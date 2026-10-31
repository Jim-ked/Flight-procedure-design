"""Read-only audit of frozen inputs; writes only Round9 audit artifacts."""
from pathlib import Path
import csv, hashlib, json, re, sys
from collections import Counter
from urllib.parse import unquote

sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2]
O=ROOT/'recovered/round9'; A=ROOT/'recovered/A4-NavAidProtection'; E=A/'evidence'
def sha(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  for b in iter(lambda:f.read(1024*1024),b''):h.update(b)
 return h.hexdigest()
def read(p):return json.loads(p.read_text(encoding='utf-8-sig'))
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def dump(p,x):p.write_text(json.dumps(x,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
def identity(p):return dict(path=str(p.relative_to(ROOT)),absolute_path=str(p),size=p.stat().st_size,sha256=sha(p))

# Fixture identity is tied to both tested source and output hashes, not just counts.
counts=read(O/'fixtures/numeric-counts.json'); checks=read(O/'static-tests.json')['checks']
fixture_files=[]
for p in sorted((O/'fixtures').iterdir()):
 if p.is_file():
  x=identity(p)
  if p.suffix=='.csv':x['data_rows']=len(rows(p))
  fixture_files.append(x)
dump(O/'fixture-index.json',dict(E3_assertions_by_layer=counts,E3_total=sum(counts.values()),static_checks_by_layer=dict(Counter(c['layer'] for c in checks)),static_total=len(checks),E4_total=0,fixtures=fixture_files,test_inputs=read(O/'test-inputs.json'),scope='Independent recovered-source execution and separate static checks; not target DLL/CAD runtime'))

inputs=[ROOT/'WsTools-master/WindSpiral2026/WindSpiralBasic.dll',ROOT/'reverse-analysis/01_original/WsTools-master/WindSpiral2026/WindSpiralBasic.dll',ROOT/'reverse-analysis/02_deobfuscated/WindSpiralBasic.methods-only.dll',ROOT/'doc/航空器运行目视和仪表飞行程序设计规范.pdf',ROOT/'WsTools-master/WindSpiral2026/config.xml',ROOT/'WsTools-master/WindSpiral2026/帮助文件/FormNavAids.html',ROOT/'reverse-analysis/03_recovered-src/annotated-strings/--/--.cs',ROOT/'recovered/round5/standard-pages.json']
dump(E/'provenance.json',dict(inputs=[identity(p) for p in inputs],evidence_levels={'E0':'original identity and metadata (protection stubs retained)','E1':'processed decompilation','E2':'IL/call/field based reconstruction','E3':'independent recovered-source tests','E4':'not performed','N':'post-recovery standard mapping'},originals_read_only=True))

failures=[]; audit_checks=[]
def ck(name,passed,detail=None):
 audit_checks.append(dict(name=name,passed=bool(passed),detail=detail))
 if not passed:failures.append(name)

base=read(O/'frozen-inputs.json'); known={x['path'] for x in base}
missing=[]; mismatch=[]
for x in base:
 p=ROOT/x['path']
 if not p.is_file():missing.append(x['path'])
 elif p.stat().st_size!=x['size'] or sha(p)!=x['sha256']:mismatch.append(x['path'])
added=[]
for tree in ['recovered','reverse-analysis','WsTools-master','doc']:
 for p in (ROOT/tree).rglob('*'):
  if p.is_file() and A not in p.parents and O not in p.parents and str(p.relative_to(ROOT)) not in known:added.append(str(p.relative_to(ROOT)))
ck('frozen baseline remains identical',not missing and not mismatch,dict(files=len(base),missing=missing,mismatch=mismatch))
ck('no new files outside two Round9 directories in four audited trees',not added,added)
ck('baseline has expected 6678 files',len(base)==6678)

bad_links=[]; link_count=0
generated_outputs={O/'integrity-report.json',O/'output-manifest.json'}
for folder in [A,O]:
 for p in folder.rglob('*.md'):
  for target in re.findall(r'\[[^\]]*\]\(([^)]+)\)',p.read_text(encoding='utf-8')):
   target=target.strip().strip('<>')
   if re.match(r'^[a-z]+://',target) or target.startswith('#'):continue
   target=unquote(target.split('#')[0]);link_count+=1
   resolved=(p.parent/target).resolve()
   # These two self-referenced audit artifacts are written at the end of this run.
   if not resolved.exists() and resolved not in generated_outputs:bad_links.append(dict(file=str(p.relative_to(ROOT)),target=target))
ck('all local report links exist',not bad_links,dict(links=link_count,broken=bad_links))

methods=rows(E/'method-index.csv');core=[m for m in methods if m['scope']=='A4 core']
ck('107 indexed methods and 13 A4 core identities',len(methods)==107 and len(core)==13)
bad_il=[]
for m in methods:
 for side,key,rva in [('raw','original_token','original_rva'),('processed','processed_token','processed_rva')]:
  p=E/side/(m[key]+'.il.txt')
  if int(m[rva],16):
   if not p.is_file() or 'METHOD '+m[key][2:] not in p.read_text(encoding='utf-8'):bad_il.append(dict(token=m[key],side=side))
ck('indexed non-native methods retain original and processed IL',not bad_il,bad_il)
ck('P2F6 is native SetFocus, no fabricated method body',read(E/'native-import.json')==[dict(token='0x060002F6',module='user32.dll',entry='SetFocus')])
events=rows(E/'event-identities.csv')
ck('all five events retain identity/RVA/callees',len(events)==5 and all(all(e[k] for k in ['control_name','event','handler_tokens','original_token','original_rva','processed_rva','direct_callees','reachability']) for e in events))
reach=read(E/'event-reachability.json')
ck('all five handlers in resolved 74-method closure',len(reach['reachable'])==74 and set(e['handler_tokens'] for e in events)<=set(reach['reachable']) and reach['methodspec_resolved'])
closure=(O/'closure.md').read_text(encoding='utf-8')
ck('twenty closure answers are present',list(map(int,re.findall(r'^### (\d+)\.',closure,re.M)))==list(range(1,21)))
ck('scope stop and static-only acceptance explicit','ACCEPTED (static recovery)' in closure and '不自动执行' in closure and 'System Coverage Review' in closure)

ck('test sources remain exactly the tested inputs',all(sha(ROOT/x['path'])==x['sha256'] for x in read(O/'test-inputs.json')))
assertions=rows(O/'fixtures/assertions.csv')
ck('5550 recorded E3 assertions agree with layered counts',len(assertions)==sum(counts.values())==5550 and dict(Counter(x['layer'] for x in assertions))==counts)
ck('all recorded E3 equality assertions passed',all(x['actual']==x['expected'] for x in assertions))
ck('thirty static checks passed',len(checks)==30 and all(x['passed'] for x in checks))
layers=rows(O/'verification-layers.csv')
ck('eight requested verification layers are represented',len(layers)==8 and sum(int(x['E3_assertions']) for x in layers)==5550 and sum(int(x['static_checks']) for x in layers)==30 and all(x['E4_assertions']=='0' for x in layers))
ck('test execution log agrees with all layers',all('PASS '+k+': '+str(v) in (O/'tests.log').read_text(encoding='utf-8') for k,v in counts.items()))
ck('fixture index hashes and counts remain current',all(sha(ROOT/x['path'])==x['sha256'] for x in read(O/'fixture-index.json')['fixtures']))
ends=rows(O/'fixtures/15-degree-endpoints.csv')
ck('15deg endpoints saved for all 96 side cases',len(ends)==96)
facility=rows(A/'facility-matrix.csv')
ck('facility matrix includes VOR/NDB and negative evidence rows',len(facility)>=6 and any('VOR'==next(iter(x.values())) for x in facility) and any('NDB'==next(iter(x.values())) for x in facility))
shared=rows(E/'cross-module-shared-calls.csv')
ck('A6 comparison limits line-sharing claim to observed P7E8',any(x['peer']=='A6-base-turn' and x['shared_target']=='0x060007E8' for x in shared) and not any(x['peer']=='A6-base-turn' and x['shared_target'] in ['0x060007E7','0x060007ED'] for x in shared))
std=read(E/'standard-search.json')
ck('standard source identity matches actual PDF and frozen text',sha(ROOT/std['path'])==std['sha256'] and sha(ROOT/std['extracted_from'])==std['text_sha256'])
ck('original DLL equals frozen original copy',sha(inputs[0])==sha(inputs[1]))

plan=O/'PLAN.md'
if not failures:plan.write_text(plan.read_text(encoding='utf-8').replace('[ ]','[x]'),encoding='utf-8')
dump(O/'integrity-report.json',dict(status='PASS' if not failures else 'FAIL',baseline_files=len(base),frozen_missing=missing,frozen_mismatch=mismatch,unexpected_additions=added,checks=audit_checks,failures=failures,scope='Four frozen material trees and two Round9 output directories; no filesystem-wide monitoring',target_runtime_executed=False))
# Manifest excludes itself to avoid self-reference; includes the completed integrity report.
manifest=[]
for folder in [A,O]:
 for p in sorted(folder.rglob('*')):
  if p.is_file() and p!=O/'output-manifest.json':manifest.append(identity(p))
dump(O/'output-manifest.json',dict(excludes=['recovered/round9/output-manifest.json'],files=manifest))
assert all(p.is_file() for p in generated_outputs)
print(json.dumps(dict(status='PASS' if not failures else 'FAIL',baseline_files=len(base),audit_checks=len(audit_checks),failures=failures,manifest_files=len(manifest)),ensure_ascii=False))
if failures:sys.exit(1)
