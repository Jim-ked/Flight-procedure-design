# WsTools / WindSpiral2026 逆向执行计划

## 2026-10-27 Round 2：A7 → A8 → A10（当前范围）

Round 1冻结为PARTIALLY ACCEPTED，产物保持原样。原目标API23.1/Framework4.8与2026宿主API25.1/CLR8差异记入`Original-host-runtime compatibility backlog`；不再反复NETLOAD原目标或修改目标来兼容。

1. 先保存Round 1产物hash，复用已恢复A2/A3/ObstacleData及方法、事件、调用、IL索引，不全DLL重枚举。
2. A7事件图先行：覆盖DER/THR/swap/坐标、三模式CAD/评价/空事件、TP/KK/C及Screen/Mark/高亮。逐项原/处理token、RVA、直接调用/CAD API，核对帮助与实际事件差异。
3. 优先A7定点转弯：两点跑道坐标与TurnEnd读写→TP/KK/C距离与双高度→构造器控制点/保护区→二次检查和评价。验收：从真实事件到实际几何/评价无断链，不能以业务预期补风螺旋。
4. A7定高/全向各自恢复几何及评价，记录分支、分区、常数、内外边界/衔接和人工操作；相似不合并。
5. A8补拾取、KK框架、Ds/MCG/MOC及全部事件，复用原评价切片；核实隐藏绘图/空按钮、A7直接共享关系。
6. A10恢复O/IF/方向点、弧向、半径/端部衔接/文字、区划/MOC/OCA及IF后直线/FAF/PriSec调用；规范限制找不到实现则明确标注。
7. 跨模块共享几何和turn/spiral调用图只列直接证据；A1/B1/B2只查询共享方法调用，不扩展其完整模块。保护区衔接及CAD交互保留专门索引。
8. 每增量保存恢复代码并编译；纯公式/几何按nominal/boundary/degenerate测试，先失败后实现，保留旧特殊值/取消/端点/Z。API25.1编译只标`ACAD2026 compatibility compile`，不作为原目标L3。
9. 内部检查后继续，不等人工常规确认。交付三模块、GeometryPrimitives、共享关系、编译/测试日志及22问；任一完整链未恢复则不得ACCEPTED。不使用完成百分比，不扩展B3/B4/B5/A5或新系统。

状态：PARTIALLY ACCEPTED（Round 2 静态恢复、独立编译和数值验证已交付；原目标业务 L3、完整 Designer/config 装配和宿主运行仍未闭合）。

## 2026-10-27 Round 3：A1 WindSpiral + B1 Fly-by + B2 Fly-over DF

Round 1/2 remain frozen as `PARTIALLY ACCEPTED`. This round does not load the original DLL or operate AutoCAD. New evidence and recovery carriers are isolated under `recovered/`.

1. A1 `_008F_0086` was recovered from processed methods-only source and call evidence: constructor, repeated angle normalization, point/base-circle/radius formulas, 1° default sampling with exact endpoint, split-list behavior and 20-step/0.01 iteration helpers.
2. P793/P854 turn parameter evidence was linked to the existing A2 port. The IL constants and formulas are recorded in `recovered/GeometryPrimitives/turn-parameter.md`; no normative correction was applied.
3. B1 and B2 are kept as separate geometry classes. Input prompts, ATT/SW/reaction/bank fields, heading and turn-angle setup, earliest/latest scalar formulas, angle branches, 15°/30° candidates and B2 12000/13000 path constants are recorded. B2 has no recovered ATT=0 equality/epsilon branch.
4. A1/B1/B2 shared direct and indirect edges are indexed in `recovered/round3/shared-turn-spiral-calls.csv` and `shared-index-summary.json`. The index separates true MethodDef sharing from copied geometry and does not promote A1 list concatenation to a tangent solver.
5. Pure carriers and fixtures are saved in `recovered/GeometryPrimitives/` and `recovered/round3/`. Python recovery fixtures pass; csc output is blocked by the sandbox and logged. No runtime validation is claimed.
6. Closure report: `recovered/round3-closure.md`. Status remains `PARTIALLY ACCEPTED` because complete B1/B2 CAD boundary writers and a public common-tangent primitive are not closed.

