# 动态与静态差异（2026-10-27）

尚无A2/障碍物/A3目标业务运行结果，不能声称“与静态一致”或“已发现算法冲突”。以下是环境、实验设计和观察能力差异。

## 1. 目标命令可用性

- Feature: EXP-00 / RCL。
- Static result: 原程序集存在命令入口；原引用API23.1、Framework4.8。
- Runtime result: API25.1 / CLR8.0.12中目标映像已加载；NETLOAD结束未见显式异常；`(command "RCL")`返回未知命令。
- Difference: 映像加载并未形成可用命令，未到两点输入。
- Likely reason: 宿主/API/依赖或命令注册兼容问题是候选原因；没有LoaderExceptions，无法确诊。
- Evidence level: L1原始引用；L3宿主命令输出/Observer事件；不是L3业务算法。
- Action: Runtime validation blocked by host compatibility；不修改目标，不推测具体缺失依赖。

## 2. EXP-06的原点示例

- Feature: A2 Departure TP。
- Static result: GetPoint取消返回Origin；绘图逐点检查Origin。
- Runtime result: 未执行。
- Difference: 任务示例DER=(0,0,0)会直接退出，不能用该输入验证距离。
- Likely reason: 旧实现把有效原点与取消哨兵合并。
- Evidence level: L1处理代码 + L2 IL；没有运行佐证。
- Action: 后续实验换成非零坐标并平移理论端点，保留原行为。

## 3. 障碍物metadata箭头

- Feature: RandomPoint→metadata→ScreenData。
- Static result: RandomPoint只追加DBPoint+MText；此调用metadata为空，未写WsEntityFrame。解析器可读其他入口写的EntityFrame，失败/空名使用ObjectId后缀。
- Runtime result: EXP-01–03未执行。
- Difference: 用户要求核实的链图不能直接当成实际必经流程。
- Likely reason: 通用metadata读取能力与生成器的裸Point路径不同。
- Evidence level: L1处理代码 + L2 IL；非运行差异结论。
- Action: 按两分支保存schema和边索引，不补造Height/TreeHeight字段或实测JSON。

## 4. 输入队列污染

- Feature: 受控CAD操作。
- Static result: 与目标业务算法无关。
- Runtime result: 任务文本被逐行作为命令，反复SAVEAS；测试图曾另存桌面；用户回复已停止后，取消操作仍立即重开SAVEAS。
- Difference: 实验失去受控输入条件。
- Likely reason: 输入/粘贴队列尚未排空；具体来源不确定，不能归因用户或WsTools。
- Evidence level: L3宿主/输入环境观察，排除出业务L3。
- Action: 停止自动输入，保留事件和污染边界；不保存、覆盖、删除桌面图，不继续加载诊断工具。

## 5. Observer源码和加载版本

- Feature: 匿名Group成员采集。
- Static result: A3以AddDBObject创建Group，未写命名字典；当前Observer源码新增groupMembers。
- Runtime result: 已加载DLL在该新增代码前构建；未执行EXP-09/10。
- Difference: 当前源码新增能力尚未部署。
- Likely reason: 编译加载后进行源码补充。
- Evidence level: 构建/源码版本记录；无Group业务实测。
- Action: 独立记录源码和DLL hash；不以命名组快照推断Group不存在，不覆盖已加载产物。
