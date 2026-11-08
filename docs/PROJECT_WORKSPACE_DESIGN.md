# 项目工作区现行设计

本文件是项目模块唯一现行设计，替代 F0/F1 项目管理方案。其他 F0/F1 设计、交付记录及恢复资料仅为历史证据，不指导本模块新开发。程序组织、专业图符、复飞、等待、标称航迹和保护区算法不在本轮范围。

## DWG 生命周期

一张 DWG 对应一个项目。入口为 AutoCAD 原生 NEW/OPEN；项目新建在当前 DWG 中初始化资料，不更换或清空图形。当前 Document/Database 是会话身份，禁止独立选择 JSON、路径匹配和人工关联。每个打开文档有独立状态，关闭释放状态。

辅助文件为 `Path.ChangeExtension(dwg, ".fpd.json")`。业务编辑同时在 DWG 命名对象字典保存 JSON 快照，使原生保存提示、撤销、另存和业务资料一致；不包含生成/还原图形指令。原生保存成功后导出同名辅助 JSON；失败保持明确错误状态，不报告资料已保存。未命名 DWG 的数据仅在当前文档中，须原生保存。

重开使用 DWG 内业务快照；无快照时不从辅助 JSON 自动初始化项目。发现两者不一致时使用该 DWG 内快照并提示。没有辅助 JSON/快照时显示未初始化项目，绝不删除、重绘、还原 CAD 实体。历史 DwgPath 仅作反序列化兼容，运行时不使用，不参与关联，不写入新 JSON。

## 四类基础资料

- 定位点：Ident、Latitude、Longitude；DBPoint + 独立名称文字。旧 Elevation 仅兼容原文件，不录入；已知旧CAD Z兼容保留，不用作程序高程。程序类型和程序高程属于未来路径引用接口，本轮不实现。
- 障碍物：Ident、Latitude、Longitude、TopElevation、GroundElevation；自身高度由顶标高减地面高程计算，不在项目表格重复显示或录入。WindSpiral 原始 Obst 块，Z=顶标高，仅另标编号。
- 导航台：Ident、Kind、绝对 Latitude/Longitude；原始块按审计映射使用，仅标代号。旧频率等资料兼容保存，但不进入新基础录入和 CSV；不增加容差、半宽、扩张角等计算参数。
- 跑道：宽度、两个相反方向编号、两个物理端的经纬度及标高。每方向 THR 默认本物理端、DER 默认对端物理端。内移 THR 和特殊 DER 可独立覆盖；旧六组数据按实际差异保留。轮廓保留两物理端标高，仅标方向编号及必要 THR/DER 位置。

所有基本坐标按 ARP 选定 CGCS2000 三度带中央经线。手输接受十进制度或度分秒；CSV 只接受十进制度。CAD X=东、Y=北，米制；缺失高程仅绘图使用 Z=0，占位不得写回为真实高程。

## 交互与 CSV

新增、修改、删除、导入、导出复用现有业务方法。资料确认后继续调用同一 CAD 实体同步服务；不提供手动绘制按钮。导出针对当前类别，模板仅放在导入窗口内。正式删除同步清理该记录的 CAD 实体和历史，人工修改冲突时保留资料并提示。

CSV 定义由 Core 中四个 Csv 类统一提供：模板调用同一个 Export 空集合；导入严格核对字段顺序和列数。跑道 CSV 物理端必填，THR/DER 三字段整组留空表示默认。导航台没有相对输入。编辑窗口统一使用 WPF 对话框；定位点只有标识、纬度、经度，障碍物增加顶标高和地面基准高程，导航台增加类型，跑道按两个方向填写物理端，THR/DER 默认值按需展开覆盖。所有窗口支持十进制度和度分秒输入；CAD拾点取消保留此前输入。

正算、反算和 CAD拾点统一放在现有“工具”页，复用 ForwardCoordinate、InverseCoordinate 和 PickToolCoordinate。项目页不提供坐标转换按钮或独立坐标窗口；后台项目投影继续使用同一 Core 投影代码。程序、工具、成果页不迁移、不调整其业务布局。

## 界面布局（WPF，2026-11-08）

本节合并已审核 WPF UI 规格，源码业务基准为 `19554c66ae86920096f2c20482b9ad06df560da7`。实施附件只作输入，项目模块唯一现行设计仍为本文件。历史 WinForms 项目页布局不再生效。

