"""Round9 reports derived from recovered code and frozen previous-round evidence."""
from pathlib import Path
import csv,json,re,hashlib
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round9';A=ROOT/'recovered/A4-NavAidProtection';E=A/'evidence'
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def write(p,s):p.write_text(s.strip()+'\n',encoding='utf-8')
def out(p,rs):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
ms={m['processed_token']:m for m in rows(E/'method-index.csv')}
common='''
## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。
'''
def report(name,title,body,tokens=()):
 s='# '+title+'\n\n'+body.strip()+'\n'+common
 if tokens:
  s+='\n## 关键定位\n\n|P|原token / RVA|处理RVA|源行|证据|\n|---|---|---|---|---|\n'
  for p in tokens:
   m=ms['0x06000'+p];ref=f'evidence/processed/0x06000{p}.il.txt' if p!='2F6' else 'evidence/native-import.json'
   s+=f'|P{p}|{m["original_token"]} / {m["original_rva"]}|{m["processed_rva"]}|{m["line"]}|[证据]({ref})|\n'
 write(A/name,s)

report('overview.md','A4 导航设备保护区 — 静态恢复','''
**Round 9: ACCEPTED (static recovery)**，2026-10-28。仅表示本轮约定的静态恢复门槛满足，不代表规范全面合规、原程序运行等价或生产可用。

A4是VOR/NDB导航设施保护边界构造工具，不是障碍物评价器。设施选择先改写两档半宽标签和角度，Draw再从标签/文本读取参数。**不是两个独立几何引擎**，也不是A3定位容差或A6 Base Turn算法的别名。

|已闭合事项|真实行为|
|---|---|
|设施|仅VOR/NDB；小/大半宽分别1/2 NM、1.25/2.5 NM；角度7.8/10.3°|
|默认与可编辑性|默认VOR小半宽、双侧、中心线；15°关闭；角度TextBox设计器Enabled=false，宽度为RadioButton，不是自由输入框|
|几何|两拾点决定位置、方向及长度；每侧外边折线+半宽线；同一公式左右符号镜像|
|15°|从第二点作斜线与内外边界求交，替换终点并加斜边，非仅显示附加线|
|主副区|代码确有外边与0.5半宽线；可映射主区50%/两侧各25%的边界几何；没有独立面对象或MOC计算|
|CAD|2D Polyline，全体一个Group；无独立Line/Text；metadata参数空，故不写WsObject/XData|
|持久化|Load→P0F6、Closed→P0F4，config.xml/NavAids；原config无此节点，无便携TXT协议|
|跨模块|公共拾点、CAD、点线primitive真正同MethodDef；无A3/A6/A9业务调用|

## 导航

- [事件图](event-map.md)、[设施矩阵](facility-matrix.csv)、[输入及人工交互](input-frame.md)
- [VOR](vor.md)、[NDB](ndb.md)、[完整边界](boundary-geometry.md)、[15°线](15-degree-line.md)
- [主副区](primary-secondary.md)、[评价检查](obstacle-evaluation.md)、[CAD](cad-output-map.md)
- [XData](xdata-schema.md)、[config](persistence.md)、[规范映射](standard-mapping.md)
- [验证分层](verification.md)、[未验证项](unrecovered.md)、[20问收口](../round9/closure.md)

源码：NavAidProtectionForm.Recovered.cs机械保留P2F7–P2FA逻辑，外部输入/写CAD以独立适配器隔离；NavAidProtectionGeometry.Recovered.cs为同一几何的E2结构化读本，测试逐点与机械切片及独立局部坐标公式比较。复用冻结GeometryPrimitives，不修改旧轮。
''',['060','2F5','2F7','2F8','2F9'])

evt='''命令原P061/处理P060→检查同名窗口计数P05A→new Form _0089_008A→ShowModelessDialog。完整窗体只有五个绑定事件，没有clear/reset按钮或独立设施/航迹拾点按钮，取点包含在CAD按钮事件内。

```mermaid
flowchart TD
 Command[Y04 P060] --> Gate[P05A FormNavAids重复窗口检查]
 Gate --> Form[P2F5 ctor / P2FE designer]
 Form --> Load[P2FB Load / P0F6 config NavAids]
 VOR[VOR CheckedChanged P2F7] --> Labels[W1/W2标签 + ExpAng文本]
 NDB[NDB CheckedChanged P2F8] --> Labels
 Load --> State[窗体状态]
 Labels --> State
 State --> Draw[CAD Click P2F9]
 Draw --> Pick[P113 两次GetPoint]
 Pick --> Geom[XY长度/反向bearing/半宽/角度]
 Geom --> Center[可选中心线]
 Center --> Right[可选右侧]
 Right --> Left[可选左侧]
 Left --> Writer[P087二维Polyline与Group / P089空metadata]
 State --> Close[P2FC Closed / P0F4保存config]
```

|Control / UI text|Event|处理token|原token / RVA|处理RVA|分类|
|---|---|---|---|---|---|
'''
labels={'radioButton1':'VOR保护区','radioButton2':'NDB保护区','buttonNdb':'CAD','FormNavAids':'FormNavAids'}
for e in rows(E/'event-identities.csv'):evt+=f'|{e["control_name"]} / {labels[e["control_name"]]}|{e["event"]}|{e["handler_tokens"]}|{e["original_token"]} / {e["original_rva"]}|{e["processed_rva"]}|reachable|\n'
evt+='''
## 非事件控件与优先级

|功能|控制/读取|是否仅显示|
|---|---|---|
|width W1/W2|radioButtonW1.Checked决定选W1，否则选W2；读取所选按钮Text的数字部分|改变实际几何；无独立Changed事件|
|expansion|textBoxExpAng.Text→P2FA→弧度|设计器禁用；仍从文本读，config可回填；无TextChanged验证|
|left/right|checkBoxLeft/Right.Checked→分支|控制是否构造整个单侧列表；无独立writer|
|center|checkBoxCenter.Checked|只控制中心线输出，不影响边界计算|
|15°|checkBoxExpand.Checked|改变两个边界终点并新增斜边，不是单纯显示|
|facility point/track|CAD按钮里两次GetPoint|第2点同时决定长度，非仅方向|
|clear/reset|无控件/绑定/删除事件|No implementation evidence found in A4.|

P2F7/P2F8不检查自身radio.Checked；false/true状态变化都执行回填，最后实际执行的handler决定标签/角度。Draw不再检查VOR/NDB Radio；几何消费的是此前形成的文本状态。独立适配器明确控制事件次序，不宣称穷尽真实WinForms重入。checkBox没有事件不等于无效，它们都在P2F9读取。

P2F6为native user32.dll SetFocus，RVA0非stub。P300/P301为true/false不透明helper。没有发现orphan evaluator、prompt-only评价入口或stub业务按钮。可达闭包74个内部方法，含公共配置接口路径；MethodSpec解析到外部MemberRef，不漏记成内部业务。

[完整callee/CAD API身份CSV](evidence/event-identities.csv)、[事件闭包](evidence/event-reachability.json)、[MethodSpec解析](evidence/methodspec-resolution.csv)、[DOT调用图](evidence/callgraph.dot)。直接CAD API还包括公共P113的GetPoint与P087/P089/P134的数据库API，不能只看handler本身的外部调用。
'''
report('event-map.md','完整事件与可达性',evt,['060','05A','2F5','2F6','2F7','2F8','2F9','2FB','2FC','2FE','2FF'])

