from pathlib import Path
p=Path('recovered/round6/supplement.py');s=p.read_text(encoding='utf-8')
s=s.replace("ms={x['processed_token']:x for x in rows(E/'method-index.csv')};calls=", "ms={x['processed_token']:x for x in rows(E/'method-index.csv')};\nfor t,ln in [('0x06000593',65895),('0x060005ED',72445)]:\n ms[t]['source']='03_recovered-src/annotated-strings/--/--.cs';ms[t]['line']=str(ln)\n ss=(R/ms[t]['source']).read_text(encoding='utf-8').splitlines();a=ln-1;indent=re.match(r'\\s*',ss[a])[0];b=next(j for j in range(a+1,len(ss)) if ss[j]==indent+'}')\n (E/('methods/'+t+'.source.txt')).write_text('\\n'.join(f'{i+1}: {ss[i]}' for i in range(a,b+1)),encoding='utf-8')\nout('method-index.csv',list(ms.values()))\ncalls=")
s=s.replace("dict(method=p.name.split('.')[0],keyword=term,IL=line)","dict(method=p.name.split('.')[0],keyword=term,classification=('clipboard, not clipping' if term=='Clip' and 'Clipboard' in line else 'UI GroupBox, not CAD Group' if term=='Group' and 'GroupBox' in line else 'API lexical candidate; see IL target'),IL=line)")
s=s.replace("['0x06000837','0x06000838']","['0x060007A0','0x060007A1']")
insert='''
for field in ['_0089_0088_009C','_0089_0088_008C','_0089_0088_0094','_0089_0088_009A']:
 check('APV factory does not read '+field,not any(x['field']==field and x['method']=='0x06000470' for x in refs))
for val in [30,60,120]:
 check('DH='+str(val)+' cannot feed APV factory through its disconnected control',not any(x['field']=='_0089_0088_009C' and x['method'] in ['0x06000470','0x0600047D'] for x in refs))
check('Group has no description setter','set_Description' not in (E/'processed/0x06000087.il.txt').read_text(encoding='utf-8'))
frozen=json.loads((O/'frozen-inputs.json').read_text(encoding='utf-8'))
key=[x for x in frozen if x['path'] in ['WsTools-master\\\\WindSpiral2026\\\\WindSpiralBasic.dll','reverse-analysis\\\\02_deobfuscated\\\\WindSpiralBasic.methods-only.dll',std['path']] or x['path'].endswith('WindSpiral2026\\\\config.xml')]
(E/'input-provenance.json').write_text(json.dumps(dict(workspace=str(ROOT),baseline='../round6/frozen-inputs.json',files=key,all_frozen_files=len(frozen)),ensure_ascii=False,indent=2),encoding='utf-8')
(O/'fixtures/static-applicability.json').write_text(json.dumps(dict(DH_values=[30,60,120],DH_effect='No factory reader; static only',LNAV_categories='A/B/C/D not consumed by LNAV factory',left_right_turn='Not implemented: no branch/turn geometry; no synthetic fixture',APV_SOC='No DH-HL pipeline; caller-specified length only',source='static-tests.json, control-references.csv, direct-calls.csv'),ensure_ascii=False,indent=2),encoding='utf-8')
'''
s=s.replace("(O/'static-tests.json').write_text",insert+"\n(O/'static-tests.json').write_text")
p.write_text(s,encoding='utf-8')
p=Path('recovered/round6/reports.py');s=p.read_text(encoding='utf-8');s=s.replace('包含四折线；description为完整控件状态文本','包含四折线；未设置Group.Description，文本参数用于实体XData');s=s.replace('|Group|description亦传入完整状态；本链未显式给Group写XData|','|Group|未设置Description；未显式写Group XData；完整状态只写各Polyline|');s=s.replace('每1°乘0.05，缺少0.1换算','以角度差直接乘0.05，缺少0.1换算');p.write_text(s,encoding='utf-8')
