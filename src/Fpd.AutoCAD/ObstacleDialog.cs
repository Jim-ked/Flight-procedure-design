using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

internal sealed class ObstacleDialog : Form
{
    public ObstacleData Value { get; private set; } = new();
    public ObstacleDialog(ObstacleData? existing=null)
    {
        SuspendLayout(); Text=existing is null?"新增障碍物":"修改障碍物"; ClientSize=new Size(370,272); AutoScaleMode=AutoScaleMode.Dpi; AutoScaleDimensions=new SizeF(96,96);
        Font=new Font("Microsoft YaHei UI",9); BackColor=Color.FromArgb(37,37,37); ForeColor=Color.Gainsboro; StartPosition=FormStartPosition.CenterParent;
        FormBorderStyle=FormBorderStyle.FixedDialog; MaximizeBox=false; MinimizeBox=false;
        var grid=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=2,Padding=new Padding(8) }; grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,110)); grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
        TextBox Add(string label,string value)
        {
            var row=grid.RowCount++; grid.RowStyles.Add(new RowStyle(SizeType.Absolute,30)); grid.Controls.Add(new Label { Text=label,Dock=DockStyle.Fill,TextAlign=ContentAlignment.MiddleLeft },0,row);
            var box=new TextBox { Text=value,Dock=DockStyle.Fill,BackColor=Color.FromArgb(55,55,55),ForeColor=Color.White }; grid.Controls.Add(box,1,row); return box;
        }
        string Format(double? n)=>n?.ToString("G",CultureInfo.InvariantCulture)??"";
        double? Optional(string s)=>string.IsNullOrWhiteSpace(s)?null:double.Parse(s,CultureInfo.InvariantCulture);
        var ident=Add("标识",existing?.Ident??""); var lat=Add("纬度 °",Format(existing?.Latitude)); var lon=Add("经度 °",Format(existing?.Longitude));
        var top=Add("顶标高 m（必填）",Format(existing?.TopElevation)); var height=Add("自身高度 m",Format(existing?.Height)); var ground=Add("地面高程 m",Format(existing?.GroundElevation));
        var note=new Label { Text="顶标高为绝对高程，不从自身高度自动推算",Dock=DockStyle.Fill }; grid.Controls.Add(note,0,grid.RowCount++); grid.SetColumnSpan(note,2);
        var buttons=new FlowLayoutPanel { Dock=DockStyle.Fill,AutoSize=true,FlowDirection=FlowDirection.RightToLeft }; var ok=new Button { Text="确定",AutoSize=true }; var cancel=new Button { Text="取消",AutoSize=true,DialogResult=DialogResult.Cancel };
        ok.Click+=(_,_)=>
        {
            try
            {
                var value=new ObstacleData { Ident=ident.Text.Trim(),Latitude=double.Parse(lat.Text,CultureInfo.InvariantCulture),Longitude=double.Parse(lon.Text,CultureInfo.InvariantCulture),TopElevation=double.Parse(top.Text,CultureInfo.InvariantCulture),Height=Optional(height.Text),GroundElevation=Optional(ground.Text) };
                ProjectValidation.Obstacle(value); Value=value; DialogResult=DialogResult.OK;
            }
            catch(Exception ex) { MessageBox.Show(this,ex.Message,"障碍物资料",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        };
        buttons.Controls.Add(ok); buttons.Controls.Add(cancel); grid.Controls.Add(buttons,0,grid.RowCount++); grid.SetColumnSpan(buttons,2); Controls.Add(grid); AcceptButton=ok; CancelButton=cancel; ResumeLayout(true);
    }
}
