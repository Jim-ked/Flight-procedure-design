using System.Reflection;

namespace Xe;

internal enum C9
{
	[Obfuscation(Exclude = true, StripAfterObfuscation = false)]
	Inbuilt,
	[Obfuscation(Exclude = true, StripAfterObfuscation = false)]
	ExternalAssembly,
	[Obfuscation(Exclude = true, StripAfterObfuscation = false)]
	HDD
}
