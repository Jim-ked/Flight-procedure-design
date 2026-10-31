# Turn parameter primitive (P793)

**Scope.** This is a static recovery of processed `0x06000793` / original `0x06000794` (source RVA `0xC3820` in the processed map). The independent IL slice is [0x06000793.il.txt](../A2-BasicCalculation/evidence/0x06000793.il.txt); the existing mechanical port is [TurnParameterInput.Recovered.cs](../A2-BasicCalculation/TurnParameterInput.Recovered.cs). No original DLL was loaded.

## Recovered computation

The constructor stores the five values supplied by the shared input reader and executes the following operations, in this order:

```text
K       = 171233 * sqrt(288 + Temperature - 0.006496 * Altitude)
          / pow(288 - 0.006496 * Altitude, 2.628)
TAS     = IAS * K
Rate    = min(6355 * tan(Bank * pi / 180) / (pi * TAS), 3)
Radius  = 1000 * TAS / (pi * 20 * Rate)
E_sita  = 1000 * Wind / (pi * 20 * Rate)       // stored as WindRadius
Drift   = asin(Wind / TAS)
```

The IL constants `171233`, `288`, `0.006496`, `2.628`, `6355`, `20`, `62.83185307179586` and the calls to `Math.Sqrt`, `Pow`, `Tan`, `Min`, `Asin` are direct evidence. The code does not branch on turn direction here; left/right is carried by downstream geometry signs and coordinate transforms.

`ToString()` derives display values from `WindRadius`, rather than integrating a separate wind path:

```text
Eθ = θ * pi / 180 * WindRadius
E45 = pi/4 * WindRadius; E90 = pi/2 * WindRadius
E135 = 3*pi/4 * WindRadius; E180 = pi * WindRadius
E235 = 4.101523742186674 * WindRadius
C6 = (TAS + Wind) / 0.6
```

Therefore `Eθ` is a linear display/parameter family. There is no IL evidence here for numerical integration or a separate `E_sita` field. `DraftAngle` in the UI is the stored `Drift` (the existing port labels it `Drift`).

## Input and defaults

The reader is processed `0x06000854` / original `0x06000855`; it converts text to doubles and applies `1.852` only when the two unit selectors are checked. A7 constructs P793 directly; A1/B1/B2 obtain the same object through their turn-parameter control. UI defaults and menu presets are not internal formula assumptions.

## Cross-check fixture

The Round 2 fixture (`IAS=300`, `Altitude=305`, `Temperature=15`, `Bank=15°`, `Wind=60`) gives approximately `TAS=312.32 km/h`, `Rate=1.74°/s`, `Radius=2864 m`, `WindRadius=550.1 m`, `Drift=11.08°`, `E90=864 m`, and `C6=621 m`, matching [round2/tests.log](../round2/tests.log). This is recovery-code verification only.

## Evidence limits and specification mapping

AC-97-FS-005 / 民航规〔2020〕12号 is a comparison baseline, not a source for missing code. The temperature/density correction, capped rate, 20-second denominator, and linear Eθ display may reflect an older ICAO/domestic version or author simplification. Their **implementation basis remains to be confirmed**; this report does not replace them with the current specification formula.
