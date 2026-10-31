# Base Turn：time / distance、primary / secondary

## 入口及证据定位

CAD P35F（original P360，RVA0x50D08）、calculate P362；业务 ctor P1ED（original P1EE，RVA0x14E14）；参数P1EE，名义P1EF，保护P1F0（original P1F1，RVA0x1593C）。`evidence/BaseTurn.source.txt:2570–3650` 及每个 raw/processed IL；全方法索引以 methods.csv 为准。

**反编译参数顺序陷阱**：P35F 的 C# 把 width 放到最前，不能据此发明 overload。IL在读width前把turn留在栈上，P1ED真实签名/调用为 `(turn, facility, antennaHeight, byTime, value, secondaryWidth=4600)`；`signatures.csv`及P35F的newobj周围指令可以复核。

## 输入与两模式

设 v=TAS/3.6、w=Wind/3.6，单位m/s；altitude和antenna为m。

|设施（ToUpper后）|zV|扩张角 A|附加容差角 B|
|---|---|---|---|
|VOR、VOR/DME|(alt−antenna)tan50°|5.2°|15°|
|NDB、NDB/DME|(alt−antenna)tan40°|**6.5°**|25°|

未知设施只写 `NaveType is Error.`，没有统一抛错分支；字段仍可取默认值。不增加限制。设施常数进入 `_0091_0094/95/98`，再构造上下出航极坐标控制点、起始容差点和spiral中心，非仅打印。

```text
按时间：s = UI minutes ×60
L = v s
ab1=(s−5)(v−w)−zV
ab2=(s+21)(v+w)+zV
tφ=s/60

按距离：L = UI nm ×1852
ab1=L−(460+0.0125L)+5(v−w)
ab2=L+(460+0.0125L)+11(v+w)
tφ=L/(60v)
```

取消“输入距离”时，CAD先P358选两个放置点，用其**3D** DistanceTo/1852取得nm；这两个点同时定义导航台/入航方向，不另选DME台。界面显示f2，但局部计算值未先取2位。calculate不重新拾点，可能读旧字段。未将该行为改成新的业务对象。

## φ 的真实条件和单位

P1EE源2794–2809、raw/processed IL中常数315、0.116、36：

```text
TAS >315 km/h: φdeg=−0.116 TAS / tφ
else:          φdeg=−36 / tφ
φ=φdeg π/180
```

等号315走36分支。几何带**负号**，不四舍五入；ToString显示正的−φ并舍入到0.01°。fixture `phi-tas315*.json` 是直接设TAS的分支隔离测试，非完整P793一致输入。

## 控制点和 nominal

`base-turn-control-points.csv`逐项保留中性P01…、原字段、赋值式、所有使用源行、MethodDef。`polar(d,a)=(d cos a,d sin a)`。代表式：

```text
O=(0,0)
out=polar(L,φ)
inEnd=out+polar(r,π/2)+polar(r,π/2+φ)
lower=polar(ab2,φ−A)
upper1=polar(ab1,φ+A)
upper2=polar(ab2,φ+A)
centers=对应边界控制点+polar(r,φ+π/2)
startTol=polar(zV,φ−30°−B)
```

原字段无b2/b3等名称；表不强加规范点名。P1EF(true)输出O/out/inEnd三顶点，open，bulges `[0,tan((π−φ)/4),0]`，右转入航镜像。P1EF(false)有独立圆弧采样分支，恢复保留，绑定CAD用true。

## Primary：五个 Spiral88 与拼接分支

P1F0的5个活跃字段 `_0092_0089/8A/8B/8C/8D` 均为 **`_008F_0088`**，同一r；源码6个newobj是最后字段在两个互斥分支中构造，并非6个同时使用。

|字段|中心|heading|offset|
|---|---|---|---|
|0089|`_0092_0098`|φ−120°|11w|
|008A|`_0092_0099`|φ−90°|0|
|008B|`_0092_009A`|φ−90°|0|
|008C|`_0092_009B`|φ−90°|0|
|008D|沿出口切线x截距减r得到的 `_0092_009C`|0|0|

流程（字段完整式和goto保留在恢复源码）：

1. primary `_0092_008E` 起始加O；0089→008A通过P7C2求拼接角并采样。
2. 比较 `δ < −φ`。成立时先008A到90°+δ，再008C到90°−φ；否则008A直接到90°−φ。
3. 对相应终点建LineCarrier，方向90°−δ，求Y=0的X截距，减r建立008D。
4. 比较 `num4=C.angleTo(B)` 与 `num2=D.angleTo(B)`。`num4>=num2`先D→C→B，否则D→B；连接角使用P7C2。
5. time模式 `_0092_0088=true`，B尾段到306°；distance模式尾段到B.P7BE(O)求出的点迭代参数。最后追加O闭合点列。

这是解析控制线、拼接角和采样点列组合，未用Autodesk IntersectWith/Trim/Union。P7BE原始P7BF/RVA0xC6EF4，P7C2原始P7C3/RVA0xC7480；直接位置列表在 `../round4/shared-template-geometry-sites.csv`。

## Secondary

独立 `_0092_008F`，按primary相同拼接分支重新调用 Spiral88.Sample 的extraOffset=`_0091_0093`（width），再构造端部点，不对实体调用 Offset。

端部特殊赋值必须保留：源码先把obj7改成一个宽度极坐标向量，下一行算obj8角度时使用的是**已修改的obj7**；不是简单复制primary首尾法向。之后只在某条件下另算一个offset切线截距，其结果被丢弃，不能把丢弃值说成修正后的secondary端点。

UI CAD width=4630；calculate省略参数取default4600。width=0/4630测试证实primary顶点相同；secondary改变。primary MOC=300仅出现在未绑定Form.P363障碍物评价，不参与本轮已绑定几何构造。辅助组 `_0092_0090` 是额外采样/容差圆弧，按aux加入Group。

## 公共迭代关系和风险

- **没有直接P7AD调用**，不能用同样功能描述替换token。
- Base确实直接P7BE（Spiral88 point iteration），直接P7C2（two-spiral angle）。
- 本业务类未直接调用P7BC/P7BD（Spiral88的其他距离迭代成员），不能说两个ParameterForLineDistance都已使用。
- 候选比较、无解/NaN、零时间、风大于TAS等没有新增防护。恢复源码保留原分支，不作为规范合格设计器。

VOR/NDB × time/distance × wind0/56，左右、aux、φ阈值、width隔离和重复性fixtures通过。原始输入、全部primary/secondary点和bulges均已保存。
