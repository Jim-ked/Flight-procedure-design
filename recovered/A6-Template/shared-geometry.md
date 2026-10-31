# A6 与 A1/B1/B2 的共享关系

`../round4/shared-template-geometry.csv`区分same MethodDef、copied implementation、only same primitive、no relation；逐调用位置见`shared-template-geometry-sites.csv`和`evidence/calls.csv`。两个token序列相同是身份依据，图面或名称相似不是。

## 核心primitive表

|功能|processed / original|A6直接调用|
|---|---|---|
|P793 turn ctor|P793 / P794|P854；各模板经P356读取，非各自直接new|
|Spiral86 ctor|P7A1 / P7A2|XE P3BF×2，YE P3CB×2，45 P452×3，80 P45E×2|
|Spiral88 ctor|P7B7 / P7B8|普通Holding P3AB×6；Base P1F0的5个活跃字段|
|Spiral86 point-to-spiral|P7AD / P7AE|**A6业务类直接caller=0**|
|Spiral88 point iteration|P7BE / P7BF|Base P1F0，多个位置|
|Spiral86 两spiral角度|P7AF / P7B0|XE P3BF IL_045B；YE P3CB IL_04EF；80 P461 IL_0080|
|Spiral88 两spiral角度|P7C2 / P7C3|普通Holding P3AB，Base P1F0|
|Spiral88 距离迭代成员|P7BC/P7BD|这些A6业务类直接caller=0|

A1/B1/B2冻结调用索引使用Spiral86；普通Holding/Base的Spiral88没有同一spiral MethodDef关系。它们仍共享P793、点/向量运算以及CAD writer。45/80/XE/YE对P7A1/Point等的复用是确切同MethodDef；各业务构造器及完整保护区算法不是同一个模板类。

## 两spiral角度的新增证据

Round 3冻结结论限定于A1/B1/B2索引，未找到其调用的独立两spiral CommonTangent。A6揭示primitive**内部成员**P7AF（original RVA0xC5CC0）和P7C2（original RVA0xC7480）。它们不是P7AD，也没有独立CommonTangent类。

P7AF可读表达式（h为heading、o为offset、e为windradius、δ为drift）：

```text
θ=atan2(C2.Y−C1.Y,C2.X−C1.X)
D=distance(C1,C2)
a=asin((o2−o1+(h1−h2)e)/D)
q=θ−a−π/2+δ
return q+(q<0 ? 2π : 0)
```

P7C2是Spiral88对应角度成员，使用 `%2π` 的归一化形式。不能声称整个程序集没有任何“两spiral角度MethodDef”，也不能把方法输出未经证明推广为任意spiral的稳健公切线求解器；asin域没有新增防护。

## copied与业务独立

Holding.P3B0/P3B1与Form.P368/P369是相同gift-wrapping/方向公式的两处实现，点类型及相等语义不同，属于copied implementation，不是same MethodDef。B1/B2自有line carrier/candidate comparison只复用底层primitive；未发现与A6完整模板构造器同MethodDef的关系。

旧Round3 writer表token错配的本轮补证见cad-output-map；旧代码/报告原样冻结。共享表中的point helper交集不能误读为Holding也new了Spiral86。
