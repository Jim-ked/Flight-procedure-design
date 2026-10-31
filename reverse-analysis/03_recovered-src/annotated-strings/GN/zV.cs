using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using LZ;
using y6;
using _0090_009C;
using _0091_008C;

namespace GN;

internal class zV
{
	internal delegate void ou();

	internal delegate void ca();

	public delegate void kJ();

	public delegate void hm();

	public delegate void oh(string connectionID);

	public delegate void zj(string connectionID);

	private static Vi YFt;

	internal static bool EFA;

	internal static bool oFQ;

	internal static Timer TFg;

	internal static Timer dFy;

	internal static Timer jFd;

	private static ou qFM;

	private static ou nFJ;

	private static ca NFk;

	private static kJ cF8;

	private static hm eFN;

	private static oh kFh;

	private static zj tFp;

	internal static bool qFL;

	internal static event ou Mmq
	{
		add
		{
			ou ou = default(ou);
			if (!_008C0())
			{
				ou = qFM;
				_ = 0;
				if (!_008C_009F())
				{
					if (!_008C_009F())
					{
					}
					goto IL_0020;
				}
			}
			goto IL_0040;
			IL_0040:
			ou ou2 = ou;
			goto IL_0020;
			IL_0020:
			ou value2 = (ou)Delegate.Combine(ou2, b);
			ou = Interlocked.CompareExchange(ref qFM, value2, ou2);
			if ((object)ou == ou2)
			{
				return;
			}
			goto IL_0040;
		}
		remove
		{
			_ = 1;
			ou ou = default(ou);
			if (!_008C0())
			{
				ou = qFM;
				goto IL_0014;
			}
			goto IL_0030;
			IL_0030:
			ou ou2 = default(ou);
			if ((object)ou == ou2)
			{
				return;
			}
			goto IL_0014;
			IL_0014:
			ou2 = ou;
			ou value2 = (ou)Delegate.Remove(ou2, value3);
			ou = Interlocked.CompareExchange(ref qFM, value2, ou2);
			goto IL_0030;
		}
	}

	internal static event ou nF4
	{
		add
		{
			_008C_009F();
			ou ou;
			if (!_008C0())
			{
				ou = nFJ;
				goto IL_001e;
			}
			goto IL_002d;
			IL_002d:
			ou value2 = default(ou);
			ou ou2 = default(ou);
			ou = Interlocked.CompareExchange(ref nFJ, value2, ou2);
			if (!_008C0() && (object)ou == ou2)
			{
				return;
			}
			goto IL_001e;
			IL_001e:
			ou2 = ou;
			value2 = (ou)Delegate.Combine(ou2, b);
			goto IL_002d;
		}
		remove
		{
			_ = 1;
			ou ou;
			if (!_008C0())
			{
				ou = nFJ;
				if (!_008C_009F())
				{
					goto IL_001b;
				}
				goto IL_002e;
			}
			goto IL_0030;
			IL_0030:
			ou ou2 = default(ou);
			ou value2 = (ou)Delegate.Remove(ou2, value3);
			goto IL_001b;
			IL_001b:
			ou = Interlocked.CompareExchange(ref nFJ, value2, ou2);
			if ((object)ou == ou2)
			{
				return;
			}
			goto IL_002e;
			IL_002e:
			ou2 = ou;
			goto IL_0030;
		}
	}

	internal static event ca NFm
	{
		add
		{
			_008C_009F();
			ca ca;
			if (!_008C0())
			{
				ca = NFk;
				goto IL_0018;
			}
			goto IL_002f;
			IL_002f:
			ca value2 = default(ca);
			ca ca2 = default(ca);
			ca = Interlocked.CompareExchange(ref NFk, value2, ca2);
			if (_008C_009F() && (object)ca == ca2)
			{
				return;
			}
			goto IL_0018;
			IL_0018:
			ca2 = ca;
			value2 = (ca)Delegate.Combine(ca2, b);
			goto IL_002f;
		}
		remove
		{
			ca ca = NFk;
			ca ca2;
			do
			{
				ca2 = ca;
				_ = 1;
				if (!_008C0())
				{
					ca value2 = (ca)Delegate.Remove(ca2, value3);
					ca = Interlocked.CompareExchange(ref NFk, value2, ca2);
				}
			}
			while ((object)ca != ca2);
		}
	}

