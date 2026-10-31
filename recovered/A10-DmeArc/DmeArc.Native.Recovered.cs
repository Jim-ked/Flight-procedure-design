#if ACAD2026_TEST
using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Application=Autodesk.AutoCAD.ApplicationServices.Core.Application;
// ACAD2026 compatibility compile only. Full original Arc/Polyline construction order.
// Original MethodDef: 0x060002DC; Original RVA: 0x37D8C.
public partial class DmeArcRecovered {
 static Point3d AsCad(RePoint p){return new Point3d(p.X,p.Y,p.Z);}
		public void DrawToCad()
		{
			int num = 96;
			InputCheck obj = default(InputCheck);
			Point3d val = default(Point3d);
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
			Point3d val2 = default(Point3d);
			double num16 = default(double);
			int num17 = default(int);
			Point3d val3 = default(Point3d);
			double num18 = default(double);
			double num19 = default(double);
			Polyline val4 = default(Polyline);
			Arc val6 = default(Arc);
			Database database = default(Database);
			Polyline val7 = default(Polyline);
			Arc val8 = default(Arc);
			Point3d val9 = default(Point3d);
			double num24 = default(double);
			double num25 = default(double);
			double num26 = default(double);
			double num27 = default(double);
			Point3d val10 = default(Point3d);
			Point3d val11 = default(Point3d);
			double num28 = default(double);
			int num29 = default(int);
			double num30 = default(double);
			RePoint obj9 = default(RePoint);
			double num32 = default(double);
			double num33 = default(double);
			Point3d val12 = default(Point3d);
			double num34 = default(double);
			int num35 = default(int);
			Arc val13 = default(Arc);
			double num36 = default(double);
			Point3d val14 = default(Point3d);
			double num37 = default(double);
			Arc val15 = default(Arc);
			Arc val16 = default(Arc);
			Polyline val17 = default(Polyline);
			double num42 = default(double);
			RePoint obj14 = default(RePoint);
			double num44 = default(double);
			RePoint obj15 = default(RePoint);
			double num45 = default(double);
			Arc val18 = default(Arc);
			Arc val19 = default(Arc);
			Polyline val20 = default(Polyline);
			Arc val21 = default(Arc);
			Arc val22 = default(Arc);
			Arc val23 = default(Arc);
			Arc val24 = default(Arc);
			Arc val25 = default(Arc);
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
							val = new Point3d(obj2.X + (num3 + num4 - num5) * Math.Cos(num6 - num7), obj2.Y + (num3 + num4 - num5) * Math.Sin(num6 - num7), 0.0);
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
							val2 = new Point3d(obj2.X + (num3 + num4 - num5) * Math.Cos(num6 + num15), obj2.Y + (num3 + num4 - num5) * Math.Sin(num6 + num15), 0.0);
							num16 = Math.Atan2(val2.Y - obj2.Y, val2.X - obj2.X);
							num17 = -9260;
							goto IL_0848;
							IL_075d:
							val3 = new Point3d(obj2.X + (num12 + num11) * Math.Cos(num13 - num10), obj2.Y + (num12 + num11) * Math.Sin(num13 - num10), 0.0);
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
							Polyline obj5 = val4;
							Point3d val5 = ((Curve)val6).EndPoint;
							double num20 = val5.X;
							val5 = ((Curve)val6).EndPoint;
							obj5.AddVertexAt(2, new Point2d(num20, val5.Y), 0.0 - Bulge(val6.StartAngle, val6.EndAngle), 0.0, 0.0);
							Polyline obj6 = val4;
							val5 = ((Curve)val6).StartPoint;
							double num21 = val5.X;
							val5 = ((Curve)val6).StartPoint;
							obj6.AddVertexAt(3, new Point2d(num21, val5.Y), 0.0, 0.0, 0.0);
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
								database = Application.DocumentManager.MdiActiveDocument.Database;
								num = 50;
								goto IL_1d78;
							}
							num = 72;
							return;
							IL_16f1:
							Polyline obj7 = val7;
							val5 = ((Curve)val8).EndPoint;
							double num22 = val5.X;
							val5 = ((Curve)val8).EndPoint;
							obj7.AddVertexAt(0, new Point2d(num22, val5.Y), 0.0 - Bulge(val8.StartAngle, val8.EndAngle), 0.0, 0.0);
							Polyline obj8 = val7;
							val5 = ((Curve)val8).StartPoint;
							double num23 = val5.X;
							val5 = ((Curve)val8).StartPoint;
							obj8.AddVertexAt(1, new Point2d(num23, val5.Y), 0.0, 0.0, 0.0);
							num = 7;
							goto IL_1795;
							IL_1326:
							val9 = new Point3d(obj2.X + (num12 + num11) * Math.Cos(num13 - num19), obj2.Y + (num12 + num11) * Math.Sin(num13 - num19), 0.0);
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
								val10 = new Point3d(obj2.X + (num12 + num11) * Math.Cos(num13 + num27), obj2.Y + (num12 + num11) * Math.Sin(num13 + num27), 0.0);
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
							val11 = new Point3d(obj2.X + (num3 + num4 - num5) * Math.Cos(num6 + num25), obj2.Y + (num3 + num4 - num5) * Math.Sin(num6 + num25), 0.0);
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
							CalcuCadRecovered.AppendWithoutMetadata((Entity)new DBText
							{
								Height = num26,
								TextString = "D" /* string-offset:1644 */ + num31.ToString("0.0" /* string-offset:1636 */) + _0087_0090_008A.Text,
								HorizontalMode = (TextHorizontalMode)1,
								VerticalMode = (TextVerticalMode)1,
								AlignmentPoint = AsCad(obj9),
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
							val12 = new Point3d(obj2.X + (num3 + num4 - num5) * Math.Cos(num6 - num33), obj2.Y + (num3 + num4 - num5) * Math.Sin(num6 - num33), 0.0);
							num34 = Math.Atan2(val12.Y - obj2.Y, val12.X - obj2.X);
							num35 = -9260;
							goto IL_1c10;
							IL_1c10:
							if (num35 <= 9260)
							{
								val13 = new Arc(val10, num11 - (double)num35, num32, num13 - Math.PI / 2.0);
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
							val14 = new Point3d(obj2.X + (num12 + num11) * Math.Cos(num13 + num36), obj2.Y + (num12 + num11) * Math.Sin(num13 + num36), 0.0);
							num37 = Math.Atan2(obj2.Y - val14.Y, obj2.X - val14.X);
							num = 22;
							if (TrueHelper())
							{
								goto IL_055c;
							}
							goto IL_208e;
							IL_1bf1:
							val15 = new Arc(val12, num5 + (double)num35, num34, num6 + Math.PI / 2.0);
							goto IL_1bc4;
							IL_1bc4:
							val16 = new Arc(AsCad(obj2), num12 + (double)num35, num13 + num27, num6 - num33);
							val17 = new Polyline();
							if (num35 >= 0)
							{
								if (num35 == 0)
								{
									Polyline obj10 = val17;
									val5 = ((Curve)val13).EndPoint;
									double num38 = val5.X;
									val5 = ((Curve)val13).EndPoint;
									obj10.AddVertexAt(0, new Point2d(num38, val5.Y), 0.0 - Bulge(val13.StartAngle, val13.EndAngle), 0.0, 0.0);
									Polyline obj11 = val17;
									val5 = ((Curve)val13).StartPoint;
									double num39 = val5.X;
									val5 = ((Curve)val13).StartPoint;
									obj11.AddVertexAt(1, new Point2d(num39, val5.Y), 0.0, 0.0, 0.0);
									Polyline obj12 = val17;
									val5 = ((Curve)val16).StartPoint;
									double num40 = val5.X;
									val5 = ((Curve)val16).StartPoint;
									obj12.AddVertexAt(2, new Point2d(num40, val5.Y), Bulge(val16.StartAngle, val16.EndAngle), 0.0, 0.0);
									Polyline obj13 = val17;
									val5 = ((Curve)val16).EndPoint;
									double num41 = val5.X;
									val5 = ((Curve)val16).EndPoint;
									obj13.AddVertexAt(3, new Point2d(num41, val5.Y), 0.0, 0.0, 0.0);
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
							CalcuCadRecovered.AppendWithoutMetadata((Entity)new DBText
							{
								Height = num26,
								TextString = "D" /* string-offset:1644 */ + num43.ToString("0.0" /* string-offset:1636 */) + _0087_0090_008A.Text,
								HorizontalMode = (TextHorizontalMode)1,
								VerticalMode = (TextVerticalMode)1,
								AlignmentPoint = AsCad(obj14),
								Rotation = num42 - Math.PI / 2.0
							}, database);
							return;
							IL_2276:
							CalcuCadRecovered.AppendWithoutMetadata((Entity)new DBText
							{
								Height = num26,
								TextString = "D" /* string-offset:1644 */ + num44.ToString("0.0" /* string-offset:1636 */) + _0087_0090_008A.Text,
								HorizontalMode = (TextHorizontalMode)1,
								VerticalMode = (TextVerticalMode)1,
								AlignmentPoint = AsCad(obj15),
								Rotation = num45 - Math.PI / 2.0
							}, database);
							return;
							IL_1b9f:
							val17.Closed = false;
							goto IL_1835;
							IL_1835:
							CalcuCadRecovered.AppendWithoutMetadata((Entity)(object)val17, database);
							num35 += 4630;
							num = 91;
							if (FalseHelper())
							{
								goto IL_17e8;
							}
							goto IL_1c10;
							IL_17e8:
							Polyline obj16 = val7;
							val5 = ((Curve)val18).StartPoint;
							double num46 = val5.X;
							val5 = ((Curve)val18).StartPoint;
							obj16.AddVertexAt(3, new Point2d(num46, val5.Y), 0.0, 0.0, 0.0);
							goto IL_16db;
							IL_16db:
							val7.Closed = false;
							num = 100;
							goto IL_1422;
							IL_1422:
							CalcuCadRecovered.AppendWithoutMetadata((Entity)(object)val7, database);
							num29 += 4630;
							goto IL_1411;
							IL_1411:
							if (num29 <= 9260)
							{
								val19 = new Arc(val9, num11 - (double)num29, num13 + Math.PI / 2.0, num24);
								num = 94;
								goto IL_12dc;
							}
							goto IL_22ef;
							IL_14fb:
							Polyline obj17 = val7;
							val5 = ((Curve)val19).StartPoint;
							double num47 = val5.X;
							val5 = ((Curve)val19).StartPoint;
							obj17.AddVertexAt(0, new Point2d(num47, val5.Y), Bulge(val19.StartAngle, val19.EndAngle), 0.0, 0.0);
							goto IL_154d;
							IL_12dc:
							val18 = new Arc(val11, num5 + (double)num29, num6 - Math.PI / 2.0, num28);
							num = 67;
							goto IL_12ae;
							IL_12ae:
							val8 = new Arc(AsCad(obj2), num12 + (double)num29, num6 + num25, num13 - num19);
							val7 = new Polyline();
							num = 103;
							goto IL_12a1;
							IL_12a1:
							if (num29 < 0)
							{
								Polyline obj18 = val7;
								val5 = ((Curve)val19).StartPoint;
								double num48 = val5.X;
								val5 = ((Curve)val19).StartPoint;
								obj18.AddVertexAt(0, new Point2d(num48, val5.Y), Bulge(val19.StartAngle, val19.EndAngle), 0.0, 0.0);
								Polyline obj19 = val7;
								val5 = ((Curve)val19).EndPoint;
								double num49 = val5.X;
								val5 = ((Curve)val19).EndPoint;
								obj19.AddVertexAt(1, new Point2d(num49, val5.Y), 0.0, 0.0, 0.0);
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
							Polyline obj20 = val7;
							val5 = ((Curve)val19).EndPoint;
							double num50 = val5.X;
							val5 = ((Curve)val19).EndPoint;
							obj20.AddVertexAt(1, new Point2d(num50, val5.Y), 0.0, 0.0, 0.0);
							goto IL_1595;
							IL_11f8:
							Polyline obj21 = val20;
							val5 = ((Curve)val21).EndPoint;
							double num51 = val5.X;
							val5 = ((Curve)val21).EndPoint;
							obj21.AddVertexAt(0, new Point2d(num51, val5.Y), 0.0 - Bulge(val21.StartAngle, val21.EndAngle), 0.0, 0.0);
							Polyline obj22 = val20;
							val5 = ((Curve)val21).StartPoint;
							double num52 = val5.X;
							val5 = ((Curve)val21).StartPoint;
							obj22.AddVertexAt(1, new Point2d(num52, val5.Y), 0.0, 0.0, 0.0);
							num = 48;
							goto IL_0369;
							IL_0369:
							Polyline obj23 = val20;
							val5 = ((Curve)val22).StartPoint;
							double num53 = val5.X;
							val5 = ((Curve)val22).StartPoint;
							obj23.AddVertexAt(2, new Point2d(num53, val5.Y), Bulge(val22.StartAngle, val22.EndAngle), 0.0, 0.0);
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
							Polyline obj24 = val4;
							val5 = ((Curve)val23).EndPoint;
							double num54 = val5.X;
							val5 = ((Curve)val23).EndPoint;
							obj24.AddVertexAt(4, new Point2d(num54, val5.Y), 0.0 - Bulge(val23.StartAngle, val23.EndAngle), 0.0, 0.0);
							num = 34;
							goto IL_0b86;
							IL_113d:
							Polyline obj25 = val20;
							val5 = ((Curve)val22).EndPoint;
							double num55 = val5.X;
							val5 = ((Curve)val22).EndPoint;
							obj25.AddVertexAt(3, new Point2d(num55, val5.Y), 0.0, 0.0, 0.0);
							Polyline obj26 = val20;
							val5 = ((Curve)val24).StartPoint;
							double num56 = val5.X;
							val5 = ((Curve)val24).StartPoint;
							obj26.AddVertexAt(4, new Point2d(num56, val5.Y), Bulge(val24.StartAngle, val24.EndAngle), 0.0, 0.0);
							num = 53;
							goto IL_10d4;
							IL_10d4:
							Polyline obj27 = val20;
							val5 = ((Curve)val24).EndPoint;
							double num57 = val5.X;
							val5 = ((Curve)val24).EndPoint;
							obj27.AddVertexAt(5, new Point2d(num57, val5.Y), 0.0, 0.0, 0.0);
							goto IL_10af;
							IL_10af:
							val20.Closed = false;
							CalcuCadRecovered.AppendWithoutMetadata((Entity)(object)val20, database);
							num = 43;
							goto IL_0e08;
							IL_0e08:
							num9 += 4630;
							goto IL_0df7;
							IL_0df7:
							if (num9 <= 9260)
							{
								val21 = new Arc(val14, num11 - (double)num9, num37, num13 - Math.PI / 2.0);
								val24 = new Arc(val, num5 + (double)num9, num8, num6 + Math.PI / 2.0);
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
							Polyline obj28 = val17;
							val5 = ((Curve)val15).EndPoint;
							double num58 = val5.X;
							val5 = ((Curve)val15).EndPoint;
							obj28.AddVertexAt(5, new Point2d(num58, val5.Y), 0.0, 0.0, 0.0);
							goto IL_1b9f;
							IL_0f60:
							Polyline obj29 = val20;
							val5 = ((Curve)val22).StartPoint;
							double num59 = val5.X;
							val5 = ((Curve)val22).StartPoint;
							obj29.AddVertexAt(0, new Point2d(num59, val5.Y), Bulge(val22.StartAngle, val22.EndAngle), 0.0, 0.0);
							num = 89;
							goto IL_0fbb;
							IL_1595:
							Polyline obj30 = val7;
							val5 = ((Curve)val8).EndPoint;
							double num60 = val5.X;
							val5 = ((Curve)val8).EndPoint;
							obj30.AddVertexAt(2, new Point2d(num60, val5.Y), 0.0 - Bulge(val8.StartAngle, val8.EndAngle), 0.0, 0.0);
							Polyline obj31 = val7;
							val5 = ((Curve)val8).StartPoint;
							double num61 = val5.X;
							val5 = ((Curve)val8).StartPoint;
							obj31.AddVertexAt(3, new Point2d(num61, val5.Y), 0.0, 0.0, 0.0);
							Polyline obj32 = val7;
							val5 = ((Curve)val18).EndPoint;
							double num62 = val5.X;
							val5 = ((Curve)val18).EndPoint;
							obj32.AddVertexAt(4, new Point2d(num62, val5.Y), 0.0 - Bulge(val18.StartAngle, val18.EndAngle), 0.0, 0.0);
							num = 42;
							goto IL_168c;
							IL_0d3b:
							val22 = new Arc(AsCad(obj2), num12 + (double)num9, num13 + num36, num6 - num7);
							val20 = new Polyline();
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
							Polyline obj33 = val20;
							val5 = ((Curve)val21).EndPoint;
							double num63 = val5.X;
							val5 = ((Curve)val21).EndPoint;
							obj33.AddVertexAt(0, new Point2d(num63, val5.Y), 0.0 - Bulge(val21.StartAngle, val21.EndAngle), 0.0, 0.0);
							num = 33;
							goto IL_0e70;
							IL_0fbb:
							Polyline obj34 = val20;
							val5 = ((Curve)val22).EndPoint;
							double num64 = val5.X;
							val5 = ((Curve)val22).EndPoint;
							obj34.AddVertexAt(1, new Point2d(num64, val5.Y), 0.0, 0.0, 0.0);
							num = 101;
							goto IL_100c;
							IL_100c:
							Polyline obj35 = val20;
							val5 = ((Curve)val24).StartPoint;
							double num65 = val5.X;
							val5 = ((Curve)val24).StartPoint;
							obj35.AddVertexAt(2, new Point2d(num65, val5.Y), Bulge(val24.StartAngle, val24.EndAngle), 0.0, 0.0);
							Polyline obj36 = val20;
							val5 = ((Curve)val24).EndPoint;
							double num66 = val5.X;
							val5 = ((Curve)val24).EndPoint;
							obj36.AddVertexAt(3, new Point2d(num66, val5.Y), 0.0, 0.0, 0.0);
							num = 97;
							goto IL_10af;
							IL_0b86:
							Polyline obj37 = val4;
							val5 = ((Curve)val23).StartPoint;
							double num67 = val5.X;
							val5 = ((Curve)val23).StartPoint;
							obj37.AddVertexAt(5, new Point2d(num67, val5.Y), 0.0, 0.0, 0.0);
							goto IL_0bd5;
							IL_22ef:
							if (_0087_0090_0089.Checked)
							{
								num = 83;
								goto IL_2308;
							}
							return;
							IL_0c48:
							Polyline obj38 = val4;
							val5 = ((Curve)val6).EndPoint;
							double num68 = val5.X;
							val5 = ((Curve)val6).EndPoint;
							obj38.AddVertexAt(0, new Point2d(num68, val5.Y), 0.0 - Bulge(val6.StartAngle, val6.EndAngle), 0.0, 0.0);
							Polyline obj39 = val4;
							val5 = ((Curve)val6).StartPoint;
							double num69 = val5.X;
							val5 = ((Curve)val6).StartPoint;
							obj39.AddVertexAt(1, new Point2d(num69, val5.Y), 0.0, 0.0, 0.0);
							Polyline obj40 = val4;
							val5 = ((Curve)val23).EndPoint;
							double num70 = val5.X;
							val5 = ((Curve)val23).EndPoint;
							obj40.AddVertexAt(2, new Point2d(num70, val5.Y), 0.0 - Bulge(val23.StartAngle, val23.EndAngle), 0.0, 0.0);
							goto IL_0bf5;
							IL_0bf5:
							Polyline obj41 = val4;
							val5 = ((Curve)val23).StartPoint;
							double num71 = val5.X;
							val5 = ((Curve)val23).StartPoint;
							obj41.AddVertexAt(3, new Point2d(num71, val5.Y), 0.0, 0.0, 0.0);
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
							CalcuCadRecovered.AppendWithoutMetadata((Entity)(object)val4, database);
							num17 += 4630;
							goto IL_0848;
							IL_0848:
							if (num17 <= 9260)
							{
								val25 = new Arc(val3, num11 - (double)num17, num13 + Math.PI / 2.0, num18);
								val23 = new Arc(val2, num5 + (double)num17, num6 - Math.PI / 2.0, num16);
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
							Polyline obj42 = val7;
							val5 = ((Curve)val18).EndPoint;
							double num72 = val5.X;
							val5 = ((Curve)val18).EndPoint;
							obj42.AddVertexAt(2, new Point2d(num72, val5.Y), 0.0 - Bulge(val18.StartAngle, val18.EndAngle), 0.0, 0.0);
							goto IL_17e8;
							IL_09d0:
							Polyline obj43 = val4;
							val5 = ((Curve)val25).StartPoint;
							double num73 = val5.X;
							val5 = ((Curve)val25).StartPoint;
							obj43.AddVertexAt(0, new Point2d(num73, val5.Y), Bulge(val25.StartAngle, val25.EndAngle), 0.0, 0.0);
							num = 81;
							goto IL_0a2b;
							IL_2308:
							double num74 = (num6 + num13) / 2.0 + Math.PI;
							RePoint obj44 = new RePoint();
							obj44.X = obj2.X + num12 * Math.Cos(num74);
							obj44.Y = obj2.Y + num12 * Math.Sin(num74);
							double num75 = Math.Round(num12 / 1852.0, 1, MidpointRounding.AwayFromZero);
							CalcuCadRecovered.AppendWithoutMetadata((Entity)new DBText
							{
								Height = num26,
								TextString = "D" /* string-offset:1644 */ + num75.ToString("0.0" /* string-offset:1636 */) + _0087_0090_008A.Text,
								HorizontalMode = (TextHorizontalMode)1,
								VerticalMode = (TextVerticalMode)1,
								AlignmentPoint = AsCad(obj44),
								Rotation = num74 - Math.PI / 2.0
							}, database);
							return;
							IL_071e:
							val6 = new Arc(AsCad(obj2), num12 + (double)num17, num6 + num15, num13 - num10);
							val4 = new Polyline();
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
							Polyline obj45 = val4;
							val5 = ((Curve)val25).EndPoint;
							double num76 = val5.X;
							val5 = ((Curve)val25).EndPoint;
							obj45.AddVertexAt(1, new Point2d(num76, val5.Y), 0.0, 0.0, 0.0);
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
								Polyline obj48 = val4;
								val5 = ((Curve)val25).StartPoint;
								double num79 = val5.X;
								val5 = ((Curve)val25).StartPoint;
								obj48.AddVertexAt(0, new Point2d(num79, val5.Y), Bulge(val25.StartAngle, val25.EndAngle), 0.0, 0.0);
								num = 55;
								goto case 55;
							}
							case 55:
							{
								Polyline obj49 = val4;
								val5 = ((Curve)val25).EndPoint;
								double num80 = val5.X;
								val5 = ((Curve)val25).EndPoint;
								obj49.AddVertexAt(1, new Point2d(num80, val5.Y), 0.0, 0.0, 0.0);
								Polyline obj50 = val4;
								val5 = ((Curve)val6).EndPoint;
								double num81 = val5.X;
								val5 = ((Curve)val6).EndPoint;
								obj50.AddVertexAt(2, new Point2d(num81, val5.Y), 0.0 - Bulge(val6.StartAngle, val6.EndAngle), 0.0, 0.0);
								num = 6;
								goto case 6;
							}
							case 6:
							{
								Polyline obj51 = val4;
								val5 = ((Curve)val6).StartPoint;
								double num82 = val5.X;
								val5 = ((Curve)val6).StartPoint;
								obj51.AddVertexAt(3, new Point2d(num82, val5.Y), 0.0, 0.0, 0.0);
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
								Polyline obj46 = val7;
								val5 = ((Curve)val8).EndPoint;
								double num77 = val5.X;
								val5 = ((Curve)val8).EndPoint;
								obj46.AddVertexAt(2, new Point2d(num77, val5.Y), 0.0 - Bulge(val8.StartAngle, val8.EndAngle), 0.0, 0.0);
								Polyline obj47 = val7;
								val5 = ((Curve)val8).StartPoint;
								double num78 = val5.X;
								val5 = ((Curve)val8).StartPoint;
								obj47.AddVertexAt(3, new Point2d(num78, val5.Y), 0.0, 0.0, 0.0);
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
							Polyline obj52 = val7;
							val5 = ((Curve)val18).StartPoint;
							double num83 = val5.X;
							val5 = ((Curve)val18).StartPoint;
							obj52.AddVertexAt(5, new Point2d(num83, val5.Y), 0.0, 0.0, 0.0);
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
							Polyline obj53 = val17;
							val5 = ((Curve)val16).StartPoint;
							double num84 = val5.X;
							val5 = ((Curve)val16).StartPoint;
							obj53.AddVertexAt(0, new Point2d(num84, val5.Y), Bulge(val16.StartAngle, val16.EndAngle), 0.0, 0.0);
							Polyline obj54 = val17;
							val5 = ((Curve)val16).EndPoint;
							double num85 = val5.X;
							val5 = ((Curve)val16).EndPoint;
							obj54.AddVertexAt(1, new Point2d(num85, val5.Y), 0.0, 0.0, 0.0);
							goto IL_19ac;
							IL_19ac:
							Polyline obj55 = val17;
							val5 = ((Curve)val15).StartPoint;
							double num86 = val5.X;
							val5 = ((Curve)val15).StartPoint;
							obj55.AddVertexAt(2, new Point2d(num86, val5.Y), Bulge(val15.StartAngle, val15.EndAngle), 0.0, 0.0);
							Polyline obj56 = val17;
							val5 = ((Curve)val15).EndPoint;
							double num87 = val5.X;
							val5 = ((Curve)val15).EndPoint;
							obj56.AddVertexAt(3, new Point2d(num87, val5.Y), 0.0, 0.0, 0.0);
							num = 87;
							goto IL_1b9f;
							IL_18bb:
							Polyline obj57 = val17;
							val5 = ((Curve)val15).StartPoint;
							double num88 = val5.X;
							val5 = ((Curve)val15).StartPoint;
							obj57.AddVertexAt(4, new Point2d(num88, val5.Y), Bulge(val15.StartAngle, val15.EndAngle), 0.0, 0.0);
							goto IL_1b41;
							IL_1863:
							Polyline obj58 = val17;
							val5 = ((Curve)val13).EndPoint;
							double num89 = val5.X;
							val5 = ((Curve)val13).EndPoint;
							obj58.AddVertexAt(0, new Point2d(num89, val5.Y), 0.0 - Bulge(val13.StartAngle, val13.EndAngle), 0.0, 0.0);
							goto IL_1a54;
							IL_1a54:
							Polyline obj59 = val17;
							val5 = ((Curve)val13).StartPoint;
							double num90 = val5.X;
							val5 = ((Curve)val13).StartPoint;
							obj59.AddVertexAt(1, new Point2d(num90, val5.Y), 0.0, 0.0, 0.0);
							goto IL_1a9c;
							IL_1a9c:
							Polyline obj60 = val17;
							val5 = ((Curve)val16).StartPoint;
							double num91 = val5.X;
							val5 = ((Curve)val16).StartPoint;
							obj60.AddVertexAt(2, new Point2d(num91, val5.Y), Bulge(val16.StartAngle, val16.EndAngle), 0.0, 0.0);
							goto IL_1aee;
							IL_1aee:
							Polyline obj61 = val17;
							val5 = ((Curve)val16).EndPoint;
							double num92 = val5.X;
							val5 = ((Curve)val16).EndPoint;
							obj61.AddVertexAt(3, new Point2d(num92, val5.Y), 0.0, 0.0, 0.0);
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
							Polyline obj62 = val20;
							val5 = ((Curve)val21).StartPoint;
							double num93 = val5.X;
							val5 = ((Curve)val21).StartPoint;
							obj62.AddVertexAt(1, new Point2d(num93, val5.Y), 0.0, 0.0, 0.0);
							goto IL_0eb8;
							IL_0eb8:
							Polyline obj63 = val20;
							val5 = ((Curve)val22).StartPoint;
							double num94 = val5.X;
							val5 = ((Curve)val22).StartPoint;
							obj63.AddVertexAt(2, new Point2d(num94, val5.Y), Bulge(val22.StartAngle, val22.EndAngle), 0.0, 0.0);
							Polyline obj64 = val20;
							val5 = ((Curve)val22).EndPoint;
							double num95 = val5.X;
							val5 = ((Curve)val22).EndPoint;
							obj64.AddVertexAt(3, new Point2d(num95, val5.Y), 0.0, 0.0, 0.0);
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

}
#endif
