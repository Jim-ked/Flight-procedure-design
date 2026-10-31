using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
// Mechanical recovery of processed source/IL. Original identifiers retained.
// IL locals initialized once at entry. No target assembly or AutoCAD dependency.
namespace Recovered.B5 {
	public class PbnDepartureAltitudeTurn
	{
		public double _008A_0086_0096;

		public double _008A_0086_0097;

		public double _008A_0086_0098;

		public double _008A_0086_0099;

		public double _008A_0086_009A;

		public double _008A_0086_009B;

		public double _008A_0086_009C;

		public double _008A_0086_009D;

		public double _008A_0086_009E;

		public bool _008A_0087_0086;

		private TemplatePoint _008A_0087_0087;

		private TemplatePoint _008A_0087_0088;

		private TemplatePoint _008A_0087_0089;

		private TemplatePoint _008A_0087_008A;

		private TemplatePoint _008A_0087_008B;

		private TemplatePoint _008A_0087_008C;

		private TemplatePoint _008A_0087_008D;

		private TemplatePoint _008A_0087_008E;

		private TemplatePoint _008A_0087_008F;

		private TemplatePoint _008A_0087_0090;

		private TemplatePoint _008A_0087_0091;

		public List<TemplatePoint> _008A_0087_0092;

		public List<TemplatePoint> _008A_0087_0093;

		public List<TemplatePoint> _008A_0087_0094;

		public List<TemplatePoint> _008A_0087_0095;

		public List<TemplatePoint> _008A_0087_0096;

		public List<TemplatePoint> _008A_0087_0097;

		public List<TemplatePoint> _008A_0087_0098;

		public List<List<TemplatePoint>> _008A_0087_0099;

		private LineCarrier _008A_0087_009A;

		private LineCarrier _008A_0087_009B;

		private TurnInput _008A_0087_009C;

		private List<TemplatePoint> _008A_0087_009D;

		private List<TemplatePoint> _008A_0087_009E;

		private static double _008A_0088_0086;

