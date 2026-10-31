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
	public class PaFafGeometry
	{
		public OasModel _0088_0094_009C;

		public TemplatePoint _0088_0094_009D;

		public TemplatePoint _0088_0094_009E;

		public TemplatePoint _0088_0095_0086;

		public TemplatePoint _0088_0095_0087;

		public TemplatePoint _0088_0095_0088;

		public TemplatePoint _0088_0095_0089;

		public TemplatePoint _0088_0095_008A;

		public PlaneCarrier _0088_0095_008B;

		public TemplatePoint _0088_0095_008C;

		public TemplatePoint _0088_0095_008D;

		private double _0088_0095_008E;

		public Dictionary<string, string> _0088_0095_008F;

		public List<List<TemplatePoint>> _0088_0095_0090;

		// R8 MethodDef: original 0x06000438 RVA 0x68AF8; processed 0x06000437 RVA 0x55DA8; source 03_recovered-src/annotated-strings/--/--.cs:44470; processed IL recovery, not original runtime.
public PaFafGeometry(OasModel P_0, TemplatePoint P_1, TemplatePoint P_2, double P_3)
		{
			int num = default(int); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals

			num = 0;
			// IL local hoisted
			while (true)
			{
				if (!false /* original-file-bool-offset:836 */)
				{
					_0088_0095_0090 = new List<List<TemplatePoint>>();
					while (true)
					{
						// implicit object constructor
						_0088_0087();
						if (_0088_0088())
						{
							num = 1;
							if (!_0088_0088())
							{
								goto IL_00f6;
							}
						}
						else
						{
							num = 7;
						}
						goto IL_0377;
						IL_0149:
						_0088_0095_008B._008B_008B_008F(_0088_0095_0089, TemplatePoint._008B_0089_008B(_0088_0095_0089), obj);
						num = 13;
						if (_0088_0087())
						{
							goto IL_00f6;
						}
						goto IL_02f1;
						IL_00f6:
						while (true)
						{
							switch (num)
							{
							case 15:
								break;
							case 13:
								_0088_0095_008A = _0088_0094_009C._0088_0091_0092._008B_0088_0093(_0088_0095_008B._008B_008B_008D(_0088_0094_009C._0088_0091_0096));
								goto case 1;
							case 1:
							case 12:
								_0088_0095_008A.Z = _0088_0094_009C._0088_0091_0098._008B_008B_008A(_0088_0095_008A.X, _0088_0095_008A.Y);
								Console.WriteLine("FAFdesEarly x{0}   y{1}  z{2}" , _0088_0095_0089.X, _0088_0095_0089.Y, _0088_0095_0089.Z);
								num = 9;
								if (!_0088_0088())
								{
									continue;
								}
								return;
							case 14:
								goto IL_0149;
							case 16:
								goto IL_017e;
							default:
								num = 4;
								goto IL_01b4;
							case 4:
								goto IL_01b4;
							case 10:
								goto IL_0207;
							case 5:
								goto IL_027a;
							case 8:
								goto IL_02f1;
							case 6:
								goto IL_031f;
							case 3:
							case 7:
								goto IL_0377;
							case 0:
								goto end_IL_0019;
							case 9:
								Console.WriteLine("FAFdesLatest x{0}   y{1}  z{2}" , _0088_0095_008A.X, _0088_0095_008A.Y, _0088_0095_008A.Z);
								_0088_0094_009D = new TemplatePoint(_0088_0095_008C.X, 4630.0, _0088_0095_008C.Z - 150.0);
								_0088_0094_009E = new TemplatePoint(_0088_0095_008C.X, 9260.0, _0088_0095_008C.Z);
								goto case 2;
							case 2:
								_0088_0094_0094();
								return;
							case 11:
							case 17:
								return;
							}
							break;
						}
						continue;
						IL_0377:
						_0088_0094_009C = P_0;
						_0088_0095_008C = P_1;
						num = 6;
						goto IL_031f;
						IL_031f:
						_0088_0095_008D = P_2;
						_0088_0095_008E = P_3;
						_0088_0095_0088 = _0088_0094_009C._0088_0091_0094._008B_0088_0093(_0088_0094_009C._0088_0091_0098._008B_008B_008E(_0088_0095_008D.Z - 150.0));
						num = 8;
						goto IL_02f1;
						IL_02f1:
						_0088_0095_0088.Z = _0088_0095_008D.Z - 150.0;
						num = 5;
						goto IL_027a;
						IL_027a:
						_0088_0095_0086 = new TemplatePoint(_0088_0095_008D.X, _0088_0094_009C._0088_0091_0094._008B_0088_008D(_0088_0095_008D.X), _0088_0095_008D.Z - 150.0);
						_0088_0095_0087 = new TemplatePoint(_0088_0095_0086.X, _0088_0095_0086.Y, _0088_0095_008D.Z);
						goto IL_0207;
						IL_0207:
						_0088_0095_0089 = new TemplatePoint(_0088_0095_008D.X + _0088_0095_008E, _0088_0094_009C._0088_0091_0098._008B_008B_008E(_0088_0095_008D.Z - 150.0)._008B_0088_008D(_0088_0095_008D.X + _0088_0095_008E), _0088_0095_008D.Z - 150.0);
						goto IL_01b4;
						IL_01b4:
						obj = new TemplatePoint(_0088_0095_0089.X - 1000.0, _0088_0095_0089.Y, _0088_0095_0089.Z - 150.0);
						num = 16;
						if (_0088_0088())
						{
							return;
						}
						goto IL_017e;
						IL_017e:
						_0088_0095_008B = new PlaneCarrier();
						goto IL_0149;
						continue;
						end_IL_0019:
						break;
					}
					continue;
				}
				num = 11;
				break;
			}
		}

		// R8 MethodDef: original 0x06000439 RVA 0x68FA8; processed 0x06000438 RVA 0x56214; source 03_recovered-src\annotated-strings\--\--.cs:44605; processed IL recovery, not original runtime.
public void _0088_0094_0094()
		{
			int num = default(int); // IL InitLocals

			num = 9;
			while (true)
			{
				_0088_0095_008F = new Dictionary<string, string>();
				_0088_0087();
				if (_0088_0088())
				{
					num = 3;
					goto IL_0146;
				}
				num = 2;
				goto IL_0032;
				IL_008a:
				_0088_0095_0090.Add(_0088_0094_009C._0088_0090_009D());
				num = 4;
				if (!_0088_0087())
				{
					break;
				}
				goto IL_004b;
				IL_004b:
				switch (num)
				{
				case 9:
					continue;
				case 1:
				case 2:
					goto IL_0032;
				case 10:
					goto IL_008a;
				case 11:
					goto IL_00b5;
				case 7:
					goto IL_00df;
				case 8:
					goto IL_0116;
				case 6:
					goto IL_0125;
				case 0:
					goto IL_013a;
				case 3:
				case 5:
					goto IL_0146;
				case 4:
					goto end_IL_0009;
				case 12:
					return;
				}
				num = 7;
				goto IL_00df;
				IL_0032:
				_0088_0094_0095();
				num = 8;
				if (_0088_0087())
				{
					goto IL_004b;
				}
				goto IL_0116;
				IL_0116:
				_0088_0094_0096();
				num = 6;
				goto IL_0125;
				IL_0125:
				_0088_0094_0097();
				_0088_0094_009A();
				num = 0;
				goto IL_013a;
				IL_013a:
				_0088_0094_0098();
				_0088_0094_0099();
				goto IL_0146;
				IL_0146:
				_0088_0094_009B();
				goto IL_00df;
				IL_00df:
				_0088_0095_0090.Add(_0088_0094_009C._0088_0091_0087());
				_0088_0095_0090.Add(_0088_0094_009C._0088_0090_009E());
				num = 11;
				goto IL_00b5;
				IL_00b5:
				_0088_0095_0090.Add(_0088_0094_009C._0088_0090_009C());
				num = 10;
				goto IL_008a;
				continue;
				end_IL_0009:
				break;
			}
			_0088_0095_0090.Add(_0088_0094_009C._0088_0091_0086());
			num = 12;
		}

		// R8 MethodDef: original 0x0600043A RVA 0x69160; processed 0x06000439 RVA 0x563A8; source 03_recovered-src\annotated-strings\--\--.cs:44698; processed IL recovery, not original runtime.
private void _0088_0094_0095()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			/* opaque discard 0 */
			if (_0088_0087())
			{
				list.Add(_0088_0094_009D);
				list.Add(_0088_0095_0086);
			}
			list.Add(_0088_0095_0088);
			list.Add(_0088_0095_0089);
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0089));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0088));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0086));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0094_009D));
			list.Add(_0088_0094_009D);
			_0088_0095_0090.Add(list);
		}

		// R8 MethodDef: original 0x0600043B RVA 0x692E4; processed 0x0600043A RVA 0x56454; source 03_recovered-src\annotated-strings\--\--.cs:44717; processed IL recovery, not original runtime.
