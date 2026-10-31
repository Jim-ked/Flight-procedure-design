# CAD交互与自动化边界

L1 Direct处理代码；公共追加helper `-/-.cs:1578`；各事件见geometry.md。

| 操作 | 正常路径拾取 | 进入计算 | 实体 |
|---|---|---|---|
| 单台定位 | 2次GetPoint | 电台位置、方向及未指定时的距离 | 1容差Polyline；可选1航迹Polyline、2KK Line；DME开启时3Arc及1DBText |
| 顶空盲区 | 1次GetPoint；航迹容差开启另1次 | 圆心、可选入航方位 | 1Circle；可选2Polyline |

这些路径没有GetEntity/GetSelection，不验证拾取对象是设施、TP或既有KK。没有非空metadata传入追加helper，因此本路径不写WsObject；也未发现独立XData赋值。图层、颜色和线型未在这里显式设置，不能据此断言最终显示样式。

人工在提供业务基准和方向。程序未从一个共享程序对象提取这些输入是代码事实；为什么作者如此设计没有直接证据。未来若有设施坐标和航迹数据，可推导拾取坐标是L4自动化可能性，不是本软件已实现能力。

取消/Origin哨兵、输入异常、Visible及原生实体已转写到FixToleranceForm.Events.Recovered.cs，尚未编译运行，不是可安装插件。盲区数字非法的catch保留Visible=false；后缀框Leave实际触发NDB半角重置事件。
