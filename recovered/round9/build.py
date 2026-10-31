from pathlib import Path
import subprocess,json,hashlib,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round9';A=ROOT/'recovered/A4-NavAidProtection'
files=sorted(A.glob('*.Recovered.cs'))+[ROOT/'recovered/GeometryPrimitives/Geometry.Recovered.cs'];test=O/'Round9.Tests.cs'
csc=r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe';logs=[]
for kind,target,inputs in [('library','Round9.Recovered.dll',files),('exe','Round9.Tests.exe',files+[test])]:
 p=subprocess.run([csc,'/nologo','/nowarn:162,219','/reference:System.Web.Extensions.dll','/target:'+kind,'/out:recovered/round9/'+target]+[str(f.relative_to(ROOT)) for f in inputs],capture_output=True)
 logs.append((p.stdout+p.stderr).decode('mbcs','replace'));(O/'compile-tests.log').write_text('\n'.join(logs),encoding='utf-8')
 if p.returncode:print(logs[-1]);raise SystemExit(p.returncode)
p=subprocess.run([str(O/'Round9.Tests.exe'),str(O/'fixtures')],capture_output=True,timeout=45);log=(p.stdout+p.stderr).decode('utf-8','replace');(O/'tests.log').write_text('E3 independent recovery source; no target DLL/AutoCAD execution.\n'+log,encoding='utf-8');print(log)
if p.returncode:raise SystemExit(p.returncode)
(O/'test-inputs.json').write_text(json.dumps([dict(path=str(f.relative_to(ROOT)),sha256=hashlib.sha256(f.read_bytes()).hexdigest()) for f in files+[test]],ensure_ascii=False,indent=2),encoding='utf-8')
