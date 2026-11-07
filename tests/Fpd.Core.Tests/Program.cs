using System.Globalization;
using Fpd.Core;

var passed = 0;
var failed = 0;
var work = Path.Combine(AppContext.BaseDirectory, "test-data-" + Guid.NewGuid().ToString("N"));
Directory.CreateDirectory(work);
void Test(string name, Action action)
{
    try { action(); passed++; Console.WriteLine("PASS " + name); }
    catch (Exception ex) { failed++; Console.WriteLine("FAIL " + name + ": " + ex.Message); }
}
void Check(bool value) { if (!value) throw new Exception("Assertion failed"); }
void Near(double actual, double expected) { if (Math.Abs(actual - expected) > 0.001) throw new Exception($"{actual:R} != {expected:R}"); }
void Reject(Action action)
{
    try { action(); } catch (ArgumentException) { return; } catch (InvalidDataException) { return; } catch (FormatException) { return; }
    throw new Exception("Invalid input was accepted");
}
ProjectData Sample() => new()
{
    Name = "天津 F0 验收", DwgPath = "Tianjin.dwg",
    Airport = new() { Name = "天津滨海", Icao = "ZBTJ", ArpLatitude = 39.124353, ArpLongitude = 117.346183 },
    Fixes = [new() { Ident = "TJ001", Latitude = 39.2, Longitude = 117.3, Elevation = 12.5 }, new() { Ident = "TJ002", Latitude = 39.2, Longitude = 118.6 }],
    Procedures = [new() { Name = "F0 APP", Kind = ProcedureKind.Approach, Runway = "16", FixIdents = ["TJ002", "TJ001", "TJ002"] }]
};
var store = new ProjectStore();
try
{
    Test("F0 JSON without Obstacles remains readable", () =>
    {
        var path = Path.Combine(work, "old.json"); File.WriteAllText(path, "{\"Name\":\"old\"}");
        Check(store.Open(path).Obstacles.Count == 0);
    });
    Test("Obstacle top elevation is distinct from height and ground", () =>
    {
        var rows = ObstacleCsv.ParseText("Ident,Latitude,Longitude,TopElevation,Height,GroundElevation\nO1,39.2,117.3,80,30,50\n");
        var p = Sample(); p.Obstacles.AddRange(rows); var path = Path.Combine(work, "obstacles.json"); store.Save(p, path);
        var opened = store.Open(path); Check(opened.Obstacles[0].Height == 30 && opened.Obstacles[0].GroundElevation == 50);
        var plotted = PointProjection.Obstacles(opened, opened.Obstacles); Check(plotted[0].Point.Z == 80);
        Reject(() => ObstacleCsv.ParseText("Ident,Latitude,Longitude,Height\nO1,39,117,30"));
    });
    Test("batch errors report source row and do not change existing project", () =>
    {
        var p = Sample();
        try { p.Fixes.AddRange(FixCsv.ParseText("Ident,Latitude,Longitude,Elevation\nTJ907,39,117,\nTJ001,39,117,", p.Fixes.Select(f => f.Ident))); throw new Exception("Accepted duplicate"); }
        catch (InvalidDataException ex) { Check(ex.Message.Contains("3") && ex.Message.Contains("TJ001")); }
        Check(p.Fixes.Count == 2);
        try { ObstacleCsv.ParseText("Ident,Latitude,Longitude,TopElevation\nO1,39,117,80\nO2,91,117,90"); throw new Exception("Accepted invalid latitude"); }
        catch (InvalidDataException ex) { Check(ex.Message.Contains("3")); }
    });
    Test("TSV paste and reordered CSV headers round trip", () =>
    {
        var fixes = FixCsv.ParseText("Longitude\tIdent\tLatitude\tElevation\n117.3\tTJ907\t39.2\t\n");
        Check(FixCsv.ParseText(FixCsv.Export(fixes))[0].Ident == "TJ907");
        var obstacles = ObstacleCsv.ParseText("O1,39.2,117.3,80,30,50");
        Check(ObstacleCsv.ParseText(ObstacleCsv.Export(obstacles))[0].TopElevation == 80);
    });
    Test("batch uses airport CM and refuses empty selection", () =>
    {
        var p = Sample(); var points = PointProjection.Fixes(p, p.Fixes);
        Near(points[1].Point.Easting, 638214.8574548216); Check(points.All(x => x.Point.Epsg == 4548));
        Reject(() => PointProjection.Fixes(p, []));
    });
    Test("CSV export quotes every accepted separator in an identifier", () =>
    {
        var fixes = new[] { new FixData { Ident = "A;B,C", Latitude = 39, Longitude = 117 } };
        Check(FixCsv.ParseText(FixCsv.Export(fixes))[0].Ident == "A;B,C");
    });
    Test("Fix rename deletion and repeated Procedure order stay consistent", () =>
    {
        var p = Sample(); ProjectEdits.ReplaceFix(p, p.Fixes[1], new() { Ident = "TJ906", Latitude = 39.2, Longitude = 118.6 });
        Check(p.Procedures[0].FixIdents.SequenceEqual(new[] { "TJ906", "TJ001", "TJ906" }));
        ProjectEdits.MoveReference(p.Procedures[0], 1, -1); Check(p.Procedures[0].FixIdents[0] == "TJ001");
        ProjectEdits.DeleteFixes(p, ["TJ906"]); Check(p.Procedures[0].FixIdents.SequenceEqual(new[] { "TJ001" }));
    });
    Test("Tianjin ARP selects CM117 / EPSG:4548", () => Check(Cgcs2000Projection.ZoneForLongitude(117.346183) is (4548, 117)));
    Test("three-degree boundary selects east zone", () => Check(Cgcs2000Projection.ZoneForLongitude(118.5) is (4549, 120)));
    Test("non-finite latitude rejected", () => Reject(() => Cgcs2000Projection.Forward(double.NaN, 117)));
    Test("invalid longitude rejected", () => Reject(() => Cgcs2000Projection.Forward(39, double.PositiveInfinity)));
    Test("unsupported CGCS2000 zone rejected", () => Reject(() => Cgcs2000Projection.ZoneForLongitude(0)));
    Test("Tianjin independent PROJ values", () =>
    {
        var p = Cgcs2000Projection.Forward(39.124353, 117.346183);
        Near(p.Easting, 529936.0628666884); Near(p.Northing, 4332366.307251088); Check(p.Z == 0);
    });
    Test("point across zone boundary keeps airport CM", () =>
    {
        var p = Cgcs2000Projection.ForwardInZone(39.2, 118.6, 117, 23);
        Near(p.Easting, 638214.8574548216); Near(p.Northing, 4341927.356207282); Check(p.Epsg == 4548 && p.Z == 23);
    });
    Test("central meridian keeps full northing", () =>
    {
        var p = Cgcs2000Projection.ForwardInZone(39, 117, 117);
        Near(p.Easting, 500000); Near(p.Northing, 4318503.984691529);
    });
    Test("zone west edge independent PROJ values", () =>
    {
        var p = Cgcs2000Projection.ForwardInZone(39, 115.5, 117);
        Near(p.Easting, 370057.27276682795); Near(p.Northing, 4319574.560958737);
    });
    Test("non-finite height rejected", () => Reject(() => Cgcs2000Projection.ForwardInZone(39, 117, 117, double.NaN)));
    Test("JSON preserves project ARP Fix and ordered repeated references", () =>
    {
        var project = Sample(); var path = Path.Combine(work, "project.fpd.json"); store.Save(project, path);
        var opened = store.Open(path);
        Check(opened.ProjectId == project.ProjectId && opened.Name == project.Name && opened.DwgPath == "Tianjin.dwg");
        Check(opened.Airport.ArpLatitude == 39.124353 && opened.Fixes[0].Elevation == 12.5);
        Check(opened.Procedures[0].Kind == ProcedureKind.Approach && opened.Procedures[0].Runway == "16" && opened.Procedures[0].FixIdents.SequenceEqual(new[] { "TJ002", "TJ001", "TJ002" }));
        project.Name = "updated"; store.Save(project, path); Check(store.Open(path).Name == "updated");
    });
    Test("all three Procedure kinds preserved", () =>
    {
        var p = Sample(); p.Procedures = Enum.GetValues<ProcedureKind>().Select(k => new ProcedureData { Name = k.ToString(), Kind = k }).ToList();
        var path = Path.Combine(work, "kinds.json"); store.Save(p, path); Check(store.Open(path).Procedures.Count == 3);
    });
    Test("duplicate Fix identifiers rejected", () => { var p = Sample(); p.Fixes.Add(new() { Ident = "tj001", Latitude = 39, Longitude = 117 }); Reject(() => store.Save(p, Path.Combine(work, "duplicate.json"))); });
    Test("unknown Procedure Fix rejected", () => { var p = Sample(); p.Procedures[0].FixIdents.Add("MISSING"); Reject(() => store.Save(p, Path.Combine(work, "missing.json"))); });
    Test("Holding is not a fourth Procedure kind", () => { var p = Sample(); p.Procedures[0].Kind = (ProcedureKind)3; Reject(() => store.Save(p, Path.Combine(work, "holding.json"))); });
    Test("incomplete ARP rejected", () => { var p = Sample(); p.Airport.ArpLongitude = null; Reject(() => store.Save(p, Path.Combine(work, "arp.json"))); });
    Test("null airport JSON rejected", () => { var path = Path.Combine(work, "invalid.json"); File.WriteAllText(path, "{\"Airport\":null}"); Reject(() => store.Open(path)); });
    Test("CSV imports header quoted ident optional height", () =>
    {
        var path = Path.Combine(work, "fix.csv"); File.WriteAllText(path, "Ident,Latitude,Longitude,Elevation\n\"TJ003\",39.21,117.31,12.5\nTJ004,39.22,117.32,\n");
        var fixes = FixCsv.Parse(path); Check(fixes.Count == 2 && fixes[0].Ident == "TJ003" && fixes[0].Elevation == 12.5 && fixes[1].Elevation is null);
    });
    Test("CSV rejects invalid latitude before returning batch", () =>
    {
        var path = Path.Combine(work, "bad.csv"); File.WriteAllText(path, "Ident,Latitude,Longitude,Elevation\nA,39,117,\nB,91,117,\n"); Reject(() => FixCsv.Parse(path));
    });
    Test("CSV duplicate batch identifiers rejected", () =>
    {
        var path = Path.Combine(work, "dupe.csv"); File.WriteAllText(path, "A,39,117,\na,39.1,117.1,\n"); Reject(() => FixCsv.Parse(path));
    });
    Test("decimal coordinates independent of current locale", () =>
    {
        var previous = CultureInfo.CurrentCulture;
        try { CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("fr-FR"); var path = Path.Combine(work, "locale.csv"); File.WriteAllText(path, "A,39.2,117.3,12.5\n"); Check(FixCsv.Parse(path)[0].Elevation == 12.5); }
        finally { CultureInfo.CurrentCulture = previous; }
    });
}
finally { Directory.Delete(work, true); }
Console.WriteLine($"Fpd.Core tests: {passed} passed, {failed} failed");
return failed == 0 ? 0 : 1;
