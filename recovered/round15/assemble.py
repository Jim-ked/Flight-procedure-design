"""Round15 documentation assembly only. No target DLL loading or business recovery."""
import csv, hashlib, json
from collections import Counter
from pathlib import Path

ROOT=Path(__file__).resolve().parents[2]
OUT=ROOT/'recovered/final-static-baseline'
ROUND=ROOT/'recovered/round15'
OUT.mkdir(exist_ok=True)
SOURCES=set()
def source(*paths):
    for p in paths:
        if not (ROOT/p).is_file(): raise FileNotFoundError(p)
        SOURCES.add(p)
    return ';'.join(paths)
def write(name, text):
    (OUT/name).write_text(text.strip()+'\n',encoding='utf-8')
def table(name, headers, rows):
    with (OUT/name).open('w',encoding='utf-8-sig',newline='') as f:
        w=csv.DictWriter(f,fieldnames=headers);w.writeheader()
        for row in rows:
            if isinstance(row,str): row=row.split('|')
            w.writerow(row if isinstance(row,dict) else dict(zip(headers,row,strict=True)))
def link(p,label=None):
    if not p.startswith(('recovered/final-static-baseline/','recovered/round15/')): source(p)
    return '['+(label or Path(p).name)+'](<'+(ROOT/p).as_posix()+'>)'

dirs={'A1':'A1-WindSpiral','A2':'A2-BasicCalculation','A3':'A3-FixTolerance','A4':'A4-NavAidProtection','A5':'A5-PrecisionApproach','A6':'A6-Template','A7':'A7-Departure','A8':'A8-TurnArea','A9':'A9-PriSec','A10':'A10-DmeArc','B1':'B1-FlyBy','B2':'B2-FlyOverDF','B3':'B3-RnpApch','B4':'B4-PbnIls','B5':'B5-PbnDeparture'}
base=lambda m: 'recovered/'+dirs[m]+'/'
def ev(m,*names): return source(*(base(m)+n for n in names))
closures={m:base(m)+'final-static-closure.md' for m in ('A1','A2','A3','A7','A9','B1','B2')}
closures.update({'A4':'recovered/round9/closure.md','A5':'recovered/round8/closure.md','A6':'recovered/round4/closure.md','A8':'recovered/round2-closure.md','A10':'recovered/round2-closure.md','B3':'recovered/round6/closure.md','B4':'recovered/round7/closure.md','B5':'recovered/round5/closure.md'})
historical={'A1':('3','PARTIALLY ACCEPTED'),'A2':('1','PARTIALLY ACCEPTED'),'A3':('1','PARTIALLY ACCEPTED'),'A4':('9','ACCEPTED (static recovery)'),'A5':('8','PARTIALLY ACCEPTED (static recovery)'),'A6':('4','ACCEPTED (static recovery)'),'A7':('2','PARTIALLY ACCEPTED'),'A8':('2','PARTIALLY ACCEPTED; module class-range chain closed'),'A9':('1','PARTIALLY ACCEPTED'),'A10':('2','PARTIALLY ACCEPTED; module class-range chain closed'),'B1':('3','PARTIALLY ACCEPTED'),'B2':('3','PARTIALLY ACCEPTED'),'B3':('6','PARTIALLY ACCEPTED'),'B4':('7','PARTIALLY ACCEPTED (static recovery)'),'B5':('5','PARTIALLY ACCEPTED')}
public=list(csv.DictReader((ROOT/'recovered/system-coverage/public-function-matrix.csv').open(encoding='utf-8-sig')))
modules=[]
def add(m,purpose,event,formula,geometry,writer,evaluator,metadata,persistence,manual,reuse,build='NONE_EVIDENCED',extra=()):
    closure=source(closures[m]); text=(ROOT/closure).read_text(encoding='utf-8')
    # Classifications require actual closure content; A8/A10 also require their overview.
    if m in ('A5','B3','B4','B5'):
        assert 'PARTIALLY ACCEPTED' in text and any(s in text.lower() for s in ('orphan','孤立','不可达','调度'))
        status='PARTIAL_STATIC_BUILD_LIMITED'
    else:
        overview=base(m)+'overview.md'
        if m in ('A8','A10'): source(overview); assert '评价' in (ROOT/overview).read_text(encoding='utf-8')
        else: assert 'COMPLETE_STATIC' in text or 'ACCEPTED (static recovery)' in text
        status='COMPLETE_STATIC'
    p=next(x for x in public if x['ModuleId']==m)
    modules.append(dict(Module=m,Command=p['Command'],PublicName=p['PublicName'],HistoricalRound='Round '+historical[m][0],HistoricalStatus=historical[m][1],FinalStaticStatus=status,PrimaryPurpose=purpose,EventChain=event,BusinessFormula=formula,Geometry=geometry,CADWriter=writer,ObstacleEvaluation=evaluator,Metadata=metadata,Persistence=persistence,ManualCADDependency=manual,AutomaticCrossModuleReuse=reuse,StaticResidual='无已索引公开业务链的高价值同构建静态断链；完整Designer/布局为低价值运行重建项',BuildResidual=build,RuntimeResidual='E4_NOT_COMPLETED; API23.1宿主/事件时序/取消/事务未验证',StandardResidual='IMPLEMENTATION_BASIS_UNRESOLVED; 规范映射不等于符合性',LatestClosure=closure,PrimaryEvidence=source(closure,*extra)))

add('A1','单/双/三风螺旋及名义点列绘图','单/双/三Click→手工锚点→P793→Spiral86→列表→writer','q=angle*WindRadius+offset；DirectionSign；非按时间积分','人工起点按R平移；公切线标签对应列表拼接/端点候选','组件Polyline/可选Circle；名义Polyline或4阶Spline','无评价器','helper委托；实体参数回读不是自动区语义','控件config/参数状态；非航段对象','起点/方向/第2与第3螺旋起点/可选转弯终点','共享P793/P854/Spiral86；无路线对象传递',extra=(base('A1')+'final-input-semantics.csv',base('A1')+'cad-output-final.csv'))
add('A2','六类基础计算与计算线','六计算/绘图事件及异常TabIndexChanged绑定闭合','FAF高差/tanGP；NPA与C时间距离；PA Round；复飞/离场高度梯度','拾取入口和方向后构造端点；负距离不夹限','Line+可选DBText；两事务写WsCalcuLine','无','WsCalcuLine Kind+JSON；10+28成员','config控件状态；实体JSON快照','THR/DER/SOC及方向；各链取消判定不同','未发现A7自动读WsCalcuLine',extra=(base('A2')+'WsCalcuLine-schema.md',base('A2')+'cad-output-final.csv'))
add('A3','单设施定位容差/KK/顶空图元','设施/绘图/Track/DME/Overhead事件；Leave=NDB异常绑定','设施精度角；DME=.0125r+460；KK半长9260；h*tan半角','一个S与方向Q；无双台交叉求交','2 Line；楔形/Track Polyline Group；3 Arc+DBText；Circle','无','无业务语义载荷','config控件状态','facility S/方向Q/距离；不自动识别台站','A7重新拾KK；A6/A10无A3业务reader',extra=(base('A3')+'cad-output-final.csv',))
add('A4','VOR/NDB保护边界绘图','设施/宽度事件→两点→Draw','外半宽档位×1852；7.8/10.3；内半宽；15°无限线交点','内外边与中心线；15°替换末端','5或双侧7条2D Polyline+Group','无评价器','空metadata，不写WsObject','config/Form状态','facility与航迹起终点；适用阶段由设计者决定','共享点/线/writer；无A3/A9业务调用',extra=(base('A4')+'cad-output-map.md',base('A4')+'standard-mapping.md'))
add('A5','六模式精密进近/OAS绘图','六绘图模式可达；表面评价P41B/P429无incoming','PartA/B定长解码→尺寸/RDH修正→WXYZ/W*；无自有HL','GPINOP/PAOAS左右/OAS/FAF/FAP不同私有构造','二维Polyline+Group；每子线完整参数TXT','孤立面高评价；无可达穿透/最低标准链','WsObject内四段JSON参数快照；无面名Kind','四段JSON以竖线拼接的UTF8 .json/.txt；另config','跑道/FAF或FAP/IF等锚点及参数','与B4共享OasModel/Plane；loader为复制实现','P41B/P429完整方法体但无UI调度；不可补接冒充恢复',extra=(base('A5')+'persistence.md',base('A5')+'hl-correction.md'))
add('A6','Holding/Base/45-180/80-260/XE/YE/全向模板','模板选择→输入→构造→CAD；Envelope选择处理','共享turn参数；Spiral86/88；gift-wrap Hull保留退化','名义bulge与采样保护点列；P7AF/P7C2两spiral角度成员','Polyline/Group；Holding可选MText；无独立Arc/Circle','非通用障碍物评价入口','helper可选参数；见CAD图元表','config/Form状态','模板锚点/方向；Envelope选Polyline或Line','共享primitive/writer；无统一业务模板引擎',extra=(base('A6')+'shared-geometry.md',base('A6')+'cad-output-map.md'))
add('A7','传统离场定高/定点/全向绘图与评价','三模式Screen→CAD/Evaluate→table→Mark均可达','高度/梯度/距离；二检P203；三独立评价器','镜像多边形/共享顶点/线与圆载体；无风螺旋','Polyline/Group/Circle及Mark块；全向外圆Radius；内存线非CAD Line','P282/P28D/P291可达；二检覆盖同一行','WsObject的Radius字符串；非独立RegApp','config控件状态/模板保存；不转交A2/A3语义对象','DER/THR/TP/KK/C重拾；无电台/航迹引导分支','共享frame/P793/parser/Mark；不共享B5业务类',extra=(base('A7')+'runway-coordinate.md',base('A7')+'cad-output-map.md'))
add('A8','KK转弯区障碍物评价','Screen→KK局部框架→Evaluate→表→Mark/Highlight','MOC/要求梯度；Ds两点三维距；MCG输出','KK两端反向局部框架；不是保护区绘图','无保护区writer；Mark块+Altitude/Name属性','自身KK评价；保留所有导入点','可读公共WsEntityFrame名称；非KK语义','config/Form状态','KK左右端/Ds两点；障碍物SelectAll','不直接调用A7/A9业务评价器',extra=(base('A8')+'overview.md',))
add('A9','通用主副区障碍物评价','Screen→Normal/IF Evaluate→表→Mark','Normal开区间；IF闭区间；主区末宽差异；副区线性MOC','数字起终点局部框架；无已有Polyline解析','无保护区writer；Mark原DBPoint处插块','P330/P331；严格横向粗筛；显示负localXY/原Z','公共障碍物名称可选；无保护区语义读取','config/Form状态','UI数值端点/宽度/MOC；不据泛表断言GetPoint','B3独立评价器，仅共享底层',extra=('recovered/ObstacleData/pri-sec-evaluation.md',))
add('A10','起始进近DME弧绘图与评价','O/IF/IAF拾点→绘图/扇区评价→表→Mark','独立Arc扇区；MOC固定factor*300，已解析UI MOC不驱动该式','自建DME弧与扇区；不自动接FAF/IF直线','Arc/Polyline/可选DBText；Mark Obst块','自身扇区评价链','CAD helper元数据；不读A3 DME语义','config/Form状态','O/IF/IAF和方向；设施/相接程序人工确定','无A3业务调用；共享CAD/障碍物公共层',extra=(base('A10')+'cad-output-map.md',base('A10')+'overview.md'))
add('B1','Fly-by保护边界绘图','三点→descriptor→角度候选→名义/四边界/KK/NN/spiral/tolerance','earliest=ATT+R*tan(A/2)；latest扣ATT与延迟距离','≤60/≤90/>90与15/30候选；SW1/SW2独立','名义4顶点bulge Polyline；4保护线；KK单线/NN Group','无','部分子实体WsObject；Group及容差无赋值','config/Form状态','P1来向/P2航路点/P3去向；非航段长度传递','与B2同primitive；业务类/候选模式分别实现',extra=(base('B1')+'cad-output-map.md',))
add('B2','Fly-over DF保护边界绘图','三点→DF descriptor→候选→边界/spiral/tolerance','earliest=ATT；latest=-ATT-delay*(TAS+wind)/3.6；零ATT无特判','15°候选；12000/13000为载体长度，非宽度','名义4顶点bulge Polyline；4保护线；spiral Group','无','子实体WsObject；容差无metadata','config/Form状态','P1来向/P2飞越点/P3出转方向；不保留下一fix语义','共享Spiral86/P793及writer；非B1同业务MethodDef',extra=(base('B2')+'cad-output-map.md',))
add('B3','RNP APCH LNAV绘图及孤立APV/评价体','LNAV绘图可达；P594/P5EE/P470链孤立','LNAV/MOC/直线复飞；APV温度/HL/Xz；无任意转弯','LNAV边界；APV数值面未从UI绘制','可达LNAV二维Polyline/Group；可Mark','LNAV/APV方法体完整；无可达评价调度','WsObject Form状态回读；公共点名称','UTF8 .rnp控件path:value；另XML config','跑道/FAF等参数和点；对象状态GetEntity恢复','frame/parser/Mark共享；P595/P5EF不同于A9','P594/P5EE/P470及后处理孤立；无Take5',extra=(base('B3')+'persistence.md',base('B3')+'cad-output-map.md'))
add('B4','OAS加同轴固定宽度PBN复飞衔接','Draw可达；P566 Evaluate仅提示；P56D KML空','OAS修正；专用面/HL；不含B3 GP>3.2项','E→15°→3704与YZ→1852；非任意PBN转弯','二维Polyline/Group；子线OAS TXT','P5E0/P567/共享P41B孤立；前5点仅导入展示','WsObject完整旧OAS文本；无Kind/独立Radius','旧CSV式参数TXT与config；不可与A5格式互换','跑道/参数/已有实体状态恢复；障碍物Take5','共享OasModel/Plane；DB loader复制；无Spiral86','Evaluate提示/评价器无incoming；KML空体；Take5',extra=(base('B4')+'cad-output-map.md',base('B4')+'hl-correction.md'))
add('B5','PBN离场定高/定点FlyOver-DF绘图','绘图可达；P501/P50C/P50D提示分派；评价无调度','P5CD/P5D8评价体；定高/FlyOver几何；固定1482','Spiral86/Hull/TurnEnd后续区；非A7同业务类','Polyline/Group；辅助几何仍为点列；Mark块','评价体孤立；无端到端归并排序；Take5仅导入','主writer description为空，不写业务XData；公共点名称可读','config/Form状态；无保护区实体往返协议','DER/THR/TP/TurnEnd等锚点；衔接需人工','共享frame/P793/primitive/parser；A7无wind spiral','提示式调度未接P5CD/P5D8；Take5影响点集',extra=(base('B5')+'protection-connections.md',base('B5')+'cad-output-map.md'))

