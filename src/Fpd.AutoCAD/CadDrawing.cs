using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Fpd.Core;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace Fpd.AutoCAD;

internal sealed record DrawRequest(IReadOnlyList<PlotPoint> Points, double TextHeight, bool ShowTop);
internal sealed record CadLayer(string Name, bool Visible, int EntityCount);

internal static class CadDrawing
{
    public static readonly string[] LayerNames = ["FPD_FIX", "FPD_OBSTACLE"];
    public static void Draw(DrawRequest request, bool legacyPoint = false)
    {
        var doc = AcadApp.DocumentManager.MdiActiveDocument ?? throw new InvalidOperationException("请先打开 DWG。");
        if (request.Points.Count == 0 || !double.IsFinite(request.TextHeight) || request.TextHeight <= 0) throw new ArgumentException("请选择点并设置正文字高度。");
        using var locked = doc.LockDocument();
        using var tr = doc.Database.TransactionManager.StartTransaction();
        var layers = (LayerTable)tr.GetObject(doc.Database.LayerTableId, OpenMode.ForRead);
        foreach (var name in request.Points.Select(p => p.IsObstacle ? "FPD_OBSTACLE" : "FPD_FIX").Distinct())
        {
            if (!layers.Has(name))
            {
                layers.UpgradeOpen(); var layer = new LayerTableRecord { Name = name, Color = Autodesk.AutoCAD.Colors.Color.FromColorIndex(ColorMethod.ByAci, (short)(name == "FPD_FIX" ? 3 : 1)) };
                layers.Add(layer); tr.AddNewlyCreatedDBObject(layer, true);
            }
            var record = (LayerTableRecord)tr.GetObject(layers[name], OpenMode.ForRead);
            if (record.IsLocked || record.IsFrozen || record.IsOff) throw new InvalidOperationException($"请在成果页或图层管理器打开、解冻并解锁 {name}。");
        }
        var model = (BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database), OpenMode.ForWrite);
        void Add(Entity e) { model.AppendEntity(e); tr.AddNewlyCreatedDBObject(e, true); }
        foreach (var row in request.Points)
        {
            var p = row.Point; var at = new Point3d(p.Easting, p.Northing, p.Z);
            var layer = row.IsObstacle ? "FPD_OBSTACLE" : "FPD_FIX";
            if (legacyPoint)
            {
                Add(new DBPoint(at) { Layer = layer });
                Add(new DBText { Layer = layer, Position = at + new Vector3d(request.TextHeight * .8, request.TextHeight * .4, 0), Height = request.TextHeight, TextString = row.Ident });
                continue;
            }
            var blockId = Symbol(tr, doc.Database, row.IsObstacle);
            var reference = new BlockReference(at, blockId) { Layer = layer, ScaleFactors = new Scale3d(request.TextHeight) };
            Add(reference);
            var definition = (BlockTableRecord)tr.GetObject(blockId, OpenMode.ForRead);
            foreach (ObjectId id in definition)
                if (tr.GetObject(id, OpenMode.ForRead) is AttributeDefinition attribute)
                {
                    var value = new AttributeReference(); value.SetAttributeFromBlock(attribute, reference.BlockTransform);
                    value.TextString = attribute.Tag == "NAME" ? row.Ident : p.Z.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture) + " m";
                    value.Invisible = attribute.Tag == "TOP" && !request.ShowTop;
                    reference.AttributeCollection.AppendAttribute(value); tr.AddNewlyCreatedDBObject(value, true);
                }
        }
        tr.Commit();
        if (legacyPoint) { doc.Database.Pdmode = 35; doc.Database.Pdsize = -3; }
        doc.Editor.Regen();
        doc.Editor.WriteMessage($"\nFPD 已绘制 {request.Points.Count} 个点及名称；CM{request.Points[0].Point.CentralMeridian} / EPSG:{request.Points[0].Point.Epsg}；原生编辑，U 可撤销本次绘图。");
    }

    private static ObjectId Symbol(Transaction tr, Database db, bool obstacle)
    {
        var blocks = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
        var name = obstacle ? "FPD_OBSTACLE_F01" : "FPD_FIX_F01";
        if (blocks.Has(name)) return blocks[name];
        blocks.UpgradeOpen(); var block = new BlockTableRecord { Name = name };
        var id = blocks.Add(block); tr.AddNewlyCreatedDBObject(block, true);
        void Add(Entity e) { e.Layer = "0"; block.AppendEntity(e); tr.AddNewlyCreatedDBObject(e, true); }
        if (obstacle)
        {
            var triangle = new Polyline();
            triangle.AddVertexAt(0, new Point2d(0, .6), 0, 0, 0); triangle.AddVertexAt(1, new Point2d(-.52, -.3), 0, 0, 0); triangle.AddVertexAt(2, new Point2d(.52, -.3), 0, 0, 0); triangle.Closed = true; Add(triangle);
        }
        else
        {
            Add(new Circle(Point3d.Origin, Vector3d.ZAxis, .35));
            Add(new Line(new Point3d(-.5, 0, 0), new Point3d(.5, 0, 0))); Add(new Line(new Point3d(0, -.5, 0), new Point3d(0, .5, 0)));
        }
        Add(new AttributeDefinition(new Point3d(.8, .4, 0), "", "NAME", "名称", db.Textstyle) { Height = 1 });
        if (obstacle) Add(new AttributeDefinition(new Point3d(.8, -.9, 0), "", "TOP", "顶标高 m", db.Textstyle) { Height = .8 });
        return id;
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
