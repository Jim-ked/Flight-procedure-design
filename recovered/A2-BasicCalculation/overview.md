# A2 基础计算恢复包（静态恢复及25.1兼容编译）

2026-10-27 Closure：[六事件/输出](cad-output-map.md)、[WsCalcuLine](WsCalcuLine-schema.md)、[总验收](../round1-closure.md)。AUTOCAD分支已通过25.1兼容编译，无原目标业务L3；下列旧状态更新为本记录。

2026-10-26。L1 Direct来源为处理后可读代码；L2 IL来源为恢复IL及原/处理token映射。没有L3 Runtime。前置业务分析只用于解释控件，不代替代码证据。

BasicCalculation.Recovered.cs 是已编译测试的数值切片。BasicCalculationForm.Events.Recovered.cs保存六绘图事件、回填与计算注册，TurnParameterInput.Recovered.cs保存依赖reader和构造器；参数工厂/JSON模型已测试，CAD写入已转写。AUTOCAD条件代码已兼容编译但未运行，完整designer/config、自定义单位控件尚未接回；不标记“任务一完整恢复完成”。

六页均通过两次共用GetPoint helper取施工基准/方向，而不是GetEntity读取已有实体业务数据。**输出Line确实有WsCalcuLine XData**，说明“施工点通过坐标重拾取”和“施工线保存参数”可以同时成立，不能二选一。

FAF名称维持原UI语义，未擅自更名为FAP。参数工厂保留FAF、THR、RDH等参数不证明满足某种程序规范。

测试：12个A2数值断言+零梯度行为通过（包括新增TAS和kt换算）；输入解析、UI事件顺序、CAD事务与宿主类型尚未运行验证。详见 ../verification.md。
