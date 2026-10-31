# RuleSpec Infrastructure Report

Implemented `IRuleSpecCatalog` and `ITurnMethodSelector` with only frozen selections:

- IAF/IF ≤30° → Arc; >30° → WindSpiral/BoundaryArc
- FAF ≤10° → Arc; >10° → WindSpiral/BoundaryArc
- Departure, Missed Approach, and TAH → WindSpiral/BoundaryArc
- RF → RF Method

Unknown or DETAIL-PENDING contexts return `RuleResolutionRequired`. No missing rule is filled from legacy WindSpiral behavior. Rule Conformance tests are separate from Legacy Behavior tests.
