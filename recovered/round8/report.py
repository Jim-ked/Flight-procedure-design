"""Round 8 reports and navigable evidence. Reads frozen rounds; writes only A5/round8."""
from pathlib import Path
import csv,json,re,hashlib
ROOT=Path(__file__).resolve().parents[2]; O=ROOT/'recovered/round8'; A=ROOT/'recovered/A5-PrecisionApproach'; E=A/'evidence'
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def csvout(p,rs):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
def write(p,s):p.write_text(s.strip()+'\n',encoding='utf-8')
ms={m['processed_token']:m for m in rows(E/'method-index.csv')}
common='''
## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。
'''
def report(name,title,body,tokens=()):
 s='# '+title+'\n\n'+body.strip()+'\n'+common
 if tokens:
  s+='\n## 关键定位\n\n|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|\n|---|---|---|---|---|\n'
  for p in tokens:
   t='0x06000'+p;m=ms.get(t)
   if m:
    ref=f'evidence/processed/{t}.il.txt' if (E/'processed'/(t+'.il.txt')).exists() else 'evidence/native-import.json'
    s+=f'|P{p}|{m["original_token"]} / {m["original_rva"]}|{m["processed_rva"]}|{m["line"]}|[证据]({ref})|\n'
 write(A/name,s)

report('overview.md','A5 Precision Approach / OAS 差异恢复', '''
**Round 8: PARTIALLY ACCEPTED (static recovery)**，2026-10-28。

本构建 A5 是绘图为主的精密进近参数/保护轮廓窗口：**A5 is drawing-oriented in this build**。六模式 dispatch、独立几何、数据库关系、W/W*、FAF/FAP、二维 writer、分段参数文件及 config 已静态恢复。完整面高方法 P41B/P429 全程序集 direct/MethodSpec incoming 均为空，A5 事件不可达；没有可达障碍物评价、HL、最低标准链。按用户验收条件保留部分验收，不补接。

## 阅读入口

- [六模式矩阵](mode-matrix.csv)；[事件图](event-map.md)；[类关系](class-map.md)
- [数据库/参数](oas-parameter-model.md)；[面/域](oas-surfaces.md)；[W/W*](w-wstar.md)
- [GP INOP](gp-inop.md)；[PAOAS](paoas.md)；[OAS绘图](oas-cad.md)
- [PA-FAP](pa-with-fap.md)；[PA-FAF](pa-with-faf.md)；[字段映射](faf-fap-mapping.md)
- [CAD输出](cad-output-map.md)；[人工交互](cad-interactions.md)；[XData](xdata-schema.md)
- [参数文件](oas-txt-format.md)；[持久化](persistence.md)；[评价](obstacle-evaluation.md)
- [HL](hl-correction.md)；[最低标准](minima.md)；[规范映射](standard-mapping.md)
- [验证](verification.md)；[未恢复项](unrecovered.md)；[26问收口](../round8/closure.md)

## 与 B4 的主要差异

A5 直接使用共享五面模型普通 OAS 几何，AUTO 组合 W/W*；B4 专用 _008C_0095 只读 W/X/Y/Z，另构造同轴衔接。A5 不 new B4 专用类。A5 的 P409–P40C 与 B4 P571–P574 是独立 MethodDef 的同 schema/解码/修正复制实现。真正共享的是 _008A_0093、Plane 及公共几何/CAD helper。A5 自有 GPINOP、PAOAS、FAF、FAP 类。文件也不同：A5 分段 JSON，B4 旧 CSV 文本，不能互当同格式。

本轮只写 A5 与 round8 两目录；原件及 Round 1–7 冻结。恢复源码只用于审计与研究，未作为可批准的飞行程序计算软件交付。
''',['306','307','409','412','41B','429'])

events=rows(E/'event-identities.csv')
evt='''20个真实事件绑定见下表，完整 direct callees 不截断地保存在 CSV。设计器绑定不等于每种 UI 状态都可点击；实际运行的 config 覆盖与事件时序未执行。

```mermaid
flowchart TD
  Load[P303 Load/default/config] --> State[FormPA 控件状态]
  State --> Params[P309至P312 参数变化]
  Params --> DB[P30A / P409查库 / P40B尺寸 / P40C RDH]
  DB --> Model[P412共享OAS / P30B文本回填]
  Pick[P314至P317 CAD拾点] --> State
  Import[P318实体XData / P31D文件] --> Parse[P31B导入选择 / P31A解析]
  Parse --> State
  State --> Draw[P306 Draw]
  Draw --> Prep[P307 所有模型及IF/fix]
  Prep --> Six[六模式列表]
  Six --> Transform[P821旋转 / P823平移 / P827清Z]
  Transform --> Writer[P087 / P089 二维Polyline + Group + XData]
  State --> Save[P31C / P319参数文件]
  State --> Close[P304 / P0F6 config]
```

|Control|Event|处理P|原token / RVA|处理RVA|分类|
|---|---|---|---|---|---|
'''
for e in events:evt+=f'|{e["control_name"]}|{e["event"]}|P{e["handler_tokens"][-3:]}|{e["original_token"]} / {e["original_rva"]}|{e["processed_rva"]}|reachable|\n'
evt+='''
## 入口、未绑定与缺失的分类

|功能|分类及证据|
|---|---|
|THR/end拾点、交换|P314/P315/P313，reachable；六个XYZ文本直接交换|
|坐标转换|没有对应 A5 控件/事件/坐标系协议，未找到实现；Lon/Lat命名不证明经纬转换|
|跑道校验|数值parse与公共两点frame；未见本窗体坐标系、零长或合法跑道校验器|
|CAT/GP/尺寸/RDH/LOC/CG|P309/P30C–P312 → P30A，reachable；表格见控件清单|
|W/W*/X/Y/Z手输|P307读取；不是每个文本都有独立重算事件|
|六radio|都由 P306读取；只有PAOAS Left绑定P308 CheckedChanged，Right无独立绑定，通过同组Left状态变化可能触发|
|ScreenData/Evaluate/Mark/Highlight/Minimums|未见控件/绑定/调度；没有可指认的prompt-only或stub评价按钮|
|P41B、P429|orphan complete method；无全局direct/MethodSpec incoming，无A5事件路径|
|GPINOP P3A7延伸|orphan complete method；不能因类内存在就算Draw输出|
|P305|native user32.dll SetFocus，RVA0不是空stub；导入元数据另存|

[可达闭包](evidence/event-reachability.json)、[全局incoming](evidence/resolved-global-incoming.csv)、[控件属性与消费者](evidence/parameter-control-inventory.csv)、[完整调用DOT](evidence/callgraph.dot)。unbound仅用于真实存在但无绑定的成员；不存在的业务入口不虚构为unbound方法。
'''
report('event-map.md','事件、可达性与分类',evt,['303','304','305','306','307','313','314','315','316','317','318','31C','31D','41B','429'])

report('class-map.md','类与真正共享的边界','''
|角色|原反编译类名|入口/核心P|恢复文件/复用|
|---|---|---|---|
|A5 Form|_0089_008C|P302–P322|PrecisionApproachForm；仅恢复计算/状态/文件切片，非完整WinForms|
|参数loader/decoder/修正|_008A_0091|P409–P40C|OasParameters.Recovered.cs；B4私有复制类不同|
|共同OAS几何|_008A_0093|P411 ctor、P412 Build、P41B面高|复用冻结B4/OasModel.Recovered.cs，原程序同MethodDef|
|平面|_008F_0092|P834–P840|冻结B4/PlaneCarrier.Recovered.cs；数值对象，不是CAD Surface|
|GPINOP|_0089_0096|P39E–P3AA|GpInopGeometry.Recovered.cs|
|PAOAS L/R|_008A_0097|P427 ctor、P428 Build、P429面高|PaOasGeometry.Recovered.cs；两列表|
|PA-FAF|_008A_0099|P437 ctor、后续点列|PaFafGeometry.Recovered.cs|
|PA-FAP|_008A_009B|P443 ctor、后续点列|PaFapGeometry.Recovered.cs|
|点/线/点列/跑道frame|_008F_008E等|P7ED、P81F、P821/P823/P827等|复用冻结A6/B5数学源码|
|公共CAD writer|_008B|P087/P089|完整方法证据；独立测试不模拟AutoCAD数据库|
|B4专用几何|_008C_0095|P5DD–P5EB|A5未构造，非统一引擎|

存在统一 OasModel 基础面/交点层，**不存在六模式完全相同的几何引擎**。各模式私有类消费共同系数、交线与fix/IF。普通OAS直接选共享列表，PAOAS选预先生成的左右列表，其余构造专用类。P307在dispatch前无条件创建/准备共同模型，因此一个模式也可能因别的模式参数文本错误而受影响。

交叉关系按原程序集 MethodDef 判定；本轮编译引用相同恢复源文件只证明测试复用，不单独证明原调用。完整调用身份见 ../round8/shared-calls.csv。
''',['307','409','411','412','39E','427','437','443','834','087'])

