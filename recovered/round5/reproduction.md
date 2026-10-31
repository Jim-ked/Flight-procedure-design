# Round 5复现

只在工作区执行本轮脚本，不执行目标DLL。Python使用已有本地dnfile静态解析库；csc只接收Recovered.cs与测试文件。

1. indexes.py：刷新本轮metadata/IL/事件/调用索引；不刷新初始冻结基线。
2. recover.py：重生成八个机械恢复文件，不覆盖Form/CAD记录适配器。
3. annotations.py：按类、方法名与ECMA-335参数数核对77方法，写身份注释与映射。
4. reports.py、supplement.py：生成报告、公共MethodSpec解析、规范摘录与对比。
5. build.py：编译独立算术恢复、逐fixture子进程执行，超时受控终止；调用postcheck.py。冻结Round4共享原语只读引用。
6. close.py、audit.py：生成收口、冻结hash核验与输出manifest。

沙箱内系统.NET csc曾报CS0016目录名称无效；已通过工具允许的受审查编译命令运行。没有复制或执行原DLL来绕过问题。tests.log保留参数模型原ToString输出和最终断言结果。

standard-pages.json是对本轮基线规范的只读文字缓存；standard-excerpts.json仅列实际引用页。不是额外业务模块恢复。
