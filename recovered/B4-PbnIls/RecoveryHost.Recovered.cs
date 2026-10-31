using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
namespace Recovered.B4 {
// Numeric enum values directly consumed by original code; metadata has no named constants.
public enum OasMode { }
// Test adapter only. Does not simulate WinForms events or config restoration ordering.
public class RecoveryCell { public string Text=""; public int SelectedIndex=-1; public bool Checked; public bool FocusRequested; public string BackColor=""; }
public static class RecoveryMessages {
 public static List<string> Messages=new List<string>();
 public static void Show(string s){Messages.Add(s);}
 public static void Discard(object o){}
}
public static class RecoveryParse {
 // E2 P7D5/P7D6 numeric error behavior. Message/focus/color recorded; no host UI execution.
 public static double Text(string s,string error){try{return Convert.ToDouble(s);}catch{RecoveryMessages.Show(s+" "+error);return 0;}}
 public static double Cell(RecoveryCell c,string error){double value;if(double.TryParse(c.Text,out value))return value;c.FocusRequested=true;c.BackColor="LightCoral";RecoveryMessages.Show(c.Text+" "+error);return 0;}
}
public static class OasRows {
 // E2 extraction of P571's row-to-coefficient assignments. IO replaced with raw SQLite row inputs.
 // The target SQLite library and target DLL are never loaded.
 public static string Key(string gp,int mode,string cg){return (gp+mode+cg).Replace(".","");}
 public static string LocKey(string key,string loc){return key+(int)Math.Round(Convert.ToDouble(loc),0);}
 public static OasModel Decode(string key,int mode,string a,string rawB){
  OasModel m=new OasModel((OasMode)mode);
  string b=PbnIlsForm._0089_0096_0097(rawB);
  m._0088_0091_009A=new PlaneCarrier(Convert.ToInt32(key.Substring(3,2))*-.001,0,Convert.ToInt32(PbnIlsForm._0089_0096_0097(a.Substring(0,4)))*-.01);
  m._0088_0091_0096=new PlaneCarrier(Convert.ToInt32(PbnIlsForm._0089_0096_0097(a.Substring(4,5)))*1e-6,0,Convert.ToInt32(PbnIlsForm._0089_0096_0097(a.Substring(9,3)))*-.01);
  m._0088_0091_0097=new PlaneCarrier(Convert.ToInt32(PbnIlsForm._0089_0096_0097(a.Substring(12,5)))*1e-6,0,Convert.ToInt32(PbnIlsForm._0089_0096_0097(a.Substring(17,4)))*-.01);
  m._0088_0091_0098=new PlaneCarrier(Convert.ToInt32(b.Substring(0,5))*1e-6,Convert.ToInt32(b.Substring(5,6))*1e-6,Convert.ToInt32(b.Substring(11,4))*-.01);
  m._0088_0091_0099=new PlaneCarrier(Convert.ToInt32(b.Substring(15,5))*1e-6,Convert.ToInt32(b.Substring(20,6))*1e-6,Convert.ToInt32(b.Substring(26,4))*-.01);
  return m;
 }
}
public static class PbnIlsCad {
 // E2 P55C list transform only. No AutoCAD writer execution.
 public static List<List<TemplatePoint>> Transform(PbnIlsTurn m,TemplatePoint thr,TemplatePoint end){
  RunwayFrame f=FrameHelpers._0089_008F(thr,end);
  return PointLists._008B_008A_0096(PointLists._008B_008A_009A(PointLists._008B_008A_0094(m._008A_008B_0095,new TemplatePoint(0,0),f._008A_009D_008A)),new TemplatePoint(f.X,f.Y));
 }
 // E2 P55B: actual form discards helper's Z and retains source absolute Z.
 public static PbnIlsObstacle Local(TemplatePoint p,TemplatePoint thr,TemplatePoint end){
  RunwayFrame f=FrameHelpers._0089_008F(new TemplatePoint(thr.X,thr.Y),new TemplatePoint(end.X,end.Y));
  TemplatePoint local=FrameHelpers._0089_0090(f,p);
  return new PbnIlsObstacle(p){X=local.X,Y=local.Y};
 }
 // E2 P555 after SelectAll; represents truncation only, not a replacement parser.
 public static List<TemplatePoint> TakeScreen(List<TemplatePoint> all){return all.Count>5?all.Take(5).ToList():all;}
}
}
