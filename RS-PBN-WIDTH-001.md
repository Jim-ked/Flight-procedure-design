# RNAV1 GNSS 进场基础保护宽度

## RuleSpecId
RS-PBN-WIDTH-001；修订 I0.6 r1；2026-10-31。

## Title
固定翼 A 至 E 类 GNSS RNAV1 Arrival 稳态 XTT ATT 与保护宽度。

## Status
IMPLEMENTABLE。YES。仅对本规则声明的 SupportedNavigationContext 有效；不表示生产实现或 SDK 验证完成。

## NormativeSource
AC-97-FS-005R1（2021-10-13）：III-1-1 表 III-1-1-3、1.5.1.1 至 1.5.2（PDF485／印刷469页）；III-1-2 2.2.2、2.2.3（PDF490／474页）、表 III-1-2-17／18（PDF494／478页）；III-3-2 2.1.1.2、2.1.4（PDF581／565页）。原文表格已与页面图像核对。

## Applicability
SupportedNavigationContext = FixedWing + AircraftCategory A/B/C/D/E + ProcedureType Arrival + NavigationSpecification RNAV1 + SensorSet {BasicGNSS} + TrackGuidance true。过程内传感器与导航规范不变。RNAV2、H类、DME/DME、混合传感器及其他导航类型不在 I1-A 内。III-1-1 1.5.1.2 要求多传感器分别计算并选控制值，因此不得把 GNSS 数值默认赋给 DME/DME。

## Inputs
navigation：类别、RNAV1、SensorSet、导航上下文 ID／版本；position：轨迹里程、到 ARP 距离及单位、FrameId；context：RuleContextId、STD-R1 版本与散列、RuleSpec 修订、MetricFrame/PrecisionPolicy ID。所有长度为有限量；距离非负。位置来自实际连续 NominalTrack，不以最近 Fix 代替。

## DerivedInputs
阶段 OutsideOrAt30 或 Inside30。NM 为规则计算单位，1 NM = 1852 m；30 NM = 55560 m，不用规范中的近似 56 km 替换。BV、XTT、ATT、H 为下表推导值；H 表示中心线至整体外边界的半宽，绝不是总宽。

| 稳态区域 | XTT NM | ATT NM | BV NM | H NM |
|---|---|---|---|---|
| r > 30 NM | 2 | 1.6 | 2 | 5 |
| r = 30 NM | 2 | 1.6 | 2 | 5 |
| r < 30 NM | 1 | 0.8 | 1 | 2.5 |

恰好 30 NM：BV 表明示“大于或等于”；GNSS XTT 表使用 >／< 而未列等号。本受控设计采用外侧较大 XTT／ATT 作为稳态查询的等号归属（设计决策 DD-I06-002），不冒充表格直接规定。过渡函数在交点取 Hc=3.5 NM，不能用本表的稳态 H=5 NM 覆盖。

## Preconditions
RuleContext 版本完整，导航上下文受支持；坐标已由上游提供为声明且适合本验证范围的同一米制正交平面。I1-A 不实现经纬度投影或地球测地线规则。输入若是未声明坐标或直接经纬度，返回 InvalidInput。真实地理适用性与投影误差须另行验证；本切片使用受控合成米制数据。

## Algorithm / Construction Rule
1. 先校验 SupportedNavigationContext，再按距离判定稳态区域。
2. 从上表解析 XTT 和 BV；ATT = 0.8 × XTT；H = 1.5 × XTT + BV。
3. 主区半宽 P = H/2；每侧副区宽 Ws = H-P = H/2；整体总宽 2H，主区总宽 H。
4. 返回稳态 WidthPolicy；实际保护区 H(s) 必须由 RS-ARR-30NM-001 构造。不得在交点强制阶跃。
5. 规范 NM 表为计算主值，米值按精确 1852 转换：外侧 XTT3704、ATT2963.2、H9260；内侧 XTT1852、ATT1481.6、H4630。规范米表 ATT2963／1482 是显示取整，计算不得在两个取整表间往返。

## Outputs
ProtectionWidthResult：Resolution、WidthPolicyId/version、Stage、XTT、ATT、BV、OverallHalfWidth H、PrimaryHalfWidth P、SecondaryWidthPerSide Ws、CanonicalUnit、RuleSpecId/revision、SourceClauses、CalculationTrace。只有 Resolved 才有数值；其他分支不携带可被误用的默认宽度。

## BoundaryConditions
距离等号处理见 DD-I06-002；主副区边界归属见 RS-OBS-PRIMARYSECONDARY-001。数值误差无法确定圆内外时返回 NumericAmbiguity，不用宽容阈值悄悄缩窄保护区。表值不代表 ARP30 过渡处瞬时边界。

## Exceptions
不支持的 SensorSet → RuleResolutionRequired/NAV-CONTEXT-UNSUPPORTED。未知传感器不降级为 GNSS。导航上下文中途改变 → UnsupportedScenario/NAV-CONTEXT-CHANGES。非有限量／缺单位／缺 FrameId → InvalidInput。

## DependencyInputs
NavigationContext、AircraftCategory、ARP/TrackPosition、MetricFrame、PrecisionPolicy、RuleContext、RuleSpec revision。宽度表策略本身不依赖障碍物；位置的阶段解析依赖 ARP 与 NominalTrack。

## InvalidationRules
导航上下文或规则修订改变：WidthPolicy → WidthTransition → Protection → Evaluation 失效。ARP／Fix 改变：位置阶段重新解析，并传播几何依赖；不改变表中常量策略。仅标记 Dirty 并产生 ImpactAnalysis/RebuildPlan，禁止自动重算。

## Diagnostics
WIDTH-RESOLVED（含阶段、源表与单位）；NAV-CONTEXT-UNSUPPORTED；NAV-CONTEXT-CHANGES；FRAME-MISSING；INPUT-NONFINITE；NUMERIC-AMBIGUITY；RULE-CONTEXT-MISMATCH。每条带 InputId/version、RuleSpecId、条款与原因。

## TestCases
编码预言见 I1-A Test Specification.md 的 W01 至 W08；包括外／内／等于30、DME/DME与混合传感器拒绝、单位换算与 H/P/Ws 语义、过程内上下文改变。

## OpenQuestions
无阻塞本 SupportedNavigationContext 的问题。DME/DME 需按 III-1-3 的台站覆盖、DTT、几何交叉角与容差另建 RuleSpec；不能复用本表。真实投影／测地线适用性、非零水平不确定性与发布精度不属于本验证切片。
