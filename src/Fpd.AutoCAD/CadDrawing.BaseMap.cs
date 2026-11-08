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
    private sealed record BaseItem(string Kind,string Key,string Ident,string Layer,string Data,Func<Transaction,IReadOnlyList<ObjectId>> Draw,Point3d? Position=null,string? SymbolKind=null);
    private static string Hash(string value)=>Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
    private static string BaseFingerprint(ProjectData project,object data)
    {
        var fingerprint=Hash(JsonSerializer.Serialize(new { CM=AirportGeometry.Meridian(project),Data=data }));
        return data is FixData?Hash(fingerprint+"/airport-label-v2"):fingerprint;
    }
    private static string HistoryKey(ProjectData project,string kind,string key)=>"FPD_B_"+Hash(project.ProjectId+"/"+kind+"/"+key);
    private static bool WasDrawn(ProjectData project,string kind,string key,Transaction tr,Database db)=>
        ((DBDictionary)tr.GetObject(db.NamedObjectsDictionaryId,OpenMode.ForRead)).Contains(HistoryKey(project,kind,key));
    private static void RememberBase(ProjectData project,string kind,string key,Transaction tr,Database db)
    {
        var dictionary=(DBDictionary)tr.GetObject(db.NamedObjectsDictionaryId,OpenMode.ForWrite); var name=HistoryKey(project,kind,key);
        if(dictionary.Contains(name)) return;
        var record=new Xrecord(); dictionary.SetAt(name,record); tr.AddNewlyCreatedDBObject(record,true);
    }
    private static string GeometryStamp(Entity entity,Transaction tr,IDictionary<ObjectId,string>? definitionCache=null)
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
                if(definitionCache is not null && definitionCache.TryGetValue(definition.ObjectId,out var cached)) s.Append(cached);
                else
                {
                    var definitionStamp=new StringBuilder();
                    foreach(ObjectId id in definition) definitionStamp.Append(GeometryStamp((Entity)tr.GetObject(id,OpenMode.ForRead),tr,definitionCache)).Append('|');
                    if(definitionCache is not null) definitionCache[definition.ObjectId]=definitionStamp.ToString();
                    s.Append(definitionStamp);
                }
                break;
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
    private static bool GeometryUnchanged(Entity entity,string expected,Transaction tr,IDictionary<ObjectId,string>? definitionCache=null)
    {
        try { return expected==GeometryStamp(entity,tr,definitionCache); }
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
    public static string SyncBaseMap(ProjectData project,string? kind=null,IReadOnlySet<string>? keys=null)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument??throw new InvalidOperationException("请打开DWG。");
        if(!DwgProjects.IsCurrent(project)) throw new InvalidOperationException("当前DWG与项目会话不一致；未写入图形。");
        ProjectValidation.Project(project); ProjectDataIds.Ensure(project);
        var cm=AirportGeometry.Meridian(project); DrawingStyle? style=null;
        bool Selected(string itemKind,string key)=>(kind is null || kind==itemKind) && (keys is null || keys.Contains(key));
        string Fingerprint(object data)=>BaseFingerprint(project,data);
        var items=new List<BaseItem>();
        if(kind is null or "Fix")
        {
            style??=ProjectDrawingStyle(doc.Database);
            foreach(var label in LayoutFixLabels(project,style).Where(l=>keys is null || l.Neighbours.Overlaps(keys)))
            {
                var f=label.Fix; var at=label.Point;
                items.Add(new("Fix",f.DataId,f.Ident,"基础_定位点",FixLabelFingerprint(project,label,style),
                    tr=>DrawBasePoints([new(f.Ident,label.Projected,false)],style!,tr,label.Text),at));
            }
        }
        foreach(var o in project.Obstacles.Where(o=>Selected("Obstacle",o.DataId)))
        {
            var p=Cgcs2000Projection.ForwardInZone(o.Latitude,o.Longitude,cm,o.TopElevation);
            items.Add(new("Obstacle",o.DataId,o.Ident,"基础_障碍物",Fingerprint(o),tr=>DrawBasePoints([new(o.Ident,p,true)],style!,tr),new(p.Easting,p.Northing,p.Z),"Obstacle"));
        }
        foreach(var r in project.Runways.Where(r=>Selected("Runway",r.DataId))) items.Add(new("Runway",r.DataId,r.Ident,"基础_跑道",Fingerprint(r),tr=>DrawRunways(project,[r],style!,tr)));
        foreach(var n in project.Navaids.Where(n=>Selected("Navaid",n.DataId))) items.Add(new("Navaid",n.DataId,n.Ident,"基础_导航台",Fingerprint(n),tr=>DrawNavaids(project,[n],style!,tr),SymbolKind:n.Kind.ToString()));
        var changes=new List<(BaseItem Item,ObjectId[] Old)>(); var conflicts=new List<string>();
        var geometryCache=new Dictionary<ObjectId,string>();
        var unsupported=items.Where(i=>i.SymbolKind=="ILS").ToArray();
        foreach(var item in unsupported) { items.Remove(item); conflicts.Add(item.Ident+"（ILS原始块待确认）"); }
        using(var read=doc.Database.TransactionManager.StartTransaction())
        {
            var model=(BlockTableRecord)read.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database),OpenMode.ForRead);
            var identityIndex=new Dictionary<string,List<(Entity Entity,BaseMark Mark)>>(StringComparer.OrdinalIgnoreCase);
            var unmarkedLayers=new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var namedEntities=new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var pointEntities=new Dictionary<(string Layer,long X,long Y),List<Point3d>>();
            static (string Layer,long X,long Y) Cell(string layer,Point3d point)=>(layer.ToUpperInvariant(),(long)Math.Floor(point.X/.01),(long)Math.Floor(point.Y/.01));
            bool HasPoint(string layer,Point3d at)
            {
                var cell=Cell(layer,at);
                for(var x=-1;x<=1;x++) for(var y=-1;y<=1;y++)
                    if(pointEntities.TryGetValue((cell.Layer,cell.X+x,cell.Y+y),out var positions) && positions.Any(point=>point.DistanceTo(at)<.01)) return true;
                return false;
            }
            foreach(ObjectId entityId in model)
            {
                var entity=(Entity)read.GetObject(entityId,OpenMode.ForRead);
                var entry=(Entity:entity,Mark:ReadBaseMark(entity,read));
                if(entry.Mark is { Archived:false } mark && mark.Project==project.ProjectId)
                {
                    var identity=mark.Project+"\0"+mark.Kind+"\0"+mark.Key;
                    if(!identityIndex.TryGetValue(identity,out var list)) identityIndex[identity]=list=[];
                    list.Add((entry.Entity,mark));
                    continue;
                }
                if(entry.Mark?.Project==project.ProjectId) continue;
                unmarkedLayers.Add(entry.Entity.Layer);
                if(entry.Entity is DBText text) namedEntities.Add(entry.Entity.Layer+"\0"+text.TextString);
                if(entry.Entity is BlockReference block)
                    foreach(ObjectId id in block.AttributeCollection)
                        if(read.GetObject(id,OpenMode.ForRead) is AttributeReference attribute && attribute.Tag=="NAME") namedEntities.Add(entry.Entity.Layer+"\0"+attribute.TextString);
                if(entry.Entity is DBPoint point)
                {
                    var cell=Cell(entry.Entity.Layer,point.Position);
                    if(!pointEntities.TryGetValue(cell,out var positions)) pointEntities[cell]=positions=[];
                    positions.Add(point.Position);
                }
            }
            foreach(var item in items)
            {
                var identity=project.ProjectId+"\0"+item.Kind+"\0"+item.Key;
                var found=identityIndex.TryGetValue(identity,out var existing)?existing:new List<(Entity Entity,BaseMark Mark)>();
                var intact=found.Count>0 && found.All(x=>x.Mark.Count==found.Count && x.Mark.Group==found[0].Mark.Group && GeometryUnchanged(x.Entity,x.Mark.Geometry,read,geometryCache));
                var decision=BaseMapPolicy.Decide(found.Count==0?0:found.Select(x=>x.Mark.Group).Distinct().Count(),intact,found.Any(x=>x.Mark.Data!=item.Data));
                if(found.Any(x=>x.Entity.Layer.StartsWith("FPD_",StringComparison.OrdinalIgnoreCase))) decision=BaseMapChange.Conflict;
                var legacyConflict=item.Kind=="Runway" && unmarkedLayers.Contains(item.Layer);
                if(item.Kind!="Runway" && namedEntities.Contains(item.Layer+"\0"+item.Ident)) legacyConflict=true;
                if(found.Count==0 && !legacyConflict && item.Position is { } at) legacyConflict=HasPoint(item.Layer,at);
                if(found.Count==0 && legacyConflict) decision=BaseMapChange.Conflict;
                if(found.Count==0 && WasDrawn(project,item.Kind,item.Key,read,doc.Database)) decision=BaseMapChange.Conflict;
                if(decision==BaseMapChange.None) continue;
                if(decision==BaseMapChange.Conflict) { conflicts.Add(item.Ident); continue; }
                changes.Add((item,found.Select(x=>x.Entity.ObjectId).ToArray()));
            }
        }
        if(changes.Count==0) return conflicts.Count>0?"图形已由人工修改，请检查："+string.Join("、",conflicts):"图形已一致";
        style??=ProjectDrawingStyle(doc.Database);
        PrepareProjectBlocks(changes.Where(c=>c.Item.SymbolKind is not null).Select(c=>c.Item.SymbolKind!));
        using var locked=doc.LockDocument(); using var tr=doc.Database.TransactionManager.StartTransaction();
        foreach(var change in changes)
        {
            foreach(var id in change.Old)
            {
                var e=(Entity)tr.GetObject(id,OpenMode.ForWrite);
                e.Erase();
            }
            var added=change.Item.Draw(tr).ToArray(); var group=Guid.NewGuid().ToString("N");
            RememberBase(project,change.Item.Kind,change.Item.Key,tr,doc.Database);
            foreach(var id in added) { var e=(Entity)tr.GetObject(id,OpenMode.ForWrite); WriteBaseMark(e,new(project.ProjectId,change.Item.Kind,change.Item.Key,change.Item.Ident,change.Item.Data,GeometryStamp(e,tr,geometryCache),group,added.Length),tr); }
        }
        tr.Commit(); doc.Editor.Regen(); var message=$"图形已更新 {changes.Count} 项";
        if(conflicts.Count>0) message+="；图形已由人工修改，请检查："+string.Join("、",conflicts); doc.Editor.WriteMessage("\n"+message); return message;
    }
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
