using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Timers;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using T7;
using _0087_008D;
using _0087_0097;
using _0088_008A;
using _0088_0090;
using _008A_008A;
using _008A_008C;
using _008A_008E;
using _008A_0090;
using _008A_0094;
using _008A_0098;
using _008B_009D;
using _008C_0086;
using _008C_008C;
using _008C_0096;
using _008C_0098;
using _008C_009A;
using _008C_009E;
using _008D_0087;
using _008D_008B;
using _008D_008D;
using _008D_008F;
using _008E_0088;
using _008E_008C;
using _008E_008E;
using _008E_0090;
using _008E_0092;
using _008E_0098;
using _008E_009C;
using _008F_0087;
using _008F_0089;
using _008F_008D;
using _008F_008F;
using _008F_0093;
using _008F_0097;
using _008F_0099;
using _0090_009C;
using _0091_008A;
using _0091_008C;

namespace _0087_0087
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _0087_0086
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Point2d _008B_009B(this Point3d P_0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point2d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_009C(this Point3d P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Point3d _008B_009D(this _008E_0097 P_0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008E_0097 _008B_009E(this Point3d P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008C_0086(this Point2d P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008C_0087(this Point3d P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Point2d _008C_0088(this _008F_008E P_0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point2d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Point3d _008C_0089(this _008F_008E P_0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008C_008A(this List<_008E_0097> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Point2dCollection _008C_008B(this List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Point3dCollection _008C_008C(this List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008C_008D(this DBPoint P_0, string P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_0086()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554454)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _3()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _4()
		{
			return true;
		}
	}
}
namespace _0087_0089
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _0087_0088
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008C_008E(this Polyline P_0, Point2dCollection P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008C_008F(this Polyline P_0, Point2dCollection P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008C_0090(this Polyline P_0, params Point2d[] pts)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polyline _008C_0091(Point2dCollection P_0, double P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Polyline3d _008C_0092(Point3dCollection P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<List<_008F_008E>> _008C_0093(List<List<_008F_008E>> P_0, double P_1 = 0.01)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _008C_0094(_008F_008E P_0, _008F_008E P_1, double P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_0088()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554455)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _5()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _6()
		{
			return true;
		}
	}
}
namespace _0087_008B
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _0087_008A
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string _008C_0095(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static XDocument _008C_0096(string P_0, string P_1 = "Document")
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008C_0097(string P_0, string P_1, string P_2 = "1.0", string P_3 = "UTF-8", string P_4 = "no")
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static XElement _008C_0098(string P_0, string P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008C_0099(string P_0, string P_1, string P_2, string P_3, string P_4, string P_5)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008C_009A(string P_0, string P_1, string P_2, string P_3)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008C_009B(string P_0, string P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string _008C_009C(string P_0, string P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008C_009D(string P_0, string P_1, string P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_008A()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554456)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _7()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _8()
		{
			return true;
		}
	}
}
namespace _0087_008D
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _0087_008C : Label
	{
		private bool _008D_008A;

		private BorderStyle _008D_008B;

		private Color _008D_008C;

		private readonly string _008D_008D;

		private readonly string _008D_008E;

		[Category("行为")]
		[Description("获取或设置Label是否被选中")]
		public bool _008D_0089
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return true;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008C_009E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008D_0086()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnMouseEnter(EventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnMouseLeave(EventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnClick(EventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnCreateControl()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_008C()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554457)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _9()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool a()
		{
			return true;
		}
	}
}
namespace _0087_008F
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0087_008E : _0087_0096
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool y_0091(Control P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetValue(Control P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetValue(Control P_0, string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087_008E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_008E()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554458)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool b()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool c()
		{
			return true;
		}
	}
}
namespace _0087_0091
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0087_0090 : _0087_0096
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool y_0091(Control P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetValue(Control P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetValue(Control P_0, string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087_0090()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_0090()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554459)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool d()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool e()
		{
			return true;
		}
	}
}
namespace _0087_0093
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0087_0092 : _0087_0096
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool y_0091(Control P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetValue(Control P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetValue(Control P_0, string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087_0092()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_0092()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554460)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool f()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool g()
		{
			return true;
		}
	}
}
namespace _0087_0095
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0087_0094
	{
		[Serializable]
		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0088
		{
			public static readonly _0090_0088 _003C_003E9;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0088()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554462)));
				_003C_003E9 = new _0090_0088();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0088()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal _0087_0094 _008B_008D_009D()
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_009B()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_009C()
			{
				return true;
			}
		}

		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _0090_0089
		{
			public Control control;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0089()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_008D_009E(_0087_0096 h)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0089()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554463)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_009D()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_009E()
			{
				return true;
			}
		}

		private readonly List<_0087_0096> _008D_0094;

		private static readonly Lazy<_0087_0094> _008D_0095;

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public static _0087_0094 _008D_0092()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _0087_0094()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008D_008F(_0087_0096 P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087_0096 _008D_0090(Control P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008D_0091(Control P_0, out _0087_0096 P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_0094()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554461)));
			_008D_0095 = new Lazy<_0087_0094>([MethodImpl(MethodImplOptions.NoInlining)] () => (_0087_0094)null);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool h()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool i()
		{
			return true;
		}
	}
}
namespace _0087_0097
{
	[LicenseProvider(typeof(_0091_008B))]
	public interface _0087_0096
	{
		bool y_0091(Control P_0);

		string GetValue(Control P_0);

		void SetValue(Control P_0, string P_1);
	}
}
namespace _0087_0099
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0087_0098 : _0087_0096
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool y_0091(Control P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetValue(Control P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetValue(Control P_0, string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087_0098()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_0098()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554465)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool l()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool m()
		{
			return true;
		}
	}
}
namespace _0087_009B
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0087_009A : _0087_0096
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool y_0091(Control P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetValue(Control P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetValue(Control P_0, string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087_009A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_009A()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554466)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool n()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool o()
		{
			return true;
		}
	}
}
namespace _0087_009D
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0087_009C : _0087_0096
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool y_0091(Control P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetValue(Control P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetValue(Control P_0, string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087_009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_009C()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554467)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool p()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool q()
		{
			return true;
		}
	}
}
namespace _0088_0086
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0087_009E : TextBox
	{
		private decimal _008E_0090;

		private decimal _008E_0091;

		private bool _008E_0092;

		[CompilerGenerated]
		private string _008E_0093;

		[Category("验证")]
		[Description("获取或设置文本框允许的最小值")]
		public decimal _008E_0086
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (decimal)(object)null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Description("获取或设置文本框允许的最大值")]
		[Category("验证")]
		public decimal _008E_0089
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (decimal)(object)null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Description("获取或设置是否在失去焦点时验证")]
		[Category("验证")]
		public bool _008E_008C
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return true;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Category("验证")]
		[Description("获取或设置验证失败时的错误提示信息")]
		public string _008E_008F
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0087_009E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008D_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008D_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008D_0098(object P_0, KeyPressEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool _008D_0099(string P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008D_009A()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public decimal? _008D_009B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008D_009C(decimal P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0087_009E()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554468)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool r()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool s()
		{
			return true;
		}
	}
}
namespace _0088_0088
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_0087 : _0087_0096
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool y_0091(Control P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string GetValue(Control P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void SetValue(Control P_0, string P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_0087()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_0087()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554469)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool t()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool u()
		{
			return true;
		}
	}
}
namespace _0088_008A
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_0089
	{
		private string _008F_0087;

		private string _008F_0088;

		private string _008F_0089;

		private string _008F_008A;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_0089(string P_0, string P_1, string P_2, string P_3 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public string _008E_0094()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008E_0095(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public string _008E_0097()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008E_0098(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public string _008E_009A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008E_009B(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public string _008E_009D()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008E_009E(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_0089()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554470)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool v()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool w()
		{
			return true;
		}
	}
}
namespace _0088_008C
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_008B : UserControl
	{
		private static Dictionary<string, Image> _0090_008D;

		private Color _0090_008E;

		private Color _0090_008F;

		private bool _0090_0090;

		private string _0090_0091;

		private IContainer _0090_0092;

		private Label _0090_0093;

		private Label _0090_0094;

		private PictureBox _0090_0095;

		private System.Windows.Forms.Timer _0090_0096;

		private ToolTip _0090_0097;

		[Category("Appearance")]
		[Description("鼠标悬停时的背景颜色")]
		public Color _008F_0096
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (Color)(object)null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[Description("正常状态下的背景颜色")]
		[Category("Appearance")]
		public Color _008F_0099
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (Color)(object)null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_008B()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554471)));
			_008F_008C();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public string _008F_009A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008F_009B(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public string _008F_009D()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008F_009E(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public Image _0090_0087()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _0090_0088(Image P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public string _0090_008A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _0090_008B(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_008B(_0088_0089 P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008F_008B(Control P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008F_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008F_008D(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008F_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008F_008F()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008F_0090()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private void _008F_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private void _008F_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		private void _008F_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool x()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool y()
		{
			return true;
		}
	}
}
namespace _0088_008E
{
	[LicenseProvider(typeof(_0091_008B))]
	internal static class _0088_008D
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _0088_008F _0090_0098(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static List<_0088_0089> _0090_0099()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static List<_0088_0089> _0090_009A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static List<_0088_0089> _0090_009B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_008D()
		{
			_0090_009C._0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554472)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool z()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0086()
		{
			return true;
		}
	}
}
namespace _0088_0090
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_008F : TableLayoutPanel
	{
		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_008A
		{
			public string cmdName;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_008A()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0086(object s, EventArgs e)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_008A()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554474)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A_009F()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A0()
			{
				return true;
			}
		}

		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_008B
		{
			public Document acDoc;

			public _0090_008A CS_0024_003C_003E8__locals1;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_008B()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0087()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_008B()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554475)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A1()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A2()
			{
				return true;
			}
		}

		private IContainer _0090_009D;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_008F()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_008F(List<_0088_0089> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0090_009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_008F()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554473)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0087()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0088()
		{
			return true;
		}
	}
}
namespace _0088_0092
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_0091
	{
		public _008E_009B _0091_008D;

		public double _0091_008E;

		public double _0091_008F;

		public double _0091_0090;

		public double _0091_0091;

		public double _0091_0092;

		public double _0091_0093;

		public double _0091_0094;

		public double _0091_0095;

		public double _0091_0096;

		public double _0091_0097;

		public double _0091_0098;

		public double _0091_0099;

		public double _0091_009A;

		public string _0091_009B;

		public double _0091_009C;

		private double _0091_009D;

		private double _0091_009E;

		private double _0092_0086;

		private bool _0092_0087;

		private bool _0092_0088;

		public _008F_0088 _0092_0089;

		public _008F_0088 _0092_008A;

		public _008F_0088 _0092_008B;

		public _008F_0088 _0092_008C;

		public _008F_0088 _0092_008D;

		public List<_008F_008E> _0092_008E;

		public List<_008F_008E> _0092_008F;

		public List<List<_008F_008E>> _0092_0090;

		public List<_008F_008E> _0092_0091;

		public _008F_008E _0092_0092;

		public _008F_008E _0092_0093;

		public _008F_008E _0092_0094;

		public _008F_008E _0092_0095;

		public _008F_008E _0092_0096;

		public _008F_008E _0092_0097;

		public _008F_008E _0092_0098;

		public _008F_008E _0092_0099;

		public _008F_008E _0092_009A;

		public _008F_008E _0092_009B;

		public _008F_008E _0092_009C;

		public _008F_008E _0092_009D;

		public _008F_008E _0092_009E;

		public _008F_008E _0093_0086;

		public _008F_008E _0093_0087;

		public _008F_008E _0093_0088;

		public _008F_008E _0093_0089;

		public _008F_008E _0093_008A;

		public _008F_008E _0093_008B;

		public ArrayList _0093_008C;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_0091(_008E_009B P_0, string P_1 = "VOR", double P_2 = 0.0, bool P_3 = true, double P_4 = 60.0, double P_5 = 4600.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0090_009E(string P_0, double P_1, bool P_2 = true, double P_3 = 60.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0091_0086(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0091_0087(bool P_0 = true, bool P_1 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0091_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0091_0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<_008F_008E> _0091_008A(_008F_008E P_0, _008F_008E P_1, double P_2, double P_3 = Math.PI * 3.0 / 5.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0091_008B(ref List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4, double P_5 = 2.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0091_008C(ref List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_0091()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(global::_0091_008A._0091_0089.e53w34m968awCm9P85taUZe(33554476)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0089()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_008A()
		{
			return true;
		}
	}
}
namespace _0088_0094
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_0093
	{
		public double _0093_008F;

		public double _0093_0090;

		public double _0093_0091;

		public double _0093_0092;

		public double _0093_0093;

		public double _0093_0094;

		public double _0093_0095;

		public bool _0093_0096;

		public _008E_0097 _0093_0097;

		public double _0093_0098;

		public double _0093_0099;

		private _008F_008E _0093_009A;

		private _008F_008E _0093_009B;

		private _008F_008E _0093_009C;

		private _008F_008E _0093_009D;

		private _008F_008C _0093_009E;

		private _008F_008C _0094_0086;

		public List<List<_008F_008E>> _0094_0087;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_0093()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_0093(_008E_0097 P_0, _008E_009B P_1, double P_2 = 0.033, double P_3 = 0.033, bool P_4 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0089 _0093_008D(_008A_0089 P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0093_008E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_0093()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554477)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_008B()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_008C()
		{
			return true;
		}
	}
}
namespace _0088_0096
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_0095
	{
		public double _0094_008A;

		public double _0094_008B;

		public _008E_0097 _0094_008C;

		public double _0094_008D;

		public double _0094_008E;

		public double _0094_008F;

		public double _0094_0090;

		private double _0094_0091;

		private double _0094_0092;

		private _008F_008E _0094_0093;

		private _008F_008E _0094_0094;

		private _008F_008E _0094_0095;

		private _008F_008E _0094_0096;

		private _008F_008E _0094_0097;

		private _008F_008C _0094_0098;

		public List<List<_008F_008E>> _0094_0099;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_0095(_008E_0097 P_0, _008E_009B P_1, double P_2, double P_3, double P_4 = 0.033, double P_5 = 0.033)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0089 _0094_0088(_008A_0089 P_0, bool P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0094_0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_0095()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554478)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_008F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0090()
		{
			return true;
		}
	}
}
namespace _0088_0098
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_0097 : Form
	{
		private IContainer _0095_008F;

		private GroupBox _0095_0090;

		private CheckBox _0095_0091;

		private TextBox _0095_0092;

		private CheckBox _0095_0093;

		private Button _0095_0094;

		private CheckBox _0095_0095;

		private GroupBox _0095_0096;

		private RadioButton _0095_0097;

		private RadioButton _0095_0098;

		private RadioButton _0095_0099;

		private CheckBox _0095_009A;

		private GroupBox _0095_009B;

		private PictureBox _0095_009C;

		private TabControl _0095_009D;

		private TabPage _0095_009E;

		private TabPage _0096_0086;

		private GroupBox _0096_0087;

		private PictureBox _0096_0088;

		private Button _0096_0089;

		private CheckBox _0096_008A;

		private GroupBox _0096_008B;

		private Label _0096_008C;

		private RadioButton _0096_008D;

		private TextBox _0096_008E;

		private RadioButton _0096_008F;

		private GroupBox _0096_0090;

		private Label _0096_0091;

		private TextBox _0096_0092;

		private PictureBox _0096_0093;

		private CheckBox _0096_0094;

		private ToolTip _0096_0095;

		private TextBox _0096_0096;

		private TextBox _0096_0097;

		private Label _0096_0098;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_0097()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0094_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0094_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0094_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0094_009D(object P_0, EventArgs P_1)
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0094_009E(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095_0088(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0095_008E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_0097()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554479)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0091()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0092()
		{
			return true;
		}
	}
}
namespace _0088_009A
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_0099 : Form
	{
		private IContainer _0097_0089;

		private Label _0097_008A;

		private TextBox _0097_008B;

		private Button _0097_008C;

		private Button _0097_008D;

		private ListBox _0097_008E;

		private GroupBox _0097_008F;

		private Button _0097_0090;

		private Button _0097_0091;

		private Button _0097_0092;

		private Button _0097_0093;

		private ListBox _0097_0094;

		private Button _0097_0095;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_0099()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0096_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0096_009A(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0096_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0096_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0096_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0096_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0097_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0097_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0097_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_0099()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554480)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0093()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0094()
		{
			return true;
		}
	}
}
namespace _0088_009C
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_009B : Form
	{
		private double[,] _0098_0097;

		private IContainer _0098_0098;

		private TabControl _0098_0099;

		private TabPage _0098_009A;

		private TabPage _0098_009B;

		private TabPage _0098_009C;

		private TabPage _0098_009D;

		private TabPage _0098_009E;

		private TabPage _0099_0086;

		private GroupBox _0099_0087;

		private Label _0099_0088;

		private GroupBox _0099_0089;

		private TextBox _0099_008A;

		private Label _0099_008B;

		private TextBox _0099_008C;

		private TextBox _0099_008D;

		private Label _0099_008E;

		private GroupBox _0099_008F;

		private PictureBox _0099_0090;

		private CheckBox _0099_0091;

		private GroupBox _0099_0092;

		private GroupBox _0099_0093;

		private Label _0099_0094;

		private Label _0099_0095;

		private Label _0099_0096;

		private TextBox _0099_0097;

		private Label _0099_0098;

		private Label _0099_0099;

		private TextBox _0099_009A;

		private Label _0099_009B;

		private TextBox _0099_009C;

		private TextBox _0099_009D;

		private TextBox _0099_009E;

		private TextBox _009A_0086;

		private Button _009A_0087;

		private CheckBox _009A_0088;

		private GroupBox _009A_0089;

		private TextBox _009A_008A;

		private Label _009A_008B;

		private Label _009A_008C;

		private Label _009A_008D;

		private GroupBox _009A_008E;

		private TextBox _009A_008F;

		private TextBox _009A_0090;

		private Label _009A_0091;

		private TextBox _009A_0092;

		private Button _009A_0093;

		private CheckBox _009A_0094;

		private GroupBox _009A_0095;

		private TextBox _009A_0096;

		private Label _009A_0097;

		private Label _009A_0098;

		private Label _009A_0099;

		private GroupBox _009A_009A;

		private TextBox _009A_009B;

		private TextBox _009A_009C;

		private Label _009A_009D;

		private TextBox _009A_009E;

		private Button _009B_0086;

		private CheckBox _009B_0087;

		private Button _009B_0088;

		private GroupBox _009B_0089;

		private PictureBox _009B_008A;

		private GroupBox _009B_008B;

		private PictureBox _009B_008C;

		private CheckBox _009B_008D;

		private Button _009B_008E;

		private ComboBox _009B_008F;

		private Label _009B_0090;

		private Label _009B_0091;

		private Label _009B_0092;

		private Label _009B_0093;

		private Label _009B_0094;

		private TextBox _009B_0095;

		private TextBox _009B_0096;

		private TextBox _009B_0097;

		private TextBox _009B_0098;

		private GroupBox _009B_0099;

		private ComboBox _009B_009A;

		private ComboBox _009B_009B;

		private TextBox _009B_009C;

		private Label _009B_009D;

		private TextBox _009B_009E;

		private Label _009C_0086;

		private Label _009C_0087;

		private Label _009C_0088;

		private GroupBox _009C_0089;

		private PictureBox _009C_008A;

		private GroupBox _009C_008B;

		private PictureBox _009C_008C;

		private GroupBox _009C_008D;

		private PictureBox _009C_008E;

		private Button _009C_008F;

		private CheckBox _009C_0090;

		private GroupBox _009C_0091;

		private _008F_0098 _009C_0092;

		private _008F_0098 _009C_0093;

		private TextBox _009C_0094;

		private Label _009C_0095;

		private TextBox _009C_0096;

		private Label _009C_0097;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_009B()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0097_0096(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0097_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0097_0098(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0097_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0097_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0097_009B()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static double _0097_009C(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0097_009D()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0097_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0098_0086()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0098_008A()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0098_008E()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0098_0091()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0098_0094()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0098_0096()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_009B()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554481)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0095()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0096()
		{
			return true;
		}
	}
}
namespace _0088_009E
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0088_009D : Form
	{
		[Serializable]
		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _0090_008C
		{
			public static readonly _0090_008C _003C_003E9;

			public static Func<_008A_0089, double> _003C_003E9__24_0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_008C()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554483)));
				_003C_003E9 = new _0090_008C();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_008C()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_0088(_008A_0089 o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A3()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A4()
			{
				return true;
			}
		}

		private List<DBPoint> _009D_009D;

		private Dictionary<string, DBPoint> _009D_009E;

		private IContainer _009E_0086;

		private Button _009E_0087;

		private Button _009E_0088;

		private DataGridView _009E_0089;

		private StatusStrip _009E_008A;

		private ToolStripStatusLabel _009E_008B;

		private GroupBox _009E_008C;

		private TextBox _009E_008D;

		private TextBox _009E_008E;

		private TextBox _009E_008F;

		private Label _009E_0090;

		private Label _009E_0091;

		private Label _009E_0092;

		private GroupBox _009E_0093;

		private TextBox _009E_0094;

		private TextBox _009E_0095;

		private Label _009E_0096;

		private TextBox _009E_0097;

		private Label _009E_0098;

		private Label _009E_0099;

		private TabControl _009E_009A;

		private TabPage _009E_009B;

		private TabPage _009E_009C;

		private ToolTip _009E_009D;

		private Button _009E_009E;

		private Button _0087_0086_0086;

		private Button _0087_0086_0087;

		private Button _0087_0086_0088;

		private TextBox _0087_0086_0089;

		private Label _0087_0086_008A;

		private Label _0087_0086_008B;

		private TextBox _0087_0086_008C;

		private Label _0087_0086_008D;

		private Button _0087_0086_008E;

		private TextBox _0087_0086_008F;

		private PictureBox _0087_0086_0090;

		private GroupBox _0087_0086_0091;

		private ComboBox _0087_0086_0092;

		private Label _0087_0086_0093;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0088_009D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _009C_0098(DataGridView P_0)
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _009C_0099(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009C_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009C_009B(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009C_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009C_009D(List<DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009C_009E(List<_008A_0089> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0086(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008E_0097 _009D_008B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ShowMessage(string s)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_0099(object P_0, CancelEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_009A(object P_0, CancelEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _009D_009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0088_009D()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554482)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0097()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0098()
		{
			return true;
		}
	}
}
namespace _0089_0087
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_0086 : Form
	{
		[Serializable]
		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _0090_008D
		{
			public static readonly _0090_008D _003C_003E9;

			public static Func<_008A_0089, double> _003C_003E9__19_0;

			public static Func<_008A_0089, double> _003C_003E9__35_0;

			public static Func<_008A_0089, double> _003C_003E9__39_0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_008D()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554485)));
				_003C_003E9 = new _0090_008D();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_008D()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_0089(_008A_0089 o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_008A(_008A_0089 o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_008B(_008A_0089 o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A5()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A6()
			{
				return true;
			}
		}

		private List<DBPoint> _0087_0089_009B;

		private Dictionary<string, DBPoint> _0087_0089_009C;

		private const double _0087_0089_009D = 0.539957;

		private const double _0087_0089_009E = 1.852;

		private Point3d _0087_008A_0086;

		private Point3d _0087_008A_0087;

		private Point3d _0087_008A_0088;

		private IContainer _0087_008A_0089;

		private Button _0087_008A_008A;

		private Button _0087_008A_008B;

		private DataGridView _0087_008A_008C;

		private TextBox _0087_008A_008D;

		private TextBox _0087_008A_008E;

		private Label _0087_008A_008F;

		private Label _0087_008A_0090;

		private StatusStrip _0087_008A_0091;

		private ToolStripStatusLabel _0087_008A_0092;

		private Button _0087_008A_0093;

		private Button _0087_008A_0094;

		private GroupBox _0087_008A_0095;

		private TextBox _0087_008A_0096;

		private TextBox _0087_008A_0097;

		private TextBox _0087_008A_0098;

		private Label _0087_008A_0099;

		private Label _0087_008A_009A;

		private Label _0087_008A_009B;

		private Button _0087_008A_009C;

		private GroupBox _0087_008A_009D;

		private TextBox _0087_008A_009E;

		private TextBox _0087_008B_0086;

		private Label _0087_008B_0087;

		private TextBox _0087_008B_0088;

		private Label _0087_008B_0089;

		private Label _0087_008B_008A;

		private CheckBox _0087_008B_008B;

		private TabControl _0087_008B_008C;

		private TabPage _0087_008B_008D;

		private TabPage _0087_008B_008E;

		private TabPage _0087_008B_008F;

		private TextBox _0087_008B_0090;

		private ToolTip _0087_008B_0091;

		private Label _0087_008B_0092;

		private Button _0087_008B_0093;

		private TextBox _0087_008B_0094;

		private TextBox _0087_008B_0095;

		private TextBox _0087_008B_0096;

		private Label _0087_008B_0097;

		private Label _0087_008B_0098;

		private Label _0087_008B_0099;

		private TextBox _0087_008B_009A;

		private Label _0087_008B_009B;

		private Button _0087_008B_009C;

		private Button _0087_008B_009D;

		private Button _0087_008B_009E;

		private TextBox _0087_008C_0086;

		private TextBox _0087_008C_0087;

		private Label _0087_008C_0088;

		private TextBox _0087_008C_0089;

		private Label _0087_008C_008A;

		private TextBox _0087_008C_008B;

		private TextBox _0087_008C_008C;

		private TextBox _0087_008C_008D;

		private Label _0087_008C_008E;

		private TextBox _0087_008C_008F;

		private Label _0087_008C_0090;

		private TextBox _0087_008C_0091;

		private Button _0087_008C_0092;

		private Button _0087_008C_0093;

		private Label _0087_008C_0094;

		private Label _0087_008C_0095;

		private TextBox _0087_008C_0096;

		private TextBox _0087_008C_0097;

		private CheckBox _0087_008C_0098;

		private TextBox _0087_008C_0099;

		private TextBox _0087_008C_009A;

		private Button _0087_008C_009B;

		private Button _0087_008C_009C;

		private Button _0087_008C_009D;

		private Button _0087_008C_009E;

		private TabPage _0087_008D_0086;

		private Button _0087_008D_0087;

		private Button _0087_008D_0088;

		private Button _0087_008D_0089;

		private Button _0087_008D_008A;

		private TextBox _0087_008D_008B;

		private TextBox _0087_008D_008C;

		private Label _0087_008D_008D;

		private Label _0087_008D_008E;

		private TextBox _0087_008D_008F;

		private Label _0087_008D_0090;

		private Button _0087_008D_0091;

		private Button _0087_008D_0092;

		private Button _0087_008D_0093;

		private Button _0087_008D_0094;

		private _0087_008C _0087_008D_0095;

		private _0087_008C _0087_008D_0096;

		private _0087_008C _0087_008D_0097;

		private _0087_008C _0087_008D_0098;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_0086()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0087_0086_0094(DataGridView P_0)
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0087_0086_0095(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0086_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0086_0097(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0086_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0086_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0086_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0086_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0086_009C(List<DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0086_009D(List<_008A_0089> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0086_009E(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0086(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008E_0097 _0087_0087_008A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0091()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0087_0087_0097(Point3d P_0, Point3d P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ShowMessage(string s)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0087_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0088_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0089_009A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_0086()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554484)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_0099()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_009A()
		{
			return true;
		}
	}
}
namespace _0089_0089
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_0088 : Form
	{
		[Serializable]
		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_008E
		{
			public static readonly _0090_008E _003C_003E9;

			public static Func<_008A_008B, double> _003C_003E9__16_0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_008E()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554487)));
				_003C_003E9 = new _0090_008E();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_008E()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_008C(_008A_008B o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A7()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A8()
			{
				return true;
			}
		}

		private List<DBPoint> _0087_008E_009B;

		private Dictionary<string, DBPoint> _0087_008E_009C;

		private IContainer _0087_008E_009D;

		private Button _0087_008E_009E;

		private Button _0087_008F_0086;

		private Button _0087_008F_0087;

		private StatusStrip _0087_008F_0088;

		private ToolStripStatusLabel _0087_008F_0089;

		private ToolTip _0087_008F_008A;

		private GroupBox _0087_008F_008B;

		private TextBox _0087_008F_008C;

		private TextBox _0087_008F_008D;

		private Button _0087_008F_008E;

		private Label _0087_008F_008F;

		private Label _0087_008F_0090;

		private Label _0087_008F_0091;

		private Label _0087_008F_0092;

		private TextBox _0087_008F_0093;

		private TextBox _0087_008F_0094;

		private Button _0087_008F_0095;

		private GroupBox _0087_008F_0096;

		private Label _0087_008F_0097;

		private Label _0087_008F_0098;

		private Button _0087_008F_0099;

		private TextBox _0087_008F_009A;

		private TextBox _0087_008F_009B;

		private GroupBox _0087_008F_009C;

		private ToolStripStatusLabel _0087_008F_009D;

		private TextBox _0087_008F_009E;

		private Label _0087_0090_0086;

		private Button _0087_0090_0087;

		private DataGridView _0087_0090_0088;

		private CheckBox _0087_0090_0089;

		private TextBox _0087_0090_008A;

		private Label _0087_0090_008B;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0087_008D_0099(DataGridView P_0)
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0087_008D_009A(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008D_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008D_009C(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008D_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008D_009E(List<DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0086(List<_008A_008B> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static double _0087_008E_008B(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_008C(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0087_008E_008E(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_008F(double P_0, double P_1, double P_2, double P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008F_008E _0087_008E_0090(_008F_008E P_0, _008F_008E P_1, double P_2, double P_3, double P_4, double P_5, bool P_6)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0092(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_008E_009A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_0088()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554486)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_009B()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_009C()
		{
			return true;
		}
	}
}
namespace _0089_008B
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_008A : Form
	{
		private static double _0087_0090_0094;

		private IContainer _0087_0090_0095;

		private CheckBox _0087_0090_0096;

		private CheckBox _0087_0090_0097;

		private CheckBox _0087_0090_0098;

		private CheckBox _0087_0090_0099;

		private GroupBox _0087_0090_009A;

		private RadioButton _0087_0090_009B;

		private RadioButton _0087_0090_009C;

		private GroupBox _0087_0090_009D;

		private RadioButton _0087_0090_009E;

		private RadioButton _0087_0091_0086;

		private TextBox _0087_0091_0087;

		private Label _0087_0091_0088;

		private Button _0087_0091_0089;

		private GroupBox _0087_0091_008A;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_008A()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0087_0090_008C(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0090_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0090_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0090_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0087_0090_0090(string P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0090_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0090_0092(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0090_0093()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_008A()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554488)));
			_0087_0090_0094 = Math.PI / 180.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_009D()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_009E()
		{
			return true;
		}
	}
}
namespace _0089_008D
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_008C : Form
	{
		private _008A_0093 _0087_0092_008E;

		private _008A_0097 _0087_0092_008F;

		private _008F_008E _0087_0092_0090;

		private _008F_008E _0087_0092_0091;

		private IContainer _0087_0092_0092;

		private GroupBox _0087_0092_0093;

		private RadioButton _0087_0092_0094;

		private RadioButton _0087_0092_0095;

		private RadioButton _0087_0092_0096;

		private RadioButton _0087_0092_0097;

		private Button _0087_0092_0098;

		private ToolTip _0087_0092_0099;

		private RadioButton _0087_0092_009A;

		private RadioButton _0087_0092_009B;

		private Label _0087_0092_009C;

		private ComboBox _0087_0092_009D;

		private Label _0087_0092_009E;

		private Label _0087_0093_0086;

		private TextBox _0087_0093_0087;

		private TextBox _0087_0093_0088;

		private ComboBox _0087_0093_0089;

		private Label _0087_0093_008A;

		private TextBox _0087_0093_008B;

		private TextBox _0087_0093_008C;

		private Label _0087_0093_008D;

		private Label _0087_0093_008E;

		private Label _0087_0093_008F;

		private ComboBox _0087_0093_0090;

		private ComboBox _0087_0093_0091;

		private Label _0087_0093_0092;

		private TextBox _0087_0093_0093;

		private TextBox _0087_0093_0094;

		private TextBox _0087_0093_0095;

		private Label _0087_0093_0096;

		private Label _0087_0093_0097;

		private TextBox _0087_0093_0098;

		private TextBox _0087_0093_0099;

		private Label _0087_0093_009A;

		private TextBox _0087_0093_009B;

		private TextBox _0087_0093_009C;

		private TextBox _0087_0093_009D;

		private TextBox _0087_0093_009E;

		private Label _0087_0094_0086;

		private TextBox _0087_0094_0087;

		private TextBox _0087_0094_0088;

		private TextBox _0087_0094_0089;

		private TextBox _0087_0094_008A;

		private TextBox _0087_0094_008B;

		private TextBox _0087_0094_008C;

		private Label _0087_0094_008D;

		private Label _0087_0094_008E;

		private Label _0087_0094_008F;

		private Label _0087_0094_0090;

		private Button _0087_0094_0091;

		private Button _0087_0094_0092;

		private TabControl _0087_0094_0093;

		private TabPage _0087_0094_0094;

		private GroupBox _0087_0094_0095;

		private GroupBox _0087_0094_0096;

		private TextBox _0087_0094_0097;

		private TextBox _0087_0094_0098;

		private TextBox _0087_0094_0099;

		private Label _0087_0094_009A;

		private Button _0087_0094_009B;

		private Label _0087_0094_009C;

		private Label _0087_0094_009D;

		private GroupBox _0087_0094_009E;

		private Button _0087_0095_0086;

		private Button _0087_0095_0087;

		private TextBox _0087_0095_0088;

		private TextBox _0087_0095_0089;

		private Label _0087_0095_008A;

		private TextBox _0087_0095_008B;

		private Label _0087_0095_008C;

		private Label _0087_0095_008D;

		private TabPage _0087_0095_008E;

		private Label _0087_0095_008F;

		private TabPage _0087_0095_0090;

		private TextBox _0087_0095_0091;

		private Label _0087_0095_0092;

		private TextBox _0087_0095_0093;

		private TextBox _0087_0095_0094;

		private Label _0087_0095_0095;

		private TextBox _0087_0095_0096;

		private TextBox _0087_0095_0097;

		private TextBox _0087_0095_0098;

		private Button _0087_0095_0099;

		private Button _0087_0095_009A;

		private TextBox _0087_0095_009B;

		private Label _0087_0095_009C;

		private TextBox _0087_0095_009D;

		private Label _0087_0095_009E;

		private Label _0087_0096_0086;

		private TextBox _0087_0096_0087;

		private Button _0087_0096_0088;

		private GroupBox _0087_0096_0089;

		private TextBox _0087_0096_008A;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_008C(object P_0, FormClosedEventArgs P_1)
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0087_0091_008D(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_008F()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0093(_008A_0093 P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0091_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0092_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0092_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string _0087_0092_0088()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0092_0089(string P_0, bool P_1 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool _0087_0092_008A(string P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0092_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0092_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0092_008D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_008C()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554489)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087_009F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00870()
		{
			return true;
		}
	}
}
namespace _0089_008F
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_008E : Form
	{
		[Serializable]
		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _0090_008F
		{
			public static readonly _0090_008F _003C_003E9;

			public static Func<_008A_008B, double> _003C_003E9__14_0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_008F()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554491)));
				_003C_003E9 = new _0090_008F();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_008F()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_008D(_008A_008B o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008A9()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Aa()
			{
				return true;
			}
		}

		private List<DBPoint> _0087_0097_008C;

		private Dictionary<string, DBPoint> _0087_0097_008D;

		private IContainer _0087_0097_008E;

		private Button _0087_0097_008F;

		private Button _0087_0097_0090;

		private DataGridView _0087_0097_0091;

		private GroupBox _0087_0097_0092;

		private TextBox _0087_0097_0093;

		private TextBox _0087_0097_0094;

		private Label _0087_0097_0095;

		private Label _0087_0097_0096;

		private Button _0087_0097_0097;

		private Button _0087_0097_0098;

		private StatusStrip _0087_0097_0099;

		private ToolStripStatusLabel _0087_0097_009A;

		private ToolStripStatusLabel _0087_0097_009B;

		private Button _0087_0097_009C;

		private GroupBox _0087_0097_009D;

		private TextBox _0087_0097_009E;

		private TextBox _0087_0098_0086;

		private Label _0087_0098_0087;

		private Label _0087_0098_0088;

		private GroupBox _0087_0098_0089;

		private TextBox _0087_0098_008A;

		private TextBox _0087_0098_008B;

		private Label _0087_0098_008C;

		private Label _0087_0098_008D;

		private TextBox _0087_0098_008E;

		private TextBox _0087_0098_008F;

		private Label _0087_0098_0090;

		private Label _0087_0098_0091;

		private Button _0087_0098_0092;

		private Button _0087_0098_0093;

		private Button _0087_0098_0094;

		private CheckBox _0087_0098_0095;

		private TextBox _0087_0098_0096;

		private Label _0087_0098_0097;

		private TextBox _0087_0098_0098;

		private Label _0087_0098_0099;

		private Button _0087_0098_009A;

		private Button _0087_0098_009B;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_008E()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0087_0096_008B(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_008D(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_0091(List<DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_0092(List<_008A_008B> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<_008A_008B> _0087_0096_0094(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<_008A_008B> _0087_0096_0097(List<_008A_008B> P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6, double P_7)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<_008A_008B> _0087_0096_0098(List<_008A_008B> P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6, double P_7)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_009B(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _0087_0096_009D(_008F_008E P_0, _008F_008E P_1, double P_2, double P_3, bool P_4 = false)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0096_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0097_0086(_008F_008E P_0, _008F_008E P_1, double P_2, double P_3, double P_4, double P_5, bool P_6 = false)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0097_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0097_0088(TextBox P_0, TextBox P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0097_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0097_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0097_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_008E()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554490)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00871()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00872()
		{
			return true;
		}
	}
}
namespace _0089_0091
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_0090 : Form
	{
		private IContainer _0087_0099_0089;

		private Label _0087_0099_008A;

		private TextBox _0087_0099_008B;

		private TextBox _0087_0099_008C;

		private TextBox _0087_0099_008D;

		private Label _0087_0099_008E;

		private Button _0087_0099_008F;

		private Label _0087_0099_0090;

		private Label _0087_0099_0091;

		private ComboBox _0087_0099_0092;

		private Label _0087_0099_0093;

		private TextBox _0087_0099_0094;

		private GroupBox _0087_0099_0095;

		private CheckBox _0087_0099_0096;

		private CheckBox _0087_0099_0097;

		private GroupBox _0087_0099_0098;

		private Button _0087_0099_0099;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_0090()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0087_0098_009C(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0098_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0098_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0099_0086(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0099_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0099_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_0090()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554492)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00873()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00874()
		{
			return true;
		}
	}
}
namespace _0089_0093
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_0092 : Form
	{
		[Serializable]
		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0090
		{
			public static readonly _0090_0090 _003C_003E9;

			public static Func<_008A_008B, double> _003C_003E9__22_0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0090()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554494)));
				_003C_003E9 = new _0090_0090();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0090()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_008E(_008A_008B o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ab()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ac()
			{
				return true;
			}
		}

		private List<DBPoint> _0087_009B_0090;

		private Dictionary<string, DBPoint> _0087_009B_0091;

		private Point3d _0087_009B_0092;

		private Point3d _0087_009B_0093;

		private double _0087_009B_0094;

		private double _0087_009B_0095;

		private IContainer _0087_009B_0096;

		private TabControl _0087_009B_0097;

		private TabPage _0087_009B_0098;

		private TabPage _0087_009B_0099;

		private TabPage _0087_009B_009A;

		private TabPage _0087_009B_009B;

		private Label _0087_009B_009C;

		private TextBox _0087_009B_009D;

		private Label _0087_009B_009E;

		private ComboBox _0087_009C_0086;

		private TextBox _0087_009C_0087;

		private Label _0087_009C_0088;

		private Button _0087_009C_0089;

		private Button _0087_009C_008A;

		private Button _0087_009C_008B;

		private Button _0087_009C_008C;

		private CheckBox _0087_009C_008D;

		private ComboBox _0087_009C_008E;

		private Label _0087_009C_008F;

		private Button _0087_009C_0090;

		private Button _0087_009C_0091;

		private CheckBox _0087_009C_0092;

		private Label _0087_009C_0093;

		private ComboBox _0087_009C_0094;

		private TextBox _0087_009C_0095;

		private Label _0087_009C_0096;

		private Label _0087_009C_0097;

		private ComboBox _0087_009C_0098;

		private ComboBox _0087_009C_0099;

		private Label _0087_009C_009A;

		private TextBox _0087_009C_009B;

		private Label _0087_009C_009C;

		private CheckBox _0087_009C_009D;

		private Button _0087_009C_009E;

		private Button _0087_009D_0086;

		private CheckBox _0087_009D_0087;

		private Button _0087_009D_0088;

		private Button _0087_009D_0089;

		private TextBox _0087_009D_008A;

		private ComboBox _0087_009D_008B;

		private Label _0087_009D_008C;

		private Label _0087_009D_008D;

		private ComboBox _0087_009D_008E;

		private Label _0087_009D_008F;

		private CheckBox _0087_009D_0090;

		private Label _0087_009D_0091;

		private TextBox _0087_009D_0092;

		private Label _0087_009D_0093;

		private TextBox _0087_009D_0094;

		private ToolTip _0087_009D_0095;

		private Button _0087_009D_0096;

		private CheckBox _0087_009D_0097;

		private _008F_0098 _0087_009D_0098;

		private Button _0087_009D_0099;

		private Button _0087_009D_009A;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_0092()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0087_0099_009A(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0099_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0099_009C(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008E_009B _0087_0099_009D()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_0099_009E(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0087_009A_0086()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_0087(List<List<_008F_008E>> P_0, string P_1 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_0088(List<_008F_008E> P_0, string P_1 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static double _0087_009A_0093(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static List<Point3d> _0087_009A_0096(List<Point3d> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int _0087_009A_0097(Point3d P_0, Point3d P_1, Point3d P_2)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool _0087_009A_0099(Polyline P_0, _008F_008E P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0087_009A_009A(Polyline P_0, _008F_008E P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0087_009A_009B(Point2d P_0, Point2d P_1, Point2d P_2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0087_009A_009C(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009A_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009B_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009B_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009B_0088(List<DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009B_0089(List<_008A_008B> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009B_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009B_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009B_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009B_008D(out _008F_008E P_0, out _008F_008E P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<_008F_008E> _0087_009B_008E(List<_008F_008E> P_0, double P_1, double P_2 = 1.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009B_008F()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_0092()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554493)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00875()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00876()
		{
			return true;
		}
	}
}
namespace _0089_0095
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_0094 : Form
	{
		private static double _0087_009E_0097;

		private static double _0087_009E_0098;

		private IContainer _0087_009E_0099;

		private Button _0087_009E_009A;

		private Button _0087_009E_009B;

		private CheckBox _0087_009E_009C;

		private CheckBox _0087_009E_009D;

		private CheckBox _0087_009E_009E;

		private CheckBox _0088_0086_0086;

		private GroupBox _0088_0086_0087;

		private Label _0088_0086_0088;

		private CheckBox _0088_0086_0089;

		private CheckBox _0088_0086_008A;

		private TextBox _0088_0086_008B;

		private Label _0088_0086_008C;

		private TextBox _0088_0086_008D;

		private Label _0088_0086_008E;

		private RadioButton _0088_0086_008F;

		private RadioButton _0088_0086_0090;

		private Label _0088_0086_0091;

		private TextBox _0088_0086_0092;

		private GroupBox _0088_0086_0093;

		private Button _0088_0086_0094;

		private Button _0088_0086_0095;

		private Button _0088_0086_0096;

		private Button _0088_0086_0097;

		private GroupBox _0088_0086_0098;

		private RadioButton _0088_0086_0099;

		private RadioButton _0088_0086_009A;

		private _008F_0098 _0088_0086_009B;

		private Button _0088_0086_009C;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_0094()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0087_009D_009B(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009D_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009D_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009D_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0087(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0087_009E_008A(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string _0087_009E_008B(double P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0087_009E_008C(Vector2d P_0, Vector2d P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool _0087_009E_008D(Vector2d P_0, Vector2d P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string _0087_009E_0094()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0095(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0087_009E_0096()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_0094()
		{
			_0090_009B._008B_0090_0088();
			_00878();
			int num;
			if (_00877())
			{
				num = 3;
				goto IL_0038;
			}
			int num2 = 2;
			if (!_00877())
			{
				goto IL_001f;
			}
			goto IL_003c;
			IL_001f:
			_0087_009E_0097 = Math.PI / 180.0;
			goto IL_0075;
			IL_0075:
			_0087_009E_0098 = 90.0 * _0087_009E_0097;
			num = 5;
			goto IL_0038;
			IL_0038:
			num2 = num;
			goto IL_003c;
			IL_003c:
			while (true)
			{
				switch (num2)
				{
				case 1:
				case 2:
					break;
				default:
					num2 = 4;
					if (_00877())
					{
						continue;
					}
					goto IL_0075;
				case 4:
					goto IL_0075;
				case 0:
				case 3:
					LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554495)));
					break;
				case 5:
					return;
				}
				break;
			}
			goto IL_001f;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00877()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00878()
		{
			return true;
		}
	}
}
namespace _0089_0097
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_0096
	{
		public _008A_0093 _0088_0087_008D;

		public _008F_008E _0088_0087_008E;

		public _008F_008E _0088_0087_008F;

		public _008F_008E _0088_0087_0090;

		public _008F_008E _0088_0087_0091;

		public _008F_008E _0088_0087_0092;

		public _008F_008E _0088_0087_0093;

		public _008F_008E _0088_0087_0094;

		public _008F_008E _0088_0087_0095;

		public _008F_008E _0088_0087_0096;

		public _008F_008E _0088_0087_0097;

		public Dictionary<string, string> _0088_0087_0098;

		public List<List<_008F_008E>> _0088_0087_0099;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_0096(_008A_0093 P_0, _008F_008E P_1, _008F_008E P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0086_009D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0086_009E(_008F_008E P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0087_0086()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0087_0087()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0087_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0087_0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0087_008A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0087_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0087_008C(double P_0 = 10000.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_0096()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554496)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00879()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087a()
		{
			return true;
		}
	}
}
namespace _0089_0099
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_0098
	{
		public _008E_009B _0088_0088_008E;

		public double _0088_0088_008F;

		public double _0088_0088_0090;

		public double _0088_0088_0091;

		public double _0088_0088_0092;

		public double _0088_0088_0093;

		private double _0088_0088_0094;

		private double _0088_0088_0095;

		public double _0088_0088_0096;

		public double _0088_0088_0097;

		public double _0088_0088_0098;

		public double _0088_0088_0099;

		public double _0088_0088_009A;

		public double _0088_0088_009B;

		public double _0088_0088_009C;

		public double _0088_0088_009D;

		public double _0088_0088_009E;

		public double _0088_0089_0086;

		private _008F_008E _0088_0089_0087;

		private _008F_008E _0088_0089_0088;

		private _008F_008E _0088_0089_0089;

		private _008F_008E _0088_0089_008A;

		private _008F_008E _0088_0089_008B;

		private _008F_008E _0088_0089_008C;

		private _008F_008E _0088_0089_008D;

		private _008F_008E _0088_0089_008E;

		private _008F_008E _0088_0089_008F;

		private _008F_008E _0088_0089_0090;

		private _008F_008E _0088_0089_0091;

		private _008F_008E _0088_0089_0092;

		private _008F_008E _0088_0089_0093;

		private _008F_008E _0088_0089_0094;

		private _008F_008E _0088_0089_0095;

		private _008F_008E _0088_0089_0096;

		private _008F_008E _0088_0089_0097;

		private _008F_008E _0088_0089_0098;

		private _008F_008E _0088_0089_0099;

		private _008F_008E _0088_0089_009A;

		private _008F_008E _0088_0089_009B;

		private _008F_008E _0088_0089_009C;

		private _008F_008E _0088_0089_009D;

		private _008F_008E _0088_0089_009E;

		private _008F_008E _0088_008A_0086;

		private _008F_008E _0088_008A_0087;

		private _008F_0088 _0088_008A_0088;

		private _008F_0088 _0088_008A_0089;

		private _008F_0088 _0088_008A_008A;

		private _008F_0088 _0088_008A_008B;

		private _008F_0088 _0088_008A_008C;

		private _008F_0088 _0088_008A_008D;

		public double _0088_008A_008E;

		public double _0088_008A_008F;

		public double _0088_008A_0090;

		public List<_008F_008E> _0088_008A_0091;

		public List<_008F_008E> _0088_008A_0092;

		public List<_008F_008E> _0088_008A_0093;

		public List<_008F_008E> _0088_008A_0094;

		public List<List<_008F_008E>> _0088_008A_0095;

		public List<List<_008F_008E>> _0088_008A_0096;

		private double _0088_008A_0097;

		private double _0088_008A_0098;

		private double _0088_008A_0099;

		private double _0088_008A_009A;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_0098(_008E_009B P_0, double P_1 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0087_009A(bool P_0 = false)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0087_009B(bool P_0 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008F_008E _0088_0087_009C(List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0087_009D(_008F_008E P_0, _008F_008E P_1, double P_2, double P_3, bool P_4 = false)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static List<_008F_008E> _0088_0087_009E(List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int _0088_0088_0086(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0088_0087()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0088_0088(_008E_009B P_0, double P_1 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0088_0089(ref List<List<_008F_008E>> P_0, _008F_008E P_1, _008F_008E P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void _0088_0088_008A(_008F_008E P_0, _008F_008E P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<_008F_008E> _0088_0088_008B(_008F_008E P_0, _008F_008E P_1, double P_2, double P_3 = Math.PI * 3.0 / 5.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0088_008C(List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0088_008D(ref List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4, double P_5 = 2.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_0098()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554497)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087b()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087c()
		{
			return true;
		}
	}
}
namespace _0089_009B
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_009A
	{
		public _008E_009B _0088_008B_0089;

		public double _0088_008B_008A;

		public double _0088_008B_008B;

		public double _0088_008B_008C;

		public double _0088_008B_008D;

		public double _0088_008B_008E;

		public _008F_008E _0088_008B_008F;

		private _008F_008E _0088_008B_0090;

		private _008F_008E _0088_008B_0091;

		private _008F_008E _0088_008B_0092;

		private _008F_008E _0088_008B_0093;

		private _008F_008E _0088_008B_0094;

		private _008F_008E _0088_008B_0095;

		private double _0088_008B_0096;

		private double _0088_008B_0097;

		private _008F_0086 _0088_008B_0098;

		private _008F_0086 _0088_008B_0099;

		public string _0088_008B_009A;

		public double _0088_008B_009B;

		public double _0088_008B_009C;

		public double _0088_008B_009D;

		public List<List<_008F_008E>> _0088_008B_009E;

		public List<List<_008F_008E>> _0088_008C_0086;

		public List<List<_008F_008E>> _0088_008C_0087;

		public List<_008F_008E> _0088_008C_0088;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_009A(_008E_009B P_0, double P_1 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_008A_009B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_008A_009C(_008E_009B P_0, double P_1 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void _0088_008A_009D(_008F_008E P_0, _008F_008E P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void _0088_008A_009E(_008F_008E P_0, _008F_008E P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<_008F_008E> _0088_008B_0086(_008F_008E P_0, _008F_008E P_1, double P_2, double P_3 = Math.PI * 3.0 / 5.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_008B_0087(List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_008B_0088(ref List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4, double P_5 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_009A()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554498)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087d()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087e()
		{
			return true;
		}
	}
}
namespace _0089_009D
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_009C
	{
		public _008E_009B _0088_008C_0090;

		public double _0088_008C_0091;

		public double _0088_008C_0092;

		public double _0088_008C_0093;

		public double _0088_008C_0094;

		public double _0088_008C_0095;

		public _008F_008E _0088_008C_0096;

		private _008F_008E _0088_008C_0097;

		private _008F_008E _0088_008C_0098;

		private _008F_008E _0088_008C_0099;

		private _008F_008E _0088_008C_009A;

		private _008F_008E _0088_008C_009B;

		private _008F_008E _0088_008C_009C;

		private _008F_008E _0088_008C_009D;

		private _008F_008E _0088_008C_009E;

		private double _0088_008D_0086;

		private double _0088_008D_0087;

		private _008F_0086 _0088_008D_0088;

		private _008F_0086 _0088_008D_0089;

		public string _0088_008D_008A;

		public double _0088_008D_008B;

		public double _0088_008D_008C;

		public double _0088_008D_008D;

		public double _0088_008D_008E;

		public List<List<_008F_008E>> _0088_008D_008F;

		public List<List<_008F_008E>> _0088_008D_0090;

		public List<List<_008F_008E>> _0088_008D_0091;

		public List<_008F_008E> _0088_008D_0092;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_009C(_008E_009B P_0, double P_1 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_008C_0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_008C_008A(_008E_009B P_0, double P_1 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void _0088_008C_008B(_008F_008E P_0, _008F_008E P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected void _0088_008C_008C(_008F_008E P_0, _008F_008E P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<_008F_008E> _0088_008C_008D(_008F_008E P_0, _008F_008E P_1, double P_2, double P_3 = Math.PI * 3.0 / 5.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_008C_008E(List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_008C_008F(ref List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4, double P_5 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_009C()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554499)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087f()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087g()
		{
			return true;
		}
	}
}
namespace _008A_0086
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089_009E : Form
	{
		private IContainer _0088_008D_0099;

		private RichTextBox _0088_008D_009A;

		private Button _0088_008D_009B;

		private Button _0088_008D_009C;

		private Button _0088_008D_009D;

		private OpenFileDialog _0088_008D_009E;

		private Button _0088_008E_0086;

		private Button _0088_008E_0087;

		private ToolTip _0088_008E_0088;

		private GroupBox _0088_008E_0089;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0089_009E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_008D_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_008D_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_008D_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_008D_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_008D_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_008D_0098()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0089_009E()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554500)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087h()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087i()
		{
			return true;
		}
	}
}
namespace _008A_0088
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _008A_0087
	{
		[CompilerGenerated]
		private string _0088_008E_0092;

		[CompilerGenerated]
		private int _0088_008E_0093;

		[CompilerGenerated]
		private int _0088_008E_0094;

		public string Name
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public int _0088_008E_008C()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008E_008D(int P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public int _0088_008E_008F()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008E_0090(int P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0087()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_0087()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554501)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087j()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087k()
		{
			return true;
		}
	}
}
namespace _008A_008A
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_0089 : _008F_008E
	{
		[CompilerGenerated]
		private string _0088_008F_0094;

		[CompilerGenerated]
		private string _0088_008F_0095;

		[CompilerGenerated]
		private double _0088_008F_0096;

		[CompilerGenerated]
		private double _0088_008F_0097;

		[CompilerGenerated]
		private double _0088_008F_0098;

		[CompilerGenerated]
		private double _0088_008F_0099;

		[CompilerGenerated]
		private double _0088_008F_009A;

		[CompilerGenerated]
		private double _0088_008F_009B;

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public string _0088_008E_0095()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008E_0096(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public string _0088_008E_0098()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008E_0099(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _0088_008E_009B()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008E_009C(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _0088_008E_009E()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008F_0086(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _0088_008F_0088()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008F_0089(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _0088_008F_008B()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008F_008C(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _0088_008F_008E()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008F_008F(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _0088_008F_0091()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _0088_008F_0092(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0089(_008F_008E P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_0089()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554502)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087l()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087m()
		{
			return true;
		}
	}
}
namespace _008A_008C
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_008B : _008F_008E
	{
		public string _0088_008F_009C;

		public double _0088_008F_009D;

		public double _0088_008F_009E;

		public double _0088_0090_0086;

		public double _0088_0090_0087;

		public double _0088_0090_0088;

		public double _0088_0090_0089;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_008B(_008F_008E P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_008B()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554503)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087n()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087o()
		{
			return true;
		}
	}
}
namespace _008A_008E
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_008D : _008F_008E
	{
		public string _0088_0090_008A;

		public double _0088_0090_008B;

		public double _0088_0090_008C;

		public double _0088_0090_008D;

		public double _0088_0090_008E;

		public double _0088_0090_008F;

		public double _0088_0090_0090;

		public double _0088_0090_0091;

		public double _0088_0090_0092;

		public double _0088_0090_0093;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_008D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_008D(_008F_008E P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_008D()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554504)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087p()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087q()
		{
			return true;
		}
	}
}
namespace _008A_0090
{
	[LicenseProvider(typeof(_0091_008B))]
	public enum _008A_008F
	{

	}
}
namespace _008A_0092
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_0091
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008A_0093 _0088_0090_0094(string P_0, _008A_008F P_1, string P_2, string P_3)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _0088_0090_0095(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_0090_0096(ref _008A_0093 P_0, double P_1, double P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _0088_0090_0097(ref _008A_0093 P_0, double P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0091()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_0091()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554506)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087t()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087u()
		{
			return true;
		}
	}
}
namespace _008A_0094
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_0093
	{
		public _008F_008E _0088_0091_0089;

		public _008F_008E _0088_0091_008A;

		public _008F_008E _0088_0091_008B;

		public _008F_008E _0088_0091_008C;

		public _008F_008E _0088_0091_008D;

		public _008F_008E _0088_0091_008E;

		public _008F_008E _0088_0091_008F;

		public _008F_008E _0088_0091_0090;

		public _008F_008E _0088_0091_0091;

		public _008F_008C _0088_0091_0092;

		public _008F_008C _0088_0091_0093;

		public _008F_008C _0088_0091_0094;

		public _008F_008C _0088_0091_0095;

		public _008F_0092 _0088_0091_0096;

		public _008F_0092 _0088_0091_0097;

		public _008F_0092 _0088_0091_0098;

		public _008F_0092 _0088_0091_0099;

		public _008F_0092 _0088_0091_009A;

		public _008A_008F _0088_0091_009B;

		public int _0088_0091_009C;

		public List<List<_008F_008E>> _0088_0091_009D;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0093(_008A_008F P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0090_0098(double P_0 = 0.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0090_0099(double P_0 = 0.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _0088_0090_009A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _0088_0090_009B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _0088_0090_009C()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _0088_0090_009D()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _0088_0090_009E()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _0088_0091_0086(double P_0 = 10000.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _0088_0091_0087()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E _0088_0091_0088(_008F_008E P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_0093()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554507)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087v()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087w()
		{
			return true;
		}
	}
}
namespace _008A_0096
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_0095
	{
		private double _0088_0092_0087;

		private double _0088_0092_0088;

		private double _0088_0092_0089;

		private double _0088_0092_008A;

		public double _0088_0092_008B;

		public double _0088_0092_008C;

		public double _0088_0092_008D;

		public double _0088_0092_008E;

		public bool _0088_0092_008F;

		public double _0088_0092_0090;

		public double _0088_0092_0091;

		public double _0088_0092_0092;

		public _008F_008E _0088_0092_0093;

		private _008F_008E _0088_0092_0094;

		private _008F_008E _0088_0092_0095;

		private _008F_008E _0088_0092_0096;

		private _008F_008E _0088_0092_0097;

		private _008F_008C _0088_0092_0098;

		private _008F_008C _0088_0092_0099;

		private _008F_008C _0088_0092_009A;

		private _008F_008C _0088_0092_009B;

		public List<List<_008F_008E>> _0088_0092_009C;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0095(_008E_0097 P_0, double P_1, double P_2, double P_3, double P_4 = 0.033, bool P_5 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0089 _0088_0091_009E(_008A_0089 P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0092_0086()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_0095()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554508)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087x()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087y()
		{
			return true;
		}
	}
}
namespace _008A_0098
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_0097
	{
		public _008F_008E _0088_0093_0090;

		public _008F_008E _0088_0093_0091;

		public _008F_008E _0088_0093_0092;

		public _008F_008E _0088_0093_0093;

		public _008F_008E _0088_0093_0094;

		public _008F_008E _0088_0093_0095;

		public _008F_008E _0088_0093_0096;

		public _008F_008E _0088_0093_0097;

		public _008F_008E _0088_0093_0098;

		public _008F_008E _0088_0093_0099;

		public _008F_008E _0088_0093_009A;

		public _008F_008E _0088_0093_009B;

		public _008F_008E _0088_0093_009C;

		public _008F_008E _0088_0093_009D;

		public _008F_008C _0088_0093_009E;

		public _008F_008C _0088_0094_0086;

		public _008F_008C _0088_0094_0087;

		public _008F_008C _0088_0094_0088;

		public _008F_008C _0088_0094_0089;

		public _008F_008C _0088_0094_008A;

		public _008F_0092 _0088_0094_008B;

		public _008F_0092 _0088_0094_008C;

		public _008F_0092 _0088_0094_008D;

		public _008F_0092 _0088_0094_008E;

		public _008F_0092 _0088_0094_008F;

		public _008F_0092 _0088_0094_0090;

		public int _0088_0094_0091;

		public List<List<_008F_008E>> _0088_0094_0092;

		public List<List<_008F_008E>> _0088_0094_0093;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0097(double P_0 = 0.0524)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0097(_008A_0093 P_0, double P_1 = 0.0524)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0092_009D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E _0088_0092_009E(_008F_008E P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_0086()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_0087()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_008A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_008D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_008E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0093_008F()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_0097()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554509)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087z()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0086()
		{
			return true;
		}
	}
}
namespace _008A_009A
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_0099
	{
		public _008A_0093 _0088_0094_009C;

		public _008F_008E _0088_0094_009D;

		public _008F_008E _0088_0094_009E;

		public _008F_008E _0088_0095_0086;

		public _008F_008E _0088_0095_0087;

		public _008F_008E _0088_0095_0088;

		public _008F_008E _0088_0095_0089;

		public _008F_008E _0088_0095_008A;

		public _008F_0092 _0088_0095_008B;

		public _008F_008E _0088_0095_008C;

		public _008F_008E _0088_0095_008D;

		private double _0088_0095_008E;

		public Dictionary<string, string> _0088_0095_008F;

		public List<List<_008F_008E>> _0088_0095_0090;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0099(_008A_0093 P_0, _008F_008E P_1, _008F_008E P_2, double P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0094_0094()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0094_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0094_0096()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0094_0097()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0094_0098()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0094_0099()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0094_009A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0094_009B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_0099()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554510)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0087()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0088()
		{
			return true;
		}
	}
}
namespace _008A_009C
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_009B
	{
		public _008A_0093 _0088_0095_0098;

		public _008F_008E _0088_0095_0099;

		public _008F_008E _0088_0095_009A;

		public _008F_008E _0088_0095_009B;

		public _008F_008E _0088_0095_009C;

		public _008F_008E _0088_0095_009D;

		public _008F_008E _0088_0095_009E;

		public _008F_008E _0088_0096_0086;

		public _008F_0092 _0088_0096_0087;

		public _008F_008E _0088_0096_0088;

		public _008F_008E _0088_0096_0089;

		public Dictionary<string, string> _0088_0096_008A;

		public List<List<_008F_008E>> _0088_0096_008B;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_009B(_008A_0093 P_0, _008F_008E P_1, _008F_008E P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0095_0091()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0095_0092()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0095_0093()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0095_0094()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0095_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0095_0096()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_0095_0097()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_009B()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554511)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0089()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_008A()
		{
			return true;
		}
	}
}
namespace _008A_009E
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008A_009D
	{
		public _008E_0097 _0088_0096_008C;

		public _008F_008E _0088_0096_008D;

		public _008F_008E _0088_0096_008E;

		public _008F_008E _0088_0096_008F;

		public _008F_008E _0088_0096_0090;

		public _008F_008E _0088_0096_0091;

		public _008F_008E _0088_0096_0092;

		public double _0088_0096_0093;

		public double _0088_0096_0094;

		public double _0088_0096_0095;

		public double _0088_0096_0096;

		private _008F_0092 _0088_0096_0097;

		private _008F_008C _0088_0096_0098;

		private _008F_008C _0088_0096_0099;

		public Dictionary<string, string> _0088_0096_009A;

		public List<List<_008F_008E>> _0088_0096_009B;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_009D(_008E_0097 P_0, _008F_008E P_1, _008F_008E P_2, double P_3, double P_4, double P_5, double P_6)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008A_009D()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554512)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_008B()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_008C()
		{
			return true;
		}
	}
}
namespace _008B_0087
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _008B_0086
	{
		public _008E_009B _0088_0097_008A;

		public double _0088_0097_008B;

		public double _0088_0097_008C;

		public double _0088_0097_008D;

		public double _0088_0097_008E;

		public double _0088_0097_008F;

		public double _0088_0097_0090;

		public double _0088_0097_0091;

		public double _0088_0097_0092;

		public double _0088_0097_0093;

		public double _0088_0097_0094;

		public double _0088_0097_0095;

		public double _0088_0097_0096;

		public double _0088_0097_0097;

		public _008F_0086 _0088_0097_0098;

		public _008F_0086 _0088_0097_0099;

		public _008F_0086 _0088_0097_009A;

		public double _0088_0097_009B;

		public double _0088_0097_009C;

		public double _0088_0097_009D;

		public double _0088_0097_009E;

		public List<_008F_008E> _0088_0098_0086;

		public List<_008F_008E> _0088_0098_0087;

		public List<List<_008F_008E>> _0088_0098_0088;

		public _008F_008E _0088_0098_0089;

		public _008F_008E _0088_0098_008A;

		public _008F_008E _0088_0098_008B;

		public _008F_008E _0088_0098_008C;

		public _008F_008E _0088_0098_008D;

		public _008F_008E _0088_0098_008E;

		public _008F_008E _0088_0098_008F;

		public _008F_008E _0088_0098_0090;

		public _008F_008E _0088_0098_0091;

		public _008F_008E _0088_0098_0092;

		public _008F_008E _0088_0098_0093;

		public _008F_008E _0088_0098_0094;

		public static double _0088_0098_0095;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_0086(_008E_009B P_0, double P_1 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0096_009C(bool P_0 = false)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0096_009D(bool P_0 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0096_009E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0097_0086()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _0088_0097_0087()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<List<_008F_008E>> _0088_0097_0088(double P_0, double P_1, double P_2, double P_3, double P_4)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0097_0089(ref List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4, double P_5 = 2.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_0086()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554513)));
			_0088_0098_0095 = Math.PI / 180.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_008D()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_008E()
		{
			return true;
		}
	}
}
namespace _008B_0089
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _008B_0088
	{
		public _008E_009B _0088_0098_009D;

		public double _0088_0098_009E;

		public double _0088_0099_0086;

		public double _0088_0099_0087;

		public double _0088_0099_0088;

		public double _0088_0099_0089;

		public List<_008F_008E> _0088_0099_008A;

		public List<_008F_008E> _0088_0099_008B;

		public List<List<_008F_008E>> _0088_0099_008C;

		public _008F_0086 _0088_0099_008D;

		public _008F_0086 _0088_0099_008E;

		public double _0088_0099_008F;

		public double _0088_0099_0090;

		public double _0088_0099_0091;

		public double _0088_0099_0092;

		public _008F_008E _0088_0099_0093;

		public _008F_008E _0088_0099_0094;

		public _008F_008E _0088_0099_0095;

		public _008F_008E _0088_0099_0096;

		public _008F_008E _0088_0099_0097;

		public _008F_008E _0088_0099_0098;

		public _008F_008E _0088_0099_0099;

		public _008F_008E _0088_0099_009A;

		public _008F_008E _0088_0099_009B;

		public _008F_008E _0088_0099_009C;

		public _008F_008E _0088_0099_009D;

		public _008F_008E _0088_0099_009E;

		public double _0088_009A_0086;

		public double _0088_009A_0087;

		public static double _0088_009A_0088;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_0088(_008E_009B P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0098_0096(bool P_0 = false)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0098_0097(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0098_0098()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _0088_0098_0099()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _0088_0098_009A(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0098_009B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0088_0098_009C(ref List<_008F_008E> P_0, _008F_008E P_1, double P_2, double P_3, double P_4, double P_5 = 2.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_0088()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554514)));
			_0088_009A_0088 = Math.PI / 180.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_008F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0090()
		{
			return true;
		}
	}
}
namespace _008B_008B
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _008B_008A
	{
		public double _0088_009A_0089;

		public double _0088_009A_008A;

		public double _0088_009A_008B;

		private _008E_009B _0088_009A_008C;

		public static double[] _0088_009A_008D;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_008A(double P_0, double P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_008A()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554515)));
			_0088_009A_008D = new double[15]
			{
				356.0, 370.0, 387.0, 404.0, 424.0, 441.0, 452.0, 459.0, 467.0, 472.0,
				478.0, 483.0, 487.0, 491.0, 493.0
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0091()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0092()
		{
			return true;
		}
	}
}
namespace _008B_008D
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008B_008C : Form
	{
		[Serializable]
		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0091
		{
			public static readonly _0090_0091 _003C_003E9;

			public static Func<_008A_008D, double> _003C_003E9__0_0;

			public static Func<_008A_008B, double> _003C_003E9__203_0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0091()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554517)));
				_003C_003E9 = new _0090_0091();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0091()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_008F(_008A_008D o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_0090(_008A_008B o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ad()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ae()
			{
				return true;
			}
		}

		private List<DBPoint> _0088_009D_0087;

		private Dictionary<string, DBPoint> _0088_009D_0088;

		private const double _0088_009D_0089 = 0.539957;

		private const double _0088_009D_008A = 1.852;

		private IContainer _0088_009D_008B;

		private StatusStrip _0088_009D_008C;

		private ToolStripStatusLabel _0088_009D_008D;

		private Button _0088_009D_008E;

		private Button _0088_009D_008F;

		private DataGridView _0088_009D_0090;

		private Button _0088_009D_0091;

		private Button _0088_009D_0092;

		private GroupBox _0088_009D_0093;

		private TextBox _0088_009D_0094;

		private TextBox _0088_009D_0095;

		private TextBox _0088_009D_0096;

		private Label _0088_009D_0097;

		private Button _0088_009D_0098;

		private Label _0088_009D_0099;

		private Label _0088_009D_009A;

		private GroupBox _0088_009D_009B;

		private Button _0088_009D_009C;

		private TextBox _0088_009D_009D;

		private TextBox _0088_009D_009E;

		private Label _0088_009E_0086;

		private TextBox _0088_009E_0087;

		private Label _0088_009E_0088;

		private Label _0088_009E_0089;

		private TabControl _0088_009E_008A;

		private TabPage _0088_009E_008B;

		private TabPage _0088_009E_008C;

		private Button _0088_009E_008D;

		private Button _0088_009E_008E;

		private Label _0088_009E_008F;

		private Label _0088_009E_0090;

		private ComboBox _0088_009E_0091;

		private Button _0088_009E_0092;

		private TextBox _0088_009E_0093;

		private Label _0088_009E_0094;

		private TextBox _0088_009E_0095;

		private Label _0088_009E_0096;

		private GroupBox _0088_009E_0097;

		private ComboBox _0088_009E_0098;

		private Label _0088_009E_0099;

		private TextBox _0088_009E_009A;

		private TextBox _0088_009E_009B;

		private TextBox _0088_009E_009C;

		private Label _0088_009E_009D;

		private Label _0088_009E_009E;

		private Label _0089_0086_0086;

		private GroupBox _0089_0086_0087;

		private Label _0089_0086_0088;

		private TextBox _0089_0086_0089;

		private Label _0089_0086_008A;

		private TextBox _0089_0086_008B;

		private GroupBox _0089_0086_008C;

		private TextBox _0089_0086_008D;

		private Label _0089_0086_008E;

		private GroupBox _0089_0086_008F;

		private ComboBox _0089_0086_0090;

		private TabPage _0089_0086_0091;

		private Button _0089_0086_0092;

		private Button _0089_0086_0093;

		private Label _0089_0086_0094;

		private ToolTip _0089_0086_0095;

		private TextBox _0089_0086_0096;

		private TabPage _0089_0086_0097;

		private Label _0089_0086_0098;

		private TextBox _0089_0086_0099;

		private GroupBox _0089_0086_009A;

		private CheckBox _0089_0086_009B;

		private ToolStripStatusLabel _0089_0086_009C;

		private GroupBox _0089_0086_009D;

		private Button _0089_0086_009E;

		private Button _0089_0087_0086;

		private Label _0089_0087_0087;

		private TextBox _0089_0087_0088;

		private TextBox _0089_0087_0089;

		private TextBox _0089_0087_008A;

		private TextBox _0089_0087_008B;

		private Label _0089_0087_008C;

		private Label _0089_0087_008D;

		private TextBox _0089_0087_008E;

		private TextBox _0089_0087_008F;

		private Label _0089_0087_0090;

		private GroupBox _0089_0087_0091;

		private TextBox _0089_0087_0092;

		private Label _0089_0087_0093;

		private Label _0089_0087_0094;

		private Label _0089_0087_0095;

		private TextBox _0089_0087_0096;

		private TextBox _0089_0087_0097;

		private Label _0089_0087_0098;

		private TextBox _0089_0087_0099;

		private Button _0089_0087_009A;

		private Button _0089_0087_009B;

		private Button _0089_0087_009C;

		private Button _0089_0087_009D;

		private TabPage _0089_0087_009E;

		private GroupBox _0089_0088_0086;

		private ComboBox _0089_0088_0087;

		private Label _0089_0088_0088;

		private Label _0089_0088_0089;

		private Label _0089_0088_008A;

		private Label _0089_0088_008B;

		private TextBox _0089_0088_008C;

		private TextBox _0089_0088_008D;

		private TextBox _0089_0088_008E;

		private Button _0089_0088_008F;

		private GroupBox _0089_0088_0090;

		private ComboBox _0089_0088_0091;

		private ComboBox _0089_0088_0092;

		private Label _0089_0088_0093;

		private ComboBox _0089_0088_0094;

		private Label _0089_0088_0095;

		private TextBox _0089_0088_0096;

		private Label _0089_0088_0097;

		private Label _0089_0088_0098;

		private GroupBox _0089_0088_0099;

		private TextBox _0089_0088_009A;

		private Label _0089_0088_009B;

		private TextBox _0089_0088_009C;

		private Label _0089_0088_009D;

		private Label _0089_0088_009E;

		private TextBox _0089_0089_0086;

		private TextBox _0089_0089_0087;

		private Label _0089_0089_0088;

		private Label _0089_0089_0089;

		private Label _0089_0089_008A;

		private TextBox _0089_0089_008B;

		private TextBox _0089_0089_008C;

		private Label _0089_0089_008D;

		private Button _0089_0089_008E;

		private Button _0089_0089_008F;

		private _0087_008C _0089_0089_0090;

		private _0087_008C _0089_0089_0091;

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_008F(List<_008A_008D> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008C_0097 _0088_009A_0090()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_0091(ref _008A_008D P_0, double P_1, double P_2, double P_3, string P_4)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_008C()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0088_009A_0092(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_0094(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_0096(List<DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008E_0097 _0088_009A_009A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008B_009C _0088_009A_009C()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009A_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_008A(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009B_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_009B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009C_009E(List<_008A_008B> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0088_009D_0086(ref _008A_008B P_0, double P_1, double P_2, double P_3, double P_4, string P_5)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_008C()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554516)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0093()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0094()
		{
			return true;
		}
	}
}
namespace _008B_008F
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008B_008E : Form
	{
		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _0090_0092
		{
			public TextBox targetTextBox;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0092()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0091(object s, EventArgs ev)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0092(object s, EventArgs ev)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0093(object s, EventArgs ev)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0094(object s, EventArgs ev)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0095(object s, EventArgs ev)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0096(object s, EventArgs ev)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0097(object s, EventArgs ev)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0098(object s, EventArgs ev)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_008E_0099(object s, EventArgs ev)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0092()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554519)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Af()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ag()
			{
				return true;
			}
		}

		public _008E_009B _0089_0089_009D;

		public _008F_0086 _0089_0089_009E;

		private IContainer _0089_008A_0086;

		private Button _0089_008A_0087;

		private TextBox _0089_008A_0088;

		private Label _0089_008A_0089;

		private TextBox _0089_008A_008A;

		private Label _0089_008A_008B;

		private TextBox _0089_008A_008C;

		private Label _0089_008A_008D;

		private CheckBox _0089_008A_008E;

		private CheckBox _0089_008A_008F;

		private CheckBox _0089_008A_0090;

		private CheckBox _0089_008A_0091;

		private CheckBox _0089_008A_0092;

		private CheckBox _0089_008A_0093;

		private GroupBox _0089_008A_0094;

		private Button _0089_008A_0095;

		private ToolTip _0089_008A_0096;

		private TextBox _0089_008A_0097;

		private Label _0089_008A_0098;

		private GroupBox _0089_008A_0099;

		private Button _0089_008A_009A;

		private Button _0089_008A_009B;

		private TextBox _0089_008A_009C;

		private Label _0089_008A_009D;

		private _008F_0098 _0089_008A_009E;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_008E()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0089_0089_0092(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0089_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0089_0094(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0089_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0089_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0089_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0089_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0089_0099(TextBox P_0, Button P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0089_0089_009A(_008B_009E P_0, Database P_1, CheckBox P_2, CheckBox P_3, CheckBox P_4, CheckBox P_5, CheckBox P_6, CheckBox P_7, _008C_0099 P_8, string P_9 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0089_0089_009B(List<List<_008F_008E>> P_0, Database P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0089_009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_008E()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554518)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0095()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0096()
		{
			return true;
		}
	}
}
namespace _008B_0091
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008B_0090 : Form
	{
		public _008E_009B _0089_008B_008E;

		public _008F_0086 _0089_008B_008F;

		private IContainer _0089_008B_0090;

		private GroupBox _0089_008B_0091;

		private Label _0089_008B_0092;

		private Label _0089_008B_0093;

		private TextBox _0089_008B_0094;

		private TextBox _0089_008B_0095;

		private Label _0089_008B_0096;

		private TextBox _0089_008B_0097;

		private Label _0089_008B_0098;

		private CheckBox _0089_008B_0099;

		private CheckBox _0089_008B_009A;

		private CheckBox _0089_008B_009B;

		private CheckBox _0089_008B_009C;

		private CheckBox _0089_008B_009D;

		private Button _0089_008B_009E;

		private Button _0089_008C_0086;

		private TextBox _0089_008C_0087;

		private Label _0089_008C_0088;

		private _008F_0098 _0089_008C_0089;

		private GroupBox _0089_008C_008A;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_0090()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0089_008B_0086(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008B_0087(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008B_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008B_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008B_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0089_008B_008B(_008B_009E P_0, Database P_1, CheckBox P_2, CheckBox P_3, CheckBox P_4, CheckBox P_5, CheckBox P_6, _008C_0099 P_7, string P_8 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0089_008B_008C(List<List<_008F_008E>> P_0, Database P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008B_008D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_0090()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554520)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0097()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0098()
		{
			return true;
		}
	}
}
namespace _008B_0093
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008B_0092 : Form
	{
		private IContainer _0089_008C_008D;

		private GroupBox _0089_008C_008E;

		private TextBox _0089_008C_008F;

		private TextBox _0089_008C_0090;

		private Button _0089_008C_0091;

		private Label _0089_008C_0092;

		private Label _0089_008C_0093;

		private GroupBox _0089_008C_0094;

		private Button _0089_008C_0095;

		private TextBox _0089_008C_0096;

		private TextBox _0089_008C_0097;

		private Label _0089_008C_0098;

		private Label _0089_008C_0099;

		private ComboBox _0089_008C_009A;

		private TextBox _0089_008C_009B;

		private Label _0089_008C_009C;

		private Label _0089_008C_009D;

		private ComboBox _0089_008C_009E;

		private TextBox _0089_008D_0086;

		private Label _0089_008D_0087;

		private Label _0089_008D_0088;

		private GroupBox _0089_008D_0089;

		private Button _0089_008D_008A;

		private Label _0089_008D_008B;

		private TextBox _0089_008D_008C;

		private TextBox _0089_008D_008D;

		private Label _0089_008D_008E;

		private TextBox _0089_008D_008F;

		private Label _0089_008D_0090;

		private TextBox _0089_008D_0091;

		private TextBox _0089_008D_0092;

		private Label _0089_008D_0093;

		private Label _0089_008D_0094;

		private GroupBox _0089_008D_0095;

		private Button _0089_008D_0096;

		private Label _0089_008D_0097;

		private TextBox _0089_008D_0098;

		private TextBox _0089_008D_0099;

		private Label _0089_008D_009A;

		private TextBox _0089_008D_009B;

		private Label _0089_008D_009C;

		private TextBox _0089_008D_009D;

		private TextBox _0089_008D_009E;

		private Label _0089_008E_0086;

		private Label _0089_008E_0087;

		private PictureBox _0089_008E_0088;

		private GroupBox _0089_008E_0089;

		private GroupBox _0089_008E_008A;

		private Button _0089_008E_008B;

		private TextBox _0089_008E_008C;

		private Label _0089_008E_008D;

		private TextBox _0089_008E_008E;

		private Label _0089_008E_008F;

		private TextBox _0089_008E_0090;

		private Label _0089_008E_0091;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_0092()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008C_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008C_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_0092()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554521)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_0099()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_009A()
		{
			return true;
		}
	}
}
namespace _008B_0095
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008B_0094 : Form
	{
		[Serializable]
		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _0090_0093
		{
			public static readonly _0090_0093 _003C_003E9;

			public static Func<_008A_0089, double> _003C_003E9__26_0;

			public static Func<_008A_0089, double> _003C_003E9__38_0;

			public static Func<_008A_0089, double> _003C_003E9__39_0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0093()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554523)));
				_003C_003E9 = new _0090_0093();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0093()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_009A(_008A_0089 o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_009B(_008A_0089 o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_009C(_008A_0089 o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ah()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ai()
			{
				return true;
			}
		}

		private List<DBPoint> _0089_0091_009D;

		private Dictionary<string, DBPoint> _0089_0091_009E;

		private _008F_008E _0089_0092_0086;

		private _008F_008E _0089_0092_0087;

		private _008F_008E _0089_0092_0088;

		private const double _0089_0092_0089 = 0.539957;

		private const double _0089_0092_008A = 1.852;

		private Point3d _0089_0092_008B;

		private IContainer _0089_0092_008C;

		private Button _0089_0092_008D;

		private Button _0089_0092_008E;

		private DataGridView _0089_0092_008F;

		private TextBox _0089_0092_0090;

		private TextBox _0089_0092_0091;

		private Label _0089_0092_0092;

		private Label _0089_0092_0093;

		private StatusStrip _0089_0092_0094;

		private ToolStripStatusLabel _0089_0092_0095;

		private Button _0089_0092_0096;

		private Button _0089_0092_0097;

		private GroupBox _0089_0092_0098;

		private TextBox _0089_0092_0099;

		private TextBox _0089_0092_009A;

		private TextBox _0089_0092_009B;

		private Label _0089_0092_009C;

		private Label _0089_0092_009D;

		private Label _0089_0092_009E;

		private Button _0089_0093_0086;

		private GroupBox _0089_0093_0087;

		private TextBox _0089_0093_0088;

		private TextBox _0089_0093_0089;

		private Label _0089_0093_008A;

		private TextBox _0089_0093_008B;

		private Label _0089_0093_008C;

		private Label _0089_0093_008D;

		private CheckBox _0089_0093_008E;

		private TabControl _0089_0093_008F;

		private TabPage _0089_0093_0090;

		private TabPage _0089_0093_0091;

		private TabPage _0089_0093_0092;

		private TextBox _0089_0093_0093;

		private ToolTip _0089_0093_0094;

		private Label _0089_0093_0095;

		private TextBox _0089_0093_0096;

		private Label _0089_0093_0097;

		private Label _0089_0093_0098;

		private TextBox _0089_0093_0099;

		private Button _0089_0093_009A;

		private Button _0089_0093_009B;

		private Button _0089_0093_009C;

		private TextBox _0089_0093_009D;

		private TextBox _0089_0093_009E;

		private Label _0089_0094_0086;

		private TextBox _0089_0094_0087;

		private Label _0089_0094_0088;

		private TextBox _0089_0094_0089;

		private TextBox _0089_0094_008A;

		private TextBox _0089_0094_008B;

		private Label _0089_0094_008C;

		private TextBox _0089_0094_008D;

		private Label _0089_0094_008E;

		private TextBox _0089_0094_008F;

		private Button _0089_0094_0090;

		private Label _0089_0094_0091;

		private Label _0089_0094_0092;

		private TextBox _0089_0094_0093;

		private TextBox _0089_0094_0094;

		private TextBox _0089_0094_0095;

		private TextBox _0089_0094_0096;

		private Button _0089_0094_0097;

		private Button _0089_0094_0098;

		private Button _0089_0094_0099;

		private Button _0089_0094_009A;

		private Button _0089_0094_009B;

		private GroupBox _0089_0094_009C;

		private Button _0089_0094_009D;

		private TextBox _0089_0094_009E;

		private TextBox _0089_0095_0086;

		private Label _0089_0095_0087;

		private Label _0089_0095_0088;

		private Label _0089_0095_0089;

		private ComboBox _0089_0095_008A;

		private Button _0089_0095_008B;

		private _0087_008C _0089_0095_008C;

		private _0087_008C _0089_0095_008D;

		private _0087_008C _0089_0095_008E;

		private _0087_008C _0089_0095_008F;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_0094()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _0089_008E_0092(DataGridView P_0)
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0089_008E_0093(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_0095(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_009A(List<DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_009B(List<_008A_0089> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_009C(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_009D(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008E_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008E_0097 _0089_008F_0089()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008E_009B _0089_008F_008A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool _0089_008F_008C(_008E_0097 P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0092()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008E_009B _0089_008F_0094()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0089_008F_0098(Point3d P_0, Point3d P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ShowMessage(string s)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_008F_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0090_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0086(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_008A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_008C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0096(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0091_009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_0094()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554522)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_009B()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_009C()
		{
			return true;
		}
	}
}
namespace _008B_0097
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008B_0096 : Form
	{
		[Serializable]
		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _0090_0094
		{
			public static readonly _0090_0094 _003C_003E9;

			public static Func<_008A_008D, double> _003C_003E9__24_0;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0094()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554525)));
				_003C_003E9 = new _0090_0094();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0094()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal double _008B_008E_009D(_008A_008D o)
			{
				return 0.0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Aj()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ak()
			{
				return true;
			}
		}

		private List<DBPoint> _0089_0097_008B;

		private Dictionary<string, DBPoint> _0089_0097_008C;

		private double[,] _0089_0097_008D;

		private IContainer _0089_0097_008E;

		private StatusStrip _0089_0097_008F;

		private ToolStripStatusLabel _0089_0097_0090;

		private Button _0089_0097_0091;

		private Button _0089_0097_0092;

		private DataGridView _0089_0097_0093;

		private Button _0089_0097_0094;

		private Button _0089_0097_0095;

		private Button _0089_0097_0096;

		private GroupBox _0089_0097_0097;

		private TextBox _0089_0097_0098;

		private TextBox _0089_0097_0099;

		private TextBox _0089_0097_009A;

		private Label _0089_0097_009B;

		private Button _0089_0097_009C;

		private Label _0089_0097_009D;

		private Label _0089_0097_009E;

		private GroupBox _0089_0098_0086;

		private Button _0089_0098_0087;

		private TextBox _0089_0098_0088;

		private TextBox _0089_0098_0089;

		private Label _0089_0098_008A;

		private TextBox _0089_0098_008B;

		private Label _0089_0098_008C;

		private Label _0089_0098_008D;

		private TabControl _0089_0098_008E;

		private TabPage _0089_0098_008F;

		private TabPage _0089_0098_0090;

		private TabPage _0089_0098_0091;

		private TextBox _0089_0098_0092;

		private Label _0089_0098_0093;

		private GroupBox _0089_0098_0094;

		private ComboBox _0089_0098_0095;

		private Label _0089_0098_0096;

		private Label _0089_0098_0097;

		private Label _0089_0098_0098;

		private Label _0089_0098_0099;

		private TextBox _0089_0098_009A;

		private TextBox _0089_0098_009B;

		private TextBox _0089_0098_009C;

		private Label _0089_0098_009D;

		private Label _0089_0098_009E;

		private Label _0089_0099_0086;

		private Button _0089_0099_0087;

		private TextBox _0089_0099_0088;

		private TextBox _0089_0099_0089;

		private TextBox _0089_0099_008A;

		private Label _0089_0099_008B;

		private Label _0089_0099_008C;

		private TextBox _0089_0099_008D;

		private TextBox _0089_0099_008E;

		private Label _0089_0099_008F;

		private TextBox _0089_0099_0090;

		private TextBox _0089_0099_0091;

		private TextBox _0089_0099_0092;

		private TextBox _0089_0099_0093;

		private Label _0089_0099_0094;

		private TextBox _0089_0099_0095;

		private TextBox _0089_0099_0096;

		private TextBox _0089_0099_0097;

		private TextBox _0089_0099_0098;

		private TextBox _0089_0099_0099;

		private TextBox _0089_0099_009A;

		private Label _0089_0099_009B;

		private Button _0089_0099_009C;

		private Button _0089_0099_009D;

		private Button _0089_0099_009E;

		private CheckBox _0089_009A_0086;

		private ToolTip _0089_009A_0087;

		private GroupBox _0089_009A_0088;

		private Label _0089_009A_0089;

		private TextBox _0089_009A_008A;

		private Label _0089_009A_008B;

		private TextBox _0089_009A_008C;

		private Label _0089_009A_008D;

		private TextBox _0089_009A_008E;

		private ComboBox _0089_009A_008F;

		private Label _0089_009A_0090;

		private TextBox _0089_009A_0091;

		private Label _0089_009A_0092;

		private Label _0089_009A_0093;

		private Label _0089_009A_0094;

		private ComboBox _0089_009A_0095;

		private ComboBox _0089_009A_0096;

		private Label _0089_009A_0097;

		private Label _0089_009A_0098;

		private TextBox _0089_009A_0099;

		private ComboBox _0089_009A_009A;

		private Label _0089_009A_009B;

		private TextBox _0089_009A_009C;

		private TextBox _0089_009A_009D;

		private Label _0089_009A_009E;

		private Button _0089_009B_0086;

		private Button _0089_009B_0087;

		private TextBox _0089_009B_0088;

		private Label _0089_009B_0089;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_0096()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _0089_0095_0090(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_0092(object P_0, FormClosedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_0094(List<DBPoint> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private List<_008A_008D> _0089_0095_0095(List<DBPoint> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_0096(List<_008A_008D> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_0097(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_0098(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_0099(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_009A(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_009B(_008C_0095 P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0089_0095_009C()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0089_0095_009D()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0095_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0086(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0087(string[] P_0, TextBox P_1, TextBox P_2, TextBox P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string _0089_0096_0088(TextBox P_0, TextBox P_1, TextBox P_2)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string _0089_0096_008A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_008B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_008C(_008C_0095 P_0, ref _008A_008D P_1, double P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_008F()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0093(object P_0, DataGridViewCellEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0095(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008A_0093 _0089_0096_0096(string P_0, _008A_008F P_1, string P_2, string P_3)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _0089_0096_0097(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0098(ref _008A_0093 P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_0099(ref _008A_0093 P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_009A(_008A_0093 P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_009B(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_009C(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_009D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0096_009E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0097_0086(object P_0, KeyPressEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0097_0087(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0097_0088(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0097_0089(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_0097_008A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_0096()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554524)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_009D()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_009E()
		{
			return true;
		}
	}
}
namespace _008B_0099
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _008B_0098
	{
		public _008F_008E _0089_009B_008A;

		public _008F_008E _0089_009B_008B;

		public _008F_008E _0089_009B_008C;

		public _008F_008E _0089_009B_008D;

		public _008F_008E _0089_009B_008E;

		public _008F_008E _0089_009B_008F;

		private static double _0089_009B_0090;

		private const double _0089_009B_0091 = 1852.0;

		private const double _0089_009B_0092 = 3704.0;

		private const double _0089_009B_0093 = 6911.76;

		private const double _0089_009B_0094 = 13823.52;

		public List<List<_008F_008E>> _0089_009B_0095;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_0098()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_0098(double P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_0098()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554526)));
			_0089_009B_0090 = Math.PI / 12.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088_009F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00880()
		{
			return true;
		}
	}
}
namespace _008B_009B
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _008B_009A
	{
		public _008F_008E _0089_009B_0096;

		public _008F_008E _0089_009B_0097;

		public _008F_008E _0089_009B_0098;

		public _008F_008E _0089_009B_0099;

		public _008F_008E _0089_009B_009A;

		public _008F_008E _0089_009B_009B;

		public _008F_008E _0089_009B_009C;

		private static double _0089_009B_009D;

		public List<List<_008F_008E>> _0089_009B_009E;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_009A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_009A(double P_0, _008F_008E P_1, bool P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_009A()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554527)));
			_0089_009B_009D = Math.PI / 12.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00881()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00882()
		{
			return true;
		}
	}
}
namespace _008B_009D
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008B_009C
	{
		public _008F_008E _0089_009C_0088;

		public _008F_008E _0089_009C_0089;

		public _008F_008E _0089_009C_008A;

		public _008F_008E _0089_009C_008B;

		public _008F_008E _0089_009C_008C;

		public _008F_008E _0089_009C_008D;

		public _008F_008E _0089_009C_008E;

		public _008F_008E _0089_009C_008F;

		public _008F_008E _0089_009C_0090;

		public double _0089_009C_0091;

		public double _0089_009C_0092;

		public double _0089_009C_0093;

		public double _0089_009C_0094;

		private double _0089_009C_0095;

		public List<List<_008F_008E>> _0089_009C_0096;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008B_009C(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6, double P_7)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0089_009C_0086(ref _008A_008B P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008A_008B _0089_009C_0087(_008A_008B P_0, double P_1, double P_2, double P_3, double P_4, double P_5)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_009C()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554528)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00883()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00884()
		{
			return true;
		}
	}
}
namespace _008C_0086
{
	[LicenseProvider(typeof(_0091_008B))]
	public abstract class _008B_009E
	{
		public _008E_009B _0089_009C_0099;

		protected _008C_0099 _0089_009C_009A;

		protected _008C_0099 _0089_009C_009B;

		protected _008C_0099 _0089_009C_009C;

		public double _0089_009C_009D;

		public double _0089_009C_009E;

		public double _0089_009D_0086;

		protected double _0089_009D_0087;

		protected double _0089_009D_0088;

		protected double _0089_009D_0089;

		protected static readonly double _0089_009D_008A;

		protected static readonly double _0089_009D_008B;

		public List<_008F_008E> _0089_009D_008C;

		public List<_008F_008E> _0089_009D_008D;

		public List<_008F_008E> _0089_009D_008E;

		public List<_008F_008E> _0089_009D_008F;

		public List<List<_008F_008E>> _0089_009D_0090;

		public List<_008F_008E> _0089_009D_0091;

		public List<List<_008F_008E>> _0089_009D_0092;

		public _008C_008B _0089_009D_0093;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected double _0089_009C_0097(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected _008C_008B _0089_009C_0098(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2, double P_3, double P_4, double P_5)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected _008B_009E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008B_009E()
		{
			_0090_009B._008B_0090_0088();
			int num = 0;
			if (false)
			{
				goto IL_0014;
			}
			goto IL_007c;
			IL_0014:
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554529)));
			_ = 0;
			int num2;
			if (_00885())
			{
				num2 = 4;
				goto IL_0080;
			}
			num = 3;
			goto IL_007c;
			IL_007c:
			num2 = num;
			goto IL_0080;
			IL_0080:
			switch (num2)
			{
			case 0:
				break;
			default:
				_0089_009D_008B = Math.PI / 180.0;
				num = 5;
				if (_00886())
				{
					goto case 1;
				}
				goto IL_007c;
			case 1:
			case 4:
				_0089_009D_008A = Math.PI / 2.0;
				goto default;
			case 5:
				return;
			}
			goto IL_0014;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00885()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00886()
		{
			return true;
		}
	}
}
namespace _008C_0088
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_0087 : _008B_009E
	{
		private _008F_0086 _0089_009D_009B;

		private _008F_0086 _0089_009D_009C;

		private _008F_008E _0089_009D_009D;

		private _008F_008E _0089_009D_009E;

		private _008F_008E _0089_009E_0086;

		private _008F_008E _0089_009E_0087;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0087(_008E_009B P_0, _008C_0099 P_1, _008C_0099 P_2, _008C_0099 P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_009D_0094()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_009D_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_009D_0096()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0089_009D_0097()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0089_009D_0098(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_009D_0099(bool P_0 = false)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _0089_009D_009A(_008F_008E P_0, double P_1, double P_2, double P_3, double P_4 = Math.PI / 180.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_0087()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554530)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00887()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00888()
		{
			return true;
		}
	}
}
namespace _008C_008A
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _008C_0089 : _008B_009E
	{
		public static double _0089_009E_008E;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0089(_008E_009B P_0, _008C_0099 P_1, _008C_0099 P_2, _008C_0099 P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_009E_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_009E_0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0089_009E_008A(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _0089_009E_008B(_008F_0086 P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_009E_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _0089_009E_008D(_008F_0086 P_0, double P_1, double P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_0089()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554531)));
			_0089_009E_008E = Math.PI / 12.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00889()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088a()
		{
			return true;
		}
	}
}
namespace _008C_008C
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_008B
	{
		public _008F_008E _0089_009E_0091;

		public _008F_008E _0089_009E_0092;

		public double _0089_009E_0093;

		public double _0089_009E_0094;

		public _008F_008E _0089_009E_0095;

		public _008F_008E _0089_009E_0096;

		public double _0089_009E_0097;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal double _0089_009E_008F()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0089_009E_0090(Database P_0, string P_1 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_008B()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554532)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088d()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088e()
		{
			return true;
		}
	}
}
namespace _008C_008E
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_008D
	{
		private readonly List<_008C_008B> _0089_009E_009A;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0089_009E_0098(_008C_008B P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0089_009E_0099(Database P_0, string P_1 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_008D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_008D()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554533)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088f()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088g()
		{
			return true;
		}
	}
}
namespace _008C_0090
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _008C_008F
	{
		public _008F_008E _0089_009E_009D;

		public _008F_008E _0089_009E_009E;

		public _008F_008E _008A_0086_0086;

		public _008F_008E _008A_0086_0087;

		public _008F_008E _008A_0086_0088;

		public _008F_008E _008A_0086_0089;

		private static double _008A_0086_008A;

		private const double _008A_0086_008B = 1852.0;

		private const double _008A_0086_008C = 3704.0;

		private const double _008A_0086_008D = 6911.76;

		private const double _008A_0086_008E = 13823.52;

		public List<List<_008F_008E>> _008A_0086_008F;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_008F(_008F_008E P_0, _008F_008E P_1, double P_2, double P_3, bool P_4)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0089 _0089_009E_009B(_008A_0089 P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _0089_009E_009C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_008F()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554534)));
			_008A_0086_008A = Math.PI / 12.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088h()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088i()
		{
			return true;
		}
	}
}
namespace _008C_0092
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_0091
	{
		public double _008A_0086_0096;

		public double _008A_0086_0097;

		public double _008A_0086_0098;

		public double _008A_0086_0099;

		public double _008A_0086_009A;

		public double _008A_0086_009B;

		public double _008A_0086_009C;

		public double _008A_0086_009D;

		public double _008A_0086_009E;

		public bool _008A_0087_0086;

		private _008F_008E _008A_0087_0087;

		private _008F_008E _008A_0087_0088;

		private _008F_008E _008A_0087_0089;

		private _008F_008E _008A_0087_008A;

		private _008F_008E _008A_0087_008B;

		private _008F_008E _008A_0087_008C;

		private _008F_008E _008A_0087_008D;

		private _008F_008E _008A_0087_008E;

		private _008F_008E _008A_0087_008F;

		private _008F_008E _008A_0087_0090;

		private _008F_008E _008A_0087_0091;

		public List<_008F_008E> _008A_0087_0092;

		public List<_008F_008E> _008A_0087_0093;

		public List<_008F_008E> _008A_0087_0094;

		public List<_008F_008E> _008A_0087_0095;

		public List<_008F_008E> _008A_0087_0096;

		public List<_008F_008E> _008A_0087_0097;

		public List<_008F_008E> _008A_0087_0098;

		public List<List<_008F_008E>> _008A_0087_0099;

		private _008F_008C _008A_0087_009A;

		private _008F_008C _008A_0087_009B;

		private _008E_009B _008A_0087_009C;

		private List<_008F_008E> _008A_0087_009D;

		private List<_008F_008E> _008A_0087_009E;

		private static double _008A_0088_0086;

		private static double _008A_0088_0087;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0091()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0091(_008E_009B P_0, _008F_008E P_1, _008F_008E P_2, _008F_008E P_3, bool P_4 = true, double P_5 = 0.033, double P_6 = 0.033, bool P_7 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_0086_0090(bool P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_0086_0091(_008F_0086 P_0, double P_1, _008F_008E P_2, double P_3, double P_4, ref List<_008F_008E> P_5, ref List<_008F_008E> P_6)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0086_0092(bool P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_0086_0093()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0089 _008A_0086_0094(_008A_0089 P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0086_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_0091()
		{
			_0090_009B._008B_0090_0088();
			_ = 0;
			int num;
			if (_0088j())
			{
				num = 3;
				if (1 == 0)
				{
					goto IL_0020;
				}
			}
			else
			{
				num = 1;
				if (_0088k())
				{
					return;
				}
			}
			goto IL_0086;
			IL_0069:
			_008A_0088_0086 = Math.PI / 12.0;
			goto IL_0020;
			IL_0086:
			switch (num)
			{
			case 0:
			case 3:
				goto IL_003d;
			case 4:
				goto IL_0069;
			case 5:
				return;
			}
			goto IL_0020;
			IL_0020:
			_008A_0088_0087 = Math.PI / 2.0;
			num = 5;
			if (1 == 0)
			{
				goto IL_003d;
			}
			goto IL_0086;
			IL_003d:
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554535)));
			num = 4;
			if (_0088k())
			{
				goto IL_0069;
			}
			goto IL_0086;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088j()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088k()
		{
			return true;
		}
	}
}
namespace _008C_0094
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_0093
	{
		public double _008A_0088_008E;

		public double _008A_0088_008F;

		public double _008A_0088_0090;

		public double _008A_0088_0091;

		public double _008A_0088_0092;

		public double _008A_0088_0093;

		public double _008A_0088_0094;

		public double _008A_0088_0095;

		public double _008A_0088_0096;

		public double _008A_0088_0097;

		private _008F_008E _008A_0088_0098;

		private _008F_008E _008A_0088_0099;

		private _008F_008E _008A_0088_009A;

		private _008F_008E _008A_0088_009B;

		private _008F_008E _008A_0088_009C;

		private _008F_008E _008A_0088_009D;

		private _008F_008E _008A_0088_009E;

		private _008F_008E _008A_0089_0086;

		private _008F_008E _008A_0089_0087;

		private _008F_008E _008A_0089_0088;

		private _008F_008E _008A_0089_0089;

		private _008F_008E _008A_0089_008A;

		public List<_008F_008E> _008A_0089_008B;

		public List<_008F_008E> _008A_0089_008C;

		public List<_008F_008E> _008A_0089_008D;

		public List<_008F_008E> _008A_0089_008E;

		public List<_008F_008E> _008A_0089_008F;

		public List<_008F_008E> _008A_0089_0090;

		public List<_008F_008E> _008A_0089_0091;

		public List<_008F_008E> _008A_0089_0092;

		public List<_008F_008E> _008A_0089_0093;

		public List<_008F_008E> _008A_0089_0094;

		public List<List<_008F_008E>> _008A_0089_0095;

		private _008F_008C _008A_0089_0096;

		private _008F_008C _008A_0089_0097;

		private _008E_009B _008A_0089_0098;

		private double _008A_0089_0099;

		private List<_008F_008E> _008A_0089_009A;

		private List<_008F_008E> _008A_0089_009B;

		private static double _008A_0089_009C;

		private static double _008A_0089_009D;

		private List<_008F_008E> _008A_0089_009E;

		private List<_008F_008E> _008A_008A_0086;

		private List<List<_008F_008E>> _008A_008A_0087;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0093()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0093(_008E_009B P_0, _008F_008E P_1, _008F_008E P_2, _008F_008E P_3, double P_4, bool P_5 = true, double P_6 = 0.033, double P_7 = 0.033)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_0088_0088(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_0088_0089(_008F_0086 P_0, double P_1, _008F_008E P_2, double P_3, double P_4, ref List<_008F_008E> P_5, ref List<_008F_008E> P_6)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0088_008A(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_0088_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008A_0089 _008A_0088_008C(_008A_0089 P_0, bool P_1 = true)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0088_008D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_0093()
		{
			_0090_009B._008B_0090_0088();
			int num = 3;
			while (true)
			{
				int num2;
				switch (num)
				{
				default:
					_008A_0089_009D = Math.PI / 2.0;
					num2 = 5;
					break;
				case 0:
				case 1:
					_008A_0089_009C = Math.PI / 12.0;
					goto default;
				case 3:
					LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554536)));
					_0088m();
					num2 = ((!_0088l()) ? 4 : 0);
					break;
				case 5:
					return;
				}
				num = num2;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088l()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088m()
		{
			return true;
		}
	}
}
namespace _008C_0096
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_0095
	{
		public _008F_008E _008A_008A_0093;

		public _008F_008E _008A_008A_0094;

		public _008F_008E _008A_008A_0095;

		public _008F_008E _008A_008A_0096;

		public _008F_008E _008A_008A_0097;

		public _008F_008E _008A_008A_0098;

		public _008F_008C _008A_008A_0099;

		public _008F_008C _008A_008A_009A;

		public _008F_0092 _008A_008A_009B;

		public _008F_008E _008A_008A_009C;

		public _008F_008E _008A_008A_009D;

		public _008F_008E _008A_008A_009E;

		public _008F_008E _008A_008B_0086;

		public _008F_008E _008A_008B_0087;

		public _008F_008E _008A_008B_0088;

		public _008F_008E _008A_008B_0089;

		public _008F_008E _008A_008B_008A;

		public _008F_008E _008A_008B_008B;

		public _008F_008C _008A_008B_008C;

		public _008F_008C _008A_008B_008D;

		public _008F_008C _008A_008B_008E;

		public _008F_008C _008A_008B_008F;

		public _008F_0092 _008A_008B_0090;

		public _008F_0092 _008A_008B_0091;

		public _008F_0092 _008A_008B_0092;

		public _008F_0092 _008A_008B_0093;

		public int _008A_008B_0094;

		public List<List<_008F_008E>> _008A_008B_0095;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_008A_0088(double P_0 = 0.0, bool P_1 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_008A_0089(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E _008A_008A_008A(ref _008A_008D P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_008A_008B(double P_0 = 0.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_008A_008C()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_008A_008D()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_008A_008E()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_008A_008F()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_008A_0090()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_008A_0091(double P_0 = 10000.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_008A_0092()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_0095()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554537)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088n()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088o()
		{
			return true;
		}
	}
}
namespace _008C_0098
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_0097
	{
		public _008F_008E _008A_008B_009D;

		public _008F_008E _008A_008B_009E;

		public _008F_008E _008A_008C_0086;

		public _008F_008E _008A_008C_0087;

		public _008F_008E _008A_008C_0088;

		public _008F_008E _008A_008C_0089;

		public _008F_008E _008A_008C_008A;

		public _008F_008E _008A_008C_008B;

		public _008F_008E _008A_008C_008C;

		public _008F_008E _008A_008C_008D;

		public _008F_008E _008A_008C_008E;

		public _008F_008E _008A_008C_008F;

		public _008F_008E _008A_008C_0090;

		public double _008A_008C_0091;

		private double _008A_008C_0092;

		private double _008A_008C_0093;

		private double _008A_008C_0094;

		public double _008A_008C_0095;

		private double _008A_008C_0096;

		private double _008A_008C_0097;

		private double _008A_008C_0098;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0097()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0097(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6, double P_7, double P_8, double P_9, string P_10)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_008B_0096(ref _008A_008D P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_008B_0097(ref _008A_008D P_0, _008F_008E P_1, double P_2, _008F_008E P_3, double P_4)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _008A_008B_0098(double P_0, double P_1, double P_2, double P_3, double P_4)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008A_008B_0099(string P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008A_008B_009A(string P_0, double P_1, double P_2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008A_008B_009B(double P_0, double P_1, double P_2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_008B_009C(ref _008A_008D P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_0097()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554538)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088p()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088q()
		{
			return true;
		}
	}
}
namespace _008C_009A
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_0099
	{
		public _008F_008E _008A_008C_009B;

		public string _008A_008C_009C;

		public double _008A_008C_009D;

		public double _008A_008C_009E;

		public double _008A_008D_0086;

		public double _008A_008D_0087;

		public _008F_008C _008A_008D_0088;

		public _008F_008C _008A_008D_0089;

		public _008F_008C _008A_008D_008A;

		public _008F_008C _008A_008D_008B;

		public _008F_008E _008A_008D_008C;

		public _008F_008E _008A_008D_008D;

		public _008F_008E _008A_008D_008E;

		public _008F_008E _008A_008D_008F;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_0099(_008F_008E P_0, double P_1 = 4630.0, string P_2 = "RNAV1")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_008C_0099(double P_0, double P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_008C_009A(double P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_0099()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554539)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088r()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088s()
		{
			return true;
		}
	}
}
namespace _008C_009C
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_009B : Form
	{
		private IContainer _008A_008D_0093;

		private GroupBox _008A_008D_0094;

		private ComboBox _008A_008D_0095;

		private Label _008A_008D_0096;

		private ComboBox _008A_008D_0097;

		private Label _008A_008D_0098;

		private CheckBox _008A_008D_0099;

		private Button _008A_008D_009A;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008C_009B()
		{
		}

		[DllImport("user32.dll", EntryPoint = "SetFocus")]
		public static extern int _008A_008D_0090(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_008D_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_008D_0092()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_009B()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554540)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088t()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088u()
		{
			return true;
		}
	}
}
namespace _008C_009E
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008C_009D
	{
		[Serializable]
		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0095
		{
			public static readonly _0090_0095 _003C_003E9;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0095()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554542)));
				_003C_003E9 = new _0090_0095();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0095()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal string _008B_008E_009E(_008C_009D p)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal string _008B_008F_0086(IGrouping<string, _008C_009D> g)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal _008C_009D[] _008B_008F_0087(IGrouping<string, _008C_009D> g)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal string _008B_008F_0088(_008C_009D p)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Al()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Am()
			{
				return true;
			}
		}

		[CompilerGenerated]
		private readonly string _008A_008F_008A;

		[CompilerGenerated]
		private readonly string _008A_008F_008B;

		[CompilerGenerated]
		private readonly Type _008A_008F_008C;

		[CompilerGenerated]
		private readonly string _008A_008F_008D;

		[CompilerGenerated]
		private readonly double? _008A_008F_008E;

		[CompilerGenerated]
		private readonly double? _008A_008F_008F;

		[CompilerGenerated]
		private readonly object _008A_008F_0090;

		[CompilerGenerated]
		private readonly string _008A_008F_0091;

		[CompilerGenerated]
		private readonly bool _008A_008F_0092;

		[CompilerGenerated]
		private readonly string _008A_008F_0093;

		[CompilerGenerated]
		private static readonly _008C_009D _008A_008F_0094;

		[CompilerGenerated]
		private static readonly _008C_009D _008A_008F_0095;

		[CompilerGenerated]
		private static readonly _008C_009D _008A_008F_0096;

		[CompilerGenerated]
		private static readonly _008C_009D _008A_008F_0097;

		[CompilerGenerated]
		private static readonly _008C_009D _008A_008F_0098;

		[CompilerGenerated]
		private static readonly _008C_009D _008A_008F_0099;

		[CompilerGenerated]
		private static readonly _008C_009D _008A_008F_009A;

		[CompilerGenerated]
		private static readonly _008C_009D _008A_008F_009B;

		private static readonly _008C_009D[] _008A_008F_009C;

		private static readonly Dictionary<string, _008C_009D[]> _008A_008F_009D;

		private static readonly Dictionary<string, _008C_009D> _008A_008F_009E;

		public static _008C_009D Speed
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public static _008C_009D Altitude
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public static _008C_009D BankAngle
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public static _008C_009D Temperature
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public static _008C_009D TreeHeight
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public static _008C_009D WindSpeed
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public static _008C_009D RunwayName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		public static _008C_009D ProcedureName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public string _008A_008E_0087()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public string _008A_008E_0089()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public Type _008A_008E_008B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public string _008A_008E_008D()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double? _008A_008E_008F()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double? _008A_008E_0091()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public object _008A_008E_0093()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public string _008A_008E_0095()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public bool _008A_008E_0097()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public string _008A_008E_0099()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008C_009D(string P_0, string P_1, Type P_2, string P_3 = null, double? P_4 = null, double? P_5 = null, object P_6 = null, string P_7 = null, bool P_8 = false, string P_9 = null)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008C_009D()
		{
			_0090_009B._008B_0090_0088();
			int num = 4;
			while (true)
			{
				int num2 = num;
				while (true)
				{
					int num3;
					switch (num2)
					{
					case 6:
						_008A_008F_009A = new _008C_009D(_0090_009B._008B_008F_009D(6724), _0090_009B._008B_008F_009D(6728), Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(16777226)), null, null, null, _0090_009B._008B_008F_009D(6732), _0090_009B._008B_008F_009D(6736), _0020: false, _0090_009B._008B_008F_009D(6740));
						num = 2;
						break;
					case 10:
						_008A_008F_0098 = new _008C_009D(_0090_009B._008B_008F_009D(6704), _0090_009B._008B_008F_009D(6708), Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(16777259)), _0090_009B._008B_008F_009D(3072), 0.0, 100.0, 15.0, _0090_009B._008B_008F_009D(6712), _0020: false, _0090_009B._008B_008F_009D(6716));
						goto case 3;
					case 3:
					case 5:
						_008A_008F_0099 = new _008C_009D(_0090_009B._008B_008F_009D(5084), _0090_009B._008B_008F_009D(6720), Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(16777259)), _0090_009B._008B_008F_009D(6660), 0.0, 500.0, 97.8, _0090_009B._008B_008F_009D(6720), _0020: false, _0090_009B._008B_008F_009D(6700));
						goto case 6;
					default:
						num2 = 6;
						continue;
					case 1:
					case 9:
						return;
					case 0:
						_008A_008F_0096 = new _008C_009D(_0090_009B._008B_008F_009D(5076), _0090_009B._008B_008F_009D(6672), Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(16777259)), _0090_009B._008B_008F_009D(6676), 0.0, 45.0, 25.0, _0090_009B._008B_008F_009D(6680), _0020: true, _0090_009B._008B_008F_009D(6668));
						num = 8;
						if (!_0088w())
						{
							break;
						}
						goto case 2;
					case 2:
						_008A_008F_009B = new _008C_009D(_0090_009B._008B_008F_009D(6744), _0090_009B._008B_008F_009D(6748), Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(16777226)), null, null, null, "", _0090_009B._008B_008F_009D(6752), _0020: false, _0090_009B._008B_008F_009D(5744));
						num2 = 7;
						continue;
					case 4:
						if (!_0090_009B._008B_008F_009A(1288))
						{
							LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554541)));
							_008A_008F_0094 = new _008C_009D(_0090_009B._008B_008F_009D(6652), _0090_009B._008B_008F_009D(6656), Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(16777259)), _0090_009B._008B_008F_009D(6660), 0.0, 999.0, 380.0, _0090_009B._008B_008F_009D(6664), _0020: true, _0090_009B._008B_008F_009D(6668));
							_008A_008F_0095 = new _008C_009D(_0090_009B._008B_008F_009D(536), _0090_009B._008B_008F_009D(4608), Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(16777259)), _0090_009B._008B_008F_009D(3072), 0.0, 15000.0, 900.0, _0090_009B._008B_008F_009D(1856), _0020: true, _0090_009B._008B_008F_009D(6668));
							num2 = 0;
							continue;
						}
						_ = 0;
						if (!_0088v())
						{
							num = 3;
							if (!_0088w())
							{
								break;
							}
							goto case 3;
						}
						num3 = 9;
						goto IL_0186;
					case 7:
						_008A_008F_009C = new _008C_009D[8] { Speed, Altitude, BankAngle, Temperature, TreeHeight, WindSpeed, RunwayName, ProcedureName };
						num = 11;
						break;
					case 11:
						_008A_008F_009D = (from p in _008A_008F_009C
							group p by (string)null).ToDictionary([MethodImpl(MethodImplOptions.NoInlining)] (IGrouping<string, _008C_009D> g) => (string)null, [MethodImpl(MethodImplOptions.NoInlining)] (IGrouping<string, _008C_009D> g) => (_008C_009D[])null);
						_008A_008F_009E = _008A_008F_009C.ToDictionary([MethodImpl(MethodImplOptions.NoInlining)] (_008C_009D p) => (string)null);
						num2 = 12;
						continue;
					case 8:
						_008A_008F_0097 = new _008C_009D(_0090_009B._008B_008F_009D(6684), _0090_009B._008B_008F_009D(6688), Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(16777259)), _0090_009B._008B_008F_009D(6692), -60.0, 60.0, 15.0, _0090_009B._008B_008F_009D(6696), _0020: false, _0090_009B._008B_008F_009D(6700));
						num3 = 10;
						goto IL_0186;
					case 12:
						return;
						IL_0186:
						num = num3;
						break;
					}
					break;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_008D_009B(object P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static IEnumerable<_008C_009D> _008A_008D_009C()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008C_009D _008A_008D_009D(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static IEnumerable<_008C_009D> _008A_008D_009E(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static IEnumerable<string> _008A_008E_0086()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088v()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088w()
		{
			return true;
		}
	}
}
namespace _008D_0087
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008D_0086
	{
		[CompilerGenerated]
		private Dictionary<string, object> _008A_0090_008B;

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public Dictionary<string, object> _008A_0090_0088()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _008A_0090_0089(Dictionary<string, object> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0090_0086(_008C_009D P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0090_0087(_008E_008D P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008D_0086()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_0086()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554543)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088x()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088y()
		{
			return true;
		}
	}
}
namespace _008D_0089
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _008D_0088
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_0090_008C(Transaction P_0, Database P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_0090_008D(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_0088()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554544)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088z()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0086()
		{
			return true;
		}
	}
}
namespace _008D_008B
{
	[LicenseProvider(typeof(_0091_008B))]
	public enum _008D_008A
	{

	}
}
namespace _008D_008D
{
	[DataContract]
	[LicenseProvider(typeof(_0091_008B))]
	public class _008D_008C : INotifyPropertyChanged
	{
		[CompilerGenerated]
		private PropertyChangedEventHandler _008A_0091_009D;

		[CompilerGenerated]
		private _008D_008A _008A_0091_009E;

		[CompilerGenerated]
		private double _008A_0092_0086;

		[CompilerGenerated]
		private double _008A_0092_0087;

		[CompilerGenerated]
		private double _008A_0092_0088;

		[CompilerGenerated]
		private double _008A_0092_0089;

		[CompilerGenerated]
		private double _008A_0092_008A;

		[CompilerGenerated]
		private string _008A_0092_008B;

		[CompilerGenerated]
		private _008D_008E _008A_0092_008C;

		[CompilerGenerated]
		private DateTime _008A_0092_008D;

		[CompilerGenerated]
		private string _008A_0092_008E;

		[DisplayName("线条类型")]
		[Category("基础信息")]
		[DataMember]
		public _008D_008A _008A_0090_0098
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return (_008D_008A)(object)null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("类型名称")]
		public string _008A_0090_009A
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[Category("位置信息")]
		[DisplayName("中心点X")]
		[DataMember]
		public double _008A_0090_009D
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[Category("位置信息")]
		[DisplayName("中心点Y")]
		[DataMember]
		public double _008A_0091_0087
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("中心点Z")]
		[Category("位置信息")]
		public double _008A_0091_008A
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("方向角度")]
		[Category("位置信息")]
		[DataMember]
		public double _008A_0091_008D
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("线条长度")]
		[DataMember]
		public double _008A_0091_0090
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("描述")]
		[DataMember]
		public string _008A_0091_0093
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[Category("计算参数")]
		[DisplayName("计算参数")]
		[DataMember]
		public _008D_008E _008A_0091_0096
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("创建时间")]
		public DateTime _008A_0091_0099
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return (DateTime)(object)null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("创建者")]
		public string _008A_0091_009C
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			add
			{
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			remove
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0090_008E(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string _008A_0090_008F()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0090_0090(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ResultBuffer _008A_0090_0091()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0090_0092(ResultBuffer P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0090_0093(Entity P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0090_0094(ObjectId P_0, Database P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0090_0095(Entity P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008D_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_008C()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554546)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0089()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_008A()
		{
			return true;
		}
	}
}
namespace _008D_008F
{
	[LicenseProvider(typeof(_0091_008B))]
	[DataContract]
	public class _008D_008E : INotifyPropertyChanged
	{
		[CompilerGenerated]
		private PropertyChangedEventHandler _008A_0095_0095;

		[CompilerGenerated]
		private double _008A_0095_0096;

		[CompilerGenerated]
		private double _008A_0095_0097;

		[CompilerGenerated]
		private double _008A_0095_0098;

		[CompilerGenerated]
		private double _008A_0095_0099;

		[CompilerGenerated]
		private double _008A_0095_009A;

		[CompilerGenerated]
		private double _008A_0095_009B;

		[CompilerGenerated]
		private double _008A_0095_009C;

		[CompilerGenerated]
		private double _008A_0095_009D;

		[CompilerGenerated]
		private double _008A_0095_009E;

		[CompilerGenerated]
		private double _008A_0096_0086;

		[CompilerGenerated]
		private double _008A_0096_0087;

		[CompilerGenerated]
		private double _008A_0096_0088;

		[CompilerGenerated]
		private double _008A_0096_0089;

		[CompilerGenerated]
		private double _008A_0096_008A;

		[CompilerGenerated]
		private double _008A_0096_008B;

		[CompilerGenerated]
		private double _008A_0096_008C;

		[CompilerGenerated]
		private double _008A_0096_008D;

		[CompilerGenerated]
		private string _008A_0096_008E;

		[CompilerGenerated]
		private double _008A_0096_008F;

		[CompilerGenerated]
		private double _008A_0096_0090;

		[CompilerGenerated]
		private double _008A_0096_0091;

		[CompilerGenerated]
		private double _008A_0096_0092;

		[CompilerGenerated]
		private double _008A_0096_0093;

		[CompilerGenerated]
		private double _008A_0096_0094;

		[CompilerGenerated]
		private double _008A_0096_0095;

		[CompilerGenerated]
		private double _008A_0096_0096;

		[CompilerGenerated]
		private double _008A_0096_0097;

		[CompilerGenerated]
		private double _008A_0096_0098;

		[DataMember]
		[DisplayName("中间段长度")]
		public double _008A_0092_0092
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("FAF高度")]
		public double _008A_0092_0095
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("THR标高")]
		[DataMember]
		public double _008A_0092_0098
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("GP角度")]
		[DataMember]
		public double _008A_0092_009B
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("RDH")]
		[DataMember]
		public double _008A_0092_009E
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("FAF-THR距离")]
		public double _008A_0093_0088
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("TAS")]
		[DataMember]
		public double _008A_0093_008B
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("IAS")]
		[DataMember]
		public double IAS
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("风速")]
		public double WindSpeed
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("高度")]
		[DataMember]
		public double Altitude
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("温度")]
		public double Temperature
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("计时")]
		[DataMember]
		public double _008A_0093_0096
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("计算距离")]
		public double _008A_0093_0099
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("GP角度")]
		public double _008A_0093_009C
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("Xz偏移")]
		public double _008A_0094_0086
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("DH")]
		[DataMember]
		public double _008A_0094_0089
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("标高")]
		public double _008A_0094_008C
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("机型类别")]
		public string _008A_0094_008F
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("HLm")]
		public double _008A_0094_0092
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("HLr")]
		public double _008A_0094_0095
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("HL修正")]
		public double _008A_0094_0098
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DataMember]
		[DisplayName("THR-SOC")]
		public double _008A_0094_009B
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("起始高度")]
		[DataMember]
		public double _008A_0094_009E
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("结束高度")]
		[DataMember]
		public double _008A_0095_0088
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("下降梯度")]
		[DataMember]
		public double _008A_0095_008B
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("距离")]
		[DataMember]
		public double _008A_0095_008E
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("计时时间")]
		[DataMember]
		public double _008A_0095_0091
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[DisplayName("计时距离")]
		[DataMember]
		public double _008A_0095_0094
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			add
			{
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			remove
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0092_008F(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008D_008E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_008E()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554547)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_008B()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_008C()
		{
			return true;
		}
	}
}
namespace _008D_0091
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _008D_0090
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0096_0099(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6, double P_7, double P_8)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0096_009A(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6, double P_7, double P_8, double P_9)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0096_009B(double P_0, double P_1, double P_2, string P_3, double P_4, double P_5, double P_6, double P_7, double P_8, double P_9, double P_10, double P_11)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0096_009C(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0096_009D(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0096_009E(double P_0, double P_1, double P_2, double P_3, double P_4)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_0090()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554548)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_008D()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_008E()
		{
			return true;
		}
	}
}
namespace _008D_0093
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _008D_0092
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008A_0097_0086(this _008D_008C P_0, Line P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static ObjectId _008A_0097_0087(this _008D_008C P_0, Database P_1, Point3d P_2, Point3d P_3)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string _008A_0097_0088(this _008D_008C P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_0092()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554549)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_008F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0090()
		{
			return true;
		}
	}
}
namespace _008D_0095
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008D_0094
	{
		private List<ObjectId> _008A_0097_008D;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0097_0089(ObjectId P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<ObjectId> _008A_0097_008A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0097_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008D_008C _008A_0097_008C(Entity P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008D_0094()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_0094()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554550)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0091()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0092()
		{
			return true;
		}
	}
}
namespace _008D_0097
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008D_0096 : _008E_0087
	{
		private BlockReference _008A_0097_0095;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008D_0096(ObjectId P_0, _008E_008B P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void y_0096()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void y_0097(Entity P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0097_008E(Point3d P_0, double P_1, Scale3d P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override BlockReference y_0098()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0097_008F(Vector3d P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0097_0090(double P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0097_0091(double P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0097_0092()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0097_0093()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string _008A_0097_0094()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_0096()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554551)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0093()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0094()
		{
			return true;
		}
	}
}
namespace _008D_0099
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008D_0098 : _008E_0087
	{
		private Circle _008A_0098_0087;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008D_0098(ObjectId P_0, _008E_008B P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void y_0099<T>(string P_0, T value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override T y_009A<T>(string P_0, T defaultValue = default(T))
		{
			return (T)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override Dictionary<string, object> y_009B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public Point3d _008A_0097_0096()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008A_0097_0097(Point3d P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public double _008A_0097_0099()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008A_0097_009A(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public double _008A_0097_009C()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public double _008A_0097_009E()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_0098()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554552)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0095()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0096()
		{
			return true;
		}
	}
}
namespace _008D_009B
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008D_009A : _008E_0087
	{
		private Line _008A_0098_0090;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008D_009A(ObjectId P_0, _008E_008B P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public Point3d _008A_0098_0088()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008A_0098_0089(Point3d P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public Point3d _008A_0098_008B()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008A_0098_008C(Point3d P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public double _008A_0098_008E()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_009A()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554553)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0097()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0098()
		{
			return true;
		}
	}
}
namespace _008D_009D
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008D_009C : _008E_0087
	{
		private DBPoint _008A_0098_0092;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008D_009C(ObjectId P_0, _008E_008B P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void y_0097(Entity P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0098_0091(Point3d P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_009C()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554554)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_0099()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_009A()
		{
			return true;
		}
	}
}
namespace _008E_0086
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008D_009E : _008E_0087
	{
		private Polyline _008A_0098_009C;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008D_009E(ObjectId P_0, _008E_008B P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public int _008A_0098_0096()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Point3d _008A_0098_0093(int P_0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0098_0094(int P_0, Point2d P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public double _008A_0098_0098()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public bool _008A_0098_009A()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0098_0095(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008D_009E()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554555)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_009B()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_009C()
		{
			return true;
		}
	}
}
namespace _008E_0088
{
	[LicenseProvider(typeof(_0091_008B))]
	public abstract class _008E_0087
	{
		protected ObjectId _008A_0099_0088;

		protected _008E_008D _008A_0099_0089;

		protected _008E_008B _008A_0099_008A;

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected _008E_0087(ObjectId P_0, _008E_008B P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public ObjectId _008A_0099_0086()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (ObjectId)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual _008E_008B y_009C()
		{
			return (_008E_008B)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual _008E_008D y_009D()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0098_009D(Entity P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual void y_009E(_008E_008D P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual bool y_009F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected virtual void y_0097(Entity P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual bool y0()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected virtual void y_0096()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual void y_0099<T>(string P_0, T value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual T y_009A<T>(string P_0, T defaultValue = default(T))
		{
			return (T)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual Dictionary<string, object> y_009B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual bool y1(string P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual void y2()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual void y3()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual void y4()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual Point3d y5()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual double y6()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual Scale3d y7()
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Scale3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual string y8()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Point3d _008A_0098_009E(Entity P_0)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return (Point3d)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual bool y9(Transaction P_0 = null)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public virtual BlockReference y_0098()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_0087()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554556)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_009D()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_009E()
		{
			return true;
		}
	}
}
namespace _008E_008A
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008E_0089
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008E_0087 _008A_0099_008B(ObjectId P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_0089()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554557)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089_009F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00890()
		{
			return true;
		}
	}
}
namespace _008E_008C
{
	[LicenseProvider(typeof(_0091_008B))]
	public enum _008E_008B
	{

	}
}
namespace _008E_008E
{
	[LicenseProvider(typeof(_0091_008B))]
	[DataContract]
	public class _008E_008D : INotifyPropertyChanged
	{
		[CompilerGenerated]
		private PropertyChangedEventHandler _008A_009A_008D;

		[DataMember]
		private string _008A_009A_008E;

		[DataMember]
		private _008E_008F _008A_009A_008F;

		[CompilerGenerated]
		private Dictionary<string, object> _008A_009A_0090;

		[Category("\t基础属性")]
		[DisplayName("\t\t实体名称")]
		public string EntityName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[DisplayName("实体类型")]
		[Category("\t基础属性")]
		public _008E_008F EntityType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (_008E_008F)(object)null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		[DataMember]
		[Category("附加属性")]
		[DisplayName("附加属性")]
		[TypeConverter(typeof(_008E_0091))]
		public Dictionary<string, object> Properties
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			add
			{
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			remove
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0099_008C(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public T _008A_0099_008D<T>(string P_0, T defaultValue = default(T))
		{
			return (T)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_0099_008E<T>(string P_0, T value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0099_008F(string P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string _008A_0099_0090()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008E_008D _008A_0099_0091(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public ResultBuffer _008A_0099_0092()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008E_008D _008A_0099_0093(ResultBuffer P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_008D _008A_0099_0094()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0099_0095(Entity P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_0099_0096(ObjectId P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008E_008D _008A_0099_0097(Entity P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008E_008D _008A_0099_0098(string P_0, string P_1 = "", double P_2 = 1.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static _008E_008F _008A_0099_0099(string P_0)
		{
			return (_008E_008F)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008A_0099_009A(ObjectId P_0, _008E_008D P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008A_0099_009B(Entity P_0, _008E_008D P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008E_008D _008A_0099_009C(ObjectId P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008A_0099_009D(Entity P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008A_0099_009E(Entity P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008A_009A_0086(ObjectId P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_008D()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_008D()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554559)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00893()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00894()
		{
			return true;
		}
	}
}
namespace _008E_0090
{
	[LicenseProvider(typeof(_0091_008B))]
	public enum _008E_008F
	{

	}
}
namespace _008E_0092
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008E_0091 : ExpandableObjectConverter
	{
		private static readonly List<string> _008A_009A_0091;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext P_0, object P_1, Attribute[] P_2)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0091()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_0091()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554561)));
			_008A_009A_0091 = new List<string>
			{
				_0090_009B._008B_008F_009D(6704),
				_0090_009B._008B_008F_009D(6920),
				_0090_009B._008B_008F_009D(6912),
				_0090_009B._008B_008F_009D(6892)
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00897()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00898()
		{
			return true;
		}
	}
}
namespace _008E_0094
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008E_0093 : PropertyDescriptor
	{
		private readonly _008E_008D _008A_009A_0092;

		private readonly Dictionary<string, object> _008A_009A_0093;

		private readonly string _008A_009A_0094;

		private static readonly Dictionary<string, string> _008A_009A_0095;

		public override string DisplayName
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override Type ComponentType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		public override bool IsReadOnly
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return true;
			}
		}

		public override Type PropertyType
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0093(_008E_008D P_0, Dictionary<string, object> P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool CanResetValue(object P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override object GetValue(object P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void ResetValue(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override void SetValue(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override bool ShouldSerializeValue(object P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_0093()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554562)));
			_008A_009A_0095 = new Dictionary<string, string>
			{
				{
					_0090_009B._008B_008F_009D(616),
					_0090_009B._008B_008F_009D(2728)
				},
				{
					_0090_009B._008B_008F_009D(6980),
					_0090_009B._008B_008F_009D(4608)
				},
				{
					_0090_009B._008B_008F_009D(6704),
					_0090_009B._008B_008F_009D(6708)
				},
				{
					_0090_009B._008B_008F_009D(6912),
					_0090_009B._008B_008F_009D(6988)
				},
				{
					_0090_009B._008B_008F_009D(6892),
					_0090_009B._008B_008F_009D(6992)
				}
			};
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _00899()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089a()
		{
			return true;
		}
	}
}
namespace _008E_0096
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008E_0095
	{
		[Serializable]
		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0096
		{
			public static readonly _0090_0096 _003C_003E9;

			public static Func<KeyValuePair<_008E_008F, List<_008E_0087>>, int> _003C_003E9__48_0;

			public static Func<KeyValuePair<_008E_008F, List<_008E_0087>>, _008E_008F> _003C_003E9__48_1;

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0096()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554564)));
				_003C_003E9 = new _0090_0096();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0096()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int _008B_008F_0089(KeyValuePair<_008E_008F, List<_008E_0087>> g)
			{
				return 0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal _008E_008F _008B_008F_008A(KeyValuePair<_008E_008F, List<_008E_0087>> g)
			{
				return (_008E_008F)(object)null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008An()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ao()
			{
				return true;
			}
		}

		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _0090_0097
		{
			public string entityType;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0097()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_008F_008B(_008E_0087 e)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0097()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554565)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ap()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Aq()
			{
				return true;
			}
		}

		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0098
		{
			public string entityName;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0098()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_008F_008C(_008E_0087 e)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0098()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554566)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Ar()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008As()
			{
				return true;
			}
		}

		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0099
		{
			public string entityID;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_0099()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_008F_008D(_008E_0087 e)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_0099()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554567)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008At()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Au()
			{
				return true;
			}
		}

		private static _008E_0095 _008A_009C_0093;

		private readonly string _008A_009C_0094;

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public static _008E_0095 _008A_009C_0091()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008E_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public (List<_008E_0087> entities, Dictionary<int, _008E_0087> dict) _008A_009A_0096()
		{
			return ((List<_008E_0087> entities, Dictionary<int, _008E_0087> dict))null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008E_0087 _008A_009A_0097(ObjectId P_0, Entity P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool _008A_009A_0098(_008E_0087 P_0, Entity P_1, ref int P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0087 _008A_009A_0099(ObjectId P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0087 _008A_009A_009A(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009A_009B(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009A_009C(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009A_009D(_008D_0086 P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009A_009E(_008E_0087 P_0, List<_008E_0087> P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009B_0086(int P_0, Dictionary<int, _008E_0087> P_1, List<_008E_0087> P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009B_0087(List<_008E_0087> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009B_0088()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009B_0089(bool P_0, bool P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009B_008A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009B_008B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009B_008C(Point3d P_0, Point3d P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009B_008D(string P_0, object P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0087 _008A_009B_008E(string P_0, Point3d P_1, _008E_008D P_2, string P_3 = "0", double P_4 = 0.0, Scale3d? P_5 = null)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0087 _008A_009B_008F(Point3d P_0, _008E_008D P_1, string P_2 = "0")
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0087 _008A_009B_0090(ObjectId P_0, Point3d P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009B_0091(_008E_0087 P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009B_0092(List<_008E_0087> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009B_0093(List<_008E_0087> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009B_0094(List<_008E_0087> P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_009B_0095(List<_008E_0087> P_0, Action<_008E_0087> P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int _008A_009B_0096(List<_008E_0087> P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Dictionary<string, int> _008A_009B_0097()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009B_0098()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0087 _008A_009B_0099()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009B_009A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009B_009B(Point3d P_0, Point3d P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008A_009B_009C(ObjectId P_0, _008E_0097 P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_008D _008A_009B_009D(ObjectId P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_008D> _008A_009B_009E()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private _008F_008E _008A_009C_0086(BlockReference P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_008F _008A_009C_0087(_008E_0087 P_0)
		{
			return (_008E_008F)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string _008A_009C_0088(_008E_008F P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Dictionary<_008E_008F, List<_008E_0087>> _008A_009C_0089()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008E_0087> _008A_009C_008A(_008E_008F P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool _008A_009C_008B(_008E_0087 P_0, Point3d P_1, Point3d P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Dictionary<_008E_008F, List<_008E_0087>> _008A_009C_008C(Point3d P_0, Point3d P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008A_009C_008D(_008E_0087 P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Dictionary<_008E_008F, List<_008E_0087>> _008A_009C_008E(double P_0, double P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public string _008A_009C_008F()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009C_0090(_008E_0087 P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_0095()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554563)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089b()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089c()
		{
			return true;
		}
	}
}
namespace _008E_0098
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008E_0097 : _008F_008E
	{
		public double _008A_009D_0088;

		public double _008A_009D_0089;

		public double _008A_009D_008A;

		[CompilerGenerated]
		private double _008A_009D_008B;

		[CompilerGenerated]
		private double _008A_009D_008C;

		[CompilerGenerated]
		private double _008A_009D_008D;

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _008A_009C_0098()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _008A_009C_0099(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _008A_009C_009B()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _008A_009C_009C(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _008A_009C_009E()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _008A_009D_0086(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0097(string P_0, double P_1, double P_2, double P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0097(string P_0, double P_1, double P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_0097()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string _008A_009C_0095(List<_008E_0097> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008A_009C_0096(List<_008E_0097> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008E_0097> _008A_009C_0097(List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_0097()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554568)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089d()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089e()
		{
			return true;
		}
	}
}
namespace _008E_009A
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008E_0099
	{
		public string _008A_009D_0090;

		public string _008A_009D_0091;

		public string _008A_009D_0092;

		private static _008E_0099 _008A_009D_0093;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008E_0099 _008A_009D_008E()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected _008E_0099()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008A_009D_008F()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_0099()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554569)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089f()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089g()
		{
			return true;
		}
	}
}
namespace _008E_009C
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008E_009B
	{
		public double _008A_009D_0095;

		public double _008A_009D_0096;

		public double _008A_009D_0097;

		public double _008A_009D_0098;

		public double _008A_009D_0099;

		public double _008A_009D_009A;

		private double _008A_009D_009B;

		public double _008A_009D_009C;

		public double _008A_009D_009D;

		public double _008A_009D_009E;

		public double _008A_009E_0086;

		public double _008A_009E_0087;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_009B(double P_0 = 380.0, double P_1 = 600.0, double P_2 = 25.0, double P_3 = 56.0, double P_4 = 15.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<string> _008A_009D_0094()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_009B()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554570)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089h()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089i()
		{
			return true;
		}
	}
}
namespace _008E_009E
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008E_009D
	{
		private double _008A_009E_008C;

		private double _008A_009E_008D;

		private int _008A_009E_008E;

		[CompilerGenerated]
		private double _008A_009E_008F;

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _008A_009E_0089()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _008A_009E_008A(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_009D(double P_0, double P_1, int P_2 = 1, double P_3 = 0.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int _008A_009E_0088(double P_0, double P_1)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008E_009D()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554571)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089j()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089k()
		{
			return true;
		}
	}
}
namespace _008F_0087
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F_0086
	{
		public double _008B_0086_0088;

		private double _008B_0086_0089;

		public _008F_008E _008B_0086_008A;

		public double _008B_0086_008B;

		public double _008B_0086_008C;

		public double _008B_0086_008D;

		public double _008B_0086_008E;

		public double _008B_0086_008F;

		private int _008B_0086_0090;

		public double _008B_0086_0091;

		private static double _008B_0086_0092;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_0086()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_0086(_008E_009B P_0, _008F_008E P_1, double P_2 = 0.0, double P_3 = 0.0, bool P_4 = true)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008A_009E_0090(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_009E_0091(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<List<_008F_008E>> _008A_009E_0092(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0, double P_4 = 5.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E _008A_009E_0093(double P_0, double P_1 = 0.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E _008A_009E_0094(double P_0, double P_1 = 0.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008A_009E_0095(double P_0, double P_1 = 0.0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008A_009E_0096(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008A_009E_0097(double P_0, double P_1 = 0.0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008A_009E_0098(double P_0, double P_1, out double P_2, out double P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008A_009E_0099(_008F_008C P_0, double P_1 = 0.0, bool P_2 = true)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008A_009E_009A(_008F_008C P_0, double P_1, double P_2, double P_3, double P_4 = 0.0, bool P_5 = true)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008A_009E_009B(_008F_008E P_0, double P_1 = 0.0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _008A_009E_009C(double P_0, double P_1, double P_2 = 1.0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008A_009E_009D(_008F_0086 P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008A_009E_009E(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0, bool P_4 = false, bool P_5 = false)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0086_0086(_008F_008E P_0, double P_1 = 0.0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_0086_0087(string P_0, double P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_0086()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554572)));
			_008B_0086_0092 = Math.PI / 2.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089l()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089m()
		{
			return true;
		}
	}
}
namespace _008F_0089
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F_0088
	{
		public double _008B_0087_0087;

		public double _008B_0087_0088;

		public _008F_008E _008B_0087_0089;

		public double _008B_0087_008A;

		public double _008B_0087_008B;

		public double _008B_0087_008C;

		public double _008B_0087_008D;

		public double _008B_0087_008E;

		public double _008B_0087_008F;

		private double _008B_0087_0090;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_0088()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_0088(_008E_009B P_0, _008F_008E P_1, double P_2 = 0.0, double P_3 = 0.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008B_0086_0093(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0, bool P_4 = false, bool P_5 = false)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public List<_008F_008E> _008B_0086_0094(double P_0 = 0.0, double P_1 = Math.PI, double P_2 = 0.0, double P_3 = 1.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E _008B_0086_0095(double P_0, double P_1 = 0.0, bool P_2 = true)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E _008B_0086_0096(double P_0, double P_1 = 0.0, bool P_2 = true)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0086_0097(_008F_008C P_0, double P_1 = 0.0, bool P_2 = true)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0086_0098(_008F_008C P_0, double P_1, double P_2, double P_3, double P_4 = 0.0, bool P_5 = true)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0086_0099(_008F_008E P_0, double P_1 = 0.0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private double _008B_0086_009A(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0086_009B(double P_0, double P_1 = 0.0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0086_009C(double P_0, double P_1 = 0.0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0086_009D(_008F_0088 P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_0086_009E(_008F_0088 P_0, _008F_0088 P_1, double P_2, double P_3, double P_4 = 0.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0087_0086(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_0088()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554573)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089n()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089o()
		{
			return true;
		}
	}
}
namespace _008F_008B
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F_008A
	{
		[LicenseProvider(typeof(_0091_008B))]
		public struct _0090_009A
		{
			public TextBox _008B_008F_008E;

			public string _008B_008F_008F;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0090_009A(TextBox P_0, string P_1)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0090_009A()
			{
				_0090_009B._008B_0090_0088();
				LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554575)));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Av()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008Aw()
			{
				return true;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_0091(double P_0, int P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_0087_0092(List<_008F_008E> P_0, double P_1, bool P_2 = true, double P_3 = Math.PI / 180.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_0087_0093(_008F_008E P_0, double P_1, double P_2, double P_3, bool P_4 = true, double P_5 = Math.PI / 180.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008B_0087_0094(ref List<List<_008F_008E>> P_0, _008F_008E P_1, _008F_008E P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_0095(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_0096(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_0097(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008B_0087_0098(double P_0, double P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_0099(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_009A(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_009B(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_009C(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_009D(string P_0, string P_1 = "输入数据有误，请检查。")
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0087_009E(TextBox P_0, string P_1 = "输入数据有误，请检查。")
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008B_0088_0086(TextBox P_0, string P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008B_0088_0087(TextBox P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0088_0088(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_0088_0089(List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int _008B_0088_008A(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008B_0088_008B(List<_008F_008E> P_0, _008F_008E P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008A()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_008A()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554574)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089p()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089q()
		{
			return true;
		}
	}
}
namespace _008F_008D
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F_008C
	{
		public double _008B_0088_009B;

		public double _008B_0088_009C;

		public double _008B_0088_009D;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008C(double P_0 = 1.0, double P_1 = 1.0, double P_2 = 1.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0088_008C(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0088_008D(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008B_0088_008E(_008F_008E P_0, _008F_008E P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008B_0088_008F(_008F_008E P_0, double P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0088_0090(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0088_0091(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0088_0092(_008F_008E P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E _008B_0088_0093(_008F_008C P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_0088_0094()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E _008B_0088_0095(_008F_008E P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0088_0096(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008B_0088_0097(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static bool _008B_0088_0098(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0088_0099(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0088_009A(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_008C()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554576)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089r()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089s()
		{
			return true;
		}
	}
}
namespace _008F_008F
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F_008E
	{
		[CompilerGenerated]
		private string _008B_008A_0086;

		[CompilerGenerated]
		private string _008B_008A_0087;

		[CompilerGenerated]
		private double _008B_008A_0088;

		[CompilerGenerated]
		private double _008B_008A_0089;

		[CompilerGenerated]
		private double _008B_008A_008A;

		[CompilerGenerated]
		private double _008B_008A_008B;

		public string ID
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		public string Name
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		public double X
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		public double Y
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		public double Z
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public double _008B_0089_009C()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		[CompilerGenerated]
		public void _008B_0089_009D(double P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008E(double P_0, double P_1, double P_2 = 0.0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0088_009E(_008F_008E P_0, _008F_008E P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static double _008B_0089_0086(_008F_008E P_0, _008F_008E P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_0087(double P_0, double P_1, double P_2 = 0.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_0088(_008F_008E P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_0089(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_008A(_008F_008E P_0, params _008F_008E[] pts)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_008B(_008F_008E P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_008C(_008F_008E P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_008D(_008F_008E P_0, _008F_008E P_1, double P_2)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_008E(_008F_008E P_0, double P_1 = 0.0, double P_2 = 0.0, double P_3 = 0.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_008F(_008F_008E P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_0090(_008F_008E P_0, double P_1 = 1.0, double P_2 = 1.0, double P_3 = 1.0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E _008B_0089_0091(_008F_008E P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_0096 operator -(_008F_008E P_0, _008F_008E P_1)
		{
			return (_008F_0096)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_008E operator +(_008F_008E P_0, _008F_0096 P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_008E()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554577)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089t()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089u()
		{
			return true;
		}
	}
}
namespace _008F_0091
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F_0090
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_008C(List<_008F_008E> P_0, double P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_008D(List<List<_008F_008E>> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_008E(List<_008F_008E> P_0, List<_008F_008E> P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<List<_008F_008E>> _008B_008A_008F(_008F_008E P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_0090(_008F_008E P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_0091(_008F_008E P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_0092(_008F_008E P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_0093(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<List<_008F_008E>> _008B_008A_0094(List<List<_008F_008E>> P_0, _008F_008E P_1, double P_2)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_0095(List<_008F_008E> P_0, _008F_008E P_1, double P_2)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<List<_008F_008E>> _008B_008A_0096(List<List<_008F_008E>> P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_0097(List<_008F_008E> P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_0098(List<_008F_008E> P_0, _008F_008E P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_0099(List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<List<_008F_008E>> _008B_008A_009A(List<List<_008F_008E>> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<List<_008F_008E>> _008B_008A_009B(List<List<_008F_008E>> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_009C(List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<_008F_008E> _008B_008A_009D(_008F_008E P_0, _008F_008E P_1, int P_2 = 10)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static List<List<_008F_008E>> _008B_008A_009E(List<_008F_008E> P_0, List<_008F_008E> P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008B_008B_0086(ref List<List<_008F_008E>> P_0, List<List<_008F_008E>> P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008B_008B_0087(ref List<_008F_008E> P_0, List<_008F_008E> P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string _008B_008B_0088(List<List<_008F_008E>> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static string _008B_008B_0089(List<_008F_008E> P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_0090()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_0090()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554578)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089v()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089w()
		{
			return true;
		}
	}
}
namespace _008F_0093
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F_0092
	{
		public double _008B_008B_0092;

		public double _008B_008B_0093;

		public double _008B_008B_0094;

		public double _008B_008B_0095;

		public string _008B_008B_0096;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_0092(double P_0 = 1.0, double P_1 = 1.0, double P_2 = 1.0, string P_3 = "")
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_008B_008A(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_008B_008B(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_008B_008C(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008C _008B_008B_008D(_008F_0092 P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_008C _008B_008B_008E(double P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008B_008B_008F(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_008B_0090(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_008B_0091(double P_0, double P_1)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override string ToString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_0092()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554579)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089x()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089y()
		{
			return true;
		}
	}
}
namespace _008F_0095
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _008F_0094
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_0094()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_0094()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554580)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0089z()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008A_0086()
		{
			return true;
		}
	}
}
namespace _008F_0097
{
	[LicenseProvider(typeof(_0091_008B))]
	public struct _008F_0096
	{
		[CompilerGenerated]
		private double _008B_008C_0088;

		[CompilerGenerated]
		private double _008B_008C_0089;

		public double X
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		public double Y
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return 0.0;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_0096(double P_0, double P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public double _008B_008B_009D()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public double _008B_008C_0086()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_008B_0097(_008F_0096 P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public double _008B_008B_0098(_008F_0096 P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_0096 operator *(_008F_0096 P_0, double P_1)
		{
			return (_008F_0096)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static _008F_0096 operator *(double P_0, _008F_0096 P_1)
		{
			return (_008F_0096)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_0096()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554581)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008A_0087()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008A_0088()
		{
			return true;
		}
	}
}
namespace _008F_0099
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F_0098 : GroupBox
	{
		private const double _008B_008D_0087 = 0.539957;

		private const double _008B_008D_0088 = 1.852;

		[CompilerGenerated]
		private EventHandler _008B_008D_0089;

		private IContainer _008B_008D_008A;

		private _0087_008C _008B_008D_008B;

		private _0087_008C _008B_008D_008C;

		public Button _008B_008D_008D;

		public TextBox _008B_008D_008E;

		public TextBox _008B_008D_008F;

		private Label _008B_008D_0090;

		public TextBox _008B_008D_0091;

		private Label _008B_008D_0092;

		public TextBox _008B_008D_0093;

		public TextBox _008B_008D_0094;

		private Label _008B_008D_0095;

		public event EventHandler _008B_008D_0086
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			add
			{
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			remove
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008F_0098()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _008E_009B _008B_008C_008A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008B_008C_008B(_008E_009B P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void _008B_008C_008C()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public bool _008B_008C_0096()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008B_008C_0097(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public bool _008B_008C_0099()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		public void _008B_008C_009A(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_008C_008D(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_008C_008E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_008C_008F(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_008C_0090(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_008C_0091(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_008C_0092(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_008C_0093(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_008C_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected virtual void yi(EventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void Dispose(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_008C_0095()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _008F_0098()
		{
			_0090_009B._008B_0090_0088();
			LicenseManager.Validate(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554582)));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008A_0089()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008A_008A()
		{
			return true;
		}
	}
}
namespace _0090_009C
{
	internal class _0090_009B
	{
		internal class _0090_009D : Attribute
		{
			internal class _0090_009E<T>
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				public _0090_009E()
				{
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool _008B_0091()
				{
					return true;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool _008B_0092()
				{
					return true;
				}

				static _0090_009E()
				{
					_0090_009B._008B_0090_0088();
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[_0090_009D(typeof(_0090_009E<object>[]))]
			public _0090_009D(object P_0)
			{
			}

			static _0090_009D()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		[Flags]
		private enum _0091_0086
		{

		}

		private static uint[] _008B_0090_009D;

		private static byte[] _008B_0091_0088;

		private static byte[] _008B_0091_0089;

		private static byte[] _008B_0091_008A;

		private static int[] _008B_0091_008E;

		private static object _008B_0091_008D;

		private static bool _008B_0091_0086;

		private static IntPtr _008B_0091_008C;

		private static byte[] _008B_0091_0087;

		private static bool _008B_0091_0092;

		private static long _008B_0091_0090;

		private static int _008B_0091_008F;

		private static bool _008B_0090_009E;

		private static int _008B_0091_0091;

		private static IntPtr _008B_0091_008B;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0090_009B()
		{
			_008B_0090_009D = new uint[64]
			{
				3614090360u, 3905402710u, 606105819u, 3250441966u, 4118548399u, 1200080426u, 2821735955u, 4249261313u, 1770035416u, 2336552879u,
				4294925233u, 2304563134u, 1804603682u, 4254626195u, 2792965006u, 1236535329u, 4129170786u, 3225465664u, 643717713u, 3921069994u,
				3593408605u, 38016083u, 3634488961u, 3889429448u, 568446438u, 3275163606u, 4107603335u, 1163531501u, 2850285829u, 4243563512u,
				1735328473u, 2368359562u, 4294588738u, 2272392833u, 1839030562u, 4259657740u, 2763975236u, 1272893353u, 4139469664u, 3200236656u,
				681279174u, 3936430074u, 3572445317u, 76029189u, 3654602809u, 3873151461u, 530742520u, 3299628645u, 4096336452u, 1126891415u,
				2878612391u, 4237533241u, 1700485571u, 2399980690u, 4293915773u, 2240044497u, 1873313359u, 4264355552u, 2734768916u, 1309151649u,
				4149444226u, 3174756917u, 718787259u, 3951481745u
			};
			_008B_0090_009E = false;
			_008B_0091_0086 = false;
			_008B_0091_0087 = new byte[0];
			_008B_0091_0088 = new byte[0];
			_008B_0091_0089 = new byte[0];
			_008B_0091_008A = new byte[0];
			_008B_0091_008B = IntPtr.Zero;
			_008B_0091_008C = IntPtr.Zero;
			_008B_0091_008D = new string[0];
			_008B_0091_008E = new int[0];
			_008B_0091_008F = 1;
			_008B_0091_0090 = 0L;
			_008B_0091_0091 = 0;
			_008B_0091_0092 = false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void leHifFIJCLsZtKEFfM1i()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] _008B_008F_0090(byte[] P_0)
		{
			uint[] array = new uint[16];
			int num = 448 - P_0.Length * 8 % 512;
			uint num2 = (uint)((num + 512) % 512);
			if (num2 == 0)
			{
				num2 = 512u;
			}
			uint num3 = (uint)(P_0.Length + num2 / 8 + 8);
			ulong num4 = (ulong)P_0.Length * 8uL;
			byte[] array2 = new byte[num3];
			for (int i = 0; i < P_0.Length; i++)
			{
				array2[i] = P_0[i];
			}
			array2[P_0.Length] |= 128;
			for (int num5 = 8; num5 > 0; num5--)
			{
				array2[num3 - num5] = (byte)((num4 >> (8 - num5) * 8) & 0xFF);
			}
			uint num6 = (uint)(array2.Length * 8) / 32u;
			uint num7 = 1732584193u;
			uint num8 = 4023233417u;
			uint num9 = 2562383102u;
			uint num10 = 271733878u;
			for (uint num11 = 0u; num11 < num6 / 16; num11++)
			{
				uint num12 = num11 << 6;
				for (uint num13 = 0u; num13 < 61; num13 += 4)
				{
					array[num13 >> 2] = (uint)((array2[num12 + (num13 + 3)] << 24) | (array2[num12 + (num13 + 2)] << 16) | (array2[num12 + (num13 + 1)] << 8) | array2[num12 + num13]);
				}
				uint num14 = num7;
				uint num15 = num8;
				uint num16 = num9;
				uint num17 = num10;
				_008B_008F_0091(ref num7, num8, num9, num10, 0u, 7, 1u, array);
				_008B_008F_0091(ref num10, num7, num8, num9, 1u, 12, 2u, array);
				_008B_008F_0091(ref num9, num10, num7, num8, 2u, 17, 3u, array);
				_008B_008F_0091(ref num8, num9, num10, num7, 3u, 22, 4u, array);
				_008B_008F_0091(ref num7, num8, num9, num10, 4u, 7, 5u, array);
				_008B_008F_0091(ref num10, num7, num8, num9, 5u, 12, 6u, array);
				_008B_008F_0091(ref num9, num10, num7, num8, 6u, 17, 7u, array);
				_008B_008F_0091(ref num8, num9, num10, num7, 7u, 22, 8u, array);
				_008B_008F_0091(ref num7, num8, num9, num10, 8u, 7, 9u, array);
				_008B_008F_0091(ref num10, num7, num8, num9, 9u, 12, 10u, array);
				_008B_008F_0091(ref num9, num10, num7, num8, 10u, 17, 11u, array);
				_008B_008F_0091(ref num8, num9, num10, num7, 11u, 22, 12u, array);
				_008B_008F_0091(ref num7, num8, num9, num10, 12u, 7, 13u, array);
				_008B_008F_0091(ref num10, num7, num8, num9, 13u, 12, 14u, array);
				_008B_008F_0091(ref num9, num10, num7, num8, 14u, 17, 15u, array);
				_008B_008F_0091(ref num8, num9, num10, num7, 15u, 22, 16u, array);
				_008B_008F_0092(ref num7, num8, num9, num10, 1u, 5, 17u, array);
				_008B_008F_0092(ref num10, num7, num8, num9, 6u, 9, 18u, array);
				_008B_008F_0092(ref num9, num10, num7, num8, 11u, 14, 19u, array);
				_008B_008F_0092(ref num8, num9, num10, num7, 0u, 20, 20u, array);
				_008B_008F_0092(ref num7, num8, num9, num10, 5u, 5, 21u, array);
				_008B_008F_0092(ref num10, num7, num8, num9, 10u, 9, 22u, array);
				_008B_008F_0092(ref num9, num10, num7, num8, 15u, 14, 23u, array);
				_008B_008F_0092(ref num8, num9, num10, num7, 4u, 20, 24u, array);
				_008B_008F_0092(ref num7, num8, num9, num10, 9u, 5, 25u, array);
				_008B_008F_0092(ref num10, num7, num8, num9, 14u, 9, 26u, array);
				_008B_008F_0092(ref num9, num10, num7, num8, 3u, 14, 27u, array);
				_008B_008F_0092(ref num8, num9, num10, num7, 8u, 20, 28u, array);
				_008B_008F_0092(ref num7, num8, num9, num10, 13u, 5, 29u, array);
				_008B_008F_0092(ref num10, num7, num8, num9, 2u, 9, 30u, array);
				_008B_008F_0092(ref num9, num10, num7, num8, 7u, 14, 31u, array);
				_008B_008F_0092(ref num8, num9, num10, num7, 12u, 20, 32u, array);
				_008B_008F_0093(ref num7, num8, num9, num10, 5u, 4, 33u, array);
				_008B_008F_0093(ref num10, num7, num8, num9, 8u, 11, 34u, array);
				_008B_008F_0093(ref num9, num10, num7, num8, 11u, 16, 35u, array);
				_008B_008F_0093(ref num8, num9, num10, num7, 14u, 23, 36u, array);
				_008B_008F_0093(ref num7, num8, num9, num10, 1u, 4, 37u, array);
				_008B_008F_0093(ref num10, num7, num8, num9, 4u, 11, 38u, array);
				_008B_008F_0093(ref num9, num10, num7, num8, 7u, 16, 39u, array);
				_008B_008F_0093(ref num8, num9, num10, num7, 10u, 23, 40u, array);
				_008B_008F_0093(ref num7, num8, num9, num10, 13u, 4, 41u, array);
				_008B_008F_0093(ref num10, num7, num8, num9, 0u, 11, 42u, array);
				_008B_008F_0093(ref num9, num10, num7, num8, 3u, 16, 43u, array);
				_008B_008F_0093(ref num8, num9, num10, num7, 6u, 23, 44u, array);
				_008B_008F_0093(ref num7, num8, num9, num10, 9u, 4, 45u, array);
				_008B_008F_0093(ref num10, num7, num8, num9, 12u, 11, 46u, array);
				_008B_008F_0093(ref num9, num10, num7, num8, 15u, 16, 47u, array);
				_008B_008F_0093(ref num8, num9, num10, num7, 2u, 23, 48u, array);
				_008B_008F_0094(ref num7, num8, num9, num10, 0u, 6, 49u, array);
				_008B_008F_0094(ref num10, num7, num8, num9, 7u, 10, 50u, array);
				_008B_008F_0094(ref num9, num10, num7, num8, 14u, 15, 51u, array);
				_008B_008F_0094(ref num8, num9, num10, num7, 5u, 21, 52u, array);
				_008B_008F_0094(ref num7, num8, num9, num10, 12u, 6, 53u, array);
				_008B_008F_0094(ref num10, num7, num8, num9, 3u, 10, 54u, array);
				_008B_008F_0094(ref num9, num10, num7, num8, 10u, 15, 55u, array);
				_008B_008F_0094(ref num8, num9, num10, num7, 1u, 21, 56u, array);
				_008B_008F_0094(ref num7, num8, num9, num10, 8u, 6, 57u, array);
				_008B_008F_0094(ref num10, num7, num8, num9, 15u, 10, 58u, array);
				_008B_008F_0094(ref num9, num10, num7, num8, 6u, 15, 59u, array);
				_008B_008F_0094(ref num8, num9, num10, num7, 13u, 21, 60u, array);
				_008B_008F_0094(ref num7, num8, num9, num10, 4u, 6, 61u, array);
				_008B_008F_0094(ref num10, num7, num8, num9, 11u, 10, 62u, array);
				_008B_008F_0094(ref num9, num10, num7, num8, 2u, 15, 63u, array);
				_008B_008F_0094(ref num8, num9, num10, num7, 9u, 21, 64u, array);
				num7 += num14;
				num8 += num15;
				num9 += num16;
				num10 += num17;
			}
			byte[] array3 = new byte[16];
			Array.Copy(BitConverter.GetBytes(num7), 0, array3, 0, 4);
			Array.Copy(BitConverter.GetBytes(num8), 0, array3, 4, 4);
			Array.Copy(BitConverter.GetBytes(num9), 0, array3, 8, 4);
			Array.Copy(BitConverter.GetBytes(num10), 0, array3, 12, 4);
			return array3;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_008F_0091(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
		{
			P_0 = P_1 + _008B_008F_0095(P_0 + ((P_1 & P_2) | (~P_1 & P_3)) + P_7[P_4] + _008B_0090_009D[P_6 - 1], P_5);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_008F_0092(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
		{
			P_0 = P_1 + _008B_008F_0095(P_0 + ((P_1 & P_3) | (P_2 & ~P_3)) + P_7[P_4] + _008B_0090_009D[P_6 - 1], P_5);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_008F_0093(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
		{
			P_0 = P_1 + _008B_008F_0095(P_0 + (P_1 ^ P_2 ^ P_3) + P_7[P_4] + _008B_0090_009D[P_6 - 1], P_5);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_008F_0094(ref uint P_0, uint P_1, uint P_2, uint P_3, uint P_4, ushort P_5, uint P_6, uint[] P_7)
		{
			P_0 = P_1 + _008B_008F_0095(P_0 + (P_2 ^ (P_1 | ~P_3)) + P_7[P_4] + _008B_0090_009D[P_6 - 1], P_5);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static uint _008B_008F_0095(uint P_0, ushort P_1)
		{
			return (P_0 >> 32 - P_1) | (P_0 << (int)P_1);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008B_008F_0096()
		{
			if (!_008B_0090_009E)
			{
				_008B_008F_0097();
				_008B_0090_009E = true;
			}
			return _008B_0091_0086;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_008F_0097()
		{
			try
			{
				_008B_0091_0086 = (bool)Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(16777588)).Assembly.GetType("System.Security.Cryptography.CryptoConfig", throwOnError: false).GetMethod("get_AllowOnlyFipsAlgorithms", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[0]);
			}
			catch
			{
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static SymmetricAlgorithm _008B_008F_0098()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (_008B_008F_0096())
			{
				try
				{
					return new AesCryptoServiceProvider();
				}
				catch
				{
					return new RijndaelManaged();
				}
			}
			return new RijndaelManaged();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] _008B_008F_0099(byte[] P_0)
		{
			if (!_008B_008F_0096())
			{
				return new MD5CryptoServiceProvider().ComputeHash(P_0);
			}
			return _008B_008F_0090(P_0);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool _008B_008F_009A(int P_0)
		{
			int num = 138;
			if (_0087())
			{
				goto IL_1cd6;
			}
			goto IL_2a2b;
			IL_1cd6:
			byte[] array3 = default(byte[]);
			byte[] array2 = default(byte[]);
			int num8 = default(int);
			int num9;
			int num10 = default(int);
			byte[] array4 = default(byte[]);
			ICryptoTransform transform = default(ICryptoTransform);
			SymmetricAlgorithm symmetricAlgorithm = default(SymmetricAlgorithm);
			byte[] rgbKey = default(byte[]);
			CryptoStream cryptoStream = default(CryptoStream);
			byte[] publicKeyToken = default(byte[]);
			MemoryStream memoryStream = default(MemoryStream);
			BinaryReader binaryReader = default(BinaryReader);
			byte[] array5 = default(byte[]);
			int num4 = default(int);
			bool result = default(bool);
			while (true)
			{
				IL_1cd6_2:
				int num2 = num;
				while (true)
				{
					switch (num2)
					{
					case 193:
						array3[17] = 234;
						num2 = 329;
						continue;
					case 100:
						array2[1] = (byte)num8;
						num2 = 299;
						continue;
					case 67:
						array2[14] = 128;
						num2 = 126;
						continue;
					case 76:
						array2[15] = 146;
						num = 140;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 338;
					case 338:
						array2[8] = 165;
						num = 146;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 268;
					case 268:
						array2[3] = (byte)num8;
						num9 = 160;
						goto IL_1cd2;
					case 27:
						num8 = 57 - 30;
						num = 279;
						goto IL_1cd6_2;
					case 188:
						array2[9] = (byte)num8;
						num = 80;
						goto IL_1cd6_2;
					case 288:
						array2[1] = (byte)num8;
						num = 278;
						goto IL_1cd6_2;
					case 206:
						array3[19] = (byte)num10;
						num2 = 218;
						continue;
					case 248:
						num8 = 13 + 110;
						num = 324;
						goto IL_1cd6_2;
					case 262:
						array4 = array2;
						num9 = 285;
						goto IL_1cd2;
					case 303:
						num8 = 208 - 69;
						num = 163;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 46;
					case 218:
						array3[19] = 155;
						num9 = 352;
						goto IL_1cd2;
					case 222:
					case 291:
						array3[31] = 108;
						num9 = 252;
						goto IL_1cd2;
					case 114:
						array3[11] = 137;
						num = 14;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 93;
					case 314:
						num10 = 193 - 64;
						num = 125;
						goto IL_1cd6_2;
					case 231:
						num10 = 132 - 16;
						num = 198;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 133;
					case 133:
						array2[11] = 119;
						num = 378;
						goto IL_1cd6_2;
					case 57:
						array2[6] = 203;
						num2 = 275;
						continue;
					case 378:
						array2[11] = 126;
						num2 = 144;
						continue;
					case 191:
						array3[24] = (byte)num10;
						num = 273;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 60;
					case 60:
						array3[6] = 114;
						num2 = 197;
						continue;
					case 75:
						array3[15] = (byte)num10;
						num = 314;
						goto IL_1cd6_2;
					case 1:
						num10 = 194 - 64;
						num2 = 340;
						continue;
					case 56:
						array2[2] = 73;
						num2 = 175;
						continue;
					case 20:
						array3[22] = (byte)num10;
						num9 = 345;
						goto IL_1cd2;
					case 239:
						array3[4] = (byte)num10;
						num = 154;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 81;
					case 81:
						array3[21] = (byte)num10;
						num2 = 21;
						continue;
					case 301:
						array3[16] = (byte)num10;
						num9 = 308;
						goto IL_1cd2;
					case 176:
						num8 = 136 - 80;
						num9 = 132;
						goto IL_1cd2;
					case 237:
						array3[31] = (byte)num10;
						num = 95;
						goto IL_1cd6_2;
					case 315:
						num8 = 124 + 8;
						num2 = 288;
						continue;
					case 364:
						array3[16] = 148;
						num = 165;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 277;
					case 277:
						num8 = 132 - 44;
						num9 = 102;
						goto IL_1cd2;
					case 128:
						array3[12] = 95;
						num2 = 342;
						continue;
					case 321:
						array3[8] = (byte)num10;
						num2 = 283;
						continue;
					case 146:
						array2[8] = 168;
						num9 = 294;
						goto IL_1cd2;
					case 78:
						array3[23] = (byte)num10;
						num9 = 210;
						goto IL_1cd2;
					case 179:
						array3[14] = 201;
						num2 = 186;
						continue;
					case 0:
						array3[7] = (byte)num10;
						num = 108;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 346;
					case 351:
						break;
					case 228:
						array2[12] = 102;
						num2 = 124;
						continue;
					case 369:
						array3[16] = (byte)num10;
						num = 364;
						goto IL_1cd6_2;
					case 250:
						num10 = 143 - 47;
						num = 221;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 370;
					case 252:
						array3[31] = 171;
						num9 = 214;
						goto IL_1cd2;
					case 105:
						num10 = 79 + 28;
						num = 365;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 330;
					case 330:
						num10 = 231 - 77;
						num = 370;
						goto IL_1cd6_2;
					case 354:
						array3[31] = (byte)num10;
						num2 = 101;
						continue;
					case 324:
						array2[13] = (byte)num8;
						num = 86;
						goto IL_1cd6_2;
					case 17:
						array3[10] = (byte)num10;
						num = 105;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 329;
					case 62:
						array3[31] = (byte)num10;
						num2 = 40;
						continue;
					case 41:
						array2[0] = (byte)num8;
						num9 = 94;
						goto IL_1cd2;
					case 45:
						array2[11] = (byte)num8;
						num = 133;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 14;
					case 14:
						num10 = 199 - 66;
						num2 = 311;
						continue;
					case 323:
						array3[20] = 84;
						num = 170;
						goto IL_1cd6_2;
					case 136:
						array3[22] = (byte)num10;
						num2 = 196;
						continue;
					case 357:
						array2[5] = (byte)num8;
						num = 242;
						goto IL_1cd6_2;
					case 219:
						array3[6] = 126;
						num9 = 347;
						goto IL_1cd2;
					case 140:
						num8 = 153 - 51;
						num = 134;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 375;
					case 375:
						array3[0] = (byte)num10;
						num2 = 91;
						continue;
					case 111:
						array2[7] = 153;
						num = 27;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 20;
					case 130:
						num8 = 152 - 50;
						num2 = 302;
						continue;
					case 249:
						num8 = 136 - 45;
						num2 = 263;
						continue;
					case 126:
						num8 = 37 - 8;
						num9 = 158;
						goto IL_1cd2;
					case 4:
						num10 = 104 + 101;
						num2 = 183;
						continue;
					case 276:
						array2[14] = 183;
						num2 = 249;
						continue;
					case 168:
						transform = symmetricAlgorithm.CreateDecryptor(rgbKey, array4);
						num9 = 129;
						goto IL_1cd2;
					case 235:
						num10 = 192 - 64;
						num = 72;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 161;
					case 161:
						num10 = 50 + 62;
						num9 = 233;
						goto IL_1cd2;
					case 335:
						num8 = 172 - 57;
						num2 = 188;
						continue;
					case 360:
						num10 = 111 + 81;
						num2 = 259;
						continue;
					case 3:
						array3[5] = (byte)num10;
						num2 = 182;
						continue;
					case 318:
						array3 = new byte[32];
						num = 52;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 344;
					case 344:
						array3[25] = (byte)num10;
						num = 36;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 372;
					case 372:
						num10 = 8 + 95;
						num = 369;
						goto IL_1cd6_2;
					case 368:
						array3[2] = (byte)num10;
						num = 55;
						goto IL_1cd6_2;
					case 302:
						array2[3] = (byte)num8;
						num9 = 153;
						goto IL_1cd2;
					case 224:
						array3[11] = (byte)num10;
						num2 = 199;
						continue;
					case 117:
						cryptoStream.Close();
						num9 = 98;
						goto IL_1cd2;
					case 2:
						num8 = 49 + 86;
						num2 = 29;
						continue;
					case 221:
						array3[8] = (byte)num10;
						num = 360;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 343;
					case 343:
						array4[11] = publicKeyToken[5];
						num = 73;
						goto IL_1cd6_2;
					case 202:
						num10 = 96 + 115;
						num2 = 300;
						continue;
					case 223:
						array3[28] = (byte)num10;
						num = 269;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 29;
					case 29:
						array2[6] = (byte)num8;
						num9 = 277;
						goto IL_1cd2;
					case 247:
						array2[13] = (byte)num8;
						num2 = 248;
						continue;
					case 342:
						num10 = 238 - 79;
						num9 = 358;
						goto IL_1cd2;
					case 205:
						array2[2] = (byte)num8;
						num9 = 341;
						goto IL_1cd2;
					case 144:
						array2[12] = 93;
						num9 = 326;
						goto IL_1cd2;
					case 190:
						array2[13] = 251;
						num9 = 276;
						goto IL_1cd2;
					case 66:
						array3[28] = 121;
						num = 272;
						goto IL_1cd6_2;
					case 150:
						array3[11] = (byte)num10;
						num9 = 304;
						goto IL_1cd2;
					case 363:
						array3[7] = (byte)num10;
						num = 16;
						goto IL_1cd6_2;
					case 172:
						num10 = 133 + 50;
						num = 363;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 304;
					case 304:
						array3[11] = 153;
						num = 192;
						goto IL_1cd6_2;
					case 22:
						array2[1] = (byte)num8;
						num = 261;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 320;
					case 320:
						array2[1] = (byte)num8;
						num = 9;
						goto IL_1cd6_2;
					case 54:
						array3[3] = 180;
						num = 298;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 84;
					case 84:
						array3[13] = 112;
						num = 367;
						goto IL_1cd6_2;
					case 256:
						array3[3] = 166;
						num2 = 54;
						continue;
					case 74:
						memoryStream.Close();
						num2 = 117;
						continue;
					case 279:
						array2[7] = (byte)num8;
						num9 = 169;
						goto IL_1cd2;
					case 61:
						num8 = 234 - 78;
						num = 24;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 134;
					case 134:
						array2[15] = (byte)num8;
						num2 = 141;
						continue;
					case 89:
						num10 = 52 + 12;
						num = 271;
						goto IL_1cd6_2;
					case 347:
						array3[6] = 139;
						num = 60;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 29;
					case 233:
						array3[9] = (byte)num10;
						num2 = 7;
						continue;
					case 327:
						num8 = 110 + 38;
						num2 = 71;
						continue;
					case 212:
						array2[15] = (byte)num8;
						num2 = 284;
						continue;
					case 167:
						array3[2] = (byte)num10;
						num = 171;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 116;
					case 116:
						binaryReader.BaseStream.Position = 0L;
						num = 152;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 79;
					case 79:
						array3[12] = 210;
						num = 84;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 296;
					case 296:
						num8 = 178 - 77;
						num2 = 156;
						continue;
					case 137:
						_008B_0091_0088 = memoryStream.ToArray();
						num9 = 74;
						goto IL_1cd2;
					case 200:
						num10 = 100 + 72;
						num = 166;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 158;
					case 371:
						num8 = 145 - 48;
						num = 290;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 51;
					case 135:
						num8 = 11 + 83;
						num = 35;
						goto IL_1cd6_2;
					case 290:
						array2[6] = (byte)num8;
						num9 = 57;
						goto IL_1cd2;
					case 95:
						rgbKey = array3;
						num9 = 246;
						goto IL_1cd2;
					case 274:
						array3[18] = (byte)num10;
						num = 178;
						goto IL_1cd6_2;
					case 271:
						array3[30] = (byte)num10;
						num = 235;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 19;
					case 19:
						array3[18] = (byte)num10;
						num = 184;
						goto IL_1cd6_2;
					case 119:
						array3[21] = 133;
						num = 265;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 47;
					case 353:
						num10 = 77 + 51;
						num = 155;
						goto IL_1cd6_2;
					case 273:
						array3[24] = 90;
						num = 53;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 60;
					case 210:
						array3[23] = 116;
						num = 251;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 169;
					case 169:
						array2[8] = 162;
						num = 338;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 129;
					case 7:
						array3[9] = 129;
						num2 = 18;
						continue;
					case 23:
						num10 = 159 + 75;
						num = 321;
						goto IL_1cd6_2;
					case 337:
						array3[5] = (byte)num10;
						num9 = 93;
						goto IL_1cd2;
					case 199:
						num10 = 222 - 74;
						num9 = 150;
						goto IL_1cd2;
					case 229:
						num8 = 149 - 49;
						num = 289;
						goto IL_1cd6_2;
					case 21:
						num10 = 3 + 13;
						num9 = 136;
						goto IL_1cd2;
					case 286:
						array2[0] = (byte)num8;
						num2 = 322;
						continue;
					case 83:
						array4[5] = publicKeyToken[2];
						num2 = 87;
						continue;
					case 328:
						num10 = 181 - 60;
						num9 = 232;
						goto IL_1cd2;
					case 156:
						array2[9] = (byte)num8;
						num2 = 355;
						continue;
					case 40:
						num10 = 131 + 49;
						num2 = 237;
						continue;
					case 209:
						num8 = 129 + 49;
						num9 = 268;
						goto IL_1cd2;
					case 244:
						array3[10] = (byte)num10;
						num = 88;
						goto IL_1cd6_2;
					case 37:
						array3[21] = 105;
						num = 119;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 215;
					case 211:
						array3[17] = 204;
						num2 = 193;
						continue;
					case 251:
						num10 = 222 + 13;
						num2 = 373;
						continue;
					case 90:
						array3[18] = (byte)num10;
						num = 255;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 201;
					case 201:
						num8 = 18 + 50;
						num = 123;
						goto IL_1cd6_2;
					case 204:
						array3[31] = (byte)num10;
						_0087();
						if (!_0088())
						{
							num = 291;
							if (0 == 0)
							{
								goto IL_1cd6_2;
							}
							goto case 312;
						}
						num = 149;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 8;
					case 312:
						array2[8] = (byte)num8;
						num2 = 332;
						continue;
					case 132:
						array2[5] = (byte)num8;
						num = 39;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 317;
					case 317:
						array3[24] = 154;
						num9 = 121;
						goto IL_1cd2;
					case 131:
						num10 = 98 - 49;
						num9 = 81;
						goto IL_1cd2;
					case 52:
						num10 = 17 + 85;
						num2 = 375;
						continue;
					case 236:
						array2[10] = (byte)num8;
						num = 253;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 113;
					case 113:
						num10 = 100 - 30;
						num2 = 164;
						continue;
					case 348:
						num10 = 120 + 14;
						num = 11;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 160;
					case 160:
						array2[4] = 143;
						num = 135;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 143;
					case 143:
						num10 = 234 - 78;
						num = 0;
						goto IL_1cd6_2;
					case 185:
						array3[4] = (byte)num10;
						num9 = 203;
						goto IL_1cd2;
					case 178:
						num10 = 180 - 60;
						num9 = 254;
						goto IL_1cd2;
					case 92:
						array4[3] = publicKeyToken[1];
						num2 = 83;
						continue;
					case 174:
						num8 = 21 + 78;
						num2 = 187;
						continue;
					case 258:
						num10 = 141 - 47;
						num = 195;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 29;
					case 307:
						array3[12] = (byte)num10;
						num9 = 128;
						goto IL_1cd2;
					case 24:
						array2[2] = (byte)num8;
						num2 = 63;
						continue;
					case 373:
						array3[23] = (byte)num10;
						num = 377;
						goto IL_1cd6_2;
					case 261:
						num8 = 65 + 101;
						num2 = 205;
						continue;
					case 124:
						array2[12] = 177;
						num = 13;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 102;
					case 102:
						array2[6] = (byte)num8;
						num = 174;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 272;
					case 272:
						num10 = 193 - 64;
						num9 = 51;
						goto IL_1cd2;
					case 356:
						array3[13] = (byte)num10;
						num = 115;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 104;
					case 336:
						_008B_0091_0087 = _008B_0090_008E(_008B_0090_0089(typeof(_0090_009B).Assembly).ToString());
						num2 = 351;
						continue;
					case 16:
						array3[8] = 143;
						num2 = 68;
						continue;
					case 33:
						array3[17] = (byte)num10;
						num2 = 217;
						continue;
					case 47:
						num10 = 111 + 123;
						num9 = 17;
						goto IL_1cd2;
					case 170:
						num10 = 139 + 24;
						num2 = 215;
						continue;
					case 127:
						array3[29] = 186;
						num2 = 348;
						continue;
					case 374:
						array3[14] = 190;
						num2 = 181;
						continue;
					case 260:
						num8 = 153 - 51;
						num9 = 162;
						goto IL_1cd2;
					case 96:
						array3[25] = 153;
						num2 = 240;
						continue;
					case 253:
						num8 = 71 + 0;
						num9 = 45;
						goto IL_1cd2;
					case 141:
						num8 = 5 + 87;
						num9 = 212;
						goto IL_1cd2;
					case 109:
						if (publicKeyToken == null)
						{
							goto case 207;
						}
						num2 = 245;
						continue;
					case 49:
						num10 = 217 - 72;
						num2 = 224;
						continue;
					case 12:
						array2[2] = 166;
						num2 = 56;
						continue;
					case 325:
						array3[26] = 168;
						num = 4;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 240;
					case 240:
						num10 = 70 + 121;
						num = 344;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 108;
					case 108:
						array3[7] = 121;
						num9 = 257;
						goto IL_1cd2;
					case 53:
						num10 = 152 - 50;
						num9 = 151;
						goto IL_1cd2;
					case 152:
						array5 = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
						num = 318;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 215;
					case 48:
						array3[23] = (byte)num10;
						num = 281;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 125;
					case 125:
						array3[16] = (byte)num10;
						num = 220;
						goto IL_1cd6_2;
					case 230:
						array3[7] = (byte)num10;
						num = 172;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 206;
					case 186:
						array3[15] = 43;
						num9 = 42;
						goto IL_1cd2;
					case 68:
						num10 = 7 + 86;
						num2 = 15;
						continue;
					case 80:
						num8 = 154 - 51;
						num = 25;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 10;
					case 10:
						symmetricAlgorithm.Mode = CipherMode.CBC;
						num = 168;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 183;
					case 183:
						array3[26] = (byte)num10;
						num = 26;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 298;
					case 28:
						array2[2] = (byte)num8;
						num2 = 12;
						continue;
					case 177:
						array3[14] = 102;
						num9 = 180;
						goto IL_1cd2;
					case 246:
						array2 = new byte[16];
						num9 = 216;
						goto IL_1cd2;
					case 36:
						num10 = 63 + 43;
						num2 = 270;
						continue;
					case 264:
						num10 = 98 + 52;
						num2 = 274;
						continue;
					case 213:
						cryptoStream.Write(array5, 0, array5.Length);
						num2 = 30;
						continue;
					case 198:
						array3[0] = (byte)num10;
						num = 339;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 208;
					case 208:
						num10 = 111 + 81;
						num = 33;
						goto IL_1cd6_2;
					case 334:
						array4[15] = publicKeyToken[7];
						num9 = 207;
						goto IL_1cd2;
					case 38:
						array3[26] = 130;
						num = 325;
						goto IL_1cd6_2;
					case 112:
						num10 = 77 + 51;
						num = 34;
						goto IL_1cd6_2;
					case 332:
						array2[9] = 161;
						num = 335;
						goto IL_1cd6_2;
					case 175:
						num8 = 70 + 24;
						num = 333;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 122;
					case 122:
						array3[23] = (byte)num10;
						num = 353;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 111;
					case 298:
						array3[4] = 132;
						num9 = 376;
						goto IL_1cd2;
					case 289:
						array2[4] = (byte)num8;
						num = 110;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 377;
					case 377:
						num10 = 36 + 45;
						num9 = 191;
						goto IL_1cd2;
					case 305:
						num10 = 202 - 67;
						num = 223;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 123;
					case 64:
						array3[28] = (byte)num10;
						num = 66;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 341;
					case 341:
						num8 = 40 + 93;
						num2 = 361;
						continue;
					case 155:
						array3[23] = (byte)num10;
						num9 = 331;
						goto IL_1cd2;
					case 181:
						array3[14] = 106;
						num9 = 179;
						goto IL_1cd2;
					case 11:
						array3[29] = (byte)num10;
						num2 = 89;
						continue;
					case 65:
						num10 = 182 - 60;
						num9 = 350;
						goto IL_1cd2;
					case 142:
						num10 = 134 - 89;
						num = 32;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 204;
					case 285:
						publicKeyToken = typeof(_0090_009B).Assembly.GetName().GetPublicKeyToken();
						num = 109;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 316;
					case 316:
						array3[5] = 42;
						num2 = 280;
						continue;
					case 104:
						num8 = 178 - 59;
						num = 247;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 278;
					case 278:
						array2[1] = 101;
						goto case 149;
					case 8:
						num10 = 43 + 87;
						num = 64;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 263;
					case 263:
						array2[14] = (byte)num8;
						num9 = 67;
						goto IL_1cd2;
					case 293:
						num10 = 152 - 50;
						num = 337;
						goto IL_1cd6_2;
					case 94:
						array2[0] = 168;
						num = 107;
						goto IL_1cd6_2;
					case 97:
						num10 = 226 - 75;
						num = 44;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 284;
					case 284:
						array2[15] = 114;
						num = 327;
						goto IL_1cd6_2;
					case 361:
						array2[2] = (byte)num8;
						num = 61;
						goto IL_1cd6_2;
					case 297:
						array3[8] = (byte)num10;
						num = 250;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 234;
					case 234:
						array2[13] = 160;
						num9 = 190;
						goto IL_1cd2;
					case 58:
						num10 = 54 + 65;
						num2 = 368;
						continue;
					case 165:
						num10 = 79 + 56;
						num = 301;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 32;
					case 32:
						array3[27] = (byte)num10;
						num2 = 305;
						continue;
					case 275:
						num8 = 241 - 80;
						num9 = 59;
						goto IL_1cd2;
					case 217:
						array3[17] = 127;
						num = 211;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 112;
					case 86:
						array2[13] = 104;
						num2 = 234;
						continue;
					case 292:
						num10 = 78 + 22;
						num = 297;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 101;
					case 101:
						num10 = 11 + 105;
						num9 = 204;
						goto IL_1cd2;
					case 5:
						array3[19] = 83;
						num2 = 6;
						continue;
					case 299:
						num8 = 70 - 0;
						num2 = 22;
						continue;
					case 147:
						num8 = 247 - 82;
						num9 = 99;
						goto IL_1cd2;
					case 139:
						array3[27] = 119;
						num9 = 142;
						goto IL_1cd2;
					case 359:
						num8 = 133 + 37;
						num = 236;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 145;
					case 376:
						num10 = 145 - 48;
						num9 = 239;
						goto IL_1cd2;
					case 154:
						num10 = 149 + 19;
						num9 = 185;
						goto IL_1cd2;
					case 270:
						array3[25] = (byte)num10;
						goto case 113;
					default:
						num2 = 113;
						continue;
					case 225:
						array3[25] = 65;
						num2 = 96;
						continue;
					case 99:
						array2[5] = (byte)num8;
						num = 176;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 355;
					case 355:
						array2[10] = 199;
						num9 = 266;
						goto IL_1cd2;
					case 266:
						array2[10] = 124;
						num = 282;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 349;
					case 349:
						array3[18] = (byte)num10;
						num = 264;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 246;
					case 345:
						array3[22] = 88;
						num9 = 77;
						goto IL_1cd2;
					case 265:
						array3[21] = 103;
						num = 131;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 162;
					case 162:
						array2[3] = (byte)num8;
						num9 = 201;
						goto IL_1cd2;
					case 35:
						array2[4] = (byte)num8;
						num9 = 229;
						goto IL_1cd2;
					case 294:
						num8 = 106 + 107;
						num = 312;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 281;
					case 281:
						num10 = 222 - 74;
						num2 = 78;
						continue;
					case 73:
						array4[13] = publicKeyToken[6];
						num = 334;
						goto IL_1cd6_2;
					case 15:
						array3[8] = (byte)num10;
						num9 = 292;
						goto IL_1cd2;
					case 182:
						array3[5] = 101;
						num = 316;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 121;
					case 121:
						num10 = 229 - 76;
						num = 145;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 310;
					case 310:
						array3[20] = 103;
						num9 = 202;
						goto IL_1cd2;
					case 77:
						num10 = 22 + 62;
						num = 122;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 156;
					case 331:
						num10 = 23 + 114;
						num2 = 48;
						continue;
					case 255:
						num10 = 240 - 80;
						num9 = 349;
						goto IL_1cd2;
					case 283:
						array3[9] = 80;
						num2 = 161;
						continue;
					case 157:
						array3[26] = (byte)num10;
						num9 = 1;
						goto IL_1cd2;
					case 6:
						num10 = 8 + 79;
						num = 206;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 319;
					case 319:
						num10 = 249 - 83;
						num9 = 307;
						goto IL_1cd2;
					case 295:
						array3[19] = (byte)num10;
						num = 310;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 88;
					case 30:
						cryptoStream.FlushFinalBlock();
						num2 = 137;
						continue;
					case 329:
						num10 = 153 - 51;
						num2 = 90;
						continue;
					case 333:
						array2[3] = (byte)num8;
						num = 260;
						goto IL_1cd6_2;
					case 55:
						array3[2] = 155;
						num2 = 85;
						continue;
					case 85:
						num10 = 221 - 73;
						num2 = 167;
						continue;
					case 339:
						array3[1] = 117;
						num = 328;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 141;
					case 197:
						array3[6] = 98;
						num = 143;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 242;
					case 242:
						array2[5] = 118;
						num = 147;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 37;
					case 326:
						array2[12] = 112;
						num2 = 241;
						continue;
					case 238:
						array3[3] = (byte)num10;
						num2 = 256;
						continue;
					case 166:
						array3[10] = (byte)num10;
						num = 227;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 31;
					case 31:
						num10 = 124 + 8;
						num = 267;
						goto IL_1cd6_2;
					case 227:
						array3[11] = 90;
						num2 = 49;
						continue;
					case 226:
						num8 = 175 - 58;
						num2 = 320;
						continue;
					case 340:
						array3[27] = (byte)num10;
						num = 139;
						goto IL_1cd6_2;
					case 313:
						array3[5] = (byte)num10;
						num = 362;
						goto IL_1cd6_2;
					case 180:
						array3[14] = 94;
						num9 = 374;
						goto IL_1cd2;
					case 98:
						binaryReader.Close();
						num9 = 50;
						goto IL_1cd2;
					case 63:
						num8 = 142 - 47;
						num9 = 28;
						goto IL_1cd2;
					case 72:
						array3[30] = (byte)num10;
						num2 = 82;
						continue;
					case 26:
						num10 = 56 - 52;
						num9 = 157;
						goto IL_1cd2;
					case 163:
						array2[5] = (byte)num8;
						num9 = 103;
						goto IL_1cd2;
					case 25:
						array2[9] = (byte)num8;
						num = 159;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 282;
					case 282:
						array2[10] = 180;
						num9 = 359;
						goto IL_1cd2;
					case 280:
						array3[6] = 27;
						num = 219;
						goto IL_1cd6_2;
					case 365:
						array3[10] = (byte)num10;
						num = 65;
						goto IL_1cd6_2;
					case 370:
						array3[2] = (byte)num10;
						num9 = 58;
						goto IL_1cd2;
					case 194:
						num10 = 108 - 30;
						num9 = 43;
						goto IL_1cd2;
					case 192:
						array3[11] = 118;
						num2 = 114;
						continue;
					case 216:
						num8 = 143 - 47;
						num = 41;
						goto IL_1cd6_2;
					case 43:
						array3[1] = (byte)num10;
						num2 = 330;
						continue;
					case 39:
						array2[6] = 132;
						num2 = 2;
						continue;
					case 322:
						array2[0] = 39;
						num = 226;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 254;
					case 254:
						array3[18] = (byte)num10;
						num9 = 346;
						goto IL_1cd2;
					case 196:
						num10 = 231 - 77;
						num2 = 20;
						continue;
					case 59:
						array2[7] = (byte)num8;
						num9 = 111;
						goto IL_1cd2;
					case 123:
						array2[3] = (byte)num8;
						num = 130;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 93;
					case 93:
						num10 = 181 - 60;
						num2 = 313;
						continue;
					case 148:
						array2[1] = (byte)num8;
						num = 315;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 367;
					case 367:
						num10 = 147 - 49;
						num9 = 356;
						goto IL_1cd2;
					case 287:
						num10 = 237 - 79;
						num = 354;
						goto IL_1cd6_2;
					case 50:
						goto IL_2a2b;
					case 153:
						num8 = 54 + 14;
						num = 120;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 308;
					case 308:
						array3[17] = 188;
						num9 = 208;
						goto IL_1cd2;
					case 51:
						array3[29] = (byte)num10;
						num = 127;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 18;
					case 18:
						num10 = 252 - 84;
						num2 = 244;
						continue;
					case 300:
						array3[20] = (byte)num10;
						num = 323;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 22;
					case 350:
						array3[10] = (byte)num10;
						num2 = 200;
						continue;
					case 9:
						num8 = 181 - 60;
						num = 148;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 187;
					case 187:
						array2[6] = (byte)num8;
						num = 371;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 88;
					case 88:
						array3[10] = 158;
						num = 47;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 158;
					case 158:
						array2[14] = (byte)num8;
						num9 = 76;
						goto IL_1cd2;
					case 257:
						num10 = 49 + 36;
						num9 = 230;
						goto IL_1cd2;
					case 71:
						array2[15] = (byte)num8;
						num = 262;
						goto IL_1cd6_2;
					case 87:
						array4[7] = publicKeyToken[3];
						num2 = 309;
						continue;
					case 107:
						num8 = 58 + 53;
						num = 286;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 306;
					case 306:
						array3[16] = (byte)num10;
						num = 112;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 91;
					case 91:
						array3[0] = 158;
						num2 = 231;
						continue;
					case 82:
						array3[30] = 149;
						num = 287;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 349;
					case 362:
						num10 = 54 + 49;
						num9 = 3;
						goto IL_1cd2;
					case 106:
						array2[12] = (byte)num8;
						num9 = 173;
						goto IL_1cd2;
					case 13:
						array2[13] = 196;
						num = 104;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 159;
					case 159:
						array2[9] = 156;
						num = 296;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 44;
					case 44:
						array3[1] = (byte)num10;
						num9 = 194;
						goto IL_1cd2;
					case 70:
						array4[1] = publicKeyToken[0];
						num = 92;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 171;
					case 171:
						array3[2] = 2;
						num = 46;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 151;
					case 151:
						array3[24] = (byte)num10;
						num2 = 317;
						continue;
					case 366:
						cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
						num = 213;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 232;
					case 232:
						array3[1] = (byte)num10;
						num = 31;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 309;
					case 309:
						array4[9] = publicKeyToken[4];
						num = 343;
						goto IL_1cd6_2;
					case 267:
						array3[1] = (byte)num10;
						num = 97;
						goto IL_1cd6_2;
					case 115:
						array3[13] = 184;
						num2 = 258;
						continue;
					case 164:
						array3[25] = (byte)num10;
						num2 = 38;
						continue;
					case 145:
						array3[25] = (byte)num10;
						num2 = 225;
						continue;
					case 184:
						array3[18] = 119;
						num = 5;
						if (0 == 0)
						{
							goto IL_1cd6_2;
						}
						goto case 311;
					case 311:
						array3[12] = (byte)num10;
						num = 319;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 118;
					case 118:
						array2[4] = (byte)num8;
						num = 303;
						if (!_0088())
						{
							goto IL_1cd6_2;
						}
						goto case 306;
					case 46:
						num10 = 55 + 16;
						num = 238;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 346;
					case 346:
						num10 = 195 - 65;
						num9 = 19;
						goto IL_1cd2;
					case 34:
						array3[16] = (byte)num10;
						num9 = 372;
						goto IL_1cd2;
					case 214:
						num10 = 71 + 12;
						num = 62;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 220;
					case 220:
						num10 = 136 - 45;
						num2 = 306;
						continue;
					case 149:
					case 243:
						num8 = 151 - 50;
						num9 = 100;
						goto IL_1cd2;
					case 173:
						array2[12] = 21;
						num2 = 228;
						continue;
					case 195:
						array3[14] = (byte)num10;
						num9 = 177;
						goto IL_1cd2;
					case 245:
						if (publicKeyToken.Length <= 0)
						{
							goto case 207;
						}
						num = 70;
						goto IL_1cd6_2;
					case 215:
						array3[20] = (byte)num10;
						num = 37;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 69;
					case 69:
						num10 = 160 - 109;
						num9 = 75;
						goto IL_1cd2;
					case 110:
						num8 = 166 + 61;
						num2 = 118;
						continue;
					case 189:
						binaryReader = new BinaryReader(typeof(_0090_009B).Assembly.GetManifestResourceStream("f40ad091-f861-47e8-92dd-16688a8bb9a5"));
						num = 116;
						if (true)
						{
							goto IL_1cd6_2;
						}
						goto case 103;
					case 103:
						num8 = 170 - 56;
						num9 = 357;
						goto IL_1cd2;
					case 269:
						array3[28] = 142;
						num2 = 8;
						continue;
					case 358:
						array3[12] = (byte)num10;
						num9 = 79;
						goto IL_1cd2;
					case 120:
						array2[3] = (byte)num8;
						num9 = 209;
						goto IL_1cd2;
					case 241:
						num8 = 147 - 49;
						num2 = 106;
						continue;
					case 138:
						if (_008B_0091_0088.Length == 0)
						{
							num2 = 189;
							continue;
						}
						goto IL_2a2b;
					case 42:
						array3[15] = 160;
						num9 = 69;
						goto IL_1cd2;
					case 352:
						num10 = 165 + 59;
						num = 295;
						if (_0087())
						{
							goto IL_1cd6_2;
						}
						goto case 259;
					case 259:
						array3[8] = (byte)num10;
						num2 = 23;
						continue;
					case 203:
						array3[5] = 118;
						num9 = 293;
						goto IL_1cd2;
					case 379:
						try
						{
							byte[] array = new byte[4];
							int num3 = 4;
							while (true)
							{
								int num5;
								switch (num3)
								{
								case 2:
									array[2] = _008B_0091_0088[P_0 + 2];
									goto case 3;
								case 3:
								case 5:
									array[3] = _008B_0091_0088[P_0 + 3];
									num3 = 6;
									continue;
								case 0:
								case 1:
									array[1] = _008B_0091_0088[P_0 + 1];
									goto case 2;
								default:
									num5 = 2;
									goto IL_3138;
								case 4:
									array[0] = _008B_0091_0088[P_0];
									_0088();
									if (!_0087())
									{
										num5 = 5;
										goto IL_3138;
									}
									num3 = 0;
									continue;
								case 6:
									{
										num4 = BitConverter.ToInt32(array, 0);
										break;
									}
									IL_3138:
									num3 = num5;
									continue;
								}
								break;
							}
						}
						catch
						{
						}
						try
						{
							if (_008B_0091_0087[num4] == 128)
							{
								_ = 0;
								int num7;
								if (_0087())
								{
									int num6 = 2;
									if (false)
									{
										goto IL_31f1;
									}
									num7 = num6;
								}
								else
								{
									num7 = 3;
								}
								switch (num7)
								{
								case 0:
								case 2:
									break;
								default:
									return result;
								}
								goto IL_31f1;
							}
							goto end_IL_31c4;
							IL_31f1:
							return true;
							end_IL_31c4:;
						}
						catch
						{
						}
						return false;
					case 207:
						symmetricAlgorithm = _008B_008F_0098();
						num = 10;
						goto IL_1cd6_2;
					case 129:
						memoryStream = new MemoryStream();
						num = 366;
						goto IL_1cd6_2;
					}
					break;
				}
				break;
			}
			goto IL_04d7;
			IL_04d7:
			num4 = 0;
			num9 = 379;
			goto IL_1cd2;
			IL_1cd2:
			num = num9;
			goto IL_1cd6;
			IL_2a2b:
			if (_008B_0091_0087.Length != 0)
			{
				goto IL_04d7;
			}
			num = 336;
			goto IL_1cd6;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static string _008B_008F_009C(int P_0)
		{
			int num = 249;
			int num6 = default(int);
			byte[] array2 = default(byte[]);
			uint num37 = default(uint);
			uint num36 = default(uint);
			int num16 = default(int);
			int num8 = default(int);
			byte[] array3 = default(byte[]);
			byte[] publicKeyToken = default(byte[]);
			int num10 = default(int);
			byte[] array4 = default(byte[]);
			int num32 = default(int);
			uint num11 = default(uint);
			byte[] array6 = default(byte[]);
			byte[] array7 = default(byte[]);
			uint num7 = default(uint);
			BinaryReader binaryReader = default(BinaryReader);
			uint num12 = default(uint);
			int num35 = default(int);
			int num33 = default(int);
			uint num30 = default(uint);
			int num31 = default(int);
			byte[] array5 = default(byte[]);
			CryptoStream cryptoStream = default(CryptoStream);
			int num13 = default(int);
			int num14 = default(int);
			SymmetricAlgorithm symmetricAlgorithm = default(SymmetricAlgorithm);
			uint num34 = default(uint);
			MemoryStream memoryStream = default(MemoryStream);
			int num38 = default(int);
			uint num18 = default(uint);
			ICryptoTransform transform = default(ICryptoTransform);
			int num9 = default(int);
			int num4 = default(int);
			int num15 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					int num3 = num2;
					while (true)
					{
						switch (num3)
						{
						case 129:
							num6 = 47 + 36;
							num2 = 328;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 258;
						case 258:
							array2[1] = (byte)num6;
							num2 = 11;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 6;
						case 6:
							num37 <<= 8;
							num2 = 330;
							goto end_IL_0dc0;
						case 341:
							num36 = (uint)num16;
							num2 = 302;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 252;
						case 252:
							num6 = 39 + 90;
							num2 = 279;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 391;
						case 391:
							array2[2] = (byte)num8;
							num = 147;
							goto end_IL_0dbc;
						case 399:
							array2[15] = (byte)num6;
							num3 = 393;
							continue;
						case 90:
							num8 = 158 - 52;
							num3 = 69;
							continue;
						case 332:
							array3[15] = publicKeyToken[7];
							num = 280;
							goto end_IL_0dbc;
						case 230:
							array2[19] = (byte)num6;
							num3 = 33;
							continue;
						case 89:
							num6 = 89 + 113;
							num = 46;
							goto end_IL_0dbc;
						case 353:
							num10 = 140 + 50;
							num2 = 283;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 363;
						case 363:
							array2[11] = 129;
							num = 58;
							goto end_IL_0dbc;
						case 297:
							array4[14] = 228;
							num3 = 358;
							continue;
						case 364:
							array2[18] = 118;
							num = 20;
							goto end_IL_0dbc;
						case 275:
							array2[4] = 123;
							num2 = 238;
							goto end_IL_0dc0;
						case 105:
							array2[17] = (byte)num6;
							num2 = 252;
							goto end_IL_0dc0;
						case 272:
							array4[12] = 104;
							num2 = 55;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 146;
						case 146:
							array2[0] = (byte)num8;
							num3 = 107;
							continue;
						case 97:
						case 229:
							break;
						case 55:
							num10 = 236 - 78;
							num3 = 79;
							continue;
						case 248:
							array4[12] = (byte)num10;
							num2 = 216;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 32;
						case 32:
							array2[19] = (byte)num6;
							num3 = 4;
							continue;
						case 4:
							array2[19] = 105;
							num2 = 167;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 123;
						case 123:
							num8 = 143 - 47;
							num2 = 186;
							goto end_IL_0dc0;
						case 333:
							array2[31] = 101;
							num = 219;
							goto end_IL_0dbc;
						case 50:
							array2[1] = (byte)num6;
							num3 = 322;
							continue;
						case 355:
							num10 = 109 + 83;
							num3 = 144;
							continue;
						case 308:
							num10 = 66 + 41;
							num2 = 10;
							goto end_IL_0dc0;
						case 20:
							array2[18] = 68;
							num2 = 138;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 127;
						case 127:
							if (num32 > 0)
							{
								num = 351;
								goto end_IL_0dbc;
							}
							goto IL_14a9;
						case 256:
							num11 = 0u;
							num = 388;
							goto end_IL_0dbc;
						case 133:
							array4[14] = (byte)num10;
							num = 247;
							goto end_IL_0dbc;
						case 68:
							array4[0] = 11;
							num2 = 92;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 95;
						case 95:
							array4[11] = (byte)num10;
							num2 = 78;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 36;
						case 36:
							array4[7] = (byte)num10;
							num3 = 15;
							continue;
						case 227:
							array2[23] = 212;
							num2 = 255;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 191;
						case 191:
							array4[2] = 219;
							num2 = 149;
							goto end_IL_0dc0;
						case 217:
							array2[4] = 86;
							num2 = 275;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 1;
						case 1:
							array2[30] = 55;
							num3 = 324;
							continue;
						case 372:
							array2[19] = 38;
							num2 = 325;
							goto end_IL_0dc0;
						case 193:
							array2[20] = 84;
							num2 = 299;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 43;
						case 43:
							num8 = 87 + 122;
							num3 = 401;
							continue;
						case 314:
							goto IL_04c8;
						case 160:
							array2[2] = 89;
							num = 176;
							goto end_IL_0dbc;
						case 385:
							num10 = 250 - 83;
							num3 = 201;
							continue;
						case 241:
							array4[13] = (byte)num10;
							num3 = 335;
							continue;
						case 220:
							num10 = 179 - 59;
							num = 71;
							goto end_IL_0dbc;
						case 71:
							array4[5] = (byte)num10;
							num2 = 301;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 399;
						case 334:
							num6 = 55 + 37;
							num2 = 74;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 100;
						case 100:
							array4[2] = 109;
							num3 = 75;
							continue;
						case 162:
							publicKeyToken = typeof(_0090_009B).Assembly.GetName().GetPublicKeyToken();
							num = 270;
							goto end_IL_0dbc;
						case 0:
							num8 = 50 - 26;
							num2 = 16;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 96;
						case 96:
							array2[25] = 185;
							num2 = 379;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 56;
						case 56:
							array4[9] = 102;
							num = 389;
							goto end_IL_0dbc;
						case 141:
						case 282:
							array4[10] = (byte)num10;
							num = 331;
							goto end_IL_0dbc;
						case 346:
							num36 = 0u;
							num = 209;
							goto end_IL_0dbc;
						case 200:
							array2[29] = 112;
							num3 = 18;
							continue;
						case 22:
							array2[26] = (byte)num8;
							num2 = 339;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 47;
						case 47:
							array2[15] = (byte)num8;
							num = 183;
							goto end_IL_0dbc;
						case 51:
							array4[4] = (byte)num10;
							num = 396;
							goto end_IL_0dbc;
						case 286:
							array4[9] = 151;
							num3 = 56;
							continue;
						case 283:
							array4[1] = (byte)num10;
							num = 338;
							goto end_IL_0dbc;
						case 222:
							array6 = new byte[array7.Length];
							num = 169;
							goto end_IL_0dbc;
						case 270:
							if (publicKeyToken != null)
							{
								num = 204;
								goto end_IL_0dbc;
							}
							goto case 280;
						case 238:
							num8 = 68 - 20;
							num3 = 189;
							continue;
						case 64:
							num6 = 133 - 44;
							num = 233;
							goto end_IL_0dbc;
						case 317:
							num7 = 0u;
							num2 = 266;
							goto end_IL_0dc0;
						case 171:
							array4[5] = (byte)num10;
							num2 = 357;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 40;
						case 40:
							binaryReader = new BinaryReader(typeof(_0090_009B).Assembly.GetManifestResourceStream("867cf343-c42d-4756-bcac-bef7f44beea9"));
							num2 = 83;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 340;
						case 340:
							num6 = 157 - 52;
							num2 = 378;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 321;
						case 29:
							array4[2] = 228;
							num2 = 67;
							goto end_IL_0dc0;
						case 17:
							array2[13] = 111;
							num2 = 35;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 264;
						case 264:
							num6 = 157 - 52;
							num3 = 214;
							continue;
						case 289:
							num10 = 171 - 57;
							num2 = 295;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 388;
						case 388:
							num12 = 0u;
							num = 317;
							goto end_IL_0dbc;
						case 296:
							array4[6] = (byte)num10;
							num2 = 66;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 197;
						case 197:
							array4[1] = (byte)num10;
							num = 102;
							goto end_IL_0dbc;
						case 25:
							num35 = 0;
							num = 229;
							goto end_IL_0dbc;
						case 203:
							array2[3] = (byte)num8;
							num = 244;
							goto end_IL_0dbc;
						case 144:
							array4[4] = (byte)num10;
							num = 309;
							goto end_IL_0dbc;
						case 132:
							array2[31] = 134;
							num2 = 333;
							goto end_IL_0dc0;
						case 305:
							num8 = 145 - 78;
							num2 = 382;
							goto end_IL_0dc0;
						case 298:
							num33++;
							num3 = 3;
							continue;
						case 345:
							array4[4] = (byte)num10;
							num2 = 84;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 90;
						case 225:
							binaryReader.Close();
							num3 = 77;
							continue;
						case 359:
							array2[11] = 155;
							num2 = 363;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 390;
						case 186:
							array2[8] = (byte)num8;
							num2 = 271;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 304;
						case 304:
							array4[1] = (byte)num10;
							num = 300;
							goto end_IL_0dbc;
						case 111:
							num10 = 204 - 68;
							num2 = 178;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 72;
						case 72:
							array2[8] = (byte)num8;
							num = 123;
							goto end_IL_0dbc;
						case 266:
							if (num32 <= 0)
							{
								goto case 346;
							}
							num2 = 42;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 78;
						case 78:
							array4[11] = 57;
							num3 = 231;
							continue;
						case 281:
							num8 = 26 + 69;
							num3 = 156;
							continue;
						case 278:
							array2 = new byte[32];
							num2 = 148;
							goto end_IL_0dc0;
						case 348:
							array2[6] = 86;
							num2 = 365;
							goto end_IL_0dc0;
						case 8:
							array2[9] = 154;
							num2 = 394;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 84;
						case 84:
							num10 = 165 - 112;
							num = 51;
							goto end_IL_0dbc;
						case 46:
							array2[28] = (byte)num6;
							num2 = 26;
							goto end_IL_0dc0;
						case 347:
							array4[4] = 21;
							num = 126;
							goto end_IL_0dbc;
						case 375:
							array4[9] = (byte)num10;
							num3 = 134;
							continue;
						case 79:
							array4[13] = (byte)num10;
							num = 154;
							goto end_IL_0dbc;
						case 37:
							array6[num16 + num33] = (byte)((num30 & num37) >> num31);
							num2 = 298;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 248;
						case 66:
							num10 = 223 - 74;
							num2 = 259;
							goto end_IL_0dc0;
						case 247:
							array4[14] = 33;
							num2 = 297;
							goto end_IL_0dc0;
						case 150:
							num10 = 105 + 93;
							num3 = 36;
							continue;
						case 226:
							array2[29] = (byte)num8;
							num = 265;
							goto end_IL_0dbc;
						case 315:
							array2[6] = 39;
							num2 = 348;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 109;
						case 38:
							array4[10] = 70;
							num2 = 54;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 246;
						case 33:
							num6 = 197 - 65;
							num = 63;
							goto end_IL_0dbc;
						case 167:
							num6 = 29 + 113;
							num3 = 398;
							continue;
						case 137:
							num8 = 197 + 29;
							num2 = 157;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 306;
						case 306:
							array2[0] = 172;
							num3 = 165;
							continue;
						case 143:
							array2[9] = 204;
							num2 = 284;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 354;
						case 354:
							array4[4] = 117;
							num = 355;
							goto end_IL_0dbc;
						case 41:
							num8 = 242 - 80;
							num2 = 391;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 263;
						case 263:
							num6 = 44 + 76;
							num3 = 368;
							continue;
						case 201:
							array4[9] = (byte)num10;
							num2 = 286;
							goto end_IL_0dc0;
						case 301:
							num10 = 148 - 120;
							num3 = 171;
							continue;
						case 136:
							num6 = 95 + 101;
							num = 179;
							goto end_IL_0dbc;
						case 181:
							num32 = array7.Length % 4;
							num = 13;
							goto end_IL_0dbc;
						case 287:
							array2[3] = 92;
							num3 = 31;
							continue;
						case 219:
							array5 = array2;
							num3 = 115;
							continue;
						case 261:
							num8 = 107 + 91;
							goto case 87;
						default:
							num3 = 87;
							continue;
						case 102:
							num10 = 172 - 57;
							num2 = 61;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 122;
						case 122:
							num6 = 128 - 46;
							num3 = 105;
							continue;
						case 110:
							array3[3] = publicKeyToken[1];
							num = 151;
							goto end_IL_0dbc;
						case 140:
							array2[23] = 134;
							num2 = 227;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 40;
						case 316:
						case 337:
							goto IL_1490;
						case 401:
							array2[25] = (byte)num8;
							num3 = 381;
							continue;
						case 88:
							cryptoStream.Close();
							num2 = 225;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 65;
						case 65:
							num8 = 119 + 96;
							num3 = 234;
							continue;
						case 322:
							num8 = 212 - 70;
							num2 = 232;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 81;
						case 81:
						case 187:
							num13++;
							num3 = 356;
							continue;
						case 204:
							if (publicKeyToken.Length > 0)
							{
								num2 = 180;
								if (!_0088())
								{
									goto end_IL_0dc0;
								}
								goto case 36;
							}
							goto case 280;
						case 377:
							num6 = 127 - 42;
							num2 = 173;
							goto end_IL_0dc0;
						case 155:
							array2[24] = 168;
							num2 = 367;
							goto end_IL_0dc0;
						case 299:
							array2[20] = 115;
							num3 = 137;
							continue;
						case 73:
							array2[9] = (byte)num8;
							num3 = 8;
							continue;
						case 59:
							num12 = (uint)((array5[num36 + 3] << 24) | (array5[num36 + 2] << 16) | (array5[num36 + 1] << 8) | array5[num36]);
							num2 = 336;
							goto end_IL_0dc0;
						case 206:
							array2[13] = 119;
							num3 = 17;
							continue;
						case 156:
							array2[12] = (byte)num8;
							num2 = 70;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 150;
						case 231:
							num10 = 122 + 101;
							num3 = 248;
							continue;
						case 239:
							array4[6] = 121;
							num = 192;
							goto end_IL_0dbc;
						case 7:
							array2[5] = 164;
							num2 = 109;
							goto end_IL_0dc0;
						case 233:
							array2[1] = (byte)num6;
							num2 = 327;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 13;
						case 13:
							num14 = array7.Length / 4;
							num3 = 222;
							continue;
						case 320:
							array2[28] = 232;
							num2 = 188;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 318;
						case 318:
							num6 = 121 - 36;
							num3 = 399;
							continue;
						case 11:
							num6 = 50 + 49;
							num3 = 50;
							continue;
						case 14:
							symmetricAlgorithm.Mode = CipherMode.CBC;
							num2 = 380;
							goto end_IL_0dc0;
						case 23:
							array4[3] = (byte)num10;
							num = 125;
							goto end_IL_0dbc;
						case 386:
							array4[2] = (byte)num10;
							num = 191;
							goto end_IL_0dbc;
						case 118:
							array4[15] = 94;
							num2 = 121;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 251;
						case 251:
							array2[27] = 118;
							num3 = 250;
							continue;
						case 76:
							array2[29] = 90;
							num2 = 200;
							goto end_IL_0dc0;
						case 148:
							array2[0] = 177;
							num = 116;
							goto end_IL_0dbc;
						case 130:
							array6[num16 + 2] = (byte)((num34 & 0xFF0000) >> 16);
							num2 = 101;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 221;
						case 221:
							array2[16] = (byte)num6;
							num3 = 392;
							continue;
						case 234:
							array2[19] = (byte)num8;
							num3 = 372;
							continue;
						case 31:
							array2[3] = 93;
							num2 = 263;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 69;
						case 69:
							array2[26] = (byte)num8;
							num2 = 312;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 248;
						case 107:
							num6 = 108 + 55;
							num3 = 258;
							continue;
						case 245:
							array2[3] = (byte)num8;
							num3 = 334;
							continue;
						case 213:
							array4[7] = 116;
							num2 = 150;
							goto end_IL_0dc0;
						case 145:
							_008B_0091_0089 = array6;
							num2 = 390;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 276;
						case 276:
							array3[13] = publicKeyToken[6];
							num = 332;
							goto end_IL_0dbc;
						case 269:
							array3 = array4;
							num2 = 162;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 349;
						case 349:
							array2[6] = 88;
							num3 = 340;
							continue;
						case 367:
							array2[24] = 158;
							num2 = 43;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 153;
						case 153:
							num8 = 179 - 59;
							num2 = 22;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 350;
						case 350:
							array2[14] = 156;
							num2 = 215;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 61;
						case 61:
							array4[1] = (byte)num10;
							num = 161;
							goto end_IL_0dbc;
						case 5:
							array2[22] = 135;
							num2 = 374;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 16;
						case 16:
							array2[10] = (byte)num8;
							num2 = 52;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 391;
						case 300:
							num10 = 206 - 68;
							num3 = 352;
							continue;
						case 109:
							array2[5] = 184;
							num = 349;
							goto end_IL_0dbc;
						case 294:
							array6[num16] = (byte)(num34 & 0xFF);
							num3 = 117;
							continue;
						case 302:
							num7 = (uint)((array7[num36 + 3] << 24) | (array7[num36 + 2] << 16) | (array7[num36 + 1] << 8) | array7[num36]);
							num2 = 91;
							goto end_IL_0dc0;
						case 194:
							array4[15] = (byte)num10;
							num2 = 118;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 244;
						case 244:
							array2[3] = 152;
							num2 = 131;
							goto end_IL_0dc0;
						case 255:
							array2[24] = 104;
							num3 = 155;
							continue;
						case 70:
							num6 = 194 - 64;
							num2 = 262;
							goto end_IL_0dc0;
						case 382:
							array2[21] = (byte)num8;
							num2 = 253;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 268;
						case 232:
							array2[1] = (byte)num8;
							num2 = 64;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 19;
						case 19:
							array4[12] = 114;
							num2 = 272;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 52;
						case 52:
							array2[11] = 134;
							num2 = 228;
							goto end_IL_0dc0;
						case 82:
							array4[3] = 11;
							num = 347;
							goto end_IL_0dbc;
						case 116:
							array2[0] = 92;
							num2 = 237;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 175;
						case 175:
							num10 = 41 + 85;
							num2 = 194;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 289;
						case 311:
							array4[0] = (byte)num10;
							num3 = 68;
							continue;
						case 285:
							num8 = 78 + 21;
							num2 = 369;
							goto end_IL_0dc0;
						case 326:
							num6 = 2 + 85;
							num3 = 400;
							continue;
						case 117:
							array6[num16 + 1] = (byte)((num34 & 0xFF00) >> 8);
							num3 = 130;
							continue;
						case 185:
							num10 = 96 + 113;
							num2 = 375;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 285;
						case 99:
							array2[25] = 236;
							num2 = 90;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 152;
						case 177:
							num7 <<= 8;
							num2 = 314;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 168;
						case 168:
							array2[10] = (byte)num6;
							num2 = 384;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 106;
						case 106:
							num10 = 226 - 75;
							num = 311;
							goto end_IL_0dbc;
						case 335:
							array4[13] = 48;
							num3 = 224;
							continue;
						case 62:
							goto IL_1d6c;
						case 149:
							num10 = 71 + 41;
							num2 = 23;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 393;
						case 393:
							num6 = 61 + 62;
							num2 = 184;
							goto end_IL_0dc0;
						case 173:
							array2[23] = (byte)num6;
							num3 = 140;
							continue;
						case 360:
							array4[11] = 170;
							num3 = 289;
							continue;
						case 108:
							num8 = 129 - 43;
							num3 = 72;
							continue;
						case 183:
							array2[15] = 148;
							num2 = 172;
							goto end_IL_0dc0;
						case 339:
							num8 = 83 + 115;
							num2 = 208;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 28;
						case 28:
							array4[9] = (byte)num10;
							num = 185;
							goto end_IL_0dbc;
						case 157:
							array2[20] = (byte)num8;
							num3 = 371;
							continue;
						case 21:
							array2[27] = 232;
							num2 = 89;
							goto end_IL_0dc0;
						case 10:
							array4[5] = (byte)num10;
							num3 = 220;
							continue;
						case 321:
							array4[6] = (byte)num10;
							num2 = 128;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 119;
						case 119:
							num6 = 121 + 76;
							num3 = 221;
							continue;
						case 77:
							array7 = _008B_0091_0089;
							num3 = 181;
							continue;
						case 327:
							num8 = 164 + 81;
							num = 387;
							goto end_IL_0dbc;
						case 271:
							array2[8] = 174;
							num2 = 323;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 260;
						case 260:
							num10 = 129 - 43;
							num2 = 241;
							goto end_IL_0dc0;
						case 376:
							array2[12] = (byte)num6;
							num2 = 206;
							goto end_IL_0dc0;
						case 309:
							num10 = 109 + 121;
							num3 = 345;
							continue;
						case 163:
							num8 = 61 + 54;
							num2 = 112;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 358;
						case 358:
							array4[15] = 167;
							num = 288;
							goto end_IL_0dbc;
						case 39:
							array2[2] = (byte)num8;
							num = 160;
							goto end_IL_0dbc;
						case 237:
							array2[0] = 146;
							num = 306;
							goto end_IL_0dbc;
						case 139:
							array2[11] = 111;
							num2 = 359;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 384;
						case 384:
							array2[10] = 215;
							num = 0;
							goto end_IL_0dbc;
						case 395:
							array7 = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
							num2 = 278;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 58;
						case 58:
							array2[12] = 152;
							num = 281;
							goto end_IL_0dbc;
						case 121:
							array4[15] = 66;
							num2 = 269;
							goto end_IL_0dc0;
						case 254:
							array2[5] = (byte)num6;
							num2 = 264;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 211;
						case 147:
							num8 = 105 + 29;
							num2 = 39;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 12;
						case 12:
							array2[21] = 103;
							num3 = 305;
							continue;
						case 279:
							array2[18] = (byte)num6;
							num2 = 364;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 228;
						case 164:
							array2[31] = (byte)num8;
							num2 = 218;
							goto end_IL_0dc0;
						case 387:
							array2[1] = (byte)num8;
							num2 = 41;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 74;
						case 74:
							array2[3] = (byte)num6;
							num2 = 287;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 20;
						case 330:
							num31 += 8;
							num2 = 37;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 106;
						case 362:
							_008B_0091_0089 = memoryStream.ToArray();
							num3 = 273;
							continue;
						case 259:
							array4[6] = (byte)num10;
							num2 = 239;
							goto end_IL_0dc0;
						case 80:
							cryptoStream.FlushFinalBlock();
							num2 = 362;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 324;
						case 324:
							num8 = 207 - 69;
							num2 = 170;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 325;
						case 325:
							num6 = 2 + 77;
							num3 = 32;
							continue;
						case 209:
							num13 = 0;
							num2 = 60;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 75;
						case 124:
							num10 = 122 + 123;
							num = 95;
							goto end_IL_0dbc;
						case 277:
							num36 = (uint)(num38 * 4);
							num = 59;
							goto end_IL_0dbc;
						case 151:
							array3[5] = publicKeyToken[2];
							num = 291;
							goto end_IL_0dbc;
						case 398:
							array2[20] = (byte)num6;
							num = 193;
							goto end_IL_0dbc;
						case 336:
							num37 = 255u;
							num3 = 307;
							continue;
						case 383:
							num8 = 36 + 1;
							num3 = 257;
							continue;
						case 397:
							array2[7] = 149;
							num = 120;
							goto end_IL_0dbc;
						case 179:
							array2[5] = (byte)num6;
							num = 202;
							goto end_IL_0dbc;
						case 312:
							num6 = 124 + 98;
							num2 = 370;
							goto end_IL_0dc0;
						case 394:
							num6 = 189 - 63;
							num3 = 344;
							continue;
						case 352:
							array4[1] = (byte)num10;
							num3 = 353;
							continue;
						case 87:
							array2[30] = (byte)num8;
							num2 = 104;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 211;
						case 211:
							array2[26] = (byte)num6;
							num3 = 251;
							continue;
						case 86:
							num10 = 210 + 3;
							num2 = 113;
							goto end_IL_0dc0;
						case 242:
							num10 = 179 - 59;
							num3 = 304;
							continue;
						case 182:
							num11 = num18;
							num = 49;
							goto end_IL_0dbc;
						case 379:
							num6 = 233 - 77;
							num2 = 174;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 373;
						case 373:
							array4[3] = 109;
							num3 = 82;
							continue;
						case 202:
							num6 = 217 - 72;
							num2 = 254;
							goto end_IL_0dc0;
						case 125:
							array4[3] = 96;
							num2 = 373;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 205;
						case 205:
							array4[8] = (byte)num10;
							num2 = 86;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 80;
						case 49:
							if (num13 == num14 - 1)
							{
								num = 190;
								goto end_IL_0dbc;
							}
							goto IL_17fd;
						case 161:
							array4[1] = 152;
							num2 = 242;
							goto end_IL_0dc0;
						case 15:
							array4[7] = 206;
							num2 = 57;
							goto end_IL_0dc0;
						case 180:
							array3[1] = publicKeyToken[0];
							num = 110;
							goto end_IL_0dbc;
						case 310:
							array4[15] = (byte)num10;
							num = 175;
							goto end_IL_0dbc;
						case 331:
							array4[10] = 18;
							num2 = 111;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 257;
						case 257:
							array2[25] = (byte)num8;
							num2 = 96;
							goto end_IL_0dc0;
						case 329:
							num35++;
							num = 97;
							goto end_IL_0dbc;
						case 9:
							cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
							num2 = 135;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 208;
						case 208:
							array2[26] = (byte)num8;
							num = 326;
							goto end_IL_0dbc;
						case 135:
							cryptoStream.Write(array7, 0, array7.Length);
							num3 = 80;
							continue;
						case 91:
						case 93:
							num18 = num11;
							num2 = 240;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 184;
						case 184:
							array2[16] = (byte)num6;
							num2 = 119;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 165;
						case 165:
							num8 = 216 + 2;
							num2 = 146;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 101;
						case 101:
							array6[num16 + 3] = (byte)((num34 & 0xFF000000u) >> 24);
							num3 = 81;
							continue;
						case 54:
							array4[10] = 130;
							num2 = 210;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 295;
						case 199:
							array2[28] = (byte)num6;
							num3 = 342;
							continue;
						case 104:
							num8 = 48 + 56;
							num = 164;
							goto end_IL_0dbc;
						case 138:
							array2[18] = 106;
							num2 = 223;
							goto end_IL_0dc0;
						case 188:
							array2[29] = 147;
							num2 = 76;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 3;
						case 154:
							array4[13] = 158;
							num3 = 260;
							continue;
						case 114:
							num6 = 113 + 60;
							num3 = 319;
							continue;
						case 366:
							array4[0] = 116;
							num3 = 106;
							continue;
						case 228:
							array2[11] = 140;
							num2 = 139;
							goto end_IL_0dc0;
						case 246:
							if (P_0 == -1)
							{
								num = 48;
								goto end_IL_0dbc;
							}
							goto case 181;
						case 381:
							array2[25] = 130;
							num2 = 383;
							goto end_IL_0dc0;
						case 172:
							array2[15] = 92;
							num3 = 318;
							continue;
						case 328:
							array2[21] = (byte)num6;
							num3 = 12;
							continue;
						case 313:
							num6 = 105 + 15;
							num2 = 230;
							goto end_IL_0dc0;
						case 63:
							array2[19] = (byte)num6;
							num = 65;
							goto end_IL_0dbc;
						case 216:
							array4[12] = 117;
							num2 = 19;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 170;
						case 190:
							if (num32 > 0)
							{
								num = 243;
								goto end_IL_0dbc;
							}
							goto IL_17fd;
						case 267:
							array4[2] = (byte)num10;
							num = 100;
							goto end_IL_0dbc;
						case 44:
							array4[10] = (byte)num10;
							num2 = 360;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 357;
						case 357:
							num10 = 209 - 69;
							num2 = 296;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 113;
						case 113:
							array4[8] = (byte)num10;
							num3 = 385;
							continue;
						case 189:
							array2[4] = (byte)num8;
							num3 = 136;
							continue;
						case 67:
							num10 = 147 - 49;
							num3 = 267;
							continue;
						case 265:
							array2[30] = 103;
							num2 = 1;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 319;
						case 319:
							array2[17] = (byte)num6;
							num3 = 122;
							continue;
						case 288:
							num10 = 147 - 49;
							num3 = 310;
							continue;
						case 112:
							array2[17] = (byte)num8;
							num = 114;
							goto end_IL_0dbc;
						case 262:
							array2[12] = (byte)num6;
							num2 = 343;
							goto end_IL_0dc0;
						case 293:
							array2[27] = 78;
							num2 = 21;
							goto end_IL_0dc0;
						case 307:
							num31 = 0;
							num2 = 198;
							goto end_IL_0dc0;
						case 250:
							array2[27] = 184;
							num = 293;
							goto end_IL_0dbc;
						case 159:
							num10 = 26 + 75;
							num2 = 205;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 280;
						case 280:
							num9 = 0;
							num2 = 316;
							goto end_IL_0dc0;
						case 75:
							num10 = 17 + 82;
							num2 = 386;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 192;
						case 192:
							num10 = 120 + 43;
							num2 = 321;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 400;
						case 400:
							array2[26] = (byte)num6;
							num3 = 292;
							continue;
						case 224:
							num10 = 214 - 71;
							num = 133;
							goto end_IL_0dbc;
						case 295:
							array4[11] = (byte)num10;
							num3 = 124;
							continue;
						case 142:
							array2[28] = (byte)num6;
							num3 = 320;
							continue;
						case 390:
							num4 = BitConverter.ToInt32(_008B_0091_0089, P_0);
							num = 402;
							goto end_IL_0dbc;
						case 243:
							num30 = num11 ^ num7;
							num2 = 152;
							goto end_IL_0dc0;
						case 343:
							num6 = 135 - 46;
							num3 = 376;
							continue;
						case 35:
							array2[13] = 136;
							num = 62;
							goto end_IL_0dbc;
						case 166:
							array2[6] = 201;
							num3 = 315;
							continue;
						case 235:
							num6 = 34 + 124;
							num2 = 158;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 370;
						case 370:
							array2[26] = (byte)num6;
							num3 = 153;
							continue;
						case 128:
							array4[6] = 228;
							num3 = 213;
							continue;
						case 98:
							array2[22] = (byte)num6;
							num3 = 377;
							continue;
						case 176:
							num8 = 17 + 67;
							num = 203;
							goto end_IL_0dbc;
						case 290:
						{
							uint num17 = num18;
							uint num19 = num18;
							uint num20 = 1341288995u;
							uint num21 = 611865032u;
							uint num22 = 1940111450u;
							uint num23 = num19;
							uint num24 = 1468126237u;
							uint num25 = 1873844383u;
							num22 += num24;
							uint num26 = ((num21 >> 9) | (num21 << 23)) ^ num20;
							uint num27 = num26 & 0x55555555;
							num26 &= 0xAAAAAAAAu;
							num21 = (num26 >> 1) | (num27 << 1);
							ulong num28 = num22 * 1695230583;
							if (num28 == 0)
							{
								num28--;
							}
							num20 = (uint)(num20 * num20 % num28);
							if ((double)num24 == 0.0)
							{
								num24--;
							}
							uint num29 = (uint)(103265678.0 / (double)num24 + (double)num24);
							num24 = (uint)((uint)(((short)num22 + -3288) * (int)num29) + (short)num22);
							num25 -= num22;
							num23 ^= num23 >> 1;
							num23 += num20;
							num23 ^= num23 >> 6;
							num23 += num24;
							num23 ^= num23 << 11;
							num23 += num25;
							num23 = (((num22 << 18) - num21) ^ num24) - num23;
							num18 = num17 + (uint)(double)num23;
							num3 = 182;
							continue;
						}
						case 24:
							num16 = num13 * 4;
							num2 = 277;
							goto end_IL_0dc0;
						case 18:
							num8 = 160 + 91;
							num2 = 226;
							goto end_IL_0dc0;
						case 392:
							array2[16] = 229;
							num2 = 163;
							goto end_IL_0dc0;
						case 284:
							num6 = 232 - 77;
							num2 = 168;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 115;
						case 115:
							array4 = new byte[16];
							num2 = 366;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 48;
						case 273:
							memoryStream.Close();
							num2 = 88;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 240;
						case 240:
							num11++;
							num2 = 290;
							goto end_IL_0dc0;
						case 291:
							array3[7] = publicKeyToken[3];
							num2 = 27;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 380;
						case 380:
							transform = symmetricAlgorithm.CreateDecryptor(array5, array3);
							num = 45;
							goto end_IL_0dbc;
						case 371:
							array2[21] = 88;
							num2 = 129;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 27;
						case 27:
							array3[9] = publicKeyToken[4];
							num2 = 30;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 222;
						case 131:
							num8 = 162 - 54;
							num2 = 245;
							goto end_IL_0dc0;
						case 158:
							array2[7] = (byte)num6;
							num3 = 212;
							continue;
						case 42:
							num14++;
							num = 346;
							goto end_IL_0dbc;
						case 178:
							array4[10] = (byte)num10;
							num2 = 38;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 34;
						case 34:
							array2[14] = 96;
							num2 = 350;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 212;
						case 212:
							array2[8] = 124;
							num = 108;
							goto end_IL_0dbc;
						case 268:
							array2[31] = (byte)num8;
							num3 = 132;
							continue;
						case 169:
							num15 = array5.Length / 4;
							num2 = 256;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 296;
						case 196:
							array2[18] = (byte)num8;
							num2 = 313;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 56;
						case 223:
							num8 = 137 + 80;
							num3 = 196;
							continue;
						case 134:
							array4[9] = 74;
							num3 = 303;
							continue;
						case 338:
							array4[2] = 105;
							num2 = 29;
							goto end_IL_0dc0;
						case 292:
							num6 = 80 - 73;
							num = 211;
							goto end_IL_0dbc;
						case 94:
						case 195:
							array2[13] = (byte)num6;
							num3 = 34;
							continue;
						case 60:
						case 356:
							goto IL_3038;
						case 214:
							array2[5] = (byte)num6;
							num3 = 7;
							continue;
						case 198:
							if (num13 == num14 - 1)
							{
								num = 127;
								goto end_IL_0dbc;
							}
							goto IL_14a9;
						case 374:
							array2[22] = 87;
							num = 285;
							goto end_IL_0dbc;
						case 57:
							array4[8] = 148;
							num2 = 159;
							goto end_IL_0dc0;
						case 389:
							num10 = 6 + 52;
							num = 28;
							goto end_IL_0dbc;
						case 365:
							array2[6] = 201;
							num3 = 397;
							continue;
						case 344:
							array2[9] = (byte)num6;
							num2 = 143;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 26;
						case 26:
							num6 = 67 + 34;
							num3 = 199;
							continue;
						case 152:
							num33 = 0;
							num3 = 361;
							continue;
						case 207:
							num8 = 226 - 75;
							num = 47;
							goto end_IL_0dbc;
						case 3:
						case 361:
							if (num33 < num32)
							{
								if (num33 > 0)
								{
									num3 = 6;
									continue;
								}
								goto case 37;
							}
							num3 = 187;
							continue;
						case 369:
							array2[22] = (byte)num8;
							num3 = 85;
							continue;
						case 218:
							array2[31] = 111;
							num2 = 236;
							if (!_0088())
							{
								goto end_IL_0dc0;
							}
							goto case 126;
						case 126:
							array4[4] = 132;
							num2 = 354;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 170;
						case 170:
							array2[30] = (byte)num8;
							num2 = 274;
							goto end_IL_0dc0;
						case 103:
							num8 = 237 - 79;
							num3 = 73;
							continue;
						case 85:
							num6 = 46 - 24;
							num2 = 98;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 386;
						case 92:
							num10 = 21 + 47;
							num = 197;
							goto end_IL_0dbc;
						case 174:
							array2[25] = (byte)num6;
							num3 = 99;
							continue;
						case 323:
							array2[9] = 48;
							num2 = 103;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 253;
						case 253:
							array2[22] = 99;
							num = 5;
							goto end_IL_0dbc;
						case 368:
							array2[4] = (byte)num6;
							num3 = 217;
							continue;
						case 342:
							num6 = 215 - 71;
							num = 142;
							goto end_IL_0dbc;
						case 378:
							array2[6] = (byte)num6;
							num = 166;
							goto end_IL_0dbc;
						case 53:
							num11 += num12;
							num2 = 25;
							if (true)
							{
								goto end_IL_0dc0;
							}
							goto case 215;
						case 215:
							array2[14] = 68;
							num = 207;
							goto end_IL_0dbc;
						case 303:
							num10 = 184 - 61;
							goto case 141;
						case 249:
							if (_008B_0091_0089.Length == 0)
							{
								num2 = 40;
								goto end_IL_0dc0;
							}
							goto case 390;
						case 210:
							num10 = 215 + 17;
							num3 = 44;
							continue;
						case 396:
							array4[5] = 160;
							num2 = 308;
							goto end_IL_0dc0;
						case 120:
							array2[7] = 43;
							num3 = 235;
							continue;
						case 83:
							binaryReader.BaseStream.Position = 0L;
							num = 395;
							goto end_IL_0dbc;
						case 236:
							num8 = 110 + 112;
							num2 = 268;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 2;
						case 2:
							num9++;
							num = 337;
							goto end_IL_0dbc;
						case 351:
							num7 = 0u;
							num2 = 53;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 30;
						case 30:
							array3[11] = publicKeyToken[5];
							num2 = 276;
							if (_0087())
							{
								goto end_IL_0dc0;
							}
							goto case 274;
						case 274:
							array2[30] = 124;
							num = 261;
							goto end_IL_0dbc;
						case 402:
							try
							{
								byte[] array = new byte[num4];
								_0087();
								int num5;
								if (!_0088())
								{
									num5 = 2;
									if (1 == 0)
									{
										goto IL_3460;
									}
								}
								else
								{
									num5 = 3;
								}
								switch (num5)
								{
								case 0:
								case 2:
									break;
								default:
									goto IL_34e1;
								}
								goto IL_3460;
								IL_34e1:
								return Encoding.Unicode.GetString(array, 0, array.Length);
								IL_3460:
								Array.Copy(_008B_0091_0089, P_0 + 4, array, 0, num4);
								goto IL_34e1;
							}
							catch
							{
							}
							return "";
						case 45:
							memoryStream = new MemoryStream();
							num2 = 9;
							goto end_IL_0dc0;
						case 48:
							{
								symmetricAlgorithm = _008B_008F_0098();
								num = 14;
								goto end_IL_0dbc;
							}
							IL_17fd:
							num34 = num11 ^ num7;
							num2 = 294;
							if (0 == 0)
							{
								goto end_IL_0dc0;
							}
							goto case 130;
							IL_14a9:
							num11 += num12;
							num = 341;
							goto end_IL_0dbc;
						}
						if (num35 >= num32)
						{
							num = 93;
							goto end_IL_0dbc;
						}
						if (num35 > 0)
						{
							num = 177;
							goto end_IL_0dbc;
						}
						goto IL_04c8;
						IL_3038:
						if (num13 < num14)
						{
							num38 = num13 % num15;
							num3 = 24;
							continue;
						}
						num = 145;
						goto end_IL_0dbc;
						IL_04c8:
						num7 |= array7[array7.Length - (1 + num35)];
						num3 = 329;
						continue;
						IL_1490:
						if (num9 >= array3.Length)
						{
							num3 = 246;
							continue;
						}
						array5[num9] ^= array3[num9];
						num = 2;
						goto end_IL_0dbc;
						IL_1d6c:
						num6 = 117 - 24;
						_0087();
						if (!_0088())
						{
							num3 = 195;
							continue;
						}
						num = 141;
						goto end_IL_0dbc;
						continue;
						end_IL_0dc0:
						break;
					}
					continue;
					end_IL_0dbc:
					break;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static string _008B_008F_009D(int P_0)
		{
			int num = 193;
			if (_0088())
			{
				goto IL_001a;
			}
			goto IL_175d;
			IL_001a:
			byte[] array = default(byte[]);
			array[31] = 101;
			num = 230;
			if (!_0087())
			{
				goto IL_0042;
			}
			goto IL_175d;
			IL_0042:
			byte[] array2 = default(byte[]);
			array2[11] = 170;
			num = 203;
			if (1 == 0)
			{
				goto IL_0066;
			}
			goto IL_175d;
			IL_0066:
			int num2 = default(int);
			array[2] = (byte)num2;
			num = 325;
			if (_0088())
			{
				goto IL_0087;
			}
			goto IL_175d;
			IL_0087:
			uint num4 = default(uint);
			uint num5 = default(uint);
			uint num3 = num4 ^ num5;
			num = 283;
			goto IL_175d;
			IL_175d:
			int num11 = default(int);
			uint num12 = default(uint);
			int num10 = default(int);
			byte[] array6 = default(byte[]);
			int num13 = default(int);
			uint num14 = default(uint);
			int num15 = default(int);
			int num18 = default(int);
			int num17 = default(int);
			byte[] array4 = default(byte[]);
			BinaryReader binaryReader = default(BinaryReader);
			byte[] array3 = default(byte[]);
			IntPtr hINSTANCE2 = default(IntPtr);
			Assembly assembly = default(Assembly);
			int num26 = default(int);
			byte[] array7 = default(byte[]);
			byte[] publicKeyToken = default(byte[]);
			int num23 = default(int);
			ICryptoTransform transform = default(ICryptoTransform);
			SymmetricAlgorithm symmetricAlgorithm = default(SymmetricAlgorithm);
			byte[] array8 = default(byte[]);
			int num22 = default(int);
			int num25 = default(int);
			string text = default(string);
			int num9 = default(int);
			CryptoStream cryptoStream = default(CryptoStream);
			MemoryStream memoryStream = default(MemoryStream);
			int num16 = default(int);
			int num8 = default(int);
			int num20 = default(int);
			uint num21 = default(uint);
			int num19 = default(int);
			uint num24 = default(uint);
			_0091_0086 obj = default(_0091_0086);
			byte[] array5 = default(byte[]);
			IntPtr hINSTANCE = default(IntPtr);
			while (true)
			{
				IL_175d_2:
				int num6 = num;
				while (true)
				{
					int num7;
					switch (num6)
					{
					case 142:
						break;
					case 232:
						goto IL_0042;
					case 157:
						goto IL_0066;
					case 186:
						goto IL_0087;
					case 185:
						num11 = 17 + 82;
						num7 = 241;
						goto IL_1759;
					case 117:
						num2 = 68 - 20;
						num = 412;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 302;
					case 302:
						num12 = 0u;
						num = 398;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 228;
					case 382:
						num11 = 96 + 113;
						num7 = 70;
						goto IL_1759;
					case 198:
						array2[10] = 18;
						num = 404;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 330;
					case 330:
						array2[4] = 132;
						num = 281;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 273;
					case 273:
						array2[8] = 148;
						num = 334;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 213;
					case 213:
						array[2] = (byte)num2;
						num7 = 72;
						goto IL_1759;
					case 34:
						array[26] = (byte)num10;
						num7 = 376;
						goto IL_1759;
					case 13:
						array2[1] = (byte)num11;
						num6 = 407;
						continue;
					case 22:
						array[15] = (byte)num10;
						num = 16;
						goto IL_175d_2;
					case 72:
						num2 = 105 + 29;
						num6 = 157;
						continue;
					case 70:
						array2[9] = (byte)num11;
						num = 38;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 265;
					case 265:
						array2[11] = (byte)num11;
						num7 = 52;
						goto IL_1759;
					case 412:
						array[4] = (byte)num2;
						num = 254;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 58;
					case 58:
						array2[12] = 117;
						num7 = 189;
						goto IL_1759;
					case 127:
						array2[10] = (byte)num11;
						num6 = 258;
						continue;
					case 54:
						array6[num13 + 3] = (byte)((num14 & 0xFF000000u) >> 24);
						num = 406;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 77;
					case 77:
						if (num15 != num18 - 1)
						{
							goto IL_0568;
						}
						num = 168;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 311;
					case 429:
						array[10] = (byte)num2;
						num6 = 320;
						continue;
					case 97:
						return ((string[])_008B_0091_008D)[_008B_0091_008E[num17]];
					case 414:
						array[3] = 92;
						num7 = 137;
						goto IL_1759;
					case 67:
						num10 = 215 - 71;
						num6 = 134;
						continue;
					case 167:
						array4 = _008B_0091_008A;
						num = 113;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 42;
					case 42:
						array2[13] = 158;
						num = 371;
						goto IL_175d_2;
					case 170:
						binaryReader = new BinaryReader(typeof(_0090_009B).Assembly.GetManifestResourceStream("867cf343-c42d-4756-bcac-bef7f44beea9"));
						num = 219;
						goto IL_175d_2;
					case 183:
						num2 = 237 - 79;
						num7 = 366;
						goto IL_1759;
					case 424:
						array3 = new byte[4];
						num6 = 225;
						continue;
					case 405:
						array[1] = (byte)num10;
						num6 = 100;
						continue;
					case 196:
						_008B_0091_008A = array6;
						goto case 141;
					case 296:
						num18++;
						num6 = 231;
						continue;
					case 319:
						array2[10] = (byte)num11;
						num7 = 198;
						goto IL_1759;
					case 260:
						hINSTANCE2 = Marshal.GetHINSTANCE(assembly.GetModules()[0]);
						num7 = 402;
						goto IL_1759;
					case 48:
						_008B_0091_008E[num17] = _008B_0091_008F;
						num = 41;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 410;
					case 410:
						array2[6] = 121;
						num6 = 282;
						continue;
					case 372:
						array2[1] = 152;
						num = 21;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 222;
					case 222:
						array[30] = 103;
						num = 387;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 281;
					case 281:
						array2[4] = 117;
						num7 = 420;
						goto IL_1759;
					case 24:
						array[26] = (byte)num2;
						num6 = 84;
						continue;
					case 290:
						array[25] = 185;
						num7 = 50;
						goto IL_1759;
					case 182:
						num10 = 232 - 77;
						num = 304;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 267;
					case 310:
						array2[2] = 105;
						num6 = 6;
						continue;
					case 112:
						array[27] = 118;
						num = 303;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 221;
					case 221:
						array[9] = 48;
						num = 183;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 188;
					case 188:
						array2[10] = 130;
						num7 = 243;
						goto IL_1759;
					case 78:
						num5 = 0u;
						num = 235;
						goto IL_175d_2;
					case 199:
						array2[15] = 167;
						num7 = 298;
						goto IL_1759;
					case 359:
						array2[3] = 96;
						num7 = 44;
						goto IL_1759;
					case 136:
						array[3] = 152;
						num6 = 25;
						continue;
					case 385:
						array[26] = (byte)num10;
						num7 = 11;
						goto IL_1759;
					case 299:
						num26++;
						num7 = 164;
						goto IL_1759;
					case 1:
						array2[1] = (byte)num11;
						num6 = 177;
						continue;
					case 342:
						array[22] = 99;
						num = 413;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 231;
					case 180:
						array2[1] = (byte)num11;
						num = 239;
						goto IL_175d_2;
					case 304:
						array[10] = (byte)num10;
						num = 341;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 249;
					case 249:
						if (_008B_0091_008A.Length > 0)
						{
							num = 388;
							if (true)
							{
								goto IL_175d_2;
							}
							goto case 341;
						}
						goto case 68;
					case 341:
						array[10] = 215;
						num = 301;
						goto IL_175d_2;
					case 18:
						array7[5] = publicKeyToken[2];
						num = 362;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 400;
					case 400:
						array6[num13 + 2] = (byte)((num14 & 0xFF0000) >> 16);
						num6 = 54;
						continue;
					case 256:
						array2[8] = (byte)num11;
						num6 = 218;
						continue;
					case 156:
						num23 += 8;
						num6 = 291;
						continue;
					case 148:
						array7[13] = publicKeyToken[6];
						num7 = 209;
						goto IL_1759;
					case 346:
						array[21] = (byte)num10;
						num = 375;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 46;
					case 46:
						array[15] = 92;
						num6 = 417;
						continue;
					case 227:
						transform = symmetricAlgorithm.CreateDecryptor(array8, array7);
						num7 = 339;
						goto IL_1759;
					case 356:
						array[19] = (byte)num2;
						num6 = 110;
						continue;
					case 323:
						array2[4] = (byte)num11;
						num6 = 329;
						continue;
					case 376:
						num10 = 80 - 73;
						num = 381;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 416;
					case 416:
						array[23] = 134;
						num7 = 64;
						goto IL_1759;
					case 38:
						array2[9] = 74;
						num6 = 57;
						continue;
					case 27:
						num22 = 0;
						num6 = 122;
						continue;
					case 237:
						num10 = 39 + 90;
						num = 140;
						goto IL_175d_2;
					case 205:
						num25++;
						num6 = 322;
						continue;
					case 389:
						array[20] = 115;
						num = 120;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 273;
					case 255:
						num11 = 165 - 112;
						num6 = 278;
						continue;
					case 41:
						((string[])_008B_0091_008D)[_008B_0091_008F] = text;
						num6 = 32;
						continue;
					case 284:
						array[13] = (byte)num10;
						num6 = 355;
						continue;
					case 384:
						array[12] = (byte)num10;
						num6 = 175;
						continue;
					case 333:
						array[16] = 229;
						num7 = 131;
						goto IL_1759;
					case 282:
						num11 = 120 + 43;
						num7 = 0;
						goto IL_1759;
					case 343:
						array[19] = (byte)num10;
						num6 = 426;
						continue;
					case 8:
						num5 <<= 8;
						num = 12;
						goto IL_175d_2;
					case 88:
						array[25] = (byte)num2;
						num = 290;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 68;
					case 64:
						array[23] = 212;
						num7 = 69;
						goto IL_1759;
					case 4:
						array[1] = (byte)num2;
						num7 = 252;
						goto IL_1759;
					case 169:
						array2[15] = (byte)num11;
						num7 = 126;
						goto IL_1759;
					case 393:
						array2[7] = 116;
						num7 = 226;
						goto IL_1759;
					case 327:
						array = new byte[32];
						num7 = 293;
						goto IL_1759;
					case 340:
						array[27] = 232;
						num = 390;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 74;
					case 74:
						array2[9] = (byte)num11;
						num = 382;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 393;
					case 331:
						num4 = 0u;
						num7 = 302;
						goto IL_1759;
					case 124:
						array[6] = 201;
						num7 = 396;
						goto IL_1759;
					case 272:
						num11 = 71 + 41;
						num = 49;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 63;
					case 63:
						array2[0] = 116;
						num6 = 47;
						continue;
					case 132:
						num11 = 66 + 41;
						num7 = 83;
						goto IL_1759;
					case 147:
						array2 = new byte[16];
						num = 63;
						goto IL_175d_2;
					case 347:
						array[29] = (byte)num2;
						num = 222;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 163;
					case 163:
						array[14] = 68;
						num6 = 5;
						continue;
					case 141:
					case 399:
						if (_008B_0091_008A.Length > 0)
						{
							num6 = 309;
							continue;
						}
						goto case 119;
					case 15:
						array[20] = (byte)num10;
						num = 111;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 264;
					case 14:
						publicKeyToken = typeof(_0090_009B).Assembly.GetName().GetPublicKeyToken();
						num6 = 96;
						continue;
					case 145:
						array[12] = (byte)num2;
						num6 = 160;
						continue;
					case 89:
						num10 = 2 + 85;
						num6 = 34;
						continue;
					case 233:
						array[8] = (byte)num2;
						num7 = 279;
						goto IL_1759;
					case 420:
						num11 = 109 + 83;
						num = 323;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 357;
					case 375:
						array[21] = 103;
						num = 238;
						goto IL_175d_2;
					case 244:
						array[31] = (byte)num2;
						num7 = 174;
						goto IL_1759;
					case 33:
						array[5] = 164;
						num7 = 352;
						goto IL_1759;
					case 397:
						array[5] = (byte)num10;
						num = 33;
						goto IL_175d_2;
					case 190:
						_008B_0091_008E = new int[_008B_0091_008A.Length / 4 + 1];
						num = 68;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 370;
					case 370:
						num10 = 197 - 65;
						num7 = 391;
						goto IL_1759;
					case 236:
						num11 = 41 + 85;
						num = 169;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 395;
					case 395:
						array6 = new byte[array4.Length];
						num = 2;
						goto IL_175d_2;
					case 394:
						if (!(_008B_0091_008B == IntPtr.Zero))
						{
							goto case 424;
						}
						num = 80;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 177;
					case 177:
						num11 = 172 - 57;
						num7 = 200;
						goto IL_1759;
					case 201:
						array7[11] = publicKeyToken[5];
						num = 148;
						goto IL_175d_2;
					case 45:
						array[26] = (byte)num2;
						num = 89;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 211;
					case 212:
						array2[2] = 219;
						num6 = 272;
						continue;
					case 228:
					case 328:
						num11 = 147 - 49;
						num = 158;
						goto IL_175d_2;
					case 258:
						array2[10] = 70;
						num7 = 188;
						goto IL_1759;
					case 51:
						array3 = new byte[num9];
						num = 81;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 27;
					case 155:
						num10 = 105 + 15;
						num = 90;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 73;
					case 73:
						cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
						num = 419;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 428;
					case 218:
						num11 = 250 - 83;
						num = 363;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 418;
					case 418:
						array[28] = 232;
						num6 = 305;
						continue;
					case 66:
						array2[9] = 102;
						num = 60;
						goto IL_175d_2;
					case 175:
						array[13] = 119;
						num = 401;
						goto IL_175d_2;
					case 102:
						array2[13] = (byte)num11;
						num6 = 42;
						continue;
					case 369:
						array[7] = 43;
						num = 386;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 306;
					case 306:
						num2 = 110 + 112;
						num = 234;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 277;
					case 277:
						num10 = 128 - 46;
						num7 = 392;
						goto IL_1759;
					case 139:
						array[13] = 136;
						num7 = 101;
						goto IL_1759;
					case 62:
					case 164:
						if (num26 >= num16)
						{
							num7 = 202;
							goto IL_1759;
						}
						if (num26 > 0)
						{
							num = 378;
							goto IL_175d_2;
						}
						goto case 291;
					case 274:
						num2 = 143 - 47;
						num = 233;
						goto IL_175d_2;
					case 5:
						num2 = 226 - 75;
						num7 = 116;
						goto IL_1759;
					case 57:
						num11 = 184 - 61;
						num6 = 319;
						continue;
					case 357:
						array4 = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
						num6 = 327;
						continue;
					case 351:
						array2[2] = 109;
						num = 185;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 74;
					case 316:
						_008B_0090_008B(_008B_0091_008B, new IntPtr(_008B_0091_0091 + num8), array3, 4u, out _008B_0091_008C);
						num = 109;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 367;
					case 367:
						array[6] = 86;
						num = 124;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 348;
					case 348:
						array[4] = (byte)num10;
						num7 = 264;
						goto IL_1759;
					case 3:
						array[22] = (byte)num2;
						num6 = 262;
						continue;
					case 75:
						array[1] = (byte)num2;
						num = 294;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 94;
					case 94:
						num2 = 129 - 43;
						num = 271;
						goto IL_175d_2;
					case 76:
						num10 = 157 - 52;
						num6 = 397;
						continue;
					case 419:
						cryptoStream.Write(array4, 0, array4.Length);
						num6 = 268;
						continue;
					case 283:
						num26 = 0;
						num = 62;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 178;
					case 178:
						array[15] = 148;
						num6 = 46;
						continue;
					case 44:
						array2[3] = 109;
						num = 288;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 338;
					case 158:
						array2[2] = (byte)num11;
						num = 351;
						goto IL_175d_2;
					case 109:
					case 184:
						num9 = BitConverter.ToInt32(array3, 0);
						num6 = 51;
						continue;
					case 101:
						num10 = 117 - 24;
						num = 284;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 288;
					case 288:
						array2[3] = 11;
						num7 = 312;
						goto IL_1759;
					case 61:
						array[30] = (byte)num2;
						num6 = 361;
						continue;
					case 23:
						array[6] = (byte)num10;
						num = 39;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 396;
					case 150:
						num10 = 113 + 60;
						num = 153;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 268;
					case 268:
						cryptoStream.FlushFinalBlock();
						num6 = 350;
						continue;
					case 108:
						num10 = 47 + 36;
						num = 346;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 215;
					case 215:
						num18 = array4.Length / 4;
						num = 395;
						goto IL_175d_2;
					case 254:
						num10 = 95 + 101;
						num7 = 297;
						goto IL_1759;
					case 269:
						if (P_0 == -1)
						{
							num7 = 144;
							goto IL_1759;
						}
						goto case 113;
					case 0:
						array2[6] = (byte)num11;
						num = 71;
						goto IL_175d_2;
					case 235:
						num25 = 0;
						num6 = 59;
						continue;
					case 106:
						if (num15 == num18 - 1)
						{
							num = 383;
							if (!_0088())
							{
								goto IL_175d_2;
							}
							goto case 176;
						}
						goto IL_3169;
					case 176:
						array[25] = (byte)num10;
						num6 = 128;
						continue;
					case 321:
						array2[13] = (byte)num11;
						num = 99;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 59;
					case 59:
					case 322:
						if (num25 >= num16)
						{
							num = 318;
							if (!_0088())
							{
								goto IL_175d_2;
							}
							goto case 30;
						}
						if (num25 > 0)
						{
							num6 = 8;
							continue;
						}
						goto case 12;
					case 30:
						array[5] = (byte)num10;
						num7 = 76;
						goto IL_1759;
					case 214:
						num11 = 122 + 123;
						num = 265;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 135;
					case 135:
						array[22] = 87;
						num = 315;
						goto IL_175d_2;
					case 98:
						array[25] = 130;
						num6 = 335;
						continue;
					case 2:
						num20 = array8.Length / 4;
						num7 = 331;
						goto IL_1759;
					case 60:
						num11 = 6 + 52;
						num = 74;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 261;
					case 261:
						num10 = 157 - 52;
						num7 = 23;
						goto IL_1759;
					case 398:
						num5 = 0u;
						num6 = 364;
						continue;
					case 168:
						if (num16 > 0)
						{
							num = 78;
							goto IL_175d_2;
						}
						goto IL_0568;
					case 20:
						array2[1] = (byte)num11;
						num = 310;
						goto IL_175d_2;
					case 297:
						array[5] = (byte)num10;
						num7 = 154;
						goto IL_1759;
					case 116:
						array[15] = (byte)num2;
						num7 = 178;
						goto IL_1759;
					case 223:
						array[3] = (byte)num2;
						num7 = 136;
						goto IL_1759;
					case 263:
						cryptoStream.Close();
						num = 295;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 361;
					case 361:
						array[30] = 124;
						num = 368;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 305;
					case 305:
						array[29] = 147;
						num = 246;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 280;
					case 280:
						array[7] = (byte)num10;
						num7 = 173;
						goto IL_1759;
					case 248:
						num21 = (uint)(num19 * 4);
						num = 31;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 107;
					case 107:
						array2[14] = 33;
						num = 217;
						goto IL_175d_2;
					case 313:
						array2[0] = (byte)num11;
						num6 = 308;
						continue;
					case 203:
						num11 = 171 - 57;
						num6 = 191;
						continue;
					case 133:
						array2[15] = (byte)num11;
						num6 = 236;
						continue;
					case 378:
						num24 <<= 8;
						num = 156;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 315;
					case 315:
						num2 = 78 + 21;
						num7 = 3;
						goto IL_1759;
					case 11:
						num2 = 179 - 59;
						num = 24;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 298;
					case 298:
						num11 = 147 - 49;
						num7 = 133;
						goto IL_1759;
					case 295:
						binaryReader.Close();
						num = 167;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 109;
					case 368:
						num2 = 107 + 91;
						num7 = 86;
						goto IL_1759;
					case 85:
						array[4] = 123;
						num7 = 117;
						goto IL_1759;
					case 355:
						array[14] = 96;
						num6 = 165;
						continue;
					case 92:
						array2[5] = 160;
						num7 = 132;
						goto IL_1759;
					case 358:
						array[11] = 140;
						num = 35;
						goto IL_175d_2;
					case 191:
						array2[11] = (byte)num11;
						num = 214;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 308;
					case 308:
						array2[0] = 11;
						goto case 207;
					default:
						num = 207;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 279;
					case 279:
						array[8] = 174;
						num = 221;
						goto IL_175d_2;
					case 219:
						binaryReader.BaseStream.Position = 0L;
						num = 357;
						goto IL_175d_2;
					case 121:
						num23 = 0;
						num = 77;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 2;
					case 294:
						num2 = 242 - 80;
						num = 213;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 401;
					case 401:
						array[13] = 111;
						num = 139;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 175;
					case 262:
						num10 = 46 - 24;
						num = 289;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 43;
					case 43:
						array[31] = 134;
						num = 142;
						goto IL_175d_2;
					case 86:
						array[30] = (byte)num2;
						num7 = 250;
						goto IL_1759;
					case 374:
						num10 = 108 + 55;
						num6 = 115;
						continue;
					case 427:
						array[18] = 106;
						num6 = 152;
						continue;
					case 300:
						array[9] = 204;
						num7 = 182;
						goto IL_1759;
					case 266:
						num13 = num15 * 4;
						num6 = 248;
						continue;
					case 114:
						num17 = P_0 / 4;
						num7 = 181;
						goto IL_1759;
					case 122:
					case 257:
						goto IL_1fb0;
					case 246:
						array[29] = 90;
						num = 129;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 208;
					case 208:
						num11 = 148 - 120;
						num7 = 125;
						goto IL_1759;
					case 7:
						array2[6] = (byte)num11;
						num6 = 242;
						continue;
					case 234:
						array[31] = (byte)num2;
						num7 = 43;
						goto IL_1759;
					case 387:
						array[30] = 55;
						num7 = 197;
						goto IL_1759;
					case 377:
						array[12] = (byte)num10;
						num6 = 143;
						continue;
					case 413:
						array[22] = 135;
						num7 = 135;
						goto IL_1759;
					case 104:
						_008B_0091_008E = new int[_008B_0091_008A.Length / 4 + 1];
						num = 119;
						goto IL_175d_2;
					case 337:
						num2 = 87 + 122;
						num7 = 220;
						goto IL_1759;
					case 243:
						num11 = 215 + 17;
						num6 = 428;
						continue;
					case 99:
						array2[13] = 48;
						num = 421;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 350;
					case 350:
						_008B_0091_008A = memoryStream.ToArray();
						num = 249;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 231;
					case 231:
						num21 = 0u;
						num7 = 166;
						goto IL_1759;
					case 171:
						array[6] = 88;
						num6 = 261;
						continue;
					case 286:
						array[23] = (byte)num10;
						num = 416;
						goto IL_175d_2;
					case 166:
						num15 = 0;
						num6 = 161;
						continue;
					case 329:
						num11 = 109 + 121;
						num6 = 10;
						continue;
					case 362:
						array7[7] = publicKeyToken[3];
						num = 326;
						goto IL_175d_2;
					case 152:
						num2 = 137 + 80;
						num = 172;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 9;
					case 9:
						num10 = 55 + 37;
						num6 = 28;
						continue;
					case 253:
						array[0] = (byte)num2;
						num6 = 374;
						continue;
					case 50:
						num10 = 233 - 77;
						num7 = 176;
						goto IL_1759;
					case 379:
						array2[12] = 104;
						num7 = 332;
						goto IL_1759;
					case 149:
						array2[6] = (byte)num11;
						num6 = 410;
						continue;
					case 324:
						array[20] = (byte)num2;
						num = 146;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 226;
					case 226:
						num11 = 105 + 93;
						num6 = 408;
						continue;
					case 95:
						array[1] = (byte)num10;
						num = 336;
						goto IL_175d_2;
					case 204:
						array[9] = 154;
						num6 = 29;
						continue;
					case 402:
						_008B_0091_0091 = hINSTANCE2.ToInt32();
						num7 = 187;
						goto IL_1759;
					case 140:
						array[18] = (byte)num10;
						num = 159;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 349;
					case 349:
						array[21] = (byte)num2;
						num = 342;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 363;
					case 363:
						array2[9] = (byte)num11;
						num = 354;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 217;
					case 217:
						array2[14] = 228;
						num = 199;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 113;
					case 113:
						num16 = array4.Length % 4;
						num7 = 215;
						goto IL_1759;
					case 181:
						if (_008B_0091_008E[num17] <= 0)
						{
							num8 = BitConverter.ToInt32(_008B_0091_008A, P_0);
							num = 394;
							if (true)
							{
								goto IL_175d_2;
							}
							goto case 414;
						}
						num = 97;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 301;
					case 301:
						num2 = 50 - 26;
						num7 = 429;
						goto IL_1759;
					case 344:
						num11 = 210 + 3;
						num6 = 256;
						continue;
					case 314:
						array[16] = (byte)num10;
						num6 = 55;
						continue;
					case 90:
						array[19] = (byte)num10;
						num7 = 370;
						goto IL_1759;
					case 326:
						array7[9] = publicKeyToken[4];
						num = 201;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 221;
					case 36:
						_008B_0091_008B = _008B_0090_008C((uint)obj, 1, (uint)Process.GetCurrentProcess().Id);
						num7 = 424;
						goto IL_1759;
					case 275:
						num10 = 50 + 49;
						num = 95;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 241;
					case 241:
						array2[2] = (byte)num11;
						num6 = 212;
						continue;
					case 229:
						array[0] = 92;
						num = 409;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 207;
					case 207:
						num11 = 21 + 47;
						num7 = 1;
						goto IL_1759;
					case 334:
						num11 = 26 + 75;
						num = 195;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 93;
					case 93:
						array2[7] = 206;
						num = 273;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 125;
					case 125:
						array2[5] = (byte)num11;
						num = 360;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 395;
					case 417:
						num10 = 121 - 36;
						num = 22;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 411;
					case 411:
					case 423:
						array5 = _008B_0090_008F(array3);
						num = 292;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 428;
					case 428:
						array2[10] = (byte)num11;
						num6 = 232;
						continue;
					case 128:
						array[25] = 236;
						num7 = 192;
						goto IL_1759;
					case 174:
						array[31] = 111;
						num = 306;
						goto IL_175d_2;
					case 100:
						num2 = 164 + 81;
						num = 75;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 65;
					case 65:
						num22++;
						num = 257;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 360;
					case 360:
						num11 = 209 - 69;
						num = 7;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 307;
					case 307:
						array2[5] = (byte)num11;
						num7 = 208;
						goto IL_1759;
					case 119:
						assembly = typeof(_0090_009B).Assembly;
						num6 = 287;
						continue;
					case 47:
						num11 = 226 - 75;
						num = 313;
						goto IL_175d_2;
					case 31:
						num12 = (uint)((array8[num21 + 3] << 24) | (array8[num21 + 2] << 16) | (array8[num21 + 1] << 8) | array8[num21]);
						num = 338;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 250;
					case 250:
						num2 = 48 + 56;
						num = 244;
						goto IL_175d_2;
					case 320:
						array[11] = 134;
						num = 358;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 210;
					case 210:
						array6[num13 + 1] = (byte)((num14 & 0xFF00) >> 8);
						num6 = 400;
						continue;
					case 373:
						num10 = 124 + 98;
						num6 = 385;
						continue;
					case 154:
						num10 = 217 - 72;
						num = 30;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 172;
					case 172:
						array[18] = (byte)num2;
						num7 = 155;
						goto IL_1759;
					case 159:
						array[18] = 118;
						num7 = 206;
						goto IL_1759;
					case 123:
						array[27] = 78;
						num7 = 340;
						goto IL_1759;
					case 267:
					case 317:
					{
						uint num27 = num4;
						uint num28 = num4;
						uint num29 = 1341288995u;
						uint num30 = 611865032u;
						uint num31 = 1940111450u;
						uint num32 = num28;
						uint num33 = 1468126237u;
						uint num34 = 1873844383u;
						num31 += num33;
						uint num35 = ((num30 >> 9) | (num30 << 23)) ^ num29;
						uint num36 = num35 & 0x55555555;
						num35 &= 0xAAAAAAAAu;
						num30 = (num35 >> 1) | (num36 << 1);
						ulong num37 = num31 * 1695230583;
						if (num37 == 0)
						{
							num37--;
						}
						num29 = (uint)(num29 * num29 % num37);
						if ((double)num33 == 0.0)
						{
							num33--;
						}
						uint num38 = (uint)(103265678.0 / (double)num33 + (double)num33);
						num33 = (uint)((uint)(((short)num31 + -3288) * (int)num38) + (short)num31);
						num34 -= num31;
						num32 ^= num32 >> 1;
						num32 += num29;
						num32 ^= num32 >> 6;
						num32 += num33;
						num32 ^= num32 << 11;
						num32 += num34;
						num32 = (((num31 << 18) - num30) ^ num33) - num32;
						num4 = num27 + (uint)(double)num32;
						num = 106;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 216;
					}
					case 216:
						num10 = 67 + 34;
						num6 = 240;
						continue;
					case 211:
						array2[14] = (byte)num11;
						num6 = 107;
						continue;
					case 289:
						array[22] = (byte)num10;
						num7 = 91;
						goto IL_1759;
					case 206:
						array[18] = 68;
						num6 = 427;
						continue;
					case 309:
						_008B_0091_008D = new string[_008B_0091_008A.Length / 4 + 1];
						num6 = 104;
						continue;
					case 80:
						obj = (_0091_0086)16;
						num7 = 36;
						goto IL_1759;
					case 192:
						num2 = 158 - 52;
						num6 = 105;
						continue;
					case 386:
						num10 = 34 + 124;
						num7 = 280;
						goto IL_1759;
					case 105:
						array[26] = (byte)num2;
						num6 = 373;
						continue;
					case 422:
						num11 = 179 - 59;
						num7 = 307;
						goto IL_1759;
					case 336:
						num2 = 212 - 70;
						num = 4;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 252;
					case 252:
						num10 = 133 - 44;
						num6 = 405;
						continue;
					case 364:
						if (num16 > 0)
						{
							num6 = 296;
							continue;
						}
						goto case 231;
					case 293:
						array[0] = 177;
						num = 229;
						goto IL_175d_2;
					case 245:
						num5 = (uint)((array4[num21 + 3] << 24) | (array4[num21 + 2] << 16) | (array4[num21 + 1] << 8) | array4[num21]);
						num7 = 425;
						goto IL_1759;
					case 240:
						array[28] = (byte)num10;
						num6 = 67;
						continue;
					case 151:
						num2 = 216 + 2;
						num6 = 253;
						continue;
					case 6:
						array2[2] = 228;
						_0088();
						if (!_0087())
						{
							num6 = 141;
							continue;
						}
						num = 328;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 304;
					case 111:
						array[20] = 84;
						num = 389;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 321;
					case 408:
						array2[7] = (byte)num11;
						num6 = 93;
						continue;
					case 84:
						num2 = 83 + 115;
						num = 45;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 364;
					case 409:
						array[0] = 146;
						num6 = 40;
						continue;
					case 193:
						if (_008B_0091_008A.Length == 0)
						{
							num7 = 170;
							goto IL_1759;
						}
						goto case 114;
					case 332:
						num11 = 236 - 78;
						num6 = 102;
						continue;
					case 19:
						symmetricAlgorithm.Mode = CipherMode.CBC;
						num = 227;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 54;
					case 12:
						num5 |= array4[array4.Length - (1 + num25)];
						num = 205;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 230;
					case 230:
						array8 = array;
						num = 147;
						goto IL_175d_2;
					case 25:
						num2 = 162 - 54;
						num = 56;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 181;
					case 21:
						num11 = 179 - 59;
						num7 = 13;
						goto IL_1759;
					case 396:
						array[7] = 149;
						num = 369;
						goto IL_175d_2;
					case 239:
						num11 = 140 + 50;
						num = 20;
						goto IL_175d_2;
					case 56:
						array[3] = (byte)num2;
						num = 9;
						if (_0088())
						{
							goto case 59;
						}
						goto IL_175d_2;
					case 209:
						array7[15] = publicKeyToken[7];
						num7 = 27;
						goto IL_1759;
					case 82:
						array2[12] = (byte)num11;
						num = 58;
						goto IL_175d_2;
					case 49:
						array2[3] = (byte)num11;
						num7 = 359;
						goto IL_1759;
					case 381:
						array[26] = (byte)num10;
						num = 112;
						if (_0088())
						{
							goto case 339;
						}
						goto IL_175d_2;
					case 91:
						num10 = 127 - 42;
						num = 286;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 365;
					case 365:
						array[16] = (byte)num10;
						num = 333;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 251;
					case 251:
						array7 = array2;
						num = 14;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 179;
					case 179:
						array2[15] = 66;
						num7 = 251;
						goto IL_1759;
					case 312:
						array2[4] = 21;
						num = 330;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 388;
					case 388:
						_008B_0091_008D = new string[_008B_0091_008A.Length / 4 + 1];
						num = 190;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 120;
					case 55:
						num10 = 121 + 76;
						num = 365;
						goto IL_175d_2;
					case 403:
						array[11] = 129;
						num7 = 130;
						goto IL_1759;
					case 391:
						array[19] = (byte)num10;
						num = 259;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 220;
					case 220:
						array[25] = (byte)num2;
						num = 98;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 352;
					case 352:
						array[5] = 184;
						num7 = 171;
						goto IL_1759;
					case 10:
						array2[4] = (byte)num11;
						num7 = 255;
						goto IL_1759;
					case 96:
						if (publicKeyToken != null)
						{
							num = 87;
							goto IL_175d_2;
						}
						goto case 27;
					case 16:
						num10 = 61 + 62;
						num6 = 314;
						continue;
					case 110:
						array[19] = 38;
						num6 = 79;
						continue;
					case 35:
						array[11] = 111;
						num = 26;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 195;
					case 195:
						array2[8] = (byte)num11;
						num = 344;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 68;
					case 68:
						memoryStream.Close();
						num7 = 263;
						goto IL_1759;
					case 26:
						array[11] = 155;
						num7 = 403;
						goto IL_1759;
					case 259:
						num2 = 119 + 96;
						num = 356;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 138;
					case 138:
					case 161:
						if (num15 < num18)
						{
							num19 = num15 % num20;
							num7 = 266;
							goto IL_1759;
						}
						num = 196;
						goto IL_175d_2;
					case 383:
						if (num16 > 0)
						{
							num = 186;
							if (true)
							{
								goto IL_175d_2;
							}
							goto case 103;
						}
						goto IL_3169;
					case 103:
						num2 = 17 + 67;
						num7 = 223;
						goto IL_1759;
					case 407:
						num11 = 206 - 68;
						num7 = 180;
						goto IL_1759;
					case 380:
						_008B_0090_008B(_008B_0091_008B, new IntPtr(_008B_0091_0091 + num8 + 4), array3, Convert.ToUInt32(num9), out _008B_0091_008C);
						num7 = 423;
						goto IL_1759;
					case 120:
						num2 = 197 + 29;
						num6 = 324;
						continue;
					case 69:
						array[24] = 104;
						num7 = 37;
						goto IL_1759;
					case 37:
						array[24] = 168;
						num6 = 162;
						continue;
					case 291:
						array6[num13 + num26] = (byte)((num3 & num24) >> num23);
						num7 = 299;
						goto IL_1759;
					case 264:
						array[4] = 86;
						num7 = 85;
						goto IL_1759;
					case 390:
						num10 = 89 + 113;
						num7 = 17;
						goto IL_1759;
					case 165:
						array[14] = 156;
						num = 163;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 247;
					case 247:
						num10 = 29 + 113;
						num6 = 15;
						continue;
					case 146:
						array[21] = 88;
						num = 108;
						goto IL_175d_2;
					case 187:
						hINSTANCE = Marshal.GetHINSTANCE(assembly.GetModules()[0]);
						num6 = 118;
						continue;
					case 303:
						array[27] = 184;
						num7 = 123;
						goto IL_1759;
					case 202:
					case 406:
						num15++;
						num = 138;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 52;
					case 52:
						array2[11] = 57;
						num7 = 345;
						goto IL_1759;
					case 338:
						num24 = 255u;
						num6 = 121;
						continue;
					case 79:
						num10 = 2 + 77;
						num = 343;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 271;
					case 278:
						array2[4] = (byte)num11;
						num7 = 92;
						goto IL_1759;
					case 271:
						array[8] = (byte)num2;
						num7 = 274;
						goto IL_1759;
					case 71:
						array2[6] = 228;
						num7 = 393;
						goto IL_1759;
					case 426:
						array[19] = 105;
						num7 = 247;
						goto IL_1759;
					case 276:
						array[6] = 39;
						num7 = 367;
						goto IL_1759;
					case 242:
						num11 = 223 - 74;
						num7 = 149;
						goto IL_1759;
					case 28:
						array[3] = (byte)num10;
						num = 414;
						goto IL_175d_2;
					case 143:
						num10 = 135 - 46;
						num6 = 384;
						continue;
					case 285:
						array[17] = (byte)num2;
						num = 150;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 32;
					case 32:
						_008B_0091_008F++;
						num = 430;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 353;
					case 353:
						num10 = 44 + 76;
						num7 = 348;
						goto IL_1759;
					case 126:
						array2[15] = 94;
						num = 179;
						goto IL_175d_2;
					case 29:
						num10 = 189 - 63;
						num = 311;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 118;
					case 118:
						_008B_0091_0090 = hINSTANCE.ToInt64();
						num6 = 114;
						continue;
					case 137:
						array[3] = 93;
						num6 = 353;
						continue;
					case 83:
						array2[5] = (byte)num11;
						num7 = 422;
						goto IL_1759;
					case 189:
						array2[12] = 114;
						num7 = 379;
						goto IL_1759;
					case 371:
						num11 = 129 - 43;
						num = 321;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 154;
					case 131:
						num2 = 61 + 54;
						num = 285;
						goto IL_175d_2;
					case 53:
						array7[3] = publicKeyToken[1];
						num6 = 18;
						continue;
					case 425:
						num4 += num12;
						num6 = 267;
						continue;
					case 17:
						array[28] = (byte)num10;
						num7 = 216;
						goto IL_1759;
					case 129:
						array[29] = 112;
						num = 224;
						if (true)
						{
							goto IL_175d_2;
						}
						goto case 162;
					case 162:
						array[24] = 158;
						num7 = 337;
						goto IL_1759;
					case 134:
						array[28] = (byte)num10;
						num = 418;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 194;
					case 194:
						array7[1] = publicKeyToken[0];
						num = 53;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 97;
					case 153:
						array[17] = (byte)num10;
						num = 277;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 354;
					case 354:
						array2[9] = 151;
						num7 = 66;
						goto IL_1759;
					case 115:
						array[1] = (byte)num10;
						num = 275;
						goto IL_175d_2;
					case 39:
						array[6] = 201;
						num = 276;
						goto IL_175d_2;
					case 325:
						array[2] = 89;
						num = 103;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 224;
					case 224:
						num2 = 160 + 91;
						num6 = 347;
						continue;
					case 238:
						num2 = 145 - 78;
						num7 = 349;
						goto IL_1759;
					case 270:
						array6[num13] = (byte)(num14 & 0xFF);
						num6 = 210;
						continue;
					case 160:
						num10 = 194 - 64;
						num7 = 377;
						goto IL_1759;
					case 173:
						array[8] = 124;
						num = 94;
						if (0 == 0)
						{
							goto IL_175d_2;
						}
						goto case 87;
					case 87:
						if (publicKeyToken.Length <= 0)
						{
							goto case 27;
						}
						num7 = 194;
						goto IL_1759;
					case 197:
						num2 = 207 - 69;
						num = 61;
						if (_0087())
						{
							goto IL_175d_2;
						}
						goto case 366;
					case 366:
						array[9] = (byte)num2;
						num6 = 204;
						continue;
					case 421:
						num11 = 214 - 71;
						num6 = 211;
						continue;
					case 130:
						array[12] = 152;
						num = 415;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 200;
					case 200:
						array2[1] = (byte)num11;
						num7 = 372;
						goto IL_1759;
					case 318:
						num4 += num12;
						num7 = 317;
						goto IL_1759;
					case 404:
						num11 = 204 - 68;
						num7 = 127;
						goto IL_1759;
					case 415:
						num2 = 26 + 69;
						num6 = 145;
						continue;
					case 40:
						array[0] = 172;
						num7 = 151;
						goto IL_1759;
					case 311:
						array[9] = (byte)num10;
						num = 300;
						if (!_0088())
						{
							goto IL_175d_2;
						}
						goto case 356;
					case 392:
						array[17] = (byte)num10;
						num7 = 237;
						goto IL_1759;
					case 335:
						num2 = 36 + 1;
						num7 = 88;
						goto IL_1759;
					case 345:
						num11 = 122 + 101;
						num6 = 82;
						continue;
					case 430:
						return text;
					case 292:
						text = Encoding.Unicode.GetString(array5, 0, array5.Length);
						num6 = 48;
						continue;
					case 81:
						if (IntPtr.Size == 4)
						{
							num = 380;
							if (true)
							{
								goto IL_175d_2;
							}
							goto case 90;
						}
						_008B_0090_008B(_008B_0091_008B, new IntPtr(_008B_0091_0090 + num8 + 4), array3, Convert.ToUInt32(num9), out _008B_0091_008C);
						num = 411;
						goto IL_175d_2;
					case 225:
						if (IntPtr.Size == 4)
						{
							num = 316;
							goto IL_175d_2;
						}
						_008B_0090_008B(_008B_0091_008B, new IntPtr(_008B_0091_0090 + num8), array3, 4u, out _008B_0091_008C);
						num7 = 184;
						goto IL_1759;
					case 339:
						memoryStream = new MemoryStream();
						num6 = 73;
						continue;
					case 287:
						if (IntPtr.Size == 4)
						{
							num = 260;
							if (true)
							{
								goto IL_175d_2;
							}
							goto case 409;
						}
						goto case 187;
					case 144:
						{
							symmetricAlgorithm = _008B_008F_0098();
							num7 = 19;
							goto IL_1759;
						}
						IL_1759:
						num = num7;
						goto IL_175d_2;
						IL_0568:
						num21 = (uint)num13;
						num7 = 245;
						goto IL_1759;
						IL_3169:
						num14 = num4 ^ num5;
						num6 = 270;
						continue;
					}
					break;
					IL_1fb0:
					if (num22 >= array7.Length)
					{
						num6 = 269;
						continue;
					}
					array8[num22] ^= array7[num22];
					num6 = 65;
				}
				break;
			}
			goto IL_001a;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_008F_009E(string P_0)
		{
			byte[] array = Convert.FromBase64String(P_0);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		[DllImport("kernel32.dll", EntryPoint = "VirtualProtect")]
		private static extern int _008B_0090_0086(IntPtr P_0, int P_1, int P_2, ref int P_3);

		[MethodImpl(MethodImplOptions.NoInlining)]
		[_0090_009D(typeof(_0090_009D._0090_009E<object>[]))]
		static void _008B_0090_0088()
		{
			int num = 412;
			int num13 = default(int);
			byte[] array3 = default(byte[]);
			byte[] array = default(byte[]);
			int num12 = default(int);
			int num41 = default(int);
			int num11 = default(int);
			byte[] publicKeyToken = default(byte[]);
			int num22 = default(int);
			int num24 = default(int);
			uint num20 = default(uint);
			byte[] array4 = default(byte[]);
			uint num23 = default(uint);
			uint num16 = default(uint);
			uint num39 = default(uint);
			int num9 = default(int);
			int num43 = default(int);
			int num42 = default(int);
			byte[] array6 = default(byte[]);
			int num18 = default(int);
			uint num15 = default(uint);
			IntPtr hINSTANCE = default(IntPtr);
			Assembly assembly = default(Assembly);
			int num44 = default(int);
			int num38 = default(int);
			byte[] array2 = default(byte[]);
			int num17 = default(int);
			IntPtr intPtr3 = default(IntPtr);
			byte[] array7 = default(byte[]);
			BinaryReader binaryReader = default(BinaryReader);
			byte[] buffer = default(byte[]);
			byte[] array5 = default(byte[]);
			int num40 = default(int);
			IntPtr intPtr2 = default(IntPtr);
			int num25 = default(int);
			uint num19 = default(uint);
			uint num21 = default(uint);
			_0091_0086 obj2 = default(_0091_0086);
			int num14 = default(int);
			IntPtr intPtr = default(IntPtr);
			int num8 = default(int);
			int num10 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					int num3 = num2;
					while (true)
					{
						IntPtr zero;
						switch (num3)
						{
						case 294:
							num13 = 136 + 8;
							num3 = 413;
							continue;
						case 328:
							break;
						case 465:
							goto IL_0045;
						case 234:
							goto IL_005e;
						case 444:
							goto IL_0070;
						case 324:
							array3[2] = 196;
							num2 = 428;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 173;
						case 173:
							array[17] = 111;
							num3 = 399;
							continue;
						case 323:
							array3[3] = (byte)num12;
							num3 = 163;
							continue;
						case 44:
							num12 = 216 + 0;
							num3 = 308;
							continue;
						case 407:
							array3[0] = (byte)num12;
							num3 = 130;
							continue;
						case 429:
							num13 = 101 + 123;
							num3 = 392;
							continue;
						case 56:
							array3[10] = 71;
							num2 = 169;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 147;
						case 257:
							goto IL_0157;
						case 107:
							zero = IntPtr.Zero;
							num2 = 174;
							goto end_IL_12db;
						case 450:
							num12 = 162 - 81;
							num2 = 267;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 60;
						case 60:
							num12 = 249 - 83;
							num3 = 93;
							continue;
						case 267:
							array3[13] = (byte)num12;
							num2 = 273;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 301;
						case 301:
							num41 = 0;
							num3 = 3;
							continue;
						case 402:
							goto IL_01e5;
						case 395:
							goto IL_01f8;
						case 310:
							array3[14] = 112;
							num2 = 291;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 238;
						case 238:
							array3[8] = 218;
							num2 = 378;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 126;
						case 126:
							array[11] = (byte)num11;
							num2 = 1;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 70;
						case 70:
							array3[6] = 136;
							num = 424;
							goto end_IL_12d7;
						case 401:
							Array.Clear(publicKeyToken, 0, publicKeyToken.Length);
							num = 90;
							goto end_IL_12d7;
						case 177:
							num11 = 198 - 66;
							num2 = 190;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 249;
						case 8:
							num12 = 132 - 44;
							num = 296;
							goto end_IL_12d7;
						case 424:
							num12 = 111 - 14;
							num3 = 188;
							continue;
						case 435:
							array[7] = (byte)num13;
							num2 = 55;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 224;
						case 18:
							array[21] = (byte)num13;
							num2 = 13;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 441;
						case 366:
							array[23] = (byte)num13;
							num = 445;
							goto end_IL_12d7;
						case 454:
							num11 = 198 - 124;
							num = 439;
							goto end_IL_12d7;
						case 184:
							num13 = 240 - 80;
							num3 = 269;
							continue;
						case 163:
							array3[3] = 56;
							num = 199;
							goto end_IL_12d7;
						case 1:
							num11 = 99 + 36;
							num3 = 131;
							continue;
						case 24:
							num22 = num24 * 4;
							num = 241;
							goto end_IL_12d7;
						case 68:
							num13 = 248 - 82;
							num3 = 438;
							continue;
						case 235:
							num20 = 0u;
							num3 = 337;
							continue;
						case 139:
							array4[num22 + 1] = (byte)((num23 & 0xFF00) >> 8);
							num3 = 71;
							continue;
						case 181:
							array[9] = 55;
							num = 79;
							goto end_IL_12d7;
						case 144:
							array3[12] = 108;
							num2 = 459;
							goto end_IL_12db;
						case 103:
						case 403:
							num16 = num16;
							num2 = 461;
							goto end_IL_12db;
						case 442:
							array[6] = 236;
							num3 = 219;
							continue;
						case 226:
							num11 = 231 - 77;
							num = 161;
							goto end_IL_12d7;
						case 336:
							num39 <<= 8;
							num3 = 247;
							continue;
						case 7:
							goto IL_04cf;
						case 330:
							array3[15] = (byte)num12;
							num = 113;
							goto end_IL_12d7;
						case 412:
							if (!_008B_0091_0092)
							{
								num2 = 251;
								if (!_0088())
								{
									goto end_IL_12db;
								}
								goto case 46;
							}
							return;
						case 104:
							array[10] = 121;
							num3 = 346;
							continue;
						case 214:
							array[20] = 122;
							num3 = 307;
							continue;
						case 457:
							array3[4] = (byte)num12;
							num3 = 261;
							continue;
						case 152:
							num12 = 172 - 57;
							num2 = 51;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 432;
						case 432:
							array3[10] = 141;
							num3 = 196;
							continue;
						case 145:
							num11 = 162 + 24;
							num2 = 309;
							goto end_IL_12db;
						case 265:
							array[30] = (byte)num11;
							num2 = 226;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 210;
						case 331:
							num11 = 96 + 50;
							num2 = 290;
							if (!_0087())
							{
								goto case 58;
							}
							goto end_IL_12db;
						case 438:
							array[25] = (byte)num13;
							num2 = 303;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 273;
						case 273:
							num12 = 49 + 105;
							num2 = 62;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 295;
						case 295:
							array[17] = (byte)num13;
							num = 231;
							goto end_IL_12d7;
						case 365:
							array[21] = (byte)num13;
							num3 = 345;
							continue;
						case 262:
							num11 = 248 - 82;
							num2 = 244;
							goto end_IL_12db;
						case 22:
							num13 = 93 + 26;
							num3 = 171;
							continue;
						case 108:
							array3[2] = (byte)num12;
							num = 20;
							goto end_IL_12d7;
						case 259:
							array3[15] = (byte)num12;
							num = 134;
							goto end_IL_12d7;
						case 174:
							num9 = 0;
							num2 = 340;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 382;
						case 382:
							num12 = 110 + 1;
							num2 = 280;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 161;
						case 161:
							array[30] = (byte)num11;
							num2 = 454;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 441;
						case 441:
							num43++;
							num = 240;
							goto end_IL_12d7;
						case 319:
							array[11] = (byte)num11;
							num2 = 327;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 339;
						case 339:
							array3[3] = 94;
							num = 39;
							goto end_IL_12d7;
						case 352:
							num13 = 165 + 75;
							num = 151;
							goto end_IL_12d7;
						case 286:
							array[23] = 105;
							num = 142;
							goto end_IL_12d7;
						case 203:
							array3[1] = 159;
							num2 = 254;
							goto end_IL_12db;
						case 421:
							num12 = 7 + 61;
							num2 = 457;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 309;
						case 309:
							array[31] = (byte)num11;
							num = 135;
							goto end_IL_12d7;
						case 4:
							num42++;
							num2 = 332;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 97;
						case 97:
							array[22] = 111;
							num = 198;
							goto end_IL_12d7;
						case 128:
							array[27] = (byte)num11;
							num3 = 344;
							continue;
						case 135:
							array6 = array;
							num2 = 10;
							goto end_IL_12db;
						case 284:
							num11 = 100 - 8;
							num2 = 63;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 239;
						case 34:
							array3[10] = 105;
							num = 363;
							goto end_IL_12d7;
						case 396:
							num11 = 75 - 60;
							num3 = 279;
							continue;
						case 326:
							array3[15] = (byte)num12;
							num2 = 86;
							goto end_IL_12db;
						case 195:
							array[17] = 92;
							num2 = 173;
							goto end_IL_12db;
						case 415:
							array[7] = 107;
							num = 367;
							goto end_IL_12d7;
						case 210:
							array = new byte[32];
							num2 = 96;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 120;
						case 406:
							num12 = 194 - 121;
							num = 407;
							goto end_IL_12d7;
						case 41:
							array[20] = 122;
							num2 = 333;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 408;
						case 408:
							array[12] = (byte)num11;
							num3 = 433;
							continue;
						case 269:
							array[22] = (byte)num13;
							num3 = 97;
							continue;
						case 370:
							num13 = 153 - 51;
							num = 447;
							goto end_IL_12d7;
						case 333:
							array[21] = 15;
							num2 = 312;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 57;
						case 57:
							array3[3] = (byte)num12;
							num = 423;
							goto end_IL_12d7;
						case 263:
							array[21] = (byte)num11;
							num2 = 29;
							goto end_IL_12db;
						case 466:
							array[19] = 143;
							num = 214;
							goto end_IL_12d7;
						case 118:
							num11 = 144 - 48;
							num = 455;
							goto end_IL_12d7;
						case 206:
							num11 = 243 - 81;
							num2 = 128;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 139;
						case 232:
							num12 = 72 + 83;
							num2 = 23;
							goto end_IL_12db;
						case 149:
							array[18] = (byte)num11;
							num2 = 452;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 356;
						case 311:
							array[29] = 162;
							num = 65;
							goto end_IL_12d7;
						case 318:
							if (num24 == num18 - 1)
							{
								num = 246;
								goto end_IL_12d7;
							}
							goto IL_3588;
						case 162:
							if (publicKeyToken.Length > 0)
							{
								num3 = 380;
								continue;
							}
							goto case 90;
						case 63:
							array[18] = (byte)num11;
							num = 328;
							goto end_IL_12d7;
						case 304:
							array[29] = 3;
							num2 = 179;
							goto end_IL_12db;
						case 99:
							num13 = 10 + 49;
							num2 = 350;
							goto end_IL_12db;
						case 381:
							array[23] = 174;
							num = 202;
							goto end_IL_12d7;
						case 33:
							array[16] = 72;
							num = 429;
							goto end_IL_12d7;
						case 138:
							num15 = 0u;
							num2 = 95;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 29;
						case 29:
							num11 = 76 - 61;
							num2 = 320;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 229;
						case 186:
							array[8] = 164;
							num2 = 352;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 106;
						case 106:
							num13 = 59 + 35;
							num = 365;
							goto end_IL_12d7;
						case 308:
							array3[7] = (byte)num12;
							num3 = 238;
							continue;
						case 47:
							array[29] = (byte)num11;
							goto case 59;
						case 427:
							num11 = 45 + 30;
							num = 170;
							goto end_IL_12d7;
						case 61:
							array[12] = (byte)num11;
							num = 209;
							goto end_IL_12d7;
						case 390:
							array[2] = 207;
							num3 = 243;
							continue;
						case 446:
							hINSTANCE = Marshal.GetHINSTANCE(assembly.GetModules()[0]);
							num3 = 176;
							continue;
						case 26:
							array3[11] = 239;
							num2 = 17;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 298;
						case 298:
							array[2] = (byte)num13;
							num2 = 390;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 344;
						case 344:
							num11 = 24 + 114;
							num = 283;
							goto end_IL_12d7;
						case 83:
							array[29] = (byte)num11;
							num = 182;
							goto end_IL_12d7;
						case 337:
							num24 = 0;
							num3 = 338;
							continue;
						case 422:
							array3[4] = (byte)num12;
							num2 = 421;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 223;
						case 223:
							array[3] = (byte)num11;
							num2 = 343;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 199;
						case 199:
							num12 = 33 + 92;
							num3 = 422;
							continue;
						case 355:
							num44 = array6.Length / 4;
							num3 = 80;
							continue;
						case 78:
							num12 = 249 - 83;
							num = 9;
							goto end_IL_12d7;
						case 346:
							num13 = 162 - 54;
							num2 = 146;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 354;
						case 354:
							num13 = 234 - 78;
							num3 = 91;
							continue;
						case 260:
							num11 = 104 + 70;
							num3 = 115;
							continue;
						case 193:
							num12 = 28 + 18;
							num = 393;
							goto end_IL_12d7;
						case 448:
							array3[1] = (byte)num12;
							num2 = 460;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 430;
						case 430:
							array[4] = (byte)num13;
							num3 = 383;
							continue;
						case 317:
							array3[3] = (byte)num12;
							num2 = 339;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 433;
						case 423:
							array3[3] = 148;
							num3 = 397;
							continue;
						case 287:
						case 332:
							if (num42 >= num38)
							{
								num = 379;
								goto end_IL_12d7;
							}
							if (num42 > 0)
							{
								num2 = 336;
								if (true)
								{
									goto end_IL_12db;
								}
								goto case 227;
							}
							goto case 66;
						case 89:
							array2[7] = publicKeyToken[3];
							num3 = 402;
							continue;
						case 14:
							array[9] = (byte)num13;
							num = 181;
							goto end_IL_12d7;
						case 151:
							array[8] = (byte)num13;
							num2 = 216;
							goto end_IL_12db;
						case 190:
							array[10] = (byte)num11;
							num2 = 38;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 437;
						case 279:
							array[26] = (byte)num11;
							num2 = 187;
							goto end_IL_12db;
						case 312:
							num11 = 90 + 41;
							num3 = 285;
							continue;
						case 409:
							num13 = 130 - 43;
							num = 248;
							goto end_IL_12d7;
						case 231:
							array[18] = 92;
							num2 = 143;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 240;
						case 75:
							array[14] = 48;
							num = 400;
							goto end_IL_12d7;
						case 157:
							array3[9] = (byte)num12;
							num = 34;
							goto end_IL_12d7;
						case 85:
							num11 = 72 + 117;
							num2 = 82;
							goto end_IL_12db;
						case 268:
							num12 = 226 + 7;
							num2 = 157;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 45;
						case 45:
							array2[15] = publicKeyToken[7];
							num2 = 401;
							goto end_IL_12db;
						case 237:
							array2[3] = publicKeyToken[1];
							num = 101;
							goto end_IL_12d7;
						case 132:
							num11 = 169 + 39;
							num3 = 377;
							continue;
						case 110:
						case 314:
							if (num17 >= num38)
							{
								num2 = 103;
								if (!_0088())
								{
									goto end_IL_12db;
								}
								goto case 0;
							}
							if (num17 > 0)
							{
								num2 = 437;
								if (!_0088())
								{
									goto end_IL_12db;
								}
								goto case 215;
							}
							goto case 386;
						case 142:
							array[23] = 174;
							num3 = 449;
							continue;
						case 123:
							array3[5] = (byte)num12;
							num2 = 193;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 452;
						case 452:
							num13 = 161 - 53;
							num = 137;
							goto end_IL_12d7;
						case 125:
							array3[7] = 150;
							num = 44;
							goto end_IL_12d7;
						case 385:
							array[16] = (byte)num11;
							num2 = 371;
							goto end_IL_12db;
						case 191:
							num42 = 0;
							num3 = 287;
							continue;
						case 84:
							num13 = 42 + 58;
							num2 = 271;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 146;
						case 146:
							array[10] = (byte)num13;
							num2 = 212;
							goto end_IL_12db;
						case 50:
							num13 = 198 - 66;
							num3 = 76;
							continue;
						case 276:
							num12 = 111 - 7;
							num3 = 121;
							continue;
						case 55:
							num13 = 25 + 84;
							num2 = 277;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 51;
						case 51:
							array3[9] = (byte)num12;
							num2 = 382;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 58;
						case 58:
						case 278:
							_008B_0090_0086(intPtr3, 4, num9, ref num9);
							num3 = 313;
							continue;
						case 362:
							num13 = 151 - 50;
							num = 249;
							goto end_IL_12d7;
						case 413:
							array[4] = (byte)num13;
							num3 = 114;
							continue;
						case 239:
							array[15] = 94;
							num3 = 22;
							continue;
						case 140:
							array7 = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
							num3 = 210;
							continue;
						case 416:
							array[28] = 146;
							goto case 304;
						default:
							num3 = 304;
							continue;
						case 297:
							array[23] = 56;
							num3 = 286;
							continue;
						case 169:
							num12 = 175 - 58;
							num2 = 275;
							goto end_IL_12db;
						case 252:
							array[21] = (byte)num13;
							num = 136;
							goto end_IL_12d7;
						case 258:
							num11 = 62 + 74;
							num2 = 149;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 425;
						case 425:
							num12 = 67 + 99;
							num2 = 358;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 211;
						case 211:
							array[25] = (byte)num11;
							num2 = 250;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 159;
						case 159:
							num11 = 22 + 119;
							num = 227;
							goto end_IL_12d7;
						case 87:
							num11 = 167 + 69;
							num = 453;
							goto end_IL_12d7;
						case 250:
							num13 = 175 - 58;
							num2 = 436;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 120;
						case 313:
							num41++;
							num = 0;
							goto end_IL_12d7;
						case 464:
							num12 = 187 - 62;
							num2 = 123;
							goto end_IL_12db;
						case 5:
							array[0] = 47;
							num3 = 289;
							continue;
						case 245:
							array3[4] = (byte)num12;
							num = 464;
							goto end_IL_12d7;
						case 178:
							array[20] = 137;
							num3 = 67;
							continue;
						case 387:
							num11 = 164 - 54;
							num3 = 434;
							continue;
						case 270:
							array[31] = 186;
							num = 50;
							goto end_IL_12d7;
						case 316:
							num13 = 209 - 69;
							num = 334;
							goto end_IL_12d7;
						case 437:
							num15 <<= 8;
							num = 386;
							goto end_IL_12d7;
						case 221:
							array[13] = 157;
							num2 = 132;
							goto end_IL_12db;
						case 54:
							binaryReader = new BinaryReader(new MemoryStream(buffer));
							num2 = 122;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 21;
						case 264:
							array5 = array7;
							num = 361;
							goto end_IL_12d7;
						case 209:
							array[12] = 248;
							num3 = 175;
							continue;
						case 391:
							array[28] = 85;
							num3 = 256;
							continue;
						case 363:
							array3[10] = 106;
							num = 56;
							goto end_IL_12d7;
						case 59:
						case 236:
							array[29] = 132;
							num3 = 311;
							continue;
						case 119:
							if (publicKeyToken != null)
							{
								num3 = 162;
								continue;
							}
							goto case 90;
						case 82:
							array[15] = (byte)num11;
							num2 = 387;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 362;
						case 266:
							num11 = 141 - 47;
							num2 = 127;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 119;
						case 340:
							num40 = binaryReader.ReadInt32();
							num = 272;
							goto end_IL_12d7;
						case 375:
							array[30] = (byte)num13;
							num2 = 53;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 208;
						case 208:
							array[2] = 130;
							num2 = 373;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 206;
						case 212:
							array[10] = 135;
							num2 = 398;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 40;
						case 40:
							array[28] = 77;
							num = 94;
							goto end_IL_12d7;
						case 380:
							array2[1] = publicKeyToken[0];
							num2 = 237;
							goto end_IL_12db;
						case 25:
							array[22] = 137;
							num = 184;
							goto end_IL_12d7;
						case 183:
							_008B_0090_008A(intPtr2, intPtr3, BitConverter.GetBytes(binaryReader.ReadInt32()), 4u, out zero);
							num = 278;
							goto end_IL_12d7;
						case 335:
							num39 = 255u;
							num3 = 64;
							continue;
						case 243:
							num11 = 78 + 52;
							num3 = 222;
							continue;
						case 449:
							num11 = 248 - 82;
							num2 = 341;
							goto end_IL_12db;
						case 27:
							array3[14] = 143;
							num2 = 351;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 329;
						case 329:
							intPtr2 = IntPtr.Zero;
							num2 = 49;
							goto end_IL_12db;
						case 65:
							num11 = 218 - 72;
							num2 = 83;
							goto end_IL_12db;
						case 222:
							array[2] = (byte)num11;
							num3 = 185;
							continue;
						case 115:
							array[3] = (byte)num11;
							_ = 1;
							if (_0088())
							{
								num = 59;
								goto end_IL_12d7;
							}
							num2 = 167;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 55;
						case 73:
							if (num24 == num18 - 1)
							{
								num2 = 7;
								if (_0087())
								{
									goto end_IL_12db;
								}
								goto case 305;
							}
							goto IL_3aca;
						case 305:
							array[24] = 235;
							num2 = 440;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 175;
						case 175:
							array[13] = 208;
							num3 = 410;
							continue;
						case 378:
							array3[8] = 161;
							num2 = 293;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 359;
						case 359:
							array3[7] = 194;
							num2 = 125;
							goto end_IL_12db;
						case 13:
							num11 = 181 - 60;
							num = 263;
							goto end_IL_12d7;
						case 240:
						case 394:
							if (num43 < array2.Length)
							{
								array6[num43] ^= array2[num43];
								num3 = 441;
								continue;
							}
							num2 = 264;
							goto end_IL_12db;
						case 6:
							num11 = 157 - 52;
							num2 = 126;
							goto end_IL_12db;
						case 321:
							array[29] = (byte)num11;
							num3 = 164;
							continue;
						case 440:
							array[25] = 169;
							num3 = 68;
							continue;
						case 95:
							if (num38 > 0)
							{
								num2 = 417;
								goto end_IL_12db;
							}
							goto case 235;
						case 361:
							num38 = array5.Length % 4;
							num = 234;
							goto end_IL_12d7;
						case 228:
							array[11] = 238;
							num3 = 266;
							continue;
						case 15:
							num15 = (uint)((array5[num20 + 3] << 24) | (array5[num20 + 2] << 16) | (array5[num20 + 1] << 8) | array5[num20]);
							num3 = 403;
							continue;
						case 431:
							array[14] = 48;
							num2 = 316;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 202;
						case 202:
							num13 = 219 + 4;
							num = 366;
							goto end_IL_12d7;
						case 148:
							array[16] = (byte)num13;
							num2 = 111;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 182;
						case 182:
							num13 = 104 + 45;
							num = 197;
							goto end_IL_12d7;
						case 76:
							array[31] = (byte)num13;
							num3 = 418;
							continue;
						case 98:
							array[26] = 15;
							num2 = 255;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 461;
						case 461:
						{
							uint num26 = num16;
							uint num27 = num16;
							uint num28 = 1341288995u;
							uint num29 = 611865032u;
							uint num30 = 1940111450u;
							uint num31 = num27;
							uint num32 = 1468126237u;
							uint num33 = 1873844383u;
							num30 += num32;
							uint num34 = ((num29 >> 9) | (num29 << 23)) ^ num28;
							uint num35 = num34 & 0x55555555;
							num34 &= 0xAAAAAAAAu;
							num29 = (num34 >> 1) | (num35 << 1);
							ulong num36 = num30 * 1695230583;
							if (num36 == 0)
							{
								num36--;
							}
							num28 = (uint)(num28 * num28 % num36);
							if ((double)num32 == 0.0)
							{
								num32--;
							}
							uint num37 = (uint)(103265678.0 / (double)num32 + (double)num32);
							num32 = (uint)((uint)(((short)num30 + -3288) * (int)num37) + (short)num30);
							num33 -= num30;
							num31 ^= num31 >> 1;
							num31 += num28;
							num31 ^= num31 >> 6;
							num31 += num32;
							num31 ^= num31 << 11;
							num31 += num33;
							num31 = (((num30 << 18) - num29) ^ num32) - num31;
							num16 = num26 + (uint)(double)num31;
							num2 = 318;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 49;
						}
						case 49:
							assembly = Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554589)).Assembly;
							num = 194;
							goto end_IL_12d7;
						case 143:
							array[18] = 165;
							num2 = 258;
							goto end_IL_12db;
						case 389:
							num11 = 209 - 112;
							num = 223;
							goto end_IL_12d7;
						case 155:
							array3[14] = (byte)num12;
							num2 = 27;
							goto end_IL_12db;
						case 188:
							array3[6] = (byte)num12;
							num = 359;
							goto end_IL_12d7;
						case 241:
							num20 = (uint)(num25 * 4);
							num3 = 242;
							continue;
						case 71:
							array4[num22 + 2] = (byte)((num23 & 0xFF0000) >> 16);
							num3 = 2;
							continue;
						case 213:
							num11 = 63 + 89;
							num3 = 408;
							continue;
						case 35:
						case 167:
							num13 = 20 + 115;
							num = 257;
							goto end_IL_12d7;
						case 285:
							array[21] = (byte)num11;
							num2 = 106;
							goto end_IL_12db;
						case 53:
							num11 = 14 + 86;
							num2 = 265;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 424;
						case 288:
							num13 = 125 + 44;
							num3 = 322;
							continue;
						case 121:
							array3[5] = (byte)num12;
							num3 = 172;
							continue;
						case 197:
							array[29] = (byte)num13;
							num3 = 109;
							continue;
						case 451:
							num19 = 0u;
							num2 = 138;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 379;
						case 379:
						case 411:
							num24++;
							num = 46;
							goto end_IL_12d7;
						case 62:
							array3[14] = (byte)num12;
							num = 310;
							goto end_IL_12d7;
						case 39:
							num12 = 13 + 50;
							num = 323;
							goto end_IL_12d7;
						case 219:
							array[6] = 43;
							num = 192;
							goto end_IL_12d7;
						case 153:
							array[9] = 97;
							num2 = 372;
							goto end_IL_12db;
						case 67:
							array[20] = 105;
							num2 = 41;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 266;
						case 377:
							array[13] = (byte)num11;
							num2 = 431;
							goto end_IL_12db;
						case 114:
							array[5] = 162;
							num = 28;
							goto end_IL_12d7;
						case 136:
							num13 = 52 + 103;
							num3 = 18;
							continue;
						case 410:
							array[13] = 62;
							num2 = 262;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 21;
						case 21:
							array3[12] = (byte)num12;
							num = 144;
							goto end_IL_12d7;
						case 283:
							array[27] = (byte)num11;
							num = 465;
							goto end_IL_12d7;
						case 133:
							array3[11] = 141;
							num2 = 26;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 138;
						case 374:
							array3[10] = 159;
							num2 = 432;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 158;
						case 158:
							num12 = 174 - 58;
							num2 = 384;
							goto end_IL_12db;
						case 428:
							num12 = 67 + 101;
							num2 = 57;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 134;
						case 134:
							num12 = 181 + 23;
							num3 = 330;
							continue;
						case 176:
							_008B_0091_0090 = hINSTANCE.ToInt64();
							num = 107;
							goto end_IL_12d7;
						case 69:
							array[3] = 126;
							num2 = 260;
							goto end_IL_12db;
						case 325:
							num13 = 153 - 51;
							num3 = 12;
							continue;
						case 20:
							array3[2] = 152;
							num3 = 425;
							continue;
						case 105:
							array4[num22] = (byte)(num23 & 0xFF);
							num3 = 139;
							continue;
						case 17:
							num12 = 197 - 65;
							num = 21;
							goto end_IL_12d7;
						case 93:
							array3[9] = (byte)num12;
							num = 152;
							goto end_IL_12d7;
						case 11:
							array[0] = (byte)num11;
							num2 = 362;
							goto end_IL_12db;
						case 215:
							array[24] = 158;
							num2 = 84;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 165;
						case 165:
							array[2] = (byte)num13;
							num2 = 325;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 246;
						case 246:
							if (num38 > 0)
							{
								num2 = 364;
								if (_0087())
								{
									goto end_IL_12db;
								}
								goto case 172;
							}
							goto IL_3588;
						case 172:
							array3[6] = 92;
							num3 = 356;
							continue;
						case 371:
							num11 = 213 - 71;
							num2 = 369;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 330;
						case 2:
							array4[num22 + 3] = (byte)((num23 & 0xFF000000u) >> 24);
							num = 411;
							goto end_IL_12d7;
						case 455:
							array[15] = (byte)num11;
							num3 = 85;
							continue;
						case 249:
							array[0] = (byte)num13;
							num = 217;
							goto end_IL_12d7;
						case 364:
							num21 = num16 ^ num15;
							num3 = 191;
							continue;
						case 229:
							num16 += num19;
							num = 15;
							goto end_IL_12d7;
						case 194:
							obj2 = (_0091_0086)56;
							num2 = 395;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 187;
						case 187:
							array[27] = 138;
							num2 = 99;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 0;
						case 0:
						case 3:
							if (num41 >= num40)
							{
								num2 = 467;
								goto end_IL_12db;
							}
							intPtr3 = new IntPtr(_008B_0091_0090 + binaryReader.ReadInt32());
							num2 = 342;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 118;
						case 218:
							num11 = 70 + 119;
							num = 116;
							goto end_IL_12d7;
						case 90:
							num43 = 0;
							num = 394;
							goto end_IL_12d7;
						case 372:
							array[9] = 94;
							num2 = 306;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 201;
						case 201:
							num13 = 184 - 61;
							num2 = 298;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 137;
						case 137:
							array[18] = (byte)num13;
							num3 = 230;
							continue;
						case 192:
							array[6] = 116;
							num2 = 87;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 369;
						case 369:
							array[16] = (byte)num11;
							num = 331;
							goto end_IL_12d7;
						case 198:
							num11 = 42 + 95;
							num2 = 166;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 92;
						case 92:
							buffer = array4;
							num2 = 205;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 342;
						case 342:
							_008B_0090_0086(intPtr3, 4, 4, ref num9);
							num2 = 224;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 277;
						case 426:
							num12 = 132 + 63;
							num3 = 233;
							continue;
						case 302:
							num11 = 228 - 76;
							num2 = 385;
							goto end_IL_12db;
						case 300:
							array[16] = 141;
							num2 = 19;
							goto end_IL_12db;
						case 453:
							array[6] = (byte)num11;
							num = 415;
							goto end_IL_12d7;
						case 166:
							array[22] = (byte)num11;
							num3 = 274;
							continue;
						case 164:
							array[30] = 74;
							num2 = 368;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 242;
						case 242:
							num19 = (uint)((array6[num20 + 3] << 24) | (array6[num20 + 2] << 16) | (array6[num20 + 1] << 8) | array6[num20]);
							num2 = 335;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 200;
						case 200:
							array[19] = 162;
							num3 = 466;
							continue;
						case 46:
						case 338:
							if (num24 < num18)
							{
								num25 = num24 % num44;
								num3 = 24;
								continue;
							}
							num2 = 92;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 141;
						case 141:
							array[19] = 207;
							num = 200;
							goto end_IL_12d7;
						case 436:
							array[25] = (byte)num13;
							num3 = 288;
							continue;
						case 419:
							array[17] = (byte)num11;
							num2 = 376;
							goto end_IL_12db;
						case 207:
							num12 = 126 - 42;
							num3 = 108;
							continue;
						case 376:
							num13 = 49 + 86;
							num2 = 295;
							goto end_IL_12db;
						case 127:
							array[11] = (byte)num11;
							num = 315;
							goto end_IL_12d7;
						case 109:
							num11 = 59 - 56;
							num3 = 321;
							continue;
						case 131:
							array[11] = (byte)num11;
							num2 = 120;
							goto end_IL_12db;
						case 101:
							array2[5] = publicKeyToken[2];
							num = 89;
							goto end_IL_12d7;
						case 160:
							num11 = 224 - 74;
							num2 = 11;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 347;
						case 347:
							num12 = 154 - 51;
							num = 326;
							goto end_IL_12d7;
						case 386:
							num15 |= array5[array5.Length - (1 + num17)];
							num3 = 282;
							continue;
						case 77:
							array3[0] = 124;
							num3 = 406;
							continue;
						case 42:
							array3[13] = 143;
							num2 = 117;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 164;
						case 120:
							array[11] = 238;
							num2 = 102;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 172;
						case 393:
							array3[5] = (byte)num12;
							num = 276;
							goto end_IL_12d7;
						case 373:
							num13 = 207 - 69;
							num2 = 165;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 196;
						case 196:
							array3[11] = 67;
							num3 = 129;
							continue;
						case 100:
							array3[13] = 118;
							num2 = 42;
							goto end_IL_12db;
						case 306:
							num13 = 179 - 59;
							num3 = 14;
							continue;
						case 434:
							array[15] = (byte)num11;
							num = 239;
							goto end_IL_12d7;
						case 459:
							array3[12] = 180;
							num2 = 426;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 28;
						case 28:
							array[5] = 154;
							num2 = 37;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 397;
						case 397:
							num12 = 203 - 67;
							num = 317;
							goto end_IL_12d7;
						case 458:
							array[26] = 95;
							num3 = 396;
							continue;
						case 171:
							array[15] = (byte)num13;
							num3 = 159;
							continue;
						case 31:
							num16 += num19;
							num = 16;
							goto end_IL_12d7;
						case 244:
							array[13] = (byte)num11;
							num2 = 292;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 365;
						case 282:
							num17++;
							num = 110;
							goto end_IL_12d7;
						case 43:
							array3[0] = 88;
							num2 = 348;
							goto end_IL_12db;
						case 52:
							array[14] = 47;
							num2 = 75;
							goto end_IL_12db;
						case 383:
							array[4] = 93;
							num = 294;
							goto end_IL_12d7;
						case 10:
							array3 = new byte[16];
							num3 = 253;
							continue;
						case 254:
							num12 = 123 - 119;
							num = 299;
							goto end_IL_12d7;
						case 233:
							array3[12] = (byte)num12;
							num2 = 100;
							goto end_IL_12db;
						case 130:
							num12 = 16 + 67;
							num3 = 448;
							continue;
						case 384:
							array3[2] = (byte)num12;
							num2 = 207;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 256;
						case 256:
							num13 = 78 + 98;
							num = 156;
							goto end_IL_12d7;
						case 79:
							array[9] = 111;
							num = 463;
							goto end_IL_12d7;
						case 225:
							array[19] = 122;
							num2 = 141;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 433;
						case 433:
							num11 = 186 - 62;
							num2 = 61;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 155;
						case 281:
							array[13] = (byte)num11;
							num2 = 427;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 322;
						case 322:
							array[25] = (byte)num13;
							num2 = 98;
							goto end_IL_12db;
						case 23:
							array3[15] = (byte)num12;
							num2 = 72;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 217;
						case 217:
							num13 = 219 - 73;
							num2 = 189;
							goto end_IL_12db;
						case 248:
							array[27] = (byte)num13;
							num = 206;
							goto end_IL_12d7;
						case 112:
							array[1] = 127;
							num2 = 154;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 147;
						case 147:
							array[20] = 130;
							num3 = 178;
							continue;
						case 289:
							array[1] = 189;
							num3 = 112;
							continue;
						case 417:
							num18++;
							num3 = 235;
							continue;
						case 315:
							num11 = 122 + 97;
							num = 319;
							goto end_IL_12d7;
						case 168:
							num17 = 0;
							num2 = 314;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 261;
						case 261:
							num12 = 206 - 109;
							num2 = 245;
							goto end_IL_12db;
						case 81:
							array[8] = 240;
							num3 = 32;
							continue;
						case 230:
							array[18] = 218;
							num2 = 284;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 80;
						case 80:
							num16 = 0u;
							num3 = 451;
							continue;
						case 64:
							num14 = 0;
							num2 = 73;
							goto end_IL_12db;
						case 170:
							array[13] = (byte)num11;
							num = 221;
							goto end_IL_12d7;
						case 320:
							array[21] = (byte)num11;
							num3 = 25;
							continue;
						case 129:
							array3[11] = 66;
							num = 133;
							goto end_IL_12d7;
						case 418:
							num11 = 52 + 56;
							num2 = 456;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 428;
						case 392:
							array[16] = (byte)num13;
							num2 = 302;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 456;
						case 456:
							array[31] = (byte)num11;
							num = 145;
							goto end_IL_12d7;
						case 253:
							num12 = 134 - 44;
							num2 = 124;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 343;
						case 343:
							array[4] = 144;
							num = 414;
							goto end_IL_12d7;
						case 91:
							array[19] = (byte)num13;
							num3 = 225;
							continue;
						case 271:
							array[24] = (byte)num13;
							num = 305;
							goto end_IL_12d7;
						case 334:
							array[14] = (byte)num13;
							num2 = 52;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 367;
						case 367:
							num13 = 22 + 3;
							num = 435;
							goto end_IL_12d7;
						case 156:
							array[28] = (byte)num13;
							num3 = 40;
							continue;
						case 102:
							array[12] = 248;
							num3 = 213;
							continue;
						case 357:
							binaryReader.BaseStream.Position = 0L;
							num2 = 140;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 292;
						case 404:
							array4 = new byte[array5.Length];
							num3 = 355;
							continue;
						case 345:
							num13 = 14 + 86;
							num3 = 252;
							continue;
						case 348:
							array3[0] = 106;
							num2 = 8;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 36;
						case 36:
							array3[2] = 101;
							num2 = 158;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 350;
						case 350:
							array[27] = (byte)num13;
							num2 = 409;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 86;
						case 86:
							num12 = 38 + 26;
							num3 = 259;
							continue;
						case 74:
							array3[1] = (byte)num12;
							num2 = 462;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 453;
						case 251:
							_008B_0091_0092 = true;
							num3 = 30;
							continue;
						case 124:
							array3[0] = (byte)num12;
							num3 = 43;
							continue;
						case 189:
							array[0] = (byte)num13;
							num2 = 5;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 272;
						case 272:
							binaryReader.ReadInt32();
							num2 = 301;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 19;
						case 19:
							num13 = 166 - 94;
							num2 = 148;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 287;
						case 227:
							array[15] = (byte)num11;
							num2 = 33;
							goto end_IL_12db;
						case 460:
							num12 = 64 + 91;
							num3 = 74;
							continue;
						case 113:
							array2 = array3;
							num2 = 444;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 430;
						case 292:
							num11 = 23 + 98;
							num = 281;
							goto end_IL_12d7;
						case 443:
							array[7] = 138;
							num = 405;
							goto end_IL_12d7;
						case 414:
							num13 = 158 - 52;
							num3 = 430;
							continue;
						case 280:
							array3[9] = (byte)num12;
							num2 = 180;
							if (0 == 0)
							{
								goto end_IL_12db;
							}
							goto case 12;
						case 12:
							array[2] = (byte)num13;
							num3 = 370;
							continue;
						case 88:
							binaryReader.Close();
							num = 54;
							goto end_IL_12d7;
						case 150:
							array[20] = (byte)num13;
							num3 = 147;
							continue;
						case 293:
							array3[8] = 226;
							num3 = 60;
							continue;
						case 117:
							num12 = 28 + 96;
							num2 = 220;
							goto end_IL_12db;
						case 96:
							array[0] = 47;
							num3 = 160;
							continue;
						case 205:
							Array.Clear(array2, 0, array2.Length);
							num = 88;
							goto end_IL_12d7;
						case 399:
							num11 = 119 + 54;
							num2 = 419;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 16;
						case 16:
							num15 = 0u;
							num = 168;
							goto end_IL_12d7;
						case 154:
							array[1] = 124;
							num2 = 218;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 439;
						case 439:
							array[30] = (byte)num11;
							num = 270;
							goto end_IL_12d7;
						case 247:
							num14 += 8;
							num3 = 66;
							continue;
						case 463:
							array[9] = 67;
							num2 = 104;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 48;
						case 48:
							array2[11] = publicKeyToken[5];
							num2 = 388;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 219;
						case 185:
							array[3] = 97;
							num = 69;
							goto end_IL_12d7;
						case 274:
							array[23] = 223;
							num2 = 297;
							goto end_IL_12db;
						case 291:
							num12 = 17 + 88;
							num2 = 155;
							goto end_IL_12db;
						case 37:
							array[5] = 231;
							num3 = 420;
							continue;
						case 72:
							array3[15] = 47;
							num2 = 347;
							goto end_IL_12db;
						case 32:
							num13 = 124 + 91;
							num = 360;
							goto end_IL_12d7;
						case 327:
							array[11] = 133;
							num2 = 6;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 349;
						case 349:
							array3[13] = 166;
							num2 = 450;
							goto end_IL_12db;
						case 275:
							array3[10] = (byte)num12;
							num = 374;
							goto end_IL_12d7;
						case 9:
							array3[15] = (byte)num12;
							num = 232;
							goto end_IL_12d7;
						case 220:
							array3[13] = (byte)num12;
							num2 = 349;
							goto end_IL_12db;
						case 204:
							array3[9] = (byte)num12;
							num2 = 268;
							goto end_IL_12db;
						case 462:
							array3[1] = 102;
							num3 = 203;
							continue;
						case 277:
							array[7] = (byte)num13;
							num = 443;
							goto end_IL_12d7;
						case 66:
							array4[num22 + num42] = (byte)((num21 & num39) >> num14);
							num2 = 4;
							if (!_0088())
							{
								goto end_IL_12db;
							}
							goto case 38;
						case 38:
							array[10] = 121;
							num2 = 228;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 341;
						case 341:
							array[23] = (byte)num11;
							num3 = 381;
							continue;
						case 360:
							array[8] = (byte)num13;
							num = 186;
							goto end_IL_12d7;
						case 307:
							num13 = 165 - 55;
							num2 = 150;
							goto end_IL_12db;
						case 368:
							num13 = 243 - 81;
							num3 = 375;
							continue;
						case 290:
							array[16] = (byte)num11;
							num2 = 300;
							goto end_IL_12db;
						case 255:
							array[26] = 64;
							num2 = 458;
							goto end_IL_12db;
						case 296:
							array3[0] = (byte)num12;
							num2 = 77;
							goto end_IL_12db;
						case 447:
							array[2] = (byte)num13;
							num3 = 201;
							continue;
						case 351:
							array3[14] = 96;
							num2 = 78;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 303;
						case 303:
							num11 = 206 - 68;
							num3 = 211;
							continue;
						case 405:
							array[7] = 107;
							num = 81;
							goto end_IL_12d7;
						case 353:
							publicKeyToken = Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554589)).Assembly.GetName().GetPublicKeyToken();
							num2 = 119;
							goto end_IL_12db;
						case 299:
							array3[1] = (byte)num12;
							num = 36;
							goto end_IL_12d7;
						case 111:
							array[17] = 135;
							num = 195;
							goto end_IL_12d7;
						case 122:
							binaryReader.BaseStream.Position = 0L;
							num3 = 329;
							continue;
						case 358:
							array3[2] = (byte)num12;
							num = 324;
							goto end_IL_12d7;
						case 445:
							array[24] = 235;
							num = 215;
							goto end_IL_12d7;
						case 356:
							array3[6] = 140;
							num2 = 70;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 216;
						case 216:
							array[9] = 67;
							num3 = 153;
							continue;
						case 179:
							num11 = 114 + 67;
							num = 47;
							goto end_IL_12d7;
						case 94:
							array[28] = 141;
							num = 416;
							goto end_IL_12d7;
						case 30:
							binaryReader = new BinaryReader(Type.GetTypeFromHandle(_0091_0089.e53w34m968awCm9P85taUZe(33554589)).Assembly.GetManifestResourceStream("ba72a797-e070-4065-8cee-54d98e57584c"));
							num3 = 357;
							continue;
						case 400:
							array[15] = 141;
							num2 = 118;
							if (true)
							{
								goto end_IL_12db;
							}
							goto case 180;
						case 180:
							num12 = 157 - 52;
							num = 204;
							goto end_IL_12d7;
						case 388:
							array2[13] = publicKeyToken[6];
							num = 45;
							goto end_IL_12d7;
						case 116:
							array[1] = (byte)num11;
							num2 = 208;
							if (_0087())
							{
								goto end_IL_12db;
							}
							goto case 420;
						case 420:
							array[5] = 162;
							num3 = 442;
							continue;
						case 398:
							array[10] = 125;
							num2 = 177;
							goto end_IL_12db;
						case 467:
							try
							{
								while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length - 1)
								{
									int num4 = 0;
									while (true)
									{
										int num6;
										int num7;
										switch (num4)
										{
										case 11:
											break;
										case 9:
											_008B_0090_0086(intPtr, num8 * 4, 4, ref num9);
											num6 = 3;
											if (true)
											{
												goto IL_3c90;
											}
											goto case 5;
										case 5:
											num10++;
											num6 = 4;
											if (0 == 0)
											{
												goto IL_3c90;
											}
											goto case 7;
										case 7:
											num8 = binaryReader.ReadInt32();
											num6 = 9;
											if (!_0088())
											{
												goto IL_3c90;
											}
											goto case 8;
										case 8:
										case 10:
											_008B_0090_0086(intPtr, num8 * 4, num9, ref num9);
											num7 = 11;
											goto IL_3c8c;
										case 3:
											num10 = 0;
											goto case 4;
										default:
											num6 = 6;
											goto IL_3c90;
										case 0:
											num5 = binaryReader.ReadInt32();
											_0088();
											if (_0087())
											{
												num7 = 2;
												goto IL_3c8c;
											}
											num6 = 10;
											goto IL_3c90;
										case 1:
										case 2:
											intPtr = new IntPtr(_008B_0091_0090 + num5);
											num6 = 7;
											if (!_0088())
											{
												goto IL_3c90;
											}
											goto case 4;
										case 4:
										case 6:
											{
												if (num10 >= num8)
												{
													goto case 8;
												}
												Marshal.WriteInt32(new IntPtr(intPtr.ToInt64() + num10 * 4), binaryReader.ReadInt32());
												num6 = 5;
												goto IL_3c90;
											}
											IL_3c8c:
											num6 = num7;
											goto IL_3c90;
										}
										break;
										IL_3c90:
										num4 = num6;
									}
								}
								_008B_0090_008D(intPtr2);
								return;
							}
							catch
							{
								return;
							}
						case 224:
							{
								if (IntPtr.Size == 4)
								{
									num3 = 183;
									continue;
								}
								_008B_0090_008A(intPtr2, intPtr3, BitConverter.GetBytes(binaryReader.ReadInt32()), 4u, out zero);
								num2 = 58;
								goto end_IL_12db;
							}
							IL_3588:
							num23 = num16 ^ num15;
							num = 105;
							goto end_IL_12d7;
						}
						array[19] = 143;
						num2 = 354;
						if (_0087())
						{
							break;
						}
						goto IL_0045;
						IL_04cf:
						if (num38 > 0)
						{
							num3 = 31;
							continue;
						}
						goto IL_3aca;
						IL_0045:
						array[28] = 146;
						num = 391;
						goto end_IL_12d7;
						IL_3aca:
						num20 = (uint)num22;
						num = 229;
						goto end_IL_12d7;
						IL_01f8:
						intPtr2 = _008B_0090_008C((uint)obj2, 1, (uint)Process.GetCurrentProcess().Id);
						num = 446;
						goto end_IL_12d7;
						IL_01e5:
						array2[9] = publicKeyToken[4];
						num = 48;
						goto end_IL_12d7;
						IL_0157:
						array[3] = (byte)num13;
						num = 389;
						goto end_IL_12d7;
						IL_0070:
						Array.Reverse(array2);
						num2 = 353;
						break;
						IL_005e:
						num18 = array5.Length / 4;
						num = 404;
						goto end_IL_12d7;
						continue;
						end_IL_12db:
						break;
					}
					continue;
					end_IL_12d7:
					break;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object _008B_0090_0089(object P_0)
		{
			try
			{
				if (File.Exists(((Assembly)P_0).Location))
				{
					return ((Assembly)P_0).Location;
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(((Assembly)P_0).GetName().CodeBase.ToString().Replace("file:///", "")))
				{
					return ((Assembly)P_0).GetName().CodeBase.ToString().Replace("file:///", "");
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(P_0.GetType().GetProperty("Location").GetValue(P_0, new object[0])
					.ToString()))
				{
					return P_0.GetType().GetProperty("Location").GetValue(P_0, new object[0])
						.ToString();
				}
			}
			catch
			{
			}
			return "";
		}

		[DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
		private static extern int _008B_0090_008A(IntPtr P_0, IntPtr P_1, [In][Out] byte[] P_2, uint P_3, out IntPtr P_4);

		[DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
		private static extern int _008B_0090_008B(IntPtr P_0, IntPtr P_1, [In][Out] byte[] P_2, uint P_3, out IntPtr P_4);

		[DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
		private static extern IntPtr _008B_0090_008C(uint P_0, int P_1, uint P_2);

		[DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
		private static extern int _008B_0090_008D(IntPtr P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] _008B_0090_008E(string P_0)
		{
			using FileStream fileStream = new FileStream(P_0, FileMode.Open, FileAccess.Read, FileShare.Read);
			int num = 0;
			long length = fileStream.Length;
			int num2 = (int)length;
			byte[] array = new byte[num2];
			while (num2 > 0)
			{
				int num3 = fileStream.Read(array, num, num2);
				num += num3;
				num2 -= num3;
			}
			return array;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static byte[] _008B_0090_008F(byte[] P_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = _008B_008F_0098();
			symmetricAlgorithm.Key = new byte[32]
			{
				28, 140, 35, 220, 242, 181, 128, 254, 224, 127,
				127, 85, 26, 117, 99, 60, 219, 55, 207, 32,
				16, 227, 240, 251, 98, 107, 210, 152, 125, 236,
				124, 188
			};
			symmetricAlgorithm.IV = new byte[16]
			{
				23, 5, 86, 220, 164, 189, 42, 28, 127, 65,
				63, 226, 210, 146, 81, 145
			};
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(P_0, 0, P_0.Length);
			cryptoStream.Close();
			return memoryStream.ToArray();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] _008B_0090_0090()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] _008B_0090_0091()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] _008B_0090_0092()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] _008B_0090_0093()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] _008B_0090_0094()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private byte[] _008B_0090_0095()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] _008B_0090_0096()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] _008B_0090_0097()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] _008B_0090_0098()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] _008B_0090_0099()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] _008B_0090_009A()
		{
			string text = "{11111-22222-60001-00001}";
			if (text.Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal byte[] _008B_0090_009B()
		{
			string text = "{11111-22222-60001-00002}";
			if (text.Length > 0)
			{
				return new byte[2] { 1, 2 };
			}
			return new byte[2] { 1, 2 };
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0090_009C(string P_0, string P_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(P_0);
			byte[] array = bytes;
			byte[] key = new byte[32]
			{
				82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
				51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
				34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
				1, 88
			};
			byte[] iV = _008B_008F_0099(Encoding.Unicode.GetBytes(P_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = _008B_008F_0098();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = iV;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0090_009B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0087()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _0088()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool _0087()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool _0088()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool _0087()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool _0088()
		{
			return false;
		}

		static bool _0087()
		{
			return true;
		}

		static bool _0088()
		{
			return false;
		}
	}
}
namespace _0091_0088
{
	internal class _0091_0087
	{
		private static bool _008B_0091_0094;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void SLV0fFIsptsZtjvFft17()
		{
			_ = 1;
			int num = (_008B_0096() ? 3 : 2);
			int num2 = num;
			while (true)
			{
				switch (num2)
				{
				case 1:
				case 3:
					_008B_0091_0094 = true;
					goto case 4;
				case 0:
				case 2:
					if (!_008B_0091_0094)
					{
						goto case 1;
					}
					return;
				case 4:
					try
					{
						MessageBox.Show(_0090_009B._008B_008F_009D(7540), _0090_009B._008B_008F_009D(7544));
						return;
					}
					catch
					{
						_008B_0091_0093(_0090_009B._008B_008F_009D(7548));
						return;
					}
				}
				num2 = 4;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0091_0093(string P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0091_0087()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0091_0087()
		{
			_0090_009B._008B_0090_0088();
		}

		internal static bool _008B_0095()
		{
			return true;
		}

		internal static bool _008B_0096()
		{
			return false;
		}
	}
}
namespace _0091_008A
{
	internal class _0091_0089
	{
		internal static ModuleHandle _008B_0091_0095;

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static RuntimeTypeHandle e53w34m968awCm9P85taUZe(int token)
		{
			return _008B_0091_0095.GetRuntimeTypeHandleFromMetadataToken(token);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static RuntimeFieldHandle q3oMVe54wE47w4v68C7s2I(int token)
		{
			return _008B_0091_0095.GetRuntimeFieldHandleFromMetadataToken(token);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0091_0089()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0091_0089()
		{
			_0090_009B._008B_0090_0088();
			_008B_0091_0095 = typeof(_0091_0089).Assembly.GetModules()[0].ModuleHandle;
		}

		internal static bool _008B_0097()
		{
			return true;
		}

		internal static bool _008B_0098()
		{
			return false;
		}
	}
}
namespace _0091_008C
{
	[DesignTimeVisible(false)]
	internal class _0091_008B : LicenseProvider
	{
		internal class _0091_008D
		{
			internal static string _008B_0098_0088;

			internal static string _008B_0098_0089;

			internal static string _008B_0098_008A;

			internal static string _008B_0098_008B;

			internal static string _008B_0098_008C;

			internal static string _008B_0098_008D;

			internal static string _008B_0098_008E;

			internal static string _008B_0098_008F;

			internal static string _008B_0098_0090;

			internal static string _008B_0098_0091;

			internal static string _008B_0098_0092;

			internal static string _008B_0098_0093;

			internal static string _008B_0098_0094;

			internal static string _008B_0098_0095;

			internal static string _008B_0098_0096;

			internal static string _008B_0098_0097;

			internal static string _008B_0098_0098;

			internal static string _008B_0098_0099;

			internal static string _008B_0098_009A;

			internal static string _008B_0098_009B;

			internal static string _008B_0098_009C;

			internal static string _008B_0098_009D;

			internal static string _008B_0098_009E;

			internal static string _008B_0099_0086;

			internal static string _008B_0099_0087;

			internal static string _008B_0099_0088;

			internal static string _008B_0099_0089;

			internal static string _008B_0099_008A;

			internal static string _008B_0099_008B;

			internal static string _008B_0099_008C;

			internal static string _008B_0099_008D;

			internal static string _008B_0099_008E;

			internal static string _008B_0099_008F;

			internal static string _008B_0099_0090;

			internal static string _008B_0099_0091;

			internal static string _008B_0099_0092;

			internal static string _008B_0099_0093;

			internal static string _008B_0099_0094;

			internal static string _008B_0099_0095;

			internal static string _008B_0099_0096;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0091_008D()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0091_008D()
			{
				_0090_009B._008B_0090_0088();
				_008B_0098_0088 = _0090_009B._008B_008F_009D(7824);
				_008B_0098_0089 = _0090_009B._008B_008F_009D(7828);
				_008B_0098_008A = _0090_009B._008B_008F_009D(7832);
				_008B_0098_008B = _0090_009B._008B_008F_009D(7836);
				_008B_0098_008C = _0090_009B._008B_008F_009D(7840);
				_008B_0098_008D = _0090_009B._008B_008F_009D(7844);
				_008B_0098_008E = _0090_009B._008B_008F_009D(7848);
				_008B_0098_008F = _0090_009B._008B_008F_009D(7852);
				_008B_0098_0090 = _0090_009B._008B_008F_009D(7856);
				_008B_0098_0091 = _0090_009B._008B_008F_009D(7860);
				_008B_0098_0092 = _0090_009B._008B_008F_009D(7864);
				_008B_0098_0093 = _0090_009B._008B_008F_009D(7868);
				_008B_0098_0094 = _0090_009B._008B_008F_009D(7872);
				_008B_0098_0095 = _0090_009B._008B_008F_009D(7876);
				_008B_0098_0096 = _0090_009B._008B_008F_009D(7880);
				_008B_0098_0097 = _0090_009B._008B_008F_009D(7884);
				_008B_0098_0098 = _0090_009B._008B_008F_009D(7888);
				_008B_0098_0099 = _0090_009B._008B_008F_009D(7892);
				_008B_0098_009A = _0090_009B._008B_008F_009D(7896);
				_008B_0098_009B = _0090_009B._008B_008F_009D(7900);
				_008B_0098_009C = _0090_009B._008B_008F_009D(7904);
				_008B_0098_009D = _0090_009B._008B_008F_009D(7908);
				_008B_0098_009E = _0090_009B._008B_008F_009D(7912);
				_008B_0099_0086 = _0090_009B._008B_008F_009D(7916);
				_008B_0099_0087 = _0090_009B._008B_008F_009D(7920);
				_008B_0099_0088 = _0090_009B._008B_008F_009D(7924);
				_008B_0099_0089 = _0090_009B._008B_008F_009D(3904);
				_008B_0099_008A = _0090_009B._008B_008F_009D(7928);
				_008B_0099_008B = _0090_009B._008B_008F_009D(7932);
				_008B_0099_008C = _0090_009B._008B_008F_009D(7936);
				_008B_0099_008D = _0090_009B._008B_008F_009D(2084);
				_008B_0099_008E = _0090_009B._008B_008F_009D(1644);
				_008B_0099_008F = _0090_009B._008B_008F_009D(7940);
				_008B_0099_0090 = _0090_009B._008B_008F_009D(7944);
				_008B_0099_0091 = _0090_009B._008B_008F_009D(7948);
				_008B_0099_0092 = _0090_009B._008B_008F_009D(7952);
				_008B_0099_0093 = _0090_009B._008B_008F_009D(2320);
				_008B_0099_0094 = _0090_009B._008B_008F_009D(7956);
				_008B_0099_0095 = _0090_009B._008B_008F_009D(7960);
				_008B_0099_0096 = _0090_009B._008B_008F_009D(700);
			}
		}

		internal class _0091_008E
		{
			internal DateTime _008B_009A_0086;

			internal DateTime _008B_009A_0087;

			internal DateTime _008B_009A_0088;

			internal int _008B_009A_0089;

			internal int _008B_009A_008A;

			internal int _008B_009A_008B;

			internal ulong _008B_009A_008C;

			internal int _008B_009A_008D;

			internal string _008B_009A_008E;

			internal bool _008B_009A_008F;

			internal string _008B_009A_0090;

			internal string _008B_009A_0091;

			private string _008B_009A_0092;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0091_008E()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_0099_0097(string P_0, byte[] P_1, byte[] P_2)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_0099_0098(string P_0)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int _008B_0099_0099(string P_0)
			{
				return 0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal ulong _008B_0099_009A(string P_0)
			{
				return 0uL;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal DateTime _008B_0099_009B(string P_0)
			{
				return (DateTime)(object)null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal string _008B_0099_009C(byte[] P_0, byte[] P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_0099_009D(string P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void _008B_0099_009E(object P_0)
			{
			}

			static _0091_008E()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		internal class _0091_008F
		{
			internal string _008B_009A_009D;

			internal ArrayList _008B_009A_009E;

			internal bool _008B_009B_0086;

			internal bool _008B_009B_0087;

			internal bool _008B_009B_0088;

			internal bool _008B_009B_0089;

			internal bool _008B_009B_008A;

			internal string _008B_009B_008B;

			internal string _008B_009B_008C;

			internal bool _008B_009B_008D;

			internal bool _008B_009B_008E;

			internal bool _008B_009B_008F;

			internal bool _008B_009B_0090;

			internal bool _008B_009B_0091;

			internal bool _008B_009B_0092;

			internal bool _008B_009B_0093;

			internal bool _008B_009B_0094;

			internal bool _008B_009B_0095;

			internal string _008B_009B_0096;

			internal bool _008B_009B_0097;

			internal bool _008B_009B_0098;

			internal bool _008B_009B_0099;

			internal string _008B_009B_009A;

			internal bool _008B_009B_009B;

			internal int _008B_009B_009C;

			internal string _008B_009B_009D;

			internal int _008B_009B_009E;

			internal int _008B_009C_0086;

			internal bool _008B_009C_0087;

			internal bool _008B_009C_0088;

			internal int _008B_009C_0089;

			internal bool _008B_009C_008A;

			internal DateTime _008B_009C_008B;

			internal bool _008B_009C_008C;

			internal int _008B_009C_008D;

			internal bool _008B_009C_008E;

			internal int _008B_009C_008F;

			internal bool _008B_009C_0090;

			internal int _008B_009C_0091;

			internal bool _008B_009C_0092;

			internal int _008B_009C_0093;

			internal bool _008B_009C_0094;

			internal bool _008B_009C_0095;

			internal bool _008B_009C_0096;

			internal bool _008B_009C_0097;

			internal bool _008B_009C_0098;

			internal bool _008B_009C_0099;

			internal bool _008B_009C_009A;

			internal bool _008B_009C_009B;

			internal bool _008B_009C_009C;

			internal bool _008B_009C_009D;

			internal bool _008B_009C_009E;

			internal bool _008B_009D_0086;

			internal bool _008B_009D_0087;

			internal bool _008B_009D_0088;

			internal bool _008B_009D_0089;

			internal bool _008B_009D_008A;

			internal bool _008B_009D_008B;

			internal string _008B_009D_008C;

			internal string _008B_009D_008D;

			internal string _008B_009D_008E;

			internal string _008B_009D_008F;

			internal string _008B_009D_0090;

			internal string _008B_009D_0091;

			internal string _008B_009D_0092;

			internal string _008B_009D_0093;

			internal string _008B_009D_0094;

			internal string _008B_009D_0095;

			internal string _008B_009D_0096;

			internal bool _008B_009D_0097;

			internal int _008B_009D_0098;

			internal string _008B_009D_0099;

			internal string _008B_009D_009A;

			internal Hashtable _008B_009D_009B;

			internal static ux _008B_009D_009C;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0091_008F()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_009A_0093(byte[] P_0)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private static byte[] _008B_009A_0094(ref int P_0, byte[] P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008B_009A_0095(byte[] P_0)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_009A_0096(byte[] P_0)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal bool _008B_009A_0097(string P_0)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal int _008B_009A_0098(string P_0)
			{
				return 0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal string _008B_009A_0099(string P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal DateTime _008B_009A_009A(string P_0)
			{
				return (DateTime)(object)null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static _0091_008F()
			{
				_0090_009B._008B_0090_0088();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008B_009A_009B()
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static bool _008B_009A_009C()
			{
				return true;
			}
		}

		internal class _0091_0090
		{
			private object _008B_009D_009E;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public _0091_0090(string P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public byte[] _008B_009D_009D(byte[] P_0)
			{
				return null;
			}

			static _0091_0090()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		[DesignerCategory("code")]
		[GeneratedCode("wsdl", "2.0.50727.42")]
		[WebServiceBinding(Name = "ActivationServiceSoap", Namespace = "http://tempuri.org/")]
		[DebuggerStepThrough]
		internal class wy : SoapHttpClientProtocol
		{
			private SendOrPostCallback kc;

			private fd q3;

			public event fd YD
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
			public wy(string P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[SoapDocumentMethod("http://tempuri.org/Activate", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
			[return: XmlElement(DataType = "base64Binary")]
			public byte[] Activate([XmlElement(DataType = "base64Binary")] byte[] license)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public IAsyncResult A4(byte[] P_0, AsyncCallback P_1, object P_2)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public byte[] bK(IAsyncResult P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void re(byte[] P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void da(byte[] P_0, object P_1)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void pm(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void NF(object P_0)
			{
			}

			static wy()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		[GeneratedCode("wsdl", "2.0.50727.42")]
		internal delegate void fd(object sender, VI e);

		[GeneratedCode("wsdl", "2.0.50727.42")]
		[DebuggerStepThrough]
		[DesignerCategory("code")]
		internal class VI : AsyncCompletedEventArgs
		{
			private object[] oR;

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal VI(object[] P_0, Exception P_1, bool P_2, object P_3)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			[SpecialName]
			public byte[] sMki4t8TjK()
			{
				return null;
			}

			static VI()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		private class Qt
		{
			internal static System.Threading.Timer Ao;

			private static bool kP;

			private static object jH;

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void lx(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static void w6()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Qt()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static Qt()
			{
				_0090_009B._008B_0090_0088();
				kP = false;
				jH = new object();
			}
		}

		internal class fP
		{
			internal static fP uA;

			internal System.Threading.Timer IQ;

			private ulong rg;

			private byte[] vy;

			private int Pd;

			private string dM;

			private DateTime zJ;

			private Guid Tk;

			private int I8;

			private _0091_008F ON;

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void Bn(_0091_008F P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public fP(ulong P_0, byte[] P_1, Guid P_2, int P_3, string P_4, int P_5, _0091_008F P_6)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void cI()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void DE()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void St(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static fP()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		internal class WX
		{
			private static Dictionary<string, WX> Jw;

			internal System.Threading.Timer Vb;

			private ulong T1;

			private byte[] gV;

			private int Pv;

			private string F2;

			private DateTime E7;

			private Guid gf;

			private int NO;

			private hKbV0NIkrxmjDtgaD7cJbeLP Tu;

			private _0091_008F Sj;

			private ChannelFactory<hKbV0NIkrxmjDtgaD7cJbeLP> j5;

			internal NetTcpBinding nq;

			internal NetworkCredential JS;

			internal string yz;

			internal string r4X;

			private bool F44;

			[MethodImpl(MethodImplOptions.NoInlining)]
			private static void Ah(_0091_008F P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void ep()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void IL(string P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static int oW()
			{
				return 0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void rZ()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void O0(string P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void D9()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void KG(string P_0, WX P_1)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public WX(ulong P_0, byte[] P_1, Guid P_2, int P_3, string P_4, int P_5, _0091_008F P_6, hKbV0NIkrxmjDtgaD7cJbeLP P_7, ChannelFactory<hKbV0NIkrxmjDtgaD7cJbeLP> P_8)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void yB()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void Ni()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void fl()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void jT(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void Vr(object P_0, string P_1)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void Ms(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static WX()
			{
				_0090_009B._008B_0090_0088();
				Jw = new Dictionary<string, WX>();
			}
		}

		private class Iq
		{
			internal int q4K;

			internal int X4e;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Iq()
			{
			}

			static Iq()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		private class SC
		{
			internal static SC U4F;

			internal System.Threading.Timer R4Y;

			internal Iq A4U;

			private bool D4C;

			private _0091_008F l4D;

			private Assembly K4c;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public SC(_0091_008F P_0, Assembly P_1)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void E4a()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void P4m(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static SC()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		private class ic
		{
			internal static System.Threading.Timer U4R;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public ic()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void x43(object P_0)
			{
			}

			static ic()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		private class x0
		{
			internal static x0 A4o;

			internal System.Threading.Timer r4P;

			internal Iq X4H;

			private bool a4n;

			private _0091_008F n4I;

			private _0091_008E i4E;

			private Type a4t;

			private byte[] a4A;

			private byte[] C4Q;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public x0(_0091_008F P_0, _0091_008E P_1, Type P_2, byte[] P_3, byte[] P_4)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void P4x()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void x46(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static x0()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		private class fF
		{
			internal static fF O4d;

			internal System.Threading.Timer c4M;

			private _0091_008F u4J;

			private _0091_008E w4k;

			internal Iq W48;

			private bool e4N;

			private Type X4h;

			private byte[] z4p;

			private byte[] i4L;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public fF(_0091_008F P_0, _0091_008E P_1, Type P_2, byte[] P_3, byte[] P_4)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void N4g()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void P4y(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static fF()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		private class dn
		{
			internal static dn H40;

			internal System.Threading.Timer P49;

			private _0091_008F K4G;

			private _0091_008E R4B;

			internal Iq v4i;

			private bool t4l;

			private Type S4T;

			private byte[] C4r;

			private byte[] m4s;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void q4W()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public dn(_0091_008F P_0, _0091_008E P_1, Type P_2, byte[] P_3, byte[] P_4)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void O4Z(object P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static dn()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		[LicenseProvider(typeof(_0091_008B))]
		private class y1
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			private void f4w()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public y1()
			{
			}

			static y1()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		internal class zH : License
		{
			private object V4b;

			private string i41;

			internal object Y4V;

			public override string LicenseKey
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					return null;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public zH(object P_0, string P_1)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public override void Dispose()
			{
			}

			static zH()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		internal struct MY
		{
			public IntPtr i4v;

			public int H42;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string O47;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
			public string D4f;

			public uint I4O;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public byte[] b4u;

			public int e4j;

			public uint u45;

			public uint X4q;

			public IntPtr O4S;

			public gG p4z;

			public gG kKX;

			public gG SK4;

			public bool HKK;

			public gG dKe;

			public gG UKa;

			public int uKm;

			public int NKF;

			static MY()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		internal struct gG
		{
			public IntPtr mKY;

			public FQ UKU;

			public FQ PKC;

			public int mKD;

			static gG()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		internal struct FQ
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string HKc;

			static FQ()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		internal class ux : RSA
		{
			private const int yKn = 1;

			private const int GKI = 2;

			internal static byte[] gKE;

			internal int uKt;

			internal Op WKA;

			internal Op CKQ;

			internal Op CKg;

			internal Op UKy;

			internal Op KKd;

			internal Op fKM;

			internal Op QKJ;

			internal Op gKk;

			public override string KeyExchangeAlgorithm
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					return null;
				}
			}

			public override string SignatureAlgorithm
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					return null;
				}
			}

			public override int KeySize
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				get
				{
					return 0;
				}
				[MethodImpl(MethodImplOptions.NoInlining)]
				set
				{
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public ux()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public ux(int P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public override void FromXmlString(string P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public override void ImportParameters(RSAParameters P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public override RSAParameters ExportParameters(bool P_0)
			{
				return (RSAParameters)(object)null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public byte[] sK3(byte[] P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public byte[] YKR(byte[] P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public bool LKx(byte[] P_0, byte[] P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public bool xK6(byte[] P_0, byte[] P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public override byte[] EncryptValue(byte[] P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public override byte[] DecryptValue(byte[] P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			protected override void Dispose(bool P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private bool hKo(byte[] P_0, int P_1, byte[] P_2, int P_3, int P_4)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal byte[] sKP(byte[] P_0, int P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private bool wKH(XmlReader P_0, string P_1, string P_2, ref Op P_3)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			static ux()
			{
				_0090_009B._008B_0090_0088();
				gKE = new byte[18]
				{
					48, 32, 48, 12, 6, 8, 42, 134, 72, 134,
					247, 13, 2, 0, 5, 0, 4, 16
				};
			}
		}

		internal class Op
		{
			internal enum HT
			{

			}

			private sealed class Hf
			{
				private Op NKs;

				private Op mKw;

				[MethodImpl(MethodImplOptions.NoInlining)]
				public Hf(Op P_0)
				{
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public void zKB(Op P_0)
				{
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public Op SKi(Op P_0, Op P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public Op SKl(Op P_0, Op P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public Op sKT(Op P_0, Op P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public Op iKr(uint P_0, Op P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool _008C_008D()
				{
					return true;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool _008C_008E()
				{
					return true;
				}

				static Hf()
				{
					_0090_009B._008B_0090_0088();
				}
			}

			private sealed class Qv
			{
				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op VKb(Op P_0, Op P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op pK1(Op P_0, Op P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static void WKV(Op P_0, Op P_1)
				{
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static void iKv(Op P_0, Op P_1)
				{
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static HT BK2(Op P_0, Op P_1)
				{
					return (HT)(object)null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static uint HK7(Op P_0, uint P_1)
				{
					return 0u;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static uint rKf(Op P_0, uint P_1)
				{
					return 0u;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op RKO(Op P_0, uint P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op[] iKu(Op P_0, uint P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op[] LKj(Op P_0, Op P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op aK5(Op P_0, int P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op BKq(Op P_0, int P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op FKS(Op P_0, uint P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static void VKz(uint[] P_0, uint P_1, uint P_2, uint[] P_3, uint P_4, uint P_5, uint[] P_6, uint P_7)
				{
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static void VeX(uint[] P_0, int P_1, int P_2, uint[] P_3, int P_4, int P_5, uint[] P_6, int P_7, int P_8)
				{
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op pe4(Op P_0, Op P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static uint XeK(Op P_0, uint P_1)
				{
					return 0u;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public static Op Pee(Op P_0, Op P_1)
				{
					return null;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public Qv()
				{
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool _008C_008F()
				{
					return true;
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				internal static bool _008C_0090()
				{
					return true;
				}

				static Qv()
				{
					_0090_009B._008B_0090_0088();
				}
			}

			private uint XK9;

			private uint[] sKG;

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Op(HT P_0, uint P_1)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Op(Op P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Op(Op P_0, uint P_1)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Op(byte[] P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Op(uint P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Op(ulong P_0)
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static implicit operator Op(uint P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static implicit operator Op(int P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static implicit operator Op(ulong P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static Op operator +(Op P_0, Op P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static Op operator -(Op P_0, Op P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static int operator %(Op P_0, int P_1)
			{
				return 0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static uint operator %(Op P_0, uint P_1)
			{
				return 0u;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static Op operator %(Op P_0, Op P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static Op operator /(Op P_0, int P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static Op operator /(Op P_0, Op P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static Op operator *(Op P_0, Op P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static Op operator *(Op P_0, int P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static Op operator <<(Op P_0, int P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static Op operator >>(Op P_0, int P_1)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public int aK8()
			{
				return 0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public bool RKN(int P_0)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public byte[] IKh()
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public byte[] eKp()
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static bool operator ==(Op P_0, uint P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static bool operator !=(Op P_0, uint P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static bool operator ==(Op P_0, Op P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static bool operator !=(Op P_0, Op P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static bool operator >(Op P_0, Op P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static bool operator <(Op P_0, Op P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static bool operator >=(Op P_0, Op P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public static bool operator <=(Op P_0, Op P_1)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public HT BKL(Op P_0)
			{
				return (HT)(object)null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void RKW()
			{
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public override int GetHashCode()
			{
				return 0;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public override bool Equals(object P_0)
			{
				return true;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Op nKZ(Op P_0)
			{
				return null;
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public Op uK0(Op P_0, Op P_1)
			{
				return null;
			}

			static Op()
			{
				_0090_009B._008B_0090_0088();
			}
		}

		private const int _008B_0095_008E = 1718264361;

		private const double _008B_0095_008F = 4.656612873077393E-10;

		private const double _008B_0095_0090 = 2.3283064365386963E-10;

		private const uint _008B_0095_0091 = 842502087u;

		private const uint _008B_0095_0092 = 3579807591u;

		private const uint _008B_0095_0093 = 273326509u;

		private const uint _008B_0095_0094 = 1073741824u;

		private const uint _008B_0095_0095 = 2147483648u;

		private const uint _008B_0095_0096 = 1u;

		private const uint _008B_0095_0097 = 2u;

		private const uint _008B_0095_0098 = 1u;

		private const uint _008B_0095_0099 = 2u;

		private const uint _008B_0095_009A = 3u;

		private const uint _008B_0095_009B = 4u;

		internal static object _008B_0095_009C;

		internal static object _008B_0095_009D;

		private static SortedList _008B_0095_009E;

		private static SortedList _008B_0096_0086;

		private static bool _008B_0096_0087;

		private static bool _008B_0096_0088;

		internal static byte[] _008B_0096_0089;

		private uint _008B_0096_008A;

		private uint _008B_0096_008B;

		private uint _008B_0096_008C;

		private uint _008B_0096_008D;

		private uint _008B_0096_008E;

		private uint _008B_0096_008F;

		internal static byte[] _008B_0096_0090;

		internal static byte[] _008B_0096_0091;

		internal static string _008B_0096_0092;

		internal static string _008B_0096_0093;

		private static System.Timers.Timer _008B_0096_0094;

		private static DateTime _008B_0096_0095;

		private static byte[] _008B_0096_0096;

		private static bool _008B_0096_0097;

		private static string _008B_0096_0098;

		private static string _008B_0096_0099;

		private static string _008B_0096_009A;

		private static string _008B_0096_009B;

		private static bool _008B_0096_009C;

		private static bool _008B_0096_009D;

		private static object _008B_0096_009E;

		private static bool _008B_0097_0086;

		internal static bool _008B_0097_0087;

		internal static int _008B_0097_0088;

		internal static _0091_008F _008B_0097_0089;

		private static string _008B_0097_008A;

		internal static string _008B_0097_008B;

		internal static string _008B_0097_008C;

		private static string _008B_0097_008D;

		private static bool _008B_0097_008E;

		private static string _008B_0097_008F;

		private static bool _008B_0097_0090;

		private static string _008B_0097_0091;

		private static bool _008B_0097_0092;

		private static string _008B_0097_0093;

		private static bool _008B_0097_0094;

		private static Hashtable _008B_0097_0095;

		private static string _008B_0097_0096;

		private static bool _008B_0097_0097;

		private static string _008B_0097_0098;

		private static bool _008B_0097_0099;

		private static string _008B_0097_009A;

		private static bool _008B_0097_009B;

		private static Hashtable _008B_0097_009C;

		private static string _008B_0097_009D;

		private static bool _008B_0097_009E;

		private static string _008B_0098_0086;

		private static bool _008B_0098_0087;

		[MethodImpl(MethodImplOptions.NoInlining)]
		static _0091_008B()
		{
			_0090_009B._008B_0090_0088();
			int num = 18;
			byte[] array = default(byte[]);
			byte[] array2 = default(byte[]);
			int num5 = default(int);
			int num6 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num2 = num;
				while (true)
				{
					int num3 = num2;
					while (true)
					{
						switch (num3)
						{
						case 4:
							break;
						case 23:
							goto IL_0033;
						case 24:
							array[11] = (byte)num4;
							array[11] = 8;
							num6 = 35 + 34;
							num2 = 30;
							if (0 == 0)
							{
								goto end_IL_17ba;
							}
							goto case 42;
						case 42:
							num4 = 168 - 56;
							array[24] = (byte)num4;
							num4 = 242 - 80;
							array[24] = (byte)num4;
							array[24] = 118;
							array[25] = 199;
							num6 = 249 - 83;
							array[25] = (byte)num6;
							num2 = 36;
							if (_008B_0095_0088())
							{
								goto end_IL_17ba;
							}
							goto case 0;
						case 0:
							array[0] = 24;
							array[0] = 144;
							array[0] = 31;
							array[1] = 150;
							num6 = 44 + 65;
							array[1] = (byte)num6;
							array[1] = 86;
							array[1] = 141;
							num3 = 39;
							continue;
						case 34:
						case 48:
							array2[5] = 66;
							array2[5] = 132;
							num5 = 225 - 75;
							array2[5] = (byte)num5;
							array2[5] = 184;
							num5 = 222 - 74;
							array2[6] = (byte)num5;
							num5 = 204 - 68;
							num2 = 50;
							goto end_IL_17ba;
						case 43:
							goto IL_0357;
						case 37:
							_008B_0097_0087 = false;
							num3 = 6;
							continue;
						case 21:
							num4 = 26 + 120;
							array[30] = (byte)num4;
							num6 = 156 - 52;
							array[30] = (byte)num6;
							array[30] = 138;
							num4 = 126 - 33;
							array[30] = (byte)num4;
							num4 = 205 - 68;
							array[31] = (byte)num4;
							num4 = 59 + 16;
							array[31] = (byte)num4;
							array[31] = 74;
							array[31] = 142;
							num4 = 223 - 74;
							array[31] = (byte)num4;
							array[31] = 181;
							_008B_0096_0090 = array;
							array2 = new byte[16];
							num5 = 171 - 57;
							array2[0] = (byte)num5;
							array2[0] = 162;
							num5 = 50 + 10;
							array2[0] = (byte)num5;
							num5 = 117 - 45;
							array2[0] = (byte)num5;
							array2[1] = 162;
							num5 = 211 - 70;
							array2[1] = (byte)num5;
							num5 = 92 + 11;
							array2[1] = (byte)num5;
							num5 = 56 + 45;
							array2[1] = (byte)num5;
							array2[1] = 110;
							num5 = 158 - 71;
							array2[1] = (byte)num5;
							num5 = 41 + 108;
							array2[2] = (byte)num5;
							num5 = 78 + 59;
							array2[2] = (byte)num5;
							array2[2] = 168;
							num5 = 90 + 102;
							array2[2] = (byte)num5;
							array2[3] = 131;
							num5 = 248 - 82;
							array2[3] = (byte)num5;
							array2[3] = 159;
							num5 = 65 + 86;
							array2[3] = (byte)num5;
							num5 = 185 - 61;
							num3 = 43;
							continue;
						case 45:
							goto IL_0703;
						case 19:
							_008B_0095_009E = new SortedList();
							_008B_0096_0086 = new SortedList();
							_008B_0096_0087 = false;
							_008B_0096_0088 = false;
							_008B_0096_0089 = new byte[0];
							array = new byte[32];
							num4 = 81 + 22;
							array[0] = (byte)num4;
							num4 = 164 - 54;
							num2 = 26;
							goto end_IL_17ba;
						case 20:
							num6 = 165 - 55;
							array[9] = (byte)num6;
							array[9] = 98;
							array[9] = 132;
							array[9] = 130;
							num4 = 31 + 94;
							array[10] = (byte)num4;
							num6 = 216 - 72;
							array[10] = (byte)num6;
							num6 = 85 + 36;
							array[10] = (byte)num6;
							array[10] = 20;
							num4 = 208 - 69;
							array[11] = (byte)num4;
							num6 = 50 + 93;
							array[11] = (byte)num6;
							num4 = 160 - 53;
							num3 = 24;
							continue;
						case 2:
							num6 = 129 - 43;
							num2 = 35;
							if (0 == 0)
							{
								goto end_IL_17ba;
							}
							goto case 9;
						case 9:
							num4 = 112 - 24;
							num2 = 29;
							goto end_IL_17ba;
						case 41:
							num4 = 176 - 58;
							array[15] = (byte)num4;
							num6 = 114 + 63;
							array[15] = (byte)num6;
							num6 = 130 - 54;
							array[15] = (byte)num6;
							num4 = 45 + 32;
							array[16] = (byte)num4;
							array[16] = 191;
							num6 = 218 - 95;
							array[16] = (byte)num6;
							num2 = 16;
							goto end_IL_17ba;
						case 11:
							num6 = 108 + 21;
							array[13] = (byte)num6;
							num4 = 228 - 76;
							array[13] = (byte)num4;
							num2 = 9;
							goto end_IL_17ba;
						case 36:
							num4 = 225 - 75;
							array[25] = (byte)num4;
							num4 = 134 - 44;
							array[25] = (byte)num4;
							num4 = 203 - 86;
							num3 = 31;
							continue;
						case 8:
							array[17] = 146;
							num4 = 23 + 85;
							array[17] = (byte)num4;
							num2 = 46;
							if (!_008B_0095_0089())
							{
								goto end_IL_17ba;
							}
							goto case 47;
						case 10:
							array2[14] = 169;
							array2[14] = 14;
							num5 = 73 + 57;
							array2[15] = (byte)num5;
							num2 = 38;
							goto end_IL_17ba;
						case 30:
							goto IL_0afc;
						case 3:
							goto IL_0b23;
						case 35:
							goto IL_0bbc;
						case 40:
							array2[14] = (byte)num5;
							num5 = 217 - 72;
							array2[14] = (byte)num5;
							num3 = 10;
							continue;
						case 15:
							_008B_0097_008E = false;
							_008B_0097_008F = "";
							_008B_0097_0090 = false;
							goto case 47;
						case 31:
							array[25] = (byte)num4;
							num6 = 153 - 51;
							array[26] = (byte)num6;
							array[26] = 106;
							num6 = 190 - 63;
							array[26] = (byte)num6;
							array[26] = 110;
							array[26] = 28;
							num4 = 87 + 68;
							array[27] = (byte)num4;
							num4 = 72 + 123;
							array[27] = (byte)num4;
							num4 = 213 - 120;
							array[27] = (byte)num4;
							array[28] = 90;
							num4 = 175 - 58;
							array[28] = (byte)num4;
							array[28] = 118;
							array[28] = 96;
							num6 = 143 - 47;
							num3 = 25;
							continue;
						case 22:
							goto IL_0dc3;
						case 28:
							array2[10] = (byte)num5;
							num5 = 16 + 37;
							array2[11] = (byte)num5;
							array2[11] = 122;
							num5 = 92 + 50;
							num3 = 7;
							continue;
						case 50:
							array2[6] = (byte)num5;
							array2[6] = 3;
							num5 = 26 + 113;
							array2[7] = (byte)num5;
							num5 = 214 - 71;
							num2 = 1;
							if (0 == 0)
							{
								goto end_IL_17ba;
							}
							goto case 27;
						case 27:
							array[21] = (byte)num4;
							array[21] = 161;
							num = 23;
							goto end_IL_17b6;
						case 18:
							_008B_0095_009C = new object();
							num2 = 17;
							if (_008B_0095_0088())
							{
								goto end_IL_17ba;
							}
							goto case 13;
						case 13:
							num5 = 174 - 58;
							array2[13] = (byte)num5;
							array2[13] = 134;
							array2[13] = 12;
							num5 = 31 - 0;
							array2[13] = (byte)num5;
							array2[14] = 116;
							array2[14] = 169;
							num5 = 168 - 56;
							num2 = 40;
							if (true)
							{
								goto end_IL_17ba;
							}
							goto case 25;
						case 25:
							array[28] = (byte)num6;
							num6 = 172 - 66;
							array[28] = (byte)num6;
							array[29] = 171;
							num4 = 93 + 55;
							array[29] = (byte)num4;
							array[29] = 75;
							array[30] = 148;
							num2 = 21;
							if (_008B_0095_0088())
							{
								goto end_IL_17ba;
							}
							goto case 17;
						case 14:
							array[4] = 138;
							array[4] = 130;
							array[5] = 78;
							array[5] = 163;
							array[5] = 230;
							array[6] = 112;
							num4 = 153 - 51;
							array[6] = (byte)num4;
							array[6] = 150;
							array[6] = 50;
							array[7] = 128;
							num6 = 39 + 76;
							array[7] = (byte)num6;
							num4 = 157 - 52;
							array[7] = (byte)num4;
							num6 = 118 + 61;
							array[7] = (byte)num6;
							array[7] = 200;
							num6 = 253 - 84;
							array[8] = (byte)num6;
							num6 = 107 + 38;
							array[8] = (byte)num6;
							array[8] = 95;
							num3 = 20;
							continue;
						case 38:
							num5 = 107 + 82;
							array2[15] = (byte)num5;
							array2[15] = 118;
							num5 = 131 - 43;
							array2[15] = (byte)num5;
							num5 = 124 + 31;
							array2[15] = (byte)num5;
							num5 = 149 - 27;
							array2[15] = (byte)num5;
							_008B_0096_0091 = array2;
							_008B_0096_0092 = "";
							_008B_0096_0093 = "";
							_008B_0096_0096 = new byte[0];
							_008B_0096_0097 = false;
							_008B_0096_0098 = string.Empty;
							_008B_0096_0099 = string.Empty;
							_008B_0096_009A = string.Empty;
							_008B_0096_009B = string.Empty;
							_008B_0096_009C = false;
							_008B_0096_009D = false;
							_008B_0096_009E = new object();
							_008B_0097_0086 = false;
							num3 = 37;
							continue;
						case 1:
							array2[7] = (byte)num5;
							array2[7] = 90;
							num5 = 106 + 44;
							array2[7] = (byte)num5;
							num5 = 147 - 49;
							num3 = 33;
							continue;
						case 17:
							_008B_0095_009D = new object();
							num3 = 19;
							continue;
						case 29:
							array[13] = (byte)num4;
							num4 = 97 + 42;
							array[14] = (byte)num4;
							array[14] = 61;
							num4 = 150 - 50;
							array[14] = (byte)num4;
							num4 = 188 - 109;
							num2 = 22;
							if (true)
							{
								goto end_IL_17ba;
							}
							goto case 16;
						case 16:
							array[17] = 117;
							array[17] = 106;
							num3 = 8;
							continue;
						case 7:
							array2[11] = (byte)num5;
							array2[12] = 200;
							array2[12] = 143;
							array2[12] = 182;
							array2[12] = 23;
							num5 = 80 + 6;
							array2[13] = (byte)num5;
							num3 = 13;
							continue;
						case 6:
							_008B_0097_0088 = -1;
							_008B_0097_0089 = null;
							_008B_0097_008A = null;
							_008B_0097_008B = "";
							_008B_0097_008C = "";
							_008B_0097_008D = "";
							num2 = 15;
							goto end_IL_17ba;
						case 26:
							array[0] = (byte)num4;
							array[0] = 188;
							num2 = 0;
							goto end_IL_17ba;
						case 39:
							num4 = 167 - 55;
							array[1] = (byte)num4;
							array[1] = 254;
							num = 2;
							goto end_IL_17b6;
						case 5:
							_008B_0097_0094 = false;
							_008B_0097_0095 = new Hashtable();
							_008B_0097_0096 = "";
							_008B_0097_0097 = false;
							_008B_0097_0098 = "";
							_008B_0097_0099 = false;
							_008B_0097_009A = "";
							_008B_0097_009B = false;
							_008B_0097_009C = new Hashtable();
							_008B_0097_009D = "";
							_008B_0097_009E = false;
							_008B_0098_0086 = "";
							_008B_0098_0087 = false;
							num2 = 52;
							if (0 == 0)
							{
								goto end_IL_17ba;
							}
							goto case 32;
						case 32:
							array[12] = (byte)num4;
							num4 = 112 + 57;
							array[12] = (byte)num4;
							array[12] = 157;
							array[12] = 154;
							num6 = 232 - 77;
							array[13] = (byte)num6;
							array[13] = 122;
							num2 = 11;
							if (!_008B_0095_0089())
							{
								goto end_IL_17ba;
							}
							goto case 39;
						case 51:
							num6 = 139 - 46;
							array[19] = (byte)num6;
							array[19] = 95;
							num4 = 185 - 61;
							array[19] = (byte)num4;
							num4 = 173 + 31;
							array[19] = (byte)num4;
							array[20] = 151;
							num6 = 40 + 50;
							array[20] = (byte)num6;
							array[20] = 127;
							num4 = 152 - 78;
							array[20] = (byte)num4;
							num6 = 124 + 114;
							array[21] = (byte)num6;
							num4 = 17 + 97;
							array[21] = (byte)num4;
							num4 = 209 - 69;
							array[21] = (byte)num4;
							array[21] = 159;
							num4 = 244 - 81;
							goto case 27;
						default:
							num2 = 27;
							goto end_IL_17ba;
						case 12:
							_008B_0097_0092 = false;
							_008B_0097_0093 = "";
							num2 = 5;
							if (!_008B_0095_0089())
							{
								goto end_IL_17ba;
							}
							goto case 14;
						case 44:
							num4 = 99 + 34;
							array[3] = (byte)num4;
							array[3] = 154;
							array[3] = 118;
							num6 = 195 - 65;
							array[4] = (byte)num6;
							array[4] = 109;
							num3 = 14;
							continue;
						case 33:
							array2[7] = (byte)num5;
							num5 = 130 + 41;
							array2[7] = (byte)num5;
							array2[8] = 196;
							array2[8] = 144;
							array2[8] = 228;
							num5 = 137 - 45;
							array2[9] = (byte)num5;
							array2[9] = 100;
							array2[9] = 84;
							num5 = 59 + 97;
							array2[9] = (byte)num5;
							array2[10] = 144;
							num5 = 25 + 40;
							array2[10] = (byte)num5;
							num5 = 39 + 106;
							array2[10] = (byte)num5;
							num5 = 26 + 0;
							array2[10] = (byte)num5;
							num5 = 145 - 90;
							num2 = 28;
							goto end_IL_17ba;
						case 47:
						case 49:
							_008B_0097_0091 = "";
							num3 = 12;
							continue;
						case 46:
							array[17] = 125;
							num4 = 124 - 111;
							num3 = 3;
							continue;
						case 52:
							return;
						}
						array[3] = 223;
						num2 = 44;
						if (0 == 0)
						{
							break;
						}
						goto IL_0033;
						IL_0dc3:
						array[14] = (byte)num4;
						array[15] = 108;
						array[15] = 158;
						num = 41;
						goto end_IL_17b6;
						IL_0bbc:
						array[2] = (byte)num6;
						num6 = 141 - 47;
						array[2] = (byte)num6;
						array[2] = 103;
						num4 = 248 - 82;
						num = 45;
						goto end_IL_17b6;
						IL_0b23:
						array[17] = (byte)num4;
						num6 = 66 + 47;
						array[18] = (byte)num6;
						array[18] = 140;
						num4 = 124 + 122;
						array[18] = (byte)num4;
						array[19] = 104;
						num6 = 97 + 86;
						array[19] = (byte)num6;
						num = 51;
						goto end_IL_17b6;
						IL_0afc:
						array[12] = (byte)num6;
						num4 = 233 - 77;
						num = 32;
						goto end_IL_17b6;
						IL_0703:
						array[2] = (byte)num4;
						array[2] = 138;
						array[2] = 117;
						num = 4;
						goto end_IL_17b6;
						IL_0357:
						array2[4] = (byte)num5;
						array2[4] = 100;
						num5 = 45 + 15;
						array2[4] = (byte)num5;
						num5 = 109 + 63;
						array2[4] = (byte)num5;
						num5 = 36 + 117;
						array2[4] = (byte)num5;
						_ = 1;
						num3 = (_008B_0095_0089() ? 49 : 48);
						continue;
						IL_0033:
						num4 = 142 - 47;
						array[22] = (byte)num4;
						array[22] = 137;
						array[22] = 102;
						num6 = 186 - 112;
						array[22] = (byte)num6;
						num6 = 118 + 18;
						array[23] = (byte)num6;
						num6 = 233 - 77;
						array[23] = (byte)num6;
						num4 = 236 - 78;
						array[23] = (byte)num4;
						num4 = 210 - 111;
						array[23] = (byte)num4;
						array[24] = 101;
						num4 = 92 + 58;
						array[24] = (byte)num4;
						num = 42;
						goto end_IL_17b6;
						continue;
						end_IL_17ba:
						break;
					}
					continue;
					end_IL_17b6:
					break;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static int _008B_0091_0096()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_0091_0097(object P_0, DoWorkEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void _008B_0091_0098(object P_0, RunWorkerCompletedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public override License GetLicense(LicenseContext P_0, Type P_1, object P_2, bool P_3)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void mkLdf8923rwE89zRgl4s()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0091_0099(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0091_009A(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0091_009B(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0091_009C(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0091_009D(LicenseContext P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _008B_0091_009E(int P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal int _008B_0092_0086()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal int _008B_0092_0087(int P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal int _008B_0092_0088(int P_0, int P_1)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private int _008B_0092_0089(int P_0, int P_1)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal double _008B_0092_008A()
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _008B_0092_008B(byte[] P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal uint _008B_0092_008C()
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal int _008B_0092_008D()
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal bool _008B_0092_008E()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ilHifFeDUTsZtKIFfN18()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_0092_008F(object P_0, ElapsedEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _008B_0092_0090(byte[] P_0, byte[] P_1, int P_2, int P_3, int P_4)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_0092_0091(_0091_008F P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_0092_0092(_0091_008F P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008B_0092_0093(byte[] P_0, byte[] P_1, byte[] P_2, _0091_008F P_3, _0091_008F P_4, ref wR P_5, bool P_6)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_0092_0094(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008B_0092_0095(byte[] P_0, byte[] P_1, _0091_008F P_2, _0091_008F P_3, ref wR P_4, bool P_5, bool P_6, out string P_7, SecurityMode P_8, NetworkCredential P_9)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_0092_0096(object P_0, DoWorkEventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0092_0097(bool P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_0092_0098()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008B_0092_0099(int P_0, _0091_008F P_1, ref bool P_2, ref bool P_3, ref bool P_4, ref bool P_5, ref bool P_6, ref bool P_7)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0092_009A(ref _0091_008E P_0, string P_1, bool P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0092_009B(ref _0091_008E P_0, string P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0092_009C(ref _0091_008E P_0, Type P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_0092_009D(string P_0, string P_1, int P_2, ref _0091_008E P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0092_009E(ref _0091_008E P_0, string P_1, bool P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0093_0086(ref _0091_008E P_0, string P_1, string P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0093_0087(ref _0091_008E P_0, Type P_1, bool P_2, string P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void _008B_0093_0088(string P_0, string P_1, string P_2, int P_3)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal License _008B_0093_0089(LicenseContext P_0, Type P_1, object P_2, bool P_3, bool P_4, bool P_5, bool P_6, string P_7, string P_8, byte[] P_9, bool P_10, bool P_11, bool P_12)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string _008B_0093_008A(Assembly P_0, Type P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ShowMessage(string message)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void _008B_0093_008B(string P_0)
		{
		}

		[DllImport("user32.dll", EntryPoint = "EnableWindow")]
		internal static extern bool _008B_0093_008C(IntPtr P_0, bool P_1);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0093_008D()
		{
			return null;
		}

		[DllImport("kernel32.dll", EntryPoint = "GetModuleFileName", SetLastError = true)]
		public static extern uint _008B_0093_008E([In] IntPtr P_0, [Out] StringBuilder P_1, [In][MarshalAs(UnmanagedType.U4)] int P_2);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, EntryPoint = "TerminateProcess", SetLastError = true)]
		internal static extern bool _008B_0093_008F(IntPtr P_0, int P_1);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentProcess", SetLastError = true)]
		internal static extern IntPtr _008B_0093_0090();

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_0091(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_0092(bool P_0, bool P_1, bool P_2, bool P_3, bool P_4, bool P_5, bool P_6)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_0093()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_0094()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_0095(bool P_0, bool P_1, bool P_2, bool P_3, bool P_4, bool P_5)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_0096(bool P_0, bool P_1, bool P_2, bool P_3, bool P_4, bool P_5, bool P_6)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_0097(string P_0, bool P_1, bool P_2, bool P_3, bool P_4, bool P_5, bool P_6)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_0098(bool P_0, bool P_1, bool P_2, bool P_3, bool P_4, bool P_5, bool P_6)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_0099(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_009A(bool P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_009B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static uint _008B_0093_009C(string P_0, string P_1, string P_2)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0093_009D(string P_0, string P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ux _008B_0093_009E(string P_0, int P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008B_0094_0086(ux P_0, byte[] P_1, byte[] P_2)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static byte[] _008B_0094_0087(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void _008B_0094_0088(string P_0, byte[] P_1)
		{
		}

		[DllImport("kernel32", EntryPoint = "GetFileSize", SetLastError = true)]
		private static extern uint _008B_0094_0089(uint P_0, IntPtr P_1);

		[DllImport("kernel32", EntryPoint = "ReadFile", SetLastError = true)]
		private static extern uint _008B_0094_008A(uint P_0, byte[] P_1, uint P_2, ref uint P_3, IntPtr P_4);

		[DllImport("kernel32", EntryPoint = "CreateFile", SetLastError = true)]
		private static extern uint _008B_0094_008B(string P_0, uint P_1, uint P_2, IntPtr P_3, uint P_4, uint P_5, IntPtr P_6);

		[DllImport("kernel32.dll", EntryPoint = "CreateFile")]
		private static extern IntPtr _008B_0094_008C(string P_0, uint P_1, int P_2, IntPtr P_3, int P_4, int P_5, IntPtr P_6);

		[DllImport("kernel32.dll", EntryPoint = "WriteFile", SetLastError = true)]
		private static extern bool _008B_0094_008D(uint P_0, byte[] P_1, uint P_2, ref uint P_3, IntPtr P_4);

		[DllImport("kernel32.dll", EntryPoint = "CloseHandle", SetLastError = true)]
		private static extern bool _008B_0094_008E(uint P_0);

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_008F(string P_0, string P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static uint _008B_0094_0090(string P_0, string P_1, string P_2)
		{
			return 0u;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_0091()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_0092()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_0093()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008B_0094_0094(string P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_0095()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0094_0096(string P_0, string P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0094_0097(ManagementObjectCollection P_0, string P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static ManagementObjectCollection _008B_0094_0098(string P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_0099()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_009A()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_009B()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008B_0094_009C(string P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_009D()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static string _008B_0094_009E()
		{
			return null;
		}

		[DllImport("iphlpapi.dll", CharSet = CharSet.Ansi, EntryPoint = "GetAdaptersInfo")]
		internal static extern int _008B_0095_0086(IntPtr P_0, ref long P_1);

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static string _008B_0095_0087()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public _0091_008B()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008B_0095_0088()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool _008B_0095_0089()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool _008B_0095_008A()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool _008B_0095_008B()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool _008B_0095_008C()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static bool _008B_0095_008D()
		{
			return true;
		}
	}
}
