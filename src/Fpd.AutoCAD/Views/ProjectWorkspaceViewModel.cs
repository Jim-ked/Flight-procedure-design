using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Fpd.Core;

namespace Fpd.AutoCAD.Views;

internal enum ProjectDataCategory { Fix, Obstacle, Runway, Navaid }
internal enum ProjectUiAction { Create, EditProject, Add, Edit, Delete, Import, Export }
internal sealed record ProjectCategory(ProjectDataCategory Kind,string Label);

// Presentation values only; all edits resolve current business objects by DataId in WorkspacePanel.
internal sealed record ProjectRow(string DataId,string Name,double? Latitude=null,double? Longitude=null,
    double? TopElevation=null,double? GroundElevation=null,double? Width=null,string? Kind=null)
{
    public static ProjectRow From(object value)=>value switch
    {
        FixData f=>new(f.DataId,f.Ident,f.Latitude,f.Longitude),
        ObstacleData o=>new(o.DataId,o.Ident,o.Latitude,o.Longitude,o.TopElevation,o.GroundElevation),
        RunwayData r=>new(r.DataId,r.EndA.Designator+" / "+r.EndB.Designator,Width:r.Width),
        NavaidData n=>new(n.DataId,n.Ident,n.Position.Latitude,n.Position.Longitude,Kind:n.Kind.ToString()),
        _=>throw new ArgumentException("未知资料类别。")
    };
}

