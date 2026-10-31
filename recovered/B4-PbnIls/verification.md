# 验证与可重放成果

运行 `python recovered/round7/database.py` 以只读方式读取原DB；`python recovered/round7/build.py` 编译并运行独立C#恢复源码。系统csc沙箱输出报CS0016后经授权允许编译器正常写本轮目录。未加载WindSpiralBasic.dll或启动AutoCAD。

|层|覆盖|限制|
|---|---|---|
|formula|27组DB原行，三mode、GP3.0/3.2/3.5、LOC2000/3000/4500；RDH12/15/18；机体修正；A-D/标高0/900/>900/GP3.0/3.2/3.3；SOC|DB expected由独立Python定长解码；HL/修正按IL算术独立表达|
|geometry|交面线性方程独立行列式校核、E′/15°/1852/3704/三点副面、12/9列表、CAD清Z|无原DWG或宿主运行oracle|
|surface-classification|五段站距边界±epsilon、正负侧、1852/3704边、tie、Y特有门控、W/X/Y/Z/副区/out自然点、共享mode/W*和CATII150|独立决策表对照不等于真实运行|
|obstacle|penetration、向外比例、原绝对高混用、Ha/HL/DA/DH/RVR、非穿透跳过|未模拟可达UI，因为原无调度|
|serialization|真实P561/P565往返、中文逗号、WS、短记录/未知NAME、遗漏跑道|RecoveryCell不触发WinForms事件|
|KML|真实空handler无输出；原/处理IL静态核验|标为stub覆盖；无导出器可验收|
|event/reachability|静态18项断言及全程序集incoming/MethodSpec；Take5危险第6点夹具|未运行目标UI；不宣称绕过成功|
|degenerate|零GP、非法GP提示后返回0并传播Infinity、文本框focus/color记录、零梯度NaN、零除哨兵、零横向系数NaN、非法DB数字、负LOC key、银行家舍入|无新增拦截；focus/color为记录适配器，左右转/角度/零可配置宽度是N/A|
|cross-module comparison|共同frame和绝对Z语义；逐MethodDef和调用CSV|A5只做获准的共享层查询|

最新分层计数见 [tests.log](../round7/tests.log)，每个断言的输入标签/实际/期望见 [assertions.csv](../round7/fixtures/assertions.csv)，[fixture-index.json](../round7/fixtures/fixture-index.json)列材料/hash/适用性。历史fixture预期错误（Y面赢但超扩张边，实际out）保存在failure.txt；已同时保留区内/区外样例，算法未改。

原/处理方法身份映射 [recovery-method-map.csv](evidence/recovery-method-map.csv)；恢复的60个方法保留分支和IL InitLocals，PE方法头另经 [method-header-flags.csv](evidence/method-header-flags.csv)核验。RecoveryHost中的DB row/CAD变换/截取是明确标注的E2适配器，输入解析按P7D5/P7D6保留提示后返回0；focus/color仅记录，未声称实际UI执行。字段完整读写见 [model-fields.csv](evidence/model-fields.csv)。所有源文件hash见test-inputs.json，冻结核验见 [integrity-report.json](../round7/integrity-report.json)。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。
