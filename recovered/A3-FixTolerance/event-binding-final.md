# A3 异常事件绑定

Designer/事件索引显示：textBox2（旧DME后缀框）Leave→P212；radioButtonN CheckedChanged→同一P212。P212 在NDB选中时写 HalfAngle=40并切换VOR/NDB图像。因此离开DME后缀框可能重置顶空半角。它不是HalfAngle控件的Leave，属于真实旧绑定，本轮不修。

VOR选择写50；DME/Suffix/指定距离事件只控制启用状态。盲区数字转换失败后Validate并直接返回，原代码不恢复Visible；Origin取消路径恢复Visible。这些异常均保留。
