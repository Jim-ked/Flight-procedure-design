using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using Recovered.A6;
public static class Round4Tests {
 static string dir;static int count;static TextWriter output;static JavaScriptSerializer json=new JavaScriptSerializer{MaxJsonLength=30000000,RecursionLimit=100};
 static void Check(bool ok,string what){count++;if(!ok)throw new Exception(what);}
 static void Near(double a,double b,string s){Check(!Double.IsNaN(a)&&!Double.IsNaN(b)&&Math.Abs(a-b)<=1E-7*Math.Max(1,Math.Max(Math.Abs(a),Math.Abs(b))),s+" "+a+" "+b);}
 static void Log(string s){output.WriteLine(s);output.Flush();}
 static object Data(object o){
  if(o==null)return null;
  if(o is double){double d=(double)o;return Double.IsNaN(d)?(object)"NaN":Double.IsInfinity(d)?(object)d.ToString(System.Globalization.CultureInfo.InvariantCulture):o;}
  if(o is string||o is bool||o is int)return o;
  if(o is TemplatePoint){var p=(TemplatePoint)o;return new object[]{Data(p.X),Data(p.Y),Data(p.Z)};}
  if(o is EnvelopePoint){var p=(EnvelopePoint)o;return new object[]{Data(p.X),Data(p.Y),Data(p.Z)};}
  if(o is IEnumerable){var l=new List<object>();foreach(var p in (IEnumerable)o)l.Add(Data(p));return l;}
  var m=new SortedDictionary<string,object>();
  foreach(var f in o.GetType().GetFields(BindingFlags.Public|BindingFlags.Instance)){
   if(f.FieldType==typeof(TurnInput)||f.FieldType==typeof(Spiral86)||f.FieldType==typeof(Spiral88))continue;
   m[f.Name]=Data(f.GetValue(o));
  }
  foreach(var p in o.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance))if(p.CanRead&&p.GetIndexParameters().Length==0)m[p.Name]=Data(p.GetValue(o,null));
  return m;
 }
 static void Save(string name,object o){File.WriteAllText(Path.Combine(dir,name+".json"),json.Serialize(Data(o)),new System.Text.UTF8Encoding(false));}
 static void Finite(IEnumerable<CadRecord> rec){foreach(var e in rec)foreach(var p in e.Points)Check(!Double.IsNaN(p.X)&&!Double.IsNaN(p.Y)&&!Double.IsInfinity(p.X)&&!Double.IsInfinity(p.Y),"finite CAD coordinate");}
 static void Mirror(List<CadRecord> left,List<CadRecord> right){
  Check(left.Count==right.Count,"mirror entity count");
  for(int i=0;i<left.Count;i++){
   Check(left[i].Points.Count==right[i].Points.Count,"mirror point count");
   for(int j=0;j<left[i].Points.Count;j++){Near(left[i].Points[j].X,right[i].Points[j].X,"mirror x");Near(left[i].Points[j].Y,-right[i].Points[j].Y,"mirror y");}
   for(int j=0;j<left[i].Bulges.Length;j++)Near(left[i].Bulges[j],-right[i].Bulges[j],"mirror arc sign");
  }
 }
 static void Metadata(List<CadRecord> rec){Check(rec.All(x=>x.XDataApp=="WsObject"),"WsObject metadata");}
 static TurnInput T(double wind,double ias=300){return new TurnInput(ias,600,25,wind,15);}
 static void Primitives(){
  var t=T(56);var old=new Recovered.Geometry.TurnParameterRecovered(300,600,15,25,56);
  Near(t._008A_009D_009A,old.TAS,"frozen P793 TAS");Near(t._008A_009D_009C,old.Rate,"frozen P793 rate");Near(t._008A_009D_009D,old.Radius,"frozen P793 radius");Near(t._008A_009D_009E,old.WindRadius,"frozen P793 windradius");
  var s=new Spiral86(t,new TemplatePoint(12,34),.4,70);var s0=new Recovered.Geometry.WindSpiralRecovered(new Recovered.Geometry.Point2(12,34),.4,70,old.WindRadius,old.Radius,old.Drift,true);
  foreach(double a in new[]{0,.3,1,3}){var p=s._008A_009E_0093(a);var q=s0.Point(a);Near(p.X,q.X,"frozen spiral86 x");Near(p.Y,q.Y,"frozen spiral86 y");}
  var z=T(0);var c=new Spiral88(z,new TemplatePoint(0,0),.2,0);foreach(double a in new[]{0,.2,2,5})Near(TemplatePoint._008B_0088_009E(new TemplatePoint(0,0),c._008B_0086_0095(a)),z._008A_009D_009D,"zero wind circle");
  Log("PASS shared primitive reuse: frozen P793 outputs/spiral86 samples, spiral88 zero-wind circle");
 }
 static void HoldingFixtures(){
  foreach(double w in new[]{0.0,56})foreach(double tm in new[]{1.0,1.5}){
   var t=T(w);var h=new Holding(t,tm);var l=TemplateCad.Holding(h,false,false,0,new TemplatePoint(0,0));var r=TemplateCad.Holding(new Holding(t,tm),true,false,0,new TemplatePoint(0,0));Mirror(l,r);Finite(l);Metadata(l);
   Near(h._0088_0088_0091,t._008A_009D_009A/3.6*tm*60,"holding L");Check(l[0].Points.Count==4&&l[0].Closed,"holding nominal CAD 4 closed");Near(TemplatePoint._008B_0088_009E(h._0088_008A_0091[0],h._0088_008A_0091[4]),0,"holding list closure");
   string tag="holding-w"+w+"-t"+tm;Save(tag,new {Input=new{IAS=300,Altitude=600,Bank=25,Wind=w,Temperature=15,Minutes=tm},Model=h,Left=l,Right=r,Evidence="recovered execution; original plugin not run"});
   var aux=TemplateCad.Holding(new Holding(t,tm),false,true,0,new TemplatePoint(0,0));Check(aux.Count>l.Count,"holding auxiliary branches");Save(tag+"-aux",aux);
   var repeated=TemplateCad.Holding(new Holding(t,tm),false,false,0,new TemplatePoint(0,0));Check(json.Serialize(Data(l))==json.Serialize(Data(repeated)),"holding repeatability");
   var xe=new HoldingXE(t,tm);var ye=new HoldingYE(t,tm);Save(tag+"-xe-ye",new{XE=xe,YE=ye});
   foreach(string facility in new[]{"VOR","NDB"}){
    var tol=TemplateCad.HoldingTolerance(t,facility,0);var omni=new Holding(t,tm);omni._0088_0087_009B(false);omni._0088_0087_009D(tol[0],tol[1],xe._0088_008B_008F.X,ye._0088_008C_0096.Y,false);
    Check(omni._0088_008A_0096.Count==1,"omni one hull");var hull=omni._0088_008A_0096.Last();Near(hull[0].X,hull.Last().X,"omni closes x");Near(hull[0].Y,hull.Last().Y,"omni closes y");
    Save(tag+"-omni-"+facility,new{Tolerance=tol,Model=omni,Outer=TemplateCad.OmniOuter(hull,9260,-1),Mirrored=PointLists._008B_008A_009B(omni._0088_008A_0096)});
   }Log("PASS "+tag+" left/right, auxiliary, XE/YE, VOR/NDB all-direction");
  }
 }
 static void BaseFixtures(){
  foreach(string facility in new[]{"VOR","NDB"})foreach(bool time in new[]{true,false})foreach(double w in new[]{0.0,56}){
   var t=T(w);double value=time?60:5;var b=new BaseTurn(t,facility,120,time,value,4630);var l=TemplateCad.BaseTurn(b,false,false,0,new TemplatePoint(0,0));var r=TemplateCad.BaseTurn(new BaseTurn(t,facility,120,time,value,4630),true,false,0,new TemplatePoint(0,0));Mirror(l,r);Finite(l);Metadata(l);
   double v=t._008A_009D_009A/3.6,minutes=time?value/60:value*1852/(60*v);Near(b._0091_008E,-(t._008A_009D_009A>315?.116*t._008A_009D_009A:36)/minutes*Math.PI/180,"phi");Near(b._0091_0095,(facility=="VOR"?5.2:6.5)*Math.PI/180,"facility angle");Near(b._0091_008F,time?v*value:value*1852,"time distance units");Check(l.Count==3,"base nominal primary secondary");
   var noWidth=new BaseTurn(t,facility,120,time,value,0);noWidth._0091_0087(false,false);Check(noWidth._0092_008E.Count==b._0092_008E.Count,"width primary count");for(int i=0;i<b._0092_008E.Count;i++){Near(noWidth._0092_008E[i].X,b._0092_008E[i].X,"primary width invariant x");Near(noWidth._0092_008E[i].Y,b._0092_008E[i].Y,"primary width invariant y");}
   string tag="base-"+facility+"-"+(time?"time":"distance")+"-w"+w;Save(tag,new{Input=new{IAS=300,Altitude=600,Bank=25,Wind=w,Temperature=15,Antenna=120,Facility=facility,ByTime=time,Value=value,SecondaryWidth=4630},Model=b,Left=l,Right=r});
   var aux=TemplateCad.BaseTurn(new BaseTurn(t,facility,120,time,value,4630),false,true,0,new TemplatePoint(0,0));Check(aux.Count>3,"base auxiliary");Save(tag+"-aux",aux);
   var again=TemplateCad.BaseTurn(new BaseTurn(t,facility,120,time,value,4630),false,false,0,new TemplatePoint(0,0));Check(json.Serialize(Data(l))==json.Serialize(Data(again)),"base repeatability");Log("PASS "+tag+" mirror, phi, facility, width, repeatability, auxiliary");
  }
  foreach(double tas in new[]{315.0,315.000001}){var t=T(0);t._008A_009D_009A=tas;var b=new BaseTurn(t,"VOR",0,true,60);Near(b._0091_008E,-(tas>315?.116*tas:36)*Math.PI/180,"315 boundary");Save("phi-tas"+tas,new{TAS=tas,Phi=b._0091_008E});}
 }
 static void ProcedureFixtures(){
  foreach(double w in new[]{0.0,56}){
   var t=T(w);foreach(double tm in new[]{1.0,1.5}){
    var p=new Procedure45180(t,tm);var l=TemplateCad.Procedure45180(p,false,false,0,new TemplatePoint(0,0));var r=TemplateCad.Procedure45180(new Procedure45180(t,tm),true,false,0,new TemplatePoint(0,0));Mirror(l,r);Finite(l);Metadata(l);
    Near(p._0088_0097_0090,(tm*60-5-45/t._008A_009D_009C)*t._008A_009D_009A/3.6,"45 time leg");Check(l.Count==2&&l[0].Points.Count==5,"45 outputs");string tag="45-w"+w+"-t"+tm;Save(tag,new{Input=new{IAS=300,Altitude=600,Bank=25,Wind=w,Temperature=15,Minutes=tm},Model=p,Left=l,Right=r});
    var aux=TemplateCad.Procedure45180(new Procedure45180(t,tm),false,true,0,new TemplatePoint(0,0));Check(aux.Count==5,"45 auxiliary 3 spirals");Save(tag+"-aux",aux);var again=TemplateCad.Procedure45180(new Procedure45180(t,tm),false,false,0,new TemplatePoint(0,0));Check(json.Serialize(Data(l))==json.Serialize(Data(again)),"45 repeatability");Log("PASS "+tag+" mirror, time leg, boundary, auxiliary, repeatability");
   }
   var q=new Procedure80260(t);var ql=TemplateCad.Procedure80260(q,false,false,0,new TemplatePoint(0,0));var qr=TemplateCad.Procedure80260(new Procedure80260(t),true,false,0,new TemplatePoint(0,0));Mirror(ql,qr);Finite(ql);Metadata(ql);Near(q._0088_0099_0088,10*t._008A_009D_009A/3.6,"80 fixed straight");Check(ql.Count==2&&ql[0].Points.Count==5,"80 outputs");Save("80-w"+w,new{Input=new{IAS=300,Altitude=600,Bank=25,Wind=w,Temperature=15},Model=q,Left=ql,Right=qr});
   var qa=TemplateCad.Procedure80260(new Procedure80260(t),false,true,0,new TemplatePoint(0,0));Check(qa.Count==4,"80 auxiliary 2 spirals");Save("80-w"+w+"-aux",qa);
   var repeated80=TemplateCad.Procedure80260(new Procedure80260(t),false,false,0,new TemplatePoint(0,0));Check(json.Serialize(Data(ql))==json.Serialize(Data(repeated80)),"80 repeatability");Log("PASS 80-w"+w+" mirror, fixed 10v leg, boundary, auxiliary, repeatability");
  }
 }
 static void WriterFixtures(){
  var t=T(56);var h=new Holding(t,1);h._0088_0087_009A(true);
  double r=t._008A_009D_009D,L=h._0088_0088_0091;
  var label=TemplateCad.HoldingLabel(h,false,0,new TemplatePoint(100,200),new TemplatePoint(110,200));
  Near(label.Points[0].X,100+L/2,"label mean X");Near(label.Points[0].Y,200-r,"label mean Y");
  var reflected=TemplateCad.HoldingLabel(h,true,0,new TemplatePoint(100,200),new TemplatePoint(110,200));
  Near(reflected.Points[0].X,200+r,"legacy label swapped X");Near(reflected.Points[0].Y,100+L/2,"legacy label swapped Y");
  Check(label.XDataApp==null&&label.Entity=="MText"&&label.TextHeight==1000&&label.Attachment==5,"label metadata");
  foreach(double a in new[]{-Math.PI/2,Math.PI/2,0.4})Near(TemplateCad.HoldingLabel(h,false,a,new TemplatePoint(0,0),new TemplatePoint(1,0)).Rotation,a==0.4?a:Math.PI+a,"label rotation strict bounds");
  var xe=new HoldingXE(t,1);var ye=new HoldingYE(t,1);
  var xl=TemplateCad.XE(xe,false,0,new TemplatePoint(0,0));var xr=TemplateCad.XE(xe,true,0,new TemplatePoint(0,0));Mirror(xl,xr);Finite(xl);
  var yl=TemplateCad.YE(ye,false,0,new TemplatePoint(0,0));var yr=TemplateCad.YE(ye,true,0,new TemplatePoint(0,0));Mirror(yl,yr);Finite(yr);
  Near(xl[0].Points[0].Y,xe._0088_008C_0087[0][0].Y,"XE left native");Near(yr[0].Points[0].Y,ye._0088_008D_0091[0][0].Y,"YE right native");
  Check(xl.All(x=>x.Description==t.ToString())&&yr.All(x=>x.Description==t.ToString()),"XE YE turn description");
  var square=new List<TemplatePoint>{new TemplatePoint(0,0),new TemplatePoint(10,0),new TemplatePoint(10,10),new TemplatePoint(0,10),new TemplatePoint(0,0)};
  var outer=TemplateCad.OmniOuter(square,2);Near(outer[0].X,10,"outer segment endpoint X");Near(outer[0].Y,-2,"outer segment endpoint normal");Check(outer.Count==5,"outer repeated first");
  var tol=TemplateCad.HoldingTolerance(t,"VOR",0);h._0088_0087_009B(false);h._0088_0087_009D(tol[0],tol[1],xe._0088_008B_008F.X,ye._0088_008C_0096.Y,false);
  var ol=TemplateCad.Omni(h,false,0,new TemplatePoint(0,0));var or=TemplateCad.Omni(h,true,0,new TemplatePoint(0,0));Mirror(ol,or);Finite(ol);Check(ol.Last().XDataApp==null&&ol.Last().Group==null&&!ol.Last().Closed,"omni outer metadata");
  Check(TemplateCad.EnvelopeOutput(null)==null,"cancel envelope writer");var empty=TemplateCad.EnvelopeOutput(new List<EnvelopePoint>());Check(empty.Points.Count==0&&!empty.Closed&&empty.XDataApp==null,"empty envelope writer");
  Save("writer-label-xe-ye-omni",new{Input=new{IAS=300,Altitude=600,Bank=25,Wind=56,Temperature=15,Minutes=1},Label=label,ReflectedLabel=reflected,XELeft=xl,XERight=xr,YELeft=yl,YERight=yr,OmniLeft=ol,OmniRight=or,OuterSquare=outer,EmptyEnvelope=empty});
  // Endpoint/bulge checks use the chord radius, independent of builder control fields.
  var b=new BaseTurn(t,"VOR",0,true,60,4630);var p45=new Procedure45180(t,1);var p80=new Procedure80260(t);
  var curves=new[]{TemplateCad.Holding(new Holding(t,1),false,false,0,new TemplatePoint(0,0))[0],TemplateCad.BaseTurn(b,false,false,0,new TemplatePoint(0,0))[0],TemplateCad.Procedure45180(p45,false,false,0,new TemplatePoint(0,0))[0],TemplateCad.Procedure80260(p80,false,false,0,new TemplatePoint(0,0))[0]};
  foreach(var curve in curves)for(int i=0;i<curve.Bulges.Length;i++){double bulge=curve.Bulges[i];if(bulge==0)continue;int j=(i+1)%curve.Points.Count;double chord=TemplatePoint._008B_0088_009E(curve.Points[i],curve.Points[j]);Near(chord*(1+bulge*bulge)/(4*Math.Abs(bulge)),r,"nominal arc endpoints and radius");}
  Save("nominal-endpoint-continuity",new{TurnRadius=r,Curves=curves,Evidence="each segment shares stored vertex; nonzero bulge chord implies common radius"});
  Log("PASS writer label quirks/bounds, XE/YE opposite baselines, omni offset/mirror/metadata, empty/cancel; nominal arc endpoint radii");
 }
 static SelectedTemplateEntity Poly(params double[] xy){var e=new SelectedTemplateEntity{Type="Polyline",Closed=true};for(int i=0;i<xy.Length;i+=2)e.Vertices.Add(new EnvelopePoint(xy[i],xy[i+1]));return e;}
 static double Area(List<EnvelopePoint> p){double a=0;for(int i=1;i<p.Count;i++)a+=p[i-1].X*p[i].Y-p[i].X*p[i-1].Y;return Math.Abs(a)/2;}
 // Observer for degenerate cases only: identical transition, external cycle detection.
 // No guard is added to recovered Envelope.Hull; repeated state proves an infinite loop.
 static object TraceEnvelope(List<EnvelopePoint> points){
  var start=points.OrderBy(p=>p.Y).ThenBy(p=>p.X).First();var current=start;var seen=new List<EnvelopePoint>();var prefix=new List<EnvelopePoint>{start};
  do{
   if(seen.Contains(current))return new{Status="nonterminating-cycle",OutputPrefix=prefix};seen.Add(current);
   var candidate=points[0];foreach(var p in points)if(candidate==current||Envelope.Orientation(current,candidate,p)==2)candidate=p;
   prefix.Add(candidate);current=candidate;
  }while(current!=start);
  return new{Status="terminated",OutputPrefix=prefix};
 }
 static void EnvelopeFixtures(){
  var cases=new Dictionary<string,List<SelectedTemplateEntity>>{
   {"nested",new List<SelectedTemplateEntity>{Poly(0,0,10,0,10,10,0,10),Poly(2,2,4,2,4,4,2,4),Poly(6,6,7,6,7,7,6,7)}},
   {"overlap",new List<SelectedTemplateEntity>{Poly(0,0,4,0,4,4,0,4),Poly(2,2,6,2,6,6,2,6),Poly(3,-1,5,-1,5,1,3,1)}},
   {"crossing",new List<SelectedTemplateEntity>{Poly(-3,-1,3,-1,3,1,-3,1),Poly(-1,-3,1,-3,1,3,-1,3),Poly(-2,0,0,-2,2,0,0,2)}}};
  foreach(var c in cases){
   var p=Envelope.Selection(c.Value);Check(p[0]==p.Last(),"hull repeated start");Check(Area(p)>0,"hull positive area");Save("envelope-"+c.Key,new{Inputs=c.Value,Output=p,Closed=false,XData=false,OriginalsRetained=true});var rev=c.Value.AsEnumerable().Reverse().ToList();var q=Envelope.Selection(rev);Near(Area(p),Area(q),"normal reorder area");Save("envelope-"+c.Key+"-reorder",new{Inputs=rev,Output=q});
   foreach(var e in c.Value){e.Closed=false;e.Bulges=new[]{.5,.5,.5,.5};}Check(json.Serialize(Data(p))==json.Serialize(Data(Envelope.Selection(c.Value))),"closed bulge ignored");Log("PASS envelope-"+c.Key+" saved, reorder area, ignores bulge/closed");
  }
  var single=Poly(0,0,3,0,3,3,0,3);var singleOut=Envelope.Selection(new List<SelectedTemplateEntity>{single});Near(Area(singleOut),9,"single square");Save("envelope-single",new{Input=single,Output=singleOut});Check(Envelope.Selection(null)==null,"cancel no append");var empty=Envelope.Selection(new List<SelectedTemplateEntity>());Check(empty.Count==0,"OK empty zero vertices");Save("envelope-empty",new{Input=new List<SelectedTemplateEntity>(),Output=empty});
  var line=Poly(-5,-1,5,1);line.Type="Line";var circle=new SelectedTemplateEntity{Type="Circle"};var mix=new List<SelectedTemplateEntity>{line,single,circle};var mixed=Envelope.Selection(mix);Check(mixed.Any(x=>x.X==-5)&&mixed.Any(x=>x.X==5),"Line endpoints included");Save("envelope-nonPolyline",new{Inputs=mix,Output=mixed});
  var c1=new List<EnvelopePoint>{new EnvelopePoint(0,0),new EnvelopePoint(1,0),new EnvelopePoint(2,0)};var c2=c1.AsEnumerable().Reverse().ToList();Save("envelope-collinear-order",new{Input1=c1,Trace1=TraceEnvelope(c1),Input2=c2,Trace2=TraceEnvelope(c2),Evidence="bounded observer; recovered Hull unchanged"});Log("PASS envelope single/cancel/empty/Line/Circle; collinear cycle saved without correction");
 }
 public static void Main(string[] args){
  Console.OutputEncoding=System.Text.Encoding.UTF8;output=Console.Out;Console.SetOut(new StringWriter());dir=args[0];Directory.CreateDirectory(dir);
  try{Primitives();HoldingFixtures();BaseFixtures();ProcedureFixtures();EnvelopeFixtures();WriterFixtures();Log("PASS assertions="+count+"; recovery-only fixtures; no original DLL/AutoCAD execution");}
  catch(Exception e){Log("FAIL after assertions="+count+" "+e);Environment.ExitCode=1;}
 }
}
