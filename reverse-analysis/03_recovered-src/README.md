# 源码/IL 层次

- ilspy-original、il-original：直接对原件导出，保留原始保护状态。
- ilspy-methods-only、il-methods-only：对静态恢复程序集导出，属于处理结果。
- annotated-strings：分析阅读视图，替换字符串/布尔调用并附解码表偏移；**不是作者源码，不承诺能编译**。文本替换也可能产生非法 C#（例如限定类型前缀保留在字符串之前），不用于构建。
- 独立 IL、方法偏移、IL hash、异常处理数在 ../04_type-map/{raw,methods-only}/。

ILSpy 版本 9.1.0.7988。使用 `dotnet tools/ilspycmd/tools/net8.0/any/ilspycmd.dll --disable-updatecheck -p -o <输出目录> <输入DLL>` 导出项目，`-il -o <输出目录>` 导出 IL；执行时 paths 相对 reverse-analysis。未要求编译目标。未知 CAD 类型和 goto 结构必须回查 IL，不能把反编译警告全部认定为损坏代码。
