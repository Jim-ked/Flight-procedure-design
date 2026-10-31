from pathlib import Path
import csv,json,re,sys,hashlib,xml.etree.ElementTree as ET
ROOT=Path(__file__).resolve().parents[2];R=ROOT/'reverse-analysis';O=ROOT/'recovered/round9';A=ROOT/'recovered/A4-NavAidProtection';E=A/'evidence'
sys.stdout.reconfigure(encoding='utf-8');sys.path.insert(0,str(R/'tools/python'));import dnfile
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
def dump(p,d):p.write_text(json.dumps(d,ensure_ascii=False,indent=2),encoding='utf-8')
ms=rows(E/'method-index.csv');meta={m['processed_token']:m for m in ms};core={t for t,m in meta.items() if m['scope']=='A4 core'}
pe=dnfile.dnPE(str(R/'02_deobfuscated/WindSpiralBasic.methods-only.dll'));spec={};sigs=[];native=[];headers=[]
for i,m in enumerate(pe.net.mdtables.MethodSpec.rows):spec['0x2B%06X'%(i+1)]=('0x06' if type(m.Method.row).__name__=='MethodDefRow' else '0x0A')+'%06X'%m.Method.row_index
for im in pe.net.mdtables.ImplMap.rows:
 if im.MemberForwarded.row_index==0x2F6:native.append(dict(token='0x060002F6',module=str(im.ImportScope.row.Name),entry=str(im.ImportName)))
for m in ms:
 r=pe.net.mdtables.MethodDef.rows[int(m['processed_token'],16)-0x06000001];sigs.append(dict(processed_token=m['processed_token'],original_token=m['original_token'],signature_hex=r.Signature.value.hex()))
 rva=int(m['processed_rva'],16)
 if rva:
  b=pe.get_data(rva,12);kind=b[0]&3;flags=int.from_bytes(b[:2],'little') if kind==3 else 0;headers.append(dict(token=m['processed_token'],header='fat' if kind==3 else 'tiny',InitLocals=bool(flags&16),locals='0x%08X'%int.from_bytes(b[8:12],'little') if kind==3 else 'none'))
pe.close();dump(E/'native-import.json',native);out(E/'signatures.csv',sigs);out(E/'method-headers.csv',headers)
calls=rows(R/'05_callgraph/static-sites.csv');expanded=[];resolved=[]
for c in calls:
 d=dict(c)
 if d['target'] in spec:
  if c['caller'] in meta:resolved.append(dict(caller=c['caller'],offset=c['il_offset'],methodspec=c['target'],resolved=spec[c['target']]))
  d['target']=spec[d['target']]
 expanded.append(d)
out(E/'methodspec-resolution.csv',resolved)
roots={e['handler_tokens'] for e in rows(E/'event-identities.csv')};adj={}
for c in expanded:
 if c['target'].startswith('0x06'):adj.setdefault(c['caller'],set()).add(c['target'])
reach=set(roots);todo=list(roots)
while todo:
 for t in adj.get(todo.pop(),set()):
  if t not in reach:reach.add(t);todo.append(t)
dump(E/'event-reachability.json',dict(roots=sorted(roots),reachable=sorted(reach),methodspec_resolved=True))
out(E/'resolved-global-incoming.csv',[c for c in expanded if c['target'] in core]);out(E/'reachability.csv',[dict(processed_token=t,original_token=meta[t]['original_token'],event_root=t in roots,reachable=t in reach,incoming_count=sum(c['target']==t for c in expanded)) for t in sorted(core)])
source=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
(E/'config-handlers.source.txt').write_text('\n'.join(f'{i+1}: {source[i]}' for i in range(895,1276)),encoding='utf-8')
pos=sorted((int(m['line']),t) for t,m in meta.items() if m['scope']=='A4 core' and m['line']);refs=[]
for c in rows(E/'controls.csv'):
 for l in (E/'FormNavAids.source.txt').read_text(encoding='utf-8').splitlines():
  n,s=l.split(':',1)
  if c['field']!='base' and c['field'] in s:refs.append(dict(field=c['field'],control=c['control_name'],method=next((t for k,t in reversed(pos) if k<=int(n)),'declaration'),line=n,expression=s.strip()))
out(E/'control-references.csv',refs)
expressions=[]
for token in ['2F7','2F8','2F9','2FA']:
 for l in (E/'methods'/('0x06000'+token+'.source.txt')).read_text(encoding='utf-8').splitlines():
  if '.Add(' in l or '=' in l or 'if (' in l:expressions.append(dict(method='P'+token,source=l))
