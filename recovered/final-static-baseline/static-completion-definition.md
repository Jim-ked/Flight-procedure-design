# 静态恢复完成的定义

`COMPLETE_STATIC` 表示当前冻结构建中，公开事件链、业务计算、几何/评价、适用的 CAD writer、metadata/持久化及负向功能证据，已恢复到可追踪原/处理身份、字段/调用与分支的可审计程度。不存在的功能以负向证据说明；不按帮助或规范补接。

该状态不表示原始运行等价、航空规范符合性、生产就绪或认证。也不保证恢复 C# 是完整可运行工程：B1/B2 的 Boundary C# 为 DTO/局部标量及 writer 记录，完整几何依据仍在冻结 source/IL 和分支索引。见 [B1 closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/B1-FlyBy/final-static-closure.md>)、[B2 closure](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/B2-FlyOverDF/final-static-closure.md>)。

`PARTIAL_STATIC_BUILD_LIMITED`：数学体/绘图及负向调用证据已审计，但当前构建公开调度为提示、空体或孤立链，无法作为完整公开业务链。A5/B3/B4/B5均属此类。它们不是普通“算法未反编译完”。

`PARTIAL_STATIC_OTHER_BUILD_REQUIRED`：需要其他可信构建才能确定关键已知缺口、且本轮证据必须支持该分类。当前没有模块采用此类。可以建议比较其他构建，但不能据此断言另一版本必有功能。

`NOT_PUBLIC_BUSINESS_FUNCTION`：辅助/诊断/通用工具不纳入15个航空公开功能统计。gap inventory中的辅助行不增加公开功能分母。

## 证据分层

- E0：原始程序集身份、PE/引用、事件/成员元数据及原件hash。原保护桩本身不证明明文公式。
- E1：去混淆/反编译结果，保留处理前后映射，不冒称作者源码。
- E2：IL、事件绑定、字段读写、调用图、CAD/数据库链交叉恢复。
- E3：独立恢复源码/记录适配器的既有验证；不是目标DLL运行。
- E4：原插件在匹配宿主中执行相关业务并保留输入/事件/实体等观察证据。全部模块尚未完成。
- N：规范/上下文映射与解释。推断保持独立，不升级为源码事实。

Round13/14 的生成式 static-tests PASS 清单不计作新执行的数值测试。Round3 C# 编译失败，Python10条共享恢复断言通过；不据此声称完整B1/B2数值移植通过。各轮断言、fixture文件、点数和业务案例不能相加冒充覆盖率。

## 统计

由 final-public-function-status.csv 记录重新计算：

- `COMPLETE_STATIC`: 11
- `PARTIAL_STATIC_BUILD_LIMITED`: 4
- `PARTIAL_STATIC_OTHER_BUILD_REQUIRED`: 0
- `NOT_PUBLIC_BUSINESS_FUNCTION`: 0

历史RoundStatus完整保留；本轮FinalStaticStatus单列。状态适用范围为此冻结构建和已索引公开链；无indexed incoming不证明任意外部程序集/反射绝不可能调用。
