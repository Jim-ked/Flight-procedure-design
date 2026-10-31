"""Mechanically adapted P2F9 and state handlers; all target host operations isolated."""
from pathlib import Path
import re,csv
ROOT=Path(__file__).resolve().parents[2];A=ROOT/'recovered/A4-NavAidProtection';E=A/'evidence'
def rows(p):return list(csv.DictReader(p.open(encoding='utf-8-sig')))
ms={m['processed_token']:m for m in rows(E/'method-index.csv')}
def method(token):
 t='0x06000'+token;m=ms[t];p=E/'methods'/(t+'.source.txt');s='\n'.join(l.split(':',1)[1] for l in p.read_text(encoding='utf-8').splitlines())
 s=re.sub(r'\s*//IL_[^\n]*','',s);s=re.sub(r'^\s*_ = [^;]+;','',s,flags=re.M)
 s=s.replace('private ','public ',1).replace('base.Visible','Visible')
 s=s.replace('_0087_0090_008C(Application.DocumentManager.MdiActiveDocument.Window.Handle);','// P2F6 SetFocus omitted at host boundary (E3).')
 s=s.replace('Point3d','NavCadPoint').replace('((NavCadPoint)(ref val)).','val.').replace('((NavCadPoint)(ref val2)).','val2.')
 s=s.replace('_009D._008B_008D','Pick').replace('._008B_009C()','.ToRecovered()')
 s=s.replace('_008B._0088_008B(HostApplicationServices.WorkingDatabase, list2);','Written = list2; WriterCalled = true; // P087 captured, not executed.')
 s=s.replace('_008F_008E._008B_0089_0087','NavMath.Polar').replace('_008F_008E._008B_0089_0088','NavMath.Add')
 s=s.replace('_008F_008E','RePoint').replace('_008F_008C','ReLine').replace('._008B_0088_008E(','.Set(').replace('._008B_0088_008F(','.Through(').replace('._008B_0088_0093(','.Intersection(')
 s=s.replace('_008F_008A._008B_0087_009D','Parse').replace('Application.ShowAlertDialog','Alert')
 return f'// E1/E2 P{token}: raw {m["original_token"]} RVA {m["original_rva"]}; processed RVA {m["processed_rva"]}; source line {m["line"]}.\n'+s+'\n'
fields=[c['field'] for c in rows(E/'controls.csv') if c['field']!='base']
prefix='''using System;
using System.Collections.Generic;
namespace Recovered.A4 {
// E3 host adapter. No target/AutoCAD/WinForms runtime loaded.
public class NavCell { public string Text=""; public bool Checked,Enabled=true; }
public struct NavCadPoint {
 public double X,Y,Z; public NavCadPoint(double x,double y,double z=0){X=x;Y=y;Z=z;}
 public static NavCadPoint Origin {get{return new NavCadPoint();}}
 public static bool operator ==(NavCadPoint a,NavCadPoint b){return a.X==b.X&&a.Y==b.Y&&a.Z==b.Z;}
 public static bool operator !=(NavCadPoint a,NavCadPoint b){return !(a==b);}
 public override bool Equals(object o){return o is NavCadPoint && this==(NavCadPoint)o;}
 public override int GetHashCode(){return X.GetHashCode()^Y.GetHashCode()^Z.GetHashCode();}
 public RePoint ToRecovered(){return new RePoint(X,Y,Z);}
}
public static class NavMath {
 public static RePoint Polar(double d,double a){return new RePoint(d*Math.Cos(a),d*Math.Sin(a));}
 public static RePoint Add(RePoint a,RePoint b){return new RePoint(a.X+b.X,a.Y+b.Y,a.Z+b.Z);}
}
public class NavAidProtectionForm {
 public bool Visible=true,WriterCalled; public Queue<NavCadPoint> Picks=new Queue<NavCadPoint>();
 public List<string> Prompts=new List<string>(),Messages=new List<string>();
 public List<List<RePoint>> Written=new List<List<RePoint>>();
 static double _0087_0090_0094=Math.PI/180; // P2FF constant, license check excluded from E3
 public NavCadPoint Pick(string prompt){Prompts.Add(prompt);return Picks.Dequeue();}
 public void Alert(string s){Messages.Add(s);}
 public double Parse(string s,string message="输入数据有误，请检查。") {try{return Convert.ToDouble(s);}catch{Messages.Add(s+" "+message);return 0;}}
 static bool _0087_009D(){return true;} // P300
 static bool _0087_009E(){return false;} // P301
'''
prefix+='\n'.join('public NavCell '+f+'=new NavCell();' for f in fields)+'\n'
prefix+='''public NavAidProtectionForm(){
 _0087_0091_0086.Checked=true; _0087_0090_009C.Checked=true;
 _0087_0090_0096.Checked=true;_0087_0090_0099.Checked=true;_0087_0090_0097.Checked=true;
 _0087_0090_009C.Text="1.0 nm";_0087_0090_009B.Text="2.0 nm";_0087_0091_0087.Text="7.8";_0087_0091_0087.Enabled=false;
}
// E3 convenience to deliver both real CheckedChanged handlers in supplied order.
// No event handler checks its sender's Checked property. Test transition order explicitly.
public void SetFacility(bool vor){
 if(_0087_0091_0086.Checked==vor)return;
 _0087_0091_0086.Checked=vor;_0087_0090_009E.Checked=!vor;
 if(vor){_0087_0090_008E(null,EventArgs.Empty);_0087_0090_008D(null,EventArgs.Empty);}
 else{_0087_0090_008D(null,EventArgs.Empty);_0087_0090_008E(null,EventArgs.Empty);}
}
'''
(A/'NavAidProtectionForm.Recovered.cs').write_text(prefix+'\n'.join(method(t) for t in ['2F7','2F8','2F9','2FA'])+'}\n}\n',encoding='utf-8')
print('mechanical Form slice written; source expressions preserved; helper math reused')