### 1. 施工边界

保留 AutoCAD 2026、`.NET 8`、现有 `PaletteSet` 及四个顶部页签“项目 / 程序 / 工具 / 成果”。当前 WinForms `WorkspacePanel` 的“项目”TabPage 中仅嵌入一个 WPF `ProjectWorkspaceView` (`ElementHost.Dock=Fill`)。不要新增第二个 PaletteSet，不引入 WebView2、DevExpress、Prism、第三方 UI 主题库；不迁移其余页签。

项目页替换为 XAML 控件树，原 WinForms `ProjectPage()` 及其动态布局辅助不再负责项目页可见控件。非 UI 的业务代码优先复用；必须避免新旧两张项目页并行显示或“双事件”同时操作 CAD。

工程 `Fpd.AutoCAD.csproj` 已启用 `UseWPF=true` 与 `UseWindowsForms=true`。仅增加必要的 WPF 与 WindowsFormsIntegration 引用，勿改 Core 数据结构、AutoCAD API 项目或.NET目标框架。

### 2. 必须呈现的界面（无需注释性文案）

已建项目从上到下只显示：

1. 项目名称 + **编辑**；机场名称单独显示；单独完整行显示 ARP。长项目名允许省略但悬停显示全名；项目名与机场名可自然换行并以悬停显示全名；ARP 始终换行，不截断。
2. **定位点、障碍物、跑道、导航台** 等宽分类标签。
3. **查找**文本框。
4. 两行操作：**新增、修改、删除**；**导入、导出**。两行均采用等分列宽，不根据屏幕宽度跳动为“一行五按钮”。
5. 唯一的**数据表**，充满剩余可用高度；底部仅显示“共 N 项 / 已选 M 项”。

不显示“绘制”、CSV 模板独立按钮、内部 FPD 名称、投影带/EPSG、诊断说明或其他解释文字。导入窗口内保留模板入口；图形更新由原业务调用。顶部四页签原样保留。

未建项目显示同一屏幕内的项目设置面板，字段为“项目名称、机场名称、ARP 纬度、ARP 经度、确定”，不同时显示一堆禁用的数据按钮和大块空表。经纬度输入延续当前度分秒/十进制度解析能力。

### 3. WPF 技术结构

- `ProjectWorkspaceView.xaml` + `.xaml.cs`：纯展示、列表选中和双击事件、声明按钮命令；不直接打开 AutoCAD 数据库事务。
- 最小 `ProjectWorkspaceViewModel`：`INotifyPropertyChanged`、当前项目摘要、4个分类标签、当前分类、搜索关键字、可视行集合、操作命令、选中数量。可以用 `ICollectionView` 过滤列表；不新增第三方 MVVM 包，也不复制整套项目业务数据仓库。
- `ProjectUiBridge`（或合并在现有 WorkspacePanel 的小型适配器）：将当前选择类别与**稳定 DataId** 及命令转发给已存在的 `EditFix/EditObstacle/EditRunway/EditNavaid`、CSV 和 DWG 服务。旧实现 `CurrentGrid.SelectedRows`、`_dataTabs.SelectedIndex` 等 WinForms 依赖需转换为与 UI 无关的 `SelectedCategory`、`SelectedDataIds`；不可仅隐藏 WinForms 控件，后台仍从它们读选择。
- 项目激活、DWG 切换时由原 `BindProject`/刷新入口更新 ViewModel；避免每次搜索逐行创建控件或重建项目对象。UI 线程只更新数据，任何实际 CAD API 交互继续通过现有 `AirportCommandRequested`/`FPDBASE` 路径。
- `ProjectDataGrid` 行选中/双击应保持现有数据编辑与高亮行为，不新增 CAD 绘制、移动或缩放机制。避免将普通搜索键入与 CAD 图形同步绑定。

### 4. 布局硬性约束

以 WPF **DIP**（与物理像素不同）为准，使用 Grid `Auto` / `*` 排列：项目摘要 Auto，分类 Auto，搜索 Auto，操作1 Auto，操作2 Auto，数据表 `*`，数量 Auto。数据表必须位于有界高度的 Grid `*` 行，外面**绝不包裹 ScrollViewer、StackPanel 或无限高度 Canvas**。不存在通过 `Canvas.Left/Top` 计算按钮位置的逻辑。

