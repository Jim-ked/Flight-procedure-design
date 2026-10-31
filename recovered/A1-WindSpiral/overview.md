# A1 WindSpiral recovery

**Status: PARTIAL static closure.** The numerical spiral generator and the three UI-to-CAD branches are recovered; the full designer/resource wiring and original-host runtime are not.

## Event and input chain

The event index is [event-map.md](event-map.md). `buttonSingle`, `buttonDouble` and the triple-like handler read the shared turn control, then construct one, two or three `_008F_0086` instances. The single branch prompts exactly:

1. `请输入第一条风螺旋的起点`
2. `请输入第二条风螺旋的起点`
3. `请输入第三条风螺旋的起点`

The first and second points define `heading = atan2(point1-point2)`. Each origin is shifted back by `turnRadius*(cos heading, sin heading)`. The third point is used to derive the ending angle; it is not ignored.

## Display branches

* `show base circle` creates three `Circle` entities centered at the three shifted origins with the turn radius.
* The optional start/end/tangent display lists use `Point`, `BaseCirclePoint` and the stored shifted origins.
* The nominal long path concatenates sampled lists from spiral 1 and 2, then conditionally spiral 3. The helper is a list concatenator, not a tangent solver.
* The Polyline branch calls the recovered CAD polyline helper with the concatenated points. The Spline branch calls `new Spline(list4._008C_008C(), 4, 0.0)`: degree 4, fit-point sequence, open by constructor evidence. No `closed=true` assignment appears in this branch.
* The XData selector (`button1`) reads the selected entity's second `TypedValue` as turn-parameter JSON; missing XData produces the explicit warning. CSV export (`button5`) serializes the spiral's output rows and starts the file with `Process.Start`.

## Direction and offsets

The constructor maps the direction checkbox to `DirectionSign = +1/-1`. `initial offset` is the constructor offset and the event's optional `DA`/angle input is added to the sampling offset. No separate world-fixed wind vector is added after point generation; wind enters through the scalar `angle*WindRadius + offset` and the fixed drift angle from P793.

## Manual CAD interaction

The three `GetPoint` calls select the three business anchors. The first two are required to establish the incoming heading; the third supplies the outgoing/end direction. The source contains no programmatic way to infer these anchors from an existing route object. This is an explicit manual dependency, not merely a UI convenience.

## Evidence and limits

Primary source slice: [A1 `_0089_0094`](evidence/_0089_0094.source.txt), lines 35713–35804. Numerical body: processed methods-only class `_008F_0086`, source lines 14454 onward; event calls processed P7A1/P7A3/P7A5/P7A6/P7AD. CAD output and XData are direct event evidence. The recovered C# is a mechanical test carrier, not a claim that the original source was written in this form.
