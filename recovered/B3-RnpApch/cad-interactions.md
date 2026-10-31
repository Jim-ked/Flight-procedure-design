# CAD 人工交互与自动化边界

|入口/API|用户选择的业务对象|软件不能自行决定的原因|进入计算/数据流|可由已有数据推导？|
|---|---|---|---|---|
|button5 P479→P113 GetPoint|跑道THR|图元没有被绑定为当前跑道入口语义|Round XY两位，Z原值→Lon1/Lat1/Z1→frame/两工厂|已有坐标即可省去拾取；当前无可信跑道对象自动识别|
|button4 P47A→P113 GetPoint|跑道另一端|需要当前跑道方向/端点身份|Lon2/Lat2/Z2→frame|若已有两端点及THR身份可推导；无自动几何匹配|
|button2 P483 GetEntity|要载入参数的RNP保护区实体|可能存在多套绘图；无当前procedure关联|实体XData[1]→控件恢复|可按WsObject文本检索候选，但无法凭现有状态唯一决定用户意图|
|button3 P476 SelectAll POINT|软件自动收集Model DBPoint，不是用户逐个选择|仅类型过滤，没有现行procedure/保护区关联|全列表解析、ID字典、展示|全列表已自动；不能宣称按区域选障碍物|
|表格行与Mark/Highlight|用户要查看或标记的障碍物行|无自动最危险障碍物排序规则|行ID→原DBPoint→高亮或obst块|已有ID可定位；评价调度断开，不能自动确定最危险行|

本链未出现GetSelection式保护区交集选择。GetPoint取消返回Origin未统一校验；GetEntity需PromptStatus5100。无根据图形手选来补足intersect/clip的编码证据；外部人工编辑可能是工作流程，但本轮未做宿主观察，标为尚未运行验证。
