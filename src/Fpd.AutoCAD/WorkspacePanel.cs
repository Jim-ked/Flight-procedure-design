using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel : UserControl
{
    private readonly ProjectStore _store = new();
    private readonly Func<string?> _drawingPath;
    private ProjectData _project = ProjectStore.Create("未命名项目", new AirportData());
    private string _currentPath = "";
    private bool _dirty, _refreshing;
    private readonly TabControl _tabs = new() { Dock = DockStyle.Fill, Appearance = TabAppearance.FlatButtons, ItemSize = new Size(78, 31), SizeMode = TabSizeMode.Fixed };
    private readonly Label _status = new() { Height = 27, Dock = DockStyle.Bottom, AutoEllipsis = true, TextAlign = ContentAlignment.MiddleLeft, BackColor = Color.FromArgb(37,37,37), ForeColor = Color.Gainsboro };
    private readonly ToolTip _tips = new();
    internal event Action<DrawRequest>? DrawRequested;
    internal event Action<string, bool>? LayerRequested;
    internal event Action? ViewRequested;
    public ProjectData Project => _project;

    public WorkspacePanel(Func<string?> drawingPath)
    {
        SuspendLayout(); _drawingPath = drawingPath;
        Dock = DockStyle.Fill; AutoScaleMode = AutoScaleMode.Dpi; AutoScaleDimensions = new SizeF(96,96);
        Font = new Font("Microsoft YaHei UI",9); BackColor = Color.FromArgb(37,37,37); ForeColor = Color.Gainsboro;
        _tabs.TabPages.Add(ProjectPage()); _tabs.TabPages.Add(ProcedurePage()); _tabs.TabPages.Add(ToolsPage()); _tabs.TabPages.Add(ResultsPage());
        _tabs.SelectedIndexChanged += (_,_) => Run(() => { if (_tabs.SelectedIndex == 3) RefreshResults(); if (_tabs.SelectedIndex == 2) RefreshToolChoices(); });
        Controls.Add(_tabs); Controls.Add(_status); RefreshProject(); ResumeLayout(true);
    }
    private TabPage Page(string title) => new(title) { BackColor = BackColor, ForeColor = ForeColor, Padding = new Padding(6), UseVisualStyleBackColor = false };
    private static TableLayoutPanel Stack() { var g = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, Margin = Padding.Empty }; g.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100)); return g; }
    private static void Row(TableLayoutPanel g, Control c, float height, bool fill = false) { var r=g.RowCount++; g.RowStyles.Add(new RowStyle(fill ? SizeType.Percent : SizeType.Absolute,height)); c.Dock=DockStyle.Fill; g.Controls.Add(c,0,r); }
    private Button Button(string text, Action action)
    {
        var b=new Button { Text=text, AutoSize=true, MinimumSize=new Size(48,27), FlatStyle=FlatStyle.Flat, BackColor=Color.FromArgb(57,57,57), ForeColor=Color.White, Margin=new Padding(2), Padding=new Padding(2,0,2,0) };
        b.FlatAppearance.BorderColor=Color.FromArgb(85,85,85); b.Click+=(_,_)=>Run(action); return b;
    }
    private static FlowLayoutPanel Bar(params Control[] controls) { var p=new FlowLayoutPanel { Dock=DockStyle.Fill, WrapContents=false, Margin=Padding.Empty }; p.Controls.AddRange(controls); return p; }
    private static Label Caption(string text) => new() { Text=text, TextAlign=ContentAlignment.MiddleLeft, AutoEllipsis=true, Dock=DockStyle.Fill };
    private static TextBox Input() => new() { Dock=DockStyle.Fill, BackColor=Color.FromArgb(55,55,55), ForeColor=Color.White, BorderStyle=BorderStyle.FixedSingle };
    private static ListBox List() => new() { Dock=DockStyle.Fill, IntegralHeight=false, BackColor=Color.FromArgb(45,45,45), ForeColor=Color.Gainsboro, HorizontalScrollbar=true };
    private static TableLayoutPanel FormGrid() { var g=new TableLayoutPanel { Dock=DockStyle.Fill, ColumnCount=2 }; g.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,76)); g.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100)); return g; }
    private static void Field(TableLayoutPanel g,string title,Control c) { var r=g.RowCount++; g.RowStyles.Add(new RowStyle(SizeType.Absolute,30)); g.Controls.Add(Caption(title),0,r); g.Controls.Add(c,1,r); }
    private void Run(Action action) { try { action(); } catch(Exception ex) { SetStatus(ex.Message); MessageBox.Show(this,ex.Message,"FPD",MessageBoxButtons.OK,MessageBoxIcon.Warning); } }
    public void SetStatus(string message) { _status.Text="  "+message; _tips.SetToolTip(_status,message); }
    private void Changed() { _dirty=true; RefreshSummary(); }
    private void RefreshProject()
    {
        RefreshSummary(); RefreshData(); RefreshProcedures(); RefreshToolChoices();
        SetStatus($"Fix {_project.Fixes.Count} · 障碍物 {_project.Obstacles.Count} · 程序 {_project.Procedures.Count}");
    }
    private bool ConfirmReplacement()
    {
        if (!_dirty) return true;
        var choice=MessageBox.Show(this,"当前项目有未保存修改，是否先保存？","FPD",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
        return choice==DialogResult.No || choice==DialogResult.Yes && SaveProject();
    }
    private void NewProject()
    {
        if(!ConfirmReplacement()) return;
        using var dialog=new AirportDialog(ProjectStore.Create("新建项目",new AirportData()));
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        _project=ProjectStore.Create(dialog.ProjectName,dialog.Airport); _currentPath=""; _dirty=true; RefreshProject();
    }
    private void EditAirport()
    {
        using var dialog=new AirportDialog(_project);
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        _project.Name=dialog.ProjectName; _project.Airport=dialog.Airport; Changed();
        _coordinateOutput.Text="机场资料已更新，请重新转换或绘制。";
    }
    private void OpenProject()
    {
        if(!ConfirmReplacement()) return;
        using var dialog=new OpenFileDialog { Filter="FPD 项目|*.fpd.json|JSON|*.json", Title="打开 FPD 项目" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        var opened=_store.Open(dialog.FileName); _project=opened; _currentPath=dialog.FileName; _dirty=false; RefreshProject();
    }
    private bool SaveProject()
    {
        ProjectValidation.Project(_project);
        var path=_currentPath;
        if(string.IsNullOrWhiteSpace(path))
        {
            using var dialog=new SaveFileDialog { Filter="FPD 项目|*.fpd.json", FileName=_project.Name+".fpd.json", Title="保存 FPD 项目" };
            if(dialog.ShowDialog(this)!=DialogResult.OK) return false;
            path=dialog.FileName;
        }
        _store.Save(_project,path); _currentPath=path; _dirty=false; SetStatus("已保存："+Path.GetFileName(path)); return true;
    }
    public void SetDwgPath(string? path)
    {
        if(string.IsNullOrWhiteSpace(path)) throw new InvalidOperationException("请先打开 DWG。");
        if(_project.DwgPath!=path) { _project.DwgPath=path; Changed(); }
    }
    public (FixData Fix,ProjectedPoint Point) GetSelectedPoint()
    {
        var selected=SelectedFixes();
        if(selected.Count!=1) throw new InvalidOperationException("FPDPOINT 需要明确选中一个 Fix；ARP 请使用“绘制 ARP”。");
        return (selected[0],PointProjection.Fixes(_project,selected)[0].Point);
    }
    private double TextHeight => (double)_textHeight.Value;
    private void Draw(IReadOnlyList<PlotPoint> points) => DrawRequested?.Invoke(new(points,TextHeight,_showTop.Checked));
    protected override void Dispose(bool disposing) { if(disposing) _tips.Dispose(); base.Dispose(disposing); }
}
