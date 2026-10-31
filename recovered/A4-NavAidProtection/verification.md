# 独立验证与静态核验分层

**5550条E3独立源码断言通过，另30项静态核验通过；E4=0。** 不把静态检查、列表记录或断言条数写成原AutoCAD实体运行次数。

|层|E3断言|静态核验|范围|
|---|---:|---:|---|
|formula|772|1|端点独立解析式、单位及自定义注入|
|geometry|4584|0|机械P2F9切片与结构化读本的列表/逐点比较|
|mode/facility dispatch|12|0|设施setter、覆盖优先级和Draw读取|
|CAD writer|146|3|输出列表数量/空列表；实体writer靠静态IL|
|serialization|0|10|Load/Closed方向及控件handler，仅静态|
|event/reachability|0|12|五绑定、native身份、MethodSpec及业务排除|
|cross-module|0|4|同MethodDef调用点，排除无证据共用|
|degenerate|36|0|零/负宽度、零/大角、非法输入、原点取消/同点、短段15°|


矩阵144组：VOR/NDB×两宽度×左/右/双侧×中心线开关×15°开关×航向0/90/37°。每组与独立局部闭式公式核对末端，并对结构化/机械切片逐点比较。[15°最终端点](../round9/fixtures/15-degree-endpoints.csv)单独保存；[几何样本](../round9/fixtures/geometry-points.csv)、[逐断言](../round9/fixtures/assertions.csv)、[分层计数](../round9/verification-layers.csv)。

自定义3.75nm/4.2°由独立适配器注入标签和文本，证明reader与几何消费优先级，不声称原UI支持自由输入。非法输入模拟P7D4的提示+0，保留零分母哨兵及不夹限行为。

编译输入hash保存在[test-inputs.json](../round9/test-inputs.json)，命令及边界见[build.py](../round9/build.py)，[编译日志](../round9/compile-tests.log)、[运行日志](../round9/tests.log)、[30项静态结果](../round9/static-tests.json)。只编译运行本轮独立恢复源码；冻结GeometryPrimitives直接复用。静态writer检查证明Polyline/Group构造路径和空metadata，不证明宿主事务成功；config检查没有伪造TXT往返或修改原config。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
|P087|0x06000088 / 0x555C|0x87E0|1458|[证据](evidence/processed/0x06000087.il.txt)|
|P089|0x0600008A / 0x5878|0x8AB8|1578|[证据](evidence/processed/0x06000089.il.txt)|
|P2FB|0x060002FC / 0x3E9A4|0x42D6|23091|[证据](evidence/processed/0x060002FB.il.txt)|
|P2FC|0x060002FD / 0x3E9C8|0x42F2|23096|[证据](evidence/processed/0x060002FC.il.txt)|
