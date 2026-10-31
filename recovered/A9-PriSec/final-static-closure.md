# A9 Primary/Secondary Evaluation — final static closure

**A9: COMPLETE_STATIC.** The public Screen → Evaluate → table → Mark chain, Normal/IF branches, local coordinate conversion, primary and secondary classifiers, MOC/OCA output and negative CAD-writer evidence are closed from the indexed source/IL and recovered code. Round 1 remains `PARTIALLY ACCEPTED` and is not modified.

A9 is a generic primary/secondary obstacle evaluator. It imports Model-space DBPoint entities through the shared SelectAll/parser chain, then uses UI numeric start/end coordinates, widths, MOC and elevations. The calculation path does not select an existing Polyline, read WsCalcuLine, or construct a protection area.

Normal uses `-L < x < 0`; IF uses `-L <= x <= 0`. Both use the same strict lateral coarse filter and outer boundary. The primary end width is `W1/2` in Normal and `W1` in IF. Primary uses `abs(y) <= primary`; secondary uses `primary < abs(y) <= outer`. `m` is linearly interpolated from endpoint MOC values. Secondary MOC is `m*(outer-abs(y))/(outer-primary)`; a zero denominator returns `m`. The legacy line helper uses ±1000000 when its denominator is zero. No non-negative clamp, tolerance, or zero-length protection was added.

The local transform produces localX/localY from the S→obstacle range and frame angle. The grid displays `-localX` and `-localY`, while Z is the original absolute obstacle altitude. Mark uses the ID→original DBPoint dictionary, so it inserts at the original point and writes `Altitude=original Z`, not OCA or MOC.

No A9 Polyline, Line, Arc, Circle or Group protection-area writer is evidenced. **A9 is an obstacle evaluator, not a protection-area construction command.** A8, A10 and A7 have business-similar obstacle evaluation but their own entry/evaluator chains; B3 has no direct A9 caller in the bounded audit.

Remaining items are E4/API23.1 host execution, full Designer/layout recreation and standards provenance. No same-build static algorithm, event-reachability or CAD-writer gap remains for the A9 evaluator chain.
