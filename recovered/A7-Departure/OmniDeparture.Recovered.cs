using System;
using System.Collections.Generic;
// Constructor Original MethodDef: 0x06000421; Original RVA: 0x65960.
// Evaluator Original MethodDef: 0x06000422; Original RVA: 0x65E14.
// Evidence: _008A_0095.source.txt:42815-43535 + processed420/421/422 IL.
// Evaluator is mechanically renamed, retaining all goto labels and original predicates.
public sealed class OmniDepartureRecovered {
 double _0088_0092_0087=150,_0088_0092_008B,_0088_0092_008E,_0088_0092_0090,_0088_0092_0091;
 RePoint _0088_0092_0093,_0088_0092_0094,_0088_0092_0095,_0088_0092_0096,_0088_0092_0097;
 ReLine _0088_0092_0098,_0088_0092_0099,_0088_0092_009A,_0088_0092_009B;
 public RePoint S {get{return _0088_0092_0093;}} public RePoint K {get{return _0088_0092_0095;}} public RePoint F {get{return _0088_0092_0096;}}
 public double Radius {get{return _0088_0092_008B;}}
 public List<List<RePoint>> Boundaries=new List<List<RePoint>>();
 public OmniDepartureRecovered(DepartureRunway runway,double baseAltitude,double tna,double finalAltitude,double gradient=.033,bool early=true) {
  _0088_0092_0090=baseAltitude;_0088_0092_0091=tna;_0088_0092_008E=gradient;
  double d1=115/gradient,d2=(tna-baseAltitude-120)/gradient;
  _0088_0092_0093=new RePoint(-runway.Length+600,150,baseAltitude+5);
  _0088_0092_0094=new RePoint(0,150,baseAltitude+5);
  _0088_0092_0095=new RePoint(d1,150+d1*Math.Tan(Math.PI/12),baseAltitude+120);
  _0088_0092_0096=new RePoint(d1+d2,K.Y+d2*Math.Tan(Math.PI/6),tna);
  _0088_0092_0098=new ReLine(S,_0088_0092_0094);_0088_0092_0099=new ReLine(_0088_0092_0094,K);_0088_0092_009A=new ReLine(K,F);
  _0088_0092_009B=new ReLine();_0088_0092_009B.Through(F,_0088_0092_009A.Angle()+Math.PI/2);
  _0088_0092_0097=new RePoint(S.X,_0088_0092_009B.Y(S.X));
  _0088_0092_008B=F.X-S.X+(finalAltitude-tna)/gradient;
  Add(_0088_0092_0094,K);Add(K,F);if(early)Add(S,_0088_0092_0094);
 }
 // Boundary builder Original MethodDef: 0x06000423; Original RVA: 0x66DEC.
 void Add(RePoint a,RePoint b){var list=RePoint.Symmetric(a,b);for(int i=0;i<list.Count;i++)list[i]=RePoint.ZeroZ(list[i]);Boundaries.Add(list);}
 static bool TrueHelper(){return true;}static bool FalseHelper(){return false;}
		public DepartureEvaluation Evaluate(RePoint input)
		{
 var P_0=new DepartureEvaluation(input);
			double num3 = default(double);
			double num4 = default(double);
			double num5 = default(double);
			double num6 = default(double);
			RePoint obj5 = default(RePoint);
			double num7 = default(double);
			while (true)
			{
				int num;
				if (!false /* original-file-bool-offset:800 */)
				{
					P_0.Area = "out" /* string-offset:1556 */;
					num = 0;
					if (!TrueHelper())
					{
						goto IL_0499;
					}
					goto IL_05f9;
				}
				num = 30;
				goto IL_0964;
				IL_03be:
				if (P_0.X < 0.0 && P_0.X > _0088_0092_0093.X)
				{
					num = 50;
					goto IL_03eb;
				}
				goto IL_03f7;
				IL_0e2b:
				P_0.OCA = P_0.Z + P_0.MOC;
				num = 47;
				goto IL_0e47;
				IL_05f9:
				P_0.OCA = 0.0;
				double num2;
				if (P_0.Y > 0.0)
				{
					num2 = P_0.Y;
					goto IL_05b6;
				}
				num = 58;
				goto IL_05af;
				IL_0e47:
				P_0.AllowableAltitude = _0088_0092_0091 + P_0.D0 * _0088_0092_008E;
				goto IL_0e61;
				IL_03eb:
				if (num3 > _0088_0092_0087)
				{
					goto IL_03f7;
				}
				num = 42;
				goto IL_08bd;
				IL_05b6:
				num3 = num2;
				RePoint obj = new RePoint(_0088_0092_0093.X, 0.0);
				if (!(RePoint.Distance(P_0, obj) > _0088_0092_008B))
				{
					if (P_0.X <= _0088_0092_0093.X && num3 <= _0088_0092_0093.Y)
					{
						num = 5;
						goto IL_023a;
					}
					if (P_0.X >= _0088_0092_0096.X)
					{
						num = 46;
						goto IL_0171;
					}
					goto IL_0597;
				}
				num = 60;
				goto IL_0a36;
				IL_0e61:
				P_0.RequiredGradient = (P_0.OCA - _0088_0092_0091) / P_0.D0;
				num = 69;
				break;
				IL_08bd:
				P_0.Dr = 0.0;
				P_0.D0 = 0.0;
				P_0.MOC = 75.0;
				goto IL_0964;
				IL_0a38:
				P_0.AllowableAltitude = _0088_0092_0091;
				num = 2;
				goto IL_0a4d;
				IL_0a4d:
				P_0.RequiredGradient = 0.0;
				P_0.Area = "1区跑道内区域" /* string-offset:5516 */;
				num = 35;
				goto IL_0a75;
				IL_0964:
				P_0.OCA = P_0.Z + P_0.MOC;
				goto IL_0a38;
				IL_0a75:
				if (!(P_0.OCA > _0088_0092_0091))
				{
					break;
				}
				goto IL_0a86;
				IL_0597:
				if (!(P_0.X < _0088_0092_0093.X) || !(num3 < _0088_0092_0097.Y))
				{
					if (!(P_0.X >= _0088_0092_0096.X))
					{
						if (P_0.X > _0088_0092_0097.X)
						{
							num = 52;
							goto IL_0383;
						}
						goto IL_039a;
					}
					goto IL_056e;
				}
				num = 4;
				goto IL_06be;
				IL_03f7:
				if (!(P_0.X >= _0088_0092_0094.X))
				{
					goto IL_043e;
				}
				num = 7;
				if (!FalseHelper())
				{
					goto IL_0484;
				}
				goto IL_08ec;
				IL_0e86:
				P_0.OCA = P_0.Z + P_0.MOC;
				P_0.AllowableAltitude = _0088_0092_0091 + P_0.D0 * _0088_0092_008E;
				P_0.RequiredGradient = (P_0.OCA - _0088_0092_0091) / P_0.D0;
				num = 45;
				break;
				IL_0a86:
				P_0.Area = P_0.Area + "  转弯高度设定偏低" /* string-offset:5520 */;
				break;
				IL_08ec:
				P_0.RequiredGradient = (P_0.OCA - _0088_0092_0090 - 5.0) / P_0.Dr;
				P_0.Area = "2区" /* string-offset:5528 */;
				num = 31;
				goto IL_0929;
				IL_0929:
				if (P_0.Z + 75.0 > _0088_0092_0091)
				{
					P_0.Area = P_0.Area + "  转弯高度设定偏低" /* string-offset:5520 */;
				}
				break;
				IL_056e:
				P_0.Dr = _0088_0092_0096.X;
				goto IL_0512;
				IL_0512:
				P_0.D0 = RePoint.Distance(new RePoint(P_0.X, num3), _0088_0092_0096);
				P_0.MOC = Math.Max((P_0.D0 + P_0.Dr) * 0.008, 75.0);
				goto IL_04f4;
				IL_04f4:
				P_0.OCA = P_0.Z + P_0.MOC;
				num = 38;
				goto IL_04be;
				IL_04be:
				P_0.AllowableAltitude = _0088_0092_0091 + P_0.D0 * _0088_0092_008E;
				P_0.RequiredGradient = (P_0.OCA - _0088_0092_0091) / P_0.D0;
				goto IL_0499;
				IL_0499:
				P_0.Area = "3区跑道侧方C5区域" /* string-offset:5512 */;
				num = 11;
				if (TrueHelper())
				{
					break;
				}
				goto IL_0484;
				IL_0484:
				if (!(P_0.X <= _0088_0092_0095.X) || !(num3 <= _0088_0092_0099.Y(P_0.X)))
				{
					goto IL_043e;
				}
				P_0.Dr = P_0.X;
				num = 1;
				goto IL_0694;
				IL_0986:
				P_0.RequiredGradient = (P_0.OCA - _0088_0092_0091) / P_0.D0;
				goto IL_09a0;
				IL_01bd:
				P_0.MOC = Math.Max(P_0.X * 0.008, 75.0);
				P_0.OCA = P_0.Z + P_0.MOC;
				goto IL_012a;
				IL_043e:
				if (!(P_0.X >= _0088_0092_0095.X) || !(P_0.X <= _0088_0092_0096.X) || !(num3 <= _0088_0092_009A.Y(P_0.X)))
				{
					num4 = _0088_0092_0098.Distance(new RePoint(P_0.X, num3));
					num = 59;
					if (!FalseHelper())
					{
						goto IL_025d;
					}
					goto IL_0e86;
				}
				P_0.Dr = P_0.X;
				P_0.D0 = 0.0;
				num = 51;
				goto IL_075d;
				IL_01f9:
				P_0.Dr = 0.0;
				P_0.MOC = Math.Max(P_0.D0 * 0.008, 75.0);
				num = 49;
				goto IL_015c;
				IL_0171:
				if (num3 <= _0088_0092_0096.Y)
				{
					P_0.D0 = P_0.X - _0088_0092_0096.X;
					num = 22;
					goto IL_01a3;
				}
				goto IL_0597;
				IL_09a0:
				P_0.Area = "早转弯前的直线段" /* string-offset:5500 */;
				break;
				IL_023a:
				P_0.D0 = _0088_0092_0093.X - P_0.X;
				num = 23;
				goto IL_01f9;
				IL_025d:
				switch (num)
				{
				case 55:
					break;
				case 14:
				case 36:
					goto IL_012a;
				case 49:
					goto IL_015c;
				case 46:
					goto IL_0171;
				case 22:
					goto IL_01a3;
				case 43:
					goto IL_01bd;
				case 23:
					goto IL_01f9;
				case 5:
					goto IL_023a;
				case 52:
					goto IL_0383;
				case 10:
					goto IL_03ad;
				case 50:
					goto IL_03eb;
				case 7:
					goto IL_0484;
				case 32:
					goto IL_0499;
				case 38:
					goto IL_04be;
				case 40:
					goto IL_04f4;
				case 53:
					goto IL_0512;
				case 61:
					goto IL_056e;
				case 58:
					goto IL_05af;
				case 0:
					goto IL_05f9;
				case 16:
					continue;
				case 1:
					goto IL_0694;
				case 4:
					goto IL_06be;
				case 26:
					P_0.RequiredGradient = (P_0.OCA - _0088_0092_0091) / P_0.D0;
					P_0.Area = "3区直线段" /* string-offset:5504 */;
					num = 64;
					goto end_IL_061e;
				case 51:
					goto IL_075d;
				case 33:
					goto IL_077c;
				case 17:
					goto IL_07c1;
				case 48:
					goto IL_07fc;
				case 42:
					goto IL_08bd;
				case 12:
					goto IL_08ec;
				case 31:
					goto IL_0929;
				default:
					goto IL_0964;
				case 9:
				case 20:
					goto IL_0986;
				case 3:
					goto IL_09a0;
				case 56:
					goto IL_09b5;
				case 59:
					num5 = _0088_0092_0099.Distance(new RePoint(P_0.X, num3));
					num6 = _0088_0092_009A.Distance(new RePoint(P_0.X, num3));
					goto case 67;
				case 60:
					goto IL_0a36;
				case 62:
					goto IL_0a38;
				case 2:
					goto IL_0a4d;
				case 35:
					goto IL_0a75;
				case 15:
					goto IL_0a86;
				case 63:
					goto IL_0aa6;
				case 37:
					goto IL_0ac2;
				case 28:
					goto IL_0b13;
				case 41:
					goto IL_0b36;
				case 65:
					goto IL_0b71;
				case 8:
					goto IL_0b8d;
				case 67:
					P_0.D0 = Math.Min(Math.Min(num4, num5), num6);
					num = 6;
					goto case 6;
				case 6:
				{
					if (P_0.D0 == num4)
					{
						num = 39;
						goto case 39;
					}
					if (P_0.D0 == num5)
					{
						goto case 13;
					}
					if (P_0.D0 != num6)
					{
						goto end_IL_061e;
					}
					ReLine obj2 = new ReLine();
					obj2.Through(new RePoint(P_0.X, num3), _0088_0092_009A.Angle() + Math.PI / 2.0);
					RePoint obj3 = obj2.Intersection(_0088_0092_009A);
					P_0.Dr = obj3.X;
					P_0.Area = "3区跑道外侧C4区域" /* string-offset:5540 */;
					goto IL_0e00;
				}
				case 39:
					P_0.Dr = 0.0;
					goto IL_0c17;
				case 18:
					goto IL_0c17;
				case 21:
					goto IL_0c27;
				case 13:
				{
					ReLine obj4 = new ReLine();
					obj4.Through(new RePoint(P_0.X, num3), _0088_0092_0099.Angle() + Math.PI / 2.0);
					obj5 = obj4.Intersection(_0088_0092_0099);
					num = 19;
					goto case 19;
				}
				case 19:
					P_0.Dr = obj5.X;
					P_0.Area = "3区跑道外侧C3区域" /* string-offset:5536 */;
					goto case 44;
				case 44:
					P_0.MOC = Math.Max((P_0.D0 + P_0.Dr) * 0.008, 75.0);
					num = 57;
					goto case 57;
				case 57:
					P_0.OCA = P_0.Z + P_0.MOC;
					num = 34;
					goto case 34;
				case 34:
					P_0.AllowableAltitude = _0088_0092_0091 + P_0.D0 * _0088_0092_008E;
					goto case 27;
				case 27:
					P_0.RequiredGradient = (P_0.OCA - _0088_0092_0091) / P_0.D0;
					goto end_IL_061e;
				case 68:
					goto IL_0e00;
				case 24:
					goto IL_0e2b;
				case 47:
					goto IL_0e47;
				case 29:
					goto IL_0e61;
				case 66:
					goto IL_0e86;
				case 11:
				case 25:
				case 45:
				case 64:
				case 69:
					goto end_IL_061e;
				}
				goto IL_0100;
				IL_0a36:
				return P_0;
				IL_075d:
				P_0.MOC = P_0.Dr * 0.008;
				num = 33;
				goto IL_077c;
				IL_077c:
				P_0.OCA = P_0.Z + P_0.MOC;
				P_0.AllowableAltitude = _0088_0092_0090 + 5.0 + P_0.Dr * _0088_0092_008E;
				goto IL_08ec;
				IL_06be:
				P_0.D0 = RePoint.Distance(new RePoint(P_0.X, num3), _0088_0092_0093);
				P_0.Dr = 0.0;
				P_0.MOC = Math.Max(P_0.D0 * 0.008, 75.0);
				num = 65;
				goto IL_0b71;
				IL_0b71:
				P_0.OCA = P_0.Z + P_0.MOC;
				num = 8;
				goto IL_0b8d;
				IL_0b8d:
				P_0.AllowableAltitude = _0088_0092_0091 + P_0.D0 * _0088_0092_008E;
				P_0.RequiredGradient = (P_0.OCA - _0088_0092_0091) / P_0.D0;
				P_0.Area = "3区跑道侧方C1区域" /* string-offset:5508 */;
				break;
				IL_0694:
				P_0.D0 = 0.0;
				P_0.MOC = P_0.Dr * 0.008;
				goto IL_0aa6;
				IL_0aa6:
				P_0.OCA = P_0.Z + P_0.MOC;
				num = 37;
				goto IL_0ac2;
				IL_0ac2:
				P_0.AllowableAltitude = _0088_0092_0090 + 5.0 + P_0.Dr * _0088_0092_008E;
				P_0.RequiredGradient = (P_0.OCA - _0088_0092_0090 - 5.0) / P_0.Dr;
				num = 28;
				goto IL_0b13;
				IL_0b13:
				P_0.Area = "1区" /* string-offset:5524 */;
				num = 41;
				if (TrueHelper())
				{
					goto IL_0b36;
				}
				goto IL_0c17;
				IL_0b36:
				if (P_0.Z + 75.0 > _0088_0092_0091)
				{
					P_0.Area = P_0.Area + "  转弯高度设定偏低" /* string-offset:5520 */;
				}
				break;
				IL_01a3:
				P_0.Dr = _0088_0092_0096.X;
				num = 43;
				goto IL_01bd;
				IL_0c17:
				P_0.Area = "3区跑道外侧C2区域" /* string-offset:5532 */;
				goto IL_0c27;
				IL_0c27:
				P_0.MOC = Math.Max((P_0.D0 + P_0.Dr) * 0.008, 75.0);
				num = 66;
				goto IL_0e86;
				IL_05af:
				num2 = 0.0 - P_0.Y;
				goto IL_05b6;
				IL_0383:
				if (num3 <= _0088_0092_009B.Y(P_0.X))
				{
					goto IL_039a;
				}
				num = 61;
				goto IL_056e;
				IL_039a:
				if (P_0.X < _0088_0092_0097.X)
				{
					goto IL_03ad;
				}
				goto IL_03be;
				IL_03ad:
				if (num3 <= _0088_0092_0097.Y)
				{
					goto IL_03be;
				}
				num = 17;
				goto IL_07c1;
				IL_015c:
				P_0.OCA = P_0.Z + P_0.MOC;
				goto IL_0100;
				IL_07c1:
				P_0.Dr = _0088_0092_0096.X;
				num7 = RePoint.Distance(new RePoint(P_0.X, num3), _0088_0092_0093);
				num = 48;
				goto IL_07fc;
				IL_07fc:
				double num8 = RePoint.Distance(new RePoint(P_0.X, num3), _0088_0092_0096);
				P_0.D0 = Math.Min(num7, num8);
				P_0.MOC = (num7 > num8) ? Math.Max((P_0.D0 + P_0.Dr) * 0.008, 75.0) : Math.Max(P_0.D0 * 0.008, 75.0);
				P_0.OCA = P_0.Z + P_0.MOC;
				P_0.AllowableAltitude = _0088_0092_0091 + P_0.D0 * _0088_0092_008E;
				num = 56;
				goto IL_09b5;
				IL_012a:
				P_0.AllowableAltitude = _0088_0092_0091 + P_0.D0 * _0088_0092_008E;
				num = 26;
				if (!FalseHelper())
				{
					goto IL_025d;
				}
				goto IL_0e00;
				IL_0e00:
				P_0.MOC = Math.Max((P_0.D0 + P_0.Dr) * 0.008, 75.0);
				goto IL_0e2b;
				IL_0100:
				P_0.AllowableAltitude = _0088_0092_0091 + P_0.D0 * _0088_0092_008E;
				TrueHelper();
				if (FalseHelper())
				{
					goto IL_012a;
				}
				num = 20;
				goto IL_0986;
				IL_09b5:
				P_0.RequiredGradient = (P_0.OCA - _0088_0092_0091) / P_0.D0;
				P_0.Area = "3区跑道侧方C1区域" /* string-offset:5508 */;
				num = 25;
				break;
				continue;
				end_IL_061e:
				break;
			}
			return P_0;
		}

}
