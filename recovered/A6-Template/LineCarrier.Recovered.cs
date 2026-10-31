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
	public class LineCarrier
	{
		public double _008B_0088_009B;

		public double _008B_0088_009C;

		public double _008B_0088_009D;

// Original MethodDef: 0x060007E5; Original RVA: 0xC8590; Processed MethodDef: 0x060007E4; Evidence: LineCarrier.source.txt:83883 + independent IL (decompilation/recovery, not runtime).
		public LineCarrier(double P_0 = 1.0, double P_1 = 1.0, double P_2 = 1.0)
		{

			if (_0089r())
			{
				// object constructor emitted automatically by C#
				_0089s();
				if (!_0089r())
				{
					goto IL_0024;
				}
			}
			_008B_0088_009B = P_0;
			goto IL_0024;
			IL_0024:
			_008B_0088_009C = P_1;
			_008B_0088_009D = P_2;
		}

// Original MethodDef: 0x060007E6; Original RVA: 0xC8654; Processed MethodDef: 0x060007E5; Evidence: LineCarrier.source.txt:83901 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0088_008C(double P_0)
		{

			return _008B_0088_0091(0.0 - _008B_0088_009D - _008B_0088_009C * P_0, _008B_0088_009B);
		}

// Original MethodDef: 0x060007E7; Original RVA: 0xC867C; Processed MethodDef: 0x060007E6; Evidence: LineCarrier.source.txt:83906 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0088_008D(double P_0)
		{

			return _008B_0088_0091(0.0 - _008B_0088_009D - _008B_0088_009B * P_0, _008B_0088_009C);
		}

// Original MethodDef: 0x060007E8; Original RVA: 0xC86A4; Processed MethodDef: 0x060007E7; Evidence: LineCarrier.source.txt:83911 + independent IL (decompilation/recovery, not runtime).
		public void _008B_0088_008E(TemplatePoint P_0, TemplatePoint P_1)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals

			/* opaque discard 0 */
			if (_0089r())
			{
				goto IL_009a;
			}
			num = 2;
			if (!_0089s())
			{
				goto IL_0022;
			}
			goto IL_00b8;
			IL_0022:
			switch (num)
			{
			case 6:
				break;
			default:
				num = 5;
				goto IL_0086;
			case 5:
				goto IL_0086;
			case 0:
			case 4:
				goto IL_009a;
			case 1:
			case 2:
				goto IL_00a1;
			case 7:
				goto IL_00b1;
			case 3:
				goto IL_00b8;
			case 8:
				return;
			}
			goto IL_0051;
			IL_009a:
			num2 = P_0.X;
			goto IL_00a1;
			IL_00a1:
			num3 = P_0.Y;
			num = 7;
			goto IL_00b1;
			IL_00b1:
			num4 = P_1.X;
			goto IL_00b8;
			IL_00b8:
			num5 = P_1.Y;
			goto IL_0086;
			IL_0086:
			_008B_0088_009B = num5 - num3;
			num = 6;
			goto IL_0051;
			IL_0051:
			_008B_0088_009C = num2 - num4;
			_008B_0088_009D = num3 * (num4 - num2) - num2 * (num5 - num3);
			num = 8;
			if (!_0089s())
			{
				goto IL_0022;
			}
			goto IL_00b8;
		}

// Original MethodDef: 0x060007E9; Original RVA: 0xC87B0; Processed MethodDef: 0x060007E8; Evidence: LineCarrier.source.txt:83976 + independent IL (decompilation/recovery, not runtime).
		public void _008B_0088_008F(TemplatePoint P_0, double P_1)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals

			obj = TemplatePoint._008B_0089_0088(P_0, TemplatePoint._008B_0089_0087(1000.0, P_1));
			_008B_0088_008E(P_0, obj);
		}

// Original MethodDef: 0x060007EA; Original RVA: 0xC87EC; Processed MethodDef: 0x060007E9; Evidence: LineCarrier.source.txt:83982 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0088_0090(double P_0)
		{

			if (P_0 > 0.0)
			{
				return 1000000.0;
			}
			return -1000000.0;
		}

// Original MethodDef: 0x060007EB; Original RVA: 0xC8818; Processed MethodDef: 0x060007EA; Evidence: LineCarrier.source.txt:83991 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0088_0091(double P_0, double P_1)
		{

			if (P_1 != 0.0)
			{
				return P_0 / P_1;
			}
			return _008B_0088_0090(P_0);
		}

// Original MethodDef: 0x060007EC; Original RVA: 0xC883C; Processed MethodDef: 0x060007EB; Evidence: LineCarrier.source.txt:84000 + independent IL (decompilation/recovery, not runtime).
		public override string ToString()
		{

			return _008B_0088_009B + "*x + " /* string-offset:7476 */ + _008B_0088_009C + "*y + " /* string-offset:7480 */ + _008B_0088_009D + " = 0" /* string-offset:7484 */;
		}

// Original MethodDef: 0x060007ED; Original RVA: 0xC88AC; Processed MethodDef: 0x060007EC; Evidence: LineCarrier.source.txt:84005 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0088_0092(TemplatePoint P_0)
		{

			return Math.Abs(_008B_0088_009B * P_0.X + _008B_0088_009C * P_0.Y + _008B_0088_009D) / Math.Sqrt(_008B_0088_009B * _008B_0088_009B + _008B_0088_009C * _008B_0088_009C);
		}

