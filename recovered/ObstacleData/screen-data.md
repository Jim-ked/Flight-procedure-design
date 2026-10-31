# ScreenData公共链（L1/L2）

Round 1 Closure补证：`evidence/closure-chain-edges.csv`逐箭头保存RandomPoint、SelectAll、解析器、EntityFrame、A8/A9表/评价/Mark、插块/导入/属性setter的原/处理token和RVA。当前AUTOCAD切片已通过25.1兼容编译，逐文件结果见`../dynamic-test/compile-validation.md`；下文“未编译”保留为上一轮历史描述，不能当成本轮最新状态。运行证据只以实验索引为准。

以下窗口均调用 `database._008B_008A<DBPoint>(OpenMode 0,false)`，不是鼠标框选：

| 窗口 | 阅读源调用行 | DBPoint→公共解析器行 |
|---|---|---|
| A7 Departure | 14335 | 14368 |
| A8 TurnArea | 12148 | 12190 |
| A9 PriSec | 28896 | 28929 |
| A10 DME | 19111 | 19140 |
| B3 RNP APCH | 47099 | 47132 |
| B4 PBN-ILS | 60819 | 60858 |
| B5 PBN Departure | 56399 | 56451 |

公共泛型helper处理后10D：SelectionFilter={DXF0=typeof(T)对应DxfName，DXF410="Model"}，Editor.SelectAll。DBPoint时选所有Model点，非当前视口范围；不接受BlockReference，也不要求IsObstacle XData标记。

公共解析器原130/RVA10D00，处理后12F：XYZ直接复制DBPoint.Position；ID来自窗口递增序号字符串；尝试读取WsEntityFrame.EntityName，失败吞异常；空白名且ObjectId字符串长度>6时按P+后四字符规则取名。**没有在该解析器读取Height/TreeHeight或做Z+树高**。

窗口重复创建DataTable，把ID/Name和Round(X/Y/Z,2)入行，并保留ID→DBPoint字典用于高亮/标记。B4/B5在SelectAll后有超过5点提示及Take(5)，A7/A8/A9/A10/B3所查导入入口无此截取。A10当前表中是高度、区域、MOC、OCA，没有前置截图所推测的树高/总高列；TreeHeight定义存在于另一属性框架，不能据此接到此导入链。

七窗原生导入与Mark现分别保存在TurnAreaForm.Events.Recovered.cs、PriSecForm.Events.Recovered.cs、ScreenData.OtherForms.Recovered.cs；公共函数在ObstacleCad.Recovered.cs。全部原生代码未编译。评价继续将点转换为各自业务对象和局部坐标；A8/A9已有独立切片，不能代替其他评价器。B4主buttonEvl实际仅提示基础版不支持；B5实际仅提示指定转弯点，其他评价入口仍存在。各评价模块尚未全部闭环，不宣称完整端到端任务完成。导入与标记之间保留源DBPoint，不自动把标记块变成下一次ScreenData障碍物。
