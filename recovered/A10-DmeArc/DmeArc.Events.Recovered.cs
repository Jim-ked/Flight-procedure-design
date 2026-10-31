#if ACAD2026_TEST
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataTable=System.Data.DataTable;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
public partial class DmeArcRecovered {
    public void BindInputs(TextBox ox,TextBox oy,TextBox ix,TextBox iy,TextBox ax,TextBox ay,TextBox moc){
        _0087_008F_009A.NativeControl=ox;_0087_008F_009B.NativeControl=oy;_0087_008F_0093.NativeControl=ix;_0087_008F_0094.NativeControl=iy;_0087_008F_008D.NativeControl=ax;_0087_008F_008C.NativeControl=ay;_0087_008F_009E.NativeControl=moc;
    }
    // Raw textbox transfer keeps invalid text until the recovered validation branch.
    public static DmeArcRecovered FromText(string ox,string oy,string ix,string iy,string ax,string ay,string moc,string suffix,bool label){
        var m=new DmeArcRecovered(new RePoint(),new RePoint(),new RePoint(),suffix,label);
        m._0087_008F_009A.Text=ox;m._0087_008F_009B.Text=oy;m._0087_008F_0093.Text=ix;m._0087_008F_0094.Text=iy;m._0087_008F_008D.Text=ax;m._0087_008F_008C.Text=ay;m.MocInput=moc;return m;
    }
}
public partial class DmeObstacleFormRecovered {
    public TextBox NavaidX,NavaidY,IfX,IfY,IafX,IafY,Moc,NavName;public CheckBox DistanceLabel;public Label InsideStatus;
    DmeArcRecovered Model(){var m=DmeArcRecovered.FromText(NavaidX.Text,NavaidY.Text,IfX.Text,IfY.Text,IafX.Text,IafY.Text,Moc.Text,NavName.Text,DistanceLabel.Checked);m.BindInputs(NavaidX,NavaidY,IfX,IfY,IafX,IafY,Moc);m.DiagnosticOutput=message=>MessageBox.Show(message);return m;}
    // Original MethodDef: 060002D9/2DA/2DB; RVA: 379FC/37B24/37C54.
    // Evidence: P2D8/2D9/2DA, --/--.cs:19172-19219. No Origin-cancel exclusion.
    void Pick(TextBox x,TextBox y,string prompt){
        CadInteractionRecovered.SetFocus(AcApp.DocumentManager.MdiActiveDocument.Window.Handle);Visible=false;
        var p=CadInteractionRecovered.Pick(prompt);Visible=true;x.Text=Math.Round(p.X,2).ToString();y.Text=Math.Round(p.Y,2).ToString();
    }
    public void PickNavaid(object s,EventArgs e){Pick(NavaidX,NavaidY,"\n请选择导航台的位置");}
    public void PickIf(object s,EventArgs e){Pick(IfX,IfY,"\n请选择IF点的方向");}
    public void PickIaf(object s,EventArgs e){Pick(IafX,IafY,"\n请选择IAF点");}
    // Original MethodDef: 060002DC; RVA: 37D8C. Evidence: full native state machine.
    public void Draw(object s,EventArgs e){Model().DrawToCad();}
    // Original MethodDef: 060002DF; RVA: 3A5DC. Evidence: P2DE full evaluation IL.
    public void Evaluate(object s,EventArgs e){
        if(points==null||points.Count==0)return;var m=Model();int n=1;var input=new List<RePoint>();foreach(var point in points)input.Add(CadSelectionRecovered.Imported(point,n++));
        var results=m.Evaluate(input);if(m.EvaluatedText=="")return;Status.Text=m.EvaluatedText;InsideStatus.Text=m.InsideText;ShowResults(results);
    }
    // Original MethodDef: 060002D8; RVA: 377AC. Evidence: P2D7 signed world XY.
    void ShowResults(List<DmeEvaluation> results){
        var t=new DataTable();string[] columns={"ID","名称","X坐标(m)","Y坐标(m)","高度(m)","所属区域","MOC(m)","OCA(m)"};
        for(int i=0;i<columns.Length;i++)t.Columns.Add(columns[i],i<2||i==5?typeof(string):typeof(double));
        foreach(var p in results)t.Rows.Add(p.ID,p.Name,Math.Round(-p.X,2),Math.Round(-p.Y,2),Math.Round(p.Z,2),p.Area,Math.Round(p.MOC,2),Math.Round(p.OCA,2));Grid.DataSource=t;Grid.Columns[1].Frozen=true;
    }
    // Original MethodDef: 060002E4; RVA: 3B9D4. Evidence: P2E3.
    public void HighlightRow(object s,DataGridViewCellEventArgs e){if(points!=null&&points.Count!=0&&e.ColumnIndex>=0&&e.RowIndex>=0)CadSelectionRecovered.Highlight(points,originals[Grid.Rows[e.RowIndex].Cells[0].Value.ToString()]);}
    // Original MethodDef: 060002E5-2EB; RVA identities in methods.json. Evidence: textbox events.
    public void ValidateNumber(object s,EventArgs e){CadInteractionRecovered.Validate((TextBox)s);}
}
#endif
