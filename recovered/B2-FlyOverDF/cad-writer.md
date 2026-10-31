# B2 Fly-over DF CAD writer recovery

The event `0x060004DF`/original `0x060004E0` calls `_0089_008B_008B` with arguments (annotated source line 53390):

| Writer argument | Actual control | Output branch |
|---|---|---|
| P2 | `showNorminalTrack` | four-vertex nominal connection descriptor |
| P3 | `showPriBoundary` (`主区边界`) | `_0089_009D_008E`, then `_0089_009D_008C` |
| P4 | `showSecBoundary` (`副区边界`) | `_0089_009D_008F`, then `_0089_009D_008D` |
| P5 | `showSpiral` (`辅助线`) | Group `_0089_009D_0090` |
| P6 | `showTolerance` | transformed tolerance Polyline |

The recovered writer order is: nominal descriptor; primary list E; primary list C; secondary list F; secondary list D; spiral Group; tolerance list. Each list is written with `_008B._0088_008A` (one open zero-bulge Polyline), while `_0089_009D_0090` is written with `_008B._0088_008B` (one Polyline per inner list plus a Group). All P8 metadata-bearing paths call `_0088_008D`; the tolerance call omits P8.

The writer does not perform `IntersectWith`, `Offset`, trimming, extending, erase/rebuild, entity selection, layer assignment, color assignment, or text creation. Those operations therefore remain absent from this chain.
