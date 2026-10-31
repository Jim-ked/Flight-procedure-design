# Holding / Racetrack 与全向等待

## 页面与链

页面文字“等待与直角航线”，实际绑定为 `buttonHolding→P364`、calculate→P366，以及 XE、YE、全向按钮。搜索该 Form 的全部17绑定、controls 与构造调用，**无独立 Racetrack CAD handler、构造器或 mode 开关证据**。可以证明页面共用 Holding 实现；不能据此证明规范上的 Holding/Racetrack 完全相同。

P364：读 P793→P358 两个坐标点→`new Holding(turn, minutes)` (P3AB)→nominal P3AC→保护点组 P3AD→旋转/平移/镜像→writer→可选 MText。P366 仅构造/显示，不拾点。

## 原点、航向、时间与坐标

局部原点 `(0,0)` 是被放置到用户指定“导航台位置”的模板基准；入航方向由第二次选点与第一点 `atan2` 得到。程序未识别一个导航台实体，也未从既有航迹反查。

设 `v=TAS/3.6`，`w=Wind/3.6`，`t=60×minutes`，`r=turn.Radius`，`e=turn.WindRadius`，`R=turn.Rate(°/s)`，`δ=turn.Drift`。P3B3：

```text
L = v t
ab = −5v; ac = −11v
gi1 = gi3 = (t−5)v
gi2 = gi4 = (t+21)v
Wb=5w; Wc=11w
Wi1=Wi3=(t+6)w+πe
Wi2=Wi4=Wi1+14w
```

代码给定 nominal 出航段长度 L，没有“飞机运行中从某事件开始计时”的状态机。名义5点是 `(0,0) → (0,−2r) → (L,−2r) → (L,0) → (0,0)`；因此时间长度体现在两半圆间的直线段。不能进一步声称它实现了通过电台/正切位置后的计时触发。

右转出航对名义实体沿所选方向轴 Mirror；保护点列在局部 X 轴反射，然后放置。左转出航保留普通模板基准。标注的特殊反射见 cad-output-map，不能用正常镜像公式替换。

## 六个 Spiral88 与边界衔接

P3AB 直接 new **六个 `_008F_0088`**（P7B7），无 Spiral86 newobj。全部使用同一 turn radius；表内 offset 是附加风距，不是新基础半径。

|字段后缀|中心字段|heading|offset|
|---|---|---|---|
|008A_0088|0089_009D|π/2|5w|
|008A_0089|0089_009E|π/2|11w|
|008A_008A|0089_0099|3π/2|Wi1|
|008A_008B|0089_009A|3π/2|Wi2|
|008A_008C|0089_009B|3π/2|Wi1|
|008A_008D|0089_009C|−π/2|Wi2|

完整字段前缀均 `_0088_`。中心由 ab/ac、gi、±5°、r 构造；公式逐行在 `evidence/Holding.source.txt:39047–39263`，恢复代码保留全部字段。

P7C2 求相邻 spiral 拼接角；P7B8 sample 的范围按各 heading 扣除拼接角，AddRange 形成 `_0088_008A_0092` 和 `_0093`。例如 `_0092` 顺序：原点→0089段→008A段→008B段→008D段→0089尾段；`_0093`：原点→0089段→0088段。不是 CAD Trim/IntersectWith。P3AD 将普通边界/辅助采样组织成组；aux=false 的 protection 是2条，aux=true保留更多构造线。

nominal 最终是4顶点 Closed Polyline，bulge `[1,0,1,0]`；保护与辅助均采样 Polyline，不输出独立 Arc/Line 实体。

## 全向等待 P377

不是第二种基础转弯构造器。链为普通 Holding→P3AD→P378设施容差→专用XE、YE→Holding.P3AF→writer。

P378 由等待页自己的 facility/antenna 计算两个平面位移点：`z=(altitude−antenna)tan(a)`，VOR `a=50°`，方位5°/165°；其他分支（UI NDB）`a=40°`，方位15°/155°。点Z保存altitude，CAD放置前ZeroZ。普通P364读取并丢弃的是 Base 页 facility/antenna，普通构造器未接收fix tolerance。

P3AF 实际处理：

1. 将基本 `_0092` 平移至 P0、mirror(P0)、P1、mirror(P1)，flatten后调用类内点集包络。
2. 形成位移点 `(ordinarySpiralXE−dedicatedXE, dedicatedYE+ordinarySpiralYE)`。
3. `i=0..80`，角步长10°，建立方向位移点列；再加入两个 **−70°** 旋转的 `_0093` 点列。
4. 再 flatten、再包络；aux保留中间模板组。
5. P377 输出全向组、普通保护组，再按最终 hull 调 P379 生成宽9260的外线。

P379 是逐段终点沿法向位移，然后重复首点；不求相邻平行线交点，未调用 AutoCAD Offset。不能称为连续360°精确扫掠或严格等距缓冲。

## 验证与未验证

`holding-w{0,56}-t{1,1.5}*.json` 保存输入、公开字段、左右全部点列、aux、XE/YE、VOR/NDB全向结果。镜像、闭合、无风circle、标注边界和外线通过独立恢复测试。自动生成的保护点列拼接包含直线桥接，不以任意相邻采样点距离为零作为合格条件。原软件图面未运行；“直角航线”独立业务含义仍无代码证据。
