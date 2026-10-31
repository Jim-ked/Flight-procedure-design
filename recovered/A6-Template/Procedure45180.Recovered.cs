using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Forms;
// Mechanical recovery: original field/method identifiers retained. See evidence/methods.csv.
// IL locals hoisted to method entry; expression assignments and branch order preserved.
namespace Recovered.A6 {
	internal class Procedure45180
	{
		public TurnInput _0088_0097_008A;

		public double _0088_0097_008B;

		public double _0088_0097_008C;

		public double _0088_0097_008D;

		public double _0088_0097_008E;

		public double _0088_0097_008F;

		public double _0088_0097_0090;

		public double _0088_0097_0091;

		public double _0088_0097_0092;

		public double _0088_0097_0093;

		public double _0088_0097_0094;

		public double _0088_0097_0095;

		public double _0088_0097_0096;

		public double _0088_0097_0097;

		public Spiral86 _0088_0097_0098;

		public Spiral86 _0088_0097_0099;

		public Spiral86 _0088_0097_009A;

		public double _0088_0097_009B;

		public double _0088_0097_009C;

		public double _0088_0097_009D;

		public double _0088_0097_009E;

		public List<TemplatePoint> _0088_0098_0086;

		public List<TemplatePoint> _0088_0098_0087;

		public List<List<TemplatePoint>> _0088_0098_0088;

		public TemplatePoint _0088_0098_0089;

		public TemplatePoint _0088_0098_008A;

		public TemplatePoint _0088_0098_008B;

		public TemplatePoint _0088_0098_008C;

		public TemplatePoint _0088_0098_008D;

		public TemplatePoint _0088_0098_008E;

		public TemplatePoint _0088_0098_008F;

		public TemplatePoint _0088_0098_0090;

		public TemplatePoint _0088_0098_0091;

		public TemplatePoint _0088_0098_0092;

		public TemplatePoint _0088_0098_0093;

		public TemplatePoint _0088_0098_0094;

