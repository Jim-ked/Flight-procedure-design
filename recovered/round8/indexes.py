from pathlib import Path
import csv,re,json,sys,hashlib
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];R=ROOT/'reverse-analysis';O=ROOT/'recovered/round8';A=ROOT/'recovered/A5-PrecisionApproach';E=A/'evidence'
def rows(p):
 with p.open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
def out(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
proc={x['token']:x for x in rows(R/'04_type-map/methods-only/methods.csv')};raw={x['token']:x for x in rows(R/'04_type-map/raw/methods.csv')}
maps={x['processed_token']:x for x in rows(R/'04_type-map/tool-token-map.csv') if x['kind']=='Method'};loc=rows(R/'04_type-map/method-source-locations.csv');calls=rows(R/'05_callgraph/static-sites.csv')
def enc(s):return re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
cls=['_0089_008C','_0089_0096','_008A_0097','_008A_0099','_008A_009B','_008A_0093','_008A_0091','_008A_008D','_008A_008B','_008E_0097','_008E_009B','_008F_008C','_008F_008E','_008F_0090','_008F_0092']
# Exact nested type identity, never an assumed adjacent token range.
core={t for t,m in proc.items() if m['name'].split('::')[0].split('.')[-1] in set(map(enc,cls[:7]))}
# Only A5 core and actual direct internal dependencies, plus downstream writer/config/parser methods.
tokens=core|{x['target'] for x in calls if x['caller'] in core and x['target'].startswith('0x06')}
tokens|={t for t,m in proc.items() if m['name'].split('::')[0].split('.')[-1] in set(map(enc,cls[7:]))}
tokens|={'0x0600001A','0x0600006A','0x060000AC','0x060000AD','0x06000087','0x06000089','0x0600012A','0x0600012D','0x06000134','0x0600010D','0x0600012F','0x0600009C','0x0600009E'}
# Bounded A5 comparison: shared parameter loader and corrections only.
tokens|={f'0x06000{i:03X}' for i in range(0x409,0x40D)}
# Persistence helper closure and list writer; never expands into another UI/business module.
allowed={enc(c) for c in ['_0097','_008B','_008D']}
for _ in range(2):
 tokens|={x['target'] for x in calls if x['caller'] in tokens and x['target'].startswith('0x06') and proc.get(x['target'],{}).get('name','').split('::')[0].split('.')[-1] in allowed}
ms=[]
for t in sorted(tokens):
 if t not in maps:continue
 old=maps[t]['original_token'];l=next((x for x in loc if t in x['tokens'].split(';')), {})
 ms.append(dict(processed_token=t,original_token=old,original_rva=raw[old]['rva'],processed_rva=proc[t]['rva'],name=proc[t]['name'],signature=maps[t]['description'],source=l.get('source',''),line=l.get('line',''),raw_status=raw[old]['status'],raw_size=raw[old]['code_size'],processed_size=proc[t]['code_size'],raw_il_sha256=raw[old]['il_sha256'],processed_il_sha256=proc[t]['il_sha256'],scope='A5 core' if t in core else 'shared dependency evidence'))
out(E/'method-index.csv',ms);meta={m['processed_token']:m for m in ms}
allil={}
for tier,key in [('methods-only','processed_token'),('raw','original_token')]:
 d=E/('processed' if tier=='methods-only' else 'raw');d.mkdir(exist_ok=True)
 il=(R/('04_type-map/'+tier+'/independent-il.txt')).read_text(encoding='utf-8')
 selected={x[key] for x in ms}
 for m in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',il,re.M|re.S):
  t='0x'+m[1]
  if t in selected:(d/(t+'.il.txt')).write_text(m[0],encoding='utf-8')
  if tier=='methods-only':allil[t]=m[0]
out(E/'direct-calls.csv',[x for x in calls if x['caller'] in tokens])
flow=[];conditions=[]
for t in tokens:
 for line in allil.get(t,'').splitlines():
  m=re.match(r'(IL_\w+): (\w+(?:\.\w+)?) (.*)',line)
  if not m:continue
  off,op,operand=m.groups()
  if op in ['ldfld','ldsfld','ldflda','stfld','stsfld']:flow.append(dict(method=t,original=meta[t]['original_token'],offset=off,opcode=op,field=operand))
  if op.startswith(('bge','bgt','ble','blt','beq','bne','brtrue','brfalse','switch')):conditions.append(dict(method=t,offset=off,opcode=op,target=operand))
out(E/'field-flow.csv',flow);out(E/'branch-sites.csv',conditions)

source=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
for c in cls:
 a=next(i for i,l in enumerate(source) if re.match(r'\t(?:public|internal) (?:static )?class '+re.escape(c)+r'(?:\s|:|$)',l));b=next(i for i in range(a+1,len(source)) if source[i]=='\t}')
 (E/(c+'.source.txt')).write_text('\n'.join(f'{i+1}: {source[i]}' for i in range(a,b+1)),encoding='utf-8')
props=[]
for l in (E/'_0089_008C.source.txt').read_text(encoding='utf-8').splitlines():
 m=re.match(r'(\d+):\s+(_\w+)\.(Text|Visible|Enabled|SelectedIndex|ReadOnly|Checked|Name|TabIndex) = (.*);',l)
 if m:props.append(dict(line=m[1],field=m[2],property=m[3],value=m[4]))
out(E/'control-state.csv',props)
out(E/'incoming-references.csv',[x for x in calls if x['target'] in core])
out(O/'shared-calls.csv',[dict(x,original_target=maps.get(x['target'],{}).get('original_token',''),original_target_rva=raw.get(maps.get(x['target'],{}).get('original_token'),{}).get('rva','')) for x in calls if x['caller'] in core and x['target'] not in core and x['target'].startswith('0x06')])
negative={}
for t in core:
 negative[t]=dict(name=proc[t]['name'],incoming=[x for x in calls if x['target']==t],nonheader_il_references=[dict(caller=k,lines=[l for l in v.splitlines()[1:] if t in l]) for k,v in allil.items() if t in '\n'.join(v.splitlines()[1:])])
(E/'all-incoming.json').write_text(json.dumps(negative,ensure_ascii=False,indent=2),encoding='utf-8')
# Save each selected method source excerpt with original line numbers for small focused reads.
d=E/'methods';d.mkdir(exist_ok=True)
for m in ms:
 if not m['source'] or not m['line']:continue
 ss=(R/m['source']).read_text(encoding='utf-8').splitlines();a=int(m['line'])-1
 # location may be declaration; end at next same-indent method closing brace.
 indent=re.match(r'\s*',ss[a])[0];b=next((j for j in range(a+1,len(ss)) if ss[j]==indent+'}'),min(a+100,len(ss)-1))
 (d/(m['processed_token']+'.source.txt')).write_text('\n'.join(f'{i+1}: {ss[i]}' for i in range(a,b+1)),encoding='utf-8')
print('core',len(core),'methods',len(ms),'field flow',len(flow),'branches',len(conditions))
