# 跑道坐标与TurnEnd核对

原MethodDef `060000AD / RVA83A0` 构造，`060000AE / RVA846C` 转换；处理PAC/PAD；`-/-.cs:3103–3131`。A7入口P281（原282/RVA2D904）读取DER与THR的XYZ。

`L=hypot(THR-DER)`；reverse=atan2(THR.Y-DER.Y,THR.X-DER.X)；forward=atan2(DER.Y-THR.Y,DER.X-THR.X)。局部原点DER，正X为 **THR→DER**：

`x=d*cos(bearing(DER,P)-forward), y=d*sin(bearing(DER,P)-forward), z=P.Z-DER.Z`。

三个评价事件随后显式`local.Z=obstacle.Z`；坐标转换按钮P280用原障碍物构造结果，只替换XY，效果同样保留绝对高度。绘图旋转forward→清Z→平移DER.X/Y；不保留DER高程。THR高程被读取，但不定义轴的坡度。

## TurnEnd没有进入A7跑道

config.xml中`FormDeparture`下有TurnEndX/Y。实际控件Name只在`--/--.cs:58490/58512`出现，字段`_0089_0094_009E / _0089_0095_0086`属于另一个窗口。直接读写定位：56306/56308声明；56681/56683拾取回填；56778/56779读取；其余为designer。A7字段/控件清单无此字段，P281无读取，三种A7业务构造器无TurnEnd参数。

所以 **没有A7用DER/THR/TurnEnd三点构造坐标系的实现证据**；不能声称TurnEnd控制A7转弯后方向、终点、衔接、螺旋或障碍物局部坐标。仅核对另一窗口字段归属，不扩展B5算法。A7与另窗共用/历史配置键不能证明共用几何。

## 全向高度属性差异

全向P290/P291传`runway._008A_009C_009E()`，getter返回`_008A_009D_008D`。该字段只有带四参构造器通过setter赋值；A7使用PAC的对象初始化，只赋XYZ、长度和两角，不赋这个属性；默认构造器也不赋。因此 **A7这两个入口传0**，即使DER.Z非0。等价代码构造器仍显式接受baseAltitude，入口必须传0，不“修正”为DER.Z。证据`--/--.cs:81513–81660`与`-/-.cs:3103–3113`。
