"""Round 7 only: immutable baseline and B4 source/call discovery. Never runs DLL."""
from pathlib import Path
import csv,json,hashlib,re,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2]; O=ROOT/'recovered/round7'; A=ROOT/'recovered/B4-PbnIls'; E=A/'evidence'; R=ROOT/'reverse-analysis'
E.mkdir(parents=True,exist_ok=True)
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
if not (O/'frozen-inputs.json').exists():
 frozen=[]
 for folder in ['recovered','WsTools-master','reverse-analysis','doc']:
  for p in sorted((ROOT/folder).rglob('*')):
   if p.is_file() and A not in p.parents and O not in p.parents:
    frozen.append(dict(path=str(p.relative_to(ROOT)),size=p.stat().st_size,sha256=hashlib.sha256(p.read_bytes()).hexdigest()))
 (O/'frozen-inputs.json').write_text(json.dumps(frozen,ensure_ascii=False,indent=2),encoding='utf-8')
src=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
def extract(cls):
 a=next(i for i,l in enumerate(src) if re.match(r'\t(?:public|internal) (?:static )?class '+re.escape(cls)+r'(?:\s|:|$)',l));b=next(i for i in range(a+1,len(src)) if src[i]=='\t}')
 (E/(cls+'.source.txt')).write_text('\n'.join(f'{i+1}: {src[i]}' for i in range(a,b+1)),encoding='utf-8')
 return '\n'.join(src[a:b+1])
form=extract('_008B_0096')
proc={m['token']:m for m in rows(R/'04_type-map/methods-only/methods.csv')};calls=rows(R/'05_callgraph/static-sites.csv')
enc=lambda s:re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
tokens={t for t,m in proc.items() if m['name'].split('::')[0].split('.')[-1]==enc('_008B_0096')}
out(E/'form-calls.csv',[c for c in calls if c['caller'] in tokens]);out(E/'events.csv',[x for x in rows(R/'04_type-map/events.csv') if x['class']=='_008B_0096']);out(E/'controls.csv',[x for x in rows(R/'04_type-map/controls.csv') if x['class']=='_008B_0096'])
targets=sorted({c['target_name'] for c in calls if c['caller'] in tokens and c['target'].startswith('0x06')})
(E/'form-targets.txt').write_text('\n'.join(targets),encoding='utf-8')
print('baseline',len(json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8'))),'form methods',len(tokens),'events',len(rows(E/'events.csv')))
print('\n'.join(t for t in targets if '::.ctor' in t))

