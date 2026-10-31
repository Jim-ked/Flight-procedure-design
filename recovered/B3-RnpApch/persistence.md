# 保存/载入的真实格式

P47F保存、P47E加载UTF8 `.rnp` 文本；P0FB/P0FC遍历支持的控件，路径以父控件名`.`拼接，写 `path:value\n`，头为 `FormApvEvl`。不是XML/JSON，也不是按航段建模的Procedure数据。字段由控件adapter取Text/SelectedIndex/bool等，不能把所有控件都强制理解为Text。

```text
FormApvEvl
tabControl1....textBoxFafAlti:900
tabControl1....comboBoxCat:3
```

上例路径中省略号只用于示意；真实路径见保存遍历/控件引用索引。P0FD按CRLF/CR/LF及RemoveEmpty分行，首行精确比较FormApvEvl；每行Split(':')后用[0].Trim与[1].Trim。额外冒号被截断；缺冒号/空文本会越界；未找到控件跳过；没有转义/版本化schema。控件适配器类型按共享原实现，测试只覆盖扁平支持控件的文本记录，不冒充实际WinForms类型setter。

Form Load P474→P0F6、Closed P475→P0F4另使用程序集目录config.xml，节点Document/FormApvEvl，dotted控件key。它与.rnp文本的格式不同。配置可覆盖设计器默认/含已不匹配的路径；未改原配置。文件选择和实体选择都只恢复UI状态，不自动重新评价。
