# Round 1 Closure

更新：2026-10-27。**Round 1: PARTIALLY ACCEPTED**。

范围仅A2、RandomPoint→xInfo→ScreenData→A8/A9评价→Mark、A3。本轮静态闭合与兼容编译已交付，原目标业务运行验证受阻，不能正式验收。未扩展其他保护区算法、未修改WsTools原件、未开发替代系统。规范基线AC-97-FS-005 / 民航规〔2020〕12号；用恢复行为对照规范，不按规范改写行为。常数及化简方法的历史依据仍标记“实现依据待确认”。

## 证据口径

| 等级/来源 | 本轮含义与边界 |
|---|---|
| L1 原始程序集直接证据 | hash、PE/TargetFramework、AssemblyRef、原始成员及事件元数据；某些原方法体是保护桩，原token/RVA本身不证明恢复公式。 |
| L1 去混淆/反编译结果 | 阅读副本及方法定位，保留处理token和原token映射；不能冒充未处理原源码。 |
| L2 IL/调用关系恢复 | 处理后独立IL、事件与调用索引交叉恢复；保留阅读副本出错及IL纠正过程。 |
| L3 运行 | 本轮只有宿主、Observer初始化/空图/命令事件及RCL不可用证据；无A2/障碍物/A3业务方法运行证明。 |
| L4 推断 | 自动化可能性、历史规范依据候选等，不能记成源码事实或用于修复算法。 |

兼容编译与恢复代码单元检查是独立验证类型，不升级成原目标L3。历史报告的“未编译/无宿主”保留为当时状态，本文件及`dynamic-test/`为最新入口。

## 交付与验收缺口

| 包 | 本轮闭合成果 | 尚未满足的运行/重建条件 |
|---|---|---|
| A2 | 六公式、六绘图事件、输入/取消、坐标/文字/两个事务、WsCalcuLine字段及下游定向检索 | EXP-05–08未执行；完整Designer/config/控件装配与原API23.1重建未验证。 |
| 障碍物 | 生成/裸Point与可选metadata、xInfo全部XData、SelectAll/解析/表格/ID回查、A8/A9评价和Mark；15条边有原/处理token/RVA | EXP-01–04未执行；没有实测随机障碍物JSON、xInfo输出对照、真实obst块定义与插入属性布局。 |
| A3 | 设施/引导参数、误差、KK先写、Polyline分组、可选三弧、盲区、Z差异、旧事件绑定 | EXP-09未执行；EXP-10可选未执行；匿名Group及几何Z没有目标实测。 |

审计入口：

