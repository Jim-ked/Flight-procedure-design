using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
// Mechanical recovery of processed source/IL. Original identifiers retained.
// IL locals initialized once at entry. No target assembly or AutoCAD dependency.
namespace Recovered.B5 {
	public class PbnDepartureFlyOver
	{
		public double _008A_0088_008E;

		public double _008A_0088_008F;

		public double _008A_0088_0090;

		public double _008A_0088_0091;

		public double _008A_0088_0092;

		public double _008A_0088_0093;

		public double _008A_0088_0094;

		public double _008A_0088_0095;

		public double _008A_0088_0096;

		public double _008A_0088_0097;

		private TemplatePoint _008A_0088_0098;

		private TemplatePoint _008A_0088_0099;

		private TemplatePoint _008A_0088_009A;

		private TemplatePoint _008A_0088_009B;

		private TemplatePoint _008A_0088_009C;

		private TemplatePoint _008A_0088_009D;

		private TemplatePoint _008A_0088_009E;

		private TemplatePoint _008A_0089_0086;

		private TemplatePoint _008A_0089_0087;

		private TemplatePoint _008A_0089_0088;

		private TemplatePoint _008A_0089_0089;

		private TemplatePoint _008A_0089_008A;

		public List<TemplatePoint> _008A_0089_008B;

		public List<TemplatePoint> _008A_0089_008C;

		public List<TemplatePoint> _008A_0089_008D;

		public List<TemplatePoint> _008A_0089_008E;

		public List<TemplatePoint> _008A_0089_008F;

		public List<TemplatePoint> _008A_0089_0090;

		public List<TemplatePoint> _008A_0089_0091;

		public List<TemplatePoint> _008A_0089_0092;

		public List<TemplatePoint> _008A_0089_0093;

		public List<TemplatePoint> _008A_0089_0094;

		public List<List<TemplatePoint>> _008A_0089_0095;

		private LineCarrier _008A_0089_0096;

		private LineCarrier _008A_0089_0097;

		private TurnInput _008A_0089_0098;

		private double _008A_0089_0099;

		private List<TemplatePoint> _008A_0089_009A;

		private List<TemplatePoint> _008A_0089_009B;

		private static double _008A_0089_009C;

		private static double _008A_0089_009D;

		private List<TemplatePoint> _008A_0089_009E;

		private List<TemplatePoint> _008A_008A_0086;

