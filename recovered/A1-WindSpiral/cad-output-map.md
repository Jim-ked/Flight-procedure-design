# A1 CAD output map

| Chain | Entity / construction | Evidence | Notes |
|---|---|---|---|
| start/end/nominal lists | CAD polyline helper `_008B._0088_008A` | `_0089_0094.source.txt` 35778–35804 | Point sequence is supplied by spiral/base-circle methods. |
| long path | `Polyline` or `Spline` | 35791–35804 | Checkbox chooses Polyline; otherwise Spline fit points, degree 4, tolerance 0.0. |
| base circles | `Circle(center, ZAxis, turnRadius)` | 35781–35785 | Three circles, one per shifted origin. |
| metadata | XData read on selected entity; CSV export | event-map / source | No new writer schema is proven in the drawing branch. |

Layer/group names are delegated to the existing CAD helper and are not recoverable from this handler alone. No `IntersectWith`, `Offset`, `Trim`, `Extend`, erase/rebuild or closed-polyline assignment is evidenced in the A1 chain.
