# A7 Conventional Departure — Round 11 最终静态收口
判定：**A7: COMPLETE_STATIC**。已索引构建中的三套业务算法、公开事件链、障碍物评价和CAD写出关系已恢复到可审计程度。原宿主E4未执行，历史Round 2状态不改。

## 20问结论
1. 独立直线离场：无独立构造/边界/evaluator，直线边属于三模式，二检属于P203。
2. 电台上空转弯：无A7实现证据。
3. 有/无航迹引导：无guided/unguided/track输入或分支。
4. VOR/NDB/DME：无A7直接reader/caller。
5. TP：不自动从A2读取，P287 GetPoint后为距离/高度。
6. KK′：不自动从A3读取，P28A GetPoint后为距离。
7. C：不自动读取，P28B GetPoint后为距离。
8. WsCalcuLine：索引闭包无A7 reader。
9. A3 XData/Group：跑道/TP/KK/C不读；共享障碍物名称解析器的EntityFrame不等同KK语义。
10. stages：定高S-K/K-L/可选S-E；定点S-TP/E-TP/TP-L/L-D；全向S-D/D-K/K-F/圆载体。
11. 衔接：镜像边界、共享顶点、线载体和圆已代码化；无IntersectWith/Offset/切线/包络/裁剪/删除重建。
12. Spiral86/88/P7AD：238个可达MethodDef不含它们。
13. P793：定高/定点实际读Altitude、TAS、Wind；Rate/Radius/WindRadius/Drift不用于A7边界/螺旋。
14. obstacle evaluators：P282/P28D/P291均由公开Click可达。
15. 二检：P203内部，由checkBoxSecChk传入，覆盖同一行。
16. Designer/config：主要影响完整WinForms/宿主运行，属RUNTIME_UI_ONLY/LOW_VALUE。
17. Help差异：ScreenData实际SelectAll Model DBPoint；入口帮助THR而代码DER；IAS/风为单位换算；button9/15无计算Click；button2只保存模板。
18. Round10 residual：三模式、evaluator、事件、CAD writer、跨窗口和负向候选均已补证；旧行不改。
19. E4剩余：原宿主加载、实体创建/删除、表格显示、原始配置/Designer运行。
20. COMPLETE_STATIC：是；剩余仅E4、低价值Designer/runtime UI、STANDARD_BASIS_UNRESOLVED。

## Residual
- STATIC_ALGORITHM_GAP：无公开断链，既有算法+本轮stage/connection索引关闭。
- EVENT_REACHABILITY_GAP：三模式CAD/evaluator/Screen/Mark直接绑定已确认；空/悬停按钮已定性。
- DESIGNER_CONFIG_GAP：完整运行重建仍缺，降级LOW_VALUE。
- MANUAL_CAD_DEPENDENCY：GetPoint和无布尔衔接为实际行为，保留。
- RUNTIME_E4_GAP：原宿主未执行，保留。
- STANDARD_BASIS_UNRESOLVED：15°、150、0.008、75、600、120、.1等常数未由AC-97-FS-005唯一解释，标记实现依据待确认。

证据等级：E0/E1原身份与IL；E2事件/字段/调用/闭包；旧E3为既有恢复源码验证，本轮不重跑105断言；E4未执行；规范为N。本轮到此停止，不自动进入A3。

新增审计文件：final-feature-matrix.csv、cross-window-input-proof.md、area-stage-map.csv、help-ui-code-final.csv；evidence-index.csv、static-tests.json、integrity-report.json、output-manifest.json、standard-basis-note.md。

