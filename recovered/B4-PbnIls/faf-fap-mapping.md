# FAF / FAP

|代码/控件|UI语义|实际坐标/consumer|规范解释|
|---|---|---|---|
|textBoxFAF `_0089_009A_008A`|FAF/FAP高度类输入；保存键FAF|只读标高，P55D请求高度=值−THR.Z−150；>300时扩展W/X绘图；也保存TXT|没有足够证据把这个标高控件当作FAF/FAP平面定位点|
|FAP对象、FafFix对象|未发现|无坐标、容差或传入定点转弯数据|未实现证据，不借用B3 FafFix|
|GP|下滑角|系数key、SOC、后处理|没有通过FAF输入反算航路点坐标的调用|

P412共享OAS接受可选绘图高度，但B4 P570调用它时使用默认0；CAD另在P55D调用专用模型，并用FAF−入口−150作为高程上限请求。这个差值不是独立FAF/FAP定义或完整航段。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P55D|0x0600055E / 0x8ABAC|0x7123C|61094|
|P565|0x06000566 / 0x8B9E4|0x71BD4|61487|
|P570|0x06000571 / 0x8CAD8|0x72830|61931|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
