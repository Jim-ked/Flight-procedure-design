from pathlib import Path
import csv,json,hashlib,re,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round5';A=ROOT/'recovered/B5-PbnDeparture';E=A/'evidence';R=ROOT/'reverse-analysis'
sys.path.insert(0,str(R/'tools/python'));import dnfile
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,rs):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
def put(name,s):(A/name).write_text(s.strip()+'\n',encoding='utf-8')
calls=rows(E/'direct-calls.csv');pe=dnfile.dnPE(str(R/'02_deobfuscated/WindSpiralBasic.methods-only.dll'));gs=[]
for c in calls:
 if not c['target'].startswith('0x2B'):continue
 spec=pe.net.mdtables.MethodSpec.rows[int(c['target'],16)-0x2B000001];base=spec.Method
 token='0x%08X'%((0x06000000 if base.table.name=='MethodDef' else 0x0A000000)+base.row_index)
 gs.append(dict(caller=c['caller'],il_offset=c['il_offset'],methodspec=c['target'],resolved_token=token,name=str(base.row.Name),instantiation_hex=spec.Instantiation.value.hex(),evidence='static PE MethodSpec.Method; not target execution'))
pe.close();out(E/'generic-calls.csv',gs)
# Field roles preserve unknowns instead of renaming them into normative concepts.
roles={
'PbnDepartureAltitudeTurn':{'_008A_0086_0096':'initial full width=300','_008A_0086_0097':'early offset=600','_008A_0086_0098':'tan15','_008A_0086_0099':'TP outer width','_008A_0086_009A':'latest outer width','_008A_0086_009B':'TP distance','_008A_0086_009C':'latest reaction distance','_008A_0086_009D':'gradient before','_008A_0086_009E':'gradient after','_008A_0087_0086':'early flag','_008A_0087_0087':'S','_008A_0087_0088':'A; X6351.95/Z6531.95','_008A_0087_0089':'B 13263.71','_008A_0087_008A':'K outer','_008A_0087_008B':'K primary','_008A_0087_008C':'C outer','_008A_0087_008D':'C inner1852','_008A_0087_008E':'early runwayLength offset','_008A_0087_008F':'DER','_008A_0087_0090':'THR','_008A_0087_0091':'TurnEnd','_008A_0087_0099':'all drawing lists','_008A_0087_009A':'S-A line','_008A_0087_009B':'K/B perpendicular line','_008A_0087_009C':'TurnInput','_008A_0087_009D':'initial Hull','_008A_0087_009E':'final evaluation Hull','_008A_0088_0086':'15degree radians','_008A_0088_0087':'90degree radians'},
'PbnDepartureFlyOver':{'_008A_0088_008E':'initial full width=300','_008A_0088_008F':'tan15','_008A_0088_0090':'earliest width','_008A_0088_0091':'navigation latest width','_008A_0088_0092':'reaction latest width','_008A_0088_0093':'earliest TP-1482','_008A_0088_0094':'navigation latest TP+1482','_008A_0088_0095':'reaction latest','_008A_0088_0096':'gradient before','_008A_0088_0097':'gradient after','_008A_0089_0088':'DER','_008A_0089_0089':'THR','_008A_0089_008A':'TurnEnd','_008A_0089_0095':'drawing lists','_008A_0089_0098':'TurnInput','_008A_0089_0099':'fixed1482; ATT source not spec-bound','_008A_0089_009A':'initial evaluation Hull','_008A_0089_009B':'final selected-subset Hull','_008A_0089_009C':'15degree radians','_008A_0089_009D':'90degree radians','_008A_0089_009E':'outer boundary sample list1','_008A_008A_0086':'outer boundary sample list2','_008A_008A_0087':'post-turn lists'},
'PbnDepartureObstacle':{'_0088_008F_0094':'area label','_0088_008F_0095':'secondary text getter0098','_0088_008F_0096':'d0','_0088_008F_0097':'dr','_0088_008F_0098':'MOC','_0088_008F_0099':'OCA','_0088_008F_009A':'PDA','_0088_008F_009B':'required gradient'}}
fs=[]
for cls,mapping in roles.items():
 s=(A/(cls+'.Recovered.cs')).read_text(encoding='utf-8')
 for m in re.finditer(r'^\s*(public|private|internal) (?:static )?([^\n;=]+?) (_00[0-9A-F_]+);',s,re.M):
  name=m[3];fs.append(dict(recovery_class=cls,field=name,type=m[2],role=mapping.get(name,'point-list/control state; see exact constructor writes, no normative role inferred'),basis='processed source plus field-flow.csv; interpretation named only where assigned/read'))
