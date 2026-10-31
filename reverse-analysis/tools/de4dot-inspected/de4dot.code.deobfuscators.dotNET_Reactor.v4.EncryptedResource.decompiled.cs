using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using de4dot.blocks;
using de4dot.blocks.cflow;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace de4dot.code.deobfuscators.dotNET_Reactor.v4;

internal class EncryptedResource
{
	private interface IDecrypter
	{
		DnrDecrypterType DecrypterType { get; }

		byte[] Decrypt(EmbeddedResource resource);

		byte[] Encrypt(byte[] data);
	}

	private class DecrypterV1 : IDecrypter
	{
		private readonly byte[] key;

		private readonly byte[] iv;

		public DnrDecrypterType DecrypterType => DnrDecrypterType.V1;

		public DecrypterV1(byte[] iv, byte[] key)
		{
			this.iv = iv;
			this.key = key;
		}

		public static bool CouldBeResourceDecrypter(MethodDef method, LocalTypes localTypes, IList<string> additionalTypes)
		{
			List<string> list = new List<string> { "System.Byte[]", "System.IO.BinaryReader", "System.IO.MemoryStream", "System.Security.Cryptography.CryptoStream", "System.Security.Cryptography.ICryptoTransform" };
			list.AddRange(additionalTypes);
			if (!localTypes.All(list))
			{
				return false;
			}
			if (DotNetUtils.GetMethod(method.DeclaringType, "System.Security.Cryptography.SymmetricAlgorithm", "()") != null && localTypes.Exists("System.UInt64"))
			{
				return false;
			}
			if (!localTypes.Exists("System.Security.Cryptography.RijndaelManaged") && !localTypes.Exists("System.Security.Cryptography.AesManaged") && !localTypes.Exists("System.Security.Cryptography.SymmetricAlgorithm"))
			{
				return false;
			}
			return true;
		}

		public byte[] Decrypt(EmbeddedResource resource)
		{
			return DeobUtils.AesDecrypt(resource.GetResourceData(), key, iv);
		}

