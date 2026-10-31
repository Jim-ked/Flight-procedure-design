# 孤立面高方法与评价缺口

P41B共享OAS、P429 PAOAS均已完整恢复并独立测试；两者全程序集direct/MethodSpec incoming均为空，事件闭包不含它们。A5未见obstacle parser、ScreenData、Evaluate、Mark、Highlight或最低标准入口。不是存在一个尚待补接的已授权实现；本轮只报告缺口。

|方法|输入/输出|业务边界|reachability|
|---|---|---|---|
|P41B|局部点；面名/面高或out|W/X/Y/Z/AUTO W*与cap/尾部域；不算穿透/HL|orphan complete method|
|P429|局部点；W/X/Y/Z/P1/P2/Gnd/out与面高|PAOAS分段，600m域；out可保留输入Z|orphan complete method|

全局incoming依据已包含MethodSpec解析；否定结论限于静态可见引用与事件路径，不能证明任意反射或外部程序集永远不调用。并未发现支持这些额外调用的证据，也不推断作者意图为旧版残留或隐藏功能。

数值用法见oas-surfaces.md及paoas.md。E3孤立调用不能改变原程序集orphan状态。依用户明确验收规则，本项要求Round8保持PARTIALLY ACCEPTED。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P41B|0x0600041C / 0x65268|0x52DA4|42448|[证据](evidence/processed/0x0600041B.il.txt)|
|P429|0x0600042A / 0x679E0|0x55010|43908|[证据](evidence/processed/0x06000429.il.txt)|
