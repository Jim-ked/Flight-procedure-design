# Round 12 有限 spot-check

|reason|methods/files examined|result|
|---|---|---|
|双台交叉定位|A3 events、P20E IL、Form controls|两次GetPoint是S/Q，无station2、bearing2、IntersectWith|
|DME公式三弧|P20E IL、geometry-chain、dme-final|1852、.0125r+460、r+e/r/r-e、theta±a、Arc Group顺序确认|
|KK|P20E IL、kk-final、cad-output-map|两Line、early cos(a)、±9260、Z0确认|
|Track|P20E/P211 IL、track-guidance|普通参考线与盲区辅助线区分|
|异常事件|events.csv、Form source|textBox2 Leave与NDB CheckedChanged共用P212|
|metadata/downstream|A3 calls、A7 Round11 proof、A6/A10/A4 evidence|无语义下游reader；仅empty/neutral writer|
|设施负向|controls/events/methods|VOR/ILS/NDB可达；LOC/TACAN/GNSS无证据|