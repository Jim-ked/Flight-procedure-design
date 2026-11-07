param(
    [string]$AutoCAD2026Dir,
    [ValidateSet('Debug','Release')][string]$Configuration = 'Debug',
    [string]$OutputDirectory
)
$ErrorActionPreference = 'Stop'
$taskRoot = $PSScriptRoot
if (-not $AutoCAD2026Dir) {
    $installed = Get-ItemProperty 'HKLM:\SOFTWARE\Autodesk\AutoCAD\R25.1\*' -ErrorAction SilentlyContinue |
        Where-Object { $_.AcadLocation -and (Test-Path -LiteralPath (Join-Path $_.AcadLocation 'AcMgd.dll')) } |
        Select-Object -First 1
    $AutoCAD2026Dir = $installed.AcadLocation
}
if (-not $AutoCAD2026Dir -or -not (Test-Path -LiteralPath (Join-Path $AutoCAD2026Dir 'AcMgd.dll'))) {
    throw 'AutoCAD 2026 API not found. Pass -AutoCAD2026Dir with the installed AutoCAD 2026 directory.'
}
# Keep disposable CLI state inside the ignored workspace cache for restricted environments.
$env:DOTNET_CLI_HOME = Join-Path $taskRoot 'tmp/dotnet-home'
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = '1'
$env:NUGET_PACKAGES = Join-Path $taskRoot 'tmp/nuget'
$taskConfig = Join-Path $taskRoot 'tmp/f0-nuget.config'
New-Item -ItemType Directory -Force (Split-Path $taskConfig) | Out-Null
# F0 has no external NuGet dependencies; use the installed .NET desktop reference packs.
Set-Content -LiteralPath $taskConfig -Encoding utf8 -Value '<configuration><packageSources><clear /></packageSources></configuration>'
Push-Location $taskRoot
try {
    $taskBuildOptions = @()
    if ($OutputDirectory) { $taskBuildOptions += "-p:OutputPath=$([IO.Path]::GetFullPath($OutputDirectory))" }
    & dotnet build src/Fpd.AutoCAD/Fpd.AutoCAD.csproj -c $Configuration "-p:AutoCAD2026Dir=$AutoCAD2026Dir" @taskBuildOptions --configfile $taskConfig -v:minimal
    if ($LASTEXITCODE -ne 0) { throw 'AutoCAD plugin build failed.' }
    & dotnet restore tests/Fpd.Core.Tests/Fpd.Core.Tests.csproj --configfile $taskConfig -v:minimal
    if ($LASTEXITCODE -ne 0) { throw 'Core test restore failed.' }
    & dotnet run --project tests/Fpd.Core.Tests/Fpd.Core.Tests.csproj -c $Configuration --no-restore
    if ($LASTEXITCODE -ne 0) { throw 'Core tests failed.' }
}
finally { Pop-Location }
