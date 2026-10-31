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
	public class Holding
	{
		public TurnInput _0088_0088_008E;

		public double _0088_0088_008F;

		public double _0088_0088_0090;

		public double _0088_0088_0091;

		public double _0088_0088_0092;

		public double _0088_0088_0093;

		private double _0088_0088_0094;

		private double _0088_0088_0095;

		public double _0088_0088_0096;

		public double _0088_0088_0097;

		public double _0088_0088_0098;

		public double _0088_0088_0099;

		public double _0088_0088_009A;

		public double _0088_0088_009B;

		public double _0088_0088_009C;

		public double _0088_0088_009D;

		public double _0088_0088_009E;

		public double _0088_0089_0086;

		private TemplatePoint _0088_0089_0087;

		private TemplatePoint _0088_0089_0088;

		private TemplatePoint _0088_0089_0089;

		private TemplatePoint _0088_0089_008A;

		private TemplatePoint _0088_0089_008B;

		private TemplatePoint _0088_0089_008C;

		private TemplatePoint _0088_0089_008D;

		private TemplatePoint _0088_0089_008E;

		private TemplatePoint _0088_0089_008F;

		private TemplatePoint _0088_0089_0090;

		private TemplatePoint _0088_0089_0091;

		private TemplatePoint _0088_0089_0092;

		private TemplatePoint _0088_0089_0093;

		private TemplatePoint _0088_0089_0094;

		private TemplatePoint _0088_0089_0095;

		private TemplatePoint _0088_0089_0096;

		private TemplatePoint _0088_0089_0097;

		private TemplatePoint _0088_0089_0098;

		private TemplatePoint _0088_0089_0099;

		private TemplatePoint _0088_0089_009A;

		private TemplatePoint _0088_0089_009B;

		private TemplatePoint _0088_0089_009C;

		private TemplatePoint _0088_0089_009D;

		private TemplatePoint _0088_0089_009E;

		private TemplatePoint _0088_008A_0086;

		private TemplatePoint _0088_008A_0087;

		private Spiral88 _0088_008A_0088;

		private Spiral88 _0088_008A_0089;

		private Spiral88 _0088_008A_008A;

		private Spiral88 _0088_008A_008B;

		private Spiral88 _0088_008A_008C;

		private Spiral88 _0088_008A_008D;

		public double _0088_008A_008E;

		public double _0088_008A_008F;

		public double _0088_008A_0090;

		public List<TemplatePoint> _0088_008A_0091;

		public List<TemplatePoint> _0088_008A_0092;

		public List<TemplatePoint> _0088_008A_0093;

		public List<TemplatePoint> _0088_008A_0094;

		public List<List<TemplatePoint>> _0088_008A_0095;

		public List<List<TemplatePoint>> _0088_008A_0096;

		private double _0088_008A_0097;

		private double _0088_008A_0098;

		private double _0088_008A_0099;

		private double _0088_008A_009A;

// Original MethodDef: 0x060003AC; Original RVA: 0x5D9B8; Processed MethodDef: 0x060003AB; Evidence: Holding.source.txt:38768 + independent IL (decompilation/recovery, not runtime).
		public Holding(TurnInput P_0, double P_1 = 1.0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (!_0087b())
			{
				goto IL_0238;
			}
			if (false /* original-file-bool-offset:676 */)
			{
				return;
			}
			_0088_008A_008E = Math.PI / 180.0;
			_0088_008A_008F = Math.PI / 4.0;
			_0088_008A_0090 = Math.PI / 2.0;
			// object constructor emitted automatically by C#
			_0088_0088_0088(P_0, P_1);
			_0088_008A_0088 = new Spiral88(_0088_0088_008E, _0088_0089_009D, _0088_008A_0090, _0088_0088_009A);
			/* opaque discard 1 */
			if (!_0087c())
			{
				_0088_008A_0089 = new Spiral88(_0088_0088_008E, _0088_0089_009E, _0088_008A_0090, _0088_0088_009B);
				if (_0087b())
				{
					_0088_008A_008A = new Spiral88(_0088_0088_008E, _0088_0089_0099, 4.71238898038469, _0088_0088_009C);
					_0088_008A_008B = new Spiral88(_0088_0088_008E, _0088_0089_009A, 4.71238898038469, _0088_0088_009D);
					_0088_008A_008C = new Spiral88(_0088_0088_008E, _0088_0089_009B, 4.71238898038469, _0088_0088_009C);
					_0088_008A_008D = new Spiral88(_0088_0088_008E, _0088_0089_009C, -Math.PI / 2.0, _0088_0088_009D);
					_0088_008A_0097 = _0088_008A_0089._008B_0086_009D(_0088_008A_0088);
					_0088_008A_0093 = new List<TemplatePoint>
					{
						new TemplatePoint(0.0, 0.0)
					};
					PointLists._008B_008B_0087(ref _0088_008A_0093, _0088_008A_0089._008B_0086_0093(0.0, _0088_008A_0097 - _0088_008A_0089._008B_0087_0087));
					list = _0088_008A_0088._008B_0086_0093(_0088_008A_0097 - _0088_008A_0088._008B_0087_0087, 5.026548245743669);
					PointLists._008B_008B_0087(ref _0088_008A_0093, list);
					_0088_008A_0098 = _0088_008A_0089._008B_0086_009D(_0088_008A_008A);
					goto IL_02fd;
				}
				goto IL_033b;
			}
			goto IL_03da;
			IL_02fd:
			_0088_008A_0099 = _0088_008A_008A._008B_0086_009D(_0088_008A_008B);
			_0088_008A_009A = _0088_008A_008D._008B_0086_009D(_0088_008A_0089);
			_0088_008A_0092 = new List<TemplatePoint>();
			goto IL_0238;
			IL_0238:
			_0088_008A_0092.Add(new TemplatePoint(0.0, 0.0));
			PointLists._008B_008B_0087(ref _0088_008A_0092, _0088_008A_0089._008B_0086_0093(0.0, _0088_008A_0098 - _0088_008A_0089._008B_0087_0087));
			PointLists._008B_008B_0087(ref _0088_008A_0092, _0088_008A_008A._008B_0086_0093(_0088_008A_0098 - _0088_008A_008A._008B_0087_0087, _0088_008A_0099 - _0088_008A_008A._008B_0087_0087));
			if (!_0087b())
			{
				goto IL_02fd;
			}
			goto IL_033b;
			IL_033b:
			PointLists._008B_008B_0087(ref _0088_008A_0092, _0088_008A_008B._008B_0086_0093(_0088_008A_0099 - _0088_008A_008B._008B_0087_0087, _0088_008A_0090 + _0088_0088_008E._008A_009E_0086));
			PointLists._008B_008B_0087(ref _0088_008A_0092, _0088_008A_008D._008B_0086_0093(_0088_008A_0090 + _0088_0088_008E._008A_009E_0086, _0088_008A_009A - _0088_008A_008D._008B_0087_0087));
			goto IL_03da;
			IL_03da:
			PointLists._008B_008B_0087(ref _0088_008A_0092, _0088_008A_0089._008B_0086_0093(_0088_008A_009A - _0088_008A_0089._008B_0087_0087, _0088_0088_008E._008A_009E_0086 + _0088_008A_0090));
			_0088_0088_0094 = _0088_008A_008D._008B_0086_0095(_0088_008A_0090 + _0088_0088_008E._008A_009E_0086).X;
			_0088_0088_0095 = _0088_008A_008D._008B_0086_0095(Math.PI + _0088_0088_008E._008A_009E_0086).Y;
		}

// Original MethodDef: 0x060003AD; Original RVA: 0x5DFA4; Processed MethodDef: 0x060003AC; Evidence: Holding.source.txt:38832 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0087_009A(bool P_0 = false)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			TemplatePoint item = default(TemplatePoint); // IL InitLocals
			TemplatePoint item2 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj4 = default(TemplatePoint); // IL InitLocals

			if (!true /* original-file-bool-offset:680 */)
			{
				return;
			}
			_0088_008A_0091 = new List<TemplatePoint>();
			_0088_0089_0087 = new TemplatePoint(0.0, 0.0);
			if (!_0087b())
			{
				goto IL_01d3;
			}
			// IL local declared at method entry
			while (true)
			{
				_0088_008A_0091.Add(_0088_0089_0087);
				if (P_0)
				{
					break;
				}
				obj = TemplatePoint._008B_0089_0088(_0088_0089_0087, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 0.0 - _0088_008A_0090));
				/* opaque discard 0 */
				if (_0087b())
				{
					if (!_0087b())
					{
						continue;
					}
					goto IL_013e;
				}
				goto IL_01df;
			}
			obj2 = new TemplatePoint(0.0, -2.0 * _0088_0088_008E._008A_009D_009D);
			_0088_008A_0091.Add(obj2);
			item = TemplatePoint._008B_0089_0088(obj2, new TemplatePoint(_0088_0088_0091, 0.0));
			_0088_008A_0091.Add(item);
			item2 = new TemplatePoint(_0088_0088_0091, 0.0);
			_0088_008A_0091.Add(item2);
			goto IL_0238;
			IL_013e:
			_0088_0088_008D(ref _0088_008A_0091, obj, _0088_0088_008E._008A_009D_009D, 90.0, 180.0);
			obj3 = new TemplatePoint(0.0, -2.0 * _0088_0088_008E._008A_009D_009D);
			_0088_008A_0091.Add(obj3);
			obj4 = TemplatePoint._008B_0089_0088(obj3, new TemplatePoint(_0088_0088_0091, 0.0));
			goto IL_01d3;
			IL_01d3:
			_0088_008A_0091.Add(obj4);
			goto IL_01df;
			IL_0238:
			_0088_008A_0091.Add(_0088_0089_0087);
			return;
			IL_01df:
			obj = TemplatePoint._008B_0089_0088(obj4, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, _0088_008A_0090));
			_0088_0088_008D(ref _0088_008A_0091, obj, _0088_0088_008E._008A_009D_009D, -90.0, 180.0);
			goto IL_0238;
		}

