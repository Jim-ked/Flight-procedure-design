# 第一轮二十问：当前已证实答案

除特别注明外，为L1 Direct处理代码+L2处理IL/原token映射，不是原始运行证明。细节及源定位见各包。

1. **A2六页方法**：处理后CAD/计算token依次为FAF 22D/22F，NPA 232/233，PA 235/237，复飞TP 23A/23B，离场TP 23D/23E，C 240/241（均0x06000前缀）。完整名称及原token/RVA见A2/ui-event-map.md、evidence.md。
2. **真实公式**：FAF=(Hfaf−RDH−Hthr)/tan(GP)；NPA=(TAS+w)t/3.6；PA=Round((DH−HLcor)/tan(GP)+Xz)，HLcor=0返回−1；复飞TP=100(Hturn−Hsoc)/梯度百分数；离场TP=100(Hturn−Hder−5)/PDG百分数；C=(TAS+w)t/3.6。GP先转弧度。机场高>900时HLcor两次舍入，D类1800米最终52.1，而非52.12。
3. **18秒**：直接读取时间框，默认18；没有分别算3与15。
4. **6秒**：直接读取时间框，默认6；没有分别算3与3。
5. **GetPoint次数**：六个正常绘图路径各两次公共helper调用；helper遇错误输入可重试。FAF/复飞TP/离场TP逐点检查Origin并可能提早结束；NPA/PA/C两点取完只检查相等，不能概括成所有入口取消即退出。
6. **实体**：FAF/IF两条20km Line，可选4 DBText；NPA/PA/C各1条12km Line，可选1 DBText；复飞/离场TP各1条20km Line，可选2 DBText。不是DBPoint。详见A2/cad-interactions.md。
7. **A2 XData**：Line写WsCalcuLine：1001 app、1000类型文字、1000 JSON。文字不走同一参数写入。不能称纯无结构施工线。
8. **RandomPoint实体**：每点DBPoint+MText，即使名称/高度显示都关闭仍创建空MText。
9. **名称/高度**：DBPoint.Position.Z为高度；生成名由ObjectId字符串后缀得出，文字可显示名字/高度；本生成器不把名字另写XData。解析器先读已有WsEntityFrame名，无名再用后缀。
10. **RegApp**：RandomPoint直接不写；公共属性框架WsEntityFrame，通用非空描述WsObject，A2 WsCalcuLine。三者不能混同。
11. **xInfo**：GetEntity后读全部Entity.XData，逐TypedValue打印；手写递归格式JSON，不读ExtensionDictionary，不拼接250字符分片，不用serializer解析探针输出。
12. **ScreenData**：SelectAll，DXF类型DBPoint且410=Model；公共解析器直接取XYZ/序号ID/名称，表格Round XYZ两位。B4/B5随后在超过5点时提示并Take(5)；不是仅当前视口，也不是用户框选。
13. **共享解析器**：A7/A8/A9/A10/B3/B4/B5共享DBPoint→坐标模型解析器；这不等于共享所有评价算法。没有在此导入链发现树高叠加。
14. **Mark**：obst（A10字面量Obst），位置原DBPoint XYZ，默认scale1，无显式旋转/图层；Altitude写原Z，不是OCA。七窗已逐一核对，只有A8所查Mark另写Name，同setter已由IL确认。块缺失时从程序集目录首个WsSymbol*.dwg导入，不硬编码2.1，DWG内部布局仍未恢复。
15. **精度表**：A3事件硬编码VOR/ILS/NDB引导5.2/2.4/6.9，非引导4.5/1.4/6.2度；DME误差=.0125r+460米。未从oas.db读表。
16. **交叉定位**：本按钮实际上构造单台角容差及可选DME弧；没有第二设施输入/IntersectWith自动求两台交集。人工叠画解释为L4，不是已证实的自动求交。
17. **KK**：late轴向r+e；early轴向(r−e)cos(a)；各沿航迹垂线正负9260米成线。
18. **独立实体**：是，两条独立Line，不是Polyline的一部分，无KK文字。
19. **A3 XData**：已追踪绘图路径未传非空metadata、未另行写XData；不扩大成全程序集不存在属性。
20. **跨窗返回**：本A3事件未见返回其他窗体的计算对象；输出图面可被重新拾取。仅凭此不能证明软件所有路径都完全靠图面共享。

以上问题可给出静态答案，不代表用户要求的全部等价C#、各评价链和原生CAD输出均已交付。未满足项见README.md。
