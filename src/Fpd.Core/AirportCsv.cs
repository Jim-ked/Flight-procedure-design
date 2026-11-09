namespace Fpd.Core;

public static class RunwayCsv
{
    private static readonly string[] Columns = new[] { "Ident","Width" }.Concat(new[] { "A","B" }.SelectMany(end=>
        new[] { end+"_Designator" }.Concat(new[] { "End","Thr","Der" }.SelectMany(p=>new[] { "Latitude","Longitude","Elevation" }.Select(c=>end+"_"+p+c))))).ToArray();
    private static readonly int[] OptionalColumns = Enumerable.Range(6,6).Concat(Enumerable.Range(16,6)).ToArray();
    public static IReadOnlyList<RunwayData> ParseText(string text,IEnumerable<string>? existing=null) => PointCsv.Read(text,Columns,Columns.Length,existing,Create,OptionalColumns);
    private static RunwayData Create(string[] v)
    {
        GeoPosition Position(int i) => new() { Latitude=PointCsv.Number(v[i]),Longitude=PointCsv.Number(v[i+1]),Elevation=PointCsv.Number(v[i+2]) };
        GeoPosition? Override(int i) => v.Skip(i).Take(3).All(string.IsNullOrWhiteSpace) ? null : Position(i);
        RunwayEndData End(int i)=>new() { Designator=v[i],PhysicalEnd=Position(i+1),Threshold=Override(i+4)!,DepartureEnd=Override(i+7)! };
        var runway=new RunwayData { Ident=v[0],Width=PointCsv.Number(v[1]),EndA=End(2),EndB=End(12) };
        RunwayDefaults.Resolve(runway); ProjectValidation.Runway(runway); return runway;
    }
    public static CsvImportResult<RunwayData> ImportText(string text, IEnumerable<RunwayData> existing)
    {
        var parsed=PointCsv.ReadItems(text, Columns, Columns.Length, Create, OptionalColumns);
        var current=existing.ToList();
        var result=PointCsv.Classify(parsed, current, Same);
        var conflicts=result.Conflicts.ToList();
        var added=new List<RunwayData>();
        // Check all parsed directions, including conflicted rows; never select an
        // arbitrary winner when two new runways claim the same operating direction.
        foreach(var runway in result.Added)
        {
            var directions=new[] { runway.EndA.Designator,runway.EndB.Designator };
            var overlaps=current.Concat(parsed.Where(r=>!r.Ident.Equals(runway.Ident,StringComparison.OrdinalIgnoreCase)))
                .Where(r=>directions.Contains(r.EndA.Designator,StringComparer.OrdinalIgnoreCase) || directions.Contains(r.EndB.Designator,StringComparer.OrdinalIgnoreCase))
                .Select(r=>r.Ident).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            if(overlaps.Count>0) conflicts.Add($"{runway.Ident}（运行方向与 {string.Join("、",overlaps)} 重复）");
            else added.Add(runway);
        }
        return new(added,result.Skipped,conflicts);
    }

    // Apply the same THR/DER defaults as Resolve, without mutating existing project records.
    private static bool Same(RunwayData a, RunwayData b) => a.Width == b.Width &&
        SameEnd(a.EndA, a.EndB, b.EndA, b.EndB) && SameEnd(a.EndB, a.EndA, b.EndB, b.EndA);
    private static bool SameEnd(RunwayEndData a, RunwayEndData oppositeA, RunwayEndData b, RunwayEndData oppositeB) =>
        string.Equals(a.Designator,b.Designator,StringComparison.OrdinalIgnoreCase) &&
        RunwayDefaults.Same(a.PhysicalEnd,b.PhysicalEnd) &&
        RunwayDefaults.Same(a.Threshold ?? a.PhysicalEnd,b.Threshold ?? b.PhysicalEnd) &&
        RunwayDefaults.Same(a.DepartureEnd ?? oppositeA.PhysicalEnd,b.DepartureEnd ?? oppositeB.PhysicalEnd);
    public static string Export(IEnumerable<RunwayData> runways) => PointCsv.Write(Columns,runways.Select(r=>
        new[] { r.Ident,PointCsv.Format(r.Width) }.Concat(new[] { r.EndA,r.EndB }.SelectMany(e=>new[] { e.Designator }.Concat(
            new[] { e.PhysicalEnd,e.Threshold,e.DepartureEnd }.SelectMany(p=>new[] { PointCsv.Format(p.Latitude),PointCsv.Format(p.Longitude),PointCsv.Format(p.Elevation) })))).ToArray()),",");
}

public static class NavaidCsv
{
    private static readonly string[] Columns = ["Ident","Kind","Latitude","Longitude"];
    public static IReadOnlyList<NavaidData> ParseText(string text,IEnumerable<string>? existing=null) => PointCsv.Read(text,Columns,4,existing,Create);
    private static NavaidData Create(string[] v)
    {
        if(!NavaidKindCatalog.TryParseCode(v[1],out var kind)) throw new FormatException("类型代码无效。");
        var n=new NavaidData { Ident=v[0],Kind=kind,Position=new() { Latitude=PointCsv.Number(v[2]),Longitude=PointCsv.Number(v[3]) } };
        ProjectValidation.Navaid(n); return n;
    }
    public static CsvImportResult<NavaidData> ImportText(string text, IEnumerable<NavaidData> existing) => PointCsv.Classify(
        PointCsv.ReadItems(text, Columns, 4, Create), existing,
        (a,b) => a.Kind==b.Kind && a.Position.Latitude==b.Position.Latitude && a.Position.Longitude==b.Position.Longitude);
    public static string Export(IEnumerable<NavaidData> rows) => PointCsv.Write(Columns,rows.Select(n=>new[] { n.Ident,NavaidKindCatalog.Code(n.Kind),PointCsv.Format(n.Position.Latitude),PointCsv.Format(n.Position.Longitude) }),",");
}
