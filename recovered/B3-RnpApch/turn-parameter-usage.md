# P793 在 B3 中的实际消费者

唯一B3直接构造P793的业务事件为P48A NPA SOC。参数IAS、NAlt、固定bank15、wind、NTemp，IAS/wind的单位开关各自乘1.852。直接消费字段仅TAS `_008A_009D_009A`，再加风和时间及固定444。

同一P793构造器内部仍算出半径、转弯率等通用字段；这些构造副作用不等于B3消费。B3没有把其C6/半径/风螺旋值交给P593或P5ED，没有PDA/required-gradient输出。MDist估算不调用P793。A2、A7、B5共享的是P793 MethodDef，后续业务算法不同。

TAS=`IAS*171233*sqrt(288+Temp−.006496*Alt)/pow(288−.006496*Alt,2.628)`；主保护几何不读取风/类别（LNAV）或速度（APV）。输入值域错误的旧NaN/Inf不截断。