		public static double _0088_0098_0095;

// Original MethodDef: 0x06000453; Original RVA: 0x6ADF4; Processed MethodDef: 0x06000452; Evidence: Procedure45180.source.txt:45542 + independent IL (decompilation/recovery, not runtime).
		public Procedure45180(TurnInput P_0, double P_1 = 1.0)
		{
			int num = default(int); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			num = 6;
			// IL local declared at method entry
			while (true /* original-file-bool-offset:860 */)
			{
				num = 17;
				while (true)
				{
					_0088_0097_008E = 5.0;
					_0088_0097_009B = Math.PI * -3.0 / 4.0;
					num = 4;
					while (true)
					{
						IL_0534:
						// object constructor emitted automatically by C#
						num = 1;
						while (true)
						{
							IL_050e:
							_0088_0097_008A = P_0;
							_0088_0097_008D = P_1 * 60.0;
							num = 9;
							while (true)
							{
								IL_0472:
								_0088_0097_008B = _0088_0097_008A._008A_009D_009A / 3.6;
								_0088_0097_008C = _0088_0097_008A._008A_009D_0098 / 3.6;
								_0088_0097_008E = Math.PI / 36.0;
								_0088_0097_008F = 5.0 * _0088_0097_008B;
								_0088_0097_0090 = (_0088_0097_008D - 5.0 - 45.0 / _0088_0097_008A._008A_009D_009C) * _0088_0097_008B;
								num = 16;
								while (true)
								{
									IL_044a:
									_0088_0097_0091 = (_0088_0097_0093 = _0088_0097_0090 - 5.0 * _0088_0097_008B);
									while (true)
									{
										_0088_0097_0092 = (_0088_0097_0094 = _0088_0097_0090 + 15.0 * _0088_0097_008B);
										num = 22;
										if (!_0088_008D())
										{
											break;
										}
										while (true)
										{
											IL_0396:
											switch (num)
											{
											case 22:
												_0088_0097_0095 = 5.0 * _0088_0097_008C + Math.PI / 4.0 * _0088_0097_008A._008A_009D_009E;
												num = 8;
												goto case 8;
											case 8:
												_0088_0097_0096 = (_0088_0097_008D - 5.0) * _0088_0097_008C;
												num = 12;
												goto case 12;
											case 12:
												_0088_0097_0097 = (_0088_0097_008D + 15.0) * _0088_0097_008C;
												num = 18;
												goto case 18;
											case 18:
											{
												_0088_0098_0089 = new TemplatePoint(_0088_0097_008F, 0.0);
												num2 = _0088_0097_008A._008A_009D_009D * Math.Sin(45.0 * _0088_0098_0095) / Math.Sin(67.5 * _0088_0098_0095);
												_0088_0098_008A = TemplatePoint._008B_0089_0088(_0088_0098_0089, TemplatePoint._008B_0089_0087(num2, -22.5 * _0088_0098_0095));
												_0088_0098_008B = TemplatePoint._008B_0089_0088(_0088_0098_008A, TemplatePoint._008B_0089_0087(_0088_0097_0090, -45.0 * _0088_0098_0095));
												num = 21;
												goto case 21;
											}
											case 21:
												_0088_0098_008C = TemplatePoint._008B_0089_0088(_0088_0098_008B, TemplatePoint._008B_0089_0087(_0088_0097_008A._008A_009D_009D, 45.0 * _0088_0098_0095));
												goto case 2;
											case 7:
												_0088_0098_008F = TemplatePoint._008B_0089_0088(_0088_0098_008A, TemplatePoint._008B_0089_0087(_0088_0097_0092, -50.0 * _0088_0098_0095));
												num = 10;
												goto case 10;
											case 10:
												_0088_0098_0090 = TemplatePoint._008B_0089_0088(_0088_0098_008A, TemplatePoint._008B_0089_0087(_0088_0097_0093, -40.0 * _0088_0098_0095));
												num = 0;
												goto case 0;
											case 0:
												_0088_0098_0091 = TemplatePoint._008B_0089_0088(_0088_0098_008A, TemplatePoint._008B_0089_0087(_0088_0097_0094, -40.0 * _0088_0098_0095));
												num = 14;
												if (_0088_008D())
												{
													goto case 14;
												}
												goto case 5;
											case 14:
												obj = TemplatePoint._008B_0089_0087(_0088_0097_008A._008A_009D_009D, 45.0 * _0088_0098_0095);
												num = 3;
												goto case 3;
											case 3:
												_0088_0098_0092 = TemplatePoint._008B_0089_0088(_0088_0098_008F, obj);
												num = 15;
												if (_0088_008E())
												{
													goto case 22;
												}
												goto case 15;
											case 2:
												_0088_0098_008D = TemplatePoint._008B_0089_0088(_0088_0098_008B, TemplatePoint._008B_0089_0087(2.0 * _0088_0097_008A._008A_009D_009D, 45.0 * _0088_0098_0095));
												_0088_0098_008E = TemplatePoint._008B_0089_0088(_0088_0098_008A, TemplatePoint._008B_0089_0087(_0088_0097_0091, -50.0 * _0088_0098_0095));
												num = 7;
												goto case 7;
											case 15:
												while (true)
												{
													_0088_0098_0093 = TemplatePoint._008B_0089_0088(_0088_0098_0090, obj);
													_0088_0098_0094 = TemplatePoint._008B_0089_0088(_0088_0098_0091, obj);
													_0088_008D();
													if (_0088_008E())
													{
														break;
													}
													num = 5;
													if (!_0088_008D())
													{
														continue;
													}
													goto IL_0396;
												}
												num = 24;
												goto case 20;
											default:
												num = 2;
												goto case 2;
											case 23:
												break;
											case 16:
												goto IL_044a;
											case 9:
												goto IL_0472;
											case 1:
												goto IL_050e;
											case 4:
												goto IL_0534;
											case 17:
												goto end_IL_040c;
											case 6:
												goto end_IL_0545;
											case 5:
											case 19:
												_0088_0097_009E = _0088_0097_0097;
												goto case 20;
											case 20:
											case 24:
												_0088_0097_009C = _0088_0097_0097;
												num = 13;
												goto case 13;
											case 13:
												_0088_0097_009D = _0088_0097_0096;
												_0088_0097_009A = new Spiral86(_0088_0097_008A, _0088_0098_0092, _0088_0097_009B, _0088_0097_009E);
												_0088_0097_0099 = new Spiral86(_0088_0097_008A, _0088_0098_0093, _0088_0097_009B, _0088_0097_009D);
												_0088_0097_0098 = new Spiral86(_0088_0097_008A, _0088_0098_0094, _0088_0097_009B, _0088_0097_009C);
												num = 11;
												goto case 11;
											case 11:
												_0088_0096_009E();
												num = 25;
												return;
											case 25:
												return;
											}
											break;
										}
										continue;
										end_IL_040c:
										break;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					continue;
					end_IL_0545:
					break;
				}
			}
		}

// Original MethodDef: 0x06000454; Original RVA: 0x6B470; Processed MethodDef: 0x06000453; Evidence: Procedure45180.source.txt:45728 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0096_009C(bool P_0 = false)
		{
			int num = default(int); // IL InitLocals

			_0088_008E();
			if (_0088_008D())
			{
				goto IL_011a;
			}
			num = 8;
			goto IL_0163;
			IL_0163:
			while (true)
			{
				if (!P_0)
				{
					_0088_0097_0089(ref _0088_0098_0086, new TemplatePoint(_0088_0098_0089.X, _0088_0098_0089.Y - _0088_0097_008A._008A_009D_009D), _0088_0097_008A._008A_009D_009D, 90.0, 45.0, -2.0);
					goto IL_00e3;
				}
				goto IL_0085;
				IL_019c:
				_0088_0097_0089(ref _0088_0098_0086, _0088_0098_008C, _0088_0097_008A._008A_009D_009D, -135.0, 180.0);
				return;
				IL_00e3:
				_0088_0098_0086.Add(_0088_0098_008A);
				_0088_0098_0086.Add(_0088_0098_008B);
				num = 6;
				if (_0088_008D())
				{
					goto IL_00a9;
				}
				goto IL_019c;
				IL_00a9:
				switch (num)
				{
				case 7:
					break;
				default:
					return;
				case 4:
					goto IL_00e3;
				case 0:
				case 1:
					goto end_IL_0163;
				case 2:
				case 8:
					continue;
				case 5:
					_0088_0098_0086.Add(_0088_0098_008B);
					_0088_0098_0086.Add(_0088_0098_008D);
					return;
				case 3:
					return;
				case 6:
					goto IL_019c;
				case 9:
				case 10:
					return;
				}
				goto IL_0085;
				IL_0085:
				_0088_0098_0086.Add(_0088_0098_008A);
				num = 5;
				if (_0088_008E())
				{
					return;
				}
				goto IL_00a9;
				continue;
				end_IL_0163:
				break;
			}
			goto IL_011a;
			IL_011a:
			if (!false /* original-file-bool-offset:864 */)
			{
				_0088_0098_0086 = new List<TemplatePoint>
				{
					new TemplatePoint(0.0, 0.0),
					_0088_0098_0089
				};
				goto IL_0163;
			}
			num = 9;
		}

// Original MethodDef: 0x06000455; Original RVA: 0x6B69C; Processed MethodDef: 0x06000454; Evidence: Procedure45180.source.txt:45812 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0096_009D(bool P_0 = true)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			LineCarrier obj = default(LineCarrier); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj4 = default(TemplatePoint); // IL InitLocals
			LineCarrier obj5 = default(LineCarrier); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:868 */)
			{
				return;
			}
			_0088_0098_0088 = new List<List<TemplatePoint>>();
			num = Math.Sqrt(_0088_0098_008A.X * _0088_0098_008A.X + _0088_0098_008A.Y * _0088_0098_008A.Y - _0088_0097_0095 * _0088_0097_0095);
			num2 = Math.Atan((0.0 - _0088_0098_008A.Y) / _0088_0098_008A.X);
			num3 = Math.Atan(_0088_0097_0095 / num);
			obj = new LineCarrier();
			obj._008B_0088_008F(new TemplatePoint(0.0, 0.0), 0.0 - num2 - num3);
			obj2 = TemplatePoint._008B_0089_0087(_0088_0097_0097, 220.0 * _0088_0098_0095 - _0088_0097_008A._008A_009E_0086);
			if (!_0088_008E())
			{
				obj3 = TemplatePoint._008B_0089_0088(_0088_0098_008F, obj2);
				obj2 = TemplatePoint._008B_0089_0087(_0088_0097_0095, 220.0 * _0088_0098_0095 - _0088_0097_008A._008A_009E_0086);
				obj4 = TemplatePoint._008B_0089_0088(_0088_0098_008A, obj2);
				obj5 = new LineCarrier();
				obj5._008B_0088_008E(obj3, obj4);
				obj2 = obj5._008B_0088_0093(obj);
				_0088_0098_0087 = new List<TemplatePoint>
				{
					new TemplatePoint(0.0, 0.0),
					obj2
				};
			}
			PointLists._008B_008B_0087(ref _0088_0098_0087, _0088_0097_009A._008A_009E_009E(0.0, Math.PI / 2.0 + _0088_0097_008A._008A_009E_0086));
			num4 = 5.0 * _0088_0098_0095 + 2.0 * _0088_0097_008A._008A_009E_0086 + Math.PI;
			PointLists._008B_008B_0087(ref _0088_0098_0087, _0088_0097_0098._008A_009E_009E(Math.PI / 2.0 + _0088_0097_008A._008A_009E_0086, num4));
			PointLists._008B_008B_0087(ref _0088_0098_0087, _0088_0097_0099._008A_009E_009E(num4, 310.0 * _0088_0098_0095));
			_0088_0098_0088.Add(_0088_0098_0087);
			_0088_008D();
			if (!_0088_008E())
			{
				if (!P_0)
				{
					return;
				}
				_0088_0098_0088.Add(_0088_0097_009A._008A_009E_009E(0.0, Math.PI / 2.0 + _0088_0097_008A._008A_009E_0086, 0.0, 1.0, P_0, P_0));
			}
			_0088_0098_0088.Add(_0088_0097_0098._008A_009E_009E(Math.PI / 2.0 + _0088_0097_008A._008A_009E_0086, num4, 0.0, 1.0, P_0, P_0));
			_0088_0098_0088.Add(_0088_0097_0099._008A_009E_009E(num4, 310.0 * _0088_0098_0095, 0.0, 1.0, P_0, P_0));
		}

// Original MethodDef: 0x06000456; Original RVA: 0x6BB7C; Processed MethodDef: 0x06000455; Evidence: Procedure45180.source.txt:45857 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0096_009E()
		{
			int num = default(int); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			LineCarrier obj5 = default(LineCarrier); // IL InitLocals
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj4 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			LineCarrier obj3 = default(LineCarrier); // IL InitLocals
			TemplatePoint obj6 = default(TemplatePoint); // IL InitLocals

			num = 18;
			if (!_0088_008E())
			{
				goto IL_00d7;
			}
			goto IL_022f;
			IL_00d7:
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			switch (num)
			{
			case 7:
				break;
			case 0:
				goto IL_0065;
			case 18:
				if (true /* original-file-bool-offset:872 */)
				{
					num = 0;
					goto IL_0065;
				}
				return;
			case 6:
				goto IL_0135;
			case 17:
				num2 = Math.Atan((0.0 - _0088_0098_008A.Y) / _0088_0098_008A.X);
				num = 4;
				goto case 4;
			case 4:
			{
				num3 = Math.Atan(_0088_0097_0095 / num4);
				obj5 = new LineCarrier();
				obj5._008B_0088_008F(new TemplatePoint(0.0, 0.0), 0.0 - num2 - num3);
				obj2 = new TemplatePoint(num4 * Math.Cos(0.0 - num2 - num3), num4 * Math.Sin(0.0 - num2 - num3));
				num = 12;
				goto case 12;
			}
			case 12:
				list = new List<TemplatePoint>();
				list.Add(new TemplatePoint(0.0, 0.0));
				num = 16;
				goto IL_022f;
			case 16:
				goto IL_022f;
			case 5:
			case 8:
				obj = TemplatePoint._008B_0089_0088(_0088_0098_008A, obj2);
				goto default;
			default:
			{
				obj3 = new LineCarrier();
				obj3._008B_0088_008E(obj4, obj);
				obj2 = obj3._008B_0088_0093(obj5);
				list.Add(obj2);
				_0088_0097_0089(ref list, _0088_0098_008F, _0088_0097_0097, 220.0 - _0088_0097_008A._008A_009E_0086 / _0088_0098_0095, 5.0, 1.0);
				num = 15;
				goto case 15;
			}
			case 15:
				list = new List<TemplatePoint>();
				goto IL_04a5;
			case 14:
				goto IL_031d;
			case 10:
				goto IL_0356;
			case 1:
				goto IL_048e;
			case 9:
			case 11:
				goto IL_04a5;
			case 3:
				goto IL_04e3;
			case 13:
				goto IL_0537;
			case 19:
				return;
			}
			goto IL_0018;
			IL_0537:
			// IL local declared at method entry
			list.Add(new TemplatePoint(_0088_0098_0094.X + obj4.X + obj6.X, _0088_0098_0094.Y + obj4.Y + obj6.Y));
			num = 19;
			return;
			IL_0356:
			num2 = -40.0 * _0088_0098_0095 + Math.PI / 2.0 + 2.0 * _0088_0097_008A._008A_009E_0086;
			obj4 = TemplatePoint._008B_0089_0087(_0088_0097_008A._008A_009D_009D, num2);
			obj = TemplatePoint._008B_0089_0087((_0088_0097_008D - 5.0) * _0088_0097_008C + (Math.PI / 2.0 + 5.0 * _0088_0098_0095 + Math.PI / 2.0 + 2.0 * _0088_0097_008A._008A_009E_0086) * _0088_0097_008A._008A_009D_009E, num2 - _0088_0097_008A._008A_009E_0086);
			obj6 = TemplatePoint._008B_0089_0087(_0088_0097_0097 + (Math.PI / 2.0 + 5.0 * _0088_0098_0095 + Math.PI / 2.0 + 2.0 * _0088_0097_008A._008A_009E_0086) * _0088_0097_008A._008A_009D_009E, num2 - _0088_0097_008A._008A_009E_0086);
			num = 1;
			goto IL_048e;
			IL_031d:
			list.Add(_0088_0097_0098._008A_009E_0093(Math.PI / 2.0 + _0088_0097_008A._008A_009E_0086));
			num = 10;
			goto IL_0356;
			IL_04a5:
			list.Add(_0088_0097_009A._008A_009E_0093(Math.PI / 2.0 + _0088_0097_008A._008A_009E_0086));
			num = 14;
			goto IL_031d;
			IL_022f:
			obj2 = TemplatePoint._008B_0089_0087(_0088_0097_0097, 220.0 * _0088_0098_0095 - _0088_0097_008A._008A_009E_0086);
			num = 6;
			goto IL_0135;
			IL_0135:
			obj4 = TemplatePoint._008B_0089_0088(_0088_0098_008F, obj2);
			goto IL_0018;
			IL_0018:
			obj2 = TemplatePoint._008B_0089_0087(_0088_0097_0095, 220.0 * _0088_0098_0095 - _0088_0097_008A._008A_009E_0086);
			/* opaque discard 0 */
			if (_0088_008D())
			{
				num = 5;
				if (!_0088_008D())
				{
					goto IL_0065;
				}
				goto IL_00d7;
			}
			num = 9;
			goto IL_04a5;
			IL_0065:
			num4 = Math.Sqrt(_0088_0098_008A.X * _0088_0098_008A.X + _0088_0098_008A.Y * _0088_0098_008A.Y - _0088_0097_0095 * _0088_0097_0095);
			num = 17;
			if (_0088_008D())
			{
				goto IL_00d7;
			}
			goto IL_0356;
			IL_04e3:
			list.Add(new TemplatePoint(_0088_0098_0093.X + obj4.X + obj.X, _0088_0098_0093.Y + obj4.Y + obj.Y));
			num = 13;
			goto IL_0537;
			IL_048e:
			list = new List<TemplatePoint>();
			num = 3;
			if (!_0088_008D())
			{
				goto IL_04a5;
			}
			goto IL_04e3;
		}

// Original MethodDef: 0x06000457; Original RVA: 0x6C158; Processed MethodDef: 0x06000456; Evidence: Procedure45180.source.txt:46005 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0097_0086()
		{

		}

// Original MethodDef: 0x06000458; Original RVA: 0x6C164; Processed MethodDef: 0x06000457; Evidence: Procedure45180.source.txt:46009 + independent IL (decompilation/recovery, not runtime).
		public override string ToString()
		{

			return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(_0088_0097_008A.ToString() + "=========== Procedure Turn parameters ============" /* string-offset:5556 */, "\nv = " /* string-offset:5560 */, Math.Round(_0088_0097_008B, 1).ToString(), "m/s" /* string-offset:5564 */), "\nw' = " /* string-offset:5568 */, Math.Round(_0088_0097_008C, 1).ToString(), "m/s" /* string-offset:5564 */), "\nab = " /* string-offset:5572 */, Math.Round(_0088_0097_008F).ToString(), "m" /* string-offset:3072 */), "\ncd = " /* string-offset:5576 */, Math.Round(_0088_0097_0090).ToString(), "m" /* string-offset:3072 */), "\ncd1 = cd3 = " /* string-offset:5580 */, Math.Round(_0088_0097_0091).ToString(), "m" /* string-offset:3072 */), "\ncd2 = cd4 = " /* string-offset:5584 */, Math.Round(_0088_0097_0092).ToString(), "m" /* string-offset:3072 */), "\nWc = " /* string-offset:5588 */, Math.Round(_0088_0097_0095).ToString(), "m" /* string-offset:3072 */), "\nWd2 = " /* string-offset:5592 */, Math.Round(_0088_0097_0097).ToString(), "m" /* string-offset:3072 */);
		}

