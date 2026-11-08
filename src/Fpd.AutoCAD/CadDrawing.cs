using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Fpd.Core;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace Fpd.AutoCAD;

internal sealed record CadLayer(string Name, bool Visible, int EntityCount);

internal static partial class CadDrawing
{
    public static readonly string[] LayerNames = ["FPD_FIX", "FPD_OBSTACLE", "FPD_RUNWAY", "FPD_NAVAID"];
    private static void DrawBasePoints(ProjectData project,IReadOnlyList<PlotPoint> points,double height,Transaction tr)
    {
        var db=AcadApp.DocumentManager.MdiActiveDocument!.Database;
        var model=(BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db),OpenMode.ForWrite);
        foreach(var row in points)
        {
            var layer=row.IsObstacle?"FPD_OBSTACLE":"FPD_FIX"; EnsureLayer(tr,db,layer,row.IsObstacle?(short)1:(short)3);
            var at=new Point3d(row.Point.Easting,row.Point.Northing,row.Point.Z);
            Entity entity=row.IsObstacle?ProjectSymbol(tr,db,"Obstacle",at,height):new DBPoint(at);
            entity.Layer=layer; model.AppendEntity(entity); tr.AddNewlyCreatedDBObject(entity,true);
            var text=new DBText { Layer=layer,Position=at+new Vector3d(height*1.4,height*.4,0),Height=height,TextString=row.Ident };
            model.AppendEntity(text); tr.AddNewlyCreatedDBObject(text,true);
        }
    }

    public static IReadOnlyList<CadLayer> ReadLayers()
    {
        var doc = AcadApp.DocumentManager.MdiActiveDocument;
        if (doc is null) return [];
        // A write lock starts an undo record even for this read-only palette query.
        // Keep browsing/refreshing layers from consuming the next native U operation.
        using var locked = doc.LockDocument(Autodesk.AutoCAD.ApplicationServices.DocumentLockMode.Read, null, null, false);
        using var tr = doc.Database.TransactionManager.StartTransaction();
        var counts = new Dictionary<string, int>();
        var model = (BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database), OpenMode.ForRead);
        foreach (ObjectId id in model) if (tr.GetObject(id, OpenMode.ForRead) is Entity entity && entity.Layer.StartsWith("FPD_", StringComparison.OrdinalIgnoreCase)) counts[entity.Layer] = counts.GetValueOrDefault(entity.Layer) + 1;
        var table = (LayerTable)tr.GetObject(doc.Database.LayerTableId, OpenMode.ForRead);
        return table.Cast<ObjectId>().Select(id => (LayerTableRecord)tr.GetObject(id, OpenMode.ForRead)).Where(l => l.Name.StartsWith("FPD_", StringComparison.OrdinalIgnoreCase)).Select(l => new CadLayer(l.Name, !l.IsOff && !l.IsFrozen, counts.GetValueOrDefault(l.Name))).ToArray();
    }

    public static void SetLayer(string name, bool visible)
    {
        if (!name.StartsWith("FPD_", StringComparison.OrdinalIgnoreCase)) throw new ArgumentException("仅操作 FPD 设计图层。");
        var doc = AcadApp.DocumentManager.MdiActiveDocument ?? throw new InvalidOperationException("请先打开 DWG。");
        using var locked = doc.LockDocument(); using var tr = doc.Database.TransactionManager.StartTransaction();
        var table = (LayerTable)tr.GetObject(doc.Database.LayerTableId, OpenMode.ForRead);
        if (!table.Has(name)) throw new InvalidOperationException("当前图面不存在该图层。");
        var layer = (LayerTableRecord)tr.GetObject(table[name], OpenMode.ForWrite);
        layer.IsOff = !visible; if (visible) layer.IsFrozen = false;
        tr.Commit(); doc.Editor.Regen();
    }

    public static void ZoomDesign()
    {
        var doc = AcadApp.DocumentManager.MdiActiveDocument ?? throw new InvalidOperationException("请先打开 DWG。");
        using var tr = doc.Database.TransactionManager.StartTransaction();
        var model = (BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database), OpenMode.ForRead);
        Extents3d? extent = null;
        foreach (ObjectId id in model)
            if (tr.GetObject(id, OpenMode.ForRead) is Entity e && e.Layer.StartsWith("FPD_", StringComparison.OrdinalIgnoreCase))
            {
                try { var box = e.GeometricExtents; if (extent is null) extent = box; else { var merged = extent.Value; merged.AddExtents(box); extent = merged; } }
                catch (Autodesk.AutoCAD.Runtime.Exception) { }
            }
        if (extent is null) throw new InvalidOperationException("当前 DWG 尚无 FPD 图形。");
        tr.Commit();
        // The editor's current view is in DCS; transform WCS extents before framing it.
        using var view = doc.Editor.GetCurrentView();
        var transform = Matrix3d.PlaneToWorld(view.ViewDirection); transform = Matrix3d.Displacement(view.Target - Point3d.Origin) * transform;
        transform = Matrix3d.Rotation(-view.ViewTwist, view.ViewDirection, view.Target) * transform;
        var bounds = extent.Value; bounds.TransformBy(transform.Inverse());
        var width = Math.Max(bounds.MaxPoint.X - bounds.MinPoint.X, 100); var height = Math.Max(bounds.MaxPoint.Y - bounds.MinPoint.Y, 100);
        var ratio = view.Width / view.Height;
        view.CenterPoint = new Point2d((bounds.MinPoint.X + bounds.MaxPoint.X) / 2, (bounds.MinPoint.Y + bounds.MaxPoint.Y) / 2);
        view.Height = Math.Max(height, width / ratio) * 1.25; view.Width = view.Height * ratio;
        doc.Editor.SetCurrentView(view);
        doc.Editor.UpdateScreen();
        doc.Editor.WriteMessage("\nFPD 已定位至当前 DWG 的设计图形。");
    }
}
