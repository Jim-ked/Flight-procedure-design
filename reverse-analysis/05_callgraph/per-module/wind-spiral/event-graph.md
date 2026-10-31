# 直接事件图（静态候选）

来源 events.csv；不是运行时完整图。处理后 token 需通过 tool-token-map 对应原件。

```text
FormWindSpiral.textBoxInitOffset --TextChanged--> _0087_009E_008F [0x06000392]
FormWindSpiral.checkBoxTangent --CheckedChanged--> _0087_009E_0088 [0x0600038B]
FormWindSpiral.button1 --Click--> _0087_009E_0093 [0x06000396]
FormWindSpiral.button5 --Click--> _0087_009E_0092 [0x06000395]
FormWindSpiral.button4 --Click--> _0087_009E_008E [0x06000391]
FormWindSpiral.buttonSingle --Click--> _0087_009D_009E [0x06000388]
FormWindSpiral.buttonDouble --Click--> _0087_009D_009D [0x06000387]
FormWindSpiral.FormWindSpiral --FormClosed--> _0087_009E_0087 [0x0600038A]
FormWindSpiral.FormWindSpiral --Load--> _0087_009E_0086 [0x06000389]
FormWindSpiral.button2 --Click--> _0087_009D_009C [0x06000386]
FormWindSpiral.button3 --Click--> _0087_009E_0089 [0x0600038C]
FormWindSpiral.textBoxEndAngle --TextChanged--> _0087_009E_0091 [0x06000394]
FormWindSpiral.textBoxStartAngle --TextChanged--> _0087_009E_0090 [0x06000393]
```

各 handler 的后续IL边见 outgoing-il.csv；共享模块的入边见 incoming-il.csv。计算/几何语义不由此图自动推定。
