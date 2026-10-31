# Round 4 — A6 传统保护区模板

范围：`Y06_传统模板` 的 Holding/Racetrack 页面、Base Turn、45/180、80/260、多个实体 Envelope。仅本目录及 `../round4/` 是本轮产物。Round 1–3 与原始材料冻结。最终验收见 [closure](../round4/closure.md)。

## 阅读入口

|问题|成果|
|---|---|
|事件、控件、直接调用、CAD API|[event-map.md](event-map.md)、`evidence/events.csv`、`shared-turn-events.csv`|
|共享 turn 输入和单位|[turn-parameter-usage.md](turn-parameter-usage.md)|
|普通等待及全向等待|[holding.md](holding.md)|
|XE、YE 的两套含义|[holding-xe-ye.md](holding-xe-ye.md)|
|Base Turn 完整分支与控制点|[base-turn.md](base-turn.md)、[控制点 CSV](base-turn-control-points.csv)|
|程序转弯|[45/180](procedure-45-180.md)、[80/260](procedure-80-260.md)、[实际角度](procedure-turn-angle-index.csv)|
|多模板包络和共线缺陷|[envelope.md](envelope.md)|
|输出、人工输入、衔接|[cad-output-map.md](cad-output-map.md)、[cad-interactions.md](cad-interactions.md)、[connections.md](connections.md)|
|共享关系与旧负结论补充|[shared-template-geometry.csv](../round4/shared-template-geometry.csv)、[shared-geometry.md](shared-geometry.md)|
|恢复变换、证据等级、限制|[recovery-notes.md](recovery-notes.md)、[规范差异](standard-differences.md)|
|独立执行、原始输入与全部顶点输出|[测试记录](../round4/tests.log)、`../round4/fixtures/*.json`、[fixture 索引](../round4/fixture-index.csv)|

## 证据解释

本文各页的 `Pxxx` **均指 processed MethodDef `0x06000xxx`**，不是原始 token；原始/处理 token 和 RVA 精确对应见 `evidence/methods.csv`。源码摘录的前缀行号对应 `reverse-analysis/03_recovered-src/annotated-strings/--/--.cs`，不是摘录文件的物理行号。

1. **原始程序集证据**：原始 DLL hash、元数据、`evidence/raw/*.il.txt`。
2. **处理/反编译证据**：处理副本 IL、带源行号摘录、事件绑定；去混淆后 token 通过表映射。
3. **恢复逻辑**：对 IL 栈、字段和分支的解释；C# 保留原表达式与分支次序，变换列于 recovery-notes。
4. **恢复代码执行**：fixtures、数值和不终止状态观察；不等于原 DLL 运行。
5. **原软件运行验证**：本轮没有；未操作 AutoCAD、未加载目标程序集。
6. **规范/上下文推断**：单独标注，不能替代代码证据。

## 主要结论

- 所有已绑定模板入口通过 P356→P854→P793。Racetrack 未找到独立开关或第二套构造器，保留其页面业务名称及实现缺席事实。
- 普通 Holding/Base 使用 Spiral88；专用 XE/YE、45/180、80/260 使用 Spiral86。不能把两类归并。
- Base φ 是带负号的分段公式；NDB 扩张角实际为 **6.5°**。secondary 为采样和控制点构造，未调用 AutoCAD Offset。
- 全向等待由普通模板平移、有限方向旋转、两次点集包络构造。
- Envelope 为顶点 gift-wrapping，非 Region union；不读 bulge，不删原模板，未写类型 metadata。共线退化可能遗漏最远点或不终止。
- 本轮补证 P7AF/P7C2 为两个 spiral 的拼接角方法；它们不是 P7AD。冻结报告不改，补充证据见 shared-geometry。

## 可复核执行

在工作区运行 `python recovered/round4/build.py`，只编译独立恢复源码和冻结的纯几何文件；不引用目标 DLL。`test-inputs.json` 保存编译输入 SHA-256；旧日志存入 `test-history/`。`python recovered/round4/audit.py` 只读核对冻结文件和本轮证据、输出本轮清单。不要重新运行旧轮次生成器。