// Original MethodDef: 0x06000459; Original RVA: 0x6C2F4; Processed MethodDef: 0x06000458; Evidence: Procedure45180.source.txt:46014 + independent IL (decompilation/recovery, not runtime).
		public List<TemplatePoint> _0088_0097_0087()
		{

			return new List<TemplatePoint> { _0088_0098_0091, _0088_0098_0090, _0088_0098_008E, _0088_0098_008F, _0088_0098_0092, _0088_0098_0094, _0088_0098_0093, _0088_0098_0090 };
		}

// Original MethodDef: 0x0600045A; Original RVA: 0x6C370; Processed MethodDef: 0x06000459; Evidence: Procedure45180.source.txt:46019 + independent IL (decompilation/recovery, not runtime).
		public List<List<TemplatePoint>> _0088_0097_0088(double P_0, double P_1, double P_2, double P_3, double P_4)
		{
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals
			List<TemplatePoint> list2 = default(List<TemplatePoint>); // IL InitLocals

			list = new List<List<TemplatePoint>>();
			list2 = new List<TemplatePoint>();
			list2.Add(new TemplatePoint(P_0, P_1));
			list2.Add(new TemplatePoint(P_2, P_1));
			list.Add(list2);
			for (double num = P_0; num <= P_2; num += P_3)
			{
				list2 = new List<TemplatePoint>();
				list2.Add(new TemplatePoint(num, P_1));
				list2.Add(new TemplatePoint(num, P_1 - P_4));
				list.Add(list2);
			}
			return list;
		}

