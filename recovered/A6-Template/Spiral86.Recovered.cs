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
	public class Spiral86
	{
		public double _008B_0086_0088;

		private double _008B_0086_0089;

		public TemplatePoint _008B_0086_008A;

		public double _008B_0086_008B;

		public double _008B_0086_008C;

		public double _008B_0086_008D;

		public double _008B_0086_008E;

		public double _008B_0086_008F;

		private int _008B_0086_0090;

		public double _008B_0086_0091;

		private static double _008B_0086_0092;

// Original MethodDef: 0x060007A1; Original RVA: 0xC4600; Processed MethodDef: 0x060007A0; Evidence: Spiral86.source.txt:81974 + independent IL (decompilation/recovery, not runtime).
		public Spiral86()
		{

			_008B_0086_0091 = Math.PI / 180.0;
			// object constructor emitted automatically by C#
		}

// Original MethodDef: 0x060007A2; Original RVA: 0xC4620; Processed MethodDef: 0x060007A1; Evidence: Spiral86.source.txt:81980 + independent IL (decompilation/recovery, not runtime).
		public Spiral86(TurnInput P_0, TemplatePoint P_1, double P_2 = 0.0, double P_3 = 0.0, bool P_4 = true)
		{
			int num = default(int); // IL InitLocals

			num = 8;
			while (true)
			{
				_008B_0086_0091 = Math.PI / 180.0;
				_0089l();
				if (_0089m())
				{
					num = 7;
					goto IL_0102;
				}
				num = 5;
				if (!_0089m())
				{
					goto IL_0036;
				}
				goto IL_0092;
				IL_00ae:
				// object constructor emitted automatically by C#
				_008B_0086_008B = P_0._008A_009D_009E;
				num = 9;
				goto IL_00c9;
				IL_00c9:
				_008B_0086_008C = P_0._008A_009D_009D;
				num = 4;
				goto IL_0092;
				IL_0092:
				_008B_0086_008D = P_0._008A_009E_0086;
				num = 3;
				if (!_0089l())
				{
					goto IL_00ae;
				}
				goto IL_00e0;
				IL_00e0:
				_008B_0086_008E = Math.Cos(_008B_0086_008D);
				goto IL_00f1;
				IL_00f1:
				_008B_0086_008F = Math.Sin(_008B_0086_008D);
				goto IL_0102;
				IL_0102:
				_008B_0086_008A = P_1;
				_008B_0086_0088 = _008A_009E_0090(P_2);
				num = 2;
				goto IL_006d;
				IL_006d:
				_008B_0086_0089 = P_3;
				num = 10;
				if (_0089l())
				{
					goto IL_0036;
				}
				goto IL_00c9;
				IL_0036:
				switch (num)
				{
				case 8:
					break;
				case 2:
					goto IL_006d;
				default:
					num = 0;
					goto IL_00f1;
				case 4:
					goto IL_0092;
				case 1:
				case 5:
					goto IL_00ae;
				case 9:
					goto IL_00c9;
				case 3:
					goto IL_00e0;
				case 0:
					goto IL_00f1;
				case 6:
				case 7:
					goto IL_0102;
				case 10:
					_008B_0086_0090 = (P_4 ? 1 : (-1));
					return;
				}
			}
		}

// Original MethodDef: 0x060007A3; Original RVA: 0xC47B0; Processed MethodDef: 0x060007A2; Evidence: Spiral86.source.txt:82065 + independent IL (decompilation/recovery, not runtime).
		public static double _008A_009E_0090(double P_0)
		{

			while (true)
			{
				if (P_0 < 0.0)
				{
					P_0 += Math.PI * 2.0;
					_0089m();
					if (!_0089l())
					{
						break;
					}
				}
				else if (_0089l())
				{
					break;
				}
			}
			while (P_0 >= Math.PI * 2.0)
			{
				P_0 -= Math.PI * 2.0;
			}
			return P_0;
		}

// Original MethodDef: 0x060007A4; Original RVA: 0xC489C; Processed MethodDef: 0x060007A3; Evidence: Spiral86.source.txt:82090 + independent IL (decompilation/recovery, not runtime).
		public List<TemplatePoint> _008A_009E_0091(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:1360 */)
			{
				goto IL_0022;
			}
			list = new List<TemplatePoint>();
			num = P_0;
			num2 = P_1;
			num3 = P_3 * _008B_0086_0091;
			goto IL_002d;
			IL_0022:
			num += num3;
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			if (num >= num2)
			{
				num4 = num2 * _008B_0086_008B + _008B_0086_0089 + P_2;
				num5 = Math.Sqrt(_008B_0086_008C * _008B_0086_008C + num4 * num4 + 2.0 * _008B_0086_008C * num4 * _008B_0086_008E);
				num6 = num2 - Math.Asin(num4 * _008B_0086_008F / num5);
				num7 = num5 * Math.Cos((double)_008B_0086_0090 * num6 + _008B_0086_0088) + _008B_0086_008A.X;
				num8 = num5 * Math.Sin((double)_008B_0086_0090 * num6 + _008B_0086_0088) + _008B_0086_008A.Y;
				list.Add(new TemplatePoint(num7, num8));
				return list;
			}
			goto IL_002d;
			IL_002d:
			num4 = num * _008B_0086_008B + _008B_0086_0089 + P_2;
			num5 = Math.Sqrt(_008B_0086_008C * _008B_0086_008C + num4 * num4 + 2.0 * _008B_0086_008C * num4 * _008B_0086_008E);
			num6 = num - Math.Asin(num4 * _008B_0086_008F / num5);
			num7 = num5 * Math.Cos((double)_008B_0086_0090 * num6 + _008B_0086_0088) + _008B_0086_008A.X;
			num8 = num5 * Math.Sin((double)_008B_0086_0090 * num6 + _008B_0086_0088) + _008B_0086_008A.Y;
			list.Add(new TemplatePoint(num7, num8));
			goto IL_0022;
		}

