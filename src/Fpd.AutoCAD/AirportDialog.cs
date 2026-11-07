using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

internal sealed class AirportDialog : Form
{
    public string ProjectName { get; private set; } = "";
    public AirportData Airport { get; private set; } = new();
    public AirportDialog(ProjectData project)
    {
        SuspendLayout(); Text="项目 / 机场资料"; ClientSize=new Size(400,300); AutoScaleMode=AutoScaleMode.Dpi; AutoScaleDimensions=new SizeF(96,96);
        Font=new Font("Microsoft YaHei UI",9); BackColor=Color.FromArgb(37,37,37); ForeColor=Color.Gainsboro;
        StartPosition=FormStartPosition.CenterParent; FormBorderStyle=FormBorderStyle.FixedDialog; MaximizeBox=false; MinimizeBox=false;
        var grid=new TableLayoutPanel { Dock=DockStyle.Fill, ColumnCount=2, Padding=new Padding(8) }; grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,100)); grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
        TextBox Add(string label,string value)
        {
            var row=grid.RowCount++; grid.RowStyles.Add(new RowStyle(SizeType.Absolute,32));
            grid.Controls.Add(new Label { Text=label,Dock=DockStyle.Fill,TextAlign=ContentAlignment.MiddleLeft },0,row);
            var box=new TextBox { Text=value,Dock=DockStyle.Fill,BackColor=Color.FromArgb(55,55,55),ForeColor=Color.White }; grid.Controls.Add(box,1,row); return box;
        }
        string Format(double? n)=>n?.ToString("G",CultureInfo.InvariantCulture)??"";
        double? Number(string s)=>string.IsNullOrWhiteSpace(s)?null:double.Parse(s,CultureInfo.InvariantCulture);
        var name=Add("项目名称",project.Name); var airport=Add("机场名称",project.Airport.Name); var icao=Add("ICAO",project.Airport.Icao);
        var lat=Add("ARP 纬度 °",Format(project.Airport.ArpLatitude)); var lon=Add("ARP 经度 °",Format(project.Airport.ArpLongitude)); var elevation=Add("ARP 高程 m",Format(project.Airport.ArpElevation));
        var note=new Label { Text="十进制度；一个机场 / 一个 ARP；确认后自动选带",Dock=DockStyle.Fill }; grid.Controls.Add(note,0,grid.RowCount++); grid.SetColumnSpan(note,2);
        var buttons=new FlowLayoutPanel { Dock=DockStyle.Fill,AutoSize=true,FlowDirection=FlowDirection.RightToLeft };
        var ok=new Button { Text="确定",AutoSize=true }; var cancel=new Button { Text="取消",AutoSize=true,DialogResult=DialogResult.Cancel };
        ok.Click+=(_,_)=>
        {
            try
            {
                var value=new AirportData { Name=airport.Text.Trim(),Icao=icao.Text.Trim().ToUpperInvariant(),ArpLatitude=Number(lat.Text),ArpLongitude=Number(lon.Text),ArpElevation=Number(elevation.Text) };
                ProjectValidation.Project(new ProjectData { Name=name.Text.Trim(),Airport=value });
                ProjectName=name.Text.Trim(); Airport=value; DialogResult=DialogResult.OK;
            }
            catch(Exception ex) { MessageBox.Show(this,ex.Message,"机场资料",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        };
        buttons.Controls.Add(ok); buttons.Controls.Add(cancel); grid.Controls.Add(buttons,0,grid.RowCount++); grid.SetColumnSpan(buttons,2);
        Controls.Add(grid); AcceptButton=ok; CancelButton=cancel; ResumeLayout(true);
    }
}
