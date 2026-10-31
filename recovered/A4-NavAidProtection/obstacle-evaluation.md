# 障碍物评价与A9可达性

完整A4 Form及直接可达公共业务helper中，未发现ScreenData、障碍物解析/筛选、SelectAll、MOC、OCA、DataGrid、Mark、Highlight、控制障碍物输出或孤立完整evaluator。CAD writer/通用config注册器的词法/API候选不等于A4障碍物入口。

P2F9只将拾点和文本转换为边界列表，写CAD后返回；不读取已绘实体、DBPoint或障碍物记录。A9 P32F/P330/P331与其PriSec窗口没有从A4事件的direct/MethodSpec可达路径。公共ReLine算术相同不等于业务评价共用。

结论是几何构造工具：支持外边/半宽分界与15°截接的绘图，不兼有障碍物评价。这里没有Round5–8式“完整孤立评价器”触发验收缺口；不存在的评价功能按缺失记录，不补接。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
