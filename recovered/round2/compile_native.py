"""Read frozen Round1 response file and add Round2; compile only, never NETLOAD."""
from pathlib import Path
import subprocess,json,hashlib,sys
ROOT=Path(__file__).resolve().parents[2];B=ROOT/'recovered';O=B/'round2'
sys.stdout.reconfigure(encoding='utf-8')
old=B/'dynamic-test/Recovered.Native.Validation.dll.rsp'
lines=old.read_text(encoding='utf-8-sig').splitlines()
lines=[x for x in lines if not x.startswith('/out:')]
files=[]
for folder in ['GeometryPrimitives','A7-Departure','A8-TurnArea','A10-DmeArc']:
    files+=sorted((B/folder).glob('*.Recovered.cs'))
lines+=['/out:"'+str(O/'Recovered.Round2.Compatibility.dll')+'"']+['"'+str(f)+'"' for f in files]
rsp=O/'Recovered.Round2.Compatibility.rsp';rsp.write_text('\n'.join(lines),encoding='utf-8-sig')
p=subprocess.run([r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe','/noconfig','@'+str(rsp)],capture_output=True)
log=(p.stdout+p.stderr).decode('mbcs','replace');print(log)
(O/'compile-native.log').write_text('ACAD2026 compatibility compile; not original API23.1 verification; no NETLOAD\n'+log,encoding='utf-8')
(O/'compile-native-inputs.json').write_text(json.dumps([dict(path=str(f.relative_to(B)),sha256=hashlib.sha256(f.read_bytes()).hexdigest()) for f in [old,rsp]+files],ensure_ascii=False,indent=2),encoding='utf-8')
raise SystemExit(p.returncode)
