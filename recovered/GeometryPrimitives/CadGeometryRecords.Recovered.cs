using System;
using System.Collections.Generic;
// Portable records of recovered CAD construction arguments, not an Autodesk kernel.
// Signed/NaN radii are retained for audit. Acceptance/exception behavior requires host verification.
public sealed class ReArc {
    public RePoint Center;public double Radius,StartAngle,EndAngle;
    public ReArc(RePoint center,double radius,double start,double end) {Center=new RePoint(center.X,center.Y,center.Z);Radius=radius;StartAngle=start;EndAngle=end;}
    public RePoint StartPoint {get{return At(StartAngle);}}public RePoint EndPoint {get{return At(EndAngle);}}
    RePoint At(double a){return new RePoint(Center.X+Radius*Math.Cos(a),Center.Y+Radius*Math.Sin(a),Center.Z);}
}
public sealed class ReVertex {public RePoint Point;public double Bulge,StartWidth,EndWidth;}
public sealed class RePolyline {
    public bool Closed;public List<ReVertex> Vertices=new List<ReVertex>();
    public void AddVertexAt(int index,RePoint p,double bulge,double start,double end) {Vertices.Insert(index,new ReVertex{Point=p,Bulge=bulge,StartWidth=start,EndWidth=end});}
}
public sealed class ReText {public double Height,Rotation;public string TextString;public int HorizontalMode,VerticalMode;public RePoint AlignmentPoint;}
public sealed class ReCadRecords {
    public List<object> Entities=new List<object>();public List<ReArc> Arcs=new List<ReArc>();
    public ReArc Arc(RePoint center,double radius,double start,double end) {var a=new ReArc(center,radius,start,end);Arcs.Add(a);return a;}
}
