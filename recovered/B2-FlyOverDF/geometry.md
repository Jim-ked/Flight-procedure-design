# B2 geometry branches

## Scalar setup

The constructor body at processed source lines 67464 and 67521 sets:

```text
earliest = ATT
latest   = -ATT - (ReactTime + BankTime)*(TAS + Wind)/3.6
```

This differs from B1's `R*tan(A/2)` anticipation. The B2 class then computes the signed heading change independently and constructs its own wind spirals.

## DF path

`_0089_009E_008C` samples an earliest/latest spiral, builds a heading line from the sampled point, uses `_0089_009E_008B` to obtain a parameter by distance-to-line bisection, and appends a path pair from the spiral point to the center waypoint. It also contains fixed-distance path constructions of `12000.0` and `13000.0` in the recovered body. Candidate points are selected by distance comparisons; there is no direct Autodesk `IntersectWith` call.

The class uses a 15° constant (`PI/12`) for connection offsets and contains branches around angular differences and candidate distances. Those are real implementation branches; a complete line-by-line boundary port is intentionally left open.

## ATT=0 check

The methods-only body and the annotated source contain assignments and arithmetic involving `_008A_008C_009E`, but no equality, epsilon, or `<=0` branch on ATT. The help statement “ATT=0 与 PBN 定高转弯保护区相同” therefore has **no implementation evidence in the recovered B2 class**. It must remain an implementation-basis-to-be-confirmed statement, not a code fact.
