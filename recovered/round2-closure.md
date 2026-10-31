# Round 2 Closure：A7 / A8 / A10

更新：2026-10-27。状态：**PARTIALLY ACCEPTED**。三包的静态恢复代码、事件图、调用/衔接索引、API25.1 兼容编译和纯恢复代码测试已交付；原目标业务 L3、完整 Designer/config 装配、原 API23.1 宿主运行仍未闭合。原 DLL、数据库、配置、DWG、帮助和压缩包只读；Round1 冻结 hash 核对结果为 0 mismatch。

## A7 回答

1. 定高链为 DER/THR→跑道局部坐标→`Station=(H-DER.Z-5)/gBefore`→S/K/延迟端几何→Sym 多边形→独立分支评价；没有风螺旋、切线或 A/2 分支证据。
2. 定点 TP、KK′、C 由 GetPoint 得到，均为 XY 无符号距离；TP 反算计算高度，KK/C 进入早点、TP、末点和延迟端的四个 Sym 多边形及评价。
3. ReferenceHeight 使用实际梯度；CalculationHeight 使用固定 10%；两者均加 DER 高程和 5m，TextChanged/事件中 `Math.Round`。业务构造用计算高度反算 TP，Reference 主要是显示/构造参考。
4. A7 不直接调用 A1 螺旋构造器；只直接调用共享 turn 参数构造器 P793 的 TAS 等结果。A1/B1/B2 有螺旋调用证据。
5. 定高/定点是直线、转弯前后和早转弯分支的 Sym 多边形；全向是三分区、跑道内段、C1–C5 线侧分支和外圆。未发现自动 IntersectWith/Offset/裁剪/包络。
6. 二次检查只处理原 DER→最早点直线内的障碍物，固定 `dr=tp-KK`、`do=Early.X-X`、MOC 至少 75；覆盖同一行，不追加行。
7. 全向评价实际分为 1/2/3 区，并包含跑道内、直线段及 C1–C5 侧方分类；不是规范意义上的同心三圆区。
8. 定点、定高、全向各自有独立障碍物公式；共同表层只有局部坐标、排序、显示和 Mark。具体公式见 `A7-Departure/obstacle-evaluation.md`。

## A8 回答

9. KK 左右两点形成反向局部框架：原点左端，正 X 为右端→左端；中点不使用，Y<0 标为线外。
10. Ds 是两次 GetPoint 的三维距离输入；MCG 是输出 `required*100`；MOC 输入在恢复评价中作为固定 MOC，模式只改变 PDA/分母路径。
11. A8 直接调用 KK 评价切片；没有 A7 三个评价器的直接共享调用证据。相似的 MOC/梯度公式是重复实现。
12. 静态完整类范围内，A8 是导入、局部坐标、KK 评价、表格、Mark、高亮窗口；未发现保护区 Polyline/Arc/Circle 绘图链，结论限于静态类范围。

## A10 回答

13. O 与 IF 的 XY 距离定义 `r`；O→IAF 定义起始 bearing，O→IF 定义结束 bearing；IAF 距离不使用。
14. `R=r+3704`，端部参数 `A=(2rk+3k²)/(2r+2k)`、`B=(2rk+k²)/(2r+2k)`，k=3704；五个偏移为 -9260/-4630/0/4630/9260。
15. 以两个 bearing 的最短弧决定 ccw/cw；cw 通过顶点反序/负 bulge 表达。
16. 没有找到 7 NM、70°、2 NM lead radial 或 120°限制的实现证据，均标记“实现依据待确认”。
17. A10 只评价 DME 弧扇区；没有 IF 后直线保护区重建或 A9 PriSec 调用证据。
18. 没有 FAF 变量、FAF 实体生成或自动连接调用证据。
19. 中央区按径向误差对称折减；两端在外侧半宽后按 `2*(width-distance+radius)/width` 折减，宽度 9260，MOC 实际为 factor×300，UI MOC 被丢弃。

## 共用层回答

20. A1/B1/B2 直接或间接使用 turn/spiral 原语；A7只直接使用 turn 参数 P793，不使用螺旋构造；A8/A10没有这两类直接调用证据。
21. A7/A8 使用恢复的障碍物导入、局部坐标和 Mark 公共链；没有 A7/A8/A10 调用 Round1 A9 PriSec 业务评价器的直接证据。A10 扇区评价是窗口内独立实现。
22. 真正公共的是点、线、距离、bearing、旋转/平移/清 Z、turn 参数和 CAD 导入/事务 helper；A7 三模式评价、A8 KK 评价、A10 扇区/端部副区折减均为独立重复实现。

## 验证与缺口

- `recovered/round2/tests.log`：105 项恢复代码断言通过；`fixtures/` 保存 A7 控制点、全向 C1–C5、A10 15 个 Arc 和 Polyline 顶点/bulge。
- `compile-native.log`：API25.1 compatibility compile 成功，5 个不可达代码 warning 来自保留原状态机；没有 NETLOAD。
- `cad-connection-sites.csv`、`protection-connection-index.md`：索引 Arc/Polyline/Group/XData、人工 GetPoint/SelectAll，并记录未发现 Offset/IntersectWith/裁剪/删除重建。
- 原始规范/资料的历史依据与旧常数关系仍待确认；没有按规范替换代码行为。Round1 状态继续为 PARTIALLY ACCEPTED。
