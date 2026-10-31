# A1/P793 Behavior Lock Report

`RecoveredTurnParameterEngine` and `RecoveredWindSpiralEngine` are compatibility shims. They preserve the recovered formulas and do not edit recovered files.

The behavior runner covers IAS→TAS, rate, radius, wind radius, drift, Eθ, C6, both directions, zero wind, 90/180/270 degree points, exact terminal sampling for non-dividing steps, SampleSplit, no-clamp `asin`, `Wind > TAS` NaN, zero-rate Infinity, and the recovered iteration/sample conventions.

Result: **PASS — 19 assertions** (`tests/Fpd.Legacy.BehaviorTests`). This is a Recovered Behavior Baseline lock, not an original-plugin Golden Master.

The compatibility shim is formula/branch equivalent to the three recovered primitive files for the covered paths. Exact point-by-point comparison against an original DLL is not claimed because no trusted original runtime output exists; the round13 fixtures remain baseline evidence only.