### Round 3 Closure Pass（2026-10-27，当前执行范围）

本次只收口 B1 CAD writer、B2 CAD writer、NN′/KK′列表语义、最终边界顶点表达式、CAD 实体顺序、Group、Text 和 XData。不得扩展到 A6、B3、B4、B5；Round 1/2/3 仍保持 `PARTIALLY ACCEPTED`。原始 DLL、数据库、配置、DWG、帮助文件和压缩包继续只读，不重新加载 DLL、不操作 AutoCAD。

1. 以反编译源、IL 和调用图恢复 `_008B._0088_008A`、`_0088_008B`、`_0088_008D`、`_008C_008F` 的实体/事务/Group/XData 行为，并与 B1/B2 writer 分支逐条对齐。
2. 为 B1/B2 每个列表保留中性名称、首尾点、中间候选表达式、15°/30°、SW1/SW2、12000/13000 和分支证据；不得把 UI 名称直接升级为规范语义。
3. NN′/KK′只在 writer 证据允许时命名。没有专用图层、Text、XData 或评价器调用的语义标记为“实现依据待确认”。
4. 追加独立 writer DTO 测试，验证实体顺序、Group 子项、metadata 分支、SW1/SW2 非对称案例、B2 固定距离和 ATT=0 的负静态结果；不把测试通过写成 AutoCAD 运行验证。
5. C# 兼容编译沿用既有 `round3/compile-tests.log` 的 sandbox 阻塞结论，不重复尝试。收口报告为 `recovered/round3-closure-final.md`；状态只有在 writer、顶点和元数据链全部有直接证据后才可改变。

### Round 2 收口增量（2026-10-27）

- A7：三模式事件适配、跑道/TP/KK/C拾取、坐标转换、评价/表格/Mark/高亮、CAD Group/Polyline/Circle/XData 路径均有恢复切片；保留原事件中的人工点选、Origin取消混用和全向入口 baseAltitude=0 行为。
- A8：KK左右点、swap、Ds三维拾取、模式空事件、高度复制、评价/表格/Mark/高亮适配已补入；静态完整类范围内未发现保护区绘图链。
- A10：O/IF/IAF 输入、数值校验、CAD绘制、评价、表格/高亮适配已补入；三弧/五offset机械转写保留，负半径仅作为构造参数记录。
- 共享与衔接：新增 `recovered/round2/shared-direct-calls.csv`、`shared-call-witnesses.json`、`cad-connection-sites.csv`、`protection-connection-index.md` 和 `GeometryPrimitives/shared-geometry-map.md`。未发现 IntersectWith/Offset/Trim/Extend/删除重建的直接调用；不能把人工图面衔接写成软件自动功能。
- 验证：`Round2.Tests.exe` 通过 105 项恢复代码断言；保存 C1–C5、控制点、DME Arc/Polyline 参数 fixtures。`Recovered.Round2.Compatibility.dll` 为 API25.1 compatibility compile，未 NETLOAD。Round1 冻结文件和原件 hash 未修改。
- 规范映射：AC-97-FS-005 / 民航规〔2020〕12号仅作对照；旧常数、简化分区、缺失限制均保留“实现依据待确认”，没有按规范补算法。

## 2026-10-27 Round 1 Closure（当前执行范围）

Round 1: PARTIALLY ACCEPTED。仅收口 A2、RandomPoint/xInfo/ScreenData/Mark（含已有 A8/A9 切片）、A3。不扩展其他保护区算法。

### Closure收尾检查

