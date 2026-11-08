using System.IO;
using System.Text.Json;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Fpd.Core;
using AcadApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace Fpd.AutoCAD;
internal static partial class CadDrawing
{
    private static Database? _projectLibrary;
    private static string ProjectLibraryPath=>Path.Combine(SymbolLibrary.DirectoryPath,"ProjectBaseSymbols.dwg");
    internal static void DisposeProjectLibrary() { _projectLibrary?.Dispose(); _projectLibrary=null; }
    private static Database OpenProjectLibrary()
    {
        if(_projectLibrary is not null) return _projectLibrary;
        var db=new Database(false,true);
        try { db.ReadDwgFile(ProjectLibraryPath,FileOpenMode.OpenForReadAndAllShare,true,null); db.CloseInput(true); _projectLibrary=db; return db; }
        catch { db.Dispose(); throw; }
    }
    private sealed record ProjectBlock(string Name,double Width);
    private sealed class ProjectBlockMap
    {
        public string LibrarySha256 { get; set; }="";
        public Dictionary<string,ProjectBlock> Blocks { get; set; }=[];
    }
    private static ProjectBlockMap ProjectBlocks()
    {
        var map=JsonSerializer.Deserialize<ProjectBlockMap>(File.ReadAllText(Path.Combine(SymbolLibrary.DirectoryPath,"project-symbol-map.json")))!;
        if(HashBytes(File.ReadAllBytes(ProjectLibraryPath))!=map.LibrarySha256) throw new InvalidOperationException("原始块库校验失败，未绘图。");
        return map;
    }
    private static string HashBytes(byte[] bytes)=>Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(bytes));
    private static string ProjectBlockName(ProjectBlockMap map,ProjectBlock block)=>"FPD_BASE_WS_"+Hash(map.LibrarySha256+"/"+block.Name)[..16];
    private static void PrepareProjectBlocks(IEnumerable<string> kinds)
    {
        var requested=kinds.Distinct().ToArray(); if(requested.Length==0) return;
        var map=ProjectBlocks(); var source=OpenProjectLibrary(); var doc=AcadApp.DocumentManager.MdiActiveDocument!;
        foreach(var kind in requested)
        {
            if(!map.Blocks.TryGetValue(kind,out var block)) throw new InvalidOperationException(kind+" 原始导航台块尚未确认；资料保留，未绘图。");
            var name=ProjectBlockName(map,block);
            using(var read=doc.Database.TransactionManager.StartTransaction())
                if(((BlockTable)read.GetObject(doc.Database.BlockTableId,OpenMode.ForRead)).Has(name)) continue;
            ObjectId sourceId;
            using(var read=source.TransactionManager.StartTransaction())
            {
                var table=(BlockTable)read.GetObject(source.BlockTableId,OpenMode.ForRead);
                if(!table.Has(block.Name)) throw new InvalidDataException("已审计原始块缺失："+block.Name);
                sourceId=table[block.Name];
            }
            using var locked=doc.LockDocument(); var mapping=new IdMapping();
            source.WblockCloneObjects(new ObjectIdCollection([sourceId]),doc.Database.BlockTableId,mapping,DuplicateRecordCloning.MangleName,false);
            using var rename=doc.Database.TransactionManager.StartTransaction();
            ((BlockTableRecord)rename.GetObject(mapping[sourceId].Value,OpenMode.ForWrite)).Name=name; rename.Commit();
        }
    }
    private static BlockReference ProjectSymbol(Transaction tr,Database db,string kind,Point3d at,double height)
    {
        var map=ProjectBlocks(); var block=map.Blocks[kind];
        var table=(BlockTable)tr.GetObject(db.BlockTableId,OpenMode.ForRead);
        // Native geometry and insertion origin are preserved. Do not instantiate sample attributes.
        return new BlockReference(at,table[ProjectBlockName(map,block)]) { ScaleFactors=new Scale3d(height*1.4/block.Width) };
    }
    public static void ShowProjectLayers(bool visible)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument; if(doc is null) return;
        using var locked=doc.LockDocument(); using var tr=doc.Database.TransactionManager.StartTransaction();
        var table=(LayerTable)tr.GetObject(doc.Database.LayerTableId,OpenMode.ForRead);
        foreach(var name in LayerNames)
        {
            if(!table.Has(name)) continue;
            var layer=(LayerTableRecord)tr.GetObject(table[name],OpenMode.ForRead);
            if(layer.IsOff==!visible && (!visible || !layer.IsFrozen)) continue;
            layer.UpgradeOpen(); layer.IsOff=!visible; if(visible && layer.ObjectId!=doc.Database.Clayer) layer.IsFrozen=false;
        }
        tr.Commit(); doc.Editor.Regen();
    }
    private sealed class ReferenceLayers : IDisposable
    {
        private readonly Autodesk.AutoCAD.ApplicationServices.Document _doc=AcadApp.DocumentManager.MdiActiveDocument!;
        private readonly List<(ObjectId Id,bool Off,bool Frozen)> _states=[];
        public ReferenceLayers()
        {
            using var locked=_doc.LockDocument(); using var tr=_doc.Database.TransactionManager.StartTransaction();
            var table=(LayerTable)tr.GetObject(_doc.Database.LayerTableId,OpenMode.ForRead);
            foreach(var name in LayerNames)
            {
                if(!table.Has(name)) continue;
                var layer=(LayerTableRecord)tr.GetObject(table[name],OpenMode.ForWrite); _states.Add((layer.ObjectId,layer.IsOff,layer.IsFrozen));
                layer.IsOff=false; if(layer.ObjectId!=_doc.Database.Clayer) layer.IsFrozen=false;
            }
            tr.Commit(); _doc.Editor.Regen();
        }
        public void Dispose()
        {
            using var locked=_doc.LockDocument(); using var tr=_doc.Database.TransactionManager.StartTransaction();
            foreach(var state in _states)
            {
                if(state.Id.IsErased) continue;
                var layer=(LayerTableRecord)tr.GetObject(state.Id,OpenMode.ForWrite); layer.IsOff=state.Off;
                if(layer.ObjectId!=_doc.Database.Clayer) layer.IsFrozen=state.Frozen;
            }
            tr.Commit(); _doc.Editor.Regen();
        }
    }
    private static IDisposable ProjectReferenceLayers()=>new ReferenceLayers();
    public static (ObjectId Id,GeoPosition Position)? PickNativePoint(ProjectData project)
    {
        using var reference=ProjectReferenceLayers(); var doc=AcadApp.DocumentManager.MdiActiveDocument!;
        var options=new PromptEntityOptions("\n选择用POINT绘制的原生点（Esc取消）："); options.SetRejectMessage("\n请选择DBPoint。"); options.AddAllowedClass(typeof(DBPoint),true);
        var result=doc.Editor.GetEntity(options); if(result.Status!=PromptStatus.OK) return null;
        using var tr=doc.Database.TransactionManager.StartTransaction(); var point=(DBPoint)tr.GetObject(result.ObjectId,OpenMode.ForRead);
        if(ReadBaseMark(point,tr) is not null) throw new InvalidOperationException("该点已有项目身份，请修改原资料。");
        return (point.ObjectId,Cgcs2000Projection.InverseInZone(point.Position.X,point.Position.Y,AirportGeometry.Meridian(project),point.Position.Z));
    }
    public static void RegisterFixPoint(ProjectData project,FixData fix,ObjectId id,double height)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument!; var p=Cgcs2000Projection.ForwardInZone(fix.Latitude,fix.Longitude,AirportGeometry.Meridian(project));
        using var locked=doc.LockDocument(); using var tr=doc.Database.TransactionManager.StartTransaction();
        if(id.IsErased || !id.IsValid) throw new InvalidOperationException("原生点已删除，未登记。");
        var point=(DBPoint)tr.GetObject(id,OpenMode.ForRead);
        if(Math.Abs(point.Position.X-p.Easting)>.01 || Math.Abs(point.Position.Y-p.Northing)>.01) throw new InvalidOperationException("登记坐标已改变，请保留所选CAD点的经纬度。");
        if(ReadBaseMark(point,tr) is not null) throw new InvalidOperationException("原生点已有身份。");
        EnsureLayer(tr,doc.Database,"FPD_FIX",3); point.UpgradeOpen(); point.Layer="FPD_FIX";
        var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite);
        var text=new DBText { Layer="FPD_FIX",Position=point.Position+new Vector3d(height*1.4,height*.4,0),Height=height,TextString=fix.Ident }; model.AppendEntity(text); tr.AddNewlyCreatedDBObject(text,true);
        var group=Guid.NewGuid().ToString("N"); var fingerprint=BaseFingerprint(project,fix,height);
        foreach(var entity in new Entity[] { point,text }) WriteBaseMark(entity,new(project.ProjectId,"Fix",fix.DataId,fix.Ident,fingerprint,GeometryStamp(entity,tr),group,2),tr);
        RememberBase(project,"Fix",fix.DataId,tr,doc.Database); tr.Commit();
    }
}
