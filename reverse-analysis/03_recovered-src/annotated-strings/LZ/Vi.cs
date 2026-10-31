using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using T7;
using Xe;
using y6;
using _0090_009C;
using _0091_008C;

namespace LZ;

internal class Vi
{
	private DateTime ImX;

	private bool Em4;

	private bool smK;

	private int zme;

	private int nma;

	private int emm;

	private int RmF;

	private int zmY;

	private bool YmU;

	private bool dmC;

	private int KmD;

	private bool vmc;

	private int om3;

	private int QmR;

	private int Tmx;

	private bool fm6;

	private bool Vmo;

	private bool umP;

	private string tmH;

	private SortedList Cmn;

	private wR FmI;

	private wR imE;

	private wR imt;

	private C9 jmA;

	private bool PmQ;

	private string smg;

	private bool Imy;

	private string Rmd;

	private bool dmM;

	private bool LmJ;

	private bool emk;

	private bool fm8;

	private bool SmN;

	private bool Bmh;

	private bool nmp;

	internal bool wmL;

	internal wR wmW;

	public bool FloatingLicense
	{
		get
		{
			return Imy;
		}
		set
		{
			Imy = imy;
		}
	}

	public string LicenseServer
	{
		get
		{
			return smg;
		}
		set
		{
			smg = text;
		}
	}

	public DateTime ExpirationDate
	{
		get
		{
			return ImX;
		}
		set
		{
			ImX = imX;
		}
	}

	public int ExpirationDays
	{
		get
		{
			return zme;
		}
		set
		{
			zme = num;
		}
	}

	public int Executions
	{
		get
		{
			return emm;
		}
		set
		{
			emm = num;
		}
	}

	public int Runtime
	{
		get
		{
			return KmD;
		}
		set
		{
			KmD = kmD;
		}
	}

	public int GlobalTime
	{
		get
		{
			return om3;
		}
		set
		{
			om3 = num;
		}
	}

	public int Instances
	{
		get
		{
			return Tmx;
		}
		set
		{
			Tmx = tmx;
		}
	}

	public string HardwareID
	{
		get
		{
			return tmH;
		}
		set
		{
			tmH = text;
		}
	}

	internal Vi()
	{
		ImX = DateTime.Now;
		tmH = _0091_008B._0091_008D._008B_0098_0095;
		_008C_009C();
		if (_008C_009B())
		{
			Cmn = new SortedList();
			smg = "http:\\\\" /* string-offset:8400 */;
		}
		Rmd = "http:\\\\" /* string-offset:8400 */;
		base._002Ector();
	}

