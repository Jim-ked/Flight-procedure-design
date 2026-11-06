using System.Text;
using System.Text.Json;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;

namespace Fpd.Core;

public sealed class ProjectStore
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
    public void Save(ProjectData project, string path)
    {
        ArgumentNullException.ThrowIfNull(project);
        ProjectValidation.Project(project);
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path))!);
        var temporary = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            File.WriteAllText(temporary, JsonSerializer.Serialize(project, JsonOptions), new UTF8Encoding(false));
            File.Move(temporary, path, true);
        }
        finally { if (File.Exists(temporary)) File.Delete(temporary); }
    }

    public ProjectData Open(string path)
    {
        using var stream = File.OpenRead(path);
        var project = JsonSerializer.Deserialize<ProjectData>(stream, JsonOptions)
            ?? throw new InvalidDataException("项目文件为空或格式无效。");
        ProjectValidation.Project(project);
        return project;
    }

    public static ProjectData Create(string name, AirportData airport) => new() { Name = name, Airport = airport };
}

public static class FixCsv
{
    public static IReadOnlyList<FixData> Parse(string path)
    {
        var result = new List<FixData>();
        using var parser = new TextFieldParser(path, Encoding.UTF8) { HasFieldsEnclosedInQuotes = true, TrimWhiteSpace = true, CommentTokens = ["#"] };
        parser.SetDelimiters(",", ";", "\t");
        var identifiers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        while (!parser.EndOfData)
        {
            var lineNumber = parser.LineNumber;
            var values = parser.ReadFields()!;
            if (result.Count == 0 && values[0].Equals("Ident", StringComparison.OrdinalIgnoreCase)) continue;
            if (values.Length is < 3 or > 4) throw new FormatException($"CSV 第 {lineNumber} 行须有 3 或 4 列。");
            if (!double.TryParse(values[1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var lat) ||
                !double.TryParse(values[2], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var lon))
                throw new FormatException($"CSV 第 {lineNumber} 行经纬度无效。");
            double? elevation = null;
            if (values.Length > 3 && !string.IsNullOrWhiteSpace(values[3]))
                elevation = double.Parse(values[3], System.Globalization.CultureInfo.InvariantCulture);
            var fix = new FixData { Ident = values[0].Trim(), Latitude = lat, Longitude = lon, Elevation = elevation };
            ProjectValidation.Fix(fix);
            if (!identifiers.Add(fix.Ident)) throw new FormatException($"CSV 第 {lineNumber} 行标识重复：{fix.Ident}");
            result.Add(fix);
        }
        return result;
    }
}
