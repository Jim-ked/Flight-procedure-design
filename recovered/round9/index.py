"""Round9 baseline, metadata/IL/source and exact call evidence. No target execution."""
from pathlib import Path
import csv,json,re,hashlib,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];R=ROOT/'reverse-analysis';O=ROOT/'recovered/round9';A=ROOT/'recovered/A4-NavAidProtection';E=A/'evidence'
E.mkdir(parents=True,exist_ok=True);(O/'fixtures').mkdir(exist_ok=True)
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
def dump(p,d):p.write_text(json.dumps(d,ensure_ascii=False,indent=2),encoding='utf-8')
if not (O/'frozen-inputs.json').exists():
 base=[]
 for directory in ['recovered','reverse-analysis','WsTools-master','doc']:
  for p in sorted((ROOT/directory).rglob('*')):
   if p.is_file() and A not in p.parents and O not in p.parents:base.append(dict(path=str(p.relative_to(ROOT)),size=p.stat().st_size,sha256=sha(p)))
 dump(O/'frozen-inputs.json',base)
proc={x['token']:x for x in rows(R/'04_type-map/methods-only/methods.csv')};raw={x['token']:x for x in rows(R/'04_type-map/raw/methods.csv')};maps={x['processed_token']:x for x in rows(R/'04_type-map/tool-token-map.csv') if x['kind']=='Method'}
calls=rows(R/'05_callgraph/static-sites.csv');loc=rows(R/'04_type-map/method-source-locations.csv')
core={t for t,m in proc.items() if m['name'].split('::')[0]=='\\x89\\x8b.\\x89\\x8a'}
assert len(core)==13,len(core)
events=[x for x in rows(R/'04_type-map/events.csv') if x['class']=='_0089_008A'];controls=[x for x in rows(R/'04_type-map/controls.csv') if x['class']=='_0089_008A']
roots={e['handler_tokens'] for e in events};reach=set(roots);adj={}
for c in calls:
 if c['target'].startswith('0x06'):adj.setdefault(c['caller'],set()).add(c['target'])
todo=list(reach)
while todo:
 for t in adj.get(todo.pop(),set()):
  if t not in reach:reach.add(t);todo.append(t)
dump(E/'event-reachability.json',dict(roots=sorted(roots),reachable=sorted(reach),scope='direct call/callvirt/newobj; MethodSpec inspected separately; not dynamic execution'))
selected=core|{'0x06000060','0x06000087','0x06000089','0x0600012A','0x0600012D','0x06000134'}
selected|=reach|{'0x0600005A'}
selected|={t for t,m in proc.items() if m['name'].split('::')[0].split('.')[-1] in {'\\x87\\x9c','\\x87\\x98','\\x87\\x90','\\x87\\x94'}}
allowed={'\\x8c.\\x8b','\\x90\\x90.\\x97','\\x9e.\\x9d'}
# Select actual dependencies and their directly called helper methods; do not copy unrelated business classes.
selected|={c['target'] for c in calls if c['caller'] in core and c['target'].startswith('0x06')}
for _ in range(5):
 selected|={c['target'] for c in calls if c['caller'] in selected and c['target'].startswith('0x06') and (proc.get(c['target'],{}).get('name','').startswith(('\\x8f\\x8d.','\\x8f\\x8b.','\\x8f\\x89.','\\x8c.','\\x98.','\\x9e.')))}
source=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
a=next(i for i,l in enumerate(source) if '\tpublic class _0089_008A : Form'==l);b=next(i for i in range(a+1,len(source)) if source[i]=='\t}')
(E/'FormNavAids.source.txt').write_text('\n'.join(f'{i+1}: {source[i]}' for i in range(a,b+1)),encoding='utf-8')
ms=[]
for t in sorted(selected):
 if t not in maps:continue
 old=maps[t]['original_token'];l=next((x for x in loc if t in x['tokens'].split(';')),{});m=dict(processed_token=t,original_token=old,original_rva=raw[old]['rva'],processed_rva=proc[t]['rva'],name=proc[t]['name'],signature=maps[t]['description'],source=l.get('source',''),line=l.get('line',''),raw_status=raw[old]['status'],raw_il_sha256=raw[old]['il_sha256'],processed_il_sha256=proc[t]['il_sha256'],scope='A4 core' if t in core else 'shared dependency/command')
 # Constructor/static constructor and native identity source locations missed by old source index.
 if t in core and not m['line']:
  needle={'.ctor':'public _0089_008A()', '.cctor':'static _0089_008A()'}.get(proc[t]['name'].split('::')[-1])
  if needle:
   hit=next(i for i in range(a,b+1) if needle in source[i]);m['source']='03_recovered-src/annotated-strings/--/--.cs';m['line']=str(hit+1)
 # Some primitive overloads lack source-location index; retain full original IL even then.
 ms.append(m)
 if m['source'] and m['line']:
  ss=(R/m['source']).read_text(encoding='utf-8').splitlines();i=int(m['line'])-1;indent=re.match(r'\s*',ss[i])[0];j=next((k for k in range(i+1,len(ss)) if ss[k]==indent+'}'),i)
  (E/'methods').mkdir(exist_ok=True);(E/'methods'/(t+'.source.txt')).write_text('\n'.join(f'{k+1}: {ss[k]}' for k in range(i,j+1)),encoding='utf-8')
