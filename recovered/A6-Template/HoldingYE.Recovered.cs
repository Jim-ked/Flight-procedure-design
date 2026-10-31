using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Forms;
// Mechanical recovery: original field/method identifiers retained. See evidence/methods.csv.
// IL locals hoisted to method entry; expression assignments and branch order preserved.
namespace Recovered.A6 {
	public class HoldingYE
	{
		public TurnInput _0088_008C_0090;

		public double _0088_008C_0091;

		public double _0088_008C_0092;

		public double _0088_008C_0093;

		public double _0088_008C_0094;

		public double _0088_008C_0095;

		public TemplatePoint _0088_008C_0096;

		private TemplatePoint _0088_008C_0097;

		private TemplatePoint _0088_008C_0098;

		private TemplatePoint _0088_008C_0099;

		private TemplatePoint _0088_008C_009A;

		private TemplatePoint _0088_008C_009B;

		private TemplatePoint _0088_008C_009C;

		private TemplatePoint _0088_008C_009D;

		private TemplatePoint _0088_008C_009E;

		private double _0088_008D_0086;

		private double _0088_008D_0087;

		private Spiral86 _0088_008D_0088;

		private Spiral86 _0088_008D_0089;

		public string _0088_008D_008A;

		public double _0088_008D_008B = Math.PI / 180.0;

		public double _0088_008D_008C = Math.PI / 9.0;

		public double _0088_008D_008D = Math.PI / 4.0;

		public double _0088_008D_008E = Math.PI / 2.0;

		public List<List<TemplatePoint>> _0088_008D_008F = new List<List<TemplatePoint>>();

		public List<List<TemplatePoint>> _0088_008D_0090 = new List<List<TemplatePoint>>();

		public List<List<TemplatePoint>> _0088_008D_0091 = new List<List<TemplatePoint>>();

		public List<TemplatePoint> _0088_008D_0092;

// Original MethodDef: 0x060003CA; Original RVA: 0x60E28; Processed MethodDef: 0x060003C9; Evidence: HoldingYE.source.txt:40029 + independent IL (decompilation/recovery, not runtime).
		public HoldingYE(TurnInput P_0, double P_1 = 1.0)
		{

			/* opaque discard 0 */
			if (_0087f())
			{
				_0088_008D_0092 = new List<TemplatePoint>();
				// object constructor emitted automatically by C#
			}
			_0088_008C_008A(P_0, P_1);
			_0088_008C_0089();
		}

// Original MethodDef: 0x060003CB; Original RVA: 0x60F90; Processed MethodDef: 0x060003CA; Evidence: HoldingYE.source.txt:40041 + independent IL (decompilation/recovery, not runtime).
		public void _0088_008C_0089()
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals

			if (_0087f())
			{
				if (!true /* original-file-bool-offset:732 */)
				{
					return;
				}
				_0088_008D_0092 = new List<TemplatePoint>();
			}
			_0088_008C_0097 = new TemplatePoint(0.0, 0.0);
			_0088_008D_0092.Add(_0088_008C_0097);
			obj = TemplatePoint._008B_0089_0088(_0088_008C_0097, TemplatePoint._008B_0089_0087(_0088_008C_0090._008A_009D_009D, 0.0 - _0088_008D_008E));
			_0088_008C_008F(ref _0088_008D_0092, obj, _0088_008C_0090._008A_009D_009D, 90.0, 180.0);
			/* opaque discard 1 */
			if (!_0087g())
			{
				goto IL_00c5;
			}
			goto IL_0122;
			IL_00c5:
			obj2 = new TemplatePoint(0.0, -2.0 * _0088_008C_0090._008A_009D_009D);
			_0088_008D_0092.Add(obj2);
			obj3 = TemplatePoint._008B_0089_0088(obj2, new TemplatePoint(_0088_008C_0093, 0.0));
			goto IL_0122;
			IL_0122:
			_0088_008D_0092.Add(obj3);
			obj = TemplatePoint._008B_0089_0088(obj3, TemplatePoint._008B_0089_0087(_0088_008C_0090._008A_009D_009D, _0088_008D_008E));
			_0088_008C_008F(ref _0088_008D_0092, obj, _0088_008C_0090._008A_009D_009D, -90.0, 180.0);
			if (!_0087g())
			{
				_0088_008D_0092.Add(_0088_008C_0097);
				return;
			}
			goto IL_00c5;
		}

// Original MethodDef: 0x060003CC; Original RVA: 0x6121C; Processed MethodDef: 0x060003CB; Evidence: HoldingYE.source.txt:40078 + independent IL (decompilation/recovery, not runtime).
		public void _0088_008C_008A(TurnInput P_0, double P_1 = 1.0)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			int num = default(int); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			while (true /* original-file-bool-offset:736 */)
			{
				num = 9;
				if (_0087f())
				{
					goto IL_02ad;
				}
				goto IL_062c;
				IL_0782:
				_0088_008C_008C(_0088_008C_0099, obj);
				num = 7;
				goto IL_0798;
				IL_062c:
				_0088_008C_0099 = TemplatePoint._008B_0089_008E(_0088_008C_009D, 0.0, 0.0 - _0088_008C_0090._008A_009D_009D);
				_0088_008C_009A = TemplatePoint._008B_0089_008E(_0088_008C_0099, _0088_008D_0087);
				_0088_008C_009E = TemplatePoint._008B_0089_008E(_0088_008C_009A, 0.0, _0088_008C_0090._008A_009D_009D - _0088_008D_0087 * Math.Tan(5.0 * _0088_008D_008B));
				_0088_008D_0088 = new Spiral86(_0088_008C_0090, _0088_008C_009D, 160.0 * _0088_008D_008B, 11.0 * _0088_008C_0092);
				num = 17;
				goto IL_05cc;
				IL_05cc:
				_0088_008D_0089 = new Spiral86(_0088_008C_0090, _0088_008C_009E, 4.71238898038469, (_0088_008C_0094 + 26.0 + (_0088_008D_008C + _0088_008D_008E) / _0088_008C_0090._008A_009D_009C) * _0088_008C_0092);
				num = 28;
				goto IL_04e3;
				IL_04e3:
				num2 = _0088_008D_0088._008A_009E_009D(_0088_008D_0089);
				_0088_008D_0091.Add(_0088_008D_0088._008A_009E_009E(0.0, num2 - _0088_008D_0088._008B_0086_0088, 0.0, 1.0, true, true));
				_0088_008D_0091.Add(_0088_008D_0089._008A_009E_009E(num2 - _0088_008D_0089._008B_0086_0088, _0088_008C_0090._008A_009E_0086, 0.0, 1.0, true, true));
				_0088_008D_0091.Add(_0088_008D_0089._008A_009E_009E(_0088_008C_0090._008A_009E_0086, _0088_008D_008E + _0088_008C_0090._008A_009E_0086));
				num = 14;
				goto IL_04af;
				IL_04af:
				_0088_008C_008B(_0088_008C_0097, _0088_008D_0088._008A_009E_0093(0.0));
				num = 27;
				goto IL_0465;
				IL_0465:
				_0088_008C_008B(_0088_008D_0088._008A_009E_0093(num2 - _0088_008D_0088._008B_0086_0088), _0088_008D_0089._008A_009E_0093(num2 - _0088_008D_0089._008B_0086_0088));
				goto IL_0451;
				IL_0451:
				list = new List<TemplatePoint>();
				list.Add(_0088_008C_0097);
				goto IL_0418;
				IL_0418:
				list.Add(_0088_008C_009B);
				list.Add(_0088_008C_009D);
				list.Add(_0088_008C_0098);
				num = 26;
				if (!_0087f())
				{
					goto IL_0145;
				}
				goto IL_03f8;
				IL_03f8:
				list.Add(_0088_008C_009C);
				num = 13;
				goto IL_03e1;
				IL_03e1:
				_0088_008D_0090.Add(list);
				num = 1;
				goto IL_0386;
				IL_0386:
				list = new List<TemplatePoint>();
				list.Add(_0088_008C_0097);
				_0088_008C_008F(ref list, _0088_008C_009D, _0088_008C_0090._008A_009D_009D, 160.0, 110.0);
				num = 4;
				if (_0087f())
				{
					goto IL_0365;
				}
				goto IL_07cb;
				IL_0365:
				list.Add(_0088_008C_009D);
				num = 21;
				if (!_0087g())
				{
					goto IL_033b;
				}
				goto IL_04af;
				IL_033b:
				_0088_008D_0090.Add(list);
				list = new List<TemplatePoint>();
				num = 10;
				if (!_0087f())
				{
					goto IL_001e;
				}
				goto IL_02ad;
				IL_001e:
				_0088_008D_0087 = (_0088_008C_0094 + 15.0) * _0088_008C_0091;
				num = 16;
				goto IL_0044;
				IL_0044:
				_0088_008C_0097 = new TemplatePoint(0.0, 0.0);
				_0088_008C_0098 = new TemplatePoint((0.0 - _0088_008D_0086) * Math.Sin(_0088_008D_008C), (0.0 - _0088_008D_0086) * Math.Cos(_0088_008D_008C));
				num = 0;
				if (_0087f())
				{
					goto IL_02ad;
				}
				goto IL_073a;
				IL_02ad:
				while (true)
				{
					switch (num)
					{
					case 18:
						break;
					case 16:
						goto IL_0044;
					case 20:
						_0088_008C_009C = TemplatePoint._008B_0089_008E(_0088_008C_009B, 0.0, (0.0 - _0088_008D_0086) * Math.Cos(_0088_008D_008C));
						_0088_008C_009D = TemplatePoint._008B_0089_008E(_0088_008C_009C, 0.0, (0.0 - _0088_008C_0090._008A_009D_009D) * Math.Sin(_0088_008D_008C));
						num = 29;
						if (_0087f())
						{
							continue;
						}
						goto IL_0746;
					case 10:
						goto IL_0145;
					case 8:
						goto IL_015a;
					case 0:
						_0088_008C_009B = new TemplatePoint(_0088_008C_0090._008A_009D_009D * Math.Cos(_0088_008D_008C) - _0088_008D_0086 * Math.Sin(_0088_008D_008C), 0.0);
						num = 20;
						goto case 20;
					case 9:
						_0088_008C_0090 = P_0;
						goto case 11;
					case 11:
						_0088_008C_0091 = _0088_008C_0090._008A_009D_009A / 3.6;
						goto IL_022a;
					case 3:
						goto IL_022a;
					case 19:
						goto IL_026e;
					case 21:
						goto IL_033b;
					case 4:
						goto IL_0365;
					case 1:
						goto IL_0386;
					case 13:
						goto IL_03e1;
					case 26:
						goto IL_03f8;
					default:
						num = 5;
						goto IL_0418;
					case 5:
						goto IL_0418;
					case 2:
						goto IL_0451;
					case 27:
						goto IL_0465;
					case 14:
						goto IL_04af;
					case 28:
						goto IL_04e3;
					case 17:
						goto IL_05cc;
					case 29:
						goto IL_062c;
					case 22:
						goto IL_0715;
					case 23:
					case 24:
						goto IL_073a;
					case 30:
						goto IL_0746;
					case 6:
					case 25:
						goto IL_0758;
					case 12:
						goto IL_0782;
					case 7:
						goto IL_0798;
					case 15:
						goto IL_07cb;
					case 31:
						return;
					}
					break;
				}
				goto IL_001e;
				IL_0145:
				list.Add(_0088_008C_009E);
				num = 8;
				goto IL_015a;
				IL_015a:
				_0088_008C_008F(ref list, _0088_008C_009E, _0088_008C_0090._008A_009D_009D, 270.0, 90.0);
				_0087f();
				if (!_0087g())
				{
					num = 24;
					if (_0087g())
					{
						goto IL_022a;
					}
					goto IL_02ad;
				}
				num = 6;
				if (!_0087f())
				{
					goto IL_073a;
				}
				goto IL_0758;
				IL_0798:
				obj2 = TemplatePoint._008B_0089_008E(_0088_008C_009D, 0.0 - _0088_008C_0090._008A_009D_009D);
				num = 15;
				goto IL_07cb;
				IL_022a:
				_0088_008C_0092 = _0088_008C_0090._008A_009D_0098 / 3.6;
				_0088_008C_0095 = 5.0 * _0088_008D_008B;
				num = 19;
				if (!_0087g())
				{
					goto IL_026e;
				}
				goto IL_033b;
				IL_026e:
				_0088_008C_0094 = P_1 * 60.0;
				_0088_008C_0093 = _0088_008C_0091 * _0088_008C_0094;
				_0088_008D_0086 = 11.0 * _0088_008C_0091;
				goto IL_001e;
				IL_07cb:
				_0088_008C_008C(_0088_008C_009D, obj2);
				_0088_008C_0096 = _0088_008D_0089._008A_009E_0093(_0088_008C_0090._008A_009E_0086);
				break;
				IL_073a:
				_0088_008D_0090.Add(list);
				goto IL_0746;
				IL_0746:
				_0088_008C_008C(_0088_008C_0099, _0088_008C_009A);
				goto IL_0758;
				IL_0758:
				obj = TemplatePoint._008B_0089_008E(_0088_008C_009E, 0.0, 0.0 - _0088_008C_0090._008A_009D_009D);
				goto IL_0782;
				IL_0715:;
			}
		}

