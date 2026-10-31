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
	public class BaseTurn
	{
		public TurnInput _0091_008D;

		public double _0091_008E;

		public double _0091_008F;

		public double _0091_0090;

		public double _0091_0091;

		public double _0091_0092;

		public double _0091_0093 = 4600.0;

		public double _0091_0094;

		public double _0091_0095;

		public double _0091_0096;

		public double _0091_0097;

		public double _0091_0098;

		public double _0091_0099;

		public double _0091_009A;

		public string _0091_009B;

		public double _0091_009C;

		private double _0091_009D;

		private double _0091_009E;

		private double _0092_0086;

		private bool _0092_0087;

		private bool _0092_0088;

		public Spiral88 _0092_0089;

		public Spiral88 _0092_008A;

		public Spiral88 _0092_008B;

		public Spiral88 _0092_008C;

		public Spiral88 _0092_008D;

		public List<TemplatePoint> _0092_008E;

		public List<TemplatePoint> _0092_008F;

		public List<List<TemplatePoint>> _0092_0090;

		public List<TemplatePoint> _0092_0091;

		public TemplatePoint _0092_0092;

		public TemplatePoint _0092_0093;

		public TemplatePoint _0092_0094;

		public TemplatePoint _0092_0095;

		public TemplatePoint _0092_0096;

		public TemplatePoint _0092_0097;

		public TemplatePoint _0092_0098;

		public TemplatePoint _0092_0099;

		public TemplatePoint _0092_009A;

		public TemplatePoint _0092_009B;

		public TemplatePoint _0092_009C;

		public TemplatePoint _0092_009D;

		public TemplatePoint _0092_009E;

		public TemplatePoint _0093_0086;

		public TemplatePoint _0093_0087;

		public TemplatePoint _0093_0088;

		public TemplatePoint _0093_0089;

		public TemplatePoint _0093_008A;

		public TemplatePoint _0093_008B;

		public ArrayList _0093_008C;

// Original MethodDef: 0x060001EE; Original RVA: 0x14E14; Processed MethodDef: 0x060001ED; Evidence: BaseTurn.source.txt:2688 + independent IL (decompilation/recovery, not runtime).
		public BaseTurn(TurnInput P_0, string P_1 = "VOR", double P_2 = 0.0, bool P_3 = true, double P_4 = 60.0, double P_5 = 4600.0)
		{

			/* opaque discard 1 */
			if (!_0087_008A())
			{
				_0091_009C = Math.PI / 180.0;
				_0091_009D = Math.PI / 6.0;
				_0091_009E = Math.PI * 5.0 / 18.0;
				_0092_0086 = Math.PI / 2.0;
				if (_0087_008A())
				{
				}
				_0092_0087 = true;
			}
			_0093_008C = new ArrayList();
			// object constructor emitted automatically by C#
			_0091_008D = P_0;
			_0090_009E(P_1, P_2, P_3, P_4);
			_0092_0088 = P_3;
			_0091_0093 = P_5;
		}

// Original MethodDef: 0x060001EF; Original RVA: 0x14F8C; Processed MethodDef: 0x060001EE; Evidence: BaseTurn.source.txt:2710 + independent IL (decompilation/recovery, not runtime).
		public void _0090_009E(string P_0, double P_1, bool P_2 = true, double P_3 = 60.0)
		{
			string text = default(string); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:216 */)
			{
				return;
			}
			_0091_009B = P_0;
			_0091_0090 = _0091_008D._008A_009D_009A / 3.6;
			_0091_0091 = _0091_008D._008A_009D_0098 / 3.6;
			text = P_0.ToUpper();
			if (!(text == "NDB" /* string-offset:1464 */) && !(text == "NDB/DME" /* string-offset:1468 */))
			{
				if (!(text == "VOR" /* string-offset:1472 */) && !(text == "VOR/DME" /* string-offset:1476 */))
				{
					Console.WriteLine("NaveType is Error." /* string-offset:1480 */);
				}
				else
				{
					_0091_0094 = (_0091_008D._008A_009D_0096 - P_1) * Math.Tan(50.0 * _0091_009C);
					_0091_0095 = 5.2 * _0091_009C;
					_0087_008A();
					if (!_0087_0089())
					{
						goto IL_028a;
					}
					if (_0087_008A())
					{
						goto IL_058f;
					}
					_0091_0098 = 15.0 * _0091_009C;
				}
				goto IL_0556;
			}
			_0091_0094 = (_0091_008D._008A_009D_0096 - P_1) * Math.Tan(40.0 * _0091_009C);
			goto IL_0155;
			IL_028a:
			_0091_008E *= _0091_009C;
			_0091_0099 = 11.0 * _0091_0090;
			_0091_009A = 11.0 * _0091_0091;
			_0092_0092 = new TemplatePoint(0.0, 0.0);
			if (!_0087_0089())
			{
				goto IL_02f9;
			}
			_0092_0093 = TemplatePoint._008B_0089_0087(_0091_008F, _0091_008E);
			_0092_0094 = TemplatePoint._008B_0089_0088(_0092_0093, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, Math.PI / 2.0));
			_0092_0094 = TemplatePoint._008B_0089_0088(_0092_0094, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, Math.PI / 2.0 + _0091_008E));
			_0092_0095 = TemplatePoint._008B_0089_0087(_0091_0097, _0091_008E - _0091_0095);
			if (!_0087_008A())
			{
			}
			_0092_0099 = TemplatePoint._008B_0089_0088(_0092_0095, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E + _0092_0086));
			_0092_0096 = TemplatePoint._008B_0089_0087(_0091_0096, _0091_008E + _0091_0095);
			_0092_009A = TemplatePoint._008B_0089_0088(_0092_0096, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E + _0092_0086));
			_0092_0097 = TemplatePoint._008B_0089_0087(_0091_0097, _0091_008E + _0091_0095);
			goto IL_04fe;
			IL_0556:
			// IL local declared at method entry
			if (P_2)
			{
				Console.WriteLine("===== Is By Time ===" /* string-offset:1484 */);
				_0091_0092 = P_3;
				_0091_008F = _0091_0090 * _0091_0092;
				_0091_0096 = (_0091_0092 - 5.0) * (_0091_0090 - _0091_0091) - _0091_0094;
				_0091_0097 = (_0091_0092 + 21.0) * (_0091_0090 + _0091_0091) + _0091_0094;
				num = _0091_0092 / 60.0;
				goto IL_023a;
			}
			Console.WriteLine("===== Is By Distance ===" /* string-offset:1488 */);
			num2 = P_3 * 1852.0;
			goto IL_02f9;
			IL_04fe:
			_0092_009B = TemplatePoint._008B_0089_0088(_0092_0097, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E + _0092_0086));
			num3 = _0091_008E - _0091_009D - _0091_0098;
			if (!_0087_0089())
			{
				goto IL_0155;
			}
			_0093_008B = new TemplatePoint(_0091_0094 * Math.Cos(num3), _0091_0094 * Math.Sin(num3));
			goto IL_058f;
			IL_058f:
			_0093_008A = TemplatePoint._008B_0089_0088(_0093_008B, TemplatePoint._008B_0089_0087(_0091_0099, _0091_008E - _0091_009D));
			_0092_0098 = TemplatePoint._008B_0089_0088(_0093_008A, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E + _0092_0086 - _0091_009D));
			return;
			IL_023a:
			if (_0091_008D._008A_009D_009A > 315.0)
			{
				_0091_008E = -0.116 * _0091_008D._008A_009D_009A / num;
				if (!_0087_0089())
				{
					goto IL_04fe;
				}
			}
			else
			{
				_0091_008E = -36.0 / num;
			}
			goto IL_028a;
			IL_0155:
			_0091_0095 = 6.5 * _0091_009C;
			_0091_0098 = 25.0 * _0091_009C;
			goto IL_0556;
			IL_02f9:
			_0091_008F = num2;
			_0091_0096 = num2 - (460.0 + 0.0125 * num2) + 5.0 * (_0091_0090 - _0091_0091);
			_0091_0097 = num2 + (460.0 + 0.0125 * num2) + 11.0 * (_0091_0090 + _0091_0091);
			num = _0091_008F / (60.0 * _0091_0090);
			goto IL_023a;
		}

