# CODEBASE_MAP：当前代码事实索引

本文件只索引当前工作区实际存在的文件和目录，不建立新的架构或设计基线。状态描述来自当前文件系统；“待功能级审计”表示已找到证据入口，但本次没有把静态恢复证据升级为运行时结论。

## 1. 工作区快照范围

| 项目 | 当前事实 |
| --- | --- |
| Solution | `Fpd.sln` |
| 非生成 C# 文件 | 183（不计 `bin/`、`obj/`、`tmp/`、测试结果） |
| `src/` C# 文件 | 8 |
| `tests/` C# 文件 | 4 |
| `recovered/` C# 文件 | 109 |
| `reverse-analysis/` C# 文件 | 62 |
| A1～A10、B1～B5 C# 文件 | 75 |
| 项目目录中的 DLL（排除生成目录） | 85 |
| 当前工作区非生成文件总量 | 约 652 MB（盘点时） |
| 当前排除 | `.vs/`、`bin/`、`obj/`、`TestResults/`、`tmp/`、编辑器/AutoCAD 锁文件、明确的机器凭据模式 |

`recovered/` 和 `reverse-analysis/` 中的历史编译日志、IL、反编译文本、manifest、hash、fixtures、样例 DWG/CSV 和研究 DLL 是项目研究材料，保留在基线中。AutoCAD 安装目录不在工作区内，也没有复制进仓库。

## 2. Solution 和 Project

| 路径 | 类型 | Target | 当前作用 |
| --- | --- | --- | --- |
| `src/Fpd.Domain/Fpd.Domain.csproj` | 生产 | .NET Framework 4.0 | 领域契约、程序状态、障碍物/保护区数据结构 |
| `src/Fpd.Engine/Fpd.Engine.csproj` | 生产 | .NET Framework 4.0 | 计算与依赖图尝试 |
| `src/Fpd.Application/Fpd.Application.csproj` | 生产 | .NET Framework 4.0 | 应用端口与用例编排尝试 |
| `src/Fpd.Infrastructure/Fpd.Infrastructure.csproj` | 生产 | .NET Framework 4.0 | 基础设施与 fake 实现 |
| `src/Fpd.Legacy.WindSpiral/Fpd.Legacy.WindSpiral.csproj` | 生产/Legacy | .NET Framework 4.0 | 当前 Legacy/WindSpiral 行为适配入口 |
| `tests/Fpd.Legacy.BehaviorTests/Fpd.Legacy.BehaviorTests.csproj` | 测试 | .NET Framework 4.0 | Legacy 行为测试入口 |
| `tests/Fpd.RuleConformance.Tests/Fpd.RuleConformance.Tests.csproj` | 测试 | .NET Framework 4.0 | 规则符合性测试入口 |
| `tests/Fpd.Engine.Tests/Fpd.Engine.Tests.csproj` | 测试 | .NET Framework 4.0 | Engine 测试入口 |
| `tests/Fpd.Application.Tests/Fpd.Application.Tests.csproj` | 测试 | .NET Framework 4.0 | Application 测试入口 |
| `reverse-analysis/03_recovered-src/ilspy-original/WindSpiralBasic.csproj` | 恢复工程 | net48 | 原始反编译工程项目文件 |
| `reverse-analysis/03_recovered-src/ilspy-methods-only/WindSpiralBasic.methods-only.csproj` | 恢复工程 | net48 | 方法级反编译工程项目文件 |

生产项目引用关系、外部程序集引用和兼容 MSBuild 顺序以各 `.csproj`、`Directory.Build.props`、`build-compat.ps1` 为准。

## 3. 主要目录

| 路径 | 当前内容 |
| --- | --- |
| `src/` | 当前生产源码；包含 Domain、Engine、Application、Infrastructure 和 Legacy.WindSpiral |
| `tests/` | 当前测试源码 |
| `recovered/` | A1～A10、B1～B5、ObstacleData、GeometryPrimitives、动态观察和历轮静态/行为证据 |
| `reverse-analysis/00_manifest` | 原始材料清单、解包记录、工具运行记录 |
| `reverse-analysis/01_original` | 原始/供分析材料副本 |
| `reverse-analysis/02_deobfuscated` | 去混淆结果 |
| `reverse-analysis/03_recovered-src` | 原始、方法级和带注释反编译源码 |
| `reverse-analysis/04_type-map` | 类型、成员、命令和资源索引 |
| `reverse-analysis/05_callgraph`～`10_spec-mapping` | 调用图、算法、程序逻辑、保护区、CAD 交互和规范映射 |
| `WsTools-master/` | WindSpiral2026、WsGis、Annex14、Misc 和帮助/样例 |
| `doc/` | 受控详细设计文档及规范资料 |

