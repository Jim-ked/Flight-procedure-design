using System;
using System.Collections.Generic;

namespace Fpd.Domain
{
    public sealed class GeometrySnapshot
    {
        public readonly string Version; public readonly IList<Point2> Points;
        public GeometrySnapshot(string version, IList<Point2> points) { Version = version; Points = points; }
    }
    public sealed class ProjectState
    {
        public readonly string ProjectId; public GeometrySnapshot LastComputedGeometry; public GeometrySnapshot AcceptedGeometry;
        public bool CADDirty; public bool ManuallyModified;
        public ProjectState(string projectId) { ProjectId = projectId; }
    }
}
