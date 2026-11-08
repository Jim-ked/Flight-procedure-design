using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Fpd.Core;
using Autodesk.AutoCAD.ApplicationServices;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel : UserControl
{
    private readonly Func<string?> _drawingPath;
    private ProjectData _project = ProjectStore.Create("未命名项目", new AirportData());
    private bool _initialized, _editable;
    private bool _dirty, _refreshing;
    private readonly TabControl _tabs = new() { Dock = DockStyle.Fill, Appearance = TabAppearance.FlatButtons, ItemSize = new Size(78, 31), SizeMode = TabSizeMode.Fixed };
    private readonly Label _status = new() { Height = 27, Dock = DockStyle.Bottom, AutoEllipsis = true, TextAlign = ContentAlignment.MiddleLeft, BackColor = Color.FromArgb(37,37,37), ForeColor = Color.Gainsboro };
    private readonly ToolTip _tips = new();
    internal event Action? ViewRequested;
    public ProjectData Project => _project;

    public WorkspacePanel(Func<string?> drawingPath)
    {
        SuspendLayout(); _drawingPath = drawingPath;
        Dock = DockStyle.Fill; AutoScaleMode = AutoScaleMode.Dpi; AutoScaleDimensions = new SizeF(96,96);
        Font = new Font("Microsoft YaHei UI",9); BackColor = Color.FromArgb(37,37,37); ForeColor = Color.Gainsboro;
        _tabs.TabPages.Add(ProjectPage()); _tabs.TabPages.Add(ProcedurePage()); _tabs.TabPages.Add(ToolsPage()); _tabs.TabPages.Add(ResultsPage());
        _tabs.SelectedIndexChanged += (_,_) => Run(() => { if (_tabs.SelectedIndex == 3) RefreshResults(); if (_tabs.SelectedIndex == 2) RefreshToolChoices(); ApplyPageLayers(); });
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
    private void Changed() { RequireProject(); DwgProjects.Changed(_project); _dirty=true; RefreshSummary(); }
    private void RefreshProject()
    {
        RefreshSummary(); RefreshData(); RefreshProcedures(); RefreshToolChoices();
        UpdateProjectVisibility();
        SetStatus("就绪");
    }
    internal void BindProject(ProjectData project,bool initialized,bool editable,bool dirty=false)
    {
        var changedProject=!ReferenceEquals(_project,project);
        _project=project; _initialized=initialized; _editable=editable; _dirty=dirty;
        if(changedProject) { _setupProjectName.Clear(); _setupAirportName.Clear(); _setupLatitude.Clear(); _setupLongitude.Clear(); }
        _refreshing=true;
        try { _search.Clear(); RefreshProject(); ResetCoordinates(); }
        finally { _refreshing=false; }
        ApplyPageLayers();
    }
    internal void SavedProject(string path) { _dirty=false; RefreshSummary(); SetStatus("DWG及项目资料已保存："+Path.GetFileName(path)); }
    private void RequireProject()
    {
        if(!_initialized || !_editable || !DwgProjects.IsCurrent(_project)) throw new InvalidOperationException("请先在当前DWG创建项目；读取失败时不能覆盖原资料。");
    }
    private void NewProject()
    {
        if(!_editable) throw new InvalidOperationException("请先打开DWG；资料读取失败时不能覆盖原文件。");
        if(_initialized) throw new InvalidOperationException("当前DWG已有项目。请修改项目，或使用AutoCAD新建另一张DWG。");
        EditProject(ProjectStore.Create("新建项目",new AirportData()),true);
    }
    private void EditAirport() { RequireProject(); EditProject(_project,false); }
    private void EditProject(ProjectData draft,bool create)
    {
        using var dialog=new AirportDialog(draft); var result=dialog.ShowDialog(this);
        if(result==DialogResult.Retry)
        {
            var value=ProjectStore.Create(dialog.ProjectName,dialog.Airport);
            // ARP picking can initialize the projection before the project exists.
            AirportCommandRequested?.Invoke(()=>
            {
                var p=CadDrawing.PickPosition(value);
                if(p is not null) { value.Airport.ArpLatitude=p.Latitude; value.Airport.ArpLongitude=p.Longitude; }
                EditProject(value,create);
            }); return;
        }
        if(result!=DialogResult.OK) return;
        if(create) DwgProjects.Initialize(ProjectStore.Create(dialog.ProjectName,dialog.Airport));
        else { _project.Name=dialog.ProjectName; _project.Airport=dialog.Airport; Changed(); }
        _dirty=true; RefreshSummary(); ResetCoordinates(); RefreshData();
        SetStatus("项目资料已更新");
    }
    private void BaseDataChanged(string kind,IEnumerable<object> values)
    {
        ProjectDataIds.Ensure(_project);
        var keys=values.Select(DataKey).ToHashSet(StringComparer.OrdinalIgnoreCase);
        Changed();
        if(keys.Count>0) QueueBaseMap(kind,keys);
    }
    private void QueueBaseMap(string? kind=null,IReadOnlySet<string>? keys=null)
    {
        RequireProject();
        if(!_project.Airport.ArpLongitude.HasValue) return;
        var project=_project;
        CadOperation(()=>SetStatus(CadDrawing.SyncBaseMap(project,kind,keys)));
    }
    private void ApplyPageLayers()
    {
        if(Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument is null) return;
        CadDrawing.ShowProjectLayers(_tabs.SelectedIndex!=1);
    }
    private double TextHeight => (double)_textHeight.Value;
    private void UpdateProjectVisibility()
    {
        if(_projectDataArea is null || _setupPrompt is null || _projectContent is null) return;
        _projectDataArea.Visible=_initialized;
        _setupPrompt.Visible=!_initialized;
        if(_editProjectButton is not null) _editProjectButton.Visible=_initialized;
        if(_coordinateButton is not null) _coordinateButton.Visible=_initialized;
        if(_projectHeader is not null) _projectHeader.Visible=_initialized;
        if(_setupConfirm is not null) _setupConfirm.Enabled=_editable && !_initialized;
        if(_projectLayout is not null) _projectLayout.RowStyles[0].SizeType=_initialized?SizeType.AutoSize:SizeType.Absolute;
        if(_projectLayout is not null && !_initialized) _projectLayout.RowStyles[0].Height=0;
        var content=_initialized?_projectDataArea:_setupPrompt;
        if(_projectContent.Controls.Count!=1 || _projectContent.Controls[0]!=content)
        {
            _projectContent.Controls.Clear(); _projectContent.Controls.Add(content);
        }
    }
    protected override void Dispose(bool disposing) { if(disposing) _tips.Dispose(); base.Dispose(disposing); }
}