- 最新交付`recovered/round1-closure.md`及十三问；三包schema/CAD/几何链、调用/事件图、原/处理token/RVA、15条障碍物边、输入输出/人工交互/未恢复项均有审计入口。
- 19文件AUTOCAD分支API25.1兼容编译成功；非原API23.1重建，恢复DLL未NETLOAD。三处DataTable别名不改变算法。
- AutoCAD2026实际CLR8.0.12/API25.1；Observer运行成功。目标副本映像加载后RCL未知命令，无业务L3。诊断DLL仅编译未加载，未取得LoaderExceptions，不能断言兼容根因。
- EXP-00未完成目标校准；EXP-01–09未执行/blocked，EXP-10可选未执行。状态`Runtime validation blocked by host compatibility`并记录根因未确认。输入队列污染后，用户回复已停止，取消SAVEAS仍立即重开；停止CAD自动输入。桌面另存图作为隔离事件保留，不作目标输出证据。
- 原件/副本hash复核及冻结日志见`recovered/dynamic-test/logs/closure-integrity.json`；兼容编译和业务运行状态分开登记。未执行规范升级或算法修复。Round 1不具备ACCEPTED条件，保留PARTIALLY ACCEPTED。
- 内部质量检查：85原件/对应副本hash未变化；78方法切片IL齐全、15链边与方法映射一致；15必需文件和22报告链接检查通过。结果`recovered/dynamic-test/logs/closure-validation.json`。不将审计PASS当成业务ACCEPTED。

1. 复用现有方法、IL、调用和事件索引，不重新枚举整个目标 DLL。
2. 用户本轮明确授权受控 AutoCAD 2026 验证：先登记 PID/实际 CLR/API 与原始 AssemblyRef 差异；先做静态闭合和兼容编译，再按 EXP-00 至 EXP-09 顺序验证，EXP-10 可选。
3. 原始 WindSpiral2026 整目录只读复制至 recovered/dynamic-test/WindSpiral2026-runtime，保留逐文件路径/hash。运行仅用副本；绘图只用 dynamic-test/dwg/R01-* 新图。不得操作最近工程图。
4. 独立 Observer 记录实体事件与完成后快照；不能将实体结果当成 API 调用栈或 GetPoint 次数证据。原 DLL 如无法 NETLOAD，保存原始错误后停止强制兼容，继续静态/编译闭合。
5. API 23.1 原目标与 API 25.1 本机测试严格区分；恢复算法、异常行为、序列化格式不得为编译或规范升级而修改。基线仍为 AC-97-FS-005 / 民航规〔2020〕12号。
6. 交付 closure、环境、逐文件编译、实验索引/差异及三个包的 schema/CAD/几何链证据。所有缺口保留；只有三个包均满足本轮条件才 ACCEPTED。

## 2026-10-26 本轮范围覆盖旧优先顺序

按新接手说明顺序仅恢复 A2 → RandomPoint/xInfo/ScreenData/Mark → A3；之后停止扩展，不进入完整A7/A8/A10。复用已有字节基线、方法索引、解码和IL，不重做全量枚举。

1. A2：逐页校对公式/输入/事件，再追踪CAD工厂和写入helper，保存原token/RVA、等价C#与测试。验收六条输入到实体链闭环，显式区分UI默认值与硬编码。
2. 障碍物：沿生成→存储→探针→各窗口解析→评价入口→标记恢复公共函数；每个schema字段/块属性必须有写读证据，不能仅由帮助命名。保存独立恢复包。
3. A3：设备表→定位/顶空分支→边界/KK→实体；保存算法和开关组合。不能恢复的部分TODO-RE，不替旧代码设计新算法。
4. 内部验证：可编译的纯计算先写失败测试再恢复实现；CAD源码不冒称运行验证。没有CAD引用/宿主时只做静态交叉核查。原件只读，输出进入 recovered/。
5. 本轮使用L1 Direct/L2 IL/L3 Runtime/L4 Inference并另标来源；历史A–E记录不改写。帮助的L1只证明帮助内容，不能升级为代码事实。当前无L3。

工作区此前已确认非Git仓库；不为本任务创建仓库或修改WsTools。按增量技能保存恢复包和测试日志作为检查点，不以规范一致性代替行为一致性。

### 本轮内部检查记录

- 2026-10-27继续：A2六绘图事件/输入/回填、RandomPoint、公共CAD读取/插入/属性、七窗ScreenData/Mark、A8/A9障碍物事件、A3两原生几何事件均新增独立C#切片；78个方法切片审计映射保存。A9新增19项检查通过。没有原生Autodesk23.1编译或L3，完整designer/config、其他评价分支及DWG定义仍未闭环；不将本次检查视为第一轮完成。发现B4/B5前5点限制及主按钮提示，保留原行为。详见recovered/round1-native-recovery.md。

