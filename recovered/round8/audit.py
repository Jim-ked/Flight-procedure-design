"""Round 8 closure checks. Does not execute or modify any frozen input."""
from pathlib import Path
import csv,json,re,hashlib,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2]; O=ROOT/'recovered/round8'; A=ROOT/'recovered/A5-PrecisionApproach'; E=A/'evidence'
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def dump(p,v):p.write_text(json.dumps(v,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
baseline=json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8')); mismatch=[];missing=[]
for f in baseline:
 p=ROOT/f['path']
 if not p.exists():missing.append(f['path'])
 elif p.stat().st_size!=f['size'] or sha(p)!=f['sha256']:mismatch.append(f['path'])
old={str(Path(f['path'])) for f in baseline};outside=[]
for d in ['recovered','reverse-analysis','WsTools-master','doc']:
 for p in (ROOT/d).rglob('*'):
  if p.is_file() and A not in p.parents and O not in p.parents and str(p.relative_to(ROOT)) not in old:outside.append(str(p.relative_to(ROOT)))
errors=[];checks=[]
def check(n,b):
 checks.append(dict(name=n,passed=bool(b)))
 if not b:errors.append(n)
check('Frozen baseline 5811 files unchanged',len(baseline)==5811 and not mismatch and not missing)
check('No additions outside Round8/A5 within all baseline trees',not outside)
required='overview event-map class-map oas-parameter-model oas-surfaces w-wstar gp-inop paoas oas-cad pa-with-fap pa-with-faf faf-fap-mapping hl-correction minima obstacle-evaluation cad-output-map xdata-schema oas-txt-format persistence standard-mapping cad-interactions unrecovered verification'.split()
check('All 23 required and supplementary reports exist',all((A/(x+'.md')).exists() for x in required))
check('Six modes in matrix',len(rows(A/'mode-matrix.csv'))==6)
check('Database, B4/A5 and HL comparisons exist',all((O/x).exists() for x in ['a5-b4-database-comparison.csv','b4-a5-comparison.csv','hl-comparison.csv']))
cl=(O/'closure.md').read_text(encoding='utf-8')
check('Exactly 26 closure answers',re.findall(r'^\|(\d+)\|',cl.split('## 验收门槛')[0],re.M)==list(map(str,range(1,27))))
check('Partially accepted and stop retained','PARTIALLY ACCEPTED (static recovery)' in cl and 'Round 8收口' in cl)
inputs=json.loads((O/'test-inputs.json').read_text(encoding='utf-8'))
check('Latest test input source hashes match',all(sha(ROOT/f['path'])==f['sha256'] for f in inputs))
counts=json.loads((O/'fixtures/numeric-counts.json').read_text());actual={}
for r in rows(O/'fixtures/assertions.csv'):actual[r['layer']]=actual.get(r['layer'],0)+1
check('All 2980 independent assertions accounted by layer',counts==actual and sum(counts.values())==2980)
log=(O/'tests.log').read_text(encoding='utf-8')
check('Current tests log has all 8 passing layers',all(f'PASS {k}: {v}' in log for k,v in counts.items()) and 'System.Exception' not in log)
check('Current compile log has no diagnostic',(O/'compile-tests.log').stat().st_size==0)
static=json.loads((O/'static-tests.json').read_text());check('32 event/reachability static assertions passed',len(static['checks'])==32 and all(x['passed'] for x in static['checks']))
fi=json.loads((O/'fixture-index.json').read_text(encoding='utf-8'))
check('All fixture hashes current',all(sha(ROOT/f['path'])==f['sha256'] for f in fi['files']))
check('Historical failure unambiguous',not (O/'fixtures/failure.txt').exists() and (O/'fixtures/historical-failure.txt').exists())
methods=rows(E/'method-index.csv');bad_il=[]
for m in methods:
 for tier,k in [('processed','processed_token'),('raw','original_token')]:
  p=E/tier/(m[k]+'.il.txt')
  if not p.exists() and m['processed_token']!='0x06000305':bad_il.append(str(p.relative_to(ROOT)))
check('All 260 managed methods have raw/processed IL; native P305 has import evidence',len(methods)==261 and not bad_il and (E/'native-import.json').exists())
events=rows(E/'event-identities.csv')
check('20 event identities contain source, raw/processed tokens and RVAs',len(events)==20 and all(all(e.get(k) for k in ['handler_tokens','original_token','original_rva','processed_rva','source','line']) for e in events))
reach=set(json.loads((E/'event-reachability.json').read_text())['reachable']);incoming=rows(E/'resolved-global-incoming.csv')
check('P41B/P429/P3A7 have no incoming or event reachability',all(t not in reach and not any(c['target']==t for c in incoming) for t in ['0x0600041B','0x06000429','0x060003A7']))
check('70 recovered method identities retained',len(rows(E/'recovery-method-map.csv'))==70)
check('Branch/field/output/semantic indexes nonempty',all((E/f).stat().st_size>100 for f in ['branch-sites.csv','field-flow.csv','condition-expressions.csv','list-construction.csv','model-expressions.csv','method-input-output.csv','model-fields.csv','connection-semantic-calls.csv']))
std=json.loads((E/'standard-search.json').read_text(encoding='utf-8'))
check('Current standard hash and 13 physical PDF pages retained',std['sha256']=='6b6b6f04380f3e0a138ca57bb95fcddb0a390a5b4aa7a9c7a391ff35bb92c8ed' and len(std['pages'])==13)
# Resolved local links in new reports only; final integrity/manifests intentionally written below.
link_errors=[]
for p in list(A.glob('*.md'))+[O/'closure.md']:
 for target in re.findall(r'\]\(([^)]+)\)',p.read_text(encoding='utf-8')):
  if '://' in target or target.startswith('#'):continue
  target=target.split('#')[0]
  if target in ['integrity-report.json','output-manifest.json'] and p.parent==O:continue
  if not (p.parent/target).exists():link_errors.append(dict(report=p.name,target=target))
check('All new report links resolve',not link_errors)
check('All six PLAN tasks complete',(O/'PLAN.md').read_text(encoding='utf-8').count('[x]')==6)
provenance=[]
for f in baseline:
 if f['path'].endswith('WindSpiralBasic.dll') or f['path'].endswith('WindSpiralBasic.methods-only.dll') or f['sha256'] in [std['sha256'],'a63ed87cbf5b816d46aef87463b7f0a3393d9cd6e83a0040b13fdea7858a025f']:
  provenance.append(dict(f,absolute_path=str(ROOT/f['path'])))
dump(O/'provenance.json',dict(inputs=provenance,frozen_manifest='frozen-inputs.json',target_execution=False,original_mutation=False,source_levels='E0 identity / E1 processed / E2 IL / E3 independent / no E4 / N standard'))
result=dict(status='PASS' if not errors else 'FAIL',round='Round 8',acceptance='PARTIALLY ACCEPTED (static recovery)',baseline_count=len(baseline),missing=missing,mismatches=mismatch,unexpected_additions=outside,scope='All files under four baseline trees; Round8/A5 excluded by design. No claim about unrelated pre-existing workspace files.',numeric_total=sum(counts.values()),numeric_layers=counts,static_event_reachability_count=32,checks=checks,errors=errors,missing_il=bad_il,link_errors=link_errors)
dump(O/'integrity-report.json',result)
manifest=[]
for directory in [A,O]:
 for p in sorted(directory.rglob('*')):
  if p.is_file() and p!=O/'output-manifest.json':manifest.append(dict(path=str(p.relative_to(ROOT)),size=p.stat().st_size,sha256=sha(p)))
dump(O/'output-manifest.json',dict(excludes_self=True,files=manifest))
print(json.dumps(dict(status=result['status'],baseline_count=len(baseline),mismatches=len(mismatch),missing=len(missing),outside_additions=len(outside),checks=len(checks),numeric_total=result['numeric_total'],static=32,outputs=len(manifest),errors=errors,link_errors=link_errors),ensure_ascii=False))
if errors:raise SystemExit(1)
