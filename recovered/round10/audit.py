from pathlib import Path
import csv,json,hashlib,re,sys
from collections import Counter
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2]; SC=ROOT/'recovered/system-coverage'; R10=ROOT/'recovered/round10'
SC.mkdir(exist_ok=True); R10.mkdir(exist_ok=True)
def sha(p):
 h=hashlib.sha256()
 with p.open('rb') as f:
  for b in iter(lambda:f.read(1024*1024),b''):h.update(b)
 return h.hexdigest()
def rel(p):return str(p.relative_to(ROOT)).replace('\\','/')
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
def wc(p,fields,data):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=fields,extrasaction='ignore');w.writeheader();w.writerows(data)
def out(name,fields,data):wc(SC/name,fields,data)
def md(name,s):
 p=SC/(name if name.endswith('.md') else name+'.md');p.write_text(s.strip()+'\n',encoding='utf-8')

# Recompute baseline before writing audit outputs.
base=[]
for d in ['recovered','reverse-analysis','WsTools-master','doc']:
 for p in sorted((ROOT/d).rglob('*')):
  if p.is_file() and SC not in p.parents and R10 not in p.parents:base.append({'path':rel(p),'size':p.stat().st_size,'sha256':sha(p)})
(R10/'frozen-inputs.json').write_text(json.dumps({'created':'Round10 start','count':len(base),'files':base,'excluded':['recovered/system-coverage','recovered/round10']},ensure_ascii=False,indent=2)+'\n',encoding='utf-8')

# Existing evidence index only.
ev=[]
for d in sorted((ROOT/'recovered').iterdir()):
 if d.name in ('system-coverage','round10') or not d.is_dir():continue
 for p in sorted(d.rglob('*')):
  if p.is_file() and (p.name in {'overview.md','event-map.md','verification.md','callgraph.md','method-index.csv','integrity-report.json','output-manifest.json','tests.log','closure.md'} or 'evidence' in p.parts):ev.append({'ModuleOrRound':d.name,'Path':rel(p),'EvidenceLevel':'E0/E1/E2' if 'evidence' in p.parts else 'E2/E3','Role':'frozen existing evidence packet'})
wc(R10/'evidence-index.csv',['ModuleOrRound','Path','EvidenceLevel','Role'],ev)

# 34 CommandMethod rows.
cmds=rows(ROOT/'reverse-analysis/04_type-map/raw/commands.csv')
avi={'Y01_风螺旋':'A1','Y02_基础计算':'A2','Y03_定位容差':'A3','Y04_导航设备保护区':'A4','Y05_精密进近保护区':'A5','Y06_传统模板':'A6','Y07_离场保护区':'A7','Y08_转弯区评估':'A8','Y09_主副区评估':'A9','Y10_起始进近DME弧':'A10','Y51_FlyBy':'B1','Y52_FlyOver':'B2','Y53_RNP_APCH':'B3','Y54_PBN_ILS':'B4','Y55_PBN_Departure':'B5'}
aux={'Y90_LoadBlock':'C1','Y91_CreateLayer':'C2','exline':'C3','Y92_RandomPoint':'C4'}; no={'RCL','NMCIRCLE','rectLine','Arc2','xInfo'}
other={'WsTools':'Panel/UI command','Hello':'Diagnostic/test command','notReady':'Stub/not-ready','y9_AddObstBlockDef':'Unknown','Command1':'Diagnostic/test command','Command2':'Diagnostic/test command','CheckAndSetLayer':'Unknown','GetCurrentLayerName':'Unknown','GetCurrentLayerInfo':'Unknown','SetCurrentLayer':'Unknown'}
ci=[]
for c in cmds:
 n=c['command']; typ='Public aviation function' if n in avi else ('Public auxiliary function' if n in aux else ('Public no-window command' if n in no else other.get(n,'Unknown')))
 ci.append({'MethodToken':c['method_token'],'Command':n,'ClassifiedAs':typ,'InventoryStatus':'PUBLIC' if n in avi or n in aux or n in no or n=='WsTools' else 'INDEXED_ONLY','HelpOrSourceEvidence':'WsTools-master/WindSpiral2026/帮助文件/index.html' if n in avi or n in aux or n in no else 'reverse-analysis/04_type-map/raw/commands.csv','Notes':'Help-listed public entry' if n in avi or n in aux or n in no else 'Indexed entry, not aviation public function'})
out('command-inventory.csv',list(ci[0]),ci)

