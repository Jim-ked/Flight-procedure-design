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
	public class SideClassifier
	{
		private double _008A_009E_008C;

		private double _008A_009E_008D;

		private int _008A_009E_008E;


		private double _008A_009E_008F;



// Original MethodDef: 0x0600079A; Original RVA: 0xC4324; Processed MethodDef: 0x06000799; Evidence: SideClassifier.source.txt:81846 + independent IL (decompilation/recovery, not runtime).
		public double _008A_009E_0089()
		{

			return _008A_009E_008F;
		}



// Original MethodDef: 0x0600079B; Original RVA: 0xC4334; Processed MethodDef: 0x0600079A; Evidence: SideClassifier.source.txt:81853 + independent IL (decompilation/recovery, not runtime).
		public void _008A_009E_008A(double P_0)
		{

			_008A_009E_008F = P_0;
		}

// Original MethodDef: 0x0600079C; Original RVA: 0xC4344; Processed MethodDef: 0x0600079B; Evidence: SideClassifier.source.txt:81858 + independent IL (decompilation/recovery, not runtime).
		public SideClassifier(double P_0, double P_1, int P_2 = 1, double P_3 = 0.0)
		{

			_008A_009E_008C = P_0;
			_008A_009E_008D = P_1;
			/* opaque discard 1 */
			if (!_0089k())
			{
				_008A_009E_008E = P_2;
			}
			_008A_009E_008A(P_3);
		}

// Original MethodDef: 0x0600079D; Original RVA: 0xC4408; Processed MethodDef: 0x0600079C; Evidence: SideClassifier.source.txt:81870 + independent IL (decompilation/recovery, not runtime).
		public int _008A_009E_0088(double P_0, double P_1)
		{
			double num = default(double); // IL InitLocals
			double x = default(double); // IL InitLocals

			// IL local declared at method entry
			if (!false /* original-file-bool-offset:1356 */)
			{
				x = P_0 - _008A_009E_008C;
				if (!_0089k())
				{
					num = Math.Atan2(P_1 - _008A_009E_008D, x);
					num = _008F_008A._008B_0088_0088(num - _008A_009E_0089());
					num *= (double)_008A_009E_008E;
					/* opaque discard 0 */
					if (!_0089j())
					{
						goto IL_00a4;
					}
					if (!(num >= 0.0) || !(num < Math.PI / 2.0))
					{
						if (num >= Math.PI / 2.0)
						{
							goto IL_0072;
						}
						goto IL_0080;
					}
				}
				return 1;
			}
			goto IL_0072;
			IL_0091:
			if (num >= -Math.PI / 2.0)
			{
				if (!_0089j())
				{
					goto IL_00a4;
				}
				if (num < 0.0)
				{
					return 4;
				}
			}
			return 0;
			IL_0080:
			if (!(num >= -Math.PI))
			{
				goto IL_0091;
			}
			goto IL_00a4;
			IL_00a4:
			if (num < -Math.PI / 2.0)
			{
				return 3;
			}
			goto IL_0091;
			IL_0072:
			if (num < Math.PI)
			{
				return 2;
			}
			goto IL_0080;
		}

// Original MethodDef: 0x0600079E; Original RVA: 0xC45CC; Processed MethodDef: 0x0600079D; Evidence: SideClassifier.source.txt:81931 + independent IL (decompilation/recovery, not runtime).
		static SideClassifier()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x0600079F; Original RVA: 0xC45E8; Processed MethodDef: 0x0600079E; Evidence: SideClassifier.source.txt:81936 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089j()
		{

			return true;
		}

// Original MethodDef: 0x060007A0; Original RVA: 0xC45F4; Processed MethodDef: 0x0600079F; Evidence: SideClassifier.source.txt:81941 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089k()
		{

			return false;
		}
	}
}
