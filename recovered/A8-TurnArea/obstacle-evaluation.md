# A8公式与表头

入口P25E，原`0600025F/RVA292F8`；直接调用公共KK evaluator P2（原`06000003/RVA2164`保护桩）和跑道frame PAC/PAD。原本恒传variableMoc=false，不合并为A7公式。

令x/y为KK局部坐标，l=KK长度，z=绝对障碍物高程，b=左点Z，ds=Dr文本，g=PDG文本/100，m=Moc文本。

`do = x < -l ? hypot(x+l,y) : x < 0 ? abs(y) : hypot(x,y)`。

`MOC=m; OCA=z+m`。mode.Text恰为“指定高度”时`PDA=b+do*g; required=(OCA-b)/do`；其它模式`PDA=b+(ds+do)*g; required=(OCA-b)/(ds+do)`。此调用不走variableMoc=true路径，故无.008变MOC和+5。无区外过滤或非负clamp，零分母保留NaN/Infinity。

表头ds(m)显示输入ds，不是新计算的do；d0(m)显示距离输出。MCG(%)为**输出所需梯度required*100，Round1位**，不是第二个梯度输入。“Missed gradient”相关帮助不能增加独立变量：实际只有PDG/100一个gradient参数，模式只改变起算距离。MOC文本是输入固定下限/本调用实际固定MOC。

按required降序；表XY为局部XY，Z仍绝对；计数把所有导入点当范围内；Mark写Name及Altitude（Round1已按IL修正参数顺序，冻结不改）。
