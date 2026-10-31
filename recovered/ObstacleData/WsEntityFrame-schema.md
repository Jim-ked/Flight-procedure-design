# WsEntityFrame 与障碍物存储（L1/L2）

## 通用属性框架

RegApp=`WsEntityFrame`；封装顺序：1001 app，1000 EntityType十进制文字，1000 EntityName或空串，随后多个1000 JSON片段。默认DataContractJsonSerializer/UTF8；按.NET字符串每250字符切片，**不是250字节**。16KB检查只警告。不存在将整个schema都写成`EntityName/EntityType`英文键的证据。

| 真实JSON键（转义显示） | 类型/含义 | new实例默认 |
|---|---|---|
| `\u008a\u009a\u008e` | string，私有名称字段 | 空串 |
| `\u008a\u009a\u008f` | enum数值，私有类型字段 | 99 |
| `Properties` | Dictionary<string,object> | 空字典 |

默认字典形态是`[{"Key":"Height","Value":123.5}]`；不是`{"Height":123.5}`。此例来自恢复序列化测试，用于说明编码，**不是RandomPoint实测内容**。任意自定义对象的KnownType兼容尚未验证。

读取第3项起非null值拼接JSON；header先赋名称/类型，然后非空JSON名称覆盖header，JSON类型始终覆盖header，Properties复制入结果。坏JSON返回new框架，其默认99也可覆盖header。`{}`绕过构造器的null/零缺项行为与new不同，不补造默认。

ToJson原06000711/BE158；FromJson 06000712/BE298；ToBuffer 06000713/BE3C4；FromBuffer 06000714/BE550；LoadEntity 06000718/BED60。原字段0x04000731/732和无Name覆盖的DataMember属性证明Unicode键。对应代码 EntityFrame*.Recovered.cs，原/处理映射及完整IL见 evidence/。

## 不存在统一的“随机障碍物EntityFrame记录”

| 数据 | RandomPoint实际存放 / ScreenData读取 | 是否固定EntityFrame字段 |
|---|---|---|
| XYZ | DBPoint.Position；Z是随机高度 | 否 |
| 名称 | MText显示P+ObjectId后缀；Point无独立Name字段 | 否；若其他入口已有EntityFrame.EntityName，则解析器优先用它 |
| ID | 每窗导入循环从1起的序号字符串；字典映射回DBPoint | 否，也不是Handle |
| Obstacle height | 此链直接使用Point.Z | 否 |
| Tree height | 此链生成/导入/评价不另读树高 | 否；不能由其他属性类定义反接到这里 |
| Total height | 此链无“障碍物高+树高”合成步骤 | 否 |
| 显示高度/名称 | MText.Contents（可为空，仍创建MText） | 否 |
| Properties | 通用扩展键值载体，取决于其他属性写入入口 | 没有RandomPoint默认Height/TreeHeight/TotalHeight键 |

RandomPoint原0600034A/4EC88每点只追加DBPoint和MText，元数据参数为空；未调用WsEntityFrame写入。公共追加helper只有非空metadata才写WsObject，此调用不进入。不得把链图中的metadata箭头理解为“RandomPoint自动写WsEntityFrame”。正确分支为：裸DBPoint→无metadata时后缀名称回退；带属性DBPoint→尝试WsEntityFrame名称。

解析器原06000130/10D00：XYZ来自原点，ID来自调用者ordinal；尝试frame.EntityName，异常吞掉；空白名走ObjectId字符串规则（长度>6，P+Substring(length−5,4)）。没有从附近MText识字，也不接受块作为ScreenData输入。

原目标运行内容、RegApp是否被宿主插件额外补写，须以EXP-01为准；静态证据不能排除宿主外部回调。本包不伪造缺失的EXP-01 JSON。
