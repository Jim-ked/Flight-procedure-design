# 原实现缺口与恢复限制

1. P5E0/P567/P41B均有完整数值方法但未找到调用；没有可达完整评价链，未补调度。
2. KML原方法空体，缺完整导出。帮助宣称不能替代IL。
3. 未找到任意TP、方向、出航点、earliest/latest或风螺旋；只恢复同轴衔接。无法从提供版本恢复不存在的业务。
4. 专用CAD/evaluator无W*/CATII cap；原代码保留，不替换成共享OAS。
5. TXT不保存完整程序；WinForms配置回填/事件重算时序、原CAD事务/实体选择与DWG符号均未运行验证。
6. 原始方法大多受保护；E0只证明身份/保护状态，主要算法证据为E1/E2，E3无原程序oracle，E4为空。
7. 不扩大A5恢复，仅查询共享类与参数helper；A5完整HL/障碍物调度/文档差异未验收。

这些是PARTIALLY ACCEPTED的具体原因；报告/源码交付已在本轮范围收口，不以补软件功能获得ACCEPTED。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P41B|0x0600041C / 0x65268|0x52DA4|42448|
|P567|0x06000568 / 0x8BBEC|0x71DB0|61497|
|P56D|0x0600056E / 0x8C978|0x2B6A|61904|
|P5E0|0x060005E1 / 0xB36EC|0x84CAC|71916|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