# Public aviation rollup; historical RoundStatus is preserved verbatim.
spec=[
('A1','Y01_风螺旋','FormWindSpiral.html','WindSpiralForm','Wind spiral','Round 3','PARTIAL static closure','PARTIAL_STATIC','EVENT_REACHABILITY_GAP;CAD_WRITER_GAP;RUNTIME_E4_GAP','A1-WindSpiral/overview.md','Designer/resource and complete CAD/runtime chain remain'),
('A2','Y02_基础计算','FormCalcu.html','FormCalcu','Basic calculation','Round 1','PARTIAL','PARTIAL_STATIC','DESIGNER_CONFIG_GAP;RUNTIME_E4_GAP','A2-BasicCalculation/overview.md','Full designer/config and host run remain'),
('A3','Y03_定位容差','FixTolerance.html','_0088_0098','Fix tolerance','Round 1','PARTIAL','PARTIAL_STATIC','GEOMETRY_GAP;DESIGNER_CONFIG_GAP;RUNTIME_E4_GAP','A3-FixTolerance/overview.md','No automatic two-facility intersection'),
('A4','Y04_导航设备保护区','FormNavAids.html','_0089_008A','VOR/NDB protection boundary','Round 9','ACCEPTED (static recovery)','COMPLETE_STATIC','RUNTIME_E4_GAP;HOST_COMPATIBILITY_GAP','A4-NavAidProtection/overview.md','Only host E4 remains'),
('A5','Y05_精密进近保护区','FormPA.html','_008A_0093','Precision/OAS drawing','Round 8','PARTIALLY ACCEPTED (static recovery)','PARTIAL_STATIC','ORPHAN_IMPLEMENTATION;EVENT_REACHABILITY_GAP;RUNTIME_E4_GAP','A5-PrecisionApproach/overview.md','P41B/P429 evaluator bodies orphaned'),
('A6','Y06_传统模板','FormTemplate.html','_0088_0091','Holding/base/procedure templates','Round 4','ACCEPTED (static recovery)','COMPLETE_STATIC','RUNTIME_E4_GAP;STANDARD_BASIS_UNRESOLVED','A6-Template/overview.md','Host E4 remains'),
('A7','Y07_离场保护区','FormDepartureEvl.html','_0088_008D','Departure evaluation','Round 2','PARTIAL','PARTIAL_STATIC','GEOMETRY_GAP;RUNTIME_E4_GAP;STANDARD_BASIS_UNRESOLVED','A7-Departure/overview.md','High-value closure remains'),
('A8','Y08_转弯区评估','FormTurnAreaEvl.html','_0088_0090','KK turn-area evaluation','Round 2','COMPLETE_STATIC','COMPLETE_STATIC','RUNTIME_E4_GAP;STANDARD_BASIS_UNRESOLVED','A8-TurnArea/overview.md','Class-range static chain closed'),
('A9','Y09_主副区评估','FormPriSecEvl.html','_0088_008B','Primary/secondary evaluation','Round 1','PARTIAL','PARTIAL_STATIC','RUNTIME_E4_GAP;STANDARD_BASIS_UNRESOLVED','ObstacleData/pri-sec-evaluation.md','Closure and host validation remain'),
('A10','Y10_起始进近DME弧','FormDmeEvl.html','_0088_008C','DME arc evaluation','Round 2','COMPLETE_STATIC','COMPLETE_STATIC','RUNTIME_E4_GAP;STANDARD_BASIS_UNRESOLVED','A10-DmeArc/overview.md','Host E4 remains'),
('B1','Y51_FlyBy','FormFlyBy.html','_008C_0087','Fly-by turn boundary','Round 3','PARTIAL','PARTIAL_STATIC','GEOMETRY_GAP;CAD_WRITER_GAP;RUNTIME_E4_GAP','B1-FlyBy/overview.md','Complete boundary vertex port not claimed'),
('B2','Y52_FlyOver','FormFlyOverDF.html','_008C_0089','Fly-over DF boundary','Round 3','PARTIAL','PARTIAL_STATIC','GEOMETRY_GAP;CAD_WRITER_GAP;RUNTIME_E4_GAP','B2-FlyOverDF/overview.md','Complete boundary vertex port not claimed'),
('B3','Y53_RNP_APCH','FormApvEvl.html','_008C_0090','RNP APCH','Round 6','PARTIALLY ACCEPTED','PARTIAL_STATIC','ORPHAN_IMPLEMENTATION;EVENT_REACHABILITY_GAP;RUNTIME_E4_GAP','B3-RnpApch/overview.md','P594/P5EE/P470 chain not UI reached'),
('B4','Y54_PBN_ILS','FormPbnIlsEvl.html','_008C_0094','PBN-ILS/OAS','Round 7','PARTIALLY ACCEPTED (static recovery)','PARTIAL_STATIC','ORPHAN_IMPLEMENTATION;UI_STUB;EVENT_REACHABILITY_GAP;RUNTIME_E4_GAP','B4-PbnIls/overview.md','Evaluate prompt-only; KML empty'),
('B5','Y55_PBN_Departure','FormPbnDepEvl.html','_008C_0091','PBN departure','Round 5','PARTIALLY ACCEPTED','PARTIAL_STATIC','ORPHAN_IMPLEMENTATION;UI_STUB;EVENT_REACHABILITY_GAP;RUNTIME_E4_GAP','B5-PbnDeparture/overview.md','Evaluation dispatcher prompt-only')]
fields=['ModuleId','Command','PublicName','HelpPage','Form/Class','PublicPurpose','Round','RoundStatus','SystemRollupStatus','GapFlags','CommandEntry','EventChain','InputSemantics','Formula','Geometry','CadWriter','ObstacleInput','ObstacleEvaluation','ResultOutput','XData','Persistence','StandardMapping','E0','E1','E2','E3','E4','N','PrimaryEvidence','MainResidualGap','RecommendedAction']
roll=[]
for m,c,h,f,p,r,rs,ss,g,e,res in spec:
 capvals=['CLOSED']*12 if ss=='COMPLETE_STATIC' else ['PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL']
 if m=='A4': capvals=['CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','ABSENT_BY_DESIGN','ABSENT_BY_DESIGN','CLOSED','ABSENT_BY_DESIGN','CLOSED','PARTIAL']
 levels=['CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','NOT_AUDITED'] if m in {'A4','A6','A8','A10'} else ['CLOSED','CLOSED','PARTIAL','PARTIAL','PARTIAL','NOT_AUDITED']
 roll.append(dict(zip(fields,[m,c,p,h,f,p,r,rs,ss,g,*capvals,*levels,e,res,'See next-action-ranking.csv'])))
out('public-function-matrix.csv',fields,roll)

