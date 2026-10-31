using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
// Processed source/IL recovery; identifiers and branches retained. No original DLL oracle.
namespace Recovered.B3 {
	public class RnpApchApv
	{
		public TemplatePoint _008A_008B_009D;

		public TemplatePoint _008A_008B_009E;

		public TemplatePoint _008A_008C_0086;

		public TemplatePoint _008A_008C_0087;

		public TemplatePoint _008A_008C_0088;

		public TemplatePoint _008A_008C_0089;

		public TemplatePoint _008A_008C_008A;

		public TemplatePoint _008A_008C_008B;

		public TemplatePoint _008A_008C_008C;

		public TemplatePoint _008A_008C_008D;

		public TemplatePoint _008A_008C_008E;

		public TemplatePoint _008A_008C_008F;

		public TemplatePoint _008A_008C_0090;

		public double _008A_008C_0091;

		private double _008A_008C_0092;

		private double _008A_008C_0093;

		private double _008A_008C_0094;

		public double _008A_008C_0095;

		private double _008A_008C_0096;

		private double _008A_008C_0097;

		private double _008A_008C_0098;

// R6 MethodDef: original 0x060005ED RVA 0xB4424; processed 0x060005EC RVA 0x51DE; source :; processed IL recovery, not original runtime.
public RnpApchApv()
		{

			_008A_008C_0092 = 444.0;
			// object constructor emitted automatically
		}

// R6 MethodDef: original 0x060005EE RVA 0xB4444; processed 0x060005ED RVA 0x857CC; source 03_recovered-src/annotated-strings/--/--.cs:72445; processed IL recovery, not original runtime.
public RnpApchApv(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6, double P_7, double P_8, double P_9, string P_10)
		{
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			if (!true /* original-file-bool-offset:1256 */)
			{
				return;
			}
			if (_0088p())
			{
				_008A_008C_0092 = 444.0;
				// object constructor emitted automatically
				_008A_008C_0093 = P_1;
				// IL local hoisted
				// IL local hoisted
				// IL local hoisted
				// IL local hoisted
				// IL local hoisted
				// IL local hoisted
				while (true)
				{
					_008A_008C_0094 = P_2;
					_008A_008C_0095 = Math.Tan(P_3 * Math.PI / 180.0);
					_008A_008C_0096 = P_5;
					_008A_008C_0091 = P_6;
					if (_0088p())
					{
						num = (P_1 - P_2 - P_4) / _008A_008C_0095;
						num2 = P_7;
						if (_0088q())
						{
							continue;
						}
						_008A_008B_009D = new TemplatePoint(num + P_0, 4630.0);
						_008A_008B_009E = new TemplatePoint(num + 3369.0, 4630.0);
						_008A_008C_0086 = new TemplatePoint(num, 2685.0, P_1 - P_2);
						_008A_008C_0087 = new TemplatePoint(num - 1604.0, 1759.0);
						goto IL_011c;
					}
					goto IL_03e8;
					IL_02bd:
					_008A_008C_0087.Z = (_008A_008C_0087.X - num3) * num4;
					_008A_008C_008F = new TemplatePoint(num3, _008A_008C_0088.Y);
					_008A_008C_0090 = new TemplatePoint(_008A_008C_0097, _008A_008C_0088.Y + (_008A_008C_0088.X - _008A_008C_0097) * Math.Tan(Math.PI / 12.0));
					if (_0088p())
					{
						break;
					}
					goto IL_011c;
					IL_011c:
					_008A_008C_0088 = new TemplatePoint(444.0, 1759.0);
					_008A_008C_0089 = new TemplatePoint(0.0, 0.0);
					_008A_008C_008A = new TemplatePoint(-6814.0, 3704.0);
					_008A_008C_008C = new TemplatePoint(Math.Min(0.0 - num2, -6814.0), 3704.0);
					num3 = (_008A_008C_0096 - P_4) / _008A_008C_0095 + _008A_008C_0092;
					num5 = _008A_008B_009B(P_2, P_9, P_1 - P_2);
					num4 = (P_1 - P_2 - num5 - _008A_008C_0096) * _008A_008C_0095 / (P_1 - P_2 - _008A_008C_0096);
					num6 = Math.Round(Math.Atan(num4) * 180.0 / Math.PI, 2);
					if (num4 < Math.Tan(Math.PI / 72.0))
					{
						RecoveryMessages.Show("机场最低温度对应的FAS面角度为" /* string-offset:6580 */ + num6 + "°，\n 低于2.5°，请提高低温限制。" /* string-offset:6584 */);
						_0088q();
						if (!_0088p())
						{
							goto IL_0350;
						}
					}
					else if (num4 > Math.Tan(Math.PI * 7.0 / 360.0))
					{
						RecoveryMessages.Show("机场最高温度对应的FAS面角度为" /* string-offset:6588 */ + num6 + "°，\n 大于3.5°，请降低高温限制。" /* string-offset:6592 */);
					}
					num7 = (P_1 - P_2 - num5 - P_5) / num4 + num3;
					if (!_0088p())
					{
						goto IL_02bd;
					}
					goto IL_03e8;
					IL_03e8:
					num8 = num7 + 150.0 / num4;
					_008A_008C_0097 = _008A_008B_0099(P_10);
					_008A_008C_0098 = _008A_008B_009A(P_10, P_8, P_3);
					goto IL_0350;
					IL_0350:
					_008A_008C_008D = new TemplatePoint(num8, _008A_008C_0087.Y + (num8 - _008A_008C_0087.X) * Math.Tan(Math.PI / 6.0), P_1 - P_2 - _008A_008C_0096 - num5 + 150.0 - _008A_008C_0096);
					_008A_008C_008E = new TemplatePoint(num7, _008A_008C_0087.Y + (num7 - _008A_008C_0087.X) * Math.Tan(Math.PI / 6.0), P_1 - P_2 - _008A_008C_0096 - num5);
					goto IL_02bd;
				}
			}
			_008A_008C_008A.Z = (_008A_008C_0097 - _008A_008C_008A.X) * P_6;
			_008A_008C_008C.Z = (_008A_008C_0097 - _008A_008C_008C.X) * P_6;
		}

// R6 MethodDef: original 0x060005EF RVA 0xB4A48; processed 0x060005EE RVA 0x85C34; source 03_recovered-src\annotated-strings\--\--.cs:72535; processed IL recovery, not original runtime.
public void _008A_008B_0096(ref RnpApchApvObstacle P_0)
		{
			int num = default(int); // IL InitLocals
			RnpApchApvObstacle obj = default(RnpApchApvObstacle); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			num = 0;
			// IL local hoisted
			// IL local hoisted
			while (true /* original-file-bool-offset:1260 */)
			{
				while (true)
				{
					IL_05d6:
					num2 = ((!(P_0.Y > 0.0)) ? (0.0 - P_0.Y) : P_0.Y);
					if (P_0.X <= _008A_008B_009D.X)
					{
						RecoveryMessages.Discard(_008A_008C_008D.X);
						RecoveryMessages.Discard(_008A_008B_009E.X);
						if (P_0.X > _008A_008B_009E.X)
						{
							num = 54;
							goto IL_0357;
						}
						if (P_0.X <= _008A_008C_008D.X)
						{
							if (P_0.X > _008A_008C_008E.X)
							{
								num = 29;
								goto IL_0487;
							}
							if (P_0.X <= _008A_008C_0087.X)
							{
								if (P_0.X > _008A_008C_008F.X)
								{
									num = 40;
									goto IL_0196;
								}
								if (P_0.X <= _008A_008C_0088.X)
								{
									if (P_0.X <= _008A_008C_0090.X)
									{
										if (!(P_0.X <= _008A_008C_008A.X))
										{
											goto IL_0a1b;
										}
										if (!(P_0.X < _008A_008C_008C.X))
										{
											goto IL_028a;
										}
										P_0._0088_0090_008A = "out" /* string-offset:1556 */;
										num = 60;
										if (_0088p())
										{
											goto IL_04c7;
										}
										goto IL_0b9e;
									}
									num = 21;
									goto IL_0651;
								}
								num = 33;
								goto IL_06be;
							}
							num = 39;
							goto IL_06ee;
						}
						num = 45;
						goto IL_0773;
					}
					P_0._0088_0090_008A = "out" /* string-offset:1556 */;
					num = 27;
					return;
					IL_0266:
					P_0._0088_0090_008F = P_0.Z + P_0._0088_0090_008D;
					num = 59;
					goto IL_015e;
					IL_015e:
					P_0._0088_0090_0090 = P_0._0088_0090_008F - _008A_008C_0094;
					_0088q();
					if (_0088p())
					{
						num = 46;
						if (_0088q())
						{
							goto IL_0196;
						}
						goto IL_04c7;
					}
					goto IL_0b87;
					IL_0bc2:
					P_0._0088_0090_008A = "水平段" /* string-offset:6616 */ + P_0._0088_0090_008A;
					num = 34;
					goto IL_0be8;
					IL_0be8:
					P_0._0088_0090_008C = P_0.Z - P_0._0088_0090_008B;
					P_0._0088_0090_008B += _008A_008C_0094;
					goto IL_0c12;
					IL_01be:
					if (P_0._0088_0090_008A != "out" /* string-offset:1556 */)
					{
						num = 12;
						goto IL_01e2;
					}
					return;
					IL_0c12:
					if (P_0._0088_0090_008C > 0.0)
					{
						_008A_008B_009C(ref P_0);
						num = 48;
					}
					else
					{
						P_0._0088_0090_008D *= _008A_008C_0098;
					}
					return;
					IL_01e2:
					P_0._0088_0090_008A = "最后段" /* string-offset:6612 */ + P_0._0088_0090_008A;
					num = 25;
					goto IL_0208;
					IL_07ee:
					P_0._0088_0090_008B = _008A_008C_0093 - P_0._0088_0090_008D;
					P_0._0088_0090_008F = P_0.Z + P_0._0088_0090_008D;
					P_0._0088_0090_0090 = P_0._0088_0090_008F - _008A_008C_0094;
					num = 28;
					return;
					IL_0208:
					P_0._0088_0090_008C = P_0.Z - P_0._0088_0090_008B;
					P_0._0088_0090_008B += _008A_008C_0094;
					if (P_0._0088_0090_008C > 0.0)
					{
						_008A_008B_009C(ref P_0);
						num = 6;
						if (_0088p())
						{
							goto IL_04c7;
						}
						goto IL_0b25;
					}
					P_0._0088_0090_008D *= _008A_008C_0098;
					return;
					IL_0b87:
					P_0._0088_0090_008F = P_0.Z + P_0._0088_0090_008D;
					return;
					IL_0a1b:
					_008A_008B_0097(ref P_0, _008A_008C_0090, 30.0, _008A_008C_008A, 30.0);
					if (P_0._0088_0090_008A != "out" /* string-offset:1556 */)
					{
						P_0._0088_0090_008A = "复飞段" /* string-offset:6620 */ + P_0._0088_0090_008A;
						P_0._0088_0090_008C = P_0.Z - P_0._0088_0090_008B;
						P_0._0088_0090_008B += _008A_008C_0094;
						goto IL_0a9f;
					}
					return;
					IL_0a9f:
					if (P_0._0088_0090_008C > 0.0)
					{
						_008A_008B_009C(ref P_0);
					}
					else
					{
						P_0._0088_0090_008D *= _008A_008C_0098;
					}
					return;
					IL_06ee:
					_008A_008B_0097(ref P_0, _008A_008C_008E, _008A_008C_0096, _008A_008C_0087, _008A_008C_0096);
					goto IL_0ace;
					IL_0651:
					_008A_008B_0097(ref P_0, _008A_008C_0088, 30.0, _008A_008C_0090, 30.0);
					goto IL_0676;
					IL_0676:
					if (P_0._0088_0090_008A != "out" /* string-offset:1556 */)
					{
						P_0._0088_0090_008A = "水平段" /* string-offset:6616 */ + P_0._0088_0090_008A;
						num = 35;
						goto IL_098f;
					}
					return;
					IL_0773:
					_008A_008B_0097(ref P_0, _008A_008B_009E, 150.0, _008A_008C_008E, 150.0);
					if (P_0._0088_0090_008A == "out" /* string-offset:1556 */)
					{
						return;
					}
					P_0._0088_0090_008A = "中间段" /* string-offset:6596 */ + P_0._0088_0090_008A;
					P_0._0088_0090_008D *= 150.0;
					num = 19;
					goto IL_07ee;
					IL_028a:
					_008A_008B_0097(ref P_0, _008A_008C_008A, 30.0, _008A_008C_008C, 30.0);
					num = 11;
					goto IL_02b8;
					IL_02b8:
					if (P_0._0088_0090_008A != "out" /* string-offset:1556 */)
					{
						P_0._0088_0090_008A = "复飞段" /* string-offset:6620 */ + P_0._0088_0090_008A;
						goto IL_02f0;
					}
					return;
					IL_098f:
					P_0._0088_0090_008C = P_0.Z - P_0._0088_0090_008B;
					num = 10;
					if (_0088q())
					{
						goto IL_09b5;
					}
					goto IL_09d7;
					IL_02f0:
					P_0._0088_0090_008C = P_0.Z - P_0._0088_0090_008B;
					goto IL_0306;
					IL_0306:
					P_0._0088_0090_008B += _008A_008C_0094;
					num = 31;
					goto IL_0323;
					IL_0323:
					if (P_0._0088_0090_008C > 0.0)
					{
						_008A_008B_009C(ref P_0);
						num = 23;
						if (_0088p())
						{
							goto IL_04c7;
						}
						goto IL_0c12;
					}
					P_0._0088_0090_008D *= _008A_008C_0098;
					num = 53;
					if (_0088p())
					{
						return;
					}
					goto IL_098f;
					IL_09b5:
					P_0._0088_0090_0090 = P_0.Z + P_0._0088_0090_008D - _008A_008C_0094;
					goto IL_0b87;
					IL_04c7:
					while (true)
					{
						switch (num)
						{
						case 59:
							break;
						case 40:
							goto IL_0196;
						case 44:
							goto IL_01be;
						case 12:
							goto IL_01e2;
						case 25:
							goto IL_0208;
						case 56:
							goto IL_0266;
						case 55:
							goto IL_028a;
						case 11:
							goto IL_02b8;
						case 30:
							goto IL_02f0;
						case 4:
							goto IL_0306;
						case 31:
							goto IL_0323;
						case 54:
							goto IL_0357;
						case 42:
							goto IL_03f8;
						case 22:
							goto IL_045d;
						case 29:
							goto IL_0487;
						default:
							num = 14;
							if (_0088p())
							{
								continue;
							}
							return;
						case 43:
							goto IL_05d6;
						case 0:
							goto end_IL_05d6;
						case 6:
							return;
						case 13:
							return;
						case 21:
							goto IL_0651;
						case 1:
							goto IL_0676;
						case 23:
							return;
						case 27:
							return;
						case 33:
							goto IL_06be;
						case 39:
							goto IL_06ee;
						case 41:
							P_0._0088_0090_008F = P_0.Z + P_0._0088_0090_008D;
							num = 24;
							goto case 24;
						case 24:
							P_0._0088_0090_0090 = P_0._0088_0090_008F - _008A_008C_0094;
							return;
						case 45:
							goto IL_0773;
						case 19:
							goto IL_07ee;
						case 28:
							return;
						case 15:
						case 46:
							return;
						case 47:
							goto IL_0839;
						case 3:
							goto IL_087b;
						case 32:
							goto IL_089c;
						case 38:
							goto IL_0910;
						case 16:
							goto IL_0941;
						case 7:
							return;
						case 5:
							return;
						case 35:
							goto IL_098f;
						case 37:
							goto IL_09b5;
						case 10:
							goto IL_09d7;
						case 2:
							goto IL_09eb;
						case 53:
							return;
						case 57:
							goto IL_0a1b;
						case 50:
							goto IL_0a9f;
						case 58:
							goto IL_0ace;
						case 49:
							goto IL_0b0f;
						case 17:
							goto IL_0b25;
						case 14:
							return;
						case 36:
							return;
						case 9:
						case 20:
							goto IL_0b87;
						case 18:
							return;
						case 51:
							goto IL_0b9e;
						case 52:
							goto IL_0bc2;
						case 34:
							goto IL_0be8;
						case 8:
							goto IL_0c12;
						case 48:
							return;
						case 26:
							return;
						case 60:
							return;
						}
						break;
					}
					goto IL_015e;
					IL_0487:
					_008A_008B_0097(ref P_0, _008A_008C_008D, _008A_008C_0096, _008A_008C_008E, _008A_008C_0096);
					num = 42;
					goto IL_03f8;
					IL_03f8:
					if (P_0._0088_0090_008A == "out" /* string-offset:1556 */)
					{
						num = 13;
						if (!_0088q())
						{
							goto IL_04c7;
						}
						goto IL_09b5;
					}
					if (P_0._0088_0090_008A == "主区" /* string-offset:3596 */)
					{
						P_0._0088_0090_008A = "中间段主区" /* string-offset:6600 */;
						num = 22;
						goto IL_045d;
					}
					obj = new RnpApchApvObstacle
					{
						X = P_0.X,
						Y = num2,
						Z = P_0.Z
					};
					goto IL_0839;
					IL_09d7:
					P_0._0088_0090_008B += _008A_008C_0094;
					goto IL_09eb;
					IL_09eb:
					if (P_0._0088_0090_008C > 0.0)
					{
						_008A_008B_009C(ref P_0);
					}
					else
					{
						P_0._0088_0090_008D *= _008A_008C_0098;
					}
					return;
					IL_0b0f:
					P_0._0088_0090_008C = P_0.Z - P_0._0088_0090_008B;
					goto IL_0b25;
					IL_045d:
					P_0._0088_0090_008D = 150.0;
					P_0._0088_0090_008B = _008A_008C_0093 - P_0._0088_0090_008D;
					goto IL_0266;
					IL_0b25:
					P_0._0088_0090_008B += _008A_008C_0094;
					if (P_0._0088_0090_008C > 0.0)
					{
						_008A_008B_009C(ref P_0);
						return;
					}
					P_0._0088_0090_008D *= _008A_008C_0098;
					num = 36;
					return;
					IL_0839:
					obj2 = new TemplatePoint
					{
						X = _008A_008C_008D.X,
						Y = _008A_008C_008D.Y,
						Z = _008A_008C_008E.Z
					};
					num = 3;
					goto IL_087b;
					IL_087b:
					_008A_008B_0097(ref obj, obj2, 150.0, _008A_008C_008E, 150.0);
					goto IL_089c;
					IL_089c:
					if (obj._0088_0090_008B < P_0._0088_0090_008B)
					{
						P_0._0088_0090_008A = "中间段副区" /* string-offset:6604 */;
						P_0._0088_0090_008D *= 150.0;
						P_0._0088_0090_008B = _008A_008C_0093 - P_0._0088_0090_008D;
						num = 37;
						goto IL_09b5;
					}
					P_0._0088_0090_008A = "最后段副区" /* string-offset:6608 */;
					num = 38;
					goto IL_0910;
					IL_0ace:
					if (P_0._0088_0090_008A != "out" /* string-offset:1556 */)
					{
						P_0._0088_0090_008A = "最后段" /* string-offset:6612 */ + P_0._0088_0090_008A;
						num = 49;
						goto IL_0b0f;
					}
					return;
					IL_06be:
					_008A_008B_0097(ref P_0, _008A_008C_008F, _008A_008C_0096, _008A_008C_0088, 30.0);
					num = 51;
					goto IL_0b9e;
					IL_0910:
					P_0._0088_0090_008C = P_0.Z - P_0._0088_0090_008B;
					if (P_0._0088_0090_008C > 0.0)
					{
						num = 16;
						goto IL_0941;
					}
					P_0._0088_0090_008D *= _008A_008C_0098;
					return;
					IL_0b9e:
					if (P_0._0088_0090_008A != "out" /* string-offset:1556 */)
					{
						num = 52;
						goto IL_0bc2;
					}
					return;
					IL_0941:
					_008A_008B_009C(ref P_0);
					num = 7;
					return;
					IL_0196:
					_008A_008B_0097(ref P_0, _008A_008C_0087, _008A_008C_0096, _008A_008C_008F, _008A_008C_0096);
					num = 44;
					goto IL_01be;
					IL_0357:
					_008A_008B_0097(ref P_0, _008A_008B_009D, 150.0, _008A_008B_009E, 150.0);
					if (!(P_0._0088_0090_008A == "out" /* string-offset:1556 */))
					{
						P_0._0088_0090_008A = "中间段" /* string-offset:6596 */ + P_0._0088_0090_008A;
						P_0._0088_0090_008D *= 150.0;
						P_0._0088_0090_008B = _008A_008C_0093 - P_0._0088_0090_008D;
						num = 41;
						if (_0088p())
						{
							goto IL_04c7;
						}
						goto IL_0b0f;
					}
					return;
					continue;
					end_IL_05d6:
					break;
				}
			}
		}

// R6 MethodDef: original 0x060005F0 RVA 0xB57AC; processed 0x060005EF RVA 0x8688C; source 03_recovered-src\annotated-strings\--\--.cs:73044; processed IL recovery, not original runtime.
private void _008A_008B_0097(ref RnpApchApvObstacle P_0, TemplatePoint P_1, double P_2, TemplatePoint P_3, double P_4)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			if (!true /* original-file-bool-offset:1264 */)
			{
				return;
			}
			// IL local hoisted
			if (!(P_0.X > Math.Max(P_1.X, P_3.X)))
			{
				if (!(P_0.X < Math.Min(P_1.X, P_3.X)))
				{
					P_0._0088_0090_008A = "out" /* string-offset:1556 */;
					num = Math.Abs(P_0.Y);
					goto IL_015c;
				}
				if (!_0088p())
				{
					goto IL_0144;
				}
			}
			RecoveryMessages.Show("数据范围有误" /* string-offset:6624 */);
			/* opaque discard 0 */
			if (_0088p())
			{
				return;
			}
			goto IL_01a9;
			IL_0144:
			P_0._0088_0090_008A = "主区" /* string-offset:3596 */;
			if (_0088p())
			{
				return;
			}
			goto IL_015c;
			IL_015c:
			if (num > Math.Max(P_1.Y, P_3.Y))
			{
				return;
			}
			num2 = _008A_008B_0098(P_1.X, P_1.Z, P_3.X, P_3.Z, P_0.X);
			num3 = _008A_008B_0098(P_1.X, P_1.Y, P_3.X, P_3.Y, P_0.X);
			while (!(num <= num3 / 2.0))
			{
				if (num <= num3)
				{
					num4 = _008A_008B_0098(P_1.X, P_2, P_3.X, P_4, P_0.X);
					P_0._0088_0090_008B = num2 + _008A_008B_0098(num3 / 2.0, 0.0, num3, num4, num);
					if (_0088q())
					{
						continue;
					}
					goto IL_0176;
				}
				return;
			}
			P_0._0088_0090_008B = num2;
			P_0._0088_0090_008D = 1.0;
			goto IL_0144;
			IL_01a9:
			P_0._0088_0090_008A = "副区" /* string-offset:3600 */;
			return;
			IL_0176:
			P_0._0088_0090_008D = 2.0 * (num3 - num) / num3;
			goto IL_01a9;
		}

// R6 MethodDef: original 0x060005F1 RVA 0xB5A70; processed 0x060005F0 RVA 0x51F5; source 03_recovered-src\annotated-strings\--\--.cs:73110; processed IL recovery, not original runtime.
private double _008A_008B_0098(double P_0, double P_1, double P_2, double P_3, double P_4)
		{

			if (P_2 == P_0)
			{
				return Math.Min(P_1, P_3);
			}
			return (P_3 - P_1) * (P_4 - P_0) / (P_2 - P_0) + P_1;
		}

// R6 MethodDef: original 0x060005F2 RVA 0xB5A98; processed 0x060005F1 RVA 0x86A54; source 03_recovered-src\annotated-strings\--\--.cs:73119; processed IL recovery, not original runtime.
public static double _008A_008B_0099(string P_0)
		{
			double result = default(double); // IL InitLocals

			/* opaque discard 1 */
			// IL local hoisted
			if (!_0088q())
			{
				result = -1400.0;
				if (!(P_0 == "A" /* string-offset:2324 */))
				{
					if (!(P_0 == "B" /* string-offset:2328 */))
					{
						if (!(P_0 == "C" /* string-offset:2084 */))
						{
							goto IL_007c;
						}
						result = -1100.0;
						if (_0088p())
						{
						}
					}
					else
					{
						result = -900.0;
					}
				}
				else
				{
					result = -900.0;
				}
			}
			else if (!_0088q())
			{
				goto IL_007c;
			}
			goto IL_0098;
			IL_0098:
			return result;
			IL_007c:
			if (P_0 == "D" /* string-offset:1644 */)
			{
				result = -1400.0;
			}
			goto IL_0098;
		}

// R6 MethodDef: original 0x060005F3 RVA 0xB5C0C; processed 0x060005F2 RVA 0x86AFC; source 03_recovered-src\annotated-strings\--\--.cs:73164; processed IL recovery, not original runtime.
public static double _008A_008B_009A(string P_0, double P_1, double P_2)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			double[,] array = default(double[,]);
			// IL local hoisted
			if (!false /* original-file-bool-offset:1268 */)
			{
				array = new double[5, 2]
				{
					{ 35.0, 8.0 },
					{ 40.0, 13.0 },
					{ 43.0, 18.0 },
					{ 46.0, 22.0 },
					{ 49.0, 26.0 }
				};
				num = 4;
				_0088q();
				if (!_0088p())
				{
					goto IL_00aa;
				}
				if (_0088p())
				{
					if (!(P_0 == "H" /* string-offset:2320 */))
					{
						if (!(P_0 == "A" /* string-offset:2324 */))
						{
							if (!(P_0 == "B" /* string-offset:2328 */))
							{
								if (!(P_0 == "C" /* string-offset:2084 */))
								{
									if (P_0 == "D" /* string-offset:1644 */)
									{
										num = 4;
									}
								}
								else
								{
									num = 3;
								}
							}
							else
							{
								num = 2;
							}
						}
						else
						{
							num = 1;
						}
					}
					else
					{
						num = 0;
					}
				}
			}
			goto IL_00cb;
			IL_00ed:
			// IL local hoisted
			// IL local hoisted
			if (P_2 > 3.2)
			{
				num2 += (P_2 - 3.2) * num3 * 0.05;
			}
			return num2;
			IL_00cb:
			num4 = array[num, 0];
			num3 = array[num, 1];
			num2 = num4;
			if (!(P_1 <= 900.0))
			{
				goto IL_00aa;
			}
			goto IL_00ed;
			IL_00aa:
			num2 += num3 * 0.02 * P_1 / 300.0;
			if (!_0088p())
			{
				goto IL_00cb;
			}
			goto IL_00ed;
		}

