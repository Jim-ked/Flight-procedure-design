# 六个CAD事件的实体结果

L1/L2。以下计数指正常路径共用GetPoint包装函数的调用次数；包装内部错误重试可能多次调用Editor.GetPoint。取消/Origin检查可提前退出。未见六事件使用GetEntity/GetSelection。

令theta=Atan2(方向点Y-基准Y,方向点X-基准X)，单位方向=(cos(theta),sin(theta))。不是直接用用户第二点当结果位置。计算结果的Z均置0。

| 页 | 拾取（正常两次） | 施工中心 | 实体 |
|---|---|---|---|
| FAF | 跑道入口、FAF方向 | FAF=入口+d*u；IF=入口+(d+中间段长)*u | 两条垂直航迹的Line，各20,000m；可选4个DBText |
| NPA SOC | “复飞最晚点”、复飞方向 | 起点+d*u | 12,000m横向Line；可选SOC DBText |
| PA SOC | THR、复飞方向 | THR-返回距离*u | 12,000m横向Line；可选“CAT … SOC”DBText |
| 复飞TP | “起点”、复飞方向 | 起点+d*u | 20,000m横向Line；可选距离及TP两个DBText |
| 离场TP | DER、离场转弯点方向 | DER+d*u | 20,000m横向Line；可选距离及TP两个DBText |
| C | “起点”、飞行方向 | 起点+d*u | 12,000m横向Line；可选C DBText |

“复飞TP起点=SOC”“C起点=最晚点”是帮助定义的操作意图；实际GetPoint仅取坐标，不读取业务身份、导航台或容差类型，因此代码不能验证用户选的是哪个对象。

没有DBPoint、MText、BlockReference或Polyline在这六条正常绘图链中创建。FAF四个DBText：距离(高500)、FAF(1000)、高度字符串(1000、位于FAF下方1000)、IF(1000)。其余标注高500；距离放在起点和施工中心的中点，标签多放横线端点。

Line由公共 `_008A_0097_0087`（处理后6A3）创建并写元数据；追加helper `_0088_008D` 写ModelSpace，不设图层名/颜色/线型，不调用SetDatabaseDefaults。所查链没有显式Layer/Color/Linetype赋值；实际默认值依CAD构造/数据库环境，不凭静态资料宣布为当前层或某固定层。

## WsCalcuLine写入

顺序：1001="WsCalcuLine"；1000=类型整数的字符串；1000=DataContractJsonSerializer序列化完整参数对象。类型：FAF1、IF2、NPA SOC3、PA SOC4、复飞TP5、离场TP6、C7。不是WsObject。

工厂最初设施工中心/航迹角/标称线长；写线helper又用端点重算中心、长度、Atan2(end-start)，**最终存的是横线方向，不是原航迹角**。C工厂初始长度10000，最终实际横线12000覆盖该字段。

对象含类型、中心XYZ、方向、长度、描述、计算参数、创建时间/创建者。参数DataMember是混淆Unicode名称，不能直接用友好名或反编译显示别名替换旧JSON键。模型与六工厂已转写并有18项纯源码检查，真实旧CAD数据兼容仍未验证。文本追加不传字符串元数据，不写此XData。写线成功、后续XData失败时旧程序只警告并返回线ObjectId，不回滚已创建的线。

六个绘图事件现见BasicCalculationForm.Events.Recovered.cs，原生分支未编译。取消不统一：FAF/复飞TP/离场TP逐点检查Origin，NPA/PA/C只检查两点相等。PA的工厂参数ThrSocDistance也保存负CAD距离。