modes=[('GP INOP','_0089_0096 / P39E','_0088_0087_0099','W/X/Y/Z及其交点；不读W*','名义fix/IF',29),('PAOAS Left','_008A_0097 / P427/P428','_0088_0094_0093','W/X/Y/Z + P1/P2','P307仍解析fix/IF',7),('PAOAS Right','_008A_0097 / P427/P428','_0088_0094_0092','同Left；Y镜像','同Left',7),('OAS','_008A_0093 / P411/P412','_0088_0091_009D','CATI/II W；AUTO W+W*','P307仍解析fix/IF','7 / AUTO 8'),('PA with FAF','_008A_0099 / P437','_0088_0095_0090','W/X/Y/Z；共享尾部','名义fix+单侧容差+IF',12),('PA with FAP','_008A_009B / P443','_0088_0096_008B','W/X/Y/Z；共享尾部','名义fix+IF',11)]
csvout(A/'mode-matrix.csv',[dict(Mode=n,Event='P306 -> P307 -> dispatch',Geometry_class=c,Internal_list=l,Database='A5 P409 -> P40B/P40C; UI roundtrip',W_Wstar=w,FAF_FAP=f,HL='No A5 HL implementation found',CAD_output=f'2D Polyline {num} + one Group; sample-dependent vertices',Evaluator='P41B/P429 orphan; no A5 entry',XData='WsObject + complete segmented JSON',UI_gate='CAT I enables all; CAT II/AUTO selects OAS and disables other five') for n,c,l,w,f,num in modes])

report('oas-parameter-model.md','A5参数、数据库与CAT模式','''
## 真实查库链与复制关系

P30A → **A5 P409** → P40A decoder → P40B尺寸 → P40C RDH → P412 Build → P30B回填。B4对应P571/P572/P573/P574，分别为不同MethodDef；不是同loader。SQL和schema相同，未发现A5独有插值；详见 [数据库比较](../round8/a5-b4-database-comparison.csv)。

程序集目录 oas.db：PartA/PartB均 `SELECT Value FROM PartA/PartB WHERE ID = @id`。keyA=`(GP+modeInteger+MissedCG).Replace(".","")`；keyB在其后追加`(int)Math.Round(LOC,0)`。文本串拼接与小数点去除保留原行为，不重新设计key。P30A先夹LOC到2000–4500；只有四个Combo SelectedIndex都不为−1才进入。逐整数米查表，**无插值**。缺文件提示并返回null；缺key的ExecuteScalar().ToString没有空值保护。

数据库原始SHA256 `a63ed87cbf5b816d46aef87463b7f0a3393d9cd6e83a0040b13fdea7858a025f`；PartA275行、PartB687775行。复用Round7只读SQLite导出27组，不加载原SQLite DLL；原行、schema和原路径保留在冻结 [database-extract.json](../B4-PbnIls/evidence/database-extract.json)。

## 解码及修正

P40A非零数字d→10−d，0保留，再整串逆序。PartA逐片段解码：Z.C[0:4]×−.01，W.A[4:9]×1e−6，W.C[9:12]×−.01，W*.A[12:17]×1e−6，W*.C[17:21]×−.01；Z.A=keyA.Substring(3,2)×−.001；W/W*/Z.B=0。PartB先整串解码后切X.A[0:5]/B[5:11]/C[11:15]、Y.A[15:20]/B[20:26]/C[26:30]；A/B×1e−6、C×−.01。

s为半翼展、t为轮参数：W/W*.C减(t−6)；P=max(t/Bx,s+(t−3)/Bx)−max(6/Bx,30+3/Bx)，X.C减Bx·P，Y.C减By·P。RDH给W/W*/X/Y.C加(RDH−15)，Z不改。P30B A/B按F6、C按F2写回，Draw再解析已舍入文本；不能把未舍入数据库模型当最终绘图系数。P30C飞机类别写A/B:30/6，C/D:32.5/7，DL:40/8；手改尺寸仍可能覆盖。P30D令P1.A=Round(tanGP,4)，随后触发参数更新。

## CAT链

|AppType SelectedIndex|DB mode|cap（米）|UI|P307实际读面|CAD|
|---|---|---|---|---|---|
|0 CAT I|0|300|W*框隐藏；六模式可用|W/X/Y/Z|普通OAS7条|
|1 CAT II|1|150|W*框可见；另五模式禁用并选OAS|W/X/Y/Z，不读W*文本|7条|
|2 CAT II AUTO|2|150|同上|W/W*/X/Y/Z|W/W*交线分两条，8条|

cap是150 **m**，不能误写150ft。AUTO查不同数据库key，X/Y等也可不同；不是只改W*或cap。enum仅value__元数据，不虚构命名常量。W*可见不等于被reader消费。所有初值和setter/reader见 [控件清单](evidence/parameter-control-inventory.csv)。
''',['309','30A','30B','30C','30D','409','40A','40B','40C','411','412'])

report('oas-surfaces.md','五面方程、交线与域','''
共享字段：0096=W、0097=W*、0098=X、0099=Y、009A=Z（前缀_0088_0091_）。各Plane为 `z=A*x+B*y+C`；镜像几何与评价absY提供左右对称。THR为局部原点，正X指向进近上游，Z为相对THR数值高度；输出CAD前清Z。

|面|方程/交线|轮廓/domain|CAD|评价使用|
|---|---|---|---|---|
|W|Aw·x+Cw（DB B=0）|WX0到WXcap；AUTO到W/W* seam|跨中线闭合点列|P41B候选；P429候选，均orphan|
|W*|Aws·x+Cws（DB B=0）|仅AUTO，W/W*至W*/Xcap|AUTO额外分段|仅P41B mode2候选，orphan|
|X|Ax·x+Bx·absY+Cx|WX与XY交线，z0/cap，FAF/FAP另截断|正负Y各一轮廓|P41B/P429；无UI评价|
|Y|Ay·x+By·absY+Cy|XY与YZ交线，z0/cap，FAF/FAP另拼接|正负Y各一轮廓|同上|
|Z|Az·x+Cz（DB B=0）|YZ0与YZcap跨中线；部分CATI尾部延伸|对称轮廓/辅助尾部|同上|

P838面面交线 `(A1−A2)x+(B1−B2)y+(C1−C2)=0`；P839固定高度 `Ax+By+C−h=0`；P83A三点拟合。Plane Y求解除数0会依分子正负给±1000000，保留原退化语义。

## 共享P41B的孤立数值域

起始面高0/入口平面，严格max依W→X→Y→Z，AUTO最后W*；tie保留先到。mode1/2赢面>150则out。mode0在x≥YZcap.x时仅Y/Z且>300排除，W/X可高于300；x更小时按YZcap点向负X反向15°线侧限进入非精密延伸段，用Z面，否则out。10000只用于求线，未作为有限射线端点界限。out不保证覆盖输入Z。

CAD轮廓、数值面域、障碍物判定是三个不同证据层，不能把一个Polyline闭环直接当成P41B的contains规则。A5真正使用共享五面普通几何；没有B4 P5E0的固定同轴分段域。
''',['412','41B','838','839','83A'])

report('w-wstar.md','W与W*的真实消费者','''
CAT I和CAT II的P307只读W，AUTO同时读W与W*。P412 mode2先求W*∩W线与WX线的交点，再求W*∩X在150m的交点，普通一条W跨线轮廓拆成两条；W仍参与，不是整体用W*替代W。

W*进入可达AUTO绘图。它也进入完整P41B的max候选，但P41B全局incoming为空，故不能称W*进入A5实际障碍物评价。PAOAS P427只引用W/X/Y/Z；改W*不会改PAOAS轮廓，独立测试已验证。GPINOP与FAF/FAP在UI上仅CATI可用，不应把强行改radio后的AUTO组合当公开模式。

E3同输入改W*：共享OAS mode0/1点列不变，mode2改变；另孤立调用P41B验证AUTO可选W*标签。这是独立源码结果，不是原插件UI执行。
''',['307','412','41B','427'])

