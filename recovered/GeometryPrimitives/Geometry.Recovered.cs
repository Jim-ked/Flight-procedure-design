using System;
using System.Collections.Generic;
// Arithmetic carriers for recovered methods; not a replacement geometry design.
public class RePoint {
    public double X,Y,Z;public string ID,Name;
    public RePoint(double x=0,double y=0,double z=0) {X=x;Y=y;Z=z;}
    public static double Distance(RePoint a,RePoint b) {return Math.Sqrt(Math.Pow(b.X-a.X,2)+Math.Pow(b.Y-a.Y,2));}
    public static double Bearing(RePoint a,RePoint b) {return Math.Atan2(b.Y-a.Y,b.X-a.X);}
    public static RePoint Mirror(RePoint p) {return new RePoint(p.X,-p.Y,p.Z);}
    public static RePoint ZeroZ(RePoint p) {return new RePoint(p.X,p.Y);}
    public static RePoint Rotate(RePoint origin,RePoint p,double angle) {
        double r=Distance(origin,p),a=Bearing(origin,p)+angle;
        return new RePoint(origin.X+r*Math.Cos(a),origin.Y+r*Math.Sin(a),origin.Z+p.Z);
    }
    public static RePoint Translate(RePoint p,double x=0,double y=0,double z=0) {return new RePoint(p.X+x,p.Y+y,p.Z+z);}
    public static List<RePoint> Symmetric(RePoint a,RePoint b) {return new List<RePoint>{a,b,Mirror(b),Mirror(a),a};}
}
// Original MethodDef: original methods map in shared-geometry-map.md (processed7E6–7ED).
// Evidence: --/--.cs:83875–84045 and independent IL. Keep ±1e6 divide sentinel.
public class ReLine {
    public double A,B,C;
    public ReLine() {A=1;B=1;C=1;}
    public ReLine(RePoint a,RePoint b) {Set(a,b);}
    public void Set(RePoint a,RePoint b) {A=b.Y-a.Y;B=a.X-b.X;C=a.Y*(b.X-a.X)-a.X*(b.Y-a.Y);}
    public void Through(RePoint p,double angle) {Set(p,new RePoint(p.X+1000*Math.Cos(angle),p.Y+1000*Math.Sin(angle),p.Z));}
    public static double Divide(double n,double d) {return d!=0?n/d:(n>0?1000000:-1000000);}
    public double X(double y) {return Divide(-C-B*y,A);}
    public double Y(double x) {return Divide(-C-A*x,B);}
    public double Distance(RePoint p) {return Math.Abs(A*p.X+B*p.Y+C)/Math.Sqrt(A*A+B*B);}
    public double Angle() {return B==0?Math.PI/2:Math.Atan(-A/B);}
    public RePoint Intersection(ReLine p) {return new RePoint(Divide(p.C*B-C*p.B,A*p.B-p.A*B),Divide(p.C*A-C*p.A,B*p.A-p.B*A));}
}
