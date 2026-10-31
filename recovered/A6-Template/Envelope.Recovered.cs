using System;
using System.Collections.Generic;
namespace Recovered.A6 {
// Point3d value equality adapter; selection reads XYZ, writer emits XY only.
public struct EnvelopePoint {
 public double X,Y,Z;
 public EnvelopePoint(double x,double y,double z=0){X=x;Y=y;Z=z;}
 public static bool operator ==(EnvelopePoint a,EnvelopePoint b){return a.X==b.X&&a.Y==b.Y&&a.Z==b.Z;}
 public static bool operator !=(EnvelopePoint a,EnvelopePoint b){return !(a==b);}
 public override bool Equals(object o){return o is EnvelopePoint && this==(EnvelopePoint)o;}
 public override int GetHashCode(){return X.GetHashCode()^Y.GetHashCode()^Z.GetHashCode();}
}
public sealed class SelectedTemplateEntity {
 public string Type; public List<EnvelopePoint> Vertices=new List<EnvelopePoint>();
 public bool Closed; public double[] Bulges; // read by fixture only: legacy ignores both
}
public static class Envelope {
 // Original MethodDef 0x06000368; Original RVA 0x51F40; processed 0x06000367.
 // Evidence: FormTemplate.source.txt:32627; GetSelection has no SelectionFilter.
 // CAD selection adapter: null represents non-OK PromptStatus (no append).
 public static List<EnvelopePoint> Selection(List<SelectedTemplateEntity> selected) {
  if(selected==null)return null;
  var points=new List<EnvelopePoint>();
  foreach(var e in selected){
   if(e==null)continue;
   if(e.Type=="Polyline")points.AddRange(e.Vertices);
   else if(e.Type=="Line"){points.Add(e.Vertices[0]);points.Add(e.Vertices[1]);}
  }
  return Hull(points);
 }
 // Original MethodDef 0x06000369; Original RVA 0x523FC; processed 0x06000368.
 // Decompilation + IL: --/--.cs:32880–32938. Preserve missing collinear tie-break.
 public static List<EnvelopePoint> Hull(List<EnvelopePoint> points) {
  if(points.Count<3)return points;
  var list=new List<EnvelopePoint>();var start=points[0];
  foreach(var p in points)if(p.Y<start.Y||(p.Y==start.Y&&p.X<start.X))start=p;
  list.Add(start);var current=start;
  do {
   var candidate=points[0];
   foreach(var p in points)if(candidate==current||Orientation(current,candidate,p)==2)candidate=p;
   list.Add(candidate);current=candidate;
  }while(current!=start);
  return list;
 }
 // Original MethodDef 0x0600036A; Original RVA 0x52534; processed 0x06000369.
 // --/--.cs:32940–32953; exact zero test, no epsilon.
 public static int Orientation(EnvelopePoint a,EnvelopePoint b,EnvelopePoint c){
  double q=(b.Y-a.Y)*(c.X-b.X)-(b.X-a.X)*(c.Y-b.Y);
  return q==0?0:q>0?1:2;
 }
}
}
