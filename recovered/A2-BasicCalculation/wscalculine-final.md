# A2 WsCalcuLine final schema

## Buffer and line contract

The writer emits a ResultBuffer with `1001 = "WsCalcuLine"`, then `1000 = Kind.ToString()`, then one `1000` containing the UTF-8 DataContractJsonSerializer JSON. The JSON uses the original Unicode DataMember names; the `_008A_...` names in decompiled code are aliases and are not substituted into the saved schema.

The line contract has 10 members: Kind, CenterX, CenterY, CenterZ, Direction, Length, Description, Parameters, Created and Creator. `Parameters` has 28 members: IntermediateLength, FafAltitude, ThrElevation, FafGp, Rdh, FafThrDistance, Tas, IAS, WindSpeed, Altitude, Temperature, SecondsNpa, NpaDistance, PaGp, Xz, Dh, Elevation, Category, Hlm, Hlr, HlCorrection, ThrSocDistance, StartAltitude, EndAltitude, Gradient, TpDistance, SecondsC and CDistance. The exact Unicode JSON keys and units remain recorded in the frozen `WsCalcuLine-schema.md`.

`CreateLine` recomputes CenterXYZ, 3D Length and `atan2(endY-startY,endX-startX)` from the actual CAD endpoints. Therefore the saved Direction is the transverse construction line direction, not the factory's original flight heading. The C factory's initial length 10000 is overwritten by the actual 12000 m line. There is no separate persisted Origin/DER field. The Line is committed first; XData is written in a second transaction. A metadata failure can leave the Line in the database.

## Readers

`FromBuffer`, `FromJson` and `LoadEntity` are present. The indexed direct-call evidence shows LoadEntity called only by a wrapper with no indexed caller beyond that wrapper. No direct A7, A8, A9, A10, B3, B4 or B5 reader of `WsCalcuLine` was found in the bounded system audit. This is a negative result over the indexed direct call/string evidence, not a claim about reflection or external plugins.

## Interpretation

WsCalcuLine is a CAD construction-line metadata carrier. It is not evidence that later procedure modules automatically recover a semantic FAF, TP or C object. A7's direct GetPoint workflow and the other evaluator chains remain independent in the recovered evidence.