// Original MethodDef: 0x060007A5; Original RVA: 0xC4A6C; Processed MethodDef: 0x060007A4; Evidence: Spiral86.source.txt:82129 + independent IL (decompilation/recovery, not runtime).
		public List<List<TemplatePoint>> _008A_009E_0092(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0, double P_4 = 5.0)
		{
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals
			List<TemplatePoint> list2 = default(List<TemplatePoint>); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			bool flag = default(bool); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			double num9 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:1364 */)
			{
				goto IL_0054;
			}
			list = new List<List<TemplatePoint>>();
			list2 = new List<TemplatePoint>();
			num = P_0;
			num2 = P_1;
			num3 = P_3 * _008B_0086_0091;
			num4 = 1.0;
			flag = true;
			goto IL_0094;
			IL_006c:
			num += num3;
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			if (!(num < num2))
			{
				num5 = num2 * _008B_0086_008B + _008B_0086_0089 + P_2;
				num6 = Math.Sqrt(_008B_0086_008C * _008B_0086_008C + num5 * num5 + 2.0 * _008B_0086_008C * num5 * _008B_0086_008E);
				num7 = num2 - Math.Asin(num5 * _008B_0086_008F / num6);
				num8 = num6 * Math.Cos((double)_008B_0086_0090 * num7 + _008B_0086_0088) + _008B_0086_008A.X;
				num9 = num6 * Math.Sin((double)_008B_0086_0090 * num7 + _008B_0086_0088) + _008B_0086_008A.Y;
				list2.Add(new TemplatePoint(num8, num9));
				list.Add(list2);
				return list;
			}
			goto IL_0094;
			IL_0094:
			num5 = num * _008B_0086_008B + _008B_0086_0089 + P_2;
			num6 = Math.Sqrt(_008B_0086_008C * _008B_0086_008C + num5 * num5 + 2.0 * _008B_0086_008C * num5 * _008B_0086_008E);
			num7 = num - Math.Asin(num5 * _008B_0086_008F / num6);
			num8 = num6 * Math.Cos((double)_008B_0086_0090 * num7 + _008B_0086_0088) + _008B_0086_008A.X;
			num9 = num6 * Math.Sin((double)_008B_0086_0090 * num7 + _008B_0086_0088) + _008B_0086_008A.Y;
			if (flag)
			{
				list2.Add(new TemplatePoint(num8, num9));
			}
			if (num4++ % P_4 == 0.0)
			{
				goto IL_0054;
			}
			goto IL_006c;
			IL_0054:
			if (flag)
			{
				list.Add(list2);
				list2 = new List<TemplatePoint>();
			}
			flag = !flag;
			goto IL_006c;
		}

