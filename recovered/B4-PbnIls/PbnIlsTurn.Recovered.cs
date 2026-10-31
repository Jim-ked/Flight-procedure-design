using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
// E1/E2 recovery. No target DLL or AutoCAD runtime. Original branches retained.
namespace Recovered.B4 {
	public class PbnIlsTurn
	{
		public TemplatePoint _008A_008A_0093;

		public TemplatePoint _008A_008A_0094;

		public TemplatePoint _008A_008A_0095;

		public TemplatePoint _008A_008A_0096;

		public TemplatePoint _008A_008A_0097;

		public TemplatePoint _008A_008A_0098;

		public LineCarrier _008A_008A_0099;

		public LineCarrier _008A_008A_009A;

		public PlaneCarrier _008A_008A_009B;

		public TemplatePoint _008A_008A_009C;

		public TemplatePoint _008A_008A_009D;

		public TemplatePoint _008A_008A_009E;

		public TemplatePoint _008A_008B_0086;

		public TemplatePoint _008A_008B_0087;

		public TemplatePoint _008A_008B_0088;

		public TemplatePoint _008A_008B_0089;

		public TemplatePoint _008A_008B_008A;

		public TemplatePoint _008A_008B_008B;

		public LineCarrier _008A_008B_008C;

		public LineCarrier _008A_008B_008D;

		public LineCarrier _008A_008B_008E;

		public LineCarrier _008A_008B_008F;

		public PlaneCarrier _008A_008B_0090;

		public PlaneCarrier _008A_008B_0091;

		public PlaneCarrier _008A_008B_0092;

		public PlaneCarrier _008A_008B_0093;

		public int _008A_008B_0094 = 300;

