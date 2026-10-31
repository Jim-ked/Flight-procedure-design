using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Recovered.A6;
using Recovered.B5;
using Recovered.B4;
// E1/E2 extraction. Only independent source, no target DLL or CAD execution.
namespace Recovered.A5 {
	public class PaOasGeometry
	{
		public TemplatePoint _0088_0093_0090;

		public TemplatePoint _0088_0093_0091;

		public TemplatePoint _0088_0093_0092;

		public TemplatePoint _0088_0093_0093;

		public TemplatePoint _0088_0093_0094;

		public TemplatePoint _0088_0093_0095;

		public TemplatePoint _0088_0093_0096;

		public TemplatePoint _0088_0093_0097;

		public TemplatePoint _0088_0093_0098;

		public TemplatePoint _0088_0093_0099;

		public TemplatePoint _0088_0093_009A;

		public TemplatePoint _0088_0093_009B;

		public TemplatePoint _0088_0093_009C;

		public TemplatePoint _0088_0093_009D;

		public LineCarrier _0088_0093_009E;

		public LineCarrier _0088_0094_0086;

		public LineCarrier _0088_0094_0087;

		public LineCarrier _0088_0094_0088;

		public LineCarrier _0088_0094_0089;

		public LineCarrier _0088_0094_008A;

		public PlaneCarrier _0088_0094_008B;

		public PlaneCarrier _0088_0094_008C;

		public PlaneCarrier _0088_0094_008D;

		public PlaneCarrier _0088_0094_008E;

		public PlaneCarrier _0088_0094_008F;

		public PlaneCarrier _0088_0094_0090;

		public int _0088_0094_0091;

		public List<List<TemplatePoint>> _0088_0094_0092;

		public List<List<TemplatePoint>> _0088_0094_0093;

		// R8 MethodDef: original 0x06000427 RVA 0x66F6C; processed 0x06000426 RVA 0x5479C; source 03_recovered-src/annotated-strings/--/--.cs:43616; processed IL recovery, not original runtime.
public PaOasGeometry(double P_0 = 0.0524)
		{

			_0088_0086();
			if (_0087z())
			{
				if (true /* original-file-bool-offset:804 */)
				{
					_0088_0094_0091 = 300;
					goto IL_002f;
				}
				return;
			}
			goto IL_00e1;
			IL_002f:
			// implicit object constructor
			_0088_0094_008B = new PlaneCarrier(0.0285, 0.0, -8.01);
			_0088_0094_008C = new PlaneCarrier(0.027681, 0.1825, -16.72);
			_0088_0094_008D = new PlaneCarrier(0.023948, 0.210054, -21.51);
			_0088_0094_008E = new PlaneCarrier(-0.025, 0.0, -22.5);
			goto IL_00e1;
			IL_00e1:
			_0088_0094_008F = new PlaneCarrier(P_0, 0.091, 5.0);
			_0088_0094_0090 = new PlaneCarrier(0.0, 0.091, 15.0);
			_0088_0092_009D();
			if (!_0088_0086())
			{
				return;
			}
			goto IL_002f;
		}

		// R8 MethodDef: original 0x06000428 RVA 0x6716C; processed 0x06000427 RVA 0x548E8; source 03_recovered-src/annotated-strings/--/--.cs:43647; processed IL recovery, not original runtime.
public PaOasGeometry(OasModel P_0, double P_1 = 0.0524)
		{

			_0088_0086();
			if (_0087z())
			{
				_0088_0094_0091 = 300;
				// implicit object constructor
				_0088_0094_008B = P_0._0088_0091_0096;
				if (_0087z())
				{
					_0088_0094_008C = P_0._0088_0091_0098;
					_0088_0094_008D = P_0._0088_0091_0099;
					if (!_0087z())
					{
						goto IL_00b0;
					}
					_0088_0094_008E = P_0._0088_0091_009A;
				}
				_0088_0094_008F = new PlaneCarrier(P_1, 0.091, 5.0);
				_0088_0094_0090 = new PlaneCarrier(0.0, 0.091, 15.0);
			}
			goto IL_00b0;
			IL_00b0:
			_0088_0092_009D();
		}

