namespace Fpd.Core;

public sealed class ProjectData
{
    public int WorkspaceVersion { get; set; } = 1;
    public string ProjectId { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = "未命名项目";
    public AirportData Airport { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public string? DwgPath { get; set; }
    public List<FixData> Fixes { get; set; } = [];
    public List<ObstacleData> Obstacles { get; set; } = [];
    public List<ProcedureData> Procedures { get; set; } = [];
    public List<RunwayData> Runways { get; set; } = [];
    public List<NavaidData> Navaids { get; set; } = [];
}

public sealed class AirportData
{
    public string Name { get; set; } = "";
    public string Icao { get; set; } = "";
    public double? ArpLatitude { get; set; }
    public double? ArpLongitude { get; set; }
    public double? ArpElevation { get; set; }
}

public sealed class FixData
{
    public string DataId { get; set; } = "";
    public string Ident { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    // Legacy/known CAD Z only; project editing and CSV never request a program altitude.
    public double? Elevation { get; set; }
}

// Values 0-2 are kept stable for existing numeric JSON files.
public enum ProcedureKind { Departure, Arrival, Approach, Missed, Holding }

public sealed class ObstacleData
{
    public string DataId { get; set; } = "";
    public string Ident { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    // Absolute top elevation in metres; never inferred from the obstacle's own height.
    public double TopElevation { get; set; } = double.NaN;
    // Compatibility setter accepts old JSON; the current value is always derived.
    public double? Height { get => GroundElevation.HasValue ? TopElevation - GroundElevation.Value : _legacyHeight; set => _legacyHeight = value; }
    private double? _legacyHeight;
    public double? GroundElevation { get; set; }
}

public sealed class ProcedureData
{
    public string ProcedureId { get; set; } = Guid.NewGuid().ToString("N");
    public List<ProcedurePath> Paths { get; set; } = [];
    public bool PathsMigrated { get; set; }
    public string Name { get; set; } = "";
    public ProcedureKind Kind { get; set; }
    // Missed procedures must reference their parent Approach; Holding may optionally reference a parent procedure.
    public string? ParentProcedureId { get; set; }
    public string? Runway { get; set; }
    public List<string> FixIdents { get; set; } = [];
    public List<ProcedureSection> Sections { get; set; } = [];
}

public sealed record ProjectSummary(string ProjectId, string Name, int FixCount, int ProcedureCount);
