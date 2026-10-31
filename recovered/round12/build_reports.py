import csv,json,hashlib
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]; R=ROOT/'recovered'/'round12'; A=ROOT/'recovered'/'A3-FixTolerance'; E=A/'evidence'
def out(p,fs,data):
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  if data and isinstance(data[0],list):
   w=csv.writer(f); w.writerow(fs); w.writerows(data)
  else:
   w=csv.DictWriter(f,fieldnames=fs); w.writeheader(); w.writerows(data)
def sh(p): return hashlib.sha256(p.read_bytes()).hexdigest()
F=['Feature','HelpEvidence','UIEvidence','Event','BusinessMethod','Geometry','CADWriter','Reachable','Status','Evidence']
rows=[
['Cross-fix / 单台单方向容差','Help称两个方位/距离交叉','交叉定位页；导航台+引导方向两次拾点','button1 Click→P20E','P20E读取S/Q、r、AccuracyDegrees','单台扇形楔形；可选Track/KK','Polyline Group；可选Line','YES','IMPLEMENTED','geometry-chain.md; 0x0600020E.il.txt'],
['DME定位容差','Help支持DME距离/指定距离','DME、指定距离、DistanceNm、Suffix','P20E DME branch','r=NM×1852或拾点平面距；e=.0125r+460','late/nominal/early三弧','3 Arc独立Group+DBText','YES','IMPLEMENTED','dme-final.md; cad-output-map.md'],
['KK早晚边界','Help有kk线选项','checkBoxkk','P20E KK branch','P20E生成late/early两条Line','中心r+e与(r-e)cos(a)，横向±9260','2 Line；不入Polyline Group','YES','IMPLEMENTED','kk-final.md; geometry-chain.md'],
['Overhead / 顶空盲区','Help说明顶空盲区','VOR/NDB、Height、HalfAngle','button2 Click→P211','P211 R=h·tan(halfAngle)','Circle；可选两条航迹容差Polyline','Circle+Polyline Group','YES','IMPLEMENTED','FixToleranceForm.Events.Recovered.cs'],
['Track guidance auxiliary','Help称航迹线/航迹容差','checkBoxTrack、checkBox2','P20E/P211 optional','P20E S→late；P211按VOR/NDB小大角生成两线','参考中心线/盲区辅助边，非完整导航模型','Polyline Group','YES','PARTIALLY_IMPLEMENTED','track-guidance.md'],
['Facility accuracy dispatch','Help宣称设备精度影响容差','VOR/ILS/NDB、Guide','P209/P20A/P20B/P20C','5.2/4.5、2.4/1.4、6.9/6.2','AccuracyDegrees进入楔形、KK、DME弧角','间接影响Polyline/Line/Arc','YES','IMPLEMENTED','facility-matrix.csv'],
['VOR/DME composition','Help列VOR/DME','VOR radio + DME checkbox','P20E组合分支','VOR精度角+DME误差三弧','同一P20E输出','Arc+Polyline Group；DBText','YES','IMPLEMENTED','facility-matrix.csv; dme-final.md'],
['NDB/DME composition','Help列NDB/DME','NDB radio + DME checkbox','P20E组合分支','NDB精度角+DME误差三弧','同一P20E输出','Arc+Polyline Group；DBText','YES','IMPLEMENTED','facility-matrix.csv; dme-final.md'],
['Automatic two-facility cross-fix','Help暗示两个方位/距离','无第二设施或bearing2控件','P20E只有两次GetPoint：S/Q','无线线求交/IntersectWith','无自动交会点','无专用writer','NO','NOT_IMPLEMENTED_IN_BUILD','downstream-consumption.md; spot-checks.md'],
['LOC/TACAN/GNSS','Help未宣称','无对应UI option','无A3 MethodDef/直接caller','无分支','无','无','NO','NOT_IMPLEMENTED_IN_BUILD','facility-matrix.csv'],
['Full procedure protection area','Help称定位容差','无保护区evaluator/主副区控件','无保护区直接链','仅容差图元','非完整程序保护区引擎','仅CAD追加','NO','NOT_IMPLEMENTED_IN_BUILD','final-static-closure.md'],
['Semantic downstream reuse','Help未承诺','无语义导入控件','无A3语义下游reader证据','Group/XData不形成业务对象','仅图元容差结果','empty/neutral XData','NO','NOT_IMPLEMENTED_IN_BUILD','downstream-consumption.md']]
out(A/'final-feature-matrix.csv',F,[dict(zip(F,x)) for x in rows])
out(A/'facility-matrix.csv',['Facility','UI option','Default accuracy','Geometry branch','Dedicated MethodDef','Downstream use','Status','Evidence'],[
['VOR','radioButtonVOR','Guide=true 5.2°, false 4.5°','AccuracyDegrees→single-station wedge/KK/DME arc','P209/P20C; no dedicated solver','P20E','IMPLEMENTED','FixTolerance.Recovered.cs; events.csv'],
['NDB','radioButtonNDB','Guide=true 6.9°, false 6.2°','AccuracyDegrees→single-station wedge/KK/DME arc','P20B/P212','P20E','IMPLEMENTED','FixTolerance.Recovered.cs; event-binding-final.md'],
['ILS','radioButtonILS','Guide=true 2.4°, false 1.4°','AccuracyDegrees→same geometry','P20A','P20E','IMPLEMENTED','FixTolerance.Recovered.cs'],
['DME','checkBoxDme; specified distance','display r from picked distance; no angle default','r/early/nominal/late arcs','branch in P20E; no dedicated class','Arc Group+DBText','IMPLEMENTED','dme-final.md'],
['VOR/DME','VOR radio + DME checkbox','VOR accuracy + DME error','composed P20E branch','none','3 arcs/text+wedge','IMPLEMENTED','facility-matrix.csv'],
['NDB/DME','NDB radio + DME checkbox','NDB accuracy + DME error','composed P20E branch','none','3 arcs/text+wedge','IMPLEMENTED','facility-matrix.csv'],
['LOC','none','none','none','none','none','NOT_IMPLEMENTED_IN_BUILD','controls/events/methods search'],
['TACAN','none','none','none','none','none','NOT_IMPLEMENTED_IN_BUILD','controls/events/methods search'],
['GNSS','none','none','none','none','none','NOT_IMPLEMENTED_IN_BUILD','controls/events/methods search']])
out(A/'angle-semantics.csv',['AngleValue','Facility','SourceControl','Method','ActualUse','BusinessMeaning','Evidence'],[
['5.2° / 4.5°','VOR','Guide/VOR events','P20C/P209','AccuracyDegrees in wedge/KK/arcs','facility accuracy, not overhead cone','FixTolerance.Recovered.cs'],
['6.9° / 6.2°','NDB','Guide/NDB events','P20B/P212','AccuracyDegrees in wedge/KK/arcs','facility accuracy, not overhead cone','FixTolerance.Recovered.cs'],
['2.4° / 1.4°','ILS','Guide/ILS events','P20A','AccuracyDegrees in same geometry','ILS accuracy branch','FixTolerance.Recovered.cs'],
['40°','NDB','radioButtonN and textBox2 Leave','P212','HalfAngle for overhead radius','overhead cone half-angle; anomalous suffix binding','events.csv; event-binding-final.md'],
['50°','VOR','radioButtonV CheckedChanged','P213','HalfAngle for overhead radius','overhead cone half-angle','FixToleranceForm.Events.Recovered.cs'],
['5° / 15°','VOR','BlindTrack branch','P211','two blind-track endpoint angles','overhead auxiliary geometry','geometry-chain.md'],
['15° / 25°','NDB','BlindTrack branch','P211','two blind-track endpoint angles','overhead auxiliary geometry','geometry-chain.md'],
['a=AccuracyDegrees','VOR/NDB/ILS','textBoxAng','P20E','theta±a','selected facility accuracy geometry','0x0600020E.il.txt'],
['7.8° / 10.3°','VOR/NDB','AC-97 comparison only','A4 protection code/docs','not read by A3','protection divergence, different business','A4 standard-search.json'],
['DME error not angle','DME','none','P20E','e=.0125r+460 m','range error, not angle','dme-final.md']])
(A/'dme-final.md').write_text('''# A3 DME 误差与三弧

P20E 计算 e = 0.0125*r + 460，单位米。指定距离时 r=DistanceNm×1852；未指定时 r 是两次拾点的平面距离，DistanceNm 只以 Round(r/1852,1) 回填显示，几何使用未四舍五入 r。数字失败进入 Validate 后返回。

三弧共用圆心 S 和角范围 theta-angle 至 theta+angle：late 半径 r+e；nominal 半径 r；early 半径 r-e。三条 Arc 追加到独立 Group。随后追加 DBText：D+距离文本+大写设施后缀，Height=500。未指定距离时文字位置为 Q，保留 Q.Z；指定距离时位置为 nominal XY 点，Z=0。Arc 使用原始 S，保留 S.Z。未选 DME 时在弧和文字前返回，但 e、楔形和 KK 已可能执行。

这是定位容差弧链，不是 A10 DME 弧或完整程序保护区。
''',encoding='utf-8')
(A/'kk-final.md').write_text('''# A3 KK 早晚边界

r 是站点 S 到方向点 Q 的平面距离，或指定距离 NM×1852；e=.0125r+460 是同一 P20E 中的误差公式，不依赖 DME 绘图开关。选中 KK 后先生成两条独立 Line：late 中心 P(r+e,theta)，early 中心 P((r-e)cos(a),theta)；两条线沿 theta±pi/2 延伸 9260 m，长度18520，Z=0。

9260 是每条横向 Line 的半长/端点延伸量，不是第二台站距离或交会求解结果。KK 不写文字、不进入楔形/Track Group，是定位容差早晚边界辅助图元，不是完整程序保护面。
''',encoding='utf-8')
(A/'track-guidance.md').write_text('''# A3 Track guidance 静态定性

普通定位容差 checkBoxTrack 只追加 S→P(r+e,theta) 两点 Polyline，与楔形共用 Polyline Group，是参考/载体线；没有第二台站、线线求交、偏航动态或完整导航引导模型。

顶空盲区 checkBox2/BlindTrack 是另一条辅助链：再拾取入航方向，P211 按 VOR 5/15 或 NDB 15/25 度生成两条端点连线，再与 Circle 分开输出。它不是普通 Track 的同一几何，也不是保护区包络。
''',encoding='utf-8')
(A/'downstream-consumption.md').write_text('''# A3 下游消费与双台交叉定位

P20E 公开 Click 只调用两次 GetPoint：第一次导航台 S，第二次引导方向 Q。第二点不是第二设施；Form 没有 station2、second station、bearing2、radial2 控件，A3 calls/IL 未发现 IntersectWith 或两条独立径向求交。

结论：A3 does not implement an automatic two-facility cross-fix solution in this build.

A7 Round 11 已证明重新 GetPoint、不读A3 semantic KK/WsCalcuLine。A6 没有A3 Form/MethodDef direct caller；相同VOR/NDB字符串不构成复用。A10有自己的DME弧业务类/事件，未发现A3入口；A4仅共享低层Point/角度/CAD primitive，Round 9 已区分为不同业务。上述均限定已索引的直接调用图，不排除反射或宿主外部行为。

A3 writer 只经共享 empty/neutral helper；没有足够的 WsObject/WsCalcuLine/WsEntityFrame 语义载荷，不能自动形成下游业务对象。
''',encoding='utf-8')
(A/'event-binding-final.md').write_text('''# A3 异常事件绑定

Designer/事件索引显示：textBox2（旧DME后缀框）Leave→P212；radioButtonN CheckedChanged→同一P212。P212 在NDB选中时写 HalfAngle=40并切换VOR/NDB图像。因此离开DME后缀框可能重置顶空半角。它不是HalfAngle控件的Leave，属于真实旧绑定，本轮不修。

VOR选择写50；DME/Suffix/指定距离事件只控制启用状态。盲区数字转换失败后Validate并直接返回，原代码不恢复Visible；Origin取消路径恢复Visible。这些异常均保留。
''',encoding='utf-8')
out(A/'cad-output-final.csv',['Feature','EntityType','Count','Group','Z handling','Layer','Color','Text','XData','Metadata'],[
['KK early/late','Line','2','none','Z=0','not explicit','not explicit','none','empty/neutral','no WsObject/WsCalcuLine/WsEntityFrame'],
['Wedge tolerance','Polyline','1','Polyline Group','Z=0','not explicit','not explicit','none','empty/neutral','no semantic schema'],
['Track guidance','Polyline','0 or 1','same Group','Z=0','not explicit','not explicit','none','empty/neutral','reference line'],
['DME arcs','Arc','3 when DME checked','separate Group','center S retains S.Z','not explicit','not explicit','none','empty/neutral','r+e/r/r-e'],
['DME distance label','DBText','1 when DME checked','none','Q.Z unspecified; 0 specified','not explicit','not explicit','D...; Height500','empty/neutral','suffix uppercase'],
['Blind-track tolerance','Polyline','0 or 2','separate Group','Z=0','not explicit','not explicit','none','empty/neutral','VOR/NDB endpoint angles'],
['Blind-zone circle','Circle','1 when h>0 and no inbound cancel','none','center S retains S.Z','not explicit','not explicit','none','empty/neutral','h*tan(halfAngle)']])
out(A/'help-ui-code-final.csv',['Function','HelpEvidence','UIEvidence','CodeEvidence','Consistency','Finding','Evidence'],[
['Cross fix','Help says two bearings/distances','one station + direction point','P20E two GetPoint; no second facility','HELP_OVRSTATES_BUILD','Help overstates automatic cross-fix','FixTolerance.html; downstream-consumption.md'],
['DME','Help says DME/specified distance','DME/Distance/Suffix controls','r/1852, .0125r+460, three Arc','CONSISTENT','DME branch exists','dme-final.md'],
['KK','Help lists KK line','checkBoxkk','two transverse Lines, 9260 half-length','CONSISTENT','tolerance helper geometry','kk-final.md'],
['Overhead','Help describes blind zone','VOR/NDB, Height, HalfAngle','Circle plus optional lines','CONSISTENT','formula and cancellation recovered','geometry-chain.md'],
['Track guidance','Help lists track line/tolerance','checkBoxTrack/checkBox2','reference or blind-track lines','CONSISTENT','drawing aid, not full model','track-guidance.md'],
['Facility types','Help mentions VOR/NDB/DME','VOR/ILS/NDB plus DME checkbox','no LOC/TACAN/GNSS','HELP_OVRSTATES_BUILD','unsupported types absent','facility-matrix.csv']])
(A/'final-static-closure.md').write_text('''# A3 Fix Tolerance — Round 12 最终静态收口

判定：**A3: COMPLETE_STATIC**。设施精度、单台容差、DME三弧、KK早晚线、顶空盲区、Track辅助、CAD实体、metadata和异常事件均有静态证据。Round 1 PARTIAL历史状态不改；本轮不补双台交叉定位。

## 20问
1. 双台交叉定位？没有；只有S和方向点Q。
2. 设施？VOR、ILS、NDB；DME为距离/弧线分支；无LOC/TACAN/GNSS。
3. 角度？5.2/4.5、6.9/6.2、2.4/1.4为设施精度角；40/50为顶空半角；5/15、15/25为盲区辅助角；7.8/10.3为A4保护发散比较。
4. DME公式？e=.0125r+460m；指定NM×1852；未指定为拾点平面距。
5. 三弧？late r+e、nominal r、early r-e，同一S和theta±a。
6. KK early/nominal/late？只有late横线和early投影横线；无独立nominal KK线。
7. 9260？横向Line半长，非第二台站距离。
8. A7读KK？不读，重新拾点。
9. A6读A3？无直接reader/caller证据。
10. A10复用DME？不复用，A10自建DME弧。
11. Overhead？R=h*tan(HalfAngle)，圆心为拾取台站。
12. VOR/NDB overhead？代码写50/40，绘图读取当前文本框。
13. Track？普通链是S→late参考线；盲区链是按设施角的两条辅助线。
14. A3性质？定位容差/顶空图元工具，不是完整程序保护区引擎。
15. 实体？2 Line、1楔形Polyline、可选Track、3 Arc+DBText、可选2盲区Polyline+Circle。
16. metadata？empty/neutral helper；无WsObject/WsCalcuLine/WsEntityFrame语义载荷。
17. 异常绑定？textBox2 Leave与NDB CheckedChanged共用P212，真实保留。
18. Designer/config？只影响完整WinForms/宿主运行，参与业务控件事件已确定，属LOW_VALUE/RUNTIME_UI_ONLY。
19. Help高估cross-fix？是；两个方位/距离描述与单台单方向实现不一致。
20. COMPLETE_STATIC？是；剩余E4、host/Designer和规范依据，不是静态算法/事件断链。

## Residual
STATIC_ALGORITHM_GAP无已实现链断裂；双台交叉定位为NOT_IMPLEMENTED_IN_BUILD。EVENT_REACHABILITY_GAP已关闭并记录异常绑定。Designer/config降级RUNTIME_UI_ONLY/LOW_VALUE。GetPoint和无对象语义关联保留为MANUAL_CAD_DEPENDENCY。E4未执行。精度角、40/50、.0125r+460、9260标记STANDARD_BASIS_UNRESOLVED。

证据等级：E0/E1身份与IL；E2事件/字段/调用；旧E3不重跑；E4禁止；规范为N。''',encoding='utf-8')