// Original MethodDef: 0x060007A6; Original RVA: 0xC4C9C; Processed MethodDef: 0x060007A5; Evidence: Spiral86.source.txt:82187 + independent IL (decompilation/recovery, not runtime).
		public TemplatePoint _008A_009E_0093(double P_0, double P_1 = 0.0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			if (!false /* original-file-bool-offset:1368 */)
			{
				num = P_0 * _008B_0086_008B + _008B_0086_0089 + P_1;
				/* opaque discard 0 */
				if (_0089l())
				{
					num2 = Math.Sqrt(_008B_0086_008C * _008B_0086_008C + num * num + 2.0 * _008B_0086_008C * num * _008B_0086_008E);
				}
			}
			num3 = P_0 - Math.Asin(num * _008B_0086_008F / num2);
			num4 = num2 * Math.Cos((double)_008B_0086_0090 * num3 + _008B_0086_0088) + _008B_0086_008A.X;
			num5 = num2 * Math.Sin((double)_008B_0086_0090 * num3 + _008B_0086_0088) + _008B_0086_008A.Y;
			return new TemplatePoint(num4, num5);
		}

// Original MethodDef: 0x060007A7; Original RVA: 0xC4DF0; Processed MethodDef: 0x060007A6; Evidence: Spiral86.source.txt:82206 + independent IL (decompilation/recovery, not runtime).
		public TemplatePoint _008A_009E_0094(double P_0, double P_1 = 0.0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			num = _008B_0086_008C * Math.Cos((double)_008B_0086_0090 * P_0 + _008B_0086_0088) + _008B_0086_008A.X;
			num2 = _008B_0086_008C * Math.Sin((double)_008B_0086_0090 * P_0 + _008B_0086_0088) + _008B_0086_008A.Y;
			return new TemplatePoint(num, num2);
		}

// Original MethodDef: 0x060007A8; Original RVA: 0xC4E64; Processed MethodDef: 0x060007A7; Evidence: Spiral86.source.txt:82213 + independent IL (decompilation/recovery, not runtime).
		public double _008A_009E_0095(double P_0, double P_1 = 0.0)
		{
			double num = default(double); // IL InitLocals

			num = P_0 * _008B_0086_008B + _008B_0086_0089 + P_1;
			return Math.Sqrt(_008B_0086_008C * _008B_0086_008C + num * num + 2.0 * _008B_0086_008C * num * _008B_0086_008E);
		}

// Original MethodDef: 0x060007A9; Original RVA: 0xC4EBC; Processed MethodDef: 0x060007A8; Evidence: Spiral86.source.txt:82219 + independent IL (decompilation/recovery, not runtime).
		public double _008A_009E_0096(double P_0)
		{

			return _008A_009E_009C(_008B_0086_0088, P_0, _008B_0086_0090);
		}

