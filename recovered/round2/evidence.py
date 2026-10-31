"""Package Round2 from existing metadata/IL/source indices, never target execution."""
from pathlib import Path
from collections import defaultdict
import csv, json, re, sys, hashlib
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2]; R=ROOT/'reverse-analysis'; B=ROOT/'recovered'
def rows(path):
    with (R/path).open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
raw={x['token']:x for x in rows('04_type-map/raw/methods.csv')}
processed={x['token']:x for x in rows('04_type-map/methods-only/methods.csv')}
mapping={x['processed_token']:x['original_token'] for x in rows('04_type-map/tool-token-map.csv') if x['kind']=='Method'}
locs=rows('04_type-map/method-source-locations.csv')
calls=rows('05_callgraph/static-sites.csv'); by_caller=defaultdict(list)
for call in calls:by_caller[call['caller']].append(call)
source_path=R/'03_recovered-src/annotated-strings/--/--.cs'
lines=source_path.read_text(encoding='utf-8').splitlines()
il=(R/'04_type-map/methods-only/independent-il.txt').read_text(encoding='utf-8')
chunks={m[1]:m[0] for m in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',il,re.M|re.S)}
def encoded(name):return re.sub(r'_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),name)
def source_method(token):
    loc=next((x for x in locs if x['tokens']==token),None)
    if not loc:return []
    file=R/loc['source']; data=file.read_text(encoding='utf-8').splitlines(); start=int(loc['line'])-1
    end=next((i for i in range(start+1,len(data)) if re.match(r'^\t\t(?:public|private|internal|protected|static) .*\(',data[i])),len(data))
    return [(i+1,data[i]) for i in range(start,end)]
if len(sys.argv)>1:
    for token in sys.argv[1:]:
        print('\n###',token,processed[token]['name'], 'original',mapping[token],raw[mapping[token]]['rva'])
        for i,line in source_method(token):
            if '//IL_' not in line:print(f'{i}: {line}')
    raise SystemExit()

specs={'A7-Departure':('FormDepartureEvl',['_0089_0086','_0088_0093','_0088_0095','_008A_0095']),
       'A8-TurnArea':('FormTurnAreaEvl',['_0088_009D']),
       'A10-DmeArc':('FormDmeEvl',['_0089_0088']),
       'A1-WindSpiral':('FormWindSpiral',['_0089_0094']),
       'B1-FlyBy':('FormFlyBy',['_008B_008E']),
       'B2-FlyOverDF':('FormFlyOverDF',['_008B_0090'])}
for folder,(ui,classes) in specs.items():
    out=B/folder/'evidence';out.mkdir(parents=True,exist_ok=True)
    tokens={t for t,m in processed.items() if m['name'].split('::')[0].split('.')[-1] in {encoded(c) for c in classes}}
    methods=[]
    for token in sorted(tokens):
        old=mapping[token];loc=next((x for x in locs if x['tokens']==token),{})
        methods.append(dict(processed_token=token,processed_rva=processed[token]['rva'],original_token=old,original_rva=raw[old]['rva'],name=processed[token]['name'],source=loc.get('source'),line=loc.get('line'),il_sha256=processed[token]['il_sha256']))
        if token[2:] in chunks:(out/(token+'.il.txt')).write_text(chunks[token[2:]],encoding='utf-8')
    for cls in classes:
        start=next(i for i,l in enumerate(lines) if re.match(r'\tpublic (?:static |partial )?class '+re.escape(cls)+r'(?:\s|:|$)',l))
        end=next(i for i in range(start+1,len(lines)) if lines[i]=='\t}')
        (out/(cls+'.source.txt')).write_text('\n'.join(f'{i+1}: {lines[i]}' for i in range(start,end+1))+'\n',encoding='utf-8')
    evs=[x for x in rows('04_type-map/events.csv') if x['ui_name']==ui]
    controls=[x for x in rows('04_type-map/controls.csv') if x['ui_name']==ui]
    for name,records in [('events',evs),('controls',controls),('calls',[x for x in calls if x['caller'] in tokens])]:
        with (out/(name+'.csv')).open('w',encoding='utf-8-sig',newline='') as f:
            w=csv.DictWriter(f,fieldnames=list(records[0]));w.writeheader();w.writerows(records)
    (out/'methods.json').write_text(json.dumps(methods,ensure_ascii=False,indent=2),encoding='utf-8')
    doc=['# '+folder+' 真实事件索引','','L1处理代码/原事件元数据 + L2独立IL；原RVA可能是保护桩。源码编号摘录、完整事件/控件和直接调用CSV见evidence/。此表不代表运行调用图。','','| Control / Event | Handler | 原MethodDef / RVA | 处理MethodDef / RVA | Direct callees / API |','|---|---|---|---|---|']
    for e in evs:
        t=e['handler_tokens'];old=mapping.get(t)
        if not old:continue
        direct=[c for c in by_caller[t] if c['opcode'] in ('call','callvirt','newobj')]
        targets=sorted({c['target']+' '+c['target_name'].replace('|','/') for c in direct})
        doc.append(f"| {e['control_name']} / {e['event']} | {e['handler']} | {old} / {raw[old]['rva']} | {t} / {processed[t]['rva']} | {'; '.join(targets)} |")
    (B/folder/'event-map.md').write_text('\n'.join(doc)+'\n',encoding='utf-8')
    print(folder,'methods',len(methods),'events',len(evs),'controls',len(controls))
