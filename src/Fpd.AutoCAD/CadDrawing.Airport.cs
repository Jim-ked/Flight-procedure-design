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
    private static ObjectId EnsureLayer(Transaction tr,Database db,string name,short color)
    {
        var layers=(LayerTable)tr.GetObject(db.LayerTableId,OpenMode.ForRead);
        if(!layers.Has(name)) { layers.UpgradeOpen(); var value=new LayerTableRecord { Name=name,Color=Autodesk.AutoCAD.Colors.Color.FromColorIndex(ColorMethod.ByAci,color) }; layers.Add(value); tr.AddNewlyCreatedDBObject(value,true); }
        var layer=(LayerTableRecord)tr.GetObject(layers[name],OpenMode.ForRead);
        if(layer.IsLocked || layer.IsOff || layer.IsFrozen) throw new InvalidOperationException("请先显示、解冻并解锁 "+name);
        return layer.ObjectId;
    }
    public static Point3d? PickWcsPoint()
    {
        using var reference=ProjectReferenceLayers();
        var editor=AcadApp.DocumentManager.MdiActiveDocument!.Editor; var result=editor.GetPoint("\n拾取WCS坐标（Esc取消）：");
        return result.Status==PromptStatus.OK?result.Value.TransformBy(editor.CurrentUserCoordinateSystem):null;
    }
    public static GeoPosition? PickPosition(ProjectData project)
    {
        using var reference=ProjectReferenceLayers();
        var cm=AirportGeometry.Meridian(project); var doc=AcadApp.DocumentManager.MdiActiveDocument!;
        var result=doc.Editor.GetPoint("\n拾取位置（当前项目投影米坐标；Esc取消）：");
        if(result.Status!=PromptStatus.OK) return null;
        var p=result.Value.TransformBy(doc.Editor.CurrentUserCoordinateSystem);
        var position=Cgcs2000Projection.InverseInZone(p.X,p.Y,cm,p.Z);
        if(p.Z==0) position.Elevation=null; // A planar pick does not establish a real zero elevation.
        return position;
    }
    public static IReadOnlyList<string> SelectProjectPoints(ProjectData project,int kind)
    {
        using var reference=ProjectReferenceLayers();
        var doc=AcadApp.DocumentManager.MdiActiveDocument!; var cm=AirportGeometry.Meridian(project);
        var result=doc.Editor.GetSelection(new PromptSelectionOptions { MessageForAdding="\n选择项目中已有的点/符号：" },new SelectionFilter([new TypedValue((int)DxfCode.Start,"INSERT,POINT")]));
        if(result.Status!=PromptStatus.OK) return [];
        var positions=kind switch
        {
            1=>project.Obstacles.Select(o=>(o.Ident,new GeoPosition { Latitude=o.Latitude,Longitude=o.Longitude,Elevation=o.TopElevation })),
            3=>project.Navaids.Select(n=>(n.Ident,n.Position)),
            _=>project.Fixes.Select(f=>(f.Ident,new GeoPosition { Latitude=f.Latitude,Longitude=f.Longitude,Elevation=f.Elevation??0 }))
        };
        var values=positions.Select(v=>(v.Ident,Point:AirportGeometry.Project(v.Item2,cm))).ToArray(); var selected=new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var expectedLayer=kind==1?"基础_障碍物":kind==3?"基础_导航台":"基础_定位点";
        using var tr=doc.Database.TransactionManager.StartTransaction();
        foreach(var id in result.Value.GetObjectIds())
        {
            var entity=tr.GetObject(id,OpenMode.ForRead); Point3d at; string? name=null;
            if(entity is BlockReference block)
            {
                if(!block.Layer.Equals(expectedLayer,StringComparison.OrdinalIgnoreCase)) continue;
                at=block.Position;
                foreach(ObjectId a in block.AttributeCollection) if(tr.GetObject(a,OpenMode.ForRead) is AttributeReference attribute && attribute.Tag=="NAME") name=attribute.TextString;
            }
            else if(entity is DBPoint point) at=point.Position; else continue;
            var matches=values.Where(v=>(name is null || v.Ident.Equals(name,StringComparison.OrdinalIgnoreCase)) && Math.Abs(at.X-v.Point.Easting)<.01 && Math.Abs(at.Y-v.Point.Northing)<.01 && Math.Abs(at.Z-v.Point.Z)<.01).ToArray();
            if(matches.Length==1) selected.Add(matches[0].Ident);
            else if(name is not null) throw new InvalidOperationException("图形标识/位置与项目不一致，未自动覆盖："+name);
        }
        doc.Editor.WriteMessage($"\n已匹配 {selected.Count} 个项目对象；取消或未匹配不更改资料。"); return selected.ToArray();
    }
    private static void DrawRunways(ProjectData project,IReadOnlyList<RunwayData> runways,double textHeight,Transaction tr)
    {
        if(runways.Count==0) throw new InvalidOperationException("请选择跑道。");
        ProjectValidation.Project(project); var cm=AirportGeometry.Meridian(project); var doc=AcadApp.DocumentManager.MdiActiveDocument!;

        var style=ProjectDrawingStyle(doc.Database);
        EnsureLayer(tr,doc.Database,"基础_跑道",7); var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite);
        void Add(Entity e) { e.Layer="基础_跑道"; e.Color=AcadColor.FromColorIndex(ColorMethod.ByLayer,0); model.AppendEntity(e); tr.AddNewlyCreatedDBObject(e,true); }
        Point3d Point(GeoPosition p) { var c=AirportGeometry.Project(p,cm); return new(c.Easting,c.Northing,c.Z); }
        foreach(var runway in runways)
        {
            var a=Point(runway.EndA.PhysicalEnd); var b=Point(runway.EndB.PhysicalEnd); var delta=b-a; var direction=new Vector3d(delta.X,delta.Y,0).GetNormal(); var side=new Vector3d(-direction.Y,direction.X,0);
            var corners=new[] { a+side*runway.Width/2,b+side*runway.Width/2,b-side*runway.Width/2,a-side*runway.Width/2 };
            // Polyline3d retains the different physical endpoint elevations.
            Add(new Polyline3d(Poly3dType.SimplePoly,new Point3dCollection(corners),true));
            Add(new Line(a,b) { LinetypeScale=1 });
            foreach(var end in new[] { runway.EndA,runway.EndB })
            {
                var physical=Point(end.PhysicalEnd); var thr=Point(end.Threshold); var der=Point(end.DepartureEnd);
                Add(new Line(thr-side*runway.Width/2,thr+side*runway.Width/2));
                Add(new DBText { Position=physical+side*(runway.Width/2+style.LabelGap),Height=style.TextHeight,TextString=end.Designator });
                if(!RunwayDefaults.Same(end.Threshold,end.PhysicalEnd))
                    Add(new DBText { Position=thr+side*(runway.Width/2+style.LabelGap),Height=style.TextHeight,TextString=end.Designator+" THR" });
                var opposite=ReferenceEquals(end,runway.EndA)?runway.EndB:runway.EndA;
                if(!RunwayDefaults.Same(end.DepartureEnd,opposite.PhysicalEnd))
                {
                    Add(new Circle(der,Vector3d.ZAxis,Math.Max(runway.Width/6,2)));
                    Add(new DBText { Position=der-side*(runway.Width/2+style.LabelGap),Height=style.TextHeight,TextString=end.Designator+" DER" });
                }
            }
        }

    }
    private static void DrawNavaids(ProjectData project,IReadOnlyList<NavaidData> navaids,double height,Transaction tr)
    {
        if(navaids.Count==0) throw new InvalidOperationException("请选择导航设施。"); ProjectValidation.Project(project); var cm=AirportGeometry.Meridian(project); var doc=AcadApp.DocumentManager.MdiActiveDocument!;
        EnsureLayer(tr,doc.Database,"基础_导航台",4);
        var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite);
        foreach(var n in navaids)
        {
            var p=AirportGeometry.Project(n.Position,cm); var at=new Point3d(p.Easting,p.Northing,p.Z);
            var entity=ProjectSymbol(tr,doc.Database,n.Kind.ToString(),at,height); entity.Layer="基础_导航台"; entity.Color=AcadColor.FromColorIndex(ColorMethod.ByLayer,0);
            model.AppendEntity(entity); tr.AddNewlyCreatedDBObject(entity,true);
            var style=ProjectDrawingStyle(doc.Database);
            var label=new DBText { Layer="基础_导航台",Color=AcadColor.FromColorIndex(ColorMethod.ByLayer,0),Position=at+new Vector3d(style.LabelGap,style.LabelGap,0),Height=style.TextHeight,TextString=n.Ident };
            model.AppendEntity(label); tr.AddNewlyCreatedDBObject(label,true);
        }

    }
}
