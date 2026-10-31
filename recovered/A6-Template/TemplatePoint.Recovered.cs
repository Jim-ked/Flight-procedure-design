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
	public class TemplatePoint
	{

		private string _008B_008A_0086;


		private string _008B_008A_0087;


		private double _008B_008A_0088;


		private double _008B_008A_0089;


		private double _008B_008A_008A;


		private double _008B_008A_008B;

		public string ID
		{

			get
			{
				return _008B_008A_0086;
			}

			set
			{
				_008B_008A_0086 = value;
			}
		}

		public string Name
		{

			get
			{
				return _008B_008A_0087;
			}

			set
			{
				_008B_008A_0087 = value;
			}
		}

		public double X
		{

			get
			{
				return _008B_008A_0088;
			}

			set
			{
				_008B_008A_0088 = value;
			}
		}

		public double Y
		{

			get
			{
				return _008B_008A_0089;
			}

			set
			{
				_008B_008A_0089 = value;
			}
		}

		public double Z
		{

			get
			{
				return _008B_008A_008A;
			}

			set
			{
				_008B_008A_008A = value;
			}
		}



// Original MethodDef: 0x06000803; Original RVA: 0xC8E50; Processed MethodDef: 0x06000802; Evidence: TemplatePoint.source.txt:84226 + independent IL (decompilation/recovery, not runtime).
		public double _008B_0089_009C()
		{

			return _008B_008A_008B;
		}



// Original MethodDef: 0x06000804; Original RVA: 0xC8E60; Processed MethodDef: 0x06000803; Evidence: TemplatePoint.source.txt:84233 + independent IL (decompilation/recovery, not runtime).
		public void _008B_0089_009D(double P_0)
		{

			_008B_008A_008B = P_0;
		}

// Original MethodDef: 0x06000805; Original RVA: 0xC8E70; Processed MethodDef: 0x06000804; Evidence: TemplatePoint.source.txt:84238 + independent IL (decompilation/recovery, not runtime).
		public TemplatePoint()
		{

		}

// Original MethodDef: 0x06000806; Original RVA: 0xC8E80; Processed MethodDef: 0x06000805; Evidence: TemplatePoint.source.txt:84242 + independent IL (decompilation/recovery, not runtime).
		public TemplatePoint(double P_0, double P_1, double P_2 = 0.0)
		{

			/* opaque discard 0 */
			if (_0089t())
			{
				// object constructor emitted automatically by C#
				X = P_0;
				Y = P_1;
			}
			Z = P_2;
		}

// Original MethodDef: 0x06000807; Original RVA: 0xC8F38; Processed MethodDef: 0x06000806; Evidence: TemplatePoint.source.txt:84254 + independent IL (decompilation/recovery, not runtime).
		public override string ToString()
		{

			return X + "," /* string-offset:704 */ + Y + "," /* string-offset:704 */ + Z;
		}

// Original MethodDef: 0x06000808; Original RVA: 0xC8FA4; Processed MethodDef: 0x06000807; Evidence: TemplatePoint.source.txt:84259 + independent IL (decompilation/recovery, not runtime).
		public static double _008B_0088_009E(TemplatePoint P_0, TemplatePoint P_1)
		{

			return Math.Sqrt((P_0.X - P_1.X) * (P_0.X - P_1.X) + (P_0.Y - P_1.Y) * (P_0.Y - P_1.Y));
		}

// Original MethodDef: 0x06000809; Original RVA: 0xC8FF4; Processed MethodDef: 0x06000808; Evidence: TemplatePoint.source.txt:84264 + independent IL (decompilation/recovery, not runtime).
		public static double _008B_0089_0086(TemplatePoint P_0, TemplatePoint P_1)
		{

			return Math.Atan2(P_1.Y - P_0.Y, P_1.X - P_0.X);
		}

// Original MethodDef: 0x0600080A; Original RVA: 0xC901C; Processed MethodDef: 0x06000809; Evidence: TemplatePoint.source.txt:84269 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_0087(double P_0, double P_1, double P_2 = 0.0)
		{

			return new TemplatePoint(P_0 * Math.Cos(P_1), P_0 * Math.Sin(P_1), P_2);
		}

// Original MethodDef: 0x0600080B; Original RVA: 0xC903C; Processed MethodDef: 0x0600080A; Evidence: TemplatePoint.source.txt:84274 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_0088(TemplatePoint P_0, TemplatePoint P_1)
		{

			return new TemplatePoint(P_0.X + P_1.X, P_0.Y + P_1.Y, P_0.Z + P_1.Z);
		}

// Original MethodDef: 0x0600080C; Original RVA: 0xC9074; Processed MethodDef: 0x0600080B; Evidence: TemplatePoint.source.txt:84279 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_0089(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{

			return new TemplatePoint(P_0.X + P_1.X + P_2.X, P_0.Y + P_1.Y + P_2.Y);
		}