out(E/'field-semantics.csv',fs)
meta={m['processed_token']:m for m in rows(E/'method-index.csv')}
adapters={'ScreenData':['4F6','4F7'],'MarkSources':['511'],'Highlight':['4F9'],'EvaluationButton':['501','50C','50D'],'UpdateTp':['505','506'],'ConstructorTp':['5C8'],'PickTp':['507','50E'],'ReadTurn':['500','50A'],'Direction':['502'],'ResultTable':['4F8'],'CAD.Record':['503','50B','087','089','12A','12D','134']}
rs=[]
for name,ts in adapters.items():
 for t in ts:
  m=meta['0x06000'+t];rs.append(dict(adapter=name,processed_token=m['processed_token'],original_token=m['original_token'],original_rva=m['original_rva'],processed_rva=m['processed_rva'],boundary='record adapter or extracted arithmetic, not full UI/AutoCAD implementation'))
out(E/'adapter-method-map.csv',rs)
put('help-config-crosscheck.md',r'''
# 帮助/config与代码交叉核验

原路径 WsTools-master/WindSpiral2026/帮助文件/FormPbnDepEvl.html 与 FormFlyOverDF.html；副本在reverse-analysis/01_original同路径。原件与副本均只读，hash在frozen-inputs.json。

|材料说法|代码事实|结论|
|---|---|---|
|B5有定高和FlyOver-DF|两个tab和独立业务类|支持公开范围，非完整PBN departure engine|
|一键/直线/转弯评价可用|三个按钮隐藏且只提示|帮助不等于当前版本可用流程|
|列表高亮并居中|绑定P4F9仅高亮；居中旧方法P4FA未绑定|部分帮助与绑定不符|
|B2 ATT为0外边界与B5高度相同（FormFlyOverDF:62）|B5没有new B2，也没有ATT=0参数传递|不证明也不否定数学边界相同；仍待数值/结构等价证明|
|导航规格/类别自动选值|无对应绑定，FO1482和宽度常数硬编码|不能依据帮助概述补出RNP dispatch|
|保存配置|P4F1→P0F6、P4F2→P0F4均用FormDeparture key|FormPbnDepEvl标题不等于配置键；无规范自动选择证据|

P06B命令特性 Y55_PBN_Departure→new P4EE Form；原/处理身份及IL在method-index与processed。Load后真正可达内容以事件/调用索引为准；未读取或执行外部脚本来填补缺失入口。
''')
# Normative excerpts were extracted read-only; preserve PDF index, not corrupted printed page text.
p=O/'standard-pages.json';norm=json.loads(p.read_text(encoding='utf-8'));keep={1,446,447,448,449,450,451,452,455,493,494,495,496}
excerpt=dict(path=norm['path'],sha256=norm['sha256'],normalization=norm['normalization'],locator='one-based PDF page; extracted printed footer digits may reverse',pages=[x for x in norm['pages'] if x['pdf_page'] in keep])
(O/'standard-excerpts.json').write_text(json.dumps(excerpt,ensure_ascii=False,indent=2),encoding='utf-8')
put('standard-mapping.md',r'''
# AC-97-FS-005规范映射与差异

基线：民航规〔2020〕12号，2020-05-19，doc/航空器运行目视和仪表飞行程序设计规范.pdf。只读提取及原PDF SHA256见../round5/standard-excerpts.json。下列页码均为**PDF从1起页序**，避免文字提取导致印刷页码数字倒置。

|真实代码行为|规范位置|映射/差异|
|---|---|---|
|TA/H采用Spiral86；FO独立spiral类|PDF446，Ⅲ-2-2 2.1.3.2/2.1.3.3|规范要求离场/TAH风螺旋/边界圆弧方法；方法家族对应，不证明采样与全部分支合规|
|高度early=−跑道长度+600；TP=(H−DER.Z−5)/g；latest加C6|PDF452，表Ⅲ-2-2-1|600m、5m与TA/H最早/最晚框架对应；代码只有THR/DER无TORA起点字段，不能证明THR等于TORA起点。延时合并6秒是否符合所有场景未证|
|FO earliest=TP−1482、latest=TP+1482+C6|同表飞越行|符合ATT/反应/建立坡度变量结构；1482无导航规范绑定，**实现依据待确认**|
|初始150半宽、15°至3704；不按ARP距离变化|PDF494，Ⅲ-3-1 1.3.1/1.3.2；PDF496表Ⅲ-3-1-1|3704为多个条件下可见半宽；规范传感器及15/30NM ARP变化未在代码实现中发现，不能标自动RNP1|
|后续15°连接及1852/3704封顶|PDF448，Ⅲ-2-2 2.3.1.3/2.3.2|有同类规则，但代码以75°选侧及自有交点分支实现；未证明所有先后区位置关系均符合规范|
|dr/d0围绕最早转弯位置计算|PDF451，Ⅲ-2-2 2.5.1 KK′|FO用earliest；高度含多区域分支，不能仅凭名称判断通用最短距离等价|
|仅TA/H与FlyOver-DF公开模式，无Fly-by/RF|PDF494，Ⅲ-3-1 1.4.1.1；PDF449 2.4|规范列四种，B5只证两种；不补出RF/旁切功能，不否定独立B1|
|MOC .008/75；高度直线PDA/required异常赋值|处理P5CD/P5D8；规范映射只作对照|不修为规范候选；异常赋值无规范解释，**实现依据待确认**|

没有证据确定作者实际使用哪版ICAO Doc8168、旧国内规范或自行简化。以上相似处不是依据版本鉴定；代码缺失的传感器、ARP、分类、统一副区MOC衰减不能由规范补造。1482与0.8NM的近似也不是身份/业务来源证据。
''')
# Source and doc hashes supplement the start-of-round frozen tree baseline.
materials=[]
for p in [ROOT/'doc/航空器运行目视和仪表飞行程序设计规范.pdf',ROOT/'WsTools-master/WindSpiral2026/WindSpiralBasic.dll',ROOT/'WsTools-master/WindSpiral2026/config.xml',ROOT/'WsTools-master/WindSpiral2026/帮助文件/FormPbnDepEvl.html',ROOT/'WsTools-master/WindSpiral2026/帮助文件/FormFlyOverDF.html']:
 materials.append(dict(path=str(p),size=p.stat().st_size,sha256=hashlib.sha256(p.read_bytes()).hexdigest(),baseline='also in frozen-inputs except doc PDF; PDF captured on read-only extraction'))
