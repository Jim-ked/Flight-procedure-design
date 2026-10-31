import csv, hashlib, json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
R = ROOT / 'recovered' / 'round13'
frozen = json.loads((R/'frozen-inputs.json').read_text(encoding='utf-8'))['files']
frozen_paths = {x['path'] for x in frozen}
missing, mismatch = [], []
for item in frozen:
    p = ROOT / item['path']
    if not p.exists():
        missing.append(item['path'])
        continue
    h = hashlib.sha256(p.read_bytes()).hexdigest()
    if h != item['sha256']:
        mismatch.append({'path':item['path'],'expected':item['sha256'],'actual':h})

allowed_dirs = {'recovered/round13'}
allowed_files = {
    'recovered/A1-WindSpiral/final-input-semantics.csv',
    'recovered/A1-WindSpiral/cad-output-final.csv',
    'recovered/A1-WindSpiral/help-ui-code-final.csv',
    'recovered/A1-WindSpiral/final-static-closure.md',
    'recovered/B1-FlyBy/final-branch-map.csv',
    'recovered/B1-FlyBy/help-ui-code-final.csv',
    'recovered/B1-FlyBy/final-static-closure.md',
    'recovered/B2-FlyOverDF/final-branch-map.csv',
    'recovered/B2-FlyOverDF/help-ui-code-final.csv',
    'recovered/B2-FlyOverDF/final-static-closure.md',
}
outside=[]
for base in [ROOT/'recovered'/'round13', ROOT/'recovered'/'A1-WindSpiral', ROOT/'recovered'/'B1-FlyBy', ROOT/'recovered'/'B2-FlyOverDF']:
    for p in base.rglob('*'):
        if not p.is_file(): continue
        rel=p.relative_to(ROOT).as_posix()
        if rel.startswith('recovered/round13/') or rel in allowed_files or rel in frozen_paths: continue
        if rel.startswith('recovered/round13'):
            continue
        outside.append(rel)

feature_checks=[]
for path, fields in [
    (ROOT/'recovered/A1-WindSpiral/final-input-semantics.csv',['Mode','Pick1','Pick2','Pick3','Origin','Heading','Offset','Direction','TurnAngle','Output']),
    (ROOT/'recovered/A1-WindSpiral/cad-output-final.csv',['Mode','Polyline','Spline','Line','Circle','Group','Text','XData','Metadata','Creation order']),
    (ROOT/'recovered/B1-FlyBy/final-branch-map.csv',['condition','method','point/list','CAD entity','business interpretation']),
    (ROOT/'recovered/B2-FlyOverDF/final-branch-map.csv',['condition','source method','geometry effect','CAD effect']),
]:
    with path.open(encoding='utf-8-sig',newline='') as f:
        got=next(csv.reader(f))
    feature_checks.append({'path':path.relative_to(ROOT).as_posix(),'columns_ok':got==fields})

tests=json.loads((R/'static-tests.json').read_text(encoding='utf-8'))
report={
    'scope':'Round13 A1/B1/B2 additive static closure integrity',
    'frozen_count':len(frozen),
    'frozen_missing':missing,
    'frozen_mismatch':mismatch,
    'unexpected_files_outside_round13_or_declared_final_reports':sorted(set(outside)),
    'feature_matrix_checks':feature_checks,
    'static_tests_all_pass':tests.get('all_pass',False),
}
report['status']='PASS' if (not missing and not mismatch and not outside and all(x['columns_ok'] for x in feature_checks) and tests.get('all_pass',False)) else 'FAIL'
(R/'integrity-report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2),encoding='utf-8')

manifest=[]
for base in [ROOT/'recovered'/'round13', ROOT/'recovered'/'A1-WindSpiral', ROOT/'recovered'/'B1-FlyBy', ROOT/'recovered'/'B2-FlyOverDF']:
    for p in base.rglob('*'):
        if not p.is_file(): continue
        rel=p.relative_to(ROOT).as_posix()
        if rel.startswith('recovered/round13/') or rel in allowed_files:
            manifest.append({'path':rel,'size':p.stat().st_size,'sha256':hashlib.sha256(p.read_bytes()).hexdigest()})
(R/'output-manifest.json').write_text(json.dumps({'scope':'Round13 outputs; includes declared additive A1/B1/B2 reports','count':len(manifest),'files':manifest},ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({'frozen_count':len(frozen),'missing':len(missing),'mismatch':len(mismatch),'outside':len(outside),'status':report['status']},ensure_ascii=False))