		// R8 MethodDef: original 0x06000429 RVA 0x672F4; processed 0x06000428 RVA 0x549AC; source 03_recovered-src\annotated-strings\--\--.cs:43673; processed IL recovery, not original runtime.
public void _0088_0092_009D()
		{
			int num = default(int); // IL InitLocals
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			LineCarrier obj2 = default(LineCarrier); // IL InitLocals
			LineCarrier obj3 = default(LineCarrier); // IL InitLocals
			LineCarrier obj4 = default(LineCarrier); // IL InitLocals
			LineCarrier obj5 = default(LineCarrier); // IL InitLocals
			LineCarrier obj6 = default(LineCarrier); // IL InitLocals

			num = 11;
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				IL_054d:
				if (!false /* original-file-bool-offset:808 */)
				{
					_0088_0094_0092 = new List<List<TemplatePoint>>();
					num = 16;
					if (!_0088_0086())
					{
						goto IL_0404;
					}
					goto IL_0534;
				}
				num = 25;
				return;
				IL_0612:
				list.Add(new TemplatePoint(_0088_0093_0090.X, 0.0));
				goto IL_063b;
				IL_063b:
				_0088_0094_0092.Add(list);
				break;
				IL_0534:
				_0088_0093_0092 = obj._008B_0088_0093(obj2);
				num = 21;
				goto IL_0524;
				IL_0524:
				_0088_0093_0099 = obj2._008B_0088_0093(obj3);
				goto IL_04f7;
				IL_04f7:
				_0088_0093_009D = obj4._008B_0088_0093(obj3);
				_0088_0093_0092.Z = 600.0;
				num = 17;
				goto IL_04ce;
				IL_04ce:
				_0088_0093_0099.Z = 600.0;
				num = 15;
				if (_0087z())
				{
					goto IL_04a2;
				}
				goto IL_058e;
				IL_04a2:
				_0088_0093_009D.Z = 600.0;
				num = 12;
				if (!_0088_0086())
				{
					goto IL_0404;
				}
				goto IL_05ae;
				IL_0404:
				while (true)
				{
					switch (num)
					{
					case 34:
						_0088_0093_009A.Z = _0088_0094_0090._008B_008B_008A(_0088_0093_0097.X, _0088_0093_0097.Y);
						obj5 = _0088_0094_008F._008B_008B_008E(300.0);
						goto case 2;
					case 2:
						obj6 = _0088_0094_0090._008B_008B_008E(300.0);
						num = 14;
						if (!_0088_0086())
						{
							goto case 14;
						}
						goto IL_05c3;
					case 14:
						obj4 = _0088_0094_008E._008B_008B_008E(300.0);
						_0088_0093_009B = _0088_0094_0088._008B_0088_0093(obj5);
						_0088_0093_0098 = obj5._008B_0088_0093(obj6);
						_0088_0093_009C = obj6._008B_0088_0093(obj4);
						_0088_0093_009B.Z = 300.0;
						_0088_0093_0098.Z = 300.0;
						_0088_0093_009C.Z = 300.0;
						num = 13;
						goto case 13;
					case 13:
						obj2 = _0088_0094_008F._008B_008B_008E(600.0);
						goto case 20;
					case 20:
						obj3 = _0088_0094_0090._008B_008B_008E(600.0);
						num = 23;
						goto case 23;
					case 23:
						obj = new LineCarrier(1.0, 0.0, 0.0 - _0088_0093_0091.X);
						num = 3;
						if (_0087z())
						{
							continue;
						}
						goto end_IL_054d;
					case 33:
						_0088_0093_0097 = _0088_0094_0088._008B_0088_0093(_0088_0094_0089);
						num = 28;
						goto case 28;
					case 28:
						_0088_0093_009A = _0088_0094_0089._008B_0088_0093(_0088_0094_008A);
						_0088_0093_0097.Z = _0088_0094_008F._008B_008B_008A(_0088_0093_0097.X, _0088_0093_0097.Y);
						num = 34;
						goto case 34;
					case 30:
						_0088_0094_0087 = _0088_0094_008D._008B_008B_008D(_0088_0094_008E);
						goto case 27;
					case 27:
						_0088_0094_0088 = _0088_0094_008F._008B_008B_008D(_0088_0094_008D);
						goto case 24;
					case 24:
						_0088_0094_0089 = _0088_0094_0090._008B_008B_008D(_0088_0094_008D);
						_0088_0086();
						if (_0087z())
						{
							num = 4;
							if (_0087z())
							{
								goto case 4;
							}
							goto IL_05e2;
						}
						num = 7;
						goto end_IL_054d;
					case 4:
					case 8:
						_0088_0094_008A = _0088_0094_0090._008B_008B_008D(_0088_0094_008E);
						goto case 1;
					case 1:
						_0088_0093_0090 = _0088_0093_009E._008B_0088_0093(_0088_0094_008B._008B_008B_008E(0.0));
						num = 26;
						goto case 26;
					case 26:
						_0088_0093_0093 = _0088_0094_0086._008B_0088_0093(_0088_0094_008C._008B_008B_008E(0.0));
						_0088_0093_0095 = _0088_0094_0087._008B_0088_0093(_0088_0094_008D._008B_008B_008E(0.0));
						_0088_0093_0091 = _0088_0093_009E._008B_0088_0093(_0088_0094_008B._008B_008B_008E(_0088_0094_0091));
						_0088_0093_0094 = _0088_0094_0086._008B_0088_0093(_0088_0094_008C._008B_008B_008E(_0088_0094_0091));
						_0088_0093_0096 = _0088_0094_0087._008B_0088_0093(_0088_0094_008D._008B_008B_008E(_0088_0094_0091));
						_0088_0093_0091.Z = _0088_0094_0091;
						_0088_0093_0094.Z = _0088_0094_0091;
						_0088_0093_0096.Z = _0088_0094_0091;
						num = 33;
						goto case 33;
					case 16:
						_0088_0094_0093 = new List<List<TemplatePoint>>();
						num = 6;
						goto case 6;
					case 6:
						_0088_0093_009E = _0088_0094_008B._008B_008B_008D(_0088_0094_008C);
						num = 9;
						goto case 9;
					case 9:
						_0088_0094_0086 = _0088_0094_008C._008B_008B_008D(_0088_0094_008D);
						goto case 30;
					default:
						num = 20;
						goto case 20;
					case 15:
						break;
					case 17:
						goto IL_04ce;
					case 10:
						goto IL_04f7;
					case 21:
						goto IL_0524;
					case 3:
						goto IL_0534;
					case 11:
						goto IL_054d;
					case 12:
						_0088_0093_0086();
						_0088_0093_0087();
						_0088_0093_0088();
						_0088_0093_0089();
						_0088_0093_008A();
						_0088_0093_008B();
						goto IL_058e;
					case 5:
						goto IL_058e;
					case 0:
						goto IL_05ae;
					case 19:
						goto IL_05c3;
					case 29:
						goto IL_05d2;
					case 22:
						goto IL_05e2;
					case 31:
						goto IL_0612;
					case 18:
						goto IL_063b;
					case 7:
					case 32:
						goto end_IL_054d;
					case 25:
					case 35:
						return;
					}
					break;
				}
				goto IL_04a2;
				IL_058e:
				_0088_0093_008C();
				num = 0;
				goto IL_05ae;
				IL_05ae:
				_0088_0093_008D();
				_0088_0093_008E();
				num = 19;
				goto IL_05c3;
				IL_05c3:
				_0088_0093_008F();
				num = 29;
				goto IL_05d2;
				IL_05d2:
				list = new List<TemplatePoint>();
				num = 22;
				goto IL_05e2;
				IL_05e2:
				list.Add(new TemplatePoint(0.0, 0.0));
				num = 31;
				goto IL_0612;
				continue;
				end_IL_054d:
				break;
			}
			_0088_0094_0093.Add(list);
		}

