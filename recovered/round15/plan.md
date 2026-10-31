# Round 15 执行计划

本轮按用户附件执行最终静态恢复总装。沿用 documentation-and-adrs 的证据引用和历史记录保留方法，仅写 `recovered/round15/` 与 `recovered/final-static-baseline/`。

1. 只读对照 Round 14 冻结清单及输出清单，再保存新的全工作区冻结快照。已完成：7653 个历史哈希核对，0 差异；新快照 7654 文件。Round 14 清单的自哈希不能自洽，单独披露，其实际文件哈希已进入本轮快照。
2. 读取各模块最新 closure，区分历史轮次状态与 FinalStaticStatus；按记录重新统计，不预设数量。
3. 对照后续模块证据纠正 Round 10 总表中的过时或冲突描述；更正只写入本轮，保留冲突与来源索引。
4. 汇总公开功能、架构、数据模型、共享/复制关系、CAD、metadata、障碍物、衔接、人工交互、Help/UI/Code、代码资产与证据等级。
5. 汇总 gap inventory：分离同构建业务静态缺口、构建调度缺失、E4、Designer/宿主与规范依据；不恢复新 MethodDef。
6. 编写技术总报告、负责人摘要、可信构建比较计划及 API23.1 E4 计划。全模块 E4 业务验证仍未完成。
7. 核验所有交付物、CSV结构、15模块/状态、证据路径、链接与哈希，扫描全工作区新增文件边界，逐文件复核冻结快照。旧文件变更立即 INTEGRITY FAILURE。
8. 验收通过才写 FINAL STATIC RECONSTRUCTION BASELINE COMPLETE，生成无自哈希递归的输出清单；本轮结束后停止，等待用户选择。

禁止执行目标 DLL、NETLOAD、AutoCAD、获取新 DLL、修正规范或旧成果、补接 orphan UI、设计新系统。内部审计脚本只负责生成与验证本轮文档。
