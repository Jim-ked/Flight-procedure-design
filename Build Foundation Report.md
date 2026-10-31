# I0.5 Build Foundation Report

## Environment

- `dotnet --info`: host 9.0.5; no .NET SDK installed; runtimes 7.0.20, 8.0.12/11 and 9.0.5.
- Local compiler: MSBuild 4.8.10001.0 / C# compiler 14.8, C# 5 compatible mode.
- AutoCAD host/SDK matrix: not frozen; no Autodesk reference is used.

## Target decision

`netstandard2.0` remains the preferred future portable target, but it cannot be build verified without an SDK. `net8.0` is also not verifiable on this machine. The checked-in projects therefore use a provisional old-style .NET Framework v4.0 compatibility build only. See [Target Framework Decision Record](Target Framework Decision Record.md).

## Solution and dependency shape

`Fpd.sln` contains Domain, Engine, Application, Legacy.WindSpiral, Infrastructure, and four executable test projects. Production dependencies are Domain <- Engine <- Application <- Infrastructure, with Legacy.WindSpiral consuming Domain. The current compatibility files use prebuilt DLL hint paths because this MSBuild host throws an internal `MSB1025/FormatException` while traversing solution project references.

## Build result

- Sequential compatibility build of all nine projects: **PASS**.
- Four console test runners: **PASS**.
- Direct solution invocation with the installed MSBuild: **BLOCKED by host internal error** (`BuildRequestConfiguration.GetCacheFile`, `MSB1025`), after solution validation succeeds. This is recorded as an environment/tooling blocker, not hidden as a successful solution build.

## Constraints

The warnings about missing .NET Framework v4.0 reference assemblies and MSIL/AMD64 mismatch are expected from the installed machine and must be removed by a proper SDK/targeting-pack build before portable target selection is frozen.
