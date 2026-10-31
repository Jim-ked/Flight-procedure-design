# 单次 ARP 30 NM 进场宽度过渡

## RuleSpecId
RS-ARR-30NM-001；修订 I0.6 r1；2026-10-31。

## Title
GNSS RNAV1 直线连续标称航迹单次由外向内穿越的 30 度收缩。

## Status
IMPLEMENTABLE。YES。仅限单次有效 outside→inside 穿越，且整段过渡位于同一方向的连续直线段内。

## NormativeSource
STD-R1 I-4-2 2.1.2.5.1／.2（PDF128／112页）；III-1-1 1.5.3（PDF485／469页）、1.5.4.1／.2（PDF486／470页）；III-3-2 2.1.1.2、2.1.4、2.2.1（PDF581至582／565至566页）及图 III-3-2-1／2（PDF585至586／569至570页）。图示明确标出变化点“内侧 XTT＋外侧 BV”。

I-4-2 2.1.2.5.1 写“III-1-2 2.5”，但本 R1 实际 GNSS XTT/ATT/半宽位于 2.2，且 III-3-2 2.1.4.1(b) 明确指向 2.2；保留原交叉引用问题记录，不把旧 PDF 或图中 8 NM／3 NM 数值用于本切片。

## Applicability
继承 RS-PBN-WIDTH-001；Straight only，全部片段共线同向且连续，无回退、无分支、无转弯；一次宽→窄过渡；交点在航迹内部，不在航迹首尾；过渡起终点均在受支持的直线范围。Turn interaction excluded from I1-A。转弯最晚位置冲突不在本规则内处理。

## Inputs
NominalTrackId/version、按序的 TrackFragmentIds/versions 及连续参数曲线；ARP Id/version 与同框架位置；Outside/Inside WidthPolicyIds（含 XTT/BV/H/ATT，必须来自同版 RS-PBN-WIDTH-001）；RuleContext（含 FrameId、PrecisionPolicy、源版本）。不接受任意手填5／2.5／30作为已解析政策。

## DerivedInputs
以航迹起点为 s=0，u 为单位前进向量，T(s)=S+s·u，0≤s≤L；a=ARP，R=30×1852 m。d(s)=|T(s)-a|。求全部有限区间根并按同一里程去重，判断根两侧 d(s)-R 的符号。outside→inside 是正→负的严格符号改变；切点不是有效穿越。

## Preconditions
L>0，连续性与共线同向已经校验；相邻片段端点误差在声明精度内；Circle/Track 同一米制正交框架。非共线的多个 Straight Fragment 也不支持（其间航向改变不能假装没有转弯）。精度导致符号无法判断时停止，不把双根强行合并为单次穿越。

## Algorithm / Construction Rule
1. 对实际连续 T(s) 求 |S+s·u-a|²=R²。令 b=u·(S-a)，c=|S-a|²-R²，则 s=-b±sqrt(b²-c)。这是直线与圆求交的解析推导，非规范常量。保留 [0,L] 根、合并共有片段端点同一根，并验证区间符号。
2. 无穿越（含纯切触）返回 UnsupportedScenario；两次或更多不同里程的有效穿越返回 RuleResolutionRequired/ODQ-ARR-001，不挑一个使用；inside→outside 不属于本切片。
3. 唯一正→负交点为 sc。外／内稳态 Hout=1.5Xout+BVout=5 NM，Hin=1.5Xin+BVin=2.5 NM。
4. 依 III-1-1 1.5.4.1，以变化点的混合宽度 Hc=1.5Xin+BVout=3.5 NM 为固定控制点。在两侧建立与标称航迹夹角30°的整体外边界直线，向前收缩；与 Hout／Hin 平行边界相交得到起终点。k=tan(30°)，s0=sc-(Hout-Hc)/k，s1=sc+(Hc-Hin)/k。
5. H(s)=Hout（s≤s0）；Hc-k(s-sc)（s0<s<s1）；Hin（s≥s1）。P(s)=H(s)/2，Ws(s)=H(s)/2。左右整体外边界 T(s)±H(s)n；主区边界 T(s)±P(s)n，n 为单位法向量。30°约束适用于整体外边界；主区边界取半宽，不能再独立套30°。
6. 上式是“混合固定点＋30°＋两侧稳态平台”三项规范控制的解析交线结果，不从示意图量取长度。过渡跨越30 NM控制点；近控制点的外侧属于过渡段，不能再强制 H=5。III 部分对 PBN 的补充／修订依 2.1.1.2 应与 I 部分一般 GNSS 叙述联合使用。I 部分“外侧使用航路宽度”确定外侧稳态平台，III 部分明确变化点与衔接构造。不得简化为从(sc,5)开始缩至2.5，也不得在sc阶跃。
7. ATT 仍输出为宽度政策的溯源值，但本阶段／XTT变化的固定点使用1.5.4，不使用1.5.3“指定航路点后一个ATT”的规则。sc不加0.8或1.6 NM偏移。仅新增不改变飞行阶段的共线Fix，结果应不变。
8. 若 s0<0、s1>L，或过渡与另一 WidthTransition 相交／接触，返回 UnsupportedScenario/TRANSITION-EXTENT-UNSUPPORTED；不截短、不外推、不把冲突交给布尔并集。交点在转弯片段或任何转弯邻域会涉及转弯保护的情况一律不支持。

