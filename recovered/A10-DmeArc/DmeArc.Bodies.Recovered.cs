using System;
using System.Collections.Generic;
using System.Linq;
// Mechanical source/IL port; original labels and compare operators retained.
// CAD original060002DC/RVA37D8C; evaluation original060002DF/RVA3A5DC.
// Portable recorder preserves signed radii; not proof of Autodesk kernel behavior.
public partial class DmeArcRecovered {
		private void DrawCore()
		{
			int num = 96;
			InputCheck obj = default(InputCheck);
			RePoint val = default(RePoint);
			RePoint obj2 = default(RePoint);
			double num3 = default(double);
			double num4 = default(double);
			double num5 = default(double);
			double num6 = default(double);
			double num7 = default(double);
			double num8 = default(double);
			int num9 = default(int);
			double num10 = default(double);
			double num11 = default(double);
			double num12 = default(double);
			RePoint obj3 = default(RePoint);
			RePoint obj4 = default(RePoint);
			double num13 = default(double);
			double num15 = default(double);
			RePoint val2 = default(RePoint);
			double num16 = default(double);
			int num17 = default(int);
			RePoint val3 = default(RePoint);
			double num18 = default(double);
			double num19 = default(double);
			RePolyline val4 = default(RePolyline);
			ReArc val6 = default(ReArc);
			object database = default(object);
			RePolyline val7 = default(RePolyline);
			ReArc val8 = default(ReArc);
			RePoint val9 = default(RePoint);
			double num24 = default(double);
			double num25 = default(double);
			double num26 = default(double);
			double num27 = default(double);
			RePoint val10 = default(RePoint);
			RePoint val11 = default(RePoint);
			double num28 = default(double);
			int num29 = default(int);
			double num30 = default(double);
			RePoint obj9 = default(RePoint);
			double num32 = default(double);
			double num33 = default(double);
			RePoint val12 = default(RePoint);
			double num34 = default(double);
			int num35 = default(int);
			ReArc val13 = default(ReArc);
			double num36 = default(double);
			RePoint val14 = default(RePoint);
			double num37 = default(double);
			ReArc val15 = default(ReArc);
			ReArc val16 = default(ReArc);
			RePolyline val17 = default(RePolyline);
			double num42 = default(double);
			RePoint obj14 = default(RePoint);
			double num44 = default(double);
			RePoint obj15 = default(RePoint);
			double num45 = default(double);
			ReArc val18 = default(ReArc);
			ReArc val19 = default(ReArc);
			RePolyline val20 = default(RePolyline);
			ReArc val21 = default(ReArc);
			ReArc val22 = default(ReArc);
			ReArc val23 = default(ReArc);
			ReArc val24 = default(ReArc);
			ReArc val25 = default(ReArc);
			while (true /* original-file-bool-offset:424 */)
			{
				while (true)
				{
					InputCheck[] array = new InputCheck[6]
					{
						new InputCheck(_0087_008F_009A, "导航台 X坐标不能为空。" /* string-offset:3552 */),
						new InputCheck(_0087_008F_009B, "导航台 Y坐标不能为空。" /* string-offset:3556 */),
						new InputCheck(_0087_008F_0093, "IF点 X坐标不能为空。" /* string-offset:3560 */),
						new InputCheck(_0087_008F_0094, "IF点 Y坐标不能为空。" /* string-offset:3564 */),
						new InputCheck(_0087_008F_008D, "IAF点 X坐标不能为空}。" /* string-offset:3568 */),
						new InputCheck(_0087_008F_008C, "IAF点 Y坐标不能为空。" /* string-offset:3572 */)
					};
					while (true)
					{
						int num2 = 0;
						num = 31;
						while (true)
						{
							if (num2 < array.Length)
							{
								obj = array[num2];
								goto IL_1ec2;
							}
							goto IL_111e;
							IL_0d80:
							val = new RePoint(obj2.X + (num3 + num4 - num5) * Math.Cos(num6 - num7), obj2.Y + (num3 + num4 - num5) * Math.Sin(num6 - num7), 0.0);
							num8 = Math.Atan2(val.Y - obj2.Y, val.X - obj2.X);
							num = 82;
							goto IL_0df0;
							IL_1ec2:
							if (!CheckInput(obj.Value, obj.Message))
							{
								num = 105;
								if (FalseHelper())
								{
									goto IL_1e9e;
								}
								return;
							}
							num2++;
							continue;
							IL_0df0:
							num9 = -9260;
							goto IL_0df7;
							IL_074e:
							num10 = Math.Asin(num11 / (num12 + num11));
							goto IL_075d;
							IL_1e9e:
							obj3.X = Convert.ToDouble(_0087_008F_0093.Text);
							num = 88;
							goto IL_1e2c;
							IL_1e2c:
							obj3.Y = Convert.ToDouble(_0087_008F_0094.Text);
							obj4.X = Convert.ToDouble(_0087_008F_008D.Text);
							num = 29;
							goto IL_1e0b;
							IL_1e0b:
							obj4.Y = Convert.ToDouble(_0087_008F_008C.Text);
							num = 93;
							goto IL_1de0;
							IL_1de0:
							num13 = Math.Atan2(obj4.Y - obj2.Y, obj4.X - obj2.X);
							num = 86;
							goto IL_1dae;
							IL_1dae:
							num6 = Math.Atan2(obj3.Y - obj2.Y, obj3.X - obj2.X);
							num13 = ((!(num13 < 0.0)) ? num13 : (num13 + Math.PI * 2.0));
							if (!(num6 < 0.0))
							{
								num = 66;
								goto IL_1d97;
							}
							double num14 = num6 + Math.PI * 2.0;
							goto IL_1d99;
							IL_07c5:
							num15 = Math.Atan(num5 / num3);
							num = 17;
							goto IL_07da;
							IL_07da:
							val2 = new RePoint(obj2.X + (num3 + num4 - num5) * Math.Cos(num6 + num15), obj2.Y + (num3 + num4 - num5) * Math.Sin(num6 + num15), 0.0);
							num16 = Math.Atan2(val2.Y - obj2.Y, val2.X - obj2.X);
							num17 = -9260;
							goto IL_0848;
							IL_075d:
							val3 = new RePoint(obj2.X + (num12 + num11) * Math.Cos(num13 - num10), obj2.Y + (num12 + num11) * Math.Sin(num13 - num10), 0.0);
							num18 = Math.Atan2(obj2.Y - val3.Y, obj2.X - val3.X);
							num = 16;
							goto IL_07c5;
							IL_053c:
							if (num6 - num13 <= Math.PI)
							{
								num = 45;
								goto IL_04b0;
							}
							num19 = Math.Asin(num11 / (num12 + num11));
							num = 54;
							if (TrueHelper())
							{
								goto IL_1326;
							}
							goto IL_20bc;
							IL_0a7c:
							RePolyline obj5 = val4;
							RePoint val5 = val6.EndPoint;
							double num20 = val5.X;
							val5 = val6.EndPoint;
							obj5.AddVertexAt(2, new RePoint(num20, val5.Y), 0.0 - Bulge(val6.StartAngle, val6.EndAngle), 0.0, 0.0);
							RePolyline obj6 = val4;
							val5 = val6.StartPoint;
							double num21 = val5.X;
							val5 = val6.StartPoint;
							obj6.AddVertexAt(3, new RePoint(num21, val5.Y), 0.0, 0.0, 0.0);
							num = 27;
							if (!FalseHelper())
							{
								goto IL_0b2a;
							}
							goto IL_1b41;
							IL_1d99:
							num6 = num14;
							if (num13 != num6)
							{
								database = null;
								num = 50;
								goto IL_1d78;
							}
							num = 72;
							return;
							IL_16f1:
							RePolyline obj7 = val7;
							val5 = val8.EndPoint;
							double num22 = val5.X;
							val5 = val8.EndPoint;
							obj7.AddVertexAt(0, new RePoint(num22, val5.Y), 0.0 - Bulge(val8.StartAngle, val8.EndAngle), 0.0, 0.0);
							RePolyline obj8 = val7;
							val5 = val8.StartPoint;
							double num23 = val5.X;
							val5 = val8.StartPoint;
							obj8.AddVertexAt(1, new RePoint(num23, val5.Y), 0.0, 0.0, 0.0);
							num = 7;
							goto IL_1795;
							IL_1326:
							val9 = new RePoint(obj2.X + (num12 + num11) * Math.Cos(num13 - num19), obj2.Y + (num12 + num11) * Math.Sin(num13 - num19), 0.0);
							num24 = Math.Atan2(obj2.Y - val9.Y, obj2.X - val9.X);
							num25 = Math.Atan(num5 / num3);
							goto IL_1391;
							IL_1d78:
							num3 = RePoint.Distance(obj3, obj2);
							num4 = 3704.0;
							num = 85;
							goto IL_1d6f;
							IL_1d6f:
							num12 = num3 + num4;
							goto IL_1cfe;
							IL_1cfe:
							num5 = (2.0 * num3 * num4 + num4 * num4) / (2.0 * num3 + 2.0 * num4);
							num11 = (2.0 * num3 * num4 + 3.0 * num4 * num4) / (2.0 * num3 + 2.0 * num4);
							goto IL_1ce9;
							IL_1ce9:
							num26 = 1000.0;
							if (!(num13 < num6))
							{
								if (num13 - num6 <= Math.PI)
								{
									num = 78;
									goto IL_074e;
								}
								num27 = Math.Asin(num11 / (num12 + num11));
								val10 = new RePoint(obj2.X + (num12 + num11) * Math.Cos(num13 + num27), obj2.Y + (num12 + num11) * Math.Sin(num13 + num27), 0.0);
								num = 49;
								goto IL_1ca0;
							}
							num = 35;
							if (!FalseHelper())
							{
								goto IL_053c;
							}
							goto IL_0eb8;
							IL_1391:
							val11 = new RePoint(obj2.X + (num3 + num4 - num5) * Math.Cos(num6 + num25), obj2.Y + (num3 + num4 - num5) * Math.Sin(num6 + num25), 0.0);
							num28 = Math.Atan2(val11.Y - obj2.Y, val11.X - obj2.X);
							num = 70;
							goto IL_1401;
							IL_1401:
							num29 = -9260;
							num = 79;
							goto IL_1411;
							IL_20bc:
							num30 = (num6 + num13) / 2.0 + Math.PI;
							obj9 = new RePoint();
							num = 20;
							goto IL_20e6;
							IL_20e6:
							obj9.X = obj2.X + num12 * Math.Cos(num30);
							obj9.Y = obj2.Y + num12 * Math.Sin(num30);
							double num31 = Math.Round(num12 / 1852.0, 1, MidpointRounding.AwayFromZero);
							Capture(new ReText
							{
								Height = num26,
								TextString = "D" /* string-offset:1644 */ + num31.ToString("0.0" /* string-offset:1636 */) + _0087_0090_008A.Text,
								HorizontalMode = (int)1,
								VerticalMode = (int)1,
								AlignmentPoint = obj9,
								Rotation = num30 - Math.PI / 2.0
							}, database);
							num = 108;
							return;
							IL_1ca0:
							num32 = Math.Atan2(obj2.Y - val10.Y, obj2.X - val10.X);
							num = 26;
							goto IL_1c21;
							IL_1c21:
							num33 = Math.Atan(num5 / num3);
							val12 = new RePoint(obj2.X + (num3 + num4 - num5) * Math.Cos(num6 - num33), obj2.Y + (num3 + num4 - num5) * Math.Sin(num6 - num33), 0.0);
							num34 = Math.Atan2(val12.Y - obj2.Y, val12.X - obj2.X);
							num35 = -9260;
							goto IL_1c10;
							IL_1c10:
							if (num35 <= 9260)
							{
								val13 = Drawing.Arc(val10, num11 - (double)num35, num32, num13 - Math.PI / 2.0);
								num = 59;
								goto IL_1bf1;
							}
							num = 90;
							goto IL_20a3;
							IL_04b0:
							num36 = Math.Asin(num11 / (num12 + num11));
							num = 11;
							goto IL_04c8;
							IL_04c8:
							val14 = new RePoint(obj2.X + (num12 + num11) * Math.Cos(num13 + num36), obj2.Y + (num12 + num11) * Math.Sin(num13 + num36), 0.0);
							num37 = Math.Atan2(obj2.Y - val14.Y, obj2.X - val14.X);
							num = 22;
							if (TrueHelper())
							{
								goto IL_055c;
							}
							goto IL_208e;
							IL_1bf1:
							val15 = Drawing.Arc(val12, num5 + (double)num35, num34, num6 + Math.PI / 2.0);
							goto IL_1bc4;
							IL_1bc4:
							val16 = Drawing.Arc(obj2, num12 + (double)num35, num13 + num27, num6 - num33);
							val17 = new RePolyline();
							if (num35 >= 0)
							{
								if (num35 == 0)
								{
									RePolyline obj10 = val17;
									val5 = val13.EndPoint;
									double num38 = val5.X;
									val5 = val13.EndPoint;
									obj10.AddVertexAt(0, new RePoint(num38, val5.Y), 0.0 - Bulge(val13.StartAngle, val13.EndAngle), 0.0, 0.0);
									RePolyline obj11 = val17;
									val5 = val13.StartPoint;
									double num39 = val5.X;
									val5 = val13.StartPoint;
									obj11.AddVertexAt(1, new RePoint(num39, val5.Y), 0.0, 0.0, 0.0);
									RePolyline obj12 = val17;
									val5 = val16.StartPoint;
									double num40 = val5.X;
									val5 = val16.StartPoint;
									obj12.AddVertexAt(2, new RePoint(num40, val5.Y), Bulge(val16.StartAngle, val16.EndAngle), 0.0, 0.0);
									RePolyline obj13 = val17;
									val5 = val16.EndPoint;
									double num41 = val5.X;
									val5 = val16.EndPoint;
									obj13.AddVertexAt(3, new RePoint(num41, val5.Y), 0.0, 0.0, 0.0);
									num = 1;
									goto IL_18bb;
								}
								if (num35 > 0)
								{
									num = 12;
									goto IL_1912;
								}
								goto IL_1b9f;
							}
							num = 0;
							if (FalseHelper())
							{
								goto IL_0d6b;
							}
							goto IL_1863;
							IL_208e:
							num42 = (num6 + num13) / 2.0;
							goto IL_21b1;
							IL_21b1:
							obj14 = new RePoint();
							goto IL_21b8;
							IL_21b8:
							obj14.X = obj2.X + num12 * Math.Cos(num42);
							obj14.Y = obj2.Y + num12 * Math.Sin(num42);
							goto IL_21e8;
							IL_21e8:
							double num43 = Math.Round(num12 / 1852.0, 1, MidpointRounding.AwayFromZero);
							Capture(new ReText
							{
								Height = num26,
								TextString = "D" /* string-offset:1644 */ + num43.ToString("0.0" /* string-offset:1636 */) + _0087_0090_008A.Text,
								HorizontalMode = (int)1,
								VerticalMode = (int)1,
								AlignmentPoint = obj14,
								Rotation = num42 - Math.PI / 2.0
							}, database);
							return;
							IL_2276:
							Capture(new ReText
							{
								Height = num26,
								TextString = "D" /* string-offset:1644 */ + num44.ToString("0.0" /* string-offset:1636 */) + _0087_0090_008A.Text,
								HorizontalMode = (int)1,
								VerticalMode = (int)1,
								AlignmentPoint = obj15,
								Rotation = num45 - Math.PI / 2.0
							}, database);
							return;
							IL_1b9f:
							val17.Closed = false;
							goto IL_1835;
							IL_1835:
							Capture(val17, database);
							num35 += 4630;
							num = 91;
							if (FalseHelper())
							{
								goto IL_17e8;
							}
							goto IL_1c10;
							IL_17e8:
							RePolyline obj16 = val7;
							val5 = val18.StartPoint;
							double num46 = val5.X;
							val5 = val18.StartPoint;
							obj16.AddVertexAt(3, new RePoint(num46, val5.Y), 0.0, 0.0, 0.0);
							goto IL_16db;
							IL_16db:
							val7.Closed = false;
							num = 100;
							goto IL_1422;
							IL_1422:
							Capture(val7, database);
							num29 += 4630;
							goto IL_1411;
							IL_1411:
							if (num29 <= 9260)
							{
								val19 = Drawing.Arc(val9, num11 - (double)num29, num13 + Math.PI / 2.0, num24);
								num = 94;
								goto IL_12dc;
							}
							goto IL_22ef;
							IL_14fb:
							RePolyline obj17 = val7;
							val5 = val19.StartPoint;
							double num47 = val5.X;
							val5 = val19.StartPoint;
							obj17.AddVertexAt(0, new RePoint(num47, val5.Y), Bulge(val19.StartAngle, val19.EndAngle), 0.0, 0.0);
							goto IL_154d;
							IL_12dc:
							val18 = Drawing.Arc(val11, num5 + (double)num29, num6 - Math.PI / 2.0, num28);
							num = 67;
							goto IL_12ae;
							IL_12ae:
							val8 = Drawing.Arc(obj2, num12 + (double)num29, num6 + num25, num13 - num19);
							val7 = new RePolyline();
							num = 103;
							goto IL_12a1;
							IL_12a1:
							if (num29 < 0)
							{
								RePolyline obj18 = val7;
								val5 = val19.StartPoint;
								double num48 = val5.X;
								val5 = val19.StartPoint;
								obj18.AddVertexAt(0, new RePoint(num48, val5.Y), Bulge(val19.StartAngle, val19.EndAngle), 0.0, 0.0);
								RePolyline obj19 = val7;
								val5 = val19.EndPoint;
								double num49 = val5.X;
								val5 = val19.EndPoint;
								obj19.AddVertexAt(1, new RePoint(num49, val5.Y), 0.0, 0.0, 0.0);
								num = 25;
								if (!FalseHelper())
								{
									goto IL_055c;
								}
								goto IL_11f8;
							}
							if (num29 == 0)
							{
								num = 76;
								goto IL_14fb;
							}
							if (num29 <= 0)
							{
								goto IL_16db;
							}
							goto IL_16f1;
							IL_154d:
							RePolyline obj20 = val7;
							val5 = val19.EndPoint;
							double num50 = val5.X;
							val5 = val19.EndPoint;
							obj20.AddVertexAt(1, new RePoint(num50, val5.Y), 0.0, 0.0, 0.0);
							goto IL_1595;
							IL_11f8:
							RePolyline obj21 = val20;
							val5 = val21.EndPoint;
							double num51 = val5.X;
							val5 = val21.EndPoint;
							obj21.AddVertexAt(0, new RePoint(num51, val5.Y), 0.0 - Bulge(val21.StartAngle, val21.EndAngle), 0.0, 0.0);
							RePolyline obj22 = val20;
							val5 = val21.StartPoint;
							double num52 = val5.X;
							val5 = val21.StartPoint;
							obj22.AddVertexAt(1, new RePoint(num52, val5.Y), 0.0, 0.0, 0.0);
							num = 48;
							goto IL_0369;
							IL_0369:
							RePolyline obj23 = val20;
							val5 = val22.StartPoint;
							double num53 = val5.X;
							val5 = val22.StartPoint;
							obj23.AddVertexAt(2, new RePoint(num53, val5.Y), Bulge(val22.StartAngle, val22.EndAngle), 0.0, 0.0);
							TrueHelper();
							if (!FalseHelper())
							{
								num = 38;
								goto IL_113d;
							}
							num = 14;
							if (!TrueHelper())
							{
								goto IL_1b9f;
							}
							goto IL_22ef;
							IL_0b2a:
							RePolyline obj24 = val4;
							val5 = val23.EndPoint;
							double num54 = val5.X;
							val5 = val23.EndPoint;
							obj24.AddVertexAt(4, new RePoint(num54, val5.Y), 0.0 - Bulge(val23.StartAngle, val23.EndAngle), 0.0, 0.0);
							num = 34;
							goto IL_0b86;
							IL_113d:
							RePolyline obj25 = val20;
							val5 = val22.EndPoint;
							double num55 = val5.X;
							val5 = val22.EndPoint;
							obj25.AddVertexAt(3, new RePoint(num55, val5.Y), 0.0, 0.0, 0.0);
							RePolyline obj26 = val20;
							val5 = val24.StartPoint;
							double num56 = val5.X;
							val5 = val24.StartPoint;
							obj26.AddVertexAt(4, new RePoint(num56, val5.Y), Bulge(val24.StartAngle, val24.EndAngle), 0.0, 0.0);
							num = 53;
							goto IL_10d4;
							IL_10d4:
							RePolyline obj27 = val20;
							val5 = val24.EndPoint;
							double num57 = val5.X;
							val5 = val24.EndPoint;
							obj27.AddVertexAt(5, new RePoint(num57, val5.Y), 0.0, 0.0, 0.0);
							goto IL_10af;
							IL_10af:
							val20.Closed = false;
							Capture(val20, database);
							num = 43;
							goto IL_0e08;
							IL_0e08:
							num9 += 4630;
							goto IL_0df7;
							IL_0df7:
							if (num9 <= 9260)
							{
								val21 = Drawing.Arc(val14, num11 - (double)num9, num37, num13 - Math.PI / 2.0);
								val24 = Drawing.Arc(val, num5 + (double)num9, num8, num6 + Math.PI / 2.0);
								num = 51;
								if (FalseHelper())
								{
									break;
								}
								goto IL_0d3b;
							}
							if (_0087_0090_0089.Checked)
							{
								num = 74;
								goto IL_208e;
							}
							return;
							IL_1b41:
							RePolyline obj28 = val17;
							val5 = val15.EndPoint;
							double num58 = val5.X;
							val5 = val15.EndPoint;
							obj28.AddVertexAt(5, new RePoint(num58, val5.Y), 0.0, 0.0, 0.0);
							goto IL_1b9f;
							IL_0f60:
							RePolyline obj29 = val20;
							val5 = val22.StartPoint;
							double num59 = val5.X;
							val5 = val22.StartPoint;
							obj29.AddVertexAt(0, new RePoint(num59, val5.Y), Bulge(val22.StartAngle, val22.EndAngle), 0.0, 0.0);
							num = 89;
							goto IL_0fbb;
							IL_1595:
							RePolyline obj30 = val7;
							val5 = val8.EndPoint;
							double num60 = val5.X;
							val5 = val8.EndPoint;
							obj30.AddVertexAt(2, new RePoint(num60, val5.Y), 0.0 - Bulge(val8.StartAngle, val8.EndAngle), 0.0, 0.0);
							RePolyline obj31 = val7;
							val5 = val8.StartPoint;
							double num61 = val5.X;
							val5 = val8.StartPoint;
							obj31.AddVertexAt(3, new RePoint(num61, val5.Y), 0.0, 0.0, 0.0);
							RePolyline obj32 = val7;
							val5 = val18.EndPoint;
							double num62 = val5.X;
							val5 = val18.EndPoint;
							obj32.AddVertexAt(4, new RePoint(num62, val5.Y), 0.0 - Bulge(val18.StartAngle, val18.EndAngle), 0.0, 0.0);
							num = 42;
							goto IL_168c;
							IL_0d3b:
							val22 = Drawing.Arc(obj2, num12 + (double)num9, num13 + num36, num6 - num7);
							val20 = new RePolyline();
							if (num9 >= 0)
							{
								if (num9 != 0)
								{
									if (num9 > 0)
									{
										num = 2;
										if (FalseHelper())
										{
											goto IL_0c48;
										}
										goto IL_0f60;
									}
									goto IL_10af;
								}
								num = 30;
								if (!FalseHelper())
								{
									goto IL_11f8;
								}
								goto IL_1835;
							}
							RePolyline obj33 = val20;
							val5 = val21.EndPoint;
							double num63 = val5.X;
							val5 = val21.EndPoint;
							obj33.AddVertexAt(0, new RePoint(num63, val5.Y), 0.0 - Bulge(val21.StartAngle, val21.EndAngle), 0.0, 0.0);
							num = 33;
							goto IL_0e70;
							IL_0fbb:
							RePolyline obj34 = val20;
							val5 = val22.EndPoint;
							double num64 = val5.X;
							val5 = val22.EndPoint;
							obj34.AddVertexAt(1, new RePoint(num64, val5.Y), 0.0, 0.0, 0.0);
							num = 101;
							goto IL_100c;
							IL_100c:
							RePolyline obj35 = val20;
							val5 = val24.StartPoint;
							double num65 = val5.X;
							val5 = val24.StartPoint;
							obj35.AddVertexAt(2, new RePoint(num65, val5.Y), Bulge(val24.StartAngle, val24.EndAngle), 0.0, 0.0);
							RePolyline obj36 = val20;
							val5 = val24.EndPoint;
							double num66 = val5.X;
							val5 = val24.EndPoint;
							obj36.AddVertexAt(3, new RePoint(num66, val5.Y), 0.0, 0.0, 0.0);
							num = 97;
							goto IL_10af;
							IL_0b86:
							RePolyline obj37 = val4;
							val5 = val23.StartPoint;
							double num67 = val5.X;
							val5 = val23.StartPoint;
							obj37.AddVertexAt(5, new RePoint(num67, val5.Y), 0.0, 0.0, 0.0);
							goto IL_0bd5;
							IL_22ef:
							if (_0087_0090_0089.Checked)
							{
								num = 83;
								goto IL_2308;
							}
							return;
							IL_0c48:
							RePolyline obj38 = val4;
							val5 = val6.EndPoint;
							double num68 = val5.X;
							val5 = val6.EndPoint;
							obj38.AddVertexAt(0, new RePoint(num68, val5.Y), 0.0 - Bulge(val6.StartAngle, val6.EndAngle), 0.0, 0.0);
							RePolyline obj39 = val4;
							val5 = val6.StartPoint;
							double num69 = val5.X;
							val5 = val6.StartPoint;
							obj39.AddVertexAt(1, new RePoint(num69, val5.Y), 0.0, 0.0, 0.0);
							RePolyline obj40 = val4;
							val5 = val23.EndPoint;
							double num70 = val5.X;
							val5 = val23.EndPoint;
							obj40.AddVertexAt(2, new RePoint(num70, val5.Y), 0.0 - Bulge(val23.StartAngle, val23.EndAngle), 0.0, 0.0);
							goto IL_0bf5;
							IL_0bf5:
							RePolyline obj41 = val4;
							val5 = val23.StartPoint;
							double num71 = val5.X;
							val5 = val23.StartPoint;
							obj41.AddVertexAt(3, new RePoint(num71, val5.Y), 0.0, 0.0, 0.0);
							num = 3;
							goto IL_0bd5;
							IL_0bd5:
							val4.Closed = false;
							num = 8;
							if (!FalseHelper())
							{
								goto IL_0859;
							}
							goto IL_1aee;
							IL_0859:
							Capture(val4, database);
							num17 += 4630;
							goto IL_0848;
							IL_0848:
							if (num17 <= 9260)
							{
								val25 = Drawing.Arc(val3, num11 - (double)num17, num13 + Math.PI / 2.0, num18);
								val23 = Drawing.Arc(val2, num5 + (double)num17, num6 - Math.PI / 2.0, num16);
								num = 95;
								goto IL_071e;
							}
							if (_0087_0090_0089.Checked)
							{
								num45 = (num6 + num13) / 2.0;
								num = 71;
								goto IL_202a;
							}
							return;
							IL_1795:
							RePolyline obj42 = val7;
							val5 = val18.EndPoint;
							double num72 = val5.X;
							val5 = val18.EndPoint;
							obj42.AddVertexAt(2, new RePoint(num72, val5.Y), 0.0 - Bulge(val18.StartAngle, val18.EndAngle), 0.0, 0.0);
							goto IL_17e8;
							IL_09d0:
							RePolyline obj43 = val4;
							val5 = val25.StartPoint;
							double num73 = val5.X;
							val5 = val25.StartPoint;
							obj43.AddVertexAt(0, new RePoint(num73, val5.Y), Bulge(val25.StartAngle, val25.EndAngle), 0.0, 0.0);
							num = 81;
							goto IL_0a2b;
							IL_2308:
							double num74 = (num6 + num13) / 2.0 + Math.PI;
							RePoint obj44 = new RePoint();
							obj44.X = obj2.X + num12 * Math.Cos(num74);
							obj44.Y = obj2.Y + num12 * Math.Sin(num74);
							double num75 = Math.Round(num12 / 1852.0, 1, MidpointRounding.AwayFromZero);
							Capture(new ReText
							{
								Height = num26,
								TextString = "D" /* string-offset:1644 */ + num75.ToString("0.0" /* string-offset:1636 */) + _0087_0090_008A.Text,
								HorizontalMode = (int)1,
								VerticalMode = (int)1,
								AlignmentPoint = obj44,
								Rotation = num74 - Math.PI / 2.0
							}, database);
							return;
							IL_071e:
							val6 = Drawing.Arc(obj2, num12 + (double)num17, num6 + num15, num13 - num10);
							val4 = new RePolyline();
							if (num17 < 0)
							{
								num = 52;
								if (!FalseHelper())
								{
									goto IL_055c;
								}
								goto IL_2276;
							}
							if (num17 == 0)
							{
								num = 58;
								goto IL_09d0;
							}
							if (num17 <= 0)
							{
								goto IL_0bd5;
							}
							goto IL_0c48;
							IL_0a2b:
							RePolyline obj45 = val4;
							val5 = val25.EndPoint;
							double num76 = val5.X;
							val5 = val25.EndPoint;
							obj45.AddVertexAt(1, new RePoint(num76, val5.Y), 0.0, 0.0, 0.0);
							num = 15;
							goto IL_0a7c;
							IL_055c:
							switch (num)
							{
							case 48:
								break;
							case 45:
								goto IL_04b0;
							case 11:
								goto IL_04c8;
							case 35:
								goto IL_053c;
							case 95:
								goto IL_071e;
							case 78:
								goto IL_074e;
							case 39:
								goto IL_075d;
							case 16:
								goto IL_07c5;
							case 17:
								goto IL_07da;
							case 75:
								goto IL_0848;
							case 8:
								goto IL_0859;
							case 52:
							{
								RePolyline obj48 = val4;
								val5 = val25.StartPoint;
								double num79 = val5.X;
								val5 = val25.StartPoint;
								obj48.AddVertexAt(0, new RePoint(num79, val5.Y), Bulge(val25.StartAngle, val25.EndAngle), 0.0, 0.0);
								num = 55;
								goto case 55;
							}
							case 55:
							{
								RePolyline obj49 = val4;
								val5 = val25.EndPoint;
								double num80 = val5.X;
								val5 = val25.EndPoint;
								obj49.AddVertexAt(1, new RePoint(num80, val5.Y), 0.0, 0.0, 0.0);
								RePolyline obj50 = val4;
								val5 = val6.EndPoint;
								double num81 = val5.X;
								val5 = val6.EndPoint;
								obj50.AddVertexAt(2, new RePoint(num81, val5.Y), 0.0 - Bulge(val6.StartAngle, val6.EndAngle), 0.0, 0.0);
								num = 6;
								goto case 6;
							}
							case 6:
							{
								RePolyline obj51 = val4;
								val5 = val6.StartPoint;
								double num82 = val5.X;
								val5 = val6.StartPoint;
								obj51.AddVertexAt(3, new RePoint(num82, val5.Y), 0.0, 0.0, 0.0);
								goto IL_0bd5;
							}
							case 58:
								goto IL_09d0;
							case 81:
								goto IL_0a2b;
							case 15:
								goto IL_0a7c;
							case 27:
								goto IL_0b2a;
							case 34:
								goto IL_0b86;
							case 3:
							case 98:
							case 102:
								goto IL_0bd5;
							case 65:
								goto IL_0bf5;
							case 23:
								goto IL_0c48;
							case 51:
								goto IL_0d3b;
							case 22:
								goto IL_0d6b;
							case 60:
								goto IL_0d80;
							case 82:
								goto IL_0df0;
							case 18:
								goto IL_0df7;
							case 43:
								goto IL_0e08;
							case 33:
								goto IL_0e70;
							case 24:
								goto IL_0eb8;
							case 2:
								goto IL_0f60;
							case 89:
								goto IL_0fbb;
							case 101:
								goto IL_100c;
							case 68:
							case 97:
								goto IL_10af;
							case 53:
								goto IL_10d4;
							case 41:
								goto IL_111e;
							case 32:
							case 38:
								goto IL_113d;
							case 30:
								goto IL_11f8;
							case 103:
								goto IL_12a1;
							case 67:
								goto IL_12ae;
							case 94:
								goto IL_12dc;
							case 54:
								goto IL_1326;
							case 10:
								goto IL_1391;
							case 70:
								goto IL_1401;
							case 79:
								goto IL_1411;
							case 100:
								goto IL_1422;
							default:
								num = 4;
								goto IL_154d;
							case 25:
							{
								RePolyline obj46 = val7;
								val5 = val8.EndPoint;
								double num77 = val5.X;
								val5 = val8.EndPoint;
								obj46.AddVertexAt(2, new RePoint(num77, val5.Y), 0.0 - Bulge(val8.StartAngle, val8.EndAngle), 0.0, 0.0);
								RePolyline obj47 = val7;
								val5 = val8.StartPoint;
								double num78 = val5.X;
								val5 = val8.StartPoint;
								obj47.AddVertexAt(3, new RePoint(num78, val5.Y), 0.0, 0.0, 0.0);
								goto IL_16db;
							}
							case 76:
								goto IL_14fb;
							case 4:
								goto IL_154d;
							case 47:
								goto IL_1595;
							case 42:
								goto IL_168c;
							case 77:
								goto IL_16db;
							case 57:
								goto IL_16f1;
							case 7:
								goto IL_1795;
							case 13:
								goto IL_17e8;
							case 37:
								goto IL_1835;
							case 0:
								goto IL_1863;
							case 1:
								goto IL_18bb;
							case 12:
								goto IL_1912;
							case 63:
								goto IL_19ac;
							case 104:
								goto IL_1a54;
							case 36:
								goto IL_1a9c;
							case 9:
								goto IL_1aee;
							case 73:
								goto IL_1b41;
							case 62:
							case 87:
							case 92:
								goto IL_1b9f;
							case 84:
								goto IL_1bc4;
							case 59:
								goto IL_1bf1;
							case 91:
								goto IL_1c10;
							case 26:
								goto IL_1c21;
							case 49:
								goto IL_1ca0;
							case 107:
								goto IL_1ce9;
							case 80:
								goto IL_1cfe;
							case 85:
								goto IL_1d6f;
							case 50:
								goto IL_1d78;
							case 66:
								goto IL_1d97;
							case 86:
								goto IL_1dae;
							case 93:
								goto IL_1de0;
							case 29:
								goto IL_1e0b;
							case 88:
								goto IL_1e2c;
							case 106:
								goto IL_1e63;
							case 56:
								goto IL_1e72;
							case 40:
								goto IL_1e9e;
							case 44:
								goto IL_1ec2;
							case 31:
								continue;
							case 46:
								goto end_IL_1ee0;
							case 19:
								goto end_IL_1ef0;
							case 96:
								goto end_IL_1efe;
							case 71:
								goto IL_202a;
							case 64:
								goto IL_2052;
							case 72:
								return;
							case 74:
								goto IL_208e;
							case 90:
								goto IL_20a3;
							case 5:
								goto IL_20bc;
							case 20:
								goto IL_20e6;
							case 99:
								goto IL_21b1;
							case 69:
								goto IL_21b8;
							case 21:
								goto IL_21e8;
							case 28:
								goto IL_2276;
							case 14:
							case 61:
								goto IL_22ef;
							case 83:
								goto IL_2308;
							case 105:
								return;
							case 108:
								return;
							}
							goto IL_0369;
							IL_20a3:
							if (_0087_0090_0089.Checked)
							{
								num = 5;
								goto IL_20bc;
							}
							return;
							IL_168c:
							RePolyline obj52 = val7;
							val5 = val18.StartPoint;
							double num83 = val5.X;
							val5 = val18.StartPoint;
							obj52.AddVertexAt(5, new RePoint(num83, val5.Y), 0.0, 0.0, 0.0);
							goto IL_16db;
							IL_202a:
							obj15 = new RePoint();
							obj15.X = obj2.X + num12 * Math.Cos(num45);
							num = 64;
							goto IL_2052;
							IL_2052:
							obj15.Y = obj2.Y + num12 * Math.Sin(num45);
							num44 = Math.Round(num12 / 1852.0, 1, MidpointRounding.AwayFromZero);
							num = 28;
							goto IL_2276;
							IL_1d97:
							num14 = num6;
							goto IL_1d99;
							IL_1912:
							RePolyline obj53 = val17;
							val5 = val16.StartPoint;
							double num84 = val5.X;
							val5 = val16.StartPoint;
							obj53.AddVertexAt(0, new RePoint(num84, val5.Y), Bulge(val16.StartAngle, val16.EndAngle), 0.0, 0.0);
							RePolyline obj54 = val17;
							val5 = val16.EndPoint;
							double num85 = val5.X;
							val5 = val16.EndPoint;
							obj54.AddVertexAt(1, new RePoint(num85, val5.Y), 0.0, 0.0, 0.0);
							goto IL_19ac;
							IL_19ac:
							RePolyline obj55 = val17;
							val5 = val15.StartPoint;
							double num86 = val5.X;
							val5 = val15.StartPoint;
							obj55.AddVertexAt(2, new RePoint(num86, val5.Y), Bulge(val15.StartAngle, val15.EndAngle), 0.0, 0.0);
							RePolyline obj56 = val17;
							val5 = val15.EndPoint;
							double num87 = val5.X;
							val5 = val15.EndPoint;
							obj56.AddVertexAt(3, new RePoint(num87, val5.Y), 0.0, 0.0, 0.0);
							num = 87;
							goto IL_1b9f;
							IL_18bb:
							RePolyline obj57 = val17;
							val5 = val15.StartPoint;
							double num88 = val5.X;
							val5 = val15.StartPoint;
							obj57.AddVertexAt(4, new RePoint(num88, val5.Y), Bulge(val15.StartAngle, val15.EndAngle), 0.0, 0.0);
							goto IL_1b41;
							IL_1863:
							RePolyline obj58 = val17;
							val5 = val13.EndPoint;
							double num89 = val5.X;
							val5 = val13.EndPoint;
							obj58.AddVertexAt(0, new RePoint(num89, val5.Y), 0.0 - Bulge(val13.StartAngle, val13.EndAngle), 0.0, 0.0);
							goto IL_1a54;
							IL_1a54:
							RePolyline obj59 = val17;
							val5 = val13.StartPoint;
							double num90 = val5.X;
							val5 = val13.StartPoint;
							obj59.AddVertexAt(1, new RePoint(num90, val5.Y), 0.0, 0.0, 0.0);
							goto IL_1a9c;
							IL_1a9c:
							RePolyline obj60 = val17;
							val5 = val16.StartPoint;
							double num91 = val5.X;
							val5 = val16.StartPoint;
							obj60.AddVertexAt(2, new RePoint(num91, val5.Y), Bulge(val16.StartAngle, val16.EndAngle), 0.0, 0.0);
							goto IL_1aee;
							IL_1aee:
							RePolyline obj61 = val17;
							val5 = val16.EndPoint;
							double num92 = val5.X;
							val5 = val16.EndPoint;
							obj61.AddVertexAt(3, new RePoint(num92, val5.Y), 0.0, 0.0, 0.0);
							num = 92;
							goto IL_1b9f;
							IL_111e:
							obj2 = new RePoint();
							obj3 = new RePoint();
							num = 106;
							if (!TrueHelper())
							{
								goto IL_113d;
							}
							goto IL_1e63;
							IL_1e63:
							obj4 = new RePoint();
							num = 56;
							goto IL_1e72;
							IL_1e72:
							obj2.X = Convert.ToDouble(_0087_008F_009A.Text);
							obj2.Y = Convert.ToDouble(_0087_008F_009B.Text);
							goto IL_1e9e;
							IL_0e70:
							RePolyline obj62 = val20;
							val5 = val21.StartPoint;
							double num93 = val5.X;
							val5 = val21.StartPoint;
							obj62.AddVertexAt(1, new RePoint(num93, val5.Y), 0.0, 0.0, 0.0);
							goto IL_0eb8;
							IL_0eb8:
							RePolyline obj63 = val20;
							val5 = val22.StartPoint;
							double num94 = val5.X;
							val5 = val22.StartPoint;
							obj63.AddVertexAt(2, new RePoint(num94, val5.Y), Bulge(val22.StartAngle, val22.EndAngle), 0.0, 0.0);
							RePolyline obj64 = val20;
							val5 = val22.EndPoint;
							double num95 = val5.X;
							val5 = val22.EndPoint;
							obj64.AddVertexAt(3, new RePoint(num95, val5.Y), 0.0, 0.0, 0.0);
							num = 68;
							goto IL_10af;
							IL_0d6b:
							num7 = Math.Atan(num5 / num3);
							num = 60;
							goto IL_0d80;
							continue;
							end_IL_1ee0:
							break;
						}
						continue;
						end_IL_1ef0:
						break;
					}
					continue;
					end_IL_1efe:
					break;
				}
			}
		}

