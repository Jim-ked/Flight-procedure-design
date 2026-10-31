# XData

每条边界Polyline经P089写`1001=WsObject`、`1000=P565完整多行OAS参数文本`。文本含AppType/CAT/GP/FAF/ELEV/LIGHT及五面系数，**不是B3的Form头+dotted控件树状态**。没有Kind/Radius/面名等独立字段；Group没有描述或XData赋值。

P56B的“请选择OAS面”实际允许GetEntity任意实体，拿整个XData.AsArray()[1].Value.ToString()给P561。没有指定RegApp、长度/模式校验，没有根据图元反算面系数，也没有真实三维面选择。无XData提示；错schema/短数组保留旧错误可能。

Mark的Altitude为Block Attribute，不能称为OAS XData；P557另读XData[3]名称，但它是无调用旧parser，不同于当前P12F名称解析。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P565|0x06000566 / 0x8B9E4|0x71BD4|61487|
|P56B|0x0600056C / 0x8C5C4|0x725B0|61820|
|P557|0x06000558 / 0x89EE0|0x708EC|60867|
|P089|0x0600008A / 0x5878|0x8AB8|1578|
|P57D|0x0600057E / 0x8E114|0x73724|62563|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
