using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
// E1/E2 recovery. No target DLL or AutoCAD runtime. Original branches retained.
namespace Recovered.B4 {
	public class OasModel
	{
		public TemplatePoint _0088_0091_0089;

		public TemplatePoint _0088_0091_008A;

		public TemplatePoint _0088_0091_008B;

		public TemplatePoint _0088_0091_008C;

		public TemplatePoint _0088_0091_008D;

		public TemplatePoint _0088_0091_008E;

		public TemplatePoint _0088_0091_008F;

		public TemplatePoint _0088_0091_0090;

		public TemplatePoint _0088_0091_0091;

		public LineCarrier _0088_0091_0092;

		public LineCarrier _0088_0091_0093;

		public LineCarrier _0088_0091_0094;

		public LineCarrier _0088_0091_0095;

		public PlaneCarrier _0088_0091_0096;

		public PlaneCarrier _0088_0091_0097;

		public PlaneCarrier _0088_0091_0098;

		public PlaneCarrier _0088_0091_0099;

		public PlaneCarrier _0088_0091_009A;

		public OasMode _0088_0091_009B;

		public int _0088_0091_009C;

		public List<List<TemplatePoint>> _0088_0091_009D;

// R7 MethodDef: original 0x06000412 RVA 0x645A4; processed 0x06000411 RVA 0x52294; source 03_recovered-src/annotated-strings/--/--.cs:42044; processed IL recovery, not original runtime.
public OasModel(OasMode P_0)
		{

			_0087w();
			if (_0087v())
			{
				if (!true /* original-file-bool-offset:780 */)
				{
					return;
				}
				_0088_0091_009C = 300;
				// implicit object constructor
				while (true)
				{
					_0088_0091_009B = P_0;
					if (_0088_0091_009B == (OasMode)0)
					{
						if (_0087v())
						{
							_0088_0091_009C = 300;
							break;
						}
						continue;
					}
					_0088_0091_009C = 150;
					break;
				}
				_0088_0091_0096 = new PlaneCarrier();
				_0088_0091_0097 = new PlaneCarrier();
				_0088_0091_0098 = new PlaneCarrier();
				_0088_0091_0099 = new PlaneCarrier();
			}
			_0088_0091_009A = new PlaneCarrier();
		}

// R7 MethodDef: original 0x06000413 RVA 0x647B4; processed 0x06000412 RVA 0x523E0; source 03_recovered-src\annotated-strings\--\--.cs:42078; processed IL recovery, not original runtime.
public void _0088_0090_0098(double P_0 = 0.0)
		{
			int num = default(int); // IL InitLocals

			num = 14;
			while (true /* original-file-bool-offset:784 */)
			{
				/* opaque discard 1 */
				if (!_0087w())
				{
					goto IL_0177;
				}
				num = 15;
				goto IL_0391;
				IL_02e8:
				_0088_0091_008A = _0088_0091_0093._008B_0088_0093(_0088_0091_0092);
				_0088_0091_008B = _0088_0091_0097._008B_008B_008E(_0088_0091_009C)._008B_0088_0093(_0088_0091_0098._008B_008B_008E(_0088_0091_009C));
				num = 0;
				goto IL_0337;
				IL_0337:
				_0088_0091_008A.Z = _0088_0091_0097._008B_008B_008A(_0088_0091_008A.X, _0088_0091_008A.Y);
				goto IL_0391;
				IL_0391:
				_0088_0091_008E = _0088_0091_0094._008B_0088_0093(_0088_0091_0098._008B_008B_008E(_0088_0091_009C));
				_0088_0091_0091 = _0088_0091_0095._008B_0088_0093(_0088_0091_0099._008B_008B_008E(_0088_0091_009C));
				num = 2;
				if (_0087v())
				{
					goto IL_00a8;
				}
				goto IL_0295;
				IL_0295:
				_0088_0091_009D.Add(PointLists._008B_008A_0092(_0088_0091_0090, _0088_0091_0091));
				num = 13;
				goto IL_027a;
				IL_027a:
				_0088_0091_009D.Add(_0088_0091_0087());
				if (_0088_0091_009B == (OasMode)0)
				{
					num = 16;
					goto IL_024f;
				}
				goto IL_025e;
				IL_0451:
				_0088_0091_009D.Add(_0088_0090_009A());
				_0088_0091_009D.Add(_0088_0090_009B());
				break;
				IL_025e:
				if (_0088_0091_009B == (OasMode)2)
				{
					num = 9;
					goto IL_0116;
				}
				_0088_0091_009D.Add(PointLists._008B_008A_0092(_0088_0091_0089, _0088_0091_008B));
				num = 18;
				goto IL_0451;
				IL_024f:
				if (P_0 <= 300.0)
				{
					goto IL_025e;
				}
				num = 22;
				goto IL_041b;
				IL_0116:
				_0088_0091_009D.Add(PointLists._008B_008A_0092(_0088_0091_008A, _0088_0091_008B));
				_0088_0091_009D.Add(PointLists._008B_008A_0092(_0088_0091_0089, _0088_0091_008A));
				_0088_0091_009D.Add(_0088_0090_009A());
				num = 17;
				if (!_0087w())
				{
					goto IL_00a8;
				}
				goto IL_024f;
				IL_00a8:
				while (true)
				{
					switch (num)
					{
					default:
						_0088_0091_0091.Z = _0088_0091_009C;
						goto case 3;
					case 3:
						_0088_0091_009D.Add(_0088_0090_009C());
						_0088_0091_009D.Add(_0088_0090_009D());
						num = 5;
						if (!_0087w())
						{
							continue;
						}
						goto IL_0391;
					case 2:
						_0088_0091_008B.Z = _0088_0091_009C;
						_0088_0091_008E.Z = _0088_0091_009C;
						goto default;
					case 9:
						break;
					case 1:
					case 20:
						goto IL_0177;
					case 12:
						goto IL_018b;
					case 21:
						goto IL_01b9;
					case 10:
						goto IL_01f5;
					case 16:
						goto IL_024f;
					case 13:
						goto IL_027a;
					case 5:
						goto IL_0295;
					case 11:
						goto IL_02bc;
					case 19:
						goto IL_02e8;
					case 0:
						goto IL_0337;
					case 4:
					case 8:
					case 15:
						goto IL_0391;
					case 14:
						goto IL_03ef;
					case 17:
						_0088_0091_009D.Add(_0088_0090_009B());
						return;
					case 22:
						goto IL_041b;
					case 6:
						return;
					case 18:
						goto IL_0451;
					case 23:
						return;
					}
					break;
				}
				goto IL_0116;
				IL_0177:
				_0088_0091_009D = new List<List<TemplatePoint>>();
				num = 12;
				goto IL_018b;
				IL_018b:
				_0088_0091_0092 = _0088_0091_0096._008B_008B_008D(_0088_0091_0098);
				_0088_0091_0094 = _0088_0091_0098._008B_008B_008D(_0088_0091_0099);
				goto IL_01b9;
				IL_01b9:
				_0088_0091_0095 = _0088_0091_0099._008B_008B_008D(_0088_0091_009A);
				_0088_0091_0089 = _0088_0091_0092._008B_0088_0093(_0088_0091_0096._008B_008B_008E(0.0));
				goto IL_01f5;
				IL_01f5:
				_0088_0091_008D = _0088_0091_0094._008B_0088_0093(_0088_0091_0098._008B_008B_008E(0.0));
				_0088_0091_0090 = _0088_0091_0095._008B_0088_0093(_0088_0091_0099._008B_008B_008E(0.0));
				num = 11;
				if (!_0087v())
				{
					goto IL_024f;
				}
				goto IL_02bc;
				IL_02bc:
				if (_0088_0091_009B == (OasMode)2)
				{
					_0088_0091_0093 = _0088_0091_0097._008B_008B_008D(_0088_0091_0096);
					num = 19;
					goto IL_02e8;
				}
				_0088_0091_008B = _0088_0091_0092._008B_0088_0093(_0088_0091_0096._008B_008B_008E(_0088_0091_009C));
				num = 4;
				goto IL_0391;
				IL_041b:
				_0088_0090_0099(P_0);
				num = 6;
				break;
				IL_03ef:;
			}
		}

// R7 MethodDef: original 0x06000414 RVA 0x64C98; processed 0x06000413 RVA 0x52860; source 03_recovered-src\annotated-strings\--\--.cs:42253; processed IL recovery, not original runtime.
public void _0088_0090_0099(double P_0 = 0.0)
		{
			int num = default(int); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			num = 9;
			// IL local hoisted
			while (!false /* original-file-bool-offset:788 */)
			{
				_0088_0091_008C = _0088_0091_0092._008B_0088_0093(_0088_0091_0096._008B_008B_008E(P_0));
				num = 3;
				while (true)
				{
					_0088_0091_008F = _0088_0091_0094._008B_0088_0093(_0088_0091_0098._008B_008B_008E(P_0));
					_0088_0091_008C.Z = P_0;
					num = 11;
					while (true)
					{
						_0088_0091_008F.Z = P_0;
						item = new List<TemplatePoint> { _0088_0091_008F, _0088_0091_008D, _0088_0091_0089, _0088_0091_008C, _0088_0091_008F };
						num = 10;
						while (true)
						{
							IL_0180:
							_0088_0091_009D.Add(item);
							item = new List<TemplatePoint>
							{
								TemplatePoint._008B_0089_008B(_0088_0091_008F),
								TemplatePoint._008B_0089_008B(_0088_0091_008D),
								TemplatePoint._008B_0089_008B(_0088_0091_0089),
								TemplatePoint._008B_0089_008B(_0088_0091_008C),
								TemplatePoint._008B_0089_008B(_0088_0091_008F)
							};
							_0088_0091_009D.Add(item);
							num = 4;
							if (_0087v())
							{
								goto IL_0073;
							}
							goto IL_0166;
							IL_0166:
							_0088_0091_009D.Add(item);
							num = 12;
							goto IL_00d7;
							IL_00d7:
							item = new List<TemplatePoint>
							{
								TemplatePoint._008B_0089_008B(_0088_0091_0091),
								TemplatePoint._008B_0089_008B(obj)
							};
							goto IL_00b6;
							IL_00b6:
							_0088_0091_009D.Add(item);
							num = 13;
							if (!_0087v())
							{
								continue;
							}
							goto IL_0073;
							IL_0073:
							while (true)
							{
								switch (num)
								{
								default:
									/* opaque discard 0 */
									if (_0087v())
									{
										num = 1;
										if (!_0087w())
										{
											continue;
										}
										goto case 4;
									}
									num = 0;
									goto case 0;
								case 4:
									_0088_0091_009D.Add(PointLists._008B_008A_0092(_0088_0091_0089, _0088_0091_008C));
									goto default;
								case 2:
									break;
								case 12:
									goto IL_00d7;
								case 1:
								case 6:
									obj = TemplatePoint._008B_0089_008E(_0088_0091_0091, -10000.0 * Math.Cos(-Math.PI / 12.0), -10000.0 * Math.Sin(-Math.PI / 12.0));
									goto case 0;
								case 0:
								case 7:
									item = new List<TemplatePoint> { _0088_0091_0091, obj };
									goto IL_0166;
								case 5:
									goto IL_0166;
								case 10:
									goto IL_0180;
								case 11:
									goto end_IL_0180;
								case 3:
									goto end_IL_020b;
								case 9:
									goto end_IL_0267;
								case 8:
								case 13:
									return;
								}
								break;
							}
							goto IL_00b6;
							continue;
							end_IL_0180:
							break;
						}
						continue;
						end_IL_020b:
						break;
					}
					continue;
					end_IL_0267:
					break;
				}
			}
			num = 8;
		}

// R7 MethodDef: original 0x06000415 RVA 0x64F9C; processed 0x06000414 RVA 0x52B24; source 03_recovered-src\annotated-strings\--\--.cs:42375; processed IL recovery, not original runtime.
public List<TemplatePoint> _0088_0090_009A()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			list.Add(_0088_0091_008E);
			list.Add(_0088_0091_008D);
			list.Add(_0088_0091_0089);
			if (_0088_0091_009B == (OasMode)2)
			{
				list.Add(_0088_0091_008A);
			}
			list.Add(_0088_0091_008B);
			list.Add(_0088_0091_008E);
			return list;
		}

// R7 MethodDef: original 0x06000416 RVA 0x6500C; processed 0x06000415 RVA 0x52B8C; source 03_recovered-src\annotated-strings\--\--.cs:42390; processed IL recovery, not original runtime.
public List<TemplatePoint> _0088_0090_009B()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			list.Add(TemplatePoint._008B_0089_008B(_0088_0091_008E));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0091_008D));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0091_0089));
			if (_0088_0091_009B == (OasMode)2)
			{
				list.Add(TemplatePoint._008B_0089_008B(_0088_0091_008A));
			}
			list.Add(TemplatePoint._008B_0089_008B(_0088_0091_008B));
			list.Add(TemplatePoint._008B_0089_008B(_0088_0091_008E));
			return list;
		}

