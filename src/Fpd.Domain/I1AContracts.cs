using System;
using System.Collections.Generic;

namespace Fpd.Domain
{
    public class Procedure
    {
        public readonly string ProcedureId; public readonly string ProcedureType; public readonly string RuleSpecId;
        public Procedure(string procedureId, string procedureType, string ruleSpecId) { ProcedureId = procedureId; ProcedureType = procedureType; RuleSpecId = ruleSpecId; }
    }
    public sealed class ArrivalProcedure : Procedure
    {
        public ArrivalProcedure(string procedureId, string ruleSpecId) : base(procedureId, "Arrival", ruleSpecId) { }
    }
    public sealed class ProcedureFixAssociation
    {
        public readonly string ProcedureId, FixId; public readonly int Sequence;
        public ProcedureFixAssociation(string procedureId, string fixId, int sequence) { ProcedureId = procedureId; FixId = fixId; Sequence = sequence; }
    }
    public abstract class Construction
    {
        public readonly string ConstructionId, ProcedureId, AlgorithmSource;
        protected Construction(string constructionId, string procedureId, string algorithmSource) { ConstructionId = constructionId; ProcedureId = procedureId; AlgorithmSource = algorithmSource; }
    }
    public sealed class StraightConstruction : Construction
    {
        public StraightConstruction(string id, string procedureId, string algorithmSource) : base(id, procedureId, algorithmSource) { }
    }
    public sealed class WidthTransitionConstruction : Construction
    {
        public readonly double TransitionDistance;
        public WidthTransitionConstruction(string id, string procedureId, string algorithmSource, double transitionDistance) : base(id, procedureId, algorithmSource) { TransitionDistance = transitionDistance; }
    }
    public sealed class ProtectionConstruction : Construction
    {
        public ProtectionConstruction(string id, string procedureId, string algorithmSource) : base(id, procedureId, algorithmSource) { }
    }
    public sealed class TrackFragment
    {
        public readonly string ConstructionId; public readonly IList<Point2> Points;
        public TrackFragment(string constructionId, IList<Point2> points) { ConstructionId = constructionId; Points = points; }
    }
    public sealed class NominalTrack
    {
        public readonly string ProcedureId; public readonly IList<TrackFragment> Fragments;
        public NominalTrack(string procedureId, IList<TrackFragment> fragments) { ProcedureId = procedureId; Fragments = fragments; }
    }
    public sealed class ProtectionGeometry
    {
        public readonly string ConstructionId; public readonly IList<BoundarySlot> PrimaryArea, SecondaryArea;
        public ProtectionGeometry(string constructionId, IList<BoundarySlot> primaryArea, IList<BoundarySlot> secondaryArea) { ConstructionId = constructionId; PrimaryArea = primaryArea; SecondaryArea = secondaryArea; }
    }
    public sealed class ObstacleDataset
    {
        public readonly string DatasetId; public readonly IList<ObstaclePoint> Obstacles;
        public ObstacleDataset(string datasetId, IList<ObstaclePoint> obstacles) { DatasetId = datasetId; Obstacles = obstacles; }
    }
    public sealed class ObstacleEvaluation
    {
        public readonly string DatasetId, GeometryVersion; public readonly IList<ObstacleAssessment> Results;
        public ObstacleEvaluation(string datasetId, string geometryVersion, IList<ObstacleAssessment> results) { DatasetId = datasetId; GeometryVersion = geometryVersion; Results = results; }
    }
}
