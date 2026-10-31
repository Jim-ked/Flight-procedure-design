using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
// Processed source/IL recovery; identifiers and branches retained. No original DLL oracle.
namespace Recovered.B3 {
	public class RnpApchObstacle : TemplatePoint
	{
		public string _0088_008F_009C;

		public double _0088_008F_009D;

		public double _0088_008F_009E;

		public double _0088_0090_0086;

		public double _0088_0090_0087;

		public double _0088_0090_0088;

		public double _0088_0090_0089;

// R6 MethodDef: original 0x06000400 RVA 0x63850; processed 0x060003FF RVA 0x48C7; source :; processed IL recovery, not original runtime.
public RnpApchObstacle()
		{

		}

// R6 MethodDef: original 0x06000401 RVA 0x63860; processed 0x06000400 RVA 0x51A94; source 03_recovered-src/annotated-strings/--/--.cs:41572; processed IL recovery, not original runtime.
public RnpApchObstacle(TemplatePoint P_0)
		{

			do
			{
				base.ID = P_0.ID;
				/* opaque discard 1 */
				if (!_0087o())
				{
					base.Name = P_0.Name;
					base.X = P_0.X;
				}
				base.Y = P_0.Y;
			}
			while (_0087o());
			base.Z = P_0.Z;
		}

// R6 MethodDef: original 0x06000402 RVA 0x6396C; processed 0x06000401 RVA 0x48CF; source 03_recovered-src/annotated-strings/--/--.cs:41589; processed IL recovery, not original runtime.
static RnpApchObstacle()
		{

			// Host licensing not executed.
		}

// R6 MethodDef: original 0x06000403 RVA 0x63988; processed 0x06000402 RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:41594; processed IL recovery, not original runtime.
internal static bool _0087n()
		{

			return true;
		}

// R6 MethodDef: original 0x06000404 RVA 0x63994; processed 0x06000403 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:41599; processed IL recovery, not original runtime.
internal static bool _0087o()
		{

			return false;
		}
	}
}
