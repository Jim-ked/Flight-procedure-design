# F0.1 崩溃诊断与恢复验收

诊断日期为 2026-11-06 至 2026-11-07。基线提交为 `d44827121918c0ec3e1c04482f11a5c3dd6ca66c`。本记录随实机复验逐步更新。

## 工作区保护

修改源码、未跟踪新文件及天津样例保存在忽略目录 `tmp/F01-crash-backup/`。`working-tree.patch` 保存已跟踪文件差异，`uncommitted-files.zip` 保存全部修改文件与未跟踪文件，`base-head.txt`、`files.txt` 记录恢复基线和清单。ZIP 的 SHA256 为 `AD2D5C4C9830096860A21EC492363A5C70C9C5200F84F6E620A939C7440DA947`。未执行 reset 或 clean。

2026-11-07 继续执行前另存 `tmp/F01-resume-backup-20261107-010549/`，保留补丁、状态清单和全部修改及未跟踪文件 ZIP；SHA256 为 `564D32780EBD4394E89C3AC12A1BF16C96BBD64832808A2079440E02CB6A0492`。本地 HEAD 与 origin/main 差异为 0/0，仍为上述 F0 基线。

## 2026-11-06 17:53:51 崩溃证据

Windows Application Error 1000 记录 `D:\SOFT\CAD\AutoCAD 2026\acad.exe`，文件版本 R25.1.60.0.0，PE 版本 31.1.60.0。进程 ID 为 44196，异常代码 `0xc0000409`，故障地址 `0x00007ff9fe08828f`，事件模块为 unknown。

WER 报告 ID 为 `39808a6c-0eb0-41af-8d15-2c310b35727f`，归档目录以 `AppCrash_OpenAI.Codex_26._dcb5f8aaffb09039a91c6649569825943ca5ee1_6fffc039_cf17a9cf-4787-4463-954f-9d42465c87d2` 命名。报告内实际映像为 ACAD.EXE，事件类型 MoBEX，故障签名 StackHash_c2da，异常数据 `0xA`。进程继承的 Codex 包标识造成报告目录使用 Codex 名称，不能据此把崩溃进程误判为 Codex。

