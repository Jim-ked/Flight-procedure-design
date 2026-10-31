# OAS 参数模型

## 两套模型

共享 OasModel（P411–P41E）字段 `_0088_0091_0096=W,0097=W*,0098=X,0099=Y,009A=Z`，每面 PlaneCarrier(A,B,C)；mode009B为组合框索引0/1/2；cap009C为300/150/150m。枚举元数据只有value__，没有命名常量，恢复代码保留数值枚举。

B4专用 PbnIlsTurn（P5DD–P5EB）字段 `_008A_008B_0090=W,0091=X,0092=Y,0093=Z`，cap0094恒300m，无mode/W*字段。P55D从UI读12个系数后Build/Transition。共享模型支持AUTO不等于专用CAD/评价支持AUTO。

## 参数、setter、reader与单位

|字段/控件|初值及setter|reader/consumer|单位/说明|
|---|---|---|---|
|textBoxWA/WB/WC；WsA/B/C；XA/B/C；YA/B/C；ZA/B/C|设计器为0.001类占位；P575、TXT P561、可编辑文本、config回填|P55D读W/X/Y/Z，P565保存全部五面|A/B无量纲，C米|
|comboBoxAppType|Load索引0；用户变更P576、TXT/config|DB key；共享mode；WS显示|CAT I / CAT II / CAT II AUTO|
|comboBoxCat|Load索引3(D)，P577写A/B30/6、C/D32.5/7、DL40/8|尺寸修正、HL表、TXT|翼参数是半翼展s，轮参数t，米；DL索引4与仅4行HL表不兼容|
|comboBoxGP|Load索引5，设计器列表对应3.0；P578/TXT/config|数据库、SOC、Ha/RVR|度|
|comboBoxMissCG|Load索引3，对应2.5|数据库、P567中100/CG|百分数数值，不先除100|
|textBoxRDH|设计器15；Validated/Enter触发P570|P574修正C|米|
|LocDistance|设计器3280；P570夹到2000–4500；P571再Round到整数|PartB key|米；逐米查表，没有插值|
|textBoxFAF|设计器/配置/TXT；通常900|P55D的FAF−THR.Z−150|绝对标高输入，**不是FAF坐标**|
|textBoxAdElev|机场标高，可编辑/TXT/config|P55F、P567|米；与HL检查页textBoxElev分开|
|textBox1(DH)|可编辑/config；设计器初值见全控件表|P55E→SOC→P5DF|米；不用于共享系数解码|
|comboCat、HLm/HLr/HLcor、textBoxElev|HL检查页P568/P56A|HLcor仅显示；业务按comboBoxCat另算|m；无GP修正|
|textBoxLGT|TXT/config/手输|P567 RVR|米|
|checkBoxShowOas|P55D读取|只控制首批Y/Z轮廓是否加入；非总开关|布尔；X/W和衔接仍生成|

设计器初值、所有控件名/字段、业务读写定位完整列于 [parameter-control-inventory.csv](evidence/parameter-control-inventory.csv)。AppType设计器Enabled=false，Evaluate/KML为Visible=false，WS三框初始隐藏，HLm/r/cor禁用，表ReadOnly=true；绑定/静态可达不等于可鼠标触发。Load先改组合框再load config，可能触发多次DB重算。原config可以覆盖支持的值，本轮未运行，不能把设计值当实际启动状态。

## 数据来源

P571直接打开程序集目录oas.db，PartA与PartB均用参数化`ID=@id`。keyA=`(GP+modeInteger+MissCG).Replace(".","")`；keyB=keyA+`(int)Round(LOC,0)`。缺文件提示并null；缺行ExecuteScalar().ToString无null检查。不是从样例TXT自动读取，也不是硬编码系数表。

P572解码：非零数字d→10−d，0保留，然后整串逆序。PartA对各片段分别解码：Z.C[0:4]×−.01；W.A[4:9]×1e−6、W.C[9:12]×−.01；W*.A[12:17]×1e−6、W*.C[17:21]×−.01。Z.A取keyA.Substring(3,2)×−.001；W/W*/Z.B=0。PartB先整串解码再切：X.A[0:5]、B[5:11]、C[11:15]；Y.A[15:20]、B[20:26]、C[26:30]，A/B×1e−6，C×−.01。

P573：W/W*.C减(t−6)；P=max(t/Bx,s+(t−3)/Bx)−max(6/Bx,30+3/Bx)；X.C减Bx×P、Y.C减By×P。P574给W/W*/X/Y.C加RDH−15；Z不改。P575把A/B输出f6、C输出f2，随后CAD重新读这个已舍入文本。

只读SQLite核验：PartA275行、PartB687775行；[database-extract.json](evidence/database-extract.json)保存原路径/hash、schema、27组原始值和解码结果。Python以mode=ro&immutable=1打开，未加载目标SQLite DLL。样例OAS参数I/II/IIA只是可导入文本，不能替代当前数据库选择值。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P411|0x06000412 / 0x645A4|0x52294|42044|
|P55D|0x0600055E / 0x8ABAC|0x7123C|61094|
|P570|0x06000571 / 0x8CAD8|0x72830|61931|
|P571|0x06000572 / 0x8CD50|0x729A0|61987|
|P572|0x06000573 / 0x8D2F8|0x72DA4|62084|
|P573|0x06000574 / 0x8D4CC|0x72F14|62207|
|P574|0x06000575 / 0x8D6B8|0x730C8|62284|
|P575|0x06000576 / 0x8D7E0|0x73168|62307|
|P577|0x06000578 / 0x8DC70|0x7346C|62384|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
