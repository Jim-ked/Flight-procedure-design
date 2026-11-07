# F1 基础资料与程序组织交付状态

2026-11-07。F1代码已实现，构建通过；实机验收部分通过，修正版未加载。按用户后续明确要求，提交待人工核验版本；本提交不表示F1验收通过。

F0.1已实机验收并独立推送main：[332b1567d5525624f9b1869724dfd7dcf1ee6644](https://github.com/Jim-ked/Flight-procedure-design/commit/332b1567d5525624f9b1869724dfd7dcf1ee6644)。详见F01_DELIVERY_REPORT.md及17张真实截图。原宿主0xc0000409的外部OLE对象来源仍未确定，本次未再次观察到崩溃。

## 实际实现

沿用Fpd.Core/Fpd.AutoCAD、.NET8、WinForms PaletteSet及四栏导航，无新通用框架。设计见F1_IMPLEMENTATION_DESIGN.md。

- 跑道：两方向标识、宽度、两实际端、各方向THR/DER独立经纬度及标高；六行编辑表、CSV、CAD拾取；项目投影计算长度/格网方向；FPD_RUNWAY原生轮廓、中心线、THR横线、DER圆、标高及名称。
- 设施：VOR/DME/NDB/ILS及对应MHz/kHz、频道、VOR磁差、独立LOC/GP位置和GP角度；录入、CSV、CAD选择/拾取、FPD_NAVAID原生符号及名称属性。这些是基础设计示意符号，不是AIP出版图式。
- CAD：PromptStatus处理取消，拾点UCS转WCS再按项目CM反算；已绘Fix/Obstacle/Navaid按标识及位置匹配项目，不自动覆盖移动后的图形。普通点可回填新增窗口，障碍物顶标高仍由用户明确确认。
- 程序：保留主顺序，增加Main/Missed、Common/RunwayTransition/Transition及跑道端分段；各段独立有序Fix引用，允许重复；Missed仅适用于Approach。Fix更名/删除同步段内引用，程序及分段刷新保持选择，旧跑道文本保留。
- 工具与成果：直接选择跑道/设施绘图、CAD选择及就地坐标显示；真实图层查看，新增跑道/设施CSV及包含分段的程序JSON导出，不要求先创建Procedure。

CSV使用英文标题、十进制度、米；设施频率单位分类型，名称可空，位置/标高必填。整批解析后写入，错误报告源行号。samples/F1仅为合成验收数据，不是正式机场资料。16方向THR在A侧，DER独立保存在B侧；34方向相反。

## 构建与Core证据

环境：AutoCAD R25.1.60.0.0，SDK8.0.427，插件net8.0-windows，Core net8.0。

初版F1使用build-f0.ps1成功构建，0警告/0错误，Core **33 passed / 0 failed**。新增5项覆盖独立PROJ反算（含跨带点）、旧JSON集合缺省、跑道位置独立CSV/JSON回读、设施类型/单位及不完整GP拒绝、程序Missed约束和段内重复引用同步。

本轮后续只修改AutoCAD代码，定向dotnet build成功：0警告/0错误，输出tmp/F1-ui-fix。修正版DLL SHA256：373500E3B87D0041D02B70CC3E0260147A63EE3DA49B88A2B47918BE953591DD。Core前后DLL SHA256一致：0C46F15BADEED1E2742E3339F85C7278B217BC08BE3A3353FDD9FDE4A35A7848；沿用33/33证据，没有重复运行Core测试。

## 已完成的F1实机增量

| 操作 | 真实结果 |
|---|---|
| 初版F1加载及工作区 | tmp/F1-host-check DLL在新进程成功加载，FPD打开，出现跑道/设施局部表 |
| 跑道CSV与绘图 | 导入16/34一条，宽45m、长度3441.0m、格网方向165.227°；原生轮廓/中心线/标记生成，FPD_RUNWAY有12个实体 |
| 设施CSV与绘图 | 导入TVOR/TDME/TNDB/TILS四条，符号/名称/ILS独立GP可见；未宣称图式符合出版规范 |
| 图面选择 | 选择TVOR块后列表匹配1条，核对标识和WCS位置 |
| 设施专用资料 | ILS窗口回读LOC位置、110.3MHz、独立GP位置及3° |
| 跑道拾取取消 | 焦点交回CAD后Esc返回，六个位置原值保留；焦点问题见下节 |
| 分段顺序 | 复飞段追加重复TJ907并上移，顺序TJ906→TJ907→TJ907→TJ906，当前段保持 |
| 多程序选择 | 新建第二个Departure并追加TJ907后，仍选中第二程序 |
| 项目与图纸保存 | JSON实际保存1跑道、4设施、2程序及上述段顺序；DWG原生命令QSAVE后正常退出旧DLL会话 |

截图docs/screenshots/F1/：01初版图面与图层；02跑道编辑窗显示缺陷；03复飞段顺序；04第二程序选择；05CAD设施匹配；06ILS独立LOC/GP。全部来自真实AutoCAD；01/02保留的是问题证据，不能当作修正通过截图。

设施绘图有一次自动化重复点击：首次截图未显示异步结果时又点击，宿主随后显示两次“绘制4个设施”，成果页有12个设施层实体（8块和两套GP圆/文字）。没有删除、撤销或再次绘制，旧图保留在tmp/F1-validation/tianjin-f1.dwg。此为操作失误，后续不得用立即重试确认异步命令。

## 按实测证据完成的代码修正（待定点复验）

- 跑道端部文字近南北方向时重叠：由单纯法线偏移改为按最近实际端分组，垂直排文字并加原生引线。
- 跑道编辑窗未选中行白底浅字、按钮压缩；设施窗口类型切换尺寸未按DPI处理：补深色单元格、构建期SuspendLayout/ResumeLayout、最小按钮高度、屏幕居中及DPI行高/尺寸。程序段输入框同步采用深色样式。
- 拾取开始后Palette仍持有键盘焦点：FPDBASE期间让出KeepFocus，操作结束后恢复；取消不写位置。
- 跑道/设施绘图成功后关联当前DWG，与已有点绘图行为一致。

当前已编译，尚未通过修正后的AutoCAD复验。旧会话已保存并正常关闭；新会话打开tmp/F1-validation/tianjin-ui-fixed.dwg（独立副本），尚未加载修正版DLL。JSON副本同名保留完整资料；旧JSON另存tianjin-before-ui-fix.fpd.json。

## 执行约束与未完成事项

用户明确要求停止重复加载和重复测试。今后直接沿用已通过证据，不重复F0.1、无修改的Core测试、导入及分段编辑。只允许在用户明确允许后，对上述修改做定点复验，并完成尚未验证的新拾取/输出/回读。

再次进入NETLOAD流程的按键动作被自动审批拒绝，理由是与用户“不要重复加载或重启验证”的要求冲突；按键未执行。没有改用其他入口、CLI或脚本绕过。当前停止界面输入，也没有改变SECURELOAD/信任路径。随后用户取消自动复验，并明确要求先完成Git提交，由网页端配合人工核验；因此保留未完成状态提交供核验。

人工核验剩余项如下，直接沿用已通过记录，无需重做整套测试：

- [ ] 修正后的跑道标注不重叠，编辑窗深色单元格、按钮及DPI布局正确。
- [ ] 拾取时键盘焦点交给CAD，成功拾点回填及Esc取消均正确。
- [ ] 新增跑道/设施CSV、包含程序分段的JSON导出正确。
- [ ] 新增资料和修正图纸保存、回读后保持。

本次仅提交供人工核验，不把上述未完成项改为通过。构建可复现命令：`./build-f0.ps1 -OutputDirectory tmp/F1-review`；本机已构建修正版位于`tmp/F1-ui-fix/Fpd.AutoCAD.dll`，同目录须保留Fpd.Core.dll。这里记录命令供人工使用，本轮未再次运行或操作AutoCAD。

F2首项准备见F2_FIRST_TOOL_PREPARATION.md：选A2离场转弯点距离计算，复用已恢复数学/CAD交互，先核实5m常量规范依据；本轮没有迁移专业算法。历史Legacy、recovered、reverse-analysis、WsTools-master及用户未跟踪资料均保留。

当前全部修改/未跟踪文件已再备份至 `tmp/F1-final-source-backup-20261107-125358/uncommitted-files.zip`，另有tracked.patch、status.txt及文件清单。ZIP SHA256：`445E479F975243CAC148D2352BB31213069ED0BD6DE63184DECDBBB468033E6D`。
