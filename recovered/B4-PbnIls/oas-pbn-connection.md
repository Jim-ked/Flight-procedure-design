# OAS → 固定宽度复飞区衔接

以下是实际P5DF构造，不从规范补出：

1. P5DE生成W/X、X/Y、Y/Z交线及0/300m交点。X/Y-cap记D′，Y/Z-cap记E′′。
2. 连D′、E′′，在x=SOCx取E（源码字段`_008A_008A_0093`），Y由此线求，Z恒300。报告记E′只是几何别名，源码没有业务点名字符串。
3. 过E以该线方向减PI/12构造辅助线L15；L15与y=3704求A，A.Z取Y面，不强行保持300。
4. Y/Z交线与y=1852求B；B.Z取Z面。C=(B.x,3704,B.z+30)。F=(B.x−20000,1852,Z面(B.x−20000,0))。
5. 三点B/C/F拟合副区面S；Y∩S再取y=3704求D，其Z取Y面。
6. 追加正负镜像八顶点衔接多边形，正负五顶点后端侧带，以及七顶点中心Z延伸轮廓。镜像只翻Y。

八顶点正侧顺序：E,A,D,B,YZ0,XY0,XY300,E。侧带：B,D,(F+(0,1852,30)),F,B。中心：YZ0,B,F,mirror(F),mirror(B),mirror(YZ0),YZ0。重复首点造成几何闭环；writer没有Closed=true。

警告条件`SOCx>XY300.x`文本却称“SOC高度大于300米”；实际比较X站距，且警告后继续。站距未排序、无通用polygon求交、裁剪或包络算法。连接是参数化点线交和数值平面，CAD没有自动与既有实体相交。后端20000只支撑绘图，评价没有相同纵向端点限制。

测试使用原OAS参数I系数、SOCx=−690，点例见 [transition-points.csv](../round7/fixtures/transition-points.csv)：E=(−690,1599.2337,300)，A≈(−6032.1747,3704,618.1801)，B≈(−7979.4493,1852,176.9862)，D≈(−15369.3736,3704,391.7343)。这是独立源码计算，不是原插件运行测量。

规则已代码化到同轴1852/3704衔接层；没有随后任意转弯区，因此不能声称“OAS→PBN定点转弯全过程已闭合”。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P5DE|0x060005DF / 0xB2CB0|0x844F4|71771|
|P5DF|0x060005E0 / 0xB3034|0x84750|71828|
|P5E0|0x060005E1 / 0xB36EC|0x84CAC|71916|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
