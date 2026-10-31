# CAD人工交互与自动化边界

|操作|选择的业务对象|软件为何要求人工|进入计算|已有程序数据能否推导|
|---|---|---|---|---|
|THR GetPoint P559→P113|入口空间点|没有跑道对象/标识查询|frame原点、绝对高、CAD平移和FAF差值|若外部提供可信跑道关联，可预填；当前只有文本/图面，不能自动辨认任意点|
|end GetPoint P55A→P113|跑道末端点|没有跑道轴线实体关系|反向bearing/二维长度；Z存储但不改bearing|同上；不能从THR单点确定方向|
|OAS GetEntity P56B|带参数文本的边界实体（提示称“面”）|无程序ID、Group模型索引或最新版本关系|XData[1]→TXT parser→系数/UI|可按已知WsObject文本检索候选；多个快照/其他App时无法无歧义自动选定，原代码未实现|
|ScreenData P555|Model全部POINT|实际SelectAll，不是人工框选|Take5→XYZ、名称、ID字典|已代码化，但无业务类型筛选/危险排序|
|表格SelectedRows P57D|设计者要标注的障碍物行|软件无可达评价/控制点选择|ID→源点→obst/Altitude|列表可以批处理；“控制障碍物”无法靠现有可达评价自动推导|
|CellClick P56E|所点表行|UI选目标|ID→取消旧高亮→高亮|可由ID自动定位，当前没有居中调用|

P113取消可返回Origin，B4未按业务额外检查。没有turn point、KK′或C选择，也没有人工裁剪边界的指令。无法从静态无调用推断设计者实际会手工补画/修正转弯；只可明确原代码没有自动完成那部分。衔接点由数值交线自动计算；与既有CAD保护区相交/删除重建没有实现证据。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P559|0x0600055A / 0x8A3E8|0x70D8C|60967|
|P55A|0x0600055B / 0x8A538|0x70E40|60988|
|P56B|0x0600056C / 0x8C5C4|0x725B0|61820|
|P555|0x06000556 / 0x899C0|0x70514|60800|
|P56E|0x0600056F / 0x8C984|0x7278C|61908|
|P57D|0x0600057E / 0x8E114|0x73724|62563|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
