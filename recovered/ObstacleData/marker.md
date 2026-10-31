# Mark（L1/L2）

Round 1 Closure：原生切片已通过25.1兼容编译，未因此证明真实DWG符号定义或目标运行。A9 Mark原0600033C/4C124→Insert原0600009D/739C→缺块Import原0600009E/7794→SetAttribute原0600009F/7A64；链边证据见`evidence/closure-chain-edges.csv`。本轮动态状态见`../dynamic-test/experiment-index.md`。

各窗口从SelectedRows的ID查回源DBPoint，将其Position传公共 `_008B._0089_0087`（-/-.cs:2596）。A7/A8/A9/B3/B4/B5字面量为`obst`，A10为`Obst`；保留大小写，不自行统一。

公共方法：若当前块表不存在名称，调用 `_0089_0088`，在程序集目录枚举`WsSymbol*.dwg`取第一个文件，FileShare.Read加载，WblockCloneObjects导入指定块。因此可能使用所提供WsSymbol2.1.dwg，但代码不是硬编码精确此文件名。多个匹配文件时不能假定排序。

新BlockReference位于源点XYZ，默认scale=1；用Matrix3d.Scaling(scale,position)变换；遍历块定义AttributeDefinition并SetAttributeFromBlock创建AttributeReference，初值一空格。未见显式旋转或图层设置；实际块/属性几何需原DWG才能补证。

普通Mark将Tag `Altitude`（比较双方ToUpper）写为源点Z.ToString，**不是评估后的OCA/MOC值**。A8另写Name；其余六窗所查Mark事件只写Altitude。七个事件已逐一核对并转写，引用见native-port-map.csv。

L2 IL纠正阅读副本错误：A8 Mark处理后0x06000254在IL_00B5 dup保留块ObjectId；IL_00D7消费一份ID并写Altitude；IL_00EE–00FA把"Name"和解析器返回Name压栈，IL_00FF调用同一个0x0600009E setter。故真实第二次调用是 `SetAttribute(blockId,"Name",parsedName)`，并不存在阅读副本所显示的string在前的另一重载。此结论来自IL而非整理C#。

公共插入/导入/setter见ObstacleCad.Recovered.cs，已通过25.1兼容编译；原DWG块/属性定义未独立读取，不能声称已复刻块符号布局。当前AutoCAD宿主已调查，但Mark未运行。