四分类等宽，不因标签文字而整体向左拥挤；两行按钮在 PaletteSet 常用停靠宽度内互不重叠。各行之间 5—10 DIP，自上而下固定次序。按钮建议高34 DIP，数据行30 DIP，表头32 DIP，分类39 DIP；根内边距左右10 DIP。尺寸是单个控件的视觉规范，不允许按窗口宽度重新计算整行像素坐标。

项目面板使用目前 PaletteSet 实际最小宽度约390物理像素（高DPI按宿主行为复核），建议检查 390、440、560 DIP 及1.0/1.5/2.0 DPI场景。WPF 各坐标信息应自然换行或允许省略，且 ARP 完整可读，按钮和标签绝不重叠。极端较窄尺寸时可限制 PaletteSet 的实际可用最小宽度，不通过把列挤成几像素解决。

同一个 `DataGrid` 为4类数据提供视图与滚动，切换分类时根据**确定的列清单**替换列；不要创建4份全新的业务表格。

- 定位点：名称（最小宽110）/纬度（最小宽122）/经度（最小宽122）。
- 障碍物：编号（100）/顶标高 m（110）/基准高程 m（120）/纬度（122）/经度（122）。
- 跑道：跑道方向（150）/宽度 m（110）。
- 导航台：名称（100）/类型（95）/纬度（122）/经度（122）。

以上宽度以 DIP 为单位；各列应设置合理 MinWidth，窗口不足时**横向滚动**，不得无条件 `*` 缩成残缺数字。当前选择行对应的稳定 ID 不作为用户列展示。滚动条由 `DataGrid` 原生管理，纵向支持87条以上记录、滚轮、PageDown、End；横向支持经纬度查看。表格列标题、可见文本和数字格式必须是中文/现有业务字段；不出现说明占位行。

筛选只更新当前分类，最好使用 `ICollectionView.Refresh()`，应尽量保留选中项和首行或滚动位置。不执行同步 CAD、DWG 保存和图纸重绘。批量导入后按原刷新接口更新数据表，不连续全量重建 4 张表。

### 5. WPF 参考 XAML 的使用说明

已审核布局附件为 `FPD_Project_WPF_UI_Design_Package/FPD_ProjectWorkspaceView_WPF_layout.xaml`，正式控件为 `src/Fpd.AutoCAD/Views/ProjectWorkspaceView.xaml`，该文件是**可解析的控件树结构与绑定命名约束**，不是声称已经可以 `NETLOAD` 的成品源码。其 `DataGrid` 故意不声明固定列，列定义按上述四份字段清单，在分类切换时生成。事件 `ProjectDataGrid_SelectionChanged` / `ProjectDataGrid_MouseDoubleClick` 需要由 Codex 接到现有逻辑。可将文件作为正式 View XAML 的基础，不得机械地再套一层 WinForms `Panel` + WPF `ScrollViewer`。

`IsInitialized`、`ProjectName`、`AirportName`、`ArpDisplay`、`DraftProjectName`、`DraftAirportName`、`DraftArpLatitude`、`DraftArpLongitude`、`Categories`、`SelectedCategory`、`SearchText`、`VisibleRows`、`CountDisplay`、`CreateProjectCommand`、`EditProjectCommand`、`AddCommand`、`EditCommand`、`DeleteCommand`、`ImportCommand`、`ExportCommand` 是约定的属性名；若名称已有工程兼容要求，先统一修改 XAML 与接口命名，**不增加第二份同功能 ViewModel**。

#### 特别避免的问题

- 把 WPF 视图盖在 WinForms 旧项目页上而旧事件仍处理操作；
- 仅替换页面外观，不修复旧代码读取 `CurrentGrid.SelectedRows` 的耦合；
- 控件在 `TabControl` 内重复嵌套无限高度滚动；
- 用 WPF `UserControl` 直接执行 `Document.LockDocument`、`Transaction` 等 CAD 操作；
- 使用自绘滚动条或引入商业控件解决87条数据；
- 为了迁移项目页而修改其他页签、程序路径、图符块、坐标算法、跑道和图层业务规则。


## 项目标注与编辑窗口

项目定位点、障碍物、导航台和跑道名称文字的新建默认字高为 500 CAD 模型空间单位。该值不再乘注释比例换算；用户可在 AutoCAD 中人工调整文字高度，人工编辑保护继续按实体几何指纹工作。字体高度不改变 DBPoint、块、跑道轮廓或其他图形实体的尺寸。

