# WsCalcuLine schema（L1 原始元数据 + L1处理代码 / L2 IL）

## 封装与证据

`1001:WsCalcuLine → 1000:Kind.ToString() → 1000:整串JSON`。JSON为默认 DataContractJsonSerializer、UTF8；没有250字符分片，超过16384字节仅提示。写入仍可能因CAD XData限制失败，不能把“会尝试保存”写成“永远成功保存”。

- ToJson 原06000650/B8558；FromJson 06000651/B8698；ToBuffer 06000652/B8748；FromBuffer 06000653/B87B0。
- SaveById 原06000655/B8B08；LoadEntity 06000656/B8D34；CreateLine 060006A4/B9C38。对应处理token通常减1，不能混写。
- 原始Unicode成员见原IL Property及CustomAttribute；下表以转义显示**真实JSON键**，不是`_008A_...`反编译别名。

## Line的10成员

| JSON键 | 便于阅读的名称/类型 | new实例默认 |
|---|---|---|
| `\u008a\u0090\u0098` | Kind / enum数值（恢复carrier为int） | 1 |
| `\u008a\u0090\u009d` | CenterX / double | 0 |
| `\u008a\u0091\u0087` | CenterY / double | 0 |
| `\u008a\u0091\u008a` | CenterZ / double | 0 |
| `\u008a\u0091\u008d` | Direction / double弧度 | 0 |
| `\u008a\u0091\u0090` | Length / double米 | 20000 |
| `\u008a\u0091\u0093` | Description / string | 空串 |
| `\u008a\u0091\u0096` | Parameters / nested contract | new参数对象 |
| `\u008a\u0091\u0099` | Created / DateTime | DateTime.Now |
| `\u008a\u0091\u009c` | Creator / string | 空串 |

Created使用DataContract JSON日期表示（`/Date(...)/`，序列化文本可含转义斜杠），不是ISO字符串。反序列化`{}`绕过构造器，缺项采用类型零/null/default(DateTime)，不能套用new默认。

CreateLine用实际端点覆盖CenterXYZ、3D Length、`atan2(endY−startY,endX−startX)`。所以保存Direction是**横向施工线的朝向**，不是工厂传入的航迹角；没有另一个显式Origin/DER坐标字段。起点需结合Distance与航迹另推，不能称为现成持久化对象。

## Parameters的28成员

未赋值double=0，Category默认为空串；其余按页赋值，默认序列化包含这些成员。

| JSON键 | 名称 | 类型/单位 |
|---|---|---|
| `\u008a\u0092\u0092` | IntermediateLength | double m |
| `\u008a\u0092\u0095` | FafAltitude | double m |
| `\u008a\u0092\u0098` | ThrElevation | double m |
| `\u008a\u0092\u009b` | FafGp | double deg |
| `\u008a\u0092\u009e` | Rdh | double m |
| `\u008a\u0093\u0088` | FafThrDistance | double m |
| `\u008a\u0093\u008b` | Tas | double km/h |
| `IAS` | IAS | double km/h（选择kt后已换算） |
| `WindSpeed` | WindSpeed | double km/h |
| `Altitude` | Altitude | double m |
| `Temperature` | Temperature | double 输入温度 |
| `\u008a\u0093\u0096` | SecondsNpa | double s |
| `\u008a\u0093\u0099` | NpaDistance | double m |
| `\u008a\u0093\u009c` | PaGp | double deg |
| `\u008a\u0094\u0086` | Xz | double m |
| `\u008a\u0094\u0089` | Dh | double m |
| `\u008a\u0094\u008c` | Elevation | double m |
| `\u008a\u0094\u008f` | Category | string |
| `\u008a\u0094\u0092` | Hlm | double m |
| `\u008a\u0094\u0095` | Hlr | double m |
| `\u008a\u0094\u0098` | HlCorrection | double m |
| `\u008a\u0094\u009b` | ThrSocDistance | double m，CAD传入有符号距离 |
| `\u008a\u0094\u009e` | StartAltitude | double m |
| `\u008a\u0095\u0088` | EndAltitude | double m |
| `\u008a\u0095\u008b` | Gradient | double 百分数（3.3而非.033） |
| `\u008a\u0095\u008e` | TpDistance | double m |
| `\u008a\u0095\u0091` | SecondsC | double s |
| `\u008a\u0095\u0094` | CDistance | double m |

## 六页共用同一个schema

| 页 / Kind | 显式写入Parameters | 工厂Line值（writer前） |
|---|---|---|
| FAF / 1 | IntermediateLength,FafAltitude,ThrElevation,FafGp,Rdh,FafThrDistance | 长20000；FAF-THR距离描述 |
| NPA / 3 | Tas,IAS,WindSpeed,Altitude,Temperature,SecondsNpa,NpaDistance | 长12000；NPA SOC |
| PA / 4 | Category,PaGp,Xz,Dh,Elevation,Hlm,Hlr,HlCorrection,ThrSocDistance | 长12000；CAT 类别 SOC |
| Missed / 5 | StartAltitude,EndAltitude,Gradient,TpDistance | 长20000；SOC-TP距离描述 |
| Departure / 6 | StartAltitude,EndAltitude,Gradient,TpDistance | 长20000；DER-TP距离描述 |
| C / 7 | SecondsC,CDistance（不额外写IAS/TAS等） | 工厂长10000，实际writer覆盖12000；计时描述 |

FAF事件额外生成Kind2 IF施工线，Parameters为默认。六工厂原0600069A/B9604至0600069F/B9970，源码75859–75994。创建时间/Creator属于元信息，未找到额外任意metadata字典。

## 读回与下游复用

FromBuffer读取第1项Kind、第2项JSON，header Kind覆盖JSON Kind；不新增app名称校验。LoadEntity使用GetXDataForApplication("WsCalcuLine")。已保存定向调用摘录 `evidence/WsCalcuLine-downstream.json`：现有静态call索引中Load只被包装方法处理060006AB调用；包装方法没有发现调用者。阅读副本中同样仅有声明与这一调用。

据现有直接调用/字符串证据，A7/A8/A10未显示自动语义复用；间接/反射/外部插件未因此被证明不存在。结论：**metadata exists, but no evidence of automatic downstream semantic reuse.** 不能从“有反序列化helper”推断后续窗口已经按类型自动识别FAF/TP/C。

验证：18项恢复序列化/工厂检查通过，原生条件代码兼容编译通过。均非原目标运行等价证据；原DWG写入时序仍需EXP-05。
