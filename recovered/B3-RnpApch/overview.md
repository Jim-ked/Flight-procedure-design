# B3 RNP APCH — Round 6

状态：**PARTIALLY ACCEPTED**。两个独立业务类分别实现 LNAV 水平主副区/MOC 与带温度修正的 APV 数值超障面/当量障碍物高。APV 公式特征对应 Baro-VNAV；没有 SBAS 专用算法或自动导航规范调度证据。不能把组合窗口当作完整可操作进近设计系统。

UI 可达的是跑道拾取/交换、障碍物读取/坐标转换、LNAV 折线绘图、SOC/TP 小计算、标记、高亮和状态保存加载。LNAV P594、APV P5EE 主评价器均 **orphan evaluator**；APV 工厂 P470、两套最低标准后处理与 APV 结果表同样没有实际入口。未补接这些方法。

FAF 高度、名义距离及 APV 对应三维点的代码角色已确定；独立 MAPt 输入/点不存在，不能从规范补入。MCG 为主复飞爬升梯度输入；MDist/MStart/MEnd/MPdg 属于独立 SOC→TP 计算器。无统一 Procedure 对象，保存的是控件状态。

审阅入口：[事件图](event-map.md)、[LNAV](lnav.md)、[APV](apv.md)、[字段](field-semantics.md)、[规范差异](standard-mapping.md)、[验证](verification.md)、[收口与32问](../round6/closure.md)。

可审计材料包括108个核心方法、248个方法身份、56个事件绑定、字段/条件/调用索引、原/处理IL、31个机械恢复方法映射及独立测试；数量来自索引，不能代表已验证全部浮点输入。未操作 AutoCAD、未执行目标 DLL，Round 1–5 冻结。

## 证据读取约定

Pxxx 均指处理后 MethodDef 的末三位，不能视为原 token。原/处理 token、RVA、原 IL 状态、体哈希及源行见 [method-index.csv](evidence/method-index.csv)。方法原/处理 IL 分别在 evidence/raw、evidence/processed；带行号摘录在 evidence/methods。原始受保护体多为占位；算法证据主要是去混淆体/处理 IL，并非原始占位体直接包含这些公式。

证据级别：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL/字段流/调用交叉恢复；E3 独立恢复代码验证（不是原 DLL oracle）；E4 原程序运行验证（本轮无）；N 规范解释/推断。恢复不等于合规性鉴定。
