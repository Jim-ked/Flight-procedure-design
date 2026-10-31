# LNAV 业务链

P47D→P593 参数依次为 `(IfSegLen,FafAlti,Z1,VPA,TCH,MCG/100,ThrToSoc,SocToTp)`。不读取类别、风、TpAlti或独立MDist计算器。四条绘图轨迹在构造器一次建立。P594按沿程分支调用本类P595线性主副区计算；没有调用A9。

```text
THR/RWY-end → P47B公共frame
输入 → P47D → P593 → 四条点列 → P47C → 公共CAD
POINT → P476 → P477 → P478转换 → P4B2展示
                         （无通往P594的边）
独立P594 → P595 → LNAV记录（孤立评价链）
```

LNAV SOC小工具P48A使用P793的TAS，`Round((TAS+wind)*NTime/3.6+444)`。类别不参与；时间为输入默认18s，bank固定15°，风/IAS各自kt开关×1.852。其输出NDist需要复制/粘贴进ThrToSoc；没有自动同步。

复飞仅直线延续、15°扩张及固定终宽，没有指定点转弯、左右转、风螺旋或实际TP转弯曲线。代码把THR至SOC和SOC至TP之和当作终止站距。详见点位表及评价分支，不能把几条开放折线命名成已裁剪封闭保护多边形。