// Original MethodDef: 0x060001F0; Original RVA: 0x157A8; Processed MethodDef: 0x060001EF; Evidence: BaseTurn.source.txt:2820 + independent IL (decompilation/recovery, not runtime).
		public void _0091_0086(bool P_0)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals

			if (false /* original-file-bool-offset:220 */)
			{
				if (!_0087_008A())
				{
					return;
				}
			}
			else
			{
				_0092_0091 = new List<TemplatePoint> { _0092_0092, _0092_0093 };
				_0087_008A();
				if (!_0087_0089() || !_0087_0089())
				{
					return;
				}
				if (!P_0)
				{
					obj = TemplatePoint._008B_0089_0088(_0092_0093, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E + _0092_0086));
					_0091_008B(ref _0092_0091, obj, _0091_008D._008A_009D_009D, _0091_008E / _0091_009C - 90.0, 180.0 - _0091_008E / _0091_009C);
					return;
				}
			}
			_0092_0091.Add(_0092_0094);
		}

// Original MethodDef: 0x060001F1; Original RVA: 0x1593C; Processed MethodDef: 0x060001F0; Evidence: BaseTurn.source.txt:2847 + independent IL (decompilation/recovery, not runtime).
		public void _0091_0087(bool P_0 = true, bool P_1 = true)
		{
			double num5 = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj8 = default(TemplatePoint); // IL InitLocals
			int num = default(int); // IL InitLocals
			LineCarrier obj2 = default(LineCarrier); // IL InitLocals
			LineCarrier obj4 = default(LineCarrier); // IL InitLocals
			LineCarrier obj5 = default(LineCarrier); // IL InitLocals
			TemplatePoint obj6 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj7 = default(TemplatePoint); // IL InitLocals

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
				// IL local declared at method entry
				if (!false /* original-file-bool-offset:224 */)
				{
					_0092_0090 = new List<List<TemplatePoint>>();
					_0092_008E = new List<TemplatePoint>
					{
						new TemplatePoint(0.0, 0.0)
					};
					_0092_008F = new List<TemplatePoint>();
					_0092_0089 = new Spiral88(_0091_008D, _0092_0098, _0091_008E - 120.0 * _0091_009C, 11.0 * _0091_0091);
					num = 41;
					if (!_0087_008A())
					{
						while (true)
						{
							switch (num)
							{
							case 53:
								_0092_0090.Add(_0092_0089._008B_0086_0093(0.0, num5 - _0092_0089._008B_0087_0087 - Math.PI * 2.0, _0091_0093, 1.0, P_0, P_1));
								num = 18;
								goto case 18;
							case 18:
								if (_0091_008D._008A_009E_0086 < 0.0 - _0091_008E)
								{
									goto case 5;
								}
								PointLists._008B_008B_0087(ref _0092_008E, _0092_008A._008B_0086_0093(num5 - _0092_008A._008B_0087_0087 - Math.PI * 2.0, _0092_0086 - _0091_008E));
								goto case 32;
							case 5:
								PointLists._008B_008B_0087(ref _0092_008E, _0092_008A._008B_0086_0093(num5 - _0092_008A._008B_0087_0087 - Math.PI * 2.0, _0092_0086 + _0091_008D._008A_009E_0086));
								/* opaque discard 0 */
								if (_0087_0089())
								{
									num = 13;
									goto case 9;
								}
								num = 19;
								goto default;
							case 9:
							case 13:
								PointLists._008B_008B_0087(ref _0092_008E, _0092_008C._008B_0086_0093(_0092_0086 + _0091_008D._008A_009E_0086, _0092_0086 - _0091_008E));
								_0092_0090.Add(_0092_008A._008B_0086_0093(num5 - _0092_008A._008B_0087_0087 - Math.PI * 2.0, _0092_0086 + _0091_008D._008A_009E_0086, 0.0, 1.0, P_0, P_1));
								num = 16;
								goto case 16;
							case 16:
								_0092_0090.Add(_0092_008C._008B_0086_0093(_0092_0086 + _0091_008D._008A_009E_0086, _0092_0086 - _0091_008E, 0.0, 1.0, P_0, P_1));
								PointLists._008B_008B_0087(ref _0092_008F, _0092_008A._008B_0086_0093(num5 - _0092_008A._008B_0087_0087 - Math.PI * 2.0, _0092_0086 + _0091_008D._008A_009E_0086, _0091_0093));
								PointLists._008B_008B_0087(ref _0092_008F, _0092_008C._008B_0086_0093(_0092_0086 + _0091_008D._008A_009E_0086, _0092_0086 - _0091_008E, _0091_0093));
								num = 3;
								goto case 3;
							case 3:
								_0092_0090.Add(_0092_008A._008B_0086_0093(num5 - _0092_008A._008B_0087_0087 - Math.PI * 2.0, _0092_0086 + _0091_008D._008A_009E_0086, _0091_0093, 1.0, P_0, P_1));
								num = 26;
								if (_0087_0089())
								{
									goto case 26;
								}
								goto case 1;
							case 26:
								_0092_0090.Add(_0092_008C._008B_0086_0093(_0092_0086 + _0091_008D._008A_009E_0086, _0092_0086 - _0091_008E, _0091_0093, 1.0, P_0, P_0));
								num = 45;
								goto case 45;
							case 45:
							{
								obj2 = new LineCarrier();
								obj2._008B_0088_008F(_0092_008C._008B_0086_0095(_0092_0086 - _0091_008E), _0092_0086 - _0091_008D._008A_009E_0086);
								_0093_0089 = new TemplatePoint(obj2._008B_0088_008C(0.0), 0.0);
								num = 38;
								goto case 38;
							}
							case 32:
								PointLists._008B_008B_0087(ref _0092_008F, _0092_008A._008B_0086_0093(num5 - _0092_008A._008B_0087_0087 - Math.PI * 2.0, _0092_0086 - _0091_008E, _0091_0093));
								_0092_0090.Add(_0092_008A._008B_0086_0093(num5 - _0092_008A._008B_0087_0087 - Math.PI * 2.0, _0092_0086 - _0091_008E, 0.0, 1.0, P_0, P_1));
								_0092_0090.Add(_0092_008A._008B_0086_0093(num5 - _0092_008A._008B_0087_0087 - Math.PI * 2.0, _0092_0086 - _0091_008E, _0091_0093, 1.0, P_0, P_1));
								num = 15;
								goto case 15;
							case 36:
								num2 = _0092_008D._008B_0086_009D(_0092_008B);
								num = 14;
								goto case 14;
							case 14:
								num4 = _0092_008C._008B_0086_009D(_0092_008B);
								goto case 6;
							case 6:
								if (num4 >= num2)
								{
									num3 = _0092_008D._008B_0086_009D(_0092_008C);
									PointLists._008B_008B_0087(ref _0092_008E, _0092_008D._008B_0086_0093(0.0, num3));
									num = 35;
									goto case 35;
								}
								PointLists._008B_008B_0087(ref _0092_008E, _0092_008D._008B_0086_0093(0.0, num2));
								num = 33;
								goto case 33;
							case 35:
								PointLists._008B_008B_0087(ref _0092_008E, _0092_008C._008B_0086_0093(num3 - _0092_008C._008B_0087_0087, num4 - _0092_008C._008B_0087_0087));
								num = 0;
								if (!_0087_008A())
								{
									continue;
								}
								goto case 38;
							case 38:
								_0092_009C = new TemplatePoint(_0093_0089.X - _0091_008D._008A_009D_009D, 0.0);
								_0092_008D = new Spiral88(_0091_008D, _0092_009C);
								num = 36;
								if (_0087_0089())
								{
									goto case 36;
								}
								goto case 15;
							case 15:
								obj = new LineCarrier();
								num = 23;
								if (!_0087_008A())
								{
									continue;
								}
								goto case 38;
							case 33:
								_0092_0090.Add(_0092_008D._008B_0086_0093(0.0, num2, 0.0, 1.0, P_0, P_1));
								if (_0092_0088)
								{
									PointLists._008B_008B_0087(ref _0092_008E, _0092_008B._008B_0086_0093(num2 - _0092_008B._008B_0087_0087, 5.340707511102648));
									_0092_0090.Add(_0092_008B._008B_0086_0093(num2 - _0092_008B._008B_0087_0087, 5.340707511102648, 0.0, 1.0, P_0, P_1));
									num = 51;
									goto case 1;
								}
								PointLists._008B_008B_0087(ref _0092_008E, _0092_008B._008B_0086_0093(num2 - _0092_008B._008B_0087_0087, _0092_008B._008B_0086_0099(_0092_0092)));
								_0092_0090.Add(_0092_008B._008B_0086_0093(num2 - _0092_008B._008B_0087_0087, _0092_008B._008B_0086_0099(_0092_0092), 0.0, 1.0, P_0, P_1));
								num = 1;
								if (!_0087_008A())
								{
									continue;
								}
								goto default;
							case 31:
								_0092_0090.Add(_0092_008D._008B_0086_0093(0.0, num2, _0091_0093, 1.0, P_0, P_1));
								if (!_0092_0088)
								{
									PointLists._008B_008B_0087(ref _0092_008F, _0092_008B._008B_0086_0093(num2 - _0092_008B._008B_0087_0087, _0092_008B._008B_0086_0099(_0092_0092), _0091_0093));
									num = 30;
									if (!_0087_008A())
									{
										continue;
									}
									goto case 32;
								}
								goto default;
							case 1:
							case 51:
								PointLists._008B_008B_0087(ref _0092_008F, _0092_008D._008B_0086_0093(0.0, num2, _0091_0093));
								goto case 31;
							default:
								PointLists._008B_008B_0087(ref _0092_008F, _0092_008B._008B_0086_0093(num2 - _0092_008B._008B_0087_0087, 5.340707511102648, _0091_0093));
								num = 48;
								if (!_0087_008A())
								{
									continue;
								}
								return;
							case 50:
								_0092_0090.Add(_0092_0089._008B_0086_0093(0.0, num5 - _0092_0089._008B_0087_0087 - Math.PI * 2.0, 0.0, 1.0, P_0, P_1));
								num = 24;
								goto case 24;
							case 24:
								_0091_0088();
								PointLists._008B_008B_0087(ref _0092_008F, _0092_0089._008B_0086_0093(0.0, num5 - _0092_0089._008B_0087_0087 - Math.PI * 2.0, _0091_0093));
								num = 53;
								goto case 53;
							case 41:
								_0092_008A = new Spiral88(_0091_008D, _0092_0099, _0091_008E - _0092_0086);
								_0092_008B = new Spiral88(_0091_008D, _0092_009A, _0091_008E - _0092_0086);
								_0092_008C = new Spiral88(_0091_008D, _0092_009B, _0091_008E - _0092_0086);
								num5 = _0092_0089._008B_0086_009D(_0092_008A);
								goto case 40;
							case 40:
								PointLists._008B_008B_0087(ref _0092_008E, _0092_0089._008B_0086_0093(0.0, num5 - _0092_0089._008B_0087_0087 - Math.PI * 2.0));
								num = 50;
								goto case 50;
							case 34:
								_0093_0089 = new TemplatePoint(obj._008B_0088_008C(0.0), 0.0);
								_0092_009C = new TemplatePoint(_0093_0089.X - _0091_008D._008A_009D_009D, 0.0);
								num = 21;
								goto case 21;
							case 21:
								_0092_008D = new Spiral88(_0091_008D, _0092_009C);
								goto case 36;
							case 23:
								obj._008B_0088_008F(_0092_008A._008B_0086_0095(_0092_0086 - _0091_008E), _0092_0086 - _0091_008D._008A_009E_0086);
								num = 34;
								goto case 34;
							case 8:
								break;
							case 0:
								_0092_0090.Add(_0092_008D._008B_0086_0093(0.0, num3, 0.0, 1.0, P_0, P_1));
								goto case 43;
							case 30:
								_0092_0090.Add(_0092_008B._008B_0086_0093(num2 - _0092_008B._008B_0087_0087, _0092_008B._008B_0086_0099(_0092_0092), _0091_0093, 1.0, P_0, P_1));
								num = 52;
								goto IL_1238;
							case 43:
								_0092_0090.Add(_0092_008C._008B_0086_0093(num3 - _0092_008C._008B_0087_0087, num4 - _0092_008C._008B_0087_0087, 0.0, 1.0, P_0, P_1));
								num = 37;
								goto case 37;
							case 37:
								if (_0092_0088)
								{
									num = 17;
									goto case 17;
								}
								PointLists._008B_008B_0087(ref _0092_008E, _0092_008B._008B_0086_0093(num4 - _0092_008B._008B_0087_0087, _0092_008B._008B_0086_0099(_0092_0092)));
								num = 22;
								goto case 22;
							case 17:
								PointLists._008B_008B_0087(ref _0092_008E, _0092_008B._008B_0086_0093(num4 - _0092_008B._008B_0087_0087, 5.340707511102648));
								_0092_0090.Add(_0092_008B._008B_0086_0093(num4 - _0092_008B._008B_0087_0087, 5.340707511102648, 0.0, 1.0, P_0, P_1));
								goto IL_0fca;
							case 22:
								_0092_0090.Add(_0092_008B._008B_0086_0093(num4 - _0092_008B._008B_0087_0087, _0092_008B._008B_0086_0099(_0092_0092), 0.0, 1.0, P_0, P_1));
								num = 2;
								goto IL_0fca;
							case 2:
							case 7:
								goto IL_0fca;
							case 4:
								goto IL_1047;
							case 29:
								goto IL_1082;
							case 28:
								goto IL_10cd;
							case 12:
								goto IL_1112;
							case 42:
								goto IL_11a2;
							case 48:
								_0092_0090.Add(_0092_008B._008B_0086_0093(num2 - _0092_008B._008B_0087_0087, 5.340707511102648, _0091_0093, 1.0, P_0, P_1));
								goto IL_1238;
							case 46:
							case 47:
							case 52:
								goto IL_1238;
							case 39:
								goto IL_1263;
							case 11:
								goto IL_1331;
							case 25:
								goto IL_133e;
							case 49:
								goto IL_135a;
							case 20:
								goto IL_137c;
							case 44:
								goto IL_13ef;
							case 10:
							case 54:
								return;
							}
							break;
						}
						continue;
					}
					goto IL_133e;
				}
				num = 10;
				if (_0087_008A())
				{
					goto IL_0fca;
				}
				break;
				IL_133e:
				num6 = _0092_008B._008B_0086_0099(_0092_0092);
				goto IL_135a;
				IL_135a:
				obj3 = _0092_008B._008B_0086_0095(num6);
				num = 20;
				goto IL_137c;
				IL_137c:
				obj4 = new LineCarrier();
				obj4._008B_0088_008F(obj3, num6 + _0092_008B._008B_0087_0087 - _0091_008D._008A_009E_0086 + _0092_0086);
				if (obj4._008B_0088_008C(0.0) > -1.0 && !_0092_0088)
				{
					num = 44;
					goto IL_13ef;
				}
				goto IL_145d;
				IL_0fca:
				PointLists._008B_008B_0087(ref _0092_008F, _0092_008D._008B_0086_0093(0.0, num3, _0091_0093));
				PointLists._008B_008B_0087(ref _0092_008F, _0092_008C._008B_0086_0093(num3 - _0092_008C._008B_0087_0087, num4 - _0092_008C._008B_0087_0087, _0091_0093));
				num = 4;
				goto IL_1047;
				IL_1047:
				_0092_0090.Add(_0092_008D._008B_0086_0093(0.0, num3, _0091_0093, 1.0, P_0, P_1));
				num = 29;
				goto IL_1082;
				IL_1082:
				_0092_0090.Add(_0092_008C._008B_0086_0093(num3 - _0092_008C._008B_0087_0087, num4 - _0092_008C._008B_0087_0087, _0091_0093, 1.0, P_0, P_1));
				num = 28;
				goto IL_10cd;
				IL_10cd:
				if (_0092_0088)
				{
					PointLists._008B_008B_0087(ref _0092_008F, _0092_008B._008B_0086_0093(num4 - _0092_008B._008B_0087_0087, 5.340707511102648, _0091_0093));
					goto IL_1112;
				}
				PointLists._008B_008B_0087(ref _0092_008F, _0092_008B._008B_0086_0093(num4 - _0092_008B._008B_0087_0087, _0092_008B._008B_0086_0099(_0092_0092), _0091_0093));
				goto IL_11a2;
				IL_13ef:
				obj3 = _0092_008B._008B_0086_0095(num6, _0091_0093);
				obj5 = new LineCarrier();
				obj5._008B_0088_008F(obj3, num6 + _0092_008B._008B_0087_0087 - _0091_008D._008A_009E_0086 + _0092_0086);
				obj5._008B_0088_008D(0.0);
				goto IL_145d;
				IL_1112:
				_0092_0090.Add(_0092_008B._008B_0086_0093(num4 - _0092_008B._008B_0087_0087, 5.340707511102648, _0091_0093, 1.0, P_0, P_1));
				goto IL_1238;
				IL_145d:
				num = 54;
				break;
				IL_11a2:
				_0092_0090.Add(_0092_008B._008B_0086_0093(num4 - _0092_008B._008B_0087_0087, _0092_008B._008B_0086_0099(_0092_0092), _0091_0093, 1.0, P_0, P_1));
				num = 47;
				goto IL_1238;
				IL_1238:
				_0092_008E.Add(new TemplatePoint(0.0, 0.0));
				goto IL_1263;
				IL_1263:
				obj6 = _0092_008E[0];
				obj7 = _0092_008E[1];
				obj8 = _0092_008E[_0092_008E.Count - 2];
				obj7 = TemplatePoint._008B_0089_0087(_0091_0093, Math.Atan2(obj7.Y - obj6.Y, obj7.X - obj6.X) - Math.PI / 2.0);
				obj8 = TemplatePoint._008B_0089_0087(_0091_0093, Math.Atan2(obj7.Y - obj6.Y, obj7.X - obj6.X) - Math.PI / 2.0);
				_0092_008F.Insert(0, obj7);
				num = 11;
				goto IL_1331;
				IL_1331:
				_0092_008F.Add(obj8);
				goto IL_133e;
			}
		}

