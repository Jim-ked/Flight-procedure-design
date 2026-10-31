# Load / Save

P560/P564分别选择UTF8 TXT文件读取/写入，P565是自定义OAS快照：

```text
AppType,<text>
CAT,<text>
GP,<text>
FAF，<text>
ELEV，<text>
LIGHT,<text>
W,A,B,C
WS,A,B,C
X,A,B,C
Y,A,B,C
Z,A,B,C
```

FAF/ELEV用中文逗号；导入P561全局替换中文逗号→ASCII，Split LF。至少5行，否则提示return；单行少于2字段跳过；key.Trim().ToUpper，NAME识别但不写值；面系数P562直接取[1]/[2]/[3].Trim，短三元组越界，额外项忽略。值以文字回填，没有统一数值schema或版本。保存系数是当前文本，不重新计算。

包含OAS模型参数及部分UI元数据；不含THR/end XYZ、DH、LOC、RDH、尺寸、MissCG等，无法单靠TXT恢复完整程序。combo回填可能触发DB重算，与后续系数行有顺序关系；本轮RecoveryCell只测文本分发，未模拟WinForms事件时序。

Form Load P553先设置组合框默认，再P0F6 load config.xml；Closed P554→P0F4 save config，节点FormPbnIlsEvl。这是通用控件状态持久化，与TXT格式不同，不是JSON/统一Procedure。CAD WsObject保存的是上面TXT，选OAS实体亦回填同一解析器。原config/样例均只读。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P553|0x06000554 / 0x897E8|0x7044C|60773|
|P554|0x06000555 / 0x89900|0x704C0|60787|
|P560|0x06000561 / 0x8B088|0x71584|61148|
|P561|0x06000562 / 0x8B1B8|0x71614|61172|
|P562|0x06000563 / 0x8B760|0x4F36|61444|
|P563|0x06000564 / 0x8B810|0x71AD8|61455|
|P564|0x06000565 / 0x8B864|0x71B28|61460|
|P565|0x06000566 / 0x8B9E4|0x71BD4|61487|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
