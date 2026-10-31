from pathlib import Path
import csv,json,re
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round7';A=ROOT/'recovered/B4-PbnIls';E=A/'evidence'
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,rs):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
ms={x['processed_token']:x for x in rows(E/'method-index.csv')};calls=rows(E/'direct-calls.csv');events=rows(E/'events.csv');reach={x['processed_token']:x for x in rows(E/'reachability.csv')}
common='\n\n证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。\n'
def write(n,text,tokens=()):
 s=text.strip()+common
 if tokens:
  s+='\n## 关键定位\n\n|P|原 MethodDef / RVA|处理 RVA|反编译行|\n|---|---|---|---|\n'
  for t in tokens:
   key='0x06000'+t;m=ms[key];s+=f'|P{t}|{m["original_token"]} / {m["original_rva"]}|{m["processed_rva"]}|{m["line"]}|\n'
  s+='\n完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。\n'
 (A/n).write_text(s,encoding='utf-8')
write('overview.md','''# Round 7 — B4 PBN-ILS

**PARTIALLY ACCEPTED (static recovery)，2026-10-28。** 完成本轮证据恢复并停止；不进入 A5。

B4 实际组合是：**OAS 系数查询/修正 + OAS 向同轴固定宽度复飞区的衔接绘图 + 独立未调度的面评价/最低标准方法**。没有证据支持完整任意定点转弯程序。窗口只长期保存源 DBPoint 列表、ID 字典和 HL 表；没有统一 Procedure，也没有常驻的 OAS+转弯+障碍物程序对象。

参数事件用共享 OasModel（W/W*/X/Y/Z）；CAD 临时构造另一个 PbnIlsTurn（原类 _008C_0095，保留历史业务称呼，**不代表已恢复任意转弯**），只含 W/X/Y/Z、SOC 衔接和副区数值面。CAT II AUTO 的 W* 没有进入这个专用模型。CAD、ScreenData/转换、导入状态可达；Evaluate 仅弹“基础版不支持此功能”；KML 空体。

## 已交付

- 四个数值类完整机械恢复、13 个 Form 数值/序列化方法、数据行/CAD变换测试适配器及真实空 KML 入口。
- [事件图](event-map.md)、[参数模型](oas-parameter-model.md)、[曲面与域](oas-surfaces.md)、[衔接构造](oas-pbn-connection.md)、[障碍物链](obstacle-evaluation.md)。
- 243 个方法索引（84 个核心含共享 OAS），原/处理 IL、字段读写、条件分支、全局 incoming、泛型解析和 CAD API 索引。
- [33 项逐条答复](../round7/closure.md)、[分层验证](verification.md)、[未恢复/原实现缺口](unrecovered.md)。

## 验收缺口

存在完整但无调用的评价器；KML 缺失；没有任意 TP/左右转/转弯后航迹代码。已能恢复同轴 OAS→固定宽度衔接规则，但不能把它替换为完整 PBN 定点转弯。没有补按钮、补导出或补转弯。任何工程可用性均未由本轮证明。
''', ['551','55C','55D','566','567','56D','570','5DF','5E0'])
sem={'553':'reachable；初始化组合框→config.xml load','554':'reachable；config save/取消高亮','555':'reachable；SelectAll POINT→Take(5)→初始表','559':'reachable；THR GetPoint','55A':'reachable；跑道末端 GetPoint','55B':'reachable；转换XY、保留绝对Z→结果表；无评价','55C':'reachable；新建模型、衔接、变换、二维writer','560':'reachable；TXT文件选择→P561','564':'reachable；P565→TXT','566':'prompt-only；基础版不支持；设计器隐藏','568':'reachable；HL类别→显示重算','569':'reachable；HL显示重算','56B':'reachable；GetEntity→XData[1]→P561','56D':'stub；KML空体；设计器隐藏','56E':'reachable；ID回查、取消旧高亮再高亮；不居中','56F':'stub；OAS勾选变化空体','576':'reachable via setter；AppType设计器禁用；WS显隐→P570','577':'reachable；尺寸默认值→P570','578':'reachable；GP→P570','579':'reachable；MissCG→P570','57A':'reachable；Enter→P570','57B':'reachable；Validated→P570','57C':'reachable；交换六坐标字符串','57D':'reachable；选中行→原DBPoint→obst/Altitude'}
evt='# 完整事件图\n\n静态 bound/reachable 不等于当前配置、许可或显示状态下实际可点击。\n\n|Control.Event|原方法 / RVA|处理方法 / RVA|直接内部 callees|状态|\n|---|---|---|---|---|\n'
erows=[]
for e in events:
 t=e['handler_tokens'];m=ms[t];k=t[-3:];cs='; '.join(c['target']+'@'+c['il_offset'] for c in calls if c['caller']==t and c['target'].startswith(('0x06','0x2B')));desc=sem.get(k,'reachable')
 evt+=f'|{e["control_name"]}.{e["event"]}|{m["original_token"]} / {m["original_rva"]}|{t} / {m["processed_rva"]}|{cs}|{desc}|\n'
 erows.append(dict(control=e['control_name'],event=e['event'],original_method= m['name'],original_token=m['original_token'],original_rva=m['original_rva'],processed_method=m['name'],processed_token=t,processed_rva=m['processed_rva'],direct_callees=cs,status=desc))
