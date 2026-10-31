"""Round 5 reports only. No edits to frozen rounds or original material."""
from pathlib import Path
import csv,json,re,hashlib,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round5';A=ROOT/'recovered/B5-PbnDeparture';E=A/'evidence'
def put(name,text): (A/name).write_text(text.strip()+'\n',encoding='utf-8')
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,data):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(data[0]));w.writeheader();w.writerows(data)
meta={m['processed_token']:m for m in rows(E/'method-index.csv')}
def ident(n):
 m=meta['0x06000'+n];return f'P{n} / original {m["original_token"]} / original RVA {m["original_rva"]}'
put('overview.md',r'''
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
''')
put('runway-frame.md',r'''
# B5 跑道与坐标

P4FB DER取点、P4FC THR取点、P4FD TurnEnd取点，均经公共P113 GetPoint。P510交换DER/THR文本；P4FF读取两跑道点。P4FE为未绑定坐标转换方法，不能当作评价入口。原/处理身份和RVA见event-map与method-index。

## 两种frame调用方向

同一 `_008D._0089_008F` P0AC：Frame(P0,P1)保存P0 XYZ、两点XY长度、bearing(P0→P1)到字段0089，反向bearing到008A。

1. Form用Frame(DER,THR)，原点DER，局部正X沿THR→DER。转换P0AD：x=L cos(bearing(DER→P)−frame.008A)，y=L sin(...)，z=P.Z−DER.Z。
2. 两业务类内部用Frame(THR,DER)取得incoming heading，再把DER→TurnEnd向量转到incoming坐标。调用顺序不同，但由同一MethodDef实现。
3. 写CAD：局部点列绕原点旋转frame.008A→ZeroZ→加DER.X/Y。绘图Z全为0；不会生成三维爬升面。

TurnEnd是实际XY目的点，既影响出航方向、长度，也进入线交点和末端追加，不只是一个无限远方向。Form不读TurnEnd Z。DER.Z用于TP/评价基准；THR.Z不参与二维跑道长度和方向。业务内部控制点Z另有旧表达式，最终CAD抹零。

和A7共享P0AC/P0AD；**A7没有TurnEnd输入字段**，不能把它称作共享DER/THR/TurnEnd三点业务模型。B5与B2三点语义也不同：B2起点→转弯航路点→终点；B5为DER、THR、TurnEnd加单独TP站距。

取点文本被Round，TP取点使用到DER的无符号XY欧式距离。没有检查延长线共线性或做有符号轴投影；取消P113返回Origin的旧行为无统一业务拦截。自动化需要已有可信跑道/航段对象关联，当前没有此关联证据。
''')
put('navigation-tolerance.md',r'''
# ATT / XTT / 宽度来源

|参数|值/单位|Source / setter|Consumer|证据|
|---|---|---|---|---|
|指定点ATT样常数|1482 m|P5D3构造字段 `_008A_0089_0099`，无UI setter|earliest=TP−1482、navigation latest=TP+1482|P5D3 IL及字段流|
|高度模式ATT|没有独立ATT入参/字段|不构造B2对象|无ATT=0调用|P503/P504→P5C8；negative-evidence|
|XTT|没有独立XTT读取/推导证据|无RNP/传感器/类别选择绑定|不应反推为已实现XTT体系|Form字段、109事件、ctor签名|
|初始总宽|300 m|两业务ctor常数|DER半宽150|P5C8/P5D3|
|外侧半宽|W(s)=min(3704,150+s tan15°) m|业务类常数/站距|TP、latest、earliest控制点|P5C8/P5D3|
|主区宽度控制|1852 m；部分控制点min(W,1852)|ctor/边界方法|初始区、spiral中心及末端交点|P5C9/P5CA/P5D4/P5D5|
|外宽上限|3704 m|hard-coded constant|初始/后续区、连接末端|同上|
|高度早转偏距|600 m|P5C8字段|early点X=−runwayLength+600|P5C8/P5CB|
|后续15°扩张|1852/3704与6911.76/13823.52 m|StartArea常数|距连接起点的长度分支|P589、FO后续P58E，method-map|

1482接近0.8NM但代码值不是1481.6；未发现RNP1名称或spec selector与该字段绑定。3704也可对应不同规范条件。全部记为 **hard-coded constant / 实现依据待确认**，不能自动命名为“RNP1 ATT/XTT”。

方向ComboBox不是飞机类别。没有基于ARP距离、导航设施、RNAV/RNP规范选择容差或宽度的证据；A3定位容差结果不被B5自动读取。不能因共享低层点/线/螺旋而判定复用A3业务。
''')
put('altitude-turn.md',r'''
# 指定高度转弯

## 输入与事件

P500读取 IAS、转弯标高H、bank、wind、temperature，P793实参顺序为 `(IAS,H,bank,wind,temperature)`，IAS/Wind按各自开关乘1.852。P503 CAD先检查H−DER.Z<186，拒绝时只提示；等于186不因该检查拒绝。gBefore、gAfter由百分数/100输入。checkBoxEarlyTurn传P5C8第8参，语义为允许DER之前转弯。

P505/P506显示TP=Round((H−DER.Z−5)/gBefore,1)；g=0保留旧显示。业务构造器没有相同保护，直接除法。P504 KML仍调用同一P5C8构造器，但丢弃几何，只载入/另存kmlTemplate.xml；无保护区点写入证据。反编译器把实参重排，不存在第二种“数字在前”ctor overload，P504 IL_002D–0098可核验。

## 业务完整阶段

1. P5C8保存DER/THR/TurnEnd、turn、两梯度、early。
2. d=(H−DER.Z−5)/gBefore；c=d+(TAS+wind)/.6，单位km/h时等价6秒位移；固定300、600、tan15°，宽度封顶3704。
3. P5CC构造直线/转弯起始点组；c<6351.95抛“本软件不支持过低的转弯高度，请检查。”，与Form186m检查并非同一判据。
4. 初始所有点flatten→P7D9 gift-wrapping hull，存初始Hull。
5. P5CB选择早转/DER侧起点，经75°判断镜像，构造StartArea并旋转/平移追加；early时另加DER与early点连接四边形。
6. P5C9自有多spiral外边界，P5CA末端连接，详见altitude-turn-geometry。
7. 现在全部绘图点flatten→P7D9，形成最终评价Hull；P5CD用它先判包含，再按KK/DER/侧方几何评价。

后续段是从选择的起始侧点到TurnEnd的有限15°扩张点组及螺旋末端连接，不是任意多航段PBN路由器。未发现自动识别前后CAD实体、布尔裁剪或通用接续下一程序对象的调用。
''')
put('altitude-turn-geometry.md',r'''
# 高度转弯完整几何与B2关系

证据主体 `_008C_0091`，P5C8初始化→P5CC初始区→P5CB内侧/后续扩张→P5C9外界→P5CA末端。所有方法原/处理token、RVA、签名见recovery-method-map。全部分支原跳转位置见branch-sites；可读表达式见condition-expressions；逐点列表在Recovered.cs及fixtures。本文不把Hull误称为CAD Union。

## 控制点（局部坐标，正侧再按需镜像）

令d=TP，c=latest，g=gBefore，W(s)=min(3704,150+s tan15°)。

|别名/字段尾号|点|
|---|---|
|S/0087|(0,150)|
|A/0088|(6351.95,1852,(g+.008)×**6531.95**+5)|
|B/0089|(13263.71,3704,(g+.008)×13263.71+5)|
|K/008A|(d,W(d),(g+.008)d+5)|
|Kprimary/008B|(d,min(W(d),1852),(g+.008)d+5)|
|Couter/008C|(c,W(c),(g+.008)c+5)|
|Cinner/008D|(c,1852,(g+.008)c+5)|
|Early/008E|(−length(THR,DER)+600,150)|

A点X和Z站距不一致是处理IL已有表达式，按原值保留。无DER.Z加到上述局部Z。

## P5CC初始分支

- c<6351.95：直接抛异常。
- d<6351.95且c≥6351.95：d宽度点、S及其镜像构初始区；A/Cinner的对称主列与两侧Couter补区，共4列表。
- d≥6351.95且c≤13263.71：S-A-Kprimary主列、A-Kouter-Kprimary两侧补列、Kprimary-Cinner中央列和两侧Couter补列，共6列表。
- d<13263.71<c：初始S-A-Kprimary，A至K两侧补列；Kprimary至Cinner中央列；两侧补列加入B。共6列表。
- d≥13263.71：对应两侧补列均含A/B/Kouter/Kprimary，共6列表。

分支严格<、<=、>=的端点语义不统一，不根据图形常识合并。列表按源码顺序保留重复首点；部分后续列表不重复首点。

## P5CB后续内侧

选择S或Early作为起点，TurnEnd转到局部坐标。比较正/镜像起点→TurnEnd的绝对bearing与75°，按左右转选择一侧。长度L=起点到TurnEnd；StartArea(L,left)在自身坐标从0扩张：L<6911.76为三点三角列表；中段封主宽1852并加侧区；L≥13823.52外宽3704。旋转到连接bearing再平移至起点，追加点组。

**反编译修复证据**：P5CB IL_01DA–022F给出的实际Rotate签名/栈顺序是 `(new StartArea(...).lists, origin, angle)`。C#只按IL纠正重排，未改业务分支。

## P5C9螺旋外界

令s=左+1/右−1，r=turn radius，δ=drift，β=15°，α=90°（静态常数见该类cctor）。以TemplatePoint极坐标向量加法定义中心，不以圆弧替代Spiral86。

1. latest轴点(c,0)，加长度r−1852、方向sα向量，构第一个Spiral86；heading=−sα、phase=0、left原参。外/内宽差Δ=W(c)−1852用于偏置采样。
2. 用Spiral.PointToParameter(TurnEnd)与δ/α比较。若候选参数−δ>α，另以r+1852中心构第二spiral；在α+δ、α+β及π+β阈值分段，依次拼接样点；否则第一spiral直接采样至候选−β。
3. 更大角度分支从A轴点+(r+1852)向量建第三spiral，从S或Early轴点+(r+150)向量建第四spiral。P7AF类相切参数 helper、两中心bearing及候选参数比较决定接到哪一条。
4. 对primary与带Δ偏置列表分别采样；P5CA收尾后，将两列表依次追加总图形。不执行CAD IntersectWith、Offset、Trim。

精确候选条件保留在完整P5C9代码；没有把所有控制点归为无条件四个spiral，某分支只需前一/两条。共享的是Spiral86方法身份，B5外界选择是独立P5C9。

## P5CA末端

取spiral在候选参数−β处的点与heading；若其径向距离大于到TurnEnd距离，提前返回。否则作主/偏置heading线，另作经过TurnEnd的±1852、±3704控制点与相应平行线，LineCarrier求交。

- 两交点到TurnEnd距离分别≤1852、≤3704：分别追加交点。
- 仅外侧≤3704：主列追加primary交点及1852控制点；外列追加到TurnEnd的交点。
- 其余：两列分别追加交点及1852/3704控制点。
- 外列表最终追加TurnEnd，primary列表不无条件追加TurnEnd。

## ATT=0结论边界

P503/P504直接new P5C8；P5C9直接new P7A1 Spiral86。无B2 `_008C_0089` ctor调用，无ATT=0实参链。B5高度模式无ATT参数，不能把“参数不存在”当“已传0”。B2与B5都有spiral候选/15°连接，但业务MethodDef不同。帮助FormFlyOverDF.html:62的“ATT为0外界相同”仍是待验证数学说法；本轮未移植冻结B2完整边界，未给数值等价判定。未反向改写Round3。
''')
put('flyover-df.md',r'''
# 定点转弯 FlyOver-DF

## 输入/高度

P507提示在跑道延长线上选择指定转弯点，实际只计算DER至pick的XY欧式距离，无投影/共线检查；Round(d,2)显示站距。

`textBoxAltiTp / 字段0093 = Round(d×.1+DER.Z+5)`；`textBoxRefAltiTp / 字段0094 = Round(d×gBefore+DER.Z+5)`。控件名称容易误导：**P50A实际读取0093（10%高度）进入P793**，不是另一高度字段。P509随PDG TextChanged重算，距离框没有TextChanged绑定。

P50B CAD调用同一P5D3，真实签名 `(turn,DER,THR,TurnEnd,TPdistance,left,gBefore,gAfter)`。IL_002E–00AE确认；不采用反编译器错排表达式。没有可用的一键/直线/转弯评价事件调度至P5D8。

## 几何

1. P5D3将ATT样字段固定为1482m。E=TP−1482，N=TP+1482，C=N+(TAS+wind)/.6；对应W(E)、W(N)、W(C)=min(3704,150+s tan15°)。
2. P5D7以S=(0,150)、A=(6351.95,1852)、B=(13263.71,3704)、E的主/外点、N的主/外点、C的1852/外点构造初始列表。Z沿(gBefore+.008)×站距+5；A保留6531.95错站距。C<6351.95抛低转弯高度异常。
3. E/N/C与6351.95、13263.71的分支控制5/7/9列表：中央主列表、两侧补列、早晚站距间中央与两侧列表。准确条件和逐点顺序完整保留P5D7与条件索引，不能用一个统一矩形取代。
4. 初始flatten→gift-wrapping Hull存009A。
5. P5D6将E主/外点与局部TurnEnd连接，按左右和75°镜像；把外点转到该后续坐标系，FlyOverPostArea沿15°线求出封顶1852/3704的交点，旋转/平移追加。
6. P5D4为本类自己的外界：以C轴点r−1852/r+1852、A轴点r+1852及Eprimary轴点r+150等候选中心构造Spiral86；δ、90°、15°、π与候选参数决定拼接。P5D5保留和高度末端类似的LineCarrier交点/1852/3704三分支，并在外列追加TurnEnd。
7. 最终009B评价Hull来自两条外界列表、后续区，以及C>13263.71时加入的B点。**并非所有绘图点组flatten**；直线评价仍用初始009A，转弯评价用009B。

## 与B2

不是同一 `_008C_0089`，不直接调用B2 ctor或边界方法。B2的三个segment descriptor语义为起点/转弯航路点/终点，ATT由中点输入；B5没有中点descriptor，TP由DER站距表达，另有固定1482。两者共享P793及Spiral86、line/point/list等低层MethodDef；业务分支相似不能标为同一实现。

DF形成的是朝实际TurnEnd的候选连接和有限后续扩张保护点组，没有恢复出原软件中独立的可执行DF飞行轨迹对象或任意航段序列引擎。Mark/高亮通过Form源DBPoint字典，几何类不直接操作CAD选集。
''')
put('straight-segment.md',r'''
# 初始直线段/转弯起始区

高度P5CC与定点P5D7独立实现，不调用A7直线业务、A9 PriSec或通用PBN航段业务对象。

起点为DER局部X=0，半宽150m、向两侧15°扩张，外半宽封3704m；1852m是主列/分片边界常数，6351.95与13263.71是源码中的过渡站距。不要重算并替换为精确tan15°交点（尤其A点Z仍用6531.95）。

终止随模式：高度在TP至latest间构造起始列表；指定点覆盖earliest、navigation latest、reaction latest。构造列表分别含主列与两侧补列，通过共享控制点/镜像连接；不是调用CAD Offset生成副区。高度可额外构造DER向THR方向至−runwayLength+600的早转连接。

图上主/侧列表存在，并不表示评价器实现副区线性MOC衰减。两套评价器分别使用Hull包含与距离分支；均未调用A9。指定点直线统一MOC=.008(dr+d0)，没有75m下限和按横向副区位置衰减。高度直线有一条异常字段赋值分支，详见obstacle-evaluation。

列表之间有重复边、重叠，Hull用于评价并非对CAD实体真正裁剪。最终Polyline没有业务XData来区分primary/secondary，后续用户若选择图元需另靠位置/显示判断，当前代码没有自动再识别链。
''')
put('obstacle-evaluation.md',r'''
# 两套障碍物评价与不可达UI

P5CD（高度）与P5D8（指定点）是不同MethodDef。完整方法体、IL、字段写入与条件均保存；evidence/negative-evidence.json记录在全程序集已解码静态调用和非header IL引用中无调用方。本轮直接调用恢复代码做公式测试，**不代表原Form能够执行评价**。

结果carrier `_008A_0089` 的dr getter=0088_008E_009E，d0 getter=0088_008E_009B；label=0095、MOC=0088_008F_0088、OCA=008B、PDA=008E、required=0091。不要把dr/d0交换。

## 高度P5CD决策表

令y=abs(Y)，K=(d,W(d))，B=(13263.71,3704)，S=(0,150)，E=(−runwayLength+600,150)，H=turn.altitude。L为S→A线，N为过K（K.X≥B.X时过B）且垂直L的线。

|顺序/区域|dr,d0|MOC/OCA|PDA / required|
|---|---|---|---|
|final Hull外|不计算，label=out|保留carrier已有字段|直接返回|
|X≥K.X|dr=K.X；y≤K.Y时d0=X−K.X，否则到K距离|max(75,.008(dr+d0))；OCA=Z+MOC|H+d0×gAfter；max(0,(OCA−H)/d0)|
|K.X>B.X，X≥B.X且y>3704|dr=X，d0=y−3704|同上|DER.Z+5+dr×gBefore；max(0,(OCA−DER.Z−5)/(dr+d0))|
|同条件y≤3704|dr=X,d0=0|**max(75,.008dr)**|DER.Z+5+dr×gBefore；max(0,(OCA−DER.Z−5)/dr)|
|0<X<K.X，y≥N(X)|dr取K.X或B.X；d0到相应K/B距离|通用转弯max75公式|H+d0×gAfter；(OCA−H)/d0下限0|
|0<X<K.X，y<L(X)|dr=X,d0=0|.008dr；OCA=Z+MOC|**PDA=dr×gBefore；required=DER.Z+5+dr×gBefore**|
|0<X<K.X，L(X)≤y<N(X)|d0为到L距离；dr为过障碍物平行N线与L交点的X|通用转弯max75公式|H+d0×gAfter；(OCA−H)/d0下限0|
|X≤0，early=false|dr=0；y≤150时d0=−X，否则到S距离|max(75,.008d0)|H+d0×gAfter；(OCA−H)/d0下限0|
|X≤0，early=true，X<E.X|dr=0；到E的轴向/欧式距离|同上|同上|
|early=true，E.X≤X≤0，y>150|dr=0，d0=y−150|同上|同上|
|early=true，E.X≤X≤0，y≤150|dr=0；d0未重新赋值|75；OCA=Z+75|PDA=H；required未重新赋值|

异常直线字段赋值由P5CD IL_0BC0–0BED确认，未改成规范公式。原方法就地修改传入carrier，out/早转净空道部分字段不赋值；应保留传入值，不能统一初始化或覆盖。零距离除法的NaN/Infinity与Math.Max传播不补clamp。

## 指定点P5D8(P0, straight=true)

- straight=true：初始Hull外label=out；内则X≥E.X时dr=E.X,d0=X−E.X，否则dr=X,d0=0。MOC=.008(dr+d0)，无75m下限；OCA=Z+MOC；PDA=DER.Z+5+dr×gBefore+d0×gAfter；required=max(0,(OCA−DER.Z−5)/(dr+d0))。
- straight=false：最终Hull外out；内dr=E.X，y≤Eouter.Y时d0=abs(X−E.X)，否则为到Eouter距离；MOC=max(75,.008(dr+d0))；OCA=Z+MOC；PDA=turn.referenceAltitude+d0×gAfter；required=max(0,(OCA−DER.Z−5)/(dr+d0))。
- referenceAltitude来自10%高度框，不是另一个按实际PDG高度框。转弯PDA与required使用不同高度基准，保留。
- 无副区线性衰减、无A9调用；primary/secondary图形片段不能证明评价语义同A9。

## 三个评价按钮及一键缺口

buttonEvl P501（一键）、button8 P50C（直线）、button7 P50D（转弯）Visible=false；处理后body都只MessageBox“请指定转弯点。”。button9 P50F隐藏且空。未找到其他可达完整evaluator事件，P4FE只是未绑定坐标转换并调用错误结果表。三个嵌套selector P54C/P54D/P54E仅返回required getter，未找到ldftn调用。

因此没有可证明的一键ScreenData→straight→turn→merge/sort链；重复障碍物优先/覆盖/最危险值规则均**未实现证据**，不补造。提示和“基础版仅前5”支持功能限制的观察，但没有证据证明作者禁用动机或某付费版行为。“原本应该调用什么”只能列现存候选P5CD/P5D8，不能当事实。

P4F8结果表又有11列（两次“高度(m)”）/每行12值的错误：实际System.Data先抛DuplicateNameException。测试保留该异常；ScreenData装载表P4F7没有重复列名，不要把两表混同。
''')
put('screen-data.md',r'''
# ScreenData、Take(5)、Mark与高亮

P4F3/P4F4按钮→P4F6→公共泛型SelectAll P10D（MethodSpec调用须解析，static-sites中token 2B00000D）筛DXF POINT/Model。Count>5弹“基础版仅提供前5项数据评估。”，然后Take(5).ToList；<=5保留原列表效果相同。没有按高度或危险程度排序后取5。

P4F7再按选择返回顺序逐点调用公共P12F parser(num.ToString())，ID从1编号，表与ID→原DBPoint字典只装载这些点。第6及以后不在此窗口字典内。

**评价影响的证据边界**：截取发生在任何潜在评价之前；当前没有可达UI评价调度，因此不能宣称已实测“前5进入原evaluator、第6绝不进入任何评价器”。直接业务方法接受任意carrier、无5项限制；恢复fixture可直接评价第6点，不代表另有原UI绕过入口。

P4F9为已绑定CellClick：通过ID回查DBPoint，P0B0取消已加载点高亮，再P0AF高亮源点；不调用居中视图逻辑。P4FA是未绑定的旧XYZ匹配/视图定位方法，把Cells[1]（当前名称列）当double的遗留问题保留。

P511 Mark：SelectedRows→表ID→原DBPoint，公共P09C在原位置插入“obst”块，再P09E向“Altitude”Attribute写source.Position.Z.ToString()。使用原绝对Z，不是几何局部Z/计算PDA。与Round1同一MethodDef；本轮只读引用其证据，不重写公共选点、parser或插块流程。

Load P4F1及Close P4F2保存/恢复config.xml的“FormDeparture”key，存在跨窗体键名重用；没有以“FormPbnDepEvl”键读取额外导航规范的证据。
''')
put('protection-connections.md',r'''
# 保护区衔接

|阶段|分类|实际机制|自动化/边界|
|---|---|---|---|
|DER直线→起始区|Shared vertex / Independent overlapping polygons|S/A/B、TP/early/latest主外点及镜像拼接各列表|无CAD布尔合并；重复边保留|
|起始→内侧/后续区|Line carrier / Shared vertex|75°选择侧点，15°扩张到1852/3704，旋转平移点组|由TurnEnd与输入确定，代码化|
|latest→外转弯|Spiral candidate|最多4条Spiral86，候选参数、δ、15°、90°、π分支|不是相同MethodDef的B1/B2业务函数|
|外界→TurnEnd|Calculated intersection / Line carrier|候选−15°样点heading线与TurnEnd控制线求交；按1852/3704距离分段|只追加选中点，不执行宿主Trim/Extend|
|整体评价包络|Calculated hull|P7D9 gift wrapping；高度用全部绘图点，FO用选择子集|非CAD Region union；可能跨越分片之间空隙|
|导出图面→下一程序|Manual CAD dependence待运行证据|未发现业务对象自动配对、选旧保护区并修剪/重建的代码|不能据此宣称用户必定手工修剪；只能说自动接口无证据|

evidence/connection-api-sites.csv索引本轮B5及依赖中Polyline/Arc构造、GetPoint/SelectAll、Group/XData相关调用；direct-calls提供全部站点。未发现B5路径调用CAD IntersectWith、Offset、Trim、Extend、Erase输入图元，未发生选择前后保护区实体的GetEntity/GetSelection流程。

CAD交互只是输入DER/THR/TurnEnd/TP及选表格行，几何层不依赖人逐个选交点。业务输入本身依赖设计人员识别，见cad-interactions。没有凭规范给旧图补点，也没有推定各列表严格切向连续、相交集合等于真实保护区。

gift wrapping由minY/minX起点，orientation==2替换候选；共线无最远点规则，按对象引用判断闭环。退化可能漏最远共线点或非终止；本轮3个退化fixture结果保存，不把全部退化一概称超时。Ray包含严格比较导致边界左/下与右/上不对称。
''')
put('cad-output-map.md',r'''
# CAD最终实体

P503（高度）/P50B（FO）→业务点组→PointLists旋转P821→ZeroZ P827→平移P823→**P087** Group writer。P086是single-polyline writer，P089是append；不得沿用早轮旧表的错配名称推断身份。准确原/处理IL均在本轮evidence。

P087：DocumentLock→外Transaction→new Group（先内存创建）→逐列表new Polyline→P12D Point2dCollection（经P12A取XY）→P134 AddVertexAt(index,point,**0 bulge,0 startWidth,0 endWidth**)→P089各自事务AppendEntity到ModelSpace→Group.Append(ObjectId)→最后Database.AddDBObject(Group)及事务提交。

|对象|创建/追加顺序|元数据/样式|
|---|---|---|
|Polyline|列表顺序逐个追加，主/补/外/后续列表不另分类对象|无显式Closed=true；重复首点只几何闭合；ZeroZ；无显式Layer/Color/Linetype|
|Group|内存先new，数据库最后持久化|没有业务命名/分类schema证据；宿主实际持久行为本轮无L3|
|Line/Arc/Circle/Text|保护区主链无独立实体创建|曲线来自采样折线，不是CAD Arc|
|BlockReference|Mark另走P09C“obst”块|在原DBPoint位置|
|AttributeReference|Mark P09E修改“Altitude”|source.Z.ToString；不是XData|

两次B5 writer实参description为空，P089的Trim().Length>0为false，跳过WsObject XData赋值。没有Radius/Kind/PBN departure metadata。默认层/颜色/线型不能以“未set”推断确定等于哪一宿主显示值。

PbnDepartureCad.Recovered.cs只记录预计实体和点列，不模拟Autodesk对象ID、事务、OCS、容差、组字典、宿主默认属性或空Polyline接受行为。每正常fixture保存local、hull与CAD顺序。KML P504不写几何，不能作为额外实体导出验证。
''')
put('xdata-schema.md',r'''
# B5 XData schema

**保护区主链：没有业务XData写入证据。** P503/P50B向P087传空description；P089只有description.Trim().Length>0才注册“WsObject”并写1001 app / 1000 description。此条件在B5为空时跳过。

|实体/属性|WsObject|Radius|Kind|PBN业务数据|
|---|---|---|---|---|
|保护区Polyline|未写|未写|未写|未写|
|Group|无此schema|无|无|无|
|Mark块/Altitude Attribute|不是XData|无此字段链|无此字段链|源标高是Attribute文本|

不能从Polyline轮廓自动推定TA/H、FO、primary/secondary或导航规范；没有恢复出实体到程序对象的往返序列化。原图若已有其他XData，不属于本轮新建路径的事实。
''')
put('cad-interactions.md',r'''
# CAD人工交互清单

|入口→API|用户确定的业务对象|为何依赖人工|计算消费者|可由已有数据自动推导？|
|---|---|---|---|---|
|P4FB→P113 GetPoint|DER点/高程|只见空间点与文本，没有跑道业务ID绑定|P4FF frame、TP、两类评价|已有可信跑道端点对象时可以；当前插件无证据|
|P4FC→P113|THR点|同上；不是识别跑道实体|二维长度/bearing、600m早转位置|可由跑道对象推导，现链未做|
|P4FD→P113|转弯后终点/下一点|代码不知道设计者要飞向哪一点|两模式局部TurnEnd、heading、后续宽度与线交点|已有航段序列时可；当前数据模型无链接|
|P507→P113|跑道延长线上TP（仅提示）|没有导航fix对象/站距绑定；不校验共线|XY欧式距离、10%与实际PDG双高度→P50A/P5D3|可从TP站距和跑道frame生成，当前可直接文本填距|
|P4F6→P10D SelectAll|所有ModelSpace POINT障碍物|不是逐个手动选；点的业务含义依赖上游导入|Take5→P12F→表/字典|选集自动；数据完整性与选择顺序非危险排序|
|P511 SelectedRows|希望标记的障碍物ID|评价按钮缺调度，代码没有自动危险结果选择策略|回查源点→P09C/P09E Mark|若有结果与明确选择规则可自动；现链未定义|
|P4F9 CellClick|列表行ID|由用户决定查看对象|取消已加载点高亮→源点高亮|已有选中ID可自动；无居中证据|

B5及直接几何依赖没有GetEntity/GetSelection选前后保护区的链。公共P113取消返回Origin，调用方继续写入文本而无统一取消哨兵，属于旧行为。以上“可以”是后续自动化候选推断，不是已实现功能。
''')
put('callgraph.md',r'''
# 调用图与数据断点

```mermaid
flowchart TD
 CMD[Y55 / Form ctor] --> UI[109 event bindings]
 UI --> PICK[DER THR TurnEnd TP / P113]
 PICK --> FRAME[P4FF / shared P0AC frame]
 UI --> ALTREAD[P500 / shared P793]
 UI --> FREAD[P50A / shared P793 10percent altitude]
 ALTREAD --> A[P503 CAD / P5C8 altitude class]
 FREAD --> F[P50B CAD / P5D3 FO class]
 A --> AS[P5CC initial / hull]
 AS --> AP[P5CB StartArea]
 AP --> AO[P5C9 Spiral86 / P5CA connection]
 F --> FS[P5D7 initial / hull]
 FS --> FP[P5D6 FlyOverPostArea]
 FP --> FO[P5D4 Spiral86 / P5D5 connection]
 AO --> WRITE[rotate ZeroZ translate / P087 P12D P134 P089]
 FO --> WRITE
 UI --> SCREEN[P4F3 P4F4 / P4F6 SelectAll Take5]
 SCREEN --> DICT[P4F7 parser P12F / ID dictionary]
 DICT --> MARK[P511 P09C P09E]
 DICT --> HIGHLIGHT[P4F9 P0B0 P0AF]
 UI --> PLACE[P501 P50C P50D hidden / message only]
 EA[P5CD altitude evaluator / no incoming call] --> RESULT[result carrier]
 EF[P5D8 FO evaluator / no incoming call] --> RESULT
 CONV[P4FE unbound local conversion] --> BAD[P4F8 duplicate-column result table]
```

图没有连ScreenData到evaluator：已解码调用没有这条边，不能根据预期补。全精度edge在direct-calls.csv；泛型MethodSpec展开另见generic-calls.csv。每条handler原/处理身份、RVA、直接callee/API见event-map，不以窗口边界截断helper链。
''')
put('compare-a7.md',r'''
# A7与B5逐项比较

分类不把形似自动当共享：**Same MethodDef**才是直接复用；**Copied algorithm**表示独立方法中有同序公式/语句结构，不能证明作者复制行为；**Numerically similar**仅指常数/公式近似；**Different implementation**有明确输入或分支差异。完整条目见../round5/a7-b5-comparison.csv，调用身份交集另存a7-b5-shared-identities.csv。

|项|分类|事实|
|---|---|---|
|两点frame|Same MethodDef|P0AC/P0AD；A7没有TurnEnd三点模型|
|TP显示|Copied algorithm|各自handler计算(H−DER.Z−5)/g并Round1，g=0保留显示|
|业务TP|Copied algorithm|各自ctor直接除法，B5另加PBN点组/Spiral86|
|指定点双高度|Copied algorithm + Different implementation|均10%及实际PDG双高；B5传10%高度且直接传TPdistance；A7由高度反算TP|
|TAS/bank/wind|Same MethodDef|共同P793，五参顺序相同；高度来源按模式不同|
|earliest/latest|Different implementation|B5固定1482（FO）/600m early（TA/H）、C6；不复用A7业务ctor|
|straight/turn area|Different implementation|B5独立类、1852/3704、Spiral86候选及后续TurnEnd；A7几何类独立且不消费spiral半径构界|
|MOC|Numerically similar + Different implementation|.008/75常数重叠，区域判断、PDA、required分支各自方法，保留B5异常赋值|
|评价结果carrier|Same MethodDef|_008A_0089是共享结果数据，非共享evaluator|
|CAD/Mark/highlight|Same MethodDef|P087/P09C/P09E/P0AF/P0B0等实际调用交集|

结论：B5独立业务几何/评价，包含与A7相同的公共输入helper和独立重复计算片段；不应标“A7+PBN turn直接组合”，也不应标“完全独立不共享”。A2参数模型真正复用；A3业务自动传递没有证据。
''')
put('compare-b1-b2.md',r'''
# B5与B1/B2

两比较CSV包含turn parameter、ATT、earliest/latest、spiral、inner/outer、width transition、CAD和XData。另有同MethodDef调用交集及caller站点。

B1/B2经P854读公共P793，B5在P500/P50A直接new P793；三者共享Spiral86 ctor/Point/sample/候选helper的实际交集。B1 `_008C_0087`、B2 `_008C_0089`与B5 `_008C_0091/_008C_0093`均为不同业务类。B5对B1/B2构造和边界方法没有直接调用。

B1的anticipation包含r tan(A/2)，B2以输入ATT确定earliest/latest；B5高度无独立ATT，FO固定1482。B1/B2用起点/航路点/终点descriptors；B5以跑道frame+TP站距+TurnEnd表达。B5后续主宽1852/外宽3704写死；B1/B2由UI/预设宽度输入。常用15°衔接与候选操作是独立相似实现，不能从局部语句相似推定完整边界相同。

本轮不修改冻结Round3的partial geometry port，也不为了ATT=0进行跨轮重写；没有输出数值等价证明。B5 public workflow does not evidence Fly-by departure. No B5 RF implementation evidence found. 负证据限于B5 Form、两业务类及直接可达helper，不否定DLL其他模块。
''')
# Explicit comparison CSV, keep true identity evidence separately from qualitative inference.
def comp(item,cat,b5,other,evidence):return dict(item=item,classification=cat,B5=b5,other=other,evidence=evidence)
a7=[comp('runway frame','Same MethodDef','P4FF -> P0AC; P4FE -> P0AD','P281/P280 -> same','a7-b5-shared-identities.csv'),comp('TurnEnd','Different implementation','actual XY used for heading and endpoints','no A7 TurnEnd field','runway-frame.md'),comp('turn height / TP','Copied algorithm','P505/P506 display; P5C8 raw divide','P285/P286 display; P1FB raw divide','altitude-turn.md; frozen A7/altitude-turn.md'),comp('reference/calculation height','Copied algorithm; Different implementation','P507/P509 two heights; P50A reads 10%; TP passed directly','P287/P289 two heights; P202 reverses TP from altitude','flyover-df.md; frozen A7/point-turn.md'),comp('TAS bank wind','Same MethodDef','P500/P50A -> P793','A7 input -> P793','shared-pbn-departure-calls.csv'),comp('earliest/latest','Different implementation','fixed1482 FO;600m optional early;C6','A7 separate ctor and own tolerance inputs','navigation-tolerance.md'),comp('straight area','Different implementation','P5CC/P5D7 150 tan15 cap3704','independent A7 polygon methods','straight-segment.md'),comp('turn area','Different implementation','P5C9/P5D4 -> Spiral86','no A7 business geometry reuse','negative-evidence.json'),comp('MOC','Numerically similar; Different implementation','.008 /75 with own distance branches','same constants in independent evaluator','obstacle-evaluation.md'),comp('obstacle evaluation','Different implementation','P5CD/P5D8 no UI incoming calls','P1FC/P203/P421 UI connected','negative-evidence.json; frozen A7 overview'),comp('result carrier','Same MethodDef','_008A_0089','same result carrier','a7-b5-shared-identities.csv'),comp('CAD writer','Same MethodDef','P503/P50B -> P087','P283/P28C/P290 -> P087','a7-b5-shared-identities.csv')]
out(O/'a7-b5-comparison.csv',a7)
for other,tag in [('B1','b1'),('B2','b2')]:
 data=[comp('turn parameter','Same MethodDef','direct P793 via P500/P50A',other+' via P854 -> P793','shared-pbn-departure-calls.csv; round3 shared table'),comp('ATT','Different implementation','TA/H no ATT; FO fixed1482','UI waypoint descriptor ATT','navigation-tolerance.md'),comp('earliest/latest','Different implementation','TA/H d/C6;FO TP+-1482 and C6','r tan(A/2) anticipation' if other=='B1' else 'input ATT and reaction/bank delay','frozen '+other+' geometry; this round geometry docs'),comp('spiral','Same MethodDef','P7A1 Spiral86 and called methods','shared Spiral86 subset',tag+'-b5-shared-identities.csv'),comp('business class','Different implementation','_008C_0091 and _008C_0093','_008C_0087' if other=='B1' else '_008C_0089','negative-evidence.json'),comp('inner boundary','Different implementation','StartArea/FlyOverPostArea;75degree side','independent descriptor-based boundary','protection-connections.md'),comp('outer boundary','Copied algorithm structure; full equivalence unproved','independent spiral candidate and 15degree connection','independent business branch methods','altitude-turn-geometry.md'),comp('width transition','Different implementation','hardcoded1852/3704 tan15','UI/preset widths via descriptors','navigation-tolerance.md'),comp('CAD writer','Same MethodDef','P087 grouped polylines','actual shared identities in separate table',tag+'-b5-shared-identities.csv'),comp('XData','Numerically similar output condition','description empty -> no business XData','shared append only writes if description nonempty','cad-output-map.md; frozen CAD map')]
 out(O/(tag+'-b5-comparison.csv'),data)
