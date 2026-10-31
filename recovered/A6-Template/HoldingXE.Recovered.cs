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
	public class HoldingXE
	{
		public TurnInput _0088_008B_0089;

		public double _0088_008B_008A;

		public double _0088_008B_008B;

		public double _0088_008B_008C;

		public double _0088_008B_008D;

		public double _0088_008B_008E;

		public TemplatePoint _0088_008B_008F;

		private TemplatePoint _0088_008B_0090;

		private TemplatePoint _0088_008B_0091;

		private TemplatePoint _0088_008B_0092;

		private TemplatePoint _0088_008B_0093;

		private TemplatePoint _0088_008B_0094;

		private TemplatePoint _0088_008B_0095;

		private double _0088_008B_0096;

		private double _0088_008B_0097;

		private Spiral86 _0088_008B_0098;

		private Spiral86 _0088_008B_0099;

		public string _0088_008B_009A;

		public double _0088_008B_009B = Math.PI / 180.0;

		public double _0088_008B_009C;

		public double _0088_008B_009D;

		public List<List<TemplatePoint>> _0088_008B_009E;

		public List<List<TemplatePoint>> _0088_008C_0086;

		public List<List<TemplatePoint>> _0088_008C_0087;

		public List<TemplatePoint> _0088_008C_0088;

// Original MethodDef: 0x060003BE; Original RVA: 0x5FD44; Processed MethodDef: 0x060003BD; Evidence: HoldingXE.source.txt:39454 + independent IL (decompilation/recovery, not runtime).
		public HoldingXE(TurnInput P_0, double P_1 = 1.0)
		{

			/* opaque discard 1 */
			if (!_0087e())
			{
				_0088_008B_009C = Math.PI / 4.0;
			}
			else if (_0087e())
			{
				goto IL_0040;
			}
			_0088_008B_009D = Math.PI / 2.0;
			goto IL_0040;
			IL_0040:
			_0088_008B_009E = new List<List<TemplatePoint>>();
			_0088_008C_0086 = new List<List<TemplatePoint>>();
			_0088_008C_0087 = new List<List<TemplatePoint>>();
			_0088_008C_0088 = new List<TemplatePoint>();
			// object constructor emitted automatically by C#
			_0088_008A_009C(P_0, P_1);
			_0088_008A_009B();
		}

// Original MethodDef: 0x060003BF; Original RVA: 0x5FE88; Processed MethodDef: 0x060003BE; Evidence: HoldingXE.source.txt:39477 + independent IL (decompilation/recovery, not runtime).
		public void _0088_008A_009B()
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			int num = default(int); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			while (true /* original-file-bool-offset:708 */)
			{
				num = 4;
				while (true)
				{
					_0088_008C_0088 = new List<TemplatePoint>();
					_0087e();
					if (!_0087d())
					{
						goto IL_01a7;
					}
					num = 0;
					goto IL_0081;
					IL_0127:
					while (true)
					{
						IL_0127_2:
						_0088_008C_0088.Add(obj);
						num = 8;
						if (!_0087d())
						{
							break;
						}
						while (true)
						{
							switch (num)
							{
							case 4:
								break;
							default:
								num = 3;
								if (_0087d())
								{
									continue;
								}
								goto IL_0127_2;
							case 0:
							case 2:
								goto IL_0081;
							case 6:
								goto IL_00e4;
							case 7:
								goto IL_0127_2;
							case 3:
								goto IL_014b;
							case 9:
								goto IL_017a;
							case 5:
							case 10:
								goto IL_01a7;
							case 11:
								goto end_IL_000f;
							case 8:
								obj2 = TemplatePoint._008B_0089_0088(obj, TemplatePoint._008B_0089_0087(_0088_008B_0089._008A_009D_009D, _0088_008B_009D));
								num = 1;
								goto case 1;
							case 1:
								_0088_008B_0088(ref _0088_008C_0088, obj2, _0088_008B_0089._008A_009D_009D, -90.0, 180.0);
								_0088_008C_0088.Add(_0088_008B_0090);
								return;
							case 12:
								return;
							}
							break;
						}
						break;
					}
					continue;
					IL_0081:
					_0088_008B_0090 = new TemplatePoint(0.0, 0.0);
					_0088_008C_0088.Add(_0088_008B_0090);
					obj2 = TemplatePoint._008B_0089_0088(_0088_008B_0090, TemplatePoint._008B_0089_0087(_0088_008B_0089._008A_009D_009D, 0.0 - _0088_008B_009D));
					goto IL_00e4;
					IL_00e4:
					_0088_008B_0088(ref _0088_008C_0088, obj2, _0088_008B_0089._008A_009D_009D, 90.0, 180.0);
					num = 9;
					if (!_0087d())
					{
						goto IL_0127;
					}
					goto IL_017a;
					IL_017a:
					obj3 = new TemplatePoint(0.0, -2.0 * _0088_008B_0089._008A_009D_009D);
					goto IL_01a7;
					IL_01a7:
					_0088_008C_0088.Add(obj3);
					goto IL_014b;
					IL_014b:
					obj = TemplatePoint._008B_0089_0088(obj3, new TemplatePoint(_0088_008B_008C, 0.0));
					num = 7;
					goto IL_0127;
					continue;
					end_IL_000f:
					break;
				}
			}
		}

