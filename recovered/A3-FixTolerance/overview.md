# A3 定位容差：静态恢复包

2026-10-27 Closure：[参数/几何链](geometry-chain.md)、[CAD输出](cad-output-map.md)、[总验收](../round1-closure.md)。已通过25.1兼容编译，EXP-09/10未执行，无目标业务L3。

L1 Direct（处理后代码）及L2 IL，无L3。Form `_0088_0098._0088_0097`，阅读副本 `--/--.cs:4355`。原/处理token、RVA、控件、事件、调用及IL见 evidence.md / evidence/。

两条链：设施/引导开关→精度角→单台容差几何→KK早晚线→CAD；高度/锥角→顶空半径→可选航迹容差折线→圆。

“交叉定位”按钮本身只拾取一个电台和一个方向点，不读取第二设施、不调用IntersectWith求两设施交集。多次绘制后人工组织图面是L4解释，不把它写成自动求交功能。

FixTolerance.Recovered.cs是已测计算切片；FixToleranceForm.Events.Recovered.cs保存两个原生绘图事件、输入/异常、事务、分组、设施/开关事件及现有注册。该原生文件已兼容编译但未运行，完整designer/config仍待接回，包仍为部分恢复。未观察到本事件向其他窗体显式返回计算结果；不能据此证明全程序集没有其他传递路径。
