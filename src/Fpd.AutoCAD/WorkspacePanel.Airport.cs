using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    internal event Action<Action>? AirportCommandRequested;
    private void CadOperation(Action action)
    {
        RequireProject(); var project=_project;
        AirportCommandRequested?.Invoke(()=> { if(project!=_project) throw new InvalidOperationException("项目已切换，请重新操作。"); action(); });
    }
    private void EditAirportData(bool edit)
    {
        RequireProject();
        if(edit && SelectedDataIds.Count!=1) throw new InvalidOperationException("请只选择一行修改。");
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
    private void AddAirportText(string text)
    {
        if(IsRunway)
        {
            var result=RunwayCsv.ImportText(text,_project.Runways);
            if(result.Added.Count>0)
            {
                var original=_project.Runways; _project.Runways=original.Concat(result.Added).ToList();
                try { ProjectValidation.Project(_project); } catch { _project.Runways=original; throw; }
                BaseDataChanged("Runway",result.Added);
            }
            RefreshData(); RefreshProcedures(); ReportImport(result);
        }
        else
        {
            var result=NavaidCsv.ImportText(text,_project.Navaids);
            _project.Navaids.AddRange(result.Added);
            if(result.Added.Count>0) BaseDataChanged("Navaid",result.Added);
            RefreshData(); RefreshProcedures(); ReportImport(result);
        }
    }
}
