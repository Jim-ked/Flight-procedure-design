# AutoCAD 2026 块表实际审计

原库SHA256：`AB3141FF3C9D173670C57600ECFA77B28E5625FC0EB1C8C06E37F08F4D8FF5F1`；INSUNITS：Meters。共188个块记录（含布局/匿名/动态块）。本表由真实AutoCAD API读取，二进制字符串不作为块名证据。完整实体、范围、属性默认值见block-table.json；可视对照见symbol-atlas.dwg。

| 实际块名 | 匿名/动态 | 基点 | 单位 | 几何类型 | 属性Tag | 层/颜色 | 含文字/默认值 |
|---|---|---|---|---|---|---|---|
| *Model_Space | False/False | [0, 0, 0] | Undefined | AlignedDimension,Arc,BlockReference,Circle,DBPoint,DBText,Hatch,Line,MLeader,MText,Ole2Frame,Polyline,Polyline3d,RotatedDimension,Solid |  | 0:1,0:110,0:121,0:18,0:251,0:252,0:256,0:33,0:4,0:5,0:7,1:256 | IF点为NDB台时的保护区; IF点为VOR台时的保护区; 常规NDB保护区 半宽1.25nm; 常规VOR保护区 半宽1nm; 假想的真北线; 通过units命令来改变; RNP APCH进近保护区; 传统扇区划分; 传统中间进近航段; PBN扇区划分; 46km_55km; 25nm_30nm; 精密进近基本ILS面; RNP1; 30NM; IF; F |
| *Paper_Space | False/False | [0, 0, 0] | Undefined | Viewport |  | 0:256 |  |
| VOR_1.0nm | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| Conv_MSA | False/True | [0, 0, 0] | Meters | Arc,Circle,Line |  | 0:256 |  |
| NDB_1.25nm | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| NDB_2.5nm | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| *U4 | True/False | [0, 0, 0] | Undefined | Arc,Circle,Line |  | 0:256 |  |
| RNP_APCH | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| *D6 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;4630m |
| *D7 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;3704m |
| *D8 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2315m |
| *D9 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;1852m |
| *D10 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;4630 |
| *D11 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2686m |
| *D12 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;1760m |
| *D13 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;3704m |
| VOR_2.0nm | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| *U15 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U16 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U17 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| Conv_InterSegment | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| *D19 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;9260 |
| PBN_MSA | False/True | [0, 0, 0] | Meters | Arc,Circle,Line |  | 0:256 |  |
| *U21 | True/False | [0, 0, 0] | Undefined | Arc,Circle,Line |  | 0:256 |  |
| *U22 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| Basic_ILS | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| *U24 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| WsGis | False/False | [0, 0, 0] | Meters | Arc,AttributeDefinition,Circle,DBText,Line | EPSG,MagVar | 0:256,0:5 | WindSpiralGis; 地理参考   请勿删除; Gis Reference, DO NOT DELETE; 磁差; EPSG; 0000; 0 |
| Flyby | False/False | [0, 0, 0] | Meters | AttributeDefinition,Circle,Line | ROLE,ALTITUDE,NAME | 0:256 |  |
| Flyover | False/False | [0, 0, 0] | Meters | AttributeDefinition,Circle,Hatch | NAME,ALTITUDE,ROLE | 0:256 |  |
| NDB | False/False | [0, 0, 0] | Meters | Circle,Hatch |  | 0:18 |  |
| ObstWithLight | False/False | [0, 0, 0] | Meters | AttributeDefinition,Circle,Polyline | ALTITUDE | 0:256 |  |
| Obst | False/False | [0, 0, 0] | Meters | AttributeDefinition,Circle,Polyline | Altitude | 0:256 |  |
| VOR | False/False | [0, 0, 0] | Meters | Hatch |  | 0:18 |  |
| Fix | False/False | [0, 0, 0] | Meters | AttributeDefinition,Polyline | ALTITUDE,DME,ROLE,RADIAL | 0:256 | IAF; R090° |
| *U33 | True/False | [0, 0, 0] | Undefined | Polyline |  | 0:256 |  |
| *U34 | True/False | [0, 0, 0] | Undefined | BlockReference |  | 1:0 |  |
| *U35 | True/False | [0, 0, 0] | Undefined | Polyline |  | 0:256 |  |
| *U36 | True/False | [0, 0, 0] | Undefined | BlockReference |  | 1:0 |  |
| TOOL001 | False/False | [0, 0, 0] | Undefined | Circle,DBPoint,Line,Polyline,Solid |  | 0:256 |  |
| TOOL010 | False/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| 强制报告点 | False/False | [0, 0, 0] | Millimeters | Line,Solid |  | 0:256 |  |
| TOOL005 | False/False | [0, 0, 0] | Undefined | Arc,Line |  | 0:0,0:256 |  |
| Tool004 | False/False | [0, 0, 0] | Undefined | Circle |  | 0:256 |  |
| *X42 | True/False | [0, 0, 0] | Undefined | Line |  | 0:0 |  |
| TOOL006 | False/False | [0, 0, 0] | Undefined | Arc,BlockReference |  | 0:256 |  |
| DME | False/False | [0, 0, 0] | Undefined | DBPoint,Polyline |  | 0:256 |  |
| 箭头 | False/False | [0, 0, 0] | Undefined | Hatch,Line |  | 0:256 |  |
| *X46 | True/False | [0, 0, 0] | Undefined | Line |  | 0:0 |  |
| TOOL008 | False/False | [0, 0, 0] | Undefined | BlockReference |  | 0:256 |  |
| 羽毛 | False/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| _ClosedBlank | False/False | [0, 0, 0] | Undefined | Line |  | 0:0 |  |
| TOOL020 | False/False | [0, 0, 0] | Undefined | Polyline,Solid |  | 0:7 |  |
| BOX3 | False/False | [0, 0, 0] | Undefined | Hatch,Line,Polyline |  | 0:7 |  |
| ROW5 | False/False | [0, 0, 0] | Undefined | Hatch,Polyline |  | 0:7 |  |
| NROSE6 | False/False | [0, 0, 0] | Undefined | Circle,Hatch,Line,Polyline |  | 0:256 |  |
| NDB1 | False/False | [0, 0, 0] | Millimeters | Circle |  | 0:256 |  |
| NLOC2 | False/False | [0, 0, 0] | Undefined | Circle,Hatch,Polyline |  | 0:256 |  |
| BOX1 | False/False | [0, 0, 0] | Undefined | DBPoint,Hatch,Line,Polyline |  | 0:7 |  |
| NVORDM | False/False | [0, 0, 0] | Undefined | Circle,Hatch,Polyline |  | 0:7 |  |
| BOX2 | False/False | [0, 0, 0] | Undefined | Hatch,Line,Polyline |  | 0:7 |  |
| NDME | False/False | [0, 0, 0] | Undefined | Circle,Hatch,Polyline |  | 0:7 |  |
| FVOR | False/False | [0, 0, 0] | Undefined | Polyline |  | 0:7 |  |
| ROW31 | False/False | [0, 0, 0] | Undefined | Hatch,Polyline |  | 0:7 |  |
| BOXLIS | False/False | [0, 0, 0] | Undefined | Ellipse,Hatch,Line,Polyline |  | 0:256 |  |
| FLOM1 | False/False | [0, 0, 0] | Undefined | Hatch,Line,Polyline |  | 0:7 |  |
| FGP | False/False | [0, 0, 0] | Undefined | Line |  | 0:7 |  |
| B12 | False/False | [0, 0, 0] | Undefined | Hatch,Polyline |  | 0:256 |  |
| ZHE | False/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| NDME1 | False/False | [0, 0, 0] | Undefined | Polyline |  | 0:7 |  |
| SANQUL | False/True | [0, 0, 0] | Undefined | Hatch,Line,Polyline |  | 0:256,0:7 |  |
| NLOC | False/False | [0, 0, 0] | Undefined | Circle,Hatch |  | 0:256 |  |
| NLOC1 | False/False | [0, 0, 0] | Undefined | Circle,Hatch |  | 0:7 |  |
| BL | False/False | [0, 0, 0] | Undefined | DBText,Line |  | 0:256 | 5; 0; 5; 10; 15km |
| ZAWNUM | False/False | [0, 0, 0] | Undefined | Circle,DBText |  | 0:256 | 1 |
| RouteA | False/True | [0, 0, 0] | Meters | BlockReference,Line |  | 0:256,0:7 |  |
| Conv_ARR | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| PBN_ARR_30nm_R1R2 | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| PBN_Miss_30nm_R1R2 | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| PBN_Miss_15nm_R1R2 | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| PBN_ARR_30nm_P1 | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| PBN_Miss_30nm_P1 | False/True | [0, 0, 0] | Meters | Line |  | 0:256 |  |
| *U80 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U81 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U82 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U83 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U84 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U85 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *D86 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;18520m |
| *D87 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;9260m |
| *D88 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;3704m |
| *D89 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;9260m |
| *D90 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;4630m |
| *D91 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;4630m |
| *D92 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;3704m |
| *D93 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;1760m |
| *D94 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;4630m |
| *D95 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;4630m |
| *D96 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;6482m |
| *D97 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;9260m |
| RouteB | False/True | [0, 0, 0] | Meters | BlockReference,Line |  | 0:256,0:7 |  |
| ROWMAPNew | False/False | [0, 0, 0] | Meters |  |  |  |  |
| ROWn | False/False | [0, 0, 0] | Meters | Ellipse,Hatch,Line,Polyline |  | 0:256,程序:256 |  |
| PBNsw3.5nm | False/True | [0, 0, 0] | Meters | Line |  | 1:256 |  |
| *U102 | True/False | [0, 0, 0] | Undefined | Line |  | 1:256 |  |
| PBNsw2.5nm | False/True | [0, 0, 0] | Meters | Line |  | 1:256 |  |
| PBNsw2.0nm | False/True | [0, 0, 0] | Meters | Line |  | 1:256 |  |
| PBNsw5.0nm | False/True | [0, 0, 0] | Meters | Line |  | 1:256 |  |
| *U106 | True/False | [0, 0, 0] | Undefined | Line |  | 1:256 |  |
| *U107 | True/False | [0, 0, 0] | Undefined | Line |  | 1:256 |  |
| Arrow | False/True | [0, 0, 0] | Meters | Hatch,Line |  | 0:256 |  |
| *U109 | True/False | [0, 0, 0] | Undefined | BlockReference,Line |  | 0:256,0:7 |  |
| *U110 | True/False | [0, 0, 0] | Undefined | BlockReference,Line |  | 0:256,0:7 |  |
| H | False/False | [0, 0, 0] | Meters | Hatch |  | 0:0 |  |
| I | False/False | [0, 0, 0] | Meters | Hatch |  | 0:0 |  |
| J | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| K | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| L | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| M | False/False | [0, 0, 0] | Meters | Solid |  | 0:0 |  |
| N | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| A | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| B | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| C | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| D | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| E | False/False | [0, 0, 0] | Meters | Hatch |  | 0:0 |  |
| F | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| G | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| O | False/False | [0, 0, 0] | Meters | Solid |  | 0:0 |  |
| P | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| Q | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| R | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| S | False/False | [0, 0, 0] | Meters | Hatch |  | 0:0 |  |
| T | False/False | [0, 0, 0] | Meters | Solid |  | 0:0 |  |
| U | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| V | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| W | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| X | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| Y | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| Z | False/False | [0, 0, 0] | Meters | Hatch,Solid |  | 0:0 |  |
| NOSCALE | False/False | [0, 0, 0] | Meters | DBText,Ellipse,Hatch,Line,MText,Polyline |  | 0:7 | N; {\fSTXihei/b0/i0/c134/p2;不按比例} |
| NomiTrack | False/True | [0, 0, 0] | Meters | BlockReference,ImpEntity |  | 0:7,1:256 |  |
| *U139 | True/False | [0, 0, 0] | Undefined | BlockReference,ImpEntity |  | 0:7,1:256 |  |
| *U140 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U141 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U142 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U143 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U144 | True/False | [0, 0, 0] | Undefined | Hatch,Line,Polyline |  | 0:256,0:7 |  |
| LocCoverage | False/True | [0, 0, 0] | Meters | Arc,Line |  | 0.8 14进近点:5,0.8 14进近点:6 |  |
| *U146 | True/False | [0, 0, 0] | Undefined | Arc,Line |  | 0.8 14进近点:5,0.8 14进近点:6 |  |
| A$Ce44d82be | False/False | [0, 0, 0] | Meters | AttributeDefinition | NAME | 0:256 | APP |
| FreqP | False/False | [0, 0, 0] | Meters | AttributeDefinition | PFREQ,NAME | 0:256 | 130.0; APP |
| FreqPS | False/False | [0, 0, 0] | Meters | AttributeDefinition | SFREQ,PFREQ,NAME | 0:256 | (130.0); 130.0; APP |
| FreqPSH | False/False | [0, 0, 0] | Meters | AttributeDefinition | NAME,PFREQ,SFREQ | 0:256 | APP; 130.0; (130.0) |
| MSAS | False/False | [0, 0, 0] | Meters | AttributeDefinition,Circle | FEET1,METER1,NAME,MSAR | 0:256 | 3000'; 900; VOR; MSA 25NM |
| MFBLK | False/False | [0, 0, 0] | Meters | AttributeDefinition | METER,FEET | 0:256 | 160(155); 530'(510') |
| FreqPSV | False/False | [0, 0, 0] | Meters | AttributeDefinition | SFREQ,PFREQ,NAME | 0:256 | (130.0); 130.0; APP |
| FAFBLK | False/False | [0, 0, 0] | Meters | AttributeDefinition | FEET,METER,DME,NAME | 0:256 | 530'(510'); 160(155); D6.1 ISZ; FAF |
| FreqLOC | False/False | [0, 0, 0] | Meters | AttributeDefinition | ID,NAME,PFREQ | 0:256 | IXX; LOC; 130.0 |
| *D156 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;6482m |
| *D157 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;1760m |
| RABLK | False/False | [0, 0, 0] | Meters | AttributeDefinition | NAME,METER,FEET | 0:256 | FAF; 160(155); 530'(510') |
| MSAD | False/True | [0, 0, 0] | Meters | AttributeDefinition,Circle,Hatch,Line | NAME,ANG1,FEET1,MSAR,METER1,METER2,FEET2,ANG2 | 0:256,0:7 | VOR; 090°; 3000'; MSA 25NM; 900; 900; 3000'; 270° |
| MSAT | False/True | [0, 0, 0] | Meters | AttributeDefinition,Circle,Hatch,Line | METER3,FEET3,ANG2,ANG3,FEET2,METER2,METER1,MSAR,FEET1,ANG1,NAME | 0:256,0:7 | 900; 3000'; 180°; 270°; 3000'; 900; 900; MSA 25NM; 3000'; 090°; VOR |
| *U161 | True/False | [0, 0, 0] | Undefined | AttributeDefinition,Circle,Hatch,Line | NAME,ANG1,FEET1,MSAR,METER1,METER2,FEET2,ANG2 | 0:256,0:7 | VOR; 090°; 3000'; MSA 25NM; 900; 900; 3000'; 270° |
| *U162 | True/False | [0, 0, 0] | Undefined | AttributeDefinition,Circle,Hatch,Line | METER3,FEET3,ANG2,ANG3,FEET2,METER2,METER1,MSAR,FEET1,ANG1,NAME | 0:256,0:7 | 900; 3000'; 180°; 270°; 3000'; 900; 900; MSA 25NM; 3000'; 090°; VOR |
| *D163 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;3.5nm |
| *D164 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;0.95nm |
| *D165 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;5.0nm |
| *D166 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.0nm |
| *D167 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;5.0nm |
| *D168 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.5nm |
| *D169 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.5nm |
| *D170 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.0nm |
| *D171 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;0.95nm |
| *D172 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.5nm |
| *D173 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.5nm |
| *D174 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;3.5nm |
| *U175 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *D176 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.0nm |
| *D177 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.5nm |
| *U178 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *U179 | True/False | [0, 0, 0] | Undefined | Line |  | 0:256 |  |
| *D180 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.0nm |
| *D181 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;5.0nm |
| *D182 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;2.5nm |
| *D183 | True/False | [0, 0, 0] | Undefined | DBPoint,Line,MText,Solid |  | 0:0,Defpoints:0 | \A1;3.5nm |
| PbnDeparture | False/True | [0, 0, 0] | Meters | Line,Polyline3d |  | 0:256 |  |
| *U185 | True/False | [0, 0, 0] | Undefined | Line,Polyline3d |  | 0:256 |  |
