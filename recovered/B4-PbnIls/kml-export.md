# KML — 原实现为空

button8.Text=KML，Click绑定P56D。原始对应MethodDef的IL是3个nop+ret；处理后是单ret。没有导出实体、坐标转换/经纬度、Polygon/LineString、业务名称、style或altitudeMode。不能把项目其他模块的KML库接入B4。

[PbnIlsKml.Recovered.cs](PbnIlsKml.Recovered.cs)忠实保存空入口。测试只确认恢复入口无输出，不能称作KML导出功能通过。KML不能确认BoundaryList语义；[kml-cad-map.csv](../round7/kml-cad-map.csv)逐列表把KML项记为N/A(stub)，CAD几何解释仅由点/平面来源证明。

帮助声称可导出KML，与实际方法体不符，作为文档差异保存 [help-original.html](evidence/help-original.html)。没有伪造KML示例作为恢复成果；验收保持PARTIALLY ACCEPTED。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P56D|0x0600056E / 0x8C978|0x2B6A|61904|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
