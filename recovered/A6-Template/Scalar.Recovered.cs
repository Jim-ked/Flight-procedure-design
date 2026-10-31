using System;
namespace Recovered.A6 {
// Original helper _008F_008A._008B_0088_0088; --/--.cs:83750.
// Decompilation evidence; repeated wrapping, preserving +PI and -PI endpoints.
public static class _008F_008A {
 // Original MethodDef: 0x060007D9; Original RVA: 0xC8184; Processed MethodDef: 0x060007D8; Evidence: --/--.cs:83750 + evidence/0x060007D8.il.txt.
 public static double _008B_0088_0088(double angle) {
  while(angle>Math.PI) angle-=2*Math.PI;
  while(angle<-Math.PI) angle+=2*Math.PI;
  return angle;
 }
}
}
