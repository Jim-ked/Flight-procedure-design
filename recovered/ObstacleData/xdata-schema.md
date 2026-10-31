# 三种XData不能混为一谈

L1/L2。RandomPoint自身不写以下schema；公共障碍物解析器可消费已有WsEntityFrame。

| RegApp | TypedValue顺序 | 写入用途 |
|---|---|---|
| WsObject | 1001 app，1000任意描述字符串 | 通用追加helper仅在非空P2时写入 |
| WsCalcuLine | 1001 app，1000类型整数文字，1000 JSON整串 | A2施工Line参数 |
| WsEntityFrame | 1001 app，1000 EntityType整数文字，1000 EntityName或空串，随后多个1000 JSON片段 | 通用实体属性框架 |

WsEntityFrame：每片段按.NET字符串250个字符切分，非250 UTF-8字节；读取从索引3起拼接全部非null Value.ToString再反序列化。JSON优先覆盖header类型，非空JSON名称覆盖header名称，复制Properties字典。序列化器DataContractJsonSerializer；UTF8长度>16384只警告。

注意JSON中标记DataMember的是**私有混淆字段** `_008A_009A_008E`（EntityName backing）、`_008A_009A_008F`（EntityType backing）与公开Properties。不能伪造`{"EntityName":...,"EntityType":...}`为原schema。原字段的元数据名称及DataMember须保留；当前尚未用独立兼容模型验证其最终JSON键编码，所以JSON兼容源移植为TODO-RE。

## xInfo

2026-10-27增量：EntityFrame.Recovered.cs已用真实Unicode元数据名称恢复JSON成员，18项新增测试包含往返/分片/键值数组检查；下划线名称仅是反编译显示别名。真实旧DWG交叉兼容仍未验证。EntityFrameCad.Recovered.cs为未编译的原生ResultBuffer恢复。详见../A2-BasicCalculation/serialization.md。

原0x06000075/RVA470C → GetEntity一次 → 只读打开Entity → **读取全部Entity.XData**，不是指定RegApp，不读取ExtensionDictionary。遇1001更新当前app，其余值逐条显示。

以TrimStart后`{`或`[`开头的值进入手写递归扫描器；其它输出`app = value`。没有使用JSON serializer解析探针输出。扫描器支持对象/数组缩进和部分字符串转义，不是完整JSON解析器；不合并WsEntityFrame多个1000片段，长JSON切片可能被分别解析且遇不完整对象有不终止风险。不得替换成健壮JSON库后称原实现。

XInfo.Recovered.cs提供原生命令（AUTOCAD条件编译，未编译运行）及已编译测试的递归格式化逻辑。测试不是L3。
