using System;
using System.Collections.Generic;

namespace Fpd.Engine
{
    public enum DirtyNode { FixPosition, TrackFragment, Construction, Protection, Evaluation, ObstacleDataset, TurnParameter, TurnGeometry, TurnProtection }
    public sealed class ImpactAnalysis
    {
        public readonly DirtyNode Changed; public readonly IList<DirtyNode> Affected;
        public ImpactAnalysis(DirtyNode changed, IList<DirtyNode> affected) { Changed = changed; Affected = affected; }
    }
    public sealed class RebuildPlan
    {
        public readonly IList<DirtyNode> Nodes; public readonly bool RequiresUserConfirmation;
        public RebuildPlan(IList<DirtyNode> nodes) { Nodes = nodes; RequiresUserConfirmation = true; }
    }
    public sealed class MinimalDependencyGraph
    {
        public ImpactAnalysis Analyze(DirtyNode changed)
        {
            var affected = new List<DirtyNode>();
            if (changed == DirtyNode.FixPosition) { affected.Add(DirtyNode.TrackFragment); affected.Add(DirtyNode.Construction); affected.Add(DirtyNode.Protection); affected.Add(DirtyNode.Evaluation); }
            else if (changed == DirtyNode.ObstacleDataset) affected.Add(DirtyNode.Evaluation);
            else if (changed == DirtyNode.TurnParameter) { affected.Add(DirtyNode.TurnGeometry); affected.Add(DirtyNode.TurnProtection); affected.Add(DirtyNode.Evaluation); }
            else affected.Add(changed);
            return new ImpactAnalysis(changed, affected);
        }
        public RebuildPlan Plan(ImpactAnalysis analysis) { return new RebuildPlan(new List<DirtyNode>(analysis.Affected)); }
    }
}
