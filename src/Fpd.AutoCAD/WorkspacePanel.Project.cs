using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Fpd.Core;
using Fpd.AutoCAD.Views;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private ProjectWorkspaceViewModel _projectViewModel=null!;
    private ProjectWorkspaceView _projectView=null!;
    private long _projectSelectionVersion;
    internal event Action<Action>? ProjectHighlightRequested;
    private ProjectDataCategory SelectedCategory=>_projectViewModel.SelectedCategory.Kind;
    private IReadOnlySet<string> SelectedDataIds=>_projectViewModel.SelectedDataIds;
    private bool IsObstacle=>SelectedCategory==ProjectDataCategory.Obstacle;
    private bool IsAirportData=>SelectedCategory is ProjectDataCategory.Runway or ProjectDataCategory.Navaid;
    private bool IsRunway=>SelectedCategory==ProjectDataCategory.Runway;
    private TabPage ProjectPage()
    {
        var page=Page("项目"); page.Padding=Padding.Empty;
        _projectViewModel=new ProjectWorkspaceViewModel(action=>Run(()=>ProjectAction(action)));
        _projectView=new ProjectWorkspaceView(_projectViewModel);
        _projectView.DataSelectionChanged+=()=>Run(()=>HighlightSelectedProjectData(false));
        _projectView.DataActivated+=()=>Run(()=> { if(IsAirportData) EditPoint(true); else HighlightSelectedProjectData(true); });
        page.Controls.Add(new ElementHost { Dock=DockStyle.Fill,Child=_projectView });
        _projectView.BindProject(_project,_initialized,_editable,true);
        return page;
    }
    private void ProjectAction(ProjectUiAction action)
    {
        switch(action)
        {
            case ProjectUiAction.Create: CreateProjectFromSetup(); break;
            case ProjectUiAction.EditProject: EditAirport(); break;
            case ProjectUiAction.ConvertCoordinates: OpenCoordinateTool(); break;
            case ProjectUiAction.Add: EditPoint(false); break;
            case ProjectUiAction.Edit: EditPoint(true); break;
            case ProjectUiAction.Delete: DeletePoints(); break;
            case ProjectUiAction.Import: ImportPoints(); break;
            case ProjectUiAction.Export: RequireProject(); ExportCurrentData(); break;
        }
    }
    private void RefreshSummary()=>_projectViewModel.UpdateSummary();
    private void RefreshData()=>_projectViewModel.RefreshRows();
    private void CreateProjectFromSetup()
    {
        if(!_editable || _initialized || !DwgProjects.IsCurrent(_project)) throw new InvalidOperationException("当前图纸无法设置项目。");
        var airport=new AirportData { Name=_projectViewModel.DraftAirportName.Trim(),ArpLatitude=CoordinateInput.Parse(_projectViewModel.DraftArpLatitude,true),ArpLongitude=CoordinateInput.Parse(_projectViewModel.DraftArpLongitude,false) };
        if(string.IsNullOrWhiteSpace(airport.Name)) throw new InvalidDataException("机场名称不能为空。");
        var project=ProjectStore.Create(_projectViewModel.DraftProjectName.Trim(),airport); ProjectValidation.Project(project);
        DwgProjects.Initialize(project); SetStatus("项目资料已设置");
    }
    private List<T> SelectedBasics<T>()=>CurrentValues().OfType<T>().Where(value=>SelectedDataIds.Contains(DataKey(value!))).ToList();
    private List<FixData> SelectedFixes()=>_project.Fixes.Where(value=>SelectedDataIds.Contains(value.DataId)).ToList();
    private List<ObstacleData> SelectedObstacles()=>_project.Obstacles.Where(value=>SelectedDataIds.Contains(value.DataId)).ToList();
    private void HighlightSelectedProjectData(bool zoom)
    {
        var version=++_projectSelectionVersion;
        if(!_initialized || !DwgProjects.IsCurrent(_project) || _tabs.SelectedIndex!=0) return;
        var project=_project; var category=SelectedCategory;
        var key=SelectedDataIds.Count==1?SelectedDataIds.Single():null;
        ProjectHighlightRequested?.Invoke(()=>
        {
            if(version!=_projectSelectionVersion || !ReferenceEquals(project,_project) ||
                !DwgProjects.IsCurrent(project) || SelectedCategory!=category || _tabs.SelectedIndex!=0 ||
                (key is not null && (SelectedDataIds.Count!=1 || !SelectedDataIds.Contains(key)))) return;
            if(key is null) Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument?.Editor.SetImpliedSelection([]);
            else CadDrawing.HighlightBasePoint(project,category.ToString(),key,zoom);
        });
    }
    private void ExportCurrentData() { if(IsAirportData) ExportAirport(IsRunway); else Export(IsObstacle); }
    private void EditPoint(bool edit)
    {
        RequireProject();
        if(IsAirportData) { EditAirportData(edit); return; }
        if(edit && SelectedDataIds.Count!=1) throw new InvalidOperationException("请选择一行数据。");
        if(IsObstacle) EditObstacle(edit?SelectedObstacles().Single():null); else EditFix(edit?SelectedFixes().Single():null);
    }
    private void OpenCoordinateTool()=>ShowCoordinateTool(null);
    private void ShowCoordinateTool(string[]? inputs)
    {
        RequireProject(); using var dialog=new CoordinateDialog(_project,inputs);
        if(dialog.ShowDialog(this)!=DialogResult.Retry) return;
        var values=dialog.Inputs;
        CadOperation(()=>
        {
            var point=CadDrawing.PickWcsPoint();
            if(point is { } p)
            {
                var geo=Cgcs2000Projection.InverseInZone(p.X,p.Y,AirportGeometry.Meridian(_project),p.Z);
                values=[DataEditor.Format(geo.Latitude),DataEditor.Format(geo.Longitude),DataEditor.Format(p.X),DataEditor.Format(p.Y),DataEditor.Format(p.Z)];
            }
            ShowCoordinateTool(values);
        });
    }
    private void EditFix(FixData? previous,FixData? draft=null)
    {
        using var dialog=new FixDialog(draft??previous); var result=dialog.ShowDialog(this);
        if(result==DialogResult.Retry)
        {
            var value=dialog.Value;
            CadOperation(()=> { var p=CadDrawing.PickPosition(_project); if(p is not null) { value.Latitude=p.Latitude; value.Longitude=p.Longitude; } EditFix(previous,value); }); return;
        }
        if(result!=DialogResult.OK) return;
        ProjectEdits.ReplaceFix(_project,previous,dialog.Value); ProjectDataIds.Ensure(_project);
        BaseDataChanged("Fix",[dialog.Value]); RefreshData(); RefreshProcedures(); RefreshToolChoices();
    }
    private void EditObstacle(ObstacleData? previous,ObstacleData? draft=null)
    {
        using var dialog=new ObstacleDialog(draft??previous); var result=dialog.ShowDialog(this);
        if(result==DialogResult.Retry)
        {
            var value=dialog.Value;
            CadOperation(()=> { var p=CadDrawing.PickPosition(_project); if(p is not null) { value.Latitude=p.Latitude; value.Longitude=p.Longitude; value.TopElevation=p.Elevation??value.TopElevation; } EditObstacle(previous,value); }); return;
        }
        if(result!=DialogResult.OK) return;
        var value2=dialog.Value; ProjectDataIds.Ensure(_project); if(previous is not null) value2.DataId=previous.DataId;
        if(_project.Obstacles.Any(o=>o!=previous && o.Ident.Equals(value2.Ident,StringComparison.OrdinalIgnoreCase))) throw new InvalidDataException("障碍物编号重复。");
        if(previous is null) _project.Obstacles.Add(value2); else _project.Obstacles[_project.Obstacles.IndexOf(previous)]=value2;
        BaseDataChanged("Obstacle",[value2]); RefreshData();
    }
    private void DeletePoints()
    {
        RequireProject();
        var count=SelectedDataIds.Count; if(count==0) throw new InvalidOperationException("未选择数据。");
        var ids=SelectedFixes().Select(f=>f.Ident).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var referenced=!IsObstacle && _project.Procedures.Any(p=>p.Paths.Any(path=>path.Fixes.Any(f=>ids.Contains(f.FixIdent))) || p.FixIdents.Any(ids.Contains) || p.Sections.Any(s=>s.FixIdents.Any(ids.Contains)));
        var prompt=referenced?"删除所选数据并移除程序引用？":"删除所选数据？";
        if(MessageBox.Show(this,prompt,"删除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!=DialogResult.OK) return;
        DeleteSelectedProjectData();
    }

    private void DeleteSelectedProjectData()
    {
        var project=_project;
        var kind=SelectedCategory.ToString();
        var keys=SelectedDataIds.ToHashSet(StringComparer.OrdinalIgnoreCase);
        CadOperation(()=> { DwgProjects.DeleteBaseData(project,kind,keys); SetStatus("已删除所选数据"); });
    }

    private void ImportPoints()
    {
        RequireProject();
        using var form=new Form { Text="导入"+_projectViewModel.SelectedCategory.Label,ClientSize=new Size(470,145),StartPosition=FormStartPosition.CenterParent,FormBorderStyle=FormBorderStyle.FixedDialog,MinimizeBox=false,MaximizeBox=false,Font=Font,BackColor=Color.FromArgb(37,37,37),ForeColor=Color.Gainsboro };
        var file=Input();
        var browse=Button("选择文件",()=> { using var open=new OpenFileDialog { Filter="CSV|*.csv" }; if(open.ShowDialog(form)==DialogResult.OK) file.Text=open.FileName; });
        var choose=new FlowLayoutPanel { Dock=DockStyle.Top,Height=38,WrapContents=false }; choose.Controls.Add(file); choose.Controls.Add(browse);
        var download=Button("下载模板",()=> { using var save=new SaveFileDialog { Filter="CSV|*.csv",FileName=_projectViewModel.SelectedCategory.Label+"_模板.csv" }; if(save.ShowDialog(form)==DialogResult.OK) { File.WriteAllText(save.FileName,TemplateText(),new UTF8Encoding(true)); SetStatus("模板已保存"); } });
        var cancel=new Button { Text="取消",AutoSize=true,DialogResult=DialogResult.Cancel };
        var import=Button("导入",()=> { if(string.IsNullOrWhiteSpace(file.Text)) throw new InvalidOperationException("请选择文件。"); AddPointText(File.ReadAllText(file.Text)); form.DialogResult=DialogResult.OK; });
        var buttons=Bar(download,import,cancel); buttons.Dock=DockStyle.Bottom; buttons.Height=38;
        form.Controls.Add(buttons); form.Controls.Add(choose); form.AcceptButton=import; form.CancelButton=cancel; form.ShowDialog(this);
    }
    private string TemplateText() => SelectedCategory switch { ProjectDataCategory.Obstacle=>ObstacleCsv.Export([]),ProjectDataCategory.Runway=>RunwayCsv.Export([]),ProjectDataCategory.Navaid=>NavaidCsv.Export([]),_=>FixCsv.Export([]) };
    private void AddPointText(string text)
    {
        RequireProject(); IReadOnlyList<object> batch;
        if(IsAirportData) { AddAirportText(text); return; }
        if(IsObstacle) { var rows=ObstacleCsv.ParseText(text,_project.Obstacles.Select(o=>o.Ident)); _project.Obstacles.AddRange(rows); batch=rows; }
        else { var rows=FixCsv.ParseText(text,_project.Fixes.Select(f=>f.Ident)); _project.Fixes.AddRange(rows); batch=rows; }
        BaseDataChanged(IsObstacle?"Obstacle":"Fix",batch); RefreshData(); RefreshProcedures(); RefreshToolChoices();
    }
    private IEnumerable<object> CurrentValues()=>SelectedCategory switch { ProjectDataCategory.Obstacle=>_project.Obstacles,ProjectDataCategory.Runway=>_project.Runways,ProjectDataCategory.Navaid=>_project.Navaids,_=>_project.Fixes };
    private static string DataKey(object value)=>value switch { FixData f=>f.DataId,ObstacleData o=>o.DataId,RunwayData r=>r.DataId,NavaidData n=>n.DataId,_=>throw new ArgumentException() };
    internal void DrawSelectedFixCommand()
    {
        RequireProject(); ProjectDataIds.Ensure(_project); var selected=SelectedFixes();
        if(selected.Count!=1) throw new InvalidOperationException("请在项目页选择一个定位点。");
        SetStatus(CadDrawing.SyncBaseMap(_project,"Fix",selected.Select(f=>f.DataId).ToHashSet()));
    }
    internal void DrawCurrentAllCommand() { RequireProject(); SetStatus(CadDrawing.SyncBaseMap(_project)); }
}
