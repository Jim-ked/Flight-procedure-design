# 指定高度转弯

## 输入与事件

P500读取 IAS、转弯标高H、bank、wind、temperature，P793实参顺序为 `(IAS,H,bank,wind,temperature)`，IAS/Wind按各自开关乘1.852。P503 CAD先检查H−DER.Z<186，拒绝时只提示；等于186不因该检查拒绝。gBefore、gAfter由百分数/100输入。checkBoxEarlyTurn传P5C8第8参，语义为允许DER之前转弯。

P505/P506显示TP=Round((H−DER.Z−5)/gBefore,1)；g=0保留旧显示。业务构造器没有相同保护，直接除法。P504 KML仍调用同一P5C8构造器，但丢弃几何，只载入/另存kmlTemplate.xml；无保护区点写入证据。反编译器把实参重排，不存在第二种“数字在前”ctor overload，P504 IL_002D–0098可核验。

## 业务完整阶段

1. P5C8保存DER/THR/TurnEnd、turn、两梯度、early。
2. d=(H−DER.Z−5)/gBefore；c=d+(TAS+wind)/.6，单位km/h时等价6秒位移；固定300、600、tan15°，宽度封顶3704。
3. P5CC构造直线/转弯起始点组；c<6351.95抛“本软件不支持过低的转弯高度，请检查。”，与Form186m检查并非同一判据。
4. 初始所有点flatten→P7D9 gift-wrapping hull，存初始Hull。
5. P5CB选择早转/DER侧起点，经75°判断镜像，构造StartArea并旋转/平移追加；early时另加DER与early点连接四边形。
6. P5C9自有多spiral外边界，P5CA末端连接，详见altitude-turn-geometry。
7. 现在全部绘图点flatten→P7D9，形成最终评价Hull；P5CD用它先判包含，再按KK/DER/侧方几何评价。

后续段是从选择的起始侧点到TurnEnd的有限15°扩张点组及螺旋末端连接，不是任意多航段PBN路由器。未发现自动识别前后CAD实体、布尔裁剪或通用接续下一程序对象的调用。
