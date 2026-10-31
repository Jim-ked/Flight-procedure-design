# 六项真实计算

L1 Direct + L2 IL，非规范推断。各原token/RVA见 evidence.md 和C#注释。

| 功能 | 实际表达式/返回值 | 舍入和边界 |
|---|---|---|
| FAF | `(FAFalt-RDH-THRalt)/tan(GP*pi/180)` | 显示Round(d)，返回未舍入d；IF与FAF相距另一个输入长度 |
| 非精密SOC | `(TAS+wind)*textBoxNTime/3.6` | 显示Round(d)，返回未舍入d；默认18，代码不拆3+15 |
| 精密SOC | `Round((DH-HLcor)/tan(GP*pi/180)+Xz)` | HLcor==0提示并返回-1；另写SOC高度为DH-HLcor的f1字符串；CAD取负返回值 |
| 复飞TP | `100*(TurnAlt-SocAlt)/gradientPercent` | 显示Round(d)，返回未舍入d |
| 离场TP | `100*(TurnAlt-DerAlt-5)/PDGPercent` | 5硬编码；显示Round(d)，返回未舍入d |
| C | `(TAS+wind)*textBoxCTime/3.6` | 默认6，代码不拆3+3；显示Round(d)，返回未舍入d |

除HLcor==0分支外，所查数值方法没有额外零除/有效域校验；不能在恢复代码中加入截断或正值保护。UI解析helper已转写到 ../CadInteraction.Recovered.cs：错误提示后返回0，TextBox版本另设焦点及LightCoral；不是取消事件。

HL表位于Form构造器，顺序comboCat={H,A,B,C,D}：{35,8},{40,13},{43,18},{46,22},{49,26}。机场标高>900时 `Round(Round(HLm+HLr*0.02*elevation/300,2),1)` 写入HLcor；否则直接复制HLm文字。D/1800产生中间52.12、最终52.1。前置分析的52.12不能当成该事件最终输入值。

TAS共用 `_008F_0098._008B_008C_008A` 读取IAS、高度、坡度、温度、风；IAS/风各自为kt时乘1.852，然后调用 `_008E_009B` 构造器（处理后793）：

`k=171233*sqrt(288+temperature-0.006496*altitude)/pow(288-0.006496*altitude,2.628); TAS=IAS*k`。

temperature是该控件输入，业务含义按前置分析为ISA偏差；未增加单位或大气模型修正。构造器还计算转弯率/半径，但A2两计时页只消费TAS和wind。TAS/单位换算在已测数值代码中；完整构造器和reader另在TurnParameterInput.Recovered.cs中，已通过25.1兼容编译，未获目标运行验证。
