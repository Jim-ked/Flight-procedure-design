# B2 input frame and manual interaction

The processed event `_0089_008B_008A` / original `0x060004E0` calls `GetPoint` in the order `起点`, `转弯点`, `终点` (source lines 53437–53449). The first and third points become the incoming/outgoing segment descriptors; the middle point is the fly-over waypoint and receives ATT. The third point is therefore a post-turn direction reference, not evidence of a hidden database waypoint or automatic DF lookup.

`textBoxSW` supplies the common width. `textBoxATT` supplies center ATT. `textBoxReactTime` and `textBoxBankTime` become the two delay fields. The five display checkboxes are passed to the CAD writer. As in B1, the program cannot infer the three anchors from an existing route object in this chain.
