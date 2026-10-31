from pathlib import Path
import subprocess,hashlib,json,sys,csv,time
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round5';A=ROOT/'recovered/B5-PbnDeparture'
files=sorted(A.glob('*.Recovered.cs'))+[O/'Round5.Tests.cs']
files += [ROOT/('recovered/A6-Template/'+x+'.Recovered.cs') for x in ['TurnInput','TemplatePoint','LineCarrier','Spiral86','PointLists','VectorCarrier','SideClassifier','Scalar']]
csc=r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe'
p=subprocess.run([csc,'/nologo','/nowarn:162,219','/reference:System.Windows.Forms.dll','/reference:System.Web.Extensions.dll','/reference:System.Data.dll','/out:'+str((O/'Round5.Tests.exe').relative_to(ROOT))]+[str(f.relative_to(ROOT)) for f in files],capture_output=True)
log=(p.stdout+p.stderr).decode('mbcs','replace');(O/'compile-tests.log').write_text(log,encoding='utf-8');print(log)
if p.returncode:raise SystemExit(p.returncode)
(O/'test-inputs.json').write_text(json.dumps([dict(path=str(f.relative_to(ROOT)),sha256=hashlib.sha256(f.read_bytes()).hexdigest()) for f in files],ensure_ascii=False,indent=2),encoding='utf-8')
ids=['form','helpers','hull-collinear','hull-same-reference','hull-coincident','deg-alt-zero']
for mode in ['alt','fo']:
 for side in ['L','R']:
  ids += [f'{mode}_12000_{side}_N',f'{mode}_12000_{side}_E']
 for variant in ['ias','wind','bank','pdg','after','near','wide']:
  ids.append(f'{mode}_12000_L_N_{variant}')
 for station in ['6351.949','6351.95','6351.951','13263.709','13263.71','13263.711','1000','-1000']:
  ids.append(f'{mode}_{station}_L_N')
 for variant in ['c6low','c6hi','c6upperlow','c6upperhi']:
  ids.append(f'{mode}_12000_L_N_{variant}')
ids+=['fo_12000_L_N_navlow','fo_12000_L_N_navhi']
log='Independent recovered C# tests; no target DLL loaded.\n';index=[];code=0
for fixture in ids:
 started=time.monotonic();timeout=3 if fixture.startswith('hull-') else 8
 try:
  p=subprocess.run([str(O/'Round5.Tests.exe'),str(O/'fixtures'),fixture],capture_output=True,timeout=timeout)
  msg=(p.stdout+p.stderr).decode('utf-8','replace');status='PASS' if p.returncode==0 else 'FAIL'
  if p.returncode:code=1
 except subprocess.TimeoutExpired:
  status='LEGACY_TIMEOUT' if fixture.startswith(('hull-','deg-')) else 'TIMEOUT';msg=f'{status} {fixture} after {timeout}s\n'
  if status=='TIMEOUT':code=1
  (O/'fixtures').mkdir(exist_ok=True)
  (O/'fixtures'/f'{fixture}.json').write_text(json.dumps(dict(id=fixture,status=status,timeout_seconds=timeout,evidence='Recovery subprocess terminated; no original DLL execution'),indent=2),encoding='utf-8')
 log+=msg;print(next((s for s in reversed(msg.splitlines()) if s.strip()),''),flush=True)
 output=O/'fixtures'/f'{fixture}.json'
 index.append(dict(id=fixture,status=status,seconds=round(time.monotonic()-started,3),path=str(output.relative_to(ROOT)),sha256=hashlib.sha256(output.read_bytes()).hexdigest() if output.exists() else ''))
with (O/'fixture-index.csv').open('w',encoding='utf-8-sig',newline='') as f:
 w=csv.DictWriter(f,fieldnames=list(index[0]));w.writeheader();w.writerows(index)
log+=f'fixtures={len(index)} failures={sum(x["status"] in ["FAIL","TIMEOUT"] for x in index)} legacy_timeouts={sum(x["status"]=="LEGACY_TIMEOUT" for x in index)}\n'
if code==0:
 p=subprocess.run([sys.executable,str(O/'postcheck.py')],capture_output=True)
 msg=(p.stdout+p.stderr).decode('utf-8','replace');log+=msg;print(msg.strip());code=p.returncode
(O/'tests.log').write_text(log,encoding='utf-8');raise SystemExit(code)
