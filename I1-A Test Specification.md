# I1-A 可编码测试规格

版本I0.6 r1，2026-10-31。本文定义预言，没有宣称已实现／已执行这些未来Native测试。Legacy已有测试保留。所有Resolved结果均断言Trace含输入ID/版本、RuleContext、RuleSpec/条款、AlgorithmSource与输出版本；所有拒绝分支均断言无可用默认数值、无新AcceptedGeometry、无有效MOCA。

## 公共夹具
F-W：FixedWing A、Arrival、RNAV1、SensorSet={BasicGNSS}、TrackGuidance=true、过程内不变，其他类别B至E参数化运行。RC=STD-R1/2021-10-13/I0.6-r1，FrameId=SyntheticMetricFrame-1，坐标为正交米制，1NM=1852m；数值表用NM表达时输入须转换。NormalConditionsConfirmed=true，SpecialMocRequirement=None。所有ObstacleTop为绝对标高m，DatumId=TestOrthometricDatum；覆盖声明合成完整、水平不确定性0、垂直余量0。

F-T：以NM标注，ARP=(0,0)，有向直线S=(40,0)至E=(20,0)，s从S沿负x方向增加；sc=10 NM，s0=7.401923788647 NM，s1=11.732050807569 NM，L=20 NM。坐标和长度计算使用m。

F-O：独立局部几何测试，S=(0,0)m至E=(10000,0)m，H=2000m、P=1000m、Ws=1000m、MOCp=300m。绝对Z=100m。该夹具用于OBS通用拆分与插值单元测试，不冒充RNAV1表宽。集成测试必须使用F-T解析profile。

F-I：在F-T的sc截面放置三个点，坐标以NM表示、Z以m表示：A=(30,0),Z100；B=(30,2.625),Z300；C=(30,4),Z10000。预期A主区候选400，B副区中点候选450，C区外无候选；有效MOCA_raw450，控制障碍物B。

预言容差：位置/宽度1e-6m、余度/标高1e-6m、角度1e-10rad；这是数值验证精度，不是规范给定容差，也不是边界内缩。严格等号使用可精确表达的局部点和profile控制点；无法可靠决定符号时必须NumericAmbiguity。拒绝测试比较代码与状态，不比较自由文本。

## Width
| ID | 输入 | 预期状态及数值 | 必须检查 |
|---|---|---|---|
| W01 | F-W，r=31NM | Resolved；XTT2、ATT1.6、BV2、H5NM | P=Ws=2.5NM；总宽10NM |
| W02 | F-W，r=29NM | Resolved；XTT1、ATT0.8、BV1、H2.5NM | P=Ws=1.25NM |
| W03 | r=30NM | 稳态查询采用外侧XTT2、ATT1.6、BV2、H5 | Trace标DD-I06-002；不可覆盖T02的Hc |
| W04 | SensorSet={DME/DME} | RuleResolutionRequired/NAV-CONTEXT-UNSUPPORTED | 不返回GNSS宽度 |
| W05 | 其他／未知／{GNSS,DME/DME} | 同W04 | 不把多传感器简化为GNSS |
| W06 | W01/02转m | H9260/4630；ATT2963.2/1481.6 | 不是取整米表ATT反算 |
| W07 | H类、RNAV2、Approach或未声明Frame | 前三者RuleResolutionRequired/NAV-CONTEXT-UNSUPPORTED；Frame缺失InvalidInput/FRAME-MISSING | 不把A至E表用于H |
| W08 | 过程内GNSS→其他或RNAV1→其他 | UnsupportedScenario/NAV-CONTEXT-CHANGES | 无部分旧政策沿用 |

