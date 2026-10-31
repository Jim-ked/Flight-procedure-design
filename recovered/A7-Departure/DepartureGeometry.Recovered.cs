using System;
using System.Collections.Generic;
// Original MethodDef: 0x06000203 constructor / 0x06000205 boundary builder.
// Evidence: processed202/204, --/--.cs:4123–4227 / 4319–4334, independent IL.
public sealed class PointDepartureRecovered {
    public double TpDistance,ReferenceHeight,DerHeight,GradientBefore,GradientAfter,Kk;
    public RePoint Start,Early,Tp,Latest,DelayEnd;
    public ReLine Straight;public List<List<RePoint>> Boundaries;
    public PointDepartureRecovered(DepartureRunway runway,TurnParametersRecovered turn,double kk,double c,double before=.033,double after=.033) {
        DerHeight=runway.Der.Z;GradientBefore=before;GradientAfter=after;Kk=kk;
        TpDistance=(turn.Altitude-DerHeight-5)/.1;
        ReferenceHeight=TpDistance*before+DerHeight+5;
        double t=Math.Tan(Math.PI/12),delay=(turn.TAS+turn.Wind)/.6;
        Start=new RePoint(0,150,DerHeight);
        Early=new RePoint(TpDistance-kk,150+(TpDistance-kk)*t,ReferenceHeight-kk*before);
        Tp=new RePoint(TpDistance,150+TpDistance*t,ReferenceHeight);
        Latest=new RePoint(TpDistance+c,150+(TpDistance+c)*t,ReferenceHeight);
        DelayEnd=new RePoint(TpDistance+c+delay,150+(TpDistance+c+delay)*t,ReferenceHeight);
        Straight=new ReLine(Start,Early);
        Boundaries=new List<List<RePoint>>{RePoint.Symmetric(Start,Tp),RePoint.Symmetric(Early,Tp),RePoint.Symmetric(Tp,Latest),RePoint.Symmetric(Latest,DelayEnd)};
    }
    // Original MethodDef: 0x06000204; Original RVA: 0x19440.
    // Evidence: processed203 independent IL; no separate secondary-area evaluator.
    public DepartureEvaluation Evaluate(RePoint p,bool recheck) {
        var r=new DepartureEvaluation(p);double y=Math.Abs(p.Y),dr,d0;
        if(p.X>=0 && p.X<=Early.X && y<=Straight.Y(p.X)) {
            if(!recheck) {dr=p.X;d0=0;r.Area="离场直线段";r.MOC=dr*.008;}
            else {dr=TpDistance-Kk;d0=Early.X-p.X;r.Area="直线段二次检查";r.MOC=Math.Max(75,(dr+d0)*.008);}
        } else {
            dr=TpDistance-Kk;d0=y<=Early.Y?Math.Abs(p.X-Early.X):RePoint.Distance(new RePoint(p.X,y),Early);
            r.Area=p.X>=Early.X?"离场转弯区-kk'线之后":"离场转弯区-kk'线之前";r.MOC=Math.Max(75,(dr+d0)*.008);
        }
        r.Dr=dr;r.D0=d0;r.OCA=p.Z+r.MOC;r.AllowableAltitude=DerHeight+5+dr*GradientBefore+d0*GradientAfter;
        r.RequiredGradient=(r.OCA-DerHeight-5)/(dr+d0);return r;
    }
}
