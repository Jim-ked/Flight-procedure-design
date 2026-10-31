# CAD 实体与顺序

主可达路径 **button6→P47C→P47D/P593**，仅LNAV四条六顶点列表。旋转P821→平移P823→P087公共writer。

|顺序/实体|方法|来源/属性/业务角色|
|---|---|---|
|1 内存Group|P087|先建尚未入库的Group|
|2–5 Polyline|每列表P12D→P12A Point2d→P134 AddVertexAt|四条开放轮廓：外侧正、主副界正、主副界负、外侧负；每条6顶点；bulge/startwidth/endwidth=0|
|每条入ModelSpace|P089|单实体append并写WsObject文本；加入Group|
|末尾Group入库|P087|包含四折线；未设置Group.Description，文本参数用于实体XData|
|独立Mark BlockReference|P48C→P09C|obst，插在原障碍物位置；Altitude属性由P09E写原标高|

没有 Closed=true 或重复首顶点，无显式layer/color/linetype配置。Point2d使绘图Z丢失；未实现三维APV面writer。未发现该绘图链创建Line/Arc/Circle/DBText；Mark块内既有内容不能冒充B3新建面几何。没有单独跑道实体绘制。

[connection-api-sites.csv](evidence/connection-api-sites.csv)逐IL收录Polyline/Arc/XData/选择/Erase等关键词及覆盖数。核心保护区衔接通过固定顶点、15°/30°直线和数值分段编码；未见IntersectWith、Offset、裁剪、切线、包络、Erase后重建保护区链。开放折线的视觉衔接/后续外部编辑不属于已自动恢复的规则。
