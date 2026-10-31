// Bounded host diagnostics: never invoke target methods or alter dependency resolution.
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Collections.Generic;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
using Exception=System.Exception;
[assembly: CommandClass(typeof(WsToolsHostDiagnostics))]
public class WsToolsHostDiagnostics {
    static string Root {get{return Path.GetFullPath(Path.Combine(Path.GetDirectoryName(typeof(WsToolsHostDiagnostics).Assembly.Location),".."));}}
    static void Save(string file,object value){File.WriteAllText(Path.Combine(Root,"logs",file),JsonSerializer.Serialize(value,new JsonSerializerOptions{WriteIndented=true}));}
    [CommandMethod("WSOBS_HOST")]
    public void Host() {
        var assemblies=AppDomain.CurrentDomain.GetAssemblies();var result=new List<object>();
        foreach(var asm in assemblies.Where(a=>a.GetName().Name=="WindSpiralBasic")) {
            try {var types=asm.GetTypes();result.Add(new{assembly=asm.FullName,location=asm.Location,typeCount=types.Length,error=(string)null});}
            catch(ReflectionTypeLoadException e){result.Add(new{assembly=asm.FullName,location=asm.Location,error=e.ToString(),loaderExceptions=e.LoaderExceptions.Select(x=>x==null?null:x.ToString()).ToArray()});}
            catch(Exception e){result.Add(new{assembly=asm.FullName,location=asm.Location,error=e.ToString()});}
        }
        Save("host-target-loader.json",new{utc=DateTime.UtcNow,clr=System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,target=result,assemblies=assemblies.Select(a=>new{name=a.FullName,location=a.IsDynamic?"dynamic":a.Location}).ToArray()});
        AcApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nHost diagnostics saved; no target method invoked.\n");
    }
    [CommandMethod("WSOBS_SYMBOLS")]
    public void Symbols() {
        // Read only the copied library; do not open a drawing document or modify its DB.
        var path=Path.Combine(Root,"WindSpiral2026-runtime","WsSymbol2.1.dwg");var rows=new List<object>();
        using(var db=new Database(false,true)) {
            db.ReadDwgFile(path,FileShare.Read,true,null);
            using(var tr=db.TransactionManager.StartTransaction()) {
                var bt=(BlockTable)tr.GetObject(db.BlockTableId,OpenMode.ForRead);
                foreach(ObjectId id in bt) {
                    var block=(BlockTableRecord)tr.GetObject(id,OpenMode.ForRead);
                    if(!block.Name.Equals("obst",StringComparison.OrdinalIgnoreCase))continue;
                    var attrs=new List<object>();var types=new List<string>();
                    foreach(ObjectId itemId in block) {
                        var item=tr.GetObject(itemId,OpenMode.ForRead);types.Add(item.GetType().FullName);
                        var a=item as AttributeDefinition;if(a==null)continue;
                        attrs.Add(new{tag=a.Tag,defaultValue=a.TextString,prompt=a.Prompt,constant=a.Constant,position=new[]{a.Position.X,a.Position.Y,a.Position.Z},height=a.Height,rotation=a.Rotation});
                    }
                    rows.Add(new{name=block.Name,handle=block.Handle.ToString(),attributes=attrs,entityTypes=types});
                }
            }
        }
        Save("symbol-obst-definition.json",new{utc=DateTime.UtcNow,path=path,blocks=rows});
        AcApp.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nCopied symbol obst definition read only; no block inserted.\n");
    }
}
