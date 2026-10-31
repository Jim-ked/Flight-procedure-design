// Independent read-only observer. No WsTools references or recovered algorithms.
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
using Exception=System.Exception;
[assembly: ExtensionApplication(typeof(WsToolsObserver))]
[assembly: CommandClass(typeof(WsToolsObserver))]
public class WsToolsObserver : IExtensionApplication {
    static readonly string Root=Path.GetFullPath(Path.Combine(Path.GetDirectoryName(typeof(WsToolsObserver).Assembly.Location),".."));
    static readonly string Logs=Path.Combine(Root,"logs");
    static readonly HashSet<Document> Documents=new HashSet<Document>();
    static readonly Dictionary<Document,string> Commands=new Dictionary<Document,string>();
    static long Sequence;
    static bool Busy;
    static bool Safe(Document d) { return d!=null && Path.GetFullPath(d.Name).StartsWith(Path.Combine(Root,"dwg")+Path.DirectorySeparatorChar,StringComparison.OrdinalIgnoreCase) && Path.GetFileName(d.Name).StartsWith("R01-",StringComparison.OrdinalIgnoreCase); }
    public void Initialize() {
        Directory.CreateDirectory(Logs);
        AcApp.DocumentManager.DocumentCreated+=Created;
        foreach(Document d in AcApp.DocumentManager) Attach(d);
        Write(new {eventName="ObserverInitialized",utc=DateTime.UtcNow,clr=System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,assembly=typeof(WsToolsObserver).Assembly.Location});
        AcApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nWsToolsObserver ready (isolated R01 drawings only).\n");
    }
    public void Terminate() { AcApp.DocumentManager.DocumentCreated-=Created; }
    static void Created(object s,DocumentCollectionEventArgs e) { Attach(e.Document); }
    static void Attach(Document d) {
        if(!Safe(d)||!Documents.Add(d)) return;
        Commands[d]="";
        d.CommandWillStart+=(s,e)=>{Commands[d]=e.GlobalCommandName;Command(d,"CommandWillStart",e.GlobalCommandName);};
        d.CommandEnded+=(s,e)=>{Command(d,"CommandEnded",e.GlobalCommandName);Snapshot(d,"AfterCommand");Commands[d]="";};
        d.CommandCancelled+=(s,e)=>{Command(d,"CommandCancelled",e.GlobalCommandName);Snapshot(d,"AfterCancel");Commands[d]="";};
        d.CommandFailed+=(s,e)=>{Command(d,"CommandFailed",e.GlobalCommandName);Snapshot(d,"AfterFailure");Commands[d]="";};
        d.Database.ObjectAppended+=(s,e)=>EntityEvent(d,"ObjectAppended",e.DBObject);
        d.Database.ObjectModified+=(s,e)=>EntityEvent(d,"ObjectModified",e.DBObject);
        d.Database.ObjectErased+=(s,e)=>EntityEvent(d,e.Erased?"ObjectErased":"ObjectUnerased",e.DBObject);
        Command(d,"Attached","");
    }
    static void Command(Document d,string name,string command) { Write(new {eventName=name,utc=DateTime.UtcNow,drawing=d.Name,command=command}); }
    static void Write(object value) {
        try { File.AppendAllText(Path.Combine(Logs,"observer.jsonl"),JsonSerializer.Serialize(value)+Environment.NewLine); }
        catch(Exception e) { System.Diagnostics.Trace.WriteLine(e); }
    }
    static object P(Point3d p) { return new[]{p.X,p.Y,p.Z}; }
    static object V(Vector3d p) { return new[]{p.X,p.Y,p.Z}; }
    static object Value(object v) {
        if(v==null)return null;
        if(v is Point3d)return P((Point3d)v);
        if(v is Vector3d)return V((Vector3d)v);
        if(v is byte[])return Convert.ToBase64String((byte[])v);
        if(v is ObjectId)return v.ToString();
        if(v is string || v is bool || v is double || v is float || v is int || v is short || v is long)return v;
        return v.ToString();
    }
    static object Buffer(ResultBuffer b) {
        if(b==null)return null;
        return b.AsArray().Select(x=>new {typeCode=x.TypeCode,value=Value(x.Value)}).ToArray();
    }
    static void Try(Dictionary<string,object> record,string key,Func<object> read) {
        try { record[key]=read(); }catch(Exception e) {record[key+"Error"]=e.GetType().Name+": "+e.Message;}
    }
    static object Describe(DBObject obj,Transaction tr) {
        var r=new Dictionary<string,object>();
        r["type"]=obj.GetType().FullName;
        Try(r,"handle",()=>obj.Handle.ToString());Try(r,"objectId",()=>obj.ObjectId.ToString());
        Try(r,"rxClass",()=>obj.GetRXClass().Name);Try(r,"dxfName",()=>obj.GetRXClass().DxfName);
        var group=obj as Group;
        if(group!=null)Try(r,"groupMembers",()=>group.GetAllEntityIds().Select(x=>new{objectId=x.ToString(),handle=x.Handle.ToString()}).ToArray());
        var entity=obj as Entity;
        if(entity==null)return r;
        Try(r,"layer",()=>entity.Layer);Try(r,"color",()=>new {method=entity.Color.ColorMethod.ToString(),index=entity.ColorIndex,rgb=entity.Color.ColorValue.ToArgb()});
        Try(r,"linetype",()=>entity.Linetype);Try(r,"lineweight",()=>entity.LineWeight.ToString());
        Try(r,"extents",()=>new {min=P(entity.GeometricExtents.MinPoint),max=P(entity.GeometricExtents.MaxPoint)});
        Try(r,"xdata",()=>Buffer(entity.XData));
        Try(r,"xdataByRegApp",()=>{
            var apps=new List<object>();string app="";var values=new List<object>();
            using(var b=entity.XData) {
                if(b==null)return apps;
                foreach(var x in b.AsArray()) {
                    if(x.TypeCode==1001) { if(app!="")apps.Add(new{regApp=app,typedValues=values.ToArray()});app=Convert.ToString(x.Value);values.Clear(); }
                    else values.Add(new{typeCode=x.TypeCode,value=Value(x.Value)});
                }
                if(app!="")apps.Add(new{regApp=app,typedValues=values.ToArray()});
            }return apps;
        });
        Try(r,"extensionDictionary",()=>{
            if(entity.ExtensionDictionary.IsNull)return null;
            if(tr==null)return "deferred to command-end snapshot";
            var dict=(DBDictionary)tr.GetObject(entity.ExtensionDictionary,OpenMode.ForRead);var entries=new List<object>();
            foreach(DBDictionaryEntry x in dict) {
                var item=tr.GetObject(x.Value,OpenMode.ForRead);var xr=item as Xrecord;
                entries.Add(new{key=x.Key,type=item.GetType().FullName,values=xr==null?null:Buffer(xr.Data)});
            }return entries;
        });
        var line=entity as Line;if(line!=null)Try(r,"line",()=>new{start=P(line.StartPoint),end=P(line.EndPoint),length=line.Length});
        var point=entity as DBPoint;if(point!=null)Try(r,"point",()=>P(point.Position));
        var pl=entity as Polyline;if(pl!=null)Try(r,"polyline",()=>{
            var vertices=new List<object>();for(int i=0;i<pl.NumberOfVertices;i++){var p=pl.GetPoint2dAt(i);vertices.Add(new{x=p.X,y=p.Y,bulge=pl.GetBulgeAt(i),startWidth=pl.GetStartWidthAt(i),endWidth=pl.GetEndWidthAt(i)});}
            return new{closed=pl.Closed,elevation=pl.Elevation,vertexCount=pl.NumberOfVertices,vertices=vertices};
        });
        var pl3=entity as Polyline3d;if(pl3!=null)Try(r,"polyline3d",()=>{if(tr==null)return (object)"deferred";var vertices=new List<object>();foreach(ObjectId id in pl3)vertices.Add(P(((PolylineVertex3d)tr.GetObject(id,OpenMode.ForRead)).Position));return new{closed=pl3.Closed,vertices=vertices};});
        var circle=entity as Circle;if(circle!=null)Try(r,"circle",()=>new{center=P(circle.Center),radius=circle.Radius,normal=V(circle.Normal)});
        var arc=entity as Arc;if(arc!=null)Try(r,"arc",()=>new{center=P(arc.Center),radius=arc.Radius,normal=V(arc.Normal),startAngle=arc.StartAngle,endAngle=arc.EndAngle,start=P(arc.StartPoint),end=P(arc.EndPoint)});
        var text=entity as DBText;if(text!=null)Try(r,"text",()=>new{text=text.TextString,position=P(text.Position),height=text.Height,rotation=text.Rotation});
        var mt=entity as MText;if(mt!=null)Try(r,"mtext",()=>new{text=mt.Contents,position=P(mt.Location),height=mt.TextHeight,rotation=mt.Rotation});
        var block=entity as BlockReference;if(block!=null)Try(r,"block",()=>{
            var attrs=new List<object>();if(tr!=null)foreach(ObjectId id in block.AttributeCollection){var a=(AttributeReference)tr.GetObject(id,OpenMode.ForRead);attrs.Add(new{tag=a.Tag,text=a.TextString,position=P(a.Position)});}
            return new{name=block.Name,definition=block.BlockTableRecord.ToString(),position=P(block.Position),scale=new[]{block.ScaleFactors.X,block.ScaleFactors.Y,block.ScaleFactors.Z},rotation=block.Rotation,attributes=attrs};
        });
        return r;
    }
    static void EntityEvent(Document d,string name,DBObject obj) {
        if(Busy||!Safe(d))return;Busy=true;
        try {if(obj is Entity || obj is Group)Write(new{eventName=name,utc=DateTime.UtcNow,sequence=++Sequence,drawing=d.Name,command=Commands[d],entity=Describe(obj,d.Database.TransactionManager.TopTransaction)});}
        catch(Exception e){Write(new{eventName="ObserverError",detail=e.ToString()});}finally{Busy=false;}
    }
    static void Snapshot(Document d,string why) {
        if(Busy||!Safe(d))return;Busy=true;
        try {using(var tr=d.Database.TransactionManager.StartOpenCloseTransaction()) {
            var bt=(BlockTable)tr.GetObject(d.Database.BlockTableId,OpenMode.ForRead);var model=(BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace],OpenMode.ForRead);
            var entities=new List<object>();foreach(ObjectId id in model)entities.Add(Describe(tr.GetObject(id,OpenMode.ForRead),tr));
            var groups=new List<object>();var gd=(DBDictionary)tr.GetObject(d.Database.GroupDictionaryId,OpenMode.ForRead);
            foreach(DBDictionaryEntry entry in gd){var g=(Group)tr.GetObject(entry.Value,OpenMode.ForRead);groups.Add(new{name=entry.Key,handle=g.Handle.ToString(),members=g.GetAllEntityIds().Select(x=>x.Handle.ToString()).ToArray()});}
            Write(new{eventName="Snapshot",utc=DateTime.UtcNow,drawing=d.Name,reason=why,command=Commands[d],entities=entities,groups=groups});
        }}catch(Exception e){Write(new{eventName="SnapshotError",detail=e.ToString()});}finally{Busy=false;}
    }
    [CommandMethod("WSOBS_SNAPSHOT")]
    public void Dump() {var d=AcApp.DocumentManager.MdiActiveDocument;Attach(d);Snapshot(d,"Explicit");}
}
