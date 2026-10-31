# NDB参数与完整构造链

P2F8将W1.Text=“1.25 nm”、W2.Text=“2.5 nm”、ExpAng.Text=“10.3”。小半宽2315m、大半宽4630m；默认设计器不选NDB，用户切至NDB后保留W1/W2档位，仅更换标签及角度。

P2F9与VOR完全同一个几何方法：W=w+L·tan(alpha)，内线为半值；按同样左右/中心/15°分支写CAD。没有独立NDB几何类/重载，没有6.5°或6.9°计算；这两个值不能从Base Turn或定位容差借入A4。NDB/DME也没有独立UI或DME距离误差消费者。

参数无上下限检查；文本parse失败P7D4提示后返回0，P2FA外层catch仅在下层异常逃逸时另提示并0替代，正常非法文本不会触发第二条alert。度数未强制10.3；但普通用户无法在被禁用文本框里直接输入。无负宽度/负角/大角纠正，测试注入仅揭示reader和算术边界。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F8|0x060002F9 / 0x3DF28|0x3356C|22693|[证据](evidence/processed/0x060002F8.il.txt)|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
|P2FA|0x060002FB / 0x3E938|0x33E7C|23078|[证据](evidence/processed/0x060002FA.il.txt)|
|P7D4|0x060007D5 / 0xC7DB8|0x91CF8|83668|[证据](evidence/processed/0x060007D4.il.txt)|
