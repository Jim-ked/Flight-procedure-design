# F0.1 / F1 统一修订交付记录

日期：2026-11-07。工作分支 codex/f1-human-review，基线319a0b7；main不变，继续使用草稿PR #1。本报告区分源码/离线检查与宿主实测，未通过项不视为整体验收完成。

## 修改与验证矩阵

| 主题 | 实际代码落点 | 当前证据 |
|---|---|---|
| 独立路径及旧资料 | Core Models、ProcedurePaths、ProjectStore、ProjectValidation、PointProjection | 旧主顺序/各段分别迁移、重复顺序/跑道/复飞信息、稳定ID、原文件备份及Fix更名删除：Core测试通过 |
| 程序页 | WorkspacePanel.Procedures / Input、CadDrawing.BaseMap.PickFixOrder | 已实现设计员命名、多路径、列表/CAD逐点、Enter/整轮Esc、前后插入、移动/反转/移除、引用图符；首轮命名窗透明背景异常已修；最终宿主已完成ZBTJ-SID/Route-A命名、CAD重复顺序、整轮Esc取消及列表搜索前插 |
| 紧凑项目资料 | WorkspacePanel.Project / Airport | 实机显示Fix标识、障碍物标识/顶标高、跑道摘要、设施类型/频率；完整专业字段仍在编辑窗。CSV、快捷键/右键与更多菜单保留 |
| 公共底图 | CadDrawing.BaseMap及原绘图薄重载、Plugin、WorkspacePanel | 实机错DWG导入不写图；明确关联后补建3 Fix；导入3障碍物/1跑道/4设施自动出图，各一次操作；最终宿主重新打开JSON/DWG提示底图已一致，未重复绘制；移动冲突专项待验 |
| 专业符号 | SymbolLibrary、CadDrawing.Symbols、Symbols/symbol-map.json | 实际枚举188块，78匿名、28动态；对照图及完整实体/属性/范围表已生成。Flyby/Flyover/强制报告点实际映射；按审计宽度分别换算；实际点击绘图触发External component异常，此项失败，已补阶段/堆栈诊断 |
| 程序图层归组 | CadDrawing.Symbols | 按稳定ProcedureId命名原生层，同程序跨路径相同Fix/符号合并；不生成TF/保护区。源码已实现；实际插块异常，宿主验证未通过 |
| 独立工具 | WorkspacePanel.Tools | 实机输入天津经纬度得到E529936.063/N4332366.307，在原页显示；原五分类常驻，不依赖项目表隐藏选择 |
| 真实成果 | WorkspacePanel.Results | 实机列出现有FPD图面实体并可查看图面；去掉源CSV、序列编辑、图层显隐树。程序路径JSON导出续验中 |
| 布局与拾取焦点 | 四页、Input、Plugin | 首轮四页实际可进入，保存真实截图；修正命名窗透明背景、跑道列宽，修正版继续定点核验 |

## 构建与测试

.NET SDK 8.0.427，AutoCAD 2026 R25.1.60.0，插件目标net8.0-windows。已执行原构建脚本；最终定点修正版位于tmp/F01-unified-final，0警告/0错误，Core 38/38。实际图符异常后补充阶段/堆栈诊断及两个新模态窗DPI基准，构建于tmp/F01-symbol-diagnostic，同样0警告/0错误、38/38。日志UNIFIED_BUILD_TEST.log、UNIFIED_FINAL_BUILD_TEST.log及UNIFIED_DIAGNOSTIC_BUILD_TEST.log。

首轮加载DLL SHA256：5D15242491DE16C883F1A6CBE24F4E01BE34F9F820A25C3E48BCF60F94A8E517。最终定点修正版SHA256：22FE947634E6E4340816B775BE94752014526345B6E666A482DB789D43B459D6。前者截图可证明未受后续局部修正影响的功能，不能代替最终程序/专业符号测试。

## 实际宿主证据

