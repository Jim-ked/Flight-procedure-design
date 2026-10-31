# 跑道与局部坐标

THR 为第一点，RWY end 为第二点。拾取把 X/Y Round(...,2)，Z 原值转字符串；swap 交换全部六字符串。共享 P0AC 保存 THR.X/Y/Z、XY长度、THR→end 方位及 end→THR 反方位。P0AD 的局部正X沿 end→THR，即进近侧为正、飞越入口向跑道延伸为负。

`x=L*cos(bearing(THR→obstacle)−bearing(end→THR))`；`y=L*sin(...)`。公共 helper 本来返回 `obstacle.Z−THR.Z`，**B4转换P55B只读取XY坐标文本，临时THR.Z/end.Z均0，而且构造障碍物后仅复制localXY，保留源绝对Z**。因此表中的面高/最低标准不能假定已做相对入口化。转换调用P558只填13列表，没有评价。

CAD P55C 读两点XYZ，按反向方位旋转点列→P827全部Z清零→P823加THR.X/Y→P087。跑道end.Z不决定二维方位。测试例 THR(1000,2000,100)、end(2000,2000,200)、障碍物(1300,2100,250)得到local(-300,-100,250)。

与B3同P0AC/P0AD；转换都保留源绝对Z。与B5同helper，但B5 Form按DER、THR顺序，业务原点/正方向与B4不同。没有第三点、出航点或 TP 数据绑定。零长度/取消拾取没有新增业务拦截。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P559|0x0600055A / 0x8A3E8|0x70D8C|60967|
|P55A|0x0600055B / 0x8A538|0x70E40|60988|
|P55B|0x0600055C / 0x8A688|0x70EF8|61010|
|P55C|0x0600055D / 0x8A970|0x710AC|61057|
|P57C|0x0600057D / 0x8DFB8|0x73680|62546|
|P0AC|0x060000AD / 0x83A0|0xA650|3103|
|P0AD|0x060000AE / 0x846C|0xA714|3116|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
