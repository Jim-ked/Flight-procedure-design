# F1 基础数据与程序组织实施设计

2026-11-07。状态：F0.1已实机验收并提交推送332b1567d5525624f9b1869724dfd7dcf1ee6644；本设计进入实施，本文不是完成报告。

## 目标与约定

继续 AutoCAD 2026 / .NET 8 / WinForms PaletteSet / 模块化单体。一个项目对应一个机场及一个 ARP；所有地理数据使用项目 ARP 确定的 CGCS2000 三度带。经纬度为十进制度，距离、高程为米。高程不进行垂直基准转换；源资料高程基准由设计员确认。

本设计采用以下实施约定：跑道方向由两实际端的投影坐标计算并明确标为“格网方向”，不冒充真方位或磁航向；THR、DER 各自保存坐标和标高，不由另一字段暗中替代。输入界面可提供显式“复制实际端位置”操作，保存后仍是独立值。设施仅录入所选类型有关属性。CAD 拾点在当前项目投影下解释，不自动猜测外部 DWG 的坐标系。

## 最小数据结构

| 数据 | 新增字段和关系 |
|---|---|
| ProjectData | `Runways=[]`、`Navaids=[]`；既有 Fix、Obstacle 和唯一 Airport 延续 |
| RunwayData | `Ident`（如16/34）、`Width`、`EndA`、`EndB` |
| RunwayEndData | `Designator`（如16）、`PhysicalEnd`、`Threshold`、`DepartureEnd`；三者均为独立 GeoPosition |
| GeoPosition | `Latitude`、`Longitude`、`Elevation`；用于跑道和设施，坐标及标高必填 |
| NavaidData | `Ident`、`Name`、`Kind`（VOR/DME/NDB/ILS）、`Position`；类型专用属性见下文 |
| ProcedureData | 保留 `Name/Kind/Runway/FixIdents`；新增 `Sections=[]`，既有 FixIdents 作为默认主顺序 |
| ProcedureSection | `Name`、`Stage`（Main/Missed）、`Branch`（Common/RunwayTransition/Transition）、可选 `Runway`、有序 `FixIdents`；允许重复 |

导航设施可选属性：VOR 的频率 MHz、磁差；DME 的频道、可选配对频率 MHz；NDB 的频率 kHz；ILS 的 LOC 标识/频率 MHz、LOC 位置（主 Position）、GP 位置与角度。ILS 不要求与 LOC 同位；未提供 GP 资料时保留空值，后续依赖该资料的工具再要求补齐。不引入完整设施性能模型，也不把不同单位放在无说明的统一频率栏中。

引用采用既有标识，不加通用对象注册系统。跑道选择用实际已建跑道端标识，旧项目自由填写的 Runway 文本保留并提示未关联。Fix 更名/删除同步主顺序和 Sections 引用。Missed 仅用于 Approach；Holding 不增加第四种 Procedure，未来专业机动按所附程序/阶段调用，本轮不实现等待参数对象。

旧 JSON 缺省集合为空。显式 null、无效枚举、重复标识、未知 Fix 引用及非有限数值拒绝；旧主顺序不迁移、不丢弃。保存沿用先校验再临时文件替换。

## 页面与 CAD 操作

项目一级页不变。在现有紧凑基础资料区域加入“跑道”“导航设施”局部列表入口，使用表格和直接新增/修改/导入/绘制按钮。机场摘要继续保持紧凑，ARP 仍在机场编辑窗中。

跑道编辑窗按两端显示实际端、THR、DER 的位置及标高。用户可键入坐标，或点击某个位置旁“CAD 拾取”；进入一次宿主 Modal 命令，使用 GetPoint，取消不改资料。拾得 UCS 点转 WCS，再按固定 CM 反算经纬度；回填后由用户确认保存。经纬度正反算必须以独立 PROJ 参照和跨带样例验证。

跑道绘图以实际端中心连线和 Width 构造原生封闭轮廓/中心线；THR 与 DER 以不同线型或明确文字区分，标注端标识及标高。位于同一点时仍保留概念和资料区分，避免叠写同一位置的文字。使用 `FPD_RUNWAY`，不按每条跑道或端创建图层。绘图为一次命令和事务，原生 U 可撤销，不覆盖既有图形。

导航设施列表按类型启用相关字段。可拾取位置、选择已绘符号，或使用项目列表；绘制为原生块及名称属性，使用 `FPD_NAVAID`，类型符号不同。用户可移动、修改，不建立逐实体生命周期。

