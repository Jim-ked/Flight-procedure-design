# Round 5 收口 — B5 PBN Departure

日期：2026-10-27。状态：**PARTIALLY ACCEPTED**。本轮限定范围的静态分析、算术恢复和审计已收口；不将原版本断开的UI评价链补造成可用功能。Round1–3既有冻结状态不变，Round4仍为ACCEPTED (static recovery)。未修改原DLL/配置/数据库/DWG/帮助/压缩包，未执行目标DLL，未进入B3/B4/A5。

## 验收门槛

|门槛|结果|证据|
|---|---|---|
|事件链完整恢复|静态通过：109绑定、未绑定与隐藏入口单列|event-map、events、controls/control-state、callgraph|
|高度转弯主要几何|静态通过：独立P5C8–P5CC、所有控制点/候选/后续区、退化旧行为保留|altitude-turn-geometry、完整Recovered.cs、原/处理IL、条件索引|
|FlyOver-DF主要几何|静态通过：P5D3–P5D7、固定1482、内外界及选择子集Hull|flyover-df、Recovered.cs、fixtures|
|直线/转弯评价算法|静态通过：P5CD/P5D8完整恢复，异常赋值保留|obstacle-evaluation、字段流、IL、公式断言|
|端到端评价/一键流程|**不通过当前功能可用门槛**：三个入口仅隐藏提示，无evaluator入边；无merge/sort/重复优先规则|negative-evidence、P501/P50C/P50D、P5CD/P5D8全域静态引用核验|
|CAD writer|静态通过至AddVertexAt/ModelSpace/Group，空description无业务XData|P087/P089/P12D/P134、cad-helper-source、CAD记录|
|Take(5)|输入截取/表格/字典/Mark高亮通过；没有原UI评价调用可证明“实际前5进入evaluator”|screen-data、generic-calls、form fixture|
|A7/B1/B2真实复用|MethodDef关系已解析；B5未调用三者业务类；仅公共层共享|比较CSV、shared-identities、negative-evidence|
|帮助ATT=0外界等价|未证数学等价；已证明没有ATT=0调用B2的结构|altitude-turn-geometry；冻结B2完整边界port未完成，不改旧轮|
|fixtures|通过限定测试集；零梯度完整几何超时单列，非合规/原DLL等价验证|tests.log、fixture-index、postcheck-results、test-inputs|

按用户“任一评价链仍断裂则PARTIALLY ACCEPTED”规则保留此状态。缺失的是当前版本实际调度和边界数学等价证明，不是把三个提示按钮误认为没有评价公式。

## 28问

|#|问题|结论|
|---:|---|---|
|1|直接复用A7？|共享P0AC/P0AD frame、P793、结果carrier/CAD/障碍物工具；没有调用A7业务几何/evaluator。|
|2|直接复用B2？|无B2 `_008C_0089` ctor/边界调用；B5独立 `_008C_0091/_008C_0093`。|
|3|直接复用B1？|无 `_008C_0087` 构造/边界调用；共享Spiral86等基础MethodDef。|
|4|高度通过ATT=0调用B2？|没有；高度ctor无ATT参数。帮助“外界相同”仍待数学验证，不等同于直接复用。|
|5|ATT来源？|FO固定1482m；高度模式没有独立ATT字段；无RNP1身份绑定。|
|6|XTT来源？|没有独立XTT输入/自动选择或推导证据；不由3704反推XTT。|
|7|SW/1/2AW来源？|初始总宽300、外半宽min(3704,150+s tan15°)、主列1852与后续宽度硬编码。|
|8|高度和TP？|高度TP=(H−DER.Z−5)/g；FO取DER到pick的XY欧式距离；10%高度进入turn，实际梯度高度另显示。|
|9|高度完整保护几何？|P5CC初始分片→初始Hull→P5CB 15°后续区/early连接→P5C9多spiral候选→P5CA交点收尾→全部点Hull评价；见详细控制点/分支表。|
|10|earliest/latest？|TA/H early可为−跑道长+600，否则由DER侧起点；TP d，reaction latest=d+C6；FO TP±1482及latest+C6。|
|11|什么spiral？|共享 `_008F_0086` Spiral86 / P7A1 ctor及实际可达方法，不是B1/B2业务对象。|
|12|后续如何接？|75°选正/镜像起点→有限15°扩张区→旋转平移；外界用LineCarrier到TurnEnd控制线求交；无宿主Trim/Offset。|
|13|FO三点语义？|DER/THR建立跑道frame，TurnEnd是实际后续终点；另传TP站距。与B2起点/转弯点/终点descriptor不同。|
|14|与B2同geometry class？|不是；B5 FO为 `_008C_0093`，B2为 `_008C_0089`。|
|15|ATT怎样进入？|P5D3自身初始化字段1482，参与E/N/C与宽度；不从UI、RNP、category读取。|
|16|DF路径怎样形成？|相对incoming heading转换TurnEnd，P5D4 spiral候选、P5D5交点与1852/3704控制点、P5D6后续区；无独立任意DF航段序列对象证据。|
|17|直线评价？|FO dr/d0依earliest分段，MOC=.008(dr+d0)，PDA=DER.Z+5+dr*gBefore+d0*gAfter，required=(OCA−DER.Z−5)/(dr+d0)下限0；高度另有独立异常字段分支。|
|18|高度转弯评价？|最终Hull包含后按KK/DER/侧方分区；通常MOC=max(75,.008(dr+d0))、PDA=H+d0*gAfter、required=max(0,(OCA−H)/d0)。完整例外见决策表。|
|19|FO转弯评价？|dr=earliest，d0为到earliest线/侧点距离；MOC=max(75,.008(dr+d0))；PDA=10%参考高度+d0*gAfter；required=max(0,(OCA−DER.Z−5)/(dr+d0))。|
|20|一键怎样合并？|没有当前实现证据；三个入口只提示，嵌套排序selector无调用；不补merge/去重/最危险优先。|
|21|Take5真正限制评价？|先限制装载表/ID字典，因此Mark/高亮仅前5；当前UI评价链不可达，不能声称已验证只前5实际进入原evaluator；业务方法自身无5项限制。|
|22|主提示与evaluator关系？|buttonEvl/直线/转弯均隐藏提示；独立完整方法存在但无入边。不能证明作者禁用动机或其他版本可用性。|
|23|Fly-by departure？|B5 public workflow does not evidence Fly-by departure；无hidden模式或B1 ctor证据，独立B1存在不等于B5支持。|
|24|RF？|No B5 RF implementation evidence found；限B5及直接helper搜索，不扩全DLL新模块。|
|25|实际覆盖turn types？|指定高度和FlyOver-DF几何绘制；评价公式存在但UI调度断开。不是规范四种类型完整引擎。|
|26|最终CAD实体？|保护区逐列表零bulge Polyline，再持久Group；Mark另为obst BlockReference/Altitude AttributeReference；无独立Line/Arc/Circle/Text保护区输出。|
|27|哪些写XData？|B5保护区description为空，跳过P089 WsObject分支；无Radius/Kind/PBN metadata；Mark是Attribute文本。|
|28|衔接代码还是人工？|几何衔接点/候选/线交点及后续区已代码化；输入跑道/TP/TurnEnd依人工识别。没有自动识别旧保护区并裁剪/重建的链，静态结果不证明用户实际一定手工修剪。|

