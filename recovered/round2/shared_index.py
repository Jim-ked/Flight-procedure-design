"""Direct call and CAD indexes from existing IL tables, no target execution."""
from pathlib import Path
from collections import defaultdict, deque
import csv,json,re
ROOT=Path(__file__).resolve().parents[2];R=ROOT/'reverse-analysis';B=ROOT/'recovered';OUT=B/'round2'
def rows(p):
    with (R/p).open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
methods={x['token']:x for x in rows('04_type-map/methods-only/methods.csv')}
raw={x['token']:x for x in rows('04_type-map/raw/methods.csv')}
mapping={x['processed_token']:x['original_token'] for x in rows('04_type-map/tool-token-map.csv') if x['kind']=='Method'}
sites=rows('05_callgraph/static-sites.csv');calls=[c for c in sites if c['opcode'] in ('call','callvirt','newobj')]
out=defaultdict(list);inc=defaultdict(list)
for c in calls:out[c['caller']].append(c);inc[c['target']].append(c)
def enc(s):return re.sub(r'_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
classes={'A1':['_0089_0094'],'A7':['_0089_0086','_0088_0093','_0088_0095','_008A_0095'],'A8':['_0088_009D'],'A10':['_0089_0088'],'B1':['_008B_008E'],'B2':['_008B_0090']}
groups={k:{t for t,m in methods.items() if m['name'].split('::')[0].split('.')[-1] in [enc(x) for x in v]} for k,v in classes.items()}
def token(n):return '0x0600'+n.upper().zfill(4)
def identity(t):
    old=mapping.get(t,'');return old+' / '+raw.get(old,{}).get('rva','')+' (P '+t+')'
def direct(t,g):return sorted({c['caller']+'@'+c['il_offset'] for c in inc[t] if c['caller'] in groups[g]})
def witness(g,t):
    q=deque((s,[s]) for s in sorted(groups[g]));seen=set(groups[g])
    while q:
        n,path=q.popleft()
        if n==t:return path
        for c in out[n]:
            x=c['target']
            if x in methods and x not in seen:seen.add(x);q.append((x,path+[x]))
    return []
primitives=[('793','Turn parameter constructor','Round1 TAS/rate/radius/wind-radius'),('854','Turn input reader','Round1 Read; units and exception path'),('7A1','Spiral constructor','spiral model; not reached by A7'),('7A2','Spiral angle normalize','loop normalization, unlike A10 once'),('7A3','Spiral samples','r=angle*windRadius+radius+offset, terminal point appended'),('7A5','Spiral point','spiral class; not ported this round'),('7AD','Spiral tangent iteration','shared call index only; not newly recovered'),('7E5','Line X(y)','original sentinel divide'),('7E6','Line Y(x)','original sentinel divide'),('7E7','Line through two points','line coefficients'),('7E8','Line through point/angle','slope/coefficient construction'),('7EA','Divide','denominator zero -> +1000000 if numerator>0 else -1000000'),('7EC','Point-line distance','infinite-line perpendicular distance'),('7ED','Line intersection','line coefficient solution'),('7EE','Line angle','old angle branch'),('807','XY point distance','ignores Z'),('808','Bearing','XY atan2'),('809','Polar point','distance/angle to point'),('80A','Point addition','includes Z'),('80D','Mirror Y','(X,-Y,Z)'),('80E','Zero Z','(X,Y,0)'),('80F','Point rotation','origin+polar(distance,bearing+angle,p.Z); Z sums'),('810','Point translation','XY translation'),('81F','Symmetric boundary','five points with repeated start'),('821','Rotate nested paths','point primitive'),('822','Rotate path','point primitive'),('823','Translate nested paths','point primitive'),('824','Translate path','point primitive'),('826','Clear path Z','point primitive'),('827','Clear nested paths Z','point primitive')]
doc=['# 共享几何与转弯原语索引','','来自既有处理IL static-sites，只有 call/callvirt/newobj 计为边；字段访问不计调用。原始token/RVA只标身份，保护桩本身不证明计算。P为处理token。直接caller只列指定窗口/模型类，不冒充运行轨迹。','','| 方法 | 原 token / RVA / P | A1直接 | A7直接 | A8直接 | A10直接 | B1直接 | B2直接 | 行为/恢复范围 |','|---|---|---|---|---|---|---|---|---|']
witnesses=[]
for n,name,behavior in primitives:
    t=token(n)
    doc.append('| '+name+' | '+identity(t)+' | '+' | '.join(', '.join(direct(t,g)) or '—' for g in groups)+' | '+behavior+' |')
    for g in groups:
        p=witness(g,t)
        if p:witnesses.append(dict(group=g,target=t,path=p))
(B/'GeometryPrimitives/shared-geometry-map.md').write_text('\n'.join(doc)+'\n',encoding='utf-8')
(OUT/'shared-call-witnesses.json').write_text(json.dumps(witnesses,indent=2),encoding='utf-8')
with (OUT/'shared-direct-calls.csv').open('w',encoding='utf-8-sig',newline='') as f:
    records=[c for c in calls if c['target'] in {token(p[0]) for p in primitives}]
    w=csv.DictWriter(f,fieldnames=list(calls[0]));w.writeheader();w.writerows(records)
text=['# A7 / A8 与共享转弯方法','','直接证据见 [全部直接边](round2/shared-direct-calls.csv) 与 [原语表](GeometryPrimitives/shared-geometry-map.md)。间接见证路径另存 [shared-call-witnesses.json](round2/shared-call-witnesses.json)，不能把间接可达当作窗口直接调用。','','- A7直接构造共同turn参数模型 P793（原06000794/RVAC3820），因此复用TAS、率、半径、风半径公式；A7实际几何只消费TAS+Wind的6秒延迟，没有调用P7A1螺旋构造器。','- A1通过输入reader P854，再构造turn参数；窗口直接new螺旋P7A1。B1/B2各自的直接边和间接路径以CSV/JSON为准，不以算法相似推断共享。','- A7三个评价器分别属于定高、定点、全向模型；A8调用KK公共评价器；两者没有共同业务评价器的直接调用证据。','- A7和A8复用点、线、局部变换及障碍物导入/解析/Mark helper；A10复用障碍物公共链，但其扇区判定与副区折减在本窗独立实现。','- Round1 PriSecRecovered.Local是恢复代码复用的等价坐标切片；不能据friendly类名断言原A7调用A9业务评价。','- 几何相似但重复实现：A7三模型的MOC/PDA/required判断、A10 sector和A9 PriSec；同为副区折减并不代表共享。','','## 证据限制','','所有无调用结论限定已索引的静态直接边/可达路径；不排除反射、外部插件或手工画图。无原目标L3。']
(B/'shared-turn-methods.md').write_text('\n'.join(text)+'\n',encoding='utf-8')
# Scope: exact A7/A8/A10 window/model bodies, plus their reachable internal callees.
root=set().union(*(groups[g] for g in ['A7','A8','A10']));reachable=set(root);q=deque(root)
while q:
    for c in out[q.popleft()]:
        if c['target'] in methods and c['target'] not in reachable:reachable.add(c['target']);q.append(c['target'])
patterns=r'Intersect|Offset|Polyline|Arc::|Circle::|Tangent|GetPoint|GetEntity|GetSelection|SelectAll|XData|Erase|Extend|Trim|Clip|GetClosestPoint|Highlight|Unhighlight'
records=[dict(scope='window/model' if c['caller'] in root else 'reachable-helper',original=mapping.get(c['caller'],''),original_rva=raw.get(mapping.get(c['caller'],''),{}).get('rva',''),**c) for c in sites if c['caller'] in reachable and re.search(patterns,c['target_name'],re.I)]
with (OUT/'cad-connection-sites.csv').open('w',encoding='utf-8-sig',newline='') as f:
    w=csv.DictWriter(f,fieldnames=list(records[0]));w.writeheader();w.writerows(records)
checks={g:{p:bool(witness(g,token(p))) for p in ['7A1','793']} for g in groups}
(OUT/'reachability-summary.json').write_text(json.dumps(dict(method_counts={g:len(s) for g,s in groups.items()},reachable_methods=len(reachable),cad_sites=len(records),checks=checks),indent=2),encoding='utf-8')
print(json.dumps(checks,ensure_ascii=False));print('CAD sites',len(records))