meta={m['processed_token']:m for m in ms};out(E/'method-index.csv',ms)
for tier,key in [('methods-only','processed_token'),('raw','original_token')]:
 directory=E/('processed' if tier=='methods-only' else 'raw');directory.mkdir(exist_ok=True);wanted={m[key] for m in ms};il=(R/('04_type-map/'+tier+'/independent-il.txt')).read_text(encoding='utf-8')
 for match in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',il,re.M|re.S):
  t='0x'+match[1]
  if t in wanted:(directory/(t+'.il.txt')).write_text(match[0],encoding='utf-8')
for e in events:
 m=meta[e['handler_tokens']];e.update(original_token=m['original_token'],original_rva=m['original_rva'],processed_rva=m['processed_rva'],direct_callees=';'.join(c['target']+' '+c['target_name'] for c in calls if c['caller']==e['handler_tokens']),CAD_API=';'.join(c['target_name'] for c in calls if c['caller']==e['handler_tokens'] and 'Autodesk' in c['target_name']),reachability='reachable')
out(E/'event-identities.csv',events);out(E/'controls.csv',controls)
props=[]
for i in range(a,b+1):
 m=re.match(r'\s*(_\w+)\.(Text|Visible|Enabled|SelectedIndex|ReadOnly|Checked|Name|TabIndex) = (.*);',source[i])
 if m:props.append(dict(line=i+1,field=m[1],property=m[2],value=m[3]))
out(E/'control-state.csv',props)
for c in controls:
 for prop in ['Text','Checked','Enabled','Visible','ReadOnly']:
  c['designer_'+prop]=';'.join(p['value'] for p in props if p['field']==c['field'] and p['property']==prop and int(p['line'])>23100) or 'framework default / no explicit assignment'
out(E/'parameter-control-inventory.csv',controls)
out(E/'direct-calls.csv',[c for c in calls if c['caller'] in selected]);out(E/'global-incoming.csv',[c for c in calls if c['target'] in core]);out(E/'reachable-calls.csv',[c for c in calls if c['caller'] in reach])
# MethodSpec-coded calls are catalogued explicitly, avoiding a silent reachability gap.
out(E/'methodspec-calls.csv',[c for c in calls if c['target'].startswith('0x2B') and c['caller'] in reach])
fields=[];branches=[];apis=[];constants=[]
terms=['IntersectWith','Offset','Polyline','Arc','Tangent','XData','GetPoint','GetEntity','GetSelection','SelectAll','Erase','AddVertexAt','Group','Line','Layer','Color','Linetype','AppendEntity']
for m in ms:
 p=E/'processed'/(m['processed_token']+'.il.txt')
 if not p.exists():continue
 for l in p.read_text(encoding='utf-8').splitlines():
  x=re.match(r'(IL_\w+): (\w+(?:\.\w+)?) (.*)',l)
  if not x:continue
  off,op,operand=x.groups();rec=dict(method=m['processed_token'],original=m['original_token'],offset=off,opcode=op,operand=operand)
  if op in ['ldfld','ldsfld','ldflda','stfld','stsfld']:fields.append(rec)
  if op.startswith(('bge','bgt','ble','blt','beq','bne','brtrue','brfalse','switch')):branches.append(rec)
  if op.startswith('ldc'):constants.append(rec)
  if any(t in operand for t in terms):apis.append(rec)
out(E/'field-flow.csv',fields);out(E/'branch-sites.csv',branches);out(E/'constant-sites.csv',constants);out(E/'cad-api-sites.csv',apis)
dot=['digraph A4 {','rankdir=LR;']
for c in calls:
 if c['caller'] in core or (c['caller'] in selected and c['target'] in selected):dot.append('"'+c['caller']+'" -> "'+c['target']+'";')
dot.append('}');(E/'callgraph.dot').write_text('\n'.join(dot),encoding='utf-8')
print('frozen',len(json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8'))),'core',len(core),'indexed',len(ms),'events',len(events),'reachable',len(reach))
print('\n'.join(m['processed_token']+' '+m['name']+' '+m['source']+':'+m['line'] for m in ms if m['scope']=='A4 core'))
