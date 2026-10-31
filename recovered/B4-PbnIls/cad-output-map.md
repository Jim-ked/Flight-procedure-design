# CAD writer 与创建顺序

入口P55C→P55D→P5DE/P5DF→P821旋转→P827清Z→P823平移→P087。Shared P087先new Group，再为每一个点列表new Polyline，P12D/P12A转Point2d，P134 AddVertexAt(bulge/start/endwidth=0)，P089入ModelSpace并写WsObject，Append到Group；末尾Group入库。不设置Group.Description、Group XData、layer/color/linetype/Closed。

## 列表顺序（P55D请求高度<=300时）

|顺序，0基|来源|几何可证明语义|
|---|---|---|
|0、1（ShowOas=true）|P5E4/P5E5|正负Y面0/300轮廓，各5点|
|2（同开关）|P81F(YZ0,YZ300)|跨中线Z面0/300闭环，5点|
|随后|P5E8|入口至W/X0站距的中线，2点|
|随后|P81F(WX0,WX300)|跨中线W面轮廓，5点|
|随后2条|P5E2/P5E3|正负X面0/300轮廓，各5点|
|最后5条|P5DF|八顶点衔接×2，五顶点侧带×2，七顶点中心延伸|

ShowOas=true共12条，false共9条；开关不移除全部OAS。请求高度>300时最后W/X三列表由P5E1替代：正X、负X、W跨中线顺序，仍三条，仍12/9。三维点列有数值面高，进入CAD前清Z，Point2d再次丢Z。实际对象为二维Polyline与Group；没有Surface、Face、Solid、Mesh、3DPolyline，也没有这条边界writer新建Arc/Circle/DBText。

Mark是另一链P57D→P09C，BlockReference=`obst`，位置为源点XYZ，Altitude属性写源Z；缺块时P09D枚举WsSymbol*.dwg取首个导入。没有按面分类写不同图层或属性。实际块内既有实体不等于B4新建的曲面。

衔接相关API索引 [connection-api-sites.csv](evidence/connection-api-sites.csv) 同时包含共享依赖的词法候选，需按caller辨别；[connection-semantic-calls.csv](evidence/connection-semantic-calls.csv)另索引被混淆名称掩盖的点线/面交、镜像和点列构造。数值常量只匹配ldc操作数，不把IL_1482偏移当1482米。GroupBox不是CAD Group，Clipboard不是裁剪。核心没有IntersectWith、Offset、实体包络、切线拟合、Erase后重建链。数值line intersection不是AutoCAD IntersectWith。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P55C|0x0600055D / 0x8A970|0x710AC|61057|
|P55D|0x0600055E / 0x8ABAC|0x7123C|61094|
|P5DE|0x060005DF / 0xB2CB0|0x844F4|71771|
|P5DF|0x060005E0 / 0xB3034|0x84750|71828|
|P5E1|0x060005E2 / 0xB3F50|0x85430|72288|
|P087|0x06000088 / 0x555C|0x87E0|1458|
|P089|0x0600008A / 0x5878|0x8AB8|1578|
|P12A|0x0600012B / 0x10B70|0x3282|191|
|P12D|0x0600012E / 0x10C28|0x10590|213|
|P134|0x06000135 / 0x11050|0x107BC|342|
|P57D|0x0600057E / 0x8E114|0x73724|62563|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
