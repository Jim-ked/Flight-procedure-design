# A4 导航设备保护区 — 静态恢复

**Round 9: ACCEPTED (static recovery)**，2026-10-28。仅表示本轮约定的静态恢复门槛满足，不代表规范全面合规、原程序运行等价或生产可用。

A4是VOR/NDB导航设施保护边界构造工具，不是障碍物评价器。设施选择先改写两档半宽标签和角度，Draw再从标签/文本读取参数。**不是两个独立几何引擎**，也不是A3定位容差或A6 Base Turn算法的别名。

|已闭合事项|真实行为|
|---|---|
|设施|仅VOR/NDB；小/大半宽分别1/2 NM、1.25/2.5 NM；角度7.8/10.3°|
|默认与可编辑性|默认VOR小半宽、双侧、中心线；15°关闭；角度TextBox设计器Enabled=false，宽度为RadioButton，不是自由输入框|
|几何|两拾点决定位置、方向及长度；每侧外边折线+半宽线；同一公式左右符号镜像|
|15°|从第二点作斜线与内外边界求交，替换终点并加斜边，非仅显示附加线|
|主副区|代码确有外边与0.5半宽线；可映射主区50%/两侧各25%的边界几何；没有独立面对象或MOC计算|
|CAD|2D Polyline，全体一个Group；无独立Line/Text；metadata参数空，故不写WsObject/XData|
|持久化|Load→P0F6、Closed→P0F4，config.xml/NavAids；原config无此节点，无便携TXT协议|
|跨模块|公共拾点、CAD、点线primitive真正同MethodDef；无A3/A6/A9业务调用|

## 导航

- [事件图](event-map.md)、[设施矩阵](facility-matrix.csv)、[输入及人工交互](input-frame.md)
- [VOR](vor.md)、[NDB](ndb.md)、[完整边界](boundary-geometry.md)、[15°线](15-degree-line.md)
- [主副区](primary-secondary.md)、[评价检查](obstacle-evaluation.md)、[CAD](cad-output-map.md)
- [XData](xdata-schema.md)、[config](persistence.md)、[规范映射](standard-mapping.md)
- [验证分层](verification.md)、[未验证项](unrecovered.md)、[20问收口](../round9/closure.md)

源码：NavAidProtectionForm.Recovered.cs机械保留P2F7–P2FA逻辑，外部输入/写CAD以独立适配器隔离；NavAidProtectionGeometry.Recovered.cs为同一几何的E2结构化读本，测试逐点与机械切片及独立局部坐标公式比较。复用冻结GeometryPrimitives，不修改旧轮。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P060|0x06000061 / 0x3B7C|0x2BEC|525|[证据](evidence/processed/0x06000060.il.txt)|
|P2F5|0x060002F6 / 0x3DE50|0x42C8|22674|[证据](evidence/processed/0x060002F5.il.txt)|
|P2F7|0x060002F8 / 0x3DE68|0x33514|22682|[证据](evidence/processed/0x060002F7.il.txt)|
|P2F8|0x060002F9 / 0x3DF28|0x3356C|22693|[证据](evidence/processed/0x060002F8.il.txt)|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
