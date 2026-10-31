from pathlib import Path
import csv,re,json,hashlib,sys
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round7';A=ROOT/'recovered/B4-PbnIls';E=A/'evidence';R=ROOT/'reverse-analysis';F=O/'fixtures'
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def out(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
ms={m['processed_token']:m for m in rows(E/'method-index.csv')}
# Fill constructor/cctor locations from independently signature-matched recovery map.
for m in rows(E/'recovery-method-map.csv'):
 if not ms[m['processed_token']]['line'] and m['source_line']:
  v=ms[m['processed_token']];v['line']=m['source_line'];v['source']=m['source']
  ss=(R/m['source']).read_text(encoding='utf-8').splitlines();a=int(m['source_line'])-1;indent=re.match(r'\s*',ss[a])[0];b=next(i for i in range(a+1,len(ss)) if ss[i]==indent+'}')
  (E/('methods/'+m['processed_token']+'.source.txt')).write_text('\n'.join(f'{i+1}: {ss[i]}' for i in range(a,b+1)),encoding='utf-8')
out(E/'method-index.csv',list(ms.values()))
inv=rows(E/'parameter-control-inventory.csv');state=rows(E/'control-state.csv')
for c in inv:
 for prop in ['Enabled','Visible','ReadOnly','Checked']:
  c['designer_'+prop]=';'.join(x['value'] for x in state if x['field']==c['field'] and x['property']==prop and int(x['line'])>=62613) or 'framework default; no explicit designer assignment'
out(E/'parameter-control-inventory.csv',inv)
meanings={'_0088_0091_0096':'W plane','_0088_0091_0097':'W* plane','_0088_0091_0098':'X plane','_0088_0091_0099':'Y plane','_0088_0091_009A':'Z plane','_008A_008B_0090':'W plane','_008A_008B_0091':'X plane','_008A_008B_0092':'Y plane','_008A_008B_0093':'Z plane','_008A_008A_0093':'E / SOC station on 300m cap line','_008A_008A_0094':'L15 at y3704','_008A_008A_0095':'Y/Z seam at y1852','_008A_008A_0096':'same station outer point +30m','_008A_008A_0097':'Y/secondary plane seam at y3704','_008A_008A_0098':'back point x-20000 y1852','_008A_008A_0099':'L15','_008A_008A_009A':'Y/secondary plane seam','_008A_008A_009B':'secondary plane','_008A_008B_0094':'cap300','_008A_008B_0095':'ordered boundary lists'}
flow=rows(E/'field-flow.csv');fields=[]
for cls in ['_008A_0093','_008C_0095']:
 for l in (E/(cls+'.source.txt')).read_text(encoding='utf-8').splitlines():
  mat=re.match(r'(\d+):\s+public ([^=;]+?) (_\w+)(?: = ([^;]+))?;',l)
  if not mat:continue
  ln,typ,name,default=mat.groups();enc=re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),name)
  sites=[x for x in flow if x['field'].split('::')[-1]==enc]
  fields.append(dict(class_name=cls,field=name,type=typ,initial_value=default or 'default',meaning=meanings.get(name,'see point/line construction and source; unused if no sites'),reads=';'.join(x['method']+'@'+x['offset'] for x in sites if x['opcode']!='stfld'),writes=';'.join(x['method']+'@'+x['offset'] for x in sites if x['opcode']=='stfld'),unit='coordinates m / plane A B dimensionless and C m' if typ.startswith('_008F_') else 'mode/count/list or metres; see type and source',source_line=ln))
out(E/'model-fields.csv',fields)
# Remove only obsolete artifacts produced by the early guessed-token index, in the Round 7 evidence dirs.
for folder,key in [('raw','original_token'),('processed','processed_token'),('methods','processed_token')]:
 valid={m[key] for m in ms.values()}
 base=(E/folder).resolve();assert A.resolve() in base.parents
 for p in base.glob('0x*.txt'):
  if p.name.split('.')[0] not in valid:
   assert p.resolve().parent==base
   p.unlink()
