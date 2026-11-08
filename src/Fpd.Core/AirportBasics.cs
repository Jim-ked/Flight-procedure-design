namespace Fpd.Core;

public sealed class GeoPosition
{
    public double Latitude { get; set; } = double.NaN;
    public double Longitude { get; set; } = double.NaN;
    public double? Elevation { get; set; }
}

public sealed class RunwayEndData
{
    public string Designator { get; set; } = "";
    public GeoPosition PhysicalEnd { get; set; } = new();
    public GeoPosition Threshold { get; set; } = new();
    public GeoPosition DepartureEnd { get; set; } = new();
}

public sealed class RunwayData
{
    public string DataId { get; set; } = "";
    public string Ident { get; set; } = "";
    public double Width { get; set; } = double.NaN;
    public RunwayEndData EndA { get; set; } = new();
    public RunwayEndData EndB { get; set; } = new();
}

public enum NavaidKind { VOR, DME, NDB, ILS }
public sealed class NavaidData
{
    public string DataId { get; set; } = "";
    public string Ident { get; set; } = "";
    public string Name { get; set; } = "";
    public NavaidKind Kind { get; set; }
    public GeoPosition Position { get; set; } = new();
    public double? FrequencyMHz { get; set; }
    public double? FrequencyKHz { get; set; }
    public string? Channel { get; set; }
    public double? MagneticVariation { get; set; }
    public GeoPosition? GlidePathPosition { get; set; }
    public double? GlidePathAngle { get; set; }
}

public enum ProcedureStage { Main, Missed }
public enum ProcedureBranch { Common, RunwayTransition, Transition }
public sealed class ProcedureSection
{
    public string Name { get; set; } = "";
    public ProcedureStage Stage { get; set; }
    public ProcedureBranch Branch { get; set; }
    public string? Runway { get; set; }
    public List<string> FixIdents { get; set; } = [];
}

public static class AirportGeometry
{
    public static double Meridian(ProjectData project) => Cgcs2000Projection.ZoneForLongitude(
        project.Airport.ArpLongitude ?? throw new InvalidOperationException("请先填写机场ARP经纬度。")).CentralMeridian;
    public static ProjectedPoint Project(GeoPosition position, double cm) => Cgcs2000Projection.ForwardInZone(position.Latitude, position.Longitude, cm, position.Elevation);
    public static (double Length, double GridBearing) RunwayAxis(RunwayData runway, double cm)
    {
        var a=Project(runway.EndA.PhysicalEnd,cm); var b=Project(runway.EndB.PhysicalEnd,cm);
        var dx=b.Easting-a.Easting; var dy=b.Northing-a.Northing;
        return (Math.Sqrt(dx*dx+dy*dy),(Math.Atan2(dx,dy)*180/Math.PI+360)%360);
    }
}
