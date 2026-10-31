# I1-A 业务流 契约与最小依赖

版本 I0.6 r1，日期2026-10-31。文档设计契约，未修改src。业务规则四项IMPLEMENTABLE；执行环境验证仍沿用I0.5阻塞记录。

## 范围冻结
ProcedureType=Arrival；FixedWing A至E；RNAV1；SupportedNavigationContext={BasicGNSS}；NominalTrack为同方向共线连续直线，可含多个共线片段；ARP30一次有效outside→inside穿越且在直线内部；一次完整宽→窄过渡；Primary+Secondary；声明基准及精度的静态合成点障碍物集；FakeCadPort；InMemoryProjectStore。

不支持Fly-by、Fly-over、RF、DME Arc、Holding、非共线直线折转、turn/width-transition interaction、multiple ARP30 crossings、过程内navigation-spec/sensor change、DME/DME或混合传感器、Approach/APV/precision、真实AutoCAD和真实持久化。真实测地线、山区特殊MOC、非零水平不确定性与任意人工多边形评价不在首个验证切片内。

## 契约原则
以下为待I1-A实现的类型化设计，不是声称现有I0.5类型已经具备这些字段。Application编排，Engine解析政策和计算，Domain保存ID/版本/语义，Ports处理预览和快照；Application不硬编码5NM、2.5NM、300m、30°。

Result<T>统一分支：Resolved(value,trace)、InvalidInput(code,diagnostics)、UnsupportedScenario(code,diagnostics)、RuleResolutionRequired(code,diagnostics)。外侧/区外是有效分类，不是异常。NumericAmbiguity归入RuleResolutionRequired并带诊断。失败分支不提供默认value；生成失败不得覆盖已有AcceptedGeometry。

建议签名（设计伪代码）：

```csharp
Result<ProtectionWidth> ResolveProtectionWidth(
    NavigationContext navigation, TrackPosition position, RuleContext context);
Result<ArrivalWidthTransition> BuildArrival30NmTransition(
    NominalTrack track, AirportReferencePoint arp,
    ProtectionWidth outside, ProtectionWidth inside, RuleContext context);
Result<ObstacleAssessmentPolicy> ResolveObstaclePolicy(
    ProcedureContext procedure, ProtectionEvaluationContext protection,
    TerrainAtmosphereContext environment, RuleContext context);
Result<ObstacleEvaluation> EvaluateObstacles(
    ProtectionEvaluationContext protection, ObstacleDataset obstacles,
    ObstacleAssessmentPolicy policy, RuleContext context);
ImpactAnalysis AnalyzeChange(ChangeSet change, DependencySnapshot snapshot);
RebuildPlan PlanRebuild(ImpactAnalysis impact);
```

NavigationContext具有类别／规范／传感器集合／引导／版本；TrackPosition具有TrackId/version、s、ARP distance、FrameId；ProtectionWidth具有XTT/ATT/BV/H/P/Ws和政策来源；ArrivalWidthTransition具有sc/s0/s1与连续profile；ObstacleAssessmentPolicy具有主MOC/递减/区外/适用条件；ProtectionEvaluationContext不包含LegacyEvaluationMode。

RuleContext = ContextId/version + StandardId/version/SHA256 + RuleSpec revisions + MetricFrameId/version + PrecisionPolicyId/version + UnitPolicy。Trace = Input IDs/versions + RuleContext + RuleSpec/clauses + AlgorithmSource/version + 中间值/单位 + OutputId/version + diagnostics。AlgorithmSource本切片使用PlannedNative:<RuleSpec>/r1与PureGeometry解析函数（未来实现版本必须替换为真实版本）；不得把未写的Native标记Implemented。

## 正式用例与追踪
表中 RC 表示上述同一RuleContext；每一步都输出StepTrace，含本行输入版本、RC、规则或“不适用的结构操作”、AlgorithmSource与依赖。ID都是对象标识，不是显示名称。