table('module-master.csv',list(modules[0]),modules)
status_headers=['Module','Command','PublicName','HistoricalRound','HistoricalStatus','FinalStaticStatus','DecisionReason','LatestClosure','PrimaryEvidence']
table('final-public-function-status.csv',status_headers,[{**{k:r[k] for k in status_headers if k!='DecisionReason'},'DecisionReason':r['BuildResidual'] if r['FinalStaticStatus']!='COMPLETE_STATIC' else '当前构建已实现公开链及负向功能证据可审计；不等于E4/规范批准'} for r in modules])
counts=Counter(r['FinalStaticStatus'] for r in modules)
COUNTS='\n'.join('- `'+s+'`: '+str(counts[s]) for s in ('COMPLETE_STATIC','PARTIAL_STATIC_BUILD_LIMITED','PARTIAL_STATIC_OTHER_BUILD_REQUIRED','NOT_PUBLIC_BUSINESS_FUNCTION'))
complete=', '.join(r['Module'] for r in modules if r['FinalStaticStatus']=='COMPLETE_STATIC')
limited=', '.join(r['Module'] for r in modules if r['FinalStaticStatus']=='PARTIAL_STATIC_BUILD_LIMITED')

cross=[]
def flow(a,b,shared,meta,semantic,repick,copied,actual,*evidence):
    cross.append([a,b,shared,meta,semantic,repick,copied,actual,source(*evidence)])
flow('A2','A7','P793及底层CAD','NO','NO','YES: TP/C','NO business handoff','A2计算线留在图面，A7重拾；WsCalcuLine reader wrapper无indexed incoming',closures['A2'],closures['A7'])
flow('A3','A7','点/线与CAD primitive','NO','NO KK semantic read','YES: KK','NO business handoff','KK线用于人工取点，不读Group/XData恢复定位容差模型',closures['A3'],closures['A7'])
flow('A3','A6','点/线/通用CAD','NO','NO','YES anchors','NO direct A3 caller','共享primitive，模板业务独立',closures['A3'],base('A6')+'shared-geometry.md')
flow('A3','A10','通用CAD/点原语','NO','NO DME read','YES O/IF/IAF','BUSINESS_SIMILAR_ONLY','A10自建DME弧/扇区，不接收A3容差模型',closures['A3'],base('A10')+'overview.md')
flow('A5','B4','OasModel P411–P41E; Plane P834–P840; P087/P089','独立参数快照；格式不互换','手动GetEntity读状态，不是区配对','YES runway/parameters','YES loaders P409–40C vs P571–574','共享数学底层；几何封装/格式/loader不同',base('A5')+'class-map.md',base('B4')+'oas-parameter-model.md')
flow('B4','A5','OasModel/Plane/CAD','NO automatic transfer','NO automatic geometry semantic read','YES','YES private loaders','A5六模式不等于B4同轴衔接模型',base('A5')+'class-map.md',base('A5')+'persistence.md')
flow('A7','B5','P0AC/P0AD; P793; parser/Mark/CAD','NO procedure transfer','NO area semantic read','YES TP/runway; B5 TurnEnd','BUSINESS_SIMILAR_ONLY','A7无spiral；B5有Spiral86/Hull，非共享完整业务类',closures['A7'],base('B5')+'protection-connections.md')
flow('B5','A7','frame/P793/obstacle/CAD','NO','NO','YES','BUSINESS_SIMILAR_ONLY','B5 TurnEnd不属于A7字段/事件',closures['A7'],base('B5')+'overview.md')
flow('A9','B3','障碍物导入/点线primitive','点名称可共同解析；非评价模型','NO area semantic read','A9数值端点；B3自身参数','SIMILAR_MATH','P330/P331与P595/P5EF独立；端点纳入条件不同',closures['A9'],base('B3')+'obstacle-evaluation.md')
flow('B3','A9','SelectAll/parser/Mark','NO procedure transfer','NO','各窗独立输入','SIMILAR_MATH','公共点数据不等于共享分类/副区算法',closures['A9'],base('B3')+'overview.md')
for b in ('B1','B2'):
    flow('A1',b,'P793/P854; Spiral86 point/sample/radius; P7AD','NO procedure transfer','NO automatic anchor read','YES three points','独立业务边界类','共享风螺旋primitive；A1列表不等于FlyBy/DF保护区算法',closures['A1'],closures[b],'recovered/round13/shared-final.csv')
table('cross-window-data-flow.csv',['SourceModule','TargetModule','SharedMethod','MetadataTransfer','EntitySemanticRead','ManualRepick','CopiedAlgorithm','ActualRelationship','Evidence'],cross)

components=[]
def component(n,kind,users,role,limit,*refs): components.append([n,kind,users,role,limit,source(*refs)])
component('P793 / P854','SAME_METHODDEF','A1/A2/A6/A7/B1/B2/B3/B5','turn输入与派生TAS/Rate/Radius/WindRadius/Drift','各调用者只消费部分字段；B3为TAS，A7不消费spiral半径；B4核心不调用','recovered/shared-turn-methods.md',closures['A7'],base('B4')+'pbn-turn.md')
component('Spiral86','SAME_METHODDEF','A1/B1/B2/A6部分/B5','点/采样/半径与候选迭代','A6 XE/YE/45/80使用；非全部模板；不是全程序模型',base('A6')+'shared-geometry.md','recovered/round13/shared-final.csv')
component('Spiral88','SAME_METHODDEF','A6 Holding/Base','普通Holding/Base spiral与P7BE/P7C2','与Spiral86不同MethodDef，不能统一替代',base('A6')+'shared-geometry.md')
component('point-to-spiral P7AD / P7BE; angle P7AF / P7C2','SAME_METHODDEF','A1/B1/B2/B5及A6相应成员','点到spiral迭代；A6两spiral角度成员','A6业务P7AD直接caller=0；不等于通用稳健公切线solver',base('A6')+'shared-geometry.md',closures['A1'])
component('P0AC/P0AD runway frame','SAME_METHODDEF','A7/B3/B4/B5','跑道数值局部坐标变换','不是WsEntityFrame；A8 KK框架和A9自己的数值输入需分列',base('A7')+'runway-coordinate.md',base('B3')+'runway-frame.md',base('B4')+'runway-frame.md')
component('point / line primitives','SAME_METHODDEF','多数几何模块','距离、角度、无限直线交点/侧方判断','共享原语不能推出共享业务构造器','recovered/GeometryPrimitives/shared-geometry-map.md',base('A4')+'boundary-geometry.md')
component('P086 / P087 / P089 CAD writer','SAME_METHODDEF','A3/A4/A5/A6/B1/B2/B3/B4/B5等','P086单Polyline；P087列表+Group；P089追加ModelSpace及可选WsObject','旧Round3 token表错配按Round4补证；Group不自动有metadata',base('A6')+'cad-output-map.md',base('A5')+'cad-output-map.md')
component('SelectAll DBPoint P10D','SAME_METHODDEF','A7/A8/A9/A10/B3/B4/B5','DXF POINT + Model筛选','不是用户逐个选择障碍物；B4/B5在之后Take5','recovered/ObstacleData/WsEntityFrame-schema.md',base('B4')+'obstacle-evaluation.md')
component('Obstacle parser P12F','SAME_METHODDEF','障碍物公共链','XYZ原点；caller ordinal ID；可选名称解析/回退','无树高相加、无从MText读名','recovered/ObstacleData/WsEntityFrame-schema.md')
component('Mark','SAME_METHODDEF','A7/A8/A9/A10/B3/B4/B5','row ID→原DBPoint→块/Altitude属性','A10块名Obst；A8多Name；不以OCA代替Z','recovered/ObstacleData/marker.md',closures['A9'])
component('Highlight','SAME_METHODDEF','障碍物表窗口','ID映射原点/视图helper','B4/B5字典前5点限制同样影响高亮',base('B4')+'obstacle-evaluation.md','recovered/ObstacleData/screen-data.md')
component('WsObject','SAME_METHODDEF','A1 helper/A5/A6/A7/B1/B2/B3/B4等','可选字符串XData载荷','B5主writer传空跳过；不同调用者payload不同；无全局区语义schema','recovered/GeometryPrimitives/WsObjectCad.Recovered.cs',base('B4')+'xdata-schema.md',base('B5')+'xdata-schema.md')
component('WsCalcuLine','SAME_METHODDEF','A2写；孤立reader/wrapper','Kind+JSON计算线快照','无已索引A7等业务消费者',base('A2')+'WsCalcuLine-schema.md',closures['A2'])
component('WsEntityFrame','SAME_METHODDEF','属性工具/障碍物可选名称解析','EntityType/Name/Properties通用实体属性','非跑道frame；RandomPoint不自动写该记录','recovered/ObstacleData/WsEntityFrame-schema.md')
component('OasModel / Plane','SAME_METHODDEF','A5/B4；相关APV数值面底层','共享OAS系数与面/域/交点','loader/模式封装/最低标准不可据此合并',base('A5')+'class-map.md',base('B4')+'oas-parameter-model.md')
component('config / state serializer P0FB/P0FC/P0FD等','SAME_METHODDEF','多数窗体','按dotted路径保存控件Text/Index/bool等状态','XML config与.rnp文本、OAS参数文件协议分别记录',base('B3')+'persistence.md',base('A5')+'persistence.md')
table('shared-components-final.csv',['Component','Classification','Consumers','Role','Boundary','Evidence'],components)

