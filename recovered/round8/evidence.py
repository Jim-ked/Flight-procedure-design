"""Round 8 evidence assembly and static assertions; read-only source/PE inspection."""
from pathlib import Path
import sys,csv,re,json,hashlib
ROOT=Path(__file__).resolve().parents[2];R=ROOT/'reverse-analysis';A=ROOT/'recovered/A5-PrecisionApproach';E=A/'evidence';O=ROOT/'recovered/round8'
sys.stdout.reconfigure(encoding='utf-8');sys.path.insert(0,str(R/'tools/python'));import dnfile
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
ms={m['processed_token']:m for m in rows(E/'method-index.csv')}
for m in rows(E/'recovery-method-map.csv'):
 if not ms[m['processed_token']]['line'] and m['source_line']:
  v=ms[m['processed_token']];v['line']=m['source_line'];v['source']=m['source']
  ss=(R/m['source']).read_text(encoding='utf-8').splitlines();a=int(m['source_line'])-1;indent=re.match(r'\s*',ss[a])[0];b=next(i for i in range(a+1,len(ss)) if ss[i]==indent+'}')
  (E/('methods/'+m['processed_token']+'.source.txt')).write_text('\n'.join(f'{i+1}: {ss[i]}' for i in range(a,b+1)),encoding='utf-8')
out(E/'method-index.csv',list(ms.values()))
headers=[];pe=dnfile.dnPE(str(R/'02_deobfuscated/WindSpiralBasic.methods-only.dll'))
for t,m in ms.items():
 rva=int(m['processed_rva'],16)
 if not rva:continue
 b=pe.get_data(rva,12);kind=b[0]&3;flags=int.from_bytes(b[:2],'little') if kind==3 else 0
 headers.append(dict(token=t,header='fat' if kind==3 else 'tiny',InitLocals=bool(flags&16),LocalVarSigTok='0x%08X'%int.from_bytes(b[8:12],'little') if kind==3 else 'none'))
native=[]
for im in pe.net.mdtables.ImplMap.rows:
 if im.MemberForwarded.row_index==0x305:native.append(dict(token='0x06000305',module=str(im.ImportScope.row.Name),entry=str(im.ImportName),flags=str(im.MappingFlags)))
pe.close();out(E/'method-header-flags.csv',headers);(E/'native-import.json').write_text(json.dumps(native,indent=2),encoding='utf-8')
hd={x['token']:x for x in headers}
for m in rows(E/'recovery-method-map.csv'):
 if hd.get(m['processed_token'],{}).get('LocalVarSigTok') not in ['0x00000000','none',None]:assert hd[m['processed_token']]['InitLocals'],m
events=rows(E/'events.csv');calls=rows(E/'direct-calls.csv');incoming=rows(E/'resolved-global-incoming.csv');reach=json.loads((E/'event-reachability.json').read_text());reached=set(reach['reachable'])
for e in events:
 m=ms[e['handler_tokens']];e.update(original_token=m['original_token'],original_rva=m['original_rva'],processed_rva=m['processed_rva'],direct_callees=';'.join(c['target'] for c in calls if c['caller']==e['handler_tokens']),reachability='reachable')
out(E/'event-identities.csv',events)
# Control properties (designer vs runtime) and exact reader/writer expressions.
state=rows(E/'control-state.csv');refs=rows(E/'control-references.csv');inv=[]
for c in rows(E/'controls.csv'):
 x=dict(c)
 for prop in ['Text','Enabled','Visible','ReadOnly','Checked']:
  x['designer_'+prop]=';'.join(y['value'] for y in state if y['field']==c['field'] and y['property']==prop and int(y['line'])>=25600) or 'framework default / no explicit assignment'
 x['consumers']=';'.join(sorted({y['method'] for y in refs if y['field']==c['field'] and int(y['line'])<25600}))
 inv.append(x)
out(E/'parameter-control-inventory.csv',inv)
meaning={'0x060007E5':'line X(y)','0x060007E6':'line Y(x)','0x060007E7':'line through two points','0x060007E8':'line through point and angle','0x060007ED':'line intersection','0x060007EE':'line angle','0x0600080D':'mirror Y','0x0600080E':'mirror Z','0x0600081F':'symmetric closed point list','0x06000821':'rotate paths','0x06000823':'translate paths','0x06000827':'clear nested paths Z','0x06000838':'plane-plane intersection line','0x06000839':'plane fixed-height contour line','0x0600083A':'plane through three points'}
out(E/'connection-semantic-calls.csv',[dict(c,meaning=meaning[c['target']]) for c in calls if c['target'] in meaning])
terms=['ScreenData','Evaluate','Mark','Highlight','HL','OCA','OCH','DA','DH','RVR','WsOasPara','Process','ShellExecute','FAF','FAP','GetPoint','GetEntity','GetSelection','SelectAll','XData']
search=[]
for p in E.glob('*.source.txt'):
 for line in p.read_text(encoding='utf-8').splitlines():
  code=line.split(':',1)[-1]
  for term in terms:
   if re.search(r'(?<![A-Za-z])'+re.escape(term)+r'(?![A-Za-z])',code,re.I):search.append(dict(file=p.name,term=term,source=line))