		private List<List<TemplatePoint>> _008A_008A_0087;

// R5 MethodDef: original 0x060005D3 RVA 0xAF6D0; processed 0x060005D2 RVA 0x815E8; source :; processed IL recovery, not original runtime.
public PbnDepartureFlyOver()
		{

			_0088m();
			if (_0088l())
			{
				_008A_0089_0096 = new LineCarrier();
			}
			_008A_0089_0097 = new LineCarrier();
			_008A_0089_0099 = 1482.0;
			// object constructor emitted automatically
		}

// R5 MethodDef: original 0x060005D4 RVA 0xAF7CC; processed 0x060005D3 RVA 0x81668; source 03_recovered-src/annotated-strings/--/--.cs:70364; processed IL recovery, not original runtime.
public PbnDepartureFlyOver(TurnInput P_0, TemplatePoint P_1, TemplatePoint P_2, TemplatePoint P_3, double P_4, bool P_5 = true, double P_6 = 0.033, double P_7 = 0.033)
		{
			int num = default(int); // IL InitLocals
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals
			List<TemplatePoint> item = default(List<TemplatePoint>); // IL InitLocals

			num = 12;
			// IL local hoisted
			// IL local hoisted
			while (!false /* original-file-bool-offset:1216 */)
			{
				_008A_0089_0096 = new LineCarrier();
				_008A_0089_0097 = new LineCarrier();
				num = 0;
				while (true)
				{
					_008A_0089_0099 = 1482.0;
					// object constructor emitted automatically
					num = 22;
					if (!_0088l())
					{
						goto IL_0293;
					}
					goto IL_060a;
					IL_060a:
					_008A_0088_008E = 300.0;
					_008A_0088_008F = Math.Tan(Math.PI / 12.0);
					num = 19;
					goto IL_05ed;
					IL_05ed:
					_008A_0089_0095 = new List<List<TemplatePoint>>();
					_008A_0089_0098 = P_0;
					num = 26;
					goto IL_05da;
					IL_05da:
					_008A_0089_0088 = P_1;
					_008A_0089_0089 = P_2;
					goto IL_0068;
					IL_0068:
					_008A_0089_008A = P_3;
					_0088m();
					if (!_0088l())
					{
						num = 6;
						goto IL_0504;
					}
					num = 24;
					goto IL_00c9;
					IL_0317:
					_008A_0088_0090 = Math.Min(3704.0, _008A_0088_0093 * _008A_0088_008F + _008A_0088_008E / 2.0);
					_008A_0088_0091 = Math.Min(3704.0, _008A_0088_0094 * _008A_0088_008F + _008A_0088_008E / 2.0);
					num = 3;
					goto IL_0384;
					IL_0140:
					switch (num)
					{
					case 20:
						break;
					case 7:
					case 24:
						goto IL_00c9;
					case 4:
						goto IL_00d9;
					case 11:
						goto IL_00f1;
					case 18:
						goto IL_0109;
					case 13:
						goto IL_01c2;
					case 2:
						goto IL_01e0;
					case 16:
						goto IL_020a;
					case 27:
						goto IL_021a;
					case 23:
						goto IL_024f;
					case 15:
						goto IL_0280;
					case 25:
						goto IL_0293;
					case 9:
						goto IL_029d;
					case 17:
						goto IL_02b5;
					case 10:
						goto IL_02c6;
					case 8:
						goto IL_0317;
					case 3:
						goto IL_0384;
					case 5:
						goto IL_04be;
					default:
						goto IL_0504;
					case 26:
						goto IL_05da;
					case 19:
						goto IL_05ed;
					case 22:
						goto IL_060a;
					case 0:
						continue;
					case 12:
						goto end_IL_0638;
					case 21:
						return;
					case 1:
					case 28:
						return;
					}
					goto IL_0068;
					IL_00c9:
					_008A_0088_0096 = P_6;
					_008A_0088_0097 = P_7;
					goto IL_00d9;
					IL_00d9:
					_008A_0088_0093 = P_4 - _008A_0089_0099;
					num = 11;
					goto IL_00f1;
					IL_00f1:
					_008A_0088_0094 = P_4 + _008A_0089_0099;
					num = 18;
					goto IL_0109;
					IL_0109:
					_008A_0088_0095 = _008A_0088_0094 + (P_0._008A_009D_009A + P_0._008A_009D_0098) / 0.6;
					num = 8;
					if (!_0088m())
					{
						goto IL_0140;
					}
					goto IL_0384;
					IL_0384:
					_008A_0088_0092 = Math.Min(3704.0, _008A_0088_0095 * _008A_0088_008F + _008A_0088_008E / 2.0);
					_008A_0088_0098 = new TemplatePoint(0.0, _008A_0088_008E / 2.0);
					_008A_0088_0099 = new TemplatePoint(6351.95, 1852.0, (_008A_0088_0096 + 0.008) * 6531.95 + 5.0);
					_008A_0088_009A = new TemplatePoint(13263.71, 3704.0, (_008A_0088_0096 + 0.008) * 13263.71 + 5.0);
					_008A_0088_009B = new TemplatePoint(_008A_0088_0094, Math.Min(_008A_0088_0091, 3704.0), (_008A_0088_0096 + 0.008) * _008A_0088_0094 + 5.0);
					num = 5;
					if (_0088m())
					{
						goto IL_0317;
					}
					goto IL_04be;
					IL_04be:
					_008A_0088_009C = new TemplatePoint(_008A_0088_0094, Math.Min(_008A_0088_0091, 1852.0), (_008A_0088_0096 + 0.008) * _008A_0088_0094 + 5.0);
					goto IL_0504;
					IL_0504:
					_008A_0088_009D = new TemplatePoint(_008A_0088_0095, _008A_0088_0092, (_008A_0088_0096 + 0.008) * _008A_0088_0095 + 5.0);
					_008A_0088_009E = new TemplatePoint(_008A_0088_0095, 1852.0, (_008A_0088_0096 + 0.008) * _008A_0088_0095 + 5.0);
					_008A_0089_0086 = new TemplatePoint(_008A_0088_0093, Math.Min(_008A_0088_0090, 1852.0), (_008A_0088_0096 + 0.008) * _008A_0088_0093 + 5.0);
					num = 10;
					goto IL_02c6;
					IL_02c6:
					_008A_0089_0087 = new TemplatePoint(_008A_0088_0093, Math.Min(_008A_0088_0090, 3704.0), (_008A_0088_0096 + 0.008) * _008A_0088_0093 + 5.0);
					num = 17;
					goto IL_02b5;
					IL_02b5:
					_008A_0088_008B();
					num = 9;
					goto IL_029d;
					IL_029d:
					_008A_0089_009A = B5Math._008B_0088_0089(PointLists._008B_008A_008D(_008A_0089_0095));
					goto IL_0293;
					IL_0293:
					_008A_0088_008A(P_5);
					goto IL_0280;
					IL_0280:
					_008A_0088_0088(P_5);
					num = 23;
					goto IL_024f;
					IL_024f:
					list = new List<List<TemplatePoint>> { _008A_0089_009E, _008A_008A_0086 };
					if (_008A_0088_0095 > 13263.71)
					{
						item = new List<TemplatePoint> { _008A_0088_009A };
						num = 16;
						goto IL_020a;
					}
					goto IL_021a;
					IL_020a:
					list.Add(item);
					num = 27;
					goto IL_021a;
					IL_021a:
					PointLists._008B_008B_0086(ref list, _008A_008A_0087);
					num = 2;
					goto IL_01e0;
					IL_01e0:
					_008A_0089_009B = B5Math._008B_0088_0089(PointLists._008B_008A_008D(list));
					_008A_0089_0096._008B_0088_008E(_008A_0088_0098, _008A_0088_0099);
					goto IL_01c2;
					IL_01c2:
					if (_008A_0088_009B.X >= 13263.71)
					{
						_008A_0089_0097._008B_0088_008F(_008A_0088_009A, _008A_0089_0096._008B_0088_0094() + Math.PI / 2.0);
						num = 21;
						if (!_0088m())
						{
							goto IL_0140;
						}
						goto IL_021a;
					}
					_008A_0089_0097._008B_0088_008F(_008A_0088_009B, _008A_0089_0096._008B_0088_0094() + Math.PI / 2.0);
					return;
					continue;
					end_IL_0638:
					break;
				}
			}
			num = 1;
		}

// R5 MethodDef: original 0x060005D5 RVA 0xAFED4; processed 0x060005D4 RVA 0x81D18; source 03_recovered-src\annotated-strings\--\--.cs:70573; processed IL recovery, not original runtime.
private void _008A_0088_0088(bool P_0)
		{
			int num = default(int); // IL InitLocals
			TemplatePoint obj4 = default(TemplatePoint); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			RunwayFrame obj2 = default(RunwayFrame); // IL InitLocals
			RunwayFrame obj3 = default(RunwayFrame); // IL InitLocals
			Spiral86 obj5 = default(Spiral86); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			Spiral86 obj6 = default(Spiral86); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			TemplatePoint obj7 = default(TemplatePoint); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			TemplatePoint obj8 = default(TemplatePoint); // IL InitLocals
			Spiral86 obj9 = default(Spiral86); // IL InitLocals
			TemplatePoint obj10 = default(TemplatePoint); // IL InitLocals
			Spiral86 obj11 = default(Spiral86); // IL InitLocals
			double num9 = default(double); // IL InitLocals
			double num10 = default(double); // IL InitLocals
			double num11 = default(double); // IL InitLocals
			double num12 = default(double); // IL InitLocals
			double num13 = default(double); // IL InitLocals
			double num14 = default(double); // IL InitLocals
			double num15 = default(double); // IL InitLocals
			double num16 = default(double); // IL InitLocals
			TemplatePoint obj12 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj13 = default(TemplatePoint); // IL InitLocals

			num = 32;
			if (!_0088m())
			{
				goto IL_0236;
			}
			goto IL_08cd;
			IL_0236:
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				switch (num)
				{
				case 29:
					break;
				case 36:
					goto IL_010f;
				case 34:
				{
					obj2 = FrameHelpers._0089_008F(_008A_0089_0089, _008A_0089_0088);
					obj3 = FrameHelpers._0089_008F(_008A_0089_0088, _008A_0089_008A);
					obj4 = new TemplatePoint(obj3._008A_009D_0088 * Math.Cos(obj3._008A_009D_0089 - obj2._008A_009D_0089), obj3._008A_009D_0088 * Math.Sin(obj3._008A_009D_0089 - obj2._008A_009D_0089));
					num = 0;
					if (!_0088m())
					{
						continue;
					}
					goto IL_05fc;
				}
				case 32:
					if (!true /* original-file-bool-offset:1220 */)
					{
						return;
					}
					goto case 25;
				case 25:
					num2 = (P_0 ? 1 : (-1));
					num = 34;
					goto case 34;
				case 5:
					goto IL_02e8;
				case 12:
					goto IL_031a;
				case 16:
					goto IL_0395;
				case 0:
					obj = new TemplatePoint(_008A_0088_0095, 0.0);
					num = 7;
					goto IL_03e3;
				case 7:
					goto IL_03e3;
				case 13:
					goto IL_044a;
				case 3:
					goto IL_046c;
				case 37:
					goto IL_0499;
				case 4:
					goto IL_04d2;
				case 1:
					goto IL_04f1;
				case 28:
					goto IL_0504;
				case 19:
					goto IL_0562;
				case 15:
					goto IL_05b2;
				case 14:
				case 39:
					goto IL_05d1;
				case 38:
					goto IL_05e1;
				case 33:
					goto IL_05fc;
				case 23:
					goto IL_060f;
				case 26:
					goto IL_0668;
				case 2:
					goto IL_0676;
				case 9:
					goto IL_06d7;
				default:
					goto IL_06f3;
				case 6:
					goto IL_0753;
				case 21:
					goto IL_079f;
				case 20:
					goto IL_07fc;
				case 18:
				case 27:
					goto IL_08ad;
				case 10:
					goto IL_08cd;
				case 24:
					goto IL_095f;
				case 11:
					goto IL_09b5;
				case 30:
					goto IL_09dc;
				case 8:
				case 17:
				case 31:
				case 35:
					goto IL_09ff;
				case 40:
					return;
				}
				break;
			}
			goto IL_0018;
			IL_09ff:
			_008A_0089_0095.Add(_008A_0089_009E);
			_008A_0089_0095.Add(_008A_008A_0086);
			num = 40;
			return;
			IL_095f:
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			_008A_0088_0089(obj5, num3, obj4, num4, num2, ref _008A_0089_009E, ref _008A_008A_0086);
			goto IL_09ff;
			IL_060f:
			_008A_0089_009E = obj5._008A_009E_0091(0.0, num3);
			// IL local hoisted
			_008A_008A_0086 = obj5._008A_009E_0091(num5, num3, num4);
			num = 24;
			if (_0088m())
			{
				goto IL_0668;
			}
			goto IL_095f;
			IL_05b2:
			// IL local hoisted
			num6 = obj6._008A_009E_009B(obj4);
			/* opaque discard 1 */
			if (!_0088m())
			{
				goto IL_05d1;
			}
			num = 18;
			goto IL_08ad;
			IL_05fc:
			num3 = num6 - _008A_0089_009C;
			num = 23;
			goto IL_060f;
			IL_06d7:
			_008A_008A_0086 = obj5._008A_009E_0091(num5, num3, num4);
			goto IL_06f3;
			IL_0562:
			// IL local hoisted
			obj6 = new Spiral86(_008A_0089_0098, obj7, 0.0 - num2 * _008A_0089_009D, 0.0, P_0);
			num7 = _008A_0089_009D + _008A_0089_0098._008A_009E_0086;
			num = 15;
			if (_0088l())
			{
				goto IL_05b2;
			}
			goto IL_09ff;
			IL_06f3:
			// IL local hoisted
			if (num8 >= Math.PI + _008A_0089_009C)
			{
				PointLists._008B_008B_0087(ref _008A_0089_009E, obj6._008A_009E_0091(_008A_0089_009D + _008A_0089_0098._008A_009E_0086, Math.PI + _008A_0089_0098._008A_009E_0086));
				goto IL_0753;
			}
			PointLists._008B_008B_0087(ref _008A_0089_009E, obj6._008A_009E_0091(num7, num6 - _008A_0089_009C));
			num = 11;
			goto IL_09b5;
			IL_05e1:
			if (num8 <= _008A_0089_009D + _008A_0089_009C)
			{
				num = 33;
				goto IL_05fc;
			}
			num3 = _008A_0089_009D + _008A_0089_0098._008A_009E_0086;
			_008A_0089_009E = obj5._008A_009E_0091(0.0, num3);
			goto IL_06d7;
			IL_05d1:
			num8 = num6 - _008A_0089_0098._008A_009E_0086;
			goto IL_05e1;
			IL_0753:
			PointLists._008B_008B_0087(ref _008A_008A_0086, obj6._008A_009E_0091(_008A_0089_009D + _008A_0089_0098._008A_009E_0086, Math.PI + _008A_0089_0098._008A_009E_0086, num4));
			num = 21;
			goto IL_079f;
			IL_079f:
			obj8 = TemplatePoint._008B_0089_0088(new TemplatePoint(_008A_0088_0099.X, 0.0), TemplatePoint._008B_0089_0087(_008A_0089_0098._008A_009D_009D + 1852.0, 0.0 + num2 * _008A_0089_009D));
			goto IL_07fc;
			IL_07fc:
			obj9 = new Spiral86(_008A_0089_0098, obj8, 0.0 - num2 * _008A_0089_009D, 0.0, P_0);
			obj10 = TemplatePoint._008B_0089_0088(new TemplatePoint(_008A_0089_0086.X, 0.0), TemplatePoint._008B_0089_0087(_008A_0089_0098._008A_009D_009D + 150.0, 0.0 + num2 * _008A_0089_009D));
			obj11 = new Spiral86(_008A_0089_0098, obj10, 0.0 - num2 * _008A_0089_009D, 0.0, P_0);
			goto IL_08ad;
			IL_08ad:
			num9 = Math.PI + _008A_0089_0098._008A_009E_0086;
			num = 10;
			goto IL_08cd;
			IL_08cd:
			num10 = obj9._008A_009E_009B(obj4);
			num = 2;
			goto IL_0676;
			IL_0676:
			obj9._008A_009E_009D(obj11);
			num = 26;
			goto IL_0668;
			IL_0668:
			num = 29;
			goto IL_0018;
			IL_0018:
			num11 = Math.Atan2(obj10.Y - obj8.Y, obj10.X - obj8.X);
			num11 += ((!P_0) ? (_008A_0089_009D - _008A_0089_0098._008A_009E_0086) : (_008A_0089_0098._008A_009E_0086 - _008A_0089_009D));
			num12 = obj9._008A_009E_0096(Spiral86._008A_009E_0090(num11));
			num13 = num12;
			num14 = obj11._008A_009E_009B(obj4);
			num15 = Math.Atan2(obj8.Y - obj10.Y, obj8.X - obj10.X);
			num = 16;
			if (_0088l())
			{
				goto IL_0395;
			}
			goto IL_03e3;
			IL_04d2:
			// IL local hoisted
			obj5._008A_009E_0098(0.0, num16, out num5, out num4);
			num = 1;
			goto IL_04f1;
			IL_0499:
			// IL local hoisted
			new LineCarrier()._008B_0088_008F(obj12, 0.0);
			num = 4;
			goto IL_04d2;
			IL_046c:
			obj12 = new TemplatePoint(0.0, num2 * 1852.0);
			num = 37;
			goto IL_0499;
			IL_0395:
			if (!(num10 + num2 * num15 >= num14))
			{
				num10 = num12;
				PointLists._008B_008B_0087(ref _008A_0089_009E, obj9._008A_009E_0091(num9, num10));
				PointLists._008B_008B_0087(ref _008A_008A_0086, obj9._008A_009E_0091(num9, num10, num16));
				goto IL_031a;
			}
			num = 36;
			if (!_0088m())
			{
				goto IL_010f;
			}
			goto IL_02e8;
			IL_0504:
			if (num3 - _008A_0089_0098._008A_009E_0086 > _008A_0089_009D)
			{
				obj7 = TemplatePoint._008B_0089_0088(obj, TemplatePoint._008B_0089_0087(_008A_0089_0098._008A_009D_009D + 1852.0, 0.0 + num2 * _008A_0089_009D));
				num = 19;
				goto IL_0562;
			}
			_008A_0089_009E = obj5._008A_009E_0091(0.0, num3 - _008A_0089_009C);
			_008A_008A_0086 = obj5._008A_009E_0091(num5, num3 - _008A_0089_009C, num4);
			_008A_0088_0089(obj5, num3, obj4, num4, num2, ref _008A_0089_009E, ref _008A_008A_0086);
			goto IL_09ff;
			IL_031a:
			PointLists._008B_008B_0087(ref _008A_0089_009E, obj11._008A_009E_0091(num13, num14 - _008A_0089_009C));
			PointLists._008B_008B_0087(ref _008A_008A_0086, obj11._008A_009E_0091(num13, num14 - _008A_0089_009C, num16));
			num = 5;
			goto IL_02e8;
			IL_04f1:
			num3 = obj5._008A_009E_009B(obj4);
			goto IL_0504;
			IL_010f:
			PointLists._008B_008B_0087(ref _008A_0089_009E, obj9._008A_009E_0091(num9, num10 - _008A_0089_009C));
			PointLists._008B_008B_0087(ref _008A_008A_0086, obj9._008A_009E_0091(num9, num10 - _008A_0089_009C, num16));
			_008A_0088_0089(obj9, num10, obj4, num4, num2, ref _008A_0089_009E, ref _008A_008A_0086);
			num = 8;
			if (!_0088m())
			{
				goto IL_0236;
			}
			goto IL_0753;
			IL_02e8:
			_008A_0088_0089(obj11, num14, obj4, num4, num2, ref _008A_0089_009E, ref _008A_008A_0086);
			num = 17;
			if (!_0088m())
			{
				goto IL_0236;
			}
			goto IL_09b5;
			IL_09b5:
			PointLists._008B_008B_0087(ref _008A_008A_0086, obj6._008A_009E_0091(num7, num6 - _008A_0089_009C, num4));
			goto IL_09dc;
			IL_09dc:
			_008A_0088_0089(obj6, num6, obj4, num4, num2, ref _008A_0089_009E, ref _008A_008A_0086);
			num = 31;
			goto IL_09ff;
			IL_03e3:
			obj13 = TemplatePoint._008B_0089_0088(obj, TemplatePoint._008B_0089_0087(_008A_0089_0098._008A_009D_009D - 1852.0, 0.0 + num2 * _008A_0089_009D));
			obj5 = new Spiral86(_008A_0089_0098, obj13, 0.0 - num2 * _008A_0089_009D, 0.0, P_0);
			goto IL_044a;
			IL_044a:
			num16 = _008A_0088_009D.Y - _008A_0088_009E.Y;
			num = 3;
			goto IL_046c;
		}

// R5 MethodDef: original 0x060005D6 RVA 0xB09E4; processed 0x060005D5 RVA 0x82750; source 03_recovered-src\annotated-strings\--\--.cs:70880; processed IL recovery, not original runtime.
private void _008A_0088_0089(Spiral86 P_0, double P_1, TemplatePoint P_2, double P_3, double P_4, ref List<TemplatePoint> P_5, ref List<TemplatePoint> P_6)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			LineCarrier obj2 = default(LineCarrier); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			LineCarrier obj4 = default(LineCarrier); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			TemplatePoint obj10 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj11 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj5 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj6 = default(TemplatePoint); // IL InitLocals
			LineCarrier obj7 = default(LineCarrier); // IL InitLocals
			LineCarrier obj8 = default(LineCarrier); // IL InitLocals
			LineCarrier obj9 = default(LineCarrier); // IL InitLocals
			TemplatePoint item = default(TemplatePoint); // IL InitLocals
			TemplatePoint item2 = default(TemplatePoint); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:1224 */)
			{
				return;
			}
			obj = P_0._008A_009E_0093(P_1 - _008A_0089_009C);
			num = P_4 * (P_1 - _008A_0089_009C - _008A_0089_0098._008A_009E_0086 + _008A_0089_009D) + P_0._008B_0086_0088;
			num2 = P_0._008A_009E_0095(P_1 - _008A_0089_009C);
			num3 = TemplatePoint._008B_0088_009E(P_2, P_0._008B_0086_008A);
			if (num2 > num3)
			{
				return;
			}
			obj2 = new LineCarrier();
			obj2._008B_0088_008F(obj, num);
			obj3 = P_0._008A_009E_0093(P_1 - _008A_0089_009C, P_3);
			obj4 = new LineCarrier();
			obj4._008B_0088_008F(obj3, num);
			if (!_0088l())
			{
				goto IL_0291;
			}
			num4 = P_4 * (P_1 - _008A_0089_0098._008A_009E_0086 + _008A_0089_009D) + P_0._008B_0086_0088;
			_0088l();
			// IL local hoisted
			// IL local hoisted
			if (!_0088m())
			{
				obj5 = new TemplatePoint(1852.0 * Math.Cos(num4 - P_4 * _008A_0089_009D) + P_2.X, 1852.0 * Math.Sin(num4 - P_4 * _008A_0089_009D) + P_2.Y);
				obj6 = new TemplatePoint(3704.0 * Math.Cos(num4 - P_4 * _008A_0089_009D) + P_2.X, 3704.0 * Math.Sin(num4 - P_4 * _008A_0089_009D) + P_2.Y);
				obj7 = new LineCarrier();
				obj8 = new LineCarrier();
				obj9 = new LineCarrier();
				obj7._008B_0088_008F(obj5, num4);
				obj8._008B_0088_008F(obj6, num4);
				obj9._008B_0088_008F(P_2, num4 + P_4 * _008A_0089_009D);
				obj10 = obj9._008B_0088_0093(obj2);
				obj11 = obj9._008B_0088_0093(obj4);
				item = obj7._008B_0088_0093(obj2);
				item2 = obj8._008B_0088_0093(obj4);
				num5 = TemplatePoint._008B_0088_009E(obj10, P_2);
				num6 = TemplatePoint._008B_0088_009E(obj11, P_2);
				if (num5 <= 1852.0 && num6 <= 3704.0)
				{
					goto IL_0291;
				}
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
			}
			goto IL_02ff;
			IL_0291:
			P_5.Add(obj10);
			P_6.Add(obj11);
			goto IL_02ff;
			IL_02ff:
			P_6.Add(P_2);
		}

