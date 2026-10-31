# A9 遗留行为与规范映射矩阵

日期2026-10-31；受控设计1.3的导出规格。RecoveredObstacleAssessmentEngine = BehaviorLocked。整体验证不等于 RuleMapped；本轮不改变 Provider 或 recovered 文件。

## 依据与口径
规范：R1 I-2-1 1.2／1.3、I-4-2 2.1.3／2.1.4；详见四份RuleSpec。行为证据：recovered/ObstacleData/PriSec.Recovered.cs 的 Local、LineY、Evaluate；recovered/A9-PriSec/input-semantics.md；A9 Behavior Lock Report.md 与既有fixtures。A9坐标以反向轴表示，首端x=0、尾端x=-L；其输入W在算式中是中心线至外边界的半宽H，不能依UI“宽度”字样当成总宽2H。

| 项目 | R1规范 | A9 Legacy | 一致性 | 正式实现 |
|---|---|---|---|---|
| Primary boundary inclusion | 主区全MOC；编程归属未明示 | y≤primary为主区，但先经纵横预筛 | 条件一致，非整个筛选一致 | Native闭合主区；等号为DD-I06-003 |
| Secondary inner boundary inclusion | 内边界全MOC | 内边界由主区分支拥有 | Normal有效正宽域内一致 | 此数值与归属可局部RuleMapped |
| Secondary outer boundary inclusion | 外边界MOC为0 | 公式用y≤outer；预筛却要求y<max(W0,W1)，等宽外边界被丢弃 | 不完全一致 | Native外边界纳入副区MOC0 |
| Segment start/end inclusion | 编程首尾归属未明示 | Normal严格-L<x<0；IF闭合-L≤x≤0 | 历史模式不同 | Native两端闭合、去重／取控制值 |
| Normal mode | 无名为Normal的规范飞行阶段 | 普通历史计算分支，主区端宽均W/2 | 无阶段映射证据 | Adapter内LegacyEvaluationMode.Normal |
| IF mode | 不能仅凭IF字符对应规范阶段 | 闭合端点，尾端primary使用W1而非W1/2 | 与通用等分模型不同 | Adapter内LegacyEvaluationMode.IF；不用于Native默认 |
| W1/2 vs W1 | 适用副区时P=H/2 | Normal尾端W1/2；IF尾端W1 | Normal条件一致；IF不一致 | Native P(s)=H(s)/2 |
| MOC linear reduction | MOCp×(1-Y/Ws)，Y垂直航迹 | moc×(outer-y)/(outer-primary)；moc另沿x插值 | 同一s、正Ws且等价边界时代数一致 | 仅该等价公式局部RuleMapped；本Arrival主MOC恒300 |
| Reference width/distance | 本s的副区宽；垂直标称航迹 | 本x的outer-primary及abs(localY) | Normal有效域可对应 | Mapper显式W=H，局部轴x=-s，非最短斜边距 |
| zero width | 本子集要求正副区宽；R1未规定除零API | 分母0时直接全moc；预筛可能先丢弃 | 无规范等价依据 | Native拒绝ZeroSecondaryWidth |
| zero length | 退化不构成受支持航段；未规定哨兵 | moc除length未防零；LineY分母0给±1000000 | 不一致／无依据 | Native拒绝，不生成NaN或哨兵 |
| outside obstacle | 区外不控制本保护区，API形式未明示 | 不加入返回列表 | 可解释业务含义，输出契约不同 | Native保留Outside记录，MOC/Candidate=None |
| original Z handling | 评价必须使用一致基准的标高 | Local初为z-sz；事件恢复原始绝对Z再Evaluate | 恢复链路一致；单独Local值不一致 | Mapper保留原始绝对Z，记录Datum及余量 |
| OCA/MOCA/程序高度 | Arrival MOCA与程序高度分离 | 字段OCA=Z+MOC，逐障碍物输出，无完整域汇总 | 仅单点候选可对应 | Native命名Candidate，再由上层有效集合求MOCA_raw |

## 映射边界
RuleMapped只用于已验证的子关系：Normal有效非退化内部点的H/2主副区拆分、正副区宽的线性余度代数关系、事件恢复原始Z后的单点Z+MOC候选。它们不构成整个A9的合规采用。端点、外边界预筛、IF主区线、退化行为与结果集合由Native新设计负责。

Normal和IF目前均无规范飞行阶段直接证据。新领域使用ProtectionEvaluationContext（ProcedureType、ProtectionAreaKind、WidthProfile、MocPolicy、GeometryVersion），Adapter单独记录LegacyEvaluationMode。当前Legacy接口和枚举不重命名，未来迁移仅在防腐层处理。

## 可复用与不采用
Legacy Adapter可作为对照基准，向Provider传入恢复语义的W=H和绝对Z；仅对已声明等价域做差分。NativeEvaluation为计划中的独立计算设计，保持Legacy行为锁定测试。Application不得依据Normal／IF选择规范阶段，不读取旧默认MOC或Width。

测试参见L01至L06及O/M组；若Native和Legacy在已知差异域不同，应断言差异，不修改A9使其相等。Baseline 1.3不会把已有BehaviorLocked升级为Adopted。