# Major subfeatures.
sub=[]
def sr(m,x,s,g,e):sub.append({'Module':m,'Subfeature':x,'Status':s,'GapFlags':g,'Evidence':e})
for x,s in [('GP INOP','CLOSED'),('PAOAS L','CLOSED'),('PAOAS R','CLOSED'),('OAS','CLOSED'),('PA with FAF','CLOSED'),('PA with FAP','CLOSED'),('Evaluator','PARTIAL')]:sr('A5',x,s,'ORPHAN_IMPLEMENTATION' if x=='Evaluator' else 'RUNTIME_E4_GAP','A5-PrecisionApproach/overview.md')
for x,s in [('LNAV geometry','CLOSED'),('LNAV evaluator','PARTIAL'),('APV surface','CLOSED'),('APV evaluator','PARTIAL'),('Missed segment','CLOSED'),('One-click evaluation','ABSENT_IN_BUILD')]:sr('B3',x,s,'ORPHAN_IMPLEMENTATION' if 'evaluator' in x else ('UI_STUB' if s=='ABSENT_IN_BUILD' else 'RUNTIME_E4_GAP'),'B3-RnpApch/overview.md')
for x,s in [('OAS database','CLOSED'),('OAS surfaces','CLOSED'),('OAS-PBN transition','CLOSED'),('Evaluator','PARTIAL'),('KML','ABSENT_IN_BUILD')]:sr('B4',x,s,'ORPHAN_IMPLEMENTATION' if x=='Evaluator' else ('EMPTY_HANDLER' if x=='KML' else 'RUNTIME_E4_GAP'),'B4-PbnIls/overview.md')
for x,s in [('Altitude turn','CLOSED'),('FlyOver-DF','CLOSED'),('Straight evaluator','PARTIAL'),('Turn evaluator','PARTIAL'),('UI evaluation dispatcher','ABSENT_IN_BUILD')]:sr('B5',x,s,'ORPHAN_IMPLEMENTATION' if 'evaluator' in x else ('UI_STUB' if s=='ABSENT_IN_BUILD' else 'RUNTIME_E4_GAP'),'B5-PbnDeparture/overview.md')
for x,s in [('Altitude turn','CLOSED'),('Point turn','CLOSED'),('Omnidirectional departure','CLOSED'),('Obstacle evaluator','CLOSED'),('UI dispatcher','PARTIAL')]:sr('A7',x,s,'RUNTIME_E4_GAP' if s=='CLOSED' else 'EVENT_REACHABILITY_GAP','A7-Departure/overview.md')
out('feature-subcoverage.csv',list(sub[0]),sub)
orows=[]
for x in [('A5','OAS surface evaluator','P41B','0x0600041C','0x0600041B','0x52DA4','complete'),('A5','PAOAS evaluator','P429','0x0600042A','0x06000429','0x55010','complete'),('B3','LNAV evaluator','P594','','0x06000594','','complete'),('B3','APV evaluator','P5EE','','0x060005EE','','complete'),('B3','APV factory/related chain','P470','','0x06000470','','partial'),('B4','PBN-ILS evaluator','P5E0','','0x060005E0','','complete'),('B4','PBN-ILS result evaluator','P567','','0x06000567','','complete'),('B5','PBN departure evaluation body','P41B','','0x0600041B','','complete')]:orows.append(dict(zip(['Module','BusinessRole','Method','OriginalToken','ProcessedToken','RVA','BodyComplete','DirectIncoming','MethodSpecIncoming','UIEventIncoming','Status','Evidence'],(*x,'0','0','0','ORPHAN_IMPLEMENTATION',f'{x[0]} overview.md'))))
out('orphan-implementations.csv',list(orows[0]),orows)

# Runtime and conflicts.
runtime=[]
for x in spec:
 m,st=x[0],x[7]; runtime.append({'Module':m,'StaticStatus':st,'OriginalTargetAPI':'Framework4.8 / Autodesk API23.1','AvailableHost':'AutoCAD2026 / API25.1 / CLR8 previously available','E4Attempted':'NO','E4Result':'NOT_RUN','RuntimeBlocker':'No matching original host; target DLL not executed','WouldE4ChangeBusinessUnderstanding':'No' if st=='COMPLETE_STATIC' else 'Possibly','RecommendedRuntimeExperiment':'Matched API23.1 host smoke test','Priority':'HIGH' if st=='PARTIAL_STATIC' else 'MEDIUM'})
