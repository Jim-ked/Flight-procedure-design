# 15°线的起点、朝向与边界作用

**代码语义已闭合：终点E处的15°斜边与边界截接**，不是独立风螺旋/转弯模型，也不是只增加显示线。P2F9固定15·π/180，创建直线对象，求两次交点，替换内/外终点，再输出。

|问题|直接恢复事实|
|---|---|
|起点|第二拾取点E，既不是S也不是自动算出的TP/切点|
|相对基准|theta=E→S反向角；代码Right过E角theta+π+15°，Left为theta+π−15°；这是无限直线的参数方向|
|实际线段方向|在正宽、正扩张角、足够长的常规样本中，E→交点沿E→S方向分别向绘图Right/Left外扩15°；它朝窄端方向，不是S→E后端向前延伸|
|左右关系|相对S→E镜像；同一个15°常数，仅符号相反|
|终点|与原外/内扩张无限直线的交点O*/I*；画出的斜边为[E,O*]，I*位于同一截接直线上|
|实际改变|O1/I1被O*/I*替换；不仅是保留原边界再叠加辅助线|
|未实现|无转弯半径/飞机速度/风/坡度/切线/TP/KK读取，无对另一保护区实体的选择/自动裁剪|

局部解析核验（正宽/非退化，t=tan15°）：

```text
outer: y=w+k*x          cut: y=t*(L-x)
x_outer=(t*L-w)/(k+t)
x_inner=(t*L-w/2)/(k/2+t)
```

左右取±y；世界坐标由S+xu±yn解释。原实现用P7E7/P7E8/P7ED数值直线求交，不是AutoCAD IntersectWith；无x∈[0,L]夹限，短段可把交点放到S之前；平行/零分母沿公共helper给±1e6哨兵，不改成段相交算法。

帮助称“单侧配合15°线，可用于转弯后飞向导航台”，可解释其作为局部衔接构造的用途。2020规范一般转弯/附加航迹引导条文亦有15°，但要求前段切点/内外关系等条件；A4不判定这些条件。**具体规范适用场景与用户选点的关系由设计人员承担，代码只落实了给定E后的相交规则**。不将它命名为完整post-turn自动连接。完整端点已保存[fixture](../round9/fixtures/15-degree-endpoints.csv)。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
|P7E7|0x060007E8 / 0xC86A4|0x92164|83911|[证据](evidence/processed/0x060007E7.il.txt)|
|P7E8|0x060007E9 / 0xC87B0|0x92234|83976|[证据](evidence/processed/0x060007E8.il.txt)|
|P7ED|0x060007EE / 0xC8908|0x9232C|84010|[证据](evidence/processed/0x060007ED.il.txt)|
