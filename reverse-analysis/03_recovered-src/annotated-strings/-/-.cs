using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Linq;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using _0087_0087;
using _0087_0089;
using _0087_008B;
using _0087_0095;
using _0087_0097;
using _0088_008E;
using _0088_0098;
using _0088_009A;
using _0088_009C;
using _0088_009E;
using _0089_0087;
using _0089_0089;
using _0089_008B;
using _0089_008D;
using _0089_008F;
using _0089_0091;
using _0089_0093;
using _0089_0095;
using _008A_0086;
using _008A_008A;
using _008B_008D;
using _008B_008F;
using _008B_0091;
using _008B_0095;
using _008B_0097;
using _008C;
using _008C_009C;
using _008E_008E;
using _008E_0098;
using _008F_008F;
using _0090_009C;
using _0091_008C;
using _009C;
using _009E;

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

		public _0087(double P_0, double P_1, double P_2, double P_3, double P_4, bool P_5, bool P_6)
		{
			_ = 0;
			if (_0089())
			{
				base._002Ector();
			}
			_0088 = P_0;
			if (_0089())
			{
				this._0089 = P_1;
			}
			this._008A = P_2;
			_008B = P_4;
			_008C = P_3;
			_008D = P_5;
			_008E = P_6;
		}

		public _008A_0089 _0087(_008F_008E P_0)
		{
			_008A_0089 obj2 = default(_008A_0089);
			if (false /* original-file-bool-offset:0 */)
			{
				if (_0089())
				{
					goto IL_01cc;
				}
			}
			else
			{
				_008A_0089 obj = new _008A_0089(P_0);
				obj._0088_008E_0096((P_0.Y < 0.0) ? "KK'线外" /* string-offset:4 */ : "KK'线内" /* string-offset:0 */);
				obj._0088_008F_0086(this._008A);
				obj2 = obj;
				if (!(P_0.X < 0.0 - _0088))
				{
					if (P_0.X < 0.0)
					{
						obj2._0088_008E_009C(Math.Abs(P_0.Y));
					}
					else
					{
						obj2._0088_008E_009C(Math.Sqrt(P_0.X * P_0.X + P_0.Y * P_0.Y));
					}
					goto IL_00e7;
				}
			}
			obj2._0088_008E_009C(Math.Sqrt((P_0.X + _0088) * (P_0.X + _0088) + P_0.Y * P_0.Y));
			goto IL_00e7;
			IL_031f:
			return obj2;
			IL_01cc:
			obj2._0088_008F_008F((obj2._0088_008E_009E() + obj2._0088_008E_009B()) * _008C + this._0089 + 5.0);
			obj2._0088_008F_0092((obj2._0088_008F_008B() - this._0089 - 5.0) / (obj2._0088_008E_009B() + obj2._0088_008E_009E()));
			goto IL_031f;
			IL_00e7:
			if (_008D && _008E)
			{
				obj2._0088_008F_0089(Math.Max((obj2._0088_008E_009E() + obj2._0088_008E_009B()) * 0.008, _008B));
				obj2._0088_008F_008C(P_0.Z + obj2._0088_008F_0088());
				obj2._0088_008F_008F(obj2._0088_008E_009B() * _008C + this._0089);
				obj2._0088_008F_0092((obj2._0088_008F_008B() - this._0089) / obj2._0088_008E_009B());
			}
			else
			{
				if (_008D)
				{
					_0089();
					if (_008A())
					{
						goto IL_031f;
					}
					if (!_008E)
					{
						obj2._0088_008F_0089(Math.Max((obj2._0088_008E_009E() + obj2._0088_008E_009B()) * 0.008, _008B));
						obj2._0088_008F_008C(P_0.Z + obj2._0088_008F_0088());
						goto IL_01cc;
					}
				}
				if (!_008D && _008E)
				{
					obj2._0088_008F_0089(_008B);
					do
					{
						obj2._0088_008F_008C(P_0.Z + _008B);
						obj2._0088_008F_008F(obj2._0088_008E_009B() * _008C + this._0089);
						obj2._0088_008F_0092((obj2._0088_008F_008B() - this._0089) / obj2._0088_008E_009B());
					}
					while (_008A());
				}
				else if (!_008D && !_008E)
				{
					obj2._0088_008F_0089(_008B);
					obj2._0088_008F_008C(P_0.Z + _008B);
					obj2._0088_008F_008F((obj2._0088_008E_009E() + obj2._0088_008E_009B()) * _008C + this._0089);
					obj2._0088_008F_0092((obj2._0088_008F_008B() - this._0089) / (obj2._0088_008E_009B() + obj2._0088_008E_009E()));
				}
				else
				{
					MessageBox.Show("参数错误！" /* string-offset:8 */);
				}
			}
			goto IL_031f;
		}

		static _0087()
		{
			LicenseManager.Validate(typeof(_0087));
		}

		internal static bool _0089()
		{
			return true;
		}

		internal static bool _008A()
		{
			return false;
		}
	}
}
namespace _008A
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0089 : IExtensionApplication
	{
		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _008F_009A
		{
			public string directoryPath;

			internal Assembly _008B_008D_0096(object sender, ResolveEventArgs args)
			{
				string text = Path.Combine(directoryPath, new AssemblyName(args.Name).Name + ".dll" /* string-offset:7520 */);
				if (File.Exists(text))
				{
					return Assembly.LoadFrom(text);
				}
				return null;
			}

			static _008F_009A()
			{
				LicenseManager.Validate(typeof(_008F_009A));
			}

			internal static bool _008A_008D()
			{
				return true;
			}

			internal static bool _008A_008E()
			{
				return false;
			}
		}

		private PaletteSet _0088_0087;

		public void Initialize()
		{
			try
			{
				_008F();
				string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				_ = 0;
				string text = default(string);
				if (_008D())
				{
					if (!_008E())
					{
					}
					text = (string)Application.GetSystemVariable("TRUSTEDPATHS" /* string-offset:276 */);
				}
				if (!text.Split(';').Contains(directoryName))
				{
					Application.SetSystemVariable("TRUSTEDPATHS" /* string-offset:276 */, (object)(text + ";" /* string-offset:280 */ + directoryName));
				}
				Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("风标设计2026【基础版】3.0加载成功。" /* string-offset:284 */);
				_0090();
			}
			catch (Exception ex)
			{
				_0096(ex);
			}
		}

		private void _008F()
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			if (!_008D())
			{
				goto IL_0096;
			}
			string[] array = default(string[]);
			while (true)
			{
				array = new string[2]
				{
					"dll" /* string-offset:288 */,
					"gis" /* string-offset:292 */
				};
				_008E();
				if (_008D())
				{
					break;
				}
				if (_008E())
				{
					continue;
				}
				goto IL_009a;
			}
			if (!_008D())
			{
				goto IL_0065;
			}
			int num = 0;
			goto IL_009a;
			IL_0096:
			num++;
			goto IL_009a;
			IL_009a:
			string path = default(string);
			_008F_009A obj = default(_008F_009A);
			if (num < array.Length)
			{
				path = array[num];
				obj = new _008F_009A();
				goto IL_0065;
			}
			return;
			IL_0065:
			obj.directoryPath = Path.Combine(directoryName, path);
			if (Directory.Exists(obj.directoryPath))
			{
				AppDomain.CurrentDomain.AssemblyResolve += obj._008B_008D_0096;
			}
			goto IL_0096;
		}

		[CommandMethod("WsTools")]
		public void _0090()
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			if (false /* original-file-bool-offset:4 */)
			{
				return;
			}
			try
			{
				if ((DisposableWrapper)(object)_0088_0087 == (DisposableWrapper)null)
				{
					_0088_0087 = new PaletteSet("风标设计2026【基础版】3.0" /* string-offset:296 */);
					_0088_0087.Add("传统程序" /* string-offset:300 */, (Control)_0088_008D._0090_0098("conv" /* string-offset:304 */));
					_0088_0087.Add("PBN程序" /* string-offset:308 */, (Control)_0088_008D._0090_0098("pbn" /* string-offset:312 */));
					_0088_0087.Add("辅助功能" /* string-offset:316 */, (Control)_0088_008D._0090_0098("misc" /* string-offset:320 */));
					Application.DocumentManager.DocumentCreated += new DocumentCollectionEventHandler(_0092);
					_008D();
					if (!_008E())
					{
						Application.DocumentManager.DocumentDestroyed += new DocumentDestroyedEventHandler(_0091);
						_0088_0087.Load += new PalettePersistEventHandler(_0095);
					}
					_0088_0087.Save += new PalettePersistEventHandler(_0094);
				}
				((Window)_0088_0087).Visible = true;
				_0088_0087.DockEnabled = (DockSides)16384;
				_0088_0087.Dock = (DockSides)16384;
				_0093();
			}
			catch (Exception ex)
			{
				_0097(ex);
			}
		}

		public void Terminate()
		{
		}

		private void _0091(object P_0, DocumentDestroyedEventArgs P_1)
		{
		}

		private void _0092(object P_0, DocumentCollectionEventArgs P_1)
		{
		}

		private void _0093()
		{
		}

		private void _0094(object P_0, PalettePersistEventArgs P_1)
		{
		}

		private void _0095(object P_0, PalettePersistEventArgs P_1)
		{
		}

		private void _0096(Exception P_0)
		{
			if (!true /* original-file-bool-offset:8 */)
			{
				return;
			}
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				_008E();
				if (_008D() && !_008E())
				{
					goto IL_0033;
				}
				goto IL_003c;
				IL_0033:
				if (!((DisposableWrapper)(object)mdiActiveDocument != (DisposableWrapper)null))
				{
					MessageBox.Show("插件初始化失败: " /* string-offset:336 */ + P_0.Message + "\n" /* string-offset:328 */ + P_0.StackTrace, "错误" /* string-offset:340 */, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				goto IL_003c;
				IL_003c:
				Editor editor = mdiActiveDocument.Editor;
				editor.WriteMessage("\n插件初始化失败: " /* string-offset:324 */ + P_0.Message + "\n" /* string-offset:328 */);
				editor.WriteMessage("堆栈跟踪: " /* string-offset:332 */ + P_0.StackTrace + "\n" /* string-offset:328 */);
				if (_008E())
				{
					goto IL_0033;
				}
			}
			catch
			{
				MessageBox.Show("插件初始化失败: " /* string-offset:336 */ + P_0.Message + "\n" /* string-offset:328 */ + P_0.StackTrace, "错误" /* string-offset:340 */, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void _0097(Exception P_0)
		{
			try
			{
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				editor.WriteMessage("\n工具栏初始化失败: " /* string-offset:344 */ + P_0.Message + "\n" /* string-offset:328 */);
				editor.WriteMessage("堆栈跟踪: " /* string-offset:332 */ + P_0.StackTrace + "\n" /* string-offset:328 */);
			}
			catch
			{
				MessageBox.Show("工具栏初始化失败: " /* string-offset:348 */ + P_0.Message + "\n" /* string-offset:328 */ + P_0.StackTrace, "错误" /* string-offset:340 */, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private int _0098(string P_0)
		{
			_008E();
			Form form = default(Form);
			if (_008D())
			{
				if (_008D())
				{
				}
				form = Application.OpenForms[P_0];
			}
			if (form != null && !form.IsDisposed)
			{
				form.WindowState = FormWindowState.Normal;
				form.Activate();
				form.Show();
				return 1;
			}
			return 0;
		}

		[CommandMethod("Hello")]
		public void _0099()
		{
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				_ = 1;
				if (!_008E())
				{
					goto IL_001a;
				}
				goto IL_0023;
				IL_001a:
				if (!((DisposableWrapper)(object)mdiActiveDocument != (DisposableWrapper)null))
				{
					MessageBox.Show("风标设计2026【基础版】3.0加载成功。" /* string-offset:284 */, "插件加载" /* string-offset:352 */, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				goto IL_0023;
				IL_0023:
				mdiActiveDocument.Editor.WriteMessage("风标设计2026【基础版】3.0加载成功。" /* string-offset:284 */);
				if (!_008D())
				{
					goto IL_001a;
				}
			}
			catch (Exception)
			{
			}
		}

		[CommandMethod("notReady")]
		public void _009A()
		{
			Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("攻城狮正在敲代码，请稍候。" /* string-offset:356 */);
		}

		[CommandMethod("Y01_风螺旋")]
		public void _009B()
		{
			if (_0098("FormWindSpiral" /* string-offset:360 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0089_0094());
			}
		}

		[CommandMethod("Y02_基础计算")]
		public void _009C()
		{
			if (_0098("FormCalcu" /* string-offset:364 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0088_009B());
			}
		}

		[CommandMethod("Y03_定位容差")]
		public void _009D()
		{
			if (_0098("FixTolerance" /* string-offset:368 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0088_0097());
			}
		}

		[CommandMethod("Y04_导航设备保护区")]
		public void _009E()
		{
			if (_0098("FormNavAids" /* string-offset:372 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0089_008A());
			}
		}

		[CommandMethod("Y05_精密进近保护区")]
		public void _0087_0086()
		{
			if (_0098("FormPA" /* string-offset:376 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0089_008C());
			}
		}

		[CommandMethod("Y06_传统模板")]
		public void _0087_0087()
		{
			if (_0098("FormTemplate" /* string-offset:380 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0089_0092());
			}
		}

		[CommandMethod("Y07_离场保护区")]
		public void _0087_0088()
		{
			if (_0098("FormDepartureEvl" /* string-offset:384 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0089_0086());
			}
		}

		[CommandMethod("Y08_转弯区评估")]
		public void _0087_0089()
		{
			if (_0098("FormTurnAreaEvl" /* string-offset:388 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0088_009D());
			}
		}

		[CommandMethod("Y09_主副区评估")]
		public void _0087_008A()
		{
			if (_0098("FormPriSecEvl" /* string-offset:392 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0089_008E());
			}
		}

		[CommandMethod("Y10_起始进近DME弧")]
		public void _0087_008B()
		{
			if (_0098("FormDmeEvl" /* string-offset:396 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0089_0088());
			}
		}

		[CommandMethod("Y51_FlyBy")]
		public void _0087_008C()
		{
			if (_0098("FormFlyBy" /* string-offset:400 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _008B_008E());
			}
		}

		[CommandMethod("Y52_FlyOver")]
		public void _0087_008D()
		{
			if (_0098("FormFlyOverDF" /* string-offset:404 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _008B_0090());
			}
		}

		[CommandMethod("Y53_RNP_APCH")]
		public void _0087_008E()
		{
			if (_0098("FormApvEvl" /* string-offset:408 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _008B_008C());
			}
		}

		[CommandMethod("Y54_PBN_ILS")]
		public void _0087_008F()
		{
			if (_0098("FormPbnIlsEvl" /* string-offset:412 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _008B_0096());
			}
		}

		[CommandMethod("Y55_PBN_Departure")]
		public void _0087_0090()
		{
			if (_0098("FormPbnDepEvl" /* string-offset:416 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _008B_0094());
			}
		}

		[CommandMethod("exline")]
		public void _0087_0091()
		{
			if (_0098("FormExLine" /* string-offset:420 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _008C_009B());
			}
		}

		[CommandMethod("RCL")]
		public void _0087_0092()
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Expected O, but got Unknown
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			if (!true /* original-file-bool-offset:12 */)
			{
				return;
			}
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Point3d val = global::_009E._009D._008B_008D("\n请选择跑道入口" /* string-offset:424 */);
			Point3d val2 = global::_009E._009D._008B_008D("\n请选择跑道末端" /* string-offset:428 */);
			if (!(val == val2))
			{
				double num = Math.Atan2(((Point3d)(ref val)).Y - ((Point3d)(ref val2)).Y, ((Point3d)(ref val)).X - ((Point3d)(ref val2)).X);
				double num2 = 40000.0 * Math.Cos(num);
				double num3;
				Database workingDatabase;
				Point3d val3 = default(Point3d);
				do
				{
					num3 = 40000.0 * Math.Sin(num);
					workingDatabase = HostApplicationServices.WorkingDatabase;
					((Point3d)(ref val3))._002Ector(((Point3d)(ref val)).X + num2, ((Point3d)(ref val)).Y + num3, 0.0);
				}
				while (!_008D());
				_008B._0088_008D((Entity)new Line(val, val3), workingDatabase);
				_008D();
				Point3d val4 = default(Point3d);
				if (!_008E())
				{
					((Point3d)(ref val4))._002Ector(((Point3d)(ref val2)).X - num2, ((Point3d)(ref val2)).Y - num3, 0.0);
				}
				_008B._0088_008D((Entity)new Line(val2, val4), workingDatabase);
			}
		}

		[CommandMethod("rectLine")]
		public void _0087_0093()
		{
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Expected O, but got Unknown
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Expected O, but got Unknown
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			if (!true /* original-file-bool-offset:16 */)
			{
				return;
			}
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			double num = 0.5 * global::_009E._009D._008B_008C("\n请输入矩形框的宽度（m）" /* string-offset:432 */);
			if (!_008D())
			{
				goto IL_018f;
			}
			Point3d val = global::_009E._009D._008B_008D("\n请选择起点" /* string-offset:436 */);
			Point3d val2 = global::_009E._009D._008B_008D("\n请选择终点" /* string-offset:440 */);
			double num3;
			double num4 = default(double);
			Database workingDatabase = default(Database);
			Point3d val3 = default(Point3d);
			Point3d val4 = default(Point3d);
			Point3d val5 = default(Point3d);
			if (_008D())
			{
				if (val == val2)
				{
					return;
				}
				double num2 = Math.Atan2(((Point3d)(ref val)).Y - ((Point3d)(ref val2)).Y, ((Point3d)(ref val)).X - ((Point3d)(ref val2)).X);
				num3 = num * Math.Cos(num2 + Math.PI / 2.0);
				_008E();
				if (_008D())
				{
					if (!_008D())
					{
						goto IL_0150;
					}
					num4 = num * Math.Sin(num2 + Math.PI / 2.0);
				}
				workingDatabase = HostApplicationServices.WorkingDatabase;
				((Point3d)(ref val3))._002Ector(((Point3d)(ref val)).X + num3, ((Point3d)(ref val)).Y + num4, 0.0);
				((Point3d)(ref val4))._002Ector(((Point3d)(ref val)).X - num3, ((Point3d)(ref val)).Y - num4, 0.0);
				((Point3d)(ref val5))._002Ector(((Point3d)(ref val2)).X - num3, ((Point3d)(ref val2)).Y - num4, 0.0);
				goto IL_0150;
			}
			goto IL_01a3;
			IL_0150:
			Point3d val6 = default(Point3d);
			((Point3d)(ref val6))._002Ector(((Point3d)(ref val2)).X + num3, ((Point3d)(ref val2)).Y + num4, 0.0);
			Point3dCollection val7 = new Point3dCollection();
			val7.Add(val3);
			val7.Add(val4);
			goto IL_018f;
			IL_018f:
			val7.Add(val5);
			val7.Add(val6);
			goto IL_01a3;
			IL_01a3:
			_008B._0088_008D((Entity)new Polyline3d((Poly3dType)0, val7, true), workingDatabase);
		}

		[CommandMethod("NMCIRCLE")]
		public void _0087_0094()
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Invalid comparison between Unknown and I4
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			Editor editor = default(Editor);
			Point3d val = default(Point3d);
			double num2 = default(double);
			double value = default(double);
			Database workingDatabase = default(Database);
			PromptDoubleResult val2 = default(PromptDoubleResult);
			while (true)
			{
				IL_01d3:
				int num;
				if (!false /* original-file-bool-offset:20 */)
				{
					editor = Application.DocumentManager.MdiActiveDocument.Editor;
					val = global::_009E._009D._008B_008D("\n请选择圆心点" /* string-offset:444 */);
					num = 2;
					if (!_008E())
					{
						goto IL_0060;
					}
					goto IL_0187;
				}
				_ = 1;
				if (!_008E())
				{
					num = 3;
					if (!_008D())
					{
						goto IL_00b4;
					}
					break;
				}
				num = 7;
				goto IL_0106;
				IL_00df:
				num2 = value * 1852.0;
				_008B._0088_008D((Entity)new Circle(val, Vector3d.ZAxis, num2), workingDatabase);
				goto IL_0106;
				IL_00b4:
				val2 = editor.GetDouble("\n请输入半径(单位：海里)，按Esc键退出。" /* string-offset:448 */);
				goto IL_00c5;
				IL_0106:
				_008B._0088_008D((Entity)new DBText
				{
					Height = 500.0,
					TextString = "---" /* string-offset:452 */ + value.ToString("0.#" /* string-offset:456 */) + " nm---" /* string-offset:460 */,
					HorizontalMode = (TextHorizontalMode)1,
					VerticalMode = (TextVerticalMode)1,
					AlignmentPoint = new Point3d(((Point3d)(ref val)).X, ((Point3d)(ref val)).Y + num2, ((Point3d)(ref val)).Z)
				}, workingDatabase);
				goto IL_0187;
				IL_0060:
				while (true)
				{
					switch (num)
					{
					default:
						num = 9;
						if (!_008E())
						{
							continue;
						}
						break;
					case 2:
						workingDatabase = HostApplicationServices.WorkingDatabase;
						num = 5;
						if (!_008D())
						{
							goto IL_01d3;
						}
						break;
					case 5:
						break;
					case 0:
					case 4:
						goto IL_00c5;
					case 9:
						goto IL_00df;
					case 6:
					case 7:
						goto IL_0106;
					case 8:
						goto IL_0187;
					case 10:
						goto IL_01d3;
					case 1:
					case 3:
					case 11:
						return;
					}
					break;
				}
				goto IL_00b4;
				IL_0187:
				val2 = editor.GetDouble("\n请输入半径(单位NM)" /* string-offset:464 */);
				num = 4;
				goto IL_00c5;
				IL_00c5:
				if ((int)((PromptResult)val2).Status != 5100)
				{
					num = 11;
					if (!_008E())
					{
						goto IL_0060;
					}
					break;
				}
				value = val2.Value;
				goto IL_00df;
			}
		}

		[CommandMethod("Arc2")]
		public void _0087_0095()
		{
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			int num = 4;
			Database database = default(Database);
			Point3d val = default(Point3d);
			Point3d val2 = default(Point3d);
			double num2 = default(double);
			double num3 = default(double);
			while (true /* original-file-bool-offset:24 */)
			{
				num = 0;
				if (!_008E())
				{
					while (true)
					{
						switch (num)
						{
						case 0:
							do
							{
								database = Application.DocumentManager.MdiActiveDocument.Database;
								num = 6;
							}
							while (!_008D());
							continue;
						case 6:
							val = global::_009E._009D._008B_008D("请选择圆心点" /* string-offset:468 */);
							_ = 1;
							if (_008E())
							{
								num = 2;
								if (_008E())
								{
									break;
								}
								goto IL_0141;
							}
							num = 1;
							goto case 1;
						case 4:
							break;
						default:
							num = 7;
							goto IL_011c;
						case 1:
						case 3:
							val2 = global::_009E._009D._008B_008D("请选择圆弧点" /* string-offset:472 */);
							num2 = Math.Sqrt((((Point3d)(ref val)).X - ((Point3d)(ref val2)).X) * (((Point3d)(ref val)).X - ((Point3d)(ref val2)).X) + (((Point3d)(ref val)).Y - ((Point3d)(ref val2)).Y) * (((Point3d)(ref val)).Y - ((Point3d)(ref val2)).Y));
							goto IL_011c;
						case 7:
							goto IL_011c;
						case 2:
						case 5:
							goto IL_0141;
						case 8:
							return;
						}
						break;
					}
					continue;
				}
				goto IL_0141;
				IL_0141:
				_008B._0088_008D((Entity)new Arc(val, num2, num3 - Math.PI / 3.0, num3 + Math.PI / 3.0), database);
				num = 8;
				if (_008D())
				{
					break;
				}
				goto IL_011c;
				IL_011c:
				num3 = Math.Atan2(((Point3d)(ref val2)).Y - ((Point3d)(ref val)).Y, ((Point3d)(ref val2)).X - ((Point3d)(ref val)).X);
				goto IL_0141;
			}
		}

		[CommandMethod("Y92_RandomPoint")]
		public void _0087_0096()
		{
			if (_0098("FormRandPoint" /* string-offset:476 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0089_0090());
			}
		}

		[CommandMethod("Y90_LoadBlock")]
		public void _0087_0097()
		{
			if (_0098("FormBlockImport" /* string-offset:480 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0088_0099());
			}
		}

		[CommandMethod("Y91_CreateLayer")]
		public void _0087_0098()
		{
			if (_0098("LayerFactoryForm" /* string-offset:484 */) <= 0)
			{
				Application.ShowModelessDialog((Form)new _0089_009E());
			}
		}

		[CommandMethod("xInfo")]
		public void _0087_0099()
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Invalid comparison between Unknown and I4
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			if (false /* original-file-bool-offset:28 */)
			{
				return;
			}
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptEntityOptions val = new PromptEntityOptions("请选择实体对象" /* string-offset:488 */);
			if (!_008D())
			{
				return;
			}
			PromptEntityResult entity = editor.GetEntity(val);
			_008E();
			if (!_008D() || (int)((PromptResult)entity).Status != 5100)
			{
				return;
			}
			Transaction val2 = Application.DocumentManager.MdiActiveDocument.Database.TransactionManager.StartTransaction();
			try
			{
				ResultBuffer xData = ((DBObject)(Entity)val2.GetObject(entity.ObjectId, (OpenMode)0)).XData;
				if (_008E() || xData != (ResultBuffer)null)
				{
					TypedValue[] array = xData.AsArray();
					string text = "";
					TypedValue[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						TypedValue val3 = array2[i];
						if (((TypedValue)(ref val3)).TypeCode == 1001)
						{
							text = ((TypedValue)(ref val3)).Value.ToString();
							continue;
						}
						string text3;
						if (!(((TypedValue)(ref val3)).Value is string text2))
						{
							_ = 0;
							if (!_008D())
							{
								continue;
							}
							text3 = ((TypedValue)(ref val3)).Value.ToString();
						}
						else
						{
							text3 = text2;
						}
						string text4 = text3;
						_0087_009A(editor, text, text4);
					}
				}
				else
				{
					editor.WriteMessage("Non-Information avaiable\n" /* string-offset:492 */);
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}

		private static void _0087_009A(Editor P_0, string P_1, string P_2)
		{
			string text = P_2.TrimStart();
			if (!text.StartsWith("{" /* string-offset:496 */) && !text.StartsWith("[" /* string-offset:500 */))
			{
				P_0.WriteMessage(P_1 + " = " /* string-offset:504 */ + P_2 + "\n" /* string-offset:328 */);
				return;
			}
			P_0.WriteMessage(P_1 + "\n" /* string-offset:328 */);
			int num = 0;
			_008D();
			if (!_008E())
			{
				_0087_009B(P_0, text, ref num, 1);
			}
		}

		private static void _0087_009B(Editor P_0, string P_1, ref int P_2, int P_3)
		{
			if (!true /* original-file-bool-offset:32 */)
			{
				return;
			}
			_0087_009C(P_1, ref P_2);
			if (P_2 >= P_1.Length)
			{
				return;
			}
			string text = new string(' ', P_3 * 2);
			if (!_008D())
			{
				goto IL_00a0;
			}
			char c = P_1[P_2];
			if (c == '{')
			{
				P_2++;
				goto IL_0113;
			}
			if (c != '[')
			{
				if (c != '"')
				{
					P_0.WriteMessage(text + _0088_0086(P_1, ref P_2) + "\n" /* string-offset:328 */);
					if (!_008E())
					{
						return;
					}
				}
				P_0.WriteMessage(text + _0087_009E(P_1, ref P_2) + "\n" /* string-offset:328 */);
				return;
			}
			goto IL_0152;
			IL_00a0:
			string text2 = default(string);
			P_0.WriteMessage(text + text2 + " = " /* string-offset:504 */ + _0088_0086(P_1, ref P_2) + "\n" /* string-offset:328 */);
			goto IL_00dd;
			IL_0152:
			P_2++;
			while (true)
			{
				_0087_009C(P_1, ref P_2);
				if (P_2 >= P_1.Length || P_1[P_2] != ']')
				{
					if (_0087_009D(P_1, P_2))
					{
						P_0.WriteMessage(text + "- " /* string-offset:508 */ + _0088_0086(P_1, ref P_2) + "\n" /* string-offset:328 */);
					}
					else
					{
						P_0.WriteMessage(text + "-\n" /* string-offset:512 */);
						_0087_009B(P_0, P_1, ref P_2, P_3 + 1);
					}
					_0087_009C(P_1, ref P_2);
					if (P_2 < P_1.Length && P_1[P_2] == ',')
					{
						P_2++;
					}
					continue;
				}
				break;
			}
			goto IL_01fd;
			IL_0113:
			_0087_009C(P_1, ref P_2);
			if (P_2 >= P_1.Length || P_1[P_2] != '}')
			{
				text2 = _0087_009E(P_1, ref P_2);
				_0087_009C(P_1, ref P_2);
				if (!_008E())
				{
					P_2++;
					_0087_009C(P_1, ref P_2);
					if (!_0087_009D(P_1, P_2))
					{
						P_0.WriteMessage(text + text2 + "\n" /* string-offset:328 */);
						_0087_009B(P_0, P_1, ref P_2, P_3 + 1);
						goto IL_00dd;
					}
				}
				goto IL_00a0;
			}
			if (!_008E())
			{
				P_2++;
				_008D();
				if (!_008E())
				{
					return;
				}
				goto IL_0152;
			}
			goto IL_01fd;
			IL_00dd:
			_0087_009C(P_1, ref P_2);
			if (P_2 < P_1.Length && P_1[P_2] == ',')
			{
				P_2++;
			}
			goto IL_0113;
			IL_01fd:
			P_2++;
		}

		private static void _0087_009C(string P_0, ref int P_1)
		{
			while (P_1 < P_0.Length)
			{
				do
				{
					if (char.IsWhiteSpace(P_0[P_1]))
					{
						P_1++;
						_008D();
						continue;
					}
					return;
				}
				while (_008E());
			}
		}

		private static bool _0087_009D(string P_0, int P_1)
		{
			if (P_1 < P_0.Length && P_0[P_1] != '{')
			{
				return P_0[P_1] != '[';
			}
			return false;
		}

		private static string _0087_009E(string P_0, ref int P_1)
		{
			if (false /* original-file-bool-offset:36 */)
			{
				goto IL_009e;
			}
			P_1++;
			StringBuilder stringBuilder = new StringBuilder();
			goto IL_00b1;
			IL_009e:
			char c = default(char);
			stringBuilder.Append(c);
			goto IL_00b1;
			IL_00b1:
			while (true)
			{
				if (P_1 < P_0.Length)
				{
					char c2 = P_0[P_1++];
					_008E();
					if (!_008D())
					{
						break;
					}
					if (c2 == '\\' && P_1 < P_0.Length)
					{
						c = P_0[P_1++];
						switch (c)
						{
						case 't':
							stringBuilder.Append('\t');
							continue;
						case 'r':
							stringBuilder.Append('\r');
							continue;
						case 'n':
							stringBuilder.Append('\n');
							continue;
						}
						break;
					}
					if (c2 != '"')
					{
						stringBuilder.Append(c2);
						continue;
					}
				}
				else if (!_008D())
				{
					break;
				}
				return stringBuilder.ToString();
			}
			goto IL_009e;
		}

		private static string _0088_0086(string P_0, ref int P_1)
		{
			int num = P_1;
			_008D();
			if (!_008E())
			{
				goto IL_001b;
			}
			goto IL_003d;
			IL_001b:
			if (P_1 < P_0.Length && P_0[P_1] != ',' && P_0[P_1] != '}')
			{
				goto IL_003d;
			}
			goto IL_0049;
			IL_003d:
			if (P_0[P_1] != ']')
			{
				P_1++;
				goto IL_001b;
			}
			goto IL_0049;
			IL_0049:
			return P_0.Substring(num, P_1 - num).Trim();
		}

		static _0089()
		{
			LicenseManager.Validate(typeof(_0089));
		}

		internal static bool _008D()
		{
			return true;
		}

		internal static bool _008E()
		{
			return false;
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

			internal void _008B_008D_0097(Entity ent)
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				btr.AppendEntity(ent);
			}

			static _008F_009B()
			{
				LicenseManager.Validate(typeof(_008F_009B));
			}

			internal static bool _008A_008F()
			{
				return true;
			}

			internal static bool _008A_0090()
			{
				return false;
			}
		}

		public static void _0088_0088(Database P_0, List<_008F_008E> P_1, string P_2 = "")
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Editor editor = mdiActiveDocument.Editor;
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				Polyline val2 = new Polyline();
				_0087_0088._008C_008E(val2, P_1._008C_008B());
				_0088_008D((Entity)val2, P_0, P_2);
				editor.Regen();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static void _0088_0089(Database P_0, List<List<_008F_008E>> P_1, string P_2 = "")
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_005d: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			if (!true /* original-file-bool-offset:40 */)
			{
				return;
			}
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = P_0.TransactionManager.StartTransaction();
				try
				{
					Group val3 = new Group();
					foreach (List<_008F_008E> item in P_1)
					{
						Polyline val4 = new Polyline();
						_0087_0088._008C_008E(val4, item._008C_008B());
						ObjectId val5 = _0088_008D((Entity)val4, P_0, P_2);
						val3.Append(val5);
					}
					P_0.AddDBObject((DBObject)(object)val3);
					val2.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
					val2.Commit();
					Application.UpdateScreen();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static void _0088_008A(Database P_0, List<_008F_008E> P_1, string P_2 = "")
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Editor editor = mdiActiveDocument.Editor;
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				Polyline val2 = new Polyline();
				_0087_0088._008C_008F(val2, P_1._008C_008B());
				_0088_008D((Entity)val2, P_0, P_2);
				editor.Regen();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static void _0088_008B(Database P_0, List<List<_008F_008E>> P_1, string P_2 = "")
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_005d: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			if (false /* original-file-bool-offset:44 */)
			{
				return;
			}
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = P_0.TransactionManager.StartTransaction();
				try
				{
					Group val3 = new Group();
					foreach (List<_008F_008E> item in P_1)
					{
						Polyline val4 = new Polyline();
						_0087_0088._008C_008F(val4, item._008C_008B());
						ObjectId val5 = _0088_008D((Entity)val4, P_0, P_2);
						val3.Append(val5);
					}
					P_0.AddDBObject((DBObject)(object)val3);
					val2.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
					val2.Commit();
					Application.UpdateScreen();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static void _0088_008C(List<Entity> P_0, Database P_1, string P_2 = "")
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			if (!true /* original-file-bool-offset:48 */)
			{
				return;
			}
			try
			{
				DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
				try
				{
					Transaction val2 = P_1.TransactionManager.StartTransaction();
					try
					{
						ResultBuffer val3 = new ResultBuffer();
						if (P_2.Trim().Length > 0)
						{
							DBObject obj = val2.GetObject(P_1.RegAppTableId, (OpenMode)1);
							RegAppTable val4 = (RegAppTable)(object)((obj is RegAppTable) ? obj : null);
							if (!((SymbolTable)val4).Has("WsInfo" /* string-offset:516 */))
							{
								RegAppTableRecord val5 = new RegAppTableRecord();
								((SymbolTableRecord)val5).Name = "WsInfo" /* string-offset:516 */;
								((SymbolTable)val4).Add((SymbolTableRecord)(object)val5);
								val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
							}
							val3.Add(new TypedValue(1001, (object)"WsInfo" /* string-offset:516 */));
							val3.Add(new TypedValue(1000, (object)P_2));
						}
						BlockTable val6 = (BlockTable)val2.GetObject(P_1.BlockTableId, (OpenMode)0);
						BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val6)[BlockTableRecord.ModelSpace], (OpenMode)1);
						foreach (Entity item in P_0)
						{
							val7.AppendEntity(item);
							if (val3 != (ResultBuffer)null)
							{
								((DBObject)item).XData = val3;
							}
							val2.AddNewlyCreatedDBObject((DBObject)(object)item, true);
						}
						val2.Commit();
						Application.UpdateScreen();
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			catch (Exception ex)
			{
				Application.ShowAlertDialog("绘制失败。\n" /* string-offset:520 */ + ex.ToString());
			}
		}

		public static ObjectId _0088_008D(Entity P_0, Database P_1, string P_2 = "")
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			ObjectId result = default(ObjectId);
			try
			{
				DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
				try
				{
					Transaction val2 = P_1.TransactionManager.StartTransaction();
					try
					{
						ResultBuffer val3 = new ResultBuffer();
						if (P_2.Trim().Length > 0)
						{
							DBObject obj = val2.GetObject(P_1.RegAppTableId, (OpenMode)1);
							RegAppTable val4 = (RegAppTable)(object)((obj is RegAppTable) ? obj : null);
							if (!((SymbolTable)val4).Has("WsObject" /* string-offset:524 */))
							{
								RegAppTableRecord val5 = new RegAppTableRecord();
								_ = 1;
								if (_0090())
								{
									goto IL_00b5;
								}
								((SymbolTableRecord)val5).Name = "WsObject" /* string-offset:524 */;
								((SymbolTable)val4).Add((SymbolTableRecord)(object)val5);
								val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
							}
							val3.Add(new TypedValue(1001, (object)"WsObject" /* string-offset:524 */));
							goto IL_00b5;
						}
						goto IL_00cd;
						IL_00cd:
						BlockTable val6 = (BlockTable)val2.GetObject(P_1.BlockTableId, (OpenMode)0);
						result = ((BlockTableRecord)val2.GetObject(((SymbolTable)val6)[BlockTableRecord.ModelSpace], (OpenMode)1)).AppendEntity(P_0);
						val2.AddNewlyCreatedDBObject((DBObject)(object)P_0, true);
						val2.Commit();
						Application.UpdateScreen();
						goto end_IL_0024;
						IL_00b5:
						val3.Add(new TypedValue(1000, (object)P_2));
						((DBObject)P_0).XData = val3;
						goto IL_00cd;
						end_IL_0024:;
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			catch (Exception ex)
			{
				Application.ShowAlertDialog("绘制失败。\n" /* string-offset:520 */ + ex.ToString());
			}
			return result;
		}

		public static ObjectId _0088_008E(this Database P_0, string P_1, List<Entity> P_2)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			ObjectId blockTableId = P_0.BlockTableId;
			BlockTable val = (BlockTable)((ObjectId)(ref blockTableId)).GetObject((OpenMode)0);
			if (!((SymbolTable)val).Has(P_1))
			{
				BlockTableRecord btr = new BlockTableRecord();
				((SymbolTableRecord)btr).Name = P_1;
				P_2.ForEach(delegate(Entity ent)
				{
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					btr.AppendEntity(ent);
				});
				((DBObject)val).UpgradeOpen();
				((SymbolTable)val).Add((SymbolTableRecord)(object)btr);
				P_0.TransactionManager.AddNewlyCreatedDBObject((DBObject)(object)btr, true);
				((DBObject)val).DowngradeOpen();
			}
			return ((SymbolTable)val)[P_1];
		}

		public static double _0088_008F(ObjectId P_0)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			double result = 0.0;
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DBObject obj = val2.GetObject(P_0, (OpenMode)1);
					Entity val3 = (Entity)(object)((obj is Entity) ? obj : null);
					if ((DisposableWrapper)(object)val3 != (DisposableWrapper)null)
					{
						goto IL_006c;
					}
					_ = 0;
					if (!_008F())
					{
						goto IL_0075;
					}
					if (!((DisposableWrapper)val3).IsDisposed)
					{
						goto IL_006c;
					}
					Application.ShowAlertDialog("未找到指定的实体。" /* string-offset:528 */);
					goto end_IL_002d;
					IL_0075:
					Extents3d geometricExtents = val3.GeometricExtents;
					Point3d val4 = ((Extents3d)(ref geometricExtents)).MaxPoint;
					double y = ((Point3d)(ref val4)).Y;
					val4 = ((Extents3d)(ref geometricExtents)).MinPoint;
					result = y - ((Point3d)(ref val4)).Y;
					goto IL_00a0;
					IL_00a0:
					val2.Commit();
					goto end_IL_002d;
					IL_006c:
					if (val3 is BlockReference)
					{
						goto IL_0075;
					}
					goto IL_00a0;
					end_IL_002d:;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return result;
		}

		public static double _0088_0090(ObjectId P_0)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			double result = 0.0;
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DBObject obj = val2.GetObject(P_0, (OpenMode)1);
					Entity val3 = (Entity)(object)((obj is Entity) ? obj : null);
					int num = 7;
					Extents3d geometricExtents = default(Extents3d);
					Point3d val4 = default(Point3d);
					if (!_0090())
					{
						while (true)
						{
							switch (num)
							{
							case 7:
								if (!((DisposableWrapper)(object)val3 != (DisposableWrapper)null))
								{
									num = 4;
									goto case 4;
								}
								goto case 0;
							case 4:
								if (!((DisposableWrapper)val3).IsDisposed)
								{
									_ = 0;
									if (_008F())
									{
										num = 0;
										goto case 0;
									}
									num = 1;
									goto IL_0122;
								}
								Application.ShowAlertDialog("未找到指定的实体。" /* string-offset:528 */);
								goto end_IL_002d;
							case 0:
							case 2:
								if (val3 is BlockReference)
								{
									goto case 3;
								}
								goto IL_0122;
							case 3:
								geometricExtents = val3.GeometricExtents;
								val4 = ((Extents3d)(ref geometricExtents)).MaxPoint;
								num = 6;
								if (!_0090())
								{
									continue;
								}
								goto IL_0122;
							default:
								num = 3;
								goto case 3;
							case 6:
								break;
							case 1:
							case 5:
								goto IL_0122;
							case 8:
								goto end_IL_002d;
							}
							break;
						}
					}
					double x = ((Point3d)(ref val4)).X;
					val4 = ((Extents3d)(ref geometricExtents)).MinPoint;
					result = x - ((Point3d)(ref val4)).X;
					goto IL_0122;
					IL_0122:
					val2.Commit();
					num = 8;
					end_IL_002d:;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return result;
		}

		public static void _0088_0091(ObjectId P_0, double P_1, Point3d P_2)
		{
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			_ = 1;
			Database database = default(Database);
			DocumentLock val = default(DocumentLock);
			if (!_0090())
			{
				if (false /* original-file-bool-offset:52 */)
				{
					return;
				}
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				database = mdiActiveDocument.Database;
				val = mdiActiveDocument.LockDocument();
			}
			else if (!_0090())
			{
				return;
			}
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DBObject obj = val2.GetObject(P_0, (OpenMode)1);
					Entity val3 = (Entity)(object)((obj is Entity) ? obj : null);
					if ((DisposableWrapper)(object)val3 != (DisposableWrapper)null)
					{
						Extents3d geometricExtents;
						if (val3 is BlockReference)
						{
							Entity obj2 = ((val3 is BlockReference) ? val3 : null);
							Matrix3d val4 = Matrix3d.Scaling(P_1, P_2);
							obj2.TransformBy(val4);
							((DBObject)obj2).UpgradeOpen();
							obj2.RecordGraphicsModified(true);
						}
						else if (val3 is Curve)
						{
							Curve val5 = (Curve)(object)((val3 is Curve) ? val3 : null);
							_ = 1;
							if (!_0090())
							{
								geometricExtents = ((Entity)val5).GeometricExtents;
								((Entity)val5).TransformBy(Matrix3d.Scaling(P_1, ((Extents3d)(ref geometricExtents)).MinPoint));
							}
						}
						else if (val3 is Solid && _008F())
						{
							Solid val6 = (Solid)(object)((val3 is Solid) ? val3 : null);
							geometricExtents = ((Entity)val6).GeometricExtents;
							((Entity)val6).TransformBy(Matrix3d.Scaling(P_1, ((Extents3d)(ref geometricExtents)).MinPoint));
						}
						val2.Commit();
					}
					else
					{
						Application.ShowAlertDialog("未找到指定的实体。" /* string-offset:528 */);
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static ObjectId _0088_0092(this Database P_0, string P_1, params Entity[] ents)
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return P_0._0088_008E(P_1, ents.ToList());
		}

		public static ObjectId _0088_0093(this ObjectId P_0, string P_1, string P_2, Point3d P_3, Scale3d P_4, double P_5)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			_ = 1;
			if (!_0090())
			{
				Database database = ((ObjectId)(ref P_0)).Database;
				ObjectId blockTableId = database.BlockTableId;
				BlockTable val = default(BlockTable);
				if (_008F())
				{
					val = (BlockTable)((ObjectId)(ref blockTableId)).GetObject((OpenMode)0);
				}
				if (((SymbolTable)val).Has(P_2))
				{
					BlockTableRecord val2 = (BlockTableRecord)((ObjectId)(ref P_0)).GetObject((OpenMode)1);
					BlockReference val3 = new BlockReference(P_3, ((SymbolTable)val)[P_2]);
					val3.ScaleFactors = P_4;
					((Entity)val3).Layer = P_1;
					val3.Rotation = P_5;
					ObjectId result = val2.AppendEntity((Entity)(object)val3);
					database.TransactionManager.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
					((DBObject)val2).DowngradeOpen();
					return result;
				}
			}
			return ObjectId.Null;
		}

		public static void _0088_0094(this ObjectId P_0, List<AttributeDefinition> P_1)
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			Database database = ((ObjectId)(ref P_0)).Database;
			BlockTableRecord val = (BlockTableRecord)((ObjectId)(ref P_0)).GetObject((OpenMode)1);
			foreach (AttributeDefinition item in P_1)
			{
				val.AppendEntity((Entity)(object)item);
				database.TransactionManager.AddNewlyCreatedDBObject((DBObject)(object)item, true);
			}
			((DBObject)val).DowngradeOpen();
		}

		public static void _0088_0095(this ObjectId P_0, params AttributeDefinition[] atts)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			P_0._0088_0094(atts.ToList());
		}

		public static ObjectId _0088_0096(this ObjectId P_0, string P_1, string P_2, Point3d P_3, Scale3d P_4, double P_5, Dictionary<string, string> P_6)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			Database database = ((ObjectId)(ref P_0)).Database;
			ObjectId blockTableId = database.BlockTableId;
			BlockTable val = (BlockTable)((ObjectId)(ref blockTableId)).GetObject((OpenMode)0);
			if (!((SymbolTable)val).Has(P_2))
			{
				return ObjectId.Null;
			}
			BlockTableRecord val2 = (BlockTableRecord)((ObjectId)(ref P_0)).GetObject((OpenMode)1);
			ObjectId val3 = ((SymbolTable)val)[P_2];
			BlockTableRecord val4 = (BlockTableRecord)((ObjectId)(ref val3)).GetObject((OpenMode)0);
			BlockReference val5 = new BlockReference(P_3, ((SymbolTable)val)[P_2]);
			val5.ScaleFactors = P_4;
			((Entity)val5).Layer = P_1;
			val5.Rotation = P_5;
			val2.AppendEntity((Entity)(object)val5);
			if (val4.HasAttributeDefinitions)
			{
				BlockTableRecordEnumerator enumerator = val4.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						DBObject obj = ((ObjectId)(ref current)).GetObject((OpenMode)0);
						AttributeDefinition val6 = (AttributeDefinition)(object)((obj is AttributeDefinition) ? obj : null);
						if ((DisposableWrapper)(object)val6 != (DisposableWrapper)null)
						{
							AttributeReference val7 = new AttributeReference();
							val7.SetAttributeFromBlock(val6, val5.BlockTransform);
							Point3d position = ((DBText)val6).Position;
							((DBText)val7).Position = ((Point3d)(ref position)).TransformBy(val5.BlockTransform);
							((DBText)val7).Rotation = ((DBText)val6).Rotation;
							((DBText)val7).AdjustAlignment(database);
							if (P_6.ContainsKey(val6.Tag.ToUpper()))
							{
								((DBText)val7).TextString = P_6[val6.Tag.ToUpper()].ToString();
							}
							val5.AttributeCollection.AppendAttribute(val7);
							database.TransactionManager.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
			}
			database.TransactionManager.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
			return ((DBObject)val5).ObjectId;
		}

		public static void _0088_0097(this ObjectId P_0, Dictionary<string, string> P_1)
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			if (!true /* original-file-bool-offset:56 */)
			{
				return;
			}
			DBObject obj = ((ObjectId)(ref P_0)).GetObject((OpenMode)0);
			BlockReference val = (BlockReference)(object)((obj is BlockReference) ? obj : null);
			if (!((DisposableWrapper)(object)val != (DisposableWrapper)null))
			{
				return;
			}
			foreach (ObjectId item in val.AttributeCollection)
			{
				ObjectId val2 = item;
				DBObject obj2 = ((ObjectId)(ref val2)).GetObject((OpenMode)0);
				AttributeReference val3 = (AttributeReference)(object)((obj2 is AttributeReference) ? obj2 : null);
				if (P_1.ContainsKey(val3.Tag.ToUpper()))
				{
					((DBObject)val3).UpgradeOpen();
					((DBText)val3).TextString = P_1[val3.Tag.ToUpper()].ToString();
					((DBObject)val3).DowngradeOpen();
				}
			}
		}

		public static bool _0088_0098(ObjectId P_0, string P_1, ResultBuffer P_2)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			bool result = false;
			try
			{
				Database workingDatabase = HostApplicationServices.WorkingDatabase;
				try
				{
					Transaction val = workingDatabase.TransactionManager.StartTransaction();
					try
					{
						RegAppTable val2 = (RegAppTable)val.GetObject(workingDatabase.RegAppTableId, (OpenMode)1);
						int num = 8;
						if (_008F())
						{
							goto IL_003a;
						}
						goto IL_00e8;
						IL_003a:
						RegAppTableRecord val3 = default(RegAppTableRecord);
						switch (num)
						{
						case 8:
							_ = ObjectId.Null;
							num = 5;
							goto case 5;
						case 5:
							if (((SymbolTable)val2).Has(P_1))
							{
								_ = ((SymbolTable)val2)[P_1];
								break;
							}
							val3 = new RegAppTableRecord();
							num = 0;
							goto case 0;
						case 7:
							break;
						case 0:
							((SymbolTableRecord)val3).Name = P_1;
							_ = 0;
							if (_008F())
							{
								num = 6;
								goto case 3;
							}
							goto IL_00e8;
						case 3:
						case 6:
							((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
							goto IL_00e8;
						default:
							goto IL_00e8;
						case 2:
							val.Commit();
							goto case 9;
						case 9:
							result = true;
							goto end_IL_0014;
						}
						goto IL_008d;
						IL_008d:
						do
						{
							((DBObject)(Entity)val.GetObject(P_0, (OpenMode)1)).XData = P_2;
							num = 2;
						}
						while (!_008F());
						goto IL_003a;
						IL_00e8:
						val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
						goto IL_008d;
						end_IL_0014:;
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)workingDatabase)?.Dispose();
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		[CommandMethod("y9_AddObstBlockDef")]
		public static ObjectId _0088_0099()
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Expected O, but got Unknown
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected O, but got Unknown
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			_008F();
			Point3d val = default(Point3d);
			if (!_0090())
			{
				((Point3d)(ref val))._002Ector(-50.0, 0.0, 0.0);
			}
			Point3d val2 = new Point3d(50.0, 0.0, 0.0);
			Point3d val3 = default(Point3d);
			((Point3d)(ref val3))._002Ector(0.0, 150.0, 0.0);
			Circle val4 = new Circle(new Point3d(0.0, 0.0, 0.0), new Vector3d(0.0, 0.0, 1.0), 10.0);
			Line val5 = new Line(val, val3);
			Line val6 = new Line(val2, val3);
			Transaction val7 = workingDatabase.TransactionManager.StartTransaction();
			try
			{
				BlockTableRecord val8 = new BlockTableRecord
				{
					Name = "Obstacle" /* string-offset:532 */
				};
				val8.AppendEntity((Entity)(object)val5);
				val8.AppendEntity((Entity)(object)val6);
				val8.AppendEntity((Entity)(object)val4);
				ObjectId result = _0088_009A(val8, workingDatabase);
				val7.Commit();
				return result;
			}
			finally
			{
				((IDisposable)val7)?.Dispose();
			}
		}

		private static ObjectId _0088_009A(BlockTableRecord P_0, Database P_1)
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			_008F();
			if (!_0090())
			{
				ObjectId val = default(ObjectId);
			}
			Transaction val2 = P_1.TransactionManager.StartTransaction();
			try
			{
				ObjectId val = ((SymbolTable)(BlockTable)val2.GetObject(P_1.BlockTableId, (OpenMode)1)).Add((SymbolTableRecord)(object)P_0);
				_0090();
				if (_008F())
				{
					val2.AddNewlyCreatedDBObject((DBObject)(object)P_0, true);
				}
				val2.Commit();
				return val;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}

		public static void _0088_009B()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			ObjectId currentSpaceId = workingDatabase.CurrentSpaceId;
			Transaction val = workingDatabase.TransactionManager.StartTransaction();
			try
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("Altitude" /* string-offset:536 */, "100" /* string-offset:540 */);
				_ = 0;
				if (_008F())
				{
					dictionary.Add("Latitude" /* string-offset:544 */, "36" /* string-offset:548 */);
				}
				else if (_0090())
				{
					goto IL_0064;
				}
				goto IL_00a3;
				IL_0064:
				currentSpaceId._0088_0096("0" /* string-offset:560 */, "Obstacle" /* string-offset:532 */, Point3d.Origin, new Scale3d(1.0), 0.0, dictionary);
				if (_008F())
				{
					val.Commit();
					return;
				}
				goto IL_00a3;
				IL_00a3:
				dictionary.Add("Longitude" /* string-offset:552 */, "108" /* string-offset:556 */);
				goto IL_0064;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static void _0088_009C()
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Invalid comparison between Unknown and I4
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			Database workingDatabase = default(Database);
			PromptEntityResult entity = default(PromptEntityResult);
			if (false /* original-file-bool-offset:60 */)
			{
				_008F();
				if (!_0090())
				{
					return;
				}
			}
			else
			{
				workingDatabase = HostApplicationServices.WorkingDatabase;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptEntityOptions val = new PromptEntityOptions("请选择一个块" /* string-offset:564 */);
				val.SetRejectMessage("选择错误" /* string-offset:568 */);
				val.AddAllowedClass(typeof(BlockReference), true);
				entity = editor.GetEntity(val);
			}
			if ((int)((PromptResult)entity).Status != 5100)
			{
				return;
			}
			Transaction val2 = workingDatabase.TransactionManager.StartTransaction();
			try
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("Altitude" /* string-offset:536 */, "200" /* string-offset:572 */);
				dictionary.Add("Latitude" /* string-offset:544 */, "200" /* string-offset:572 */);
				_ = 0;
				if (_008F())
				{
					goto IL_00d4;
				}
				goto IL_00ef;
				IL_00d4:
				dictionary.Add("Longitude" /* string-offset:552 */, "200" /* string-offset:572 */);
				goto IL_00ef;
				IL_00ef:
				entity.ObjectId._0088_0097(dictionary);
				if (!_0090())
				{
					val2.Commit();
					return;
				}
				goto IL_00d4;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}

		public static void _0088_009D()
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Invalid comparison between Unknown and I4
			_ = 0;
			Editor editor = default(Editor);
			PromptSelectionResult selection = default(PromptSelectionResult);
			if (_008F())
			{
				editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptSelectionOptions val = new PromptSelectionOptions();
				selection = editor.GetSelection(val);
				if ((int)selection.Status != 5100)
				{
					return;
				}
			}
			int count = selection.Value.Count;
			do
			{
				editor.WriteMessage("选择了{0}个实体" /* string-offset:576 */, new object[1] { count });
			}
			while (!_008F());
		}

		public static ObjectId _0088_009E(this Database P_0, string P_1, short P_2 = 0, LineWeight P_3 = (LineWeight)(-1))
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			_0090();
			ObjectId result = default(ObjectId);
			if (_008F())
			{
				result = ObjectId.Null;
			}
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = P_0.TransactionManager.StartTransaction();
				try
				{
					LayerTable val3 = (LayerTable)val2.GetObject(P_0.LayerTableId, (OpenMode)1);
					if (!((SymbolTable)val3).Has(P_1))
					{
						LayerTableRecord val4 = new LayerTableRecord();
						((SymbolTableRecord)val4).Name = P_1;
						_ = 0;
						if (_008F())
						{
							if (_0090())
							{
							}
							val4.Color = Color.FromColorIndex((ColorMethod)195, P_2);
							val4.LineWeight = P_3;
							result = ((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
							val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
						}
					}
					else
					{
						result = ((SymbolTable)val3)[P_1];
					}
					val2.Commit();
					return result;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static ObjectId _0089_0086(string P_0, string P_1)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			ObjectId result = default(ObjectId);
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
					int num = 4;
					TextStyleTableRecord val4 = default(TextStyleTableRecord);
					if (!_0090())
					{
						while (true)
						{
							switch (num)
							{
							case 7:
								val4 = new TextStyleTableRecord();
								goto case 0;
							case 0:
								((SymbolTableRecord)val4).Name = P_0;
								_ = 1;
								if (!_0090())
								{
									num = 6;
									if (_008F())
									{
										continue;
									}
									goto IL_00f7;
								}
								num = 1;
								goto IL_0108;
							case 4:
								if (!((SymbolTable)val3).Has(P_0))
								{
									num = 7;
									goto case 7;
								}
								result = ((SymbolTable)val3)[P_0];
								num = 9;
								goto IL_011a;
							default:
								num = 2;
								goto IL_00f7;
							case 3:
							case 6:
								break;
							case 2:
								goto IL_00f7;
							case 1:
							case 5:
								goto IL_0108;
							case 8:
							case 9:
								goto IL_011a;
							}
							break;
						}
					}
					val4.FileName = P_1;
					goto IL_00f7;
					IL_00f7:
					((DBObject)val3).UpgradeOpen();
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					goto IL_0108;
					IL_0108:
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
					num = 8;
					goto IL_011a;
					IL_011a:
					val2.Commit();
					return result;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static ObjectId _0089_0087(string P_0, Point3d P_1, double P_2 = 1.0)
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Expected O, but got Unknown
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Expected O, but got Unknown
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			_0090();
			Document mdiActiveDocument = default(Document);
			if (_008F())
			{
				mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			}
			Database database = mdiActiveDocument.Database;
			ObjectId result = default(ObjectId);
			bool flag = false;
			DocumentLock val = default(DocumentLock);
			if (_008F())
			{
				val = mdiActiveDocument.LockDocument();
			}
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					if (((SymbolTable)(BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0)).Has(P_0))
					{
						flag = true;
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			if (!flag)
			{
				_0089_0088(P_0);
			}
			DocumentLock val3 = mdiActiveDocument.LockDocument();
			try
			{
				Transaction val4 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val5 = (BlockTable)val4.GetObject(database.BlockTableId, (OpenMode)0);
					if (!((SymbolTable)val5).Has(P_0))
					{
						Application.ShowAlertDialog("未找到指定图块，请通过辅助功能界面导入图块。" /* string-offset:580 */);
						return result;
					}
					new BlockTableRecord();
					BlockTableRecord val6 = (BlockTableRecord)val4.GetObject(((SymbolTable)val5)[P_0], (OpenMode)1);
					BlockReference val7 = new BlockReference(P_1, ((SymbolTable)val5)[P_0]);
					Matrix3d val8 = Matrix3d.Scaling(P_2, P_1);
					((Entity)val7).TransformBy(val8);
					result = ((BlockTableRecord)val4.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)1)).AppendEntity((Entity)(object)val7);
					val4.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
					BlockTableRecordEnumerator enumerator = val6.GetEnumerator();
					try
					{
						AttributeReference val10 = default(AttributeReference);
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							_008F();
							if (!_0090())
							{
								DBObject obj = val4.GetObject(current, (OpenMode)0);
								AttributeDefinition val9 = (AttributeDefinition)(object)((obj is AttributeDefinition) ? obj : null);
								if (val9 == null)
								{
									continue;
								}
								val10 = new AttributeReference();
								val10.SetAttributeFromBlock(val9, val7.BlockTransform);
								((DBText)val10).TextString = " " /* string-offset:584 */;
							}
							val7.AttributeCollection.AppendAttribute(val10);
							val4.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)val7).RecordGraphicsModified(true);
					val4.Commit();
					Application.UpdateScreen();
					return result;
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}

		public static void _0089_0088(string P_0)
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected O, but got Unknown
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Expected O, but got Unknown
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			_008F();
			if (_0090() || false /* original-file-bool-offset:64 */)
			{
				return;
			}
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			string[] files = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "WsSymbol*.dwg" /* string-offset:588 */);
			if (files.Length == 0)
			{
				return;
			}
			string text = files[0];
			if (!File.Exists(text))
			{
				return;
			}
			try
			{
				Database val = new Database(false, true);
				TransactionManager transactionManager = val.TransactionManager;
				val.ReadDwgFile(text, FileShare.Read, true, (string)null);
				ObjectIdCollection val2 = new ObjectIdCollection();
				DocumentLock val3 = mdiActiveDocument.LockDocument();
				try
				{
					Transaction val4 = transactionManager.StartTransaction();
					try
					{
						BlockTable val5 = (BlockTable)transactionManager.GetObject(val.BlockTableId, (OpenMode)0, false);
						_ = 0;
						if (_008F() && !((SymbolTable)val5).Has(P_0))
						{
							Application.ShowAlertDialog("图块 " /* string-offset:592 */ + P_0 + " 未找到，请检查图库是否正确。" /* string-offset:596 */);
						}
						else
						{
							val2.Add(((SymbolTable)val5)[P_0]);
						}
						((DisposableWrapper)val5).Dispose();
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
					IdMapping val6 = new IdMapping();
					Database workingDatabase = HostApplicationServices.WorkingDatabase;
					val.WblockCloneObjects(val2, workingDatabase.BlockTableId, val6, (DuplicateRecordCloning)2, false);
					((DisposableWrapper)val).Dispose();
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			catch (Exception ex)
			{
				Application.ShowAlertDialog("复制错误：" /* string-offset:600 */ + ex.Message);
			}
		}

		public static void _0089_0089(ObjectId P_0, string P_1, string P_2)
		{
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			if (false /* original-file-bool-offset:68 */ || ((ObjectId)(ref P_0)).IsNull)
			{
				return;
			}
			if (!((ObjectId)(ref P_0)).IsValid)
			{
				if (!_008F())
				{
				}
			}
			else if (P_1 == null)
			{
				_0090();
				if (!_008F())
				{
				}
			}
			else
			{
				if (P_2 == null)
				{
					return;
				}
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				DocumentLock val = mdiActiveDocument.LockDocument();
				try
				{
					Transaction val2 = database.TransactionManager.StartTransaction();
					try
					{
						DBObject obj = val2.GetObject(P_0, (OpenMode)0);
						foreach (ObjectId item in ((BlockReference)((obj is BlockReference) ? obj : null)).AttributeCollection)
						{
							DBObject obj2 = val2.GetObject(item, (OpenMode)1);
							AttributeReference val4 = (AttributeReference)(object)((obj2 is AttributeReference) ? obj2 : null);
							if ((DisposableWrapper)(object)val4 != (DisposableWrapper)null)
							{
								_008F();
								if (_0090() || val4.Tag.ToUpper() == P_1.ToUpper())
								{
									((DBText)val4).TextString = P_2;
								}
							}
						}
						val2.Commit();
						Application.UpdateScreen();
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
		}

		public static void _0089_008A(ObjectId P_0, string P_1, double P_2)
		{
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			_008F();
			if (!_0090())
			{
				if (!true /* original-file-bool-offset:72 */)
				{
					return;
				}
			}
			else if (!_008F())
			{
				return;
			}
			if (((ObjectId)(ref P_0)).IsNull || !((ObjectId)(ref P_0)).IsValid || P_1 == null)
			{
				return;
			}
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DBObject obj = val2.GetObject(P_0, (OpenMode)0);
					foreach (DynamicBlockReferenceProperty item in ((BlockReference)((obj is BlockReference) ? obj : null)).DynamicBlockReferencePropertyCollection)
					{
						DynamicBlockReferenceProperty val3 = item;
						_ = 0;
						if (!_008F() || val3.PropertyName == P_1)
						{
							val3.Value = P_2;
							break;
						}
					}
					val2.Commit();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static List<string> _0089_008B(ObjectId P_0)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			List<string> list = new List<string>();
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DBObject obj = val2.GetObject(P_0, (OpenMode)0);
					foreach (ObjectId item in ((BlockReference)((obj is BlockReference) ? obj : null)).AttributeCollection)
					{
						DBObject obj2 = val2.GetObject(item, (OpenMode)1);
						AttributeReference val4 = (AttributeReference)(object)((obj2 is AttributeReference) ? obj2 : null);
						if ((DisposableWrapper)(object)val4 != (DisposableWrapper)null && val4.Tag != null)
						{
							list.Add(val4.Tag);
						}
					}
					val2.Commit();
					return list;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static void _0089_008C(BlockReference P_0)
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			Transaction val = Application.DocumentManager.MdiActiveDocument.Database.TransactionManager.StartTransaction();
			try
			{
				foreach (DynamicBlockReferenceProperty item in P_0.DynamicBlockReferencePropertyCollection)
				{
					_ = item.PropertyName;
					_ = item.Value;
				}
				val.Commit();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static ObjectId _0089_008D(string P_0, string P_1)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			ObjectId result = ObjectId.Null;
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[P_0], (OpenMode)0);
					if (val4.HasAttributeDefinitions)
					{
						BlockTableRecordEnumerator enumerator = val4.GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								DBObject obj = ((ObjectId)(ref current)).GetObject((OpenMode)0);
								AttributeDefinition val5 = (AttributeDefinition)(object)((obj is AttributeDefinition) ? obj : null);
								if (_008F())
								{
									if (!((DisposableWrapper)(object)val5 != (DisposableWrapper)null))
									{
										continue;
									}
									_0090();
									if (_008F())
									{
										if (!(val5.Tag.ToUpper() == P_1.ToUpper()))
										{
											continue;
										}
									}
									else if (_0090())
									{
										break;
									}
								}
								result = current;
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
					}
					val2.Commit();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return result;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static bool _0089_008E()
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			ObjectId clayer = mdiActiveDocument.Database.Clayer;
			Transaction val = mdiActiveDocument.Database.TransactionManager.StartTransaction();
			try
			{
				bool isOff = ((LayerTableRecord)val.GetObject(clayer, (OpenMode)0)).IsOff;
				val.Commit();
				return isOff;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		static _008B()
		{
			LicenseManager.Validate(typeof(_008B));
		}

		internal static bool _008F()
		{
			return true;
		}

		internal static bool _0090()
		{
			return false;
		}
	}
}
namespace _008E
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _008D
	{
		public static _008E_0097 _0089_008F(_008F_008E P_0, _008F_008E P_1)
		{
			return new _008E_0097
			{
				X = P_0.X,
				Y = P_0.Y,
				Z = P_0.Z,
				_008A_009D_0088 = Math.Sqrt(Math.Pow(P_1.Y - P_0.Y, 2.0) + Math.Pow(P_1.X - P_0.X, 2.0)),
				_008A_009D_0089 = Math.Atan2(P_1.Y - P_0.Y, P_1.X - P_0.X),
				_008A_009D_008A = Math.Atan2(P_0.Y - P_1.Y, P_0.X - P_1.X)
			};
		}

		public static _008F_008E _0089_0090(_008E_0097 P_0, _008F_008E P_1)
		{
			_008E_0097 obj = _0089_008F(P_0, P_1);
			return new _008F_008E
			{
				ID = P_1.ID,
				Name = P_1.Name,
				X = obj._008A_009D_0088 * Math.Cos(obj._008A_009D_0089 - P_0._008A_009D_008A),
				Y = obj._008A_009D_0088 * Math.Sin(obj._008A_009D_0089 - P_0._008A_009D_008A),
				Z = P_1.Z - P_0.Z
			};
		}

		public static _008F_008E _0089_0091(_008E_0097 P_0, _008F_008E P_1)
		{
			double num = Math.Sqrt(P_1.X * P_1.X + P_1.Y * P_1.Y);
			double num2 = Math.Atan2(P_1.Y, P_1.X);
			return new _008F_008E
			{
				X = P_0.X + num * Math.Cos(P_0._008A_009D_008A + num2),
				Y = P_0.Y + num * Math.Sin(P_0._008A_009D_008A + num2)
			};
		}

		public static void _0089_0092(DBPoint P_0)
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			_ = 1;
			Editor editor = default(Editor);
			Point3d position = default(Point3d);
			if (!_0092())
			{
				if (!true /* original-file-bool-offset:76 */)
				{
					return;
				}
				editor = Application.DocumentManager.MdiActiveDocument.Editor;
				position = P_0.Position;
			}
			try
			{
				ViewTableRecord currentView = editor.GetCurrentView();
				Point3d target = ((AbstractViewTableRecord)currentView).Target;
				double viewTwist = ((AbstractViewTableRecord)currentView).ViewTwist;
				double num = ((Point3d)(ref position)).X - ((Point3d)(ref target)).X;
				double num2 = ((Point3d)(ref position)).Y - ((Point3d)(ref target)).Y;
				double num3 = Math.Cos(0.0 - viewTwist);
				double num4 = Math.Sin(0.0 - viewTwist);
				double num5 = num * num3 - num2 * num4;
				_0091();
				double num6 = default(double);
				if (!_0092())
				{
					num6 = num * num4 + num2 * num3;
				}
				((AbstractViewTableRecord)currentView).CenterPoint = new Point2d(num5, num6);
				editor.SetCurrentView(currentView);
			}
			catch (Exception ex)
			{
				editor.WriteMessage("\n居中视图失败: " /* string-offset:604 */ + ex.Message);
			}
			((Entity)P_0).Highlight();
			Application.UpdateScreen();
		}

		public static void _0089_0093(List<DBPoint> P_0)
		{
			foreach (DBPoint item in P_0)
			{
				((Entity)item).Unhighlight();
			}
			Application.UpdateScreen();
		}

		public static void _0089_0094(Dictionary<string, DBPoint> P_0)
		{
			foreach (KeyValuePair<string, DBPoint> item in P_0)
			{
				((Entity)item.Value).Unhighlight();
			}
			Application.UpdateScreen();
		}

		private static bool _0089_0095(List<_008F_008E> P_0, _008F_008E P_1)
		{
			if (false /* original-file-bool-offset:80 */)
			{
				goto IL_00a2;
			}
			if (P_0.Count <= 0)
			{
				return false;
			}
			int num = 0;
			_008F_008E obj = P_0[0];
			int count = P_0.Count;
			int num2 = 1;
			goto IL_00fe;
			IL_00f7:
			_008F_008E obj2 = default(_008F_008E);
			obj = obj2;
			num2++;
			goto IL_00fe;
			IL_00a2:
			if (obj.X == obj2.X)
			{
				num++;
			}
			else
			{
				double num3 = (P_1.Y - obj.Y) * (obj2.X - obj.X) / (obj2.Y - obj.Y) + obj.X;
				if (P_1.X <= num3)
				{
					num++;
				}
			}
			goto IL_00f7;
			IL_00fe:
			if (num2 <= count)
			{
				obj2 = P_0[num2 % count];
				if (obj.Y != obj2.Y && P_1.Y > Math.Min(obj.Y, obj2.Y) && P_1.Y <= Math.Max(obj.Y, obj2.Y) && P_1.X <= Math.Max(obj.X, obj2.X))
				{
					goto IL_00a2;
				}
				goto IL_00f7;
			}
			return num % 2 != 0;
		}

		static _008D()
		{
			LicenseManager.Validate(typeof(_008D));
		}

		internal static bool _0091()
		{
			return true;
		}

		internal static bool _0092()
		{
			return false;
		}
	}
}
namespace _0090
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _008F
	{
		public static List<_008F_008E> _0089_0096(List<_008F_008E> P_0)
		{
			if (P_0.Count < 3)
			{
				return P_0;
			}
			List<_008F_008E> list = new List<_008F_008E>();
			_008F_008E obj = P_0[0];
			_008F_008E obj2 = P_0[0];
			foreach (_008F_008E item in P_0)
			{
				if (item.X < obj.X)
				{
					obj = item;
				}
				if (item.X > obj2.X)
				{
					obj2 = item;
				}
			}
			list.Add(obj);
			list.Add(obj2);
			List<_008F_008E> list2 = new List<_008F_008E>();
			List<_008F_008E> list3 = new List<_008F_008E>();
			for (int i = 0; i < P_0.Count; i++)
			{
				_008F_008E obj3 = P_0[i];
				if (_0089_0098(obj, obj2, obj3))
				{
					list2.Add(obj3);
				}
				else if (_0089_0098(obj2, obj, obj3))
				{
					list3.Add(obj3);
				}
			}
			_0089_0097(list, list2, obj, obj2);
			_0089_0097(list, list3, obj2, obj);
			return list;
		}

		private static void _0089_0097(List<_008F_008E> P_0, List<_008F_008E> P_1, _008F_008E P_2, _008F_008E P_3)
		{
			if (!true /* original-file-bool-offset:84 */ || P_1.Count == 0)
			{
				return;
			}
			if (P_1.Count == 1)
			{
				P_0.Add(P_1[0]);
				return;
			}
			int index = P_0.IndexOf(P_3) + 1;
			double num = 0.0;
			_008F_008E obj = null;
			for (int i = 0; i < P_1.Count; i++)
			{
				_008F_008E obj2 = P_1[i];
				double num2 = _0089_0099(P_2, P_3, obj2);
				if (num2 > num)
				{
					num = num2;
					obj = obj2;
				}
			}
			P_0.Insert(index, obj);
			List<_008F_008E> list = new List<_008F_008E>();
			List<_008F_008E> list2 = new List<_008F_008E>();
			for (int j = 0; j < P_1.Count; j++)
			{
				_008F_008E obj3 = P_1[j];
				if (_0089_0098(P_2, obj, obj3))
				{
					list.Add(obj3);
				}
				else if (_0089_0098(obj, P_3, obj3))
				{
					list2.Add(obj3);
				}
			}
			_0089_0097(P_0, list, P_2, obj);
			_0089_0097(P_0, list2, obj, P_3);
		}

		private static bool _0089_0098(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			if ((P_2.X - P_0.X) * (P_1.Y - P_0.Y) - (P_2.Y - P_0.Y) * (P_1.X - P_0.X) > 0.0)
			{
				return true;
			}
			return false;
		}

		private static double _0089_0099(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			double num = P_1.Y - P_0.Y;
			_0094();
			double num2 = default(double);
			if (_0093())
			{
				num2 = P_0.X - P_1.X;
			}
			double num3 = P_1.Y * P_0.X - P_1.X * P_0.Y;
			return Math.Abs(num * P_2.X + num2 * P_2.Y + num3) / Math.Sqrt(num * num + num2 * num2);
		}

		static _008F()
		{
			LicenseManager.Validate(typeof(_008F));
		}

		internal static bool _0093()
		{
			return true;
		}

		internal static bool _0094()
		{
			return false;
		}
	}
}
namespace _0092
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0091
	{
		private static int _0089_009A(_008F_008E P_0, _008F_008E P_1, _008F_008E P_2)
		{
			double num = (P_1.Y - P_0.Y) * (P_2.X - P_1.X) - (P_1.X - P_0.X) * (P_2.Y - P_1.Y);
			_ = 0;
			if (_0095() && num != 0.0)
			{
				if (!(num > 0.0))
				{
					return 2;
				}
				return 1;
			}
			return 0;
		}

		public static List<_008F_008E> _0089_009B(List<_008F_008E> P_0)
		{
			int count = default(int);
			List<_008F_008E> list = default(List<_008F_008E>);
			int num = default(int);
			int num2 = default(int);
			if (!false /* original-file-bool-offset:88 */)
			{
				count = P_0.Count;
				if (count < 3)
				{
					return P_0;
				}
				list = new List<_008F_008E>();
				num = 0;
				for (int i = 1; i < count; i++)
				{
					if (P_0[i].X < P_0[num].X)
					{
						num = i;
					}
				}
				num2 = num;
			}
			do
			{
				list.Add(P_0[num2]);
				int num3 = (num2 + 1) % count;
				for (int j = 0; j < count; j++)
				{
					if (_0089_009A(P_0[num2], P_0[j], P_0[num3]) == 2)
					{
						num3 = j;
					}
				}
				num2 = num3;
			}
			while (num2 != num);
			return list;
		}

		static _0091()
		{
			LicenseManager.Validate(typeof(_0091));
		}

		internal static bool _0095()
		{
			return true;
		}

		internal static bool _0096()
		{
			return false;
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
				add
				{
				}
				remove
				{
				}
			}

			public bool CanExecute(object P_0)
			{
				return true;
			}

			public void Execute(object P_0)
			{
				_ = 1;
				string text = default(string);
				if (!_008A_0092())
				{
					text = P_0 as string;
				}
				if (!string.IsNullOrEmpty(text))
				{
					Application.DocumentManager.MdiActiveDocument.SendStringToExecute(text + " " /* string-offset:584 */, true, false, false);
				}
			}

			static _008F_009C()
			{
				LicenseManager.Validate(typeof(_008F_009C));
			}

			internal static bool _008A_0091()
			{
				return true;
			}

			internal static bool _008A_0092()
			{
				return false;
			}
		}

		public void _0089_009C()
		{
			_ = 1;
			if (!_0098() && !true /* original-file-bool-offset:92 */)
			{
				return;
			}
			string text = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "btn.xml" /* string-offset:608 */);
			MessageBox.Show(text);
			foreach (XElement item in XDocument.Load(text).Descendants("Button" /* string-offset:612 */))
			{
				_ = item.Element("Name" /* string-offset:616 */).Value;
				_ = item.Element("Icon" /* string-offset:620 */).Value;
				_ = item.Element("Tooltip" /* string-offset:624 */).Value;
				_ = item.Element("Command" /* string-offset:628 */).Value;
			}
		}

		[CommandMethod("Command1")]
		public void _0089_009D()
		{
			Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nCommand1 executed." /* string-offset:632 */);
		}

		[CommandMethod("Command2")]
		public void _0089_009E()
		{
			Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage("\nCommand2 executed." /* string-offset:636 */);
		}

		static _0093()
		{
			LicenseManager.Validate(typeof(_0093));
		}

		internal static bool _0097()
		{
			return true;
		}

		internal static bool _0098()
		{
			return false;
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

			static _008F_009D()
			{
				LicenseManager.Validate(typeof(_008F_009D));
				_003C_003E9 = new _008F_009D();
			}

			internal string _008B_008D_0098(XElement c)
			{
				return c.Attribute("Value" /* string-offset:7524 */)?.Value;
			}

			internal XElement _008B_008D_0099(DataGridViewCell cell)
			{
				return new XElement("Column" /* string-offset:652 */, new XAttribute("Value" /* string-offset:7524 */, cell.Value?.ToString()));
			}

			internal static bool _008A_0093()
			{
				return true;
			}

			internal static bool _008A_0094()
			{
				return false;
			}
		}

		[CompilerGenerated]
		[LicenseProvider(typeof(_0091_008B))]
		private sealed class _008F_009E
		{
			public DataGridView dataGridView;

			public ContextMenuStrip contextMenu;

			public Button button;

			internal void _008B_008D_009A(object sender, EventArgs e)
			{
				contextMenu.Show(button, 0, button.Height);
			}

			static _008F_009E()
			{
				LicenseManager.Validate(typeof(_008F_009E));
			}

			internal static bool _008A_0095()
			{
				return true;
			}

			internal static bool _008A_0096()
			{
				return false;
			}
		}

		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0086
		{
			public DataGridViewColumn column;

			public ToolStripMenuItem menuItem;

			public _008F_009E CS_0024_003C_003E8__locals1;

			internal void _008B_008D_009B(object sender, EventArgs e)
			{
				_ = 0;
				DataGridViewColumn dataGridViewColumn = default(DataGridViewColumn);
				if (_008A_0097())
				{
					dataGridViewColumn = CS_0024_003C_003E8__locals1.dataGridView.Columns[column.Name];
				}
				if (dataGridViewColumn != null)
				{
					dataGridViewColumn.Visible = !dataGridViewColumn.Visible;
					menuItem.Checked = dataGridViewColumn.Visible;
				}
			}

			static _0090_0086()
			{
				LicenseManager.Validate(typeof(_0090_0086));
			}

			internal static bool _008A_0097()
			{
				return true;
			}

			internal static bool _008A_0098()
			{
				return false;
			}
		}

		[LicenseProvider(typeof(_0091_008B))]
		[CompilerGenerated]
		private sealed class _0090_0087
		{
			public string columnName;

			internal bool _008B_008D_009C(DataGridViewColumn c)
			{
				return c.HeaderText == columnName;
			}

			static _0090_0087()
			{
				LicenseManager.Validate(typeof(_0090_0087));
			}

			internal static bool _008A_0099()
			{
				return true;
			}

			internal static bool _008A_009A()
			{
				return false;
			}
		}

		private DataTable _008A_008E;

		private int _008A_008F;

		public static string _008A_0090;

		public _0095()
		{
			_ = 0;
			if (_0099())
			{
				_008A_008F = 1;
				base._002Ector();
			}
			_008A_008E = new DataTable();
			_008A_008E.Columns.Add("ID" /* string-offset:640 */, typeof(int));
		}

		public void _008A_0086(List<List<object>> P_0, List<string> P_1)
		{
			if (false /* original-file-bool-offset:96 */)
			{
				return;
			}
			_008A_008E.Clear();
			foreach (string item in P_1)
			{
				_008A_008E.Columns.Add(item, typeof(string));
			}
			foreach (List<object> item2 in P_0)
			{
				DataRow dataRow = _008A_008E.NewRow();
				dataRow["ID" /* string-offset:640 */] = _008A_008F++;
				for (int i = 0; i < P_1.Count; i++)
				{
					dataRow[P_1[i]] = item2[i]?.ToString();
				}
				_008A_008E.Rows.Add(dataRow);
			}
		}

		public void _008A_0087(List<string> P_0)
		{
			_008A_008E.Clear();
			foreach (string item in P_0)
			{
				_008A_008E.Columns.Add(item, typeof(string));
			}
		}

		public void _008A_0088(DataGridView P_0)
		{
			P_0.DataSource = _008A_008E;
		}

		public static void _008A_0089(DataGridView P_0, Button P_1, ContextMenuStrip P_2)
		{
			if (false /* original-file-bool-offset:100 */)
			{
				return;
			}
			_0099();
			DataGridView dataGridView = default(DataGridView);
			ContextMenuStrip contextMenu = default(ContextMenuStrip);
			Button button = default(Button);
			if (!_009A())
			{
				dataGridView = P_0;
				contextMenu = P_2;
				button = P_1;
				if (_009A())
				{
				}
				contextMenu.Items.Clear();
			}
			IEnumerator enumerator = dataGridView.Columns.GetEnumerator();
			try
			{
				DataGridViewColumn column = default(DataGridViewColumn);
				ToolStripMenuItem menuItem = default(ToolStripMenuItem);
				for (; enumerator.MoveNext(); menuItem.Click += delegate
				{
					_ = 0;
					DataGridViewColumn dataGridViewColumn = default(DataGridViewColumn);
					if (_0090_0086._008A_0097())
					{
						dataGridViewColumn = dataGridView.Columns[column.Name];
					}
					if (dataGridViewColumn != null)
					{
						dataGridViewColumn.Visible = !dataGridViewColumn.Visible;
						menuItem.Checked = dataGridViewColumn.Visible;
					}
				}, contextMenu.Items.Add(menuItem))
				{
					_009A();
					if (_0099())
					{
						if (_009A())
						{
							continue;
						}
						column = (DataGridViewColumn)enumerator.Current;
					}
					menuItem = new ToolStripMenuItem(column.HeaderText)
					{
						Checked = column.Visible
					};
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			button.Click += delegate
			{
				contextMenu.Show(button, 0, button.Height);
			};
		}

		public static void _008A_008A(string P_0, DataGridView P_1, ContextMenuStrip P_2)
		{
			if (!true /* original-file-bool-offset:104 */ || !File.Exists(_008A_0090))
			{
				return;
			}
			object obj;
			if (_0099())
			{
				XElement xElement = XDocument.Load(_008A_0090).Element("Document" /* string-offset:644 */);
				if (xElement != null)
				{
					XElement xElement2 = xElement.Element("DgvSettings" /* string-offset:648 */);
					if (xElement2 == null)
					{
						if (!_0099())
						{
							goto IL_00ab;
						}
						obj = null;
					}
					else
					{
						obj = xElement2.Element(P_0);
					}
					goto IL_0087;
				}
				_009A();
				if (!_0099())
				{
					goto IL_00ab;
				}
			}
			obj = null;
			goto IL_0087;
			IL_0087:
			XElement xElement3 = (XElement)obj;
			XElement xElement4 = default(XElement);
			if (xElement3 != null)
			{
				xElement4 = xElement3.Element(P_1.Name);
				if (xElement4 == null)
				{
					return;
				}
				goto IL_00ab;
			}
			return;
			IL_00ab:
			bool visible = default(bool);
			foreach (XElement item in xElement4.Elements("Column" /* string-offset:652 */))
			{
				string columnName = item.Attribute("Name" /* string-offset:616 */)?.Value;
				XAttribute xAttribute = item.Attribute("Visible" /* string-offset:656 */);
				object obj2;
				if (xAttribute == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = xAttribute.Value;
					if (obj2 != null)
					{
						goto IL_0138;
					}
				}
				_ = 1;
				if (!_009A())
				{
					if (!_009A())
					{
						obj2 = "true" /* string-offset:660 */;
						goto IL_0138;
					}
					goto IL_014c;
				}
				goto IL_013e;
				IL_014c:
				P_1.Columns[columnName].Visible = visible;
				continue;
				IL_0138:
				visible = bool.Parse((string)obj2);
				goto IL_013e;
				IL_013e:
				if (P_1.Columns[columnName] == null)
				{
					continue;
				}
				goto IL_014c;
			}
			DataGridViewColumn dataGridViewColumn = default(DataGridViewColumn);
			foreach (ToolStripMenuItem item2 in P_2.Items)
			{
				_ = 1;
				if (!_009A())
				{
					string columnName2 = item2.Text;
					dataGridViewColumn = P_1.Columns.Cast<DataGridViewColumn>().FirstOrDefault((DataGridViewColumn c) => c.HeaderText == columnName2);
					if (dataGridViewColumn == null)
					{
						continue;
					}
				}
				item2.Checked = dataGridViewColumn.Visible;
			}
		}

		public static void _008A_008B(string P_0, DataGridView P_1, ContextMenuStrip P_2)
		{
			if (false /* original-file-bool-offset:108 */)
			{
				return;
			}
			XDocument xDocument;
			if (File.Exists(_008A_0090))
			{
				xDocument = XDocument.Load(_008A_0090);
			}
			else
			{
				xDocument = new XDocument(new XElement("Document" /* string-offset:644 */, new XElement("DgvSettings" /* string-offset:648 */)));
				_0099();
				if (_009A())
				{
					goto IL_0212;
				}
			}
			XElement xElement = xDocument.Element("Document" /* string-offset:644 */)?.Element("DgvSettings" /* string-offset:648 */);
			if (xElement == null)
			{
				xElement = new XElement("DgvSettings" /* string-offset:648 */);
				xDocument.Element("Document" /* string-offset:644 */)?.Add(xElement);
			}
			goto IL_0212;
			IL_0212:
			while (true)
			{
				XElement xElement2 = xElement.Element(P_0);
				if (xElement2 != null)
				{
					xElement2.RemoveAll();
					goto IL_01ea;
				}
				xElement2 = new XElement(P_0);
				goto IL_01bc;
				IL_01ea:
				XElement xElement3 = xElement2.Element(P_1.Name);
				if (xElement3 != null)
				{
					xElement3.RemoveAll();
				}
				else
				{
					xElement3 = new XElement(P_1.Name);
					xElement2.Add(xElement3);
				}
				foreach (DataGridViewColumn column in P_1.Columns)
				{
					_009A();
					if (_0099())
					{
						xElement3.Add(new XElement("Column" /* string-offset:652 */, new XAttribute("Name" /* string-offset:616 */, column.Name), new XAttribute("Visible" /* string-offset:656 */, column.Visible)));
					}
				}
				xDocument.Save(_008A_0090);
				if (_0099())
				{
					break;
				}
				goto IL_01bc;
				IL_01bc:
				xElement.Add(xElement2);
				if (!_0099())
				{
					continue;
				}
				goto IL_01ea;
			}
		}

		public static void _008A_008C(string P_0, DataGridView P_1)
		{
			_009A();
			XElement xElement2 = default(XElement);
			if (_0099())
			{
				if (false /* original-file-bool-offset:112 */ || !File.Exists(_008A_0090))
				{
					return;
				}
				XElement xElement = XDocument.Load(_008A_0090).Element("Document" /* string-offset:644 */)?.Element("DgvData" /* string-offset:664 */)?.Element(P_0);
				if (xElement == null)
				{
					return;
				}
				xElement2 = xElement.Element(P_1.Name);
			}
			if (xElement2 == null)
			{
				return;
			}
			if (P_1.DataSource is DataTable dataTable)
			{
				dataTable.Clear();
			}
			else
			{
				P_1.DataSource = null;
			}
			foreach (XElement item in xElement2.Elements("Row" /* string-offset:668 */))
			{
				string[] array = (from c in item.Elements("Column" /* string-offset:652 */)
					select c.Attribute("Value" /* string-offset:7524 */)?.Value).ToArray();
				DataRow dataRow;
				int num;
				if (P_1.DataSource is DataTable dataTable2)
				{
					dataRow = dataTable2.NewRow();
					num = 0;
					_009A();
					if (_0099())
					{
						goto IL_014e;
					}
					goto IL_0164;
				}
				throw new InvalidOperationException("DataGridView is not bound to a DataTable." /* string-offset:672 */);
				IL_014e:
				if (num < array.Length)
				{
					dataRow[num] = array[num];
					goto IL_0164;
				}
				dataTable2.Rows.Add(dataRow);
				continue;
				IL_0164:
				num++;
				goto IL_014e;
			}
		}

		public static void _008A_008D(string P_0, DataGridView P_1)
		{
			_ = 1;
			XDocument xDocument = default(XDocument);
			object obj;
			if (!_009A())
			{
				if (false /* original-file-bool-offset:116 */)
				{
					return;
				}
				xDocument = ((!File.Exists(_008A_0090)) ? new XDocument(new XElement("Document" /* string-offset:644 */, new XElement("DgvData" /* string-offset:664 */))) : XDocument.Load(_008A_0090));
				XElement xElement = xDocument.Element("Document" /* string-offset:644 */);
				if (xElement != null)
				{
					obj = xElement.Element("DgvData" /* string-offset:664 */);
					goto IL_009e;
				}
			}
			obj = null;
			goto IL_009e;
			IL_009e:
			XElement xElement2 = (XElement)obj;
			if (xElement2 == null)
			{
				if (_0099())
				{
				}
				xElement2 = new XElement("DgvData" /* string-offset:664 */);
				xDocument.Element("Document" /* string-offset:644 */)?.Add(xElement2);
			}
			XElement xElement3 = xElement2.Element(P_0);
			if (xElement3 == null)
			{
				xElement3 = new XElement(P_0);
				xElement2.Add(xElement3);
			}
			else
			{
				xElement3.RemoveAll();
			}
			XElement xElement4 = xElement3.Element(P_1.Name);
			if (xElement4 == null)
			{
				xElement4 = new XElement(P_1.Name);
				xElement3.Add(xElement4);
			}
			else
			{
				xElement4.RemoveAll();
			}
			foreach (DataGridViewRow item in P_1.Rows.Cast<DataGridViewRow>())
			{
				_009A();
				if (!_0099() || !item.IsNewRow)
				{
					XElement content = new XElement("Row" /* string-offset:668 */, from DataGridViewCell cell in item.Cells
						select new XElement("Column" /* string-offset:652 */, new XAttribute("Value" /* string-offset:7524 */, cell.Value?.ToString())));
					xElement4.Add(content);
				}
			}
			xDocument.Save(_008A_0090);
		}

		static _0095()
		{
			LicenseManager.Validate(typeof(_0095));
			_008A_0090 = "config.xml" /* string-offset:676 */;
		}

		internal static bool _0099()
		{
			return true;
		}

		internal static bool _009A()
		{
			return false;
		}
	}
}
namespace _0098
{
	[LicenseProvider(typeof(_0091_008B))]
	public class _0097
	{
		private static readonly _0087_0094 _008A_009B;

		public static void _008A_0091(Form P_0, string P_1, string P_2)
		{
			if (false /* original-file-bool-offset:120 */)
			{
				_ = 1;
				if (!_009C())
				{
					return;
				}
				goto IL_00d0;
			}
			string text = Path.Combine(Path.GetDirectoryName(P_0.GetType().Assembly.Location), P_1);
			if (!File.Exists(text))
			{
				do
				{
					_0087_008A._008C_0097(text, "Document" /* string-offset:644 */, "1.0" /* string-offset:680 */, "UTF-8" /* string-offset:684 */, "no" /* string-offset:688 */);
				}
				while (!_009B());
				_0087_008A._008C_0099(text, "/Document" /* string-offset:692 */, P_2, "", "", "");
			}
			else if (_0087_008A._008C_0098(text, "/Document/" /* string-offset:696 */ + P_2) == null)
			{
				goto IL_00d0;
			}
			goto IL_00f1;
			IL_00f1:
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Dictionary<string, string>.Enumerator enumerator = default(Dictionary<string, string>.Enumerator);
			if (!_009C())
			{
				_008A_0092(ref dictionary, P_0.Controls, "");
				if (_009C())
				{
					goto IL_00d0;
				}
				enumerator = dictionary.GetEnumerator();
			}
			try
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> current = enumerator.Current;
					_ = 0;
					if (_009B())
					{
						_0087_008A._008C_009A(text, "/Document/" /* string-offset:696 */ + P_2, current.Key, current.Value);
					}
					else if (!_009B())
					{
					}
				}
				return;
			}
			finally
			{
				((IDisposable)enumerator/*cast due to .constrained prefix*/).Dispose();
			}
			IL_00d0:
			_0087_008A._008C_0099(text, "/Document" /* string-offset:692 */, P_2, "", "", "");
			goto IL_00f1;
		}

		private static void _008A_0092(ref Dictionary<string, string> P_0, Control.ControlCollection P_1, string P_2)
		{
			_009C();
			if (_009B() && !_009C() && !true /* original-file-bool-offset:124 */)
			{
				return;
			}
			foreach (Control item in P_1)
			{
				string text = (string.IsNullOrEmpty(P_2) ? item.Name : (P_2 + "." /* string-offset:700 */ + item.Name));
				if (_008A_009B._008D_0091(item, out var obj))
				{
					P_0.Add(text, obj.GetValue(item));
				}
				else if (item is GroupBox)
				{
					_008A_0092(ref P_0, item.Controls, text);
				}
				else if (item is TabPage)
				{
					_008A_0092(ref P_0, item.Controls, text);
				}
				else if (item is TabControl)
				{
					foreach (TabPage tabPage in ((TabControl)item).TabPages)
					{
						_ = 0;
						if (_009B())
						{
							_008A_0092(ref P_0, tabPage.Controls, text);
						}
					}
				}
				else
				{
					_008A_0092(ref P_0, item.Controls, text);
				}
			}
		}

		public static void _008A_0093(Form P_0, string P_1, string P_2)
		{
			if (false /* original-file-bool-offset:128 */)
			{
				return;
			}
			string text = Path.Combine(Path.GetDirectoryName(P_0.GetType().Assembly.Location), P_1);
			if (!File.Exists(text))
			{
				return;
			}
			XElement xElement = XDocument.Load(text).Element("Document" /* string-offset:644 */);
			object obj;
			if (xElement == null)
			{
				_009B();
				if (_009C())
				{
					goto IL_007c;
				}
				obj = null;
			}
			else
			{
				obj = xElement.Element(P_2);
			}
			XElement xElement2 = (XElement)obj;
			if (xElement2 == null)
			{
				return;
			}
			Control.ControlCollection controls = P_0.Controls;
			goto IL_007c;
			IL_007c:
			string text2 = default(string);
			_0087_0096 obj2 = default(_0087_0096);
			Control control = default(Control);
			foreach (XElement item in xElement2.Elements())
			{
				_009C();
				if (_009B())
				{
					goto IL_00c3;
				}
				if (_009B())
				{
					goto IL_00d1;
				}
				goto IL_00e1;
				IL_00c3:
				text2 = item.Name.ToString();
				goto IL_00d1;
				IL_00e1:
				obj2.SetValue(control, item.Value);
				continue;
				IL_00d1:
				control = _008A_0094(controls, text2);
				if (control == null || !_008A_009B._008D_0091(control, out obj2))
				{
					continue;
				}
				if (!_009B())
				{
					goto IL_00c3;
				}
				goto IL_00e1;
			}
		}

		private static Control _008A_0094(Control.ControlCollection P_0, string P_1)
		{
			Control control;
			Control.ControlCollection controlCollection = default(Control.ControlCollection);
			string[] array2 = default(string[]);
			int num = default(int);
			if (!false /* original-file-bool-offset:132 */)
			{
				string[] array = P_1.Split('.');
				if (array.Length != 0)
				{
					control = null;
					controlCollection = P_0;
					_009B();
					if (!_009C())
					{
						array2 = array;
					}
					num = 0;
					goto IL_0047;
				}
				if (_009B())
				{
					return null;
				}
			}
			goto IL_0072;
			IL_0061:
			num++;
			goto IL_0047;
			IL_0072:
			string key = default(string);
			Control[] array3 = controlCollection.Find(key, searchAllChildren: true);
			if (array3.Length != 0)
			{
				control = array3[0];
				controlCollection = control.Controls;
				goto IL_0061;
			}
			return null;
			IL_0047:
			if (num < array2.Length)
			{
				key = array2[num];
				goto IL_0072;
			}
			if (_009C())
			{
				goto IL_0061;
			}
			return control;
		}

		public static void _008A_0095(TabControl P_0, string P_1)
		{
			if (false /* original-file-bool-offset:136 */)
			{
				return;
			}
			string text = P_1 + "\n" /* string-offset:328 */;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			_008A_0092(ref dictionary, P_0.Controls, "");
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				_ = 0;
				if (_009B())
				{
					text = text + item.Key + "," /* string-offset:704 */ + item.Value + "\n" /* string-offset:328 */;
				}
			}
			MessageBox.Show(text);
			if (string.IsNullOrEmpty(text))
			{
				goto IL_00bd;
			}
			goto IL_00f7;
			IL_00bd:
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			_009C();
			if (_009B())
			{
				saveFileDialog.Filter = "RNP APCH程序文件|*.txt" /* string-offset:708 */;
				saveFileDialog.Title = "保存RNP APCH程序文件" /* string-offset:712 */;
				if (_009C())
				{
					goto IL_00f7;
				}
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
			}
			using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
			{
				streamWriter.Write(text);
				return;
			}
			IL_00f7:
			text = text.Remove(text.Length - 1);
			goto IL_00bd;
		}

		public static void _008A_0096(TabControl P_0, string P_1)
		{
			if (false /* original-file-bool-offset:140 */)
			{
				return;
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "RNP APCH程序文件|*.txt" /* string-offset:708 */;
			openFileDialog.Title = "打开RNP APCH程序文件" /* string-offset:716 */;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string[] array = File.ReadAllText(openFileDialog.FileName).Split('\n');
			if (array[0] != P_1)
			{
				MessageBox.Show("数据内容不匹配，请重新选择。" /* string-offset:720 */);
				return;
			}
			for (int i = 1; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(',');
				_ = 1;
				if (!_009C() && array2.Length >= 2)
				{
					Control control = _008A_0094(P_0.Controls, array2[0]);
					if (control != null && _008A_009B._008D_0091(control, out var obj))
					{
						obj.SetValue(control, array2[1]);
					}
				}
			}
		}

		private static string _008A_0097(Dictionary<string, string> P_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in P_0)
			{
				stringBuilder.Append(item.Key + "," /* string-offset:704 */ + item.Value + "\n" /* string-offset:328 */);
			}
			string text = stringBuilder.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Remove(text.Length - 1);
			}
			return text;
		}

		public static void _008A_0098(Control.ControlCollection P_0, ref string P_1)
		{
			_008A_0099(P_0, ref P_1, "");
		}

		private static void _008A_0099(Control.ControlCollection P_0, ref string P_1, string P_2)
		{
			_ = 0;
			if (!_009B() || false /* original-file-bool-offset:144 */)
			{
				return;
			}
			foreach (Control item in P_0)
			{
				string text = (string.IsNullOrEmpty(P_2) ? item.Name : (P_2 + "." /* string-offset:700 */ + item.Name));
				if (_008A_009B._008D_0091(item, out var obj))
				{
					P_1 = P_1 + text + ":" /* string-offset:724 */ + obj.GetValue(item) + "\n" /* string-offset:328 */;
					_ = 0;
					if (!_009B())
					{
					}
				}
				else if (!(item is TabPage) && !(item is GroupBox))
				{
					_008A_0099(item.Controls, ref P_1, text);
				}
				else
				{
					_008A_0099(item.Controls, ref P_1, text);
				}
			}
		}

		public static void _008A_009A(Control.ControlCollection P_0, string P_1, string P_2)
		{
			_ = 0;
			string[] array = default(string[]);
			int num = default(int);
			if (_009B())
			{
				if (!true /* original-file-bool-offset:148 */)
				{
					return;
				}
				if (_009B())
				{
					array = P_1.Split(new string[3]
					{
						"\r\n" /* string-offset:728 */,
						"\r" /* string-offset:732 */,
						"\n" /* string-offset:328 */
					}, StringSplitOptions.RemoveEmptyEntries);
					if (P_2 != array[0])
					{
						MessageBox.Show("数据格式不匹配，请重新选择数据文件。" /* string-offset:736 */);
						return;
					}
					num = 1;
					goto IL_0084;
				}
				goto IL_00cc;
			}
			if (!_009C())
			{
				goto IL_00d4;
			}
			return;
			IL_00cc:
			_0087_0096 obj = default(_0087_0096);
			Control control = default(Control);
			string text = default(string);
			obj.SetValue(control, text);
			goto IL_00d4;
			IL_00d4:
			num++;
			goto IL_0084;
			IL_0084:
			if (num < array.Length)
			{
				string[] array2 = array[num].Split(':');
				string text2 = array2[0].Trim();
				text = array2[1].Trim();
				control = _008A_0094(P_0, text2);
				if (control != null && _008A_009B._008D_0091(control, out obj))
				{
					goto IL_00cc;
				}
				goto IL_00d4;
			}
		}

		static _0097()
		{
			LicenseManager.Validate(typeof(_0097));
			_008A_009B = _0087_0094._008D_0092();
		}

		internal static bool _009B()
		{
			return true;
		}

		internal static bool _009C()
		{
			return false;
		}
	}
}
namespace _009A
{
	[LicenseProvider(typeof(_0091_008B))]
	internal class _0099
	{
		[CommandMethod("CheckAndSetLayer")]
		public static string _008A_009C(string P_0 = null)
		{
			//IL_0252: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Invalid comparison between Unknown and I4
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Expected O, but got Unknown
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Editor editor = mdiActiveDocument.Editor;
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				if (string.IsNullOrWhiteSpace(P_0))
				{
					PromptStringOptions val2 = new PromptStringOptions("\n请输入目标图层名称：" /* string-offset:740 */)
					{
						AllowSpaces = true
					};
					PromptResult val3 = editor.GetString(val2);
					if ((int)val3.Status != 5100)
					{
						return "操作取消：未输入有效图层名称" /* string-offset:744 */;
					}
					P_0 = val3.StringResult.Trim();
					if (string.IsNullOrWhiteSpace(P_0))
					{
						return "错误：图层名称不能为空" /* string-offset:748 */;
					}
				}
				Transaction val4 = database.TransactionManager.StartTransaction();
				try
				{
					DBObject obj = val4.GetObject(database.LayerTableId, (OpenMode)0);
					LayerTable val5 = (LayerTable)(object)((obj is LayerTable) ? obj : null);
					_ = 0;
					LayerTableRecord val6 = default(LayerTableRecord);
					if (_009D())
					{
						if (((SymbolTable)val5).Has(P_0))
						{
							DBObject obj2 = val4.GetObject(((SymbolTable)val5)[P_0], (OpenMode)1);
							val6 = (LayerTableRecord)(object)((obj2 is LayerTableRecord) ? obj2 : null);
							if (val6.IsLocked)
							{
								val6.IsLocked = false;
								editor.WriteMessage("\n图层【" /* string-offset:752 */ + P_0 + "】已解锁" /* string-offset:756 */);
							}
							if (val6.IsFrozen)
							{
								val6.IsFrozen = false;
								editor.WriteMessage("\n图层【" /* string-offset:752 */ + P_0 + "】已解冻" /* string-offset:760 */);
							}
							if (val6.IsOff)
							{
								goto IL_01a8;
							}
							goto IL_01d0;
						}
						LayerTableRecord val7 = new LayerTableRecord
						{
							Name = P_0,
							IsLocked = false,
							IsFrozen = false,
							IsOff = false
						};
						((DBObject)val5).UpgradeOpen();
						((SymbolTable)val5).Add((SymbolTableRecord)(object)val7);
						val4.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
						editor.WriteMessage("\n图层【" /* string-offset:752 */ + P_0 + "】不存在，已创建新图层" /* string-offset:772 */);
					}
					else if (!_009E())
					{
						goto IL_01a8;
					}
					goto IL_020b;
					IL_01a8:
					val6.IsOff = false;
					editor.WriteMessage("\n图层【" /* string-offset:752 */ + P_0 + "】已显示" /* string-offset:764 */);
					goto IL_01d0;
					IL_01d0:
					if (!val6.IsLocked && !val6.IsFrozen && !val6.IsOff)
					{
						editor.WriteMessage("\n图层【" /* string-offset:752 */ + P_0 + "】状态正常（未锁定、未冻结、已显示）" /* string-offset:768 */);
					}
					goto IL_020b;
					IL_020b:
					val4.Commit();
					editor.Regen();
					return "操作完成：图层【" /* string-offset:776 */ + P_0 + "】处理成功" /* string-offset:780 */;
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				editor.WriteMessage("\n错误：" /* string-offset:784 */ + ((Exception)(object)ex2).Message);
				return "操作失败：" /* string-offset:788 */ + ((Exception)(object)ex2).Message;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		public static string _008A_009D(string P_0, Database P_1, bool P_2 = true)
		{
			//IL_01d3: Expected O, but got Unknown
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Invalid comparison between Unknown and I4
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			if (!_009E())
			{
				if ((DisposableWrapper)(object)P_1 == (DisposableWrapper)null)
				{
					_009E();
					if (_009D())
					{
						goto IL_01fd;
					}
				}
				else if (!string.IsNullOrWhiteSpace(P_0))
				{
					Document document = Application.DocumentManager.GetDocument(P_1);
					Editor editor = document.Editor;
					if ((DisposableWrapper)(object)document == (DisposableWrapper)null)
					{
						throw new InvalidOperationException("无法获取数据库对应的CAD文档" /* string-offset:808 */);
					}
					string result = string.Empty;
					DocumentLock val = document.LockDocument();
					Exception ex = default(Exception);
					try
					{
						Transaction val2 = P_1.TransactionManager.StartTransaction();
						try
						{
							DBObject obj = val2.GetObject(P_1.LayerTableId, (OpenMode)0);
							LayerTable val3 = (LayerTable)(object)((obj is LayerTable) ? obj : null);
							LayerTableRecord val4 = default(LayerTableRecord);
							if (((SymbolTable)val3).Has(P_0))
							{
								DBObject obj2 = val2.GetObject(((SymbolTable)val3)[P_0], (OpenMode)1);
								DBObject obj3 = ((obj2 is LayerTableRecord) ? obj2 : null);
								((LayerTableRecord)obj3).IsLocked = false;
								((LayerTableRecord)obj3).IsFrozen = false;
								((LayerTableRecord)obj3).IsOff = !P_2;
								_009E();
								if (_009D())
								{
									result = "图层【" /* string-offset:812 */ + P_0 + "】状态已重置（解锁、解冻、显示）" /* string-offset:816 */;
									if (!_009E())
									{
									}
									goto IL_016e;
								}
							}
							else
							{
								val4 = new LayerTableRecord
								{
									Name = P_0,
									IsLocked = false,
									IsFrozen = false,
									IsOff = !P_2
								};
								if (!((DBObject)val3).IsWriteEnabled)
								{
									((DBObject)val3).UpgradeOpen();
								}
								((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
							}
							val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
							result = "图层【" /* string-offset:812 */ + P_0 + "】已创建，状态：未锁定、未冻结、已显示" /* string-offset:820 */;
							goto IL_016e;
							IL_016e:
							val2.Commit();
						}
						finally
						{
							((IDisposable)val2)?.Dispose();
						}
						editor.Regen();
						return result;
					}
					catch (object obj4) when (((Func<bool>)delegate
					{
						// Could not convert BlockContainer to single expression
						object obj5 = ((obj4 is Exception) ? obj4 : null);
						System.Runtime.CompilerServices.Unsafe.SkipInit(out int result2);
						if (obj5 == null)
						{
							result2 = 0;
						}
						else
						{
							ex = (Exception)obj5;
							result2 = (((int)ex.ErrorStatus == 320) ? 1 : 0);
						}
						return (byte)result2 != 0;
					}).Invoke())
					{
						result = "锁定冲突：无法操作图层【" /* string-offset:824 */ + P_0 + "】，请关闭其他占用该图层的程序/命令" /* string-offset:828 */;
						throw new InvalidOperationException(result, (Exception)(object)ex);
					}
					catch (Exception ex2)
					{
						Exception ex3 = ex2;
						result = "操作失败：" /* string-offset:788 */ + ((Exception)(object)ex3).Message;
						throw new InvalidOperationException(result, (Exception)(object)ex3);
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
				throw new ArgumentException("图层名称不能为空" /* string-offset:800 */, "layerName" /* string-offset:804 */);
			}
			goto IL_01fd;
			IL_01fd:
			throw new ArgumentNullException("targetDb" /* string-offset:792 */, "CAD数据库不能为空" /* string-offset:796 */);
		}

		[CommandMethod("GetCurrentLayerName")]
		public static string _008A_009E()
		{
			//IL_00a5: Expected O, but got Unknown
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database val = ((mdiActiveDocument != null) ? mdiActiveDocument.Database : null);
				if (!((DisposableWrapper)(object)val == (DisposableWrapper)null))
				{
					ObjectId clayer = val.Clayer;
					Transaction val2 = val.TransactionManager.StartTransaction();
					try
					{
						DBObject obj = val2.GetObject(clayer, (OpenMode)0);
						DBObject obj2 = ((obj is LayerTableRecord) ? obj : null);
						object obj3;
						if (obj2 == null)
						{
							_ = 1;
							if (_009E())
							{
								goto IL_006e;
							}
							obj3 = null;
						}
						else
						{
							obj3 = ((SymbolTableRecord)obj2).Name;
							if (obj3 != null)
							{
								goto IL_0065;
							}
						}
						obj3 = string.Empty;
						goto IL_0065;
						IL_0065:
						string text = (string)obj3;
						val2.Commit();
						goto IL_006e;
						IL_006e:
						mdiActiveDocument.Editor.WriteMessage("\n当前图层名称：" /* string-offset:832 */ + text);
						return text;
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
				}
				return string.Empty;
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				Document mdiActiveDocument2 = Application.DocumentManager.MdiActiveDocument;
				if (mdiActiveDocument2 != null)
				{
					mdiActiveDocument2.Editor.WriteMessage("\n获取当前图层失败：" /* string-offset:836 */ + ((Exception)(object)ex2).Message);
				}
				return string.Empty;
			}
		}

		[CommandMethod("GetCurrentLayerInfo")]
		public static LayerTableRecord _008B_0086()
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			if ((DisposableWrapper)(object)mdiActiveDocument == (DisposableWrapper)null)
			{
				throw new Exception();
			}
			Database database = mdiActiveDocument.Database;
			Editor editor = mdiActiveDocument.Editor;
			DocumentLock val = mdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					DBObject obj = val2.GetObject(database.Clayer, (OpenMode)0);
					LayerTableRecord val3 = (LayerTableRecord)(object)((obj is LayerTableRecord) ? obj : null);
					while (true)
					{
						if (!((DisposableWrapper)(object)val3 == (DisposableWrapper)null))
						{
							editor.WriteMessage("\n==== 当前图层信息 ====" /* string-offset:840 */);
							editor.WriteMessage("\n名称：" /* string-offset:844 */ + ((SymbolTableRecord)val3).Name);
							editor.WriteMessage(string.Format("\n是否锁定：{0}" /* string-offset:848 */, val3.IsLocked));
							_ = 1;
							if (!_009E())
							{
								editor.WriteMessage(string.Format("\n是否冻结：{0}" /* string-offset:852 */, val3.IsFrozen));
							}
							else if (!_009D())
							{
								break;
							}
							editor.WriteMessage(string.Format("\n是否隐藏：{0}" /* string-offset:856 */, val3.IsOff));
							editor.WriteMessage(string.Format("\n颜色索引：{0}" /* string-offset:860 */, val3.Color.ColorIndex));
							if (_009D())
							{
								editor.WriteMessage(string.Format("\n线型：{0}" /* string-offset:864 */, val2.GetObject(val3.LinetypeObjectId, (OpenMode)0)));
								break;
							}
							continue;
						}
						throw new Exception();
					}
					val2.Commit();
					return val3;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}

		[CommandMethod("SetCurrentLayer")]
		public static void _008B_0087(string P_0 = null)
		{
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Invalid comparison between Unknown and I4
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			if (false /* original-file-bool-offset:152 */)
			{
				return;
			}
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			_ = 1;
			if (_009E() || (DisposableWrapper)(object)mdiActiveDocument == (DisposableWrapper)null)
			{
				return;
			}
			Database database = mdiActiveDocument.Database;
			Editor editor = mdiActiveDocument.Editor;
			if (string.IsNullOrWhiteSpace(P_0))
			{
				PromptStringOptions val = new PromptStringOptions("\n请输入要设置为当前的图层名称：" /* string-offset:868 */)
				{
					AllowSpaces = true
				};
				PromptResult val2 = editor.GetString(val);
				if ((int)val2.Status != 5100)
				{
					return;
				}
				P_0 = val2.StringResult.Trim();
			}
			DocumentLock val3 = mdiActiveDocument.LockDocument();
			try
			{
				Transaction val4 = database.TransactionManager.StartTransaction();
				try
				{
					DBObject obj = val4.GetObject(database.LayerTableId, (OpenMode)0);
					LayerTable val5 = (LayerTable)(object)((obj is LayerTable) ? obj : null);
					if (!_009D())
					{
						goto IL_00eb;
					}
					if (!((SymbolTable)val5).Has(P_0))
					{
						_ = 1;
						if (!_009E())
						{
							editor.WriteMessage("\n图层【" /* string-offset:752 */ + P_0 + "】不存在" /* string-offset:872 */);
						}
						goto IL_00eb;
					}
					database.Clayer = ((SymbolTable)val5)[P_0];
					val4.Commit();
					editor.WriteMessage("\n已将图层【" /* string-offset:876 */ + P_0 + "】设为当前图层" /* string-offset:880 */);
					goto end_IL_0099;
					IL_00eb:
					val4.Abort();
					return;
					end_IL_0099:;
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
				editor.Regen();
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}

		static _0099()
		{
			LicenseManager.Validate(typeof(_0099));
		}

		internal static bool _009D()
		{
			return true;
		}

		internal static bool _009E()
		{
			return false;
		}
	}
}
namespace _009C
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _009B
	{
		public static List<T> _008B_0088<T>(this Database P_0, OpenMode P_1, bool P_2) where T : Entity
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Invalid comparison between Unknown and I4
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			List<T> list = default(List<T>);
			ObjectId[] objectIds = default(ObjectId[]);
			if (!false /* original-file-bool-offset:156 */)
			{
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				list = new List<T>();
				string dxfName = RXObject.GetClass(typeof(T)).DxfName;
				SelectionFilter val = new SelectionFilter((TypedValue[])(object)new TypedValue[1]
				{
					new TypedValue(0, (object)dxfName)
				});
				PromptSelectionResult val2 = editor.SelectAll(val);
				if ((int)val2.Status != 5100)
				{
					goto IL_00ac;
				}
				objectIds = val2.Value.GetObjectIds();
			}
			for (int i = 0; i < objectIds.Length; i++)
			{
				ObjectId val3 = objectIds[i];
				T item = (T)(object)((ObjectId)(ref val3)).GetObject(P_1, P_2);
				list.Add(item);
			}
			goto IL_00ac;
			IL_00ac:
			return list;
		}

		public static List<T> _008B_0089<T>(this Database P_0) where T : Entity
		{
			return P_0._008B_0088<T>((OpenMode)0, _0020: false);
		}

		public static List<T> _008B_008A<T>(this Database P_0, OpenMode P_1, bool P_2) where T : Entity
		{
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Invalid comparison between Unknown and I4
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			List<T> list = default(List<T>);
			ObjectId[] objectIds = default(ObjectId[]);
			if (!false /* original-file-bool-offset:160 */)
			{
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				list = new List<T>();
				string dxfName = RXObject.GetClass(typeof(T)).DxfName;
				SelectionFilter val = new SelectionFilter((TypedValue[])(object)new TypedValue[2]
				{
					new TypedValue(0, (object)dxfName),
					new TypedValue(410, (object)"Model" /* string-offset:884 */)
				});
				PromptSelectionResult val2 = editor.SelectAll(val);
				if ((int)val2.Status != 5100)
				{
					goto IL_00ca;
				}
				objectIds = val2.Value.GetObjectIds();
			}
			for (int i = 0; i < objectIds.Length; i++)
			{
				ObjectId val3 = objectIds[i];
				T item = (T)(object)((ObjectId)(ref val3)).GetObject(P_1, P_2);
				list.Add(item);
			}
			goto IL_00ca;
			IL_00ca:
			return list;
		}

		public static List<T> _008B_008B<T>(this Database P_0, OpenMode P_1, bool P_2) where T : Entity
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Invalid comparison between Unknown and I4
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			List<T> list = default(List<T>);
			ObjectId[] objectIds = default(ObjectId[]);
			if (!false /* original-file-bool-offset:164 */)
			{
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				list = new List<T>();
				string dxfName = RXObject.GetClass(typeof(T)).DxfName;
				SelectionFilter val = new SelectionFilter((TypedValue[])(object)new TypedValue[1]
				{
					new TypedValue(0, (object)dxfName)
				});
				PromptSelectionResult selection = editor.GetSelection(val);
				if ((int)selection.Status != 5100)
				{
					goto IL_00ac;
				}
				objectIds = selection.Value.GetObjectIds();
			}
			for (int i = 0; i < objectIds.Length; i++)
			{
				ObjectId val2 = objectIds[i];
				T item = (T)(object)((ObjectId)(ref val2)).GetObject(P_1, P_2);
				list.Add(item);
			}
			goto IL_00ac;
			IL_00ac:
			return list;
		}

		static _009B()
		{
			LicenseManager.Validate(typeof(_009B));
		}

		internal static bool _009F()
		{
			return true;
		}

		internal static bool _0()
		{
			return false;
		}
	}
}
namespace _009E
{
	[LicenseProvider(typeof(_0091_008B))]
	public static class _009D
	{
		public static double _008B_008C(string P_0)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Invalid comparison between Unknown and I4
			PromptDoubleResult val = Application.DocumentManager.MdiActiveDocument.Editor.GetDouble(P_0);
			if ((int)((PromptResult)val).Status == 5100)
			{
				return val.Value;
			}
			return 0.0;
		}

		public static Point3d _008B_008D(string P_0)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Invalid comparison between Unknown and I4
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Invalid comparison between Unknown and I4
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Invalid comparison between Unknown and I4
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointOptions val = new PromptPointOptions("\n" /* string-offset:328 */ + P_0 + ", 按Esc键退出。" /* string-offset:888 */);
			((PromptCornerOptions)val).AllowArbitraryInput = true;
			while (true)
			{
				PromptPointResult point = editor.GetPoint(val);
				PromptStatus status = ((PromptResult)point).Status;
				while (true)
				{
					if ((int)status != -5002)
					{
						_ = 0;
						if (!_1())
						{
							if (_2())
							{
								continue;
							}
						}
						else if ((int)status == -5001)
						{
							editor.WriteMessage("\n输入错误，请重试。" /* string-offset:896 */);
							break;
						}
						if ((int)status != 5100)
						{
							break;
						}
						return point.Value;
					}
					editor.WriteMessage("\n已取消点选择。" /* string-offset:892 */);
					return Point3d.Origin;
				}
			}
		}

		public static double _008B_008E(double P_0, double P_1)
		{
			_ = 1;
			if ((!_2() && P_1 < P_0 && P_1 > P_0 - 180.0) || P_1 > P_0 + 180.0)
			{
				return _008B_0099(P_0 - P_1);
			}
			return _008B_0099(P_1 - P_0);
		}

		public static void _008B_008F(Point3d P_0, Point3d P_1, double P_2, double P_3, double P_4, bool P_5 = true)
		{
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Expected O, but got Unknown
			//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			if (!true /* original-file-bool-offset:168 */)
			{
				return;
			}
			Database workingDatabase = HostApplicationServices.WorkingDatabase;
			_2();
			Editor editor = default(Editor);
			DBText val = default(DBText);
			if (_1())
			{
				if (P_5)
				{
					if (_2())
					{
						return;
					}
					_008B._0088_008D((Entity)new Line(P_0, P_1), workingDatabase);
				}
				Point3d alignmentPoint = default(Point3d);
				((Point3d)(ref alignmentPoint))._002Ector((((Point3d)(ref P_0)).X + ((Point3d)(ref P_1)).X) / 2.0, (((Point3d)(ref P_0)).Y + ((Point3d)(ref P_1)).Y) / 2.0, (((Point3d)(ref P_0)).X + ((Point3d)(ref P_1)).Z) / 2.0);
				double num = _008B_0097(P_4);
				editor = Application.DocumentManager.MdiActiveDocument.Editor;
				editor.WriteMessage((num * 180.0 / Math.PI).ToString());
				_008B._0088_008D((Entity)new DBText
				{
					Height = 1600.0,
					TextString = Math.Round(P_2 / 1852.0) + " nm" /* string-offset:900 */,
					HorizontalMode = (TextHorizontalMode)1,
					VerticalMode = (TextVerticalMode)1,
					AlignmentPoint = alignmentPoint,
					Rotation = num
				}, workingDatabase);
				val = new DBText
				{
					Height = 2000.0,
					TextString = " " /* string-offset:584 */ + _008B_0098(P_3) + "° " /* string-offset:904 */,
					Rotation = num
				};
			}
			if (!(P_4 <= Math.PI / 2.0) && P_4 < 4.71238898038469)
			{
				editor.WriteMessage("more than 90, less than 270" /* string-offset:908 */);
				val.HorizontalMode = (TextHorizontalMode)2;
				val.VerticalMode = (TextVerticalMode)1;
				val.AlignmentPoint = P_0;
			}
			else
			{
				val.HorizontalMode = (TextHorizontalMode)0;
				val.VerticalMode = (TextVerticalMode)1;
				val.AlignmentPoint = P_0;
			}
			_008B._0088_008D((Entity)(object)val, workingDatabase);
		}

		internal static void _008B_0090()
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_09ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_09f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_12d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_12d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_12e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_12e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_12f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_1324: Unknown result type (might be due to invalid IL or missing references)
			//IL_1329: Unknown result type (might be due to invalid IL or missing references)
			//IL_1334: Unknown result type (might be due to invalid IL or missing references)
			//IL_1339: Unknown result type (might be due to invalid IL or missing references)
			//IL_1342: Unknown result type (might be due to invalid IL or missing references)
			//IL_1376: Unknown result type (might be due to invalid IL or missing references)
			//IL_137b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1386: Unknown result type (might be due to invalid IL or missing references)
			//IL_138b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1394: Unknown result type (might be due to invalid IL or missing references)
			//IL_13d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a76: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a7b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a86: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a8b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a94: Unknown result type (might be due to invalid IL or missing references)
			//IL_1abe: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ac3: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ace: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ad3: Unknown result type (might be due to invalid IL or missing references)
			//IL_1adc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d42: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d47: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d52: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d57: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d60: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b19: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b1e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b29: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b2e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b37: Unknown result type (might be due to invalid IL or missing references)
			//IL_18e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_18e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_18f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_18f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_1901: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c21: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c26: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c31: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c36: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c3f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c74: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c79: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c84: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c89: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c92: Unknown result type (might be due to invalid IL or missing references)
			//IL_1cbc: Unknown result type (might be due to invalid IL or missing references)
			//IL_1cc1: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ccc: Unknown result type (might be due to invalid IL or missing references)
			//IL_1cd1: Unknown result type (might be due to invalid IL or missing references)
			//IL_1cda: Unknown result type (might be due to invalid IL or missing references)
			//IL_183f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1844: Unknown result type (might be due to invalid IL or missing references)
			//IL_184f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1854: Unknown result type (might be due to invalid IL or missing references)
			//IL_185d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1892: Unknown result type (might be due to invalid IL or missing references)
			//IL_1897: Unknown result type (might be due to invalid IL or missing references)
			//IL_18a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_18a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_18b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_143c: Unknown result type (might be due to invalid IL or missing references)
			//IL_144c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1453: Expected O, but got Unknown
			//IL_1453: Unknown result type (might be due to invalid IL or missing references)
			//IL_145a: Expected O, but got Unknown
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1467: Unknown result type (might be due to invalid IL or missing references)
			//IL_146c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1477: Unknown result type (might be due to invalid IL or missing references)
			//IL_147c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1485: Unknown result type (might be due to invalid IL or missing references)
			//IL_14ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_14bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_14ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_14cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_14d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e39: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e3e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e49: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e4e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e57: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e90: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e9b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ea0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ea9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ed3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ed8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ee3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ee8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ef1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f26: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f2b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f44: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04be: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0500: Unknown result type (might be due to invalid IL or missing references)
			//IL_0505: Unknown result type (might be due to invalid IL or missing references)
			//IL_0510: Unknown result type (might be due to invalid IL or missing references)
			//IL_0515: Unknown result type (might be due to invalid IL or missing references)
			//IL_051e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0548: Unknown result type (might be due to invalid IL or missing references)
			//IL_054d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0558: Unknown result type (might be due to invalid IL or missing references)
			//IL_055d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0566: Unknown result type (might be due to invalid IL or missing references)
			//IL_150b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1510: Unknown result type (might be due to invalid IL or missing references)
			//IL_151b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1520: Unknown result type (might be due to invalid IL or missing references)
			//IL_1529: Unknown result type (might be due to invalid IL or missing references)
			//IL_155d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1562: Unknown result type (might be due to invalid IL or missing references)
			//IL_156d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1572: Unknown result type (might be due to invalid IL or missing references)
			//IL_157b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f8c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f91: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f9c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fa1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0faa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fde: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fe3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ff3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ffc: Unknown result type (might be due to invalid IL or missing references)
			//IL_1199: Unknown result type (might be due to invalid IL or missing references)
			//IL_119e: Unknown result type (might be due to invalid IL or missing references)
			//IL_11a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_11ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_11b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_11e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_11e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_11f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_11f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_11ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_1234: Unknown result type (might be due to invalid IL or missing references)
			//IL_1239: Unknown result type (might be due to invalid IL or missing references)
			//IL_1244: Unknown result type (might be due to invalid IL or missing references)
			//IL_1249: Unknown result type (might be due to invalid IL or missing references)
			//IL_1252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0488: Unknown result type (might be due to invalid IL or missing references)
			//IL_048f: Expected O, but got Unknown
			//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05be: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_102f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1034: Unknown result type (might be due to invalid IL or missing references)
			//IL_103f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1044: Unknown result type (might be due to invalid IL or missing references)
			//IL_104d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1082: Unknown result type (might be due to invalid IL or missing references)
			//IL_1087: Unknown result type (might be due to invalid IL or missing references)
			//IL_1092: Unknown result type (might be due to invalid IL or missing references)
			//IL_1097: Unknown result type (might be due to invalid IL or missing references)
			//IL_10a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_10ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_10da: Unknown result type (might be due to invalid IL or missing references)
			//IL_10df: Unknown result type (might be due to invalid IL or missing references)
			//IL_10e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e13: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e1a: Expected O, but got Unknown
			//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_071f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0724: Unknown result type (might be due to invalid IL or missing references)
			//IL_072f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0734: Unknown result type (might be due to invalid IL or missing references)
			//IL_073d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0454: Unknown result type (might be due to invalid IL or missing references)
			//IL_046a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0471: Expected O, but got Unknown
			//IL_0471: Unknown result type (might be due to invalid IL or missing references)
			//IL_0481: Unknown result type (might be due to invalid IL or missing references)
			//IL_0488: Expected O, but got Unknown
			//IL_061f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0624: Unknown result type (might be due to invalid IL or missing references)
			//IL_062f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0634: Unknown result type (might be due to invalid IL or missing references)
			//IL_063d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bf4: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bfb: Expected O, but got Unknown
			//IL_1d0e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1d13: Unknown result type (might be due to invalid IL or missing references)
			//IL_1d1e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1d23: Unknown result type (might be due to invalid IL or missing references)
			//IL_1d2c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1655: Unknown result type (might be due to invalid IL or missing references)
			//IL_165a: Unknown result type (might be due to invalid IL or missing references)
			//IL_1665: Unknown result type (might be due to invalid IL or missing references)
			//IL_166a: Unknown result type (might be due to invalid IL or missing references)
			//IL_1673: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_16b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_16b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_16c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_16c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_16ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_0296: Unknown result type (might be due to invalid IL or missing references)
			//IL_029b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_15ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_15bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_15ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_15cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_15d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_160d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1612: Unknown result type (might be due to invalid IL or missing references)
			//IL_161d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1622: Unknown result type (might be due to invalid IL or missing references)
			//IL_162b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1935: Unknown result type (might be due to invalid IL or missing references)
			//IL_193a: Unknown result type (might be due to invalid IL or missing references)
			//IL_1945: Unknown result type (might be due to invalid IL or missing references)
			//IL_194a: Unknown result type (might be due to invalid IL or missing references)
			//IL_1953: Unknown result type (might be due to invalid IL or missing references)
			//IL_197d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1982: Unknown result type (might be due to invalid IL or missing references)
			//IL_198d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1992: Unknown result type (might be due to invalid IL or missing references)
			//IL_199b: Unknown result type (might be due to invalid IL or missing references)
			//IL_19cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_19d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_19df: Unknown result type (might be due to invalid IL or missing references)
			//IL_19e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_19ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dfc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e0c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e13: Expected O, but got Unknown
			//IL_067b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0680: Unknown result type (might be due to invalid IL or missing references)
			//IL_068b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0690: Unknown result type (might be due to invalid IL or missing references)
			//IL_0699: Unknown result type (might be due to invalid IL or missing references)
			//IL_17ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_17bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_17ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_17cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_17d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d93: Unknown result type (might be due to invalid IL or missing references)
			//IL_175c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1761: Unknown result type (might be due to invalid IL or missing references)
			//IL_176c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1771: Unknown result type (might be due to invalid IL or missing references)
			//IL_177a: Unknown result type (might be due to invalid IL or missing references)
			//IL_1701: Unknown result type (might be due to invalid IL or missing references)
			//IL_1706: Unknown result type (might be due to invalid IL or missing references)
			//IL_1711: Unknown result type (might be due to invalid IL or missing references)
			//IL_1716: Unknown result type (might be due to invalid IL or missing references)
			//IL_171f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1416: Unknown result type (might be due to invalid IL or missing references)
			//IL_142c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1433: Expected O, but got Unknown
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b76: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a24: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a29: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a34: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a39: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a42: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dcf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dd6: Expected O, but got Unknown
			//IL_0dd6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0df3: Expected O, but got Unknown
			//IL_1b9b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bb0: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bb7: Expected O, but got Unknown
			//IL_1bb7: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bcd: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bd4: Expected O, but got Unknown
			//IL_1bd4: Unknown result type (might be due to invalid IL or missing references)
			//IL_1be4: Unknown result type (might be due to invalid IL or missing references)
			//IL_1beb: Expected O, but got Unknown
			//IL_13f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_1406: Unknown result type (might be due to invalid IL or missing references)
			//IL_140d: Expected O, but got Unknown
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0454: Expected O, but got Unknown
			//IL_113d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1142: Unknown result type (might be due to invalid IL or missing references)
			//IL_114d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1152: Unknown result type (might be due to invalid IL or missing references)
			//IL_115b: Unknown result type (might be due to invalid IL or missing references)
			int num = 38;
			Polyline val4 = default(Polyline);
			Arc val6 = default(Arc);
			Arc val7 = default(Arc);
			Polyline val8 = default(Polyline);
			Arc val9 = default(Arc);
			Arc val10 = default(Arc);
			Arc val11 = default(Arc);
			Database database = default(Database);
			double num8 = default(double);
			double num9 = default(double);
			double num10 = default(double);
			double num11 = default(double);
			double num12 = default(double);
			Point3d val12 = default(Point3d);
			int num13 = default(int);
			Arc val13 = default(Arc);
			Point3d val14 = default(Point3d);
			double num14 = default(double);
			double num15 = default(double);
			double num16 = default(double);
			Point3d val15 = default(Point3d);
			Polyline val18 = default(Polyline);
			Arc val20 = default(Arc);
			int num21 = default(int);
			Arc val19 = default(Arc);
			Arc val22 = default(Arc);
			double num22 = default(double);
			double num24 = default(double);
			Point3d val21 = default(Point3d);
			double num23 = default(double);
			Point3d val16 = default(Point3d);
			double num17 = default(double);
			double num18 = default(double);
			Point3d val17 = default(Point3d);
			double num19 = default(double);
			int num20 = default(int);
			double num25 = default(double);
			Point3d val23 = default(Point3d);
			double num26 = default(double);
			double num27 = default(double);
			Point3d val24 = default(Point3d);
			double num28 = default(double);
			int num29 = default(int);
			Polyline val25 = default(Polyline);
			Arc val26 = default(Arc);
			Arc val27 = default(Arc);
			Arc val28 = default(Arc);
			double num30 = default(double);
			while (!false /* original-file-bool-offset:172 */)
			{
				Point3d val = _008B_008D("\n请指定导航台" /* string-offset:912 */);
				Point3d val2 = _008B_008D("\n请指定IF点" /* string-offset:916 */);
				num = 83;
				while (true)
				{
					Point3d val3 = _008B_008D("\n请指定IAF点" /* string-offset:920 */);
					double num2 = Math.Atan2(((Point3d)(ref val3)).Y - ((Point3d)(ref val)).Y, ((Point3d)(ref val3)).X - ((Point3d)(ref val)).X);
					while (true)
					{
						double num3 = Math.Atan2(((Point3d)(ref val2)).Y - ((Point3d)(ref val)).Y, ((Point3d)(ref val2)).X - ((Point3d)(ref val)).X);
						while (true)
						{
							IL_09ad:
							double num4;
							if (num2 < 0.0)
							{
								num4 = num2 + Math.PI * 2.0;
								goto IL_098f;
							}
							num = 35;
							goto IL_0977;
							IL_16ab:
							Polyline obj = val4;
							Point3d val5 = ((Curve)val6).EndPoint;
							double x = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val6).EndPoint;
							obj.AddVertexAt(3, new Point2d(x, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							num = 74;
							goto IL_16fc;
							IL_16fc:
							Polyline obj2 = val4;
							val5 = ((Curve)val7).StartPoint;
							double x2 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val7).StartPoint;
							obj2.AddVertexAt(4, new Point2d(x2, ((Point3d)(ref val5)).Y), _008B_0094(val7.StartAngle, val7.EndAngle), 0.0, 0.0);
							num = 68;
							goto IL_1757;
							IL_098f:
							num2 = num4;
							double num5;
							if (num3 < 0.0)
							{
								num5 = num3 + Math.PI * 2.0;
								goto IL_0968;
							}
							num = 18;
							if (!_2())
							{
								goto IL_0966;
							}
							goto IL_12ce;
							IL_0f87:
							Polyline obj3 = val8;
							val5 = ((Curve)val9).StartPoint;
							double x3 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val9).StartPoint;
							obj3.AddVertexAt(0, new Point2d(x3, ((Point3d)(ref val5)).Y), _008B_0094(val9.StartAngle, val9.EndAngle), 0.0, 0.0);
							Polyline obj4 = val8;
							val5 = ((Curve)val9).EndPoint;
							double x4 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val9).EndPoint;
							obj4.AddVertexAt(1, new Point2d(x4, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							num = 24;
							goto IL_102a;
							IL_102a:
							Polyline obj5 = val8;
							val5 = ((Curve)val10).EndPoint;
							double x5 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val10).EndPoint;
							obj5.AddVertexAt(2, new Point2d(x5, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val10.StartAngle, val10.EndAngle), 0.0, 0.0);
							Polyline obj6 = val8;
							val5 = ((Curve)val10).StartPoint;
							double x6 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val10).StartPoint;
							obj6.AddVertexAt(3, new Point2d(x6, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							Polyline obj7 = val8;
							val5 = ((Curve)val11).EndPoint;
							double x7 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val11).EndPoint;
							obj7.AddVertexAt(4, new Point2d(x7, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val11.StartAngle, val11.EndAngle), 0.0, 0.0);
							num = 44;
							if (!_2())
							{
								goto IL_0d3d;
							}
							goto IL_1277;
							IL_0968:
							num3 = num5;
							double num6;
							double num7;
							if (num2 != num3)
							{
								database = Application.DocumentManager.MdiActiveDocument.Database;
								num6 = ((Point3d)(ref val2)).DistanceTo(val);
								num7 = 3704.0;
								num8 = num6 + num7;
								num9 = (2.0 * num6 * num7 + 13719616.0) / (2.0 * num6 + 7408.0);
								num10 = (2.0 * num6 * num7 + 41158848.0) / (2.0 * num6 + 7408.0);
								if (!(num2 >= num3))
								{
									goto IL_0767;
								}
								if (num2 - num3 > Math.PI)
								{
									num11 = Math.Asin(num10 / (num8 + num10));
									num = 3;
									if (!_2())
									{
										goto IL_07fc;
									}
									goto IL_182b;
								}
								num = 54;
								goto IL_0bd0;
							}
							num = 47;
							return;
							IL_1757:
							Polyline obj8 = val4;
							val5 = ((Curve)val7).EndPoint;
							double x8 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val7).EndPoint;
							obj8.AddVertexAt(5, new Point2d(x8, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							goto IL_13c2;
							IL_13c2:
							val4.Closed = false;
							_008B._0088_008D((Entity)(object)val4, database);
							num = 70;
							goto IL_13e2;
							IL_1194:
							Polyline obj9 = val8;
							val5 = ((Curve)val10).StartPoint;
							double x9 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val10).StartPoint;
							obj9.AddVertexAt(1, new Point2d(x9, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							Polyline obj10 = val8;
							val5 = ((Curve)val11).EndPoint;
							double x10 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val11).EndPoint;
							obj10.AddVertexAt(2, new Point2d(x10, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val11.StartAngle, val11.EndAngle), 0.0, 0.0);
							Polyline obj11 = val8;
							val5 = ((Curve)val11).StartPoint;
							double x11 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val11).StartPoint;
							obj11.AddVertexAt(3, new Point2d(x11, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							goto IL_1277;
							IL_1291:
							num12 = Math.Atan2(((Point3d)(ref val12)).Y - ((Point3d)(ref val)).Y, ((Point3d)(ref val12)).X - ((Point3d)(ref val)).X);
							num13 = -9260;
							goto IL_1815;
							IL_1815:
							if (num13 <= 9260)
							{
								val13 = new Arc(val14, num10 - (double)num13, num14, num2 - Math.PI / 2.0);
								num = 78;
								goto IL_1416;
							}
							num = 79;
							return;
							IL_0767:
							if (num3 - num2 > Math.PI)
							{
								num15 = Math.Asin(num10 / (num8 + num10));
								num = 32;
								if (_2())
								{
									continue;
								}
								goto IL_079b;
							}
							num16 = Math.Asin(num10 / (num8 + num10));
							((Point3d)(ref val14))._002Ector(((Point3d)(ref val)).X + (num8 + num10) * Math.Cos(num2 + num16), ((Point3d)(ref val)).Y + (num8 + num10) * Math.Sin(num2 + num16), 0.0);
							num14 = Math.Atan2(((Point3d)(ref val)).Y - ((Point3d)(ref val14)).Y, ((Point3d)(ref val)).X - ((Point3d)(ref val14)).X);
							num = 73;
							goto IL_0ccf;
							IL_13e2:
							num13 += 4630;
							goto IL_1815;
							IL_079b:
							((Point3d)(ref val15))._002Ector(((Point3d)(ref val)).X + (num8 + num10) * Math.Cos(num2 - num15), ((Point3d)(ref val)).Y + (num8 + num10) * Math.Sin(num2 - num15), 0.0);
							num = 76;
							if (_1())
							{
								goto IL_07fc;
							}
							goto IL_1a71;
							IL_07fc:
							while (true)
							{
								switch (num)
								{
								case 80:
								{
									Polyline obj25 = val18;
									val5 = ((Curve)val20).StartPoint;
									double x25 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val20).StartPoint;
									obj25.AddVertexAt(5, new Point2d(x25, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
									num = 2;
									goto case 2;
								}
								case 39:
									num21 += 4630;
									num = 69;
									if (!_2())
									{
										continue;
									}
									goto case 50;
								case 50:
								{
									Polyline obj12 = val18;
									val5 = ((Curve)val19).StartPoint;
									double x12 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val19).StartPoint;
									obj12.AddVertexAt(0, new Point2d(x12, ((Point3d)(ref val5)).Y), _008B_0094(val19.StartAngle, val19.EndAngle), 0.0, 0.0);
									num = 22;
									goto case 22;
								}
								case 22:
								{
									Polyline obj17 = val18;
									val5 = ((Curve)val19).EndPoint;
									double x17 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val19).EndPoint;
									obj17.AddVertexAt(1, new Point2d(x17, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
									num = 26;
									goto case 26;
								}
								case 26:
								{
									Polyline obj18 = val18;
									val5 = ((Curve)val22).EndPoint;
									double x18 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val22).EndPoint;
									obj18.AddVertexAt(2, new Point2d(x18, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val22.StartAngle, val22.EndAngle), 0.0, 0.0);
									goto case 55;
								}
								case 55:
								{
									Polyline obj19 = val18;
									val5 = ((Curve)val22).StartPoint;
									double x19 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val22).StartPoint;
									obj19.AddVertexAt(3, new Point2d(x19, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
									Polyline obj20 = val18;
									val5 = ((Curve)val20).EndPoint;
									double x20 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val20).EndPoint;
									obj20.AddVertexAt(4, new Point2d(x20, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val20.StartAngle, val20.EndAngle), 0.0, 0.0);
									num = 80;
									goto case 80;
								}
								case 2:
									val18.Closed = false;
									_008B._0088_008D((Entity)(object)val18, database);
									num = 39;
									goto case 39;
								case 76:
									num22 = Math.Atan2(((Point3d)(ref val)).Y - ((Point3d)(ref val15)).Y, ((Point3d)(ref val)).X - ((Point3d)(ref val15)).X);
									num24 = Math.Atan(num9 / num6);
									num = 56;
									goto case 56;
								case 56:
									((Point3d)(ref val21))._002Ector(((Point3d)(ref val)).X + (num6 + num7 - num9) * Math.Cos(num3 + num24), ((Point3d)(ref val)).Y + (num6 + num7 - num9) * Math.Sin(num3 + num24), 0.0);
									num23 = Math.Atan2(((Point3d)(ref val21)).Y - ((Point3d)(ref val)).Y, ((Point3d)(ref val21)).X - ((Point3d)(ref val)).X);
									num = 30;
									goto case 30;
								case 30:
									num21 = -9260;
									num = 67;
									if (!_2())
									{
										continue;
									}
									goto case 39;
								case 67:
								case 69:
									if (num21 <= 9260)
									{
										val19 = new Arc(val15, num10 - (double)num21, num2 + Math.PI / 2.0, num22);
										goto case 36;
									}
									return;
								case 36:
									val20 = new Arc(val21, num9 + (double)num21, num3 - Math.PI / 2.0, num23);
									val22 = new Arc(val, num8 + (double)num21, num3 + num24, num2 - num15);
									goto case 17;
								case 17:
									val18 = new Polyline();
									num = 52;
									goto case 52;
								case 52:
									if (num21 < 0)
									{
										num = 8;
										goto case 8;
									}
									if (num21 == 0)
									{
										num = 50;
										if (_1())
										{
											goto case 50;
										}
										goto IL_0da2;
									}
									if (num21 <= 0)
									{
										goto case 2;
									}
									goto case 41;
								case 8:
								{
									Polyline obj13 = val18;
									val5 = ((Curve)val19).StartPoint;
									double x13 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val19).StartPoint;
									obj13.AddVertexAt(0, new Point2d(x13, ((Point3d)(ref val5)).Y), _008B_0094(val19.StartAngle, val19.EndAngle), 0.0, 0.0);
									Polyline obj14 = val18;
									val5 = ((Curve)val19).EndPoint;
									double x14 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val19).EndPoint;
									obj14.AddVertexAt(1, new Point2d(x14, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
									Polyline obj15 = val18;
									val5 = ((Curve)val22).EndPoint;
									double x15 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val22).EndPoint;
									obj15.AddVertexAt(2, new Point2d(x15, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val22.StartAngle, val22.EndAngle), 0.0, 0.0);
									num = 21;
									if (!_2())
									{
										goto case 21;
									}
									goto IL_1506;
								}
								case 21:
								{
									Polyline obj16 = val18;
									val5 = ((Curve)val22).StartPoint;
									double x16 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val22).StartPoint;
									obj16.AddVertexAt(3, new Point2d(x16, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
									goto case 2;
								}
								case 41:
								{
									Polyline obj21 = val18;
									val5 = ((Curve)val22).EndPoint;
									double x21 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val22).EndPoint;
									obj21.AddVertexAt(0, new Point2d(x21, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val22.StartAngle, val22.EndAngle), 0.0, 0.0);
									num = 62;
									goto case 62;
								}
								case 62:
								{
									Polyline obj22 = val18;
									val5 = ((Curve)val22).StartPoint;
									double x22 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val22).StartPoint;
									obj22.AddVertexAt(1, new Point2d(x22, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
									num = 29;
									goto case 29;
								}
								case 29:
								{
									Polyline obj23 = val18;
									val5 = ((Curve)val20).EndPoint;
									double x23 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val20).EndPoint;
									obj23.AddVertexAt(2, new Point2d(x23, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val20.StartAngle, val20.EndAngle), 0.0, 0.0);
									Polyline obj24 = val18;
									val5 = ((Curve)val20).StartPoint;
									double x24 = ((Point3d)(ref val5)).X;
									val5 = ((Curve)val20).StartPoint;
									obj24.AddVertexAt(3, new Point2d(x24, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
									goto case 2;
								}
								case 37:
									break;
								case 32:
									goto IL_079b;
								default:
									num = 55;
									goto case 55;
								case 18:
									goto IL_0966;
								case 35:
									goto IL_0977;
								case 10:
									goto IL_09ad;
								case 42:
									goto end_IL_09ad;
								case 83:
									goto end_IL_09be;
								case 38:
									goto end_IL_09e5;
								case 3:
									((Point3d)(ref val16))._002Ector(((Point3d)(ref val)).X + (num8 + num10) * Math.Cos(num2 + num11), ((Point3d)(ref val)).Y + (num8 + num10) * Math.Sin(num2 + num11), 0.0);
									num = 23;
									goto case 23;
								case 23:
									num17 = Math.Atan2(((Point3d)(ref val)).Y - ((Point3d)(ref val16)).Y, ((Point3d)(ref val)).X - ((Point3d)(ref val16)).X);
									goto case 12;
								case 12:
									num18 = Math.Atan(num9 / num6);
									((Point3d)(ref val17))._002Ector(((Point3d)(ref val)).X + (num6 + num7 - num9) * Math.Cos(num3 - num18), ((Point3d)(ref val)).Y + (num6 + num7 - num9) * Math.Sin(num3 - num18), 0.0);
									num19 = Math.Atan2(((Point3d)(ref val17)).Y - ((Point3d)(ref val)).Y, ((Point3d)(ref val17)).X - ((Point3d)(ref val)).X);
									_2();
									if (_1())
									{
										goto case 71;
									}
									num = 46;
									goto IL_1d09;
								case 47:
									return;
								case 54:
									goto IL_0bd0;
								case 65:
									goto IL_0bdf;
								case 7:
									goto IL_0cc2;
								case 73:
									goto IL_0ccf;
								case 4:
									goto IL_0ce4;
								case 44:
									goto IL_0d3d;
								case 64:
									goto IL_0d8a;
								case 19:
									goto IL_0da2;
								case 60:
									goto IL_0dfc;
								case 28:
									goto IL_0e13;
								case 25:
									goto IL_0e23;
								case 6:
									goto IL_0e34;
								case 15:
									goto IL_0f87;
								case 24:
									goto IL_102a;
								case 16:
									goto IL_1194;
								case 27:
								case 48:
									goto IL_1277;
								case 11:
								case 31:
									goto IL_1284;
								case 53:
									goto IL_1291;
								case 71:
								case 77:
									num20 = -9260;
									goto IL_1b8f;
								case 85:
									goto IL_12ce;
								case 34:
									goto IL_131f;
								case 72:
									goto IL_13c2;
								case 70:
									goto IL_13e2;
								case 78:
									goto IL_1416;
								case 1:
									goto IL_143c;
								case 84:
									goto IL_145a;
								case 5:
									goto IL_1462;
								case 13:
									goto IL_1506;
								case 58:
									goto IL_15b5;
								case 49:
									goto IL_1650;
								case 51:
									goto IL_16ab;
								case 74:
									goto IL_16fc;
								case 68:
									goto IL_1757;
								case 63:
									goto IL_17b5;
								case 40:
								case 57:
									goto IL_1815;
								case 79:
									return;
								case 61:
									goto IL_182b;
								case 0:
									goto IL_18de;
								case 59:
									goto IL_1930;
								case 14:
									goto IL_1a71;
								case 33:
									goto IL_1b14;
								case 66:
								case 81:
									goto IL_1b5c;
								case 82:
									goto IL_1b6d;
								case 20:
									goto IL_1b8f;
								case 43:
									goto IL_1bf4;
								case 45:
									goto IL_1c1c;
								case 46:
								case 75:
									goto IL_1d09;
								case 9:
								case 86:
									return;
								}
								break;
							}
							goto IL_0767;
							IL_0bd0:
							num25 = Math.Asin(num10 / (num8 + num10));
							goto IL_0bdf;
							IL_0bdf:
							((Point3d)(ref val23))._002Ector(((Point3d)(ref val)).X + (num8 + num10) * Math.Cos(num2 - num25), ((Point3d)(ref val)).Y + (num8 + num10) * Math.Sin(num2 - num25), 0.0);
							num26 = Math.Atan2(((Point3d)(ref val)).Y - ((Point3d)(ref val23)).Y, ((Point3d)(ref val)).X - ((Point3d)(ref val23)).X);
							num27 = Math.Atan(num9 / num6);
							((Point3d)(ref val24))._002Ector(((Point3d)(ref val)).X + (num6 + num7 - num9) * Math.Cos(num3 + num27), ((Point3d)(ref val)).Y + (num6 + num7 - num9) * Math.Sin(num3 + num27), 0.0);
							num28 = Math.Atan2(((Point3d)(ref val24)).Y - ((Point3d)(ref val)).Y, ((Point3d)(ref val24)).X - ((Point3d)(ref val)).X);
							num = 7;
							goto IL_0cc2;
							IL_0cc2:
							num29 = -9260;
							goto IL_1284;
							IL_0977:
							num4 = num2;
							goto IL_098f;
							IL_0966:
							num5 = num3;
							goto IL_0968;
							IL_1a71:
							Polyline obj26 = val25;
							val5 = ((Curve)val26).EndPoint;
							double x26 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val26).EndPoint;
							obj26.AddVertexAt(1, new Point2d(x26, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							Polyline obj27 = val25;
							val5 = ((Curve)val27).StartPoint;
							double x27 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val27).StartPoint;
							obj27.AddVertexAt(2, new Point2d(x27, ((Point3d)(ref val5)).Y), _008B_0094(val27.StartAngle, val27.EndAngle), 0.0, 0.0);
							num = 33;
							goto IL_1b14;
							IL_1b14:
							Polyline obj28 = val25;
							val5 = ((Curve)val27).EndPoint;
							double x28 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val27).EndPoint;
							obj28.AddVertexAt(3, new Point2d(x28, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							goto IL_1b5c;
							IL_1b5c:
							val25.Closed = false;
							num = 82;
							goto IL_1b6d;
							IL_1b6d:
							_008B._0088_008D((Entity)(object)val25, database);
							num20 += 4630;
							num = 20;
							goto IL_1b8f;
							IL_1b8f:
							if (num20 <= 9260)
							{
								val28 = new Arc(val16, num10 - (double)num20, num17, num2 - Math.PI / 2.0);
								val27 = new Arc(val17, num9 + (double)num20, num19, num3 + Math.PI / 2.0);
								val26 = new Arc(val, num8 + (double)num20, num2 + num11, num3 - num18);
								num = 43;
								goto IL_1bf4;
							}
							num = 86;
							return;
							IL_1416:
							val7 = new Arc(val12, num9 + (double)num13, num12, num3 + Math.PI / 2.0);
							num = 1;
							goto IL_143c;
							IL_1bf4:
							val25 = new Polyline();
							num = 61;
							goto IL_182b;
							IL_182b:
							if (num20 >= 0)
							{
								if (num20 != 0)
								{
									if (num20 > 0)
									{
										Polyline obj29 = val25;
										val5 = ((Curve)val26).StartPoint;
										double x29 = ((Point3d)(ref val5)).X;
										val5 = ((Curve)val26).StartPoint;
										obj29.AddVertexAt(0, new Point2d(x29, ((Point3d)(ref val5)).Y), _008B_0094(val26.StartAngle, val26.EndAngle), 0.0, 0.0);
										goto IL_1a71;
									}
									goto IL_1b5c;
								}
								Polyline obj30 = val25;
								val5 = ((Curve)val28).EndPoint;
								double x30 = ((Point3d)(ref val5)).X;
								val5 = ((Curve)val28).EndPoint;
								obj30.AddVertexAt(0, new Point2d(x30, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val28.StartAngle, val28.EndAngle), 0.0, 0.0);
								Polyline obj31 = val25;
								val5 = ((Curve)val28).StartPoint;
								double x31 = ((Point3d)(ref val5)).X;
								val5 = ((Curve)val28).StartPoint;
								obj31.AddVertexAt(1, new Point2d(x31, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
								num = 0;
							}
							else
							{
								num = 45;
								if (!_2())
								{
									goto IL_1c1c;
								}
							}
							goto IL_18de;
							IL_145a:
							if (num13 < 0)
							{
								goto IL_1462;
							}
							if (num13 == 0)
							{
								num = 58;
								goto IL_15b5;
							}
							if (num13 <= 0)
							{
								goto IL_13c2;
							}
							num = 63;
							goto IL_17b5;
							IL_1506:
							Polyline obj32 = val4;
							val5 = ((Curve)val6).StartPoint;
							double x32 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val6).StartPoint;
							obj32.AddVertexAt(2, new Point2d(x32, ((Point3d)(ref val5)).Y), _008B_0094(val6.StartAngle, val6.EndAngle), 0.0, 0.0);
							Polyline obj33 = val4;
							val5 = ((Curve)val6).EndPoint;
							double x33 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val6).EndPoint;
							obj33.AddVertexAt(3, new Point2d(x33, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							goto IL_13c2;
							IL_12ce:
							Polyline obj34 = val4;
							val5 = ((Curve)val6).EndPoint;
							double x34 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val6).EndPoint;
							obj34.AddVertexAt(1, new Point2d(x34, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							num = 34;
							goto IL_131f;
							IL_131f:
							Polyline obj35 = val4;
							val5 = ((Curve)val7).StartPoint;
							double x35 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val7).StartPoint;
							obj35.AddVertexAt(2, new Point2d(x35, ((Point3d)(ref val5)).Y), _008B_0094(val7.StartAngle, val7.EndAngle), 0.0, 0.0);
							Polyline obj36 = val4;
							val5 = ((Curve)val7).EndPoint;
							double x36 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val7).EndPoint;
							obj36.AddVertexAt(3, new Point2d(x36, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							num = 72;
							goto IL_13c2;
							IL_1462:
							Polyline obj37 = val4;
							val5 = ((Curve)val13).EndPoint;
							double x37 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val13).EndPoint;
							obj37.AddVertexAt(0, new Point2d(x37, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val13.StartAngle, val13.EndAngle), 0.0, 0.0);
							Polyline obj38 = val4;
							val5 = ((Curve)val13).StartPoint;
							double x38 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val13).StartPoint;
							obj38.AddVertexAt(1, new Point2d(x38, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							num = 13;
							goto IL_1506;
							IL_1c1c:
							Polyline obj39 = val25;
							val5 = ((Curve)val28).EndPoint;
							double x39 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val28).EndPoint;
							obj39.AddVertexAt(0, new Point2d(x39, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val28.StartAngle, val28.EndAngle), 0.0, 0.0);
							Polyline obj40 = val25;
							val5 = ((Curve)val28).StartPoint;
							double x40 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val28).StartPoint;
							obj40.AddVertexAt(1, new Point2d(x40, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							Polyline obj41 = val25;
							val5 = ((Curve)val26).StartPoint;
							double x41 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val26).StartPoint;
							obj41.AddVertexAt(2, new Point2d(x41, ((Point3d)(ref val5)).Y), _008B_0094(val26.StartAngle, val26.EndAngle), 0.0, 0.0);
							goto IL_1d09;
							IL_1d09:
							Polyline obj42 = val25;
							val5 = ((Curve)val26).EndPoint;
							double x42 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val26).EndPoint;
							obj42.AddVertexAt(3, new Point2d(x42, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							goto IL_1b5c;
							IL_18de:
							Polyline obj43 = val25;
							val5 = ((Curve)val26).StartPoint;
							double x43 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val26).StartPoint;
							obj43.AddVertexAt(2, new Point2d(x43, ((Point3d)(ref val5)).Y), _008B_0094(val26.StartAngle, val26.EndAngle), 0.0, 0.0);
							goto IL_1930;
							IL_1930:
							Polyline obj44 = val25;
							val5 = ((Curve)val26).EndPoint;
							double x44 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val26).EndPoint;
							obj44.AddVertexAt(3, new Point2d(x44, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							Polyline obj45 = val25;
							val5 = ((Curve)val27).StartPoint;
							double x45 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val27).StartPoint;
							obj45.AddVertexAt(4, new Point2d(x45, ((Point3d)(ref val5)).Y), _008B_0094(val27.StartAngle, val27.EndAngle), 0.0, 0.0);
							Polyline obj46 = val25;
							val5 = ((Curve)val27).EndPoint;
							double x46 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val27).EndPoint;
							obj46.AddVertexAt(5, new Point2d(x46, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							goto IL_1b5c;
							IL_143c:
							val6 = new Arc(val, num8 + (double)num13, num2 + num16, num3 - num30);
							val4 = new Polyline();
							goto IL_145a;
							IL_17b5:
							Polyline obj47 = val4;
							val5 = ((Curve)val6).StartPoint;
							double x47 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val6).StartPoint;
							obj47.AddVertexAt(0, new Point2d(x47, ((Point3d)(ref val5)).Y), _008B_0094(val6.StartAngle, val6.EndAngle), 0.0, 0.0);
							num = 85;
							goto IL_12ce;
							IL_0ccf:
							num30 = Math.Atan(num9 / num6);
							num = 4;
							goto IL_0ce4;
							IL_0ce4:
							((Point3d)(ref val12))._002Ector(((Point3d)(ref val)).X + (num6 + num7 - num9) * Math.Cos(num3 - num30), ((Point3d)(ref val)).Y + (num6 + num7 - num9) * Math.Sin(num3 - num30), 0.0);
							num = 53;
							if (!_1())
							{
								goto IL_0d3d;
							}
							goto IL_1291;
							IL_0d3d:
							Polyline obj48 = val8;
							val5 = ((Curve)val11).StartPoint;
							double x48 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val11).StartPoint;
							obj48.AddVertexAt(5, new Point2d(x48, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							goto IL_1277;
							IL_1277:
							val8.Closed = false;
							goto IL_0d8a;
							IL_0d8a:
							_008B._0088_008D((Entity)(object)val8, database);
							num = 19;
							goto IL_0da2;
							IL_0da2:
							num29 += 4630;
							num = 31;
							goto IL_1284;
							IL_1284:
							if (num29 <= 9260)
							{
								val9 = new Arc(val23, num10 - (double)num29, num2 + Math.PI / 2.0, num26);
								val11 = new Arc(val24, num9 + (double)num29, num3 - Math.PI / 2.0, num28);
								num = 60;
								goto IL_0dfc;
							}
							return;
							IL_15b5:
							Polyline obj49 = val4;
							val5 = ((Curve)val13).EndPoint;
							double x49 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val13).EndPoint;
							obj49.AddVertexAt(0, new Point2d(x49, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val13.StartAngle, val13.EndAngle), 0.0, 0.0);
							Polyline obj50 = val4;
							val5 = ((Curve)val13).StartPoint;
							double x50 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val13).StartPoint;
							obj50.AddVertexAt(1, new Point2d(x50, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							goto IL_1650;
							IL_0dfc:
							val10 = new Arc(val, num8 + (double)num29, num3 + num27, num2 - num25);
							goto IL_0e13;
							IL_0e13:
							val8 = new Polyline();
							num = 25;
							goto IL_0e23;
							IL_0e23:
							if (num29 < 0)
							{
								num = 6;
								goto IL_0e34;
							}
							if (num29 == 0)
							{
								num = 15;
								goto IL_0f87;
							}
							if (num29 > 0)
							{
								Polyline obj51 = val8;
								val5 = ((Curve)val10).EndPoint;
								double x51 = ((Point3d)(ref val5)).X;
								val5 = ((Curve)val10).EndPoint;
								obj51.AddVertexAt(0, new Point2d(x51, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val10.StartAngle, val10.EndAngle), 0.0, 0.0);
								num = 16;
								goto IL_1194;
							}
							goto IL_1277;
							IL_1650:
							Polyline obj52 = val4;
							val5 = ((Curve)val6).StartPoint;
							double x52 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val6).StartPoint;
							obj52.AddVertexAt(2, new Point2d(x52, ((Point3d)(ref val5)).Y), _008B_0094(val6.StartAngle, val6.EndAngle), 0.0, 0.0);
							num = 51;
							goto IL_16ab;
							IL_0e34:
							Polyline obj53 = val8;
							val5 = ((Curve)val9).StartPoint;
							double x53 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val9).StartPoint;
							obj53.AddVertexAt(0, new Point2d(x53, ((Point3d)(ref val5)).Y), _008B_0094(val9.StartAngle, val9.EndAngle), 0.0, 0.0);
							Polyline obj54 = val8;
							val5 = ((Curve)val9).EndPoint;
							double x54 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val9).EndPoint;
							obj54.AddVertexAt(1, new Point2d(x54, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							Polyline obj55 = val8;
							val5 = ((Curve)val10).EndPoint;
							double x55 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val10).EndPoint;
							obj55.AddVertexAt(2, new Point2d(x55, ((Point3d)(ref val5)).Y), 0.0 - _008B_0094(val10.StartAngle, val10.EndAngle), 0.0, 0.0);
							Polyline obj56 = val8;
							val5 = ((Curve)val10).StartPoint;
							double x56 = ((Point3d)(ref val5)).X;
							val5 = ((Curve)val10).StartPoint;
							obj56.AddVertexAt(3, new Point2d(x56, ((Point3d)(ref val5)).Y), 0.0, 0.0, 0.0);
							num = 27;
							goto IL_1277;
							continue;
							end_IL_09ad:
							break;
						}
						continue;
						end_IL_09be:
						break;
					}
					continue;
					end_IL_09e5:
					break;
				}
			}
		}

		internal unsafe static void _008B_0091()
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			if (false /* original-file-bool-offset:176 */)
			{
				return;
			}
			_008F_008E obj = _008B_008D("\n请指定圆心点" /* string-offset:924 */)._008C_0087();
			double num = _008F_008E._008B_0088_009E(_008B_008D("\n请指定圆周点" /* string-offset:928 */)._008C_0087(), obj);
			_ = 0;
			Editor editor = default(Editor);
			DBPoint val2 = default(DBPoint);
			Point3d position = default(Point3d);
			string text2;
			if (_1())
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				editor = mdiActiveDocument.Editor;
				Database database = mdiActiveDocument.Database;
				List<DBPoint> list = new List<DBPoint>();
				Transaction val = database.TransactionManager.StartTransaction();
				try
				{
					list = database._008B_008A<DBPoint>((OpenMode)0, _0020: false);
					editor.WriteMessage("\n检测到 " /* string-offset:932 */ + list.Count + " 个障碍物。" /* string-offset:936 */);
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
				val2 = new DBPoint(new Point3d(0.0, 0.0, 0.0));
				foreach (DBPoint item in list)
				{
					((Entity)item).Unhighlight();
					_2();
					if (_1())
					{
						position = item.Position;
						double x = ((Point3d)(ref position)).X;
						position = item.Position;
						if (!(_008F_008E._008B_0088_009E(new _008F_008E(x, ((Point3d)(ref position)).Y), obj) < num))
						{
							continue;
						}
						position = val2.Position;
					}
					else if (_1())
					{
					}
					double z = ((Point3d)(ref position)).Z;
					position = item.Position;
					if (z < ((Point3d)(ref position)).Z)
					{
						val2 = item;
					}
				}
				position = val2.Position;
				if (!(((Point3d)(ref position)).Z > 0.0))
				{
					return;
				}
				ResultBuffer xDataForApplication = ((DBObject)val2).GetXDataForApplication("WsEntityFrame" /* string-offset:940 */);
				if (xDataForApplication == (ResultBuffer)null)
				{
					Editor obj2 = editor;
					string text = "\n最高点为 " /* string-offset:944 */;
					position = val2.Position;
					obj2.WriteMessage(text + ((object)(*(Point3d*)(&position))/*cast due to .constrained prefix*/).ToString() + "\n" /* string-offset:328 */);
					goto IL_0269;
				}
				_008E_008D obj3 = _008E_008D._008A_0099_0093(xDataForApplication);
				if (obj3 != null)
				{
					if (!string.IsNullOrEmpty(obj3.EntityName))
					{
						text2 = obj3.EntityName;
						goto IL_023b;
					}
					if (_2())
					{
						goto IL_0272;
					}
				}
				position = val2.Position;
				text2 = ((object)(*(Point3d*)(&position))/*cast due to .constrained prefix*/).ToString();
				goto IL_023b;
			}
			goto IL_0272;
			IL_0269:
			((Entity)val2).Highlight();
			goto IL_0272;
			IL_0272:
			ViewTableRecord currentView = editor.GetCurrentView();
			if (_1())
			{
				position = val2.Position;
				double x2 = ((Point3d)(ref position)).X;
				position = val2.Position;
				((AbstractViewTableRecord)currentView).CenterPoint = new Point2d(x2, ((Point3d)(ref position)).Y);
			}
			editor.SetCurrentView(currentView);
			return;
			IL_023b:
			string text3 = text2;
			Editor obj4 = editor;
			string text4 = "\n最高点为 " /* string-offset:944 */;
			position = val2.Position;
			obj4.WriteMessage(text4 + text3 + ((object)(*(Point3d*)(&position))/*cast due to .constrained prefix*/).ToString());
			goto IL_0269;
		}

		internal static void _008B_0092()
		{
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_048d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0492: Unknown result type (might be due to invalid IL or missing references)
			//IL_036d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0372: Unknown result type (might be due to invalid IL or missing references)
			//IL_037d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Unknown result type (might be due to invalid IL or missing references)
			if (!_1())
			{
				goto IL_003a;
			}
			if (false /* original-file-bool-offset:180 */)
			{
				_ = 0;
				if (_1())
				{
					return;
				}
				goto IL_0063;
			}
			double num = _008B_008C("\n请输入基准角度" /* string-offset:948 */);
			goto IL_02b0;
			IL_0063:
			List<DBPoint> list;
			Database database = default(Database);
			Editor editor = default(Editor);
			Transaction val = default(Transaction);
			try
			{
				list = database._008B_008A<DBPoint>((OpenMode)0, _0020: false);
				editor.WriteMessage("\n检测到 " /* string-offset:932 */ + list.Count + " 个障碍物。" /* string-offset:936 */);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			Point3d position;
			Point3d val2 = default(Point3d);
			Point3d val3 = default(Point3d);
			double num3 = default(double);
			foreach (DBPoint item in list)
			{
				ResultBuffer xDataForApplication = ((DBObject)item).GetXDataForApplication("WsEntityFrame" /* string-offset:940 */);
				string text2;
				if (xDataForApplication != (ResultBuffer)null)
				{
					_008E_008D obj = _008E_008D._008A_0099_0093(xDataForApplication);
					string text;
					while (true)
					{
						if (obj != null)
						{
							if (!_1())
							{
								continue;
							}
							if (!string.IsNullOrEmpty(obj.EntityName))
							{
								text = obj.EntityName;
								break;
							}
						}
						text = "未定义" /* string-offset:952 */;
						break;
					}
					text2 = text;
				}
				else
				{
					text2 = "未定义" /* string-offset:952 */;
				}
				position = item.Position;
				double x = ((Point3d)(ref position)).X;
				position = item.Position;
				((Point3d)(ref val2))._002Ector(x, ((Point3d)(ref position)).Y, 0.0);
				double num2 = 90.0 - 180.0 * Math.Atan2(((Point3d)(ref val2)).Y - ((Point3d)(ref val3)).Y, ((Point3d)(ref val2)).X - ((Point3d)(ref val3)).X) / Math.PI;
				_1();
				if (!_2())
				{
					num2 = Math.Round(num + ((num2 < 0.0) ? (num2 + 360.0) : num2), 0);
					num2 = ((num2 > 360.0) ? (num2 - 360.0) : num2);
					num3 = Math.Round(((Point3d)(ref val2)).DistanceTo(val3), 0);
				}
				if (num3 <= 15000.0)
				{
					Editor obj2 = editor;
					string[] obj3 = new string[8]
					{
						"\n15km障碍物：" /* string-offset:956 */,
						text2,
						"," /* string-offset:704 */,
						num2.ToString(),
						"," /* string-offset:704 */,
						num3.ToString(),
						"," /* string-offset:704 */,
						null
					};
					position = item.Position;
					obj3[7] = ((Point3d)(ref position)).Z.ToString();
					obj2.WriteMessage(string.Concat(obj3));
				}
			}
			List<DBPoint>.Enumerator enumerator2 = list.GetEnumerator();
			if (_1())
			{
				try
				{
					string text3 = default(string);
					Point3d val4 = default(Point3d);
					double num4 = default(double);
					double num5 = default(double);
					while (enumerator2.MoveNext())
					{
						DBPoint current2 = enumerator2.Current;
						_ = 0;
						if (_1() && _1())
						{
							ResultBuffer xDataForApplication2 = ((DBObject)current2).GetXDataForApplication("WsEntityFrame" /* string-offset:940 */);
							if (!(xDataForApplication2 != (ResultBuffer)null))
							{
								text3 = "未定义" /* string-offset:952 */;
								if (_1())
								{
									goto IL_0369;
								}
							}
							_008E_008D obj4 = _008E_008D._008A_0099_0093(xDataForApplication2);
							text3 = ((obj4 == null || string.IsNullOrEmpty(obj4.EntityName)) ? "未定义" /* string-offset:952 */ : obj4.EntityName);
							goto IL_0369;
						}
						goto IL_0418;
						IL_0369:
						position = current2.Position;
						double x2 = ((Point3d)(ref position)).X;
						position = current2.Position;
						((Point3d)(ref val4))._002Ector(x2, ((Point3d)(ref position)).Y, 0.0);
						num4 = 90.0 - 180.0 * Math.Atan2(((Point3d)(ref val4)).Y - ((Point3d)(ref val3)).Y, ((Point3d)(ref val4)).X - ((Point3d)(ref val3)).X) / Math.PI;
						num4 = Math.Round(num + ((num4 < 0.0) ? (num4 + 360.0) : num4), 0);
						num5 = Math.Round(((Point3d)(ref val4)).DistanceTo(val3), 0);
						goto IL_0418;
						IL_0418:
						if (num5 > 15000.0 && num5 < 55000.0)
						{
							Editor obj5 = editor;
							string[] obj6 = new string[8]
							{
								"\n55km障碍物：" /* string-offset:960 */,
								text3,
								"," /* string-offset:704 */,
								num4.ToString(),
								"," /* string-offset:704 */,
								num5.ToString(),
								"," /* string-offset:704 */,
								null
							};
							position = current2.Position;
							obj6[7] = ((Point3d)(ref position)).Z.ToString();
							obj5.WriteMessage(string.Concat(obj6));
						}
					}
					return;
				}
				finally
				{
					((IDisposable)enumerator2/*cast due to .constrained prefix*/).Dispose();
				}
			}
			goto IL_02b0;
			IL_02b0:
			val3 = _008B_008D("\n请指定圆心点" /* string-offset:924 */);
			((Point3d)(ref val3))._002Ector(((Point3d)(ref val3)).X, ((Point3d)(ref val3)).Y, 0.0);
			goto IL_003a;
			IL_003a:
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			editor = mdiActiveDocument.Editor;
			database = mdiActiveDocument.Database;
			list = new List<DBPoint>();
			val = database.TransactionManager.StartTransaction();
			goto IL_0063;
		}

		private static string _008B_0093(string P_0, double P_1)
		{
			return "\n" /* string-offset:328 */ + P_0 + ": " /* string-offset:964 */ + P_1 * 180.0 / Math.PI;
		}

		private static double _008B_0094(double P_0, double P_1)
		{
			_1();
			if (_2())
			{
				goto IL_0173;
			}
			int num = 9;
			double num3 = default(double);
			while (!false /* original-file-bool-offset:184 */)
			{
				P_0 = ((P_0 < 0.0) ? (P_0 + Math.PI * 2.0) : P_0);
				if (!(P_1 < 0.0))
				{
					num = 3;
					if (_2())
					{
						break;
					}
					goto IL_00d8;
				}
				double num2 = P_1 + Math.PI * 2.0;
				goto IL_0124;
				IL_0113:
				num2 = P_1;
				goto IL_0124;
				IL_0124:
				P_1 = num2;
				num3 = 0.0;
				if (!(P_0 < P_1))
				{
					if (P_0 - P_1 <= Math.PI)
					{
						num = 8;
						if (!_1())
						{
							break;
						}
						goto IL_00d8;
					}
					num3 = Math.PI * 2.0 + P_1 - P_0;
					num = 11;
					break;
				}
				num = 1;
				goto IL_0091;
				IL_00d8:
				while (true)
				{
					switch (num)
					{
					case 1:
						break;
					default:
						num = 2;
						if (!_2())
						{
							continue;
						}
						goto IL_0173;
					case 3:
						goto IL_0113;
					case 0:
					case 9:
						goto IL_0139;
					case 8:
						num3 = P_0 - P_1;
						num = 7;
						goto end_IL_0139;
					case 4:
					case 5:
						goto IL_0173;
					case 2:
					case 6:
					case 7:
					case 10:
					case 11:
						goto end_IL_0139;
					}
					break;
				}
				goto IL_0091;
				IL_0091:
				if (P_1 - P_0 > Math.PI)
				{
					num3 = Math.PI * 2.0 + P_0 - P_1;
					num = 10;
					if (_2())
					{
						break;
					}
					goto IL_00d8;
				}
				goto IL_0173;
				continue;
				end_IL_0139:
				break;
				IL_0139:;
			}
			goto IL_0177;
			IL_0173:
			num3 = P_1 - P_0;
			goto IL_0177;
			IL_0177:
			return (1.0 - Math.Cos(num3 / 2.0)) / Math.Sin(num3 / 2.0);
		}

		private static bool _008B_0095(double P_0, double P_1)
		{
			int num = 2;
			bool result = default(bool);
			if (_1())
			{
				do
				{
					switch (num)
					{
					case 1:
					case 4:
						if (!(P_1 - P_0 <= Math.PI))
						{
							result = false;
							break;
						}
						goto IL_0023;
					case 2:
						if (P_0 < P_1)
						{
							_1();
							if (!_2())
							{
								goto case 1;
							}
							break;
						}
						if (P_0 - P_1 > Math.PI)
						{
							result = true;
							num = 8;
							break;
						}
						goto default;
					case 6:
						result = true;
						num = 0;
						break;
					default:
						result = false;
						break;
					case 0:
					case 3:
					case 5:
					case 8:
						break;
					}
					break;
					IL_0023:
					num = 6;
				}
				while (_1());
			}
			return result;
		}

		internal static void _008B_0096(bool P_0 = true)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Expected O, but got Unknown
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Expected O, but got Unknown
			//IL_0636: Unknown result type (might be due to invalid IL or missing references)
			//IL_063d: Expected O, but got Unknown
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0542: Unknown result type (might be due to invalid IL or missing references)
			//IL_05db: Unknown result type (might be due to invalid IL or missing references)
			//IL_0600: Unknown result type (might be due to invalid IL or missing references)
			//IL_0463: Unknown result type (might be due to invalid IL or missing references)
			//IL_0575: Unknown result type (might be due to invalid IL or missing references)
			//IL_059a: Unknown result type (might be due to invalid IL or missing references)
			//IL_048a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0435: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Unknown result type (might be due to invalid IL or missing references)
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_071e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0653: Unknown result type (might be due to invalid IL or missing references)
			//IL_0516: Unknown result type (might be due to invalid IL or missing references)
			//IL_067e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0767: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0776: Unknown result type (might be due to invalid IL or missing references)
			//IL_0758: Unknown result type (might be due to invalid IL or missing references)
			if (!true /* original-file-bool-offset:188 */)
			{
				return;
			}
			Point3d val = _008B_008D("\n请指定IF点" /* string-offset:916 */);
			Point3d val2 = _008B_008D("\n请指定FAF点" /* string-offset:968 */);
			Point3d val3 = _008B_008D("\n请指定FAF外边界点" /* string-offset:972 */);
			double num = Math.Atan2(((Point3d)(ref val2)).Y - ((Point3d)(ref val)).Y, ((Point3d)(ref val2)).X - ((Point3d)(ref val)).X);
			double num2 = 9260.0;
			double num3 = ((Point3d)(ref val2)).DistanceTo(val3);
			Point2d val4 = default(Point2d);
			((Point2d)(ref val4))._002Ector(((Point3d)(ref val)).X + num2 * Math.Cos(num - Math.PI / 2.0), ((Point3d)(ref val)).Y + num2 * Math.Sin(num - Math.PI / 2.0));
			Point2d val5 = default(Point2d);
			((Point2d)(ref val5))._002Ector(((Point3d)(ref val)).X + num2 * Math.Cos(num + Math.PI / 2.0), ((Point3d)(ref val)).Y + num2 * Math.Sin(num + Math.PI / 2.0));
			Point2d val6 = default(Point2d);
			Point2d val7 = default(Point2d);
			Point2d val8 = default(Point2d);
			Point2d val9 = default(Point2d);
			Point2d val10 = default(Point2d);
			Point2d val11 = default(Point2d);
			Editor editor = default(Editor);
			if (!_2())
			{
				while (true)
				{
					((Point2d)(ref val6))._002Ector(((Point3d)(ref val2)).X + num3 * Math.Cos(num - Math.PI / 2.0), ((Point3d)(ref val2)).Y + num3 * Math.Sin(num - Math.PI / 2.0));
					((Point2d)(ref val7))._002Ector(((Point3d)(ref val2)).X + num3 * Math.Cos(num + Math.PI / 2.0), ((Point3d)(ref val2)).Y + num3 * Math.Sin(num + Math.PI / 2.0));
					((Point2d)(ref val8))._002Ector((((Point3d)(ref val)).X + ((Point2d)(ref val4)).X) / 2.0, (((Point3d)(ref val)).Y + ((Point2d)(ref val4)).Y) / 2.0);
					_2();
					if (!_1())
					{
						break;
					}
					if (_1())
					{
						((Point2d)(ref val9))._002Ector((((Point3d)(ref val)).X + ((Point2d)(ref val5)).X) / 2.0, (((Point3d)(ref val)).Y + ((Point2d)(ref val5)).Y) / 2.0);
						((Point2d)(ref val10))._002Ector((((Point3d)(ref val2)).X + ((Point2d)(ref val6)).X) / 2.0, (((Point3d)(ref val2)).Y + ((Point2d)(ref val6)).Y) / 2.0);
						break;
					}
				}
				((Point2d)(ref val11))._002Ector((((Point3d)(ref val2)).X + ((Point2d)(ref val7)).X) / 2.0, (((Point3d)(ref val2)).Y + ((Point2d)(ref val7)).Y) / 2.0);
				editor = Application.DocumentManager.MdiActiveDocument.Editor;
			}
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Polyline val12 = new Polyline();
				Polyline val13 = new Polyline();
				int num4 = 5;
				while (true)
				{
					IL_0636:
					Polyline val14 = new Polyline();
					num4 = 12;
					if (_2())
					{
						goto IL_053f;
					}
					goto IL_062e;
					IL_062e:
					if (!P_0)
					{
						val12.AddVertexAt(0, val4, 0.0, 0.0, 0.0);
						goto IL_02e0;
					}
					val12.AddVertexAt(0, val4, 0.0, 0.0, 0.0);
					val12.AddVertexAt(1, val8, 0.0, 0.0, 0.0);
					num4 = 20;
					goto IL_0460;
					IL_041e:
					val12.Closed = true;
					num4 = 18;
					goto IL_0376;
					IL_0376:
					val13.AddVertexAt(0, val5, 0.0, 0.0, 0.0);
					val13.AddVertexAt(1, val9, 0.0, 0.0, 0.0);
					val13.AddVertexAt(2, val11, 0.0, 0.0, 0.0);
					val13.AddVertexAt(3, val7, 0.0, 0.0, 0.0);
					num4 = 6;
					if (!_2())
					{
						goto IL_030e;
					}
					goto IL_04b3;
					IL_02e0:
					_ = 0;
					if (!_1())
					{
						num4 = 2;
						goto IL_0572;
					}
					goto IL_0487;
					IL_030e:
					while (true)
					{
						switch (num4)
						{
						case 6:
							do
							{
								val13.Closed = true;
								num4 = 17;
							}
							while (_2());
							continue;
						case 18:
							goto IL_0376;
						case 3:
							goto IL_041e;
						case 21:
							goto IL_0432;
						case 20:
							goto IL_0460;
						case 10:
						case 15:
							goto IL_0487;
						case 14:
							goto IL_04b3;
						case 8:
							goto IL_04e7;
						case 7:
							goto IL_0513;
						case 0:
							goto IL_053f;
						case 19:
							goto IL_056a;
						case 2:
						case 16:
							goto IL_0572;
						case 12:
							goto IL_062e;
						case 5:
							goto IL_0636;
						case 4:
							val14.AddVertexAt(2, val7, 0.0, 0.0, 0.0);
							num4 = 9;
							goto case 9;
						case 9:
							val14.AddVertexAt(3, val6, 0.0, 0.0, 0.0);
							val14.Closed = true;
							goto IL_074f;
						case 17:
							val14.AddVertexAt(0, val8, 0.0, 0.0, 0.0);
							val14.AddVertexAt(1, val9, 0.0, 0.0, 0.0);
							val14.AddVertexAt(2, val11, 0.0, 0.0, 0.0);
							goto case 1;
						case 1:
							val14.AddVertexAt(3, val10, 0.0, 0.0, 0.0);
							num4 = 11;
							goto case 11;
						case 11:
							val14.Closed = true;
							goto IL_074f;
						case 13:
							_008B._0088_008D((Entity)(object)val13, database);
							goto case 22;
						case 22:
							{
								_008B._0088_008D((Entity)(object)val14, database);
								return;
							}
							IL_074f:
							_008B._0088_008D((Entity)(object)val12, database);
							goto case 13;
						}
						break;
					}
					goto IL_02e0;
					IL_0487:
					val12.AddVertexAt(1, val8, 0.0, 0.0, 0.0);
					num4 = 14;
					goto IL_04b3;
					IL_04b3:
					val12.AddVertexAt(2, val6, 0.0, 0.0, 0.0);
					val12.Closed = true;
					num4 = 8;
					goto IL_04e7;
					IL_04e7:
					val13.AddVertexAt(0, val5, 0.0, 0.0, 0.0);
					num4 = 7;
					goto IL_0513;
					IL_0513:
					val13.AddVertexAt(1, val9, 0.0, 0.0, 0.0);
					num4 = 0;
					goto IL_053f;
					IL_053f:
					val13.AddVertexAt(2, val7, 0.0, 0.0, 0.0);
					num4 = 19;
					goto IL_056a;
					IL_056a:
					val13.Closed = true;
					goto IL_0572;
					IL_0572:
					val14.AddVertexAt(0, val8, 0.0, 0.0, 0.0);
					val14.AddVertexAt(1, val9, 0.0, 0.0, 0.0);
					num4 = 4;
					if (!_2())
					{
						goto IL_030e;
					}
					goto IL_0460;
					IL_0460:
					val12.AddVertexAt(2, val10, 0.0, 0.0, 0.0);
					goto IL_0432;
					IL_0432:
					val12.AddVertexAt(3, val6, 0.0, 0.0, 0.0);
					num4 = 3;
					goto IL_041e;
				}
			}
			catch
			{
				editor.WriteMessage("中间航段保护区绘制失败。\n" /* string-offset:976 */);
			}
		}

		private static double _008B_0097(double P_0)
		{
			if (!(P_0 < Math.PI / 2.0) && P_0 <= 4.71238898038469)
			{
				return Math.PI - P_0;
			}
			return 0.0 - P_0;
		}

		private static string _008B_0098(double P_0)
		{
			string text = default(string);
			while (true)
			{
				P_0 = _008B_0099(P_0);
				if (_1())
				{
				}
				double num = Math.Round(P_0);
				_ = 0;
				if (!_1())
				{
					if (_2())
					{
						continue;
					}
				}
				else
				{
					text = num.ToString();
					if (num < 10.0)
					{
						text = "00" /* string-offset:980 */ + text;
						break;
					}
					if (!(num < 100.0))
					{
						break;
					}
				}
				text = "0" /* string-offset:560 */ + text;
				break;
			}
			return text;
		}

		private static double _008B_0099(double P_0)
		{
			P_0 = ((P_0 < 0.0) ? (P_0 + 360.0) : P_0);
			P_0 = ((P_0 > 360.0) ? (P_0 - 360.0) : P_0);
			return P_0;
		}

		private static double _008B_009A(double P_0)
		{
			P_0 = ((P_0 < 0.0) ? (P_0 + Math.PI * 2.0) : P_0);
			P_0 = ((P_0 > Math.PI * 2.0) ? (P_0 - Math.PI * 2.0) : P_0);
			return P_0;
		}

		static _009D()
		{
			LicenseManager.Validate(typeof(_009D));
		}

		internal static bool _1()
		{
			return true;
		}

		internal static bool _2()
		{
			return false;
		}
	}
}