report('gp-inop.md','GP INOP：实际构造与未调用延伸','''
P306→new _0089_0096(P39E)，传入当前OasModel、IF、名义fix。该类使用当前X/Y seam、WX0、XY300/YZ300等共享点，构造H−150的连接、IF内/外半宽4630/9260、中间75m点及Z镜像辅助轮廓。29条数值点列最终经清Z输出为二维投影。

|候选说法|代码判断|
|---|---|
|固定CATI X面|公开UI仅CATI允许GPINOP；构造器不重新查CATI，消费传入模型的X面|
|强制3°|没有；P307按当前GP算fix，模型由当前GP查库。GP3.2差异测试改变输出|
|独立300m GPINOP模型|共享CATI交点含300m，不是另查库/强制新模型|
|后续15°扩张|P3A7确有15°、10000延伸方法，但无全局incoming；Draw29条不包含该额外调用|
|完整LOC-only/NPA|几何与非精密/LOC候选相关；未找到可达专用障碍物评价及完整LOC程序状态，不能认定完整实现|

具体点列逐顶点数值见 [fixture](../round8/fixtures/geometry-points.csv)；构造Add与字段赋值见 [列表表达式](evidence/list-construction.csv)、[字段表达式](evidence/model-expressions.csv)，全部保留原方法IL。Z镜像不是另一个三维CAD面，清Z后存在重合线且不去重。
''',['306','307','39E','3A7'])

report('paoas.md','PAOAS Left/Right与P1/P2','''
P307构造P427，引用共享W/X/Y/Z，再将UI六个P1/P2系数赋值并P428重建。默认P1=(Round(tanGP,4),.091,5)，P2=(0,.091,15)，可手改；左右使用同一系数，只把Y镜像。Right正Y列表_0088_0094_0092，Left负Y列表_0088_0094_0093；各六个单侧轮廓+一个共同中线列表引用，均7条。没有两个独立CAD writer，统一P087，每条都有完整参数XData。

这是OAS与P1/P2组合保护轮廓，含0/300/600m交点与边界；不是仅一组施工辅助线，也不能称完整可达障碍物评价器。

## 点字段（前缀_0088_0093_）

|后缀|构造意义|
|---|---|
|0090/0091|WX0/WX300|
|0092|x=WX300.x与P1=600交点|
|0093/0094|XY0/XY300|
|0095/0096|YZ0/YZ300|
|0097|P1/Y与P2/Y交线相交（三面点）|
|0098/0099|P1=300与P2=300 / P1=600与P2=600|
|009A|P2/Y与P2/Z交线相交（三面点）；Z异常见下|
|009B|P1/Y与P1=300|
|009C/009D|P2=300与Z=300 / P2=600与Z=600|

**原行为异常保留**：009A.Z使用P2在0097.X/Y求值，而非009A自身XY。处理P428 IL_0032–IL_0058及源码43738行直接支持；E3显式断言保留，未修正。

## 完整但不可达P429

先矩形前筛x≥009D.x、|y|≤009D.y、x≤0092.x，外部Name=out且保留输入Z。内部先严格max按X→Y→Z→W，负值取0/Gnd；再依x与0094/009B/0098/009A分段，以X300、Y300、P1/Y、P2/Y、P2/Z线侧限切至P1/P2/Z。超过600则out且保留输入Z，否则回填面名/面高。它只算点面高，没有穿透、HL、OCA或最低标准。全程序集incoming为空，A5也不调用；孤立边界测试覆盖144输入的标签和面高，不能升级成UI评价。
''',['307','427','428','429'])

report('oas-cad.md','普通OAS列表与创建顺序','''
P306直接取共享P412生成的_0088_0091_009D，不构造B4 _008C_0095，不追加SOC同轴带。

|创建顺序（0基）|内部构造|几何来源|
|---|---|---|
|0/1|P416/P417|正/负Y面0至cap轮廓|
|2|P81F(YZ0,YZcap)|跨中线Z轮廓|
|3|P41A|入口至WX0中线|
|4（CATI/II）|P81F(WX0,WXcap)|W跨中线轮廓|
|4/5（AUTO）|P81F(W/W*点,W*/Xcap)，P81F(WX0,W/W*点)|先W*段再W段|
|最后2条|P414/P415|X正/负侧轮廓；AUTO六顶点，普通五顶点|

CATI/II：7条，顶点5/5/5/2/5/5/5；AUTO：8条，5/5/5/2/5/5/6/6。以上为默认Build()请求高度0；共享P412存在高于300的另一调用分支，但A5普通模式没有传该请求。

统一P087创建一个Group，逐列表创建二维Polyline、入ModelSpace、加XData、加入Group，最后Group入库。每条完整参数文本相同；无独立surface业务名。
''',['306','412','414','415','416','417','41A','087','089'])

report('pa-with-fap.md','PA with FAP：名义点、中间段与截断','''
P307读取绝对fix标高F、THR.Z=T，H=F−T，g=tan(GP·π/180)，名义点=(H/g,0,H)，IF=(H/g+L,0,H)。L为textBoxIF输入的中间段长度；没有减RDH，也没有地球曲率。RDH此前只进入面系数修正。用户可手输F或通过相关CAD取点量距输入其他字段；没有独立FAP高度控件。

P306 FAP第一优先分支→P443：利用X/Y seam及X面在H−150的等高线求交，截断精密面上游轮廓。W/X在H−150交点如x>IF.x则夹到IF，并在IF站距另求W/X seam点。IF内/外半宽4630/9260；内边Z=H−150，外边Z=H。中间段与截断后的X/W/Y点列连接，再附共享中线、Z轮廓、Y两侧与15°尾部。

样本11条，8/6/6/5/6/6/2/5/5/5/4；IF长度/高度改变裁剪分支及部分顶点数。原P446/P447均构造第二个局部三角形但未Add至返回列表；不补输出。完整构造表达式和原IL保留，可审计每个交点/条件。

此处“FAP”是原UI/类路径名；规范FAP定义及带RDH/曲率站距候选另见映射报告，不能以规范重算该坐标。
''',['307','443','444','445','446','447'])

report('pa-with-faf.md','PA with FAF：容差与15%下降面','''
与FAP共用P307的名义fix=(H/tanGP,0,H)和IF=(fix.x+L,0,H)。FAF分支P437另读取textBoxFafFix作为容差T（默认700m），不是700m高度。

最早点E.x=fix.x+T；E.y由X面H−150等高线在E.x求得，E.z=H−150。辅助点=(E.x−1000,E.y,E.z−150)，与E及镜像E三点拟合下降平面，得到A=.15、B=0。这是**15%**，不是15°。该平面与W面及W/X seam相交求latest点，其Z由X面计算。相关W/X轮廓在early/latest边界截断，连接IF内/外半宽4630/9260与共享Y/Z尾部。

没有±900m上限校验；也没有对称±T两端，代码只显式构造x增加T的最早点，再由下降面求另一端。规范±0.9km不能当输入验证。默认900属于绝对标高textBoxFAF；默认700属于FAF定位容差。

样本12条，9/6/6/5/7/7/5/2/5/5/5/4。P43A/P43B第二局部三角形未Add，照实保留。日志中的FAFdesEarly/Latest来自恢复类Console输出，不是原CAD运行日志。
''',['307','437','438','439','43A','43B'])

