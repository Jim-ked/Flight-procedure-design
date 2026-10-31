# 验证分层、适配与实际限制

## 分层结果

全部成功，数值断言和静态检查分开计数：

|层|通过数|覆盖内容|
|---|---|---|
|database|406|27组真实DB行；CAT0/1/2，GP3/3.2/3.5，LOC2000/3000/4500；缺文件另列|
|cross-module|810|A5 loader/修正与B4复制实现比较；不是独立标准oracle|
|formula|437|尺寸/RDH12/15/18、fix/IF、交换、RDH不进入名义点|
|surface|311|交线独立线性代数参考；Wstar敏感性；P41B及P429孤立边界|
|geometry|975|六模式有限点、mirror、清Z；F650/900/1200，L0/6000/10000，T0/700/900；异常Z、GP3.2、Wstar不进PAOAS|
|mode-dispatch|15|六分支优先级、CAT UI gate、Wstar显隐、PAOAS面板|
|serialization|14|四段协议、full/OAS-only、精度、旧CSV不兼容|
|degenerate|12|GP0/非法、负高、零距、缺key/文件/字段、部分写入、LOC夹限|
|event/reachability|32 静态检查|原/处理事件身份、MethodSpec incoming、orphan、无外部Start、无B4构造、真实fixture一致性|

独立源码 **2980** 条 + 静态 **32** 条；不能合称原程序集运行验证。

## 复现与适配边界

`python recovered/round8/build.py`编译本轮独立恢复源码及冻结数学依赖，再运行Round8.Tests.exe；测试不加载目标DLL/AutoCAD/目标SQLite库。系统csc写PE在沙箱下曾CS0016，经限定命令提权后成功；仅操作本轮输出。适配器内存fixture代替文件/SQLite IO；保留SQL/key/decoder/修正业务体。Cell仅模拟被读取的控件属性，不模拟WinForms自动互斥、Text到SelectedIndex、事件重算时序。P306仅计算dispatch/transform，CAD事务与实体创建依据IL静态核对，未模拟宿主API。

[tests.log](../round8/tests.log)、[compile-tests.log](../round8/compile-tests.log)、[数值记录](../round8/fixtures/assertions.csv)、[分层计数](../round8/fixtures/numeric-counts.json)、[32项静态检查](../round8/static-tests.json)、[源码输入哈希](../round8/test-inputs.json)、[fixture索引](../round8/fixture-index.json)。空编译日志表示csc无诊断，不表示漏执行。

fixtures/failure.txt保存早期测试模板误计PA-FAF13条（实际12）的历史失败，不代表当前失败；初期其他数量也曾误计，均按IL Add链纠正测试期望，未改目标/恢复算法。收口时已归档为historical-failure.txt并在fixture索引中注明。额外测试初次误用PAOAS三参构造器导致CS1729，改为真实二参构造及赋值后重建；同样只改测试。

本轮不是全输入穷举，也没有证明与原程序数值逐点等价。跨模块复制算法比较不充当独立规范证明；有限点/清Z断言只覆盖投影性质，列表构造/未Add局部点等由原/处理IL静态证据补强。测试通过不消除原行为异常、不可达评价链或未知历史依据。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。
