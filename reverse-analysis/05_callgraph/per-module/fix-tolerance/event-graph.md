# 直接事件图（静态候选）

来源 events.csv；不是运行时完整图。处理后 token 需通过 tool-token-map 对应原件。

```text
FixTolerance.textBox2 --Leave--> _0095_008A [0x06000212]
FixTolerance.radioButtonVOR --CheckedChanged--> _0094_009A [0x06000209]
FixTolerance.checkBoxDme --CheckedChanged--> _0095_008D [0x06000215]
FixTolerance.button1 --Click--> _0095_0086 [0x0600020E]
FixTolerance.checkBoxGuide --CheckStateChanged--> _0094_009D [0x0600020C]
FixTolerance.radioButtonNDB --CheckedChanged--> _0094_009C [0x0600020B]
FixTolerance.radioButtonV --CheckedChanged--> _0095_008B [0x06000213]
FixTolerance.radioButtonN --CheckedChanged--> _0095_008A [0x06000212]
FixTolerance.radioButtonILS --CheckedChanged--> _0094_009B [0x0600020A]
FixTolerance.FixTolerance --FormClosed--> _0095_0088 [0x06000210]
FixTolerance.FixTolerance --Load--> _0095_0087 [0x0600020F]
FixTolerance.checkBox2 --CheckedChanged--> _0095_008C [0x06000214]
FixTolerance.button2 --Click--> _0095_0089 [0x06000211]
```

各 handler 的后续IL边见 outgoing-il.csv；共享模块的入边见 incoming-il.csv。计算/几何语义不由此图自动推定。
