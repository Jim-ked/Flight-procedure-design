from pathlib import Path
import csv,re,json,sys,hashlib
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];R=ROOT/'reverse-analysis';O=ROOT/'recovered/round5';A=ROOT/'recovered/B5-PbnDeparture';E=A/'evidence'
def rows(p):
 with p.open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
def out(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
proc={x['token']:x for x in rows(R/'04_type-map/methods-only/methods.csv')};raw={x['token']:x for x in rows(R/'04_type-map/raw/methods.csv')}
maps={x['processed_token']:x for x in rows(R/'04_type-map/tool-token-map.csv') if x['kind']=='Method'};loc=rows(R/'04_type-map/method-source-locations.csv');calls=rows(R/'05_callgraph/static-sites.csv')
def enc(s):return re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
cls=['_008B_0094','_008C_0091','_008C_0093','_008A_0089','_008B_0098','_008B_009A','_008E_0097','_008E_009D','_008E_009B','_008F_0086','_008F_008C','_008F_008E','_008F_0090','_008F_0096']
core={t for t,m in proc.items() if m['name'].split('::')[0].split('.')[-1] in set(map(enc,cls[:3]))}|{f'0x06000{i:03X}' for i in range(0x54A,0x551)}
tokens={t for t,m in proc.items() if m['name'].split('::')[0].split('.')[-1] in set(map(enc,cls))}|core
tokens|={'0x060000AC','0x060000AD','0x060000AE','0x060000AF','0x060000B0','0x0600010D','0x0600012F','0x0600009C','0x0600009D','0x0600009E','0x06000087','0x06000086','0x06000089','0x060007D1','0x060007D8','0x060007D9','0x060007DA','0x060007DB'}
tokens|={'0x0600012D','0x06000134','0x060000B1','0x060000B2'}
tokens|={'0x06000113','0x0600012A'}
tokens|={'0x0600006B','0x060000F4','0x060000F6'}
tokens|={'0x060007DE','0x060007DF'}
ms=[]
for t in sorted(tokens):
 if t not in maps:continue
 old=maps[t]['original_token'];l=next((x for x in loc if t in x['tokens'].split(';')), {})
 ms.append(dict(processed_token=t,original_token=old,original_rva=raw[old]['rva'],processed_rva=proc[t]['rva'],name=proc[t]['name'],signature=maps[t]['description'],source=l.get('source',''),line=l.get('line',''),raw_status=raw[old]['status'],raw_size=raw[old]['code_size'],processed_size=proc[t]['code_size'],raw_il_sha256=raw[old]['il_sha256'],processed_il_sha256=proc[t]['il_sha256'],scope='B5 core' if t in core else 'shared dependency evidence'))
out(E/'method-index.csv',ms);meta={m['processed_token']:m for m in ms}
allil={}
for tier,key in [('methods-only','processed_token'),('raw','original_token')]:
 d=E/('processed' if tier=='methods-only' else 'raw');d.mkdir(exist_ok=True)
 il=(R/('04_type-map/'+tier+'/independent-il.txt')).read_text(encoding='utf-8')
 selected={x[key] for x in ms}
 for m in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',il,re.M|re.S):
  t='0x'+m[1]
  if t in selected:(d/(t+'.il.txt')).write_text(m[0],encoding='utf-8')
  if tier=='methods-only':allil[t]=m[0]
out(E/'direct-calls.csv',[x for x in calls if x['caller'] in tokens])
flow=[];conditions=[]
for t in tokens:
 for line in allil.get(t,'').splitlines():
  m=re.match(r'(IL_\w+): (\w+(?:\.\w+)?) (.*)',line)
  if not m:continue
  off,op,operand=m.groups()
  if op in ['ldfld','ldsfld','ldflda','stfld','stsfld']:flow.append(dict(method=t,original=meta[t]['original_token'],offset=off,opcode=op,field=operand))
  if op.startswith(('bge','bgt','ble','blt','beq','bne','brtrue','brfalse','switch')):conditions.append(dict(method=t,offset=off,opcode=op,target=operand))
out(E/'field-flow.csv',flow);out(E/'branch-sites.csv',conditions)
events=rows(E/'events.csv');controls=rows(E/'controls.csv')
src=(E/'_008B_0094.source.txt').read_text(encoding='utf-8').splitlines();props=[]
for l in src:
 m=re.match(r'(\d+):\s+(_\w+)\.(Text|Visible|Enabled|SelectedIndex|ReadOnly|Checked|Name|TabIndex) = (.*);',l)
 if m:props.append(dict(line=m[1],field=m[2],property=m[3],value=m[4]))
out(E/'control-state.csv',props)
text={x['field']:x['value'] for x in props if x['property']=='Text'}
report=['# B5 完整事件图','', '绑定来自 designer 处理后源码；原文件主体多为保护占位。表中 token/RVA 由元数据映射，不按名称猜测。完整 API/调用位置见 evidence/direct-calls.csv。','', '|Control / Text|Event|Original MethodDef / RVA|Processed MethodDef / RVA|Handler|Direct callees / CAD API|','|---|---|---|---|---|---|']
for e in events:
 t=e['handler_tokens'];m=meta[t];cs=[x for x in calls if x['caller']==t]
 short=', '.join(sorted({x['target']+' '+x['target_name'] for x in cs if x['target'].startswith('0x06') or 'Autodesk' in x['target_name']}))
 report.append('|'+e['control_name']+' '+text.get(e['field'],'').split(' /*')[0]+'|'+e['event']+'|'+m['original_token']+' / '+m['original_rva']+'|'+t+' / '+m['processed_rva']+'|'+e['handler']+'|'+short+'|')
report+=['','## 可达性与未绑定方法','', 'P501 buttonEvl：一键评估，Visible=false；P50C button8：直线段评估，Visible=false；P50D button7：转弯区评估，Visible=false。三个绑定体均只显示“请指定转弯点。”。P50F button9为空且隐藏。没有类别或Tab SelectedIndexChanged绑定；默认Tab index=0，方向框是左/右转选择。','', 'P5CD（高度评价）与P5D8（指定点评价）在全程序集已解码静态调用表中均无入边。三条嵌套sort selector P54C/P54D/P54E也没有ldftn调用位点。不能补造一键 pipeline 或危险值合并策略。','', 'P4FA为未绑定XYZ高亮/视图定位方法；P4FE为未绑定坐标转换/结果表方法。P4F5是未绑定ScreenData转发。P508为空未绑定；P509有TP高度刷新逻辑，但只绑定PDG TextChanged；TP距离本身没有TextChanged绑定。所有主类方法保存在 evidence/method-index.csv 与完整source。']
(A/'event-map.md').write_text('\n'.join(report),encoding='utf-8')
# Explicit negative evidence has scope and incoming reference locations.
negative={}
for t in ['0x060005CD','0x060005D8','0x0600054C','0x0600054D','0x0600054E']:
 negative[t]=dict(name=proc[t]['name'],incoming=[x for x in calls if x['target']==t],nonheader_il_references=[dict(caller=k,lines=[l for l in v.splitlines()[1:] if t in l]) for k,v in allil.items() if t in '\n'.join(v.splitlines()[1:])])
business={t for t in core if '0x060005C7'<=t<='0x060005DC'}
negative['B2_constructor_direct_calls']=[x for x in calls if x['caller'] in core and '\\x8c\\x89::' in x['target_name']]
negative['B1_constructor_direct_calls']=[x for x in calls if x['caller'] in core and '\\x8c\\x87::' in x['target_name']]
negative['RF_scope']='B5 Form, two business classes and their indexed shared dependencies. No RF / RadiusToFix / arc-to-fix labels or dispatch found; no all-DLL feature claim.'
(E/'negative-evidence.json').write_text(json.dumps(negative,ensure_ascii=False,indent=2),encoding='utf-8')
out(O/'shared-pbn-departure-calls.csv',[dict(x,original_target=maps.get(x['target'],{}).get('original_token',''),original_target_rva=raw.get(maps.get(x['target'],{}).get('original_token'),{}).get('rva','')) for x in calls if x['caller'] in core and x['target'] not in core and x['target'].startswith('0x06')])
connect=[x for x in calls if x['caller'] in tokens and re.search('IntersectWith|Offset|Polyline|Arc::|Circle::|Tangent|Erase|GetPoint|GetEntity|GetSelection|SelectAll|XData|Group::|AppendEntity|\\\\x8b\\\\x88\\\\x93|\\\\x8a\\\\x9e\\\\x9b|\\\\x8b\\\\x88\\\\x89',x['target_name'])]
out(E/'connection-api-sites.csv',connect)
out(E/'incoming-references.csv',[x for x in calls if x['target'] in core and x['caller'] not in core])
print('core',len(core),'evidence methods',len(ms),'field sites',len(flow),'branches',len(conditions),'events',len(events))
