import hashlib,json,sys
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]
R=ROOT/'recovered/round15'
def sha(p):
    h=hashlib.sha256()
    with p.open('rb') as f:
        for b in iter(lambda:f.read(1024*1024),b''): h.update(b)
    return h.hexdigest()
def current_files():
    return sorted((p for p in ROOT.rglob('*') if p.is_file() and not any(p.relative_to(ROOT).as_posix().startswith(s) for s in ('.git/','recovered/round15/','recovered/final-static-baseline/'))),key=lambda p:p.as_posix())
prior=[]
for name in ('frozen-inputs.json','output-manifest.json'):
    manifest=ROOT/'recovered/round14'/name
    for item in json.loads(manifest.read_text(encoding='utf-8'))['files']:
        # A manifest cannot hash its own final content. Its actual current hash
        # is recorded in the new snapshot; this is not an old-input exception.
        if item['path']=='recovered/round14/output-manifest.json': continue
        p=ROOT/item['path']
        prior.append({'source':manifest.relative_to(ROOT).as_posix(),'path':item['path'],'expected':item['sha256'],'actual':sha(p) if p.exists() else None})
bad=[x for x in prior if x['actual']!=x['expected']]
result={'status':'INTEGRITY FAILURE' if bad else 'PASS','checked':len(prior),'mismatches':bad,'self_hash_note':'Round14 manifest self-entry is non-verifiable by definition; new snapshot records the actual manifest SHA256.'}
(R/'preflight-integrity.json').write_text(json.dumps(result,ensure_ascii=False,indent=2),encoding='utf-8')
if bad:
    (R/'closure.md').write_text('INTEGRITY FAILURE\nSee preflight-integrity.json. Baseline assembly stopped.\n',encoding='utf-8')
    print(json.dumps({'status':result['status'],'mismatches':bad},ensure_ascii=False));sys.exit(1)
fp=R/'frozen-inputs.json'
if fp.exists(): raise SystemExit('Snapshot already exists; use verify.py, do not replace baseline.')
files=[{'path':p.relative_to(ROOT).as_posix(),'size':p.stat().st_size,'sha256':sha(p)} for p in current_files()]
fp.write_text(json.dumps({'scope':'All workspace input files, including original materials, WsTools-master, reverse-analysis and recovered Round1-14; excludes only .git and the two new Round15 output directories','count':len(files),'files':files},ensure_ascii=False,indent=2),encoding='utf-8')
print(json.dumps({'preflight':result['status'],'prior_hash_checks':len(prior),'snapshot_count':len(files)},ensure_ascii=False))
