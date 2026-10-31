// FormCalcu event bodies, renamed for maintenance. Controls are binding slots for
// the original designer (see controls/events.csv), not a newly designed UI.
// #if AUTOCAD paths remain uncompiled/unexecuted. No target DLL is referenced.
#if AUTOCAD
using System;
using System.Windows.Forms;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
public partial class BasicCalculationFormRecovered:Form {
    public TextBox FafAltitude,ThrElevation,Gp,Rdh,Intermediate,FafResult;
    public TextBox NpaSeconds,NpaResult,PaDh,PaElevation,Hlm,Hlr,HlCorrected,PaResult,SocHeight;
    public TextBox MissedStart,MissedEnd,MissedGradient,MissedResult,DerElevation,DepartureEnd,DepartureGradient,DepartureResult,CSeconds,CResult;
    public ComboBox Category,PaGp,Xz;
    public CheckBox FafLabel,NpaLabel,PaLabel,MissedLabel,DepartureLabel,CLabel;
    public TurnParameterInputRecovered NpaTurn,CTurn;
    public Button FafButton,NpaButton,PaButton,MissedButton,DepartureButton,CButton;
    // Recovery integration glue: reproduces the existing event registrations listed
    // in events.csv after the original designer controls are bound. Call once.
    // Not claimed to be an additional original MethodDef. Config/Load/Closed remain TODO.
    public void AttachCalculationEvents() {
        FafButton.Click+=DrawFaf;NpaButton.Click+=DrawNpa;PaButton.Click+=DrawPa;
        MissedButton.Click+=DrawMissed;DepartureButton.Click+=DrawDeparture;CButton.Click+=DrawC;
        Rdh.Validated+=OnFaf;ThrElevation.Validated+=OnFaf;Gp.Validated+=OnFaf;FafAltitude.Validated+=OnFaf;
        Xz.SelectedIndexChanged+=OnPa;Xz.Validated+=OnPa;
        Xz.TabIndexChanged+=DrawPa; // Actual old registration at --/--.cs:9532.
        SocHeight.Validated+=OnPa;PaDh.Validated+=OnPa;PaGp.SelectedIndexChanged+=OnPa;HlCorrected.Validated+=OnPa;
        MissedStart.Validated+=OnMissed;MissedEnd.Validated+=OnMissed;MissedGradient.Validated+=OnMissed;
        DerElevation.Validated+=OnDeparture;DepartureEnd.Validated+=OnDeparture;DepartureGradient.Validated+=OnDeparture;
        NpaSeconds.Validated+=OnNpa;CSeconds.Validated+=OnC;
        Category.SelectedIndexChanged+=CategoryChanged;PaElevation.Validated+=CategoryChanged;
    }
    private void OnFaf(object sender,EventArgs args) { CalculateFaf(); }
    private void OnNpa(object sender,EventArgs args) { CalculateNpa(); }
    private void OnPa(object sender,EventArgs args) { CalculatePa(); }
    private void OnMissed(object sender,EventArgs args) { CalculateMissed(); }
    private void OnDeparture(object sender,EventArgs args) { CalculateDeparture(); }
    private void OnC(object sender,EventArgs args) { CalculateC(); }
    private static Point3d Polar(Point3d p,double d,double a) { return new Point3d(p.X+d*Math.Cos(a),p.Y+d*Math.Sin(a),0); }
    private static double Heading(Point3d p,Point3d q) { return Math.Atan2(q.Y-p.Y,q.X-p.X); }
    // Original06000231/RVA1FB68. No further angle normalization.
    private static double Readable(double a) { return a>=-Math.PI/2 && a<=Math.PI/2?a:a+Math.PI; }
    private static DBText Aligned(string text,double height,Point3d at,double rotation) {
        return new DBText { Height=height,TextString=text,HorizontalMode=(TextHorizontalMode)1,VerticalMode=(TextVerticalMode)1,AlignmentPoint=at,Rotation=rotation };
    }
    // Original06000230/RVA1FAC0 processed22F.
    public double CalculateFaf() {
        double faf=CadInteractionRecovered.Number(FafAltitude),thr=CadInteractionRecovered.Number(ThrElevation);
        double tangent=Math.Tan(CadInteractionRecovered.Number(Gp)*Math.PI/180),rdh=CadInteractionRecovered.Number(Rdh);
        double d=(faf-rdh-thr)/tangent;FafResult.Text=Math.Round(d).ToString();return d;
    }
    // Original06000234/RVA1FFE8 processed233.
    public double CalculateNpa() {
        var turn=NpaTurn.Read();double seconds=CadInteractionRecovered.Number(NpaSeconds);
        double d=(turn.TAS+turn.Wind)*seconds/3.6;NpaResult.Text=Math.Round(d).ToString();return d;
    }
    // Original06000238/RVA2056C processed237. Invalid HL leaves output boxes unchanged.
    public double CalculatePa() {
        double gp=CadInteractionRecovered.Number(PaGp.Text),xz=CadInteractionRecovered.Number(Xz.Text);
        double dh=CadInteractionRecovered.Number(PaDh),hl=CadInteractionRecovered.Number(HlCorrected);
        if(hl==0) { MessageBox.Show("HL不得为0，请检查数据。");return -1; }
        double d=Math.Round((dh-hl)/Math.Tan(gp*Math.PI/180)+xz);
        PaResult.Text=d.ToString();SocHeight.Text=(dh-hl).ToString("f1");return d;
    }
    // Original0600023A/RVA2084C processed239. Low elevation COPIES text exactly.
    public void CorrectHl() {
        double elevation=CadInteractionRecovered.Number(PaElevation);
        if(elevation>900) {
            double m=CadInteractionRecovered.Number(Hlm),r=CadInteractionRecovered.Number(Hlr);
            HlCorrected.Text=Math.Round(Math.Round(m+r*.02*elevation/300,2),1).ToString();
        } else HlCorrected.Text=Hlm.Text;
    }
    // Original06000239/RVA20754 processed238.
    public void CategoryChanged(object sender,EventArgs args) {
        double[,] table={{35,8},{40,13},{43,18},{46,22},{49,26}};
        Hlm.Text=table[Category.SelectedIndex,0].ToString();Hlr.Text=table[Category.SelectedIndex,1].ToString();CorrectHl();CalculatePa();
    }
    public double CalculateMissed() {
        double start=CadInteractionRecovered.Number(MissedStart),end=CadInteractionRecovered.Number(MissedEnd),gradient=CadInteractionRecovered.Number(MissedGradient);
        double d=100*(end-start)/gradient;MissedResult.Text=Math.Round(d).ToString();return d;
    }
    public double CalculateDeparture() {
        double start=CadInteractionRecovered.Number(DerElevation),end=CadInteractionRecovered.Number(DepartureEnd),gradient=CadInteractionRecovered.Number(DepartureGradient);
        double d=100*(end-start-5)/gradient;DepartureResult.Text=Math.Round(d).ToString();return d;
    }
    public double CalculateC() {
        var turn=CTurn.Read();double seconds=CadInteractionRecovered.Number(CSeconds);
        double d=(turn.TAS+turn.Wind)*seconds/3.6;CResult.Text=Math.Round(d).ToString();return d;
    }
    // Original0600022E/RVA1F350 processed22D; --/--.cs:7534.
    public void DrawFaf(object sender,EventArgs args) {
        var db=HostApplicationServices.WorkingDatabase;var doc=AcApp.DocumentManager.MdiActiveDocument;
        CadInteractionRecovered.SetFocus(doc.Window.Handle);Visible=false;
        var thr=CadInteractionRecovered.Pick("请选择跑道入口点");
        if(thr==Point3d.Origin) { Visible=true;return; }
        var toward=CadInteractionRecovered.Pick("请指定FAF方向");
        if(toward==Point3d.Origin) { Visible=true;return; }
        Visible=true;double a=Heading(thr,toward),intermediate=CadInteractionRecovered.Number(Intermediate),d=CalculateFaf();
        var faf=Polar(thr,d,a);var ifPoint=Polar(thr,d+intermediate,a);
        using(var docLock=doc.LockDocument()) {
            var data=CalcuFactoryRecovered.Faf(faf.X,faf.Y,a,intermediate,CadInteractionRecovered.Number(FafAltitude),CadInteractionRecovered.Number(ThrElevation),CadInteractionRecovered.Number(Gp),CadInteractionRecovered.Number(Rdh),d);
            CalcuCadRecovered.CreateLine(data,db,Polar(faf,10000,a+Math.PI/2),Polar(faf,10000,a-Math.PI/2));
            CalcuCadRecovered.CreateLine(new CalcuLineRecovered { Kind=2,CenterX=ifPoint.X,CenterY=ifPoint.Y,Direction=a,Length=20000,Description="IF" },db,Polar(ifPoint,10000,a+Math.PI/2),Polar(ifPoint,10000,a-Math.PI/2));
        }
        if(!FafLabel.Checked) return;
        using(var docLock=doc.LockDocument()) {
            CalcuCadRecovered.AppendWithoutMetadata(Aligned("FAF-THR: "+Math.Round(d/1000,1)+"km",500,new Point3d((thr.X+faf.X)/2,(thr.Y+faf.Y)/2,0),Readable(a)),db);
            CalcuCadRecovered.AppendWithoutMetadata(new DBText { Height=1000,TextString="FAF",Position=faf },db);
            string altitudeText=FafAltitude.Text;
            double relative=CadInteractionRecovered.Number(FafAltitude)-CadInteractionRecovered.Number(ThrElevation);
            CalcuCadRecovered.AppendWithoutMetadata(new DBText { Height=1000,TextString=altitudeText+"("+Math.Round(relative)+")",Position=new Point3d(faf.X,faf.Y-1000,0) },db);
            CalcuCadRecovered.AppendWithoutMetadata(new DBText { Height=1000,TextString="IF",Position=ifPoint },db);
        }
    }
    // Original06000233/RVA1FBE0 processed232. Both points are picked before equality test.
    public void DrawNpa(object sender,EventArgs args) {
        var doc=AcApp.DocumentManager.MdiActiveDocument;CadInteractionRecovered.SetFocus(doc.Window.Handle);Visible=false;
        var start=CadInteractionRecovered.Pick("\n请输入复飞最晚点");var toward=CadInteractionRecovered.Pick("\n请指定复飞方向");Visible=true;
        if(start==toward) return;
        var turn=NpaTurn.Read();double seconds=CadInteractionRecovered.Number(NpaSeconds),d=CalculateNpa(),a=Heading(start,toward);
        var center=Polar(start,d,a);var plus=Polar(center,6000,a+Math.PI/2);var minus=Polar(center,-6000,a+Math.PI/2);
        using(var docLock=doc.LockDocument()) {
            var db=HostApplicationServices.WorkingDatabase;
            CalcuCadRecovered.CreateLine(CalcuFactoryRecovered.Npa(center.X,center.Y,a,turn.TAS,turn.IAS,turn.Wind,turn.Altitude,turn.Temperature,seconds,d),db,plus,minus);
            if(NpaLabel.Checked) CalcuCadRecovered.AppendWithoutMetadata(Aligned("SOC",500,plus,a-Math.PI/2),db);
        }
    }
    // Original06000236/RVA200E0 processed235. Negative d is ALSO saved in XData.
    public void DrawPa(object sender,EventArgs args) {
        var doc=AcApp.DocumentManager.MdiActiveDocument;CadInteractionRecovered.SetFocus(doc.Window.Handle);Visible=false;
        var start=CadInteractionRecovered.Pick("\n请输入跑道入口THR");var toward=CadInteractionRecovered.Pick("\n请指定复飞方向");Visible=true;
        if(start==toward) return;
        double d=-CalculatePa(),a=Heading(start,toward);var center=Polar(start,d,a);
        var plus=Polar(center,6000,a+Math.PI/2);var minus=Polar(center,-6000,a+Math.PI/2);
        using(var docLock=doc.LockDocument()) {
            var db=HostApplicationServices.WorkingDatabase;
            var data=CalcuFactoryRecovered.Pa(center.X,center.Y,a,Category.Text,CadInteractionRecovered.Number(PaGp.Text),CadInteractionRecovered.Number(Xz.Text),CadInteractionRecovered.Number(PaDh),CadInteractionRecovered.Number(PaElevation),CadInteractionRecovered.Number(Hlm),CadInteractionRecovered.Number(Hlr),CadInteractionRecovered.Number(HlCorrected),d);
            CalcuCadRecovered.CreateLine(data,db,plus,minus);
            if(PaLabel.Checked) CalcuCadRecovered.AppendWithoutMetadata(Aligned("CAT "+Category.Text+" SOC",500,plus,a-Math.PI/2),db);
        }
    }
    // Original0600023B/RVA20990 processed23A.
    public void DrawMissed(object sender,EventArgs args) {
        var db=HostApplicationServices.WorkingDatabase;var doc=AcApp.DocumentManager.MdiActiveDocument;
        CadInteractionRecovered.SetFocus(doc.Window.Handle);Visible=false;
        var start=CadInteractionRecovered.Pick("请选择起点");if(start==Point3d.Origin) { Visible=true;return; }
        var toward=CadInteractionRecovered.Pick("请指定复飞方向");if(toward==Point3d.Origin) { Visible=true;return; }
        Visible=true;double d=CalculateMissed(),a=Heading(start,toward);var center=Polar(start,d,a);
        var plus=Polar(center,10000,a+Math.PI/2);var minus=Polar(center,-10000,a+Math.PI/2);
        using(var docLock=doc.LockDocument()) {
            CalcuCadRecovered.CreateLine(CalcuFactoryRecovered.MissedTp(center.X,center.Y,a,CadInteractionRecovered.Number(MissedStart),CadInteractionRecovered.Number(MissedEnd),CadInteractionRecovered.Number(MissedGradient),d),db,plus,minus);
            if(!MissedLabel.Checked) return;
            CalcuCadRecovered.AppendWithoutMetadata(Aligned("SOC-TP:"+Math.Round(d/1000,1)+"km\n",500,new Point3d((start.X+center.X)/2,(start.Y+center.Y)/2,0),Readable(a)),db);
            CalcuCadRecovered.AppendWithoutMetadata(Aligned("TP",500,plus,a-Math.PI/2),db);
        }
    }
    // Original0600023E/RVA20FBC processed23D.
    public void DrawDeparture(object sender,EventArgs args) {
        var db=HostApplicationServices.WorkingDatabase;var doc=AcApp.DocumentManager.MdiActiveDocument;
        CadInteractionRecovered.SetFocus(doc.Window.Handle);Visible=false;
        var start=CadInteractionRecovered.Pick("请选择离场程序起点DER");if(start==Point3d.Origin) { Visible=true;return; }
        var toward=CadInteractionRecovered.Pick("请指定离场转弯点方向");if(toward==Point3d.Origin) { Visible=true;return; }
        Visible=true;double d=CalculateDeparture(),a=Heading(start,toward);var center=Polar(start,d,a);
        var plus=Polar(center,10000,a+Math.PI/2);var minus=Polar(center,-10000,a+Math.PI/2);
        using(var docLock=doc.LockDocument()) {
            CalcuCadRecovered.CreateLine(CalcuFactoryRecovered.DepartureTp(center.X,center.Y,a,CadInteractionRecovered.Number(DerElevation),CadInteractionRecovered.Number(DepartureEnd),CadInteractionRecovered.Number(DepartureGradient),d),db,plus,minus);
            if(!DepartureLabel.Checked) return;
            CalcuCadRecovered.AppendWithoutMetadata(Aligned("DER-TP:"+Math.Round(d/1000,1)+"km\n",500,new Point3d((start.X+center.X)/2,(start.Y+center.Y)/2,0),Readable(a)),db);
            CalcuCadRecovered.AppendWithoutMetadata(Aligned("TP",500,plus,a-Math.PI/2),db);
        }
    }
    // Original06000241/RVA21628 processed240. First Read() return is discarded.
    public void DrawC(object sender,EventArgs args) {
        var doc=AcApp.DocumentManager.MdiActiveDocument;CadInteractionRecovered.SetFocus(doc.Window.Handle);Visible=false;
        var start=CadInteractionRecovered.Pick("\n请输入起点");var toward=CadInteractionRecovered.Pick("\n请指定飞行方向");Visible=true;
        if(start==toward) return;
        CTurn.Read();double seconds=CadInteractionRecovered.Number(CSeconds),d=CalculateC(),a=Heading(start,toward);var center=Polar(start,d,a);
        var plus=Polar(center,6000,a+Math.PI/2);var minus=Polar(center,-6000,a+Math.PI/2);
        using(var docLock=doc.LockDocument()) {
            var db=HostApplicationServices.WorkingDatabase;
            CalcuCadRecovered.CreateLine(CalcuFactoryRecovered.C(center.X,center.Y,a,seconds,d),db,plus,minus);
            if(CLabel.Checked) CalcuCadRecovered.AppendWithoutMetadata(Aligned("C",500,plus,a-Math.PI/2),db);
        }
    }
}
#endif