report('faf-fap-mapping.md','FAF/FAP、IF与高度字段映射','''
|field / UI label|code object / formula|used by / CAD|规范候选与证据|
|---|---|---|---|
|textBoxFAF / FAF高度；_0087_0096_0087|P307 F，H=F−THR.Z；名义fix_0087_0092_0090=(H/tanGP,0,H)|GPINOP、FAF、FAP；其余模式仍无条件parse|候选中间最低高度/下降定位点标高；不是规范定义证明，E2|
|textBoxFafFix / FAF定位容差；_0087_0095_009D|P306传P437；early.x=fix.x+T|仅FAF实际附加容差，E3测试0/700/900|下降定位容差候选；未限制±.9km，Differs|
|textBoxIF / 中间段长度；_0087_0095_009B|IF_0087_0092_0091=(fix.x+L,0,H)|GPINOP、FAF、FAP中间轮廓；无可达评价|输入长度非绝对站距、非硬编码10000；E2|
|GP|tan(GPπ/180)|fix站距；DB key；P1.A|名义GP候选，未强制3°|
|RDH|P40C加到W/W*/X/Y.C|面系数、截断交点；不减入fix站距|与规范表中FAP站距计算不一致|
|THR XYZ|F−THR.Z；frame原点和方向|CAD旋转平移|米制CAD坐标；未实现投影转换|
|P316 IF两点拾取|3D DistanceTo，F2回填L|只代替长度手输|不是自动提取航段|
|P317 FAF/最早点两点拾取|3D DistanceTo，F2回填T|代替容差手输|未用方向或投影距离|

FAF/FAP为**两个不同构造类/分支角色**，但不是两个独立名义点/高度输入。FAP不使用T；FAF叠加最早点/下降面。L=0允许IF与fix重合，负H不拒绝；GP0或非法parse成0可传播Infinity，不补合法性检查。完整setter/consumer清单见parameter-control-inventory.csv。
''',['307','316','317','437','443'])

report('hl-correction.md','A5 HL与B3/B4对照','''
未找到A5的HLm/HLr表、机场标高修正、GP修正、HL输入/显示控件或业务消费者。P41B/P429只返回面高/标签，不计算HL。**A5没有可恢复的自有HL公式，不能选用B3或B4填入。**

对照冻结结论：B3 APV P5F2=HLm+(Elev>900?HLr·.02·Elev/300:0)+(GP>3.2?(GP−3.2)·HLr·.05:0)，无round；B4 P55F无GP项、P567仅round机场增量、P56A round显示总和。A5三者均不调用。详见 [hl-comparison.csv](../round8/hl-comparison.csv)与冻结报告。

没有证据证明A5由另一窗口自动补齐最低标准；跨窗口数据关系只能记录已找到的公共模型/配置，不猜测隐藏评价路径。
''',['307','41B','429'])
report('minima.md','最低标准：缺失的可达业务链','''
A5未见DA、DH、OCA、OCH、RVR控件、后处理公式、表格、控制障碍物归并或ScreenData→Evaluate链。CAT I/II/AUTO只是模式/数据库/轮廓控制，不自动意味着具有相应运行最低标准计算。

P41B/P429为孤立单点面高函数；无障碍物原高减面高、HL、Ha→OCA/OCH、DA/DH/RVR调用。不能把孤立面高方法改名为最低标准评价器。帮助/规范的功能叙述不替代本构建事件可达证据。
''',['41B','429'])
report('obstacle-evaluation.md','孤立面高方法与评价缺口','''
P41B共享OAS、P429 PAOAS均已完整恢复并独立测试；两者全程序集direct/MethodSpec incoming均为空，事件闭包不含它们。A5未见obstacle parser、ScreenData、Evaluate、Mark、Highlight或最低标准入口。不是存在一个尚待补接的已授权实现；本轮只报告缺口。

|方法|输入/输出|业务边界|reachability|
|---|---|---|---|
|P41B|局部点；面名/面高或out|W/X/Y/Z/AUTO W*与cap/尾部域；不算穿透/HL|orphan complete method|
|P429|局部点；W/X/Y/Z/P1/P2/Gnd/out与面高|PAOAS分段，600m域；out可保留输入Z|orphan complete method|

全局incoming依据已包含MethodSpec解析；否定结论限于静态可见引用与事件路径，不能证明任意反射或外部程序集永远不调用。并未发现支持这些额外调用的证据，也不推断作者意图为旧版残留或隐藏功能。

数值用法见oas-surfaces.md及paoas.md。E3孤立调用不能改变原程序集orphan状态。依用户明确验收规则，本项要求Round8保持PARTIALLY ACCEPTED。
''',['41B','429'])

summary=rows(O/'fixtures/mode-lists.csv')
cad='''P306：P307准备→按FAP/FAF/GPINOP/OAS/PAOAS Left/Right顺序择第一checked分支→P821旋转→P823平移→P827清Z→P087/P089。

|模式|样本Polyline数|逐列表顶点数（创建顺序）|
|---|---|---|
'''
for r in summary:cad+=f'|{r["mode"]}|{r["polylines"]}|{r["vertices"]}|\n'
cad+='''|OAS AUTO|8|5/5/5/2/5/5/6/6|

样本CATI GP3 LOC3000，THR=(1000,2000,100)，end=(2000,2000,110)，F=900，L=10000，T=700，RDH15，尺寸30/6。点列数与顶点顺序取自真实Add链并以独立源码生成；不是以规范预设数量。某些输入改变截断顶点数，不能当所有输入固定模板。

## CAD实体协议

所有模式统一一个Group与逐列表一条2D Polyline。P087先new Group，再循环new Polyline，Point2d转换，AddVertexAt的bulge/start/endwidth均0，P089入ModelSpace并写XData，Append到Group，最后Group入库。未显式Closed=true；点列重复首点形成的几何闭合不等于CAD Closed属性。无Text、独立图层/颜色/线型设置；最终宿主默认值未运行验证。

没有3DPolyline、Face、Surface、Solid、Mesh；内存点含面高和Z镜像，清Z及Point2d将其变为平面投影。不会自动去重重合图元。Group无Description或XData。每子Polyline带完整参数，非surface标签。

## 保护区衔接索引

[CAD API词法候选](evidence/connection-api-sites.csv)、[数值交线/交点/镜像调用](evidence/connection-semantic-calls.csv)、[条件](evidence/condition-expressions.csv)、[列表构造](evidence/list-construction.csv)、[字段赋值](evidence/model-expressions.csv)、[逐顶点fixture](../round8/fixtures/geometry-points.csv)互相对应。词法索引含公共依赖候选，SelectAll/BlockReference/Spiral等不能未经caller过滤归为A5实际功能；GroupBox不是CAD Group。

核心是数值line/plane交点后组织列表，没有AutoCAD IntersectWith、Offset、Arc/切线、实体包络、自动裁剪或Erase重建证据。FAF/FAP数值截断已代码化；既有图元选择只取XData参数，不参加几何裁剪。没有找到人工选两条边完成衔接的A5事件；需要设计人员观察图面做后续编辑是否存在，不能由静态缺失直接断言具体工作步骤已实现。
'''
report('cad-output-map.md','六模式CAD输出与衔接',cad,['306','087','089','821','823','827','134'])

report('xdata-schema.md','XData：完整参数而非面标签','''
每条Polyline依次写TypedValue(1001,"WsObject")、TypedValue(1000,P319完整分段JSON参数文本)。Group没有Description/XData赋值；未写Kind、surface name、面高、Radius或单独业务标签。输出顺序可用于审计，但不能反推XData有面类型字段。

P318 GetEntity选任意实体→取整个XData→直接读索引1的Value文本→P31B导入选择→P31A解析。非OK选择直接返回，null XData及空文本有提示；不按RegApp过滤，不验证schema或数组长度，短数组/错误内容仍有失败风险，不能改写成强类型保护区对象选择。它只恢复参数，不从所选实体顶点反求面系数，不进行障碍物评价。

完整协议/样本见 [参数格式](oas-txt-format.md)与 [sample](../round8/fixtures/a5-parameters.txt)。未运行AutoCAD，超长XData的宿主限制/异常未实测。
''',['318','319','31A','31B','087','089'])