// Original MethodDef: 0x0600080D; Original RVA: 0xC90B4; Processed MethodDef: 0x0600080C; Evidence: TemplatePoint.source.txt:84284 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_008A(TemplatePoint P_0, params TemplatePoint[] pts)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			int num = default(int); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals

			obj = P_0;
			// IL local declared at method entry
			if (!_0089u())
			{
				num = 0;
				_0089u();
				if (_0089t())
				{
					goto IL_001f;
				}
				goto IL_0031;
			}
			goto IL_0037;
			IL_0031:
			num++;
			goto IL_001f;
			IL_001f:
			if (num < pts.Length)
			{
				obj2 = pts[num];
				obj = _008B_0089_0088(obj, obj2);
				goto IL_0031;
			}
			goto IL_0037;
			IL_0037:
			return obj;
		}

// Original MethodDef: 0x0600080E; Original RVA: 0xC91A0; Processed MethodDef: 0x0600080D; Evidence: TemplatePoint.source.txt:84314 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_008B(TemplatePoint P_0)
		{

			return new TemplatePoint(P_0.X, 0.0 - P_0.Y, P_0.Z);
		}

// Original MethodDef: 0x0600080F; Original RVA: 0xC91C4; Processed MethodDef: 0x0600080E; Evidence: TemplatePoint.source.txt:84319 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_008C(TemplatePoint P_0)
		{

			return new TemplatePoint(P_0.X, P_0.Y);
		}

// Original MethodDef: 0x06000810; Original RVA: 0xC91E8; Processed MethodDef: 0x0600080F; Evidence: TemplatePoint.source.txt:84324 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_008D(TemplatePoint P_0, TemplatePoint P_1, double P_2)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			num = _008B_0088_009E(P_0, P_1);
			num2 = Math.Atan2(P_1.Y - P_0.Y, P_1.X - P_0.X);
			return _008B_0089_0088(P_0, _008B_0089_0087(num, num2 + P_2, P_1.Z));
		}

// Original MethodDef: 0x06000811; Original RVA: 0xC923C; Processed MethodDef: 0x06000810; Evidence: TemplatePoint.source.txt:84331 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_008E(TemplatePoint P_0, double P_1 = 0.0, double P_2 = 0.0, double P_3 = 0.0)
		{

			return new TemplatePoint(P_0.X + P_1, P_0.Y + P_2, P_0.Z + P_3);
		}

// Original MethodDef: 0x06000812; Original RVA: 0xC9264; Processed MethodDef: 0x06000811; Evidence: TemplatePoint.source.txt:84336 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_008F(TemplatePoint P_0, TemplatePoint P_1)
		{

			return new TemplatePoint(P_0.X + P_1.X, P_0.Y + P_1.Y, P_0.Z + P_1.Z);
		}

// Original MethodDef: 0x06000813; Original RVA: 0xC929C; Processed MethodDef: 0x06000812; Evidence: TemplatePoint.source.txt:84341 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_0090(TemplatePoint P_0, double P_1 = 1.0, double P_2 = 1.0, double P_3 = 1.0)
		{

			return new TemplatePoint(P_0.X * P_1, P_0.Y * P_2, P_0.Z * P_3);
		}

// Original MethodDef: 0x06000814; Original RVA: 0xC92C4; Processed MethodDef: 0x06000813; Evidence: TemplatePoint.source.txt:84346 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint _008B_0089_0091(TemplatePoint P_0, TemplatePoint P_1)
		{

			return new TemplatePoint(P_0.X * P_1.X, P_0.Y * P_1.Y, P_0.Z * P_1.Z);
		}

// Original MethodDef: 0x06000815; Original RVA: 0xC92FC; Processed MethodDef: 0x06000814; Evidence: TemplatePoint.source.txt:84351 + independent IL (decompilation/recovery, not runtime).
		public static VectorCarrier operator -(TemplatePoint P_0, TemplatePoint P_1)
		{

			return new VectorCarrier(P_0.X - P_1.X, P_0.Y - P_1.Y);
		}

// Original MethodDef: 0x06000816; Original RVA: 0xC9324; Processed MethodDef: 0x06000815; Evidence: TemplatePoint.source.txt:84356 + independent IL (decompilation/recovery, not runtime).
		public static TemplatePoint operator +(TemplatePoint P_0, VectorCarrier P_1)
		{

			return new TemplatePoint(P_0.X + P_1.X, P_0.Y + P_1.Y);
		}

// Original MethodDef: 0x06000817; Original RVA: 0xC9358; Processed MethodDef: 0x06000816; Evidence: TemplatePoint.source.txt:84361 + independent IL (decompilation/recovery, not runtime).
		static TemplatePoint()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x06000818; Original RVA: 0xC9374; Processed MethodDef: 0x06000817; Evidence: TemplatePoint.source.txt:84366 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089t()
		{

			return true;
		}

// Original MethodDef: 0x06000819; Original RVA: 0xC9380; Processed MethodDef: 0x06000818; Evidence: TemplatePoint.source.txt:84371 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089u()
		{

			return false;
		}
	}
}
