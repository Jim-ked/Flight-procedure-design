# 全向离场

原构造`06000421/RVA65960`、评价`06000422/RVA65E14`、边界`06000423/RVA66DEC`；对应P420/421/422。评价534行机械转写，保留goto标签/所有比较符/分支顺序，生成脚本round2/port_omni.py。

输入b=baseAltitude（A7真实入口为0，见runway-coordinate）、T=TNA、H=Final、g=PDG/100、L=跑道长。

`d1=115/g; d2=(T-b-120)/g`。

S=(-L+600,150,b+5)，D=(0,150,b+5)，K=(d1,150+d1*tan15°,b+120)，F=(d1+d2,K.Y+d2*tan30°,T)。

构造线SD、DK、KF、过F且垂直KF的n；Q=(S.X,n.Y(S.X))。外圆圆心(S.X,0)，半径`F.X-S.X+(H-T)/g`。CAD圆经跑道旋转平移，Z=0。边界Sym(D,K)、Sym(K,F)，early默认true再Sym(S,D)。H只进入半径；未限制H>=T或g>0。120/115/5常数不可换算成规范更合理版本。

## 分类优先顺序（y=abs(Y)，所有点先做外圆测试）

1. 圆心距离>Radius：out，OCA=0；圆上包含。
2. X<=S.X且y<=150：早转弯前直线，dr=0，do=S.X-X，MOC=max(.008do,75)，PDA=T+do*g，required=(OCA-T)/do。
3. X>=F.X且y<=F.Y：3区直线，dr=F.X，do=X-F.X，MOC=max(.008X,75)，PDA=T+do*g，required=(OCA-T)/do。
4. X<S.X且y<Q.Y：C1侧方，dr=0，do=dist(P,S)，MOC=max(.008do,75)。
5. X>=F.X，或X>Q.X且y>n.Y(X)：C5侧方，dr=F.X，do=dist(P,F)，MOC=max(.008(dr+do),75)。
6. X<Q.X且y>Q.Y：C1侧方，dr=F.X，do=min(dist(P,S),dist(P,F))。若S较近，MOC仅按do；否则按dr+do。
7. S.X<X<0且y<=150：1区跑道内，dr=do=0，MOC75，PDA=T，required0；OCA>T追加“转弯高度设定偏低”。
8. X>=0且X<=K.X且y<=DK.Y(X)：1区，dr=X/do0/MOC=.008X/PDA=b+5+dr*g/required=(OCA-b-5)/dr。
9. K.X<=X<=F.X且y<=KF.Y(X)：2区，同上。1/2区Z+75>T追加高度偏低提示（判断不是按该行实际MOC）。
10. 剩余点：分别计算到无限线SD/DK/KF的垂距，do取最小；相等优先SD再DK再KF。SD最近为C2，dr0；DK为C3，dr=垂足X；KF为C4，dr=垂足X。MOC=max(.008(dr+do),75)。

除1/2区及1区跑道内以外，PDA=T+do*g；required=(OCA-T)/do，无Math.Max(0)。三分区不是同心圆。C1同一名称有两种dr路径；勿按名称合并。early开关只改变几何builder，评价器没有读取此开关的分支。

## 风险与验证

负/零g、负半径、零do、退化线均保留raw行为；没有规范限制修正。此链与定高/定点独立。数值测试验证本轮恢复代码，未做原目标运行对照。