有效转储保留于 `C:\Users\ZJ\AppData\Local\CrashDumps\acad.exe.44196.dmp`，大小 77,349,359 字节。转储异常流确认线程 12812（0x320c）、代码 `0xc0000409`、地址 `0x7ff9fe08828f`、唯一异常参数 `0xA`。Microsoft SDK 中 `FAST_FAIL_GUARD_ICALL_CHECK_FAILURE` 定义为 10。该代码本身不足以确定哪个组件制造了无效调用目标。[Microsoft Windows SDK 定义](https://github.com/microsoft/win32metadata/blob/main/generation/WinSDK/RecompiledIdlHeaders/um/winnt.h)

使用 Microsoft dotnet-dump 8.0.547301 读取实际托管栈，原始输出为 `tmp/F01-crash-backup/managed-analysis.txt`。关键调用依次如下。

```text
Interop.Ole32.ReleaseStgMedium(ref STGMEDIUM)
System.Windows.Forms.DataObject.ComDataObjectAdapter.TryGetIStreamData
System.Windows.Forms.DataObject.ComDataObjectAdapter.GetObjectFromDataObject
System.Windows.Forms.DataObject.ComDataObjectAdapter.GetData
System.Windows.Forms.Clipboard.GetText(TextDataFormat)
Autodesk.AutoCAD.ViewModel.CommandLine.CommandLineViewModel.DoPaste
Autodesk.AutoCAD.ViewModel.CommandLine.CommandLineControl.PreProcessKeyDown
Autodesk.AutoCAD.ViewModel.CommandLine.CommandLineControl.OnKeyMessages
System.Windows.Interop.ComponentDispatcherThread.RaiseThreadMessage
Autodesk.AutoCAD.ApplicationServices.Core.Application.FilterAndPreProcessMessageWPF
Autodesk.AutoCAD.ApplicationServices.Core.Application.OnPreTranslateMessage
```

该线程没有当前托管异常。CLR `dumpdomain` 的程序集清单未出现 Fpd.AutoCAD 或 Fpd.Core。原始转储中扫描到的栈地址仅用于初步定位，不能当作已展开调用栈。本结论采用上述 dotnet-dump 输出。

最后成功动作是新进程打开已保存天津 DWG。触发操作是向宿主命令行粘贴 NETLOAD 文本，随后窗口退出。转储支持“命令行粘贴、读取及释放 OLE 剪贴板内容时 fail-fast”的触发路径。无效剪贴板对象或函数指针的具体产生方尚未确定，此处不宣称宿主崩溃已根治。

## 与 F0 异常比较

F0 报告记录的是长 AutoLISP 文本粘贴之后的 `System.ArgumentException`，位于 WPF Popup/CreateWindow、CommandLineControl.ShowTempPrompt 和 CommandEditor.UpdateTempHistory。本次为 OLE ReleaseStgMedium 中的原生 fail-fast，两份栈的直接失败位置不同。两次均涉及 AutoCAD 命令行输入，尚无证据证明它们具有相同根因。F0 原转储仍保存在 `tmp/f0-crash/minidump.dmp`。本轮尝试重新读取该旧 CER 转储时 DAC 初始化失败，因此旧栈引用已有 F0 验收记录。

## 代码检查与构建

已检查 PaletteSet 单例创建与隐藏、Terminate 释放、WinForms 事件、SendStringToExecute 命令队列、批量事务、块与名称属性创建及图层操作。当前转储未执行这些 FPD 路径，因此本轮尚无证据支持以调整这些代码来修复该 fail-fast。

保留此前实测发现的布局及图面定位修正。`./build-f0.ps1 -OutputDirectory tmp/F01-crash-check` 构建成功，0 个警告、0 个错误。Core 测试为 28 passed、0 failed。

## 恢复验收记录

复验采用独立 DWG 副本 `tmp/F01-recovery-validation/tianjin-recovery.dwg`，原始 JSON 与 DWG 保留。使用新进程和逐步观察，每个输入动作之后读取窗口状态。宿主命令通过按键输入，避免再次将自动化剪贴板内容粘贴到 CAD 命令行。该输入方式属于复验规避措施，尚未修复外部 OLE 故障来源。

2026-11-06 本轮新进程成功打开副本，键入 N 后命令自动补全为 NETLOAD，未发生崩溃。随后工具连接更新中断，Return 的执行结果未知。2026-11-07 电脑会话重建，需从新进程重新执行 NETLOAD、FPD 和各项功能验证。

本轮代码尚未提交或推送。实机验收完成后再更新本节和 F0.1 交付报告。

2026-11-07 续验：启动全新 AutoCAD，成功打开独立副本 `tmp/F01-validation-20261107/tianjin-review.dwg`。真实图面中绿色 Fix 名称、红色障碍物符号和 80/120/95 m 标注仍在。命令行切换英文后正常键入 N、通过自动补全执行 NETLOAD，没有粘贴命令。文件选择窗选取 `tmp/F01-crash-check/Fpd.AutoCAD.dll` 后出现未签名文件安全提示，目前等待用户点击“加载一次”。该状态不等于 NETLOAD 已成功，也不等于 F0.1 最终验收通过。F1 仅开展离线设计准备，未编码。

用户继续后，安全提示已消失，NETLOAD 与 FPD 实际成功。随后逐项完成四页、JSON 重读、机场资料编辑/保存、Fix/Obstacle 批量绘图、图面定位、图层隐藏/显示、三类导出、程序引用上移/下移、就地转换、FPDCLOSE/FPD 重开及重复 FPD。整个会话未观察到崩溃，正常保存 DWG 后通过窗口关闭按钮退出。

发现独立于 0xc0000409 的普通插件缺陷：成果只读图层查询使用默认写锁，多出空撤销记录；“绘图→查图层→U”未减少图形，“绘图→直接U”回显撤销 FPDBATCH。Autodesk 文档说明写锁建立 undo bracket，改 `ReadLayers` 为 `DocumentLockMode.Read`。该修正构建 0警告/0错误，Core 28/28；输出 `tmp/F01-undo-fix`。之后已在新进程通过查询后单次U回归，见后文。此缺陷没有 fail-fast 或新转储，不能将其当作旧宿主 OLE 崩溃的根因。

该修正版 DLL SHA256 为 `0444C3CB15E8AF53E2803121B15DDA1C10843945AF8FA892B814170ECA473C2A`；Core DLL 保留同目录。未更改 SECURELOAD/信任路径，未绕过安全提示。

用户继续后，新进程 NETLOAD / FPD 成功。“绘制三个障碍物→成果页查询→一次 U→刷新”已实测通过，实体数从6增加至9，再恢复为6，宿主回显 FPDBATCH；截图10、11记录前后数量。该普通撤销缺陷已得到实际验证，原0xc0000409的外部OLE来源仍未确定。

同一新进程完成项目重开、手工Fix新增和修改、FPDPOINT。原生属性确认类型为点，X531984.0303 / Y4335221.7233 / Z26、FPD_FIX图层，截图12。用户即时授权后已完成临时Fix删除；表格恢复3行，CAD点保留。随后多行粘贴、重复整批拒绝、标识查找和CSV重导入实机通过，JSON/DWG已保存。最终构建0警告/0错误，Core28/28。F0.1完成独立提交后才推进F1编码。
