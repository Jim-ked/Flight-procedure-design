"""Final audit. Reads frozen trees; writes only Round 5 report/manifest."""
from pathlib import Path
import json,hashlib,csv,re,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round5';A=ROOT/'recovered/B5-PbnDeparture'
def sha(p):return hashlib.sha256(p.read_bytes()).hexdigest()
frozen=json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8'));changed=[];missing=[]
for x in frozen:
 p=ROOT/x['path']
 if not p.exists():missing.append(x['path'])
 elif p.stat().st_size!=x['size'] or sha(p)!=x['sha256']:changed.append(x['path'])
expected={str(Path(x['path'])) for x in frozen};new=[]
for folder in [ROOT/'recovered',ROOT/'WsTools-master',ROOT/'reverse-analysis']:
 for p in folder.rglob('*'):
  if not p.is_file() or O in p.parents or A in p.parents:continue
  if str(p.relative_to(ROOT)) not in expected:new.append(str(p.relative_to(ROOT)))
testinputs=json.loads((O/'test-inputs.json').read_text(encoding='utf-8'));test_changed=[x['path'] for x in testinputs if sha(ROOT/x['path'])!=x['sha256']]
fixtures=list(csv.DictReader((O/'fixture-index.csv').open(encoding='utf-8-sig')));badfixtures=[x['id'] for x in fixtures if not (ROOT/x['path']).exists() or sha(ROOT/x['path'])!=x['sha256']]
mandatory=['overview.md','event-map.md','runway-frame.md','navigation-tolerance.md','altitude-turn.md','altitude-turn-geometry.md','flyover-df.md','straight-segment.md','obstacle-evaluation.md','protection-connections.md','cad-output-map.md','xdata-schema.md','compare-a7.md','callgraph.md','cad-interactions.md','screen-data.md','help-config-crosscheck.md','standard-mapping.md','unrecovered.md']
missing_reports=[x for x in mandatory if not (A/x).exists()];badlinks=[]
for p in list(A.glob('*.md'))+list(O.glob('*.md')):
 for link in re.findall(r'\]\(([^)]+)\)',p.read_text(encoding='utf-8')):
  if '://' in link or link.startswith('#'):continue
  target=link.split('#')[0]
  if target and not (p.parent/target).exists():badlinks.append(dict(file=p.name,target=target))
status=not any([changed,missing,new,test_changed,badfixtures,missing_reports,badlinks])
result=dict(passed=status,frozen_count=len(frozen),changed=changed,missing=missing,new_outside_round5=new,test_source_hash_changes=test_changed,fixture_hash_failures=badfixtures,missing_reports=missing_reports,broken_markdown_links=badlinks,scope='Original/frozen files in original baseline verified; doc PDF supplemental hash in material-baseline',execution='Only independent recovered C#; no target DLL or AutoCAD L3')
(O/'integrity-report.json').write_text(json.dumps(result,ensure_ascii=False,indent=2),encoding='utf-8')
manifest=[]
for folder in [A,O]:
 for p in sorted(folder.rglob('*')):
  if p.is_file() and p.name!='output-manifest.json':manifest.append(dict(path=str(p.relative_to(ROOT)),size=p.stat().st_size,sha256=sha(p)))
(O/'output-manifest.json').write_text(json.dumps(dict(integrity_passed=status,files=manifest),ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps(dict(passed=status,frozen=len(frozen),outputs=len(manifest),changed=changed,missing=missing,new_outside=new,test_changed=test_changed,badfixtures=badfixtures,missing_reports=missing_reports,badlinks=badlinks),ensure_ascii=False))
raise SystemExit(0 if status else 1)
