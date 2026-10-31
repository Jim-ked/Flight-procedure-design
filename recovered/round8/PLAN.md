# Round 8 — A5 Precision Approach / OAS 差异恢复

## 边界与证据

仅写 `recovered/A5-PrecisionApproach/` 与 `recovered/round8/`。Round 1–7、原 DLL/数据库/config/DWG/帮助/压缩包只读。规范基线 AC-97-FS-005（民航规〔2020〕12号）；先恢复实现再映射，差异标记“实现依据待确认”。不执行目标 DLL、AutoCAD 或 WsOasPara.exe，不开发新软件，不补接 orphan evaluator。

E0=原程序集身份/元数据；E1=处理反编译；E2=IL/调用/字段恢复；E3=独立恢复源码测试；E4=原运行（本轮无）；N=规范推断。保护桩不称原始明文公式。

## 顺序、验收与验证

1. [x] 基线：记录全部既有 recovered/WsTools-master/reverse-analysis/doc 文件路径、大小、SHA256；读取 Round 7 指定报告。验证：基线不覆盖，最终逐文件复核。
2. [x] 事件/类/调用：建立 A5 控件与事件、MethodDef/RVA、原/处理 IL、字段、条件、incoming、调用图和 CAD API 索引。验证：解析 MethodSpec，检查 P41B 及评价/最低标准可达性。
3. [x] 参数/OAS：A5/B4 loader 身份、SQL/key/decoder/修正、CAT I/II/AUTO、W/W*、共享五面与 CAD writer。验证：真实只读数据库样本、参数/曲面/共享身份 fixtures。
4. [x] 模式差异：GP INOP、PAOAS L/R、PA-FAF、PA-FAP；追踪 IF、FafFix、高度/RDH/容差、镜像与截断。验证：六模式 dispatch、点列几何、不同输入和退化值。
5. [x] HL/文件/交互：HL/最低标准、TXT/config、XData、WsOasPara 直接调用证据；逐项记录人工对象、消费者与自动推导可能。验证：序列化往返与事件入口静态断言。
6. [x] 收口：模式矩阵、跨模块对照、规范映射、26问答、剩余公开功能排序、测试分层、未恢复项与完整性审计。验证：全部文件/链接/fixture/hash 和日志；按用户条件给出 ACCEPTED 或 PARTIALLY ACCEPTED，之后停止。

步骤 1–3 与 4–5 后仅内部检查，正常阶段完成自动继续。仅遇不可控未知二进制执行、原件修改、关键歧义无法静态消除或关键材料缺失再暂停。

## 当前状态

六阶段完成，Round 8: **PARTIALLY ACCEPTED (static recovery)**。DB关系/六模式/W*/FAF/FAP/CAD/文件已静态闭合；P41B/P429完整而不可达，按用户条件保留部分验收。独立源码2980条与静态32条通过；本轮无E4。完整性结论见integrity-report.json，交付与26问见closure.md。之后停止，不自动进入新模块。
