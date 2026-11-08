using System.Text;
using System.Text.Json;

namespace Fpd.Core;

public sealed class ProjectStore
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
    public void Save(ProjectData project, string path)
    {
        var json = Serialize(project);
        if (File.Exists(path))
        {
            using var old = JsonDocument.Parse(File.ReadAllText(path));
            if (!old.RootElement.TryGetProperty("WorkspaceVersion", out _) && !File.Exists(path + ".pre-workspace.bak")) File.Copy(path, path + ".pre-workspace.bak");
            if (!File.Exists(path + ".pre-paths.bak") && old.RootElement.TryGetProperty("Procedures", out var procedures) && procedures.EnumerateArray().Any(p => !p.TryGetProperty("PathsMigrated", out var migrated) || !migrated.GetBoolean()))
                File.Copy(path, path + ".pre-paths.bak");
        }
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path))!);
        var temporary = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            File.WriteAllText(temporary, json, new UTF8Encoding(false));
            File.Move(temporary, path, true);
        }
        finally { if (File.Exists(temporary)) File.Delete(temporary); }
    }

    public ProjectData Open(string path)
    {
        return Deserialize(File.ReadAllText(path));
    }

    public static string Serialize(ProjectData project)
    {
        ArgumentNullException.ThrowIfNull(project);
        ProcedurePaths.Migrate(project);
        ProjectValidation.Project(project);
        return JsonSerializer.Serialize(project, JsonOptions);
    }

    public static string AuxiliaryPath(string dwgPath)
    {
        if (!Path.IsPathFullyQualified(dwgPath) || !Path.GetExtension(dwgPath).Equals(".dwg", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("请先使用 AutoCAD 原生保存 DWG。");
        return Path.ChangeExtension(dwgPath, ".fpd.json");
    }

    public static ProjectData Deserialize(string json)
    {
        using var document = JsonDocument.Parse(json);
        var project = document.RootElement.Deserialize<ProjectData>(JsonOptions)
            ?? throw new InvalidDataException("项目文件为空或格式无效。");
        if(document.RootElement.TryGetProperty("Procedures",out var oldProcedures) && oldProcedures.ValueKind==JsonValueKind.Array)
        {
            var index=0;
            foreach(var old in oldProcedures.EnumerateArray())
            {
                if(!old.TryGetProperty("ProcedureId",out _) && index<project.Procedures.Count)
                    project.Procedures[index].ProcedureId=Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(Encoding.UTF8.GetBytes(project.ProjectId+"/legacy-procedure/"+index)))[..32];
                index++;
            }
        }
        ProcedurePaths.Migrate(project);
        ProjectValidation.Project(project);
        return project;
    }

    public static ProjectData Create(string name, AirportData airport) => new() { Name = name, Airport = airport };
}