// Original MethodDef: 0x0600045B; Original RVA: 0x6C414; Processed MethodDef: 0x0600045A; Evidence: Procedure45180.source.txt:46036 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0097_0089(ref List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4, double P_5 = 2.0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			if (!true /* original-file-bool-offset:876 */)
			{
				return;
			}
			num = Math.Abs(P_5);
			num2 = P_3;
			num3 = 0.0;
			while (num3 < P_4)
			{
				obj = new TemplatePoint(P_2 * Math.Cos(num2 * _0088_0098_0095), P_2 * Math.Sin(num2 * _0088_0098_0095));
				/* opaque discard 1 */
				if (!_0088_008E())
				{
					P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
					num2 += P_5;
					num3 += num;
				}
				else if (_0088_008D())
				{
					break;
				}
			}
			num4 = ((P_5 > 0.0) ? (P_3 + P_4) : (P_3 - P_4));
			if (num2 - P_5 != num4)
			{
				obj = new TemplatePoint(P_2 * Math.Cos(num4 * _0088_0098_0095), P_2 * Math.Sin(num4 * _0088_0098_0095));
				P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
			}
		}

// Original MethodDef: 0x0600045C; Original RVA: 0x6C5EC; Processed MethodDef: 0x0600045B; Evidence: Procedure45180.source.txt:46068 + independent IL (decompilation/recovery, not runtime).
		static Procedure45180()
		{

			// Host licensing not executed in independent arithmetic recovery.
			_0088_0098_0095 = Math.PI / 180.0;
		}

// Original MethodDef: 0x0600045D; Original RVA: 0x6C618; Processed MethodDef: 0x0600045C; Evidence: Procedure45180.source.txt:46074 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0088_008D()
		{

			return true;
		}

// Original MethodDef: 0x0600045E; Original RVA: 0x6C624; Processed MethodDef: 0x0600045D; Evidence: Procedure45180.source.txt:46079 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0088_008E()
		{

			return false;
		}
	}
}
