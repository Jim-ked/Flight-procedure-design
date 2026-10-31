# A10 几何与衔接

构造体和端部连接由 `DmeArc.Bodies.Recovered.cs` 机械转写，CAD 参数由 `DmeArc.Native.Recovered.cs` 保留。每个 offset 均有三条 Arc；只有中央 offset 生成完整六顶点 Polyline。没有 IntersectWith、Offset、Trim、Extend 或自动包络/裁剪调用；衔接已代码化为圆心、角度、bulge 计算，后续人工观察衔接的行为未有运行证据。
