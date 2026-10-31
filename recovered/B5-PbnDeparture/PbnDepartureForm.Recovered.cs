using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Recovered.A6;
namespace Recovered.B5 {
// Record adapter for FormPbnDepEvl. Input points are already parsed by the frozen
// ObstacleData P12F contract. No duplicate CAD SelectAll/parser/Mark implementation.
// No new evaluation dispatch: original P501/P50C/P50D only show a message.
public sealed class PbnDepartureForm {
 public List<TemplatePoint> Loaded;
 public Dictionary<string,TemplatePoint> ById;
 // P4F6 original P4F7/RVA804F8, P4F7 original P4F8/RVA80704.
 public void ScreenData(List<TemplatePoint> selectAllOrder) {
  Loaded=selectAllOrder.Count>5?selectAllOrder.Take(5).ToList():selectAllOrder;ById=new Dictionary<string,TemplatePoint>();
  int id=1;foreach(var p in Loaded)ById.Add((id++).ToString(),p);
 }
 // P511 original P512/RVA82F8C: return source positions to frozen Mark P09C;
 // its Attribute setter P09E receives "Altitude", source.Z.ToString().
 public List<TemplatePoint> MarkSources(IEnumerable<string> selectedIds){
  return selectedIds.Select(id=>ById[id]).ToList();
 }
 // P4F9 original P4FA/RVA80CD8: ID lookup; unhighlight loaded then highlight ID.
 public TemplatePoint Highlight(string id){return ById[id];}
 // P501 original P502/RVA81D2C; P50C/P50D same processed IL body.
 public string EvaluationButton(){return "请指定转弯点。";}
 // P505/P506: zero gradient leaves prior displayed value unchanged.
 public static double UpdateTp(double altitude,double derZ,double gradient,double previous){
  return gradient!=0?Math.Round((altitude-derZ-5)/gradient,1):previous;
 }
 // Raw arithmetic inside P5C8; intentionally no zero/negative clamp.
 public static double ConstructorTp(double altitude,double derZ,double gradient){return (altitude-derZ-5)/gradient;}
 // P507 pick: planar distance, not projection on the runway extension.
 public static double[] PickTp(TemplatePoint der,TemplatePoint pick,double gradient){
  double d=Math.Sqrt(Math.Pow(pick.X-der.X,2)+Math.Pow(pick.Y-der.Y,2));
  return new[]{Math.Round(d,2),Math.Round(d*.1+der.Z+5),Math.Round(d*gradient+der.Z+5)};
 }
 // P500/P50A, exact P793 constructor order.
 public static TurnInput ReadTurn(double ias,double altitude,double bank,double wind,double temp,bool iasKt,bool windKt){
  return new TurnInput(ias*(iasKt?1.852:1),altitude,bank,wind*(windKt?1.852:1),temp);
 }
 // P502 original P503/RVA81D50. Invalid/empty text falls back to SideClassifier.
 public static bool Direction(string text,TemplatePoint der,TemplatePoint thr,TemplatePoint end){
  if(text=="左转")return true;if(text=="右转")return false;
  var f=FrameHelpers._0089_008F(der,thr);
  int side=new SideClassifier(der.X,der.Y,-1,f._008A_009D_0089)._008A_009E_0088(end.X,end.Y);
  return side==1||side==2;
 }
 // P4F8 original P4F9/RVA809B8: 11 columns with duplicate 高度(m), then 12 values.
 // This real System.Data call reproduces the legacy schema exception; not repaired.
 public static DataTable ResultTable(List<PbnDepartureObstacle> result){
  var t=new DataTable();
  t.Columns.Add("ID",typeof(string));t.Columns.Add("名称",typeof(string));
  t.Columns.Add("X坐标(m)",typeof(double));t.Columns.Add("Y坐标(m)",typeof(double));
  t.Columns.Add("高度(m)",typeof(double));t.Columns.Add("dr(m)",typeof(string));
  t.Columns.Add("d0(m)",typeof(string));t.Columns.Add("MOC(m)",typeof(double));
  t.Columns.Add("OCA(m)",typeof(double));t.Columns.Add("高度(m)",typeof(double));
  t.Columns.Add("minPDG(%)",typeof(double));
  foreach(var p in result)t.Rows.Add(p.ID,p.Name,Math.Round(p.X,2),Math.Round(p.Y,2),Math.Round(p.Z,2),p._0088_008E_0095(),Math.Round(p._0088_008E_009E(),2),Math.Round(p._0088_008E_009B(),2),Math.Round(p._0088_008F_0088()),Math.Round(p._0088_008F_008B()),Math.Round(p._0088_008F_008E(),2),Math.Round(p._0088_008F_0091()*100,1));
  return t;
 }
}
}
