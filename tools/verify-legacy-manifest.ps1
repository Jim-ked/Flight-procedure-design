$expected = @{
  'recovered/GeometryPrimitives/WindSpiral.Recovered.cs' = '08669FD267200C9AECC63FF23FEA087FCBD037812AA7137D68946DCF6B296FB0'
  'recovered/GeometryPrimitives/TurnParameter.Recovered.cs' = '3154FB0B909CF87F2727DBD789D8DB680F4464C12177CFBF69E80C4B6C17B3EF'
  'recovered/GeometryPrimitives/Geometry.Recovered.cs' = 'DCF47E9B13C627BD8B42B42ACF40B28261FAFF0949F67AF11ADFB7CAAD1A6650'
  'recovered/ObstacleData/PriSec.Recovered.cs' = 'F326F6E7CB9876E95CD4CBD419E50900F5CE651E7F8B81C9EBE3918230AEA6D0'
  'recovered/B1-FlyBy/FlyBy.Boundaries.Recovered.cs' = '985CA1C6A29A29B5C5557A7066A2BF09CBC6E83C6CBEB7FA79D452D0709562BE'
  'recovered/B1-FlyBy/FlyBy.CadWriter.Recovered.cs' = 'C65D72ED05037469431E048CFFFB145A8EE4981C1623E22C6C3688335760B4B5'
  'recovered/B2-FlyOverDF/FlyOver.Boundaries.Recovered.cs' = 'FD6FD72DFC564BF47E1C668EB093660EE3C5D1B64C680A9E20E114EA7156A3AB'
  'recovered/B2-FlyOverDF/FlyOver.CadWriter.Recovered.cs' = 'B4A9F4B710E959EFB9EC3F237F150C5F2E6627F2227C51903C81079F979D2191'
}
$failed = $false
foreach ($path in $expected.Keys) {
  $actual = (Get-FileHash $path -Algorithm SHA256).Hash
  if ($actual -ne $expected[$path]) { Write-Error "$path hash mismatch"; $failed = $true }
}
if ($failed) { exit 1 }
Write-Output "RECOVERED_HASH_GATE_PASS ($($expected.Count) files)"
