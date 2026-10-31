# 45°/180° Procedure Turn

入口P35D CAD、P35E calculate；P452构造、P453 nominal、P454 protection。方法token/RVA见evidence/methods.csv，每方法raw与processed IL均保留。nominal与保护保持独立；多模板Envelope为P367，不是P452内部步骤。

## 时间及名义点列

`v=TAS/3.6`，`w=Wind/3.6`，`t=60×UI minutes`，r、e、R、δ来自P793。

```text
firstStraight=5v
middleStraight=(t−5−45/R)v
minimumStraight=middleStraight−5v
maximumStraight=middleStraight+15v
```

所以输入时间在模型中包括起始5秒和45°/R；**不是只有中间直线的独立时间**。没有飞机事件时钟，可从算式解释计时区间，不能声称实现了实际过点触发。

5个nominal点：原点→(5v,0)→45°弧终点→沿−45°移动middleStraight后的点→反向180°弧终点。P453(true)用于CAD，open，bulges `[0,−tan(π/16),0,1,0]`，即−45°和+180°弧；false分支保留采样方法。右转入航按放置轴镜像，保护局部点列镜像后放置。

## 保护区与风

heading容差±5°产生−50°/−40°出航边界候选。源码还有22.5°、67.5°的弦/控制点三角关系，不能只找45和180。

风距字段：`5w+(π/4)e`、`(t−5)w`、`(t+15)w`。构造 **3个Spiral86**，均同r、heading−135°，各offset按min/max分支使用（精确赋值及字段关系见构造源码与field-flow）。

P454：LineCarrier/候选交点形成入口连接点；按以下角域采样后拼接（原helper可带端点/构造线参数）：

1. spiral3：0→π/2+δ；
2. spiral1：π/2+δ→π+5°+2δ；
3. spiral2：该界限→310°。

连接处以同一点列中的线段连接，不调用CAD IntersectWith；终端含原有构造点。无aux输出1条protection Polyline；aux时额外3条spiral采样，共nominal+4条=5条。构造时P455还生成局部临时列表后弃用，不把它们计作CAD输出。

完整真实角表达式及MethodDef见 `procedure-turn-angle-index.csv`；完整分支见 `evidence/conditions.csv`，未用规范候选补值。实际直接newobj P7A1在P452的IL_05D5/05F9/061D；**无直接P7AD**。

fixtures：风0/56、时间1/1.5min、左右、aux、重复结果；nominal弧端点反推半径与r一致。时间过小导致middleStraight为负时未加修正，未证实无风保护区一定收缩为最小规范区。
