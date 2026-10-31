# XE / YE：显示标量与专用几何点

以下为代码公式；不从规范补值。单位：m、m/s、s，角为rad，R仍为 **°/s**。设 v、w、t、r、e、δ 同 holding.md。

## 普通 Holding 显示的 XE/YE

P3B3 (`Holding.source.txt:39135–39136`)：

```text
XE_display = 2r + (t+15)v + (t+26+195/R)w
YE_display = 11v cos20° + r(1+sin20°)
             + (t+15)v tan5° + (t+26+125/R)w
```

分别存 `_0088_0088_009E`、`_0088_0089_0086`。ToString取 Ceiling 显示；几何未提前取整。字段使用索引显示这些标量被显示读取，**不是普通保护顶点的直接构造输入**。

## 专用 XE 按钮 P375 → P3BD/P3BF

`D=11v`，`S=(t+15)v`。两 Spiral86 的中心：`C1=(r,−D)`，`C2=(r+S,−D)`；heading分别 π、3π/2；offset分别 `11w` 和 `(t+26+(π/2)/R)w`。

输出点 `_0088_008B_008F = Spiral2.Point(π/2+δ)`；全向等待取它的 **X** 坐标作为 dedicatedXE。XE不是从 XE_display 字段复制。

## 专用 YE 按钮 P376 → P3C9/P3CB

令 α=20°，β=5°，D=11v，S=(t+15)v。源码控制点（中性符号，非规范点名）可写为：

```text
B=(r cosα−D sinα, 0)
C=B+(0,−D cosα)
C1=C+(0,−r sinα)
N=C1+(0,−r)
M=N+(S,0)
C2=M+(0,r−S tanβ)
```

两 Spiral86：`(C1, heading160°, offset11w)`；`(C2, heading270°, offset(t+26+(α+π/2)/R)w)`。

输出点 `_0088_008C_0096 = Spiral2.Point(δ)`；全向等待取它的 **Y** 坐标作为 dedicatedYE。完整含构造线/圆弧采样见 `HoldingYE.Recovered.cs` 与源40078–40324，未按规范重画。

## Point 的明确计算

复用 Spiral86 P7A5。给定 θ、中心(cx,cy)、heading h、offset o：

```text
u=θ e+o
ρ=sqrt(r²+u²+2 r u cosδ)
q=θ−asin(u sinδ/ρ)
Point=(cx+ρ cos(s q+h), cy+ρ sin(s q+h))
```

这里专用构造器的默认方向 s=+1；完整方向处理保留于 primitive。以上结合C2和θ即专用XE/YE实际公式，不额外取绝对值或四舍五入。

## 方向、容差和用途

XE：左转出航保留点列，右转镜像；YE：**左转出航镜像，右转保留**。输出坐标在局部定义，再旋转/平移至人工选点。YE Y坐标可能因基准而负；不得强制改成正的“宽度”。

专用XE/YE不接收facility或fix tolerance；P377先以P378获得容差，另构造XE/YE，再把两者送入普通Holding的全向方法。它们输出三组采样/构造线，writer description为turn.ToString，无独立XE/YE metadata。它们的点坐标确实进入全向几何；普通显示标量则没有同样调用关系。

`(π/2)/R` 和 `(20°rad+π/2)/R` 是**代码中的弧度除度每秒**，与195/R、125/R显示公式也不同。如实保留并列为“实现依据待确认”，不能改为90/R或110/R。fixtures保存两套值及专用完整模型。
