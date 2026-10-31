# Round 1 实验索引（2026-10-27）

**Runtime validation blocked by host compatibility**（工作状态，根因未确证）。原目标映像已加载，但 RCL 未注册/不可用；另有输入队列污染，不能继续受控实验。没有修改目标或强行重定向依赖。

| 实验 | 实际状态 | 证据及未完成项 |
|---|---|---|
| EXP-00 RCL | 尝试，未完成校准 | Observer 初始化和空图快照成功；目标 NETLOAD 结束。但 `(command "RCL")` 返回未知命令，没有两点提示或目标实体。普通输入误纠正为 CIRCLE，已取消，不计作 RCL。 |
| EXP-01 RandomPoint | 未执行 / blocked | 没有原目标单障碍物数据，不生成冒充实测的 EXP-01-RandomPoint.json。 |
| EXP-02 xInfo | 未执行 / blocked | 没有 EXP-01 Point，未取得 xInfo 实际输出与 Observer 字段对照。 |
| EXP-03 ScreenData | 未执行 / blocked | 无原目标 SelectAll、表格或 API 调用栈运行证据。 |
| EXP-04 Mark | 未执行 / blocked | 无实际 BlockReference/属性结果；图块定义只读诊断也未执行。 |
| EXP-05 C | 未执行 / blocked | Line 追加→另一事务写 metadata 只有代码/IL证据，未取得实体事件时序。 |
| EXP-06 Departure TP | 未执行 / blocked | 另有静态注意：DER=(0,0,0)会触发 Origin 返回，重试应使用非零DER并平移比较，不能修改旧代码。 |
| EXP-07 NPA SOC | 未执行 / blocked | 18来自单一计时输入，内部没有3+15拆分：Direct IL；非 Runtime corroborated。 |
| EXP-08 PA SOC | 未执行 / blocked | HLcor=0→−1→CAD取负+1只有L1/L2，未实测。 |
| EXP-09 A3 KK | 未执行 / blocked | 无 KK/Polyline/Group 实体运行记录。 |
| EXP-10 A3 DME | Not required for Round1 acceptance；未执行 | 以EXP-09完成为前提；当前未满足。三弧半径/分组/Z已有静态证据，继续宿主操作不能消除当前阻塞。此可选项不豁免EXP-01–09的缺口。 |

## 原始记录与证据边界

- `logs/observer.jsonl`：Observer生成的活动日志。`logs/observer-closure-snapshot.jsonl`为收尾时冻结副本；hash见`logs/closure-integrity.json`。冻结副本保留污染事件，不删改后伪装干净日志。
- `logs/AutoCAD-command-history-before-diagnostics.txt`：污染前文本窗口的可见历史；并非CAD全会话日志。
- `logs/NETLOAD-observed.txt`：截图/模块查询的人工转录，不能等同原生完整错误日志。
- `logs/input-interference.md`：污染经过与再次取消结果。污染命令不能作为WsTools行为。
- `bin/WsToolsHostDiagnostics.dll` 已编译，**未成功NETLOAD/执行**；没有`host-target-loader.json`或`symbol-obst-definition.json`，不能猜写LoaderExceptions或obst定义。

Observer确有宿主运行证据，但只校验了初始化、命令事件和空图快照。未校验非空实体各字段/Group成员的采集能力；没有附加managed debugger，也没有GetPoint/GetEntity/GetSelection断点调用栈。API调用次数仍以静态IL标注。

## Observer版本

当前已加载DLL为12:07编译版本。源码后来增加了Group对象的`groupMembers`采集，尚未重新编译/加载；这部分不能算已部署能力。原版本能记录Group对象基本信息及命名组字典快照，无法据空命名组字典排除A3直接AddDBObject的Group。各源码/产物hash独立登记，不声称现源码就是已加载DLL的精确构建输入。

## 继续验证的条件

先清空并确认CAD输入队列，重新使用隔离目录内的新R01图；确认目标命令注册/类型加载的具体错误后决定是否需要匹配API23.1的受控宿主。不得修改原DLL、修改安全设置或接管现有工程图来绕过阻塞。本轮保留全部未执行项，完成静态及编译交付。
