# B2 CAD metadata schema

The event passes `_0089_008B_008E.ToString()` as P8. For every nominal, primary, secondary, and spiral child entity, `_0088_008D` registers/uses `WsObject` and writes typed values `(1001, "WsObject")`, `(1000, P8)` when P8 is non-empty. The Group created for `_0089_009D_0090` is not assigned XData by the helper. The tolerance branch uses `_008A_008C_009A(...)` followed by `_0088_008A` without a description, so this branch has no `WsObject` XData in the recovered call path.

No B2-specific RegApp, layer, color, linetype, DBText/MText, extension dictionary, or block metadata write is evidenced.