fac=[('VOR','Yes','P2F7 sets text -> common P2F9','W1=1.0 NM=1852m; W2=2.0 NM=3704m; angle7.8deg','P2F7 setter only; geometry P2F9 common','2 side paths each + optional15; one Group'),('NDB','Yes','P2F8 sets text -> common P2F9','W1=1.25 NM=2315m; W2=2.5 NM=4630m; angle10.3deg','P2F8 setter only; geometry P2F9 common','same writer/list structure')]
for n in ['LOC','DME','VOR/DME','NDB/DME','Other']:fac.append((n,'No','No implementation evidence found in A4.','N/A','N/A','N/A'))
out(A/'facility-matrix.csv',[dict(Facility=a,UI_available=b,Geometry_branch=c,Default_parameters=d,Dedicated_MethodDef=e,CAD_output=f) for a,b,c,d,e,f in fac])

report('input-frame.md','拾点、输入坐标与人工依赖','''
P2F9先SetFocus、隐藏窗体，P113提示“请输入保护区起点”得到S，再提示“请指定保护区终点”得到E。任一点等于完整三维Origin时恢复Visible并退出；Origin是真实坐标也被当取消哨兵。P113本身GetPoint遇错误重试、取消返回Origin。

S为施加所选设施起始半宽的窄端，通常可作为设施位置；**代码只称保护区起点，没有验证它是导航台**。E为指定保护区另一端，既确定方向又决定长度/15°起点，不能称仅方向点。没有台站ID、设施数据库、航迹实体或统一procedure对象。

```text
L = sqrt((Sx-Ex)^2+(Sy-Ey)^2)
theta = atan2(Sy-Ey,Sx-Ex)       // E→S反向角
u=(E-S)/L, n=(-u.y,u.x)        // 仅用于说明；原代码不除L
alpha = Parse(ExpAng.Text)*PI/180
w = Parse((W1.Checked?W1.Text:W2.Text).Trim().Split('n')[0])*1852
```

原实现直接以世界XY的S/E加极坐标位移；不把设施平移到局部原点再旋转回去。计算过`3π/2−theta`并一次规范化，但该bearing局部变量后续不消费。左右相对**拾点S→E**定义：Left在正n，Right在负n；若航空器按E→S向台飞行，其飞行视角左右与该绘图向量左右相反，不能混称。

Z不用于长度、角度、线系数：数值S/E及位移相加保留端点Z；15°求交产生新点Z=0。CAD最终Point2d忽略所有Z。没有高度保护面/超障计算。

## 人工交互及自动化可能（N层建议，非已实现）

|API/入口|业务对象|为什么由用户提供|消费者|已有数据能否推导|
|---|---|---|---|---|
|P113第一次GetPoint|窄端/设施位置候选S|无台站注册/ID/检索；仅点|所有起始偏移、L、theta|若已有设施坐标可代入；当前窗体无该关联|
|P113第二次GetPoint|航迹另一端/连接点E|无航段对象或设计终点规则|L、theta、远端宽度、15°两条线起点|若已有明确航段终点可代入；只知道方向不能唯一决定L|
|checkbox/radio|左右/中心/15°、半宽档位|由设计人员选择构造范围和参数|P2F9分支/文本读取|可由程序阶段/目标输出指定；原代码没有阶段自动判定|

没有GetEntity/GetSelection、自动拾取既有保护边、剪裁CAD实体或选前后窗口对象。设计人员可借输出作后续构造，帮助提示可用于转弯后飞向导航台；但代码没有自动求风螺旋切点、判断内外、包络或删除/重建已有图元。无法仅据静态缺失指定完整手工操作步骤。
''',['2F9','113','125','809','80A'])

