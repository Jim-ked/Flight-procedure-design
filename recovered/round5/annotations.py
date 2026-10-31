"""Read metadata signatures, annotate recovery and index semantic condition sites."""
from pathlib import Path
import sys,re,csv,json
ROOT=Path(__file__).resolve().parents[2];E=ROOT/'recovered/B5-PbnDeparture/evidence';A=E.parent;O=ROOT/'recovered/round5'
sys.path.insert(0,str(ROOT/'reverse-analysis/tools/python'))
import dnfile
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,rs):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
ms=rows(E/'method-index.csv');sigs=[];counts={}
def uint(b,i):
 a=b[i]
 if a<128:return a,i+1
 if a<192:return ((a&63)<<8)|b[i+1],i+2
 return ((a&31)<<24)|(b[i+1]<<16)|(b[i+2]<<8)|b[i+3],i+4
for tier,path,key in [('processed','reverse-analysis/02_deobfuscated/WindSpiralBasic.methods-only.dll','processed_token'),('raw','WsTools-master/WindSpiral2026/WindSpiralBasic.dll','original_token')]:
 pe=dnfile.dnPE(str(ROOT/path))
 for m in ms:
  t=m[key];b=pe.net.mdtables.MethodDef.rows[int(t,16)-0x06000001].Signature.value;i=1
  if b[0]&16:_,i=uint(b,i)
  n,i=uint(b,i);sigs.append(dict(tier=tier,token=t,parameter_count=n,signature_hex=b.hex(),evidence=path+' MethodDef.Signature'))
  if tier=='processed':counts[t]=n
 pe.close()
out(E/'signatures.csv',sigs)
classes={'PbnDepartureAltitudeTurn':'_008C_0091','PbnDepartureFlyOver':'_008C_0093','PbnDepartureObstacle':'_008A_0089','StartArea':'_008B_0098','FlyOverPostArea':'_008B_009A','RunwayFrame':'_008E_0097','B5Math':'_008F_008A','FrameHelpers':'_008D'}
def enc(s):return re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
mapping=[];branches=[]
for cls,old in classes.items():
 p=A/(cls+'.Recovered.cs');src=re.sub(r'^[ \t]*// R5 MethodDef:.*\n','',p.read_text(encoding='utf-8'),flags=re.M)
 pattern=r'^(\s*(?:public|private|internal|protected|static) (?:[^\n]*? )?([\w]+)\(([^\n]*)\))\s*\n\s*\{'
 entries=list(re.finditer(pattern,src,re.M));changes=[]
 for j,e in enumerate(entries):
  name=e[2];pars=e[3];n=0 if not pars.strip() else len(re.split(r',\s*(?![^<]*>)',pars))
  method='.ctor' if name==cls else name
  if name==cls and e[1].strip().startswith('static'):method='.cctor'
  cand=[m for m in ms if m['name'].split('::')[0].split('.')[-1]==enc(old) and m['name'].split('::')[-1]==enc(method) and counts[m['processed_token']]==n]
  if len(cand)!=1:raise RuntimeError((p.name,name,n,len(cand)))
  m=dict(cand[0]);at=e.start()+len(e[1])-len(e[1].lstrip())
  if not m['source'] and (E/(old+'.source.txt')).exists():
   srcname=old if method in ['.ctor','.cctor'] else name
   lines=(E/(old+'.source.txt')).read_text(encoding='utf-8').splitlines()
   found=[]
   for l in lines:
    lm=re.match(r'^(\d+):\s*(.*)'+re.escape(srcname)+r'\(([^\n]*)\)',l)
    if not lm:continue
    params=lm[3];numparams=0 if not params.strip() else len(re.split(r',\s*(?![^<]*>)',params))
    if numparams==n and (method!='.cctor' or 'static ' in lm[2]):found.append(lm)
   if len(found)==1:m['source']='03_recovered-src/annotated-strings/--/--.cs';m['line']=found[0][1]
  comment=f'// R5 MethodDef: original {m["original_token"]} RVA {m["original_rva"]}; processed {m["processed_token"]} RVA {m["processed_rva"]}; source {m["source"]}:{m["line"]}; processed IL recovery, not original runtime.\n'
  changes.append((at,comment));mapping.append(dict(file=p.name,method=name,parameter_count=n,processed_token=m['processed_token'],original_token=m['original_token'],original_rva=m['original_rva'],processed_rva=m['processed_rva'],source=m['source'],source_line=m['line']))
  block=src[e.end():entries[j+1].start() if j+1<len(entries) else len(src)];label='entry'
  for line in block.splitlines():
   lm=re.search(r'(IL_[0-9a-fA-F]+):',line)
   if lm:label=lm[1]
   if re.search(r'\b(if|else if|while|throw)\s*\(|\?',line) and 'num = ' not in line:
    branches.append(dict(processed_token=m['processed_token'],original_token=m['original_token'],recovery_file=p.name,nearest_decompiler_label=label,expression=line.strip(),evidence='processed decompilation; corresponding exact opcodes in branch-sites.csv'))
 for at,comment in reversed(changes):src=src[:at]+comment+src[at:]
 p.write_text(src,encoding='utf-8')
out(E/'recovery-method-map.csv',mapping);out(E/'condition-expressions.csv',branches)
# Resolve shared MethodDef intersections from existing indexes; no old output edits.
calls=rows(ROOT/'reverse-analysis/05_callgraph/static-sites.csv');meta={m['processed_token']:m for m in ms}
b5={x['caller'] for x in rows(E/'calls.csv')};b5targets={x['target'] for x in calls if x['caller'] in b5}
for tag,folder in [('a7','A7-Departure'),('b1','B1-FlyBy'),('b2','B2-FlyOverDF')]:
 p=ROOT/('recovered/'+folder+'/evidence/calls.csv')
 if p.exists():oldcalls=rows(p)
 else:oldcalls=[x for x in rows(ROOT/'recovered/round3/shared-turn-spiral-calls.csv') if x['module']==folder]
 if tag in ['b1','b2']:oldcalls += [x for x in rows(ROOT/'recovered/round3/shared-turn-spiral-calls.csv') if x['module']==folder]
 shared=sorted({x['target'] for x in oldcalls}&b5targets)
 rs=[]
 for t in shared:
  if t not in meta:continue
  rs.append(dict(item=meta[t]['name'],classification='Same MethodDef',processed_target=t,original_target=meta[t]['original_token'],original_rva=meta[t]['original_rva'],B5_callers=';'.join(sorted({x['caller'] for x in calls if x['caller'] in b5 and x['target']==t})),other_callers=';'.join(sorted({x['caller'] for x in oldcalls if x['target']==t}))))
 out(O/(tag+'-b5-shared-identities.csv'),rs)
print('annotated',len(mapping),'conditions',len(branches),'signature rows',len(sigs))
