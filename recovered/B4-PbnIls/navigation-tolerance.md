# 导航容差与固定宽度

|值|真实来源/setter|consumer|单位与可证明语义|
|---|---|---|---|
|1852|P5DF/P5E0常量|Y/Z交线到内边、后段内边、比例分母|m；主/副区内边半宽的实现值|
|3704|P5DF/P5E0常量|辅助线外边交点、Y/副面交点、评价外侧限|m；总半宽，副区宽=1852|
|30|P5DF/P567|副区外边抬高30；后处理减fraction*30|m；向外放宽的面高/超障项，不是30°|
|20000|P5DF|内侧后端点的x回退|m；仅绘图/拟合支撑点，不是评价截断|
|1482/4630/9260|B4核心未找到|无|不能借用其他模块|

没有可达ATT/XTT/RNP/SW输入、容差表查询或随导航方式变更分支。1852和3704分别为1NM与2NM的数值换算，但**代码没有RNP1枚举/系数推导证据**，实现依据待确认。固定宽度与规范PBN通式1.5XTT+BV不能自动等同。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P5DF|0x060005E0 / 0xB3034|0x84750|71828|
|P5E0|0x060005E1 / 0xB36EC|0x84CAC|71916|
|P567|0x06000568 / 0x8BBEC|0x71DB0|61497|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
