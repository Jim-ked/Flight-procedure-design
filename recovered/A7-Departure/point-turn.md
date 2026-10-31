# 定点转弯：拾取、双高度和业务路径

P287/28A/28B分别拾取TP、KK′最早点和C最晚点；原288/RVA2E580、28B/2E954、28C/2EA6C。均经公共GetPoint，不是GetEntity，不读WsCalcuLine或A3生成实体的XData。

公共距离P28E（原28F/RVA2F364）=`sqrt((x2-x1)^2+(y2-y1)^2)`。**没有轴投影、符号、共线校验，忽略Z。** UI要求跑道延长线上由人选择，软件没有识别TP/KK/C实体的实现。存储TP Point3d字段供之后KK/C距离使用；顺序错误/取消返回Origin无统一拦截。

| 显示 | 真实路径 |
|---|---|
| TP-DER | 两点XY距离，Round(d,2)回填 |
| KK′-TP | TP存储字段到新点XY距离，Round(d,2) |
| C-TP | 同上，Round(d,2) |
| CalculationHeight | Round(TPdistance*0.1+DER.Z+5) |
| ReferenceHeight | Round(TPdistance*输入PDG/100+DER.Z+5) |

TP拾取P287用未舍入距离算双高度；PDG TextChanged P289用文本距离重新计算，整数Math.Round默认中点到偶数，无floor/truncate。10%和5m均代码常数。P28F“计算”按钮体为空（原290/RVA2F3B8）。Reference没有被CAD/评价构造读取；Calculation进入公共turn模型，决定TAS及模型内部Rate/Radius等。A7随后只用Altitude、TAS、Wind，未用Radius构造螺旋。

定点业务构造P202从CalculationHeight再次`tp=(alt-DER.Z-5)/.1`反算；所以不直接使用TP距离文本，受整数高度舍入影响。参考高程再按实际PDG精算，不读取已Round的Reference文本。

完整几何见geometry-point-turn；评价见obstacle-evaluation。前序A2/A3到A7存在**人工拾取桥接工作流**，没有直接自动传递实体参数的调用边。已有点可作为后续自动化候选，但原软件不维护可靠业务对象关联。