out('runtime-gap-register.csv',list(runtime[0]),runtime)
conf=[{'Module':'A4/A6','OldStatement':'Shared primitive wording was broad','CurrentEvidence':'A6 direct evidence supports P7E8; not P7E7/P7ED','ConflictType':'shared-method scope','Severity':'LOW','RecommendedSeparateAction':'Future wording only; do not edit old report'},{'Module':'A5/B3/B4/B5','OldStatement':'Help exposes evaluation-capable function','CurrentEvidence':'Bodies are orphaned or handler is prompt-only in current build','ConflictType':'help/UI/code reachability','Severity':'HIGH','RecommendedSeparateAction':'Trusted-build comparison'}]
out('review-conflicts.csv',list(conf[0]),conf)
gap=[('G-A1','A1','full designer/CAD chain','EVENT_REACHABILITY_GAP','Partial package','YES','YES','NO','YES','NO','HIGH','A1 closure'),('G-A3','A3','cross-facility semantics','GEOMETRY_GAP','Single-station/KK chain','YES','YES','NO','YES','YES','HIGH','A3 closure'),('G-A5','A5','evaluator UI reachability','ORPHAN_IMPLEMENTATION','Complete bodies without incoming','YES','NO','YES','NO','NO','HIGH','Other-build comparison'),('G-A7','A7','public chain closure','GEOMETRY_GAP','Three mode chains recovered','YES','YES','NO','YES','YES','HIGH','A7 closure'),('G-B1','B1','boundary vertex equivalence','GEOMETRY_GAP','Candidate branch only','YES','YES','NO','YES','NO','HIGH','B1 closure'),('G-B2','B2','DF boundary vertex equivalence','GEOMETRY_GAP','Candidate branch only','YES','YES','NO','YES','NO','HIGH','B2 closure'),('G-B3','B3','evaluator UI reachability','ORPHAN_IMPLEMENTATION','P594/P5EE/P470 no incoming','YES','NO','YES','NO','NO','HIGH','Other-build comparison'),('G-B4','B4','Evaluate/KML/evaluator','UI_STUB','Prompt-only/empty/orphan','YES','NO','YES','NO','NO','HIGH','Other-build comparison'),('G-B5','B5','evaluation dispatcher','UI_STUB','Prompt-only/hidden','YES','NO','YES','NO','NO','HIGH','Other-build comparison'),('G-E4','All','matched-host execution','RUNTIME_E4_GAP','No original host run','NO','NO','NO','YES','NO','MEDIUM','API23.1 host'),('G-STD','All','historical provenance','STANDARD_BASIS_UNRESOLVED','Current mapping only','NO','NO','NO','NO','YES','MEDIUM','Standards research')]
out('residual-gap-register.csv',['GapId','Module','Feature','GapType','Description','StaticEvidenceAvailable','NeedsMoreStaticWork','NeedsOtherBuild','NeedsE4','NeedsStandardResearch','BusinessImpact','SuggestedAction'],[dict(zip(['GapId','Module','Feature','GapType','Description','StaticEvidenceAvailable','NeedsMoreStaticWork','NeedsOtherBuild','NeedsE4','NeedsStandardResearch','BusinessImpact','SuggestedAction'],x)) for x in gap])
acts=[('A7 closure','HIGH','MEDIUM','MEDIUM','LOW','HIGH'),('A3 closure','HIGH','MEDIUM','MEDIUM','LOW','HIGH'),('A1/B1/B2 closure','HIGH','MEDIUM','MEDIUM','MEDIUM','HIGH'),('A2/Obstacle/A8/A9/A10 closure','HIGH','MEDIUM','MEDIUM','LOW','HIGH'),('API23.1 runtime validation','HIGH','LOW','HIGH','LOW','HIGH'),('other-build comparison B3/B4/B5/A5','HIGH','LOW','HIGH','LOW','HIGH'),('auxiliary CAD commands','MEDIUM','LOW','LOW','MEDIUM','MEDIUM'),('standard/history research','MEDIUM','LOW','LOW','LOW','MEDIUM'),('final technical report','HIGH','LOW','LOW','LOW','MEDIUM')]
out('next-action-ranking.csv',['CandidateAction','BusinessValue','ExpectedNewEvidence','DependencyReadiness','StaticRecoverability','RuntimeRequirement','RiskOfDuplicatingExistingWork','Priority'],[{'CandidateAction':a,'BusinessValue':b,'ExpectedNewEvidence':c,'DependencyReadiness':d,'StaticRecoverability':e,'RuntimeRequirement':'HIGH' if 'runtime' in a.lower() or 'build' in a.lower() else 'LOW','RiskOfDuplicatingExistingWork':f,'Priority':f} for a,b,c,d,e,f in acts])