// R7 MethodDef: original 0x06000417 RVA 0x6509C; processed 0x06000416 RVA 0x52C10; source 03_recovered-src\annotated-strings\--\--.cs:42405; processed IL recovery, not original runtime.
public List<TemplatePoint> _0088_0090_009C()
		{

			return new List<TemplatePoint> { _0088_0091_0090, _0088_0091_0091, _0088_0091_008E, _0088_0091_008D, _0088_0091_0090 };
		}

// R7 MethodDef: original 0x06000418 RVA 0x650F4; processed 0x06000417 RVA 0x52C60; source 03_recovered-src\annotated-strings\--\--.cs:42410; processed IL recovery, not original runtime.
public List<TemplatePoint> _0088_0090_009D()
		{

			return new List<TemplatePoint>
			{
				TemplatePoint._008B_0089_008B(_0088_0091_0090),
				TemplatePoint._008B_0089_008B(_0088_0091_0091),
				TemplatePoint._008B_0089_008B(_0088_0091_008E),
				TemplatePoint._008B_0089_008B(_0088_0091_008D),
				TemplatePoint._008B_0089_008B(_0088_0091_0090)
			};
		}

// R7 MethodDef: original 0x06000419 RVA 0x65164; processed 0x06000418 RVA 0x4905; source 03_recovered-src\annotated-strings\--\--.cs:42422; processed IL recovery, not original runtime.
public List<TemplatePoint> _0088_0090_009E()
		{

			return PointLists._008B_008A_0092(_0088_0091_0090, _0088_0091_0091);
		}

