# 跑道局部系

P47B 读取 textBoxLon1/Lat1/Z1（THR）和 Lon2/Lat2/Z2（跑道另一端），调用公共 **P0AC**，与 A7/B5 是 Same MethodDef。保存THR XYZ、两点XY长、正反bearing。B5 Form以DER为原点的参数顺序与B3不同；相同方法不能推成相同业务原点。

局部 +X 沿 RWY end→THR，指向进近入口前方；Y由该反向bearing确定。P0AD：x=L cos(bearing(THR→P)−reverseBearing)，y=L sin(...)，z=P.Z−THR.Z。两端Z不改变XY方向/长度。

重要区别：buttonAix/P478 用公共转换结果只覆盖障碍物 X/Y；结果记录从原点对象构造，**Z保留原绝对标高**。不能声称UI已经提供完整的APV相对Z链。APV工厂/评价器无UI连接，输入Z惯例须分别看算术，不能替它建立新适配器。

绘图 P47C 旋转局部点列（P821，reverseBearing）再平移THR XYZ（P823），writer经Point2d丢弃Z。B3没有B5的ZeroZ调用，但最终同样只存XY折线。取点取消公共P113返回Origin，现有事件未统一拒绝该值。

证据：P47B行47206、P478行47141、P47C行47219，及公共P0AC/P0AD；身份见method-index。
