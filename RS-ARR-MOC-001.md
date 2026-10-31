# 简单进场超障余度政策

## RuleSpecId
RS-ARR-MOC-001；修订 I0.6 r1；2026-10-31。

## Title
普通地形条件下 GNSS RNAV1 Arrival 主副区 MOC 与评价结果语义。

## Status
IMPLEMENTABLE。YES。排除需附加山区／大气或当地规定余度的条件；不生成公布程序高度。

## NormativeSource
STD-R1 I-4-2 2.1.3、2.1.4（PDF128／112页）；I-2-1 1.2、1.3（PDF44／28页）、1.7（PDF45／29页）、1.8与1.10（PDF46／30页）；III-3-2 2.1.1.2、2.1.2、2.2.1（PDF581至582／565至566页）。主区“最小300 m”已回读原文，不是从旧设计摘要反推。

## Applicability
Arrival 超障准则适用到 IAF 或 IF 的进场部分；固定翼A至E、GNSS RNAV1、直线 Primary+Secondary。不是 TAA/MSA、不是 Approach、不是山区最低区域高度。300 m是本普通条件切片的最低主区余度，不是所有机场／地形／天气的全局常量。

## Inputs
ProcedureContext（Arrival、有效航段范围、TerminalFixRole）；ProtectionEvaluationContext（已解析主副区、当前几何版本）；TerrainAtmosphereContext（NormalConditionsConfirmed、SpecialMocRequirement，必须显式声明）；RuleContext；ObstacleDataset（点坐标、原始绝对标高、DatumId、数据版本、覆盖/完整性声明、垂直与水平不确定性声明）。真实复杂地形与气象风险判定不由本切片自动推断。

## DerivedInputs
PrimaryMoc=300 m；SecondaryMoc(s,Y)=300×(1-Y/Ws(s)) m；Y、Ws由 RS-OBS-PRIMARYSECONDARY-001 返回。EvaluatedElevation = AbsoluteTopElevation + declaredVerticalAllowance（已包括时不得重复增加）；I1-A合成点集水平不确定性为已声明0。非零水平不确定性需要足迹/包络评价，不可当成精确点静默使用。

## Preconditions
普通条件已确认，SpecialMocRequirement=None；若为 Unknown 或需山区／当地附加余度，不解析300 m政策。障碍物和评价标高同一垂直基准，单位m且有限。I1-A可用显式合成完整数据集验证计算；不得把该标志伪装成真实运行安全证明。

## Algorithm / Construction Rule
1. 校验过程阶段和特殊条件，解析 ObstacleAssessmentPolicy；Application 只消费政策值。
2. 主区 MOC300；副区按1.3线性递减；外边界0。Outside输出分类且 MOC和高度候选为 NotApplicable，不以MOC=0、候选=Z混入控制障碍物集合。
3. 对在区内的每个障碍物 i 输出 RequiredAltitudeCandidate_i = EvaluatedElevation_i + AppliedMoc_i。Native用该明确命名；A9的OCA字段只能经Adapter解释为单障碍物候选。
4. 在同一有效评价域内，MOCA_raw = max(RequiredAltitudeCandidate_i)，同时记录全部并列控制障碍物。仅当地形／障碍物覆盖完整、基准与余度政策有效、几何可评价且非空有效集合时返回 MOCA_raw。数据不完整时允许列出已有候选，但整体结果Incomplete且不提供有效MOCA；空集返回NoControllingData，不能返回0或“安全”。
5. ProcedureAltitude 不由此函数产生。若后续输入建议程序高度，仅可检查其不低于有效MOCA_raw；ATC、空域、温度、覆盖、下降与公布取整约束由后续规则处理。MOCA_raw是本静态数据与政策的未取整计算下限，不是公布或批准高度。

## Outputs
ObstacleAssessmentPolicyId/version、PrimaryMoc、SecondaryReductionPolicyId、OutsidePolicy；每障碍物分类、AppliedMoc、EvaluatedElevation、RequiredAltitudeCandidate、CalculationTrace；集合EvaluationStatus、MOCA_raw/optional、ControllingObstacleIds、CoverageStatus、DatumId、GeometryVersion、RuleSpec/source。A9.OCA 与 Native.MOCA_raw 不复用同名字段。

## BoundaryConditions
主副区共边全余度；副区外边0但属于闭合保护边界，其标高仍可形成候选；Outside无候选。端点去重／控制取最大见 OBS 规则。高度负值允许（海平面以下），NaN/Infinity不允许；不提前取整MOC或候选。

## Exceptions
山区已知≥20 kt风等情形：I-2-1 1.7规定可能增加最多100%，由设计师/审批当局判断；本切片返回 RuleResolutionRequired/SPECIAL-MOC-REQUIRED，不自动套600。普通条件未知同样拒绝。非零水平不确定性 → RuleResolutionRequired/OBSTACLE-FOOTPRINT-REQUIRED；基准缺失或不同 → InvalidInput/DATUM-MISMATCH。

## DependencyInputs
Procedure/terrain/atmosphere context、RuleContext、ProtectionEvaluationContext、AcceptedGeometryId/version、ObstacleDatasetId/version、Datum/AccuracyMetadata。障碍物变化不依赖航迹重建。

## InvalidationRules
MOC政策或特殊条件改变使 Evaluation 失效；若适用阶段／导航条件改变，还须按依赖矩阵传播；ObstacleDataset／AcceptedGeometry改变只使 Evaluation 失效。无自动求最大值或后台重新评价。

## Diagnostics
MOC-POLICY-RESOLVED；SPECIAL-MOC-REQUIRED；NORMAL-CONDITIONS-UNCONFIRMED；DATUM-MISMATCH；DATA-COVERAGE-INCOMPLETE；NO-CONTROLLING-DATA；OBSTACLE-FOOTPRINT-REQUIRED；GEOMETRY-MAPPING-MISSING；EVALUATION-STALE。

## TestCases
见 M01至M09与O01至O15；主区300、副区300/150/0、区外、特殊条件拒绝、原始Z、统一基准、空集、不完整数据与MOCA/程序高度区分均有确定预言。

## OpenQuestions
无本普通条件子集阻塞项。山区附加余度、真实地形包络、非零水平不确定性、公布高度取整及程序高度运行约束另行 RuleSpec 化。RecoveredObstacleAssessmentEngine 整体仍 BehaviorLocked；不把一个线性公式的一致性升级成整个A9符合规范。
