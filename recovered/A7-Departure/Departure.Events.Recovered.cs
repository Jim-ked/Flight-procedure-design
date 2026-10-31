#if ACAD2026_TEST
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using DataTable=System.Data.DataTable;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
// Field bindings to the old designer, not a new application. No target DLL dependency.
public partial class DepartureObstacleFormRecovered {
    public TextBox DerX,DerY,DerZ,ThrX,ThrY,ThrZ,TurnAltitude,AltitudePdg,AltitudeAfter,AltitudeStation;
    public TextBox AltitudeIas,AltitudeBank,AltitudeWind,AltitudeTemperature;
    public TextBox TpDistance,KkDistance,CDistance,PointPdg,PointAfter,CalculationHeight,ReferenceHeight;
    public TextBox PointIas,PointBank,PointWind,PointTemperature,OmniPdg,Tna,FinalAltitude;
    public CheckBox EarlyTurn,SecondaryRecheck;public bool AltitudeIasKnots,AltitudeWindKnots,PointIasKnots,PointWindKnots;
    private RePoint pickedTp=new RePoint();
    static double Box(TextBox b){return CadInteractionRecovered.Number(b);}
    static double TextNumber(TextBox b){return CadInteractionRecovered.Number(b.Text);}
    DepartureRunway Runway(){return new DepartureRunway(new RePoint(Box(DerX),Box(DerY),Box(DerZ)),new RePoint(Box(ThrX),Box(ThrY),Box(ThrZ)));}
    // Original MethodDef: 0600027F/280; RVA: 2D36C/2D4B4. Evidence: P27E/27F.
    void PickRunway(TextBox x,TextBox y,TextBox z,string prompt){
        CadInteractionRecovered.SetFocus(AcApp.DocumentManager.MdiActiveDocument.Window.Handle);Visible=false;
        var p=CadInteractionRecovered.Pick(prompt);Visible=true;x.Text=Math.Round(p.X,2).ToString();y.Text=Math.Round(p.Y,2).ToString();z.Text=p.Z.ToString();
    }
    public void PickDer(object s,EventArgs e){PickRunway(DerX,DerY,DerZ,"\n请选择跑道末端点");}
    public void PickThr(object s,EventArgs e){PickRunway(ThrX,ThrY,ThrZ,"\n请选择跑道入口点");}
    // Original MethodDef: 06000293; RVA: 2FA98. Evidence: P292.
    public void SwapRunway(object s,EventArgs e){Swap(DerX,ThrX);Swap(DerY,ThrY);Swap(DerZ,ThrZ);}
    static void Swap(TextBox a,TextBox b){string t=a.Text;a.Text=b.Text;b.Text=t;}
    // Original MethodDef: 06000288; RVA: 2E580. Evidence: P287.
    public void PickTp(object s,EventArgs e){
        CadInteractionRecovered.SetFocus(AcApp.DocumentManager.MdiActiveDocument.Window.Handle);Visible=false;
        var p=CadInteractionRecovered.Pick("\n请在跑道延长线上，指定转弯点");Visible=true;pickedTp=new RePoint(p.X,p.Y,p.Z);
        var der=new RePoint(Box(DerX),Box(DerY),Box(DerZ));double d=DepartureFormRecovered.PickedDistance(der,pickedTp);
        TpDistance.Text=Math.Round(d,2).ToString();CalculationHeight.Text=Math.Round(d*.1+der.Z+5).ToString();ReferenceHeight.Text=Math.Round(d*TextNumber(PointPdg)/100+der.Z+5).ToString();
    }
    // Original MethodDef: 0600028B/28C; RVA: 2E954/2EA6C. Evidence: P28A/28B.
    public void PickKk(object s,EventArgs e){PickTolerance(KkDistance,"\n请在跑道延长线上，选择定位容差最早点");}
    public void PickC(object s,EventArgs e){PickTolerance(CDistance,"\n请在跑道延长线上，选择定位容差最晚点");}
    void PickTolerance(TextBox box,string prompt){
        CadInteractionRecovered.SetFocus(AcApp.DocumentManager.MdiActiveDocument.Window.Handle);Visible=false;
        var p=CadInteractionRecovered.Pick(prompt);box.Text=Math.Round(DepartureFormRecovered.PickedDistance(pickedTp,new RePoint(p.X,p.Y,p.Z)),2).ToString();Visible=true;
    }
    // Original MethodDef: 0600028A; RVA: 2E7F8. Evidence: P289.
    public void PointGradientChanged(object s,EventArgs e){double g=Box(PointPdg)/100,d=Box(TpDistance),z=Box(DerZ);var h=DepartureFormRecovered.Heights(d,z,g);ReferenceHeight.Text=h[0].ToString();CalculationHeight.Text=h[1].ToString();}
    // Original MethodDef: 06000286/287; RVA: 2E30C/2E450. Evidence: P285/286.
    public void AltitudeChanged(object s,EventArgs e){var d=DepartureFormRecovered.AltitudeStation(Box(TurnAltitude),Box(DerZ),Box(AltitudePdg)/100);if(d.HasValue)AltitudeStation.Text=d.Value.ToString();}
    // Original MethodDef: 06000290; RVA: 2F3B8. Evidence: P28F is empty.
    public void PointCalculate(object s,EventArgs e){}
    TurnParametersRecovered AltTurn(){double i=Box(AltitudeIas),h=Box(TurnAltitude),b=Box(AltitudeBank),t=Box(AltitudeTemperature),w=Box(AltitudeWind);return new TurnParametersRecovered(i*(AltitudeIasKnots?1.852:1),h,b,w*(AltitudeWindKnots?1.852:1),t);}
    TurnParametersRecovered PointTurn(){double i=TextNumber(PointIas),b=TextNumber(PointBank),t=TextNumber(PointTemperature),w=TextNumber(PointWind),h=TextNumber(CalculationHeight);return new TurnParametersRecovered(i*(PointIasKnots?1.852:1),h,b,w*(PointWindKnots?1.852:1),t);}
    PointDepartureRecovered PointModel(DepartureRunway r){var turn=PointTurn();return new PointDepartureRecovered(r,turn,TextNumber(KkDistance),TextNumber(CDistance),TextNumber(PointPdg)/100,TextNumber(PointAfter)/100);}
    AltitudeDepartureRecovered AltModel(DepartureRunway r){double before=Box(AltitudePdg)/100,after=Box(AltitudeAfter)/100;var turn=AltTurn();return new AltitudeDepartureRecovered(r,turn,before,after,EarlyTurn.Checked);}
    OmniDepartureRecovered OmniModel(DepartureRunway r){return new OmniDepartureRecovered(r,0,TextNumber(Tna),TextNumber(FinalAltitude),TextNumber(OmniPdg)/100);}
    // Original MethodDef: 06000283 / 28E / 292; RVA: 2D9B0 / 2EEBC / 2F730.
    // Evidence: P282/28D/291. local.Z is explicitly restored to absolute obstacle Z.
    void EvaluateRows(Func<DepartureRunway,Func<RePoint,DepartureEvaluation>> make,bool omni){
        if(points==null||points.Count==0)return;var runway=Runway();var eval=make(runway);var list=new List<DepartureEvaluation>();int n=1;
        foreach(var point in points){var p=CadSelectionRecovered.Imported(point,n++);var local=runway.Local(p);local.Z=p.Z;list.Add(eval(local));}
        Status.Text="已评估"+list.Count+"个障碍物。"+(omni?list.Count+"个障碍物在范围内":"");ShowResults(list.OrderByDescending(p=>p.RequiredGradient));
    }
    public void EvaluateAltitude(object s,EventArgs e){EvaluateRows(r=>{var m=AltModel(r);return p=>m.Evaluate(p);},false);}
    public void EvaluatePoint(object s,EventArgs e){EvaluateRows(r=>{var m=PointModel(r);return p=>m.Evaluate(p,SecondaryRecheck.Checked);},false);}
    public void EvaluateOmni(object s,EventArgs e){EvaluateRows(r=>{var m=OmniModel(r);return p=>m.Evaluate(p);},true);}
    // Original MethodDef: 0600027C; RVA: 2CA8C. Evidence: P27B table columns/rounding.
    void ShowResults(IEnumerable<DepartureEvaluation> rows){
        var t=new DataTable();string[] columns={"ID","名称","X坐标(m)","Y坐标(m)","高度(m)","所属区域","dr(m)","d0(m)","MOC(m)","OCA(m)","程序高度(m)","minPDG(%)"};
        for(int i=0;i<columns.Length;i++)t.Columns.Add(columns[i],i<2||i==5||i==6||i==7?typeof(string):typeof(double));
        foreach(var p in rows)t.Rows.Add(p.ID,p.Name,Math.Round(p.X,2),Math.Round(p.Y,2),Math.Round(p.Z,2),p.Area,Math.Round(p.Dr,2),Math.Round(p.D0,2),Math.Round(p.MOC),Math.Round(p.OCA),Math.Round(p.AllowableAltitude,2),Math.Round(p.RequiredGradient*100,1));
        Grid.DataSource=t;Grid.Columns[1].Frozen=true;
    }
    // Original MethodDef: 06000281; RVA: 2D5F8. Evidence: P280 (only XY input).
    public void ConvertCoordinates(object s,EventArgs e){
        if(points==null||points.Count==0)return;var r=new DepartureRunway(new RePoint(TextNumber(DerX),TextNumber(DerY)),new RePoint(TextNumber(ThrX),TextNumber(ThrY)));int n=1;var list=new List<DepartureEvaluation>();
        foreach(var point in points){var p=CadSelectionRecovered.Imported(point,n++);var q=r.Local(p);q.Z=p.Z;list.Add(new DepartureEvaluation(q));}Status.Text="已转换"+list.Count+"个障碍物。";ShowResults(list);
    }
    // Original MethodDef: 06000284 / 28D / 291; RVA: 2DDDC / 2EB80 / 2F3C4.
    // Evidence: P283/28C/290. Reuse frozen Round1 exact polyline/anonymous-group helper.
    void DrawPaths(DepartureRunway r,List<List<RePoint>> paths){var output=new List<List<Point3d>>();foreach(var path in paths){var row=new List<Point3d>();foreach(var p in path){var q=r.Drawing(p);row.Add(new Point3d(q.X,q.Y,0));}output.Add(row);}FixToleranceFormRecovered.AppendPolylineGroup(HostApplicationServices.WorkingDatabase,output);}
    public void DrawAltitude(object s,EventArgs e){var r=Runway();DrawPaths(r,AltModel(r).Boundaries);MessageBox.Show("离场 定高转弯保护区 绘制成功！");}
    public void DrawPoint(object s,EventArgs e){var r=Runway();DrawPaths(r,PointModel(r).Boundaries);MessageBox.Show("离场 定点转弯保护区 绘制成功！");}
    public void DrawOmni(object s,EventArgs e){
        var r=Runway();var m=OmniModel(r);DrawPaths(r,m.Boundaries);var center=r.Drawing(new RePoint(m.S.X,0));
        using(var l=AcApp.DocumentManager.MdiActiveDocument.LockDocument())WsObjectCadRecovered.Append(new Circle(new Point3d(center.X,center.Y,0),Vector3d.ZAxis,m.Radius),HostApplicationServices.WorkingDatabase,"Radius: "+m.Radius+"m");MessageBox.Show("绘制成功！");
    }
    // Original MethodDef: 0600027D; RVA: 2CDD8. Evidence: P27C active CellClick.
    public void HighlightRow(object s,DataGridViewCellEventArgs e){if(points!=null&&points.Count!=0&&e.ColumnIndex>=0&&e.RowIndex>=0)CadSelectionRecovered.Highlight(points,originals[Grid.Rows[e.RowIndex].Cells[0].Value.ToString()]);}
}
#endif