		// R8 MethodDef: original 0x0600042A RVA 0x679E0; processed 0x06000429 RVA 0x55010; source 03_recovered-src\annotated-strings\--\--.cs:43908; processed IL recovery, not original runtime.
public TemplatePoint _0088_0092_009E(TemplatePoint P_0)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			string text = default(string); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			double num8 = default(double); // IL InitLocals

			num = 23;
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				if (!false /* original-file-bool-offset:812 */)
				{
					num2 = ((P_0.Y > 0.0) ? P_0.Y : (0.0 - P_0.Y));
					P_0.Name = "out" ;
					if (P_0.X < _0088_0093_009D.X)
					{
						break;
					}
					goto IL_04ec;
				}
				num = 2;
				if (!_0087z())
				{
					goto IL_0218;
				}
				goto IL_0348;
				IL_052e:
				P_0.Name = "out" ;
				goto IL_053e;
				IL_053e:
				return P_0;
				IL_0430:
				num3 = num4;
				num = 22;
				goto IL_0472;
				IL_03e8:
				num3 = num5;
				num = 3;
				goto IL_0401;
				IL_041c:
				text = "Y" ;
				num = 31;
				goto IL_0430;
				IL_04ec:
				if (num2 > _0088_0093_009D.Y)
				{
					break;
				}
				goto IL_04d4;
				IL_04d4:
				if (!(P_0.X > _0088_0093_0092.X))
				{
					text = "X" ;
					goto IL_04bf;
				}
				break;
				IL_03c9:
				text = "W" ;
				goto IL_03d4;
				IL_04bf:
				num3 = _0088_0094_008C._008B_008B_008A(P_0.X, num2);
				goto IL_04a1;
				IL_04a1:
				num4 = _0088_0094_008D._008B_008B_008A(P_0.X, num2);
				num = 25;
				goto IL_049b;
				IL_049b:
				if (num3 < num4)
				{
					num = 34;
					goto IL_041c;
				}
				goto IL_0472;
				IL_03d4:
				num3 = num6;
				goto IL_03d7;
				IL_0472:
				num5 = _0088_0094_008E._008B_008B_008A(P_0.X, num2);
				if (!(num3 < num5))
				{
					goto IL_0401;
				}
				text = "Z" ;
				/* opaque discard 0 */
				if (_0087z())
				{
					num = 29;
					goto IL_03e8;
				}
				num = 24;
				if (!_0088_0086())
				{
					goto IL_037a;
				}
				goto IL_04ec;
				IL_0259:
				text = "Gnd" ;
				num = 19;
				if (_0088_0086())
				{
					goto IL_028e;
				}
				goto IL_0395;
				IL_028e:
				text = "P1" ;
				num3 = num7;
				goto IL_034b;
				IL_0395:
				num3 = 0.0;
				goto IL_039f;
				IL_0401:
				num6 = _0088_0094_008B._008B_008B_008A(P_0.X, num2);
				if (num3 < num6)
				{
					num = 15;
					goto IL_03c9;
				}
				goto IL_03d7;
				IL_0218:
				if (num2 > obj._008B_0088_008D(P_0.X))
				{
					num = 4;
					if (!_0087z())
					{
						goto IL_034b;
					}
					goto IL_0364;
				}
				text = "Z" ;
				num = 26;
				goto IL_02f0;
				IL_03d7:
				if (num3 < 0.0)
				{
					goto IL_0259;
				}
				goto IL_039f;
				IL_039f:
				num7 = _0088_0094_008F._008B_008B_008A(P_0.X, num2);
				num8 = _0088_0094_0090._008B_008B_008A(P_0.X, num2);
				goto IL_037a;
				IL_037a:
				if (!(P_0.X > _0088_0093_0094.X))
				{
					if (P_0.X > _0088_0093_009B.X)
					{
						num = 6;
						if (_0087z())
						{
							goto IL_01f7;
						}
						goto IL_0279;
					}
					if (P_0.X > _0088_0093_0098.X)
					{
						obj = _0088_0094_008F._008B_008B_008D(_0088_0094_008D);
						if (num2 > obj._008B_0088_008D(P_0.X))
						{
							num = 13;
							goto IL_028e;
						}
						goto IL_034b;
					}
					if (!(P_0.X <= _0088_0093_009A.X))
					{
						goto IL_02bd;
					}
					obj = _0088_0094_0090._008B_008B_008D(_0088_0094_008E);
					num = 7;
					if (_0087z())
					{
						goto IL_012f;
					}
					goto IL_0364;
				}
				goto IL_030e;
				IL_032d:
				if (num2 > obj._008B_0088_008D(P_0.X))
				{
					text = "P1" ;
					goto IL_0348;
				}
				goto IL_034b;
				IL_0364:
				text = "P2" ;
				num = 18;
				goto IL_035f;
				IL_035f:
				num3 = num8;
				goto IL_034b;
				IL_0348:
				num3 = num7;
				goto IL_034b;
				IL_01f7:
				obj = _0088_0094_008D._008B_008B_008E(300.0);
				num = 9;
				goto IL_0279;
				IL_02f0:
				num3 = _0088_0094_008E._008B_008B_008A(P_0.X, num2);
				num = 30;
				goto IL_034b;
				IL_0279:
				if (num2 > obj._008B_0088_008D(P_0.X))
				{
					goto IL_02a1;
				}
				goto IL_034b;
				IL_02bd:
				obj = _0088_0094_0090._008B_008B_008D(_0088_0094_008D);
				if (num2 > obj._008B_0088_008D(P_0.X))
				{
					text = "P2" ;
					num3 = num8;
				}
				goto IL_034b;
				IL_02a1:
				text = "P1" ;
				num = 5;
				goto IL_02b5;
				IL_034b:
				if (!(num3 > 600.0))
				{
					P_0.Name = text;
					num = 1;
					goto IL_01ca;
				}
				num = 21;
				goto IL_052e;
				IL_02b5:
				num3 = num7;
				goto IL_034b;
				IL_030e:
				obj = _0088_0094_008C._008B_008B_008E(300.0);
				num = 0;
				goto IL_032d;
				IL_01ca:
				P_0.Z = num3;
				num = 35;
				if (!_0088_0086())
				{
					goto IL_012f;
				}
				goto IL_032d;
				IL_012f:
				switch (num)
				{
				case 1:
					break;
				default:
					num = 28;
					goto IL_030e;
				case 6:
					goto IL_01f7;
				case 7:
					goto IL_0218;
				case 8:
					goto IL_0259;
				case 9:
					goto IL_0279;
				case 13:
					goto IL_028e;
				case 14:
					goto IL_02a1;
				case 5:
					goto IL_02b5;
				case 17:
					goto IL_02bd;
				case 26:
					goto IL_02f0;
				case 28:
					goto IL_030e;
				case 0:
					goto IL_032d;
				case 2:
					goto IL_0348;
				case 20:
				case 30:
					goto IL_034b;
				case 18:
					goto IL_035f;
				case 4:
					goto IL_0364;
				case 16:
				case 24:
					goto IL_037a;
				case 19:
					goto IL_0395;
				case 15:
					goto IL_03c9;
				case 12:
					goto IL_03d4;
				case 10:
				case 29:
					goto IL_03e8;
				case 3:
					goto IL_0401;
				case 34:
					goto IL_041c;
				case 31:
					goto IL_0430;
				case 22:
					goto IL_0472;
				case 25:
					goto IL_049b;
				case 32:
					goto IL_04a1;
				case 33:
					goto IL_04bf;
				case 27:
					goto IL_04d4;
				case 11:
					goto IL_04ec;
				case 23:
					continue;
				case 21:
					goto IL_052e;
				case 35:
					goto IL_053e;
				}
				goto IL_01ca;
			}
			return P_0;
		}

		// R8 MethodDef: original 0x0600042B RVA 0x67FAC; processed 0x0600042A RVA 0x55560; source 03_recovered-src\annotated-strings\--\--.cs:44236; processed IL recovery, not original runtime.