// Original MethodDef: 0x060003C0; Original RVA: 0x6011C; Processed MethodDef: 0x060003BF; Evidence: HoldingXE.source.txt:39580 + independent IL (decompilation/recovery, not runtime).
		public void _0088_008A_009C(TurnInput P_0, double P_1 = 1.0)
		{
			int num = default(int); // IL InitLocals
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			/* opaque discard 1 */
			// IL local declared at method entry
			if (!_0087e())
			{
				num = 16;
				goto IL_01ca;
			}
			num = 15;
			if (!_0087e())
			{
				goto IL_002b;
			}
			goto IL_044f;
			IL_002b:
			// IL local declared at method entry
			switch (num)
			{
			case 20:
				break;
			case 19:
				goto IL_00ee;
			case 6:
				goto IL_016e;
			default:
				num = 10;
				goto IL_044f;
			case 0:
			case 16:
				goto IL_01ca;
			case 1:
			case 15:
				goto IL_01d9;
			case 8:
				goto IL_0204;
			case 5:
				goto IL_0228;
			case 4:
				goto IL_0281;
			case 13:
				goto IL_02a7;
			case 17:
				goto IL_02d6;
			case 18:
				goto IL_0303;
			case 3:
				goto IL_0377;
			case 2:
				goto IL_0404;
			case 10:
				goto IL_044f;
			case 12:
				list = new List<TemplatePoint>();
				num = 9;
				goto case 9;
			case 9:
				list.Add(_0088_008B_0090);
				num = 11;
				goto case 11;
			case 11:
				_0088_008B_0088(ref list, _0088_008B_0094, _0088_008B_0089._008A_009D_009D, 180.0, 90.0);
				num = 14;
				goto case 14;
			case 14:
				_0088_008B_0088(ref list, _0088_008B_0095, _0088_008B_0089._008A_009D_009D, 270.0, 180.0);
				goto case 7;
			case 7:
				_0088_008C_0086.Add(list);
				_0088_008B_008F = _0088_008B_0099._008A_009E_0093(_0088_008B_009D + _0088_008B_0089._008A_009E_0086);
				num = 21;
				return;
			case 21:
				return;
			}
			goto IL_0091;
			IL_0091:
			// IL local declared at method entry
			do
			{
				_0088_008A_009D(_0088_008B_0098._008A_009E_0093(num2 - _0088_008B_0098._008B_0086_0088), _0088_008B_0099._008A_009E_0093(num2 - _0088_008B_0099._008B_0086_0088));
				num = 12;
			}
			while (!_0087d());
			goto IL_002b;
			IL_01ca:
			if (!true /* original-file-bool-offset:712 */)
			{
				return;
			}
			goto IL_01d9;
			IL_01d9:
			_0088_008B_0089 = P_0;
			_0088_008B_008A = _0088_008B_0089._008A_009D_009A / 3.6;
			num = 8;
			goto IL_0204;
			IL_0204:
			_0088_008B_008B = _0088_008B_0089._008A_009D_0098 / 3.6;
			num = 5;
			goto IL_0228;
			IL_0228:
			_0088_008B_008E = 5.0 * _0088_008B_009B;
			_0088_008B_008D = P_1 * 60.0;
			_0088_008B_008C = _0088_008B_008A * _0088_008B_008D;
			_0088_008B_0096 = 11.0 * _0088_008B_008A;
			num = 4;
			goto IL_0281;
			IL_0281:
			_0088_008B_0097 = (_0088_008B_008D + 15.0) * _0088_008B_008A;
			num = 13;
			goto IL_02a7;
			IL_02a7:
			_0088_008B_0090 = new TemplatePoint(0.0, 0.0);
			num = 17;
			goto IL_02d6;
			IL_02d6:
			_0088_008B_0091 = new TemplatePoint(0.0, 0.0 - _0088_008B_0096);
			num = 18;
			goto IL_0303;
			IL_0303:
			_0088_008B_0092 = new TemplatePoint(_0088_008B_0089._008A_009D_009D, 0.0 - _0088_008B_0096 - _0088_008B_0089._008A_009D_009D);
			_0088_008B_0093 = new TemplatePoint(_0088_008B_0089._008A_009D_009D + _0088_008B_0097, 0.0 - _0088_008B_0096 - _0088_008B_0089._008A_009D_009D);
			num = 3;
			goto IL_0377;
			IL_0377:
			_0088_008B_0094 = new TemplatePoint(_0088_008B_0089._008A_009D_009D, 0.0 - _0088_008B_0096);
			_0088_008B_0095 = new TemplatePoint(_0088_008B_0089._008A_009D_009D + _0088_008B_0097, 0.0 - _0088_008B_0096);
			_0088_008B_0098 = new Spiral86(_0088_008B_0089, _0088_008B_0094, Math.PI, 11.0 * _0088_008B_008B);
			num = 2;
			goto IL_0404;
			IL_0404:
			_0088_008B_0099 = new Spiral86(_0088_008B_0089, _0088_008B_0095, 4.71238898038469, (_0088_008B_008D + 26.0 + _0088_008B_009D / _0088_008B_0089._008A_009D_009C) * _0088_008B_008B);
			goto IL_044f;
			IL_044f:
			num2 = _0088_008B_0098._008A_009E_009D(_0088_008B_0099);
			_0088_008C_0087.Add(_0088_008B_0098._008A_009E_009E(0.0, num2 - _0088_008B_0098._008B_0086_0088, 0.0, 1.0, true, true));
			goto IL_016e;
			IL_016e:
			_0088_008C_0087.Add(_0088_008B_0099._008A_009E_009E(num2 - _0088_008B_0099._008B_0086_0088, _0088_008B_009D + _0088_008B_0089._008A_009E_0086, 0.0, 1.0, true, true));
			goto IL_00ee;
			IL_00ee:
			_0088_008C_0087.Add(_0088_008B_0099._008A_009E_009E(_0088_008B_009D + _0088_008B_0089._008A_009E_0086, _0088_008B_009D + _0088_008B_009C));
			_0088_008A_009D(_0088_008B_0090, _0088_008B_0098._008A_009E_0093(0.0));
			num = 20;
			goto IL_0091;
		}

