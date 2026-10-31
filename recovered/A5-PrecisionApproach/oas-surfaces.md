# 五面方程、交线与域

共享字段：0096=W、0097=W*、0098=X、0099=Y、009A=Z（前缀_0088_0091_）。各Plane为 `z=A*x+B*y+C`；镜像几何与评价absY提供左右对称。THR为局部原点，正X指向进近上游，Z为相对THR数值高度；输出CAD前清Z。

|面|方程/交线|轮廓/domain|CAD|评价使用|
|---|---|---|---|---|
|W|Aw·x+Cw（DB B=0）|WX0到WXcap；AUTO到W/W* seam|跨中线闭合点列|P41B候选；P429候选，均orphan|
|W*|Aws·x+Cws（DB B=0）|仅AUTO，W/W*至W*/Xcap|AUTO额外分段|仅P41B mode2候选，orphan|
|X|Ax·x+Bx·absY+Cx|WX与XY交线，z0/cap，FAF/FAP另截断|正负Y各一轮廓|P41B/P429；无UI评价|
|Y|Ay·x+By·absY+Cy|XY与YZ交线，z0/cap，FAF/FAP另拼接|正负Y各一轮廓|同上|
|Z|Az·x+Cz（DB B=0）|YZ0与YZcap跨中线；部分CATI尾部延伸|对称轮廓/辅助尾部|同上|

P838面面交线 `(A1−A2)x+(B1−B2)y+(C1−C2)=0`；P839固定高度 `Ax+By+C−h=0`；P83A三点拟合。Plane Y求解除数0会依分子正负给±1000000，保留原退化语义。

## 共享P41B的孤立数值域

起始面高0/入口平面，严格max依W→X→Y→Z，AUTO最后W*；tie保留先到。mode1/2赢面>150则out。mode0在x≥YZcap.x时仅Y/Z且>300排除，W/X可高于300；x更小时按YZcap点向负X反向15°线侧限进入非精密延伸段，用Z面，否则out。10000只用于求线，未作为有限射线端点界限。out不保证覆盖输入Z。

CAD轮廓、数值面域、障碍物判定是三个不同证据层，不能把一个Polyline闭环直接当成P41B的contains规则。A5真正使用共享五面普通几何；没有B4 P5E0的固定同轴分段域。

## 证据与复核

E0＝原程序集身份/元数据；E1＝处理反编译；E2＝IL/字段/调用恢复；E3＝独立恢复源码检查；E4＝原插件运行，本轮无；N＝规范解释。Pxxx 指处理后 MethodDef 0x06000xxx，不是原 token。原方法可能为保护桩，token/RVA 不单独证明公式。

[方法身份、RVA及IL哈希](evidence/method-index.csv)、[恢复方法映射](evidence/recovery-method-map.csv)、[签名](evidence/signatures.csv)、[事件完整身份](evidence/event-identities.csv)。完整原/处理 IL 位于 evidence/raw 和 evidence/processed；按 token 命名。以下结论限于本构建和静态可见路径，不排除无法证明的外部反射调用。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|处理 IL|
|---|---|---|---|---|
|P412|0x06000413 / 0x647B4|0x523E0|42078|[证据](evidence/processed/0x06000412.il.txt)|
|P41B|0x0600041C / 0x65268|0x52DA4|42448|[证据](evidence/processed/0x0600041B.il.txt)|
|P838|0x06000839 / 0xCA208|0x63AE|84846|[证据](evidence/processed/0x06000838.il.txt)|
|P839|0x0600083A / 0xCA240|0x63DC|84851|[证据](evidence/processed/0x06000839.il.txt)|
|P83A|0x0600083B / 0xCA264|0x93234|84856|[证据](evidence/processed/0x0600083A.il.txt)|
