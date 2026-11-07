using System.IO;
using System.Text.Json;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Fpd.Core;
using AcadApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
namespace Fpd.AutoCAD;
internal static partial class CadDrawing
{
    private sealed class SymbolMap
    {
        public string LibrarySha256 { get; set; }="";
        public Dictionary<string,string> Symbols { get; set; }=[];
        public Dictionary<string,double> NativeWidths { get; set; }=[];
    }
    private sealed record ProgramMark(string Project,string Procedure,string Key,string Data,string Geometry);
    private const string ProgramTag="FPD_PROGRAM_V1";
    private static SymbolMap LoadSymbols()
    {
        var map=JsonSerializer.Deserialize<SymbolMap>(File.ReadAllText(Path.Combine(SymbolLibrary.DirectoryPath,"symbol-map.json")))??throw new InvalidDataException("符号映射无效。");
        var hash=Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(SymbolLibrary.LibraryPath)));
        if(!hash.Equals(map.LibrarySha256,StringComparison.OrdinalIgnoreCase)) throw new InvalidOperationException("符号库尚未完成实际块表审计和映射确认；不会猜测块名或使用替代图符。");
        return map;
    }
    public static void DrawProcedure(ProjectData project,ProcedureData procedure,ProcedurePath selected,double scale,double textHeight)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument!;
        if(!BaseMapPolicy.CanWrite(project.DwgPath,doc.Name)) throw new InvalidOperationException("请打开明确关联的项目DWG。");
        if(!project.Procedures.Contains(procedure) || !procedure.Paths.Contains(selected)) throw new InvalidOperationException("程序/路径目标已变化。");
        ProjectValidation.Project(project); ProjectDataIds.Ensure(project); var mapping=LoadSymbols();
        // One native symbol per program/Fix/symbol; path names never enter layer ownership.
        var uses=procedure.Paths.SelectMany(path=>path.Fixes).GroupBy(use=>(Ident:use.FixIdent.ToUpperInvariant(),use.SymbolKey)).ToArray();
        var missing=uses.Select(g=>g.Key.SymbolKey).Distinct().Where(key=>!mapping.Symbols.ContainsKey(key)).ToArray();
        if(missing.Length>0) throw new InvalidOperationException("旧库未确认可用图符："+string.Join("、",missing));
        var blockIds=new Dictionary<string,ObjectId>();
        var phase="打开已审计块库";
        try
        {
        using var locked=doc.LockDocument();
        using(var source=new Database(false,true))
        {
            source.ReadDwgFile(SymbolLibrary.LibraryPath,FileShare.Read,true,null); source.CloseInput(true);
            using var sourceTr=source.TransactionManager.StartTransaction(); var blocks=(BlockTable)sourceTr.GetObject(source.BlockTableId,OpenMode.ForRead);
            foreach(var key in uses.Select(g=>g.Key.SymbolKey).Distinct())
            {
                phase="查找块定义 "+key;
                var name=mapping.Symbols[key]; if(!blocks.Has(name)) throw new InvalidOperationException("审计映射块缺失："+name);
                var qualified="FPD_WS_"+Hash(mapping.LibrarySha256+"/"+name)[..16];
                using(var read=doc.Database.TransactionManager.StartTransaction()) { var target=(BlockTable)read.GetObject(doc.Database.BlockTableId,OpenMode.ForRead); if(target.Has(qualified)) { blockIds[key]=target[qualified]; continue; } }
                phase="导入块定义 "+name;
                var ids=new IdMapping(); source.WblockCloneObjects(new ObjectIdCollection([blocks[name]]),doc.Database.BlockTableId,ids,DuplicateRecordCloning.MangleName,false);
                phase="命名导入块 "+name;
                using var rename=doc.Database.TransactionManager.StartTransaction(); var id=ids[blocks[name]].Value; var definition=(BlockTableRecord)rename.GetObject(id,OpenMode.ForWrite); definition.Name=qualified; blockIds[key]=id; rename.Commit();
            }
        }
        phase="建立程序图层";
        using var tr=doc.Database.TransactionManager.StartTransaction(); var layer="FPD_P_"+Hash(procedure.ProcedureId)[..12]+"_SYMBOL"; EnsureLayer(tr,doc.Database,layer,7);
        var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite);
        var existing=new List<(Entity Entity,ProgramMark Mark)>();
        foreach(ObjectId id in model)
        {
            var e=(Entity)tr.GetObject(id,OpenMode.ForRead); if(e.ExtensionDictionary.IsNull) continue;
            var d=(DBDictionary)tr.GetObject(e.ExtensionDictionary,OpenMode.ForRead); if(!d.Contains(ProgramTag)) continue;
            using var data=((Xrecord)tr.GetObject(d.GetAt(ProgramTag),OpenMode.ForRead)).Data;
            var mark=JsonSerializer.Deserialize<ProgramMark>((string)data.AsArray()[0].Value);
            if(mark is not null && mark.Project==project.ProjectId && mark.Procedure==procedure.ProcedureId) existing.Add((e,mark));
        }
        var desired=new HashSet<string>(); var added=0; var conflicts=0;
        void Add(Entity e,string key,string data)
        {
            phase="写入图符 "+key+" / "+e.GetType().Name;
            e.Layer=layer; model.AppendEntity(e); tr.AddNewlyCreatedDBObject(e,true); e.CreateExtensionDictionary(); var d=(DBDictionary)tr.GetObject(e.ExtensionDictionary,OpenMode.ForWrite); var record=new Xrecord(); d.SetAt(ProgramTag,record); tr.AddNewlyCreatedDBObject(record,true);
            phase="检查图符几何 "+key+" / "+e.GetType().Name;
            var geometry=GeometryStamp(e,tr);
            phase="保存图符标记 "+key;
            using var buffer=new ResultBuffer(new TypedValue((int)DxfCode.Text,JsonSerializer.Serialize(new ProgramMark(project.ProjectId,procedure.ProcedureId,key,data,geometry)))); record.Data=buffer;
        }
        foreach(var group in uses)
        {
            var fix=project.Fixes.Single(f=>f.Ident.Equals(group.Key.Ident,StringComparison.OrdinalIgnoreCase)); var key=fix.DataId+"/"+group.Key.SymbolKey; desired.Add(key);
            var p=PointProjection.Fixes(project,[fix])[0].Point; var note=string.Join(" / ",group.Select(u=>u.Annotation).Where(n=>!string.IsNullOrWhiteSpace(n)).Distinct());
            var data=Hash(JsonSerializer.Serialize(new { p.Easting,p.Northing,p.Z,scale,textHeight,note,Symbol=group.Key.SymbolKey }));
            var found=existing.Where(x=>x.Mark.Key==key).ToArray();
            if(found.Length>0)
            {
                if(found.Any(x=>!GeometryUnchanged(x.Entity,x.Mark.Geometry,tr))) { conflicts++; continue; }
                if(found.All(x=>x.Mark.Data==data)) continue;
                foreach(var x in found) { x.Entity.UpgradeOpen(); x.Entity.Erase(); }
            }
            var at=new Point3d(p.Easting,p.Northing,p.Z); var symbol=new BlockReference(at,blockIds[group.Key.SymbolKey]) { ScaleFactors=new Scale3d(scale / (mapping.NativeWidths.TryGetValue(group.Key.SymbolKey,out var width) && width>0?width:throw new InvalidDataException("缺少已审计的图符宽度。"))),ColorIndex=256 };
            // Library attributes are annotations; no sample default is emitted into production drawings.
            Add(symbol,key,data);
            if(note.Length>0) Add(new DBText { Position=at+new Vector3d(scale*.65,scale*.65,0),Height=textHeight,TextString=note,ColorIndex=256 },key,data);
            added++;
        }
        foreach(var orphan in existing.Where(x=>!desired.Contains(x.Mark.Key)))
        {
            if(!GeometryUnchanged(orphan.Entity,orphan.Mark.Geometry,tr)) { conflicts++; continue; }
            orphan.Entity.UpgradeOpen(); orphan.Entity.Erase();
        }
        phase="提交图符事务";
        tr.Commit(); doc.Editor.Regen(); doc.Editor.WriteMessage($"\n程序图符新增/更新 {added}，冲突保留 {conflicts}；图层 {layer}；不生成航迹折线。");
        }
        catch(System.Exception ex)
        {
            var log=Path.Combine(Path.GetDirectoryName(typeof(CadDrawing).Assembly.Location)!,"diagnostics","symbol-errors.log");
            try { Directory.CreateDirectory(Path.GetDirectoryName(log)!); File.AppendAllText(log,$"{DateTime.UtcNow:O} {phase}\n{ex}\n"); } catch(IOException) { } catch(UnauthorizedAccessException) { }
            throw new InvalidOperationException($"程序图符失败（{phase}）：{ex.Message}\n诊断记录：{log}",ex);
        }
    }
}