relations=[
['B1 vs B2','P793/Spiral86/CAD','SAME_METHODDEF','同一底层成员复用',source('recovered/round13/shared-final.csv')],
['B1 vs B2','carrier/candidate业务结构','COPIED_IMPLEMENTATION','结构模式重复；FlyBy与DF公式/分支不同，不是同完整业务方法',source(closures['B1'],closures['B2'])],
['A7 vs B5','frame/P793/parser/Mark','SAME_METHODDEF','实际底层调用复用',source('recovered/round5/a7-b5-shared-identities.csv')],
['A7 vs B5','离场业务构造器','BUSINESS_SIMILAR_ONLY','三模式镜像/圆与Spiral86/Hull/TurnEnd不同',source(closures['A7'],base('B5')+'protection-connections.md')],
['A9 vs B3','障碍物公共层','SAME_METHODDEF','共享导入/解析及基础工具',source(closures['A9'],base('B3')+'overview.md')],
['A9 vs B3','主副区线性评价','SIMILAR_MATH','P330/P331与P595/P5EF不同；边界纳入条件不同',source(closures['A9'],base('B3')+'obstacle-evaluation.md')],
['A5 vs B4','OasModel/Plane/writer','SAME_METHODDEF','共享系数/面/交点及图元writer',ev('A5','class-map.md')],
['A5 vs B4','DB loader/decoder/尺寸/RDH','COPIED_IMPLEMENTATION','P409–P40C与P571–P574独立成员；同schema/key/解码',ev('A5','oas-parameter-model.md')],
['B3 vs B4 HL','高损修正','SIMILAR_MATH','B3有GP>3.2项且不Round；B4无GP项、三分支独立舍入',source(base('B3')+'hl-correction.md',base('B4')+'hl-correction.md')],
['A5 vs B3/B4 HL','A5自有HL','NO_RELATION','未发现A5自有HL公式/表/消费者，不能借用补齐',ev('A5','hl-correction.md')],
]
table('shared-vs-copied-final.csv',['Pair','Aspect','Classification','Conclusion','Evidence'],relations)

cad=[]
# PRESENT means creation in the reviewed chain; READ_ONLY and IN_MEMORY are explicit.
cadfacts={
'A1':['NO','YES components/nominal','NO','OPTIONAL base','OPTIONAL degree4','NO','NO','NO','NO','NO','NOT_PROVEN_A1_SPECIFIC','helper-dependent'],
'A2':['YES calculated','NO','NO','NO','NO','NO','NO','OPTIONAL','NO','NO','NO','WsCalcuLine'],
'A3':['YES 2 KK','YES wedge/Track','YES 3 DME','OPTIONAL overhead','NO','NO','NO','YES DME','NO','NO','YES lists','NO semantic payload'],
'A4':['NO','YES 5/7','NO','NO','NO','NO','NO','NO','NO','NO','YES','NO'],
'A5':['NO','YES 2D','NO','NO','NO','NO','NO','NO','NO','NO','YES','WsObject per child'],
'A6':['NO standalone in bound template writers','YES nominal bulge/protection','NO standalone','NO standalone','NO','NO','OPTIONAL Holding','NO','NO','NO','YES','optional helper payload'],
'A7':['NO standalone; memory carriers only','YES','NO','YES omni','NO','READ_ONLY','NO','NO proven dedicated text','YES Mark','YES Altitude','YES','WsObject Radius on outer Circle'],
'A8':['NO','NO','NO','NO','NO','READ_ONLY','NO','NO','YES Mark','YES Altitude/Name','NO protection','optional WsEntityFrame read'],
'A9':['NO','NO','NO','NO','NO','READ_ONLY','NO','NO','YES Mark','YES Altitude','NO','optional name read only'],
'A10':['NO evidenced independent Line','YES','YES; separate memory/persisted scope','NO','NO','READ_ONLY','NO','OPTIONAL','YES Mark Obst','YES Altitude','writer indexed','helper path; no A3 semantic read'],
'B1':['NO standalone','YES nominal bulge/four boundary/KK','NO standalone','NO','NO','NO','NO','NO','NO','NO','YES NN/spiral','WsObject selected child paths'],
'B2':['NO standalone','YES nominal bulge/four boundary','NO standalone','NO','NO','NO','NO','NO','NO','NO','YES spiral','WsObject except tolerance'],
'B3':['NO','YES LNAV','NO','NO','NO','READ_ONLY','NO','NO','YES Mark','YES Altitude','YES','WsObject form state'],
'B4':['NO','YES 2D','NO','NO','NO','READ_ONLY','NO','NO','YES Mark','YES Altitude','YES','WsObject OAS TXT'],
'B5':['NO standalone','YES','NO standalone','NO','NO','READ_ONLY','NO','NO','YES Mark','YES Altitude','YES','NO business write; empty description']}
for m in dirs:
    ref=closures[m] if m in ('A8','A9') else base(m)+('cad-output-final.csv' if m in ('A1','A2','A3') else 'cad-output-map.md')
    cad.append([m,*cadfacts[m],*(['NOT_EXPLICIT_IN_REVIEWED_CHAIN']*3),source(ref)])
table('cad-entity-master.csv',['Module','Line','Polyline','Arc','Circle','Spline','DBPoint','MText','DBText','BlockReference','AttributeReference','Group','XData','ExplicitLayer','ExplicitColor','ExplicitLinetype','Evidence'],cad)

metadata=[
['WsCalcuLine','A2','reader P655(original656) via wrapper6AB(original6AC)','NO public business semantic reuse','YES wrapper no indexed incoming','1001 app +1000 Kind +1000 JSON; 10 line/28 turn members',ev('A2','WsCalcuLine-schema.md','final-static-closure.md')],
['WsObject','metadata-bearing CAD helper callers; B5 main writer empty','A1/A5/B3/B4 manual GetEntity state read','NO automatic topology/area pairing','NOT a universal orphan claim','1001 WsObject +1000 string; schema depends on caller',source('recovered/GeometryPrimitives/WsObjectCad.Recovered.cs',base('A5')+'xdata-schema.md',base('B3')+'xdata-schema.md',base('B4')+'xdata-schema.md',base('B5')+'xdata-schema.md')],
['WsEntityFrame','generic attribute tooling; NOT RandomPoint','shared obstacle parser optional EntityName','Name reuse only, not procedure semantics','NO orphan claim','1001 app/type/name + sliced Unicode JSON; Properties Key/Value list',source('recovered/ObstacleData/WsEntityFrame-schema.md')],
['Radius','A7 omni outer Circle','no indexed downstream procedure reader','NO','reader not evidenced','String inside WsObject; not a separate RegApp/label',source(closures['A7'],base('A7')+'cad-output-map.md')],
['Form-state','A1/B3 entity payload; multiple Forms config','selected entity A1/B3 state restore; B5 no business payload','NO automatic semantic reuse','reader per module; not all orphan','control state snapshots; loose XData[1] reading lacks strict RegApp/schema check',source(closures['A1'],base('B3')+'xdata-schema.md',base('B5')+'xdata-schema.md')],
['OAS parameter TXT','A5 and B4 separately','A5 P318 selected XData[1]; B4 P56B selected XData[1]/file import','NO automatic cross-format use','NO','A5 four JSON sections; B4 old CSV-like text; payload != surface label',source(base('A5')+'persistence.md',base('B4')+'persistence.md')],
['.rnp','B3 P47F','B3 P47E/P0FD','NO','NO','UTF8 FormApvEvl header + dotted path:value; control state, not procedure model',ev('B3','persistence.md')],
['config','Forms via common state serializer','Form Load','Automatic control restore only','N/A','XML Document/Form nodes/dotted keys; separate from portable text protocols',source(base('B3')+'persistence.md',base('A5')+'persistence.md')],
]
table('metadata-master.csv',['Metadata','WriterModules','ReaderModules','AutomaticSemanticReuse','KnownOrphanReader','SchemaEvidence','Evidence'],metadata)

obstacle=[]
def obst(n,inp,take,frame,cl,moc,out,mark,highlight,ui,*refs): obstacle.append([n,inp,take,frame,cl,moc,out,mark,highlight,ui,source(*refs)])
common='recovered/ObstacleData/WsEntityFrame-schema.md'
obst('RandomPoint','生成随机XYZ；每点DBPoint+MText','N/A','CAD原坐标','无','无','裸DBPoint；不写WsEntityFrame；MText可空','N/A','N/A','YES creation',common)
obst('ScreenData','P10D SelectAll DXF POINT + Model','caller-dependent','先保留原点','不是保护区筛选','无','序号ID→原DBPoint字典','公共后续','公共后续','YES',common)
obst('parser P12F','DBPoint+caller ordinal','N/A','原XYZ','可选EntityName/后缀回退','无树高附加','obstacle carrier','保持原点映射','保持原点映射','shared',common)
obst('A7','Model DBPoint','NO','跑道frame','定高/定点/全向三独立分支+二检','分支公式/75下限等','表；二检覆盖同一行','原点/Altitude','原点','YES',closures['A7'])
obst('A8','Model DBPoint','NO','KK左端反向frame','KK线外/模式分类','输入固定MOC与Ds/梯度','表/MCG','原点/Altitude+Name','原点','YES',base('A8')+'overview.md')
obst('A9','Model DBPoint','NO','UI数值S/E frame','Normal开区间/IF闭区间+严格粗筛','主区插值/副区线性','负localXY+原Z/MOC/OCA','原点/Altitude=Z','原点','YES',closures['A9'])
obst('A10','Model DBPoint','NO','O/IF/IAF扇区','自己的Arc扇区','固定factor*300，非已解析UI MOC','表','Obst块/原点Z','原点','YES',base('A10')+'overview.md')
obst('B3','Model DBPoint','NO','跑道frame','P594 LNAV/P5EE APV；P595/P5EF局部分类','LNAV/复飞及APV面/HL','初始导入表可达；评价/后处理孤立','原点/Altitude','原点','IMPORT YES; EVALUATION NO',base('B3')+'obstacle-evaluation.md')
obst('B4','Model DBPoint','YES before parser first5','跑道frame','P5E0/P41B面；P567最低标准孤立','副面/HL自身分支','前5点表/字典；无端到端评价','限前5点映射','限前5点映射','IMPORT YES; P566 prompt only',base('B4')+'obstacle-evaluation.md')
obst('B5','Model DBPoint','YES before parser first5','跑道frame','P5CD/P5D8孤立；不是P41B','直线/转弯体已恢复','前5点表；无归并排序可达链','限前5点映射','限前5点映射','IMPORT YES; prompt dispatch only',base('B5')+'obstacle-evaluation.md')
obst('A5','surface numerical arguments; no reachable Screen/eval chain','N/A','模型局部坐标','孤立P41B/P429面高/标签','无自有HL/最低标准','绘图可达；非评价表链','无A5可达Mark','无A5评价高亮链','DRAW YES; EVALUATION NO',base('A5')+'obstacle-evaluation.md',base('A5')+'hl-correction.md')
table('obstacle-system-final.csv',['Module','Input','Take5','LocalFrame','Classifier','MOC','Output','Mark','Highlight','UIReachable','Evidence'],obstacle)

