# 共享几何与转弯原语索引

来自既有处理IL static-sites，只有 call/callvirt/newobj 计为边；字段访问不计调用。原始token/RVA只标身份，保护桩本身不证明计算。P为处理token。直接caller只列指定窗口/模型类，不冒充运行轨迹。点在多边形方法为 P7DB / 原060007DC / RVA C8174，当前只建立索引，未把其行为误用于 A7/A8/A10。

| 方法 | 原 token / RVA / P | A1直接 | A7直接 | A8直接 | A10直接 | B1直接 | B2直接 | 行为/恢复范围 |
|---|---|---|---|---|---|---|---|---|
| Turn parameter constructor | 0x06000794 / 0xC3820 (P 0x06000793) | — | 0x06000282@IL_0135, 0x06000283@IL_0129, 0x06000284@IL_00AA, 0x0600028C@IL_0179, 0x0600028D@IL_0180 | — | — | — | — | Round1 TAS/rate/radius/wind-radius |
| Turn input reader | 0x06000855 / 0xCA6B8 (P 0x06000854) | 0x06000386@IL_0015, 0x06000387@IL_01BC, 0x06000388@IL_0015, 0x0600038C@IL_0574, 0x06000391@IL_000F, 0x06000395@IL_002E | — | — | — | 0x060004BF@IL_0022, 0x060004C2@IL_0016 | 0x060004DE@IL_0016, 0x060004DF@IL_0016 | Round1 Read; units and exception path |
| Spiral constructor | 0x060007A2 / 0xC4620 (P 0x060007A1) | 0x06000386@IL_016D, 0x06000386@IL_01C1, 0x06000386@IL_0215, 0x06000387@IL_06A8, 0x06000387@IL_06FD, 0x06000388@IL_01CD | — | — | — | — | — | spiral model; not reached by A7 |
| Spiral angle normalize | 0x060007A3 / 0xC47B0 (P 0x060007A2) | 0x06000386@IL_0270 | — | — | — | — | — | loop normalization, unlike A10 once |
| Spiral samples | 0x060007A4 / 0xC489C (P 0x060007A3) | 0x06000386@IL_055D, 0x06000386@IL_0583, 0x06000386@IL_05B9, 0x06000387@IL_0081, 0x06000387@IL_00A8, 0x06000387@IL_048B, 0x06000388@IL_0281 | — | — | — | — | — | r=angle*windRadius+radius+offset, terminal point appended |
| Spiral point | 0x060007A6 / 0xC4C9C (P 0x060007A5) | 0x06000386@IL_02ED, 0x06000386@IL_0333, 0x06000386@IL_037B, 0x06000386@IL_0403, 0x06000386@IL_0445, 0x06000386@IL_0489, 0x06000387@IL_0574, 0x06000387@IL_0723, 0x06000387@IL_0788, 0x06000387@IL_07D8, 0x06000387@IL_081D, 0x06000388@IL_034D, 0x06000388@IL_03BA | — | — | — | — | — | spiral class; not ported this round |
| Spiral tangent iteration | 0x060007AE / 0xC5650 (P 0x060007AD) | 0x06000387@IL_0422, 0x06000387@IL_0448, 0x06000388@IL_025B | — | — | — | — | — | shared call index only; not newly recovered |
| Line X(y) | 0x060007E6 / 0xC8654 (P 0x060007E5) | — | — | — | — | — | — | original sentinel divide |
| Line Y(x) | 0x060007E7 / 0xC867C (P 0x060007E6) | — | 0x060001FC@IL_0135, 0x060001FC@IL_0206, 0x06000203@IL_0078, 0x06000420@IL_03F1, 0x06000421@IL_0390, 0x06000421@IL_042F, 0x06000421@IL_0478 | — | — | — | — | original sentinel divide |
| Line through two points | 0x060007E8 / 0xC86A4 (P 0x060007E7) | — | 0x060001FB@IL_0308, 0x06000202@IL_033F, 0x06000420@IL_002E, 0x06000420@IL_0080, 0x06000420@IL_03A0 | — | — | — | — | line coefficients |
| Line through point/angle | 0x060007E9 / 0xC87B0 (P 0x060007E8) | — | 0x060001FB@IL_0337, 0x060001FC@IL_02BF, 0x06000420@IL_03CF, 0x06000421@IL_0CB8, 0x06000421@IL_0DD1 | — | — | — | — | slope/coefficient construction |
| Divide | 0x060007EB / 0xC8818 (P 0x060007EA) | — | — | — | — | — | — | denominator zero -> +1000000 if numerator>0 else -1000000 |
| Point-line distance | 0x060007ED / 0xC88AC (P 0x060007EC) | — | 0x060001FC@IL_0278, 0x06000421@IL_00E1, 0x06000421@IL_0A08, 0x06000421@IL_0A2A | — | — | — | — | infinite-line perpendicular distance |
| Line intersection | 0x060007EE / 0xC8908 (P 0x060007ED) | — | 0x060001FC@IL_02CA, 0x06000421@IL_0CC3, 0x06000421@IL_0DDC | — | — | — | — | line coefficient solution |
| Line angle | 0x060007EF / 0xC89A8 (P 0x060007EE) | — | 0x060001FB@IL_0328, 0x060001FC@IL_02BA, 0x06000420@IL_03C0, 0x06000421@IL_0CA9, 0x06000421@IL_0DC2 | — | — | — | — | old angle branch |
| XY point distance | 0x06000808 / 0xC8FA4 (P 0x06000807) | 0x0600038C@IL_00AB | 0x06000421@IL_052E, 0x06000421@IL_05DC, 0x06000421@IL_06DA, 0x06000421@IL_07ED, 0x06000421@IL_0817 | — | 0x060002DB@IL_1D7A, 0x060002DE@IL_03B2 | — | — | ignores Z |
| Bearing | 0x06000809 / 0xC8FF4 (P 0x06000808) | — | — | — | — | — | — | XY atan2 |
| Polar point | 0x0600080A / 0xC901C (P 0x06000809) | 0x0600038C@IL_00EB, 0x0600038C@IL_0300, 0x0600038C@IL_03E2, 0x0600038C@IL_0441 | — | — | — | — | — | distance/angle to point |
| Point addition | 0x0600080B / 0xC903C (P 0x0600080A) | — | — | — | — | — | — | includes Z |
| Mirror Y | 0x0600080E / 0xC91A0 (P 0x0600080D) | — | — | — | — | — | — | (X,-Y,Z) |
| Zero Z | 0x0600080F / 0xC91C4 (P 0x0600080E) | — | — | — | — | — | — | (X,Y,0) |
| Point rotation | 0x06000810 / 0xC91E8 (P 0x0600080F) | — | 0x06000290@IL_016C | — | — | — | — | origin+polar(distance,bearing+angle,p.Z); Z sums |
| Point translation | 0x06000811 / 0xC923C (P 0x06000810) | — | 0x06000290@IL_0198 | — | — | — | — | XY translation |
| Symmetric boundary | 0x06000820 / 0xC97D0 (P 0x0600081F) | — | 0x060001FD@IL_0019, 0x060001FD@IL_0045, 0x060001FD@IL_0079, 0x06000204@IL_0012, 0x06000204@IL_003D, 0x06000204@IL_005E, 0x06000204@IL_007C, 0x06000422@IL_0012, 0x06000422@IL_003B, 0x06000422@IL_0078 | — | — | — | — | five points with repeated start |
| Rotate nested paths | 0x06000822 / 0xC9868 (P 0x06000821) | — | 0x06000283@IL_0177, 0x0600028C@IL_01BD, 0x06000290@IL_00CA | — | — | — | — | point primitive |
| Rotate path | 0x06000823 / 0xC98E8 (P 0x06000822) | — | — | — | — | — | — | point primitive |
| Translate nested paths | 0x06000824 / 0xC9968 (P 0x06000823) | — | 0x06000283@IL_019F, 0x0600028C@IL_01E5, 0x06000290@IL_00F2 | — | — | — | — | point primitive |
| Translate path | 0x06000825 / 0xC99E8 (P 0x06000824) | — | — | — | — | — | — | point primitive |
| Clear path Z | 0x06000827 / 0xC9AE8 (P 0x06000826) | — | 0x060001FD@IL_002F, 0x060001FD@IL_0052, 0x060001FD@IL_0086, 0x06000422@IL_001F, 0x06000422@IL_0048, 0x06000422@IL_0085 | — | — | — | — | point primitive |
| Clear nested paths Z | 0x06000828 / 0xC9B68 (P 0x06000827) | — | 0x06000283@IL_017E, 0x0600028C@IL_01C4, 0x06000290@IL_00D3 | — | — | — | — | point primitive |