report('vor.md','VOR参数与完整构造链','''
P2F7每次执行都将W1.Text=“1.0 nm”、W2.Text=“2.0 nm”、ExpAng.Text=“7.8”。默认设计器选VOR与W1，所以默认外半宽1852m；大档3704m。它不更改当前宽度档Checked，也不按距离自动换档。

P2F9不再读设施radio；读当前半宽标签→乘1852，读当前ExpAng.Text→乘π/180。距离L来自两拾点XY，远端外半宽W=w+L·tan(7.8°)，内线用起始w/2、远端W/2。中心线可选，左右各2条，15°时各3条；统一二维writer。

7.8为设施handler/初值赋予的默认文本，不是Draw里强制常数。无5.2°的VOR边界算法分支；5.2是A3/A6不同消费者的参数。15°则是P2F9实用硬编码连接角，独立于ExpAng。没有DME/KK/顶空锥逻辑。

UI没有自定义宽度输入框，角度文本框Enabled=false；修改恢复适配器标签/文本的fixture只验证实际reader优先级，不证明正常UI可自由编辑。config可以改角度Text，设施Changed又会覆盖；radio仅保存Checked，config不把宽度标签变成自由输入。
''',['2F7','2F9','2FA'])
report('ndb.md','NDB参数与完整构造链','''
P2F8将W1.Text=“1.25 nm”、W2.Text=“2.5 nm”、ExpAng.Text=“10.3”。小半宽2315m、大半宽4630m；默认设计器不选NDB，用户切至NDB后保留W1/W2档位，仅更换标签及角度。

P2F9与VOR完全同一个几何方法：W=w+L·tan(alpha)，内线为半值；按同样左右/中心/15°分支写CAD。没有独立NDB几何类/重载，没有6.5°或6.9°计算；这两个值不能从Base Turn或定位容差借入A4。NDB/DME也没有独立UI或DME距离误差消费者。

参数无上下限检查；文本parse失败P7D4提示后返回0，P2FA外层catch仅在下层异常逃逸时另提示并0替代，正常非法文本不会触发第二条alert。度数未强制10.3；但普通用户无法在被禁用文本框里直接输入。无负宽度/负角/大角纠正，测试注入仅揭示reader和算术边界。
''',['2F8','2F9','2FA','7D4'])

report('boundary-geometry.md','所有最终边界、符号与条件','''
定义S窄端、E远端，L=XY距离、u为S→E单位方向、n为其左法向，外半宽w，k=tan(alpha)，W=w+kL。局部说明坐标x沿u，不代表原实现建立了局部对象。

|点|Left|Right|Z（未求交时）|
|---|---|---|---|
|O0外边起点|S+w n|S−w n|S.Z|
|I0半宽起点|S+(w/2)n|S−(w/2)n|S.Z|
|O1外边终点|E+W n|E−W n|E.Z|
|I1半宽终点|E+(W/2)n|E−(W/2)n|E.Z|

不选15°时，每侧输出外折线[S,O0,O1]和内线[I0,I1]；没有重复S/闭环、没有终端横线、不是闭合四边形实体。外边界从S到O0为横向初始边，O0→O1为线性扩张边。内线斜率为k/2，其方向角是atan(k/2)，**不是alpha/2**。中间无弧/螺旋采样点。

选15°时，用过E与u夹角的左右斜线替换O1/I1为无限直线交点O*/I*，先新增[E,O*]，再[S,O0,O*]、[I0,I*]。它们共同形成尖端至起始边的构造线网，但没有自动区域/面/主副区对象。

左右是同一几何的符号镜像，两个独立点列分支写入同一个Group；不是两个writer。原次序Right在前、Left在后。选择单侧只产生该侧；双侧两套；都不选仍可仅中心线或空Group调用。

控制变量源映射：原obj=S、obj9=E；Right obj2/obj3=O0/O1，obj4/obj5=I0/I1；Left obj6/obj7=O0/O1，obj8/obj10=I0/I1；num2=w、num3=theta、num5=L、a=alpha弧度。完整表达式/IL与逐点fixture共同保存。

[边界符号索引](boundary-vertices.csv)、[所有表达式](evidence/geometry-expressions.csv)、[样本逐点](../round9/fixtures/geometry-points.csv)。负数、零长/大角和无限线求交不夹限，避免以规范修正“合理边界”。
''',['2F9','7E7','7E8','7ED','809','80A'])

vertices=[]
for side,sig in [('Right','-'),('Left','+')]:
 for exp in [False,True]:
  if exp:vertices.append(dict(side=side,condition='checkBoxExpand=true',relative_order=0,vertices='E -> O*',meaning='15deg cap/seam',point_source='P2F9 intersection with E-line'))
  vertices.append(dict(side=side,condition='Expand='+str(exp),relative_order=1 if exp else 0,vertices=f'S -> S {sig} w*n -> '+('O*' if exp else f'E {sig} (w+L*tan(a))*n'),meaning='outer boundary open polyline',point_source='P2F9 polar/add/intersection'))
  vertices.append(dict(side=side,condition='Expand='+str(exp),relative_order=2 if exp else 1,vertices=f'S {sig} (w/2)*n -> '+('I*' if exp else f'E {sig} ((w+L*tan(a))/2)*n'),meaning='half-width demarcation open polyline',point_source='P2F9 polar/add/intersection'))
out(A/'boundary-vertices.csv',vertices)