private void _0088_0093_0086()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (true /* original-file-bool-offset:816 */)
			{
				list = new List<TemplatePoint>();
				list.Add(_0088_0093_0090);
				_0088_0086();
				if (_0087z())
				{
					list.Add(_0088_0093_0091);
					list.Add(new TemplatePoint(_0088_0093_0091.X, 0.0, _0088_0093_0091.Z));
					list.Add(new TemplatePoint(_0088_0093_0090.X, 0.0, _0088_0093_0090.Z));
					list.Add(_0088_0093_0090);
					_0088_0094_0092.Add(list);
					list = new List<TemplatePoint>();
				}
				list.Add(TemplatePoint._008B_0089_008B(_0088_0093_0090));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0093_0091));
				list.Add(new TemplatePoint(_0088_0093_0091.X, 0.0, _0088_0093_0091.Z));
				list.Add(new TemplatePoint(_0088_0093_0090.X, 0.0, _0088_0093_0090.Z));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0093_0090));
				_0088_0094_0093.Add(list);
			}
		}

		// R8 MethodDef: original 0x0600042C RVA 0x681E8; processed 0x0600042B RVA 0x556B4; source 03_recovered-src\annotated-strings\--\--.cs:44261; processed IL recovery, not original runtime.
private void _0088_0093_0087()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			item = new List<TemplatePoint> { _0088_0093_0094, _0088_0093_0093, _0088_0093_0090, _0088_0093_0091, _0088_0093_0094 };
			_0088_0094_0092.Add(item);
		}

		// R8 MethodDef: original 0x0600042D RVA 0x6824C; processed 0x0600042C RVA 0x55710; source 03_recovered-src\annotated-strings\--\--.cs:44267; processed IL recovery, not original runtime.
