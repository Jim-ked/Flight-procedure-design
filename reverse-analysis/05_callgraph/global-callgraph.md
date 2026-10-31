# 静态调用图基线

static-sites.csv 保存 47867 个调用/构造/函数指针位置；每条有处理后 caller token、IL 偏移、opcode、target token/name。field-accesses.csv 保存字段访问。

注意：MethodSpec 泛型调用尚未展开，反射及间接委托运行边缺失；这不是完整运行调用图。原始映射见 ../04_type-map/tool-token-map.csv。不使用未验证的原始 token 等于处理后 token 假设。