report('15-degree-line.md','15°线的起点、朝向与边界作用','''
**代码语义已闭合：终点E处的15°斜边与边界截接**，不是独立风螺旋/转弯模型，也不是只增加显示线。P2F9固定15·π/180，创建直线对象，求两次交点，替换内/外终点，再输出。

|问题|直接恢复事实|
|---|---|
|起点|第二拾取点E，既不是S也不是自动算出的TP/切点|
|相对基准|theta=E→S反向角；代码Right过E角theta+π+15°，Left为theta+π−15°；这是无限直线的参数方向|
|实际线段方向|在正宽、正扩张角、足够长的常规样本中，E→交点沿E→S方向分别向绘图Right/Left外扩15°；它朝窄端方向，不是S→E后端向前延伸|
|左右关系|相对S→E镜像；同一个15°常数，仅符号相反|
|终点|与原外/内扩张无限直线的交点O*/I*；画出的斜边为[E,O*]，I*位于同一截接直线上|
|实际改变|O1/I1被O*/I*替换；不仅是保留原边界再叠加辅助线|
|未实现|无转弯半径/飞机速度/风/坡度/切线/TP/KK读取，无对另一保护区实体的选择/自动裁剪|

局部解析核验（正宽/非退化，t=tan15°）：

```text
outer: y=w+k*x          cut: y=t*(L-x)
x_outer=(t*L-w)/(k+t)
x_inner=(t*L-w/2)/(k/2+t)
```

左右取±y；世界坐标由S+xu±yn解释。原实现用P7E7/P7E8/P7ED数值直线求交，不是AutoCAD IntersectWith；无x∈[0,L]夹限，短段可把交点放到S之前；平行/零分母沿公共helper给±1e6哨兵，不改成段相交算法。

帮助称“单侧配合15°线，可用于转弯后飞向导航台”，可解释其作为局部衔接构造的用途。2020规范一般转弯/附加航迹引导条文亦有15°，但要求前段切点/内外关系等条件；A4不判定这些条件。**具体规范适用场景与用户选点的关系由设计人员承担，代码只落实了给定E后的相交规则**。不将它命名为完整post-turn自动连接。完整端点已保存[fixture](../round9/fixtures/15-degree-endpoints.csv)。
''',['2F9','7E7','7E8','7ED'])

report('primary-secondary.md','主副区：几何有分界，评价无实现','''
A4不是“只有一条外边界”。P2F9明确使用w/2与(w+L·tanα)/2，左右各画一条内线；每个站距主区半宽为外半宽的一半。这支持**主副区边界几何**：双侧合计主区宽度占总宽50%，每侧副区占总宽25%。规范对照亦能支持该解释（N），但代码没有Primary/Secondary命名的区域对象或类型标签。

15°选中时两条不同斜率的内/外边与同一斜线相交，终止站距不同；不能把两个交点当同一截面的w/2关系失效。边界为开放Polyline，没有填充/面、闭合polygon、自动contains、MOC衰减或OCA。

不得用“无显式业务名称”否认明确的0.5几何，也不得将它扩成已实现完整主副区评价。A9是另一个宽度/MOC/障碍物算法，A4没有调用。无0.25宽度常数业务调用；25%是由双侧几何推导的比例，不冒充源码常数。
''',['2F9'])
report('obstacle-evaluation.md','障碍物评价与A9可达性','''
完整A4 Form及直接可达公共业务helper中，未发现ScreenData、障碍物解析/筛选、SelectAll、MOC、OCA、DataGrid、Mark、Highlight、控制障碍物输出或孤立完整evaluator。CAD writer/通用config注册器的词法/API候选不等于A4障碍物入口。

P2F9只将拾点和文本转换为边界列表，写CAD后返回；不读取已绘实体、DBPoint或障碍物记录。A9 P32F/P330/P331与其PriSec窗口没有从A4事件的direct/MethodSpec可达路径。公共ReLine算术相同不等于业务评价共用。

结论是几何构造工具：支持外边/半宽分界与15°截接的绘图，不兼有障碍物评价。这里没有Round5–8式“完整孤立评价器”触发验收缺口；不存在的评价功能按缺失记录，不补接。
''',['2F9'])

