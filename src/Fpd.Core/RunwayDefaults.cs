namespace Fpd.Core;

public static class RunwayDefaults
{
    public static GeoPosition Copy(GeoPosition p) => new() { Latitude=p.Latitude, Longitude=p.Longitude, Elevation=p.Elevation };
    public static bool Same(GeoPosition? a, GeoPosition? b) => a is not null && b is not null &&
        a.Latitude==b.Latitude && a.Longitude==b.Longitude && a.Elevation==b.Elevation;
    public static void Resolve(RunwayData runway)
    {
        runway.EndA.Threshold ??= Copy(runway.EndA.PhysicalEnd);
        runway.EndB.Threshold ??= Copy(runway.EndB.PhysicalEnd);
        runway.EndA.DepartureEnd ??= Copy(runway.EndB.PhysicalEnd);
        runway.EndB.DepartureEnd ??= Copy(runway.EndA.PhysicalEnd);
    }
    public static bool Opposite(string a, string b)
    {
        var pattern = @"^(0[1-9]|[12][0-9]|3[0-6])([LRC]?)$";
        var ma=System.Text.RegularExpressions.Regex.Match(a.ToUpperInvariant(),pattern);
        var mb=System.Text.RegularExpressions.Regex.Match(b.ToUpperInvariant(),pattern);
        if (!ma.Success || !mb.Success) return false;
        var suffix=ma.Groups[2].Value switch { "L"=>"R", "R"=>"L", var s=>s };
        return (int.Parse(ma.Groups[1].Value)+17)%36+1==int.Parse(mb.Groups[1].Value) && suffix==mb.Groups[2].Value;
    }
}