evt+='''
## 调度断点

P557 自定义解析器、P567 最低标准后处理、P5E0 专用面评价器：全程序集直接 call/callvirt/newobj/ldftn 及 MethodSpec 解析未找到 incoming。共享 P41B 点评价同样没有全局静态调用。P56C 是旧 AppType 显隐方法，未绑定；实际绑定的是 P576。嵌套 P585 只返回 DH，找不到业务使用，不能据此宣称已实现排序或控制障碍物选择。

静态事件遍历含三处 MethodSpec 解析，详见 [reachability.csv](evidence/reachability.csv)、[resolved-global-incoming.csv](evidence/resolved-global-incoming.csv)、[all-incoming.json](evidence/all-incoming.json)、[callgraph.dot](evidence/callgraph.dot)。无反射或运行验证，结论限定为所给程序集的静态引用。

```mermaid
flowchart TD
 P[参数变化] --> DB[P571 oas.db]
 DB --> C[尺寸/RDH修正]
 C --> M[P412共享OAS构造]
 M --> UI[系数格式化到控件]
 CAD[CAD按钮] --> N[P55D新建四面模型]
 N --> SOC[P55E SOC]
 SOC --> J[P5DF衔接]
 J --> W[变换 / 二维Polyline / WsObject]
 S[ScreenData] --> T[Take5 / parser / ID]
 T --> L[坐标转换 / 表格]
 L --> H[Mark / Highlight]
 E[Evaluate] --> Msg[仅基础版提示]
 K[KML] --> Empty[空体]
 O[P5E0 orphan]
 R[P567 orphan]
```

没有 turn point/turn-end/direction 的事件、字段或 reader；全控件引用见 [control-references.csv](evidence/control-references.csv)。原始命令 Y54_PBN_ILS 是 P06A；它构造 P551 并 ShowModelessDialog。
'''
write('event-map.md',evt,['06A','551','566','567','56C','56D','5E0']);out(E/'events-enriched.csv',erows)
write('runway-frame.md','''# 跑道与局部坐标

THR 为第一点，RWY end 为第二点。拾取把 X/Y Round(...,2)，Z 原值转字符串；swap 交换全部六字符串。共享 P0AC 保存 THR.X/Y/Z、XY长度、THR→end 方位及 end→THR 反方位。P0AD 的局部正X沿 end→THR，即进近侧为正、飞越入口向跑道延伸为负。

`x=L*cos(bearing(THR→obstacle)−bearing(end→THR))`；`y=L*sin(...)`。公共 helper 本来返回 `obstacle.Z−THR.Z`，**B4转换P55B只读取XY坐标文本，临时THR.Z/end.Z均0，而且构造障碍物后仅复制localXY，保留源绝对Z**。因此表中的面高/最低标准不能假定已做相对入口化。转换调用P558只填13列表，没有评价。

CAD P55C 读两点XYZ，按反向方位旋转点列→P827全部Z清零→P823加THR.X/Y→P087。跑道end.Z不决定二维方位。测试例 THR(1000,2000,100)、end(2000,2000,200)、障碍物(1300,2100,250)得到local(-300,-100,250)。

与B3同P0AC/P0AD；转换都保留源绝对Z。与B5同helper，但B5 Form按DER、THR顺序，业务原点/正方向与B4不同。没有第三点、出航点或 TP 数据绑定。零长度/取消拾取没有新增业务拦截。
''',['559','55A','55B','55C','57C','0AC','0AD'])
write('oas-parameter-model.md','''# OAS 参数模型

## 两套模型

共享 OasModel（P411–P41E）字段 `_0088_0091_0096=W,0097=W*,0098=X,0099=Y,009A=Z`，每面 PlaneCarrier(A,B,C)；mode009B为组合框索引0/1/2；cap009C为300/150/150m。枚举元数据只有value__，没有命名常量，恢复代码保留数值枚举。

B4专用 PbnIlsTurn（P5DD–P5EB）字段 `_008A_008B_0090=W,0091=X,0092=Y,0093=Z`，cap0094恒300m，无mode/W*字段。P55D从UI读12个系数后Build/Transition。共享模型支持AUTO不等于专用CAD/评价支持AUTO。

## 参数、setter、reader与单位

|字段/控件|初值及setter|reader/consumer|单位/说明|
|---|---|---|---|
|textBoxWA/WB/WC；WsA/B/C；XA/B/C；YA/B/C；ZA/B/C|设计器为0.001类占位；P575、TXT P561、可编辑文本、config回填|P55D读W/X/Y/Z，P565保存全部五面|A/B无量纲，C米|
|comboBoxAppType|Load索引0；用户变更P576、TXT/config|DB key；共享mode；WS显示|CAT I / CAT II / CAT II AUTO|
|comboBoxCat|Load索引3(D)，P577写A/B30/6、C/D32.5/7、DL40/8|尺寸修正、HL表、TXT|翼参数是半翼展s，轮参数t，米；DL索引4与仅4行HL表不兼容|
|comboBoxGP|Load索引5，设计器列表对应3.0；P578/TXT/config|数据库、SOC、Ha/RVR|度|
|comboBoxMissCG|Load索引3，对应2.5|数据库、P567中100/CG|百分数数值，不先除100|
|textBoxRDH|设计器15；Validated/Enter触发P570|P574修正C|米|
|LocDistance|设计器3280；P570夹到2000–4500；P571再Round到整数|PartB key|米；逐米查表，没有插值|
|textBoxFAF|设计器/配置/TXT；通常900|P55D的FAF−THR.Z−150|绝对标高输入，**不是FAF坐标**|
|textBoxAdElev|机场标高，可编辑/TXT/config|P55F、P567|米；与HL检查页textBoxElev分开|
|textBox1(DH)|可编辑/config；设计器初值见全控件表|P55E→SOC→P5DF|米；不用于共享系数解码|
|comboCat、HLm/HLr/HLcor、textBoxElev|HL检查页P568/P56A|HLcor仅显示；业务按comboBoxCat另算|m；无GP修正|
|textBoxLGT|TXT/config/手输|P567 RVR|米|
|checkBoxShowOas|P55D读取|只控制首批Y/Z轮廓是否加入；非总开关|布尔；X/W和衔接仍生成|

设计器初值、所有控件名/字段、业务读写定位完整列于 [parameter-control-inventory.csv](evidence/parameter-control-inventory.csv)。AppType设计器Enabled=false，Evaluate/KML为Visible=false，WS三框初始隐藏，HLm/r/cor禁用，表ReadOnly=true；绑定/静态可达不等于可鼠标触发。Load先改组合框再load config，可能触发多次DB重算。原config可以覆盖支持的值，本轮未运行，不能把设计值当实际启动状态。

## 数据来源

P571直接打开程序集目录oas.db，PartA与PartB均用参数化`ID=@id`。keyA=`(GP+modeInteger+MissCG).Replace(".","")`；keyB=keyA+`(int)Round(LOC,0)`。缺文件提示并null；缺行ExecuteScalar().ToString无null检查。不是从样例TXT自动读取，也不是硬编码系数表。

P572解码：非零数字d→10−d，0保留，然后整串逆序。PartA对各片段分别解码：Z.C[0:4]×−.01；W.A[4:9]×1e−6、W.C[9:12]×−.01；W*.A[12:17]×1e−6、W*.C[17:21]×−.01。Z.A取keyA.Substring(3,2)×−.001；W/W*/Z.B=0。PartB先整串解码再切：X.A[0:5]、B[5:11]、C[11:15]；Y.A[15:20]、B[20:26]、C[26:30]，A/B×1e−6，C×−.01。

P573：W/W*.C减(t−6)；P=max(t/Bx,s+(t−3)/Bx)−max(6/Bx,30+3/Bx)；X.C减Bx×P、Y.C减By×P。P574给W/W*/X/Y.C加RDH−15；Z不改。P575把A/B输出f6、C输出f2，随后CAD重新读这个已舍入文本。

只读SQLite核验：PartA275行、PartB687775行；[database-extract.json](evidence/database-extract.json)保存原路径/hash、schema、27组原始值和解码结果。Python以mode=ro&immutable=1打开，未加载目标SQLite DLL。样例OAS参数I/II/IIA只是可导入文本，不能替代当前数据库选择值。
''',['411','55D','570','571','572','573','574','575','577'])
write('oas-surfaces.md','''# 曲面、区域与裁剪

## 面方程与交线

PlaneCarrier P834–P840完整恢复：z=A*x+B*y+C，评价先取a=abs(y)。两平面交线为(A1−A2)x+(B1−B2)y+(C1−C2)=0；固定高度h线为Ax+By+C−h=0；三点拟合系数由行列式求解。除数0时按分子>0给+1000000，否则−1000000；不改成几何异常。

共享OAS：W∩X、X∩Y、Y∩Z在z=0和cap求交点；AUTO另有W*∩W及W*∩X。P412构造线性轮廓。P41B评价以0/入口平面起步，严格max依次W→X→Y→Z，AUTO最后W*；同值保留先到标签。不是min，也不是多行候选输出。

|共享P41B条件|实际domain|
|---|---|
|mode1/2|最大面高>150则out，否则赢面；AUTO含W*|
|mode0，x≥Y/Z-cap点.x|只有赢面为Y/Z且>300被排除；W/X可高于300|
|mode0，x<Y/Z-cap点.x|构造cap点向负X、由−15°方向反向延伸10000m的辅助线；a≤线y(x)则非精密延伸段并用Z面；否则out|

辅助10000只用于求直线，未检验射线有限端点；out延伸分支不一定更新输入点Z。共享P41B无静态incoming，不能称其为B4界面实际评估结果。

## B4专用P5E0逐分支决策表

定义 E=P5DF的SOC处点，A=15°辅助线到y3704点，B=Y/Z交线到y1852点，D=Y/副区面交线到y3704点；按下表源码顺序判断，**不排序这些站距**。初始最大0、标签入口平面。

|首个满足条件|按顺序候选|侧限/排除|副区比例字段|
|---|---|---|---|
|x>E.x|W,X,Y|仅Y赢且面高>300→out|不设置|
|else x>A.x|W,X,Y,Z|仅Y赢且a>辅助线y(x)→out|不设置|
|else x>B.x|W,X,Y,Z|仅Y赢且a>3704→out|不设置|
|else x>D.x|Y,Z,Z面副区|任意赢面，a>3704→out|max(0,(a−1852)/1852)|
|else|Z,Z面副区|同上|同上|

严格取max；tie保留早先标签（包含入口平面0）。专用模型**没有W***、mode或150m CATII上限；部分前段侧限只对Y赢面生效，所以不能改写为通用polygon contains或“所有面均限3704”。无额外x最大/最小距离测试，后端有限绘图点不构成评价域截断。

所有分支最后写surface=max、penetration=原记录Z−surface，即使标签out也保留这些值。若复用同一record，前3段不清空旧比例字段；P567还会把该字段改写为HL。测试及消费者必须知道这一状态语义。
''',['412','41B','5DE','5E0'])
write('faf-fap-mapping.md','''# FAF / FAP

|代码/控件|UI语义|实际坐标/consumer|规范解释|
|---|---|---|---|
|textBoxFAF `_0089_009A_008A`|FAF/FAP高度类输入；保存键FAF|只读标高，P55D请求高度=值−THR.Z−150；>300时扩展W/X绘图；也保存TXT|没有足够证据把这个标高控件当作FAF/FAP平面定位点|
|FAP对象、FafFix对象|未发现|无坐标、容差或传入定点转弯数据|未实现证据，不借用B3 FafFix|
|GP|下滑角|系数key、SOC、后处理|没有通过FAF输入反算航路点坐标的调用|

P412共享OAS接受可选绘图高度，但B4 P570调用它时使用默认0；CAD另在P55D调用专用模型，并用FAF−入口−150作为高程上限请求。这个差值不是独立FAF/FAP定义或完整航段。
''',['55D','565','570'])
write('hl-correction.md','''# HL / DH / SOC

HL表仅A/B/C/D四行：HLm={40,43,46,49}、HLr={13,18,22,26}。业务P55F按comboBoxCat.SelectedIndex索引，AdElev>900加HLr*.02*AdElev/300；≤900直接HLm。无GP项、无round。类别DL会索引越界；P567虽有H对应700m的文字分支，当前4行表及UI并未提供完整H支持，不能自动补表。

HL检查页是另一组comboCat/textBoxElev/HLm/HLr：P568设置表值后P56A；P569亦调用P56A。Elev>900时Round(HLm+HLr*.02*Elev/300,2)，否则复制HLm文字。HLcor显示文本不被SOC/评价读取。

P567最低标准支路再算HL=HLm+(Elev>900?Round(HLr*.02*Elev/300,2):0)，仅修正增量round。三条代码不是同MethodDef。B3 APV P5F2独立实现，另有GP>3.2的增量且类别处理不同；[b3-b4-hl-comparison.csv](../round7/b3-b4-hl-comparison.csv)记录差异。绝不能复用B3修正填入B4。

## DH和SOC

DH控件textBox1（`_0089_009B_0088`）的业务reader只有P55E：

`SOCx = Round((DH−P55F_HL)/tan(GP*PI/180) − 900)`。

P55D→P5DF(SOCx)，影响E′及衔接几何；不是只显示，也不是直接输入P5E0的障碍物评价阈值。没有独立SOC对象、ThrToSoc/SocToTp字段，但**确有SOC公式/参数传递**。不输出“无SOC证据”。GP=0传播Infinity/NaN；无追加校验。没有HL==0保护或依据mode变更−900。P567计算的DH是每个障碍物结果字段，未见回写这个输入控件或再循环绘图。
''',['55E','55F','567','568','569','56A'])
write('navigation-tolerance.md','''# 导航容差与固定宽度

|值|真实来源/setter|consumer|单位与可证明语义|
|---|---|---|---|
|1852|P5DF/P5E0常量|Y/Z交线到内边、后段内边、比例分母|m；主/副区内边半宽的实现值|
|3704|P5DF/P5E0常量|辅助线外边交点、Y/副面交点、评价外侧限|m；总半宽，副区宽=1852|
|30|P5DF/P567|副区外边抬高30；后处理减fraction*30|m；向外放宽的面高/超障项，不是30°|
|20000|P5DF|内侧后端点的x回退|m；仅绘图/拟合支撑点，不是评价截断|
|1482/4630/9260|B4核心未找到|无|不能借用其他模块|

没有可达ATT/XTT/RNP/SW输入、容差表查询或随导航方式变更分支。1852和3704分别为1NM与2NM的数值换算，但**代码没有RNP1枚举/系数推导证据**，实现依据待确认。固定宽度与规范PBN通式1.5XTT+BV不能自动等同。
''',['5DF','5E0','567'])
write('pbn-turn.md','''# 所谓定点转弯的真实恢复边界

帮助标题为“PBN-ILS定点转弯评估”；核心源码/控制引用只见THR与跑道end两点。没有turn point、turn-end/next point、left/right、incoming/outgoing航迹输入，不存在三点转弯链、earliest/latest TP、风螺旋或post-turn航段。

P55C→P55D→P5DE/P5DF是**同轴直线复飞侧向衔接**。模型类的恢复名PbnIlsTurn仅保留请求目录命名；不能凭名称证明转弯。P793、Spiral86构造/采样在B4核心及事件依赖路径中没有调用。恢复源码编译复用PointLists的既有依赖文件包含Spiral86，只是构建依赖，绝非原B4使用证据。

PI/12有两种上下文：共享OAS CATI“非精密延伸段”辅助线（P413/P419/P41B）；B4 P5DF在OAS 300m交点连线上求SOC处点，再将该连线角减15°构造扩张线。它没有方向选择或转弯半径；不把这个15°称作完整转弯保护。30为米，未见本路径30°转弯扩张。

左/右、小角/大角夹具标为不适用：原实现未提供对应控制量。已有全部站距及宽度边界fixture；未合成任意转弯功能来获得验收。
''',['55C','55D','5DE','5DF','5E0'])
write('oas-pbn-connection.md','''# OAS → 固定宽度复飞区衔接

以下是实际P5DF构造，不从规范补出：

1. P5DE生成W/X、X/Y、Y/Z交线及0/300m交点。X/Y-cap记D′，Y/Z-cap记E′′。
2. 连D′、E′′，在x=SOCx取E（源码字段`_008A_008A_0093`），Y由此线求，Z恒300。报告记E′只是几何别名，源码没有业务点名字符串。
3. 过E以该线方向减PI/12构造辅助线L15；L15与y=3704求A，A.Z取Y面，不强行保持300。
4. Y/Z交线与y=1852求B；B.Z取Z面。C=(B.x,3704,B.z+30)。F=(B.x−20000,1852,Z面(B.x−20000,0))。
5. 三点B/C/F拟合副区面S；Y∩S再取y=3704求D，其Z取Y面。
6. 追加正负镜像八顶点衔接多边形，正负五顶点后端侧带，以及七顶点中心Z延伸轮廓。镜像只翻Y。

八顶点正侧顺序：E,A,D,B,YZ0,XY0,XY300,E。侧带：B,D,(F+(0,1852,30)),F,B。中心：YZ0,B,F,mirror(F),mirror(B),mirror(YZ0),YZ0。重复首点造成几何闭环；writer没有Closed=true。

警告条件`SOCx>XY300.x`文本却称“SOC高度大于300米”；实际比较X站距，且警告后继续。站距未排序、无通用polygon求交、裁剪或包络算法。连接是参数化点线交和数值平面，CAD没有自动与既有实体相交。后端20000只支撑绘图，评价没有相同纵向端点限制。

测试使用原OAS参数I系数、SOCx=−690，点例见 [transition-points.csv](../round7/fixtures/transition-points.csv)：E=(−690,1599.2337,300)，A≈(−6032.1747,3704,618.1801)，B≈(−7979.4493,1852,176.9862)，D≈(−15369.3736,3704,391.7343)。这是独立源码计算，不是原插件运行测量。

规则已代码化到同轴1852/3704衔接层；没有随后任意转弯区，因此不能声称“OAS→PBN定点转弯全过程已闭合”。
''',['5DE','5DF','5E0'])
write('obstacle-evaluation.md','''# 障碍物评价与最低标准

## 可达数据链与断链

P555在Model空间SelectAll POINT（不筛IsObstacle、不取块），先Count>5时Take(5)，再P556共享P12F解析：原XYZ、顺序字符串ID、名称/备用名、ID→源DBPoint。初始表和P55B转换、Mark/Highlight都只见这个截取列表。

另有P557自定义parser，直接读整个XData数组[3]作为名称，参数List可超过5，但没有静态incoming；不能把“可传任意List”当作UI绕过入口。P55B重新遍历原点，转换XY、保留绝对Z，P558填13列；没有调用面评价或最低标准。

P5E0为单记录评价：按 [oas-surfaces.md](oas-surfaces.md) 五段选择候选最大高度，严格max，同值入口/W/X/Y/Z/副区按先后保留。没有先OAS后独立PBN再max OCA，也无多行候选、无所有障碍物的控制结果合并。只写region、surface、penetration和部分分支fraction。

## 结果字段

|原字段后缀 `_0088_0090_`|意义/状态|
|---|---|
|008A|区域字符串：入口平面、W/X/Y/Z面、Z面副区、out|
|008B|数值面高；P567又加THR标高|
|008C|penetration=记录Z−面高，P567不重算|
|008D|P5E0后段是max(0,(absY−1852)/1852)；P567后变成HL|
|008E|Ha，当量进近障碍物高|
|008F / 0090|OCA / OCH，中间字段；表不直接展示它们|
|0091 / 0092 / 0093|DA / DH / RVR，最终表值|

## P567最低标准后处理（orphan）

只对penetration>0执行；不另测region!=out。记h=record.Z−THR，t=tanGP，u=100/MissCG，c=1/t，k=类别文字H?700:900；HL见独立报告。

- 若x>−900且h<(x+k)t：008D=HL；**OCH=record.Z+HL，OCA=THR+record.Z+HL**。record.Z在可达转换中是绝对值，这个标高混用保留，未纠正。
- 否则若x>B.x（Y/Z到1852点）：Ha=Ceiling((h*u+x+k)/(c+u))；OCH=Ha+HL，OCA=THR+Ha+HL。
- 否则：先M=fraction*30；Ha=Ceiling(((h−M)*u+x+k)/(c+u))；再008D=HL；OCH/OCA同上一行。
- surface+=THR；DH=Ceiling(OCH/5)*5，CAT I下限60；DA=Round(DH+THR)。
- rawRVR=DH/tanGP−LIGHT；<800按50向上，<5000按100，否则按1000。THR<3000时先封顶5000；否则DH≤300时封顶8000，DH>300时5000（其余源码路径见IL）。CATI再最低：LIGHT>720→550，>420→800，其余1200；其他mode按DH≤35→350、≤42→400、其余450。

没有调用这两方法的可达循环、全局排序/最高OCA选择或回写DH再绘图过程。P585返回DH但未被引用。独立测试按明确单记录调用验证原方法，**并未给原UI补接**。

## 第6点

危险第6点在parser前丢弃，无对应ID表行、转换行、Mark或Highlight资格。SelectAll返回的顺序不保证按危险程度。数学评价器没有Take(5)，外部独立调用可以输入任意record；这不证明原UI第6点可以绕过。未发现另一可达导入评价入口。
''',['555','556','557','558','55B','567','57D','585','5E0','12F'])
write('cad-output-map.md','''# CAD writer 与创建顺序

入口P55C→P55D→P5DE/P5DF→P821旋转→P827清Z→P823平移→P087。Shared P087先new Group，再为每一个点列表new Polyline，P12D/P12A转Point2d，P134 AddVertexAt(bulge/start/endwidth=0)，P089入ModelSpace并写WsObject，Append到Group；末尾Group入库。不设置Group.Description、Group XData、layer/color/linetype/Closed。

## 列表顺序（P55D请求高度<=300时）

|顺序，0基|来源|几何可证明语义|
|---|---|---|
|0、1（ShowOas=true）|P5E4/P5E5|正负Y面0/300轮廓，各5点|
|2（同开关）|P81F(YZ0,YZ300)|跨中线Z面0/300闭环，5点|
|随后|P5E8|入口至W/X0站距的中线，2点|
|随后|P81F(WX0,WX300)|跨中线W面轮廓，5点|
|随后2条|P5E2/P5E3|正负X面0/300轮廓，各5点|
|最后5条|P5DF|八顶点衔接×2，五顶点侧带×2，七顶点中心延伸|

ShowOas=true共12条，false共9条；开关不移除全部OAS。请求高度>300时最后W/X三列表由P5E1替代：正X、负X、W跨中线顺序，仍三条，仍12/9。三维点列有数值面高，进入CAD前清Z，Point2d再次丢Z。实际对象为二维Polyline与Group；没有Surface、Face、Solid、Mesh、3DPolyline，也没有这条边界writer新建Arc/Circle/DBText。

Mark是另一链P57D→P09C，BlockReference=`obst`，位置为源点XYZ，Altitude属性写源Z；缺块时P09D枚举WsSymbol*.dwg取首个导入。没有按面分类写不同图层或属性。实际块内既有实体不等于B4新建的曲面。

衔接相关API索引 [connection-api-sites.csv](evidence/connection-api-sites.csv) 同时包含共享依赖的词法候选，需按caller辨别；[connection-semantic-calls.csv](evidence/connection-semantic-calls.csv)另索引被混淆名称掩盖的点线/面交、镜像和点列构造。数值常量只匹配ldc操作数，不把IL_1482偏移当1482米。GroupBox不是CAD Group，Clipboard不是裁剪。核心没有IntersectWith、Offset、实体包络、切线拟合、Erase后重建链。数值line intersection不是AutoCAD IntersectWith。
''',['55C','55D','5DE','5DF','5E1','087','089','12A','12D','134','57D'])
write('xdata-schema.md','''# XData

每条边界Polyline经P089写`1001=WsObject`、`1000=P565完整多行OAS参数文本`。文本含AppType/CAT/GP/FAF/ELEV/LIGHT及五面系数，**不是B3的Form头+dotted控件树状态**。没有Kind/Radius/面名等独立字段；Group没有描述或XData赋值。

P56B的“请选择OAS面”实际允许GetEntity任意实体，拿整个XData.AsArray()[1].Value.ToString()给P561。没有指定RegApp、长度/模式校验，没有根据图元反算面系数，也没有真实三维面选择。无XData提示；错schema/短数组保留旧错误可能。

Mark的Altitude为Block Attribute，不能称为OAS XData；P557另读XData[3]名称，但它是无调用旧parser，不同于当前P12F名称解析。
''',['565','56B','557','089','57D'])
write('kml-export.md','''# KML — 原实现为空

button8.Text=KML，Click绑定P56D。原始对应MethodDef的IL是3个nop+ret；处理后是单ret。没有导出实体、坐标转换/经纬度、Polygon/LineString、业务名称、style或altitudeMode。不能把项目其他模块的KML库接入B4。

[PbnIlsKml.Recovered.cs](PbnIlsKml.Recovered.cs)忠实保存空入口。测试只确认恢复入口无输出，不能称作KML导出功能通过。KML不能确认BoundaryList语义；[kml-cad-map.csv](../round7/kml-cad-map.csv)逐列表把KML项记为N/A(stub)，CAD几何解释仅由点/平面来源证明。

帮助声称可导出KML，与实际方法体不符，作为文档差异保存 [help-original.html](evidence/help-original.html)。没有伪造KML示例作为恢复成果；验收保持PARTIALLY ACCEPTED。
''',['56D'])
write('persistence.md','''# Load / Save

P560/P564分别选择UTF8 TXT文件读取/写入，P565是自定义OAS快照：

```text
AppType,<text>
CAT,<text>
GP,<text>
FAF，<text>
ELEV，<text>
LIGHT,<text>
W,A,B,C
WS,A,B,C
X,A,B,C
Y,A,B,C
Z,A,B,C
```

FAF/ELEV用中文逗号；导入P561全局替换中文逗号→ASCII，Split LF。至少5行，否则提示return；单行少于2字段跳过；key.Trim().ToUpper，NAME识别但不写值；面系数P562直接取[1]/[2]/[3].Trim，短三元组越界，额外项忽略。值以文字回填，没有统一数值schema或版本。保存系数是当前文本，不重新计算。

包含OAS模型参数及部分UI元数据；不含THR/end XYZ、DH、LOC、RDH、尺寸、MissCG等，无法单靠TXT恢复完整程序。combo回填可能触发DB重算，与后续系数行有顺序关系；本轮RecoveryCell只测文本分发，未模拟WinForms事件时序。

Form Load P553先设置组合框默认，再P0F6 load config.xml；Closed P554→P0F4 save config，节点FormPbnIlsEvl。这是通用控件状态持久化，与TXT格式不同，不是JSON/统一Procedure。CAD WsObject保存的是上面TXT，选OAS实体亦回填同一解析器。原config/样例均只读。
''',['553','554','560','561','562','563','564','565'])
write('cad-interactions.md','''# CAD人工交互与自动化边界

|操作|选择的业务对象|软件为何要求人工|进入计算|已有程序数据能否推导|
|---|---|---|---|---|
|THR GetPoint P559→P113|入口空间点|没有跑道对象/标识查询|frame原点、绝对高、CAD平移和FAF差值|若外部提供可信跑道关联，可预填；当前只有文本/图面，不能自动辨认任意点|
|end GetPoint P55A→P113|跑道末端点|没有跑道轴线实体关系|反向bearing/二维长度；Z存储但不改bearing|同上；不能从THR单点确定方向|
|OAS GetEntity P56B|带参数文本的边界实体（提示称“面”）|无程序ID、Group模型索引或最新版本关系|XData[1]→TXT parser→系数/UI|可按已知WsObject文本检索候选；多个快照/其他App时无法无歧义自动选定，原代码未实现|
|ScreenData P555|Model全部POINT|实际SelectAll，不是人工框选|Take5→XYZ、名称、ID字典|已代码化，但无业务类型筛选/危险排序|
|表格SelectedRows P57D|设计者要标注的障碍物行|软件无可达评价/控制点选择|ID→源点→obst/Altitude|列表可以批处理；“控制障碍物”无法靠现有可达评价自动推导|
|CellClick P56E|所点表行|UI选目标|ID→取消旧高亮→高亮|可由ID自动定位，当前没有居中调用|

P113取消可返回Origin，B4未按业务额外检查。没有turn point、KK′或C选择，也没有人工裁剪边界的指令。无法从静态无调用推断设计者实际会手工补画/修正转弯；只可明确原代码没有自动完成那部分。衔接点由数值交线自动计算；与既有CAD保护区相交/删除重建没有实现证据。
''',['559','55A','56B','555','56E','57D'])
write('standard-mapping.md','''# 规范映射（恢复之后对照）

基线为项目原PDF《航空器运行目视和仪表飞行程序设计规范》AC-97-FS-005、民航规〔2020〕12号。哈希和原路径见 [standard-search.json](evidence/standard-search.json)；页码均为PDF序号，不混用页脚印刷页。未用规范改写代码。

|恢复行为|条款/页|分类与差异|
|---|---|---|
|z=Ax+By+C、对称absY、max(0,各面)|II-1-1 1.4.8.4/.5，PDF275|matches current standard，方程和最大规则对应|
|共享CATI300、CATII150；W/X高于300例外|1.4.8.4.3 PDF275|共享模型局部对应；专用B4恒300、无mode且仅Y部分门控，differs/missing|
|CATII AUTO共享W*，B4专用模型丢弃W*|1.4.8.7.6 PDF276|参数层对应，绘图/专用评价缺失；无独立运行审定条件验证|
|机体尺寸与RDH修正|1.4.8.7.3/.4 PDF276|算术matches；RDH大于15也统一加，规范允许不调，属于具体实现选择|
|GP/LOC/复飞梯度查询表|1.4.8.4.2 PDF275、1.4.8.7.7 PDF277|数据结构对应；不能证明oas.db来自何版本PANS-OPS，**实现依据待确认**|
|HLm/r和Elev>900修正|表II-1-1-2 PDF286、1.4.8.8.3.1 PDF278|A-D基础表/标高项对应；B4无GP>3.2增量，round方式亦不同于条文示例向上取整，differs/missing|
|FAF标高−THR−150绘图请求|1.7.1.2 PDF285|代码不是FAF/FAP定义；Only terminology，不能确认完整规范角色|
|SOC=(DH−HL)/tanGP−900|1.5.1.2 PDF280、1.4.8.8.2 PDF277|公式形式有对应；没有独立程序模型/反馈链，模式和高基准问题保留|
|SOC处15°扩张、Y外推、Z延伸、副区0→30|1.5.2.3 PDF281|高度一致的结构候选：同轴传统→RNAV/RNP直线衔接；代码从300m线角减15°，不武断说绝对跑道角固定15°；局部匹配，完整合规未证|
|1852/3704固定半宽|III-1-1 1.5.4 PDF402|没有XTT/ATT/BV及导航方式推导，author simplification候选/**实现依据待确认**；不可直接标RNP1|
|无TP/earliest/latest/旁切/飞越及转弯曲线|1.5.3 PDF281–282|missing；不能把直线衔接当完整定点转弯|
|单记录Ha/HL后处理|1.4.8.8.2.1 PDF277|Ha算式形态对应；进近分支绝对/相对Z混用、无全局控制障碍物选择且UI断链，differs/missing|

未发现足够证据把异常归到某一旧版ICAO Doc8168或旧国内规范。旧版本/作者简化仅列候选，数据库版本和实际采用依据仍待确认。没有根据课件点名/规范图示给空缺业务补实现。
''',['41B','55D','55E','55F','567','571','573','574','5DF','5E0'])
write('unrecovered.md','''# 原实现缺口与恢复限制

1. P5E0/P567/P41B均有完整数值方法但未找到调用；没有可达完整评价链，未补调度。
2. KML原方法空体，缺完整导出。帮助宣称不能替代IL。
3. 未找到任意TP、方向、出航点、earliest/latest或风螺旋；只恢复同轴衔接。无法从提供版本恢复不存在的业务。
4. 专用CAD/evaluator无W*/CATII cap；原代码保留，不替换成共享OAS。
5. TXT不保存完整程序；WinForms配置回填/事件重算时序、原CAD事务/实体选择与DWG符号均未运行验证。
6. 原始方法大多受保护；E0只证明身份/保护状态，主要算法证据为E1/E2，E3无原程序oracle，E4为空。
7. 不扩大A5恢复，仅查询共享类与参数helper；A5完整HL/障碍物调度/文档差异未验收。

这些是PARTIALLY ACCEPTED的具体原因；报告/源码交付已在本轮范围收口，不以补软件功能获得ACCEPTED。
''',['41B','567','56D','5E0'])
write('verification.md','''# 验证与可重放成果

运行 `python recovered/round7/database.py` 以只读方式读取原DB；`python recovered/round7/build.py` 编译并运行独立C#恢复源码。系统csc沙箱输出报CS0016后经授权允许编译器正常写本轮目录。未加载WindSpiralBasic.dll或启动AutoCAD。

|层|覆盖|限制|
|---|---|---|
|formula|27组DB原行，三mode、GP3.0/3.2/3.5、LOC2000/3000/4500；RDH12/15/18；机体修正；A-D/标高0/900/>900/GP3.0/3.2/3.3；SOC|DB expected由独立Python定长解码；HL/修正按IL算术独立表达|
|geometry|交面线性方程独立行列式校核、E′/15°/1852/3704/三点副面、12/9列表、CAD清Z|无原DWG或宿主运行oracle|
|surface-classification|五段站距边界±epsilon、正负侧、1852/3704边、tie、Y特有门控、W/X/Y/Z/副区/out自然点、共享mode/W*和CATII150|独立决策表对照不等于真实运行|
|obstacle|penetration、向外比例、原绝对高混用、Ha/HL/DA/DH/RVR、非穿透跳过|未模拟可达UI，因为原无调度|
|serialization|真实P561/P565往返、中文逗号、WS、短记录/未知NAME、遗漏跑道|RecoveryCell不触发WinForms事件|
|KML|真实空handler无输出；原/处理IL静态核验|标为stub覆盖；无导出器可验收|
|event/reachability|静态18项断言及全程序集incoming/MethodSpec；Take5危险第6点夹具|未运行目标UI；不宣称绕过成功|
|degenerate|零GP、非法GP提示后返回0并传播Infinity、文本框focus/color记录、零梯度NaN、零除哨兵、零横向系数NaN、非法DB数字、负LOC key、银行家舍入|无新增拦截；focus/color为记录适配器，左右转/角度/零可配置宽度是N/A|
|cross-module comparison|共同frame和绝对Z语义；逐MethodDef和调用CSV|A5只做获准的共享层查询|

最新分层计数见 [tests.log](../round7/tests.log)，每个断言的输入标签/实际/期望见 [assertions.csv](../round7/fixtures/assertions.csv)，[fixture-index.json](../round7/fixtures/fixture-index.json)列材料/hash/适用性。历史fixture预期错误（Y面赢但超扩张边，实际out）保存在failure.txt；已同时保留区内/区外样例，算法未改。

原/处理方法身份映射 [recovery-method-map.csv](evidence/recovery-method-map.csv)；恢复的60个方法保留分支和IL InitLocals，PE方法头另经 [method-header-flags.csv](evidence/method-header-flags.csv)核验。RecoveryHost中的DB row/CAD变换/截取是明确标注的E2适配器，输入解析按P7D5/P7D6保留提示后返回0；focus/color仅记录，未声称实际UI执行。字段完整读写见 [model-fields.csv](evidence/model-fields.csv)。所有源文件hash见test-inputs.json，冻结核验见 [integrity-report.json](../round7/integrity-report.json)。
''')

