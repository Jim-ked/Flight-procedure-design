from pathlib import Path
import csv,json,re
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round6';A=ROOT/'recovered/B3-RnpApch';E=A/'evidence'
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
ms={x['processed_token']:x for x in rows(E/'method-index.csv')};calls=rows(E/'direct-calls.csv');events=rows(E/'events.csv')
def tok(t):return '0x06000'+t
def ref(t):
 m=ms[tok(t)];return f"P{t}: 原 {m['original_token']} / RVA {m['original_rva']}；处理 {m['processed_token']} / RVA {m['processed_rva']}；源行 {m['line']}"
def put(n,s): (A/n).write_text(s.strip()+'\n',encoding='utf-8')
base='''
## 证据读取约定

Pxxx 均指处理后 MethodDef 的末三位，不能视为原 token。原/处理 token、RVA、原 IL 状态、体哈希及源行见 [method-index.csv](evidence/method-index.csv)。方法原/处理 IL 分别在 evidence/raw、evidence/processed；带行号摘录在 evidence/methods。原始受保护体多为占位；算法证据主要是去混淆体/处理 IL，并非原始占位体直接包含这些公式。

证据级别：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL/字段流/调用交叉恢复；E3 独立恢复代码验证（不是原 DLL oracle）；E4 原程序运行验证（本轮无）；N 规范解释/推断。恢复不等于合规性鉴定。
'''
put('overview.md','''# B3 RNP APCH — Round 6

状态：**PARTIALLY ACCEPTED**。两个独立业务类分别实现 LNAV 水平主副区/MOC 与带温度修正的 APV 数值超障面/当量障碍物高。APV 公式特征对应 Baro-VNAV；没有 SBAS 专用算法或自动导航规范调度证据。不能把组合窗口当作完整可操作进近设计系统。

UI 可达的是跑道拾取/交换、障碍物读取/坐标转换、LNAV 折线绘图、SOC/TP 小计算、标记、高亮和状态保存加载。LNAV P594、APV P5EE 主评价器均 **orphan evaluator**；APV 工厂 P470、两套最低标准后处理与 APV 结果表同样没有实际入口。未补接这些方法。

FAF 高度、名义距离及 APV 对应三维点的代码角色已确定；独立 MAPt 输入/点不存在，不能从规范补入。MCG 为主复飞爬升梯度输入；MDist/MStart/MEnd/MPdg 属于独立 SOC→TP 计算器。无统一 Procedure 对象，保存的是控件状态。

审阅入口：[事件图](event-map.md)、[LNAV](lnav.md)、[APV](apv.md)、[字段](field-semantics.md)、[规范差异](standard-mapping.md)、[验证](verification.md)、[收口与32问](../round6/closure.md)。

可审计材料包括108个核心方法、248个方法身份、56个事件绑定、字段/条件/调用索引、原/处理IL、31个机械恢复方法映射及独立测试；数量来自索引，不能代表已验证全部浮点输入。未操作 AutoCAD、未执行目标 DLL，Round 1–5 冻结。
'''+base)
# Full event identities, exact call sites and explicit behavior.
roles={'476':'ScreenData；SelectAll POINT','478':'坐标转换→12列展示；不调用评价','479':'THR GetPoint','47A':'RWY end GetPoint','47C':'LNAV CAD','47E':'载入.rnp状态','47F':'保存.rnp状态','483':'GetEntity载入状态','484':'ID查找并高亮；无居中','485':'剪贴板→ThrToSoc','486':'剪贴板→SocToTp','487':'NDist→剪贴板','488':'MDist→剪贴板','489':'SOC→TP估算','48A':'NPA SOC估算','48B':'交换跑道六字符串','48C':'Mark','474':'config load','475':'config save/unhighlight','46E':'仅基础版提示','4B1':'仅基础版提示','4B0':'空体'}
head=['# 完整事件图','','绑定可达指静态事件委托可到达，隐藏控件另列；不等于用户在当前许可/布局中一定能点击。原始和处理方法名/签名由 method-index.csv 展开。全部直接callee含IL偏移见 direct-calls.csv。','','|Control.Event|Handler / 原token(RVA) / 处理token(RVA)|直接callee（内部P号；外部完整名在索引）|判定/行为|','|---|---|---|---|']
for e in events:
 t=e['handler_tokens'];m=ms[t];short=t[-3:];cs=[x for x in calls if x['caller']==t];cal='; '.join(x['target']+'@'+x['il_offset'] for x in cs)
 role=roles.get(short,'共同数字校验；不重算' if '48D'<=short<='4AD' else '绑定适配/事件处理，见方法摘录')
 kind='bound but only prompt/stub；隐藏' if short in ['46E','4B1','4B0'] else 'bound and reachable'
 head.append(f"|{e['control_name']}.{e['event']}|{e['handler']} / {m['original_token']}({m['original_rva']}) / {t}({m['processed_rva']})|{cal}|{kind}；{role}|")
