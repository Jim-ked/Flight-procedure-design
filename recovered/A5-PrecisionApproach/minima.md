# 最低标准：缺失的可达业务链

A5未见DA、DH、OCA、OCH、RVR控件、后处理公式、表格、控制障碍物归并或ScreenData→Evaluate链。CAT I/II/AUTO只是模式/数据库/轮廓控制，不自动意味着具有相应运行最低标准计算。

P41B/P429为孤立单点面高函数；无障碍物原高减面高、HL、Ha→OCA/OCH、DA/DH/RVR调用。不能把孤立面高方法改名为最低标准评价器。帮助/规范的功能叙述不替代本构建事件可达证据。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P41B|0x0600041C / 0x65268|0x52DA4|42448|[证据](evidence/processed/0x0600041B.il.txt)|
|P429|0x0600042A / 0x679E0|0x55010|43908|[证据](evidence/processed/0x06000429.il.txt)|