// Original MethodDef: 0x060003AE; Original RVA: 0x5E31C; Processed MethodDef: 0x060003AD; Evidence: Holding.source.txt:38889 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0087_009B(bool P_0 = true)
		{

			if (!false /* original-file-bool-offset:684 */)
			{
				_0088_008A_0095 = new List<List<TemplatePoint>> { _0088_008A_0092, _0088_008A_0093 };
				if (P_0)
				{
					_0088_008A_0095.Add(_0088_008A_0089._008B_0086_0093(0.0, _0088_008A_0097 - _0088_008A_0089._008B_0087_0087, 0.0, 1.0, false, P_0));
					_0087b();
					if (!_0087c())
					{
						goto IL_008f;
					}
					goto IL_00dd;
				}
				return;
			}
			return;
			IL_008f:
			_0088_008A_0095.Add(_0088_008A_0089._008B_0086_0093(_0088_008A_009A - _0088_008A_0089._008B_0087_0087, _0088_008A_0098 - _0088_008A_0089._008B_0087_0087, 0.0, 1.0, P_0, P_0));
			goto IL_00dd;
			IL_00dd:
			_0088_008A_0095.Add(_0088_008A_0088._008B_0086_0093(_0088_008A_0097 - _0088_008A_0088._008B_0087_0087, 5.026548245743669, 0.0, 1.0, P_0, P_0));
			_0088_008A_0095.Add(_0088_008A_008A._008B_0086_0093(_0088_008A_0098 - _0088_008A_008A._008B_0087_0087, _0088_008A_0099 - _0088_008A_008A._008B_0087_0087, 0.0, 1.0, P_0, P_0));
			_0088_008A_0095.Add(_0088_008A_008B._008B_0086_0093(_0088_008A_0099 - _0088_008A_008B._008B_0087_0087, _0088_008A_0090 + _0088_0088_008E._008A_009E_0086, 0.0, 1.0, P_0, P_0));
			if (_0087b())
			{
				_0088_008A_0095.Add(_0088_008A_008D._008B_0086_0093(_0088_008A_0090 + _0088_0088_008E._008A_009E_0086, _0088_008A_009A - _0088_008A_008D._008B_0087_0087, 0.0, 1.0, P_0, P_0));
				return;
			}
			goto IL_008f;
		}

