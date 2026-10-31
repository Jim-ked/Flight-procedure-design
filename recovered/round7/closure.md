# Round 7 Closure

**Round 7: PARTIALLY ACCEPTED (static recovery)**，2026-10-28。仅B4；Round1–6及原材料冻结；本轮不运行目标DLL/AutoCAD，不补接评价或KML，不进入A5。

## 33项逐条答复

|序号|问题|答复|证据报告|
|---|---|---|---|
|1|B4到底是什么业务组合？|OAS参数/修正+同轴固定宽度复飞衔接绘图；另有无调度数值评价/最低标准方法。不是已实现的任意PBN转弯链。|[定位](../B4-PbnIls/overview.md)|
|2|是否有统一程序对象？|无。Form保留源点/ID/HL表；参数模型和CAD模型临时构造。|[定位](../B4-PbnIls/overview.md)|
|3|OAS和PBN转弯是否同一业务类？|四面OAS及同轴衔接同属_008C_0095；参数用另一共享_008A_0093。没有任意转弯业务可据此合并。|[定位](../B4-PbnIls/oas-pbn-connection.md)|
|4|W/W*/X/Y/Z真实来源？|oas.db解码→尺寸/RDH修正→UI舍入；亦支持手输、TXT、config回填。W*仅共享模型/保存，专用模型未读。|[定位](../B4-PbnIls/oas-parameter-model.md)|
|5|是否查询oas.db？|是，P570可达调用私有P571，查PartA与PartB；非仅项目同名文件推断。|[定位](../B4-PbnIls/oas-parameter-model.md)|
|6|每个surface方程？|各面z=A*x+B*absY+C；加0入口平面严格max，副面三点拟合。|[定位](../B4-PbnIls/oas-surfaces.md)|
|7|domain如何裁剪？|专用评价按E/A/B/D四个X阈值分5段、部分只对Y限侧宽，后段统一3704；共享模型按mode/cap/辅助线另分。|[定位](../B4-PbnIls/oas-surfaces.md)|
|8|CAT II AUTO专门实现？|数据库mode2、共享模型W*/150存在；B4专用绘图/评价没有W*或mode/cap150分支。不能称完整AUTO。|[定位](../B4-PbnIls/oas-parameter-model.md)|
|9|HL公式？|HLm+(e>900?HLr*.02*e/300:0)，四行A-D；SOC不round HL，后处理round增量2位；显示支路round总和。无GP修正。|[定位](../B4-PbnIls/hl-correction.md)|
|10|与B3同MethodDef？|否。B3 P5F2含GP项，B4 P55F/P567/P56A独立。|[定位](../B4-PbnIls/hl-correction.md)|
|11|FAF/FAP代码角色？|FAF标高控件只生成FAF−THR−150绘图高度请求；无FAP/FafFix坐标对象。|[定位](../B4-PbnIls/faf-fap-mapping.md)|
|12|DH进入哪里？|输入DH进入P55E算SOC，再传P5DF衔接；不直接进P5E0。每障碍物输出DH由P567另算，无回写。|[定位](../B4-PbnIls/hl-correction.md)|
|13|PBN转弯输入？|无TP/出航点/左右转；只有THR/end两点。无真实多点转弯语义可恢复。|[定位](../B4-PbnIls/pbn-turn.md)|
|14|ATT/XTT/SW来源？|未发现；1852/3704为硬编码内外半宽，不能据数值标RNP1。|[定位](../B4-PbnIls/navigation-tolerance.md)|
|15|是否用P793？|B4核心/事件闭包未调用。|[定位](../B4-PbnIls/pbn-turn.md)|
|16|是否用Spiral86？|未找到构造/采样/评价调用；编译基础依赖不代表原调用。|[定位](../B4-PbnIls/pbn-turn.md)|
|17|15°作用？|P5DF相对300m交点连线减15°得到扩张辅助线；共享CATI另有非精密延伸射线。都不等于完整转弯。|[定位](../B4-PbnIls/oas-pbn-connection.md)|
|18|OAS/PBN如何连接？|SOC处E→15°线到3704；YZ线到1852；外侧+30拟合副面；Y/副面相交→对称轮廓。任意后续转弯未实现。|[定位](../B4-PbnIls/oas-pbn-connection.md)|
|19|OAS障碍物公式？|P41B共享面max与域；B4专用P5E0候选max，穿透=记录Z−surface。两者未调度。|[定位](../B4-PbnIls/obstacle-evaluation.md)|
|20|PBN障碍物公式？|后段Z/副面max、a≤3704；fraction=max(0,(a−1852)/1852)，P567用fraction*30修正Ha。|[定位](../B4-PbnIls/obstacle-evaluation.md)|
|21|多候选如何合并？|单记录在当前分段内严格max面高、tie先到；不是max OCA或多行结果。没有可达全障碍物控制结果汇总。|[定位](../B4-PbnIls/obstacle-evaluation.md)|
|22|OCA/OCH怎样得到？|P567对穿透>0做进近/Ha分支，加HL；保留进近分支绝对高混用；DA/DH/RVR再后处理。|[定位](../B4-PbnIls/obstacle-evaluation.md)|
|23|所有evaluator UI可达？|否。P5E0/P567/P41B全局静态incoming均空，Evaluate只提示；不补接。|[定位](../B4-PbnIls/event-map.md)|
|24|Take5影响哪层？|SelectAll后、parser前；源列表、ID/初始表、转换表及Mark/Highlight只保留前5。|[定位](../B4-PbnIls/obstacle-evaluation.md)|
|25|第6点能否绕过？|数学接口无截取但没有UI绕过证据；P557可收任意List但无调用，不等同入口。|[定位](../B4-PbnIls/obstacle-evaluation.md)|
|26|CAD实体？|边界2D Polyline+Group，通常12或9条；Mark另插obst BlockReference与Altitude属性。|[定位](../B4-PbnIls/cad-output-map.md)|
|27|是否创建3D surface？|否；数值面/三维内存点列经清Z及Point2d写二维折线。|[定位](../B4-PbnIls/cad-output-map.md)|
|28|哪些XData？|每折线WsObject+完整自定义OAS TXT；Group无描述/XData，无Kind/Radius独立字段。|[定位](../B4-PbnIls/xdata-schema.md)|
|29|KML导出区域？|无，绑定P56D空体；没有业务区域/坐标/样式输出。|[定位](../B4-PbnIls/kml-export.md)|
|30|KML能确认列表语义？|不能；只能按CAD顶点/面来源解释，kml-cad-map对应项为N/A。|[定位](../B4-PbnIls/kml-export.md)|
|31|与A5共享？|共享OasModel/Plane/公共CAD writer同MethodDef；DB schema相同但B4私有loader/decoder/尺寸/RDH为独立复制算法。|[定位](../B4-PbnIls/oas-parameter-model.md)|
|32|与B3共享？|frame、SelectAll/parser、APV obstacle carrier、Mark/Highlight和writer；不共享APV面/HL算法/状态TXT格式。|[定位](../B4-PbnIls/runway-frame.md)|
|33|与B5共享？|frame及公共导入/Mark/writer；Take5是不同事件中的相同截取；无B4 P793/风螺旋或TurnEnd复用。|[定位](../B4-PbnIls/pbn-turn.md)|