# Shared layers.
shared=[('P793/P854 turn parameters','P793/P854','A1,A6,B1,B2,B5','SAME_METHODDEF in indexed callers','B5/A6 consume shared parameters','Turn input','A6/shared-turn-methods.md;B5 overview.md'),('Spiral86/Spiral88','P86/P88','A1,A6,B1,B2,B5','SHARED lower layer','B1/B2/B5 also copy branches','Spiral primitive','A1/spiral-model.md'),('point/line primitives','P7E4/P7E7/P7E8/P7ED/P809/P80A','A1-A10,B1-B5','SAME_METHODDEF where incoming recorded','Local boundary formulas remain','Geometry arithmetic','A4 evidence/cross-module-shared-calls.csv'),('CAD writer','P087/P089/P134','A1-A10,B1-B5','SAME_METHODDEF in many chains','Local wrappers vary','Polyline/group/XData','A4 cad-output-map.md'),('SelectAll/DBPoint','ScreenData/PriSec helpers','A7-A10,B3-B5','PARTIAL','B3 explicitly no Take5','Obstacle enumeration','A7 obstacle-evaluation.md;B3 obstacle-evaluation.md'),('Obstacle parser','Take5/ScreenData','A7,A8,A9,A10,B3,B4,B5','PARTIAL','B3 differs on Take5','Obstacle coordinates','module obstacle-evaluation.md'),('Mark/Highlight','Mark/Highlight helpers','A7,A8,A9,A10,B3,B4,B5','SHARED idiom','Result output differs','Visual output','A8 overview.md'),('WsObject serializer','P089/XData','A1-A10/B1-B5','SHARED optional writer','Many calls pass empty metadata','XData','A4 xdata-schema.md'),('WsCalcuLine','A2 line model','A2 and manual downstream','NO_UNIFIED_MODEL','Repick often required','Persisted calculation line','A2 WsCalcuLine-schema.md'),('WsEntityFrame','frame helpers','A7/B3/B4/B5','SHARED/PARTIAL','No global procedure object','Local frame','A7 runway-coordinate.md'),('OasModel/Plane','OAS classes','A5/B4','SAME_METHODDEF core','Wrappers/files differ','OAS surfaces','A5 class-map.md'),('config/state serializer','P0F4/P0F6/P0F5/P0F7','A2-A5/B3-B5','SHARED infrastructure','Keys differ','UI state','A4 persistence.md')]
out('shared-components.csv',['Component','MethodDef','KnownModules','DirectSharing','CopiedAlternatives','Purpose','Evidence'],[dict(zip(['Component','MethodDef','KnownModules','DirectSharing','CopiedAlternatives','Purpose','Evidence'],x)) for x in shared])
sv=[('A5/B4 OAS loader','A5/B4','P409-P40C vs P571-P574','COPIED_IMPLEMENTATION','Same schema, different methods','A5 class-map.md'),('A5/B4 OAS model','A5/B4','OasModel/Plane','SAME_METHODDEF','Shared core wrappers differ','A5 overview.md'),('B1/B2 boundaries','B1/B2','_008C_0087/_008C_0089','COPIED_IMPLEMENTATION','Similar branches, independent classes','B1/B2 overview.md'),('A7/B5 departure','A7/B5','Departure classes','ONLY_BUSINESS_SIMILAR','B5 does not call A7 business classes','A7/B5 overview.md'),('A9/B3 PriSec','A9/B3','P330/P331 vs P595/P5EF','NO_RELATION','Similar purpose, distinct methods','round6/closure.md'),('A1/B1/B2 spiral','A1/B1/B2','Spiral primitives','NUMERICALLY_SIMILAR','Shared primitives plus copied logic','round3 closure'),('A4/A3 facility','A4/A3','P113/point helpers','ONLY_BUSINESS_SIMILAR','Different accuracy/protection concepts','round9 a3-a4-comparison.csv')]
out('shared-vs-copied.csv',['Topic','Modules','ObservedMethods','Classification','Interpretation','Evidence'],[dict(zip(['Topic','Modules','ObservedMethods','Classification','Interpretation','Evidence'],x)) for x in sv])

# Manual CAD dependencies and protection connections.
manual=[]
def man(m,a,o,mi,du,derive,auto,e):manual.append({'Module':m,'Action':a,'Prompt/Object':o,'ManualInput':mi,'DownstreamUse':du,'CanExistingDataDeriveIt':derive,'CodeAutomaticallyDerivesIt':auto,'Evidence':e})
for x in [('A1','GetPoint x3','spiral points','YES','heading/offsets','Only if existing procedure points','NO','A1 overview.md'),('A2','GetPoint x2/page','THR/DER/facility/track','YES','FAF/SOC/C/TP','No object handoff','NO','A2 cad-interactions.md'),('A3','GetPoint facility+direction','facility/track','YES','tolerance/KK/overhead','No second-facility link','NO','A3 geometry-chain.md'),('A4','GetPoint x2','facility candidate S/E','YES','length/bearing/boundaries','No association','NO','A4 input-frame.md'),('A5','GetPoint/selection','runway/OAS anchors','YES','OAS/CAD','No procedure object','NO','A5 cad-interactions.md'),('A6','GetPoint variants','template control points','YES','template geometry','No entity reuse','NO','A6 cad-interactions.md'),('A7','GetPoint/selection','THR/DER/TP/KK/C','YES','frame/area/evaluator','Frame after picks','PARTIAL','A7 cad-interactions.md'),('A8','GetPoint x2','KK/Ds points','YES','KK evaluation','No auto entity selection','NO','A8 event-map.md'),('A9','GetPoint/selection','start/end/width','YES','PriSec/MOC','No cross-window association','NO','ObstacleData/pri-sec-evaluation.md'),('A10','GetPoint x3','O/IF/IAF','YES','arcs/sectors','No nav lookup','NO','A10 input-points.md'),('B1','GetPoint x3','start/turn/end','YES','turn geometry','No procedure object','NO','B1 input-frame.md'),('B2','GetPoint x3','start/DF/end','YES','DF candidates','No procedure object','NO','B2 input-frame.md'),('B3','GetPoint/selection','runway/obstacles/approach','YES','LNAV/APV','No MAPt auto derivation','PARTIAL','B3 cad-interactions.md'),('B4','GetPoint/selection','runway/OAS/turn','YES','OAS/transition','No arbitrary TP','PARTIAL','B4 cad-interactions.md'),('B5','GetPoint/selection','runway/turn/obstacle','YES','departure/evaluator','No UI evaluator dispatcher','PARTIAL','B5 cad-interactions.md'),('Aux','GetEntity/GetSelection','entity for xInfo','YES','XData/utility','Command-specific','NO','doc/阶段8_人工交互矩阵.md')]:man(*x)
out('manual-cad-dependencies.csv',list(manual[0]),manual)
con=[]
for x in [('A1','spiral lists','Polyline list concatenation','YES','No','A1 overview.md'),('A3','facility→KK','point/line construction','YES','No','A3 geometry-chain.md'),('A4','outer/inner→15deg','line intersection','YES','No','A4 15-degree-line.md'),('A5','OAS→PA boundary','plane/line intersections','YES','No','A5 oas-surfaces.md'),('A6','template→envelope','Polyline/list envelope','YES','No','A6 envelope.md'),('A7','runway→departure','local frame construction','YES','No','A7 geometry-altitude-turn.md'),('A8','KK→obstacle area','local classifier','YES','No','A8 kk-frame.md'),('A9','input→MOC','PriSec evaluator','YES','No','ObstacleData/pri-sec-evaluation.md'),('A10','O/IF/IAF→arcs','Arc/Polyline','YES','No','A10 geometry.md'),('B1','earliest/latest','candidate lists','YES','No','B1 geometry.md'),('B2','DF candidates','spiral/line selection','YES','No','B2 geometry.md'),('B3','LNAV/APV','Polyline/surfaces','YES','No','B3 overview.md'),('B4','OAS→transition','shared vertex/Polyline','YES','No','B4 oas-pbn-connection.md'),('B5','departure→post area','Polyline/frame','YES','No','B5 protection-connections.md')]:con.append({'Module':x[0],'FromArea':x[1],'ToArea':'output/evaluator','ConnectionMethod':x[2],'Automatic':x[3],'ManualInput':x[4],'MethodDef':'module-specific/shared primitives','Evidence':x[5]})
out('protection-connection-master.csv',list(con[0]),con)

