using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Recovered.A4;
class Tests {
 static Dictionary<string,int> counts=new Dictionary<string,int>();static List<string> records=new List<string>{"layer,case,actual,expected"};
 static string Csv(string s){return "\""+s.Replace("\"","\"\"")+"\"";}
 static void Check(string l,string n,object a,object b){if(!counts.ContainsKey(l))counts[l]=0;counts[l]++;if(!object.Equals(a,b))throw new Exception(l+" "+n+" actual="+a+" expected="+b);records.Add(string.Join(",",new[]{l,n,Convert.ToString(a),Convert.ToString(b)}.Select(Csv)));}
 static void Near(string l,string n,double a,double b){Check(l,n,double.IsNaN(a)&&double.IsNaN(b)||a==b||Math.Abs(a-b)<=1e-8*Math.Max(1,Math.Abs(b)),true);}
 static NavAidProtectionForm Form(bool vor=true,bool wide=false,bool left=true,bool right=true,bool center=true,bool expand=false){var f=new NavAidProtectionForm();f.SetFacility(vor);f._0087_0090_009C.Checked=!wide;f._0087_0090_009B.Checked=wide;f._0087_0090_0099.Checked=left;f._0087_0090_0096.Checked=right;f._0087_0090_0097.Checked=center;f._0087_0090_0098.Checked=expand;return f;}
 static void Draw(NavAidProtectionForm f,NavCadPoint s,NavCadPoint e){f.Picks.Enqueue(s);f.Picks.Enqueue(e);f._0087_0090_008F(null,EventArgs.Empty);}
 static string Points(List<List<RePoint>> p){return string.Join("|",p.Select(l=>string.Join(";",l.Select(q=>q.X+","+q.Y+","+q.Z))));}
 static void Dispatch(){var f=Form();Check("mode/facility dispatch","angle UI disabled",f._0087_0091_0087.Enabled,false);Check("mode/facility dispatch","VOR small label",f._0087_0090_009C.Text,"1.0 nm");Check("mode/facility dispatch","VOR large label",f._0087_0090_009B.Text,"2.0 nm");Check("mode/facility dispatch","VOR angle",f._0087_0091_0087.Text,"7.8");f.SetFacility(false);Check("mode/facility dispatch","NDB small label",f._0087_0090_009C.Text,"1.25 nm");Check("mode/facility dispatch","NDB large label",f._0087_0090_009B.Text,"2.5 nm");Check("mode/facility dispatch","NDB angle",f._0087_0091_0087.Text,"10.3");f._0087_0091_0087.Text="4.2";f._0087_0090_008D(null,EventArgs.Empty);Check("mode/facility dispatch","VOR handler overwrites while NDB selected",f._0087_0091_0087.Text,"7.8");f._0087_0090_008E(null,EventArgs.Empty);Check("mode/facility dispatch","last handler wins",f._0087_0091_0087.Text,"10.3");f.SetFacility(true);Check("mode/facility dispatch","VOR restored",f._0087_0091_0087.Text,"7.8");}
 static void Matrix(string dir){var output=new List<string>{"case,list,vertex,x,y,z"};var ends=new List<string>{"case,side,outer_x,outer_y,inner_x,inner_y"};
 foreach(bool vor in new[]{true,false})foreach(bool wide in new[]{false,true})foreach(int side in new[]{0,1,2})foreach(bool center in new[]{false,true})foreach(bool expand in new[]{false,true})foreach(double deg in new[]{0.0,90,37}){
  var f=Form(vor,wide,side!=1,side!=0,center,expand);double w=(vor?(wide?2:1):(wide?2.5:1.25))*1852,a=vor?7.8:10.3,angle=deg*Math.PI/180,L=20000;var s=new NavCadPoint(3000,4000,110);var e=new NavCadPoint(s.X+L*Math.Cos(angle),s.Y+L*Math.Sin(angle),250);Draw(f,s,e);
  var g=NavAidProtectionGeometry.Build(s.ToRecovered(),e.ToRecovered(),w,a,side!=1,side!=0,center,expand);string key=(vor?"VOR":"NDB")+"-"+(wide?"W2":"W1")+"-side"+side+"-center"+center+"-cut"+expand+"-deg"+deg;
  Check("CAD writer",key+" list count",f.Written.Count,(center?1:0)+(side==2?2:1)*(expand?3:2));Check("geometry",key+" structured count",g.Paths.Count,f.Written.Count);
  for(int i=0;i<g.Paths.Count;i++){Check("geometry",key+" vertices"+i,g.Paths[i].Count,f.Written[i].Count);for(int j=0;j<g.Paths[i].Count;j++){Near("geometry",key+" X"+i+"-"+j,g.Paths[i][j].X,f.Written[i][j].X);Near("geometry",key+" Y"+i+"-"+j,g.Paths[i][j].Y,f.Written[i][j].Y);Near("geometry",key+" Z"+i+"-"+j,g.Paths[i][j].Z,f.Written[i][j].Z);}}
  // Independent local-coordinate closed form; not the line/intersection implementation.
  foreach(string name in side==2?new[]{"Right","Left"}:new[]{side==0?"Left":"Right"}){
   int sign=name=="Left"?1:-1;double k=Math.Tan(a*Math.PI/180),t=Math.Tan(Math.PI/12),xo=expand?(L*t-w)/(k+t):L,xi=expand?(L*t-w/2)/(k/2+t):L;
   var q=g.Points[name+"OuterEnd"];var z=g.Points[name+"InnerEnd"];
   double nx=-Math.Sin(angle)*sign,ny=Math.Cos(angle)*sign;
   Near("formula",key+name+" outerX",q.X,s.X+xo*Math.Cos(angle)+(w+k*xo)*nx);Near("formula",key+name+" outerY",q.Y,s.Y+xo*Math.Sin(angle)+(w+k*xo)*ny);
   Near("formula",key+name+" innerX",z.X,s.X+xi*Math.Cos(angle)+(w+k*xi)*nx/2);Near("formula",key+name+" innerY",z.Y,s.Y+xi*Math.Sin(angle)+(w+k*xi)*ny/2);
   if(expand)ends.Add(key+","+name+","+q.X.ToString("R")+","+q.Y.ToString("R")+","+z.X.ToString("R")+","+z.Y.ToString("R"));
  }
  if(deg==0&&center&&side==2)for(int i=0;i<f.Written.Count;i++)for(int j=0;j<f.Written[i].Count;j++){var p=f.Written[i][j];output.Add(key+","+i+","+j+","+p.X.ToString("R")+","+p.Y.ToString("R")+","+p.Z.ToString("R"));}
 }
 File.WriteAllLines(Path.Combine(dir,"geometry-points.csv"),output);File.WriteAllLines(Path.Combine(dir,"15-degree-endpoints.csv"),ends);
 }
 static void CustomAndDegenerate(){
 foreach(bool vor in new[]{true,false}){var f=Form(vor);f._0087_0090_009C.Text="3.75 nm";f._0087_0091_0087.Text="4.2";var s=new NavCadPoint(100,200,7);var e=new NavCadPoint(10100,200,9);Draw(f,s,e);var r=f.Written[1];Near("formula","custom label half width "+vor,r[1].Y,200-3.75*1852);Near("formula","custom text angle "+vor,r[2].Y,200-3.75*1852-10000*Math.Tan(4.2*Math.PI/180));}
 // Degenerate arithmetic is preserved. Labels are injected at the E3 boundary, not normal editable UI.
 foreach(double w in new[]{0.0,-2,1})foreach(double a in new[]{0.0,89.9,90,100}){var f=Form();f._0087_0090_009C.Text=w.ToString()+" nm";f._0087_0091_0087.Text=a.ToString();Draw(f,new NavCadPoint(100,200),new NavCadPoint(10100,200));Check("degenerate","no clamp width "+w+" angle"+a,f.WriterCalled,true);Near("degenerate","raw farY "+w+" angle"+a,f.Written[1][2].Y,200-w*1852-10000*Math.Tan(a*Math.PI/180));}
 var q=Form();Draw(q,new NavCadPoint(100,200),new NavCadPoint(100,200));Check("degenerate","same points accepted",q.WriterCalled,true);Check("degenerate","same points lists",q.Written.Count,5);
 q=Form();Draw(q,NavCadPoint.Origin,new NavCadPoint(1,2));Check("degenerate","first origin cancellation",q.WriterCalled,false);Check("degenerate","cancel restores visible",q.Visible,true);Check("degenerate","only one pick consumed",q.Picks.Count,1);
 q=Form();Draw(q,new NavCadPoint(1,2),NavCadPoint.Origin);Check("degenerate","second origin cancellation",q.WriterCalled,false);
 q=Form();q._0087_0091_0087.Text="bad";q._0087_0090_009C.Text="bad nm";Draw(q,new NavCadPoint(100,200),new NavCadPoint(10100,200));Check("degenerate","bad numeric still draws",q.WriterCalled,true);Check("degenerate","both bad numeric messages",q.Messages.Count,2);Near("degenerate","zero substituted width/angle",q.Written[1][2].Y,200);
 q=Form(true,false,false,false,false,true);Draw(q,new NavCadPoint(100,200),new NavCadPoint(10100,200));Check("CAD writer","all output unchecked still writer called",q.WriterCalled,true);Check("CAD writer","all unchecked empty paths",q.Written.Count,0);
 q=Form();q._0087_0090_009C.Checked=false;q._0087_0090_009B.Checked=false;Draw(q,new NavCadPoint(100,200),new NavCadPoint(10100,200));Near("mode/facility dispatch","neither width falls back large label",q.Written[1][1].Y,200-3704);
 q=Form();q._0087_0091_0086.Checked=false;q._0087_0090_009E.Checked=true;Draw(q,new NavCadPoint(100,200),new NavCadPoint(10100,200));Near("mode/facility dispatch","Draw does not read facility radio",q.Written[1][1].Y,200-1852);
 q=Form(true,false,true,true,true,true);Draw(q,new NavCadPoint(100,200),new NavCadPoint(1100,200));Check("degenerate","15cut no longitudinal clamp",q.Written[1][1].X<100,true);
 Near("degenerate","existing divide sentinel positive",ReLine.Divide(1,0),1000000);Near("degenerate","existing divide sentinel zero",ReLine.Divide(0,0),-1000000);
 }
 static void Main(string[] args){CultureInfo.DefaultThreadCurrentCulture=CultureInfo.InvariantCulture;string dir=args[0];try{Dispatch();Matrix(dir);CustomAndDegenerate();File.WriteAllLines(Path.Combine(dir,"assertions.csv"),records);File.WriteAllText(Path.Combine(dir,"numeric-counts.json"),new JavaScriptSerializer().Serialize(counts));foreach(var p in counts)Console.WriteLine("PASS "+p.Key+": "+p.Value);}catch(Exception ex){Console.WriteLine(ex);Environment.ExitCode=1;}}
}
