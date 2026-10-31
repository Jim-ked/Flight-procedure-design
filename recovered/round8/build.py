from pathlib import Path
import subprocess,hashlib,json,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round8';A=ROOT/'recovered/A5-PrecisionApproach'
files=sorted(A.glob('*.Recovered.cs'))
files += sorted((ROOT/'recovered/B4-PbnIls').glob('*.Recovered.cs'))
files += [ROOT/('recovered/A6-Template/'+x+'.Recovered.cs') for x in ['TurnInput','TemplatePoint','LineCarrier','Spiral86','PointLists','VectorCarrier','SideClassifier','Scalar']]
files += [ROOT/('recovered/B5-PbnDeparture/'+x+'.Recovered.cs') for x in ['RunwayFrame','FrameHelpers']]
csc=r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe'
args=[csc,'/nologo','/nowarn:162,219','/reference:System.Data.dll','/reference:System.Web.Extensions.dll','/reference:System.Windows.Forms.dll']
test=O/'Round8.Tests.cs'
for kind,target,inputs in [('library','Round8.Recovered.dll',files)]+([('exe','Round8.Tests.exe',files+[test])] if test.exists() else []):
 p=subprocess.run(args+['/target:'+kind,'/out:recovered/round8/'+target]+[str(f.relative_to(ROOT)) for f in inputs],capture_output=True)
 log=(p.stdout+p.stderr).decode('mbcs','replace');(O/'compile-tests.log').write_text(log,encoding='utf-8');print(log)
 if p.returncode:raise SystemExit(p.returncode)
if test.exists():
 p=subprocess.run([str(O/'Round8.Tests.exe'),str(O/'fixtures')],capture_output=True,timeout=45)
 log=(p.stdout+p.stderr).decode('utf-8','replace');(O/'tests.log').write_text('E3 independent source checks; no target DLL or AutoCAD execution.\n'+log,encoding='utf-8');print(log)
 if p.returncode:raise SystemExit(p.returncode)
(O/'test-inputs.json').write_text(json.dumps([dict(path=str(f.relative_to(ROOT)),sha256=hashlib.sha256(f.read_bytes()).hexdigest()) for f in files+([test] if test.exists() else [])],ensure_ascii=False,indent=2),encoding='utf-8')
