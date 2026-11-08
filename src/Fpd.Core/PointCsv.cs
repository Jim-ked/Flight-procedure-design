using System.Globalization;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace Fpd.Core;

public static class FixCsv
{
    internal static readonly string[] Columns = ["Ident", "Latitude", "Longitude"];
    public static IReadOnlyList<FixData> Parse(string path) => ParseText(File.ReadAllText(path));
    public static IReadOnlyList<FixData> ParseText(string text, IEnumerable<string>? existing = null) => PointCsv.Read(text, Columns, 3, existing, v =>
    {
        var fix = new FixData { Ident = v[0], Latitude = PointCsv.Number(v[1]), Longitude = PointCsv.Number(v[2]) };
        ProjectValidation.Fix(fix); return fix;
    });
    public static string Export(IEnumerable<FixData> rows, string separator = ",") => PointCsv.Write(Columns, rows.Select(f => new[] { f.Ident, PointCsv.Format(f.Latitude), PointCsv.Format(f.Longitude) }), separator);
}

public static class ObstacleCsv
{
    internal static readonly string[] Columns = ["Ident", "Latitude", "Longitude", "TopElevation", "GroundElevation"];
    public static IReadOnlyList<ObstacleData> Parse(string path) => ParseText(File.ReadAllText(path));
    public static IReadOnlyList<ObstacleData> ParseText(string text, IEnumerable<string>? existing = null) => PointCsv.Read(text, Columns, 5, existing, v =>
    {
        var obstacle = new ObstacleData { Ident = v[0], Latitude = PointCsv.Number(v[1]), Longitude = PointCsv.Number(v[2]), TopElevation = PointCsv.Number(v[3]), GroundElevation = PointCsv.Number(v[4]) };
        ProjectValidation.Obstacle(obstacle); return obstacle;
    });
    public static string Export(IEnumerable<ObstacleData> rows, string separator = ",") => PointCsv.Write(Columns, rows.Select(o => new[] { o.Ident, PointCsv.Format(o.Latitude), PointCsv.Format(o.Longitude), PointCsv.Format(o.TopElevation), PointCsv.Format(o.GroundElevation) }), separator);
}

internal static class PointCsv
{
    public static double Number(string value) => double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
    public static double? Optional(string value) => string.IsNullOrWhiteSpace(value) ? null : Number(value);
    public static string Format(double? value) => value?.ToString("G17", CultureInfo.InvariantCulture) ?? "";

    public static IReadOnlyList<T> Read<T>(string text, string[] columns, int required, IEnumerable<string>? existing, Func<string[], T> create, int[]? optionalColumns = null)
    {
        var result = new List<T>();
        var identifiers = new HashSet<string>(existing ?? [], StringComparer.OrdinalIgnoreCase);
        using var reader = new StringReader(text.TrimStart('\uFEFF'));
        using var parser = new TextFieldParser(reader) { HasFieldsEnclosedInQuotes = true, TrimWhiteSpace = true, CommentTokens = ["#"] };
        parser.SetDelimiters(",", ";", "\t");
        var first = true;
        while (!parser.EndOfData)
        {
            var line = parser.LineNumber;
            try
            {
                var values = parser.ReadFields()!;
                if (first)
                {
                    if (!values.SequenceEqual(columns, StringComparer.Ordinal)) throw new FormatException("请使用规定列名和顺序：" + string.Join(",", columns));
                    first = false; continue;
                }
                if (values.Length != columns.Length) throw new FormatException("列数与模板不一致。");
                var ordered = values.Select(v => v.Trim()).ToArray();
                for (var i = 0; i < required; i++) if (string.IsNullOrWhiteSpace(ordered[i]) && !(optionalColumns?.Contains(i)??false)) throw new FormatException("缺少 " + columns[i]);
                var item = create(ordered);
                if (!identifiers.Add(ordered[0])) throw new FormatException("标识已存在或批内重复：" + ordered[0]);
                result.Add(item);
            }
            catch (Exception ex) when (ex is ArgumentException or FormatException or InvalidDataException or MalformedLineException or OverflowException)
            { throw new InvalidDataException($"第 {line} 行：{ex.Message}（整批未导入）", ex); }
        }
        if (result.Count == 0) throw new InvalidDataException("没有可导入的数据行。");
        return result;
    }

    public static string Write(string[] columns, IEnumerable<string[]> rows, string separator)
    {
        string Escape(string value) => value.Contains(separator) || value.IndexOfAny([',', ';', '\t', '"', '\r', '\n']) >= 0 ? "\"" + value.Replace("\"", "\"\"") + "\"" : value;
        var output = new StringBuilder(string.Join(separator, columns)).AppendLine();
        foreach (var row in rows) output.AppendLine(string.Join(separator, row.Select(Escape)));
        return output.ToString();
    }
}
