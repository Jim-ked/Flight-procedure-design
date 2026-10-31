from pathlib import Path
import json,csv,hashlib,re
ROOT=Path(__file__).resolve().parents[2];O=ROOT/'recovered/round6';A=ROOT/'recovered/B3-RnpApch';E=A/'evidence'
idx=json.loads((O/'fixtures/index.json').read_text(encoding='utf-8-sig'));st=json.loads((O/'static-tests.json').read_text(encoding='utf-8'));cnt=idx['assertions'];n=len(idx['cases']);nc=len(st['assertions'])
questions=[
 ('B3实际实现哪些进近类型？','LNAV平面/MOC与带气压温度修正的APV数值面/当量高，公式特征对应Baro-VNAV；无SBAS专用模型或完整导航规范dispatch。','overview.md; standard-mapping.md'),
 ('LNAV和APV是独立类还是同类分支？','独立类_008B_009C与_008C_0097，独立记录_008A_008B与_008A_008D；不是一个大评价器。','lnav.md; apv.md'),
 ('是否统一Procedure对象？','未发现。Form与业务构造对象分开；.rnp和config按控件树保存状态。','persistence.md'),
 ('FAF/MAPt如何定义？','FAF名义d=(FafAlti−THR.Z−TCH)/tanVPA，点(d,2685)；没有独立MAPt对象或可移动MAPt输入，固定THR/444模板不能冒充任意MAPt。','lnav-fix-geometry.md; faf-fap-mapping.md'),
 ('SOC真实公式？','P48A=Round((P793.TAS+wind)*NTime/3.6+444)，默认18s，bank15；不同于A2返回式。主几何SOC站距读tbThrToSoc，需手动复制粘贴。','lnav.md; turn-parameter-usage.md'),
 ('TP如何得到？','P489独立小工具Round(100*(MEnd−MStart)/MPdg)；主几何读tbSocToTp，与ThrToSoc相加限定总距离。没有TP曲线或实际转弯构造。','field-semantics.md; missed-approach.md'),
 ('final protection如何生成？','P593固定A/B/C/D/E/END，四条Y倍率1/.5/−.5/−1的开放轨迹；评价另按自己的点/阈值分段，主副区线性宽度/MOC。','lnav-fix-geometry.md; lnav-obstacle-evaluation.md'),
 ('missed protection如何生成？','从(444,1759)向15°扩张至(−6814,3704)，固定终宽延伸到min(−总距,−6814)；SOC控制MOC下降/复飞爬升项，未实现左右转。','missed-approach.md'),
 ('LNAV obstacle公式？','P594调用自有P595：−L<x≤0、主区半宽/外宽插值，副区MOC线性减至0。Z+MOC实际写OCH字段，OCA保留0；复飞还写(SOC.X−x)*g至MDH。','lnav-obstacle-evaluation.md'),
 ('HLm/HLr/HLcor如何计算？','P5F2类别H/A/B/C/D为35/8、40/13、43/18、46/22、49/26；>900加HLr*.02*elev/300；GP>3.2加(GP−3.2)*HLr*.05，不round。孤立P482显示只做标高校正round2。','hl-correction.md'),
 ('Xz来源？','P5F1只按类别A/B−900、C−1100、D/未知−1400；不读DH/GP/机场标高校正，不读comboXz。','apv-surfaces.md; standard-mapping.md'),
 ('FAP与FAF关系？','共用FafAlti计算名义d；APV点(d,2685,FafAlti−Z1)具有垂直航径交点作用。没有分别存储LNAV FAF与APV FAP导航fix身份；代码角色确定，规范身份不可自动等同。','faf-fap-mapping.md'),
 ('APV SOC如何计算？','没有DH−HLcor或其除tan加Xz的B3链。P470不读DH/HLcor；Z面从Xz起，终止总距由ThrToSoc+SocToTp指定。','apv.md'),
 ('APV有哪些surface/area？','数值中间面、斜FAS、水平地面、Z面及横向主/副侧面；由三维控制点分段插值，无CAD Surface/Solid/Face或闭合拓扑生成器。','apv-surfaces.md'),
 ('APV obstacle如何评价？','P5EE分段→P5EF插值得面高/factor→穿透后P5F4：主区Ha=Ceiling((Z/g+x−Xz)/(cotVPA+1/g))，副区用Z−30*(1−factor)；根据分类加HL。中间候选副面有内部比较，但无全局合并。','apv-obstacle-evaluation.md'),
 ('是否直接复用A2公式方法？','不调用A2 SOC/HL/TP/C方法；TP与HL部分算术复制，round有差异；NPA SOC增加444。公共P793是同一MethodDef。','../round6/a2-b3-comparison.csv'),
 ('是否复用A9 PriSec？','没有同一MethodDef调用。自有P595与P5EF；P595纵向−L<x≤0，A9 normal两端严格、IF两端含且主区终宽不同。','../round6/a9-b3-comparison.csv'),
 ('是否复用A8 turn evaluator？','无直接业务调用；B3用自身LNAV/APV方法。','../round6/a8-b3-comparison.csv'),
 ('是否复用B5 PBN turn？','无直接业务类调用。相同的是公共frame、P793、parser/Mark及CAD层，业务入参/下游不同。','../round6/b5-b3-comparison.csv'),
 ('P793用于什么？','P48A只读取TAS用于SOC。构造器虽内部计算半径/转弯率，B3没有这些字段到C6/spiral/TP/保护区评价的消费者。','turn-parameter-usage.md'),
 ('MDist是什么？','禁用显示输出m，默认8000；独立SOC→TP估算结果，可复制，不直接作为主几何字段读取。','field-semantics.md'),
 ('MStart是什么？','独立估算器SOC起始高度m，默认100。','field-semantics.md'),
 ('MEnd是什么？','独立估算器转弯高度m，默认300。','field-semantics.md'),
 ('MPdg是什么？','独立距离估算的梯度百分数，默认2.5，进入100*(MEnd−MStart)/MPdg。','field-semantics.md'),
 ('MCG是什么？','主复飞爬升梯度输入，百分数/100成为g；LNAV MOC过渡/爬升项与APV Z面/当量高使用。不是required-gradient输出。','field-semantics.md'),
 ('SocToTp/ThrToSoc/TpAlti是什么？','tbSocToTp=SOC至TP距离，tbThrToSoc=入口至SOC距离；两个输入直接影响主几何。TpAlti转弯高度输入只校验/持久化，不进入主构造链。','field-semantics.md'),
 ('最终CAD实体？','button6绘制四条开放六顶点Polyline，之后Group入库；独立Mark插入obst BlockReference并写Altitude属性。没有B3专用Line/Arc/Circle/3D面writer。','cad-output-map.md'),
 ('哪些XData？','各Polyline 1001 WsObject+1000完整FormApvEvl控件状态文本；Group未显式写XData或Description。无WsCalcuLine/Radius/Kind/结构化RNP-APV面元数据。','xdata-schema.md'),
 ('ScreenData有Take(5)？','没有；P476的MethodSpec解析到P10D<DBPoint>，P477/P478 foreach全列表；ID映射/Mark/Highlight复用公共层。','obstacle-evaluation.md; evidence/methodspec-resolution.csv'),
 ('load/save保存什么？','UTF8.rnp为头+控件路径:value文本；config.xml另为FormApvEvl控件状态。不是统一Procedure数据模型。','persistence.md'),
 ('所有评价器UI可达？','否。P594、P5EE均全局无直接入边/解码IL引用。APV工厂P470、结果表P46F、后处理P471/P4B3也断开。可达坐标转换只展示，不评价。','event-map.md; evidence/all-incoming.json'),
 ('一键评价有完整合并链？','未实现证据；隐藏按钮为提示/空体，没有final+missed+APV的merge/max/排序/覆盖规则。未为验收补接。','event-map.md; obstacle-evaluation.md')]
