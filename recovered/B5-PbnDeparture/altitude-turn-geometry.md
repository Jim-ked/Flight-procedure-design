# 高度转弯完整几何与B2关系

证据主体 `_008C_0091`，P5C8初始化→P5CC初始区→P5CB内侧/后续扩张→P5C9外界→P5CA末端。所有方法原/处理token、RVA、签名见recovery-method-map。全部分支原跳转位置见branch-sites；可读表达式见condition-expressions；逐点列表在Recovered.cs及fixtures。本文不把Hull误称为CAD Union。

## 控制点（局部坐标，正侧再按需镜像）

令d=TP，c=latest，g=gBefore，W(s)=min(3704,150+s tan15°)。

|别名/字段尾号|点|
|---|---|
|S/0087|(0,150)|
|A/0088|(6351.95,1852,(g+.008)×**6531.95**+5)|
|B/0089|(13263.71,3704,(g+.008)×13263.71+5)|
|K/008A|(d,W(d),(g+.008)d+5)|
|Kprimary/008B|(d,min(W(d),1852),(g+.008)d+5)|
|Couter/008C|(c,W(c),(g+.008)c+5)|
|Cinner/008D|(c,1852,(g+.008)c+5)|
|Early/008E|(−length(THR,DER)+600,150)|

A点X和Z站距不一致是处理IL已有表达式，按原值保留。无DER.Z加到上述局部Z。

## P5CC初始分支

- c<6351.95：直接抛异常。
- d<6351.95且c≥6351.95：d宽度点、S及其镜像构初始区；A/Cinner的对称主列与两侧Couter补区，共4列表。
- d≥6351.95且c≤13263.71：S-A-Kprimary主列、A-Kouter-Kprimary两侧补列、Kprimary-Cinner中央列和两侧Couter补列，共6列表。
- d<13263.71<c：初始S-A-Kprimary，A至K两侧补列；Kprimary至Cinner中央列；两侧补列加入B。共6列表。
- d≥13263.71：对应两侧补列均含A/B/Kouter/Kprimary，共6列表。

分支严格<、<=、>=的端点语义不统一，不根据图形常识合并。列表按源码顺序保留重复首点；部分后续列表不重复首点。

## P5CB后续内侧

选择S或Early作为起点，TurnEnd转到局部坐标。比较正/镜像起点→TurnEnd的绝对bearing与75°，按左右转选择一侧。长度L=起点到TurnEnd；StartArea(L,left)在自身坐标从0扩张：L<6911.76为三点三角列表；中段封主宽1852并加侧区；L≥13823.52外宽3704。旋转到连接bearing再平移至起点，追加点组。

**反编译修复证据**：P5CB IL_01DA–022F给出的实际Rotate签名/栈顺序是 `(new StartArea(...).lists, origin, angle)`。C#只按IL纠正重排，未改业务分支。

## P5C9螺旋外界

令s=左+1/右−1，r=turn radius，δ=drift，β=15°，α=90°（静态常数见该类cctor）。以TemplatePoint极坐标向量加法定义中心，不以圆弧替代Spiral86。

1. latest轴点(c,0)，加长度r−1852、方向sα向量，构第一个Spiral86；heading=−sα、phase=0、left原参。外/内宽差Δ=W(c)−1852用于偏置采样。
2. 用Spiral.PointToParameter(TurnEnd)与δ/α比较。若候选参数−δ>α，另以r+1852中心构第二spiral；在α+δ、α+β及π+β阈值分段，依次拼接样点；否则第一spiral直接采样至候选−β。
3. 更大角度分支从A轴点+(r+1852)向量建第三spiral，从S或Early轴点+(r+150)向量建第四spiral。P7AF类相切参数 helper、两中心bearing及候选参数比较决定接到哪一条。
4. 对primary与带Δ偏置列表分别采样；P5CA收尾后，将两列表依次追加总图形。不执行CAD IntersectWith、Offset、Trim。

精确候选条件保留在完整P5C9代码；没有把所有控制点归为无条件四个spiral，某分支只需前一/两条。共享的是Spiral86方法身份，B5外界选择是独立P5C9。

## P5CA末端

取spiral在候选参数−β处的点与heading；若其径向距离大于到TurnEnd距离，提前返回。否则作主/偏置heading线，另作经过TurnEnd的±1852、±3704控制点与相应平行线，LineCarrier求交。

- 两交点到TurnEnd距离分别≤1852、≤3704：分别追加交点。
- 仅外侧≤3704：主列追加primary交点及1852控制点；外列追加到TurnEnd的交点。
- 其余：两列分别追加交点及1852/3704控制点。
- 外列表最终追加TurnEnd，primary列表不无条件追加TurnEnd。

## ATT=0结论边界

P503/P504直接new P5C8；P5C9直接new P7A1 Spiral86。无B2 `_008C_0089` ctor调用，无ATT=0实参链。B5高度模式无ATT参数，不能把“参数不存在”当“已传0”。B2与B5都有spiral候选/15°连接，但业务MethodDef不同。帮助FormFlyOverDF.html:62的“ATT为0外界相同”仍是待验证数学说法；本轮未移植冻结B2完整边界，未给数值等价判定。未反向改写Round3。