def comparison(name,data):out(O/name,[dict(topic=x[0],classification=x[1],B4=x[2],other=x[3],evidence=x[4]) for x in data])
comparison('b3-b4-hl-comparison.csv',[
 ('HL table','Different implementation','P55F/567 four rows A-D; raw index','B3 P5F2 H/A/B/C/D and fallback D','P55F P567; frozen B3 hl-correction.md'),
 ('high elevation','Copied formula','e>900 adds HLr*.02*e/300','same arithmetic P5F2','different MethodDefs'),
 ('GP correction','Different implementation','none','P5F2 adds (GP-3.2)*HLr*.05','control readers and method bodies'),
 ('rounding','Different implementation','SOC none; P567 increment round2; display total round2','business no round; separate display total round2','P55F P567 P56A; B3 report')])
comparison('b3-b4-comparison.csv',[
 ('runway frame','Same MethodDef','P0AC/P0AD THR,end; absolute Z retained','same helpers; same axis and original Z convention','P55B vs B3 P478'),
 ('HL','Different implementation','independent P55F/P567','B3 P5F2 GP correction','b3-b4-hl-comparison.csv'),
 ('Xz/SOC','Different implementation','P55E uses inputDH-HL and fixed -900','B3 APV factory no DH-driven SOC','P55E; frozen B3 missed-approach.md'),
 ('FAF/FAP','Only same UI terminology','scalar FAF-THR-150 requested draw cap','B3 separate APV numeric FafFix semantics','P55D vs frozen B3 faf-fap-mapping.md'),
 ('surface','Different implementation','W/WS/X/Y/Z planes; extended four-plane model','B3 APV longitudinal/lateral interpolation','P411/P5DE vs B3 apv-surfaces.md'),
 ('obstacle carrier','Same MethodDef','P404/P405 _008A_008D','same carrier in B3 APV; LNAV different _008A_008B','method-index and B3 code'),
 ('CAD writer','Same MethodDef','P087/P089 Polyline plus WsObject','same writer','P55C vs B3 P47C'),
 ('XData contents','Different implementation','custom OAS TXT','FormApvEvl header+dotted control state','P565 vs B3 persistence'),
 ('ScreenData parser and Mark','Same MethodDef','P10D/P12F/P09C/P09E','same methods; B3 no Take5','calls and frozen ScreenData evidence')])
