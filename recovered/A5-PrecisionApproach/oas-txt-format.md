# A5参数文件完整协议

P319输出：

```text
RUNWAY:{...}|APPROACH:{...}|PAOAS:{...}|OAS:{...}
```

每一段值是独立JSON对象；整体不是单一合法JSON。P31C默认扩展名.json，也支持.txt，UTF8写出；P31D UTF8读取后P31B选择导入范围。没有因扩展名txt自动采用B4 CSV解析器。

|分段/字段（大小写敏感）|Control / business consumer|数据库/输出关系|
|---|---|---|
|RUNWAY.THR / DER，各X/Y/Z|THR/end六文本，P306frame / P307相对高度|不参与DB key；决定变换|
|APPROACH.AppType|comboBoxAppType.Text|DB mode来源依UI SelectedIndex；文本回填事件时序未模拟|
|CAT|comboBoxCat.Text|尺寸默认setter，A5无HL表|
|GP|comboBoxGP.Text|DB key、fix、P1.A|
|MissedCG|comboBoxMissCG.Text|DB key|
|LocDistance|LocDistance.Text|PartB key，保存为字符串|
|RDH|textBoxRDH|P40C面常数修正|
|WingSpan / WheelBase|textBoxWing / textBoxWheel|实际半翼展s/轮参数t，不自动改字段名|
|FAF_Height / IF_Length / FAF_Tolerance|textBoxFAF / textBoxIF / textBoxFafFix|F绝对标高 / L追加长度 / T容差，米|
|PAOAS.P1/P2，各a/b/c|六文本|P307/PAOAS构造，非DB字段|
|OAS.W / Ws / X / Y / Z，各a/b/c|十五面系数文本|P307读模型；**Ws**不是WS/W*；写每条Polyline完整快照|

AppType/CAT/GP/MissedCG/LocDistance保存为字符串，其余为数值。无ELEV/LIGHT、draw mode、HL或最低标准字段；B4旧样例的同名/近似字段不构成兼容。

P31A按`|`分段，首个`:`拆名称，区分大小写，重复分段后者覆盖。full=true按RUNWAY→APPROACH→PAOAS→OAS写控件；false只OAS。数值一般F2，面A/B F6、C F2，P1/P2 A/B F4。缺分段可能跳过，缺成员可能写入部分控件后catch提示；没有事务回滚。E3验证缺W.b时W.a已改动仍保留。P31B默认Button2（仅OAS），用户可选全部。

完整可解析样本在fixtures/a5-parameters.txt。序列化恢复使用同JavaScriptSerializer；测试Cell不模拟WinForms Text/SelectedIndex联动、事件重入和config时序，往返通过不代表原UI最终状态已动态验证。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P319|0x0600031A / 0x41DD0|0x36594|24808|[证据](evidence/processed/0x06000319.il.txt)|
|P31A|0x0600031B / 0x4259C|0x36D38|24964|[证据](evidence/processed/0x0600031A.il.txt)|
|P31B|0x0600031C / 0x43518|0x4391|25482|[证据](evidence/processed/0x0600031B.il.txt)|
|P31C|0x0600031D / 0x43558|0x37BD0|25487|[证据](evidence/processed/0x0600031C.il.txt)|
|P31D|0x0600031E / 0x43730|0x37CDC|25533|[证据](evidence/processed/0x0600031D.il.txt)|
