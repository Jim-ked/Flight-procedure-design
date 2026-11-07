# 固定翼飞行程序设计 / Flight Procedure Design

基于 AutoCAD 的固定翼飞行程序辅助设计软件。当前 F0.1 宿主为 **AutoCAD 2026（.NET 8）**。

当前业务顶层为 `Departure`、`Arrival`、`Approach` 三类 `Procedure`。`Missed Approach` 属于 `Approach` 内部；`Holding` 是可嵌入 Procedure 的完整机动/设计能力，不是第四类 Procedure。

仓库保留当前项目的生产源码、测试源码、WindSpiral/WsTools 恢复资产、反编译与 IL 分析材料、Legacy 实现、研究 DLL、CAD 样例、fixtures、阶段报告和历史工程文件。首次提交是当前代码事实快照，不代表产品化完成。

## 从哪里开始

- Solution：[`Fpd.sln`](Fpd.sln)
- 当前生产项目：`src/`
- 当前测试项目：`tests/`
- WindSpiral 恢复与功能证据：`recovered/`
- 原始材料、反编译、类型图和调用图：`reverse-analysis/`
- 恢复的 WsTools 工作区与样例：`WsTools-master/`
- 受控详细设计文档和规范资料：`doc/`
- 事实性代码索引：[`docs/CODEBASE_MAP.md`](docs/CODEBASE_MAP.md)

代码标识使用英文；用户可见界面默认使用中文。三类 Procedure 的数据组织和设计上下文，与 CAD 专业工具负责的定位点、标称航迹、保护区和障碍物评价共同构成当前软件方向。

## 构建和 NETLOAD

F0 运行工程为 `src/Fpd.AutoCAD` 和 `src/Fpd.Core`，安装 .NET 8 SDK 与 AutoCAD 2026 后运行：

```powershell
./build-f0.ps1
# 自动查找本机 AutoCAD 2026 安装目录；也可指定 -AutoCAD2026Dir 'D:\SOFT\CAD\AutoCAD 2026'
```

该脚本编译插件并运行 Core 测试，不使用外部 NuGet 包。也可直接执行：

```powershell
dotnet build src/Fpd.AutoCAD/Fpd.AutoCAD.csproj -c Debug
dotnet run --project tests/Fpd.Core.Tests/Fpd.Core.Tests.csproj
```

在 AutoCAD 2026 中 `NETLOAD` 加载 `src/Fpd.AutoCAD/bin/Debug/net8.0-windows/Fpd.AutoCAD.dll`，保持同目录的 `Fpd.Core.dll`。执行 `FPD` 打开工作区、`FPDCLOSE` 隐藏、`FPDPOINT` 绘制明确选中的单个 Fix。ARP 使用工具页的“绘制 ARP”。已加载的 DLL 会被宿主锁定，需要独立构建目录时使用 `./build-f0.ps1 -OutputDirectory tmp/F01-build`，并加载该目录中的 DLL。

项目页显示紧凑摘要，通过“编辑项目 / 机场”修改唯一 ARP，确认后自动确定投影带。定位点与障碍物表支持新增、修改、删除、标识查找、多选、复制和粘贴新增（Ctrl+C/V/A）、CSV 整批导入，以及绘制所选或全部点。重复标识、错误坐标和缺少必填字段会报告源行号，整批拒绝写入。

CSV 可带表头并调整列顺序；无表头时按以下顺序。纬经度为十进制度，高程/标高/高度为米，数值小数点使用 `.`，可选字段留空。支持逗号、分号和 Tab 分隔，含分隔符的内容用双引号包裹。

- Fix：`Ident,Latitude,Longitude,Elevation`，前三列必填。
- Obstacle：`Ident,Latitude,Longitude,TopElevation,Height,GroundElevation`，前四列必填。`TopElevation` 是顶标高，`Height` 是自身高度，`GroundElevation` 是地面高程，三者分别保存，不自动推算。

样例见 `samples/F01/`。批量绘图使用 `FPD_FIX`（绿色圆十字）和 `FPD_OBSTACLE`（红色三角）图层，原生块及属性包含名称与可选障碍物顶标高；字高在项目页设置，默认 50 m。绘制明确新增图形，不自动覆盖已有点；一次批量操作可用 AutoCAD 原生撤销。`FPDPOINT` 继续生成 DBPoint 与名称文字。

程序页通过选择已有 Fix、追加、删除引用、上移/下移编辑顺序，允许重复引用。工具页转换结果就地显示。成果页操作当前 DWG 的实际 FPD 图层、定位图面，并导出 Fix/障碍物 CSV 和程序顺序 JSON；尚无专业算法结果。

项目保存为 `.fpd.json`，DWG 使用 AutoCAD 原生保存。所有点均使用 ARP 决定的同一 CGCS2000 三度带 CM；WCS X=东坐标，Y=北坐标，高程未提供时 Z=0，不减去 ARP。不支持 DMS 输入或垂直基准换算。当前最小投影适用 CM75E–CM135E，点距中央经线不得超过 6°。

本机宿主与验收记录见 [F0 交付报告](docs/F0_DELIVERY_REPORT.md)，投影独立参照见 [PROJ_REFERENCE.md](tests/Fpd.Core.Tests/PROJ_REFERENCE.md)。

### 历史验证工程

保留的历史工程使用旧式 .NET Framework 4.0；反编译的 WindSpiral 工程目标为 `net48`。这些历史工程在 Windows 上使用与项目匹配的 .NET Framework MSBuild。已有兼容构建入口为 [`build-compat.ps1`](build-compat.ps1)：

```powershell
powershell -ExecutionPolicy Bypass -File .\\build-compat.ps1
```

AutoCAD 安装目录中的 `AcDbMgd.dll`、`AcMgd.dll`、`accoremgd.dll` 等宿主程序集不复制进仓库。若要在 AutoCAD 2020 中 `NETLOAD`，需要在本机配置这些宿主引用，并按本地 MSBuild/AutoCAD 环境验证输出；仓库中的项目内研究 DLL 和恢复 DLL 保持原样。

## 当前状态

本仓库建立的是产品化整合前的真实基线。不要把 `recovered/`、`reverse-analysis/`、Legacy 或历史版本合并成新的 clean implementation。后续工作应先基于 GitHub 代码事实开展 WindSpiral 功能级审计，再单独提交产品化变更。
