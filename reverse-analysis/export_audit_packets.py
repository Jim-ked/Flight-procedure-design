"""Export exact IL fragments and focused event graphs, without executing target code."""
from pathlib import Path
import csv, json, re
R=Path(__file__).resolve().parent
def read(path):
    with (R/path).open(encoding='utf-8-sig',newline='') as f:
        return list(csv.DictReader(f))
mapping=read('04_type-map/tool-token-map.csv')
original={r['processed_token']:r['original_token'] for r in mapping if r['kind']=='Method'}
locations={r['tokens']:r for r in read('04_type-map/method-source-locations.csv') if '|' not in r['tokens']}
targets=['0x06000070','0x0600010D','0x06000113','0x06000279','0x06000285','0x06000286',
         '0x06000287','0x06000289','0x0600028A','0x0600028B','0x0600028C','0x0600028D','0x0600028E',
         '0x06000290','0x06000291']
out=R/'05_callgraph/per-module/conventional-departure/evidence'
out.mkdir(parents=True,exist_ok=True)
manifest=[]
for variant in ['raw','methods-only']:
    text=(R/f'04_type-map/{variant}/independent-il.txt').read_text(encoding='utf-8')
    chunks={m[1]:'METHOD '+m[1]+m[2] for m in re.finditer(r'^METHOD ([0-9A-F]{8})(.*?)(?=^METHOD |\Z)',text,re.M|re.S)}
    for token in targets:
        actual=original[token] if variant=='raw' else token
        key=actual[2:]
        assert key in chunks, (variant,actual)
        dest=out/f'{variant}-{actual}.il.txt'
        dest.write_text(chunks[key],encoding='utf-8')
        manifest.append(dict(processed_token=token,original_token=original[token],variant=variant,
                             excerpt=str(dest.relative_to(R)),source_location=locations.get(token)))
(out/'manifest.json').write_text(json.dumps(manifest,ensure_ascii=False,indent=2),encoding='utf-8')
for folder in sorted((R/'05_callgraph/per-module').iterdir()):
    if not folder.is_dir():continue
    events=read(str((folder/'events.csv').relative_to(R)))
    lines=['# 直接事件图（静态候选）','','来源 events.csv；不是运行时完整图。处理后 token 需通过 tool-token-map 对应原件。', '', '```text']
    for row in events:
        lines.append(f"{row['ui_name']}.{row['control_name'] or row['field']} --{row['event']}--> {row['handler']} [{row['handler_tokens']}]")
    lines += ['```','','各 handler 的后续IL边见 outgoing-il.csv；共享模块的入边见 incoming-il.csv。计算/几何语义不由此图自动推定。']
    (folder/'event-graph.md').write_text('\n'.join(lines)+'\n',encoding='utf-8')
print(json.dumps({'exact_il_excerpts':len(manifest),'module_event_graphs':5}))
