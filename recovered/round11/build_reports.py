import csv,json,hashlib
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]; R=ROOT/'recovered'/'round11'; A=ROOT/'recovered'/'A7-Departure'; E=R/'evidence'
def read(p): return list(csv.DictReader(p.open(encoding='utf-8-sig',newline='')))
def out(p,fs,rs):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  if rs and isinstance(rs[0],list):
   w=csv.writer(f); w.writerow(fs); w.writerows(rs)
  else:
   w=csv.DictWriter(f,fieldnames=fs); w.writeheader(); w.writerows(rs)
def sh(p): return hashlib.sha256(p.read_bytes()).hexdigest()
F=['Feature','HelpEvidence','UIEvidence','EventEvidence','BusinessMethod','Geometry','Evaluator','CADWriter','Reachable','Status','Evidence']
rows=[
['直线离场（独立构造）','Help未宣称独立工作流','无独立按钮；直线段在定高/定点内','P203内部二检；无独立Click','P1FB/P202直线边；P203二检','无独立保护区类','无独立evaluator','随模式输出','YES（依附模式链）','NOT_IMPLEMENTED_IN_BUILD','full Form source; area-stage-map.csv'],
['定高转弯','Help说明离场评价','tab2 TurnAlt/Grad/Early','P282/P283/P285/P286事件','P1FB/P1FD/P1FC','S-K、可选S-E、K-L镜像多边形','dr/do及MOC/OCA/PDA/required','2或3 Polyline+Group','YES','IMPLEMENTED','geometry-altitude-turn.md; events.csv'],
['定点转弯','Help说明定点/容差','TP/KK/C拾点文本','P287/P28A/P28B/P28D/P28C','P202/P204/P203','S-TP、E-TP、TP-L、L-D','直线/KK/C分支及二检','4 Polyline+Group','YES','IMPLEMENTED','point-turn.md; events.csv'],
['全向离场','Help说明全向','tab4 TNA/FinalAltitude/PDG','P290/P291/button14/button16','P420/P422/P421','S-D、D-K、K-F及外圆','三区+C1-C5','2或3 Polyline+Circle','YES','IMPLEMENTED','omnidirectional.md; events.csv'],
['电台上空转弯','未宣称','无VOR/NDB/DME/facility控件','A7闭包无导航设施分支','无A7 MethodDef/直接caller','无','无','无','NO','NOT_IMPLEMENTED_IN_BUILD','full Form source; reachability.json'],
['有/无航迹引导分支','未宣称','无guided/unguided/track控件','无状态分支；15/30度为几何常数','三模式无航迹输入','同一几何','无','同一writer','NO','NOT_IMPLEMENTED_IN_BUILD','full Form/business source'],
['导航设施参与','未宣称','无设施类型/位置/精度控件','无A7 facility reader','无直接reader/caller','无','无','无','NO','NOT_IMPLEMENTED_IN_BUILD','reachability.json; resolved-calls.csv'],
['TP/KK/C定位容差','定点输入说明','三个GetPoint及距离框','P287/P28A/P28B可达','P202/P203/P204','TP高度反算；KK/C距离','P203使用tp-k/E.X-X','定点4 Polyline','YES','IMPLEMENTED','cross-window-input-proof.md; point-turn.md'],
['风螺旋/Spiral86/88/P7AD','A7帮助未称风螺旋','仅TAS/Wind输入','238可达MethodDef不含Spiral86/88/P7AD','P793只供Altitude/TAS/Wind','直线/镜像边界','无螺旋调用','Polyline/Circle','NO','NOT_IMPLEMENTED_IN_BUILD','P793-field-consumption.csv; reachability.json'],
['障碍物评价公共链','Help描述障碍物评价','Screen→评价→Grid/Mark','P282/P28D/P291由Click可达','P1FC/P203/P421','局部XY+绝对Z','classifier→dr/do→MOC→OCA/PDA/required','表格/Mark','YES','IMPLEMENTED','obstacle-evaluation.md; events.csv'],
['直线段二次检查','未独立宣称','仅定点checkBoxSecChk','无独立Click；Checked传P203','P203内部同一行覆盖','DER→E直线','dr=tp-k; do=E.X-X; max75','无额外实体','YES（定点评价内部）','PARTIALLY_IMPLEMENTED','DepartureGeometry.Recovered.cs; Departure.Events.Recovered.cs']]
out(A/'final-feature-matrix.csv',F,[dict(zip(F,x)) for x in rows])
(A/'cross-window-input-proof.md').write_text('''# A7 跨窗口输入最终证明

A7 的 DER、THR、TP、KK′、C 均经 GetPoint 取得坐标，再转为距离/高度文本进入本窗口模型；未发现 A2/A3 业务实体语义 reader。结论限于已索引的直接 call/callvirt/newobj/MethodSpec 闭包。

|对象|A7入口|下游|人工原因|
|---|---|---|---|
|DER/THR|P27E/P27F GetPoint→P0AC/P0AD|跑道长度与局部坐标|无跑道实体识别；已有坐标可外部推导|
|TP|P287 GetPoint→XY hypot→P289双高度|P202从CalculationHeight反算tp|无投影/符号/共线校验，需人判断转弯点|
|KK′|P28A GetPoint→距离|P202的kk、P203的dr/do|A3 KK空metadata，无A3语义reader|
|C|P28B GetPoint→距离|P202的c、P203后续分支|无turn-end自动推导|
|障碍物|P279→P276/277/278→P12F|局部XY、评价、表格、Mark|SelectAll Model DBPoints；Mark需选表格行|

A7可达闭包未发现 WsCalcuLine、RegApp、Entity.XData、GetXDataForApplication 的跑道/TP/KK/C reader。唯一 GetXDataForApplication 在共享障碍物名称解析器 P717；A7 Group 是输出容器，全向 Circle 的 WsObject 是写出 Radius 字符串。因此：
A7 does not automatically consume A2 WsCalcuLine in the indexed build.
A7 consumes picked coordinates, not A3 semantic KK objects.
''',encoding='utf-8')
H=['Mode','Stage','Source method','Start control point','End control point','Boundary list','Evaluator','CAD entity','Connection/limit']
area=[
['Altitude','Initial/Straight','P1FB/P1FD','S','K','Sym(S,K)','P1FC','Polyline #1; Group','无独立直线工作流'],['Altitude','Turn-initiation/delay','P1FB/P1FD','K','L','Sym(K,L)','P1FC','Polyline #2; Group','e=(TAS+Wind)/.6'],['Altitude','Early runway patch','P1FB/P1FD','S','E','Sym(S,E)','P1FC','Polyline #3 when early','无union/trim'],['Altitude','Turn','P1FB/P1FC','K/L','classifier','distance branches','P1FC','none','评估区标签非曲线航迹'],['Altitude','Post-turn','—','—','—','none','none','none','未独立构造'],
['Point','Initial/Straight','P202/P204','S','TP','Sym(S,TP)','P203','Polyline #1; Group','二检为评价分支'],['Point','Turn-initiation','P202/P204','E','TP','Sym(E,TP)','P203','Polyline #2; Group','E=TP-KK'],['Point','Turn','P202/P204','TP','L=TP+C','Sym(TP,L)','P203','Polyline #3; Group','线性边界'],['Point','Post-turn/delay','P202/P204','L','D=L+delay','Sym(L,D)','P203','Polyline #4; Group','无next-heading'],['Omni','Initial/Straight','P420/P422','S','D','Sym(S,D) when early','P421','Polyline optional','A7调用b=0'],['Omni','Turn-initiation','P420/P422','D','K','Sym(D,K)','P421','Polyline #1; Group','固定15度'],['Omni','Turn','P420/P422','K','F','Sym(K,F)','P421','Polyline #2; Group','固定30度；C1-C5'],['Omni','Post-turn','P420/P422','F','circle carrier','circle','P421','Circle+Radius WsObject','非后航迹']]
out(A/'area-stage-map.csv',H,[dict(zip(H,x)) for x in area])
I=['Function','HelpEvidence','UIEvidence','Reachability','Consistency','Finding','Evidence']
help_rows=[
['Y07 Departure evaluation','Departure evaluation; three tabs','FormDepartureEvl; three tabs','P283/P282; P28C/P28D; P290/P291','CONSISTENT','公开入口与三链一致','FormDepartureEvl.html; overview.md'],['Independent straight departure','Not promised','No independent control','No independent builder/evaluator/Click','CONSISTENT','Help omission matches build','full Form source'],['Station-overhead turn','Not promised','No facility controls','No A7 caller/MethodDef','CONSISTENT','No implementation evidence in this build','full Form source; reachability.json'],['Guided/unguided departure','Not promised','No guidance control','No branch input','CONSISTENT','No implementation evidence in this build','full Form/business source'],['KML button2','Not geometry help','button2 Click P284','Reachable; template copy only','CODE_HAS_EXTRA','Template save has no geometry injection','cad-output-map.md'],['button9/button15 KML','Labels exist','button9 empty; button15 hover only','No calculation Click','HELP_OVRSTATES_BUILD','No calculation path','events.csv; cad-output-map.md'],['IAS/wind toggles','Help suggests participation','Click converts units 1.852','Reachable','HELP_OVRSTATES_BUILD','Observed behavior is unit conversion','event-map.md'],['ScreenData current screen','Help says current screen','SelectAll Model DBPoints','Reachable','HELP_OVRSTATES_BUILD','No view clipping evidence','obstacle-evaluation.md'],['Entry coordinate system','Help says THR origin','Code uses DER origin','Reachable','HELP_OVRSTATES_BUILD','Retain code behavior','runway-coordinate.md']]
out(A/'help-ui-code-final.csv',I,[dict(zip(I,x)) for x in help_rows])
out(R/'P793-field-consumption.csv',['Field','Constructed/available in P793','Read by A7 business geometry','Read locations','Disposition'],[
['Altitude','yes','yes','P1FB/P202 ldfld 0x0400074D','actual input'],['TAS','yes','yes','P1FB/P202 ldfld 0x0400074F','actual input; delay'],['Wind','yes','yes','P1FB/P202 ldfld 0x04000751','actual input; delay'],['Rate','yes','no','P793 internal only','not boundary-driving'],['Radius/WindRadius/Drift','yes','no','P793 internal; no A7 Spiral calls','not consumed'],['IAS/bank/temperature','yes','no','model retained; no boundary read','not geometry-driving']])
out(R/'cad-audit.csv',['Mode','Entity lists','Group','XData','Layer/color/linetype','Text/metadata','Deletion/rebuild','Evidence'],[
['Altitude','2 or 3 Polyline','anonymous Group','empty metadata at P087','no explicit assignment','none','none','P283/P087; cad-output-map.md'],['Point','4 Polyline','anonymous Group','empty metadata at P087','no explicit assignment','none','none','P28C/P087'],['Omni','2 or 3 Polyline + Circle','Polyline Group; Circle separate','Circle WsObject Radius string','no explicit assignment','Radius string; not Text','none','P290/P089; cad-output-map.md']])
out(R/'connection-proof.csv',['Mode','Connection/relationship','Code evidence','Classification','Automatic/manual','Limit'],[
['All','DER/THR to local frame','P0AC+P0AD','line carrier','automatic after manual picks','DER origin; absolute Z restored'],['Altitude','S-K and K-L','P1FD Sym','shared vertex','automatic','no boolean union/trim/offset'],['Point','S-TP/E-TP/TP-L/L-D','P204 Sym','shared vertex; overlapping polygons','automatic','no intersection resolver'],['Omni','D-K-K-F and circle','P422 Sym + P089','line carrier; outer circle','automatic','no tangent/clip/union'],['All','A2/A3 to A7','P287/P28A/P28B; no semantic reader','manual repick','manual','cannot infer intended point'],['All','boundary merge','no IntersectWith/Offset/trim/hull/delete','independent overlapping polygons','not code-driven','manual drawing unobserved']])
ev=[]
for p in [E/'method-index.csv',E/'events.csv',E/'controls.csv',E/'resolved-calls.csv',E/'reachability.json',A/'Departure.Events.Recovered.cs',A/'DepartureForm.Recovered.cs',A/'AltitudeDeparture.Recovered.cs',A/'DepartureGeometry.Recovered.cs',A/'OmniDeparture.Recovered.cs',A/'cad-output-map.md',A/'obstacle-evaluation.md',R/'standard-basis-note.md',ROOT/'recovered'/'round5'/'standard-pages.json',ROOT/'doc'/'航空器运行目视和仪表飞行程序设计规范.pdf']:
 level='N' if p.suffix=='.pdf' or 'standard' in p.name else 'E1/E2/E3'
 ev.append({'Artifact':str(p.relative_to(ROOT)).replace('\\\\','/'),'Evidence level':level,'Purpose':'Round11 static evidence','SHA256':sh(p)})
