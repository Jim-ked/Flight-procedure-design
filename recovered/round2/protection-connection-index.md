# Round 2 保护区衔接索引

来源为 `cad-connection-sites.csv`（A7/A8/A10 窗口及其可达 helper）。

| 类别 | 静态证据 | 结论 |
|---|---|---|
| Arc/Polyline/Arc bulge/顶点 | A10 P2DC / P2DB CAD体 | 已代码化，参数与顶点已保存 fixtures |
| Group/ModelSpace/事务 | 共享 P87/P89、A7 CAD事件 | 已代码化；A7路径保留匿名 Group |
| XData | 共享 P89、WsObject/Radius | 已代码化；A10未发现保存后续导航语义 |
| IntersectWith/Offset/切线 | 未发现对应 CAD 直接调用 | 本轮没有代码化证据 |
| 裁剪/延伸/删除重建 | 未发现对应 CAD 直接调用 | 不能声称软件自动完成；人工衔接无法由静态索引确定 |
| GetPoint/GetEntity/GetSelection | GetPoint 三点、跑道/KK/TP；公共 SelectAll | 点位依赖用户，障碍物导入由 SelectAll 自动筛 POINT/Model |

“未发现”限于当前静态方法/调用索引；不排除反射或宿主外部操作。
