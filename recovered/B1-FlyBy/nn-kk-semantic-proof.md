# B1 NN'/KK' semantic proof

## What is proven

* `checkBoxNN` is displayed as `NN'线` and controls writer argument P5.
* `checkBoxKK` is displayed as `KK'线` and controls writer argument P4.
* P4 emits exactly `_0089_009D_0091` as one open zero-bulge Polyline.
* P5 emits exactly `_0089_009D_0092` as a Group containing one or more open zero-bulge Polylines.
* `_0089_009D_0091` is populated by `_0089_009D_0095` with two points (`_0089_009D_009D`, `_0089_009D_009E`). `_0089_009D_0092` is populated by `_0089_009D_0096` with three-point line carriers and candidate points.

## What is not proven

The static writer has no `WsObject` description specific to NN'/KK', no `WsInfo` metadata, no layer name and no obstacle-evaluation call. The two lists are therefore not enough to prove which one is a protection-area edge, an inner/outer edge, or a primary/secondary edge. The control labels are preserved as source UI labels, while the list semantics remain implementation-basis-to-be-confirmed.

## Relevant geometry evidence

`_0089_009D_0095` constructs the two-point list from the incoming turn geometry and then chooses 15° or `A/2` headings based on a distance comparison against `1.5*SW`. `_0089_009D_0096` constructs a Group list around the centre with two radius/angle points and a centre point, followed by a second candidate list in the recovered branch. These are real branches, but they do not carry an NN'/KK' string into CAD.