// R7 MethodDef: original 0x0600041A RVA 0x65180; processed 0x06000419 RVA 0x52CC8; source 03_recovered-src\annotated-strings\--\--.cs:42427; processed IL recovery, not original runtime.
public List<TemplatePoint> _0088_0091_0086(double P_0 = 10000.0)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals

			obj = TemplatePoint._008B_0089_008E(_0088_0091_0091, (0.0 - P_0) * Math.Cos(-Math.PI / 12.0), (0.0 - P_0) * Math.Sin(-Math.PI / 12.0));
			return new List<TemplatePoint>
			{
				obj,
				_0088_0091_0091,
				TemplatePoint._008B_0089_008B(_0088_0091_0091),
				TemplatePoint._008B_0089_008B(obj)
			};
		}

// R7 MethodDef: original 0x0600041B RVA 0x65200; processed 0x0600041A RVA 0x52D44; source 03_recovered-src\annotated-strings\--\--.cs:42439; processed IL recovery, not original runtime.
public List<TemplatePoint> _0088_0091_0087()
		{

			return new List<TemplatePoint>
			{
				new TemplatePoint(0.0, 0.0),
				new TemplatePoint(_0088_0091_0089.X, 0.0)
			};
		}

// R7 MethodDef: original 0x0600041C RVA 0x65268; processed 0x0600041B RVA 0x52DA4; source 03_recovered-src\annotated-strings\--\--.cs:42448; processed IL recovery, not original runtime.
public TemplatePoint _0088_0091_0088(TemplatePoint P_0)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			string text = default(string); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			LineCarrier obj2 = default(LineCarrier); // IL InitLocals
			double num8 = default(double); // IL InitLocals

			num = 9;
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				IL_03b3:
				if (!false /* original-file-bool-offset:792 */)
				{
					num2 = ((P_0.Y > 0.0) ? P_0.Y : (0.0 - P_0.Y));
					P_0.Name = "out" /* string-offset:1556 */;
					num = 6;
					goto IL_038f;
				}
				num = 2;
				goto IL_0291;
				IL_02f2:
				text = "W面" /* string-offset:5476 */;
				num3 = num4;
				num = 23;
				goto IL_0308;
				IL_02d4:
				text = "X面" /* string-offset:5480 */;
				num = 1;
				goto IL_02e8;
				IL_02b2:
				num3 = num5;
				num = 4;
				goto IL_02cd;
				IL_025c:
				_0087w();
				if (_0087v())
				{
					num = 16;
					goto IL_0275;
				}
				num = 12;
				break;
				IL_029e:
				text = "Y面" /* string-offset:5484 */;
				num = 17;
				goto IL_02b2;
				IL_038f:
				text = "入口平面" /* string-offset:5472 */;
				num = 7;
				goto IL_0367;
				IL_0367:
				num3 = 0.0;
				num4 = _0088_0091_0096._008B_008B_008A(P_0.X, num2);
				num = 24;
				goto IL_0320;
				IL_0320:
				num6 = _0088_0091_0098._008B_008B_008A(P_0.X, num2);
				num5 = _0088_0091_0099._008B_008B_008A(P_0.X, num2);
				num7 = _0088_0091_009A._008B_008B_008A(P_0.X, num2);
				num = 25;
				goto IL_031a;
				IL_031a:
				if (num3 < num4)
				{
					num = 3;
					goto IL_02f2;
				}
				goto IL_0308;
				IL_02e8:
				num3 = num6;
				goto IL_02eb;
				IL_0308:
				if (num3 < num6)
				{
					goto IL_02d4;
				}
				goto IL_02eb;
				IL_02eb:
				if (num3 < num5)
				{
					goto IL_029e;
				}
				goto IL_02cd;
				IL_02cd:
				if (num3 < num7)
				{
					text = "Z面" /* string-offset:5488 */;
					goto IL_025c;
				}
				goto IL_0291;
				IL_0275:
				num3 = num7;
				num = 14;
				goto IL_0291;
				IL_0291:
				while (true)
				{
					if (_0088_0091_009B != 0)
					{
						if (_0088_0091_009B == (OasMode)1)
						{
							num = 5;
							if (!_0087v())
							{
								break;
							}
							goto IL_01a9;
						}
						if (_0088_0091_009B != (OasMode)2)
						{
							goto end_IL_03b3;
						}
						goto IL_023d;
					}
					num = 10;
					goto IL_010e;
					IL_01a9:
					switch (num)
					{
					case 11:
						break;
					case 10:
						goto IL_010e;
					case 0:
						goto IL_018c;
					case 21:
						goto IL_0233;
					case 19:
						goto IL_023d;
					default:
						goto IL_025c;
					case 13:
					case 16:
						goto IL_0275;
					case 2:
					case 14:
						continue;
					case 20:
						goto end_IL_0291;
					case 17:
						goto IL_02b2;
					case 4:
						goto IL_02cd;
					case 8:
						goto IL_02d4;
					case 1:
						goto IL_02e8;
					case 3:
						goto IL_02f2;
					case 23:
						goto IL_0308;
					case 25:
						goto IL_031a;
					case 24:
						goto IL_0320;
					case 7:
						goto IL_0367;
					case 6:
						goto IL_038f;
					case 9:
						goto IL_03b3;
					case 5:
						P_0.Name = ((num3 > (double)_0088_0091_009C) ? "out" /* string-offset:1556 */ : text);
						P_0.Z = num3;
						goto end_IL_03b3;
					case 12:
					case 15:
					case 18:
					case 22:
					case 26:
						goto end_IL_03b3;
					}
					goto IL_00bb;
					IL_010e:
					if (P_0.X < _0088_0091_0091.X)
					{
						obj = TemplatePoint._008B_0089_008E(_0088_0091_0091, -10000.0 * Math.Cos(-Math.PI / 12.0), -10000.0 * Math.Sin(-Math.PI / 12.0));
						obj2 = new LineCarrier();
						goto IL_018c;
					}
					P_0.Name = (((text == "Y面" /* string-offset:5484 */ || text == "Z面" /* string-offset:5488 */) && num3 > (double)_0088_0091_009C) ? "out" /* string-offset:1556 */ : text);
					P_0.Z = num3;
					num = 22;
					goto end_IL_03b3;
					IL_00bb:
					if (num2 <= obj2._008B_0088_008D(P_0.X))
					{
						P_0.Name = "非精密延伸段" /* string-offset:5492 */;
						P_0.Z = _0088_0091_009A._008B_008B_008A(P_0.X, num2);
						num = 15;
						if (!_0087w())
						{
							goto IL_01a9;
						}
						goto IL_02e8;
					}
					P_0.Name = "out" /* string-offset:1556 */;
					goto end_IL_03b3;
					IL_018c:
					obj2._008B_0088_008E(_0088_0091_0091, obj);
					num = 11;
					goto IL_00bb;
					IL_023d:
					num8 = _0088_0091_0097._008B_008B_008A(P_0.X, num2);
					num = 21;
					goto IL_0233;
					IL_0233:
					if (num3 < num8)
					{
						text = "W*面" /* string-offset:5496 */;
						num3 = num8;
					}
					P_0.Name = ((num3 > (double)_0088_0091_009C) ? "out" /* string-offset:1556 */ : text);
					P_0.Z = num3;
					num = 26;
					if (_0087v())
					{
						goto IL_01a9;
					}
					goto IL_0320;
					continue;
					end_IL_0291:
					break;
				}
				goto IL_029e;
				continue;
				end_IL_03b3:
				break;
			}
			return P_0;
		}

// R7 MethodDef: original 0x0600041D RVA 0x65744; processed 0x0600041C RVA 0x4918; source 03_recovered-src/annotated-strings/--/--.cs:42685; processed IL recovery, not original runtime.
static OasModel()
		{

			// host licensing excluded from independent recovery
		}

// R7 MethodDef: original 0x0600041E RVA 0x65760; processed 0x0600041D RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:42690; processed IL recovery, not original runtime.
internal static bool _0087v()
		{

			return true;
		}

// R7 MethodDef: original 0x0600041F RVA 0x6576C; processed 0x0600041E RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:42695; processed IL recovery, not original runtime.
internal static bool _0087w()
		{

			return false;
		}
	}
}
