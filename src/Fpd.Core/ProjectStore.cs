using System.Text;
using System.Text.Json;

namespace Fpd.Core;

public sealed class ProjectStore
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
    public void Save(ProjectData project, string path)
    {
        ArgumentNullException.ThrowIfNull(project);
        ProcedurePaths.Migrate(project);
        ProjectValidation.Project(project);
        if (File.Exists(path) && !File.Exists(path + ".pre-paths.bak"))
        {
            using var old = JsonDocument.Parse(File.ReadAllText(path));
            if (old.RootElement.TryGetProperty("Procedures", out var procedures) && procedures.EnumerateArray().Any(p => !p.TryGetProperty("PathsMigrated", out var migrated) || !migrated.GetBoolean()))
                File.Copy(path, path + ".pre-paths.bak");
        }
        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path))!);
        var temporary = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
        try
        {
            File.WriteAllText(temporary, JsonSerializer.Serialize(project, JsonOptions), new UTF8Encoding(false));
            File.Move(temporary, path, true);
        }
        finally { if (File.Exists(temporary)) File.Delete(temporary); }
    }

    public ProjectData Open(string path)
    {
        using var stream = File.OpenRead(path);
        var project = JsonSerializer.Deserialize<ProjectData>(stream, JsonOptions)
            ?? throw new InvalidDataException("项目文件为空或格式无效。");
        ProcedurePaths.Migrate(project);
        ProjectValidation.Project(project);
        return project;
    }

    public static ProjectData Create(string name, AirportData airport) => new() { Name = name, Airport = airport };
}
