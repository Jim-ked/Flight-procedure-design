using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly Label _resultDwg=Caption("");
    private readonly Label _dataSummary=Caption("");
    private readonly ListBox _layers=List();
    private readonly ListBox _resultProcedures=List();
    private readonly TextBox _resultSequence=new() { Dock=DockStyle.Fill,ReadOnly=true,Multiline=true,ScrollBars=ScrollBars.Vertical,BackColor=System.Drawing.Color.FromArgb(42,42,42),ForeColor=System.Drawing.Color.Gainsboro };
    private sealed record LayerRow(CadLayer Layer) { public override string ToString()=>$"{(Layer.Visible?"显示":"隐藏")}  {Layer.Name} · {Layer.EntityCount} 个实体"; }
    private TabPage ResultsPage()
    {
        var page=Page("成果"); var stack=Stack(); Row(stack,_resultDwg,42);
        Row(stack,Bar(Button("查看图面",()=>ViewRequested?.Invoke()),Button("刷新图层",RefreshResults)),34);
        Row(stack,_layers,25,true); Row(stack,Bar(Button("显示所选层",()=>ToggleLayer(true)),Button("隐藏所选层",()=>ToggleLayer(false))),34);
        Row(stack,_dataSummary,24); Row(stack,Bar(Button("导出 Fix CSV",()=>Export(false)),Button("导出障碍物 CSV",()=>Export(true))),34);
        Row(stack,Caption("程序成果 · 定位点使用顺序"),24); Row(stack,_resultProcedures,30,true); Row(stack,_resultSequence,45,true);
        Row(stack,Bar(Button("导出程序 JSON",ExportProcedures)),34);
        Row(stack,Caption("后续：标称航迹 · 保护区 · 障碍物评价（尚未开发）"),26);
        _resultProcedures.SelectedIndexChanged+=(_,_)=> { _resultSequence.Text=_resultProcedures.SelectedItem is ProcedureRow row ? $"{row.Value.Name} · {row.Value.Kind} · 跑道 {row.Value.Runway}\r\n{string.Join(" → ",row.Value.FixIdents)}" : ""; };
        page.Controls.Add(stack); return page;
    }
    internal void RefreshResults()
    {
        var current=_drawingPath(); _resultDwg.Text=$"关联：{(_project.DwgPath is null?"未关联":Path.GetFileName(_project.DwgPath))}\r\n当前：{(current is null?"未打开 DWG":Path.GetFileName(current))}";
        _tips.SetToolTip(_resultDwg,$"关联：{_project.DwgPath}\r\n当前：{current}");
        var name=(_layers.SelectedItem as LayerRow)?.Layer.Name; _layers.Items.Clear();
        foreach(var layer in CadDrawing.ReadLayers()) { var index=_layers.Items.Add(new LayerRow(layer)); if(layer.Name==name) _layers.SelectedIndex=index; }
        if(_layers.SelectedIndex<0 && _layers.Items.Count>0) _layers.SelectedIndex=0;
        _dataSummary.Text=$"可导出：Fix {_project.Fixes.Count} · 障碍物 {_project.Obstacles.Count}（顶标高 m）";
        var chosen=(_resultProcedures.SelectedItem as ProcedureRow)?.Value??CurrentProcedure; _resultProcedures.Items.Clear();
        foreach(var procedure in _project.Procedures) { var index=_resultProcedures.Items.Add(new ProcedureRow(procedure)); if(procedure==chosen) _resultProcedures.SelectedIndex=index; }
        if(_resultProcedures.SelectedIndex<0 && _resultProcedures.Items.Count>0) _resultProcedures.SelectedIndex=0;
    }
    private void ToggleLayer(bool visible)
    {
        var row=_layers.SelectedItem as LayerRow??throw new InvalidOperationException("请选择当前图面中的 FPD 图层。");
        LayerRequested?.Invoke(row.Layer.Name,visible);
    }
    private void Export(bool obstacle)
    {
        using var dialog=new SaveFileDialog { Filter="CSV|*.csv",FileName=obstacle?"obstacles.csv":"fixes.csv" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        File.WriteAllText(dialog.FileName,obstacle?ObstacleCsv.Export(_project.Obstacles):FixCsv.Export(_project.Fixes),new UTF8Encoding(true)); SetStatus("已导出："+Path.GetFileName(dialog.FileName));
    }
    private void ExportProcedures()
    {
        using var dialog=new SaveFileDialog { Filter="JSON|*.json",FileName="procedures.json" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        File.WriteAllText(dialog.FileName,JsonSerializer.Serialize(_project.Procedures,new JsonSerializerOptions { WriteIndented=true }),new UTF8Encoding(false)); SetStatus("已导出程序顺序数据");
    }
}
