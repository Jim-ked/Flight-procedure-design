using System;
public static class Round2Tests {
    static int checks;
    static void Equal(double expected,double actual,string name) {
        checks++;if(double.IsNaN(expected)?!double.IsNaN(actual):Math.Abs(expected-actual)>1e-7 || double.IsNaN(actual))throw new Exception(name+": "+actual+" expected "+expected);
    }
    static void Is(bool value,string name) {checks++;if(!value)throw new Exception(name);}
    public static int Main() {try {Run();return 0;}catch(Exception e){Console.WriteLine("FAIL: "+e.Message);return 1;}}
    static void Run() {
        // Nominal, boundary and degenerate cases derived before writing ports.
        Equal(5,DepartureFormRecovered.PickedDistance(new RePoint(0,0,9),new RePoint(-3,4,-90)),"TP is unsigned XY distance, not projection");
        Equal(0,DepartureFormRecovered.PickedDistance(new RePoint(1,2,5),new RePoint(1,2,500)),"vertical pick has zero XY distance");
        var heights=DepartureFormRecovered.Heights(3000,0,.033);Equal(104,heights[0],"reference height");Equal(305,heights[1],"calculation fixed ten percent");
        Equal(5,DepartureFormRecovered.Heights(0,0,0)[1],"height boundary at DER");
        var runway=new DepartureRunway(new RePoint(100,200,0),new RePoint(0,200,40));
        var local=runway.Local(new RePoint(1100,220,90));Equal(1000,local.X,"THR to DER positive forward");Equal(20,local.Y,"local side");Equal(90,local.Z,"local Z difference");
        var turn=new TurnParametersRecovered(300,305,15,60,15);turn.TAS=300;turn.Wind=60;
        var point=new PointDepartureRecovered(runway,turn,100,200,.033,.04);
        Equal(3000,point.TpDistance,"TP recovered from calc altitude, not display distance");Equal(104,point.ReferenceHeight,"constructor actual gradient height");
        Equal(2900,point.Early.X,"earliest station");Equal(3200,point.Latest.X,"latest station");Equal(3800,point.DelayEnd.X,"six second delay");
        Is(point.Boundaries.Count==4 && point.Boundaries[0].Count==5,"four closed-by-repeat polygons");
        var a=point.Evaluate(new RePoint(100,0,50),false);Equal(.8,a.MOC,"straight MOC no minimum");Equal(8.3,a.AllowableAltitude,"straight altitude");
        var b=point.Evaluate(new RePoint(100,0,50),true);Equal(2900,b.Dr,"recheck fixed early dr");Equal(2800,b.D0,"recheck backward do");Equal(75,b.MOC,"recheck minimum MOC");Is(b.Area=="直线段二次检查","recheck replaces row");
        var c=point.Evaluate(new RePoint(0,0,50),false);Is(double.IsPositiveInfinity(c.RequiredGradient),"zero distance raw division");
        var edge=point.Evaluate(new RePoint(2900,point.Early.Y,50),false);Is(edge.Area=="离场直线段","early endpoint inside straight");
        Equal(-1000000,ReLine.Divide(0,0),"zero numerator sentinel negative");Equal(1000000,ReLine.Divide(1,0),"positive sentinel");
        Equal(0,new ReLine(new RePoint(0,0),new RePoint(10,0)).Y(4),"horizontal line");
        Is(double.IsNaN(new ReLine(new RePoint(0,0),new RePoint(0,0)).Distance(new RePoint(1,1))),"degenerate distance NaN retained");
        var altRunway=new DepartureRunway(new RePoint(),new RePoint(-2000,0));
        var alt=new AltitudeDepartureRecovered(altRunway,turn,.033,.04,true);
        Equal(300/.033,alt.Station,"altitude station subtracts DER+5");
        Is(alt.Boundaries.Count==3,"altitude early flag adds runway polygon");
        var ar=alt.Evaluate(new RePoint(100,0,50));Equal(.8,ar.MOC,"altitude straight MOC");
        var at=alt.Evaluate(new RePoint(alt.Station,0,400));Equal(75,at.MOC,"KK endpoint classified after");Is(double.IsPositiveInfinity(at.RequiredGradient),"altitude KK zero do raw division");
        var ae=alt.Evaluate(new RePoint(0,150,50));Is(ae.Area=="离场直线段--KK线之前","DER inclusive straight before early");
        var early=alt.Evaluate(new RePoint(-100,0,400));Equal(305,early.AllowableAltitude,"early runway constant turn height");Equal(0,early.RequiredGradient,"early runway default gradient");
        var noearly=new AltitudeDepartureRecovered(altRunway,turn,.033,.04,false);Is(noearly.Boundaries.Count==2,"early disabled");
        Equal(309,noearly.Evaluate(new RePoint(-100,0,400)).AllowableAltitude,"before DER uses turn altitude");
        Is(double.IsPositiveInfinity(new AltitudeDepartureRecovered(runway,turn,0,.04,true).Station),"altitude zero gradient retained");
        var omni=new OmniDepartureRecovered(altRunway,0,300,600,.033);
        Equal(115/.033,omni.K.X,"omni 120m transition");Equal(295/.033,omni.F.X,"omni TNA station");
        Equal(omni.F.X+1400+300/.033,omni.Radius,"omni final altitude radius");
        Is(omni.Evaluate(new RePoint(0,1e6,0)).Area=="out","omni circle exclusion");
        var oz=omni.Evaluate(new RePoint(-100,0,50));Equal(75,oz.MOC,"omni runway 75");Equal(300,oz.AllowableAltitude,"omni runway TNA");
        var oz1=omni.Evaluate(new RePoint(100,0,50));Equal(.8,oz1.MOC,"omni zone1 no minimum");
        Is(oz1.Area.StartsWith("1区"),"omni zone1 name");
        var oz2=omni.Evaluate(new RePoint(5000,0,50));Is(oz2.Area.StartsWith("2区"),"omni zone2 name");
        var oz3=omni.Evaluate(new RePoint(omni.F.X+100,0,50));Equal(100,oz3.D0,"omni forward extension");Equal(75,oz3.MOC,"omni forward MOC minimum");
        Is(double.IsInfinity(new OmniDepartureRecovered(altRunway,0,300,600,0).K.X),"omni zero PDG preserved");
        Equal(13,TurnAreaRecovered.PickedDs(new RePoint(0,0,0),new RePoint(3,4,12)),"A8 Ds pick is 3D unlike A7");
        var kkarea=new TurnAreaRecovered(new RePoint(0,0,100),new RePoint(100,0,999),1000,.04,75,"指定高度");
        var kr=kkarea.Evaluate(new RePoint(50,100,120));Equal(-50,kr.X,"KK reversed endpoint axis");Equal(-100,kr.Y,"KK local outside side");
        Equal(100,kr.D0,"KK perpendicular segment distance");Equal(75,kr.MOC,"KK constant input MOC");Equal(104,kr.AllowableAltitude,"specified ignores Ds in PDA");Equal(.95,kr.RequiredGradient,"specified numerator and do");
        var kfree=new TurnAreaRecovered(new RePoint(0,0,100),new RePoint(100,0,0),1000,.04,75,"其他");Equal(144,kfree.Evaluate(new RePoint(50,100,120)).AllowableAltitude,"unspecified uses Ds+do no five");
        var ke=kkarea.Evaluate(new RePoint(0,0,120));Is(double.IsPositiveInfinity(ke.RequiredGradient),"A8 zero do division");
        Is(kkarea.Evaluate(new RePoint(1e8,1e8,0))!=null,"A8 no outer exclusion");
        Equal(0,TurnAreaRecovered.PickedDs(new RePoint(),new RePoint()),"A8 coincident pick");
        Equal(.25*Math.PI,DmeArcRecovered.Normalize(-1.75*Math.PI),"DME normalize one add");
        Equal(-Math.PI,DmeArcRecovered.Normalize(-3*Math.PI),"DME normalize is not modulo loop");
        Equal(Math.Tan(Math.PI/8),DmeArcRecovered.Bulge(0,Math.PI/2),"DME minor bulge");Is(double.IsNaN(DmeArcRecovered.Bulge(0,0)),"DME equal-angle bulge NaN");
        var ds=DmeArcRecovered.Sector(new RePoint(100,0),new RePoint(),100,0,Math.PI/2,20,true);Equal(1,ds.Z,"DME primary factor");
        Equal(.5,DmeArcRecovered.Sector(new RePoint(115,0),new RePoint(),100,0,Math.PI/2,20,true).Z,"DME secondary half reduction");
        Equal(0,DmeArcRecovered.Sector(new RePoint(120,0),new RePoint(),100,0,Math.PI/2,20,true).Z,"DME outer inclusive zero MOC");
        Is(DmeArcRecovered.Sector(new RePoint(121,0),new RePoint(),100,0,Math.PI/2,20,true).Name=="out","DME beyond outer");
        Equal(1,DmeArcRecovered.Sector(new RePoint(85,0),new RePoint(),100,0,Math.PI/2,20,false).Z,"DME end-sector one-sided primary");
        var dme=new DmeArcRecovered(new RePoint(),new RePoint(20000,0),new RePoint(0,123)," TEST",true);
        dme.Draw();Is(dme.Drawing.Entities.Count==6,"DME five offset paths plus text");
        Is(dme.Drawing.Arcs.Count==15,"DME three construction arcs at each offset");
        var dpoly=(RePolyline)dme.Drawing.Entities[2];Is(dpoly.Vertices.Count==6 && !dpoly.Closed,"DME central three-arc open path");
        var eval=dme.Evaluate(new[]{new RePoint(23704/Math.Sqrt(2),23704/Math.Sqrt(2),100)});
        Is(eval.Count==1,"DME nominal sector admitted");Equal(300,eval[0].MOC,"DME fixed 300 not editable input");Equal(400,eval[0].OCA,"DME OCA");
        var same=new DmeArcRecovered(new RePoint(),new RePoint(20000,0),new RePoint(30000,0));same.Draw();Is(same.Drawing.Entities.Count==0,"DME same bearing returns");
        Is(same.Evaluate(new[]{new RePoint(20000,0)}).Count==0,"DME equal-bearing evaluate returns");
        double dmeB=(2*20000*3704.0+3704.0*3704)/(2*20000+7408),dmeA=(2*20000*3704.0+3*3704.0*3704)/(2*20000+7408);
        Equal(dmeA+9260,dme.Drawing.Arcs[0].Radius,"DME IAF first radius");Equal(dmeB-9260,dme.Drawing.Arcs[1].Radius,"DME signed IF radius retained");Equal(23704-9260,dme.Drawing.Arcs[2].Radius,"DME first concentric radius");
        foreach(var bearings in new[]{new[]{20.0,100.0},new[]{20.0,300.0},new[]{300.0,20.0},new[]{100.0,20.0}}){
            double a0=bearings[0]*Math.PI/180,b0=bearings[1]*Math.PI/180;
            var dm=new DmeArcRecovered(new RePoint(),new RePoint(20000*Math.Cos(b0),20000*Math.Sin(b0)),new RePoint(123*Math.Cos(a0),123*Math.Sin(a0)));
            dm.Draw();Is(dm.Drawing.Entities.Count==5 && dm.Drawing.Arcs.Count==15,"DME four direction/wrap branches");
        }
        dme.MocInput="999";Equal(300,dme.Evaluate(new[]{new RePoint(23704/Math.Sqrt(2),23704/Math.Sqrt(2),100)})[0].MOC,"DME parsed MOC input ignored");
        // Independent line-distance expectations, targeting the previously untested C1-C5 branches.
        var c1=omni.Evaluate(new RePoint(-1500,200,50));Is(c1.Area.Contains("C1"),"omni C1 before S");Equal(Math.Sqrt(12500),c1.D0,"C1 distance to S");
        var c2=omni.Evaluate(new RePoint(-700,200,50));Is(c2.Area.Contains("C2"),"omni C2 nearest runway side");Equal(50,c2.D0,"C2 perpendicular distance");
        var c3=omni.Evaluate(new RePoint(1500,1000,50));Is(c3.Area.Contains("C3"),"omni C3 nearest 15 degree line");
        Equal((1000-150-1500*Math.Tan(Math.PI/12))*Math.Cos(Math.PI/12),c3.D0,"C3 perpendicular distance");
        var c4=omni.Evaluate(new RePoint(6500,4000,50));Is(c4.Area.Contains("C4"),"omni C4 nearest 30 degree line");
        Equal((4000-omni.K.Y-(6500-omni.K.X)*Math.Tan(Math.PI/6))*Math.Cos(Math.PI/6),c4.D0,"C4 perpendicular distance");
        var c5=omni.Evaluate(new RePoint(omni.F.X+100,omni.F.Y+100,50));Is(c5.Area.Contains("C5"),"omni C5 beyond F");Equal(Math.Sqrt(20000),c5.D0,"C5 distance to F");
        Equal(c3.D0,omni.Evaluate(new RePoint(1500,-1000,50)).D0,"omni mirrored side");
        Equal(c3.MOC,new OmniDepartureRecovered(altRunway,0,300,600,.033,false).Evaluate(new RePoint(1500,1000,50)).MOC,"omni early flag does not enter evaluator");
        var ac=alt.Evaluate(new RePoint(-100,200,400));Equal(50,ac.D0,"altitude early side do");Equal(307,ac.AllowableAltitude,"altitude early side uses turn height");
        Equal(100,alt.Evaluate(new RePoint(-1500,150,400)).D0,"altitude before early endpoint");
        Equal(6,DepartureFormRecovered.Heights(5,0,0)[1],"Math Round midpoint to even: 5.5 to 6");
        Equal(6,DepartureFormRecovered.Heights(15,0,0)[1],"Math Round midpoint to even: 6.5 to 6");
        Is(DmeArcRecovered.Sector(new RePoint(100,0),new RePoint(),100,1.5*Math.PI,.5*Math.PI,20,true).Name=="主区","DME wrapped sector includes zero");
        Equal(1,DmeArcRecovered.Sector(new RePoint(100,0),new RePoint(),100,0,Math.PI/2,0,true).Z,"zero width symmetric center primary");
        Is(double.IsNaN(DmeArcRecovered.Sector(new RePoint(100,0),new RePoint(),100,0,Math.PI/2,0,false).Z),"zero width asymmetric raw zero division");
        Round2Artifacts.Write(omni,point,alt,dme);
        Console.WriteLine("PASS "+checks+" Round2 assertions; recovered code only, not original runtime.");
    }
}
