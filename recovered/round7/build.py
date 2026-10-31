from pathlib import Path
import subprocess,hashlib,json,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round7';A=ROOT/'recovered/B4-PbnIls'
files=sorted(A.glob('*.Recovered.cs'))
files += [ROOT/('recovered/A6-Template/'+x+'.Recovered.cs') for x in ['TurnInput','TemplatePoint','LineCarrier','Spiral86','PointLists','VectorCarrier','SideClassifier','Scalar']]
files += [ROOT/('recovered/B5-PbnDeparture/'+x+'.Recovered.cs') for x in ['RunwayFrame','FrameHelpers']]
test=O/'Round7.Tests.cs'
csc=r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe'
args=[csc,'/nologo','/nowarn:162,219','/reference:System.Data.dll','/reference:System.Web.Extensions.dll','/reference:System.Windows.Forms.dll']
lib=subprocess.run(args+['/target:library','/out:recovered/round7/Round7.Recovered.dll']+[str(f.relative_to(ROOT)) for f in files],capture_output=True)
log=(lib.stdout+lib.stderr).decode('mbcs','replace');(O/'compile-tests.log').write_text(log,encoding='utf-8');print(log)
if lib.returncode:raise SystemExit(lib.returncode)
if test.exists():
 p=subprocess.run(args+['/out:recovered/round7/Round7.Tests.exe']+[str(f.relative_to(ROOT)) for f in files+[test]],capture_output=True)
 log=(p.stdout+p.stderr).decode('mbcs','replace');(O/'compile-tests.log').write_text(log,encoding='utf-8');print(log)
 if p.returncode:raise SystemExit(p.returncode)
 p=subprocess.run([str(O/'Round7.Tests.exe'),str(O/'fixtures')],capture_output=True,timeout=45)
 log=(p.stdout+p.stderr).decode('utf-8','replace');(O/'tests.log').write_text('E3 independent recovery checks; no original DLL or AutoCAD execution.\n'+log,encoding='utf-8');print(log)
 if p.returncode:raise SystemExit(p.returncode)
(O/'test-inputs.json').write_text(json.dumps([dict(path=str(f.relative_to(ROOT)),sha256=hashlib.sha256(f.read_bytes()).hexdigest()) for f in files+([test] if test.exists() else [])],ensure_ascii=False,indent=2),encoding='utf-8')
