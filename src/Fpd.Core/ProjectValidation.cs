namespace Fpd.Core;

public static class ProjectValidation
{
    public static void Coordinates(double latitude, double longitude, double? elevation)
    {
        if (!double.IsFinite(latitude) || latitude <= -90 || latitude >= 90 ||
            !double.IsFinite(longitude) || longitude < -180 || longitude > 180 ||
            (elevation.HasValue && !double.IsFinite(elevation.Value)))
            throw new ArgumentException("经纬度须为有限十进制度（纬度 -90° 至 90°之间、经度 ±180°）；高程须为有限米值。");
    }

    public static void Fix(FixData fix)
    {
        if (fix is null || string.IsNullOrWhiteSpace(fix.Ident)) throw new InvalidDataException("定位点标识不能为空。");
        Coordinates(fix.Latitude, fix.Longitude, fix.Elevation);
    }

    public static void Project(ProjectData project)
    {
        if (project is null || string.IsNullOrWhiteSpace(project.ProjectId) || string.IsNullOrWhiteSpace(project.Name) ||
            project.Airport is null || project.Fixes is null || project.Procedures is null)
            throw new InvalidDataException("项目标识、名称、机场或数据列表无效。");
        var airport = project.Airport;
        if (airport.ArpLatitude.HasValue != airport.ArpLongitude.HasValue)
            throw new InvalidDataException("ARP 经纬度须同时填写或同时留空。");
        if (airport.ArpLatitude.HasValue)
        {
            Coordinates(airport.ArpLatitude.Value, airport.ArpLongitude!.Value, airport.ArpElevation);
            Cgcs2000Projection.ZoneForLongitude(airport.ArpLongitude.Value);
        }
        if (airport.ArpElevation.HasValue && !double.IsFinite(airport.ArpElevation.Value))
            throw new InvalidDataException("ARP 高程无效。");
        var identifiers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var fix in project.Fixes)
        {
            Fix(fix);
            if (!identifiers.Add(fix.Ident)) throw new InvalidDataException($"定位点标识重复：{fix.Ident}");
        }
        foreach (var procedure in project.Procedures)
        {
            if (procedure is null || string.IsNullOrWhiteSpace(procedure.Name) || !Enum.IsDefined(procedure.Kind) || procedure.FixIdents is null)
                throw new InvalidDataException("程序名称、类型或定位点顺序无效。");
            foreach (var ident in procedure.FixIdents)
                if (ident is null || !identifiers.Contains(ident)) throw new InvalidDataException($"程序引用未知定位点：{ident}");
        }
    }
}