report('cad-output-map.md','CAD创建顺序、实体与连接索引','''
P2F9→P087(WorkingDatabase,list2, **空字符串**)→P089；P12D/P12A转换Point2d，P134按每顶点bulge/startWidth/endWidth=0添加。P087先new Group，再按列表顺序new Polyline并逐个入ModelSpace、Append到同一个Group，最后AddDBObject(Group)。没有Group名字/Description/XData，也没有按左/右另分组。

|顺序|条件|Polyline顶点|备注|
|---|---|---|---|
|最先|center|S,E|中心线长度为拾点XY长度，独立Polyline，但在同Group|
|随后Right0|right且expand|E,O*_R|15°斜边独立Polyline|
|Right外边|right|S,O0_R,O1_R或O*_R|三顶点开放折线|
|Right内线|right|I0_R,I1_R或I*_R|二顶点半宽分界|
|随后Left0|left且expand|E,O*_L|15°斜边|
|Left外边|left|S,O0_L,O1_L或O*_L|三顶点开放折线|
|Left内线|left|I0_L,I1_L或I*_L|二顶点半宽分界|

条数：`center?1:0 + (left?1:0 + right?1:0)*(expand?3:2)`（按布尔项分别求和）。默认5条，双侧+15°为7条；单侧无中心2/3条，有中心3/4条。全不选时仍调用P087，列表空，代码new空Group并尝试入库；宿主是否接受不在本轮实测范围。

全部是2D Polyline，无AutoCAD Line/Arc/Circle/Text/3DPolyline/Face/Surface新建。数值点Z最终丢弃，不显式Closed=true，不赋图层、颜色、线型，最终显示属性取宿主默认而未验证。没有对零长/重合线去重。

## 保护区衔接与图元交互索引

[全部CAD API调用位置](evidence/cad-api-sites.csv)、[数值交线/极坐标/加点调用](evidence/connection-semantic-calls.csv)、[源表达式](evidence/geometry-expressions.csv)、[分支](evidence/branch-sites.csv)、[字段流](evidence/field-flow.csv)、[符号边界](boundary-vertices.csv)。这些索引同时保留通用helper中的条件路径，XData候选必须按空metadata实参判定。

15°数值求交和列表终点替换已代码化；没有IntersectWith、Offset、Arc/切线/包络、GetEntity/GetSelection、实体裁剪/延伸、Erase后重建既有图元。图元是每次重新创建，不自动删除上次结果；不能称已实现跨窗口区域自动合并。
''',['2F9','087','089','12A','12D','134'])
report('xdata-schema.md','XData：本路径无metadata','''
P2F9处理IL_0891–IL_089D：传WorkingDatabase、list2、`ldstr ''`给公共P087。C#省略可选第三参，IL证明实际是空串。P089只有`P_2.Trim().Length>0`才登记WsObject、写1001和1000。

因此A4新建子Polyline不写WsObject、Kind、facility、angle、width、Form state或其他XData；Group也无metadata。公共writer具备可选metadata能力不等于A4使用。无业务标签可从所选图元反读导航台类型或参数。几何位置可供人判断，但不是可审计的参数身份协议。

本窗口无GetEntity/XData导入按钮，也没有portable TXT/JSON序列化器；临时UI配置是另一个config通道。不能从Group名称猜业务身份，writer未给Group命名。
''',['2F9','087','089'])
report('persistence.md','config、禁用角度与无参数文件协议','''
P2FB Load→**P0F6 _008A_0093**读取程序集目录config.xml的`/Document/NavAids`；P2FC Closed→**P0F4 _008A_0091**保存。记录以groupBox层级和控件Name拼dotted key，P0F5递归收集、P0F7按路径查控件。

TextBox handler取/设Text，不检查Enabled；radio/checkbox仅保存Checked为True/False，不保存Text标签。A4的文本框虽Enabled=false，config仍可能回填非默认角度；设施radio状态变化可触发P2F7/P2F8再覆盖角度/宽度标签。最终依config条目顺序与真实WinForms事件顺序，不能仅看默认值断定运行值。

原`WsTools-master/WindSpiral2026/config.xml`中**无NavAids节点**，已按hash保存该事实，不能伪造其持久化值。其已有其他窗体状态保持冻结。恢复适配器不写原config，不完整模拟通用config/WinForms生命周期；serialization层为静态路径和handler检查，非假造TXT往返。

没有独立A4保存/读取TXT/JSON的UI、格式、XData Form state。宽度只有单选预设，config保存宽度档位，不提供自定义宽度；测试注入“3.75 nm”验证标签reader，必须标注非普通用户功能。

[config证据/hash](evidence/config-evidence.json)、[注册器与handler源摘录](evidence/config-handlers.source.txt)。角度数值不限制最小/最大；P7D4 Convert.ToDouble异常→提示+0，P2FA外层catch也会0替代下层逃逸异常；不把0自动恢复为设施默认。
''',['2FB','2FC','0F4','0F5','0F6','0F7','2FA','7D4'])

a3=[('VOR/NDB angles','A3 guide5.2/6.9 or no-guide4.5/6.2; ILS2.4/1.4','A4 outer divergence7.8/10.3','Different concept','A3 P209-P20C vs A4 P2F7/P2F8; different setters'),('facility point','A3 first point station S','A4 generic start S / facility candidate','Different concept','same P113 GetPoint, no shared facility object'),('track','A3 S/Q XY atan2 and distance','A4 S/E reverse atan2 and finite length','Copied formula','same elementary operations, different MethodDef; Q is not only direction in A3 either'),('DME','A3 .0125r+460, optional arcs/labels','none','No relation','No implementation evidence found in A4.'),('KK','A3 early/late transverse lines','none','No relation','No A3 call from A4'),('overhead','A3 altitude/cone blind zone','none','No relation','A4 no altitude/cone input'),('CAD group','P087/P089','same P087/P089','Same MethodDef','A4 supplies empty metadata; A3 other entities are separate'),('numeric point/polar','P809/P80A','same P809/P80A','Same MethodDef','shared primitive, not shared facility accuracy algorithm')]
out(O/'a3-a4-comparison.csv',[dict(component=a,A3=b,A4=c,classification=d,evidence=e) for a,b,c,d,e in a3])
a6=[('VOR','P1EE BaseTurn5.2deg','P2F7 UI7.8deg','Different concept','different MethodDef and consumers'),('NDB','P1EE BaseTurn6.5deg','P2F8 UI10.3deg','Different concept','do not substitute6.9 or6.5'),('15deg','BaseTurn additional tolerance15 VOR/25 NDB, separate model','fixed15 both facilities; cap intersections','Different concept','no BaseTurn constructor/algorithm dispatch'),('point primitive','BaseTurn P809/P80A','P809/P80A','Same MethodDef','exact call offsets in cross-module-shared-calls.csv'),('line primitive','BaseTurn P1F0 calls P7E8','A4 P2F9 calls P7E8','Same MethodDef','point-angle line only; no direct shared P7E7/P7ED evidence in selected BaseTurn methods'),('business model','P1ED/P1EE/P1EF/P1F0','none called','No relation','A4 event closure excludes A6 business')]
out(O/'a6-a4-comparison.csv',[dict(component=a,A6=b,A4=c,classification=d,evidence=e) for a,b,c,d,e in a6])
a9=[('primary/secondary width','P330 normal primary halfwidth; P331 IF asymmetric endpoint','P2F9 draws w/2 inner line and outerw','Different concept','A4 construction, A9 evaluator; similar ratio not same business method'),('MOC reduction','A9 linear side reduction and height/MOC inputs','none','No relation','no MOC/OCA/grid controls in A4'),('evaluation call','P32F -> P330/P331','no direct/MethodSpec path','No relation','event closure resolved; no evaluator orphan found'),('line equation','P7E7 etc','P7E7','Same MethodDef','common line primitive only'),('input association','A9 picks S/E independently, no A4 object ID','A4 output has no metadata','No relation','no automatic transfer of lists/widths/IDs'),('possible manual reuse','A9 can accept manually supplied points/widths','drawn points/widths available to designer','Different concept','workflow possibility N; not coded cross-window relationship')]
out(O/'a9-a4-comparison.csv',[dict(component=a,A9=b,A4=c,classification=d,evidence=e) for a,b,c,d,e in a9])

