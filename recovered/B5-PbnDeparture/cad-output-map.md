# CAD最终实体

P503（高度）/P50B（FO）→业务点组→PointLists旋转P821→ZeroZ P827→平移P823→**P087** Group writer。P086是single-polyline writer，P089是append；不得沿用早轮旧表的错配名称推断身份。准确原/处理IL均在本轮evidence。

P087：DocumentLock→外Transaction→new Group（先内存创建）→逐列表new Polyline→P12D Point2dCollection（经P12A取XY）→P134 AddVertexAt(index,point,**0 bulge,0 startWidth,0 endWidth**)→P089各自事务AppendEntity到ModelSpace→Group.Append(ObjectId)→最后Database.AddDBObject(Group)及事务提交。

|对象|创建/追加顺序|元数据/样式|
|---|---|---|
|Polyline|列表顺序逐个追加，主/补/外/后续列表不另分类对象|无显式Closed=true；重复首点只几何闭合；ZeroZ；无显式Layer/Color/Linetype|
|Group|内存先new，数据库最后持久化|没有业务命名/分类schema证据；宿主实际持久行为本轮无L3|
|Line/Arc/Circle/Text|保护区主链无独立实体创建|曲线来自采样折线，不是CAD Arc|
|BlockReference|Mark另走P09C“obst”块|在原DBPoint位置|
|AttributeReference|Mark P09E修改“Altitude”|source.Z.ToString；不是XData|

两次B5 writer实参description为空，P089的Trim().Length>0为false，跳过WsObject XData赋值。没有Radius/Kind/PBN departure metadata。默认层/颜色/线型不能以“未set”推断确定等于哪一宿主显示值。

PbnDepartureCad.Recovered.cs只记录预计实体和点列，不模拟Autodesk对象ID、事务、OCS、容差、组字典、宿主默认属性或空Polyline接受行为。每正常fixture保存local、hull与CAD顺序。KML P504不写几何，不能作为额外实体导出验证。
