using System;
using System.Linq;
using System.Collections.Generic;
using Recovered.A6;
using Recovered.B5;
namespace Recovered.B3 {
// P47C→P821/P823→P087/P089/P12D/P134: records only, no AutoCAD simulation.
public sealed class RnpPolylineRecord {
 public List<TemplatePoint> XY;public bool Closed=false;public double Bulge=0;public string XDataApplication="WsObject";public string XDataText;
}
public static class RnpApchCad {
 public static List<RnpPolylineRecord> Record(RnpApchLnav area,RunwayFrame frame,string serializedControls){
  var rotated=PointLists._008B_008A_0094(area._0089_009C_0096,new TemplatePoint(0,0),frame._008A_009D_008A);
  var world=PointLists._008B_008A_0096(rotated,new TemplatePoint(frame.X,frame.Y,frame.Z));
  return world.Select(l=>new RnpPolylineRecord{XY=l.Select(p=>new TemplatePoint(p.X,p.Y,0)).ToList(),XDataText=serializedControls}).ToList();
 }
}
// B3 persistence adapter: P47E/P47F to P0FB/P0FC/P0FD.
// Input already contains supported controls flattened by original collection traversal.
public static class RnpApchStateText {
 public static string Save(IEnumerable<KeyValuePair<string,string>> controls){string s="FormApvEvl\n";foreach(var item in controls)s+=item.Key+":"+item.Value+"\n";return s;}
 public static void Load(string text,IDictionary<string,string> existing){
  string[] lines=text.Split(new[]{"\r\n","\r","\n"},StringSplitOptions.RemoveEmptyEntries);
  if(lines[0]!="FormApvEvl"){RecoveryMessages.Show("数据格式不匹配，请重新选择数据文件。");return;}
  for(int i=1;i<lines.Length;i++){string[] pair=lines[i].Split(':');string key=pair[0].Trim(),value=pair[1].Trim();if(existing.ContainsKey(key))existing[key]=value;}
 }
}
}
