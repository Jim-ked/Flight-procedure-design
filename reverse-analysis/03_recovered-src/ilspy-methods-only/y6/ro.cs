using GN;
using T7;
using _0090_009C;
using _0091_008C;

namespace y6;

internal class ro
{
	internal static string DFB;

	public static bool EFW()
	{
		_0091_008B.ShowMessage(_0090_009B._008B_008F_009D(8420));
		return false;
	}

	public static bool nFZ()
	{
		_0091_008B.ShowMessage(_0090_009B._008B_008F_009D(8424));
		return false;
	}

	public static string WF0()
	{
		lock (_0091_008B._008B_0095_009C)
		{
			DFB = "";
			if (!_008Ce())
			{
				new _0091_008B()._008B_0093_0089(null, typeof(ro), null, _0020: true, _0020: false, _0020: true, _0020: false, "", "", null, _0020: false, _0020: false, _0020: false);
			}
			zV.imf().JeJ((wR)8);
			_008Ce();
			if (_008Cd())
			{
				zV.imf().qeN((wR)8);
			}
			zV.imf().seL((wR)8);
			return DFB;
		}
	}

	public static string VF9(bool P_0, bool P_1, bool P_2, bool P_3, bool P_4, bool P_5)
	{
		lock (_0091_008B._008B_0095_009C)
		{
			DFB = "";
			_ = 0;
			if (_008Cd())
			{
				new _0091_008B()._008B_0093_0089(null, typeof(ro), null, _0020: true, _0020: false, _0020: true, _0020: false, _0091_008B._008B_0093_0095(P_0, P_1, P_2, P_3, P_4, P_5), "", null, _0020: false, _0020: false, _0020: false);
				zV.imf().JeJ((wR)8);
				zV.imf().qeN((wR)8);
			}
			zV.imf().seL((wR)8);
			return DFB;
		}
	}

	public static bool TFG(string P_0)
	{
		lock (_0091_008B._008B_0095_009C)
		{
			if (!_008Ce())
			{
				if (new _0091_008B()._008B_0093_0089(null, typeof(ro), null, _0020: true, _0020: false, _0020: false, _0020: true, P_0, "", null, _0020: false, _0020: false, _0020: false) == null)
				{
					return false;
				}
				zV.imf().JeJ((wR)9);
				_008Ce();
				if (!_008Cd())
				{
					if (_008Cd())
					{
					}
					goto IL_006d;
				}
			}
			zV.imf().qeN((wR)9);
			goto IL_006d;
			IL_006d:
			zV.imf().seL((wR)9);
			return true;
		}
	}

	static ro()
	{
		DFB = "";
	}

	internal static bool _008Cd()
	{
		return true;
	}

	internal static bool _008Ce()
	{
		return false;
	}
}
