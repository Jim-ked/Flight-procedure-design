using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
// E1/E2 recovery. No target DLL or AutoCAD runtime. Original branches retained.
namespace Recovered.B4 {
	public class PlaneCarrier
	{
		public double _008B_008B_0092;

		public double _008B_008B_0093;

		public double _008B_008B_0094;

		public double _008B_008B_0095;

		public string _008B_008B_0096;

// R7 MethodDef: original 0x06000835 RVA 0xCA098; processed 0x06000834 RVA 0x931D4; source 03_recovered-src/annotated-strings/--/--.cs:84804; processed IL recovery, not original runtime.
public PlaneCarrier(double P_0 = 1.0, double P_1 = 1.0, double P_2 = 1.0, string P_3 = "")
		{

			_008B_008B_0092 = P_0;
			_0089y();
			if (_0089x())
			{
				if (_0089y())
				{
					return;
				}
				goto IL_0026;
			}
			goto IL_0043;
			IL_0043:
			_008B_008B_0096 = P_3;
			if (_0089x())
			{
				return;
			}
			goto IL_0026;
			IL_0026:
			_008B_008B_0093 = P_1;
			_008B_008B_0094 = P_2;
			_008B_008B_0095 = 0.0;
			goto IL_0043;
		}

// R7 MethodDef: original 0x06000836 RVA 0xCA194; processed 0x06000835 RVA 0x6356; source 03_recovered-src\annotated-strings\--\--.cs:84831; processed IL recovery, not original runtime.
public double _008B_008B_008A(double P_0, double P_1)
		{

			return _008B_008B_0092 * P_0 + _008B_008B_0093 * P_1 + _008B_008B_0094;
		}

// R7 MethodDef: original 0x06000837 RVA 0xCA1B8; processed 0x06000836 RVA 0x6370; source 03_recovered-src\annotated-strings\--\--.cs:84836; processed IL recovery, not original runtime.
public double _008B_008B_008B(double P_0, double P_1)
		{

			return _008B_008B_0091(P_1 - _008B_008B_0094 - _008B_008B_0093 * P_0, _008B_008B_0092);
		}

// R7 MethodDef: original 0x06000838 RVA 0xCA1E0; processed 0x06000837 RVA 0x638F; source 03_recovered-src\annotated-strings\--\--.cs:84841; processed IL recovery, not original runtime.
public double _008B_008B_008C(double P_0, double P_1)
		{

			return _008B_008B_0091(P_1 - _008B_008B_0094 - _008B_008B_0092 * P_0, _008B_008B_0093);
		}

// R7 MethodDef: original 0x06000839 RVA 0xCA208; processed 0x06000838 RVA 0x63AE; source 03_recovered-src\annotated-strings\--\--.cs:84846; processed IL recovery, not original runtime.
public LineCarrier _008B_008B_008D(PlaneCarrier P_0)
		{

			return new LineCarrier(_008B_008B_0092 - P_0._008B_008B_0092, _008B_008B_0093 - P_0._008B_008B_0093, _008B_008B_0094 - P_0._008B_008B_0094);
		}

// R7 MethodDef: original 0x0600083A RVA 0xCA240; processed 0x06000839 RVA 0x63DC; source 03_recovered-src\annotated-strings\--\--.cs:84851; processed IL recovery, not original runtime.
public LineCarrier _008B_008B_008E(double P_0)
		{

			return new LineCarrier(_008B_008B_0092, _008B_008B_0093, _008B_008B_0094 - P_0);
		}

// R7 MethodDef: original 0x0600083B RVA 0xCA264; processed 0x0600083A RVA 0x93234; source 03_recovered-src\annotated-strings\--\--.cs:84856; processed IL recovery, not original runtime.
public void _008B_008B_008F(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			if (!false /* original-file-bool-offset:1456 */)
			{
				num = P_0.X - P_1.X;
				_0089y();
				// IL local hoisted
				if (_0089x())
				{
					num2 = P_0.X - P_2.X;
				}
				num3 = P_0.Y - P_1.Y;
				num4 = P_0.Y - P_2.Y;
				num5 = P_0.Z - P_1.Z;
				num6 = P_0.Z - P_2.Z;
				if (_0089x())
				{
					_008B_008B_0092 = _008B_008B_0091(num5 * num4 - num6 * num3, num * num4 - num2 * num3);
					_008B_008B_0093 = _008B_008B_0091(num5 * num2 - num6 * num, num3 * num2 - num4 * num);
					_008B_008B_0094 = P_0.Z - _008B_008B_0092 * P_0.X - _008B_008B_0093 * P_0.Y;
				}
			}
		}

// R7 MethodDef: original 0x0600083C RVA 0xCA40C; processed 0x0600083B RVA 0x6027; source 03_recovered-src\annotated-strings\--\--.cs:84880; processed IL recovery, not original runtime.
public double _008B_008B_0090(double P_0)
		{

			if (P_0 > 0.0)
			{
				return 1000000.0;
			}
			return -1000000.0;
		}

// R7 MethodDef: original 0x0600083D RVA 0xCA438; processed 0x0600083C RVA 0x63F7; source 03_recovered-src\annotated-strings\--\--.cs:84889; processed IL recovery, not original runtime.
public double _008B_008B_0091(double P_0, double P_1)
		{

			if (P_1 != 0.0)
			{
				return P_0 / P_1;
			}
			return _008B_008B_0090(P_0);
		}

// R7 MethodDef: original 0x0600083E RVA 0xCA45C; processed 0x0600083D RVA 0x93320; source 03_recovered-src\annotated-strings\--\--.cs:84898; processed IL recovery, not original runtime.
public override string ToString()
		{

			return _008B_008B_0092 + "*x + " /* string-offset:7476 */ + _008B_008B_0093 + "*y + " /* string-offset:7480 */ + _008B_008B_0094 + " = z" /* string-offset:7496 */;
		}

// R7 MethodDef: original 0x0600083F RVA 0xCA4CC; processed 0x0600083E RVA 0x6410; source 03_recovered-src/annotated-strings/--/--.cs:84903; processed IL recovery, not original runtime.
static PlaneCarrier()
		{

			// host licensing excluded from independent recovery
		}

// R7 MethodDef: original 0x06000840 RVA 0xCA4E8; processed 0x0600083F RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:84908; processed IL recovery, not original runtime.
internal static bool _0089x()
		{

			return true;
		}

// R7 MethodDef: original 0x06000841 RVA 0xCA4F4; processed 0x06000840 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:84913; processed IL recovery, not original runtime.
internal static bool _0089y()
		{

			return false;
		}
	}
}
