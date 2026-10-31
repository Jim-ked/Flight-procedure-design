# Round 7 — B4 PBN-ILS

**PARTIALLY ACCEPTED (static recovery)，2026-10-28。** 完成本轮证据恢复并停止；不进入 A5。

B4 实际组合是：**OAS 系数查询/修正 + OAS 向同轴固定宽度复飞区的衔接绘图 + 独立未调度的面评价/最低标准方法**。没有证据支持完整任意定点转弯程序。窗口只长期保存源 DBPoint 列表、ID 字典和 HL 表；没有统一 Procedure，也没有常驻的 OAS+转弯+障碍物程序对象。

参数事件用共享 OasModel（W/W*/X/Y/Z）；CAD 临时构造另一个 PbnIlsTurn（原类 _008C_0095，保留历史业务称呼，**不代表已恢复任意转弯**），只含 W/X/Y/Z、SOC 衔接和副区数值面。CAT II AUTO 的 W* 没有进入这个专用模型。CAD、ScreenData/转换、导入状态可达；Evaluate 仅弹“基础版不支持此功能”；KML 空体。

## 已交付

- 四个数值类完整机械恢复、13 个 Form 数值/序列化方法、数据行/CAD变换测试适配器及真实空 KML 入口。
- [事件图](event-map.md)、[参数模型](oas-parameter-model.md)、[曲面与域](oas-surfaces.md)、[衔接构造](oas-pbn-connection.md)、[障碍物链](obstacle-evaluation.md)。
- 243 个方法索引（84 个核心含共享 OAS），原/处理 IL、字段读写、条件分支、全局 incoming、泛型解析和 CAD API 索引。
- [33 项逐条答复](../round7/closure.md)、[分层验证](verification.md)、[未恢复/原实现缺口](unrecovered.md)。

## 验收缺口

存在完整但无调用的评价器；KML 缺失；没有任意 TP/左右转/转弯后航迹代码。已能恢复同轴 OAS→固定宽度衔接规则，但不能把它替换为完整 PBN 定点转弯。没有补按钮、补导出或补转弯。任何工程可用性均未由本轮证明。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P551|0x06000552 / 0x8973C|0x4F00||
|P55C|0x0600055D / 0x8A970|0x710AC|61057|
|P55D|0x0600055E / 0x8ABAC|0x7123C|61094|
|P566|0x06000567 / 0x8BBC8|0x4A1E|61492|
|P567|0x06000568 / 0x8BBEC|0x71DB0|61497|
|P56D|0x0600056E / 0x8C978|0x2B6A|61904|
|P570|0x06000571 / 0x8CAD8|0x72830|61931|
|P5DF|0x060005E0 / 0xB3034|0x84750|71828|
|P5E0|0x060005E1 / 0xB36EC|0x84CAC|71916|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