		private static double _008A_0088_0087;

// R5 MethodDef: original 0x060005C8 RVA 0xAC188; processed 0x060005C7 RVA 0x7E76C; source :; processed IL recovery, not original runtime.
public PbnDepartureAltitudeTurn()
		{

			_008A_0087_009A = new LineCarrier();
			_0088k();
			if (_0088j())
			{
				goto IL_0038;
			}
			goto IL_005e;
			IL_0038:
			_008A_0087_009B = new LineCarrier();
			goto IL_005e;
			IL_005e:
			// object constructor emitted automatically
			if (!_0088k())
			{
				return;
			}
			goto IL_0038;
		}

// R5 MethodDef: original 0x060005C9 RVA 0xAC270; processed 0x060005C8 RVA 0x7E7E4; source 03_recovered-src/annotated-strings/--/--.cs:68754; processed IL recovery, not original runtime.
public PbnDepartureAltitudeTurn(TurnInput P_0, TemplatePoint P_1, TemplatePoint P_2, TemplatePoint P_3, bool P_4 = true, double P_5 = 0.033, double P_6 = 0.033, bool P_7 = true)
		{
			int num = default(int); // IL InitLocals

			while (true /* original-file-bool-offset:1192 */)
			{
				while (true)
				{
					_008A_0087_009A = new LineCarrier();
					_008A_0087_009B = new LineCarrier();
					while (true)
					{
						// object constructor emitted automatically
						num = 14;
						while (true)
						{
							_008A_0086_0096 = 300.0;
							while (true)
							{
								_008A_0086_0097 = 600.0;
								while (true)
								{
									_008A_0086_0098 = Math.Tan(Math.PI / 12.0);
									_0088k();
									if (_0088j())
									{
										num = 5;
										if (_0088j())
										{
											goto IL_0042;
										}
									}
									goto IL_02f3;
									IL_0042:
									while (true)
									{
										switch (num)
										{
										case 11:
											break;
										default:
											num = 20;
											if (!_0088k())
											{
												continue;
											}
											goto case 0;
										case 7:
											goto IL_00b8;
										case 1:
											goto IL_0113;
										case 16:
											goto IL_01d0;
										case 2:
											goto IL_0210;
										case 23:
											goto IL_024d;
										case 21:
											goto IL_0273;
										case 20:
											goto IL_0299;
										case 12:
											goto IL_02ac;
										case 13:
											goto IL_02b6;
										case 22:
											goto IL_02c0;
										case 5:
										case 6:
											_008A_0087_0099 = new List<List<TemplatePoint>>();
											goto case 9;
										case 9:
											_008A_0087_009C = P_0;
											_008A_0087_008F = P_1;
											goto IL_02f3;
										case 4:
										case 8:
											goto IL_02f3;
										case 24:
											goto end_IL_0006;
										case 14:
											goto end_IL_031b;
										case 3:
											goto end_IL_032f;
										case 19:
											goto end_IL_0340;
										case 10:
											goto end_IL_0351;
										case 17:
											_008A_0087_008B = new TemplatePoint(_008A_0086_009B, Math.Min(_008A_0086_0099, 1852.0), (_008A_0086_009D + 0.008) * _008A_0086_009B + 5.0);
											_008A_0087_008C = new TemplatePoint(_008A_0086_009C, _008A_0086_009A, (_008A_0086_009D + 0.008) * _008A_0086_009C + 5.0);
											_008A_0087_008D = new TemplatePoint(_008A_0086_009C, 1852.0, (_008A_0086_009D + 0.008) * _008A_0086_009C + 5.0);
											num = 18;
											goto case 18;
										case 18:
											_008A_0087_008E = new TemplatePoint(0.0 - TemplatePoint._008B_0088_009E(_008A_0087_008F, _008A_0087_0090) + _008A_0086_0097, _008A_0086_0096 / 2.0);
											_008A_0086_0093();
											_008A_0087_009D = B5Math._008B_0088_0089(PointLists._008B_008A_008D(_008A_0087_0099));
											_008A_0086_0092(P_7, P_4);
											_008A_0086_0090(P_7, P_4);
											goto case 15;
										case 15:
											_008A_0087_009E = B5Math._008B_0088_0089(PointLists._008B_008A_008D(_008A_0087_0099));
											_008A_0087_009A._008B_0088_008E(_008A_0087_0087, _008A_0087_0088);
											num = 0;
											goto case 0;
										case 0:
											if (_008A_0087_008A.X >= 13263.71)
											{
												_008A_0087_009B._008B_0088_008F(_008A_0087_0089, _008A_0087_009A._008B_0088_0094() + Math.PI / 2.0);
											}
											else
											{
												_008A_0087_009B._008B_0088_008F(_008A_0087_008A, _008A_0087_009A._008B_0088_0094() + Math.PI / 2.0);
											}
											return;
										case 25:
											return;
										}
										break;
									}
									continue;
									IL_02f3:
									_008A_0087_0090 = P_2;
									num = 22;
									goto IL_02c0;
									IL_02c0:
									_008A_0087_0091 = P_3;
									num = 13;
									if (_0088k())
									{
										break;
									}
									goto IL_02b6;
									IL_02b6:
									_008A_0086_009D = P_5;
									goto IL_02ac;
									IL_02ac:
									_008A_0086_009E = P_6;
									goto IL_0299;
									IL_0299:
									_008A_0087_0086 = P_7;
									num = 21;
									goto IL_0273;
									IL_0273:
									_008A_0086_009B = (P_0._008A_009D_0096 - P_1.Z - 5.0) / _008A_0086_009D;
									goto IL_024d;
									IL_024d:
									_008A_0086_009C = _008A_0086_009B + (P_0._008A_009D_009A + P_0._008A_009D_0098) / 0.6;
									goto IL_0210;
									IL_0210:
									_008A_0086_0099 = Math.Min(3704.0, _008A_0086_009B * _008A_0086_0098 + _008A_0086_0096 / 2.0);
									num = 16;
									goto IL_01d0;
									IL_01d0:
									_008A_0086_009A = Math.Min(3704.0, _008A_0086_009C * _008A_0086_0098 + _008A_0086_0096 / 2.0);
									num = 1;
									goto IL_0113;
									IL_0113:
									_008A_0087_0087 = new TemplatePoint(0.0, _008A_0086_0096 / 2.0);
									_008A_0087_0088 = new TemplatePoint(6351.95, 1852.0, (_008A_0086_009D + 0.008) * 6531.95 + 5.0);
									_008A_0087_0089 = new TemplatePoint(13263.71, 3704.0, (_008A_0086_009D + 0.008) * 13263.71 + 5.0);
									num = 7;
									goto IL_00b8;
									IL_00b8:
									do
									{
										_008A_0087_008A = new TemplatePoint(_008A_0086_009B, Math.Min(_008A_0086_0099, 3704.0), (_008A_0086_009D + 0.008) * _008A_0086_009B + 5.0);
										num = 17;
									}
									while (_0088k());
									goto IL_0042;
									continue;
									end_IL_0006:
									break;
								}
								continue;
								end_IL_031b:
								break;
							}
							continue;
							end_IL_032f:
							break;
						}
						continue;
						end_IL_0340:
						break;
					}
					continue;
					end_IL_0351:
					break;
				}
			}
		}

// R5 MethodDef: original 0x060005CA RVA 0xAC87C; processed 0x060005C9 RVA 0x7ED6C; source 03_recovered-src\annotated-strings\--\--.cs:68947; processed IL recovery, not original runtime.
private void _008A_0086_0090(bool P_0, bool P_1)
		{
			int num = default(int); // IL InitLocals
			TemplatePoint obj5 = default(TemplatePoint); // IL InitLocals
			Spiral86 obj6 = default(Spiral86); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			TemplatePoint obj7 = default(TemplatePoint); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			Spiral86 obj8 = default(Spiral86); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals
			List<TemplatePoint> item2 = default(List<TemplatePoint>); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			TemplatePoint obj9 = default(TemplatePoint); // IL InitLocals
			double num9 = default(double); // IL InitLocals
			TemplatePoint obj10 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj11 = default(TemplatePoint); // IL InitLocals
			Spiral86 obj12 = default(Spiral86); // IL InitLocals
			double num10 = default(double); // IL InitLocals
			Spiral86 obj13 = default(Spiral86); // IL InitLocals
			double num11 = default(double); // IL InitLocals
			double num12 = default(double); // IL InitLocals
			double num13 = default(double); // IL InitLocals
			double num14 = default(double); // IL InitLocals
			double num16 = default(double); // IL InitLocals
			double num17 = default(double); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			RunwayFrame obj = default(RunwayFrame); // IL InitLocals
			RunwayFrame obj2 = default(RunwayFrame); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj4 = default(TemplatePoint); // IL InitLocals
			double num15 = default(double); // IL InitLocals

			num = 18;
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
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (true /* original-file-bool-offset:1196 */)
			{
				while (true)
				{
					IL_09ec:
					// IL local hoisted
					if (P_1)
					{
						num2 = 1;
						goto IL_09d4;
					}
					num = 32;
					goto IL_09d3;
					IL_09d4:
					num3 = num2;
					num = 35;
					while (true)
					{
						obj = FrameHelpers._0089_008F(_008A_0087_0090, _008A_0087_008F);
						num = 26;
						while (true)
						{
							obj2 = FrameHelpers._0089_008F(_008A_0087_008F, _008A_0087_0091);
							obj3 = new TemplatePoint(obj2._008A_009D_0088 * Math.Cos(obj2._008A_009D_0089 - obj._008A_009D_0089), obj2._008A_009D_0088 * Math.Sin(obj2._008A_009D_0089 - obj._008A_009D_0089));
							while (true)
							{
								obj4 = new TemplatePoint(_008A_0086_009C, 0.0);
								/* opaque discard 1 */
								if (_0088k())
								{
									goto IL_0925;
								}
								goto IL_0386;
								IL_0386:
								obj5 = TemplatePoint._008B_0089_0088(obj4, TemplatePoint._008B_0089_0087(_008A_0087_009C._008A_009D_009D - 1852.0, 0.0 + num3 * _008A_0088_0087));
								goto IL_032e;
								IL_032e:
								obj6 = new Spiral86(_008A_0087_009C, obj5, 0.0 - num3 * _008A_0088_0087, 0.0, P_1);
								num4 = _008A_0087_008C.Y - _008A_0087_008D.Y;
								num = 22;
								if (!_0088k())
								{
									goto IL_0305;
								}
								goto IL_0819;
								IL_0305:
								obj7 = new TemplatePoint(0.0, num3 * 1852.0);
								goto IL_01d8;
								IL_01d8:
								new LineCarrier()._008B_0088_008F(obj7, 0.0);
								num = 9;
								goto IL_0211;
								IL_0211:
								obj6._008A_009E_0098(0.0, num4, out num5, out num6);
								num = 12;
								if (!_0088k())
								{
									goto IL_023a;
								}
								goto IL_05e8;
								IL_05e8:
								_008A_0086_0091(obj8, num7, obj3, num6, num3, ref item, ref item2);
								goto IL_05c3;
								IL_05c3:
								_008A_0087_0099.Add(item);
								num = 16;
								if (!_0088j())
								{
									goto IL_0080;
								}
								goto IL_03c8;
								IL_03c8:
								switch (num)
								{
								case 3:
									break;
								case 21:
									goto IL_0044;
								case 5:
									goto IL_0080;
								case 39:
									goto IL_00e1;
								case 8:
									goto IL_0131;
								case 15:
									goto IL_0154;
								case 36:
									goto IL_0170;
								case 29:
									goto IL_01d8;
								case 9:
									goto IL_0211;
								case 12:
									goto IL_023a;
								case 1:
									goto IL_0260;
								case 27:
									goto IL_02c3;
								case 22:
									goto IL_0305;
								case 13:
									goto IL_032e;
								case 6:
								case 7:
									goto IL_0386;
								default:
									num = 0;
									goto IL_0572;
								case 20:
									goto IL_0487;
								case 19:
									goto IL_0548;
								case 0:
									goto IL_0572;
								case 2:
									goto IL_05a8;
								case 11:
								case 30:
								case 34:
									goto IL_05c3;
								case 17:
									goto IL_05e8;
								case 40:
									goto IL_05fc;
								case 14:
									goto IL_0654;
								case 38:
									goto IL_06b1;
								case 4:
									goto IL_06e6;
								case 25:
									goto IL_0774;
								case 33:
									goto IL_07bc;
								case 24:
									goto IL_0819;
								case 10:
									goto IL_08f1;
								case 28:
								case 31:
								case 37:
									goto IL_0925;
								case 26:
									goto end_IL_0014;
								case 35:
									goto end_IL_095e;
								case 32:
									goto end_IL_09b6;
								case 23:
									goto IL_09ec;
								case 18:
									goto end_IL_09ec;
								case 16:
									_008A_0087_0099.Add(item2);
									num = 41;
									return;
								case 41:
									return;
								}
								continue;
								IL_023a:
								num8 = obj6._008A_009E_009B(obj3);
								num = 1;
								if (!_0088k())
								{
									goto IL_0260;
								}
								goto IL_0487;
								IL_0260:
								if (num8 - _008A_0087_009C._008A_009E_0086 > _008A_0088_0087)
								{
									obj9 = TemplatePoint._008B_0089_0088(obj4, TemplatePoint._008B_0089_0087(_008A_0087_009C._008A_009D_009D + 1852.0, 0.0 + num3 * _008A_0088_0087));
									num = 39;
									goto IL_00e1;
								}
								num = 5;
								goto IL_0080;
								IL_0925:
								num9 = Math.Atan2(obj10.Y - obj11.Y, obj10.X - obj11.X);
								num = 21;
								goto IL_0044;
								IL_05a8:
								_008A_0086_0091(obj12, num10, obj3, num6, num3, ref item, ref item2);
								num = 34;
								goto IL_05c3;
								IL_0487:
								PointLists._008B_008B_0087(ref item2, obj13._008A_009E_0091(num11, num12 - _008A_0088_0086, num4));
								_008A_0086_0091(obj13, num12, obj3, num6, num3, ref item, ref item2);
								num = 11;
								goto IL_05c3;
								IL_00e1:
								obj12 = new Spiral86(_008A_0087_009C, obj9, 0.0 - num3 * _008A_0088_0087, 0.0, P_1);
								num13 = _008A_0088_0087 + _008A_0087_009C._008A_009E_0086;
								num = 8;
								if (!_0088k())
								{
									goto IL_0131;
								}
								goto IL_05a8;
								IL_0131:
								num10 = obj12._008A_009E_009B(obj3);
								num14 = num10 - _008A_0087_009C._008A_009E_0086;
								goto IL_0154;
								IL_0154:
								if (num14 <= _008A_0088_0087 + _008A_0088_0086)
								{
									num8 = num10 - _008A_0088_0086;
									goto IL_0170;
								}
								num8 = _008A_0088_0087 + _008A_0087_009C._008A_009E_0086;
								item = obj6._008A_009E_0091(0.0, num8);
								item2 = obj6._008A_009E_0091(num5, num8, num6);
								if (num14 < Math.PI + _008A_0088_0086)
								{
									num = 19;
									goto IL_0548;
								}
								PointLists._008B_008B_0087(ref item, obj12._008A_009E_0091(_008A_0088_0087 + _008A_0087_009C._008A_009E_0086, Math.PI + _008A_0087_009C._008A_009E_0086));
								goto IL_0774;
								IL_0044:
								num9 += ((!P_1) ? (_008A_0088_0087 - _008A_0087_009C._008A_009E_0086) : (_008A_0087_009C._008A_009E_0086 - _008A_0088_0087));
								num = 4;
								goto IL_06e6;
								IL_0170:
								item = obj6._008A_009E_0091(0.0, num8);
								item2 = obj6._008A_009E_0091(num5, num8, num6);
								_008A_0086_0091(obj6, num8, obj3, num6, num3, ref item, ref item2);
								num = 30;
								if (_0088j())
								{
									goto IL_03c8;
								}
								goto IL_0654;
								IL_0080:
								item = obj6._008A_009E_0091(0.0, num8 - _008A_0088_0086);
								item2 = obj6._008A_009E_0091(num5, num8 - _008A_0088_0086, num6);
								_008A_0086_0091(obj6, num8, obj3, num6, num3, ref item, ref item2);
								goto IL_05c3;
								IL_0654:
								PointLists._008B_008B_0087(ref item, obj13._008A_009E_0091(num11, num12));
								PointLists._008B_008B_0087(ref item2, obj13._008A_009E_0091(num11, num12, num4));
								num = 40;
								goto IL_05fc;
								IL_0548:
								PointLists._008B_008B_0087(ref item, obj12._008A_009E_0091(num13, num10 - _008A_0088_0086));
								goto IL_0572;
								IL_0572:
								PointLists._008B_008B_0087(ref item2, obj12._008A_009E_0091(num13, num10 - _008A_0088_0086, num6));
								num = 2;
								if (_0088k())
								{
									break;
								}
								goto IL_05a8;
								IL_02c3:
								PointLists._008B_008B_0087(ref item, obj13._008A_009E_0091(num11, num12 - _008A_0088_0086));
								num = 20;
								if (_0088j())
								{
									goto IL_03c8;
								}
								goto IL_05c3;
								IL_0774:
								PointLists._008B_008B_0087(ref item2, obj12._008A_009E_0091(_008A_0088_0087 + _008A_0087_009C._008A_009E_0086, Math.PI + _008A_0087_009C._008A_009E_0086, num6));
								num = 33;
								goto IL_07bc;
								IL_07bc:
								obj11 = TemplatePoint._008B_0089_0088(new TemplatePoint(_008A_0087_0088.X, 0.0), TemplatePoint._008B_0089_0087(_008A_0087_009C._008A_009D_009D + 1852.0, 0.0 + num3 * _008A_0088_0087));
								goto IL_0819;
								IL_0819:
								obj13 = new Spiral86(_008A_0087_009C, obj11, 0.0 - num3 * _008A_0088_0087, 0.0, P_1);
								obj10 = TemplatePoint._008B_0089_0088(P_0 ? new TemplatePoint(_008A_0087_008E.X, 0.0) : new TemplatePoint(_008A_0087_0087.X, 0.0), TemplatePoint._008B_0089_0087(_008A_0087_009C._008A_009D_009D + 150.0, 0.0 + num3 * _008A_0088_0087));
								obj8 = new Spiral86(_008A_0087_009C, obj10, 0.0 - num3 * _008A_0088_0087, 0.0, P_1);
								goto IL_08f1;
								IL_06b1:
								num15 = Math.Atan2(obj11.Y - obj10.Y, obj11.X - obj10.X);
								if (!(num12 + num3 * num15 >= num7))
								{
									num12 = num16;
									num = 14;
									goto IL_0654;
								}
								num = 27;
								goto IL_02c3;
								IL_05fc:
								PointLists._008B_008B_0087(ref item, obj8._008A_009E_0091(num17, num7 - _008A_0088_0086));
								PointLists._008B_008B_0087(ref item2, obj8._008A_009E_0091(num17, num7 - _008A_0088_0086, num4));
								num = 17;
								goto IL_05e8;
								IL_06e6:
								num16 = obj13._008A_009E_0096(Spiral86._008A_009E_0090(num9));
								num17 = num16;
								num7 = obj8._008A_009E_009B(obj3);
								num = 38;
								goto IL_06b1;
								IL_08f1:
								num11 = Math.PI + _008A_0087_009C._008A_009E_0086;
								num12 = obj13._008A_009E_009B(obj3);
								obj13._008A_009E_009D(obj8);
								goto IL_0925;
								continue;
								end_IL_0014:
								break;
							}
							continue;
							end_IL_095e:
							break;
						}
						continue;
						end_IL_09b6:
						break;
					}
					goto IL_09d3;
					IL_09d3:
					num2 = -1;
					goto IL_09d4;
					continue;
					end_IL_09ec:
					break;
				}
			}
		}

// R5 MethodDef: original 0x060005CB RVA 0xAD34C; processed 0x060005CA RVA 0x7F794; source 03_recovered-src\annotated-strings\--\--.cs:69297; processed IL recovery, not original runtime.
private void _008A_0086_0091(Spiral86 P_0, double P_1, TemplatePoint P_2, double P_3, double P_4, ref List<TemplatePoint> P_5, ref List<TemplatePoint> P_6)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			LineCarrier obj2 = default(LineCarrier); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			LineCarrier obj4 = default(LineCarrier); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			TemplatePoint obj5 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj6 = default(TemplatePoint); // IL InitLocals
			LineCarrier obj7 = default(LineCarrier); // IL InitLocals
			LineCarrier obj8 = default(LineCarrier); // IL InitLocals
			TemplatePoint obj11 = default(TemplatePoint); // IL InitLocals
			LineCarrier obj9 = default(LineCarrier); // IL InitLocals
			TemplatePoint obj10 = default(TemplatePoint); // IL InitLocals
			TemplatePoint item = default(TemplatePoint); // IL InitLocals
			TemplatePoint item2 = default(TemplatePoint); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			if (!true /* original-file-bool-offset:1200 */)
			{
				return;
			}
			obj = P_0._008A_009E_0093(P_1 - _008A_0088_0086);
			num = P_4 * (P_1 - _008A_0088_0086 - _008A_0087_009C._008A_009E_0086 + _008A_0088_0087) + P_0._008B_0086_0088;
			num2 = P_0._008A_009E_0095(P_1 - _008A_0088_0086);
			num3 = TemplatePoint._008B_0088_009E(P_2, P_0._008B_0086_008A);
			// IL local hoisted
			if (num2 > num3)
			{
				if (_0088j())
				{
					return;
				}
			}
			else
			{
				obj2 = new LineCarrier();
			}
			obj2._008B_0088_008F(obj, num);
			obj3 = P_0._008A_009E_0093(P_1 - _008A_0088_0086, P_3);
			obj4 = new LineCarrier();
			obj4._008B_0088_008F(obj3, num);
			num4 = P_4 * (P_1 - _008A_0087_009C._008A_009E_0086 + _008A_0088_0087) + P_0._008B_0086_0088;
			obj5 = new TemplatePoint(1852.0 * Math.Cos(num4 - P_4 * _008A_0088_0087) + P_2.X, 1852.0 * Math.Sin(num4 - P_4 * _008A_0088_0087) + P_2.Y);
			obj6 = new TemplatePoint(3704.0 * Math.Cos(num4 - P_4 * _008A_0088_0087) + P_2.X, 3704.0 * Math.Sin(num4 - P_4 * _008A_0088_0087) + P_2.Y);
			obj7 = new LineCarrier();
			obj8 = new LineCarrier();
			/* opaque discard 1 */
			// IL local hoisted
			if (!_0088k())
			{
				obj9 = new LineCarrier();
				obj7._008B_0088_008F(obj5, num4);
				obj8._008B_0088_008F(obj6, num4);
				obj9._008B_0088_008F(P_2, num4 + P_4 * _008A_0088_0087);
				obj10 = obj9._008B_0088_0093(obj2);
				obj11 = obj9._008B_0088_0093(obj4);
				item = obj7._008B_0088_0093(obj2);
				item2 = obj8._008B_0088_0093(obj4);
				num5 = TemplatePoint._008B_0088_009E(obj10, P_2);
				num6 = TemplatePoint._008B_0088_009E(obj11, P_2);
				if (!(num5 <= 1852.0) || !(num6 <= 3704.0))
				{
					if (num6 <= 3704.0)
					{
						P_5.Add(item);
						P_5.Add(obj5);
						P_6.Add(obj11);
					}
					else
					{
						P_5.Add(item);
						P_5.Add(obj5);
						P_6.Add(item2);
						P_6.Add(obj6);
					}
					goto IL_02f7;
				}
				P_5.Add(obj10);
			}
			P_6.Add(obj11);
			goto IL_02f7;
			IL_02f7:
			P_6.Add(P_2);
		}

// R5 MethodDef: original 0x060005CC RVA 0xAD7E0; processed 0x060005CB RVA 0x7FAA4; source 03_recovered-src\annotated-strings\--\--.cs:69367; processed IL recovery, not original runtime.
public void _008A_0086_0092(bool P_0, bool P_1)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			RunwayFrame obj2 = default(RunwayFrame); // IL InitLocals
			RunwayFrame obj4 = default(RunwayFrame); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			RunwayFrame obj5 = default(RunwayFrame); // IL InitLocals
			RunwayFrame obj6 = default(RunwayFrame); // IL InitLocals
			double num = default(double); // IL InitLocals
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals

			if (!true /* original-file-bool-offset:1204 */)
			{
				return;
			}
			// IL local hoisted
			if (!P_0)
			{
				obj = _008A_0087_0087;
				_0088k();
				if (_0088j())
				{
					goto IL_00f6;
				}
				if (!_0088k())
				{
					goto IL_0108;
				}
			}
			List<TemplatePoint> item = new List<TemplatePoint>
			{
				new TemplatePoint(0.0, _008A_0086_0096 / 2.0),
				new TemplatePoint(0.0, (0.0 - _008A_0086_0096) / 2.0),
				TemplatePoint._008B_0089_008B(_008A_0087_008E),
				_008A_0087_008E,
				new TemplatePoint(0.0, _008A_0086_0096 / 2.0)
			};
			_008A_0087_0099.Add(item);
			obj = _008A_0087_008E;
			goto IL_00f6;
			IL_0108:
			obj2 = FrameHelpers._0089_008F(_008A_0087_008F, _008A_0087_0091);
			// IL local hoisted
			obj3 = new TemplatePoint(obj2._008A_009D_0088 * Math.Cos(obj2._008A_009D_0089 - obj4._008A_009D_0089), obj2._008A_009D_0088 * Math.Sin(obj2._008A_009D_0089 - obj4._008A_009D_0089));
			obj5 = FrameHelpers._0089_008F(obj, obj3);
			obj6 = FrameHelpers._0089_008F(TemplatePoint._008B_0089_008B(obj), obj3);
			obj5._008A_009D_0089 = Math.Abs(obj5._008A_009D_0089);
			obj6._008A_009D_0089 = Math.Abs(obj6._008A_009D_0089);
			if (P_1)
			{
				if (obj6._008A_009D_0089 > B5Math._008B_0087_009A(75.0))
				{
					obj = TemplatePoint._008B_0089_008B(obj);
				}
			}
			else if (!(obj5._008A_009D_0089 > B5Math._008B_0087_009A(75.0)))
			{
				obj = TemplatePoint._008B_0089_008B(obj);
			}
			num = TemplatePoint._008B_0088_009E(obj, obj3);
			list = PointLists._008B_008A_0094(new StartArea(num, P_1)._0089_009B_0095, new TemplatePoint(0.0, 0.0), Math.Atan2(obj3.Y - obj.Y, obj3.X - obj.X)) /* P5CB IL_01DA-022F stack order */;
			list = PointLists._008B_008A_0096(list, obj);
			PointLists._008B_008B_0086(ref _008A_0087_0099, list);
			return;
			IL_00f6:
			obj4 = FrameHelpers._0089_008F(_008A_0087_0090, _008A_0087_008F);
			goto IL_0108;
		}