		public byte[] Encrypt(byte[] data)
		{
			using RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			};
			using ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(key, iv);
			return cryptoTransform.TransformFinalBlock(data, 0, data.Length);
		}
	}

	private class DecrypterV2 : IDecrypter
	{
		private readonly byte[] key;

		private readonly byte[] iv;

		private readonly MethodDef method;

		private List<Instruction> instructions;

		private readonly List<Local> locals;

		private readonly InstructionEmulator instrEmulator = new InstructionEmulator();

		private Local emuLocal;

		public DnrDecrypterType DecrypterType => DnrDecrypterType.V2;

		public DecrypterV2(byte[] iv, byte[] key, MethodDef method)
		{
			this.iv = iv;
			this.key = key;
			this.method = method;
			locals = new List<Local>(method.Body.Variables);
			if (!Initialize())
			{
				throw new ApplicationException("Could not initialize decrypter");
			}
		}

		public static bool CouldBeResourceDecrypter(MethodDef method, LocalTypes localTypes, IList<string> additionalTypes)
		{
			List<string> list = new List<string> { "System.UInt32", "System.String", "System.Int32", "System.Byte[]", "System.IO.BinaryReader" };
			list.AddRange(additionalTypes);
			if (!localTypes.All(list))
			{
				return false;
			}
			return true;
		}

		private bool Initialize()
		{
			for (int i = 0; i < iv.Length; i++)
			{
				key[i] ^= iv[i];
			}
			IList<Instruction> list = method.Body.Instructions;
			if (!Find(list, out var startIndex, out var endIndex, out emuLocal) && !FindStartEnd(list, out startIndex, out endIndex, out emuLocal))
			{
				return false;
			}
			int num = endIndex - startIndex + 1;
			instructions = new List<Instruction>(num);
			for (int j = 0; j < num; j++)
			{
				instructions.Add(list[startIndex + j].Clone());
			}
			return true;
		}

		private bool Find(IList<Instruction> instrs, out int startIndex, out int endIndex, out Local tmpLocal)
		{
			startIndex = 0;
			endIndex = 0;
			tmpLocal = null;
			if (!FindStart(instrs, out var startIndex2, out emuLocal))
			{
				return false;
			}
			if (!FindEnd(instrs, startIndex2, out var endIndex2))
			{
				return false;
			}
			startIndex = startIndex2;
			endIndex = endIndex2;
			tmpLocal = emuLocal;
			return true;
		}

		private bool FindStartEnd(IList<Instruction> instrs, out int startIndex, out int endIndex, out Local tmpLocal)
		{
			for (int i = 0; i + 8 < instrs.Count; i++)
			{
				if (instrs[i].OpCode.Code != Code.Conv_R_Un || instrs[i + 1].OpCode.Code != Code.Conv_R8 || instrs[i + 2].OpCode.Code != Code.Conv_U4 || instrs[i + 3].OpCode.Code != Code.Add)
				{
					continue;
				}
				int num = i + 3;
				int num2 = -1;
				for (int num3 = num; num3 > 0; num3--)
				{
					if (instrs[num3].OpCode.FlowControl != FlowControl.Next)
					{
						num2 = num3 + 1;
						break;
					}
				}
				if (num2 >= 0)
				{
					endIndex = num;
					startIndex = num2;
					tmpLocal = CheckLocal(instrs[startIndex], isLdloc: true);
					return true;
				}
			}
			endIndex = 0;
			startIndex = 0;
			tmpLocal = null;
			return false;
		}

		private bool FindStart(IList<Instruction> instrs, out int startIndex, out Local tmpLocal)
		{
			for (int i = 0; i + 8 < instrs.Count; i++)
			{
				Local local;
				if (instrs[i].OpCode.Code == Code.Conv_U && instrs[i + 1].OpCode.Code == Code.Ldelem_U1 && instrs[i + 2].OpCode.Code == Code.Or && CheckLocal(instrs[i + 3], isLdloc: false) != null && (local = CheckLocal(instrs[i + 4], isLdloc: true)) != null && CheckLocal(instrs[i + 5], isLdloc: true) != null && instrs[i + 6].OpCode.Code == Code.Add && CheckLocal(instrs[i + 7], isLdloc: false) == local)
				{
					Instruction instruction = instrs[i + 8];
					int num = i + 8;
					if (instruction.IsBr())
					{
						instruction = instruction.Operand as Instruction;
						num = instrs.IndexOf(instruction);
					}
					if (num >= 0 && instruction != null && CheckLocal(instruction, isLdloc: true) == local)
					{
						startIndex = num;
						tmpLocal = local;
						return true;
					}
				}
			}
			startIndex = 0;
			tmpLocal = null;
			return false;
		}

		private bool FindEnd(IList<Instruction> instrs, int startIndex, out int endIndex)
		{
			for (int i = startIndex; i < instrs.Count; i++)
			{
				Instruction instruction = instrs[i];
				if (instruction.OpCode.FlowControl != FlowControl.Next)
				{
					break;
				}
				if (instruction.IsStloc() && instruction.GetLocal(locals) == emuLocal)
				{
					endIndex = i - 1;
					return true;
				}
			}
			endIndex = 0;
			return false;
		}

		private Local CheckLocal(Instruction instr, bool isLdloc)
		{
			if (isLdloc && !instr.IsLdloc())
			{
				return null;
			}
			if (!isLdloc && !instr.IsStloc())
			{
				return null;
			}
			return instr.GetLocal(locals);
		}

		public byte[] Decrypt(EmbeddedResource resource)
		{
			byte[] resourceData = resource.GetResourceData();
			byte[] array = new byte[resourceData.Length];
			uint num = 0u;
			for (int i = 0; i < resourceData.Length; i += 4)
			{
				num = CalculateMagic(num + ReadUInt32(key, i % key.Length));
				WriteUInt32(array, i, num ^ ReadUInt32(resourceData, i));
			}
			return array;
		}

		private uint CalculateMagic(uint input)
		{
			instrEmulator.Initialize(method, method.Parameters, locals, method.Body.InitLocals, emulateFromFirstInstruction: false);
			instrEmulator.SetLocal(emuLocal, new Int32Value((int)input));
			foreach (Instruction instruction in instructions)
			{
				instrEmulator.Emulate(instruction);
			}
			if (!(instrEmulator.Pop() is Int32Value int32Value) || !int32Value.AllBitsValid())
			{
				throw new ApplicationException("Couldn't calculate magic value");
			}
			return (uint)int32Value.Value;
		}

		private static uint ReadUInt32(byte[] ary, int index)
		{
			int num = ary.Length - index;
			if (num >= 4)
			{
				return BitConverter.ToUInt32(ary, index);
			}
			return num switch
			{
				1 => ary[index], 
				2 => (uint)(ary[index] | (ary[index + 1] << 8)), 
				3 => (uint)(ary[index] | (ary[index + 1] << 8) | (ary[index + 2] << 16)), 
				_ => throw new ApplicationException("Can't read data"), 
			};
		}

		private static void WriteUInt32(byte[] ary, int index, uint value)
		{
			int num = ary.Length - index;
			if (num >= 1)
			{
				ary[index] = (byte)value;
			}
			if (num >= 2)
			{
				ary[index + 1] = (byte)(value >> 8);
			}
			if (num >= 3)
			{
				ary[index + 2] = (byte)(value >> 16);
			}
			if (num >= 4)
			{
				ary[index + 3] = (byte)(value >> 24);
			}
		}

		public byte[] Encrypt(byte[] data)
		{
			Logger.e("Re-encryption is not supported. Assembly will probably crash at runtime.");
			return (byte[])data.Clone();
		}
	}

	private ModuleDefMD module;

	private MethodDef resourceDecrypterMethod;

	private EmbeddedResource encryptedDataResource;

	private IDecrypter decrypter;

	private static int[] pktIndexes = new int[16]
	{
		1, 0, 3, 1, 5, 2, 7, 3, 9, 4,
		11, 5, 13, 6, 15, 7
	};

	public DnrDecrypterType DecrypterTypeVersion
	{
		get
		{
			if (decrypter != null)
			{
				return decrypter.DecrypterType;
			}
			return DnrDecrypterType.Unknown;
		}
	}

	public TypeDef Type
	{
		get
		{
			if (resourceDecrypterMethod != null)
			{
				return resourceDecrypterMethod.DeclaringType;
			}
			return null;
		}
	}

	public MethodDef Method
	{
		get
		{
			return resourceDecrypterMethod;
		}
		set
		{
			resourceDecrypterMethod = value;
		}
	}

	public EmbeddedResource Resource => encryptedDataResource;

	public bool FoundResource => encryptedDataResource != null;

	public EncryptedResource(ModuleDefMD module)
	{
		this.module = module;
	}

	public EncryptedResource(ModuleDefMD module, EncryptedResource oldOne)
	{
		this.module = module;
		resourceDecrypterMethod = Lookup(oldOne.resourceDecrypterMethod, "Could not find resource decrypter method");
		if (oldOne.encryptedDataResource != null)
		{
			encryptedDataResource = DotNetUtils.GetResource(module, oldOne.encryptedDataResource.Name.String) as EmbeddedResource;
		}
		decrypter = oldOne.decrypter;
		if (encryptedDataResource == null && oldOne.encryptedDataResource != null)
		{
			throw new ApplicationException("Could not initialize EncryptedResource");
		}
	}

	private T Lookup<T>(T def, string errorMessage) where T : class, ICodedToken
	{
		return DeobUtils.Lookup(module, def, errorMessage);
	}

	public bool CouldBeResourceDecrypter(MethodDef method, IList<string> additionalTypes)
	{
		return CouldBeResourceDecrypter(method, additionalTypes, checkResource: true);
	}

	public bool CouldBeResourceDecrypter(MethodDef method, IList<string> additionalTypes, bool checkResource)
	{
		if (GetDecrypterType(method, additionalTypes) == DnrDecrypterType.Unknown)
		{
			return false;
		}
		if (checkResource && FindMethodsDecrypterResource(method) == null)
		{
			return false;
		}
		return true;
	}

	public DnrDecrypterType GuessDecrypterType()
	{
		return GetDecrypterType(resourceDecrypterMethod, null);
	}

	private static DnrDecrypterType GetDecrypterType(MethodDef method, IList<string> additionalTypes)
	{
		if (method == null || !method.IsStatic || method.Body == null)
		{
			return DnrDecrypterType.Unknown;
		}
		if (additionalTypes == null)
		{
			additionalTypes = new string[0];
		}
		LocalTypes localTypes = new LocalTypes(method);
		if (DecrypterV1.CouldBeResourceDecrypter(method, localTypes, additionalTypes))
		{
			return DnrDecrypterType.V1;
		}
		if (DecrypterV2.CouldBeResourceDecrypter(method, localTypes, additionalTypes))
		{
			return DnrDecrypterType.V2;
		}
		return DnrDecrypterType.Unknown;
	}

	public void Initialize(ISimpleDeobfuscator simpleDeobfuscator)
	{
		if (resourceDecrypterMethod == null)
		{
			return;
		}
		simpleDeobfuscator.Deobfuscate(resourceDecrypterMethod);
		encryptedDataResource = FindMethodsDecrypterResource(resourceDecrypterMethod);
		if (encryptedDataResource == null)
		{
			return;
		}
		byte[] initializedByteArray = ArrayFinder.GetInitializedByteArray(resourceDecrypterMethod, 32);
		if (initializedByteArray == null)
		{
			throw new ApplicationException("Could not find resource decrypter key");
		}
		byte[] initializedByteArray2 = ArrayFinder.GetInitializedByteArray(resourceDecrypterMethod, 16);
		if (initializedByteArray2 == null)
		{
			throw new ApplicationException("Could not find resource decrypter IV");
		}
		if (NeedReverse())
		{
			Array.Reverse(initializedByteArray2);
		}
		if (UsesPublicKeyToken())
		{
			PublicKeyToken publicKeyToken = module.Assembly.PublicKeyToken;
			if (publicKeyToken != null && publicKeyToken.Data.Length != 0)
			{
				for (int i = 0; i < 8; i++)
				{
					initializedByteArray2[i * 2 + 1] = publicKeyToken.Data[i];
				}
			}
		}
		switch (GetDecrypterType(resourceDecrypterMethod, new string[0]))
		{
		case DnrDecrypterType.V1:
			decrypter = new DecrypterV1(initializedByteArray2, initializedByteArray);
			break;
		case DnrDecrypterType.V2:
			decrypter = new DecrypterV2(initializedByteArray2, initializedByteArray, resourceDecrypterMethod);
			break;
		default:
			throw new ApplicationException("Unknown decrypter type");
		}
	}

	private bool UsesPublicKeyToken()
	{
		int num = 0;
		foreach (Instruction instruction in resourceDecrypterMethod.Body.Instructions)
		{
			if (instruction.OpCode.FlowControl != FlowControl.Next)
			{
				num = 0;
			}
			else if (instruction.IsLdcI4())
			{
				if (instruction.GetLdcI4Value() != pktIndexes[num++])
				{
					num = 0;
				}
				else if (num >= pktIndexes.Length)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool NeedReverse()
	{
		return DotNetUtils.CallsMethod(resourceDecrypterMethod, "System.Void System.Array::Reverse(System.Array)");
	}

	private EmbeddedResource FindMethodsDecrypterResource(MethodDef method)
	{
		foreach (string codeString in DotNetUtils.GetCodeStrings(method))
		{
			if (DotNetUtils.GetResource(module, codeString) is EmbeddedResource result)
			{
				return result;
			}
		}
		return null;
	}

	public byte[] Decrypt()
	{
		if (encryptedDataResource == null || decrypter == null)
		{
			throw new ApplicationException("Can't decrypt resource");
		}
		return decrypter.Decrypt(encryptedDataResource);
	}

	public byte[] Encrypt(byte[] data)
	{
		if (decrypter == null)
		{
			throw new ApplicationException("Can't encrypt resource");
		}
		return decrypter.Encrypt(data);
	}
}
