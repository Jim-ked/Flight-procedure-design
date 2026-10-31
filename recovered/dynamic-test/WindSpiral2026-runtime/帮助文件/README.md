# WindSpiralBasic 帮助文件维护说明

本目录为【风标设计2026 基础版】的 HTML 帮助文件中心，采用纯静态页面（无构建步骤），直接用浏览器打开 `index.html` 即可浏览。

## 目录结构

```
帮助文件/
├── index.html              帮助中心首页（模块概览、命令速查表）
├── style.css               全站共享样式（所有页面引用同一份）
├── images/                 界面截图目录（每个窗口一张，命名 = 窗口类名.png；含选项卡级分页图共 48 张）
│   ├── FormWindSpiral.png
│   ├── FormCalcu.png
│   ├── FormTemplate_tab1.png ~ FormTemplate_tab4.png               （FormTemplate 各选项卡界面截图）
│   ├── FormTemplate_tab1_effect.png ~ FormTemplate_tab4_effect.png  （FormTemplate 各选项卡绘制效果示例）
│   ├── FormDepartureEvl_tab1.png ~ FormDepartureEvl_tab4.png        （FormDepartureEvl 各选项卡界面截图）
│   ├── FormDepartureEvl_tab1_effect.png ~ FormDepartureEvl_tab4_effect.png（FormDepartureEvl 各选项卡应用效果）
│   ├── FormCalcu_tab1.png ~ FormCalcu_tab6.png                      （FormCalcu 各选项卡界面截图）
│   ├── FormCalcu_tab1_effect.png ~ FormCalcu_tab6_effect.png        （FormCalcu 各选项卡绘制效果示例）
│   └── ...（共 48 张）
└── <FormName>.html         各窗口说明页（共 20 个）
```

20 个窗口说明页：FormWindSpiral、FormCalcu、FixTolerance、FormNavAids、FormPA、FormTemplate、FormDepartureEvl、FormTurnAreaEvl、FormPriSecEvl、FormDmeEvl、FormFlyBy、FormFlyOverDF、FormApvEvl、FormPbnIlsEvl、FormPbnDepEvl、FormBlockImport、LayerFactoryForm、FormExLine、FormRandPoint、FormMSD。

## 页面统一模板

每个说明页由以下部分组成，修改时请保持结构一致：

- **topbar**：面包屑导航 + 页面标题 + 对应 CAD 命令名。
- **sidebar**：分组导航；当前页的链接带 `class="active"`（每页仅一处）。
- **content**：若干 `card` 卡片，固定顺序为「功能简介 → 界面预览 → 界面元素 → 操作步骤」。
- **pager**：上/下篇翻页，按窗口线性顺序串联。
- **footer**：版权行。

## 界面预览卡片约定

每个窗口页在「功能简介」与「界面元素」之间有一个「界面预览」卡片，用于展示该窗口的界面截图：

```html
<div class="card">
    <h2>界面预览</h2>
    <!-- 界面截图：将 images/<FormName>.png 替换为实际窗口截图即可（保持文件名不变）。
         图片显示宽度通过下方 width 属性的数值（单位：像素）指定，高度自动等比缩放。 -->
    <img src="images/<FormName>.png" alt="<FormName> 界面截图" width="720"
         style="max-width:100%; height:auto; border:1px solid var(--border); border-radius:8px;">
</div>
```

### 替换为真实截图

1. 用截图工具截取对应窗口，保存为 PNG。
2. **覆盖** `images/<FormName>.png`（文件名保持不变）。
3. 无需修改任何 HTML，刷新页面即生效。

### 调整图片显示大小

- 统一约定：`width` = 图片**实际像素宽度 × 75%**（四舍五入取整），例如实际宽 806px → `width="604"`；占位图 960×600 对应 `width="720"`。
- 修改 `<img>` 的 `width` 中的**数值**（单位：像素）即可调整显示大小。
- 高度由 `height:auto` 自动等比缩放，无需单独设置。
- `max-width:100%` 保证在窄屏下不溢出卡片，请勿删除。

### 关于占位图

当前 `images/` 下的 48 张 PNG 为程序生成的**占位图**（960×600 灰底、居中提示文字），仅用于占位与版式预览，**应被真实窗口截图替换**。占位图不含任何真实界面信息。

### 选项卡级分页图（FormTemplate / FormDepartureEvl / FormCalcu）

按选项卡展开说明的页面，每个选项卡对应一张界面截图与一张效果示例图，命名规则 `<FormName>_tab<N>.png`（界面）与 `<FormName>_tab<N>_effect.png`（效果），N 按选项卡在窗口中的显示顺序编号：

- **FormTemplate**（N = 1~4）：等待与直角航线 / 基线转弯 / 45·180程序转弯 / 80·260程序转弯，每选项卡卡片含：界面截图 → 参数说明表 → 按钮功能表 → 操作步骤 → 效果示例图。
- **FormDepartureEvl**（N = 1~4）：跑道数据 / 定高转弯 / 定点转弯 / 全向离场，每选项卡卡片含：界面截图 → 参数说明表 → 按钮功能表 → 应用效果图。
- **FormCalcu**（N = 1~6）：FAF计算 / 非精密SOC计算 / 精密SOC计算 / 复飞TP计算 / 离场TP计算 / C容差计算，每选项卡卡片含：界面截图 → 参数说明表（含自动计算公式）→ 操作步骤 → 效果示例图。

替换真实截图后，请按实测像素宽度 × 75%（四舍五入）修改 HTML 中对应 `<img>` 的 `width` 属性（占位图 960×600 对应 720）。

## 编码与命名规范

- 所有 HTML / CSS 文件统一使用 **UTF-8（无 BOM）** 编码保存，避免中文乱码。
- 截图文件名必须与窗口类名完全一致（区分大小写），例如窗口 `FormPbnIlsEvl` 对应 `images/FormPbnIlsEvl.png`。
- 新增窗口页时，同步在 `index.html` 的对应分组与命令速查表中登记，并在 `images/` 下补充同名截图。