head += ['','## 未绑定与断链','','|方法|身份|实际作用|判定|','|---|---|---|---|']
for t,label in [('46F','APV14列表'),('470','APV工厂'),('471','APV最低标准/RVR'),('481','调用HL显示'),('482','HL显示'),('480','空体'),('4B3','LNAV最低标准/VIS'),('4B9','APV DH selector'),('4BA','LNAV OCH selector'),('594','LNAV主评价'),('5EE','APV主评价')]:head.append(f"|P{t}|{ref(t)}|{label}|"+('dead/unreachable；仅P481→P482' if t=='482' else 'unbound；无全局直接入边/IL引用')+'|')
head += ['','无 category SelectedIndexChanged、tab change、GP重算绑定。P48D–P4AD TextChanged 仅校验。button10/P46E、button9/P4B1、button8/P4B0 的 Visible=false。不能用控件标题补调度。','','[全局入边与IL引用](evidence/all-incoming.json)；[事件起点闭包](evidence/event-reachability.json)；[调用图DOT](evidence/callgraph.dot)。泛型MethodSpec解析见 methodspec-resolution.csv，防止遗漏SelectAll。']
put('event-map.md','\n'.join(head))
put('runway-frame.md','''# 跑道局部系

P47B 读取 textBoxLon1/Lat1/Z1（THR）和 Lon2/Lat2/Z2（跑道另一端），调用公共 **P0AC**，与 A7/B5 是 Same MethodDef。保存THR XYZ、两点XY长、正反bearing。B5 Form以DER为原点的参数顺序与B3不同；相同方法不能推成相同业务原点。

局部 +X 沿 RWY end→THR，指向进近入口前方；Y由该反向bearing确定。P0AD：x=L cos(bearing(THR→P)−reverseBearing)，y=L sin(...)，z=P.Z−THR.Z。两端Z不改变XY方向/长度。

重要区别：buttonAix/P478 用公共转换结果只覆盖障碍物 X/Y；结果记录从原点对象构造，**Z保留原绝对标高**。不能声称UI已经提供完整的APV相对Z链。APV工厂/评价器无UI连接，输入Z惯例须分别看算术，不能替它建立新适配器。

绘图 P47C 旋转局部点列（P821，reverseBearing）再平移THR XYZ（P823），writer经Point2d丢弃Z。B3没有B5的ZeroZ调用，但最终同样只存XY折线。取点取消公共P113返回Origin，现有事件未统一拒绝该值。

证据：P47B行47206、P478行47141、P47C行47219，及公共P0AC/P0AD；身份见method-index。
''')
put('lnav.md','''# LNAV 业务链

P47D→P593 参数依次为 `(IfSegLen,FafAlti,Z1,VPA,TCH,MCG/100,ThrToSoc,SocToTp)`。不读取类别、风、TpAlti或独立MDist计算器。四条绘图轨迹在构造器一次建立。P594按沿程分支调用本类P595线性主副区计算；没有调用A9。

```text
THR/RWY-end → P47B公共frame
输入 → P47D → P593 → 四条点列 → P47C → 公共CAD
POINT → P476 → P477 → P478转换 → P4B2展示
                         （无通往P594的边）
独立P594 → P595 → LNAV记录（孤立评价链）
```

LNAV SOC小工具P48A使用P793的TAS，`Round((TAS+wind)*NTime/3.6+444)`。类别不参与；时间为输入默认18s，bank固定15°，风/IAS各自kt开关×1.852。其输出NDist需要复制/粘贴进ThrToSoc；没有自动同步。

复飞仅直线延续、15°扩张及固定终宽，没有指定点转弯、左右转、风螺旋或实际TP转弯曲线。代码把THR至SOC和SOC至TP之和当作终止站距。详见点位表及评价分支，不能把几条开放折线命名成已裁剪封闭保护多边形。
''')
put('lnav-fix-geometry.md','''# LNAV 定位点与绘图几何

定义 `d=(FafAlti−Z1−TCH)/tan(VPA)`，`I=IfSegLen`，`s=ThrToSoc`，`t=SocToTp`。单位m、角度deg；局部坐标THR=(0,0)，+X指向进近方向。下表字段末尾对应P593点字段，不额外建立导航数据库fix。

|代码点|坐标(X,Y)|来源/手动或计算|下游|
|---|---|---|---|
|THR / 008D|0,0|THR人工/文本，局部原点|最后/复飞分界|
|A / 0088|d+I,4630|计算|绘图及中间段入口|
|B / 0089|d+3369,4630|计算|绘图、分段|
|F / 008A|d,2685|FafAlti计算|FAF名义站距/评价；未直接列入外轮廓|
|C / 008B|d−1604,1759|计算|最后段收缩控制|
|D / 008C|444,1759|计算|固定沿程容差偏移/扩张起点|
|E / 008E|−6814,3704|计算|固定终宽控制|
|SOC / 008F|−s,(444+s)tan15°+1759|s主输入；可粘贴小工具结果|MOC转换、复飞评价；不在六顶点绘图列表|
|END / 0090|min(−(s+t),−6814),3704|终止距离计算|绘图/复飞延伸|
|TP业务距离|−(s+t)|主参数相加|评价总范围下界；没有真正转弯点/曲线|
|MAPt|没有独立字段/坐标对象|固定444与入口共同定义简化模板|不能标为任意可移MAPt|

四条开放轨迹按 `[A,B,C,D,E,END]` 构造，Y倍率依次1、0.5、−0.5、−1。4630/2685/1759/3704为模板外侧半宽，副区内界取其一半。此绘图模板与评价分段不完全相同（评价另用d−444、256.3、119等），不得用图面轮廓替换算法。

s+t<6814时，绘图仍延到−6814，主评价却在−(s+t)截止；这是保留的行为差异。MDist小工具不会直接重建这些点。
''')
put('lnav-obstacle-evaluation.md','''# LNAV 障碍物评价

**主方法P594**；**分段helper P595**。前者全局无入边，后者由前者调用。P594先令area=out；总体要求 `x≤d+I`、`x≥−(s+t)`、`|y|≤4630`，随后按下表顺序选段；helper端点可能再次排除阈值上的点。

|条件（从上向下）|局部输入x/长度L|外半宽W0→W1|主区MOC|
|---|---|---|---|
|x≥d+3369|x−(d+I), I|4630→4630|150|
|x≥d−444|x−(d+3369),3813|4630→2428.7|150|
|x≥d−1604|x−d+444,1160|2428.7→1759|75|
|x≥444|x−d+1604,d−1604−444|1759→1759|75|
|x≥0|x−444,444|1759→1878|75|
|x<0，初始复飞|见下|1878→SOC宽度|75或min(75,s*g+30)降至30|
|SOC之后至−6814|x−SOC.X,SOC.X−E.X|SOC宽→3704|30|
|−6814之后|x−E.X,E.X−END.X|3704→3704|30；另检查总长度|

初始复飞：`u=45/g`。u<s时，分成[0,SOC.X+u]的75段和[SOC.X+u,SOC.X]的75→30段，连接宽`1759+(s−u+444)tan15°`。否则一段从min(75,s*g+30)降至30。g为MCG/100；零或负g不加保护。具体新记录、坐标平移、分支/返回均保存在机械源码；见 condition-expressions.csv、branch-sites.csv 和P594 IL，未根据规范重排退化点。

P595：`−L<x≤0` 且 `absY<max(W0,W1)`；内界w/2、外界w都是端点宽度的线性插值。M=`M1+(M0−M1)*(L+x)/L`；内界以内主区M；副区MOC=`M*(w−absY)/(w−w/2)`，外界以外out。外侧最大宽处因预筛严格小于，端点/角点不统一包含。

结果字段：area=`_0088_008F_009C`，MOC=`...009D`，OCA=`...009E`，OCH=`_0088_0090_0086`，MDA/MDH/VIS=`...0087/0088/0089`（由P4B2表头证明）。主评价将 **Z+MOC写进OCH字段**，OCA仍为0；复飞中间段另把`(SOC.X−x)*g`写MDH。绝不按通常OCA/OCH含义修正。

P4B3孤立后处理：MDH最低90；否则Round(MDA−THR)，MDA不足时设THR+90。能见度按MDH/tan(angle)−灯光距离，<5000按100进位，其余1000进位；依灯光/类别设置800/1200/1600下限，并按相关参数3000阈值封顶5000/8000。完整保留于RnpApchForm.Recovered.cs，UI未调用。

独立fixture(1000,0,100)：MOC75、OCH175、OCA0；不代表原DLL运行。不存在final+missed批处理合并、最大OCA排序或去重调度证据。
''')
put('apv.md','''# APV / Baro-VNAV 数值业务链

Form工厂P470（孤立）→P5ED，参数依次为 `(IfSegLen,FafAlti,Z1,VPA,TCH,comboBoxHi,MCG/100,ThrToSoc+SocToTp,AdElev,Temp,comboBoxCat)`。IL中第一个IfSegLen压栈后跨局部赋值保留，11参数签名与newobj一致；不是丢失参数。

主输入不包含DH、HLcor文本、comboXz、comboBoxGP、textBoxPDist、textBoxElev、TpAlti。故候选`SOC高度=DH−HLcor`及`THR-SOC=(DH−HLcor)/tan+Xz`未在B3形成计算链。只有Z面起点Xz与主输入指定的复飞总距离。该结论不把A2公式移植进B3。

温度修正、FAS斜率/起点、水平面、Z面和侧面数值均已恢复，详见apv-surfaces。P5EE对单个障碍物分段，P5EF作主副区面高/比例，穿透时P5F4作当量高。P5F0插值、P5F1类别Xz、P5F2类别HL、P5F3温度项。各方法身份见索引，勿将P5F1误当评价后处理。

APV业务类没有点列表CAD生成器；不存在可达APV CAD surface writer。恢复的是数值曲面分段，不能宣称已经生成拓扑闭合3D面。没有B3调用A5 W/X/Y/Z系数库或OAS数据库的证据。
''')
put('hl-correction.md','''# HL：显示支路与业务支路

|类别|HLm|HLr|
|---|---|---|
|H|35|8|
|A|40|13|
|B|43|18|
|C|46|22|
|D/未知|49|26|

APV **P5F2** 根据comboBoxCat计算：基础HLm；AdElev>900加`HLr*0.02*AdElev/300`；VPA>3.2再加`(VPA−3.2)*HLr*0.05`。无round，无上限。未知类别默认为D。表中的H为额外实现项，规范引用不因此自动涵盖。

Form **P482** 从AdElev、HLm/HLr文本计算显示：>900时Round(和,2)，否则复制HLm原文字，不含GP项。P481是唯一调用者且本身未绑定；所以没有实际事件驱动的类别/GP/标高自动重算。TextChanged仅验证，配置可保存陈旧显示。D/1800显示52.12不是所有APV构造输入下的值。

A2 P239显示支路同一高机场算术，但不同MethodDef，且A2还外层round到一位；B3没有直接调用A2。APV主类另按类别重新算HL，根本不读HLcor文本。

与2020规范PDF515页4.5.2.2对照：规范每增加0.1°加5% HLr；代码直接以角度差直接乘0.05，缺少0.1换算（如D、3.3°：代码增0.13，条文增1.3）。记录为Different from current standard/实现依据待确认；不修代码。
''')
put('faf-fap-mapping.md','''# FAF / FAP / MAPt 映射

|Source field / UI|代码作用/坐标|保护用途|规范解释（N）|证据|
|---|---|---|---|---|
|textBoxFafAlti / FAF高度|绝对标高H；LNAV/APV都算d=(H−Z1−TCH)/tanVPA|LNAV F=(d,2685)，APV `_008A_008C_0086`=(d,2685,H−Z1)|与公布垂直航径在程序高度的交点计算相容，APV代码角色可解释为名义FAP；不证明与数据库LNAV FAF同一fix|P47D/P470/P593/P5ED E1/E2|
|textBoxZ1 / THR Z|入口标高；垂直基准|d、温度项及面高|THR参考|同上|
|textBoxTCH|基准高m|d、FAS起点|RDH候选|同上|
|comboBoxHi|固定输入q|温度修正后的FAS起点/侧面余度|Hi；代码单值，不自动分层|P470/P5ED|
|textBoxPDist|禁用显示默认0|无主业务消费者|不能据名字认定FAP坐标|控件引用索引|
|MAPt|无独立坐标/可移输入|固定444及THR简化模板|规范允许MAPt在THR前移动；代码不提供该关系|构造/字段/事件穷举|

2020规范PDF511页4.3.2区分FAP（垂直航径与前序高度交点）和LNAV FAF/MAPt（平面构型/编码）。本实现共用一个高度计算名义距离，未存储两种导航fix身份。这个代码关系已经确定；不能说“FAP所有作用未知”，也不能擅自把二者等同为一个航路点。
''')
put('apv-surfaces.md','''# APV 数值保护面

P5ED定义 `h=FafAlti−Z1`，`v=tanVPA`，`q=Hi`，`g=MCG/100`，`d=(h−TCH)/v`，`S=ThrToSoc+SocToTp`。

温度项P5F3：`n=Temp−15+Z1*.0065`；`tc=−n/(−.0065)*ln(1−.0065*h/(288.15−.0065*Z1))`。输入机场高度在此为Z1，HL支路为AdElev，不能互换。`x0=(q−TCH)/v+444`；`a=(h−tc−q)*v/(h−q)`；`xF=(h−tc−q)/a+x0`；`xI=xF+150/a`。a低于tan2.5或高于tan3.5只提示，不中止。NaN/Inf和负值保留。

|点字段尾码|XYZ / 定义|业务数值作用|
|---|---|---|
|8B9D / A|d+I,4630,0|中间段远端|
|8B9E / B|d+3369,4630,0|中间段宽度过渡|
|8C86|d,2685,h|名义FAP高度/沿程参考|
|8C87 / C|d−1604,1759,(d−1604−x0)*a|最后段固定宽起点|
|8C88 / D|444,1759,0|地面侧面降为30的点|
|8C89|0,0,0|入口参考|
|8C8A / E|−6814,3704,(xz+6814)*g|Z面终宽点|
|8C8C / END|min(−S,−6814),3704,(xz−endX)*g|Z面末端|
|8C8D / I|xI,1759+(xI−C.X)tan30,h−q−tc+150−q|中间与最后面重叠起点；**保留双减q**|
|8C8E / F|xF,1759+(xF−C.X)tan30,h−q−tc|FAS接前段|
|8C8F / H|x0,1759,0|FAS地面交点|
|8C90 / Z|xz,1759+(444−xz)tan15,0|Z面起点|

面高由各段两端XYZ插值，横向主区半宽w/2；侧面在w/2→w由基面升高0→该段MOC。不是一个统一plane equation对象。数值上含中间平面、斜FAS、水平地面、倾斜Z面和对应侧面；没有Surface/Solid/Face CAD对象或闭合拓扑。

P5F1 Xz仅依类别：A/B−900、C−1100、D及未知−1400。VPA、DH、机场标高不修正Xz，comboXz不被读入。单一q输入未自动生成2020规范要求的5000/10000ft分层FAS′/FAS″。外侧界计算与LNAV模板相关但没有IntersectWith/裁剪/包络拼接。
''')
put('apv-obstacle-evaluation.md','''# APV 障碍物评价

P5EE主调度，P5EF单段helper，P5F0线性插值，P5F4当量高。主方法无UI入边；以下是恢复方法算术，不虚构可达工作流。

## 单段P5EF

X在端点闭区间内才处理；越界提示“数据范围有误”并return，**不清除原record内容**。以absY判域；端点插值得w(x)、基面z(x)、MOC(x)，相同X的插值P5F0取两端纵值min。absY≤w/2主区，surface=z，factor=1；w/2<absY≤w副区，surface=`z+MOC*(absY−w/2)/(w/2)`，factor=`2*(w−absY)/w`；更外侧out。

## 沿程主分支（P5EE按此顺序）

|位置/条件|调用点对 / MOC|结果行为|
|---|---|---|
|x>A.X|无|out|
|A.X≥x>B.X|A→B /150,150|中间段，MOC=factor*150；surface=FafAlti−MOC，OCA=Z+MOC，OCH=OCA−Z1|
|B.X≥x>I.X|B→F /150,150|同中间段|
|I.X≥x>F.X|I→F /q,q|主区用150；副区再构造一套I′→F /150,150，比两种surface，区分中间副区/最后副区|
|F.X≥x>C.X|F→C /q,q|最后段；penetration=Z−surface，再surface加Z1|
|C.X≥x>H.X|C→H /q,q|最后段同上|
|H.X≥x>444|H→D /q,30|水平段侧面渐变|
|444≥x>xz|D→Z /30,30|水平段|
|xz≥x>−6814|Z→E /30,30|复飞段|
|−6814≥x≥END.X|E→END /30,30|复飞段|
|x<END.X|无|out|

阈值以既有点位为准；退化输入可能破坏其沿程排序，代码没有排序修复。重叠处是同一个障碍物的内部候选面比较，**不是一键评价合并**。中间分支与最后/水平/复飞分支混有绝对/相对标高表达，恢复不统一Z。详见P5EE IL及机械代码。

## 穿透后的P5F4

r=cot(VPA)，u=1/g，HL=P5F2结果，Xz=P5F1。factor字段`_0088_0090_008D`在helper中是比例，在主方法后变成HL，不能赋予单一恒定语义。

- 主区：若x<Xz或Z>(x−Xz)*tanVPA，则 `Ha=Ceiling((Z*u+x−Xz)/(r+u))`，OCH=Ha+HL；否则OCH=Z+HL。
- 副区：e=30*(1−factor)。同上判别但比较面增加e；若当作复飞障碍物，则 `Ha=Ceiling(((Z−e)*u+x−Xz)/(r+u))`，**改写为全HL**，OCH=Ha+HL；否则OCH=Z+factor*HL。
- 非穿透：主方法通常只factor*=HL，未必填写OCH/OCA。未知旧字段不自动归零。

P471孤立最低标准：OCA=OCH+THR，DH=Ceiling(OCH/5)*5，DA=Round(DH+THR)。RVR初算DH/P3−P2，<800按50进位、<5000按100、否则1000；上限5000/8000由高度条件决定。虽然类别/灯光分支写过下限，末尾IL_02BA又用num2覆盖RVR，**最终不保留这些下限**。完整机械方法保留该覆盖。

表P46F为14列：ID、名称、XYZ、区域、面高、穿透、HL、Ha、OCH、DA、DH、RVR。P46F与P471均孤立，没有UI到完整评价结果展示的链。
''')
put('missed-approach.md','''# LNAV / APV 复飞边界

LNAV主工厂使用s=ThrToSoc、t=SocToTp、g=MCG/100：SOC.X=−s，评价截断x=−(s+t)，初始MOC向30下降，中间段另计算(SOC.X−x)*g。绘图外侧从(444,1759)至(−6814,3704)，对应15°扩张；并延伸至min(−(s+t),−6814)。SOC和端点不代表已经执行转弯。

APV使用同一总距离但没有独立SOC高度公式。Z面从类别Xz开始、gradient=g，使用数值侧面和当量高。未读取DH−HLcor；TpAlti未进入任一工厂。不存在指定高度/点/电台、KK′/C或转弯终向选择链。

B3核心对A8 turn evaluator、B5 PBN turn geometry、Spiral86均无直接业务调用；P793只供SOC的TAS。类名“missed”或字段“TP”不能证明存在风螺旋转弯。左右转fixture标为不适用，并记录缺项，不能构造新转弯实现来通过测试。
''')
put('turn-parameter-usage.md','''# P793 在 B3 中的实际消费者

唯一B3直接构造P793的业务事件为P48A NPA SOC。参数IAS、NAlt、固定bank15、wind、NTemp，IAS/wind的单位开关各自乘1.852。直接消费字段仅TAS `_008A_009D_009A`，再加风和时间及固定444。

同一P793构造器内部仍算出半径、转弯率等通用字段；这些构造副作用不等于B3消费。B3没有把其C6/半径/风螺旋值交给P593或P5ED，没有PDA/required-gradient输出。MDist估算不调用P793。A2、A7、B5共享的是P793 MethodDef，后续业务算法不同。

TAS=`IAS*171233*sqrt(288+Temp−.006496*Alt)/pow(288−.006496*Alt,2.628)`；主保护几何不读取风/类别（LNAV）或速度（APV）。输入值域错误的旧NaN/Inf不截断。
''')
# Auditable all-control reference inventory plus key semantic table.
put('field-semantics.md','''# 字段语义与数据流

所有命名控件的声明、初始化、setter/reader及所在P号/源行见 [control-references.csv](evidence/control-references.csv)；精确字段token/IL读写见 field-flow.csv。数字TextChanged只做公共校验，状态加载/反序列化也可赋值，不代表重新计算。

|Field / UI control|Setter|Reader|Unit / Formula|真实角色|
|---|---|---|---|---|
|MDist / textBoxMDist|初始化8000；P489计算|P488复制剪贴板|m；Round(100*(MEnd−MStart)/MPdg)|禁用显示：独立SOC→TP估算输出，不是几何直接参数|
|MStart / textBoxMStart|初始化100；文本/状态加载|P489；数值校验|m；SOC起始高度|不是保护宽度|
|MEnd / textBoxMEnd|初始化300；文本/状态加载|P489；校验|m；转弯高度|不是末宽|
|MPdg / textBoxMPdg|初始化2.5；文本/状态|P489；校验|百分数；分母不除100而分子乘100|独立距离估算爬升梯度|
|MCG / textBoxMCG|初始化2.5；文本/状态|P47D、P470，之后P594/P5ED/P5F4|输入%→g=value/100|**missed climb gradient**；主复飞爬升梯度，不是required-gradient输出|
|ThrToSoc / tbThrToSoc|主输入默认2000；P485粘贴|P47D/P470|m；LNAV SOC.X=−s|主几何SOC站距；不自动读取NDist|
|SocToTp / tbSocToTp|主输入默认8000；P486粘贴|P47D/P470|m；TP总距=s+t|主复飞终止距离；不自动读取MDist|
|TpAlti / textBoxTpAlti|初始化300；输入/状态|仅校验/保存|m|名义转弯高度输入，未进入几何/评价|
|IfSegLen / textBoxIfSegLen|10000；输入/状态|P47D/P470|m|中间段长度|
|FafAlti / textBoxFafAlti|900；输入/状态|P47D/P470|m，绝对标高|名义FAF/FAP高度；d公式见点位表|
|Z1/Z2 / runway text|拾取P479/P47A、交换P48B、状态|P47B；Z1另进两工厂|m|THR/跑道另一端标高，XY长度不读Z|
|VPA / comboBoxVPA|3.0；输入/状态|两工厂|deg→tan|主垂直航径角|
|TCH / textBoxTCH|15；输入/状态|两工厂|m|入口基准高|
|Hi / comboBoxHi|75；状态|P470|m|APV单一面余度q|
|AdElev / textBoxAdElev|0；输入/状态|P470→P5F2；孤立P482|m|APV HL高机场修正；非温度函数基准|
|Temp / textBoxTemp|−20；输入/状态|P470→P5F3|°C|APV温度项；P5F3高度基准用Z1|
|category / comboBoxCat|D；状态|P470→P5F1/P5F2|类别字符串|APV Xz/HL，不是LNAV分类输入|
|NIAS/NAlt/NWind/NTemp/NTime|380/900/19/15/18；状态|P48A|km/h或kt、m、°C、s|独立NPA SOC小工具|
|NDist / textBoxNDist|默认2300；P48A|P487复制|m；Round((TAS+wind)*time/3.6+444)|输出需粘贴才能影响主几何|
|DH / textBoxDH|默认60；状态|校验/保存，无主工厂读取|m|APV候选显示/输入，计算断开|
|HLm/HLr/HLcor|49/26/52.12；状态；孤立P482写HLcor|P482读HLm/HLr；主工厂不读HLcor|m|显示小工具，与P5F2独立|
|comboXz/comboBoxGP/comboBox1/comboCat|设计器/状态|无主工厂消费者|m/deg/类别|附加设置候选；无类别事件联动|
|PDist/Elev/LGT等附加项|控件/状态|本轮已索引所有reader，未进入两工厂|控件单位/文本|不能按名字补FAP/SOC计算；LGT原名确为textBoxLGT|

身份与原始字段名以CSV为准。控件初始值和config载入后的值分开：默认不保证运行时生效；配置可包含陈旧控件路径。没有将字段语义未知作为回避理由：MCG与四个M字段已由真实算式、标签和消费者确定。
''')
put('obstacle-evaluation.md','''# 公共障碍物入口与两套评价记录

button3/P476→公共泛型SelectAll P10D<DBPoint>（MethodSpec 2B00000D），读取ModelSpace POINT；未见Take(5)。P477对全列表解析名称/XYZ并以递增ID建立DBPoint字典。P478 foreach全列表，保留原Z仅转换X/Y，写P4B2的12列表；没有评价。

button18/P48C按当前选中行ID反查原DBPoint，公共Mark P09C→obst块与P09E Altitude=原DBPoint.Z。P484绑定CellClick及CellContentClick，先取消全列表高亮，再高亮ID对象；无视图居中调用。

LNAV与APV的记录类型互相独立，无统一最危险结果集合；两主评价器都是孤立方法。单个APV内部比较两候选副面，不是外层final+missed+APV merge。无max OCA/max required gradient、去重、多行优先或排序实现。详情分别见lnav-obstacle-evaluation.md、apv-obstacle-evaluation.md。
''')
put('cad-output-map.md','''# CAD 实体与顺序

主可达路径 **button6→P47C→P47D/P593**，仅LNAV四条六顶点列表。旋转P821→平移P823→P087公共writer。

|顺序/实体|方法|来源/属性/业务角色|
|---|---|---|
|1 内存Group|P087|先建尚未入库的Group|
|2–5 Polyline|每列表P12D→P12A Point2d→P134 AddVertexAt|四条开放轮廓：外侧正、主副界正、主副界负、外侧负；每条6顶点；bulge/startwidth/endwidth=0|
|每条入ModelSpace|P089|单实体append并写WsObject文本；加入Group|
|末尾Group入库|P087|包含四折线；未设置Group.Description，文本参数用于实体XData|
|独立Mark BlockReference|P48C→P09C|obst，插在原障碍物位置；Altitude属性由P09E写原标高|

没有 Closed=true 或重复首顶点，无显式layer/color/linetype配置。Point2d使绘图Z丢失；未实现三维APV面writer。未发现该绘图链创建Line/Arc/Circle/DBText；Mark块内既有内容不能冒充B3新建面几何。没有单独跑道实体绘制。

[connection-api-sites.csv](evidence/connection-api-sites.csv)逐IL收录Polyline/Arc/XData/选择/Erase等关键词及覆盖数。核心保护区衔接通过固定顶点、15°/30°直线和数值分段编码；未见IntersectWith、Offset、裁剪、切线、包络、Erase后重建保护区链。开放折线的视觉衔接/后续外部编辑不属于已自动恢复的规则。
''')
put('xdata-schema.md','''# XData

P47C先生成 `FormApvEvl\\n` 再P0FB遍历控件，把**完整序列化文本**传给P087/P089。

|实体/位置|数据|
|---|---|
|每一条Polyline|1001=WsObject；1000=完整控件状态（头+多行dotted path:value）|
|Group|未设置Description；未显式写Group XData；完整状态只写各Polyline|
|Mark的obst|Altitude为块Attribute，不能称为APV XData|

B3此链不写WsCalcuLine、Radius、Kind、RNP/APV面系数或类别结构化元数据。状态文本当然可能含HL等控件值，不等于存在独立HL元数据字段。

**button2/P483** GetEntity选择保护区实体，取整个XData.AsArray()[1]的Value后P0FD按FormApvEvl回填；未限定RegApp、未检查数组长度/语义schema。不存在自动匹配最新保护区或相交面功能。无XData时提示，选错其他App数据时保留旧异常/格式不符行为。
''')
put('persistence.md','''# 保存/载入的真实格式

P47F保存、P47E加载UTF8 `.rnp` 文本；P0FB/P0FC遍历支持的控件，路径以父控件名`.`拼接，写 `path:value\\n`，头为 `FormApvEvl`。不是XML/JSON，也不是按航段建模的Procedure数据。字段由控件adapter取Text/SelectedIndex/bool等，不能把所有控件都强制理解为Text。

```text
FormApvEvl
tabControl1....textBoxFafAlti:900
tabControl1....comboBoxCat:3
```

上例路径中省略号只用于示意；真实路径见保存遍历/控件引用索引。P0FD按CRLF/CR/LF及RemoveEmpty分行，首行精确比较FormApvEvl；每行Split(':')后用[0].Trim与[1].Trim。额外冒号被截断；缺冒号/空文本会越界；未找到控件跳过；没有转义/版本化schema。控件适配器类型按共享原实现，测试只覆盖扁平支持控件的文本记录，不冒充实际WinForms类型setter。

Form Load P474→P0F6、Closed P475→P0F4另使用程序集目录config.xml，节点Document/FormApvEvl，dotted控件key。它与.rnp文本的格式不同。配置可覆盖设计器默认/含已不匹配的路径；未改原配置。文件选择和实体选择都只恢复UI状态，不自动重新评价。
''')
put('cad-interactions.md','''# CAD 人工交互与自动化边界

|入口/API|用户选择的业务对象|软件不能自行决定的原因|进入计算/数据流|可由已有数据推导？|
|---|---|---|---|---|
|button5 P479→P113 GetPoint|跑道THR|图元没有被绑定为当前跑道入口语义|Round XY两位，Z原值→Lon1/Lat1/Z1→frame/两工厂|已有坐标即可省去拾取；当前无可信跑道对象自动识别|
|button4 P47A→P113 GetPoint|跑道另一端|需要当前跑道方向/端点身份|Lon2/Lat2/Z2→frame|若已有两端点及THR身份可推导；无自动几何匹配|
|button2 P483 GetEntity|要载入参数的RNP保护区实体|可能存在多套绘图；无当前procedure关联|实体XData[1]→控件恢复|可按WsObject文本检索候选，但无法凭现有状态唯一决定用户意图|
|button3 P476 SelectAll POINT|软件自动收集Model DBPoint，不是用户逐个选择|仅类型过滤，没有现行procedure/保护区关联|全列表解析、ID字典、展示|全列表已自动；不能宣称按区域选障碍物|
|表格行与Mark/Highlight|用户要查看或标记的障碍物行|无自动最危险障碍物排序规则|行ID→原DBPoint→高亮或obst块|已有ID可定位；评价调度断开，不能自动确定最危险行|

本链未出现GetSelection式保护区交集选择。GetPoint取消返回Origin未统一校验；GetEntity需PromptStatus5100。无根据图形手选来补足intersect/clip的编码证据；外部人工编辑可能是工作流程，但本轮未做宿主观察，标为尚未运行验证。
''')
put('standard-mapping.md','''# 代码完成后的规范映射

基线：AC-97-FS-005，民航规〔2020〕12号。原PDF路径/全SHA256见evidence/standard-excerpts.json；PDF第499–519页摘录从冻结缓存读取并重新校验原PDF。以下用**PDF物理页号**，避免正文OCR页码倒序。仅作行为对照，不判软件整体适航/合规。

|已恢复行为|条文/PDF页|分类|结论与差异|
|---|---|---|---|
|LNAV最后主区MOC75，副区线性衰减|III-3-3 3.2.3–3.2.4，504–505|Matches current standard（局部规则）|75与副区原则一致；不能覆盖全部端点/航段设计|
|固定THR/444模板，无可移动MAPt对象|3.3.1–3.3.2，505|Author simplification|条文MAPt为飞越航路点且可向FAF移动；代码不建该对象|
|15°复飞扩张|3.3.4.2，505|Matches current standard（局部形态）|固定6814/3704、TP长度与其他终止规则仍不能仅凭角度宣布符合|
|APV FAS温度斜率和起点x0|4.3.4.2.5，512|Matches current standard（表达式结构）|h−tc−Hi与444，公式相符；不等于全温度模型验收|
|2.5/3.5角度检查仅提示继续|4.2.1、4.3.4.2.2，509–512|Author simplification|提示不能代表规范要求的程序限制已执行|
|单q，不自动分层FAS′/FAS″|4.3.4.2.4–.6，512–513|Different from current standard|未实现5000/10000ft自动转换；不能以用户手输Hi替代分层|
|APV FAP名义d与LNAV FAF共高输入|4.3.2，511|Implementation basis unresolved|代码角色确定，缺少规范分开的fix身份/程序终止关联|
|Xz A/B−900 C−1100 D−1400|4.3.4.4.2，513|Matches current standard（基本表）|常量来源可解释，不因此认定作者版本|
|Xz不受AdElev/VPA影响|4.3.4.4.3，513|Different from current standard|高于900m或VPA>3.2时条文另算min值；实现没有此分支|
|HLm/HLr A–D表|表III-3-4-2，515|Matches current standard（表值）|H35/8和未知回退D为额外代码行为|
|HL机场修正HLr*.02*elev/300|4.5.2.1，515|Matches current standard（表达式）|只在>900触发；显示/主业务round不同|
|HL陡角度增量(gp−3.2)*HLr*.05|4.5.2.2，515|Different from current standard|条文每0.1°加5%；代码没有÷0.1，增量为其1/10；原样保留|
|地面/侧面75或q降至30、Z面g|4.3.4.3–.4，513|Matches current standard（结构）|分段数值面，没有CAD拓扑闭合证明|
|当量障碍物高、侧面减e、全HL|4.4.1–.3，514–515|Matches current standard（公式家族）|实现额外Ceiling及字段复写/基准问题单列，不对全链背书|
|无所有障碍物max OCH调度|4.4.4，515|Different from current standard（可执行范围）|规范取进近与复飞最大值，B3没有可达批处理/合并|
|SOC小工具+444、固定宽度、APV双减q|本段未找到足够独立依据|Implementation basis unresolved|与简化模板相关；不能修成规范值|

未识别到足以鉴定其他具体ICAO Doc8168版次/旧国内规范的证据。Older-version candidate没有被强行分配到某条；所有历史归因统一标“**实现依据待确认**”。差异不自动证明是旧版依据，也可能是作者简化/代码错误。
''')
put('unrecovered.md','''# 未恢复/未证明边界

1. 原程序集算法常为受保护占位；已用处理IL/字段/事件恢复业务。没有原DLL或CAD动态oracle，本轮不得运行它们。
2. 两主评价器无调用入边；APV工厂/结果展示/最低标准、LNAV最低标准均断开。没有可恢复的完整一键合并链，未补调用。
3. APV数值分段面已恢复；不存在可达APV绘图或3D面闭合链。FAP/FAF代码角色已定位，但无独立导航fix身份；MAPt对象/可移位置不存在。
4. 无左右转、风螺旋、C/KK′、指定高度/点转弯业务链，TpAlti只保存/校验。不是因反编译未完成而故意省略。
5. AutoCAD事务失败/已有RegApp组合/控件实际类型setter未做动态验证；扁平序列化和CAD记录测试不能代替这些验证。
6. 规范差异和历史来源见standard-mapping；“实现依据待确认”不影响保留已确定旧算术。MCG、MStart、MEnd、MPdg、MDist语义已解决，不列为未知。
''')
# Detailed comparison rows use the actual frozen method identities, not numeric coincidence.
def comp(name,items):
 with (O/name).open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=['item','B3','other','classification','evidence']);w.writeheader();w.writerows(dict(zip(w.fieldnames,x)) for x in items)
