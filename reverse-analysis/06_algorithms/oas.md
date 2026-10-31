# OAS：数据库与静态查询初步恢复

原件只读数据事实：PartA(ID INTEGER PRIMARY KEY NOT NULL, Value TEXT NOT NULL) 275 行；PartB 同结构 687,775 行；sqlite_sequence 为空。sqlite_master 未显示额外显式索引/外键。完整导出见 `00_manifest/materials/`。不能把 ID 和 Value 直接解读为规范参数列。

A（处理后代码）：`_008A_0092._008A_0091._0088_0090_0094`，阅读副本 `--/--.cs:41675`：

1. 数据库位置为程序集目录 + `\oas.db`；不存在时提示“参数文件不存在”。
2. `keyA=(P0+(int)P1+P2).Replace(".","")`；`n=(int)Math.Round(Convert.ToDouble(P3),0)`。
3. 参数化查询 PartA `WHERE ID=@id`，值为 keyA；PartB 值为 keyA+n。**字符串拼接，不是数值相加**。
4. PartA Value 分段(0,4)、(4,5)、(9,3)、(12,5)、(17,4)，分别解码并乘 -0.01、1e-6、-0.01、1e-6、-0.01。另有 keyA.Substring(3,2)*-0.001。
5. PartB 整串先解码，然后分段(0,5)、(5,6)、(11,4)、(15,5)、(20,6)、(26,4)，乘 1e-6、1e-6、-0.01、1e-6、1e-6、-0.01。
6. `_0088_0090_0095`（41815）对非0/5数字取10-d，之后反转整个串；布尔表offset772为false，相关混淆分支不是业务条件。

本函数直接查表和缩放，尚不能据此断言整个 OAS 系统“不插值”。后续 `_0088_0090_0096` 及调用者仍需恢复；GP/类别/梯度与四个参数的对应、返回字段的面方程语义尚未核实。SQL 站点索引见 `09_cad-interactions/sql-il-sites.csv`。

PANS-OAS3.3.rar 包含旧4D程序数据/资源文件和多语种手册，已独立解包，未运行 EXE。现有归档列表和散件中未发现 WsOasPara.exe。不能据文件名声称二者使用相同数据模型；需要从手册、表边界与编码值逐项对照。WindSpiralTemplate 中有数值报告，可作为独立历史样本，但其2020时间标识不证明与当前DLL一致。
