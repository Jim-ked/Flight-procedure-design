# 所谓定点转弯的真实恢复边界

帮助标题为“PBN-ILS定点转弯评估”；核心源码/控制引用只见THR与跑道end两点。没有turn point、turn-end/next point、left/right、incoming/outgoing航迹输入，不存在三点转弯链、earliest/latest TP、风螺旋或post-turn航段。

P55C→P55D→P5DE/P5DF是**同轴直线复飞侧向衔接**。模型类的恢复名PbnIlsTurn仅保留请求目录命名；不能凭名称证明转弯。P793、Spiral86构造/采样在B4核心及事件依赖路径中没有调用。恢复源码编译复用PointLists的既有依赖文件包含Spiral86，只是构建依赖，绝非原B4使用证据。

PI/12有两种上下文：共享OAS CATI“非精密延伸段”辅助线（P413/P419/P41B）；B4 P5DF在OAS 300m交点连线上求SOC处点，再将该连线角减15°构造扩张线。它没有方向选择或转弯半径；不把这个15°称作完整转弯保护。30为米，未见本路径30°转弯扩张。

左/右、小角/大角夹具标为不适用：原实现未提供对应控制量。已有全部站距及宽度边界fixture；未合成任意转弯功能来获得验收。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P55C|0x0600055D / 0x8A970|0x710AC|61057|
|P55D|0x0600055E / 0x8ABAC|0x7123C|61094|
|P5DE|0x060005DF / 0xB2CB0|0x844F4|71771|
|P5DF|0x060005E0 / 0xB3034|0x84750|71828|
|P5E0|0x060005E1 / 0xB36EC|0x84CAC|71916|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
