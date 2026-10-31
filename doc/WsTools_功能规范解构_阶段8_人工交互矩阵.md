# WsTools 功能—规范—算法解构（阶段8）
## 全功能人工交互矩阵与动态逆向靶标

本阶段不再按航空业务模块展开，而是重新扫描 `WindSpiral2026/帮助文件`、界面截图、`config.xml` 和 DLL 中可见的 AutoCAD API 名称，把 WsTools 的所有公开功能按“人怎样给软件输入数据、软件怎样回写 CAD”分类。

这一步的目的，是把后续 Codex 的动态逆向从“盲目找事件”收缩为少量明确的 CAD API 验证题。

---

## 1. 证据说明

本文区分四种证据：

- H：帮助 HTML 明确说明。
- S：界面截图直接可见。
- C：`config.xml` 中存在对应控件/状态。
- D：原 DLL 静态字符串中确认存在对应 AutoCAD API 名称，但尚未证明某一具体窗口调用。

DLL 已确认包含这些 API/类型名称：

`GetPoint`  
`GetEntity`  
`GetSelection`  
`PromptPointOptions / PromptPointResult`  
`PromptEntityOptions / PromptEntityResult`  
`PromptSelectionOptions / PromptSelectionResult`  
`AppendEntity`  
`DBPoint`  
`Polyline / Polyline3d`  
`BlockReference / AttributeReference`  
`GetOffsetCurves`  
`GetXDataForApplication`  
`get_XData / set_XData`  
`ResultBuffer`  
`RegAppTable / RegAppTableRecord`

因此后面的“预计 API”不是说已证明调用关系，只是给动态逆向限定靶标。

---

# 2. 交互类型编码

为方便后续动态记录，统一定义：

| 编码 | 人机动作 | 预计 AutoCAD API |
|---|---|---|
| P | 拾取一个坐标点 | `Editor.GetPoint` |
| Pn | 按顺序拾取多个点 | 多次 `Editor.GetPoint` |
| E | 选择一个已有实体 | `Editor.GetEntity` |
| M | 批量选择多个已有实体 | `Editor.GetSelection` |
| O | 向图纸创建实体 | `AppendEntity` 等 |
| B | 障碍物批量读取 | `GetSelection` 或等价 SelectionFilter |
| X | 读取/写入扩展数据 | `XData / ResultBuffer` |
| F | 文件输入/输出 | FileDialog / Stream / XML / TXT / KML 等 |
| D | 仅数值/枚举输入 | WinForms 控件，不需要 CAD 交互 |
| T | 已有图面拓扑由人工组织 | 多种 CAD 交互组合 |

---

# 3. A1—A10 人工交互矩阵

## A1 风螺旋 `Y01_风螺旋`

可确定：

- D：IAS、高度、坡度、温度、风速、转弯方向、起止角、DA、线条类型。
- P/Pn：单/双/三螺旋绘图时指定位置；标称航迹明确要求“起点、转弯点、转弯终点”。
- O：Polyline/Spline、基圆、起点线、终点线、公切线、标称轨迹等。

预计动态靶标：

`GetPoint → wind spiral geometry → AppendEntity`

标称航迹应重点验证是否严格为三次 `GetPoint`。

证据：H/S/D。

---

## A2 飞行程序基础计算 `Y02_基础计算`

六个页签全部属于：

`D + Pn + O`

### FAF

数值输入后：
- 拾取绘制基准点；
- 拾取/指定方向；
- 绘制 IF/FAF/THR 相关施工几何。

### 非精密 SOC

明确：
- 拾取 MAPt 定位容差最晚点；
- 拾取复飞方向；
- 绘制 SOC。

### 精密 SOC

明确：
- 拾取 THR；
- 拾取复飞方向；
- 绘制 SOC。

### 复飞 TP

明确：
- 拾取 SOC；
- 拾取复飞方向；
- 绘制 TP。

### 离场 TP

明确：
- 拾取 DER；
- 拾取离场方向；
- 绘制 TP。

### C 容差