snap=json.loads((O/'fixtures/a5-parameters.txt').read_text().split('|')[1].split(':',1)[1])
report('oas-txt-format.md','A5参数文件完整协议','''
P319输出：

```text
RUNWAY:{...}|APPROACH:{...}|PAOAS:{...}|OAS:{...}
```

每一段值是独立JSON对象；整体不是单一合法JSON。P31C默认扩展名.json，也支持.txt，UTF8写出；P31D UTF8读取后P31B选择导入范围。没有因扩展名txt自动采用B4 CSV解析器。

|分段/字段（大小写敏感）|Control / business consumer|数据库/输出关系|
|---|---|---|
|RUNWAY.THR / DER，各X/Y/Z|THR/end六文本，P306frame / P307相对高度|不参与DB key；决定变换|
|APPROACH.AppType|comboBoxAppType.Text|DB mode来源依UI SelectedIndex；文本回填事件时序未模拟|
|CAT|comboBoxCat.Text|尺寸默认setter，A5无HL表|
|GP|comboBoxGP.Text|DB key、fix、P1.A|
|MissedCG|comboBoxMissCG.Text|DB key|
|LocDistance|LocDistance.Text|PartB key，保存为字符串|
|RDH|textBoxRDH|P40C面常数修正|
|WingSpan / WheelBase|textBoxWing / textBoxWheel|实际半翼展s/轮参数t，不自动改字段名|
|FAF_Height / IF_Length / FAF_Tolerance|textBoxFAF / textBoxIF / textBoxFafFix|F绝对标高 / L追加长度 / T容差，米|
|PAOAS.P1/P2，各a/b/c|六文本|P307/PAOAS构造，非DB字段|
|OAS.W / Ws / X / Y / Z，各a/b/c|十五面系数文本|P307读模型；**Ws**不是WS/W*；写每条Polyline完整快照|

AppType/CAT/GP/MissedCG/LocDistance保存为字符串，其余为数值。无ELEV/LIGHT、draw mode、HL或最低标准字段；B4旧样例的同名/近似字段不构成兼容。

P31A按`|`分段，首个`:`拆名称，区分大小写，重复分段后者覆盖。full=true按RUNWAY→APPROACH→PAOAS→OAS写控件；false只OAS。数值一般F2，面A/B F6、C F2，P1/P2 A/B F4。缺分段可能跳过，缺成员可能写入部分控件后catch提示；没有事务回滚。E3验证缺W.b时W.a已改动仍保留。P31B默认Button2（仅OAS），用户可选全部。

完整可解析样本在fixtures/a5-parameters.txt。序列化恢复使用同JavaScriptSerializer；测试Cell不模拟WinForms Text/SelectedIndex联动、事件重入和config时序，往返通过不代表原UI最终状态已动态验证。
''',['319','31A','31B','31C','31D'])

report('persistence.md','config与便携文件、外部程序关系','''
|通道|入口/协议|用途与边界|
|---|---|---|
|config.xml|Load P303→公共P0F4，Closed P304→P0F6；节点FormPA|通用dotted控件状态持久化，保存窗体支持的属性；不是P319分段协议|
|参数文件|P31C/P31D→P319/P31A，UTF8 .json/.txt|便携参数快照；可只导入OAS或全部；不含绘图模式/HL|
|实体XData|P306保存P319；P318读取|同参数快照，不含几何类型标签；不是完整CAD对象序列化|

Load先设默认再读config，实际控件事件可触发重算；Closed将当前状态持久化。默认值不代表原件config覆盖后的启动状态。本轮原config只读，不以恢复适配器写回。

## WsOasPara.exe

**No direct process invocation evidence found.** 全程序集唯一Process.Start位于其他Form的P395，A5事件闭包不可达。A5闭包中保护helper P888的GetCurrentProcess/Id不是启动外部程序；见global-process-calls.csv。未发现A5 ShellExecute、专用输出TXT路径或外部协议调用。通用文件对话框可打开用户提供的文件，不证明兼容该EXE输出格式。按范围不执行、不扩逆EXE。
''',['303','304','0F4','0F6','318','31C','31D'])

report('cad-interactions.md','人工CAD交互及可自动推导条件','''
|入口/API|用户选什么业务对象|为什么由用户提供（代码能证明的范围）|结果进入哪里|可由已有数据推导？（推断）|
|---|---|---|---|---|
|P314→GetPoint|THR入口三维坐标|A5无跑道对象ID或机场数据库检索；只存文本坐标|THR XYZ→相对H、frame、参数快照|若项目已有跑道坐标可直接赋值；本构建未实现自动检索|
|P315→GetPoint|跑道另一端三维坐标|同上；未根据跑道号/长度自动生成|end XYZ→方向frame；swap可交换|需外部可靠跑道方向/端点，当前参数本身不足唯一确定|
|P316两次GetPoint|IF航段起/终点|没有程序航段对象关联，人工量距|3D DistanceTo→F2→IF长度L|若已有同坐标IF/fix可算长度；代码不选择对象、未投影至航迹|
|P317两次GetPoint|FAF点及FAF最早点|没有设施/定位容差对象或模型ID|3D DistanceTo→F2→容差T→FAF下降面|若已有定位误差可直接填T；本轮不替作者生成容差|
|P318→GetEntity|带参数的OAS相关实体（没有类型筛选，实际可选任意实体）|无实体注册表、无自动选唯一当前快照|XData[1]→导入选项→P31A控件回填|若保存图元ID/当前参数可免选；多组参数时不能无依据选唯一|
|P31B对话选择|全部参数或仅OAS|由用户决定是否覆盖跑道/进近/P1P2|full布尔控制P31A|可由调用意图指定，原实现交互决定，默认仅OAS|
|P31C/P31D文件对话|存/取便携参数文件路径|无固定项目参数文件注册|UTF8读写→P319/P31A|可由项目元数据指定；原逻辑不自动推导|

P313 swap不选实体，直接交换六个文本。各GetPoint通过公共helper，非按实体类型/业务ID拾取；窗口隐藏、SetFocus后取点再恢复。取消/异常路径保留原方法证据，未宿主测试。GetSelection未见A5核心调用；SelectAll词法候选来自共用依赖，不能算A5障碍物导入。

数值面间交线、截断、左右镜像和轮廓列表已代码化；没有依赖人工选边才能计算这些交线的事件。后续人工观察/编辑的具体规则缺少代码证据，标未确定，不凭“没有自动裁剪”就杜撰手工流程。
''',['313','314','315','316','317','318','31B'])

# Audit-friendly intermediate products: exact expressions, not invented semantic source.
expressions=[];adds=[];method_io=[]
for m in rows(E/'recovery-method-map.csv'):
 p=E/('methods/'+m['processed_token']+'.source.txt')
 if not p.exists():continue
 for l in p.read_text(encoding='utf-8').splitlines():
  if re.search(r'_008\w+\s*(?:\.[XYZ])?\s*=',l):expressions.append(dict(token=m['processed_token'],original_token=m['original_token'],file=p.name,expression=l))
  if '.Add(' in l or 'return new List<' in l:adds.append(dict(token=m['processed_token'],original_token=m['original_token'],file=p.name,expression=l,order_note='source expression order; flattened control flow must follow IL/branch conditions'))
csvout(E/'model-expressions.csv',expressions);csvout(E/'list-construction.csv',adds)
ios=[('306','all UI + prepared lists','one Group / per-list 2D Polyline','FAP > FAF > GPINOP > OAS > L > R; P307 unconditional'),('307','OAS, P1/P2, GP, F, THR.Z, IF length','OAS/PAOAS model + nominal fix + IF','Wstar only mode2; no RDH subtraction in fix'),('30A','4 combos, dimensions, RDH, LOC','corrected/rounded coefficient texts','all SelectedIndex != -1; LOC 2000..4500'),('409','GP text, enum mode, CG text, LOC text','OasModel raw coefficients','missing file null; missing row ToString failure'),('412','five planes / mode / optional requested height','shared numeric lists','mode0/1/2 cap & Wstar; A5 default request0'),('39E','shared OAS + IF + nominal fix','29 sample lists','no force GP/CAT; orphan extension excluded'),('428','WXYZ + P1/P2','left/right7 lists + seam points','300/600 construction; anomalous cross-point Z'),('437','OAS + IF + fix + tolerance','PA-FAF12 sample lists','early+T; 15% plane; clipping'),('443','OAS + IF + fix','PA-FAP11 sample lists','H-150 intersections; clamp WX to IF'),('41B','local point / mode / shared planes','surface point/label','strict max; cap/extension; orphan'),('429','local point / PAOAS planes/seams','surface point/label','piecewise P1/P2; 600/out; orphan'),('319','form numeric/text state','four section JSON text','catch returns empty'),('31A','sectioned text + full bool','partially updated controls','case sensitive; no rollback'),('318','selected Entity.XData[1]','P31A import','nonOK return; null/empty prompt; no length/schema validation'),('087','paths + metadata text','2D Polylines + Group','loop ordering; no surface tags')]
for p,inp,outp,branch in ios:
 m=ms['0x06000'+p];method_io.append(dict(method='P'+p,original_token=m['original_token'],original_RVA=m['original_rva'],processed_RVA=m['processed_rva'],inputs=inp,outputs=outp,branches=branch,source_line=m['line'],processed_IL='processed/0x06000'+p+'.il.txt'))