private void _0088_0093_0088()
		{

			List<TemplatePoint> item = new List<TemplatePoint>
			{
				TemplatePoint._008B_0089_008B(_0088_0093_0094),
				TemplatePoint._008B_0089_008B(_0088_0093_0093),
				TemplatePoint._008B_0089_008B(_0088_0093_0090),
				TemplatePoint._008B_0089_008B(_0088_0093_0091),
				TemplatePoint._008B_0089_008B(_0088_0093_0094)
			};
			_0088_0094_0093.Add(item);
		}

		// R8 MethodDef: original 0x0600042E RVA 0x682C8; processed 0x0600042D RVA 0x55784; source 03_recovered-src\annotated-strings\--\--.cs:44280; processed IL recovery, not original runtime.
private void _0088_0093_0089()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			item = new List<TemplatePoint> { _0088_0093_0095, _0088_0093_009A, _0088_0093_0097, _0088_0093_009B, _0088_0093_0094, _0088_0093_0093, _0088_0093_0095 };
			_0088_0094_0092.Add(item);
		}

		// R8 MethodDef: original 0x0600042F RVA 0x68344; processed 0x0600042E RVA 0x557F8; source 03_recovered-src\annotated-strings\--\--.cs:44286; processed IL recovery, not original runtime.
private void _0088_0093_008A()
		{

			List<TemplatePoint> item = new List<TemplatePoint>
			{
				TemplatePoint._008B_0089_008B(_0088_0093_0095),
				TemplatePoint._008B_0089_008B(_0088_0093_009A),
				TemplatePoint._008B_0089_008B(_0088_0093_0097),
				TemplatePoint._008B_0089_008B(_0088_0093_009B),
				TemplatePoint._008B_0089_008B(_0088_0093_0094),
				TemplatePoint._008B_0089_008B(_0088_0093_0093),
				TemplatePoint._008B_0089_008B(_0088_0093_0095)
			};
			_0088_0094_0093.Add(item);
		}

		// R8 MethodDef: original 0x06000430 RVA 0x683E4; processed 0x0600042F RVA 0x55890; source 03_recovered-src\annotated-strings\--\--.cs:44301; processed IL recovery, not original runtime.
