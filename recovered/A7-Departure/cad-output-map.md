# A7 CAD、事件与人工桥接

所有事件原/处理token、RVA及直接callee见event-map.md；无业务L3。

| 功能 | 处理token | 实际行为 |
|---|---|---|
| DER / THR | 27E / 27F | GetPoint，XY Round2，Z不Round，取消Origin仍回填 |
| swap | 292 | 交换两组XYZ文本 |
| 坐标转换 | 280 | ScreenData当前列表逐点局部XY，保留原Z |
| 定高“计算” | 285/286 | 高度/PDG TextChanged反算站距；无独立计算Click绑定 |
| 定点“计算” | 28F | 空体 |
| 全向“计算”button15 | 无Click | 只有帮助/悬停事件；CAD/评价入口实际构造模型 |
| 定高CAD | 283 | 两或三Polyline→Group，bulge0，Z0 |
| 定点CAD | 28C | 四Polyline→Group，重叠保留，Z0 |
| 全向CAD | 290 | 两或三Polyline→Group + 外Circle；Radius字符串写WsObject XData，不生成Radius文字实体 |
| KML | 284 | 载入并另存模板，未写几何 |
| Screen | 279及276/277/278代理 | 复用Round1公共链 |
| Mark | 293，三按钮共用 | 按ID回查原点，插obst块并写Altitude；不写Name |
| 高亮 | 27C | 绑定CellClick，取消全部高亮后按ID找点、移动视图 |
| 旧高亮方法 | 27D | 有体，按XYZ容差找点；未发现事件绑定，不能当活动链 |

## 人工交互登记

TP/KK/C提示让人判断业务点，软件只取得坐标。A2/A3已能产生位置，但A7不读其XData、不选择实体，缺少保存对象身份及前序输入的直接关联，因而依靠人从图上拾取。拾取结果成为无符号距离并进入起始区构造及评价；若外层保存前序计算数据，可以自动推导候选位置，此为自动化可行性分析，不是旧软件已有功能。

DER/THR同样没有从跑道实体识别或自动选取的代码。ScreenData为SelectAll DBPoint，不逐点手选。Mark选择表格行；高亮从表格ID找到原对象，不重新GetEntity。

此链没有IntersectWith、Offset、切线、包络、裁剪、延伸或删除重建已有保护区。已代码化的是共享顶点和镜像/旋转/平移；连接后续保护区尚无入口与调用证据。设计人员可在CAD手动处理，但本轮没有运行行为证明具体手工步骤，不能把“无代码”升级为已观察到某种操作。
