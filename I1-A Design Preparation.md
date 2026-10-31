# I1-A Design Preparation

This document is a contract-only preparation slice. It does not claim I1-A production implementation.

## Intended flow

`Procedure → Construction → TrackFragment → NominalTrack → ProtectionGeometry → ObstacleEvaluation`

The state flow is `Parameter Change → ImpactAnalysis → RebuildPlan → user confirmation → partial rebuild`. CAD editing keeps `LastComputedGeometry` and `AcceptedGeometry` separate; persistence must retain Procedure, Construction, RuleSpec, AlgorithmSource, geometry version, and evaluation version.

## Contract boundary

The minimal contract names are present in `src/Fpd.Domain/I1AContracts.cs`. They contain identifiers and value objects only. No Tianjin case value, WindSpiral default, width threshold, MOC constant, or Primary/Secondary interpretation is supplied while the RuleSpecs remain pending.

## Explicit exclusions

Fly-by, Fly-over, RF, multiple ARP crossings, complex turn protection, real AutoCAD, real Project Store, APV, Precision OAS, and Holding remain outside this preparation slice.
