import json,hashlib,re
from pathlib import Path
root=Path(__file__).resolve().parents[2]; r=root/'recovered'/'round11'; a=root/'recovered'/'A7-Departure'
frozen=json.loads((r/'frozen-inputs.json').read_text(encoding='utf-8'))['files']
mismatch=[]; missing=[]
for x in frozen:
 p=root/x['path']
 if not p.exists(): missing.append(x['path']); continue
 h=hashlib.sha256(p.read_bytes()).hexdigest()
 if h!=x['sha256']: mismatch.append({'path':x['path'],'expected':x['sha256'],'actual':h})
allowed={'recovered/round11','recovered/A7-Departure'}; new=[]
for base in [r,a]:
 for p in base.rglob('*'):
  if p.is_file():
   rel=p.relative_to(root).as_posix()
   if not any(rel==d or rel.startswith(d+'/') for d in allowed): new.append(rel)
links=[]
for p in [a/'final-static-closure.md',a/'cross-window-input-proof.md',r/'closure.md']:
 for token in re.findall(r'[A-Za-z0-9_./-]+\.(?:csv|md|json)',p.read_text(encoding='utf-8')):
  ok=any(c.exists() for c in [p.parent/token,root/token,r/token,a/token])
  links.append({'source':p.relative_to(root).as_posix(),'target':token,'exists':ok})
report={'scope':'Round11 static closure integrity','frozen_count':len(frozen),'frozen_missing':missing,'frozen_mismatch':mismatch,'new_files_outside_allowed_dirs':new,'link_checks':links,'status':'PASS' if not mismatch and not missing and not new and all(x['exists'] for x in links) else 'FAIL'}
(r/'integrity-report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2),encoding='utf-8')
manifest=[]
for base in [a,r]:
 for p in base.rglob('*'):
  if p.is_file() and p.name not in ('output-manifest.json','integrity-report.json'):
   manifest.append({'path':p.relative_to(root).as_posix(),'size':p.stat().st_size,'sha256':hashlib.sha256(p.read_bytes()).hexdigest()})
(r/'output-manifest.json').write_text(json.dumps({'scope':'new Round11 outputs; integrity-report excluded from manifest','count':len(manifest),'files':manifest},ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({'frozen_count':len(frozen),'mismatch':len(mismatch),'missing':len(missing),'outside':new,'links_bad':sum(not x['exists'] for x in links),'status':report['status']},ensure_ascii=False))

