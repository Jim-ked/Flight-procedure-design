# A5 Precision Approach / OAS 差异恢复

**Round 8: PARTIALLY ACCEPTED (static recovery)**，2026-10-28。

本构建 A5 是绘图为主的精密进近参数/保护轮廓窗口：**A5 is drawing-oriented in this build**。六模式 dispatch、独立几何、数据库关系、W/W*、FAF/FAP、二维 writer、分段参数文件及 config 已静态恢复。完整面高方法 P41B/P429 全程序集 direct/MethodSpec incoming 均为空，A5 事件不可达；没有可达障碍物评价、HL、最低标准链。按用户验收条件保留部分验收，不补接。

## 阅读入口

- [六模式矩阵](mode-matrix.csv)；[事件图](event-map.md)；[类关系](class-map.md)
- [数据库/参数](oas-parameter-model.md)；[面/域](oas-surfaces.md)；[W/W*](w-wstar.md)
- [GP INOP](gp-inop.md)；[PAOAS](paoas.md)；[OAS绘图](oas-cad.md)
- [PA-FAP](pa-with-fap.md)；[PA-FAF](pa-with-faf.md)；[字段映射](faf-fap-mapping.md)
- [CAD输出](cad-output-map.md)；[人工交互](cad-interactions.md)；[XData](xdata-schema.md)
- [参数文件](oas-txt-format.md)；[持久化](persistence.md)；[评价](obstacle-evaluation.md)
- [HL](hl-correction.md)；[最低标准](minima.md)；[规范映射](standard-mapping.md)
- [验证](verification.md)；[未恢复项](unrecovered.md)；[26问收口](../round8/closure.md)

## 与 B4 的主要差异

A5 直接使用共享五面模型普通 OAS 几何，AUTO 组合 W/W*；B4 专用 _008C_0095 只读 W/X/Y/Z，另构造同轴衔接。A5 不 new B4 专用类。A5 的 P409–P40C 与 B4 P571–P574 是独立 MethodDef 的同 schema/解码/修正复制实现。真正共享的是 _008A_0093、Plane 及公共几何/CAD helper。A5 自有 GPINOP、PAOAS、FAF、FAP 类。文件也不同：A5 分段 JSON，B4 旧 CSV 文本，不能互当同格式。

本轮只写 A5 与 round8 两目录；原件及 Round 1–7 冻结。恢复源码只用于审计与研究，未作为可批准的飞行程序计算软件交付。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P306|0x06000307 / 0x3FDF0|0x34FDC|24016|[证据](evidence/processed/0x06000306.il.txt)|
|P307|0x06000308 / 0x401EC|0x3537C|24174|[证据](evidence/processed/0x06000307.il.txt)|
|P409|0x0600040A / 0x63AE4|0x51B54|41676|[证据](evidence/processed/0x06000409.il.txt)|
|P412|0x06000413 / 0x647B4|0x523E0|42078|[证据](evidence/processed/0x06000412.il.txt)|
|P41B|0x0600041C / 0x65268|0x52DA4|42448|[证据](evidence/processed/0x0600041B.il.txt)|
|P429|0x0600042A / 0x679E0|0x55010|43908|[证据](evidence/processed/0x06000429.il.txt)|
