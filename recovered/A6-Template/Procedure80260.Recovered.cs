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
	internal class Procedure80260
	{
		public TurnInput _0088_0098_009D;

		public double _0088_0098_009E;

		public double _0088_0099_0086;

		public double _0088_0099_0087;

		public double _0088_0099_0088;

		public double _0088_0099_0089;

		public List<TemplatePoint> _0088_0099_008A;

		public List<TemplatePoint> _0088_0099_008B;

		public List<List<TemplatePoint>> _0088_0099_008C;

		public Spiral86 _0088_0099_008D;

		public Spiral86 _0088_0099_008E;

		public double _0088_0099_008F;

		public double _0088_0099_0090;

		public double _0088_0099_0091;

		public double _0088_0099_0092;

		public TemplatePoint _0088_0099_0093;

		public TemplatePoint _0088_0099_0094;

		public TemplatePoint _0088_0099_0095;

		public TemplatePoint _0088_0099_0096;

		public TemplatePoint _0088_0099_0097;

		public TemplatePoint _0088_0099_0098;

		public TemplatePoint _0088_0099_0099;

		public TemplatePoint _0088_0099_009A;

		public TemplatePoint _0088_0099_009B;

		public TemplatePoint _0088_0099_009C;

		public TemplatePoint _0088_0099_009D;

		public TemplatePoint _0088_0099_009E;

		public double _0088_009A_0086;

		public double _0088_009A_0087;

		public static double _0088_009A_0088;

// Original MethodDef: 0x0600045F; Original RVA: 0x6C630; Processed MethodDef: 0x0600045E; Evidence: Procedure80260.source.txt:46150 + independent IL (decompilation/recovery, not runtime).
		public Procedure80260(TurnInput P_0)
		{
			double num = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals

			if (!_0088_0090())
			{
				if (!true /* original-file-bool-offset:880 */)
				{
					return;
				}
				// object constructor emitted automatically by C#
				_0088_0098_009D = P_0;
			}
			_0088_0098_009E = _0088_0098_009D._008A_009D_009A / 3.6;
			if (_0088_008F())
			{
			}
			_0088_0099_0086 = _0088_0098_009D._008A_009D_0098 / 3.6;
			_0088_0099_0087 = 5.0 * _0088_0098_009E;
			_0088_0099_0088 = 10.0 * _0088_0098_009E;
			_0088_0099_0089 = 15.0 * _0088_0099_0086 + Math.PI * 85.0 * _0088_0098_009D._008A_009D_009E / 180.0;
			num = _0088_0098_009D._008A_009D_009D;
			_0088_0099_0093 = new TemplatePoint(_0088_0099_0087, 0.0);
			obj = TemplatePoint._008B_0089_0087(num, -90.0 * _0088_009A_0088);
			_0088_0099_0094 = TemplatePoint._008B_0089_0088(_0088_0099_0093, obj);
			/* opaque discard 0 */
			if (_0088_008F())
			{
				obj = TemplatePoint._008B_0089_0087(num, 15.0 * _0088_009A_0088);
				_0088_0099_0099 = TemplatePoint._008B_0089_0088(_0088_0099_0094, obj);
				_0088_0099_009A = TemplatePoint._008B_0089_0088(_0088_0099_0099, TemplatePoint._008B_0089_0087(_0088_0099_0088, -75.0 * _0088_009A_0088));
			}
			_0088_0099_009B = TemplatePoint._008B_0089_0088(_0088_0099_009A, obj);
			obj = TemplatePoint._008B_0089_0087(num, 10.0 * _0088_009A_0088);
			_0088_0099_0095 = TemplatePoint._008B_0089_0088(_0088_0099_0094, obj);
			_0088_0099_0096 = TemplatePoint._008B_0089_0088(_0088_0099_0095, TemplatePoint._008B_0089_0087(_0088_0099_0088, -80.0 * _0088_009A_0088));
			_0088_0099_0097 = TemplatePoint._008B_0089_0088(_0088_0099_0096, obj);
			_0088_0099_0098 = TemplatePoint._008B_0089_0088(_0088_0099_0097, TemplatePoint._008B_0089_0087(num, 90.0 * _0088_009A_0088));
			obj = TemplatePoint._008B_0089_0087(num, 5.0 * _0088_009A_0088);
			_0088_0099_009C = TemplatePoint._008B_0089_0088(_0088_0099_0094, obj);
			_0088_0099_009D = TemplatePoint._008B_0089_0088(_0088_0099_009C, TemplatePoint._008B_0089_0087(_0088_0099_0088, -85.0 * _0088_009A_0088));
			_0088_0099_009E = TemplatePoint._008B_0089_0088(_0088_0099_009D, obj);
			_0088_0099_0091 = 15.0 * _0088_0099_0086 + 75.0 * _0088_009A_0088 * _0088_0098_009D._008A_009D_009E;
			_0088_0099_008F = 195.0 * _0088_009A_0088;
			_0088_0099_008D = new Spiral86(_0088_0098_009D, _0088_0099_009B, _0088_0099_008F, _0088_0099_0091);
			_0088_0099_0092 = 15.0 * _0088_0099_0086 + 85.0 * _0088_009A_0088 * _0088_0098_009D._008A_009D_009E;
			_0088_0099_0090 = 185.0 * _0088_009A_0088;
			_0088_0099_008E = new Spiral86(_0088_0098_009D, _0088_0099_009E, _0088_0099_0090, _0088_0099_0092);
		}

// Original MethodDef: 0x06000460; Original RVA: 0x6CB40; Processed MethodDef: 0x0600045F; Evidence: Procedure80260.source.txt:46198 + independent IL (decompilation/recovery, not runtime).
		public override string ToString()
		{
			string text = default(string); // IL InitLocals

			// IL local declared at method entry
			if (!false /* original-file-bool-offset:884 */)
			{
				text = _0088_0098_009D.ToString();
				_0088_008F();
				if (!_0088_0090())
				{
					text += "=========== Procedure Turn parameters ============" /* string-offset:5556 */;
					text = text + "\nv = " /* string-offset:5560 */ + Math.Round(_0088_0098_009E * 10.0) / 10.0 + "m/s" /* string-offset:5564 */;
				}
				else if (!_0088_0090())
				{
					goto IL_01c1;
				}
				text = text + "\nw' = " /* string-offset:5568 */ + Math.Round(_0088_0099_0086 * 10.0) / 10.0 + "m/s" /* string-offset:5564 */;
				text = text + "\nab = " /* string-offset:5572 */ + Math.Round(_0088_0099_0087) + "m" /* string-offset:3072 */;
				text = text + "\nde = cd1 = cd3 = " /* string-offset:5596 */ + Math.Round(_0088_0099_0088) + "m" /* string-offset:3072 */;
			}
			text = text + "\nWe2 = " /* string-offset:5600 */ + Math.Round(_0088_0099_0089) + "m" /* string-offset:3072 */;
			text = text + "Center F1 ( x= " /* string-offset:5604 */ + Math.Round(_0088_0099_009B.X) + ", y= " /* string-offset:5608 */ + Math.Round(_0088_0099_009B.Y) + ")\n" /* string-offset:5612 */;
			goto IL_01c1;
			IL_01c1:
			text = text + "Center F2 ( x= " /* string-offset:5616 */ + Math.Round(_0088_0099_009E.X) + ", y= " /* string-offset:5608 */ + Math.Round(_0088_0099_009E.Y) + ")\n" /* string-offset:5612 */;
			return text + "Angle of F2-F1 :{0}" /* string-offset:5620 */ + Math.Atan2(_0088_0099_009E.Y - _0088_0099_009B.Y, _0088_0099_009E.X - _0088_0099_009B.X) * 180.0 / Math.PI;
		}

// Original MethodDef: 0x06000461; Original RVA: 0x6CEB8; Processed MethodDef: 0x06000460; Evidence: Procedure80260.source.txt:46226 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0098_0096(bool P_0 = false)
		{

			if (!true /* original-file-bool-offset:888 */)
			{
				return;
			}
			_0088_008F();
			if (!_0088_0090())
			{
				if (_0088_008F())
				{
					_0088_0099_008A = new List<TemplatePoint>
					{
						new TemplatePoint(0.0, 0.0),
						_0088_0099_0093
					};
					if (P_0)
					{
						_0088_0099_008A.Add(_0088_0099_0095);
						_0088_0099_008A.Add(_0088_0099_0096);
					}
					else
					{
						_0088_0098_009C(ref _0088_0099_008A, _0088_0099_0094, _0088_0098_009D._008A_009D_009D, 90.0, 10.0, -2.0);
						if (!_0088_0090())
						{
							goto IL_00df;
						}
					}
					_0088_0099_008A.Add(_0088_0099_0098);
					return;
				}
				goto IL_00df;
			}
			if (_0088_008F())
			{
			}
			return;
			IL_00df:
			_0088_0099_008A.Add(_0088_0099_0095);
			_0088_0099_008A.Add(_0088_0099_0096);
			_0088_0098_009C(ref _0088_0099_008A, _0088_0099_0097, _0088_0098_009D._008A_009D_009D, -170.0, 90.0);
		}

// Original MethodDef: 0x06000462; Original RVA: 0x6D0C0; Processed MethodDef: 0x06000461; Evidence: Procedure80260.source.txt:46270 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0098_0097(bool P_0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			if (!true /* original-file-bool-offset:892 */)
			{
				return;
			}
			/* opaque discard 0 */
			// IL local declared at method entry
			// IL local declared at method entry
			if (_0088_008F())
			{
				_0088_0099_008C = new List<List<TemplatePoint>>();
				_0088_0099_008B = new List<TemplatePoint>
				{
					new TemplatePoint(0.0, 0.0)
				};
				num = _0088_0098_0099() - Math.PI / 2.0 + _0088_0098_009D._008A_009E_0086;
				num2 = _0088_0099_008E._008A_009E_009D(_0088_0099_008D);
				PointLists._008B_008B_0087(ref _0088_0099_008B, _0088_0099_008E._008A_009E_009E(num, num2 - _0088_0099_0090 + Math.PI * 2.0));
				PointLists._008B_008B_0087(ref _0088_0099_008B, _0088_0099_008D._008A_009E_009E(num2 - _0088_0099_008F + Math.PI * 2.0, 5.497787143782138));
				_0088_0099_008C.Add(_0088_0099_008B);
				if (!P_0)
				{
					return;
				}
			}
			_0088_0099_008C.Add(_0088_0099_008E._008A_009E_009E(num, num2 - _0088_0099_0090 + Math.PI * 2.0, 0.0, 1.0, P_0, P_0));
			_0088_0099_008C.Add(_0088_0099_008D._008A_009E_009E(num2 - _0088_0099_008F + Math.PI * 2.0, 5.497787143782138, 0.0, 1.0, P_0, P_0));
		}

