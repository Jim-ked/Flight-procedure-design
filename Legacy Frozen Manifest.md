# Legacy Frozen Manifest

Hashes are SHA-256. Recovered source files are read-only evidence; compatibility code is under `src/Fpd.Legacy.WindSpiral`.

| Asset | Original/recovered paths | SHA256 (source evidence) | StaticClosureStatus | IntegrationStatus | Evidence / fixtures | KnownLimitations | AlgorithmVersion | BehaviorVersion |
|---|---|---|---|---|---|---|
| A1/P793 | `recovered/GeometryPrimitives/WindSpiral.Recovered.cs`; `TurnParameter.Recovered.cs`; `Geometry.Recovered.cs` | `08669FD267200C9AECC63FF23FEA087FCBD037812AA7137D68946DCF6B296FB0`; `3154FB0B909CF87F2727DBD789D8DB680F4464C12177CFBF69E80C4B6C17B3EF`; `DCF47E9B13C627BD8B42B42ACF40B28261FAFF0949F67AF11ADFB7CAAD1A6650` | COMPLETE_STATIC | BehaviorLocked | `recovered/A1-WindSpiral/final-static-closure.md`; `recovered/round13/a1-degenerate-fixtures.csv` | No trusted original host; no clamp/guard added | A1-P793-SHIM-1 | A1-P793-RECOVERED-1 |
| A9 | `recovered/ObstacleData/PriSec.Recovered.cs` | `F326F6E7CB9876E95CD4CBD419E50900F5CE651E7F8B81C9EBE3918230AEA6D0` | COMPLETE_STATIC | BehaviorLocked | `recovered/A9-PriSec/final-static-closure.md`; `recovered/round14/a9-cross-module-comparison.csv` | Rule mapping for primary/secondary pending | A9-PRI-SEC-SHIM-1 | A9-PRI-SEC-RECOVERED-1 |
| B1 | `recovered/B1-FlyBy/FlyBy.Boundaries.Recovered.cs`; `FlyBy.CadWriter.Recovered.cs` | `985CA1C6A29A29B5C5557A7066A2BF09CBC6E83C6CBEB7FA79D452D0709562BE`; `C65D72ED05037469431E048CFFFB145A8EE4981C1623E22C6C3688335760B4B5` | COMPLETE_STATIC | Recovered | `recovered/B1-FlyBy/final-static-closure.md`; `recovered/round13/b1-branch-fixtures.csv` | Pure complete boundary path and KK/NN semantics missing | B1-STATIC-1 | B1-STATIC-1 |
| B2 | `recovered/B2-FlyOverDF/FlyOver.Boundaries.Recovered.cs`; `FlyOver.CadWriter.Recovered.cs` | `FD6FD72DFC564BF47E1C668EB093660EE3C5D1B64C680A9E20E114EA7156A3AB`; `B4A9F4B710E959EFB9EC3F237F150C5F2E6627F2227C51903C81079F979D2191` | COMPLETE_STATIC | Recovered | `recovered/B2-FlyOverDF/final-static-closure.md`; `recovered/round13/b2-branch-fixtures.csv` | Pure complete boundary path and KK/NN semantics missing | B2-STATIC-1 | B2-STATIC-1 |

Round13/14 fixtures, recovered calculations, and IL-derived results are **Recovered Behavior Baseline**. They are not Golden Master data because no trusted original AutoCAD runtime output is available.
