# Round 4 A6 执行计划

2026-10-27。仅新增 A6-Template 与 round4 目录；Round 1–3 全部文件以 frozen-inputs.json 固定 SHA-256。原始材料同表只读核对。未加载目标程序集，不操作 CAD。

1. 事件和证据：FormTemplate 17 个绑定事件、嵌入 turn control、业务构造器原/处理 token、RVA、IL、直接调用；验收逐事件覆盖所有控件，未绑定项明确标记。
2. Holding/Racetrack：分别追踪普通、XE、YE、全向，保存公式、分支、点列及 writer；验收 time/wind/left-right fixtures，并优先明确 BaseTurn 的共享 spiral 关系。
3. Base Turn：time/distance、φ、VOR/NDB、所有控制点、primary/secondary、spiral/iteration 与 CAD 写入；验收分支 fixture 与可执行恢复代码。
4. 45/180 与 80/260：独立恢复时间/角度/风保护/nominal 及 writer；验收左右、风零/非零、时间变化。
5. Envelope：实体筛选、顶点/bulge、真实点列算法、输出/删除/metadata；验收 nested/overlap/crossing、输入顺序、空/单/非Polyline。
6. 汇总 25 问、共享 MethodDef、CAD 人工交互和规范差异、恢复缺口；复核所有冻结文件 hash。

检查点内部继续推进。编译新纯恢复程序集只用独立目录，既有 Round 3 编译阻塞不作为本轮数值验证结论。不得按规范补源码，不创建统一 TemplateEngine。任何缺口均保持 PARTIALLY ACCEPTED。

## 收口检查

六阶段静态恢复已完成，逐项门槛、25问与外部宿主未验证项见closure.md。最终完整性以integrity-report.json为准。保留原始占位IL、处理后完整IL及签名，明确不把处理后主体称为原文件明文代码。新增准确writer映射仅存本轮，不改冻结表。测试62个JSON、56,545项断言；验收状态ACCEPTED (static recovery)，不延伸为原软件动态/规范合规验收。
