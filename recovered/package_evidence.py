"""Slice existing evidence only; does not load, decompile, or run the target DLL."""
from pathlib import Path
import csv,json,re
BASE=Path(__file__).resolve().parent
R=BASE.parent/'reverse-analysis'
def table(p):
    with (R/p).open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
raw={r['token']:r for r in table('04_type-map/raw/methods.csv')}
processed={r['token']:r for r in table('04_type-map/methods-only/methods.csv')}
mapping={r['processed_token']:r['original_token'] for r in table('04_type-map/tool-token-map.csv') if r['kind']=='Method'}
locations=table('04_type-map/method-source-locations.csv')
# Existing declaration index omitted generic methods and constructors. Explicit
# locations below are checked against methods-only metadata; no new decompilation.
locations += [dict(method='.ctor',tokens='0x06000793',source=r'03_recovered-src\annotated-strings\--\--.cs',line='81748'),
              dict(method='_008B_008A<T>',tokens='0x0600010D',source=r'03_recovered-src\annotated-strings\-\-.cs',line='5120')]
source_root=R/'03_recovered-src/annotated-strings'
packages={
 'A2-BasicCalculation':{'ui':['FormCalcu'],'ranges':{'--/--.cs':[(7283,7506),(7508,8615),(74436,76200),(81722,81860),(83668,83752),(85141,85193)],'-/-.cs':[(1578,1658),(5236,5305)]}},
 'ObstacleData':{'ui':['FormRandPoint','FormDepartureEvl','FormTurnAreaEvl','FormPriSecEvl','FormDmeEvl','FormApvEvl','FormPbnIlsEvl','FormPbnDepEvl'],
                 'ranges':{'--/--.cs':[(239,303),(12096,12230),(12310,12485),(14310,14410),(15238,15340),(19090,19170),(21400,21490),(28870,29301),(29630,29720),(31055,31238),(41377,41614),(47070,47170),(47510,47590),(56370,56510),(56817,56822),(57259,57360),(60790,60910),(61492,61496),(62560,62650),(78403,79025),(83875,84008)],'-/-.cs':[(65,196),(1011,1321),(1578,1658),(2596,2874),(3103,3150),(5120,5201)]}},
 'A3-FixTolerance':{'ui':['FixTolerance'],'ranges':{'--/--.cs':[(4355,5042)],'-/-.cs':[(1458,1510),(1578,1658)]}}
}
il=(R/'04_type-map/methods-only/independent-il.txt').read_text(encoding='utf-8')
chunks={m[1]:m[0] for m in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',il,re.M|re.S)}
refs=table('05_callgraph/static-sites.csv')
for name,spec in packages.items():
    out=BASE/name/'evidence';out.mkdir(parents=True,exist_ok=True)
    selected=[]
    for rel,ranges in spec['ranges'].items():
        lines=(source_root/rel).read_text(encoding='utf-8').splitlines()
        for first,last in ranges:
            (out/(rel.replace('/','_')+f'.{first}-{last}.txt')).write_text('\n'.join(f'{i+1}: {lines[i]}' for i in range(first-1,min(last,len(lines))))+'\n',encoding='utf-8')
        for loc in locations:
            if Path(loc['source']).name!=Path(rel).name:continue
            if not any(a<=int(loc['line'])<=b for a,b in ranges):continue
            token=loc['tokens']
            if token not in processed:continue
            old=mapping[token]
            selected.append(dict(method=loc['method'],processed_token=token,processed_rva=processed[token]['rva'],original_token=old,original_rva=raw[old]['rva'],source=loc['source'],line=loc['line']))
            if token[2:] in chunks:(out/(token+'.il.txt')).write_text(chunks[token[2:]],encoding='utf-8')
    (out/'methods.json').write_text(json.dumps(selected,ensure_ascii=False,indent=2),encoding='utf-8')
    tokens={r['processed_token'] for r in selected}
    for filename,records in [('events', [r for r in table('04_type-map/events.csv') if r['ui_name'] in spec['ui']]),
                             ('controls',[r for r in table('04_type-map/controls.csv') if r['ui_name'] in spec['ui']]),
                             ('calls',[r for r in refs if r['caller'] in tokens])]:
        with (out/(filename+'.csv')).open('w',encoding='utf-8-sig',newline='') as f:
            writer=csv.DictWriter(f,fieldnames=list(records[0]));writer.writeheader();writer.writerows(records)
    text=['# 方法与来源','', 'L1 Direct=处理后代码；L2 IL=处理后IL及原件token映射；无L3。原始RVA可能仅指向保护桩，不意味着原始明文方法体已含这些公式。以下是审计定位，不以条目数作为完成比例。源码是固定行段摘录，首尾可能跨方法；以IL文件为完整方法体定位。旧摘录文件保留，新生成清单为当前有效索引。','', '| 方法 | 原token / RVA | 处理后token / RVA | 原阅读副本行 |','|---|---|---|---|']
    text += [f"| {r['method']} | {r['original_token']} / {r['original_rva']} | {r['processed_token']} / {r['processed_rva']} | {r['source']}:{r['line']} |" for r in selected]
    (BASE/name/'evidence.md').write_text('\n'.join(text)+'\n',encoding='utf-8')
    print(name,len(selected),'method locations; exact excerpts retained')