// R5 MethodDef: original 0x060005CD RVA 0xADB6C; processed 0x060005CC RVA 0x7FD00; source 03_recovered-src\annotated-strings\--\--.cs:69427; processed IL recovery, not original runtime.
private void _008A_0086_0093()
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			int num = default(int); // IL InitLocals

			// IL local hoisted
			while (true /* original-file-bool-offset:1208 */)
			{
				while (true)
				{
					// IL local hoisted
					if (!(_008A_0086_009C < 6351.95))
					{
						if (_008A_0086_009B < 6351.95)
						{
							obj = new TemplatePoint(_008A_0086_009B, _008A_0086_0099, (_008A_0086_009D + 0.008) * _008A_0086_009B + 5.0);
							num = 11;
							goto IL_0384;
						}
						if (_008A_0086_009B >= 6351.95)
						{
							num = 13;
							goto IL_03d9;
						}
						goto IL_05b2;
					}
					num = 10;
					goto IL_0605;
					IL_0305:
					_008A_0087_0094 = new List<TemplatePoint>
					{
						TemplatePoint._008B_0089_008B(_008A_0087_0088),
						TemplatePoint._008B_0089_008B(_008A_0087_008A),
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						TemplatePoint._008B_0089_008B(_008A_0087_0088)
					};
					num = 3;
					if (_0088j())
					{
						goto IL_00d4;
					}
					goto IL_0146;
					IL_0146:
					_008A_0087_0095 = new List<TemplatePoint>
					{
						obj,
						_008A_0087_0088,
						_008A_0087_008D,
						TemplatePoint._008B_0089_008B(_008A_0087_008D),
						TemplatePoint._008B_0089_008B(_008A_0087_0088),
						TemplatePoint._008B_0089_008B(obj),
						obj
					};
					_008A_0087_0096 = new List<TemplatePoint> { _008A_0087_0088, _008A_0087_008C, _008A_0087_008D, _008A_0087_0088 };
					_008A_0087_0097 = new List<TemplatePoint>
					{
						TemplatePoint._008B_0089_008B(_008A_0087_0088),
						TemplatePoint._008B_0089_008B(_008A_0087_008C),
						TemplatePoint._008B_0089_008B(_008A_0087_008D),
						TemplatePoint._008B_0089_008B(_008A_0087_0088)
					};
					/* opaque discard 1 */
					if (!_0088k())
					{
						num = 23;
						if (_0088j())
						{
							goto IL_00d4;
						}
						goto IL_0a86;
					}
					num = 21;
					goto IL_03fc;
					IL_095f:
					_008A_0087_0095 = new List<TemplatePoint>
					{
						_008A_0087_008D,
						TemplatePoint._008B_0089_008B(_008A_0087_008D),
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						_008A_0087_008B,
						_008A_0087_008D
					};
					num = 4;
					goto IL_09b9;
					IL_09b9:
					_008A_0087_0096 = new List<TemplatePoint> { _008A_0087_008A, _008A_0087_0089, _008A_0087_008C, _008A_0087_008D, _008A_0087_008B, _008A_0087_008A };
					_008A_0087_0097 = new List<TemplatePoint>
					{
						TemplatePoint._008B_0089_008B(_008A_0087_008A),
						TemplatePoint._008B_0089_008B(_008A_0087_0089),
						TemplatePoint._008B_0089_008B(_008A_0087_008C),
						TemplatePoint._008B_0089_008B(_008A_0087_008D),
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						TemplatePoint._008B_0089_008B(_008A_0087_008A)
					};
					num = 6;
					goto IL_0a86;
					IL_057a:
					if (_008A_0086_009C <= 13263.71)
					{
						goto IL_058e;
					}
					_008A_0087_0092 = new List<TemplatePoint>
					{
						_008A_0087_0087,
						_008A_0087_0088,
						_008A_0087_008B,
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						TemplatePoint._008B_0089_008B(_008A_0087_0088),
						TemplatePoint._008B_0089_008B(_008A_0087_0087),
						_008A_0087_0087
					};
					num = 17;
					goto IL_08d5;
					IL_05b2:
					if (_008A_0086_009B < 13263.71)
					{
						num = 14;
						goto IL_057a;
					}
					goto IL_058e;
					IL_0a86:
					_008A_0087_0099 = new List<List<TemplatePoint>> { _008A_0087_0092, _008A_0087_0093, _008A_0087_0094, _008A_0087_0095, _008A_0087_0096, _008A_0087_0097 };
					return;
					IL_058e:
					if (_008A_0086_009B >= 13263.71)
					{
						goto IL_03fc;
					}
					return;
					IL_03fc:
					_008A_0087_0092 = new List<TemplatePoint>
					{
						_008A_0087_0087,
						_008A_0087_0088,
						_008A_0087_008B,
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						TemplatePoint._008B_0089_008B(_008A_0087_0088),
						TemplatePoint._008B_0089_008B(_008A_0087_0087),
						_008A_0087_0087
					};
					_008A_0087_0093 = new List<TemplatePoint> { _008A_0087_0088, _008A_0087_0089, _008A_0087_008A, _008A_0087_008B, _008A_0087_0088 };
					_008A_0087_0094 = new List<TemplatePoint>
					{
						TemplatePoint._008B_0089_008B(_008A_0087_0088),
						TemplatePoint._008B_0089_008B(_008A_0087_0089),
						TemplatePoint._008B_0089_008B(_008A_0087_008A),
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						TemplatePoint._008B_0089_008B(_008A_0087_0088)
					};
					_008A_0087_0095 = new List<TemplatePoint>
					{
						_008A_0087_008D,
						TemplatePoint._008B_0089_008B(_008A_0087_008D),
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						_008A_0087_008B,
						_008A_0087_008D
					};
					num = 20;
					if (_0088j())
					{
						goto IL_007a;
					}
					goto IL_03d9;
					IL_007a:
					_008A_0087_0096 = new List<TemplatePoint> { _008A_0087_008A, _008A_0087_008C, _008A_0087_008D, _008A_0087_008B, _008A_0087_008A };
					num = 22;
					if (!_0088k())
					{
						goto IL_00d4;
					}
					goto IL_057a;
					IL_00d4:
					switch (num)
					{
					case 20:
						break;
					case 16:
						goto IL_0146;
					case 15:
						goto IL_0253;
					case 7:
						goto IL_02c1;
					case 8:
						goto IL_0305;
					case 11:
						goto IL_0384;
					case 13:
						goto IL_03d9;
					case 19:
					case 21:
						goto IL_03fc;
					case 14:
						goto IL_057a;
					case 9:
						continue;
					case 1:
						goto end_IL_05c5;
					default:
						num = 0;
						goto IL_06ad;
					case 10:
						goto IL_0605;
					case 3:
						goto IL_0615;
					case 0:
						goto IL_06ad;
					case 12:
						return;
					case 22:
						_008A_0087_0097 = new List<TemplatePoint>
						{
							TemplatePoint._008B_0089_008B(_008A_0087_008A),
							TemplatePoint._008B_0089_008B(_008A_0087_008C),
							TemplatePoint._008B_0089_008B(_008A_0087_008D),
							TemplatePoint._008B_0089_008B(_008A_0087_008B),
							TemplatePoint._008B_0089_008B(_008A_0087_008A)
						};
						_008A_0087_0099 = new List<List<TemplatePoint>> { _008A_0087_0092, _008A_0087_0093, _008A_0087_0094, _008A_0087_0095, _008A_0087_0096, _008A_0087_0097 };
						num = 24;
						return;
					case 5:
					case 23:
						_008A_0087_0099 = new List<List<TemplatePoint>> { _008A_0087_0092, _008A_0087_0095, _008A_0087_0096, _008A_0087_0097 };
						return;
					case 2:
						return;
					case 17:
						goto IL_08d5;
					case 18:
						goto IL_095f;
					case 4:
						goto IL_09b9;
					case 6:
						goto IL_0a86;
					case 24:
						return;
					}
					goto IL_007a;
					IL_0605:
					throw new Exception("本软件不支持过低的转弯高度，请检查。" /* string-offset:6544 */);
					IL_03d9:
					if (!(_008A_0086_009C <= 13263.71))
					{
						goto IL_05b2;
					}
					num = 15;
					if (_0088j())
					{
						goto IL_0253;
					}
					goto IL_0615;
					IL_08d5:
					_008A_0087_0093 = new List<TemplatePoint> { _008A_0087_0088, _008A_0087_008A, _008A_0087_008B, _008A_0087_0088 };
					_008A_0087_0094 = new List<TemplatePoint>
					{
						TemplatePoint._008B_0089_008B(_008A_0087_0088),
						TemplatePoint._008B_0089_008B(_008A_0087_008A),
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						TemplatePoint._008B_0089_008B(_008A_0087_0088)
					};
					goto IL_095f;
					IL_0615:
					_008A_0087_0095 = new List<TemplatePoint>
					{
						_008A_0087_008D,
						TemplatePoint._008B_0089_008B(_008A_0087_008D),
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						_008A_0087_008B,
						_008A_0087_008D
					};
					_008A_0087_0096 = new List<TemplatePoint> { _008A_0087_008A, _008A_0087_008C, _008A_0087_008D, _008A_0087_008B, _008A_0087_008A };
					goto IL_06ad;
					IL_06ad:
					_008A_0087_0097 = new List<TemplatePoint>
					{
						TemplatePoint._008B_0089_008B(_008A_0087_008A),
						TemplatePoint._008B_0089_008B(_008A_0087_008C),
						TemplatePoint._008B_0089_008B(_008A_0087_008D),
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						TemplatePoint._008B_0089_008B(_008A_0087_008A)
					};
					_008A_0087_0099 = new List<List<TemplatePoint>> { _008A_0087_0092, _008A_0087_0093, _008A_0087_0094, _008A_0087_0095, _008A_0087_0096, _008A_0087_0097 };
					return;
					IL_0384:
					_008A_0087_0092 = new List<TemplatePoint>
					{
						_008A_0087_0087,
						obj,
						TemplatePoint._008B_0089_008B(obj),
						TemplatePoint._008B_0089_008B(_008A_0087_0087),
						_008A_0087_0087
					};
					num = 16;
					goto IL_0146;
					IL_0253:
					_008A_0087_0092 = new List<TemplatePoint>
					{
						_008A_0087_0087,
						_008A_0087_0088,
						_008A_0087_008B,
						TemplatePoint._008B_0089_008B(_008A_0087_008B),
						TemplatePoint._008B_0089_008B(_008A_0087_0088),
						TemplatePoint._008B_0089_008B(_008A_0087_0087),
						_008A_0087_0087
					};
					goto IL_02c1;
					IL_02c1:
					_008A_0087_0093 = new List<TemplatePoint> { _008A_0087_0088, _008A_0087_008A, _008A_0087_008B, _008A_0087_0088 };
					num = 8;
					goto IL_0305;
					continue;
					end_IL_05c5:
					break;
				}
			}
		}

