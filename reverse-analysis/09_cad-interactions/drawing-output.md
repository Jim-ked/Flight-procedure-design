# CAD 输出索引边界

cad-il-sites.csv 包含 AutoCAD MemberRef 位置；geometry-il-sites.csv 为宽匹配几何候选，包括 Intersect/Offset/Polyline/Arc/Region/Erase/Explode/Trim/Extend 等。它可能包含 String.Trim 等非几何命中，不得将候选总数作为保护区算法数。

源候选定位见 source-candidate-sites.csv，字段读写另见 05_callgraph/field-accesses.csv。必须继续确认事务、坐标系、实体所有权、图层、XData、重建/删除、失败路径。当前离场已连到共享 CAD 输出 helper，但未证明输出多段线闭合、无自交或规范正确。

原始 WsSymbol2.1.dwg 已保留hash与快照，块/层/属性尚未提取；没有通过运行未知CAD插件来弥补这一缺口。