csvout(E/'method-input-output.csv',method_io)
fields=[('OasModel','_0088_0091_0096/97/98/99/9A','W/W*/X/Y/Z','P307/P409/P412/P41B'),('OasModel','_0088_0091_009B/9C/9D','mode / cap / output paths','P411/P412'),('Form','_0087_0092_0090/91','nominal fix / IF','P307 -> P39E/P437/P443'),('Form','_0087_0092_008E/8F','shared OAS / PAOAS','P307 -> P306'),('PAOAS','_0088_0094_008B/8C/8D/8E/8F/90','W/X/Y/Z/P1/P2','P427/P428/P429'),('PAOAS','_0088_0094_0092/93','Right/Left output paths','P428 -> P306')]
csvout(E/'model-fields.csv',[dict(owner=a,field=b,meaning=c,evidence=d) for a,b,c,d in fields])

# Standard excerpts are a second-stage mapping, not recovery inputs.
std=json.loads((ROOT/'recovered/round5/standard-pages.json').read_text(encoding='utf-8'))
pages={270,272,275,276,277,278,284,286,316,317,318,319,320}
(E/'standard-search.json').write_text(json.dumps(dict(path=std['path'],sha256=std['sha256'],source='frozen round5 PDF text extraction; page numbers are physical PDF pages',pages=[p for p in std['pages'] if p['pdf_page'] in pages]),ensure_ascii=False,indent=2),encoding='utf-8')
standard=[('CAT I/II cap','P411/P412 300/150m','PDF275 OAS height domains','Matches','cap alone does not prove complete standard-compliant geometry'),('AUTO W/W*','P307/P412 combine W and Wstar; distinct DB key','PDF276 AUTO additional Wstar/X changes','Matches','table provenance/version not established'),('dimensions/RDH','P40B/P40C copied corrections','PDF276 s/t/RDH corrections','Matches','numeric model verified; full table authorship unresolved'),('PAOAS P1/P2','P1=(Round(tanGP,4),.091,5), P2=(0,.091,15)','PDF318-320 appendix D, table D-1','Matches','UI allows arbitrary coefficients; rounded tan'),('PAOAS terminal','P428 fixed 600m','PDF318-320 terminal relative to radar minimum altitude minus300','Differs','no minimum radar altitude reader; Implementation basis unresolved'),('GPINOP','current OAS seam + fix/IF projection; no force3deg; no invoked P3A7','PDF270 1.1.7 NPA/LOC-only treatment','Implementation basis unresolved','incomplete LOC-only relationship; no reached evaluation'),('FAP nominal station','(F-THR.Z)/tanGP; no RDH/curvature','PDF272 1.4.2; PDF316-317 distance tables','Differs','Author simplification candidate; not corrected'),('FAF tolerance','single early x+T; default700; no900 check','PDF272 1.4.3 max +/-0.9km candidate','Differs','negative/oversized T not guarded; terminology mapping conditional'),('FAF descent plane','.15 slope via 1000/150 point delta','PDF272 1.4.3 15 percent plane','Matches','matching slope does not establish full method equivalence'),('intermediate segment','IF=fix.x+L, inner4630 outer9260, H-150/H','PDF272 intermediate/FAP connection context','Implementation basis unresolved','no facility/tolerance derivation for fixed widths in this path'),('HL/minima','no A5 implementation or event chain','PDF277-278,286 OCA/HL and correction tables','Missing','do not insert B3/B4 formulas'),('OAS truncation','P437/P443 numerical intersections + IF clamp','PDF272 descent-fix/FAP candidate','Implementation basis unresolved','unadded local triangles retained; no claim of full compliance')]
csvout(A/'standard-mapping.csv',[dict(topic=a,code_fact=b,standard=c,classification=d,difference_or_limit=e,evidence='E1/E2 code; N mapping; 实现依据待确认') for a,b,c,d,e in standard])
stdmd='''规范基线为项目 AC-97-FS-005 / 民航规〔2020〕12号。PDF SHA256 `6b6b6f04380f3e0a138ca57bb95fcddb0a390a5b4aa7a9c7a391ff35bb92c8ed`。页码为物理PDF页，不是印刷页；摘录见 [standard-search.json](evidence/standard-search.json)。以下先列恢复行为，再作N层对应；没有按规范修代码。不能仅据公式相近断定作者依据某版ICAO Doc8168。

|主题|代码事实|当前规范候选|分类/差异|
|---|---|---|---|
'''
for a,b,c,d,e in standard:stdmd+=f'|{a}|{b}|{c}|{d}；{e}|\n'
stdmd+='''
差异统一记录“**实现依据待确认**”。Older-version candidate / Author simplification只作为待核假设，未以现有材料确认历史规范版本。W/W*、15%、P1/P2常数对应不证明其余域/截断/评价均与2020版一致；A5无HL也不能解读为规范允许省略。
'''
report('standard-mapping.md','规范对照与实现依据待确认',stdmd,['307','40B','40C','412','428','437','443'])

comparison=[
 ('database loader','P409','P571','Copied implementation','same schema/key/query, separate MethodDef; A5 standalone parameter class'),
 ('decoder','P40A','P572','Copied implementation','same digit transform and fixed slicing'),
 ('size/RDH','P40B/P40C','P573/P574','Copied implementation','same arithmetic; independent methods'),
 ('OasModel','P411-P41E / _008A_0093','same','Same MethodDef','shared five planes, cap, Build and orphan P41B'),
 ('Plane','P834-P840','same','Same MethodDef','same line/plane equations, numeric not CAD surface'),
 ('W/Wstar draw','P412 mode2 W+Wstar','P5DE/P5DF WXYZ only','A5-only','B4 stores Wstar in shared model/text but dedicated geometry ignores it'),
 ('surface equations','shared five-plane model','shared + private four-plane copy','Same MethodDef','mathematical plane engine same; domain/consumer not interchangeable'),
 ('geometry/domain','shared P412; private GPINOP/PAOAS/FAF/FAP','private P5DE/P5DF/P5E0','A5-only','B4-only dedicated same-axis transition is separate'),
 ('HL','none','P55F/P567/P56A','B4-only','A5 has no corresponding chain; B4 no GP correction'),
 ('FAF/FAP','nominal fix/IF, tolerance and two classes','FAF altitude request only; no FAP object','A5-only','not equivalent despite similar text label'),
 ('GPINOP/PAOAS','P39E/P427','none dedicated','A5-only','several private geometry classes'),
 ('CAD writer','P087/P089','same','Same MethodDef','2D Polyline + Group + WsObject; A5 transform rotate/translate/clearZ'),
 ('frame/point helpers','P821/P823/P827 + common frame','same helpers','Same MethodDef','ordering differs: B4 rotate/clearZ/translate'),
 ('portable TXT','P319/P31A sectioned JSON','P565/P561 CSV text','A5-only','different schema/format; common UTF8 concepts not same method'),
 ('XData envelope','P087/P089 WsObject+full text','same writer','Same MethodDef','payload differs: A5 four section JSON, B4 CSV; no labels'),
 ('evaluation','P41B/P429 orphan; no parser/UI','P5E0/P567 orphan; parser/Mark reachable; Evaluate prompt','B4-only','private evaluation bodies different; shared P41B remains orphan'),
 ('config','P0F4/P0F6 FormPA','same helper / other form node','Same MethodDef','same generic persistence, different UI state schema'),
 ('SOC/PBN transition','none','P55E/P5DF','B4-only','do not import B4 SOC -900 or fixed transition into A5')]
