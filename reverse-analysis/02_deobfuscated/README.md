# 静态恢复路径（未执行目标）

原始 DLL SHA-256：`62fdb1b78959343c20cc3d84930b272db57ba36eaf9528c9df13c9c5f3193bd5`。
处理后 methods-only DLL SHA-256：`75627021d4d8f4fa4dfc96cc5d4ea6464f7461f1bdd7b68ba78cf0edb36471df`。

## 方法恢复

原始大量方法是短占位 IL。模块初始化器关联解密器，并引用 VirtualProtect/WriteProcessMemory；这不是只靠 C# 反编译格式调整能解决的问题。ILSpy 原始导出与 dnfile/dncil 独立 IL 保留在各自目录。

采用 ViRb3 de4dot-cex release v4.0.0（程序自报 v3.1.41592.3405）进行 .NET Reactor 方法资源静态恢复。工作区根运行：

```powershell
& .\reverse-analysis\tools\de4dot-cex\de4dot-x64.exe -f .\reverse-analysis\01_original\WsTools-master\WindSpiral2026\WindSpiralBasic.dll -o .\reverse-analysis\02_deobfuscated\WindSpiralBasic.methods-only.dll -p dr4 --strtyp none --dont-rename --keep-types --preserve-tokens --dr4-bools false --dr4-types false --dr4-rsrc false --dr4-sn false --dr4-inline false --dr4-remove-inlined false --dr4-embedded false -v
```

成功日志：de4dot-methods-only.log。其他尝试失败日志保留在本目录 de4dot-static*.log、de4dot-strings.log；包括参数顺序错误、默认/字符串路径异常，不能当成目标程序运行异常。即使指定 preserve-tokens，方法数仍由 2,725 变为 2,681；必须用工具 token-map，不可直接沿用 token。

## 字符串/布尔恢复

`../StaticResourceDump.cs` 仅加载分析工具程序集，用 dnlib 解析目标字节；未用 Reflection.Load/Invoke 执行目标。字符串资源选择 V2 uint mixing 静态解码（自动旧版 AES 路径不适配 8,428-byte 资源），得到 string-rva-table.bin。布尔资源静态 AES 解码得到 boolean-table.bin（1,552 bytes）。

工具运行：`tools/de4dot-cex/bin/StaticResourceDump.exe <methods-only DLL> <输出表路径>`；布尔模式增加第三参数 `bool`。辅助工具通过 Framework64/v4.0.30319/csc.exe、dnlib.dll、de4dot.code.dll、de4dot.blocks.dll 编译；源码保留。

`../decode_strings.py` 从 RVA 表定位**原始** DLL 密文，按代码恢复的 AES-CBC key/IV 解码；boolean 表为原件文件偏移，并非 RVA，值判断为 byte==128。`../validate_evidence.py` 验证每条字符串重加密和布尔原字节。回环成功证明该转换与原件一致，不等于业务意义或运行正确性已验证。

静态恢复未尝试移除授权逻辑，不用于绕过软件使用许可。仍有混淆控制流及 CAD 引用缺口。
