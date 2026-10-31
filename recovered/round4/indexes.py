"""Build A6 audit indices using existing static evidence only."""
from pathlib import Path
import csv,re,json,hashlib
ROOT=Path(__file__).resolve().parents[2];R=ROOT/'reverse-analysis';A=ROOT/'recovered/A6-Template';E=A/'evidence';O=ROOT/'recovered/round4'
def rows(p):
 with p.open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
def save(p,r):
 if not r:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(r[0]));w.writeheader();w.writerows(r)
methods=rows(E/'methods.csv');meta={m['processed_token']:m for m in methods};calls=rows(E/'calls.csv');loc=rows(R/'04_type-map/method-source-locations.csv')
arity={m['Token']:int(m['ParameterCount']) for m in rows(E/'signatures.csv') if m['Tier']=='processed'}
src=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
def enc(s):return re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
# Include constructor/static-initializer declarations missing from the older map.
decls={}
for p in E.glob('_*.source.txt'):
 cls=p.stem.split('.')[0]; ds=[]
 for line in p.read_text(encoding='utf-8').splitlines():
  n,body=line.split(': ',1)
  if not re.match(r'^\t\t(?:public|private|internal|protected|static) [^\n]*\(',body):continue
  mm=re.search(r'(\w+)\(',body)
  if not mm:continue
  name=mm[1]; pn=('.cctor' if body.startswith('\t\tstatic ') else '.ctor') if name==cls else enc(name)
  ms=[m for m in methods if m['name'].split('::')[0].split('.')[-1]==enc(cls) and m['name'].split('::')[1]==pn]
  params=body.split('(',1)[1].rsplit(')',1)[0];argc=0 if not params.strip() else len(params.split(','))
  ms=[m for m in ms if arity[m['processed_token']]==argc]
  ds.append(dict(line=n,method=name,tokens=';'.join(m['processed_token'] for m in ms)))
 decls[cls]=ds
def methodat(n,cls=None):
 if cls in decls:
  ds=[x for x in decls[cls] if int(x['line'])<=n]
  return max(ds,key=lambda x:int(x['line'])) if ds else {}
 ls=[x for x in loc if x['source'].endswith('--\\--.cs') and int(x['line'])<=n and (cls is None or x['class']==cls)]
 return max(ls,key=lambda x:int(x['line'])) if ls else {}
def fmt(t):
 m=meta.get(t,{})
 return f"{t} / {m.get('original_token','external')} / original RVA {m.get('original_rva','n/a')}"
control=rows(E/'controls.csv');events=rows(E/'events.csv');shared=rows(E/'shared-turn-events.csv')
lines=['# A6 事件图','', '证据等级：绑定来自反编译初始化器；token/RVA 来自程序集元数据索引；IL 调用见 evidence/calls.csv。表中 token 均标明 processed/original，不将 UI 名称视为独立业务算法。','',
'```mermaid','flowchart TD','  A[FormTemplate] --> R[P356 → shared reader P854 → P793]','  A --> H[P364 Holding / Racetrack共用页面]','  A --> B[P35F Base Turn]','  A --> P[P35D 45/180]','  A --> Q[P35B 80/260]','  A --> E[P367 Envelope 实体选择]','  H --> HH[P3AB / Spiral88]','  B --> BB[P1ED / P1F0 / Spiral88]','  P --> PP[P452 / Spiral86]','  Q --> QQ[P45E / Spiral86]','  E --> EH[P368 / P369 点集包络]','```','',
'## 业务入口与未绑定代码','',
'等待/直角航线页只有 buttonHolding，未找到独立 Racetrack CAD 按钮、事件或模式开关；相同页面标题不能证明存在两套实现。普通 Holding 不使用等待页设施和台高构造容差；全向 Holding 才由 P378 读取这些字段。','',
'Base Turn MOC=300 只在未绑定 P363 障碍物评价方法读取，不进入当前已绑定几何链。P36A 是未绑定 Region 合并方法，P367 才是两个 Envelope 按钮的已绑定处理器。不得把 P36A 的 Union 行为归入 P367。','']
for e in events+shared:
 t=e['handler_tokens'];m=meta[t];cs=[c for c in calls if c['caller']==t]
 lines+=['## '+('嵌入公共控件 / ' if e in shared else '')+e['control_name']+'.'+e['event'],'',
 f"Handler `{e['handler']}`; {fmt(t)}; processed RVA {m['processed_rva']}; source line {m['line'] or 'constructor map'}; binding line {e['line']}.",'',
 '| Direct callee (processed) | Name | IL sites |','|---|---|---|']
 for target in dict.fromkeys(c['target'] for c in cs):
  same=[c for c in cs if c['target']==target];lines.append('| '+target+' | `'+same[0]['target_name']+'` | '+', '.join(c['il_offset'] for c in same)+' |')
 cad=[c['target_name'] for c in cs if 'Autodesk.' in c['target_name']]
 lines+=['','CAD API（直接）：'+('；'.join(dict.fromkeys(cad)) if cad else '无；共用拾点/写入通过 P358/P359/P35A 或共享 writer 间接发生。'),'']
