# XData

P47C先生成 `FormApvEvl\n` 再P0FB遍历控件，把**完整序列化文本**传给P087/P089。

|实体/位置|数据|
|---|---|
|每一条Polyline|1001=WsObject；1000=完整控件状态（头+多行dotted path:value）|
|Group|未设置Description；未显式写Group XData；完整状态只写各Polyline|
|Mark的obst|Altitude为块Attribute，不能称为APV XData|

B3此链不写WsCalcuLine、Radius、Kind、RNP/APV面系数或类别结构化元数据。状态文本当然可能含HL等控件值，不等于存在独立HL元数据字段。

**button2/P483** GetEntity选择保护区实体，取整个XData.AsArray()[1]的Value后P0FD按FormApvEvl回填；未限定RegApp、未检查数组长度/语义schema。不存在自动匹配最新保护区或相交面功能。无XData时提示，选错其他App数据时保留旧异常/格式不符行为。
