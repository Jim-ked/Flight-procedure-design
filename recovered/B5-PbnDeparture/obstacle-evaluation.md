# 两套障碍物评价与不可达UI

P5CD（高度）与P5D8（指定点）是不同MethodDef。完整方法体、IL、字段写入与条件均保存；evidence/negative-evidence.json记录在全程序集已解码静态调用和非header IL引用中无调用方。本轮直接调用恢复代码做公式测试，**不代表原Form能够执行评价**。

结果carrier `_008A_0089` 的dr getter=0088_008E_009E，d0 getter=0088_008E_009B；label=0095、MOC=0088_008F_0088、OCA=008B、PDA=008E、required=0091。不要把dr/d0交换。

## 高度P5CD决策表

令y=abs(Y)，K=(d,W(d))，B=(13263.71,3704)，S=(0,150)，E=(−runwayLength+600,150)，H=turn.altitude。L为S→A线，N为过K（K.X≥B.X时过B）且垂直L的线。

|顺序/区域|dr,d0|MOC/OCA|PDA / required|
|---|---|---|---|
|final Hull外|不计算，label=out|保留carrier已有字段|直接返回|
|X≥K.X|dr=K.X；y≤K.Y时d0=X−K.X，否则到K距离|max(75,.008(dr+d0))；OCA=Z+MOC|H+d0×gAfter；max(0,(OCA−H)/d0)|
|K.X>B.X，X≥B.X且y>3704|dr=X，d0=y−3704|同上|DER.Z+5+dr×gBefore；max(0,(OCA−DER.Z−5)/(dr+d0))|
|同条件y≤3704|dr=X,d0=0|**max(75,.008dr)**|DER.Z+5+dr×gBefore；max(0,(OCA−DER.Z−5)/dr)|
|0<X<K.X，y≥N(X)|dr取K.X或B.X；d0到相应K/B距离|通用转弯max75公式|H+d0×gAfter；(OCA−H)/d0下限0|
|0<X<K.X，y<L(X)|dr=X,d0=0|.008dr；OCA=Z+MOC|**PDA=dr×gBefore；required=DER.Z+5+dr×gBefore**|
|0<X<K.X，L(X)≤y<N(X)|d0为到L距离；dr为过障碍物平行N线与L交点的X|通用转弯max75公式|H+d0×gAfter；(OCA−H)/d0下限0|
|X≤0，early=false|dr=0；y≤150时d0=−X，否则到S距离|max(75,.008d0)|H+d0×gAfter；(OCA−H)/d0下限0|
|X≤0，early=true，X<E.X|dr=0；到E的轴向/欧式距离|同上|同上|
|early=true，E.X≤X≤0，y>150|dr=0，d0=y−150|同上|同上|
|early=true，E.X≤X≤0，y≤150|dr=0；d0未重新赋值|75；OCA=Z+75|PDA=H；required未重新赋值|

异常直线字段赋值由P5CD IL_0BC0–0BED确认，未改成规范公式。原方法就地修改传入carrier，out/早转净空道部分字段不赋值；应保留传入值，不能统一初始化或覆盖。零距离除法的NaN/Infinity与Math.Max传播不补clamp。

## 指定点P5D8(P0, straight=true)

- straight=true：初始Hull外label=out；内则X≥E.X时dr=E.X,d0=X−E.X，否则dr=X,d0=0。MOC=.008(dr+d0)，无75m下限；OCA=Z+MOC；PDA=DER.Z+5+dr×gBefore+d0×gAfter；required=max(0,(OCA−DER.Z−5)/(dr+d0))。
- straight=false：最终Hull外out；内dr=E.X，y≤Eouter.Y时d0=abs(X−E.X)，否则为到Eouter距离；MOC=max(75,.008(dr+d0))；OCA=Z+MOC；PDA=turn.referenceAltitude+d0×gAfter；required=max(0,(OCA−DER.Z−5)/(dr+d0))。
- referenceAltitude来自10%高度框，不是另一个按实际PDG高度框。转弯PDA与required使用不同高度基准，保留。
- 无副区线性衰减、无A9调用；primary/secondary图形片段不能证明评价语义同A9。

## 三个评价按钮及一键缺口

buttonEvl P501（一键）、button8 P50C（直线）、button7 P50D（转弯）Visible=false；处理后body都只MessageBox“请指定转弯点。”。button9 P50F隐藏且空。未找到其他可达完整evaluator事件，P4FE只是未绑定坐标转换并调用错误结果表。三个嵌套selector P54C/P54D/P54E仅返回required getter，未找到ldftn调用。

因此没有可证明的一键ScreenData→straight→turn→merge/sort链；重复障碍物优先/覆盖/最危险值规则均**未实现证据**，不补造。提示和“基础版仅前5”支持功能限制的观察，但没有证据证明作者禁用动机或某付费版行为。“原本应该调用什么”只能列现存候选P5CD/P5D8，不能当事实。

P4F8结果表又有11列（两次“高度(m)”）/每行12值的错误：实际System.Data先抛DuplicateNameException。测试保留该异常；ScreenData装载表P4F7没有重复列名，不要把两表混同。