	public static event kJ mFC
	{
		add
		{
			kJ kJ = cF8;
			if (_008C_009F())
			{
				goto IL_000d;
			}
			goto IL_001f;
			IL_000d:
			kJ kJ2 = kJ;
			_ = 1;
			if (_008C0())
			{
				goto IL_0018;
			}
			goto IL_001f;
			IL_001f:
			kJ value2 = (kJ)Delegate.Combine(kJ2, b);
			kJ = Interlocked.CompareExchange(ref cF8, value2, kJ2);
			goto IL_0018;
			IL_0018:
			if ((object)kJ == kJ2)
			{
				return;
			}
			goto IL_000d;
		}
		remove
		{
			kJ kJ = cF8;
			_008C_009F();
			if (!_008C0())
			{
				goto IL_0018;
			}
			goto IL_001a;
			IL_0018:
			kJ kJ2 = kJ;
			goto IL_001a;
			IL_001a:
			kJ value2 = (kJ)Delegate.Remove(kJ2, value3);
			kJ = Interlocked.CompareExchange(ref cF8, value2, kJ2);
			if ((object)kJ == kJ2)
			{
				return;
			}
			goto IL_0018;
		}
	}

	public static event hm FFR
	{
		add
		{
			hm hm = eFN;
			_008C_009F();
			if (!_008C0() && _008C_009F())
			{
				goto IL_001f;
			}
			goto IL_003b;
			IL_003b:
			hm hm2 = default(hm);
			if ((object)hm == hm2)
			{
				return;
			}
			goto IL_001f;
			IL_001f:
			hm2 = hm;
			hm value2 = (hm)Delegate.Combine(hm2, b);
			hm = Interlocked.CompareExchange(ref eFN, value2, hm2);
			goto IL_003b;
		}
		remove
		{
			_ = 0;
			hm hm;
			if (_008C_009F())
			{
				hm = eFN;
				goto IL_0014;
			}
			goto IL_002e;
			IL_002e:
			hm value2 = default(hm);
			hm hm2 = default(hm);
			hm = Interlocked.CompareExchange(ref eFN, value2, hm2);
			if ((object)hm == hm2 && _008C_009F())
			{
				return;
			}
			goto IL_0014;
			IL_0014:
			hm2 = hm;
			value2 = (hm)Delegate.Remove(hm2, value3);
			goto IL_002e;
		}
	}

	public static event oh VFP
	{
		add
		{
			oh oh = kFh;
			oh oh2;
			do
			{
				oh2 = oh;
				oh value2 = (oh)Delegate.Combine(oh2, b);
				_008C_009F();
				if (!_008C0())
				{
					oh = Interlocked.CompareExchange(ref kFh, value2, oh2);
				}
			}
			while ((object)oh != oh2);
		}
		remove
		{
			oh oh = kFh;
			if (!_008C0())
			{
				goto IL_000d;
			}
			goto IL_002c;
			IL_000d:
			oh oh2 = oh;
			_008C_009F();
			oh value2 = default(oh);
			if (!_008C0())
			{
				value2 = (oh)Delegate.Remove(oh2, value3);
			}
			goto IL_002c;
			IL_002c:
			oh = Interlocked.CompareExchange(ref kFh, value2, oh2);
			if ((object)oh == oh2)
			{
				return;
			}
			goto IL_000d;
		}
	}

	public static event zj SFE
	{
		add
		{
			zj zj = tFp;
			zj zj2;
			zj value2 = default(zj);
			do
			{
				zj2 = zj;
				_ = 1;
				if (!_008C0() && !_008C0())
				{
					value2 = (zj)Delegate.Combine(zj2, b);
				}
				zj = Interlocked.CompareExchange(ref tFp, value2, zj2);
			}
			while ((object)zj != zj2);
		}
		remove
		{
			zj zj = tFp;
			if (_008C_009F())
			{
				goto IL_000d;
			}
			goto IL_0030;
			IL_000d:
			zj zj2 = zj;
			zj value2 = (zj)Delegate.Remove(zj2, value3);
			_008C_009F();
			if (_008C0())
			{
				goto IL_0029;
			}
			goto IL_0030;
			IL_0030:
			zj = Interlocked.CompareExchange(ref tFp, value2, zj2);
			goto IL_0029;
			IL_0029:
			if ((object)zj == zj2)
			{
				return;
			}
			goto IL_000d;
		}
	}

	internal static void KmB(string P_0)
	{
		_ = 0;
		if (_008C_009F())
		{
			if (kFh != null)
			{
				kFh(P_0);
			}
		}
		else if (_008C0())
		{
			goto IL_002c;
		}
		if (tFp == null)
		{
			return;
		}
		goto IL_002c;
		IL_002c:
		tFp(P_0);
	}