# Standard mapping is deliberately generated after the code/IL reports above.
standard=json.loads((ROOT/'recovered/round5/standard-pages.json').read_text(encoding='utf-8'))
selected=[56,63,65,146,147,148,149,225,331,332,334,335]
standard_evidence=dict(path=standard['path'],sha256=standard['sha256'],extracted_from='recovered/round5/standard-pages.json',text_sha256=hashlib.sha256((ROOT/'recovered/round5/standard-pages.json').read_bytes()).hexdigest(),normalization=standard['normalization'],page_numbering='physical PDF page, one-based; extracted printed folios can be OCR-distorted',pages=[p for p in standard['pages'] if p['pdf_page'] in selected])
write(E/'standard-search.json',json.dumps(standard_evidence,ensure_ascii=False,indent=2))
mapping=[
 ('VOR divergence','P2F7 writes7.8; P2F9 reads Text','I-2-2 2.8',56,'Matches current standard','Terminal protection divergence; not A3 2SD accuracy'),
 ('NDB divergence','P2F8 writes10.3; P2F9 reads Text','I-2-2 2.8',56,'Matches current standard','No A6 6.5deg or A3 6.9deg substitution'),
 ('VOR small half-width','1nm *1852; two sides total2nm','II-2-3 3.4.3.2 / II-2-4 4.4.4',332,'Matches current standard','Matches station width in specified final approach context; A4 does not identify stage'),
 ('NDB small half-width','1.25nm *1852; two sides total2.5nm','II-2-3 3.4.3.3 / II-2-4 4.4.4',332,'Matches current standard','NM exact conversion; rounded km values not a separate discrepancy'),
 ('VOR/NDB large half-width','2 /2.5nm; user selects W2','I-4-3 Appendix B B.1.1, B.1.3-B.1.4',146,'Matches current standard','Values match IF station half-width candidates; general applicability not inferred'),
 ('Stage and maximum-width/distance rules','No IF/FAF/MAPt, stage, maximum-distance or width cap','I-4-3 Appendix B; II-2-4 4.4.4',335,'Not implemented','No automatic5nm cap or stage-specific width transition; user must supply valid segment'),
 ('Primary/secondary geometry','Inner line half of outer half-width at each uncut station','II-2-3 3.4.3.2-.3; II-2-4 4.4.4',332,'Matches current standard','Primary50% total, each secondary25%; only boundary lines'),
 ('Secondary MOC / evaluation','No evaluation or zone objects','II-2-3 3.4.4; II-2-4 4.4.6',335,'Not implemented','Do not attach A9 evaluator or impose one MOC for every stage'),
 ('15deg geometric construction','E-line intersects inner/outer infinite lines and replaces far endpoints','I-2-3 3.2.2 /3.3.4',65,'Implementation basis unresolved','Angle and connection concept present; no P tangent/inside-outside/turn direction tests, no30deg secondary transition'),
 ('15deg automatic scenario choice','No wind spiral/tangent, K-K, turn-start or previous-area input','I-2-3 3.2.1-.2,3.3.4-.5',63,'Not implemented','Designer chooses E/side/15deg; cannot claim complete prescribed turn connection'),
 ('Angle read priority','Facility setter -> disabled TextBox/config -> Draw text','I-2-2 2.8',56,'Different','Config can change final text; no validation forcing current prescribed angle; not normally user-editable UI'),
 ('Width read priority','Facility label text -> W1.Checked selection -> parse *1852','II-2-3 3.4.3',332,'Different','Finite presets; no facility/stage validation. Custom label fixture is injection, not editable user default'),
 ('Historical derivation','No version/year or formula provenance in A4 branch','Current standard compared only',56,'Implementation basis unresolved','No evidence sufficient to identify older ICAO/domestic edition or author simplification as actual source')]
