using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
// Processed source/IL recovery; identifiers and branches retained. No original DLL oracle.
namespace Recovered.B3 {
public static class RnpApchForm {
// R6 MethodDef: original 0x06000472 RVA 0x6E248; processed 0x06000471 RVA 0x59F1C; source 03_recovered-src\annotated-strings\--\--.cs:46858; processed IL recovery, not original runtime.
public static void _0088_009A_0091(ref RnpApchApvObstacle P_0, double P_1, double P_2, double P_3, string P_4)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			num = 6;
			while (true)
			{
				if (!false /* original-file-bool-offset:908 */)
				{
					P_0._0088_0090_008F = P_0._0088_0090_0090 + P_1;
					P_0._0088_0090_0092 = Math.Ceiling(P_0._0088_0090_0090 / 5.0) * 5.0;
					P_0._0088_0090_0091 = Math.Round(P_0._0088_0090_0092 + P_1);
					while (true)
					{
						num2 = P_0._0088_0090_0092 / P_3 - P_2;
						num = 11;
						if (_0088_0094())
						{
							return;
						}
						while (true)
						{
							IL_02fa:
							if (!(num2 < 800.0))
							{
								if (num2 < 5000.0)
								{
									num = 10;
									goto IL_0239;
								}
								num2 = Math.Ceiling(num2 / 1000.0) * 1000.0;
								num = 16;
							}
							else
							{
								/* opaque discard 1 */
								if (!_0088_0094())
								{
									num = 15;
									goto IL_01e2;
								}
								num = 0;
							}
							goto IL_0254;
							IL_01e2:
							num2 = Math.Ceiling(num2 / 50.0) * 50.0;
							goto IL_0254;
							IL_0239:
							num2 = Math.Ceiling(num2 / 100.0) * 100.0;
							goto IL_0254;
							IL_0254:
							while (true)
							{
								if (!(P_1 < 3000.0))
								{
									goto IL_011d;
								}
								goto IL_01bd;
								IL_01bd:
								num2 = Math.Min(num2, 5000.0);
								num = 2;
								if (!_0088_0093())
								{
									break;
								}
								goto IL_014c;
								IL_014c:
								switch (num)
								{
								case 17:
									break;
								case 2:
									goto IL_00c4;
								case 13:
									goto IL_00f2;
								default:
									goto IL_011d;
								case 12:
									goto IL_01bd;
								case 4:
								case 15:
									goto IL_01e2;
								case 10:
									goto end_IL_0254;
								case 0:
								case 5:
								case 16:
								case 18:
									continue;
								case 1:
								case 3:
								case 8:
									goto IL_02ba;
								case 11:
									goto IL_02fa;
								case 7:
									goto end_IL_02fa;
								case 6:
									goto end_IL_030b;
								case 9:
								case 19:
									return;
								}
								goto IL_00a2;
								IL_011d:
								if (P_0._0088_0090_0092 <= 300.0)
								{
									if (!(P_1 >= 3000.0))
									{
										num = 17;
										goto IL_00a2;
									}
									goto IL_00b4;
								}
								num = 12;
								if (_0088_0093())
								{
									goto IL_01bd;
								}
								goto IL_02ba;
								IL_00c4:
								if (!(P_4 == "D" /* string-offset:1644 */))
								{
									if (P_2 > 720.0)
									{
										num = 13;
										goto IL_00f2;
									}
									if (P_2 > 420.0)
									{
										P_0._0088_0090_0093 = Math.Max(num2, 1200.0);
										num = 8;
										if (!_0088_0093())
										{
											continue;
										}
									}
									else
									{
										P_0._0088_0090_0093 = Math.Max(num2, 1600.0);
									}
								}
								else if (P_2 > 720.0)
								{
									P_0._0088_0090_0093 = Math.Max(num2, 1200.0);
								}
								else
								{
									P_0._0088_0090_0093 = Math.Max(num2, 1600.0);
								}
								goto IL_02ba;
								IL_02ba:
								P_0._0088_0090_0093 = num2;
								num = 19;
								if (!_0088_0093())
								{
									goto IL_02fa;
								}
								return;
								IL_00f2:
								P_0._0088_0090_0093 = Math.Max(num2, 800.0);
								num = 3;
								if (!_0088_0094())
								{
									goto IL_014c;
								}
								goto IL_01bd;
								IL_00a2:
								if (P_0._0088_0090_0092 > 450.0)
								{
									goto IL_00b4;
								}
								goto IL_00c4;
								IL_00b4:
								num2 = Math.Min(num2, 8000.0);
								goto IL_00c4;
								continue;
								end_IL_0254:
								break;
							}
							goto IL_0239;
							continue;
							end_IL_02fa:
							break;
						}
						continue;
						end_IL_030b:
						break;
					}
					continue;
				}
				num = 9;
				break;
			}
		}
// R6 MethodDef: original 0x060004B4 RVA 0x78BF8; processed 0x060004B3 RVA 0x62D34; source 03_recovered-src\annotated-strings\--\--.cs:51969; processed IL recovery, not original runtime.
public static void _0088_009D_0086(ref RnpApchObstacle P_0, double P_1, double P_2, double P_3, double P_4, string P_5)
		{
			int num = default(int); // IL InitLocals
			double val = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			num = 1;
			// IL local hoisted
			while (true)
			{
				if (!false /* original-file-bool-offset:940 */)
				{
					if (P_0._0088_0090_0087 - P_1 < 90.0)
					{
						P_0._0088_0090_0088 = 90.0;
						goto IL_01f8;
					}
					P_0._0088_0090_0088 = Math.Round(P_0._0088_0090_0087 - P_1);
					goto IL_004c;
				}
				return;
				IL_01e6:
				val = Math.Max(val, 1600.0);
				goto IL_01d5;
				IL_01d5:
				if (!(P_2 > 3000.0))
				{
					val = Math.Min(val, 5000.0);
					num = 11;
					if (!_0088_0094())
					{
						goto IL_00b4;
					}
					goto IL_01c5;
				}
				val = Math.Min(val, 8000.0);
				num = 9;
				break;
				IL_019e:
				// IL local hoisted
				val = num2;
				goto IL_01d5;
				IL_004c:
				val = P_0._0088_0090_0088 / Math.Tan(P_4 * Math.PI / 180.0) - P_3;
				_0088_0094();
				if (!_0088_0093())
				{
					num = 2;
					goto IL_01e6;
				}
				num = 4;
				if (_0088_0093())
				{
					goto IL_00b4;
				}
				goto IL_0100;
				IL_01c5:
				num3 = Math.Max(val, 800.0);
				goto IL_01d4;
				IL_00b4:
				switch (num)
				{
				default:
					num = 8;
					goto IL_016b;
				case 3:
				case 4:
					break;
				case 10:
					goto IL_0133;
				case 8:
					goto IL_016b;
				case 7:
					goto IL_017e;
				case 0:
					goto IL_01c5;
				case 2:
				case 5:
					goto IL_01e6;
				case 12:
					goto IL_01f8;
				case 1:
					continue;
				case 9:
				case 11:
					goto end_IL_0228;
				case 6:
				case 13:
					return;
				}
				goto IL_0100;
				IL_0100:
				if (!(val < 5000.0))
				{
					num = 10;
					goto IL_0133;
				}
				num4 = Math.Ceiling(val / 100.0) * 100.0;
				goto IL_014d;
				IL_01f8:
				P_0._0088_0090_0087 = P_1 + 90.0;
				goto IL_004c;
				IL_0133:
				num4 = Math.Ceiling(val / 1000.0) * 1000.0;
				goto IL_014d;
				IL_014d:
				val = num4;
				if (P_3 >= 420.0)
				{
					if (P_3 < 720.0)
					{
						goto IL_016b;
					}
					if (!("D" /* string-offset:1644 */ == P_5))
					{
						goto IL_01c5;
					}
					num3 = Math.Max(val, 1600.0);
					goto IL_01d4;
				}
				goto IL_01e6;
				IL_016b:
				if (!("D" /* string-offset:1644 */ == P_5))
				{
					goto IL_017e;
				}
				num2 = Math.Max(val, 1600.0);
				goto IL_019e;
				IL_017e:
				num2 = Math.Max(val, 1200.0);
				goto IL_019e;
				IL_01d4:
				val = num3;
				goto IL_01d5;
				continue;
				end_IL_0228:
				break;
			}
			P_0._0088_0090_0089 = val;
		}
internal static bool _0088_0093(){return true;}
internal static bool _0088_0094(){return false;}
}
}
