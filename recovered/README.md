# WsTools 本轮恢复成果与验收状态

范围：A2 → RandomPoint/xInfo/ScreenData/评价/Mark → A3。不扩展完整A7/A8/A10。更新至2026-10-27。

**Round 1: PARTIALLY ACCEPTED。** 最新见[Closure及十三问](round1-closure.md)。A2、障碍物公共链、A3静态证据已整理，19个恢复文件启用AUTOCAD后通过API25.1兼容编译；原API23.1重建、完整designer/config和目标业务运行仍有缺口。目标副本映像已加载但RCL未知命令，随后输入队列污染阻止诊断；只有宿主/Observer运行证据，无业务L3。原件收尾hash复核见`dynamic-test/logs/closure-integrity.json`。

## 包入口

本轮最新：[编译验证](dynamic-test/compile-validation.md)、[实验索引](dynamic-test/experiment-index.md)、[差异及阻塞](dynamic-test/dynamic-static-differences.md)。下列“未编译/未运行”及旧增量报告描述当时状态，由Closure更新。

最新：[原生事件、七窗障碍物链与A9评价增量](round1-native-recovery.md)，[78个方法切片审计映射](native-port-map.csv)，[新增19项检查记录](PriSec.verification.log)。这些数字均不表示恢复完成率。

2026-10-27：[参数序列化、六工厂及CAD写入链增量](A2-BasicCalculation/serialization.md)。新增18项恢复代码测试通过；原生CAD文件未编译/运行。完整第一轮仍未验收。

- [A2](A2-BasicCalculation/overview.md)：六页公式、事件、实体级输出、WsCalcuLine；新增TAS/单位换算。
- [障碍物](ObstacleData/random-point.md)：生成、[XData及xInfo](ObstacleData/xdata-schema.md)、[ScreenData](ObstacleData/screen-data.md)、[KK评价](ObstacleData/evaluation.md)、[Mark](ObstacleData/marker.md)。
- [A3](A3-FixTolerance/overview.md)：设备表、几何、KK、盲区与CAD交互。
- [验证](verification.md)：27条数值断言及名称/格式器/Infinity检查通过；明确未验证部分。
- [二十问](twenty-questions.md)：当前证据答案，不是全任务完成声明。

每包 evidence/ 保存摘录、处理后独立IL、methods.json、events.csv、controls.csv、calls.csv。源摘录只作证据，不能当成可编译源码。旧报告A–E证据体系保持不动；本轮L1–L4并标明来源，原始RVA可能只是保护桩。

## 后续仍需完成（本轮范围内）

1. A2六条CAD事件、解析/文字布局已转写；仍需接回完整designer/config及单位选择控件，核验原生引用和真实旧数据兼容。
2. RandomPoint、公共ScreenData/parser、七窗导入表与Mark已转写；A8/A9评价有独立恢复代码，其他评价器仍需按入口核对，不能推广KK或主副区算法。
3. A3原生事件、输入异常、可见性、分组事务及输出已转写并通过25.1兼容编译；Arc/Circle与Polyline/KK不同Z的目标宿主验证未完成。
4. 当前宿主已确认API25.1/CLR8.0.12；原目标引用23.1。RCL不可用及输入污染处理前，不再继续CAD自动输入；实验索引明确未执行项，不允许声称运行等价。
5. 原DWG块定义尚未独立读取；在其布局和属性定义得到证据前，不宣布符号完整恢复。

没有为了符合AC-97-FS-005而修改公式。规范来源和实现历史依据需分别记录，“实现依据待确认”不等于算法可随意修正。
