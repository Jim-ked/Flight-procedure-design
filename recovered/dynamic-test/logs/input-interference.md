# CAD输入干扰记录

日期2026-10-27；来源：Computer Use可见状态、Observer命令事件。此文件是观察转录，不是完整CAD日志。

1. 污染前，Observer已附加隔离`dynamic-test/dwg/R01-EXP00.dwg`；目标副本NETLOAD结束，但RCL未知命令。可见历史另存`AutoCAD-command-history-before-diagnostics.txt`。
2. 后续尝试加载独立诊断DLL期间，整段任务文本进入CAD命令解释器，出现大量未知命令及SAVEAS。未能确认输入来源，不断言用户操作或WsTools所致。
3. 图名变为`C:\Users\ZJ\Desktop\R01-EXP00.dwg`。这超出约定隔离目录，是实验隔离事件。未把它当成业务输出；没有主动删除/移动/覆盖该图。只读文件状态/hash见`closure-integrity.json`。
4. 已停止文本输入并请用户取消操作；用户回复“已停止”。恢复后截图仍为桌面位置的SAVEAS对话框。
5. 恢复中仅尝试Escape和点击可见“取消”。Observer在`2026-10-27T05:02:23.1556492Z`记录SAVEAS取消，`05:02:23.3554887Z`立即又记录SAVEAS开始；刷新截图继续显示同一对话框，并出现未知命令“至少记录”。此后停止一切CAD自动输入。没有确认已清空队列，不能宣称取消成功。
6. 未保存或覆盖这次对话框；未NETLOAD诊断DLL、未执行WSOBS_HOST/WSOBS_SYMBOLS、未开始EXP-01。最后观察状态仍为SAVEAS，CAD保持打开。

Observer的Safe检查在图名离开隔离目录后拒绝实体事件和快照，但已订阅的Command事件继续写日志。桌面图状态不能用空快照作判断；未证明污染后仍为空图。后续所有污染命令和保存事件均排除出WsTools业务证据。
