from pathlib import Path
import csv,re,json,hashlib,sys
ROOT=Path(__file__).resolve().parents[2];R=ROOT/'reverse-analysis';O=ROOT/'recovered/round7';A=ROOT/'recovered/B4-PbnIls';E=A/'evidence'
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def out(p,rs):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
src=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
a=next(i for i,l in enumerate(src) if l=='\tpublic class _008A_0091');b=next(i for i in range(a+1,len(src)) if src[i]=='\t}')
(E/'a5-shared-parameter-structure.source.txt').write_text('\n'.join(f'{i+1}: {src[i]}' for i in range(a,b+1)),encoding='utf-8')
# Annotations generator adapted from the frozen Round 6 script; executed only at new path.
s=(ROOT/'recovered/round6/annotations.py').read_text(encoding='utf-8').replace('B3-RnpApch','B4-PbnIls').replace('round6','round7').replace('R6 MethodDef','R7 MethodDef')
start=s.index("classes={");end=s.index('\n',start)
s=s[:start]+"classes={'OasModel':'_008A_0093','PbnIlsTurn':'_008C_0095','PbnIlsObstacle':'_008A_008D','PlaneCarrier':'_008F_0092','PbnIlsForm':'_008B_0096'}"+s[end:]
(O/'annotations.py').write_text(s,encoding='utf-8')
# All control defaults and consumers, evidence fields instead of invented business names.
controls=rows(E/'controls.csv');state=rows(E/'control-state.csv');refs=rows(E/'control-references.csv');inventory=[]
for c in controls:
 inventory.append(dict(control=c['control_name'],field=c['field'],default_Text=';'.join(x['value'] for x in state if x['field']==c['field'] and x['property']=='Text' and int(x['line'])>=62613),default_SelectedIndex=';'.join(x['value'] for x in state if x['field']==c['field'] and x['property']=='SelectedIndex' and int(x['line'])>=62613),business_methods=';'.join(sorted({x['method'] for x in refs if x['field']==c['field'] and x['method']!='0x0600057F'})),evidence_line=c['line']))
out(E/'parameter-control-inventory.csv',inventory)
# Normative comparison is generated after independent code tests; cached text is read-only.
d=json.loads((ROOT/'recovered/round5/standard-pages.json').read_text(encoding='utf-8'));actual=hashlib.sha256((ROOT/d['path']).read_bytes()).hexdigest();assert actual==d['sha256']
terms=['障碍物评价面','自动驾驶','高度损失','复飞起始点','15°','OAS','oas','W*','W＊']
matches=[x for x in d['pages'] if 190<=x['pdf_page']<=420 and any(t in x['text'] for t in terms)]
(E/'standard-search.json').write_text(json.dumps(dict(path=d['path'],sha256=actual,matches=matches),ensure_ascii=False,indent=2),encoding='utf-8')
sys.stdout.reconfigure(encoding='utf-8');print('standard pages',[(x['pdf_page'],x['text'][:65].replace('\n',' ')) for x in matches])
help=ROOT/'WsTools-master/WindSpiral2026/帮助文件/FormPbnIlsEvl.html'
(E/'help-original.html').write_bytes(help.read_bytes())
baseline=json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8'))
key=[x for x in baseline if x['path'] in ['WsTools-master\\WindSpiral2026\\WindSpiralBasic.dll','reverse-analysis\\02_deobfuscated\\WindSpiralBasic.methods-only.dll',str(d['path'])] or x['path'].endswith(('WindSpiral2026\\oas.db','WindSpiral2026\\config.xml','FormPbnIlsEvl.html'))]
(E/'input-provenance.json').write_text(json.dumps(dict(workspace=str(ROOT),frozen_files=len(baseline),files=key),ensure_ascii=False,indent=2),encoding='utf-8')