// Original MethodDef: 0x060003AF; Original RVA: 0x5E5F4; Processed MethodDef: 0x060003AE; Evidence: Holding.source.txt:38922 + independent IL (decompilation/recovery, not runtime).
		private TemplatePoint _0088_0087_009C(List<TemplatePoint> P_0)
		{
			TemplatePoint result = default(TemplatePoint); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			result = new TemplatePoint();
			num = 0.0;
			foreach (TemplatePoint item in P_0)
			{
				num2 = item.X * item.X + item.Y * item.Y;
				if (num2 > num)
				{
					result = item;
					num = num2;
					continue;
				}
				break;
			}
			return result;
		}

// Original MethodDef: 0x060003B0; Original RVA: 0x5E688; Processed MethodDef: 0x060003AF; Evidence: Holding.source.txt:38940 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0087_009D(TemplatePoint P_0, TemplatePoint P_1, double P_2, double P_3, bool P_4 = false)
		{
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals
			List<List<TemplatePoint>> list2 = default(List<List<TemplatePoint>>); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num = default(double); // IL InitLocals
			int i = default(int); // IL InitLocals
			List<TemplatePoint> list3 = default(List<TemplatePoint>); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			List<TemplatePoint> list4 = default(List<TemplatePoint>); // IL InitLocals
			List<TemplatePoint> list5 = default(List<TemplatePoint>); // IL InitLocals

			if (false /* original-file-bool-offset:688 */)
			{
				return;
			}
			list = new List<List<TemplatePoint>>();
			list2 = new List<List<TemplatePoint>>();
			list2.Add(PointLists._008B_008A_0098(_0088_008A_0092, P_0));
			list2.Add(PointLists._008B_008A_0098(_0088_008A_0092, TemplatePoint._008B_0089_008B(P_0)));
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			if (!_0087c())
			{
				list2.Add(PointLists._008B_008A_0098(_0088_008A_0092, P_1));
				list2.Add(PointLists._008B_008A_0098(_0088_008A_0092, TemplatePoint._008B_0089_008B(P_1)));
				list3 = PointLists._008B_008A_008D(list2);
				_0087b();
				if (!_0087c())
				{
					list3 = _0088_0087_009E(list3);
					list.Add(list3);
					obj = new TemplatePoint(_0088_0088_0094 - P_2, P_3 + _0088_0088_0095);
					_0088_0088_0089(ref _0088_008A_0095, obj, new TemplatePoint(0.0, 0.0));
				}
				num = TemplatePoint._008B_0088_009E(P_0, new TemplatePoint(0.0, 0.0));
				i = 0;
			}
			for (; i <= 80; i += 10)
			{
				obj2 = new TemplatePoint(num * Math.Cos((double)i * _0088_008A_008E) - obj.X, num * Math.Sin((double)i * _0088_008A_008E) - obj.Y);
				list.Add(PointLists._008B_008A_0098(list3, obj2));
			}
			list4 = PointLists._008B_008A_0098(_0088_008A_0093, TemplatePoint._008B_0089_008B(P_1));
			list5 = PointLists._008B_008A_0098(PointLists._008B_008A_009C(_0088_008A_0093), P_1);
			list.Add(PointLists._008B_008A_0095(list4, new TemplatePoint(0.0, 0.0), -70.0 * _0088_008A_008E));
			list.Add(PointLists._008B_008A_0095(list5, new TemplatePoint(0.0, 0.0), -70.0 * _0088_008A_008E));
			_0088_008A_0096 = new List<List<TemplatePoint>>();
			if (P_4)
			{
				PointLists._008B_008B_0086(ref _0088_008A_0096, list);
				PointLists._008B_008B_0086(ref _0088_008A_0096, list2);
			}
			list3 = PointLists._008B_008A_008D(list);
			list3 = _0088_0087_009E(list3);
			_0088_008A_0096.Add(list3);
		}

