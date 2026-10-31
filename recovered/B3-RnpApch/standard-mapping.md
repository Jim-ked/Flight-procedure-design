# 代码完成后的规范映射

基线：AC-97-FS-005，民航规〔2020〕12号。原PDF路径/全SHA256见evidence/standard-excerpts.json；PDF第499–519页摘录从冻结缓存读取并重新校验原PDF。以下用**PDF物理页号**，避免正文OCR页码倒序。仅作行为对照，不判软件整体适航/合规。

|已恢复行为|条文/PDF页|分类|结论与差异|
|---|---|---|---|
|LNAV最后主区MOC75，副区线性衰减|III-3-3 3.2.3–3.2.4，504–505|Matches current standard（局部规则）|75与副区原则一致；不能覆盖全部端点/航段设计|
|固定THR/444模板，无可移动MAPt对象|3.3.1–3.3.2，505|Author simplification|条文MAPt为飞越航路点且可向FAF移动；代码不建该对象|
|15°复飞扩张|3.3.4.2，505|Matches current standard（局部形态）|固定6814/3704、TP长度与其他终止规则仍不能仅凭角度宣布符合|
|APV FAS温度斜率和起点x0|4.3.4.2.5，512|Matches current standard（表达式结构）|h−tc−Hi与444，公式相符；不等于全温度模型验收|
|2.5/3.5角度检查仅提示继续|4.2.1、4.3.4.2.2，509–512|Author simplification|提示不能代表规范要求的程序限制已执行|
|单q，不自动分层FAS′/FAS″|4.3.4.2.4–.6，512–513|Different from current standard|未实现5000/10000ft自动转换；不能以用户手输Hi替代分层|
|APV FAP名义d与LNAV FAF共高输入|4.3.2，511|Implementation basis unresolved|代码角色确定，缺少规范分开的fix身份/程序终止关联|
|Xz A/B−900 C−1100 D−1400|4.3.4.4.2，513|Matches current standard（基本表）|常量来源可解释，不因此认定作者版本|
|Xz不受AdElev/VPA影响|4.3.4.4.3，513|Different from current standard|高于900m或VPA>3.2时条文另算min值；实现没有此分支|
|HLm/HLr A–D表|表III-3-4-2，515|Matches current standard（表值）|H35/8和未知回退D为额外代码行为|
|HL机场修正HLr*.02*elev/300|4.5.2.1，515|Matches current standard（表达式）|只在>900触发；显示/主业务round不同|
|HL陡角度增量(gp−3.2)*HLr*.05|4.5.2.2，515|Different from current standard|条文每0.1°加5%；代码没有÷0.1，增量为其1/10；原样保留|
|地面/侧面75或q降至30、Z面g|4.3.4.3–.4，513|Matches current standard（结构）|分段数值面，没有CAD拓扑闭合证明|
|当量障碍物高、侧面减e、全HL|4.4.1–.3，514–515|Matches current standard（公式家族）|实现额外Ceiling及字段复写/基准问题单列，不对全链背书|
|无所有障碍物max OCH调度|4.4.4，515|Different from current standard（可执行范围）|规范取进近与复飞最大值，B3没有可达批处理/合并|
|SOC小工具+444、固定宽度、APV双减q|本段未找到足够独立依据|Implementation basis unresolved|与简化模板相关；不能修成规范值|

未识别到足以鉴定其他具体ICAO Doc8168版次/旧国内规范的证据。Older-version candidate没有被强行分配到某条；所有历史归因统一标“**实现依据待确认**”。差异不自动证明是旧版依据，也可能是作者简化/代码错误。
