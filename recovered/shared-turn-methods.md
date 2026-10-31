# A7 / A8 与共享转弯方法

直接证据见 [全部直接边](round2/shared-direct-calls.csv) 与 [原语表](GeometryPrimitives/shared-geometry-map.md)。间接见证路径另存 [shared-call-witnesses.json](round2/shared-call-witnesses.json)，不能把间接可达当作窗口直接调用。

- A7直接构造共同turn参数模型 P793（原06000794/RVAC3820），因此复用TAS、率、半径、风半径公式；A7实际几何只消费TAS+Wind的6秒延迟，没有调用P7A1螺旋构造器。
- A1通过输入reader P854，再构造turn参数；窗口直接new螺旋P7A1。B1/B2各自的直接边和间接路径以CSV/JSON为准，不以算法相似推断共享。
- A7三个评价器分别属于定高、定点、全向模型；A8调用KK公共评价器；两者没有共同业务评价器的直接调用证据。
- A7和A8复用点、线、局部变换及障碍物导入/解析/Mark helper；A10复用障碍物公共链，但其扇区判定与副区折减在本窗独立实现。
- Round1 PriSecRecovered.Local是恢复代码复用的等价坐标切片；不能据friendly类名断言原A7调用A9业务评价。
- 几何相似但重复实现：A7三模型的MOC/PDA/required判断、A10 sector和A9 PriSec；同为副区折减并不代表共享。

## 证据限制

所有无调用结论限定已索引的静态直接边/可达路径；不排除反射、外部插件或手工画图。无原目标L3。
