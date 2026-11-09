using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using Fpd.Core;
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Core.Application;

[assembly: ExtensionApplication(typeof(Fpd.AutoCAD.Plugin))]
[assembly: CommandClass(typeof(Fpd.AutoCAD.Plugin))]
namespace Fpd.AutoCAD;

public sealed class Plugin : IExtensionApplication
{
    public void Initialize()
    {
        AcadApp.DocumentManager.MdiActiveDocument?.Editor.WriteMessage("\nFPD F1 已加载；FPD 打开工作区。");
    }
    public void Terminate() { FpdPalette.Dispose(); CadDrawing.DisposeProjectLibrary(); SymbolLibrary.Dispose(); }
    [CommandMethod("FPD",CommandFlags.Session)] public void OpenWorkspace()
    {
        FpdPalette.Show();
    }
    [CommandMethod("FPDCLOSE",CommandFlags.Session)] public void CloseWorkspace()=>FpdPalette.Close();
    [CommandMethod("FPDPOINT",CommandFlags.Modal)] public void DrawFix()=>Execute(()=>
    {
        var panel=FpdPalette.CurrentPanel??throw new InvalidOperationException("请先运行 FPD。");
        panel.DrawSelectedFixCommand();
    });
    [CommandMethod("FPDBATCH",CommandFlags.Modal)] public void DrawBatch()=>Execute(()=>
    {
        (FpdPalette.CurrentPanel??throw new InvalidOperationException("请先运行FPD。")).DrawCurrentAllCommand();
    });
    [CommandMethod("FPDVIEW",CommandFlags.Modal)] public void ViewDrawing()=>Execute(CadDrawing.ZoomDesign);
    [CommandMethod("FPDAUDITSYMBOLS",CommandFlags.Modal)] public void AuditSymbols()=>Execute(SymbolLibrary.Audit);
    [CommandMethod("FPDHIGHLIGHT",CommandFlags.Modal|CommandFlags.NoUndoMarker|CommandFlags.NoHistory|CommandFlags.UsePickSet|CommandFlags.Redraw)]
    public void HighlightProject()=>Execute(FpdPalette.ExecuteProjectHighlight);
    [CommandMethod("FPDBASE",CommandFlags.Modal)] public void AirportOperation()=>Execute(FpdPalette.ExecuteAirportOperation);
    private static void Execute(Action action)
    {
        try { action(); }
        catch(System.Exception ex) { AcadApp.DocumentManager.MdiActiveDocument?.Editor.WriteMessage("\nFPD："+ex.Message); FpdPalette.CurrentPanel?.SetStatus(ex.Message); AcadApp.ShowAlertDialog(ex.Message); }
    }
}

internal static class FpdPalette
{
    private static PaletteSet? _palette;
    private static Action? _airportOperation;
    private sealed record HighlightRequest(Autodesk.AutoCAD.ApplicationServices.Document Document,Action Execute,long QueuedAt);
    private static HighlightRequest? _highlightRequest;
    private static readonly HashSet<Autodesk.AutoCAD.ApplicationServices.Document> HighlightQueued=[];
    private static Autodesk.AutoCAD.ApplicationServices.Document? _queuedDocument;
    public static WorkspacePanel? CurrentPanel { get; private set; }
    public static void Show()
    {
        if(_palette is null)
        {
            CurrentPanel=new WorkspacePanel(()=>AcadApp.DocumentManager.MdiActiveDocument?.Name); CurrentPanel.CreateControl(); var scale=CurrentPanel.DeviceDpi/96f;
            _palette=new PaletteSet("固定翼飞行程序","FPD",Guid.Parse("52E45B1C-7A72-4B34-8F9E-0FD000000001"))
            {
                Style=PaletteSetStyles.ShowAutoHideButton|PaletteSetStyles.ShowCloseButton|PaletteSetStyles.ShowPropertiesMenu,
                MinimumSize=new System.Drawing.Size((int)(390*scale),(int)(540*scale)),Size=new System.Drawing.Size((int)(440*scale),(int)(760*scale)),KeepFocus=true,DockEnabled=DockSides.Left|DockSides.Right
            };
            _palette.Add("工作区",CurrentPanel);
            CurrentPanel.ViewRequested+=()=>Queue("FPDVIEW");
            CurrentPanel.AirportCommandRequested+=action=> { if(_airportOperation is not null) throw new InvalidOperationException("请等待上次CAD操作结束。"); _airportOperation=action; _palette.KeepFocus=false; try { Queue("FPDBASE"); } catch { _airportOperation=null; _palette.KeepFocus=true; throw; } };
            CurrentPanel.ProjectHighlightRequested+=QueueProjectHighlight;
            DwgProjects.Start(CurrentPanel);
            _palette.Visible=true; _palette.Dock=DockSides.Right;
        }
        _palette.Visible=true;
    }
    private static void QueueProjectHighlight(Action action)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument;
        if(doc is null) return;
        // One queued command per DWG, one latest request overall. Repeated clicks
        // replace the request; they never append a queue of obsolete camera moves.
        _highlightRequest=new(doc,action,System.Diagnostics.Stopwatch.GetTimestamp());
        if(!HighlightQueued.Add(doc)) return;
        if(_palette is not null) _palette.KeepFocus=false;
        try { doc.SendStringToExecute("FPDHIGHLIGHT ",false,false,false); }
        catch { HighlightQueued.Remove(doc); _highlightRequest=null; if(_palette is not null) _palette.KeepFocus=_airportOperation is null; throw; }
    }
    public static void ExecuteProjectHighlight()
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument;
        if(doc is null) return;
        HighlightQueued.Remove(doc);
        var request=_highlightRequest;
        if(request is null || request.Document!=doc) return;
        _highlightRequest=null;
        try
        {
            System.Diagnostics.Trace.WriteLine($"FPD selection queue {System.Diagnostics.Stopwatch.GetElapsedTime(request.QueuedAt).TotalMilliseconds:F3} ms");
            request.Execute();
        }
        finally { if(_palette is not null) _palette.KeepFocus=_airportOperation is null && _highlightRequest is null; }
    }
    internal static void CancelProjectHighlights(Autodesk.AutoCAD.ApplicationServices.Document doc)
    {
        HighlightQueued.Remove(doc);
        if(_highlightRequest?.Document==doc) _highlightRequest=null;
    }
    private static void Queue(string command)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument??throw new InvalidOperationException("请先打开 DWG。");
        _queuedDocument=doc; doc.SendStringToExecute(command+" ",true,false,false);
    }
    private static void CheckDocument()
    {
        if(_queuedDocument!=AcadApp.DocumentManager.MdiActiveDocument) throw new InvalidOperationException("当前 DWG 已切换，请重新执行操作。");
    }
    public static void ExecuteAirportOperation()
    {
        try { TakeAirportOperation()(); }
        finally { if(_palette is not null) _palette.KeepFocus=_airportOperation is null && _highlightRequest is null; }
    }
    private static Action TakeAirportOperation() { var action=_airportOperation; _airportOperation=null; CheckDocument(); return action??throw new InvalidOperationException("请从基础资料选择操作。"); }
    public static void Close() { if(_palette is not null) _palette.Visible=false; }
    public static void Dispose() { DwgProjects.Stop(); _palette?.Dispose(); _palette=null; CurrentPanel=null; _airportOperation=null; _queuedDocument=null; _highlightRequest=null; HighlightQueued.Clear(); }
}
