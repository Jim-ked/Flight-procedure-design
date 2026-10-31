# FAF/FAP、IF与高度字段映射

|field / UI label|code object / formula|used by / CAD|规范候选与证据|
|---|---|---|---|
|textBoxFAF / FAF高度；_0087_0096_0087|P307 F，H=F−THR.Z；名义fix_0087_0092_0090=(H/tanGP,0,H)|GPINOP、FAF、FAP；其余模式仍无条件parse|候选中间最低高度/下降定位点标高；不是规范定义证明，E2|
|textBoxFafFix / FAF定位容差；_0087_0095_009D|P306传P437；early.x=fix.x+T|仅FAF实际附加容差，E3测试0/700/900|下降定位容差候选；未限制±.9km，Differs|
|textBoxIF / 中间段长度；_0087_0095_009B|IF_0087_0092_0091=(fix.x+L,0,H)|GPINOP、FAF、FAP中间轮廓；无可达评价|输入长度非绝对站距、非硬编码10000；E2|
|GP|tan(GPπ/180)|fix站距；DB key；P1.A|名义GP候选，未强制3°|
|RDH|P40C加到W/W*/X/Y.C|面系数、截断交点；不减入fix站距|与规范表中FAP站距计算不一致|
|THR XYZ|F−THR.Z；frame原点和方向|CAD旋转平移|米制CAD坐标；未实现投影转换|
|P316 IF两点拾取|3D DistanceTo，F2回填L|只代替长度手输|不是自动提取航段|
|P317 FAF/最早点两点拾取|3D DistanceTo，F2回填T|代替容差手输|未用方向或投影距离|

FAF/FAP为**两个不同构造类/分支角色**，但不是两个独立名义点/高度输入。FAP不使用T；FAF叠加最早点/下降面。L=0允许IF与fix重合，负H不拒绝；GP0或非法parse成0可传播Infinity，不补合法性检查。完整setter/consumer清单见parameter-control-inventory.csv。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P307|0x06000308 / 0x401EC|0x3537C|24174|[证据](evidence/processed/0x06000307.il.txt)|
|P316|0x06000317 / 0x418A8|0x362EC|24691|[证据](evidence/processed/0x06000316.il.txt)|
|P317|0x06000318 / 0x419E8|0x3638C|24726|[证据](evidence/processed/0x06000317.il.txt)|
|P437|0x06000438 / 0x68AF8|0x55DA8|44470|[证据](evidence/processed/0x06000437.il.txt)|
|P443|0x06000444 / 0x699B8|0x56848|44929|[证据](evidence/processed/0x06000443.il.txt)|
