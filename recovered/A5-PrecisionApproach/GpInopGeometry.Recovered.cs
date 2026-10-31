using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Recovered.A6;
using Recovered.B5;
using Recovered.B4;
// E1/E2 extraction. Only independent source, no target DLL or CAD execution.
namespace Recovered.A5 {
	public class GpInopGeometry
	{
		public OasModel _0088_0087_008D;

		public TemplatePoint _0088_0087_008E;

		public TemplatePoint _0088_0087_008F;

		public TemplatePoint _0088_0087_0090;

		public TemplatePoint _0088_0087_0091;

		public TemplatePoint _0088_0087_0092;

		public TemplatePoint _0088_0087_0093;

		public TemplatePoint _0088_0087_0094;

		public TemplatePoint _0088_0087_0095;

		public TemplatePoint _0088_0087_0096;

		public TemplatePoint _0088_0087_0097;

		public Dictionary<string, string> _0088_0087_0098;

		public List<List<TemplatePoint>> _0088_0087_0099;

		// R8 MethodDef: original 0x0600039F RVA 0x5CA54; processed 0x0600039E RVA 0x4CA9C; source 03_recovered-src/annotated-strings/--/--.cs:38366; processed IL recovery, not original runtime.
public GpInopGeometry(OasModel P_0, TemplatePoint P_1, TemplatePoint P_2)
		{

			if (!_0087a())
			{
				if (!true /* original-file-bool-offset:664 */)
				{
					return;
				}
				_0088_0087_0099 = new List<List<TemplatePoint>>();
				_0087a();
				if (!_00879())
				{
					goto IL_01e9;
				}
				if (!_00879())
				{
					goto IL_004c;
				}
			}
			// implicit object constructor
			_0088_0087_008D = P_0;
			_0088_0087_0096 = P_1;
			goto IL_004c;
			IL_01e9:
			_0088_0086_009D();
			return;
			IL_004c:
			_0088_0087_0097 = P_2;
			_0088_0087_0090 = new TemplatePoint(_0088_0087_0097.X, _0088_0087_008D._0088_0091_0094._008B_0088_008D(_0088_0087_0097.X), _0088_0087_0097.Z - 150.0);
			_0088_0087_0091 = new TemplatePoint(_0088_0087_0097.X, _0088_0087_0090.Y, _0088_0087_0097.Z);
			_0088_0087_008E = new TemplatePoint(_0088_0087_0096.X, 4630.0, _0088_0087_0096.Z - 150.0);
			_0088_0087_008F = new TemplatePoint(_0088_0087_0096.X, 9260.0, _0088_0087_0096.Z);
			_0088_0087_0092 = new TemplatePoint(_0088_0087_0090.X, _0088_0087_0090.Y);
			_0088_0087_0093 = new TemplatePoint(_0088_0087_0091.X, _0088_0087_0091.Y, 75.0);
			if (_00879())
			{
				_0088_0087_0095 = new TemplatePoint(_0088_0087_008D._0088_0091_008E.X, _0088_0087_008D._0088_0091_008E.Y, 75.0);
				_0088_0087_0094 = new TemplatePoint(_0088_0087_008D._0088_0091_0091.X, _0088_0087_008D._0088_0091_0091.Y, 75.0);
				goto IL_01e9;
			}
		}

		// R8 MethodDef: original 0x060003A0 RVA 0x5CD38; processed 0x0600039F RVA 0x4CC98; source 03_recovered-src\annotated-strings\--\--.cs:38408; processed IL recovery, not original runtime.
public void _0088_0086_009D()
		{

			_0088_0087_0098 = new Dictionary<string, string>();
			/* opaque discard 1 */
			if (!_0087a())
			{
				_0088_0087_0086();
				_0088_0087_0087();
				_0088_0087_0088();
				_0088_0087_0089();
				if (!_0087a())
				{
					_0088_0087_008A();
				}
			}
			_0088_0087_008B();
			_0088_0087_0099.Add(_0088_0087_008D._0088_0091_0087());
		}

