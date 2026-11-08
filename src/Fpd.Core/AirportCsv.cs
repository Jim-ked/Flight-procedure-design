namespace Fpd.Core;

public static class RunwayCsv
{
    private static readonly string[] Columns = new[] { "Ident","Width" }.Concat(new[] { "A","B" }.SelectMany(end=>
        new[] { end+"_Designator" }.Concat(new[] { "End","Thr","Der" }.SelectMany(p=>new[] { "Latitude","Longitude","Elevation" }.Select(c=>end+"_"+p+c))))).ToArray();
    public static IReadOnlyList<RunwayData> ParseText(string text,IEnumerable<string>? existing=null) => PointCsv.Read(text,Columns,Columns.Length,existing,v=>
    {
        GeoPosition Position(int i) => new() { Latitude=PointCsv.Number(v[i]),Longitude=PointCsv.Number(v[i+1]),Elevation=PointCsv.Number(v[i+2]) };
        GeoPosition? Override(int i) => v.Skip(i).Take(3).All(string.IsNullOrWhiteSpace) ? null : Position(i);
        RunwayEndData End(int i)=>new() { Designator=v[i],PhysicalEnd=Position(i+1),Threshold=Override(i+4)!,DepartureEnd=Override(i+7)! };
        var runway=new RunwayData { Ident=v[0],Width=PointCsv.Number(v[1]),EndA=End(2),EndB=End(12) };
        RunwayDefaults.Resolve(runway); ProjectValidation.Runway(runway); return runway;
    }, Enumerable.Range(6,6).Concat(Enumerable.Range(16,6)).ToArray());
    public static string Export(IEnumerable<RunwayData> runways) => PointCsv.Write(Columns,runways.Select(r=>
        new[] { r.Ident,PointCsv.Format(r.Width) }.Concat(new[] { r.EndA,r.EndB }.SelectMany(e=>new[] { e.Designator }.Concat(
            new[] { e.PhysicalEnd,e.Threshold,e.DepartureEnd }.SelectMany(p=>new[] { PointCsv.Format(p.Latitude),PointCsv.Format(p.Longitude),PointCsv.Format(p.Elevation) })))).ToArray()),",");
}

public static class NavaidCsv
{
    private static readonly string[] Columns = ["Ident","Kind","Latitude","Longitude"];
    public static IReadOnlyList<NavaidData> ParseText(string text,IEnumerable<string>? existing=null) => PointCsv.Read(text,Columns,4,existing,v=>
    {
        if(!Enum.TryParse<NavaidKind>(v[1],true,out var kind) || !Enum.IsDefined(kind)) throw new FormatException("类型须为VOR/DME/NDB/ILS。");
        var n=new NavaidData { Ident=v[0],Kind=kind,Position=new() { Latitude=PointCsv.Number(v[2]),Longitude=PointCsv.Number(v[3]) } };
        ProjectValidation.Navaid(n); return n;
    });
    public static string Export(IEnumerable<NavaidData> rows) => PointCsv.Write(Columns,rows.Select(n=>new[] { n.Ident,n.Kind.ToString(),PointCsv.Format(n.Position.Latitude),PointCsv.Format(n.Position.Longitude) }),",");
}
