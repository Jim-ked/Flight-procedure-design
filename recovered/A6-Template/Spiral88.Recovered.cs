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
	public class Spiral88
	{
		public double _008B_0087_0087;

		public double _008B_0087_0088;

		public TemplatePoint _008B_0087_0089;

		public double _008B_0087_008A;

		public double _008B_0087_008B;

		public double _008B_0087_008C;

		public double _008B_0087_008D;

		public double _008B_0087_008E;

		public double _008B_0087_008F;

		private double _008B_0087_0090;

// Original MethodDef: 0x060007B7; Original RVA: 0xC6248; Processed MethodDef: 0x060007B6; Evidence: Spiral88.source.txt:82817 + independent IL (decompilation/recovery, not runtime).
		public Spiral88()
		{

			_0089o();
			if (_0089n())
			{
				_008B_0087_008F = Math.PI / 180.0;
				_008B_0087_0090 = Math.PI / 2.0;
			}
			// object constructor emitted automatically by C#
		}

// Original MethodDef: 0x060007B8; Original RVA: 0xC62F0; Processed MethodDef: 0x060007B7; Evidence: Spiral88.source.txt:82828 + independent IL (decompilation/recovery, not runtime).
		public Spiral88(TurnInput P_0, TemplatePoint P_1, double P_2 = 0.0, double P_3 = 0.0)
		{
			int num = default(int); // IL InitLocals

			num = 9;
			if (_0089n())
			{
				while (true)
				{
					switch (num)
					{
					case 9:
						_008B_0087_008F = Math.PI / 180.0;
						num = 6;
						goto case 6;
					case 6:
						_008B_0087_0090 = Math.PI / 2.0;
						num = 3;
						if (!_0089n())
						{
						}
						goto case 3;
					case 3:
						// object constructor emitted automatically by C#
						goto case 4;
					case 4:
						_008B_0087_008A = P_0._008A_009D_009E;
						num = 0;
						goto case 0;
					case 0:
						_008B_0087_008B = P_0._008A_009D_009D;
						goto default;
					default:
						/* opaque discard 1 */
						if (_0089o())
						{
							num = 7;
							if (!_0089o())
							{
								continue;
							}
							goto case 10;
						}
						num = 2;
						goto case 2;
					case 2:
					case 5:
						_008B_0087_008C = P_0._008A_009E_0086;
						num = 10;
						goto case 10;
					case 10:
						_008B_0087_008D = Math.Cos(_008B_0087_008C);
						_008B_0087_008E = Math.Sin(_008B_0087_008C);
						num = 1;
						break;
					case 1:
						break;
					case 7:
					case 8:
						goto IL_0118;
					case 11:
						return;
					}
					break;
				}
			}
			_008B_0087_0089 = P_1;
			goto IL_0118;
			IL_0118:
			_008B_0087_0087 = P_2;
			_008B_0087_0088 = P_3;
		}

// Original MethodDef: 0x060007B9; Original RVA: 0xC646C; Processed MethodDef: 0x060007B8; Evidence: Spiral88.source.txt:82899 + independent IL (decompilation/recovery, not runtime).
		public List<TemplatePoint> _008B_0086_0093(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0, bool P_4 = false, bool P_5 = false)
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

			if (false /* original-file-bool-offset:1396 */)
			{
				goto IL_0080;
			}
			list = new List<TemplatePoint>();
			if (P_4)
			{
				list.Add(_008B_0087_0089);
				list.Add(TemplatePoint._008B_0089_008E(_008B_0087_0089, _008B_0087_008B * Math.Cos(P_0 + _008B_0087_0087), _008B_0087_008B * Math.Sin(P_0 + _008B_0087_0087)));
			}
			num = Math.Min(P_0, P_1);
			num2 = Math.Max(P_0, P_1);
			num3 = num;
			num4 = P_3 * _008B_0087_008F;
			goto IL_008b;
			IL_008b:
			num5 = num3 * _008B_0087_008A + _008B_0087_0088 + P_2;
			num6 = Math.Sqrt(_008B_0087_008B * _008B_0087_008B + num5 * num5 + 2.0 * _008B_0087_008B * num5 * _008B_0087_008D);
			num7 = num3 - Math.Asin(num5 * _008B_0087_008E / num6);
			num8 = num6 * Math.Cos(num7 + _008B_0087_0087) + _008B_0087_0089.X;
			num9 = num6 * Math.Sin(num7 + _008B_0087_0087) + _008B_0087_0089.Y;
			list.Add(new TemplatePoint(num8, num9));
			goto IL_0080;
			IL_0080:
			num3 += num4;
			if (num3 >= num2)
			{
				num5 = num2 * _008B_0087_008A + _008B_0087_0088 + P_2;
				num6 = Math.Sqrt(_008B_0087_008B * _008B_0087_008B + num5 * num5 + 2.0 * _008B_0087_008B * num5 * _008B_0087_008D);
				num7 = num2 - Math.Asin(num5 * _008B_0087_008E / num6);
				num8 = num6 * Math.Cos(num7 + _008B_0087_0087) + _008B_0087_0089.X;
				num9 = num6 * Math.Sin(num7 + _008B_0087_0087) + _008B_0087_0089.Y;
				list.Add(new TemplatePoint(num8, num9));
				if (P_5)
				{
					list.Add(new TemplatePoint(_008B_0087_008B * Math.Cos(num2 + _008B_0087_0087) + _008B_0087_0089.X, _008B_0087_008B * Math.Sin(num2 + _008B_0087_0087) + _008B_0087_0089.Y));
					list.Add(_008B_0087_0089);
				}
				return list;
			}
			goto IL_008b;
		}

