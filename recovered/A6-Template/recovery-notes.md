# 恢复方法、证据等级与剩余边界

## 来源与保护层

原DLL SHA-256及绝对路径见 `../round4/material-baseline.csv`。`evidence/body-provenance.csv`逐方法列原始/处理body状态与大小。很多原始method body只是`nop…ret`等保护占位：例如原P1F1保护方法raw只有4字节，处理副本才有完整主体。**原始token/RVA的存在不证明原文件明文包含本报告的完整几何**。

因此几何表达式的主要证据等级是“既有去混淆结果及其反编译、处理后IL”；原始DLL提供身份、元数据、signature与占位body交叉定位。本轮未重新加载或执行原DLL/未知二进制。raw和processed都保存，不能把processed主体写成原始明文源码。

`methods.csv`包含296个范围内MethodDef；`signatures.csv`保存原/处理592个签名记录，ctor重载按参数数目匹配，未按同名混配。P353为P/Invoke没有managed body，记录元数据但无伪造IL文件。共享writer另有3个MethodDef包 `evidence/writers/`。

## C# 变换清单

`../round4/recover.py`只从既有带源行号摘录生成本轮类：

- 类赋可读别名，字段/方法标识保留；去掉反编译产生的重复 `_0020:` 标签，保持位置参数次序。
- `base._002Ector()`由C#语言隐式object ctor代替；struct ctor使用`:this()`。
- synthetic setter `num/text`改为C#的value；getter/setter、重载和运算符均保留元数据定位。
- IL local声明提升到方法入口并default初始化；原地有意义的赋值保留，goto顺序保留。仅原地写`=default(...)`的反编译局部声明不重复重置。这样避免标签交叉导致C# definite-assignment失败及循环back edge误重置。
- 去掉宿主`LicenseManager.Validate`实际执行，原始证据文本不改；这是独立算术适配，**不是可替换原插件的破解DLL**。
- 保留opaque predicate helpers的处理后true/false体、分支、无界循环、重复点、未使用局部/字段、丢弃结果与显示舍入。无规范纠错。

handwritten的Envelope、TemplateCad、Scalar为小范围可读恢复/适配；精确业务来源和方法映射见各文件注释及对应报告。没有构建TemplateEngine/新的产品软件，也没有替换WsTools原件。

## 验证范围

冻结纯几何P793/Spiral86输出与本轮同MethodDef适配比较；完整模板独立执行、分支fixtures、镜像、有限性、重复性、名义弧端点半径、Envelope退化状态、writer记录验证通过。测试来源SHA-256在test-inputs.json；不是原插件输出oracle。没有全输入域数学证明，也不宣称100%分支覆盖。

每个sampling Polyline的相邻顶点在记录中由线段连接；名义弧端点通过bulge弦长反推r校核。未证明任意风/速度下采样边界是解析最小包络、严格切向连续或满足规范全部包含关系。

## 待确认项及可验收范围

|项目|已恢复|仍未验证|
|---|---|---|
|四类主要几何|完整分支/控制点/采样C#、IL索引|原DLL输出对照；全部极端参数|
|Envelope|输入读取/忽略字段/转移/输出完整|宿主Point3d近等容差内部；退化输入宿主实际卡死行为|
|CAD|创建次序/bulges/Group/metadata/transaction静态完整|OCS/Normal、Group持久状态、空实体接受/异常图面|
|Racetrack|全部事件/控件中无独立入口|其设计业务意图，不能补造模式|
|规范依据|真实公式和差异已分级|具体版本/作者简化选择；规范逐条合规|

这些项不是“只生成C#”掩盖的缺口。宿主运行、规范合规和业务独立模式不作为本轮静态恢复已验证结论；最终验收范围按closure单列。
