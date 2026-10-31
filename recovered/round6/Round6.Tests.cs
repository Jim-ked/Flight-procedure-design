using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Recovered.B3;
using Recovered.A6;
using Recovered.B5;
class Round6Tests {
 static Dictionary<string,int> counts=new Dictionary<string,int>(); static List<object> cases=new List<object>();static string dir;
 static void Check(string layer,string name,bool ok){if(!ok)throw new Exception(layer+": "+name);if(!counts.ContainsKey(layer))counts[layer]=0;counts[layer]++;}
 static void Near(string layer,string name,double a,double b){Check(layer,name,(double.IsNaN(a)&&double.IsNaN(b))||a==b||Math.Abs(a-b)<1e-7);}
 static object N(double a){return double.IsNaN(a)?(object)"NaN":double.IsPositiveInfinity(a)?"Infinity":double.IsNegativeInfinity(a)?"-Infinity":(object)a;}
 static object Pt(TemplatePoint p){return new {X=N(p.X),Y=N(p.Y),Z=N(p.Z)};}
 static object Result(RnpApchObstacle p){return new {p.ID,p.Name,point=Pt(p),area=p._0088_008F_009C,MOC=N(p._0088_008F_009D),OCA=N(p._0088_008F_009E),OCH=N(p._0088_0090_0086),MDA=N(p._0088_0090_0087),MDH=N(p._0088_0090_0088),VIS=N(p._0088_0090_0089)};}
 static object Result(RnpApchApvObstacle p){return new {p.ID,p.Name,point=Pt(p),area=p._0088_0090_008A,surface=N(p._0088_0090_008B),penetration=N(p._0088_0090_008C),HL=N(p._0088_0090_008D),Ha=N(p._0088_0090_008E),OCA=N(p._0088_0090_008F),OCH=N(p._0088_0090_0090),DA=N(p._0088_0090_0091),DH=N(p._0088_0090_0092),RVR=N(p._0088_0090_0093)};}
 static void Save(string id,string layer,object input,object output){var obj=new {id,layer,input,output,evidence="Independent recovered code; not original DLL oracle"};File.WriteAllText(Path.Combine(dir,id+".json"),new JavaScriptSerializer().Serialize(obj),System.Text.Encoding.UTF8);cases.Add(new{id,layer});}
 static RnpApchApv Apv(string cat,double elevation,double angle,double temp){return new RnpApchApv(10000,900,0,angle,15,75,.025,10000,elevation,temp,cat);}
 static double Field(object obj,string field){return (double)obj.GetType().GetField(field,BindingFlags.Instance|BindingFlags.NonPublic).GetValue(obj);}
 static void Main(string[] args){
  Console.OutputEncoding=System.Text.Encoding.UTF8;dir=args[0];Directory.CreateDirectory(dir);
  string[] cats={"A","B","C","D"};double[] hlm={40,43,46,49},hlr={13,18,22,26},xz={-900,-900,-1100,-1400};
  for(int c=0;c<4;c++)foreach(double elev in new[]{0.0,900,900.001,1800})foreach(double gp in new[]{3.0,3.2,3.3}){
   double want=hlm[c]+(elev>900?hlr[c]*.02*elev/300:0)+(gp>3.2?(gp-3.2)*hlr[c]*.05:0);
   double hl=RnpApchApv._008A_008B_009A(cats[c],elev,gp);Near("formula","HL category/elevation/GP",hl,want);
   Near("formula","Xz",RnpApchApv._008A_008B_0099(cats[c]),xz[c]);
   var g=Apv(cats[c],elev,gp,-20);Near("geometry","constructor Xz",Field(g,"_008A_008C_0097"),xz[c]);Near("formula","constructor HL",Field(g,"_008A_008C_0098"),want);
   Save("apv_"+cats[c]+"_"+elev.ToString(System.Globalization.CultureInfo.InvariantCulture)+"_"+gp.ToString(System.Globalization.CultureInfo.InvariantCulture),"formula+geometry",new{category=cats[c],elev,gp,temp=-20},new{hl,xz=xz[c],Fap=Pt(g._008A_008C_0086),FasEnd=Pt(g._008A_008C_0087),horizontalStart=Pt(g._008A_008C_008F),missedStart=Pt(g._008A_008C_0090)});
  }
  Near("formula","unknown Xz fallback",RnpApchApv._008A_008B_0099("?"),-1400);Near("formula","H HL",RnpApchApv._008A_008B_009A("H",0,3),35);
  Near("formula","display HL two decimals",RnpApchMissed.HlDisplay(49,26,1800),52.12);
  foreach(double wind in new[]{0.0,19,80})foreach(double alt in new[]{0.0,900,1800}){
   double tas=380*171233*Math.Sqrt(288+15-.006496*alt)/Math.Pow(288-.006496*alt,2.628);
   double got=RnpApchMissed.LnavSoc(380,alt,wind,15,18,false,false);
   Near("formula","LNAV SOC includes444",got,Math.Round((tas+wind)*18/3.6+444));
   Save("lnav_soc_"+wind+"_"+alt,"formula",new{ias=380,alt,wind,temp=15,seconds=18},new{distance=got,tas});
  }
  Near("formula","knots conversion",RnpApchMissed.LnavSoc(200,900,10,15,18,true,true),RnpApchMissed.LnavSoc(370.4,900,18.52,15,18,false,false));
  Near("formula","SOC TP displayed",RnpApchMissed.SocToTp(100,300,2.5),8000);
  Check("degenerate","zero gradient Infinity",double.IsPositiveInfinity(RnpApchMissed.SocToTp(100,300,0)));
  Check("degenerate","zero over zero NaN",double.IsNaN(RnpApchMissed.SocToTp(100,100,0)));
  Check("degenerate","negative TP retained",RnpApchMissed.SocToTp(400,300,2.5)==-4000);
  Save("tp_degenerate","degenerate",new{soc=100,turn=300},new{zero=N(RnpApchMissed.SocToTp(100,300,0)),zeroZero=N(RnpApchMissed.SocToTp(100,100,0)),negative=-4000});
  var ln=new RnpApchLnav(10000,900,0,3,15,.025,2000,8000);double f=(900-15)/Math.Tan(Math.PI/60);
  Near("geometry","FAF distance",ln._0089_009C_0092,f);Near("geometry","TP total",ln._0089_009C_0094,10000);
  Check("geometry","four open lists",ln._0089_009C_0096.Count==4&&ln._0089_009C_0096.All(l=>l.Count==6));
  for(int i=0;i<6;i++){Near("invariant","outer mirror X",ln._0089_009C_0096[0][i].X,ln._0089_009C_0096[3][i].X);Near("invariant","outer mirror Y",ln._0089_009C_0096[0][i].Y,-ln._0089_009C_0096[3][i].Y);Near("geometry","half-width list",ln._0089_009C_0096[1][i].Y,ln._0089_009C_0096[0][i].Y/2);}
  Save("lnav_geometry","geometry",new{ifLength=10000,fafAlt=900,thr=0,gp=3,tch=15,mcg=.025,thrSoc=2000,socTp=8000},ln._0089_009C_0096.Select(l=>l.Select(Pt).ToArray()).ToArray());
  var lc=typeof(RnpApchLnav).GetMethod("_0089_009C_0087",BindingFlags.Instance|BindingFlags.NonPublic);
  foreach(double x in new[]{-1000.0,-999.999,-500,0,.001})foreach(double y in new[]{0.0,150,225,300,400}){
   var p=new RnpApchObstacle(new TemplatePoint(x,y,100));p=(RnpApchObstacle)lc.Invoke(ln,new object[]{p,200.0,75.0,400.0,100.0,1000.0});
   if(x==-500&&y==0)Near("classification","LNAV primary MOC",p._0088_008F_009D,87.5);
   if(x==-500&&y==225)Near("classification","LNAV secondary reduction",p._0088_008F_009D,43.75);
   if(x==-1000||x>.0||y==400)Check("classification","LNAV endpoint/coarse exclusion",p._0088_008F_009C=="out");
   Save("lnav_classifier_"+x+"_"+y,"classification",new{x,y,w0=200,w1=400,len=1000},Result(p));
  }
  foreach(double x in new[]{f+5000,f, f-444,f-1604,1000,444,0,-1000,-2000,-5000,-6814,-10000,-10001})foreach(double y in new[]{0.0,1000,3000}){
   var p=new RnpApchObstacle(new TemplatePoint(x,y,100));ln._0089_009C_0086(ref p);
   if(x==1000&&y==0){Near("classification","final MOC75",p._0088_008F_009D,75);Near("formula","legacy OCH carrier absolute Z+MOC",p._0088_0090_0086,175);Near("formula","OCA carrier remains zero",p._0088_008F_009E,0);}
   if(x==-10001)Check("classification","past TP out",p._0088_008F_009C=="out");
   Save("lnav_eval_"+x.ToString("R",System.Globalization.CultureInfo.InvariantCulture)+"_"+y,"classification",new{x,y,z=100},Result(p));
  }
  var ap=Apv("D",0,3,-20);var ac=typeof(RnpApchApv).GetMethod("_008A_008B_0097",BindingFlags.Instance|BindingFlags.NonPublic);
  foreach(double x in new[]{-1000.0,-500,0})foreach(double y in new[]{0.0,150,225,300,400}){
   var p=new RnpApchApvObstacle(new TemplatePoint(x,y,100));object[] par={p,new TemplatePoint(0,200,10),75.0,new TemplatePoint(-1000,400,30),100.0};ac.Invoke(ap,par);p=(RnpApchApvObstacle)par[0];
   if(x==-500&&y==0){Near("classification","APV primary surface",p._0088_0090_008B,20);Near("classification","APV primary fraction",p._0088_0090_008D,1);}
   if(x==-500&&y==225){Near("classification","APV secondary surface",p._0088_0090_008B,63.75);Near("classification","APV secondary fraction",p._0088_0090_008D,.5);}
   if(y==0)Check("classification","APV inclusive end",p._0088_0090_008A=="主区");
   Save("apv_classifier_"+x+"_"+y,"classification",new{x,y},Result(p));
  }
  foreach(double x in new[]{ap._008A_008B_009D.X+1,ap._008A_008B_009E.X+500,ap._008A_008C_008D.X,ap._008A_008C_008E.X,ap._008A_008C_0087.X,ap._008A_008C_008F.X,1000,444,0,-1400,-6814,-10000,-10001})foreach(double y in new[]{0.0,1000,3000}){
   var p=new RnpApchApvObstacle(new TemplatePoint(x,y,100));ap._008A_008B_0096(ref p);
   if(x==1000&&y==0){Near("formula","APV horizontal primary OCH",p._0088_0090_0090,149);Check("classification","APV horizontal label",p._0088_0090_008A=="水平段主区");}
   Save("apv_eval_"+x.ToString("R",System.Globalization.CultureInfo.InvariantCulture)+"_"+y,"classification",new{x,y,z=100},Result(p));
  }
  foreach(double angle in new[]{0.0,-3,90}){var g=Apv("D",0,angle,-20);Save("apv_angle_"+angle,"degenerate",new{angle},new{Fap=Pt(g._008A_008C_0086),FasEnd=Pt(g._008A_008C_0087),messages=RecoveryMessages.Messages.ToArray()});}
  var nz=new RnpApchLnav(10000,-100,0,3,15,0,2000,8000);Check("degenerate","negative FAF retained",nz._0089_009C_0092<0);Save("lnav_negative_faf","degenerate",new{faf=-100,g=0},new{distance=nz._0089_009C_0092});
  var frame=FrameHelpers._0089_008F(new TemplatePoint(100,200,50),new TemplatePoint(1100,200,70));var local=FrameHelpers._0089_0090(frame,new TemplatePoint(-100,300,80));Near("geometry","THR outward axis",local.X,200);Near("geometry","local cross sign",local.Y,-100);Near("geometry","frame Z relative",local.Z,30);
  Save("runway_frame","geometry",new{thr=Pt(frame)},Pt(local));
  var min=new RnpApchApvObstacle(new TemplatePoint(0,0,100));min._0088_0090_0090=101;RnpApchForm._0088_009A_0091(ref min,0,900,.0524,"D");Near("formula","DH ceiling5",min._0088_0090_0092,105);Near("formula","DA rounded",min._0088_0090_0091,105);Save("apv_minima","formula",new{och=101,thr=0,lgt=900,tan=.0524},Result(min));
  var nm=new RnpApchObstacle(new TemplatePoint(0,0,100));nm._0088_0090_0087=20;RnpApchForm._0088_009D_0086(ref nm,0,0,0,3,"A");Near("formula","LNAV MDH minimum90",nm._0088_0090_0088,90);Near("formula","LNAV MDA minimum90",nm._0088_0090_0087,90);Save("lnav_minima","formula",new{mda=20},Result(nm));
  // Record adapters test recovered text grammar and XY writer inputs, not AutoCAD transactions.
  var state=new[]{new KeyValuePair<string,string>("tabControl1.groupBox1.textBoxZ1","50"),new KeyValuePair<string,string>("tabControl1.groupBox2.comboBoxCat","3")};
  string saved=RnpApchStateText.Save(state);Check("serialization","header and traversal order",saved=="FormApvEvl\ntabControl1.groupBox1.textBoxZ1:50\ntabControl1.groupBox2.comboBoxCat:3\n");
  var loaded=new Dictionary<string,string>{{state[0].Key,"0"},{state[1].Key,"0"}};RnpApchStateText.Load(saved,loaded);
  Check("serialization","roundtrip supported flat controls",loaded[state[0].Key]=="50"&&loaded[state[1].Key]=="3");
  RnpApchStateText.Load("FormApvEvl\nmissing:100\n "+state[0].Key+" : 60:discarded\n",loaded);
  Check("serialization","unknown skipped and colon truncation",loaded[state[0].Key]=="60"&&loaded.Count==2);
  RnpApchStateText.Load("WrongForm\n"+state[0].Key+":99",loaded);Check("serialization","wrong header leaves state",loaded[state[0].Key]=="60");
  bool malformed=false;try{RnpApchStateText.Load("FormApvEvl\nmalformed",loaded);}catch(IndexOutOfRangeException){malformed=true;}Check("serialization","missing colon throws",malformed);
  bool empty=false;try{RnpApchStateText.Load("",loaded);}catch(IndexOutOfRangeException){empty=true;}Check("serialization","empty text throws",empty);
  Save("state_text","serialization",new{saved},new{loaded,malformed,empty,limitation="Flat supported-control adapter, not WinForms typed setter execution"});
  var cad=RnpApchCad.Record(ln,frame,saved);Check("geometry","four polyline writer inputs",cad.Count==4);
  for(int i=0;i<4;i++){Check("geometry","six vertices open zero bulge",cad[i].XY.Count==6&&!cad[i].Closed&&cad[i].Bulge==0);Check("serialization","full control state XData",cad[i].XDataApplication=="WsObject"&&cad[i].XDataText==saved);Check("geometry","writer loses Z",cad[i].XY.All(p=>p.Z==0));}
  Near("geometry","reverse-bearing rotation X",cad[0].XY[0].X,100-ln._0089_009C_0096[0][0].X);Near("geometry","reverse-bearing rotation Y",cad[0].XY[0].Y,200-ln._0089_009C_0096[0][0].Y);
  Save("cad_record","geometry+serialization",new{thr=Pt(frame),state=saved},cad.Select(l=>new{l.Closed,l.Bulge,l.XDataApplication,l.XDataText,vertices=l.XY.Select(Pt).ToArray()}).ToArray());
  var eq=typeof(RnpApchApv).GetMethod("_008A_008B_009C",BindingFlags.Instance|BindingFlags.NonPublic);
  foreach(double fraction in new[]{1.0,.5}){var ob=new RnpApchApvObstacle(new TemplatePoint(-2000,0,200));ob._0088_0090_008D=fraction;object[] arr={ob};eq.Invoke(ap,arr);ob=(RnpApchApvObstacle)arr[0];double offset=30*(1-fraction);double wantHa=Math.Ceiling(((200-offset)/.025-2000+1400)/(1/Math.Tan(Math.PI/60)+1/.025));Near("formula","APV penetrating equivalent Ha",ob._0088_0090_008E,wantHa);Near("formula","penetrating full HL even secondary",ob._0088_0090_008D,49);Near("formula","equivalent OCH",ob._0088_0090_0090,wantHa+49);Save("apv_equivalent_"+fraction,"formula",new{x=-2000,z=200,fraction},Result(ob));}
  var zg=new RnpApchApv(10000,900,0,3,15,75,0,10000,0,-20,"D");var zo=new RnpApchApvObstacle(new TemplatePoint(-2000,0,200));zo._0088_0090_008D=1;object[] zargs={zo};eq.Invoke(zg,zargs);zo=(RnpApchApvObstacle)zargs[0];Check("degenerate","zero MCG equivalent Ha NaN",double.IsNaN(zo._0088_0090_008E));Save("apv_zero_mcg","degenerate",new{g=0},Result(zo));
  Near("degenerate","zero HL display retained",RnpApchMissed.HlDisplay(0,0,1800),0);Near("degenerate","negative HL display retained",RnpApchMissed.HlDisplay(-10,0,0),-10);Check("degenerate","NaN elevation HL retained",double.IsNaN(RnpApchApv._008A_008B_009A("D",double.NaN,3)));
  var stale=new RnpApchApvObstacle(new TemplatePoint(1,0,100));stale._0088_0090_008A="previous";stale._0088_0090_008B=321;object[] st={stale,new TemplatePoint(0,200,10),75.0,new TemplatePoint(-1000,400,30),100.0};ac.Invoke(ap,st);stale=(RnpApchApvObstacle)st[0];Check("degenerate","invalid classifier retains old values",stale._0088_0090_008A=="previous"&&stale._0088_0090_008B==321);Save("apv_invalid_domain_stale","degenerate",new{x=1},Result(stale));
  var same1=new RnpApchObstacle(new TemplatePoint(1000,0,100));var same2=new RnpApchApvObstacle(new TemplatePoint(1000,0,100));ln._0089_009C_0086(ref same1);ap._008A_008B_0096(ref same2);Check("invariant","same obstacle independent area records",same1._0088_0090_0086==175&&same2._0088_0090_0090==149);Save("same_obstacle_two_classes","invariant",new{x=1000,y=0,z=100},new{lnav=Result(same1),apv=Result(same2),merged=false});
  double negativeSoc=RnpApchMissed.LnavSoc(380,0,0,15,-18,false,false);Check("degenerate","negative SOC distance retained",negativeSoc<0);Save("lnav_negative_soc","degenerate",new{ias=380,alt=0,wind=0,temp=15,seconds=-18},new{distance=negativeSoc});
  var reverseSoc=new RnpApchLnav(10000,900,0,3,15,.025,-500,8000);Near("geometry","negative ThrToSoc reverses SOC station",reverseSoc._0089_009C_008F.X,500);Save("lnav_negative_thr_soc","degenerate",new{thrSoc=-500,socTp=8000},new{soc=Pt(reverseSoc._0089_009C_008F),end=Pt(reverseSoc._0089_009C_0090)});
  foreach(var kv in counts)Console.WriteLine("PASS "+kv.Key+" assertions="+kv.Value);
  File.WriteAllText(Path.Combine(dir,"index.json"),new JavaScriptSerializer().Serialize(new{cases,assertions=counts}),System.Text.Encoding.UTF8);
 }
}
