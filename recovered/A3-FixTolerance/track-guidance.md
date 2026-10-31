# A3 Track guidance 静态定性

普通定位容差 checkBoxTrack 只追加 S→P(r+e,theta) 两点 Polyline，与楔形共用 Polyline Group，是参考/载体线；没有第二台站、线线求交、偏航动态或完整导航引导模型。

顶空盲区 checkBox2/BlindTrack 是另一条辅助链：再拾取入航方向，P211 按 VOR 5/15 或 NDB 15/25 度生成两条端点连线，再与 Circle 分开输出。它不是普通 Track 的同一几何，也不是保护区包络。