明确：
- 拾取转弯最晚点；
- 拾取飞行方向；
- 绘制 C 容差施工线。

因此 A2 是目前最明确的“坐标施工几何生成器”。

预计 API：

`GetPoint × 2 → Line/Point/Text/Polyline → AppendEntity`

关键验证：
- 每页具体新增哪些实体；
- 是否有 DBPoint；
- 是否只是 Line + Text；
- 是否写 XData。

证据：H/S/D。

---

## A3 定位容差 `Y03_定位容差`

可确定：

- D：导航设备类型、精度、DME 距离、航迹引导开关。
- O：定位容差区、航迹线、KK线、航迹容差、顶空盲区。

帮助没有明确列出 CAD 绘制时的拾取顺序，因此：

- P/Pn：高度可能，但具体次数暂不判定。
- O：明确。

重点动态问题：

1. CAD 后第一次是什么 `GetPoint`；
2. 是否要求台址、定位点、航迹方向；
3. KK线是否单独作为 Line/Polyline 创建；
4. 是否写 XData。

证据：H/S/D；P 次数未知。

---

## A4 非精密进近保护区 `Y04_导航设备保护区`

可确定：

- D：VOR/NDB、初始半宽、扩张角、左右半区、中心线、15°线。
- P/Pn：帮助明确 CAD 后“按提示拾取绘制保护区”，但未写清点数。
- O：梯形/扇形保护区边界、中心线、15°辅助线。

预计：
- 至少需要保护区基准点和航迹方向；
- 大概率为连续 `GetPoint` 而非实体选择。

代码验证：
- 1 NM / 2 NM 如何进入；
- 7.8°/10.3°是否自动设置；
- 15°线是否独立方法。

证据：H/S/D。

---

## A5 精密进近保护区 `Y05_精密进近保护区`

可确定：

- P：跑道入口、跑道末端截图均有坐标拾取按钮。
- D：FAF高度、FAF容差、中间段长度、机型、RDH、GP、LOC距离、OAS系数等。
- F：OAS参数导入/导出。
- O：GP INOP、PAOAS左/右、OAS、PA with FAF、PA with FAP。

这里存在两个不同层次的复用：

1. 跑道几何通过坐标拾取；
2. OAS 参数通过文件/控件复用。

尚无帮助证据说明 A5 需要选择已有 OAS 实体。

预计 API：

`GetPoint(THR) + GetPoint(RWY End) → coordinate transform → OAS/PA geometry → AppendEntity`

代码验证：
- 是否查询 `oas.db`；
- 参数导入/导出格式；
- 是否写图形 XData。

证据：H/S/C/D。

---

## A6 传统保护区模板 `Y06_传统模板`

该模块同时存在两种完全不同的交互。

### 普通模板绘制

- D：IAS、高度、坡度、风、时间、导航台、出航距离等。
- P：按需拾取模板基点/方向。
- O：等待、Base Turn、45/180、80/260 模板。

### 包络线

帮助明确：

“选择图中已绘制的多条模板多段线，合并生成包络保护区。”

这是全帮助体系中最明确的“已有程序几何实体作为算法输入”。

因此包络功能应优先验证：

`GetSelection`
→ 过滤 `Polyline`
→ 读取顶点/曲线
→ 相交/包络
→ 新 Polyline
→ `AppendEntity`

这与 TP/KK/C 的坐标拾取性质完全不同。

证据：H/S/D，非常高价值。

---

## A7 离场越障评估 `Y07_离场保护区`

这是交互类型最丰富的窗口。

### 跑道

- P：DER。
- P：THR。
- P：转弯结束点，`config.xml` 有 `textBoxTurnEndX/Y`。
- D：标高、梯度、转弯参数等。

### 定点转弯

- P：TP。
- P：KK′。
- P：C。

帮助明确说三点“在跑道延长线上拾取”，然后计算相对距离。

当前最高概率：

`GetPoint`
而不是
`GetEntity`

### 障碍物

- B：屏幕数据“拾取当前屏幕中的所有点实体”。
- 内部读取名称、坐标、高度。
- 标记时 O：插入带高度属性的图块。