// Original MethodDef: 0x060003B1; Original RVA: 0x5EA5C; Processed MethodDef: 0x060003B0; Evidence: Holding.source.txt:38990 + independent IL (decompilation/recovery, not runtime).
		private static List<TemplatePoint> _0088_0087_009E(List<TemplatePoint> P_0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals

			if (P_0.Count < 3)
			{
				return P_0;
			}
			list = new List<TemplatePoint>();
			obj = P_0[0];
			foreach (TemplatePoint item in P_0)
			{
				if (item.Y < obj.Y || (item.Y == obj.Y && item.X < obj.X))
				{
					obj = item;
				}
			}
			list.Add(obj);
			obj2 = obj;
			do
			{
				obj3 = P_0[0];
				foreach (TemplatePoint item2 in P_0)
				{
					if (obj3 == obj2 || _0088_0088_0086(obj2, obj3, item2) == 2)
					{
						obj3 = item2;
					}
				}
				list.Add(obj3);
				obj2 = obj3;
			}
			while (obj2 != obj);
			return list;
		}

// Original MethodDef: 0x060003B2; Original RVA: 0x5EB88; Processed MethodDef: 0x060003B1; Evidence: Holding.source.txt:39024 + independent IL (decompilation/recovery, not runtime).
		private static int _0088_0088_0086(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{
			double num = default(double); // IL InitLocals

			/* opaque discard 0 */
			// IL local declared at method entry
			if (_0087b())
			{
				num = (P_1.Y - P_0.Y) * (P_2.X - P_1.X) - (P_1.X - P_0.X) * (P_2.Y - P_1.Y);
			}
			if (num == 0.0)
			{
				return 0;
			}
			if (!(num > 0.0))
			{
				return 2;
			}
			return 1;
		}

// Original MethodDef: 0x060003B3; Original RVA: 0x5EC60; Processed MethodDef: 0x060003B2; Evidence: Holding.source.txt:39043 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0088_0087()
		{

		}

// Original MethodDef: 0x060003B4; Original RVA: 0x5EC6C; Processed MethodDef: 0x060003B3; Evidence: Holding.source.txt:39047 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0088_0088(TurnInput P_0, double P_1 = 1.0)
		{
			int num = default(int); // IL InitLocals

			// IL local declared at method entry
			while (!false /* original-file-bool-offset:692 */)
			{
				_0088_0088_008E = P_0;
				_0088_0088_008F = _0088_0088_008E._008A_009D_009A / 3.6;
				_0088_0088_0090 = _0088_0088_008E._008A_009D_0098 / 3.6;
				_0088_0088_0093 = 5.0 * _0088_008A_008E;
				_0088_0088_0096 = -5.0 * _0088_0088_008F;
				num = 11;
				while (true)
				{
					_0088_0088_0097 = -11.0 * _0088_0088_008F;
					_0088_0088_0092 = P_1 * 60.0;
					num = 8;
					while (true)
					{
						IL_0799:
						_0088_0088_0091 = _0088_0088_008F * _0088_0088_0092;
						num = 12;
						while (true)
						{
							IL_0771:
							_0088_0088_0098 = (_0088_0088_0092 - 5.0) * _0088_0088_008F;
							num = 14;
							while (true)
							{
								IL_0749:
								_0088_0088_0099 = (_0088_0088_0092 + 21.0) * _0088_0088_008F;
								num = 16;
								while (true)
								{
									IL_071e:
									_0088_0088_009A = 5.0 * _0088_0088_0090;
									num = 3;
									if (!_0087b())
									{
										goto IL_0492;
									}
									goto IL_06fd;
									IL_06fd:
									_0088_0088_009B = 11.0 * _0088_0088_0090;
									num = 10;
									goto IL_06b2;
									IL_06b2:
									_0088_0088_009C = (_0088_0088_0092 + 6.0) * _0088_0088_0090 + _0088_0088_008E._008A_009D_009E * Math.PI;
									num = 20;
									if (!_0087b())
									{
										break;
									}
									goto IL_0630;
									IL_0630:
									while (true)
									{
										switch (num)
										{
										case 21:
											break;
										case 17:
											goto IL_00d8;
										case 24:
											goto IL_0138;
										case 26:
											goto IL_0208;
										case 9:
											goto IL_024b;
										case 2:
										case 18:
											goto IL_0295;
										case 4:
											goto IL_02f9;
										case 1:
											goto IL_0332;
										case 0:
											goto IL_036b;
										case 6:
										case 22:
											goto IL_03a8;
										case 19:
											goto IL_03e4;
										case 15:
											goto IL_045a;
										case 27:
											goto IL_0492;
										case 20:
											_0088_0088_009D = _0088_0088_009C + 14.0 * _0088_0088_0090;
											_0088_0088_009E = 2.0 * _0088_0088_008E._008A_009D_009D + (_0088_0088_0092 + 15.0) * _0088_0088_008F + (_0088_0088_0092 + 26.0 + 195.0 / _0088_0088_008E._008A_009D_009C) * _0088_0088_0090;
											_0088_0089_0086 = 11.0 * _0088_0088_008F * Math.Cos(20.0 * _0088_008A_008E) + _0088_0088_008E._008A_009D_009D * (1.0 + Math.Sin(20.0 * _0088_008A_008E)) + (_0088_0088_0092 + 15.0) * _0088_0088_008F * Math.Tan(5.0 * _0088_008A_008E) + (_0088_0088_0092 + 26.0 + 125.0 / _0088_0088_008E._008A_009D_009C) * _0088_0088_0090;
											num = 7;
											goto case 7;
										case 7:
											_0088_0089_0088 = new TemplatePoint(_0088_0088_0096, 0.0);
											goto IL_045a;
										default:
											num = 17;
											if (_0087b())
											{
												continue;
											}
											goto IL_0771;
										case 10:
											goto IL_06b2;
										case 3:
											goto IL_06fd;
										case 16:
											goto IL_071e;
										case 14:
											goto IL_0749;
										case 12:
											goto IL_0771;
										case 8:
											goto IL_0799;
										case 11:
											goto end_IL_071e;
										case 5:
											goto end_IL_07b7;
										case 13:
											_0088_0089_0092 = TemplatePoint._008B_0089_0088(_0088_0089_009C, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, _0088_008A_008F));
											num = 23;
											goto case 23;
										case 23:
											_0088_0089_009B = TemplatePoint._008B_0089_0088(_0088_0089_0097, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, _0088_008A_0090));
											_0088_008A_0086 = TemplatePoint._008B_0089_0088(_0088_0089_009B, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, _0088_008A_0090));
											_0088_0089_009C = TemplatePoint._008B_0089_0088(_0088_0089_0098, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, _0088_008A_0090));
											_0088_008A_0087 = TemplatePoint._008B_0089_0088(_0088_0089_009C, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, _0088_008A_0090));
											num = 28;
											return;
										case 25:
										case 28:
											return;
										}
										break;
									}
									goto IL_007d;
									IL_007d:
									_0088_0089_008E = new TemplatePoint(_0088_0088_0096, -2.0 * _0088_0088_008E._008A_009D_009D);
									_0088_0089_0095 = TemplatePoint._008B_0089_0088(_0088_0089_008D, TemplatePoint._008B_0089_0087(_0088_0088_0098, 0.0 - _0088_0088_0093));
									goto IL_00d8;
									IL_00d8:
									_0088_0089_0097 = TemplatePoint._008B_0089_0088(_0088_0089_008D, TemplatePoint._008B_0089_0087(_0088_0088_0098, _0088_0088_0093));
									_0088_0089_0096 = TemplatePoint._008B_0089_0088(_0088_0089_008D, TemplatePoint._008B_0089_0087(_0088_0088_0099, 0.0 - _0088_0088_0093));
									num = 24;
									goto IL_0138;
									IL_0138:
									_0088_0089_0098 = TemplatePoint._008B_0089_0088(_0088_0089_008D, TemplatePoint._008B_0089_0087(_0088_0088_0099, _0088_0088_0093));
									_0088_0089_009D = TemplatePoint._008B_0089_0088(_0088_0089_0088, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 0.0 - _0088_008A_0090));
									_0088_0089_009E = TemplatePoint._008B_0089_0088(_0088_0089_0089, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 0.0 - _0088_008A_0090));
									_0088_0089_008A = TemplatePoint._008B_0089_0088(_0088_0089_009E, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 3.0 * _0088_008A_008F));
									num = 26;
									goto IL_0208;
									IL_0208:
									_0088_0089_008B = TemplatePoint._008B_0089_0088(_0088_0089_009E, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 4.0 * _0088_008A_008F));
									num = 9;
									goto IL_024b;
									IL_024b:
									_0088_0089_008C = TemplatePoint._008B_0089_0088(_0088_0089_009E, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 5.0 * _0088_008A_008F));
									_0087c();
									if (_0087b())
									{
										goto IL_0295;
									}
									num = 6;
									goto IL_03a8;
									IL_0295:
									_0088_0089_0093 = TemplatePoint._008B_0089_0088(_0088_0089_009D, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 0.0 - _0088_008A_008F));
									_0088_0089_0094 = TemplatePoint._008B_0089_0088(_0088_0089_009D, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 0.0));
									goto IL_02f9;
									IL_02f9:
									_0088_0089_0099 = TemplatePoint._008B_0089_0088(_0088_0089_0095, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, _0088_008A_0090));
									num = 1;
									goto IL_0332;
									IL_0332:
									_0088_0089_009A = TemplatePoint._008B_0089_0088(_0088_0089_0096, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, _0088_008A_0090));
									num = 0;
									goto IL_036b;
									IL_036b:
									_0088_0089_008F = TemplatePoint._008B_0089_0088(_0088_0089_009A, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 0.0 - _0088_008A_008F));
									goto IL_03a8;
									IL_0492:
									_0088_0089_0089 = new TemplatePoint(_0088_0088_0097, 0.0);
									goto IL_007d;
									IL_03a8:
									_0088_0089_0090 = TemplatePoint._008B_0089_0088(_0088_0089_009A, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 0.0));
									num = 19;
									goto IL_03e4;
									IL_03e4:
									_0088_0089_009C = TemplatePoint._008B_0089_0088(_0088_0089_0098, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, _0088_008A_0090));
									_0088_0089_0091 = TemplatePoint._008B_0089_0088(_0088_0089_009C, TemplatePoint._008B_0089_0087(_0088_0088_008E._008A_009D_009D, 0.0));
									num = 13;
									if (_0087c())
									{
										goto IL_045a;
									}
									goto IL_0630;
									IL_045a:
									_0088_0089_008D = new TemplatePoint(_0088_0088_0097, -2.0 * _0088_0088_008E._008A_009D_009D);
									num = 27;
									goto IL_0492;
									continue;
									end_IL_071e:
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					continue;
					end_IL_07b7:
					break;
				}
			}
			num = 25;
		}

