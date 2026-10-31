using Fpd.Domain;

namespace Fpd.Application
{
    public interface ICadPort
    {
        GeometrySnapshot LastComputedGeometry { get; }
        GeometrySnapshot AcceptedGeometry { get; }
        bool CADDirty { get; }
        bool ManuallyModified { get; }
        void Rebuild(GeometrySnapshot geometry);
        void Accept();
        void Detach();
    }
    public interface IProjectStore
    {
        void Save(ProjectState state);
        ProjectState Reopen(string projectId);
    }
    public sealed class ProjectCoordinator
    {
        private readonly ICadPort _cad; private readonly IProjectStore _store;
        public ProjectCoordinator(ICadPort cad, IProjectStore store) { _cad = cad; _store = store; }
        public void Rebuild(GeometrySnapshot geometry) { _cad.Rebuild(geometry); }
        public void Accept() { _cad.Accept(); }
        public void Detach() { _cad.Detach(); }
        public ProjectState Capture(string id) { var state = new ProjectState(id); state.LastComputedGeometry = _cad.LastComputedGeometry; state.AcceptedGeometry = _cad.AcceptedGeometry; state.CADDirty = _cad.CADDirty; state.ManuallyModified = _cad.ManuallyModified; return state; }
        public void Save(string id) { _store.Save(Capture(id)); }
        public ProjectState Reopen(string id) { return _store.Reopen(id); }
    }
}