// R6 MethodDef: original 0x060005F4 RVA 0xB5E70; processed 0x060005F3 RVA 0x86C20; source 03_recovered-src\annotated-strings\--\--.cs:73247; processed IL recovery, not original runtime.
public static double _008A_008B_009B(double P_0, double P_1, double P_2)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			num = P_1 - 15.0 + P_0 * 0.0065;
			num2 = -0.0065;
			num3 = 288.15;
			return (0.0 - num / num2) * Math.Log(1.0 + num2 * P_2 / (num3 + num2 * P_0));
		}

// R6 MethodDef: original 0x060005F5 RVA 0xB5ECC; processed 0x060005F4 RVA 0x86C74; source 03_recovered-src\annotated-strings\--\--.cs:73255; processed IL recovery, not original runtime.
private void _008A_008B_009C(ref RnpApchApvObstacle P_0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:1272 */)
			{
				return;
			}
			num = P_0.Z;
			num2 = 1.0 / _008A_008C_0095;
			num3 = 1.0 / _008A_008C_0091;
			// IL local hoisted
			if (P_0._0088_0090_008D == 1.0)
			{
				P_0._0088_0090_008D *= _008A_008C_0098;
				if (!(P_0.X < _008A_008C_0097) && num <= (P_0.X - _008A_008C_0097) * _008A_008C_0095)
				{
					P_0._0088_0090_0090 = P_0.Z + P_0._0088_0090_008D;
					return;
				}
				P_0._0088_0090_008E = Math.Ceiling((num * num3 + P_0.X - _008A_008C_0097) / (num2 + num3));
				P_0._0088_0090_0090 = P_0._0088_0090_008E + P_0._0088_0090_008D;
				/* opaque discard 0 */
				if (_0088p())
				{
					return;
				}
			}
			else
			{
				num4 = 30.0 * (1.0 - P_0._0088_0090_008D);
			}
			if (!(P_0.X < _008A_008C_0097) && num <= (P_0.X - _008A_008C_0097) * _008A_008C_0095 + num4)
			{
				P_0._0088_0090_008D *= _008A_008C_0098;
				P_0._0088_0090_0090 = P_0.Z + P_0._0088_0090_008D;
				return;
			}
			do
			{
				P_0._0088_0090_008E = Math.Ceiling(((num - num4) * num3 + P_0.X - _008A_008C_0097) / (num2 + num3));
				P_0._0088_0090_008D = _008A_008C_0098;
				if (!_0088q())
				{
					P_0._0088_0090_0090 = P_0._0088_0090_008E + P_0._0088_0090_008D;
					continue;
				}
				break;
			}
			while (!_0088p());
		}

// R6 MethodDef: original 0x060005F6 RVA 0xB61A0; processed 0x060005F5 RVA 0x5213; source 03_recovered-src/annotated-strings/--/--.cs:73305; processed IL recovery, not original runtime.
static RnpApchApv()
		{

			// Host licensing not executed.
		}

// R6 MethodDef: original 0x060005F7 RVA 0xB61BC; processed 0x060005F6 RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:73310; processed IL recovery, not original runtime.
internal static bool _0088p()
		{

			return true;
		}

// R6 MethodDef: original 0x060005F8 RVA 0xB61C8; processed 0x060005F7 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:73315; processed IL recovery, not original runtime.
internal static bool _0088q()
		{

			return false;
		}
	}
}
