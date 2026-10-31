# APV 障碍物评价

P5EE主调度，P5EF单段helper，P5F0线性插值，P5F4当量高。主方法无UI入边；以下是恢复方法算术，不虚构可达工作流。

## 单段P5EF

X在端点闭区间内才处理；越界提示“数据范围有误”并return，**不清除原record内容**。以absY判域；端点插值得w(x)、基面z(x)、MOC(x)，相同X的插值P5F0取两端纵值min。absY≤w/2主区，surface=z，factor=1；w/2<absY≤w副区，surface=`z+MOC*(absY−w/2)/(w/2)`，factor=`2*(w−absY)/w`；更外侧out。

## 沿程主分支（P5EE按此顺序）

|位置/条件|调用点对 / MOC|结果行为|
|---|---|---|
|x>A.X|无|out|
|A.X≥x>B.X|A→B /150,150|中间段，MOC=factor*150；surface=FafAlti−MOC，OCA=Z+MOC，OCH=OCA−Z1|
|B.X≥x>I.X|B→F /150,150|同中间段|
|I.X≥x>F.X|I→F /q,q|主区用150；副区再构造一套I′→F /150,150，比两种surface，区分中间副区/最后副区|
|F.X≥x>C.X|F→C /q,q|最后段；penetration=Z−surface，再surface加Z1|
|C.X≥x>H.X|C→H /q,q|最后段同上|
|H.X≥x>444|H→D /q,30|水平段侧面渐变|
|444≥x>xz|D→Z /30,30|水平段|
|xz≥x>−6814|Z→E /30,30|复飞段|
|−6814≥x≥END.X|E→END /30,30|复飞段|
|x<END.X|无|out|

阈值以既有点位为准；退化输入可能破坏其沿程排序，代码没有排序修复。重叠处是同一个障碍物的内部候选面比较，**不是一键评价合并**。中间分支与最后/水平/复飞分支混有绝对/相对标高表达，恢复不统一Z。详见P5EE IL及机械代码。

## 穿透后的P5F4

r=cot(VPA)，u=1/g，HL=P5F2结果，Xz=P5F1。factor字段`_0088_0090_008D`在helper中是比例，在主方法后变成HL，不能赋予单一恒定语义。

- 主区：若x<Xz或Z>(x−Xz)*tanVPA，则 `Ha=Ceiling((Z*u+x−Xz)/(r+u))`，OCH=Ha+HL；否则OCH=Z+HL。
- 副区：e=30*(1−factor)。同上判别但比较面增加e；若当作复飞障碍物，则 `Ha=Ceiling(((Z−e)*u+x−Xz)/(r+u))`，**改写为全HL**，OCH=Ha+HL；否则OCH=Z+factor*HL。
- 非穿透：主方法通常只factor*=HL，未必填写OCH/OCA。未知旧字段不自动归零。

P471孤立最低标准：OCA=OCH+THR，DH=Ceiling(OCH/5)*5，DA=Round(DH+THR)。RVR初算DH/P3−P2，<800按50进位、<5000按100、否则1000；上限5000/8000由高度条件决定。虽然类别/灯光分支写过下限，末尾IL_02BA又用num2覆盖RVR，**最终不保留这些下限**。完整机械方法保留该覆盖。

表P46F为14列：ID、名称、XYZ、区域、面高、穿透、HL、Ha、OCH、DA、DH、RVR。P46F与P471均孤立，没有UI到完整评价结果展示的链。
