# 人工CAD交互及可自动推导条件

|入口/API|用户选什么业务对象|为什么由用户提供（代码能证明的范围）|结果进入哪里|可由已有数据推导？（推断）|
|---|---|---|---|---|
|P314→GetPoint|THR入口三维坐标|A5无跑道对象ID或机场数据库检索；只存文本坐标|THR XYZ→相对H、frame、参数快照|若项目已有跑道坐标可直接赋值；本构建未实现自动检索|
|P315→GetPoint|跑道另一端三维坐标|同上；未根据跑道号/长度自动生成|end XYZ→方向frame；swap可交换|需外部可靠跑道方向/端点，当前参数本身不足唯一确定|
|P316两次GetPoint|IF航段起/终点|没有程序航段对象关联，人工量距|3D DistanceTo→F2→IF长度L|若已有同坐标IF/fix可算长度；代码不选择对象、未投影至航迹|
|P317两次GetPoint|FAF点及FAF最早点|没有设施/定位容差对象或模型ID|3D DistanceTo→F2→容差T→FAF下降面|若已有定位误差可直接填T；本轮不替作者生成容差|
|P318→GetEntity|带参数的OAS相关实体（没有类型筛选，实际可选任意实体）|无实体注册表、无自动选唯一当前快照|XData[1]→导入选项→P31A控件回填|若保存图元ID/当前参数可免选；多组参数时不能无依据选唯一|
|P31B对话选择|全部参数或仅OAS|由用户决定是否覆盖跑道/进近/P1P2|full布尔控制P31A|可由调用意图指定，原实现交互决定，默认仅OAS|
|P31C/P31D文件对话|存/取便携参数文件路径|无固定项目参数文件注册|UTF8读写→P319/P31A|可由项目元数据指定；原逻辑不自动推导|

P313 swap不选实体，直接交换六个文本。各GetPoint通过公共helper，非按实体类型/业务ID拾取；窗口隐藏、SetFocus后取点再恢复。取消/异常路径保留原方法证据，未宿主测试。GetSelection未见A5核心调用；SelectAll词法候选来自共用依赖，不能算A5障碍物导入。

数值面间交线、截断、左右镜像和轮廓列表已代码化；没有依赖人工选边才能计算这些交线的事件。后续人工观察/编辑的具体规则缺少代码证据，标未确定，不凭“没有自动裁剪”就杜撰手工流程。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P313|0x06000314 / 0x41498|0x360D0|24621|[证据](evidence/processed/0x06000313.il.txt)|
|P314|0x06000315 / 0x41610|0x36188|24652|[证据](evidence/processed/0x06000314.il.txt)|
|P315|0x06000316 / 0x41768|0x36240|24674|[证据](evidence/processed/0x06000315.il.txt)|
|P316|0x06000317 / 0x418A8|0x362EC|24691|[证据](evidence/processed/0x06000316.il.txt)|
|P317|0x06000318 / 0x419E8|0x3638C|24726|[证据](evidence/processed/0x06000317.il.txt)|
|P318|0x06000319 / 0x41B08|0x36418|24747|[证据](evidence/processed/0x06000318.il.txt)|
|P31B|0x0600031C / 0x43518|0x4391|25482|[证据](evidence/processed/0x0600031B.il.txt)|
