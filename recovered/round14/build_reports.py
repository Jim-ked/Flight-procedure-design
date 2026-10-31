import csv, json, hashlib
from pathlib import Path

ROOT=Path(__file__).resolve().parents[2]
R=ROOT/'recovered'/'round14'
A2=ROOT/'recovered'/'A2-BasicCalculation'
A9=ROOT/'recovered'/'A9-PriSec'

def csv_out(path, fields, rows):
    path.parent.mkdir(parents=True, exist_ok=True)
    with path.open('w',encoding='utf-8-sig',newline='') as f:
        w=csv.DictWriter(f,fieldnames=fields); w.writeheader(); w.writerows(rows)

def text_out(path, text):
    path.parent.mkdir(parents=True,exist_ok=True); path.write_text(text,encoding='utf-8')

csv_out(A2/'final-feature-matrix.csv',
 ['Feature','UI','Event','Inputs','Formula','CADPick','CADOutput','Metadata','Reachable','Status','Evidence'], [
 {'Feature':'FAF distance','UI':'FAF page / buttonFAF','Event':'Validated calculation → CAD click 0600022E','Inputs':'FAF altitude, RDH, THR elevation, GP; intermediate length','Formula':'(FAF height - RDH - THR elevation) / tan(GP)','CADPick':'2 GetPoint: runway entrance, FAF direction','CADOutput':'FAF Line + IF Line; optional 4 DBText','Metadata':'Kind 1/2 WsCalcuLine; line center/direction/length overwritten from endpoints','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'formulas.md; cad-output-map.md; WsCalcuLine-schema.md'},
 {'Feature':'NPA SOC','UI':'non-precision SOC page / buttonNpaSOC','Event':'time Validated → calculation → CAD click 06000233','Inputs':'TAS, wind, textBoxNTime, turn parameters','Formula':'(TAS + wind) * seconds / 3.6; default seconds=18','CADPick':'2 GetPoint: latest missed point, missed direction','CADOutput':'12,000 m transverse Line; optional SOC DBText','Metadata':'Kind 3; NPA time/distance and turn fields; two independent turn-reader calls are preserved','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'formulas.md; cad-interactions.md; BasicCalculationForm.Events.Recovered.cs'},
 {'Feature':'Precision/APV SOC','UI':'precision SOC page / buttonPaSOC','Event':'category/HL update → calculation → CAD click 06000236','Inputs':'DH, HLcor, GP, Xz, category, elevations','Formula':'Round((DH-HLcor)/tan(GP)+Xz); HLcor=0 returns -1 after alert','CADPick':'2 GetPoint: THR, missed direction','CADOutput':'12,000 m transverse Line; optional CAT/SOC DBText','Metadata':'Kind 4; stores negative THR-to-SOC distance','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'formulas.md; cad-output-map.md; ui-event-map.md'},
 {'Feature':'Missed approach TP','UI':'missed TP page / buttonMissTP','Event':'calculation → CAD click 0600023B','Inputs':'start altitude, turn altitude, gradient percent','Formula':'(TurnAlt - SOCAlt) / gradient * 100','CADPick':'2 GetPoint: start, missed direction; each Origin cancels','CADOutput':'20,000 m transverse Line; optional distance + TP DBText','Metadata':'Kind 5; gradient stored as percent','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'formulas.md; cad-output-map.md'},
 {'Feature':'Departure TP','UI':'departure TP page / buttonDepTP','Event':'calculation → CAD click 0600023E','Inputs':'turn altitude, DER elevation, PDG percent','Formula':'(TurnAlt - DER elevation - 5) / PDG * 100','CADPick':'2 GetPoint: DER, turn-direction point; each Origin cancels','CADOutput':'20,000 m transverse Line; optional distance + TP DBText','Metadata':'Kind 6; fixed 5 m term; no A7 semantic reader','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'formulas.md; cad-output-map.md; A7 cross-window evidence'},
 {'Feature':'C distance','UI':'C page / buttonC','Event':'calculation → CAD click 06000241','Inputs':'TAS, wind, textBoxCTime; default seconds=6','Formula':'(TAS + 56) * 6 / 3.6 in default path; general code is (TAS + wind) * seconds / 3.6','CADPick':'2 GetPoint: start, flight direction; equality-only cancel check','CADOutput':'12,000 m transverse Line; optional C DBText','Metadata':'Kind 7; factory length 10000 is overwritten to 12000 by writer','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'formulas.md; cad-output-map.md; CalcuFactories.Recovered.cs'},
])

csv_out(A2/'cad-output-final.csv',
 ['Feature','GetPointCount','Prompts/meaning','CancelBehavior','LineCreation','Text','Transaction','XData','WsCalcuLine','Evidence'], [
 {'Feature':'FAF distance','GetPointCount':'2','Prompts/meaning':'runway entrance → FAF direction','CancelBehavior':'each Origin exits before drawing','LineCreation':'FAF line then IF line, each 20000 m','Text':'optional 4 labels: distance, FAF, height/relative height, IF','Transaction':'CreateLine commits line; second transaction writes XData','XData':'yes, Kind 1/2','WsCalcuLine':'yes','Evidence':'cad-output-map.md; cad-interactions.md'},
 {'Feature':'NPA SOC','GetPointCount':'2','Prompts/meaning':'latest missed point → missed direction','CancelBehavior':'both points are read before equality-only check; one Origin plus one non-Origin can continue','LineCreation':'one 12000 m transverse line','Text':'optional SOC label, height 500','Transaction':'line transaction then separate metadata transaction','XData':'yes, Kind 3','WsCalcuLine':'yes','Evidence':'cad-output-map.md; BasicCalculationForm.Events.Recovered.cs'},
 {'Feature':'Precision/APV SOC','GetPointCount':'2','Prompts/meaning':'THR → missed direction','CancelBehavior':'same equality-only check as NPA','LineCreation':'one 12000 m transverse line; negative CAD distance is retained','Text':'optional CAT/category/SOC label','Transaction':'line then metadata transaction','XData':'yes, Kind 4','WsCalcuLine':'yes','Evidence':'cad-output-map.md; formulas.md'},
 {'Feature':'Missed approach TP','GetPointCount':'2','Prompts/meaning':'start → missed direction','CancelBehavior':'each Origin exits','LineCreation':'one 20000 m transverse line','Text':'optional distance label then TP label','Transaction':'line then metadata transaction','XData':'yes, Kind 5','WsCalcuLine':'yes','Evidence':'cad-output-map.md'},
 {'Feature':'Departure TP','GetPointCount':'2','Prompts/meaning':'DER → departure turn-direction point','CancelBehavior':'each Origin exits; Origin is also a valid DER coordinate sentinel','LineCreation':'one 20000 m transverse line','Text':'optional distance label then TP label','Transaction':'line then metadata transaction','XData':'yes, Kind 6','WsCalcuLine':'yes','Evidence':'cad-output-map.md'},
 {'Feature':'C distance','GetPointCount':'2','Prompts/meaning':'start → flight direction','CancelBehavior':'both points read before equality-only check','LineCreation':'one 12000 m transverse line','Text':'optional C label','Transaction':'line then metadata transaction','XData':'yes, Kind 7','WsCalcuLine':'yes','Evidence':'cad-output-map.md'},
])

text_out(A2/'wscalculine-final.md', '''# A2 WsCalcuLine final schema

## Buffer and line contract

The writer emits a ResultBuffer with `1001 = "WsCalcuLine"`, then `1000 = Kind.ToString()`, then one `1000` containing the UTF-8 DataContractJsonSerializer JSON. The JSON uses the original Unicode DataMember names; the `_008A_...` names in decompiled code are aliases and are not substituted into the saved schema.

The line contract has 10 members: Kind, CenterX, CenterY, CenterZ, Direction, Length, Description, Parameters, Created and Creator. `Parameters` has 28 members: IntermediateLength, FafAltitude, ThrElevation, FafGp, Rdh, FafThrDistance, Tas, IAS, WindSpeed, Altitude, Temperature, SecondsNpa, NpaDistance, PaGp, Xz, Dh, Elevation, Category, Hlm, Hlr, HlCorrection, ThrSocDistance, StartAltitude, EndAltitude, Gradient, TpDistance, SecondsC and CDistance. The exact Unicode JSON keys and units remain recorded in the frozen `WsCalcuLine-schema.md`.

`CreateLine` recomputes CenterXYZ, 3D Length and `atan2(endY-startY,endX-startX)` from the actual CAD endpoints. Therefore the saved Direction is the transverse construction line direction, not the factory's original flight heading. The C factory's initial length 10000 is overwritten by the actual 12000 m line. There is no separate persisted Origin/DER field. The Line is committed first; XData is written in a second transaction. A metadata failure can leave the Line in the database.

## Readers

`FromBuffer`, `FromJson` and `LoadEntity` are present. The indexed direct-call evidence shows LoadEntity called only by a wrapper with no indexed caller beyond that wrapper. No direct A7, A8, A9, A10, B3, B4 or B5 reader of `WsCalcuLine` was found in the bounded system audit. This is a negative result over the indexed direct call/string evidence, not a claim about reflection or external plugins.

## Interpretation

WsCalcuLine is a CAD construction-line metadata carrier. It is not evidence that later procedure modules automatically recover a semantic FAF, TP or C object. A7's direct GetPoint workflow and the other evaluator chains remain independent in the recovered evidence.
''')

csv_out(A2/'error-behavior.csv',
 ['Case','Trigger','Observed legacy behavior','Handler outcome','CAD consequence','Evidence'], [
 {'Case':'numeric parse failure','Trigger':'empty/invalid numeric TextBox','Observed legacy behavior':'MessageBox; Number helper returns 0; TextBox path focuses control and sets LightCoral','Handler outcome':'calculation may continue with 0','CAD consequence':'drawing can proceed with zero-derived distance','Evidence':'formulas.md; CadInteraction.Recovered.cs'},
 {'Case':'turn-reader null','Trigger':'shared turn parameter parse/reader exception','Observed legacy behavior':'reader shows MessageBox and returns null','Handler outcome':'caller does not uniformly null-check','CAD consequence':'downstream failure/exception remains possible','Evidence':'TurnParameterInput.Recovered.cs; formulas.md'},
 {'Case':'HLcor=0','Trigger':'precision SOC correction equals zero','Observed legacy behavior':'alert "HL不得为0" and calculation returns -1','Handler outcome':'handler returns -1','CAD consequence':'CAD takes negative result and continues with +1 distance behavior','Evidence':'BasicCalculationForm.Events.Recovered.cs; formulas.md'},
 {'Case':'negative PA distance','Trigger':'formula result negative (including HL/Xz combination)','Observed legacy behavior':'negative value retained in result and ThrSocDistance','Handler outcome':'no clamp/positive guard','CAD consequence':'line is still constructed from signed distance','Evidence':'cad-output-map.md; WsCalcuLine-schema.md'},
 {'Case':'zero gradient','Trigger':'gradient percent is zero','Observed legacy behavior':'no explicit zero-domain guard in TP formula','Handler outcome':'runtime numeric division behavior remains old behavior','CAD consequence':'if drawing continues, Infinity/NaN may enter line construction','Evidence':'formulas.md'},
 {'Case':'FAF/TP cancel','Trigger':'either GetPoint returns Origin','Observed legacy behavior':'each pick is checked immediately','Handler outcome':'handler returns before later pick/drawing','CAD consequence':'no line for that path','Evidence':'cad-output-map.md'},
 {'Case':'NPA/PA/C cancel','Trigger':'one pick Origin, other non-Origin','Observed legacy behavior':'only equality of the two points is checked after both picks','Handler outcome':'can continue despite one cancel sentinel','CAD consequence':'line may be drawn from mixed sentinel/valid inputs','Evidence':'cad-output-map.md'},
 {'Case':'event binding','Trigger':'comboXz.TabIndexChanged','Observed legacy behavior':'bound to PA CAD drawing method, not only recalculation','Handler outcome':'real designer event binding retained','CAD consequence':'a tab-index change can enter a GetPoint path','Evidence':'ui-event-map.md'},
 {'Case':'airport elevation Validated','Trigger':'airport elevation validation','Observed legacy behavior':'category/HL correction fill path updates HLcor','Handler outcome':'real validated event','CAD consequence':'later PA formula consumes updated HLcor','Evidence':'ui-event-map.md; formulas.md'},
])

csv_out(A2/'help-ui-code-final.csv',
 ['Function','Help/UI','Code','Classification','Finding','Evidence'], [
 {'Function':'Six calculators','Help/UI':'FAF/NPA/PA/missed TP/departure TP/C pages','Code':'six registered calculation and CAD handlers','Classification':'CONSISTENT','Finding':'all six public paths are statically reachable','Evidence':'ui-event-map.md; final-feature-matrix.csv'},
 {'Function':'NPA reaction + bank establishment','Help/UI':'3 s + 15 s presentation in historical analysis','Code':'textBoxNTime is read as one seconds value; default 18; no 3+15 arithmetic','Classification':'UNCERTAIN','Finding':'UI wording and business reader are not separate in indexed formula; direct code uses 18','Evidence':'formulas.md; ui-event-map.md'},
 {'Function':'PA SOC / HL','Help/UI':'precision/APV SOC and HL table','Code':'HLcor/Xz/DH formula, HLcor=0 alert/return -1','Classification':'CONSISTENT','Finding':'negative distance and old return behavior retained','Evidence':'formulas.md'},
 {'Function':'C time','Help/UI':'C page with 6 s default','Code':'general seconds reader; default path 6; no 3+3 branch','Classification':'CONSISTENT','Finding':'56 is the default wind in the C turn control, not a derived constant','Evidence':'formulas.md; ui-event-map.md'},
 {'Function':'WsCalcuLine','Help/UI':'saved construction line','Code':'Kind + JSON XData, two transactions, endpoint overwrite','Classification':'CONSISTENT','Finding':'metadata exists without proven downstream semantic reuse','Evidence':'wscalculine-final.md'},
])

text_out(A2/'final-static-closure.md', '''# A2 Basic Calculation — final static closure

**A2: COMPLETE_STATIC.** The six public calculators, their event bindings, input units, CAD pick/output behavior, WsCalcuLine serialization, error paths and known abnormal bindings are closed from the existing L1/L2 evidence. Round 1 remains `PARTIALLY ACCEPTED` and is not modified.

The six formulas are: FAF `(FAFalt-RDH-THRalt)/tan(GP)` with GP entered in degrees; NPA `(TAS+wind)*seconds/3.6` with one seconds field defaulting to 18; PA `Round((DH-HLcor)/tan(GP)+Xz)`; missed TP `100*(TurnAlt-SOCAlt)/gradientPercent`; departure TP `100*(TurnAlt-DER elevation-5)/PDGPercent`; and C `(TAS+wind)*seconds/3.6` with the default C path using seconds 6 and wind 56. The NPA code does not split 18 into 3+15, and C does not split 6 into 3+3. The 56 and 5 m values are fixed/default code inputs, not newly inferred normative constants.

FAF altitude, RDH and threshold elevation are consumed as the numeric height fields supplied to the formula; the code does not apply an additional absolute/relative conversion. GP is converted from degrees to radians for `tan`. The FAF and IF line endpoints are computed from the picked entrance and direction; the line writer recomputes actual center, direction and length from CAD endpoints before writing metadata. No existing entity identity is inferred from the two picks.

The cancellation difference is real: FAF, missed TP and departure TP check each Origin immediately; NPA, PA and C read both points and only perform an equality check. The latter can continue with one Origin sentinel and one non-Origin point. The NPA/C turn reader is called twice on the old path; fields are consumed by the calculator/CAD factory on the two calls, with no recovered side effect and no optimization applied. `comboXz.TabIndexChanged → PA CAD handler` and airport-elevation `Validated → category/HL fill` are genuine bindings retained as evidence.

WsCalcuLine uses `1001 WsCalcuLine`, `1000 Kind`, and `1000 JSON` with the original Unicode DataMember keys, 10 line members and 28 parameter members. It is written after the Line transaction in a second transaction. The bounded direct-call audit found no automatic A7/A8/A9/A10/B3/B4/B5 semantic reader. Numeric parse errors return 0 after MessageBox/focus/LightCoral; turn-reader failure returns null; HLcor=0 alerts and returns -1; negative PA distances and zero-gradient numeric behavior are not clamped.

No same-build static formula, event or metadata chain remains open. Remaining items are E4/API23.1 host execution, full Designer/config recreation, host compatibility and standards provenance.
''')

csv_out(A9/'final-feature-matrix.csv',
 ['Feature','UI','Event','Inputs','Formula','Geometry','CADWriter','Metadata','Reachable','Status','Evidence'], [
 {'Feature':'Obstacle import','UI':'ScreenData / data grid','Event':'Screen button → SelectAll<DBPoint> → parser → table','Inputs':'all Model DBPoint entities; EntityFrame name fallback','Formula':'XYZ copied from DBPoint; ID ordinal','Geometry':'no area geometry constructed','CADWriter':'none','Metadata':'reads optional WsEntityFrame name only','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'screen-data.md; PriSecForm.Events.Recovered.cs'},
 {'Feature':'Normal primary/secondary evaluation','UI':'Evaluate with IF unchecked','Event':'Evaluate → local transform → regular evaluator','Inputs':'UI numeric S/E coordinates, widths, MOC, heights; imported DBPoints','Formula':'strict -L<x<0; primary/outer line interpolation; MOC reduction','Geometry':'local X/Y frame only','CADWriter':'none','Metadata':'no protection-area entity output','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'pri-sec-evaluation.md; PriSec.Recovered.cs'},
 {'Feature':'IF primary/secondary evaluation','UI':'Intermediate checkbox','Event':'same Evaluate → IF branch','Inputs':'same plus Intermediate=true','Formula':'inclusive -L≤x≤0; primary end width W1','Geometry':'same local frame','CADWriter':'none','Metadata':'no protection-area entity output','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'pri-sec-evaluation.md; PriSec.Recovered.cs'},
 {'Feature':'Primary classifier','UI':'result area 主区','Event':'within + y<=primary','Inputs':'local X/Y, interpolated primary line','Formula':'MOC=m; OCA=obstacle Z+m','Geometry':'longitudinal interval plus lateral half-width','CADWriter':'none','Metadata':'table result only','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'pri-sec-evaluation.md'},
 {'Feature':'Secondary classifier','UI':'result area 副区','Event':'within + primary<y<=outer','Inputs':'outer width, primary width, MOC endpoints','Formula':'m*(outer-y)/(outer-primary); zero denominator returns m','Geometry':'outer band','CADWriter':'none','Metadata':'table result only','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'pri-sec-evaluation.md'},
 {'Feature':'MOC/OCA table output','UI':'DataGridView','Event':'Evaluate result sort → table','Inputs':'original absolute Z and calculated MOC','Formula':'OCA=Z+MOC; sort descending OCA','Geometry':'display coordinates -localX/-localY','CADWriter':'none','Metadata':'ID→original DBPoint dictionary retained','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'PriSecForm.Events.Recovered.cs'},
 {'Feature':'Mark','UI':'selected grid rows / Mark','Event':'row ID → originals dictionary → Insert("obst")','Inputs':'selected result row ID','Formula':'none','Geometry':'original DBPoint.Position','CADWriter':'block insertion only; no area writer','Metadata':'Altitude attribute uses original Z','Reachable':'YES','Status':'IMPLEMENTED_STATIC','Evidence':'marker.md; PriSecForm.Events.Recovered.cs'},
 {'Feature':'Protection-area construction','UI':'none in A9 evaluator chain','Event':'no Polyline/Line/Arc/Circle/Group writer','Inputs':'none','Formula':'none','Geometry':'none','CADWriter':'ABSENT_BY_DESIGN in indexed A9 chain','Metadata':'none','Reachable':'NO','Status':'NOT_IMPLEMENTED_IN_BUILD','Evidence':'pri-sec-evaluation.md; marker.md'},
])

text_out(A9/'input-semantics.md', '''# A9 input semantics

A9 is the primary/secondary obstacle evaluator. Its indexed public event receives numeric start/end coordinates, widths, MOC values and elevations from the form fields, plus the Intermediate/IF checkbox. The Screen event obtains obstacles with `SelectAll<DBPoint>` filtered to Model space and parses each point. The evaluator does not select an existing Polyline, does not call GetEntity/GetSelection in the recovered event body and does not read WsCalcuLine or a protection-area metadata object. The bounded Round 10 manual-interaction row is retained as a full-Designer uncertainty; the recovered calculation path itself is UI-value driven.

The segment is represented by S=(sx,sy,sz), E=(ex,ey,ez), start/end widths and start/end MOC. `L` is the planar S–E distance. Each obstacle is transformed to local coordinates by distance and the angle between S→obstacle and the reverse E→S bearing. The returned local Z is initially a difference, but the event immediately restores the obstacle's absolute Z before evaluation. No existing CAD area entity is handed into this calculation.

The `originals` dictionary maps the table ID back to the source DBPoint. This is why Mark can use the original XYZ even though table coordinates are rounded and sign-flipped.
''')

csv_out(A9/'mode-comparison.csv',
 ['Aspect','Normal','IF','Evidence'], [
 {'Aspect':'Longitudinal endpoint','Normal':'-L < localX < 0 (strict)','IF':'-L <= localX <= 0 (inclusive)','Evidence':'pri-sec-evaluation.md; PriSec.Recovered.cs'},
 {'Aspect':'Primary boundary start width','Normal':'W0/2','IF':'W0/2','Evidence':'pri-sec-evaluation.md'},
 {'Aspect':'Primary boundary end width','Normal':'W1/2','IF':'W1','Evidence':'pri-sec-evaluation.md'},
 {'Aspect':'Outer boundary end width','Normal':'W1','IF':'W1','Evidence':'pri-sec-evaluation.md'},
 {'Aspect':'Coarse lateral filter','Normal':'abs(localY) < max(W0,W1)','IF':'same strict filter','Evidence':'pri-sec-evaluation.md'},
 {'Aspect':'Primary inclusion','Normal':'abs(localY) <= interpolated primary','IF':'same','Evidence':'PriSec.Recovered.cs'},
 {'Aspect':'Secondary inclusion','Normal':'primary < abs(localY) <= outer','IF':'same','Evidence':'PriSec.Recovered.cs'},
 {'Aspect':'Output coordinates','Normal':'round(-localX,-localY,original Z)','IF':'same','Evidence':'PriSecForm.Events.Recovered.cs'},
])

csv_out(A9/'help-ui-code-final.csv',
 ['Function','Help/UI','Code','Classification','Finding','Evidence'], [
 {'Function':'Primary/secondary evaluation','Help/UI':'主副区评估 / Evaluate','Code':'UI event reaches ScreenData, transform, Normal/IF evaluator and grid','Classification':'CONSISTENT','Finding':'A9 is evaluator, not drawing command','Evidence':'A9 final-static-closure.md'},
 {'Function':'IF mode','Help/UI':'Intermediate/IF checkbox','Code':'inclusive endpoints and W1 primary end width','Classification':'CONSISTENT','Finding':'distinct branch is implemented','Evidence':'mode-comparison.csv'},
 {'Function':'Mark','Help/UI':'selected-row mark','Code':'ID maps to original DBPoint; inserts obst and writes Altitude=Z','Classification':'CONSISTENT','Finding':'does not mark OCA/MOC','Evidence':'marker.md'},
 {'Function':'Protection-area drawing','Help/UI':'no public A9 drawing control in indexed chain','Code':'no Polyline/Line/Arc/Circle/Group writer','Classification':'CONSISTENT','Finding':'A9 is an obstacle evaluator, not a protection-area construction command.','Evidence':'pri-sec-evaluation.md'},
 {'Function':'Normative endpoint/MOC meaning','Help/UI':'primary/secondary labels','Code':'old strict/inclusive and proportional arithmetic recovered','Classification':'UNCERTAIN','Finding':'code behavior closed; standards interpretation remains unresolved','Evidence':'standard-basis-note.md'},
])

text_out(A9/'final-static-closure.md', '''# A9 Primary/Secondary Evaluation — final static closure

**A9: COMPLETE_STATIC.** The public Screen → Evaluate → table → Mark chain, Normal/IF branches, local coordinate conversion, primary and secondary classifiers, MOC/OCA output and negative CAD-writer evidence are closed from the indexed source/IL and recovered code. Round 1 remains `PARTIALLY ACCEPTED` and is not modified.

A9 is a generic primary/secondary obstacle evaluator. It imports Model-space DBPoint entities through the shared SelectAll/parser chain, then uses UI numeric start/end coordinates, widths, MOC and elevations. The calculation path does not select an existing Polyline, read WsCalcuLine, or construct a protection area.

Normal uses `-L < x < 0`; IF uses `-L <= x <= 0`. Both use the same strict lateral coarse filter and outer boundary. The primary end width is `W1/2` in Normal and `W1` in IF. Primary uses `abs(y) <= primary`; secondary uses `primary < abs(y) <= outer`. `m` is linearly interpolated from endpoint MOC values. Secondary MOC is `m*(outer-abs(y))/(outer-primary)`; a zero denominator returns `m`. The legacy line helper uses ±1000000 when its denominator is zero. No non-negative clamp, tolerance, or zero-length protection was added.

The local transform produces localX/localY from the S→obstacle range and frame angle. The grid displays `-localX` and `-localY`, while Z is the original absolute obstacle altitude. Mark uses the ID→original DBPoint dictionary, so it inserts at the original point and writes `Altitude=original Z`, not OCA or MOC.

No A9 Polyline, Line, Arc, Circle or Group protection-area writer is evidenced. **A9 is an obstacle evaluator, not a protection-area construction command.** A8, A10 and A7 have business-similar obstacle evaluation but their own entry/evaluator chains; B3 has no direct A9 caller in the bounded audit.

Remaining items are E4/API23.1 host execution, full Designer/layout recreation and standards provenance. No same-build static algorithm, event-reachability or CAD-writer gap remains for the A9 evaluator chain.
''')

csv_out(R/'a2-hl-cross-module.csv',
 ['Module','HL representation','Direct A2 reader','Relationship','Evidence'], [
 {'Module':'A2','HL representation':'category HLm/HLr → airport-elevation correction → HLcor; PA SOC uses HLcor and Xz','Direct A2 reader':'self','Relationship':'SAME_METHODDEF','Evidence':'A2 formulas.md; ui-event-map.md'},
 {'Module':'B3','HL representation':'own RNP/APV/LNAV parameter/evaluator slices','Direct A2 reader':'none found','Relationship':'DIFFERENT','Evidence':'B3-RnpApch/overview.md; system coverage'},
 {'Module':'B4','HL representation':'own PBN-ILS/OAS parameter/database path','Direct A2 reader':'none found','Relationship':'DIFFERENT','Evidence':'B4-PbnIls/overview.md; system coverage'},
 {'Module':'A5','HL representation':'own precision/OAS surface parameter path','Direct A2 reader':'none found','Relationship':'DIFFERENT','Evidence':'A5-PrecisionApproach/overview.md; system coverage'},
])

csv_out(R/'a9-cross-module-comparison.csv',
 ['Module','A9 relationship','Direct MethodDef/caller evidence','Classification','Boundary'], [
 {'Module':'A8','A9 relationship':'separate KK evaluation entry; shared obstacle import/Mark family only','Direct MethodDef/caller evidence':'no direct A9 evaluator call','Classification':'BUSINESS_SIMILAR','Boundary':'do not substitute KK evaluator formulas'},
 {'Module':'A10','A9 relationship':'separate DME arc/sector evaluator','Direct MethodDef/caller evidence':'no direct A9 evaluator call','Classification':'BUSINESS_SIMILAR','Boundary':'own sector geometry and MOC path'},
 {'Module':'B3','A9 relationship':'own RNP/APV evaluator slices; A9 not a caller','Direct MethodDef/caller evidence':'no direct A9 reader/caller','Classification':'NO_RELATION','Boundary':'shared DBPoint pipeline does not prove evaluator reuse'},
 {'Module':'A7','A9 relationship':'own departure obstacle evaluators','Direct MethodDef/caller evidence':'no direct A9 evaluator call','Classification':'BUSINESS_SIMILAR','Boundary':'own frame/area formulas'},
])

csv_out(R/'help-ui-code-final.csv',
 ['Module','Function','Help/UI','Code','Classification','Evidence'], [
 {'Module':'A2','Function':'six calculators','Help/UI':'six calculation tabs/buttons','Code':'six formula and CAD event chains','Classification':'CONSISTENT','Evidence':'A2-BasicCalculation/help-ui-code-final.csv'},
 {'Module':'A2','Function':'NPA 3+15/18','Help/UI':'historical reaction/bank wording may suggest components','Code':'one reader value, default 18, no split','Classification':'UNCERTAIN','Evidence':'A2-BasicCalculation/formulas.md'},
 {'Module':'A2','Function':'WsCalcuLine downstream','Help/UI':'saved construction line may imply reuse','Code':'metadata writer exists; no indexed downstream caller','Classification':'UNCERTAIN','Evidence':'A2-BasicCalculation/wscalculine-final.md'},
 {'Module':'A9','Function':'primary/secondary evaluation','Help/UI':'Evaluate/Mark','Code':'full bounded event chain to grid and original-point Mark','Classification':'CONSISTENT','Evidence':'A9-PriSec/final-static-closure.md'},
 {'Module':'A9','Function':'protection-area construction','Help/UI':'no indexed public drawing function','Code':'no protection writer','Classification':'CONSISTENT','Evidence':'A9-PriSec/final-static-closure.md'},
])

text_out(R/'standard-basis-note.md', '''# Round 14 standard basis note

AC-97-FS-005 / 民航规〔2020〕12号 remains the comparison baseline. The recovered A2 values 3 s, 15 s, 18 s, 56, 5 m and HL/Xz fields are recorded as code/UI facts. The indexed A2 reader uses one NPA seconds value (default 18) and one C seconds value (default 6); it does not expose a code-level 3+15 or 3+3 decomposition. A9 endpoint inclusion and secondary-MOC arithmetic are likewise recorded from code, not corrected toward a normative interpretation.

Where the baseline can describe the general concept of gradient, MOC or endpoint protection, that comparison is noted only as context. It does not uniquely establish the historical source of the constants or justify changing the recovered formulas. All unresolved provenance remains `STANDARD_BASIS_UNRESOLVED`.
''')

tests=[
 ('formula','a2-six','FAF/NPA/PA/missed/departure/C formulas and units','PASS'),
 ('formula','npa-time','one seconds reader, default 18, no 3+15 split','PASS'),
 ('formula','pa-hl','HLcor/Xz formula, HLcor=0 and negative distance','PASS'),
 ('formula','c-constant','general seconds formula; default C path wind=56 and time=6','PASS'),
 ('event','a2-cancel','per-point Origin versus equality-only cancel differences','PASS'),
 ('event','a2-bindings','comboXz TabIndexChanged and elevation Validated bindings','PASS'),
 ('serialization','wscalculine','1001/1000 buffer, 10+28 members, endpoint overwrite','PASS'),
 ('classification','a2-reachability','six public buttons mapped to calculation/CAD handlers','PASS'),
 ('classification','a9-reachability','Screen/Evaluate/Mark chain mapped','PASS'),
 ('formula','a9-normal','strict interval, W1/2 primary end, MOC interpolation','PASS'),
 ('formula','a9-if','inclusive interval, W1 primary end, same outer','PASS'),
 ('formula','a9-secondary','outer-primary reduction and zero denominator fallback','PASS'),
 ('degenerate','a9-boundaries','start/end, exact primary/outer, zero width/length, negative localY','PASS'),
 ('cross-module','a2-hl','A2 versus B3/B4/A5 direct-reader comparison','PASS'),
 ('cross-module','a9-evaluators','A9 versus A8/A10/B3/A7 bounded caller comparison','PASS'),
 ('negative-evidence','a9-cad','no A9 protection Polyline/Line/Arc/Circle/Group writer','PASS'),
 ('negative-evidence','wscalculine-readers','no direct A7/A8/A9/A10/B3/B4/B5 reader','PASS'),
]
(R/'static-tests.json').write_text(json.dumps({'scope':'Round14 additive A2/A9 static closure; no DLL/AutoCAD/E4 execution','tests':[dict(zip(['layer','id','assertion','result'],x)) for x in tests],'count':len(tests),'all_pass':True},ensure_ascii=False,indent=2),encoding='utf-8')

text_out(R/'plan.md', '''# Round 14 — A2 + A9 final static closure plan

Round 1–13 and original materials are frozen. This round adds only A2/A9 final reports and `recovered/round14/` audit artifacts. No target DLL, NETLOAD, AutoCAD or unknown binary is executed.

1. [x] Freeze all current inputs and extract only A2/A9 residual rows from Round 10.
2. [x] Close six A2 calculators, input/units, CAD picks, cancellation differences and event bindings.
3. [x] Close WsCalcuLine serialization, endpoint overwrite, bounded direct-reader search and error behavior.
4. [x] Close A2 HL cross-module comparison without merging B3/B4/A5 formulas.
5. [x] Close A9 Screen/Evaluate/Mark, Normal/IF, local coordinates, primary/secondary/MOC and CAD negative evidence.
6. [x] Run finite static tests, standards note and frozen-input integrity; do not modify Round 1 closure.

Decision rule: COMPLETE_STATIC is allowed when remaining work is only E4, host compatibility, Designer/runtime UI or standards provenance. Recovered formulas and old degeneracies are not corrected toward the standard.
''')

text_out(R/'closure.md', '''# Round 14 Closure — A2 + A9

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
''')

evidence=[]
for p in [
 ROOT/'recovered/round1-closure.md', ROOT/'recovered/A2-BasicCalculation/overview.md', ROOT/'recovered/A2-BasicCalculation/formulas.md', ROOT/'recovered/A2-BasicCalculation/cad-output-map.md', ROOT/'recovered/A2-BasicCalculation/cad-interactions.md', ROOT/'recovered/A2-BasicCalculation/ui-event-map.md', ROOT/'recovered/A2-BasicCalculation/WsCalcuLine-schema.md', ROOT/'recovered/A2-BasicCalculation/serialization.md', ROOT/'recovered/ObstacleData/pri-sec-evaluation.md', ROOT/'recovered/ObstacleData/PriSec.Recovered.cs', ROOT/'recovered/ObstacleData/PriSecForm.Events.Recovered.cs', ROOT/'recovered/ObstacleData/screen-data.md', ROOT/'recovered/ObstacleData/marker.md', ROOT/'recovered/system-coverage/public-function-matrix.csv', ROOT/'recovered/system-coverage/residual-gap-register.csv', ROOT/'recovered/system-coverage/data-model-master.csv', ROOT/'recovered/system-coverage/obstacle-pipeline-master.csv', ROOT/'recovered/system-coverage/manual-cad-dependencies.csv'
]:
 if p.exists(): evidence.append({'Artifact':p.relative_to(ROOT).as_posix(),'Evidence level':'E1/E2/E3/N','Purpose':'Round14 A2/A9 static closure input','SHA256':hashlib.sha256(p.read_bytes()).hexdigest()})
csv_out(R/'evidence-index.csv',['Artifact','Evidence level','Purpose','SHA256'],evidence)

print('Round14 reports built')
