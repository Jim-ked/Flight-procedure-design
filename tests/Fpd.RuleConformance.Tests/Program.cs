using System;
using Fpd.Engine;

namespace Fpd.RuleConformance.Tests
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
            var catalog = new FrozenRuleSpecCatalog();
            if (!catalog.IsFrozen("RS-TURN-SEL-IAFIF") || catalog.GetState("DETAIL-PENDING") != "DETAIL-PENDING") throw new Exception("Rule catalog mismatch");
            var pending = new FrozenTurnMethodSelector().Select("STAR-UNRESOLVED", 90, null);
            if (pending.Resolution != RuleResolution.RuleResolutionRequired) throw new Exception("Missing rule was filled");
            Console.WriteLine("Rule Conformance: PASS"); return 0;
        }
    }
}
