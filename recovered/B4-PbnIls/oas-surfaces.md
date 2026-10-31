# 曲面、区域与裁剪

## 面方程与交线

PlaneCarrier P834–P840完整恢复：z=A*x+B*y+C，评价先取a=abs(y)。两平面交线为(A1−A2)x+(B1−B2)y+(C1−C2)=0；固定高度h线为Ax+By+C−h=0；三点拟合系数由行列式求解。除数0时按分子>0给+1000000，否则−1000000；不改成几何异常。

共享OAS：W∩X、X∩Y、Y∩Z在z=0和cap求交点；AUTO另有W*∩W及W*∩X。P412构造线性轮廓。P41B评价以0/入口平面起步，严格max依次W→X→Y→Z，AUTO最后W*；同值保留先到标签。不是min，也不是多行候选输出。

|共享P41B条件|实际domain|
|---|---|
|mode1/2|最大面高>150则out，否则赢面；AUTO含W*|
|mode0，x≥Y/Z-cap点.x|只有赢面为Y/Z且>300被排除；W/X可高于300|
|mode0，x<Y/Z-cap点.x|构造cap点向负X、由−15°方向反向延伸10000m的辅助线；a≤线y(x)则非精密延伸段并用Z面；否则out|

辅助10000只用于求直线，未检验射线有限端点；out延伸分支不一定更新输入点Z。共享P41B无静态incoming，不能称其为B4界面实际评估结果。

## B4专用P5E0逐分支决策表

定义 E=P5DF的SOC处点，A=15°辅助线到y3704点，B=Y/Z交线到y1852点，D=Y/副区面交线到y3704点；按下表源码顺序判断，**不排序这些站距**。初始最大0、标签入口平面。

|首个满足条件|按顺序候选|侧限/排除|副区比例字段|
|---|---|---|---|
|x>E.x|W,X,Y|仅Y赢且面高>300→out|不设置|
|else x>A.x|W,X,Y,Z|仅Y赢且a>辅助线y(x)→out|不设置|
|else x>B.x|W,X,Y,Z|仅Y赢且a>3704→out|不设置|
|else x>D.x|Y,Z,Z面副区|任意赢面，a>3704→out|max(0,(a−1852)/1852)|
|else|Z,Z面副区|同上|同上|

严格取max；tie保留早先标签（包含入口平面0）。专用模型**没有W***、mode或150m CATII上限；部分前段侧限只对Y赢面生效，所以不能改写为通用polygon contains或“所有面均限3704”。无额外x最大/最小距离测试，后端有限绘图点不构成评价域截断。

所有分支最后写surface=max、penetration=原记录Z−surface，即使标签out也保留这些值。若复用同一record，前3段不清空旧比例字段；P567还会把该字段改写为HL。测试及消费者必须知道这一状态语义。

证据等级：E0 原件身份/元数据；E1 去混淆/反编译；E2 IL、字段和调用恢复；E3 独立恢复源码测试；E4 原插件运行，本轮无；N 规范对照/解释。原始 DLL 中的保护桩不能当作明文算法事实。Pxxx 是处理后 MethodDef 0x06000xxx 的简写。

## 关键定位

|P|原 MethodDef / RVA|处理 RVA|反编译行|
|---|---|---|---|
|P412|0x06000413 / 0x647B4|0x523E0|42078|
|P41B|0x0600041C / 0x65268|0x52DA4|42448|
|P5DE|0x060005DF / 0xB2CB0|0x844F4|71771|
|P5E0|0x060005E1 / 0xB36EC|0x84CAC|71916|

完整原/处理 IL、哈希及签名见 [method-index.csv](evidence/method-index.csv)、[signatures.csv](evidence/signatures.csv)；IL 按 token 存于 evidence/raw 与 evidence/processed，源码摘录存于 evidence/methods。
