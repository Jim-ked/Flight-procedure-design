using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
// Processed source/IL recovery; identifiers and branches retained. No original DLL oracle.
namespace Recovered.B3 {
	public class RnpApchLnav
	{
		public TemplatePoint _0089_009C_0088;

		public TemplatePoint _0089_009C_0089;

		public TemplatePoint _0089_009C_008A;

		public TemplatePoint _0089_009C_008B;

		public TemplatePoint _0089_009C_008C;

		public TemplatePoint _0089_009C_008D;

		public TemplatePoint _0089_009C_008E;

		public TemplatePoint _0089_009C_008F;

		public TemplatePoint _0089_009C_0090;

		public double _0089_009C_0091;

		public double _0089_009C_0092;

		public double _0089_009C_0093;

		public double _0089_009C_0094;

		private double _0089_009C_0095;

		public List<List<TemplatePoint>> _0089_009C_0096;

// R6 MethodDef: original 0x06000593 RVA 0x94C84; processed 0x06000592 RVA 0x5076; source :; processed IL recovery, not original runtime.
public RnpApchLnav()
		{

			_0089_009C_0095 = 444.0;
			// object constructor emitted automatically
		}

// R6 MethodDef: original 0x06000594 RVA 0x94CA4; processed 0x06000593 RVA 0x7952C; source 03_recovered-src/annotated-strings/--/--.cs:65895; processed IL recovery, not original runtime.
public RnpApchLnav(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6, double P_7)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (!false /* original-file-bool-offset:1112 */)
			{
				_0089_009C_0095 = 444.0;
				// object constructor emitted automatically
				_0089_009C_0091 = P_0;
				_0089_009C_0093 = P_5;
				_0089_009C_0092 = (P_1 - P_2 - P_4) / Math.Tan(P_3 * Math.PI / 180.0);
				_0089_009C_0094 = P_6 + P_7;
				_0089_009C_0088 = new TemplatePoint(_0089_009C_0092 + P_0, 4630.0);
				_0089_009C_0089 = new TemplatePoint(_0089_009C_0092 + 3369.0, 4630.0);
				/* opaque discard 1 */
				if (!_00884())
				{
					_0089_009C_008A = new TemplatePoint(_0089_009C_0092, 2685.0);
				}
				do
				{
					_0089_009C_008B = new TemplatePoint(_0089_009C_0092 - 1604.0, 1759.0);
				}
				while (_00884());
				_0089_009C_008C = new TemplatePoint(444.0, 1759.0);
				_0089_009C_008D = new TemplatePoint(0.0, 0.0);
				_0089_009C_008E = new TemplatePoint(-6814.0, 3704.0);
				_0089_009C_008F = new TemplatePoint(0.0 - P_6, (_0089_009C_0095 + P_6) * Math.Tan(Math.PI / 12.0) + 1759.0);
				_0089_009C_0090 = new TemplatePoint(Math.Min(0.0 - _0089_009C_0094, -6814.0), 3704.0);
				_0089_009C_0096 = new List<List<TemplatePoint>>();
				list = new List<TemplatePoint> { _0089_009C_0088, _0089_009C_0089, _0089_009C_008B, _0089_009C_008C, _0089_009C_008E, _0089_009C_0090 };
				_0089_009C_0096.Add(list);
				_0089_009C_0096.Add(PointLists._008B_008A_0097(list, new TemplatePoint(1.0, 0.5, 1.0)));
				_0089_009C_0096.Add(PointLists._008B_008A_0097(list, new TemplatePoint(1.0, -0.5, 1.0)));
				_0089_009C_0096.Add(PointLists._008B_008A_0097(list, new TemplatePoint(1.0, -1.0, 1.0)));
			}
		}

// R6 MethodDef: original 0x06000595 RVA 0x950D4; processed 0x06000594 RVA 0x7982C; source 03_recovered-src\annotated-strings\--\--.cs:65931; processed IL recovery, not original runtime.
public void _0089_009C_0086(ref RnpApchObstacle P_0)
		{
			int num = default(int); // IL InitLocals
			RnpApchObstacle obj = default(RnpApchObstacle); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			RnpApchObstacle obj2 = default(RnpApchObstacle); // IL InitLocals
			RnpApchObstacle obj3 = default(RnpApchObstacle); // IL InitLocals
			RnpApchObstacle obj4 = default(RnpApchObstacle); // IL InitLocals
			RnpApchObstacle obj5 = default(RnpApchObstacle); // IL InitLocals
			RnpApchObstacle obj6 = default(RnpApchObstacle); // IL InitLocals
			RnpApchObstacle obj7 = default(RnpApchObstacle); // IL InitLocals
			RnpApchObstacle obj8 = default(RnpApchObstacle); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			RnpApchObstacle obj9 = default(RnpApchObstacle); // IL InitLocals
			RnpApchObstacle obj10 = default(RnpApchObstacle); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals

			num = 13;
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
				if (!false /* original-file-bool-offset:1116 */)
				{
					num2 = Math.Abs(P_0.Y);
					num = 30;
					while (true)
					{
						P_0._0088_008F_009C = "out" /* string-offset:1556 */;
						num = 1;
						while (true)
						{
							IL_05b6:
							if (!(P_0.X > _0089_009C_0091 + _0089_009C_0092) && !(P_0.X < 0.0 - _0089_009C_0094) && num2 <= _0089_009C_0088.Y)
							{
								if (P_0.X >= _0089_009C_0089.X)
								{
									obj = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X - _0089_009C_0088.X, num2, P_0.Z)), _0089_009C_0088.Y, 150.0, _0089_009C_0089.Y, 150.0, _0089_009C_0091);
									num = 10;
									goto IL_031c;
								}
								if (!(P_0.X < _0089_009C_008A.X - _0089_009C_0095))
								{
									goto IL_0985;
								}
								if (P_0.X < _0089_009C_008B.X)
								{
									if (!(P_0.X < _0089_009C_008C.X))
									{
										goto IL_0ac6;
									}
									if (P_0.X >= _0089_009C_008D.X)
									{
										num = 14;
										if (!_00884())
										{
											goto IL_0367;
										}
										goto IL_0c1d;
									}
									num3 = 45.0 / _0089_009C_0093;
									num4 = Math.Abs(_0089_009C_008F.X);
									num = 11;
									goto IL_058c;
								}
								num = 27;
								goto IL_0814;
							}
							return;
							IL_0c34:
							P_0._0088_0090_0086 = P_0.Z + obj2._0088_008F_009D;
							return;
							IL_0909:
							P_0._0088_008F_009C = "复飞初始段" /* string-offset:6524 */ + obj3._0088_008F_009C;
							P_0._0088_008F_009D = obj3._0088_008F_009D;
							num = 33;
							if (_00883())
							{
								goto IL_096e;
							}
							goto IL_0a5b;
							IL_0a5b:
							P_0._0088_008F_009C = "复飞初始段" /* string-offset:6524 */ + obj4._0088_008F_009C;
							num = 12;
							goto IL_0a81;
							IL_0a81:
							P_0._0088_008F_009D = obj4._0088_008F_009D;
							num = 7;
							goto IL_0a98;
							IL_0a98:
							P_0._0088_0090_0086 = P_0.Z + obj4._0088_008F_009D;
							return;
							IL_096e:
							P_0._0088_0090_0086 = P_0.Z + obj3._0088_008F_009D;
							return;
							IL_0b8c:
							P_0._0088_0090_0086 = P_0.Z + obj5._0088_008F_009D;
							return;
							IL_0660:
							if (obj6._0088_008F_009C != "out" /* string-offset:1556 */)
							{
								P_0._0088_008F_009C = "复飞中间段" /* string-offset:5860 */ + obj6._0088_008F_009C;
								num = 22;
								goto IL_06a1;
							}
							return;
							IL_0985:
							obj7 = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X - _0089_009C_0089.X, num2, P_0.Z)), _0089_009C_0089.Y, 150.0, _0089_009C_008A.Y - 256.3, 150.0, 3369.0 + _0089_009C_0095);
							num = 32;
							goto IL_09fd;
							IL_06a1:
							P_0._0088_0090_0086 = obj6._0088_008F_009D + obj6.Z;
							goto IL_06b7;
							IL_058c:
							num5 = Math.Min(75.0, num4 * _0089_009C_0093 + 30.0);
							if (!(num3 < num4))
							{
								if (!(P_0.X >= _0089_009C_008F.X))
								{
									goto IL_053b;
								}
								obj8 = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X, num2, P_0.Z)), _0089_009C_008C.Y + 119.0, num5, _0089_009C_008F.Y, 30.0, num4);
								if (obj8._0088_008F_009C != "out" /* string-offset:1556 */)
								{
									P_0._0088_008F_009C = "复飞初始段" /* string-offset:6524 */ + obj8._0088_008F_009C;
									goto IL_0801;
								}
								return;
							}
							num6 = _0089_009C_008C.Y + (num4 - num3 + _0089_009C_0095) * Math.Tan(Math.PI / 12.0);
							num = 25;
							goto IL_0220;
							IL_06b7:
							P_0._0088_0090_0088 = (_0089_009C_008F.X - P_0.X) * _0089_009C_0093;
							num = 43;
							if (!_00883())
							{
								break;
							}
							goto IL_0c4c;
							IL_0c4c:
							P_0._0088_008F_009D = obj6._0088_008F_009D;
							num = 45;
							return;
							IL_0ac6:
							obj5 = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X - _0089_009C_0092 + 1604.0, num2, P_0.Z)), _0089_009C_008B.Y, 75.0, _0089_009C_008C.Y, 75.0, _0089_009C_0092 - 1604.0 - _0089_009C_0095);
							if (obj5._0088_008F_009C != "out" /* string-offset:1556 */)
							{
								num = 9;
								goto IL_0b58;
							}
							return;
							IL_09fd:
							if (obj7._0088_008F_009C != "out" /* string-offset:1556 */)
							{
								P_0._0088_008F_009C = "中间进近航段" /* string-offset:6516 */ + obj7._0088_008F_009C;
								goto IL_0bba;
							}
							return;
							IL_053b:
							if (P_0.X >= _0089_009C_008E.X)
							{
								num = 16;
								goto IL_04af;
							}
							if (_0089_009C_0094 >= Math.Abs(_0089_009C_0090.X))
							{
								obj6 = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X - _0089_009C_008E.X, num2, P_0.Z)), 3704.0, 30.0, 3704.0, 30.0, _0089_009C_008E.X - _0089_009C_0090.X);
								num = 3;
								goto IL_0660;
							}
							return;
							IL_0b58:
							P_0._0088_008F_009C = "最后进近航段" /* string-offset:6520 */ + obj5._0088_008F_009C;
							P_0._0088_008F_009D = obj5._0088_008F_009D;
							num = 2;
							goto IL_0b8c;
							IL_04af:
							obj9 = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X - _0089_009C_008F.X, num2, P_0.Z)), _0089_009C_008F.Y, 30.0, _0089_009C_008E.Y, 30.0, _0089_009C_008F.X - _0089_009C_008E.X);
							if (obj9._0088_008F_009C != "out" /* string-offset:1556 */)
							{
								goto IL_0487;
							}
							return;
							IL_0487:
							P_0._0088_008F_009C = "复飞中间段" /* string-offset:5860 */ + obj9._0088_008F_009C;
							num = 0;
							goto IL_0466;
							IL_0466:
							P_0._0088_0090_0086 = obj9._0088_008F_009D + obj9.Z;
							num = 20;
							goto IL_042d;
							IL_042d:
							P_0._0088_0090_0088 = (_0089_009C_008F.X - P_0.X) * _0089_009C_0093;
							num = 15;
							if (!_00884())
							{
								goto IL_0367;
							}
							goto IL_0be8;
							IL_0367:
							while (true)
							{
								switch (num)
								{
								case 28:
									if (!(obj10._0088_008F_009C != "out" /* string-offset:1556 */))
									{
										return;
									}
									_00883();
									if (!_00884())
									{
										num = 8;
										if (!_00884())
										{
											goto case 8;
										}
										goto IL_0bba;
									}
									num = 23;
									if (_00883())
									{
										continue;
									}
									break;
								case 8:
								case 19:
									P_0._0088_008F_009C = "最后进近航段" /* string-offset:6520 */ + obj10._0088_008F_009C;
									num = 18;
									if (_00883())
									{
										continue;
									}
									goto IL_0b8c;
								case 25:
									break;
								case 14:
									obj10 = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X - _0089_009C_0095, num2, P_0.Z)), _0089_009C_008C.Y, 75.0, _0089_009C_008C.Y + 119.0, 75.0, _0089_009C_0095);
									goto case 28;
								case 10:
									goto IL_031c;
								case 20:
									goto IL_042d;
								case 0:
									goto IL_0466;
								case 4:
									goto IL_0487;
								case 16:
									goto IL_04af;
								case 11:
									goto IL_058c;
								case 1:
									goto IL_05b6;
								case 3:
									goto IL_0660;
								case 22:
									goto IL_06a1;
								case 23:
								case 41:
									goto IL_06b7;
								case 30:
									goto end_IL_05b6;
								case 13:
									goto end_IL_06eb;
								default:
									num = 29;
									return;
								case 15:
									P_0._0088_008F_009D = obj9._0088_008F_009D;
									num = 42;
									return;
								case 18:
									P_0._0088_008F_009D = obj10._0088_008F_009D;
									num = 37;
									goto case 37;
								case 26:
									goto IL_0801;
								case 27:
									goto IL_0814;
								case 17:
									goto IL_0909;
								case 31:
									P_0._0088_008F_009D = obj._0088_008F_009D;
									P_0._0088_0090_0086 = P_0.Z + obj._0088_008F_009D;
									return;
								case 33:
									goto IL_096e;
								case 34:
									goto IL_0985;
								case 32:
									goto IL_09fd;
								case 36:
									if (obj4._0088_008F_009C != "out" /* string-offset:1556 */)
									{
										num = 35;
										goto IL_0a5b;
									}
									return;
								case 35:
									goto IL_0a5b;
								case 12:
									goto IL_0a81;
								case 7:
									goto IL_0a98;
								case 37:
									P_0._0088_0090_0086 = P_0.Z + obj10._0088_008F_009D;
									return;
								case 29:
									return;
								case 39:
									goto IL_0ac6;
								case 9:
									goto IL_0b58;
								case 2:
									goto IL_0b8c;
								case 40:
									goto IL_0ba3;
								case 44:
									goto IL_0bba;
								case 21:
									return;
								case 24:
									goto IL_0be8;
								case 5:
									goto IL_0c1d;
								case 6:
									goto IL_0c34;
								case 42:
									return;
								case 43:
									goto IL_0c4c;
								case 45:
									return;
								case 38:
									return;
								}
								break;
							}
							goto IL_0220;
							IL_0801:
							P_0._0088_008F_009D = obj8._0088_008F_009D;
							goto IL_0ba3;
							IL_0ba3:
							P_0._0088_0090_0086 = P_0.Z + obj8._0088_008F_009D;
							return;
							IL_031c:
							if (obj._0088_008F_009C != "out" /* string-offset:1556 */)
							{
								P_0._0088_008F_009C = "中间进近航段" /* string-offset:6516 */ + obj._0088_008F_009C;
								num = 31;
								if (_00884())
								{
									goto IL_0220;
								}
								goto IL_0367;
							}
							return;
							IL_0814:
							obj2 = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X - _0089_009C_008A.X + _0089_009C_0095, num2, P_0.Z)), _0089_009C_008A.Y - 256.3, 75.0, _0089_009C_008B.Y, 75.0, 1604.0 - _0089_009C_0095);
							num = 24;
							goto IL_0be8;
							IL_0220:
							if (P_0.X < _0089_009C_008F.X + num3)
							{
								if (!(P_0.X >= _0089_009C_008F.X))
								{
									goto IL_053b;
								}
								obj4 = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X - _0089_009C_008F.X - num3, num2, P_0.Z)), num6, 75.0, _0089_009C_008F.Y, 30.0, num3);
								num = 36;
								if (!_00884())
								{
									goto IL_0367;
								}
							}
							else
							{
								obj3 = _0089_009C_0087(new RnpApchObstacle(new TemplatePoint(P_0.X, num2, P_0.Z)), _0089_009C_008C.Y + 119.0, 75.0, num6, 75.0, num4 - num3);
								if (!(obj3._0088_008F_009C != "out" /* string-offset:1556 */))
								{
									return;
								}
								num = 17;
							}
							goto IL_0909;
							IL_0be8:
							if (obj2._0088_008F_009C != "out" /* string-offset:1556 */)
							{
								P_0._0088_008F_009C = "最后进近航段" /* string-offset:6520 */ + obj2._0088_008F_009C;
								goto IL_0c1d;
							}
							return;
							IL_0c1d:
							P_0._0088_008F_009D = obj2._0088_008F_009D;
							num = 6;
							goto IL_0c34;
							IL_0bba:
							P_0._0088_008F_009D = obj7._0088_008F_009D;
							P_0._0088_0090_0086 = P_0.Z + obj7._0088_008F_009D;
							num = 21;
							return;
							continue;
							end_IL_05b6:
							break;
						}
						continue;
						end_IL_06eb:
						break;
					}
					continue;
				}
				num = 38;
				break;
			}
		}