数值预言（NM）：s0=sc-2.598076211353；s1=sc+1.732050807569；总收缩长度4.330127018922；H(sc)=3.5；P(sc)=Ws(sc)=1.75。

## Outputs
WidthTransitionResult：Resolution、IntersectionId/sc/point、CrossingDirection、s0/s1、Hout/Hc/Hin、Angle、ContinuousWidthProfile、Primary/Secondary profiles、InputVersions、RuleSpec/revision、SourceClauses、CalculationTrace（根、符号、构造点、单位与派生公式）。失败无 ProtectionGeometry。GeometryOutput 保留交点和控制线作为 AuxGeometry。

## BoundaryConditions
相切判别式为0且无符号变化 → TangencyNoCrossing。交点恰在两个共线片段的共享Fix上只计一次；交点在整个航迹首尾缺一侧邻域 → EndpointCrossingUnsupported。s0、sc、s1处连续且边界闭合；profile 分段在共有端点返回同一H。数值不能区分近切点／近双根 → NumericAmbiguity，不选择更窄结果。数值精度策略为软件决策，不能用于消除 ODQ。

## Exceptions
NoCrossing、TangencyNoCrossing、WrongCrossingDirection、EndpointCrossingUnsupported、TurnFragmentUnsupported、TransitionExtentUnsupported → UnsupportedScenario；MultipleCrossings → RuleResolutionRequired/ODQ-ARR-001；源政策或版本不匹配 → InvalidInput/WidthPolicyMismatch。

## DependencyInputs
ARP、全体相关 Fix/TrackFragment/NominalTrack、WidthPolicy、RuleContext、MetricFrame、PrecisionPolicy。另一个过渡的存在属于适用性输入，不能忽略。

## InvalidationRules
ARP／Fix／航迹几何变化使 Intersection → Transition → Protection → Evaluation 失效；导航政策变化使 Transition → Protection → Evaluation 失效；仅障碍物变化不使求交与过渡失效。只生成影响分析与重建计划。

## Diagnostics
ARP30-SINGLE-CROSSING；ARP30-TANGENCY；ARP30-NO-CROSSING；ARP30-MULTIPLE-CROSSINGS（ODQ-ARR-001）；ARP30-ENDPOINT；TRACK-TURN-UNSUPPORTED；TRANSITION-EXTENT-UNSUPPORTED；WIDTH-POLICY-MISMATCH；NUMERIC-AMBIGUITY。

## TestCases
见 T01至T14。必须断言混合控制半宽3.5、收缩起终点、无ATT平移、完整连续航迹求交、切触／无交／双交／转弯拒绝、共线分段不改变结果。

## OpenQuestions
ODQ-ARR-001 多次穿越仍 BLOCKED；不决定多交点选取、相邻过渡合并、往返阶段切换。转弯相互作用、过渡区外推与其他阶段的 ATT 规则另行闭合，不阻塞本文声明的直线单次穿越子集。R1 的2.5交叉引用定位记录保留，数值采用有明确引用的2.2与相应表。
