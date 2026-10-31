#if ACAD2026_TEST
using System;
using Autodesk.AutoCAD.DatabaseServices;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
public static class WsObjectCadRecovered {
    // Original MethodDef: 0x0600008A; Original RVA: 0x5878.
    // Evidence: -/-.cs:1578-1655, processed89 IL_003B-00CA and append/commit.
    // A7 outer-circle call uses a nonempty description; Round1 only ported empty branch.
    public static ObjectId Append(Entity entity,Database db,string description=""){
        ObjectId result=default(ObjectId);
        try{
            using(var l=AcApp.DocumentManager.MdiActiveDocument.LockDocument())
            using(var tr=db.TransactionManager.StartTransaction()){
                var buffer=new ResultBuffer();
                if(description.Trim().Length>0){
                    var apps=(RegAppTable)tr.GetObject(db.RegAppTableId,OpenMode.ForWrite);
                    if(!apps.Has("WsObject")){var app=new RegAppTableRecord{Name="WsObject"};apps.Add(app);tr.AddNewlyCreatedDBObject(app,true);}
                    buffer.Add(new TypedValue(1001,"WsObject"));buffer.Add(new TypedValue(1000,description));entity.XData=buffer;
                }
                var table=(BlockTable)tr.GetObject(db.BlockTableId,OpenMode.ForRead);
                result=((BlockTableRecord)tr.GetObject(table[BlockTableRecord.ModelSpace],OpenMode.ForWrite)).AppendEntity(entity);
                tr.AddNewlyCreatedDBObject(entity,true);tr.Commit();AcApp.UpdateScreen();
            }
        }catch(Exception ex){AcApp.ShowAlertDialog("绘制失败。\n"+ex.ToString());}
        return result;
    }
}
#endif
