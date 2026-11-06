namespace Fpd.Core;

public readonly record struct ProjectedPoint(double Easting, double Northing, double Z, int Epsg, double CentralMeridian);

/// CGCS2000 three-degree Gauss-Kruger CM, false easting 500000 m, false northing 0 m.
public static class Cgcs2000Projection
{
    public static (int Epsg, double CentralMeridian) ZoneForLongitude(double longitude)
    {
        if (!double.IsFinite(longitude) || longitude < 73.5 || longitude >= 136.5)
            throw new ArgumentOutOfRangeException(nameof(longitude), "ARP 经度须在 CGCS2000 三度带 CM75E–CM135E 范围内。");
        var zone = (int)Math.Floor((longitude + 1.5) / 3.0);
        var cm = zone * 3.0;
        return (4509 + zone, cm); // EPSG:4548 when zone=117/3=39.
    }

    public static ProjectedPoint Forward(double latitude, double longitude, double? z = null)
    {
        var (epsg, cm) = ZoneForLongitude(longitude);
        return ForwardInZone(latitude, longitude, cm, z);
    }

    // All project points use the airport ARP central meridian, including points crossing a zone boundary.
    public static ProjectedPoint ForwardInZone(double latitude, double longitude, double centralMeridian, double? z = null)
    {
        ProjectValidation.Coordinates(latitude, longitude, z);
        var (epsg, cm) = ZoneForLongitude(centralMeridian);
        if (cm != centralMeridian || Math.Abs(longitude - cm) > 6)
            throw new ArgumentException("中央经线须为三度带 CM 值；定位点距中央经线不得超过 6°。");
        const double a = 6378137.0;
        const double invF = 298.257222101;
        var f = 1.0 / invF;
        var e2 = f * (2 - f);
        var ep2 = e2 / (1 - e2);
        var lat = latitude * Math.PI / 180.0;
        var dLon = (longitude - cm) * Math.PI / 180.0;
        var sin = Math.Sin(lat); var cos = Math.Cos(lat); var tan = Math.Tan(lat);
        var n = a / Math.Sqrt(1 - e2 * sin * sin);
        var t = tan * tan; var c = ep2 * cos * cos; var aa = cos * dLon;
        var m = a * ((1 - e2 / 4 - 3 * Math.Pow(e2, 2) / 64 - 5 * Math.Pow(e2, 3) / 256) * lat
            - (3 * e2 / 8 + 3 * Math.Pow(e2, 2) / 32 + 45 * Math.Pow(e2, 3) / 1024) * Math.Sin(2 * lat)
            + (15 * Math.Pow(e2, 2) / 256 + 45 * Math.Pow(e2, 3) / 1024) * Math.Sin(4 * lat)
            - (35 * Math.Pow(e2, 3) / 3072) * Math.Sin(6 * lat));
        var east = 500000 + n * (aa + (1 - t + c) * Math.Pow(aa, 3) / 6 + (5 - 18 * t + t * t + 72 * c - 58 * ep2) * Math.Pow(aa, 5) / 120);
        var north = m + n * tan * (aa * aa / 2 + (5 - t + 9 * c + 4 * c * c) * Math.Pow(aa, 4) / 24 + (61 - 58 * t + t * t + 600 * c - 330 * ep2) * Math.Pow(aa, 6) / 720);
        return new ProjectedPoint(east, north, z ?? 0, epsg, cm);
    }
}
