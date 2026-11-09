using System.IO;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System.Text.Json;
namespace Fpd.AutoCAD;
internal static class SymbolLibrary
{
    private static readonly object Gate=new();
    private static Database? _database;
    internal static string DirectoryPath=>Path.Combine(Path.GetDirectoryName(typeof(SymbolLibrary).Assembly.Location)!,"Symbols");
    internal static string LibraryPath=>Path.Combine(DirectoryPath,"WsSymbol2.1.dwg");
    internal static Database Open()
    {
        lock(Gate)
        {
            if(_database is not null) return _database;
            var database=new Database(false,true);
            try
            {
                database.ReadDwgFile(LibraryPath,FileOpenMode.OpenForReadAndAllShare,true,null);
                database.CloseInput(true);
                _database=database;
                return database;
            }
            catch { database.Dispose(); throw; }
        }
    }
    internal static void Preload()=>Open();
    internal static void Dispose()
    {
        lock(Gate) { _database?.Dispose(); _database=null; }
    }
    public static void Audit()
    {
        var output=Path.Combine(Path.GetDirectoryName(typeof(SymbolLibrary).Assembly.Location)!,"symbol-audit"); Directory.CreateDirectory(output);
        var db=Open();
        using var tr=db.TransactionManager.StartTransaction(); var table=(BlockTable)tr.GetObject(db.BlockTableId,OpenMode.ForRead);
        var rows=new List<object>();
        foreach(ObjectId id in table)
        {
            var b=(BlockTableRecord)tr.GetObject(id,OpenMode.ForRead); var entities=new List<object>();
            foreach(ObjectId eid in b)
            {
                if(tr.GetObject(eid,OpenMode.ForRead) is not Entity e) continue;
                double[]? bounds=null; try { var x=e.GeometricExtents; bounds=[x.MinPoint.X,x.MinPoint.Y,x.MaxPoint.X,x.MaxPoint.Y]; } catch(Autodesk.AutoCAD.Runtime.Exception) { }
                entities.Add(new { Type=e.GetType().Name, e.Layer, Color=e.ColorIndex, Bounds=bounds, Text=e is DBText text?text.TextString:e is MText mt?mt.Contents:null, Tag=e is AttributeDefinition a?a.Tag:null, Constant=e is AttributeDefinition at?at.Constant:(bool?)null, Block=e is BlockReference br?((BlockTableRecord)tr.GetObject(br.BlockTableRecord,OpenMode.ForRead)).Name:null });
            }
            rows.Add(new { b.Name,b.IsAnonymous,b.IsDynamicBlock,b.IsLayout,Origin=new[]{b.Origin.X,b.Origin.Y,b.Origin.Z},Units=b.Units.ToString(),Entities=entities });
        }
        Atlas(db,tr,table,Path.Combine(output,"symbol-atlas.dwg"));
        File.WriteAllText(Path.Combine(output,"block-table.json"),JsonSerializer.Serialize(new { Host="AutoCAD 2026",Utc=DateTime.UtcNow,LibrarySha256=Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(File.ReadAllBytes(LibraryPath))),Insunits=db.Insunits.ToString(),Blocks=rows },new JsonSerializerOptions{WriteIndented=true}));
        Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument!.Editor.WriteMessage("\n块表审计及对照DWG："+output);
    }
    private static void Atlas(Database source,Transaction sourceTr,BlockTable table,string path)
    {
        using var atlas=new Database(true,true);
        var blocks=table.Cast<ObjectId>().Select(id=>(BlockTableRecord)sourceTr.GetObject(id,OpenMode.ForRead)).Where(b=>!b.IsLayout && !b.IsAnonymous && !b.IsFromExternalReference && b.Cast<ObjectId>().Any()).ToArray();
        var map=new IdMapping(); source.WblockCloneObjects(new ObjectIdCollection(blocks.Select(b=>b.ObjectId).ToArray()),atlas.BlockTableId,map,DuplicateRecordCloning.MangleName,false);
        using(var tr=atlas.TransactionManager.StartTransaction())
        {
            var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(atlas),OpenMode.ForWrite);
            for(var i=0;i<blocks.Length;i++)
            {
                var reference=new BlockReference(Point3d.Origin,map[blocks[i].ObjectId].Value); model.AppendEntity(reference); tr.AddNewlyCreatedDBObject(reference,true);
                Extents3d box; try { box=reference.GeometricExtents; } catch(Autodesk.AutoCAD.Runtime.Exception) { box=new(new(-1,-1,0),new(1,1,0)); }
                var scale=80/Math.Max(Math.Max(box.MaxPoint.X-box.MinPoint.X,box.MaxPoint.Y-box.MinPoint.Y),.01);
                reference.ScaleFactors=new Scale3d(scale); reference.Position=new Point3d(i%5*120-box.MinPoint.X*scale,-i/5*150-box.MinPoint.Y*scale,0);
                var text=new DBText { Position=new(i%5*120,-i/5*150-20,0),Height=6,TextString=blocks[i].Name,ColorIndex=7 }; model.AppendEntity(text); tr.AddNewlyCreatedDBObject(text,true);
            }
            tr.Commit();
        }
        atlas.SaveAs(path,DwgVersion.Current);
    }
}
