// Shared native input slices. No target assembly is loaded by this source.
#if AUTOCAD
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
public static class CadInteractionRecovered {
    [DllImport("user32.dll",EntryPoint="SetFocus")]
    public static extern int SetFocus(IntPtr handle);
    // -/-.cs:5236, processed113. Cancel returns Origin; Error retries.
    public static Point3d Pick(string prompt) {
        var editor=AcApp.DocumentManager.MdiActiveDocument.Editor;
        var options=new PromptPointOptions("\n"+prompt+", 按Esc键退出。");
        options.AllowArbitraryInput=true;
        while(true) {
            var result=editor.GetPoint(options);
            if(result.Status==PromptStatus.Cancel) {
                editor.WriteMessage("\n已取消点选择。");return Point3d.Origin;
            }
            if(result.Status==PromptStatus.Error) editor.WriteMessage("\n输入错误，请重试。");
            else if(result.Status==PromptStatus.OK) return result.Value;
        }
    }
    // --/--.cs:83668. Convert and TryParse are deliberately distinct.
    public static double Number(string text) {
        try { return Convert.ToDouble(text); }
        catch { MessageBox.Show(text+" 输入数据有误，请检查。","数据错误",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return 0; }
    }
    // --/--.cs:83681. A bad value alerts and RETURNS ZERO; it does not cancel drawing.
    public static double Number(TextBox box) {
        double value;
        if(double.TryParse(box.Text,out value)) return value;
        box.Focus();box.BackColor=Color.LightCoral;
        MessageBox.Show(box.Text+" 输入数据有误，请检查。","数据错误",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return 0;
    }
    // --/--.cs:83738, no alert in this helper.
    public static bool Validate(TextBox box) {
        double value;bool ok=double.TryParse(box.Text,out value);
        box.BackColor=ok?Color.White:Color.LightCoral;return ok;
    }
}
#endif