// Original MethodDef: 0x060001F2; Original RVA: 0x16EAC; Processed MethodDef: 0x060001F1; Evidence: BaseTurn.source.txt:3200 + independent IL (decompilation/recovery, not runtime).
		public void _0091_0088()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			item = new List<TemplatePoint>();
			/* opaque discard 1 */
			if (!_0087_008A())
			{
				_0091_008C(ref item, _0092_0092, _0091_0094, -1.3 * _0092_0086, 2.5 * _0092_0086);
				if (!_0087_0089())
				{
				}
				_0092_0090.Add(item);
				TemplatePoint._008B_0089_0088(_0093_008B, TemplatePoint._008B_0089_0087(3000.0, _0091_008E - _0091_009D));
			}
			TemplatePoint._008B_0089_0088(_0092_0092, TemplatePoint._008B_0089_0087(5000.0, _0091_008E - _0091_009D));
		}

// Original MethodDef: 0x060001F3; Original RVA: 0x16FFC; Processed MethodDef: 0x060001F2; Evidence: BaseTurn.source.txt:3216 + independent IL (decompilation/recovery, not runtime).
		public void _0091_0089()
		{
			int num = default(int); // IL InitLocals
			List<TemplatePoint> value = default(List<TemplatePoint>); // IL InitLocals

			num = 14;
			while (true /* original-file-bool-offset:228 */)
			{
				num = 3;
				while (true)
				{
					value = new List<TemplatePoint>();
					while (true)
					{
						_0091_008C(ref value, _0092_0099, _0091_008D._008A_009D_009D, _0091_008E - _0092_0086, 110.0 * _0091_009C);
						_0093_008C.Add(value);
						num = 7;
						while (true)
						{
							value = new List<TemplatePoint>();
							_0091_008C(ref value, _0092_009B, _0091_008D._008A_009D_009D, _0091_008E - _0092_0086, 110.0 * _0091_009C);
							_0093_008C.Add(value);
							while (true)
							{
								value = new List<TemplatePoint>();
								_0087_0089();
								if (_0087_008A())
								{
									num = 13;
									goto IL_025b;
								}
								num = 10;
								goto IL_0225;
								IL_0225:
								_0091_008C(ref value, _0092_009A, _0091_008D._008A_009D_009D, _0091_008E + _0092_0086, 90.0 * _0091_009C);
								goto IL_025b;
								IL_025b:
								while (true)
								{
									IL_025b_2:
									_0093_008C.Add(value);
									num = 1;
									if (_0087_0089())
									{
										while (true)
										{
											switch (num)
											{
											case 12:
												break;
											case 11:
												_0093_0087 = TemplatePoint._008B_0089_0088(_0092_009A, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E - _0092_0086 + 190.0 * _0091_009C));
												_0093_0088 = TemplatePoint._008B_0089_0088(_0092_009A, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E - _0092_0086 + 235.0 * _0091_009C));
												num = 8;
												if (!_0087_008A())
												{
													continue;
												}
												break;
											default:
												_0093_0086 = TemplatePoint._008B_0089_0088(_0092_009B, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E - _0092_0086 + 2.0 * _0091_009E));
												num = 11;
												if (!_0087_008A())
												{
													continue;
												}
												goto IL_0347;
											case 1:
												_0092_009D = TemplatePoint._008B_0089_0088(_0092_0099, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E - _0092_0086 + _0091_009E));
												_0092_009E = TemplatePoint._008B_0089_0088(_0092_0099, TemplatePoint._008B_0089_0087(_0091_008D._008A_009D_009D, _0091_008E - _0092_0086 + 2.0 * _0091_009E));
												goto default;
											case 5:
											case 10:
												goto IL_0225;
											case 6:
											case 13:
												goto IL_025b_2;
											case 7:
												goto end_IL_001c;
											case 4:
												goto end_IL_028c;
											case 3:
												goto end_IL_02da;
											case 14:
												goto end_IL_032b;
											case 8:
												goto IL_0347;
											case 15:
												goto IL_03d6;
											case 0:
												goto IL_0422;
											case 9:
												goto IL_046e;
											case 16:
												return;
											}
											break;
										}
										break;
									}
									goto IL_0347;
									IL_046e:
									_0093_008C.Add(_0091_008A(_0092_009A, _0093_0088, 235.0 * _0091_009C * _0091_008D._008A_009D_009E));
									return;
									IL_0347:
									_0093_008C.Add(_0091_008A(_0092_0099, _0092_009D, 50.0 * _0091_009C * _0091_008D._008A_009D_009E));
									_0093_008C.Add(_0091_008A(_0092_0099, _0092_009E, 100.0 * _0091_009C * _0091_008D._008A_009D_009E));
									num = 15;
									goto IL_03d6;
									IL_03d6:
									_0093_008C.Add(_0091_008A(_0092_009B, _0093_0086, 100.0 * _0091_009C * _0091_008D._008A_009D_009E));
									num = 0;
									goto IL_0422;
									IL_0422:
									_0093_008C.Add(_0091_008A(_0092_009A, _0093_0087, 190.0 * _0091_009C * _0091_008D._008A_009D_009E));
									num = 9;
									goto IL_046e;
								}
								continue;
								end_IL_001c:
								break;
							}
							continue;
							end_IL_028c:
							break;
						}
						continue;
						end_IL_02da:
						break;
					}
					continue;
					end_IL_032b:
					break;
				}
			}
		}

