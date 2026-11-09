using System.Globalization;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace Fpd.Core;

public static class FixCsv
{
    internal static readonly string[] Columns = ["Ident", "Latitude", "Longitude"];
    public static IReadOnlyList<FixData> Parse(string path) => ParseText(File.ReadAllText(path));
    public static IReadOnlyList<FixData> ParseText(string text, IEnumerable<string>? existing = null) => PointCsv.Read(text, Columns, 3, existing, Create);
    private static FixData Create(string[] v)
    {
        var fix = new FixData { Ident = v[0], Latitude = PointCsv.Number(v[1]), Longitude = PointCsv.Number(v[2]) };
        ProjectValidation.Fix(fix); return fix;
    }
    public static CsvImportResult<FixData> ImportText(string text, IEnumerable<FixData> existing) => PointCsv.Classify(
        PointCsv.ReadItems(text, Columns, 3, Create), existing, (a, b) => a.Latitude == b.Latitude && a.Longitude == b.Longitude);
    public static string Export(IEnumerable<FixData> rows, string separator = ",") => PointCsv.Write(Columns, rows.Select(f => new[] { f.Ident, PointCsv.Format(f.Latitude), PointCsv.Format(f.Longitude) }), separator);
}

public static class ObstacleCsv
{
    internal static readonly string[] Columns = ["Ident", "Latitude", "Longitude", "TopElevation", "GroundElevation"];
    public static IReadOnlyList<ObstacleData> Parse(string path) => ParseText(File.ReadAllText(path));
    public static IReadOnlyList<ObstacleData> ParseText(string text, IEnumerable<string>? existing = null) => PointCsv.Read(text, Columns, 5, existing, Create);
    private static ObstacleData Create(string[] v)
    {
        var obstacle = new ObstacleData { Ident = v[0], Latitude = PointCsv.Number(v[1]), Longitude = PointCsv.Number(v[2]), TopElevation = PointCsv.Number(v[3]), GroundElevation = PointCsv.Number(v[4]) };
        ProjectValidation.Obstacle(obstacle); return obstacle;
    }
    public static CsvImportResult<ObstacleData> ImportText(string text, IEnumerable<ObstacleData> existing) => PointCsv.Classify(
        PointCsv.ReadItems(text, Columns, 5, Create), existing, (a, b) => a.Latitude == b.Latitude && a.Longitude == b.Longitude && a.TopElevation == b.TopElevation && a.GroundElevation == b.GroundElevation);
    public static string Export(IEnumerable<ObstacleData> rows, string separator = ",") => PointCsv.Write(Columns, rows.Select(o => new[] { o.Ident, PointCsv.Format(o.Latitude), PointCsv.Format(o.Longitude), PointCsv.Format(o.TopElevation), PointCsv.Format(o.GroundElevation) }), separator);
}

public sealed record CsvImportResult<T>(IReadOnlyList<T> Added, IReadOnlyList<string> Skipped, IReadOnlyList<string> Conflicts);

internal static class PointCsv
{
    public static double Number(string value) => double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
    public static double? Optional(string value) => string.IsNullOrWhiteSpace(value) ? null : Number(value);
    public static string Format(double? value) => value?.ToString("G17", CultureInfo.InvariantCulture) ?? "";

    public static IReadOnlyList<T> Read<T>(string text, string[] columns, int required, IEnumerable<string>? existing, Func<string[], T> create, int[]? optionalColumns = null, bool allowDuplicates = false)
    {
        var result = new List<T>();
        var sourceRows = new List<(string Ident, long Line)>();
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
                    if (!values.SequenceEqual(columns, StringComparer.Ordinal)) throw new FormatException($"CSV格式不匹配。当前文件字段：{string.Join(",", values)}；要求字段：{string.Join(",", columns)}");
                    first = false; continue;
                }
                if (values.Length != columns.Length) throw new FormatException("列数与模板不一致。");
                var ordered = values.Select(v => v.Trim()).ToArray();
                for (var i = 0; i < required; i++) if (string.IsNullOrWhiteSpace(ordered[i]) && !(optionalColumns?.Contains(i)??false)) throw new FormatException("缺少 " + columns[i]);
                var item = create(ordered);
                sourceRows.Add((ordered[0], line));
                result.Add(item);
            }
            catch (Exception ex) when (ex is ArgumentException or FormatException or InvalidDataException or MalformedLineException or OverflowException)
            { throw new InvalidDataException($"第 {line} 行：{ex.Message}（整批未导入）", ex); }
        }
        if (first) throw new InvalidDataException("CSV格式不匹配。文件缺少表头；要求字段：" + string.Join(",", columns));
        if (result.Count == 0 && !allowDuplicates) throw new InvalidDataException("没有可导入的数据行。");
        if (!allowDuplicates)
            foreach (var row in sourceRows)
                if (!identifiers.Add(row.Ident))
                    throw new InvalidDataException($"第 {row.Line} 行：标识已存在或批内重复：{row.Ident}（整批未导入）");
        return result;
    }

    internal static IReadOnlyList<T> ReadItems<T>(string text, string[] columns, int required, Func<string[], T> create, int[]? optionalColumns = null) =>
        Read(text, columns, required, null, create, optionalColumns, allowDuplicates: true);

    internal static CsvImportResult<T> Classify<T>(IReadOnlyList<T> parsed, IEnumerable<T> existing, Func<T, T, bool> same)
    {
        var existingByIdent = existing.GroupBy(Ident, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);
        var added = new List<T>();
        var skipped = new List<string>();
        var conflicts = new List<string>();
        foreach (var group in parsed.GroupBy(Ident, StringComparer.OrdinalIgnoreCase))
        {
            var rows = group.ToList();
            var first = rows[0];
            if (rows.Skip(1).Any(row => !same(first, row)))
            {
                conflicts.Add($"{group.Key}（CSV内部字段不同）");
                continue;
            }
            if (existingByIdent.TryGetValue(group.Key, out var current))
            {
                if (same(current, first)) foreach (var _ in rows) skipped.Add(group.Key);
                else conflicts.Add($"{group.Key}（与现有数据字段不同）");
                continue;
            }
            added.Add(first);
            foreach (var _ in rows.Skip(1)) skipped.Add(group.Key);
        }
        return new CsvImportResult<T>(added, skipped, conflicts);
    }

    private static string Ident<T>(T value) => value switch
    {
        FixData f => f.Ident,
        ObstacleData o => o.Ident,
        RunwayData r => r.Ident,
        NavaidData n => n.Ident,
        _ => throw new ArgumentException("CSV记录缺少业务标识。")
    };

    public static string Write(string[] columns, IEnumerable<string[]> rows, string separator)
    {
        string Escape(string value) => value.Contains(separator) || value.IndexOfAny([',', ';', '\t', '"', '\r', '\n']) >= 0 ? "\"" + value.Replace("\"", "\"\"") + "\"" : value;
        var output = new StringBuilder(string.Join(separator, columns)).AppendLine();
        foreach (var row in rows) output.AppendLine(string.Join(separator, row.Select(Escape)));
        return output.ToString();
    }
}
