# 拾点、输入坐标与人工依赖

P2F9先SetFocus、隐藏窗体，P113提示“请输入保护区起点”得到S，再提示“请指定保护区终点”得到E。任一点等于完整三维Origin时恢复Visible并退出；Origin是真实坐标也被当取消哨兵。P113本身GetPoint遇错误重试、取消返回Origin。

S为施加所选设施起始半宽的窄端，通常可作为设施位置；**代码只称保护区起点，没有验证它是导航台**。E为指定保护区另一端，既确定方向又决定长度/15°起点，不能称仅方向点。没有台站ID、设施数据库、航迹实体或统一procedure对象。

```text
L = sqrt((Sx-Ex)^2+(Sy-Ey)^2)
theta = atan2(Sy-Ey,Sx-Ex)       // E→S反向角
u=(E-S)/L, n=(-u.y,u.x)        // 仅用于说明；原代码不除L
alpha = Parse(ExpAng.Text)*PI/180
w = Parse((W1.Checked?W1.Text:W2.Text).Trim().Split('n')[0])*1852
```

原实现直接以世界XY的S/E加极坐标位移；不把设施平移到局部原点再旋转回去。计算过`3π/2−theta`并一次规范化，但该bearing局部变量后续不消费。左右相对**拾点S→E**定义：Left在正n，Right在负n；若航空器按E→S向台飞行，其飞行视角左右与该绘图向量左右相反，不能混称。

Z不用于长度、角度、线系数：数值S/E及位移相加保留端点Z；15°求交产生新点Z=0。CAD最终Point2d忽略所有Z。没有高度保护面/超障计算。

## 人工交互及自动化可能（N层建议，非已实现）

|API/入口|业务对象|为什么由用户提供|消费者|已有数据能否推导|
|---|---|---|---|---|
|P113第一次GetPoint|窄端/设施位置候选S|无台站注册/ID/检索；仅点|所有起始偏移、L、theta|若已有设施坐标可代入；当前窗体无该关联|
|P113第二次GetPoint|航迹另一端/连接点E|无航段对象或设计终点规则|L、theta、远端宽度、15°两条线起点|若已有明确航段终点可代入；只知道方向不能唯一决定L|
|checkbox/radio|左右/中心/15°、半宽档位|由设计人员选择构造范围和参数|P2F9分支/文本读取|可由程序阶段/目标输出指定；原代码没有阶段自动判定|

没有GetEntity/GetSelection、自动拾取既有保护边、剪裁CAD实体或选前后窗口对象。设计人员可借输出作后续构造，帮助提示可用于转弯后飞向导航台；但代码没有自动求风螺旋切点、判断内外、包络或删除/重建已有图元。无法仅据静态缺失指定完整手工操作步骤。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
|P113|0x06000114 / 0xCB28|0xD220|5236|[证据](evidence/processed/0x06000113.il.txt)|
|P125|0x06000126 / 0x10A84|0x31C1|150|[证据](evidence/processed/0x06000125.il.txt)|
|P809|0x0600080A / 0xC901C|0x6191|84269|[证据](evidence/processed/0x06000809.il.txt)|
|P80A|0x0600080B / 0xC903C|0x61A9|84274|[证据](evidence/processed/0x0600080A.il.txt)|