## 测试解释

54个JSON样例：53正常返回/预期异常，1个零梯度完整几何8秒超时记录；490项C#断言，64项跨fixture检查。不是同样数量的独立业务场景，也不是原DLL数值oracle。FO fixture名中的E字段未传入FO ctor（FO无early参数），它只是重复稳定性样例，不能当DER前FO模式。

左右nominal CAD顶点集镜像残差<1e-6m；两方向Hull顶点数量可因gift-wrapping的引用/共线/浮点行为不同，不强行规范化。共线(0,1,2) fixture丢最远点2；射线边界左右/上下包含不一致；这些行为保留。零梯度公式Infinity和完整构造超时分开记录。

低站距异常、负站距、6351.95/13263.71前后、C6跨界、导航最早/最晚、IAS/wind/bank/PDG/TurnEnd变化、primary/侧方/out/边界点、危险第6点、重复列名、LineCarrier±1000000特殊值均有样例。没有穷举所有可达角度分支或证明所有点连续/包含；每个精确条件及完整IL仍可审计。

## 证据规模与完整性

326个MethodDef索引（含直接依赖证据）、77个机械恢复方法映射、88个字段角色条目、109事件、2,534字段位点、613 IL条件跳转位点和204反编译条件表达式。MethodSpec→SelectAll P10D的解析另存，不能因原static-sites显示2B token就遗漏公共复用。

最初冻结基线3,224个文件，范围为旧recovered、WsTools-master、reverse-analysis，完整性以integrity-report.json实测为准。规范PDF是本轮只读提取时补充hash，不冒充已含在最初三棵树基线中。所有路径与SHA256见frozen-inputs、material-baseline、output-manifest。

## 残留与停止边界

1. 当前原版本无评价调度，不能逆向出不存在的merge/sort规则；若后续取得其他版本，应另建轮次比对，不回改本轮证据。
2. 帮助ATT=0的数学外界相同未证明；不改冻结B2 partial port，也不因无直接调用就否定等价可能性。
3. 原始body大量保护占位，行为来自处理IL；未做原DLL运行/AutoCAD持久状态验证。
4. 原作者规范/ICAO版次无法鉴定；固定1482、宽度、6秒、Z错站距和异常评价赋值均不以现行规范解释掉。
5. Form是记录适配器，未复建完整UI；宿主事务、OCS、Point3d容差、默认图层/Group字典与空Polyline行为未模拟。

## Round 6顺序建议（不开始执行）

建议先 **B3 RNP APCH**，后 **B4 PBN-ILS**。仅根据已冻结static-sites入口比较：B3 Form中P48A直接new共享P793，且与当前frame、parser、writer、Mark层有直接交集；B4 Form同样复用后几项，但在该入口索引范围未见直接P793。精确站点保存在round6-order-evidence.csv。此为下一轮排序依据，不是B4没有间接turn依赖的证明，也没有新恢复B3/B4业务体。本轮到此停止。
