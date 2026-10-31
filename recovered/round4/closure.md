# Round 4 收口 — A6 传统保护区模板

日期：2026-10-27。状态：**ACCEPTED (static recovery)**。仅表示下列静态恢复门槛满足，不表示规范合规、原插件数值等价或生产可用。原件、Round 1–3不改；未进入A5/B3/B4/B5。完整性结果见[integrity-report.json](integrity-report.json)，入口见[A6总览](../A6-Template/overview.md)。

## 六项验收门槛

|门槛|结果|可审计成果|
|---|---|---|
|四类模板事件链|通过：Form17绑定+公共控件8绑定；未绑定代码单列|event-map.md、events.csv、control-references.csv、callgraph.md|
|四类主要几何|通过：完整类、控制点、参数/条件、采样/衔接、镜像/放置|*.Recovered.cs、源摘录、296 MethodDef、body-provenance、method-field-flow|
|Envelope|通过：实体输入→点集转移→写入，退化异常保留|Envelope.Recovered.cs、envelope.md、输入输出fixtures|
|CAD writer|通过：nominal/protection/aux/XE/YE/全向/标注/Envelope、metadata和事务静态恢复|TemplateCad记录适配、cad-output-map、writers原/处理IL、adapter-method-map|
|共享关系|通过：P793、Spiral86/88、P7AD负证据、P7BE/P7AF/P7C2、低层helper、writer身份|shared-template-geometry.csv、sites.csv、shared-geometry.md|
|fixtures|通过：62个JSON产物；最终56,545项断言|tests.log、test-inputs.json、fixture-index.csv、test-history/|

不是56,545个独立业务用例。大量断言是同一fixture中的逐点镜像/有限性检查。编译仅有原有未使用字段CS0414警告，未把它作为源码缺失。

## 最终25问

|#|问题|恢复结论|
|---:|---|---|
|1|Holding/Racetrack是否同类？|同页只有Holding几何类和按钮；未找到独立Racetrack模式/handler。保留这个负证据，不编造第二套，也不宣称规范语义相同。|
|2|XE/YE真实公式？|普通显示：XE=2r+(t+15)v+(t+26+195/R)w；YE=11v cos20°+r(1+sin20°)+(t+15)v tan5°+(t+26+125/R)w。专用类则输出第二Spiral86的Point(π/2+δ).X / Point(δ).Y，中心和offset完整列于holding-xe-ye。|
|3|全向等待怎样生成？|普通模板fix容差四位置平移→本地点包络→0..80每10°位移模板+两个−70°旋转模板→再包络，外加9260法向终点线。|
|4|Holding风螺旋在哪？|普通6个Spiral88；专用XE/YE各2个Spiral86，全向通过普通+专用结果组合。|
|5|Base两模式？|time秒：L=vt，容差端距(t−5)(v−w)−zV / (t+21)(v+w)+zV；distance nm×1852，加入460+.0125L及5/11秒项。|
|6|φ？|TAS>315：−.116TAS/tmin；else −36/tmin，乘π/180，几何不舍入；显示正值舍入.01°。|
|7|VOR/NDB常数？|VOR tan50°/5.2°/15°；NDB tan40°/**6.5°**/25°，进入容差控制点/spiral中心。|
|8|primary怎样生成？|五个Spiral88，P7C2拼接角、δ与−φ比较、候选角比较、LineCarrier截距、time306°或distance P7BE尾参数，采样桥接并加原点。|
|9|secondary怎样生成？|同分支重新sample(extraOffset=width)+端部控制点，不做CAD Offset；保留端点赋值中的旧变量覆盖。|
|10|Base用哪些helper？|P7B7构造、P7B8采样/P7BA点、P7BE点迭代、P7C2两spiral角；无P7AD及P7BC/P7BD直接调用。|
|11|45时间控制哪段？|middleStraight=(60min−5−45/R)v，输入包含起始5秒和45°转弯用时；没有运行时计时事件状态机。|
|12|45和180怎样入几何？|5顶点nominal，bulge −tan(π/16)和1；圆心/端点用r及−45°方向构造。|
|13|45风怎样影响？|5w+(π/4)e、(t−5)w、(t+15)w，3个Spiral86和容差线/点，分段采样拼接。|
|14|80为什么没时间？|构造器只有turn；固定5v初直线、10v中间直线和r弧，不按UI出航时间计算。|
|15|80实际关键角？|10/−80名义位置，5/15、−75/−85容差，185/195 spiral heading，315尾角；80/260进入bulge；完整实际表达式见angle-index。|
|16|80两转弯怎样连接？|首弧终点→10v直线→按r的10°向量定第二中心；保护用自有P463迭代和P7AF角拼接。|
|17|Envelope输入类型？|不带filter的GetSelection；Polyline全部顶点，Line两端，其他忽略。|
|18|真实算法？|从minY/minX起点gift wrapping，orientation==2更新；缺共线最远点处理，可漏点/不终止。|
|19|IntersectWith/Union/Offset？|已绑定P367均无；未绑定P36A有Region BooleanOperation，不属于两个按钮链。|
|20|原模板保留？|是，未Erase输入实体。|
|21|Envelope写XData？|无；description空，零bulge新Polyline，未设Closed=true。|
|22|哪些直接P793？|P854直接new；各模板入口经P356→P854间接共享，不能说各业务类直接new。|
|23|哪些直接Spiral86？|XE、YE、45、80；普通Holding/Base是Spiral88。|
|24|哪些point-to-spiral？|Base直接P7BE；A6业务类无P7AD；80另有自有P463，不能合并身份。|
|25|与A1/B1/B2共享哪些？|P793/P854链、Spiral86 ctor/Point/sample等实际交集、低层point/line及CAD P086/P087/P089；逐项身份和差异见shared表。普通Holding/Base不共享Spiral86 ctor；完整模板构造器独立。|

## 仍待确认，但不冒充已恢复事实

1. **原软件运行**：本轮没有。恢复测试不是原DLL数值oracle；宿主OCS/Normal、Point3d近等容差、Group持久状态、空Polyline的宿主接受情况未验证。
2. **原始body保护**：raw很多方法是stub；几何主体来自处理后IL/反编译，不标为原文件明文源码。原始身份和处理映射均保留。
3. **规范版本**：NDB6.5°、专用XE/YE的rad/R、4600/4630、有限角度全向和点集Envelope等均为“实现依据待确认”。未查明具体旧版规范/ICAO版次/作者简化，未修改为规范候选。
4. **退化与极端输入**：Hull共线缺陷、自有迭代无上限、部分cancel仍继续、负时间/NaN域等未修复；未穷举参数域，未证明所有保护边界切向连续/严格包含。
5. **独立Racetrack语义**：全部事件/控件/构造调用已查，未发现第二套模式。没有以规范补出实现。

这些限制与“缺失某主要几何方法体/只有UI公式”不同；本轮限定链的所有主要过程已有可追溯源码/IL、可执行算术恢复和写图静态证据，故采用静态验收标签。任何未来宿主差异应新增轮次补证，不回写冻结Round1–3。
