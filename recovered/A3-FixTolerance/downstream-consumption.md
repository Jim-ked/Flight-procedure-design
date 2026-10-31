# A3 下游消费与双台交叉定位

P20E 公开 Click 只调用两次 GetPoint：第一次导航台 S，第二次引导方向 Q。第二点不是第二设施；Form 没有 station2、second station、bearing2、radial2 控件，A3 calls/IL 未发现 IntersectWith 或两条独立径向求交。

结论：A3 does not implement an automatic two-facility cross-fix solution in this build.

A7 Round 11 已证明重新 GetPoint、不读A3 semantic KK/WsCalcuLine。A6 没有A3 Form/MethodDef direct caller；相同VOR/NDB字符串不构成复用。A10有自己的DME弧业务类/事件，未发现A3入口；A4仅共享低层Point/角度/CAD primitive，Round 9 已区分为不同业务。上述均限定已索引的直接调用图，不排除反射或宿主外部行为。

A3 writer 只经共享 empty/neutral helper；没有足够的 WsObject/WsCalcuLine/WsEntityFrame 语义载荷，不能自动形成下游业务对象。