		private void EvaluateCore()
		{
			int num = 7;
			List<DmeEvaluation> list = default(List<DmeEvaluation>);
			if (!FalseHelper())
			{
				int num11 = default(int);
				InputCheck obj2 = default(InputCheck);
				RePoint obj8 = default(RePoint);
				RePoint obj9 = default(RePoint);
				RePoint obj = default(RePoint);
				double num8 = default(double);
				double num9 = default(double);
				InputCheck[] array = default(InputCheck[]);
				double num3 = default(double);
				double num4 = default(double);
				double num5 = default(double);
				double num6 = default(double);
				double num7 = default(double);
				int num2 = default(int);
				List<RePoint>.Enumerator enumerator = default(List<RePoint>.Enumerator);
				RePoint obj4 = default(RePoint);
				RePoint obj5 = default(RePoint);
				double num13 = default(double);
				double num14 = default(double);
				double num15 = default(double);
				double num16 = default(double);
				RePoint obj6 = default(RePoint);
				DmeEvaluation obj7 = default(DmeEvaluation);
				bool flag = default(bool);
				while (true)
				{
					double num17;
					int num10;
					switch (num)
					{
					case 3:
					case 25:
						num11 = 0;
						goto IL_004f;
					case 4:
						if (CheckInput(obj2.Value, obj2.Message))
						{
							num11++;
							goto IL_004f;
						}
						return;
					case 20:
						obj8.X = Convert.ToDouble(_0087_008F_0093.Text);
						num = 5;
						if (!TrueHelper())
						{
							return;
						}
						goto case 5;
					case 5:
						obj8.Y = Convert.ToDouble(_0087_008F_0094.Text);
						obj9.X = Convert.ToDouble(_0087_008F_008D.Text);
						obj9.Y = Convert.ToDouble(_0087_008F_008C.Text);
						num = 12;
						goto case 12;
					case 16:
						obj = new RePoint();
						obj8 = new RePoint();
						num = 0;
						goto case 0;
					case 0:
						obj9 = new RePoint();
						num = 15;
						if (TrueHelper())
						{
							continue;
						}
						goto case 12;
					case 12:
						num8 = Math.Atan2(obj9.Y - obj.Y, obj9.X - obj.X);
						goto case 6;
					case 6:
						num9 = Math.Atan2(obj8.Y - obj.Y, obj8.X - obj.X);
						goto case 9;
					case 9:
						num8 = ((num8 < 0.0) ? (num8 + Math.PI * 2.0) : num8);
						if (!(num9 < 0.0))
						{
							goto case 21;
						}
						num17 = num9 + Math.PI * 2.0;
						goto IL_0184;
					case 21:
						num17 = num9;
						goto IL_0184;
					case 15:
						obj.X = Convert.ToDouble(_0087_008F_009A.Text);
						obj.Y = Convert.ToDouble(_0087_008F_009B.Text);
						num = 20;
						goto case 20;
					case 7:
						if (true /* original-file-bool-offset:432 */)
						{
							num = 11;
							goto case 11;
						}
						return;
					case 11:
						if (_0087_008E_009B != null)
						{
							if (_0087_008E_009B.Count == 0)
							{
								return;
							}
							array = new InputCheck[7]
							{
								new InputCheck(_0087_008F_009A, "导航台 X坐标不能为空。" /* string-offset:3552 */),
								new InputCheck(_0087_008F_009B, "导航台 Y坐标不能为空。" /* string-offset:3556 */),
								new InputCheck(_0087_008F_0093, "IF点 X坐标不能为空。" /* string-offset:3560 */),
								new InputCheck(_0087_008F_0094, "IF点 Y坐标不能为空。" /* string-offset:3564 */),
								new InputCheck(_0087_008F_008D, "IAF点 X坐标不能为空}。" /* string-offset:3568 */),
								new InputCheck(_0087_008F_008C, "IAF点 Y坐标不能为空。" /* string-offset:3572 */),
								new InputCheck(_0087_008F_009E, "超障余度不能为空。" /* string-offset:3576 */)
							};

							if (!FalseHelper())
							{
								num = 25;
								if (!FalseHelper())
								{
									goto case 3;
								}
								goto case 7;
							}
							num = 8;
							if (TrueHelper())
							{
								continue;
							}
							goto case 9;
						}
						num = 24;
						return;
					default:
						num = 21;
						goto case 21;
					case 24:
						return;
					case 19:
						return;
					case 26:
						num3 = 3704.0;
						num4 = num5 + num3;
						num6 = (2.0 * num5 * num3 + 13719616.0) / (2.0 * num5 + 7408.0);
						num = 14;
						goto case 14;
					case 14:
						num7 = (2.0 * num5 * num3 + 3.0 * num3 * num3) / (2.0 * num5 + 2.0 * num3);
						goto case 10;
					case 10:
						Convert.ToDouble(_0087_008F_009E.Text);
						num = 13;
						goto case 13;
					case 13:
						if (num8 < num9)
						{
							goto case 1;
						}
						goto IL_046d;
					case 1:
						if (num9 - num8 > Math.PI)
						{
							goto IL_046d;
						}
						num10 = 1;
						goto IL_048d;
					case 2:
						num10 = ((num8 - num9 > Math.PI) ? 1 : 0);
						goto IL_048d;
					case 23:
						list = new List<DmeEvaluation>();
						goto case 8;
					case 8:
					case 22:
						num2 = 1;
						enumerator = _0087_008E_009B.GetEnumerator();
						num = 18;
						goto case 18;
					case 18:
						try
						{
							while (enumerator.MoveNext())
							{
								RePoint obj3 = Imported(enumerator.Current,num2.ToString());
								int num12 = 11;
								if (!FalseHelper())
								{
									goto IL_05b6;
								}
								goto IL_0a9b;
								IL_08b6:
								obj4 = Sector(new RePoint(obj3.X, obj3.Y), obj5, num6, num13, Normalize(num9 + Math.PI / 2.0), 9260.0, symmetric: false);
								if (obj4.Name == "out" /* string-offset:1556 */)
								{
									obj4 = Sector(new RePoint(obj3.X, obj3.Y), obj, num4, num14, num13, 9260.0, symmetric: true);
								}
								goto IL_0949;
								IL_0a9b:
								obj5 = new RePoint(obj.X + (num5 + num3 - num6) * Math.Cos(num9 + num15), obj.Y + (num5 + num3 - num6) * Math.Sin(num9 + num15));
								goto IL_0a4f;
								IL_0a4f:
								num13 = Math.Atan2(obj5.Y - obj.Y, obj5.X - obj.X);
								num14 = Normalize(num14);
								num12 = 18;
								if (FalseHelper())
								{
									goto IL_09b4;
								}
								goto IL_0a29;
								IL_0a29:
								num13 = Normalize(num13);
								Angles(num14, num13, num16, num15);
								goto IL_09b4;
								IL_09b4:
								obj4 = Sector(new RePoint(obj3.X, obj3.Y), obj6, num7, Normalize(num8 + Math.PI / 2.0), Normalize(num14 + Math.PI), 9260.0, symmetric: false);
								if (obj4.Name == "out" /* string-offset:1556 */)
								{
									obj4 = Sector(new RePoint(obj3.X, obj3.Y), obj5, num6, Normalize(num9 - Math.PI / 2.0), num13, 9260.0, symmetric: false);
									goto IL_06c4;
								}
								goto IL_0949;
								IL_06f2:
								obj4 = Sector(new RePoint(obj3.X, obj3.Y), obj, num4, num13, num14, 9260.0, symmetric: true);
								num12 = 15;
								if (!FalseHelper())
								{
									goto IL_0949;
								}
								goto IL_0a9b;
								IL_0949:
								if (!(obj4.Name != "out" /* string-offset:1556 */))
								{
									continue;
								}
								num12 = 2;
								goto IL_06a2;
								IL_089b:
								if (obj4.Name == "out" /* string-offset:1556 */)
								{
									goto IL_08b6;
								}
								goto IL_0949;
								IL_06a2:
								obj7 = new DmeEvaluation(obj3);
								obj7.Area = obj4.Name;
								num12 = 10;
								goto IL_065f;
								IL_065f:
								obj7.MOC = obj4.Z * 300.0;
								obj7.OCA = obj7.Z + obj7.MOC;
								num12 = 0;
								if (TrueHelper())
								{
									goto IL_0620;
								}
								goto IL_0ae4;
								IL_0620:
								obj7.RoundedOca = Math.Ceiling(obj7.OCA / 5.0) * 5.0;
								num12 = 3;
								if (TrueHelper())
								{
									goto IL_05b6;
								}
								goto IL_0a4f;
								IL_05b6:
								while (true)
								{
									switch (num12)
									{
									case 17:
										obj4 = new RePoint();
										if (!flag)
										{
											obj6 = new RePoint(obj.X + (num4 + num7) * Math.Cos(num8 - num16), obj.Y + (num4 + num7) * Math.Sin(num8 - num16));
											goto case 5;
										}
										obj6 = new RePoint(obj.X + (num4 + num7) * Math.Cos(num8 + num16), obj.Y + (num4 + num7) * Math.Sin(num8 + num16));
										num12 = 1;
										goto case 1;
									case 5:
										num14 = Math.Atan2(obj6.Y - obj.Y, obj6.X - obj.X);

										if (FalseHelper())
										{
											num12 = 12;
											if (!FalseHelper())
											{
												continue;
											}
											goto IL_09b4;
										}
										num12 = 8;
										goto IL_0a9b;
									case 11:
										num2++;
										num12 = 17;
										goto case 17;
									case 0:
										break;
									case 10:
										goto IL_065f;
									case 2:
										goto IL_06a2;
									case 12:
									case 13:
										goto IL_06c4;
									case 4:
										goto IL_06f2;
									case 1:
										num14 = Math.Atan2(obj6.Y - obj.Y, obj6.X - obj.X);
										num12 = 20;
										goto case 20;
									case 20:
										obj5 = new RePoint(obj.X + (num5 + num3 - num6) * Math.Cos(num9 - num15), obj.Y + (num5 + num3 - num6) * Math.Sin(num9 - num15));
										num13 = Math.Atan2(obj5.Y - obj.Y, obj5.X - obj.X);
										num14 = Normalize(num14);
										num12 = 14;
										goto case 14;
									case 14:
										num13 = Normalize(num13);
										num12 = 16;
										goto case 16;
									case 16:
										obj4 = Sector(new RePoint(obj3.X, obj3.Y), obj6, num7, Normalize(num14 - Math.PI), Normalize(num8 - Math.PI / 2.0), 9260.0, symmetric: false);
										num12 = 19;
										goto IL_089b;
									case 19:
										goto IL_089b;
									case 6:
										goto IL_08b6;
									case 15:
										goto IL_0949;
									case 21:
										goto IL_09b4;
									case 18:
										goto IL_0a29;
									default:
										num12 = 7;
										goto IL_0a4f;
									case 7:
										goto IL_0a4f;
									case 8:
									case 9:
										goto IL_0a9b;
									case 3:
										goto IL_0ae4;
									case 22:
										goto IL_0af6;
									}
									break;
								}
								goto IL_0620;
								IL_0ae4:
								list.Add(obj7);
								num12 = 22;
								continue;
								IL_06c4:
								if (obj4.Name == "out" /* string-offset:1556 */)
								{
									num12 = 4;
									if (TrueHelper())
									{
										goto IL_06f2;
									}
									goto IL_089b;
								}
								goto IL_0949;
								IL_0af6:;
							}
						}
						finally
						{
							((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
						}
						_0087_008F_0089.Text = "已评估" /* string-offset:2812 */ + _0087_008E_009B.Count + "个障碍物。" /* string-offset:2816 */;
						_0087_008F_009D.Text = list.Count + "个障碍物在范围内" /* string-offset:2820 */;
						break;
					case 17:
						break;
					case 27:
						return;
						IL_004f:
						if (num11 < array.Length)
						{
							obj2 = array[num11];
							num = 4;
							goto case 4;
						}
						num = 16;
						if (FalseHelper())
						{
							goto case 20;
						}
						goto case 16;
						IL_046d:
						if (num8 > num9)
						{
							num = 2;
							goto case 2;
						}
						num10 = 0;
						goto IL_048d;
						IL_048d:
						flag = (byte)num10 != 0;
						num16 = Math.Asin(num7 / (num4 + num7));
						num15 = Math.Atan(num6 / num5);
						num = 23;
						goto case 23;
						IL_0184:
						num9 = num17;
						if (num8 == num9)
						{
							num = 19;
							if (TrueHelper())
							{
								continue;
							}
							goto case 13;
						}
						num5 = RePoint.Distance(obj8, obj);
						goto case 26;
					}
					break;
				}
			}
			list = list.OrderByDescending((DmeEvaluation o) => o.OCA).ToList();
			Results=list;
		}

}
