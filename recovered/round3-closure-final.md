# Round 3 Closure Pass — final

更新时间：2026-10-27。状态：**PARTIALLY ACCEPTED**。

本轮只收口 A1/B1/B2 中的 B1/B2 writer、NN′/KK′、边界顶点以及 CAD 实体顺序/Group/Text/XData。没有重新加载原 DLL，没有操作 AutoCAD，没有修改原始输入，也没有扩展到 A6、B3、B4、B5。

## 已闭合的 writer 证据

* B1 writer `_0089_0089_009A`（annotated source line 52420）的控件到参数顺序已固定：标称航迹、保护区、KK′、NN′、辅助螺旋、容差显示。writer 实际顺序为 nominal descriptor → 四条保护区 Polyline → KK′控制的单 Polyline → NN′控制的 Polyline Group → 螺旋 Group → 无 metadata 的容差 Polyline。
* B2 writer `_0089_008B_008B`（annotated source line 53453）的顺序已固定：nominal descriptor → 主区两条 Polyline → 副区两条 Polyline → 螺旋 Group → 无 metadata 的容差 Polyline。
* 共享 `_008B._0088_008A`、`_0088_008B`、`_0088_008D` 与 `_008C_008F` 的实体、事务和 Group 行为已写入 `round3/shared-cad-writers.csv`。B1/B2 writer 路径均未发现图层、颜色、线型、Text、IntersectWith、Offset、裁剪或重建图元调用。
* 非空 P9/P8 只写 `WsObject` XData 到实体子项，Group 本身不写；容差分支省略 metadata。XData 证据分别记录于 B1/B2 `xdata-schema.md`。

## 边界顶点和语义

`B1-FlyBy/boundary-vertices.csv` 与 `B2-FlyOverDF/boundary-vertices.csv` 记录了源字段、顶点表达式、分支条件和证据行。源代码有大量距离比较、15°/30°连接和风螺旋采样，因此无法把所有运行时点压成一个固定数值表；CSV 保留了每个最终列表的确定首点/尾点和分支产生的中间表达式。

NN′/KK′的 UI 名称及各自 writer 分支是直接证据。writer 没有把这些名称写入实体、XData 或障碍物评价器，所以 `BoundaryList05`、`BoundaryGroup02` 以及 B2 的主/副区列表都使用中性名称。任何“内/外”“主/副”或规范术语映射均标为**实现依据待确认**。

## 未闭合项

1. 运行时输入下每个分支的数值顶点仍需在不加载原 DLL 的条件下由独立 DTO/数学模型验证；当前已保留公式和分支证据，但未伪造为源码事实。
2. 未恢复 AutoCAD 最终图层/颜色/线型的宿主环境默认值；源 writer 没有显式设置它们。
3. C# 兼容编译仍受既有 sandbox csc PE/Win32-resource 错误阻塞，记录于 `round3/compile-tests.log`；本轮不重复尝试。

## 证据分层

* 原始程序集/IL：MethodDef、RVA、调用 token、字段读写和共享 helper。
* 去混淆/反编译：`annotated-strings/--/--.cs` 中 B1/B2 类、writer 和 CAD helper 方法体。
* 调用关系恢复：`round3/shared-turn-spiral-calls.csv`、`round3/shared-cad-writers.csv`。
* 独立恢复验证：已有 `round3/fixtures/round3-python-results.json` 的 10 项断言；本轮新增 DTO 仅承载 writer 顺序和公式，没有宣称已编译或已在 AutoCAD 中执行。
* 规范比较：AC-97-FS-005 / 民航规〔2020〕12号仅作基线，不用于修正代码。差异仍标记为实现依据待确认。
