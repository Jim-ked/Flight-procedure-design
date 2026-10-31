# 公共障碍物入口与两套评价记录

button3/P476→公共泛型SelectAll P10D<DBPoint>（MethodSpec 2B00000D），读取ModelSpace POINT；未见Take(5)。P477对全列表解析名称/XYZ并以递增ID建立DBPoint字典。P478 foreach全列表，保留原Z仅转换X/Y，写P4B2的12列表；没有评价。

button18/P48C按当前选中行ID反查原DBPoint，公共Mark P09C→obst块与P09E Altitude=原DBPoint.Z。P484绑定CellClick及CellContentClick，先取消全列表高亮，再高亮ID对象；无视图居中调用。

LNAV与APV的记录类型互相独立，无统一最危险结果集合；两主评价器都是孤立方法。单个APV内部比较两候选副面，不是外层final+missed+APV merge。无max OCA/max required gradient、去重、多行优先或排序实现。详情分别见lnav-obstacle-evaluation.md、apv-obstacle-evaluation.md。
