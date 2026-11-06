using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Fpd.Core;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Core.Application;

[assembly: ExtensionApplication(typeof(Fpd.AutoCAD.Plugin))]
[assembly: CommandClass(typeof(Fpd.AutoCAD.Plugin))]

namespace Fpd.AutoCAD;

public sealed class Plugin : IExtensionApplication
{
    public void Initialize() => AcadApp.DocumentManager.MdiActiveDocument?.Editor.WriteMessage("\nFPD 已加载；运行 FPD 打开工作区。");
    public void Terminate() => FpdPalette.Dispose();

    [CommandMethod("FPD", CommandFlags.Session)]
    public void OpenWorkspace() => FpdPalette.Show();

    [CommandMethod("FPDCLOSE", CommandFlags.Session)]
    public void CloseWorkspace() => FpdPalette.Close();

    [CommandMethod("FPDPOINT", CommandFlags.Modal)]
    public void DrawFix()
    {
        var doc = AcadApp.DocumentManager.MdiActiveDocument;
        if (doc is null) { AcadApp.ShowAlertDialog("请先打开 DWG。"); return; }
        try
        {
            var panel = FpdPalette.CurrentPanel ?? throw new InvalidOperationException("请先运行 FPD 打开工作区。");
            var (fix, p) = panel.GetSelectedPoint();
            using var documentLock = doc.LockDocument();
            using var tr = doc.Database.TransactionManager.StartTransaction();
            var layers = (LayerTable)tr.GetObject(doc.Database.LayerTableId, OpenMode.ForRead);
            const string layerName = "FPD_FIX";
            if (!layers.Has(layerName))
            {
                layers.UpgradeOpen(); var layer = new LayerTableRecord { Name = layerName, Color = Autodesk.AutoCAD.Colors.Color.FromColorIndex(Autodesk.AutoCAD.Colors.ColorMethod.ByAci, 3) };
                layers.Add(layer); tr.AddNewlyCreatedDBObject(layer, true);
            }
            var layerRecord = (LayerTableRecord)tr.GetObject(layers[layerName], OpenMode.ForRead);
            if (layerRecord.IsLocked || layerRecord.IsFrozen || layerRecord.IsOff)
                throw new InvalidOperationException("请先在 AutoCAD 图层管理器中打开、解冻并解锁 FPD_FIX 图层。");
            var model = (BlockTableRecord)tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(doc.Database), OpenMode.ForWrite);
            var point = new DBPoint(new Point3d(p.Easting, p.Northing, p.Z)) { Layer = layerName };
            model.AppendEntity(point); tr.AddNewlyCreatedDBObject(point, true);
            tr.Commit();
            // A visible native point symbol; coordinates are full WCS easting/northing, independent of current UCS.
            doc.Database.Pdmode = 35; doc.Database.Pdsize = -3;
            panel.SetDwgPath(doc.Name);
            doc.Editor.Regen();
            doc.Editor.WriteMessage($"\nFPDPOINT {fix.Ident}: WCS X(E)={p.Easting:F3}, Y(N)={p.Northing:F3}, Z={p.Z:F3} m; CM{p.CentralMeridian:0}E / EPSG:{p.Epsg}; DBPoint / {layerName}{(fix.Elevation.HasValue ? "" : "; 高程未提供，Z=0")}");
        }
        catch (System.Exception ex) { doc.Editor.WriteMessage("\nFPDPOINT 失败：" + ex.Message); AcadApp.ShowAlertDialog(ex.Message); }
    }
}

internal static class FpdPalette
{
    private static PaletteSet? _palette;
    public static WorkspacePanel? CurrentPanel { get; private set; }

    public static void Show()
    {
        if (_palette is null)
        {
            CurrentPanel = new WorkspacePanel(() => AcadApp.DocumentManager.MdiActiveDocument?.Name);
            CurrentPanel.CreateControl();
            var dpiScale = CurrentPanel.DeviceDpi / 96f;
            _palette = new PaletteSet("固定翼飞行程序", "FPD", Guid.Parse("52E45B1C-7A72-4B34-8F9E-0FD000000001"))
            {
                Style = PaletteSetStyles.ShowAutoHideButton | PaletteSetStyles.ShowCloseButton | PaletteSetStyles.ShowPropertiesMenu,
                MinimumSize = new System.Drawing.Size((int)(360 * dpiScale), (int)(420 * dpiScale)),
                Size = new System.Drawing.Size((int)(390 * dpiScale), (int)(740 * dpiScale)),
                KeepFocus = true,
                DockEnabled = DockSides.Left | DockSides.Right
            };
            _palette.Add("工作区", CurrentPanel);
            CurrentPanel.DrawFixRequested += (_, _) =>
            {
                var doc = AcadApp.DocumentManager.MdiActiveDocument;
                if (doc is null) AcadApp.ShowAlertDialog("请先打开 DWG。");
                else doc.SendStringToExecute("FPDPOINT ", true, false, false);
            };
            _palette.Visible = true;
            _palette.Dock = DockSides.Right;
        }
        _palette.Visible = true;
    }
    public static void Close() { if (_palette is not null) _palette.Visible = false; }
    public static void Dispose() { _palette?.Dispose(); _palette = null; CurrentPanel = null; }
}
