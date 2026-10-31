# A5 HL与B3/B4对照

未找到A5的HLm/HLr表、机场标高修正、GP修正、HL输入/显示控件或业务消费者。P41B/P429只返回面高/标签，不计算HL。**A5没有可恢复的自有HL公式，不能选用B3或B4填入。**

对照冻结结论：B3 APV P5F2=HLm+(Elev>900?HLr·.02·Elev/300:0)+(GP>3.2?(GP−3.2)·HLr·.05:0)，无round；B4 P55F无GP项、P567仅round机场增量、P56A round显示总和。A5三者均不调用。详见 [hl-comparison.csv](../round8/hl-comparison.csv)与冻结报告。

没有证据证明A5由另一窗口自动补齐最低标准；跨窗口数据关系只能记录已找到的公共模型/配置，不猜测隐藏评价路径。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P307|0x06000308 / 0x401EC|0x3537C|24174|[证据](evidence/processed/0x06000307.il.txt)|
|P41B|0x0600041C / 0x65268|0x52DA4|42448|[证据](evidence/processed/0x0600041B.il.txt)|
|P429|0x0600042A / 0x679E0|0x55010|43908|[证据](evidence/processed/0x06000429.il.txt)|
