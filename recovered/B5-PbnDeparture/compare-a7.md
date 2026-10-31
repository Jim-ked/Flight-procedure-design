# A7与B5逐项比较

分类不把形似自动当共享：**Same MethodDef**才是直接复用；**Copied algorithm**表示独立方法中有同序公式/语句结构，不能证明作者复制行为；**Numerically similar**仅指常数/公式近似；**Different implementation**有明确输入或分支差异。完整条目见../round5/a7-b5-comparison.csv，调用身份交集另存a7-b5-shared-identities.csv。

|项|分类|事实|
|---|---|---|
|两点frame|Same MethodDef|P0AC/P0AD；A7没有TurnEnd三点模型|
|TP显示|Copied algorithm|各自handler计算(H−DER.Z−5)/g并Round1，g=0保留显示|
|业务TP|Copied algorithm|各自ctor直接除法，B5另加PBN点组/Spiral86|
|指定点双高度|Copied algorithm + Different implementation|均10%及实际PDG双高；B5传10%高度且直接传TPdistance；A7由高度反算TP|
|TAS/bank/wind|Same MethodDef|共同P793，五参顺序相同；高度来源按模式不同|
|earliest/latest|Different implementation|B5固定1482（FO）/600m early（TA/H）、C6；不复用A7业务ctor|
|straight/turn area|Different implementation|B5独立类、1852/3704、Spiral86候选及后续TurnEnd；A7几何类独立且不消费spiral半径构界|
|MOC|Numerically similar + Different implementation|.008/75常数重叠，区域判断、PDA、required分支各自方法，保留B5异常赋值|
|评价结果carrier|Same MethodDef|_008A_0089是共享结果数据，非共享evaluator|
|CAD/Mark/highlight|Same MethodDef|P087/P09C/P09E/P0AF/P0B0等实际调用交集|

结论：B5独立业务几何/评价，包含与A7相同的公共输入helper和独立重复计算片段；不应标“A7+PBN turn直接组合”，也不应标“完全独立不共享”。A2参数模型真正复用；A3业务自动传递没有证据。
