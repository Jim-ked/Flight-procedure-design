// Native shared methods, directly transcribed from cited processed bodies/IL.
// AUTOCAD path has not been compiled against Autodesk 23.1 or executed.
#if AUTOCAD
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
public static class ObstacleCadRecovered {
    // -/-.cs:5120 processed10D. Caller must supply transaction; db is UNUSED.
    public static List<T> ScreenData<T>(Database db,OpenMode mode,bool erased) where T:Entity {
        var list=new List<T>();
        var filter=new SelectionFilter(new[]{new TypedValue(0,RXObject.GetClass(typeof(T)).DxfName),new TypedValue(410,"Model")});
        var result=AcApp.DocumentManager.MdiActiveDocument.Editor.SelectAll(filter);
        if(result.Status==PromptStatus.OK)
            foreach(ObjectId id in result.Value.GetObjectIds()) list.Add((T)id.GetObject(mode,erased));
        return list;
    }
    // Renamed projection of original business point fields; not a new evaluator.
    public sealed class ImportedPoint { public double X,Y,Z;public string ID,Name; }
    // Original06000130/RVA10D00 processed12F; --/--.cs:239.
    public static ImportedPoint Parse(DBPoint point,string ordinal) {
        var result=new ImportedPoint { X=point.Position.X,Y=point.Position.Y,Z=point.Position.Z,ID=ordinal,Name="" };
        try {
            var frame=EntityFrameCadRecovered.Load(point);
            if(frame!=null && !string.IsNullOrWhiteSpace(frame.EntityName)) result.Name=frame.EntityName;
        } catch { }
        if(string.IsNullOrWhiteSpace(result.Name)) result.Name=ObstacleRecovered.ParsedName(null,point.ObjectId.ToString());
        return result;
    }
    // Original0600009D/RVA739C processed9C; -/-.cs:2596.
    public static ObjectId Insert(string blockName,Point3d position,double scale=1.0) {
        var doc=AcApp.DocumentManager.MdiActiveDocument;var db=doc.Database;
        ObjectId result=default(ObjectId);bool found=false;
        using(var docLock=doc.LockDocument())
        using(var tr=db.TransactionManager.StartTransaction()) found=((BlockTable)tr.GetObject(db.BlockTableId,OpenMode.ForRead)).Has(blockName);
        if(!found) Import(blockName);
        using(var docLock=doc.LockDocument())
        using(var tr=db.TransactionManager.StartTransaction()) {
            var table=(BlockTable)tr.GetObject(db.BlockTableId,OpenMode.ForRead);
            if(!table.Has(blockName)) { AcApp.ShowAlertDialog("未找到指定图块，请通过辅助功能界面导入图块。");return result; }
            var definition=(BlockTableRecord)tr.GetObject(table[blockName],OpenMode.ForWrite);
            var block=new BlockReference(position,table[blockName]);
            block.TransformBy(Matrix3d.Scaling(scale,position));
            result=((BlockTableRecord)tr.GetObject(table[BlockTableRecord.ModelSpace],OpenMode.ForWrite)).AppendEntity(block);
            tr.AddNewlyCreatedDBObject(block,true);
            foreach(ObjectId id in definition) {
                var attribute=tr.GetObject(id,OpenMode.ForRead) as AttributeDefinition;
                if(attribute==null) continue;
                var reference=new AttributeReference();reference.SetAttributeFromBlock(attribute,block.BlockTransform);reference.TextString=" ";
                block.AttributeCollection.AppendAttribute(reference);tr.AddNewlyCreatedDBObject(reference,true);
            }
            block.RecordGraphicsModified(true);tr.Commit();AcApp.UpdateScreen();return result;
        }
    }
    // Original0600009E/RVA7794 processed9D; -/-.cs:2730.
    // ExecutingAssembly means the OLD plugin directory in the original. A recovered
    // build needs its own unchanged library copy there; no source file is moved here.
    public static void Import(string blockName) {
        var doc=AcApp.DocumentManager.MdiActiveDocument;
        string[] files=Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"WsSymbol*.dwg");
        if(files.Length==0 || !File.Exists(files[0])) return;
        try {
            var source=new Database(false,true);var manager=source.TransactionManager;
            source.ReadDwgFile(files[0],FileShare.Read,true,null);
            var ids=new ObjectIdCollection();
            using(var docLock=doc.LockDocument()) {
                using(var tr=manager.StartTransaction()) {
                    var table=(BlockTable)manager.GetObject(source.BlockTableId,OpenMode.ForRead,false);
                    if(!table.Has(blockName)) AcApp.ShowAlertDialog("图块 "+blockName+" 未找到，请检查图库是否正确。");
                    else ids.Add(table[blockName]);
                    table.Dispose();
                }
                source.WblockCloneObjects(ids,HostApplicationServices.WorkingDatabase.BlockTableId,new IdMapping(),(DuplicateRecordCloning)2,false);
                source.Dispose();
            }
        } catch(System.Exception ex) { AcApp.ShowAlertDialog("复制错误："+ex.Message); }
    }
    // Original0600009F/RVA7A64 processed9E; -/-.cs:2803. No break after match.
    public static void SetAttribute(ObjectId id,string tag,string value) {
        if(id.IsNull || !id.IsValid || tag==null || value==null) return;
        var doc=AcApp.DocumentManager.MdiActiveDocument;
        using(var docLock=doc.LockDocument())
        using(var tr=doc.Database.TransactionManager.StartTransaction()) {
            var block=tr.GetObject(id,OpenMode.ForRead) as BlockReference;
            foreach(ObjectId attributeId in block.AttributeCollection) {
                var attribute=tr.GetObject(attributeId,OpenMode.ForWrite) as AttributeReference;
                if(attribute!=null && attribute.Tag.ToUpper()==tag.ToUpper()) attribute.TextString=value;
            }
            tr.Commit();AcApp.UpdateScreen();
        }
    }
}
#endif
