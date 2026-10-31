"""Compile only independent recovered C#; original DLL never loaded."""
from pathlib import Path
import subprocess,json,hashlib,sys
from datetime import datetime
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round4';A=ROOT/'recovered/A6-Template'
history=O/'test-history'/datetime.now().strftime('%Y%m%d-%H%M%S');history.mkdir(parents=True)
for name in ['compile-tests.log','tests.log','test-inputs.json']:
 if (O/name).exists():(history/name).write_bytes((O/name).read_bytes())
files=sorted(A.glob('*.Recovered.cs'))+[O/'Round4.Tests.cs',ROOT/'recovered/GeometryPrimitives/TurnParameter.Recovered.cs',ROOT/'recovered/GeometryPrimitives/WindSpiral.Recovered.cs']
csc=r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe'
p=subprocess.run([csc,'/nologo','/nowarn:162,219','/reference:System.Windows.Forms.dll','/reference:System.Web.Extensions.dll','/out:'+str((O/'Round4.Tests.exe').relative_to(ROOT))]+[str(f.relative_to(ROOT)) for f in files],capture_output=True)
log=(p.stdout+p.stderr).decode('mbcs','replace');(O/'compile-tests.log').write_text(log,encoding='utf-8');print(log)
if p.returncode:raise SystemExit(p.returncode)
(O/'test-inputs.json').write_text(json.dumps([dict(path=str(f.relative_to(ROOT)),sha256=hashlib.sha256(f.read_bytes()).hexdigest()) for f in files],ensure_ascii=False,indent=2),encoding='utf-8')
try:
 p=subprocess.run([str(O/'Round4.Tests.exe'),str(O/'fixtures')],capture_output=True,timeout=35)
 log=(p.stdout+p.stderr).decode('utf-8','replace');code=p.returncode
except subprocess.TimeoutExpired as e:
 log=(e.stdout or b'').decode('utf-8','replace')+'\nTIMEOUT: recovery runner stopped at 35 seconds.\n';code=1
(O/'tests.log').write_text(log,encoding='utf-8');print(log);raise SystemExit(code)