// Original MethodDef: 0x060007AA; Original RVA: 0xC4EDC; Processed MethodDef: 0x060007A9; Evidence: Spiral86.source.txt:82224 + independent IL (decompilation/recovery, not runtime).
		public double _008A_009E_0097(double P_0, double P_1 = 0.0)
		{
			double num = default(double); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			if (!false /* original-file-bool-offset:1372 */)
			{
				P_0 = _008A_009E_0090(P_0);
				_0089l();
				if (_0089m())
				{
					goto IL_00b0;
				}
				if (_0089l())
				{
					num = P_0;
					num2 = 0;
					goto IL_0041;
				}
			}
			goto IL_0097;
			IL_0041:
			num3 = num * _008B_0086_008B + _008B_0086_0089 + P_1;
			num4 = Math.Sqrt(_008B_0086_008C * _008B_0086_008C + num3 * num3 + 2.0 * _008B_0086_008C * num3 * _008B_0086_008E);
			num5 = num - Math.Asin(num3 * _008B_0086_008F / num4);
			goto IL_0097;
			IL_0097:
			num6 = P_0 - num5;
			num += num6;
			num2++;
			if (num2 <= 20)
			{
				if (num6 <= 1E-09)
				{
					return num;
				}
				goto IL_0041;
			}
			goto IL_00b0;
			IL_00b0:
			return num;
		}

// Original MethodDef: 0x060007AB; Original RVA: 0xC5070; Processed MethodDef: 0x060007AA; Evidence: Spiral86.source.txt:82266 + independent IL (decompilation/recovery, not runtime).
		public void _008A_009E_0098(double P_0, double P_1, out double P_2, out double P_3)
		{
			double num = default(double); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			num = P_1;
			while (true)
			{
				num2 = 0;
				while (true)
				{
					num3 = _008A_009E_0097(P_0, num);
					num4 = _008A_009E_0095(num3, num) - P_1 - _008B_0086_008C;
					num -= num4;
					if (_0089m())
					{
						break;
					}
					num2++;
					_0089l();
					if ((!_0089m() && num2 > 5) || P_1 - num <= 1E-05)
					{
						P_2 = num3;
						P_3 = num;
						return;
					}
				}
			}
		}

// Original MethodDef: 0x060007AC; Original RVA: 0xC5190; Processed MethodDef: 0x060007AB; Evidence: Spiral86.source.txt:82293 + independent IL (decompilation/recovery, not runtime).
		public double _008A_009E_0099(LineCarrier P_0, double P_1 = 0.0, bool P_2 = true)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			int num5 = default(int); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			if (false /* original-file-bool-offset:1376 */)
			{
				if (_0089l())
				{
					goto IL_0084;
				}
			}
			else
			{
				num = P_0._008B_0088_0094() + _008B_0086_0088 + _008B_0086_0092 + _008B_0086_008D;
				if (_008B_0086_0090 > 0)
				{
					if (P_2)
					{
						num2 = 0.0;
						num3 = num;
					}
					else
					{
						num2 = num;
						num3 = num + _008B_0086_0092;
					}
				}
				else
				{
					if (P_2)
					{
						/* opaque discard 0 */
						if (_0089l())
						{
							goto IL_011a;
						}
						goto IL_00a1;
					}
					num2 = 0.0;
					num3 = num;
				}
			}
			goto IL_0124;
			IL_0084:
			// IL local declared at method entry
			// IL local declared at method entry
			obj._008B_0088_008F(obj2, P_0._008B_0088_0094());
			num4 = P_0._008B_0088_0092(obj2);
			num5 = 0;
			goto IL_0109;
			IL_0124:
			obj = new LineCarrier();
			obj2 = _008A_009E_0093(num, P_1);
			goto IL_0084;
			IL_011a:
			num2 = num;
			num3 = num + _008B_0086_0092;
			goto IL_0124;
			IL_00a1:
			// IL local declared at method entry
			obj2 = _008A_009E_0093(num6, P_1);
			num7 = obj._008B_0088_0092(obj2);
			if (num7 > num4)
			{
				// IL local declared at method entry
				if (!P_2)
				{
					if (_0089m())
					{
						goto IL_011a;
					}
					num8 = num2;
				}
				else
				{
					num8 = num6;
				}
				num2 = num8;
				num3 = (P_2 ? num3 : num6);
			}
			else
			{
				num2 = (P_2 ? num2 : num6);
				num3 = (P_2 ? num6 : num3);
			}
			if (num5++ <= 20)
			{
				if (Math.Abs(num7 - num4) <= 0.01)
				{
					return num6;
				}
				goto IL_0109;
			}
			return num6;
			IL_0109:
			num6 = (num2 + num3) / 2.0;
			goto IL_00a1;
		}

