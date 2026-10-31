# WsTools / WindSpiral2026 深度逆向分析任务书

## 1. 任务目标

对 `WsTools-master/WindSpiral2026` 进行代码级逆向分析。目标不是罗列功能，也不是简单导出反编译代码，而是尽可能恢复 WindSpiralBasic 的真实软件结构、计算链、条件分支、CAD 交互逻辑、保护区构造与衔接方法，并把这些结果组织成可用于后续“有人机飞行程序设计自动化”开发的技术基础。

本阶段只研究现行有人机飞行程序设计辅助/自动化，不讨论无人机扩展、协同运行、三维空域等后续内容。

最终需要回答的中心问题是：

1. 软件中每一种程序/保护区的输入、分支条件、计算过程、几何构造、障碍物评价和输出是什么？
2. 各窗口并非孤立时，它们共享哪些底层算法、控件、数据结构和几何方法？
3. 哪些步骤由程序自动完成，哪些步骤依赖设计人员在 CAD 中拾取、选择、判断、试算、裁剪、包络或重新绘制？
4. 保护区之间如何衔接，尤其是直线与转弯、主区与副区、前后宽度不同、定位容差与转弯区、传统与 PBN 各种转弯之间的衔接？
5. 如果要把现有 WsTools 的“人工交互式辅助设计”提升为更高程度的自动化，哪些人工操作可以可靠地转化为算法，哪些仍应保留人为设计判断？

## 2. 必须先阅读的材料

不要直接从 DLL 开始。先完整阅读并建立证据索引：

- 项目根目录 `README.md`
- `WindSpiral2026/#U8f6f#U4ef6#U8bf4#U660e.txt`（软件说明）
- `WindSpiral2026/#U5e2e#U52a9#U6587#U4ef6/README.md`
- 帮助目录下全部 HTML 页面及其源代码
- `config.xml`
- `oas.db`
- `Sample/` 全部样例文件
- `WsSymbol2.1.dwg` 的块/图层/属性定义（如工具允许）
- `System.Data.SQLite.xml`
- 整个 WsTools 目录中的其它压缩包、说明、课件和可执行工具，尤其与 PANS-OPS/OAS/风螺旋模板有关的资料

帮助文档只能作为“作者意图与界面语义”的证据，不得默认与 DLL 100% 一致。

## 3. 已知文档线索，必须在代码中验证

### 3.1 软件定位

根 README 将 WindSpiral2026 定义为飞行程序设计 CAD 插件，使用 C#，支持 AutoCAD 等 CAD 平台。软件说明称基础版面向学生和初学者，用于算法验证、项目实践和应用分析，结果需由使用者自行负责。

这意味着逆向分析必须区分：

- 规范算法是否完整实现；
- 是否存在教学/基础版简化；
- 是否把部分规范判断留给用户人工完成。

### 3.2 帮助中心的公开模块

帮助首页公开：

传统程序 10 项：
- 风螺旋
- 基础计算
- 定位容差
- 非精密进近保护区
- 精密进近保护区
- 传统模板
- 离场越障评估
- 复飞转弯区评估
- 主副区评估
- 起始进近 DME 弧

PBN 5 项：
- Fly-by
- Fly-over / DF
- RNP APCH
- PBN-ILS
- PBN Departure

辅助窗口 4 项：
- 图块导入
- 图层批量创建
- 外扩线
- 随机障碍物点

另外还有无窗口命令：RCL、NMCIRCLE、rectLine、Arc2、xInfo。

### 3.3 必须重点追查的跨模块关系

帮助和 config 已经表明部分模块不是独立算法：