ev=[]
paths=[E/'events.csv',E/'controls.csv',E/'calls.csv',E/'methods.json',E/'0x0600020E.il.txt',E/'0x06000211.il.txt',A/'FixTolerance.Recovered.cs',A/'FixToleranceForm.Events.Recovered.cs',A/'geometry-chain.md',A/'cad-output-map.md',A/'tolerance-table.md',ROOT/'WsTools-master'/'WindSpiral2026'/'帮助文件'/'FixTolerance.html',ROOT/'recovered'/'A7-Departure'/'cross-window-input-proof.md',ROOT/'recovered'/'A6-Template'/'overview.md',ROOT/'recovered'/'A10-DmeArc'/'overview.md',ROOT/'recovered'/'A4-NavAidProtection'/'overview.md']
for p in paths:
 if p.exists(): ev.append({'Artifact':p.relative_to(ROOT).as_posix(),'Evidence level':'E1/E2/E3' if p.suffix in ['.csv','.json','.il','.cs'] else 'E2/N','Purpose':'Round12 A3 static evidence','SHA256':sh(p)})
out(R/'evidence-index.csv',['Artifact','Evidence level','Purpose','SHA256'],ev)
(R/'spot-checks.md').write_text('''# Round 12 有限 spot-check

|reason|methods/files examined|result|
|---|---|---|
|双台交叉定位|A3 events、P20E IL、Form controls|两次GetPoint是S/Q，无station2、bearing2、IntersectWith|
|DME公式三弧|P20E IL、geometry-chain、dme-final|1852、.0125r+460、r+e/r/r-e、theta±a、Arc Group顺序确认|
|KK|P20E IL、kk-final、cad-output-map|两Line、early cos(a)、±9260、Z0确认|
|Track|P20E/P211 IL、track-guidance|普通参考线与盲区辅助线区分|
|异常事件|events.csv、Form source|textBox2 Leave与NDB CheckedChanged共用P212|
|metadata/downstream|A3 calls、A7 Round11 proof、A6/A10/A4 evidence|无语义下游reader；仅empty/neutral writer|
|设施负向|controls/events/methods|VOR/ILS/NDB可达；LOC/TACAN/GNSS无证据|''',encoding='utf-8')
tests=[['formula','dme-error','0.0125*r+460 and 1852 conversion','PASS'],['geometry','dme-arcs','r+e,r,r-e arcs and theta±a','PASS'],['geometry','kk-lines','two Lines with 9260 half-length','PASS'],['geometry','overhead','h*tan(halfAngle), optional lines, Circle','PASS'],['event/reachability','facility-dispatch','facility/Guide/DME/KK/Track handlers registered','PASS'],['cross-module','downstream-readers','no A3 semantic consumer in indexed A7/A6/A10/A4 graphs','PASS'],['negative-evidence','two-station','no second facility/radial/intersection','PASS'],['negative-evidence','metadata','no semantic Ws payload','PASS']]
(R/'static-tests.json').write_text(json.dumps({'scope':'Round12 additive static fixtures; no AutoCAD/DLL; Round1 E3 not rerun','tests':[dict(zip(['layer','id','assertion','result'],x)) for x in tests],'count':len(tests),'all_pass':True},ensure_ascii=False,indent=2),encoding='utf-8')
(R/'standard-basis-note.md').write_text('''# A3 规范基线与实现依据

基线为 doc/航空器运行目视和仪表飞行程序设计规范.pdf（AC-97-FS-005，民航规〔2020〕12号，SHA-256 6b6b6f04380f3e0a138ca57bb95fcddb0a390a5b4aa7a9c7a391ff35bb92c8ed）；页级提取 recovered/round5/standard-pages.json（SHA-256 6fe0dcd777a9cc58b40aad3f5752fdefaab420ae35d22f271b8b81c7e39965ac）。

规范页能区分导航台精度和保护区发散，但不能把A3的5.2/4.5、6.9/6.2、2.4/1.4、40/50、5/15、15/25、.0125r+460、9260逐一唯一映射到AC-97-FS-005。A4的VOR7.8°/NDB10.3°是保护区发散，不能替代A3精度角。全部标记IMPLEMENTATION_BASIS_UNRESOLVED，不修改代码。
''',encoding='utf-8')
(R/'closure.md').write_text('''# Round 12 Closure

- Scope: A3 Fix Tolerance final static closure only.
- Decision: A3 COMPLETE_STATIC.
- Round 1–11, existing A3 files, originals and Round 10 are frozen.
- No automatic two-facility cross-fix; A3 is single-station/single-direction tolerance geometry.
- VOR/ILS/NDB, DME adjunct, KK, overhead, Track, CAD, metadata and anomalous event binding are statically closed.
- A7/A6/A10/A4 semantic reuse is not evidenced by direct reader/caller graphs.
- Remaining: E4 host/runtime, Designer/config runtime, implementation-basis confirmation.
- No A1/B1/B2 work was started.
See final-static-closure.md, final-feature-matrix.csv, facility-matrix.csv, dme-final.md, kk-final.md, downstream-consumption.md, event-binding-final.md, cad-output-final.csv and help-ui-code-final.csv.
''',encoding='utf-8')
p=R/'plan.md'; p.write_text(p.read_text(encoding='utf-8').replace('[ ]','[x]'),encoding='utf-8')

