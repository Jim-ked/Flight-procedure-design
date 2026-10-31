# CAD创建顺序、实体与连接索引

P2F9→P087(WorkingDatabase,list2, **空字符串**)→P089；P12D/P12A转换Point2d，P134按每顶点bulge/startWidth/endWidth=0添加。P087先new Group，再按列表顺序new Polyline并逐个入ModelSpace、Append到同一个Group，最后AddDBObject(Group)。没有Group名字/Description/XData，也没有按左/右另分组。

|顺序|条件|Polyline顶点|备注|
|---|---|---|---|
|最先|center|S,E|中心线长度为拾点XY长度，独立Polyline，但在同Group|
|随后Right0|right且expand|E,O*_R|15°斜边独立Polyline|
|Right外边|right|S,O0_R,O1_R或O*_R|三顶点开放折线|
|Right内线|right|I0_R,I1_R或I*_R|二顶点半宽分界|
|随后Left0|left且expand|E,O*_L|15°斜边|
|Left外边|left|S,O0_L,O1_L或O*_L|三顶点开放折线|
|Left内线|left|I0_L,I1_L或I*_L|二顶点半宽分界|

条数：`center?1:0 + (left?1:0 + right?1:0)*(expand?3:2)`（按布尔项分别求和）。默认5条，双侧+15°为7条；单侧无中心2/3条，有中心3/4条。全不选时仍调用P087，列表空，代码new空Group并尝试入库；宿主是否接受不在本轮实测范围。

全部是2D Polyline，无AutoCAD Line/Arc/Circle/Text/3DPolyline/Face/Surface新建。数值点Z最终丢弃，不显式Closed=true，不赋图层、颜色、线型，最终显示属性取宿主默认而未验证。没有对零长/重合线去重。

## 保护区衔接与图元交互索引

[全部CAD API调用位置](evidence/cad-api-sites.csv)、[数值交线/极坐标/加点调用](evidence/connection-semantic-calls.csv)、[源表达式](evidence/geometry-expressions.csv)、[分支](evidence/branch-sites.csv)、[字段流](evidence/field-flow.csv)、[符号边界](boundary-vertices.csv)。这些索引同时保留通用helper中的条件路径，XData候选必须按空metadata实参判定。

15°数值求交和列表终点替换已代码化；没有IntersectWith、Offset、Arc/切线/包络、GetEntity/GetSelection、实体裁剪/延伸、Erase后重建既有图元。图元是每次重新创建，不自动删除上次结果；不能称已实现跨窗口区域自动合并。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
|P087|0x06000088 / 0x555C|0x87E0|1458|[证据](evidence/processed/0x06000087.il.txt)|
|P089|0x0600008A / 0x5878|0x8AB8|1578|[证据](evidence/processed/0x06000089.il.txt)|
|P12A|0x0600012B / 0x10B70|0x3282|191|[证据](evidence/processed/0x0600012A.il.txt)|
|P12D|0x0600012E / 0x10C28|0x10590|213|[证据](evidence/processed/0x0600012D.il.txt)|
|P134|0x06000135 / 0x11050|0x107BC|342|[证据](evidence/processed/0x06000134.il.txt)|