## 4. WindSpiral A1～A10 / B1～B5 功能索引

下表只记录当前发现的窗口/输入、CAD、图层/块、评价和输出证据入口。没有独立证据的栏位写“待功能级审计”，不推断功能已完成。

| 功能 | 当前文件入口 | 当前可见链条/状态 |
| --- | --- | --- |
| A1 WindSpiral | `recovered/A1-WindSpiral/`、`WsTools-master/WindSpiral2026/` | `overview.md`、`event-map.md`、`final-input-semantics.csv`、`cad-output-final.csv`；总入口和 CAD 输出证据已恢复，具体窗口到评价链待功能级审计 |
| A2 BasicCalculation | `recovered/A2-BasicCalculation/BasicCalculation.Recovered.cs`、`BasicCalculationForm.Events.Recovered.cs`、`TurnParameterInput.Recovered.cs`、`CalcuCad.Recovered.cs` | 参数窗口/用户输入、计算契约与工厂、CAD 输出和事务证据；障碍物评价未在该模块目录发现独立入口，待功能级审计 |
| A3 FixTolerance | `recovered/A3-FixTolerance/FixTolerance.Recovered.cs`、`FixToleranceForm.Events.Recovered.cs` | 参数窗口、定位容差输入、几何链、CAD 输出映射；图层/块和障碍物评价待功能级审计 |
| A4 NavAidProtection | `recovered/A4-NavAidProtection/NavAidProtectionForm.Recovered.cs`、`NavAidProtectionGeometry.Recovered.cs` | 导航设备参数窗口、边界几何、CAD 输出、`obstacle-evaluation.md`；拾取/图层/块细节在 evidence 和静态报告中 |
| A5 PrecisionApproach | `recovered/A5-PrecisionApproach/PrecisionApproachForm.Recovered.cs`、`PrecisionApproachModes.Recovered.cs`、`Pa*Geometry.Recovered.cs`、`GpInopGeometry.Recovered.cs` | 模式和参数窗口、精密进近几何、CAD 输出、`obstacle-evaluation.md`；运行时宿主状态待功能级审计 |
| A6 Template | `recovered/A6-Template/TemplateCad.Recovered.cs`、`BaseTurn`、`Holding*`、`Spiral*`、`Procedure*` | 模板/转弯/Holding/螺旋几何、CAD 写入、共享点列和辅助图形证据；独立障碍物评价入口未发现 |
| A7 Departure | `recovered/A7-Departure/DepartureForm.Recovered.cs`、`Departure.Events.Recovered.cs`、`DepartureGeometry.Recovered.cs`、`DepartureObstacleEvaluator.Recovered.cs` | 离场窗口/输入、点转弯和高度转弯几何、CAD 输出、障碍物评价；跨窗口输入证据已记录 |
| A8 TurnArea | `recovered/A8-TurnArea/TurnArea.Recovered.cs`、`TurnArea.Events.Recovered.cs` | 转弯区窗口/事件、几何和 `obstacle-evaluation.md`；CAD 输出细节待功能级审计 |
| A9 Primary/Secondary | `recovered/A9-PriSec/`、`recovered/ObstacleData/PriSec.Recovered.cs`、`PriSecForm.Events.Recovered.cs` | 主副区输入语义、评价报告和障碍物表单证据；当前静态闭包明确没有独立 protection writer，运行时链条待功能级审计 |
| A10 DME Arc | `recovered/A10-DmeArc/DmeArc.Recovered.cs`、`DmeArc.Events.Recovered.cs`、`DmeArc.Bodies.Recovered.cs`、`DmeArc.Native.Recovered.cs` | DME 弧窗口/输入点、弧几何、CAD 输出和障碍物评价文档；运行时宿主状态待功能级审计 |
| B1 FlyBy | `recovered/B1-FlyBy/FlyBy.Boundaries.Recovered.cs`、`FlyBy.CadWriter.Recovered.cs` | FlyBy 输入/边界、CAD writer、事件和输出映射；障碍物评价未发现独立入口 |
| B2 FlyOverDF | `recovered/B2-FlyOverDF/FlyOver.Boundaries.Recovered.cs`、`FlyOver.CadWriter.Recovered.cs` | FlyOver/DF 输入/边界、CAD writer、事件和输出映射；障碍物评价未发现独立入口 |
| B3 RNP APCH | `recovered/B3-RnpApch/RnpApchForm.Recovered.cs`、`RnpApchCad.Recovered.cs`、`RnpApchApv*`、`RnpApchLnav*`、`RnpApchMissed.Recovered.cs` | 参数窗口、CAD 绘制、APV/LNAV 几何、Missed Approach、两套障碍物评价证据；细节待功能级审计 |
| B4 PBN ILS | `recovered/B4-PbnIls/PbnIlsForm.Recovered.cs`、`OasModel.Recovered.cs`、`PbnIlsTurn.Recovered.cs`、`PbnIlsObstacle.Recovered.cs`、`PbnIlsKml.Recovered.cs` | 参数窗口、OAS/转弯、CAD/KML 输出和障碍物评价；宿主连接待功能级审计 |
| B5 PBN Departure | `recovered/B5-PbnDeparture/PbnDepartureForm.Recovered.cs`、`PbnDepartureCad.Recovered.cs`、`PbnDepartureObstacle.Recovered.cs`、`PbnDepartureAltitudeTurn.Recovered.cs` | 参数窗口、跑道/起始区/高度转弯、CAD 写入、图层/线型和障碍物评价；细节待功能级审计 |

