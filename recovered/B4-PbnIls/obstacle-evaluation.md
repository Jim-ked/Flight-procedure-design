# 障碍物评价与最低标准

## 可达数据链与断链

P555在Model空间SelectAll POINT（不筛IsObstacle、不取块），先Count>5时Take(5)，再P556共享P12F解析：原XYZ、顺序字符串ID、名称/备用名、ID→源DBPoint。初始表和P55B转换、Mark/Highlight都只见这个截取列表。

另有P557自定义parser，直接读整个XData数组[3]作为名称，参数List可超过5，但没有静态incoming；不能把“可传任意List”当作UI绕过入口。P55B重新遍历原点，转换XY、保留绝对Z，P558填13列；没有调用面评价或最低标准。

P5E0为单记录评价：按 [oas-surfaces.md](oas-surfaces.md) 五段选择候选最大高度，严格max，同值入口/W/X/Y/Z/副区按先后保留。没有先OAS后独立PBN再max OCA，也无多行候选、无所有障碍物的控制结果合并。只写region、surface、penetration和部分分支fraction。

## 结果字段

|原字段后缀 `_0088_0090_`|意义/状态|
|---|---|
|008A|区域字符串：入口平面、W/X/Y/Z面、Z面副区、out|
|008B|数值面高；P567又加THR标高|
|008C|penetration=记录Z−面高，P567不重算|
|008D|P5E0后段是max(0,(absY−1852)/1852)；P567后变成HL|
|008E|Ha，当量进近障碍物高|
|008F / 0090|OCA / OCH，中间字段；表不直接展示它们|
|0091 / 0092 / 0093|DA / DH / RVR，最终表值|

## P567最低标准后处理（orphan）

只对penetration>0执行；不另测region!=out。记h=record.Z−THR，t=tanGP，u=100/MissCG，c=1/t，k=类别文字H?700:900；HL见独立报告。

- 若x>−900且h<(x+k)t：008D=HL；**OCH=record.Z+HL，OCA=THR+record.Z+HL**。record.Z在可达转换中是绝对值，这个标高混用保留，未纠正。
- 否则若x>B.x（Y/Z到1852点）：Ha=Ceiling((h*u+x+k)/(c+u))；OCH=Ha+HL，OCA=THR+Ha+HL。
- 否则：先M=fraction*30；Ha=Ceiling(((h−M)*u+x+k)/(c+u))；再008D=HL；OCH/OCA同上一行。
- surface+=THR；DH=Ceiling(OCH/5)*5，CAT I下限60；DA=Round(DH+THR)。
- rawRVR=DH/tanGP−LIGHT；<800按50向上，<5000按100，否则按1000。THR<3000时先封顶5000；否则DH≤300时封顶8000，DH>300时5000（其余源码路径见IL）。CATI再最低：LIGHT>720→550，>420→800，其余1200；其他mode按DH≤35→350、≤42→400、其余450。

没有调用这两方法的可达循环、全局排序/最高OCA选择或回写DH再绘图过程。P585返回DH但未被引用。独立测试按明确单记录调用验证原方法，**并未给原UI补接**。

## 第6点

危险第6点在parser前丢弃，无对应ID表行、转换行、Mark或Highlight资格。SelectAll返回的顺序不保证按危险程度。数学评价器没有Take(5)，外部独立调用可以输入任意record；这不证明原UI第6点可以绕过。未发现另一可达导入评价入口。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P555|0x06000556 / 0x899C0|0x70514|60800|
|P556|0x06000557 / 0x89BDC|0x7062C|60835|
|P557|0x06000558 / 0x89EE0|0x708EC|60867|
|P558|0x06000559 / 0x8A088|0x70A74|60939|
|P55B|0x0600055C / 0x8A688|0x70EF8|61010|
|P567|0x06000568 / 0x8BBEC|0x71DB0|61497|
|P57D|0x0600057E / 0x8E114|0x73724|62563|
|P585|0x06000586 / 0xCCBA4|0x4B1C||
|P5E0|0x060005E1 / 0xB36EC|0x84CAC|71916|
|P12F|0x06000130 / 0x10D00|0x10648|239|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
