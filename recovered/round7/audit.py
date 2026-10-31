from pathlib import Path
import json,hashlib,csv,re
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round7';A=ROOT/'recovered/B4-PbnIls';E=A/'evidence'
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
frozen=json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8'));changed=[];missing=[]
for x in frozen:
 p=ROOT/x['path']
 if not p.exists():missing.append(x['path'])
 elif p.stat().st_size!=x['size'] or sha(p)!=x['sha256']:changed.append(x['path'])
known={x['path'] for x in frozen};new=[]
for folder in ['recovered','WsTools-master','reverse-analysis','doc']:
 for p in (ROOT/folder).rglob('*'):
  if p.is_file() and A not in p.parents and O not in p.parents and str(p.relative_to(ROOT)) not in known:new.append(str(p.relative_to(ROOT)))
inputs=json.loads((O/'test-inputs.json').read_text(encoding='utf-8'));inputchanges=[x['path'] for x in inputs if sha(ROOT/x['path'])!=x['sha256']]
required=['overview.md','event-map.md','runway-frame.md','oas-parameter-model.md','oas-surfaces.md','faf-fap-mapping.md','hl-correction.md','navigation-tolerance.md','pbn-turn.md','oas-pbn-connection.md','obstacle-evaluation.md','cad-output-map.md','xdata-schema.md','kml-export.md','persistence.md','standard-mapping.md','cad-interactions.md','unrecovered.md','verification.md']
missingreports=[n for n in required if not (A/n).exists()];broken=[]
for p in list(A.glob('*.md'))+list(O.glob('*.md')):
 for target in re.findall(r'\]\(([^)]+)\)',p.read_text(encoding='utf-8')):
  if target.startswith(('http:','https:')):continue
  target=target.split('#')[0]
  if target and not (p.parent/target).exists():broken.append(dict(file=str(p.relative_to(ROOT)),target=target))
answers=re.findall(r'^\|(\d+)\|',(O/'closure.md').read_text(encoding='utf-8'),re.M);validanswers=answers==[str(i) for i in range(1,34)]
fi=json.loads((O/'fixtures/fixture-index.json').read_text(encoding='utf-8'));fixturechanges=[x['path'] for x in fi['artifacts'] if sha(O/'fixtures'/x['path'])!=x['sha256']]
log=(O/'tests.log').read_text(encoding='utf-8');logok=all('PASS '+k+': '+str(v) in log for k,v in fi['layers'].items())
static=json.loads((O/'static-tests.json').read_text(encoding='utf-8'));staticok=all(x['passed'] for x in static['checks'])
ms={x['processed_token']:x for x in rows(E/'method-index.csv')};eventerrors=[e['handler_tokens'] for e in rows(E/'events.csv') if e['handler_tokens'] not in ms or not ms[e['handler_tokens']]['original_rva']]
indexerrors=[]
for t,m in ms.items():
 for sub,key in [('raw','original_token'),('processed','processed_token')]:
  if m[key] not in ['0x06000552'] and m[sub+'_size' if sub=='raw' else 'processed_size']!='0' and not (E/sub/(m[key]+'.il.txt')).exists():indexerrors.append(t+':'+sub)
passed=not(changed or missing or new or inputchanges or missingreports or broken or fixturechanges or eventerrors or indexerrors) and validanswers and logok and staticok
report=dict(passed=passed,frozen_files=len(frozen),frozen_changed=changed,frozen_missing=missing,new_outside_round7=new,test_source_hash_changes=inputchanges,missing_reports=missingreports,broken_links=broken,all_33_answers=validanswers,fixture_hash_changes=fixturechanges,layer_assertions=fi['layers'],static_assertions=len(static['checks']),static_passed=staticok,logs_match=logok,event_identity_errors=eventerrors,index_errors=indexerrors,execution='Only independently recovered C#; no original target DLL or AutoCAD',status='PARTIALLY ACCEPTED (static recovery)',limits='Integrity/hash/fixture checks are not an original runtime or aviation design validation')
(O/'integrity-report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2),encoding='utf-8')
manifest=[dict(path=str(p.relative_to(ROOT)),size=p.stat().st_size,sha256=sha(p)) for folder in [A,O] for p in sorted(folder.rglob('*')) if p.is_file() and p.name!='output-manifest.json']
(O/'output-manifest.json').write_text(json.dumps(dict(integrity_passed=passed,files=manifest),ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps(report,ensure_ascii=False));print('manifest files',len(manifest));raise SystemExit(0 if passed else 1)
