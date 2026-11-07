namespace Fpd.Core;

public sealed class ProcedurePath
{
    public string PathId { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = "";
    public bool IsMissed { get; set; }
    public string? Runway { get; set; }
    public string? MigrationNote { get; set; }
    public List<FixUse> Fixes { get; set; } = [];
}

public sealed class FixUse
{
    public string FixIdent { get; set; } = "";
    public string SymbolKey { get; set; } = "FlyBy";
    public string? Annotation { get; set; }
}

public static class ProcedurePaths
{
    public static void Migrate(ProjectData project)
    {
        ProjectDataIds.Ensure(project);
        foreach (var p in project.Procedures)
        {
            if (p.PathsMigrated) continue;
            // Never combine legacy segments or infer that they constitute complete routes.
            if (p.FixIdents.Count > 0)
            {
                var path = Add(p, UniqueName(p,"旧主顺序"));
                path.PathId=LegacyId(p.ProcedureId+"/main");
                path.Runway=p.Runway; path.MigrationNote="旧FixIdents主顺序；未认定为完整运行路线。";
                Insert(path,0,p.FixIdents);
            }
            var sectionIndex=0;
            foreach (var section in p.Sections)
            {
                var path=Add(p,UniqueName(p,section.Name));
                path.PathId=LegacyId(p.ProcedureId+"/section/"+sectionIndex++);
                path.Runway=section.Runway; path.IsMissed=section.Stage==ProcedureStage.Missed;
                path.MigrationNote=$"旧段独立保留：Stage={section.Stage}, Branch={section.Branch}；未认定为完整运行路线。";
                Insert(path,0,section.FixIdents);
            }
            p.PathsMigrated=true;
        }
    }
    private static string LegacyId(string value)=>Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(value)))[..32];
    private static string UniqueName(ProcedureData p,string name)
    {
        var result=name; var i=2;
        while(p.Paths.Any(x=>x.Name.Equals(result,StringComparison.OrdinalIgnoreCase))) result=$"{name} ({i++})";
        return result;
    }
    public static ProcedurePath Add(ProcedureData procedure,string name)
    {
        var path=new ProcedurePath(); Rename(procedure,path,name); procedure.Paths.Add(path); return path;
    }
    public static void Rename(ProcedureData procedure,ProcedurePath path,string name)
    {
        name=name.Trim();
        if(string.IsNullOrWhiteSpace(name) || procedure.Paths.Any(p=>p!=path && p.Name.Equals(name,StringComparison.OrdinalIgnoreCase)))
            throw new InvalidDataException("路径名称不能为空或重复。");
        path.Name=name;
    }
    public static void Insert(ProcedurePath path,int index,IEnumerable<string> identifiers)
    {
        if(index<0 || index>path.Fixes.Count) throw new ArgumentOutOfRangeException(nameof(index));
        var values=identifiers.Select(id=>new FixUse { FixIdent=id }).ToList();
        if(values.Any(f=>string.IsNullOrWhiteSpace(f.FixIdent))) throw new InvalidDataException("定位点标识不能为空。");
        path.Fixes.InsertRange(index,values);
    }
    public static int Move(ProcedurePath path,int index,int direction)
    {
        var target=index+direction;
        if(index<0 || index>=path.Fixes.Count || target<0 || target>=path.Fixes.Count) return index;
        (path.Fixes[index],path.Fixes[target])=(path.Fixes[target],path.Fixes[index]); return target;
    }
}

// A cancelled acquisition returns no partial batch; duplicates keep their click order.
public sealed class OrderedFixPick
{
    private readonly List<string> _values=[];
    public void Add(string ident)=>_values.Add(ident);
    public IReadOnlyList<string>? Complete(bool accepted)=>accepted?_values.ToArray():null;
}

public enum BaseMapChange { Create, None, Update, Conflict }
public static class BaseMapPolicy
{
    public static bool CanWrite(string? associated,string? current)=>
        !string.IsNullOrWhiteSpace(associated) && !string.IsNullOrWhiteSpace(current) &&
        Path.IsPathFullyQualified(associated) && Path.IsPathFullyQualified(current) &&
        Path.GetFullPath(associated).Equals(Path.GetFullPath(current),StringComparison.OrdinalIgnoreCase);
    public static BaseMapChange Decide(int matches,bool untouched,bool dataChanged)=>matches switch
    {
        0=>BaseMapChange.Create,
        1 when untouched=>dataChanged?BaseMapChange.Update:BaseMapChange.None,
        _=>BaseMapChange.Conflict
    };
}

// Deterministic defaults keep old JSON stable even before its first migrated save.
public static class ProjectDataIds
{
    public static void Ensure(ProjectData p)
    {
        string Id(string kind,string ident)=>Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(p.ProjectId+"/"+kind+"/"+ident.ToUpperInvariant())))[..32];
        foreach(var f in p.Fixes) if(string.IsNullOrWhiteSpace(f.DataId)) f.DataId=Id("Fix",f.Ident);
        foreach(var o in p.Obstacles) if(string.IsNullOrWhiteSpace(o.DataId)) o.DataId=Id("Obstacle",o.Ident);
        foreach(var r in p.Runways) if(string.IsNullOrWhiteSpace(r.DataId)) r.DataId=Id("Runway",r.Ident);
        foreach(var n in p.Navaids) if(string.IsNullOrWhiteSpace(n.DataId)) n.DataId=Id("Navaid",n.Ident);
    }
}
