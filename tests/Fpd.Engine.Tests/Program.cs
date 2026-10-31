using System;
using Fpd.Domain;
using Fpd.Engine;

namespace Fpd.Engine.Tests
{
    internal static class Program
    {
        private static void Check(bool c, string n) { if (!c) throw new Exception("FAIL: " + n); }
        public static int Main(string[] args)
        {
            var selector = new FrozenTurnMethodSelector();
            Check(selector.Select("IAF", 30, null).Method == TurnMethod.Arc, "IAF 30 Arc");
            Check(selector.Select("IF", 30.1, null).Method == TurnMethod.WindSpiralBoundaryArc, "IF >30 WindSpiral");
            Check(selector.Select("FAF", 10, null).Method == TurnMethod.Arc, "FAF 10 Arc");
            Check(selector.Select("FAF", 10.1, null).Method == TurnMethod.WindSpiralBoundaryArc, "FAF >10 WindSpiral");
            Check(selector.Select("RF", 1, "RF").Method == TurnMethod.Rf, "RF");
            Check(selector.Select("UNKNOWN", 1, null).Resolution == RuleResolution.RuleResolutionRequired, "pending rule");
            var graph = new MinimalDependencyGraph();
            var a = graph.Analyze(DirtyNode.FixPosition); Check(a.Affected.Count == 4 && a.Affected[3] == DirtyNode.Evaluation, "fix impact");
            a = graph.Analyze(DirtyNode.ObstacleDataset); Check(a.Affected.Count == 1 && a.Affected[0] == DirtyNode.Evaluation, "obstacle impact");
            a = graph.Analyze(DirtyNode.TurnParameter); Check(a.Affected.Count == 3 && a.Affected[0] == DirtyNode.TurnGeometry, "IAS impact");
            Check(graph.Plan(a).RequiresUserConfirmation, "no automatic rebuild");
            var arrival = new ArrivalProcedure("arrival-1", "RS-ARR-30NM-001");
            var straight = new StraightConstruction("construction-1", arrival.ProcedureId, "I1A-CONTRACT");
            Check(arrival.ProcedureType == "Arrival" && straight.ProcedureId == arrival.ProcedureId, "I1-A contract skeleton");
            Console.WriteLine("Rule/Dependency tests: PASS"); return 0;
        }
    }
}
