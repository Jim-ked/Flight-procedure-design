# 保护区衔接：索引已建，规则未全部恢复

检索入口：`09_cad-interactions/geometry-il-sites.csv`、`source-candidate-sites.csv`、`xdata-il-sites.csv`、`manual-il-sites.csv`，及 `05_callgraph/field-accesses.csv`。所有位置需回到独立IL确认；泛型MethodSpec、间接调用仍可能漏边。

传统定点离场绘图/评价共用 `_0088_0095`；定高使用 `_0088_0093`；全向入口使用 `_008A_0095`。这是代码可见的构造/调用关系（A/B），不代表已经恢复类内几何规则。不能把 UI “CAD绘制”解释为已经自动完成所有相交、裁剪和包络。

待逐例闭环：传统直线→转弯、指定高度、指定点、传统复飞、FlyBy等宽/异宽、FlyOver→DF、直线主副区、DME弧相邻航段、RNP APCH各段、PBN-ILS复飞。每例必须留存前后航段、限制线、几何步骤、主副区输出、评价区划、人工依赖及规范定位；目前没有任何例子被标为完整完成。
