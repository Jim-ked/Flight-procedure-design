# 字段语义与数据流

所有命名控件的声明、初始化、setter/reader及所在P号/源行见 [control-references.csv](evidence/control-references.csv)；精确字段token/IL读写见 field-flow.csv。数字TextChanged只做公共校验，状态加载/反序列化也可赋值，不代表重新计算。

|Field / UI control|Setter|Reader|Unit / Formula|真实角色|
|---|---|---|---|---|
|MDist / textBoxMDist|初始化8000；P489计算|P488复制剪贴板|m；Round(100*(MEnd−MStart)/MPdg)|禁用显示：独立SOC→TP估算输出，不是几何直接参数|
|MStart / textBoxMStart|初始化100；文本/状态加载|P489；数值校验|m；SOC起始高度|不是保护宽度|
|MEnd / textBoxMEnd|初始化300；文本/状态加载|P489；校验|m；转弯高度|不是末宽|
|MPdg / textBoxMPdg|初始化2.5；文本/状态|P489；校验|百分数；分母不除100而分子乘100|独立距离估算爬升梯度|
|MCG / textBoxMCG|初始化2.5；文本/状态|P47D、P470，之后P594/P5ED/P5F4|输入%→g=value/100|**missed climb gradient**；主复飞爬升梯度，不是required-gradient输出|
|ThrToSoc / tbThrToSoc|主输入默认2000；P485粘贴|P47D/P470|m；LNAV SOC.X=−s|主几何SOC站距；不自动读取NDist|
|SocToTp / tbSocToTp|主输入默认8000；P486粘贴|P47D/P470|m；TP总距=s+t|主复飞终止距离；不自动读取MDist|
|TpAlti / textBoxTpAlti|初始化300；输入/状态|仅校验/保存|m|名义转弯高度输入，未进入几何/评价|
|IfSegLen / textBoxIfSegLen|10000；输入/状态|P47D/P470|m|中间段长度|
|FafAlti / textBoxFafAlti|900；输入/状态|P47D/P470|m，绝对标高|名义FAF/FAP高度；d公式见点位表|
|Z1/Z2 / runway text|拾取P479/P47A、交换P48B、状态|P47B；Z1另进两工厂|m|THR/跑道另一端标高，XY长度不读Z|
|VPA / comboBoxVPA|3.0；输入/状态|两工厂|deg→tan|主垂直航径角|
|TCH / textBoxTCH|15；输入/状态|两工厂|m|入口基准高|
|Hi / comboBoxHi|75；状态|P470|m|APV单一面余度q|
|AdElev / textBoxAdElev|0；输入/状态|P470→P5F2；孤立P482|m|APV HL高机场修正；非温度函数基准|
|Temp / textBoxTemp|−20；输入/状态|P470→P5F3|°C|APV温度项；P5F3高度基准用Z1|
|category / comboBoxCat|D；状态|P470→P5F1/P5F2|类别字符串|APV Xz/HL，不是LNAV分类输入|
|NIAS/NAlt/NWind/NTemp/NTime|380/900/19/15/18；状态|P48A|km/h或kt、m、°C、s|独立NPA SOC小工具|
|NDist / textBoxNDist|默认2300；P48A|P487复制|m；Round((TAS+wind)*time/3.6+444)|输出需粘贴才能影响主几何|
|DH / textBoxDH|默认60；状态|校验/保存，无主工厂读取|m|APV候选显示/输入，计算断开|
|HLm/HLr/HLcor|49/26/52.12；状态；孤立P482写HLcor|P482读HLm/HLr；主工厂不读HLcor|m|显示小工具，与P5F2独立|
|comboXz/comboBoxGP/comboBox1/comboCat|设计器/状态|无主工厂消费者|m/deg/类别|附加设置候选；无类别事件联动|
|PDist/Elev/LGT等附加项|控件/状态|本轮已索引所有reader，未进入两工厂|控件单位/文本|不能按名字补FAP/SOC计算；LGT原名确为textBoxLGT|

身份与原始字段名以CSV为准。控件初始值和config载入后的值分开：默认不保证运行时生效；配置可包含陈旧控件路径。没有将字段语义未知作为回避理由：MCG与四个M字段已由真实算式、标签和消费者确定。