private void _0088_0094_0096()
		{
			int num = default(int); // IL InitLocals
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			_0088_0087();
			if (!_0088_0088())
			{
				goto IL_0028;
			}
			num = 8;
			if (!_0088_0087())
			{
				goto IL_00bb;
			}
			goto IL_0144;
			IL_0083:
			// IL local hoisted
			do
			{
				list.Add(_0088_0095_0087);
				list.Add(_0088_0094_009E);
				num = 7;
			}
			while (_0088_0088());
			goto IL_0041;
			IL_0028:
			list = new List<TemplatePoint>();
			num = 10;
			if (_0088_0087())
			{
				goto IL_0041;
			}
			goto IL_0138;
			IL_0041:
			switch (num)
			{
			case 0:
			case 11:
				break;
			case 1:
				goto IL_0083;
			case 6:
				goto IL_00ad;
			case 10:
				goto IL_00bb;
			case 9:
				goto IL_00de;
			case 3:
				goto IL_00ff;
			case 4:
				goto IL_0122;
			default:
				goto IL_0130;
			case 7:
				goto IL_0138;
			case 5:
			case 8:
				goto IL_0144;
			case 12:
				return;
			}
			goto IL_0028;
			IL_0138:
			list.Add(_0088_0094_009D);
			goto IL_0144;
			IL_0144:
			_0088_0095_0090.Add(list);
			goto IL_0130;
			IL_0130:
			list = new List<TemplatePoint>();
			goto IL_0122;
			IL_0122:
			list.Add(_0088_0095_0086);
			goto IL_00ff;
			IL_00ff:
			list.Add(_0088_0095_0087);
			list.Add(_0088_0095_0088);
			num = 9;
			goto IL_00de;
			IL_00de:
			list.Add(_0088_0095_0086);
			num = 12;
			if (!_0088_0088())
			{
				goto IL_0041;
			}
			goto IL_00bb;
			IL_00bb:
			list.Add(_0088_0094_009D);
			list.Add(_0088_0095_0086);
			num = 6;
			goto IL_00ad;
			IL_00ad:
			list.Add(_0088_0095_0088);
			goto IL_0083;
		}

		// R8 MethodDef: original 0x0600043C RVA 0x69490; processed 0x0600043B RVA 0x565B4; source 03_recovered-src\annotated-strings\--\--.cs:44812; processed IL recovery, not original runtime.
