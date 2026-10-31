# XData：本路径无metadata

P2F9处理IL_0891–IL_089D：传WorkingDatabase、list2、`ldstr ''`给公共P087。C#省略可选第三参，IL证明实际是空串。P089只有`P_2.Trim().Length>0`才登记WsObject、写1001和1000。

因此A4新建子Polyline不写WsObject、Kind、facility、angle、width、Form state或其他XData；Group也无metadata。公共writer具备可选metadata能力不等于A4使用。无业务标签可从所选图元反读导航台类型或参数。几何位置可供人判断，但不是可审计的参数身份协议。

本窗口无GetEntity/XData导入按钮，也没有portable TXT/JSON序列化器；临时UI配置是另一个config通道。不能从Group名称猜业务身份，writer未给Group命名。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
|P087|0x06000088 / 0x555C|0x87E0|1458|[证据](evidence/processed/0x06000087.il.txt)|
|P089|0x0600008A / 0x5878|0x8AB8|1578|[证据](evidence/processed/0x06000089.il.txt)|
