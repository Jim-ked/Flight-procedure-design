# B1 CAD metadata schema

The B1 writer passes the form string `_0089_0089_009D.ToString()` as metadata P9 for the writer-created entities. The shared `_0088_008D` helper writes this only when `P9.Trim().Length > 0`:

```text
RegAppTableRecord.Name = "WsObject"
ResultBuffer = [(1001, "WsObject"), (1000, P9)]
entity.XData = ResultBuffer
```

The four-list and Group paths all call `_0088_008D(..., P9)`, so their child polylines receive the same `WsObject` payload. The Group object itself is added to the database but is not passed through `_0088_008D`; no XData assignment to the Group is evidenced. The tolerance path calls `_0088_008A` without P9 and therefore has no `WsObject` write in this path.

No layer, color, linetype, text entity, block attribute, extension dictionary, or `WsInfo` write is present in the recovered B1 writer slice. The nominal connection descriptor writes a four-vertex Polyline through `_0088_008D` and therefore follows the same `WsObject` branch.

Evidence: annotated source `_008B._0088_008D` lines 1578–1655, `_0089_0089_009A` lines 52420–52462, and `_008C_008B._0089_009E_0090` lines 68440–68466.
