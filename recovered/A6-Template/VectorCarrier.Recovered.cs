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
	public struct VectorCarrier
	{

		private double _008B_008C_0088;


		private double _008B_008C_0089;

		public double X
		{

			get
			{
				return _008B_008C_0088;
			}

			set
			{
				_008B_008C_0088 = value;
			}
		}

		public double Y
		{

			get
			{
				return _008B_008C_0089;
			}

			set
			{
				_008B_008C_0089 = value;
			}
		}

// Original MethodDef: 0x0600084A; Original RVA: 0xCA584; Processed MethodDef: 0x06000849; Evidence: VectorCarrier.source.txt:84979 + independent IL (decompilation/recovery, not runtime).
		public VectorCarrier(double P_0, double P_1) : this()
		{

			X = P_0;
			Y = P_1;
		}


// Original MethodDef: 0x0600084B; Original RVA: 0xCA59C; Processed MethodDef: 0x0600084A; Evidence: VectorCarrier.source.txt:84986 + independent IL (decompilation/recovery, not runtime).
		public double _008B_008B_009D()
		{

			return Math.Sqrt(X * X + Y * Y);
		}


// Original MethodDef: 0x0600084C; Original RVA: 0xCA5C8; Processed MethodDef: 0x0600084B; Evidence: VectorCarrier.source.txt:84992 + independent IL (decompilation/recovery, not runtime).
		public double _008B_008C_0086()
		{

			return X * X + Y * Y;
		}

// Original MethodDef: 0x0600084D; Original RVA: 0xCA5EC; Processed MethodDef: 0x0600084C; Evidence: VectorCarrier.source.txt:84997 + independent IL (decompilation/recovery, not runtime).
		public double _008B_008B_0097(VectorCarrier P_0)
		{

			return X * P_0.X + Y * P_0.Y;
		}

// Original MethodDef: 0x0600084E; Original RVA: 0xCA614; Processed MethodDef: 0x0600084D; Evidence: VectorCarrier.source.txt:85002 + independent IL (decompilation/recovery, not runtime).
		public double _008B_008B_0098(VectorCarrier P_0)
		{

			return X * P_0.Y - Y * P_0.X;
		}

		public static VectorCarrier operator *(VectorCarrier P_0, double P_1)
		{

			return new VectorCarrier(P_0.X * P_1, P_0.Y * P_1);
		}

		public static VectorCarrier operator *(double P_0, VectorCarrier P_1)
		{

			return P_1 * P_0;
		}

// Original MethodDef: 0x06000851; Original RVA: 0xCA66C; Processed MethodDef: 0x06000850; Evidence: VectorCarrier.source.txt:85017 + independent IL (decompilation/recovery, not runtime).
		static VectorCarrier()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x06000852; Original RVA: 0xCA688; Processed MethodDef: 0x06000851; Evidence: VectorCarrier.source.txt:85022 + independent IL (decompilation/recovery, not runtime).
		internal static bool _008A_0087()
		{

			return true;
		}

// Original MethodDef: 0x06000853; Original RVA: 0xCA694; Processed MethodDef: 0x06000852; Evidence: VectorCarrier.source.txt:85027 + independent IL (decompilation/recovery, not runtime).
		internal static bool _008A_0088()
		{

			return false;
		}
	}
}