	internal static void fmi()
	{
		lock (_0091_008B._008B_0095_009C)
		{
			if (cF8 == null && eFN == null)
			{
				if (jFd == null)
				{
					jFd = new Timer(Qml, null, 2000, 2000);
				}
				return;
			}
			if (jFd != null)
			{
				jFd.Change(-1, -1);
				if (_008C_009F())
				{
					jFd = null;
				}
			}
			if (cF8 != null)
			{
				cF8();
				_008C_009F();
				if (_008C0())
				{
					goto IL_0093;
				}
			}
			if (eFN == null)
			{
				return;
			}
			goto IL_0093;
			IL_0093:
			eFN();
		}
	}

	internal static void Qml(object P_0)
	{
		lock (_0091_008B._008B_0095_009C)
		{
			_008C_009F();
			if ((!_008C0() && cF8 == null && eFN == null) || jFd == null)
			{
				return;
			}
			jFd.Change(-1, -1);
			jFd = null;
			while (true)
			{
				if (cF8 != null)
				{
					cF8();
				}
				if (eFN != null)
				{
					if (!_008C_009F())
					{
						continue;
					}
					eFN();
					break;
				}
				break;
			}
		}
	}

	internal static void nmT()
	{
		_008C0();
		if (_008C_009F())
		{
			if (false /* original-file-bool-offset:1544 */)
			{
				return;
			}
			if (qFL)
			{
				goto IL_0175;
			}
		}
		else if (_008C0())
		{
			goto IL_003d;
		}
		qFL = true;
		if (nFJ != null)
		{
			goto IL_003d;
		}
		goto IL_0047;
		IL_0047:
		string text = "System.Reflection.ObfuscationAttribute" /* string-offset:8412 */;
		string text2 = "INTELLILOCKCALLBACK" /* string-offset:8416 */;
		try
		{
			Type[] types = typeof(_0091_008B).Assembly.GetTypes();
			MethodInfo[] methods = default(MethodInfo[]);
			for (int i = 0; i < types.Length; i++)
			{
				object[] customAttributes = types[i].GetCustomAttributes(inherit: false);
				bool flag = false;
				for (int j = 0; j < customAttributes.Length; j++)
				{
					if (customAttributes[j].GetType().FullName == text && ((ObfuscationAttribute)customAttributes[j]).Feature == text2)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				_008C_009F();
				if (!_008C0())
				{
					methods = types[i].GetMethods();
				}
				foreach (MethodInfo methodInfo in methods)
				{
					customAttributes = methodInfo.GetCustomAttributes(inherit: false);
					for (int l = 0; l < customAttributes.Length; l++)
					{
						if (customAttributes[l].GetType().FullName == text && ((ObfuscationAttribute)customAttributes[l]).Feature == text2)
						{
							methodInfo.Invoke(null, new object[0]);
						}
					}
				}
			}
		}
		catch
		{
		}
		goto IL_0175;
		IL_003d:
		nFJ();
		goto IL_0047;
		IL_0175:
		lock (_0091_008B._008B_0095_009C)
		{
			if (qFM != null)
			{
				_ = 1;
				if (!_008C0() && (_008C0() || TFg != null))
				{
					TFg.Change(-1, -1);
					TFg = null;
				}
				qFM();
			}
			else if (TFg == null)
			{
				TFg = new Timer(Emr, null, 2000, 2000);
			}
		}
	}

	internal static void Emr(object P_0)
	{
		lock (_0091_008B._008B_0095_009C)
		{
			_ = 1;
			if (!_008C0())
			{
				if (qFM == null || TFg == null)
				{
					return;
				}
				TFg.Change(-1, -1);
			}
			else if (_008C0())
			{
			}
			TFg = null;
			qFM();
		}
	}

	internal static void Hms()
	{
		lock (_0091_008B._008B_0095_009C)
		{
			if (NFk != null)
			{
				_008C0();
				if (_008C_009F())
				{
					if (dFy != null)
					{
						dFy.Change(-1, -1);
						dFy = null;
					}
					NFk();
				}
				else if (!_008C_009F())
				{
				}
			}
			else if (dFy == null)
			{
				dFy = new Timer(Qmw, null, 2000, 2000);
			}
		}
	}

	internal static void Qmw(object P_0)
	{
		lock (_0091_008B._008B_0095_009C)
		{
			if (NFk != null && dFy != null)
			{
				_008C_009F();
				if (!_008C0())
				{
					dFy.Change(-1, -1);
				}
				dFy = null;
				NFk();
			}
		}
	}

	[SpecialName]
	public static Vi imf()
	{
		lock (_0091_008B._008B_0095_009C)
		{
			if (!EFA)
			{
				_ = 0;
				if (_008C_009F())
				{
					if (oFQ)
					{
						goto IL_005d;
					}
					new _0091_008B()._008B_0093_0089(LicenseManager.CurrentContext, typeof(zV), null, _0020: true, _0020: false, _0020: false, _0020: false, "", "", null, _0020: false, _0020: false, _0020: false);
				}
				nmT();
			}
			goto IL_005d;
			IL_005d:
			return YFt;
		}
	}

	public static void Tmb(string P_0)
	{
		EmV(_0091_008B._008B_0094_0087(P_0), P_0);
	}

	public static void Em1(byte[] P_0)
	{
		EmV(P_0, null);
	}

	public static void EmV(byte[] P_0, string P_1)
	{
		_ = 0;
		if (!_008C_009F() || false /* original-file-bool-offset:1548 */)
		{
			return;
		}
		try
		{
			LicenseManager.CurrentContext?.SetSavedLicenseKey(typeof(ILLicenseModule), Convert.ToBase64String(P_0));
		}
		catch
		{
		}
		string text = _0091_008B._008B_0091_009C("<RSAKeyValue><Modulus>tH+JKmqb+FvcOwRYHoSmG7FA+ljYA15fdjFImtTAjEypaH/1rOCYEKgO2cmZBQ7Q+I4wU/B9EwJ8+HhK/fcy12PCt0UDvuuVjZ9a9fqh3XblyQNCeMTHZl9+c30yHrir2D6xp3JBWMvLBXYM2007Oy1Pc5yuGGQt8KoPd2yDpQpSPY2zOGkMG/0Be/tL8Uxuf5Q5Gdt675kIh0AhnnlgQrtWFCROeSJiU03i/NfaSBi8E8A6dDoZ2BO7j1Nq8x86WAptOv4M3bH+pb+dThZfTJ7Xdb9f4B6G7vbbER4OA+KWN0QBT44bBs7e4j30lLk1BGpesmWqYvpg1CK9EPWsFQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>" /* string-offset:7632 */);
		try
		{
			string text2 = _0091_008B._008B_0091_0099(text);
			_0091_008B._008B_0094_0088(text2, P_0);
			if (P_1 != null)
			{
				string path = _0091_008B._008B_0091_009A(text);
				File.WriteAllLines(path, new string[2]
				{
					P_1,
					Convert.ToBase64String(_0090_009B._008B_008F_0099(P_0))
				});
			}
		}
		catch (Exception)
		{
			try
			{
				string text3 = _0091_008B._008B_0091_009B(text);
				_0091_008B._008B_0094_0088(text3, P_0);
			}
			catch
			{
			}
		}
	}

	public static byte[] hmv()
	{
		return _0091_008B._008B_0096_0089;
	}

	public static void Xm2(string P_0)
	{
		_008C0();
		if (_008C_009F() && !File.Exists(P_0))
		{
			lock (_0091_008B._008B_0095_009C)
			{
				_008C_009F();
				if (!_008C0() && !_008C0())
				{
					new _0091_008B()._008B_0093_0089(LicenseManager.CurrentContext, typeof(ro), null, _0020: true, _0020: true, _0020: false, _0020: false, "", P_0, null, _0020: false, _0020: false, _0020: false);
				}
				nmT();
				return;
			}
		}
		Om7(File.ReadAllBytes(P_0));
	}

	public static void Om7(byte[] P_0)
	{
		lock (_0091_008B._008B_0095_009C)
		{
			_008C_009F();
			if (!_008C0())
			{
				new _0091_008B()._008B_0093_0089(LicenseManager.CurrentContext, typeof(ro), null, _0020: true, _0020: true, _0020: false, _0020: false, "", "", P_0, _0020: false, _0020: false, _0020: false);
			}
			else if (_008C_009F())
			{
			}
			nmT();
		}
	}

	static zV()
	{
		YFt = new Vi();
		EFA = false;
		oFQ = false;
		TFg = null;
		dFy = null;
		_008C_009F();
		if (!_008C0())
		{
			jFd = null;
		}
		qFL = false;
	}

	internal static bool _008C_009F()
	{
		return true;
	}

	internal static bool _008C0()
	{
		return false;
	}
}
