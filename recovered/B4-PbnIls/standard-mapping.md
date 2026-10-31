# 规范映射（恢复之后对照）

基线为项目原PDF《航空器运行目视和仪表飞行程序设计规范》AC-97-FS-005、民航规〔2020〕12号。哈希和原路径见 [standard-search.json](evidence/standard-search.json)；页码均为PDF序号，不混用页脚印刷页。未用规范改写代码。

|恢复行为|条款/页|分类与差异|
|---|---|---|
|z=Ax+By+C、对称absY、max(0,各面)|II-1-1 1.4.8.4/.5，PDF275|matches current standard，方程和最大规则对应|
|共享CATI300、CATII150；W/X高于300例外|1.4.8.4.3 PDF275|共享模型局部对应；专用B4恒300、无mode且仅Y部分门控，differs/missing|
|CATII AUTO共享W*，B4专用模型丢弃W*|1.4.8.7.6 PDF276|参数层对应，绘图/专用评价缺失；无独立运行审定条件验证|
|机体尺寸与RDH修正|1.4.8.7.3/.4 PDF276|算术matches；RDH大于15也统一加，规范允许不调，属于具体实现选择|
|GP/LOC/复飞梯度查询表|1.4.8.4.2 PDF275、1.4.8.7.7 PDF277|数据结构对应；不能证明oas.db来自何版本PANS-OPS，**实现依据待确认**|
|HLm/r和Elev>900修正|表II-1-1-2 PDF286、1.4.8.8.3.1 PDF278|A-D基础表/标高项对应；B4无GP>3.2增量，round方式亦不同于条文示例向上取整，differs/missing|
|FAF标高−THR−150绘图请求|1.7.1.2 PDF285|代码不是FAF/FAP定义；Only terminology，不能确认完整规范角色|
|SOC=(DH−HL)/tanGP−900|1.5.1.2 PDF280、1.4.8.8.2 PDF277|公式形式有对应；没有独立程序模型/反馈链，模式和高基准问题保留|
|SOC处15°扩张、Y外推、Z延伸、副区0→30|1.5.2.3 PDF281|高度一致的结构候选：同轴传统→RNAV/RNP直线衔接；代码从300m线角减15°，不武断说绝对跑道角固定15°；局部匹配，完整合规未证|
|1852/3704固定半宽|III-1-1 1.5.4 PDF402|没有XTT/ATT/BV及导航方式推导，author simplification候选/**实现依据待确认**；不可直接标RNP1|
|无TP/earliest/latest/旁切/飞越及转弯曲线|1.5.3 PDF281–282|missing；不能把直线衔接当完整定点转弯|
|单记录Ha/HL后处理|1.4.8.8.2.1 PDF277|Ha算式形态对应；进近分支绝对/相对Z混用、无全局控制障碍物选择且UI断链，differs/missing|

未发现足够证据把异常归到某一旧版ICAO Doc8168或旧国内规范。旧版本/作者简化仅列候选，数据库版本和实际采用依据仍待确认。没有根据课件点名/规范图示给空缺业务补实现。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P41B|0x0600041C / 0x65268|0x52DA4|42448|
|P55D|0x0600055E / 0x8ABAC|0x7123C|61094|
|P55E|0x0600055F / 0x8AEF0|0x71484|61122|
|P55F|0x06000560 / 0x8AF6C|0x714F8|61131|
|P567|0x06000568 / 0x8BBEC|0x71DB0|61497|
|P571|0x06000572 / 0x8CD50|0x729A0|61987|
|P573|0x06000574 / 0x8D4CC|0x72F14|62207|
|P574|0x06000575 / 0x8D6B8|0x730C8|62284|
|P5DF|0x060005E0 / 0xB3034|0x84750|71828|
|P5E0|0x060005E1 / 0xB36EC|0x84CAC|71916|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