connections=[]
def conn(m,k,operation,auto,manual,*refs): connections.append([m,k,operation,auto,manual,source(*refs)])
conn('A1','point-list concatenation','start/base-circle/spiral列表拼接；标签common tangent','点列已编码；非独立通用solver','双/三起点与可选终点人工',closures['A1'])
conn('A3→A7','manual repick','KK画出后A7重新拾点','无语义自动接续','KK位置/业务角色由设计者认定',closures['A3'],closures['A7'])
conn('A4','line intersection','15°无限线与内外边求交后替换末端','局部交点/端点替换已编码','阶段与相邻程序适用性人工',base('A4')+'15-degree-line.md')
conn('A5','line intersection','面/平面交点与IF/FAF/FAP截限轮廓','各模式数学交点/夹限已编码','输入点及相邻段非自动拓扑',base('A5')+'cad-output-map.md',base('A5')+'class-map.md')
conn('A6','Hull','Envelope选择Polyline/Line及模板gift-wrap','选定点集Hull已编码；绑定Envelope非Region Union','选择哪些图元和是否合适仍人工',base('A6')+'shared-geometry.md',base('A6')+'cad-output-map.md')
conn('A6','candidate comparison','P7AF/P7C2两spiral角度；P7BE或自有P463迭代','具体模板成员已编码','不能推广任意保护区共同切线',base('A6')+'shared-geometry.md')
conn('A7','shared vertex','三模式阶段共用顶点与镜像边界','共享点/阶段点列已编码','TP/KK/C与上游区关系人工',closures['A7'])
conn('A7','line carrier','直线/转弯区边界与全向圆载体','无IntersectWith/Offset/Hull/裁剪/删除重建','图面相接性仍由设计者判断',closures['A7'])
conn('A8/A9','manual repick','A8 KK重拾；A9数值框架/宽度','不读现有区边界拓扑，不构造保护区','业务区/坐标含义人工指定',closures['A9'],base('A8')+'overview.md')
conn('A10','line carrier','O/IF/IAF自建弧扇区/辅助连接','局部几何已编码；无自动FAF/IF直线延续','后续保护区连接人工',base('A10')+'cad-output-map.md')
for m in ('B1','B2'):
    conn(m,'candidate comparison','角度候选/侧方比较→四条边界列表','业务内候选比较已编码，无CAD实体布尔裁剪','三点/宽度/与外部区相接人工',closures[m])
conn('B3','shared vertex','LNAV直线扩张/复飞共享分段点','可达绘图已编码；APV厂/评价孤立','无左右任意转弯/KK/C自动接续',base('B3')+'overview.md')
conn('B4','line intersection','OAS E/Y/Z与15°线、1852/3704带/副面相接','同轴点线/面交点已编码','不是任意PBN后续转弯',base('B4')+'oas-pbn-connection.md')
conn('B5','Hull','Spiral86/候选子集Hull/TurnEnd后续区','局部候选与包络已编码；无端到端区合并评价','TurnEnd/相邻保护区人工',base('B5')+'protection-connections.md')
table('protection-connection-final.csv',['Module','Classification','Operation','CodeDefinedScope','ManualScope','Evidence'],connections)

manual=[]
def pick(m,inp,api,possible,actual,judge,why,dest,*refs): manual.append([m,inp,api,possible,actual,judge,why,dest,source(*refs)])
pick('A1','spiral start/track/third origin/optional turn end','GetPoint','已有程序对象不足；若另有路线数据可另行推导，当前未证','NO','YES third origin and curve connection','仅坐标拾取，无路线对象ID','heading/shifted origin/list assembly',closures['A1'])
pick('A1','existing state-bearing entity','GetEntity','选中payload可恢复状态；选择与当前程序的关联未编码','STATE RESTORE ONLY','YES selected snapshot','没有自动选择对象或保护区语义匹配','XData第二项→Form/config state',closures['A1'],base('A1')+'cad-output-final.csv')
pick('A2','THR/DER/SOC and track direction','GetPoint','本窗无上游入口/路线语义；不能保证自动可恢复','NO','YES reference and bearing','公式数值不含图上身份','line endpoints/WsCalcuLine；取消差异见closure',closures['A2'])
pick('A3','facility S/track Q/DME range','GetPoint','若有设施库可推导；当前代码不接库','NO','YES station and direction','无设施对象语义查询','precision wedge/KK/3 DME Arc/overhead',closures['A3'])
pick('A4','facility/track S,E','GetPoint','仅两点；无已存路线关联','NO','YES phase/selected segment','缺适用阶段和前后段模型','width expansion/15° endpoint replacement',closures['A4'])
pick('A5','THR/runway/FAF-FAP/IF parameters','GetPoint + numeric UI','部分坐标若另有程序数据可推导；本构建未关联','NO','YES reference semantics','状态快照无段间拓扑','runway frame/mode contours',closures['A5'])
pick('A5','existing parameter-bearing entity','GetEntity','payload存在时可恢复参数；选择哪条仍人工','PARAMETER RESTORE ONLY','YES entity and snapshot appropriateness','没有自动匹配当前程序/区的键','P318 XData[1]→parameter import',base('A5')+'xdata-schema.md')
pick('A6','template anchors/track','GetPoint','无统一程序锚点来源','NO','YES anchors','模板拥有自己的输入状态','Holding/Base/45/80 construction',base('A6')+'overview.md')
pick('A6','existing Polyline/Line for Envelope','GetSelection','存在几何点，但缺哪些区应合并的业务规则','POINT EXTRACTION/HULL AFTER SELECTION','YES selection and envelope meaning','实体不携带统一区拓扑/主副区角色','selected vertices→Hull/Envelope',base('A6')+'cad-output-map.md')
for inp,dest in [('DER/THR','runway frame'),('TP','distance/height'),('KK','early/latest distance'),('C','delay/end distance')]:
    pick('A7',inp,'GetPoint','A2/A3部分几何已有；缺业务关联键，不能保证唯一推导','NO','YES coordinate/object role','不读WsCalcuLine/KK Group语义',dest,closures['A7'])
pick('A8','KK endpoints/Ds','GetPoint','图元坐标可候选提取；无KK语义配对键','NO','YES KK endpoints/Ds reference','不会自动解析上游区','KK local frame and Ds distance',base('A8')+'overview.md')
pick('A9','start/end/width/MOC','numeric UI; GetPoint not asserted','数值已有即可计算；没有可识别保护区实体对象','NUMERIC TRANSFORM ONLY','YES numeric business region','无现有Polyline reader','Normal/IF classification',closures['A9'])
pick('A10','O/IF/IAF','GetPoint','A3 DME无业务reader；现有点不保证唯一','NO','YES facility/fixes/connection','自建扇区，不继承A3','Arc/sector/evaluator',base('A10')+'overview.md')
for m in ('B1','B2'):
    pick(m,'P1/P2/P3 track/waypoint','GetPoint','另有路线对象才可推导；当前无模型','NO','YES which waypoint and directions','P1/P3只提供方向，不带leg长度语义','descriptor/angle/candidates',closures[m])
pick('B3','runway/FAF/APV parameters','GetPoint + numeric UI','部分可由外部程序数据提供；本构建不自动关联','NO','YES datum/fix/parameters','各窗独立状态','LNAV geometry/APV numerical inputs',base('B3')+'overview.md')
pick('B3','existing state entity','GetEntity','已有payload可读但实体选择需人工','STATE RESTORE ONLY','YES selected snapshot','缺严格RegApp/schema/程序关联验证','P483 XData[1]→control restore',base('B3')+'xdata-schema.md')
pick('B4','runway/OAS parameters or existing entity','GetPoint/GetEntity','可恢复选中payload；不自动识别区角色','STATE RESTORE ONLY','YES snapshot/runway','单纯参数文本不含面身份','P56B XData[1]→old OAS text',base('B4')+'xdata-schema.md')
pick('B5','DER/THR/TP/turn end','GetPoint','现有参数不足以唯一确定TurnEnd及后续区','NO','YES turn end and adjacent area','无全局路线拓扑','Spiral86/Hull/post area',base('B5')+'protection-connections.md')
pick('A7/A8/A9/A10/B3/B4/B5','obstacles','SelectAll (not manual GetSelection)','YES Model DBPoint filter','YES; B4/B5 first5','YES drawings/point eligibility; no arbitrary shape selection','业务筛选由后续分类器；前5截取不是保护区筛选','parser→ID dictionary→table→Mark/Highlight',common,base('B4')+'obstacle-evaluation.md')
table('manual-interaction-final.csv',['Module','Input','GetPoint/GetEntity/GetSelection','AutomaticallyRecoverable','ActuallyRecoveredAutomatically','ManualJudgementRequired','WhyManual','CalculationConsumer','Evidence'],manual)

diffs=[
['A1','common tangent','HELP_OVRSTATES_BUILD','UI标签与通用两spiral solver不能等同；实际点列拼接/候选；A6另有角度成员',source(closures['A1'],base('A6')+'shared-geometry.md')],
['A3','cross-fix','HELP_OVRSTATES_BUILD','实现仅单台S+方向Q；无双台自动交叉定位',source(closures['A3'])],
['A5','surface evaluator','CODE_ORPHAN','P41B/P429完整面高体，无indexed incoming，不是漏反编译',source(closures['A5'])],
['B3','LNAV/APV evaluator/factory','CODE_ORPHAN','P594/P5EE/P470及后处理链不可从当前UI到达',source(closures['B3'])],
['B4','Evaluate P566','UI_STUB','消息提示，不调P5E0/P567/P41B',source(closures['B4'])],
['B4','surface/minima evaluators','CODE_ORPHAN','数学体存在，公开入口调度缺失',source(closures['B4'])],
['B4','KML P56D','UI_STUB','绑定方法为空；无输出区域/坐标/样式',source(closures['B4'])],
['B5','Evaluate dispatch','UI_STUB','P501/P50C/P50D提示路径；无端到端评价/归并',source(closures['B5'])],
['B5','P5CD/P5D8 evaluator','CODE_ORPHAN','两业务评价体存在且已恢复；不是共享P41B',source(closures['B5'])],
['A7','ScreenData/DER/help','HELP_OVRSTATES_BUILD','SelectAll Model DBPoint；帮助THR而入口DER；无导航方式/电台上空独立分支',source(closures['A7'])],
['A2','NPA time/C time labels','CONSISTENT','代码单时间字段18或6；不得把其解释为强制3+15或3+3',source(closures['A2'])],
]
table('help-ui-code-final.csv',['Module','Feature','Classification','ActualBuildBehavior','Evidence'],diffs)

standards=[]
def norm(m,behavior,mapping,candidate,*refs): standards.append([m,behavior,source(*refs),mapping,candidate,'实现依据待确认；未据规范改写恢复代码'])
norm('A1','turn rate cap3；WindRadius/Drift；角度线性风累积','已有局部映射；非风时域模型等价证明','ICAO Doc8168其他版/旧国内规范/作者简化，均未确证','recovered/round13/standard-basis-note.md',closures['A1'])
norm('A2','单时间18；C风56与时间6；离场5；HLcor=0哨兵','18未分3+15；6未分3+3；哨兵异常保留','历史时间/风假设或简化待查','recovered/round14/standard-basis-note.md',closures['A2'])
norm('A3','精度5.2/4.5/6.9/6.2/2.4/1.4；50/40；.0125r+460；9260','设施/容差/顶空/距离角色已证；历史来源未唯一确认','ICAO版本/旧国内规范待查','recovered/round12/standard-basis-note.md',closures['A3'])
norm('A4','7.8/10.3；1/2NM与1.25/2.5NM；15°；半宽分界','已有2020局部匹配；大档/阶段适用限制/未自动校验分别保留','原作者适用阶段或其他版本待查',base('A4')+'standard-mapping.md')
norm('A5','W/W*；CATII AUTO150；GPINOP H−150/75；FAF700','六模式实际几何已有映射；无自有HL可对照','OAS程序/数据库历史版本与课件为候选，来源未确证',base('A5')+'standard-mapping.md',base('A5')+'hl-correction.md')
norm('A6','模板设施角/风参数/spiral；Hull/Envelope退化','模板常数局部对照；gift-wrap是计算实现，不能当规范规定','旧国内/Doc8168模板版本及作者近似待查',base('A6')+'standard-differences.md')
norm('A7','15°/150/.008/75/600/120/.1；无guided分支或风螺旋','三实际分支已映射；不可用规范补出未实现分支','其他版本/简化离场方法待查','recovered/round11/standard-basis-note.md',closures['A7'])
norm('A8','KK反向框架；固定MOC/梯度；Ds三维距','按既有KK评价链解释；框架方向不是规范适用性证明','旧计算方法/作者简化待查',base('A8')+'overview.md','recovered/round2-closure.md')
norm('A9','Normal/IF纵向开闭边界；末端主宽W1/2与W1；严格粗筛','2020映射保留差异；无容差/夹限补丁','作者分支实现或历史规则待查','recovered/round14/standard-basis-note.md',closures['A9'])
norm('A10','factor*300；已解析MOC不驱动该式','真实固定式与UI差异保留','历史DME弧评价方法或简化待查',base('A10')+'overview.md','recovered/round2-closure.md')
for m in ('B1','B2'):
    norm(m,'NN/KK语义；15/30候选；ATT；B2载体12000/13000','UI字段/输出已闭合；NN/KK不得强贴主副区；载体非保护宽','Doc8168不同版/作者几何选择待查','recovered/round13/standard-basis-note.md',closures[m])
