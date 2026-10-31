# ScreenData → 评价 → Mark：已闭合的A8分支

证据L1 Direct为处理后代码；L2为对应处理后IL及原/处理方法映射。无L3。仅为本轮障碍物链追踪评价入口，不扩展到A8整窗功能。

## 事件链

`--/--.cs:12100`附近ScreenData调用SelectAll<DBPoint>，12168解析器填初始表；12402附近 `_009D_0093` 评价事件重新遍历原DBPoint列表，不从初始表显示的四舍五入坐标计算。

`_009D_008B`（12347附近）读取KK′左右边界输入，调用 `-/-.cs:3103` `_0089_008F`：基准为左点，长度为左右点平面距离，正方位为左→右，反方位为右→左。

逐障碍物调用 `-/-.cs:3116` `_0089_0090`，得到局部XY：

`distance(left,obstacle) × [cos(azimuth(left,obstacle)−azimuth(right,left)), sin(...)]`。

helper原来返回Z差，但评价事件立即把局部对象Z改回障碍物绝对Z。ID/Name保留。这个覆盖不能漏掉，否则OCA会变成相对高度。

事件构造 `_0088._0087(length,left.Z,dr,gradient/100,minimumMoc,false,modeText=="指定高度")`，再调用评价方法。评价后按minPDG降序排列，回填DataGridView；提示字符串把总数同样称为“范围内”数量，没有在这个循环过滤KK′线外对象。

## 评价器实码

`-/-.cs:95`；原0x06000003/RVA0x2164（保护桩），处理0x06000002/RVA0x710C。恢复的可执行数值代码见Obstacle.Recovered.cs `KkEvaluation`。

局部X<−length：d0=sqrt((X+length)²+Y²)；−length≤X<0：d0=abs(Y)；X≥0：d0=sqrt(X²+Y²)。所属区域只由Y<0标为“KK'线外”，否则“KK'线内”；不是任意保护区Polygon包含测试。

| variableMoc | specifiedAltitude | MOC | PDA | minPDG |
|---|---|---|---|---|
| true | true | max(.008(dr+d0),最低MOC) | d0×梯度+基准高 | (OCA−基准高)/d0 |
| true | false | 同上 | (dr+d0)×梯度+基准高+5 | (OCA−基准高−5)/(dr+d0) |
| false | true | 最低MOC | d0×梯度+基准高 | (OCA−基准高)/d0 |
| false | false | 最低MOC | (dr+d0)×梯度+基准高 | (OCA−基准高)/(dr+d0) |

所有分支OCA=障碍物Z+MOC。A8此入口固定variableMoc=false。最后一分支没有+5，不能为了规范一致性添加。无零分母保护，无自动钳制非负梯度。

结果类 `--/--.cs:41377` `_008A_0089` 继承坐标/ID/Name模型。getter映射由ToString标签和表格顺序交叉确认：009B=d0、009E=dr、008F0088=MOC、008F008B=OCA、008F008E=PDA、008F0091=minPDG。表格MOC/OCA取Round整数，PDA两位小数，minPDG×100后保留1位。

## Mark与边界

12310附近Mark仍从选中行ID查询原DBPoint，而非把OCA作点标高。Altitude属性写原Z。Name调用已通过处理后0x06000254的IL_00B5/00D7/00EE–00FF栈分析恢复为同一setter(blockId,"Name",parsedName)；反编译阅读副本参数次序错误，见marker.md。

本次A8原生导入/评价/表格/Mark切片已转写到TurnAreaForm.Events.Recovered.cs（未编译）。A9两种主副区评价另见PriSec.Recovered.cs、PriSecForm.Events.Recovered.cs及pri-sec-evaluation.md，新增19项纯计算检查通过。A7/A10/B3/B4/B5其他评价入口仍有缺口，不把这些算法相互推广。本轮障碍物任务仍未全部验收。