- `turnParameterControl1` 被 WindSpiral、FlyBy、FlyOver 等共同使用，必须追踪该控件的类、计算方法及所有调用者。
- 传统模板的转弯半径共同由转弯参数面板计算。
- Fly-by 帮助明确写明：当前后航段保护区宽度不同时，通过风螺旋进行衔接。必须恢复实际衔接算法，而不能只写成一句功能说明。
- Fly-over 帮助写明：ATT=0 时，转弯外边界与 PBN 定高转弯保护区相同。必须验证代码是否复用同一几何函数或仅数值等价。
- 传统转弯离场与复飞转弯保护区在规范上存在方法复用，必须检查 DLL 是否也存在共享算法。
- 传统 45/180、80/260 程序转弯有“包络线”功能，用户需要选择多条已绘制多段线后合并包络。这里是明显的人工交互点，应追踪其 CAD 几何算法及是否可自动化。
- `xInfo` 可以输出实体 XData(JSON)。必须追踪所有写入 XData 的位置、schema、用途以及是否用于不同功能之间的数据传递。

### 3.4 离场模块是首要深挖对象

帮助中的传统离场至少包含：

- 跑道数据
- 定高转弯
- 定点转弯
- 全向离场
- DER 之前转弯
- 直线段二次检查
- 障碍物一键评估
- CAD 保护区绘制

定高转弯包含：直线段梯度、转弯区梯度、转弯高度、KK'-DER、IAS、坡度、温度、风速。

定点转弯包含：TP-DER、最早 TP（KK' 相对 TP）、最晚 TP（C 相对 TP）、参考高度、计算高度、直线段二次检查。TP、KK'、C 由用户在跑道延长线上拾取。

要恢复：

- 定高转弯和定点转弯的完整条件分支；
- 转弯起始区和转弯区的几何定义；
- 最早/最晚转弯边界；
- 风螺旋/转弯参数如何进入保护区；
- DER 之前转弯分支；
- 直线段二次检查实际检查什么；
- 障碍物属于哪个区时使用什么评价方法；
- 直线保护区与转弯保护区如何连接、相交、裁剪或取包络；
- 代码中是否存在固定数值、经验修正、简化逻辑。

PBN Departure 也要与传统 Departure 对照，恢复其定高转弯与 FlyOver-DF 定点转弯的区别及共享代码。

### 3.5 基础计算不能只抄帮助公式

帮助公开了 FAF、非精密 SOC、精密 SOC、复飞 TP、离场 TP、C 容差等公式。必须在代码中找到真正实现位置，确认：

- 单位换算；
- IAS→TAS；
- 温度/高度修正；
- 风的取法；
- 航空器类别；
- HLm/HLr/HL correction；
- 边界条件和输入校验；
- 是否被其它模块直接复用。

## 4. 文档与配置中的异常，必须解释

不要忽略以下不一致：

1. 帮助维护 README 声称有 20 个窗口，并列出 `FormMSD`；实际帮助目录只有 19 个功能 HTML 页面，`FormMSD.html` 不存在，帮助首页命令表也没有该功能，但 `images/FormMSD.png` 存在。检查 DLL 中是否存在 FormMSD、相关类、命令或遗留代码。
2. `config.xml` 出现帮助首页没有公开的节点/窗体名称，包括 `FormRouteCheck`、`FormOasEvl`、`FormPaoasEvl`、`FormAn14Evl`、`FormAn14Next2` 等。判断它们是 WindSpiralBasic 内部隐藏/遗留功能、其它工具共用配置，还是历史版本残留。
3. 帮助页面使用 `FormDepartureEvl`，而 config 节点为 `FormDeparture`；类似类名差异要建立映射，不要按名称直接假设。
4. 帮助内容可能由后期人工编写，需用 DLL、config、运行行为三方校验。

## 5. 逆向技术要求

### 5.1 静态反编译

优先尝试多种 .NET 反编译路径并保存结果：

- ILSpy / ilspycmd
- dnSpyEx
- dotPeek
- ildasm / IL 层导出
- 可用的 de4dot / unpack/deobfuscation 方法

输出三个层级：

- `original/` 原始文件及 hash
- `deobfuscated/` 去混淆后的程序集和处理日志
- `recovered-src/` 反编译 C# 项目

