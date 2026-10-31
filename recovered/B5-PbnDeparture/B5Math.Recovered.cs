using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
// Mechanical recovery of processed source/IL. Original identifiers retained.
// IL locals initialized once at entry. No target assembly or AutoCAD dependency.
namespace Recovered.B5 {
public static class B5Math {
// R5 MethodDef: original 0x060007DA RVA 0xC8260; processed 0x060007D9 RVA 0x91F38; source 03_recovered-src\annotated-strings\--\--.cs:83767; processed IL recovery, not original runtime.
public static List<TemplatePoint> _008B_0088_0089(List<TemplatePoint> P_0)
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
					if (obj3 == obj2 || _008B_0088_008A(obj2, obj3, item2) == 2)
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

// R5 MethodDef: original 0x060007DB RVA 0xC838C; processed 0x060007DA RVA 0x9203C; source 03_recovered-src\annotated-strings\--\--.cs:83801; processed IL recovery, not original runtime.
private static int _008B_0088_008A(TemplatePoint P_0, TemplatePoint P_1, TemplatePoint P_2)
		{
			double num = default(double); // IL InitLocals

			// IL local hoisted
			if (!_0089q())
			{
				num = (P_1.Y - P_0.Y) * (P_2.X - P_1.X) - (P_1.X - P_0.X) * (P_2.Y - P_1.Y);
				_0089q();
				if (!_0089p())
				{
					goto IL_005d;
				}
			}
			if (num != 0.0)
			{
				if (!(num > 0.0))
				{
					return 2;
				}
				return 1;
			}
			goto IL_005d;
			IL_005d:
			return 0;
		}

// R5 MethodDef: original 0x060007DC RVA 0xC8484; processed 0x060007DB RVA 0x920B8; source 03_recovered-src\annotated-strings\--\--.cs:83826; processed IL recovery, not original runtime.
public static bool _008B_0088_008B(List<TemplatePoint> P_0, TemplatePoint P_1)
		{
			int count = default(int); // IL InitLocals
			bool flag = default(bool); // IL InitLocals
			int num = default(int); // IL InitLocals
			int index = default(int); // IL InitLocals
			TemplatePoint obj = default(TemplatePoint); // IL InitLocals
			TemplatePoint obj2 = default(TemplatePoint); // IL InitLocals

			if (false /* original-file-bool-offset:1436 */)
			{
				goto IL_002f;
			}
			count = P_0.Count;
			flag = false;
			num = 0;
			index = count - 1;
			goto IL_0098;
			IL_002f:
			// IL local hoisted
			// IL local hoisted
			if (obj.Y > P_1.Y != obj2.Y > P_1.Y && P_1.X < (obj2.X - obj.X) * (P_1.Y - obj.Y) / (obj2.Y - obj.Y) + obj.X)
			{
				flag = !flag;
			}
			index = num++;
			goto IL_0098;
			IL_0098:
			if (num < count)
			{
				obj = P_0[num];
				obj2 = P_0[index];
				goto IL_002f;
			}
			return flag;
		}

// R5 MethodDef: original 0x060007D2 RVA 0xC7C90; processed 0x060007D1 RVA 0x5F5F; source 03_recovered-src\annotated-strings\--\--.cs:83638; processed IL recovery, not original runtime.
public static double _008B_0087_009A(double a)
{
 return a*Math.PI/180.0;
}
// R5 MethodDef: original 0x060007DF RVA 0xC8578; processed 0x060007DE RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:83861; processed IL recovery, not original runtime.
internal static bool _0089p()
{
 return true;
}
// R5 MethodDef: original 0x060007E0 RVA 0xC8584; processed 0x060007DF RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:83866; processed IL recovery, not original runtime.
internal static bool _0089q()
{
 return false;
}
}
}
