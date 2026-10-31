# DependencyGraph Prototype

`MinimalDependencyGraph` returns local `ImpactAnalysis` and a confirmation-gated `RebuildPlan`; it never performs a rebuild.

| Changed input | Affected nodes |
|---|---|
| Fix position | adjacent TrackFragment → Construction → Protection → Evaluation |
| Obstacle dataset | Evaluation |
| IAS / turn parameter | TurnGeometry → TurnProtection → Evaluation |

The Engine test runner verifies all three impact sets and the user-confirmation flag.
