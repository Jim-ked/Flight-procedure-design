using System;
using System.Collections.Generic;
using Recovered.A6;
namespace Recovered.B5 {
public sealed class PbnCadRecord {
 public string Entity,Description="",XDataApp=null,Layer="no explicit assignment",Color="no explicit assignment",Linetype="no explicit assignment";
 public int Order;public bool Closed=false;public double[] Bulges;public List<TemplatePoint> Points;
}
public static class PbnDepartureCad {
 // P503/P50B -> P821 rotate -> P827 ZeroZ -> P823 translate -> P087.
 // P087 creates Group first in memory, writes each Polyline/P089, then persists
 // the Group. Record order is the database append order. No Autodesk side effects.
 public static List<PbnCadRecord> Record(List<List<TemplatePoint>> local,RunwayFrame frame){
  var p=PointLists._008B_008A_0094(local,new TemplatePoint(0,0),frame._008A_009D_008A);
  p=PointLists._008B_008A_0096(PointLists._008B_008A_009A(p),new TemplatePoint(frame.X,frame.Y));
  var r=new List<PbnCadRecord>();int n=0;
  foreach(var list in p)r.Add(new PbnCadRecord{Entity="Polyline",Order=n++,Points=list,Bulges=new double[list.Count]});
  r.Add(new PbnCadRecord{Entity="Group",Order=n,Points=null});return r;
 }
}
}