因此 A7 至少有两条完全不同的 CAD 数据入口：

`GetPoint → 程序几何参数`

和：

`GetSelection → 障碍物实体 → 业务属性`

动态观察必须分开记录。

证据：H/S/C/D。

---

## A8 复飞转弯区评估 `Y08_转弯区评估`

- P：KK′左端点。
- P：KK′右端点。
- D：Ds、PDG、MOC、复飞梯度、转弯方式。
- B：障碍物屏幕数据。
- O：障碍物标记。

没有帮助证据表明 A8 自己画完整转弯保护区。

所以优先验证：

`GetPoint(KK-L)`
`GetPoint(KK-R)`
与
`GetSelection(obstacles)`

是否严格独立。

若是，则进一步支持“A8只是评价器”的定位。

证据：H/S/D。

---

## A9 主副区评估 `Y09_主副区评估`

截图非常明确：

- P：起点坐标。
- P：终点坐标。
- D：起点半宽、起点MOC、终点半宽、终点MOC。
- B：屏幕数据。
- O：CAD 绘制主副区。
- O：障碍物标记。

注意：

A9 帮助中“屏幕数据”一词同时用于障碍物，起终点本身又有独立小型拾取按钮。

因此不应把帮助页中的“屏幕数据拾取起终点”理解成同一个按钮。

预计内部至少是：

`GetPoint(start)`
`GetPoint(end)`
`GetSelection(obstacles)`

三条不同事件。

证据：H/S/C/D。

---

## A10 起始进近 DME 弧 `Y10_起始进近DME弧`

截图进一步确认：

- P：导航台位置，小型拾取按钮。
- P：IF位置，小型拾取按钮。
- P：IAF方向，小型拾取按钮。
- B：大按钮“屏幕数据”用于障碍物。
- D：呼号、MOC、距离标注开关。
- O：DME弧保护区。
- O：障碍物标记。

所以 A10 的三项程序条件和障碍物载入是两套交互。

核心动态靶标：

`GetPoint(O)`
`GetPoint(IF)`
`GetPoint(direction reference)`
→ DME geometry

以及：

`GetSelection(obstacle points)`
→ obstacle evaluation

这也进一步削弱“A10自动读取已有 FAF 实体”的可能性。

证据：H/S/D。

---

# 4. B1—B5 人工交互矩阵

## B1 Fly-by `Y51_FlyBy`

- D：IAS、高度、坡度、风、ATT、反应时间、建坡时间、前后航段半宽。
- Pn：帮助明确 CAD 时依次指定：
  1. 转弯起点；
  2. 转弯点；
  3. 转弯终点。
- O：标称航迹、容差、主副区、NN′/KK′、风螺旋等。

预计：

`GetPoint × 3`

这是非常适合作为 GetPoint 动态验证基准样本的功能。

证据：H/S/C/D。

---

## B2 Fly-over DF `Y52_FlyOver`

截图直接提示：

“请依次输入三点进行绘制”。

因此：

- D：ATT、半宽、反应时间、建立坡度时间等。
- Pn：3 个点。
- O：主区、副区、标称航迹、容差、辅助线。

三个点的业务语义需要代码/运行最终确定，但第三点很可能就是 DF 后续定位点。

预计：

`GetPoint × 3`

证据：H/S/C/D。

---

## B3 RNP APCH `Y53_RNP_APCH`

跑道数据页截图：

- P：入口坐标。
- P：末端坐标。
- B：屏幕数据障碍物。
- O：CAD 保护区。
- O：标记。
- D：程序参数、LNAV复飞、APV复飞、附加设置。

帮助还提到加载/保存，但当前截图未显示完整按钮位置；应作为 F 类验证。

最重要的是：

B3 没有帮助证据说明设计人员要选择“已有 FAF/TP/保护区实体”。

更可能是：
- 跑道位置通过坐标；
- 其他程序参数通过数值；
- 障碍物通过实体批量读取。

证据：H/S/C/D。

---

## B4 PBN-ILS `Y54_PBN_ILS`

