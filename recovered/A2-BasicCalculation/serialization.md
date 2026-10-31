# 2026-10-27 序列化/工厂恢复增量

## 实现和边界

CalcuContracts.Recovered.cs恢复10个线数据成员、28个参数成员、默认值、UTF8/16KB警告和错误反序列化回退。CalcuFactories.Recovered.cs恢复原六个参数工厂。EntityFrame.Recovered.cs恢复名称/类型私有成员、Properties、名称/类型通知、JSON读写及250字符分片。均为原代码切片，不是新架构。

新增18项测试通过：往返、嵌套参数、真实键名、默认值、超限仅警告、字典数组、分片、六个工厂。原27数值及名称/格式器/Infinity检查也重新编译通过。不构成L3或真实DWG兼容证明。

## 原成员名证据

L1原始元数据：`reverse-analysis/03_recovered-src/il-original/WindSpiralBasic.il:30287`的Property名为`\u008a\u0090\u0098`；`04_type-map/raw/fields.csv`中0x04000731/732是`\x8a\x9a\x8e`、`\x8a\x9a\x8f`，custom-attributes.json的DataMemberAttribute blob均为01000000，无显式Name覆盖。

DataMember.Name因此使用真实Unicode名称。下划线`_008A_...`只是反编译显示别名，不能拿来当JSON键。本次中途曾误判应改为别名，已凭原始IL撤回，并加入键名断言；最终文件未混用别名。

L1处理代码74863/74888及78618/78647使用无额外设置的DataContractJsonSerializer。实测Properties输出`[{"Key":"Height","Value":123.5}]`，不是普通JSON对象。枚举用int承载数值JSON只是序列化切片，不恢复枚举UI；Properties中自定义类型的类型标识/已知类型兼容仍TODO-RE。

## 原生代码（未编译运行）

CalcuCad.Recovered.cs恢复ResultBuffer、header类型覆盖JSON、RegApp注册、Save、空metadata追加和CreateLine。CreateLine重算端点中心XYZ/三维长度/平面方向，先提交Line，再单独写XData；失败不回滚Line（原0x060006A4/RVA0xB9C38）。

EntityFrameCad.Recovered.cs恢复分片写入和拼接读取：JSON非空名称覆盖header，JSON类型无条件覆盖header。坏JSON的默认99也保留。

两个文件的AUTOCAD分支没有编译或运行。缺口：匹配宿主引用、完整Form事件/文字布局、原生事务验证和真实DWG交叉验证。不要以条件排除后可编译冒充原生验证。

## 命令和结果

项目根目录PowerShell：

```powershell
& 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe' /nologo /r:System.Runtime.Serialization.dll /out:recovered\XData.Tests.exe recovered\XData.Tests.cs recovered\A2-BasicCalculation\CalcuContracts.Recovered.cs recovered\A2-BasicCalculation\CalcuFactories.Recovered.cs recovered\ObstacleData\EntityFrame.Recovered.cs
if ($LASTEXITCODE -eq 0) { & .\recovered\XData.Tests.exe }
```

实际输出：PASS 18 recovered XData checks; NOT original runtime or DWG compatibility verification.

沙箱内CS0016在最小程序也复现，经授权沙箱外编译成功。只运行新恢复代码，未加载目标DLL。_csc-temp中保留本次编译诊断小文件，不作为交付源码；删除尝试失败，未移除原件或用户文件。
