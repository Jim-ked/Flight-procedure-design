# B1 Fly-by recovery

**Status: partial static recovery.** Input frame, shared turn parameter, earliest/latest scalar formulas, copied `_008C_0087` geometry branches and CAD dispatch are indexed. A complete boundary vertex port is not claimed.

The event prompts `起点 → 转弯点 → 终点`, creates three `_008C_0099` segment descriptors and passes them to `_008C_0087` (processed P5A0 / original constructor). The descriptors use `RNAV1` as a default name, but the event does not hard-code a normative RNAV1 algorithm; menu presets provide several widths.

`_008C_0087` is not a wrapper around the A1 form. It allocates two `_008F_0086` spirals, computes headings and signed shortest turn angle, then builds separate earliest/late and primary/secondary lists. It contains explicit `A≤60°`, `A≤90°`, and `A>90°` branches, a `A>120°` warning, 15°/30° connections, and candidate-distance selection.

The detailed input mapping is in [input-frame.md](input-frame.md), branch evidence in [geometry.md](geometry.md), and entity dispatch in [cad-output-map.md](cad-output-map.md).