norm('B3','LNAV/APV副区/HL；GP>3.2项；直线复飞','计算已恢复；评价调度缺失不等同符合规范','APV历史表/版本或简化待查',base('B3')+'standard-mapping.md',base('B3')+'hl-correction.md')
norm('B4','1852/3704固定带；15°同轴衔接；HL无GP项','不能据数值称任意RNP转弯；B3/B4 HL不同','旧RNAV-ILS/OAS方法与版本待查',base('B4')+'standard-mapping.md',base('B4')+'hl-correction.md')
norm('B5','1482；TurnEnd；选定子集Hull；评价异常赋值','真实构造/孤立评价已对照；不补导航规范/调度','旧PBN离场模型/作者简化待查',base('B5')+'standard-mapping.md')
table('standard-basis-unresolved.csv',['Module','Constant/Behavior','CodeEvidence','CurrentStandardMapping','HistoricalSourceCandidate','Status'],standards)

old_e3={'A1':'recovered/round3/tests.log','A2':'recovered/verification.md','A3':'recovered/verification.md','A4':'recovered/round9/tests.log','A5':'recovered/round8/tests.log','A6':'recovered/round4/tests.log','A7':'recovered/round2/tests.log','A8':'recovered/round2/tests.log','A9':'recovered/PriSec.verification.log','A10':'recovered/round2/tests.log','B1':'recovered/round3/tests.log','B2':'recovered/round3/tests.log','B3':'recovered/round6/tests.log','B4':'recovered/round7/tests.log','B5':'recovered/round5/tests.log'}
evidence=[]
for r in modules:
    m=r['Module']
    e3='EXISTING_RECOVERY_ONLY: '+source(old_e3[m])
    if m in ('A1','B1','B2'): e3+='; Round3 Python10共享断言；C#编译受阻；非完整边界数值移植验证'
    elif m in ('A2','A3','A9'): e3+='; Round1独立验证/兼容联合编译；Round12/14静态清单不是新增数值测试'
    else: e3+='; 原宿主/原DLL不是oracle；组内断言不独立按模块累加'
    evidence.append([m,'原件身份/PE/事件元数据: '+source('reverse-analysis/00_manifest/hashes.csv'),'处理副本/反编译身份；原保护桩非公式明文',r['PrimaryEvidence'],e3,'NOT_COMPLETED','局部规范解释/映射；实现依据待确认',r['LatestClosure']])
table('evidence-level-master.csv',['Module','E0','E1','E2','E3','E4','N','Evidence'],evidence)

membership={}
for p in json.loads((ROOT/'recovered/dynamic-test/logs/compile-files.json').read_text(encoding='utf-8')):
    membership[Path(p).relative_to(ROOT).as_posix()]=('COMPATIBILITY_GROUP_COMPILED_API25.1_NOT_STANDALONE','recovered/dynamic-test/compile-validation.md')
for n in range(4,10):
    p=ROOT/f'recovered/round{n}/test-inputs.json'
    if p.exists():
        data=json.loads(p.read_text(encoding='utf-8'))
        data=data.get('files',[]) if isinstance(data,dict) else data
        for item in data:
            path=item.get('path','').replace('\\','/')
            if path.endswith('.cs') and (ROOT/path).is_file():
                membership[path]=('RECOVERY_GROUP_COMPILED_NOT_STANDALONE',f'recovered/round{n}/compile-tests.log')
inventory=[]
for p in sorted((ROOT/'recovered').rglob('*.cs')):
    rel=p.relative_to(ROOT).as_posix()
    if rel.startswith(('recovered/round15/','recovered/final-static-baseline/')): continue
    text=p.read_text(encoding='utf-8-sig',errors='replace')
    m=next((m for m,d in dirs.items() if '/'+d+'/' in rel),'SHARED_OR_SUPPORT')
    if 'PriSec' in p.name: m='A9'
    elif 'TurnAreaForm' in p.name: m='A8'
    role='RECOVERED_IMPLEMENTATION'
    if '.Tests.cs' in p.name or rel.startswith('recovered/_csc-temp/'): role='TEST_OR_TEMP_SUPPORT'
    if '/dynamic-test/observer/' in rel: role='INDEPENDENT_OBSERVER_OR_HOST_DIAGNOSTICS'
    kind='STRUCTURED_READABLE_RECOVERY; NOT ORIGINAL SOURCE'
    if m in ('A5','A6','B3','B4','B5') or 'Mechanical recovery' in text or 'Mechanical port' in text:
        kind='MECHANICAL_WITH_TYPE_RENAMING; NOT ORIGINAL SOURCE'
    if p.name in ('DmeArc.Bodies.Recovered.cs','DmeArc.Native.Recovered.cs'):
        kind='MECHANICAL_BODY_OR_CAD_PORT; NOT ORIGINAL SOURCE'
    if m in ('B1','B2'):
        kind='DTO_AND_SCALAR_SLICE' if 'Boundaries' in p.name else 'CAD_RECORD_ADAPTER'
    elif any(s in p.name for s in ('RecoveryHost','CadWriter','TemplateCad','PbnDepartureCad','RnpApchCad')): kind='CAD_OR_CONTROL_RECORD_ADAPTER'
    elif role!='RECOVERED_IMPLEMENTATION': kind=role
    compile_state,compile_ref=membership.get(rel,('NO_PER_FILE_COMPILE_CLAIM',''))
    if m in ('B1','B2') or p.parent.name=='GeometryPrimitives':
        compile_state='ROUND3_CSHARP_COMPILE_BLOCKED; NO_STANDALONE_SUCCESS_CLAIM'
        compile_ref='recovered/round3/compile-tests.log'
    if m in ('A7','A8','A10') and not compile_ref:
        compile_state='ROUND2_GROUP_EVIDENCE; NO_STANDALONE_CLAIM';compile_ref='recovered/round2/compile-native.log'
    fixtures=old_e3.get(m,'recovered/verification.md')
    if role!='RECOVERED_IMPLEMENTATION': fixtures='recovered/dynamic-test/compile-validation.md' if 'OBSERVER' in role else fixtures
    transformations='重命名/类型替换或接口封装见同模块报告；保留旧分支，不声称逐位运行等价'
    if m in ('B1','B2'): transformations='Boundary DTO/少量scalar+writer记录；完整数值边界不在这些C#中，静态证据在source/IL'
    if kind=='CAD_OR_CONTROL_RECORD_ADAPTER': transformations='以记录/控件适配器代替Autodesk/WinForms副作用；不模拟事务/OCS/宿主事件'
    if role!='RECOVERED_IMPLEMENTATION': transformations='验证/观察辅助资产；不属于原始业务源码'
    refs=source(rel,fixtures,*( [compile_ref] if compile_ref else []))
    scope='EXISTING_GROUP_RECORD; NOT_PER_FILE_COVERAGE_CLAIM' if role=='RECOVERED_IMPLEMENTATION' else 'SUPPORT_ASSET; NO_BUSINESS_COVERAGE_CLAIM'
    inventory.append([m,rel,kind,compile_state,'AUTODESK_REFERENCES' if 'Autodesk.' in text else ('RECORD_ADAPTER_OR_SHARED_HELPER' if 'Cad' in p.name or 'RecoveryHost' in p.name else 'NO_DIRECT_AUTODESK_REFERENCE'),'HOST_DIAGNOSTICS_NOT_BUSINESS_ORACLE' if 'OBSERVER' in role else 'NO_TARGET_EXECUTION_REQUIRED_FOR_RECOVERY',fixtures,transformations,role,scope,hashlib.sha256(p.read_bytes()).hexdigest(),refs])
table('recovered-code-inventory.csv',['Module','RecoveredCs','MechanicalOrStructured','CompilesStandalone','UsesCADAdapter','UsesOriginalDLL','FixtureCoverage','KnownTransformation','AssetRole','FixtureScope','SHA256','Evidence'],inventory)

gaps=[]
for r in modules:
    m=r['Module']
    gaps.append([m,r['FinalStaticStatus'],'NONE_IDENTIFIED_IN_INDEXED_PUBLIC_CHAIN',r['BuildResidual'],'COMPLETE_DESIGNER_LAYOUT_AND_HOST_RECONSTRUCTION_LOW_PRIORITY','NOT_COMPLETED','IMPLEMENTATION_BASIS_UNRESOLVED','NO additional public business MethodDef recovery justified by final closure; E4/build/provenance next',r['LatestClosure']])
gaps.append(['AUXILIARY_COMMANDS','NOT_PUBLIC_BUSINESS_FUNCTION','NOT_AUDITED_TO_SAME_DEPTH','不据此断言所有辅助命令完整','LOW_PRIORITY_AUXILIARY_WORK','NOT_COMPLETED','OUTSIDE_15_FUNCTION_ROLLUP','exline/RCL/rectLine/NMCIRCLE/Arc2/图层/块工具属于辅助工作，不冒充航空算法断链',source('recovered/system-coverage/public-function-matrix.csv','recovered/round8/closure.md')])
table('final-gap-inventory.csv',['Module','FinalStaticStatus','SameBuildBusinessStaticGap','BuildGap','LowPriorityStaticWork','E4','StandardGap','Disposition','Evidence'],gaps)

