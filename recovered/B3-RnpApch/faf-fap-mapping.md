# FAF / FAP / MAPt 映射

|Source field / UI|代码作用/坐标|保护用途|规范解释（N）|证据|
|---|---|---|---|---|
|textBoxFafAlti / FAF高度|绝对标高H；LNAV/APV都算d=(H−Z1−TCH)/tanVPA|LNAV F=(d,2685)，APV `_008A_008C_0086`=(d,2685,H−Z1)|与公布垂直航径在程序高度的交点计算相容，APV代码角色可解释为名义FAP；不证明与数据库LNAV FAF同一fix|P47D/P470/P593/P5ED E1/E2|
|textBoxZ1 / THR Z|入口标高；垂直基准|d、温度项及面高|THR参考|同上|
|textBoxTCH|基准高m|d、FAS起点|RDH候选|同上|
|comboBoxHi|固定输入q|温度修正后的FAS起点/侧面余度|Hi；代码单值，不自动分层|P470/P5ED|
|textBoxPDist|禁用显示默认0|无主业务消费者|不能据名字认定FAP坐标|控件引用索引|
|MAPt|无独立坐标/可移输入|固定444及THR简化模板|规范允许MAPt在THR前移动；代码不提供该关系|构造/字段/事件穷举|

2020规范PDF511页4.3.2区分FAP（垂直航径与前序高度交点）和LNAV FAF/MAPt（平面构型/编码）。本实现共用一个高度计算名义距离，未存储两种导航fix身份。这个代码关系已经确定；不能说“FAP所有作用未知”，也不能擅自把二者等同为一个航路点。