Fix/Obstacle 延续 F0.1，增加“CAD 选择”和“拾点新增”入口。GetSelection 接受插件原生块/DBPoint：已有块名称属性用于匹配项目标识，同时核对位置；同标识异位置不静默覆盖。普通 CAD 点可回填新增窗，标识与障碍物顶标高须明确填写，不能猜测。多选后可直接调用批量绘图，不强制切到程序页。

程序页保留程序列表及主顺序，增加紧凑段选择和段名称/阶段/分支/跑道编辑；顺序追加、删除、上下移动复用现有实现。当前程序和段在刷新后保留。Common 段只保存一次，不自动展开复制；导出同时保留主顺序和分段结构，不宣称 ARINC424 编码。切换 Approach 为其他类型若存在 Missed 段，拒绝并明确提示先调整段，不能静默删数据。

工具页保留固定窄分类。基础绘图直接调用相应项目数据或 CAD 拾点；专业工具仍可独立于 Procedure 运行。成果页增加跑道/设施实际图层查看及 CSV 输出，不创建模拟专业成果。

## CSV 与绘图约束

所有导入先完成整批解析和校验，再写项目；错误报告实际行号。新 CSV 使用英文标题、InvariantCulture 数值、UTF-8，支持重排标题和带引号字段，复用现有 PointCsv 解析能力，不引入 GIS 库。

- Runway：一行一条跑道；`Ident,Width,A_Designator,A_EndLatitude,A_EndLongitude,A_EndElevation,A_ThrLatitude,A_ThrLongitude,A_ThrElevation,A_DerLatitude,A_DerLongitude,A_DerElevation`，以及相同结构的 B 列。全部必要位置显式填写。
- Navaid：`Ident,Name,Kind,Latitude,Longitude,Elevation,FrequencyMHz,FrequencyKHz,Channel,MagneticVariation,GpLatitude,GpLongitude,GpElevation,GpAngle`；类型无关列可空。GP 经纬度/标高须成组填写。ILS 频率属于 LOC。

检查跑道端位置不同、宽度正值、THR/DER 与中心线关系合理、端标识唯一；不根据磁差自动改跑道编号。方向显示由实际数据计算。数据范围错误拒绝；超出预期但可能合法的资料由明确提示处理，不编造专业标准阈值。

## 复用与最小新增

`Fpd.Core`：在 Models/ProjectValidation/PointProjection 相邻位置增加跑道、设施和程序段数据及校验；新增投影反算、CSV和必要编辑函数。`Fpd.AutoCAD`：新增直接相关的编辑窗和一份 CAD 基础资料拾取/绘制文件，WorkspacePanel 沿现有 partial 分工扩展。沿用命令队列、文档一致性检查、一次事务、图层与块属性。禁止引入 MVVM、DI、事件总线、通用工具调度或 CAD 实体管理系统。

现有恢复资料用于复用紧凑参数窗→CAD 拾取→计算→原生实体的交互；参考 `recovered/GeometryPrimitives/CadSelection.Recovered.cs`、A2 的 `cad-interactions.md` 和 CalcuCad。旧恢复文件只读，不直接加载 net48 DLL，不复制无关旧框架。拾取消失/取消必须使用 PromptStatus，不能把原点当取消哨兵。

风格继续使用 sealed 数据类、明确属性和直接方法，例如 `public List<RunwayData> Runways { get; set; } = [];`。不加入新的外部依赖。

## 实施与验证顺序

1. Core 数据/校验/旧 JSON 兼容；验证实际端与 THR/DER 不同、设施类型字段与单位、程序重复引用和分段回读。
2. 反算与 CAD 拾取；对天津及非中心经线点使用独立 PROJ 参照，正反算误差和取消不写入单独测试。
3. 跑道录入/整批导入/原生绘图，实机检查轮廓、THR/DER、标注、WCS 坐标和 U。
4. 设施录入/导入/选择/符号绘图，实机确认不同类型字段及 CAD 直接选用；验证 Fix/Obstacle 拾取。
5. 程序阶段/分支和成果输出；保存 JSON 与 DWG，关闭重开后继续编辑，四页高 DPI 截图。

每片运行 `./build-f0.ps1 -OutputDirectory tmp/F1-check`；Core 入口为 `dotnet run --project tests/Fpd.Core.Tests/Fpd.Core.Tests.csproj`。实际宿主使用新进程 NETLOAD，逐项观察，保留最后成功动作；不粘贴命令行脚本。同一崩溃连续两次无新增证据就停止重复触发。验收后独立 F1 提交推送；F0.1 先独立提交。任何未完成项在报告明示。

始终保留历史资产和用户未提交资料。涉及范围扩大、依赖新增或大量文件迁移才提请用户决策；现有范围内普通修改继续执行。不得强推、reset/clean、改安全设置或以静态结果替代实机验收。
