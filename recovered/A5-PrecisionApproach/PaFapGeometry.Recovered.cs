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
	public class PaFapGeometry
	{
		public OasModel _0088_0095_0098;

		public TemplatePoint _0088_0095_0099;

		public TemplatePoint _0088_0095_009A;

		public TemplatePoint _0088_0095_009B;

		public TemplatePoint _0088_0095_009C;

		public TemplatePoint _0088_0095_009D;

		public TemplatePoint _0088_0095_009E;

		public TemplatePoint _0088_0096_0086;

		public PlaneCarrier _0088_0096_0087;

		public TemplatePoint _0088_0096_0088;

		public TemplatePoint _0088_0096_0089;

		public Dictionary<string, string> _0088_0096_008A;

		public List<List<TemplatePoint>> _0088_0096_008B;

		// R8 MethodDef: original 0x06000444 RVA 0x699B8; processed 0x06000443 RVA 0x56848; source 03_recovered-src/annotated-strings/--/--.cs:44929; processed IL recovery, not original runtime.
public PaFapGeometry(OasModel P_0, TemplatePoint P_1, TemplatePoint P_2)
		{

			_0088_0089();
			if (!_0088_008A())
			{
				if (false /* original-file-bool-offset:844 */)
				{
					return;
				}
				_0088_0096_008B = new List<List<TemplatePoint>>();
				// implicit object constructor
				_0088_0095_0098 = P_0;
				_0088_0096_0088 = P_1;
				_0088_0096_0089 = P_2;
				_0088_0095_009D = _0088_0095_0098._0088_0091_0094._008B_0088_0093(_0088_0095_0098._0088_0091_0098._008B_008B_008E(_0088_0096_0089.Z - 150.0));
				_0088_0095_009D.Z = _0088_0096_0089.Z - 150.0;
				_0088_0095_009B = new TemplatePoint(_0088_0096_0089.X, _0088_0095_0098._0088_0091_0094._008B_0088_008D(_0088_0096_0089.X), _0088_0096_0089.Z - 150.0);
				_0088_0095_009C = new TemplatePoint(_0088_0095_009B.X, _0088_0095_009B.Y, _0088_0096_0089.Z);
				if (!_0088_0089())
				{
					return;
				}
				_0088_0095_009E = _0088_0095_0098._0088_0091_0096._008B_008B_008E(_0088_0096_0089.Z - 150.0)._008B_0088_0093(_0088_0095_0098._0088_0091_0098._008B_008B_008E(_0088_0096_0089.Z - 150.0));
				if (_0088_0095_009E.X > _0088_0096_0088.X)
				{
					_0088_0095_009E.X = _0088_0096_0088.X;
					_0088_0095_009E.Y = _0088_0095_0098._0088_0091_0098._008B_008B_008E(_0088_0096_0089.Z - 150.0)._008B_0088_008D(_0088_0096_0088.X);
				}
				else
				{
					_0088_0095_009E.Z = _0088_0096_0089.Z - 150.0;
					if (!_0088_008A())
					{
						_0088_0096_0086 = _0088_0095_009E;
						goto IL_02c2;
					}
				}
			}
			_0088_0095_009E.Z = _0088_0096_0089.Z - 150.0;
			_0088_0096_0086 = new TemplatePoint();
			_0088_0096_0086.X = _0088_0096_0088.X;
			_0088_0096_0086.Y = _0088_0095_0098._0088_0091_0096._008B_008B_008D(_0088_0095_0098._0088_0091_0098)._008B_0088_008D(_0088_0096_0088.X);
			_0088_0096_0086.Z = _0088_0095_0098._0088_0091_0096._008B_008B_008A(_0088_0096_0086.X, _0088_0096_0086.Y);
			goto IL_02c2;
			IL_02c2:
			_0088_0095_0099 = new TemplatePoint(_0088_0096_0088.X, 4630.0, _0088_0096_0088.Z - 150.0);
			_0088_0095_009A = new TemplatePoint(_0088_0096_0088.X, 9260.0, _0088_0096_0088.Z);
			_0088_0095_0091();
		}

		// R8 MethodDef: original 0x06000445 RVA 0x69E24; processed 0x06000444 RVA 0x56B7C; source 03_recovered-src\annotated-strings\--\--.cs:44979; processed IL recovery, not original runtime.
public void _0088_0095_0091()
		{
			int num = default(int); // IL InitLocals

			num = 2;
			while (true)
			{
				_0088_0096_008A = new Dictionary<string, string>();
				_0088_008A();
				if (!_0088_0089())
				{
					goto IL_00a2;
				}
				num = 3;
				goto IL_0053;
				IL_010e:
				_0088_0096_008B.Add(_0088_0095_0098._0088_0090_009D());
				num = 9;
				break;
				IL_0053:
				_0088_0095_0092();
				_0088_0095_0093();
				goto IL_003c;
				IL_003c:
				_0088_0095_0094();
				_0088_0095_0097();
				num = 10;
				goto IL_0026;
				IL_0026:
				_0088_0095_0095();
				num = 4;
				if (!_0088_0089())
				{
					goto IL_003c;
				}
				goto IL_0061;
				IL_0061:
				switch (num)
				{
				case 2:
					break;
				case 10:
					goto IL_0026;
				case 7:
					goto IL_003c;
				case 1:
				case 3:
					goto IL_0053;
				case 4:
					_0088_0095_0096();
					goto IL_00a2;
				default:
					goto IL_00a2;
				case 8:
					goto IL_00ef;
				case 0:
					goto IL_010e;
				case 9:
					goto end_IL_0009;
				case 11:
					return;
				}
				continue;
				IL_00a2:
				_0088_0096_008B.Add(_0088_0095_0098._0088_0091_0087());
				_0088_0096_008B.Add(_0088_0095_0098._0088_0090_009E());
				num = 8;
				if (_0088_0089())
				{
					goto IL_0061;
				}
				goto IL_00ef;
				IL_00ef:
				_0088_0096_008B.Add(_0088_0095_0098._0088_0090_009C());
				num = 0;
				goto IL_010e;
				continue;
				end_IL_0009:
				break;
			}
			_0088_0096_008B.Add(_0088_0095_0098._0088_0091_0086());
			num = 11;
		}

		// R8 MethodDef: original 0x06000446 RVA 0x69FC8; processed 0x06000445 RVA 0x56CE0; source 03_recovered-src\annotated-strings\--\--.cs:45061; processed IL recovery, not original runtime.
private void _0088_0095_0092()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (false /* original-file-bool-offset:848 */)
			{
				return;
			}
			list = new List<TemplatePoint>();
			_0088_008A();
			if (_0088_0089())
			{
				list.Add(_0088_0095_009E);
				list.Add(_0088_0095_009D);
				list.Add(_0088_0095_009B);
				if (!_0088_008A())
				{
					list.Add(_0088_0095_0099);
					if (_0088_0095_009E.Y == _0088_0096_0086.Y)
					{
						goto IL_00ae;
					}
					list.Add(_0088_0095_009E);
					list.Add(_0088_0096_0086);
					list.Add(TemplatePoint._008B_0089_008B(_0088_0096_0086));
				}
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009E));
				goto IL_00ae;
			}
			goto IL_00f5;
			IL_00ae:
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0099));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009B));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009D));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009E));
			goto IL_00f5;
			IL_00f5:
			_0088_0096_008B.Add(list);
		}

		// R8 MethodDef: original 0x06000447 RVA 0x6A1BC; processed 0x06000446 RVA 0x56DF0; source 03_recovered-src\annotated-strings\--\--.cs:45099; processed IL recovery, not original runtime.
