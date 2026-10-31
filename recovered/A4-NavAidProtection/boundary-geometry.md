# 所有最终边界、符号与条件

定义S窄端、E远端，L=XY距离、u为S→E单位方向、n为其左法向，外半宽w，k=tan(alpha)，W=w+kL。局部说明坐标x沿u，不代表原实现建立了局部对象。

|点|Left|Right|Z（未求交时）|
|---|---|---|---|
|O0外边起点|S+w n|S−w n|S.Z|
|I0半宽起点|S+(w/2)n|S−(w/2)n|S.Z|
|O1外边终点|E+W n|E−W n|E.Z|
|I1半宽终点|E+(W/2)n|E−(W/2)n|E.Z|

不选15°时，每侧输出外折线[S,O0,O1]和内线[I0,I1]；没有重复S/闭环、没有终端横线、不是闭合四边形实体。外边界从S到O0为横向初始边，O0→O1为线性扩张边。内线斜率为k/2，其方向角是atan(k/2)，**不是alpha/2**。中间无弧/螺旋采样点。

选15°时，用过E与u夹角的左右斜线替换O1/I1为无限直线交点O*/I*，先新增[E,O*]，再[S,O0,O*]、[I0,I*]。它们共同形成尖端至起始边的构造线网，但没有自动区域/面/主副区对象。

左右是同一几何的符号镜像，两个独立点列分支写入同一个Group；不是两个writer。原次序Right在前、Left在后。选择单侧只产生该侧；双侧两套；都不选仍可仅中心线或空Group调用。

控制变量源映射：原obj=S、obj9=E；Right obj2/obj3=O0/O1，obj4/obj5=I0/I1；Left obj6/obj7=O0/O1，obj8/obj10=I0/I1；num2=w、num3=theta、num5=L、a=alpha弧度。完整表达式/IL与逐点fixture共同保存。

[边界符号索引](boundary-vertices.csv)、[所有表达式](evidence/geometry-expressions.csv)、[样本逐点](../round9/fixtures/geometry-points.csv)。负数、零长/大角和无限线求交不夹限，避免以规范修正“合理边界”。

## 证据等级与审计入口

E0原程序集身份/元数据；E1处理后反编译；E2 IL/调用/字段恢复；E3独立恢复源码验证；E4原插件运行，本轮无；N规范解释。Pxxx为处理后MethodDef 0x06000xxx，不能当原token；原保护桩本身不证明恢复公式。没有运行目标DLL、AutoCAD或未知EXE。

[方法身份/原处理RVA与IL哈希](evidence/method-index.csv)、[事件完整身份与callee](evidence/event-identities.csv)、[分支](evidence/branch-sites.csv)、[字段](evidence/field-flow.csv)、[控件状态](evidence/parameter-control-inventory.csv)、[表达式](evidence/geometry-expressions.csv)。完整原/处理IL在evidence/raw与processed；[Form源摘录](evidence/FormNavAids.source.txt)保留真实源行。

## 关键定位

|P|原token / RVA|处理RVA|源行|证据|
|---|---|---|---|---|
|P2F9|0x060002FA / 0x3DFF4|0x335CC|22708|[证据](evidence/processed/0x060002F9.il.txt)|
|P7E7|0x060007E8 / 0xC86A4|0x92164|83911|[证据](evidence/processed/0x060007E7.il.txt)|
|P7E8|0x060007E9 / 0xC87B0|0x92234|83976|[证据](evidence/processed/0x060007E8.il.txt)|
|P7ED|0x060007EE / 0xC8908|0x9232C|84010|[证据](evidence/processed/0x060007ED.il.txt)|
|P809|0x0600080A / 0xC901C|0x6191|84269|[证据](evidence/processed/0x06000809.il.txt)|
|P80A|0x0600080B / 0xC903C|0x61A9|84274|[证据](evidence/processed/0x0600080A.il.txt)|
