# 证据索引

等级沿用任务书：A=可读代码/IL，B=多处关系交叉确认，C=动态验证，D=帮助/配置推断，E=假设。来源另列；文件完整性/元数据事实注明原件，不套用“运行验证”。当前无 C 级结果。

| ID | 事实/用途 | 来源、等级 | 定位 |
|---|---|---|---|
| E001 | 原路径、大小、hash、快照 | 原件字节 | hashes.csv；original-recheck.json |
| E002 | 原始类型/字段/方法/命令 | 原始程序集，A | ../04_type-map/raw/ 下 CSV、independent-il.txt、summary.json |
| E003 | 方法静态恢复与 token 变化 | 工具处理，A/B | ../02_deobfuscated/de4dot-methods-only.log；../04_type-map/tool-token-map.csv |
| E004 | 字符串和布尔静态解码 | 原件字节+恢复逻辑，A/B | ../02_deobfuscated/strings.json、booleans.json；string-roundtrip.json |
| E005 | UI Name/事件候选 | 反编译+解码，A/B | ../04_type-map/controls.csv、events.csv、method-source-locations.csv |
| E006 | 调用与字段使用 | 处理后 IL，A | ../05_callgraph/static-sites.csv、field-accesses.csv |
| E007 | CAD/几何/XData/SQL 位置 | 处理后 IL，A（仅调用位置） | ../09_cad-interactions/*-il-sites.csv |
| E008 | SQLite schema/数据 | 原件只读读取 | materials/sqlite-schema.json、sqlite-tables.json、sqlite-integrity.json、CSV |
| E009 | 压缩包条目及独立衍生物 | 归档清单与解包 | materials/archives.json；unpacked/；derivative-tool-hashes.json |
| E010 | 国内规范身份 | 原文档 | materials/spec-metadata.json、spec-first-pages.txt、spec-cover.png |
| E011 | Arc2 实际 ±π/3 | 处理后 IL，A | token 0x06000070，IL_0145/0151/015B；原 token 0x06000071 |
| E012 | 离场拾取为无符号平面距离 | 处理后代码，A/B | annotated-strings/--/--.cs:14874、14931、14951、15098；处理后 0x06000287/28A/28B/28E |
| E013 | 障碍物获取为 Model 类型筛选 SelectAll | 处理后代码+IL，A/B | annotated-strings/-/-.cs:5120；处理后 0x0600010D，IL_0071 |

表内 annotated-strings 路径均相对 `03_recovered-src/`。行号为当前阅读副本；稳定交叉定位使用方法 token 和工具映射。数字 token 必须指明原始或处理后版本。

工具来源留存：`ilspycmd-versions.json` 及 tools 中 NuGet 包、GitHub release 元数据/参考源码；精确下载产物 SHA-256 见 derivative-tool-hashes.json。校验脚本 `../validate_evidence.py` 不加载目标程序集。
