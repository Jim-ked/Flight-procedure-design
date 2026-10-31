# B5 完整事件图

绑定来自 designer 处理后源码；原文件主体多为保护占位。表中 token/RVA 由元数据映射，不按名称猜测。完整 API/调用位置见 evidence/direct-calls.csv。

|Control / Text|Event|Original MethodDef / RVA|Processed MethodDef / RVA|Handler|Direct callees / CAD API|
|---|---|---|---|---|---|
|textBoxRefAltiTp "300"|MouseEnter|0x06000533 / 0x834F8|0x06000532 / 0x4E30|_0089_0091_0089|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|cbLabelWindSpeed "风速(km/h)"|Click|0x06000541 / 0x83774|0x06000540 / 0x6AF6C|_0089_0091_0097|0x06000149 \x87\x8d.\x87\x8c::\x8d\x87, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|cbLabelIAS "IAS(km/h)"|Click|0x06000540 / 0x83664|0x0600053F / 0x6AEDC|_0089_0091_0096|0x06000149 \x87\x8d.\x87\x8c::\x8d\x87, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button18 "标记"|Click|0x06000512 / 0x82F8C|0x06000511 / 0x6AD90|_0089_008F_009B|0x0600009C \x8c.\x8b::\x89\x87, 0x0600009E \x8c.\x8b::\x89\x89, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x06000886 \x90\x9c.\x90\x9b::\x8b\x8f\x9a, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d, 0x0A000077 Autodesk.AutoCAD.Geometry.Point3d::get_Z, 0x0A000113 Autodesk.AutoCAD.DatabaseServices.DBPoint::get_Position|
|button18 "标记"|MouseEnter|0x0600052C / 0x83434|0x0600052B / 0x4DFA|_0089_0090_009B|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button18 "标记"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxGradTpAfter "3.3"|MouseEnter|0x06000521 / 0x83300|0x06000520 / 0x4DFA|_0089_0090_0090|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxGradTpAfter "3.3"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxGradTp "3.3"|TextChanged|0x0600050A / 0x8289C|0x06000509 / 0x6A9D0|_0089_008F_0093|0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x060007D5 \x8f\x8b.\x8f\x8a::\x8b\x87\x9e, 0x06000886 \x90\x9c.\x90\x9b::\x8b\x8f\x9a, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxGradTp "3.3"|MouseEnter|0x06000520 / 0x832E4|0x0600051F / 0x4DFA|_0089_0090_008F|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxGradTp "3.3"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button7 "转弯区评估"|Click|0x0600050E / 0x82DAC|0x0600050D / 0x4DC8|_0089_008F_0097|0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button8 "直线段评估"|Click|0x0600050D / 0x82D88|0x0600050C / 0x4DC8|_0089_008F_0096|0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|FormPbnDepEvl |FormClosed|0x060004F3 / 0x803F8|0x060004F2 / 0x4D7F|_0089_008E_0095|0x060000B0 \x8e.\x8d::\x89\x93, 0x060000F4 \x98.\x97::\x8a\x91, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|FormPbnDepEvl |Load|0x060004F2 / 0x803D4|0x060004F1 / 0x3DFA|_0089_008E_0094|0x060000F6 \x98.\x97::\x8a\x93, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxLat2 "0"|MouseEnter|0x0600051E / 0x832AC|0x0600051D / 0x4E1E|_0089_0090_008D|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxLat2 "0"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxLon2 "-3000"|MouseEnter|0x0600051D / 0x83290|0x0600051C / 0x4E0C|_0089_0090_008C|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxLon2 "-3000"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxTurnEndY "0"|MouseEnter|0x0600053F / 0x83648|0x0600053E / 0x4E1E|_0089_0091_0095|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxTurnEndY "0"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxTurnEndX "-3000"|MouseEnter|0x06000544 / 0x83AC8|0x06000543 / 0x4E0C|_0089_0091_009A|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxTurnEndX "-3000"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button4 |Click|0x060004FD / 0x813F0|0x060004FC / 0x69CE0|_0089_008F_0086|0x06000113 \x9e.\x9d::\x8b\x8d, 0x060004F0 \x8b\x95.\x8b\x94::\x89\x8e\x93, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d, 0x0A00003E Autodesk.AutoCAD.ApplicationServices.Core.Application::get_DocumentManager, 0x0A00003F Autodesk.AutoCAD.ApplicationServices.DocumentCollection::get_MdiActiveDocument, 0x0A000061 Autodesk.AutoCAD.Geometry.Point3d::get_Y, 0x0A000062 Autodesk.AutoCAD.Geometry.Point3d::get_X, 0x0A000077 Autodesk.AutoCAD.Geometry.Point3d::get_Z, 0x0A000278 Autodesk.AutoCAD.ApplicationServices.Document::get_Window, 0x0A000279 Autodesk.AutoCAD.Windows.Window::get_Handle|
|button4 |MouseEnter|0x06000517 / 0x831E8|0x06000516 / 0x4DFA|_0089_0090_0086|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button4 |MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button9 "KML"|Click|0x06000510 / 0x82E24|0x0600050F / 0x2B6A|_0089_008F_0099||
|button9 "KML"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button9 "KML"|MouseHover|0x06000536 / 0x8354C|0x06000535 / 0x4E78|_0089_0091_008C|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button17 |Click|0x06000511 / 0x82E30|0x06000510 / 0x6ACE8|_0089_008F_009A|0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c|
|button17 |MouseEnter|0x06000515 / 0x831B0|0x06000514 / 0x4DFA|_0089_008F_009D|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button17 |MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxAlt2 "0"|MouseEnter|0x0600051F / 0x832C8|0x0600051E / 0x4DFA|_0089_0090_008E|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxAlt2 "0"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button3 "屏幕数据"|MouseEnter|0x06000518 / 0x83204|0x06000517 / 0x4DFA|_0089_0090_0087|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button22 |Click|0x060004FE / 0x81544|0x060004FD / 0x69D8C|_0089_008F_0087|0x06000113 \x9e.\x9d::\x8b\x8d, 0x060004F0 \x8b\x95.\x8b\x94::\x89\x8e\x93, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d, 0x0A00003E Autodesk.AutoCAD.ApplicationServices.Core.Application::get_DocumentManager, 0x0A00003F Autodesk.AutoCAD.ApplicationServices.DocumentCollection::get_MdiActiveDocument, 0x0A000061 Autodesk.AutoCAD.Geometry.Point3d::get_Y, 0x0A000062 Autodesk.AutoCAD.Geometry.Point3d::get_X, 0x0A000278 Autodesk.AutoCAD.ApplicationServices.Document::get_Window, 0x0A000279 Autodesk.AutoCAD.Windows.Window::get_Handle|
|button22 |MouseEnter|0x06000545 / 0x83AE4|0x06000544 / 0x4DFA|_0089_0091_009B|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button22 |MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button1 "CAD"|Click|0x06000504 / 0x81F10|0x06000503 / 0x6A358|_0089_008F_008D|0x06000087 \x8c.\x8b::\x88\x8b, 0x060004FF \x8b\x95.\x8b\x94::\x89\x8f\x89, 0x06000500 \x8b\x95.\x8b\x94::\x89\x8f\x8a, 0x06000502 \x8b\x95.\x8b\x94::\x89\x8f\x8c, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x060005C8 \x8c\x92.\x8c\x91::.ctor, 0x060007D5 \x8f\x8b.\x8f\x8a::\x8b\x87\x9e, 0x060007FC \x8f\x8f.\x8f\x8e::\x8b\x89\x96, 0x060007FE \x8f\x8f.\x8f\x8e::\x8b\x89\x98, 0x06000800 \x8f\x8f.\x8f\x8e::\x8b\x89\x9a, 0x06000805 \x8f\x8f.\x8f\x8e::.ctor, 0x06000821 \x8f\x91.\x8f\x90::\x8b\x8a\x94, 0x06000823 \x8f\x91.\x8f\x90::\x8b\x8a\x96, 0x06000827 \x8f\x91.\x8f\x90::\x8b\x8a\x9a, 0x06000886 \x90\x9c.\x90\x9b::\x8b\x8f\x9a, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d, 0x0A00003E Autodesk.AutoCAD.ApplicationServices.Core.Application::get_DocumentManager, 0x0A00003F Autodesk.AutoCAD.ApplicationServices.DocumentCollection::get_MdiActiveDocument, 0x0A000040 Autodesk.AutoCAD.ApplicationServices.Document::get_Editor, 0x0A000041 Autodesk.AutoCAD.EditorInput.Editor::WriteMessage, 0x0A000066 Autodesk.AutoCAD.DatabaseServices.HostApplicationServices::get_WorkingDatabase|
|button1 "CAD"|MouseEnter|0x06000529 / 0x833E0|0x06000528 / 0x4DFA|_0089_0090_0098|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button1 "CAD"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|buttonEvl "一键评估"|Click|0x06000502 / 0x81D2C|0x06000501 / 0x4DC8|_0089_008F_008B|0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxTurnAlt "300"|MouseEnter|0x06000522 / 0x8331C|0x06000521 / 0x4DFA|_0089_0090_0091|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxTurnAlt "300"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxGrad "3.3"|TextChanged|0x06000507 / 0x824B0|0x06000506 / 0x6A718|_0089_008F_0090|0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x060007D5 \x8f\x8b.\x8f\x8a::\x8b\x87\x9e, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxGrad "3.3"|MouseEnter|0x06000520 / 0x832E4|0x0600051F / 0x4DFA|_0089_0090_008F|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxGrad "3.3"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|comboBox1 "自动计算"|MouseEnter|0x0600053E / 0x8362C|0x0600053D / 0x4DFA|_0089_0091_0094|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|comboBox1 "自动计算"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button2 "KML"|MouseEnter|0x0600052A / 0x833FC|0x06000529 / 0x4E78|_0089_0090_0099|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button2 "KML"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxLon1 "0"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxAlt1 "0"|MouseEnter|0x0600051C / 0x83274|0x0600051B / 0x4DFA|_0089_0090_008B|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxAlt1 "0"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|cbLabelWindSpeedTp "风速(km/h)"|Click|0x06000543 / 0x839A8|0x06000542 / 0x6B094|_0089_0091_0099|0x06000149 \x87\x8d.\x87\x8c::\x8d\x87, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxLon1 "0"|MouseEnter|0x0600051A / 0x8323C|0x06000519 / 0x4E0C|_0089_0090_0089|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxRefAltiTp "300"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxGradAfter "3.3"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxLat1 "0"|MouseEnter|0x0600051B / 0x83258|0x0600051A / 0x4E1E|_0089_0090_008A|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxLat1 "0"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button5 |Click|0x060004FC / 0x81294|0x060004FB / 0x69C28|_0089_008E_009E|0x06000113 \x9e.\x9d::\x8b\x8d, 0x060004F0 \x8b\x95.\x8b\x94::\x89\x8e\x93, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d, 0x0A00003E Autodesk.AutoCAD.ApplicationServices.Core.Application::get_DocumentManager, 0x0A00003F Autodesk.AutoCAD.ApplicationServices.DocumentCollection::get_MdiActiveDocument, 0x0A000061 Autodesk.AutoCAD.Geometry.Point3d::get_Y, 0x0A000062 Autodesk.AutoCAD.Geometry.Point3d::get_X, 0x0A000077 Autodesk.AutoCAD.Geometry.Point3d::get_Z, 0x0A000278 Autodesk.AutoCAD.ApplicationServices.Document::get_Window, 0x0A000279 Autodesk.AutoCAD.Windows.Window::get_Handle|
|button5 |MouseEnter|0x06000516 / 0x831CC|0x06000515 / 0x4DFA|_0089_008F_009E|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button5 |MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button3 "屏幕数据"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxWindSpeed "56"|MouseEnter|0x06000528 / 0x833C4|0x06000527 / 0x4E66|_0089_0090_0097|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxWindSpeed "56"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxTemp "15"|MouseEnter|0x06000527 / 0x833A8|0x06000526 / 0x4E54|_0089_0090_0096|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxTemp "15"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxBank "15"|MouseEnter|0x06000526 / 0x8338C|0x06000525 / 0x4E42|_0089_0090_0095|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxBank "15"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxIAS "380"|MouseEnter|0x06000525 / 0x83370|0x06000524 / 0x4DFA|_0089_0090_0094|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxIAS "380"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxDrByAlti "8939.39"|MouseEnter|0x06000523 / 0x83338|0x06000522 / 0x4E30|_0089_0090_0092|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxDrByAlti "8939.39"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxDrByAlti "8939.39"|MouseHover|0x06000523 / 0x83338|0x06000522 / 0x4E30|_0089_0090_0092|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxGradAfter "3.3"|MouseEnter|0x06000521 / 0x83300|0x06000520 / 0x4DFA|_0089_0090_0090|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button2 "KML"|Click|0x06000505 / 0x82154|0x06000504 / 0x6A53C|_0089_008F_008E|0x060004FF \x8b\x95.\x8b\x94::\x89\x8f\x89, 0x06000500 \x8b\x95.\x8b\x94::\x89\x8f\x8a, 0x06000502 \x8b\x95.\x8b\x94::\x89\x8f\x8c, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x060005C8 \x8c\x92.\x8c\x91::.ctor, 0x060007D5 \x8f\x8b.\x8f\x8a::\x8b\x87\x9e, 0x06000886 \x90\x9c.\x90\x9b::\x8b\x8f\x9a, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|cbLabelIAStp "IAS(km/h)"|Click|0x06000542 / 0x83888|0x06000541 / 0x6AFFC|_0089_0091_0098|0x06000149 \x87\x8d.\x87\x8c::\x8d\x87, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button19 "标记"|Click|0x06000512 / 0x82F8C|0x06000511 / 0x6AD90|_0089_008F_009B|0x0600009C \x8c.\x8b::\x89\x87, 0x0600009E \x8c.\x8b::\x89\x89, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x06000886 \x90\x9c.\x90\x9b::\x8b\x8f\x9a, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d, 0x0A000077 Autodesk.AutoCAD.Geometry.Point3d::get_Z, 0x0A000113 Autodesk.AutoCAD.DatabaseServices.DBPoint::get_Position|
|button19 "标记"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button19 "标记"|MouseHover|0x0600052C / 0x83434|0x0600052B / 0x4DFA|_0089_0090_009B|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxWindSpeedTp "56"|MouseEnter|0x06000528 / 0x833C4|0x06000527 / 0x4E66|_0089_0090_0097|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxWindSpeedTp "56"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxTempTp "15"|MouseEnter|0x06000527 / 0x833A8|0x06000526 / 0x4E54|_0089_0090_0096|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxTempTp "15"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxBankTp "15"|MouseEnter|0x06000526 / 0x8338C|0x06000525 / 0x4E42|_0089_0090_0095|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxBankTp "15"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxIAStp "380"|MouseEnter|0x06000525 / 0x83370|0x06000524 / 0x4DFA|_0089_0090_0094|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxIAStp "380"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button10 "CAD"|Click|0x0600050C / 0x82BA8|0x0600050B / 0x6ABA0|_0089_008F_0095|0x06000087 \x8c.\x8b::\x88\x8b, 0x060004FF \x8b\x95.\x8b\x94::\x89\x8f\x89, 0x06000502 \x8b\x95.\x8b\x94::\x89\x8f\x8c, 0x0600050A \x8b\x95.\x8b\x94::\x89\x8f\x94, 0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x060005D3 \x8c\x94.\x8c\x93::.ctor, 0x060007D4 \x8f\x8b.\x8f\x8a::\x8b\x87\x9d, 0x060007D5 \x8f\x8b.\x8f\x8a::\x8b\x87\x9e, 0x060007FC \x8f\x8f.\x8f\x8e::\x8b\x89\x96, 0x060007FE \x8f\x8f.\x8f\x8e::\x8b\x89\x98, 0x06000805 \x8f\x8f.\x8f\x8e::.ctor, 0x06000821 \x8f\x91.\x8f\x90::\x8b\x8a\x94, 0x06000823 \x8f\x91.\x8f\x90::\x8b\x8a\x96, 0x06000827 \x8f\x91.\x8f\x90::\x8b\x8a\x9a, 0x06000886 \x90\x9c.\x90\x9b::\x8b\x8f\x9a, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d, 0x0A00003E Autodesk.AutoCAD.ApplicationServices.Core.Application::get_DocumentManager, 0x0A00003F Autodesk.AutoCAD.ApplicationServices.DocumentCollection::get_MdiActiveDocument, 0x0A000040 Autodesk.AutoCAD.ApplicationServices.Document::get_Editor, 0x0A000041 Autodesk.AutoCAD.EditorInput.Editor::WriteMessage, 0x0A000066 Autodesk.AutoCAD.DatabaseServices.HostApplicationServices::get_WorkingDatabase|
|button10 "CAD"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button10 "CAD"|MouseHover|0x06000535 / 0x83530|0x06000534 / 0x4DFA|_0089_0091_008B|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button6 |Click|0x06000508 / 0x82604|0x06000507 / 0x6A840|_0089_008F_0091|0x06000113 \x9e.\x9d::\x8b\x8d, 0x060004F0 \x8b\x95.\x8b\x94::\x89\x8e\x93, 0x0600050E \x8b\x95.\x8b\x94::\x89\x8f\x98, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x060007D4 \x8f\x8b.\x8f\x8a::\x8b\x87\x9d, 0x060007D5 \x8f\x8b.\x8f\x8a::\x8b\x87\x9e, 0x06000886 \x90\x9c.\x90\x9b::\x8b\x8f\x9a, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d, 0x0A00003E Autodesk.AutoCAD.ApplicationServices.Core.Application::get_DocumentManager, 0x0A00003F Autodesk.AutoCAD.ApplicationServices.DocumentCollection::get_MdiActiveDocument, 0x0A000040 Autodesk.AutoCAD.ApplicationServices.Document::get_Editor, 0x0A000067 Autodesk.AutoCAD.Geometry.Point3d::.ctor, 0x0A000077 Autodesk.AutoCAD.Geometry.Point3d::get_Z, 0x0A000278 Autodesk.AutoCAD.ApplicationServices.Document::get_Window, 0x0A000279 Autodesk.AutoCAD.Windows.Window::get_Handle|
|button6 |MouseEnter|0x0600052E / 0x8346C|0x0600052D / 0x4DFA|_0089_0090_009D|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button6 |MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button6 |MouseHover|0x0600052E / 0x8346C|0x0600052D / 0x4DFA|_0089_0090_009D|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|button12 "屏幕数据"|Click|0x060004F5 / 0x804D0|0x060004F4 / 0x4DBE|_0089_008E_0097|0x060004F6 \x8b\x95.\x8b\x94::\x89\x8e\x99|
|button12 "屏幕数据"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button12 "屏幕数据"|MouseHover|0x06000518 / 0x83204|0x06000517 / 0x4DFA|_0089_0090_0087|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|dataGridView1 |CellClick|0x060004FA / 0x80CD8|0x060004F9 / 0x698C4|_0089_008E_009C|0x060000AF \x8e.\x8d::\x89\x92, 0x060000B0 \x8e.\x8d::\x89\x93, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x0A00003E Autodesk.AutoCAD.ApplicationServices.Core.Application::get_DocumentManager, 0x0A00003F Autodesk.AutoCAD.ApplicationServices.DocumentCollection::get_MdiActiveDocument, 0x0A000040 Autodesk.AutoCAD.ApplicationServices.Document::get_Editor|
|checkBoxEarlyTurn "DER之前转弯"|MouseEnter|0x06000524 / 0x83354|0x06000523 / 0x4E30|_0089_0090_0093|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|checkBoxEarlyTurn "DER之前转弯"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxTurnAlt "300"|TextChanged|0x06000506 / 0x82384|0x06000505 / 0x6A674|_0089_008F_008F|0x06000548 \x8b\x95.\x8b\x94::\x88\x9b, 0x06000549 \x8b\x95.\x8b\x94::\x88\x9c, 0x060007D5 \x8f\x8b.\x8f\x8a::\x8b\x87\x9e, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxTp2Der "8939.39"|MouseEnter|0x0600052D / 0x83450|0x0600052C / 0x4E30|_0089_0090_009C|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxTp2Der "8939.39"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|button3 "屏幕数据"|Click|0x060004F4 / 0x804BC|0x060004F3 / 0x4DBE|_0089_008E_0096|0x060004F6 \x8b\x95.\x8b\x94::\x89\x8e\x99|
|tabPage3 "定点转弯(FlyOver-DF)"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||
|textBoxAltiTp "899"|MouseEnter|0x06000534 / 0x83514|0x06000533 / 0x4E8A|_0089_0091_008A|0x06000512 \x8b\x95.\x8b\x94::ShowMessage, 0x06000888 \x90\x9c.\x90\x9b::\x8b\x8f\x9d|
|textBoxAltiTp "899"|MouseLeave|0x06000514 / 0x83194|0x06000513 / 0x4DE8|_0089_008F_009C||

## 可达性与未绑定方法

P501 buttonEvl：一键评估，Visible=false；P50C button8：直线段评估，Visible=false；P50D button7：转弯区评估，Visible=false。三个绑定体均只显示“请指定转弯点。”。P50F button9为空且隐藏。没有类别或Tab SelectedIndexChanged绑定；默认Tab index=0，方向框是左/右转选择。

P5CD（高度评价）与P5D8（指定点评价）在全程序集已解码静态调用表中均无入边。三条嵌套sort selector P54C/P54D/P54E也没有ldftn调用位点。不能补造一键 pipeline 或危险值合并策略。

P4FA为未绑定XYZ高亮/视图定位方法；P4FE为未绑定坐标转换/结果表方法。P4F5是未绑定ScreenData转发。P508为空未绑定；P509有TP高度刷新逻辑，但只绑定PDG TextChanged；TP距离本身没有TextChanged绑定。所有主类方法保存在 evidence/method-index.csv 与完整source。