// Original MethodDef: 0x060007EE; Original RVA: 0xC8908; Processed MethodDef: 0x060007ED; Evidence: LineCarrier.source.txt:84010 + independent IL (decompilation/recovery, not runtime).
		public TemplatePoint _008B_0088_0093(LineCarrier P_0)
		{

			return new TemplatePoint
			{
				X = _008B_0088_0091(P_0._008B_0088_009D * _008B_0088_009C - _008B_0088_009D * P_0._008B_0088_009C, _008B_0088_009B * P_0._008B_0088_009C - P_0._008B_0088_009B * _008B_0088_009C),
				Y = _008B_0088_0091(P_0._008B_0088_009D * _008B_0088_009B - _008B_0088_009D * P_0._008B_0088_009B, _008B_0088_009C * P_0._008B_0088_009B - P_0._008B_0088_009C * _008B_0088_009B)
			};
		}

// Original MethodDef: 0x060007EF; Original RVA: 0xC89A8; Processed MethodDef: 0x060007EE; Evidence: LineCarrier.source.txt:84019 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0088_0094()
		{

			if (_008B_0088_009C == 0.0)
			{
				return Math.PI / 2.0;
			}
			return Math.Atan((0.0 - _008B_0088_009B) / _008B_0088_009C);
		}

// Original MethodDef: 0x060007F0; Original RVA: 0xC89E4; Processed MethodDef: 0x060007EF; Evidence: LineCarrier.source.txt:84028 + independent IL (decompilation/recovery, not runtime).
		public TemplatePoint _008B_0088_0095(TemplatePoint P_0)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			if (!false /* original-file-bool-offset:1440 */)
			{
				obj = new TemplatePoint(0.0, 0.0);
				obj.Y = _008B_0088_008D(0.0);
				if (obj.X == P_0.X)
				{
					_0089r();
					if (_0089s() || obj.Y == P_0.Y)
					{
						return obj;
					}
				}
				num = TemplatePoint._008B_0088_009E(P_0, obj);
			}
			num2 = TemplatePoint._008B_0089_0086(obj, P_0);
			num3 = _008B_0088_0094();
			if (num2 > num3)
			{
				num3 += Math.PI * 2.0;
			}
			return TemplatePoint._008B_0089_0088(obj, TemplatePoint._008B_0089_0087(num, 2.0 * num3 - num2));
		}

// Original MethodDef: 0x060007F1; Original RVA: 0xC8B78; Processed MethodDef: 0x060007F0; Evidence: LineCarrier.source.txt:84055 + independent IL (decompilation/recovery, not runtime).
		public static double _008B_0088_0096(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{
			VectorCarrier obj = default(VectorCarrier); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			obj = P_1 - P_0;
			num = (P_2 - P_0)._008B_008B_0097(obj);
			num2 = obj._008B_008B_0097(obj);
			if (Math.Abs(num2) < 1E-10)
			{
				throw new ArgumentException("线段长度不能为0" /* string-offset:7488 */);
			}
			return num / num2;
		}

// Original MethodDef: 0x060007F2; Original RVA: 0xC8BD4; Processed MethodDef: 0x060007F1; Evidence: LineCarrier.source.txt:84067 + independent IL (decompilation/recovery, not runtime).
		public static bool _008B_0088_0097(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{
			double num = default(double); // IL InitLocals

			num = _008B_0088_0096(P_0, P_1, P_2);
			if (!(num < 0.0))
			{
				return num > 1.0;
			}
			return true;
		}

// Original MethodDef: 0x060007F3; Original RVA: 0xC8C10; Processed MethodDef: 0x060007F2; Evidence: LineCarrier.source.txt:84077 + independent IL (decompilation/recovery, not runtime).
		public static bool _008B_0088_0098(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{
			double num = default(double); // IL InitLocals

			num = _008B_0088_0096(P_0, P_1, P_2);
			if (num >= 0.0)
			{
				return num <= 1.0;
			}
			return false;
		}

// Original MethodDef: 0x060007F4; Original RVA: 0xC8C50; Processed MethodDef: 0x060007F3; Evidence: LineCarrier.source.txt:84087 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0088_0099(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{
			double num = default(double); // IL InitLocals
			VectorCarrier obj = default(VectorCarrier); // IL InitLocals

			num = _008B_0088_0096(P_0, P_1, P_2);
			obj = P_1 - P_0;
			return P_0 + obj * num;
		}

// Original MethodDef: 0x060007F5; Original RVA: 0xC8C84; Processed MethodDef: 0x060007F4; Evidence: LineCarrier.source.txt:84094 + independent IL (decompilation/recovery, not runtime).
		public static double _008B_0088_009A(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{
			double num = default(double); // IL InitLocals
			VectorCarrier obj = default(VectorCarrier); // IL InitLocals
			VectorCarrier obj2 = default(VectorCarrier); // IL InitLocals

			/* opaque discard 0 */
			// IL local declared at method entry
			if (_0089r())
			{
				num = _008B_0088_0096(P_0, P_1, P_2);
			}
			if (num < 0.0)
			{
				return TemplatePoint._008B_0088_009E(P_2, P_0);
			}
			if (num > 1.0)
			{
				return TemplatePoint._008B_0088_009E(P_2, P_1);
			}
			obj = P_1 - P_0;
			obj2 = P_2 - P_0;
			return Math.Abs(obj._008B_008B_0098(obj2)) / obj._008B_008B_009D();
		}

// Original MethodDef: 0x060007F6; Original RVA: 0xC8D7C; Processed MethodDef: 0x060007F5; Evidence: LineCarrier.source.txt:84115 + independent IL (decompilation/recovery, not runtime).
		static LineCarrier()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x060007F7; Original RVA: 0xC8D98; Processed MethodDef: 0x060007F6; Evidence: LineCarrier.source.txt:84120 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089r()
		{

			return true;
		}

// Original MethodDef: 0x060007F8; Original RVA: 0xC8DA4; Processed MethodDef: 0x060007F7; Evidence: LineCarrier.source.txt:84125 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089s()
		{

			return false;
		}
	}
}