	internal Vi(byte[] P_0)
	{
		int num = 24;
		IDictionaryEnumerator enumerator = default(IDictionaryEnumerator);
		while (true)
		{
			ImX = DateTime.Now;
			num = 7;
			while (true)
			{
				tmH = _0091_008B._0091_008D._008B_0098_0095;
				Cmn = new SortedList();
				smg = "http:\\\\" /* string-offset:8400 */;
				Rmd = "http:\\\\" /* string-offset:8400 */;
				base._002Ector();
				_0091_008B._0091_008F obj = null;
				num = 6;
				while (true)
				{
					_0091_008B.zH zH = new _0091_008B()._008B_0093_0089(LicenseManager.CurrentContext, typeof(ro), null, _0020: true, _0020: true, _0020: false, _0020: false, "", "", P_0, _0020: true, _0020: false, _0020: false) as _0091_008B.zH;
					num = 22;
					while (true)
					{
						IL_0315:
						if (zH != null)
						{
							goto IL_0249;
						}
						goto IL_030a;
						IL_030a:
						if (obj != null)
						{
							fag(obj._008B_009C_0094);
							Daa(obj._008B_009C_008C);
							Executions = obj._008B_009C_008D;
							Ha4(0);
							num = 21;
							if (_008C_009C())
							{
								continue;
							}
							goto IL_0280;
						}
						throw new ArgumentException("Invalid License" /* string-offset:8404 */, "license" /* string-offset:8408 */);
						IL_03de:
						Maf(obj._008B_009B_0092);
						HaS(obj._008B_009C_0086);
						daj(obj._008B_009B_0098);
						num = 30;
						return;
						IL_0280:
						while (true)
						{
							switch (num)
							{
							case 29:
								break;
							case 25:
								goto IL_005d;
							case 9:
								goto IL_0079;
							case 20:
								goto IL_008e;
							case 12:
								goto IL_0095;
							case 5:
								goto IL_00aa;
							case 19:
								goto IL_00bf;
							case 23:
								goto IL_00d7;
							case 10:
							case 18:
								goto IL_0135;
							case 21:
								goto IL_0154;
							case 0:
								goto IL_017f;
							case 2:
								goto IL_0194;
							case 16:
								goto IL_01a9;
							case 27:
								goto IL_01ca;
							case 13:
								goto IL_01eb;
							case 14:
								goto IL_0200;
							case 11:
								goto IL_021f;
							case 1:
							case 4:
							case 17:
								goto IL_0239;
							case 28:
								goto IL_0249;
							default:
								num = 23;
								if (_008C_009B())
								{
									continue;
								}
								goto IL_01eb;
							case 8:
								goto IL_030a;
							case 22:
								goto IL_0315;
							case 6:
								goto end_IL_0315;
							case 7:
								goto end_IL_031d;
							case 24:
								goto end_IL_035b;
							case 3:
								goto IL_03bd;
							case 15:
								goto IL_03c9;
							case 26:
								goto IL_03de;
							case 30:
								return;
							}
							break;
						}
						goto IL_0051;
						IL_0249:
						obj = zH.Y4V as _0091_008B._0091_008F;
						num = 8;
						if (!_008C_009B())
						{
							goto IL_01a9;
						}
						goto IL_030a;
						IL_0051:
						ExpirationDays = obj._008B_009C_0089;
						goto IL_005d;
						IL_005d:
						Se5(0);
						Va3(obj._008B_009C_0090);
						num = 9;
						goto IL_0079;
						IL_0079:
						GlobalTime = obj._008B_009C_0091;
						num = 20;
						goto IL_008e;
						IL_008e:
						xaP(0);
						goto IL_0095;
						IL_0095:
						Dat(obj._008B_009C_0092);
						num = 5;
						goto IL_00aa;
						IL_00aa:
						Instances = obj._008B_009C_0093;
						num = 19;
						goto IL_00bf;
						IL_00bf:
						iaY(obj._008B_009C_008E);
						Runtime = obj._008B_009C_008F;
						goto IL_00d7;
						IL_00d7:
						faL().Clear();
						enumerator = obj._008B_009D_009B.GetEnumerator();
						num = 1;
						goto IL_0239;
						IL_0239:
						while (enumerator.MoveNext())
						{
							faL().Add(enumerator.Key.ToString(), enumerator.Value.ToString());
							_ = 1;
							if (_008C_009C())
							{
								break;
							}
							num = 4;
						}
						goto IL_0135;
						IL_0135:
						meB(obj._008B_009B_0089);
						num = 0;
						if (!_008C_009B())
						{
							goto IL_0154;
						}
						goto IL_0280;
						IL_0154:
						BeV(obj._008B_009C_008A);
						ExpirationDate = obj._008B_009C_008B;
						num = 11;
						if (_008C_009C())
						{
							goto IL_017f;
						}
						goto IL_0280;
						IL_017f:
						LicenseServer = obj._008B_009B_009A;
						num = 2;
						goto IL_0194;
						IL_0194:
						FloatingLicense = obj._008B_009B_008A;
						num = 16;
						goto IL_01a9;
						IL_01a9:
						yey(obj._008B_009B_008B);
						HardwareID = obj._008B_009B_009D;
						num = 27;
						goto IL_01ca;
						IL_01ca:
						Ta8(obj._008B_009B_008E);
						Jar(obj._008B_009B_0090);
						num = 13;
						goto IL_01eb;
						IL_01eb:
						Yab(obj._008B_009B_0091);
						num = 14;
						goto IL_0200;
						IL_0200:
						iai(obj._008B_009B_008F);
						num = 3;
						if (_008C_009C())
						{
							goto IL_021f;
						}
						goto IL_03bd;
						IL_021f:
						Me7(obj._008B_009C_0088);
						num = 29;
						goto IL_0051;
						IL_03bd:
						da9(obj._008B_009B_0097);
						goto IL_03c9;
						IL_03c9:
						wav(obj._008B_009B_0093);
						num = 26;
						goto IL_03de;
						continue;
						end_IL_0315:
						break;
					}
					continue;
					end_IL_031d:
					break;
				}
				continue;
				end_IL_035b:
				break;
			}
		}
	}

