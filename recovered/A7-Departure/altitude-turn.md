# 定高转弯

事件P285/P286（原286/RVA2E30C、原287/RVA2E450）响应转弯高度/PDG文本变化：g=文本/100；g!=0时Round((turnAlt-DER.Z-5)/g,1)回填DrByAlti；g=0不更新文本。几何构造器仍直接原始除法，无同样的零保护。

输入IAS/Altitude/Bank/Wind/Temperature进入Round1公共turn参数模型；IAS/Wind按各自单位选择器决定是否乘1.852。默认风/坡度是UI值，不等于业务类锁定56/15。CAD P283与评价P282各自重新构造turn参数与定高模型。KML P284构造了模型，但后续只载入/保存kmlTemplate.xml；没有写入保护区控制点的证据，不能当真实几何导出。

定高构造/边界/评价分别原1FC/RVA17F3C、1FE/RVA18C94、1FD/RVA182F0。几何见geometry-altitude-turn；评价与定点不同，不能合并。完整等价C#为AltitudeDeparture.Recovered.cs。