comparison('a5-b4-comparison.csv',[
 ('OAS data/model','Same MethodDef','P411/P412 shared _008A_0093','A5 P307/P30A directly construct/build same class','resolved-global-incoming.csv'),
 ('coefficient DB loader','Same data schema','private P571 calls own decoderP572','A5 P30A calls P409 loader/decoderP40A','a5-shared-parameter-structure.source.txt; distinct MethodDefs'),
 ('size/RDH corrections','Copied formula','P573/P574','A5 parameter path P40B/P40C','P30A direct calls; no B4 calls to P40B/P40C'),
 ('surface primitive','Same MethodDef','Plane _008F_0092','same OAS parameter surface class','shared OAS direct calls'),
 ('CATII AUTO','Different implementation','shared model includes W*; dedicated drawing model omits','A5 shared OAS class includes W*; full UI path not recovered','P412/P41B vs P55D'),
 ('HL','Only same UI terminology','B4 P55F/P567; no shared HL call','A5 full HL path outside authorized shared query','no direct B4 P5F2; do not infer A5 implementation'),
 ('FAF/FAP','Only same UI terminology','scalar draw-height input','full A5 role deferred','no common FAF business object in B4'),
 ('GP/RDH/LOC','Same data schema','key/rounding/coefficient corrections','P409/P40B/P40C same parameter schema','bounded source excerpts'),
 ('CAD writer','Same MethodDef','P087/P089','A5 parameter drawing path P30A uses P087','global direct calls; higher-level contents differ')])
