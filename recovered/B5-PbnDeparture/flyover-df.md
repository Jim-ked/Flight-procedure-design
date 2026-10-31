# 定点转弯 FlyOver-DF

## 输入/高度

P507提示在跑道延长线上选择指定转弯点，实际只计算DER至pick的XY欧式距离，无投影/共线检查；Round(d,2)显示站距。

`textBoxAltiTp / 字段0093 = Round(d×.1+DER.Z+5)`；`textBoxRefAltiTp / 字段0094 = Round(d×gBefore+DER.Z+5)`。控件名称容易误导：**P50A实际读取0093（10%高度）进入P793**，不是另一高度字段。P509随PDG TextChanged重算，距离框没有TextChanged绑定。

P50B CAD调用同一P5D3，真实签名 `(turn,DER,THR,TurnEnd,TPdistance,left,gBefore,gAfter)`。IL_002E–00AE确认；不采用反编译器错排表达式。没有可用的一键/直线/转弯评价事件调度至P5D8。

## 几何

1. P5D3将ATT样字段固定为1482m。E=TP−1482，N=TP+1482，C=N+(TAS+wind)/.6；对应W(E)、W(N)、W(C)=min(3704,150+s tan15°)。
2. P5D7以S=(0,150)、A=(6351.95,1852)、B=(13263.71,3704)、E的主/外点、N的主/外点、C的1852/外点构造初始列表。Z沿(gBefore+.008)×站距+5；A保留6531.95错站距。C<6351.95抛低转弯高度异常。
3. E/N/C与6351.95、13263.71的分支控制5/7/9列表：中央主列表、两侧补列、早晚站距间中央与两侧列表。准确条件和逐点顺序完整保留P5D7与条件索引，不能用一个统一矩形取代。
4. 初始flatten→gift-wrapping Hull存009A。
5. P5D6将E主/外点与局部TurnEnd连接，按左右和75°镜像；把外点转到该后续坐标系，FlyOverPostArea沿15°线求出封顶1852/3704的交点，旋转/平移追加。
6. P5D4为本类自己的外界：以C轴点r−1852/r+1852、A轴点r+1852及Eprimary轴点r+150等候选中心构造Spiral86；δ、90°、15°、π与候选参数决定拼接。P5D5保留和高度末端类似的LineCarrier交点/1852/3704三分支，并在外列追加TurnEnd。
7. 最终009B评价Hull来自两条外界列表、后续区，以及C>13263.71时加入的B点。**并非所有绘图点组flatten**；直线评价仍用初始009A，转弯评价用009B。

## 与B2

不是同一 `_008C_0089`，不直接调用B2 ctor或边界方法。B2的三个segment descriptor语义为起点/转弯航路点/终点，ATT由中点输入；B5没有中点descriptor，TP由DER站距表达，另有固定1482。两者共享P793及Spiral86、line/point/list等低层MethodDef；业务分支相似不能标为同一实现。

DF形成的是朝实际TurnEnd的候选连接和有限后续扩张保护点组，没有恢复出原软件中独立的可执行DF飞行轨迹对象或任意航段序列引擎。Mark/高亮通过Form源DBPoint字典，几何类不直接操作CAD选集。