(A/'event-map.md').write_text('\n'.join(lines),encoding='utf-8')
reads=[]
for ctrl in control+rows(E/'shared-turn-controls.csv'):
 cls=ctrl['class'];field=ctrl['field'];a=next(i for i,l in enumerate(src) if re.search(r'class '+cls+r'(?:\s|:|$)',l));b=next(i for i in range(a+1,len(src)) if src[i]=='\t}')
 for i in range(a,b+1):
  if field not in src[i] or '.Name = ' in src[i]:continue
  ma=methodat(i+1,cls);token=ma.get('tokens','');
  reads.append(dict(Control=ctrl['control_name'],Field=field,SourceLine=i+1,Method=ma.get('method','constructor/field'),Token=token,Expression=src[i].strip(),Category='initialization' if ma.get('method') in ['_0087_009B_008F','_008B_008C_0095'] else 'reference (read/write classification in expression)'))
save(E/'control-references.csv',reads)
# Every business branch statement, not a normalized re-interpretation.
branches=[];geom=['_0088_0091','_0089_0098','_0089_009A','_0089_009C','_008B_0086','_008B_0088']
for cls in geom:
 text=(E/(cls+'.source.txt')).read_text(encoding='utf-8').splitlines()
 for l in text:
  no,body=l.split(': ',1)
  if re.search(r'\b(if|while|for|switch)\s*\(',body):
   ma=methodat(int(no),cls);branches.append(dict(Class=cls,Method=ma.get('method','constructor'),Token=ma.get('tokens',''),Line=no,Predicate=body.strip(),Evidence='decompilation; original and processed IL indexed'))
save(E/'conditions.csv',branches)
# Actual source assignment + all observed field uses; neutral point names only.
cls='_0088_0091';text=(E/(cls+'.source.txt')).read_text(encoding='utf-8').splitlines();fields=[]
for l in text:
 mm=re.search(r'public _008F_008E (\w+);',l)
 if mm:fields.append(mm[1])
cp=[]
for idx,f in enumerate(fields,1):
 for l in text:
  no,body=l.split(': ',1)
  if re.match(r'\s*'+f+r' = ',body):
   ma=methodat(int(no),cls);uses=[q.split(': ',1)[0] for q in text if f in q and q!=l and 'public _008F_008E' not in q]
   cp.append(dict(PointName=f'P{idx:02}',OriginalField=f,SourceMethod=ma.get('method','ctor'),ProcessedMethodDef=ma.get('tokens',''),Formula=body.strip(),GeometricMeaning='中性控制点；以公式/用途为准，无源码业务点名',UsedBy='source lines '+','.join(uses),Evidence=f'{cls}.source.txt:{no}; method IL'))
save(A/'base-turn-control-points.csv',cp)
angles=[]
for cls in ['_008B_0086','_008B_0088']:
 for l in (E/(cls+'.source.txt')).read_text(encoding='utf-8').splitlines():
  no,body=l.split(': ',1)
  if 'Math.PI' in body or re.search(r'\d+\.\d+\s*\*\s*_0088_009[8A]_00(?:95|88)',body) or re.search(r', (?:-?\d+\.\d+), (?:-?\d+\.\d+)',body):
   if '//IL_' in body or not '(' in body and '=' not in body:continue
   exprs=re.findall(r'Math.PI(?:\s*[*/]\s*-?\d+(?:\.\d+)?)?(?:\s*/\s*\d+(?:\.\d+)?)?',body)
   degs=re.findall(r'(-?\d+\.\d+)\s*\*\s*_0088_009[8A]_00(?:95|88)',body)
   if not exprs and not degs:exprs=['sampler angle arguments: '+body[body.rfind(', _0088_'):].strip() if ', _0088_' in body else body.strip()]
   ma=methodat(int(no),cls);angles.append(dict(Angle='; '.join(exprs+[v+' degrees' for v in degs]),Method=ma.get('method','ctor/static init'),ProcessedMethodDef=ma.get('tokens',''),Branch='exact branch context in evidence/conditions.csv',UsedFor=body.strip(),Evidence=f'{cls}.source.txt:{no}'))
