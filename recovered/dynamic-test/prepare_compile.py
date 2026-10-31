"""Read originals, copy runtime, and compile recovery slices; never load target code."""
import csv, hashlib, json, pathlib, shutil, subprocess, sys
ROOT = pathlib.Path(__file__).resolve().parents[2]
BASE = ROOT / 'recovered/dynamic-test'
LOG = BASE / 'logs'
LOG.mkdir(parents=True, exist_ok=True)
(BASE/'dwg').mkdir(exist_ok=True)
sys.path.insert(0, str(ROOT/'reverse-analysis/tools/python'))
import dnfile
import pefile
source = ROOT/'WsTools-master/WindSpiral2026'
dest = BASE/'WindSpiral2026-runtime'
manifest = []
for path in sorted(source.rglob('*')):
    if not path.is_file(): continue
    out = dest/path.relative_to(source)
    out.parent.mkdir(parents=True, exist_ok=True)
    before = hashlib.sha256(path.read_bytes()).hexdigest()
    if not out.exists(): shutil.copy2(path, out)
    copied = hashlib.sha256(out.read_bytes()).hexdigest()
    manifest.append(dict(original=str(path), copy=str(out), original_sha256=before, copy_sha256=copied, identical=before==copied))
(LOG/'runtime-copy-manifest.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2),encoding='utf8')
pe = dnfile.dnPE(str(source/'WindSpiralBasic.dll'))
framework_strings = []
for row in pe.net.mdtables.CustomAttribute:
    b = bytes(row.Value.value)
    if b'.NETFramework' in b: framework_strings.append(dict(blob_hex=b.hex(), text=b.decode('utf8','backslashreplace')))
info=dict(machine=hex(pe.FILE_HEADER.Machine), machine_meaning='I386 PE container; use CLR flags for AnyCPU vs x86', pe_magic=hex(pe.OPTIONAL_HEADER.Magic), clr_version=pe.net.metadata.struct.Version.rstrip(b'\0').decode(), corflags=str(pe.net.Flags), framework_attribute_blobs=framework_strings)
(LOG/'original-pe.json').write_text(json.dumps(info,ensure_ascii=False,indent=2),encoding='utf8')
cad = pathlib.Path(r'D:\SOFT\CAD\AutoCAD 2026')
refs = sorted(pathlib.Path(r'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.12').glob('*.dll'))
refs += sorted(pathlib.Path(r'C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\8.0.12').glob('*.dll'))
# Native runtime binaries are not CLI metadata. Only managed files become references.
managed=[]
for f in refs:
    try:
        p=pefile.PE(str(f),fast_load=True)
        if p.OPTIONAL_HEADER.DATA_DIRECTORY[14].VirtualAddress: managed.append(f)
        p.close()
    except Exception: pass
managed += [cad/x for x in ('acmgd.dll','acdbmgd.dll','accoremgd.dll')]
csc = r'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe'
def compile_set(name, files, defines):
    out=BASE/'bin'/name
    out.parent.mkdir(exist_ok=True)
    args=['/nostdlib+','/target:library','/langversion:5','/define:'+defines,'/out:"'+str(out)+'"']
    args+=['/reference:"'+str(p)+'"' for p in managed]
    args+=['"'+str(p)+'"' for p in files]
    rsp=BASE/(name+'.rsp')
    rsp.write_text('\n'.join(args),encoding='utf-8-sig')
    result=subprocess.run([csc,'/noconfig','@'+str(rsp)],capture_output=True)
    text=(result.stdout+result.stderr).decode('mbcs','replace')
    (LOG/(name+'.compile.log')).write_text(text,encoding='utf8')
    print(name, 'exit', result.returncode, '\n'+text[:12000],flush=True)
    return result.returncode
files=[ROOT/'recovered/CadInteraction.Recovered.cs']
for folder in ('A2-BasicCalculation','ObstacleData','A3-FixTolerance'):
    files += sorted((ROOT/'recovered'/folder).glob('*.Recovered.cs'))
if '--observer-only' not in sys.argv and '--diagnostics-only' not in sys.argv:
    compile_set('Recovered.Native.Validation.dll',files,'AUTOCAD;ACAD2026_TEST')
    (LOG/'compile-files.json').write_text(json.dumps([str(p) for p in files],ensure_ascii=False,indent=2),encoding='utf8')
observer=BASE/'observer/WsToolsObserver.cs'
if observer.exists() and '--diagnostics-only' not in sys.argv: compile_set('WsToolsObserver.dll',[observer],'ACAD2026_TEST')
diagnostics=BASE/'observer/WsToolsHostDiagnostics.cs'
if diagnostics.exists(): compile_set('WsToolsHostDiagnostics.dll',[diagnostics],'ACAD2026_TEST')
