"""Query existing static indices only; never loads target or overwrites Round1."""
from pathlib import Path
import csv, json, re, hashlib
ROOT=Path(__file__).resolve().parents[2]
R=ROOT/'reverse-analysis'
REC=ROOT/'recovered'
def rows(name):
    with (R/name).open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
events=rows('04_type-map/events.csv')
locs=rows('04_type-map/method-source-locations.csv')
for ui in ['FormDepartureEvl','FormTurnAreaEvl','FormDmeEvl']:
    records=[e for e in events if e['ui_name']==ui]
    print(ui, sorted({e['class'] for e in records}))
    print([(e['control_name'],e['event'],e['handler_tokens']) for e in records if e['event'] in ['Click','CellClick','TextChanged']])
for cls in ['_0088_0093','_0088_0095','_008A_0095','_008E_0097']:
    print(cls,[(x['method'],x['tokens'],x['line']) for x in locs if x['class']==cls])
freeze=REC/'round2/round1-frozen-manifest.json'
if not freeze.exists():
    paths=[p for p in REC.rglob('*') if p.is_file() and 'round2' not in p.relative_to(REC).parts]
    freeze.write_text(json.dumps([dict(path=str(p.relative_to(REC)),sha256=hashlib.sha256(p.read_bytes()).hexdigest()) for p in paths],ensure_ascii=False,indent=2),encoding='utf-8')
    print('Frozen prior recovered artifact paths/hashes:',len(paths))
