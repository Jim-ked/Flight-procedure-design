# 方法与来源

L1 Direct=处理后代码；L2 IL=处理后IL及原件token映射；无L3。原始RVA可能仅指向保护桩，不意味着原始明文方法体已含这些公式。以下是审计定位，不以条目数作为完成比例。源码是固定行段摘录，首尾可能跨方法；以IL文件为完整方法体定位。旧摘录文件保留，新生成清单为当前有效索引。

| 方法 | 原token / RVA | 处理后token / RVA | 原阅读副本行 |
|---|---|---|---|
| _0094_009A | 0x0600020A / 0x199D8 | 0x06000209 / 0x39A4 | 03_recovered-src\annotated-strings\--\--.cs:4432 |
| _0094_009B | 0x0600020B / 0x19A30 | 0x0600020A / 0x39E1 | 03_recovered-src\annotated-strings\--\--.cs:4440 |
| _0094_009C | 0x0600020C / 0x19A88 | 0x0600020B / 0x3A1E | 03_recovered-src\annotated-strings\--\--.cs:4448 |
| _0094_009D | 0x0600020D / 0x19AE0 | 0x0600020C / 0x15FDC | 03_recovered-src\annotated-strings\--\--.cs:4456 |
| _0095_0086 | 0x0600020F / 0x19CD4 | 0x0600020E / 0x160EC | 03_recovered-src\annotated-strings\--\--.cs:4502 |
| _0095_0087 | 0x06000210 / 0x1A5E0 | 0x0600020F / 0x3A5B | 03_recovered-src\annotated-strings\--\--.cs:4716 |
| _0095_0088 | 0x06000211 / 0x1A604 | 0x06000210 / 0x3A77 | 03_recovered-src\annotated-strings\--\--.cs:4721 |
| _0095_0089 | 0x06000212 / 0x1A628 | 0x06000211 / 0x1673C | 03_recovered-src\annotated-strings\--\--.cs:4726 |
| _0095_008A | 0x06000213 / 0x1AB18 | 0x06000212 / 0x16BC4 | 03_recovered-src\annotated-strings\--\--.cs:4973 |
| _0095_008B | 0x06000214 / 0x1AC00 | 0x06000213 / 0x16C2C | 03_recovered-src\annotated-strings\--\--.cs:4995 |
| _0095_008C | 0x06000215 / 0x1ACDC | 0x06000214 / 0x3A93 | 03_recovered-src\annotated-strings\--\--.cs:5014 |
| _0095_008D | 0x06000216 / 0x1ACFC | 0x06000215 / 0x16C8C | 03_recovered-src\annotated-strings\--\--.cs:5019 |
| Dispose | 0x06000217 / 0x1ADD8 | 0x06000216 / 0x3AAB | 03_recovered-src\annotated-strings\--\--.cs:5033 |
| _0088_008B | 0x06000088 / 0x555C | 0x06000087 / 0x87E0 | 03_recovered-src\annotated-strings\-\-.cs:1458 |
| _0088_008C | 0x06000089 / 0x5660 | 0x06000088 / 0x88C8 | 03_recovered-src\annotated-strings\-\-.cs:1504 |
| _0088_008D | 0x0600008A / 0x5878 | 0x06000089 / 0x8AB8 | 03_recovered-src\annotated-strings\-\-.cs:1578 |
| _0088_008E | 0x0600008B / 0x5B04 | 0x0600008A / 0x8C60 | 03_recovered-src\annotated-strings\-\-.cs:1657 |
