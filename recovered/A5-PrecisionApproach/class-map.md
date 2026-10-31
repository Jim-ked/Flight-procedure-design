# 类与真正共享的边界

|角色|原反编译类名|入口/核心P|恢复文件/复用|
|---|---|---|---|
|A5 Form|_0089_008C|P302–P322|PrecisionApproachForm；仅恢复计算/状态/文件切片，非完整WinForms|
|参数loader/decoder/修正|_008A_0091|P409–P40C|OasParameters.Recovered.cs；B4私有复制类不同|
|共同OAS几何|_008A_0093|P411 ctor、P412 Build、P41B面高|复用冻结B4/OasModel.Recovered.cs，原程序同MethodDef|
|平面|_008F_0092|P834–P840|冻结B4/PlaneCarrier.Recovered.cs；数值对象，不是CAD Surface|
|GPINOP|_0089_0096|P39E–P3AA|GpInopGeometry.Recovered.cs|
|PAOAS L/R|_008A_0097|P427 ctor、P428 Build、P429面高|PaOasGeometry.Recovered.cs；两列表|
|PA-FAF|_008A_0099|P437 ctor、后续点列|PaFafGeometry.Recovered.cs|
|PA-FAP|_008A_009B|P443 ctor、后续点列|PaFapGeometry.Recovered.cs|
|点/线/点列/跑道frame|_008F_008E等|P7ED、P81F、P821/P823/P827等|复用冻结A6/B5数学源码|
|公共CAD writer|_008B|P087/P089|完整方法证据；独立测试不模拟AutoCAD数据库|
|B4专用几何|_008C_0095|P5DD–P5EB|A5未构造，非统一引擎|

存在统一 OasModel 基础面/交点层，**不存在六模式完全相同的几何引擎**。各模式私有类消费共同系数、交线与fix/IF。普通OAS直接选共享列表，PAOAS选预先生成的左右列表，其余构造专用类。P307在dispatch前无条件创建/准备共同模型，因此一个模式也可能因别的模式参数文本错误而受影响。

交叉关系按原程序集 MethodDef 判定；本轮编译引用相同恢复源文件只证明测试复用，不单独证明原调用。完整调用身份见 ../round8/shared-calls.csv。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P307|0x06000308 / 0x401EC|0x3537C|24174|[证据](evidence/processed/0x06000307.il.txt)|
|P409|0x0600040A / 0x63AE4|0x51B54|41676|[证据](evidence/processed/0x06000409.il.txt)|
|P411|0x06000412 / 0x645A4|0x52294||[证据](evidence/processed/0x06000411.il.txt)|
|P412|0x06000413 / 0x647B4|0x523E0|42078|[证据](evidence/processed/0x06000412.il.txt)|
|P39E|0x0600039F / 0x5CA54|0x4CA9C|38366|[证据](evidence/processed/0x0600039E.il.txt)|
|P427|0x06000428 / 0x6716C|0x548E8|43647|[证据](evidence/processed/0x06000427.il.txt)|
|P437|0x06000438 / 0x68AF8|0x55DA8|44470|[证据](evidence/processed/0x06000437.il.txt)|
|P443|0x06000444 / 0x699B8|0x56848|44929|[证据](evidence/processed/0x06000443.il.txt)|
|P834|0x06000835 / 0xCA098|0x931D4||[证据](evidence/processed/0x06000834.il.txt)|
|P087|0x06000088 / 0x555C|0x87E0|1458|[证据](evidence/processed/0x06000087.il.txt)|