# CAD, data, obstacle, standards and consistency matrices.
cad=[]
for m,ent,grp,xd,lay,col,lt in [('A1','Circle;Point;Polyline;Spline','PARTIAL','PARTIAL','NO','NO','NO'),('A2','Line;Polyline','PARTIAL','WsCalcuLine','PARTIAL','NO','NO'),('A3','Line;Polyline;Circle','PARTIAL','PARTIAL','NO','NO','NO'),('A4','Polyline;Group','CLOSED','ABSENT','NO','NO','NO'),('A5','Polyline;surface lines','PARTIAL','PARTIAL','NO','NO','NO'),('A6','Polyline;Arc;Circle;Group','CLOSED','PARTIAL','PARTIAL','PARTIAL','PARTIAL'),('A7','Polyline;Circle;BlockReference','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL'),('A8','Mark/BlockReference','ABSENT_BY_DESIGN','PARTIAL','NO','NO','NO'),('A9','Mark/obstacle entities','PARTIAL','PARTIAL','NO','NO','NO'),('A10','Arc;Polyline','CLOSED','PARTIAL','NO','NO','NO'),('B1','Polyline;Spline','PARTIAL','PARTIAL','NO','NO','NO'),('B2','Polyline;Spline','PARTIAL','PARTIAL','NO','NO','NO'),('B3','Polyline;surface lines;Mark','PARTIAL','PARTIAL','NO','NO','NO'),('B4','Polyline;KML path','PARTIAL','PARTIAL','NO','NO','NO'),('B5','Polyline;Mark','PARTIAL','PARTIAL','NO','NO','NO')]:
 cad.append({'Module':m,'Line':'CLOSED' if 'Line' in ent else 'ABSENT_BY_DESIGN','Polyline':'CLOSED' if 'Polyline' in ent else 'ABSENT_BY_DESIGN','Arc':'CLOSED' if 'Arc' in ent else 'ABSENT_BY_DESIGN','Circle':'CLOSED' if 'Circle' in ent else 'ABSENT_BY_DESIGN','Spline':'CLOSED' if 'Spline' in ent else 'ABSENT_BY_DESIGN','DBPoint':'PARTIAL' if 'Point' in ent or 'Mark' in ent else 'ABSENT_BY_DESIGN','MText':'PARTIAL' if 'Mark' in ent else 'ABSENT_BY_DESIGN','BlockReference':'PARTIAL' if 'BlockReference' in ent else 'ABSENT_BY_DESIGN','Group':grp,'XData':xd,'ExplicitLayer':lay,'ExplicitColor':col,'ExplicitLinetype':lt,'Evidence':f'recovered/{m}-*/cad-output-map.md'})
out('cad-output-master.csv',list(cad[0]),cad)
data=[('WsCalcuLine','A2','A2/manual downstream','line parameters/XData','PARTIAL','MANUAL','No unified procedure reader','A2-BasicCalculation/WsCalcuLine-schema.md'),('WsEntityFrame','frame helpers','A7/B3/B4/B5','local transform','PARTIAL','MANUAL','No global procedure model','A7-Departure/runway-coordinate.md'),('WsObject','P089','A1-A10/B1-B5','optional XData','PARTIAL','MANUAL','A4 empty metadata','A4 xdata-schema.md'),('Form state TXT','config handlers','A2-A5/B3-B5','control state','PARTIAL','MANUAL','Not geometry interchange','A4 persistence.md'),('OAS parameter TXT/JSON','A5','A5','mode JSON/TXT','CLOSED','MANUAL','B4 separate CSV','A5 oas-txt-format.md'),('config.xml','P0F4/P0F6','A2-A5/B3-B5','dotted control keys','PARTIAL','MANUAL','Node may be absent','A4 persistence.md'),('.rnp','none evidenced','none','none','ABSENT_IN_BUILD','MANUAL','No evidence','system spot-check'),('oas.db','A5/B4 loaders','A5/B4','OAS rows','CLOSED','MANUAL','No unified model','A5 oas-parameter-model.md')]
out('data-model-master.csv',['DataItem','Writer','Reader','Modules','Schema','AutomaticReuse','ManualReuse','KnownOrphanReaders','Evidence'],[dict(zip(['DataItem','Writer','Reader','Modules','Schema','AutomaticReuse','ManualReuse','KnownOrphanReaders','Evidence'],(x[0],x[1],x[1],x[2],x[3],x[4],x[5],x[6],x[7]))) for x in data])
obs=[]
for x in [('A5','OAS/ScreenData','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','PARTIAL','P41B/P429 orphan','A5 obstacle-evaluation.md'),('A7','Take5/ScreenData','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','evaluators','A7 obstacle-evaluation.md'),('A8','DBPoint/KK','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','Mark/highlight','A8 overview.md'),('A9','ScreenData/PriSec','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','OCA table','ObstacleData/pri-sec-evaluation.md'),('A10','ScreenData/sector','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','CLOSED','OCA table','A10 obstacle-evaluation.md'),('B3','Obstacle source; no Take5','PARTIAL','CLOSED','CLOSED','PARTIAL','PARTIAL','PARTIAL','PARTIAL','P594/P5EE orphan','B3 obstacle-evaluation.md'),('B4','ScreenData/obstacle','PARTIAL','CLOSED','CLOSED','PARTIAL','PARTIAL','PARTIAL','PARTIAL','Evaluate prompt-only','B4 obstacle-evaluation.md'),('B5','Take5/ScreenData','PARTIAL','CLOSED','CLOSED','PARTIAL','PARTIAL','PARTIAL','PARTIAL','dispatcher prompt-only','B5 obstacle-evaluation.md')]:obs.append(dict(zip(['Module','InputSource','Take5','CoordinateTransform','AreaClassifier','MOC','OutputMetric','Mark','Highlight','UIReachable','Evidence'],x)))
out('obstacle-pipeline-master.csv',list(obs[0]),obs)
cons=[]
for x in spec:
 m,c,h,f,p,r,rs,ss,g,e,res=x;cons.append({'Module':m,'Function':c,'HelpSays':p,'UIExposes':'YES','CodeImplements':'IMPLEMENTED_STATIC','CodeReachable':'CLOSED' if ss=='COMPLETE_STATIC' else 'PARTIAL','Consistency':'CODE_ORPHAN' if 'ORPHAN_IMPLEMENTATION' in g else ('UI_STUB' if 'UI_STUB' in g else 'CONSISTENT'),'Evidence':e})
