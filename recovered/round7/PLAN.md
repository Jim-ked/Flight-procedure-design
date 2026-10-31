# Round 7 — B4 PBN-ILS

日期2026-10-28；用户完整任务为附件d6ae9814-8b74-4624-bb2e-9f3ae3cc1a5e/已粘贴的文本.txt。只写recovered/B4-PbnIls与recovered/round7；Round1–6、原DLL/数据库/配置/帮助/压缩包只读。目标DLL和AutoCAD不运行；不回改B3，不扩A5完整业务，不设计新系统。

证据E0原件身份/元数据、E1处理反编译、E2 IL/字段/调用恢复、E3独立源码测试、E4原程序运行（本轮无）、N规范解释分别记录。当前规范为AC-97-FS-005/民航规〔2020〕12号，先恢复后对照，不修旧公式。

## 有序任务与验收

1. 建立不可覆盖hash基线，读取B3和公共层；核验原件路径/大小/hash。输出冻结清单、依赖读取记录。
2. 先恢复B4 Form全部事件、控件状态与全局入边；解析MethodSpec，判定Evaluate/CAD/KML/OAS导入可达性。输出事件/调用图、原/处理token/RVA与IL。
3. OAS参数→setter→plane/domain→评价链。完整W/W*/X/Y/Z、系数来源、数据库实际调用、HL/DH/FAF/FAP/SOC。输出字段/方程/决策表与独立恢复代码；核验每个consumer。
4. 转弯输入→容差/早晚点→实际几何→OAS衔接→主副区/障碍物。保存所有分支与15°语义；不套B5。输出点/边界/交点/包络/裁剪与计算过程，核验调用/IL。
5. POINT→Take(5)→parser→ID/评价/Mark/Highlight，恢复多候选优先/OCA/OCH与UI断链，不能补调度。输出真实限制作用层及第6障碍物样例。
6. CAD/KML/持久化完整追到最终writer。逐列表列实体/业务名、转换、style/高度模式、XData与人工选择目的。独立记录/格式fixture核验，不冒充CAD运行。
7. 分层测试formula/geometry/surface/obstacle/serialization/KML/event/degenerate/cross-module；用户要求不适用项也须以代码证据解释，不能补实现。编译只运行独立恢复代码，不加载目标DLL。
8. 代码完成后规范映射、33问、验收门槛、B4→A5复用与A5差异恢复建议。最终hash/链接/测试来源审计，停止，不开始A5。

各阶段为内部检查点，不等待正常完成确认。仅未知二进制、修改原件、无法由现有证据解决且改变方向的歧义、关键材料缺失时暂停。阶段文件逐段保存，不为凑验收改旧行为。

## 内部检查点收口（2026-10-28）

1–2完成：5013文件冻结基线；30事件；84核心/243索引方法，原/处理IL和MethodSpec解析；核实Evaluate隐藏提示体、KML隐藏空体，AppType设计器禁用。

3–4完成：共享五面与专用四面模型、DB解码/尺寸/RDH、HL/DH/SOC及同轴衔接全部按代码恢复；无任意TP/左右转/P793/Spiral86业务证据，保留缺口。

5–7完成：Take5/ID/Mark/Highlight、2D writer和XData、TXT/config链；60个方法机械恢复及PE InitLocals核验；27组真实DB行、1355项分层独立源码断言与18项静态断言通过。未运行目标DLL/AutoCAD。

8完成：19份报告、7份跨模块/输出对照CSV、33问逐条答复；全部写入本轮两目录。状态PARTIALLY ACCEPTED：orphan evaluator、任意定点转弯缺失、KML stub。最终冻结/链接/来源hash审计见integrity-report.json。收口后停止，不进入A5。
