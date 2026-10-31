# B1 Fly-by CAD writer recovery

Status: writer chain recovered from the annotated decompilation and shared helper source; aviation labels for individual lists remain unresolved.

## Direct call order

The event `0x060004BF`/original `0x060004C0` constructs `_008C_0087` and calls `_0089_0089_009A` (annotated source line 52313). The arguments are, in order:

| Writer argument | Actual control | Direct source evidence |
|---|---|---|
| P2 | `showNorminalTrack` | `_0089_008A_0092`, UI text `标称航迹`, line 52793–52807 |
| P3 | `showBoundary` | `_0089_008A_0091`, UI text `保护区`, line 52815–52826 |
| P4 | `checkBoxKK` | `_0089_008A_008F`, UI text `KK'线`, line 53164–53168 |
| P5 | `checkBoxNN` | `_0089_008A_008E`, UI text `NN'线`, line 52814 |
| P6 | `showSpiral` | `_0089_008A_0090`, UI text `辅助螺旋`, line 53169–53180 |
| P7 | `showTolerance` | `_0089_008A_0093`, UI text `容差显示`, line 53283–53287 |

The writer body (original source line 52420) executes this order:

1. If P2 and `_0089_009D_0093 != null`, call `_0089_009D_0093._0089_009E_0090(db, metadata)`.
2. If P3, append four independent lists with `_008B._0088_008A`: `BoundaryList03` (`_0089_009D_008E`), `BoundaryList01` (`_0089_009D_008C`), `BoundaryList04` (`_0089_009D_008F`), `BoundaryList02` (`_0089_009D_008D`).
3. If P4, append `BoundaryList05` (`_0089_009D_0091`).
4. If P5, append `BoundaryGroup02` (`_0089_009D_0092`) through `_008B._0088_008B`.
5. If P6, append `SpiralGroup01` (`_0089_009D_0090`) through `_008B._0088_008B`.
6. If P7, append the tolerance list returned by `_008C_0099._008A_008C_009A(center)` through `_008B._0088_008A`; this call has no metadata argument.

`_008B._0088_008A` creates one open `Polyline` with zero bulge for every point and calls `_0088_008D`. `_008B._0088_008B` creates one zero-bulge `Polyline` per inner list, appends each returned `ObjectId` to a new `Group`, adds the group to the database, and commits. Neither helper sets a layer, color, or linetype in the recovered body.

## NN'/KK' conclusion

The UI names are direct evidence that P4/P5 are display controls for KK'/NN'. The writer proves only which recovered lists are emitted under those controls. It does not write a semantic label, an entity name, or a distinct XData application for either line. Therefore `BoundaryList05` and `BoundaryGroup02` are neutral names; assigning one to a normative primary/secondary or inner/outer boundary is **implementation basis to be confirmed**.

## Evidence classes

* Direct assembly/source: event and writer call order, helper bodies, `WsObject` XData branch.
* Decompilation/IL recovery: list field identities and branch structure in `_008C_0087`.
* Inference: neutral list labels and any aviation interpretation of NN'/KK'.
