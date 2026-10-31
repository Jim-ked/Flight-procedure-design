import csv,hashlib,json
from pathlib import Path

ROOT=Path(__file__).resolve().parents[2]; R=ROOT/'recovered'/'round14'
snap=json.loads((R/'frozen-inputs.json').read_text(encoding='utf-8'))
frozen=snap['files']; frozen_paths={x['path'] for x in frozen}
missing=[]; mismatch=[]
for item in frozen:
 p=ROOT/item['path']
 if not p.exists(): missing.append(item['path']); continue
 h=hashlib.sha256(p.read_bytes()).hexdigest()
 if h!=item['sha256']: mismatch.append({'path':item['path'],'expected':item['sha256'],'actual':h})

allowed_files={
 'recovered/A2-BasicCalculation/final-feature-matrix.csv','recovered/A2-BasicCalculation/cad-output-final.csv','recovered/A2-BasicCalculation/wscalculine-final.md','recovered/A2-BasicCalculation/error-behavior.csv','recovered/A2-BasicCalculation/help-ui-code-final.csv','recovered/A2-BasicCalculation/final-static-closure.md',
 'recovered/A9-PriSec/final-feature-matrix.csv','recovered/A9-PriSec/input-semantics.md','recovered/A9-PriSec/mode-comparison.csv','recovered/A9-PriSec/help-ui-code-final.csv','recovered/A9-PriSec/final-static-closure.md'
}
outside=[]
for base in [ROOT/'recovered'/'round14',ROOT/'recovered'/'A2-BasicCalculation',ROOT/'recovered'/'A9-PriSec']:
 for p in base.rglob('*'):
  if not p.is_file(): continue
  rel=p.relative_to(ROOT).as_posix()
  if rel.startswith('recovered/round14/') or rel in allowed_files or rel in frozen_paths: continue
  outside.append(rel)

checks=[]
for path,fields in [
 (ROOT/'recovered/A2-BasicCalculation/final-feature-matrix.csv',['Feature','UI','Event','Inputs','Formula','CADPick','CADOutput','Metadata','Reachable','Status','Evidence']),
 (ROOT/'recovered/A2-BasicCalculation/cad-output-final.csv',['Feature','GetPointCount','Prompts/meaning','CancelBehavior','LineCreation','Text','Transaction','XData','WsCalcuLine','Evidence']),
 (ROOT/'recovered/A9-PriSec/final-feature-matrix.csv',['Feature','UI','Event','Inputs','Formula','Geometry','CADWriter','Metadata','Reachable','Status','Evidence']),
 (ROOT/'recovered/A9-PriSec/mode-comparison.csv',['Aspect','Normal','IF','Evidence']),
]:
 with path.open(encoding='utf-8-sig',newline='') as f: got=next(csv.reader(f))
 checks.append({'path':path.relative_to(ROOT).as_posix(),'columns_ok':got==fields})
tests=json.loads((R/'static-tests.json').read_text(encoding='utf-8'))
report={'scope':'Round14 A2/A9 additive static closure integrity','frozen_count':len(frozen),'frozen_missing':missing,'frozen_mismatch':mismatch,'unexpected_files_outside_round14_or_declared_final_reports':sorted(set(outside)),'feature_matrix_checks':checks,'static_tests_all_pass':tests.get('all_pass',False)}
report['status']='PASS' if not missing and not mismatch and not outside and all(x['columns_ok'] for x in checks) and tests.get('all_pass',False) else 'FAIL'
(R/'integrity-report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2),encoding='utf-8')
manifest=[]
for base in [ROOT/'recovered'/'round14',ROOT/'recovered'/'A2-BasicCalculation',ROOT/'recovered'/'A9-PriSec']:
 for p in base.rglob('*'):
  if not p.is_file(): continue
  rel=p.relative_to(ROOT).as_posix()
  if rel.startswith('recovered/round14/') or rel in allowed_files:
   manifest.append({'path':rel,'size':p.stat().st_size,'sha256':hashlib.sha256(p.read_bytes()).hexdigest()})
(R/'output-manifest.json').write_text(json.dumps({'scope':'Round14 outputs and declared A2/A9 final reports','count':len(manifest),'files':manifest},ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({'frozen_count':len(frozen),'missing':len(missing),'mismatch':len(mismatch),'outside':len(outside),'status':report['status']},ensure_ascii=False))
