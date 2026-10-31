# B1/B2 Executability Audit

## Executable now

- DTO parsing, writer plans, scalar ATT/angle formulas and static branch evidence can be inspected.
- `BoundarySlot`, `AuxGeometry`, and `LegacyBoundaryId` are available as neutral carriers.

## Recoverable from static evidence

- Several candidate branch outputs and writer ordering can be compared to round13 fixtures.
- Full pure boundary computation may be recovered only by preserving the indexed IL/decompiled method bodies and proving every input/output path.

## Still missing

- A directly executable, pure complete B1 boundary calculation contract.
- A directly executable, pure complete B2 boundary calculation contract.
- Normative meaning for KK/NN and Primary/Secondary labels.

## Blocked

The current recovered C# does not provide a complete build-ready calculation body that can be safely wrapped without creating an algorithm. Therefore this round deliberately does **not** add `RecoveredFlyByTurnEngine` or `RecoveredFlyOverTurnEngine`, and does not infer semantics from list order, color, layer, XData, or 60/90/120-degree branches. B1 and B2 remain `IntegrationStatus = Recovered`.
