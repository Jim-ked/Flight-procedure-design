using System.Globalization;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Fpd.Core;
using WpfScrollViewer=System.Windows.Controls.ScrollViewer;

namespace Fpd.AutoCAD.Views;

public partial class ProjectWorkspaceView : System.Windows.Controls.UserControl
{
    private sealed record GridState(string[] SelectedIds,double VerticalOffset,double HorizontalOffset);
    private readonly Dictionary<ProjectDataCategory,GridState> _states=[];
    private readonly ProjectWorkspaceViewModel _model;
    private ProjectDataCategory? _activeCategory;
    private bool _restoring;
    private int _refreshVersion;
    private DispatcherOperation? _restoreOperation;
    private ProjectData? _boundProject;
    private string? _activeSearchText;
    private ICollectionView? _activeRowsView;
    internal event Action? DataActivated;

    internal ProjectWorkspaceView(ProjectWorkspaceViewModel model)
    {
        InitializeComponent(); _model=model; DataContext=model;
        model.RowsRefreshing+=SaveGridState; model.RowsRefreshed+=RestoreGridState;
    }
    internal void BindProject(ProjectData project,bool initialized,bool editable,bool reset)
    {
        Dispatcher.VerifyAccess();
        _boundProject=project;
        if(reset) { _states.Clear(); _activeCategory=null; _activeSearchText=null; _activeRowsView=null; }
        _model.BindProject(project,initialized,editable,reset);
    }
    private void SaveGridState()
    {
        Dispatcher.VerifyAccess();
        // Invalidate at the start, before the model publishes another view.
        ++_refreshVersion;
        _restoreOperation?.Abort(); _restoreOperation=null;
        var wasRestoring=_restoring; _restoring=true;
        if(!wasRestoring && _activeCategory is { } category)
        {
            var scroll=FindScrollViewer(ProjectDataGrid);
            _states[category]=new(ProjectDataGrid.SelectedItems.Cast<ProjectRow>().Select(row=>row.DataId).ToArray(),
                scroll?.VerticalOffset??0,scroll?.HorizontalOffset??0);
        }
    }
    private void RestoreGridState()
    {
        Dispatcher.VerifyAccess();
        var category=_model.SelectedCategory.Kind;
        var version=_refreshVersion;
        var view=_model.VisibleRows; var project=_boundProject;
        var searchText=_model.SearchText;
        var searchOnly=_activeCategory==category && ReferenceEquals(view,_activeRowsView) && _activeSearchText!=searchText;
        var state=_states.GetValueOrDefault(category)??new GridState([],0,0);
        bool IsCurrent()=>version==_refreshVersion && ReferenceEquals(project,_boundProject) &&
            category==_model.SelectedCategory.Kind && ReferenceEquals(view,_model.VisibleRows);
        try
        {
            var operation=Dispatcher.BeginInvoke(DispatcherPriority.Loaded,new Action(()=>
            {
                if(!IsCurrent()) return;
                try
                {
                    if(!ReferenceEquals(ProjectDataGrid.ItemsSource,view)) return;
                    if(_activeCategory!=category) ConfigureColumns(category);
                    _activeCategory=category;
                    _activeSearchText=searchText; _activeRowsView=view;
                    if(!IsCurrent()) return;
                    var ids=state.SelectedIds.ToHashSet(StringComparer.OrdinalIgnoreCase);
                    var selected=ids.Count==0?[]:view.Cast<ProjectRow>().Where(row=>ids.Contains(row.DataId)).ToArray();
                    ProjectDataGrid.SelectedItems.Clear();
                    foreach(var row in selected) ProjectDataGrid.SelectedItems.Add(row);
                    // A search keeps the same columns and row snapshot. Let the
                    // grid clamp its own viewport instead of forcing another layout
                    // and rebuilding scroll position on every character.
                    if(!searchOnly)
                    {
                        var scroll=FindScrollViewer(ProjectDataGrid);
                        scroll?.ScrollToVerticalOffset(state.VerticalOffset); scroll?.ScrollToHorizontalOffset(state.HorizontalOffset);
                    }
                }
                finally
                {
                    if(version==_refreshVersion)
                    {
                        _restoreOperation=null; _restoring=false;
                        if(IsCurrent() && ReferenceEquals(ProjectDataGrid.ItemsSource,view)) UpdateSelection();
                    }
                }
            }));
            _restoreOperation=operation;
            operation.Aborted+=(_,_)=>
            {
                if(version==_refreshVersion) { _restoreOperation=null; _restoring=false; }
            };
            if(operation.Status==DispatcherOperationStatus.Aborted && version==_refreshVersion) { _restoreOperation=null; _restoring=false; }
        }
        catch
        {
            if(version==_refreshVersion) { _restoreOperation=null; _restoring=false; }
            throw;
        }
    }
    private void ConfigureColumns(ProjectDataCategory category)
    {
        ProjectDataGrid.Columns.Clear();
        void Column(string title,string property,double width,string? format=null)
        {
            var binding=new System.Windows.Data.Binding(property) { Mode=BindingMode.OneWay,ConverterCulture=CultureInfo.InvariantCulture,StringFormat=format };
            ProjectDataGrid.Columns.Add(new DataGridTextColumn { Header=title,Binding=binding,MinWidth=width,Width=new DataGridLength(width) });
        }
        switch(category)
        {
            case ProjectDataCategory.Fix:
                Column("名称",nameof(ProjectRow.Name),110); Coordinates(); break;
            case ProjectDataCategory.Obstacle:
                Column("编号",nameof(ProjectRow.Name),100);
                Column("顶标高 m",nameof(ProjectRow.TopElevation),110,"0.###");
                Column("基准高程 m",nameof(ProjectRow.GroundElevation),120,"0.###"); Coordinates(); break;
            case ProjectDataCategory.Runway:
                Column("跑道方向",nameof(ProjectRow.Name),150); Column("宽度 m",nameof(ProjectRow.Width),110,"0.###"); break;
            case ProjectDataCategory.Navaid:
                Column("名称",nameof(ProjectRow.Name),100); Column("类型",nameof(ProjectRow.Kind),95); Coordinates(); break;
        }
        void Coordinates()
        {
            Column("纬度",nameof(ProjectRow.Latitude),122,"F8");
            Column("经度",nameof(ProjectRow.Longitude),122,"F8");
        }
    }
    private void ProjectDataGrid_SelectionChanged(object sender,System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if(!_restoring) UpdateSelection();
    }
    private void UpdateSelection()=>_model.SetSelection(ProjectDataGrid.SelectedItems.Cast<ProjectRow>().Select(row=>row.DataId));
    private void ProjectDataGrid_MouseDoubleClick(object sender,MouseButtonEventArgs e)
    {
        if(_restoring || e.ChangedButton!=MouseButton.Left || e.OriginalSource is not DependencyObject source ||
            ItemsControl.ContainerFromElement(ProjectDataGrid,source) is not DataGridRow row) return;
        if(!ProjectDataGrid.SelectedItems.Contains(row.Item)) ProjectDataGrid.SelectedItem=row.Item;
        UpdateSelection();
        if(ProjectDataGrid.SelectedItems.Count==1) DataActivated?.Invoke();
    }
    private void ProjectDataGrid_PreviewKeyDown(object sender,System.Windows.Input.KeyEventArgs e)
    {
        if(_restoring || e.Key!=Key.End || Keyboard.Modifiers!=ModifierKeys.None || ProjectDataGrid.Items.Count==0) return;
        var last=ProjectDataGrid.Items[ProjectDataGrid.Items.Count-1];
        if(ProjectDataGrid.Columns.Count>0) ProjectDataGrid.CurrentCell=new DataGridCellInfo(last,ProjectDataGrid.CurrentCell.Column??ProjectDataGrid.Columns[0]);
        ProjectDataGrid.SelectedItem=last; ProjectDataGrid.ScrollIntoView(last); e.Handled=true;
    }
    private static WpfScrollViewer? FindScrollViewer(DependencyObject parent)
    {
        for(var i=0;i<VisualTreeHelper.GetChildrenCount(parent);i++)
        {
            var child=VisualTreeHelper.GetChild(parent,i);
            if(child is WpfScrollViewer scroll) return scroll;
            var nested=FindScrollViewer(child); if(nested is not null) return nested;
        }
        return null;
    }
}
