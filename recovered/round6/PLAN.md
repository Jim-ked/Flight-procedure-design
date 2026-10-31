# Round 6 — B3 RNP APCH

范围只限 Y53_RNP_APCH / FormApvEvl。Round 1–5 全部冻结；只写 B3-RnpApch/、round6/。原件只读，不运行目标 DLL，不操作 AutoCAD，不进入 B4/A5，不追加 B5 分析。

证据区分：原程序集身份/IL；处理IL/反编译；按IL恢复；独立恢复代码测试；原软件运行（本轮无）；规范/上下文推断。规范采用 AC-97-FS-005（民航规〔2020〕12号），代码恢复完成后映射，不修旧算法。

## 顺序与核验

1. 材料、冻结基线、既有基础层读取。核验路径/大小/SHA256，基线不覆盖。
2. Form事件/控件/字段/调用及原处理身份。核验全部绑定、隐藏、未绑定、占位与orphan evaluator。
3. LNAV链：点位/SOC/TP/最终与复飞几何/评价。核验构造参数、分支、直接公共调用。
4. APV链：HL/Xz/FAF-FAP/SOC/保护区/评价。核验类别与事件触发及Z/plane真实用途。
5. 复飞、调度/合并、字段语义、ScreenData/Mark。核验输入到结果，不补不存在的功能。
6. 最终CAD writer/XData/持久化。核验实体创建顺序、格式、人工对象语义。
7. 独立恢复代码与分类fixtures；按formula/geometry/classification/reachability/serialization/invariant/degenerate分层记录，不将测试冒充原DLL oracle。
8. 规范差异、32问、共享比较、收口与hash审计；停止，只列B3→B4已恢复层。

1–3、4–5检查点内部执行并继续。仅用户已列的未知二进制、修改原件、方向性无法判别歧义或关键材料缺失才暂停。测试和报告保留旧边界/负值/零除/异常，不设计统一新架构。

## 完成记录

步骤1–8已执行，内部核验完成；最终状态PARTIALLY ACCEPTED。评价器UI断链与数值APV面缺少CAD输出等已按门槛记录，不补实现。最终文件/hash审计由audit.py记录，正常阶段无需再确认。