comp('a2-b3-comparison.csv',[
 ('NPA SOC','P48A Round((TAS+w)*t/3.6+444)','A2 P233 (TAS+w)*t/3.6; displayRound','Different formula','No B3 direct call to P233; +444 retained'),
 ('PA SOC','P470/P5ED do not read DH/HLcor; no PA SOC helper','A2 P237 Round((DH-HLcor)/tanGP+Xz); HL0->-1','UI-only similarity','P470 input IL; no P237 call'),
 ('HL display','P482 Round(sum,2); orphan','A2 P239 Round(Round(sum,2),1)','Copied formula with different rounding','Different MethodDefs; source P482/A2 formulas.md'),
 ('HL business','P5F2 table + elevation + GP*.05','A2 P238/P239 table + elevation display','Different formula','No direct call; APV adds GP branch'),
 ('Xz','P5F1 category constant','A2 editable Xz in P237','Different formula','No direct helper; comboXz not used by B3 factory'),
 ('TP','P489 Round(100*(end-start)/percent)','A2 P23B same arithmetic (raw return/display separated)','Copied formula','Different MethodDefs; no P23B call'),
 ('C','No B3 C reader/geometry','A2 P241 C calculation','UI-only similarity (no B3 counterpart)','B3 core call index contains no P241 edge'),
 ('turn parameter','P48A new P793; consumes TAS only','A2 P793 via turn-input reader P854','Same MethodDef','Original P794/0xC3820 processed P793; downstream not same business')])
