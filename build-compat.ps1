$ErrorActionPreference = 'Stop'
$msbuild = 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe'
$projects = @(
  'src\Fpd.Domain\Fpd.Domain.csproj',
  'src\Fpd.Engine\Fpd.Engine.csproj',
  'src\Fpd.Legacy.WindSpiral\Fpd.Legacy.WindSpiral.csproj',
  'src\Fpd.Application\Fpd.Application.csproj',
  'src\Fpd.Infrastructure\Fpd.Infrastructure.csproj',
  'tests\Fpd.Legacy.BehaviorTests\Fpd.Legacy.BehaviorTests.csproj',
  'tests\Fpd.RuleConformance.Tests\Fpd.RuleConformance.Tests.csproj',
  'tests\Fpd.Engine.Tests\Fpd.Engine.Tests.csproj',
  'tests\Fpd.Application.Tests\Fpd.Application.Tests.csproj'
)
foreach ($project in $projects) {
  & $msbuild $project /t:Build /p:Configuration=Debug /p:Platform=AnyCPU /m:1 /nr:false /v:minimal
  if ($LASTEXITCODE -ne 0) { throw "Build failed: $project" }
}
& 'tests\Fpd.Legacy.BehaviorTests\bin\Debug\Fpd.Legacy.BehaviorTests.exe'
& 'tests\Fpd.RuleConformance.Tests\bin\Debug\Fpd.RuleConformance.Tests.exe'
& 'tests\Fpd.Engine.Tests\bin\Debug\Fpd.Engine.Tests.exe'
& 'tests\Fpd.Application.Tests\bin\Debug\Fpd.Application.Tests.exe'
