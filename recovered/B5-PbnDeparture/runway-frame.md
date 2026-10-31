# B5 跑道与坐标

P4FB DER取点、P4FC THR取点、P4FD TurnEnd取点，均经公共P113 GetPoint。P510交换DER/THR文本；P4FF读取两跑道点。P4FE为未绑定坐标转换方法，不能当作评价入口。原/处理身份和RVA见event-map与method-index。

## 两种frame调用方向

同一 `_008D._0089_008F` P0AC：Frame(P0,P1)保存P0 XYZ、两点XY长度、bearing(P0→P1)到字段0089，反向bearing到008A。

1. Form用Frame(DER,THR)，原点DER，局部正X沿THR→DER。转换P0AD：x=L cos(bearing(DER→P)−frame.008A)，y=L sin(...)，z=P.Z−DER.Z。
2. 两业务类内部用Frame(THR,DER)取得incoming heading，再把DER→TurnEnd向量转到incoming坐标。调用顺序不同，但由同一MethodDef实现。
3. 写CAD：局部点列绕原点旋转frame.008A→ZeroZ→加DER.X/Y。绘图Z全为0；不会生成三维爬升面。

TurnEnd是实际XY目的点，既影响出航方向、长度，也进入线交点和末端追加，不只是一个无限远方向。Form不读TurnEnd Z。DER.Z用于TP/评价基准；THR.Z不参与二维跑道长度和方向。业务内部控制点Z另有旧表达式，最终CAD抹零。

和A7共享P0AC/P0AD；**A7没有TurnEnd输入字段**，不能把它称作共享DER/THR/TurnEnd三点业务模型。B5与B2三点语义也不同：B2起点→转弯航路点→终点；B5为DER、THR、TurnEnd加单独TP站距。

取点文本被Round，TP取点使用到DER的无符号XY欧式距离。没有检查延长线共线性或做有符号轴投影；取消P113返回Origin的旧行为无统一业务拦截。自动化需要已有可信跑道/航段对象关联，当前没有此关联证据。
