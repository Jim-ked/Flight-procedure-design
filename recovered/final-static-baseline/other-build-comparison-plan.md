# A5 / B3 / B4 / B5 可信构建比较计划（不执行）

目的：确认当前构建中孤立/提示/空体是否在另一可信版本有不同公开调度。可信来源需记录提供方、完整目录、获取时间、原始SHA256；不搜索或执行未知DLL。另一版本的存在及能力均未获证明。

1. 比较Assembly名、版本、TargetFramework、PE架构、引用、资源/MVID与文件hash。MVID和token可能变化，不能仅按Pxxx位置配对；按签名、IL形态、字段与字符串建立identity映射。
2. 比较Form构造/InitializeComponent事件绑定、Checked/Validated/Click/Load等事件及handler体，确认UI可达范围。
3. 比较目标evaluation/factory的所有direct/MethodSpec incoming、字段来源与结果消费者；区分消息提示、体替换和真实端到端处理。反射/外部入口若有新增证据，单列。
4. 比较config、Help、控件可见/启用状态、数据库及参数文件格式；只记录差异，不以帮助宣称覆盖代码。

|模块|优先配对链|应保存的判断证据|
|---|---|---|
|A5|六模式事件/P41B/P429|是否新增Screen/eval/穿透/最低标准调用；是否仍只是面高体|
|B3|P594/P5EE/P470及后处理|LNAV/APV工厂和评价是否接入公开事件；结果如何入表|
|B4|P566/P5E0/P567/P41B/P56D|Evaluate是否实际调度；KML是否仍空；Take5是否改变|
|B5|P501/P50C/P50D/P5CD/P5D8|提示是否变为评价；多候选如何归并排序；Take5是否改变|

预期产物：两原件hash、成员映射、事件diff、调用diff、配置/帮助diff与独立结论。保持当前基线冻结；比较发现不能回写为当前构建事实。

原始缺口定位：[构建限制](<C:/Users/ZJ/Desktop/固定翼航空器飞行程序-工程大/飞行程序设计系统开发/recovered/final-static-baseline/build-limitations.md>)。本轮未获取新构建，也未安排执行。