// Original MethodDef: 0x060007BA; Original RVA: 0xC66E4; Processed MethodDef: 0x060007B9; Evidence: Spiral88.source.txt:82944 + independent IL (decompilation/recovery, not runtime).
		public List<TemplatePoint> _008B_0086_0094(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0)
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

			if (false /* original-file-bool-offset:1400 */)
			{
				goto IL_0022;
			}
			list = new List<TemplatePoint>();
			num = P_0;
			num2 = P_1;
			num3 = P_3 * _008B_0087_008F;
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
				num4 = num2 * _008B_0087_008A + _008B_0087_0088 + P_2;
				num5 = Math.Sqrt(_008B_0087_008B * _008B_0087_008B + num4 * num4 + 2.0 * _008B_0087_008B * num4 * _008B_0087_008D);
				num6 = num2 - Math.Asin(num4 * _008B_0087_008E / num5);
				num7 = num5 * Math.Cos(num6 + _008B_0087_0087) + _008B_0087_0089.X;
				num8 = num5 * Math.Sin(num6 + _008B_0087_0087) + _008B_0087_0089.Y;
				list.Add(new TemplatePoint(num7, num8));
				return list;
			}
			goto IL_002d;
			IL_002d:
			num4 = num * _008B_0087_008A + _008B_0087_0088 + P_2;
			num5 = Math.Sqrt(_008B_0087_008B * _008B_0087_008B + num4 * num4 + 2.0 * _008B_0087_008B * num4 * _008B_0087_008D);
			num6 = num - Math.Asin(num4 * _008B_0087_008E / num5);
			num7 = num5 * Math.Cos(num6 + _008B_0087_0087) + _008B_0087_0089.X;
			num8 = num5 * Math.Sin(num6 + _008B_0087_0087) + _008B_0087_0089.Y;
			list.Add(new TemplatePoint(num7, num8));
			goto IL_0022;
		}

// Original MethodDef: 0x060007BB; Original RVA: 0xC6894; Processed MethodDef: 0x060007BA; Evidence: Spiral88.source.txt:82983 + independent IL (decompilation/recovery, not runtime).
		public TemplatePoint _008B_0086_0095(double P_0, double P_1 = 0.0, bool P_2 = true)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			int num4 = default(int); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			if (false /* original-file-bool-offset:1404 */)
			{
				/* opaque discard 0 */
				if (_0089n())
				{
					goto IL_006f;
				}
			}
			else
			{
				num = P_0 * _008B_0087_008A + _008B_0087_0088 + P_1;
				num2 = Math.Sqrt(_008B_0087_008B * _008B_0087_008B + num * num + 2.0 * _008B_0087_008B * num * _008B_0087_008D);
			}
			num3 = P_0 - Math.Asin(num * _008B_0087_008E / num2);
			goto IL_006f;
			IL_006f:
			num4 = (P_2 ? 1 : (-1));
			num5 = num2 * Math.Cos((double)num4 * num3 + _008B_0087_0087) + _008B_0087_0089.X;
			num6 = num2 * Math.Sin((double)num4 * num3 + _008B_0087_0087) + _008B_0087_0089.Y;
			return new TemplatePoint(num5, num6);
		}

