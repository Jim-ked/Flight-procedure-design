# 未实测项与证据限度

|事项|当前证据|保留范围|
|---|---|---|
|原插件E4|本轮未加载目标DLL、未控制AutoCAD|无运行等价、界面外观、许可/加载状态或原宿主回归结论|
|WinForms真实生命周期/config时序|五绑定及P0F6/P0F4/handler静态恢复|未运行所有配置条目顺序与CheckedChanged交错；最后文本仍可能被设施事件覆盖|
|CAD宿主行为|writer及数据库API路径完整|空Group入库、宿主默认层/色/线型、事务/锁异常、零长重复顶点的实际接受性未测|
|异常拾点/输入|Origin取消及重试/parse分支已恢复，独立输入测试|未实测UCS/交互显示/用户打断。代码消费返回坐标并在其XY运算，不另推宿主坐标转换|
|15°场景选择|交点构造、终点替换、固定角及帮助语境已闭合|规范转弯切点/内外判定未实现；选E与侧别由设计人员提供。历史来源“实现依据待确认”|
|主副区与评价|半宽分界几何直接存在，完整窗体和可达链无评价|不能产出已评价MOC/OCA。没有发现待补接的孤立评价器|
|设施/航段语义对象|只有S/E、标签、开关|无台站ID/阶段/长度上限/输出metadata，外部数据自动关联未实现|

以上是宿主运行验证缺口、缺失产品功能或规范适用条件，不是重要设施/15°计算/CAD writer的静态断链。P2F6无IL是已证明user32.dll SetFocus的P/Invoke，不能报告成未恢复方法体。原DLL保护桩与处理源码不同证据等级始终保留；未将E1/E2升格为原始未混淆源码。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F6|0x060002F7 / 0x0|0x0||[证据](evidence/native-import.json)|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
|P2FB|0x060002FC / 0x3E9A4|0x42D6|23091|[证据](evidence/processed/0x060002FB.il.txt)|
|P2FC|0x060002FD / 0x3E9C8|0x42F2|23096|[证据](evidence/processed/0x060002FC.il.txt)|
