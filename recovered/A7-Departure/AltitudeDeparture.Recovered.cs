using System;
using System.Collections.Generic;
// Original MethodDef: 0x060001FC; Original RVA: 0x17F3C.
// Evidence: processed1FB ctor, _0088_0093.source.txt:3721-3847; IL in evidence.
public sealed class AltitudeDepartureRecovered {
    public double Station,TurnHeight,DerHeight,Before,After;public bool EarlyEnabled;
    public RePoint Start,Kk,Early,DelayEnd;public ReLine Straight,Perpendicular;
    public List<List<RePoint>> Boundaries=new List<List<RePoint>>();
    public AltitudeDepartureRecovered(DepartureRunway runway,TurnParametersRecovered turn,double before=.033,double after=.033,bool early=true) {
        Before=before;After=after;EarlyEnabled=early;DerHeight=runway.Der.Z;TurnHeight=turn.Altitude;
        Station=(TurnHeight-DerHeight-5)/before;double t=Math.Tan(Math.PI/12),delay=(turn.TAS+turn.Wind)/.6;
        Start=new RePoint(0,150,DerHeight);Kk=new RePoint(Station,150+Station*t,TurnHeight);
        Early=new RePoint(-runway.Length+600,150,DerHeight);DelayEnd=new RePoint(Station+delay,150+(Station+delay)*t,TurnHeight);
        Straight=new ReLine(Start,Kk);Perpendicular=new ReLine();Perpendicular.Through(Kk,Straight.Angle()+Math.PI/2);
        // Original MethodDef: 0x060001FE; Original RVA: 0x18C94. Original builder clears Z.
        foreach(var pair in new[]{new[]{Start,Kk},new[]{Kk,DelayEnd}})AddBoundary(pair[0],pair[1]);
        if(early)AddBoundary(Start,Early);
    }
    void AddBoundary(RePoint a,RePoint b) {var list=RePoint.Symmetric(a,b);for(int i=0;i<list.Count;i++)list[i]=RePoint.ZeroZ(list[i]);Boundaries.Add(list);}
    // Original MethodDef: 0x060001FD; Original RVA: 0x182F0.
    // Evidence: processed1FC, source3850-4001. Branch order and raw division retained.
    public DepartureEvaluation Evaluate(RePoint p) {
        var r=new DepartureEvaluation(p);r.Area="out";double y=p.Y>0?p.Y:-p.Y,dr=0,d0=0;
        if(p.X>=Kk.X) {
            dr=Station;d0=y<=Kk.Y?p.X-Kk.X:RePoint.Distance(new RePoint(p.X,y),Kk);
            r.Area="离场转弯区-kk'线之后";
        } else if(p.X>=Start.X && y<=Straight.Y(p.X)) {
            r.Area="离场直线段--KK线之前";r.Dr=p.X;r.D0=0;r.MOC=p.X*.008;r.OCA=p.Z+r.MOC;
            r.AllowableAltitude=DerHeight+5+p.X*Before;r.RequiredGradient=Math.Max(0,(r.OCA-DerHeight-5)/p.X);return r;
        } else if(p.X>Start.X) {
            if(y>=Perpendicular.Y(p.X)) {d0=RePoint.Distance(new RePoint(p.X,y),Kk);dr=Station;}
            else {d0=Straight.Distance(new RePoint(p.X,y));var normal=new ReLine();normal.Through(new RePoint(p.X,y),Perpendicular.Angle());dr=normal.Intersection(Straight).X;}
            r.Area="离场转弯区-kk'线之前";
        } else if(!EarlyEnabled) {
            d0=y<=Start.Y?Start.X-p.X:RePoint.Distance(new RePoint(p.X,y),Start);r.Area="离场转弯段--DER之前";
        } else if(p.X>=Early.X) {
            if(y<=Early.Y) {r.Area="早转弯区-净空道内";r.MOC=75;r.OCA=p.Z+75;r.AllowableAltitude=TurnHeight;return r;}
            d0=y-Early.Y;r.Area="离场转弯区-净空道侧方";
        } else {d0=y<=Early.Y?Early.X-p.X:RePoint.Distance(new RePoint(p.X,y),Early);r.Area="离场转弯区-最早点之前";}
        r.Dr=dr;r.D0=d0;r.MOC=Math.Max(75,(dr+d0)*.008);r.OCA=p.Z+r.MOC;
        r.AllowableAltitude=TurnHeight+d0*After;r.RequiredGradient=Math.Max(0,(r.OCA-TurnHeight)/d0);return r;
    }
}