		public List<List<TemplatePoint>> _008A_008B_0095;

// R7 MethodDef: original 0x060005DE RVA 0xB2B34; processed 0x060005DD RVA 0x84410; source :; processed IL recovery, not original runtime.
public PbnIlsTurn()
		{

			if (_0088o())
			{
			}
			_008A_008B_0090 = new PlaneCarrier();
			_008A_008B_0091 = new PlaneCarrier();
			_0088o();
			if (_0088n())
			{
				_008A_008B_0092 = new PlaneCarrier();
			}
			_008A_008B_0093 = new PlaneCarrier();
		}

// R7 MethodDef: original 0x060005DF RVA 0xB2CB0; processed 0x060005DE RVA 0x844F4; source 03_recovered-src\annotated-strings\--\--.cs:71771; processed IL recovery, not original runtime.
public void _008A_008A_0088(double P_0 = 0.0, bool P_1 = true)
		{

			/* opaque discard 1 */
			if (!_0088o() && !false /* original-file-bool-offset:1240 */)
			{
				_008A_008B_0095 = new List<List<TemplatePoint>>();
				_008A_008B_008C = _008A_008B_0090._008B_008B_008D(_008A_008B_0091);
				if (!_0088o())
				{
					goto IL_008f;
				}
				goto IL_0205;
			}
			return;
			IL_008f:
			_008A_008B_008E = _008A_008B_0091._008B_008B_008D(_008A_008B_0092);
			_008A_008B_008F = _008A_008B_0092._008B_008B_008D(_008A_008B_0093);
			_008A_008A_009C = _008A_008B_008C._008B_0088_0093(_008A_008B_0090._008B_008B_008E(0.0));
			_008A_008B_0087 = _008A_008B_008E._008B_0088_0093(_008A_008B_0091._008B_008B_008E(0.0));
			_008A_008B_008A = _008A_008B_008F._008B_0088_0093(_008A_008B_0092._008B_008B_008E(0.0));
			_008A_008A_009E = _008A_008B_008C._008B_0088_0093(_008A_008B_0090._008B_008B_008E(_008A_008B_0094));
			_008A_008B_0088 = _008A_008B_008E._008B_0088_0093(_008A_008B_0091._008B_008B_008E(_008A_008B_0094));
			_008A_008B_008B = _008A_008B_008F._008B_0088_0093(_008A_008B_0092._008B_008B_008E(_008A_008B_0094));
			_008A_008A_009E.Z = _008A_008B_0094;
			_008A_008B_0088.Z = _008A_008B_0094;
			goto IL_0205;
			IL_0205:
			while (true)
			{
				_008A_008B_008B.Z = _008A_008B_0094;
				if (!P_1)
				{
					break;
				}
				_008A_008B_0095.Add(_008A_008A_008E());
				if (_0088n())
				{
					_008A_008B_0095.Add(_008A_008A_008F());
					_008A_008B_0095.Add(PointLists._008B_008A_0092(_008A_008B_008A, _008A_008B_008B));
					break;
				}
			}
			_008A_008B_0095.Add(_008A_008A_0092());
			if (P_0 <= 300.0)
			{
				_008A_008B_0095.Add(PointLists._008B_008A_0092(_008A_008A_009C, _008A_008A_009E));
				if (_0088n())
				{
					_008A_008B_0095.Add(_008A_008A_008C());
					_008A_008B_0095.Add(_008A_008A_008D());
					return;
				}
				goto IL_008f;
			}
			_008A_008A_008B(P_0);
		}

// R7 MethodDef: original 0x060005E0 RVA 0xB3034; processed 0x060005DF RVA 0x84750; source 03_recovered-src\annotated-strings\--\--.cs:71828; processed IL recovery, not original runtime.
public void _008A_008A_0089(double P_0)
		{
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals

			if (false /* original-file-bool-offset:1244 */)
			{
				return;
			}
			if (P_0 > _008A_008B_0088.X)
			{
				RecoveryMessages.Show("SOC高度大于300米，计算有误。" /* string-offset:6572 */);
			}
			obj = new LineCarrier();
			obj._008B_0088_008E(_008A_008B_0088, _008A_008B_008B);
			_008A_008A_0093 = new TemplatePoint
			{
				X = P_0,
				Y = obj._008B_0088_008D(P_0),
				Z = _008A_008B_0094
			};
			_008A_008A_0099 = new LineCarrier();
			_008A_008A_0099._008B_0088_008F(_008A_008A_0093, obj._008B_0088_0094() - Math.PI / 12.0);
			_008A_008A_0094 = new TemplatePoint
			{
				X = _008A_008A_0099._008B_0088_008C(3704.0),
				Y = 3704.0
			};
			_008A_008A_0094.Z = _008A_008B_0092._008B_008B_008A(_008A_008A_0094.X, _008A_008A_0094.Y);
			_008A_008A_0095 = new TemplatePoint(_008A_008B_008F._008B_0088_008C(1852.0), 1852.0);
			_008A_008A_0095.Z = _008A_008B_0093._008B_008B_008A(_008A_008A_0095.X, _008A_008A_0095.Y);
			_008A_008A_0096 = new TemplatePoint(_008A_008A_0095.X, 3704.0, _008A_008A_0095.Z + 30.0);
			_008A_008A_0098 = new TemplatePoint(_008A_008A_0095.X - 20000.0, 1852.0, _008A_008B_0093._008B_008B_008A(_008A_008A_0095.X - 20000.0, 0.0));
			_008A_008A_009B = new PlaneCarrier();
			_008A_008A_009B._008B_008B_008F(_008A_008A_0095, _008A_008A_0096, _008A_008A_0098);
			_008A_008A_009A = _008A_008B_0092._008B_008B_008D(_008A_008A_009B);
			_008A_008A_0097 = new TemplatePoint
			{
				X = _008A_008A_009A._008B_0088_008C(3704.0),
				Y = 3704.0
			};
			// IL local hoisted
			do
			{
				_008A_008A_0097.Z = _008A_008B_0092._008B_008B_008A(_008A_008A_009A._008B_0088_008C(3704.0), 3704.0);
				item = new List<TemplatePoint> { _008A_008A_0093, _008A_008A_0094, _008A_008A_0097, _008A_008A_0095, _008A_008B_008A, _008A_008B_0087, _008A_008B_0088, _008A_008A_0093 };
				_008A_008B_0095.Add(item);
				item = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_008A_0093),
					TemplatePoint._008B_0089_008B(_008A_008A_0094),
					TemplatePoint._008B_0089_008B(_008A_008A_0097),
					TemplatePoint._008B_0089_008B(_008A_008A_0095),
					TemplatePoint._008B_0089_008B(_008A_008B_008A),
					TemplatePoint._008B_0089_008B(_008A_008B_0087),
					TemplatePoint._008B_0089_008B(_008A_008B_0088),
					TemplatePoint._008B_0089_008B(_008A_008A_0093)
				};
				_008A_008B_0095.Add(item);
				_0088n();
				if (!_0088o())
				{
					obj2 = TemplatePoint._008B_0089_008E(_008A_008A_0098, 0.0, 1852.0, 30.0);
					item = new List<TemplatePoint> { _008A_008A_0095, _008A_008A_0097, obj2, _008A_008A_0098, _008A_008A_0095 };
					_008A_008B_0095.Add(item);
					item = new List<TemplatePoint>
					{
						TemplatePoint._008B_0089_008B(_008A_008A_0095),
						TemplatePoint._008B_0089_008B(_008A_008A_0097),
						TemplatePoint._008B_0089_008B(obj2),
						TemplatePoint._008B_0089_008B(_008A_008A_0098),
						TemplatePoint._008B_0089_008B(_008A_008A_0095)
					};
					_008A_008B_0095.Add(item);
					item = new List<TemplatePoint>
					{
						_008A_008B_008A,
						_008A_008A_0095,
						_008A_008A_0098,
						TemplatePoint._008B_0089_008B(_008A_008A_0098),
						TemplatePoint._008B_0089_008B(_008A_008A_0095),
						TemplatePoint._008B_0089_008B(_008A_008B_008A),
						_008A_008B_008A
					};
					break;
				}
			}
			while (_0088o());
			_008A_008B_0095.Add(item);
		}

