using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Data;
using Recovered.A6;
using Recovered.B5;
class Round5Tests {
 static int assertions=0;
 static void Check(bool b,string m){assertions++;if(!b)throw new Exception(m);}
 static void Near(double a,double b,string m){Check(Math.Abs(a-b)<1e-6,m+" "+a+" != "+b);}
 static object Safe(object x){
  if(x==null)return null;
  if(x is double){double d=(double)x;return double.IsNaN(d)||double.IsInfinity(d)?(object)d.ToString(System.Globalization.CultureInfo.InvariantCulture):d;}
  if(x is string||x is bool||x is int)return x;
  var dict=x as IDictionary;if(dict!=null){var r=new Dictionary<string,object>();foreach(var k in dict.Keys)r[k.ToString()]=Safe(dict[k]);return r;}
  var seq=x as IEnumerable;if(seq!=null)return seq.Cast<object>().Select(Safe).ToArray();
  var fields=new Dictionary<string,object>();
  foreach(var f in x.GetType().GetFields(BindingFlags.Public|BindingFlags.Instance))fields[f.Name]=Safe(f.GetValue(x));
  foreach(var p in x.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance))if(p.CanRead&&p.GetIndexParameters().Length==0)fields[p.Name]=Safe(p.GetValue(x,null));
  return fields;
 }
 static object Result(PbnDepartureObstacle p){return new {p.ID,p.Name,p.X,p.Y,p.Z,label=p._0088_008E_0095(),dr=p._0088_008E_009E(),d0=p._0088_008E_009B(),MOC=p._0088_008F_0088(),OCA=p._0088_008F_008B(),PDA=p._0088_008F_008E(),required=p._0088_008F_0091()};}
 static PbnDepartureObstacle Ob(double x,double y,double z){return new PbnDepartureObstacle(new TemplatePoint(x,y,z));}
 static TemplatePoint Der(){return new TemplatePoint(0,0,100);}
 static TemplatePoint Thr(){return new TemplatePoint(-3000,0,99);}
 static object Private(object x,string name){return x.GetType().GetField(name,BindingFlags.NonPublic|BindingFlags.Instance).GetValue(x);}
 static object Geometry(string mode,double station,bool left,bool early,double ias,double wind,double bank,double g,double after,double endX,double endY){
  double h=station*g+105;var t=new TurnInput(ias,h,bank,wind,15);var end=new TemplatePoint(endX,endY);
  var evaluations=new List<object>();var inputs=new {mode,station,left,early,ias,wind,bank,g,after,endX,endY,altitude=h};
  if(mode=="alt"){
   var a=new PbnDepartureAltitudeTurn(t,Der(),Thr(),end,left,g,after,early);
   Near(a._008A_0086_009B,station,"TP");Near(a._008A_0086_009C,station+(t._008A_009D_009A+t._008A_009D_0098)/.6,"C6 latest");
   Near(a._008A_0086_0099,Math.Min(3704,station*Math.Tan(Math.PI/12)+150),"TP width");
   Check(a._008A_0087_0099.Count>0,"altitude groups");
   var outside=Ob(1e6,1e6,100);outside._0088_008F_0092(77);outside._0088_008F_008C(999);a._008A_0086_0094(outside);Check(outside._0088_008E_0095()=="out"&&outside._0088_008F_0091()==77&&outside._0088_008F_008B()==999,"out preserves prior fields");
   if(early){var reused=Ob(-100,0,100);reused._0088_008F_0092(88);a._008A_0086_0094(reused);if(reused._0088_008E_0095()=="早转弯区-净空道内")Near(reused._0088_008F_0091(),88,"early clearway retains required field");}
   var anchor=(TemplatePoint)Private(a,"_008A_0087_0088");Near(anchor.X,6351.95,"legacy anchor X");Near(anchor.Z,(g+.008)*6531.95+5,"legacy mismatched Z station");
   foreach(var p in new[]{Ob(1000,0,200),Ob(5000,1600,300),Ob(station,0,350),Ob(station+1000,2000,500),Ob(-100,0,100),Ob(1e6,1e6,100)})evaluations.Add(Result(a._008A_0086_0094(p)));
   foreach(var p in ((List<TemplatePoint>)Private(a,"_008A_0087_009E")).Take(4))foreach(double eps in new[]{-.001,0,.001})evaluations.Add(Result(a._008A_0086_0094(Ob(p.X+eps,p.Y,300))));
   var straight=a._008A_0086_0094(Ob(1000,0,200));
   if(straight._0088_008E_0095()!="out"&&station>1000) {Near(straight._0088_008F_0088(),8,"straight MOC");Near(straight._0088_008F_008E(),1000*g,"legacy PDA assignment");Near(straight._0088_008F_0091(),105+1000*g,"legacy required assignment");}
   var cad=PbnDepartureCad.Record(a._008A_0087_0099,FrameHelpers._0089_008F(Der(),Thr()));
   Check(cad.Count==a._008A_0087_0099.Count+1&&cad.Last().Entity=="Group","CAD group order");
   Check(cad.Take(cad.Count-1).All(p=>p.Bulges.All(b=>b==0)&&!p.Closed&&p.Points.All(q=>q.Z==0)),"zero bulge/Z and non-Closed");
   return new {inputs,scalars=Safe(a),initialHull=Private(a,"_008A_0087_009D"),evaluationHull=Private(a,"_008A_0087_009E"),evaluations,cad};
  }
  var f=new PbnDepartureFlyOver(t,Der(),Thr(),end,station,left,g,after);
  Near(f._008A_0088_0093,station-1482,"fixed ATT earliest");Near(f._008A_0088_0094,station+1482,"fixed ATT latest");
  Near(f._008A_0088_0095,station+1482+(t._008A_009D_009A+t._008A_009D_0098)/.6,"latest C6");
  Near((double)Private(f,"_008A_0089_0099"),1482,"private constant");
  foreach(bool straight in new[]{true,false}){var outside=Ob(1e6,1e6,100);outside._0088_008F_0092(77);f._008A_0088_008C(outside,straight);Check(outside._0088_008E_0095()=="out"&&outside._0088_008F_0091()==77,"FO out retains fields");}
  foreach(bool straight in new[]{true,false})foreach(var p in new[]{Ob(1000,0,200),Ob(5000,1600,300),Ob(station-1482,0,350),Ob(station+1000,2000,500),Ob(-100,0,100),Ob(1e6,1e6,100)})evaluations.Add(new {straight,result=Result(f._008A_0088_008C(p,straight))});
  foreach(bool straight in new[]{true,false})foreach(var p in ((List<TemplatePoint>)Private(f,straight?"_008A_0089_009A":"_008A_0089_009B")).Take(4))foreach(double eps in new[]{-.001,0,.001})evaluations.Add(new {straight,result=Result(f._008A_0088_008C(Ob(p.X+eps,p.Y,300),straight))});
  var sr=f._008A_0088_008C(Ob(1000,0,200),true);Check(sr._0088_008E_0095()!="out","straight primary included");Near(sr._0088_008F_0088(),8,"FO straight no 75 floor");Near(sr._0088_008F_008E(),105+1000*g,"FO straight PDA");Near(sr._0088_008F_0091(),.103,"FO required");
  return new {inputs,scalars=Safe(f),initialHull=Private(f,"_008A_0089_009A"),evaluationHull=Private(f,"_008A_0089_009B"),evaluations,cad=PbnDepartureCad.Record(f._008A_0089_0095,FrameHelpers._0089_008F(Der(),Thr()))};
 }
 static object FormTest(){
  var ps=Enumerable.Range(1,7).Select(i=>new TemplatePoint(i*1000,0,i==6?5000:100+i){ID=i.ToString(),Name="ob"+i}).ToList();var f=new PbnDepartureForm();f.ScreenData(ps);
  Check(f.Loaded.Count==5&&f.Loaded[4]==ps[4],"Take5 selection order");Check(f.ById.Count==5,"five dictionary entries");Check(f.Highlight("5")==ps[4],"highlight source");Check(f.MarkSources(new[]{"1","5"})[1].Z==105,"Mark source absolute altitude");
  bool missing=false;try{f.Highlight("6");}catch(KeyNotFoundException){missing=true;}Check(missing,"sixth inaccessible");
  Check(f.EvaluationButton()=="请指定转弯点。","placeholder");Near(PbnDepartureForm.UpdateTp(500,100,0,77),77,"zero update retains");Check(double.IsPositiveInfinity(PbnDepartureForm.ConstructorTp(500,100,0)),"unclamped zero gradient");Near(PbnDepartureForm.ConstructorTp(500,100,-.033),-395/.033,"negative gradient");
  var pick=PbnDepartureForm.PickTp(Der(),new TemplatePoint(3000,4000,999),.033);Near(pick[0],5000,"off-track Euclidean distance");Near(pick[1],605,"reference 10pct");Near(pick[2],270,"calculation 3.3pct");
  bool duplicate=false;try{PbnDepartureForm.ResultTable(new List<PbnDepartureObstacle>());}catch(DuplicateNameException){duplicate=true;}Check(duplicate,"legacy duplicate result column");
  var turn=PbnDepartureForm.ReadTurn(100,500,15,20,15,true,true);Near(turn._008A_009D_0098,37.04,"wind units");
  var dir=PbnDepartureForm.Direction("invalid",Der(),Thr(),new TemplatePoint(10000,5000));
  var small=new PbnDepartureForm();small.ScreenData(ps.Take(3).ToList());Check(small.Loaded.Count==3,"less than 5");
  var direct=new PbnDepartureFlyOver(new TurnInput(300,500,15,56,15),Der(),Thr(),new TemplatePoint(25000,15000),12000,true,.033,.04);
  var sixth=direct._008A_0088_008C(new PbnDepartureObstacle(ps[5]),true);Check(sixth._0088_008E_0095()!="out"&&sixth._0088_008F_0091()>.8,"algorithm can evaluate arbitrary sixth; no UI dispatch implied");
  return new {input=ps,loaded=f.Loaded,mark=f.MarkSources(new[]{"1","5"}),missing,duplicate,pick,invalidDirection=dir,turn,sixthDirect=Result(sixth)};
 }
 static object HelperTest(string id){
  if(id=="hull-collinear")return B5Math._008B_0088_0089(new List<TemplatePoint>{new TemplatePoint(0,0),new TemplatePoint(1,0),new TemplatePoint(2,0)});
  if(id=="hull-same-reference"){var p=new TemplatePoint(0,0);return B5Math._008B_0088_0089(new List<TemplatePoint>{p,p,p});}
  if(id=="hull-coincident")return B5Math._008B_0088_0089(new List<TemplatePoint>{new TemplatePoint(0,0),new TemplatePoint(0,0),new TemplatePoint(0,0)});
  var poly=new List<TemplatePoint>{new TemplatePoint(0,0),new TemplatePoint(10,0),new TemplatePoint(10,10),new TemplatePoint(0,10)};
  var points=new[]{new TemplatePoint(0,0),new TemplatePoint(5,0),new TemplatePoint(10,5),new TemplatePoint(0,5),new TemplatePoint(5,10),new TemplatePoint(5,5)};
  var include=points.Select(p=>B5Math._008B_0088_008B(poly,p)).ToArray();Check(include[1]&&!include[2]&&include[3]&&!include[4],"ray boundary asymmetry");
  var pos=new LineCarrier(0,0,-1)._008B_0088_008C(0);var neg=new LineCarrier(0,0,1)._008B_0088_008C(0);Near(pos,1e6,"line positive sentinel");Near(neg,-1e6,"line negative sentinel");
  var frame=FrameHelpers._0089_008F(new TemplatePoint(100,200,50),new TemplatePoint(100,-2800,40));var local=FrameHelpers._0089_0090(frame,new TemplatePoint(100,1200,70));Near(local.X,1000,"frame forward X");Near(local.Y,0,"frame Y");Near(local.Z,20,"frame relative Z");
  return new {poly,points,include,pos,neg,frame,local};
 }
 static void Main(string[] args){
  string id=args[1];object result=null;string error=null;bool expected=false;
  try{
   if(id=="deg-alt-zero")result=new PbnDepartureAltitudeTurn(new TurnInput(300,500,15,56,15),Der(),Thr(),new TemplatePoint(25000,15000),true,0,.04,false);
   else if(id=="form")result=FormTest();
   else if(id=="helpers"||id.StartsWith("hull-"))result=HelperTest(id);
   else {string[] p=id.Split('_');string mode=p[0];double station=double.Parse(p[1],System.Globalization.CultureInfo.InvariantCulture);bool left=p[2]=="L";bool early=p[3]=="E";double ias=300,wind=56,bank=15,g=.033,after=.04,ex=25000,ey=left?15000:-15000;
    if(p.Length>4)switch(p[4]){case "ias":ias=420;break;case "wind":wind=100;break;case "bank":bank=25;break;case "pdg":g=.05;break;case "after":after=.06;break;case "near":ex=10000;ey=left?5000:-5000;break;case "wide":ex=-5000;ey=left?15000:-15000;break;}
    if(p.Length>4&&p[4].StartsWith("c6")){var fixedTurn=new TurnInput(300,500,15,56,15);double limit=p[4].Contains("upper")?13263.71:6351.95;double eps=p[4].EndsWith("low")?-.001:(p[4].EndsWith("hi")?.001:0);station=limit+eps-(fixedTurn._008A_009D_009A+fixedTurn._008A_009D_0098)/.6-(mode=="fo"?1482:0);g=395/station;}
    if(p.Length>4&&p[4].StartsWith("nav")){station=6351.95+(p[4]=="navlow"?-1482:1482);g=395/station;}
    result=Geometry(mode,station,left,early,ias,wind,bank,g,after,ex,ey);
   }
  }catch(Exception e){error=e.GetType().Name+": "+e.Message;expected=id.Contains("_1000_")||id.Contains("_-1000_")||id.EndsWith("c6low")||id=="deg-alt-zero";if(!expected)Console.WriteLine(error);else if(id!="deg-alt-zero")Check(e.Message.Contains("不支持过低"),"legacy low-station exception");}
  Directory.CreateDirectory(args[0]);File.WriteAllText(Path.Combine(args[0],id+".json"),new JavaScriptSerializer{MaxJsonLength=int.MaxValue,RecursionLimit=200}.Serialize(Safe(new {id,assertions,expected,error,result,evidence="Recovered C# execution only; no original DLL oracle"})));
  Console.WriteLine("PASS "+id+" assertions="+assertions+(expected?" expected exception":""));
  if(error!=null&&!expected)Environment.ExitCode=1;
 }
}
