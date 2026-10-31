# Round 8 Closure — A5 Precision Approach / OAS

**Round 8: PARTIALLY ACCEPTED (static recovery)**，2026-10-28。

Round 1–7及原件冻结；只写本轮两目录。六模式、DB关系、W/W*、FAF/FAP、CAD、文件及B4比较已静态闭合。P41B/P429完整但不可达，触发用户指定部分验收条件；不补接、不扩模块。无原插件/AutoCAD/WsOasPara执行。

## 26项逐条答复

|序号|问题|答复|证据报告|
|---|---|---|---|
|1|A5是绘图器还是评价器？|drawing-oriented；无可达障碍物/HL/最低标准入口，P41B/P429孤立。|[报告](../A5-PrecisionApproach/overview.md)|
|2|六模式分别什么类？|GPINOP _0089_0096；PAOAS L/R _008A_0097；OAS _008A_0093；FAF _008A_0099；FAP _008A_009B。|[报告](../A5-PrecisionApproach/class-map.md)|
|3|是否统一OAS geometry engine？|基础五面/交点共享；另有多种私有几何类，不是完整统一六模式引擎。|[报告](../A5-PrecisionApproach/class-map.md)|
|4|是否直接查oas.db？|是，P30A→A5 P409；PartA/PartB参数化ID查询。|[报告](../A5-PrecisionApproach/oas-parameter-model.md)|
|5|与B4同loader？|否；A5 P409/P40A与B4 P571/P572是独立复制MethodDef；同schema/key/decoder，无插值。|[报告](../A5-PrecisionApproach/oas-parameter-model.md)|
|6|W/W*如何选择？|CATI/II用W；AUTO组合W+W*，不是替换W；PAOAS不读W*。|[报告](../A5-PrecisionApproach/w-wstar.md)|
|7|CAT II AUTO实现什么？|mode2数据库key、150m cap、W*/W与W*/X交点及两段W轮廓，8条；无实际评价调度。|[报告](../A5-PrecisionApproach/w-wstar.md)|
|8|GP INOP真实几何？|当前OAS交点+fix/IF+H−150/75及镜像投影29条；不强制3°或重查CATI，P3A7延伸不可达。|[报告](../A5-PrecisionApproach/gp-inop.md)|
|9|PAOAS Left/Right是什么？|共享WXYZ+P1/P2的0/300/600复合轮廓；Y镜像各7条，共用中线；非独立writer。|[报告](../A5-PrecisionApproach/paoas.md)|
|10|普通OAS输出？|Y±、Z跨线、中线、W跨线、X±；AUTO W分2条，7/8条二维折线。|[报告](../A5-PrecisionApproach/oas-cad.md)|
|11|PA with FAP怎样构造？|名义H/tanGP、追加IF长度；H−150面交点截断与IF夹限；11列表并接共享尾部。|[报告](../A5-PrecisionApproach/pa-with-fap.md)|
|12|PA with FAF怎样构造？|共用名义fix，early.x+T，三点拟合15%下降面求latest，截W/X并接IF/尾部；12列表。|[报告](../A5-PrecisionApproach/pa-with-faf.md)|
|13|FAF/FAP是否两个不同角色？|不同构造类/分支；共用一个名义点及高度控件。FafFix是容差700，不是高度；FAF900为绝对标高。|[报告](../A5-PrecisionApproach/faf-fap-mapping.md)|
|14|A5 HL公式？|未发现自有HL表、公式、控件或消费者。|[报告](../A5-PrecisionApproach/hl-correction.md)|
|15|与B3/B4哪个相同？|均无可等同A5公式；B3含GP项，B4不含；不能移植补齐。|[报告](../A5-PrecisionApproach/hl-correction.md)|
|16|有OCA/OCH/DA/DH evaluator？|无A5可达链；P41B/P429只面高/标签，不算穿透或最低标准。|[报告](../A5-PrecisionApproach/minima.md)|
|17|六模式创建什么实体？|一个Group+每点列一条2DPolyline；样本29/7/7/7(8)/12/11，按列表顺序。|[报告](../A5-PrecisionApproach/cad-output-map.md)|
|18|有3D实体？|没有；内存三维点经清Z与Point2d输出二维投影，无Surface/Face。|[报告](../A5-PrecisionApproach/cad-output-map.md)|
|19|写哪些XData？|每子Polyline 1001 WsObject + 1000完整P319参数文本；Group不写。|[报告](../A5-PrecisionApproach/xdata-schema.md)|
|20|有surface business label？|无独立Kind/面名/高程标签，不能从参数快照断定所选线具体面。|[报告](../A5-PrecisionApproach/xdata-schema.md)|
|21|OAS TXT完整格式？|RUNWAY/APPROACH/PAOAS/OAS四段JSON以竖线拼接，.json/.txt UTF8；Ws大小写敏感，非旧CSV。|[报告](../A5-PrecisionApproach/oas-txt-format.md)|
|22|config与TXT什么关系？|config用FormPA通用dotted控件状态；便携文件为四段参数快照，不是同协议。|[报告](../A5-PrecisionApproach/persistence.md)|
|23|是否直接调用WsOasPara.exe？|No direct process invocation evidence found. P395外部Start不从A5可达。|[报告](../A5-PrecisionApproach/persistence.md)|
|24|真正共享哪些MethodDef？|P411–P41E OasModel、P834–P840 Plane、P087/P089 writer及点线/变换/frame/config公共helper；P41B虽共享但orphan。|[报告](../A5-PrecisionApproach/class-map.md)|
|25|哪些loader/geometry复制？|A5 P409–P40C vs B4 P571–P574 loader/decoder/尺寸/RDH复制；B4专用WXYZ几何另复制公共轮廓再加同轴带，A5不构造。|[报告](../A5-PrecisionApproach/class-map.md)|
|26|P41B从A5可达？|否；全局direct/MethodSpec incoming空，A5事件闭包不含；P429同样不可达。|[报告](../A5-PrecisionApproach/obstacle-evaluation.md)|

