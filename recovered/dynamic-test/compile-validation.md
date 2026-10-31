# 编译验证（2026-10-27）

收尾记录：另有`observer/WsToolsHostDiagnostics.cs`→`bin/WsToolsHostDiagnostics.dll`编译成功，但未加载/执行。Observer源码在加载后增加Group成员采集而未重编，原加载版本能力和源码差异见[实验索引](experiment-index.md)。当前源码/产物hash及19文件清单见`logs/closure-integrity.json`，hash采集时间为收尾时，不能冒称编译当时的输入证明。

性质：**AutoCAD2026 compatibility compile**。本机未发现API23.1引用；本次用API25.1.0.0/.NET8.0.12运行库元数据显式引用。没有构建或修改原目标程序集。csc 14.8.10001.0（C#5），`/noconfig /nostdlib+ /target:library /define:AUTOCAD;ACAD2026_TEST`。响应文件和原始编译日志同目录保留。

`prepare_compile.py` 先只读复制/校验原件，再编译本机恢复源码。不加载任何目标类型。因为无 .NET SDK，使用系统Framework编译器；这不代表原net48工程重建成功。运行库实现程序集引用仅用于本机验证，不是可移植交付配置。

| 恢复文件 | 状态 |
|---|---|
| CadInteraction.Recovered.cs | Compiled |
| A2/BasicCalculation.Recovered.cs | Compiled |
| A2/BasicCalculationForm.Events.Recovered.cs | Compiled |
| A2/CalcuCad.Recovered.cs | Compiled |
| A2/CalcuContracts.Recovered.cs | Compiled |
| A2/CalcuFactories.Recovered.cs | Compiled |
| A2/TurnParameterInput.Recovered.cs | Compiled |
| ObstacleData/EntityFrame.Recovered.cs | Compiled |
| ObstacleData/EntityFrameCad.Recovered.cs | Compiled |
| ObstacleData/Obstacle.Recovered.cs | Compiled |
| ObstacleData/ObstacleCad.Recovered.cs | Compiled |
| ObstacleData/PriSec.Recovered.cs | Compiled |
| ObstacleData/PriSecForm.Events.Recovered.cs | Compiled with compatibility adapter |
| ObstacleData/RandomPointForm.Events.Recovered.cs | Compiled |
| ObstacleData/ScreenData.OtherForms.Recovered.cs | Compiled with compatibility adapter |
| ObstacleData/TurnAreaForm.Events.Recovered.cs | Compiled with compatibility adapter |
| ObstacleData/XInfo.Recovered.cs | Compiled |
| A3/FixTolerance.Recovered.cs | Compiled |
| A3/FixToleranceForm.Events.Recovered.cs | Compiled |
| observer/WsToolsObserver.cs（独立工具） | Compiled |

三处adapter均仅为 `#if ACAD2026_TEST using DataTable=System.Data.DataTable; #endif`：恢复源码同时引入System.Data与Autodesk.DatabaseServices，25.1提供同名DataTable。未改数值、分支、序列化和CAD事务。其余文件无兼容性改动。

初次失败：默认csc.rsp重复引用；把/noconfig放到命令参数后解决。第二次发现DataTable歧义；加上述别名解决。沙箱csc输出CS0016，按既有复现使用批准的沙箱外编译，最终两个DLL均exit0。

产物：`bin/Recovered.Native.Validation.dll`（19文件联合编译，**未NETLOAD**）、`bin/WsToolsObserver.dll`。全量文件绝对路径见 `logs/compile-files.json`。联合编译验证静态类型/引用，不证明完整Designer、配置加载、控件初始化、资源、许可或目标等价运行。旧报告“未编译”是历史状态，由本记录更新，不回写为历史运行事实。
