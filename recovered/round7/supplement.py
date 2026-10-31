from pathlib import Path
import csv,json,re,sys,hashlib
ROOT=Path(__file__).resolve().parents[2]; O=ROOT/'recovered/round7';E=ROOT/'recovered/B4-PbnIls/evidence';R=ROOT/'reverse-analysis'
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
ms={m['processed_token']:m for m in rows(E/'method-index.csv')};calls=rows(R/'05_callgraph/static-sites.csv')
sys.path.insert(0,str(R/'tools/python'));import dnfile
pe=dnfile.dnPE(str(R/'02_deobfuscated/WindSpiralBasic.methods-only.dll'));spec={};enums=[]
for i,m in enumerate(pe.net.mdtables.MethodSpec.rows):
 dest=('0x06' if type(m.Method.row).__name__=='MethodDefRow' else '0x0A')+'%06X'%m.Method.row_index
 spec['0x2B%06X'%(i+1)]=dest
for i,t in enumerate(pe.net.mdtables.TypeDef.rows):
 if str(t.TypeName)=='\x8a\x8f':
  enums.append(dict(token='0x0200%04X'%(i+1),name=str(t.TypeName),fields=[dict(name=str(f.row.Name),signature=f.row.Signature.value.hex()) for f in t.FieldList]))
pe.close();(E/'enum-metadata.json').write_text(json.dumps(enums,ensure_ascii=False,indent=2),encoding='utf-8')
expanded=[];res=[]
for c in calls:
 d=dict(c)
 if c['target'] in spec:
  if c['caller'] in ms:res.append(dict(caller=c['caller'],offset=c['il_offset'],methodspec=c['target'],resolved=spec[c['target']]))
  d['target']=spec[c['target']];d['opcode']='resolved-MethodSpec'
 expanded.append(d)
out(E/'methodspec-resolution.csv',res)
events=rows(E/'events.csv');roots={e['handler_tokens'] for e in events};reached=set(roots);adj={}
for c in expanded:
 if c['opcode'] in ('call','callvirt','newobj','resolved-MethodSpec'):adj.setdefault(c['caller'],set()).add(c['target'])
todo=list(roots)
while todo:
 for t in adj.get(todo.pop(),[]):
  if t.startswith('0x06') and t not in reached:reached.add(t);todo.append(t)
core={t for t,m in ms.items() if m['scope']=='B4 core'}
out(E/'reachability.csv',[dict(processed_token=t,original_token=ms[t]['original_token'],name=ms[t]['name'],bound_handler=t in roots,reachable_from_bound_event=t in reached,incoming_count=sum(c['target']==t for c in expanded)) for t in sorted(core)])
(E/'event-reachability.json').write_text(json.dumps(dict(roots=sorted(roots),reachable=sorted(reached)),indent=2),encoding='utf-8')
out(E/'resolved-global-incoming.csv',[c for c in expanded if c['target'] in core])
g=['digraph B4 {','rankdir=LR;']
for e in events:g.append('"'+e['control_name']+'.'+e['event']+'" -> "'+e['handler_tokens']+'";')
for c in expanded:
 if c['caller'] in core and c['target'] in ms:g.append('"'+c['caller']+'" -> "'+c['target']+'" [label="'+c['il_offset']+' '+c['opcode']+'"];')
for t in ['0x060005E0','0x06000567']:g.append('"'+t+'" [color=red,label="'+t+' orphan"];')
g.append('}');(E/'callgraph.dot').write_text('\n'.join(g),encoding='utf-8')
ss=(E/'_008B_0096.source.txt').read_text(encoding='utf-8').splitlines();pos=sorted((int(m['line']),t) for t,m in ms.items() if m['line'] and 60750<=int(m['line'])<=65600)
refs=[]
for c in rows(E/'controls.csv'):
 for l in ss:
  n,s=l.split(':',1)
  if re.search(r'(?<!\w)'+re.escape(c['field'])+r'(?!\w)',s):refs.append(dict(control=c['control_name'],field=c['field'],method=next((t for n0,t in reversed(pos) if n0<=int(n)),'declaration'),line=n,source=s.strip()))
out(E/'control-references.csv',refs)
terms=['IntersectWith','Offset','Polyline','Arc','Circle','Tangent','Intersect','Envelope','Clip','Extend','XData','GetPoint','GetEntity','GetSelection','SelectAll','Erase','AddVertexAt','AppendEntity','BlockReference','Group','P793','Spiral','1482','1852','3704','4630','9260']
api=[]
for p in sorted((E/'processed').glob('*.txt')):
 if p.stem.split('.')[0] not in ms:continue
 for l in p.read_text(encoding='utf-8').splitlines():
  for term in terms:
   match=bool(re.search(r': ldc\.(?:r8|i4(?:\.s)?) '+re.escape(term)+r'(?:\.0)?(?:\s|$)',l)) if term.isdigit() else term.lower() in l.lower()
   if l.startswith('IL_') and match:api.append(dict(method=p.name.split('.')[0],keyword=term,IL=l))
out(E/'connection-api-sites.csv',api);(E/'connection-api-coverage.json').write_text(json.dumps({t:sum(x['keyword']==t for x in api) for t in terms},indent=2),encoding='utf-8')
checks=[]
def ck(n,b):
 assert b,n
 checks.append(dict(name=n,passed=True))
for t in ['0x06000567','0x060005E0','0x06000557','0x0600041B']:
 ck(t+' has no global direct or MethodSpec caller',not any(c['target']==t for c in expanded));ck(t+' not event reachable',t not in reached)
ck('KML processed IL consists of ret', 'IL_0000: ret' in (E/'processed/0x0600056D.il.txt').read_text())
ck('KML bound button8',any(e['control_name']=='button8' and e['handler_tokens']=='0x0600056D' for e in events))
ck('Evaluate prompt bound',any(e['control_name']=='buttonEvl' and e['handler_tokens']=='0x06000566' for e in events))
ck('B4 parameter database loader reachable','0x06000571' in reached)
ck('B4 drawing extended model reachable','0x060005DF' in reached)
ck('Shared OAS evaluator not B4 event reachable','0x0600041B' not in reached)
ck('No direct core P793 call',not any(c['caller'] in core and c['target']=='0x06000793' for c in expanded))
ck('No direct core Spiral constructor',not any(c['caller'] in core and c['target'] in ['0x060007A0','0x060007A1'] for c in expanded))
ck('No event path to P793','0x06000793' not in reached)
ck('No event path to Spiral constructors',not {'0x060007A0','0x060007A1'} & reached)
(O/'static-tests.json').write_text(json.dumps(dict(layer='event/reachability',checks=checks,scope='whole-assembly calls and metadata; no target runtime'),ensure_ascii=False,indent=2),encoding='utf-8')
print('core',len(core),'generic resolutions',len(res),'references',len(refs),'checks',len(checks))