// Original MethodDef: 0x060003CD; Original RVA: 0x61A88; Processed MethodDef: 0x060003CC; Evidence: HoldingYE.source.txt:40325 + independent IL (decompilation/recovery, not runtime).
		protected void _0088_008C_008B(TemplatePoint P_0, TemplatePoint P_1)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			/* opaque discard 0 */
			// IL local declared at method entry
			if (_0087f())
			{
				list = new List<TemplatePoint>();
				list.Add(P_0);
				list.Add(P_1);
			}
			_0088_008D_008F.Add(list);
		}

// Original MethodDef: 0x060003CE; Original RVA: 0x61B38; Processed MethodDef: 0x060003CD; Evidence: HoldingYE.source.txt:40338 + independent IL (decompilation/recovery, not runtime).
		protected void _0088_008C_008C(TemplatePoint P_0, TemplatePoint P_1)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			/* opaque discard 0 */
			if (_0087f())
			{
				list.Add(P_0);
			}
			list.Add(P_1);
			_0088_008D_0090.Add(list);
		}

// Original MethodDef: 0x060003CF; Original RVA: 0x61BF4; Processed MethodDef: 0x060003CE; Evidence: HoldingYE.source.txt:40350 + independent IL (decompilation/recovery, not runtime).
		private List<TemplatePoint> _0088_008C_008D(TemplatePoint P_0, TemplatePoint P_1, double P_2, double P_3 = Math.PI * 3.0 / 5.0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:740 */)
			{
				goto IL_0094;
			}
			list = new List<TemplatePoint>();
			num = Math.Atan2(P_1.Y - P_0.Y, P_1.X - P_0.X) - P_3 / 2.0;
			num2 = num + P_3;
			num3 = 2.0 * _0088_008D_008B;
			num4 = num;
			goto IL_0098;
			IL_0094:
			num4 += num3;
			goto IL_0098;
			IL_0098:
			if (num4 < num2)
			{
				num5 = P_2 * Math.Cos(num4) + P_1.X;
				num6 = P_2 * Math.Sin(num4) + P_1.Y;
				list.Add(new TemplatePoint(num5, num6));
				goto IL_0094;
			}
			list.Add(new TemplatePoint(P_2 * Math.Cos(num2) + P_1.X, P_2 * Math.Sin(num2) + P_1.Y));
			return list;
		}

