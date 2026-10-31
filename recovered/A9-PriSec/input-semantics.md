# A9 input semantics

A9 is the primary/secondary obstacle evaluator. Its indexed public event receives numeric start/end coordinates, widths, MOC values and elevations from the form fields, plus the Intermediate/IF checkbox. The Screen event obtains obstacles with `SelectAll<DBPoint>` filtered to Model space and parses each point. The evaluator does not select an existing Polyline, does not call GetEntity/GetSelection in the recovered event body and does not read WsCalcuLine or a protection-area metadata object. The bounded Round 10 manual-interaction row is retained as a full-Designer uncertainty; the recovered calculation path itself is UI-value driven.

The segment is represented by S=(sx,sy,sz), E=(ex,ey,ez), start/end widths and start/end MOC. `L` is the planar S–E distance. Each obstacle is transformed to local coordinates by distance and the angle between S→obstacle and the reverse E→S bearing. The returned local Z is initially a difference, but the event immediately restores the obstacle's absolute Z before evaluation. No existing CAD area entity is handed into this calculation.

The `originals` dictionary maps the table ID back to the source DBPoint. This is why Mark can use the original XYZ even though table coordinates are rounded and sign-flipped.
