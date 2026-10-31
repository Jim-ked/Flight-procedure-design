"""Round11 read-only evidence collection. No target assembly execution."""
from pathlib import Path
import csv,json,hashlib,sys,re
sys.dont_write_bytecode=True
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2]; O=ROOT/'recovered/round11'; E=O/'evidence'; A=ROOT/'recovered/A7-Departure'; R=ROOT/'reverse-analysis'
E.mkdir(exist_ok=True)
def sha(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  for b in iter(lambda:f.read(1024*1024),b''):h.update(b)
 return h.hexdigest()
def rel(p):return str(p.relative_to(ROOT)).replace('\\','/')
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def dump(p,x):p.write_text(json.dumps(x,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
def out(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
if not (O/'frozen-inputs.json').exists():
 b=[]
 for p in sorted(ROOT.rglob('*')):
  if p.is_file() and O not in p.parents and '.git' not in p.parts:
   b.append(dict(path=rel(p),size=p.stat().st_size,sha256=sha(p)))
 dump(O/'frozen-inputs.json',dict(scope='all existing workspace files except .git and round11; includes every existing A7 file',files=b,count=len(b)))
res=[]
for name in ['public-function-matrix','feature-subcoverage','residual-gap-register','manual-cad-dependencies','protection-connection-master','help-ui-code-consistency','next-action-ranking']:
 p=ROOT/'recovered/system-coverage'/(name+'.csv')
 for i,r in enumerate(rows(p),2):
  if 'A7' in str(r):res.append(dict(source=rel(p),row=i,source_sha256=sha(p),original_row=json.dumps(r,ensure_ascii=False)))
out(O/'residual-gap-input.csv',res)

old=json.loads((A/'evidence/methods.json').read_text(encoding='utf-8'))
proc={m['token']:m for m in rows(R/'04_type-map/methods-only/methods.csv')}
mapping={m['processed_token']:m['original_token'] for m in rows(R/'04_type-map/tool-token-map.csv') if m['kind']=='Method'}
raw={m['token']:m for m in rows(R/'04_type-map/raw/methods.csv')}
loc=rows(R/'04_type-map/method-source-locations.csv')
events=rows(A/'evidence/events.csv');controls=rows(A/'evidence/controls.csv'); core={m['processed_token'] for m in old}
form_tokens={m['processed_token'] for m in old if m['name'].split('::')[0]=='\\x89\\x87.\\x89\\x86'}
# Pure metadata read to resolve generic call targets. Does not load the DLL into CLR.
sys.path.insert(0,str(R/'tools/python'));import dnfile
pe=dnfile.dnPE(str(R/'02_deobfuscated/WindSpiralBasic.methods-only.dll'))
spec={}
for i,m in enumerate(pe.net.mdtables.MethodSpec.rows):spec['0x2B%06X'%(i+1)]=('0x06' if type(m.Method.row).__name__=='MethodDefRow' else '0x0A')+'%06X'%m.Method.row_index
pe.close()
calls=rows(R/'05_callgraph/static-sites.csv');resolved=[]
for c in calls:
 d=dict(c);d['unresolved_target']=c['target'];d['target']=spec.get(c['target'],c['target']);resolved.append(d)
adj={}
for c in resolved:
 if c['target'].startswith('0x06'):adj.setdefault(c['caller'],set()).add(c['target'])
roots={e['handler_tokens'] for e in events}; reach=set(roots);todo=list(roots)
while todo:
 for t in adj.get(todo.pop(),set()):
  if t not in reach:reach.add(t);todo.append(t)
selected=core|reach|{'0x06000063','0x06000087','0x06000089','0x060000AC','0x060000AD','0x06000793'}
all_methods=[]
for t in sorted(selected):
 if t not in mapping:continue
 m=proc[t];rw=raw[mapping[t]];ls=next((x for x in loc if t in x['tokens'].split(';')),None)
 all_methods.append(dict(processed_token=t,original_token=mapping[t],processed_rva=m['rva'],original_rva=rw['rva'],name=m['name'],processed_status=m['status'],original_status=rw['status'],scope='A7 Form' if t in form_tokens else ('A7 business' if t in core else 'shared dependency/command'),event_reachable=t in reach,source=ls['source'] if ls else '',source_line=ls['line'] if ls else '',processed_il_sha256=m['il_sha256'],original_il_sha256=rw['il_sha256']))
out(E/'method-index.csv',all_methods)
out(E/'resolved-calls.csv',[c for c in resolved if c['caller'] in selected])
out(E/'global-core-incoming.csv',[c for c in resolved if c['target'] in core])
dump(E/'reachability.json',dict(form_class='_0089_0086 / FormDepartureEvl',form_methods=sorted(form_tokens),core_methods=sorted(core),event_roots=sorted(roots),event_reachable=sorted(reach),methodspec_resolution=spec,scope='Static direct/callvirt/newobj/ldftn edges and MethodSpec targets; no reflective/external or native host dispatch inference'))
out(E/'events.csv',[dict(e,original_token=mapping[e['handler_tokens']],processed_rva=proc[e['handler_tokens']]['rva'],original_rva=raw[mapping[e['handler_tokens']]]['rva']) for e in events])
out(E/'controls.csv',controls)
# New IL excerpts retain both token systems; do not modify Round2 evidence.
for tier,key,directory in [('methods-only','processed_token','processed'),('raw','original_token','raw')]:
 target=E/directory;target.mkdir(exist_ok=True)
 text=(R/'04_type-map'/tier/'independent-il.txt').read_text(encoding='utf-8')
 chunks=re.split(r'(?=^METHOD )',text,flags=re.M)
 wanted={m[key] for m in all_methods}
 for ch in chunks:
  mt=re.match(r'METHOD ([0-9A-Fa-f]{8})',ch)
  if mt and '0x'+mt[1] in wanted:(target/('0x'+mt[1]+'.il.txt')).write_text(ch,encoding='utf-8')
dump(E/'provenance.json',[dict(path=rel(p),absolute_path=str(p),sha256=sha(p)) for p in [ROOT/'WsTools-master/WindSpiral2026/WindSpiralBasic.dll',R/'02_deobfuscated/WindSpiralBasic.methods-only.dll',ROOT/'WsTools-master/WindSpiral2026/config.xml',ROOT/'WsTools-master/WindSpiral2026/帮助文件/FormDepartureEvl.html',ROOT/'doc/航空器运行目视和仪表飞行程序设计规范.pdf']])
print(json.dumps(dict(baseline=json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8'))['count'],methods=len(all_methods),core=len(core),form=len(form_tokens),events=len(events),roots=len(roots),reachable=len(reach)),ensure_ascii=False))