// Original MethodDef: 0x060001F4; Original RVA: 0x174F8; Processed MethodDef: 0x060001F3; Evidence: BaseTurn.source.txt:3350 + independent IL (decompilation/recovery, not runtime).
		public override string ToString()
		{
			string text = default(string); // IL InitLocals

			// IL local declared at method entry
			while (true)
			{
				if (!false /* original-file-bool-offset:232 */)
				{
					text = _0091_008D.ToString();
					text = text + "========" /* string-offset:1492 */ + _0091_009B + " base turn parameters===============\n" /* string-offset:1496 */;
					if (!_0087_0089())
					{
						continue;
					}
					text = text + "v= " /* string-offset:1500 */ + Math.Round(_0091_0090 * 10.0) / 10.0 + "m/s\n" /* string-offset:1504 */;
					text = text + "w' = " /* string-offset:1508 */ + Math.Round(_0091_0091 * 10.0) / 10.0 + "m/s\n" /* string-offset:1504 */;
					text = text + "Phi = " /* string-offset:1512 */ + Math.Round(-100.0 * _0091_008E / _0091_009C) / 100.0 + " degree\n" /* string-offset:1516 */;
					goto IL_0241;
				}
				goto IL_011a;
				IL_0241:
				text = text + "zV = " /* string-offset:1520 */ + Math.Round(_0091_0094) + "m\n" /* string-offset:1524 */;
				text = text + "t = " /* string-offset:1528 */ + _0091_0092 + "sec\n" /* string-offset:1532 */;
				goto IL_011a;
				IL_011a:
				text = text + "L = " /* string-offset:1536 */ + _0091_008F + "m\n" /* string-offset:1524 */;
				text = text + _0091_009B + " ab1 = " /* string-offset:1540 */ + Math.Round(_0091_0096) + "m\n" /* string-offset:1524 */;
				/* opaque discard 0 */
				if (_0087_0089())
				{
					text = text + _0091_009B + " ab2 = " /* string-offset:1544 */ + Math.Round(_0091_0097) + "m\n" /* string-offset:1524 */;
				}
				text = text + "V31 = " /* string-offset:1548 */ + Math.Round(_0091_0099) + "m\n" /* string-offset:1524 */;
				text = text + "WL = " /* string-offset:1552 */ + Math.Round(_0091_009A) + "m\n" /* string-offset:1524 */;
				if (!_0087_008A())
				{
					break;
				}
				goto IL_0241;
			}
			return text;
		}