// Original MethodDef: 0x060003B5; Original RVA: 0x5F5E8; Processed MethodDef: 0x060003B4; Evidence: Holding.source.txt:39265 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0088_0089(ref List<List<TemplatePoint>> P_0, TemplatePoint P_1, TemplatePoint P_2)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			/* opaque discard 0 */
			if (_0087b())
			{
				list.Add(P_1);
			}
			list.Add(P_2);
			P_0.Add(list);
		}

// Original MethodDef: 0x060003B6; Original RVA: 0x5F698; Processed MethodDef: 0x060003B5; Evidence: Holding.source.txt:39277 + independent IL (decompilation/recovery, not runtime).
		protected void _0088_0088_008A(TemplatePoint P_0, TemplatePoint P_1)
		{

			new List<TemplatePoint> { P_0, P_1 };
		}

// Original MethodDef: 0x060003B7; Original RVA: 0x5F6B4; Processed MethodDef: 0x060003B6; Evidence: Holding.source.txt:39282 + independent IL (decompilation/recovery, not runtime).
		private List<TemplatePoint> _0088_0088_008B(TemplatePoint P_0, TemplatePoint P_1, double P_2, double P_3 = Math.PI * 3.0 / 5.0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:696 */)
			{
				goto IL_0094;
			}
			list = new List<TemplatePoint>();
			num = Math.Atan2(P_1.Y - P_0.Y, P_1.X - P_0.X) - P_3 / 2.0;
			num2 = num + P_3;
			num3 = 2.0 * _0088_008A_008E;
			num4 = num;
			goto IL_0098;
			IL_0094:
			num4 += num3;
			goto IL_0098;
			IL_0098:
			if (num4 < num2)
			{
				num5 = P_2 * Math.Cos(num4) + P_1.X;
				num6 = P_2 * Math.Sin(num4) + P_1.Y;
				list.Add(new TemplatePoint(num5, num6));
				goto IL_0094;
			}
			list.Add(new TemplatePoint(P_2 * Math.Cos(num2) + P_1.X, P_2 * Math.Sin(num2) + P_1.Y));
			return list;
		}