comparison('b5-b4-comparison.csv',[
 ('P793','Different implementation','no call/reachability','B5 real turn parameter constructor calls','B4 direct-calls plus event-reachability'),
 ('Spiral86','Different implementation','no call','B5 directly uses P7A1 Spiral86 and methods','frozen B5 overview and round5 b2-b5-comparison.csv; B4 negative search'),
 ('turn points','Different implementation','THR/end only; no third point','B5 DER/THR/TurnEnd+TP station','P55B/P55C vs frozen B5 runway-frame.md'),
 ('primary-secondary','Different implementation','fixed1852/3704 and outward30m surface','B5 per-turn boundary/evaluator chain','P5DF/P5E0 vs frozen B5 reports'),
 ('Take5','Copied formula','P555 after SelectAll before parser','B5 ScreenData same truncation arithmetic distinct event','Round1 screen-data.md and IL'),
 ('Mark','Same MethodDef','P09C/P09E obst Altitude=originalZ','same common helpers','P57D actual direct calls'),
 ('runway frame','Same MethodDef','P0AC THR,end','P0AC DER,THR reversed roles','frozen B5 runway-frame.md')])
comparison('primary-secondary-comparison.csv',[
 ('B3 APV','Different implementation','outward fraction max(0,(a-1852)/1852); +30 plane','B3 inward MOC factor and own interpolation','P5E0/P567 vs B3 apv-surfaces/evaluation'),
 ('B5 departure','Different implementation','fixed same-axis OAS transition','turn-specific region geometry/MOC; no B4 evaluator call','B4 direct-calls; frozen B5'),
 ('A9 PriSec','Different implementation','max surfaces and outward correction','MOC=m*(outer-a)/(outer-primary) with finite longitudinal gates','P5E0 vs frozen ObstacleData/pri-sec-evaluation.md')])