- FPDAUDITSYMBOLS在AutoCAD图形宿主成功执行，完整数据见symbol-audit/block-table.json，原生对照图symbol-audit/symbol-atlas.dwg。原件WsTools-master完整保留。
- 库INSUNITS为Meters，但具体块单位不同；Flyby几何宽1993.862127m单位数、Flyover2067.959697、强制报告点1（块单位Millimeters），基点均为0。直接DB BlockReference按审计原始几何宽度换算到指定图面米宽，不将文字高度作为块比例。
- Flyby、Flyover属性NAME/ALTITUDE/ROLE默认空；强制报告点无属性。程序插块不创建示例默认属性引用，注记单独生成；不烘焙WS911、2100、IAF等值。Obst、ObstWithLight独立于Fix选择，公共障碍物继续采用原简易块。
- 两次Core Console启动在加载AdSpatialReference.dll阶段退出，未执行审计插件；随后采用真实图形宿主审计成功。不把前两次退出归因于FPD，也不宣称已修复Autodesk安装问题。
- 首轮实际测试图纸tmp/Unified-acceptance.dwg，资料tmp/Unified-acceptance.fpd.json；已分别保存。最终定点副本tmp/Unified-final.dwg及同名JSON，原测试图和用户旧图保留。

真实截图见screenshots/unified/：library-original、library-atlas、wrong-dwg-import、fix-base-map、obstacle-base-map、airport-auto-map、coordinate-tool、reopen-no-duplicates、cad-ordered-picks、cad-escape-cancel。name-dialog-defect及program-symbol-exception是失败证据，不作为通过证据。

## 迁移与边界

详细迁移说明见F01_PATH_MIGRATION.md。JSON和DWG分开保存，CAD U不倒退项目数据。未关联/错DWG只录入资料；普通绘图不再修改关联。自动更新只处理身份、成组数量和几何指纹均一致的公共图形，冲突保留并提供明确补建入口。没有增加逐CAD实体通用管理、专业算法或新架构。

## 最终会话的新增实测

已加载tmp/F01-unified-final版本，在独立Unified-final.dwg/JSON中：重新打开项目提示“底图已一致，未重复绘制”；成功新建离场程序ZBTJ-SID及设计员命名路径Route-A；CAD按TJ906→TJ907→TJ906点击，Enter后顺序和重复均保留；新一轮点击后Esc，原序列完整保留；列表搜索TJ908并在所选前插入成功，结果TJ906→TJ907→TJ908→TJ906。第三引用改Reporting，第二引用改FlyOver并填写IAF 1500，其他引用仍为FlyBy，项目Fix坐标未改。JSON已保存。以上未自动创建航迹折线。

随后点击“绘制程序图符”，接受100m宽度，出现AutoCAD消息“External component has thrown an exception.”。宿主继续运行，但未形成可验收程序图符；此项明确记为失败。原处理仅记录Message，无具体API/堆栈，现不能据此认定根因。新构建加入导入、命名、几何检查及事务阶段和完整异常诊断，输出至部署目录diagnostics/symbol-errors.log；不得将加日志本身称为问题修复。独立Unified-diagnostic.dwg/JSON副本已准备，诊断构建NETLOAD停在人工安全提示，尚未执行复现。

诊断构建SHA256：900B86B5D6204E018CAF8B950AD2C111BE6D8B262B0AC0996B61439FE1E14396。命名窗和列表窗已补96DPI基准，源码构建通过；该局部最终视觉修正未实测，不沿用旧截图宣称通过。

## 待验 / 未通过

- **失败/待诊断**：旧库专业图符实际插入；其尺寸、深色可读性、独立程序层、跨路径去重均未通过宿主验收。没有生成模拟通过截图。
- **待验**：多程序/多路径切换及重命名，列表多点后插、上/下移/反转、原生撤销及移动图形冲突；Core对应有序模型及保守边界策略已测试，不替代宿主集成验证。
- **待验**：程序路径JSON按钮实际导出；最终命名/顺序窗DPI、跑道列宽；含新增程序图符的DWG关闭重开（因插块失败未形成结果）。基础资料JSON/DWG回读及不复画已有真实通过证据。
- 未增加F2算法，未将未实现工具或成果伪装为完成；未更改SECURELOAD/TRUSTEDPATHS，未自动点击安全授权。

## Git交付与复核入口

继续codex/f1-human-review，已提交Core迁移增量c9d956b；本轮余下源码、测试、迁移说明、符号审计、真实截图及可移植样例一并交付同一草稿PR #1：https://github.com/Jim-ked/Flight-procedure-design/pull/1 。最终提交SHA以该PR远程分支为准。main保持332b1567d5525624f9b1869724dfd7dcf1ee6644，不合并、不强推。三份doc/用户原件未纳入本轮提交，Legacy/recovered/reverse-analysis/WsTools-master原件未改。

本轮是可审阅的统一修订代码交付，**不是F0/F1整体验收通过**；专业图符异常仍为阻塞。samples/Unified/tianjin-unified.fpd.json来源于真实保存项目，已清除本机DWG绝对关联；四类CSV及空项目模板可用于人工复核。
