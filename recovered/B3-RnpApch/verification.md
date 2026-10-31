# 分层验证与恢复偏差清单

数值/记录fixture：193；独立源码断言：303；静态事件/可达性断言：44。两者分开，不以大PASS掩盖业务覆盖。

|层|断言|
|---|---|
|formula|171|
|geometry|72|
|degenerate|10|
|invariant|13|
|classification|27|
|serialization|10|
|event/reachability（静态）|44|

## 适用性

- A/B/C/D × 标高0/900/900.001/1800 × VPA3/3.2/3.3 共48组APV构造/HL/Xz记录；SOC含3风速×3高度及独立kt开关。
- LNAV/APV主/副区/区外、纵向端点、最终/水平/复飞点位各有记录；逐项有固定预期的断言与单纯记录数量分别保存。
- 同一(1000,0,100)分别评价LNAV/APV，得到175/149，未合并；APV穿透主副区及零MCG当量高已断言。
- DH变化仅作静态不可达/无reader检查；LNAV类别不进入工厂。左右转不存在；不能凭要求补转弯fixture。
- 保存文本测试是支持控件已扁平化后的记录adapter，未加载WinForms/AutoCAD；CAD测试只断言writer输入/XY丢Z/完整XData。
- 超时40s，本次无超时；无效VPA0/−3/90记录NaN/Inf/提示，不宣称已穷举退化后所有分支。

## 恢复代码变换（需与原体区分）

- 四个业务/记录类和两最低标准后处理保留混淆字段名及分支；IL InitLocals上提以使goto能够编译，原真/假混淆谓词按已提取值替换。
- 宿主许可静态初始化不执行；MessageBox写RecoveryMessages，Discard替代未消费求值；这些属于测试适配而非原DLL行为观察。
- P595有一个构造后即丢弃且无字段/方法消费的plane carrier，恢复测试省略该无业务消费分配；不据此声称原方法无该指令。
- RnpApchMissed及Cad文件是算术/文本/CAD输入记录适配，非完整原生事件Form，也不是新保护区设计系统。
- build.py引用冻结A6/B5的公共原语源码（包括编译所需而B3不调用的Spiral86），没有修改它们；没有引用/运行WindSpiralBasic.dll。

## 复核证据

[fixture索引](../round6/fixtures/index.json)、[静态断言](../round6/static-tests.json)、[构建日志](../round6/tests.log)、[测试输入哈希](../round6/test-inputs.json)、[恢复方法映射](evidence/recovery-method-map.csv)。完整源/IL定位与branch/field索引可逐点复查。
