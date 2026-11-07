using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Fpd.Core;
namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly TextBox _latitude=Input(),_longitude=Input(),_east=Input(),_north=Input(),_cm=Input();
    private readonly TextBox _coordinateOutput=new() { Dock=DockStyle.Fill,Multiline=true,ReadOnly=true,ScrollBars=ScrollBars.Vertical,BackColor=Color.FromArgb(42,42,42),ForeColor=Color.Gainsboro };
    private TabPage ToolsPage()
    {
        var page=Page("工具"); page.Padding=Padding.Empty;
        var layout=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=2,RowCount=1,Margin=Padding.Empty };
        layout.ColumnStyles.Add(new(SizeType.Absolute,52)); layout.ColumnStyles.Add(new(SizeType.Percent,100)); layout.RowStyles.Add(new(SizeType.Percent,100));
        var side=new FlowLayoutPanel { Dock=DockStyle.Fill,FlowDirection=FlowDirection.TopDown,WrapContents=false,BackColor=Color.FromArgb(44,44,44),Margin=Padding.Empty };
        var panels=new Panel { Dock=DockStyle.Fill }; var basic=Stack(); basic.Padding=new Padding(6);
        var fields=FormGrid(); _cm.Text="117"; Field(fields,"中央经线°",_cm); Field(fields,"纬度°",_latitude); Field(fields,"经度°",_longitude); Field(fields,"东坐标 m",_east); Field(fields,"北坐标 m",_north); Row(basic,fields,152);
        Row(basic,Bar(Button("正算",ForwardCoordinate),Button("反算",InverseCoordinate),Button("CAD拾点",PickToolCoordinate)),32);
        Row(basic,_coordinateOutput,100,true);
        var reserved=new ListBox { Dock=DockStyle.Fill,BackColor=BackColor,ForeColor=Color.Gray,Enabled=false,IntegralHeight=false };
        var catalog=new[] { Array.Empty<string>(),new[]{"风螺旋（未开发）","转弯与等待（未开发）","标称航迹（未开发）"},new[]{"导航定位容差（未开发）","航迹保护区（未开发）"},new[]{"垂直剖面（未开发）","梯度与高度（未开发）"},new[]{"障碍物评价（未开发）","控制障碍物（未开发）"} };
        panels.Controls.Add(basic); panels.Controls.Add(reserved); reserved.Visible=false;
        var buttons=new List<Button>(); var titles=new[]{"基础\n计算","航迹\n机动","保护区","垂直\n设计","障碍\n评价"};
        for(var i=0;i<titles.Length;i++)
        {
            var index=i; var button=Button(titles[i],()=>{}); button.AutoSize=false; button.Width=46; button.Height=52; button.Margin=new Padding(2,4,2,0);
            button.Click+=(_,_)=> { basic.Visible=index==0; reserved.Visible=index!=0; reserved.Items.Clear(); reserved.Items.AddRange(catalog[index]); foreach(var b in buttons) b.BackColor=b==button?Color.FromArgb(55,90,115):Color.FromArgb(44,44,44); };
            buttons.Add(button); side.Controls.Add(button);
        }
        buttons[0].BackColor=Color.FromArgb(55,90,115); layout.Controls.Add(side,0,0); layout.Controls.Add(panels,1,0); page.Controls.Add(layout); return page;
    }
    private void RefreshToolChoices() { if(string.IsNullOrWhiteSpace(_latitude.Text) && _project.Airport.ArpLongitude is { } lon) _cm.Text=Cgcs2000Projection.ZoneForLongitude(lon).CentralMeridian.ToString(CultureInfo.InvariantCulture); }
    private static double ToolNumber(TextBox text) { if(!double.TryParse(text.Text,NumberStyles.Float,CultureInfo.InvariantCulture,out var v) || !double.IsFinite(v)) throw new InvalidOperationException("请输入有限十进制数值。"); return v; }
    private void ForwardCoordinate()
    {
        var p=Cgcs2000Projection.ForwardInZone(ToolNumber(_latitude),ToolNumber(_longitude),ToolNumber(_cm));
        _east.Text=p.Easting.ToString("F3",CultureInfo.InvariantCulture); _north.Text=p.Northing.ToString("F3",CultureInfo.InvariantCulture);
        _coordinateOutput.Text=$"CGCS2000 / CM{p.CentralMeridian}E\r\nE {p.Easting:F3} m\r\nN {p.Northing:F3} m";
    }
    private void InverseCoordinate()
    {
        var p=Cgcs2000Projection.InverseInZone(ToolNumber(_east),ToolNumber(_north),ToolNumber(_cm));
        _latitude.Text=p.Latitude.ToString("F9",CultureInfo.InvariantCulture); _longitude.Text=p.Longitude.ToString("F9",CultureInfo.InvariantCulture);
        _coordinateOutput.Text=$"纬度 {p.Latitude:F9}°\r\n经度 {p.Longitude:F9}°";
    }
    private void PickToolCoordinate()=>CadOperation(()=>
    {
        var p=CadDrawing.PickWcsPoint(); if(p is null) { SetStatus("已取消拾点"); return; }
        _east.Text=p.Value.X.ToString("R",CultureInfo.InvariantCulture); _north.Text=p.Value.Y.ToString("R",CultureInfo.InvariantCulture); InverseCoordinate();
    });
}
