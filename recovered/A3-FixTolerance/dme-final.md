# A3 DME 误差与三弧

P20E 计算 e = 0.0125*r + 460，单位米。指定距离时 r=DistanceNm×1852；未指定时 r 是两次拾点的平面距离，DistanceNm 只以 Round(r/1852,1) 回填显示，几何使用未四舍五入 r。数字失败进入 Validate 后返回。

三弧共用圆心 S 和角范围 theta-angle 至 theta+angle：late 半径 r+e；nominal 半径 r；early 半径 r-e。三条 Arc 追加到独立 Group。随后追加 DBText：D+距离文本+大写设施后缀，Height=500。未指定距离时文字位置为 Q，保留 Q.Z；指定距离时位置为 nominal XY 点，Z=0。Arc 使用原始 S，保留 S.Z。未选 DME 时在弧和文字前返回，但 e、楔形和 KK 已可能执行。

这是定位容差弧链，不是 A10 DME 弧或完整程序保护区。