// Original MethodDef: 0x060003C1; Original RVA: 0x60704; Processed MethodDef: 0x060003C0; Evidence: HoldingXE.source.txt:39727 + independent IL (decompilation/recovery, not runtime).
		protected void _0088_008A_009D(TemplatePoint P_0, TemplatePoint P_1)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			if (!_0087e())
			{
				list.Add(P_0);
				/* opaque discard 0 */
				if (!_0087d())
				{
					goto IL_0029;
				}
			}
			list.Add(P_1);
			goto IL_0029;
			IL_0029:
			_0088_008B_009E.Add(list);
		}

// Original MethodDef: 0x060003C2; Original RVA: 0x607C0; Processed MethodDef: 0x060003C1; Evidence: HoldingXE.source.txt:39745 + independent IL (decompilation/recovery, not runtime).
		protected void _0088_008A_009E(TemplatePoint P_0, TemplatePoint P_1)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			_0087d();
			// IL local declared at method entry
			if (!_0087e())
			{
				list = new List<TemplatePoint>();
				list.Add(P_0);
			}
			do
			{
				list.Add(P_1);
				_0088_008C_0086.Add(list);
			}
			while (!_0087d());
		}

// Original MethodDef: 0x060003C3; Original RVA: 0x6088C; Processed MethodDef: 0x060003C2; Evidence: HoldingXE.source.txt:39762 + independent IL (decompilation/recovery, not runtime).
		private List<TemplatePoint> _0088_008B_0086(TemplatePoint P_0, TemplatePoint P_1, double P_2, double P_3 = Math.PI * 3.0 / 5.0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:716 */)
			{
				goto IL_0094;
			}
			list = new List<TemplatePoint>();
			num = Math.Atan2(P_1.Y - P_0.Y, P_1.X - P_0.X) - P_3 / 2.0;
			num2 = num + P_3;
			num3 = 2.0 * _0088_008B_009B;
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

// Original MethodDef: 0x060003C4; Original RVA: 0x6097C; Processed MethodDef: 0x060003C3; Evidence: HoldingXE.source.txt:39789 + independent IL (decompilation/recovery, not runtime).
		private void _0088_008B_0087(List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals

			if (!true /* original-file-bool-offset:720 */)
			{
				return;
			}
			num = P_3 + P_4;
			if (P_4 > 0.0)
			{
				num2 = 2.0 * _0088_008B_009B;
				for (double num3 = P_3 + num2; num3 < num; num3 += num2)
				{
					num4 = P_2 * Math.Cos(num3) + P_1.X;
					num5 = P_2 * Math.Sin(num3) + P_1.Y;
					P_0.Add(new TemplatePoint(num4, num5));
				}
			}
			else
			{
				num2 = -2.0 * _0088_008B_009B;
				for (double num6 = P_3 + num2; num6 > num; num6 += num2)
				{
					num7 = P_2 * Math.Cos(num6) + P_1.X;
					num8 = P_2 * Math.Sin(num6) + P_1.Y;
					P_0.Add(new TemplatePoint(num7, num8));
				}
			}
		}

