# HL / DH / SOC

HL表仅A/B/C/D四行：HLm={40,43,46,49}、HLr={13,18,22,26}。业务P55F按comboBoxCat.SelectedIndex索引，AdElev>900加HLr*.02*AdElev/300；≤900直接HLm。无GP项、无round。类别DL会索引越界；P567虽有H对应700m的文字分支，当前4行表及UI并未提供完整H支持，不能自动补表。

HL检查页是另一组comboCat/textBoxElev/HLm/HLr：P568设置表值后P56A；P569亦调用P56A。Elev>900时Round(HLm+HLr*.02*Elev/300,2)，否则复制HLm文字。HLcor显示文本不被SOC/评价读取。

P567最低标准支路再算HL=HLm+(Elev>900?Round(HLr*.02*Elev/300,2):0)，仅修正增量round。三条代码不是同MethodDef。B3 APV P5F2独立实现，另有GP>3.2的增量且类别处理不同；[b3-b4-hl-comparison.csv](../round7/b3-b4-hl-comparison.csv)记录差异。绝不能复用B3修正填入B4。

## DH和SOC

DH控件textBox1（`_0089_009B_0088`）的业务reader只有P55E：

`SOCx = Round((DH−P55F_HL)/tan(GP*PI/180) − 900)`。

P55D→P5DF(SOCx)，影响E′及衔接几何；不是只显示，也不是直接输入P5E0的障碍物评价阈值。没有独立SOC对象、ThrToSoc/SocToTp字段，但**确有SOC公式/参数传递**。不输出“无SOC证据”。GP=0传播Infinity/NaN；无追加校验。没有HL==0保护或依据mode变更−900。P567计算的DH是每个障碍物结果字段，未见回写这个输入控件或再循环绘图。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P55E|0x0600055F / 0x8AEF0|0x71484|61122|
|P55F|0x06000560 / 0x8AF6C|0x714F8|61131|
|P567|0x06000568 / 0x8BBEC|0x71DB0|61497|
|P568|0x06000569 / 0x8C38C|0x72488|61778|
|P569|0x0600056A / 0x8C464|0x4F6F|61789|
|P56A|0x0600056B / 0x8C474|0x724F8|61794|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
