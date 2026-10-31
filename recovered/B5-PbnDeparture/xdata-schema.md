# B5 XData schema

**保护区主链：没有业务XData写入证据。** P503/P50B向P087传空description；P089只有description.Trim().Length>0才注册“WsObject”并写1001 app / 1000 description。此条件在B5为空时跳过。

|实体/属性|WsObject|Radius|Kind|PBN业务数据|
|---|---|---|---|---|
|保护区Polyline|未写|未写|未写|未写|
|Group|无此schema|无|无|无|
|Mark块/Altitude Attribute|不是XData|无此字段链|无此字段链|源标高是Attribute文本|

不能从Polyline轮廓自动推定TA/H、FO、primary/secondary或导航规范；没有恢复出实体到程序对象的往返序列化。原图若已有其他XData，不属于本轮新建路径的事实。
