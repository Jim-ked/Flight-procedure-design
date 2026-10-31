from pathlib import Path
import csv,json,hashlib,re,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2]; B=ROOT/'recovered'; R=ROOT/'reverse-analysis'; O=B/'round5'; A=B/'B5-PbnDeparture'; E=A/'evidence'
E.mkdir(parents=True,exist_ok=True)
def rows(p):
 with p.open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
def csvout(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
freeze=[]
for tree in [B,ROOT/'WsTools-master',R]:
 for p in tree.rglob('*'):
  if not p.is_file() or O in p.parents or A in p.parents:continue
  freeze.append(dict(path=str(p.relative_to(ROOT)),size=p.stat().st_size,sha256=hashlib.sha256(p.read_bytes()).hexdigest()))
if not (O/'frozen-inputs.json').exists():(O/'frozen-inputs.json').write_text(json.dumps(freeze,ensure_ascii=False,indent=2),encoding='utf-8')
raw={x['token']:x for x in rows(R/'04_type-map/raw/methods.csv')};proc={x['token']:x for x in rows(R/'04_type-map/methods-only/methods.csv')};mp={x['processed_token']:x['original_token'] for x in rows(R/'04_type-map/tool-token-map.csv') if x['kind']=='Method'}
loc=rows(R/'04_type-map/method-source-locations.csv');calls=rows(R/'05_callgraph/static-sites.csv')
classes=['_008B_0094','_008C_0091','_008C_0093']
def enc(s):return re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
tokens={t for t,m in proc.items() if m['name'].split('::')[0].split('.')[-1] in set(map(enc,classes))}
methods=[]
for t in sorted(tokens):
 old=mp[t];l=next((x for x in loc if t in x['tokens'].split(';')), {})
 methods.append(dict(processed_token=t,original_token=old,original_rva=raw[old]['rva'],processed_rva=proc[t]['rva'],name=proc[t]['name'],source=l.get('source',''),line=l.get('line',''),raw_status=raw[old]['status'],raw_size=raw[old]['code_size'],processed_size=proc[t]['code_size'],il_sha256=proc[t]['il_sha256']))
csvout(E/'methods.csv',methods);csvout(E/'calls.csv',[x for x in calls if x['caller'] in tokens])
csvout(E/'events.csv',[x for x in rows(R/'04_type-map/events.csv') if x['class']==classes[0]])
csvout(E/'controls.csv',[x for x in rows(R/'04_type-map/controls.csv') if x['class']==classes[0]])
for tier,key in [('methods-only','processed_token'),('raw','original_token')]:
 d=E/('processed' if tier=='methods-only' else 'raw');d.mkdir(exist_ok=True)
 il=(R/('04_type-map/'+tier+'/independent-il.txt')).read_text(encoding='utf-8')
 for m in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',il,re.M|re.S):
  if '0x'+m[1] in {x[key] for x in methods}:(d/('0x'+m[1]+'.il.txt')).write_text(m[0],encoding='utf-8')
src=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
for cls in classes:
 a=next(i for i,l in enumerate(src) if re.match(r'\t(?:public|internal) (?:static )?class '+cls+r'(?:\s|:|$)',l));b=next(i for i in range(a+1,len(src)) if src[i]=='\t}')
 (E/(cls+'.source.txt')).write_text('\n'.join(f'{i+1}: {src[i]}' for i in range(a,b+1)),encoding='utf-8')
print('baseline',len(freeze),'methods',len(methods),'events',len(rows(E/'events.csv')))