// R5 MethodDef: original 0x060005D7 RVA 0xB0E68; processed 0x060005D6 RVA 0x82A68; source 03_recovered-src\annotated-strings\--\--.cs:70950; processed IL recovery, not original runtime.
public void _008A_0088_008A(bool P_0)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			RunwayFrame obj3 = default(RunwayFrame); // IL InitLocals
			RunwayFrame obj4 = default(RunwayFrame); // IL InitLocals
			TemplatePoint obj5 = default(TemplatePoint); // IL InitLocals
			RunwayFrame obj6 = default(RunwayFrame); // IL InitLocals
			RunwayFrame obj7 = default(RunwayFrame); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			TemplatePoint obj8 = default(TemplatePoint); // IL InitLocals
			FlyOverPostArea obj9 = default(FlyOverPostArea); // IL InitLocals

			if (false /* original-file-bool-offset:1228 */)
			{
				return;
			}
			obj = _008A_0089_0086;
			obj2 = _008A_0089_0087;
			obj3 = FrameHelpers._0089_008F(_008A_0089_0089, _008A_0089_0088);
			obj4 = FrameHelpers._0089_008F(_008A_0089_0088, _008A_0089_008A);
			obj5 = new TemplatePoint(obj4._008A_009D_0088 * Math.Cos(obj4._008A_009D_0089 - obj3._008A_009D_0089), obj4._008A_009D_0088 * Math.Sin(obj4._008A_009D_0089 - obj3._008A_009D_0089));
			obj6 = FrameHelpers._0089_008F(obj, obj5);
			_0088l();
			if (_0088m())
			{
				goto IL_011f;
			}
			obj7 = FrameHelpers._0089_008F(TemplatePoint._008B_0089_008B(obj), obj5);
			obj6._008A_009D_0089 = Math.Abs(obj6._008A_009D_0089);
			obj7._008A_009D_0089 = Math.Abs(obj7._008A_009D_0089);
			if (P_0)
			{
				if (!_0088l() || obj7._008A_009D_0089 > B5Math._008B_0087_009A(75.0))
				{
					goto IL_011f;
				}
			}
			else if (!(obj6._008A_009D_0089 > B5Math._008B_0087_009A(75.0)))
			{
				obj = TemplatePoint._008B_0089_008B(obj);
				obj2 = TemplatePoint._008B_0089_008B(obj2);
			}
			goto IL_012d;
			IL_011f:
			obj = TemplatePoint._008B_0089_008B(obj);
			obj2 = TemplatePoint._008B_0089_008B(obj2);
			goto IL_012d;
			IL_012d:
			num = TemplatePoint._008B_0088_009E(obj, obj5);
			num2 = Math.Atan2(obj5.Y - obj.Y, obj5.X - obj.X);
			obj8 = TemplatePoint._008B_0089_008D(TemplatePoint._008B_0089_008E(obj2, 0.0 - obj.X, 0.0 - obj.Y), new TemplatePoint(0.0, 0.0), 0.0 - num2);
			obj9 = new FlyOverPostArea(num, obj8, P_0);
			_008A_008A_0087 = PointLists._008B_008A_0094(obj9._0089_009B_009E, new TemplatePoint(0.0, 0.0), num2);
			_008A_008A_0087 = PointLists._008B_008A_0096(_008A_008A_0087, obj);
			PointLists._008B_008B_0086(ref _008A_0089_0095, _008A_008A_0087);
		}

