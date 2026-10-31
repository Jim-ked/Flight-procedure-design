# APV / Baro-VNAV 数值业务链

Form工厂P470（孤立）→P5ED，参数依次为 `(IfSegLen,FafAlti,Z1,VPA,TCH,comboBoxHi,MCG/100,ThrToSoc+SocToTp,AdElev,Temp,comboBoxCat)`。IL中第一个IfSegLen压栈后跨局部赋值保留，11参数签名与newobj一致；不是丢失参数。

主输入不包含DH、HLcor文本、comboXz、comboBoxGP、textBoxPDist、textBoxElev、TpAlti。故候选`SOC高度=DH−HLcor`及`THR-SOC=(DH−HLcor)/tan+Xz`未在B3形成计算链。只有Z面起点Xz与主输入指定的复飞总距离。该结论不把A2公式移植进B3。

温度修正、FAS斜率/起点、水平面、Z面和侧面数值均已恢复，详见apv-surfaces。P5EE对单个障碍物分段，P5EF作主副区面高/比例，穿透时P5F4作当量高。P5F0插值、P5F1类别Xz、P5F2类别HL、P5F3温度项。各方法身份见索引，勿将P5F1误当评价后处理。

APV业务类没有点列表CAD生成器；不存在可达APV CAD surface writer。恢复的是数值曲面分段，不能宣称已经生成拓扑闭合3D面。没有B3调用A5 W/X/Y/Z系数库或OAS数据库的证据。