- 2026-10-27：新增A2参数序列化、六工厂、EntityFrame序列化/分片，18项测试通过；原27项回归通过。CAD写入两个原生切片已转写未编译，完整功能仍未验收。元数据名称已与反编译显示别名区分。

- 已保存recovered三个包的事件/控件/调用、原/处理token与RVA、逐行证据和独立IL；补齐A3说明及二十问。
- 数值/格式器/KK评价恢复代码编译并通过27数值断言及名称、合法JSON递归、零梯度检查；没有目标DLL或AutoCAD运行证据。
- A8 Mark Name写入阅读副本参数次序错误已通过IL dup/两次同setter调用纠正；不得当成未知重载。
- A2/A3原生事件及兼容XData移植、其他评价器分支、DWG块定义仍未完成；当前成果为部分恢复，不以生成C#或测试通过代替功能验收。后续仍限定本轮范围。

状态：用户已确认计划及补充要求，开始材料基线和静态恢复；阶段检查为内部检查，不再等待常规确认。

## 范围和约束

- 输入：工作区 WsTools-master；Downloads 中两份任务材料。
- 仅研究现行有人机飞行程序辅助设计，不修改原软件、不开发替代系统。
- 交付目录遵循任务书第 10 节。结论逐项标注 A/B/C/D/E 证据等级，并保留文件路径、方法/token 或文档定位。
- 不把帮助公式当作源码；不把反编译器生成的错误代码当作算法；不能恢复的部分明确记录覆盖缺口。
- 规范基线为工作区《航空器运行目视和仪表飞行程序设计规范》AC-97-FS-005，民航规〔2020〕12号，核实 PDF 正文标识后登记。可运行 CAD 环境尚未确认；动态验证不能实施时不得声称 C 级证据。
- 不执行原始未知 EXE/DLL；先做静态检查。需要动态加载时核实可控宿主及其影响。

## 顺序与验收

1. 材料及证据基线
   - 清点整个软件包，计算 SHA-256，保留原件副本；完整阅读说明、全部帮助源文件、配置及样例。
   - 验收：文件清单与 hash 一一对应；帮助与配置的不一致逐条入表。
2. 数据与工具条件
   - 只读提取 SQLite schema、索引、表记录数和样例；清点压缩包内容、规范/课件及 DWG 可读工具。
   - 验收：查询可复现，明确数据库事实与字段语义推断的区别。
3. 静态恢复可行性
   - 检查程序集元数据、资源、依赖和保护迹象；尝试可用反编译路径，保存工具版本、命令、日志和输出。
   - 对失败的方法继续检查 IL、异常表、资源和解密入口；不以单一反编译器失败结束调查。
   - 验收：原始/处理后程序集分离；恢复率、失败方法及后续路径明确。
4. 类型、入口和事件图
   - 建立 Form/控件/事件/方法映射、命令入口、共享组件及 CAD API 引用索引。
   - 验收：每条关系可追溯到元数据或代码，不以类名猜测业务。
5. 五条基础链（逐链交付）
   - WindSpiral、Basic Calculation、FixTolerance、Conventional Departure、FlyBy/FlyOver。
   - 每链验收：输入/单位、分支、调用、计算、几何、人工依赖及输出有证据；无法恢复处单独列出。
6. 保护区衔接和障碍物公共算法
   - 按任务书十类案例分别追踪边界构造、交点/切线/裁剪、区划及评价；追踪 XData 写入与读取。
   - 验收：区分共享实现与数值等价；公式与区域判定具有真实代码定位。
7. 扩展模块（逐模块交付）
   - Missed Approach、Primary/Secondary、DME Arc、RNP APCH、PBN-ILS、PBN Departure、传统模板。
   - 验收：与基础链复用关系和人工操作边界可追溯。
