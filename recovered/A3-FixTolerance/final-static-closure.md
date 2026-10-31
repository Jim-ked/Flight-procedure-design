# A3 Fix Tolerance — Round 12 最终静态收口

判定：**A3: COMPLETE_STATIC**。设施精度、单台容差、DME三弧、KK早晚线、顶空盲区、Track辅助、CAD实体、metadata和异常事件均有静态证据。Round 1 PARTIAL历史状态不改；本轮不补双台交叉定位。

## 20问
1. 双台交叉定位？没有；只有S和方向点Q。
2. 设施？VOR、ILS、NDB；DME为距离/弧线分支；无LOC/TACAN/GNSS。
3. 角度？5.2/4.5、6.9/6.2、2.4/1.4为设施精度角；40/50为顶空半角；5/15、15/25为盲区辅助角；7.8/10.3为A4保护发散比较。
4. DME公式？e=.0125r+460m；指定NM×1852；未指定为拾点平面距。
5. 三弧？late r+e、nominal r、early r-e，同一S和theta±a。
6. KK early/nominal/late？只有late横线和early投影横线；无独立nominal KK线。
7. 9260？横向Line半长，非第二台站距离。
8. A7读KK？不读，重新拾点。
9. A6读A3？无直接reader/caller证据。
10. A10复用DME？不复用，A10自建DME弧。
11. Overhead？R=h*tan(HalfAngle)，圆心为拾取台站。
12. VOR/NDB overhead？代码写50/40，绘图读取当前文本框。
13. Track？普通链是S→late参考线；盲区链是按设施角的两条辅助线。
14. A3性质？定位容差/顶空图元工具，不是完整程序保护区引擎。
15. 实体？2 Line、1楔形Polyline、可选Track、3 Arc+DBText、可选2盲区Polyline+Circle。
16. metadata？empty/neutral helper；无WsObject/WsCalcuLine/WsEntityFrame语义载荷。
17. 异常绑定？textBox2 Leave与NDB CheckedChanged共用P212，真实保留。
18. Designer/config？只影响完整WinForms/宿主运行，参与业务控件事件已确定，属LOW_VALUE/RUNTIME_UI_ONLY。
19. Help高估cross-fix？是；两个方位/距离描述与单台单方向实现不一致。
20. COMPLETE_STATIC？是；剩余E4、host/Designer和规范依据，不是静态算法/事件断链。

## Residual
STATIC_ALGORITHM_GAP无已实现链断裂；双台交叉定位为NOT_IMPLEMENTED_IN_BUILD。EVENT_REACHABILITY_GAP已关闭并记录异常绑定。Designer/config降级RUNTIME_UI_ONLY/LOW_VALUE。GetPoint和无对象语义关联保留为MANUAL_CAD_DEPENDENCY。E4未执行。精度角、40/50、.0125r+460、9260标记STANDARD_BASIS_UNRESOLVED。

证据等级：E0/E1身份与IL；E2事件/字段/调用；旧E3不重跑；E4禁止；规范为N。