// Original MethodDef: 0x060007AD; Original RVA: 0xC5468; Processed MethodDef: 0x060007AC; Evidence: Spiral86.source.txt:82393 + independent IL (decompilation/recovery, not runtime).
		public double _008A_009E_009A(LineCarrier P_0, double P_1, double P_2, double P_3, double P_4 = 0.0, bool P_5 = true)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num5 = default(double); // IL InitLocals

			_0089l();
			// IL local declared at method entry
			if (!_0089m())
			{
				if (!false /* original-file-bool-offset:1380 */)
				{
					Console.WriteLine("<<getIntersectSita>>\n search from: {0},\n  to {1}." /* string-offset:7452 */, P_2 / _008B_0086_0091, P_3 / _008B_0086_0091);
					num = 0;
					goto IL_006c;
				}
				goto IL_009c;
			}
			if (!_0089m())
			{
				goto IL_008c;
			}
			goto IL_00cb;
			IL_00ad:
			// IL local declared at method entry
			// IL local declared at method entry
			if (num++ <= 20)
			{
				if (Math.Abs(num2 - P_1) <= 0.01)
				{
					return num3;
				}
				goto IL_006c;
			}
			return num3;
			IL_00cb:
			num4 = num3;
			goto IL_00c3;
			IL_00c3:
			P_2 = num4;
			P_3 = ((!P_5) ? P_3 : num3);
			goto IL_00ad;
			IL_006c:
			num3 = (P_2 + P_3) / 2.0;
			// IL local declared at method entry
			if (_0089l())
			{
				obj = _008A_009E_0093(num3, P_4);
				goto IL_008c;
			}
			goto IL_009c;
			IL_00a0:
			// IL local declared at method entry
			P_2 = num5;
			P_3 = (P_5 ? P_3 : num3);
			goto IL_00ad;
			IL_008c:
			num2 = P_0._008B_0088_0092(obj);
			if (num2 > P_1)
			{
				if (!P_5)
				{
					goto IL_009c;
				}
				num5 = num3;
				goto IL_00a0;
			}
			if (P_5)
			{
				num4 = P_2;
				goto IL_00c3;
			}
			goto IL_00cb;
			IL_009c:
			num5 = P_2;
			goto IL_00a0;
		}

