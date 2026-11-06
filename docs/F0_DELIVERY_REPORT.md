# F0 环境修复与验收记录

日期：2026-11-06（Asia/Shanghai）。本次 F0 构建、Core 测试及规定的 AutoCAD 实机流程通过。首次长 AutoLISP 验收脚本触发的宿主崩溃单独保留，未将其写成已修复。

## 环境与构建（通过）

- 官方 WinGet 包 `Microsoft.DotNet.SDK.8` 安装 .NET SDK **8.0.427**；`dotnet --list-sdks` 已确认 `C:\Program Files\dotnet\sdk`。
- WinGet 实测版本 **v1.29.380**。
- 本机 AutoCAD 2026 简体中文：`D:\SOFT\CAD\AutoCAD 2026\acad.exe`，注册表版本 **25.1.60.0**，文件详细版本 **R25.1.60.0.0**；API 程序集版本 **25.1.0.0**。未推断未核实的市场更新名称。
- 宿主 `acdbmgd.runtimeconfig.json` 明确 `tfm=net8.0`。工程沿用 Core `net8.0` / 插件 `net8.0-windows`，未添加多版本目标。
- `build-f0.ps1` 实际执行成功：插件 Debug 构建 **0 警告 / 0 错误**；Core 测试 **21 通过 / 0 失败**。
- 直接构建可自动从 AutoCAD 2026 中文产品注册表读取 API 目录，也可设置 `AutoCAD2026Dir`。本地 CLI/NuGet 缓存写在忽略的 `tmp/` 下。

## 数据与坐标测试（通过）

- JSON 保存、覆盖保存、重新读取；保留项目标识、ARP、DWG 路径、Fix 高程、三种 Procedure、有序与重复 Fix 引用。
- CSV 表头、引号、缺省高程、区域设置、重复标识与无效经纬度；异常批次整体拒绝。
- 天津输入：**经度 117.346183° / 纬度 39.124353°**，选择 **CM117E / EPSG:4548**。
- 独立 pyproj 3.8.0 / PROJ 9.8.1：`E=529936.0628666884 m, N=4332366.307251088 m`。生产实现与参照差异在样例中小于 1 mm；原报告同公式重算并不构成独立核验，本轮已替换参照。
- 跨 118.5°E 分带界线的点仍用机场 CM117E，保留完整投影坐标。参照与复算方法见 `tests/Fpd.Core.Tests/PROJ_REFERENCE.md`。

## 已修复的 F0 问题

- 修复 AutoCAD API 安装路径解析与错误提示；启用 WPF 框架引用以消除 API 所需的 WindowsBase 冲突，界面仍为 WinForms PaletteSet。
- 修复以每个 Fix 经度各自选带，改用机场 ARP 固定中央经线；显式检查有限数值、支持范围及高程。
- 修复刷新列表覆盖尚未保存的机场输入；补齐 Fix 修改、引用同步、程序有序定位点录入与查看。
- 修复工具类别显示同一工具列表及无效点击；保持四栏、52px 固定分类侧栏和紧凑单列。
- 绘图经 AutoCAD 命令上下文执行，使用文档锁、原生 FPD_FIX 图层和 DBPoint，WCS X=E / Y=N；缺省 Z=0 明示。
- JSON 保存先校验并使用临时文件替换，避免失败写入覆盖原项目。

## AutoCAD 实机（规定流程通过）

前一会话完成数据录入与绘点；最终构建在新会话完成加载、关开、重读及绘点保存闭环。全部截图均为真实 AutoCAD 运行截图。

