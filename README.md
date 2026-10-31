# 固定翼飞行程序设计 / Flight Procedure Design

基于 AutoCAD 的固定翼飞行程序辅助设计软件。当前首发宿主为 **AutoCAD 2020**。

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

项目是旧式 .NET Framework 工程，当前生产项目目标为 .NET Framework 4.0；反编译的 WindSpiral 工程目标为 `net48`。在 Windows 上使用与项目匹配的 .NET Framework MSBuild。已有兼容构建入口为 [`build-compat.ps1`](build-compat.ps1)：

```powershell
powershell -ExecutionPolicy Bypass -File .\\build-compat.ps1
```

AutoCAD 安装目录中的 `AcDbMgd.dll`、`AcMgd.dll`、`accoremgd.dll` 等宿主程序集不复制进仓库。若要在 AutoCAD 2020 中 `NETLOAD`，需要在本机配置这些宿主引用，并按本地 MSBuild/AutoCAD 环境验证输出；仓库中的项目内研究 DLL 和恢复 DLL 保持原样。

## 当前状态

本仓库建立的是产品化整合前的真实基线。不要把 `recovered/`、`reverse-analysis/`、Legacy 或历史版本合并成新的 clean implementation。后续工作应先基于 GitHub 代码事实开展 WindSpiral 功能级审计，再单独提交产品化变更。