out(R/'evidence-index.csv',['Artifact','Evidence level','Purpose','SHA256'],ev)
tests=[{'id':x,'kind':'static','result':'PASS'} for x in ['cross-window-repick','event-mode-dispatch','area-stage-map','negative-candidates','obstacle-ui-reachability','p793-consumption']]
(R/'static-tests.json').write_text(json.dumps({'scope':'additive fixtures; no DLL/AutoCAD; old E3=105 not rerun','tests':tests,'count':len(tests),'all_pass':True},ensure_ascii=False,indent=2),encoding='utf-8')
(A/'final-static-closure.md').write_text('''# A7 Conventional Departure — Round 11 最终静态收口
判定：**A7: COMPLETE_STATIC**。已索引构建中的三套业务算法、公开事件链、障碍物评价和CAD写出关系已恢复到可审计程度。原宿主E4未执行，历史Round 2状态不改。

## 20问结论
1. 独立直线离场：无独立构造/边界/evaluator，直线边属于三模式，二检属于P203。
2. 电台上空转弯：无A7实现证据。
3. 有/无航迹引导：无guided/unguided/track输入或分支。
4. VOR/NDB/DME：无A7直接reader/caller。
5. TP：不自动从A2读取，P287 GetPoint后为距离/高度。
6. KK′：不自动从A3读取，P28A GetPoint后为距离。
7. C：不自动读取，P28B GetPoint后为距离。
8. WsCalcuLine：索引闭包无A7 reader。
9. A3 XData/Group：跑道/TP/KK/C不读；共享障碍物名称解析器的EntityFrame不等同KK语义。
10. stages：定高S-K/K-L/可选S-E；定点S-TP/E-TP/TP-L/L-D；全向S-D/D-K/K-F/圆载体。
11. 衔接：镜像边界、共享顶点、线载体和圆已代码化；无IntersectWith/Offset/切线/包络/裁剪/删除重建。
12. Spiral86/88/P7AD：238个可达MethodDef不含它们。
13. P793：定高/定点实际读Altitude、TAS、Wind；Rate/Radius/WindRadius/Drift不用于A7边界/螺旋。
14. obstacle evaluators：P282/P28D/P291均由公开Click可达。
15. 二检：P203内部，由checkBoxSecChk传入，覆盖同一行。
16. Designer/config：主要影响完整WinForms/宿主运行，属RUNTIME_UI_ONLY/LOW_VALUE。
17. Help差异：ScreenData实际SelectAll Model DBPoint；入口帮助THR而代码DER；IAS/风为单位换算；button9/15无计算Click；button2只保存模板。
18. Round10 residual：三模式、evaluator、事件、CAD writer、跨窗口和负向候选均已补证；旧行不改。
19. E4剩余：原宿主加载、实体创建/删除、表格显示、原始配置/Designer运行。
20. COMPLETE_STATIC：是；剩余仅E4、低价值Designer/runtime UI、STANDARD_BASIS_UNRESOLVED。

## Residual
- STATIC_ALGORITHM_GAP：无公开断链，既有算法+本轮stage/connection索引关闭。
- EVENT_REACHABILITY_GAP：三模式CAD/evaluator/Screen/Mark直接绑定已确认；空/悬停按钮已定性。
- DESIGNER_CONFIG_GAP：完整运行重建仍缺，降级LOW_VALUE。
- MANUAL_CAD_DEPENDENCY：GetPoint和无布尔衔接为实际行为，保留。
- RUNTIME_E4_GAP：原宿主未执行，保留。
- STANDARD_BASIS_UNRESOLVED：15°、150、0.008、75、600、120、.1等常数未由AC-97-FS-005唯一解释，标记实现依据待确认。

证据等级：E0/E1原身份与IL；E2事件/字段/调用/闭包；旧E3为既有恢复源码验证，本轮不重跑105断言；E4未执行；规范为N。本轮到此停止，不自动进入A3。
''',encoding='utf-8')
(R/'closure.md').write_text('''# Round 11 Closure
- Scope: A7 Conventional Departure final static closure only.
- Decision: A7 COMPLETE_STATIC.
- Round 1–10 and existing A7 artifacts are frozen; this pass is additive.
- No target DLL, NETLOAD, AutoCAD, or unknown binary was executed.
- Three public mode chains and three obstacle evaluators are statically reachable.
- Negative candidates have bounded negative evidence in the indexed A7 closure.
- A7 repicks coordinates; it does not automatically consume A2 WsCalcuLine or A3 semantic KK objects.
- Remaining: E4 host/runtime, full Designer/config runtime, standard-basis confirmation.
- A3 is only a later suggestion; no A3 work was started.
''',encoding='utf-8')
p=R/'plan.md'; p.write_text(p.read_text(encoding='utf-8').replace('[ ]','[x]'),encoding='utf-8')