## 5. CAD 资产索引

### AutoCAD CommandMethod

已在 `reverse-analysis/03_recovered-src/ilspy-original/-/-.cs`、带注释版本和 `reverse-analysis/04_type-map/raw/commands.csv` 中发现 34 个索引命令。公开功能入口包括：

`WsTools`、`Y01_风螺旋`、`Y02_基础计算`、`Y03_定位容差`、`Y04_导航设备保护区`、`Y05_精密进近保护区`、`Y06_传统模板`、`Y07_离场保护区`、`Y08_转弯区评估`、`Y09_主副区评估`、`Y10_起始进近DME弧`、`Y51_FlyBy`、`Y52_FlyOver`、`Y53_RNP_APCH`、`Y54_PBN_ILS`、`Y55_PBN_Departure`、`exline`、`RCL`、`rectLine`、`NMCIRCLE`、`Arc2`、`Y92_RandomPoint`、`Y90_LoadBlock`、`Y91_CreateLayer`、`xInfo`。另有 `Hello`、`notReady`、`y9_AddObstBlockDef`、`Command1`、`Command2` 和图层工具命令，状态以 command inventory 标注为 diagnostic/stub/unknown。

### Window/Form

恢复窗口事件和表单入口主要位于 `recovered/A2-BasicCalculation/`、`A3-FixTolerance/`、`A4-NavAidProtection/`、`A5-PrecisionApproach/`、`A7-Departure/`、`A8-TurnArea/`、`B3-RnpApch/`、`B4-PbnIls/`、`B5-PbnDeparture/` 和 `recovered/ObstacleData/`。A6 的 `Holding*`、`TurnInput`、`Procedure*` 是模板/机动输入与几何组件。原始窗口资源和帮助页面位于 `WsTools-master/WindSpiral2026/帮助文件/` 及其 `images/`。

### CAD writer、实体和拾取

