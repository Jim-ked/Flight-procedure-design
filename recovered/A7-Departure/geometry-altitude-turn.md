# 定高转弯几何

令H=turn.Altitude、h=DER.Z、g=前梯度、t=tan15°、d=(H-h-5)/g、e=(TAS+Wind)/.6。

| 点 | 坐标 |
|---|---|
| S | (0,150,h) |
| K/KK′ | (d,150+d*t,H) |
| E | (-runwayLength+600,150,h) |
| L | (d+e,150+(d+e)*t,H) |

输出Sym(S,K)、Sym(K,L)；earlyFlag=true再加Sym(S,E)。构造两条无限线SK及过K垂线供评价用。边界builder先清Z，handler再次旋转/清Z/平移。默认8939.39与(300-5)/.033相符，但实际构造以读取的绝对H、DER.Z和g计算；不读取DrByAlti来构造。

没有风螺旋/圆弧、切点P、A/2收敛、75°角度阈值或后续航段连接输入；常宽150与tan15°扩张组成有限矩形/梯形片段。earlyFlag控制额外跑道片段和评价分支。多边形不Union、不Trim、不Offset。

原构造1FC/17F3C、builder1FE/18C94；源码3721–3847、4003–4028。这只是恢复实际行为，历史实现依据待确认。