		// R8 MethodDef: original 0x060003A1 RVA 0x5CE54; processed 0x060003A0 RVA 0x4CD00; source 03_recovered-src\annotated-strings\--\--.cs:38427; processed IL recovery, not original runtime.
private void _0088_0086_009E(TemplatePoint P_0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (P_0.Z != 0.0)
			{
				/* opaque discard 0 */
				// IL local hoisted
				if (_00879())
				{
					list = new List<TemplatePoint>();
					list.Add(P_0);
				}
				list.Add(TemplatePoint._008B_0089_008C(P_0));
				_0088_0087_0099.Add(list);
			}
		}

		// R8 MethodDef: original 0x060003A2 RVA 0x5CF3C; processed 0x060003A1 RVA 0x4CD50; source 03_recovered-src\annotated-strings\--\--.cs:38443; processed IL recovery, not original runtime.
private void _0088_0087_0086()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			/* opaque discard 1 */
			// IL local hoisted
			if (!_0087a())
			{
				list = PointLists._008B_008A_0092(_0088_0087_0090, _0088_0087_008E);
			}
			_0088_0087_0099.Add(list);
			_0088_0087_0099.Add(PointLists._008B_008A_0099(list));
			_0088_0086_009E(_0088_0087_0090);
			_0088_0086_009E(TemplatePoint._008B_0089_008B(_0088_0087_0090));
			_0088_0086_009E(_0088_0087_008E);
			_0088_0086_009E(TemplatePoint._008B_0089_008B(_0088_0087_008E));
		}

		// R8 MethodDef: original 0x060003A3 RVA 0x5D05C; processed 0x060003A2 RVA 0x4CDD4; source 03_recovered-src\annotated-strings\--\--.cs:38459; processed IL recovery, not original runtime.
private void _0088_0087_0087()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			_0087a();
			// IL local hoisted
			if (_00879())
			{
				list = new List<TemplatePoint>();
				do
				{
					list.Add(_0088_0087_008E);
				}
				while (_0087a());
				list.Add(_0088_0087_0090);
				list.Add(_0088_0087_0091);
				list.Add(_0088_0087_008F);
				list.Add(_0088_0087_008E);
			}
			_0088_0087_0099.Add(list);
			_0088_0087_0099.Add(PointLists._008B_008A_0099(list));
			_0088_0086_009E(_0088_0087_008F);
		}

		// R8 MethodDef: original 0x060003A4 RVA 0x5D1B0; processed 0x060003A3 RVA 0x4CE64; source 03_recovered-src\annotated-strings\--\--.cs:38481; processed IL recovery, not original runtime.
private void _0088_0087_0088()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_008E));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_0090));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_0091));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_008F));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_008E));
			_00879();
			if (!_0087a())
			{
				_0088_0087_0099.Add(list);
			}
			_0088_0087_0099.Add(PointLists._008B_008A_0099(list));
			_0088_0086_009E(TemplatePoint._008B_0089_008B(_0088_0087_008F));
		}

		// R8 MethodDef: original 0x060003A5 RVA 0x5D30C; processed 0x060003A4 RVA 0x4CF0C; source 03_recovered-src\annotated-strings\--\--.cs:38498; processed IL recovery, not original runtime.
private void _0088_0087_0089()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			// IL local hoisted
			while (true)
			{
				if (!false /* original-file-bool-offset:668 */)
				{
					list = new List<TemplatePoint>();
					list.Add(_0088_0087_0093);
					list.Add(_0088_0087_0095);
					if (_0087a())
					{
						continue;
					}
					list.Add(_0088_0087_008D._0088_0091_008D);
					list.Add(_0088_0087_008D._0088_0091_0089);
					list.Add(TemplatePoint._008B_0089_008B(_0088_0087_008D._0088_0091_0089));
					if (!_00879())
					{
						break;
					}
					list.Add(TemplatePoint._008B_0089_008B(_0088_0087_008D._0088_0091_008D));
					list.Add(TemplatePoint._008B_0089_008B(_0088_0087_0095));
				}
				else
				{
					_00879();
					if (!_0087a())
					{
						return;
					}
				}
				list.Add(TemplatePoint._008B_0089_008B(_0088_0087_0093));
				list.Add(_0088_0087_0093);
				_0088_0087_0099.Add(list);
				_0088_0087_0099.Add(PointLists._008B_008A_0099(list));
				_0088_0086_009E(_0088_0087_0095);
				break;
			}
			_0088_0086_009E(TemplatePoint._008B_0089_008B(_0088_0087_0095));
			_0088_0086_009E(_0088_0087_0093);
			_0088_0086_009E(TemplatePoint._008B_0089_008B(_0088_0087_0093));
		}

		// R8 MethodDef: original 0x060003A6 RVA 0x5D530; processed 0x060003A5 RVA 0x4D03C; source 03_recovered-src\annotated-strings\--\--.cs:38542; processed IL recovery, not original runtime.
