# Common tangent / connection primitive

## Result

No standalone circle-circle or spiral-spiral `CommonTangent` MethodDef was found in the indexed A1/B1/B2 call graph. There is, however, a point-to-spiral tangent-like parameter iteration in `_008F_0086::_008A_009E_009B` (processed P7AD / original P7AE), and B1/B2 call that primitive through their copied geometry classes. The word “tangent” is also present in the A1 checkbox and help text.

## A1 evidence

In `_0089_0094` processed `0x06000388` / original `0x06000389` (source slice [A1 source](../A1-WindSpiral/evidence/_0089_0094.source.txt), lines 35713–35804):

* three `_008F_0086` objects are constructed with the same turn parameters, heading and direction;
* when the tangent checkbox is enabled, each displayed list receives a start point, a base-circle point and a spiral point;
* the long output curve is made by `_008F_0090._008B_008A_008E`, processed `0x0600081B`, which the recovered body at source line 84442 shows is only `AddRange(P0)` followed by `AddRange(P1)`;
* the resulting list is sent to the Polyline helper or to `new Spline(fitPoints, 4, 0.0)`.

Thus the A1 “带公切线” label corresponds to point-list assembly and sampled spiral segments in the event chain; the point-to-spiral P7AD helper is a lower-level candidate routine, not a two-spiral common-tangent solver. No `IntersectWith`, `Offset`, analytic circle-circle tangent, or tangent non-existence branch is evidenced in that chain.

## B1/B2 evidence

`_008C_0087` (B1) and `_008C_0089` (B2) construct line carriers from a point and a heading, sample `_008F_0086`, call the spiral distance/bisection methods, and compare two candidate line intersections by point distance. The recurring `PI/6`, `PI/12`, `PI/2` and candidate-distance comparisons are genuine geometry branches, but they are private to each copied class. The static index contains no direct call from B1/B2 to `_008B_008A_008E` and no shared tangent MethodDef.

## Classification

* **True shared method:** `_008F_0086` point/sample/radius/point-tangent/iteration methods and low-level point/line primitives.
* **Mathematically similar:** B1 and B2 each use line carriers, spiral samples and distance comparisons.
* **Not evidenced:** a public two-spiral common-tangent primitive, circle-circle tangent API, CAD `IntersectWith`, or automatic trim/extend operation.

This is a static negative conclusion. Reflection or an external assembly is outside the indexed evidence.
