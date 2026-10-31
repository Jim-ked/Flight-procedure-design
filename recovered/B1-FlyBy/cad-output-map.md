# B1 CAD output map

The handler sends `_008C_0087` plus the `showSpiral`, `showBoundary`, `showNominalTrack`, `showTolerance`, `NN`, and `KK` checkboxes to `_0089_0089_009A`. The writer and shared CAD helper bodies are now recovered; list aviation semantics remain neutral where no writer metadata proves them. See `cad-writer.md`, `boundary-vertices.csv`, and `xdata-schema.md`.

| Output | Evidence-backed behavior | Remaining gap |
|---|---|---|
| spiral | `_0089_009D_0090` sample lists | Group of zero-bulge Polyline children; no explicit layer |
| boundary | `_0089_009D_008E` / `_0089_009D_008F` and companion lists | vertex expressions indexed in `boundary-vertices.csv` |
| nominal | `_0089_009D_0093` descriptor | four-vertex Polyline, middle bulge `tan(delta/4)` |
| NN / KK | independent checkbox arguments | list identities are proven; aviation semantic mapping remains implementation basis to be confirmed |

No direct `IntersectWith`, `Offset`, `Trim`, `Extend`, delete/rebuild or XData write is present in the B1 geometry classes. This does not exclude a helper outside the selected writer slice.
