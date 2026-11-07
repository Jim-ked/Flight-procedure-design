using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

internal sealed class NavaidDialog : Form
{
    public NavaidData Value { get; private set; } = new();
    public bool PickGlidePath { get; private set; }
    public NavaidDialog(NavaidData? value=null)
    {
        SuspendLayout(); Text="导航设施资料"; ClientSize=new(520,480); AutoScaleMode=AutoScaleMode.Dpi; AutoScaleDimensions=new(96,96);
        Font=new("Microsoft YaHei UI",9); BackColor=Color.FromArgb(37,37,37); ForeColor=Color.Gainsboro; StartPosition=FormStartPosition.CenterScreen;
        FormBorderStyle=FormBorderStyle.FixedDialog; MinimizeBox=false; MaximizeBox=false;
        var grid=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=2,Padding=new(8) }; grid.ColumnStyles.Add(new(SizeType.Absolute,140)); grid.ColumnStyles.Add(new(SizeType.Percent,100));
        TextBox Field(string title,string text) { var r=grid.RowCount++; grid.RowStyles.Add(new(SizeType.Absolute,30)); grid.Controls.Add(new Label { Text=title,Dock=DockStyle.Fill,TextAlign=ContentAlignment.MiddleLeft },0,r); var t=new TextBox { Text=text,Dock=DockStyle.Fill,BackColor=Color.FromArgb(55,55,55),ForeColor=Color.White }; grid.Controls.Add(t,1,r); return t; }
        var ident=Field("标识",value?.Ident??""); var name=Field("名称",value?.Name??"");
        var kind=new ComboBox { Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList }; kind.Items.AddRange(Enum.GetNames<NavaidKind>());
        var kr=grid.RowCount++; grid.RowStyles.Add(new(SizeType.Absolute,30)); grid.Controls.Add(new Label { Text="类型",Dock=DockStyle.Fill },0,kr); grid.Controls.Add(kind,1,kr);
        var lat=Field("纬度 ° / ILS LOC",Format(value?.Position.Latitude)); var lon=Field("经度 °",Format(value?.Position.Longitude)); var elevation=Field("标高 m",Format(value?.Position.Elevation));
        var mhz=Field("频率 MHz / ILS LOC",Format(value?.FrequencyMHz)); var khz=Field("频率 kHz (NDB)",Format(value?.FrequencyKHz)); var channel=Field("DME频道",value?.Channel??""); var variation=Field("VOR磁差 °（东正）",Format(value?.MagneticVariation));
        var gpLat=Field("GP纬度 °",Format(value?.GlidePathPosition?.Latitude)); var gpLon=Field("GP经度 °",Format(value?.GlidePathPosition?.Longitude)); var gpElevation=Field("GP标高 m",Format(value?.GlidePathPosition?.Elevation)); var angle=Field("GP角度 °",Format(value?.GlidePathAngle));
        NavaidData Read() { double Required(TextBox b)=>string.IsNullOrWhiteSpace(b.Text)?double.NaN:double.Parse(b.Text,CultureInfo.InvariantCulture); double? Optional(TextBox b)=>string.IsNullOrWhiteSpace(b.Text)?null:Required(b); var k=(NavaidKind)kind.SelectedIndex;
            return new() { Ident=ident.Text.Trim(),Name=name.Text.Trim(),Kind=k,Position=new() { Latitude=Required(lat),Longitude=Required(lon),Elevation=Required(elevation) },FrequencyMHz=k==NavaidKind.NDB?null:Optional(mhz),FrequencyKHz=k==NavaidKind.NDB?Optional(khz):null,
                Channel=k==NavaidKind.DME?channel.Text.Trim():null,MagneticVariation=k==NavaidKind.VOR?Optional(variation):null,
                GlidePathPosition=k==NavaidKind.ILS && new[] { gpLat,gpLon,gpElevation }.Any(b=>!string.IsNullOrWhiteSpace(b.Text)) ? new() { Latitude=Required(gpLat),Longitude=Required(gpLon),Elevation=Required(gpElevation) }:null,GlidePathAngle=k==NavaidKind.ILS?Optional(angle):null }; }
        void ShowType() { var k=(NavaidKind)kind.SelectedIndex; var scale=IsHandleCreated?DeviceDpi/96f:1f; void Show(TextBox field,bool visible) { var row=grid.GetRow(field); field.Visible=visible; grid.GetControlFromPosition(0,row)!.Visible=visible; grid.RowStyles[row].Height=visible?30*scale:0; }
            Show(mhz,k!=NavaidKind.NDB); Show(khz,k==NavaidKind.NDB); Show(channel,k==NavaidKind.DME); Show(variation,k==NavaidKind.VOR); foreach(var box in new[] { gpLat,gpLon,gpElevation,angle }) Show(box,k==NavaidKind.ILS); ClientSize=new((int)(520*scale),(int)((k==NavaidKind.ILS?450:k==NavaidKind.NDB?330:360)*scale)); }
        kind.SelectedIndexChanged+=(_,_)=>ShowType(); kind.SelectedIndex=(int)(value?.Kind??NavaidKind.VOR);
        var actions=new FlowLayoutPanel { Dock=DockStyle.Fill,WrapContents=false };
        void Pick(string title,bool gp) { var b=new Button { Text=title,AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat }; b.Click+=(_,_)=> { try { if(gp && kind.SelectedIndex!=(int)NavaidKind.ILS) throw new InvalidOperationException("只有ILS使用GP位置。"); Value=Read(); PickGlidePath=gp; DialogResult=DialogResult.Retry; } catch(Exception ex) { MessageBox.Show(this,ex.Message,Text); } }; actions.Controls.Add(b); }
        Pick("CAD拾取位置 / LOC",false); Pick("CAD拾取GP",true);
        var ar=grid.RowCount++; grid.RowStyles.Add(new(SizeType.Absolute,34)); grid.Controls.Add(actions,0,ar); grid.SetColumnSpan(actions,2);
        var note=new Label { Text="位置按当前项目投影解释；频率等缺省可留空。",Dock=DockStyle.Fill }; var nr=grid.RowCount++; grid.RowStyles.Add(new(SizeType.Absolute,25)); grid.Controls.Add(note,0,nr); grid.SetColumnSpan(note,2);
        var buttons=new FlowLayoutPanel { Dock=DockStyle.Fill,FlowDirection=FlowDirection.RightToLeft }; var ok=new Button { Text="确定",AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat }; ok.Click+=(_,_)=> { try { var n=Read(); ProjectValidation.Navaid(n); Value=n; DialogResult=DialogResult.OK; } catch(Exception ex) { MessageBox.Show(this,ex.Message,Text); } };
        var cancel=new Button { Text="取消",AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat,DialogResult=DialogResult.Cancel }; buttons.Controls.Add(ok); buttons.Controls.Add(cancel); var br=grid.RowCount++; grid.RowStyles.Add(new(SizeType.Absolute,34)); grid.Controls.Add(buttons,0,br); grid.SetColumnSpan(buttons,2);
        Controls.Add(grid); AcceptButton=ok; CancelButton=cancel; ResumeLayout(true);
    }
    private static string Format(double? n)=>n.HasValue && double.IsFinite(n.Value)?n.Value.ToString("G",CultureInfo.InvariantCulture):"";
}
