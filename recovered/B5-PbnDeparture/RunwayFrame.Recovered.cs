using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
// Mechanical recovery of processed source/IL. Original identifiers retained.
// IL locals initialized once at entry. No target assembly or AutoCAD dependency.
namespace Recovered.B5 {
	public class RunwayFrame : TemplatePoint
	{
		public double _008A_009D_0088;

		public double _008A_009D_0089;

		public double _008A_009D_008A;

		private double _008A_009D_008B;

		private double _008A_009D_008C;

		private double _008A_009D_008D;


// R5 MethodDef: original 0x0600077E RVA 0xC3360; processed 0x0600077D RVA 0x5D2E; source 03_recovered-src\annotated-strings\--\--.cs:81532; processed IL recovery, not original runtime.
public double _008A_009C_0098()
		{

			return _008A_009D_008B;
		}


// R5 MethodDef: original 0x0600077F RVA 0xC3370; processed 0x0600077E RVA 0x5D36; source 03_recovered-src\annotated-strings\--\--.cs:81539; processed IL recovery, not original runtime.
public void _008A_009C_0099(double P_0)
		{

			_008A_009D_008B = P_0;
		}


// R5 MethodDef: original 0x06000780 RVA 0xC3380; processed 0x0600077F RVA 0x5D3F; source 03_recovered-src\annotated-strings\--\--.cs:81546; processed IL recovery, not original runtime.
public double _008A_009C_009B()
		{

			return _008A_009D_008C;
		}


// R5 MethodDef: original 0x06000781 RVA 0xC3390; processed 0x06000780 RVA 0x5D47; source 03_recovered-src\annotated-strings\--\--.cs:81553; processed IL recovery, not original runtime.
public void _008A_009C_009C(double P_0)
		{

			_008A_009D_008C = P_0;
		}


// R5 MethodDef: original 0x06000782 RVA 0xC33A0; processed 0x06000781 RVA 0x5D50; source 03_recovered-src\annotated-strings\--\--.cs:81560; processed IL recovery, not original runtime.
public double _008A_009C_009E()
		{

			return _008A_009D_008D;
		}


// R5 MethodDef: original 0x06000783 RVA 0xC33B0; processed 0x06000782 RVA 0x5D58; source 03_recovered-src\annotated-strings\--\--.cs:81567; processed IL recovery, not original runtime.
public void _008A_009D_0086(double P_0)
		{

			_008A_009D_008D = P_0;
		}

// R5 MethodDef: original 0x06000784 RVA 0xC33C0; processed 0x06000783 RVA 0x5D61; source 03_recovered-src/annotated-strings/--/--.cs:81572; processed IL recovery, not original runtime.
public RunwayFrame(string P_0, double P_1, double P_2, double P_3)
		{

			_0089d();
			if (!_0089e())
			{
				// object constructor emitted automatically
			}
			base.Name = P_0;
			_008A_009C_009C(P_1);
			_008A_009C_0099(P_2);
			_008A_009D_0086(P_3);
		}

// R5 MethodDef: original 0x06000785 RVA 0xC3494; processed 0x06000784 RVA 0x5D96; source 03_recovered-src/annotated-strings/--/--.cs:81585; processed IL recovery, not original runtime.
public RunwayFrame(string P_0, double P_1, double P_2)
		{

			if (_0089d())
			{
				base.Name = P_0;
				/* opaque discard 1 */
				if (!_0089e())
				{
					_008A_009C_009C(P_1);
				}
			}
			_008A_009C_0099(P_2);
		}

// R5 MethodDef: original 0x06000786 RVA 0xC354C; processed 0x06000785 RVA 0x48C7; source :; processed IL recovery, not original runtime.
public RunwayFrame()
		{

		}

// R5 MethodDef: original 0x06000787 RVA 0xC355C; processed 0x06000786 RVA 0x8E9CC; source 03_recovered-src\annotated-strings\--\--.cs:81603; processed IL recovery, not original runtime.
public override string ToString()
		{

			return _008A_009C_009B() + "," /* string-offset:704 */ + _008A_009C_0098() + "," /* string-offset:704 */ + _008A_009C_009E() + " " /* string-offset:584 */;
		}

// R5 MethodDef: original 0x06000788 RVA 0xC35D8; processed 0x06000787 RVA 0x8EA40; source 03_recovered-src\annotated-strings\--\--.cs:81608; processed IL recovery, not original runtime.
public static string _008A_009C_0095(List<RunwayFrame> P_0)
		{
			string text = default(string); // IL InitLocals

			text = "";
			if (P_0 == null)
			{
				return text;
			}
			foreach (RunwayFrame item in P_0)
			{
				text += item.ToString();
			}
			return text;
		}

// R5 MethodDef: original 0x06000789 RVA 0xC364C; processed 0x06000788 RVA 0x8EAA4; source 03_recovered-src\annotated-strings\--\--.cs:81622; processed IL recovery, not original runtime.
public static List<TemplatePoint> _008A_009C_0096(List<RunwayFrame> P_0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			if (P_0 == null)
			{
				return list;
			}
			foreach (RunwayFrame item in P_0)
			{
				list.Add(new TemplatePoint(item.X, item.Y, item.Z));
			}
			return list;
		}

// R5 MethodDef: original 0x0600078A RVA 0xC36D0; processed 0x06000789 RVA 0x8EB18; source 03_recovered-src\annotated-strings\--\--.cs:81636; processed IL recovery, not original runtime.
public static List<RunwayFrame> _008A_009C_0097(List<TemplatePoint> P_0)
		{
			List<RunwayFrame> list = default(List<RunwayFrame>); // IL InitLocals
			RunwayFrame obj = default(RunwayFrame); // IL InitLocals

			list = new List<RunwayFrame>();
			if (P_0 == null)
			{
				return list;
			}
			foreach (TemplatePoint item in P_0)
			{
				obj = new RunwayFrame();
				obj.X = item.X;
				obj.Y = item.Y;
				obj.Z = item.Z;
				obj.Name = item.Name;
				list.Add(obj);
			}
			return list;
		}

// R5 MethodDef: original 0x0600078B RVA 0xC3774; processed 0x0600078A RVA 0x5DC6; source 03_recovered-src/annotated-strings/--/--.cs:81655; processed IL recovery, not original runtime.
static RunwayFrame()
		{

			// Host licensing not executed in independent recovery.
		}

// R5 MethodDef: original 0x0600078C RVA 0xC3790; processed 0x0600078B RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:81660; processed IL recovery, not original runtime.
internal static bool _0089d()
		{

			return true;
		}

// R5 MethodDef: original 0x0600078D RVA 0xC379C; processed 0x0600078C RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:81665; processed IL recovery, not original runtime.
internal static bool _0089e()
		{

			return false;
		}
	}
}