// Original MethodDef: 0x060007AE; Original RVA: 0xC5650; Processed MethodDef: 0x060007AD; Evidence: Spiral86.source.txt:82467 + independent IL (decompilation/recovery, not runtime).
		public double _008A_009E_009B(TemplatePoint P_0, double P_1 = 0.0)
		{
			int num = default(int); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj4 = default(TemplatePoint); // IL InitLocals
			SideClassifier obj5 = default(SideClassifier); // IL InitLocals
			int num6 = default(int); // IL InitLocals
			int num14 = default(int); // IL InitLocals
			int num15 = default(int); // IL InitLocals
			int num16 = default(int); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num10 = default(double); // IL InitLocals
			double num13 = default(double); // IL InitLocals
			double num17 = default(double); // IL InitLocals
			double num9 = default(double); // IL InitLocals
			double num11 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num12 = default(double); // IL InitLocals
			SideClassifier obj6 = default(SideClassifier); // IL InitLocals
			SideClassifier obj7 = default(SideClassifier); // IL InitLocals

			num = 24;
			// IL local declared at method entry
			if (!_0089m())
			{
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				// IL local declared at method entry
				while (true)
				{
					switch (num)
					{
					case 25:
						obj3 = _008A_009E_0093(0.0);
						obj4 = _008A_009E_0093(Math.PI * 2.0);
						obj5 = new SideClassifier(obj3.X, obj3.Y, _008B_0086_0090, _008B_0086_0088);
						goto case 7;
					case 1:
						num6 = 0;
						if (num14 == 1 && num15 == 2)
						{
							num = 12;
							if (!_0089m())
							{
								goto case 12;
							}
							goto case 17;
						}
						if (num15 == 1 && num16 == 2)
						{
							num = 9;
							goto case 9;
						}
						goto case 11;
					case 12:
						obj = _008A_009E_0094(num5);
						num = 16;
						if (!_0089l())
						{
							goto case 2;
						}
						goto case 16;
					case 2:
					case 21:
					{
						num10 = Math.Atan2(P_0.Y - _008B_0086_008A.Y, P_0.X - _008B_0086_008A.X);
						num12 = _008A_009E_009C(_008B_0086_0088, num10, _008B_0086_0090);
						num13 = _008A_009E_0097(num12, P_1);
						num17 = _008A_009E_0095(num13, P_1);
						num = 6;
						if (!_0089m())
						{
							goto case 6;
						}
						goto case 16;
					}
					case 6:
						if (num9 >= num17)
						{
							num11 = Math.Acos(_008B_0086_008C / num9);
							num = 17;
							goto case 17;
						}
						goto case 19;
					case 17:
						num5 = _008A_009E_009C(_008B_0086_0088, num10 - (double)_008B_0086_0090 * num11, _008B_0086_0090);
						goto case 25;
					case 7:
					case 20:
					{
						obj6 = new SideClassifier(obj3.X, obj3.Y, _008B_0086_0090, _008B_0086_0088 - (double)_008B_0086_0090 * _008B_0086_008D);
						obj7 = new SideClassifier(obj4.X, obj4.Y, _008B_0086_0090, _008B_0086_0088 - (double)_008B_0086_0090 * _008B_0086_008D);
						num14 = obj5._008A_009E_0088(P_0.X, P_0.Y);
						num15 = obj6._008A_009E_0088(P_0.X, P_0.Y);
						num16 = obj7._008A_009E_0088(P_0.X, P_0.Y);
						num = 1;
						goto case 1;
					}
					case 16:
						num8 = _008B_0086_0088 - (double)_008B_0086_0090 * _008B_0086_008D + (double)_008B_0086_0090 * Math.PI / 2.0;
						num = 14;
						goto case 14;
					case 14:
						num7 = Math.Atan2(P_0.Y - obj.Y, P_0.X - obj.X);
						goto case 3;
					case 3:
					case 23:
						num2 = _008A_009E_009C(num8, num7, _008B_0086_0090);
						num5 = num2;
						goto case 11;
					case 9:
					{
						num12 = Math.PI * 2.0 + _008A_009E_009C(_008B_0086_0088, num10, _008B_0086_0090);
						num13 = Math.PI * 2.0 + _008A_009E_0097(num12, P_1);
						num = 10;
						goto case 10;
					}
					case 10:
						num17 = _008A_009E_0095(num13, P_1);
						if (num9 >= num17)
						{
							num5 = Math.PI * 2.0;
							goto case 11;
						}
						num = 15;
						goto case 15;
					case 13:
						obj2 = _008A_009E_0093(num5);
						goto case 4;
					case 4:
						num3 = Math.Atan2(P_0.Y - obj2.Y, P_0.X - obj2.X);
						num4 = Math.Atan2(obj.Y - obj2.Y, obj.X - obj2.X);
						num = 5;
						if (_0089l())
						{
							continue;
						}
						goto case 11;
					case 11:
					case 22:
						obj = _008A_009E_0094(num5);
						goto case 13;
					case 24:
						if (false /* original-file-bool-offset:1384 */)
						{
							num = 3;
							if (_0089l())
							{
								continue;
							}
							goto case 17;
						}
						num9 = TemplatePoint._008B_0088_009E(P_0, _008B_0086_008A);
						/* opaque discard 1 */
						if (!_0089m())
						{
							num = 21;
							goto case 2;
						}
						num = 20;
						goto case 7;
					case 18:
						num6++;
						if (num6 <= 10)
						{
							if (num2 > 1E-07)
							{
								goto case 11;
							}
							goto case 26;
						}
						num = 0;
						break;
					case 8:
						num5 += num2;
						num = 18;
						goto case 18;
					case 5:
						num2 = Math.PI / 2.0 - _008A_009E_009C(num3, num4, _008B_0086_0090);
						goto case 8;
					default:
						num = 22;
						goto case 11;
					case 19:
						return num13;
					case 15:
						return num13;
					case 26:
						return num5;
					case 0:
						break;
					}
					break;
				}
			}
			return num5;
		}