reconciliations=[
['Round10 WsEntityFrame=local transform','WsEntityFrame是属性schema；P0AC/P0AD才是数值跑道frame',source('recovered/system-coverage/data-model-master.csv','recovered/ObstacleData/WsEntityFrame-schema.md',base('A7')+'runway-coordinate.md')],
['Round10 .rnp none evidenced','B3 P47F/P47E已有UTF8控件path:value协议；与config XML分开',source('recovered/system-coverage/data-model-master.csv',base('B3')+'persistence.md')],
['Round3 writer token/name mismatch','P086单Polyline；P087列表+Group；P089 append/optional metadata',source('recovered/round3/shared-cad-writers.csv',base('A6')+'cad-output-map.md')],
['全局无two-spiral angle的过度推论','A1/B1/B2无独立通用solver；A6 P7AF/P7C2存在；A6 P7AD直接caller=0',source(closures['A1'],base('A6')+'shared-geometry.md')],
['Round10 CAD实体概括失真','A2无Polyline；A3有3 Arc；A6无独立Arc/Circle；B1/B2非Spline；A7无独立Line；A10有Arc',source('recovered/system-coverage/cad-output-master.csv',base('A2')+'cad-output-final.csv',base('A3')+'cad-output-final.csv',base('A6')+'cad-output-map.md',closures['B1'],closures['B2'],base('A7')+'cad-output-map.md',base('A10')+'cad-output-map.md')],
['B5 evaluator identity / metadata泛化','评价体P5CD/P5D8；主writer description为空，不写WsObject；Mark Altitude是Attribute',source('recovered/system-coverage/orphan-implementations.csv',base('B5')+'obstacle-evaluation.md',base('B5')+'xdata-schema.md')],
['A5 HL泛化为DIFFERENT','A5无自有HL表/公式/消费者；B3/B4 HL独立不同',source('recovered/round14/a2-hl-cross-module.csv',base('A5')+'hl-correction.md',base('B3')+'hl-correction.md',base('B4')+'hl-correction.md')],
['Round13/14 static-tests PASS的证据边界','是生成式静态检查清单，不作为本轮或当轮新执行的数值断言；E3引用早轮日志',source('recovered/round13/static-tests.json','recovered/round14/static-tests.json','recovered/round3/tests.log','recovered/round2/tests.log')],
['静态COMPLETE与可运行源码混淆','B1/B2 C#是DTO/scalar+writer记录；完整算法审计依赖source/IL；C#编译曾受阻',source(closures['B1'],closures['B2'],'recovered/round3/compile-tests.log','recovered/B1-FlyBy/FlyBy.Boundaries.Recovered.cs')],
]
table('reconciliation-register.csv',['PriorStatementOrRisk','FinalReconciliation','Evidence'],reconciliations)

write('static-completion-definition.md',f'''
# 静态恢复完成的定义

`COMPLETE_STATIC` 表示当前冻结构建中，公开事件链、业务计算、几何/评价、适用的 CAD writer、metadata/持久化及负向功能证据，已恢复到可追踪原/处理身份、字段/调用与分支的可审计程度。不存在的功能以负向证据说明；不按帮助或规范补接。

该状态不表示原始运行等价、航空规范符合性、生产就绪或认证。也不保证恢复 C# 是完整可运行工程：B1/B2 的 Boundary C# 为 DTO/局部标量及 writer 记录，完整几何依据仍在冻结 source/IL 和分支索引。见 {link(closures['B1'],'B1 closure')}、{link(closures['B2'],'B2 closure')}。

`PARTIAL_STATIC_BUILD_LIMITED`：数学体/绘图及负向调用证据已审计，但当前构建公开调度为提示、空体或孤立链，无法作为完整公开业务链。A5/B3/B4/B5均属此类。它们不是普通“算法未反编译完”。

`PARTIAL_STATIC_OTHER_BUILD_REQUIRED`：需要其他可信构建才能确定关键已知缺口、且本轮证据必须支持该分类。当前没有模块采用此类。可以建议比较其他构建，但不能据此断言另一版本必有功能。

`NOT_PUBLIC_BUSINESS_FUNCTION`：辅助/诊断/通用工具不纳入15个航空公开功能统计。gap inventory中的辅助行不增加公开功能分母。

## 证据分层

- E0：原始程序集身份、PE/引用、事件/成员元数据及原件hash。原保护桩本身不证明明文公式。
- E1：去混淆/反编译结果，保留处理前后映射，不冒称作者源码。
- E2：IL、事件绑定、字段读写、调用图、CAD/数据库链交叉恢复。
- E3：独立恢复源码/记录适配器的既有验证；不是目标DLL运行。
- E4：原插件在匹配宿主中执行相关业务并保留输入/事件/实体等观察证据。全部模块尚未完成。
- N：规范/上下文映射与解释。推断保持独立，不升级为源码事实。

Round13/14 的生成式 static-tests PASS 清单不计作新执行的数值测试。Round3 C# 编译失败，Python10条共享恢复断言通过；不据此声称完整B1/B2数值移植通过。各轮断言、fixture文件、点数和业务案例不能相加冒充覆盖率。

## 统计

由 final-public-function-status.csv 记录重新计算：

{COUNTS}

历史RoundStatus完整保留；本轮FinalStaticStatus单列。状态适用范围为此冻结构建和已索引公开链；无indexed incoming不证明任意外部程序集/反射绝不可能调用。
''')

write('system-architecture-final.md',f'''
# 最终系统架构：恢复到的事实

## 1. 总体组织与统一模型

**No unified Procedure Model evidenced.** 现有证据支持“AutoCAD共享工作面 + 各Form的输入/表格/临时业务对象 + 共用几何/障碍物/状态helper”。没有证据显示以统一Procedure对象保存航段、设施、保护区主副区语义、前后拓扑及评价结果并自动跨窗传递。

```mermaid
flowchart TD
  UI[各公开命令与Form独立状态] --> B[各模块业务构造器或评价器]
  B --> G[共享turn / spiral / 点线 / OAS面]
  B --> W[通用CAD写出与可选metadata]
  W --> CAD[AutoCAD图面与实体数据库]
  CAD --> P[人工重拾锚点或选实体状态]
  P --> UI
  CAD --> O[Model DBPoint公共导入与parser]
  O --> E[各模块独立分类与评价]
  E --> T[Form表格与ID到原点映射]
  T --> M[Mark / Highlight]
```

图中“各模块评价”仅表示实际关系：A5/B3/B4/B5的孤立体不因此变成可达入口。见 {link('recovered/final-static-baseline/build-limitations.md','构建限制')}。

## 2. AutoCAD的角色及跨窗传递

AutoCAD保存可见几何、Model障碍物点、Group和局部状态字符串，也供设计者观察与重拾。图面不是已恢复出的统一程序拓扑数据库。A2→A7的TP/C、A3→A7的KK均重新GetPoint，不从WsCalcuLine/Group恢复前序业务对象。A3→A6/A10无直接业务reader，A10自己构造DME弧。

## 3. 哪些metadata被读

A1选实体取状态，A5 P318、B3 P483、B4 P56B通过人工GetEntity读取XData数组第二项并恢复参数/控件。缺少严格RegApp/schema校验，不能视为自动识别保护区角色。公共障碍物parser自动尝试WsEntityFrame名称，这只复用名称。A2的WsCalcuLine reader P655仅通过wrapper6AB，wrapper无indexed incoming；未证明业务自动消费者。B5主writer传空description，不写业务XData。

证据：{link(base('A2')+'evidence/WsCalcuLine-downstream.json','WsCalcuLine调用审计')}；{link(base('A5')+'xdata-schema.md','A5')}；{link(base('B3')+'xdata-schema.md','B3')}；{link(base('B4')+'xdata-schema.md','B4')}；{link(base('B5')+'xdata-schema.md','B5')}。

## 4. 障碍物公共层

P10D选择Model空间DBPoint；P12F读取原XYZ、调用者ordinal ID、可选WsEntityFrame名称或后缀回退。各Form维护ID到原DBPoint字典，再由自身分类器计算。Mark用原点与原Z写块属性，Highlight也回到原实体。RandomPoint只创建DBPoint+MText，没有统一树高合成或自动属性框架记录。B3无Take5；B4/B5在parser前截前5点，连带限制表、字典、Mark和高亮。其评价UI未调度，不能声称实际评价已覆盖这些点。

证据：{link('recovered/ObstacleData/WsEntityFrame-schema.md','属性与解析')}、{link('recovered/ObstacleData/marker.md','Mark')}、{link(base('B4')+'obstacle-evaluation.md','Take5及边界')}。

## 5. OAS公共层

A5/B4共享OasModel P411–P41E与Plane P834–P840及CAD helper。数据库loader/decoder/尺寸/RDH包装是A5 P409–40C与B4 P571–574两个实现；同schema不是同MethodDef。A5六模式与B4同轴固定宽度衔接几何不同。A5参数为四段JSON，B4旧文本格式不同；A5没有自有HL，不能用B3/B4公式填补。

证据：{link(base('A5')+'class-map.md','共享身份')}、{link(base('A5')+'persistence.md','格式')}、{link(base('A5')+'hl-correction.md','HL负向证据')}。

## 6. Turn与Wind spiral公共层

P793/P854提供turn输入与派生参数，模块只消费所需字段。A7实际用TAS等，不使用spiral构造；B3为TAS消费；B4核心无P793。A1/B1/B2以及B5、A6部分模板复用Spiral86；Holding/Base使用Spiral88。A6两spiral角度成员P7AF/P7C2真实存在，与A1标签common tangent及点到spiral P7AD不能混为一谈。

证据：{link('recovered/shared-turn-methods.md','turn')}、{link(base('A6')+'shared-geometry.md','spiral身份与调用')}、{link(closures['A7'],'A7负向闭包')}。

## 7. 共享与复制边界

B1/B2共享primitive但有独立候选/业务构造器；A7/B5共享frame/基础设施但不是同一离场类；A9/B3有相似线性副区数学而非同评价器；B3/B4 HL包含GP项和舍入差异。完整分项见 {link('recovered/final-static-baseline/shared-vs-copied-final.csv','共享/复制表')}与 {link('recovered/final-static-baseline/cross-window-data-flow.csv','跨窗流表')}。
''')

write('procedure-model-assessment.md',f'''
# Procedure Model 最终判定

**No unified Procedure Model evidenced.** 结论限定于本构建已索引的公开链、字段与持久化协议；不以名称相似或几何可以拼接代替对象模型证据。

|载体|已恢复作用|为何不能证明统一Procedure Model|
|---|---|---|
|WsCalcuLine|A2计算线Kind+JSON，10+28成员；端点重算中心/方向/长度|无已索引下游公开业务reader；不保存跨窗航段拓扑|
|WsObject|通用可选字符串XData|调用者格式不一；Group未自动携带角色；B5主链为空|
|WsEntityFrame|EntityType/Name/Properties属性schema|不是坐标frame，也不是RandomPoint统一障碍物记录|
|config.xml|各Form dotted控件状态|控件状态非设施/航段/保护区拓扑|
|.rnp|B3 FormApvEvl头+path:value控件文本|无航段schema/版本化；独立于XML config|
|OAS TXT|A5四段JSON参数；B4旧CSV式文本|两格式不能互换；参数快照不携带所选折线面角色|
|oas.db|PartA/PartB OAS系数参数源|数据库参数表不是正在设计的程序/航段实例|
|Group|Polyline ObjectId列表/绘图容器|没有已证实的统一主副区、前后段或设施语义|
|Polyline|采样边界或bulge名义轨迹|形状不等于typed业务对象；点列可几何闭合而未设Closed|

正向证据是各Form自己读取数值、临时构造模型及维护障碍物字典；负向证据是A2/A3→A7重拾、业务reader缺失及各协议不兼容。若图上有人工合并区，不能由此声称软件存在自动程序模型；本轮也未运行观察人工步骤。

证据入口：{link(base('A2')+'WsCalcuLine-schema.md','WsCalcuLine')}、{link('recovered/ObstacleData/WsEntityFrame-schema.md','属性schema')}、{link(base('B3')+'persistence.md','.rnp/config')}、{link(base('A5')+'persistence.md','A5参数')}、{link(base('B4')+'persistence.md','B4参数')}、{link(closures['A7'],'跨窗负向证据')}。
''')

