# config与便携文件、外部程序关系

|通道|入口/协议|用途与边界|
|---|---|---|
|config.xml|Load P303→公共P0F4，Closed P304→P0F6；节点FormPA|通用dotted控件状态持久化，保存窗体支持的属性；不是P319分段协议|
|参数文件|P31C/P31D→P319/P31A，UTF8 .json/.txt|便携参数快照；可只导入OAS或全部；不含绘图模式/HL|
|实体XData|P306保存P319；P318读取|同参数快照，不含几何类型标签；不是完整CAD对象序列化|

Load先设默认再读config，实际控件事件可触发重算；Closed将当前状态持久化。默认值不代表原件config覆盖后的启动状态。本轮原config只读，不以恢复适配器写回。

## WsOasPara.exe

**No direct process invocation evidence found.** 全程序集唯一Process.Start位于其他Form的P395，A5事件闭包不可达。A5闭包中保护helper P888的GetCurrentProcess/Id不是启动外部程序；见global-process-calls.csv。未发现A5 ShellExecute、专用输出TXT路径或外部协议调用。通用文件对话框可打开用户提供的文件，不证明兼容该EXE输出格式。按范围不执行、不扩逆EXE。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P303|0x06000304 / 0x3FC0C|0x34E4C|23916|[证据](evidence/processed/0x06000303.il.txt)|
|P304|0x06000305 / 0x3FDCC|0x436B|24008|[证据](evidence/processed/0x06000304.il.txt)|
|P0F4|0x060000F5 / 0xA644|0xBC18|4166|[证据](evidence/processed/0x060000F4.il.txt)|
|P0F6|0x060000F7 / 0xAB28|0xBF28|4269|[证据](evidence/processed/0x060000F6.il.txt)|
|P318|0x06000319 / 0x41B08|0x36418|24747|[证据](evidence/processed/0x06000318.il.txt)|
|P31C|0x0600031D / 0x43558|0x37BD0|25487|[证据](evidence/processed/0x0600031C.il.txt)|
|P31D|0x0600031E / 0x43730|0x37CDC|25533|[证据](evidence/processed/0x0600031D.il.txt)|
