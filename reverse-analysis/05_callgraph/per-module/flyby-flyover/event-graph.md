# 直接事件图（静态候选）

来源 events.csv；不是运行时完整图。处理后 token 需通过 tool-token-map 对应原件。

```text
FormFlyBy.button5 --Click--> _0089_0089_0098 [0x060004C4]
FormFlyBy.button4 --Click--> _0089_0089_0097 [0x060004C3]
FormFlyBy.button2 --Click--> _0089_0089_0096 [0x060004C2]
FormFlyBy.button1 --Click--> _0089_0089_0093 [0x060004BF]
FormFlyBy.FormFlyBy --FormClosed--> _0089_0089_0094 [0x060004C0]
FormFlyBy.FormFlyBy --Load--> _0089_0089_0095 [0x060004C1]
FormFlyOverDF.FormFlyOverDF --FormClosed--> _0089_008B_0087 [0x060004DC]
FormFlyOverDF.FormFlyOverDF --Load--> _0089_008B_0088 [0x060004DD]
FormFlyOverDF.button2 --Click--> _0089_008B_0089 [0x060004DE]
FormFlyOverDF.button1 --Click--> _0089_008B_008A [0x060004DF]
```

各 handler 的后续IL边见 outgoing-il.csv；共享模块的入边见 incoming-il.csv。计算/几何语义不由此图自动推定。