// R7 MethodDef: original 0x060005E1 RVA 0xB36EC; processed 0x060005E0 RVA 0x84CAC; source 03_recovered-src\annotated-strings\--\--.cs:71916; processed IL recovery, not original runtime.
public TemplatePoint _008A_008A_008A(ref PbnIlsObstacle P_0)
		{
			double num = default(double); // IL InitLocals
			string[] array = default(string[]); // IL InitLocals
			int num3 = default(int); // IL InitLocals
			double[] array2 = default(double[]); // IL InitLocals
			string[] array3 = default(string[]); // IL InitLocals
			int num5 = default(int); // IL InitLocals
			double[] array4 = default(double[]); // IL InitLocals
			int num6 = default(int); // IL InitLocals
			string[] array5 = default(string[]); // IL InitLocals
			int num7 = default(int); // IL InitLocals
			double[] array6 = default(double[]); // IL InitLocals
			string[] array7 = default(string[]); // IL InitLocals
			int num8 = default(int); // IL InitLocals
			double[] array8 = default(double[]); // IL InitLocals
			double[] array9 = default(double[]); // IL InitLocals
			string[] array10 = default(string[]); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			string text = default(string); // IL InitLocals
			double num4 = default(double); // IL InitLocals

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
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				// IL local hoisted
				if (!false /* original-file-bool-offset:1248 */)
				{
					num = ((P_0.Y > 0.0) ? P_0.Y : (0.0 - P_0.Y));
					P_0._0088_0090_008A = "out" /* string-offset:1556 */;
					/* opaque discard 0 */
					if (_0088n())
					{
						num2 = 13;
						goto IL_03df;
					}
					goto IL_04b2;
				}
				num2 = 9;
				goto IL_06f0;
				IL_019e:
				text = array[num3];
				num4 = array2[num3];
				num2 = 18;
				if (!_0088n())
				{
					goto IL_01bd;
				}
				goto IL_02bc;
				IL_0676:
				text = array3[num5];
				num4 = array4[num5];
				num2 = 31;
				goto IL_068b;
				IL_017f:
				if (num3 < array2.Length)
				{
					if (num4 < array2[num3])
					{
						num2 = 7;
						goto IL_019e;
					}
					goto IL_02bc;
				}
				P_0._0088_0090_008A = ((num > 3704.0) ? "out" /* string-offset:1556 */ : text);
				P_0._0088_0090_008D = Math.Max(0.0, (num - 1852.0) / 1852.0);
				num2 = 0;
				goto IL_074e;
				IL_01e6:
				num6++;
				num2 = 22;
				goto IL_01f5;
				IL_015a:
				array = new string[2]
				{
					"Z面" /* string-offset:5488 */,
					"Z面副区" /* string-offset:6576 */
				};
				num3 = 0;
				goto IL_017f;
				IL_068b:
				num5++;
				num2 = 29;
				goto IL_069a;
				IL_04b2:
				text = array5[num7];
				num4 = array6[num7];
				goto IL_0494;
				IL_0494:
				num7++;
				num2 = 27;
				if (_0088n())
				{
					goto IL_031e;
				}
				goto IL_03df;
				IL_03df:
				text = "入口平面" /* string-offset:5472 */;
				num4 = 0.0;
				num2 = 8;
				goto IL_03c6;
				IL_03c6:
				if (!(P_0.X > _008A_008A_0093.X))
				{
					if (P_0.X > _008A_008A_0094.X)
					{
						array4 = new double[4]
						{
							_008A_008B_0090._008B_008B_008A(P_0.X, num),
							_008A_008B_0091._008B_008B_008A(P_0.X, num),
							_008A_008B_0092._008B_008B_008A(P_0.X, num),
							_008A_008B_0093._008B_008B_008A(P_0.X, num)
						};
						num2 = 20;
						goto IL_02c7;
					}
					if (P_0.X > _008A_008A_0095.X)
					{
						num2 = 14;
						if (!_0088o())
						{
							goto IL_031e;
						}
						goto IL_0483;
					}
					if (P_0.X <= _008A_008A_0097.X)
					{
						array2 = new double[2]
						{
							_008A_008B_0093._008B_008B_008A(P_0.X, num),
							_008A_008A_009B._008B_008B_008A(P_0.X, num)
						};
						num2 = 32;
						goto IL_015a;
					}
					goto IL_0215;
				}
				num2 = 21;
				goto IL_0408;
				IL_02c7:
				array3 = new string[4]
				{
					"W面" /* string-offset:5476 */,
					"X面" /* string-offset:5480 */,
					"Y面" /* string-offset:5484 */,
					"Z面" /* string-offset:5488 */
				};
				goto IL_0303;
				IL_0303:
				num5 = 0;
				num2 = 19;
				if (_0088o())
				{
					goto IL_015a;
				}
				goto IL_069a;
				IL_069a:
				if (num5 < array4.Length)
				{
					if (num4 < array4[num5])
					{
						num2 = 15;
						goto IL_0676;
					}
					goto IL_068b;
				}
				num2 = 30;
				goto IL_06ab;
				IL_06f0:
				text = array7[num8];
				num4 = array8[num8];
				num2 = 28;
				goto IL_0705;
				IL_06ab:
				P_0._0088_0090_008A = ((!(text == "Y面" /* string-offset:5484 */) || num <= _008A_008A_0099._008B_0088_008D(P_0.X)) ? text : "out" /* string-offset:1556 */);
				goto IL_074e;
				IL_0705:
				num8++;
				num2 = 23;
				goto IL_0714;
				IL_074e:
				P_0._0088_0090_008B = num4;
				num2 = 4;
				goto IL_075f;
				IL_0215:
				array9 = new double[3]
				{
					_008A_008B_0092._008B_008B_008A(P_0.X, num),
					_008A_008B_0093._008B_008B_008A(P_0.X, num),
					_008A_008A_009B._008B_008B_008A(P_0.X, num)
				};
				array10 = new string[3]
				{
					"Y面" /* string-offset:5484 */,
					"Z面" /* string-offset:5488 */,
					"Z面副区" /* string-offset:6576 */
				};
				num6 = 0;
				num2 = 25;
				goto IL_01f5;
				IL_01f5:
				if (num6 < array9.Length)
				{
					if (num4 >= array9[num6])
					{
						goto IL_01e6;
					}
					num2 = 10;
					goto IL_02a8;
				}
				num2 = 11;
				if (_0088n())
				{
					goto IL_031e;
				}
				goto IL_05ec;
				IL_0714:
				if (num8 < array8.Length)
				{
					if (num4 < array8[num8])
					{
						goto IL_06f0;
					}
					goto IL_0705;
				}
				P_0._0088_0090_008A = ((!(text == "Y面" /* string-offset:5484 */) || num <= 3704.0) ? text : "out" /* string-offset:1556 */);
				goto IL_074e;
				IL_02bc:
				num3++;
				goto IL_017f;
				IL_075f:
				P_0._0088_0090_008C = P_0.Z - P_0._0088_0090_008B;
				break;
				IL_02a8:
				text = array10[num6];
				num2 = 16;
				goto IL_01bd;
				IL_01bd:
				num4 = array9[num6];
				num2 = 3;
				if (!_0088o())
				{
					goto IL_031e;
				}
				goto IL_0714;
				IL_031e:
				switch (num2)
				{
				case 32:
					break;
				case 7:
					goto IL_019e;
				case 16:
					goto IL_01bd;
				case 3:
					goto IL_01e6;
				case 22:
				case 25:
					goto IL_01f5;
				case 1:
					goto IL_0215;
				case 10:
					goto IL_02a8;
				case 18:
					goto IL_02bc;
				case 20:
					goto IL_02c7;
				case 33:
					goto IL_0303;
				default:
					num2 = 12;
					if (_0088o())
					{
						goto IL_03c6;
					}
					goto IL_0714;
				case 8:
					goto IL_03c6;
				case 2:
				case 13:
					goto IL_03df;
				case 21:
					goto IL_0408;
				case 27:
					goto IL_0483;
				case 5:
				case 17:
					goto IL_04b2;
				case 26:
					continue;
				case 11:
					P_0._0088_0090_008A = ((num > 3704.0) ? "out" /* string-offset:1556 */ : text);
					P_0._0088_0090_008D = Math.Max(0.0, (num - 1852.0) / 1852.0);
					goto IL_074e;
				case 14:
					array8 = new double[4]
					{
						_008A_008B_0090._008B_008B_008A(P_0.X, num),
						_008A_008B_0091._008B_008B_008A(P_0.X, num),
						_008A_008B_0092._008B_008B_008A(P_0.X, num),
						_008A_008B_0093._008B_008B_008A(P_0.X, num)
					};
					num2 = 6;
					goto IL_05ec;
				case 6:
					goto IL_05ec;
				case 24:
					goto IL_0628;
				case 15:
					goto IL_0676;
				case 31:
					goto IL_068b;
				case 19:
				case 29:
					goto IL_069a;
				case 30:
					goto IL_06ab;
				case 9:
					goto IL_06f0;
				case 28:
					goto IL_0705;
				case 12:
				case 23:
					goto IL_0714;
				case 0:
					goto IL_074e;
				case 4:
					goto IL_075f;
				case 34:
					goto end_IL_04bf;
				}
				goto IL_015a;
				IL_05ec:
				array7 = new string[4]
				{
					"W面" /* string-offset:5476 */,
					"X面" /* string-offset:5480 */,
					"Y面" /* string-offset:5484 */,
					"Z面" /* string-offset:5488 */
				};
				goto IL_0628;
				IL_0628:
				num8 = 0;
				goto IL_0714;
				IL_0408:
				array6 = new double[3]
				{
					_008A_008B_0090._008B_008B_008A(P_0.X, num),
					_008A_008B_0091._008B_008B_008A(P_0.X, num),
					_008A_008B_0092._008B_008B_008A(P_0.X, num)
				};
				array5 = new string[3]
				{
					"W面" /* string-offset:5476 */,
					"X面" /* string-offset:5480 */,
					"Y面" /* string-offset:5484 */
				};
				num7 = 0;
				goto IL_0483;
				IL_0483:
				if (num7 < array6.Length)
				{
					if (num4 >= array6[num7])
					{
						goto IL_0494;
					}
					goto IL_04b2;
				}
				P_0._0088_0090_008A = ((!(text == "Y面" /* string-offset:5484 */) || num4 <= (double)_008A_008B_0094) ? text : "out" /* string-offset:1556 */);
				goto IL_074e;
				continue;
				end_IL_04bf:
				break;
			}
			return P_0;
		}

