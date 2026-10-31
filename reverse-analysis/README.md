# WsTools 静态恢复阶段交付

日期：2026-10-25。范围：材料基线、静态方法恢复、入口/事件/调用索引，以及传统离场首批可核实数据流。**不是完整业务逆向完成报告，也不是可用于实际程序设计的验证软件。**

## 已完成和证据

- 131 个原件（163,071,568 bytes）建立原路径/SHA-256/独立快照；二次核验原件及快照共 262 项，零变更。见 `00_manifest/hashes.csv`、`original-recheck.json`。
- 确认规范基线 AC-97-FS-005、民航规〔2020〕12号，PDF 656 页；不据此反向修正代码。
- 原始程序集 212 TypeDef、2,725 MethodDef、2,336 Field、34 CAD 命令。静态处理后 2,681 MethodDef；2,229 个非短桩方法可解码，387 个短体/桩候选，65 个无方法体，零 IL 解析失败。短体可能是正常常量辅助函数，不是 387 个业务算法失败；这些数值不是业务恢复率。
- 静态恢复 2,107 条字符串、388 个布尔值；2,107 条字符串重新加密均与原始密文完全一致。没有执行目标 DLL/EXE，也没有动态证据。
- 建立 999 个控件 Name 赋值、544 条直接事件绑定候选、47,867 个 IL 调用/构造/函数指针位置、5,229 个工具 token 映射。最初 561 条文本候选误含算术 `+=`；已按 IL `add_*` 名称约束修正。候选索引仍非完整运行调用图。
- SQLite 完整性检查为 ok，PartA 275 行、PartB 687,775 行；完整 schema/CSV 留存。4 个压缩包已清点并独立解包。分析工具和解包文件合计 1,010 个文件已登记 hash。

## 阅读入口

| 内容 | 文件 |
|---|---|
| 原件/工具/校验 | `00_manifest/evidence_index.md`、`validation-summary.json` |
| 恢复路径和限制 | `02_deobfuscated/README.md`、`03_recovered-src/README.md` |
| UI 和调用 | `04_type-map/forms.md`、`controls-events.md`、`05_callgraph/` |
| 离场初步代码事实 | `07_procedure-logic/conventional-departure.md` |
| 人工 CAD 依赖 | `09_cad-interactions/manual-picks.md` |
| OAS 查询事实 | `06_algorithms/oas.md` |
| 规范映射状态 | `10_spec-mapping/code-to-spec-matrix.md` |
| 缺口和文档差异 | `12_unknowns/` |

## 未完成边界

五条基础链审计包目前保存入口、控件、事件、入/出调用和源码定位，**均未达到业务链验收标准**。十类保护区衔接、完整 XData schema、导航方式分支、障碍物计算区划尚需深入。DWG 块/层/属性未提取；未建立可控 CAD 运行环境；缺失 AutoCAD 引用会影响反编译类型推断。PANS-OAS 与当前数据库的模型对应、历史模板与当前代码数值一致性尚未证明。

后续直接按 PLAN 推进传统离场的业务类和几何函数，贯通共享模块；正常检查点无需再次确认。本交付没有修改或重构 WsTools，没有开发替代软件。文档记录技能用于保留证据边界、恢复决策与未完成项。
