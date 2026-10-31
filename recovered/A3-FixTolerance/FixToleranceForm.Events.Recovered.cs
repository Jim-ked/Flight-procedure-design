// Native event slices; renamed controls map to controls.csv. No designer/config recreation.
// TODO-RE: Autodesk 23.1 reference compilation and researcher-run host checks.
#if AUTOCAD
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
public partial class FixToleranceFormRecovered:Form {
    // _0095_0092, _0096_0096, _0096_0097, _0096_0092, _0096_008E
    public TextBox AccuracyDegrees,DistanceNm,Suffix,HeightMetres,HalfAngle;
    // _0095_0095, _0096_0094, _0095_0093, _0095_009A, _0096_008A
    public CheckBox Dme,SpecifiedDistance,Track,Kk,BlindTrack;
    // _0096_008D, _0096_008F
    public RadioButton BlindVor,BlindNdb;
    public RadioButton FacilityVor,FacilityIls,FacilityNdb;
    public CheckBox Guide;
    public Control VorImage,NdbImage;
    public Button ToleranceButton,BlindButton;
    // Integration glue for the existing events.csv registrations, call once after
    // binding controls. Not an invented original method; designer/config still TODO.
    public void AttachCalculationEvents() {
        ToleranceButton.Click+=DrawTolerance;BlindButton.Click+=DrawBlind;
        FacilityVor.CheckedChanged+=VorChanged;FacilityIls.CheckedChanged+=IlsChanged;FacilityNdb.CheckedChanged+=NdbChanged;
        Guide.CheckStateChanged+=GuideChanged;Dme.CheckedChanged+=DmeChanged;SpecifiedDistance.CheckedChanged+=SpecifiedChanged;
        BlindVor.CheckedChanged+=BlindVorChanged;BlindNdb.CheckedChanged+=BlindNdbChanged;Suffix.Leave+=BlindNdbChanged;
    }
    // --/--.cs:4429–4497; retain literal dot strings rather than culture ToString.
    public void VorChanged(object sender,EventArgs args) { if(FacilityVor.Checked) AccuracyDegrees.Text=Guide.Checked?"5.2":"4.5"; }
    public void IlsChanged(object sender,EventArgs args) { if(FacilityIls.Checked) AccuracyDegrees.Text=Guide.Checked?"2.4":"1.4"; }
    public void NdbChanged(object sender,EventArgs args) { if(FacilityNdb.Checked) AccuracyDegrees.Text=Guide.Checked?"6.9":"6.2"; }
    public void GuideChanged(object sender,EventArgs args) {
        if(FacilityVor.Checked) AccuracyDegrees.Text=Guide.Checked?"5.2":"4.5";
        else if(FacilityIls.Checked) AccuracyDegrees.Text=Guide.Checked?"2.4":"1.4";
        else if(FacilityNdb.Checked) AccuracyDegrees.Text=Guide.Checked?"6.9":"6.2";
    }
    // processed212–215, --/--.cs:4973–5031.
    public void BlindNdbChanged(object sender,EventArgs args) {
        if(BlindNdb.Checked) { HalfAngle.Text="40";VorImage.Visible=false;NdbImage.Visible=true; }
    }
    public void BlindVorChanged(object sender,EventArgs args) {
        if(BlindVor.Checked) { HalfAngle.Text="50";VorImage.Visible=true;NdbImage.Visible=false; }
    }
    public void SpecifiedChanged(object sender,EventArgs args) { DistanceNm.Enabled=SpecifiedDistance.Checked; }
    public void DmeChanged(object sender,EventArgs args) {
        DistanceNm.Enabled=SpecifiedDistance.Checked;Suffix.Enabled=Dme.Checked;SpecifiedDistance.Enabled=Dme.Checked;
    }
    private static Point3d Polar(Point3d origin,double distance,double angle) {
        return new Point3d(origin.X+distance*Math.Cos(angle),origin.Y+distance*Math.Sin(angle),0);
    }
    // Original0600020F/RVA19CD4 processed20E; --/--.cs:4502.
    public void DrawTolerance(object sender,EventArgs args) {
        var db=HostApplicationServices.WorkingDatabase;var doc=AcApp.DocumentManager.MdiActiveDocument;
        CadInteractionRecovered.SetFocus(doc.Window.Handle);Visible=false;
        Point3d station=CadInteractionRecovered.Pick("请选择导航台");
        if(station==Point3d.Origin) { Visible=true;return; }
        Point3d direction=CadInteractionRecovered.Pick("请指定引导方向");
        if(direction==Point3d.Origin) { Visible=true;return; }
        Visible=true;
        double theta=Math.Atan2(direction.Y-station.Y,direction.X-station.X);
        double r=Math.Sqrt(Math.Pow(station.Y-direction.Y,2)+Math.Pow(station.X-direction.X,2));
        if(Dme.Checked) {
            if(SpecifiedDistance.Checked) {
                try { r=1852*Convert.ToDouble(DistanceNm.Text); }
                catch {
                    if(!CadInteractionRecovered.Validate(DistanceNm)) {
                        MessageBox.Show("DME距离输入错误，请检查。","输入错误",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return;
                    }
                }
            } else DistanceNm.Text=Math.Round(r/1852,1).ToString("0.0");
        }
        double angle=Convert.ToDouble(AccuracyDegrees.Text)*Math.PI/180;
        double error=r*0.0125+460;
        var station2d=new Point3d(station.X,station.Y,0);
        Point3d late=Polar(station,r+error,theta),nominal=Polar(station,r,theta);
        var polylines=new List<List<Point3d>> { new List<Point3d> { Polar(station,r+error,theta-angle),station2d,Polar(station,r+error,theta+angle) } };
        if(Track.Checked) polylines.Add(new List<Point3d> { station2d,late });
        if(Kk.Checked) {
            using(var docLock=doc.LockDocument()) {
                CalcuCadRecovered.AppendWithoutMetadata(new Line(Polar(late,9260,theta+Math.PI/2),Polar(late,9260,theta-Math.PI/2)),db);
                var early=Polar(station,(r-error)*Math.Cos(angle),theta);
                CalcuCadRecovered.AppendWithoutMetadata(new Line(Polar(early,9260,theta+Math.PI/2),Polar(early,9260,theta-Math.PI/2)),db);
            }
        }
        AppendPolylineGroup(db,polylines);
        if(!Dme.Checked) return;
        using(var docLock=doc.LockDocument()) {
            var group=new Group();
            group.Append(CalcuCadRecovered.AppendWithoutMetadata(new Arc(station,r+error,theta-angle,theta+angle),db));
            group.Append(CalcuCadRecovered.AppendWithoutMetadata(new Arc(station,r,theta-angle,theta+angle),db));
            group.Append(CalcuCadRecovered.AppendWithoutMetadata(new Arc(station,r-error,theta-angle,theta+angle),db));
            using(var tr=db.TransactionManager.StartTransaction()) {
                db.AddDBObject(group);tr.AddNewlyCreatedDBObject(group,true);tr.Commit();
            }
        }
        if(!DistanceNm.Text.Contains(".")) DistanceNm.Text+=".0";
        Suffix.Text=Suffix.Text.ToUpper();
        CalcuCadRecovered.AppendWithoutMetadata(new DBText { Position=SpecifiedDistance.Checked?nominal:direction,Height=500,TextString="D"+DistanceNm.Text+Suffix.Text },db);
    }
    // Original06000212/RVA1A628 processed211; --/--.cs:4726.
    public void DrawBlind(object sender,EventArgs args) {
        var db=HostApplicationServices.WorkingDatabase;
        CadInteractionRecovered.SetFocus(AcApp.DocumentManager.MdiActiveDocument.Window.Handle);Visible=false;
        var station=CadInteractionRecovered.Pick("请选择导航台");
        if(station==Point3d.Origin) { Visible=true;return; }
        double h,angle;
        try { h=Convert.ToDouble(HeightMetres.Text);angle=Convert.ToDouble(HalfAngle.Text); }
        catch {
            CadInteractionRecovered.Validate(HeightMetres);CadInteractionRecovered.Validate(HalfAngle);
            MessageBox.Show("数据输入有错误，请检查。","输入错误",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            return; // Original leaves Visible=false here; no added finally.
        }
        if(h<=0) { Visible=true;return; }
        double radius=h*Math.Tan(angle*Math.PI/180);
        if(BlindTrack.Checked) {
            var inbound=CadInteractionRecovered.Pick("请指定入航方向");
            if(inbound==Point3d.Origin) { Visible=true;return; }
            double theta=Math.Atan2(inbound.Y-station.Y,inbound.X-station.X);
            double[,] endpoints=FixToleranceRecovered.BlindTrackEndpoints(station.X,station.Y,radius,theta,BlindVor.Checked,BlindNdb.Checked);
            AppendPolylineGroup(db,new List<List<Point3d>> {
                new List<Point3d> { new Point3d(endpoints[0,0],endpoints[0,1],0),new Point3d(endpoints[1,0],endpoints[1,1],0) },
                new List<Point3d> { new Point3d(endpoints[2,0],endpoints[2,1],0),new Point3d(endpoints[3,0],endpoints[3,1],0) }
            });
        }
        Visible=true;
        CalcuCadRecovered.AppendWithoutMetadata(new Circle(station,Vector3d.ZAxis,radius),db);
    }
    // -/-.cs:1458 processed87, empty-metadata call sites only. Group is added
    // directly with AddDBObject; no invented named group dictionary registration.
    public static void AppendPolylineGroup(Database db,List<List<Point3d>> paths) {
        using(var docLock=AcApp.DocumentManager.MdiActiveDocument.LockDocument())
        using(var tr=db.TransactionManager.StartTransaction()) {
            var group=new Group();
            foreach(var path in paths) {
                var polyline=new Polyline();
                for(int i=0;i<path.Count;i++) polyline.AddVertexAt(i,new Point2d(path[i].X,path[i].Y),0,0,0);
                group.Append(CalcuCadRecovered.AppendWithoutMetadata(polyline,db));
            }
            db.AddDBObject(group);tr.AddNewlyCreatedDBObject(group,true);tr.Commit();AcApp.UpdateScreen();
        }
    }
}
#endif
