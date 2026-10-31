# VOR参数与完整构造链

P2F7每次执行都将W1.Text=“1.0 nm”、W2.Text=“2.0 nm”、ExpAng.Text=“7.8”。默认设计器选VOR与W1，所以默认外半宽1852m；大档3704m。它不更改当前宽度档Checked，也不按距离自动换档。

P2F9不再读设施radio；读当前半宽标签→乘1852，读当前ExpAng.Text→乘π/180。距离L来自两拾点XY，远端外半宽W=w+L·tan(7.8°)，内线用起始w/2、远端W/2。中心线可选，左右各2条，15°时各3条；统一二维writer。

7.8为设施handler/初值赋予的默认文本，不是Draw里强制常数。无5.2°的VOR边界算法分支；5.2是A3/A6不同消费者的参数。15°则是P2F9实用硬编码连接角，独立于ExpAng。没有DME/KK/顶空锥逻辑。

UI没有自定义宽度输入框，角度文本框Enabled=false；修改恢复适配器标签/文本的fixture只验证实际reader优先级，不证明正常UI可自由编辑。config可以改角度Text，设施Changed又会覆盖；radio仅保存Checked，config不把宽度标签变成自由输入。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F7|0x060002F8 / 0x3DE68|0x33514|22682|[证据](evidence/processed/0x060002F7.il.txt)|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
|P2FA|0x060002FB / 0x3E938|0x33E7C|23078|[证据](evidence/processed/0x060002FA.il.txt)|
