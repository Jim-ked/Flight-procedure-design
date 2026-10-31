"""Derived audit indexes; references are static sites, not runtime coverage."""
from pathlib import Path
import csv,json,re,collections,hashlib
R=Path(__file__).resolve().parent
def readcsv(p):
    with (R/p).open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
def writecsv(p,rows):
    p=R/p;p.parent.mkdir(parents=True,exist_ok=True)
    if not rows:return
    with p.open('w',encoding='utf-8-sig',newline='') as f:
        w=csv.DictWriter(f,fieldnames=list(rows[0]));w.writeheader();w.writerows(rows)
def write(p,text):
    p=R/p;p.parent.mkdir(parents=True,exist_ok=True);p.write_text(text,encoding='utf-8')
def csname(s):
    return re.sub(r'\\x([0-9a-f]{2})',lambda m:'_'+m[1].upper().zfill(4),s)
raw=readcsv('04_type-map/raw/methods.csv')
processed=readcsv('04_type-map/methods-only/methods.csv')
refs=readcsv('04_type-map/methods-only/references.csv')
raw_by_name=collections.defaultdict(list)
for m in raw:raw_by_name[m['name']].append(m['token'])
tokens={m['token']:m for m in processed}
# Name-based matches are labelled ambiguous; authoritative tool token mapping is separate.
mapping=[]
for m in processed:
    candidates=raw_by_name[m['name']]
    mapping.append({'processed_token':m['token'],'name':m['name'],'original_candidates':'|'.join(candidates),'unique_name_match':len(candidates)==1})
writecsv('04_type-map/token-name-crosscheck.csv',mapping)
log=(R/'02_deobfuscated/de4dot-methods-only.log').read_text(encoding='utf-8-sig')
toolmap=[{'original_token':'0x'+a,'processed_token':'0x'+b,'kind':k,'description':d}
         for a,b,k,d in re.findall(r'^\s*([0-9A-F]{8}) -> ([0-9A-F]{8}) (Method|Type|Field): (.*)$',log,re.M)]
writecsv('04_type-map/tool-token-map.csv',toolmap)
calls=[x for x in refs if x['opcode'] in ('call','callvirt','newobj','ldftn','ldvirtftn','jmp')]
writecsv('05_callgraph/static-sites.csv',calls)
writecsv('05_callgraph/field-accesses.csv',[x for x in refs if 'fld' in x['opcode']])
patterns={
 'manual':r'Autodesk\.AutoCAD\.EditorInput\.Editor::(GetPoint|GetEntity|GetSelection|GetDouble|GetAngle|GetDistance|GetKeywords|GetInteger|GetString|SelectAll|SelectWindow|SelectCrossing)',
 'geometry':r'Intersect|Offset|Polyline|::Arc|\.Arc::|Circle|Tangent|Trim|Extend|Region|Erase|Explode|Join|BooleanOperation|AddVertex|RemoveVertex|SetPoint|GetSplit|GetClosest',
 'xdata':r'XData|RegApp|ResultBuffer|TypedValue|Json|Serialize|Deserialize',
 'cad':r'Autodesk\.AutoCAD', 'events':r'::add_|::remove_', 'sql':r'SQLite|DbCommand|DbConnection|ExecuteScalar',
}
for group,pattern in patterns.items():
    writecsv('09_cad-interactions/'+group+'-il-sites.csv',[x for x in refs if re.search(pattern,x['target_name'],re.I)])

event_names={x['target_name'].split('::add_',1)[1] for x in refs if '::add_' in x['target_name']}
classes=[];controls=[];events=[];sites=[];method_locations=[]
methodmap=collections.defaultdict(list)
for m in processed:methodmap[csname(m['name'])].append(m['token'])
for path in (R/'03_recovered-src/annotated-strings').rglob('*.cs'):
    lines=path.read_text(encoding='utf-8').splitlines(); ns='';cl=None;method=''; group=[]
    def flush():
        if cl is None:return
        text='\n'.join(line for _,line in group)
        aliases=dict(re.findall(r'([\w]+)\.Name = "([^"\n]+)"',text))
        form=aliases.get('base','')
        classes.append({'namespace':ns,'class':cl,'ui_name':form,'source':str(path.relative_to(R)),'start_line':group[0][0] if group else 0})
        for line_no,line in group:
            for field,name in re.findall(r'(\w+)\.Name = "([^"\n]+)"',line):
                controls.append({'class':cl,'ui_name':form,'field':field,'control_name':name,'source':str(path.relative_to(R)),'line':line_no})
            for obj,event,handler in re.findall(r'(\w+)\.(\w+) \+= (\w+);',line):
                if event not in event_names:
                    continue  # Numeric/property += is not an event subscription.
                key=ns+'.'+cl+'::'+handler
                events.append({'class':cl,'ui_name':form,'field':obj,'control_name':aliases.get(obj,''),'event':event,'handler':handler,
                               'handler_tokens':'|'.join(methodmap.get(key,[])),'source':str(path.relative_to(R)),'line':line_no})
    for i,line in enumerate(lines,1):
        n=re.match(r'^namespace (\S+)',line)
        c=re.match(r'^\t(?:public|internal|private).*?\b(?:class|struct|enum|interface) (\w+)',line)
        if n:flush();cl=None;group=[];ns=n[1]
        if c:flush();cl=c[1];group=[];method=''
        if cl:group.append((i,line))
        mm=re.match(r'^\t\t(?:public|private|internal|protected|static) [^=;]+? ([_\w]+)\([^;]*\)$',line)
        if mm:
            method=mm[1];key=ns+'.'+(cl or '')+'::'+method
            method_locations.append({'class':cl,'method':method,'tokens':'|'.join(methodmap.get(key,[])),'source':str(path.relative_to(R)),'line':i})
        if re.search(r'GetPoint|GetEntity|GetSelection|Intersect|Offset|Tangent|Trim|Extend|XData|\.Erase\(|new Polyline|new Arc|\.Click \+=|SELECT |config.xml',line):
            sites.append({'class':cl,'method':method,'source':str(path.relative_to(R)),'line':i,'text':line.strip()})
    flush()
