# KK′端点和Ds

左pick P251→原252/RVA28B48；右pick P252→原253/RVA28C98；swap P253→原254/RVA28DE8。均GetPoint，XY Round2，Z原值；取消Origin仍回填，无实体身份/XData读取。操作者指定何为KK′左右业务端点，软件不从A7保护区识别。

L为左点、R为右点。length=hypot(R-L)，原点L，局部正X为 **R→L**（不是L→R，亦非中点）。

`x=distance(L,P)*cos(bearing(L,P)-bearing(R,L))`；y对应sin；公共转换原返回Z-L.Z，评价handler强制恢复绝对Z。R.Z虽解析但不用；L.Z作为起算高度。KK线段在局部X从-length到0，Y=0；区域标签仅y<0为外，其余内，标签不产生过滤。

Ds不用于构造这条线、不定位中点，只作评价器dr输入。button1 P25F→原260/RVA296C0独立两次GetPoint第一/第二点，**Point3d.DistanceTo为三维距离**，Round2写Dr文本。无业务对象约束；其Z行为与A7的XY距离不同。可以由外层航段数据推导Ds是自动化候选，原程序没有这种自动来源。

高度事件P262/264将左复制到右，P263/265将右复制到左；不设置Cancel。选择模式P261和P260空体。完整事件图见event-map。
