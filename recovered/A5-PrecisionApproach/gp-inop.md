# GP INOP：实际构造与未调用延伸

P306→new _0089_0096(P39E)，传入当前OasModel、IF、名义fix。该类使用当前X/Y seam、WX0、XY300/YZ300等共享点，构造H−150的连接、IF内/外半宽4630/9260、中间75m点及Z镜像辅助轮廓。29条数值点列最终经清Z输出为二维投影。

|候选说法|代码判断|
|---|---|
|固定CATI X面|公开UI仅CATI允许GPINOP；构造器不重新查CATI，消费传入模型的X面|
|强制3°|没有；P307按当前GP算fix，模型由当前GP查库。GP3.2差异测试改变输出|
|独立300m GPINOP模型|共享CATI交点含300m，不是另查库/强制新模型|
|后续15°扩张|P3A7确有15°、10000延伸方法，但无全局incoming；Draw29条不包含该额外调用|
|完整LOC-only/NPA|几何与非精密/LOC候选相关；未找到可达专用障碍物评价及完整LOC程序状态，不能认定完整实现|

具体点列逐顶点数值见 [fixture](../round8/fixtures/geometry-points.csv)；构造Add与字段赋值见 [列表表达式](evidence/list-construction.csv)、[字段表达式](evidence/model-expressions.csv)，全部保留原方法IL。Z镜像不是另一个三维CAD面，清Z后存在重合线且不去重。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P306|0x06000307 / 0x3FDF0|0x34FDC|24016|[证据](evidence/processed/0x06000306.il.txt)|
|P307|0x06000308 / 0x401EC|0x3537C|24174|[证据](evidence/processed/0x06000307.il.txt)|
|P39E|0x0600039F / 0x5CA54|0x4CA9C|38366|[证据](evidence/processed/0x0600039E.il.txt)|
|P3A7|0x060003A8 / 0x5D86C|0x4D1F8|38599|[证据](evidence/processed/0x060003A7.il.txt)|