out(E/'geometry-expressions.csv',expressions)
semantic={'0x060007E7':'line through two points','0x060007E8':'line through point and angle','0x060007ED':'infinite line intersection','0x06000809':'polar point','0x0600080A':'point addition including Z','0x06000125':'Point3d to numeric point including Z','0x06000113':'GetPoint retry/cancel helper','0x06000087':'Polyline Group writer','0x06000089':'append entity with optional XData'}
out(E/'connection-semantic-calls.csv',[dict(c,meaning=semantic[c['target']]) for c in calls if c['caller'] in meta and c['target'] in semantic])
# Inter-module relations use actual method identities/offsets, not name resemblance.
proc=rows(R/'04_type-map/methods-only/methods.csv')
a3={m['token'] for m in proc if m['name'].split('::')[0].split('.')[-1]=='\\x88\\x97'}
a6={m['token'] for m in proc if m['name'].split('::')[0].split('.')[-1]=='\\x88\\x91'}|{'0x0600035F','0x06000358'}
a9={'0x0600032F','0x06000330','0x06000331'}
edges=[]
for module,owner in [('A3',a3),('A6-base-turn',a6),('A9',a9)]:
 targets={c['target'] for c in calls if c['caller'] in owner}
 for c in calls:
  if c['caller'] in core and c['target'] in targets and c['target'] in set(semantic)|{'0x060000F4','0x060000F6','0x060007D4','0x060007E4','0x060007EA'}:edges.append(dict(peer=module,shared_target=c['target'],A4_caller=c['caller'],A4_offset=c['il_offset'],peer_calls=';'.join(x['caller']+'@'+x['il_offset'] for x in calls if x['caller'] in owner and x['target']==c['target'])))
out(E/'cross-module-shared-calls.csv',edges)
config=ROOT/'WsTools-master/WindSpiral2026/config.xml';rt=ET.parse(config).getroot();node=rt.find('NavAids')
dump(E/'config-evidence.json',dict(path=str(config.relative_to(ROOT)),sha256=hashlib.sha256(config.read_bytes()).hexdigest(),node='NavAids',present=node is not None,entries=[dict(key=c.tag,value=c.text) for c in node] if node is not None else [],load='P2FB -> P0F6',save='P2FC -> P0F4',radio_handler='Checked boolean only',textbox_handler='Text even if Enabled=false'))
checks=[]
def ck(layer,name,b):
 assert b,name
 checks.append(dict(layer=layer,name=name,passed=True))
ck('event/reachability','all five event roots reached',roots<=reach)
ck('event/reachability','native SetFocus not stub',native==[dict(token='0x060002F6',module='user32.dll',entry='SetFocus')])
for t in ['0x060002F7','0x060002F8','0x060002F9','0x06000087','0x060007ED','0x06000113']:ck('event/reachability',t+' reachable',t in reach)
ck('event/reachability','no A9 PriSec dispatch',not (a9&reach))
ck('event/reachability','no A3 Form dispatch',not (a3&reach))
ck('event/reachability','no A6 BaseTurn dispatch',not (a6&reach))
ck('event/reachability','core has no evaluation/grid/obstacle control',not any(re.search('Evl|Evalu|Screen|Mark|OCA|DataGrid|Obstacle|MOC',c['control_name'],re.I) for c in rows(E/'controls.csv')))
ck('CAD writer','draw supplies literal empty metadata',"IL_0898: ldstr ''" in (E/'processed/0x060002F9.il.txt').read_text())
ck('CAD writer','writer optional XData gate', 'P_2.Trim().Length > 0' in (E/'methods/0x06000089.source.txt').read_text(encoding='utf-8'))
ck('CAD writer','2D zero-bulge writer','P_0.AddVertexAt(num, P_1[num], 0.0, 0.0, 0.0)' in (E/'methods/0x06000134.source.txt').read_text(encoding='utf-8'))
ck('serialization','Load invokes P0F6','0x060000F6' in (E/'processed/0x060002FB.il.txt').read_text())
ck('serialization','Closed invokes P0F4','0x060000F4' in (E/'processed/0x060002FC.il.txt').read_text())
for needle in ['return P_0 is TextBox','return P_0 is RadioButton','return P_0 is CheckBox','return ((TextBox)P_0).Text','((RadioButton)P_0).Checked = P_1 == "True"','((CheckBox)P_0).Checked = P_1 == "True"']:
 ck('serialization',needle,needle in (E/'config-handlers.source.txt').read_text(encoding='utf-8'))
ck('serialization','no original NavAids config node',node is None)
ck('serialization','config does not persist radio labels','((RadioButton)P_0).Text' not in (E/'config-handlers.source.txt').read_text(encoding='utf-8'))
for target in ['0x06000087','0x060007E7','0x06000809']:
 ck('cross-module',target+' exact shared MethodDef',any(x['shared_target']==target for x in edges))
ck('cross-module','P7ED not assumed shared by A3/A6-base/A9 without incoming',not any(x['shared_target']=='0x060007ED' for x in edges))
ck('formula','P2FF degrees conversion retained','0.017453292519943295' in (E/'processed/0x060002FF.il.txt').read_text())
dump(O/'static-tests.json',dict(checks=checks,no_target_execution=True));print('native',native,'indexed',len(ms),'resolved',resolved,'static',len(checks),'shared edges',len(edges))