csvout(O/'b4-a5-comparison.csv',[dict(component=a,A5=b,B4=c,classification=d,detail=e,evidence='method-index/direct-calls + frozen Round7 reports; E1/E2') for a,b,c,d,e in comparison])
hl=[('A5','none','none','none','none','none','P41B/P429 surface only; no HL/minima controls or event path'),('B3 APV','P5F2','H35/8,A40/13,B43/18,C46/22,D49/26','Elev>900: HLr*.02*Elev/300','GP>3.2: (GP-3.2)*HLr*.05','no round','frozen B3 hl-correction.md; different MethodDef'),('B4 business','P55F','A40/13,B43/18,C46/22,D49/26','Elev>900: HLr*.02*Elev/300','none','no round','SOC consumer; frozen B4'),('B4 minima','P567','same four rows','same increment','none','round increment2','orphan minima body, not A5'),('B4 display','P56A','HLm/r text','same increment','none','round total2','HLcor display not read by business')]
csvout(O/'hl-comparison.csv',[dict(module=a,method=b,table=c,elevation=d,GP=e,rounding=f,provenance=g) for a,b,c,d,e,f,g in hl])

counts=json.loads((O/'fixtures/numeric-counts.json').read_text());st=json.loads((O/'static-tests.json').read_text());total=sum(counts.values())
ver='''## 分层结果

全部成功，数值断言和静态检查分开计数：

|层|通过数|覆盖内容|
|---|---|---|
'''
detail={'database':'27组真实DB行；CAT0/1/2，GP3/3.2/3.5，LOC2000/3000/4500；缺文件另列','cross-module':'A5 loader/修正与B4复制实现比较；不是独立标准oracle','formula':'尺寸/RDH12/15/18、fix/IF、交换、RDH不进入名义点','surface':'交线独立线性代数参考；Wstar敏感性；P41B及P429孤立边界','geometry':'六模式有限点、mirror、清Z；F650/900/1200，L0/6000/10000，T0/700/900；异常Z、GP3.2、Wstar不进PAOAS','mode-dispatch':'六分支优先级、CAT UI gate、Wstar显隐、PAOAS面板','serialization':'四段协议、full/OAS-only、精度、旧CSV不兼容','degenerate':'GP0/非法、负高、零距、缺key/文件/字段、部分写入、LOC夹限'}
for k,v in counts.items():ver+=f'|{k}|{v}|{detail[k]}|\n'
ver+=f'|event/reachability|{len(st["checks"])} 静态检查|原/处理事件身份、MethodSpec incoming、orphan、无外部Start、无B4构造、真实fixture一致性|\n\n独立源码 **{total}** 条 + 静态 **{len(st["checks"])}** 条；不能合称原程序集运行验证。\n'
ver+='''
## 复现与适配边界

`python recovered/round8/build.py`编译本轮独立恢复源码及冻结数学依赖，再运行Round8.Tests.exe；测试不加载目标DLL/AutoCAD/目标SQLite库。系统csc写PE在沙箱下曾CS0016，经限定命令提权后成功；仅操作本轮输出。适配器内存fixture代替文件/SQLite IO；保留SQL/key/decoder/修正业务体。Cell仅模拟被读取的控件属性，不模拟WinForms自动互斥、Text到SelectedIndex、事件重算时序。P306仅计算dispatch/transform，CAD事务与实体创建依据IL静态核对，未模拟宿主API。

[tests.log](../round8/tests.log)、[compile-tests.log](../round8/compile-tests.log)、[数值记录](../round8/fixtures/assertions.csv)、[分层计数](../round8/fixtures/numeric-counts.json)、[32项静态检查](../round8/static-tests.json)、[源码输入哈希](../round8/test-inputs.json)、[fixture索引](../round8/fixture-index.json)。空编译日志表示csc无诊断，不表示漏执行。

fixtures/failure.txt保存早期测试模板误计PA-FAF13条（实际12）的历史失败，不代表当前失败；初期其他数量也曾误计，均按IL Add链纠正测试期望，未改目标/恢复算法。收口时已归档为historical-failure.txt并在fixture索引中注明。额外测试初次误用PAOAS三参构造器导致CS1729，改为真实二参构造及赋值后重建；同样只改测试。

本轮不是全输入穷举，也没有证明与原程序数值逐点等价。跨模块复制算法比较不充当独立规范证明；有限点/清Z断言只覆盖投影性质，列表构造/未Add局部点等由原/处理IL静态证据补强。测试通过不消除原行为异常、不可达评价链或未知历史依据。
'''
report('verification.md','验证分层、适配与实际限制',ver)

report('unrecovered.md','未恢复/未验证项及保留异常','''
|事项|当前结论|后续所需证据|
|---|---|---|
|A5障碍物/HL/最低标准调度|本构建未发现入口，P41B/P429完整而orphan|另一可信构建或明确外部调用证据；不能靠补接称恢复|
|原插件运行等价|无E4，只有E3源码检查|若另行授权，独立运行环境与可审计输入/图元结果|
|完整WinForms重建|designer/控件/事件静态索引完整；恢复源码是切片|宿主UI事件时序、config覆盖与自动重算的验证|
|CAD宿主最终属性/限制|writer无显式layer/color/Closed；未执行宿主|宿主默认、超长XData、取消/异常的真实行为|
|规范版本/数据库来源|按2020规范映射，差异实施依据待确认|作者来源/历史标准/原始计算表；不扩逆新版PANS-OAS|
|PAOAS异常点Z|P428跨点赋值直接证据，原样保留|用途/作者解释未知；不修正|
|FAF/FAP局部第二三角形|P43A/B与P446/447构造但未Add|原构建事实，不能补画后声称原行为|
|GPINOP尾部15°|P3A7无incoming|不能声称可达，也不推断作者意图|
|文件兼容|A5四段JSON，无旧CSV dispatcher|WsOasPara输出实际协议关系未证明；本轮不扩逆|

无因上述缺口暂停阶段推进；它们已作为收口限制逐项记录。所有本轮可静态恢复的正常链已完成。验收按用户规则为PARTIALLY ACCEPTED，之后停止，不进入新业务模块。
''',['3A7','428','429','43A','43B','446','447'])

