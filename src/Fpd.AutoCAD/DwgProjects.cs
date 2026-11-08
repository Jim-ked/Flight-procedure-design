using System.IO;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Fpd.Core;
using AcadApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace Fpd.AutoCAD;

// Document identity survives Save As and never depends on a stored path.
internal static class DwgProjects
{
    private const string SnapshotKey="FPD_PROJECT_WORKSPACE_V1";
    private sealed class State
    {
        public ProjectData Project=ProjectStore.Create("未创建项目",new AirportData());
        public string? Snapshot;
        public string? PendingSave;
        public bool Initialized;
        public bool Dirty;
        public IntPtr DatabasePointer;
        public string? Error;
    }
    private static readonly Dictionary<Document,State> States=[];
    private static WorkspacePanel? Panel;
    public static void Start(WorkspacePanel panel)
    {
        Panel=panel;
        AcadApp.DocumentManager.DocumentActivated+=Activated;
        AcadApp.DocumentManager.DocumentToBeDestroyed+=Closing;
        AcadApp.DocumentManager.DocumentDestroyed+=Closed;
        foreach(Document doc in AcadApp.DocumentManager) Attach(doc);
        AcadApp.DocumentManager.DocumentCreated+=Created;
        Activate();
    }
    private static void Created(object sender,DocumentCollectionEventArgs e) { Attach(e.Document); }
    private static void Activated(object sender,DocumentCollectionEventArgs e) => Activate();
    private static void Attach(Document doc)
    {
        if(States.ContainsKey(doc)) return;
        CadDrawing.TrackProjectEntities(doc);
        var state=new State { DatabasePointer=doc.Database.UnmanagedObject }; States.Add(doc,state);
        try
        {
            state.Snapshot=ReadSnapshot(doc.Database);
            if(state.Snapshot is { } json)
            {
                state.Project=ProjectStore.Deserialize(json); state.Initialized=true;
                try
                {
                    var path=SavedPath(doc);
                    if(path is not null && File.Exists(path) && ProjectStore.Serialize(new ProjectStore().Open(path))!=ProjectStore.Serialize(state.Project))
                        state.Error="辅助JSON与DWG快照不一致，已使用当前DWG资料；原图保持。";
                }
                catch(Exception ex) { state.Error="辅助JSON不可读，已使用DWG快照："+ex.Message; }
            }
        }
        catch(Exception ex) { state.Error="读取项目失败，禁止覆盖原资料："+ex.Message; }
        doc.Database.BeginSave+=BeginSave;
        doc.Database.SaveComplete+=Saved;
        doc.Database.AbortSave+=SaveAborted;
        doc.CommandEnded+=CommandEnded;
    }
    private static string? SavedPath(Document doc) => Path.IsPathFullyQualified(doc.Name) && File.Exists(doc.Name) ? ProjectStore.AuxiliaryPath(doc.Name) : null;
    public static void Activate()=>BindCurrentProject(true);
    private static void BindCurrentProject(bool applyPageLayers)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument;
        if(doc is null) { Panel?.BindProject(ProjectStore.Create("无当前DWG",new AirportData()),false,false); return; }
        Attach(doc); var state=States[doc];
        Panel?.BindProject(state.Project,state.Initialized,state.Error?.StartsWith("读取项目失败")!=true,state.Dirty,applyPageLayers);
        if(state.Error is not null) Panel?.SetStatus(state.Error);
        else if(!state.Initialized) Panel?.SetStatus("就绪");
    }
    public static bool IsCurrent(ProjectData project) => AcadApp.DocumentManager.MdiActiveDocument is { } doc && States.TryGetValue(doc,out var state) && ReferenceEquals(state.Project,project);
    public static void Initialize(ProjectData project)
    {
        var doc=AcadApp.DocumentManager.MdiActiveDocument??throw new InvalidOperationException("请先新建或打开DWG。");
        Attach(doc); var state=States[doc];
        if(state.Initialized || state.Error is not null) throw new InvalidOperationException("当前DWG已有项目或资料读取失败，请使用修改项目或打开另一张DWG。");
        WriteSnapshot(doc,ProjectStore.Serialize(project));
        state.Project=project; state.Initialized=true; state.Dirty=true; state.Snapshot=ReadSnapshot(doc.Database); Activate();
    }
    public static void Changed(ProjectData project)
    {
        if(!IsCurrent(project)) throw new InvalidOperationException("DWG已切换，请重新操作。");
        var doc=AcadApp.DocumentManager.MdiActiveDocument!; var state=States[doc];
        if(!state.Initialized) throw new InvalidOperationException("请先创建项目。");
        var json=ProjectStore.Serialize(project);
        WriteSnapshot(doc,json); state.Snapshot=json; state.Error=null; state.Dirty=true;
    }
    public static void DeleteBaseData(ProjectData project,string kind,IReadOnlySet<string> keys)
    {
        if(!IsCurrent(project)) throw new InvalidOperationException("DWG已切换，请重新操作。");
        if(keys.Count==0) throw new InvalidOperationException("未选择数据。");
        var doc=AcadApp.DocumentManager.MdiActiveDocument!; var state=States[doc];
        if(!state.Initialized) throw new InvalidOperationException("请先创建项目。");
        // Stage the business edit without changing the live project. Publish it only
        // after geometry, per-record history and the DWG snapshot commit together.
        var draft=ProjectStore.Deserialize(ProjectStore.Serialize(project));
        var available=kind switch
        {
            "Fix"=>draft.Fixes.Select(x=>x.DataId),"Obstacle"=>draft.Obstacles.Select(x=>x.DataId),
            "Runway"=>draft.Runways.Select(x=>x.DataId),"Navaid"=>draft.Navaids.Select(x=>x.DataId),
            _=>throw new ArgumentException("未知资料类别。",nameof(kind))
        };
        if(!keys.IsSubsetOf(available.ToHashSet(StringComparer.OrdinalIgnoreCase))) throw new InvalidOperationException("资料已变化，请重新选择。");
        switch(kind)
        {
            case "Fix": ProjectEdits.DeleteFixes(draft,draft.Fixes.Where(x=>keys.Contains(x.DataId)).Select(x=>x.Ident).ToArray()); break;
            case "Obstacle": draft.Obstacles.RemoveAll(x=>keys.Contains(x.DataId)); break;
            case "Runway": draft.Runways.RemoveAll(x=>keys.Contains(x.DataId)); break;
            case "Navaid": draft.Navaids.RemoveAll(x=>keys.Contains(x.DataId)); break;
        }
        var json=ProjectStore.Serialize(draft);
        using(var locked=doc.LockDocument())
        using(var tr=doc.Database.TransactionManager.StartTransaction())
        {
            CadDrawing.DeleteBaseRecords(project,kind,keys,tr,doc.Database);
            WriteSnapshot(doc.Database,tr,json);
            tr.Commit();
        }
        switch(kind)
        {
            case "Fix": project.Fixes=draft.Fixes; project.Procedures=draft.Procedures; break;
            case "Obstacle": project.Obstacles=draft.Obstacles; break;
            case "Runway": project.Runways=draft.Runways; break;
            case "Navaid": project.Navaids=draft.Navaids; break;
        }
        state.Snapshot=json; state.Error=null; state.Dirty=true;
        // Rebind the panel without touching layers; a layer write here would add
        // a second native undo item after the deletion transaction.
        BindCurrentProject(false); doc.Editor.Regen();
    }
    private static string? ReadSnapshot(Database db)
    {
        using var tr=db.TransactionManager.StartTransaction();
        var dictionary=(DBDictionary)tr.GetObject(db.NamedObjectsDictionaryId,OpenMode.ForRead);
        if(!dictionary.Contains(SnapshotKey)) return null;
        using var buffer=((Xrecord)tr.GetObject(dictionary.GetAt(SnapshotKey),OpenMode.ForRead)).Data;
        var bytes=buffer.AsArray().SelectMany(v=>(byte[])v.Value).ToArray();
        return Encoding.UTF8.GetString(bytes);
    }
    private static void WriteSnapshot(Document doc,string json)
    {
        using var locked=doc.LockDocument(); using var tr=doc.Database.TransactionManager.StartTransaction();
        WriteSnapshot(doc.Database,tr,json); tr.Commit();
    }
    private static void WriteSnapshot(Database db,Transaction tr,string json)
    {
        var dictionary=(DBDictionary)tr.GetObject(db.NamedObjectsDictionaryId,OpenMode.ForWrite);
        Xrecord record;
        if(dictionary.Contains(SnapshotKey)) record=(Xrecord)tr.GetObject(dictionary.GetAt(SnapshotKey),OpenMode.ForWrite);
        else { record=new Xrecord(); dictionary.SetAt(SnapshotKey,record); tr.AddNewlyCreatedDBObject(record,true); }
        var bytes=Encoding.UTF8.GetBytes(json);
        using var buffer=new ResultBuffer(bytes.Chunk(127).Select(chunk=>new TypedValue((int)DxfCode.BinaryChunk,chunk)).ToArray());
        record.Data=buffer;
    }
    // Native event senders can be fresh managed wrappers around the same database.
    private static KeyValuePair<Document,State> Find(object? sender) => sender is Database db
        ? States.FirstOrDefault(p=>p.Value.DatabasePointer==db.UnmanagedObject) : default;
    private static void BeginSave(object sender,DatabaseIOEventArgs e)
    {
        var entry=Find(sender); if(entry.Key is null || !entry.Value.Initialized) return;
        if(!Path.GetExtension(e.FileName).Equals(".dwg",StringComparison.OrdinalIgnoreCase)) { entry.Value.PendingSave=null; return; }
        // Snapshot the exact native save, not whichever document is active when SaveComplete arrives.
        entry.Value.PendingSave=ReadSnapshot(entry.Key.Database)??ProjectStore.Serialize(entry.Value.Project);
    }
    private static void Saved(object sender,DatabaseIOEventArgs e)
    {
        var entry=Find(sender); if(entry.Key is null || entry.Value.PendingSave is not { } json) return;
        entry.Value.PendingSave=null;
        try
        {
            var path=ProjectStore.AuxiliaryPath(e.FileName);
            new ProjectStore().Save(ProjectStore.Deserialize(json),path);
            entry.Value.Error=null; entry.Value.Dirty=false;
            if(entry.Key==AcadApp.DocumentManager.MdiActiveDocument) Panel?.SavedProject(path);
        }
        catch(Exception ex)
        {
            entry.Value.Error="DWG已保存，辅助JSON保存失败；业务快照仍在DWG中："+ex.Message;
            entry.Key.Editor.WriteMessage("\n"+entry.Value.Error);
            if(entry.Key==AcadApp.DocumentManager.MdiActiveDocument) Panel?.SetStatus(entry.Value.Error);
        }
    }
    private static void SaveAborted(object? sender,EventArgs e)
    { var entry=Find(sender); if(entry.Key is not null) entry.Value.PendingSave=null; }
    private static void CommandEnded(object sender,CommandEventArgs e)
    {
        if(sender is not Document doc || !States.TryGetValue(doc,out var state)) return;
        if(e.GlobalCommandName.ToUpperInvariant() is not ("U" or "UNDO" or "REDO" or "MREDO")) return;
        CadDrawing.InvalidateProjectEntities(doc);
        var json=ReadSnapshot(doc.Database);
        if(json==state.Snapshot) return;
        state.Snapshot=json; state.Initialized=json is not null; state.Dirty=true;
        state.Project=json is null?ProjectStore.Create("未创建项目",new AirportData()):ProjectStore.Deserialize(json);
        // Undo/Redo already restored the CAD state. Reapplying page layers here
        // obtains a write lock and destroys the native redo chain, even if no
        // layer value ultimately changes.
        if(doc==AcadApp.DocumentManager.MdiActiveDocument) BindCurrentProject(false);
    }
    private static void Closed(object sender,DocumentDestroyedEventArgs e) => Activate();
    private static void Closing(object sender,DocumentCollectionEventArgs e)
    {
        Detach(e.Document); States.Remove(e.Document);
    }
    private static void Detach(Document doc)
    {
        CadDrawing.ForgetProjectEntities(doc);
        FpdPalette.CancelProjectHighlights(doc);
        doc.Database.BeginSave-=BeginSave; doc.Database.SaveComplete-=Saved; doc.Database.AbortSave-=SaveAborted; doc.CommandEnded-=CommandEnded;
    }
    public static void Stop()
    {
        AcadApp.DocumentManager.DocumentActivated-=Activated; AcadApp.DocumentManager.DocumentCreated-=Created; AcadApp.DocumentManager.DocumentToBeDestroyed-=Closing; AcadApp.DocumentManager.DocumentDestroyed-=Closed;
        foreach(var doc in States.Keys) Detach(doc);
        States.Clear(); Panel=null;
    }
}