// R5 MethodDef: original 0x060005D8 RVA 0xB11B0; processed 0x060005D7 RVA 0x82C74; source 03_recovered-src\annotated-strings\--\--.cs:70997; processed IL recovery, not original runtime.
private void _008A_0088_008B()
		{
			int num = default(int); // IL InitLocals

			num = 6;
			while (true)
			{
				if (!false /* original-file-bool-offset:1232 */)
				{
					if (_008A_0088_0095 >= 6351.95)
					{
						if (_008A_0088_0094 >= 6351.95)
						{
							if (_008A_0088_0093 >= 6351.95)
							{
								if (_008A_0088_0093 >= 6351.95)
								{
									num = 21;
									goto IL_0107;
								}
								goto IL_06e8;
							}
							_008A_0089_008B = new List<TemplatePoint>
							{
								_008A_0088_0098,
								_008A_0089_0087,
								TemplatePoint._008B_0089_008B(_008A_0089_0087),
								TemplatePoint._008B_0089_008B(_008A_0088_0098),
								_008A_0088_0098
							};
							_008A_0089_008E = new List<TemplatePoint>
							{
								_008A_0088_009C,
								_008A_0088_0099,
								_008A_0089_0087,
								TemplatePoint._008B_0089_008B(_008A_0089_0087),
								TemplatePoint._008B_0089_008B(_008A_0088_0099),
								TemplatePoint._008B_0089_008B(_008A_0088_009C),
								_008A_0088_009C
							};
							num = 34;
							goto IL_0dab;
						}
						_008A_0089_008B = new List<TemplatePoint>
						{
							_008A_0088_0098,
							_008A_0089_0087,
							TemplatePoint._008B_0089_008B(_008A_0089_0087),
							TemplatePoint._008B_0089_008B(_008A_0088_0098),
							_008A_0088_0098
						};
						num = 17;
						goto IL_09b6;
					}
					throw new Exception("本软件不支持过低的转弯高度，请检查" /* string-offset:6560 */);
				}
				num = 7;
				break;
				IL_0e98:
				_008A_0089_0092 = new List<TemplatePoint> { _008A_0088_009B, _008A_0088_009C, _008A_0088_009E, _008A_0088_009D, _008A_0088_009B };
				_008A_0089_0093 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_009B),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_009D),
					TemplatePoint._008B_0089_008B(_008A_0088_009B)
				};
				_008A_0089_0095 = new List<List<TemplatePoint>> { _008A_0089_008B, _008A_0089_008E, _008A_0089_008F, _008A_0089_0090, _008A_0089_0091, _008A_0089_0092, _008A_0089_0093 };
				break;
				IL_10c7:
				_008A_0089_0093 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_009B),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_009D),
					TemplatePoint._008B_0089_008B(_008A_0088_009B)
				};
				num = 8;
				goto IL_1130;
				IL_1130:
				_008A_0089_0095 = new List<List<TemplatePoint>> { _008A_0089_008B, _008A_0089_008C, _008A_0089_008D, _008A_0089_008E, _008A_0089_008F, _008A_0089_0090, _008A_0089_0091, _008A_0089_0092, _008A_0089_0093 };
				break;
				IL_0b70:
				_008A_0089_0092 = new List<TemplatePoint> { _008A_0088_009B, _008A_0088_009C, _008A_0088_009E, _008A_0088_009D, _008A_0088_009B };
				_008A_0089_0093 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_009B),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_009D),
					TemplatePoint._008B_0089_008B(_008A_0088_009B)
				};
				num = 14;
				goto IL_1279;
				IL_1208:
				_008A_0089_0093 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_009B),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_009D),
					TemplatePoint._008B_0089_008B(_008A_0088_009A),
					TemplatePoint._008B_0089_008B(_008A_0088_009B)
				};
				goto IL_1279;
				IL_1279:
				_008A_0089_0095 = new List<List<TemplatePoint>> { _008A_0089_008B, _008A_0089_008C, _008A_0089_008D, _008A_0089_008E, _008A_0089_008F, _008A_0089_0090, _008A_0089_0091, _008A_0089_0092, _008A_0089_0093 };
				break;
				IL_06e8:
				if (_008A_0088_0093 < 13263.71)
				{
					num = 9;
					goto IL_0577;
				}
				goto IL_06c1;
				IL_0acc:
				_008A_0089_0093 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_0099),
					TemplatePoint._008B_0089_008B(_008A_0088_009D),
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_0099)
				};
				_008A_0089_0095 = new List<List<TemplatePoint>> { _008A_0089_008B, _008A_0089_008E, _008A_0089_0091, _008A_0089_0092, _008A_0089_0093 };
				num = 22;
				break;
				IL_06c1:
				if (_008A_0088_0093 >= 13263.71)
				{
					_008A_0089_008B = new List<TemplatePoint>
					{
						_008A_0088_0098,
						_008A_0088_0099,
						_008A_0089_0086,
						TemplatePoint._008B_0089_008B(_008A_0089_0086),
						TemplatePoint._008B_0089_008B(_008A_0088_0099),
						TemplatePoint._008B_0089_008B(_008A_0088_0098),
						_008A_0088_0098
					};
					goto IL_060c;
				}
				break;
				IL_09b6:
				_008A_0089_008E = new List<TemplatePoint>
				{
					_008A_0088_009C,
					_008A_0089_0087,
					TemplatePoint._008B_0089_008B(_008A_0089_0087),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					_008A_0088_009C
				};
				num = 18;
				goto IL_0a10;
				IL_060c:
				_008A_0089_008C = new List<TemplatePoint> { _008A_0088_0099, _008A_0088_009A, _008A_0089_0087, _008A_0089_0086, _008A_0088_0099 };
				_008A_0089_008D = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_0099),
					TemplatePoint._008B_0089_008B(_008A_0088_009A),
					TemplatePoint._008B_0089_008B(_008A_0089_0087),
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_0099)
				};
				num = 32;
				goto IL_04d1;
				IL_04d1:
				_008A_0089_008E = new List<TemplatePoint>
				{
					_008A_0088_009C,
					_008A_0089_0086,
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					_008A_0088_009C
				};
				_008A_0089_008F = new List<TemplatePoint> { _008A_0088_009C, _008A_0088_009B, _008A_0089_0087, _008A_0089_0086, _008A_0088_009C };
				num = 19;
				goto IL_0459;
				IL_0459:
				_008A_0089_0090 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					TemplatePoint._008B_0089_008B(_008A_0088_009B),
					TemplatePoint._008B_0089_008B(_008A_0089_0087),
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_009C)
				};
				num = 25;
				if (_0088l())
				{
					goto IL_019c;
				}
				goto IL_0410;
				IL_0410:
				_008A_0089_008C = new List<TemplatePoint> { _008A_0088_0099, _008A_0089_0087, _008A_0089_0086, _008A_0088_0099 };
				num = 3;
				goto IL_0362;
				IL_0362:
				_008A_0089_008D = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_0099),
					TemplatePoint._008B_0089_008B(_008A_0089_0087),
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_0099)
				};
				_008A_0089_008E = new List<TemplatePoint>
				{
					_008A_0088_009C,
					_008A_0089_0086,
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					_008A_0088_009C
				};
				num = 24;
				goto IL_0316;
				IL_0316:
				_008A_0089_008F = new List<TemplatePoint> { _008A_0088_009C, _008A_0088_009B, _008A_0089_0087, _008A_0089_0086, _008A_0088_009C };
				goto IL_02a8;
				IL_02a8:
				_008A_0089_0090 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					TemplatePoint._008B_0089_008B(_008A_0088_009B),
					TemplatePoint._008B_0089_008B(_008A_0089_0087),
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_009C)
				};
				num = 10;
				goto IL_023e;
				IL_023e:
				_008A_0089_0091 = new List<TemplatePoint>
				{
					_008A_0088_009C,
					_008A_0088_009E,
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					_008A_0088_009C
				};
				if (_008A_0088_0095 < 13263.71)
				{
					_0088l();
					if (_0088m())
					{
						num = 33;
						if (!_0088m())
						{
							goto IL_019c;
						}
						goto IL_10c7;
					}
					num = 20;
					goto IL_0b70;
				}
				_008A_0089_0092 = new List<TemplatePoint> { _008A_0088_009B, _008A_0088_009C, _008A_0088_009E, _008A_0088_009D, _008A_0088_009A, _008A_0088_009B };
				num = 11;
				goto IL_1208;
				IL_0a10:
				_008A_0089_0091 = new List<TemplatePoint>
				{
					_008A_0088_009C,
					_008A_0088_0099,
					_008A_0088_009E,
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_0099),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					_008A_0088_009C
				};
				_008A_0089_0092 = new List<TemplatePoint> { _008A_0088_0099, _008A_0088_009D, _008A_0088_009E, _008A_0088_0099 };
				num = 1;
				if (!_0088m())
				{
					goto IL_0acc;
				}
				goto IL_0dab;
				IL_0dab:
				_008A_0089_008F = new List<TemplatePoint> { _008A_0088_009C, _008A_0088_0099, _008A_0088_009B, _008A_0088_009C };
				_008A_0089_0090 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					TemplatePoint._008B_0089_008B(_008A_0088_0099),
					TemplatePoint._008B_0089_008B(_008A_0088_009B),
					TemplatePoint._008B_0089_008B(_008A_0088_009C)
				};
				num = 30;
				goto IL_0e3e;
				IL_019c:
				switch (num)
				{
				case 21:
					break;
				case 10:
					goto IL_023e;
				case 26:
					goto IL_02a8;
				case 24:
					goto IL_0316;
				case 3:
					goto IL_0362;
				case 29:
					goto IL_0410;
				case 19:
					goto IL_0459;
				case 32:
					goto IL_04d1;
				case 9:
					goto IL_0577;
				case 27:
				case 33:
					goto IL_060c;
				case 6:
					continue;
				default:
					num = 16;
					goto IL_1279;
				case 4:
					goto IL_0871;
				case 13:
					goto IL_08b5;
				case 17:
					goto IL_09b6;
				case 18:
					goto IL_0a10;
				case 1:
					goto IL_0acc;
				case 15:
				case 20:
					goto IL_0b70;
				case 22:
					return;
				case 23:
					goto IL_0c26;
				case 25:
					_008A_0089_0091 = new List<TemplatePoint>
					{
						_008A_0088_009C,
						_008A_0088_009E,
						TemplatePoint._008B_0089_008B(_008A_0088_009E),
						TemplatePoint._008B_0089_008B(_008A_0088_009C),
						_008A_0088_009C
					};
					goto case 2;
				case 2:
					_008A_0089_0092 = new List<TemplatePoint> { _008A_0088_009B, _008A_0088_009C, _008A_0088_009E, _008A_0088_009D, _008A_0088_009B };
					num = 12;
					goto IL_10c7;
				case 28:
					goto IL_0d55;
				case 34:
					goto IL_0dab;
				case 30:
					goto IL_0e3e;
				case 0:
					goto IL_0e98;
				case 35:
					goto IL_0f9f;
				case 5:
					goto IL_1046;
				case 31:
					return;
				case 12:
					goto IL_10c7;
				case 8:
					goto IL_1130;
				case 11:
					goto IL_1208;
				case 14:
				case 16:
					goto IL_1279;
				case 7:
				case 36:
					return;
				}
				goto IL_0107;
				IL_0577:
				if (!(_008A_0088_0094 >= 13263.71))
				{
					goto IL_06c1;
				}
				_008A_0089_008B = new List<TemplatePoint>
				{
					_008A_0088_0098,
					_008A_0088_0099,
					_008A_0089_0086,
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_0099),
					TemplatePoint._008B_0089_008B(_008A_0088_0098),
					_008A_0088_0098
				};
				num = 4;
				if (_0088m())
				{
					goto IL_060c;
				}
				goto IL_0871;
				IL_0e3e:
				_008A_0089_0091 = new List<TemplatePoint>
				{
					_008A_0088_009C,
					_008A_0088_009E,
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					_008A_0088_009C
				};
				num = 0;
				goto IL_0e98;
				IL_0871:
				_008A_0089_008C = new List<TemplatePoint> { _008A_0088_0099, _008A_0089_0087, _008A_0089_0086, _008A_0088_0099 };
				num = 13;
				goto IL_08b5;
				IL_08b5:
				_008A_0089_008D = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_0099),
					TemplatePoint._008B_0089_008B(_008A_0089_0087),
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_0099)
				};
				_008A_0089_008E = new List<TemplatePoint>
				{
					_008A_0088_009C,
					_008A_0089_0086,
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					_008A_0088_009C
				};
				_008A_0089_008F = new List<TemplatePoint> { _008A_0088_009C, _008A_0088_009B, _008A_0088_009A, _008A_0089_0087, _008A_0089_0086, _008A_0088_009C };
				num = 23;
				goto IL_0c26;
				IL_0c26:
				_008A_0089_0090 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					TemplatePoint._008B_0089_008B(_008A_0088_009B),
					TemplatePoint._008B_0089_008B(_008A_0088_009A),
					TemplatePoint._008B_0089_008B(_008A_0089_0087),
					TemplatePoint._008B_0089_008B(_008A_0089_0086),
					TemplatePoint._008B_0089_008B(_008A_0088_009C)
				};
				num = 28;
				if (!_0088l())
				{
					break;
				}
				goto IL_0d55;
				IL_0d55:
				_008A_0089_0091 = new List<TemplatePoint>
				{
					_008A_0088_009C,
					_008A_0088_009E,
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					_008A_0088_009C
				};
				goto IL_0f9f;
				IL_0f9f:
				_008A_0089_0092 = new List<TemplatePoint> { _008A_0088_009B, _008A_0088_009C, _008A_0088_009E, _008A_0088_009D, _008A_0088_009B };
				_008A_0089_0093 = new List<TemplatePoint>
				{
					TemplatePoint._008B_0089_008B(_008A_0088_009B),
					TemplatePoint._008B_0089_008B(_008A_0088_009C),
					TemplatePoint._008B_0089_008B(_008A_0088_009E),
					TemplatePoint._008B_0089_008B(_008A_0088_009D),
					TemplatePoint._008B_0089_008B(_008A_0088_009B)
				};
				goto IL_1046;
				IL_1046:
				_008A_0089_0095 = new List<List<TemplatePoint>> { _008A_0089_008B, _008A_0089_008C, _008A_0089_008D, _008A_0089_008E, _008A_0089_008F, _008A_0089_0090, _008A_0089_0091, _008A_0089_0092, _008A_0089_0093 };
				num = 31;
				break;
				IL_0107:
				if (_008A_0088_0094 < 13263.71)
				{
					_008A_0089_008B = new List<TemplatePoint>
					{
						_008A_0088_0098,
						_008A_0088_0099,
						_008A_0089_0086,
						TemplatePoint._008B_0089_008B(_008A_0089_0086),
						TemplatePoint._008B_0089_008B(_008A_0088_0099),
						TemplatePoint._008B_0089_008B(_008A_0088_0098),
						_008A_0088_0098
					};
					num = 29;
					if (!_0088m())
					{
						goto IL_019c;
					}
					goto IL_0459;
				}
				goto IL_06e8;
			}
		}

