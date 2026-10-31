# 规范基线与实现依据状态

本轮规范基线为项目内 doc/航空器运行目视和仪表飞行程序设计规范.pdf（AC-97-FS-005，民航规〔2020〕12号），SHA-256 6b6b6f04380f3e0a138ca57bb95fcddb0a390a5b4aa7a9c7a391ff35bb92c8ed。Round 5 的页级提取 recovered/round5/standard-pages.json（SHA-256 6fe0dcd777a9cc58b40aad3f5752fdefaab420ae35d22f271b8b81c7e39965ac）是本轮引用的规范检索结果。

A7 代码真实使用了 15°/30°、150 m 半宽、0.008、75 m、5 m、600 m/120 m、.1固定高度梯度和 .6 延迟换算等常数。现有页级证据不能把这些常数及其阶段/评价分支逐一唯一映射到 AC-97-FS-005，也不能排除其他 ICAO Doc 8168 版本、旧版国内规范或作者简化。因此状态统一记为“实现依据待确认 / STANDARD_BASIS_UNRESOLVED”。代码行为按恢复结果记录，没有为匹配规范而改写算法。