- [78个方法切片](native-port-map.csv)，[机器状态](native-evidence-status.json)。切片数量不是完成率。
- A2：[公式](A2-BasicCalculation/formulas.md)、[六事件及输出](A2-BasicCalculation/cad-output-map.md)、[schema及下游](A2-BasicCalculation/WsCalcuLine-schema.md)、`evidence/events.csv`、`calls.csv`及独立IL。
- 障碍物：[schema](ObstacleData/WsEntityFrame-schema.md)、[xInfo](ObstacleData/xinfo.md)、[ScreenData](ObstacleData/screen-data.md)、[Mark](ObstacleData/marker.md)、[15条边](ObstacleData/evidence/closure-chain-edges.csv)。
- A3：[几何链](A3-FixTolerance/geometry-chain.md)、[事件/实体输出](A3-FixTolerance/cad-output-map.md)、`evidence/events.csv`、`calls.csv`及独立IL。
- [跨链调用图、事件异常与CAD人工交互](round1-native-recovery.md#调用事件链)。各包同时保留输入输出、条件分支、恢复C#及未恢复项；图是静态恢复图，不是运行轨迹。

## 编译与宿主

19文件联合启用`AUTOCAD;ACAD2026_TEST`，使用API25.1.0.0/.NET8.0.12，兼容编译成功。三处适配只指定`System.Data.DataTable`别名，没有改变公式、分支、几何或序列化。`Recovered.Native.Validation.dll`从未NETLOAD。详见[逐文件编译记录](dynamic-test/compile-validation.md)及响应文件、原日志。

原目标为Framework4.8、AnyCPU（I386容器但无32BITREQUIRED），引用Autodesk23.1.0.0；本机AutoCAD2026实际API25.1/CLR8.0.12。目标副本映像已加载，NETLOAD结束时未见显式异常，但`(command "RCL")`返回未知命令。没有得到LoaderExceptions，不能断言具体兼容性根因。独立诊断DLL已编译但未加载。

运行状态：**Runtime validation blocked by host compatibility**，具体原因待确认；随后输入队列污染又阻止受控诊断。新图曾被另存桌面；用户回复停止后，取消SAVEAS仍立即重开。已停止UI，未继续业务实验。此隔离事件和所有污染命令不作为WsTools业务证据。记录：[环境](dynamic-test/environment.md)、[实验索引](dynamic-test/experiment-index.md)、[差异](dynamic-test/dynamic-static-differences.md)、[输入事件](dynamic-test/logs/input-interference.md)。

原件/副本的原路径和hash保留在`dynamic-test/logs/runtime-copy-manifest.json`；收尾重检、编译输入及产物hash、冻结Observer日志见`dynamic-test/logs/closure-integrity.json`。Observer源码的Group成员补充尚未构建，不能当成已加载能力。原23.1宿主等价运行、块定义和业务实验是明确缺口。

内部收尾审计通过：85原件及85对应副本hash未变化；78方法切片配套IL无缺项；15条障碍物边的token/RVA及编译状态与方法映射一致；15项必需文件和本轮报告22个链接目标存在。可复现`python recovered/dynamic-test/validate_closure.py`；结果`dynamic-test/logs/closure-validation.json`。这是证据包完整性检查，不是业务验收测试。没有为收尾重跑无关数值测试。

## 旧行为保留

保留Origin/取消混用与各页检查差异、数字失败返回0、HLcor=0仍继续画+1、NPA/C重复读取、comboXz.TabIndexChanged错误绑定、A3数字异常后Form隐藏、DME后缀Leave重置NDB半角、未命名Group、KK/Polyline Z0与Arc/Circle保留拾取Z。没有以异常看似不合理为由“清理”。

## 最后十三问

1. **A2六项是否全部恢复？** 六项公式及六个CAD事件的静态行为已恢复并有IL定位，兼容编译通过。FAF=`(faf−rdh−thr)/tanGP`；NPA/C=`(TAS+w)t/3.6`，默认t=18/6但不拆3+15/3+3；PA=`Round((DH−HLcor)/tanGP+Xz)`后CAD取负；复飞TP=`100(终高−起高)/梯度%`；离场TP=`100(转弯高−DER高−5)/PDG%`。完整窗口重建及目标运行未验收。
2. **WsCalcuLine是什么？** RegApp及施工Line的DataContract JSON载体，封装`1001 app / 1000 Kind / 1000 JSON`。六页共用10成员Line和28成员参数schema；有Kind、中心、方向、长度、描述、参数、时间/创建者。writer以实际横向线覆盖中心/朝向/长度，没有独立持久化DER/原始起点字段。Line先提交、另一事务再写XData。
3. **下游是否自动读取？** 唯一reader原06000656/B8D34仅发现包装方法原060006AC调用；后者无已索引直接调用者。A7/A8/A10无自动复用证据。**metadata exists, but no evidence of automatic downstream semantic reuse.** 未排除反射/外部调用。
4. **RandomPoint一个障碍物由什么实体组成？** 静态每个点一个DBPoint+一个MText，即使空内容也建MText。XYZ在Point.Position，Z舍入2位；中心Z不参与；显示名为P+ObjectId字符串后缀。未直接写WsEntityFrame；以上未获EXP-01运行验证。
5. **WsEntityFrame是什么？** 通用实体名称/类型/Properties属性框架，JSON真实名称/类型键为Unicode；header含类型和名称，JSON按250个.NET字符分片。Properties默认Key/Value数组。不是统一的随机障碍物高度模型：此链的高度在Point.Z、显示在MText、ID在导入序号/字典；没有树高相加步骤或固定TreeHeight/TotalHeight字段。
6. **ScreenData如何识别障碍物？** 公共SelectAll过滤DXF0=POINT、410=Model；不手选、不检查IsObstacle、不读附近MText。parser原06000130/10D00接收序号ID，取原XYZ，尝试EntityFrame名称，失败/空名退回后缀；A8/A9保留ID→原DBPoint字典供Mark，评价表不是原实体。识别链有静态证据，未获EXP-03验证。
7. **xInfo实际读取什么？** 原06000075/470C一次GetEntity，只读Entity.XData全部RegApp。1001切换app，其余TypedValue逐项输出或手写递归扫描JSON形文本；不读ExtensionDictionary、不用GetXDataForApplication、不递归实体.NET Properties、不拼接250字符片段。长坏JSON有潜在循环风险，未冒险在宿主构造。
8. **Mark实际插入什么？** 选中行ID查原Point，在其原XYZ插入`obst`、scale1；高度Tag `Altitude`写原Z而非OCA，A8另写`Name`。缺块时枚举执行程序集目录首个`WsSymbol*.dwg`导入，非硬编码WsSymbol2.1文件名。A10字面量为`Obst`。真实DWG内部属性定义/布局未读取，未获EXP-04运行证明。
9. **A3 KK如何生成？** r为平面距离或指定NM×1852，e=.0125r+460；late=r+e、early=(r−e)cos a，按航迹θ两中心各横向±9260生成两条Line（Z0）。先写KK，再追加楔形与可选Track的Polyline组；KK不入该组。精度角由设施/引导事件回填后再读取UI。
10. **DME三弧如何生成？** DME开时按r+e/r/r−e、θ−a至θ+a建3Arc，用原台站S所以保留Sz，另一个Group后加距离DBText。Group直接AddDBObject未登记命名组字典。盲区则R=h·tan半角，先可选两Polyline组后Circle(S)，取消入航点则Circle也不画。以上为静态恢复。
11. **哪些结论已有AutoCAD运行证据？** AutoCAD版本/PID/API/实际CLR、Observer成功初始化和空图快照/命令事件、目标副本映像加载、RCL未知命令、输入污染与SAVEAS重开。没有A2/RandomPoint/xInfo/ScreenData/Mark/A3业务行为L3。
12. **哪些仍只有L1/L2？** 六公式/事件的目标等价性、metadata真实写入及事务时序、生成器实体内容、导入与评价数据流、块插入及属性、KK/三弧/盲区几何与旧异常均为L1处理结果+L2恢复；已做恢复代码数值测试/兼容编译但不升级为L3。历史规范来源和可自动化建议仍L4或“实现依据待确认”。
13. **能否正式ACCEPTED？** 不能。**PARTIALLY ACCEPTED**：静态成果和兼容编译可审计，EXP-00未完成目标校准、EXP-01–09未执行，块定义和原宿主等价性未闭合。没有用成功生成C#或编译成功代替功能验收。
