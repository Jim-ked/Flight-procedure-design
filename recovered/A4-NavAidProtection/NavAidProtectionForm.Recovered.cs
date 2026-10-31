using System;
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
public NavCell _0087_0090_009E=new NavCell();
public NavCell _0087_0091_0086=new NavCell();
public NavCell _0087_0091_0087=new NavCell();
public NavCell _0087_0090_0097=new NavCell();
public NavCell _0087_0090_0098=new NavCell();
public NavCell _0087_0090_0099=new NavCell();
public NavCell _0087_0090_009A=new NavCell();
public NavCell _0087_0090_009B=new NavCell();
public NavCell _0087_0090_009C=new NavCell();
public NavCell _0087_0091_0088=new NavCell();
public NavCell _0087_0090_0096=new NavCell();
public NavCell _0087_0090_009D=new NavCell();
public NavCell _0087_0091_0089=new NavCell();
public NavCell _0087_0091_008A=new NavCell();
public NavAidProtectionForm(){
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
// E1/E2 P2F7: raw 0x060002F8 RVA 0x3DE68; processed RVA 0x33514; source line 22682.
 		public void _0087_0090_008D(object P_0, EventArgs P_1)
 		{

 			if (!_0087_009E())
 			{
 				_0087_0090_009C.Text = "1.0 nm" /* string-offset:3680 */;
 				_0087_0090_009B.Text = "2.0 nm" /* string-offset:3684 */;
 			}
 			_0087_0091_0087.Text = "7.8" /* string-offset:3688 */;
 		}

// E1/E2 P2F8: raw 0x060002F9 RVA 0x3DF28; processed RVA 0x3356C; source line 22693.
 		public void _0087_0090_008E(object P_0, EventArgs P_1)
 		{

 			if (_0087_009D())
 			{
 				_0087_0090_009C.Text = "1.25 nm" /* string-offset:3692 */;
 			}
 			do
 			{
 				_0087_0090_009B.Text = "2.5 nm" /* string-offset:3696 */;
 				_0087_0091_0087.Text = "10.3" /* string-offset:3700 */;
 			}
 			while (_0087_009E());
 		}

// E1/E2 P2F9: raw 0x060002FA RVA 0x3DFF4; processed RVA 0x335CC; source line 22708.
 		public void _0087_0090_008F(object P_0, EventArgs P_1)
 		{
 			RePoint obj = default(RePoint);
 			RePoint obj2 = default(RePoint);
 			RePoint obj3 = default(RePoint);
 			List<List<RePoint>> list2 = default(List<List<RePoint>>);
 			List<RePoint> list = default(List<RePoint>);
 			RePoint obj4 = default(RePoint);
 			RePoint obj5 = default(RePoint);
 			RePoint obj6 = default(RePoint);
 			double num2 = default(double);
 			double num3 = default(double);
 			RePoint obj7 = default(RePoint);
 			double num4 = default(double);
 			double num5 = default(double);
 			double a = default(double);
 			string[] array = default(string[]);
 			RePoint obj8 = default(RePoint);
 			RePoint obj9 = default(RePoint);
 			RePoint obj10 = default(RePoint);
 			ReLine obj11 = default(ReLine);
 			ReLine obj15 = default(ReLine);
 			int num;
 			while (!false /* original-file-bool-offset:452 */)
 			{
 				// P2F6 SetFocus omitted at host boundary (E3).
 				Visible = false;
 				while (true)
 				{
 					NavCadPoint val = Pick("请输入保护区起点" /* string-offset:3704 */);
 					NavCadPoint val2;
 					if (!(val == NavCadPoint.Origin))
 					{
 						val2 = Pick("请指定保护区终点" /* string-offset:3708 */);
 						_0087_009E();
 						if (_0087_009D())
 						{
 							num = 26;
 							goto IL_0517;
 						}
 						num = 29;
 						if (!_0087_009E())
 						{
 							goto IL_0557;
 						}
 						goto IL_07e0;
 					}
 					num = 37;
 					goto IL_0880;
 					IL_0451:
 					list = new List<RePoint>();
 					list.Add(obj);
 					list.Add(obj2);
 					list.Add(obj3);
 					list2.Add(list);
 					goto IL_047c;
 					IL_047c:
 					list = new List<RePoint>();
 					list.Add(obj4);
 					num = 40;
 					goto IL_0495;
 					IL_0495:
 					list.Add(obj5);
 					list2.Add(list);
 					num = 25;
 					goto IL_01c0;
 					IL_01c0:
 					if (_0087_0090_0099.Checked)
 					{
 						obj6 = NavMath.Add(obj, NavMath.Polar(num2, num3 - Math.PI / 2.0));
 						num = 6;
 						if (_0087_009E())
 						{
 							goto IL_02e2;
 						}
 						goto IL_0557;
 					}
 					goto IL_0891;
 					IL_07e0:
 					list.Add(obj7);
 					list2.Add(list);
 					goto IL_06dd;
 					IL_06dd:
 					list = new List<RePoint>();
 					list.Add(obj);
 					num = 22;
 					goto IL_0619;
 					IL_0619:
 					list.Add(obj6);
 					num = 27;
 					if (_0087_009E())
 					{
 						goto IL_0070;
 					}
 					goto IL_0557;
 					IL_0070:
 					num4 = 4.71238898038469 - num3;
 					num = 23;
 					goto IL_0085;
 					IL_0085:
 					num4 = ((num4 >= 0.0) ? num4 : (Math.PI * 2.0 + num4));
 					num4 = ((num4 > Math.PI * 2.0) ? (num4 - Math.PI * 2.0) : num4);
 					num5 = Math.Sqrt(Math.Pow(val.Y - val2.Y, 2.0) + Math.Pow(val.X - val2.X, 2.0));
 					a = _0087_0090_0090(_0087_0091_0087.Text) * _0087_0090_0094;
 					if (_0087_0090_009C.Checked)
 					{
 						array = _0087_0090_009C.Text.Trim().Split('n');
 						num = 17;
 					}
 					else
 					{
 						array = _0087_0090_009B.Text.Trim().Split('n');
 					}
 					goto IL_04e4;
 					IL_0557:
 					switch (num)
 					{
 					case 12:
 						break;
 					case 23:
 						goto IL_0085;
 					case 9:
 						goto IL_017a;
 					case 20:
 						goto IL_018b;
 					case 7:
 						goto IL_019c;
 					case 36:
 						goto IL_01b0;
 					case 25:
 						goto IL_01c0;
 					case 4:
 						goto IL_020c;
 					case 3:
 						goto IL_021c;
 					case 14:
 						goto IL_0233;
 					case 27:
 						list.Add(obj7);
 						list2.Add(list);
 						list = new List<RePoint>();
 						num = 16;
 						if (_0087_009E())
 						{
 							goto IL_047c;
 						}
 						goto case 16;
 					case 28:
 						goto IL_02c1;
 					case 8:
 						goto IL_02e2;
 					case 2:
 						goto IL_0353;
 					case 18:
 						goto IL_038e;
 					default:
 						goto IL_041d;
 					case 21:
 						goto IL_0424;
 					case 41:
 						goto IL_0436;
 					case 42:
 						goto IL_0448;
 					case 24:
 						goto IL_047c;
 					case 40:
 						goto IL_0495;
 					case 43:
 						goto IL_04b5;
 					case 17:
 						goto IL_04e4;
 					case 5:
 					case 26:
 						goto IL_0517;
 					case 22:
 						goto IL_0619;
 					case 6:
 						obj8 = NavMath.Add(obj, NavMath.Polar(num2 / 2.0, num3 - Math.PI / 2.0));
 						obj7 = NavMath.Add(obj9, NavMath.Polar(num5 * Math.Tan(a) + num2, num3 - Math.PI / 2.0));
 						goto case 29;
 					case 29:
 					case 30:
 						obj10 = NavMath.Add(obj9, NavMath.Polar((num5 * Math.Tan(a) + num2) / 2.0, num3 - Math.PI / 2.0));
 						if (!_0087_0090_0098.Checked)
 						{
 							goto IL_06dd;
 						}
 						goto case 33;
 					case 33:
 						obj11 = new ReLine();
 						num = 11;
 						goto case 11;
 					case 11:
 					{
 						ReLine obj12 = new ReLine();
 						obj11.Set(obj8, obj10);
 						obj12.Set(obj6, obj7);
 						ReLine obj13 = new ReLine();
 						obj13.Through(obj9, num3 + Math.PI - 15.0 * _0087_0090_0094);
 						obj10 = obj11.Intersection(obj13);
 						obj7 = obj12.Intersection(obj13);
 						num = 0;
 						goto case 0;
 					}
 					case 0:
 						list = new List<RePoint>();
 						num = 39;
 						goto case 39;
 					case 39:
 						list.Add(obj9);
 						num = 32;
 						goto IL_07e0;
 					case 32:
 						goto IL_07e0;
 					case 31:
 						continue;
 					case 15:
 						goto end_IL_07f7;
 					case 16:
 						list.Add(obj8);
 						num = 1;
 						goto case 1;
 					case 1:
 						list.Add(obj10);
 						num = 10;
 						goto case 10;
 					case 10:
 						list2.Add(list);
 						goto IL_0891;
 					case 35:
 						goto IL_0878;
 					case 37:
 						goto IL_0880;
 					case 38:
 						return;
 					case 19:
 						goto IL_0891;
 					case 13:
 					case 44:
 						return;
 					}
 					goto IL_0070;
 					IL_0880:
 					Visible = true;
 					num = 38;
 					return;
 					IL_0436:
 					list.Add(obj3);
 					num = 42;
 					goto IL_0448;
 					IL_0448:
 					list2.Add(list);
 					goto IL_0451;
 					IL_0891:
 					Written = list2; WriterCalled = true; // P087 captured, not executed.
 					return;
 					IL_0517:
 					if (!(val2 == NavCadPoint.Origin))
 					{
 						Visible = true;
 						num3 = Math.Atan2(val.Y - val2.Y, val.X - val2.X);
 						goto IL_0070;
 					}
 					num = 35;
 					goto IL_0878;
 					IL_0878:
 					Visible = true;
 					return;
 					IL_038e:
 					ReLine obj14 = new ReLine();
 					obj15.Set(obj4, obj5);
 					obj14.Set(obj2, obj3);
 					ReLine obj16 = new ReLine();
 					obj16.Through(obj9, num3 + Math.PI + 15.0 * _0087_0090_0094);
 					obj5 = obj15.Intersection(obj16);
 					obj3 = obj14.Intersection(obj16);
 					goto IL_041d;
 					IL_04e4:
 					num2 = Parse(array[0], "输入数据有误，请检查。" /* string-offset:1984 */) * 1852.0;
 					num = 9;
 					goto IL_017a;
 					IL_017a:
 					obj = val.ToRecovered();
 					num = 20;
 					goto IL_018b;
 					IL_018b:
 					obj9 = val2.ToRecovered();
 					num = 7;
 					goto IL_019c;
 					IL_019c:
 					list2 = new List<List<RePoint>>();
 					if (!_0087_0090_0097.Checked)
 					{
 						goto IL_01b0;
 					}
 					goto IL_020c;
 					IL_020c:
 					list = new List<RePoint>();
 					num = 3;
 					goto IL_021c;
 					IL_021c:
 					list.Add(obj);
 					num = 28;
 					goto IL_02c1;
 					IL_02c1:
 					list.Add(obj9);
 					num = 43;
 					if (_0087_009E())
 					{
 						goto IL_0495;
 					}
 					goto IL_04b5;
 					IL_04b5:
 					list2.Add(list);
 					num = 36;
 					if (!_0087_009E())
 					{
 						goto IL_01b0;
 					}
 					goto IL_0880;
 					IL_01b0:
 					if (!_0087_0090_0096.Checked)
 					{
 						goto IL_01c0;
 					}
 					num = 14;
 					goto IL_0233;
 					IL_041d:
 					list = new List<RePoint>();
 					goto IL_0424;
 					IL_0233:
 					obj2 = NavMath.Add(obj, NavMath.Polar(num2, num3 + Math.PI / 2.0));
 					obj4 = NavMath.Add(obj, NavMath.Polar(num2 / 2.0, num3 + Math.PI / 2.0));
 					num = 8;
 					goto IL_02e2;
 					IL_02e2:
 					obj3 = NavMath.Add(obj9, NavMath.Polar(num5 * Math.Tan(a) + num2, num3 + Math.PI / 2.0));
 					obj5 = NavMath.Add(obj9, NavMath.Polar((num5 * Math.Tan(a) + num2) / 2.0, num3 + Math.PI / 2.0));
 					num = 2;
 					goto IL_0353;
 					IL_0353:
 					if (_0087_0090_0098.Checked)
 					{
 						obj15 = new ReLine();
 						num = 18;
 						goto IL_038e;
 					}
 					goto IL_0451;
 					IL_0424:
 					list.Add(obj9);
 					num = 41;
 					goto IL_0436;
 					continue;
 					end_IL_07f7:
 					break;
 				}
 			}
 			num = 13;
 		}

// E1/E2 P2FA: raw 0x060002FB RVA 0x3E938; processed RVA 0x33E7C; source line 23078.
 		public double _0087_0090_0090(string P_0)
 		{
 			try
 			{
 				return Parse(P_0, "输入数据有误，请检查。" /* string-offset:1984 */);
 			}
 			catch
 			{
 				Alert("数据 " /* string-offset:3712 */ + P_0 + " 输入有误，将以零代替。" /* string-offset:3716 */);
 				return 0.0;
 			}
 		}
}
}
