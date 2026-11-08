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
        SuspendLayout(); Text="跑道资料 · 两个运行方向"; ClientSize=new(740,385); AutoScaleMode=AutoScaleMode.Dpi; AutoScaleDimensions=new(96,96);
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
        _positions.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText="自定义位置",FillWeight=55 });
        var names=new[] { "A 实际端","A THR入口","A DER离场端","B 实际端","B THR入口","B DER离场端" };
        for(var i=0;i<6;i++)
        {
            var defaultPosition=value is null?null:i%3==1?(i<3?value.EndA.PhysicalEnd:value.EndB.PhysicalEnd):(i<3?value.EndB.PhysicalEnd:value.EndA.PhysicalEnd);
            var custom=i%3==0 || positions[i] is not null && !RunwayDefaults.Same(positions[i],defaultPosition);
            _positions.Rows.Add(names[i],Format(positions[i]?.Latitude),Format(positions[i]?.Longitude),Format(positions[i]?.Elevation),custom);
            _positions[4,i].ReadOnly=i%3==0;
        }
        _positions.CurrentCellDirtyStateChanged+=(_,_)=> { if(_positions.IsCurrentCellDirty) _positions.CommitEdit(DataGridViewDataErrorContexts.Commit); };
        void EnableRows() { for(var i=0;i<6;i++) for(var c=1;c<4;c++) _positions[c,i].ReadOnly=!(bool)_positions[4,i].Value; }
        _positions.CellValueChanged+=(_,e)=> { if(e.ColumnIndex==4) EnableRows(); }; EnableRows();
        var directions=new TabControl { Dock=DockStyle.Fill }; directions.TabPages.Add("方向 A · THR / DER"); directions.TabPages.Add("方向 B · THR / DER");
        void Direction() { _positions.CurrentCell=null; for(var i=0;i<6;i++) _positions.Rows[i].Visible=(i<3)==(directions.SelectedIndex==0); }
        directions.SelectedIndexChanged+=(_,_)=>Direction(); Direction();
        var actions=new FlowLayoutPanel { Dock=DockStyle.Fill,WrapContents=false };
        Button Add(string title,Action action) { var b=new Button { Text=title,AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat }; b.Click+=(_,_)=> { try { _positions.EndEdit(); action(); } catch(Exception ex) { MessageBox.Show(this,ex.Message,Text); } }; actions.Controls.Add(b); return b; }
        Add("CAD拾取所选位置",()=> { var index=_positions.CurrentRow?.Index??(directions.SelectedIndex==0?0:3); _positions[4,index].Value=true; Value=Read(); PickIndex=index; DialogResult=DialogResult.Retry; });
        var buttons=new FlowLayoutPanel { Dock=DockStyle.Fill,FlowDirection=FlowDirection.RightToLeft };
        var ok=new Button { Text="确定",AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat }; ok.Click+=(_,_)=> { try { _positions.EndEdit(); var result=Read(); ProjectValidation.Runway(result); Value=result; DialogResult=DialogResult.OK; } catch(Exception ex) { MessageBox.Show(this,ex.Message,Text); } };
        var cancel=new Button { Text="取消",AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat,DialogResult=DialogResult.Cancel }; buttons.Controls.Add(ok); buttons.Controls.Add(cancel);
        void Row(Control control,int height, bool fill=false) { var r=stack.RowCount++; stack.RowStyles.Add(new(fill?SizeType.Percent:SizeType.Absolute,height)); stack.Controls.Add(control,0,r); }
        Row(fields,34); Row(directions,30); Row(_positions,100,true); Row(actions,34); Row(new Label { Text="THR默认本端；DER默认对端物理端。内移入口/特殊DER勾选自定义。",Dock=DockStyle.Fill },25); Row(buttons,34);
        Controls.Add(stack); AcceptButton=ok; CancelButton=cancel; ResumeLayout(true);
    }
    private static string Format(double? n)=>n.HasValue && double.IsFinite(n.Value)?n.Value.ToString("G",CultureInfo.InvariantCulture):"";
    private static double Number(string? text)=>string.IsNullOrWhiteSpace(text)?double.NaN:double.Parse(text,CultureInfo.InvariantCulture);
    private static double Angle(string? text,bool latitude)=>string.IsNullOrWhiteSpace(text)?double.NaN:CoordinateInput.Parse(text,latitude);
    private RunwayData Read()
    {
        GeoPosition Position(int row)=>new() { Latitude=Angle(_positions[1,row].Value?.ToString(),true),Longitude=Angle(_positions[2,row].Value?.ToString(),false),Elevation=Number(_positions[3,row].Value?.ToString()) };
        var value=new RunwayData { Ident=_ident.Text.Trim(),Width=Number(_width.Text),
            EndA=new() { Designator=_endA.Text.Trim(),PhysicalEnd=Position(0),Threshold=(bool)_positions[4,1].Value?Position(1):null!,DepartureEnd=(bool)_positions[4,2].Value?Position(2):null! },
            EndB=new() { Designator=_endB.Text.Trim(),PhysicalEnd=Position(3),Threshold=(bool)_positions[4,4].Value?Position(4):null!,DepartureEnd=(bool)_positions[4,5].Value?Position(5):null! } };
        if(string.IsNullOrWhiteSpace(value.Ident)) value.Ident=value.EndA.Designator+"/"+value.EndB.Designator;
        RunwayDefaults.Resolve(value); return value;
    }
    public static void SetPosition(RunwayData value,int index,GeoPosition position)
    {
        var end=index<3?value.EndA:value.EndB;
        switch(index%3)
        {
            case 0:
                var other=index<3?value.EndB:value.EndA;
                if(RunwayDefaults.Same(end.Threshold,end.PhysicalEnd)) end.Threshold=RunwayDefaults.Copy(position);
                if(RunwayDefaults.Same(other.DepartureEnd,end.PhysicalEnd)) other.DepartureEnd=RunwayDefaults.Copy(position);
                end.PhysicalEnd=position; break;
            case 1: end.Threshold=position; break;
            case 2: end.DepartureEnd=position; break;
        }
    }
}
