# UI → 事件 → 方法

全部为FormCalcu `_0088_009C._0088_009B`。以下token为处理后版本；原token/RVA见 evidence.md，完整控件/绑定见 evidence/controls.csv、events.csv。

| 页 | CAD按钮/Click | 计算方法 | 更新触发 |
|---|---|---|---|
| FAF | buttonFAF → `_0097_0099` / 0x0600022D | `_0097_009B` / 22F | `_0097_009A` / 22E（Validated） |
| 非精密SOC | buttonNpaSOC → `_0097_009E` / 232 | `_0098_0086` / 233 | `_0098_0087` / 234（时间Validated） |
| 精密SOC | buttonPaSOC → `_0098_0088` / 235 | `_0098_008A` / 237 | `_0098_0089` / 236；comboCat→238→239和237 |
| 复飞TP | buttonMissTP → `_0098_008D` / 23A | `_0098_008E` / 23B | `_0098_008F` / 23C |
| 离场TP | buttonDepTP → `_0098_0090` / 23D | `_0098_0091` / 23E | `_0098_0092` / 23F |
| C | buttonC → `_0098_0093` / 240 | `_0098_0094` / 241 | `_0098_0095` / 242 |

另有值得保留的异常绑定：comboXz.TabIndexChanged也绑定精密SOC CAD方法235，不应擅自改成纯重算；其SelectedIndexChanged/Validated绑定236。该绑定来自源9529–9536，不声称运行时一定触发拾取。

Load 22B：先设非精密IAS=345、bank=15、wind=19；C的bank=15、wind=56；禁用/隐藏相关bank控件后读config.xml/FormCalcu。因此默认风不是不可变常量，配置可能覆盖。时间默认18与6分别见源10915/11666。
