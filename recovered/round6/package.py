from pathlib import Path
p=Path('recovered/round6/build.py');s=p.read_text(encoding='utf-8');needle="(O/'test-inputs.json').write_text";insert="""lib=subprocess.run([csc,'/nologo','/nowarn:162,219','/target:library','/out:'+str((O/'Round6.Recovered.dll').relative_to(ROOT)),'/reference:System.Data.dll','/reference:System.Web.Extensions.dll']+[str(f.relative_to(ROOT)) for f in files if f!=test],capture_output=True)
if lib.returncode:
 print((lib.stdout+lib.stderr).decode('mbcs','replace'));raise SystemExit(lib.returncode)
""";assert needle in s;s=s.replace(needle,insert+needle);p.write_text(s,encoding='utf-8')
p=Path('recovered/round6/reports.py');s=p.read_text(encoding='utf-8').replace('ThrToSoc / 见控件路径','ThrToSoc / tbThrToSoc').replace('SocToTp / 见控件路径','SocToTp / tbSocToTp');p.write_text(s,encoding='utf-8')
