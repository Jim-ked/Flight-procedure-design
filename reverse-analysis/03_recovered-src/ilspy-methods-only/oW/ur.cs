using _0090_009C;
using _0091_008C;

namespace oW;

internal class ur
{
	public static string xeI(bool P_0, bool P_1, bool P_2, bool P_3, bool P_4, bool P_5)
	{
		lock (_0091_008B._008B_0095_009D)
		{
			_008C_0095();
			if (!_008C_0096())
			{
				if (_008C_0095())
				{
				}
				_0091_008B._008B_0092_0097(_0020: false);
			}
			return _0091_008B._008B_0093_0095(P_0, P_2, P_3, P_1, P_4, P_5);
		}
	}

	public static void leE(string P_0, out bool P_1, out bool P_2, out bool P_3, out bool P_4, out bool P_5, out bool P_6)
	{
		_008C_0095();
		_0091_008B._0091_008F obj = default(_0091_008B._0091_008F);
		bool flag = default(bool);
		bool flag2 = default(bool);
		bool flag3 = default(bool);
		bool flag4 = default(bool);
		bool flag5 = default(bool);
		if (!_008C_0096())
		{
			if (!_0090_009B._008B_008F_009A(1536))
			{
				return;
			}
			obj = new _0091_008B._0091_008F();
			obj._008B_009B_0092 = true;
			obj._008B_009B_0090 = true;
			obj._008B_009B_0091 = true;
			obj._008B_009B_0097 = true;
			obj._008B_009B_008F = true;
			if (!_008C_0096())
			{
				obj._008B_009B_0093 = true;
				obj._008B_009B_009D = P_0;
				flag = false;
				flag2 = false;
				flag3 = false;
			}
			flag4 = false;
			flag5 = false;
		}
		else if (!_008C_0096())
		{
			goto IL_0095;
		}
		bool flag6 = false;
		_0091_008B._008B_0092_0099(0, obj, ref flag, ref flag2, ref flag3, ref flag4, ref flag5, ref flag6);
		P_1 = flag;
		P_2 = flag4;
		P_3 = flag2;
		P_4 = flag3;
		goto IL_0095;
		IL_0095:
		P_5 = flag5;
		P_6 = flag6;
	}

	internal static bool _008C_0095()
	{
		return true;
	}

	internal static bool _008C_0096()
	{
		return false;
	}
}