// R6 MethodDef: original 0x06000596 RVA 0x95DB8; processed 0x06000595 RVA 0x7A4A0; source 03_recovered-src\annotated-strings\--\--.cs:66344; processed IL recovery, not original runtime.
private RnpApchObstacle _0089_009C_0087(RnpApchObstacle P_0, double P_1, double P_2, double P_3, double P_4, double P_5)
		{
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			LineCarrier obj2 = default(LineCarrier); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj4 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj5 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj6 = default(TemplatePoint); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:1120 */)
			{
				goto IL_0134;
			}
			P_0._0088_008F_009C = "out" /* string-offset:1556 */;
			// P595 constructs an unused plane carrier; no methods or fields consumed.
			obj = new LineCarrier();
			obj2 = new LineCarrier();
			obj3 = new TemplatePoint(0.0, P_1 / 2.0);
			obj4 = new TemplatePoint(0.0 - P_5, P_3 / 2.0);
			obj._008B_0088_008E(obj3, obj4);
			obj5 = new TemplatePoint(0.0, P_1);
			if (!_00883())
			{
				goto IL_0157;
			}
			obj6 = new TemplatePoint(0.0 - P_5, P_3);
			goto IL_01d5;
			IL_0157:
			num = P_4 + (P_2 - P_4) * (P_5 + P_0.X) / P_5;
			goto IL_0179;
			IL_0134:
			// IL local hoisted
			// IL local hoisted
			if (P_0.X > 0.0 - P_5 && num2 < num3)
			{
				_00884();
				if (_00883())
				{
					goto IL_0157;
				}
				if (!_00884())
				{
					goto IL_0179;
				}
			}
			goto IL_0212;
			IL_01d5:
			obj2._008B_0088_008E(obj5, obj6);
			num3 = ((!(P_1 > P_3)) ? P_3 : P_1);
			num2 = Math.Abs(P_0.Y);
			if (P_0.X <= 0.0)
			{
				goto IL_0134;
			}
			goto IL_0212;
			IL_0212:
			return P_0;
			IL_0179:
			num4 = obj._008B_0088_008D(P_0.X);
			num5 = obj2._008B_0088_008D(P_0.X);
			if (num2 > num4)
			{
				if (num2 <= num5)
				{
					num6 = ((num5 - num4 == 0.0) ? num : (num * (num5 - num2) / (num5 - num4)));
					P_0._0088_008F_009D = num6;
					if (_00884())
					{
						goto IL_01d5;
					}
					P_0._0088_008F_009C = "副区" /* string-offset:3600 */;
				}
			}
			else
			{
				P_0._0088_008F_009D = num;
				P_0._0088_008F_009C = "主区" /* string-offset:3596 */;
			}
			goto IL_0212;
		}

// R6 MethodDef: original 0x06000597 RVA 0x96128; processed 0x06000596 RVA 0x508D; source 03_recovered-src/annotated-strings/--/--.cs:66418; processed IL recovery, not original runtime.
static RnpApchLnav()
		{

			// Host licensing not executed.
		}

// R6 MethodDef: original 0x06000598 RVA 0x96144; processed 0x06000597 RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:66423; processed IL recovery, not original runtime.
internal static bool _00883()
		{

			return true;
		}

// R6 MethodDef: original 0x06000599 RVA 0x96150; processed 0x06000598 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:66428; processed IL recovery, not original runtime.
internal static bool _00884()
		{

			return false;
		}
	}
}
