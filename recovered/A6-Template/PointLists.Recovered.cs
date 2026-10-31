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
	public class PointLists
	{
// Original MethodDef: 0x0600081A; Original RVA: 0xC938C; Processed MethodDef: 0x06000819; Evidence: PointLists.source.txt:84382 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_008C(List<TemplatePoint> P_0, double P_1)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals
			double num = default(double); // IL InitLocals
			TemplatePoint obj3 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj4 = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj5 = default(TemplatePoint); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:1444 */)
			{
				goto IL_0082;
			}
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			if (P_0 != null && P_0.Count >= 2)
			{
				list = new List<TemplatePoint>();
				obj = P_0[0];
				obj2 = P_0[1];
				num = TemplatePoint._008B_0089_0086(obj, obj2);
				list.Add(new TemplatePoint(obj.X - P_1 * Math.Sin(num), obj.Y + P_1 * Math.Cos(num)));
				num2 = 1;
				goto IL_00fc;
			}
			throw new ArgumentException("点集必须包含至少两个点" /* string-offset:7492 */);
			IL_0082:
			obj3 = P_0[num2];
			obj4 = P_0[num2 + 1];
			// IL local declared at method entry
			num3 = TemplatePoint._008B_0089_0086(obj3, obj5);
			num4 = TemplatePoint._008B_0089_0086(obj3, obj4);
			num5 = (num3 + num4) / 2.0;
			num6 = obj3.X - P_1 * Math.Sin(num5);
			num7 = obj3.Y + P_1 * Math.Cos(num5);
			list.Add(new TemplatePoint(num6, num7));
			num2++;
			goto IL_00fc;
			IL_00fc:
			if (num2 < P_0.Count - 1)
			{
				obj5 = P_0[num2 - 1];
				goto IL_0082;
			}
			obj = P_0[P_0.Count - 2];
			obj2 = P_0[P_0.Count - 1];
			num = TemplatePoint._008B_0089_0086(obj, obj2);
			list.Add(new TemplatePoint(obj2.X - P_1 * Math.Sin(num), obj2.Y + P_1 * Math.Cos(num)));
			return list;
		}

// Original MethodDef: 0x0600081B; Original RVA: 0xC951C; Processed MethodDef: 0x0600081A; Evidence: PointLists.source.txt:84429 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_008D(List<List<TemplatePoint>> P_0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			foreach (List<TemplatePoint> item in P_0)
			{
				foreach (TemplatePoint item2 in item)
				{
					list.Add(item2);
				}
			}
			return list;
		}

// Original MethodDef: 0x0600081C; Original RVA: 0xC95C0; Processed MethodDef: 0x0600081B; Evidence: PointLists.source.txt:84442 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_008E(List<TemplatePoint> P_0, List<TemplatePoint> P_1)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			list = new List<TemplatePoint>();
			foreach (TemplatePoint item in P_0)
			{
				list.Add(item);
			}
			foreach (TemplatePoint item2 in P_1)
			{
				list.Add(item2);
			}
			return list;
		}

// Original MethodDef: 0x0600081D; Original RVA: 0xC966C; Processed MethodDef: 0x0600081C; Evidence: PointLists.source.txt:84456 + independent IL (decompilation/recovery, not runtime).
		public static List<List<TemplatePoint>> _008B_008A_008F(TemplatePoint P_0, TemplatePoint P_1)
		{

			return new List<List<TemplatePoint>>
			{
				_008B_008A_0092(P_0, P_1),
				_008B_008A_0092(TemplatePoint._008B_0089_0090(P_0, 1.0, 0.5), TemplatePoint._008B_0089_0090(P_1, 1.0, 0.5))
			};
		}

// Original MethodDef: 0x0600081E; Original RVA: 0xC96E0; Processed MethodDef: 0x0600081D; Evidence: PointLists.source.txt:84465 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_0090(TemplatePoint P_0, TemplatePoint P_1)
		{

			return new List<TemplatePoint>
			{
				P_0,
				P_1,
				new TemplatePoint(P_1.X, 0.0, P_1.Z),
				new TemplatePoint(P_0.X, 0.0, P_0.Z),
				P_0
			};
		}

