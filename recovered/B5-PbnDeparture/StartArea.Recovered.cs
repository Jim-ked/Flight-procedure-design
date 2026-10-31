using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
// Mechanical recovery of processed source/IL. Original identifiers retained.
// IL locals initialized once at entry. No target assembly or AutoCAD dependency.
namespace Recovered.B5 {
	internal class StartArea
	{
		public TemplatePoint _0089_009B_008A;

		public TemplatePoint _0089_009B_008B;

		public TemplatePoint _0089_009B_008C;

		public TemplatePoint _0089_009B_008D;

		public TemplatePoint _0089_009B_008E;

		public TemplatePoint _0089_009B_008F;

		private static double _0089_009B_0090;

		private const double _0089_009B_0091 = 1852.0;

		private const double _0089_009B_0092 = 3704.0;

		private const double _0089_009B_0093 = 6911.76;

		private const double _0089_009B_0094 = 13823.52;

		public List<List<TemplatePoint>> _0089_009B_0095;

// R5 MethodDef: original 0x06000589 RVA 0x94270; processed 0x06000588 RVA 0x5010; source :; processed IL recovery, not original runtime.
public StartArea()
		{

			_0089_009B_0095 = new List<List<TemplatePoint>>();
			// object constructor emitted automatically
		}

// R5 MethodDef: original 0x0600058A RVA 0x9428C; processed 0x06000589 RVA 0x78EB0; source 03_recovered-src/annotated-strings/--/--.cs:65664; processed IL recovery, not original runtime.
public StartArea(double P_0, bool P_1)
		{
			List<TemplatePoint> item5 = default(List<TemplatePoint>); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals
			List<TemplatePoint> item4 = default(List<TemplatePoint>); // IL InitLocals
			List<TemplatePoint> item2 = default(List<TemplatePoint>); // IL InitLocals
			List<TemplatePoint> item3 = default(List<TemplatePoint>); // IL InitLocals

			_00880();
			// IL local hoisted
			if (_0088_009F())
			{
				if (false /* original-file-bool-offset:1104 */)
				{
					return;
				}
				_0089_009B_0095 = new List<List<TemplatePoint>>();
				// object constructor emitted automatically
				num = (P_1 ? 1 : (-1));
				_0089_009B_008A = new TemplatePoint(0.0, 0.0);
				_0089_009B_008B = new TemplatePoint(P_0, 0.0);
				num2 = Math.Min(3704.0, P_0 * Math.Tan(_0089_009B_0090));
				if (P_0 < 6911.76)
				{
					_0089_009B_008E = new TemplatePoint(P_0, num * num2);
					item = new List<TemplatePoint> { _0089_009B_008A, _0089_009B_008E, _0089_009B_008B };
					_0089_009B_0095.Add(item);
					return;
				}
				// IL local hoisted
				if (P_0 < 13823.52)
				{
					_0089_009B_008C = new TemplatePoint(P_0, num * num2);
					if (_00880())
					{
						return;
					}
					_0089_009B_008E = new TemplatePoint(6911.76, num * 1852.0);
					_0089_009B_008F = new TemplatePoint(P_0, num * 1852.0);
					item2 = new List<TemplatePoint> { _0089_009B_008A, _0089_009B_008E, _0089_009B_008F, _0089_009B_008B };
					if (!_00880())
					{
						_0089_009B_0095.Add(item2);
						item3 = new List<TemplatePoint> { _0089_009B_008C, _0089_009B_008E, _0089_009B_008F, _0089_009B_008C };
						_0089_009B_0095.Add(item3);
						return;
					}
				}
				else
				{
					_0089_009B_008C = new TemplatePoint(13823.52, 3704.0 * num);
					_0089_009B_008D = new TemplatePoint(P_0, 3704.0 * num);
					_0089_009B_008E = new TemplatePoint(6911.76, 1852.0 * num);
					_0089_009B_008F = new TemplatePoint(P_0, 1852.0 * num);
					item4 = new List<TemplatePoint> { _0089_009B_008A, _0089_009B_008E, _0089_009B_008F, _0089_009B_008B };
				}
				_0089_009B_0095.Add(item4);
				item5 = new List<TemplatePoint> { _0089_009B_008C, _0089_009B_008D, _0089_009B_008F, _0089_009B_008E, _0089_009B_008C };
			}
			else if (_0088_009F())
			{
				return;
			}
			_0089_009B_0095.Add(item5);
		}

// R5 MethodDef: original 0x0600058B RVA 0x9472C; processed 0x0600058A RVA 0x5023; source 03_recovered-src/annotated-strings/--/--.cs:65724; processed IL recovery, not original runtime.
static StartArea()
		{

			// Host licensing not executed in independent recovery.
			_0089_009B_0090 = Math.PI / 12.0;
		}

// R5 MethodDef: original 0x0600058C RVA 0x94758; processed 0x0600058B RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:65730; processed IL recovery, not original runtime.
internal static bool _0088_009F()
		{

			return true;
		}

// R5 MethodDef: original 0x0600058D RVA 0x94764; processed 0x0600058C RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:65735; processed IL recovery, not original runtime.
internal static bool _00880()
		{

			return false;
		}
	}
}
