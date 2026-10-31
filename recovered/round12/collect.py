import csv,json,hashlib,sys
from pathlib import Path
sys.dont_write_bytecode=True
root=Path(__file__).resolve().parents[2]; out=root/'recovered'/'round12'; out.mkdir(exist_ok=True)
def sha(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  for b in iter(lambda:f.read(1024*1024),b''): h.update(b)
 return h.hexdigest()
files=[]
for p in root.rglob('*'):
 if not p.is_file(): continue
 rel=p.relative_to(root).as_posix()
 if rel.startswith('.git/') or rel.startswith('recovered/round12/'): continue
 files.append({'path':rel,'size':p.stat().st_size,'sha256':sha(p)})
files.sort(key=lambda x:x['path'])
snap={'scope':'all existing workspace files except .git and recovered/round12; includes Round1-11 and existing A3','count':len(files),'files':files}
fp=out/'frozen-inputs.json'
if not fp.exists(): fp.write_text(json.dumps(snap,ensure_ascii=False,indent=2),encoding='utf-8')
sources=['public-function-matrix.csv','feature-subcoverage.csv','residual-gap-register.csv','manual-cad-dependencies.csv','shared-components.csv','shared-vs-copied.csv','help-ui-code-consistency.csv']
rows=[]
for name in sources:
 p=root/'recovered'/'system-coverage'/name
 if not p.exists(): continue
 rs=list(csv.DictReader(p.open(encoding='utf-8-sig',newline='')))
 for i,r in enumerate(rs,1):
  s=' '.join(str(v) for v in r.values())
  if r.get('Module')=='A3' or r.get('ModuleId')=='A3' or 'A3' in s:
   raw=json.dumps(r,ensure_ascii=False,sort_keys=True)
   rows.append({'source':'recovered/system-coverage/'+name,'row':i,'source_sha256':sha(p),'original_row':raw})
with (out/'residual-gap-input.csv').open('w',encoding='utf-8-sig',newline='') as f:
 w=csv.DictWriter(f,fieldnames=['source','row','source_sha256','original_row']); w.writeheader(); w.writerows(rows)
print(json.dumps({'frozen_count':len(files),'a3_rows':len(rows)},ensure_ascii=False))