private void _0088_0087_008A()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			// IL local hoisted
			if (!false /* original-file-bool-offset:672 */)
			{
				list = new List<TemplatePoint>();
				list.Add(_0088_0087_0095);
				list.Add(_0088_0087_008D._0088_0091_008D);
				list.Add(_0088_0087_008D._0088_0091_0090);
				list.Add(_0088_0087_0094);
				list.Add(_0088_0087_0095);
				_0088_0087_0099.Add(list);
				_0088_0087_0099.Add(PointLists._008B_008A_0099(list));
				_0088_0086_009E(_0088_0087_0095);
				_00879();
				if (!_0087a())
				{
					goto IL_0099;
				}
				goto IL_012e;
			}
			return;
			IL_012e:
			_0088_0086_009E(TemplatePoint._008B_0089_008B(_0088_0087_0095));
			_0088_0086_009E(TemplatePoint._008B_0089_008B(_0088_0087_0094));
			if (!_0087a())
			{
				return;
			}
			goto IL_0099;
			IL_0099:
			_0088_0086_009E(_0088_0087_0094);
			list = new List<TemplatePoint>();
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_0095));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_008D._0088_0091_008D));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_008D._0088_0091_0090));
			if (!_0087a())
			{
			}
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_0094));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0087_0095));
			_0088_0087_0099.Add(list);
			_0088_0087_0099.Add(PointLists._008B_008A_0099(list));
			goto IL_012e;
		}

		// R8 MethodDef: original 0x060003A7 RVA 0x5D7AC; processed 0x060003A6 RVA 0x4D1A4; source 03_recovered-src\annotated-strings\--\--.cs:38588; processed IL recovery, not original runtime.
private void _0088_0087_008B()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = PointLists._008B_008A_0092(_0088_0087_0094, _0088_0087_008D._0088_0091_0090);
			_0087a();
			if (_00879())
			{
				_0088_0087_0099.Add(list);
			}
			_0088_0087_0099.Add(PointLists._008B_008A_0099(list));
		}

		// R8 MethodDef: original 0x060003A8 RVA 0x5D86C; processed 0x060003A7 RVA 0x4D1F8; source 03_recovered-src\annotated-strings\--\--.cs:38599; processed IL recovery, not original runtime.
public void _0088_0087_008C(double P_0 = 10000.0)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals

			_00879();
			// IL local hoisted
			if (!_0087a())
			{
				obj = TemplatePoint._008B_0089_008E(_0088_0087_008D._0088_0091_0091, (0.0 - P_0) * Math.Cos(-Math.PI / 12.0), (0.0 - P_0) * Math.Sin(-Math.PI / 12.0));
			}
			do
			{
				List<TemplatePoint> item = new List<TemplatePoint>
				{
					obj,
					_0088_0087_008D._0088_0091_0091,
					TemplatePoint._008B_0089_008B(_0088_0087_008D._0088_0091_0091),
					TemplatePoint._008B_0089_008B(obj)
				};
				_0088_0087_0099.Add(item);
			}
			while (!_00879());
		}

		// R8 MethodDef: original 0x060003A9 RVA 0x5D984; processed 0x060003A8 RVA 0x476C; source 03_recovered-src/annotated-strings/--/--.cs:38621; processed IL recovery, not original runtime.
static GpInopGeometry()
		{

			// original licensing excluded; independent source only
		}

		// R8 MethodDef: original 0x060003AA RVA 0x5D9A0; processed 0x060003A9 RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:38626; processed IL recovery, not original runtime.
internal static bool _00879()
		{

			return true;
		}

		// R8 MethodDef: original 0x060003AB RVA 0x5D9AC; processed 0x060003AA RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:38631; processed IL recovery, not original runtime.
internal static bool _0087a()
		{

			return false;
		}
	}
}