// Original MethodDef: 0x060007AF; Original RVA: 0xC5BA0; Processed MethodDef: 0x060007AE; Evidence: Spiral86.source.txt:82662 + independent IL (decompilation/recovery, not runtime).
		private double _008A_009E_009C(double P_0, double P_1, double P_2 = 1.0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			if (_0089l())
			{
				num = _008A_009E_0090(P_0);
				num2 = _008A_009E_0090(P_1);
				_0089l();
				if (!_0089m() && P_2 <= 0.0)
				{
					num2 = ((num2 < num) ? num2 : (num2 - Math.PI * 2.0));
					return num - num2;
				}
			}
			num2 = ((num2 < num) ? (num2 + Math.PI * 2.0) : num2);
			return num2 - num;
		}

// Original MethodDef: 0x060007B0; Original RVA: 0xC5CC0; Processed MethodDef: 0x060007AF; Evidence: Spiral86.source.txt:82681 + independent IL (decompilation/recovery, not runtime).
		public double _008A_009E_009D(Spiral86 P_0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			num = Math.Atan2(P_0._008B_0086_008A.Y - _008B_0086_008A.Y, P_0._008B_0086_008A.X - _008B_0086_008A.X);
			num2 = TemplatePoint._008B_0088_009E(_008B_0086_008A, P_0._008B_0086_008A);
			num3 = Math.Asin((P_0._008B_0086_0089 - _008B_0086_0089 + (_008B_0086_0088 - P_0._008B_0086_0088) * _008B_0086_008B) / num2);
			num4 = num - num3 - Math.PI / 2.0 + _008B_0086_008D;
			return num4 + ((num4 < 0.0) ? (Math.PI * 2.0) : 0.0);
		}

// Original MethodDef: 0x060007B1; Original RVA: 0xC5D80; Processed MethodDef: 0x060007B0; Evidence: Spiral86.source.txt:82690 + independent IL (decompilation/recovery, not runtime).
		public List<TemplatePoint> _008A_009E_009E(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0, bool P_4 = false, bool P_5 = false)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			double num9 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:1388 */)
			{
				goto IL_0080;
			}
			list = new List<TemplatePoint>();
			if (P_4)
			{
				list.Add(_008B_0086_008A);
				list.Add(TemplatePoint._008B_0089_008E(_008B_0086_008A, _008B_0086_008C * Math.Cos(P_0 + _008B_0086_0088), _008B_0086_008C * Math.Sin(P_0 + _008B_0086_0088)));
			}
			num = Math.Min(P_0, P_1);
			num2 = Math.Max(P_0, P_1);
			num3 = num;
			num4 = P_3 * _008B_0086_0091;
			goto IL_008b;
			IL_008b:
			num5 = num3 * _008B_0086_008B + _008B_0086_0089 + P_2;
			num6 = Math.Sqrt(_008B_0086_008C * _008B_0086_008C + num5 * num5 + 2.0 * _008B_0086_008C * num5 * _008B_0086_008E);
			num7 = num3 - Math.Asin(num5 * _008B_0086_008F / num6);
			num8 = num6 * Math.Cos(num7 + _008B_0086_0088) + _008B_0086_008A.X;
			num9 = num6 * Math.Sin(num7 + _008B_0086_0088) + _008B_0086_008A.Y;
			list.Add(new TemplatePoint(num8, num9));
			goto IL_0080;
			IL_0080:
			num3 += num4;
			if (num3 >= num2)
			{
				num5 = num2 * _008B_0086_008B + _008B_0086_0089 + P_2;
				num6 = Math.Sqrt(_008B_0086_008C * _008B_0086_008C + num5 * num5 + 2.0 * _008B_0086_008C * num5 * _008B_0086_008E);
				num7 = num2 - Math.Asin(num5 * _008B_0086_008F / num6);
				num8 = num6 * Math.Cos(num7 + _008B_0086_0088) + _008B_0086_008A.X;
				num9 = num6 * Math.Sin(num7 + _008B_0086_0088) + _008B_0086_008A.Y;
				list.Add(new TemplatePoint(num8, num9));
				if (P_5)
				{
					list.Add(new TemplatePoint(_008B_0086_008C * Math.Cos(num2 + _008B_0086_0088) + _008B_0086_008A.X, _008B_0086_008C * Math.Sin(num2 + _008B_0086_0088) + _008B_0086_008A.Y));
					list.Add(_008B_0086_008A);
				}
				return list;
			}
			goto IL_008b;
		}

