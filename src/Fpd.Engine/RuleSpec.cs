using System;
using System.Collections.Generic;
using Fpd.Domain;

namespace Fpd.Engine
{
    public enum TurnMethod { Arc, WindSpiralBoundaryArc, Rf, RuleResolutionRequired }
    public enum RuleResolution { Resolved, RuleResolutionRequired }
    public sealed class RuleSelection
    {
        public readonly RuleResolution Resolution; public readonly TurnMethod Method; public readonly string RuleId;
        public RuleSelection(RuleResolution resolution, TurnMethod method, string ruleId) { Resolution = resolution; Method = method; RuleId = ruleId; }
    }
    public interface IRuleSpecCatalog { bool IsFrozen(string ruleId); string GetState(string ruleId); }
    public interface ITurnMethodSelector { RuleSelection Select(string segmentType, double turnAngle, string rfType); }

    public sealed class FrozenRuleSpecCatalog : IRuleSpecCatalog
    {
        private readonly HashSet<string> _frozen = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "RS-TURN-SEL-IAFIF", "RS-TURN-SEL-FAF", "RS-TURN-SEL-DEPARTURE", "RS-TURN-SEL-MISSED", "RS-TURN-SEL-TAH", "RS-TURN-SEL-RF" };
        public bool IsFrozen(string ruleId) { return _frozen.Contains(ruleId); }
        public string GetState(string ruleId) { return IsFrozen(ruleId) ? "FROZEN" : "DETAIL-PENDING"; }
    }
    public sealed class FrozenTurnMethodSelector : ITurnMethodSelector
    {
        public RuleSelection Select(string segmentType, double turnAngle, string rfType)
        {
            var s = (segmentType ?? string.Empty).ToUpperInvariant();
            if (s == "RF") return new RuleSelection(RuleResolution.Resolved, TurnMethod.Rf, "RS-TURN-SEL-RF");
            if (s == "IAF" || s == "IF") return turnAngle <= 30.0 ? Arc("RS-TURN-SEL-IAFIF") : Wind("RS-TURN-SEL-IAFIF");
            if (s == "FAF") return turnAngle <= 10.0 ? Arc("RS-TURN-SEL-FAF") : Wind("RS-TURN-SEL-FAF");
            if (s == "DEPARTURE") return Wind("RS-TURN-SEL-DEPARTURE");
            if (s == "MISSED") return Wind("RS-TURN-SEL-MISSED");
            if (s == "TAH") return Wind("RS-TURN-SEL-TAH");
            return new RuleSelection(RuleResolution.RuleResolutionRequired, TurnMethod.RuleResolutionRequired, "DETAIL-PENDING");
        }
        private static RuleSelection Arc(string id) { return new RuleSelection(RuleResolution.Resolved, TurnMethod.Arc, id); }
        private static RuleSelection Wind(string id) { return new RuleSelection(RuleResolution.Resolved, TurnMethod.WindSpiralBoundaryArc, id); }
    }
}
