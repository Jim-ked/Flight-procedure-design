"""Compile and run only recovered Round2 tests; never references target DLL."""
from pathlib import Path
import subprocess,sys,json,hashlib,datetime
ROOT=Path(__file__).resolve().parents[2];B=ROOT/'recovered';OUT=B/'round2'
sys.stdout.reconfigure(encoding='utf-8')
files=[OUT/'Round2.Tests.cs',OUT/'Round2.Artifacts.cs',B/'A2-BasicCalculation/TurnParameterInput.Recovered.cs',B/'ObstacleData/Obstacle.Recovered.cs',B/'ObstacleData/PriSec.Recovered.cs']
for folder in ['GeometryPrimitives','A7-Departure','A8-TurnArea','A10-DmeArc']:
    files+=sorted((B/folder).glob('*.Recovered.cs'))
csc=r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe'
args=[csc,'/nologo','/define:AUTOCAD','/reference:System.Windows.Forms.dll','/reference:System.Drawing.dll','/out:'+str(OUT/'Round2.Tests.exe')]+[str(p) for p in files]
p=subprocess.run(args,capture_output=True)
log=(p.stdout+p.stderr).decode('mbcs','replace')
(OUT/'compile-tests.log').write_text(log,encoding='utf-8');print(log)
if p.returncode:raise SystemExit(p.returncode)
p=subprocess.run([str(OUT/'Round2.Tests.exe')],capture_output=True)
text=(p.stdout+p.stderr).decode('utf-8','replace');print(text)
(OUT/'tests.log').write_text(text,encoding='utf-8')
(OUT/'test-inputs.json').write_text(json.dumps([dict(path=str(f.relative_to(B)),sha256=hashlib.sha256(f.read_bytes()).hexdigest()) for f in files],ensure_ascii=False,indent=2),encoding='utf-8')
history=OUT/'test-history'/datetime.datetime.now(datetime.timezone.utc).strftime('%Y%m%dT%H%M%S%fZ');history.mkdir(parents=True)
for name in ['compile-tests.log','tests.log','test-inputs.json']:(history/name).write_bytes((OUT/name).read_bytes())
raise SystemExit(p.returncode)
