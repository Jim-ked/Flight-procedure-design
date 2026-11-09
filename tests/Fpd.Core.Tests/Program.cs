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
    Test("manual DMS input validates hemisphere and minute range", () =>
    {
        Near(CoordinateInput.Parse("39°07′27.67″N",true),39+7.0/60+27.67/3600);
        Near(CoordinateInput.Parse("117 20 46.26 E",false),117+20.0/60+46.26/3600);
        Near(CoordinateInput.Parse("-0°30'",true),-.5);
        Reject(()=>CoordinateInput.Parse("39°60'",true)); Reject(()=>CoordinateInput.Parse("117N",false));
    });
    Test("runway defaults use opposite physical end regardless of displaced threshold", () =>
    {
        var r=new RunwayData { Ident="16R/34L",Width=45,
            EndA=new() { Designator="16R",PhysicalEnd=new() { Latitude=39.14,Longitude=117.34,Elevation=3 },Threshold=null!,DepartureEnd=null! },
            EndB=new() { Designator="34L",PhysicalEnd=new() { Latitude=39.11,Longitude=117.34,Elevation=6 },Threshold=new() { Latitude=39.111,Longitude=117.34,Elevation=7 },DepartureEnd=null! } };
        RunwayDefaults.Resolve(r); ProjectValidation.Runway(r);
        Check(RunwayDefaults.Same(r.EndA.DepartureEnd,r.EndB.PhysicalEnd)); Check(!RunwayDefaults.Same(r.EndA.DepartureEnd,r.EndB.Threshold));
        Check(RunwayDefaults.Opposite("16R","34L") && !RunwayDefaults.Opposite("16R","34R"));
        var csv=RunwayCsv.Export([r]); Check(RunwayCsv.ParseText(csv)[0].EndB.Threshold.Elevation==7);
    });
    Test("DWG auxiliary path follows Save As and ignores legacy association", () =>
    {
        Check(ProjectStore.AuxiliaryPath(Path.Combine(work,"A.dwg"))==Path.Combine(work,"A.fpd.json"));
        Reject(()=>ProjectStore.AuxiliaryPath("Drawing1.dwg"));
        var p=ProjectStore.Deserialize("{\"Name\":\"legacy\",\"DwgPath\":\"C:/other.dwg\"}"); Check(p.DwgPath is null);
    });
    Test("WsGis CM105 sample agrees with existing CGCS2000 projection", () =>
    {
        var p=Cgcs2000Projection.ForwardInZone(37+31.0/60+25.25/3600,105+20.0/60+32.92/3600,105,300);
        Near(p.Easting,530274.230418334); Near(p.Northing,4154685.49330783);
    });
    Test("legacy paths migrate separately once with stable IDs and coordinates", () =>
    {
        var p=Sample(); var proc=p.Procedures[0];
        proc.Sections.Add(new() { Name="复飞段",Stage=ProcedureStage.Missed,Branch=ProcedureBranch.Transition,Runway="34",FixIdents=["TJ001","TJ001"] });
        var file=Path.Combine(work,"migration.json"); File.WriteAllText(file,System.Text.Json.JsonSerializer.Serialize(p));
        var opened=store.Open(file); var q=opened.Procedures[0];
        Check(q.Paths.Count==2 && q.Paths[0].Fixes.Select(f=>f.FixIdent).SequenceEqual(proc.FixIdents));
        Check(q.Paths[1].IsMissed && q.Paths[1].Runway=="34" && q.Paths[1].Fixes.Count==2 && q.Paths[1].MigrationNote!.Contains("Transition"));
        var id=q.Paths[0].PathId; store.Save(opened,file); var again=store.Open(file);
        Check(again.Procedures[0].Paths.Count==2 && again.Procedures[0].Paths[0].PathId==id);
        Near(again.Fixes[0].Longitude,p.Fixes[0].Longitude); Check(again.ProjectId==p.ProjectId);
    });
    Test("named paths preserve independent reference symbols and repeated edits", () =>
    {
        var p=Sample(); var q=p.Procedures[0];
        var a=ProcedurePaths.Add(q,"设计员路径"); var b=ProcedurePaths.Add(q,"另一条");
        Reject(()=>ProcedurePaths.Add(q," ")); Reject(()=>ProcedurePaths.Add(q,"设计员路径"));
        ProcedurePaths.Insert(a,0,["TJ001","TJ002","TJ001"]); ProcedurePaths.Insert(b,0,["TJ001"]);
        a.Fixes[0].SymbolKey="FlyOver"; Check(b.Fixes[0].SymbolKey=="FlyBy" && a.Fixes[2].SymbolKey=="FlyBy");
        var id=a.PathId; ProcedurePaths.Rename(q,a,"改名"); Check(a.PathId==id);
        ProcedurePaths.Move(a,2,-1); a.Fixes.Reverse(); Check(a.Fixes.Select(x=>x.FixIdent).SequenceEqual(new[]{"TJ002","TJ001","TJ001"}));
        ProjectEdits.ReplaceFix(p,p.Fixes[0],new() { Ident="NEW",Latitude=39.2,Longitude=117.3 });
        Check(a.Fixes.Count(x=>x.FixIdent=="NEW")==2 && b.Fixes[0].FixIdent=="NEW");
        ProjectEdits.DeleteFixes(p,["NEW"]); Check(a.Fixes.Count==1 && b.Fixes.Count==0);
    });
    Test("ordered pick cancellation is atomic and keeps repeats", () =>
    {
        var q=new ProcedureData(); var a=ProcedurePaths.Add(q,"选点"); ProcedurePaths.Insert(a,0,["OLD"]);
        var pick=new OrderedFixPick(); pick.Add("B"); pick.Add("A"); pick.Add("B");
        Check(pick.Complete(false) is null && a.Fixes.Count==1);
        var next=new OrderedFixPick(); next.Add("B"); next.Add("A"); next.Add("B");
        ProcedurePaths.Insert(a,1,next.Complete(true)!); Check(a.Fixes.Select(f=>f.FixIdent).SequenceEqual(new[]{"OLD","B","A","B"}));
    });
    Test("base drawing boundary and repeat reconciliation are conservative", () =>
    {
        Check(!BaseMapPolicy.CanWrite(null,@"C:\a.dwg") && !BaseMapPolicy.CanWrite(@"C:\a.dwg",@"C:\b.dwg"));
        Check(BaseMapPolicy.CanWrite(@"C:\a.dwg",@"c:\A.dwg"));
        Check(BaseMapPolicy.Decide(0,false,false)==BaseMapChange.Create);
        Check(BaseMapPolicy.Decide(1,true,false)==BaseMapChange.None);
        Check(BaseMapPolicy.Decide(1,true,true)==BaseMapChange.Update);
        Check(BaseMapPolicy.Decide(1,false,true)==BaseMapChange.Conflict && BaseMapPolicy.Decide(2,true,false)==BaseMapChange.Conflict);
    });
    Test("legacy stable IDs survive repeated opening before saving and keep original backup", () =>
    {
        var p=Sample(); var file=Path.Combine(work,"legacy-ids.json");
        File.WriteAllText(file,System.Text.Json.JsonSerializer.Serialize(p).Replace("\"ProcedureId\":\""+p.Procedures[0].ProcedureId+"\",",""));
        var before=File.ReadAllText(file); var a=store.Open(file); var b=store.Open(file);
        Check(a.Procedures[0].ProcedureId==b.Procedures[0].ProcedureId && a.Procedures[0].Paths[0].PathId==b.Procedures[0].Paths[0].PathId);
        Check(a.Fixes[0].DataId==b.Fixes[0].DataId); var dataId=a.Fixes[0].DataId;
        ProjectEdits.ReplaceFix(a,a.Fixes[0],new() { Ident="RENAMED",Latitude=39.2,Longitude=117.3 }); Check(a.Fixes[0].DataId==dataId);
        store.Save(a,file); Check(File.ReadAllText(file+".pre-paths.bak")==before);
    });
    Test("inverse uses fixed airport CM with independent PROJ coordinates", () =>
    {
        var a = Cgcs2000Projection.InverseInZone(529936.0628666884, 4332366.307251088, 117, 23);
        Check(Math.Abs(a.Latitude - 39.124353) < 1e-8 && Math.Abs(a.Longitude - 117.346183) < 1e-8 && a.Elevation == 23);
        var b = Cgcs2000Projection.InverseInZone(638214.8574548216, 4341927.356207282, 117);
        Check(Math.Abs(b.Latitude - 39.2) < 1e-8 && Math.Abs(b.Longitude - 118.6) < 1e-8);
        Reject(() => Cgcs2000Projection.InverseInZone(double.NaN, 0, 117));
    });
    Test("old project defaults F1 collections to empty", () =>
    {
        var path = Path.Combine(work, "f0.json"); File.WriteAllText(path, "{\"Name\":\"old\"}");
        var p = store.Open(path); Check(p.Runways.Count == 0 && p.Navaids.Count == 0);
    });
    Test("runway CSV preserves separate physical THR and DER positions", () =>
    {
        var runway = new RunwayData { Ident="16/34", Width=45,
            EndA=new() { Designator="16",PhysicalEnd=new() { Latitude=39.14,Longitude=117.34,Elevation=3 },Threshold=new() { Latitude=39.139,Longitude=117.34,Elevation=4 },DepartureEnd=new() { Latitude=39.14,Longitude=117.34,Elevation=5 } },
            EndB=new() { Designator="34",PhysicalEnd=new() { Latitude=39.11,Longitude=117.34,Elevation=6 },Threshold=new() { Latitude=39.111,Longitude=117.34,Elevation=7 },DepartureEnd=new() { Latitude=39.11,Longitude=117.34,Elevation=8 } } };
        var parsed=RunwayCsv.ParseText(RunwayCsv.Export([runway]))[0];
        Check(parsed.EndA.PhysicalEnd.Latitude!=parsed.EndA.Threshold.Latitude && parsed.EndA.DepartureEnd.Elevation==5);
        var p=Sample(); p.Runways.Add(parsed); var path=Path.Combine(work,"runway.json"); store.Save(p,path);
        Check(store.Open(path).Runways[0].EndB.Threshold.Elevation==7);
        var axis=AirportGeometry.RunwayAxis(parsed,117); Check(axis.Length>3300 && axis.Length<3400 && axis.GridBearing>179 && axis.GridBearing<181);
        parsed.Width=0; Reject(()=>ProjectValidation.Project(p));
    });
    Test("navaid type units and partial GP are validated before importing", () =>
    {
        var n=new NavaidData { Ident="TJ",Kind=NavaidKind.NDB,Position=new() { Latitude=39.1,Longitude=117.3,Elevation=10 },FrequencyKHz=345 };
        var imported=NavaidCsv.ParseText(NavaidCsv.Export([n]))[0]; Check(imported.Ident=="TJ" && imported.Kind==NavaidKind.NDB && imported.Position.Elevation is null);
        var row=n;
        var p=Sample(); p.Navaids.Add(row); row.FrequencyMHz=110; Reject(()=>ProjectValidation.Project(p)); row.FrequencyMHz=null;
        row.Kind=NavaidKind.ILS; row.FrequencyKHz=null; row.FrequencyMHz=110.3; row.GlidePathPosition=new() { Latitude=39,Longitude=117 };
        ProjectValidation.Project(p); // Legacy optional elevation is not a manufactured zero.
        Reject(()=>NavaidCsv.ParseText("Ident,Name,Kind,Latitude,Longitude,Elevation\nA,A,VOR,39,117,1\nB,B,VOR,91,117,1"));
    });
    Test("sections preserve repeated Fix references and enforce Approach Missed", () =>
    {
        var p=Sample(); p.Procedures[0].Sections.Add(new() { Name="复飞",Stage=ProcedureStage.Missed,Branch=ProcedureBranch.Common,FixIdents=["TJ002","TJ001","TJ002"] });
        var path=Path.Combine(work,"sections.json"); store.Save(p,path); var opened=store.Open(path);
        Check(opened.Procedures[0].Sections[0].FixIdents.Count==3);
        ProjectEdits.ReplaceFix(p,p.Fixes[1],new() { Ident="NEW",Latitude=39.2,Longitude=118.6 });
        Check(p.Procedures[0].Sections[0].FixIdents.SequenceEqual(new[] { "NEW","TJ001","NEW" }));
        p.Procedures[0].Kind=ProcedureKind.Departure; Reject(()=>ProjectValidation.Project(p));
        p.Procedures[0].Kind=ProcedureKind.Approach; ProjectEdits.DeleteFixes(p,["NEW"]);
        Check(p.Procedures[0].Sections[0].FixIdents.SequenceEqual(new[] { "TJ001" }));
    });
    Test("F0 JSON without Obstacles remains readable", () =>
    {
        var path = Path.Combine(work, "old.json"); File.WriteAllText(path, "{\"Name\":\"old\"}");
        Check(store.Open(path).Obstacles.Count == 0);
    });
    Test("Obstacle top elevation is distinct from height and ground", () =>
    {
        var rows = ObstacleCsv.ParseText("Ident,Latitude,Longitude,TopElevation,GroundElevation\nO1,39.2,117.3,80,50\n");
        var p = Sample(); p.Obstacles.AddRange(rows); var path = Path.Combine(work, "obstacles.json"); store.Save(p, path);
        var opened = store.Open(path); Check(opened.Obstacles[0].Height == 30 && opened.Obstacles[0].GroundElevation == 50);
        var plotted = PointProjection.Obstacles(opened, opened.Obstacles); Check(plotted[0].Point.Z == 80);
        Reject(() => ObstacleCsv.ParseText("Ident,Latitude,Longitude,Height\nO1,39,117,30"));
    });
    Test("batch errors report source row and do not change existing project", () =>
    {
        var p = Sample();
        try { p.Fixes.AddRange(FixCsv.ParseText("Ident,Latitude,Longitude\nTJ907,39,117\nTJ001,39,117", p.Fixes.Select(f => f.Ident))); throw new Exception("Accepted duplicate"); }
        catch (InvalidDataException ex) { Check(ex.Message.Contains("3") && ex.Message.Contains("TJ001")); }
        Check(p.Fixes.Count == 2);
        try { ObstacleCsv.ParseText("Ident,Latitude,Longitude,TopElevation,GroundElevation\nO1,39,117,80,50\nO2,91,117,90,50"); throw new Exception("Accepted invalid latitude"); }
        catch (InvalidDataException ex) { Check(ex.Message.Contains("3")); }
    });
    Test("fixed CSV rejects reordered headers and round trips", () =>
    {
        Reject(()=>FixCsv.ParseText("Longitude,Ident,Latitude\n117.3,TJ907,39.2\n"));
        var fixes=FixCsv.ParseText("Ident,Latitude,Longitude\nTJ907,39.2,117.3\n");
        Check(FixCsv.ParseText(FixCsv.Export(fixes))[0].Ident == "TJ907");
        var obstacles = ObstacleCsv.ParseText("Ident,Latitude,Longitude,TopElevation,GroundElevation\nO1,39.2,117.3,80,50");
        Check(ObstacleCsv.ParseText(ObstacleCsv.Export(obstacles))[0].TopElevation == 80);
    });
    Test("CSV imports classify overlap without changing existing fields or stable IDs", () =>
    {
        var existing=new NavaidData { DataId="stable",Ident="TJ",Kind=NavaidKind.VOR_DME,Name="kept",FrequencyMHz=113.3,Position=new() { Latitude=39,Longitude=117,Elevation=9 } };
        var result=NavaidCsv.ImportText("Ident,Kind,Latitude,Longitude\nTJ,VOR/DME,39.000,117.0\nNEW,NDB,39.1,117.2",[existing]);
        Check(result.Added.Count==1 && result.Skipped.Count==1 && result.Conflicts.Count==0);
        Check(existing.DataId=="stable" && existing.Name=="kept" && existing.Position.Elevation==9 && result.Added[0].DataId=="");
        var again=NavaidCsv.ImportText("Ident,Kind,Latitude,Longitude\nTJ,VOR_DME,39,117\nNEW,NDB,39.1,117.2",new[] { existing }.Concat(result.Added));
        Check(again.Added.Count==0 && again.Skipped.Count==2 && again.Conflicts.Count==0);
        var conflict=NavaidCsv.ImportText("Ident,Kind,Latitude,Longitude\nTJ,VOR_DME,40,117\nOTHER,DME,39.2,117.3",[existing]);
        Check(conflict.Added.Single().Ident=="OTHER" && conflict.Conflicts.Single().Contains("TJ") && existing.Position.Latitude==39);
    });
    Test("CSV internal identical rows collapse and conflicting rows never choose a winner", () =>
    {
        var result=FixCsv.ImportText("Ident,Latitude,Longitude\nA,39,117\na,39.0,117.00\nB,39,117\nB,40,117\nC,39,117",[]);
        Check(result.Added.Select(f=>f.Ident).SequenceEqual(new[] { "A","C" }) && result.Skipped.Count==1 && result.Conflicts.Single().Contains("B"));
        var repeated=FixCsv.ImportText(FixCsv.Export(result.Added),result.Added);
        Check(repeated.Added.Count==0 && repeated.Skipped.Count==2);
        var fixConflict=FixCsv.ImportText("Ident,Latitude,Longitude\nA,40,117\nD,39,117",result.Added);
        Check(fixConflict.Added.Single().Ident=="D" && fixConflict.Conflicts.Count==1 && result.Added[0].Latitude==39);
        var obstacle=new ObstacleData { DataId="obstacle-id",Ident="O1",Latitude=39,Longitude=117,TopElevation=80,GroundElevation=50 };
        var same=ObstacleCsv.ImportText("Ident,Latitude,Longitude,TopElevation,GroundElevation\nO1,39.0,117,80.00,50",[obstacle]);
        Check(same.Added.Count==0 && same.Skipped.Count==1 && obstacle.DataId=="obstacle-id");
        var changed=ObstacleCsv.ImportText("Ident,Latitude,Longitude,TopElevation,GroundElevation\nO1,39,117,81,50\nO2,39,117,90,50",[obstacle]);
        Check(changed.Added.Single().Ident=="O2" && changed.Conflicts.Count==1 && obstacle.TopElevation==80);
    });
    Test("CSV validates all rows before classification and explains incompatible source headers", () =>
    {
        var existing=new FixData { Ident="A",Latitude=39,Longitude=117 };
        try { FixCsv.ImportText("Ident,Latitude,Longitude\nA,39,117\nB,91,117",[existing]); throw new Exception("Accepted invalid row"); }
        catch(InvalidDataException ex) { Check(ex.Message.Contains("第 3 行") && !ex.Message.Contains("重复")); }
        try { NavaidCsv.ImportText("Ident,Name,Kind,Latitude,Longitude\nA,Source,VOR,39,117",[]); throw new Exception("Accepted source CSV"); }
        catch(InvalidDataException ex) { Check(ex.Message.Contains("格式不匹配") && ex.Message.Contains("当前文件字段：Ident,Name,Kind,Latitude,Longitude") && ex.Message.Contains("要求字段：Ident,Kind,Latitude,Longitude")); }
        Check(FixCsv.ImportText(FixCsv.Export([]),[]).Added.Count==0);
    });
    Test("runway CSV normalizes THR DER defaults and preserves existing direction conflicts", () =>
    {
        var runway=RunwayCsv.ParseText(RunwayCsv.Export([new RunwayData { Ident="R",Width=45,
            EndA=new() { Designator="16R",PhysicalEnd=new() { Latitude=39.14,Longitude=117.34,Elevation=3 },Threshold=new() { Latitude=39.14,Longitude=117.34,Elevation=3 },DepartureEnd=new() { Latitude=39.11,Longitude=117.34,Elevation=6 } },
            EndB=new() { Designator="34L",PhysicalEnd=new() { Latitude=39.11,Longitude=117.34,Elevation=6 },Threshold=new() { Latitude=39.11,Longitude=117.34,Elevation=6 },DepartureEnd=new() { Latitude=39.14,Longitude=117.34,Elevation=3 } } }]))[0];
        runway.DataId="runway-id";
        var lines=RunwayCsv.Export([runway]).Trim().Split('\n'); var fields=lines[1].Trim().Split(',');
        foreach(var i in Enumerable.Range(6,6).Concat(Enumerable.Range(16,6))) fields[i]="";
        var defaults=RunwayCsv.ImportText(lines[0]+"\n"+string.Join(",",fields),[runway]);
        Check(defaults.Added.Count==0 && defaults.Skipped.Count==1 && runway.DataId=="runway-id");
        fields[0]="OTHER";
        var direction=RunwayCsv.ImportText(lines[0]+"\n"+string.Join(",",fields),[runway]);
        Check(direction.Added.Count==0 && direction.Conflicts.Single().Contains("OTHER"));
        var other=RunwayCsv.ParseText(RunwayCsv.Export([runway]))[0]; other.Ident="FREE"; other.EndA.Designator="16L"; other.EndB.Designator="34R";
        var mixed=RunwayCsv.ImportText(RunwayCsv.Export([runway,other]),[runway]);
        Check(mixed.Added.Single().Ident=="FREE" && mixed.Skipped.Count==1);
        var duplicate=RunwayCsv.ParseText(RunwayCsv.Export([other]))[0]; duplicate.Ident="COLLISION";
        var internalDirections=RunwayCsv.ImportText(RunwayCsv.Export([other,duplicate]),[]);
        Check(internalDirections.Added.Count==0 && internalDirections.Conflicts.Count==2);
        fields[0]="R"; fields[1]="46";
        Check(RunwayCsv.ImportText(lines[0]+"\n"+string.Join(",",fields),[runway]).Conflicts.Count==1 && runway.Width==45);
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
        Check(opened.ProjectId == project.ProjectId && opened.Name == project.Name && opened.DwgPath is null && !File.ReadAllText(path).Contains("DwgPath"));
        Check(opened.Airport.ArpLatitude == 39.124353 && opened.Fixes[0].Elevation == 12.5);
        Check(opened.Procedures[0].Kind == ProcedureKind.Approach && opened.Procedures[0].Runway == "16" && opened.Procedures[0].FixIdents.SequenceEqual(new[] { "TJ002", "TJ001", "TJ002" }));
        project.Name = "updated"; store.Save(project, path); Check(store.Open(path).Name == "updated");
    });
    Test("all five Procedure kinds preserved", () =>
    {
        var p = Sample(); var approach = new ProcedureData { Name = "APP", Kind = ProcedureKind.Approach };
        p.Procedures = [
            new() { Name = "DEP", Kind = ProcedureKind.Departure },
            new() { Name = "ARR", Kind = ProcedureKind.Arrival },
            approach,
            new() { Name = "MIS", Kind = ProcedureKind.Missed, ParentProcedureId = approach.ProcedureId },
            new() { Name = "HLD", Kind = ProcedureKind.Holding, ParentProcedureId = approach.ProcedureId }
        ];
        var path = Path.Combine(work, "kinds.json"); store.Save(p, path); Check(store.Open(path).Procedures.Count == 5);
    });
    Test("duplicate Fix identifiers rejected", () => { var p = Sample(); p.Fixes.Add(new() { Ident = "tj001", Latitude = 39, Longitude = 117 }); Reject(() => store.Save(p, Path.Combine(work, "duplicate.json"))); });
    Test("unknown Procedure Fix rejected", () => { var p = Sample(); p.Procedures[0].FixIdents.Add("MISSING"); Reject(() => store.Save(p, Path.Combine(work, "missing.json"))); });
    Test("Missed requires an Approach parent", () => { var p = Sample(); p.Procedures[0].Kind = ProcedureKind.Missed; p.Procedures[0].ParentProcedureId = "missing"; Reject(() => store.Save(p, Path.Combine(work, "missed.json"))); });
    Test("incomplete ARP rejected", () => { var p = Sample(); p.Airport.ArpLongitude = null; Reject(() => store.Save(p, Path.Combine(work, "arp.json"))); });
    Test("null airport JSON rejected", () => { var path = Path.Combine(work, "invalid.json"); File.WriteAllText(path, "{\"Airport\":null}"); Reject(() => store.Open(path)); });
    Test("CSV imports fixed header and quoted identifier", () =>
    {
        var path = Path.Combine(work, "fix.csv"); File.WriteAllText(path, "Ident,Latitude,Longitude\n\"TJ003\",39.21,117.31\nTJ004,39.22,117.32\n");
        var fixes = FixCsv.Parse(path); Check(fixes.Count == 2 && fixes[0].Ident == "TJ003" && fixes[0].Elevation is null && fixes[1].Elevation is null);
    });
    Test("CSV rejects invalid latitude before returning batch", () =>
    {
        var path = Path.Combine(work, "bad.csv"); File.WriteAllText(path, "Ident,Latitude,Longitude\nA,39,117\nB,91,117\n"); Reject(() => FixCsv.Parse(path));
    });
    Test("CSV duplicate batch identifiers rejected", () =>
    {
        var path = Path.Combine(work, "dupe.csv"); File.WriteAllText(path, "Ident,Latitude,Longitude\nA,39,117\na,39.1,117.1\n"); Reject(() => FixCsv.Parse(path));
    });
    Test("decimal coordinates independent of current locale", () =>
    {
        var previous = CultureInfo.CurrentCulture;
        try { CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("fr-FR"); var path = Path.Combine(work, "locale.csv"); File.WriteAllText(path, "Ident,Latitude,Longitude\nA,39.2,117.3\n"); Near(FixCsv.Parse(path)[0].Latitude,39.2); }
        finally { CultureInfo.CurrentCulture = previous; }
    });
}
finally { Directory.Delete(work, true); }
Console.WriteLine($"Fpd.Core tests: {passed} passed, {failed} failed");
return failed == 0 ? 0 : 1;
