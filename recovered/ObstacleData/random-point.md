# RandomPoint（L1 Direct/L2 IL）

Round 1 Closure：恢复源码通过25.1兼容编译；EXP-01未执行，以下不是实测。存储分支见[WsEntityFrame-schema.md](WsEntityFrame-schema.md)，链边见`evidence/closure-chain-edges.csv`，验收见[Closure](../round1-closure.md)。

入口Y92_RandomPoint→FormRandPoint→`_0087_0098_009D`（原0x0600034A/RVA0x4EC88，处理后349/RVA4175C）。

正常一次GetPoint“请指定中心点”；Origin则退出。读数量、最小/最大Z、范围(km)*1000、文字高。每次按钮执行new Random()一次，每点依次取三个NextDouble：

`r=range*U1; angle=2*pi*U2; z=Round((zMax-zMin)*U3+zMin,2)`。
XY=center+(r*cos(angle),r*sin(angle))。**半径均匀，不是圆盘面积均匀**，不得改成sqrt(U)。中心点Z不参与随机高度。

每点创建一个DBPoint(Position=XYZ)并取得ObjectId.ToString；名称=`P`+最后第5至第2字符（Substring(length-5,4)）。随后总是创建一个MText，Location=同XYZ、TextHeight=输入、Attachment=1；勾选名称则拼名称+换行，勾选高度则拼z。两项都不勾时仍创建空Contents的MText。

两次追加均不传元数据字符串，公共追加helper的P2默认为空，不进入WsObject写入分支；未见该链使用WsEntityFrame、ExtensionDictionary或块属性，亦未搜索到ObjectAppended/ObjectModified绑定自动补写。结论限于本DLL已恢复静态路径，不排除宿主其他插件行为。

名称不是一个绑定在DBPoint上的文本字段，解析器可按同一ObjectId规则重新计算；改MText不等于改点名称。Z存DBPoint.Position.Z，不是通过附近文字识别。
