using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace z8;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = true, Inherited = false)]
[ComVisible(true)]
internal sealed class R4 : Attribute
{
	private bool eeo;

	private bool geP;

	private bool EeH;

	private string xen;

	[SpecialName]
	public bool Mea()
	{
		return eeo;
	}

	[SpecialName]
	public void xem(bool P_0)
	{
		eeo = P_0;
	}

	[SpecialName]
	public bool reY()
	{
		return geP;
	}

	[SpecialName]
	public void neU(bool P_0)
	{
		geP = P_0;
	}

	[SpecialName]
	public string YeD()
	{
		return xen;
	}

	[SpecialName]
	public void nec(string P_0)
	{
		xen = P_0;
	}

	[SpecialName]
	public bool qeR()
	{
		return EeH;
	}

	[SpecialName]
	public void qex(bool P_0)
	{
		EeH = P_0;
	}

	public R4()
	{
		_ = 0;
		int num;
		if (_008C_0091())
		{
			num = 5;
			goto IL_0030;
		}
		num = 2;
		goto IL_0070;
		IL_0027:
		EeH = true;
		goto IL_0070;
		IL_0020:
		geP = true;
		goto IL_0027;
		IL_0030:
		eeo = true;
		num = 6;
		if (!_008C_0092())
		{
			goto IL_0047;
		}
		goto IL_008d;
		IL_0047:
		switch (num)
		{
		case 6:
			break;
		case 1:
			goto IL_0027;
		case 0:
		case 5:
			goto IL_0030;
		default:
			goto IL_0070;
		case 4:
			goto IL_008d;
		case 7:
			return;
		}
		goto IL_0020;
		IL_008d:
		base._002Ector();
		num = 7;
		return;
		IL_0070:
		xen = "";
		num = 4;
		if (_008C_0092())
		{
			goto IL_0020;
		}
		goto IL_0047;
	}

	internal static bool _008C_0091()
	{
		return true;
	}

	internal static bool _008C_0092()
	{
		return false;
	}
}
