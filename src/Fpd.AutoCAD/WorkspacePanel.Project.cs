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
    private readonly DataGridView _fixGrid=DataTable();
    private readonly DataGridView _obstacleGrid=DataTable();
    private readonly TextBox _search=Input();
    private readonly Label _selectionSummary=Caption("");
    private readonly Label _dataDetails=Caption("");
    private readonly NumericUpDown _textHeight=new() { Minimum=.1m,Maximum=10000,DecimalPlaces=1,Value=50,Increment=10,Width=70,BackColor=Color.FromArgb(55,55,55),ForeColor=Color.White };
    private readonly CheckBox _showTop=new() { Text="障碍物顶标高",Checked=true,AutoSize=true,Margin=new Padding(6,5,0,0) };
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
        Row(stack,Bar(Button("新建",NewProject),Button("打开",OpenProject),Button("保存",()=>SaveProject())),34);
        Row(stack,_projectSummary,23); Row(stack,_projectionSummary,23); Row(stack,_dwgSummary,23);
        Row(stack,Bar(Button("机场资料",EditAirport),MenuButton("更多",("关联当前DWG",()=>SetDwgPath(_drawingPath())),("补建公共底图",()=>QueueBaseMap()),("保留冲突原图并补建",RepairBaseMap),("导出本类CSV",ExportCurrentData),("标注设置",BaseLabelSettings),("绘制ARP",()=>Draw(PointProjection.Arp(_project))))),32);
        var search=FormGrid(); Field(search,"查找标识",_search); Row(stack,search,32);
        void Columns(DataGridView grid,bool obstacle)
        {
            foreach(var (name,width) in obstacle?new[] { ("标识",130),("顶标高 m",110) }:new[] { ("标识",160) }) grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText=name,Width=width,SortMode=DataGridViewColumnSortMode.NotSortable });
            grid.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionChanged+=(_,_)=>UpdateSelection(); grid.CellDoubleClick+=(_,e)=> { if(e.RowIndex>=0) Run(()=>EditPoint(true)); };
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
        var fixes=Page("定位点"); fixes.Padding=Padding.Empty; fixes.Controls.Add(_fixGrid); var obstacles=Page("障碍物"); obstacles.Padding=Padding.Empty; obstacles.Controls.Add(_obstacleGrid);
        _dataTabs.TabPages.Add(fixes); _dataTabs.TabPages.Add(obstacles); AddAirportTabs(); _dataTabs.SelectedIndexChanged+=(_,_)=>UpdateSelection();
        _search.TextChanged+=(_,_)=>RefreshData(); Row(stack,_dataTabs,100,true); Row(stack,_selectionSummary,23);
        Row(stack,Bar(Button("新增",()=>EditPoint(false)),Button("修改",()=>EditPoint(true)),Button("删除",DeletePoints),Button("CSV 导入",ImportPoints)),34);
        Row(stack,_dataDetails,52);
        page.Controls.Add(stack); return page;
    }
    private void RefreshSummary()
    {
        _projectSummary.Text=$"{_project.Name} · {_project.Airport.Name}  {_project.Airport.Icao}";
        _tips.SetToolTip(_projectSummary,_projectSummary.Text);
        _projectionSummary.Text=_project.Airport.ArpLongitude is double lon ? $"CGCS2000 / CM{Cgcs2000Projection.ZoneForLongitude(lon).CentralMeridian}E · EPSG:{Cgcs2000Projection.ZoneForLongitude(lon).Epsg}" : "投影未确定 · 请编辑机场资料";
        _dwgSummary.Text="DWG · "+(_project.DwgPath is null?"未关联":Path.GetFileName(_project.DwgPath)); _tips.SetToolTip(_dwgSummary,_project.DwgPath??"未关联");
    }
    private void RefreshData()
    {
        void Fill(DataGridView grid,IEnumerable<object> values,Func<object,string> ident,Func<object,object?[]> cells)
        {
            var selected=grid.SelectedRows.Cast<DataGridViewRow>().Select(r=>r.Tag).ToHashSet(); grid.Rows.Clear();
            foreach(var value in values.Where(v=>ident(v).Contains(_search.Text.Trim(),StringComparison.OrdinalIgnoreCase)))
            { var row=grid.Rows[grid.Rows.Add(cells(value))]; row.Tag=value; row.Selected=selected.Contains(value); }
            // DataGridView auto-selects its first row; an empty selection must stay empty.
            if(selected.Count==0) grid.ClearSelection();
        }
        Fill(_fixGrid,_project.Fixes,f=>((FixData)f).Ident,f=> { var p=(FixData)f; return [p.Ident]; });
        Fill(_obstacleGrid,_project.Obstacles,o=>((ObstacleData)o).Ident,o=> { var p=(ObstacleData)o; return [p.Ident,p.TopElevation]; });
        RefreshAirportData(); UpdateSelection();
    }
    private List<FixData> SelectedFixes()=>_fixGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(r=>r.Index).Select(r=>(FixData)r.Tag!).ToList();
    private List<ObstacleData> SelectedObstacles()=>_obstacleGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(r=>r.Index).Select(r=>(ObstacleData)r.Tag!).ToList();
    private void UpdateSelection()
    {
        _selectionSummary.Text=$"{_dataTabs.SelectedTab?.Text} · 已选 {CurrentGrid.SelectedRows.Count} / {DataCount}";
        var value=CurrentGrid.SelectedRows.Count==1?CurrentGrid.SelectedRows[0].Tag:null;
        _dataDetails.Text=value switch
        {
            FixData f=>$"{f.Ident}  纬 {f.Latitude:F8}°  经 {f.Longitude:F8}°\r\n高程 {f.Elevation?.ToString("0.###")??"未填"} m",
            ObstacleData o=>$"纬 {o.Latitude:F8}°  经 {o.Longitude:F8}°\r\n顶标高 {o.TopElevation:0.###} m · 自身高 {o.Height} m · 地面 {o.GroundElevation} m",
            RunwayData r=>$"{r.EndA.Designator} / {r.EndB.Designator}  宽 {r.Width} m\r\n双击查看两物理端及各方向THR / DER资料",
            NavaidData n=>$"纬 {n.Position.Latitude:F8}°  经 {n.Position.Longitude:F8}°\r\n标高 {n.Position.Elevation:0.###} m · {n.Name}",
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
        if(IsAirportData) { EditAirportData(edit); return; }
        if(edit && CurrentGrid.SelectedRows.Count!=1) throw new InvalidOperationException("请只选择一行进行修改。");
        if(IsObstacle)
        {
            var previous=edit?SelectedObstacles()[0]:null; using var dialog=new ObstacleDialog(previous);
            if(dialog.ShowDialog(this)!=DialogResult.OK) return;
            var value=dialog.Value; ProjectDataIds.Ensure(_project); if(previous is not null) value.DataId=previous.DataId;
            if(_project.Obstacles.Any(o=>o!=previous && o.Ident.Equals(value.Ident,StringComparison.OrdinalIgnoreCase))) throw new InvalidDataException("障碍物标识已存在。");
            if(previous is null) _project.Obstacles.Add(value); else _project.Obstacles[_project.Obstacles.IndexOf(previous)]=value;
        }
        else
        {
            var previous=edit?SelectedFixes()[0]:null; using var dialog=new FixDialog(previous);
            if(dialog.ShowDialog(this)!=DialogResult.OK) return;
            ProjectEdits.ReplaceFix(_project,previous,dialog.Value);
        }
        BaseDataChanged(); RefreshData(); RefreshProcedures(); RefreshToolChoices();
    }
    private void DeletePoints()
    {
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
        using var dialog=new OpenFileDialog { Filter="CSV / TSV|*.csv;*.tsv;*.txt|所有文件|*.*",Title=IsAirportData?"导入"+_dataTabs.SelectedTab!.Text+" CSV":IsObstacle?"导入障碍物（TopElevation 为必填顶标高，单位米）":"导入定位点（十进制度，高程单位米）" };
        if(dialog.ShowDialog(this)==DialogResult.OK) AddPointText(File.ReadAllText(dialog.FileName));
    }
    private void AddPointText(string text)
    {
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
        if(IsAirportData) { DrawAirportData(all); return; }
        Draw(IsObstacle ? PointProjection.Obstacles(_project,all?_project.Obstacles:SelectedObstacles()) : PointProjection.Fixes(_project,all?_project.Fixes:SelectedFixes()));
    }
}