	internal Vi(string P_0)
		: this(File.ReadAllBytes(P_0))
	{
	}

	[SpecialName]
	public bool wet()
	{
		return FloatingLicense;
	}

	[SpecialName]
	public void neA(bool P_0)
	{
		FloatingLicense = P_0;
	}

	[SpecialName]
	public string veg()
	{
		return Rmd;
	}

	[SpecialName]
	public void yey(string P_0)
	{
		Rmd = P_0;
	}

	[SpecialName]
	public wR EeM()
	{
		_008C_009C();
		if (_008C_009B())
		{
			if (!wmL)
			{
				goto IL_0054;
			}
			if (!_008C_009B())
			{
				goto IL_002f;
			}
		}
		else if (_008C_009B())
		{
			goto IL_0043;
		}
		if (wmW != (wR)7)
		{
			goto IL_002f;
		}
		goto IL_004d;
		IL_0043:
		if (wmW == (wR)11)
		{
			goto IL_004d;
		}
		goto IL_0054;
		IL_004d:
		return wmW;
		IL_0054:
		return FmI;
		IL_002f:
		if (wmW != (wR)10 && wmW != (wR)13)
		{
			goto IL_0043;
		}
		goto IL_004d;
	}

	[SpecialName]
	public void JeJ(wR P_0)
	{
		FmI = P_0;
	}

	[SpecialName]
	public wR Ie8()
	{
		return imE;
	}

	[SpecialName]
	public void qeN(wR P_0)
	{
		imE = P_0;
	}

	[SpecialName]
	public wR vep()
	{
		return imt;
	}

	[SpecialName]
	public void seL(wR P_0)
	{
		imt = P_0;
	}

	[SpecialName]
	public C9 yeZ()
	{
		return jmA;
	}

	[SpecialName]
	public void Ke0(C9 P_0)
	{
		jmA = P_0;
	}

	[SpecialName]
	public bool WeG()
	{
		return PmQ;
	}

	[SpecialName]
	public void meB(bool P_0)
	{
		PmQ = P_0;
	}

	[SpecialName]
	public bool Ke1()
	{
		return Em4;
	}

	[SpecialName]
	public void BeV(bool P_0)
	{
		Em4 = P_0;
	}

	[SpecialName]
	public bool Pe2()
	{
		return smK;
	}

	[SpecialName]
	public void Me7(bool P_0)
	{
		smK = P_0;
	}

	[SpecialName]
	public int Mej()
	{
		return nma;
	}

	[SpecialName]
	public void Se5(int P_0)
	{
		nma = P_0;
	}

	[SpecialName]
	public int JaX()
	{
		return zmY;
	}

	[SpecialName]
	public void Ha4(int P_0)
	{
		zmY = P_0;
	}

	[SpecialName]
	public bool bae()
	{
		return YmU;
	}

	[SpecialName]
	public void Daa(bool P_0)
	{
		YmU = P_0;
	}

	[SpecialName]
	public bool HaF()
	{
		return dmC;
	}

	[SpecialName]
	public void iaY(bool P_0)
	{
		dmC = P_0;
	}

	[SpecialName]
	public bool Iac()
	{
		return vmc;
	}

	[SpecialName]
	public void Va3(bool P_0)
	{
		vmc = P_0;
	}

	[SpecialName]
	public int Nao()
	{
		return QmR;
	}

	[SpecialName]
	public void xaP(int P_0)
	{
		QmR = P_0;
	}

