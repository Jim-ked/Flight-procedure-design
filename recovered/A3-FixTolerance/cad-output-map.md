# A3 CAD 输出与事件证据

| 事件 | 原token/RVA | 输入与退出 | 数据库输出顺序 |
|---|---|---|---|
| 定位容差CAD | 0600020F/19CD4 | 导航台S→引导方向Q，任一点Origin返回；DME指定距离数字失败Validate后提示返回 | KK late Line→KK early Line（若开）→楔形Polyline→Track Polyline（若开）→Polyline Group→DME late/nominal/early Arc→另Group→DBText（后三部分仅DME开） |
| 顶空/盲区CAD | 06000212/1A628 | S→读h/半角→可选入航点；h≤0返回；数字错不恢复Visible；入航Origin取消整次 | 可选Polyline1→Polyline2→Group→Circle |

| 实体 | 关键数据 | Z | Metadata/组 |
|---|---|---|---|
| KK两Line | 中心r+e与(r−e)cos a，各长18520；端点θ±π/2 | 0 | 无本事件WsCalcuLine/WsEntityFrame写入；未加Polyline组 |
| 楔形Polyline | 3顶点，bulge/startWidth/endWidth均0；未显式闭合 | 0 | 同组包含可选Track |
| Track Polyline | S→late两顶点，零bulge/宽 | 0 | 同上 |
| DME3Arc | r+e、r、r−e；θ−a→θ+a | Sz | 单独Group |
| DME DBText | D+NM文字+大写Suffix；Height500；未显式Rotation | Qz或0 | 不在三弧组 |
| 盲区Polyline2条 | VOR5/15、NDB15/25的端点组合 | 0 | 自己的组 |
| Circle | S、ZAxis、h tan半角 | Sz | 不在前述折线组 |

所有追加使用共享empty-metadata helper原0600008A/5878；分组helper原06000088/555C。代码使用AddDBObject而未登记GroupDictionary，Observer除了命名组字典还应采集Group对象事件；命名组表为空不能证明未生成组。

上述输出已恢复且AUTOCAD分支编译通过；不等于原DLL在宿主运行。EXPs 09/10必须分清实体追加顺序、Group对象事件与命名组条目，不把最后图面倒推成API调用序列。当前实测状态见 ../dynamic-test/experiment-index.md。
