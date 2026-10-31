using System;
using System.Collections.Generic;
namespace Recovered.A6 {
// Independent recording adapter for the recovered FormTemplate writer calls.
// Records are fixtures, not Autodesk entities; host drawing/Group IDs are unverified.
public sealed class CadRecord {
 public string Entity="Polyline",Group,Layer="no explicit layer assignment",XDataApp,Description;
 public bool Closed;public double[] Bulges;public List<TemplatePoint> Points;
 public string Contents;public double TextHeight,Rotation;public int Attachment;
}
public static class TemplateCad {
 // P359/P35A: rotate, ZeroZ, translate, then frozen shared Polyline/Group writer.
 // Original metadata and direct call offsets: evidence/methods.csv + calls.csv.
 static List<TemplatePoint> Place(List<TemplatePoint> points,bool mirror,double heading,TemplatePoint origin){
  if(points==null)return null;
  if(mirror)points=PointLists._008B_008A_009C(points);
  return PointLists._008B_008A_0098(PointLists._008B_008A_0099(PointLists._008B_008A_0095(points,new TemplatePoint(0,0),heading)),origin);
 }
 static void Add(List<CadRecord> r,List<TemplatePoint> pts,string desc,string group,bool mirror,double heading,TemplatePoint origin,double[] bulges=null,bool closed=false){
  if(pts==null||pts.Count==0)return;
  var b=bulges??new double[pts.Count];if(mirror)for(int i=0;i<b.Length;i++)b[i]=-b[i];
  r.Add(new CadRecord{Points=Place(pts,mirror,heading,origin),Description=desc,XDataApp=String.IsNullOrEmpty(desc)?null:"WsObject",Group=group,Bulges=b,Closed=closed});
 }
 static void Group(List<CadRecord> r,List<List<TemplatePoint>> pts,string desc,string id,bool mirror,double heading,TemplatePoint origin){
  if(pts==null)return;foreach(var p in pts)Add(r,p,desc,id,mirror,heading,origin);
 }
 // P364 -> _0089_0098; nominal writes first 4 of 5 points, Closed=true.
 // Optional label MText is emitted by HoldingLabel, separately from curve records.
 public static List<CadRecord> Holding(Holding h,bool right,bool aux,double heading,TemplatePoint origin){
  h._0088_0087_009A(true);var r=new List<CadRecord>();
  Add(r,h._0088_008A_0091.GetRange(0,4),h.ToString(),null,right,heading,origin,new double[]{1,0,1,0},true);
  h._0088_0087_009B(aux);Group(r,h._0088_008A_0095,h.ToString(),"holding",right,heading,origin);return r;
 }
 // P35F -> _0088_0091; width is constructor P5, actual CAD control 4630.
 public static List<CadRecord> BaseTurn(BaseTurn b,bool right,bool aux,double heading,TemplatePoint origin){
  b._0091_0086(true);var r=new List<CadRecord>();
  Add(r,b._0092_0091,b.ToString(),null,right,heading,origin,new double[]{0,Math.Tan((Math.PI-b._0091_008E)/4),0});
  b._0091_0087(aux,aux);Add(r,b._0092_008E,b.ToString(),null,right,heading,origin);Add(r,b._0092_008F,b.ToString(),null,right,heading,origin);
  if(aux)Group(r,b._0092_0090,b.ToString(),"base-aux",right,heading,origin);return r;
 }
 // P35D; single-template boundary builder is independent of Envelope P367.
 internal static List<CadRecord> Procedure45180(Procedure45180 p,bool right,bool aux,double heading,TemplatePoint origin){
  p._0088_0096_009C(true);var r=new List<CadRecord>();
  Add(r,p._0088_0098_0086,p.ToString(),null,right,heading,origin,new double[]{0,-Math.Tan(Math.PI/16),0,1,0});
  p._0088_0096_009D(aux);Group(r,p._0088_0098_0088,p.ToString(),"45-protection",right,heading,origin);return r;
 }
 // P35B.
 internal static List<CadRecord> Procedure80260(Procedure80260 p,bool right,bool aux,double heading,TemplatePoint origin){
  p._0088_0098_0096(true);var r=new List<CadRecord>();
  Add(r,p._0088_0099_008A,p.ToString(),null,right,heading,origin,new double[]{0,-Math.Tan(Math.PI/9),0,Math.Tan(13*Math.PI/36),0});
  p._0088_0098_0097(aux);Group(r,p._0088_0099_008C,p.ToString(),"80-protection",right,heading,origin);return r;
 }
 // P378 facility tolerance; alt/elev in metres. No template sampling here.
 public static TemplatePoint[] HoldingTolerance(TurnInput t,string facility,double antenna){
  double d=Math.PI/180,z=(t._008A_009D_0096-antenna)*Math.Tan((facility=="VOR"?50:40)*d);
  return new[]{new TemplatePoint(z*Math.Cos((facility=="VOR"?5:15)*d),z*Math.Sin((facility=="VOR"?5:15)*d),t._008A_009D_0096),new TemplatePoint(z*Math.Cos((facility=="VOR"?165:155)*d),z*Math.Sin((facility=="VOR"?165:155)*d),t._008A_009D_0096)};
 }
 // P379: per-segment end-point displacement, no Autodesk Offset; original quirks retained.
 public static List<TemplatePoint> OmniOuter(List<TemplatePoint> p,double width,double sign=1){
  var l=new List<TemplatePoint>();
  for(int i=1;i<p.Count;i++){double a=Math.Atan2(p[i].Y-p[i-1].Y,p[i].X-p[i-1].X);l.Add(TemplatePoint._008B_0089_0088(p[i],TemplatePoint._008B_0089_0087(width,a-sign*Math.PI/2)));}
  if(p[0].Y!=p[p.Count-1].Y||p[0].X!=p[p.Count-1].X){double a=Math.Atan2(p[0].Y-p[p.Count-1].Y,p[0].X-p[p.Count-1].X);l.Add(TemplatePoint._008B_0089_0088(p[0],TemplatePoint._008B_0089_0087(width,a-sign*Math.PI/2)));}
  l.Add(l[0]);return l;
 }
 // P364/P365: label uses nominal points BEFORE CAD mirroring; preserve swapped X/Y.
 public static CadRecord HoldingLabel(Holding h,bool right,double heading,TemplatePoint origin,TemplatePoint inbound){
  var p=Place(h._0088_008A_0091,false,heading,origin);
  var c=new TemplatePoint((p[0].X+p[1].X+p[2].X+p[3].X)/4,(p[0].Y+p[1].Y+p[2].Y+p[3].Y)/4);
  if(right){double dx=inbound.X-origin.X,dy=inbound.Y-origin.Y,k=((c.X-origin.X)*dx+(c.Y-origin.Y)*dy)/(dx*dx+dy*dy);c=new TemplatePoint(2*(origin.Y+k*dy)-c.Y,2*(origin.X+k*dx)-c.X);}
  return new CadRecord{Entity="MText",Points=new List<TemplatePoint>{c},Contents="IAS "+h._0088_0088_008E._008A_009D_0095+"km/h\n"+h._0088_0088_008E._008A_009D_0096,TextHeight=1000,Rotation=heading<Math.PI/2&&heading>-Math.PI/2?heading:Math.PI+heading,Attachment=5};
 }
 // P377: no nominal curve or label; two Group invocations then one outer polyline.
 public static List<CadRecord> Omni(Holding h,bool right,double heading,TemplatePoint origin){
  var r=new List<CadRecord>();Group(r,h._0088_008A_0096,h.ToString(),"omni",right,heading,origin);Group(r,h._0088_008A_0095,h.ToString(),"holding",right,heading,origin);
  var hull=h._0088_008A_0096[h._0088_008A_0096.Count-1];if(right)hull=PointLists._008B_008A_009C(hull);
  Add(r,OmniOuter(hull,9260,right?1:-1),"",null,false,heading,origin);return r;
 }
 // P375/P376: descriptions are turn.ToString(), not XE/YE.ToString().
 public static List<CadRecord> XE(HoldingXE x,bool right,double heading,TemplatePoint origin){var r=new List<CadRecord>();Group(r,x._0088_008C_0087,x._0088_008B_0089.ToString(),"xe-spiral",right,heading,origin);Group(r,x._0088_008B_009E,x._0088_008B_0089.ToString(),"xe-lines",right,heading,origin);Group(r,x._0088_008C_0086,x._0088_008B_0089.ToString(),"xe-nominal",right,heading,origin);return r;}
 public static List<CadRecord> YE(HoldingYE y,bool right,double heading,TemplatePoint origin){var r=new List<CadRecord>();Group(r,y._0088_008D_0091,y._0088_008C_0090.ToString(),"ye-spiral",!right,heading,origin);Group(r,y._0088_008D_008F,y._0088_008C_0090.ToString(),"ye-lines",!right,heading,origin);Group(r,y._0088_008D_0090,y._0088_008C_0090.ToString(),"ye-nominal",!right,heading,origin);return r;}
 // P367 appends even a zero-vertex result after OK selection; cancel returns no entity.
 public static CadRecord EnvelopeOutput(List<EnvelopePoint> p){if(p==null)return null;var pts=new List<TemplatePoint>();foreach(var v in p)pts.Add(new TemplatePoint(v.X,v.Y));return new CadRecord{Points=pts,Bulges=new double[pts.Count]};}
}
}
