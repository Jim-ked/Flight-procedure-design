# A7 障碍物三套公式

共用入口：Round1 ScreenData/DBPoint解析→跑道局部XY→恢复绝对Z→模式评价→按required降序→表格Round→Mark按ID定位原DBPoint。定高/定点不做保护多边形包含过滤；全向圆外返回out/OCA0，但入口仍把结果加表，并显示全部点数为在范围内。

## 定点（P203，原204/RVA19440）

y=abs(Y)，E为最早KK′点，tp为反算TP距离。

| 条件 | dr | do | MOC |
|---|---|---|---|
| 0<=X<=E.X且y<=SE.Y(X)，不二检 | X | 0 | .008dr，无75下限 |
| 同一区域，勾选二检 | tp-k | E.X-X | max(75,.008(dr+do)) |
| 其它，y<=E.Y | tp-k | abs(X-E.X) | max(75,.008(dr+do)) |
| 其它，y>E.Y | tp-k | hypot(X-E.X,y-E.Y) | 同上 |

OCA=Z+MOC；PDA=h+5+dr*gBefore+do*gAfter；required=(OCA-h-5)/(dr+do)，无非负clamp。其它区域按X>=E.X标签KK′后/前，但没有区外排除。

### 直线段二次检查

没有独立Click/CheckedChanged计算事件；checkBoxSecChk.Checked在P28D传入P203。只改变本来满足0<=X<=E.X且在线内的障碍物。原直线段为DER→E；二检将dr固定E站距，do回量E.X-X并用75m下限。**覆盖该障碍物同一行，不追加行**；不是另画航段或额外导入。可见公式会将某些点的dr+do算得比E站距大，忠实保留。

## 定高（P1FC，原1FD/RVA182F0）

分支顺序与AltitudeDeparture.Recovered.cs一致：

| 条件 | dr/do | 结果 |
|---|---|---|
| X>=K.X | dr=d；y<=K.Y则do=X-K.X，否则到K距离 | 转弯公共尾式 |
| X>=0且y<=SK.Y(X) | dr=X,do0 | MOC=.008dr；PDA=h+5+dr*gBefore；required=max(0,(OCA-h-5)/dr) |
| X>0侧方且y>=过K垂线.Y(X) | dr=d，do到K距离 | 公共尾式 |
| X>0其它侧方 | do=到SK垂距；dr=过P垂线与SK交点X | 公共尾式 |
| X<=0且early=false | dr0，do到S水平/圆角距离 | 公共尾式 |
| early且X>=E.X且y<=150 | dr/do默认0 | MOC75，PDA=H，required默认0 |
| early且X>=E.X且y>150 | dr0，do=y-150 | 公共尾式 |
| early且X<E.X | dr0，y<=150取E.X-X，否则到E距离 | 公共尾式 |

转弯公共尾式：MOC=max(75,.008(dr+do))，OCA=Z+MOC，PDA=H+do*gAfter，required=max(0,(OCA-H)/do)。dr仅影响MOC，不进入该PDA或required分母。零do会产生Infinity/NaN，无额外保护。

## 全向

见omnidirectional.md十步优先分类和完整转写。独立评价器；不调用A8 KK或A9 PriSec。相似.008/75常数是重复公式，不能称共享方法。