out(O/'material-baseline.csv',materials)
# Recommend future order from existing graph only, without reading new module bodies.
allcalls=rows(R/'05_callgraph/static-sites.csv');methods=rows(R/'04_type-map/methods-only/methods.csv');controls=rows(R/'04_type-map/controls.csv');existing={x['target'] for x in calls if x['target'].startswith('0x06')};future=[]
def enc(s):return re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
for ui in ['FormApvEvl','FormPbnIlsEvl']:
 cls={x['class'] for x in controls if x['ui_name']==ui};tokens={m['token'] for m in methods if m['name'].split('::')[0].split('.')[-1] in {enc(c) for c in cls}}
 for c in allcalls:
  if c['caller'] in tokens and (c['target'] in existing or '\\x8c\\x87::' in c['target_name'] or '\\x8c\\x89::' in c['target_name']):future.append(dict(module=ui,caller=c['caller'],offset=c['il_offset'],target=c['target'],target_name=c['target_name'],scope='existing static-sites index only; no new business-body recovery'))
out(O/'round6-order-evidence.csv',future)
features=[]
for query in [r'\bRF\b',r'RadiusToFix',r'arc.to.fix',r'constant.radius',r'Fly.?by',r'旁切']:
 matches=[]
 for p in E.glob('*.source.txt'):
  for i,l in enumerate(p.read_text(encoding='utf-8').splitlines()):
   if re.search(query,l,re.I):matches.append(dict(file=p.name,line=i+1,text=l.strip()))
 features.append(dict(query=query,scope='B5 Form and indexed directly used helper source excerpts only',matches=matches))
(E/'feature-search.json').write_text(json.dumps(features,ensure_ascii=False,indent=2),encoding='utf-8')
print('generic calls',len(gs),'fields',len(fs),'adapter rows',len(rs),'future indexed edges',len(future))
