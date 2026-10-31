using System.IO;
using System.Security.Cryptography;
using System.Text;
using y6;
using _0090_009C;
using _0091_008C;

namespace lK;

internal class PO
{
	internal static byte[] jFb;

	public static bool dFi(byte[] P_0)
	{
		lock (_0091_008B._008B_0095_009C)
		{
			_008Cf();
			if (!_008Cg())
			{
				if (new _0091_008B()._008B_0093_0089(null, typeof(ro), null, _0020: true, _0020: false, _0020: false, _0020: false, "", "", P_0, _0020: false, _0020: true, _0020: false) == null)
				{
					return false;
				}
			}
			else if (!_008Cf())
			{
			}
			return true;
		}
	}

	public static byte[] GFl(byte[] P_0)
	{
		_ = 0;
		if (_008Cf())
		{
			jFb = new byte[0];
		}
		lock (_0091_008B._008B_0095_009C)
		{
			new _0091_008B()._008B_0093_0089(null, typeof(ro), null, _0020: true, _0020: false, _0020: false, _0020: false, "", "", P_0, _0020: false, _0020: false, _0020: true);
		}
		return jFb;
	}

	public static byte[] DFT(byte[] P_0)
	{
		byte[] array = P_0;
		byte[] array2 = default(byte[]);
		SymmetricAlgorithm symmetricAlgorithm = default(SymmetricAlgorithm);
		if (!_008Cg())
		{
			array2 = array;
			_008Cg();
			if (!_008Cf())
			{
				goto IL_0042;
			}
			symmetricAlgorithm = _0090_009B._008B_008F_0098();
		}
		symmetricAlgorithm.Mode = CipherMode.CBC;
		ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor(_0091_008B._008B_0096_0090, _0091_008B._008B_0096_0091);
		MemoryStream memoryStream = new MemoryStream();
		goto IL_0042;
		IL_0042:
		CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
		cryptoStream.Write(array2, 0, array2.Length);
		cryptoStream.FlushFinalBlock();
		array = memoryStream.ToArray();
		memoryStream.Close();
		return array;
	}

	public static byte[] rFr(byte[] P_0)
	{
		try
		{
			SymmetricAlgorithm symmetricAlgorithm = _0090_009B._008B_008F_0098();
			_008Cf();
			ICryptoTransform transform = default(ICryptoTransform);
			if (!_008Cg())
			{
				symmetricAlgorithm.Mode = CipherMode.CBC;
				transform = symmetricAlgorithm.CreateDecryptor(_0091_008B._008B_0096_0090, _0091_008B._008B_0096_0091);
			}
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] result;
			do
			{
				cryptoStream.Write(P_0, 0, P_0.Length);
				cryptoStream.FlushFinalBlock();
				result = memoryStream.ToArray();
				memoryStream.Close();
			}
			while (_008Cg());
			cryptoStream.Close();
			if (!_008Cg())
			{
			}
			return result;
		}
		catch
		{
			return null;
		}
	}

	public static byte[] sFs()
	{
		return _0090_009B._008B_008F_0099(sFw());
	}

	internal static byte[] sFw()
	{
		return Encoding.Unicode.GetBytes(_0090_009B._008B_008F_009D(7632));
	}

	static PO()
	{
		jFb = new byte[0];
	}

	internal static bool _008Cf()
	{
		return true;
	}

	internal static bool _008Cg()
	{
		return false;
	}
}