## 验收门槛

|门槛|静态结论|保留限制|
|---|---|---|
|six mode dispatch|完整恢复优先级及UI gate|未模拟WinForms宿主事件时序|
|database relationship|同schema/复制loader，直接查库链闭合|27行fixture，非全表全输入穷举|
|W/W* / AUTO|mode2组合、150m及8条CAD闭合|不可达P41B不算UI评价|
|FAF/FAP|名义点、T/L/H、截断/夹限和writer闭合|未Add局部三角形、简化站距保留|
|CAD writer|2D Polyline/Group/完整XData静态闭合|无宿主图元实测|
|TXT/config|独立协议、full/OAS-only、异常部分写入闭合|UI自动重算时序未运行|
|evaluation reachability|无direct/MethodSpec incoming，孤立方法完整恢复|按用户规则必须PARTIALLY ACCEPTED|
|B4/A5关系|同MethodDef/复制/A5-only/B4-only分列|不修改冻结Round7比较|
|fixtures|全部分层通过|E3独立源码，不是E4原运行|

## 验证与完整性

独立源码2980条：database 406；cross-module 810；formula 437；surface 311；geometry 975；mode-dispatch 15；serialization 14；degenerate 12。另event/reachability静态32条。

[完整验证边界](../A5-PrecisionApproach/verification.md)、[tests.log](tests.log)、[静态检查](static-tests.json)、[fixture索引](fixture-index.json)、[冻结核验](integrity-report.json)、[本轮清单](output-manifest.json)。5811项冻结基线最终逐文件核对；实际结果以integrity-report.json为准。

## 未完整逆向的公开功能清单（仅列后续，不执行）

排序先看业务价值，再看已恢复依赖，最后看剩余未知量。以下状态引用既有冻结成果，不重新验收旧轮，也不因目录存在称完整。

|顺位|公开功能/缺口|业务价值|依赖已恢复程度|剩余未知量/既有状态|
|---|---|---|---|---|
|1|A4 Y04_导航设备保护区|高：尚缺完整导航设施保护链|点线/坐标/CAD/容差基础已恢复|无独立完整恢复包；需先确认真实设施分支与评价范围，高未知|
|2|A7 Y07传统离场的跨窗口业务覆盖与验证|高：直线/定高/定点/全向核心|Round2静态链、评价、CAD已交付|Round2 PARTIALLY；导航方式/电台上空/人工衔接等不能仅凭现有三类推断完整，原运行与完整UI未验证|
|3|A3 Y03定位容差与保护区衔接|高：多个程序基础输入|Round1单台/KK早晚/顶空、公共几何已恢复|PARTIALLY；交叉定位按钮仅一台一方向，不自动两设施求交；完整designer/config及运行未知|
|4|A1/B1/B2 风螺旋、FlyBy、FlyOver DF|高：转弯与连接|Round3 writer/顶点/NN/KK静态成果已冻结|Round3 PARTIALLY；当时兼容编译/分支运行数值缺口及宿主属性，须按新授权单独收口|
|5|B3 Y53、B5 Y55、B4 Y54、A5 Y05的不可达评价/最低标准缺口|高，但可能是原构建功能缺失|Round5–8孤立业务体、可达性及共享层已恢复|均PARTIALLY；需要其他可信构建/外部入口证据，继续同构建逆向不保证有可恢复调度，不能补接冒充恢复|
|6|A2、Y92/xInfo/ScreenData/Mark、A8/Y09主副区、A10|中高：公共数值/障碍物与专项评价|Round1/2静态切片与兼容编译已有|PARTIALLY；完整UI/config、宿主业务运行与输出等价缺口；Y09已有公共评价链不算未开始|
|7|公开CAD辅助命令 exline/RCL/rectLine/NMCIRCLE/Arc2及图层/块工具|中：设计操作便利|公共writer与旧命令入口索引已有|本轮未逐项验收；不是断言全部未恢复，先核已有报告再补缺口|

Y06/A6 Round4 = ACCEPTED (static recovery)，不列为未完整静态恢复；运行/规范批准不因此完成。命令边界依据冻结commands.csv/command-entrypoints.md；工具/诊断入口Hello/notReady/Command1/2不自动升级为航空业务模块。Misc/PANS-OAS/课件来源调查保留为早期总任务待核材料，优先级低于公开主链，当前不扩逆。

## 停止

Round 8收口。未改变原算法、未修改旧轮、未开发替代软件；不自动进入任何其他模块。