	[SpecialName]
	public bool vaE()
	{
		return fm6;
	}

	[SpecialName]
	public void Dat(bool P_0)
	{
		fm6 = P_0;
	}

	[SpecialName]
	public bool NaQ()
	{
		return Vmo;
	}

	[SpecialName]
	public void fag(bool P_0)
	{
		Vmo = P_0;
	}

	[SpecialName]
	public string wad()
	{
		try
		{
			lock (_0091_008B._008B_0095_009C)
			{
				_0091_008B._008B_0093_009A(_0020: true);
				_0091_008B._0091_008E obj = null;
				_0091_008B._008B_0092_009A(ref obj, null, _0020: true);
				_008C_009C();
				if (_008C_009B())
				{
					_0091_008B._008B_0092_009C(ref obj, GetType(), null);
					_0091_008B._008B_0092_009E(ref obj, null, _0020: true);
					if (obj != null)
					{
						goto IL_0053;
					}
				}
				obj = new _0091_008B._0091_008E();
				goto IL_0053;
				IL_0053:
				return obj._008B_009A_008E.Replace("ez&#02" /* string-offset:8324 */, "|" /* string-offset:7968 */);
			}
		}
		catch
		{
		}
		return "";
	}

	[SpecialName]
	public void GaM(string P_0)
	{
		if (!true /* original-file-bool-offset:1540 */)
		{
			return;
		}
		try
		{
			lock (_0091_008B._008B_0095_009C)
			{
				_0091_008B._008B_0093_009A(_0020: true);
				_0091_008B._0091_008E obj = null;
				_008C_009B();
				if (!_008C_009C())
				{
					_0091_008B._008B_0092_009A(ref obj, null, _0020: true);
				}
				_0091_008B._008B_0092_009C(ref obj, GetType(), null);
				_0091_008B._008B_0092_009E(ref obj, null, _0020: true);
				if (obj == null)
				{
					obj = new _0091_008B._0091_008E();
				}
				obj._008B_009A_008E = P_0.Replace("|" /* string-offset:7968 */, "ez&#02" /* string-offset:8324 */);
				_0091_008B._008B_0093_0087(ref obj, GetType(), _0020: true, null);
			}
		}
		catch
		{
		}
	}

	[SpecialName]
	public bool oak()
	{
		return umP;
	}

	[SpecialName]
	public void Ta8(bool P_0)
	{
		umP = P_0;
	}

	[SpecialName]
	public SortedList faL()
	{
		return Cmn;
	}

	[SpecialName]
	public void maW(SortedList P_0)
	{
		Cmn = P_0;
	}

	[SpecialName]
	public bool Ha0()
	{
		return dmM;
	}

	[SpecialName]
	public void da9(bool P_0)
	{
		dmM = P_0;
	}

	[SpecialName]
	public bool baB()
	{
		return LmJ;
	}

	[SpecialName]
	public void iai(bool P_0)
	{
		LmJ = P_0;
	}

	[SpecialName]
	public bool JaT()
	{
		return emk;
	}

	[SpecialName]
	public void Jar(bool P_0)
	{
		emk = P_0;
	}

	[SpecialName]
	public bool saw()
	{
		return fm8;
	}

	[SpecialName]
	public void Yab(bool P_0)
	{
		fm8 = P_0;
	}

	[SpecialName]
	public bool oaV()
	{
		return SmN;
	}

	[SpecialName]
	public void wav(bool P_0)
	{
		SmN = P_0;
	}

	[SpecialName]
	public bool ia7()
	{
		return Bmh;
	}

	[SpecialName]
	public void Maf(bool P_0)
	{
		Bmh = P_0;
	}

	[SpecialName]
	public bool Nau()
	{
		return nmp;
	}

	[SpecialName]
	public void daj(bool P_0)
	{
		nmp = P_0;
	}

	[SpecialName]
	public int Caq()
	{
		return RmF;
	}

	[SpecialName]
	public void HaS(int P_0)
	{
		RmF = P_0;
	}

	internal static bool _008C_009B()
	{
		return true;
	}

	internal static bool _008C_009C()
	{
		return false;
	}
}