// Original MethodDef: 0x060003B8; Original RVA: 0x5F7A4; Processed MethodDef: 0x060003B7; Evidence: Holding.source.txt:39309 + independent IL (decompilation/recovery, not runtime).
		private void _0088_0088_008C(List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals

			if (!true /* original-file-bool-offset:700 */)
			{
				return;
			}
			num = P_3 + P_4;
			if (P_4 > 0.0)
			{
				num2 = 2.0 * _0088_008A_008E;
				for (double num3 = P_3 + num2; num3 < num; num3 += num2)
				{
					num4 = P_2 * Math.Cos(num3) + P_1.X;
					num5 = P_2 * Math.Sin(num3) + P_1.Y;
					P_0.Add(new TemplatePoint(num4, num5));
				}
			}
			else
			{
				num2 = -2.0 * _0088_008A_008E;
				for (double num6 = P_3 + num2; num6 > num; num6 += num2)
				{
					num7 = P_2 * Math.Cos(num6) + P_1.X;
					num8 = P_2 * Math.Sin(num6) + P_1.Y;
					P_0.Add(new TemplatePoint(num7, num8));
				}
			}
		}

// Original MethodDef: 0x060003B9; Original RVA: 0x5F8A8; Processed MethodDef: 0x060003B8; Evidence: Holding.source.txt:39338 + independent IL (decompilation/recovery, not runtime).
		public void _0088_0088_008D(ref List<TemplatePoint> P_0, TemplatePoint P_1, double P_2, double P_3, double P_4, double P_5 = 2.0)
		{
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			if (!true /* original-file-bool-offset:704 */)
			{
				return;
			}
			// IL local declared at method entry
			while (true)
			{
				num = Math.Abs(P_5);
				if (_0087b())
				{
					num2 = P_3;
					for (double num3 = 0.0; num3 < P_4; num3 += num)
					{
						obj = new TemplatePoint(P_2 * Math.Cos(num2 * _0088_008A_008E), P_2 * Math.Sin(num2 * _0088_008A_008E));
						P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
						num2 += P_5;
						/* opaque discard 0 */
						if (!_0087b())
						{
							break;
						}
					}
					num4 = ((P_5 > 0.0) ? (P_3 + P_4) : (P_3 - P_4));
					if (num2 - P_5 == num4)
					{
						break;
					}
					obj = new TemplatePoint(P_2 * Math.Cos(num4 * _0088_008A_008E), P_2 * Math.Sin(num4 * _0088_008A_008E));
					if (_0087c())
					{
						continue;
					}
				}
				P_0.Add(TemplatePoint._008B_0089_0088(P_1, obj));
				break;
			}
		}

