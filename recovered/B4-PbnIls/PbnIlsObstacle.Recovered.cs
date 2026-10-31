using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
// E1/E2 recovery. No target DLL or AutoCAD runtime. Original branches retained.
namespace Recovered.B4 {
	public class PbnIlsObstacle : TemplatePoint
	{
		public string _0088_0090_008A;

		public double _0088_0090_008B;

		public double _0088_0090_008C;

		public double _0088_0090_008D;

		public double _0088_0090_008E;

		public double _0088_0090_008F;

		public double _0088_0090_0090;

		public double _0088_0090_0091;

		public double _0088_0090_0092;

		public double _0088_0090_0093;

// R7 MethodDef: original 0x06000405 RVA 0x639A0; processed 0x06000404 RVA 0x48C7; source :; processed IL recovery, not original runtime.
public PbnIlsObstacle()
		{

		}

// R7 MethodDef: original 0x06000406 RVA 0x639B0; processed 0x06000405 RVA 0x51AF8; source 03_recovered-src/annotated-strings/--/--.cs:41634; processed IL recovery, not original runtime.
public PbnIlsObstacle(TemplatePoint P_0)
		{

			base.ID = P_0.ID;
			base.Name = P_0.Name;
			/* opaque discard 1 */
			if (!_0087q())
			{
				base.X = P_0.X;
			}
			base.Y = P_0.Y;
			base.Z = P_0.Z;
		}

// R7 MethodDef: original 0x06000407 RVA 0x63AB0; processed 0x06000406 RVA 0x48E1; source 03_recovered-src/annotated-strings/--/--.cs:41647; processed IL recovery, not original runtime.
static PbnIlsObstacle()
		{

			// host licensing excluded from independent recovery
		}

// R7 MethodDef: original 0x06000408 RVA 0x63ACC; processed 0x06000407 RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:41652; processed IL recovery, not original runtime.
internal static bool _0087p()
		{

			return true;
		}

// R7 MethodDef: original 0x06000409 RVA 0x63AD8; processed 0x06000408 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:41657; processed IL recovery, not original runtime.
internal static bool _0087q()
		{

			return false;
		}
	}
}
