# LNAV / APV 复飞边界

LNAV主工厂使用s=ThrToSoc、t=SocToTp、g=MCG/100：SOC.X=−s，评价截断x=−(s+t)，初始MOC向30下降，中间段另计算(SOC.X−x)*g。绘图外侧从(444,1759)至(−6814,3704)，对应15°扩张；并延伸至min(−(s+t),−6814)。SOC和端点不代表已经执行转弯。

APV使用同一总距离但没有独立SOC高度公式。Z面从类别Xz开始、gradient=g，使用数值侧面和当量高。未读取DH−HLcor；TpAlti未进入任一工厂。不存在指定高度/点/电台、KK′/C或转弯终向选择链。

B3核心对A8 turn evaluator、B5 PBN turn geometry、Spiral86均无直接业务调用；P793只供SOC的TAS。类名“missed”或字段“TP”不能证明存在风螺旋转弯。左右转fixture标为不适用，并记录缺项，不能构造新转弯实现来通过测试。
