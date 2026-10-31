"""Build source/IL audit map from existing static metadata; never imports the target."""
from pathlib import Path
import csv,json,hashlib
BASE=Path(__file__).resolve().parent
R=BASE.parent/'reverse-analysis'
def rows(name):
    with (R/name).open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
raw={r['token']:r for r in rows('04_type-map/raw/methods.csv')}
processed={r['token']:r for r in rows('04_type-map/methods-only/methods.csv')}
mapping={r['processed_token']:r['original_token'] for r in rows('04_type-map/tool-token-map.csv') if r['kind']=='Method'}
locations=rows('04_type-map/method-source-locations.csv')
closure_path=BASE/'dynamic-test/closure-evidence-status.json'
closure=json.loads(closure_path.read_text(encoding='utf-8')) if closure_path.exists() else {}
compiled={r['path'].replace('\\','/'):r['status'] for r in closure.get('native_compiled_files',[])}
# A port can have several slices of one original method. No completion percentage.
specs={
 'CadInteraction.Recovered.cs': [('Pick','0x06000113'),('Number(string)','0x060007D4'),('Number(TextBox)','0x060007D5'),('Validate','0x060007D7')],
 'A2-BasicCalculation/BasicCalculationForm.Events.Recovered.cs': [('DrawFaf','0x0600022D'),('CalculateFaf','0x0600022F'),('Readable','0x06000230'),('DrawNpa','0x06000232'),('CalculateNpa','0x06000233'),('DrawPa','0x06000235'),('CalculatePa','0x06000237'),('CategoryChanged','0x06000238'),('CorrectHl','0x06000239'),('DrawMissed','0x0600023A'),('CalculateMissed','0x0600023B'),('DrawDeparture','0x0600023D'),('CalculateDeparture','0x0600023E'),('DrawC','0x06000240'),('CalculateC','0x06000241')],
 'A2-BasicCalculation/TurnParameterInput.Recovered.cs':[('TurnParametersRecovered.ctor','0x06000793'),('ToString','0x06000794'),('Read','0x06000854')],
 'A3-FixTolerance/FixToleranceForm.Events.Recovered.cs':[('VorChanged','0x06000209'),('IlsChanged','0x0600020A'),('NdbChanged','0x0600020B'),('GuideChanged','0x0600020C'),('DrawTolerance','0x0600020E'),('DrawBlind','0x06000211'),('BlindNdbChanged','0x06000212'),('BlindVorChanged','0x06000213'),('SpecifiedChanged','0x06000214'),('DmeChanged','0x06000215'),('AppendPolylineGroup','0x06000087')],
 'ObstacleData/ObstacleCad.Recovered.cs':[('ScreenData','0x0600010D'),('Parse','0x0600012F'),('Insert','0x0600009C'),('Import','0x0600009D'),('SetAttribute','0x0600009E')],
 'ObstacleData/EntityFrameCad.Recovered.cs':[('Load','0x06000717'),('ToBuffer','0x06000712'),('FromBuffer','0x06000713')],
 'ObstacleData/RandomPointForm.Events.Recovered.cs':[('Generate','0x06000349')],
 'ObstacleData/PriSec.Recovered.cs':[('Evaluate IF','0x06000330'),('Evaluate regular','0x06000331'),('Local frame','0x060000AC'),('Local transform','0x060000AD'),('LineY','0x060007E6'),('LineY coefficients','0x060007E7'),('LineY sentinel','0x060007E9'),('LineY divide','0x060007EA')],
 'ObstacleData/PriSecForm.Events.Recovered.cs':[('Screen','0x06000329'),('Screen table','0x0600032A'),('Evaluate table','0x0600032B'),('Evaluate','0x0600032F'),('Mark','0x0600033B')],
 'ObstacleData/TurnAreaForm.Events.Recovered.cs':[('Screen','0x0600024D'),('Screen table','0x0600024E'),('Evaluate table','0x0600024F'),('Evaluate frame','0x06000255'),('Evaluate','0x0600025E'),('Mark','0x06000254')]
}
generated=json.loads((BASE/'ObstacleData/evidence/screen-port-locations.json').read_text(encoding='utf-8'))
specs['ObstacleData/ScreenData.OtherForms.Recovered.cs']=[(r['form']+'.'+r['port'],r['tokens']) for r in generated]
# Resolve declarations by method location, not guesses about numerical token shifts.
by_token={r['tokens']:r for r in locations}
by_token['0x06000793']=dict(method='.ctor',source=r'03_recovered-src\annotated-strings\--\--.cs',line='81748')
by_token['0x0600010D']=dict(method='_008B_008A<T>',source=r'03_recovered-src\annotated-strings\-\-.cs',line='5120')
result=[]
for path,methods in specs.items():
    assert (BASE/path).is_file(),path
    for port,token in methods:
        loc=by_token[token];old=mapping[token]
        compile_state=compiled.get(path,'uncompiled')
        result.append(dict(port_file=path,port_method=port,processed_token=token,processed_rva=processed[token]['rva'],original_token=old,original_rva=raw[old]['rva'],source_method=loc['method'],source=loc['source'],line=loc['line'],evidence='L1 processed + L2 IL',native_status=compile_state+'; no original business runtime'+('; 19 recovered-code assertions' if path=='ObstacleData/PriSec.Recovered.cs' else '')))
with (BASE/'native-port-map.csv').open('w',encoding='utf-8-sig',newline='') as f:
    writer=csv.DictWriter(f,fieldnames=list(result[0]));writer.writeheader();writer.writerows(result)
print('Saved',len(result),'method slices to native-port-map.csv; inspect source_method for mapping errors.')
missing=[]
for row in result:
    evidence=list(BASE.glob('*/evidence/'+row['processed_token']+'.il.txt'))
    if not evidence:missing.append(dict(file=row['port_file'],method=row['port_method'],token=row['processed_token']))
artifact_files=[BASE/path for path in specs]+[BASE/'native-port-map.csv',BASE/'PriSec.Tests.cs',BASE/'PriSec.verification.log']
status=dict(method_slices=len(result),missing_packaged_il=missing,
            native_compiled=closure.get('native_compiled',False),
            compile_kind=closure.get('compile_kind','not compiled'),
            target_executed=closure.get('target_executed',False),L3=closure.get('L3',False),
            target_image_loaded=closure.get('target_image_loaded',False),
            observer_runtime=closure.get('observer_runtime',False),
            status_source='dynamic-test/closure-evidence-status.json' if closure else 'historical static audit',
            L3_definition='Original A2 / obstacle / A3 business behavior; image loading and Observer excluded',
            files=[dict(path=str(p.relative_to(BASE)),sha256=hashlib.sha256(p.read_bytes()).hexdigest()) for p in artifact_files])
(BASE/'native-evidence-status.json').write_text(json.dumps(status,ensure_ascii=False,indent=2),encoding='utf-8')
print('Packaged IL coverage:',len(result)-len(missing),'/',len(result),'slices. Compatibility compiled:',status['native_compiled'],'; business target executed:',status['target_executed'])
if missing:raise SystemExit('Missing IL evidence: '+repr(missing))
