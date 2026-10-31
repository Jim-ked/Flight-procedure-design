# 定点转弯控制点和衔接

构造：原`06000203/RVA19098`（P202），边界：原`06000205/RVA19820`（P204）。源码`_0088_0095.source.txt:4123–4334`，独立IL同目录。

令t=tan15°，h=DER.Z，g=前梯度，k=KK′-TP，c=C-TP，v=TAS，w=Wind；

`tp=(CalculationHeight-h-5)/.1; ref=tp*g+h+5; delay=(v+w)/.6`。

| 点 | X | Y | Z |
|---|---|---|---|
| S | 0 | 150 | h |
| E | tp-k | 150+(tp-k)t | ref-k*g |
| TP | tp | 150+tp*t | ref |
| L | tp+c | 150+(tp+c)t | ref |
| D | tp+c+delay | 150+(tp+c+delay)t | ref |

`Sym(a,b)=[a,b,(b.X,-b.Y,b.Z),(a.X,-a.Y,a.Z),a]`。

输出严格为：Sym(S,TP)、Sym(E,TP)、Sym(TP,L)、Sym(L,D)。第一条和第二条可能重叠；软件没有布尔合并/裁剪。每条直线顶点bulge=0，重复起点闭合；全部旋转forward→清Z→平移DER后生成Polyline组。

在此构造器、边界builder及CAD handler可达几何链中，无Arc/风螺旋、切线P、A/2、<75°分支、设施分型、转弯角或后续航段输入。没有主副区独立边界；不能把两侧镜像边称为规范意义的内外转弯保护边。Polyline相接只靠共享控制点；未代码化与下一段的交点、扩张、裁剪或包络。此结论限定A7这条链，不是声称整个DLL没有螺旋。

15°扩张和6秒距离有代码；这不证明其完整满足规范。实现依据待确认。