## 验收矩阵

|项目|恢复状态|
|---|---|
|OAS参数/数据库/系数修正|静态闭合；原行/hash/定长解码保存|
|OAS面/域|共享/专用两套均恢复；专用缺W*与CATII分支等异常保留|
|PBN任意定点转弯|未找到实现，不以同轴衔接冒充|
|OAS→固定宽度衔接|点线/面/轮廓闭合；后续任意转弯未闭合|
|障碍物评价/最低标准|方法体恢复，UI调度缺失；无控制障碍物归并|
|事件可达性/Take5|已核对；第6点UI绕过未发现|
|CAD|列表到二维Polyline/Group及XData静态链闭合；未宿主执行|
|KML|空方法已证实；导出功能缺失|
|规范映射/跨模块关系|按证据及授权边界完成；实现依据未强归版本|

## 验证材料

分层数字与范围见 [verification.md](../B4-PbnIls/verification.md)、[tests.log](tests.log)、[static-tests.json](static-tests.json)。所有计算验证为独立恢复源码E3，原DLL运行E4为空。冻结完整性最终结果见 [integrity-report.json](integrity-report.json)，输出文件hash见 [output-manifest.json](output-manifest.json)。

## B4 → A5 可复用的已恢复层

可复用OasModel/Plane的原MethodDef与域决策、数据库schema/key/解码验证、尺寸/RDH修正公式、公共2D CAD writer、参数TXT结构和通用障碍物管线。必须识别B4专用四面衔接与共享五面模型的边界，不能把前者代替A5。

**A5仍有必要逆向，但可以改为差异恢复。** 优先检查A5真实事件/评价调度、共享P41B为何没有incoming、CATII/AUTO的实际输出、HL和Ha/最低标准、FAF/FAP及配置/序列化差异。无需从零重做本轮已恢复的共享数值层。此为下一轮建议，本轮不启动。
