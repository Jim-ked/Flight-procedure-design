using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly Label _projectSummary=Caption("");
    private readonly Label _projectionSummary=Caption("");
    private readonly Label _dwgSummary=Caption("");
    private readonly TabControl _dataTabs=new() { Dock=DockStyle.Fill };
    private readonly Panel _dataList=new() { Dock=DockStyle.Fill };
    private readonly DataGridView _fixGrid=DataTable();
    private readonly DataGridView _obstacleGrid=DataTable();
    private readonly TextBox _search=Input();
    private readonly Label _selectionSummary=Caption("");
    private readonly Label _dataDetails=Caption("");
    private readonly NumericUpDown _textHeight=new() { Minimum=.1m,Maximum=10000,DecimalPlaces=1,Value=50,Increment=10,Width=70,BackColor=Color.FromArgb(55,55,55),ForeColor=Color.White };
    private bool IsObstacle => _dataTabs.SelectedIndex==1;
    private DataGridView CurrentGrid => _dataTabs.SelectedIndex switch { 1=>_obstacleGrid,2=>_runwayGrid,3=>_navaidGrid,_=>_fixGrid };
    private static DataGridView DataTable() => new()
    {
        Dock=DockStyle.Fill,ReadOnly=true,AllowUserToAddRows=false,AllowUserToDeleteRows=false,MultiSelect=true,SelectionMode=DataGridViewSelectionMode.FullRowSelect,
        RowHeadersVisible=false,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells,BackgroundColor=Color.FromArgb(42,42,42),BorderStyle=BorderStyle.FixedSingle,
        EnableHeadersVisualStyles=false,ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize,AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.None,RowTemplate=new DataGridViewRow { Height=27 },
        ColumnHeadersDefaultCellStyle=new DataGridViewCellStyle { BackColor=Color.FromArgb(55,55,55),ForeColor=Color.Gainsboro,WrapMode=DataGridViewTriState.True },
        DefaultCellStyle=new DataGridViewCellStyle { BackColor=Color.FromArgb(42,42,42),ForeColor=Color.Gainsboro,SelectionBackColor=Color.FromArgb(55,90,115),SelectionForeColor=Color.White },
        ClipboardCopyMode=DataGridViewClipboardCopyMode.Disable
    };
    private TabPage ProjectPage()
    {
        var page=Page("项目"); var stack=Stack();
        Row(stack,_projectSummary,25); Row(stack,_dwgSummary,25); Row(stack,_projectionSummary,25);
        Row(stack,Bar(Button("创建项目",NewProject),Button("修改项目",EditAirport),Button("打开DWG",OpenProject)),34);
        Row(stack,Bar(Button("保存DWG",()=>SaveProject()),Button("坐标转换",()=> { RequireProject(); ResetCoordinates(); _tabs.SelectedIndex=2; }),MenuButton("更多",("CAD点登记",RegisterCadPoint),("字高",BaseLabelSettings))),34);

        void Columns(DataGridView grid,bool obstacle)
        {
            foreach(var (name,width) in obstacle?new[] { ("标识",130),("顶标高 m",110) }:new[] { ("标识",160) }) grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText=name,Width=width,SortMode=DataGridViewColumnSortMode.NotSortable });
            grid.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionChanged+=(_,_)=> { UpdateSelection(); if(!_refreshing && grid.Focused && !IsAirportData) HighlightSelectedProjectData(false); }; grid.CellDoubleClick+=(_,e)=> { if(e.RowIndex>=0 && !IsAirportData) Run(()=>HighlightSelectedProjectData(true)); else if(e.RowIndex>=0) Run(()=>EditPoint(true)); };
            grid.KeyDown+=(_,e)=>
            {
                if(e.Control && e.KeyCode==Keys.C) { Run(CopyPoints); e.SuppressKeyPress=true; }
                if(e.Control && e.KeyCode==Keys.V) { Run(PastePoints); e.SuppressKeyPress=true; }
                if(e.Control && e.KeyCode==Keys.A) { grid.SelectAll(); e.SuppressKeyPress=true; }
                if(e.KeyCode==Keys.Delete) { Run(DeletePoints); e.SuppressKeyPress=true; }
            };
            var menu=new ContextMenuStrip(); menu.Items.Add("复制所选",null,(_,_)=>Run(CopyPoints)); menu.Items.Add("粘贴新增",null,(_,_)=>Run(PastePoints)); menu.Items.Add("全选",null,(_,_)=>grid.SelectAll()); menu.Items.Add("CAD选择",null,(_,_)=>Run(SelectCadData)); menu.Items.Add("CAD拾取新增",null,(_,_)=>Run(PickNewPoint)); grid.ContextMenuStrip=menu;
            grid.Disposed+=(_,_)=>menu.Dispose();
        }
        Columns(_fixGrid,false); Columns(_obstacleGrid,true);
        var fixes=Page("定位点"); fixes.Padding=Padding.Empty;  var obstacles=Page("障碍物"); obstacles.Padding=Padding.Empty;
        _dataTabs.TabPages.Add(fixes); _dataTabs.TabPages.Add(obstacles); AddAirportTabs(); _dataTabs.SelectedIndexChanged+=(_,_)=> { _dataList.Controls.Clear(); _dataList.Controls.Add(CurrentGrid); UpdateSelection(); };
        _dataList.Controls.Add(_fixGrid); Row(stack,_dataTabs,28);
        var search=FormGrid(); Field(search,"查找标识",_search); Row(stack,search,32); _search.TextChanged+=(_,_)=>RefreshCurrentData();
        Row(stack,Bar(Button("新增",()=>EditPoint(false)),Button("修改",()=>EditPoint(true)),Button("删除",DeletePoints),Button("CAD拾取",PickNewPoint)),34);
        Row(stack,Bar(Button("导入CSV",ImportPoints),Button("导出CSV",ExportCurrentData),Button("模板",ExportTemplate)),34);
        Row(stack,Bar(Button("绘制所选",()=>DrawSelected(false)),Button("绘制全部",()=>DrawSelected(true))),34);
        Row(stack,_dataList,100,true); Row(stack,_selectionSummary,23); Row(stack,_dataDetails,52);
        page.Controls.Add(stack); return page;
    }
    private void RefreshSummary()
    {
        _projectSummary.Text=$"{_project.Name} · {_project.Airport.Name}  {_project.Airport.Icao}";
        _tips.SetToolTip(_projectSummary,_projectSummary.Text);
        _projectionSummary.Text=_project.Airport.ArpLongitude is double lon ? $"CGCS2000 / CM{Cgcs2000Projection.ZoneForLongitude(lon).CentralMeridian}E · EPSG:{Cgcs2000Projection.ZoneForLongitude(lon).Epsg}" : "投影未确定 · 请编辑机场资料";
        _dwgSummary.Text=$"ARP · {_project.Airport.ArpLatitude?.ToString("F8")??"未设置"} / {_project.Airport.ArpLongitude?.ToString("F8")??"未设置"}";
        _tips.SetToolTip(_dwgSummary,_drawingPath()??"无DWG");
        if(_dirty) _projectSummary.Text+=" · 待保存DWG";
    }
    private void FillGrid<T>(DataGridView grid,IEnumerable<T> values,Func<T,string> ident,Func<T,object?[]> cells)
    {
        var selected=grid.SelectedRows.Cast<DataGridViewRow>().Select(r=>r.Tag).ToHashSet(); grid.Rows.Clear();
        foreach(var value in values.Where(v=>ident(v).Contains(_search.Text.Trim(),StringComparison.OrdinalIgnoreCase)))
        { var row=grid.Rows[grid.Rows.Add(cells(value))]; row.Tag=value; row.Selected=selected.Contains(value); }
        if(selected.Count==0) grid.ClearSelection();
    }
    private void RefreshData()
    {
        FillGrid(_fixGrid,_project.Fixes,f=>f.Ident,f=>[f.Ident]);
        FillGrid(_obstacleGrid,_project.Obstacles,o=>o.Ident,o=>[o.Ident,o.TopElevation]);
        RefreshAirportData(); UpdateSelection();
    }
    private void RefreshCurrentData()
    {
        switch(_dataTabs.SelectedIndex)
        {
            case 0: FillGrid(_fixGrid,_project.Fixes,f=>f.Ident,f=>[f.Ident]); break;
            case 1: FillGrid(_obstacleGrid,_project.Obstacles,o=>o.Ident,o=>[o.Ident,o.TopElevation]); break;
            default: RefreshAirportData(); break;
        }
        UpdateSelection();
    }
    private List<FixData> SelectedFixes()=>_fixGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(r=>r.Index).Select(r=>(FixData)r.Tag!).ToList();
    private List<ObstacleData> SelectedObstacles()=>_obstacleGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(r=>r.Index).Select(r=>(ObstacleData)r.Tag!).ToList();
    private void HighlightSelectedProjectData(bool zoom)
    {
        if(CurrentGrid.SelectedRows.Count!=1 || !DwgProjects.IsCurrent(_project)) return;
        var fix=CurrentGrid.SelectedRows[0].Tag as FixData; if(fix is not null) { var project=_project; CadOperation(()=>CadDrawing.HighlightPoint(project,null,null,fix,zoom)); return; }
        var obstacle=CurrentGrid.SelectedRows[0].Tag as ObstacleData; if(obstacle is not null) { var project=_project; CadOperation(()=>CadDrawing.HighlightBasePoint(project,"Obstacle",obstacle.DataId,zoom)); }
    }
    private void UpdateSelection()
    {
        _selectionSummary.Text=$"{_dataTabs.SelectedTab?.Text} · 已选 {CurrentGrid.SelectedRows.Count} / {DataCount}";
        var value=CurrentGrid.SelectedRows.Count==1?CurrentGrid.SelectedRows[0].Tag:null;
        _dataDetails.Text=value switch
        {
            FixData f=>$"{f.Ident}  纬 {f.Latitude:F8}°  经 {f.Longitude:F8}°",
            ObstacleData o=>$"纬 {o.Latitude:F8}°  经 {o.Longitude:F8}°\r\n顶标高 {o.TopElevation:0.###} m · 自身高 {o.Height} m · 地面 {o.GroundElevation} m",
            RunwayData r=>$"{r.EndA.Designator} / {r.EndB.Designator}  宽 {r.Width} m\r\n双击查看两物理端及各方向THR / DER资料",
            NavaidData n=>$"纬 {n.Position.Latitude:F8}°  经 {n.Position.Longitude:F8}°\r\n{n.Kind} · {n.Ident}",
            _=>""
        };
        _tips.SetToolTip(_dataDetails,_dataDetails.Text);
    }
    private void ExportCurrentData() { if(IsAirportData) ExportAirport(IsRunway); else Export(IsObstacle); }
    private void BaseLabelSettings()
    {
        var text=PromptText("公共底图标注","字高(m)",TextHeight.ToString(System.Globalization.CultureInfo.InvariantCulture)); if(text is null) return;
        if(!decimal.TryParse(text,System.Globalization.NumberStyles.Float,System.Globalization.CultureInfo.InvariantCulture,out var height) || height<_textHeight.Minimum || height>_textHeight.Maximum) throw new InvalidOperationException("字高超出范围。");
        _textHeight.Value=height; QueueBaseMap();
    }
    private void EditPoint(bool edit)
    {
        RequireProject();
        if(IsAirportData) { EditAirportData(edit); return; }
        if(edit && CurrentGrid.SelectedRows.Count!=1) throw new InvalidOperationException("请只选择一行进行修改。");
        if(IsObstacle) EditObstacle(edit?SelectedObstacles()[0]:null);
        else EditFix(edit?SelectedFixes()[0]:null);
    }
    private void EditFix(FixData? previous,FixData? draft=null,Autodesk.AutoCAD.DatabaseServices.ObjectId? nativePoint=null)
    {
        using var dialog=new FixDialog(draft??previous); var result=dialog.ShowDialog(this);
        if(result==DialogResult.Retry)
        {
            var value=dialog.Value;
            CadOperation(()=> { var p=CadDrawing.PickPosition(_project); if(p is not null) { value.Latitude=p.Latitude; value.Longitude=p.Longitude; if(p.Elevation.HasValue) value.Elevation=p.Elevation; } EditFix(previous,value,nativePoint); }); return;
        }
        if(result!=DialogResult.OK) return;
        ProjectEdits.ReplaceFix(_project,previous,dialog.Value); ProjectDataIds.Ensure(_project);
        try { if(nativePoint.HasValue) CadDrawing.RegisterFixPoint(_project,dialog.Value,nativePoint.Value,TextHeight); }
        catch { if(previous is null) _project.Fixes.Remove(dialog.Value); throw; }
        BaseDataChanged(); RefreshData(); RefreshProcedures(); RefreshToolChoices();
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
        BaseDataChanged(); RefreshData();
    }
    private void DeletePoints()
    {
        RequireProject();
        if(IsAirportData) { DeleteAirportData(); return; }
        var count=CurrentGrid.SelectedRows.Count; if(count==0) throw new InvalidOperationException("请先选择数据行。");
        var ids=SelectedFixes().Select(f=>f.Ident).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var referenced=!IsObstacle && _project.Procedures.Any(p=>p.Paths.Any(path=>path.Fixes.Any(f=>ids.Contains(f.FixIdent))) || p.FixIdents.Any(ids.Contains) || p.Sections.Any(s=>s.FixIdents.Any(ids.Contains)));
        if(MessageBox.Show(this,$"删除所选 {count} 行？"+(referenced?"同时移除程序中的这些 Fix 引用。":"")+"已绘制的 CAD 图形保持原样。","删除数据",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!=DialogResult.OK) return;
        if(IsObstacle) { var selected=SelectedObstacles(); _project.Obstacles.RemoveAll(selected.Contains); }
        else ProjectEdits.DeleteFixes(_project,ids);
        BaseDataChanged(); RefreshData(); RefreshProcedures(); RefreshToolChoices();
    }
    private void ImportPoints()
    {
        using var dialog=new OpenFileDialog { Filter="CSV|*.csv",Title=IsAirportData?"导入"+_dataTabs.SelectedTab!.Text+" CSV":IsObstacle?"导入障碍物（TopElevation 为必填顶标高，单位米）":"导入定位点（固定模板，十进制度）" };
        if(dialog.ShowDialog(this)==DialogResult.OK) AddPointText(File.ReadAllText(dialog.FileName));
    }
    private void AddPointText(string text)
    {
        RequireProject();
        int count;
        if(IsAirportData) { AddAirportText(text); return; }
        if(IsObstacle) { var batch=ObstacleCsv.ParseText(text,_project.Obstacles.Select(o=>o.Ident)); count=batch.Count; _project.Obstacles.AddRange(batch); }
        else { var batch=FixCsv.ParseText(text,_project.Fixes.Select(f=>f.Ident)); count=batch.Count; _project.Fixes.AddRange(batch); }
        BaseDataChanged(); RefreshData(); RefreshProcedures(); RefreshToolChoices(); SetStatus($"已整批导入 {count} 行");
    }
    private void CopyPoints()
    {
        if(CurrentGrid.SelectedRows.Count==0) throw new InvalidOperationException("请先选择要复制的数据行。");
        Clipboard.SetText(IsAirportData?ExportAirportSelection():IsObstacle?ObstacleCsv.Export(SelectedObstacles(),"\t"):FixCsv.Export(SelectedFixes(),"\t")); SetStatus("已复制所选行（含字段标题）");
    }
    private void PastePoints() { if(!Clipboard.ContainsText()) throw new InvalidOperationException("剪贴板没有表格文本。"); AddPointText(Clipboard.GetText()); }
    private void DrawSelected(bool all)
    {
        RequireProject(); ProjectDataIds.Ensure(_project);
        var kind=_dataTabs.SelectedIndex switch { 1=>"Obstacle",2=>"Runway",3=>"Navaid",_=>"Fix" };
        var keys=(all?CurrentValues():CurrentGrid.SelectedRows.Cast<DataGridViewRow>().Select(r=>r.Tag!)).Select(DataKey).ToHashSet();
        if(keys.Count==0) throw new InvalidOperationException("请选择数据，或新增资料。");
        QueueBaseMap(kind,keys);
    }
    private IEnumerable<object> CurrentValues()=>_dataTabs.SelectedIndex switch
    { 1=>_project.Obstacles,2=>_project.Runways,3=>_project.Navaids,_=>_project.Fixes };
    private static string DataKey(object value)=>value switch { FixData f=>f.DataId,ObstacleData o=>o.DataId,RunwayData r=>r.DataId,NavaidData n=>n.DataId,_=>throw new ArgumentException() };
    internal void DrawSelectedFixCommand()
    {
        RequireProject(); ProjectDataIds.Ensure(_project); var selected=SelectedFixes();
        if(selected.Count!=1) throw new InvalidOperationException("请在项目页选择一个定位点。");
        SetStatus(CadDrawing.SyncBaseMap(_project,TextHeight,"Fix",selected.Select(f=>f.DataId).ToHashSet()));
    }
    internal void DrawCurrentAllCommand() { RequireProject(); SetStatus(CadDrawing.SyncBaseMap(_project,TextHeight)); }
    private void ExportTemplate()
    {
        using var dialog=new SaveFileDialog { Filter="CSV|*.csv",FileName="template-"+_dataTabs.SelectedIndex+".csv" };
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        var text=_dataTabs.SelectedIndex switch { 1=>ObstacleCsv.Export([]),2=>RunwayCsv.Export([]),3=>NavaidCsv.Export([]),_=>FixCsv.Export([]) };
        File.WriteAllText(dialog.FileName,text,new System.Text.UTF8Encoding(true)); SetStatus("已导出本类固定字段模板");
    }
    private void RegisterCadPoint()
    {
        RequireProject();
        CadOperation(()=> { var picked=CadDrawing.PickNativePoint(_project); if(picked is null) return; var p=picked.Value.Position; EditFix(null,new() { Latitude=p.Latitude,Longitude=p.Longitude,Elevation=p.Elevation==0?null:p.Elevation },picked.Value.Id); });
    }
}
