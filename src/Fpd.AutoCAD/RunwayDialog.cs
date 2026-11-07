using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

internal sealed class RunwayDialog : Form
{
    private readonly TextBox _ident=new(),_width=new(),_endA=new(),_endB=new();
    private readonly DataGridView _positions=new();
    public RunwayData Value { get; private set; } = new();
    public int PickIndex { get; private set; } = -1;
    public RunwayDialog(RunwayData? value=null)
    {
        SuspendLayout(); Text="跑道资料 · 十进制度 / 米"; ClientSize=new(720,350); AutoScaleMode=AutoScaleMode.Dpi; AutoScaleDimensions=new(96,96);
        Font=new("Microsoft YaHei UI",9); BackColor=Color.FromArgb(37,37,37); ForeColor=Color.Gainsboro;
        StartPosition=FormStartPosition.CenterScreen; MinimizeBox=false; MaximizeBox=false; FormBorderStyle=FormBorderStyle.FixedDialog;
        var stack=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=1,Padding=new(8) };
        var fields=new FlowLayoutPanel { Dock=DockStyle.Fill,WrapContents=false };
        void Field(string title,TextBox box,int width) { fields.Controls.Add(new Label { Text=title,AutoSize=true,Margin=new(3,6,3,0) }); box.Width=width; box.BackColor=Color.FromArgb(55,55,55); box.ForeColor=Color.White; fields.Controls.Add(box); }
        Field("跑道",_ident,95); Field("宽 m",_width,55); Field("A端",_endA,55); Field("B端",_endB,55);
        _ident.Text=value?.Ident??""; _width.Text=Format(value?.Width); _endA.Text=value?.EndA.Designator??""; _endB.Text=value?.EndB.Designator??"";
        _positions.Dock=DockStyle.Fill; _positions.AllowUserToAddRows=false; _positions.AllowUserToDeleteRows=false; _positions.RowHeadersVisible=false;
        _positions.BackgroundColor=BackColor; _positions.EnableHeadersVisualStyles=false;
        _positions.ColumnHeadersDefaultCellStyle=new DataGridViewCellStyle { BackColor=Color.FromArgb(55,55,55),ForeColor=Color.Gainsboro };
        _positions.DefaultCellStyle=new DataGridViewCellStyle { BackColor=Color.FromArgb(42,42,42),ForeColor=Color.Gainsboro,SelectionBackColor=Color.FromArgb(55,90,115),SelectionForeColor=Color.White }; _positions.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill; _positions.SelectionMode=DataGridViewSelectionMode.FullRowSelect; _positions.MultiSelect=false;
        _positions.Columns.Add(new DataGridViewTextBoxColumn { HeaderText="位置",ReadOnly=true,FillWeight=95 });
        foreach(var title in new[] { "纬度 °","经度 °","标高 m" }) _positions.Columns.Add(title,title);
        var positions=value is null ? new GeoPosition?[6] : new[] { value.EndA.PhysicalEnd,value.EndA.Threshold,value.EndA.DepartureEnd,value.EndB.PhysicalEnd,value.EndB.Threshold,value.EndB.DepartureEnd };
        var names=new[] { "A 实际端","A THR入口","A DER离场端","B 实际端","B THR入口","B DER离场端" };
        for(var i=0;i<6;i++) _positions.Rows.Add(names[i],Format(positions[i]?.Latitude),Format(positions[i]?.Longitude),Format(positions[i]?.Elevation));
        var actions=new FlowLayoutPanel { Dock=DockStyle.Fill,WrapContents=false };
        Button Add(string title,Action action) { var b=new Button { Text=title,AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat }; b.Click+=(_,_)=> { try { _positions.EndEdit(); action(); } catch(Exception ex) { MessageBox.Show(this,ex.Message,Text); } }; actions.Controls.Add(b); return b; }
        Add("CAD拾取所选位置",()=> { Value=Read(); PickIndex=_positions.CurrentRow?.Index??0; DialogResult=DialogResult.Retry; });
        Add("复制本端实际端至THR/DER",()=> { var first=(_positions.CurrentRow?.Index??0)<3?0:3; for(var r=first+1;r<first+3;r++) for(var c=1;c<4;c++) _positions[c,r].Value=_positions[c,first].Value; });
        var buttons=new FlowLayoutPanel { Dock=DockStyle.Fill,FlowDirection=FlowDirection.RightToLeft };
        var ok=new Button { Text="确定",AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat }; ok.Click+=(_,_)=> { try { _positions.EndEdit(); var result=Read(); ProjectValidation.Runway(result); Value=result; DialogResult=DialogResult.OK; } catch(Exception ex) { MessageBox.Show(this,ex.Message,Text); } };
        var cancel=new Button { Text="取消",AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat,DialogResult=DialogResult.Cancel }; buttons.Controls.Add(ok); buttons.Controls.Add(cancel);
        void Row(Control control,int height, bool fill=false) { var r=stack.RowCount++; stack.RowStyles.Add(new(fill?SizeType.Percent:SizeType.Absolute,height)); stack.Controls.Add(control,0,r); }
        Row(fields,34); Row(_positions,100,true); Row(actions,34); Row(new Label { Text="THR与DER独立保存；格网方向由两实际端计算，不代表磁航向。",Dock=DockStyle.Fill },25); Row(buttons,34);
        Controls.Add(stack); AcceptButton=ok; CancelButton=cancel; ResumeLayout(true);
    }
    private static string Format(double? n)=>n.HasValue && double.IsFinite(n.Value)?n.Value.ToString("G",CultureInfo.InvariantCulture):"";
    private static double Number(string? text)=>string.IsNullOrWhiteSpace(text)?double.NaN:double.Parse(text,CultureInfo.InvariantCulture);
    private RunwayData Read()
    {
        GeoPosition Position(int row)=>new() { Latitude=Number(_positions[1,row].Value?.ToString()),Longitude=Number(_positions[2,row].Value?.ToString()),Elevation=Number(_positions[3,row].Value?.ToString()) };
        return new() { Ident=_ident.Text.Trim(),Width=Number(_width.Text),
            EndA=new() { Designator=_endA.Text.Trim(),PhysicalEnd=Position(0),Threshold=Position(1),DepartureEnd=Position(2) },
            EndB=new() { Designator=_endB.Text.Trim(),PhysicalEnd=Position(3),Threshold=Position(4),DepartureEnd=Position(5) } };
    }
    public static void SetPosition(RunwayData value,int index,GeoPosition position)
    {
        var end=index<3?value.EndA:value.EndB;
        switch(index%3) { case 0: end.PhysicalEnd=position; break; case 1: end.Threshold=position; break; case 2: end.DepartureEnd=position; break; }
    }
}