out(A/'standard-mapping.csv',[dict(item=a,code=b,standard_clause=c,pdf_page=d,classification=e,limit=f) for a,b,c,d,e,f in mapping])
report('standard-mapping.md','代码恢复后的2020规范映射','''
基线：《航空器运行目视和仪表飞行程序设计规范》AC-97-FS-005，民航规〔2020〕12号。PDF原路径`doc/航空器运行目视和仪表飞行程序设计规范.pdf`，SHA256 `6b6b6f04380f3e0a138ca57bb95fcddb0a390a5b4aa7a9c7a391ff35bb92c8ed`。以下是N层解释，代码事实来自E1/E2，未按规范改写原公式。

[逐项分类CSV](standard-mapping.csv)、[页文本摘录及源hash](evidence/standard-search.json)。页码均为物理PDF页，不能把OCR页脚数字当准确印刷页码。

|行为|规范对应|结论及限度|
|---|---|---|
|VOR7.8° / NDB10.3°|I部分2篇2章2.8，PDF56|Matches current standard。明确是终端区保护区3SD外推扩张角；同页5.2/6.9为2SD系统使用精度，不能混用|
|小档半宽1 /1.25NM|II部分2篇3章3.4.3.2/.3，PDF332；4章4.4.4，PDF335|Matches current standard。在台处总宽2 /2.5NM，故代码两侧半宽准确对应；规范3.7/4.6km是舍入表示，不能用2315与2300差15m认定不同标准|
|大档半宽2 /2.5NM|I部分4篇3章附录B，B.1.1等，PDF146–149|数值Matches current standard：可解释IF在VOR/NDB台处的宽度候选。代码没有进近阶段，不能把大档当通用最后进近默认宽度|
|内线为外半宽0.5|II-2-3 3.4.3、II-2-4 4.4.4|Matches current standard的分界比例：主区总50%，副区每侧25%。仅画线，不是完整区域评价|
|15°截接|I-2-3 3.2.1/.2、3.3.4，PDF63/65|角度与局部连接用途有规范支持，但具体条款适用条件仍为Implementation basis unresolved（实现依据待确认）；没有转弯切点、内外判定、前段保护区或副区30°构造|
|任意长度/半宽/角度运算|附录B、II-2-4 4.4.4|阶段选择、最大宽度/距离、FAF/MAPt截段Not implemented。把无约束绘图当完整航段模板会与规范条件不同|
|参数来源|两设施setter，随后Draw消费文本|角度不是不可覆盖硬常数：TextBox禁用，但config能填Text；宽度为两档radio。没有普通UI自由宽度/角度编辑，测试自定义值是适配器注入|
|超障评价|II-2-3 3.4.4、II-2-4 4.4.6|Not implemented；规范各场景的MOC不由A4计算|

具体场景必须结合实际程序阶段和飞行方向。S是窄端、E是另端；若飞行E→S向台，边界沿飞行方向收敛，15°斜边从E指向窄端侧相交。这解释帮助中“转弯后飞向导航台”的使用语境，但不能单凭帮助确认设计人员将E放在规范要求的正确连接点。

没有充分证据认定A4来自其他版ICAO Doc8168、旧版国内规范或作者自创方法；不因规范数值一致就证明作者引用来源。历史来源与15°自动适用场景标“实现依据待确认”，其计算/求交本身已恢复。User-editable default、Older-version candidate分类未被证据支持时不强行使用。
''',['2F7','2F8','2F9'])

numeric=json.loads((O/'fixtures/numeric-counts.json').read_text())
static=json.loads((O/'static-tests.json').read_text())['checks']
from collections import Counter
sc=Counter(x['layer'] for x in static)
verification=[]
for layer in ['formula','geometry','mode/facility dispatch','CAD writer','serialization','event/reachability','cross-module','degenerate']:
 verification.append(dict(layer=layer,E3_assertions=numeric.get(layer,0),static_checks=sc.get(layer,0),E4_assertions=0))
out(O/'verification-layers.csv',verification)
report('verification.md','独立验证与静态核验分层','''
**5550条E3独立源码断言通过，另30项静态核验通过；E4=0。** 不把静态检查、列表记录或断言条数写成原AutoCAD实体运行次数。

|层|E3断言|静态核验|范围|
|---|---:|---:|---|
'''+''.join(f'|{x["layer"]}|{x["E3_assertions"]}|{x["static_checks"]}|'+{'formula':'端点独立解析式、单位及自定义注入','geometry':'机械P2F9切片与结构化读本的列表/逐点比较','mode/facility dispatch':'设施setter、覆盖优先级和Draw读取','CAD writer':'输出列表数量/空列表；实体writer靠静态IL','serialization':'Load/Closed方向及控件handler，仅静态','event/reachability':'五绑定、native身份、MethodSpec及业务排除','cross-module':'同MethodDef调用点，排除无证据共用','degenerate':'零/负宽度、零/大角、非法输入、原点取消/同点、短段15°'}[x['layer']]+'|\n' for x in verification)+'''

矩阵144组：VOR/NDB×两宽度×左/右/双侧×中心线开关×15°开关×航向0/90/37°。每组与独立局部闭式公式核对末端，并对结构化/机械切片逐点比较。[15°最终端点](../round9/fixtures/15-degree-endpoints.csv)单独保存；[几何样本](../round9/fixtures/geometry-points.csv)、[逐断言](../round9/fixtures/assertions.csv)、[分层计数](../round9/verification-layers.csv)。

自定义3.75nm/4.2°由独立适配器注入标签和文本，证明reader与几何消费优先级，不声称原UI支持自由输入。非法输入模拟P7D4的提示+0，保留零分母哨兵及不夹限行为。

编译输入hash保存在[test-inputs.json](../round9/test-inputs.json)，命令及边界见[build.py](../round9/build.py)，[编译日志](../round9/compile-tests.log)、[运行日志](../round9/tests.log)、[30项静态结果](../round9/static-tests.json)。只编译运行本轮独立恢复源码；冻结GeometryPrimitives直接复用。静态writer检查证明Polyline/Group构造路径和空metadata，不证明宿主事务成功；config检查没有伪造TXT往返或修改原config。
''',['2F9','087','089','2FB','2FC'])
report('unrecovered.md','未实测项与证据限度','''
|事项|当前证据|保留范围|
|---|---|---|
|原插件E4|本轮未加载目标DLL、未控制AutoCAD|无运行等价、界面外观、许可/加载状态或原宿主回归结论|
|WinForms真实生命周期/config时序|五绑定及P0F6/P0F4/handler静态恢复|未运行所有配置条目顺序与CheckedChanged交错；最后文本仍可能被设施事件覆盖|
|CAD宿主行为|writer及数据库API路径完整|空Group入库、宿主默认层/色/线型、事务/锁异常、零长重复顶点的实际接受性未测|
|异常拾点/输入|Origin取消及重试/parse分支已恢复，独立输入测试|未实测UCS/交互显示/用户打断。代码消费返回坐标并在其XY运算，不另推宿主坐标转换|
|15°场景选择|交点构造、终点替换、固定角及帮助语境已闭合|规范转弯切点/内外判定未实现；选E与侧别由设计人员提供。历史来源“实现依据待确认”|
|主副区与评价|半宽分界几何直接存在，完整窗体和可达链无评价|不能产出已评价MOC/OCA。没有发现待补接的孤立评价器|
|设施/航段语义对象|只有S/E、标签、开关|无台站ID/阶段/长度上限/输出metadata，外部数据自动关联未实现|

以上是宿主运行验证缺口、缺失产品功能或规范适用条件，不是重要设施/15°计算/CAD writer的静态断链。P2F6无IL是已证明user32.dll SetFocus的P/Invoke，不能报告成未恢复方法体。原DLL保护桩与处理源码不同证据等级始终保留；未将E1/E2升格为原始未混淆源码。
''',['2F6','2F9','2FB','2FC'])