## Transition
| ID | 输入 | 预期状态及数值 | 必须检查 |
|---|---|---|---|
| T01 | F-T全连续航迹 | Resolved；唯一sc=10NM，Q=(30,0)NM | 解析求交，不选最近Fix |
| T02 | F-T政策输入 | Hout5、Hc3.5、Hin2.5NM；s0/s1如公共夹具 | 外边界夹角30°；P(sc)=Ws(sc)=1.75NM |
| T03 | 查询s0/sc/s1及两端微邻域 | H连续为5/3.5/2.5；过渡长4.330127018922NM | 无阶跃；ATT不平移交点 |
| T04 | (-40,30)→(40,30)NM | UnsupportedScenario/ARP30-TANGENCY | 重根，无符号变化，不算穿越 |
| T05 | (40,40)→(50,40)NM | UnsupportedScenario/ARP30-NO-CROSSING | 无Protection输出 |
| T06 | (40,0)→(-40,0)NM | RuleResolutionRequired/ODQ-ARR-001 | 两个有效穿越；不选第一个 |
| T07 | 交点位于Turn TrackFragment | UnsupportedScenario/TRACK-TURN-UNSUPPORTED | 不调用Legacy转弯补齐 |
| T08 | F-T插入(35,0)、(30,0)、(25,0)Fix分段 | 与T01/02相同；共享交点去重 | 共线Fix不引入ATT延迟 |
| T09 | F-T逆向E→S | UnsupportedScenario/WrongCrossingDirection | inside→outside不处理 |
| T10 | S=(30,0)→(20,0)NM | UnsupportedScenario/ARP30-ENDPOINT | 缺交点上游邻域 |
| T11 | S=(31,0)→(29,0)NM | UnsupportedScenario/TRANSITION-EXTENT-UNSUPPORTED | 不能容纳完整过渡，不截短 |
| T12 | 另一WidthTransition接触或重叠 | UnsupportedScenario/TRANSITION-EXTENT-UNSUPPORTED | 不做无依据的合并 |
| T13 | 两段均Straight但非共线且相连 | UnsupportedScenario/TRACK-TURN-UNSUPPORTED | 不把折线折角当Straight only |
| T14 | 近切点，误差区间包含判别式0且不能可靠定符号 | RuleResolutionRequired/NUMERIC-AMBIGUITY | 不自动合并双交点或判为单交点 |

## Primary Secondary 与退化
| ID | F-O输入，除另注明 | 预期 | 检查量 |
|---|---|---|---|
| O01 | Q=(5000,500)m | Primary；MOC300；Candidate400 | s5000、y500 |
| O02 | Q=(5000,1000)m | Primary；MOC300；Candidate400 | 主区等号含边界 |
| O03 | Q=(5000,1500)m | Secondary；MOC150；Candidate250 | Y500、Ws1000 |
| O04 | Q=(5000,2000)m | Secondary；MOC0；Candidate100 | 外边界不被预筛丢弃 |
| O05 | Q=(5000,2001)m | Outside；MOC=None；Candidate=None | 返回记录，不参与max |
| O06 | y=P、P+Ws/2、H | 分别300/150/0 | 内边界归Primary |
| O07 | Q=(0,500)、(10000,500)m | 两端Primary，MOC300 | 闭合首尾 |
| O08 | Q=(-1,0)、(10001,0)m | Outside | 不生成端部圆帽 |
| O09 | 左右对称y=±1500 | 相同分类和MOC150 | 坐标法向符号不改变结果 |
| O10 | L=0或Ws=0，或H≤P | InvalidInput/退化诊断 | 无NaN、哨兵或默认全MOC |
| O11 | H0=2000,H1=1000，L10000；s5000,y1125 | P750、Ws750、Y375；Secondary/MOC150 | 用同s截面，非斜边最短距离 |
| O12 | 两共线片段共享端点同ObstacleId | 一个统一结果，保留来源；候选不重复累计 | 多上下文控制取max非平均 |
| O13 | F-T在sc处，y=2.625NM | P1.75、H3.5、Ws1.75NM；MOC150 | 集成使用真实transition profile |
| O14 | NaN/Infinity或Datum/Frame不一致 | InvalidInput | 无有效Evaluation |
| O15 | 任意手改多边形，无Track/Profile映射 | RuleResolutionRequired/GEOMETRY-MAPPING-MISSING | 不能仅凭PointInPolygon通过 |

## MOC 与结果语义
| ID | 输入 | 预期 | 防止错误 |
|---|---|---|---|
| M01 | 普通条件已确认，F-W有效Arrival | 主MOC政策300m，副区线性300→0 | 值来自RS-ARR-MOC-001 |
| M02 | 已知山区≥20kt风／需附加MOC | RuleResolutionRequired/SPECIAL-MOC-REQUIRED | 不自动套300或600 |
| M03 | 普通条件Unknown | RuleResolutionRequired/NORMAL-CONDITIONS-UNCONFIRMED | 无静默默认 |
| M04 | 同基准Primary Z100、Secondary中点Z300、Outside Z10000 | 候选400、450、None；MOCA_raw450；控制第二点 | Outside高点不控制；ProcedureAltitude未产生 |
| M05 | 空数据集或全部Outside | NoControllingData，MOCA_raw=None | 不返回0/安全 |
| M06 | 数据覆盖Incomplete | 可以列逐点候选，整体Incomplete、MOCA_raw=None | 不把局部max称有效MOCA |
| M07 | 起点Z50、障碍物绝对Z100，主区 | Candidate400，不是350 | 不能用Local的z-sz |
| M08 | Z100，垂直余量10，主区；另测已含余量标志 | Candidate410；不重复加10 | 同基准、余量只加一次 |
| M09 | 水平不确定性>0或垂直基准未知 | RuleResolutionRequired/足迹要求或InvalidInput/基准 | 不当精确点处理 |

