# 验证记录（2026-10-26）

## Round 1 Closure 最新状态（2026-10-27）

19文件启用AUTOCAD/ACAD2026_TEST通过API25.1兼容编译，三处仅为DataTable别名适配；恢复DLL未NETLOAD。Observer已在隔离新图加载并记录空图、命令事件。目标运行副本映像已加载但RCL不可用，A2/障碍物/A3业务实验均未执行；输入污染后停止操作。没有业务L3。详见[Closure](round1-closure.md)、[编译](dynamic-test/compile-validation.md)、[实验索引](dynamic-test/experiment-index.md)。下文为此前纯代码检查的历史记录。

`audit_native_ports.py`现消费`dynamic-test/closure-evidence-status.json`更新兼容编译状态，不再把最新结果固定覆盖为未编译；78条方法切片仍逐条保留原/处理token/RVA和独立IL，数量不代表完成率。

## 2026-10-27增量

本次继续新增PriSec.Tests：19项主副区、端点、局部坐标及退化线段检查通过；红/绿过程与一次错误测试预期修正见[记录](PriSec.verification.log)。对应纯代码PriSec.Recovered.cs。新的原生事件没有Autodesk23.1引用，未编译/运行；不将可读C#或关闭AUTOCAD宏的空编译当成原生验证。

XData.Tests先因缺类/工厂编译失败，恢复后18项断言通过；原27项数值及名称/格式器/Infinity检查重编译通过。新增CalcuCad/EntityFrameCad的AUTOCAD分支未编译运行，目标DLL未执行。详情和命令见A2-BasicCalculation/serialization.md。沙箱CS0016经批准外部编译解决。

## 范围

测试只运行本目录人工恢复的纯C#，不加载WindSpiralBasic.dll、不启动AutoCAD，不构成L3 Runtime。`XInfo.Recovered.cs`的AUTOCAD条件分支没有编译/运行；当前没有已确认的AutoCAD引用程序集。

## 可复现命令

在项目根目录PowerShell执行：

```powershell
& 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe' /nologo /out:recovered\Recovery.Tests.exe recovered\Recovery.Tests.cs recovered\A2-BasicCalculation\BasicCalculation.Recovered.cs recovered\A3-FixTolerance\FixTolerance.Recovered.cs recovered\ObstacleData\Obstacle.Recovered.cs recovered\ObstacleData\XInfo.Recovered.cs
if ($LASTEXITCODE -eq 0) { & .\recovered\Recovery.Tests.exe }
```

本次实际结果：退出码0，`PASS 27 numeric checks, name, recursive formatter and zero-gradient behavior; recovered code only, NOT original runtime.`

TAS增量先加入测试，编译报CS0117（缺TrueAirspeed/SpeedKmh），恢复后通过。首个TAS期望字面值在实现前经独立PowerShell公式核算纠正为364.405116191195，未将错误值当作目标行为。KK评价增量先加入测试，编译报CS0117（缺KkEvaluation），恢复后通过。旧17条数值断言仍通过。

覆盖：A2公式、两次HL舍入、时间可配置、零梯度Infinity、TAS/kt转换；A3精度/DME/盲区半径；RandomPoint半径分布/高度舍入/名称；合法嵌套JSON格式器；KK d0/OCA/PDA/minPDG部分分支。

未覆盖：原生UI输入和事件运行顺序、异常分支全覆盖、实体属性/事务、原生旧XData兼容、块定义、全部评价器、AutoCAD运行行为。部分JSON字段/类型/分片有另18项纯源码断言。测试通过不等于旧程序数值正确或符合规范，更不等于完整功能恢复。

## 证据包检查

`python recovered/package_evidence.py`只读取既有静态成果；最新生成A2 75、障碍物165、A3 17个方法定位（不是完成率）。已把A3错误的相邻Polyline摘录定位改为1458–1510；补入声明扫描漏掉的泛型SelectAll与转弯模型构造器。`audit_native_ports.py`生成78个移植方法切片映射；原生是否编译一栏始终保留未编译标记。障碍物包包含七窗ScreenData/Mark、WsEntityFrame、KK与A9主副区、直线helper及坐标变换证据。

原件未改；输出仅在recovered/，计划在reverse-analysis/PLAN.md。原件hash沿用既有00_manifest，不重复全量计算。
