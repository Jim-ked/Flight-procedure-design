# 六模式CAD输出与衔接

P306：P307准备→按FAP/FAF/GPINOP/OAS/PAOAS Left/Right顺序择第一checked分支→P821旋转→P823平移→P827清Z→P087/P089。

|模式|样本Polyline数|逐列表顶点数（创建顺序）|
|---|---|---|
|GP INOP|29|5/5/2/2/2/2/5/5/2/5/5/2/9/9/2/2/2/2/5/5/2/2/5/5/2/2/5/5/2|
|PAOAS Left|7|5/5/7/6/10/9/2|
|PAOAS Right|7|5/5/7/6/10/9/2|
|OAS|7|5/5/5/2/5/5/5|
|PA-FAF|12|9/6/6/5/7/7/5/2/5/5/5/4|
|PA-FAP|11|8/6/6/5/6/6/2/5/5/5/4|
|OAS AUTO|8|5/5/5/2/5/5/6/6|

样本CATI GP3 LOC3000，THR=(1000,2000,100)，end=(2000,2000,110)，F=900，L=10000，T=700，RDH15，尺寸30/6。点列数与顶点顺序取自真实Add链并以独立源码生成；不是以规范预设数量。某些输入改变截断顶点数，不能当所有输入固定模板。

## CAD实体协议

所有模式统一一个Group与逐列表一条2D Polyline。P087先new Group，再循环new Polyline，Point2d转换，AddVertexAt的bulge/start/endwidth均0，P089入ModelSpace并写XData，Append到Group，最后Group入库。未显式Closed=true；点列重复首点形成的几何闭合不等于CAD Closed属性。无Text、独立图层/颜色/线型设置；最终宿主默认值未运行验证。

没有3DPolyline、Face、Surface、Solid、Mesh；内存点含面高和Z镜像，清Z及Point2d将其变为平面投影。不会自动去重重合图元。Group无Description或XData。每子Polyline带完整参数，非surface标签。

## 保护区衔接索引

[CAD API词法候选](evidence/connection-api-sites.csv)、[数值交线/交点/镜像调用](evidence/connection-semantic-calls.csv)、[条件](evidence/condition-expressions.csv)、[列表构造](evidence/list-construction.csv)、[字段赋值](evidence/model-expressions.csv)、[逐顶点fixture](../round8/fixtures/geometry-points.csv)互相对应。词法索引含公共依赖候选，SelectAll/BlockReference/Spiral等不能未经caller过滤归为A5实际功能；GroupBox不是CAD Group。

核心是数值line/plane交点后组织列表，没有AutoCAD IntersectWith、Offset、Arc/切线、实体包络、自动裁剪或Erase重建证据。FAF/FAP数值截断已代码化；既有图元选择只取XData参数，不参加几何裁剪。没有找到人工选两条边完成衔接的A5事件；需要设计人员观察图面做后续编辑是否存在，不能由静态缺失直接断言具体工作步骤已实现。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P306|0x06000307 / 0x3FDF0|0x34FDC|24016|[证据](evidence/processed/0x06000306.il.txt)|
|P087|0x06000088 / 0x555C|0x87E0|1458|[证据](evidence/processed/0x06000087.il.txt)|
|P089|0x0600008A / 0x5878|0x8AB8|1578|[证据](evidence/processed/0x06000089.il.txt)|
|P821|0x06000822 / 0xC9868|0x92B20|84515|[证据](evidence/processed/0x06000821.il.txt)|
|P823|0x06000824 / 0xC9968|0x92BF8|84547|[证据](evidence/processed/0x06000823.il.txt)|
|P827|0x06000828 / 0xC9B68|0x92DA4|84611|[证据](evidence/processed/0x06000827.il.txt)|
|P134|0x06000135 / 0x11050|0x107BC|342|[证据](evidence/processed/0x06000134.il.txt)|
