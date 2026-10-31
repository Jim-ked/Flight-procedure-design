using System;
using System.Collections.Generic;
using Fpd.Application;
using Fpd.Domain;

namespace Fpd.Infrastructure
{
    public sealed class FakeCadPort : ICadPort
    {
        public GeometrySnapshot LastComputedGeometry { get; private set; }
        public GeometrySnapshot AcceptedGeometry { get; private set; }
        public bool CADDirty { get; private set; }
        public bool ManuallyModified { get; private set; }
        public void Rebuild(GeometrySnapshot geometry) { LastComputedGeometry = geometry; CADDirty = true; ManuallyModified = false; }
        public void Accept() { AcceptedGeometry = LastComputedGeometry; CADDirty = false; ManuallyModified = false; }
        public void Detach() { ManuallyModified = true; CADDirty = true; }
        public void SimulateManualEdit() { ManuallyModified = true; CADDirty = true; }
    }
    public sealed class InMemoryProjectStore : IProjectStore
    {
        private readonly Dictionary<string, ProjectState> _states = new Dictionary<string, ProjectState>(StringComparer.OrdinalIgnoreCase);
        public void Save(ProjectState state) { _states[state.ProjectId] = Clone(state); }
        public ProjectState Reopen(string projectId) { return _states.ContainsKey(projectId) ? Clone(_states[projectId]) : null; }
        private static ProjectState Clone(ProjectState source) { var result = new ProjectState(source.ProjectId); result.LastComputedGeometry = source.LastComputedGeometry; result.AcceptedGeometry = source.AcceptedGeometry; result.CADDirty = source.CADDirty; result.ManuallyModified = source.ManuallyModified; return result; }
    }
}