四类编辑窗口统一采用简洁 WPF 对话框，共用标题、字段排列、输入框和底部操作区样式。窗口只显示该类别确定的业务字段，不重复显示经纬度格式说明；CAD拾点作为同一位置操作，取消时保留先前输入。

## 图层与实体更新

新项目使用四个中文公共图层：基础_定位点、基础_障碍物、基础_跑道、基础_导航台；历史 FPD_ 图层只作兼容，不自动删除、改名或覆盖。项目页显示、程序页关闭；拾取临时显示相关公共参考图层并在 finally 恢复原 off/frozen 状态，其他图层不改。

明确的数据新增、修改、导入继续使用现有实体身份/指纹同步及按类别、稳定 ID 更新的命令路径。无变化不插入；数据改变且图形未变才更新；人工改动、部分删除、重复实体均提示冲突并保留，不自动补回。DWG 保存/打开/切换从不同步图形。数据删除保留既有图形。历史实体没有可靠身份时提示冲突，禁止静默接管或重叠补建。

## 验收与未决项

保留现有构建和 Core 基础检查，主要验收是在 AutoCAD 新 DWG 中创建项目、录入四类资料、CSV 往返、页面图层切换、原生保存重开及人工改图保护。只记录实际完成操作，宿主未执行的步骤不得写为通过。项目块库从可正常读取的 `docs/symbol-audit/symbol-atlas.dwg` 原样克隆四个原始定义，避开完整旧库读取异常；提取实体类型、数量、属性和边界与原始块表一致，来源和SHA见 `src/Fpd.AutoCAD/Symbols/project-block-provenance.json`。ILS 原始台站块尚未确认，保留资料并提示未绘制，不把 NLOC 猜作 ILS，不新增 GP/保护区业务。


## 历史宿主检查记录（不代表本轮 WPF 验收）

- AutoCAD窗口实际创建项目、录入天津ARP、打开定位点窗口并保存TJ001资料；初次绘图暴露ByLayer透明度读取错误，已通过原生堆栈定位并修正。窗口的最终完整交互验收以实际后续记录为准。
- 最终构建：Release，0警告/0错误；原有Core检查42/42。
- 独立AutoCAD 2026原生宿主实际执行：创建当前DWG项目；分别加入并绘制定位点、障碍物、16R/34L跑道、VOR/DME/NDB；四类CSV往返；公共图层显示/关闭；重复绘图16实体保持16；移动文字后改资料再次绘图，冲突原图保留。
- 原生QSAVE、SAVEAS均实际生成相应同名JSON；重开资料为1/1/1/3条、16实体；复制为无JSON的DWG后仍从自身快照读取资料，实体保持16。该记录为原生宿主执行，不冒称所有编辑窗口都已人工验收。
- 原生保存事件sender会产生新的Database托管包装对象，必须按数据库原生指针匹配会话；不能ReferenceEquals比较包装对象。临时自动保存文件不作为另一张DWG导出JSON。
- 未决：ILS原始台站块未确认，保留资料并提示未绘图。CAD拾取取消、POINT登记和多文档窗口切换等交互仍需最终人工复核；本轮未改专业程序图符和计算算法。

最终图面复核：已用本轮模块DLL在独立AutoCAD窗口打开原生另存验收图，项目摘要、四公共图层、跑道轮廓可见；图面宽度测量为45m。完整四类编辑窗口逐条人工操作仍未全部完成，不以原生宿主脚本代替该结论。

## WPF 交付与人工验收

本轮只替换项目页与必要的业务适配，不修改 CAD 同步机制、图符颜色、WindSpiral 原始资源、专业图符映射及各类绘制规则。项目页只使用一个 ElementHost 和一个原生 WPF DataGrid；旧项目页 WinForms 控件不再创建或用于选择状态。

执行正常 Release 构建与现有 Core 检查，提供版本明确的完整加载目录。最终由用户在新 AutoCAD 2026 进程中 NETLOAD，检查项目创建、87 条以上定位点的滚轮/纵向滚动条/PageDown/End/横向滚动、四类切换、两行按钮、编辑后的选择与滚动位置、停靠宽高变化、保存重开。未进行的宿主操作不写为通过。保持 PR #1 为 Draft，不合并 main；交付后停止扩展，等待代码审核与人工反馈。
