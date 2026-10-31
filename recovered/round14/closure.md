# Round 14 Closure — A2 + A9

Historical Round 1 status remains `PARTIALLY ACCEPTED`; no prior closure was modified.

| Module | Final static status | Basis |
|---|---|---|
| A2 Basic Calculation | **COMPLETE_STATIC** | six calculators, six CAD events, cancellation behavior, WsCalcuLine schema/readers, errors and event bindings closed |
| A9 Primary/Secondary Evaluation | **COMPLETE_STATIC** | Screen/Evaluate/Mark chain, Normal/IF branches, coordinate signs, primary/secondary/MOC and no-CAD-writer result closed |

Key fixed conclusions:

- NPA reads one seconds value (default 18); no 3+15 code split was recovered.
- C uses the general `(TAS+wind)*seconds/3.6` path; default C inputs include time 6 and wind 56. No 3+3 derivation was recovered.
- A2 writes WsCalcuLine XData, but the bounded direct-call graph shows no automatic A7/A8/A9/A10/B3/B4/B5 semantic reader.
- A9 is an obstacle evaluator, not a protection-area construction command. It has no indexed Polyline/Line/Arc/Circle/Group protection writer.

Remaining same-build static work: none for the bounded A2/A9 chains. Remaining validation is E4/API23.1 host execution, full Designer/config recreation, host compatibility and standards provenance. API23.1 E4 is recommended only if runtime evidence is now desired; it was not executed in this round.
