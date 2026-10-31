# A2功能链

```text
FormCalcu控件输入/Validated
  ├─ FAF公式22F ── CAD22D ── FAF工厂/IF对象 ─┐
  ├─ TAS控件854 ─ NPA公式233 ─ CAD232 ─工厂 ┤
  ├─ 类别表238 ─ HL239 ─ PA公式237 ─CAD235 ┤
  ├─ 复飞公式23B ─ CAD23A ─工厂            ┤
  ├─ 离场公式23E ─ CAD23D ─工厂            ┤
  └─ TAS控件854 ─ C公式241 ─ CAD240 ─工厂  ┤
                GetPoint×2→Atan2→cos/sin   │
                                           ↓
           6A3 端点重算→new Line→89追加ModelSpace
                           ↓
           RegApp WsCalcuLine→651 ResultBuffer→XData
                           + 按复选框追加DBText
```

图中简写为处理后token尾部。全部调用位置见evidence/calls.csv；原token/RVA见evidence.md。没有把这些对象解释为完整Procedure Domain Model，也没有否认其局部数据契约。
