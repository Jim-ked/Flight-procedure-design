# I1-A Readiness

2026-10-31 I0.6：**I1-A RULE READY**。四项RuleSpec设计均IMPLEMENTABLE，受控基线1.3与导出规格已同步。

I1-A implementation：NOT IMPLEMENTED。SDK/environment validation：仍依I0.5-R报告BLOCKED；本轮未继续修复环境。规则就绪不等于运行测试通过。现有Catalog代码未同步本轮文档状态。

首个切片仅FixedWing A至E、BasicGNSS RNAV1 Arrival、同向共线直线、一次外→内ARP30穿越及完整单次过渡、普通条件静态合成障碍物、FakeCadPort和InMemoryProjectStore。禁止自动重算；详细流程和依赖见I1-A Dependency Matrix.md，编码预言见I1-A Test Specification.md。

A9保留BehaviorLocked；Native规范模型与Legacy差异已单独设计。ODQ-ARR-001持续BLOCKED；Fly-by/Fly-over/RF/DME Arc/Holding、转弯耦合、真实CAD/存储等仍不支持。I1-B仍需B1 BehaviorLocked及RuleMap完成。