private void _0088_0095_0093()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			/* opaque discard 0 */
			if (_0088_0089())
			{
				list.Add(_0088_0095_0099);
				list.Add(_0088_0095_009B);
				list.Add(_0088_0095_009D);
			}
			list.Add(_0088_0095_009C);
			list.Add(_0088_0095_009A);
			list.Add(_0088_0095_0099);
			_0088_0096_008B.Add(list);
			list = new List<TemplatePoint>();
			list.Add(_0088_0095_009B);
			list.Add(_0088_0095_009C);
			list.Add(_0088_0095_009D);
			list.Add(_0088_0095_009B);
		}

		// R8 MethodDef: original 0x06000448 RVA 0x6A334; processed 0x06000447 RVA 0x56E9C; source 03_recovered-src\annotated-strings\--\--.cs:45120; processed IL recovery, not original runtime.
private void _0088_0095_0094()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (false /* original-file-bool-offset:852 */)
			{
				return;
			}
			list = new List<TemplatePoint>();
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0099));
			if (_0088_008A())
			{
				return;
			}
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009B));
			if (_0088_0089())
			{
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009D));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009C));
				/* opaque discard 1 */
				if (!_0088_008A())
				{
					list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009A));
					list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0099));
					_0088_0096_008B.Add(list);
					list = new List<TemplatePoint>();
					list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009B));
					list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009C));
				}
			}
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009D));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009B));
		}

		// R8 MethodDef: original 0x06000449 RVA 0x6A518; processed 0x06000448 RVA 0x56F9C; source 03_recovered-src\annotated-strings\--\--.cs:45152; processed IL recovery, not original runtime.
