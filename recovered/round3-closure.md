# Round 3 closure: A1 / B1 / B2

更新：2026-10-27。状态：**PARTIALLY ACCEPTED**。A1 spiral point generator、P793 turn parameter、B1/B2 scalar and branch evidence、共享调用索引和纯恢复 fixtures 已交付；B1/B2 的完整 CAD writer/schema 和全部边界顶点仍未闭合，因此不标记 ACCEPTED。

## A1 answers

1. **模型：** `_008F_0086` uses `q=θ*WindRadius+offset`, radial distance `d=sqrt(R²+q²+2Rq cos drift)`, corrected angle `θ-asin(q sin drift/d)`, then origin/heading/sign rotation.
2. **Wind accumulation:** linear in turn angle, not time integration. `WindRadius` and `Drift` come from P793.
3. **Left/right:** constructor bool becomes `DirectionSign=+1/-1`; the sign multiplies the corrected angle and base-circle angle.
4. **Polyline/Spline:** the same concatenated point list is sent either to the Polyline helper or to `Spline(fitPoints,4,0.0)`. The source branch does not set closed.
5. **Double/triple:** each has its own shifted origin and `_008F_0086`; the second and third are appended as sampled segments. They are not merely repeated calls to one CAD command.
6. **Tangent:** `_008F_0086::_008A_009E_009B` is a shared point-to-spiral tangent-like parameter iteration. No two-spiral/circle-circle common-tangent MethodDef is evidenced. The A1 “tangent” path itself uses list concatenation; B1/B2 use private line carriers and distance-selected candidates.
7. **Nominal track:** three manual points establish incoming heading, segment transition and ending angle; the nominal path is a sampled point sequence, not an Autodesk Arc call in the recovered event.

## B1 answers

8. **Three points:** incoming reference, fly-by waypoint, outgoing reference, proven by two `atan2` calls and three descriptor constructors.
9. **Earliest/latest:** `n=R*tan(A/2)`, `earliest=ATT+n`, `latest=n-ATT-(ReactTime+BankAngleDelay)*(TAS+Wind)/3.6`.
10. **ATT:** stored on the middle descriptor and added/subtracted in those scalar formulas and later line/spiral branches.
11. **NN′/KK′:** checkbox arguments and independent geometry lists are proven; a complete semantic line schema and XData writer are not. The report does not equate list names with aviation labels.
12. **SW1≠SW2:** first/middle and last descriptors carry separate widths. Candidate selection uses those descriptors and signed line geometry; no one-sided expansion rule can be asserted from the static slice.
13. **Outer branches:** `A≤60°`, `60°<A≤90°`, `A>90°`, `A>120°` warning, plus 15°/30° connection and candidate-distance branches.
14. **Inner branches:** independent list construction exists, but an A/2 convergence rule is not directly evidenced; it remains implementation basis to be confirmed.

## B2 answers

15. **Three points:** incoming reference, fly-over waypoint, post-turn direction reference. The middle descriptor receives ATT.
16. **Earliest/latest:** `earliest=ATT`, `latest=-ATT-(ReactTime+BankTime)*(TAS+Wind)/3.6`; this is distinct from B1 anticipation.
17. **DF path:** private `_008C_0089` samples spiral candidates, constructs heading lines, appends path pairs to the center waypoint, and contains literal 12000/13000 path constructions.
18. **Next-waypoint tangent:** no direct point-to-spiral `CommonTangent` call is present. B2 uses line carriers, parameter bisection and candidate-distance comparisons.
19. **ATT=0:** no equality/epsilon/`<=0` branch on ATT was found in the B2 class. The help statement is therefore not a recovered code fact.

## Shared layer answers

20. **True shared MethodDefs:** P793/P854 turn parameter path, `_008F_0086` constructor/point/sample/radius/iteration methods, and low-level point/line primitives. The direct/indirect evidence is [shared-turn-spiral-calls.csv](round3/shared-turn-spiral-calls.csv), 182 indexed rows.
21. **A7/P793:** A7 directly constructs the same turn parameter object; it has no direct P7A1 spiral constructor edge in the Round 2 scope.
22. **B1/B2 spiral builder:** both directly call the same `_008F_0086` MethodDefs, but their boundary classes and branch methods are separate.
23. **Common tangent:** the shared P7AD point-to-spiral candidate is real; no public two-spiral/circle-circle common-tangent primitive or CAD `IntersectWith` edge was found in the selected evidence.
24. **Copied implementations:** `_008C_0087` (B1) and `_008C_0089` (B2) independently implement similar line/spiral candidate logic; their code is numerically similar and shares base state, not one boundary MethodDef.

## Evidence and validation

* Direct assembly/IL/source: `A1-WindSpiral/evidence`, `B1-FlyBy/evidence`, `B2-FlyOverDF/evidence`, and the original/processed source paths cited in each module report.
* Mechanical recovery code: `GeometryPrimitives/WindSpiral.Recovered.cs`, `TurnParameter.Recovered.cs`, `round3/Round3.Geometry.cs`.
* Recovery-code fixtures: `round3/fixtures/round3-python-results.json` and `round3/tests.log` (10 assertions, PASS).
* C# compatibility compile was attempted but blocked by the sandbox's csc PE/Win32-resource output (`CS0016/CS1567`); this is recorded in `round3/compile-tests.log`. No original DLL, AutoCAD or unknown binary was loaded.
* AC-97-FS-005 / 民航规〔2020〕12号 is a comparison baseline only. Formula differences and missing limits are marked implementation basis to be confirmed; no code was corrected to fit the specification.

## Closure pass result

The B1/B2 writer bodies, entity order, Group behavior, `WsObject` XData branch, and branch-indexed boundary vertex expressions are now recorded in `recovered/round3-closure-final.md` and the B1/B2 closure artifacts. NN′/KK′ aviation semantics remain unresolved because the writer carries no semantic metadata. The negative ATT=0 result is preserved. Round 1 and Round 2 frozen manifests remain unchanged.