kml=[]
for i,n in enumerate(['Y positive','Y negative','Z across centerline','axis','W across centerline','X positive','X negative','connection positive','connection negative','secondary extension positive','secondary extension negative','central Z extension']):
 kml.append(dict(internal_list='P5DE/P5DF default '+str(i),CAD_entity='2D Polyline',KML_element='N/A: P56D stub',KML_name='none',business_interpretation=n,evidence='P5DE/P5DF vertex/plane provenance; showOas=true request<=300; order differs request>300'))
out(O/'kml-cad-map.csv',kml)

answers=[
 ('B4到底是什么业务组合？','OAS参数/修正+同轴固定宽度复飞衔接绘图；另有无调度数值评价/最低标准方法。不是已实现的任意PBN转弯链。','overview.md'),
 ('是否有统一程序对象？','无。Form保留源点/ID/HL表；参数模型和CAD模型临时构造。','overview.md'),
 ('OAS和PBN转弯是否同一业务类？','四面OAS及同轴衔接同属_008C_0095；参数用另一共享_008A_0093。没有任意转弯业务可据此合并。','oas-pbn-connection.md'),
 ('W/W*/X/Y/Z真实来源？','oas.db解码→尺寸/RDH修正→UI舍入；亦支持手输、TXT、config回填。W*仅共享模型/保存，专用模型未读。','oas-parameter-model.md'),
 ('是否查询oas.db？','是，P570可达调用私有P571，查PartA与PartB；非仅项目同名文件推断。','oas-parameter-model.md'),
 ('每个surface方程？','各面z=A*x+B*absY+C；加0入口平面严格max，副面三点拟合。','oas-surfaces.md'),
 ('domain如何裁剪？','专用评价按E/A/B/D四个X阈值分5段、部分只对Y限侧宽，后段统一3704；共享模型按mode/cap/辅助线另分。','oas-surfaces.md'),
 ('CAT II AUTO专门实现？','数据库mode2、共享模型W*/150存在；B4专用绘图/评价没有W*或mode/cap150分支。不能称完整AUTO。','oas-parameter-model.md'),
 ('HL公式？','HLm+(e>900?HLr*.02*e/300:0)，四行A-D；SOC不round HL，后处理round增量2位；显示支路round总和。无GP修正。','hl-correction.md'),
 ('与B3同MethodDef？','否。B3 P5F2含GP项，B4 P55F/P567/P56A独立。','hl-correction.md'),
 ('FAF/FAP代码角色？','FAF标高控件只生成FAF−THR−150绘图高度请求；无FAP/FafFix坐标对象。','faf-fap-mapping.md'),
 ('DH进入哪里？','输入DH进入P55E算SOC，再传P5DF衔接；不直接进P5E0。每障碍物输出DH由P567另算，无回写。','hl-correction.md'),
 ('PBN转弯输入？','无TP/出航点/左右转；只有THR/end两点。无真实多点转弯语义可恢复。','pbn-turn.md'),
 ('ATT/XTT/SW来源？','未发现；1852/3704为硬编码内外半宽，不能据数值标RNP1。','navigation-tolerance.md'),
 ('是否用P793？','B4核心/事件闭包未调用。','pbn-turn.md'),
 ('是否用Spiral86？','未找到构造/采样/评价调用；编译基础依赖不代表原调用。','pbn-turn.md'),
 ('15°作用？','P5DF相对300m交点连线减15°得到扩张辅助线；共享CATI另有非精密延伸射线。都不等于完整转弯。','oas-pbn-connection.md'),
 ('OAS/PBN如何连接？','SOC处E→15°线到3704；YZ线到1852；外侧+30拟合副面；Y/副面相交→对称轮廓。任意后续转弯未实现。','oas-pbn-connection.md'),
 ('OAS障碍物公式？','P41B共享面max与域；B4专用P5E0候选max，穿透=记录Z−surface。两者未调度。','obstacle-evaluation.md'),
 ('PBN障碍物公式？','后段Z/副面max、a≤3704；fraction=max(0,(a−1852)/1852)，P567用fraction*30修正Ha。','obstacle-evaluation.md'),
 ('多候选如何合并？','单记录在当前分段内严格max面高、tie先到；不是max OCA或多行结果。没有可达全障碍物控制结果汇总。','obstacle-evaluation.md'),
 ('OCA/OCH怎样得到？','P567对穿透>0做进近/Ha分支，加HL；保留进近分支绝对高混用；DA/DH/RVR再后处理。','obstacle-evaluation.md'),
 ('所有evaluator UI可达？','否。P5E0/P567/P41B全局静态incoming均空，Evaluate只提示；不补接。','event-map.md'),
 ('Take5影响哪层？','SelectAll后、parser前；源列表、ID/初始表、转换表及Mark/Highlight只保留前5。','obstacle-evaluation.md'),
 ('第6点能否绕过？','数学接口无截取但没有UI绕过证据；P557可收任意List但无调用，不等同入口。','obstacle-evaluation.md'),
 ('CAD实体？','边界2D Polyline+Group，通常12或9条；Mark另插obst BlockReference与Altitude属性。','cad-output-map.md'),
 ('是否创建3D surface？','否；数值面/三维内存点列经清Z及Point2d写二维折线。','cad-output-map.md'),
 ('哪些XData？','每折线WsObject+完整自定义OAS TXT；Group无描述/XData，无Kind/Radius独立字段。','xdata-schema.md'),
 ('KML导出区域？','无，绑定P56D空体；没有业务区域/坐标/样式输出。','kml-export.md'),
 ('KML能确认列表语义？','不能；只能按CAD顶点/面来源解释，kml-cad-map对应项为N/A。','kml-export.md'),
 ('与A5共享？','共享OasModel/Plane/公共CAD writer同MethodDef；DB schema相同但B4私有loader/decoder/尺寸/RDH为独立复制算法。','oas-parameter-model.md'),
 ('与B3共享？','frame、SelectAll/parser、APV obstacle carrier、Mark/Highlight和writer；不共享APV面/HL算法/状态TXT格式。','runway-frame.md'),
 ('与B5共享？','frame及公共导入/Mark/writer；Take5是不同事件中的相同截取；无B4 P793/风螺旋或TurnEnd复用。','pbn-turn.md')]