// Original MethodDef: 0x0600081F; Original RVA: 0xC9750; Processed MethodDef: 0x0600081E; Evidence: PointLists.source.txt:84477 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_0091(TemplatePoint P_0, TemplatePoint P_1)
		{

			return new List<TemplatePoint>
			{
				TemplatePoint._008B_0089_008B(P_0),
				TemplatePoint._008B_0089_008B(P_1),
				new TemplatePoint(P_1.X, 0.0, P_1.Z),
				new TemplatePoint(P_0.X, 0.0, P_0.Z),
				TemplatePoint._008B_0089_008B(P_0)
			};
		}

// Original MethodDef: 0x06000820; Original RVA: 0xC97D0; Processed MethodDef: 0x0600081F; Evidence: PointLists.source.txt:84489 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_0092(TemplatePoint P_0, TemplatePoint P_1)
		{

			return new List<TemplatePoint>
			{
				P_0,
				P_1,
				TemplatePoint._008B_0089_008B(P_1),
				TemplatePoint._008B_0089_008B(P_0),
				P_0
			};
		}

// Original MethodDef: 0x06000821; Original RVA: 0xC980C; Processed MethodDef: 0x06000820; Evidence: PointLists.source.txt:84501 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_0093(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{

			return new List<TemplatePoint>
			{
				P_1,
				P_0,
				TemplatePoint._008B_0089_008B(P_0),
				TemplatePoint._008B_0089_008B(P_1),
				TemplatePoint._008B_0089_008B(P_2),
				P_2,
				P_1
			};
		}

// Original MethodDef: 0x06000822; Original RVA: 0xC9868; Processed MethodDef: 0x06000821; Evidence: PointLists.source.txt:84515 + independent IL (decompilation/recovery, not runtime).
		public static List<List<TemplatePoint>> _008B_008A_0094(List<List<TemplatePoint>> P_0, TemplatePoint P_1, double P_2)
		{
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals

			if (P_0 != null && P_0.Count != 0)
			{
				list = new List<List<TemplatePoint>>();
				{
					foreach (List<TemplatePoint> item in P_0)
					{
						list.Add(_008B_008A_0095(item, P_1, P_2));
					}
					return list;
				}
			}
			return null;
		}

// Original MethodDef: 0x06000823; Original RVA: 0xC98E8; Processed MethodDef: 0x06000822; Evidence: PointLists.source.txt:84531 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_0095(List<TemplatePoint> P_0, TemplatePoint P_1, double P_2)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (P_0 != null && P_0.Count != 0)
			{
				list = new List<TemplatePoint>();
				{
					foreach (TemplatePoint item in P_0)
					{
						list.Add(TemplatePoint._008B_0089_008D(P_1, item, P_2));
					}
					return list;
				}
			}
			return null;
		}

// Original MethodDef: 0x06000824; Original RVA: 0xC9968; Processed MethodDef: 0x06000823; Evidence: PointLists.source.txt:84547 + independent IL (decompilation/recovery, not runtime).
		public static List<List<TemplatePoint>> _008B_008A_0096(List<List<TemplatePoint>> P_0, TemplatePoint P_1)
		{
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals

			if (P_0 != null && P_0.Count != 0)
			{
				list = new List<List<TemplatePoint>>();
				{
					foreach (List<TemplatePoint> item in P_0)
					{
						list.Add(_008B_008A_0098(item, P_1));
					}
					return list;
				}
			}
			return null;
		}

// Original MethodDef: 0x06000825; Original RVA: 0xC99E8; Processed MethodDef: 0x06000824; Evidence: PointLists.source.txt:84563 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_0097(List<TemplatePoint> P_0, TemplatePoint P_1)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (P_0 != null && P_0.Count != 0)
			{
				list = new List<TemplatePoint>();
				{
					foreach (TemplatePoint item in P_0)
					{
						list.Add(TemplatePoint._008B_0089_0091(item, P_1));
					}
					return list;
				}
			}
			return null;
		}

