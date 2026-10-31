# 普通OAS列表与创建顺序

P306直接取共享P412生成的_0088_0091_009D，不构造B4 _008C_0095，不追加SOC同轴带。

|创建顺序（0基）|内部构造|几何来源|
|---|---|---|
|0/1|P416/P417|正/负Y面0至cap轮廓|
|2|P81F(YZ0,YZcap)|跨中线Z轮廓|
|3|P41A|入口至WX0中线|
|4（CATI/II）|P81F(WX0,WXcap)|W跨中线轮廓|
|4/5（AUTO）|P81F(W/W*点,W*/Xcap)，P81F(WX0,W/W*点)|先W*段再W段|
|最后2条|P414/P415|X正/负侧轮廓；AUTO六顶点，普通五顶点|

CATI/II：7条，顶点5/5/5/2/5/5/5；AUTO：8条，5/5/5/2/5/5/6/6。以上为默认Build()请求高度0；共享P412存在高于300的另一调用分支，但A5普通模式没有传该请求。

统一P087创建一个Group，逐列表创建二维Polyline、入ModelSpace、加XData、加入Group，最后Group入库。每条完整参数文本相同；无独立surface业务名。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P306|0x06000307 / 0x3FDF0|0x34FDC|24016|[证据](evidence/processed/0x06000306.il.txt)|
|P412|0x06000413 / 0x647B4|0x523E0|42078|[证据](evidence/processed/0x06000412.il.txt)|
|P414|0x06000415 / 0x64F9C|0x52B24|42375|[证据](evidence/processed/0x06000414.il.txt)|
|P415|0x06000416 / 0x6500C|0x52B8C|42390|[证据](evidence/processed/0x06000415.il.txt)|
|P416|0x06000417 / 0x6509C|0x52C10|42405|[证据](evidence/processed/0x06000416.il.txt)|
|P417|0x06000418 / 0x650F4|0x52C60|42410|[证据](evidence/processed/0x06000417.il.txt)|
|P41A|0x0600041B / 0x65200|0x52D44|42439|[证据](evidence/processed/0x0600041A.il.txt)|
|P087|0x06000088 / 0x555C|0x87E0|1458|[证据](evidence/processed/0x06000087.il.txt)|
|P089|0x0600008A / 0x5878|0x8AB8|1578|[证据](evidence/processed/0x06000089.il.txt)|
