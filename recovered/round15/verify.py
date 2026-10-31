"""Read-only input audit; only writes Round15 closure/integrity/output manifest.

No original business code is built or executed. --check verifies sealed outputs
without writing any file. Output manifest excludes itself to avoid self-hash recursion.
"""
import csv, hashlib, json, re, sys
from collections import Counter
from pathlib import Path

ROOT=Path(__file__).resolve().parents[2]
R=ROOT/'recovered/round15'
B=ROOT/'recovered/final-static-baseline'
ALLOWED=('recovered/round15/','recovered/final-static-baseline/')
CHECK_ONLY='--check' in sys.argv
def sha(p):
    h=hashlib.sha256()
    with p.open('rb') as f:
        for block in iter(lambda:f.read(1048576),b''): h.update(block)
    return h.hexdigest()
def dump(p,obj): p.write_text(json.dumps(obj,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
snapshot=json.loads((R/'frozen-inputs.json').read_text(encoding='utf-8'))
inputs={x['path']:x for x in snapshot['files']}
failures=[]
changed=[]
for rel,row in inputs.items():
    p=ROOT/rel
    if not p.is_file(): changed.append({'path':rel,'reason':'MISSING'})
    else:
        actual=sha(p)
        if actual!=row['sha256'] or p.stat().st_size!=row['size']:
            changed.append({'path':rel,'expected':row['sha256'],'actual':actual})
allfiles={p.relative_to(ROOT).as_posix():p for p in ROOT.rglob('*') if p.is_file() and '.git' not in p.relative_to(ROOT).parts}
unauthorized=[rel for rel in allfiles if rel not in inputs and not rel.startswith(ALLOWED)]
if changed or unauthorized:
    report={'status':'INTEGRITY FAILURE','frozen_file_count':len(inputs),'mismatches':changed,'unauthorized_new_files':unauthorized}
    if not CHECK_ONLY:
        dump(R/'integrity-report.json',report)
        (R/'closure.md').write_text('# Round 15\n\nINTEGRITY FAILURE\n\nAssembly stopped; see integrity-report.json.\n',encoding='utf-8')
    print(json.dumps(report,ensure_ascii=False));sys.exit(1)

required='''executive-summary.md static-reconstruction-report.md final-public-function-status.csv module-master.csv static-completion-definition.md system-architecture-final.md procedure-model-assessment.md cross-window-data-flow.csv shared-components-final.csv shared-vs-copied-final.csv cad-entity-master.csv metadata-master.csv obstacle-system-final.csv protection-connection-final.csv manual-interaction-final.csv help-ui-code-final.csv build-limitations.md other-build-comparison-plan.md e4-validation-plan.md standard-basis-unresolved.csv recovered-code-inventory.csv evidence-level-master.csv'''.split()
for n in required:
    if not (B/n).is_file() or (B/n).stat().st_size==0: failures.append('Missing/empty deliverable '+n)
for n in ('plan.md','frozen-inputs.json','evidence-index.csv','preflight-integrity.json'):
    if not (R/n).is_file(): failures.append('Missing Round15 input/output '+n)

csvs={}
csv_rows=0
path_columns={'Evidence','PrimaryEvidence','CodeEvidence','LatestClosure','RecoveredCs','FixtureCoverage'}
for p in [*B.glob('*.csv'),R/'evidence-index.csv']:
    with p.open(encoding='utf-8-sig',newline='') as f:
        rd=csv.DictReader(f); fields=rd.fieldnames or []
        if len(fields)!=len(set(fields)): failures.append('Duplicate columns '+p.name)
        rows=list(rd)
        if not rows: failures.append('No records '+p.name)
        for i,row in enumerate(rows,2):
            if None in row or any(v is None for v in row.values()): failures.append(f'CSV width {p.name}:{i}')
            for k,v in row.items():
                if k in path_columns and v:
                    for rel in v.split(';'):
                        if not (ROOT/rel).is_file(): failures.append(f'Broken source {p.name}:{i} {rel}')
        csv_rows+=len(rows);csvs[p.name]=rows

expected={f'A{i}' for i in range(1,11)}|{f'B{i}' for i in range(1,6)}
statusset={'COMPLETE_STATIC','PARTIAL_STATIC_BUILD_LIMITED','PARTIAL_STATIC_OTHER_BUILD_REQUIRED','NOT_PUBLIC_BUSINESS_FUNCTION'}
statuses=csvs.get('final-public-function-status.csv',[])
master=csvs.get('module-master.csv',[])
counts=Counter(row['FinalStaticStatus'] for row in statuses)
if len(statuses)!=15 or {r['Module'] for r in statuses}!=expected: failures.append('Public module coverage')
if len(master)!=15 or {r['Module'] for r in master}!=expected: failures.append('Module master coverage')
if set(counts)-statusset: failures.append('Invalid status vocabulary')
if any(r['FinalStaticStatus']=='NOT_PUBLIC_BUSINESS_FUNCTION' for r in statuses): failures.append('Auxiliary status in public15')
mastermap={r['Module']:r for r in master}
for r in statuses:
    m=r['Module']
    if m not in mastermap or any(r[k]!=mastermap[m][k] for k in ('Command','HistoricalRound','HistoricalStatus','FinalStaticStatus','LatestClosure')):
        failures.append('Rollup mismatch '+m)
    closure=(ROOT/r['LatestClosure']).read_text(encoding='utf-8')
    if r['FinalStaticStatus']=='COMPLETE_STATIC' and m not in ('A8','A10'):
        if not ('COMPLETE_STATIC' in closure or 'ACCEPTED (static recovery)' in closure): failures.append('Closure classification '+m)
    if r['FinalStaticStatus']=='PARTIAL_STATIC_BUILD_LIMITED' and 'PARTIALLY ACCEPTED' not in closure: failures.append('Limited historical closure '+m)
for n in ('cad-entity-master.csv','evidence-level-master.csv','standard-basis-unresolved.csv'):
    rows=csvs.get(n,[])
    if len(rows)!=15 or {r['Module'] for r in rows}!=expected: failures.append('Module coverage '+n)
for row in csvs.get('evidence-level-master.csv',[]):
    if row['E4']!='NOT_COMPLETED': failures.append('E4 incorrectly promoted '+row['Module'])
for row in csvs.get('shared-vs-copied-final.csv',[]):
    if row['Classification'] not in {'SAME_METHODDEF','COPIED_IMPLEMENTATION','SIMILAR_MATH','BUSINESS_SIMILAR_ONLY','NO_RELATION'}: failures.append('Shared classification')
for row in csvs.get('help-ui-code-final.csv',[]):
    if row['Classification'] not in {'CONSISTENT','HELP_OVRSTATES_BUILD','UI_STUB','CODE_ORPHAN','HELP_UNDERSTATES_CODE'}: failures.append('Help classification')
for row in csvs.get('protection-connection-final.csv',[]):
    if row['Classification'] not in {'shared vertex','line intersection','line carrier','candidate comparison','Hull','point-list concatenation','manual repick'}: failures.append('Connection classification')

links=0
for p in B.glob('*.md'):
    text=p.read_text(encoding='utf-8')
    if re.search(r'\b\d+(?:\.\d+)?\s*%',text): failures.append('Completion-like percentage present '+p.name)
    for target in re.findall(r'\]\((?:<([^>]+)>|([^\s)]+))\)',text):
        t=next(x for x in target if x)
        if t.startswith(('https://','http://')): continue
        path=Path(t)
        # integrity-report is created after these content checks.
        if path==R/'integrity-report.json' and not CHECK_ONLY: links+=1;continue
        if not path.is_file(): failures.append('Broken markdown link '+p.name+': '+t)
        links+=1
for n in ('executive-summary.md','static-reconstruction-report.md','static-completion-definition.md'):
    text=(B/n).read_text(encoding='utf-8')
    for s in statusset:
        if f'`{s}`: {counts[s]}' not in text: failures.append('Summary count mismatch '+n+' '+s)

indexed=csvs.get('evidence-index.csv',[])
for row in indexed:
    if row['Path'] not in inputs or row['SHA256']!=inputs[row['Path']]['sha256']: failures.append('Unfrozen evidence '+row['Path'])
csrows=csvs.get('recovered-code-inventory.csv',[])
expected_cs={rel for rel in inputs if rel.startswith('recovered/') and rel.endswith('.cs')}
if {r['RecoveredCs'] for r in csrows}!=expected_cs or len(csrows)!=len(expected_cs): failures.append('C# inventory incomplete/duplicate')
for row in csrows:
    if sha(ROOT/row['RecoveredCs'])!=row['SHA256']: failures.append('CS asset hash '+row['RecoveredCs'])

status='PASS' if not failures else 'FINAL STATIC RECONSTRUCTION BASELINE INCOMPLETE'
report={'status':status,'scope':'Entire workspace; .git excluded; additions allowed only under Round15 two directories',
        'frozen_file_count':len(inputs),'snapshot_declared_count':snapshot['count'],
        'frozen_snapshot_sha256':sha(R/'frozen-inputs.json'),'mismatch_count':len(changed),'mismatches':changed,
        'unauthorized_new_files':unauthorized,'required_baseline_deliverables':len(required),
        'actual_baseline_files':len([p for p in B.iterdir() if p.is_file()]),'module_count':len(statuses),
        'final_status_counts':{s:counts[s] for s in sorted(statusset)},'csv_records_checked':csv_rows,
        'source_index_count':len(indexed),'cs_assets_checked':len(csrows),'markdown_links_checked':links,
        'validation_errors':failures,'business_tests_run_in_round15':False,'target_dll_executed_in_round15':False,
        'E4_business_validation':'NOT_COMPLETED_ALL_MODULES',
        'historical_statuses_preserved':True,'manifest_rule':'output-manifest.json excludes its own file; all other Round15 outputs are hashed'}

if CHECK_ONLY:
    manifest=json.loads((R/'output-manifest.json').read_text(encoding='utf-8'))
    output_files={rel for rel in allfiles if rel.startswith(ALLOWED) and rel!='recovered/round15/output-manifest.json'}
    if output_files!={r['path'] for r in manifest['files']}: failures.append('Output manifest scope mismatch')
    for row in manifest['files']:
        p=ROOT/row['path']
        if not p.is_file() or sha(p)!=row['sha256'] or p.stat().st_size!=row['size']: failures.append('Output hash '+row['path'])
    report['output_manifest_records_verified']=len(manifest['files'])
    report['status']='PASS' if not failures else 'FINAL STATIC RECONSTRUCTION BASELINE INCOMPLETE'
    report['validation_errors']=failures
    print(json.dumps(report,ensure_ascii=False));sys.exit(0 if not failures else 1)

dump(R/'integrity-report.json',report)
label='FINAL STATIC RECONSTRUCTION BASELINE COMPLETE' if not failures else 'FINAL STATIC RECONSTRUCTION BASELINE INCOMPLETE'
lines=['# Round 15 Closure','',label,'',
       '15个航空公开功能已按最新closure汇总；历史Round1–14状态和文件均保留。', '',
       *[f'- {s}: {counts[s]}' for s in sorted(statusset)],'',
       f'冻结文件逐项复核：{len(inputs)}；hash差异：{len(changed)}；越界新增：{len(unauthorized)}。',
       f'本轮基线文件：{report["actual_baseline_files"]}；源证据索引：{len(indexed)}；C#资产：{len(csrows)}。','',
       '## 验收依据','',
       '- 15个模块、Round11–14升级、共享/复制及metadata/跨窗关系已进入新总表。',
       '- A5/B3/B4/B5按当前构建调度限制独立分类；不补接orphan入口。',
       '- 冲突校正登记与逐模块gap inventory支撑同构建剩余工作判断。',
       '- E4计划与静态/E3来源分开；全部模块E4业务验证未完成。',
       '- 完整性及交付检查采用实际读取/哈希/结构/链接验证，不以生成式PASS清单替代数值实验。','',
       '## 审计边界','',
       'Round14旧manifest自哈希不可自洽，preflight显式披露；其文件本体实际hash已进入本轮快照。本轮output-manifest排除自身，避免递归自哈希。',
       'Round15未执行任何新业务数值测试/目标DLL/AutoCAD，未修改旧成果。静态完成不表示运行等价、规范符合或认证。','',
       '## 入口','',
       '[阶段摘要](../final-static-baseline/executive-summary.md) / [技术总报告](../final-static-baseline/static-reconstruction-report.md) / [完整性报告](integrity-report.json) / [输出清单](output-manifest.json)','',
       '## 停止','',
       '本轮结束；等待用户决定E4、可信构建比较、独立规范研究或最终文档工作。未自动执行下一阶段。']
if failures: lines+=['','## 未通过项','',*['- '+x for x in failures]]
(R/'closure.md').write_text('\n'.join(lines)+'\n',encoding='utf-8')
outputs=sorted(p for d in (R,B) for p in d.rglob('*') if p.is_file() and p!=R/'output-manifest.json')
dump(R/'output-manifest.json',{'scope':'Round15 outputs only; self excluded by design','count':len(outputs),
    'files':[{'path':p.relative_to(ROOT).as_posix(),'size':p.stat().st_size,'sha256':sha(p)} for p in outputs]})
print(json.dumps(report,ensure_ascii=False));sys.exit(0 if not failures else 1)
