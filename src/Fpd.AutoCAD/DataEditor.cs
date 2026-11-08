using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

internal sealed class DataEditor
{
    private readonly Form _form;
    private readonly TableLayoutPanel _grid=new() { Dock=DockStyle.Fill,ColumnCount=2,Padding=new(10) };
    public DataEditor(Form form,string title,int height)
    {
        _form=form; form.Text=title; form.ClientSize=new(440,height); form.AutoScaleMode=AutoScaleMode.Dpi; form.AutoScaleDimensions=new(96,96);
        form.Font=new("Microsoft YaHei UI",9); form.BackColor=Color.FromArgb(37,37,37); form.ForeColor=Color.Gainsboro;
        form.StartPosition=FormStartPosition.CenterScreen; form.FormBorderStyle=FormBorderStyle.FixedDialog; form.MaximizeBox=false; form.MinimizeBox=false;
        _grid.ColumnStyles.Add(new(SizeType.Absolute,130)); _grid.ColumnStyles.Add(new(SizeType.Percent,100)); form.Controls.Add(_grid);
    }
    public TextBox Field(string title,string text)
    {
        var box=new TextBox { Text=text,Dock=DockStyle.Fill,BackColor=Color.FromArgb(55,55,55),ForeColor=Color.White,AccessibleName=title };
        ControlField(title,box); return box;
    }
    public void ControlField(string title,Control control)
    {
        var row=_grid.RowCount++; _grid.RowStyles.Add(new(SizeType.Absolute,33));
        _grid.Controls.Add(new Label { Text=title,Dock=DockStyle.Fill,TextAlign=ContentAlignment.MiddleLeft },0,row); _grid.Controls.Add(control,1,row);
    }
    public void Buttons(Action accept,Action pick)
    {
        var note=new Label { Text="经纬度支持十进制度 / 度分秒",Dock=DockStyle.Fill }; var r=_grid.RowCount++; _grid.RowStyles.Add(new(SizeType.Absolute,28)); _grid.Controls.Add(note,0,r); _grid.SetColumnSpan(note,2);
        var bar=new FlowLayoutPanel { Dock=DockStyle.Fill,WrapContents=false };
        Button Add(string title,Action action) { var b=new Button { Text=title,AutoSize=true }; b.Click+=(_,_)=> { try { action(); } catch(Exception ex) { MessageBox.Show(_form,ex.Message,_form.Text,MessageBoxButtons.OK,MessageBoxIcon.Warning); } }; bar.Controls.Add(b); return b; }
        Add("CAD拾取",pick); _form.AcceptButton=Add("确定",accept);
        var cancel=new Button { Text="取消",AutoSize=true,DialogResult=DialogResult.Cancel }; bar.Controls.Add(cancel); _form.CancelButton=cancel;
        r=_grid.RowCount++; _grid.RowStyles.Add(new(SizeType.Absolute,38)); _grid.Controls.Add(bar,0,r); _grid.SetColumnSpan(bar,2);
    }
    public static string Format(double? value) => value.HasValue && double.IsFinite(value.Value)?value.Value.ToString("G17",CultureInfo.InvariantCulture):"";
    public static double Angle(TextBox box,bool latitude,bool draft) => draft && string.IsNullOrWhiteSpace(box.Text)?double.NaN:CoordinateInput.Parse(box.Text,latitude);
    public static double Number(TextBox box,bool draft) => draft && string.IsNullOrWhiteSpace(box.Text)?double.NaN:double.Parse(box.Text,NumberStyles.Float,CultureInfo.InvariantCulture);
}