// Original MethodDef: 0x060007BC; Original RVA: 0xC6A00; Processed MethodDef: 0x060007BB; Evidence: Spiral88.source.txt:83009 + independent IL (decompilation/recovery, not runtime).
		public TemplatePoint _008B_0086_0096(double P_0, double P_1 = 0.0, bool P_2 = true)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			num = (P_2 ? 1 : (-1));
			num2 = _008B_0087_008B * Math.Cos(num * P_0 + _008B_0087_0087) + _008B_0087_0089.X;
			num3 = _008B_0087_008B * Math.Sin(num * P_0 + _008B_0087_0087) + _008B_0087_0089.Y;
			return new TemplatePoint(num2, num3);
		}

// Original MethodDef: 0x060007BD; Original RVA: 0xC6A78; Processed MethodDef: 0x060007BC; Evidence: Spiral88.source.txt:83017 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0086_0097(LineCarrier P_0, double P_1 = 0.0, bool P_2 = true)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			int num7 = default(int); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			if (false /* original-file-bool-offset:1408 */)
			{
				if (!_0089o())
				{
					goto IL_011d;
				}
			}
			else
			{
				num = P_0._008B_0088_0094() + _008B_0087_0087 + _008B_0087_0090 + _008B_0087_008C;
				if (P_2)
				{
					num2 = 0.0;
					num3 = num;
				}
				else
				{
					num2 = num;
					num3 = num + _008B_0087_0090;
					if (_0089o())
					{
						goto IL_011d;
					}
				}
			}
			obj = new LineCarrier();
			obj2 = _008B_0086_0095(num, P_1);
			obj._008B_0088_008F(obj2, P_0._008B_0088_0094());
			_0089n();
			if (_0089o())
			{
				goto IL_00ab;
			}
			goto IL_0112;
			IL_0112:
			num4 = P_0._008B_0088_0092(obj2);
			goto IL_00ab;
			IL_011d:
			// IL local declared at method entry
			while (true)
			{
				num5 = (num2 + num3) / 2.0;
				if (!_0089n())
				{
					break;
				}
				obj2 = _008B_0086_0095(num5, P_1);
				num6 = obj._008B_0088_0092(obj2);
				if (num6 > num4)
				{
					num2 = (P_2 ? num5 : num2);
					num3 = (P_2 ? num3 : num5);
				}
				else
				{
					num2 = (P_2 ? num2 : num5);
					num3 = (P_2 ? num5 : num3);
				}
				if (num7++ <= 20)
				{
					if (!(Math.Abs(num6 - num4) > 0.01))
					{
						return num5;
					}
					continue;
				}
				return num5;
			}
			goto IL_0112;
			IL_00ab:
			num7 = 0;
			goto IL_011d;
		}

// Original MethodDef: 0x060007BE; Original RVA: 0xC6D04; Processed MethodDef: 0x060007BD; Evidence: Spiral88.source.txt:83096 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0086_0098(LineCarrier P_0, double P_1, double P_2, double P_3, double P_4 = 0.0, bool P_5 = true)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals

			// IL local declared at method entry
			if (_0089n())
			{
				if (false /* original-file-bool-offset:1412 */)
				{
					if (_0089n())
					{
						goto IL_006d;
					}
				}
				else
				{
					Console.WriteLine("<<getIntersectSita>>\n search from: {0},\n  to {1}." /* string-offset:7452 */, P_2 / _008B_0087_008F, P_3 / _008B_0087_008F);
					num = 0;
				}
				goto IL_00b1;
			}
			goto IL_00dc;
			IL_0071:
			// IL local declared at method entry
			P_2 = num2;
			if (!P_5)
			{
				goto IL_0077;
			}
			num3 = P_3;
			goto IL_007c;
			IL_0095:
			// IL local declared at method entry
			// IL local declared at method entry
			if (num++ <= 20)
			{
				if (Math.Abs(num4 - P_1) <= 0.01)
				{
					return num5;
				}
				goto IL_00b1;
			}
			goto IL_00dc;
			IL_006d:
			num2 = P_2;
			goto IL_0071;
			IL_00b1:
			num5 = (P_2 + P_3) / 2.0;
			obj = _008B_0086_0095(num5, P_4);
			if (_0089n())
			{
				num4 = P_0._008B_0088_0092(obj);
				if (num4 > P_1)
				{
					if (!P_5)
					{
						_0089n();
						if (!_0089o())
						{
							goto IL_006d;
						}
						goto IL_00dc;
					}
					num2 = num5;
					goto IL_0071;
				}
				P_2 = (P_5 ? P_2 : num5);
				P_3 = (P_5 ? num5 : P_3);
				goto IL_0095;
			}
			goto IL_0077;
			IL_007c:
			P_3 = num3;
			goto IL_0095;
			IL_0077:
			num3 = num5;
			goto IL_007c;
			IL_00dc:
			return num5;
		}

