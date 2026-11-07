using System.Drawing;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly ComboBox _pointSource=new() { Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList };
    private readonly ComboBox _toolFix=new() { Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList };
    private readonly TextBox _coordinateOutput=new() { Dock=DockStyle.Fill,Multiline=true,ReadOnly=true,ScrollBars=ScrollBars.Both,WordWrap=false,BackColor=Color.FromArgb(42,42,42),ForeColor=Color.Gainsboro };
    private TabPage ToolsPage()
    {
        var page=Page("工具"); page.Padding=Padding.Empty;
        var layout=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=2,RowCount=1,Margin=Padding.Empty };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,52)); layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100)); layout.RowStyles.Add(new RowStyle(SizeType.Percent,100));
        var side=new FlowLayoutPanel { Dock=DockStyle.Fill,FlowDirection=FlowDirection.TopDown,WrapContents=false,BackColor=Color.FromArgb(44,44,44),Margin=Padding.Empty };
        var panels=new Panel { Dock=DockStyle.Fill }; var basic=Stack(); basic.Padding=new Padding(6);
        _pointSource.Items.AddRange(new[] { "所选 Fix（项目表多选）","ARP","单个 Fix","全部 Fix","所选障碍物（项目表多选）","全部障碍物" }); _pointSource.SelectedIndex=0;
        Row(basic,_pointSource,32); Row(basic,_toolFix,32);
        Row(basic,Bar(Button("坐标转换",ShowCoordinates),Button("绘制当前选择",()=>Draw(ToolPoints()))),34);
        Row(basic,Bar(Button("绘制 ARP",()=>Draw(PointProjection.Arp(_project))),Button("绘制所选障碍物",()=>Draw(PointProjection.Obstacles(_project,SelectedObstacles())))),34);
        Row(basic,_coordinateOutput,100,true);
        var reserved=Caption(""); reserved.Dock=DockStyle.Top; reserved.Height=32;
        panels.Controls.Add(basic); panels.Controls.Add(reserved);
        var buttons=new List<Button>(); var titles=new[] { "基础\n计算","航迹\n机动","保护区","垂直\n设计","障碍\n评价" };
        for(var i=0;i<titles.Length;i++)
        {
            var index=i; var button=Button(titles[i],()=>{}); button.AutoSize=false; button.Width=46; button.Height=52; button.Margin=new Padding(2,4,2,0);
            button.Click+=(_,_)=> { basic.Visible=index==0; reserved.Visible=index!=0; reserved.Text=index==0?"":titles[index].Replace("\n","")+" · 尚未开发"; foreach(var b in buttons) b.BackColor=b==button?Color.FromArgb(55,90,115):Color.FromArgb(44,44,44); };
            buttons.Add(button); side.Controls.Add(button);
        }
        buttons[0].BackColor=Color.FromArgb(55,90,115); reserved.Visible=false;
        _pointSource.SelectedIndexChanged+=(_,_)=> { _toolFix.Enabled=_pointSource.SelectedIndex==2; _coordinateOutput.Clear(); };
        _toolFix.Enabled=false; layout.Controls.Add(side,0,0); layout.Controls.Add(panels,1,0); page.Controls.Add(layout); return page;
    }
    private void RefreshToolChoices()
    {
        var selected=_toolFix.SelectedItem as string; _toolFix.Items.Clear(); _toolFix.Items.AddRange(_project.Fixes.Select(f=>f.Ident).ToArray());
        if(selected is not null && _toolFix.Items.Contains(selected)) _toolFix.SelectedItem=selected; else if(_toolFix.Items.Count>0) _toolFix.SelectedIndex=0;
    }
    private IReadOnlyList<PlotPoint> ToolPoints()=>_pointSource.SelectedIndex switch
    {
        1=>PointProjection.Arp(_project),
        2=>PointProjection.Fixes(_project,_project.Fixes.Where(f=>f.Ident==_toolFix.SelectedItem as string)),
        3=>PointProjection.Fixes(_project,_project.Fixes),
        4=>PointProjection.Obstacles(_project,SelectedObstacles()),
        5=>PointProjection.Obstacles(_project,_project.Obstacles),
        _=>PointProjection.Fixes(_project,SelectedFixes())
    };
    private void ShowCoordinates()
    {
        var rows=ToolPoints();
        _coordinateOutput.Text=string.Join(Environment.NewLine+Environment.NewLine,rows.Select(p=>$"{p.Ident} · CM{p.Point.CentralMeridian}E / EPSG:{p.Point.Epsg}\r\nE {p.Point.Easting:F3} m\r\nN {p.Point.Northing:F3} m\r\nZ {p.Point.Z:F3} m"));
        SetStatus($"已转换 {rows.Count} 个点（当前工具内显示）");
    }
}
