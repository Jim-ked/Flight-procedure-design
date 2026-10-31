# 保护区衔接

|阶段|分类|实际机制|自动化/边界|
|---|---|---|---|
|DER直线→起始区|Shared vertex / Independent overlapping polygons|S/A/B、TP/early/latest主外点及镜像拼接各列表|无CAD布尔合并；重复边保留|
|起始→内侧/后续区|Line carrier / Shared vertex|75°选择侧点，15°扩张到1852/3704，旋转平移点组|由TurnEnd与输入确定，代码化|
|latest→外转弯|Spiral candidate|最多4条Spiral86，候选参数、δ、15°、90°、π分支|不是相同MethodDef的B1/B2业务函数|
|外界→TurnEnd|Calculated intersection / Line carrier|候选−15°样点heading线与TurnEnd控制线求交；按1852/3704距离分段|只追加选中点，不执行宿主Trim/Extend|
|整体评价包络|Calculated hull|P7D9 gift wrapping；高度用全部绘图点，FO用选择子集|非CAD Region union；可能跨越分片之间空隙|
|导出图面→下一程序|Manual CAD dependence待运行证据|未发现业务对象自动配对、选旧保护区并修剪/重建的代码|不能据此宣称用户必定手工修剪；只能说自动接口无证据|

evidence/connection-api-sites.csv索引本轮B5及依赖中Polyline/Arc构造、GetPoint/SelectAll、Group/XData相关调用；direct-calls提供全部站点。未发现B5路径调用CAD IntersectWith、Offset、Trim、Extend、Erase输入图元，未发生选择前后保护区实体的GetEntity/GetSelection流程。

CAD交互只是输入DER/THR/TurnEnd/TP及选表格行，几何层不依赖人逐个选交点。业务输入本身依赖设计人员识别，见cad-interactions。没有凭规范给旧图补点，也没有推定各列表严格切向连续、相交集合等于真实保护区。

gift wrapping由minY/minX起点，orientation==2替换候选；共线无最远点规则，按对象引用判断闭环。退化可能漏最远共线点或非终止；本轮3个退化fixture结果保存，不把全部退化一概称超时。Ray包含严格比较导致边界左/下与右/上不对称。
