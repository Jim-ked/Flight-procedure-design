"""A6 closure tables: only static metadata and previously recorded calls."""
from pathlib import Path
import csv,json,re,hashlib,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round4';A=ROOT/'recovered/A6-Template';E=A/'evidence';R=ROOT/'reverse-analysis'
def read(p):
 with p.open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
def save(p,rs):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
proc={m['token']:m for m in read(R/'04_type-map/methods-only/methods.csv')};raw={m['token']:m for m in read(R/'04_type-map/raw/methods.csv')};mp={m['processed_token']:m['original_token'] for m in read(R/'04_type-map/tool-token-map.csv') if m['kind']=='Method'}
calls=read(E/'calls.csv');allcalls=read(R/'05_callgraph/static-sites.csv');methods=read(E/'methods.csv')
# Supplement prior frozen writer table, without changing it.
W=E/'writers';(W/'raw').mkdir(parents=True,exist_ok=True);wr=[]
for t in ['0x06000086','0x06000087','0x06000089']:
 m=proc[t];old=mp[t];wr.append(dict(Processed=t,Original=old,OriginalRVA=raw[old]['rva'],ProcessedRVA=m['rva'],Name=m['name'],RawStatus=raw[old]['status'],ProcessedStatus=m['status']))
save(W/'methods.csv',wr);save(W/'calls.csv',[c for c in allcalls if c['caller'] in {m['Processed'] for m in wr}])
adapter={'Place':['0x06000359','0x0600035A'],'Add':['0x06000089'],'Group':['0x06000087'],'Holding':['0x06000364'],'BaseTurn':['0x0600035F'],'Procedure45180':['0x0600035D'],'Procedure80260':['0x0600035B'],'HoldingTolerance':['0x06000378'],'OmniOuter':['0x06000379'],'HoldingLabel':['0x06000364','0x06000365'],'Omni':['0x06000377'],'XE':['0x06000375'],'YE':['0x06000376'],'EnvelopeOutput':['0x06000367']}
save(E/'cad-adapter-method-map.csv',[dict(AdapterMethod=name,Processed=t,Original=mp[t],OriginalRVA=raw[mp[t]]['rva'],Evidence='Form source/IL or writers packet',Qualification='independent recording helper derived from these methods; no one-to-one original class identity') for name,ts in adapter.items() for t in ts])
for tier,ts,p,folder in [('processed',{m['Processed'] for m in wr},R/'04_type-map/methods-only/independent-il.txt',W),('raw',{m['Original'] for m in wr},R/'04_type-map/raw/independent-il.txt',W/'raw')]:
 for m in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',p.read_text(encoding='utf-8'),re.M|re.S):
  if '0x'+m[1] in ts:(folder/('0x'+m[1]+'.il.txt')).write_text(m[0],encoding='utf-8')
ss=(R/'03_recovered-src/annotated-strings/-/-.cs').read_text(encoding='utf-8').splitlines()
(W/'writer.source.txt').write_text('\n'.join(str(i+1)+': '+ss[i] for a,b in [(1435,1502),(1578,1655)] for i in range(a-1,b)),encoding='utf-8')
# Public/no-body versus stub-like raw evidence is explicit for every MethodDef.
save(E/'body-provenance.csv',[dict(Processed=m['processed_token'],Original=m['original_token'],RawStatus=raw[m['original_token']]['status'],RawCodeSize=raw[m['original_token']]['code_size'],ProcessedStatus=proc[m['processed_token']]['status'],ProcessedCodeSize=proc[m['processed_token']]['code_size'],SourceLine=m['line'],EvidenceTier='processed deobfuscated IL for body; raw metadata/stub retained') for m in methods])
blocks={'A6 Holding':['0x060003AB','0x060003AC','0x060003AD','0x060003AF'],'A6 XE':['0x060003BF'],'A6 YE':['0x060003CB'],'A6 BaseTurn':['0x060001ED','0x060001EE','0x060001EF','0x060001F0'],'A6 45/180':['0x06000452','0x06000453','0x06000454'],'A6 80/260':['0x0600045E','0x06000460','0x06000461','0x06000463']}
old=read(ROOT/'recovered/round3/shared-turn-spiral-calls.csv')
others={s:{m['target'] for m in old if m['module']==s} for s in dict.fromkeys(m['module'] for m in old)}
relations=[]
for group,cts in blocks.items():
 cc=[c for c in calls if c['caller'] in cts];targets={c['target'] for c in cc}
 for oth,targets2 in others.items():
  shared=sorted(targets&targets2)
  relations.append(dict(Module=group,ComparedWith=oth,Relation='same MethodDef' if shared else 'no relation (direct calls in inventory)',ProcessedMethods=';'.join(shared),OriginalMethods=';'.join(mp[t] for t in shared),Evidence='evidence/calls.csv; frozen round3/shared-turn-spiral-calls.csv',Limit='inventory also contains low-level point helpers; intersection alone does not imply same spiral; P793 transitive for all A6'))
