from pathlib import Path
import csv,json
ROOT=Path(__file__).resolve().parents[2]; R=ROOT/'reverse-analysis'; O=ROOT/'recovered'/'round3'
def read(p):
    with open(p,encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
sites=read(R/'05_callgraph/static-sites.csv')
maps=read(R/'04_type-map/tool-token-map.csv')
old={x.get('processed_token'):x for x in maps if x.get('kind')=='Method'}
raw={x['token']:x for x in read(R/'04_type-map/raw/methods.csv')}
method_rows=read(R/'04_type-map/methods-only/methods.csv')
method_name={x['token']:x['name'] for x in method_rows}
modules={}
for mod in ['A1-WindSpiral','B1-FlyBy','B2-FlyOverDF']:
    modules[mod]={x['processed_token'] for x in json.loads((ROOT/'recovered'/mod/'evidence'/'methods.json').read_text(encoding='utf-8'))}
# Evidence JSON contains the form only. Add the two geometry classes by their
# constructor MethodDefs, then include all methods in those exact classes.
for mod,ctor in [('B1-FlyBy','0x060005A0'),('B2-FlyOverDF','0x060005AB')]:
    prefix=method_name[ctor].split('::')[0]+'::'
    modules[mod].update(x['token'] for x in method_rows if x['name'].startswith(prefix))
targets=['0x06000793','0x060007A1','0x060007A2','0x060007A3','0x060007A5','0x060007A6','0x060007A7','0x060007A8','0x060007A9','0x060007AA','0x060007AB','0x060007AC','0x060007AD','0x0600081B','0x06000821','0x06000823','0x06000827','0x06000807','0x06000808','0x06000809','0x0600080A']
rows=[]
for c in sites:
    if c.get('opcode') not in ('call','callvirt','newobj') or c.get('target') not in targets: continue
    module=''
    for m,s in modules.items():
        if c.get('caller') in s: module=m; break
    if not module: continue
    x=old.get(c['target'],{}); ro=raw.get(x.get('original_token',''),{})
    rows.append(dict(module=module,caller=c['caller'],caller_name=c.get('caller_name',''),il_offset=c.get('il_offset',''),opcode=c['opcode'],target=c['target'],target_name=c.get('target_name',''),original_token=x.get('original_token',''),original_rva=ro.get('rva','')))
# P793 is reached through the shared reader P854. Keep this as an indirect
# witness rather than falsely labeling it a direct constructor edge.
for module, caller, off in [('A1-WindSpiral','0x06000386','IL_0015'),('A1-WindSpiral','0x06000387','IL_01BC'),('A1-WindSpiral','0x06000388','IL_0015'),('B1-FlyBy','0x060004BF','IL_0022'),('B2-FlyOverDF','0x060004DF','IL_0016')]:
    rows.append(dict(module=module,caller=caller,caller_name='form -> P854 reader',il_offset=off,opcode='indirect-witness',target='0x06000793',target_name='turn constructor via 0x06000854',original_token='0x06000794',original_rva='0xC3820'))
with (O/'shared-turn-spiral-calls.csv').open('w',encoding='utf-8-sig',newline='') as f:
    w=csv.DictWriter(f,fieldnames=list(rows[0]) if rows else ['module']);w.writeheader();w.writerows(rows)
summary={'indexed_rows':len(rows),'static_direct_rows':sum(1 for x in rows if x['opcode']!='indirect-witness'),'indirect_witness_rows':sum(1 for x in rows if x['opcode']=='indirect-witness'),'modules':{m:sum(1 for x in rows if x['module']==m) for m in modules},'targets':targets,
         'negative_common_tangent':'No CommonTangent MethodDef or CAD IntersectWith edge in selected module evidence.'}
(O/'shared-index-summary.json').write_text(json.dumps(summary,ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps(summary,ensure_ascii=False))
