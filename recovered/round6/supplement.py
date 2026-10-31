from pathlib import Path
import csv,json,re,hashlib,sys
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round6';A=ROOT/'recovered/B3-RnpApch';E=A/'evidence';R=ROOT/'reverse-analysis'
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(n,rs):
 if not rs:return
 with (E/n).open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
ms={x['processed_token']:x for x in rows(E/'method-index.csv')};
for t,ln in [('0x06000593',65895),('0x060005ED',72445)]:
 ms[t]['source']='03_recovered-src/annotated-strings/--/--.cs';ms[t]['line']=str(ln)
 ss=(R/ms[t]['source']).read_text(encoding='utf-8').splitlines();a=ln-1;indent=re.match(r'\s*',ss[a])[0];b=next(j for j in range(a+1,len(ss)) if ss[j]==indent+'}')
 (E/('methods/'+t+'.source.txt')).write_text('\n'.join(f'{i+1}: {ss[i]}' for i in range(a,b+1)),encoding='utf-8')
out('method-index.csv',list(ms.values()))
calls=rows(R/'05_callgraph/static-sites.csv');events=rows(E/'events.csv');controls=rows(E/'controls.csv')
sys.path.insert(0,str(R/'tools/python'));import dnfile
pe=dnfile.dnPE(str(R/'02_deobfuscated/WindSpiralBasic.methods-only.dll'))
res=[]
for i,m in enumerate(pe.net.mdtables.MethodSpec.rows):
 t='0x2B%06X'%(i+1);target=m.Method.row_index;kind=type(m.Method.row).__name__;dest=('0x06%06X'%target if kind=='MethodDefRow' else '0x0A%06X'%target)
 for c in calls:
  if c['caller'] in ms and c['target']==t:res.append(dict(caller=c['caller'],offset=c['il_offset'],methodspec=t,resolved=dest,table=kind,instantiation=m.Instantiation.value.hex()))
pe.close();out('methodspec-resolution.csv',res)
expanded=calls+[dict(c,caller_name='',il_offset=c['offset'],opcode='resolved-MethodSpec',target=c['resolved'],target_name='') for c in res]
adj={}
for c in expanded:
 if c['opcode'] in ('call','callvirt','newobj','resolved-MethodSpec'):adj.setdefault(c['caller'],set()).add(c['target'])
roots={e['handler_tokens'] for e in events};reached=set(roots);todo=list(roots)
while todo:
 for dest in adj.get(todo.pop(),[]):
  if dest.startswith('0x06') and dest not in reached:reached.add(dest);todo.append(dest)
reachable=[dict(processed_token=t,original_token=m['original_token'],name=m['name'],bound_handler=t in roots,reachable_from_bound_event=t in reached,incoming_count=len([c for c in expanded if c['target']==t])) for t,m in ms.items() if m['scope']=='B3 core']
out('reachability.csv',reachable)
(E/'event-reachability.json').write_text(json.dumps(dict(roots=sorted(roots),reachable=sorted(reached),methodspec=res),ensure_ascii=False,indent=2),encoding='utf-8')
graph=['digraph B3 {','rankdir=LR;']
for e in events:graph.append('"'+e['control_name']+'.'+e['event']+'" -> "'+e['handler_tokens']+'";')
core={t for t,m in ms.items() if m['scope']=='B3 core'}
for c in expanded:
 if c['caller'] in core and c['target'] in ms:graph.append('"'+c['caller']+'" -> "'+c['target']+'" [label="'+c['il_offset']+' '+c['opcode']+'"];')
for t in ['0x06000594','0x060005EE']:graph.append('"'+t+'" [color=red,label="'+t+' orphan evaluator"];')
graph.append('}');(E/'callgraph.dot').write_text('\n'.join(graph),encoding='utf-8')
# Every source reference to each named control, partitioned by containing source method.
source=(E/'_008B_008C.source.txt').read_text(encoding='utf-8').splitlines();positions=sorted((int(m['line']),t) for t,m in ms.items() if m['line'] and '\\--\\--.cs' in m['source'] and 46494<=int(m['line'])<=52120)
refs=[]
for c in controls:
 for l in source:
  ln,txt=l.split(':',1)
  if re.search(r'(?<!\w)'+re.escape(c['field'])+r'(?!\w)',txt):
   tok=next((t for n,t in reversed(positions) if n<=int(ln)),'declaration');refs.append(dict(control=c['control_name'],field=c['field'],method=tok,line=ln,source=txt.strip()))
out('control-references.csv',refs)
# Audit all connection-related APIs in selected IL, including absence, rather than infer clipping.
terms=['IntersectWith','Offset','Polyline','Arc','Circle','Tangent','Intersect','Envelope','Clip','Extend','XData','GetPoint','GetEntity','GetSelection','SelectAll','Erase','AddVertexAt','AppendEntity','BlockReference','Group']
api=[]
for p in sorted((E/'processed').glob('*.txt')):
 for line in p.read_text(encoding='utf-8').splitlines():
  for term in terms:
   if term.lower() in line.lower() and line.startswith('IL_'):api.append(dict(method=p.name.split('.')[0],keyword=term,classification=('clipboard, not clipping' if term=='Clip' and 'Clipboard' in line else 'UI GroupBox, not CAD Group' if term=='Group' and 'GroupBox' in line else 'API lexical candidate; see IL target'),IL=line))
