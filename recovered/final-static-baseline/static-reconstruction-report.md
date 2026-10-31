# WindSpiral2026 最终静态恢复技术报告

Round15 / Final Static Reconstruction Baseline。范围为当前冻结构建、15航空公开命令及既有Round1–14证据。本报告是技术总装，不是新业务逆向、替代软件设计或论文。

## 1. 研究对象与证据边界

材料覆盖原DLL/config/oas.db/DWG/Help、WsTools-master、reverse-analysis及旧recovered成果。冻结快照按实际全工作区文件建立；路径、字节与SHA256保存在 [本轮冻结清单](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round15/frozen-inputs.json>)，原件身份另见 [原件hash清单](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/reverse-analysis/00_manifest/hashes.csv>)。旧轮自哈希记录的不可自洽问题在本轮preflight说明，当前旧清单文件的实际hash已冻结。

E0是原身份/元数据；E1是处理结果；E2是IL/字段/调用恢复；E3是独立恢复源码验证；E4是原插件业务运行；N是规范解释。它们不能互相冒充。Pxxx为处理后MethodDef简写，原token/RVA以模块映射为准；原始保护桩不等于明文业务源码。负向incoming结论限定于已索引direct/MethodSpec与公开事件闭包，不排除未知外部/反射调用。

未执行目标DLL、NETLOAD或AutoCAD；没有恢复新MethodDef、修改旧成果、规范纠错或补接orphan UI。Misc压缩包和课件保留在材料基线；其既有来源线索不升级为公式已确证的历史来源，本轮不扩展调查。

## 2. 软件功能地图与状态

|模块|公开命令|FinalStaticStatus|用途|
|---|---|---|---|
|A1|Y01_风螺旋|COMPLETE_STATIC|单/双/三风螺旋及名义点列绘图|
|A2|Y02_基础计算|COMPLETE_STATIC|六类基础计算与计算线|
|A3|Y03_定位容差|COMPLETE_STATIC|单设施定位容差/KK/顶空图元|
|A4|Y04_导航设备保护区|COMPLETE_STATIC|VOR/NDB保护边界绘图|
|A5|Y05_精密进近保护区|PARTIAL_STATIC_BUILD_LIMITED|六模式精密进近/OAS绘图|
|A6|Y06_传统模板|COMPLETE_STATIC|Holding/Base/45-180/80-260/XE/YE/全向模板|
|A7|Y07_离场保护区|COMPLETE_STATIC|传统离场定高/定点/全向绘图与评价|
|A8|Y08_转弯区评估|COMPLETE_STATIC|KK转弯区障碍物评价|
|A9|Y09_主副区评估|COMPLETE_STATIC|通用主副区障碍物评价|
|A10|Y10_起始进近DME弧|COMPLETE_STATIC|起始进近DME弧绘图与评价|
|B1|Y51_FlyBy|COMPLETE_STATIC|Fly-by保护边界绘图|
|B2|Y52_FlyOver|COMPLETE_STATIC|Fly-over DF保护边界绘图|
|B3|Y53_RNP_APCH|PARTIAL_STATIC_BUILD_LIMITED|RNP APCH LNAV绘图及孤立APV/评价体|
|B4|Y54_PBN_ILS|PARTIAL_STATIC_BUILD_LIMITED|OAS加同轴固定宽度PBN复飞衔接|
|B5|Y55_PBN_Departure|PARTIAL_STATIC_BUILD_LIMITED|PBN离场定高/定点FlyOver-DF绘图|

按表重新统计：

- `COMPLETE_STATIC`: 11
- `PARTIAL_STATIC_BUILD_LIMITED`: 4
- `PARTIAL_STATIC_OTHER_BUILD_REQUIRED`: 0
- `NOT_PUBLIC_BUSINESS_FUNCTION`: 0

