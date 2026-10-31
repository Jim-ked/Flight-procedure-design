// TODO-RE: native AutoCAD compilation and host verification pending.
#if AUTOCAD
using System;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
public static class EntityFrameCadRecovered {
    // Original06000718/RVABED60, processed717; --/--.cs:78914.
    public static EntityFrameRecovered Load(Entity entity) {
        try {
            if(entity==null) return null;
            using(var docLock=AcApp.DocumentManager.MdiActiveDocument.LockDocument())
            using(var tr=entity.Database.TransactionManager.StartTransaction()) {
                var opened=tr.GetObject(entity.ObjectId,OpenMode.ForRead) as Entity;
                if(opened!=null) {
                    var buffer=opened.GetXDataForApplication("WsEntityFrame");
                    if(buffer!=null) { var result=FromBuffer(buffer,AcApp.ShowAlertDialog);tr.Commit();return result; }
                }
                tr.Abort();return null;
            }
        } catch(Exception ex) { AcApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\n从实体加载数据失败: "+ex.Message);return null; }
    }
    // Original0x06000713 RVA0xBE3C4 / processed712; --/--.cs:78664.
    public static ResultBuffer ToBuffer(EntityFrameRecovered frame,Action<string> alert) {
        string json=frame.ToJson(alert);
        var buffer=new ResultBuffer();
        buffer.Add(new TypedValue(1001,"WsEntityFrame"));
        buffer.Add(new TypedValue(1000,frame.EntityType.ToString()));
        buffer.Add(new TypedValue(1000,frame.EntityName??""));
        foreach(string chunk in frame.JsonChunks(json)) buffer.Add(new TypedValue(1000,chunk));
        return buffer;
    }
    // Original0x06000714 RVA0xBE550 / processed713; --/--.cs:78717.
    // JSON type always overrides header; nonempty JSON name overrides header name.
    public static EntityFrameRecovered FromBuffer(ResultBuffer buffer,Action<string> alert) {
        if(buffer==null) return null;
        var result=new EntityFrameRecovered();
        try {
            TypedValue[] values=buffer.AsArray();
            if(values.Length>=3) {
                int kind;
                if(int.TryParse(values[1].Value==null?null:values[1].Value.ToString(),out kind)) result.EntityType=kind;
                result.EntityName=values[2].Value==null?null:values[2].Value.ToString();
                if(values.Length>=4) {
                    var builder=new StringBuilder();
                    for(int i=3;i<values.Length;i++) if(values[i].Value!=null) builder.Append(values[i].Value.ToString());
                    var parsed=EntityFrameRecovered.FromJson(builder.ToString(),alert);
                    if(parsed!=null) {
                        if(!string.IsNullOrEmpty(parsed.EntityName)) result.EntityName=parsed.EntityName;
                        result.EntityType=parsed.EntityType;
                        foreach(var pair in parsed.Properties) result.Properties[pair.Key]=pair.Value;
                    }
                }
            }
        } catch(Exception ex) { alert("解析XData失败: "+ex.Message); }
        return result;
    }
}
#endif