out('connection-api-sites.csv',api)
(E/'connection-api-coverage.json').write_text(json.dumps({t:sum(x['keyword']==t for x in api) for t in terms},indent=2),encoding='utf-8')
# The normalized cache is already frozen; use it read-only and independently hash the original PDF.
std=json.loads((ROOT/'recovered/round5/standard-pages.json').read_text(encoding='utf-8'));pdf=ROOT/std['path'];actual=hashlib.sha256(pdf.read_bytes()).hexdigest();assert actual==std['sha256']
sel=[x for x in std['pages'] if 499<=x['pdf_page']<=519]
(E/'standard-excerpts.json').write_text(json.dumps(dict(path=std['path'],sha256=actual,normalization=std['normalization'],pages=sel),ensure_ascii=False,indent=2),encoding='utf-8')
(E/'standard-excerpts.txt').write_text('\n\n'.join('PDF PAGE '+str(x['pdf_page'])+'\n'+x['text'] for x in sel),encoding='utf-8')
# Evidence assertions about dispatch and whole-list conversion, not UI runtime tests.
checks=[]
def check(n,b):
 assert b,n;checks.append(dict(name=n,passed=True))
def tok(n):return '0x06000'+n
for name,t in [('button3','476'),('buttonAix','478'),('button6','47C'),('button2','483'),('button4','47A'),('button15','489'),('button13','48A')]:check(name+' binding',any(e['control_name']==name and e['handler_tokens']==tok(t) for e in events))
inc=json.loads((E/'all-incoming.json').read_text(encoding='utf-8'))
for t in ['594','5EE','470','471','4B3','4B9','4BA']:
 check(t+' no global direct incoming',not inc[tok(t)]['incoming']);check(t+' no global IL references',not inc[tok(t)]['nonheader_il_references']);check(t+' unreachable from bound event',tok(t) not in reached)
check('LNAV factory is reachable',tok('47D') in reached)
check('SelectAll MethodSpec resolved',any(x['caller']==tok('476') and x['resolved']=='0x0600010D' for x in res))
s=(E/'methods/0x06000478.source.txt').read_text(encoding='utf-8');check('conversion iterates whole obstacle list','foreach (DBPoint item in _0088_009D_0087)' in s and 'Take(' not in s);check('conversion preserves original Z','new _008A_008B(obj2)' in s and 'obj4.Z =' not in s)
check('no category change event',not any(e['event']=='SelectedIndexChanged' for e in events));check('no tab change binding',not any('Selected' in e['event'] for e in events))
check('no direct Take on B3 core',not any(c['caller'] in core and '::Take' in c['target_name'] for c in calls))
check('no B3 spiral construction',not any(c['caller'] in core and c['opcode']=='newobj' and c['target'] in ['0x060007A0','0x060007A1'] for c in calls))

for field in ['_0089_0088_009C','_0089_0088_008C','_0089_0088_0094','_0089_0088_009A']:
 check('APV factory does not read '+field,not any(x['field']==field and x['method']=='0x06000470' for x in refs))
for val in [30,60,120]:
 check('DH='+str(val)+' cannot feed APV factory through its disconnected control',not any(x['field']=='_0089_0088_009C' and x['method'] in ['0x06000470','0x0600047D'] for x in refs))
check('Group has no description setter','set_Description' not in (E/'processed/0x06000087.il.txt').read_text(encoding='utf-8'))
frozen=json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8'))
key=[x for x in frozen if x['path'] in ['WsTools-master\\WindSpiral2026\\WindSpiralBasic.dll','reverse-analysis\\02_deobfuscated\\WindSpiralBasic.methods-only.dll',std['path']] or x['path'].endswith('WindSpiral2026\\config.xml')]
(E/'input-provenance.json').write_text(json.dumps(dict(workspace=str(ROOT),baseline='../round6/frozen-inputs.json',files=key,all_frozen_files=len(frozen)),ensure_ascii=False,indent=2),encoding='utf-8')
(O/'fixtures/static-applicability.json').write_text(json.dumps(dict(DH_values=[30,60,120],DH_effect='No factory reader; static only',LNAV_categories='A/B/C/D not consumed by LNAV factory',left_right_turn='Not implemented: no branch/turn geometry; no synthetic fixture',APV_SOC='No DH-HL pipeline; caller-specified length only',source='static-tests.json, control-references.csv, direct-calls.csv'),ensure_ascii=False,indent=2),encoding='utf-8')

(O/'static-tests.json').write_text(json.dumps(dict(layer='event/reachability',assertions=checks,scope='static metadata/IL and source; no original UI execution'),ensure_ascii=False,indent=2),encoding='utf-8')
print('static assertions',len(checks),'resolved generic calls',len(res),'control references',len(refs),'API sites',len(api))

