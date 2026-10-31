"""Validate packaged Round1 evidence, statuses and links without executing target."""
from pathlib import Path
import csv, hashlib, json, re

REC = Path(__file__).resolve().parents[1]
def read(path):
    return json.loads((REC/path).read_text(encoding='utf-8'))
def sha(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()
def rows(path):
    with (REC/path).open(encoding='utf-8-sig', newline='') as stream:
        return list(csv.DictReader(stream))

required = ['round1-closure.md', 'dynamic-test/environment.md', 'dynamic-test/compile-validation.md',
            'dynamic-test/experiment-index.md', 'dynamic-test/dynamic-static-differences.md',
            'A2-BasicCalculation/WsCalcuLine-schema.md', 'A2-BasicCalculation/cad-output-map.md',
            'A2-BasicCalculation/BasicCalculationForm.Events.Recovered.cs',
            'ObstacleData/WsEntityFrame-schema.md', 'ObstacleData/random-point.md',
            'ObstacleData/xinfo.md', 'ObstacleData/screen-data.md', 'ObstacleData/marker.md',
            'A3-FixTolerance/geometry-chain.md', 'A3-FixTolerance/cad-output-map.md']
for path in required:
    assert (REC/path).is_file(), path
for folder in ['A2-BasicCalculation', 'ObstacleData', 'A3-FixTolerance']:
    for file in ['methods.json', 'events.csv', 'controls.csv', 'calls.csv']:
        assert (REC/folder/'evidence'/file).is_file(), (folder, file)

status = read('native-evidence-status.json')
closure = read('dynamic-test/closure-evidence-status.json')
integrity = read('dynamic-test/logs/closure-integrity.json')
assert closure['round1']=='PARTIALLY ACCEPTED'
assert status['native_compiled'] and closure['native_compiled']
assert not status['target_executed'] and not status['L3']
assert not closure['diagnostics_executed'] and not closure['target_command_available']
assert status['missing_packaged_il']==[]
assert integrity['original_unchanged'] and integrity['copies_unchanged']
assert len(closure['native_compiled_files'])==19
for item in closure['native_compiled_files'] + status['files'] + integrity['binaries'] + integrity['observer_sources_current']:
    assert sha(REC/item['path'])==item['sha256'], item['path']
frozen = integrity['observer_snapshot']
assert sha(REC/frozen['path'])==frozen['sha256']
assert frozen['lines']==len((REC/frozen['path']).read_text(encoding='utf-8').splitlines())

ports = rows('native-port-map.csv')
edges = rows('ObstacleData/evidence/closure-chain-edges.csv')
assert len(ports)==78 and len(edges)==15
by_key = {(x['port_file'], x['port_method']):x for x in ports}
for edge in edges:
    expected = by_key[edge['port_file'], edge['port_method']]
    for field in ['processed_token', 'processed_rva', 'original_token', 'original_rva', 'native_status']:
        assert edge[field]==expected[field], (edge['edge'], field)

links = []
for name in required:
    if not name.endswith('.md'):
        continue
    doc = REC/name
    for target in re.findall(r'\[[^\]]*\]\(([^)]+)\)', doc.read_text(encoding='utf-8')):
        if '://' in target or target.startswith('#'):
            continue
        destination = target.split('#',1)[0]
        assert (doc.parent/destination).exists(), (name, target)
        links.append(dict(document=name, target=target))
assert not (REC/'dynamic-test/logs/EXP-01-RandomPoint.json').exists(), 'Unexpected claimed experiment data'
result = dict(result='PASS', scope='Artifact integrity/status/link audit only; no original business runtime',
              required_files=len(required), method_slices=len(ports), obstacle_edges=len(edges),
              original_files=integrity['original_files'], compiled_files=19, checked_links=len(links),
              files=[dict(path=p, sha256=sha(REC/p)) for p in required])
(REC/'dynamic-test/logs/closure-validation.json').write_text(json.dumps(result,ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({k:v for k,v in result.items() if k!='files'},ensure_ascii=False))
