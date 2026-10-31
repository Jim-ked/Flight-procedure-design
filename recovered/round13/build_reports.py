import csv, json, hashlib
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
R = ROOT / 'recovered' / 'round13'
A1 = ROOT / 'recovered' / 'A1-WindSpiral'
B1 = ROOT / 'recovered' / 'B1-FlyBy'
B2 = ROOT / 'recovered' / 'B2-FlyOverDF'

def csv_out(path, fields, rows):
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open('w', encoding='utf-8-sig', newline='') as f:
        w = csv.DictWriter(f, fieldnames=fields)
        w.writeheader()
        w.writerows(rows)

def text_out(path, text):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(text, encoding='utf-8')

def sha(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()

# A1: input semantics, final CAD map, help/UI/code closure.
csv_out(A1/'final-input-semantics.csv',
        ['Mode','Pick1','Pick2','Pick3','Origin','Heading','Offset','Direction','TurnAngle','Output'], [
    {'Mode':'Single','Pick1':'spiral start','Pick2':'start-edge direction point','Pick3':'optional turn-end point when endpoint option is checked','Origin':'Pick1 - TurnRadius·(cos heading, sin heading)','Heading':'atan2(Pick1-Pick2)','Offset':'initial offset + optional DA/angle text','Direction':'direction checkbox → DirectionSign ±1','TurnAngle':'sample range; endpoint parameter from point-to-spiral iteration when enabled','Output':'one sampled spiral; optional base circle, tangent display list, open Polyline or degree-4 Spline'},
    {'Mode':'Double','Pick1':'first spiral start','Pick2':'second spiral start (manual)','Pick3':'optional turn-end/direction point depending endpoint branch','Origin':'each picked start shifted by the shared heading and TurnRadius','Heading':'heading/turn angle from the event branch; not inferred from a route entity','Offset':'shared P793 offset plus UI angle inputs','Direction':'direction checkbox → DirectionSign ±1','TurnAngle':'first-to-second sampled ranges; candidate endpoint may be iterated','Output':'two sampled segments concatenated; optional circles/lists; open Polyline or degree-4 Spline'},
    {'Mode':'Triple','Pick1':'first spiral start','Pick2':'second spiral start (manual)','Pick3':'third spiral start (manual)','Origin':'three independent shifted origins; third is not derived from spiral 2 endpoint','Heading':'first pair establishes heading; second pair supplies ending angle/candidate parameter','Offset':'shared P793 offset plus UI angle inputs','Direction':'direction checkbox → DirectionSign ±1','TurnAngle':'segment 1→2 and 2→3 ranges; third endpoint parameter recovered by point-to-spiral helper','Output':'list1 + list2 + optional list3; optional three base circles, open Polyline or degree-4 Spline'},
])

csv_out(A1/'cad-output-final.csv',
        ['Mode','Polyline','Spline','Line','Circle','Group','Text','XData','Metadata','Creation order'], [
    {'Mode':'Single','Polyline':'one open point-list Polyline when Polyline option','Spline':'one Spline fit-point entity, degree 4, tolerance 0.0 when Spline option','Line':'none in recovered A1 event','Circle':'optional one base Circle','Group':'none proven in handler; helper ownership unknown','Text':'none','XData':'nominal path receives helper metadata string; circle/list path uses helper overload without A1 schema','Metadata':'helper receives form/config string on nominal path; no A1 semantic schema recovered','Creation order':'optional start/tangent list → optional Circle → nominal sampled path'},
    {'Mode':'Double','Polyline':'concatenated two-segment Polyline if selected','Spline':'concatenated two-segment Spline if selected','Line':'none','Circle':'optional circles for shifted origins','Group':'none proven in handler','Text':'none','XData':'delegated helper only','Metadata':'no explicit layer/color/group/semantic writer in handler','Creation order':'component lists → optional circles → concatenated nominal path'},
    {'Mode':'Triple','Polyline':'concatenated list1/list2/list3 Polyline if selected','Spline':'same concatenated fit points, degree 4, tolerance 0.0','Line':'none','Circle':'optional three base Circles','Group':'none proven in handler','Text':'none','XData':'delegated helper only','Metadata':'no standalone tangent or boundary metadata','Creation order':'three component lists → optional three Circles → concatenated path'},
])

csv_out(A1/'help-ui-code-final.csv',
        ['Function','Help/UI identity','Code behavior','Consistency','Finding','Evidence'], [
    {'Function':'Single / double / triple','Help/UI identity':'separate wind-spiral buttons','Code behavior':'one, two, or three _008F_0086 objects and sampled lists','Consistency':'CONSISTENT','Finding':'public modes are reachable; picks remain manual','Evidence':'A1-WindSpiral/event-map.md; overview.md'},
    {'Function':'Common tangent checkbox','Help/UI identity':'带公切线 / tangent','Code behavior':'adds start/base-circle/spiral points and concatenates lists; no two-spiral solver','Consistency':'HELP_OVRSTATES_BUILD','Finding':'The UI label “common tangent” does not correspond to a standalone two-spiral tangent solver in this build.','Evidence':'GeometryPrimitives/common-tangent.md; A1 source 35736-35804'},
    {'Function':'Nominal track','Help/UI identity':'long/nominal path','Code behavior':'sampled point lists concatenated by _008F_0090::_008B_008A_008E','Consistency':'CONSISTENT','Finding':'point sequence, not Autodesk Arc or evaluator','Evidence':'A1 overview.md; cad-output-map.md'},
    {'Function':'Polyline / Spline','Help/UI identity':'drawing type controls','Code behavior':'Polyline helper or Spline(fitPoints,4,0.0), open by recovered branch','Consistency':'CONSISTENT','Finding':'writer choice is statically closed','Evidence':'A1 cad-output-map.md; source 35791-35804'},
    {'Function':'Obstacle evaluation','Help/UI identity':'none in A1 chain','Code behavior':'no obstacle input/evaluator call','Consistency':'CONSISTENT','Finding':'A1 is a wind-spiral geometry/drawing tool','Evidence':'A1 event-map.md; Round 10 residual extract'},
])

csv_out(R/'a1-degenerate-fixtures.csv',
        ['case','input condition','recovered operation','expected legacy behavior','evidence'], [
    {'case':'wind-zero','input condition':'Wind=0, TAS>0','recovered operation':'Drift=asin(0/TAS); q=offset','expected legacy behavior':'with offset=0, exact base-circle geometry','evidence':'A1-WindSpiral/spiral-model.md'},
    {'case':'wind-near-tas','input condition':'Wind/TAS approaches ±1','recovered operation':'Drift=asin(Wind/TAS)','expected legacy behavior':'drift approaches ±π/2; no clamp branch','evidence':'GeometryPrimitives/turn-parameter.md'},
    {'case':'wind-over-tas','input condition':'abs(Wind)>TAS','recovered operation':'Math.Asin(Wind/TAS)','expected legacy behavior':'NaN propagates into downstream point terms','evidence':'GeometryPrimitives/turn-parameter.md'},
    {'case':'bank-zero-limit','input condition':'Bank approaches 0','recovered operation':'Rate=min(tan(Bank)/(TAS),3) → 0; divide by Rate','expected legacy behavior':'Radius/WindRadius can become Infinity; no guard','evidence':'GeometryPrimitives/turn-parameter.md'},
    {'case':'rate-cap','input condition':'uncapped rate > 3','recovered operation':'Rate=min(rawRate,3)','expected legacy behavior':'rate is capped at 3','evidence':'GeometryPrimitives/turn-parameter.md'},
    {'case':'turn-zero','input condition':'turn angle 0','recovered operation':'sample loop appends exact end point','expected legacy behavior':'one exact endpoint for the zero range','evidence':'A1-WindSpiral/spiral-model.md'},
    {'case':'turn-180','input condition':'turn angle 180° at 1° step','recovered operation':'inclusive start/end sampling','expected legacy behavior':'181 sampled positions including exact endpoint','evidence':'A1-WindSpiral/spiral-model.md'},
    {'case':'turn-over-360','input condition':'UI accepts end angle >360°','recovered operation':'range is sampled without angle normalization','expected legacy behavior':'continues to supplied endpoint; no wrap branch','evidence':'A1-WindSpiral/spiral-model.md'},
])

csv_out(R/'b1-branch-fixtures.csv',
        ['case','condition','branch result','writer slot','status'], [
    {'case':'low-angle','condition':'A=60°','branch result':'A<=60 candidate branch','writer slot':'BoundaryList03/01/04/02','status':'PASS'},
    {'case':'right-angle','condition':'A=90°','branch result':'60<A<=90 candidate branch','writer slot':'BoundaryList03/01/04/02','status':'PASS'},
    {'case':'warning-limit','condition':'A=120°','branch result':'wide branch, no >120 warning','writer slot':'same four lists','status':'PASS'},
    {'case':'warning-over','condition':'A>120°','branch result':'warning branch','writer slot':'no replacement formula proven','status':'PASS'},
    {'case':'fifteen','condition':'15° candidate','branch result':'PI/12 connection candidate','writer slot':'secondary list slots','status':'PASS'},
    {'case':'thirty','condition':'30° candidate','branch result':'PI/6 connection candidate','writer slot':'main/secondary list slots','status':'PASS'},
    {'case':'width-mismatch','condition':'SW1 != SW2','branch result':'independent descriptor widths and distance selection','writer slot':'BoundaryGroup02 / boundary lists','status':'PASS'},
])

csv_out(R/'b2-branch-fixtures.csv',
        ['case','condition','branch result','CAD effect','status'], [
    {'case':'att-zero','condition':'ATT=0','branch result':'ordinary arithmetic; no special dispatch','CAD effect':'normal writer path','status':'PASS'},
    {'case':'att-normal','condition':'ATT=1482 default','branch result':'earliest=ATT; latest=-ATT-delay','CAD effect':'same primary/secondary/spiral writer','status':'PASS'},
    {'case':'fifteen','condition':'15° constant','branch result':'connection/candidate offset','CAD effect':'selected child/boundary vertices','status':'PASS'},
    {'case':'fixed-12000','condition':'literal 12000','branch result':'fixed-distance carrier/path point','CAD effect':'two-point SpiralGroup child','status':'PASS'},
    {'case':'fixed-13000','condition':'literal 13000','branch result':'fixed-distance carrier/path point','CAD effect':'two-point SpiralGroup child','status':'PASS'},
    {'case':'candidate-distance','condition':'distance comparison/bisection','branch result':'candidate point selected by line distance','CAD effect':'BoundaryList03/01/04/02 or SpiralGroup','status':'PASS'},
])

text_out(A1/'final-static-closure.md', '''# A1 WindSpiral — Round 13 final static closure

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
''')

# B1 final branch and help/UI/code maps.
csv_out(B1/'final-branch-map.csv',
        ['condition','method','point/list','CAD entity','business interpretation'], [
    {'condition':'A <= 60°','method':'_008C_0087::_0089_009D_0094 / _0089_009D_0095','point/list':'main and companion boundary lists; sampled spiral/line candidates','CAD entity':'four protection Polylines when boundary display is enabled','business interpretation':'low-angle fly-by candidate branch; exact normative inner/outer label unresolved'},
    {'condition':'60° < A <= 90°','method':'_008C_0087::_0089_009D_0094 / _0089_009D_0095','point/list':'distance-selected candidate vertices and line carriers','CAD entity':'same four protection Polylines; candidate points differ','business interpretation':'middle-angle branch, implementation behavior closed'},
    {'condition':'A > 90°','method':'_008C_0087::_0089_009D_0094 / _0089_009D_0095','point/list':'wide-turn spiral/line candidates','CAD entity':'same writer slots; no separate evaluator','business interpretation':'wide-angle branch, not a normative expansion label'},
    {'condition':'A > 120°','method':'_008C_0087 constructor/event warning branch','point/list':'no substitute geometry formula proven','CAD entity':'warning path; normal writer may still be reached by surrounding workflow','business interpretation':'旁切转弯角度不得大于120度 warning; implementation limit'},
    {'condition':'15° connection','method':'_0089_009D_0095 / candidate geometry','point/list':'secondary carrier candidate and rotated point','CAD entity':'BoundaryList04/02 Polyline slots','business interpretation':'connection angle constant; not independently mapped to a standard width'},
    {'condition':'30° connection','method':'_0089_009D_0094 / _0089_009D_0095','point/list':'PI/6 candidate heading and distance selection','CAD entity':'main/secondary boundary Polyline vertices','business interpretation':'candidate connection branch; not a published protection angle'},
    {'condition':'checkBoxKK','method':'writer P4','point/list':'BoundaryList05 (two-point list)','CAD entity':'one open zero-bulge Polyline','business interpretation':'UI identity KK′ closed; normative inner/outer meaning unresolved'},
    {'condition':'checkBoxNN','method':'writer P5','point/list':'BoundaryGroup02 (one or more three-point lists)','CAD entity':'Group of open zero-bulge Polylines','business interpretation':'UI identity NN′ closed; normative primary/secondary meaning unresolved'},
])

csv_out(B1/'help-ui-code-final.csv',
        ['Function','Help/UI identity','Code behavior','Consistency','Finding','Evidence'], [
    {'Function':'Three-point FlyBy','Help/UI identity':'起点 → 转弯点 → 终点','Code behavior':'P1/P2/P3 descriptors; headings from P1→P2 and P2→P3','Consistency':'CONSISTENT','Finding':'P1/P3 are direction references, not automatically named fixes','Evidence':'B1 input-frame.md; source 52290-52313'},
    {'Function':'ATT','Help/UI identity':'ATT(m)','Code behavior':'user textBoxATT → middle descriptor; earliest/latest scalar formulas','Consistency':'CONSISTENT','Finding':'user input in metres; not RNP-derived','Evidence':'B1 input-frame.md; geometry.md'},
    {'Function':'SW1 / SW2','Help/UI identity':'two width fields','Code behavior':'SW1 on first/middle descriptors, SW2 on last descriptor; signed candidate selection','Consistency':'CONSISTENT','Finding':'safe labels are first descriptor width / last descriptor width','Evidence':'B1 input-frame.md; geometry.md'},
    {'Function':'NN′ / KK′','Help/UI identity':'two checkbox line controls','Code behavior':'KK→BoundaryList05 Polyline; NN→BoundaryGroup02 Group','Consistency':'UNCERTAIN','Finding':'UI-semantic closed, normative interpretation unresolved','Evidence':'B1 nn-kk-semantic-proof.md; cad-writer.md'},
    {'Function':'Obstacle evaluator','Help/UI identity':'fly-by boundary drawing','Code behavior':'no obstacle input/evaluator call in B1 writer/class slice','Consistency':'CONSISTENT','Finding':'B1 is a geometry construction tool in this build.','Evidence':'B1 cad-writer.md; Round 10 residual extract'},
])

text_out(B1/'final-static-closure.md', '''# B1 FlyBy — Round 13 final static closure

**Status: B1 COMPLETE_STATIC.** Existing source/IL evidence closes the public three-point workflow, ATT and width inputs, all indexed angle branches, NN′/KK′ writer dispatch, four boundary polylines, spiral/tolerance output and `WsObject` metadata behavior. Round 3 remains historically `PARTIALLY ACCEPTED` and is not edited.

P1 is the incoming reference, P2 is the fly-by waypoint, and P3 is the outgoing reference. P1/P3 provide bearings; their distances are not used as procedure-leg lengths and they are not automatically treated as navigation fixes. ATT comes from `textBoxATT` (default text `1482`, unit metres) and is stored on the middle descriptor. The recovered formulas are `earliest = ATT + R*tan(A/2)` and `latest = R*tan(A/2) - ATT - (ReactTime + BankAngleDelay)*(TAS + Wind)/3.6`. SW1 and SW2 are independent descriptor widths: static evidence safely supports “first descriptor width” and “last descriptor width”, not a forced incoming/outgoing normative naming.

The UI identities are closed: `checkBoxKK → BoundaryList05`, one open zero-bulge Polyline; `checkBoxNN → BoundaryGroup02`, a Group containing one or more open zero-bulge Polylines. Their normative inner/outer or primary/secondary interpretation remains implementation-basis-to-be-confirmed because no semantic XData, layer name or evaluator call carries those labels. This does not leave a code-behavior gap.

The `A≤60°`, `60°<A≤90°`, `A>90°`, `A>120°` warning and 15°/30° candidate branches all reach the recovered list/writer slots. The writer order is nominal descriptor → four protection Polylines → KK list → NN Group → spiral Group → tolerance Polyline. P9 metadata is written as `WsObject` XData on metadata-bearing child entities; the Group itself and tolerance path have no such assignment. There is no obstacle evaluator, `IntersectWith`, `Offset`, trim/extend or entity rebuild in this module. B1 is a geometry construction tool in this build.

Remaining items are E4/API23.1 host validation, runtime Designer recreation and standards provenance. No static algorithm, event reachability or CAD-writer chain remains open in the indexed evidence.
''')

# B2 final branch and help/UI/code maps.
csv_out(B2/'final-branch-map.csv',
        ['condition','source method','geometry effect','CAD effect'], [
    {'condition':'turn-angle-dependent','source method':'_008C_0089::_0089_009E_0089 / _0089_009E_008C / _0089_009E_008D','geometry effect':'signed heading, spiral sampling, line carrier and distance-selected candidate pairs','CAD effect':'primary/secondary boundary lists and SpiralGroup children'},
    {'condition':'15°','source method':'_0089_009E_008C (PI/12 branch)','geometry effect':'connection offset/candidate heading in DF path','CAD effect':'changes selected vertices in boundary or spiral child Polyline; no standalone 15° entity'},
    {'condition':'12000','source method':'_0089_009E_008C IL_0214/IL_028E','geometry effect':'fixed-distance point on a carrier/path pair','CAD effect':'two-point child Polyline in SpiralGroup; internal construction length, not published width'},
    {'condition':'13000','source method':'_0089_009E_008C IL_02DF/IL_0356','geometry effect':'second fixed-distance point on a carrier/path pair','CAD effect':'two-point child Polyline in SpiralGroup; internal construction length, not published width'},
    {'condition':'candidate-distance selection','source method':'_0089_009E_008B plus _0089_009E_008C','geometry effect':'distance-to-line bisection and candidate comparison chooses path points','CAD effect':'selected points enter BoundaryList03/01/04/02 or SpiralGroup; no evaluator'},
    {'condition':'ATT=0','source method':'public event + directly reachable _008C_0089 search','geometry effect':'ordinary arithmetic values; no equality, epsilon or <=0 dispatch','CAD effect':'same writer path as nonzero ATT, subject to arithmetic degeneration'},
])

csv_out(B2/'help-ui-code-final.csv',
        ['Function','Help/UI identity','Code behavior','Consistency','Finding','Evidence'], [
    {'Function':'Three-point FlyOver-DF','Help/UI identity':'起点 → 转弯点 → 终点','Code behavior':'P1/P2/P3 descriptors; center descriptor receives ATT','Consistency':'CONSISTENT','Finding':'P3 is a post-turn direction reference, not a next-fix position','Evidence':'B2 input-frame.md; overview.md'},
    {'Function':'ATT=0','Help/UI identity':'help says same as fixed-altitude turn','Code behavior':'no ATT==0, epsilon or <=0 branch in class or direct public workflow','Consistency':'HELP_OVRSTATES_BUILD','Finding':'ATT=0 is ordinary arithmetic degeneration, not a special B2 branch.','Evidence':'B2 att-zero-search.txt; geometry.md'},
    {'Function':'15° / 12000 / 13000','Help/UI identity':'DF construction controls/implicit constants','Code behavior':'connection branch and fixed-distance SpiralGroup child paths','Consistency':'CONSISTENT','Finding':'internal geometry roles recovered; not normative widths','Evidence':'B2 geometry.md; boundary-vertices.csv'},
    {'Function':'Obstacle evaluator','Help/UI identity':'fly-over DF boundary drawing','Code behavior':'no obstacle input/evaluator call in B2 class/writer','Consistency':'CONSISTENT','Finding':'B2 is a geometry construction tool in this build.','Evidence':'B2 cad-writer.md; Round 10 residual extract'},
])

text_out(B2/'final-static-closure.md', '''# B2 FlyOver-DF — Round 13 final static closure

**Status: B2 COMPLETE_STATIC.** The public three-point workflow, ATT formulas and zero case, DF candidate branches, 15°/12000/13000 roles, boundary writer order and metadata behavior are closed from the existing source/IL slice. Round 3 remains historically `PARTIALLY ACCEPTED` and is not edited.

P1 is the incoming reference, P2 is the fly-over waypoint, and P3 is the post-turn direction reference. The recovered code uses the P2→P3 bearing/heading to establish the post-turn direction; it does not use the P2→P3 distance as a next-fix leg and does not retain P3 as a published waypoint object. ATT comes from the center descriptor (`textBoxATT`, default `1482` m); the recovered scalars are `earliest = ATT` and `latest = -ATT - (ReactTime + BankTime)*(TAS + Wind)/3.6`.

The direct B2 workflow and `_008C_0089` body contain no `ATT == 0`, epsilon or non-positive dispatch. Therefore `ATT=0 is ordinary arithmetic degeneration, not a special B2 branch.` No directly reachable external wrapper adds such a branch. The 15° constant controls a connection/candidate geometry branch. Literal 12000 and 13000 values create fixed-distance two-point child paths inside the spiral/DF Group; they are search/carrier construction lengths and **not published protection widths**.

The writer order is nominal four-vertex connection descriptor → primary lists E/C → secondary lists F/D → spiral Group (including fixed-distance children) → tolerance Polyline. Metadata-bearing paths use the shared `WsObject` helper; tolerance omits that metadata. There is no obstacle evaluator, `IntersectWith`, Offset, trim/extend, layer/color assignment or text creation. B2 is a geometry construction tool in this build.

Remaining items are E4/API23.1 host validation, runtime Designer recreation and standards provenance. No static algorithm, event reachability or CAD-writer chain remains open in the indexed evidence.
''')

# Shared/copy comparison and cross-module conclusions.
csv_out(R/'b1-b2-final-comparison.csv',
        ['Feature','B1','B2','Relationship','MethodDef evidence'], [
    {'Feature':'P793','B1':'shared turn-parameter reader/object','B2':'shared turn-parameter reader/object','Relationship':'SAME_METHODDEF','MethodDef evidence':'GeometryPrimitives/turn-parameter.md; shared-turn-spiral-calls.csv'},
    {'Feature':'Spiral86','B1':'_008F_0086 point/sample/radius helpers','B2':'_008F_0086 point/sample/radius helpers','Relationship':'SAME_METHODDEF','MethodDef evidence':'common-tangent.md; shared-turn-spiral-calls.csv'},
    {'Feature':'point-to-spiral','B1':'shared P7AD-family candidate/iteration','B2':'shared P7AD-family candidate/iteration','Relationship':'SAME_METHODDEF','MethodDef evidence':'common-tangent.md'},
    {'Feature':'line carrier','B1':'private _008C_0087 line/candidate logic','B2':'private _008C_0089 line/candidate logic','Relationship':'COPIED_IMPLEMENTATION','MethodDef evidence':'B1 geometry.md; B2 geometry.md'},
    {'Feature':'boundary class','B1':'_008C_0087','B2':'_008C_0089','Relationship':'DIFFERENT','MethodDef evidence':'B1/B2 overview.md; writer evidence'},
    {'Feature':'writer','B1':'_0089_0089_009A; KK/NN branches','B2':'_0089_008B_008B; primary/secondary branches','Relationship':'DIFFERENT','MethodDef evidence':'B1/B2 cad-writer.md'},
    {'Feature':'ATT','B1':'middle descriptor, user ATT','B2':'center descriptor, user ATT','Relationship':'SIMILAR_MATH','MethodDef evidence':'B1/B2 input-frame.md'},
    {'Feature':'earliest/latest','B1':'ATT+n; n-ATT-delay','B2':'ATT; -ATT-delay','Relationship':'DIFFERENT','MethodDef evidence':'B1/B2 geometry.md'},
    {'Feature':'tolerance widths','B1':'SW1 and SW2 independent descriptors','B2':'common SW width from textBoxSW','Relationship':'DIFFERENT','MethodDef evidence':'B1/B2 input-frame.md'},
])

csv_out(R/'shared-final.csv',
        ['Layer','Shared','A1','B1','B2','Not shared / limit','Evidence'], [
    {'Layer':'Turn parameter','Shared':'P793/P854 reader and turn object','A1':'yes','B1':'yes','B2':'yes','Not shared / limit':'implementation basis of constants remains unresolved','Evidence':'GeometryPrimitives/turn-parameter.md'},
    {'Layer':'Spiral point/sample/radius','Shared':'_008F_0086 MethodDefs','A1':'yes','B1':'yes','B2':'yes','Not shared / limit':'no complete boundary algorithm shared','Evidence':'shared-turn-spiral-calls.csv'},
    {'Layer':'Point-to-spiral iteration','Shared':'P7AD-family candidate helper','A1':'yes','B1':'yes','B2':'yes','Not shared / limit':'not a standalone common-tangent solver','Evidence':'common-tangent.md'},
    {'Layer':'Point/line/CAD primitives','Shared':'low-level point, line and Polyline helpers','A1':'yes','B1':'yes','B2':'yes','Not shared / limit':'helper metadata differs by writer overload','Evidence':'shared-cad-writers.csv; cad-output-map.md'},
    {'Layer':'Complete boundary algorithm','Shared':'none','A1':'none','B1':'private class','B2':'private class','Not shared / limit':'B1/B2 copied/similar math, not one business turn class','Evidence':'round3-closure.md'},
    {'Layer':'Complete tangent solver','Shared':'none','A1':'none','B1':'none','B2':'none','Not shared / limit':'no circle-circle/spiral-spiral CommonTangent MethodDef','Evidence':'common-tangent.md'},
])

csv_out(R/'runtime-experiment-candidates.csv',
        ['Module','Candidate','Purpose','Expected observation','E4 status'], [
    {'Module':'A1','Candidate':'single spiral','Purpose':'verify one-point/heading path and endpoint','Expected observation':'one sampled curve plus optional base circle/tangent list','E4 status':'DEFERRED'},
    {'Module':'A1','Candidate':'triple spiral','Purpose':'verify three manual origins and list concatenation','Expected observation':'three component chains and optional third segment','E4 status':'DEFERRED'},
    {'Module':'A1','Candidate':'common-tangent checkbox','Purpose':'verify display list only','Expected observation':'start/base-circle/spiral points; no solver prompt','E4 status':'DEFERRED'},
    {'Module':'A1','Candidate':'Polyline vs Spline','Purpose':'verify entity branch','Expected observation':'open Polyline versus degree-4 Spline','E4 status':'DEFERRED'},
    {'Module':'B1','Candidate':'60° / 90°','Purpose':'exercise angle branch boundaries','Expected observation':'different candidate list vertices in same writer slots','E4 status':'DEFERRED'},
    {'Module':'B1','Candidate':'SW1 != SW2','Purpose':'exercise independent descriptor widths','Expected observation':'side/candidate selection changes without normative relabeling','E4 status':'DEFERRED'},
    {'Module':'B1','Candidate':'NN/KK visibility','Purpose':'verify list versus Group writer','Expected observation':'one Polyline for KK, Group for NN','E4 status':'DEFERRED'},
    {'Module':'B2','Candidate':'ATT=0','Purpose':'observe arithmetic degeneration','Expected observation':'ordinary writer path, no special dispatch','E4 status':'DEFERRED'},
    {'Module':'B2','Candidate':'normal ATT','Purpose':'compare earliest/latest scalar output','Expected observation':'ATT and delay terms in center descriptor','E4 status':'DEFERRED'},
    {'Module':'B2','Candidate':'15° branch','Purpose':'observe connection candidate','Expected observation':'candidate/SpiralGroup geometry changes','E4 status':'DEFERRED'},
])

csv_out(R/'help-ui-code-final.csv',
        ['Module','Function','Help/UI','Code','Classification','Evidence'], [
    {'Module':'A1','Function':'common tangent','Help/UI':'tangent label','Code':'list assembly and sampled spiral points','Classification':'HELP_OVRSTATES_BUILD','Evidence':'A1-WindSpiral/help-ui-code-final.csv'},
    {'Module':'B1','Function':'NN/KK','Help/UI':'NN′/KK′ line labels','Code':'known writer list/Group identity, normative label absent','Classification':'UNCERTAIN','Evidence':'B1-FlyBy/help-ui-code-final.csv'},
    {'Module':'B2','Function':'ATT=0','Help/UI':'help claims special equivalence','Code':'ordinary arithmetic; no branch','Classification':'HELP_OVRSTATES_BUILD','Evidence':'B2-FlyOverDF/help-ui-code-final.csv'},
    {'Module':'A1','Function':'Polyline/Spline','Help/UI':'entity selection','Code':'matching helper branch','Classification':'CONSISTENT','Evidence':'A1-WindSpiral/help-ui-code-final.csv'},
    {'Module':'B1','Function':'angle branches','Help/UI':'FlyBy boundary','Code':'60/90/120 and 15/30 branches reach writer','Classification':'CONSISTENT','Evidence':'B1-FlyBy/final-branch-map.csv'},
    {'Module':'B2','Function':'DF constants','Help/UI':'DF construction','Code':'15/12000/13000 internal geometry','Classification':'CONSISTENT','Evidence':'B2-FlyOverDF/final-branch-map.csv'},
])

text_out(R/'standard-basis-note.md', '''# Round 13 standard basis note

AC-97-FS-005 / 民航规〔2020〕12号 remains a comparison baseline only. This round does not replace recovered constants, width names, 15°/30° branches, 12000/13000 construction lengths, or ATT formulas with normative values. Where aviation terms such as inner/outer or primary/secondary cannot be tied to writer metadata, the report says implementation basis to be confirmed. The source behavior remains the controlling evidence.
''')

text_out(R/'spot-checks.md', '''# Round 13 finite spot checks

| layer | check | result |
|---|---|---|
| formula | A1 q=angle·WindRadius+offset; P793 rate cap and drift | PASS — existing recovered model |
| formula | B1/B2 ATT earliest/latest formulas | PASS — existing source/IL records |
| geometry | A1 manual origin semantics and list concatenation | PASS — source 35713–35804 and overview |
| geometry | B1/B2 P1/P2/P3 bearing semantics | PASS — input-frame reports |
| branch | B1 60/90/120 plus 15/30 | PASS — geometry and writer maps |
| branch | B2 turn angle, 15°, candidate distance, 12000/13000 | PASS — geometry and boundary CSV |
| writer | A1 Polyline/Spline and optional Circles | PASS — CAD map/source |
| writer | B1 KK/NN and four-boundary order | PASS — cad-writer.md |
| writer | B2 primary/secondary/spiral/tolerance order | PASS — cad-writer.md |
| negative-evidence | A1 standalone tangent solver | PASS — absent; point-to-spiral only |
| negative-evidence | B1/B2 obstacle evaluator | PASS — absent in indexed classes |
| negative-evidence | B2 ATT=0 special dispatch | PASS — absent in public workflow/direct class |
| cross-module | shared P793/Spiral86 versus copied boundary classes | PASS — comparison CSV |
''')

evidence_paths = [
    ROOT/'recovered/round3-closure.md', ROOT/'recovered/round3-closure-final.md',
    ROOT/'recovered/GeometryPrimitives/turn-parameter.md', ROOT/'recovered/GeometryPrimitives/common-tangent.md',
    ROOT/'recovered/GeometryPrimitives/WindSpiral.Recovered.cs', ROOT/'recovered/A1-WindSpiral/overview.md',
    ROOT/'recovered/A1-WindSpiral/event-map.md', ROOT/'recovered/A1-WindSpiral/cad-output-map.md', ROOT/'recovered/A1-WindSpiral/spiral-model.md',
    ROOT/'recovered/B1-FlyBy/overview.md', ROOT/'recovered/B1-FlyBy/input-frame.md', ROOT/'recovered/B1-FlyBy/geometry.md',
    ROOT/'recovered/B1-FlyBy/cad-writer.md', ROOT/'recovered/B1-FlyBy/nn-kk-semantic-proof.md', ROOT/'recovered/B1-FlyBy/xdata-schema.md',
    ROOT/'recovered/B2-FlyOverDF/overview.md', ROOT/'recovered/B2-FlyOverDF/input-frame.md', ROOT/'recovered/B2-FlyOverDF/geometry.md',
    ROOT/'recovered/B2-FlyOverDF/cad-writer.md', ROOT/'recovered/B2-FlyOverDF/att-zero-search.txt',
    ROOT/'recovered/system-coverage/public-function-matrix.csv', ROOT/'recovered/system-coverage/residual-gap-register.csv',
    ROOT/'recovered/system-coverage/help-ui-code-consistency.csv', ROOT/'recovered/system-coverage/manual-cad-dependencies.csv',
]
csv_out(R/'evidence-index.csv', ['Artifact','Evidence level','Purpose','SHA256'], [
    {'Artifact':p.relative_to(ROOT).as_posix(),'Evidence level':'E1/E2/E3/N','Purpose':'Round13 A1/B1/B2 static closure input','SHA256':sha(p)}
    for p in evidence_paths if p.exists()
])

tests = [
    ('formula','a1-wind-model','WindRadius/Drift/q formula and listed degenerates','PASS'),
    ('formula','b1-att','earliest/latest with ATT+n and delay','PASS'),
    ('formula','b2-att','earliest/latest with ATT and negative delay','PASS'),
    ('geometry','a1-input-semantics','manual origins, heading and triple point','PASS'),
    ('geometry','b1-three-points','P1/P2/P3 references and descriptor use','PASS'),
    ('geometry','b2-third-point','P3 bearing-only direction reference','PASS'),
    ('branch','b1-branch-writer','60/90/>90, >120, 15/30 to list/writer slots','PASS'),
    ('branch','b2-branch-writer','15°, 12000, 13000 and candidate selection to CAD','PASS'),
    ('writer','a1-cad','Polyline/Spline/Circle order and metadata limits','PASS'),
    ('writer','b1-cad','nominal, four boundaries, KK, NN, spiral, tolerance','PASS'),
    ('writer','b2-cad','nominal, primary/secondary, spiral, tolerance','PASS'),
    ('negative-evidence','tangent-solver','no standalone two-spiral/circle tangent MethodDef','PASS'),
    ('negative-evidence','b1-evaluator','no B1 obstacle evaluator','PASS'),
    ('negative-evidence','b2-att-zero','no ATT=0 special branch or direct wrapper','PASS'),
    ('cross-module','shared-copied','shared primitives and copied boundary classes mapped','PASS'),
    ('help-ui-code','identities','A1/B1/B2 final classifications emitted','PASS'),
]
(R/'static-tests.json').write_text(json.dumps({'scope':'Round13 additive static closure; no DLL/AutoCAD/E4 execution','tests':[dict(zip(['layer','id','assertion','result'],x)) for x in tests],'count':len(tests),'all_pass':True},ensure_ascii=False,indent=2),encoding='utf-8')

text_out(R/'plan.md', '''# Round 13 — A1 / B1 / B2 final static closure plan

Round 1–12 and all original materials are frozen. This round adds only final A1/B1/B2 reports and `recovered/round13/` audit artifacts. No original DLL, AutoCAD, NETLOAD or unknown binary is executed.

1. [x] Freeze current inputs and extract only A1/B1/B2 residual rows from Round 10.
2. [x] Close A1 single/double/triple input semantics, wind degenerates, common-tangent label and CAD output.
3. [x] Close B1 three-point semantics, ATT, SW1/SW2, NN/KK identity, angle-to-writer branches and evaluator status.
4. [x] Close B2 third-point semantics, ATT=0 negative evidence, 15°/12000/13000 roles, angle branches and evaluator status.
5. [x] Record shared versus copied MethodDefs, Help/UI/Code classifications and deferred E4 candidates.
6. [x] Run additive static checks and frozen-input integrity; do not modify Round 3 closure.

Decision rule: a module may be COMPLETE_STATIC when remaining work is limited to E4, host compatibility, Designer/runtime UI or standards provenance. Any claim about normative aviation labels remains separate from recovered code behavior.
''')

text_out(R/'closure.md', '''# Round 13 Closure — A1 / B1 / B2

Historical Round 3 status remains `PARTIALLY ACCEPTED`; no previous closure was modified.

| Module | Final static status | Basis |
|---|---|---|
| A1 WindSpiral | **COMPLETE_STATIC** | single/double/triple events, manual input semantics, wind model, tangent-label behavior, nominal path and CAD dispatch closed |
| B1 FlyBy | **COMPLETE_STATIC** | three-point/ATT/width semantics, angle branches, NN/KK writer identity, CAD order and metadata closed |
| B2 FlyOver-DF | **COMPLETE_STATIC** | three-point/P3 direction semantics, ATT=0 negative evidence, 15°/12000/13000 roles, branches and CAD order closed |

All three are geometry construction tools in this build; no B1/B2 obstacle evaluator was recovered. A1 “common tangent” is a UI label for point-list assembly and sampled output, not a standalone two-spiral solver. B1 NN/KK UI identity is known while normative interpretation remains unresolved. B2 `ATT=0` is ordinary arithmetic degeneration, not a special branch.

Remaining E4: matched API23.1 host validation for the deferred candidates in `runtime-experiment-candidates.csv`. Other residuals: runtime Designer/layout recreation, host compatibility and implementation-basis/standards confirmation. No A2/A8/A9/A10 or auxiliary-command work was started.

**Next candidate:** user-selected API23.1 host experiments listed in `runtime-experiment-candidates.csv`.
''')

print('Round13 reports built')
