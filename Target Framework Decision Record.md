# Target Framework Decision Record

| Option | Recovered C# | AutoCAD host compatibility | Tests/numerics | Decision |
|---|---|---|---|---|
| `netstandard2.0` | Likely after compatibility shims; unverified here | Best bridge for old Framework and newer hosts | Broad library/test support; adequate `System.Math` | Preferred future baseline, not frozen |
| `net8.0` | Requires SDK/project conversion and API review | Good for modern hosts, poor for legacy in-process hosts | Best tooling and maintenance | Future option, not verified |
| Multi-target | Requires an SDK and explicit API split | Can serve both host generations | Highest test/build cost | Revisit after host matrix is confirmed |

## I0.5-R decision

The core decision is **netstandard2.0 when the SDK build machine is available** for `Fpd.Domain`, `Fpd.Engine`, `Fpd.Application`, and the pure calculation portion of `Fpd.Legacy.WindSpiral`. `Fpd.Infrastructure` should remain portable while it contains only in-memory ports. A future `Fpd.AutoCAD` adapter will choose its target from the confirmed AutoCAD host matrix and will not force the core down to that host's framework.

This is a formal direction, not a local build claim. The machine has no SDK or targeting pack, so `netstandard2.0`, `net8.0`, and multi-target builds remain **UNVALIDATED**. The old C#5/.NET Framework v4.0 projects are retained solely as a diagnostic compatibility harness and are not the new system's permanent framework baseline.

No AutoCAD reference is permitted until host version, API level, and target framework are confirmed. This record is a build decision, not a business-rule decision.
