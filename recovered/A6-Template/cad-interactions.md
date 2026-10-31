# A6 CAD 人工交互记录

范围包括本Form已绑定链和同Form未绑定交互，后者只索引，不扩展障碍物模块。每项源位置及token见 `connection-and-cad-index.csv`、`evidence/calls.csv`、event-map。

|入口/交互|用户选什么|流向哪个计算|为什么未自行确定（可证实事实）|自动推导判断|
|---|---|---|---|---|
|P358→GetPoint wrapper，第一次|“导航台位置”坐标|模板原点放置；Base自动距离起点；镜像轴起点|当前函数直接请求坐标，无导航台实体查询|若上游有台坐标可提供；旧实现未连接这些数据|
|P358第二次|“入航方向”上的点|atan2方向；镜像轴；Base自动距离终点|第二点既给方向也给长度；无命名航段读取|若已有航迹方位可推一方向点；Base距离需要保留实际长度，不能只给单位向量|
|Base关闭输入距离|沿用上述两点，无第三次拾点|3D DistanceTo/1852→distance→φ和控制点|没有DME台对象输入，也未读取航段结构|可以由已有两点确定，旧程序本来已算；业务意图不能擅改|
|P367 GetSelection|任意已绘实体集合，实际接受Polyline和Line|顶点flatten→P368→新Polyline|没有按Group/XData/程序ID查询；作者理由未知|调用方若持有目标列表可以替代选择；哪些模板属于同程序仍需业务关联|
|未绑定P363 GetEntity|提示选择“基线转弯保护区的主区边界线”，Polyline|主区/副区与MOC评价；读取300/width|当前没有从本轮创建对象直接传ObjectId|本轮不恢复评价新模块；已有写入结果可作为未来关联来源|
|未绑定P36A GetSelection|多条曲线，转Region|BooleanOperation与Explode|独立未绑定方法|不应替换已绑定P367算法|

普通CAD、XE、YE、全向均调用P358；calculate按钮不调用它。P358先隐藏Form/激活CAD，再恢复可见；两个选点为Origin时返回0但不保证清除旧heading。仅一个Origin时仍可继续atan2。wrapper把取消/原点哨兵混用，**不可在恢复中改为新的cancel异常流程**。

本Form.Load P354/Close P355读取/保存 `config.xml` 的FormTemplate状态。故calculate可能使用先前UI字段；未发现本绑定链用数据库中的程序ID自动组装模板集合。配置持久化不是飞行程序几何数据库关系。

本轮没有执行CAD操作。能由数据自动提供坐标/集合是恢复后的可行性判断；选择对象归属、原点取消歧义、部分取消继续和多次计算后旧状态均需后续宿主验证。
