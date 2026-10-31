using System;
using System.Collections.Generic;
namespace Recovered.A4 {
// E2 structured reading of P2F9; mechanical flattened event retained separately.
// RePoint/ReLine reuse frozen GeometryPrimitives/Geometry.Recovered.cs.
public class NavGeometryResult {
 public double ReverseAngle,UnusedBearing,Length,HalfWidth,Angle;
 public List<List<RePoint>> Paths=new List<List<RePoint>>();
 public Dictionary<string,RePoint> Points=new Dictionary<string,RePoint>();
}
public static class NavAidProtectionGeometry {
 public static NavGeometryResult Build(RePoint s,RePoint e,double w,double alphaDegrees,bool left,bool right,bool center,bool expand){
  var r=new NavGeometryResult();double theta=Math.Atan2(s.Y-e.Y,s.X-e.X),L=RePoint.Distance(s,e),a=alphaDegrees*Math.PI/180;
  r.ReverseAngle=theta;r.Length=L;r.HalfWidth=w;r.Angle=a;
  double bearing=1.5*Math.PI-theta;bearing=bearing>=0?bearing:2*Math.PI+bearing;r.UnusedBearing=bearing>2*Math.PI?bearing-2*Math.PI:bearing;
  if(center)r.Paths.Add(new List<RePoint>{s,e});
  // Original creation order: right, then left. Reverse theta+PI/2 is forward-right.
  if(right)Side(r,s,e,w,a,theta,L,1,expand,"Right");
  if(left)Side(r,s,e,w,a,theta,L,-1,expand,"Left");
  return r;
 }
 static void Side(NavGeometryResult r,RePoint s,RePoint e,double w,double a,double theta,double L,int sign,bool expand,string side){
  double normal=theta+sign*Math.PI/2,far=L*Math.Tan(a)+w;
  var outerStart=NavMath.Add(s,NavMath.Polar(w,normal));
  var innerStart=NavMath.Add(s,NavMath.Polar(w/2,normal));
  var outerEnd=NavMath.Add(e,NavMath.Polar(far,normal));
  var innerEnd=NavMath.Add(e,NavMath.Polar(far/2,normal));
  if(expand){
   var inner=new ReLine(innerStart,innerEnd);var outer=new ReLine(outerStart,outerEnd);var cut=new ReLine();
   cut.Through(e,theta+Math.PI+sign*15*Math.PI/180);
   innerEnd=inner.Intersection(cut);outerEnd=outer.Intersection(cut);
   r.Paths.Add(new List<RePoint>{e,outerEnd});
  }
  r.Paths.Add(new List<RePoint>{s,outerStart,outerEnd});
  r.Paths.Add(new List<RePoint>{innerStart,innerEnd});
  r.Points[side+"OuterStart"]=outerStart;r.Points[side+"InnerStart"]=innerStart;r.Points[side+"OuterEnd"]=outerEnd;r.Points[side+"InnerEnd"]=innerEnd;
 }
}
}