relations += [dict(Module='A6 all bound template readers',ComparedWith='A1/B1/B2 shared turn input',Relation='same MethodDef',ProcessedMethods='0x06000854;0x06000793',OriginalMethods=mp['0x06000854']+';'+mp['0x06000793'],Evidence='P356->P854->P793; shared-template-geometry-sites.csv',Limit='transitive; not each business constructor directly new P793'),dict(Module='A6 Form P359/P35A',ComparedWith='A1/B1/B2 CAD writes',Relation='same MethodDef',ProcessedMethods='0x06000086;0x06000087;0x06000089',OriginalMethods=';'.join(mp[t] for t in ['0x06000086','0x06000087','0x06000089']),Evidence='evidence/writers + A6 direct IL; frozen writer behavior source',Limit='frozen round3 token/name mismatch corrected only in Round4 supplement'),dict(Module='A6 Holding local hull P3B0/P3B1',ComparedWith='A6 Form Envelope P368/P369',Relation='copied implementation',ProcessedMethods='0x060003B0;0x060003B1;0x06000368;0x06000369',OriginalMethods=';'.join(mp[t] for t in ['0x060003B0','0x060003B1','0x06000368','0x06000369']),Evidence='same gift wrapping and orientation source; different point types',Limit='Holding TemplatePoint reference identity; Form uses external Point3d equality'),dict(Module='A6 template builders',ComparedWith='B1/B2 geometry builders',Relation='only same primitive',ProcessedMethods='see preceding MethodDef intersections',OriginalMethods='not a shared business constructor',Evidence='distinct class constructors and field graphs; Round3 frozen analysis',Limit='no unified TemplateEngine; no proof of copied complete template algorithm')]
relations.append(dict(Module='A6 ordinary Holding / BaseTurn',ComparedWith='A1/B1/B2 Spiral86 construction',Relation='no relation',ProcessedMethods='A6 uses 0x060007B7; other modules use 0x060007A1',OriginalMethods=mp['0x060007B7']+';'+mp['0x060007A1'],Evidence='exact newobj targets; shared-template-geometry-sites.csv',Limit='no direct Spiral86 constructor in ordinary Holding/BaseTurn; common point helpers and turn parameters remain'))
save(O/'shared-template-geometry.csv',relations)
branchrows=read(E/'conditions.csv')
save(O/'branch-inventory.csv',[dict(Class=r['Class'],ProcessedMethodDef=r['Token'],Line=r['Line'],Predicate=r['Predicate'],Coverage='structural index; fixture coverage is sampled, not exhaustive branch coverage') for r in branchrows])
fixtures=[]
for p in sorted((O/'fixtures').glob('*.json')):
 data=json.loads(p.read_text(encoding='utf-8'))
 fixtures.append(dict(File=p.name,Bytes=p.stat().st_size,SHA256=hashlib.sha256(p.read_bytes()).hexdigest(),TopLevelKeys=';'.join(data) if isinstance(data,dict) else 'list['+str(len(data))+']',Evidence='recovered execution / bounded observer; no original plugin run'))
save(O/'fixture-index.csv',fixtures)
# Full internal graph is machine-readable calls.csv; this readable graph keeps real token edges.
keep=set(sum(blocks.values(),[]))|{'0x06000356','0x06000358','0x06000359','0x0600035A','0x0600035B','0x0600035D','0x0600035F','0x06000364','0x06000367','0x06000368','0x06000369','0x06000375','0x06000376','0x06000377','0x06000378','0x06000379','0x06000854'}
edges=[c for c in calls if c['caller'] in keep and c['target'].startswith('0x06')]
save(E/'business-callgraph.csv',edges)
md=['# A6 关键调用图','','箭头均为processed MethodDef直接调用；原/处理token、RVA和每个IL offset见 methods.csv / business-callgraph.csv。可读业务图见event-map。以下仅展示主要业务边，其余直接调用留CSV。','','```mermaid','flowchart TD']
keytargets=keep|{'0x06000793','0x060007A1','0x060007AD','0x060007AF','0x060007B7','0x060007BE','0x060007C2','0x06000086','0x06000087','0x06000089','0x060003BD','0x060003C9'}
for a,b in sorted({(c['caller'],c['target']) for c in edges if c['target'] in keytargets}):
 aa=a.replace('0x06000','P');bb=b.replace('0x06000','P');md.append('  '+aa+' --> '+bb)
md+=['```','','不要把相似用途视为同MethodDef。未绑定P36A未加入两个Envelope按钮的链。']
(A/'callgraph.md').write_text('\n'.join(md),encoding='utf-8')
print('writer supplement',len(wr),'relations',len(relations),'fixture files',len(fixtures),'readable graph edges',len(edges))