// Original MethodDef: 0x060007B2; Original RVA: 0xC5FF8; Processed MethodDef: 0x060007B1; Evidence: Spiral86.source.txt:82735 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0086_0086(TemplatePoint P_0, double P_1 = 0.0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			if (false /* original-file-bool-offset:1392 */)
			{
				/* opaque discard 1 */
				if (_0089m())
				{
					goto IL_005f;
				}
			}
			else
			{
				num = _008A_009E_0090(Math.Atan2(P_0.Y - _008B_0086_008A.Y, P_0.X - _008B_0086_008A.X));
				num2 = 0.0;
				if (_008B_0086_0090 > 0)
				{
					goto IL_005f;
				}
				num2 = ((!(num > _008B_0086_0088)) ? (_008B_0086_0088 - num) : (Math.PI * 2.0 + _008B_0086_0088 - num));
			}
			goto IL_00af;
			IL_005f:
			num2 = ((!(num < _008B_0086_0088)) ? (num - _008B_0086_0088) : (Math.PI * 2.0 + num - _008B_0086_0088));
			goto IL_00af;
			IL_00af:
			num3 = _008A_009E_0097(num2, P_1);
			if (TemplatePoint._008B_0088_009E(_008A_009E_0093(num3, P_1), _008B_0086_008A) > TemplatePoint._008B_0088_009E(P_0, _008B_0086_008A))
			{
				return num3;
			}
			return -1.0;
		}

// Original MethodDef: 0x060007B3; Original RVA: 0xC61C8; Processed MethodDef: 0x060007B2; Evidence: Spiral86.source.txt:82770 + independent IL (decompilation/recovery, not runtime).
		private void _008B_0086_0087(string P_0, double P_1)
		{

			MessageBox.Show(P_0 + ": " /* string-offset:964 */ + P_1 / _008B_0086_0091);
		}

// Original MethodDef: 0x060007B4; Original RVA: 0xC6204; Processed MethodDef: 0x060007B3; Evidence: Spiral86.source.txt:82775 + independent IL (decompilation/recovery, not runtime).
		static Spiral86()
		{

			// Host licensing not executed in independent arithmetic recovery.
			_008B_0086_0092 = Math.PI / 2.0;
		}

// Original MethodDef: 0x060007B5; Original RVA: 0xC6230; Processed MethodDef: 0x060007B4; Evidence: Spiral86.source.txt:82781 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089l()
		{

			return true;
		}

// Original MethodDef: 0x060007B6; Original RVA: 0xC623C; Processed MethodDef: 0x060007B5; Evidence: Spiral86.source.txt:82786 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089m()
		{

			return false;
		}
	}
}