// Original MethodDef: 0x060007BF; Original RVA: 0xC6EF4; Processed MethodDef: 0x060007BE; Evidence: Spiral88.source.txt:83175 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0086_0099(TemplatePoint P_0, double P_1 = 0.0)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			int num9 = default(int); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals

			num = 8;
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
				if (!false /* original-file-bool-offset:1416 */)
				{
					num2 = (_008B_0087_0087 + Math.PI * 2.0) % (Math.PI * 2.0);
					num = 9;
					if (_0089n())
					{
						goto IL_0039;
					}
					goto IL_0097;
				}
				goto IL_019a;
				IL_019a:
				obj = TemplatePoint._008B_0089_0088(TemplatePoint._008B_0089_0088(obj2, TemplatePoint._008B_0089_0087(_008B_0087_008B, num3 + num2)), TemplatePoint._008B_0089_0087(_008B_0087_008A * num3 + _008B_0087_0088 + P_1, num3 - _008B_0087_008C + num2));
				num4 = _008B_0086_009A(Math.Atan2(P_0.Y - obj.Y, P_0.X - obj.X), num2);
				num = 6;
				goto IL_0145;
				IL_0097:
				num5 = Math.Atan2(P_0.Y - obj2.Y, P_0.X - obj2.X);
				num = 2;
				if (_0089n())
				{
					goto IL_0039;
				}
				goto IL_0140;
				IL_0039:
				switch (num)
				{
				case 9:
					obj2 = _008B_0087_0089;
					num6 = TemplatePoint._008B_0088_009E(P_0, obj2);
					num = 4;
					break;
				case 4:
					break;
				case 8:
					continue;
				case 2:
					goto IL_00e0;
				case 0:
				case 5:
					goto IL_012e;
				default:
					goto IL_0140;
				case 6:
					goto IL_0145;
				case 1:
					goto IL_016b;
				case 11:
					goto IL_017b;
				case 3:
				case 10:
					goto IL_0181;
				case 7:
					goto IL_019a;
				case 13:
					goto end_IL_00cc;
				}
				goto IL_0097;
				IL_00e0:
				if (num6 < TemplatePoint._008B_0088_009E(_008B_0086_0095(_008B_0086_009C(num5, P_1), P_1), obj2))
				{
					return num5;
				}
				num7 = Math.Acos(_008B_0087_008B / num6);
				_0089o();
				if (_0089n())
				{
					num = 0;
					goto IL_012e;
				}
				num = 3;
				goto IL_0181;
				IL_0145:
				num8 = _008B_0086_009A(num4, num3 - _008B_0087_008C + Math.PI / 2.0);
				num = 1;
				goto IL_016b;
				IL_016b:
				num3 += num8;
				num = 11;
				goto IL_017b;
				IL_017b:
				num9++;
				goto IL_0181;
				IL_012e:
				num3 = _008B_0086_009A(_008B_0086_009A(num5, num7), num2);
				goto IL_0140;
				IL_0181:
				if (num9 <= 10)
				{
					if (num8 <= 1E-07)
					{
						num = 13;
						break;
					}
					goto IL_019a;
				}
				return num3;
				IL_0140:
				num9 = 0;
				goto IL_019a;
				continue;
				end_IL_00cc:
				break;
			}
			return num3;
		}

// Original MethodDef: 0x060007C0; Original RVA: 0xC7174; Processed MethodDef: 0x060007BF; Evidence: Spiral88.source.txt:83296 + independent IL (decompilation/recovery, not runtime).
		private double _008B_0086_009A(double P_0, double P_1)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			num = (P_0 + Math.PI * 2.0) % (Math.PI * 2.0);
			/* opaque discard 1 */
			// IL local declared at method entry
			if (!_0089o())
			{
				num2 = (P_1 + Math.PI * 2.0) % (Math.PI * 2.0);
			}
			if (num < num2)
			{
				return num - num2 + Math.PI * 2.0;
			}
			return num - num2;
		}

