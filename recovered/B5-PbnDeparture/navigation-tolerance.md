# ATT / XTT / 宽度来源

|参数|值/单位|Source / setter|Consumer|证据|
|---|---|---|---|---|
|指定点ATT样常数|1482 m|P5D3构造字段 `_008A_0089_0099`，无UI setter|earliest=TP−1482、navigation latest=TP+1482|P5D3 IL及字段流|
|高度模式ATT|没有独立ATT入参/字段|不构造B2对象|无ATT=0调用|P503/P504→P5C8；negative-evidence|
|XTT|没有独立XTT读取/推导证据|无RNP/传感器/类别选择绑定|不应反推为已实现XTT体系|Form字段、109事件、ctor签名|
|初始总宽|300 m|两业务ctor常数|DER半宽150|P5C8/P5D3|
|外侧半宽|W(s)=min(3704,150+s tan15°) m|业务类常数/站距|TP、latest、earliest控制点|P5C8/P5D3|
|主区宽度控制|1852 m；部分控制点min(W,1852)|ctor/边界方法|初始区、spiral中心及末端交点|P5C9/P5CA/P5D4/P5D5|
|外宽上限|3704 m|hard-coded constant|初始/后续区、连接末端|同上|
|高度早转偏距|600 m|P5C8字段|early点X=−runwayLength+600|P5C8/P5CB|
|后续15°扩张|1852/3704与6911.76/13823.52 m|StartArea常数|距连接起点的长度分支|P589、FO后续P58E，method-map|

1482接近0.8NM但代码值不是1481.6；未发现RNP1名称或spec selector与该字段绑定。3704也可对应不同规范条件。全部记为 **hard-coded constant / 实现依据待确认**，不能自动命名为“RNP1 ATT/XTT”。

方向ComboBox不是飞机类别。没有基于ARP距离、导航设施、RNAV/RNP规范选择容差或宽度的证据；A3定位容差结果不被B5自动读取。不能因共享低层点/线/螺旋而判定复用A3业务。
