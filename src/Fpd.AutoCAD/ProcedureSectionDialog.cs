using System.Drawing;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

internal sealed class ProcedureSectionDialog : Form
{
    public ProcedureSection Value { get; private set; } = new();
    public ProcedureSectionDialog(ProcedureData procedure,IEnumerable<RunwayData> runways,ProcedureSection? previous)
    {
        SuspendLayout(); Text="程序阶段 / 分支"; ClientSize=new(400,215); AutoScaleMode=AutoScaleMode.Dpi; AutoScaleDimensions=new(96,96); Font=new("Microsoft YaHei UI",9);
        BackColor=Color.FromArgb(37,37,37); ForeColor=Color.Gainsboro; StartPosition=FormStartPosition.CenterScreen; FormBorderStyle=FormBorderStyle.FixedDialog; MinimizeBox=false; MaximizeBox=false;
        var grid=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=2,Padding=new(8) }; grid.ColumnStyles.Add(new(SizeType.Absolute,100)); grid.ColumnStyles.Add(new(SizeType.Percent,100));
        void Field(string text,Control control) { var row=grid.RowCount++; grid.RowStyles.Add(new(SizeType.Absolute,32)); grid.Controls.Add(new Label { Text=text,Dock=DockStyle.Fill,TextAlign=ContentAlignment.MiddleLeft },0,row); control.Dock=DockStyle.Fill; control.BackColor=Color.FromArgb(55,55,55); control.ForeColor=Color.White; grid.Controls.Add(control,1,row); }
        var name=new TextBox { Text=previous?.Name??"" }; var stage=new ComboBox { DropDownStyle=ComboBoxStyle.DropDownList }; stage.Items.AddRange(Enum.GetNames<ProcedureStage>()); stage.SelectedIndex=(int)(previous?.Stage??ProcedureStage.Main);
        var branch=new ComboBox { DropDownStyle=ComboBoxStyle.DropDownList }; branch.Items.AddRange(Enum.GetNames<ProcedureBranch>()); branch.SelectedIndex=(int)(previous?.Branch??ProcedureBranch.Common);
        var runway=new ComboBox { DropDownStyle=ComboBoxStyle.DropDown }; runway.Items.AddRange(runways.SelectMany(r=>new[] { r.EndA.Designator,r.EndB.Designator }).ToArray()); runway.Text=previous?.Runway??procedure.Runway??"";
        Field("段名称",name); Field("阶段",stage); Field("分支",branch); Field("跑道端",runway);
        var buttons=new FlowLayoutPanel { Dock=DockStyle.Fill,FlowDirection=FlowDirection.RightToLeft }; var ok=new Button { Text="确定",AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat }; ok.Click+=(_,_)=> { if(string.IsNullOrWhiteSpace(name.Text)) { MessageBox.Show(this,"段名称不能为空。"); return; } if(stage.SelectedIndex==1 && procedure.Kind is not (ProcedureKind.Approach or ProcedureKind.Missed)) { MessageBox.Show(this,"Missed仅属于Approach或复飞程序。"); return; }
            Value=new() { Name=name.Text.Trim(),Stage=(ProcedureStage)stage.SelectedIndex,Branch=(ProcedureBranch)branch.SelectedIndex,Runway=string.IsNullOrWhiteSpace(runway.Text)?null:runway.Text.Trim(),FixIdents=previous?.FixIdents.ToList()??[] }; DialogResult=DialogResult.OK; };
        var cancel=new Button { Text="取消",AutoSize=true,MinimumSize=new Size(70,28),BackColor=Color.FromArgb(57,57,57),ForeColor=Color.White,FlatStyle=FlatStyle.Flat,DialogResult=DialogResult.Cancel }; buttons.Controls.Add(ok); buttons.Controls.Add(cancel); var row=grid.RowCount++; grid.RowStyles.Add(new(SizeType.Absolute,36)); grid.Controls.Add(buttons,0,row); grid.SetColumnSpan(buttons,2); Controls.Add(grid); AcceptButton=ok; CancelButton=cancel; ResumeLayout(true);
    }
}