// R5 MethodDef: original 0x060005D9 RVA 0xB24D0; processed 0x060005D8 RVA 0x83F74; source 03_recovered-src\annotated-strings\--\--.cs:71489; processed IL recovery, not original runtime.
public PbnDepartureObstacle _008A_0088_008C(PbnDepartureObstacle P_0, bool P_1 = true)
		{
			int num = default(int); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			num = 5;
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				if (!false /* original-file-bool-offset:1236 */)
				{
					if (P_1)
					{
						num = 18;
						if (_0088l())
						{
						}
						goto IL_0241;
					}
					if (!B5Math._008B_0088_008B(_008A_0089_009B, new TemplatePoint(P_0.X, P_0.Y)))
					{
						num = 19;
						goto IL_0371;
					}
					num2 = ((P_0.Y > 0.0) ? P_0.Y : (0.0 - P_0.Y));
					num3 = _008A_0089_0087.X;
					num4 = ((num2 <= _008A_0089_0087.Y) ? Math.Abs(P_0.X - _008A_0089_0087.X) : Math.Sqrt((P_0.X - _008A_0089_0087.X) * (P_0.X - _008A_0089_0087.X) + (num2 - _008A_0089_0087.Y) * (num2 - _008A_0089_0087.Y)));
					P_0._0088_008E_0096((P_0.X >= _008A_0089_0087.X) ? "离场转弯段--KK线之后" /* string-offset:6568 */ : "离场转弯段--KK线之前" /* string-offset:6552 */);
					P_0._0088_008F_0086(num3);
					num = 4;
					if (_0088l())
					{
						goto IL_0137;
					}
				}
				else
				{
					_0088l();
					if (!_0088m())
					{
						goto IL_03c2;
					}
					num = 11;
					if (_0088l())
					{
						goto IL_0209;
					}
				}
				goto IL_0395;
				IL_0241:
				if (B5Math._008B_0088_008B(_008A_0089_009A, new TemplatePoint(P_0.X, P_0.Y)))
				{
					if (P_0.X >= _008A_0089_0087.X)
					{
						num4 = P_0.X - _008A_0089_0087.X;
						num = 8;
						goto IL_01c8;
					}
					num4 = 0.0;
					num = 0;
					goto IL_0202;
				}
				num = 3;
				goto IL_02c9;
				IL_02c9:
				P_0._0088_008E_0096("out" /* string-offset:1556 */);
				return P_0;
				IL_03c2:
				P_0._0088_008F_008F(_008A_0089_0088.Z + 5.0 + num4 * _008A_0088_0097 + num3 * _008A_0088_0096);
				P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0089_0088.Z - 5.0) / (num4 + num3)));
				break;
				IL_0202:
				num3 = P_0.X;
				goto IL_0209;
				IL_0371:
				P_0._0088_008E_0096("out" /* string-offset:1556 */);
				num = 10;
				if (!_0088l())
				{
				}
				goto IL_0391;
				IL_0391:
				return P_0;
				IL_01c8:
				num3 = _008A_0089_0087.X;
				P_0._0088_008E_0096("离场直线段--KK线之后" /* string-offset:6564 */);
				num = 2;
				goto IL_0222;
				IL_0222:
				P_0._0088_008F_0086(num3);
				num = 12;
				if (_0088l())
				{
					goto IL_0137;
				}
				goto IL_02db;
				IL_0209:
				P_0._0088_008E_0096("离场直线段--KK线之前" /* string-offset:1564 */);
				num = 6;
				goto IL_0222;
				IL_0318:
				P_0._0088_008F_008F(_008A_0089_0098._008A_009D_0096 + num4 * _008A_0088_0097);
				num = 9;
				goto IL_033b;
				IL_033b:
				P_0._0088_008F_0092(Math.Max(0.0, (P_0._0088_008F_008B() - _008A_0089_0088.Z - 5.0) / (num4 + num3)));
				goto IL_0393;
				IL_02db:
				P_0._0088_008F_0089(Math.Max(75.0, (num4 + num3) * 0.008));
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				num = 16;
				goto IL_0318;
				IL_0395:
				P_0._0088_008E_009C(num4);
				goto IL_039c;
				IL_039c:
				P_0._0088_008F_0089((num4 + num3) * 0.008);
				P_0._0088_008F_008C(P_0.Z + P_0._0088_008F_0088());
				goto IL_03c2;
				IL_0393:
				return P_0;
				IL_0137:
				switch (num)
				{
				case 8:
					break;
				case 0:
					goto IL_0202;
				case 7:
				case 11:
					goto IL_0209;
				case 2:
				case 6:
					goto IL_0222;
				case 18:
					goto IL_0241;
				case 5:
					continue;
				case 4:
					P_0._0088_008E_009C(num4);
					goto IL_02db;
				case 3:
					goto IL_02c9;
				case 15:
					goto IL_02db;
				case 16:
					goto IL_0318;
				case 9:
					goto IL_033b;
				case 19:
					goto IL_0371;
				case 10:
					goto IL_0391;
				case 20:
					goto IL_0393;
				case 12:
					goto IL_0395;
				default:
					goto IL_039c;
				case 1:
				case 17:
					goto IL_03c2;
				case 13:
					goto end_IL_0292;
				}
				goto IL_01c8;
				continue;
				end_IL_0292:
				break;
			}
			return P_0;
		}