// R7 MethodDef: original 0x060005E2 RVA 0xB3F50; processed 0x060005E1 RVA 0x85430; source 03_recovered-src\annotated-strings\--\--.cs:72288; processed IL recovery, not original runtime.
public void _008A_008A_008B(double P_0 = 0.0)
		{
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			_0088o();
			if (_0088n())
			{
				if (!true /* original-file-bool-offset:1252 */)
				{
					return;
				}
				_008A_008B_0086 = _008A_008B_008C._008B_0088_0093(_008A_008B_0090._008B_008B_008E(P_0));
				_008A_008B_0089 = _008A_008B_008E._008B_0088_0093(_008A_008B_0091._008B_008B_008E(P_0));
				_008A_008B_0086.Z = P_0;
				_008A_008B_0089.Z = P_0;
			}
			item = new List<TemplatePoint> { _008A_008B_0089, _008A_008B_0087, _008A_008A_009C, _008A_008B_0086, _008A_008B_0089 };
			_008A_008B_0095.Add(item);
			item = new List<TemplatePoint>
			{
				TemplatePoint._008B_0089_008B(_008A_008B_0089),
				TemplatePoint._008B_0089_008B(_008A_008B_0087),
				TemplatePoint._008B_0089_008B(_008A_008A_009C),
				TemplatePoint._008B_0089_008B(_008A_008B_0086),
				TemplatePoint._008B_0089_008B(_008A_008B_0089)
			};
			_008A_008B_0095.Add(item);
			_008A_008B_0095.Add(PointLists._008B_008A_0092(_008A_008A_009C, _008A_008B_0086));
		}