// R5 MethodDef: original 0x060005CE RVA 0xAE694; processed 0x060005CD RVA 0x807E8; source 03_recovered-src\annotated-strings\--\--.cs:69742; processed IL recovery, not original runtime.
public PbnDepartureObstacle _008A_0086_0094(PbnDepartureObstacle P_0)
		{
			int num = default(int); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			num = 19;
			if (!_0088j())
			{
				goto IL_07ba;
			}
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				// IL local hoisted
				if (!false /* original-file-bool-offset:1212 */)
				{
					if (B5Math._008B_0088_008B(_008A_0087_009E, new TemplatePoint(P_0.X, P_0.Y)))
					{
						if (!(P_0.Y > 0.0))
						{
							num = 2;
							goto IL_0414;
						}
						num2 = P_0.Y;
						goto IL_041b;
					}
					P_0._0088_008E_0096("out" /* string-offset:1556 */);
					return P_0;
				}
				num = 49;
				goto IL_089a;
				IL_0178:
				if (!(_008A_0087_008A.X > _008A_0087_0089.X))
				{
					goto IL_03fe;
				}
				if (num3 > 3704.0)
				{
					num4 = num3 - 3704.0;
					num5 = P_0.X;
					P_0._0088_008E_0096("离场转弯段--KK线之前" /* string-offset:6552 */);
					P_0._0088_008F_0086(num5);
					num = 6;
					goto IL_01d5;
				}
				num4 = 0.0;
				num = 13;
				if (_0088k())
				{
					break;
				}
				goto IL_05e7;
				IL_0cc3:
				P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0087_009C._008A_009D_0096) / num4));
				num = 59;
				break;
				IL_0aa3:
				P_0._0088_008E_009C(num4);
				P_0._0088_008F_0089(Math.Max(75.0, num4 * 0.008));
				num = 29;
				goto IL_0ad2;
				IL_0652:
				if (num3 <= _008A_0087_0087.Y)
				{
					goto IL_066e;
				}
				num = 48;
				goto IL_07ba;
				IL_05e7:
				num5 = P_0.X;
				num = 22;
				goto IL_05f7;
				IL_041b:
				num3 = num2;
				if (!(P_0.X >= _008A_0087_008A.X))
				{
					if (P_0.X >= _008A_0087_0089.X)
					{
						goto IL_0178;
					}
					goto IL_03fe;
				}
				num5 = _008A_0087_008A.X;
				num4 = ((num3 <= _008A_0087_008A.Y) ? (P_0.X - _008A_0087_008A.X) : Math.Sqrt((P_0.X - _008A_0087_008A.X) * (P_0.X - _008A_0087_008A.X) + (num3 - _008A_0087_008A.Y) * (num3 - _008A_0087_008A.Y)));
				P_0._0088_008E_0096("离场转弯区--kk'线之后" /* string-offset:6548 */);
				P_0._0088_008F_0086(num5);
				P_0._0088_008E_009C(num4);
				num = 25;
				goto IL_061a;
				IL_05f7:
				P_0._0088_008E_0096("离场直线段--KK线之前" /* string-offset:1564 */);
				P_0._0088_008F_0086(num5);
				P_0._0088_008E_009C(num4);
				goto IL_09c5;
				IL_0a34:
				P_0._0088_008E_0096("离场转弯区-kk'线之前" /* string-offset:1568 */);
				goto IL_0a44;
				IL_0a44:
				P_0._0088_008F_0086(num5);
				num = 57;
				goto IL_0b2c;
				IL_09ed:
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				P_0._0088_008F_008F(_008A_0087_008F.Z + 5.0 + num5 * _008A_0086_009D);
				num = 1;
				if (_0088k())
				{
					goto IL_0a34;
				}
				goto IL_0a59;
				IL_09c5:
				P_0._0088_008F_0089(Math.Max(75.0, num5 * 0.008));
				num = 53;
				goto IL_09ed;
				IL_03fe:
				if (!(P_0.X > 0.0))
				{
					if (_008A_0087_0086)
					{
						P_0._0088_008F_0086(0.0);
						num = 34;
						goto IL_03ca;
					}
					P_0._0088_008F_0086(0.0);
					num = 28;
					goto IL_0652;
				}
				if (num3 >= _008A_0087_009B._008B_0088_008D(P_0.X))
				{
					goto IL_0399;
				}
				if (num3 < _008A_0087_009A._008B_0088_008D(P_0.X))
				{
					num4 = 0.0;
					num = 37;
					goto IL_0785;
				}
				goto IL_089a;
				IL_0b2c:
				P_0._0088_008E_009C(num4);
				num = 21;
				goto IL_0b3c;
				IL_0b79:
				P_0._0088_008F_008F(_008A_0087_009C._008A_009D_0096 + num4 * _008A_0086_009E);
				P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0087_009C._008A_009D_0096) / num4));
				break;
				IL_0a59:
				P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0087_008F.Z - 5.0) / num5));
				/* opaque discard 0 */
				if (_0088j())
				{
					break;
				}
				num = 40;
				goto IL_0aa3;
				IL_0b3c:
				P_0._0088_008F_0089(Math.Max(75.0, (num4 + num5) * 0.008));
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				num = 38;
				goto IL_0b79;
				IL_01d5:
				P_0._0088_008E_009C(num4);
				P_0._0088_008F_0089(Math.Max(75.0, (num4 + num5) * 0.008));
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				num = 36;
				if (!_0088k())
				{
					goto IL_0286;
				}
				goto IL_0652;
				IL_03ca:
				if (P_0.X >= _008A_0087_008E.X)
				{
					num = 20;
					goto IL_03b4;
				}
				num4 = ((num3 <= _008A_0087_008E.Y) ? (_008A_0087_008E.X - P_0.X) : Math.Sqrt((P_0.X - _008A_0087_008E.X) * (P_0.X - _008A_0087_008E.X) + (num3 - _008A_0087_008E.Y) * (num3 - _008A_0087_008E.Y)));
				P_0._0088_008E_0096("离场转弯区-最早点之前" /* string-offset:1584 */);
				goto IL_0c70;
				IL_0ad2:
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				goto IL_0ae5;
				IL_03b4:
				if (!(num3 <= _008A_0087_008E.Y))
				{
					num4 = num3 - _008A_0087_008E.Y;
					num = 26;
					if (!_0088k())
					{
						goto IL_0286;
					}
					goto IL_0399;
				}
				num = 50;
				goto IL_0929;
				IL_0929:
				P_0._0088_008E_0096("早转弯区-净空道内" /* string-offset:1576 */);
				P_0._0088_008F_0089(75.0);
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				P_0._0088_008F_008F(_008A_0087_009C._008A_009D_0096);
				num = 32;
				break;
				IL_0ae5:
				P_0._0088_008F_008F(_008A_0087_009C._008A_009D_0096 + num4 * _008A_0086_009E);
				goto IL_0aff;
				IL_0399:
				if (!(_008A_0087_008A.X >= 13263.71))
				{
					num4 = Math.Sqrt((P_0.X - _008A_0087_008A.X) * (P_0.X - _008A_0087_008A.X) + (num3 - _008A_0087_008A.Y) * (num3 - _008A_0087_008A.Y));
					goto IL_012a;
				}
				num = 11;
				if (_0088j())
				{
					goto IL_0286;
				}
				goto IL_03ca;
				IL_0aff:
				P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0087_009C._008A_009D_0096) / num4));
				break;
				IL_0c70:
				P_0._0088_008E_009C(num4);
				P_0._0088_008F_0089(Math.Max(75.0, num4 * 0.008));
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				P_0._0088_008F_008F(_008A_0087_009C._008A_009D_0096 + num4 * _008A_0086_009E);
				goto IL_0cc3;
				IL_012a:
				num5 = _008A_0087_008A.X;
				num = 0;
				if (_0088j())
				{
					goto IL_0149;
				}
				goto IL_0929;
				IL_0149:
				P_0._0088_008E_0096("离场转弯区-kk'线之前" /* string-offset:1568 */);
				P_0._0088_008F_0086(num5);
				num = 17;
				if (!_0088j())
				{
					break;
				}
				goto IL_0286;
				IL_0286:
				switch (num)
				{
				case 44:
					break;
				case 0:
				case 41:
					goto IL_0149;
				case 18:
					goto IL_0178;
				case 6:
					goto IL_01d5;
				case 11:
					num4 = Math.Sqrt((P_0.X - _008A_0087_0089.X) * (P_0.X - _008A_0087_0089.X) + (num3 - _008A_0087_0089.Y) * (num3 - _008A_0087_0089.Y));
					goto case 5;
				case 5:
					num5 = _008A_0087_0089.X;
					num = 41;
					goto IL_0149;
				case 10:
					goto IL_0399;
				case 20:
					goto IL_03b4;
				case 34:
					goto IL_03ca;
				case 2:
					goto IL_0414;
				case 19:
					continue;
				case 17:
					P_0._0088_008E_009C(num4);
					P_0._0088_008F_0089(Math.Max(75.0, (num4 + num5) * 0.008));
					P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
					num = 7;
					goto case 7;
				case 7:
					P_0._0088_008F_008F(_008A_0087_009C._008A_009D_0096 + num4 * _008A_0086_009E);
					num = 30;
					goto case 30;
				case 13:
					goto IL_05e7;
				case 22:
					goto IL_05f7;
				case 25:
					goto IL_061a;
				case 26:
					P_0._0088_008E_0096("离场转弯区-净空道侧方" /* string-offset:1580 */);
					goto IL_0aa3;
				case 28:
					goto IL_0652;
				case 30:
					P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0087_009C._008A_009D_0096) / num4));
					num = 3;
					goto end_IL_0434;
				case 35:
					goto IL_06bb;
				case 31:
					goto IL_06ce;
				case 36:
					P_0._0088_008F_008F(_008A_0087_008F.Z + 5.0 + num5 * _008A_0086_009D);
					goto case 33;
				case 33:
					P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0087_008F.Z - 5.0) / (num5 + num4)));
					num = 46;
					if (!_0088k())
					{
						goto end_IL_0434;
					}
					goto IL_0bc0;
				case 37:
					goto IL_0785;
				case 14:
					goto IL_07a5;
				case 48:
					goto IL_07ba;
				case 27:
					goto IL_0818;
				case 45:
					goto IL_0837;
				case 16:
					goto IL_0864;
				case 49:
					goto IL_089a;
				case 39:
					goto IL_08c4;
				case 50:
					goto IL_0929;
				case 54:
					goto IL_097a;
				case 8:
					goto IL_098a;
				case 52:
					goto IL_09a4;
				case 55:
					goto IL_09c5;
				case 53:
					goto IL_09ed;
				case 15:
					goto IL_0a34;
				default:
					goto IL_0a44;
				case 1:
					goto IL_0a59;
				case 40:
				case 51:
					goto IL_0aa3;
				case 29:
					goto IL_0ad2;
				case 4:
					goto IL_0ae5;
				case 43:
					goto IL_0aff;
				case 57:
					goto IL_0b2c;
				case 21:
					goto IL_0b3c;
				case 38:
					goto IL_0b79;
				case 58:
					goto IL_0bc0;
				case 24:
					goto IL_0bce;
				case 47:
					goto IL_0c70;
				case 42:
					goto IL_0cc3;
				case 3:
				case 12:
				case 23:
				case 32:
				case 46:
				case 56:
				case 59:
					goto end_IL_0434;
				}
				goto IL_012a;
				IL_089a:
				num4 = _008A_0087_009A._008B_0088_0092(new TemplatePoint(P_0.X, num3));
				num = 39;
				goto IL_08c4;
				IL_08c4:
				obj = new LineCarrier();
				obj._008B_0088_008F(new TemplatePoint(P_0.X, num3), _008A_0087_009B._008B_0088_0094());
				num5 = obj._008B_0088_0093(_008A_0087_009A).X;
				num = 15;
				goto IL_0a34;
				IL_0785:
				num5 = P_0.X;
				P_0._0088_008E_0096("离场直线段-kk'线之前" /* string-offset:6556 */);
				num = 14;
				goto IL_07a5;
				IL_07a5:
				P_0._0088_008F_0086(num5);
				num = 54;
				goto IL_097a;
				IL_097a:
				P_0._0088_008E_009C(num4);
				num = 8;
				goto IL_098a;
				IL_098a:
				P_0._0088_008F_0089(num5 * 0.008);
				num = 52;
				goto IL_09a4;
				IL_09a4:
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				num = 58;
				goto IL_0bc0;
				IL_0bc0:
				P_0._0088_008F_008F(num5 * _008A_0086_009D);
				goto IL_0bce;
				IL_0bce:
				P_0._0088_008F_0092(_008A_0087_008F.Z + 5.0 + num5 * _008A_0086_009D);
				break;
				IL_061a:
				P_0._0088_008F_0089(Math.Max(75.0, (num4 + num5) * 0.008));
				goto IL_06bb;
				IL_06bb:
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				goto IL_06ce;
				IL_06ce:
				P_0._0088_008F_008F(_008A_0087_009C._008A_009D_0096 + num4 * _008A_0086_009E);
				P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0087_009C._008A_009D_0096) / num4));
				break;
				IL_0414:
				num2 = 0.0 - P_0.Y;
				goto IL_041b;
				continue;
				end_IL_0434:
				break;
			}
			goto IL_0cf4;
			IL_07ba:
			num6 = Math.Sqrt((P_0.X - _008A_0087_0087.X) * (P_0.X - _008A_0087_0087.X) + (num3 - _008A_0087_0087.Y) * (num3 - _008A_0087_0087.Y));
			goto IL_0800;
			IL_0837:
			P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
			P_0._0088_008F_008F(_008A_0087_009C._008A_009D_0096 + num4 * _008A_0086_009E);
			goto IL_0864;
			IL_0818:
			P_0._0088_008F_0089(Math.Max(75.0, num4 * 0.008));
			goto IL_0837;
			IL_0864:
			P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0087_009C._008A_009D_0096) / num4));
			num = 56;
			goto IL_0cf4;
			IL_0cf4:
			return P_0;
			IL_066e:
			num6 = _008A_0087_0087.X - P_0.X;
			goto IL_0800;
			IL_0800:
			num4 = num6;
			P_0._0088_008E_0096("离场转弯段--DER之前" /* string-offset:1572 */);
			P_0._0088_008E_009C(num4);
			goto IL_0818;
		}