comp('a9-b3-comparison.csv',[
 ('geometry','P595 lines W/2 to W; APV P5EF numeric interpolation','A9 P330(IF)/P331(normal) PriSec helpers','Different implementation','No B3 call to A9; own token source/IL'),
 ('secondary MOC','P595 M*(outer-y)/(outer-inner)','A9 same linear taper family','Copied formula family; different MethodDef','B3 P595 != A9; compare frozen ObstacleData/pri-sec-evaluation.md'),
 ('segment inclusion','P595 -L<x<=0 and absY<maxW','A9 P331 normal -L<x<0; P330 IF inclusive endpoints','Different implementation','Endpoint conditions explicitly recovered'),
 ('terminal primary width','P595 ending W1/2; APV w/2','A9 IF ending W1 rather than half','Different implementation','Do not import IF endpoint behavior'),
 ('APV surface','P5EF inclusive X ends; secondary adds MOC to Z surface','A9 MOC output','Different implementation','P5EF/5F0; not interchangeable')])
comp('a8-b3-comparison.csv',[
 ('missed turn geometry','None; straight template only','A8 KK/turn-area chain','Different implementation','No B3 direct A8 business call'),
 ('obstacle evaluator','P594/595 and P5EE/5EF/5F4','A8 turn-area evaluator','Different implementation','Core outgoing-call index'),
 ('turn parameter','P793 TAS only in SOC','A8 turn input/turn geometry','Same MethodDef at shared model only','No C6/spiral/PDA consumer in B3'),
 ('C6/PDA/required gradient','No B3 counterpart; MCG is input','A8 turning evaluation quantities','Different implementation','P47D/P470/field-flow; no inferred reuse')])
