# XData：完整参数而非面标签

每条Polyline依次写TypedValue(1001,"WsObject")、TypedValue(1000,P319完整分段JSON参数文本)。Group没有Description/XData赋值；未写Kind、surface name、面高、Radius或单独业务标签。输出顺序可用于审计，但不能反推XData有面类型字段。

P318 GetEntity选任意实体→取整个XData→直接读索引1的Value文本→P31B导入选择→P31A解析。非OK选择直接返回，null XData及空文本有提示；不按RegApp过滤，不验证schema或数组长度，短数组/错误内容仍有失败风险，不能改写成强类型保护区对象选择。它只恢复参数，不从所选实体顶点反求面系数，不进行障碍物评价。

完整协议/样本见 [参数格式](oas-txt-format.md)与 [sample](../round8/fixtures/a5-parameters.txt)。未运行AutoCAD，超长XData的宿主限制/异常未实测。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P318|0x06000319 / 0x41B08|0x36418|24747|[证据](evidence/processed/0x06000318.il.txt)|
|P319|0x0600031A / 0x41DD0|0x36594|24808|[证据](evidence/processed/0x06000319.il.txt)|
|P31A|0x0600031B / 0x4259C|0x36D38|24964|[证据](evidence/processed/0x0600031A.il.txt)|
|P31B|0x0600031C / 0x43518|0x4391|25482|[证据](evidence/processed/0x0600031B.il.txt)|
|P087|0x06000088 / 0x555C|0x87E0|1458|[证据](evidence/processed/0x06000087.il.txt)|
|P089|0x0600008A / 0x5878|0x8AB8|1578|[证据](evidence/processed/0x06000089.il.txt)|
