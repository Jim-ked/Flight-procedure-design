#if ACAD2026_TEST
using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
public static class CadSelectionRecovered {
    // Original MethodDef: 0x060007D7; RVA: 0xC7F1C. Evidence: P7D6:83704-83735.
    public static bool CheckInput(System.Windows.Forms.TextBox box,string message){
        double n;if(string.IsNullOrWhiteSpace(box.Text)){System.Windows.Forms.MessageBox.Show(message,"\n输入错误，请检查。",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);box.Focus();box.BackColor=System.Drawing.Color.LightCoral;return false;}
        if(double.TryParse(box.Text,out n)){box.BackColor=System.Drawing.Color.White;return true;}
        message=message.Replace("不能为空","必须是一个有效的数字")+"\n";System.Windows.Forms.MessageBox.Show(message,"输入错误，请检查。",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);box.Focus();box.BackColor=System.Drawing.Color.LightCoral;return false;
    }
    // Original MethodDef: 0x060000B0; Original RVA: 0x857C.
    // Evidence: -/-.cs:3140-3183 / processed AF independent IL.
    public static void Highlight(List<DBPoint> points,DBPoint point) {
        foreach(var p in points)p.Unhighlight();AcApp.UpdateScreen();
        var ed=AcApp.DocumentManager.MdiActiveDocument.Editor;var pos=point.Position;
        try {var view=ed.GetCurrentView();double x=pos.X-view.Target.X,y=pos.Y-view.Target.Y;
            double a=-view.ViewTwist;view.CenterPoint=new Point2d(x*Math.Cos(a)-y*Math.Sin(a),x*Math.Sin(a)+y*Math.Cos(a));ed.SetCurrentView(view);
        }catch(Exception ex){ed.WriteMessage("\n居中视图失败: "+ex.Message);}
        point.Highlight();AcApp.UpdateScreen();
    }
    public static RePoint Imported(DBPoint point,int ordinal) {
        var p=ObstacleCadRecovered.Parse(point,ordinal.ToString());return new RePoint(p.X,p.Y,p.Z){ID=p.ID,Name=p.Name};
    }
}
#endif
