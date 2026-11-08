using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly DataGridView _runwayGrid=DataTable(),_navaidGrid=DataTable();
    internal event Action<Action>? AirportCommandRequested;
    private bool IsAirportData=>_dataTabs.SelectedIndex>=2;
    private bool IsRunway=>_dataTabs.SelectedIndex==2;
    private int DataCount=>_dataTabs.SelectedIndex switch { 1=>_project.Obstacles.Count,2=>_project.Runways.Count,3=>_project.Navaids.Count,_=>_project.Fixes.Count };
    private void AddAirportTabs()
    {
        foreach(var (title,grid,columns) in new[] { ("跑道",_runwayGrid,new[] { "跑道方向","宽度（m）" }),("导航台",_navaidGrid,new[] { "名称","类型","纬度","经度" }) })
        {
            foreach(var c in columns) grid.Columns.Add(c,c);
            for(var i=0;i<grid.Columns.Count;i++) grid.Columns[i].FillWeight=100;
            grid.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionChanged+=(_,_)=>UpdateSelection(); grid.CellDoubleClick+=(_,e)=> { if(e.RowIndex>=0) Run(()=>EditAirportData(true)); };
            var page=Page(title); page.Padding=Padding.Empty; _dataTabs.TabPages.Add(page);
        }
    }
    private void RefreshAirportData()
    {
        var selected=_runwayGrid.SelectedRows.Cast<DataGridViewRow>().Select(r=>r.Tag).ToHashSet(); _runwayGrid.Rows.Clear();
        foreach(var r in _project.Runways.Where(r=>r.Ident.Contains(_search.Text.Trim(),StringComparison.OrdinalIgnoreCase)))
        {
            var row=_runwayGrid.Rows[_runwayGrid.Rows.Add(r.Ident,r.Width)]; row.Tag=r; row.Selected=selected.Contains(r);
        }
        if(selected.Count==0) _runwayGrid.ClearSelection();
        selected=_navaidGrid.SelectedRows.Cast<DataGridViewRow>().Select(r=>r.Tag).ToHashSet(); _navaidGrid.Rows.Clear();
        foreach(var n in _project.Navaids.Where(n=>n.Ident.Contains(_search.Text.Trim(),StringComparison.OrdinalIgnoreCase)))
        {
            var row=_navaidGrid.Rows[_navaidGrid.Rows.Add(n.Ident,n.Kind,n.Position.Latitude,n.Position.Longitude)]; row.Tag=n; row.Selected=selected.Contains(n);
        }
        if(selected.Count==0) _navaidGrid.ClearSelection();
    }
    private List<T> SelectedBasics<T>()=>CurrentGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(r=>r.Index).Select(r=>(T)r.Tag!).ToList();
    private void CadOperation(Action action)
    {
        RequireProject(); var project=_project;
        AirportCommandRequested?.Invoke(()=> { if(project!=_project) throw new InvalidOperationException("项目已切换，请重新操作。"); action(); });
    }
    private void EditAirportData(bool edit)
    {
        RequireProject();
        if(edit && CurrentGrid.SelectedRows.Count!=1) throw new InvalidOperationException("请只选择一行修改。");
        if(IsRunway) EditRunway(edit?SelectedBasics<RunwayData>()[0]:null); else EditNavaid(edit?SelectedBasics<NavaidData>()[0]:null);
    }
    private void EditRunway(RunwayData? previous,RunwayData? draft=null)
    {
        using var dialog=new RunwayDialog(draft??previous); var result=dialog.ShowDialog(this);
        if(result==DialogResult.Retry)
        {
            var value=dialog.Value; var index=dialog.PickIndex;
            CadOperation(()=> { var position=CadDrawing.PickPosition(_project); if(position is not null) RunwayDialog.SetPosition(value,index,position); EditRunway(previous,value); }); return;
        }
        if(result!=DialogResult.OK) return;
        ProjectDataIds.Ensure(_project); if(previous is not null) dialog.Value.DataId=previous.DataId;
        var original=_project.Runways.ToList();
        if(previous is null) _project.Runways.Add(dialog.Value); else _project.Runways[_project.Runways.IndexOf(previous)]=dialog.Value;
        try { ProjectValidation.Project(_project); } catch { _project.Runways=original; throw; }
        BaseDataChanged("Runway",[dialog.Value]); RefreshData(); RefreshProcedures();
    }
    private void EditNavaid(NavaidData? previous,NavaidData? draft=null)
    {
        using var dialog=new NavaidDialog(draft??previous); var result=dialog.ShowDialog(this);
        if(result==DialogResult.Retry)
        {
            var value=dialog.Value;
            CadOperation(()=> { var position=CadDrawing.PickPosition(_project); if(position is not null) { value.Position.Latitude=position.Latitude; value.Position.Longitude=position.Longitude; } EditNavaid(previous,value); }); return;
        }
        if(result!=DialogResult.OK) return;
        ProjectDataIds.Ensure(_project); if(previous is not null) dialog.Value.DataId=previous.DataId;
        if(_project.Navaids.Any(n=>n!=previous && n.Ident.Equals(dialog.Value.Ident,StringComparison.OrdinalIgnoreCase))) throw new InvalidOperationException("设施标识重复。");
        if(previous is null) _project.Navaids.Add(dialog.Value); else _project.Navaids[_project.Navaids.IndexOf(previous)]=dialog.Value;
        BaseDataChanged("Navaid",[dialog.Value]); RefreshData();
    }
    private void DeleteAirportData()
    {
        if(CurrentGrid.SelectedRows.Count==0) throw new InvalidOperationException("请选择数据行。");
        if(MessageBox.Show(this,"删除所选基础资料？CAD图形保留；程序原跑道文本保留。","删除资料",MessageBoxButtons.OKCancel)!=DialogResult.OK) return;
        if(IsRunway) { var selected=SelectedBasics<RunwayData>(); _project.Runways.RemoveAll(selected.Contains); } else { var selected=SelectedBasics<NavaidData>(); _project.Navaids.RemoveAll(selected.Contains); }
        Changed(); RefreshData(); RefreshProcedures();
    }
    private void AddAirportText(string text)
    {
        IReadOnlyList<object> changed;
        if(IsRunway)
        {
            var batch=RunwayCsv.ParseText(text,_project.Runways.Select(r=>r.Ident)); var original=_project.Runways; _project.Runways=original.Concat(batch).ToList();
            try { ProjectValidation.Project(_project); } catch { _project.Runways=original; throw; }
            changed=batch;
        }
        else { var batch=NavaidCsv.ParseText(text,_project.Navaids.Select(n=>n.Ident)); _project.Navaids.AddRange(batch); changed=batch; }
        BaseDataChanged(IsRunway?"Runway":"Navaid",changed); RefreshData(); RefreshProcedures();
    }
    private string ExportAirportSelection()=>IsRunway?RunwayCsv.Export(SelectedBasics<RunwayData>()):NavaidCsv.Export(SelectedBasics<NavaidData>());
}
