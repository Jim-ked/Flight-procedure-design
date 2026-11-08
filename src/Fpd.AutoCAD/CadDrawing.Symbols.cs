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
        public Dictionary<string,string> Roles { get; set; }=[];
        public Dictionary<string,double> NativeWidths { get; set; }=[];
    }
    private sealed record ProgramMark(string Project,string Procedure,string? Path,string Key,string Data,string Geometry);
    private const string ProgramTag="FPD_PROGRAM_V1";
    private static ProgramMark? ReadProgramMark(Entity entity,Transaction tr)
    {
        if(entity.ExtensionDictionary.IsNull) return null;
        var dictionary=(DBDictionary)tr.GetObject(entity.ExtensionDictionary,OpenMode.ForRead);
        if(!dictionary.Contains(ProgramTag)) return null;
        using var data=((Xrecord)tr.GetObject(dictionary.GetAt(ProgramTag),OpenMode.ForRead)).Data;
        try { return JsonSerializer.Deserialize<ProgramMark>((string)data.AsArray()[0].Value); }
        catch(JsonException) { return null; }
    }
    public static void HighlightPoint(ProjectData project,ProcedureData? procedure,ProcedurePath? path,FixData fix,bool zoom)
    {
        if(procedure is null) { HighlightBasePoint(project,"Fix",fix.DataId,zoom); return; }
        var doc=AcadApp.DocumentManager.MdiActiveDocument??throw new InvalidOperationException("请先打开 DWG。");
        if(!DwgProjects.IsCurrent(project)) throw new InvalidOperationException("当前DWG与项目会话不一致。");
        using var tr=doc.Database.TransactionManager.StartTransaction();
        TrackProjectEntities(doc);
        var ids=BaseEntityIndices[doc].Find(project.ProjectId,"Program",procedure.ProcedureId+"\0"+path?.PathId+"\0"+fix.DataId,tr).ToList();
        if(ids.Count==0) ids.AddRange(BaseEntityIds(doc,project.ProjectId,"Fix",fix.DataId,tr));
        tr.Commit();
        doc.Editor.SetImpliedSelection(ids.ToArray());
        if(ids.Count==0) { doc.Editor.WriteMessage("\n当前定位点尚未生成可联动的CAD图形。"); return; }
        if(zoom) ZoomEntities(doc,ids);
        doc.Editor.UpdateScreen();
    }
    private static void ZoomEntities(Autodesk.AutoCAD.ApplicationServices.Document doc,IReadOnlyList<ObjectId> ids)
    {
        using var tr=doc.Database.TransactionManager.StartTransaction(); Extents3d? extent=null;
        foreach(var id in ids) { var e=(Entity)tr.GetObject(id,OpenMode.ForRead); try { var box=e.GeometricExtents; if(extent is null) extent=box; else { var merged=extent.Value; merged.AddExtents(box); extent=merged; } } catch(Autodesk.AutoCAD.Runtime.Exception) { } }
        tr.Commit(); if(extent is null) return;
        using var view=doc.Editor.GetCurrentView(); var transform=Matrix3d.PlaneToWorld(view.ViewDirection); transform=Matrix3d.Displacement(view.Target-Point3d.Origin)*transform; transform=Matrix3d.Rotation(-view.ViewTwist,view.ViewDirection,view.Target)*transform; var bounds=extent.Value; bounds.TransformBy(transform.Inverse()); var width=Math.Max(bounds.MaxPoint.X-bounds.MinPoint.X,100); var height=Math.Max(bounds.MaxPoint.Y-bounds.MinPoint.Y,100); var ratio=view.Width/view.Height; view.CenterPoint=new Autodesk.AutoCAD.Geometry.Point2d((bounds.MinPoint.X+bounds.MaxPoint.X)/2,(bounds.MinPoint.Y+bounds.MaxPoint.Y)/2); view.Height=Math.Max(height,width/ratio)*1.25; view.Width=view.Height*ratio; doc.Editor.SetCurrentView(view);
    }
    public static void HighlightBasePoint(ProjectData project,string kind,string key,bool zoom)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument??throw new InvalidOperationException("请先打开 DWG。");
        if(!DwgProjects.IsCurrent(project)) throw new InvalidOperationException("当前DWG与项目会话不一致。");
        var watch=System.Diagnostics.Stopwatch.StartNew();
        ObjectId[] ids;
        using(var tr=doc.Database.TransactionManager.StartTransaction())
        {
            ids=BaseEntityIds(doc,project.ProjectId,kind,key,tr);
            tr.Commit();
        }
        // Read-only selection must not create an undo marker or acquire a write lock.
        doc.Editor.SetImpliedSelection(ids);
        doc.Editor.UpdateScreen();
        System.Diagnostics.Trace.WriteLine($"FPD selection lookup+highlight {watch.Elapsed.TotalMilliseconds:F3} ms");
        if(ids.Length==0) { if(zoom) doc.Editor.WriteMessage("\n当前对象尚未生成可联动的CAD图形。"); return; }
        if(zoom)
        {
            watch.Restart(); ZoomEntities(doc,ids);
            System.Diagnostics.Trace.WriteLine($"FPD selection zoom {watch.Elapsed.TotalMilliseconds:F3} ms");
        }
    }
    public static void RemoveProcedurePath(ProjectData project,string procedureId,string pathId)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument??throw new InvalidOperationException("请先打开 DWG。");
        if(!DwgProjects.IsCurrent(project)) throw new InvalidOperationException("当前DWG与项目会话不一致。");
        using var locked=doc.LockDocument(); using var tr=doc.Database.TransactionManager.StartTransaction(); var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite); var conflicts=0; var removed=0;
        foreach(ObjectId id in model)
        {
            var e=(Entity)tr.GetObject(id,OpenMode.ForRead); if(e.ExtensionDictionary.IsNull) continue; var d=(DBDictionary)tr.GetObject(e.ExtensionDictionary,OpenMode.ForRead); if(!d.Contains(ProgramTag)) continue;
            using var data=((Xrecord)tr.GetObject(d.GetAt(ProgramTag),OpenMode.ForRead)).Data; ProgramMark? mark; try { mark=JsonSerializer.Deserialize<ProgramMark>((string)data.AsArray()[0].Value); } catch { continue; }
            if(mark is null || mark.Project!=project.ProjectId || mark.Procedure!=procedureId || mark.Path!=pathId) continue;
            if(!GeometryUnchanged(e,mark.Geometry,tr)) { conflicts++; continue; }
            e.UpgradeOpen(); e.Erase(); removed++;
        }
        tr.Commit(); doc.Editor.Regen(); doc.Editor.WriteMessage($"\n已移除路径图符 {removed} 个；冲突保留 {conflicts} 个。");
    }
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
        if(!DwgProjects.IsCurrent(project)) throw new InvalidOperationException("请切回项目所属DWG。");
        if(!project.Procedures.Contains(procedure) || !procedure.Paths.Contains(selected)) throw new InvalidOperationException("程序/路径目标已变化。");
        ProjectValidation.Project(project); ProjectDataIds.Ensure(project); var mapping=LoadSymbols();
        // A drawing operation is scoped to the selected path. Path identity is persisted on every entity.
        var uses=selected.Fixes.GroupBy(use=>(Ident:use.FixIdent.ToUpperInvariant(),use.SymbolKey)).ToArray();
        var missing=uses.Select(g=>g.Key.SymbolKey).Distinct().Where(key=>!mapping.Symbols.ContainsKey(key)).ToArray();
        if(missing.Length>0) throw new InvalidOperationException("旧库未确认可用图符："+string.Join("、",missing));
        var blockIds=new Dictionary<string,ObjectId>();
        var phase="打开已审计块库";
        try
        {
        var source=SymbolLibrary.Open();
        {
            foreach(var key in uses.Select(g=>g.Key.SymbolKey).Distinct())
            {
                phase="查找块定义 "+key;
                var name=mapping.Symbols[key];
                var qualified="FPD_WS_"+Hash(mapping.LibrarySha256+"/"+name)[..16];
                ObjectId sourceId;
                using(var sourceTr=source.TransactionManager.StartTransaction())
                {
                    var blocks=(BlockTable)sourceTr.GetObject(source.BlockTableId,OpenMode.ForRead);
                    if(!blocks.Has(name)) throw new InvalidOperationException("审计映射块缺失："+name);
                    sourceId=blocks[name];
                    sourceTr.Commit();
                }
                using(var locked=doc.LockDocument())
                {
                    using(var read=doc.Database.TransactionManager.StartTransaction())
                    {
                        var target=(BlockTable)read.GetObject(doc.Database.BlockTableId,OpenMode.ForRead);
                        if(target.Has(qualified)) { blockIds[key]=target[qualified]; continue; }
                    }
                    phase="导入块定义 "+name;
                    var ids=new IdMapping(); source.WblockCloneObjects(new ObjectIdCollection([sourceId]),doc.Database.BlockTableId,ids,DuplicateRecordCloning.MangleName,false);
                    if(!ids.Contains(sourceId)) throw new InvalidOperationException("AutoCAD 未返回审计块的 IdMapping："+name);
                    var mapped=ids[sourceId].Value;
                    if(mapped.IsNull || !mapped.IsValid) throw new InvalidOperationException("AutoCAD 返回了无效的克隆块 ObjectId："+name);
                    phase="命名导入块 "+name;
                    using(var rename=doc.Database.TransactionManager.StartTransaction())
                    {
                        var definition=(BlockTableRecord)rename.GetObject(mapped,OpenMode.ForWrite);
                        definition.Name=qualified;
                        rename.Commit();
                    }
                    blockIds[key]=mapped;
                }
            }
        }
        phase="建立程序图层";
        using var lockedTarget=doc.LockDocument();
        using var tr=doc.Database.TransactionManager.StartTransaction(); var layer="FPD_P_"+Hash(procedure.ProcedureId)[..8]+"_"+Hash(selected.PathId)[..8]+"_SYMBOL"; EnsureLayer(tr,doc.Database,layer,7);
        var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite);
        var existing=new List<(Entity Entity,ProgramMark Mark)>();
        foreach(ObjectId id in model)
        {
            var e=(Entity)tr.GetObject(id,OpenMode.ForRead); if(e.ExtensionDictionary.IsNull) continue;
            var d=(DBDictionary)tr.GetObject(e.ExtensionDictionary,OpenMode.ForRead); if(!d.Contains(ProgramTag)) continue;
            using var data=((Xrecord)tr.GetObject(d.GetAt(ProgramTag),OpenMode.ForRead)).Data;
            var mark=JsonSerializer.Deserialize<ProgramMark>((string)data.AsArray()[0].Value);
            if(mark is not null && mark.Project==project.ProjectId && mark.Procedure==procedure.ProcedureId && mark.Path==selected.PathId) existing.Add((e,mark));
        }
        var desired=new HashSet<string>(); var added=0; var conflicts=0;
        void Add(Entity e,string key,string data)
        {
            phase="写入图符 "+key+" / "+e.GetType().Name;
            e.Layer=layer; model.AppendEntity(e); tr.AddNewlyCreatedDBObject(e,true); e.CreateExtensionDictionary(); var d=(DBDictionary)tr.GetObject(e.ExtensionDictionary,OpenMode.ForWrite); var record=new Xrecord(); d.SetAt(ProgramTag,record); tr.AddNewlyCreatedDBObject(record,true);
            phase="检查图符几何 "+key+" / "+e.GetType().Name;
            var geometry=GeometryStamp(e,tr);
            phase="保存图符标记 "+key;
            using var buffer=new ResultBuffer(new TypedValue((int)DxfCode.Text,JsonSerializer.Serialize(new ProgramMark(project.ProjectId,procedure.ProcedureId,selected.PathId,key,data,geometry)))); record.Data=buffer;
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