- 前一构建 NETLOAD 成功，FPD 打开工作区，无程序集加载异常；四栏齐全，工具固定窄侧栏点击可切换列表。
- 发现高 DPI 标签、行高及状态栏可读性问题，已修复布局初始化和 Palette 尺寸缩放。最终构建显式设置状态栏颜色及 KeepFocus；新会话实测界面紧凑，关键标签、按钮和状态栏清晰可读。
- 界面创建“天津F0验收项目”，ARP 纬度 39.124353 / 经度 117.346183；显示 CM117 / EPSG:4548、E529936.063 / N4332366.307 / Z0。
- 手工录入 TJMAN（39.2,117.3,12.5），通过 CSV 导入 TJ002、TJ003；创建并查看 TJ F0 SID，Departure / 跑道16，顺序 TJMAN,TJ002,TJ003,TJ002。
- 原生 FPDPOINT 绘制 ARP，属性面板显示类型“点”、FPD_FIX 图层、X529936.0629 / Y4332366.3074 / Z0；界面绘制 TJMAN、跨带 TJ003，命令回显分别为 E525914.625/N4340750.343/Z12.5 与 E638214.857/N4341927.356/Z0，均 CM117/EPSG:4548。
- 已通过界面保存并重新打开 `samples/F0/tianjin-acceptance.fpd.json`，3 Fix、1 Procedure、ARP 及有序重复引用恢复正确；已关联最终 DWG 并再次保存。

### 最终构建命令与持久化复测

| 验收项 | 实测结果 |
|---|---|
| NETLOAD | 用户点击“加载一次”后加载最终 DLL，无程序集或运行时异常 |
| FPD / 重复 FPD | 正常打开，重复运行仅保留一个工作区 |
| FPDCLOSE → FPD | 关闭后可正常重开 |
| 四栏与工具分类 | 项目、程序、工具、成果齐全；固定窄侧栏点击替换列表，无滑动抽屉 |
| JSON 重开 | 天津 ARP、3 Fix、1 Procedure 全部恢复，程序详情顺序正确 |
| FPDPOINT | 最终版本重新生成 ARP 原生 DBPoint，FPD_FIX 图层；属性 X529936.0629 / Y4332366.3074 / Z0 |
| 工作区绘制 | TJMAN 成功，E525914.625 / N4340750.343 / Z12.5 |
| DWG 保存与重开 | 原生 QSAVE 保存，关闭后从最近文件重新打开，ARP、TJMAN 两点保留 |
| 重开后继续使用 | 继续绘制 TJ002，E526774.650 / N4341863.446 / Z12.5，随后再次保存 JSON 与 DWG |

最终 DWG：`samples/F0/tianjin-acceptance.dwg`（39,158 字节，2026-11-06 13:04:08），包含 ARP、TJMAN、TJ002 三个点。模型空间使用完整投影坐标，未平移 ARP。JSON 为 1,084 字节；DWG 路径保存的是本机绝对路径，其他电脑需点击“关联当前 DWG”。TJ003 的跨带实测保留在前一会话截图09及 Core 测试中，未包含在最终 DWG。

实际加载的 Debug DLL SHA256：

```text
Fpd.AutoCAD.dll F616D13E31C5E970AF1D5C140B8419D2D8EBD5BE702CE307DB8B9267CD6022EC
Fpd.Core.dll    6D4A6AAB85C976D0732EA349FCDF2D6C4B74E1D8A38F8CD375EA8C5148550430
验收 DWG       E4799B85986BB9CACF8C09F3BDF7637066B5B72D329837081279E33E57F8CB7B
```

### 保存异常及恢复

首次尝试在浮动命令行粘贴较长 AutoLISP（缩放、保存及实体导出）时宿主崩溃，未生成有效绘点 DWG。真实异常截图为 `docs/screenshots/F0/10-cad-save-crash.jpg`。本地 CER 转储经官方 dotnet-dump 8.0.547301 分析，异常为 System.ArgumentException，栈位于 WPF Popup/CreateWindow、Autodesk.AutoCAD.ViewModel.CommandLine.CommandLineControl.ShowTempPrompt 与 CommandEditor.UpdateTempHistory，未出现 FPD 栈；不能完全排除插件影响。转储及诊断工具仅留在忽略的 tmp 目录，未提交。

