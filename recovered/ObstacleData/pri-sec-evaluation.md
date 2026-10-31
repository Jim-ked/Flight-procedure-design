# A9 主副区评价的静态恢复

L1处理代码及L2 IL；无L3。processed32F事件（--/--.cs:29155）→processed330/331（29214/29257）。原token/RVA、源码行和IL见evidence.md及 ../native-port-map.csv。

## 输入与调用

起点S(X,Y,Z)、宽度W0、MOC0；终点E(X,Y,Z)、宽度W1、MOC1。L=平面距离(S,E)。先用S→障碍物方位减E→S反方位转换局部XY；构造评价对象时保留原障碍物绝对Z。起终点高度传入临时直线的Z，但直线系数方法只使用XY，因此不参与这两个评价函数的OCA。

令t=(L+x)/L，m=MOC1+(MOC0−MOC1)t，a=abs(y)。

| 条件 | IF模式（checkbox `_0087_0098_0095`） | 普通模式 |
|---|---|---|
| 纵向范围 | −L≤x≤0 | −L<x<0 |
| 主区线起点→终点 | W0/2 → W1 | W0/2 → W1/2 |
| 外边线起点→终点 | W0 → W1 | W0 → W1 |
| 粗筛选 | a<max(W0,W1) | 相同 |

两条直线使用旧Ax+By+C=0 helper求给定x的y，不能把其中IF终宽改成“对称”的W1/2。主区a≤primary时MOC=m；副区a≤outer时MOC=m(outer−a)/(outer−primary)，分母0取m。OCA=原Z+MOC。两个比较都通过才入结果；粗筛选严格小于，可能排除恰好位于最大外宽的点。

直线helper分母0时按分子>0返回+1000000，否则−1000000。零长度段无额外保护；测试覆盖其实际负哨兵导致空结果的情况。没有加入非负MOC或坐标容差。

## 输出与CAD关系

结果按OCA降序，表内XYZ依次为Round(−localX,2)、Round(−localY,2)、Round(原Z,2)，MOC/OCA两位。ID不因排序重新编号。SelectedRows的ID回查保留的DBPoint，Mark插入obst、Altitude=原Z；不是标OCA。A9这条链没有给Mark写Name。

已转写代码：PriSec.Recovered.cs（纯计算）、PriSecForm.Events.Recovered.cs（原生表格/实体）。19项测试是恢复源码内部检查，不是原程序对照实验；原生文件尚未编译/运行。静态分支和数值检查不能替代真实保护区工程验证，历史实现依据待确认。
