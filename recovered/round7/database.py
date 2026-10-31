from pathlib import Path
import sqlite3,hashlib,json,itertools
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round7';E=ROOT/'recovered/B4-PbnIls/evidence';F=O/'fixtures';F.mkdir(exist_ok=True)
p=ROOT/'WsTools-master/WindSpiral2026/oas.db';before=hashlib.sha256(p.read_bytes()).hexdigest()
c=sqlite3.connect(p.as_uri()+'?mode=ro&immutable=1',uri=True)
schema=list(c.execute("select name,sql from sqlite_master where type='table'"));counts={t:c.execute('select count(*) from '+t).fetchone()[0] for t in ['PartA','PartB']}
samples={t:list(c.execute('select * from '+t+' limit 4')) for t in ['PartA','PartB']}
print(schema,counts,samples)
def decode(s):return ''.join(str(10-int(x)) if x!='0' else '0' for x in s)[::-1]
cases=[]
for mode,gp,cg,loc in itertools.product(range(3),['3.0','3.2','3.5'],['2.5'],[2000,3000,4500]):
 key=(gp+str(mode)+cg).replace('.','');ka=c.execute('select Value from PartA where ID=?',(key,)).fetchone();kb=c.execute('select Value from PartB where ID=?',(key+str(loc),)).fetchone()
 if not ka or not kb:raise RuntimeError(('missing requested database fixture',key,loc))
 a=str(ka[0]);b=str(kb[0]);d=decode(b)
 coeff=[ [int(decode(a[4:9]))*1e-6,0,int(decode(a[9:12]))*-.01], [int(decode(a[12:17]))*1e-6,0,int(decode(a[17:21]))*-.01], [int(d[:5])*1e-6,int(d[5:11])*1e-6,int(d[11:15])*-.01], [int(d[15:20])*1e-6,int(d[20:26])*1e-6,int(d[26:30])*-.01], [int(key[3:5])*-.001,0,int(decode(a[:4]))*-.01] ]
 cases.append(dict(mode=mode,gp=gp,cg=cg,loc=loc,key=key,partA=a,partB=b,coefficients=coeff))
c.close();assert before==hashlib.sha256(p.read_bytes()).hexdigest()
(E/'database-extract.json').write_text(json.dumps(dict(path=str(p.relative_to(ROOT)),sha256=before,open='Python sqlite3 URI mode=ro&immutable=1',schema=schema,counts=counts,first_rows=samples,cases=cases),ensure_ascii=False,indent=2),encoding='utf-8')
(F/'database-rows.tsv').write_text('\n'.join('\t'.join(map(str,[x['mode'],x['gp'],x['cg'],x['loc'],x['key'],x['partA'],x['partB']]+[v for plane in x['coefficients'] for v in plane])) for x in cases)+'\n',encoding='utf-8')
print('database fixtures',len(cases),'sha256',before)
