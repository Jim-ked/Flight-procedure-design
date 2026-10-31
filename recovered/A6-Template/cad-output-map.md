# CAD 写入、放置与metadata

## 共享writer与本轮准确token

Form.P359将组点列旋转→ZeroZ→平移→`_008B._0088_008B`；P35A对单点列同样处理→`_0088_008A`。复用旧轮已恢复行为，A6直接IL确认：

|方法名|processed token|作用|
|---|---|---|
|`_008B._0088_008A`|**P086**|单条零bulge Polyline|
|`_008B._0088_008B`|**P087**|每个列表一条Polyline，再建立Group并Append ObjectId|
|`_008B._0088_008D`|**P089**|ModelSpace AppendEntity，description非空时WsObject|

冻结 `round3/shared-cad-writers.csv` 的这些方法名与其token列存在错配；**不改冻结表**。本轮以真实P359/P35A调用、完整元数据映射和 `evidence/writers/methods.csv` 为准。不得将旧表的P089当成单条writer。

append方法为当前文档加锁并开transaction，条件注册RegApp `WsObject`，写 `(1001,"WsObject"),(1000,description)`，append ModelSpace/commit/update；异常显示绘制失败。组writer外层另有lock/transaction，逐条调用append后建Group、commit。未发现类型Kind/结构化程序ID。未显式赋Layer，不把它描述成固定命名图层。

## 实体创建顺序与数量

以下条数是代码点组和fixtures中的正常参数结果；Group指一次组writer调用，fixture里的Group字符串仅供区分调用批次，**不是CAD持久Group名或ID**。

|入口|创建顺序|无aux Polyline数|aux/额外输出|metadata|
|---|---|---:|---|---|
|Holding P364|nominal→保护组→可选MText|3|aux增加构造采样；标注另1 MText|曲线h.ToString；标注无|
|Base P35F|nominal→primary→secondary→可选辅助组|3|辅助列表逐条输出|b.ToString|
|45 P35D|nominal→保护组|2|aux共5条|p.ToString|
|80 P35B|nominal→保护组|2|aux共4条|p.ToString|
|XE P375|spiral组→construction组→nominal采样组|按各列表数|3次组writer调用|turn.ToString|
|YE P376|同上|按各列表数|3次组writer调用|turn.ToString|
|全向P377|全向组→普通组→9260外线|按列表数|aux保留中间模板；无nominal实体/MText|前两组h.ToString；外线空|
|Envelope P367|新零bulge Polyline|1|cancel不生成；OK空输入尝试空实体|无|

XE/YE及各aux分支的精确点组数量保存在fixtures，可随输入或辅助分支变化，不把某一fixture数量推广到任意参数。

## Nominal弧

|模板|顶点数|bulges（未镜像基准）|Closed|
|---|---:|---|---|
|Holding|4（丢掉第5个重复首点）|1,0,1,0|true|
|Base|3|0,tan((π−φ)/4),0|false|
|45|5|0,−tan(π/16),0,1,0|false|
|80|5|0,−tan(π/9),0,tan(13π/36),0|false|

没有独立CAD Arc实体。保护/辅助、XE/YE名义采样、全向及Envelope都是零bulge采样Polyline。源内圆弧采样helper不等于调用Autodesk Arc构造器。

nominal先世界放置再由Matrix3d.Mirroring(Line3d)镜像；保护点列先局部镜像再放置。前者可含宿主OCS/Normal语义，独立记录器的bulge符号仅表示世界XY有向弧，不声称与CAD实际DXF bulge逐位相同。

## Holding MText

P364/P365：取**镜像前**nominal四世界点平均坐标c。右转时投影到所选轴得p，再用旧代码 `(2p.Y−c.Y, 2p.X−c.X)`，**X/Y交换**；原样恢复。内容 `IAS {IAS}km/h\n{altitude}`，height1000、Attachment enum5。heading严格在(−π/2,π/2)内原值，否则π+heading。通过append无description，不写WsObject。

## 静态恢复边界

`TemplateCad.Recovered.cs`是写入**记录适配器**，保留创建次序、点列、描述、bool和bulge以供审计；不连接Autodesk数据库，不创建真实实体/Group。数据库副作用由writer源与IL恢复，事务、OCS、Point3d容差及异常提示显示仍无本轮宿主运行验证。