private void _0088_0093_008B()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			/* opaque discard 0 */
			// IL local hoisted
			if (_0087z())
			{
				if (false /* original-file-bool-offset:820 */)
				{
					return;
				}
				item = new List<TemplatePoint>
				{
					_0088_0093_0095,
					_0088_0093_009A,
					_0088_0093_009C,
					new TemplatePoint(_0088_0093_009C.X, 0.0, _0088_0093_009C.Z),
					new TemplatePoint(_0088_0093_0095.X, 0.0, _0088_0093_0095.Z),
					_0088_0093_0095
				};
				_0088_0094_0092.Add(item);
				item = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_0088_0093_0095),
					TemplatePoint._008B_0089_008B(_0088_0093_009A),
					TemplatePoint._008B_0089_008B(_0088_0093_009C),
					new TemplatePoint(_0088_0093_009C.X, 0.0, _0088_0093_009C.Z),
					new TemplatePoint(_0088_0093_0095.X, 0.0, _0088_0093_0095.Z),
					TemplatePoint._008B_0089_008B(_0088_0093_0095)
				};
			}
			_0088_0094_0093.Add(item);
		}

		// R8 MethodDef: original 0x06000431 RVA 0x685D8; processed 0x06000430 RVA 0x559FC; source 03_recovered-src\annotated-strings\--\--.cs:44334; processed IL recovery, not original runtime.
