# 固定翼飞行程序设计 / Flight Procedure Design

基于 AutoCAD 的固定翼飞行程序辅助设计软件。当前 F0 宿主为 **AutoCAD 2026（.NET 8）**。

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

在 AutoCAD 2026 中 `NETLOAD` 加载 `src/Fpd.AutoCAD/bin/Debug/net8.0-windows/Fpd.AutoCAD.dll`，保持同目录的 `Fpd.Core.dll`。执行 `FPD` 打开工作区、`FPDCLOSE` 隐藏、`FPDPOINT` 绘制选中 Fix（未选时绘制 ARP）。

创建项目后填写 ARP 十进制经纬度；Fix 支持新增、修改和 CSV 导入。CSV 列为 `Ident,Latitude,Longitude,Elevation`，高程可空，示例见 `samples/F0/tianjin-fixes.csv`。程序可输入有序 Fix 标识，支持重复引用。

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