## Legacy差异回归
L组用A9局部轴 x=-s、W=H、startMoc=endMoc=300、绝对Z100；保留既有锁定夹具，本组是新增编码规格，不改Legacy输出。

| ID | 输入 | A9预言 | Native预言 |
|---|---|---|---|
| L01 | 等宽H2000，L10000，x=-5000,y2000 | 预筛y<maximum失败，无结果 | Secondary/MOC0/Candidate100 |
| L02 | Normal x=0或-L，y500 | 严格首尾过滤，无结果 | Primary/MOC300 |
| L03 | IF，x=-L/2,y1500，等宽2000 | primary=1500，Primary/MOC300 | P1000，Secondary/MOC150 |
| L04 | Normal内部，x=-5000,y1500 | Secondary/MOC150 | 同值；Trace仍不同 |
| L05 | IF，L0、W2000，x0,y0，端点MOC均300 | moc中间值NaN；两条LineY均为-1000000，点不通过，返回空列表 | InvalidInput/DEGENERATE-TRACK；不要求与Legacy相等 |
| L06 | Local计算起点Z50、点Z100后事件恢复Z | Local差值50，事件评价使用绝对100，OCA400 | Candidate400；不把OCA字段直接当集合MOCA |

L05按恢复源码的IEEE浮点与LineY分支推导，编码时同时对原Provider运行确认；不改变已锁定行为，也不提升A9退化域的RuleMapped状态。空结果不能解释为该退化域安全。

## Dependency 与流程
基于已保存并重开的F-T项目，每次变化先断言旧输出版本未变、计算调用数0、AcceptedGeometry保留，随后核对ImpactAnalysis与RequiresExplicitExecution=true的RebuildPlan。

| ID | 变化 | Dirty闭包 | 不得发生 |
|---|---|---|---|
| D01 | ARP位置版本+1 | Intersection→WidthTransition→Protection→Evaluation，阶段解析失效 | 不重建NominalTrack；不自动执行 |
| D02 | Fix位置版本+1 | 对应TrackFragment→NominalTrack→Intersection→WidthTransition→Protection→Evaluation | 不默认全程序重建 |
| D03 | NavigationContext版本+1 | WidthPolicy→WidthTransition→Protection→Evaluation | 不重算几何Intersection；换DME后不复用旧GNSS结果 |
| D04 | ObstacleDataset版本+1 | Evaluation only | 不重建保护与航迹 |
| D05 | AcceptedGeometry空间版本+1 | Evaluation only／语义缺失NeedsReview | 不覆盖LastComputedGeometry |
| D06 | 显式执行已过期Plan | PlanStale，重新分析 | 不用旧输入提交新结果 |
| D07 | Save/Reopen Dirty项目 | 同ID/版本/RC/Trace/双几何快照/Dirty状态 | 不因重开清Dirty；不自动评价 |
| D08 | F-T＋F-I完整17步、接受未变更成果、Save/Reopen、显式Re-evaluate | MOCA_raw450、控制B；相同几何语义与数值，新的Evaluation版本，Fake预览保留绑定 | 不调用真CAD／真持久化 |
| D09 | 手改空间形状后Accept且丢失profile映射 | Evaluation Dirty、NeedsReview；显式评价返回GeometryMappingMissing | 不能以接受动作签发有效MOCA |

## 未来执行门
先实现Native政策及纯函数，再执行本表；使用FakeCadPort和同进程InMemoryProjectStore走D08。I0.5现有Catalog仍返回四项DETAIL-PENDING，本轮不改源码；I1-A编码时同步Catalog修订并加入以上测试后才可宣称运行实现。SDK构建验证、Native测试执行、真实数据与发布规则各自单独报告，不以I1-A RULE READY替代它们。