private void _0088_0095_0095()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			/* opaque discard 1 */
			// IL local hoisted
			if (!_0088_008A())
			{
				list = new List<TemplatePoint>();
				list.Add(_0088_0095_009D);
				if (_0088_0095_009D.Y != _0088_0095_009E.Y)
				{
					list.Add(_0088_0095_009E);
				}
				list.Add(_0088_0096_0086);
				list.Add(_0088_0095_0098._0088_0091_0089);
			}
			list.Add(_0088_0095_0098._0088_0091_008D);
			list.Add(_0088_0095_009D);
			_0088_0096_008B.Add(list);
		}

		// R8 MethodDef: original 0x0600044A RVA 0x6A664; processed 0x06000449 RVA 0x57034; source 03_recovered-src\annotated-strings\--\--.cs:45172; processed IL recovery, not original runtime.
private void _0088_0095_0096()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009D));
			while (true)
			{
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009E));
				/* opaque discard 1 */
				if (_0088_008A())
				{
					break;
				}
				if (_0088_0095_009D.Y != _0088_0095_009E.Y)
				{
					list.Add(TemplatePoint._008B_0089_008B(_0088_0096_0086));
				}
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0098._0088_0091_0089));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0098._0088_0091_008D));
				if (_0088_0089())
				{
					list.Add(TemplatePoint._008B_0089_008B(_0088_0095_009D));
					break;
				}
			}
			_0088_0096_008B.Add(list);
		}

		// R8 MethodDef: original 0x0600044B RVA 0x6A7EC; processed 0x0600044A RVA 0x570F0; source 03_recovered-src\annotated-strings\--\--.cs:45199; processed IL recovery, not original runtime.
private void _0088_0095_0097()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			item = PointLists._008B_008A_0092(_0088_0096_0086, _0088_0095_0098._0088_0091_0089);
			_0088_0096_008B.Add(item);
		}

		// R8 MethodDef: original 0x0600044C RVA 0x6A824; processed 0x0600044B RVA 0x4960; source 03_recovered-src/annotated-strings/--/--.cs:45205; processed IL recovery, not original runtime.
static PaFapGeometry()
		{

			// original licensing excluded; independent source only
		}

		// R8 MethodDef: original 0x0600044D RVA 0x6A840; processed 0x0600044C RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:45210; processed IL recovery, not original runtime.
internal static bool _0088_0089()
		{

			return true;
		}

		// R8 MethodDef: original 0x0600044E RVA 0x6A84C; processed 0x0600044D RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:45215; processed IL recovery, not original runtime.
internal static bool _0088_008A()
		{

			return false;
		}
	}
}