// Original MethodDef: 0x060003BA; Original RVA: 0x5FA9C; Processed MethodDef: 0x060003B9; Evidence: Holding.source.txt:39378 + independent IL (decompilation/recovery, not runtime).
		public override string ToString()
		{

			return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(_0088_0088_008E.ToString() + "======= Holding Parameters=========\n" /* string-offset:5268 */, "v = " /* string-offset:5272 */, Math.Ceiling(_0088_0088_008F).ToString(), "m/s\n" /* string-offset:1504 */), "w = " /* string-offset:5276 */, Math.Ceiling(_0088_0088_0090).ToString(), "m/s\n" /* string-offset:1504 */), "L = " /* string-offset:1536 */, Math.Ceiling(_0088_0088_0091).ToString(), " m\n" /* string-offset:5280 */), "ab = " /* string-offset:5284 */, Math.Ceiling(Math.Abs(_0088_0088_0096)).ToString(), " m\n" /* string-offset:5280 */), "ac = " /* string-offset:5288 */, Math.Ceiling(Math.Abs(_0088_0088_0097)).ToString(), " m\n" /* string-offset:5280 */), "gi1 = gi3 = " /* string-offset:5292 */, Math.Ceiling(_0088_0088_0098).ToString(), " m\n" /* string-offset:5280 */), "gi2 = gi4 = " /* string-offset:5296 */, Math.Ceiling(_0088_0088_0099).ToString(), " m\n" /* string-offset:5280 */), "Wb = " /* string-offset:5300 */, Math.Ceiling(_0088_0088_009A).ToString(), " m\n" /* string-offset:5280 */), "Wc = " /* string-offset:5304 */, Math.Ceiling(_0088_0088_009B).ToString(), " m\n" /* string-offset:5280 */), "Wi1 = Wi3 = " /* string-offset:5308 */, Math.Ceiling(_0088_0088_009C).ToString(), " m\n" /* string-offset:5280 */), "Wi2 = Wi4 = " /* string-offset:5312 */, Math.Ceiling(_0088_0088_009D).ToString(), " m\n" /* string-offset:5280 */), "XE = " /* string-offset:5316 */, Math.Ceiling(_0088_0088_009E).ToString(), " m\n" /* string-offset:5280 */), "YE = " /* string-offset:5320 */, Math.Ceiling(_0088_0089_0086).ToString(), " m\n" /* string-offset:5280 */);
		}

// Original MethodDef: 0x060003BB; Original RVA: 0x5FD10; Processed MethodDef: 0x060003BA; Evidence: Holding.source.txt:39383 + independent IL (decompilation/recovery, not runtime).
		static Holding()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x060003BC; Original RVA: 0x5FD2C; Processed MethodDef: 0x060003BB; Evidence: Holding.source.txt:39388 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0087b()
		{

			return true;
		}

// Original MethodDef: 0x060003BD; Original RVA: 0x5FD38; Processed MethodDef: 0x060003BC; Evidence: Holding.source.txt:39393 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0087c()
		{

			return false;
		}
	}
}
