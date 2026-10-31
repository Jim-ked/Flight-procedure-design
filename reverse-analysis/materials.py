"""Read-only evidence extraction; all generated files stay under reverse-analysis."""
from pathlib import Path
import sys, json, sqlite3, csv, xml.etree.ElementTree as ET
ROOT = Path(__file__).resolve().parent
sys.path.insert(0, str(ROOT / 'tools/python'))
import rarfile
from pypdf import PdfReader

SRC = ROOT / '01_original/WsTools-master'
OUT = ROOT / '00_manifest/materials'
OUT.mkdir(parents=True, exist_ok=True)
def save(name, data):
    (OUT / name).write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding='utf-8')

db = SRC / 'WindSpiral2026/oas.db'
con = sqlite3.connect(db.as_uri() + '?mode=ro&immutable=1', uri=True)
schema = con.execute('select type,name,tbl_name,sql from sqlite_master order by type,name').fetchall()
save('sqlite-schema.json', schema)
tables = {}
for kind, name, _, sql in schema:
    if kind != 'table': continue
    quoted = '"' + name.replace('"', '""') + '"'
    cur = con.execute('select * from ' + quoted)
    cols = [c[0] for c in cur.description]
    rows = cur.fetchall()
    tables[name] = {'columns': cols, 'count': len(rows), 'sample': rows[:5],
                    'column_distinct_counts': {c: len(set(r[i] for r in rows)) for i,c in enumerate(cols)}}
    with (OUT / ('sqlite-' + name + '.csv')).open('w', newline='', encoding='utf-8-sig') as f:
        w = csv.writer(f); w.writerow(cols); w.writerows(rows)
save('sqlite-tables.json', tables)
save('sqlite-integrity.json', con.execute('pragma integrity_check').fetchall())
con.close()

archives = {}
for path in sorted(SRC.rglob('*.rar')):
    try:
        with rarfile.RarFile(path) as arc:
            archives[str(path.relative_to(SRC))] = [
                {'name': x.filename, 'size': x.file_size, 'compressed': x.compress_size,
                 'is_directory': x.isdir(), 'needs_password': x.needs_password()}
                for x in arc.infolist()]
    except Exception as exc: archives[str(path.relative_to(SRC))] = {'error': str(exc)}
save('archives.json', archives)

spec = ROOT / '01_original/supplied/航空器运行目视和仪表飞行程序设计规范.pdf'
reader = PdfReader(spec)
save('spec-metadata.json', {'pages': len(reader.pages), 'metadata': dict(reader.metadata or {})})
(OUT / 'spec-first-pages.txt').write_text('\n'.join(
    f'\n=== PDF page {i+1} ===\n' + (reader.pages[i].extract_text() or '')
    for i in range(min(8,len(reader.pages)))), encoding='utf-8')

xml = ET.parse(SRC / 'WindSpiral2026/config.xml').getroot()
save('config-controls.json', {form.tag: {node.tag: node.text for node in form} for form in xml})
api = ET.parse(SRC / 'WindSpiral2026/System.Data.SQLite.xml').getroot()
members = api.findall('./members/member')
save('sqlite-doc-index.json', {'assembly': api.findtext('./assembly/name'), 'member_count': len(members),
    'members': [{'name': m.attrib.get('name'), 'text': ' '.join(''.join(m.itertext()).split())} for m in members]})
print(json.dumps({'tables': {k:v['count'] for k,v in tables.items()},
    'archives': {k:len(v) for k,v in archives.items()}, 'spec_pages':len(reader.pages),
    'config_forms':len(xml), 'sqlite_doc_members':len(members)},ensure_ascii=False))