answers=[
 ('A4实际支持哪些设施？','只有VOR、NDB。LOC/DME/VOR-DME/NDB-DME等在A4未发现实现；见设施矩阵。'),
 ('VOR真实默认宽度是什么？','小档初始外半宽1NM=1852m；另有大档2NM=3704m。默认选小档。'),
 ('VOR真实扩张角是什么？','P2F7设置7.8°，P2F9读取最终角度文本参与tan计算。'),
 ('NDB真实默认宽度是什么？','切NDB后小档1.25NM=2315m，大档2.5NM=4630m；设施事件不强制改变所选档位。'),
 ('NDB真实扩张角是什么？','P2F8设置10.3°；不是A3的6.9°或A6的6.5°。'),
 ('用户修改角度/宽度时真实优先级如何？','设施事件写标签和角度→config/状态可能影响最终Text→Draw读取。角度TextBox Enabled=false、宽度为radio，普通UI不支持自由编辑；注入自定义测试仅验证reader。两个设施handler不查Checked，最后事件覆盖文本。'),
 ('起始宽度是总宽还是半宽？','所选值×1852后为每侧外半宽w；内线w/2，双侧总宽2w。'),
 ('左右边界如何构造？','以S→E左法向n：外端S±wn、E±(w+Ltanα)n；内端S±wn/2、E±(w+Ltanα)n/2。每侧外折线[S,O0,O1]和内线[I0,I1]。15°时末端换交点。'),
 ('中心线如何构造？','列表最先加入[S,E]，单独2D Polyline；长度由拾点XY距离决定，与其他线共Group。'),
 ('15°线到底是什么？','从E构造相对反向航迹的15°无限直线，与该侧内外边求交，替换末端并画[E,O*]；通常向窄端方向截接。不只是叠加显示线，也不是自动转弯/风螺旋保护区。'),
 ('是否生成主区/副区？','确有外边与半宽分界几何，对应主区总50%/各副区25%；无命名区对象、闭合面、填充或MOC。不能写成毫无区划证据。'),
 ('是否存在障碍物评价？','没有A4评价UI/可达或孤立完整评价器证据，无MOC/OCA/障碍物筛选。'),
 ('最终创建哪些CAD实体？','2D Polyline及一个Group；默认5条，双侧带15°为7条。无独立Line/Arc/Text；未显式设置Closed/Layer/Color/Linetype。'),
 ('写哪些XData？','不写。P2F9给P087空metadata，P089条件不满足；无WsObject/Kind/设施/宽度/角度/Form state。'),
 ('A4与A3真正共享什么？','P113拾点、P087/P089 writer、P809/P80A点原语和config基础。无A3设施精度/DME/KK/顶空业务调用；角度属不同概念。'),
 ('A4与A6真正共享什么？','BaseTurn与A4确有P809/P80A、P7E8点角直线等直接同MethodDef证据，选定窗口入口还有P113/P125。没有将P7E7/P7ED推作BaseTurn共享；5.2/6.5与7.8/10.3为不同方法/业务常数。'),
 ('A4是否调用A9主副区算法？','不调用P32F/P330/P331。共享P7E7等线原语，不共享评价逻辑或宽度/实体ID数据传递。'),
 ('哪些行为与2020规范不同？','无阶段/距离/最大宽度/FAF-MAPt裁段校验、MOC、自动转弯衔接条件；config可以覆盖角度且不强制规定值。固定默认角/小档半宽/分界比例匹配对应条文，大档仅匹配特定IF候选。'),
 ('哪些参数只是UI默认值，不是硬编码规则？','7.8/10.3与两档宽度由设施setter赋Text，Draw读取最终文本；它们是UI预设而非Draw再次强制的常量。15°、1852和0.5则为计算内固定常数。'),
 ('A4最终应定性为什么？','导航设施保护边界几何构造工具，含半宽分界及15°局部截接；不是障碍物评价器。')]
closure='''# Round 9 Closure — A4 导航设备保护区

**Round 9: ACCEPTED (static recovery)**，2026-10-28。

本轮只修改`recovered/A4-NavAidProtection/`和`recovered/round9/`。Round1–8和原件冻结。结论针对静态恢复与独立源码验证，不表示原AutoCAD运行验证或规范全面批准。

## 20问逐项回答

'''
for i,(q,a) in enumerate(answers,1):closure+=f'### {i}. {q}\n\n{a}\n\n'
closure+='''## 验收矩阵

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
'''
write(O/'closure.md',closure)