如果程序集受保护导致方法体异常、空白、无效控制流，不允许停止在“无法反编译”。继续检查 IL、资源、元数据、异常处理表、字符串解密函数、运行时生成代码和可能的动态解包方式。

### 5.2 动态分析

如果静态恢复不完整，可在合法可控环境中：

- 加载插件并记录命令入口；
- 设置断点追踪按钮事件；
- 记录 AutoCAD API 调用；
- 记录重要方法输入输出；
- 追踪字符串/数值解密；
- 必要时对运行时程序集或方法体进行 dump。

动态结论必须和静态证据分开标注。

### 5.3 UI 事件级恢复

每个 Form 必须建立：

`控件 → 事件 → 方法 → 数据 → 几何/计算 → CAD输出`

特别追踪：

- ComboBox/RadioButton/CheckBox 改变后启用了什么业务分支；
- TextChanged 是否触发实时计算；
- CAD 拾取按钮调用什么 Editor API；
- “计算”“CAD”“一键评估”“标记”“包络线”等按钮分别做什么；
- Load/Save 是否序列化完整程序参数；
- config.xml 是怎样按控件树保存/加载状态的。

### 5.4 CAD API 专项追踪

建立所有 AutoCAD API 的用途清单，重点包括：

- Editor.GetPoint / GetEntity / GetSelection
- Transaction / BlockTable / BlockReference
- Polyline / Line / Arc / Circle / Region
- IntersectWith
- Offset / Extend / Trim 等等价操作
- XData / RegApp / ResultBuffer
- UCS/WCS/坐标转换
- 图层、图块、属性文字

凡是用户必须“拾取、选择、指定方向、选择多段线”的位置，都要标为人工依赖点，并说明是否可由已有程序对象自动提供。

## 6. 保护区与衔接专项分析

这是整个逆向工作的最高优先级之一。

不要只搜索 method 名中的 Join/Connect/Merge。保护区衔接可能隐藏在：

- 两条边界求交；
- 风螺旋切线；
- 公切线；
- Offset 后取交点；
- Polyline 节点重排；
- Trim/Extend；
- 多边形 union/intersection；
- 取包络；
- 删除内部线；
- 主区/副区边界渐变；
- 前后半宽不同的过渡；
- KK'/NN'/ATT 定义的纵向限制线。

对每个衔接案例输出：

- 前一航段类型
- 后一航段类型
- 输入参数
- 限制线/定位容差
- 几何对象
- 相交/切线/裁剪步骤
- 最终主区边界
- 最终副区边界
- 障碍物评价区划分
- 对应规范逻辑
- 需要人工介入的位置

至少覆盖：

- 传统直线→转弯离场
- 指定高度转弯
- 指定点转弯
- 传统复飞直线→转弯
- Fly-by 前后保护区宽度相同/不同
- Fly-over→DF
- 主副区直线航段
- DME 弧与相邻航段
- RNP APCH 中间/最后/复飞段连接
- PBN-ILS 复飞区

## 7. 障碍物评估专项分析

恢复统一障碍物对象的数据来源和字段：名称、X/Y/Z、经纬度、标高、图块属性等。

对每个评估模块恢复：

- 如何判断障碍物位于保护区内；
- 如何判断主区/副区；
- 如何计算横向比例；
- MOC/OCA/PDG/穿透值的公式；
- 如何识别控制障碍物；
- “一键评估”具体调用链；
- “直线段二次检查”具体逻辑；
- 列表点击后 CAD 高亮/居中的实现。

## 8. OAS / SQLite 专项

分析 `oas.db`：

- 完整 schema、索引、记录数、字段意义；
- PartA/PartB 的关系；
- 查询条件如何由 GP、类别、复飞梯度等参数构成；
- DLL 中所有 SQL 语句和数据库访问方法；
- OAS 参数是查表、插值还是计算；
- `WsOasPara.exe` / PANS-OPS-OAS 工具与 WindSpiralBasic 是否使用相同数据模型。

