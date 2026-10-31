# W与W*的真实消费者

CAT I和CAT II的P307只读W，AUTO同时读W与W*。P412 mode2先求W*∩W线与WX线的交点，再求W*∩X在150m的交点，普通一条W跨线轮廓拆成两条；W仍参与，不是整体用W*替代W。

W*进入可达AUTO绘图。它也进入完整P41B的max候选，但P41B全局incoming为空，故不能称W*进入A5实际障碍物评价。PAOAS P427只引用W/X/Y/Z；改W*不会改PAOAS轮廓，独立测试已验证。GPINOP与FAF/FAP在UI上仅CATI可用，不应把强行改radio后的AUTO组合当公开模式。

E3同输入改W*：共享OAS mode0/1点列不变，mode2改变；另孤立调用P41B验证AUTO可选W*标签。这是独立源码结果，不是原插件UI执行。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P307|0x06000308 / 0x401EC|0x3537C|24174|[证据](evidence/processed/0x06000307.il.txt)|
|P412|0x06000413 / 0x647B4|0x523E0|42078|[证据](evidence/processed/0x06000412.il.txt)|
|P41B|0x0600041C / 0x65268|0x52DA4|42448|[证据](evidence/processed/0x0600041B.il.txt)|
|P427|0x06000428 / 0x6716C|0x548E8|43647|[证据](evidence/processed/0x06000427.il.txt)|