// Original MethodDef: 0x06000463; Original RVA: 0x6D32C; Processed MethodDef: 0x06000462; Evidence: Procedure80260.source.txt:46300 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0098_0098()
		{

		}

// Original MethodDef: 0x06000464; Original RVA: 0x6D338; Processed MethodDef: 0x06000463; Evidence: Procedure80260.source.txt:46304 + independent IL (decompilation/recovery, not runtime).
		public double _0088_0098_0099()
		{
			double num12 = default(double); // IL InitLocals
			double num13 = default(double); // IL InitLocals
			double num11 = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			double num9 = default(double); // IL InitLocals
			double num10 = default(double); // IL InitLocals
			double num14 = default(double); // IL InitLocals
			double num15 = default(double); // IL InitLocals
			int num16 = default(int); // IL InitLocals
			double num17 = default(double); // IL InitLocals
			double num18 = default(double); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			if (!_0088_0090() && !false /* original-file-bool-offset:896 */)
			{
				num = TemplatePoint._008B_0088_009E(_0088_0099_009B, _0088_0099_009E);
				num2 = Math.Atan2(_0088_0099_009B.Y - _0088_0099_009E.Y, _0088_0099_009B.X - _0088_0099_009E.X);
				/* opaque discard 0 */
				if (_0088_008F())
				{
					num3 = -165.0 * _0088_009A_0088;
					num4 = -175.0 * _0088_009A_0088;
					num5 = Math.Asin(-20.0 * _0088_009A_0088 * _0088_0098_009D._008A_009D_009E / num);
					num6 = num2 - num5 - Math.PI / 2.0;
					obj = TemplatePoint._008B_0089_0087(_0088_0098_009D._008A_009D_009D, num6 + _0088_0098_009D._008A_009E_0086);
					TemplatePoint._008B_0089_0088(_0088_0099_009B, obj);
					if (!_0088_0090())
					{
					}
					TemplatePoint._008B_0089_0088(_0088_0099_009E, obj);
					Console.WriteLine("公切线sita:{0}" /* string-offset:5624 */, (num6 + Math.PI / 2.0) / _0088_009A_0088);
					_0088_009A_0086 = num6 + _0088_0098_009D._008A_009E_0086 - num3;
					_0088_009A_0087 = num6 + _0088_0098_009D._008A_009E_0086 - num4;
					num7 = 15.0 * _0088_0099_0086 + 75.0 * _0088_009A_0088 * _0088_0098_009D._008A_009D_009E;
					num8 = _0088_009A_0086 * _0088_0098_009D._008A_009D_009E;
					num9 = 15.0 * _0088_0099_0086 + 85.0 * _0088_009A_0088 * _0088_0098_009D._008A_009D_009E;
					num10 = _0088_009A_0087 * _0088_0098_009D._008A_009D_009E;
					TemplatePoint._008B_0089_0087(num7 + num8, num2 - Math.PI / 2.0 - num5);
					TemplatePoint._008B_0089_0087(num9 + num10, num2 - Math.PI / 2.0 - num5);
					num11 = Math.Asin(_0088_0098_009D._008A_009D_009D / TemplatePoint._008B_0088_009E(new TemplatePoint(0.0, 0.0), _0088_0099_009E));
					num12 = Math.Atan2(_0088_0099_009E.Y, _0088_0099_009E.X) - num11 - Math.PI / 2.0 + _0088_0098_009D._008A_009E_0086;
					obj = TemplatePoint._008B_0089_0088(_0088_0099_009E, TemplatePoint._008B_0089_0087(_0088_0098_009D._008A_009D_009D, num12));
					num13 = num9 + (num12 - num4) * _0088_0098_009D._008A_009D_009E;
				}
			}
			obj = TemplatePoint._008B_0089_0088(obj, TemplatePoint._008B_0089_0087(num13, num12 - _0088_0098_009D._008A_009E_0086));
			num14 = Math.Atan2(obj.Y, obj.X);
			num15 = num12 + Math.PI / 2.0 - _0088_0098_009D._008A_009E_0086;
			num11 = num14 - num15;
			num16 = 0;
			while (Math.Abs(num11) > 1E-12)
			{
				num12 += num11;
				num13 += num11 * _0088_0098_009D._008A_009D_009E;
				obj = TemplatePoint._008B_0089_0087(_0088_0098_009D._008A_009D_009D, num12);
				obj = TemplatePoint._008B_0089_0088(_0088_0099_009E, obj);
				obj = TemplatePoint._008B_0089_0088(obj, TemplatePoint._008B_0089_0087(num13, num12 - _0088_0098_009D._008A_009E_0086));
				num17 = Math.Atan2(obj.Y, obj.X);
				num15 = num12 - _0088_0098_009D._008A_009E_0086 + Math.PI / 2.0;
				num11 = num17 - num15;
				num16++;
			}
			num18 = num15 + 175.0 * _0088_009A_0088;
			Console.WriteLine("firsSita:{0}" /* string-offset:5628 */, num18 / _0088_009A_0088);
			Console.WriteLine("wsf2 start" /* string-offset:5632 */, num15 / _0088_009A_0088 - 90.0 + _0088_0098_009D._008A_009E_0086 / _0088_009A_0088);
			return num18;
		}