// Original MethodDef: 0x06000826; Original RVA: 0xC9A68; Processed MethodDef: 0x06000825; Evidence: PointLists.source.txt:84579 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_0098(List<TemplatePoint> P_0, TemplatePoint P_1)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (P_0 != null && P_0.Count != 0)
			{
				list = new List<TemplatePoint>();
				{
					foreach (TemplatePoint item in P_0)
					{
						list.Add(TemplatePoint._008B_0089_008F(item, P_1));
					}
					return list;
				}
			}
			return null;
		}

// Original MethodDef: 0x06000827; Original RVA: 0xC9AE8; Processed MethodDef: 0x06000826; Evidence: PointLists.source.txt:84595 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_0099(List<TemplatePoint> P_0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (P_0 != null && P_0.Count != 0)
			{
				list = new List<TemplatePoint>();
				{
					foreach (TemplatePoint item in P_0)
					{
						list.Add(TemplatePoint._008B_0089_008C(item));
					}
					return list;
				}
			}
			return null;
		}

// Original MethodDef: 0x06000828; Original RVA: 0xC9B68; Processed MethodDef: 0x06000827; Evidence: PointLists.source.txt:84611 + independent IL (decompilation/recovery, not runtime).
		public static List<List<TemplatePoint>> _008B_008A_009A(List<List<TemplatePoint>> P_0)
		{
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals

			if (P_0 != null && P_0.Count != 0)
			{
				list = new List<List<TemplatePoint>>();
				{
					foreach (List<TemplatePoint> item in P_0)
					{
						list.Add(_008B_008A_0099(item));
					}
					return list;
				}
			}
			return null;
		}

// Original MethodDef: 0x06000829; Original RVA: 0xC9BE8; Processed MethodDef: 0x06000828; Evidence: PointLists.source.txt:84627 + independent IL (decompilation/recovery, not runtime).
		public static List<List<TemplatePoint>> _008B_008A_009B(List<List<TemplatePoint>> P_0)
		{
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals

			if (P_0 != null && P_0.Count != 0)
			{
				list = new List<List<TemplatePoint>>();
				{
					foreach (List<TemplatePoint> item in P_0)
					{
						list.Add(_008B_008A_009C(item));
					}
					return list;
				}
			}
			return null;
		}

// Original MethodDef: 0x0600082A; Original RVA: 0xC9C68; Processed MethodDef: 0x06000829; Evidence: PointLists.source.txt:84643 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_009C(List<TemplatePoint> P_0)
		{
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			if (P_0 != null && P_0.Count != 0)
			{
				list = new List<TemplatePoint>();
				{
					foreach (TemplatePoint item in P_0)
					{
						list.Add(TemplatePoint._008B_0089_008B(item));
					}
					return list;
				}
			}
			return null;
		}

// Original MethodDef: 0x0600082B; Original RVA: 0xC9CE8; Processed MethodDef: 0x0600082A; Evidence: PointLists.source.txt:84659 + independent IL (decompilation/recovery, not runtime).
		public static List<TemplatePoint> _008B_008A_009D(TemplatePoint P_0, TemplatePoint P_1, int P_2 = 10)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			List<TemplatePoint> list = default(List<TemplatePoint>); // IL InitLocals

			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			// IL local declared at method entry
			if (!false /* original-file-bool-offset:1448 */)
			{
				if (P_2 == 0)
				{
					return null;
				}
				num = (P_1.X - P_0.X) / (double)P_2;
				num2 = (P_1.Y - P_0.Y) / (double)P_2;
				num3 = (P_1.Z - P_0.Z) / (double)P_2;
				list = new List<TemplatePoint>();
				list.Add(P_0);
			}
			for (int i = 1; i < P_2; i++)
			{
				list.Add(TemplatePoint._008B_0089_008E(P_0, num * (double)i, num2 * (double)i, num3 * (double)i));
			}
			list.Add(P_1);
			return list;
		}

