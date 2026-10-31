# 直线主副区障碍物评价

## RuleSpecId
RS-OBS-PRIMARYSECONDARY-001；修订 I0.6 r1；2026-10-31。

## Title
连续直线对称保护区的空间分类与副区线性余度。

## Status
IMPLEMENTABLE。YES。Native 规范模型可编码；A9 继续 BehaviorLocked，不修改其边界、IF或异常行为。

## NormativeSource
STD-R1 I-2-1 1.2.1、1.2.2、1.3与式 I-2-1-1／2（PDF44／28页）；III-1-1 1.5.2、1.5.4.1（PDF485至486／469至470页）；III-3-2 2.1.2（PDF581／565页）。规范定义主副区及余度，未规定编程比较操作符、重复障碍物归属和浮点容差；下述等号与退化处理明确为受控软件设计决策 DD-I06-003。

## Applicability
I1-A 同方向共线连续直线，连续分段线性 H(s)>0；P(s)=H(s)/2，Ws(s)=H(s)-P(s)>0；静态精确点障碍物，或已经声明垂直余量的点。不是任意多边形、转弯保护、无副区保护或零宽退化构造的通用算法。

## Inputs
ProtectionEvaluationContext：TrackId/version、S、单位向量u、L、WidthProfileId/version、s0/sc/s1、P/H/Ws函数、端点和边界政策、FrameId；ObstacleId/version、位置Q、AbsoluteTopElevation/Datum/AccuracyMetadata；ResolvedObstacleAssessmentPolicy；RuleContext。新Domain不出现A9 Normal／IF。

## DerivedInputs
s=(Q-S)·u；n为u的单位法向量；y=|(Q-S)·n|（左右对称）；在同一沿航迹位置取P(s)、H(s)、Ws(s)。Y=y-P(s) 为从主区边界沿垂直标称航迹方向量得的距离。Reference width 是本s的每侧副区宽Ws，不是总宽、外侧H或欧氏最近边距离。

## Preconditions
有限坐标、L>0、u有效、帧和高程基准一致；整个评价域H>P>0、Ws>0。输入折线不得在不同片段出现航向变化。WidthProfile必须保留与NominalTrack的解析映射；仅有人工多边形而无映射 → RuleResolutionRequired/GEOMETRY-MAPPING-MISSING。点的非零水平不确定性按 MOC 规则拒绝。

## Algorithm / Construction Rule
1. 首先判断s：s<0或s>L → Outside。Native在s=0、L均纳入闭合端截面；不延长航迹，不生成端部圆帽。
2. 对0≤s≤L，求当前H、P、Ws；y≤P → Primary；P<y≤H → Secondary；y>H → Outside。
3. Primary的MOC=MOCp；Secondary的MOC=MOCp×(1-(y-P)/Ws)。函数在内边界为MOCp，在中点为MOCp/2，在外边界为0。先分类后计算；不以clamp把区外点转换为副区。
4. 分段线性宽度的Ws沿s线性插值，对应 I-2-1 1.2.2；P/H在同一个s计算。收缩斜边不使用点到斜线的最短距离，避免余度递减偏差。
5. 共享片段端点同一ObstacleId只保留一个统一评价记录；若存在多个合法保护上下文覆盖，保留上下文明细，候选高度取最大以防漏算，不取平均。I1-A单一连续profile的共享点应得到相同值。
6. 保留原始绝对Z，按 MOC 规则统一基准后计算候选。局部坐标变换不得把z-sz当作绝对标高。
7. 零长度、零副区宽、非正H/P、不连续profile及非有限结果均返回InvalidInput/诊断，无NaN、无±1000000哨兵、无除零后全MOC的隐式补救。全主区无副区应是另一规则类型，本切片不冒充退化副区。

## Outputs
每障碍物 ObstacleId、ContextId、Classification Primary/Secondary/Outside、s/y/P/H/Ws/Y、AppliedMoc（Outside为None）、RequiredAltitudeCandidate（Outside为None）、BoundaryOwnership、InputVersions、RuleSpec/source、CalculationTrace。对Outside保留结果记录以便证明已处理，不静默丢弃。

## BoundaryConditions
DD-I06-003：主区含其边界；副区内边界由主区拥有；副区含外边界且MOC0；首尾截面均含；共点去重且保守控制。该决策与规范在主区全余度／副区外边0一致，补充了实现所需的集合归属，并非声称R1逐字规定≤。精度策略：合成测试采用双精度、位置预言容差1e-6 m、MOC容差1e-6 m；容差只用于验证数值，不扩张或收缩区域。生产求值若误差区间跨分类边界且无法可靠识别等号，返回NumericAmbiguity，不自动将障碍物判区外。

## Exceptions
InvalidInput（DegenerateTrack、ZeroSecondaryWidth、NonFinite、Frame/DatumMismatch）；UnsupportedScenario（Turn、UnsupportedProfile）；RuleResolutionRequired（GeometryMappingMissing、AccuracyFootprintRequired）；NumericAmbiguity。失败不得产生有效MOCA。

## DependencyInputs
Track geometry、ResolvedWidthProfile、ObstacleAssessmentPolicy、ObstacleDataset、AcceptedGeometry、RuleContext、Frame/Datum/PrecisionPolicy。A9 Adapter必须记录LegacyEvaluationMode和AlgorithmSource，但不把其模式注入本规则。

## InvalidationRules
Protection/profile/AcceptedGeometry/政策/障碍物任一版本改变 → Evaluation Dirty。上游构造变化按依赖图传播；不通过重新跑 A9 自动更新 Native 结果。

## Diagnostics
OBS-PRIMARY；OBS-SECONDARY；OBS-OUTSIDE；DEGENERATE-TRACK；ZERO-SECONDARY-WIDTH；PROFILE-INVALID；GEOMETRY-MAPPING-MISSING；NUMERIC-AMBIGUITY；EVALUATION-STALE。

## TestCases
见 O01至O15。A9 差异预言见 L01至L06；必须分别保留 Legacy 回归与 Native 规范测试，不把两者数值不同视为应修改Legacy的理由。

## OpenQuestions
无当前直线对称正宽度子集阻塞项。A9 Normal／IF与规范阶段无直接证据映射，只是 LegacyEvaluationMode；IF不得自动解释为Intermediate Fix阶段。任意人工边界／转弯／无副区／水平不确定性包络另行闭合。