answers=[
('A5是绘图器还是评价器？','drawing-oriented；无可达障碍物/HL/最低标准入口，P41B/P429孤立。','overview.md'),
('六模式分别什么类？','GPINOP _0089_0096；PAOAS L/R _008A_0097；OAS _008A_0093；FAF _008A_0099；FAP _008A_009B。','class-map.md'),
('是否统一OAS geometry engine？','基础五面/交点共享；另有多种私有几何类，不是完整统一六模式引擎。','class-map.md'),
('是否直接查oas.db？','是，P30A→A5 P409；PartA/PartB参数化ID查询。','oas-parameter-model.md'),
('与B4同loader？','否；A5 P409/P40A与B4 P571/P572是独立复制MethodDef；同schema/key/decoder，无插值。','oas-parameter-model.md'),
('W/W*如何选择？','CATI/II用W；AUTO组合W+W*，不是替换W；PAOAS不读W*。','w-wstar.md'),
('CAT II AUTO实现什么？','mode2数据库key、150m cap、W*/W与W*/X交点及两段W轮廓，8条；无实际评价调度。','w-wstar.md'),
('GP INOP真实几何？','当前OAS交点+fix/IF+H−150/75及镜像投影29条；不强制3°或重查CATI，P3A7延伸不可达。','gp-inop.md'),
('PAOAS Left/Right是什么？','共享WXYZ+P1/P2的0/300/600复合轮廓；Y镜像各7条，共用中线；非独立writer。','paoas.md'),
('普通OAS输出？','Y±、Z跨线、中线、W跨线、X±；AUTO W分2条，7/8条二维折线。','oas-cad.md'),
('PA with FAP怎样构造？','名义H/tanGP、追加IF长度；H−150面交点截断与IF夹限；11列表并接共享尾部。','pa-with-fap.md'),
('PA with FAF怎样构造？','共用名义fix，early.x+T，三点拟合15%下降面求latest，截W/X并接IF/尾部；12列表。','pa-with-faf.md'),
('FAF/FAP是否两个不同角色？','不同构造类/分支；共用一个名义点及高度控件。FafFix是容差700，不是高度；FAF900为绝对标高。','faf-fap-mapping.md'),
('A5 HL公式？','未发现自有HL表、公式、控件或消费者。','hl-correction.md'),
('与B3/B4哪个相同？','均无可等同A5公式；B3含GP项，B4不含；不能移植补齐。','hl-correction.md'),
('有OCA/OCH/DA/DH evaluator？','无A5可达链；P41B/P429只面高/标签，不算穿透或最低标准。','minima.md'),
('六模式创建什么实体？','一个Group+每点列一条2DPolyline；样本29/7/7/7(8)/12/11，按列表顺序。','cad-output-map.md'),
('有3D实体？','没有；内存三维点经清Z与Point2d输出二维投影，无Surface/Face。','cad-output-map.md'),
('写哪些XData？','每子Polyline 1001 WsObject + 1000完整P319参数文本；Group不写。','xdata-schema.md'),
('有surface business label？','无独立Kind/面名/高程标签，不能从参数快照断定所选线具体面。','xdata-schema.md'),
('OAS TXT完整格式？','RUNWAY/APPROACH/PAOAS/OAS四段JSON以竖线拼接，.json/.txt UTF8；Ws大小写敏感，非旧CSV。','oas-txt-format.md'),
('config与TXT什么关系？','config用FormPA通用dotted控件状态；便携文件为四段参数快照，不是同协议。','persistence.md'),
('是否直接调用WsOasPara.exe？','No direct process invocation evidence found. P395外部Start不从A5可达。','persistence.md'),
('真正共享哪些MethodDef？','P411–P41E OasModel、P834–P840 Plane、P087/P089 writer及点线/变换/frame/config公共helper；P41B虽共享但orphan。','class-map.md'),
('哪些loader/geometry复制？','A5 P409–P40C vs B4 P571–P574 loader/decoder/尺寸/RDH复制；B4专用WXYZ几何另复制公共轮廓再加同轴带，A5不构造。','class-map.md'),
('P41B从A5可达？','否；全局direct/MethodSpec incoming空，A5事件闭包不含；P429同样不可达。','obstacle-evaluation.md')]
closure='''# Round 8 Closure — A5 Precision Approach / OAS

**Round 8: PARTIALLY ACCEPTED (static recovery)**，2026-10-28。

Round 1–7及原件冻结；只写本轮两目录。六模式、DB关系、W/W*、FAF/FAP、CAD、文件及B4比较已静态闭合。P41B/P429完整但不可达，触发用户指定部分验收条件；不补接、不扩模块。无原插件/AutoCAD/WsOasPara执行。

## 26项逐条答复

|序号|问题|答复|证据报告|
|---|---|---|---|
'''
for i,(q,a,p) in enumerate(answers,1):closure+=f'|{i}|{q}|{a}|[报告](../A5-PrecisionApproach/{p})|\n'
closure+='''
## 验收门槛

|门槛|静态结论|保留限制|
|---|---|---|
|six mode dispatch|完整恢复优先级及UI gate|未模拟WinForms宿主事件时序|
|database relationship|同schema/复制loader，直接查库链闭合|27行fixture，非全表全输入穷举|
|W/W* / AUTO|mode2组合、150m及8条CAD闭合|不可达P41B不算UI评价|
|FAF/FAP|名义点、T/L/H、截断/夹限和writer闭合|未Add局部三角形、简化站距保留|
|CAD writer|2D Polyline/Group/完整XData静态闭合|无宿主图元实测|
|TXT/config|独立协议、full/OAS-only、异常部分写入闭合|UI自动重算时序未运行|
|evaluation reachability|无direct/MethodSpec incoming，孤立方法完整恢复|按用户规则必须PARTIALLY ACCEPTED|
|B4/A5关系|同MethodDef/复制/A5-only/B4-only分列|不修改冻结Round7比较|
|fixtures|全部分层通过|E3独立源码，不是E4原运行|

'''
closure+=f'## 验证与完整性\n\n独立源码{total}条：'+ '；'.join(k+' '+str(v) for k,v in counts.items())+f'。另event/reachability静态{len(st["checks"])}条。\n\n'
closure+='''[完整验证边界](../A5-PrecisionApproach/verification.md)、[tests.log](tests.log)、[静态检查](static-tests.json)、[fixture索引](fixture-index.json)、[冻结核验](integrity-report.json)、[本轮清单](output-manifest.json)。5811项冻结基线最终逐文件核对；实际结果以integrity-report.json为准。

## 未完整逆向的公开功能清单（仅列后续，不执行）

排序先看业务价值，再看已恢复依赖，最后看剩余未知量。以下状态引用既有冻结成果，不重新验收旧轮，也不因目录存在称完整。

|顺位|公开功能/缺口|业务价值|依赖已恢复程度|剩余未知量/既有状态|
|---|---|---|---|---|
|1|A4 Y04_导航设备保护区|高：尚缺完整导航设施保护链|点线/坐标/CAD/容差基础已恢复|无独立完整恢复包；需先确认真实设施分支与评价范围，高未知|
|2|A7 Y07传统离场的跨窗口业务覆盖与验证|高：直线/定高/定点/全向核心|Round2静态链、评价、CAD已交付|Round2 PARTIALLY；导航方式/电台上空/人工衔接等不能仅凭现有三类推断完整，原运行与完整UI未验证|
|3|A3 Y03定位容差与保护区衔接|高：多个程序基础输入|Round1单台/KK早晚/顶空、公共几何已恢复|PARTIALLY；交叉定位按钮仅一台一方向，不自动两设施求交；完整designer/config及运行未知|
|4|A1/B1/B2 风螺旋、FlyBy、FlyOver DF|高：转弯与连接|Round3 writer/顶点/NN/KK静态成果已冻结|Round3 PARTIALLY；当时兼容编译/分支运行数值缺口及宿主属性，须按新授权单独收口|
|5|B3 Y53、B5 Y55、B4 Y54、A5 Y05的不可达评价/最低标准缺口|高，但可能是原构建功能缺失|Round5–8孤立业务体、可达性及共享层已恢复|均PARTIALLY；需要其他可信构建/外部入口证据，继续同构建逆向不保证有可恢复调度，不能补接冒充恢复|
|6|A2、Y92/xInfo/ScreenData/Mark、A8/Y09主副区、A10|中高：公共数值/障碍物与专项评价|Round1/2静态切片与兼容编译已有|PARTIALLY；完整UI/config、宿主业务运行与输出等价缺口；Y09已有公共评价链不算未开始|
|7|公开CAD辅助命令 exline/RCL/rectLine/NMCIRCLE/Arc2及图层/块工具|中：设计操作便利|公共writer与旧命令入口索引已有|本轮未逐项验收；不是断言全部未恢复，先核已有报告再补缺口|

Y06/A6 Round4 = ACCEPTED (static recovery)，不列为未完整静态恢复；运行/规范批准不因此完成。命令边界依据冻结commands.csv/command-entrypoints.md；工具/诊断入口Hello/notReady/Command1/2不自动升级为航空业务模块。Misc/PANS-OAS/课件来源调查保留为早期总任务待核材料，优先级低于公开主链，当前不扩逆。

## 停止

Round 8收口。未改变原算法、未修改旧轮、未开发替代软件；不自动进入任何其他模块。
'''
write(O/'closure.md',closure)

plan=(O/'PLAN.md').read_text(encoding='utf-8').replace('[ ]','[x]')
plan=plan[:plan.index('## 当前状态')]+'''## 当前状态

六阶段完成，Round 8: **PARTIALLY ACCEPTED (static recovery)**。DB关系/六模式/W*/FAF/FAP/CAD/文件已静态闭合；P41B/P429完整而不可达，按用户条件保留部分验收。独立源码2980条与静态32条通过；本轮无E4。完整性结论见integrity-report.json，交付与26问见closure.md。之后停止，不自动进入新模块。
'''
write(O/'PLAN.md',plan)
# Keep historical failure unambiguous without deleting its audit trail.
if (O/'fixtures/failure.txt').exists():
 (O/'fixtures/failure.txt').replace(O/'fixtures/historical-failure.txt')
fixture=[]
for p in sorted((O/'fixtures').glob('*')):
 if p.is_file():fixture.append(dict(path=str(p.relative_to(ROOT)),size=p.stat().st_size,sha256=hashlib.sha256(p.read_bytes()).hexdigest(),role='historical, superseded test expectation failure; current run passed' if p.name=='historical-failure.txt' else 'independent source fixture/result; see verification.md'))
(O/'fixture-index.json').write_text(json.dumps(dict(numeric_counts=counts,numeric_total=total,static_layer='event/reachability',static_count=len(st['checks']),files=fixture),ensure_ascii=False,indent=2),encoding='utf-8')
print('reports',len(list(A.glob('*.md'))),'numeric',total,'static',len(st['checks']))
