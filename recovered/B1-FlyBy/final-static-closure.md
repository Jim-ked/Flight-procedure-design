# B1 FlyBy — Round 13 final static closure

**Status: B1 COMPLETE_STATIC.** Existing source/IL evidence closes the public three-point workflow, ATT and width inputs, all indexed angle branches, NN′/KK′ writer dispatch, four boundary polylines, spiral/tolerance output and `WsObject` metadata behavior. Round 3 remains historically `PARTIALLY ACCEPTED` and is not edited.

P1 is the incoming reference, P2 is the fly-by waypoint, and P3 is the outgoing reference. P1/P3 provide bearings; their distances are not used as procedure-leg lengths and they are not automatically treated as navigation fixes. ATT comes from `textBoxATT` (default text `1482`, unit metres) and is stored on the middle descriptor. The recovered formulas are `earliest = ATT + R*tan(A/2)` and `latest = R*tan(A/2) - ATT - (ReactTime + BankAngleDelay)*(TAS + Wind)/3.6`. SW1 and SW2 are independent descriptor widths: static evidence safely supports “first descriptor width” and “last descriptor width”, not a forced incoming/outgoing normative naming.

The UI identities are closed: `checkBoxKK → BoundaryList05`, one open zero-bulge Polyline; `checkBoxNN → BoundaryGroup02`, a Group containing one or more open zero-bulge Polylines. Their normative inner/outer or primary/secondary interpretation remains implementation-basis-to-be-confirmed because no semantic XData, layer name or evaluator call carries those labels. This does not leave a code-behavior gap.

The `A≤60°`, `60°<A≤90°`, `A>90°`, `A>120°` warning and 15°/30° candidate branches all reach the recovered list/writer slots. The writer order is nominal descriptor → four protection Polylines → KK list → NN Group → spiral Group → tolerance Polyline. P9 metadata is written as `WsObject` XData on metadata-bearing child entities; the Group itself and tolerance path have no such assignment. There is no obstacle evaluator, `IntersectWith`, `Offset`, trim/extend or entity rebuild in this module. B1 is a geometry construction tool in this build.

Remaining items are E4/API23.1 host validation, runtime Designer recreation and standards provenance. No static algorithm, event reachability or CAD-writer chain remains open in the indexed evidence.
