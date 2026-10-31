# 保护区衔接与人工余量

可检索清单：`connection-and-cad-index.csv`、`evidence/method-field-flow.csv`、`evidence/conditions.csv`、`evidence/key-il-locations.csv`、`evidence/calls.csv`。这些索引保留原表达式，不把相似图形自动命名为offset/union。

|衔接|已经代码化的处理|尚未由代码确定|
|---|---|---|
|普通Holding|六个Spiral88；P7C2角度；sample范围和AddRange桥接；左右反射|独立Racetrack切换；自动导航台识别|
|全向Holding|fix容差平移、0..80每10°移位、−70°旋转、两次本地点包络；外线段终点法向位移|连续360°包络或严格offset的保证|
|Base主区|出航控制点、LineCarrier截距、P7C2候选拼接、P7BE尾参数、分支闭合|规范正确性与极端参数收敛保证|
|Base副区|相同分支重采样extraOffset=width、端部点|主副边界的严格等距/包含关系保证；未做自动修形|
|45|自有line/candidate与3个Spiral86顺序采样|自动相邻程序保护区裁剪关系|
|80|自有P463迭代、P7AF两spiral角、2段采样|无上限迭代收敛域|
|多模板Envelope|按选中顶点gift wrapping，输出一条折线|应选哪些模板；圆弧极值；非凸并集；退化共线处理|

本轮已绑定链没有CAD IntersectWith、GetOffsetCurves、BooleanOperation、Trim/Extend或Erase原模板的直接行为。数学线相交由LineCarrier等点/线算术完成；名义弧由Polyline bulge写入。未绑定P36A的Region行为单独标识，不能消除Envelope的缺口。

自动放置和模板内部拼接已经实现；多模板属于哪一组、原点/方向、选择后结果是否满足设计意图仍由人员提供输入或观察图面。没有发现程序自动读取图面、判断“衔接不良”、裁剪前后保护区、重建并回写父子程序关系的证据。此为A6范围内负证据，不推广到其他窗口/模块。

原点选择、模板实体、XData写入和未绑定交互均已单列。后续自动化应建立输入归属并保留这些差异；本轮没有新增统一引擎或修复旧几何。
