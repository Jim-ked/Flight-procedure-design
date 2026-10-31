from pathlib import Path
import csv,re,sys
R=Path.cwd()/'reverse-analysis'
sys.stdout.reconfigure(encoding='utf-8')
def rows(p):
 with (R/p).open(encoding='utf-8-sig') as f:return list(csv.DictReader(f))
locs=rows('04_type-map/method-source-locations.csv')
methods=rows('04_type-map/methods-only/methods.csv')
for token in sys.argv[1:]:
 loc=next((x for x in locs if token in x['tokens'].split(';')),None)
 if loc is None:
  decl=next(x for x in list(csv.DictReader((Path.cwd()/'recovered/A6-Template/evidence/method-declarations.csv').open(encoding='utf-8-sig'))) if token in x['tokens'].split(';'))
  loc=dict(source='03_recovered-src/annotated-strings/--/--.cs',line=decl['line'])
 a=(R/loc['source']).read_text(encoding='utf-8').splitlines();s=int(loc['line'])-1
 e=next((i for i in range(s+1,len(a)) if re.match(r'^\t\t(?:public|private|internal|protected|static) .*\(',a[i])),len(a))
 print('\n###',token,next(x['name'] for x in methods if x['token']==token),'line',s+1)
 print('\n'.join(f'{i+1}: {a[i]}' for i in range(s,e) if '//IL_' not in a[i]))