// R7 MethodDef: original 0x060005E3 RVA 0xB415C; processed 0x060005E2 RVA 0x85580; source 03_recovered-src\annotated-strings\--\--.cs:72316; processed IL recovery, not original runtime.
public List<TemplatePoint> _008A_008A_008C()
		{

			return new List<TemplatePoint> { _008A_008B_0088, _008A_008B_0087, _008A_008A_009C, _008A_008A_009E, _008A_008B_0088 };
		}

// R7 MethodDef: original 0x060005E4 RVA 0xB41B4; processed 0x060005E3 RVA 0x855D0; source 03_recovered-src\annotated-strings\--\--.cs:72321; processed IL recovery, not original runtime.
public List<TemplatePoint> _008A_008A_008D()
		{

			return new List<TemplatePoint>
			{
				TemplatePoint._008B_0089_008B(_008A_008B_0088),
				TemplatePoint._008B_0089_008B(_008A_008B_0087),
				TemplatePoint._008B_0089_008B(_008A_008A_009C),
				TemplatePoint._008B_0089_008B(_008A_008A_009E),
				TemplatePoint._008B_0089_008B(_008A_008B_0088)
			};
		}

// R7 MethodDef: original 0x060005E5 RVA 0xB4224; processed 0x060005E4 RVA 0x85638; source 03_recovered-src\annotated-strings\--\--.cs:72333; processed IL recovery, not original runtime.
public List<TemplatePoint> _008A_008A_008E()
		{

			return new List<TemplatePoint> { _008A_008B_008A, _008A_008B_008B, _008A_008B_0088, _008A_008B_0087, _008A_008B_008A };
		}

