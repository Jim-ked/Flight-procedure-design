import csv,json,hashlib,sys
from pathlib import Path
sys.dont_write_bytecode=True
root=Path(__file__).resolve().parents[2]; out=root/'recovered'/'round14'
def sha(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  for b in iter(lambda:f.read(1024*1024),b''): h.update(b)
 return h.hexdigest()
files=[]
for p in root.rglob('*'):
 if not p.is_file(): continue
 rel=p.relative_to(root).as_posix()
 if rel.startswith('.git/') or rel.startswith('recovered/round14/'): continue
 files.append({'path':rel,'size':p.stat().st_size,'sha256':sha(p)})
files.sort(key=lambda x:x['path'])
(out/'frozen-inputs.json').write_text(json.dumps({'scope':'Round14 inputs: all existing workspace files except .git and recovered/round14; Round1-13 frozen','count':len(files),'files':files},ensure_ascii=False,indent=2),encoding='utf-8')
# Extract only A2/A9 rows from required Round 10 audits.
sources=['public-function-matrix.csv','feature-subcoverage.csv','residual-gap-register.csv','help-ui-code-consistency.csv','data-model-master.csv','obstacle-pipeline-master.csv','manual-cad-dependencies.csv']
rows=[]
for name in sources:
 p=root/'recovered'/'system-coverage'/name
 if not p.exists(): continue
 rs=list(csv.DictReader(p.open(encoding='utf-8-sig',newline='')))
 for i,r in enumerate(rs,1):
  s=' '.join(str(v) for v in r.values())
  if any(x in s for x in ['A2','A9','PriSec','WsCalcuLine']):
   rows.append({'source':'recovered/system-coverage/'+name,'row':i,'source_sha256':sha(p),'original_row':json.dumps(r,ensure_ascii=False,sort_keys=True)})
with (out/'residual-gap-input.csv').open('w',encoding='utf-8-sig',newline='') as f:
 w=csv.DictWriter(f,fieldnames=['source','row','source_sha256','original_row']); w.writeheader(); w.writerows(rows)
print(json.dumps({'frozen_count':len(files),'residual_rows':len(rows)},ensure_ascii=False))