out(E/'business-term-search.csv',search)
allcalls=rows(R/'05_callgraph/static-sites.csv');process=[dict(c,reachable_from_A5=c['caller'] in reached) for c in allcalls if 'System.Diagnostics.Process::' in c['target_name'] or 'ShellExecute' in c['target_name']]
out(E/'global-process-calls.csv',process)
# Normalize IL names only to compare copied loaders; retain complete originals separately.
pairs=[('409','571','loader'),('40A','572','decoder'),('40B','573','size'),('40C','574','RDH')];comparison=[]
for a,b,role in pairs:
 pa=E/('processed/0x06000'+a+'.il.txt');pb=ROOT/('recovered/B4-PbnIls/evidence/processed/0x06000'+b+'.il.txt')
 sa=pa.read_text(encoding='utf-8');sb=pb.read_text(encoding='utf-8');sql=lambda s: re.findall(r'SELECT[^\n]*',s)
 comparison.append(dict(component=role,A5='P'+a,B4='P'+b,classification='Same database schema but copied loader' if role=='loader' else 'Copied implementation',same_methoddef=False,A5_original=ms['0x06000'+a]['original_token'],A5_original_RVA=ms['0x06000'+a]['original_rva'],B4_original='0x06000'+format(int(b,16)+1,'03X'),query='SELECT Value FROM PartA/PartB WHERE ID = @id' if role=='loader' else 'N/A',key_or_formula='(GP+modeInteger+CG).Replace(dot,empty); rounded integer LOC appended; no interpolation' if role=='loader' else 'compare E2 recovered assignments and cross-module E3 fixtures',post_processing='P30A: P409->P40B->P40C->P412->P30B(F6/F2)' if role=='loader' else 'same arithmetic; separate MethodDef',A5_sha256=hashlib.sha256(sa.encode()).hexdigest(),B4_sha256=hashlib.sha256(sb.encode()).hexdigest()))
out(O/'a5-b4-database-comparison.csv',comparison)
checks=[]
def ck(name,b):
 assert b,name
 checks.append(dict(name=name,passed=True))
for t in ['0x0600041B','0x06000429','0x060003A7']:
 ck(t+' no global direct/MethodSpec incoming',not any(c['target']==t for c in incoming));ck(t+' not event reachable',t not in reached)
for t in ['0x06000306','0x06000307','0x06000409','0x06000412','0x0600039E','0x06000427','0x06000437','0x06000443','0x06000087','0x06000319','0x0600031A']:
 ck(t+' event reachable',t in reached)
ck('No B4 extended geometry constructor reachable','0x060005DD' not in reached)
ck('No B4 private loader reachable','0x06000571' not in reached)
ck('No process start reachable',not any(c['reachable_from_A5'] for c in process if c['target_name'].endswith('::Start') or 'ShellExecute' in c['target_name']))
ck('A5 six radio controls',sum('radioButton' in c['control_name'] for c in inv)==6)
ck('No evaluator controls',not any(re.search('Evl|Evalu|Screen|Mark|Highlight|OCA|OCH|HLm|HLr',c['control_name'],re.I) for c in inv))
ck('A5 native activation import inspected',len(native)==1)
ck('All original event identities known',all(e['original_token'] and e['original_rva'] for e in events))
ck('Database fixture copied byte-identically', (O/'fixtures/database-rows.tsv').read_bytes()==(ROOT/'recovered/round7/fixtures/database-rows.tsv').read_bytes())
ck('All recovered methods with locals have InitLocals',all(hd[m['processed_token']]['InitLocals'] for m in rows(E/'recovery-method-map.csv') if hd.get(m['processed_token'],{}).get('LocalVarSigTok') not in ['0x00000000','none',None]))
# Exact key constants sourced from decoded strings / processed bodies, not IL offset numbers.
for code,needle in [('00319','RUNWAY:'),('00319','|APPROACH:'),('00319','|PAOAS:'),('00319','|OAS:'),('00307','(num2 - num4) / num3'),('00307','_0087_0092_0090.X + num')]:
 ck('source '+code+' '+needle,needle in (E/('methods/0x060'+code+'.source.txt')).read_text(encoding='utf-8'))
(O/'static-tests.json').write_text(json.dumps(dict(layer='event/reachability',checks=checks,execution='metadata/IL/source only; no target runtime'),ensure_ascii=False,indent=2),encoding='utf-8')
print('event identities',len(events),'InitLocals',len(headers),'static checks',len(checks),'native',native)
