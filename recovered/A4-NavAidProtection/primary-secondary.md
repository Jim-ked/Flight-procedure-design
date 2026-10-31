# 主副区：几何有分界，评价无实现

A4不是“只有一条外边界”。P2F9明确使用w/2与(w+L·tanα)/2，左右各画一条内线；每个站距主区半宽为外半宽的一半。这支持**主副区边界几何**：双侧合计主区宽度占总宽50%，每侧副区占总宽25%。规范对照亦能支持该解释（N），但代码没有Primary/Secondary命名的区域对象或类型标签。

15°选中时两条不同斜率的内/外边与同一斜线相交，终止站距不同；不能把两个交点当同一截面的w/2关系失效。边界为开放Polyline，没有填充/面、闭合polygon、自动contains、MOC衰减或OCA。

不得用“无显式业务名称”否认明确的0.5几何，也不得将它扩成已实现完整主副区评价。A9是另一个宽度/MOC/障碍物算法，A4没有调用。无0.25宽度常数业务调用；25%是由双侧几何推导的比例，不冒充源码常数。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
