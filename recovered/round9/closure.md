# Round 9 Closure — A4 导航设备保护区

**Round 9: ACCEPTED (static recovery)**，2026-10-28。

本轮只修改`recovered/A4-NavAidProtection/`和`recovered/round9/`。Round1–8和原件冻结。结论针对静态恢复与独立源码验证，不表示原AutoCAD运行验证或规范全面批准。

## 20问逐项回答

### 1. A4实际支持哪些设施？

只有VOR、NDB。LOC/DME/VOR-DME/NDB-DME等在A4未发现实现；见设施矩阵。

### 2. VOR真实默认宽度是什么？

小档初始外半宽1NM=1852m；另有大档2NM=3704m。默认选小档。

### 3. VOR真实扩张角是什么？

P2F7设置7.8°，P2F9读取最终角度文本参与tan计算。

### 4. NDB真实默认宽度是什么？

切NDB后小档1.25NM=2315m，大档2.5NM=4630m；设施事件不强制改变所选档位。

### 5. NDB真实扩张角是什么？

P2F8设置10.3°；不是A3的6.9°或A6的6.5°。

### 6. 用户修改角度/宽度时真实优先级如何？

设施事件写标签和角度→config/状态可能影响最终Text→Draw读取。角度TextBox Enabled=false、宽度为radio，普通UI不支持自由编辑；注入自定义测试仅验证reader。两个设施handler不查Checked，最后事件覆盖文本。

### 7. 起始宽度是总宽还是半宽？

所选值×1852后为每侧外半宽w；内线w/2，双侧总宽2w。

### 8. 左右边界如何构造？

以S→E左法向n：外端S±wn、E±(w+Ltanα)n；内端S±wn/2、E±(w+Ltanα)n/2。每侧外折线[S,O0,O1]和内线[I0,I1]。15°时末端换交点。

### 9. 中心线如何构造？

列表最先加入[S,E]，单独2D Polyline；长度由拾点XY距离决定，与其他线共Group。

### 10. 15°线到底是什么？

从E构造相对反向航迹的15°无限直线，与该侧内外边求交，替换末端并画[E,O*]；通常向窄端方向截接。不只是叠加显示线，也不是自动转弯/风螺旋保护区。

### 11. 是否生成主区/副区？

确有外边与半宽分界几何，对应主区总50%/各副区25%；无命名区对象、闭合面、填充或MOC。不能写成毫无区划证据。

### 12. 是否存在障碍物评价？

没有A4评价UI/可达或孤立完整评价器证据，无MOC/OCA/障碍物筛选。

### 13. 最终创建哪些CAD实体？

2D Polyline及一个Group；默认5条，双侧带15°为7条。无独立Line/Arc/Text；未显式设置Closed/Layer/Color/Linetype。

### 14. 写哪些XData？

不写。P2F9给P087空metadata，P089条件不满足；无WsObject/Kind/设施/宽度/角度/Form state。

### 15. A4与A3真正共享什么？

P113拾点、P087/P089 writer、P809/P80A点原语和config基础。无A3设施精度/DME/KK/顶空业务调用；角度属不同概念。

### 16. A4与A6真正共享什么？

BaseTurn与A4确有P809/P80A、P7E8点角直线等直接同MethodDef证据，选定窗口入口还有P113/P125。没有将P7E7/P7ED推作BaseTurn共享；5.2/6.5与7.8/10.3为不同方法/业务常数。

### 17. A4是否调用A9主副区算法？

不调用P32F/P330/P331。共享P7E7等线原语，不共享评价逻辑或宽度/实体ID数据传递。

### 18. 哪些行为与2020规范不同？

无阶段/距离/最大宽度/FAF-MAPt裁段校验、MOC、自动转弯衔接条件；config可以覆盖角度且不强制规定值。固定默认角/小档半宽/分界比例匹配对应条文，大档仅匹配特定IF候选。

### 19. 哪些参数只是UI默认值，不是硬编码规则？

7.8/10.3与两档宽度由设施setter赋Text，Draw读取最终文本；它们是UI预设而非Draw再次强制的常量。15°、1852和0.5则为计算内固定常数。

### 20. A4最终应定性为什么？

导航设施保护边界几何构造工具，含半宽分界及15°局部截接；不是障碍物评价器。

## 验收矩阵

|要求|结果|审计入口|
|---|---|---|
|facility branches complete|通过：VOR/NDB完整，其他设施无证据|[事件](../A4-NavAidProtection/event-map.md)、[设施](../A4-NavAidProtection/facility-matrix.csv)|
|geometry complete|通过：两点、两宽度、内外分界、双侧、中心线|[边界](../A4-NavAidProtection/boundary-geometry.md)、[输入](../A4-NavAidProtection/input-frame.md)|
|15° semantic resolved|通过：E为起点、求交/替换末端；适用场景非自动判定|[15°](../A4-NavAidProtection/15-degree-line.md)、[端点](fixtures/15-degree-endpoints.csv)|
|CAD writer complete|通过：Polyline顺序、单Group、空metadata和默认属性范围|[writer](../A4-NavAidProtection/cad-output-map.md)、[XData](../A4-NavAidProtection/xdata-schema.md)|
|event reachability resolved|通过：五事件完整身份、原/处理IL、MethodSpec、全局incoming|[身份](../A4-NavAidProtection/evidence/event-identities.csv)、[可达](../A4-NavAidProtection/evidence/event-reachability.json)|
|cross-module resolved|通过：逐MethodDef限定共用，无A3/A6/A9业务调用|[A3](a3-a4-comparison.csv)、[A6](a6-a4-comparison.csv)、[A9](a9-a4-comparison.csv)|
|fixtures pass|通过：5550条E3断言+30项静态核验，八层分别报告|[验证](../A4-NavAidProtection/verification.md)、[索引](fixture-index.json)|
|2020映射|完成：匹配/缺失/不同/实现依据待确认分别记录|[规范](../A4-NavAidProtection/standard-mapping.md)|
|冻结与产物完整性|由审计报告逐文件hash、链接和源输入复核|[integrity](integrity-report.json)、[manifest](output-manifest.json)|

## 边界与后续

[未实测事项](../A4-NavAidProtection/unrecovered.md)：E4原插件运行、宿主默认/空Group/异常事务、完整WinForms配置时序均未实测。重要设施/几何/15°/writer静态链已闭合；缺少本来不存在的评价器不作为静态断链。

本轮到此停止。**System Coverage Review留待单独后续任务，不自动执行，不进入新模块。**
