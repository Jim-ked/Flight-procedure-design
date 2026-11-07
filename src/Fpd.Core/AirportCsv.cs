namespace Fpd.Core;

public static class RunwayCsv
{
    private static readonly string[] Columns = new[] { "Ident","Width" }.Concat(new[] { "A","B" }.SelectMany(end=>
        new[] { end+"_Designator" }.Concat(new[] { "End","Thr","Der" }.SelectMany(p=>new[] { "Latitude","Longitude","Elevation" }.Select(c=>end+"_"+p+c))))).ToArray();
    public static IReadOnlyList<RunwayData> ParseText(string text,IEnumerable<string>? existing=null) => PointCsv.Read(text,Columns,Columns.Length,existing,v=>
    {
        GeoPosition Position(int i)=>new() { Latitude=PointCsv.Number(v[i]),Longitude=PointCsv.Number(v[i+1]),Elevation=PointCsv.Number(v[i+2]) };
        RunwayEndData End(int i)=>new() { Designator=v[i],PhysicalEnd=Position(i+1),Threshold=Position(i+4),DepartureEnd=Position(i+7) };
        var runway=new RunwayData { Ident=v[0],Width=PointCsv.Number(v[1]),EndA=End(2),EndB=End(12) };
        ProjectValidation.Runway(runway); return runway;
    });
    public static string Export(IEnumerable<RunwayData> runways) => PointCsv.Write(Columns,runways.Select(r=>
        new[] { r.Ident,PointCsv.Format(r.Width) }.Concat(new[] { r.EndA,r.EndB }.SelectMany(e=>new[] { e.Designator }.Concat(
            new[] { e.PhysicalEnd,e.Threshold,e.DepartureEnd }.SelectMany(p=>new[] { PointCsv.Format(p.Latitude),PointCsv.Format(p.Longitude),PointCsv.Format(p.Elevation) })))).ToArray()),",");
}

public static class NavaidCsv
{
    private static readonly string[] Columns = ["Ident","Name","Kind","Latitude","Longitude","Elevation","FrequencyMHz","FrequencyKHz","Channel","MagneticVariation","GpLatitude","GpLongitude","GpElevation","GpAngle"];
    public static IReadOnlyList<NavaidData> ParseText(string text,IEnumerable<string>? existing=null) => PointCsv.Read(text,Columns,6,existing,v=>
    {
        if(!Enum.TryParse<NavaidKind>(v[2],true,out var kind) || !Enum.IsDefined(kind)) throw new FormatException("设施类型须为VOR/DME/NDB/ILS。");
        var gp=v[10].Length+v[11].Length+v[12].Length>0 ? new GeoPosition { Latitude=PointCsv.Number(v[10]),Longitude=PointCsv.Number(v[11]),Elevation=PointCsv.Number(v[12]) } : null;
        var n=new NavaidData { Ident=v[0],Name=v[1],Kind=kind,Position=new() { Latitude=PointCsv.Number(v[3]),Longitude=PointCsv.Number(v[4]),Elevation=PointCsv.Number(v[5]) },
            FrequencyMHz=PointCsv.Optional(v[6]),FrequencyKHz=PointCsv.Optional(v[7]),Channel=string.IsNullOrWhiteSpace(v[8])?null:v[8],MagneticVariation=PointCsv.Optional(v[9]),GlidePathPosition=gp,GlidePathAngle=PointCsv.Optional(v[13]) };
        ProjectValidation.Navaid(n); return n;
    }, [1]);
    public static string Export(IEnumerable<NavaidData> rows) => PointCsv.Write(Columns,rows.Select(n=>new[] { n.Ident,n.Name,n.Kind.ToString(),PointCsv.Format(n.Position.Latitude),PointCsv.Format(n.Position.Longitude),PointCsv.Format(n.Position.Elevation),
        PointCsv.Format(n.FrequencyMHz),PointCsv.Format(n.FrequencyKHz),n.Channel??"",PointCsv.Format(n.MagneticVariation),PointCsv.Format(n.GlidePathPosition?.Latitude),PointCsv.Format(n.GlidePathPosition?.Longitude),PointCsv.Format(n.GlidePathPosition?.Elevation),PointCsv.Format(n.GlidePathAngle) }),",");
}
