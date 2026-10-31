from pathlib import Path
import json,math,csv,hashlib,sys
O=Path(__file__).resolve().parent;D=O/'fixtures';checks=[]
def read(id):return json.loads((D/(id+'.json')).read_text(encoding='utf-8'))
def check(b,label):
 checks.append(dict(check=label,passed=bool(b)))
 if not b:raise AssertionError(label)
def pts(r):return [(p['X'],p['Y']) for c in r['cad'] for p in c['Points'] or []]
for mode in ['alt','fo']:
 a=read(f'{mode}_12000_L_N')['result'];b=read(f'{mode}_12000_R_N')['result'];x=pts(a);y=[(x,-y) for x,y in pts(b)]
 residual=max(max(min(math.hypot(px-qx,py-qy) for qx,qy in y) for px,py in x),max(min(math.hypot(px-qx,py-qy) for qx,qy in x) for px,py in y))
 check(residual<1e-6,mode+' nominal mirrored CAD vertex sets within 1e-6m');checks[-1]['residual_m']=residual
 for variant in ['ias','wind','bank','pdg','near','wide']:
  v=read(f'{mode}_12000_L_N_{variant}')['result'];check(pts(v)!=x,mode+' '+variant+' changes geometry')
 if mode=='alt':check(len(read('alt_12000_L_E')['result']['cad'])>len(a['cad']),'early flag adds geometry')
 check(read(f'{mode}_12000_L_N_c6low')['expected'],mode+' C6 lower boundary rejects')
 check(not read(f'{mode}_12000_L_N_c6hi')['expected'],mode+' C6 upper boundary computes')
 # Hull order/count is deliberately not required to match between mirrored runs.
for p in D.glob('*.json'):
 r=json.loads(p.read_text(encoding='utf-8')).get('result')
 if isinstance(r,dict) and 'cad' in r:check(all(math.isfinite(v) for point in pts(r) for v in point),p.stem+' finite CAD XY')
col=read('hull-collinear')['result'];check(max(p['X'] for p in col)==1,'legacy hull loses farthest collinear point 2')
form=read('form')['result'];check(len(form['loaded'])==5 and form['input'][5]['Z']==5000,'dangerous sixth excluded before any available UI evaluation')
check(form['sixthDirect']['required']>.8,'direct arithmetic evaluator has no five-item limit')
summary=dict(evidence='Recovered code only; no original DLL oracle',postcheck_count=len(checks),checks=checks,assertions=sum(read(p.stem).get('assertions',0) for p in D.glob('*.json')))
(O/'postcheck-results.json').write_text(json.dumps(summary,ensure_ascii=False,indent=2),encoding='utf-8')
print('PASS postchecks',len(checks),'C# assertions',summary['assertions'])
