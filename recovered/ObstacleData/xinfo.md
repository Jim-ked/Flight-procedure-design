# xInfo完整链（L1/L2；运行证据另列）

入口原06000075/RVA470C（处理06000074）→Editor.GetEntity(PromptEntityOptions("请选择实体对象"))一次→非OK返回→只读Transaction.GetObject→Entity.XData→逐TypedValue输出。无数据输出原拼写`Non-Information avaiable\n`。

读取的是**所有RegApp的Entity.XData**，不是GetXDataForApplication；不读取ExtensionDictionary。1001更新app变量，其余项值逐项传给formatter，1001本身不单独打印。WsEntityFrame如果存在，只是全部XData中的一段，不是xInfo预置业务对象。

FormatValue原06000076/49FC：TrimStart以后非`{`/`[`开头，输出`app = value`；否则先输出app再递归打印JSON形文本。Print原06000077/4B30；空白/标量/引号/Raw原06000078–7B，RVA4F64/5014/5048/5234。详见 XInfo.Recovered.cs、evidence/0x06000075.il.txt等（证据包文件名是处理token）。

所谓递归Properties仅是通用字符串扫描器遇到嵌套对象/数组时递归；它没有读取实体的.NET Properties集合，更没有递归追踪CAD属性对象。没有使用JSON反序列化器构建业务模型，输出也不是一个统一JSON对象。

各1000项分别扫描，**不拼接250字符分片**。因此长WsEntityFrame首片可能是不完整JSON，手写循环可能不终止；保留旧行为，不能在宿主中用人为构造长坏JSON冒险验证。短合法JSON格式检查已通过，不能升为原DLL运行证明。

EXP-02应在EXP-01的同图同Point执行，并保存完整命令文本，与Observer的全部XData及ExtensionDictionary逐字段比较；不能将Observer读到的字段直接冒称xInfo打印过。当前运行状态见 ../dynamic-test/experiment-index.md。