// Original MethodDef: 0x060007C1; Original RVA: 0xC7244; Processed MethodDef: 0x060007C0; Evidence: Spiral88.source.txt:83312 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0086_009B(double P_0, double P_1 = 0.0)
		{

			return Math.Sqrt(_008B_0087_008B * _008B_0087_008B + (P_0 * _008B_0087_008A + _008B_0087_0088 + P_1) * (P_0 * _008B_0087_008A + _008B_0087_0088 + P_1) + 2.0 * _008B_0087_008B * (P_0 * _008B_0087_008A + _008B_0087_0088 + P_1) * _008B_0087_008D);
		}

// Original MethodDef: 0x060007C2; Original RVA: 0xC72B8; Processed MethodDef: 0x060007C1; Evidence: Spiral88.source.txt:83317 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0086_009C(double P_0, double P_1 = 0.0)
		{
			double num = default(double); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:1420 */)
			{
				goto IL_0057;
			}
			P_0 = (P_0 + Math.PI * 4.0) % (Math.PI * 2.0);
			num = P_0;
			num2 = 0;
			goto IL_007e;
			IL_0057:
			// IL local declared at method entry
			num += num3;
			/* opaque discard 0 */
			if (_0089n())
			{
				num2++;
			}
			if (num2 <= 20)
			{
				if (num3 <= 1E-09)
				{
					return num;
				}
				goto IL_007e;
			}
			return num;
			IL_007e:
			num4 = Math.Sqrt(_008B_0087_008B * _008B_0087_008B + (num * _008B_0087_008A + _008B_0087_0088 + P_1) * (num * _008B_0087_008A + _008B_0087_0088 + P_1) + 2.0 * _008B_0087_008B * (num * _008B_0087_008A + _008B_0087_0088 + P_1) * _008B_0087_008D);
			// IL local declared at method entry
			do
			{
				num5 = num - Math.Asin((num * _008B_0087_008A + _008B_0087_0088 + P_1) * _008B_0087_008E / num4);
			}
			while (_0089o());
			num3 = P_0 - num5;
			goto IL_0057;
		}

// Original MethodDef: 0x060007C3; Original RVA: 0xC7480; Processed MethodDef: 0x060007C2; Evidence: Spiral88.source.txt:83356 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0086_009D(Spiral88 P_0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			num = Math.Atan2(P_0._008B_0087_0089.Y - _008B_0087_0089.Y, P_0._008B_0087_0089.X - _008B_0087_0089.X);
			num2 = TemplatePoint._008B_0088_009E(_008B_0087_0089, P_0._008B_0087_0089);
			num3 = Math.Asin((P_0._008B_0087_0088 - _008B_0087_0088 + (_008B_0087_0087 - P_0._008B_0087_0087) * _008B_0087_008A) / num2);
			return (num - num3 - Math.PI / 2.0 + _008B_0087_008C + Math.PI * 2.0) % (Math.PI * 2.0);
		}

// Original MethodDef: 0x060007C4; Original RVA: 0xC752C; Processed MethodDef: 0x060007C3; Evidence: Spiral88.source.txt:83364 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_0086_009E(Spiral88 P_0, Spiral88 P_1, double P_2, double P_3, double P_4 = 0.0)
		{

			return new List<TemplatePoint>
			{
				P_0._008B_0086_0095(P_2, P_4),
				P_1._008B_0086_0095(P_3, P_4)
			};
		}

// Original MethodDef: 0x060007C5; Original RVA: 0xC755C; Processed MethodDef: 0x060007C4; Evidence: Spiral88.source.txt:83373 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0087_0086(double P_0)
		{

			return P_0 / _008B_0087_008F;
		}

// Original MethodDef: 0x060007C6; Original RVA: 0xC7570; Processed MethodDef: 0x060007C5; Evidence: Spiral88.source.txt:83378 + independent IL (decompilation/recovery, not runtime).
		static Spiral88()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x060007C7; Original RVA: 0xC758C; Processed MethodDef: 0x060007C6; Evidence: Spiral88.source.txt:83383 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089n()
		{

			return true;
		}

// Original MethodDef: 0x060007C8; Original RVA: 0xC7598; Processed MethodDef: 0x060007C7; Evidence: Spiral88.source.txt:83388 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089o()
		{

			return false;
		}
	}
}
