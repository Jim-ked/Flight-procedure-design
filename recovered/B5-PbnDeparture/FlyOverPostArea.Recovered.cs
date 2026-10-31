using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
// Mechanical recovery of processed source/IL. Original identifiers retained.
// IL locals initialized once at entry. No target assembly or AutoCAD dependency.
namespace Recovered.B5 {
	internal class FlyOverPostArea
	{
		public TemplatePoint _0089_009B_0096;

		public TemplatePoint _0089_009B_0097;

		public TemplatePoint _0089_009B_0098;

		public TemplatePoint _0089_009B_0099;

		public TemplatePoint _0089_009B_009A;

		public TemplatePoint _0089_009B_009B;

		public TemplatePoint _0089_009B_009C;

		private static double _0089_009B_009D;

		public List<List<TemplatePoint>> _0089_009B_009E;

// R5 MethodDef: original 0x0600058E RVA 0x94770; processed 0x0600058D RVA 0x5043; source :; processed IL recovery, not original runtime.
public FlyOverPostArea()
		{

			_0089_009B_009E = new List<List<TemplatePoint>>();
			// object constructor emitted automatically
		}

// R5 MethodDef: original 0x0600058F RVA 0x9478C; processed 0x0600058E RVA 0x791F0; source 03_recovered-src/annotated-strings/--/--.cs:65770; processed IL recovery, not original runtime.
public FlyOverPostArea(double P_0, TemplatePoint P_1, bool P_2)
		{
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			LineCarrier obj2 = default(LineCarrier); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals
			List<TemplatePoint> item2 = default(List<TemplatePoint>); // IL InitLocals

			if (false /* original-file-bool-offset:1108 */)
			{
				return;
			}
			_0089_009B_009E = new List<List<TemplatePoint>>();
			// object constructor emitted automatically
			_0089_009B_0096 = new TemplatePoint(0.0, 0.0);
			_0089_009B_0097 = P_1;
			_0089_009B_009C = new TemplatePoint(P_0, 0.0);
			obj = new LineCarrier();
			obj2 = new LineCarrier();
			// IL local hoisted
			if (_00881())
			{
				obj._008B_0088_008F(_0089_009B_0096, _0089_009B_009D);
				_00881();
				if (_00882())
				{
					goto IL_01ee;
				}
				obj2._008B_0088_008F(P_2 ? P_1 : TemplatePoint._008B_0089_008B(P_1), _0089_009B_009D);
				num = (P_2 ? 1 : (-1));
				if (_00881())
				{
					num2 = obj._008B_0088_008C(1852.0);
					num3 = obj2._008B_0088_008C(3704.0);
					if (!(P_0 >= num2))
					{
						goto IL_01ee;
					}
					if (!(P_0 < num3))
					{
						_0089_009B_0098 = new TemplatePoint(num2, num * 1852.0);
						_0089_009B_0099 = new TemplatePoint(num3, num * 3704.0);
						goto IL_0246;
					}
					_0089_009B_0098 = new TemplatePoint(num2, num * 1852.0);
					_0089_009B_0099 = new TemplatePoint(P_0, num * obj2._008B_0088_008D(P_0));
				}
			}
			_0089_009B_009A = new TemplatePoint(P_0, num * 1852.0);
			_0089_009B_009B = _0089_009B_0099;
			goto IL_0286;
			IL_0286:
			item = new List<TemplatePoint> { _0089_009B_0096, _0089_009B_0098, _0089_009B_009A, _0089_009B_009C };
			item2 = new List<TemplatePoint> { _0089_009B_0097, _0089_009B_0099, _0089_009B_009B, _0089_009B_009A, _0089_009B_0098, _0089_009B_0096 };
			_0089_009B_009E.Add(item);
			_0089_009B_009E.Add(item2);
			if (!_00882())
			{
				return;
			}
			goto IL_0246;
			IL_01ee:
			_0089_009B_0098 = new TemplatePoint(P_0, num * obj._008B_0088_008D(P_0));
			_0089_009B_009A = _0089_009B_0098;
			_0089_009B_0099 = new TemplatePoint(P_0, num * obj2._008B_0088_008D(P_0));
			_0089_009B_009B = _0089_009B_0099;
			goto IL_0286;
			IL_0246:
			_0089_009B_009A = new TemplatePoint(P_0, num * 1852.0);
			_0089_009B_009B = new TemplatePoint(P_0, num * 3704.0);
			goto IL_0286;
		}

// R5 MethodDef: original 0x06000590 RVA 0x94C40; processed 0x0600058F RVA 0x5056; source 03_recovered-src/annotated-strings/--/--.cs:65837; processed IL recovery, not original runtime.
static FlyOverPostArea()
		{

			// Host licensing not executed in independent recovery.
			_0089_009B_009D = Math.PI / 12.0;
		}

// R5 MethodDef: original 0x06000591 RVA 0x94C6C; processed 0x06000590 RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:65843; processed IL recovery, not original runtime.
internal static bool _00881()
		{

			return true;
		}

// R5 MethodDef: original 0x06000592 RVA 0x94C78; processed 0x06000591 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:65848; processed IL recovery, not original runtime.
internal static bool _00882()
		{

			return false;
		}
	}
}