// Original MethodDef: 0x060001F5; Original RVA: 0x17878; Processed MethodDef: 0x060001F4; Evidence: BaseTurn.source.txt:3392 + independent IL (decompilation/recovery, not runtime).
		private List<TemplatePoint> _0091_008A(TemplatePoint P_0, TemplatePoint P_1, double P_2, double P_3 = Math.PI * 3.0 / 5.0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:236 */)
			{
				goto IL_0094;
			}
			list = new List<TemplatePoint>();
			num = Math.Atan2(P_1.Y - P_0.Y, P_1.X - P_0.X) - P_3 / 2.0;
			num2 = num + P_3;
			num3 = 2.0 * _0091_009C;
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

// Original MethodDef: 0x060001F6; Original RVA: 0x17968; Processed MethodDef: 0x060001F5; Evidence: BaseTurn.source.txt:3419 + independent IL (decompilation/recovery, not runtime).
		public void _0091_008B(ref List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4, double P_5 = 2.0)
		{
			int num = default(int); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals

			num = 2;
			if (_0087_0089())
			{
				goto IL_008d;
			}
			goto IL_0171;
			IL_008d:
			// IL local declared at method entry
			switch (num)
			{
			case 0:
				break;
			case 9:
				goto IL_0059;
			case 3:
				goto IL_005e;
			case 1:
			case 7:
				goto IL_00cc;
			case 6:
			case 8:
				goto IL_00f0;
			default:
				num = 3;
				goto IL_005e;
			case 4:
				goto IL_0143;
			case 2:
				goto IL_0151;
			case 10:
				goto IL_0171;
			case 11:
				P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
				num = 12;
				return;
			case 5:
			case 12:
				return;
			}
			goto IL_0042;
			IL_0151:
			// IL local declared at method entry
			// IL local declared at method entry
			if (!false /* original-file-bool-offset:240 */)
			{
				num2 = Math.Abs(P_5);
				num3 = P_3;
				num = 10;
				goto IL_0171;
			}
			num = 5;
			return;
			IL_00cc:
			num4 = ((P_5 > 0.0) ? (P_3 + P_4) : (P_3 - P_4));
			if (num3 - P_5 == num4)
			{
				return;
			}
			goto IL_00f0;
			IL_0042:
			P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
			num = 9;
			goto IL_0059;
			IL_0171:
			num5 = 0.0;
			num = 4;
			goto IL_0143;
			IL_0059:
			num3 += P_5;
			goto IL_005e;
			IL_00f0:
			obj = new TemplatePoint(P_2 * Math.Cos(num4 * _0091_009C), P_2 * Math.Sin(num4 * _0091_009C));
			num = 11;
			if (_0087_008A())
			{
				goto IL_0059;
			}
			goto IL_008d;
			IL_005e:
			num5 += num2;
			goto IL_0143;
			IL_0143:
			if (num5 < P_4)
			{
				obj = new TemplatePoint(P_2 * Math.Cos(num3 * _0091_009C), P_2 * Math.Sin(num3 * _0091_009C));
				goto IL_0042;
			}
			_0087_008A();
			if (_0087_0089())
			{
				num = 1;
				goto IL_00cc;
			}
			num = 6;
			goto IL_00f0;
		}

