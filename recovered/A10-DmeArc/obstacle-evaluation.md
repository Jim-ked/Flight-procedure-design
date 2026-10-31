# A10 障碍物评价

每个导入 DBPoint 以 O 为中心计算角度和半径，依次尝试 IAF 端、IF 端、中央扇区，首个非 out 结果进入列表。中央误差 `abs(d-R)`，误差不超过半宽为主区；端部在外侧半宽后按 `2*(width-d+radius)/width` 折减，内侧保持主区。width=9260，MOC 始终为 factor×300。扇区端点包含；跨零使用 `angle>=start || angle<=end`。不重建 IF 后直线，也没有 FAF 变量或实体生成证据。
