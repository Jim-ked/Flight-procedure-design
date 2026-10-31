# XData 待恢复清单

`xdata-il-sites.csv` 收录 XData/RegApp/ResultBuffer/TypedValue/JSON/序列化相关位置（A：调用位置）；并非每条都是 XData，也不保证包括所有间接包装。

目前尚未逐写入点恢复 RegApp 名称、DXF类型码、JSON字段、版本、读者及删除/重建后的保留行为。不得声称存在统一程序数据模型。离场 DBPoint `_008C_008D` 转换和 xInfo 是优先追踪入口。完整schema需要按写入→读取闭环确认；JSON库调用本身不是跨窗口传递证据。
