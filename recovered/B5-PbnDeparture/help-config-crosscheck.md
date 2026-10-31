# 帮助/config与代码交叉核验

原路径 WsTools-master/WindSpiral2026/帮助文件/FormPbnDepEvl.html 与 FormFlyOverDF.html；副本在reverse-analysis/01_original同路径。原件与副本均只读，hash在frozen-inputs.json。

|材料说法|代码事实|结论|
|---|---|---|
|B5有定高和FlyOver-DF|两个tab和独立业务类|支持公开范围，非完整PBN departure engine|
|一键/直线/转弯评价可用|三个按钮隐藏且只提示|帮助不等于当前版本可用流程|
|列表高亮并居中|绑定P4F9仅高亮；居中旧方法P4FA未绑定|部分帮助与绑定不符|
|B2 ATT为0外边界与B5高度相同（FormFlyOverDF:62）|B5没有new B2，也没有ATT=0参数传递|不证明也不否定数学边界相同；仍待数值/结构等价证明|
|导航规格/类别自动选值|无对应绑定，FO1482和宽度常数硬编码|不能依据帮助概述补出RNP dispatch|
|保存配置|P4F1→P0F6、P4F2→P0F4均用FormDeparture key|FormPbnDepEvl标题不等于配置键；无规范自动选择证据|

P06B命令特性 Y55_PBN_Departure→new P4EE Form；原/处理身份及IL在method-index与processed。Load后真正可达内容以事件/调用索引为准；未读取或执行外部脚本来填补缺失入口。
