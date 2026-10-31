# 当前构建的明确限制

这里的“孤立”指已建立的direct/MethodSpec调用及公开事件闭包中没有incoming/可达调度，不能扩展成排除所有反射、外部程序集或其他版本入口。

|模块|直接证据|当前公开功能边界|
|---|---|---|
|A5|P41B/P429完整面高/标签体；incoming为空|六模式绘图可达，无A5障碍物穿透/HL/最低标准公开链|
|B3|LNAV P594、APV P5EE、工厂P470及后处理孤立|LNAV绘图/导入可达；APV数值构造与评价不构成UI业务链|
|B4|P566 Evaluate消息提示；P5E0/P567/共享P41B孤立|绘图/导入可达；无端到端评价/控制障碍物归并|
|B4|绑定KML P56D空体|无区域、坐标、样式或KML输出|
|B5|P501/P50C/P50D提示分派；P5CD/P5D8数学体已恢复、无评价调度|绘图可达；没有端到端合并/排序/评价结果链|

这些模块采用 `PARTIAL_STATIC_BUILD_LIMITED`。其他可信构建比较是后续取证选择，未证明其他构建必有相关能力；本轮不补UI、不执行孤立方法。

其他已确认功能边界：A3无双设施自动cross-fix；A7无独立电台上空/导航方式guided分支或风螺旋；B3无任意左右转复飞链；B4为同轴固定宽度衔接，不是任意PBN转弯。此类“当前未实现”不等同反编译遗漏。

详细定位：[A5 closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round8/closure.md>)、[B3 closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round6/closure.md>)、[B4 closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round7/closure.md>)、[B5 closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/round5/closure.md>)。相关Help/UI分类见 [差异表](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/help-ui-code-final.csv>)。