assert len(questions)==32
out=['# Round 6 收口 — B3 RNP APCH','','日期：2026-10-27。状态：**PARTIALLY ACCEPTED**。仅写 recovered/B3-RnpApch 与 recovered/round6；未运行目标DLL或AutoCAD，未进入B4/A5/UAV或新增B5分析。Round 1–5保持原冻结状态。','','## 验收门槛','','|项目|恢复结论|限制|','|---|---|---|','|LNAV主链|构造/点位/主副区/MOC/复飞分支已恢复|主评价P594孤立，UI未评价|','|APV链|温度、HL、Xz、数值面、当量高已恢复|P470工厂/P5EE评价孤立；无可达APV CAD面|','|复飞|直线扩张与终止/爬升参数已恢复|没有左右转/KK′/C/风螺旋链|','|字段|MCG与M系列等真实意义已解决|DH/HL显示等未接入主业务；TpAlti仅状态|','|事件/数据|56绑定、完整入边与泛型SelectAll解析|无一键合并|','|CAD与持久化|开放折线、Group、WsObject和控件状态格式已恢复|CAD宿主动态异常/实际WinForms setter未验证|','|规范|恢复后逐项对照2020基线|HL陡角度系数、Xz修正、分层FAS等存在差异|','', '本轮不标ACCEPTED：按用户门槛，“完整evaluator但UI无调用”已成立。没有用规范补调用、修字段或加入曲面/转弯算法。缺失原DLL运行oracle是证据限制，并非单独否决静态验收的理由。','','## 32个独立问题','','|序号|问题|答案|定位|','|---|---|---|---|']
for i,(q,a,loc) in enumerate(questions,1):out.append(f'|{i}|{q}|{a}|{loc}|')
out += ['', '## 分层验证', '',f'{n}个数值/记录fixture文件；不是{n}个独立程序场景，许多是同一模型的类别/位置/边界展开。以下数量为有明确预期的断言；单纯导出点位也保留但不充作额外断言。','','|层|通过断言|覆盖与限制|','|---|---|---|']
labels={'formula':'HL/类别/标高/VPA、TAS/SOC、TP、当量Ha/OCH、最低标准','geometry':'构造控制点、四条开放轨迹、frame、CAD XY记录（不是CAD宿主）','classification':'主/副/外区、端点、final/missed分支','serialization':'扁平状态文本、截断/缺冒号/空输入、每Polyline完整XData记录','invariant':'镜像、宽度倍率、同点在两个独立业务类的结果','degenerate':'零梯度/NaN/Inf、负TP/负SOC、负FAF、HL边界、无效domain残留'}
for k in ['formula','geometry','classification','serialization','invariant','degenerate']:out.append(f'|{k}|{cnt[k]}|{labels[k]}|')
out += [f'|event/reachability|{nc}|静态元数据/IL绑定、全局引用与事件闭包、泛型解析、断开DH控件；无UI运行|','','总运行超时预算40s，本次未超时。零/负/90°路径角的构造结果另有记录，不声称每个退化角度后的全部评价都穷举。左/右转无实现，fixture不适用；LNAV类别不进入构造器，以静态字段流验证；DH 30/60/120无主工厂reader，以静态断链验证，不伪造数值影响。','','测试执行的是处理IL恢复的独立源码与冻结公共原语，**不是原DLL oracle，也不是飞行程序工程可用性验证**。详见 [verification.md](../B3-RnpApch/verification.md)、tests.log、static-tests.json。','','## 审计和复现','','原件/冻结4031个文件的初始路径、大小及SHA256保存于frozen-inputs.json；最终核验见integrity-report.json。每个输出及fixture哈希见output-manifest.json；测试源码依赖哈希见test-inputs.json。E0/E1/E2/E3/E4/N证据分级见overview，未把规范推断写成源码事实。','','复现：`indexes.py` → `annotations.py` → `supplement.py` → `reports.py` → `build.py` → `close.py` → `audit.py`。setup只初始化现有不覆盖的冻结基线；recover是最初提取器，当前审定机械源码为测试输入，不应以旧生成器覆盖审定结果。add-tests/refine/package/negative-soc为已执行的一次性补丁记录，不属于复现序列。','','## B3 → B4 可直接复用的已恢复层（仅候选，不进入B4）','','|层|可供下一轮核对的成果|边界|','|---|---|---|','|runway frame|P0AC/P0AD与逆变换|必须核对THR/DER参数顺序与绝对/相对Z|','|HL|P5F2类别表、标高校正；孤立P482显示|GP系数与2020规范有差异，不能作为已合规库移植|','|surface参数|B3的Hi/VPA/温度项、控制点/插值索引|无通用W/X/Y/Z OAS系数模型；不能当成B4算法|','|障碍物|P10D SelectAll、P12F parser、ID/Mark/Highlight|B3无Take(5)，需核对下一模块自身调度|','|CAD|P087/P089、Polyline/Point2d/Group、WsObject完整状态|开放轨迹，非闭合保护区与3D曲面|','|复飞|B3直线MOC/Z面/当量高|没有可复用的B3转弯链；不能替代B4复飞准则|','|P793|同一构造器及TAS用途证据|B3只消费TAS，其他模块用途须另核对|','','**Round 6到此停止，不自动开始B4。**']
(O/'closure.md').write_text('\n'.join(out)+'\n',encoding='utf-8')
verify=['# 分层验证与恢复偏差清单','',f'数值/记录fixture：{n}；独立源码断言：{sum(cnt.values())}；静态事件/可达性断言：{nc}。两者分开，不以大PASS掩盖业务覆盖。','', '|层|断言|','|---|---|']+[f'|{k}|{v}|' for k,v in cnt.items()]+[f'|event/reachability（静态）|{nc}|', '', '## 适用性', '', '- A/B/C/D × 标高0/900/900.001/1800 × VPA3/3.2/3.3 共48组APV构造/HL/Xz记录；SOC含3风速×3高度及独立kt开关。','- LNAV/APV主/副区/区外、纵向端点、最终/水平/复飞点位各有记录；逐项有固定预期的断言与单纯记录数量分别保存。','- 同一(1000,0,100)分别评价LNAV/APV，得到175/149，未合并；APV穿透主副区及零MCG当量高已断言。','- DH变化仅作静态不可达/无reader检查；LNAV类别不进入工厂。左右转不存在；不能凭要求补转弯fixture。','- 保存文本测试是支持控件已扁平化后的记录adapter，未加载WinForms/AutoCAD；CAD测试只断言writer输入/XY丢Z/完整XData。','- 超时40s，本次无超时；无效VPA0/−3/90记录NaN/Inf/提示，不宣称已穷举退化后所有分支。','', '## 恢复代码变换（需与原体区分）', '', '- 四个业务/记录类和两最低标准后处理保留混淆字段名及分支；IL InitLocals上提以使goto能够编译，原真/假混淆谓词按已提取值替换。','- 宿主许可静态初始化不执行；MessageBox写RecoveryMessages，Discard替代未消费求值；这些属于测试适配而非原DLL行为观察。','- P595有一个构造后即丢弃且无字段/方法消费的plane carrier，恢复测试省略该无业务消费分配；不据此声称原方法无该指令。','- RnpApchMissed及Cad文件是算术/文本/CAD输入记录适配，非完整原生事件Form，也不是新保护区设计系统。','- build.py引用冻结A6/B5的公共原语源码（包括编译所需而B3不调用的Spiral86），没有修改它们；没有引用/运行WindSpiralBasic.dll。','', '## 复核证据', '', '[fixture索引](../round6/fixtures/index.json)、[静态断言](../round6/static-tests.json)、[构建日志](../round6/tests.log)、[测试输入哈希](../round6/test-inputs.json)、[恢复方法映射](evidence/recovery-method-map.csv)。完整源/IL定位与branch/field索引可逐点复查。']
(A/'verification.md').write_text('\n'.join(verify)+'\n',encoding='utf-8')
log=(O/'tests.log').read_text(encoding='utf-8').split('\nSTATIC AUDIT')[0];(O/'tests.log').write_text(log+'\nSTATIC AUDIT\nPASS event/reachability assertions='+str(nc)+' (metadata/IL only)\n',encoding='utf-8')
plan=(O/'PLAN.md').read_text(encoding='utf-8').split('\n## 完成记录')[0];(O/'PLAN.md').write_text(plan+'\n## 完成记录\n\n步骤1–8已执行，内部核验完成；最终状态PARTIALLY ACCEPTED。评价器UI断链与数值APV面缺少CAD输出等已按门槛记录，不补实现。最终文件/hash审计由audit.py记录，正常阶段无需再确认。\n',encoding='utf-8')
print('closure: 32 questions; fixtures',n,'runtime assertions',sum(cnt.values()),'static assertions',nc)

