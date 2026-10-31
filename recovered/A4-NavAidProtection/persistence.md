# config、禁用角度与无参数文件协议

P2FB Load→**P0F6 _008A_0093**读取程序集目录config.xml的`/Document/NavAids`；P2FC Closed→**P0F4 _008A_0091**保存。记录以groupBox层级和控件Name拼dotted key，P0F5递归收集、P0F7按路径查控件。

TextBox handler取/设Text，不检查Enabled；radio/checkbox仅保存Checked为True/False，不保存Text标签。A4的文本框虽Enabled=false，config仍可能回填非默认角度；设施radio状态变化可触发P2F7/P2F8再覆盖角度/宽度标签。最终依config条目顺序与真实WinForms事件顺序，不能仅看默认值断定运行值。

原`WsTools-master/WindSpiral2026/config.xml`中**无NavAids节点**，已按hash保存该事实，不能伪造其持久化值。其已有其他窗体状态保持冻结。恢复适配器不写原config，不完整模拟通用config/WinForms生命周期；serialization层为静态路径和handler检查，非假造TXT往返。

没有独立A4保存/读取TXT/JSON的UI、格式、XData Form state。宽度只有单选预设，config保存宽度档位，不提供自定义宽度；测试注入“3.75 nm”验证标签reader，必须标注非普通用户功能。

[config证据/hash](evidence/config-evidence.json)、[注册器与handler源摘录](evidence/config-handlers.source.txt)。角度数值不限制最小/最大；P7D4 Convert.ToDouble异常→提示+0，P2FA外层catch也会0替代下层逃逸异常；不把0自动恢复为设施默认。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2FB|0x060002FC / 0x3E9A4|0x42D6|23091|[证据](evidence/processed/0x060002FB.il.txt)|
|P2FC|0x060002FD / 0x3E9C8|0x42F2|23096|[证据](evidence/processed/0x060002FC.il.txt)|
|P0F4|0x060000F5 / 0xA644|0xBC18|4166|[证据](evidence/processed/0x060000F4.il.txt)|
|P0F5|0x060000F6 / 0xA8D8|0xBD98|4229|[证据](evidence/processed/0x060000F5.il.txt)|
|P0F6|0x060000F7 / 0xAB28|0xBF28|4269|[证据](evidence/processed/0x060000F6.il.txt)|
|P0F7|0x060000F8 / 0xAD9C|0xC04C|4338|[证据](evidence/processed/0x060000F7.il.txt)|
|P2FA|0x060002FB / 0x3E938|0x33E7C|23078|[证据](evidence/processed/0x060002FA.il.txt)|
|P7D4|0x060007D5 / 0xC7DB8|0x91CF8|83668|[证据](evidence/processed/0x060007D4.il.txt)|
