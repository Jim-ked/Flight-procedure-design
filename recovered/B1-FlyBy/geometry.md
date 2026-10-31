# B1 geometry branches

## Scalar setup

The constructor computes `A = shortestSignedTurn(inHeading,outHeading)` and `n = R*tan(A/2)`. Direct processed body lines 66656–66657 give:

```text
earliest = ATT + n
latest   = n - ATT - (ReactTime + BankAngleDelay)*(TAS + Wind)/3.6
```

The sign of the turn is selected by `_008B_009E._0089_009C_0097`; the `A>120°` branch only shows `旁切转弯角度不得大于120度。` and does not substitute a normative formula.

## Boundary construction

`_008C_0087._0089_009D_0094` and `_0089_009D_0095` create separate lists for nominal/earliest and secondary paths. They instantiate wind spirals with the signed heading, sample them, construct line carriers from points and headings, and choose between candidate intersections by comparing distances. Actual constants include `PI/6` (30°), `PI/12` (15°), `PI/2`, and `1.5*width` checks. Branch thresholds are `A≤PI/3`, `A≤PI/2`, otherwise `A>90°`; the warning threshold is `2PI/3`.

The source has explicit width mismatch inputs because the first/middle and last descriptors carry `SW1` and `SW2` independently. The recovered static code does not support the claim that one side “always expands”: the side is selected by signed heading, candidate distance and the two descriptor widths. The SW1<SW2 and SW1>SW2 fixtures therefore remain evidence cases, not normative expectations.

## NN′ / KK′ and inner/outer claims

The event passes checkboxes named `checkBoxNN` and `checkBoxKK` to the CAD writer. In the available static slice, these are display switches for lists; no separate XData schema or obstacle evaluator call is proven. The list variables `_0089_009D_0091` and `_0089_009D_0092` are stored geometry carriers, but their semantic labels cannot be upgraded from names alone.

There is implementation evidence for 15°/30° connection candidates and distance selection. There is **no direct evidence of an independent A/2 convergence rule**. Any mapping to primary/secondary aviation terms is marked implementation basis to be confirmed.