// Original MethodDef: 0x060003D0; Original RVA: 0x61CE4; Processed MethodDef: 0x060003CF; Evidence: HoldingYE.source.txt:40377 + independent IL (decompilation/recovery, not runtime).
		private void _0088_008C_008E(List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:744 */)
			{
				return;
			}
			num = P_3 + P_4;
			if (P_4 > 0.0)
			{
				num2 = 2.0 * _0088_008D_008B;
				for (double num3 = P_3 + num2; num3 < num; num3 += num2)
				{
					num4 = P_2 * Math.Cos(num3) + P_1.X;
					num5 = P_2 * Math.Sin(num3) + P_1.Y;
					P_0.Add(new TemplatePoint(num4, num5));
				}
			}
			else
			{
				num2 = -2.0 * _0088_008D_008B;
				for (double num6 = P_3 + num2; num6 > num; num6 += num2)
				{
					num7 = P_2 * Math.Cos(num6) + P_1.X;
					num8 = P_2 * Math.Sin(num6) + P_1.Y;
					P_0.Add(new TemplatePoint(num7, num8));
				}
			}
		}

// Original MethodDef: 0x060003D1; Original RVA: 0x61DEC; Processed MethodDef: 0x060003D0; Evidence: HoldingYE.source.txt:40406 + independent IL (decompilation/recovery, not runtime).
		public void _0088_008C_008F(ref List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4, double P_5 = 1.0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			_0087g();
			if (_0087f() && !false /* original-file-bool-offset:748 */)
			{
				num = Math.Abs(P_5);
				num2 = P_3;
				for (double num3 = 0.0; num3 < P_4; num3 += num)
				{
					obj = new TemplatePoint(P_2 * Math.Cos(num2 * _0088_008D_008B), P_2 * Math.Sin(num2 * _0088_008D_008B));
					P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
					num2 += P_5;
				}
				num4 = ((P_5 > 0.0) ? (P_3 + P_4) : (P_3 - P_4));
				if (num2 - P_5 != num4)
				{
					obj = new TemplatePoint(P_2 * Math.Cos(num4 * _0088_008D_008B), P_2 * Math.Sin(num4 * _0088_008D_008B));
					P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
				}
			}
		}