internal sealed class ProjectWorkspaceViewModel : INotifyPropertyChanged
{
    private ProjectData? _project;
    private bool _initialized,_editable;
    private readonly Dispatcher _dispatcher=Dispatcher.CurrentDispatcher;
    private ProjectRow[] _rows=[];
    private readonly HashSet<string> _selectedDataIds=new(StringComparer.OrdinalIgnoreCase);
    private readonly List<ProjectCommand> _commands=[];
    private ProjectCategory _selectedCategory;
    private string _searchText="";
    public event PropertyChangedEventHandler? PropertyChanged;
    public event Action? RowsRefreshing;
    public event Action? RowsRefreshed;
    public IReadOnlyList<ProjectCategory> Categories { get; }=
    [
        new(ProjectDataCategory.Fix,"定位点"),new(ProjectDataCategory.Obstacle,"障碍物"),
        new(ProjectDataCategory.Runway,"跑道"),new(ProjectDataCategory.Navaid,"导航台")
    ];
    public ProjectWorkspaceViewModel(Action<ProjectUiAction> execute)
    {
        _selectedCategory=Categories[0];
        VisibleRows=CreateRowsView(_rows);
        CreateProjectCommand=Command(ProjectUiAction.Create,()=>_editable && !_initialized);
        EditProjectCommand=Command(ProjectUiAction.EditProject,Ready);
        AddCommand=Command(ProjectUiAction.Add,Ready);
        EditCommand=Command(ProjectUiAction.Edit,()=>Ready() && _selectedDataIds.Count==1);
        DeleteCommand=Command(ProjectUiAction.Delete,()=>Ready() && _selectedDataIds.Count>0);
        ImportCommand=Command(ProjectUiAction.Import,Ready);
        ExportCommand=Command(ProjectUiAction.Export,Ready);
        ProjectCommand Command(ProjectUiAction action,Func<bool> canExecute)
        {
            var command=new ProjectCommand(()=>execute(action),canExecute); _commands.Add(command); return command;
        }
    }
    public bool IsInitialized=>_initialized;
    public string ProjectName=>_initialized?_project?.Name??"":"";
    public string AirportName=>_initialized?_project?.Airport.Name??"":"";
    public string ArpDisplay=>_project?.Airport is { ArpLatitude:double lat,ArpLongitude:double lon }
        ?$"ARP {Angle(lat,true)} / {Angle(lon,false)}":"ARP 未设置";
    public string DraftProjectName { get; set; }="";
    public string DraftAirportName { get; set; }="";
    public string DraftArpLatitude { get; set; }="";
    public string DraftArpLongitude { get; set; }="";
    public ICollectionView VisibleRows { get; private set; }
    public IReadOnlySet<string> SelectedDataIds=>_selectedDataIds;
    public string CountDisplay=>$"共 {_rows.Length} 项 / 已选 {_selectedDataIds.Count} 项";
    public ProjectCategory SelectedCategory
    {
        get=>_selectedCategory;
        set
        {
            if(value is null || value==_selectedCategory) return;
            ChangeRows(()=> { _selectedCategory=value; Notify(nameof(SelectedCategory)); LoadRows(); });
        }
    }
    public string SearchText
    {
        get=>_searchText;
        set
        {
            value??="";
            if(value==_searchText) return;
            ChangeRows(()=>
            {
                _searchText=value; Notify(nameof(SearchText));
                // Filtering does not rebuild the immutable row snapshot or replace
                // DataGrid.ItemsSource. Refresh is synchronous, never deferred.
                VisibleRows.Refresh();
            });
        }
    }
    public ICommand CreateProjectCommand { get; }
    public ICommand EditProjectCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand ImportCommand { get; }
    public ICommand ExportCommand { get; }
    private bool Ready()=>_initialized && _editable;
    public void BindProject(ProjectData project,bool initialized,bool editable,bool reset)
    {
        ChangeRows(()=>
        {
            _project=project; _initialized=initialized; _editable=editable;
            if(reset)
            {
                _searchText=""; _selectedCategory=Categories[0];
                DraftProjectName=""; DraftAirportName=""; DraftArpLatitude=""; DraftArpLongitude="";
                foreach(var name in new[]{nameof(SearchText),nameof(SelectedCategory),nameof(DraftProjectName),
                    nameof(DraftAirportName),nameof(DraftArpLatitude),nameof(DraftArpLongitude)}) Notify(name);
            }
            UpdateSummary(); LoadRows();
        });
    }
    public void UpdateSummary()
    {
        _dispatcher.VerifyAccess();
        foreach(var name in new[]{nameof(IsInitialized),nameof(ProjectName),nameof(AirportName),nameof(ArpDisplay)}) Notify(name);
        RefreshCommands();
    }
    public void RefreshRows()=>ChangeRows(LoadRows);
    private void LoadRows()
    {
        IEnumerable<object> values=_project is null?[]:SelectedCategory.Kind switch
        {
            ProjectDataCategory.Fix=>_project.Fixes,ProjectDataCategory.Obstacle=>_project.Obstacles,
            ProjectDataCategory.Runway=>_project.Runways,ProjectDataCategory.Navaid=>_project.Navaids,_=>[]
        };
        ReplaceRows(values.Select(ProjectRow.From).ToArray());
    }
    private ICollectionView CreateRowsView(ProjectRow[] rows)
    {
        return new ListCollectionView(rows) { Filter=RowMatchesSearch };
    }
    private bool RowMatchesSearch(object value)=>value is ProjectRow row &&
        row.Name.Contains(_searchText.Trim(),StringComparison.OrdinalIgnoreCase);
    private void ReplaceRows(ProjectRow[] snapshot)
    {
        // Prepare the filtered view before binding it. Never mutate a bound
        // collection inside DeferRefresh: ListCollectionView reads CurrentPosition.
        var view=CreateRowsView(snapshot);
        _rows=snapshot; VisibleRows=view;
        Notify(nameof(VisibleRows));
    }
    private void ChangeRows(Action action)
    {
        _dispatcher.VerifyAccess();
        try { RowsRefreshing?.Invoke(); action(); }
        finally
        {
            try { SetSelection([]); }
            finally { RowsRefreshed?.Invoke(); }
        }
    }
    public void SetSelection(IEnumerable<string> ids)
    {
        _dispatcher.VerifyAccess();
        _selectedDataIds.Clear(); _selectedDataIds.UnionWith(ids);
        Notify(nameof(CountDisplay)); RefreshCommands();
    }
    private void RefreshCommands() { foreach(var command in _commands) command.Refresh(); }
    private void Notify([CallerMemberName]string? name=null)=>PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
    private static string Angle(double value,bool latitude)
    {
        var tenths=(long)Math.Round(Math.Abs(value)*36000,MidpointRounding.AwayFromZero);
        var degrees=tenths/36000; var minutes=tenths%36000/600; var seconds=tenths%600/10d;
        var hemisphere=latitude?(value<0?'S':'N'):(value<0?'W':'E');
        return string.Create(CultureInfo.InvariantCulture,$"{degrees:0}°{minutes:00}′{seconds:00.0}″{hemisphere}");
    }
    private sealed class ProjectCommand(Action execute,Func<bool> canExecute) : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)=>canExecute();
        public void Execute(object? parameter) { if(canExecute()) execute(); }
        public void Refresh()=>CanExecuteChanged?.Invoke(this,EventArgs.Empty);
    }
}
