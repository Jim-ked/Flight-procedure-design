# A10 CAD 输出与连接索引

P2DB/P2DC 的 CAD 事件创建 Arc、Polyline、可选 DBText；P2DF/2E0/2E1 为 Normalize、诊断、扇区辅助。完整 API 调用索引见 `round2/cad-connection-sites.csv`。该索引只收录静态 call/callvirt/newobj，不代表运行顺序。当前发现的 CAD API 是 Arc/Polyline.AddVertexAt、Closed、XData、Group/ModelSpace 事务；未发现 Offset、IntersectWith、删除重建或自动裁剪。