| 步骤 | Input IDs 与依赖 | RuleSpec 与 AlgorithmSource | 输出及 CalculationTrace 重点 |
|---|---|---|---|
| 1 Create Arrival | ProjectId、ProcedureContextId、NavigationContextId、RC | 无数值规则；Application.CreateArrival | ProcedureId/version；记录范围与RC |
| 2 Add procedure fixes | ProcedureId、FixIds/versions | Domain.FixReference；无宽度规则 | ProcedureFixIds/roles；记录位置/FrameId |
| 3 Create straight construction | ProcedureId、ProcedureFixIds | Native.StraightValidation | ConstructionId；声明共线同向，不创建转弯 |
| 4 Build TrackFragment | ConstructionId、端点FixIds | PureGeometry.StraightFragment | FragmentIds/versions；长度/方向/源Fix |
| 5 Assemble NominalTrack | 顺序FragmentIds | PureGeometry.ContinuousTrack | TrackId/version；连续性/全局里程映射 |
| 6 Resolve RNAV1 width | NavigationContext、TrackId、ARP、RC | RS-PBN-WIDTH-001；PlannedNative | WidthPolicyIds；外内XTT/ATT/BV/H |
| 7 Find single ARP30 intersection | TrackId、ARPId、FrameId | RS-ARR-30NM-001；PureGeometry | IntersectionId；全部根/符号/去重依据 |
| 8 Build width transition | IntersectionId、WidthPolicyIds | RS-ARR-30NM-001；PlannedNative | TransitionId；Hc、s0/sc/s1、无ATT移位 |
| 9 Build Primary Secondary | TrackId、TransitionId | WIDTH＋ARR30＋OBS；PlannedNative | ProtectionId/version；H/P/Ws profile与边界 |
| 10 Load obstacle dataset | DatasetId/version、Datum/Accuracy/Coverage | DatasetValidation；无MOC数值默认 | DatasetSnapshotId；原始XYZ与声明 |
| 11 Evaluate obstacles | ProtectionId、AcceptedGeometryId、DatasetId、Procedure/Environment、RC | MOC＋OBS；PlannedNative | EvaluationId/version；分类/余度/候选/控制集 |
| 12 Generate GeometryOutput | ProtectionId、EvaluationId及版本 | Domain.GeometryOutputMapper | OutputId；各实体角色和源对象绑定 |
| 13 Fake CAD preview | GeometryOutputId | FakeCadPort | PreviewId；临时快照，不替换Accepted |
| 14 Accept manual modification simulation | PreviewId、ComputedGeometryId、旧AcceptedGeometryId | Domain.AcceptGeometry；语义映射校验 | 新AcceptedGeometryId/version；区分计算/接受快照 |
| 15 Save | Procedure、构造、RC、几何/评价/依赖版本 | InMemoryProjectStore | ProjectSnapshotId；同进程存储，非磁盘持久化 |
| 16 Reopen | ProjectSnapshotId | InMemoryProjectStore.DeepSnapshot | 保持所有ID/版本/状态/追踪；不自动重算 |
| 17 Re-evaluate | 重开对象、显式命令、当前AcceptedGeometry及Dataset | MOC＋OBS；PlannedNative | 新EvaluationId；核对版本，清除已处理Dirty |

步骤11在首次接受前使用与当前计算profile绑定的评价快照；步骤14接受后版本不同则先使评价失效。不得把初次计算评价继续挂到新版人工几何上。Fake预览及手改模拟不调用真实CAD。

## 人工修改与接受
LastComputedGeometry和AcceptedGeometry为独立快照。I1-A可以接受未变更的计算成果，并模拟图形改动产生新版本。改变显示样式可保持评价语义；改变空间形状必须声明保留的Track/Profile映射并验证符合本规则，否则返回GeometryMappingMissing、保持NeedsReview、禁止输出有效MOCA。任意缩窄人工边界不因“Accept”自动获得规范合规状态。原始计算成果仍可查看。

## 最小依赖表
所有箭头表示标记Dirty的有向依赖闭包，表中“只”针对计算节点；结果展示/快照的stale标识随版本状态反映，不触发计算。

| 变化源 | 直接失效 | 必须传播的计算节点 | 不自动执行 |
|---|---|---|---|
| ARP位置 | Intersection、TrackPosition阶段解析 | WidthTransition → Protection → Evaluation | 不改NominalTrack/障碍物；不重建 |
| Fix位置 | 依赖该Fix的TrackFragment | NominalTrack → Intersection → WidthTransition → Protection → Evaluation | 校验后可能变不支持，不生成猜测结果 |
| RNAV1 NavigationContext | WidthPolicy | WidthTransition → Protection → Evaluation | Intersection几何不变；DME输入不得沿用旧宽度 |
| ObstacleDataset/Datum/Accuracy/Coverage | Evaluation | Evaluation only | 不重建轨迹、求交、宽度或保护 |
| AcceptedGeometry空间版本 | Evaluation | Evaluation only，若语义失配则NeedsReview | 不覆盖LastComputedGeometry |
| RuleContext/RuleSpec revision | 引用变更条款的政策或几何节点 | 依其边向下传播 | 不全程序默认重算 |
| MocEnvironment/普通条件确认 | MocPolicy/Evaluation | Evaluation | 不凭空重建保护边界 |

Intersection依赖NominalTrack、ARP；WidthTransition依赖Intersection、WidthPolicy、直线支持域；Protection依赖NominalTrack、WidthTransition；Evaluation依赖Protection语义、实际AcceptedGeometry版本、ObstacleDataset、MocPolicy。ARP导致阶段变化时解析状态失效，WidthPolicy表常量不变。

## 计划与状态约束
AnalyzeChange只产生ImpactAnalysis（源ID、旧/新版本、直接/传递依赖、原因、NeedsReview）与RebuildPlan（按拓扑排序、前置版本、预期输入、RequiresExplicitExecution=true），不调用几何/评价函数、不增加计算输出版本。用户明确执行后先验证适用范围，再重建受影响节点；若版本已变化返回PlanStale，重新分析。重开保留Dirty/NeedsReview，不能以加载旧结果消除失效。

非自动重算测试必须断言：变更后计算调用数0、输出版本未变、AcceptedGeometry未覆盖；明确执行计划后才产生新版本。环境未就绪不影响此规格设计，但阻止宣称I1-A已经执行通过。
