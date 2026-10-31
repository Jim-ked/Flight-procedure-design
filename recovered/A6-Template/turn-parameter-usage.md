# A6 turn parameter 与输入事件

## 真实调用链

`FormTemplate.P356 → embedded control.P854 → new P793(IAS, altitude, bank, wind, temperature)`。

|模板入口|processed handler|构造器|turn 来源|
|---|---|---|---|
|Holding CAD / calculate|P364 / P366|P3AB|P356|
|Racetrack|没有独立 handler|页面共用 Holding 对象|没有第二套计算证据|
|XE / YE|P375 / P376|P3BD / P3C9|P356|
|全向等待|P377|Holding + XE + YE|P356；P378 再读 P854 的 altitude|
|Base CAD / calculate|P35F / P362|P1ED|P356|
|45/180 CAD / calculate|P35D / P35E|P452|P356|
|80/260 CAD / calculate|P35B / P35C|P45E|P356|

P854 的 processed IL `IL_00A0 newobj P793`；本轮 `shared-template-geometry-sites.csv` 保存调用位置。P793 的公式沿用冻结 [turn-parameter.md](../GeometryPrimitives/turn-parameter.md)。本轮未找到模板另算 TAS、bank→rate 或基础 radius 的公式。几何内的 `TAS/3.6`、`Wind/3.6` 只是 km/h→m/s。

## 单位

IAS、Wind 的单位选择器启用 kt 时，reader 各乘 **1.852** 后传 P793；Altitude、天线高度为 m，Bank 为度，Temperature 为温差输入的原值。reader catch 显示输入错误并返回 null；模板入口并非全部防护 null，未补校验。

Holding、XE/YE、45 输入 min，构造器乘60；Base UI time 分支先乘60传秒，distance 分支传 nm，构造器乘1852。80构造器没有 time 参数。几何角通常 rad；度制 sampler 的参数在实际源码中明确乘 π/180，不可统一替换。

## 公共控件的8个绑定

|事件|handler|作用|
|---|---|---|
|checkableLabel1.Click|P85B|IAS单位开关及显示更新|
|checkableLabel2.Click|P85C|Wind单位开关及显示更新|
|button1.Click|P85D|自动风更新入口|
|textBoxIAS.TextChanged|P85E|触发公共参数刷新|
|textBoxAlti.TextChanged|P85F|高度相关刷新|
|textBoxBank.TextChanged|P860|坡度相关刷新|
|textBoxTemp.TextChanged|P861|温度相关刷新|
|textBoxWindSpeed.TextChanged|P862|风速相关刷新|

精确赋值、控制状态和调用见 `evidence/_008F_0098.source.txt`、`shared-turn-controls.csv`、`control-references.csv` 及 event-map 的逐事件表。本轮复用冻结 `A2-BasicCalculation/TurnParameterInput.Recovered.cs` 的解释；未重新制造 WinForms designer，也未把控件外观当作调用证据。

自动风P85D实际算 `0.012×altitude(m)+87`，Wind单位开关启用时再乘0.539957，显示F2。高度TextChanged会将自动风按钮样式改变并触发更新事件；不能把它描述成每次高度改变都自动重新计算风速。单位开关显示转换使用1.852/0.539957和F2，reader再次转为km/h，这些显示舍入与P793几何计算舍入不同。

MOC=300：仅在 Form 未绑定的 P363 评价方法读取。Base CAD secondary width 控件=4630，而 calculate 不传宽度，用构造器默认4600；这些不是 turn radius。