// Original MethodDef: 0x060003D2; Original RVA: 0x61FBC; Processed MethodDef: 0x060003D1; Evidence: HoldingYE.source.txt:40428 + independent IL (decompilation/recovery, not runtime).
		public override string ToString()
		{
			int num = default(int); // IL InitLocals

			num = 2;
			if (!_0087g())
			{
				while (true)
				{
					switch (num)
					{
					case 2:
						if (false /* original-file-bool-offset:752 */)
						{
							_0087g();
							if (_0087f())
							{
								num = 6;
								if (_0087f())
								{
									continue;
								}
								goto default;
							}
							num = 5;
							break;
						}
						_0088_008D_008A = "======= HoldingXE Parameters=========\n" /* string-offset:5324 */;
						num = 3;
						goto case 3;
					case 3:
						_0088_008D_008A = _0088_008D_008A + "v = " /* string-offset:5272 */ + Math.Ceiling(_0088_008C_0091) + "m/s\n" /* string-offset:1504 */;
						goto default;
					default:
						_0088_008D_008A = _0088_008D_008A + "w = " /* string-offset:5276 */ + Math.Ceiling(_0088_008C_0092) + "m/s\n" /* string-offset:1504 */;
						break;
					case 1:
					case 4:
					case 5:
					case 6:
						break;
					case 7:
						goto IL_0145;
					}
					break;
				}
			}
			_0088_008D_008A = _0088_008D_008A + "L = " /* string-offset:1536 */ + Math.Ceiling(_0088_008C_0093) + " m\n" /* string-offset:5280 */;
			num = 7;
			goto IL_0145;
			IL_0145:
			return _0088_008D_008A;
		}

// Original MethodDef: 0x060003D3; Original RVA: 0x6214C; Processed MethodDef: 0x060003D2; Evidence: HoldingYE.source.txt:40480 + independent IL (decompilation/recovery, not runtime).
		static HoldingYE()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x060003D4; Original RVA: 0x62168; Processed MethodDef: 0x060003D3; Evidence: HoldingYE.source.txt:40485 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0087f()
		{

			return true;
		}

// Original MethodDef: 0x060003D5; Original RVA: 0x62174; Processed MethodDef: 0x060003D4; Evidence: HoldingYE.source.txt:40490 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0087g()
		{

			return false;
		}
	}
}
