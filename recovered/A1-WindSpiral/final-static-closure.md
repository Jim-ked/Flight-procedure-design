# A1 WindSpiral — Round 13 final static closure

## Status

**A1: COMPLETE_STATIC.** The reachable single, double and triple event chains, input meaning, wind parameter use, tangent-label behavior, nominal track assembly and CAD entity dispatch are closed from existing source/IL evidence. Round 3 files and its `PARTIALLY ACCEPTED` historical closure are unchanged. Remaining items are E4 host execution, complete Designer/runtime layout and implementation-basis confirmation.

## Input semantics

The three-point chain uses manual CAD anchors. In the triple chain the first point and second point establish the heading; all three origins are independently shifted by the turn radius. The third origin is a third manually picked start, not an endpoint automatically derived from spiral 2. In the single chain the second pick is the start-edge direction and the optional third pick is the turn-end point when that checkbox branch is enabled. The double chain has a manually supplied second spiral start; no route-object handoff derives it. See `final-input-semantics.csv`.

## Wind model and degenerates

P793 supplies `WindRadius` and `Drift`. The recovered point body uses `q = angle * WindRadius + offset` and `d = sqrt(R² + q² + 2Rq cos(Drift))`, then applies the `asin` correction and `DirectionSign` rotation. Wind accumulation is linear in turn angle; it is not time-step integration or vector-time simulation. Left/right is carried by `DirectionSign`.

The old behavior has no clamp or guard for degenerate inputs: wind zero reduces to the base circle when drift is zero; `|wind| > TAS` makes `asin(wind/TAS)` NaN; bank approaching zero makes `Rate` zero and radius/wind-radius division produce Infinity; a rate above the cap is reduced by `min(...,3)`; zero turn angle emits the exact endpoint; angles beyond 360° are sampled as the supplied range rather than normalized. The normal UI supplies a positive one-degree step, so no reachable infinite-loop branch was proven. A malformed non-positive step in the generic carrier would not make progress. These are preserved behaviors, not repairs.

## “Common tangent” final meaning

`The UI label “common tangent” does not correspond to a standalone two-spiral tangent solver in this build.` The checked path assembles a point list containing start/base-circle/spiral points and sends sampled lists through a concatenator. The lower-level P7AD helper is a point-to-spiral candidate/parameter iteration, not a circle-circle or spiral-spiral tangent method. No `IntersectWith`, analytic tangent, trim/extend or tangent-failure dispatch is evidenced.

## CAD and residuals

The final CAD map records optional component polylines, optional base circles and a nominal concatenated open Polyline or degree-4 Spline. The event does not prove an A1-specific Group, Text, layer, color or semantic XData writer; helper metadata is delegated. No static event, formula or writer chain remains unresolved. E4, host compatibility, Designer recreation and standards provenance remain outside this static closure.