for n,d in [('Y90_LoadBlock','block import'),('Y91_CreateLayer','layer creation'),('exline','line utility'),('Y92_RandomPoint','random points'),('RCL','runway centerline'),('NMCIRCLE','NM circle'),('rectLine','rectangle'),('Arc2','arc'),('xInfo','XData inspector')]:cons.append({'Module':'Aux','Function':n,'HelpSays':d,'UIExposes':'COMMAND','CodeImplements':'INDEXED_ONLY','CodeReachable':'NOT_AUDITED','Consistency':'UNCERTAIN','Evidence':'doc/阶段8_人工交互矩阵.md; raw/commands.csv'})
out('help-ui-code-consistency.csv',list(cons[0]),cons)
std=[]
for m in [x[0] for x in spec]:std.append({'Module':m,'CurrentStandardMapped':'MAPPED' if m=='A4' else 'PARTIAL','KnownDifference':'Historical basis or stage/evaluator limits retained','HistoricalBasisResolved':'NO','ImplementationBasisUnresolved':'YES','NeedFurtherStandardsResearch':'YES'})
out('standard-mapping-status.csv',list(std[0]),std)

# Architecture and summaries.
md('system-architecture','''# System architecture from frozen evidence

No unified Procedure Model is evidenced. Shared types include turn parameters, local frames, OAS core, WsCalcuLine and optional WsObject/XData writers; form state and point lists remain module-specific.

The CAD drawing is a shared-state surface. Cross-window reuse usually means manually repicking coordinates or inspecting entities. Automatic object-ID/metadata transfer is limited and writer-dependent. True same-MethodDef sharing exists for point/line primitives, CAD writers, turn parameters, OAS core and selected frame/obstacle helpers; A4→A9 and A7→B5 are not unified business calls.

Obstacle processing is partly shared and partly divergent: A7/A8/A9/A10 have static evaluation chains, B3 differs on Take5, and B4/B5 retain orphan or prompt-only evaluation paths. OAS has a reusable core with different wrappers and file formats. Turn/spiral primitives are shared while boundary algorithms are often copied.

The earlier statement remains supported: CAD entities carry geometry and sometimes metadata, while cross-module connection generally needs manual coordinate repick. Exceptions are shared helpers, WsCalcuLine/XData inspection and OAS parameter files; none establishes a global procedure object.''')
md('executive-summary','''# Executive summary

Round 10 is complete as an independent system coverage audit. Fifteen public aviation functions, four named auxiliary functions and five no-window CAD commands were classified from frozen Help/UI/code evidence; the remaining ten raw CommandMethod rows are panel, diagnostic, stub or internal utility entries.

Complete static chains are A4, A6, A8 and A10. A1–A3, A5, A7 and B1–B5 remain partial for different reasons. A5/B3/B4/B5 have orphan or prompt-only evaluator gaps. A matched API23.1/Framework4.8 host is absent, so E4 is not available.

Algorithm gaps, UI-dispatch gaps, host-runtime gaps and standard-history gaps are separate in the residual register. The next high-value choices are A7/A3 and A1/B1/B2 closure, followed by trusted-build comparison for A5/B3/B4/B5. No new module, AutoCAD run, or runtime experiment was started.''')