截图结构与 B3 高度一致：

- P：入口坐标。
- P：末端坐标。
- B：屏幕数据障碍物。
- D：OAS、HL、FAF高度、DH等。
- O：CAD。
- O：标记。
- F：KML；帮助还提到加载/保存。

这使 B4 很适合与 B3 比较是否复用统一：
- runway coordinate picker；
- obstacle screen loader；
- coordinate transform；
- marker insertion。

证据：H/S/C/D。

---

## B5 PBN Departure `Y55_PBN_Departure`

截图显示跑道页至少有：

- P：DER。
- P：THR。
- P：转弯结束点。
- D：转弯方向，可自动计算。
- B：评价流程中障碍物载入。
- O：CAD。
- O：标记。

这与 A7 跑道页结构高度相似。

因此动态逆向时应优先比较 A7 与 B5 的三组小型拾取按钮是否调用相同公共方法。

如果调用栈重合，可直接恢复一套公共 runway/turn-end 输入组件。

证据：H/S/D。

---

# 5. C1—C4 辅助功能

本轮可以正式确认帮助中心确有 C1—C4，不再作为未验证编号。

## C1 `Y90_LoadBlock`

- F：打开外部 DWG。
- E/M：不是图面实体选择，而是 WinForms 列表选择图块定义。
- O：将 BlockTableRecord/块定义导入当前数据库。

重点不是 `GetSelection`，而是数据库层面的跨 DWG 克隆/复制。

---

## C2 `Y91_CreateLayer`

- F：加载/保存文本图层清单。
- D：文本配置。
- O：创建 LayerTableRecord。

无图面拾取。

这是最纯粹的数据库操作基准样本。

---

## C3 `exline`

- D：扩张角、长度、是否中心线。
- P/Pn：帮助明确至少拾取起点；方向还需要运行确认。
- O：外扩线与可选中心线。

非常适合验证简单的：
`GetPoint → Line → AppendEntity`

---

## C4 `Y92_RandomPoint`

- D：高度范围、文字高度、半径、数量、名称/高度显示。
- P：中心点。
- O：随机障碍物点。
- O：文字标注。
- X：高度/名称业务数据是否写 XData，是当前首要验证问题。

这是最适合打通障碍物数据链的入口。

---

# 6. 无窗口命令

帮助首页确认：

## `RCL`

“拾取跑道入口与末端，向两端各延伸 40 km 中心线。”

- Pn：2 点。
- O：Line。

应成为最简单的双 `GetPoint` 基准命令。

## `NMCIRCLE`

“指定圆心后连续输入半径（nm）绘制带标注的圆。”

- P：圆心。
- D：半径。
- O：Circle + Text。

## `rectLine`

“指定宽度与起终点，绘制闭合矩形框。”

- Pn：起点、终点。
- D：宽度。
- O：Polyline。

## `Arc2`

“指定圆心与圆弧点，绘制左右30°圆弧。”

- Pn：圆心、弧上点。
- O：Arc。

## `xInfo`

“选择实体，在命令行按层级展开输出 XData（JSON）。”

这是帮助体系中最明确的单实体语义读取：

- E：实体选择。
- X：读取 XData。
- 不创建几何。

预计：