## 9. 与现行规范的映射方式

项目提供的《航空器运行目视和仪表飞行程序设计规范》作为对照依据。

对恢复出的每个重要算法建立：

`代码位置 → 软件功能 → 计算/几何含义 → 对应规范章节/条款 → 实现完整度 → 是否存在简化/疑点`

不要因为数值看起来熟悉就直接声称对应某条规范。只有确认后再标注；不确定的写 `待确认`。

## 10. 必须输出的目录与报告

建议建立：

```text
reverse-analysis/
├── 00_manifest/
│   ├── file_inventory.md
│   ├── hashes.csv
│   └── evidence_index.md
├── 01_original/
├── 02_deobfuscated/
├── 03_recovered-src/
├── 04_type-map/
│   ├── forms.md
│   ├── controls-events.md
│   └── shared-components.md
├── 05_callgraph/
│   ├── global-callgraph.md
│   ├── command-entrypoints.md
│   └── per-module/
├── 06_algorithms/
│   ├── turn-parameters.md
│   ├── wind-spiral.md
│   ├── fix-tolerance.md
│   ├── oas.md
│   └── obstacle-evaluation.md
├── 07_procedure-logic/
│   ├── conventional-departure.md
│   ├── missed-approach.md
│   ├── conventional-approach.md
│   ├── holding-procedure-turn.md
│   ├── pbn-departure.md
│   └── rnp-approach.md
├── 08_protection-area/
│   ├── geometry-primitives.md
│   ├── joining-rules.md
│   └── case-studies/
├── 09_cad-interactions/
│   ├── manual-picks.md
│   ├── xdata-schema.md
│   └── drawing-output.md
├── 10_spec-mapping/
│   └── code-to-spec-matrix.md
├── 11_automation-opportunities/
│   └── human-vs-automatable.md
└── 12_unknowns/
    ├── unresolved-methods.md
    ├── documentation-mismatches.md
    └── hypotheses.md
```

## 11. 报告质量要求

禁止使用以下低价值结论：

- “FormDeparture 用于离场评估。”
- “WindSpiral 用于计算风螺旋。”
- “用户输入参数后生成保护区。”

这类内容帮助文件已经有了，不能算逆向成果。

一个合格结论应接近：

> 在指定点转弯分支中，UI 通过三个 CAD 拾取事件分别得到 TP、KK'、C；转换到跑道局部坐标后形成 TP-DER、KK'-TP、C-TP 三个纵向参数。保护区生成函数以最早 TP 作为外侧风螺旋起始约束，并以最晚 TP 叠加反应/建立坡度延迟构造另一边界；随后与初始离场边界求交并重建多段线。障碍物评估先判断点是否在直线起始区或转弯区，再采用不同的 PDG/MOC 公式。若 `checkBoxSecChk` 为真则重新对直线区执行一次穿透测试。

即使最终发现实际代码与上述例子不同，也要达到这种粒度。

## 12. 证据等级

每条重要结论标注证据等级：

- A：直接来自可读反编译代码/IL
- B：由调用关系、字段使用和多处代码交叉确认
- C：动态运行验证
- D：由帮助/config/行为推断，尚未代码确认
- E：仅为待验证假设

不得把 D/E 级推断写成已恢复源码事实。

## 13. 执行顺序

第一轮：完整清点 + DLL 反编译/去混淆 + 类型/命令/UI事件图。

第二轮：只深挖 5 条基础链：

1. WindSpiral
2. Basic Calculation
3. FixTolerance
4. Conventional Departure
5. FlyBy / FlyOver

第三轮：恢复保护区衔接和障碍物评价公共算法。

第四轮：扩展到 Missed Approach、Primary/Secondary、DME Arc、RNP APCH、PBN-ILS、PBN Departure、传统模板。

第五轮：代码与规范映射，形成“人工判断—自动计算—可进一步自动化”的分析结果。

不要在逆向结果尚未稳定前开始重构新软件。
