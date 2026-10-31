# Round 9 — A4 导航设备保护区

仅写 `recovered/A4-NavAidProtection/`、`recovered/round9/`。Round 1–8、原 DLL/DB/config/DWG/帮助/压缩包只读，记录原路径与 SHA256。不执行目标 DLL、AutoCAD 或未知 EXE；只编译运行独立恢复源码，复用冻结公共 helper，不重做公共算法。AC-97-FS-005 / 民航规〔2020〕12号只在代码恢复后映射；差异标“实现依据待确认”。

E0原身份/元数据，E1处理反编译，E2 IL/调用/字段恢复，E3独立源码验证，E4原运行（本轮无），N规范解释。正常阶段检查后自动继续，不等待重新确认。

1. [x] 基线与前置：hash全部既有四材料树，读取A3/A9/A6及公共几何。验证原件身份和已有证据，明确不扩大范围。
2. [x] 事件与输入：命令→Form→设施/宽度/角度/方向/开关，保存原/处理token、RVA、IL、事件图、调用图与人工交互。验证完整Form和直接业务helper及全局incoming。
3. [x] 几何与15°：恢复左右、起终点、内外边、中心线及15°交点，识别实际区划与评价缺口。独立源码保留原分支和退化值，按IL复核，不按UI名称推算法。
4. [x] CAD及关系：实体顺序/Group/metadata/config；逐MethodDef比较A3/A6/A9，建立连接/API/字段/分支索引。检查已有图元是否参与选择/裁剪/重建。
5. [x] 验证及规范：VOR/NDB两宽度、左右/双侧、角度、方向、退化及15°端点fixtures；formula/geometry/dispatch/CAD/serialization/reachability/cross-module/degenerate分层。代码事实闭合后映射2020规范。
6. [x] 收口：指定报告、20问、验收矩阵、未恢复项、链接及hash审计。无重要断链才ACCEPTED (static recovery)，否则PARTIALLY ACCEPTED；之后停止。System Coverage Review留待独立后续任务，不在本轮自动执行。

内部检查点：步骤1–3后检查输入/控制流/IL一致；步骤4–5后检查输出顺序、关系与测试分层。仅不可控二进制执行、原件修改、无法静态判定的重大歧义或关键缺件才暂停。
