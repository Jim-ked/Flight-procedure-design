# A3 规范基线与实现依据

基线为 doc/航空器运行目视和仪表飞行程序设计规范.pdf（AC-97-FS-005，民航规〔2020〕12号，SHA-256 6b6b6f04380f3e0a138ca57bb95fcddb0a390a5b4aa7a9c7a391ff35bb92c8ed）；页级提取 recovered/round5/standard-pages.json（SHA-256 6fe0dcd777a9cc58b40aad3f5752fdefaab420ae35d22f271b8b81c7e39965ac）。

规范页能区分导航台精度和保护区发散，但不能把A3的5.2/4.5、6.9/6.2、2.4/1.4、40/50、5/15、15/25、.0125r+460、9260逐一唯一映射到AC-97-FS-005。A4的VOR7.8°/NDB10.3°是保护区发散，不能替代A3精度角。全部标记IMPLEMENTATION_BASIS_UNRESOLVED，不修改代码。