完整定义见 [静态完成定义](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/static-completion-definition.md>)。历史PARTIALLY ACCEPTED不被新状态覆盖。A8/A10虽在Round2已有类范围静态链闭合，Round2整体仍PARTIALLY ACCEPTED。本轮未把E4/Designer缺口误写为业务公式未恢复。

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

A5/B4 OasModel/Plane同MethodDef，DB loader复制；B1/B2业务模式复制/独立；A7/B5仅业务相似和底层共享；A9/B3线性副区数学相似但评价器不同；B3/B4 HL独立。详见 [共享组件](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/shared-components-final.csv>)、[共享与复制](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/shared-vs-copied-final.csv>)。

## 6. CAD交互与数据模型

**No unified Procedure Model evidenced.** Form状态、参数对象、CAD点列、实体属性和数据库系数各有用途。WsObject没有统一区角色schema；WsCalcuLine无可达下游业务reader；Group只存成员ID；config与.rnp序列化控件而非航段。A5/B4 OAS参数格式不能互换。

CAD表区分实际写出、内存几何、只读DBPoint及Mark块；未显式设置的Layer/Color/Linetype记NOT_EXPLICIT_IN_REVIEWED_CHAIN，不能据此填宿主默认值。人工矩阵同时记录对象意义、缺少的关联、进入哪个计算和潜在可推导范围；自动化可能性不记为旧软件实际功能。未运行观察到手工裁剪，只能说代码边界外需人工判断，不能声称已观察到具体人工操作。

见 [模型评估](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/procedure-model-assessment.md>)、[CAD实体表](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/cad-entity-master.csv>)、[人工交互矩阵](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/manual-interaction-final.csv>)。

## 7. 障碍物评价体系

公共导入限定Model DBPoint，parser原XYZ与caller ordinal ID，名称可选WsEntityFrame回读。没有统一树高相加，RandomPoint不自动写属性框架。评价器各自负责局部frame、分类、MOC/OCA和显示。Mark从表ID回查原点并写原Z，不写计算OCA；A8额外Name，A10块名Obst。B3不截5点，B4/B5截取影响表/字典/Mark/Highlight；孤立评价体不因导入成功而变可达。

总表：[障碍物链](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/obstacle-system-final.csv>)。

## 8. 跨模块与保护区衔接

实际衔接分为shared vertex、line intersection、line carrier、candidate comparison、Hull、point-list concatenation及manual repick。业务内部部分连接已编码；跨窗并无统一拓扑接续。A2/A3→A7人工重拾；A3→A6/A10无业务调用；A5/B4共享层不自动传参数；A1/B1/B2共享primitive但无程序对象交接。A7明确无IntersectWith/Offset/Hull等链，不能因画面相接称“自动连接”。

见 [跨窗数据流](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/cross-window-data-flow.csv>)、[衔接分类](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/protection-connection-final.csv>)、[metadata表](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/metadata-master.csv>)。

## 9. 当前构建缺失与证据纠偏

A5/B3/B4/B5归PARTIAL_STATIC_BUILD_LIMITED：绘图或数学体已恢复，公开评价调度缺失；B4 KML明确空体。没有把此缺口变成待补数学算法，也没有推测作者意图或另一版本能力。Round10过时状态由新表更新，原表冻结。WsEntityFrame/.rnp/CAD writer token/实体种类/B5评价器/A5 HL等冲突逐项留证。

见 [构建限制](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/build-limitations.md>)、[Help/UI/Code](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/help-ui-code-final.csv>)、[冲突校正登记](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/reconciliation-register.csv>)。

## 10. 规范差异与实现依据

对照基线AC-97-FS-005 / 民航规〔2020〕12号。映射从已恢复行为出发；局部数值匹配不能证明适用阶段和全流程符合性。A1风与turn常数、A2时间/风/5m、A3精度/顶空/DME、A6模板、A7常数、B1/B2 NN/KK及候选常数、APV/OAS历史表均有未确证来源。其他Doc8168版、旧国内规范和作者简化仅为研究候选。

