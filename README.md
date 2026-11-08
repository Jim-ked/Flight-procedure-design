# 固定翼飞行程序设计 / Flight Procedure Design

基于 AutoCAD 的固定翼飞行程序辅助设计软件。当前宿主为 **AutoCAD 2026（.NET 8）**。

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

在 AutoCAD 2026 中 `NETLOAD` 加载 `Fpd.AutoCAD.dll`，保持同目录的 `Fpd.Core.dll` 和完整 `Symbols/`。执行 `FPD` 打开工作区，`FPDCLOSE` 隐藏。已加载的 DLL 会被宿主锁定；可用 `./build-f0.ps1 -Configuration Release -OutputDirectory tmp/project-workspace-release` 构建独立目录，在新宿主进程加载。

项目模块唯一现行设计为 [PROJECT_WORKSPACE_DESIGN.md](docs/PROJECT_WORKSPACE_DESIGN.md)。一张 DWG 对应一个项目，通过当前 DWG 创建/修改机场与 ARP；没有 JSON 独立打开、路径匹配和人工关联。原生 DWG 保存成功后写入同名 `.fpd.json`；打开/切换不重绘图形。

项目页管理定位点、障碍物、物理跑道和导航台，支持编辑窗口、CAD拾取、搜索、整类CSV导入/导出及模板。CSV必须使用当前界面导出的固定表头和字段顺序，坐标为十进制度；`samples/F01/`、`samples/F1/` 为历史格式资料，不作当前模板。手动坐标接受十进制度和度分秒。

定位点使用DBPoint与独立名称；障碍物及已确认的VOR/DME/NDB使用WindSpiral原始块，图面只标编号或名称；跑道按两物理端及可选THR/DER位置绘制。编辑后更新、绘制所选/全部和FPDPOINT采用同一身份同步规则，无变化不重复插入，人工修改冲突保留。项目/程序页面仅切换四个项目公共图层的常规显示。

所有基本坐标使用ARP确定的CGCS2000三度带CM；WCS X=东、Y=北，长度和高程为米。缺少高程只在平面绘图中使用Z=0占位。坐标转换入口在项目页，复用既有正反算，提供XYZ、复制及拾点。投影适用CM75E–CM135E，点距中央经线不得超过6°；不实施垂直基准换算。

本机宿主与验收记录见 [F0 交付报告](docs/F0_DELIVERY_REPORT.md)，投影独立参照见 [PROJ_REFERENCE.md](tests/Fpd.Core.Tests/PROJ_REFERENCE.md)。

### F1 历史版本与验收资料

以下保留F1历史交付背景，项目模块已由现行设计替代；程序相关历史记录不在本轮调整。

核验入口：[F1交付状态与剩余清单](docs/F1_DELIVERY_REPORT.md)、[实施设计](docs/F1_IMPLEMENTATION_DESIGN.md)、[真实截图](docs/screenshots/F1/)、[合成CSV/JSON样例](samples/F1/)。[F2首工具准备](docs/F2_FIRST_TOOL_PREPARATION.md)仅为后续范围，没有提前开发专业算法。

### 历史验证工程

保留的历史工程使用旧式 .NET Framework 4.0；反编译的 WindSpiral 工程目标为 `net48`。这些历史工程在 Windows 上使用与项目匹配的 .NET Framework MSBuild。已有兼容构建入口为 [`build-compat.ps1`](build-compat.ps1)：

```powershell
powershell -ExecutionPolicy Bypass -File .\\build-compat.ps1
```

AutoCAD 安装目录中的 `AcDbMgd.dll`、`AcMgd.dll`、`accoremgd.dll` 等宿主程序集不复制进仓库。若要在 AutoCAD 2020 中 `NETLOAD`，需要在本机配置这些宿主引用，并按本地 MSBuild/AutoCAD 环境验证输出；仓库中的项目内研究 DLL 和恢复 DLL 保持原样。

## 当前状态

本仓库建立的是产品化整合前的真实基线。不要把 `recovered/`、`reverse-analysis/`、Legacy 或历史版本合并成新的 clean implementation。后续工作应先基于 GitHub 代码事实开展 WindSpiral 功能级审计，再单独提交产品化变更。
