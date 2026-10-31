# E4 原插件验证计划（仅计划）

## 当前状态和宿主条件

15个航空功能的E4业务验证均 **NOT_COMPLETED**。Round1曾有Observer初始化、映射目标和空图/命令事件，但RCL不可用及输入干扰不构成业务验证。后续轮为恢复源码E3与静态审计。现有AutoCAD2026/API25.1兼容编译不能替代匹配API23.1原宿主。

启动条件：匹配Autodesk API **23.1** 的宿主及原依赖解析；兼容 **.NET Framework 4.8**；核对PE x86/AnyCPU与宿主位宽，AnyCPU不保证所有native依赖兼容；核对System.Data.SQLite托管/native位宽和版本；保持原WsSymbol、块、config、oas.db及资源相对路径。记录OS/区域设置、程序集hash、引用版本与工作目录。优先复制到独立测试目录，新建独立图；不得改原件或绕过信任设置。

## Priority 1：可能改变业务理解

|试验|输入/比较|必须记录|结论边界|
|---|---|---|---|
|事件时序|Load/config/Validated/CheckedChanged及A2 TabIndexChanged；A3 Leave|前后控件值、事件序列、方法身份、异常|确定真正先后覆盖，不以记录adapter推断WinForms行为|
|取消行为|A2各链第1/2次Esc；A7 DER/THR取消；A6 Envelope取消/空选择|PromptStatus、返回值、已有/新增实体及事务|区分Origin哨兵与真实取消；不据静态差异先修复|
|metadata持久化|A2 Line两事务、A5/B3/B4子线payload、A7 Circle Radius、B5空description|保存重开DWG前后TypedValue、RegApp、entity handle、异常与数量|确认实际写入/失败原子性；不补schema|
|Group/XData宿主行为|空列表/单列表/多列表；Undo/失败路径|Group成员ObjectId、字典/实体状态、XData/OCS|恢复记录器不能模拟宿主事务和组字典|
|另一可信构建的orphan UI|仅在完成静态比较并获后续执行授权后|事件→评价→结果消费完整链|不主动调用当前孤立体冒充公开能力|

## Priority 2：验证静态几何

- A1：single/double/triple人工锚点、左/右、Polyline/Spline、切线checkbox列表；测量输出点序/端点，不预设通用公切线。
- B1：60/90/120附近、SW1≠SW2、KK单Polyline与NN Group；B2：ATT=0和非零、15°候选、12000/13000载体。保存名义bulge及四保护点列。
- A7：三模式阶段实体/镜像/外圆及Radius；障碍物边界与二检覆盖同一行。保留TP/KK/C人工输入。
- A3：DME三Arc、KK早晚Line、顶空Circle；检查未指定/指定距离及取消。
- A8/A9/A10：ID→原点Mark/Altitude与高亮；A9 Normal/IF端点；A10 factor*300。B3/B4/B5先确认仅导入链，放入第6个高障碍物观察Take5差异，不宣称孤立评价已运行。

## Priority 3：宿主显示细节

默认图层/颜色/线型、布局/focus/界面恢复、文本外观与OCS显示。未显式set不能预填具体默认值；这类试验优先级低于业务时序与几何。

## 证据包与判定方法

每个实验保存：case ID、适用构建/环境hash、输入值与精确拾点、动作和取消位置、Observer版本hash、事件记录、原始JSON/DXF属性、前后DWG副本、截图、错误日志。以静态预测对照实际差异；宿主证据只升级该实验实际观察到的逻辑，未测分支保持未验证。禁止把E3 fixture点数计为E4样本。

顺序建议：先完成环境匹配与少量Priority1实验，再决定是否扩大Priority2。当前值得做的是有条件的小规模E4；现有2026环境不足以直接宣称原宿主等价。

既有候选：[Round13候选](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round13/runtime-experiment-candidates.csv>)；[Round1编译边界](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/dynamic-test/compile-validation.md>)；[Round1运行限制](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round1-closure.md>)。本轮没有启动宿主或执行目标DLL。
