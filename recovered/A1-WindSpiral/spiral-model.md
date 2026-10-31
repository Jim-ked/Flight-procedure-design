# A1 spiral numerical model

## Formula

For angle `θ`, constructor offset `o`, wind radius `E_sita`, turn radius `R`, drift `δ`, origin `O`, heading `h`, and direction sign `s∈{+1,-1}` the processed `_008F_0086._008A_009E_0093` body is equivalent to:

```text
q       = θ * E_sita + o + extraOffset
d       = sqrt(R² + q² + 2 R q cos δ)
θ_eff   = θ - asin(q sin δ / d)
P(θ)    = O + d * (cos(s*θ_eff+h), sin(s*θ_eff+h))
```

The no-wind limit (`E_sita=0`, `δ=0`) is exactly the base circle of radius `R`. This is a code-derived limit check, not a normative claim.

The base-circle method `_008A_009E_0094` is `O + R*(cos(sθ+h), sin(sθ+h))`. `Radius` exposes `d` without the final angular correction.

## Sampling

`_008A_009E_0091` starts at `start`, increments by `stepDegrees*pi/180` (default 1°), emits each point while below `end`, and then emits one exact `end` point. The terminal point is included even when the increment does not divide the interval. `_008A_009E_0092` preserves the source's alternating split-list counter; it is not equivalent to a single decimated polyline.

The parameter is a turn angle, not time. There is no time integration in this class. Wind displacement is a linear scalar term in angle; `P793` supplies the scalar wind radius and drift.

## Inverse/iteration helpers

The angle inverse uses up to 20 fixed-point updates. The line-distance helper uses midpoint bisection with a `0.01` distance tolerance and up to 20 iterations. These tolerances are literal recovered constants.

## Mechanical recovery carrier

[WindSpiral.Recovered.cs](../GeometryPrimitives/WindSpiral.Recovered.cs) preserves the sign, offsets, endpoint, split behavior and unconstrained `asin`/zero-radius behavior. The carrier is tested with no-wind, head/tail/cross-wind, left/right and 90/180/270° fixtures. It is not linked to Autodesk or the original DLL.
