# B5 PBN Departure 静态恢复

范围：Y55_PBN_Departure / FormPbnDepEvl，两个模式为指定高度转弯、定点转弯(FlyOver-DF)。Round 1–4冻结，原件只读；本轮没有加载目标 DLL、没有 AutoCAD 运行验证，没有进入 B3/B4/A5。

**收口状态：PARTIALLY ACCEPTED。** 两套几何、业务评价方法、事件与最终实体链已作静态恢复及独立测试；当前版本的三个评价入口均为隐藏提示体，无法恢复出实际存在的端到端评价调度。帮助所称 ATT=0 外边界相同也没有数值等价证明。详情见 ../round5/closure.md。

## 架构结论

B5 不是 A7 或 B2 的窗口包装。高度 `_008C_0091`、定点 `_008C_0093` 是独立业务类，复用 P793 转弯参数、Spiral86、point/line/list、frame、CAD writer 和障碍物公共工具；没有调用 A7 业务类，也没有直接 new B1 `_008C_0087` / B2 `_008C_0089`。存在复制/相似的算法结构，不等于已经证明整套数值等价。不能归结成“A7+B2嵌入调用”。

## 证据层级

|层级|本轮产物|范围|
|---|---|---|
|原始程序集直接证据|evidence/raw、method-index、signatures|身份、RVA、原始body hash；很多body是4字节保护占位|
|处理后IL/反编译|evidence/processed、*.source.txt|去混淆后行为；不是原 DLL 明文源码|
|IL/调用恢复|*.Recovered.cs、recovery-method-map、condition-expressions|提升IL locals，保留控制流；P5CB参数顺序按IL修正|
|恢复代码执行|../round5/fixtures、tests.log、test-inputs.json|独立算术/记录适配测试；无目标DLL oracle|
|原软件运行|无|不以恢复测试冒充L3|
|规范/上下文推断|standard-mapping、compare-*|基线AC-97-FS-005；未能证明历史来源者“实现依据待确认”|

## 阅读入口

- event-map.md / callgraph.md：绑定、未绑定、可达性与跨类调用。
- runway-frame.md / navigation-tolerance.md：输入、局部坐标、常数来源。
- altitude-turn.md / altitude-turn-geometry.md / flyover-df.md / straight-segment.md：完整业务阶段、控制点、后续航段。
- obstacle-evaluation.md / screen-data.md：两套公式、无法到达的入口、Take(5)、表格缺陷、Mark/高亮。
- protection-connections.md / cad-output-map.md / xdata-schema.md / cad-interactions.md：衔接和人工边界。
- compare-a7.md / compare-b1-b2.md / ../round5/*comparison.csv：同MethodDef与相似算法分开。
- evidence/method-index.csv、signatures.csv、field-flow.csv、branch-sites.csv、condition-expressions.csv：精确代码/IL定位与可审计中间成果。

恢复 Form 与 CAD 是记录适配器，不是可安装的插件或完整 UI；原公共 ObstacleData parser/Mark没有重写。业务类保留原标识及分支，编译时只读引用冻结 Round 4 的共享原语。
