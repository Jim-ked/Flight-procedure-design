# A3 几何链

L1 Direct代码：交叉定位事件 `--/--.cs:4502`，原0x0600020F/RVA0x19CD4，处理0x0600020E；盲区事件4726，原0x06000212/RVA0x1A628，处理0x06000211。完整对应IL见evidence/。

## 单台容差/KK

S=电台点；方向θ=atan2(第二点Y−SY,第二点X−SX)；r=两点平面距离或指定NM×1852；a=精度角×π/180；e=.0125r+460。

定义P(t,φ)=S+t(cosφ,sinφ)。始终生成三顶点Polyline：P(r+e,θ−a)→S→P(r+e,θ+a)。可选航迹Polyline：S→P(r+e,θ)。共享helper `-/-.cs:1458` 使用零bulge。

KK选中时建立两个独立Line，中心分别为P(r+e,θ)和P((r−e)cos(a),θ)，各沿θ±π/2延伸9260米，全长18520米。不写KK文字。e的计算和KK构造并不要求DME绘图开关选中。

DME选中才继续绘制半径r+e、r、r−e的三个Arc，范围θ−a至θ+a，并分组；DBText内容D+NM文本+设施名大写后缀，高500。没有在此事件对负半径另加修正。未选DME则在弧和文字前返回。

## 顶空/航迹容差

h≤0不画；R=h*tan(输入半角×π/180)。一个Circle(S,ZAxis,R)。航迹容差开启时另拾取入航方向；θ为方向点相对电台方位。

VOR small/large=5°/15°，NDB=15°/25°。两条二顶点Polyline分别连接P(R,θ+large+π)到P(R,θ−small)，以及P(R,θ−large+π)到P(R,θ+small)。入航点为Origin哨兵时退出，连Circle也不创建。

没有在本链中发现两设施IntersectWith、自动取包络或主副区裁剪；不能按功能标题虚构这些步骤。

Z必须区分：Polyline/KK来自仅XY构造的业务点，默认Z=0；Arc和Circle直接使用拾取的Point3d圆心，保留其Z。DME文字未指定距离时保留第二拾取点Z，指定距离时使用XY计算点。不能把所有输出都强制压到同一平面而声称原样恢复。
