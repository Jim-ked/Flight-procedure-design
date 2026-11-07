namespace Fpd.Core;

public sealed record PlotPoint(string Ident, ProjectedPoint Point, bool IsObstacle);

public static class PointProjection
{
    private static double Meridian(ProjectData project)
    {
        ProjectValidation.Project(project);
        return Cgcs2000Projection.ZoneForLongitude(project.Airport.ArpLongitude ?? throw new InvalidOperationException("请编辑机场资料，填写 ARP 经纬度。")).CentralMeridian;
    }
    public static IReadOnlyList<PlotPoint> Fixes(ProjectData project, IEnumerable<FixData> fixes)
    {
        var cm = Meridian(project);
        return RequirePoints(fixes.Select(f => new PlotPoint(f.Ident, Cgcs2000Projection.ForwardInZone(f.Latitude, f.Longitude, cm, f.Elevation), false)).ToArray());
    }
    public static IReadOnlyList<PlotPoint> Obstacles(ProjectData project, IEnumerable<ObstacleData> obstacles)
    {
        var cm = Meridian(project);
        return RequirePoints(obstacles.Select(o => new PlotPoint(o.Ident, Cgcs2000Projection.ForwardInZone(o.Latitude, o.Longitude, cm, o.TopElevation), true)).ToArray());
    }
    public static IReadOnlyList<PlotPoint> Arp(ProjectData project)
    {
        var cm = Meridian(project); var airport = project.Airport;
        return [new("ARP", Cgcs2000Projection.ForwardInZone(airport.ArpLatitude!.Value, airport.ArpLongitude!.Value, cm, airport.ArpElevation), false)];
    }
    private static IReadOnlyList<PlotPoint> RequirePoints(PlotPoint[] points) => points.Length > 0 ? points : throw new ArgumentException("请明确选择至少一个点；未选择时不会绘制 ARP。");
}

public static class ProjectEdits
{
    public static void ReplaceFix(ProjectData project, FixData? previous, FixData value)
    {
        ProjectValidation.Fix(value);
        if (project.Fixes.Any(f => f != previous && f.Ident.Equals(value.Ident, StringComparison.OrdinalIgnoreCase))) throw new InvalidDataException("定位点标识已存在。");
        if (previous is null) project.Fixes.Add(value);
        else
        {
            var index = project.Fixes.IndexOf(previous);
            if (index < 0) throw new InvalidDataException("定位点已不存在。");
            foreach (var procedure in project.Procedures)
            foreach (var sequence in new[] { procedure.FixIdents }.Concat(procedure.Sections.Select(s=>s.FixIdents)))
                for (var i = 0; i < sequence.Count; i++)
                    if (sequence[i].Equals(previous.Ident, StringComparison.OrdinalIgnoreCase)) sequence[i] = value.Ident;
            project.Fixes[index] = value;
        }
    }
    public static void DeleteFixes(ProjectData project, IEnumerable<string> selected)
    {
        var ids = selected.ToHashSet(StringComparer.OrdinalIgnoreCase);
        project.Fixes.RemoveAll(f => ids.Contains(f.Ident));
        foreach (var procedure in project.Procedures)
        {
            procedure.FixIdents.RemoveAll(ids.Contains);
            foreach(var section in procedure.Sections) section.FixIdents.RemoveAll(ids.Contains);
        }
    }
    public static int MoveReference(ProcedureData procedure, int index, int direction)
    {
        var target = index + direction;
        if (index < 0 || index >= procedure.FixIdents.Count || target < 0 || target >= procedure.FixIdents.Count) return index;
        (procedure.FixIdents[index], procedure.FixIdents[target]) = (procedure.FixIdents[target], procedure.FixIdents[index]);
        return target;
    }
}
