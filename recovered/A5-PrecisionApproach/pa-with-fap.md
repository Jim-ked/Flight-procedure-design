# PA with FAP：名义点、中间段与截断

P307读取绝对fix标高F、THR.Z=T，H=F−T，g=tan(GP·π/180)，名义点=(H/g,0,H)，IF=(H/g+L,0,H)。L为textBoxIF输入的中间段长度；没有减RDH，也没有地球曲率。RDH此前只进入面系数修正。用户可手输F或通过相关CAD取点量距输入其他字段；没有独立FAP高度控件。

P306 FAP第一优先分支→P443：利用X/Y seam及X面在H−150的等高线求交，截断精密面上游轮廓。W/X在H−150交点如x>IF.x则夹到IF，并在IF站距另求W/X seam点。IF内/外半宽4630/9260；内边Z=H−150，外边Z=H。中间段与截断后的X/W/Y点列连接，再附共享中线、Z轮廓、Y两侧与15°尾部。

样本11条，8/6/6/5/6/6/2/5/5/5/4；IF长度/高度改变裁剪分支及部分顶点数。原P446/P447均构造第二个局部三角形但未Add至返回列表；不补输出。完整构造表达式和原IL保留，可审计每个交点/条件。

此处“FAP”是原UI/类路径名；规范FAP定义及带RDH/曲率站距候选另见映射报告，不能以规范重算该坐标。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P307|0x06000308 / 0x401EC|0x3537C|24174|[证据](evidence/processed/0x06000307.il.txt)|
|P443|0x06000444 / 0x699B8|0x56848|44929|[证据](evidence/processed/0x06000443.il.txt)|
|P444|0x06000445 / 0x69E24|0x56B7C|44979|[证据](evidence/processed/0x06000444.il.txt)|
|P445|0x06000446 / 0x69FC8|0x56CE0|45061|[证据](evidence/processed/0x06000445.il.txt)|
|P446|0x06000447 / 0x6A1BC|0x56DF0|45099|[证据](evidence/processed/0x06000446.il.txt)|
|P447|0x06000448 / 0x6A334|0x56E9C|45120|[证据](evidence/processed/0x06000447.il.txt)|