// Original MethodDef: 0x060001F7; Original RVA: 0x17B6C; Processed MethodDef: 0x060001F6; Evidence: BaseTurn.source.txt:3518 + independent IL (decompilation/recovery, not runtime).
		private void _0091_008C(ref List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4)
		{
			int num = default(int); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num9 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			num = 9;
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			while (true /* original-file-bool-offset:244 */)
			{
				while (true)
				{
					num2 = P_3 + P_4;
					while (true)
					{
						// IL local declared at method entry
						if (!(P_4 > 0.0))
						{
							num3 = -2.0 * _0091_009C;
							num4 = P_3 + num3;
							num = 10;
							if (_0087_008A())
							{
								goto IL_00ac;
							}
							goto IL_0209;
						}
						num = 0;
						goto IL_0039;
						IL_01da:
						P_0.Add(new TemplatePoint(num5, num6));
						num = 7;
						if (!_0087_008A())
						{
							goto IL_0203;
						}
						goto IL_0209;
						IL_0203:
						num4 += num3;
						goto IL_0209;
						IL_00ac:
						num7 = P_3 + num3;
						num = 14;
						if (_0087_008A())
						{
							break;
						}
						goto IL_005d;
						IL_005d:
						switch (num)
						{
						case 0:
							break;
						case 3:
							goto IL_00ac;
						case 2:
							continue;
						case 4:
							goto end_IL_00d0;
						case 9:
							goto end_IL_00e2;
						default:
							num = 11;
							goto case 11;
						case 6:
						case 8:
							num9 = P_2 * Math.Sin(num7) + P_1.Y;
							num = 1;
							goto case 1;
						case 1:
							P_0.Add(new TemplatePoint(num8, num9));
							num7 += num3;
							goto case 11;
						case 11:
						case 14:
							if (num7 < num2)
							{
								num8 = P_2 * Math.Cos(num7) + P_1.X;
								_0087_0089();
								if (!_0087_008A())
								{
									goto case 6;
								}
								num = 5;
								goto IL_0209;
							}
							P_0.Add(new TemplatePoint(P_2 * Math.Cos(num2) + P_1.X, P_2 * Math.Sin(num2) + P_1.Y));
							num = 15;
							return;
						case 15:
							return;
						case 12:
							goto IL_01da;
						case 7:
							goto IL_0203;
						case 5:
						case 10:
						case 13:
							goto IL_0209;
						case 16:
							return;
						}
						goto IL_0039;
						IL_0039:
						num3 = 2.0 * _0091_009C;
						num = 3;
						if (_0087_0089())
						{
							goto IL_005d;
						}
						goto IL_01da;
						IL_0209:
						if (num4 > num2)
						{
							num5 = P_2 * Math.Cos(num4) + P_1.X;
							num6 = P_2 * Math.Sin(num4) + P_1.Y;
							num = 12;
							goto IL_01da;
						}
						P_0.Add(new TemplatePoint(P_2 * Math.Cos(num2) + P_1.X, P_2 * Math.Sin(num2) + P_1.Y));
						num = 16;
						return;
						continue;
						end_IL_00d0:
						break;
					}
					continue;
					end_IL_00e2:
					break;
				}
			}
		}

// Original MethodDef: 0x060001F8; Original RVA: 0x17E1C; Processed MethodDef: 0x060001F7; Evidence: BaseTurn.source.txt:3652 + independent IL (decompilation/recovery, not runtime).
		static BaseTurn()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x060001F9; Original RVA: 0x17E38; Processed MethodDef: 0x060001F8; Evidence: BaseTurn.source.txt:3657 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0087_0089()
		{

			return true;
		}

// Original MethodDef: 0x060001FA; Original RVA: 0x17E44; Processed MethodDef: 0x060001F9; Evidence: BaseTurn.source.txt:3662 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0087_008A()
		{

			return false;
		}
	}
}