// R5 MethodDef: original 0x060005DA RVA 0xB296C; processed 0x060005D9 RVA 0x843A8; source 03_recovered-src\annotated-strings\--\--.cs:71660; processed IL recovery, not original runtime.
public void _008A_0088_008D()
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			/* opaque discard 0 */
			if (_0088l())
			{
				list = PointLists._008B_008A_0092(_008A_0088_0098, _008A_0088_0099);
				_008A_0089_0095.Add(PointLists._008B_008A_0099(list));
				list = PointLists._008B_008A_0092(_008A_0088_0099, _008A_0088_009B);
			}
			_008A_0089_0095.Add(PointLists._008B_008A_0099(list));
		}

// R5 MethodDef: original 0x060005DB RVA 0xB2A64; processed 0x060005DA RVA 0x517B; source 03_recovered-src/annotated-strings/--/--.cs:71673; processed IL recovery, not original runtime.
static PbnDepartureFlyOver()
		{

			// Host licensing not executed in independent recovery.
			_0088m();
			if (_0088l())
			{
				_008A_0089_009C = Math.PI / 12.0;
			}
			_008A_0089_009D = Math.PI / 2.0;
		}

// R5 MethodDef: original 0x060005DC RVA 0xB2B1C; processed 0x060005DB RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:71684; processed IL recovery, not original runtime.
internal static bool _0088l()
		{

			return true;
		}

// R5 MethodDef: original 0x060005DD RVA 0xB2B28; processed 0x060005DC RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:71689; processed IL recovery, not original runtime.
internal static bool _0088m()
		{

			return false;
		}
	}
}
