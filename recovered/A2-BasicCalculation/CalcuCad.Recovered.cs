// Native bindings recovered from the exact helpers cited below.
// TODO-RE: compile against matching Autodesk references; no host execution performed.
#if AUTOCAD
using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;

public static class CalcuCadRecovered {
    // Original 0x06000652 RVA0xB8748 / processed651: --/--.cs:74906.
    public static ResultBuffer ToBuffer(CalcuLineRecovered data) {
        var buffer=new ResultBuffer();
        buffer.Add(new TypedValue(1001,"WsCalcuLine"));
        buffer.Add(new TypedValue(1000,data.Kind.ToString()));
        buffer.Add(new TypedValue(1000,data.ToJson(AcApp.ShowAlertDialog)));
        return buffer;
    }
    // Original 0x06000653 RVA0xB87B0 / processed652.
    // Type header overrides the deserialized JSON type; no app-name check added.
    public static CalcuLineRecovered FromBuffer(ResultBuffer buffer) {
        if(buffer==null) return null;
        try {
            TypedValue[] values=buffer.AsArray(); int kind;
            if(values.Length>=3 && int.TryParse(values[1].Value==null?null:values[1].Value.ToString(),out kind)) {
                var data=CalcuLineRecovered.FromJson(values[2].Value==null?"":values[2].Value.ToString(),AcApp.ShowAlertDialog);
                data.Kind=kind;return data;
            }
        } catch(Exception ex) { AcApp.ShowAlertDialog("解析XData失败: "+ex.Message); }
        return null;
    }
    // Shared registration helper --/--.cs:74437 _008A_0090_008C;
    // evidence.md contains original token/RVA. Both catches intentionally swallow.
    public static void Register(Transaction tr,Database db,string name) {
        try {
            var table=(RegAppTable)tr.GetObject(db.RegAppTableId,OpenMode.ForRead);
            if(table.Has(name)) return;
            try {
                table.UpgradeOpen();
                if(!table.Has(name)) {
                    var record=new RegAppTableRecord { Name=name };
                    table.Add(record);tr.AddNewlyCreatedDBObject(record,true);
                }
            } catch(Exception) { }
        } catch(Exception) { }
    }
    // Original 0x06000655 RVA0xB8B08 / processed654, --/--.cs:75050.
    public static bool Save(CalcuLineRecovered data,ObjectId id,Database db) {
        if(id.IsNull || db==null) return false;
        try {
            using(var docLock=AcApp.DocumentManager.MdiActiveDocument.LockDocument())
            using(var tr=db.TransactionManager.StartTransaction()) {
                var entity=tr.GetObject(id,OpenMode.ForWrite) as Entity;
                if(entity==null) { tr.Abort();return false; }
                Register(tr,db,"WsCalcuLine");entity.XData=ToBuffer(data);tr.Commit();return true;
            }
        } catch(Exception ex) { AcApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nSaveToEntityById 失败: "+ex.Message);return false; }
    }
    // Empty-metadata branch of shared append helper -/-.cs:1578, processed89.
    // This slice is all this line writer calls. Nonempty WsObject branch not ported here.
    public static ObjectId AppendWithoutMetadata(Entity entity,Database db) {
        ObjectId result=default(ObjectId);
        try {
            using(var docLock=AcApp.DocumentManager.MdiActiveDocument.LockDocument())
            using(var tr=db.TransactionManager.StartTransaction()) {
                var table=(BlockTable)tr.GetObject(db.BlockTableId,OpenMode.ForRead);
                var model=(BlockTableRecord)tr.GetObject(table[BlockTableRecord.ModelSpace],OpenMode.ForWrite);
                result=model.AppendEntity(entity);tr.AddNewlyCreatedDBObject(entity,true);tr.Commit();AcApp.UpdateScreen();
            }
        } catch(Exception ex) { AcApp.ShowAlertDialog("绘制失败。\n"+ex.ToString()); }
        return result;
    }
    // Original 0x060006A4 RVA0xB9C38 / processed6A3, --/--.cs:76055.
    // Preserve two separate transactions: XData failure does NOT roll back the Line.
    public static ObjectId CreateLine(CalcuLineRecovered data,Database db,Point3d start,Point3d end) {
        try {
            data.CenterX=(start.X+end.X)/2.0;data.CenterY=(start.Y+end.Y)/2.0;data.CenterZ=(start.Z+end.Z)/2.0;
            data.Length=start.DistanceTo(end);data.Direction=Math.Atan2(end.Y-start.Y,end.X-start.X);
            ObjectId id=AppendWithoutMetadata(new Line(start,end),db);
            if(!id.IsNull && !Save(data,id,db)) AcApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\n警告：线条创建成功，但XData写入失败");
            return id;
        } catch(Exception ex) { AcApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\n创建线条失败: "+ex.Message);return ObjectId.Null; }
    }
}
#endif