# Verify actual PE method headers instead of assuming IL local initialization.
sys.path.insert(0,str(R/'tools/python'));import dnfile
headers=[];pe=dnfile.dnPE(str(R/'02_deobfuscated/WindSpiralBasic.methods-only.dll'))
for t,m in ms.items():
 rva=int(m['processed_rva'],16)
 if not rva:continue
 b=pe.get_data(rva,12);kind=b[0]&3;flags=int.from_bytes(b[:2],'little') if kind==3 else 0
 headers.append(dict(token=t,header='fat' if kind==3 else 'tiny',InitLocals=bool(flags&16),LocalVarSigTok='0x%08X'%int.from_bytes(b[8:12],'little') if kind==3 else 'none'))
pe.close();out(E/'method-header-flags.csv',headers)
sourceflags={x['token']:x for x in headers}
for m in rows(E/'recovery-method-map.csv'):
 if sourceflags.get(m['processed_token'],{}).get('LocalVarSigTok') not in ['0x00000000','none',None]:assert sourceflags[m['processed_token']]['InitLocals'],m
# Semantic geometry-call index catches obfuscated line/plane methods missed by API keyword searches.
meaning={'0x060007E5':'line X(y)','0x060007E6':'line Y(x)','0x060007E7':'line through two points','0x060007E8':'line through point and angle','0x060007ED':'line intersection','0x060007EE':'line angle','0x0600080D':'mirror Y','0x0600081F':'symmetric closed point list','0x06000821':'rotate paths','0x06000823':'translate paths','0x06000827':'clear nested paths Z','0x06000838':'plane-plane intersection line','0x06000839':'plane fixed-height contour line','0x0600083A':'plane through three points'}
out(E/'connection-semantic-calls.csv',[dict(c,meaning=meaning[c['target']]) for c in rows(E/'direct-calls.csv') if c['target'] in meaning])
data=rows(F/'assertions.csv');counts={}
for x in data:counts[x['layer']]=counts.get(x['layer'],0)+1
fixtures=[]
for p in sorted(F.iterdir()):
 if p.is_file() and p.name!='fixture-index.json':fixtures.append(dict(path=p.name,size=p.stat().st_size,sha256=sha(p),role='historical corrected fixture expectation; not a current failure' if p.name=='failure.txt' else 'E3 input/output or original row fixture'))
app=dict(arbitrary_left_right_turn='N/A: no original controls/branch/geometry',small_large_turn_angles='N/A: no original turn angle input',zero_configurable_width='N/A: widths are literal1852/3704; zero plane B tested',KML_regions='N/A: original handler nop/ret; no geometry exporter',original_runtime='not performed',UI_bypass_sixth='not established; only numeric method can receive arbitrary records')
(F/'fixture-index.json').write_text(json.dumps(dict(layers=counts,static_assertions=len(json.loads((O/'static-tests.json').read_text(encoding='utf-8'))['checks']),database_cases=27,artifacts=fixtures,applicability=app,oracle='independent recovered sources and algebra/reference branches, never original DLL'),ensure_ascii=False,indent=2),encoding='utf-8')
(O/'read-log.json').write_text(json.dumps(dict(frozen_sources_read=['B3-RnpApch runway-frame/hl-correction/apv-surfaces/obstacle-evaluation/cad-output-map/xdata-schema/persistence/event-map/faf-fap-mapping','ObstacleData screen-data/marker/evaluation/pri-sec-evaluation/evidence','GeometryPrimitives shared-geometry-map/turn-parameter','B5-PbnDeparture runway-frame/overview and round5 comparison','A5 direct shared model and parameter helpers P409-P40C only','original help and OAS samples/database','AC-97-FS-005 cached pages after code recovery'],writes='B4-PbnIls and round7 only',runtime='independent recovery only'),ensure_ascii=False,indent=2),encoding='utf-8')
print('fixture counts',counts,'headers',len(headers),'InitLocals verified')
