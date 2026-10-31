using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using _0087_0095;
using _008A_008A;
using _008E_0098;
using _008F_008F;
using _0090_009C;
using _0091_008A;
using _0091_008C;

namespace _0088
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _0087
	{
		public double _0088;

		public double _0089;

		public double _008A;

		public double _008B;

		public double _008C;

		public bool _008D;

		public bool _008E;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087(double P_0, double P_1, double P_2, double P_3, double P_4, bool P_5, bool P_6)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0089 _0087(_008F_008E P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554434)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008A()
		{
			return true;
		}
	}
}
namespace _008A
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089 : IExtensionApplication
	{
		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _008F_009A
		{
			public string directoryPath;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _008F_009A()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal Assembly _008B_008D_0096(object sender, ResolveEventArgs args)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _008F_009A()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554437)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_008D()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_008E()
			{
				return true;
			}
		}

		private PaletteSet _0088_0087;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Initialize()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008F()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("WsTools")]
		public void _0090()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Terminate()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0091(object P_0, DocumentDestroyedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0092(object P_0, DocumentCollectionEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0093()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0094(object P_0, PalettePersistEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095(object P_0, PalettePersistEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0096(Exception P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0097(Exception P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int _0098(string P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Hello")]
		public void _0099()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("notReady")]
		public void _009A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y01_风螺旋")]
		public void _009B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y02_基础计算")]
		public void _009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y03_定位容差")]
		public void _009D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y04_导航设备保护区")]
		public void _009E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y05_精密进近保护区")]
		public void _0087_0086()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y06_传统模板")]
		public void _0087_0087()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y07_离场保护区")]
		public void _0087_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y08_转弯区评估")]
		public void _0087_0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y09_主副区评估")]
		public void _0087_008A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y10_起始进近DME弧")]
		public void _0087_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y51_FlyBy")]
		public void _0087_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y52_FlyOver")]
		public void _0087_008D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y53_RNP_APCH")]
		public void _0087_008E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y54_PBN_ILS")]
		public void _0087_008F()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y55_PBN_Departure")]
		public void _0087_0090()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("exline")]
		public void _0087_0091()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("RCL")]
		public void _0087_0092()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("rectLine")]
		public void _0087_0093()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("NMCIRCLE")]
		public void _0087_0094()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Arc2")]
		public void _0087_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y92_RandomPoint")]
		public void _0087_0096()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y90_LoadBlock")]
		public void _0087_0097()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Y91_CreateLayer")]
		public void _0087_0098()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("xInfo")]
		public void _0087_0099()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0087_009A(Editor P_0, string P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0087_009B(Editor P_0, string P_1, ref int P_2, int P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0087_009C(string P_0, ref int P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _0087_009D(string P_0, int P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _0087_009E(string P_0, ref int P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _0088_0086(string P_0, ref int P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554436)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008D()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008E()
		{
			return true;
		}
	}
}
namespace _008C
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _008B
	{
		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _008F_009B
		{
			public BlockTableRecord btr;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _008F_009B()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008D_0097(Entity ent)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _008F_009B()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554439)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_008F()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0090()
			{
				return true;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_0088(Database P_0, List<_008F_008E> P_1, string P_2 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_0089(Database P_0, List<List<_008F_008E>> P_1, string P_2 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_008A(Database P_0, List<_008F_008E> P_1, string P_2 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_008B(Database P_0, List<List<_008F_008E>> P_1, string P_2 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_008C(List<Entity> P_0, Database P_1, string P_2 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _0088_008D(Entity P_0, Database P_1, string P_2 = "")
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _0088_008E(this Database P_0, string P_1, List<Entity> P_2)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _0088_008F(ObjectId P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _0088_0090(ObjectId P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_0091(ObjectId P_0, double P_1, Point3d P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _0088_0092(this Database P_0, string P_1, params Entity[] ents)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _0088_0093(this ObjectId P_0, string P_1, string P_2, Point3d P_3, Scale3d P_4, double P_5)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_0094(this ObjectId P_0, List<AttributeDefinition> P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_0095(this ObjectId P_0, params AttributeDefinition[] atts)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _0088_0096(this ObjectId P_0, string P_1, string P_2, Point3d P_3, Scale3d P_4, double P_5, Dictionary<string, string> P_6)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_0097(this ObjectId P_0, Dictionary<string, string> P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _0088_0098(ObjectId P_0, string P_1, ResultBuffer P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("y9_AddObstBlockDef")]
		public static ObjectId _0088_0099()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static ObjectId _0088_009A(BlockTableRecord P_0, Database P_1)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_009B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_009D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _0088_009E(this Database P_0, string P_1, short P_2 = 0, LineWeight P_3 = (LineWeight)(-1))
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _0089_0086(string P_0, string P_1)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _0089_0087(string P_0, Point3d P_1, double P_2 = 1.0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0089_0088(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0089_0089(ObjectId P_0, string P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0089_008A(ObjectId P_0, string P_1, double P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<string> _0089_008B(ObjectId P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0089_008C(BlockReference P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _0089_008D(string P_0, string P_1)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _0089_008E()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554438)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0090()
		{
			return true;
		}
	}
}
namespace _008E
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _008D
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008E_0097 _0089_008F(_008F_008E P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _0089_0090(_008E_0097 P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _0089_0091(_008E_0097 P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0089_0092(DBPoint P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0089_0093(List<DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0089_0094(Dictionary<string, DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _0089_0095(List<_008F_008E> P_0, _008F_008E P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554440)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0091()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0092()
		{
			return true;
		}
	}
}
namespace _0090
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _0089_0096(List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0089_0097(List<_008F_008E> P_0, List<_008F_008E> P_1, _008F_008E P_2, _008F_008E P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _0089_0098(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static double _0089_0099(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554441)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0093()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0094()
		{
			return true;
		}
	}
}
namespace _0092
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0091
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int _0089_009A(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _0089_009B(List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0091()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0091()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554442)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0095()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0096()
		{
			return true;
		}
	}
}
namespace _0094
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0093
	{
		[LicenseProvider(typeof(_0091_008B))]
		public class _008F_009C : ICommand
		{
			public event EventHandler CanExecuteChanged
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				add
				{
				}
				[MethodImpl(MethodImplOptions.NoInlining)]
				remove
				{
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public bool CanExecute(object P_0)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void Execute(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _008F_009C()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _008F_009C()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554444)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0091()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0092()
			{
				return true;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0089_009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Command1")]
		public void _0089_009D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("Command2")]
		public void _0089_009E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0093()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0093()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554443)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0097()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0098()
		{
			return true;
		}
	}
}
namespace _0096
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0095
	{
		[Serializable]
		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _008F_009D
		{
			public static readonly _008F_009D _003C_003E9;

			public static Func<XElement, string> _003C_003E9__10_0;

			public static Func<DataGridViewCell, XElement> _003C_003E9__11_0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _008F_009D()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554446)));
				_003C_003E9 = new _008F_009D();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _008F_009D()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal string _008B_008D_0098(XElement c)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal XElement _008B_008D_0099(DataGridViewCell cell)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0093()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0094()
			{
				return true;
			}
		}

		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _008F_009E
		{
			public DataGridView dataGridView;

			public ContextMenuStrip contextMenu;

			public Button button;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _008F_009E()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008D_009A(object sender, EventArgs e)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _008F_009E()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554447)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0095()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0096()
			{
				return true;
			}
		}

		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0086
		{
			public DataGridViewColumn column;

			public ToolStripMenuItem menuItem;

			public _008F_009E CS_0024_003C_003E8__locals1;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0086()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008D_009B(object sender, EventArgs e)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0086()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554448)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0097()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0098()
			{
				return true;
			}
		}

		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0087
		{
			public string columnName;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0087()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_008D_009C(DataGridViewColumn c)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0087()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554449)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_0099()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_009A()
			{
				return true;
			}
		}

		private DataTable _008A_008E;

		private int _008A_008F;

		public static string _008A_0090;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0086(List<List<object>> P_0, List<string> P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0087(List<string> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0088(DataGridView P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_0089(DataGridView P_0, Button P_1, ContextMenuStrip P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_008A(string P_0, DataGridView P_1, ContextMenuStrip P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_008B(string P_0, DataGridView P_1, ContextMenuStrip P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_008C(string P_0, DataGridView P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_008D(string P_0, DataGridView P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0095()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554445)));
			_008A_0090 = _0090_009B._008B_008F_009D(676);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0099()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _009A()
		{
			return true;
		}
	}
}
namespace _0098
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0097
	{
		private static readonly _0087_0094 _008A_009B;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_0091(Form P_0, string P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008A_0092(ref Dictionary<string, string> P_0, Control.ControlCollection P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_0093(Form P_0, string P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static Control _008A_0094(Control.ControlCollection P_0, string P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_0095(TabControl P_0, string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_0096(TabControl P_0, string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008A_0097(Dictionary<string, string> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_0098(Control.ControlCollection P_0, ref string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008A_0099(Control.ControlCollection P_0, ref string P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_009A(Control.ControlCollection P_0, string P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0097()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0097()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554450)));
			_008A_009B = _0087_0094._008D_0092();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _009B()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _009C()
		{
			return true;
		}
	}
}
namespace _009A
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _0099
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("CheckAndSetLayer")]
		public static string _008A_009C(string P_0 = null)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string _008A_009D(string P_0, Database P_1, bool P_2 = true)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("GetCurrentLayerName")]
		public static string _008A_009E()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("GetCurrentLayerInfo")]
		public static LayerTableRecord _008B_0086()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CommandMethod("SetCurrentLayer")]
		public static void _008B_0087(string P_0 = null)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0099()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0099()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554451)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _009D()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _009E()
		{
			return true;
		}
	}
}
namespace _009C
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _009B
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<T> _008B_0088<T>(this Database P_0, OpenMode P_1, bool P_2) where T : Entity
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<T> _008B_0089<T>(this Database P_0) where T : Entity
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<T> _008B_008A<T>(this Database P_0, OpenMode P_1, bool P_2) where T : Entity
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<T> _008B_008B<T>(this Database P_0, OpenMode P_1, bool P_2) where T : Entity
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _009B()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554452)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _009F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0()
		{
			return true;
		}
	}
}
namespace _009E
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _009D
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_008C(string P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Point3d _008B_008D(string P_0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_008E(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008B_008F(Point3d P_0, Point3d P_1, double P_2, double P_3, double P_4, bool P_5 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0090()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0091()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0092()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0093(string P_0, double P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static double _008B_0094(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _008B_0095(double P_0, double P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0096(bool P_0 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static double _008B_0097(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0098(double P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static double _008B_0099(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static double _008B_009A(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _009D()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554453)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _1()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _2()
		{
			return true;
		}
	}
}
