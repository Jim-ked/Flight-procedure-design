from pathlib import Path
import json,hashlib,csv,re
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round6';A=ROOT/'recovered/B3-RnpApch';E=A/'evidence'
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
frozen=json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8'));changed=[];missing=[]
for x in frozen:
 p=ROOT/x['path']
 if not p.exists():missing.append(x['path'])
 elif p.stat().st_size!=x['size'] or sha(p)!=x['sha256']:changed.append(x['path'])
known={x['path'] for x in frozen};new=[]
for folder in [ROOT/'recovered',ROOT/'WsTools-master',ROOT/'reverse-analysis',ROOT/'doc']:
 for p in folder.rglob('*'):
  if p.is_file() and O not in p.parents and A not in p.parents and str(p.relative_to(ROOT)) not in known:new.append(str(p.relative_to(ROOT)))
inputs=json.loads((O/'test-inputs.json').read_text(encoding='utf-8'));test_changed=[x['path'] for x in inputs if not (ROOT/x['path']).exists() or sha(ROOT/x['path'])!=x['sha256']]
required=['overview.md','event-map.md','runway-frame.md','lnav.md','lnav-fix-geometry.md','lnav-obstacle-evaluation.md','apv.md','hl-correction.md','faf-fap-mapping.md','apv-surfaces.md','apv-obstacle-evaluation.md','missed-approach.md','turn-parameter-usage.md','field-semantics.md','obstacle-evaluation.md','cad-output-map.md','xdata-schema.md','persistence.md','cad-interactions.md','standard-mapping.md','unrecovered.md','verification.md']
missing_reports=[x for x in required if not (A/x).exists()];broken=[]
for p in list(A.glob('*.md'))+list(O.glob('*.md')):
 for target in re.findall(r'\]\(([^)]+)\)',p.read_text(encoding='utf-8')):
  if target.startswith(('http:','https:')):continue
  target=target.split('#')[0]
  if target and not (p.parent/target).exists():broken.append(dict(file=str(p.relative_to(ROOT)),target=target))
idx=json.loads((O/'fixtures/index.json').read_text(encoding='utf-8-sig'));fixture_errors=[]
for x in idx['cases']:
 p=O/'fixtures'/(x['id']+'.json')
 if not p.exists():fixture_errors.append('missing '+x['id']);continue
 obj=json.loads(p.read_text(encoding='utf-8-sig'))
 if obj.get('id')!=x['id'] or 'input' not in obj or 'output' not in obj:fixture_errors.append('schema '+x['id'])
static=json.loads((O/'static-tests.json').read_text(encoding='utf-8'));static_pass=all(x['passed'] for x in static['assertions']);log=(O/'tests.log').read_text(encoding='utf-8')
counts_valid=all('PASS '+k+' assertions='+str(v) in log for k,v in idx['assertions'].items())
metadata=rows(E/'method-index.csv');md={x['processed_token']:x for x in metadata};events=rows(E/'events.csv');event_identity_errors=[e['handler_tokens'] for e in events if e['handler_tokens'] not in md or not md[e['handler_tokens']]['original_rva']]
closure=(O/'closure.md').read_text(encoding='utf-8');answers=re.findall(r'^\|(\d+)\|',closure,re.M);answers_valid=answers==list(map(str,range(1,33)))
artifacts_valid=all((O/n).stat().st_size>0 for n in ['Round6.Recovered.dll','Round6.Tests.exe'])
passed=not(changed or missing or new or test_changed or missing_reports or broken or fixture_errors or event_identity_errors) and static_pass and counts_valid and answers_valid and artifacts_valid
result=dict(passed=passed,frozen_count=len(frozen),changed=changed,missing=missing,new_outside_round6=new,test_source_hash_changes=test_changed,missing_reports=missing_reports,broken_report_links=broken,fixture_count=len(idx['cases']),fixture_errors=fixture_errors,assertions=idx['assertions'],static_assertions=len(static['assertions']),static_pass=static_pass,log_counts_match=counts_valid,event_count=len(events),event_identity_errors=event_identity_errors,all_32_answers_present=answers_valid,recovered_artifacts_present=artifacts_valid,execution='Independent recovered B3 only; no target DLL or AutoCAD',audit_limit='Hashes, links, schema and counts do not independently prove algorithm/report correctness; method/IL evidence and limitations retained')
(O/'integrity-report.json').write_text(json.dumps(result,ensure_ascii=False,indent=2),encoding='utf-8')
manifest=[]
for folder in [A,O]:
 for p in sorted(folder.rglob('*')):
  if p.is_file() and p.name!='output-manifest.json':manifest.append(dict(path=str(p.relative_to(ROOT)),size=p.stat().st_size,sha256=sha(p)))
(O/'output-manifest.json').write_text(json.dumps(dict(integrity_passed=passed,files=manifest),ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps(result,ensure_ascii=False));print('manifest files',len(manifest));raise SystemExit(0 if passed else 1)