save(A/'procedure-turn-angle-index.csv',angles)
# CAD and joining/connection index, scoped to A6 form/classes plus their actual primitives.
ops=[]
for cls in ['_0089_0092']+geom+['_008F_0086','_008F_0088','_008F_0090']:
 for l in (E/(cls+'.source.txt')).read_text(encoding='utf-8').splitlines():
  no,body=l.split(': ',1)
  if '//IL_' in body:continue
  if re.search(r'IntersectWith|Offset|Polyline|\bArc\b|\bLine\b|Mirroring|GetSelection|GetEntity|GetPoint|\.Erase\(|XData|BooleanOperation|AddRange|\.Insert\(|\.Add\(|_008B_008B_008[67]\(|_008B_0088_0093\(|_008B_0086_009[35D9]\(|_008A_009E_009[3BE]\(|_008B_008D\(|_008B_008A_009[4589ABC]\(',body):
   ma=methodat(int(no),cls);ops.append(dict(Class=cls,Line=no,Method=ma.get('method','constructor'),Token=ma.get('tokens',''),Code=body.strip(),Evidence='static source/IL; no AutoCAD runtime validation'))
save(A/'connection-and-cad-index.csv',ops)
targets={'0x060007A1','0x060007AD','0x060007AF','0x060007B7','0x060007BE','0x060007C2','0x060007BC','0x060007BD','0x06000793','0x06000854'}
save(O/'shared-template-geometry-sites.csv',[c for c in calls if c['target'] in targets])
# Numeric IL constants and shared primitive calls with raw/processed locator.
key=[]
for m in methods:
 for tier,token in [('processed',m['processed_token']),('raw',m['original_token'])]:
  p=E/(('raw/'+token) if tier=='raw' else token);p=p.with_suffix('.il.txt')
  if not p.exists():continue
  for i,l in enumerate(p.read_text(encoding='utf-8').splitlines(),1):
   if 'ldc.r8' in l or any(t in l for t in targets):key.append(dict(Tier=tier,Method=token,File=str(p.relative_to(A)),FileLine=i,IL=l))
save(E/'key-il-locations.csv',key)
flow=[]
for m in methods:
 p=E/(m['processed_token']+'.il.txt')
 if not p.exists():continue # extern/PInvoke has metadata but no managed body
 for l in p.read_text(encoding='utf-8').splitlines():
  if re.search(r'\b(?:ldfld|ldflda|stfld|ldsfld|stsfld)\b',l):
   flow.append(dict(ProcessedMethodDef=m['processed_token'],OriginalMethodDef=m['original_token'],OriginalRVA=m['original_rva'],IL=l))
save(E/'method-field-flow.csv',flow)
save(E/'method-declarations.csv',[dict(Class=cls,**d) for cls,ds in decls.items() for d in ds])
# Material/input list supplements (does not replace or alter initial frozen manifest).
materials=[]
for p in [ROOT/'doc/航空器运行目视和仪表飞行程序设计规范.pdf',R/'03_recovered-src/annotated-strings/--/--.cs',R/'04_type-map/raw/independent-il.txt',R/'04_type-map/methods-only/independent-il.txt',ROOT/'WsTools-master/WindSpiral2026/WindSpiralBasic.dll',ROOT/'WsTools-master/WindSpiral2026/帮助文件/FormTemplate.html']:
 materials.append(dict(Path=str(p),Size=p.stat().st_size,SHA256=hashlib.sha256(p.read_bytes()).hexdigest(),Handling='read-only'))
save(O/'material-baseline.csv',materials)
print('event entries',len(events)+len(shared),'control references',len(reads),'points',len(cp),'angle expressions',len(angles),'connections',len(ops),'IL key sites',len(key))