重新启动后，先验证未加载 FPD 的空图可正常保存，再加载最终插件，使用短命令及原生 QSAVE 反复保存有点 DWG，关闭重开后继续绘点成功。最终文件已由空图更新为上述三点模型。此前宿主 WPF 临时提示异常的触发因素尚未完全查清；正常插件工作流复测未复现，不宣称宿主异常根治。

新会话 NETLOAD 安全提示由用户处理；未修改 SECURELOAD 或信任路径。插件保持未签名，新进程加载时仍可能提示。

### 已有实机证据

`docs/screenshots/F0/02-fpd-dpi-fixed.jpg` 至 `09-cross-zone-draw-command.jpg` 分别记录 DPI 修复、ARP 转换、DBPoint 属性、手工/CSV Fix、Procedure 和工具切换。它们来自前一构建。00 为安全提示、01 为修复前布局、10 为崩溃记录，均不是最终通过截图。

最终构建证据（同目录，1707×1019）：

- `11-final-fpd-single-instance.jpg`：重复 FPD。
- `12-fpdclose.jpg`：工作区已关闭。
- `13-json-reopened.jpg`：JSON 重开恢复数据。
- `14-final-dbpoint-properties.jpg`：原生点类型、图层、真实东/北坐标。
- `15-dwg-reopened.jpg`：DWG 重开保留两点。
- `16-continue-drawing-after-reopen.jpg`：继续绘制第三点及坐标回显。
- `17-final-procedure.jpg`：程序详情与顺序。
- `18-final-tools-basic.jpg` / `19-final-tools-category.jpg`：固定侧栏及列表切换。

## Git 交付

正确仓库根目录与任务路径一致，`origin` 指向 `https://github.com/Jim-ked/Flight-procedure-design.git`。提交前再次 fetch，本地 `main` 与 `origin/main` 均为 `cfdace3`，左右差异 0/0；沿用 main 和现有历史。无残留 index.lock、无阻塞的其他 Git 写进程；ACL 对用户具备正常完全控制，前次错误来自沙箱对 .git 的只读限制。正常授权的 Git 命令可以写 index；现有 GitHub CLI / Credential Manager 认证有效。

本报告与 F0 源码、测试、构建入口、CSV/JSON/DWG 样例及真实截图作为一次 `feat: implement and validate F0 AutoCAD framework` 提交发布。未包含 bin/obj、缓存、诊断转储、凭据及个人开发环境文件；原始任务文档与需求基线文档保留在工作区。提交不删除或覆盖历史文件，不使用强制推送。

精确提交 SHA 与远程核验结果记录在本次最终交付消息。也可通过 `git log -1 --format=%H -- docs/F0_DELIVERY_REPORT.md` 定位本报告所在的 F0 提交，在 [GitHub main 历史](https://github.com/Jim-ked/Flight-procedure-design/commits/main/) 查看。

## 尚未解决的事项

- 无阻止上述 F0 正常工作流验收的已知问题。
- 首次长 AutoLISP 脚本触发的宿主命令行 WPF 异常未完全查清；已记录真实失败及成功重测范围。
- 本次仅验收当前 AutoCAD 2026 / .NET 8 安装，不将结果外推至其他更新或 CAD 版本；专业算法及成果导出仍属后续阶段。

## 运行

```powershell
./build-f0.ps1 -Configuration Debug
```

NETLOAD 文件：`src/Fpd.AutoCAD/bin/Debug/net8.0-windows/Fpd.AutoCAD.dll`。保持旁边 `Fpd.Core.dll`。
项目创建后录入 ARP；定位点 CSV 示例：`samples/F0/tianjin-fixes.csv`。高程单位为米，空值绘图为 0；输入为十进制度。本轮未实现 DMS、垂直基准转换或专业航迹/保护区算法。

官方资料：[EPSG:4548](https://epsg.io/4548)；[Autodesk .NET 兼容表](https://help.autodesk.com/cloudhelp/2026/ENU/AutoCAD-Customization/files/GUID-A6C680F2-DE2E-418A-A182-E4884073338A.htm)。本机 runtimeconfig 为 .NET 8，非 .NET 10 更新版配置。