write('build-limitations.md',f'''
# 当前构建的明确限制

这里的“孤立”指已建立的direct/MethodSpec调用及公开事件闭包中没有incoming/可达调度，不能扩展成排除所有反射、外部程序集或其他版本入口。

|模块|直接证据|当前公开功能边界|
|---|---|---|
|A5|P41B/P429完整面高/标签体；incoming为空|六模式绘图可达，无A5障碍物穿透/HL/最低标准公开链|
|B3|LNAV P594、APV P5EE、工厂P470及后处理孤立|LNAV绘图/导入可达；APV数值构造与评价不构成UI业务链|
|B4|P566 Evaluate消息提示；P5E0/P567/共享P41B孤立|绘图/导入可达；无端到端评价/控制障碍物归并|
|B4|绑定KML P56D空体|无区域、坐标、样式或KML输出|
|B5|P501/P50C/P50D提示分派；P5CD/P5D8数学体已恢复、无评价调度|绘图可达；没有端到端合并/排序/评价结果链|

这些模块采用 `PARTIAL_STATIC_BUILD_LIMITED`。其他可信构建比较是后续取证选择，未证明其他构建必有相关能力；本轮不补UI、不执行孤立方法。

其他已确认功能边界：A3无双设施自动cross-fix；A7无独立电台上空/导航方式guided分支或风螺旋；B3无任意左右转复飞链；B4为同轴固定宽度衔接，不是任意PBN转弯。此类“当前未实现”不等同反编译遗漏。

详细定位：{link(closures['A5'],'A5 closure')}、{link(closures['B3'],'B3 closure')}、{link(closures['B4'],'B4 closure')}、{link(closures['B5'],'B5 closure')}。相关Help/UI分类见 {link('recovered/final-static-baseline/help-ui-code-final.csv','差异表')}。
''')

write('other-build-comparison-plan.md',f'''
# A5 / B3 / B4 / B5 可信构建比较计划（不执行）

目的：确认当前构建中孤立/提示/空体是否在另一可信版本有不同公开调度。可信来源需记录提供方、完整目录、获取时间、原始SHA256；不搜索或执行未知DLL。另一版本的存在及能力均未获证明。

1. 比较Assembly名、版本、TargetFramework、PE架构、引用、资源/MVID与文件hash。MVID和token可能变化，不能仅按Pxxx位置配对；按签名、IL形态、字段与字符串建立identity映射。
2. 比较Form构造/InitializeComponent事件绑定、Checked/Validated/Click/Load等事件及handler体，确认UI可达范围。
3. 比较目标evaluation/factory的所有direct/MethodSpec incoming、字段来源与结果消费者；区分消息提示、体替换和真实端到端处理。反射/外部入口若有新增证据，单列。
4. 比较config、Help、控件可见/启用状态、数据库及参数文件格式；只记录差异，不以帮助宣称覆盖代码。

|模块|优先配对链|应保存的判断证据|
|---|---|---|
|A5|六模式事件/P41B/P429|是否新增Screen/eval/穿透/最低标准调用；是否仍只是面高体|
|B3|P594/P5EE/P470及后处理|LNAV/APV工厂和评价是否接入公开事件；结果如何入表|
|B4|P566/P5E0/P567/P41B/P56D|Evaluate是否实际调度；KML是否仍空；Take5是否改变|
|B5|P501/P50C/P50D/P5CD/P5D8|提示是否变为评价；多候选如何归并排序；Take5是否改变|

预期产物：两原件hash、成员映射、事件diff、调用diff、配置/帮助diff与独立结论。保持当前基线冻结；比较发现不能回写为当前构建事实。

原始缺口定位：{link('recovered/final-static-baseline/build-limitations.md','构建限制')}。本轮未获取新构建，也未安排执行。
''')

write('e4-validation-plan.md',f'''
# E4 原插件验证计划（仅计划）

## 当前状态和宿主条件

15个航空功能的E4业务验证均 **NOT_COMPLETED**。Round1曾有Observer初始化、映射目标和空图/命令事件，但RCL不可用及输入干扰不构成业务验证。后续轮为恢复源码E3与静态审计。现有AutoCAD2026/API25.1兼容编译不能替代匹配API23.1原宿主。

启动条件：匹配Autodesk API **23.1** 的宿主及原依赖解析；兼容 **.NET Framework 4.8**；核对PE x86/AnyCPU与宿主位宽，AnyCPU不保证所有native依赖兼容；核对System.Data.SQLite托管/native位宽和版本；保持原WsSymbol、块、config、oas.db及资源相对路径。记录OS/区域设置、程序集hash、引用版本与工作目录。优先复制到独立测试目录，新建独立图；不得改原件或绕过信任设置。

## Priority 1：可能改变业务理解

|试验|输入/比较|必须记录|结论边界|
|---|---|---|---|
|事件时序|Load/config/Validated/CheckedChanged及A2 TabIndexChanged；A3 Leave|前后控件值、事件序列、方法身份、异常|确定真正先后覆盖，不以记录adapter推断WinForms行为|
|取消行为|A2各链第1/2次Esc；A7 DER/THR取消；A6 Envelope取消/空选择|PromptStatus、返回值、已有/新增实体及事务|区分Origin哨兵与真实取消；不据静态差异先修复|
|metadata持久化|A2 Line两事务、A5/B3/B4子线payload、A7 Circle Radius、B5空description|保存重开DWG前后TypedValue、RegApp、entity handle、异常与数量|确认实际写入/失败原子性；不补schema|
|Group/XData宿主行为|空列表/单列表/多列表；Undo/失败路径|Group成员ObjectId、字典/实体状态、XData/OCS|恢复记录器不能模拟宿主事务和组字典|
|另一可信构建的orphan UI|仅在完成静态比较并获后续执行授权后|事件→评价→结果消费完整链|不主动调用当前孤立体冒充公开能力|

## Priority 2：验证静态几何

- A1：single/double/triple人工锚点、左/右、Polyline/Spline、切线checkbox列表；测量输出点序/端点，不预设通用公切线。
- B1：60/90/120附近、SW1≠SW2、KK单Polyline与NN Group；B2：ATT=0和非零、15°候选、12000/13000载体。保存名义bulge及四保护点列。
- A7：三模式阶段实体/镜像/外圆及Radius；障碍物边界与二检覆盖同一行。保留TP/KK/C人工输入。
- A3：DME三Arc、KK早晚Line、顶空Circle；检查未指定/指定距离及取消。
- A8/A9/A10：ID→原点Mark/Altitude与高亮；A9 Normal/IF端点；A10 factor*300。B3/B4/B5先确认仅导入链，放入第6个高障碍物观察Take5差异，不宣称孤立评价已运行。

## Priority 3：宿主显示细节

默认图层/颜色/线型、布局/focus/界面恢复、文本外观与OCS显示。未显式set不能预填具体默认值；这类试验优先级低于业务时序与几何。

## 证据包与判定方法

每个实验保存：case ID、适用构建/环境hash、输入值与精确拾点、动作和取消位置、Observer版本hash、事件记录、原始JSON/DXF属性、前后DWG副本、截图、错误日志。以静态预测对照实际差异；宿主证据只升级该实验实际观察到的逻辑，未测分支保持未验证。禁止把E3 fixture点数计为E4样本。

顺序建议：先完成环境匹配与少量Priority1实验，再决定是否扩大Priority2。当前值得做的是有条件的小规模E4；现有2026环境不足以直接宣称原宿主等价。

既有候选：{link('recovered/round13/runtime-experiment-candidates.csv','Round13候选')}；{link('recovered/dynamic-test/compile-validation.md','Round1编译边界')}；{link('recovered/round1-closure.md','Round1运行限制')}。本轮没有启动宿主或执行目标DLL。
''')

function_map='\n'.join('|'+r['Module']+'|'+r['Command']+'|'+r['FinalStaticStatus']+'|'+r['PrimaryPurpose']+'|' for r in modules)
closure_links='\n'.join('- '+r['Module']+'：'+link(r['LatestClosure'],r['Module']+'最新closure')+'；历史 '+r['HistoricalRound']+' = `'+r['HistoricalStatus']+'`。' for r in modules)
write('executive-summary.md',f'''
# 最终静态恢复基线：项目阶段摘要

## 恢复范围与结果

本轮将WindSpiral2026当前冻结构建的15个航空公开功能及Round1–14成果总装为一套静态证据基线。状态按各模块最新closure核对并从最终CSV重新统计：

{COUNTS}

静态完成模块：**{complete}**。受当前构建限制模块：**{limited}**，其数学/几何体已恢复，公开评价调度孤立、提示或空体，不能补接后冒称原功能。

历史轮次状态原样冻结；Round11–14的静态升级独立记录。COMPLETE_STATIC表示当前构建代码行为已达到可审计程度，不代表原插件运行等价、规范符合性、生产就绪或认证。

## 系统真实架构

未发现统一Procedure Model。软件依赖AutoCAD图面、各窗口独立控件和临时对象，复用turn/spiral/点线/OAS及障碍物公共层。跨窗口主要依赖人工重拾与参数回填。Group/Polyline和状态XData不能直接视为程序/保护区拓扑对象。

共享组件与完整业务类需分开：A7不使用风螺旋，B5使用；A5/B4共享OAS底层而复制loader；A9/B3是独立评价器；B3/B4 HL公式不同。新基线已对照后续证据记录Round10等历史总表的冲突，不修改旧文件。

## 还缺什么

所有模块的原插件业务E4验证均未完成；仍需匹配API23.1宿主、原依赖与资源条件。恢复C#并非作者原源码或完整可运行产品。完整Designer/宿主细节、历史规范来源及当前构建缺失公开能力分别列账。AC-97-FS-005/民航规〔2020〕12号为对照基线，未按规范改写代码。

对已索引15功能，**没有已识别的高价值同构建静态业务恢复工作剩余**；依据为最终gap inventory与最新closure。辅助CAD命令深挖仍可作为低优先级工作，不能列作航空算法断链。

## 下一步顺序

1. 冻结并使用本静态恢复基线。
2. 在API23.1匹配环境开展少量Priority1 E4，先查事件/取消/Group与metadata，再决定几何实验规模。值得有条件投入，当前2026兼容编译不能替代。
3. 对A5/B3/B4/B5做可信构建比较，前提是未来获得可信材料；不保证另一个版本有缺失功能。

历史规范来源调查作为独立研究线。本轮到此停止，未执行上述后续工作。

入口：{link('recovered/final-static-baseline/module-master.csv','模块总表')}、{link('recovered/final-static-baseline/static-reconstruction-report.md','技术总报告')}、{link('recovered/final-static-baseline/final-gap-inventory.csv','最终缺口账')}、{link('recovered/round15/integrity-report.json','完整性结果')}。
''')

