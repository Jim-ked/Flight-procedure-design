# Round 1 动态环境（2026-10-27）

收尾更新：原件与运行副本85文件hash均复核一致，见`logs/closure-integrity.json`。目标副本映像加载但RCL不可用；业务验证受阻，未完成类型加载诊断。测试图曾另存桌面，已作为隔离事件记录，Observer不再对桌面路径采集实体；当前没有继续该图实验。见[实验索引](experiment-index.md)和`logs/input-interference.md`。

## 当前宿主（直接读取）

- AutoCAD 2026 简体中文，acad.exe 产品/文件版本 R25.1.60.0.0。
- 路径：`D:\SOFT\CAD\AutoCAD 2026\acad.exe`；调查时 PID **28660**，窗口标题 `[开始]`。
- API 三件均位于该安装目录：`acmgd.dll`、`acdbmgd.dll`、`accoremgd.dll`；AssemblyVersion 均 **25.1.0.0**，FileVersion 均 **25.1.60.0.0**。
- 实际加载 CLR：`C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.12\coreclr.dll`，文件版本 8,0,1224,60305。
- 实际 hostfxr：`C:\Program Files\dotnet\host\fxr\9.0.5\hostfxr.dll`。hostfxr 版本不是 CLR 版本。
- 安装内 `acdbmgd.runtimeconfig.json` 为 net8.0，声明 Core/WindowsDesktop/AspNetCore 8.0.0；以上实际进程模块证据优先。
- `dotnet --info`：无 SDK；有运行时 7.0.20、8.0.12、9.0.5。采用系统 Framework csc + 显式 .NET8 引用尝试兼容性编译；不声称 SDK 工程已构建。

## 原始目标（不得与本机混同）

- `WsTools-master/WindSpiral2026/WindSpiralBasic.dll`，原 SHA256 `62fdb1b78959343c20cc3d84930b272db57ba36eaf9528c9df13c9c5f3193bd5`。
- 原 AssemblyRef：AcMgd/AcDbMgd/AcCoreMgd **23.1.0.0**；mscorlib/System/System.Core/Windows.Forms/Drawing/Xml/Xml.Linq/Data/Web.Services/Web.Extensions/Runtime.Serialization/ServiceModel/Management **4.0.0.0**；SQLite **1.0.119.0**。
- 逐条原始引用：`reverse-analysis/04_type-map/raw/assemblyrefs.json`。原 TargetFramework/PE 直接元数据摘录见 `logs/original-pe.json`（生成后以该证据为准）；ILSpy 生成工程 net48 不能单独替代原自定义属性证据。
- 当前仅确认本机 API25.1，未找到匹配23.1引用。编译性质：**AutoCAD2026 compatibility compile**，不等于重建原目标。

## 隔离与观察边界

整目录运行副本：`WindSpiral2026-runtime/`；逐文件复制/hash记录 `logs/runtime-copy-manifest.json`。新图限 `dwg/R01-*`。未加载恢复算法插件；Observer 独立编译，无目标程序集引用。Observer 仅对该新图目录订阅数据库事件，输出限 logs/。API 调用栈、GetPoint/GetEntity/SelectAll 次数仍需 IL 或调试器证据。

初始沙箱 Get-Process 无输出、CIM 无法访问；经已授权的只读进程查询及 Computer Use 窗口查询交叉确认宿主存在。没有据沙箱限制断言宿主缺失。