closure='# Round 7 Closure\n\n**Round 7: PARTIALLY ACCEPTED (static recovery)**，2026-10-28。仅B4；Round1–6及原材料冻结；本轮不运行目标DLL/AutoCAD，不补接评价或KML，不进入A5。\n\n## 33项逐条答复\n\n|序号|问题|答复|证据报告|\n|---|---|---|---|\n'
for i,(q,a,p) in enumerate(answers,1):closure+=f'|{i}|{q}|{a}|[定位](../B4-PbnIls/{p})|\n'
closure+='''
## 验收矩阵

|项目|恢复状态|
|---|---|
|OAS参数/数据库/系数修正|静态闭合；原行/hash/定长解码保存|
|OAS面/域|共享/专用两套均恢复；专用缺W*与CATII分支等异常保留|
|PBN任意定点转弯|未找到实现，不以同轴衔接冒充|
|OAS→固定宽度衔接|点线/面/轮廓闭合；后续任意转弯未闭合|
|障碍物评价/最低标准|方法体恢复，UI调度缺失；无控制障碍物归并|
|事件可达性/Take5|已核对；第6点UI绕过未发现|
|CAD|列表到二维Polyline/Group及XData静态链闭合；未宿主执行|
|KML|空方法已证实；导出功能缺失|
|规范映射/跨模块关系|按证据及授权边界完成；实现依据未强归版本|

## 验证材料

分层数字与范围见 [verification.md](../B4-PbnIls/verification.md)、[tests.log](tests.log)、[static-tests.json](static-tests.json)。所有计算验证为独立恢复源码E3，原DLL运行E4为空。冻结完整性最终结果见 [integrity-report.json](integrity-report.json)，输出文件hash见 [output-manifest.json](output-manifest.json)。

## B4 → A5 可复用的已恢复层

可复用OasModel/Plane的原MethodDef与域决策、数据库schema/key/解码验证、尺寸/RDH修正公式、公共2D CAD writer、参数TXT结构和通用障碍物管线。必须识别B4专用四面衔接与共享五面模型的边界，不能把前者代替A5。

**A5仍有必要逆向，但可以改为差异恢复。** 优先检查A5真实事件/评价调度、共享P41B为何没有incoming、CATII/AUTO的实际输出、HL和Ha/最低标准、FAF/FAP及配置/序列化差异。无需从零重做本轮已恢复的共享数值层。此为下一轮建议，本轮不启动。
'''
(O/'closure.md').write_text(closure,encoding='utf-8')
print('reports',len(list(A.glob('*.md'))),'answers',len(answers),'event rows',len(erows))
