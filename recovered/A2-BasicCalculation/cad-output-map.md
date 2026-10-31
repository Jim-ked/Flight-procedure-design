# A2 CAD 事件与输出闭合（L1/L2）

定位以原始token/RVA为主；阅读副本为处理后结果。逐条IL与事件注册见本包 evidence/，不把处理后的token冒称原token。绘图公式见 formulas.md。

令起点S、第二点Q，θ=atan2(Qy−Sy,Qx−Sx)，P(S,d,θ)仅由XY构造、Z=0。C为中心P(S,d,θ)，横向端点C±L/2·(cos(θ+π/2),sin(θ+π/2))。各页Line为横向施工线。

| 页/Click | 原 MethodDef / RVA | GetPoint依次提示 | 取消/Origin | 实体顺序与文字开关 |
|---|---|---|---|---|
| FAF/buttonFAF | 0600022E / 1F350 | 跑道入口→FAF方向 | 每点Origin即退出 | FAF Line→IF Line；勾选后4个DBText：间距(500)、FAF(1000)、高度/相对高(1000)、IF(1000) |
| NPA/buttonNpaSOC | 06000233 / 1FBE0 | 复飞最晚点→复飞方向 | 取完两点只检查相等 | 1 Line→可选SOC DBText(500) |
| PA/buttonPaSOC | 06000236 / 200E0 | 入口THR→复飞方向 | 同NPA | 1 Line→可选CAT+类别+SOC DBText(500) |
| Missed/buttonMissTP | 0600023B / 20990 | 起点→复飞方向 | 每点Origin即退出 | 1 Line→可选距离DBText(500，含换行)→TP DBText(500) |
| Departure/buttonDepTP | 0600023E / 20FBC | DER→离场转弯点方向 | 每点Origin即退出 | 1 Line→可选距离DBText(500，含换行)→TP DBText(500) |
| C/buttonC | 06000241 / 21628 | 起点→飞行方向 | 同NPA | 1 Line→可选C DBText(500) |

GetPoint helper原06000114/CB28，PromptPointOptions.AllowArbitraryInput=true；Error重试、Cancel返回Origin。所以Origin是有效坐标与取消哨兵混用：Departure以(0,0,0)做DER将退出，不能为实验修复它。NPA/PA/C一次取消但另一次非零仍可能画图。

| 页 | 中心沿程值d | Line长 | Metadata |
|---|---|---:|---|
| FAF | 原公式未舍入d；IF=d+输入Intermediate | 两条各20000 | Kind1参数；IF用Kind2默认参数 |
| NPA | (TAS+w)t/3.6未舍入 | 12000 | Kind3，包含转弯参数/计时/距离 |
| PA | −Round((DH−HLcor)/tanGP+Xz) | 12000 | Kind4，ThrSocDistance也保存负d |
| Missed | 100(终高−起高)/梯度百分数 | 20000 | Kind5 |
| Departure | 100(转弯高−DER高−5)/PDG百分数 | 20000 | Kind6 |
| C | (TAS+w)t/3.6未舍入 | 12000 | Kind7；工厂10000被writer改成12000 |

所有Line/DBText Z=0。NPA/PA/C标签在plus端点，旋转θ−π/2；FAF/TP距离文字在起点与中心中点，旋转Readable(θ)（θ在±π/2外加π）。TP标签在plus端点。未显式设Layer/Color，不能据此代替宿主默认值实测。

公共链：CreateLine原060006A4/B9C38重算中心、长度、横向方向→AppendWithoutMetadata原0600008A/5878（事务提交Line）→Save原06000655/B8B08（另一事务Register+XData）。两个事务独立，元数据失败不回滚线。文字另行追加，无WsCalcuLine。完整schema见 WsCalcuLine-schema.md。

保留：HLcor=0时CalculatePa原06000238/2056C返回−1，CAD取负继续+1；空数字返回0；NPA/C转弯reader重复调用；reader异常返回null而调用者未统一保护；comboXz.TabIndexChanged绑定PA绘图（不是纯重算）。原代码、IL、事件表已归档，不因兼容编译去除这些行为。运行验证状态另见 dynamic-test/experiment-index.md。
