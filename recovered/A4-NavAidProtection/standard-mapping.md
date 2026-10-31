# 代码恢复后的2020规范映射

基线：《航空器运行目视和仪表飞行程序设计规范》AC-97-FS-005，民航规〔2020〕12号。PDF原路径`doc/航空器运行目视和仪表飞行程序设计规范.pdf`，SHA256 `6b6b6f04380f3e0a138ca57bb95fcddb0a390a5b4aa7a9c7a391ff35bb92c8ed`。以下是N层解释，代码事实来自E1/E2，未按规范改写原公式。

[逐项分类CSV](standard-mapping.csv)、[页文本摘录及源hash](evidence/standard-search.json)。页码均为物理PDF页，不能把OCR页脚数字当准确印刷页码。

|行为|规范对应|结论及限度|
|---|---|---|
|VOR7.8° / NDB10.3°|I部分2篇2章2.8，PDF56|Matches current standard。明确是终端区保护区3SD外推扩张角；同页5.2/6.9为2SD系统使用精度，不能混用|
|小档半宽1 /1.25NM|II部分2篇3章3.4.3.2/.3，PDF332；4章4.4.4，PDF335|Matches current standard。在台处总宽2 /2.5NM，故代码两侧半宽准确对应；规范3.7/4.6km是舍入表示，不能用2315与2300差15m认定不同标准|
|大档半宽2 /2.5NM|I部分4篇3章附录B，B.1.1等，PDF146–149|数值Matches current standard：可解释IF在VOR/NDB台处的宽度候选。代码没有进近阶段，不能把大档当通用最后进近默认宽度|
|内线为外半宽0.5|II-2-3 3.4.3、II-2-4 4.4.4|Matches current standard的分界比例：主区总50%，副区每侧25%。仅画线，不是完整区域评价|
|15°截接|I-2-3 3.2.1/.2、3.3.4，PDF63/65|角度与局部连接用途有规范支持，但具体条款适用条件仍为Implementation basis unresolved（实现依据待确认）；没有转弯切点、内外判定、前段保护区或副区30°构造|
|任意长度/半宽/角度运算|附录B、II-2-4 4.4.4|阶段选择、最大宽度/距离、FAF/MAPt截段Not implemented。把无约束绘图当完整航段模板会与规范条件不同|
|参数来源|两设施setter，随后Draw消费文本|角度不是不可覆盖硬常数：TextBox禁用，但config能填Text；宽度为两档radio。没有普通UI自由宽度/角度编辑，测试自定义值是适配器注入|
|超障评价|II-2-3 3.4.4、II-2-4 4.4.6|Not implemented；规范各场景的MOC不由A4计算|

具体场景必须结合实际程序阶段和飞行方向。S是窄端、E是另端；若飞行E→S向台，边界沿飞行方向收敛，15°斜边从E指向窄端侧相交。这解释帮助中“转弯后飞向导航台”的使用语境，但不能单凭帮助确认设计人员将E放在规范要求的正确连接点。

没有充分证据认定A4来自其他版ICAO Doc8168、旧版国内规范或作者自创方法；不因规范数值一致就证明作者引用来源。历史来源与15°自动适用场景标“实现依据待确认”，其计算/求交本身已恢复。User-editable default、Older-version candidate分类未被证据支持时不强行使用。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F7|0x060002F8 / 0x3DE68|0x33514|22682|[证据](evidence/processed/0x060002F7.il.txt)|
|P2F8|0x060002F9 / 0x3DF28|0x3356C|22693|[证据](evidence/processed/0x060002F8.il.txt)|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
