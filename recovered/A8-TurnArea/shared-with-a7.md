# A8与A7直接共享

共有：GetPoint、数字读取、两点frame构造PAC及转换PAD、DBPoint解析P12F、ScreenData公共选择、障碍物块/属性写入、视图高亮helper；这些是直接调用关系。

A8调用P2 KK evaluator；A7定高P1FC、定点P203、全向P421分别调用各自评价器，**无直接调用P2**。A8不调用A7几何builder，A7不调用A8窗的评价handler。不因75/.008等相似常数标共享MOC函数；也没有A8构造turn参数或风螺旋的调用边。

全量精确token/RVA和调用点在../shared-turn-methods.md及../GeometryPrimitives/shared-geometry-map.md（由现有静态索引生成）。
