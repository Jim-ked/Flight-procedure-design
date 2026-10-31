#if ACAD2026_TEST
using System;
using System.ComponentModel;
using System.Windows.Forms;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
// Complements frozen Round1 partial form; existing Screen/Evaluate/Mark stay unchanged.
public partial class TurnAreaFormRecovered {
    // Original MethodDef: 0x06000252 / 253; RVA: 0x28B48 / 0x28C98.
    // Evidence: processed251/252, --/--.cs:12238-12289.
    void PickEnd(TextBox x,TextBox y,TextBox z,string prompt) {
        CadInteractionRecovered.SetFocus(AcApp.DocumentManager.MdiActiveDocument.Window.Handle);Visible=false;
        var p=CadInteractionRecovered.Pick(prompt);Visible=true;x.Text=Math.Round(p.X,2).ToString();y.Text=Math.Round(p.Y,2).ToString();z.Text=p.Z.ToString();
    }
    public void PickLeft(object sender,EventArgs e){PickEnd(LeftX,LeftY,LeftHeight,"\n请选择KK'左侧边界点");}
    public void PickRight(object sender,EventArgs e){PickEnd(RightX,RightY,RightHeight,"\n请选择KK'右侧边界点");}
    // Original MethodDef: 0x06000254; RVA: 0x28DE8. Evidence: processed253.
    public void SwapEnds(object sender,EventArgs e){Swap(LeftX,RightX);Swap(LeftY,RightY);Swap(LeftHeight,RightHeight);}
    static void Swap(TextBox a,TextBox b){string s=a.Text;a.Text=b.Text;b.Text=s;}
    // Original MethodDef: 0x06000260; RVA: 0x296C0. Evidence: processed25F.
    public void PickDs(object sender,EventArgs e){
        CadInteractionRecovered.SetFocus(AcApp.DocumentManager.MdiActiveDocument.Window.Handle);Visible=false;
        var a=CadInteractionRecovered.Pick("\n请指定第一点");var b=CadInteractionRecovered.Pick("\n请指定第二点");Visible=true;Dr.Text=Math.Round(a.DistanceTo(b),2).ToString();
    }
    // Original MethodDef: 0x06000263-266; RVA: 29808/29828/29848/29868.
    // Evidence: processed262-265; no assignment to CancelEventArgs.Cancel.
    public void LeftValidated(object s,EventArgs e){RightHeight.Text=LeftHeight.Text;}
    public void RightValidated(object s,EventArgs e){LeftHeight.Text=RightHeight.Text;}
    public void LeftValidating(object s,CancelEventArgs e){RightHeight.Text=LeftHeight.Text;}
    public void RightValidating(object s,CancelEventArgs e){LeftHeight.Text=RightHeight.Text;}
    // Original MethodDef: 0x06000251; RVA: 0x28A08. Evidence: processed250.
    public void HighlightRow(object s,DataGridViewCellEventArgs e){
        if(points!=null&&points.Count!=0&&e.ColumnIndex>=0&&e.RowIndex>=0)CadSelectionRecovered.Highlight(points,originals[Grid.Rows[e.RowIndex].Cells[0].Value.ToString()]);
    }
    // Original processed260/261 are empty event bodies (no hidden drawing).
    public void EmptyModeEvent(object s,EventArgs e){}
}
#endif