writecsv('04_type-map/classes-source.csv',classes);writecsv('04_type-map/controls.csv',controls)
writecsv('04_type-map/events.csv',events);writecsv('04_type-map/method-source-locations.csv',method_locations)
writecsv('09_cad-interactions/source-candidate-sites.csv',sites)
forms=[c for c in classes if c['ui_name']]
write('04_type-map/forms.md','# 已恢复 UI 名称与混淆类型\n\n来源：处理后代码 + 静态解密字符串（A；非运行验证）。base.Name 不是原始类名。\n\n| UI Name | 命名空间/类 | 阅读副本行号 |\n|---|---|---|\n'+'\n'.join('| '+c['ui_name']+' | '+c['namespace']+'.'+c['class']+' | '+c['source']+':'+str(c['start_line'])+' |' for c in forms))
write('04_type-map/controls-events.md',f'# 控件与事件索引\n\n已提取 {len(controls)} 个 Name 赋值、{len(events)} 个直接事件绑定。详见 controls.csv、events.csv 和 method-source-locations.csv。\n\n这是文本匹配的候选索引；嵌套、间接委托、反射绑定可能不被覆盖。handler_tokens 不唯一或空白时不能猜测。IL 的 add_* 与 ldftn 证据另见 ../09_cad-interactions/events-il-sites.csv。控件属性不能仅凭字段名解释。\n')
write('05_callgraph/global-callgraph.md',f'# 静态调用图基线\n\nstatic-sites.csv 保存 {len(calls)} 个调用/构造/函数指针位置；每条有处理后 caller token、IL 偏移、opcode、target token/name。field-accesses.csv 保存字段访问。\n\n注意：MethodSpec 泛型调用尚未展开，反射及间接委托运行边缺失；这不是完整运行调用图。原始映射见 ../04_type-map/tool-token-map.csv。不使用未验证的原始 token 等于处理后 token 假设。\n')
commands=readcsv('04_type-map/raw/commands.csv')
write('05_callgraph/command-entrypoints.md','# 原始命令入口\n\nA：原始程序集 CustomAttribute，完整属性 blob 见 ../04_type-map/raw/commands.csv。命令存在不等于运行可用。\n\n| 命令 | 原始方法 token |\n|---|---|\n'+'\n'.join('| '+c['command']+' | '+c['method_token']+' |' for c in commands))

# Retain focused audit packages for subsequent chain analysis, explicitly incomplete.
chains={'wind-spiral':['FormWindSpiral'],'basic-calculation':['FormCalcu'],'fix-tolerance':['FixTolerance'],
        'conventional-departure':['FormDepartureEvl'],'flyby-flyover':['FormFlyBy','FormFlyOverDF']}
for name,uis in chains.items():
    selected=[c for c in classes if c['ui_name'] in uis]; cset={c['class'] for c in selected}
    tset=set()
    for c in selected:
        prefix=c['namespace']+'.'+c['class']+'::'
        tset.update(m['token'] for m in processed if csname(m['name']).startswith(prefix))
    base='05_callgraph/per-module/'+name+'/'
    writecsv(base+'controls.csv',[x for x in controls if x['class'] in cset])
    writecsv(base+'events.csv',[x for x in events if x['class'] in cset])
    writecsv(base+'outgoing-il.csv',[x for x in refs if x['caller'] in tset])
    writecsv(base+'incoming-il.csv',[x for x in refs if x['target'] in tset])
    writecsv(base+'source-locations.csv',[x for x in method_locations if x['class'] in cset])
    write(base+'STATUS.md','# 审计包：'+name+'\n\n状态：第一阶段入口/控件/事件/调用候选索引已建立，业务链尚未完成。\n\n字符串和388个布尔值已静态解码校验；仍需逐方法识别混淆门控与真实业务条件。后续必须恢复输入输出与单位、条件分支、控件到 handler 到计算几何到 CAD 的路径，解决缺失 CAD 依赖和运行验证缺口；不得以当前文件数量声称基础链完成。事件图由 export_audit_packets.py 生成；离场新增证据见 ../../../07_procedure-logic/conventional-departure.md。\n')
print(json.dumps({'classes':len(classes),'ui_names':len(forms),'controls':len(controls),'events':len(events),'call_sites':len(calls),'token_map':len(toolmap)}))
