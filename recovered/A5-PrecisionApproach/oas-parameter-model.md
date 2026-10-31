# A5参数、数据库与CAT模式

## 真实查库链与复制关系

P30A → **A5 P409** → P40A decoder → P40B尺寸 → P40C RDH → P412 Build → P30B回填。B4对应P571/P572/P573/P574，分别为不同MethodDef；不是同loader。SQL和schema相同，未发现A5独有插值；详见 [数据库比较](../round8/a5-b4-database-comparison.csv)。

程序集目录 oas.db：PartA/PartB均 `SELECT Value FROM PartA/PartB WHERE ID = @id`。keyA=`(GP+modeInteger+MissedCG).Replace(".","")`；keyB在其后追加`(int)Math.Round(LOC,0)`。文本串拼接与小数点去除保留原行为，不重新设计key。P30A先夹LOC到2000–4500；只有四个Combo SelectedIndex都不为−1才进入。逐整数米查表，**无插值**。缺文件提示并返回null；缺key的ExecuteScalar().ToString没有空值保护。

数据库原始SHA256 `a63ed87cbf5b816d46aef87463b7f0a3393d9cd6e83a0040b13fdea7858a025f`；PartA275行、PartB687775行。复用Round7只读SQLite导出27组，不加载原SQLite DLL；原行、schema和原路径保留在冻结 [database-extract.json](../B4-PbnIls/evidence/database-extract.json)。

## 解码及修正

P40A非零数字d→10−d，0保留，再整串逆序。PartA逐片段解码：Z.C[0:4]×−.01，W.A[4:9]×1e−6，W.C[9:12]×−.01，W*.A[12:17]×1e−6，W*.C[17:21]×−.01；Z.A=keyA.Substring(3,2)×−.001；W/W*/Z.B=0。PartB先整串解码后切X.A[0:5]/B[5:11]/C[11:15]、Y.A[15:20]/B[20:26]/C[26:30]；A/B×1e−6、C×−.01。

s为半翼展、t为轮参数：W/W*.C减(t−6)；P=max(t/Bx,s+(t−3)/Bx)−max(6/Bx,30+3/Bx)，X.C减Bx·P，Y.C减By·P。RDH给W/W*/X/Y.C加(RDH−15)，Z不改。P30B A/B按F6、C按F2写回，Draw再解析已舍入文本；不能把未舍入数据库模型当最终绘图系数。P30C飞机类别写A/B:30/6，C/D:32.5/7，DL:40/8；手改尺寸仍可能覆盖。P30D令P1.A=Round(tanGP,4)，随后触发参数更新。

## CAT链

|AppType SelectedIndex|DB mode|cap（米）|UI|P307实际读面|CAD|
|---|---|---|---|---|---|
|0 CAT I|0|300|W*框隐藏；六模式可用|W/X/Y/Z|普通OAS7条|
|1 CAT II|1|150|W*框可见；另五模式禁用并选OAS|W/X/Y/Z，不读W*文本|7条|
|2 CAT II AUTO|2|150|同上|W/W*/X/Y/Z|W/W*交线分两条，8条|

cap是150 **m**，不能误写150ft。AUTO查不同数据库key，X/Y等也可不同；不是只改W*或cap。enum仅value__元数据，不虚构命名常量。W*可见不等于被reader消费。所有初值和setter/reader见 [控件清单](evidence/parameter-control-inventory.csv)。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P309|0x0600030A / 0x408A0|0x3584C|24244|[证据](evidence/processed/0x06000309.il.txt)|
|P30A|0x0600030B / 0x40B18|0x35A60|24361|[证据](evidence/processed/0x0600030A.il.txt)|
|P30B|0x0600030C / 0x40DA4|0x35C04|24425|[证据](evidence/processed/0x0600030B.il.txt)|
|P30C|0x0600030D / 0x41110|0x35F34|24529|[证据](evidence/processed/0x0600030C.il.txt)|
|P30D|0x0600030E / 0x4134C|0x36058|24584|[证据](evidence/processed/0x0600030D.il.txt)|
|P409|0x0600040A / 0x63AE4|0x51B54|41676|[证据](evidence/processed/0x06000409.il.txt)|
|P40A|0x0600040B / 0x640AC|0x51FC4|41814|[证据](evidence/processed/0x0600040A.il.txt)|
|P40B|0x0600040C / 0x64280|0x5207C|41867|[证据](evidence/processed/0x0600040B.il.txt)|
|P40C|0x0600040D / 0x64454|0x52218|41965|[证据](evidence/processed/0x0600040C.il.txt)|
|P411|0x06000412 / 0x645A4|0x52294||[证据](evidence/processed/0x06000411.il.txt)|
|P412|0x06000413 / 0x647B4|0x523E0|42078|[证据](evidence/processed/0x06000412.il.txt)|
