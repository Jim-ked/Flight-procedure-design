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
    private readonly NumericUpDown _textHeight=new() { Minimum=.1m,Maximum=10000,DecimalPlaces=1,Value=50,Increment=10,Width=70,BackColor=Color.FromArgb(55,55,55),ForeColor=Color.White };
    private readonly CheckBox _showTop=new() { Text="障碍物顶标高",Checked=true,AutoSize=true,Margin=new Padding(6,5,0,0) };
    private bool IsObstacle => _dataTabs.SelectedIndex==1;
    private DataGridView CurrentGrid => IsObstacle?_obstacleGrid:_fixGrid;
    private static DataGridView DataTable() => new()
    {
        Dock=DockStyle.Fill,ReadOnly=true,AllowUserToAddRows=false,AllowUserToDeleteRows=false,MultiSelect=true,SelectionMode=DataGridViewSelectionMode.FullRowSelect,
        RowHeadersVisible=false,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells,BackgroundColor=Color.FromArgb(42,42,42),BorderStyle=BorderStyle.FixedSingle,
        EnableHeadersVisualStyles=false,ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize,AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells,
        ColumnHeadersDefaultCellStyle=new DataGridViewCellStyle { BackColor=Color.FromArgb(55,55,55),ForeColor=Color.Gainsboro,WrapMode=DataGridViewTriState.True },
        DefaultCellStyle=new DataGridViewCellStyle { BackColor=Color.FromArgb(42,42,42),ForeColor=Color.Gainsboro,SelectionBackColor=Color.FromArgb(55,90,115),SelectionForeColor=Color.White },
        ClipboardCopyMode=DataGridViewClipboardCopyMode.Disable
    };
    private TabPage ProjectPage()
    {
        var page=Page("项目"); var stack=Stack();
        Row(stack,Bar(Button("新建",NewProject),Button("打开",OpenProject),Button("保存",()=>SaveProject())),34);
        Row(stack,_projectSummary,23); Row(stack,_projectionSummary,23); Row(stack,_dwgSummary,23);
        Row(stack,Bar(Button("编辑项目 / 机场",EditAirport),Button("关联当前 DWG",()=>SetDwgPath(_drawingPath()))),34);
        var search=FormGrid(); Field(search,"查找标识",_search); Row(stack,search,32);
        void Columns(DataGridView grid,bool obstacle)
        {
            foreach(var (name,width) in new[] { ("标识",82),("纬度 °",100),("经度 °",100),(obstacle?"顶标高 m":"高程 m",85) }) grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText=name,Width=width,SortMode=DataGridViewColumnSortMode.NotSortable });
            if(obstacle) { grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText="自身高度 m",Width=90 }); grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText="地面高程 m",Width=90 }); }
            grid.SelectionChanged+=(_,_)=>UpdateSelection(); grid.CellDoubleClick+=(_,e)=> { if(e.RowIndex>=0) Run(()=>EditPoint(true)); };
            grid.KeyDown+=(_,e)=>
            {
                if(e.Control && e.KeyCode==Keys.C) { Run(CopyPoints); e.SuppressKeyPress=true; }
                if(e.Control && e.KeyCode==Keys.V) { Run(PastePoints); e.SuppressKeyPress=true; }
                if(e.Control && e.KeyCode==Keys.A) { grid.SelectAll(); e.SuppressKeyPress=true; }
                if(e.KeyCode==Keys.Delete) { Run(DeletePoints); e.SuppressKeyPress=true; }
            };
            var menu=new ContextMenuStrip(); menu.Items.Add("复制所选",null,(_,_)=>Run(CopyPoints)); menu.Items.Add("粘贴新增",null,(_,_)=>Run(PastePoints)); menu.Items.Add("全选",null,(_,_)=>grid.SelectAll()); grid.ContextMenuStrip=menu;
            grid.Disposed+=(_,_)=>menu.Dispose();
        }
        Columns(_fixGrid,false); Columns(_obstacleGrid,true);
        var fixes=Page("定位点"); fixes.Padding=Padding.Empty; fixes.Controls.Add(_fixGrid); var obstacles=Page("障碍物"); obstacles.Padding=Padding.Empty; obstacles.Controls.Add(_obstacleGrid);
        _dataTabs.TabPages.Add(fixes); _dataTabs.TabPages.Add(obstacles); _dataTabs.SelectedIndexChanged+=(_,_)=>UpdateSelection();
        _search.TextChanged+=(_,_)=>RefreshData(); Row(stack,_dataTabs,100,true); Row(stack,_selectionSummary,23);
        Row(stack,Bar(Button("新增",()=>EditPoint(false)),Button("修改",()=>EditPoint(true)),Button("删除",DeletePoints),Button("CSV 导入",ImportPoints)),34);
        Row(stack,Bar(Button("复制",CopyPoints),Button("粘贴",PastePoints),Button("全选",()=>CurrentGrid.SelectAll())),34);
        Row(stack,Bar(Button("绘制所选",()=>DrawSelected(false)),Button("绘制全部",()=>DrawSelected(true))),34);
        Row(stack,Bar(new Label { Text="字高 m",AutoSize=true,Margin=new Padding(2,5,0,0) },_textHeight,_showTop),30);
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
        Fill(_fixGrid,_project.Fixes,f=>((FixData)f).Ident,f=> { var p=(FixData)f; return [p.Ident,p.Latitude.ToString("F6"),p.Longitude.ToString("F6"),p.Elevation]; });
        Fill(_obstacleGrid,_project.Obstacles,o=>((ObstacleData)o).Ident,o=> { var p=(ObstacleData)o; return [p.Ident,p.Latitude.ToString("F6"),p.Longitude.ToString("F6"),p.TopElevation,p.Height,p.GroundElevation]; });
        UpdateSelection();
    }
    private List<FixData> SelectedFixes()=>_fixGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(r=>r.Index).Select(r=>(FixData)r.Tag!).ToList();
    private List<ObstacleData> SelectedObstacles()=>_obstacleGrid.SelectedRows.Cast<DataGridViewRow>().OrderBy(r=>r.Index).Select(r=>(ObstacleData)r.Tag!).ToList();
    private void UpdateSelection() => _selectionSummary.Text=$"{(IsObstacle?"障碍物":"定位点")} · 已选 {CurrentGrid.SelectedRows.Count} / 显示 {CurrentGrid.Rows.Count} / 共 {(IsObstacle?_project.Obstacles.Count:_project.Fixes.Count)}";
    private void EditPoint(bool edit)
    {
        if(edit && CurrentGrid.SelectedRows.Count!=1) throw new InvalidOperationException("请只选择一行进行修改。");
        if(IsObstacle)
        {
            var previous=edit?SelectedObstacles()[0]:null; using var dialog=new ObstacleDialog(previous);
            if(dialog.ShowDialog(this)!=DialogResult.OK) return;
            var value=dialog.Value;
            if(_project.Obstacles.Any(o=>o!=previous && o.Ident.Equals(value.Ident,StringComparison.OrdinalIgnoreCase))) throw new InvalidDataException("障碍物标识已存在。");
            if(previous is null) _project.Obstacles.Add(value); else _project.Obstacles[_project.Obstacles.IndexOf(previous)]=value;
        }
        else
        {
            var previous=edit?SelectedFixes()[0]:null; using var dialog=new FixDialog(previous);
            if(dialog.ShowDialog(this)!=DialogResult.OK) return;
            ProjectEdits.ReplaceFix(_project,previous,dialog.Value);
        }
        Changed(); RefreshData(); RefreshProcedures(); RefreshToolChoices();
    }
    private void DeletePoints()
    {
        var count=CurrentGrid.SelectedRows.Count; if(count==0) throw new InvalidOperationException("请先选择数据行。");
        var ids=SelectedFixes().Select(f=>f.Ident).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var referenced=!IsObstacle && _project.Procedures.Any(p=>p.FixIdents.Any(ids.Contains));
        if(MessageBox.Show(this,$"删除所选 {count} 行？"+(referenced?"同时移除程序中的这些 Fix 引用。":"")+"已绘制的 CAD 图形保持原样。","删除数据",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!=DialogResult.OK) return;
        if(IsObstacle) { var selected=SelectedObstacles(); _project.Obstacles.RemoveAll(selected.Contains); }
        else ProjectEdits.DeleteFixes(_project,ids);
        Changed(); RefreshData(); RefreshProcedures(); RefreshToolChoices();
    }
    private void ImportPoints()
    {
        using var dialog=new OpenFileDialog { Filter="CSV / TSV|*.csv;*.tsv;*.txt|所有文件|*.*",Title=IsObstacle?"导入障碍物（TopElevation 为必填顶标高，单位米）":"导入定位点（十进制度，高程单位米）" };
        if(dialog.ShowDialog(this)==DialogResult.OK) AddPointText(File.ReadAllText(dialog.FileName));
    }
    private void AddPointText(string text)
    {
        int count;
        if(IsObstacle) { var batch=ObstacleCsv.ParseText(text,_project.Obstacles.Select(o=>o.Ident)); count=batch.Count; _project.Obstacles.AddRange(batch); }
        else { var batch=FixCsv.ParseText(text,_project.Fixes.Select(f=>f.Ident)); count=batch.Count; _project.Fixes.AddRange(batch); }
        Changed(); RefreshData(); RefreshProcedures(); RefreshToolChoices(); SetStatus($"已整批导入 {count} 行");
    }
    private void CopyPoints()
    {
        if(CurrentGrid.SelectedRows.Count==0) throw new InvalidOperationException("请先选择要复制的数据行。");
        Clipboard.SetText(IsObstacle?ObstacleCsv.Export(SelectedObstacles(),"\t"):FixCsv.Export(SelectedFixes(),"\t")); SetStatus("已复制所选行（含字段标题）");
    }
    private void PastePoints() { if(!Clipboard.ContainsText()) throw new InvalidOperationException("剪贴板没有表格文本。"); AddPointText(Clipboard.GetText()); }
    private void DrawSelected(bool all) => Draw(IsObstacle ? PointProjection.Obstacles(_project,all?_project.Obstacles:SelectedObstacles()) : PointProjection.Fixes(_project,all?_project.Fixes:SelectedFixes()));
}
