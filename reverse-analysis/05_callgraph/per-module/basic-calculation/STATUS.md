# 审计包：basic-calculation

状态：第一阶段入口/控件/事件/调用候选索引已建立，业务链尚未完成。

字符串和388个布尔值已静态解码校验；仍需逐方法识别混淆门控与真实业务条件。后续必须恢复输入输出与单位、条件分支、控件到 handler 到计算几何到 CAD 的路径，解决缺失 CAD 依赖和运行验证缺口；不得以当前文件数量声称基础链完成。事件图由 export_audit_packets.py 生成；离场新增证据见 ../../../07_procedure-logic/conventional-departure.md。
