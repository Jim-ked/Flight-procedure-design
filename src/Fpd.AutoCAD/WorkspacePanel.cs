using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed class WorkspacePanel : UserControl
{
    private readonly ProjectStore _store = new();
    private readonly Func<string?> _drawingPath;
    private ProjectData _project = ProjectStore.Create("未命名项目", new AirportData());
    private string _currentPath = "";
    private bool _dirty, _refreshing;
    private readonly TabControl _tabs = new() { Dock = DockStyle.Fill, Appearance = TabAppearance.FlatButtons, ItemSize = new Size(78, 31), SizeMode = TabSizeMode.Fixed };
    private readonly Label _status = new() { Height = 29, Dock = DockStyle.Bottom, AutoEllipsis = true, TextAlign = ContentAlignment.MiddleLeft, BackColor = Color.FromArgb(37, 37, 37), ForeColor = Color.Gainsboro };
    private readonly ListBox _fixList = List();
    private readonly ListBox _procedureList = List();
    private readonly Label _procedureDetail = new() { Dock = DockStyle.Fill, AutoEllipsis = true };
    private readonly Label _result = new() { Dock = DockStyle.Fill, Padding = new Padding(2) };
    private TextBox _name = null!, _airport = null!, _icao = null!, _lat = null!, _lon = null!, _elev = null!, _dwg = null!;
    private TextBox _procedure = null!, _runway = null!, _sequence = null!;
    private ComboBox _kind = null!;
    public ProjectData Project => _project;
    public FixData? SelectedFix => (_fixList.SelectedItem as FixRow)?.Fix;
    public event EventHandler? DrawFixRequested;

    public WorkspacePanel(Func<string?> drawingPath)
    {
        // Build the complete 96-DPI layout before the host scales it once.
        SuspendLayout();
        _drawingPath = drawingPath;
        Dock = DockStyle.Fill; AutoScaleMode = AutoScaleMode.Dpi; AutoScaleDimensions = new SizeF(96, 96);
        Font = new Font("Microsoft YaHei UI", 9); BackColor = Color.FromArgb(37, 37, 37); ForeColor = Color.Gainsboro;
        _tabs.TabPages.Add(ProjectPage()); _tabs.TabPages.Add(ProcedurePage()); _tabs.TabPages.Add(ToolsPage());
        var results = Page("成果"); results.Controls.Add(_result); _tabs.TabPages.Add(results);
        _tabs.SelectedIndexChanged += (_, _) => { if (_tabs.SelectedIndex == 3) ShowSummary(); };
        Controls.Add(_tabs); Controls.Add(_status);
        LoadProjectFields(); RefreshLists();
        ResumeLayout(true);
    }

    private static ListBox List() => new() { Dock = DockStyle.Fill, IntegralHeight = false, BackColor = Color.FromArgb(45, 45, 45), ForeColor = Color.Gainsboro, BorderStyle = BorderStyle.FixedSingle, HorizontalScrollbar = true };
    private TabPage Page(string title) => new(title) { BackColor = BackColor, ForeColor = ForeColor, Padding = new Padding(7), UseVisualStyleBackColor = false };
    private static TableLayoutPanel FormGrid()
    {
        var grid = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, AutoScroll = true };
        grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84)); grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        return grid;
    }
    private TextBox Field(TableLayoutPanel grid, string label, bool projectField = false)
    {
        var box = new TextBox { Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.FromArgb(55, 55, 55), ForeColor = Color.White };
        AddField(grid, label, box);
        if (projectField) box.TextChanged += (_, _) => { if (!_refreshing) _dirty = true; };
        return box;
    }
    private static void AddField(TableLayoutPanel grid, string label, Control control)
    {
        var row = grid.RowCount++; grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        grid.Controls.Add(new Label { Text = label, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, row);
        grid.Controls.Add(control, 1, row);
    }
    private static void FullRow(TableLayoutPanel grid, Control control, float height, SizeType size = SizeType.Absolute)
    {
        var row = grid.RowCount++; grid.RowStyles.Add(new RowStyle(size, height)); grid.Controls.Add(control, 0, row); grid.SetColumnSpan(control, 2);
    }
    private Button ActionButton(string text, Action action)
    {
        var button = new Button { Text = text, AutoSize = true, MinimumSize = new Size(55, 27), FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(57, 57, 57), ForeColor = Color.White, Margin = new Padding(2), Padding = new Padding(3, 0, 3, 0) };
        button.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
        button.Click += (_, _) => Run(action);
        return button;
    }
    private static FlowLayoutPanel Toolbar(params Control[] controls)
    {
        var bar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, Margin = Padding.Empty };
        bar.Controls.AddRange(controls); return bar;
    }
    private void Run(Action action)
    {
        try { action(); }
        catch (Exception ex) { _status.Text = "  " + ex.Message; MessageBox.Show(this, ex.Message, "FPD", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }

    private TabPage ProjectPage()
    {
        var page = Page("项目"); var grid = FormGrid();
        FullRow(grid, Toolbar(ActionButton("新建", NewProject), ActionButton("打开", OpenProject), ActionButton("保存", () => SaveProject())), 34);
        _name = Field(grid, "项目名称", true); _airport = Field(grid, "机场名称", true); _icao = Field(grid, "ICAO", true);
        _lat = Field(grid, "ARP 纬度 °", true); _lon = Field(grid, "ARP 经度 °", true); _elev = Field(grid, "ARP 高程 m", true);
        _dwg = Field(grid, "DWG 路径"); _dwg.ReadOnly = true;
        FullRow(grid, new Label { Text = "CGCS2000 · 十进制度 · 高程留空时 Z=0", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 24);
        FullRow(grid, Toolbar(ActionButton("应用 ARP", () => { SyncAirport(); ShowCoordinates(); }), ActionButton("关联当前 DWG", () => SetDwgPath(_drawingPath()))), 34);
        FullRow(grid, new Label { Text = "定位点  /  双击修改", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 24);
        FullRow(grid, _fixList, 100, SizeType.Percent); _fixList.MinimumSize = new Size(0, 84);
        _fixList.DoubleClick += (_, _) => Run(() => EditFix(true));
        FullRow(grid, Toolbar(ActionButton("新增", () => EditFix(false)), ActionButton("修改", () => EditFix(true)), ActionButton("CSV 导入", ImportCsv), ActionButton("绘制", RequestDraw)), 34);
        page.Controls.Add(grid); return page;
    }

    private TabPage ProcedurePage()
    {
        var page = Page("程序"); var grid = FormGrid();
        _procedure = Field(grid, "程序名称");
        _kind = new ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList, BackColor = Color.FromArgb(55, 55, 55), ForeColor = Color.White };
        _kind.Items.AddRange(Enum.GetNames<ProcedureKind>()); _kind.SelectedIndex = 0; AddField(grid, "程序类型", _kind);
        _runway = Field(grid, "关联跑道"); _sequence = Field(grid, "Fix 顺序");
        FullRow(grid, new Label { Text = "用逗号分隔标识，可重复；如 TJ001,TJ002", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 25);
        FullRow(grid, Toolbar(ActionButton("创建程序", AddProcedure)), 34);
        FullRow(grid, new Label { Text = "程序记录", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 24);
        FullRow(grid, _procedureList, 100, SizeType.Percent);
        FullRow(grid, _procedureDetail, 110);
        _procedureList.SelectedIndexChanged += (_, _) =>
        {
            if (_procedureList.SelectedItem is ProcedureRow row)
                _procedureDetail.Text = $"{row.Procedure.Name}\r\n类型：{row.Procedure.Kind}   跑道：{row.Procedure.Runway ?? "未关联"}\r\n顺序：{string.Join(" → ", row.Procedure.FixIdents)}";
        };
        page.Controls.Add(grid); return page;
    }

    private sealed record ToolEntry(string Category, string Name, Action? Execute);
    private TabPage ToolsPage()
    {
        var page = Page("工具"); page.Padding = Padding.Empty;
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1, Margin = Padding.Empty };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 52)); layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        var categories = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, Padding = new Padding(1, 5, 1, 0), Margin = Padding.Empty, BackColor = Color.FromArgb(44, 44, 44) };
        var content = new TableLayoutPanel { Dock = DockStyle.Top, AutoSize = true, ColumnCount = 1, Padding = new Padding(7), Margin = Padding.Empty };
        content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        var scroll = new Panel { Dock = DockStyle.Fill, AutoScroll = true }; scroll.Controls.Add(content);
        ToolEntry[] tools =
        [
            new("基础计算", "经纬度转 XYZ", ShowCoordinates), new("基础计算", "定位点绘制", RequestDraw),
            new("航迹与机动", "航迹与机动（未实现）", null), new("保护区", "保护区设计（未实现）", null),
            new("垂直设计", "垂直设计（未实现）", null), new("障碍物评价", "障碍物评价（未实现）", null)
        ];
        var categoryButtons = new List<Button>();
        void SelectCategory(string category, Button selected)
        {
            while (content.Controls.Count > 0) content.Controls[0].Dispose();
            content.RowStyles.Clear(); content.RowCount = 0;
            foreach (var button in categoryButtons) button.BackColor = button == selected ? Color.FromArgb(55, 90, 115) : Color.FromArgb(44, 44, 44);
            foreach (var tool in tools.Where(t => t.Category == category))
            {
                var button = ActionButton(tool.Name, () => tool.Execute?.Invoke());
                button.Enabled = tool.Execute is not null; button.AutoSize = false; button.Dock = DockStyle.Fill; button.TextAlign = ContentAlignment.MiddleLeft;
                button.Margin = new Padding(0, 0, 0, 5);
                var row = content.RowCount++; content.RowStyles.Add(new RowStyle(SizeType.Absolute, 35)); content.Controls.Add(button, 0, row);
            }
        }
        foreach (var category in tools.Select(t => t.Category).Distinct())
        {
            var button = new Button { Text = category switch { "基础计算" => "基础\n计算", "航迹与机动" => "航迹\n机动", "障碍物评价" => "障碍\n评价", "垂直设计" => "垂直\n设计", _ => category }, Width = 46, Height = 52, FlatStyle = FlatStyle.Flat, Margin = new Padding(1, 1, 1, 3), ForeColor = Color.Gainsboro };
            button.FlatAppearance.BorderSize = 0; button.Click += (_, _) => SelectCategory(category, button);
            categoryButtons.Add(button); categories.Controls.Add(button);
        }
        layout.Controls.Add(categories, 0, 0); layout.Controls.Add(scroll, 1, 0); page.Controls.Add(layout);
        SelectCategory("基础计算", categoryButtons[0]); return page;
    }

    private void LoadProjectFields()
    {
        _refreshing = true;
        try
        {
            _name.Text = _project.Name; _airport.Text = _project.Airport.Name; _icao.Text = _project.Airport.Icao;
            _lat.Text = Format(_project.Airport.ArpLatitude); _lon.Text = Format(_project.Airport.ArpLongitude); _elev.Text = Format(_project.Airport.ArpElevation); _dwg.Text = _project.DwgPath ?? "";
        }
        finally { _refreshing = false; }
    }
    private static string Format(double? number) => number?.ToString("G", CultureInfo.InvariantCulture) ?? "";
    private static double? Number(string text) => string.IsNullOrWhiteSpace(text) ? null : double.Parse(text, CultureInfo.InvariantCulture);
    private void SyncAirport()
    {
        var candidate = new ProjectData
        {
            ProjectId = _project.ProjectId, Name = _name.Text.Trim(), DwgPath = _project.DwgPath, Fixes = _project.Fixes, Procedures = _project.Procedures,
            Airport = new() { Name = _airport.Text.Trim(), Icao = _icao.Text.Trim().ToUpperInvariant(), ArpLatitude = Number(_lat.Text), ArpLongitude = Number(_lon.Text), ArpElevation = Number(_elev.Text) }
        };
        ProjectValidation.Project(candidate); _project.Name = candidate.Name; _project.Airport = candidate.Airport;
    }
    private void RefreshLists()
    {
        var selected = SelectedFix?.Ident; _fixList.Items.Clear();
        foreach (var fix in _project.Fixes) { var index = _fixList.Items.Add(new FixRow(fix)); if (fix.Ident == selected) _fixList.SelectedIndex = index; }
        _procedureList.Items.Clear(); foreach (var procedure in _project.Procedures) _procedureList.Items.Add(new ProcedureRow(procedure));
        if (_procedureList.Items.Count > 0) _procedureList.SelectedIndex = 0;
        _status.Text = $"  {_project.Name}  ·  Fix {_project.Fixes.Count}  ·  程序 {_project.Procedures.Count}";
        ShowSummary();
    }
    private void ShowSummary() => _result.Text = $"项目：{_project.Name}\r\n机场：{_project.Airport.Name}  {_project.Airport.Icao}\r\n定位点：{_project.Fixes.Count}    程序：{_project.Procedures.Count}\r\nDWG：{_project.DwgPath ?? "未关联"}\r\n\r\n成果导出尚未实现。点位请在 CAD 模型空间查看。";
    private bool ConfirmReplacement()
    {
        if (!_dirty) return true;
        var choice = MessageBox.Show(this, "当前项目有未保存修改，是否先保存？", "FPD", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        return choice == DialogResult.No || (choice == DialogResult.Yes && SaveProject());
    }
    private void NewProject()
    {
        if (!ConfirmReplacement()) return;
        _project = ProjectStore.Create("未命名项目", new AirportData()); _currentPath = ""; _dirty = false;
        LoadProjectFields(); RefreshLists();
    }
    private void OpenProject()
    {
        if (!ConfirmReplacement()) return;
        using var dialog = new OpenFileDialog { Filter = "FPD 项目|*.fpd.json|JSON|*.json", Title = "打开 FPD 项目" };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        var opened = _store.Open(dialog.FileName); _project = opened; _currentPath = dialog.FileName; _dirty = false;
        LoadProjectFields(); RefreshLists();
    }
    private bool SaveProject()
    {
        SyncAirport();
        if (string.IsNullOrWhiteSpace(_currentPath))
        {
            using var dialog = new SaveFileDialog { Filter = "FPD 项目|*.fpd.json", FileName = _project.Name + ".fpd.json", Title = "保存 FPD 项目" };
            if (dialog.ShowDialog(this) != DialogResult.OK) return false;
            _currentPath = dialog.FileName;
        }
        _store.Save(_project, _currentPath); _dirty = false; _status.Text = "  已保存：" + _currentPath; return true;
    }
    public void SetDwgPath(string? path)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new InvalidOperationException("请先打开 DWG。");
        _project.DwgPath = path; _dwg.Text = path; _dirty = true; ShowSummary();
    }
    private void EditFix(bool edit)
    {
        var previous = edit ? SelectedFix : null;
        if (edit && previous is null) throw new InvalidOperationException("请先选择定位点。");
        using var dialog = new FixDialog(previous);
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        var value = dialog.Value;
        if (_project.Fixes.Any(f => f != previous && f.Ident.Equals(value.Ident, StringComparison.OrdinalIgnoreCase))) throw new InvalidDataException("定位点标识已存在。");
        if (previous is null) _project.Fixes.Add(value);
        else
        {
            foreach (var procedure in _project.Procedures)
                for (var i = 0; i < procedure.FixIdents.Count; i++)
                    if (procedure.FixIdents[i].Equals(previous.Ident, StringComparison.OrdinalIgnoreCase)) procedure.FixIdents[i] = value.Ident;
            _project.Fixes[_project.Fixes.IndexOf(previous)] = value;
        }
        _dirty = true; RefreshLists(); _fixList.SelectedIndex = _project.Fixes.IndexOf(value);
    }
    private void ImportCsv()
    {
        using var dialog = new OpenFileDialog { Filter = "CSV|*.csv|所有文件|*.*", Title = "导入定位点：Ident,Latitude,Longitude,Elevation" };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        var batch = FixCsv.Parse(dialog.FileName);
        foreach (var fix in batch)
            if (_project.Fixes.Any(f => f.Ident.Equals(fix.Ident, StringComparison.OrdinalIgnoreCase))) throw new InvalidDataException($"项目中已存在 {fix.Ident}，整批未导入。");
        _project.Fixes.AddRange(batch); _dirty = true; RefreshLists(); _status.Text = $"  已导入 {batch.Count} 个定位点";
    }
    private void AddProcedure()
    {
        if (string.IsNullOrWhiteSpace(_procedure.Text)) throw new InvalidDataException("请填写程序名称。");
        var idents = _sequence.Text.Split([',', '，', ';'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var record = new ProcedureData { Name = _procedure.Text.Trim(), Kind = (ProcedureKind)_kind.SelectedIndex, Runway = string.IsNullOrWhiteSpace(_runway.Text) ? null : _runway.Text.Trim() };
        foreach (var ident in idents)
            record.FixIdents.Add(_project.Fixes.FirstOrDefault(f => f.Ident.Equals(ident, StringComparison.OrdinalIgnoreCase))?.Ident ?? throw new InvalidDataException("未知定位点：" + ident));
        _project.Procedures.Add(record); _dirty = true; _procedure.Clear(); RefreshLists(); _procedureList.SelectedIndex = _project.Procedures.Count - 1;
    }
    public (FixData Fix, ProjectedPoint Point) GetSelectedPoint()
    {
        SyncAirport();
        if (!_project.Airport.ArpLongitude.HasValue) throw new InvalidOperationException("请先录入机场 ARP 经纬度，以确定项目统一投影带。");
        var cm = Cgcs2000Projection.ZoneForLongitude(_project.Airport.ArpLongitude.Value).CentralMeridian;
        var fix = SelectedFix ?? new FixData { Ident = "ARP", Latitude = _project.Airport.ArpLatitude!.Value, Longitude = _project.Airport.ArpLongitude.Value, Elevation = _project.Airport.ArpElevation };
        return (fix, Cgcs2000Projection.ForwardInZone(fix.Latitude, fix.Longitude, cm, fix.Elevation));
    }
    private void ShowCoordinates()
    {
        var (fix, point) = GetSelectedPoint();
        _tabs.SelectedIndex = 3;
        _result.Text = $"{fix.Ident} · CGCS2000 / CM{point.CentralMeridian:0}E\r\nEPSG:{point.Epsg} · 不含带号\r\n\r\nWCS X / Easting\r\n{point.Easting:F3} m\r\nWCS Y / Northing\r\n{point.Northing:F3} m\r\nZ = {point.Z:F3} m{(fix.Elevation.HasValue ? "（输入值）" : "（未提供，使用 0）")}\r\n\r\n未减去 ARP；未进行垂直基准换算。";
    }
    private void RequestDraw() { GetSelectedPoint(); DrawFixRequested?.Invoke(this, EventArgs.Empty); }
    private sealed record FixRow(FixData Fix) { public override string ToString() => $"{Fix.Ident}   {Fix.Latitude:F6}, {Fix.Longitude:F6}   {(Fix.Elevation.HasValue ? Fix.Elevation.Value.ToString("G") + "m" : "Z=0（缺省）")}"; }
    private sealed record ProcedureRow(ProcedureData Procedure) { public override string ToString() => $"{Procedure.Name} · {Procedure.Kind} · {Procedure.FixIdents.Count} 点"; }
}
