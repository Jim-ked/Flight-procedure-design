using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
// Mechanical recovery of processed source/IL. Original identifiers retained.
// IL locals initialized once at entry. No target assembly or AutoCAD dependency.
namespace Recovered.B5 {
public static class FrameHelpers {
// R5 MethodDef: original 0x060000AD RVA 0x83A0; processed 0x060000AC RVA 0xA650; source 03_recovered-src\annotated-strings\-\-.cs:3103; processed IL recovery, not original runtime.
public static RunwayFrame _0089_008F(TemplatePoint P_0, TemplatePoint P_1)
		{

			return new RunwayFrame
			{
				X = P_0.X,
				Y = P_0.Y,
				Z = P_0.Z,
				_008A_009D_0088 = Math.Sqrt(Math.Pow(P_1.Y - P_0.Y, 2.0) + Math.Pow(P_1.X - P_0.X, 2.0)),
				_008A_009D_0089 = Math.Atan2(P_1.Y - P_0.Y, P_1.X - P_0.X),
				_008A_009D_008A = Math.Atan2(P_0.Y - P_1.Y, P_0.X - P_1.X)
			};
		}

// R5 MethodDef: original 0x060000AE RVA 0x846C; processed 0x060000AD RVA 0xA714; source 03_recovered-src\annotated-strings\-\-.cs:3116; processed IL recovery, not original runtime.
public static TemplatePoint _0089_0090(RunwayFrame P_0, TemplatePoint P_1)
		{
			RunwayFrame obj = default(RunwayFrame); // IL InitLocals

			obj = _0089_008F(P_0, P_1);
			return new TemplatePoint
			{
				ID = P_1.ID,
				Name = P_1.Name,
				X = obj._008A_009D_0088 * Math.Cos(obj._008A_009D_0089 - P_0._008A_009D_008A),
				Y = obj._008A_009D_0088 * Math.Sin(obj._008A_009D_0089 - P_0._008A_009D_008A),
				Z = P_1.Z - P_0.Z
			};
		}

}
}