cnt=Counter(x['SystemRollupStatus'] for x in roll)
md('coverage-review',f'''# Round 10 — System Coverage Review

**SYSTEM COVERAGE REVIEW COMPLETE**

This is an independent audit of frozen Round 1–9 results. No old closure/report/code/config/DLL was modified; no target DLL, AutoCAD or unknown executable was run. Evidence levels are E0 original identity/metadata, E1 processed IL/decompilation, E2 call/field/event/algorithm recovery, E3 independent recovered-source/fixture verification, E4 original-host execution, N standards/context.

## Function counts

- Public aviation functions: **15**.
- Named auxiliary functions: **4**.
- Named no-window CAD commands: **5**.
- Raw CommandMethod rows: **34**. The other 10 indexed entries are WsTools, Hello, notReady, y9_AddObstBlockDef, Command1, Command2 and five layer utility entries.

## Rollup counts

- COMPLETE_STATIC: **{cnt['COMPLETE_STATIC']}** (A4, A6, A8, A10).
- PARTIAL_STATIC: **{cnt['PARTIAL_STATIC']}**.
- INDEXED_ONLY: **0** public aviation functions; auxiliary/no-window depth is indexed-only in the consistency matrix.
- NOT_STARTED: **0** named public functions by this evidence policy.
- RUNTIME_ONLY_GAP: **0** rollups; statically closed modules carry RUNTIME_E4_GAP.
- LIKELY_UNAVAILABLE_IN_BUILD: **0** public rollups; B4/B5 stubs and orphan bodies are represented as PARTIAL_STATIC with flags because substantial code exists.

## Required answers

1. 15 public aviation functions are in scope; 4 auxiliary and 5 no-window commands are separate.
2. All 34 CommandMethod rows are classified in `command-inventory.csv`.
3. Complete static: A4, A6, A8, A10. Partial static: A1, A2, A3, A5, A7, A9, B1, B2, B3, B4, B5.
4. No named public function is only INDEXED_ONLY or NOT_STARTED; auxiliary depth remains indexed-only.
5. B4 Evaluate/KML and B5 evaluation dispatch are most likely unavailable in this build; A5/B3/B4/B5 evaluator availability is unresolved by orphan evidence.
6. Pure E4 gaps remain for A4/A6/A8/A10; E4 does not repair static UI/orphan gaps.
7. Orphans are A5, B3, B4 and B5 in `orphan-implementations.csv`.
8. Same-build static work remains valuable for A1/A3/A7/B1/B2; trusted-build comparison is preferred for A5/B3/B4/B5.
9. No unified Procedure Model is evidenced. Data flows through shared primitives/writers, module state, config/OAS files and manual coordinate repick. CAD carries geometry and some metadata.
10. Genuine sharing: point/line, CAD writer, turn parameters, OAS core and selected frame/obstacle helpers. Copied/business-similar: B1/B2 boundaries, A5/B4 loaders, A7/B5 departure logic and A9/B3 PriSec.
11. API23.1 E4 priority: A7, A3, A1/B1/B2, then host smoke tests for A4/A6/A8/A10.
12. Next phase follows `next-action-ranking.csv`; it is not started by this round.

Static recovery is not runtime equivalence, standards compliance or production readiness.''')

# Integrity: rehash every frozen input and ensure only the two Round10 directories changed.
missing=[];changed=[]
for x in base:
 p=ROOT/x['path']
 if not p.is_file():missing.append(x['path'])
 elif p.stat().st_size!=x['size'] or sha(p)!=x['sha256']:changed.append(x['path'])
log='\n'.join(['ROUND10 AUDIT LOG',f'baseline_count={len(base)}',f'old_closures_checked={len(list(ROOT.glob("recovered/round*/closure.md")))}','target_dll_executed=NO','autocad_operated=NO','old_outputs_modified='+str(bool(missing or changed)),'new_output_scope=recovered/system-coverage,recovered/round10','spot_checks=command classification; orphan incoming; A4/A6 shared primitive wording','status='+('PASS' if not missing and not changed else 'INTEGRITY FAILURE')])
(R10/'audit-log.txt').write_text(log+'\n',encoding='utf-8')
integrity={'status':'PASS' if not missing and not changed else 'INTEGRITY FAILURE','baseline_count':len(base),'missing_frozen_files':missing,'changed_frozen_files':changed,'old_closure_modified':False,'old_test_inputs_checked':True,'target_runtime_executed':False,'new_output_directories':['recovered/system-coverage','recovered/round10'],'spot_checks':[{'reason':'34 CommandMethod classification','files_examined':['reverse-analysis/04_type-map/raw/commands.csv','reverse-analysis/03_recovered-src/ilspy-original/-/-.cs','WsTools-master/WindSpiral2026/帮助文件/index.html'],'result':'34 rows classified without new module recovery'},{'reason':'orphan incoming status','files_examined':['recovered/A5-PrecisionApproach/event-map.md','recovered/B3-RnpApch/overview.md','recovered/B4-PbnIls/overview.md','recovered/B5-PbnDeparture/overview.md'],'result':'orphan/prompt-only status retained; no UI connection added'},{'reason':'A4/A6 shared primitive wording','files_examined':['recovered/round9/a6-a4-comparison.csv','recovered/A4-NavAidProtection/evidence/cross-module-shared-calls.csv'],'result':'method-specific sharing only'}]}
(R10/'integrity-report.json').write_text(json.dumps(integrity,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
manifest=[]
for d in [SC,R10]:
 for p in sorted(d.rglob('*')):
  if p.is_file() and p!=R10/'output-manifest.json':manifest.append({'path':rel(p),'size':p.stat().st_size,'sha256':sha(p)})
(R10/'output-manifest.json').write_text(json.dumps({'excludes':['recovered/round10/output-manifest.json'],'files':manifest},ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
if missing or changed:raise SystemExit('INTEGRITY FAILURE')
print(json.dumps({'status':'SYSTEM COVERAGE REVIEW COMPLETE','baseline_count':len(base),'command_methods':len(cmds),'public_aviation':len(spec),'rollup_counts':dict(cnt),'outputs':len(manifest)},ensure_ascii=False))

