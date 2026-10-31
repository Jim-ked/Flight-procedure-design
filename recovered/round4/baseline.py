from pathlib import Path
import csv,json,hashlib,re
ROOT=Path.cwd(); B=ROOT/'recovered'; R=ROOT/'reverse-analysis'; O=B/'round4'; E=B/'A6-Template/evidence'
def read(p):
 with p.open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
def savecsv(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
# Freeze all pre-existing recovered outputs, plus the original entire input tree.
freeze=[]
for tree in [B,ROOT/'WsTools-master']:
 for p in tree.rglob('*'):
  if not p.is_file() or O in p.parents or B/'A6-Template' in p.parents:continue
  freeze.append(dict(path=str(p.relative_to(ROOT)),size=p.stat().st_size,sha256=hashlib.sha256(p.read_bytes()).hexdigest()))
p=O/'frozen-inputs.json'
if not p.exists():p.write_text(json.dumps(freeze,ensure_ascii=False,indent=2),encoding='utf-8')
raw={x['token']:x for x in read(R/'04_type-map/raw/methods.csv')}; proc={x['token']:x for x in read(R/'04_type-map/methods-only/methods.csv')}; mp={x['processed_token']:x['original_token'] for x in read(R/'04_type-map/tool-token-map.csv') if x['kind']=='Method'}
loc=read(R/'04_type-map/method-source-locations.csv'); calls=read(R/'05_callgraph/static-sites.csv'); src=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
evs=[x for x in read(R/'04_type-map/events.csv') if x['ui_name']=='FormTemplate']; savecsv(E/'events.csv',evs); savecsv(E/'controls.csv',[x for x in read(R/'04_type-map/controls.csv') if x['ui_name']=='FormTemplate'])
def enc(s):return re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
# Form plus its actual business constructor types and geometry helpers.
classes=['_0089_0092','_0089_0098','_0089_009A','_0089_009C','_008B_0086','_008B_0088']
tokens={t for t,m in proc.items() if m['name'].split('::')[0].split('.')[-1] in set(map(enc,classes))}
methods=[]
for t in sorted(tokens):
 old=mp[t];l=next((x for x in loc if x['tokens']==t),{})
 methods.append(dict(processed_token=t,original_token=old,original_rva=raw[old]['rva'],processed_rva=proc[t]['rva'],name=proc[t]['name'],line=l.get('line'),source=l.get('source'),il_sha256=proc[t]['il_sha256']))
savecsv(E/'methods.csv',methods); savecsv(E/'calls.csv',[x for x in calls if x['caller'] in tokens])
for cls in classes:
 start=next(i for i,l in enumerate(src) if re.match(r'\t(?:public|internal) (?:static )?class '+cls+r'(?:\s|:|$)',l));end=next(i for i in range(start+1,len(src)) if src[i]=='\t}')
 (E/(cls+'.source.txt')).write_text('\n'.join(f'{i+1}: {src[i]}' for i in range(start,end+1)),encoding='utf-8')
il=(R/'04_type-map/methods-only/independent-il.txt').read_text(encoding='utf-8')
for m in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',il,re.M|re.S):
 if '0x'+m[1] in tokens:(E/('0x'+m[1]+'.il.txt')).write_text(m[0],encoding='utf-8')
print('freeze',len(freeze),'methods',len(methods),'events',len(evs));print('\n'.join(str(x) for x in evs))