// R5 MethodDef: original 0x060005CF RVA 0xAF480; processed 0x060005CE RVA 0x814EC; source 03_recovered-src\annotated-strings\--\--.cs:70201; processed IL recovery, not original runtime.
public void _008A_0086_0095()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			_0088j();
			if (!_0088k())
			{
				goto IL_0025;
			}
			goto IL_006b;
			IL_0025:
			list = PointLists._008B_008A_0092(_008A_0087_0087, _008A_0087_0088);
			_008A_0087_0099.Add(PointLists._008B_008A_0099(list));
			list = PointLists._008B_008A_0092(_008A_0087_0088, _008A_0087_008A);
			_008A_0087_0099.Add(PointLists._008B_008A_0099(list));
			goto IL_006b;
			IL_006b:
			if (_008A_0087_0086)
			{
				list = new List<TemplatePoint>();
				if (!_0088k())
				{
					list = PointLists._008B_008A_0092(_008A_0087_0087, _008A_0087_0089);
					_008A_0087_0099.Add(PointLists._008B_008A_0099(list));
					return;
				}
				goto IL_0025;
			}
		}

// R5 MethodDef: original 0x060005D0 RVA 0xAF5E8; processed 0x060005CF RVA 0x81594; source 03_recovered-src/annotated-strings/--/--.cs:70230; processed IL recovery, not original runtime.
static PbnDepartureAltitudeTurn()
		{

			/* opaque discard 0 */
			if (_0088j())
			{
				// Host licensing not executed in independent recovery.
				if (_0088k())
				{
				}
				_008A_0088_0086 = Math.PI / 12.0;
			}
			else if (_0088k())
			{
				return;
			}
			_008A_0088_0087 = Math.PI / 2.0;
		}

// R5 MethodDef: original 0x060005D1 RVA 0xAF6B8; processed 0x060005D0 RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:70248; processed IL recovery, not original runtime.
internal static bool _0088j()
		{

			return true;
		}

// R5 MethodDef: original 0x060005D2 RVA 0xAF6C4; processed 0x060005D1 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:70253; processed IL recovery, not original runtime.
internal static bool _0088k()
		{

			return false;
		}
	}
}
