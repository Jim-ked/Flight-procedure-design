using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

internal sealed class CoordinateDialog : Form
{
    private readonly ProjectData _project;
    private readonly TextBox _latitude=new(),_longitude=new(),_east=new(),_north=new(),_z=new();
    private readonly TextBox _output=new() { Multiline=true,ReadOnly=true,ScrollBars=ScrollBars.Vertical };
    public string[] Inputs=>new[]{_latitude.Text,_longitude.Text,_east.Text,_north.Text,_z.Text};
    public CoordinateDialog(ProjectData project,string[]? inputs=null)
    {
        _project=project; Text="坐标转换"; ClientSize=new Size(520,330); StartPosition=FormStartPosition.CenterParent;
        AutoScaleMode=AutoScaleMode.Dpi; AutoScaleDimensions=new SizeF(96,96); Font=new Font("Microsoft YaHei UI",9);
        BackColor=Color.FromArgb(37,37,37); ForeColor=Color.Gainsboro; FormBorderStyle=FormBorderStyle.FixedDialog; MaximizeBox=false; MinimizeBox=false;
        _latitude.Text=DataEditor.Format(project.Airport.ArpLatitude); _longitude.Text=DataEditor.Format(project.Airport.ArpLongitude);
        if(inputs is not null) { var boxes=new[]{_latitude,_longitude,_east,_north,_z}; for(var i=0;i<boxes.Length;i++) boxes[i].Text=inputs[i]; }
        foreach(var box in new[]{_latitude,_longitude,_east,_north,_z,_output}) { box.BackColor=Color.FromArgb(55,55,55); box.ForeColor=Color.White; box.Dock=DockStyle.Fill; }
        var grid=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=2,Padding=new Padding(10) };
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,120)); grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
        Field(grid,"纬度",_latitude); Field(grid,"经度",_longitude); Field(grid,"X / 东坐标（m）",_east); Field(grid,"Y / 北坐标（m）",_north); Field(grid,"Z / 高程（m）",_z);
        var actions=new FlowLayoutPanel { Dock=DockStyle.Fill,WrapContents=false };
        Add(actions,"正算",Forward); Add(actions,"反算",Inverse); Add(actions,"CAD拾点",()=>DialogResult=DialogResult.Retry); Add(actions,"复制",Copy); Add(actions,"关闭",()=>DialogResult=DialogResult.Cancel);
        var actionRow=grid.RowCount++; grid.RowStyles.Add(new RowStyle(SizeType.Absolute,38)); grid.Controls.Add(actions,0,actionRow); grid.SetColumnSpan(actions,2);
        var outputRow=grid.RowCount++; grid.RowStyles.Add(new RowStyle(SizeType.Percent,100)); grid.Controls.Add(_output,0,outputRow); grid.SetColumnSpan(_output,2);
        Controls.Add(grid);
    }
    private static void Field(TableLayoutPanel grid,string title,TextBox box)
    {
        var row=grid.RowCount++; grid.RowStyles.Add(new RowStyle(SizeType.Absolute,31));
        grid.Controls.Add(new Label { Text=title,AutoSize=true,TextAlign=ContentAlignment.MiddleLeft,Dock=DockStyle.Fill },0,row); grid.Controls.Add(box,1,row);
    }
    private static void Add(FlowLayoutPanel bar,string title,Action action)
    {
        var button=new Button { Text=title,AutoSize=true,MinimumSize=new Size(64,28),FlatStyle=FlatStyle.Flat,BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White };
        button.Click+=(_,_)=> { try { action(); } catch(Exception ex) { MessageBox.Show(ex.Message,"坐标转换",MessageBoxButtons.OK,MessageBoxIcon.Warning); } }; bar.Controls.Add(button);
    }
    private static double Number(TextBox box)
    {
        if(!double.TryParse(box.Text,NumberStyles.Float,CultureInfo.InvariantCulture,out var value) || !double.IsFinite(value)) throw new InvalidOperationException("请输入有限十进制数值。");
        return value;
    }
    private void Forward()
    {
        var lat=CoordinateInput.Parse(_latitude.Text,true); var lon=CoordinateInput.Parse(_longitude.Text,false);
        double? z=string.IsNullOrWhiteSpace(_z.Text)?null:Number(_z); var p=Cgcs2000Projection.ForwardInZone(lat,lon,AirportGeometry.Meridian(_project),z);
        _east.Text=p.Easting.ToString("F3",CultureInfo.InvariantCulture); _north.Text=p.Northing.ToString("F3",CultureInfo.InvariantCulture);
        _output.Text=$"X {p.Easting:F3} m\r\nY {p.Northing:F3} m\r\nZ {(z.HasValue?z.Value.ToString("F3",CultureInfo.InvariantCulture):"0.000")} m";
    }
    private void Inverse()
    {
        var p=Cgcs2000Projection.InverseInZone(Number(_east),Number(_north),AirportGeometry.Meridian(_project),string.IsNullOrWhiteSpace(_z.Text)?0:Number(_z));
        _latitude.Text=p.Latitude.ToString("F9",CultureInfo.InvariantCulture); _longitude.Text=p.Longitude.ToString("F9",CultureInfo.InvariantCulture);
        _output.Text=$"纬度 {p.Latitude:F9}°\r\n经度 {p.Longitude:F9}°\r\nZ {p.Elevation:F3} m";
    }
    private void Copy()
    {
        if(_output.Text.Length==0) throw new InvalidOperationException("暂无转换结果。");
        Clipboard.SetText(_output.Text);
    }
}
