# 规范对照与实现依据待确认

规范基线为项目 AC-97-FS-005 / 民航规〔2020〕12号。PDF SHA256 `6b6b6f04380f3e0a138ca57bb95fcddb0a390a5b4aa7a9c7a391ff35bb92c8ed`。页码为物理PDF页，不是印刷页；摘录见 [standard-search.json](evidence/standard-search.json)。以下先列恢复行为，再作N层对应；没有按规范修代码。不能仅据公式相近断定作者依据某版ICAO Doc8168。

|主题|代码事实|当前规范候选|分类/差异|
|---|---|---|---|
|CAT I/II cap|P411/P412 300/150m|PDF275 OAS height domains|Matches；cap alone does not prove complete standard-compliant geometry|
|AUTO W/W*|P307/P412 combine W and Wstar; distinct DB key|PDF276 AUTO additional Wstar/X changes|Matches；table provenance/version not established|
|dimensions/RDH|P40B/P40C copied corrections|PDF276 s/t/RDH corrections|Matches；numeric model verified; full table authorship unresolved|
|PAOAS P1/P2|P1=(Round(tanGP,4),.091,5), P2=(0,.091,15)|PDF318-320 appendix D, table D-1|Matches；UI allows arbitrary coefficients; rounded tan|
|PAOAS terminal|P428 fixed 600m|PDF318-320 terminal relative to radar minimum altitude minus300|Differs；no minimum radar altitude reader; Implementation basis unresolved|
|GPINOP|current OAS seam + fix/IF projection; no force3deg; no invoked P3A7|PDF270 1.1.7 NPA/LOC-only treatment|Implementation basis unresolved；incomplete LOC-only relationship; no reached evaluation|
|FAP nominal station|(F-THR.Z)/tanGP; no RDH/curvature|PDF272 1.4.2; PDF316-317 distance tables|Differs；Author simplification candidate; not corrected|
|FAF tolerance|single early x+T; default700; no900 check|PDF272 1.4.3 max +/-0.9km candidate|Differs；negative/oversized T not guarded; terminology mapping conditional|
|FAF descent plane|.15 slope via 1000/150 point delta|PDF272 1.4.3 15 percent plane|Matches；matching slope does not establish full method equivalence|
|intermediate segment|IF=fix.x+L, inner4630 outer9260, H-150/H|PDF272 intermediate/FAP connection context|Implementation basis unresolved；no facility/tolerance derivation for fixed widths in this path|
|HL/minima|no A5 implementation or event chain|PDF277-278,286 OCA/HL and correction tables|Missing；do not insert B3/B4 formulas|
|OAS truncation|P437/P443 numerical intersections + IF clamp|PDF272 descent-fix/FAP candidate|Implementation basis unresolved；unadded local triangles retained; no claim of full compliance|

差异统一记录“**实现依据待确认**”。Older-version candidate / Author simplification只作为待核假设，未以现有材料确认历史规范版本。W/W*、15%、P1/P2常数对应不证明其余域/截断/评价均与2020版一致；A5无HL也不能解读为规范允许省略。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P307|0x06000308 / 0x401EC|0x3537C|24174|[证据](evidence/processed/0x06000307.il.txt)|
|P40B|0x0600040C / 0x64280|0x5207C|41867|[证据](evidence/processed/0x0600040B.il.txt)|
|P40C|0x0600040D / 0x64454|0x52218|41965|[证据](evidence/processed/0x0600040C.il.txt)|
|P412|0x06000413 / 0x647B4|0x523E0|42078|[证据](evidence/processed/0x06000412.il.txt)|
|P428|0x06000429 / 0x672F4|0x549AC|43673|[证据](evidence/processed/0x06000428.il.txt)|
|P437|0x06000438 / 0x68AF8|0x55DA8|44470|[证据](evidence/processed/0x06000437.il.txt)|
|P443|0x06000444 / 0x699B8|0x56848|44929|[证据](evidence/processed/0x06000443.il.txt)|
