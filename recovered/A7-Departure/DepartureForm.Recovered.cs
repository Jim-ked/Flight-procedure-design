using System;
// Pure event arithmetic. Actual CAD bindings are documented in event-map.md.
public static class DepartureFormRecovered {
    // Original MethodDef: 0x0600028F; processed 0x0600028E.
    // Evidence: --/--.cs:15098; XY Euclidean distance, no projection/sign/Z.
    public static double PickedDistance(RePoint a,RePoint b) {return RePoint.Distance(a,b);}
    // Original MethodDef: 0x06000288 / 0x0600028A; processed287/289.
    // Evidence: --/--.cs:14868–14928; return [Reference, Calculation].
    public static double[] Heights(double tpDistance,double derAltitude,double gradient) {
        return new[]{Math.Round(tpDistance*gradient+derAltitude+5),Math.Round(tpDistance*.1+derAltitude+5)};
    }
    // Original MethodDef: 0x06000286 / 0x06000287; processed285/286.
    // Evidence: --/--.cs:14846–14866; g=0 means do not overwrite TextBox.
    public static double? AltitudeStation(double turnAltitude,double derAltitude,double gradient) {
        return gradient==0?(double?)null:Math.Round((turnAltitude-derAltitude-5)/gradient,1);
    }
}
// Original MethodDef: 0x060000AD / 0x060000AE; processed AC/AD.
// Evidence: -/-.cs:3103–3131; THR→DER defines positive local X.
public sealed class DepartureRunway {
    public RePoint Der,Thr;public double Length,ReverseAngle,ForwardAngle;
    public DepartureRunway(RePoint der,RePoint thr) {Der=der;Thr=thr;Length=RePoint.Distance(der,thr);ReverseAngle=RePoint.Bearing(der,thr);ForwardAngle=RePoint.Bearing(thr,der);}
    public RePoint Local(RePoint p) {
        double d=RePoint.Distance(Der,p),a=RePoint.Bearing(Der,p)-ForwardAngle;
        return new RePoint(d*Math.Cos(a),d*Math.Sin(a),p.Z-Der.Z){ID=p.ID,Name=p.Name};
    }
    // A7 geometry output rotates, explicitly flattens Z, then translates XY.
    public RePoint Drawing(RePoint p) {var q=RePoint.Rotate(new RePoint(),p,ForwardAngle);return new RePoint(q.X+Der.X,q.Y+Der.Y);}
}
