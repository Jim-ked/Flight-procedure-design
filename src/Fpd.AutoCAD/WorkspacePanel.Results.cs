using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly Label _resultDwg=Caption("");
    private readonly ListBox _artifacts=List();
    private TabPage ResultsPage()
    {
        var page=Page("成果"); var stack=Stack(); Row(stack,_resultDwg,44);
        Row(stack,Bar(Button("查看图面",()=>ViewRequested?.Invoke()),Button("刷新",RefreshResults)),32);
        Row(stack,_artifacts,100,true);
        Row(stack,Bar(Button("导出程序路径 JSON",ExportProcedures)),32);
        page.Controls.Add(stack); return page;
    }
    internal void RefreshResults()
    {
        var current=_drawingPath(); _resultDwg.Text="当前DWG："+(current is null?"未打开":Path.GetFileName(current));
        _tips.SetToolTip(_resultDwg,current??"无DWG"); _artifacts.Items.Clear();
        foreach(var layer in CadDrawing.ReadLayers().Where(l=>l.EntityCount>0))
            _artifacts.Items.Add($"图面 · {layer.Name} · {layer.EntityCount} 个原生实体");
        foreach(var p in _project.Procedures.Where(p=>p.Paths.Any(path=>path.Fixes.Count>0)))
            _artifacts.Items.Add($"程序数据 · {p.Name} · {p.Paths.Count} 条路径");
    }
    private void Export(bool obstacle)
    {
        using var dialog=new SaveFileDialog { Filter="CSV|*.csv",FileName=obstacle?"obstacles.csv":"fixes.csv" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        File.WriteAllText(dialog.FileName,obstacle?ObstacleCsv.Export(_project.Obstacles):FixCsv.Export(_project.Fixes),new UTF8Encoding(true)); SetStatus("已导出："+Path.GetFileName(dialog.FileName));
    }
    private void ExportAirport(bool runway)
    {
        using var dialog=new SaveFileDialog { Filter="CSV|*.csv",FileName=runway?"runways.csv":"navaids.csv" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        File.WriteAllText(dialog.FileName,runway?RunwayCsv.Export(_project.Runways):NavaidCsv.Export(_project.Navaids),new UTF8Encoding(true)); SetStatus("已导出："+Path.GetFileName(dialog.FileName));
    }
    private void ExportProcedures()
    {
        using var dialog=new SaveFileDialog { Filter="JSON|*.json",FileName="procedures.json" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        File.WriteAllText(dialog.FileName,JsonSerializer.Serialize(new { Format="FPD procedure paths (not ARINC424)",_project.ProjectId,Procedures=_project.Procedures.Select(p=>new { p.ProcedureId,p.Name,p.Kind,p.Runway,p.Paths }) },new JsonSerializerOptions { WriteIndented=true }),new UTF8Encoding(false)); SetStatus("已导出程序顺序数据");
    }
}