comp('b5-b3-comparison.csv',[
 ('frame','P47B P0AC(THR,RWY-end)','B5 P4FF P0AC(DER,THR)','Same MethodDef','Parameter order differs; frozen B5 runway-frame.md'),
 ('turn geometry','No turn branch/TurnEnd input','B5 PBN turning classes','Different implementation','No direct B3 business ctor calls'),
 ('evaluator','B3 own LNAV/APV','B5 own PBN evaluator','Different implementation','No direct B3 call'),
 ('P793','P48A direct new; TAS->SOC','B5 direct same ctor for turning','Same MethodDef','P793 original P794; actual field consumers differ'),
 ('parser/ID/Mark','SelectAll P10D; parser P12F; Mark P09C/P09E','B5 shared helper family','Same MethodDef','B3 MethodSpec resolved; no Take(5)'),
 ('CAD writer','P087/P089 Polyline/Group WsObject','B5 same shared writer','Same MethodDef','B3 no ZeroZ but Point2d losesZ; full state text'),
 ('C6/PDA/required gradient','No counterpart; MCG input','B5 own turning quantities','Different implementation','No new B5 analysis; frozen comparison only')])
# Machine index of every direct segment call supplements compact prose tables.
segments=[]
for t in ['594','5EE']:
 text=(E/('methods/'+tok(t)+'.source.txt')).read_text(encoding='utf-8')
 for l in text.splitlines():
  if ('_0089_009C_0087(' in l or '_008A_008B_0097(' in l):segments.append(dict(method=tok(t),line=l.split(':')[0],source=l.split(':',1)[1].strip()))
with (E/'segment-invocations.csv').open('w',encoding='utf-8-sig',newline='') as f:
 w=csv.DictWriter(f,fieldnames=list(segments[0]));w.writeheader();w.writerows(segments)
print('accurate reports regenerated',len(list(A.glob('*.md'))))
