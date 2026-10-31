"""Extract only existing A2 reader edges and Round1 path locations; no DLL enumeration."""
import csv,json,pathlib,hashlib
R=pathlib.Path(__file__).resolve().parents[2]
B=R/'recovered'
sites=list(csv.DictReader((R/'reverse-analysis/05_callgraph/static-sites.csv').open(encoding='utf-8-sig')))
mapping={r['processed_token']:r['original_token'] for r in csv.DictReader((R/'reverse-analysis/04_type-map/tool-token-map.csv').open(encoding='utf-8-sig')) if r['kind']=='Method'}
readers=['0x06000655','0x060006AB']
evidence={
 'scope':'Existing processed static-sites direct call/callvirt index; no claim to rule out reflection or external assembly callers',
 'index_sha256':hashlib.sha256((R/'reverse-analysis/05_callgraph/static-sites.csv').read_bytes()).hexdigest(),
 'reader':dict(processed_token=readers[0],original_token=mapping.get(readers[0]),original_rva='0xB8D34',source_line=75103),
 'wrapper':dict(processed_token=readers[1],original_token=mapping.get(readers[1]),source_line=76214),
 'incoming_edges':{t:[r for r in sites if r['target']==t] for t in readers},
 'source_literal_search':[
   dict(path='annotated-strings/--/--.cs',line=74917,role='ResultBuffer app name'),
   dict(path='annotated-strings/--/--.cs',line=75010,role='Save registration'),
   dict(path='annotated-strings/--/--.cs',line=75075,role='SaveById registration'),
   dict(path='annotated-strings/--/--.cs',line=75128,role='Load GetXDataForApplication')],
 'conclusion':'metadata exists, but no evidence of automatic downstream semantic reuse.'}
(B/'A2-BasicCalculation/evidence/WsCalcuLine-downstream.json').write_text(json.dumps(evidence,ensure_ascii=False,indent=2),encoding='utf8')
ports=list(csv.DictReader((B/'native-port-map.csv').open(encoding='utf-8-sig')))
def find(file,method):
    return next(r for r in ports if r['port_file']==file and r['port_method']==method)
specs=[
 ('RandomPoint -> DBPoint + MText','ObstacleData/RandomPointForm.Events.Recovered.cs','Generate','No direct metadata write; shared empty-metadata append'),
 ('Model DBPoint -> SelectAll','ObstacleData/ObstacleCad.Recovered.cs','ScreenData','DXF0 POINT + DXF410 Model; no manual GetSelection'),
 ('DBPoint -> optional EntityFrame.Name / ID / XYZ','ObstacleData/ObstacleCad.Recovered.cs','Parse','ID supplied by caller ordinal; XYZ raw Position; name fallback'),
 ('EntityFrame buffer -> Name/type/Properties','ObstacleData/EntityFrameCad.Recovered.cs','FromBuffer','Does not synthesize height or tree-height'),
 ('A9 points -> imported DataTable / ID dictionary','ObstacleData/PriSecForm.Events.Recovered.cs','Screen','Rounded display only; original DBPoint retained'),
 ('A9 -> local obstacles / evaluator','ObstacleData/PriSecForm.Events.Recovered.cs','Evaluate','Absolute Z retained; OCA descending table; display -localXY'),
 ('A9 IF evaluator -> result','ObstacleData/PriSec.Recovered.cs','Evaluate IF','Endpoint inclusion and width differences retained'),
 ('A9 regular evaluator -> result','ObstacleData/PriSec.Recovered.cs','Evaluate regular','Endpoint exclusion retained'),
 ('A9 selected row -> original DBPoint -> obst','ObstacleData/PriSecForm.Events.Recovered.cs','Mark','Height from original Z, not OCA'),
 ('A8 points -> table','ObstacleData/TurnAreaForm.Events.Recovered.cs','Screen','Original point dictionary retained'),
 ('A8 -> local KK evaluation / table','ObstacleData/TurnAreaForm.Events.Recovered.cs','Evaluate','No outside filtering; sort value[4] descending'),
 ('A8 selected row -> obst / Name+Altitude','ObstacleData/TurnAreaForm.Events.Recovered.cs','Mark','IL resolves Name setter argument order'),
 ('Block missing -> symbol import','ObstacleData/ObstacleCad.Recovered.cs','Import','First WsSymbol*.dwg in executing assembly directory'),
 ('Original XYZ -> BlockReference+attributes','ObstacleData/ObstacleCad.Recovered.cs','Insert','Scale default1; no Constant filter'),
 ('BlockReference -> Altitude attribute','ObstacleData/ObstacleCad.Recovered.cs','SetAttribute','Case-insensitive via ToUpper; no break')]
rows=[]
for edge,f,m,note in specs:
    r=find(f,m)
    rows.append(dict(edge=edge,**r,note=note,runtime_evidence='Not yet validated in original target'))
with (B/'ObstacleData/evidence/closure-chain-edges.csv').open('w',encoding='utf-8-sig',newline='') as out:
    w=csv.DictWriter(out,fieldnames=rows[0].keys());w.writeheader();w.writerows(rows)
print('Saved targeted WsCalcuLine edges and',len(rows),'obstacle chain edges')