private void _0088_0093_008C()
		{

			_0087z();
			if (!_0088_0086() && !false /* original-file-bool-offset:824 */)
			{
				List<TemplatePoint> item = new List<TemplatePoint>
				{
					_0088_0093_009B,
					_0088_0093_0097,
					_0088_0093_0098,
					_0088_0093_009B,
					_0088_0093_0094,
					new TemplatePoint(_0088_0093_0091.X, _0088_0093_0091.Y, _0088_0093_0092.Z - (_0088_0093_0092.Y - _0088_0093_0091.Y) * _0088_0094_008F._008B_008B_0093),
					_0088_0093_0092,
					_0088_0093_0099,
					_0088_0093_0098,
					_0088_0093_009B
				};
				_0088_0094_0092.Add(item);
			}
		}

		// R8 MethodDef: original 0x06000432 RVA 0x68740; processed 0x06000431 RVA 0x55AFC; source 03_recovered-src\annotated-strings\--\--.cs:44356; processed IL recovery, not original runtime.
private void _0088_0093_008D()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			// IL local hoisted
			if (false /* original-file-bool-offset:828 */)
			{
				/* opaque discard 0 */
				if (_0087z() || !_0087z())
				{
					return;
				}
			}
			else
			{
				item = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_0088_0093_009B),
					TemplatePoint._008B_0089_008B(_0088_0093_0097),
					TemplatePoint._008B_0089_008B(_0088_0093_0098),
					TemplatePoint._008B_0089_008B(_0088_0093_009B),
					TemplatePoint._008B_0089_008B(_0088_0093_0094),
					TemplatePoint._008B_0089_008B(new TemplatePoint(_0088_0093_0091.X, _0088_0093_0091.Y, _0088_0093_0092.Z - (_0088_0093_0092.Y - _0088_0093_0091.Y) * _0088_0094_008F._008B_008B_0093)),
					TemplatePoint._008B_0089_008B(_0088_0093_0092),
					TemplatePoint._008B_0089_008B(_0088_0093_0099),
					TemplatePoint._008B_0089_008B(_0088_0093_0098),
					TemplatePoint._008B_0089_008B(_0088_0093_009B)
				};
			}
			_0088_0094_0093.Add(item);
		}

		// R8 MethodDef: original 0x06000433 RVA 0x688E0; processed 0x06000432 RVA 0x55C34; source 03_recovered-src\annotated-strings\--\--.cs:44386; processed IL recovery, not original runtime.
private void _0088_0093_008E()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			item = new List<TemplatePoint> { _0088_0093_0098, _0088_0093_009C, _0088_0093_009D, _0088_0093_0099, _0088_0093_0098, _0088_0093_0097, _0088_0093_009A, _0088_0093_009C, _0088_0093_0098 };
			_0088_0094_0092.Add(item);
		}

		// R8 MethodDef: original 0x06000434 RVA 0x68974; processed 0x06000433 RVA 0x55CC0; source 03_recovered-src\annotated-strings\--\--.cs:44392; processed IL recovery, not original runtime.
private void _0088_0093_008F()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			_0087z();
			// IL local hoisted
			if (!_0088_0086())
			{
				if (false /* original-file-bool-offset:832 */)
				{
					if (_0087z())
					{
					}
					return;
				}
				item = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_0088_0093_0098),
					TemplatePoint._008B_0089_008B(_0088_0093_009C),
					TemplatePoint._008B_0089_008B(_0088_0093_009D),
					TemplatePoint._008B_0089_008B(_0088_0093_0099),
					TemplatePoint._008B_0089_008B(_0088_0093_0098),
					TemplatePoint._008B_0089_008B(_0088_0093_0097),
					TemplatePoint._008B_0089_008B(_0088_0093_009A),
					TemplatePoint._008B_0089_008B(_0088_0093_009C),
					TemplatePoint._008B_0089_008B(_0088_0093_0098)
				};
			}
			_0088_0094_0093.Add(item);
		}

		// R8 MethodDef: original 0x06000435 RVA 0x68AC4; processed 0x06000434 RVA 0x493C; source 03_recovered-src/annotated-strings/--/--.cs:44421; processed IL recovery, not original runtime.
static PaOasGeometry()
		{

			// original licensing excluded; independent source only
		}

		// R8 MethodDef: original 0x06000436 RVA 0x68AE0; processed 0x06000435 RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:44426; processed IL recovery, not original runtime.
internal static bool _0087z()
		{

			return true;
		}

		// R8 MethodDef: original 0x06000437 RVA 0x68AEC; processed 0x06000436 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:44431; processed IL recovery, not original runtime.
internal static bool _0088_0086()
		{

			return false;
		}
	}
}