`GetEntity`
→ `Entity.XData / GetXDataForApplication`
→ JSON serializer
→ Editor.WriteMessage`

这个命令应该成为 XData 逆向的第一入口之一。

---

# 7. 交互矩阵总表

| 功能 | 数值 D | 点拾取 P | 单实体 E | 多实体 M/B | 文件 F | CAD输出 O | 当前最重要验证 |
|---|---:|---:|---:|---:|---:|---:|---|
| A1 风螺旋 | 是 | 是 | - | - | - | 是 | 各绘制按钮的点数 |
| A2 基础计算 | 是 | 强 | - | - | - | 强 | 施工实体类型/XData |
| A3 定位容差 | 是 | 待定 | - | - | - | 强 | CAD输入顺序 |
| A4 VOR/NDB | 是 | 是 | - | - | - | 强 | 基准点/方向 |
| A5 精密进近 | 是 | 强 | - | - | 是 | 强 | OAS参数来源 |
| A6 传统模板 | 是 | 是 | - | **强** | - | 强 | 包络Polyline选择 |
| A7 离场 | 是 | **强** | - | **障碍物强** | - | 强 | GetPoint vs Selection |
| A8 转弯区评估 | 是 | 强 | - | **障碍物强** | - | 标记 | 是否完全无保护区绘制 |
| A9 主副区 | 是 | 强 | - | **障碍物强** | - | 强 | 起终点与障碍物两通道 |
| A10 DME弧 | 是 | **强** | - | **障碍物强** | - | 强 | 三点构造 + 障碍物 |
| B1 Fly-by | 是 | **3点** | - | - | - | 强 | 顺序三点 |
| B2 Fly-over DF | 是 | **3点** | - | - | - | 强 | 三点语义 |
| B3 RNP APCH | 是 | 跑道2点 | - | 障碍物 | 可能 | 强 | 与B4共享输入组件 |
| B4 PBN-ILS | 是 | 跑道2点 | - | 障碍物 | KML/可能保存 | 强 | OAS与障碍物链 |
| B5 PBN离场 | 是 | DER/THR/终点 | - | 障碍物 | - | 强 | 与A7复用 |
| C1 图块导入 | 是 | - | - | - | 强 | DB写入 | DWG块复制 |
| C2 图层 | 是 | - | - | - | 强 | DB写入 | LayerTable |
| C3 exline | 是 | 是 | - | - | - | 强 | 起点/方向点数 |
| C4 RandomPoint | 是 | 中心点 | - | - | - | 强 | XData |
| RCL | - | 2点 | - | - | - | 强 | 最简单GetPoint基准 |
| NMCIRCLE | 是 | 1点 | - | - | - | 强 | Circle/标注 |
| rectLine | 是 | 2点 | - | - | - | 强 | Polyline |
| Arc2 | - | 2点 | - | - | - | 强 | Arc |
| xInfo | - | - | **强** | - | - | - | XData schema |

---

# 8. 当前可以下的架构结论

## 8.1 “程序几何”主要靠 Point3d 传入

从帮助和截图看，大多数程序设计条件不是选择已有实体，而是：
- 点击小型拾取按钮；
- 取得一个坐标；
- 填入 X/Y/Z 文本框；
- 后续按坐标计算。

典型：
- DER；
- THR；
- TP；
- KK′；
- C；
- IF；
- IAF方向；
- runway end；
- turn end。

所以“前序模块复用”目前更准确地说是：

**图面施工结果被人重新拾取成坐标。**

## 8.2 真正实体级几何复用目前最明确的是 A6 包络

A6 明确选择多条已绘 Polyline。

这是真正应该追：
`GetSelection → entity geometry → envelope`
的地方。

不能把这种实体复用模式套到 A7 的 TP/KK/C 上。

## 8.3 真正实体级业务数据复用最明确的是障碍物

评价窗口反复使用“屏幕数据”，且明确称障碍物为点实体。

所以障碍物数据链应优先追：
`Selection → DBPoint/Block → XData/Attributes → Obstacle object`

## 8.4 `xInfo` 是独立的语义探针

`xInfo` 可以直接暴露 XData JSON。

如果本机运行 WsTools 时：
1. 用 C4 创建随机障碍物；
2. 对随机点运行 xInfo；
3. 再对 A2 生成的 TP/FAF/C 运行 xInfo；
4. 再对 A3 KK线运行 xInfo；
5. 再对 A7/A10 最终保护区运行 xInfo；

就能很快区分：

- 哪些实体只是普通几何；
- 哪些实体带业务语义；
- 不同类型使用什么 RegApp/XData schema。

这项实验的价值非常高，而且不需要懂复杂业务操作。

---

# 9. 推荐的最小 AutoCAD 实验序列

现在不需要一上来跑完整离场。

应先做一组“低业务难度、最大信息量”的实验。

## Run 1：RCL

输入两个点。

记录：
- 两次 Point；
- 新增实体类型；
- Layer；
- 长度；
- XData。

目的：
建立 Observer / Debugger 基线。

## Run 2：C4 RandomPoint

生成 1 个随机点，勾选名称和高度。

记录：
- DBPoint / BlockReference / Text；
- XData；
- ExtensionDictionary；
- 同一障碍物到底由几个实体组成。

随后立即运行 `xInfo`。

这是最关键的 XData 实验。

## Run 3：A2 C容差

使用简单数值，绘制一条 C 容差。

记录：
- 输入两次 Point 还是一次 Point + direction；
- 产生 Line / Point / Text；
- 对这些实体运行 xInfo。

## Run 4：A2 离场TP

从一个 DER 沿方向画 TP。

同样记录新增实体，并 xInfo。

## Run 5：A3 定位容差

先只勾选 KK线/航迹线，尽量减少输出。

记录：
- 需要几次拾取；
- KK线实体类型；
- xInfo。

## Run 6：A7 定点转弯，只做三次拾取

不必先完成复杂越障。

只观察：
- TP按钮；
- KK′按钮；
- C按钮。

分别确认调用：
- GetPoint？
- GetEntity？
- GetSelection？

如果三个都是 GetPoint，则跨模块工作方式基本可以正式定性。

## Run 7：A6 包络线

预先人工画三条简单 Polyline，再执行包络。

这次应观察明显的 Selection 行为。

与 A7 的 TP拾取做对照。

---

# 10. 给 Codex 的动态任务现在可以缩成 API 级

不再发：

“逆向所有 CAD 交互”。

而发：

### 任务组 P：坐标拾取

定位并验证：
- RCL 两次 GetPoint；
- A2 C容差；
- A2 离场TP；
- A7 TP/KK/C；
- A10 O/IF/IAF；
- B1/B2 三点输入。

输出每个调用点：
- MethodDef token；
- RVA；
- 调用栈；
- PromptPointOptions.Message；
- 返回 Point3d 去向。

### 任务组 S：实体/选择集

只追：
- A6 包络；
- 各窗口屏幕数据；
- xInfo。

输出：
- GetEntity / GetSelection；
- SelectionFilter；
- 允许的 DXF 类型；
- Entity 类型；
- XData读取函数。

### 任务组 O：实体输出

只追：
- AppendEntity；
- DBPoint；
- Line；
- Polyline；
- Arc；
- Circle；
- BlockReference；
- AttributeReference。

要求把调用栈反向映射到具体功能。

### 任务组 X：XData

优先：
1. RandomPoint；
2. xInfo；
3. ScreenData；
4. Marker。

最后才检查：
- A2施工点；
- A3 KK线；
- 最终保护区。

---

# 11. 还需要警惕的帮助文件问题

## FormMSD

帮助图片目录有 `FormMSD.png`，但它只是“界面截图占位图”，没有对应 HTML 功能页，也没有真实界面内容。

不能据此认定基础版公开存在 MSD 窗口。

后续只有找到：
- CommandMethod；
- Form Type；
- 事件；
- 调用关系；

才能把它纳入公开功能。

## 隐藏配置

`config.xml` 还有：
- FormRouteCheck；
- FormAn14Evl；
- FormAn14Next2；
- FormOasEvl；
- FormPaoasEvl；

其中有些可能属于项目其他模块、历史功能或未公开入口。

暂时不要与帮助中心 A/B/C 功能混在一起。

先恢复公开功能链，再处理隐藏/遗留类型。

---

# 12. 当前阶段的工作重心

至此，帮助文件已经不再只是“功能说明”。

它已经可以直接变成动态逆向测试规范：

`功能`
→ `预期人工动作`
→ `预计 CAD API`
→ `预期输入语义`
→ `预期输出实体`
→ `需要验证的代码位置`

下一阶段最有价值的事情不是继续读更多规范，而是进一步整理：

**“最小实验用例 + 预期几何结果 + Observer 应记录的字段”**

然后就可以真正开始在本机 AutoCAD 中逐个低风险实验，把静态推断转换成运行证据。
