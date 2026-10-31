$ErrorActionPreference = 'Stop'
$workspace = Split-Path -Parent $PSScriptRoot
$sourceRoot = Join-Path $workspace 'WsTools-master'
$manifestDir = Join-Path $PSScriptRoot '00_manifest'
$originalDir = Join-Path $PSScriptRoot '01_original'
New-Item -ItemType Directory -Force -Path $manifestDir,$originalDir | Out-Null
$sourceFiles = @(Get-ChildItem -LiteralPath $sourceRoot -Recurse -File)
$sourceFiles += Get-Item -LiteralPath (Join-Path $workspace '航空器运行目视和仪表飞行程序设计规范.pdf')
$sourceFiles += Get-Item -LiteralPath 'C:\Users\ZJ\Downloads\CODEX_WsTools_ReverseEngineering_Task.md','C:\Users\ZJ\Downloads\WindSpiral2026_PreReverse_Findings.md'
$rows = foreach ($file in $sourceFiles) {
    $relative = if ($file.FullName.StartsWith($sourceRoot + '\')) { 'WsTools-master\' + $file.FullName.Substring($sourceRoot.Length + 1) } else { 'supplied\' + $file.Name }
    $dest = Join-Path $originalDir $relative
    New-Item -ItemType Directory -Force -Path (Split-Path -Parent $dest) | Out-Null
    $hash = (Get-FileHash -LiteralPath $file.FullName -Algorithm SHA256).Hash
    if (!(Test-Path -LiteralPath $dest)) { Copy-Item -LiteralPath $file.FullName -Destination $dest }
    $copyHash = (Get-FileHash -LiteralPath $dest -Algorithm SHA256).Hash
    if ($hash -ne $copyHash) { throw "Snapshot mismatch: $relative" }
    [PSCustomObject]@{OriginalPath=$file.FullName;RelativePath=$relative;Bytes=$file.Length;SHA256=$hash;SnapshotSHA256=$copyHash;SnapshotPath=$dest}
}
$rows | Export-Csv -LiteralPath (Join-Path $manifestDir 'hashes.csv') -NoTypeInformation -Encoding utf8
$lines = @('# 文件基线清单','','原件仅读取；副本逐一 SHA-256 校验。精确路径见 hashes.csv。','','| 相对路径 | 字节 | SHA-256 |','|---|---:|---|')
$lines += $rows | ForEach-Object { '| ' + $_.RelativePath + ' | ' + $_.Bytes + ' | ' + $_.SHA256 + ' |' }
$lines | Set-Content -LiteralPath (Join-Path $manifestDir 'file_inventory.md') -Encoding utf8
Write-Output "Verified snapshot files: $($rows.Count)"
Write-Output "Total bytes: $(($rows | Measure-Object Bytes -Sum).Sum)"
