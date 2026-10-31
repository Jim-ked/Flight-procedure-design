# Round 12 — A3 Fix Tolerance 最终静态收口计划

Round 1–11、既有 A3 文件、原始 DLL/数据库/配置/帮助和 Round 10 均冻结。本轮仅新增 `recovered/A3-FixTolerance/` final 报告与 `recovered/round12/` 审计产物；不执行 AutoCAD、NETLOAD 或未知二进制，不修改 Round 1 closure。

1. [x] 冻结：保存本轮开始时工作区哈希，读取 Round 10 A3 rows、Round 1 closure 与 A3 evidence。
2. [x] 入口：核对 A3 Form、事件、IL、CAD helper、三类公开路径和可达调用边。
3. [x] 业务：定性单台/单方向、设施矩阵、VOR/NDB/ILS 精度角、DME 三弧、KK、顶空和 track 辅助。
4. [x] 系统：核对 A3→A7/A6/A10/A4 直接 reader、metadata、CAD writer、Help/UI/Code 与 Designer/config 影响。
5. [x] 验证：只补静态 fixtures 与有限 spot-check 记录，不重跑 Round 1 数值测试，不虚称 E3/E4。
6. [x] 收口：20 问、residual 分类、规范基线、冻结文件完整性、输出清单；状态为 COMPLETE_STATIC 或保留 PARTIAL_STATIC。

证据等级：E0 原身份/元数据；E1 处理 IL/反编译；E2 事件/字段/调用恢复；E3 既有恢复代码验证（本轮不重跑）；E4 原宿主（本轮禁止）；N 规范及上下文解释。