// R7 MethodDef: original 0x060005E6 RVA 0xB427C; processed 0x060005E5 RVA 0x85688; source 03_recovered-src\annotated-strings\--\--.cs:72338; processed IL recovery, not original runtime.
public List<TemplatePoint> _008A_008A_008F()
		{

			return new List<TemplatePoint>
			{
				TemplatePoint._008B_0089_008B(_008A_008B_008A),
				TemplatePoint._008B_0089_008B(_008A_008B_008B),
				TemplatePoint._008B_0089_008B(_008A_008B_0088),
				TemplatePoint._008B_0089_008B(_008A_008B_0087),
				TemplatePoint._008B_0089_008B(_008A_008B_008A)
			};
		}

// R7 MethodDef: original 0x060005E7 RVA 0xB42EC; processed 0x060005E6 RVA 0x51B9; source 03_recovered-src\annotated-strings\--\--.cs:72350; processed IL recovery, not original runtime.
public List<TemplatePoint> _008A_008A_0090()
		{

			return PointLists._008B_008A_0092(_008A_008B_008A, _008A_008B_008B);
		}

// R7 MethodDef: original 0x060005E8 RVA 0xB4308; processed 0x060005E7 RVA 0x856F0; source 03_recovered-src\annotated-strings\--\--.cs:72355; processed IL recovery, not original runtime.
public List<TemplatePoint> _008A_008A_0091(double P_0 = 10000.0)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals

			obj = TemplatePoint._008B_0089_008E(_008A_008B_008B, (0.0 - P_0) * Math.Cos(-Math.PI / 12.0), (0.0 - P_0) * Math.Sin(-Math.PI / 12.0));
			return new List<TemplatePoint>
			{
				obj,
				_008A_008B_008B,
				TemplatePoint._008B_0089_008B(_008A_008B_008B),
				TemplatePoint._008B_0089_008B(obj)
			};
		}

// R7 MethodDef: original 0x060005E9 RVA 0xB4388; processed 0x060005E8 RVA 0x8576C; source 03_recovered-src\annotated-strings\--\--.cs:72367; processed IL recovery, not original runtime.
public List<TemplatePoint> _008A_008A_0092()
		{

			return new List<TemplatePoint>
			{
				new TemplatePoint(0.0, 0.0),
				new TemplatePoint(_008A_008A_009C.X, 0.0)
			};
		}

// R7 MethodDef: original 0x060005EA RVA 0xB43F0; processed 0x060005E9 RVA 0x51CC; source 03_recovered-src/annotated-strings/--/--.cs:72376; processed IL recovery, not original runtime.
static PbnIlsTurn()
		{

			// host licensing excluded from independent recovery
		}

// R7 MethodDef: original 0x060005EB RVA 0xB440C; processed 0x060005EA RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:72381; processed IL recovery, not original runtime.
internal static bool _0088n()
		{

			return true;
		}

// R7 MethodDef: original 0x060005EC RVA 0xB4418; processed 0x060005EB RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:72386; processed IL recovery, not original runtime.
internal static bool _0088o()
		{

			return false;
		}
	}
}
