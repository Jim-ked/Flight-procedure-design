# 直接事件图（静态候选）

来源 events.csv；不是运行时完整图。处理后 token 需通过 tool-token-map 对应原件。

```text
FormCalcu.buttonNpaSOC --Click--> _0097_009E [0x06000232]
FormCalcu.textBoxRDH --Validated--> _0097_009A [0x0600022E]
FormCalcu.buttonPaSOC --Click--> _0098_0088 [0x06000235]
FormCalcu.comboXz --SelectedIndexChanged--> _0098_0089 [0x06000236]
FormCalcu.comboXz --TabIndexChanged--> _0098_0088 [0x06000235]
FormCalcu.comboXz --Validated--> _0098_0089 [0x06000236]
FormCalcu.textBoxSocH --Validated--> _0098_0089 [0x06000236]
FormCalcu.textBoxDH --Validated--> _0098_0089 [0x06000236]
FormCalcu.textBoxDPdg --Validated--> _0098_0092 [0x0600023F]
FormCalcu.buttonMissTP --Click--> _0098_008D [0x0600023A]
FormCalcu.buttonC --Click--> _0098_0093 [0x06000240]
FormCalcu.textBoxTHR --Validated--> _0097_009A [0x0600022E]
FormCalcu.textBoxMPdg --Validated--> _0098_008F [0x0600023C]
FormCalcu.buttonDepTP --Click--> _0098_0090 [0x0600023D]
FormCalcu.textBoxNTime --Validated--> _0098_0087 [0x06000234]
FormCalcu.textBoxDEnd --Validated--> _0098_0092 [0x0600023F]
FormCalcu.textBoxDStart --Validated--> _0098_0092 [0x0600023F]
FormCalcu.buttonFAF --Click--> _0097_0099 [0x0600022D]
FormCalcu.comboCat --SelectedIndexChanged--> _0098_008B [0x06000238]
FormCalcu.textBoxMEnd --Validated--> _0098_008F [0x0600023C]
FormCalcu.textBoxMStart --Validated--> _0098_008F [0x0600023C]
FormCalcu.FormCalcu --FormClosed--> _0097_0098 [0x0600022C]
FormCalcu.FormCalcu --Load--> _0097_0097 [0x0600022B]
FormCalcu.textBoxCTime --Validated--> _0098_0095 [0x06000242]
FormCalcu.textBoxGP --Validated--> _0097_009A [0x0600022E]
FormCalcu.textBoxFAF --Validated--> _0097_009A [0x0600022E]
FormCalcu.textBoxElev --Validated--> _0098_008B [0x06000238]
FormCalcu.comboBoxGP --SelectedIndexChanged--> _0098_0089 [0x06000236]
FormCalcu.textBoxHLcor --Validated--> _0098_0089 [0x06000236]
```

各 handler 的后续IL边见 outgoing-il.csv；共享模块的入边见 incoming-il.csv。计算/几何语义不由此图自动推定。
