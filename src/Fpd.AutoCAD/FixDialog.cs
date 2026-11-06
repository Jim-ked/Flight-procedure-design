using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

internal sealed class FixDialog : Form
{
    private readonly TextBox _ident = new(), _lat = new(), _lon = new(), _elev = new();
    public FixData Value { get; private set; } = new();

    public FixDialog(FixData? existing = null)
    {
        SuspendLayout();
        Text = existing is null ? "添加定位点" : "修改定位点";
        ClientSize = new Size(320, 204);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScaleDimensions = new SizeF(96, 96);
        Font = new Font("Microsoft YaHei UI", 9);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false; MinimizeBox = false;
        BackColor = Color.FromArgb(37, 37, 37); ForeColor = Color.Gainsboro;
        var table = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(8) };
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        Add(table, "标识", _ident); Add(table, "纬度 (°)", _lat); Add(table, "经度 (°)", _lon); Add(table, "高程 (m)", _elev);
        var note = new Label { Text = "十进制度；高程留空时绘图 Z=0", AutoSize = true, Dock = DockStyle.Fill };
        table.Controls.Add(note, 0, table.RowCount++); table.SetColumnSpan(note, 2);
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, FlowDirection = FlowDirection.RightToLeft };
        var ok = new Button { Text = "确定", AutoSize = true };
        ok.Click += (_, _) =>
        {
            try
            {
                var value = new FixData
                {
                    Ident = _ident.Text.Trim(), Latitude = double.Parse(_lat.Text, CultureInfo.InvariantCulture),
                    Longitude = double.Parse(_lon.Text, CultureInfo.InvariantCulture),
                    Elevation = string.IsNullOrWhiteSpace(_elev.Text) ? null : double.Parse(_elev.Text, CultureInfo.InvariantCulture)
                };
                ProjectValidation.Fix(value); Value = value; DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        };
        var cancel = new Button { Text = "取消", AutoSize = true, DialogResult = DialogResult.Cancel };
        buttons.Controls.Add(ok); buttons.Controls.Add(cancel);
        table.Controls.Add(buttons, 0, table.RowCount++); table.SetColumnSpan(buttons, 2);
        Controls.Add(table); AcceptButton = ok; CancelButton = cancel;
        if (existing is not null)
        {
            _ident.Text = existing.Ident; _lat.Text = existing.Latitude.ToString("G", CultureInfo.InvariantCulture);
            _lon.Text = existing.Longitude.ToString("G", CultureInfo.InvariantCulture); _elev.Text = existing.Elevation?.ToString("G", CultureInfo.InvariantCulture) ?? "";
        }
        ResumeLayout(true);
    }

    private static void Add(TableLayoutPanel table, string label, TextBox box)
    {
        var row = table.RowCount++; table.RowStyles.Add(new RowStyle(SizeType.Absolute, 29));
        table.Controls.Add(new Label { Text = label, TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, row);
        box.Dock = DockStyle.Fill; box.BackColor = Color.FromArgb(55, 55, 55); box.ForeColor = Color.White; box.BorderStyle = BorderStyle.FixedSingle;
        table.Controls.Add(box, 1, row);
    }
}
