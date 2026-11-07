using System.Drawing;
using System.Windows.Forms;
using Fpd.Core;
namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private Button MenuButton(string title,params (string Title,Action Action)[] actions)
    {
        var menu=new ContextMenuStrip(); foreach(var action in actions) menu.Items.Add(action.Title,null,(_,_)=>Run(action.Action));
        var button=Button(title+" ▾",()=>{}); button.Click+=(_,_)=>menu.Show(button,new Point(0,button.Height)); button.Disposed+=(_,_)=>menu.Dispose(); return button;
    }
    private string? PromptText(string title,string label,string initial="")
    {
        using var form=new Form { Text=title,AutoScaleDimensions=new SizeF(96,96),AutoScaleMode=AutoScaleMode.Dpi,ClientSize=new Size(360,110),StartPosition=FormStartPosition.CenterParent,FormBorderStyle=FormBorderStyle.FixedDialog,MinimizeBox=false,MaximizeBox=false,Font=Font,BackColor=Color.FromArgb(37,37,37),ForeColor=Color.Gainsboro };
        var text=Input(); text.Text=initial; var fields=FormGrid(); fields.Dock=DockStyle.Top; fields.Height=36; Field(fields,label,text);
        var ok=new Button { Text="确定",DialogResult=DialogResult.OK }; var cancel=new Button { Text="取消",DialogResult=DialogResult.Cancel }; var bar=Bar(ok,cancel); bar.Dock=DockStyle.Bottom; bar.Height=36;
        form.Controls.Add(fields); form.Controls.Add(bar); form.AcceptButton=ok; form.CancelButton=cancel; form.Shown+=(_,_)=> { text.Focus(); text.SelectAll(); };
        if(form.ShowDialog(this)!=DialogResult.OK) return null;
        if(string.IsNullOrWhiteSpace(text.Text)) throw new InvalidOperationException(label+"不能为空。"); return text.Text.Trim();
    }
}

internal sealed class FixOrderDialog:Form
{
    private readonly ListBox _available=new() { Dock=DockStyle.Fill,IntegralHeight=false },_ordered=new() { Dock=DockStyle.Fill,IntegralHeight=false };
    public IReadOnlyList<string> Identifiers=>_ordered.Items.Cast<string>().ToArray();
    public FixOrderDialog(IReadOnlyList<FixData> fixes)
    {
        Text="依次选择定位点（允许重复）"; AutoScaleDimensions=new SizeF(96,96); AutoScaleMode=AutoScaleMode.Dpi; ClientSize=new Size(420,400); MinimumSize=new Size(340,320); StartPosition=FormStartPosition.CenterParent; Font=new Font("Microsoft YaHei UI",9);
        var grid=new TableLayoutPanel { Dock=DockStyle.Fill,ColumnCount=2,RowCount=3 }; grid.ColumnStyles.Add(new(SizeType.Percent,50)); grid.ColumnStyles.Add(new(SizeType.Percent,50)); grid.RowStyles.Add(new(SizeType.Absolute,30)); grid.RowStyles.Add(new(SizeType.Percent,100)); grid.RowStyles.Add(new(SizeType.Absolute,34));
        var search=new TextBox { Dock=DockStyle.Fill,PlaceholderText="查找标识" }; grid.Controls.Add(search,0,0); grid.Controls.Add(new Label { Text="本轮顺序",Dock=DockStyle.Fill },1,0); grid.Controls.Add(_available,0,1); grid.Controls.Add(_ordered,1,1);
        void Filter() { _available.Items.Clear(); _available.Items.AddRange(fixes.Where(f=>f.Ident.Contains(search.Text,StringComparison.OrdinalIgnoreCase)).Select(f=>f.Ident).ToArray()); }
        search.TextChanged+=(_,_)=>Filter(); Filter();
        var add=new Button { Text="加入 →",Dock=DockStyle.Fill }; add.Click+=(_,_)=> { if(_available.SelectedItem is string id) _ordered.Items.Add(id); }; _available.DoubleClick+=(_,_)=>add.PerformClick(); grid.Controls.Add(add,0,2);
        var bar=new FlowLayoutPanel { Dock=DockStyle.Fill,WrapContents=false }; var ok=new Button { Text="确定",DialogResult=DialogResult.OK,Width=65 }; var cancel=new Button { Text="取消",DialogResult=DialogResult.Cancel,Width=65 }; bar.Controls.AddRange([ok,cancel]); grid.Controls.Add(bar,1,2); Controls.Add(grid); AcceptButton=ok; CancelButton=cancel;
    }
}
