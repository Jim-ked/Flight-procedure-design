# DCP-I0.5-001 — provisional build and integration status

## Change

Record `StaticClosureStatus` separately from `IntegrationStatus`, classify round13/14 evidence as Recovered Behavior Baseline, and use a provisional old-style compatibility build until an SDK and AutoCAD host matrix are available.

## Reason

The machine has no .NET SDK, no trusted AutoCAD runtime, and no AutoCAD reference assemblies. The distinction is required to prevent static closure from being reported as executable or adopted behavior.

## Impact

No business rule, recovered source file, or B1/B2 semantic label is changed. A1 and A9 are executable and behavior locked; B1/B2 remain recovered. Portable target freezing and true Golden Master promotion are deferred.

## Exit criteria

Install and verify a supported SDK/targeting pack, confirm the AutoCAD host/API matrix, run a solution build without the current MSBuild `MSB1025` internal error, and obtain trusted original-plugin outputs for Golden Master promotion.
