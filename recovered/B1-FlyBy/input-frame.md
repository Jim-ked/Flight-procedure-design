# B1 input frame and manual interaction

## Three points

The processed handler `_0089_0089_0093` / original `0x060004C0` calls `GetPoint` three times with the literal prompts `请输入起点`, `请输入转弯点`, and `请输入终点` (source lines 52290–52305). The heading code computes `atan2(point2-point1)` and `atan2(point3-point2)`, so the first point is the incoming-segment reference, the second is the fly-by waypoint, and the third is the outgoing-segment reference.

The software cannot infer these points from an existing route entity in this chain; the values are raw XY points and go directly into three `_008C_0099` constructors. That is a real CAD manual dependency.

## Numeric fields

| UI field | Event local / destination | Direct use |
|---|---|---|
| `textBoxATT` | `num` → middle descriptor `_008A_008C_009E` | B1 earliest/latest formulas |
| `textBoxSW1` | `num2` → first and middle widths | segment offsets |
| `textBoxSW2` | `num3` → last width | width mismatch branch |
| `textBoxReactTime` | `num4` → middle `_008A_008D_0086` | latest distance |
| `textBoxBankAngleDelay` | `num5` → middle `_008A_008D_0087` | latest distance |

The default constructor width is `4630.0`, but the event overwrites widths from UI. Presets include other values; there is no direct evidence that B1 is restricted to RNP1.
