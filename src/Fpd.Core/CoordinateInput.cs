using System.Globalization;
using System.Text.RegularExpressions;

namespace Fpd.Core;

public static class CoordinateInput
{
    // Explicit separators keep malformed DMS (e.g. 39°75') from becoming a decimal.
    public static double Parse(string text, bool latitude)
    {
        var value = text.Trim().ToUpperInvariant();
        var hemisphere = Regex.Match(value, "[NSEW]$").Value;
        if (hemisphere.Length > 0) value = value[..^1].Trim();
        if (hemisphere.Length > 0 && (latitude ? hemisphere is not ("N" or "S") : hemisphere is not ("E" or "W")))
            throw new FormatException("经纬度方向字母不匹配。");
        var parts = Regex.Split(value.TrimEnd('°', '度'), "[°度′'分″\"秒:\\s]+").Where(p => p.Length > 0).ToArray();
        if (parts.Length is < 1 or > 3) throw new FormatException("请输入十进制度或度分秒。");
        var degrees = double.Parse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture);
        var minutes = parts.Length > 1 ? double.Parse(parts[1], CultureInfo.InvariantCulture) : 0;
        var seconds = parts.Length > 2 ? double.Parse(parts[2], CultureInfo.InvariantCulture) : 0;
        if (minutes < 0 || minutes >= 60 || seconds < 0 || seconds >= 60 ||
            parts.Length > 1 && degrees != Math.Truncate(degrees)) throw new FormatException("度分秒格式或分秒范围无效。");
        var negative = value.StartsWith('-');
        if (negative && hemisphere is "N" or "E") throw new FormatException("正负号与方向不一致。");
        var result = (Math.Abs(degrees) + minutes / 60 + seconds / 3600) * (negative || hemisphere is "S" or "W" ? -1 : 1);
        ProjectValidation.Coordinates(latitude ? result : 0, latitude ? 0 : result, null);
        return result;
    }
}
