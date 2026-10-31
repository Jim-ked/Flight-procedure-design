# B5与B1/B2

两比较CSV包含turn parameter、ATT、earliest/latest、spiral、inner/outer、width transition、CAD和XData。另有同MethodDef调用交集及caller站点。

B1/B2经P854读公共P793，B5在P500/P50A直接new P793；三者共享Spiral86 ctor/Point/sample/候选helper的实际交集。B1 `_008C_0087`、B2 `_008C_0089`与B5 `_008C_0091/_008C_0093`均为不同业务类。B5对B1/B2构造和边界方法没有直接调用。

B1的anticipation包含r tan(A/2)，B2以输入ATT确定earliest/latest；B5高度无独立ATT，FO固定1482。B1/B2用起点/航路点/终点descriptors；B5以跑道frame+TP站距+TurnEnd表达。B5后续主宽1852/外宽3704写死；B1/B2由UI/预设宽度输入。常用15°衔接与候选操作是独立相似实现，不能从局部语句相似推定完整边界相同。

本轮不修改冻结Round3的partial geometry port，也不为了ATT=0进行跨轮重写；没有输出数值等价证明。B5 public workflow does not evidence Fly-by departure. No B5 RF implementation evidence found. 负证据限于B5 Form、两业务类及直接可达helper，不否定DLL其他模块。