write('static-reconstruction-report.md',f'''
# WindSpiral2026 最终静态恢复技术报告

Round15 / Final Static Reconstruction Baseline。范围为当前冻结构建、15航空公开命令及既有Round1–14证据。本报告是技术总装，不是新业务逆向、替代软件设计或论文。

## 1. 研究对象与证据边界

材料覆盖原DLL/config/oas.db/DWG/Help、WsTools-master、reverse-analysis及旧recovered成果。冻结快照按实际全工作区文件建立；路径、字节与SHA256保存在 {link('recovered/round15/frozen-inputs.json','本轮冻结清单')}，原件身份另见 {link('reverse-analysis/00_manifest/hashes.csv','原件hash清单')}。旧轮自哈希记录的不可自洽问题在本轮preflight说明，当前旧清单文件的实际hash已冻结。

E0是原身份/元数据；E1是处理结果；E2是IL/字段/调用恢复；E3是独立恢复源码验证；E4是原插件业务运行；N是规范解释。它们不能互相冒充。Pxxx为处理后MethodDef简写，原token/RVA以模块映射为准；原始保护桩不等于明文业务源码。负向incoming结论限定于已索引direct/MethodSpec与公开事件闭包，不排除未知外部/反射调用。

未执行目标DLL、NETLOAD或AutoCAD；没有恢复新MethodDef、修改旧成果、规范纠错或补接orphan UI。Misc压缩包和课件保留在材料基线；其既有来源线索不升级为公式已确证的历史来源，本轮不扩展调查。

## 2. 软件功能地图与状态

|模块|公开命令|FinalStaticStatus|用途|
|---|---|---|---|
{function_map}

按表重新统计：

{COUNTS}

完整定义见 {link('recovered/final-static-baseline/static-completion-definition.md','静态完成定义')}。历史PARTIALLY ACCEPTED不被新状态覆盖。A8/A10虽在Round2已有类范围静态链闭合，Round2整体仍PARTIALLY ACCEPTED。本轮未把E4/Designer缺口误写为业务公式未恢复。

## 3. 传统程序与基础模块

### A1风螺旋

单/双/三链依赖手工锚点；第三起点不是第二螺旋终点自动推导。风项q随角度线性累计，DirectionSign控制左右。common tangent标签对应点列/候选组合，没有从A1链恢复到独立通用两spiral solver。该结论不否认A6已有P7AF/P7C2角度成员。实际输出可为Polyline或4阶Spline与可选基圆；退化NaN/Infinity等保留。

### A2基础计算

六计算链、单位、取消差异、异常事件和WsCalcuLine已闭合。NPA一个seconds字段默认18，C默认时间6和风56；不拆分为规范时间段。PA保留HLcor=0哨兵、负距离及舍入行为；离场5m及梯度按代码记录。Line实体与XData两事务，不是Polyline输出。

### A3/A4定位与设施

A3为单台S/方向Q，包含设施精度、KK早晚Line、DME三Arc、顶空Circle及Track辅助；没有双台自动cross-fix。A4只有VOR/NDB，内外半宽分界与15°无限线交点替换末端，写5/7条Polyline+Group，不是障碍物评价器。数值角色/适用阶段按代码和既有映射保留。

### A5/A6精密进近与模板

A5六绘图模式及参数/数据库/FAF/FAP、W/W*、CAD和文本持久化闭合；P41B/P429面高体孤立，无A5自有HL/最低标准链。A6 Holding/Base/45/80/XE/YE/全向含Spiral86/88、模板特定连接与gift-wrap Hull；名义曲线为bulge Polyline，采样保护为Polyline/Group，无独立CAD Arc/Circle。绑定Envelope基于人工选择/Hull，不是Region Union。

### A7/A8/A9/A10离场与评价

A7定高/定点/全向三独立构造和评价链可达；直线边属于这些模式。TP/KK/C需重拾，没有导航方式/电台上空独立分支、风螺旋或CAD布尔裁剪。全向Radius为外Circle的WsObject字符串。A8为KK反向局部frame评价，无保护区writer。A9读取数值S/E/宽度/MOC；Normal纵向开区间、IF闭区间且主区末宽差异，显示负localXY并保留原Z；无Polyline构区。A10自己构造DME弧/扇区并评价，实际MOC=factor*300，不自动延续FAF/IF直线。

## 4. PBN模块

B1 FlyBy与B2 FlyOver-DF均静态完成。三点P1/P2/P3用于来去向和中点，不自动建立完整航段对象。ATT与独立宽度输入、角度候选、四保护线、名义bulge Polyline及metadata路径已闭合；B2 ATT=0无特判，12000/13000为载体长度。NN/KK控件映射已闭合，但规范主副区含义未强制命名。它们没有障碍物评价入口。

B3为LNAV绘图及APV/评价孤立体；无Take5，复飞为直线扩张，无任意左右转/KK/C链。B4为OAS和同轴固定宽度PBN衔接，未调用spiral/P793核心，不等于任意PBN转弯；Evaluate提示、KML空体。B5定高/FlyOver构造使用Spiral86、选择子集Hull、TurnEnd后续区；P5CD/P5D8评价体完整但未由UI调度。B4/B5导入前5点的截取不是保护区筛选。

## 5. 共享几何与计算基础

共享P793/P854不代表共享其所有结果或完整业务算法。Spiral86与Spiral88有不同成员/调用者；P7AD点到spiral迭代与P7AF/P7C2两spiral角度不同。P0AC/P0AD是数值跑道frame；WsEntityFrame是属性记录。点/线/Plane、列表变换与P086/P087/P089共享CAD writer构成基础层。

A5/B4 OasModel/Plane同MethodDef，DB loader复制；B1/B2业务模式复制/独立；A7/B5仅业务相似和底层共享；A9/B3线性副区数学相似但评价器不同；B3/B4 HL独立。详见 {link('recovered/final-static-baseline/shared-components-final.csv','共享组件')}、{link('recovered/final-static-baseline/shared-vs-copied-final.csv','共享与复制')}。

## 6. CAD交互与数据模型

**No unified Procedure Model evidenced.** Form状态、参数对象、CAD点列、实体属性和数据库系数各有用途。WsObject没有统一区角色schema；WsCalcuLine无可达下游业务reader；Group只存成员ID；config与.rnp序列化控件而非航段。A5/B4 OAS参数格式不能互换。

CAD表区分实际写出、内存几何、只读DBPoint及Mark块；未显式设置的Layer/Color/Linetype记NOT_EXPLICIT_IN_REVIEWED_CHAIN，不能据此填宿主默认值。人工矩阵同时记录对象意义、缺少的关联、进入哪个计算和潜在可推导范围；自动化可能性不记为旧软件实际功能。未运行观察到手工裁剪，只能说代码边界外需人工判断，不能声称已观察到具体人工操作。

见 {link('recovered/final-static-baseline/procedure-model-assessment.md','模型评估')}、{link('recovered/final-static-baseline/cad-entity-master.csv','CAD实体表')}、{link('recovered/final-static-baseline/manual-interaction-final.csv','人工交互矩阵')}。

## 7. 障碍物评价体系

公共导入限定Model DBPoint，parser原XYZ与caller ordinal ID，名称可选WsEntityFrame回读。没有统一树高相加，RandomPoint不自动写属性框架。评价器各自负责局部frame、分类、MOC/OCA和显示。Mark从表ID回查原点并写原Z，不写计算OCA；A8额外Name，A10块名Obst。B3不截5点，B4/B5截取影响表/字典/Mark/Highlight；孤立评价体不因导入成功而变可达。

总表：{link('recovered/final-static-baseline/obstacle-system-final.csv','障碍物链')}。

## 8. 跨模块与保护区衔接

实际衔接分为shared vertex、line intersection、line carrier、candidate comparison、Hull、point-list concatenation及manual repick。业务内部部分连接已编码；跨窗并无统一拓扑接续。A2/A3→A7人工重拾；A3→A6/A10无业务调用；A5/B4共享层不自动传参数；A1/B1/B2共享primitive但无程序对象交接。A7明确无IntersectWith/Offset/Hull等链，不能因画面相接称“自动连接”。

见 {link('recovered/final-static-baseline/cross-window-data-flow.csv','跨窗数据流')}、{link('recovered/final-static-baseline/protection-connection-final.csv','衔接分类')}、{link('recovered/final-static-baseline/metadata-master.csv','metadata表')}。

## 9. 当前构建缺失与证据纠偏

A5/B3/B4/B5归PARTIAL_STATIC_BUILD_LIMITED：绘图或数学体已恢复，公开评价调度缺失；B4 KML明确空体。没有把此缺口变成待补数学算法，也没有推测作者意图或另一版本能力。Round10过时状态由新表更新，原表冻结。WsEntityFrame/.rnp/CAD writer token/实体种类/B5评价器/A5 HL等冲突逐项留证。

见 {link('recovered/final-static-baseline/build-limitations.md','构建限制')}、{link('recovered/final-static-baseline/help-ui-code-final.csv','Help/UI/Code')}、{link('recovered/final-static-baseline/reconciliation-register.csv','冲突校正登记')}。

## 10. 规范差异与实现依据

对照基线AC-97-FS-005 / 民航规〔2020〕12号。映射从已恢复行为出发；局部数值匹配不能证明适用阶段和全流程符合性。A1风与turn常数、A2时间/风/5m、A3精度/顶空/DME、A6模板、A7常数、B1/B2 NN/KK及候选常数、APV/OAS历史表均有未确证来源。其他Doc8168版、旧国内规范和作者简化仅为研究候选。

见 {link('recovered/final-static-baseline/standard-basis-unresolved.csv','依据待确认总表')}。本轮未新开展历史规范研究，也未修正代码使其符合规范。

## 11. 源码资产与运行验证缺口

恢复代码不是原始源代码。机械切片、结构化读本、DTO、CAD/控件记录器、测试/观察工具分别标识，hash与编译依据见 {link('recovered/final-static-baseline/recovered-code-inventory.csv','代码资产盘点')}。联合/兼容编译不是每文件独立编译，更不是原插件运行；B1/B2完整数值边界不在其DTO中。Round3编译受阻，Python10共享断言通过；Round13/14生成式PASS清单不作新增数值运行。

已有E3按来源引用，不跨组重复累加，也不把56545点/不变量断言视为56545业务案例。Round5零梯度几何有1次旧行为超时；保留验证限制。E4均未完成，Round1 Observer初始化/空图记录不升级为业务运行。

匹配API23.1/.NET4.8及架构、SQLite、资源路径等前提见 {link('recovered/final-static-baseline/e4-validation-plan.md','E4计划')}。本轮没有以AutoCAD2026代替该条件。

## 12. 剩余同构建静态工作与结论

**Is there any high-value same-build static recovery work remaining? No — within the indexed 15 aviation public functions and the audited current build.**

依据：COMPLETE_STATIC各模块的公开链/负向证据已闭合；四个受限模块缺少的是已证实的公开调度/空体，继续同构建取证未识别到可恢复的新业务体；其余为E4、低价值Designer/宿主重建或独立规范研究。逐模块 disposition 见 {link('recovered/final-static-baseline/final-gap-inventory.csv','gap inventory')}。此判断不涵盖所有辅助CAD命令或未知外部扩展。

下一步只排序：冻结基线 → 匹配API23.1的小规模Priority1 E4 → A5/B3/B4/B5可信构建比较；历史规范依据为独立研究线。本轮不执行后续，等待用户选择。

## 13. 模块最新审计入口

{closure_links}
''')

# Add exact indexed evidence locations without recovering any new MethodDef.
for m in dirs:
    p=ROOT/base(m)/'evidence'
    if p.is_dir():
        for f in p.rglob('*'):
            if f.is_file() and (f.suffix in ('.il','.json','.csv') or f.name.endswith('.source.txt')):
                source(f.relative_to(ROOT).as_posix())
for rel in ('recovered/round13/build_reports.py','recovered/round14/build_reports.py','reverse-analysis/04_type-map/raw/methods.csv','reverse-analysis/04_type-map/methods-only/methods.csv','reverse-analysis/04_type-map/raw/commands.csv','reverse-analysis/00_manifest/materials/archives.json'):
    source(rel)

# Every indexed source is linked to a frozen SHA256; no source is copied or rewritten.
frozen=json.loads((ROUND/'frozen-inputs.json').read_text(encoding='utf-8'))
by_path={x['path']:x for x in frozen['files']}
with (ROUND/'evidence-index.csv').open('w',encoding='utf-8-sig',newline='') as f:
    w=csv.writer(f);w.writerow(['Path','EvidenceKind','SHA256','Size','FrozenInput'])
    for rel in sorted(SOURCES):
        if rel.startswith('recovered/final-static-baseline/') or rel.startswith('recovered/round15/'):
            continue
        assert rel in by_path,rel
        row=by_path[rel]
        kind='E2_INDEX_OR_REPORT'
        if '00_manifest' in rel or '/raw/' in rel: kind='E0_IDENTITY_OR_MATERIAL_INDEX'
        elif rel.endswith('.il') or '/methods-only/' in rel: kind='E1_E2_PROCESSED_EVIDENCE'
        elif rel.endswith('.cs'): kind='RECOVERY_OR_AUDIT_SOURCE_NOT_ORIGINAL'
        elif rel.endswith('tests.log') or 'verification' in rel: kind='E3_EXISTING_RECORD_NOT_NEW_RUN'
        elif 'standard' in rel: kind='N_EXISTING_MAPPING'
        w.writerow([rel,kind,row['sha256'],row['size'],'YES'])
print(json.dumps({'assembled_modules':len(modules),'status_counts':dict(counts),'cs_assets':len(inventory),'indexed_sources':sum(1 for p in SOURCES if p in by_path),'output_files':len(list(OUT.iterdir()))},ensure_ascii=False))