private void _0088_0094_0097()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (true /* original-file-bool-offset:840 */)
			{
				list = new List<TemplatePoint>();
				list.Add(TemplatePoint._008B_0089_008B(_0088_0094_009D));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0086));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0088));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0087));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0094_009E));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0094_009D));
				_0088_0095_0090.Add(list);
				list = new List<TemplatePoint>();
				_0088_0087();
				if (!_0088_0088())
				{
					list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0086));
					list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0087));
					list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0088));
				}
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0086));
			}
		}

		// R8 MethodDef: original 0x0600043D RVA 0x69660; processed 0x0600043C RVA 0x566A4; source 03_recovered-src\annotated-strings\--\--.cs:44836; processed IL recovery, not original runtime.
private void _0088_0094_0098()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			list.Add(_0088_0095_0088);
			list.Add(_0088_0095_0089);
			_0088_0088();
			if (_0088_0087())
			{
				list.Add(_0088_0095_008A);
				list.Add(_0088_0094_009C._0088_0091_0089);
				list.Add(_0088_0094_009C._0088_0091_008D);
				list.Add(_0088_0094_009C._0088_0091_008E);
				list.Add(_0088_0095_0088);
			}
			_0088_0095_0090.Add(list);
		}

		// R8 MethodDef: original 0x0600043E RVA 0x697AC; processed 0x0600043D RVA 0x56738; source 03_recovered-src\annotated-strings\--\--.cs:44853; processed IL recovery, not original runtime.
private void _0088_0094_0099()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0088));
			/* opaque discard 1 */
			if (!_0088_0088())
			{
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0089));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0095_008A));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0094_009C._0088_0091_0089));
				list.Add(TemplatePoint._008B_0089_008B(_0088_0094_009C._0088_0091_008D));
			}
			list.Add(TemplatePoint._008B_0089_008B(_0088_0094_009C._0088_0091_008E));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0095_0088));
			_0088_0095_0090.Add(list);
		}

		// R8 MethodDef: original 0x0600043F RVA 0x69918; processed 0x0600043E RVA 0x567EC; source 03_recovered-src\annotated-strings\--\--.cs:44870; processed IL recovery, not original runtime.
private void _0088_0094_009A()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			item = PointLists._008B_008A_0092(_0088_0095_008A, _0088_0094_009C._0088_0091_0089);
			_0088_0095_0090.Add(item);
		}

		// R8 MethodDef: original 0x06000440 RVA 0x69950; processed 0x0600043F RVA 0x5681C; source 03_recovered-src\annotated-strings\--\--.cs:44876; processed IL recovery, not original runtime.
private void _0088_0094_009B()
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			item = PointLists._008B_008A_0092(_0088_0095_008A, _0088_0095_0089);
			_0088_0095_0090.Add(item);
		}

		// R8 MethodDef: original 0x06000441 RVA 0x69984; processed 0x06000440 RVA 0x494E; source 03_recovered-src/annotated-strings/--/--.cs:44882; processed IL recovery, not original runtime.
static PaFafGeometry()
		{

			// original licensing excluded; independent source only
		}

		// R8 MethodDef: original 0x06000442 RVA 0x699A0; processed 0x06000441 RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:44887; processed IL recovery, not original runtime.
internal static bool _0088_0087()
		{

			return true;
		}

		// R8 MethodDef: original 0x06000443 RVA 0x699AC; processed 0x06000442 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:44892; processed IL recovery, not original runtime.
internal static bool _0088_0088()
		{

			return false;
		}
	}
}