// Original MethodDef: 0x060003C5; Original RVA: 0x60A80; Processed MethodDef: 0x060003C4; Evidence: HoldingXE.source.txt:39818 + independent IL (decompilation/recovery, not runtime).
		public void _0088_008B_0088(ref List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4, double P_5 = 1.0)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			num = 3;
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			while (true)
			{
				if (!false /* original-file-bool-offset:724 */)
				{
					num2 = Math.Abs(P_5);
					goto IL_0081;
				}
				num = 8;
				if (_0087e())
				{
					goto IL_0018;
				}
				goto IL_0042;
				IL_0125:
				if (!(P_5 > 0.0))
				{
					num = 7;
					goto IL_013b;
				}
				num3 = P_3 + P_4;
				goto IL_0147;
				IL_0158:
				obj = new TemplatePoint(P_2 * Math.Cos(num4 * _0088_008B_009B), P_2 * Math.Sin(num4 * _0088_008B_009B));
				P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
				num = 12;
				break;
				IL_0081:
				num5 = P_3;
				num = 0;
				goto IL_0018;
				IL_0018:
				num6 = 0.0;
				/* opaque discard 1 */
				if (_0087e())
				{
					num = 9;
					if (!_0087e())
					{
						goto IL_0042;
					}
					goto IL_0125;
				}
				num = 6;
				goto IL_0116;
				IL_013b:
				num3 = P_3 - P_4;
				goto IL_0147;
				IL_0042:
				switch (num)
				{
				case 0:
					break;
				case 2:
					goto IL_0081;
				case 3:
					continue;
				default:
					num = 1;
					goto IL_0116;
				case 5:
				case 9:
					goto IL_00cc;
				case 1:
				case 4:
				case 6:
					goto IL_0116;
				case 10:
					goto IL_0125;
				case 7:
					goto IL_013b;
				case 11:
					goto IL_0158;
				case 8:
				case 12:
					return;
				}
				goto IL_0018;
				IL_00cc:
				P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
				num5 += P_5;
				num6 += num2;
				goto IL_0116;
				IL_0116:
				if (num6 < P_4)
				{
					obj = new TemplatePoint(P_2 * Math.Cos(num5 * _0088_008B_009B), P_2 * Math.Sin(num5 * _0088_008B_009B));
					goto IL_00cc;
				}
				num = 10;
				goto IL_0125;
				IL_0147:
				num4 = num3;
				if (num5 - P_5 != num4)
				{
					num = 11;
					goto IL_0158;
				}
				break;
			}
		}

// Original MethodDef: 0x060003C6; Original RVA: 0x60C70; Processed MethodDef: 0x060003C5; Evidence: HoldingXE.source.txt:39927 + independent IL (decompilation/recovery, not runtime).
		public override string ToString()
		{

			if (false /* original-file-bool-offset:728 */)
			{
				/* opaque discard 1 */
				if (!_0087e())
				{
					goto IL_00a4;
				}
				if (!_0087d())
				{
				}
			}
			else
			{
				_0088_008B_009A = "======= HoldingXE Parameters=========\n" /* string-offset:5324 */;
			}
			_0088_008B_009A = _0088_008B_009A + "v = " /* string-offset:5272 */ + Math.Ceiling(_0088_008B_008A) + "m/s\n" /* string-offset:1504 */;
			_0088_008B_009A = _0088_008B_009A + "w = " /* string-offset:5276 */ + Math.Ceiling(_0088_008B_008B) + "m/s\n" /* string-offset:1504 */;
			goto IL_00a4;
			IL_00a4:
			_0088_008B_009A = _0088_008B_009A + "L = " /* string-offset:1536 */ + Math.Ceiling(_0088_008B_008C) + " m\n" /* string-offset:5280 */;
			return _0088_008B_009A;
		}

// Original MethodDef: 0x060003C7; Original RVA: 0x60DF4; Processed MethodDef: 0x060003C6; Evidence: HoldingXE.source.txt:39952 + independent IL (decompilation/recovery, not runtime).
		static HoldingXE()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x060003C8; Original RVA: 0x60E10; Processed MethodDef: 0x060003C7; Evidence: HoldingXE.source.txt:39957 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0087d()
		{

			return true;
		}

// Original MethodDef: 0x060003C9; Original RVA: 0x60E1C; Processed MethodDef: 0x060003C8; Evidence: HoldingXE.source.txt:39962 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0087e()
		{

			return false;
		}
	}
}
