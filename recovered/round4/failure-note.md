# 恢复测试中的早期失败记录

本轮早期直接调用独立恢复Envelope.Hull处理反序共线输入时，测试进程出现OutOfMemoryException。随后保留Hull原算法，退化例改由测试侧相同状态转移及循环检测保存有界前缀。fixture见`fixtures/envelope-collinear-order.json`。

早期进程错误曾出现在工具输出；当时build脚本尚未保留历史，后续覆盖了tests.log。**本文件是事后记录，不是原始失败日志**，也不能作为原DLL/AutoCAD崩溃记录。本轮未执行原插件。

此外早期fixture序列化只反射字段，匿名顶层对象被保存为`{}`；测试工具已加入public properties并重新生成，审计脚本检查所有当前JSON非空。早期csc沙箱返回CS0016路径错误，后通过经自动审批的独立源码编译完成。均不以这些工具失败推断目标软件行为。