// Original MethodDef: 0x06000465; Original RVA: 0x6D920; Processed MethodDef: 0x06000464; Evidence: Procedure80260.source.txt:46365 + independent IL (decompilation/recovery, not runtime).
		public double _0088_0098_009A(double P_0, double P_1)
		{

			Console.WriteLine("a {0}, b {1}" /* string-offset:5636 */, P_0 * _0088_009A_0088, P_1 * _0088_009A_0088);
			return Math.Abs(P_0 - P_1);
		}

// Original MethodDef: 0x06000466; Original RVA: 0x6D958; Processed MethodDef: 0x06000465; Evidence: Procedure80260.source.txt:46371 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0098_009B()
		{

		}

// Original MethodDef: 0x06000467; Original RVA: 0x6D964; Processed MethodDef: 0x06000466; Evidence: Procedure80260.source.txt:46375 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0098_009C(ref List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4, double P_5 = 2.0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:900 */)
			{
				return;
			}
			num = Math.Abs(P_5);
			num2 = P_3;
			num3 = 0.0;
			// IL local declared at method entry
			if (!_0088_0090())
			{
				// IL local declared at method entry
				while (true)
				{
					if (num3 < P_4)
					{
						obj = new TemplatePoint(P_2 * Math.Cos(num2 * _0088_009A_0088), P_2 * Math.Sin(num2 * _0088_009A_0088));
						P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
						_0088_008F();
						if (!_0088_0090())
						{
							num2 += P_5;
							num3 += num;
						}
						else if (_0088_008F())
						{
							break;
						}
						continue;
					}
					num4 = ((P_5 > 0.0) ? (P_3 + P_4) : (P_3 - P_4));
					if (num2 - P_5 != num4)
					{
						break;
					}
					return;
				}
				obj = new TemplatePoint(P_2 * Math.Cos(num4 * _0088_009A_0088), P_2 * Math.Sin(num4 * _0088_009A_0088));
			}
			P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
		}

// Original MethodDef: 0x06000468; Original RVA: 0x6DB4C; Processed MethodDef: 0x06000467; Evidence: Procedure80260.source.txt:46418 + independent IL (decompilation/recovery, not runtime).
		static Procedure80260()
		{

			// Host licensing not executed in independent arithmetic recovery.
			_0088_009A_0088 = Math.PI / 180.0;
		}

// Original MethodDef: 0x06000469; Original RVA: 0x6DB78; Processed MethodDef: 0x06000468; Evidence: Procedure80260.source.txt:46424 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0088_008F()
		{

			return true;
		}

// Original MethodDef: 0x0600046A; Original RVA: 0x6DB84; Processed MethodDef: 0x06000469; Evidence: Procedure80260.source.txt:46429 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0088_0090()
		{

			return false;
		}
	}
}