- CAD writer：`recovered/A2-BasicCalculation/CalcuCad.Recovered.cs`、`A6-Template/TemplateCad.Recovered.cs`、`B1-FlyBy/FlyBy.CadWriter.Recovered.cs`、`B2-FlyOverDF/FlyOver.CadWriter.Recovered.cs`、`B3-RnpApch/RnpApchCad.Recovered.cs`、`B5-PbnDeparture/PbnDepartureCad.Recovered.cs`、`recovered/ObstacleData/ObstacleCad.Recovered.cs`。
- CAD 选择/拾取：`recovered/GeometryPrimitives/CadSelection.Recovered.cs`、`A6-Template/Envelope.Recovered.cs`，以及 `reverse-analysis/03_recovered-src/*/--/--.cs` 中的原始 `GetSelection`/`PromptSelection` 证据。
- Transaction/Entity：`recovered/GeometryPrimitives/WsObjectCad.Recovered.cs`、`recovered/ObstacleData/EntityFrameCad.Recovered.cs`、`ObstacleCad.Recovered.cs`、各模块的 `*Cad.Recovered.cs`。
- Layer 创建/切换：`recovered/A6-Template/TemplateCad.Recovered.cs`、`recovered/B5-PbnDeparture/PbnDepartureCad.Recovered.cs`、`recovered/dynamic-test/observer/WsToolsObserver.cs`，以及原始源码中的 `Y91_CreateLayer`、`CheckAndSetLayer`、`GetCurrentLayerName`、`GetCurrentLayerInfo`、`SetCurrentLayer`。
- Block 定义/插入：`recovered/ObstacleData/ObstacleCad.Recovered.cs`、`recovered/A2-BasicCalculation/CalcuCad.Recovered.cs`、`recovered/GeometryPrimitives/WsObjectCad.Recovered.cs`，以及原始 `Y90_LoadBlock`、`y9_AddObstBlockDef` 和 `BlockReference`/`BlockTable` 证据。
- Text/annotation：原始和恢复 CAD 源码中的 `DBText`/文字实体证据；未发现名为 `Annotation` 的独立 C# 类型，具体文字样式待功能级审计。
- Linetype：`recovered/B5-PbnDeparture/PbnDepartureCad.Recovered.cs`、`recovered/dynamic-test/observer/WsToolsObserver.cs` 和原始 CAD 源码。

### 障碍物评价和保护区

当前生产适配入口为 `src/Fpd.Legacy.WindSpiral/RecoveredProviders.cs`；恢复资产集中在 `recovered/ObstacleData/`、`A7-Departure/DepartureObstacleEvaluator.Recovered.cs`、`B3-RnpApch/*Obstacle*`、`B4-PbnIls/PbnIlsObstacle.Recovered.cs`、`B5-PbnDeparture/PbnDepartureObstacle.Recovered.cs`，以及 A4/A5/A8/A10 的 `obstacle-evaluation.md`。`src/Fpd.Domain/Contracts.cs` 和 `I1AContracts.cs` 提供当前 I0/I0.5/I0.6 侧的保护区/障碍物契约。

## 6. fixtures、hash、manifest、案例和文档

- fixtures：`recovered/round2`～`round9` 下的 `fixtures/`、`fixture-index.json`、数值/几何/CAD 记录；模块目录下的 `evidence/`、`*.csv`、`*.json` 同时保留。
- hash/manifest：`reverse-analysis/00_manifest/`、`recovered/**/manifest*`、`recovered/round*/output-manifest.json` 等。
- 样例 DWG/CSV：`recovered/dynamic-test/dwg/`、`WsTools-master/WindSpiral2026/Sample/`、`WsTools-master/WindSpiral2026/WsSymbol2.1.dwg`、`WsTools-master/Misc/Skp/` 及对应 `reverse-analysis/01_original/` 副本。
- 天津案例：当前文件系统未发现以“天津/Tianjin”命名的案例实体或数据目录；只有报告中的文字引用（例如 `I0.6 RuleSpec Closure Report.md`、`I1-A Design Preparation.md`）。
- 受控详细设计文档：`doc/固定翼飞行程序设计系统_业务与设计基线 .docx`；同目录规范 PDF 和 WsTools 功能规范阶段文档一并保留。该 DOCX 是业务与设计事实的受控来源，本索引不替代它。

## 7. 构建状态记录

项目目标框架、外部引用和构建顺序由工程文件决定；`build-compat.ps1` 使用 `C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe` 逐项目构建并运行四个测试可执行文件。AutoCAD 2020 的宿主程序集来自本机安装，不在仓库。2026-10-31 在本机执行该脚本成功：9 个工程构建成功，4 个测试程序均 PASS；MSBuild 报告缺少 .NET Framework 4.0 targeting pack（MSB3644）并有 MSIL/AMD64 架构警告（MSB3270）。

