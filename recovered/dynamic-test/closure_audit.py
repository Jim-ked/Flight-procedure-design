"""Freeze generated logs and recheck existing evidence; never loads target code."""
from pathlib import Path
import csv, datetime, hashlib, json, re

BASE = Path(__file__).resolve().parent
REC = BASE.parent
ROOT = REC.parent
LOG = BASE / 'logs'
def sha(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()
def write(path, value):
    path.write_text(json.dumps(value, ensure_ascii=False, indent=2), encoding='utf-8')

manifest = json.loads((LOG/'runtime-copy-manifest.json').read_text(encoding='utf-8'))
checks = []
for row in manifest:
    a, b = Path(row['original']), Path(row['copy'])
    ah, bh = sha(a), sha(b)
    checks.append(dict(original=str(a), copy=str(b), baseline_sha256=row['original_sha256'],
                       original_sha256_now=ah, copy_sha256_now=bh,
                       original_unchanged=ah==row['original_sha256'],
                       copy_unchanged=bh==row['copy_sha256']))

# Keep the live log untouched; freeze once to make line references/hash stable.
frozen = LOG/'observer-closure-snapshot.jsonl'
if not frozen.exists():
    frozen.write_bytes((LOG/'observer.jsonl').read_bytes())
events = [json.loads(line) for line in frozen.read_text(encoding='utf-8').splitlines() if line.strip()]
compile_files = [Path(p) for p in json.loads((LOG/'compile-files.json').read_text(encoding='utf-8'))]
adapters = {'PriSecForm.Events.Recovered.cs', 'TurnAreaForm.Events.Recovered.cs', 'ScreenData.OtherForms.Recovered.cs'}
inputs = [dict(path=str(p.relative_to(REC)).replace('\\','/'), sha256=sha(p),
               status='Compiled with compatibility adapter' if p.name in adapters else 'Compiled') for p in compile_files]
binaries = [dict(path=str(p.relative_to(REC)), sha256=sha(p), bytes=p.stat().st_size)
            for p in sorted((BASE/'bin').glob('*.dll'))]
generated_sources = [dict(path=str(p.relative_to(REC)), sha256=sha(p)) for p in sorted((BASE/'observer').glob('*.cs'))]
dwgs = list((BASE/'dwg').glob('R01-*.dwg'))
desktop = Path.home()/'Desktop/R01-EXP00.dwg'
if desktop.is_file():
    dwgs.append(desktop)
report = dict(utc=datetime.datetime.now(datetime.timezone.utc).isoformat(),
              scope='Existing runtime-copy manifest; no DLL enumeration or target execution',
              baseline_manifest_sha256=sha(LOG/'runtime-copy-manifest.json'),
              original_files=len(checks), original_unchanged=all(x['original_unchanged'] for x in checks),
              copies_unchanged=all(x['copy_unchanged'] for x in checks), checks=checks,
              compile_inputs_current=inputs, binaries=binaries, observer_sources_current=generated_sources,
              provenance_note='Hashes collected at closure, not contemporaneous compiler input attestation. Loaded Observer predates source groupMembers addition.',
              observer_snapshot=dict(path=str(frozen.relative_to(REC)), sha256=sha(frozen), lines=len(events),
                                     first_utc=events[0]['utc'], last_utc=events[-1]['utc']),
              drawings=[dict(path=str(p), sha256=sha(p), bytes=p.stat().st_size) for p in dwgs])
write(LOG/'closure-integrity.json', report)
status = dict(round1='PARTIALLY ACCEPTED', native_compiled=True,
              compile_kind='AutoCAD2026 compatibility compile; API25.1 / CLR8.0.12; original API23.1 not rebuilt',
              native_compiled_files=inputs, target_executed=False, target_executed_definition='Target business methods verified, not image load',
              target_image_loaded=True, target_command_available=False, observer_runtime=True,
              L3=False, L3_definition='A2 / obstacle / A3 original business behavior',
              runtime_status='Runtime validation blocked by host compatibility',
              runtime_cause_confirmed=False, input_queue_contaminated=True,
              diagnostics_loaded=False, diagnostics_executed=False,
              observer_source_matches_loaded_binary=False,
              evidence=['round1-closure.md', 'dynamic-test/compile-validation.md', 'dynamic-test/experiment-index.md',
                        'dynamic-test/logs/closure-integrity.json', 'dynamic-test/logs/NETLOAD-observed.txt'])
write(BASE/'closure-evidence-status.json', status)
print(json.dumps(dict(original_files=len(checks), originals_unchanged=report['original_unchanged'],
                      copies_unchanged=report['copies_unchanged'], compiled_files=len(inputs),
                      observer_frozen_lines=len(events)), ensure_ascii=False))
if not report['original_unchanged']:
    raise SystemExit('Original hash mismatch: inspect closure-integrity.json')