# Add exact citations for key methods in one compact index.
put('key-locations.md','# 关键MethodDef定位\n\n'+'\n'.join('- '+ident(n) for n in ['4F6','4F7','4F8','4F9','4FE','4FF','500','501','503','504','507','509','50A','50B','50C','50D','511','5C8','5C9','5CA','5CB','5CC','5CD','5D3','5D4','5D5','5D6','5D7','5D8'])+'\n\n全部processed RVA及签名见evidence/method-index.csv、signatures.csv；同token文件在evidence/raw与processed。')
# Supplement frozen source text for final CAD writer/helpers, by mapped source locations.
loc=rows(ROOT/'reverse-analysis/04_type-map/method-source-locations.csv');snips=[]
for t in ['0x06000087','0x06000089','0x0600012A','0x0600012D','0x06000134','0x06000113','0x0600010D','0x0600012F']:
 l=next((x for x in loc if t in x['tokens'].split(';')),None)
 if l is None:
  snips+=['\n// '+t+' generic source mapper has no location; exact processed IL retained.'];continue
 lines=(ROOT/'reverse-analysis'/l['source']).read_text(encoding='utf-8').splitlines();start=int(l['line'])-1
 end=next((i for i in range(start+1,len(lines)) if lines[i]=='\t\t}'),start+1)
 snips+=['\n// '+t+' '+l['source']]+[f'{i+1}: {lines[i]}' for i in range(start,end+1)]
(E/'cad-helper-source.txt').write_text('\n'.join(snips),encoding='utf-8')
print('reports generated')
