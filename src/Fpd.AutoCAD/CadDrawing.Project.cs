using System.IO;
using System.Text.Json;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Fpd.Core;
using AcadApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace Fpd.AutoCAD;
using AcadColor=Autodesk.AutoCAD.Colors.Color;
internal static partial class CadDrawing
{
    private static Database? _projectLibrary;
    private static readonly object ProjectMapGate=new();
    private static ProjectBlockMap? _projectBlockMap;
    private static string ProjectLibraryPath=>Path.Combine(SymbolLibrary.DirectoryPath,"ProjectBaseSymbols.dwg");
    internal static void DisposeProjectLibrary() { _projectLibrary?.Dispose(); _projectLibrary=null; _projectBlockMap=null; }
    private static Database OpenProjectLibrary()
    {
        if(_projectLibrary is not null) return _projectLibrary;
        var db=new Database(false,true);
        try { db.ReadDwgFile(ProjectLibraryPath,FileOpenMode.OpenForReadAndAllShare,true,null); db.CloseInput(true); _projectLibrary=db; return db; }
        catch { db.Dispose(); throw; }
    }
    private sealed class ProjectBlock
    {
        public string Name { get; set; }="";
        public double[] Bounds { get; set; }=[];
        public double[] BasePoint { get; set; }=[];
        public double DisplaySizeMm { get; set; }=3.5;
        public double LabelHeightMm { get; set; }=2.5;
        public double LabelGapMm { get; set; }=1.5;
    }
    private sealed record DrawingStyle(double SymbolSize,double TextHeight,double LabelGap)
    {
        public Dictionary<ObjectId,double> BlockSizes { get; }=[];
    }
    private sealed class ProjectBlockMap
    {
        public string LibrarySha256 { get; set; }="";
        public Dictionary<string,ProjectBlock> Blocks { get; set; }=[];
    }
    private static ProjectBlockMap ProjectBlocks()
    {
        lock(ProjectMapGate)
        {
            if(_projectBlockMap is not null) return _projectBlockMap;
            var map=JsonSerializer.Deserialize<ProjectBlockMap>(File.ReadAllText(Path.Combine(SymbolLibrary.DirectoryPath,"project-symbol-map.json")))!;
            var libraryHash=HashBytes(File.ReadAllBytes(ProjectLibraryPath));
            if(!libraryHash.Equals(map.LibrarySha256,StringComparison.OrdinalIgnoreCase)) throw new InvalidOperationException("原始块库校验失败，未绘图。");
            _projectBlockMap=map; return map;
        }
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
            var target=(BlockTableRecord)rename.GetObject(mapping[sourceId].Value,OpenMode.ForWrite); target.Name=name;
            var cloned=mapping.Cast<IdPair>().Select(pair=>pair.Value).ToHashSet(); NormalizeProjectBlock(target,rename,cloned,[]); rename.Commit();
        }
    }
    private static void NormalizeProjectBlock(BlockTableRecord block,Transaction tr,HashSet<ObjectId> cloned,HashSet<ObjectId> visited)
    {
        if(!visited.Add(block.ObjectId)) return;
        foreach(ObjectId id in block)
        {
            if(tr.GetObject(id,OpenMode.ForWrite) is not Entity entity) continue;
            entity.Layer="0"; entity.Color=AcadColor.FromColorIndex(ColorMethod.ByBlock,0);
            if(entity is BlockReference nested)
            {
                var definition=(BlockTableRecord)tr.GetObject(nested.BlockTableRecord,OpenMode.ForWrite);
                if(cloned.Contains(definition.ObjectId)) NormalizeProjectBlock(definition,tr,cloned,visited);
            }
        }
    }
    private static DrawingStyle ProjectDrawingStyle(Database db)
    {
        using var scale=db.Cannoscale;
        var denominator=scale.DrawingUnits/scale.PaperUnits;
        if(!double.IsFinite(denominator) || denominator<=0)
            throw new InvalidOperationException("请先设置可用注释比例。");
        // Paper height is millimetres; project model coordinates are metres.
        // 1:1 means 0.0025 m, 1:2000 means 5 m. Never reinterpret or change
        // an existing drawing's annotation scale to make text appear larger.
        return new DrawingStyle(.0035*denominator,.0025*denominator,.0015*denominator);
    }
    private sealed record FixLabel(FixData Fix,ProjectedPoint Projected,Point3d Text,IReadOnlySet<string> Neighbours)
    {
        public Point3d Point=>new(Projected.Easting,Projected.Northing,Projected.Z);
    }
    private static IReadOnlyList<FixLabel> LayoutFixLabels(ProjectData project,DrawingStyle style)
    {
        var cm=AirportGeometry.Meridian(project);
        var points=project.Fixes.OrderBy(f=>f.Ident,StringComparer.OrdinalIgnoreCase).ThenBy(f=>f.DataId,StringComparer.Ordinal).Select(f=>
        {
            var p=Cgcs2000Projection.ForwardInZone(f.Latitude,f.Longitude,cm,f.Elevation);
            return (Fix:f,Projected:p,Point:new Point3d(p.Easting,p.Northing,p.Z));
        }).ToArray();
        if(points.Length==0) return [];
        // Conservative local text boxes, not a global chart-label optimizer.
        // A spatial index groups overlapping default labels once per operation.
        var height=style.TextHeight*1.6;
        double Width(int i)=>style.TextHeight*Math.Max(1,points[i].Fix.Ident.Length);
        var cellWidth=points.Max(p=>style.TextHeight*Math.Max(1,p.Fix.Ident.Length));
        var cells=new Dictionary<(long X,long Y),List<int>>();
        var parents=Enumerable.Range(0,points.Length).ToArray();
        int Root(int i) { while(parents[i]!=i) { parents[i]=parents[parents[i]]; i=parents[i]; } return i; }
        for(var i=0;i<points.Length;i++)
        {
            var at=points[i].Point;
            var cell=((long)Math.Floor(at.X/cellWidth),(long)Math.Floor(at.Y/height));
            for(var x=-1;x<=1;x++) for(var y=-1;y<=1;y++)
                if(cells.TryGetValue((cell.Item1+x,cell.Item2+y),out var near))
                    foreach(var j in near)
                    {
                        var other=points[j].Point;
                        if(Math.Abs(at.Y-other.Y)<height && at.X<other.X+Width(j) && other.X<at.X+Width(i)) parents[Root(i)]=Root(j);
                    }
            if(!cells.TryGetValue(cell,out var list)) cells[cell]=list=[];
            list.Add(i);
        }
        var labels=new List<FixLabel>();
        foreach(var group in Enumerable.Range(0,points.Length).GroupBy(Root))
        {
            var members=group.ToArray();
            var ids=members.Select(i=>points[i].Fix.DataId).ToHashSet(StringComparer.OrdinalIgnoreCase);
            var x=members.Max(i=>points[i].Point.X)+style.LabelGap;
            var y=members.Min(i=>points[i].Point.Y)+style.LabelGap;
            for(var rank=0;rank<members.Length;rank++)
            {
                var item=points[members[rank]];
                labels.Add(new(item.Fix,item.Projected,new Point3d(x,y+rank*height,item.Point.Z),ids));
            }
        }
        return labels;
    }
    private static string FixLabelFingerprint(ProjectData project,FixLabel label,DrawingStyle style)=>
        Hash(BaseFingerprint(project,label.Fix)+"/local-label-v3/"+
            string.Join("/",new[]{label.Text.X,label.Text.Y,label.Text.Z,style.TextHeight}.Select(v=>v.ToString("R",System.Globalization.CultureInfo.InvariantCulture))));

    private static Extents3d BlockExtents(BlockTableRecord block,Transaction tr)
    {
        Extents3d? result=null;
        foreach(ObjectId id in block)
        {
            if(tr.GetObject(id,OpenMode.ForRead) is not Entity entity) continue;
            try { var box=entity.GeometricExtents; if(result is null) result=box; else { var merged=result.Value; merged.AddExtents(box); result=merged; } }
            catch(Autodesk.AutoCAD.Runtime.Exception) { }
        }
        return result??throw new InvalidOperationException("原始图符没有有效几何外包框。");
    }
    private static BlockReference ProjectSymbol(Transaction tr,Database db,string kind,Point3d at,DrawingStyle style)
    {
        var map=ProjectBlocks(); var block=map.Blocks[kind];
        var table=(BlockTable)tr.GetObject(db.BlockTableId,OpenMode.ForRead);
        // Native geometry and insertion origin are preserved. Do not instantiate sample attributes.
        var definition=(BlockTableRecord)tr.GetObject(table[ProjectBlockName(map,block)],OpenMode.ForRead);
        if(!style.BlockSizes.TryGetValue(definition.ObjectId,out var width))
        {
            var bounds=BlockExtents(definition,tr); width=Math.Max(bounds.MaxPoint.X-bounds.MinPoint.X,bounds.MaxPoint.Y-bounds.MinPoint.Y);
            if(!double.IsFinite(width) || width<=0) throw new InvalidOperationException("原始图符没有有效几何外包框。");
            style.BlockSizes[definition.ObjectId]=width;
        }
        return new BlockReference(at,definition.ObjectId) { ScaleFactors=new Scale3d(style.SymbolSize/width),Color=AcadColor.FromColorIndex(ColorMethod.ByLayer,0) };
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
        var style=ProjectDrawingStyle(doc.Database);
        var label=LayoutFixLabels(project,style).Single(l=>l.Fix.DataId==fix.DataId);
        EnsureLayer(tr,doc.Database,"基础_定位点",3); point.UpgradeOpen(); point.Layer="基础_定位点"; point.Color=AcadColor.FromColorIndex(ColorMethod.ByLayer,256);
        var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite);
        var text=new DBText { Layer="基础_定位点",Color=AcadColor.FromColorIndex(ColorMethod.ByLayer,256),Position=label.Text,Height=style.TextHeight,TextString=fix.Ident }; model.AppendEntity(text); tr.AddNewlyCreatedDBObject(text,true);
        var group=Guid.NewGuid().ToString("N"); var fingerprint=FixLabelFingerprint(project,label,style);
        foreach(var entity in new Entity[] { point,text }) WriteBaseMark(entity,new(project.ProjectId,"Fix",fix.DataId,fix.Ident,fingerprint,GeometryStamp(entity,tr),group,2),tr);
        RememberBase(project,"Fix",fix.DataId,tr,doc.Database); tr.Commit();
    }
}
