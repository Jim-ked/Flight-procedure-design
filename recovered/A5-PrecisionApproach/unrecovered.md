# 未恢复/未验证项及保留异常

|事项|当前结论|后续所需证据|
|---|---|---|
|A5障碍物/HL/最低标准调度|本构建未发现入口，P41B/P429完整而orphan|另一可信构建或明确外部调用证据；不能靠补接称恢复|
|原插件运行等价|无E4，只有E3源码检查|若另行授权，独立运行环境与可审计输入/图元结果|
|完整WinForms重建|designer/控件/事件静态索引完整；恢复源码是切片|宿主UI事件时序、config覆盖与自动重算的验证|
|CAD宿主最终属性/限制|writer无显式layer/color/Closed；未执行宿主|宿主默认、超长XData、取消/异常的真实行为|
|规范版本/数据库来源|按2020规范映射，差异实施依据待确认|作者来源/历史标准/原始计算表；不扩逆新版PANS-OAS|
|PAOAS异常点Z|P428跨点赋值直接证据，原样保留|用途/作者解释未知；不修正|
|FAF/FAP局部第二三角形|P43A/B与P446/447构造但未Add|原构建事实，不能补画后声称原行为|
|GPINOP尾部15°|P3A7无incoming|不能声称可达，也不推断作者意图|
|文件兼容|A5四段JSON，无旧CSV dispatcher|WsOasPara输出实际协议关系未证明；本轮不扩逆|

无因上述缺口暂停阶段推进；它们已作为收口限制逐项记录。所有本轮可静态恢复的正常链已完成。验收按用户规则为PARTIALLY ACCEPTED，之后停止，不进入新业务模块。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P3A7|0x060003A8 / 0x5D86C|0x4D1F8|38599|[证据](evidence/processed/0x060003A7.il.txt)|
|P428|0x06000429 / 0x672F4|0x549AC|43673|[证据](evidence/processed/0x06000428.il.txt)|
|P429|0x0600042A / 0x679E0|0x55010|43908|[证据](evidence/processed/0x06000429.il.txt)|
|P43A|0x0600043B / 0x692E4|0x56454|44717|[证据](evidence/processed/0x0600043A.il.txt)|
|P43B|0x0600043C / 0x69490|0x565B4|44812|[证据](evidence/processed/0x0600043B.il.txt)|
|P446|0x06000447 / 0x6A1BC|0x56DF0|45099|[证据](evidence/processed/0x06000446.il.txt)|
|P447|0x06000448 / 0x6A334|0x56E9C|45120|[证据](evidence/processed/0x06000447.il.txt)|
