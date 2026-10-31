# A3 参数→容差→KK/折线/弧（L1/L2）

本文件与 cad-output-map.md、tolerance-table.md、evidence/ 配套。仅恢复实际单台容差与盲区事件，不把功能标题解释成自动两台交点或保护区包络。

## 参数来源和自动改写

| 参数 | 来源/行为 |
|---|---|
| 设施VOR/ILS/NDB、航迹引导 | UI RadioButton/CheckBox |
| 精度角a | 设施/引导事件硬编码回填5.2/2.4/6.9或4.5/1.4/6.2度；绘图时再从TextBox读取 |
| 台站S、方向Q | 用户两次GetPoint；仅使用XY求方位及距离 |
| r | 平面两点距离；DME且指定距离时UI NM×1852；非指定时回填Round(r/1852,1) |
| e | 硬编码 .0125r+460米；DME输出关闭仍参与KK与楔形 |
| Track/KK/DME/BlindTrack | UI开关；DME未选时在弧与文字前返回 |
| 盲区h、半角 | UI；切设施回填VOR50/NDB40；绘图读取当前文本 |
| 盲区航迹小/大角 | VOR5/15、NDB15/25度，硬编码 |
| Suffix | UI字符串；DME绘图改大写；距离文本无小数点时补.0 |

Vor/Ils/Ndb/Guide事件原0600020A/199D8、20B/19A30、20C/19A88、20D/19AE0。盲区事件等对应见 methods.json与events.csv。实际旧注册为DME后缀字段`_0096_0097`（早期Name=textBox2）Leave→NDB半角回填；**不是HalfAngle.Leave**。NDB选中时离开后缀框将重置40并切图。不得“修正”事件。

## 单台几何

绘图原0600020F/19CD4（处理20E），阅读源4502。定义P(t,φ)=(Sx+t cosφ,Sy+t sinφ,0)，θ=atan2(Qy−Sy,Qx−Sx)。

1. 计算r、a、e，准备三顶点楔形Polyline：P(r+e,θ−a)→(Sx,Sy,0)→P(r+e,θ+a)。
2. Track选中时准备二顶点Polyline：(Sx,Sy,0)→P(r+e,θ)。此时尚未写数据库。
3. KK选中时立即追加两条Line。late中心P(r+e,θ)，early中心P((r−e)cos a,θ)，每端横向延伸9260米。两个Line独立，不加入后面的折线组。
4. AppendPolylineGroup原06000088（处理87，-/-.cs:1458）逐条追加零bulge/零宽Polyline，再AddDBObject(Group)。没有写命名组字典；不补造组名。
5. DME选中才追加三个Arc，半径r+e、r、r−e，角θ−a到θ+a；三个实体放另一个直接AddDBObject的Group；再加距离DBText。未为负半径增加修正。

## 盲区

原06000212/1A628（处理211），阅读源4726。拾取S后读h和半角，h≤0恢复Visible后不画。R=h·tan(半角)。BlindTrack选中再拾取入航点，构造两条二顶点Polyline：

- P(R,θ+large+π)→P(R,θ−small)
- P(R,θ−large+π)→P(R,θ+small)

先将两Polyline分组，后追加Circle(S,ZAxis,R)。额外点取消则整个事件返回，Circle也不创建。数字异常catch提示后直接返回，保留Form.Visible=false旧行为。

## Z和人工依赖

Polyline/KK都是XY构造，Z=0；Arc/Circle用原拾取S，保留Sz。DME文本用Q时保留Qz；指定距离用P(r,θ)时Z=0。S或Q==Origin即退出。原代码不验证拾取对象是否真是导航设施；只有点，没有统一设施对象自动关联。若已有台站/航迹数据可推导输入属于L4自动化建议，不是原实现事实。

规范仍为AC-97-FS-005/2020，仅用于对照；这些角度、距离误差和化简公式的历史依据标记“实现依据待确认”。没有用规范补充不存在的IntersectWith/裁剪/主副区过程。