见 [依据待确认总表](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/standard-basis-unresolved.csv>)。本轮未新开展历史规范研究，也未修正代码使其符合规范。

## 11. 源码资产与运行验证缺口

恢复代码不是原始源代码。机械切片、结构化读本、DTO、CAD/控件记录器、测试/观察工具分别标识，hash与编译依据见 [代码资产盘点](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/recovered-code-inventory.csv>)。联合/兼容编译不是每文件独立编译，更不是原插件运行；B1/B2完整数值边界不在其DTO中。Round3编译受阻，Python10共享断言通过；Round13/14生成式PASS清单不作新增数值运行。

已有E3按来源引用，不跨组重复累加，也不把56545点/不变量断言视为56545业务案例。Round5零梯度几何有1次旧行为超时；保留验证限制。E4均未完成，Round1 Observer初始化/空图记录不升级为业务运行。

匹配API23.1/.NET4.8及架构、SQLite、资源路径等前提见 [E4计划](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/e4-validation-plan.md>)。本轮没有以AutoCAD2026代替该条件。

## 12. 剩余同构建静态工作与结论

**Is there any high-value same-build static recovery work remaining? No — within the indexed 15 aviation public functions and the audited current build.**

依据：COMPLETE_STATIC各模块的公开链/负向证据已闭合；四个受限模块缺少的是已证实的公开调度/空体，继续同构建取证未识别到可恢复的新业务体；其余为E4、低价值Designer/宿主重建或独立规范研究。逐模块 disposition 见 [gap inventory](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/final-gap-inventory.csv>)。此判断不涵盖所有辅助CAD命令或未知外部扩展。

下一步只排序：冻结基线 → 匹配API23.1的小规模Priority1 E4 → A5/B3/B4/B5可信构建比较；历史规范依据为独立研究线。本轮不执行后续，等待用户选择。

## 13. 模块最新审计入口

- A1：[A1最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/A1-WindSpiral/final-static-closure.md>)；历史 Round 3 = `PARTIALLY ACCEPTED`。
- A2：[A2最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/A2-BasicCalculation/final-static-closure.md>)；历史 Round 1 = `PARTIALLY ACCEPTED`。
- A3：[A3最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/A3-FixTolerance/final-static-closure.md>)；历史 Round 1 = `PARTIALLY ACCEPTED`。
- A4：[A4最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round9/closure.md>)；历史 Round 9 = `ACCEPTED (static recovery)`。
- A5：[A5最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round8/closure.md>)；历史 Round 8 = `PARTIALLY ACCEPTED (static recovery)`。
- A6：[A6最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round4/closure.md>)；历史 Round 4 = `ACCEPTED (static recovery)`。
- A7：[A7最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/A7-Departure/final-static-closure.md>)；历史 Round 2 = `PARTIALLY ACCEPTED`。
- A8：[A8最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round2-closure.md>)；历史 Round 2 = `PARTIALLY ACCEPTED; module class-range chain closed`。
- A9：[A9最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/A9-PriSec/final-static-closure.md>)；历史 Round 1 = `PARTIALLY ACCEPTED`。
- A10：[A10最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round2-closure.md>)；历史 Round 2 = `PARTIALLY ACCEPTED; module class-range chain closed`。
- B1：[B1最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/B1-FlyBy/final-static-closure.md>)；历史 Round 3 = `PARTIALLY ACCEPTED`。
- B2：[B2最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/B2-FlyOverDF/final-static-closure.md>)；历史 Round 3 = `PARTIALLY ACCEPTED`。
- B3：[B3最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round6/closure.md>)；历史 Round 6 = `PARTIALLY ACCEPTED`。
- B4：[B4最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round7/closure.md>)；历史 Round 7 = `PARTIALLY ACCEPTED (static recovery)`。
- B5：[B5最新closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round5/closure.md>)；历史 Round 5 = `PARTIALLY ACCEPTED`。