// Original MethodDef: 0x0600082C; Original RVA: 0xC9D94; Processed MethodDef: 0x0600082B; Evidence: PointLists.source.txt:84685 + independent IL (decompilation/recovery, not runtime).
		public static List<List<TemplatePoint>> _008B_008A_009E(List<TemplatePoint> P_0, List<TemplatePoint> P_1)
		{
			List<List<TemplatePoint>> list = default(List<List<TemplatePoint>>); // IL InitLocals
			int num = default(int); // IL InitLocals
			List<TemplatePoint> list2 = default(List<TemplatePoint>); // IL InitLocals
			List<TemplatePoint> list3 = default(List<TemplatePoint>); // IL InitLocals

			if (false /* original-file-bool-offset:1452 */)
			{
				goto IL_0073;
			}
			// IL local declared at method entry
			// IL local declared at method entry
			if (P_0 != null && P_0.Count != 0 && P_1 != null && P_1.Count != 0)
			{
				if (P_0.Count != P_1.Count)
				{
					return null;
				}
				list = new List<List<TemplatePoint>>();
				num = 1;
				goto IL_00db;
			}
			return null;
			IL_00db:
			// IL local declared at method entry
			// IL local declared at method entry
			if (num < P_0.Count)
			{
				list2 = new List<TemplatePoint>();
				list3 = new List<TemplatePoint>();
				list2.Add(P_0[num - 1]);
				list2.Add(P_0[num]);
				goto IL_0073;
			}
			return list;
			IL_0073:
			list2.Add(P_1[num - 1]);
			list2.Add(P_0[num - 1]);
			list.Add(list2);
			list3.Add(P_1[num - 1]);
			list3.Add(P_1[num]);
			list3.Add(P_0[num]);
			list3.Add(P_1[num - 1]);
			list.Add(list3);
			num++;
			goto IL_00db;
		}

// Original MethodDef: 0x0600082D; Original RVA: 0xC9EA0; Processed MethodDef: 0x0600082C; Evidence: PointLists.source.txt:84729 + independent IL (decompilation/recovery, not runtime).
		public static void _008B_008B_0086(ref List<List<TemplatePoint>> P_0, List<List<TemplatePoint>> P_1)
		{

			if (P_1 == null)
			{
				return;
			}
			foreach (List<TemplatePoint> item in P_1)
			{
				P_0.Add(item);
			}
		}

// Original MethodDef: 0x0600082E; Original RVA: 0xC9F08; Processed MethodDef: 0x0600082D; Evidence: PointLists.source.txt:84741 + independent IL (decompilation/recovery, not runtime).
		public static void _008B_008B_0087(ref List<TemplatePoint> P_0, List<TemplatePoint> P_1)
		{

			if (P_1 == null)
			{
				return;
			}
			foreach (TemplatePoint item in P_1)
			{
				P_0.Add(item);
			}
		}

// Original MethodDef: 0x0600082F; Original RVA: 0xC9F70; Processed MethodDef: 0x0600082E; Evidence: PointLists.source.txt:84753 + independent IL (decompilation/recovery, not runtime).
		public static string _008B_008B_0088(List<List<TemplatePoint>> P_0)
		{
			string text = default(string); // IL InitLocals

			text = "";
			foreach (List<TemplatePoint> item in P_0)
			{
				text += _008B_008B_0089(item);
			}
			return text;
		}

// Original MethodDef: 0x06000830; Original RVA: 0xC9FDC; Processed MethodDef: 0x0600082F; Evidence: PointLists.source.txt:84763 + independent IL (decompilation/recovery, not runtime).
		public static string _008B_008B_0089(List<TemplatePoint> P_0)
		{
			string text = default(string); // IL InitLocals

			text = "";
			foreach (TemplatePoint item in P_0)
			{
				text = text + item.ToString() + "\n" /* string-offset:328 */;
			}
			return text;
		}

// Original MethodDef: 0x06000832; Original RVA: 0xCA064; Processed MethodDef: 0x06000831; Evidence: PointLists.source.txt:84773 + independent IL (decompilation/recovery, not runtime).
		static PointLists()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x06000833; Original RVA: 0xCA080; Processed MethodDef: 0x06000832; Evidence: PointLists.source.txt:84778 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089v()
		{

			return true;
		}

// Original MethodDef: 0x06000834; Original RVA: 0xCA08C; Processed MethodDef: 0x06000833; Evidence: PointLists.source.txt:84783 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089w()
		{

			return false;
		}
	}
}
