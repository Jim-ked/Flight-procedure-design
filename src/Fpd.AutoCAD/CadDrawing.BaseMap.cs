using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Fpd.Core;
using AcadApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
namespace Fpd.AutoCAD;

internal static partial class CadDrawing
{
    private const string BaseTag="FPD_BASE_V1";
    private sealed record BaseMark(string Project,string Kind,string Key,string Ident,string Data,string Geometry,string Group,int Count,bool Archived=false);
    private sealed record BaseItem(string Kind,string Key,string Ident,string Layer,string Data,Action<Transaction> Draw);
    private static string Hash(string value)=>Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
    private static string BaseFingerprint(ProjectData project,object data)=>Hash(JsonSerializer.Serialize(new { CM=AirportGeometry.Meridian(project),Data=data }));
    private static string HistoryKey(ProjectData project,string kind,string key)=>"FPD_B_"+Hash(project.ProjectId+"/"+kind+"/"+key);
    private static bool WasDrawn(ProjectData project,string kind,string key,Transaction tr,Database db)=>
        ((DBDictionary)tr.GetObject(db.NamedObjectsDictionaryId,OpenMode.ForRead)).Contains(HistoryKey(project,kind,key));
    private static void RememberBase(ProjectData project,string kind,string key,Transaction tr,Database db)
    {
        var dictionary=(DBDictionary)tr.GetObject(db.NamedObjectsDictionaryId,OpenMode.ForWrite); var name=HistoryKey(project,kind,key);
        if(dictionary.Contains(name)) return;
        var record=new Xrecord(); dictionary.SetAt(name,record); tr.AddNewlyCreatedDBObject(record,true);
    }
    private static string GeometryStamp(Entity entity,Transaction tr)
    {
        // Only our small set of native base-map entities is eligible for automatic updates.
        var s=new StringBuilder(); void Add(object? value)=>s.Append(value is double d?d.ToString("R",CultureInfo.InvariantCulture):value).Append('|');
        void Point(Point3d p) { Add(p.X); Add(p.Y); Add(p.Z); }
        Add(entity.GetType().Name); Add(entity.Layer); Add(entity.ColorIndex); Add(entity.Linetype); Add(entity.Visible); Add(entity.LinetypeScale); Add(entity.LineWeight); var opacity=entity.Transparency; Add(opacity.IsByAlpha?(object)opacity.Alpha:opacity.IsByLayer?"ByLayer":"ByBlock");
        Add(entity.Color.ColorMethod); if(entity.Color.ColorMethod==Autodesk.AutoCAD.Colors.ColorMethod.ByColor) Add(entity.Color.ColorValue.ToArgb());
        switch(entity)
        {
            case BlockReference b:
                Point(b.Position); Add(b.Rotation); Add(b.ScaleFactors); Add(b.BlockTableRecord.Handle);
                foreach(ObjectId id in b.AttributeCollection) { var a=(AttributeReference)tr.GetObject(id,OpenMode.ForRead); Add(a.Tag); Add(a.TextString); Point(a.Position); Add(a.Height); Add(a.Rotation); Add(a.Invisible); }
                var definition=(BlockTableRecord)tr.GetObject(b.BlockTableRecord,OpenMode.ForRead);
                foreach(ObjectId id in definition) Add(GeometryStamp((Entity)tr.GetObject(id,OpenMode.ForRead),tr)); break;
            case DBText t: Point(t.Position); Add(t.TextString); Add(t.Height); Add(t.Rotation); Add(t.TextStyleId.Handle); Add(t.Normal); Add(t.WidthFactor); Add(t.Oblique); Add(t.HorizontalMode); Add(t.VerticalMode); Point(t.AlignmentPoint); break;
            case Hatch hatch:
                Add(hatch.PatternName); Add(hatch.PatternScale); Add(hatch.PatternAngle); Add(hatch.Normal); Add(hatch.NumberOfLoops);
                for(var i=0;i<hatch.NumberOfLoops;i++)
                {
                    var loop=hatch.GetLoopAt(i); Add(loop.LoopType);
                    if(loop.IsPolyline)
                        foreach(BulgeVertex vertex in loop.Polyline) { Add(vertex.Vertex.X); Add(vertex.Vertex.Y); Add(vertex.Bulge); }
                    else foreach(Curve2d curve in loop.Curves)
                    {
                        Add(curve.GetType().Name);
                        if(curve is CircularArc2d arc) { Add(arc.Center.X); Add(arc.Center.Y); Add(arc.Radius); Add(arc.StartAngle); Add(arc.EndAngle); Add(arc.IsClockWise); }
                        else if(curve is LineSegment2d line) { Add(line.StartPoint.X); Add(line.StartPoint.Y); Add(line.EndPoint.X); Add(line.EndPoint.Y); }
                        else throw new InvalidOperationException("图符含未支持的填充曲线，保留原图。");
                    }
                }
                break;
            case Arc a: Point(a.Center); Add(a.Radius); Add(a.StartAngle); Add(a.EndAngle); Add(a.Normal); break;
            case Solid solid: for(short i=0;i<4;i++) Point(solid.GetPointAt(i)); break;
            case Ellipse ellipse: Point(ellipse.Center); Add(ellipse.MajorAxis); Add(ellipse.MinorAxis); Add(ellipse.StartAngle); Add(ellipse.EndAngle); break;
            case MText mt: Point(mt.Location); Add(mt.Contents); Add(mt.TextHeight); Add(mt.Width); Add(mt.Rotation); break;
            case Line l: Point(l.StartPoint); Point(l.EndPoint); break;
            case Circle c: Point(c.Center); Add(c.Radius); Add(c.Normal); break;
            case Polyline3d p: Add(p.Closed); foreach(ObjectId id in p) Point(((PolylineVertex3d)tr.GetObject(id,OpenMode.ForRead)).Position); break;
            case Polyline p: Add(p.Closed); for(var i=0;i<p.NumberOfVertices;i++) { Point(p.GetPoint3dAt(i)); Add(p.GetBulgeAt(i)); Add(p.GetStartWidthAt(i)); Add(p.GetEndWidthAt(i)); } break;
            case DBPoint p: Point(p.Position); Add(p.Normal); Add(p.Thickness); Add(p.EcsRotation); break;
            default: throw new InvalidOperationException("无法安全检查底图实体："+entity.GetType().Name);
        }
        return Hash(s.ToString());
    }
    private static bool GeometryUnchanged(Entity entity,string expected,Transaction tr)
    {
        try { return expected==GeometryStamp(entity,tr); }
        catch(Autodesk.AutoCAD.Runtime.Exception) { return false; }
        catch(InvalidOperationException) { return false; }
    }
    private static BaseMark? ReadBaseMark(Entity e,Transaction tr)
    {
        if(e.ExtensionDictionary.IsNull) return null;
        var d=(DBDictionary)tr.GetObject(e.ExtensionDictionary,OpenMode.ForRead); if(!d.Contains(BaseTag)) return null;
        using var data=((Xrecord)tr.GetObject(d.GetAt(BaseTag),OpenMode.ForRead)).Data;
        try { return JsonSerializer.Deserialize<BaseMark>((string)data.AsArray()[0].Value); } catch(System.Exception) { return null; }
    }
    private static void WriteBaseMark(Entity e,BaseMark mark,Transaction tr)
    {
        e.UpgradeOpen(); if(e.ExtensionDictionary.IsNull) e.CreateExtensionDictionary();
        var d=(DBDictionary)tr.GetObject(e.ExtensionDictionary,OpenMode.ForWrite); Xrecord record;
        if(d.Contains(BaseTag)) record=(Xrecord)tr.GetObject(d.GetAt(BaseTag),OpenMode.ForWrite);
        else { record=new Xrecord(); d.SetAt(BaseTag,record); tr.AddNewlyCreatedDBObject(record,true); }
        using var data=new ResultBuffer(new TypedValue((int)DxfCode.Text,JsonSerializer.Serialize(mark))); record.Data=data;
    }
    public static string SyncBaseMap(ProjectData project,double height,string? kind=null,IReadOnlySet<string>? keys=null)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument??throw new InvalidOperationException("请打开DWG。");
        if(!DwgProjects.IsCurrent(project)) throw new InvalidOperationException("当前DWG与项目会话不一致；未写入图形。");
        ProjectValidation.Project(project); ProjectDataIds.Ensure(project);
        string Fingerprint(object data)=>BaseFingerprint(project,data);
        var items=new List<BaseItem>();
        foreach(var f in project.Fixes) items.Add(new("Fix",f.DataId,f.Ident,"基础_定位点",Fingerprint(f),tr=>DrawBasePoints(project,PointProjection.Fixes(project,[f]),height,tr)));
        foreach(var o in project.Obstacles) items.Add(new("Obstacle",o.DataId,o.Ident,"基础_障碍物",Fingerprint(o),tr=>DrawBasePoints(project,PointProjection.Obstacles(project,[o]),height,tr)));
        foreach(var r in project.Runways) items.Add(new("Runway",r.DataId,r.Ident,"基础_跑道",Fingerprint(r),tr=>DrawRunways(project,[r],height,tr)));
        foreach(var n in project.Navaids) items.Add(new("Navaid",n.DataId,n.Ident,"基础_导航台",Fingerprint(n),tr=>DrawNavaids(project,[n],height,tr)));
        items=items.Where(item=>(kind is null || item.Kind==kind) && (keys is null || keys.Contains(item.Key))).ToList();
        var changes=new List<(BaseItem Item,ObjectId[] Old)>(); var conflicts=new List<string>();
        var unsupported=items.Where(i=>i.Kind=="Navaid" && project.Navaids.Single(n=>n.DataId==i.Key).Kind==NavaidKind.ILS).ToArray();
        foreach(var item in unsupported) { items.Remove(item); conflicts.Add(item.Ident+"（ILS原始块待确认）"); }
        using(var read=doc.Database.TransactionManager.StartTransaction())
        {
            var model=(BlockTableRecord)read.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForRead);
            var entities=model.Cast<ObjectId>().Select(id=>(Entity)read.GetObject(id,OpenMode.ForRead)).ToArray();
            var marked=entities.Select(e=>(Entity:e,Mark:ReadBaseMark(e,read))).ToArray();
            foreach(var item in items)
            {
                var found=marked.Where(x=>x.Mark is { Archived:false } m && m.Project==project.ProjectId && m.Kind==item.Kind && m.Key==item.Key).ToArray();
                var intact=found.Length>0 && found.All(x=>x.Mark!.Count==found.Length && x.Mark.Group==found[0].Mark!.Group && GeometryUnchanged(x.Entity,x.Mark.Geometry,read));
                var decision=BaseMapPolicy.Decide(found.Length==0?0:found.Select(x=>x.Mark!.Group).Distinct().Count(),intact,found.Any(x=>x.Mark!.Data!=item.Data));
                if(found.Any(x=>x.Entity.Layer.StartsWith("FPD_",StringComparison.OrdinalIgnoreCase))) decision=BaseMapChange.Conflict;
                if(found.Length==0 && marked.Any(x=>(x.Mark is null || x.Mark.Project!=project.ProjectId) && x.Entity.Layer==item.Layer && (item.Kind=="Runway" || HasName(x.Entity,item.Ident,read) || LegacyPointAt(x.Entity,item,project)))) decision=BaseMapChange.Conflict;
                if(found.Length==0 && WasDrawn(project,item.Kind,item.Key,read,doc.Database)) decision=BaseMapChange.Conflict;
                if(decision==BaseMapChange.None) continue;
                if(decision==BaseMapChange.Conflict) { conflicts.Add(item.Ident); continue; }
                changes.Add((item,found.Select(x=>x.Entity.ObjectId).ToArray()));
            }
        }
        if(changes.Count==0) return conflicts.Count>0?"图形已由人工修改，请检查："+string.Join("、",conflicts):"图形已一致";
        PrepareProjectBlocks(changes.Where(c=>c.Item.Kind is "Obstacle" or "Navaid").Select(c=>c.Item.Kind=="Obstacle"?"Obstacle":project.Navaids.Single(n=>n.DataId==c.Item.Key).Kind.ToString()));
        using var locked=doc.LockDocument(); using var tr=doc.Database.TransactionManager.StartTransaction();
        var target=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForWrite);
        foreach(var change in changes)
        {
            foreach(var id in change.Old)
            {
                var e=(Entity)tr.GetObject(id,OpenMode.ForWrite);
                e.Erase();
            }
            var before=target.Cast<ObjectId>().ToHashSet(); change.Item.Draw(tr);
            var added=target.Cast<ObjectId>().Where(id=>!before.Contains(id)).ToArray(); var group=Guid.NewGuid().ToString("N");
            RememberBase(project,change.Item.Kind,change.Item.Key,tr,doc.Database);
            foreach(var id in added) { var e=(Entity)tr.GetObject(id,OpenMode.ForWrite); WriteBaseMark(e,new(project.ProjectId,change.Item.Kind,change.Item.Key,change.Item.Ident,change.Item.Data,GeometryStamp(e,tr),group,added.Length),tr); }
        }
        tr.Commit(); doc.Editor.Regen(); var message=$"图形已更新 {changes.Count} 项";
        if(conflicts.Count>0) message+="；图形已由人工修改，请检查："+string.Join("、",conflicts); doc.Editor.WriteMessage("\n"+message); return message;
    }
    private static bool LegacyPointAt(Entity entity,BaseItem item,ProjectData project)
    {
        if(entity is not DBPoint point || item.Kind is not ("Fix" or "Obstacle")) return false;
        var p=item.Kind=="Fix"?PointProjection.Fixes(project,project.Fixes.Where(f=>f.DataId==item.Key))[0].Point:PointProjection.Obstacles(project,project.Obstacles.Where(o=>o.DataId==item.Key))[0].Point;
        return point.Position.DistanceTo(new Point3d(p.Easting,p.Northing,p.Z))<.01;
    }
    private static bool HasName(Entity e,string ident,Transaction tr)=>e is DBText text && text.TextString.Equals(ident,StringComparison.OrdinalIgnoreCase) || e is BlockReference b && b.AttributeCollection.Cast<ObjectId>().Any(id=>tr.GetObject(id,OpenMode.ForRead) is AttributeReference a && a.Tag=="NAME" && a.TextString.Equals(ident,StringComparison.OrdinalIgnoreCase));

    public static IReadOnlyList<string>? PickFixOrder(ProjectData project)
    {
        using var reference=ProjectReferenceLayers();
        var doc=AcadApp.DocumentManager.MdiActiveDocument!; var pick=new OrderedFixPick();
        while(true)
        {
            var options=new PromptEntityOptions("\n依次点击项目Fix（可重复；Enter完成，Esc整轮取消）：") { AllowNone=true };
            var result=doc.Editor.GetEntity(options);
            if(result.Status==PromptStatus.None) return pick.Complete(true);
            if(result.Status!=PromptStatus.OK) return pick.Complete(false);
            using var tr=doc.Database.TransactionManager.StartTransaction(); var e=tr.GetObject(result.ObjectId,OpenMode.ForRead) as Entity;
            var mark=e is null?null:ReadBaseMark(e,tr);
            if(mark is null || mark.Archived || mark.Project!=project.ProjectId || mark.Kind!="Fix" || !project.Fixes.Any(f=>f.DataId==mark.Key && f.Ident==mark.Ident) || !GeometryUnchanged(e!,mark.Geometry,tr)) { doc.Editor.WriteMessage("\n不是当前项目可匹配的Fix符号，请重新点击。"); continue; }
            pick.Add(mark.Ident); doc.Editor.WriteMessage("\n已加入 "+mark.Ident);
        }
    }
}