8. 规范与自动化结论
   - 对已恢复算法进行版本明确的规范对照，区分可自动化操作、设计判断及不确定项。
   - 验收：不确定条款明确待确认；报告中的恢复声明与实际证据一致；列出所有未满足的任务要求。

## 检查点

- 仅在需要执行不可控未知二进制、修改原始文件、关键歧义无法判定且显著影响方向、或关键文件缺失导致无法继续时暂停。正常阶段结束直接推进。

- 步骤 1–3 后核查材料完整性和静态恢复质量，决定哪些问题确需动态分析。
- 步骤 4–5 后核查事件调用链及离场分支覆盖，防止以文档替代代码。
- 步骤 6–8 后复核全部证据链接、交付文件和未解决事项；只有满足验收条件才声明任务完成。

## 当前已核实

- 工作区存在 WsTools-master/WindSpiral2026/WindSpiralBasic.dll、oas.db、config.xml、帮助文件、Sample 及 WsSymbol2.1.dwg。
- 实际中文目录名为“软件说明.txt”和“帮助文件”，与任务书转义名称对应。
- Misc 四个压缩包已清点并独立解包，PANS-OAS 为旧4D应用资料，模板含数值报告；与当前DLL/数据库的模型关系尚待核实。
- 根 README 已读取；其软件定位不构成算法正确性或规范符合性证明。

## 2026-10-25 静态阶段内部检查

- 材料基线：131原件及快照哈希复核通过；规范身份已核实；数据库只读导出、归档清点/解包已完成。DWG块/层/属性和部分文档差异仍未闭环。
- 静态方法恢复：原件与处理件分离；原始/处理后C#和独立IL保留；2,107字符串回环通过，388布尔原字节验证通过。没有执行目标程序集。
- 类型/入口/事件：元数据、34命令、999控件Name、544事件候选、47,867调用位置已索引；非完整运行图，MethodSpec和间接边仍需补齐。
- 五条链：已有逐链审计索引，均不标记完成。传统离场优先推进，已保存拾取数据流、单位变换、业务类构造与二次检查入参证据；继续到业务类及共享几何，不在Form边界止步。
- 第一阶段报告见 README.md；缺口见12_unknowns。正常检查点不等待再次确认。

## 用户补充要求（执行约束）

1. 规范映射从真实代码行为出发，不能为符合规范而修正或解释代码。其他版本 Doc 8168、旧国内规范或作者简化的迹象，单列“实现依据待确认”和差异。
2. Conventional Departure 为最高优先级之一，按业务分支而非窗体分割：直线/转弯/全向、定高/定点/电台上空、有无航迹引导、导航设施与方式、TP/KK′/C/定位容差/风螺旋关系、起始区/转弯区/后续区、相交/扩张/裁剪/包络/主副区/障碍物评价。跨窗口数据和调用必须贯通；这些是待核查分支，不预设 DLL 全部实现。
3. 单独建立保护区衔接索引，覆盖 IntersectWith、Offset、Polyline/Arc、切线、交点、包络、裁剪、延伸、XData、选择以及删除/重建图元；判别代码化规则与人工图面操作。
4. CAD 人工交互逐处记录业务对象、无法自行确定的原因（无证据则待确认）、选择结果下游计算、能否从程序数据推导。
5. C# 导出不等于恢复完成；继续综合 IL、字段、事件、调用、CAD API、SQL、配置、帮助恢复业务与计算。
6. 证据来源另外标明：原始程序集、处理/反编译、IL/调用恢复、运行验证、规范/上下文推断。此来源维度与 A–E 级别并列，推断不能写成源码事实。
7. 检查点只作内部质量检查，遵守上述四类暂停条件。
8. DLL、数据库、配置、DWG、帮助和压缩包原件只读，保存原路径与 hash；处理程序集、源码及解包内容均进入独立目录。
9. Misc 的 PANS-OAS3.3.rar、WindSpiralTemplate-1.2.rar 及课件纳入分析，优先级低于主 DLL；验证其与数据模型、公式和代码的关系，不预设仅为参考资料。
10. 每条基础链交付调用图、事件图、代码/IL 定位、输入输出、分支、CAD 交互和未恢复项等可审计中间成果。
