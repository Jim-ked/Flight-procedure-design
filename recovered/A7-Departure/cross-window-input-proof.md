# A7 跨窗口输入最终证明

A7 的 DER、THR、TP、KK′、C 均经 GetPoint 取得坐标，再转为距离/高度文本进入本窗口模型；未发现 A2/A3 业务实体语义 reader。结论限于已索引的直接 call/callvirt/newobj/MethodSpec 闭包。

|对象|A7入口|下游|人工原因|
|---|---|---|---|
|DER/THR|P27E/P27F GetPoint→P0AC/P0AD|跑道长度与局部坐标|无跑道实体识别；已有坐标可外部推导|
|TP|P287 GetPoint→XY hypot→P289双高度|P202从CalculationHeight反算tp|无投影/符号/共线校验，需人判断转弯点|
|KK′|P28A GetPoint→距离|P202的kk、P203的dr/do|A3 KK空metadata，无A3语义reader|
|C|P28B GetPoint→距离|P202的c、P203后续分支|无turn-end自动推导|
|障碍物|P279→P276/277/278→P12F|局部XY、评价、表格、Mark|SelectAll Model DBPoints；Mark需选表格行|

A7可达闭包未发现 WsCalcuLine、RegApp、Entity.XData、GetXDataForApplication 的跑道/TP/KK/C reader。唯一 GetXDataForApplication 在共享障碍物名称解析器 P717；A7 Group 是输出容器，全向 Circle 的 WsObject 是写出 Radius 字符串。因此：
A7 does not automatically consume A2 WsCalcuLine in the indexed build.
A7 consumes picked coordinates, not A3 semantic KK objects.
