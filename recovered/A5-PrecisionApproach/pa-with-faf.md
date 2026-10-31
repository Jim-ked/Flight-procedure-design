# PA with FAF：容差与15%下降面

与FAP共用P307的名义fix=(H/tanGP,0,H)和IF=(fix.x+L,0,H)。FAF分支P437另读取textBoxFafFix作为容差T（默认700m），不是700m高度。

最早点E.x=fix.x+T；E.y由X面H−150等高线在E.x求得，E.z=H−150。辅助点=(E.x−1000,E.y,E.z−150)，与E及镜像E三点拟合下降平面，得到A=.15、B=0。这是**15%**，不是15°。该平面与W面及W/X seam相交求latest点，其Z由X面计算。相关W/X轮廓在early/latest边界截断，连接IF内/外半宽4630/9260与共享Y/Z尾部。

没有±900m上限校验；也没有对称±T两端，代码只显式构造x增加T的最早点，再由下降面求另一端。规范±0.9km不能当输入验证。默认900属于绝对标高textBoxFAF；默认700属于FAF定位容差。

样本12条，9/6/6/5/7/7/5/2/5/5/5/4。P43A/P43B第二局部三角形未Add，照实保留。日志中的FAFdesEarly/Latest来自恢复类Console输出，不是原CAD运行日志。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P307|0x06000308 / 0x401EC|0x3537C|24174|[证据](evidence/processed/0x06000307.il.txt)|
|P437|0x06000438 / 0x68AF8|0x55DA8|44470|[证据](evidence/processed/0x06000437.il.txt)|
|P438|0x06000439 / 0x68FA8|0x56214|44605|[证据](evidence/processed/0x06000438.il.txt)|
|P439|0x0600043A / 0x69160|0x563A8|44698|[证据](evidence/processed/0x06000439.il.txt)|
|P43A|0x0600043B / 0x692E4|0x56454|44717|[证据](evidence/processed/0x0600043A.il.txt)|
|P43B|0x0600043C / 0x69490|0x565B4|44812|[证据](evidence/processed/0x0600043B.il.txt)|
