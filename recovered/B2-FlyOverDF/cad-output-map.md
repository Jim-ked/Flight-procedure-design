# B2 CAD output map

The B2 event passes `_0089_0089_009B` (show primary), `_0089_0089_009A` (show secondary), nominal, spiral and tolerance switches to `_0089_008B_008B`. The writer receives the independent `_008C_0089` model and center descriptor. The full dispatch order is recorded in `cad-writer.md` and `round3/cad-entity-order.csv`.

The static geometry slice and shared helper prove list construction, path pairs, Group creation and `WsObject` XData on metadata-bearing child entities. No direct `IntersectWith`, `Offset`, trim/extend, erase/rebuild or automatic entity selection is in `_008C_0089` or its writer path. Exact fixed 12000/13000 path pairs are indexed in `boundary-vertices.csv`.
