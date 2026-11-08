using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly Label _projectSummary=Caption("");
    private readonly Label _airportSummary=Caption("");
    private readonly Label _arpSummary=Caption("");
    private readonly Panel _projectContent=new() { Dock=DockStyle.Fill };
    private readonly Panel _projectDataArea=new() { Dock=DockStyle.Fill };
    private readonly Panel _setupPrompt=new() { Dock=DockStyle.Fill };
    private readonly TextBox _setupProjectName=Input(),_setupAirportName=Input(),_setupLatitude=Input(),_setupLongitude=Input();
    private Button? _setupConfirm;
    private readonly TabControl _dataTabs=new() { Dock=DockStyle.Fill };
    private readonly Panel _dataList=new() { Dock=DockStyle.Fill };
    private readonly DataGridView _fixGrid=DataTable();
    private readonly DataGridView _obstacleGrid=DataTable();
    private readonly TextBox _search=Input();
    private readonly Label _selectionSummary=Caption("");
    private readonly NumericUpDown _textHeight=new() { Minimum=.1m,Maximum=10000,DecimalPlaces=1,Value=50,Increment=10,Width=70,BackColor=Color.FromArgb(55,55,55),ForeColor=Color.White };
    private Button? _editButton;
    private Button? _deleteButton;
    private Button? _editProjectButton;
    private Button? _coordinateButton;
    private TableLayoutPanel? _projectLayout;
    private TableLayoutPanel? _projectHeader;
    private bool IsObstacle => _dataTabs.SelectedIndex==1;
    private DataGridView CurrentGrid => _dataTabs.SelectedIndex switch { 1=>_obstacleGrid,2=>_runwayGrid,3=>_navaidGrid,_=>_fixGrid };

    private static DataGridView DataTable() => new()
    {
        Dock=DockStyle.Fill,ReadOnly=true,AllowUserToAddRows=false,AllowUserToDeleteRows=false,MultiSelect=true,SelectionMode=DataGridViewSelectionMode.FullRowSelect,
        RowHeadersVisible=false,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill,BackgroundColor=Color.FromArgb(42,42,42),BorderStyle=BorderStyle.FixedSingle,
        EnableHeadersVisualStyles=false,ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize,AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.None,RowTemplate=new DataGridViewRow { Height=27 },
        ColumnHeadersDefaultCellStyle=new DataGridViewCellStyle { BackColor=Color.FromArgb(55,55,55),ForeColor=Color.Gainsboro,WrapMode=DataGridViewTriState.False },
        DefaultCellStyle=new DataGridViewCellStyle { BackColor=Color.FromArgb(42,42,42),ForeColor=Color.Gainsboro,SelectionBackColor=Color.FromArgb(55,90,115),SelectionForeColor=Color.White },
        ClipboardCopyMode=DataGridViewClipboardCopyMode.Disable
    };

    private TabPage ProjectPage()
    {
        var page=Page("项目"); var outer=Stack(); _projectLayout=outer;
        var header=new TableLayoutPanel { Dock=DockStyle.Top,AutoSize=true,AutoSizeMode=AutoSizeMode.GrowAndShrink,ColumnCount=2,RowCount=3,Margin=Padding.Empty }; _projectHeader=header;
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100)); header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        for(var i=0;i<3;i++) header.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        foreach(var label in new[]{_projectSummary,_airportSummary,_arpSummary}) { label.AutoEllipsis=false; label.AutoSize=true; label.Margin=new Padding(0,4,0,4); }
        _editProjectButton=Button("编辑",EditAirportOrCreate); _coordinateButton=Button("坐标转换",OpenCoordinateTool);
        header.Controls.Add(_projectSummary,0,0); header.Controls.Add(_editProjectButton,1,0);
        header.Controls.Add(_airportSummary,0,1); header.SetColumnSpan(_airportSummary,2);
        header.Controls.Add(_arpSummary,0,2); header.Controls.Add(_coordinateButton,1,2);
        Row(outer,header,74);
        outer.RowStyles[0].SizeType=SizeType.AutoSize; header.Dock=DockStyle.Top;
        void FitSummary()
        {
            var actionWidth=Math.Max(_editProjectButton.PreferredSize.Width,_coordinateButton.PreferredSize.Width)+12;
            var width=Math.Max(100,outer.ClientSize.Width-actionWidth);
            _projectSummary.MaximumSize=new Size(width,0); _arpSummary.MaximumSize=new Size(width,0);
            _airportSummary.MaximumSize=new Size(Math.Max(100,outer.ClientSize.Width-8),0);
        }
        outer.SizeChanged+=(_,_)=>FitSummary(); FitSummary();

        BuildProjectSetup();

        var data=Stack();
        void Configure(DataGridView grid,params (string Name,int Width)[] columns)
        {
            foreach(var column in columns) grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText=column.Name,Width=column.Width,SortMode=DataGridViewColumnSortMode.NotSortable });
            grid.SelectionChanged+=(_,_)=>UpdateSelection();
            grid.CellDoubleClick+=(_,e)=> { if(e.RowIndex<0) return; Run(()=> { if(grid==_fixGrid || grid==_obstacleGrid) HighlightSelectedProjectData(true); else EditPoint(true); }); };
        }
        Configure(_fixGrid,("名称",130),("纬度",110),("经度",110));
        Configure(_obstacleGrid,("编号",120),("顶标高（m）",110),("纬度",110),("经度",110));
        var fixes=Page("定位点"); fixes.Padding=Padding.Empty; var obstacles=Page("障碍物"); obstacles.Padding=Padding.Empty;
        _dataTabs.TabPages.Add(fixes); _dataTabs.TabPages.Add(obstacles); AddAirportTabs();
        _dataTabs.SelectedIndexChanged+=(_,_)=> { _dataList.Controls.Clear(); _dataList.Controls.Add(CurrentGrid); UpdateSelection(); };
        _dataList.Controls.Add(_fixGrid); Row(data,_dataTabs,28);
        _search.PlaceholderText="查找名称或编号"; Row(data,_search,32); _search.TextChanged+=(_,_)=>RefreshCurrentData();
        _editButton=Button("修改",()=>EditPoint(true)); _deleteButton=Button("删除",DeletePoints);
        Row(data,Bar(Button("新增",()=>EditPoint(false)),_editButton,_deleteButton,Button("导入",ImportPoints),Button("导出",ExportCurrentData)),34);
        Row(data,_dataList,100,true); Row(data,_selectionSummary,23);
        _projectDataArea.Controls.Add(data);
        _projectContent.Controls.Add(_setupPrompt);
        Row(outer,_projectContent,100,true);
        page.Controls.Add(outer); return page;
    }

    private void EditAirportOrCreate() { if(_initialized) EditAirport(); else NewProject(); }
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

    private void RefreshSummary()
    {
        if(!_initialized)
        {
            _projectSummary.Text="当前图纸尚未设置机场资料"; _airportSummary.Text=""; _arpSummary.Text=""; return;
        }
        _projectSummary.Text=_project.Name;
        _airportSummary.Text=string.IsNullOrWhiteSpace(_project.Airport.Name)?"未设置机场名称":_project.Airport.Name;
        _arpSummary.Text=_project.Airport.ArpLatitude is double lat && _project.Airport.ArpLongitude is double lon
            ? $"ARP {FormatCoordinate(lat,true)} / {FormatCoordinate(lon,false)}"
            : "ARP 未设置";
        _tips.SetToolTip(_projectSummary,_projectSummary.Text); _tips.SetToolTip(_airportSummary,_airportSummary.Text); _tips.SetToolTip(_arpSummary,_arpSummary.Text);
    }
    private void BuildProjectSetup()
    {
        var card=new TableLayoutPanel { ColumnCount=2,Padding=new Padding(10),Margin=Padding.Empty };
        card.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); card.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
        var title=new Label { Text="项目设置",AutoSize=true,Font=new Font(Font.FontFamily,11,FontStyle.Bold),Margin=new Padding(0,0,0,16) };
        card.Controls.Add(title,0,0); card.SetColumnSpan(title,2); card.RowStyles.Add(new RowStyle(SizeType.AutoSize)); card.RowCount=1;
        foreach(var (label,box) in new[]{("项目名称",_setupProjectName),("机场名称",_setupAirportName),("ARP 纬度",_setupLatitude),("ARP 经度",_setupLongitude)})
        {
            var row=card.RowCount++; card.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            card.Controls.Add(new Label { Text=label,AutoSize=true,Anchor=AnchorStyles.Left,Margin=new Padding(0,6,12,6) },0,row);
            box.Margin=new Padding(0,6,0,6); card.Controls.Add(box,1,row);
        }
        _setupConfirm=Button("确定",CreateProjectFromSetup); _setupConfirm.Anchor=AnchorStyles.Right; _setupConfirm.Margin=new Padding(0,12,0,0);
        var actionRow=card.RowCount++; card.RowStyles.Add(new RowStyle(SizeType.AutoSize)); card.Controls.Add(_setupConfirm,1,actionRow);
        _setupPrompt.AutoScroll=true; _setupPrompt.Controls.Add(card);
        void CenterSetup()
        {
            var scale=DeviceDpi/96f; card.Width=Math.Max(1,Math.Min((int)(420*scale),_setupPrompt.ClientSize.Width-(int)(24*scale)));
            card.Height=card.GetPreferredSize(new Size(card.Width,0)).Height;
            card.Location=new Point(Math.Max(0,(_setupPrompt.ClientSize.Width-card.Width)/2),Math.Max(0,(_setupPrompt.ClientSize.Height-card.Height)/2));
        }
        _setupPrompt.SizeChanged+=(_,_)=>CenterSetup(); card.SizeChanged+=(_,_)=>CenterSetup(); CenterSetup();
    }
    private void CreateProjectFromSetup()
    {
        if(!_editable || _initialized || !DwgProjects.IsCurrent(_project)) throw new InvalidOperationException("当前图纸无法设置项目。");
        var airport=new AirportData { Name=_setupAirportName.Text.Trim(),ArpLatitude=CoordinateInput.Parse(_setupLatitude.Text,true),ArpLongitude=CoordinateInput.Parse(_setupLongitude.Text,false) };
        if(string.IsNullOrWhiteSpace(airport.Name)) throw new InvalidDataException("机场名称不能为空。");
        var project=ProjectStore.Create(_setupProjectName.Text.Trim(),airport); ProjectValidation.Project(project);
        DwgProjects.Initialize(project); SetStatus("项目资料已设置");
    }
    private static string FormatCoordinate(double value,bool latitude)
    {
        var absolute=Math.Abs(value); var degrees=Math.Floor(absolute); var minutesValue=(absolute-degrees)*60; var minutes=Math.Floor(minutesValue); var seconds=(minutesValue-minutes)*60;
        if(seconds>=59.995) { seconds=0; minutes++; } if(minutes>=60) { minutes=0; degrees++; }
        var hemisphere=latitude?(value<0?'S':'N'):(value<0?'W':'E');
        return string.Create(CultureInfo.InvariantCulture,$"{degrees:0}°{minutes:00}′{seconds:00.0}″{hemisphere}");
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
        FillGrid(_fixGrid,_project.Fixes,f=>f.Ident,f=>[f.Ident,f.Latitude,f.Longitude]);
        FillGrid(_obstacleGrid,_project.Obstacles,o=>o.Ident,o=>[o.Ident,o.TopElevation,o.Latitude,o.Longitude]);
        RefreshAirportData(); UpdateSelection();
    }
    private void RefreshCurrentData()
    {
        switch(_dataTabs.SelectedIndex)
        {
            case 0: FillGrid(_fixGrid,_project.Fixes,f=>f.Ident,f=>[f.Ident,f.Latitude,f.Longitude]); break;
            case 1: FillGrid(_obstacleGrid,_project.Obstacles,o=>o.Ident,o=>[o.Ident,o.TopElevation,o.Latitude,o.Longitude]); break;
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
        if(_editButton is null || _deleteButton is null) return;
        var count=CurrentGrid.SelectedRows.Count; _editButton.Enabled=count==1; _deleteButton.Enabled=count>0;
        _selectionSummary.Text=DataCount==0?"暂无数据":$"已选 {count} 项 · 共 {DataCount} 项";
    }
    private void ExportCurrentData() { if(IsAirportData) ExportAirport(IsRunway); else Export(IsObstacle); }

    private void EditPoint(bool edit)
    {
        RequireProject();
        if(IsAirportData) { EditAirportData(edit); return; }
        if(edit && CurrentGrid.SelectedRows.Count!=1) throw new InvalidOperationException("请选择一行数据。");
        if(IsObstacle) EditObstacle(edit?SelectedObstacles()[0]:null); else EditFix(edit?SelectedFixes()[0]:null);
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
        if(IsAirportData) { DeleteAirportData(); return; }
        var count=CurrentGrid.SelectedRows.Count; if(count==0) throw new InvalidOperationException("未选择数据。");
        var ids=SelectedFixes().Select(f=>f.Ident).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var referenced=!IsObstacle && _project.Procedures.Any(p=>p.Paths.Any(path=>path.Fixes.Any(f=>ids.Contains(f.FixIdent))) || p.FixIdents.Any(ids.Contains) || p.Sections.Any(s=>s.FixIdents.Any(ids.Contains)));
        var prompt=referenced?"删除所选数据并移除程序引用？":"删除所选数据？";
        if(MessageBox.Show(this,prompt,"删除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!=DialogResult.OK) return;
        if(IsObstacle) { var selected=SelectedObstacles(); _project.Obstacles.RemoveAll(selected.Contains); } else ProjectEdits.DeleteFixes(_project,ids);
        Changed(); RefreshData(); RefreshProcedures(); RefreshToolChoices();
    }

    private void ImportPoints()
    {
        RequireProject();
        using var form=new Form { Text="导入"+_dataTabs.SelectedTab!.Text,ClientSize=new Size(470,145),StartPosition=FormStartPosition.CenterParent,FormBorderStyle=FormBorderStyle.FixedDialog,MinimizeBox=false,MaximizeBox=false,Font=Font,BackColor=Color.FromArgb(37,37,37),ForeColor=Color.Gainsboro };
        var file=Input();
        var browse=Button("选择文件",()=> { using var open=new OpenFileDialog { Filter="CSV|*.csv" }; if(open.ShowDialog(form)==DialogResult.OK) file.Text=open.FileName; });
        var choose=new FlowLayoutPanel { Dock=DockStyle.Top,Height=38,WrapContents=false }; choose.Controls.Add(file); choose.Controls.Add(browse);
        var download=Button("下载模板",()=> { using var save=new SaveFileDialog { Filter="CSV|*.csv",FileName=_dataTabs.SelectedTab!.Text+"_模板.csv" }; if(save.ShowDialog(form)==DialogResult.OK) { File.WriteAllText(save.FileName,TemplateText(),new UTF8Encoding(true)); SetStatus("模板已保存"); } });
        var cancel=new Button { Text="取消",AutoSize=true,DialogResult=DialogResult.Cancel };
        var import=Button("导入",()=> { if(string.IsNullOrWhiteSpace(file.Text)) throw new InvalidOperationException("请选择文件。"); AddPointText(File.ReadAllText(file.Text)); form.DialogResult=DialogResult.OK; });
        var buttons=Bar(download,import,cancel); buttons.Dock=DockStyle.Bottom; buttons.Height=38;
        form.Controls.Add(buttons); form.Controls.Add(choose); form.AcceptButton=import; form.CancelButton=cancel; form.ShowDialog(this);
    }
    private string TemplateText() => _dataTabs.SelectedIndex switch { 1=>ObstacleCsv.Export([]),2=>RunwayCsv.Export([]),3=>NavaidCsv.Export([]),_=>FixCsv.Export([]) };
    private void AddPointText(string text)
    {
        RequireProject(); IReadOnlyList<object> batch;
        if(IsAirportData) { AddAirportText(text); return; }
        if(IsObstacle) { var rows=ObstacleCsv.ParseText(text,_project.Obstacles.Select(o=>o.Ident)); _project.Obstacles.AddRange(rows); batch=rows; }
        else { var rows=FixCsv.ParseText(text,_project.Fixes.Select(f=>f.Ident)); _project.Fixes.AddRange(rows); batch=rows; }
        BaseDataChanged(IsObstacle?"Obstacle":"Fix",batch); RefreshData(); RefreshProcedures(); RefreshToolChoices();
    }
    private void DrawSelected(bool all)
    {
        RequireProject(); ProjectDataIds.Ensure(_project);
        var kind=_dataTabs.SelectedIndex switch { 1=>"Obstacle",2=>"Runway",3=>"Navaid",_=>"Fix" };
        var keys=(all?CurrentValues():CurrentGrid.SelectedRows.Cast<DataGridViewRow>().Select(r=>r.Tag!)).Select(DataKey).ToHashSet();
        if(keys.Count==0) throw new InvalidOperationException("未选择数据。");
        QueueBaseMap(kind,keys);
    }
    private IEnumerable<object> CurrentValues()=>_dataTabs.SelectedIndex switch { 1=>_project.Obstacles,2=>_project.Runways,3=>_project.Navaids,_=>_project.Fixes };
    private static string DataKey(object value)=>value switch { FixData f=>f.DataId,ObstacleData o=>o.DataId,RunwayData r=>r.DataId,NavaidData n=>n.DataId,_=>throw new ArgumentException() };
    internal void DrawSelectedFixCommand()
    {
        RequireProject(); ProjectDataIds.Ensure(_project); var selected=SelectedFixes();
        if(selected.Count!=1) throw new InvalidOperationException("请在项目页选择一个定位点。");
        SetStatus(CadDrawing.SyncBaseMap(_project,"Fix",selected.Select(f=>f.DataId).ToHashSet()));
    }
    internal void DrawCurrentAllCommand() { RequireProject(); SetStatus(CadDrawing.SyncBaseMap(_project)); }
}
