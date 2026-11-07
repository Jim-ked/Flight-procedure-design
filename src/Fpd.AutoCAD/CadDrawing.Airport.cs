using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Fpd.Core;
using AcadApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace Fpd.AutoCAD;

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
    public static GeoPosition? PickPosition(ProjectData project)
    {
        var cm=AirportGeometry.Meridian(project); var doc=AcadApp.DocumentManager.MdiActiveDocument!;
        var result=doc.Editor.GetPoint("\n拾取位置（当前项目投影米坐标；Esc取消）：");
        if(result.Status!=PromptStatus.OK) return null;
        var p=result.Value.TransformBy(doc.Editor.CurrentUserCoordinateSystem);
        return Cgcs2000Projection.InverseInZone(p.X,p.Y,cm,p.Z);
    }
    public static IReadOnlyList<string> SelectProjectPoints(ProjectData project,int kind)
    {
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
        var expectedLayer=kind==1?"FPD_OBSTACLE":kind==3?"FPD_NAVAID":"FPD_FIX";
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
    public static void DrawRunways(ProjectData project,IReadOnlyList<RunwayData> runways,double textHeight)
    {
        if(runways.Count==0) throw new InvalidOperationException("请选择跑道。");
        ProjectValidation.Project(project); var cm=AirportGeometry.Meridian(project); var doc=AcadApp.DocumentManager.MdiActiveDocument!;
        using var locked=doc.LockDocument(); using var tr=doc.Database.TransactionManager.StartTransaction();
        EnsureLayer(tr,doc.Database,"FPD_RUNWAY",7); var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite);
        void Add(Entity e) { e.Layer="FPD_RUNWAY"; model.AppendEntity(e); tr.AddNewlyCreatedDBObject(e,true); }
        Point3d Point(GeoPosition p) { var c=AirportGeometry.Project(p,cm); return new(c.Easting,c.Northing,c.Z); }
        foreach(var runway in runways)
        {
            var a=Point(runway.EndA.PhysicalEnd); var b=Point(runway.EndB.PhysicalEnd); var delta=b-a; var direction=new Vector3d(delta.X,delta.Y,0).GetNormal(); var side=new Vector3d(-direction.Y,direction.X,0);
            var corners=new[] { a+side*runway.Width/2,b+side*runway.Width/2,b-side*runway.Width/2,a-side*runway.Width/2 };
            // Polyline3d retains the different physical endpoint elevations.
            Add(new Polyline3d(Poly3dType.SimplePoly,new Point3dCollection(corners),true));
            Add(new Line(a,b) { LinetypeScale=1 });
            var labels=new List<(Point3d At,string Text)>();
            foreach(var end in new[] { runway.EndA,runway.EndB })
            {
                var physical=Point(end.PhysicalEnd); var thr=Point(end.Threshold); var der=Point(end.DepartureEnd);
                Add(new Line(thr-side*runway.Width/2,thr+side*runway.Width/2));
                Add(new Circle(der,Vector3d.ZAxis,Math.Max(runway.Width/6,2)));
                labels.Add((physical,end.Designator+" END "+end.PhysicalEnd.Elevation.ToString("0.##")+"m"));
                labels.Add((thr,end.Designator+" THR "+end.Threshold.Elevation.ToString("0.##")+"m"));
                labels.Add((der,end.Designator+" DER "+end.DepartureEnd.Elevation.ToString("0.##")+"m"));
            }
            // Stack labels beside the nearest physical end. Offsetting every label along
            // the runway normal alone overlaps horizontal text on north/south runways.
            foreach(var anchor in new[] { a,b })
            {
                var rows=labels.Where(l=>(l.At.DistanceTo(a)<=l.At.DistanceTo(b))==(anchor==a)).ToArray();
                for(var i=0;i<rows.Length;i++)
                {
                    var at=anchor+side*(runway.Width/2+textHeight*2)+new Vector3d(0,(rows.Length-1-i)*textHeight*1.6,0);
                    Add(new DBText { Position=at,Height=textHeight,TextString=rows[i].Text });
                    Add(new Line(rows[i].At,at-new Vector3d(textHeight*.3,0,0)));
                }
            }
        }
        tr.Commit(); doc.Editor.Regen(); doc.Editor.WriteMessage($"\n已绘制 {runways.Count} 条跑道（END/THR/DER），U撤销本次绘图。");
    }
    public static void DrawNavaids(ProjectData project,IReadOnlyList<NavaidData> navaids,double height)
    {
        if(navaids.Count==0) throw new InvalidOperationException("请选择导航设施。"); ProjectValidation.Project(project); var cm=AirportGeometry.Meridian(project); var doc=AcadApp.DocumentManager.MdiActiveDocument!;
        using var locked=doc.LockDocument(); using var tr=doc.Database.TransactionManager.StartTransaction(); EnsureLayer(tr,doc.Database,"FPD_NAVAID",4);
        var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite); var blocks=(BlockTable)tr.GetObject(doc.Database.BlockTableId,OpenMode.ForRead);
        foreach(var n in navaids)
        {
            var name="FPD_NAVAID_F1_"+n.Kind;
            if(!blocks.Has(name))
            {
                blocks.UpgradeOpen(); var definition=new BlockTableRecord { Name=name }; blocks.Add(definition); tr.AddNewlyCreatedDBObject(definition,true);
                void Add(Entity entity) { entity.Layer="0"; definition.AppendEntity(entity); tr.AddNewlyCreatedDBObject(entity,true); }
                Add(new Circle(Point3d.Origin,Vector3d.ZAxis,.5));
                if(n.Kind==NavaidKind.VOR) { var hex=new Polyline(); for(var i=0;i<6;i++) hex.AddVertexAt(i,new Point2d(Math.Cos(i*Math.PI/3)*.7,Math.Sin(i*Math.PI/3)*.7),0,0,0); hex.Closed=true; Add(hex); }
                if(n.Kind==NavaidKind.DME) { var square=new Polyline(); foreach(var (x,y) in new[] { (-.7,-.7),(.7,-.7),(.7,.7),(-.7,.7) }) square.AddVertexAt(square.NumberOfVertices,new(x,y),0,0,0); square.Closed=true; Add(square); }
                if(n.Kind==NavaidKind.NDB) Add(new Circle(Point3d.Origin,Vector3d.ZAxis,.8));
                if(n.Kind==NavaidKind.ILS) { Add(new Line(new(-.8,-.8,0),new(.8,.8,0))); Add(new Line(new(-.8,.8,0),new(.8,-.8,0))); }
                Add(new AttributeDefinition(new(.9,.4,0),"","NAME","设施标识",doc.Database.Textstyle) { Height=1 });
                Add(new AttributeDefinition(new(.9,-.8,0),"","TYPE","设施类型",doc.Database.Textstyle) { Height=.7 });
            }
            var p=AirportGeometry.Project(n.Position,cm); var reference=new BlockReference(new(p.Easting,p.Northing,p.Z),blocks[name]) { Layer="FPD_NAVAID",ScaleFactors=new(height) }; model.AppendEntity(reference); tr.AddNewlyCreatedDBObject(reference,true);
            if(n.Kind==NavaidKind.ILS && n.GlidePathPosition is { } gp)
            {
                var g=AirportGeometry.Project(gp,cm); var at=new Point3d(g.Easting,g.Northing,g.Z);
                var symbol=new Circle(at,Vector3d.ZAxis,height*.25) { Layer="FPD_NAVAID" }; model.AppendEntity(symbol); tr.AddNewlyCreatedDBObject(symbol,true);
                var label=new DBText { Layer="FPD_NAVAID",Position=at+new Vector3d(height*.5,-height*2,0),Height=height*.7,TextString=n.Ident+" GP "+n.GlidePathAngle?.ToString("0.##")+" deg" }; model.AppendEntity(label); tr.AddNewlyCreatedDBObject(label,true);
            }
            var block=(BlockTableRecord)tr.GetObject(blocks[name],OpenMode.ForRead);
            foreach(ObjectId id in block) if(tr.GetObject(id,OpenMode.ForRead) is AttributeDefinition def) { var attribute=new AttributeReference(); attribute.SetAttributeFromBlock(def,reference.BlockTransform); attribute.TextString=def.Tag=="NAME"?n.Ident:n.Kind.ToString(); reference.AttributeCollection.AppendAttribute(attribute); tr.AddNewlyCreatedDBObject(attribute,true); }
        }
        tr.Commit(); doc.Editor.Regen(); doc.Editor.WriteMessage($"\n已绘制 {navaids.Count} 个设施符号及名称，U撤销本次绘图。");
    }
}
