using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Recovered.A6;
using Recovered.B5;
using Recovered.B4;
// E1/E2 extraction. Only independent source, no target DLL or CAD execution.
namespace Recovered.A5 {
public class PrecisionApproachForm {
public OasModel _0087_0092_008E; public PaOasGeometry _0087_0092_008F; public TemplatePoint _0087_0092_0090,_0087_0092_0091;
public PrecisionCell _0087_0093_008C = new PrecisionCell(); // LocDistance
public PrecisionCell _0087_0092_009B = new PrecisionCell(); // radioButtonPsRight
public PrecisionCell _0087_0096_008A = new PrecisionCell(); // textBox1
public PrecisionCell _0087_0092_009E = new PrecisionCell(); // label18
public PrecisionCell _0087_0093_0086 = new PrecisionCell(); // label24
public PrecisionCell _0087_0093_0087 = new PrecisionCell(); // textBoxWing
public PrecisionCell _0087_0093_008D = new PrecisionCell(); // label19
public PrecisionCell _0087_0093_008E = new PrecisionCell(); // label21
public PrecisionCell _0087_0092_0098 = new PrecisionCell(); // buttonDraw
public PrecisionCell _0087_0096_0087 = new PrecisionCell(); // textBoxFAF
public PrecisionCell _0087_0095_009B = new PrecisionCell(); // textBoxIF
public PrecisionCell _0087_0094_0086 = new PrecisionCell(); // label25
public PrecisionCell _0087_0094_0092 = new PrecisionCell(); // button3
public PrecisionCell _0087_0095_0089 = new PrecisionCell(); // textBoxLat2
public PrecisionCell _0087_0094_0087 = new PrecisionCell(); // textBoxWsB
public PrecisionCell _0087_0093_0096 = new PrecisionCell(); // label27
public PrecisionCell _0087_0094_0091 = new PrecisionCell(); // button5
public PrecisionCell _0087_0095_008B = new PrecisionCell(); // textBoxLon2
public PrecisionCell _0087_0095_008C = new PrecisionCell(); // label7
public PrecisionCell _0087_0094_0096 = new PrecisionCell(); // groupBox6
public PrecisionCell _0087_0095_008A = new PrecisionCell(); // label6
public PrecisionCell _0087_0094_009B = new PrecisionCell(); // button4
public PrecisionCell _0087_0095_0086 = new PrecisionCell(); // button10
public PrecisionCell _0087_0095_0087 = new PrecisionCell(); // button6
public PrecisionCell _0087_0093_0095 = new PrecisionCell(); // textBoxZA
public PrecisionCell _0087_0095_009A = new PrecisionCell(); // button2
public PrecisionCell _0087_0093_0092 = new PrecisionCell(); // label23
public PrecisionCell _0087_0094_0089 = new PrecisionCell(); // textBoxXB
public PrecisionCell _0087_0092_009D = new PrecisionCell(); // comboBoxMissCG
public PrecisionCell _0087_0092_0097 = new PrecisionCell(); // radioButtonFAP
public PrecisionCell _0087_0095_008D = new PrecisionCell(); // label10
public PrecisionCell _0087_0093_009C = new PrecisionCell(); // textBoxWsA
public PrecisionCell _0087_0095_0099 = new PrecisionCell(); // button1
public PrecisionCell _0087_0094_0088 = new PrecisionCell(); // textBoxXC
public PrecisionCell _0087_0094_009D = new PrecisionCell(); // label5
public PrecisionCell _0087_0093_0097 = new PrecisionCell(); // label20
public PrecisionCell _0087_0093_0098 = new PrecisionCell(); // textBoxWA
public PrecisionCell _0087_0093_0091 = new PrecisionCell(); // comboBoxAppType
public PrecisionCell _0087_0094_008A = new PrecisionCell(); // textBoxWC
public PrecisionCell _0087_0094_008B = new PrecisionCell(); // textBoxXA
public PrecisionCell _0087_0093_0088 = new PrecisionCell(); // textBoxRDH
public PrecisionCell _0087_0093_009D = new PrecisionCell(); // textBoxYA
public PrecisionCell _0087_0093_0089 = new PrecisionCell(); // comboBoxCat
public PrecisionCell _0087_0093_008A = new PrecisionCell(); // label13
public PrecisionCell _0087_0093_008B = new PrecisionCell(); // textBoxWheel
public PrecisionCell _0087_0095_0090 = new PrecisionCell(); // tabPage4
public PrecisionCell _0087_0095_009D = new PrecisionCell(); // textBoxFafFix
public PrecisionCell _0087_0096_0089 = new PrecisionCell(); // groupBox2
public PrecisionCell _0087_0095_0091 = new PrecisionCell(); // textBoxP1A
public PrecisionCell _0087_0095_0097 = new PrecisionCell(); // textBoxP2C
public PrecisionCell _0087_0095_0094 = new PrecisionCell(); // textBoxP1C
public PrecisionCell _0087_0095_0096 = new PrecisionCell(); // textBoxP2A
public PrecisionCell _0087_0095_0095 = new PrecisionCell(); // label15
public PrecisionCell _0087_0095_0092 = new PrecisionCell(); // label3
public PrecisionCell _0087_0095_0098 = new PrecisionCell(); // textBoxP2B
public PrecisionCell _0087_0095_0093 = new PrecisionCell(); // textBoxP1B
public PrecisionCell _0087_0092_0094 = new PrecisionCell(); // radioButtonPsLeft
public PrecisionCell _0087_0092_0095 = new PrecisionCell(); // radioButtonOAS
public PrecisionCell _0087_0092_0096 = new PrecisionCell(); // radioButtonFAF
public PrecisionCell _0087_0095_008E = new PrecisionCell(); // tabPage2
public PrecisionCell _0087_0096_0088 = new PrecisionCell(); // button7
public PrecisionCell _0087_0095_008F = new PrecisionCell(); // label44
public PrecisionCell _0087_0094_008C = new PrecisionCell(); // textBoxWsC
public PrecisionCell _0087_0094_008D = new PrecisionCell(); // label28
public PrecisionCell _0087_0093_008F = new PrecisionCell(); // label22
public PrecisionCell _0087_0093_0090 = new PrecisionCell(); // comboBoxGP
public PrecisionCell _0087_0093_0093 = new PrecisionCell(); // textBoxZC
public PrecisionCell _0087_0094_009E = new PrecisionCell(); // groupBox7
public PrecisionCell _0087_0095_0088 = new PrecisionCell(); // textBoxZ2
public PrecisionCell _0087_0093_0094 = new PrecisionCell(); // textBoxZB
public PrecisionCell _0087_0092_0093 = new PrecisionCell(); // groupBox1
public PrecisionCell _0087_0093_0099 = new PrecisionCell(); // textBoxYC
public PrecisionCell _0087_0093_009A = new PrecisionCell(); // label26
public PrecisionCell _0087_0093_009B = new PrecisionCell(); // textBoxYB
public PrecisionCell _0087_0094_0093 = new PrecisionCell(); // tabControl1
public PrecisionCell _0087_0094_0094 = new PrecisionCell(); // tabPage1
public PrecisionCell _0087_0092_009A = new PrecisionCell(); // radioButtonGPINOP
public PrecisionCell _0087_0094_0095 = new PrecisionCell(); // groupBox3
public PrecisionCell _0087_0094_0097 = new PrecisionCell(); // textBoxZ1
public PrecisionCell _0087_0094_0098 = new PrecisionCell(); // textBoxLat1
public PrecisionCell _0087_0094_0099 = new PrecisionCell(); // textBoxLon1
public PrecisionCell _0087_0094_009A = new PrecisionCell(); // label4
public PrecisionCell _0087_0094_009C = new PrecisionCell(); // Start
public PrecisionCell _0087_0095_009E = new PrecisionCell(); // label14
public PrecisionCell _0087_0096_0086 = new PrecisionCell(); // label9
public PrecisionCell _0087_0094_008E = new PrecisionCell(); // label29
public PrecisionCell _0087_0094_008F = new PrecisionCell(); // label30
public PrecisionCell _0087_0094_0090 = new PrecisionCell(); // label31
public PrecisionCell _0087_0092_009C = new PrecisionCell(); // label17
public PrecisionCell _0087_0095_009C = new PrecisionCell(); // label8
public PrecisionCell _0087_0093_009E = new PrecisionCell(); // textBoxWB
		// R8 MethodDef: original 0x06000308 RVA 0x401EC; processed 0x06000307 RVA 0x3537C; source 03_recovered-src\annotated-strings\--\--.cs:24174; processed IL recovery, not original runtime.
public void _0087_0091_008F()
		{
			OasMode selectedIndex = default(OasMode); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			if (true /* original-file-bool-offset:468 */)
			{
				selectedIndex = (OasMode)_0087_0093_0091.SelectedIndex;
				_0087_0092_008E = new OasModel(selectedIndex);
				_0087_0092_008E._0088_0091_0096._008B_008B_0092 = RecoveryParse.Text(_0087_0093_0098.Text, "输入数据有误，请检查。" );
				_0087_0092_008E._0088_0091_0096._008B_008B_0093 = RecoveryParse.Text(_0087_0093_009E.Text, "输入数据有误，请检查。" );
				_0087_0092_008E._0088_0091_0096._008B_008B_0094 = RecoveryParse.Text(_0087_0094_008A.Text, "输入数据有误，请检查。" );
				if (selectedIndex == (OasMode)2)
				{
					_0087_0092_008E._0088_0091_0097._008B_008B_0092 = RecoveryParse.Text(_0087_0093_009C.Text, "输入数据有误，请检查。" );
					_0087_0092_008E._0088_0091_0097._008B_008B_0093 = RecoveryParse.Text(_0087_0094_0087.Text, "输入数据有误，请检查。" );
					_0087_0092_008E._0088_0091_0097._008B_008B_0094 = RecoveryParse.Text(_0087_0094_008C.Text, "输入数据有误，请检查。" );
				}
				_0087_0092_008E._0088_0091_0098._008B_008B_0092 = RecoveryParse.Text(_0087_0094_008B.Text, "输入数据有误，请检查。" );
				_0087_0092_008E._0088_0091_0098._008B_008B_0093 = RecoveryParse.Text(_0087_0094_0089.Text, "输入数据有误，请检查。" );
				/* opaque discard 1 */
				if (!_00870())
				{
					_0087_0092_008E._0088_0091_0098._008B_008B_0094 = RecoveryParse.Text(_0087_0094_0088.Text, "输入数据有误，请检查。" );
					goto IL_021f;
				}
				goto IL_02c7;
			}
			return;
			IL_02c7:
			do
			{
				_0087_0092_008E._0088_0091_009A._008B_008B_0093 = RecoveryParse.Text(_0087_0093_0094.Text, "输入数据有误，请检查。" );
				_0087_0092_008E._0088_0091_009A._008B_008B_0094 = RecoveryParse.Text(_0087_0093_0093.Text, "输入数据有误，请检查。" );
				_0087_0092_008F = new PaOasGeometry(_0087_0092_008E, RecoveryParse.Cell(_0087_0095_0091, "输入数据有误，请检查。" ));
				_0087_0092_008F._0088_0094_008F = new PlaneCarrier(RecoveryParse.Cell(_0087_0095_0091, "输入数据有误，请检查。" ), RecoveryParse.Cell(_0087_0095_0093, "输入数据有误，请检查。" ), RecoveryParse.Cell(_0087_0095_0094, "输入数据有误，请检查。" ));
			}
			while (!_0087_009F());
			_0087_0092_008F._0088_0094_0090 = new PlaneCarrier(RecoveryParse.Cell(_0087_0095_0096, "输入数据有误，请检查。" ), RecoveryParse.Cell(_0087_0095_0098, "输入数据有误，请检查。" ), RecoveryParse.Cell(_0087_0095_0097, "输入数据有误，请检查。" ));
			_0087_0092_008F._0088_0092_009D();
			if (!_00870())
			{
				num = RecoveryParse.Cell(_0087_0095_009B, "中间段长度输入错误" );
				num2 = RecoveryParse.Cell(_0087_0096_0087, "FAF高度输入错误" );
				num3 = Math.Tan(RecoveryParse.Text(_0087_0093_0090.Text, "GP输入错误" ) * Math.PI / 180.0);
				num4 = RecoveryParse.Cell(_0087_0094_0097, "跑道入口高度输入错误" );
				_0087_0092_0090 = new TemplatePoint((num2 - num4) / num3, 0.0, num2 - num4);
				_0087_0092_0091 = new TemplatePoint(_0087_0092_0090.X + num, 0.0, num2 - num4);
				_0087_0092_008E._0088_0090_0098();
				return;
			}
			goto IL_021f;
			IL_021f:
			_0087_0092_008E._0088_0091_0099._008B_008B_0092 = RecoveryParse.Text(_0087_0093_009D.Text, "输入数据有误，请检查。" );
			_0087_0092_008E._0088_0091_0099._008B_008B_0093 = RecoveryParse.Text(_0087_0093_009B.Text, "输入数据有误，请检查。" );
			_0087_0092_008E._0088_0091_0099._008B_008B_0094 = RecoveryParse.Text(_0087_0093_0099.Text, "输入数据有误，请检查。" );
			_0087_0092_008E._0088_0091_009A._008B_008B_0092 = RecoveryParse.Text(_0087_0093_0095.Text, "输入数据有误，请检查。" );
			goto IL_02c7;
		}
		// R8 MethodDef: original 0x06000309 RVA 0x407C8; processed 0x06000308 RVA 0x357FC; source 03_recovered-src\annotated-strings\--\--.cs:24231; processed IL recovery, not original runtime.
public void _0087_0091_0090(object P_0, EventArgs P_1)
		{

			_00870();
			if ((_0087_009F() && _0087_0092_0094.Checked) || _0087_0092_009B.Checked)
			{
				_0087_0096_0089.Visible = true;
			}
			else
			{
				_0087_0096_0089.Visible = false;
			}
		}
		// R8 MethodDef: original 0x0600030A RVA 0x408A0; processed 0x06000309 RVA 0x3584C; source 03_recovered-src\annotated-strings\--\--.cs:24244; processed IL recovery, not original runtime.
public void _0087_0091_0091(object P_0, EventArgs P_1)
		{
			int num = default(int); // IL InitLocals

			num = 15;
			while (true)
			{
				if (!false /* original-file-bool-offset:472 */)
				{
					if (_0087_0093_0091.SelectedIndex == 0)
					{
						_0087_0093_009C.Visible = false;
						num = 6;
						if (!_0087_009F())
						{
							goto IL_003a;
						}
						goto IL_006d;
					}
					_0087_0093_009C.Visible = true;
					_0087_0094_0087.Visible = true;
					goto IL_016f;
				}
				num = 14;
				return;
				IL_016f:
				_0087_0094_008C.Visible = true;
				num = 13;
				goto IL_0184;
				IL_0184:
				_0087_0092_0097.Enabled = false;
				_0087_0092_0096.Enabled = false;
				_0087_0092_009A.Enabled = false;
				num = 9;
				goto IL_01b1;
				IL_01b1:
				_0087_0092_0094.Enabled = false;
				num = 5;
				goto IL_01c6;
				IL_006d:
				switch (num)
				{
				case 6:
					break;
				case 3:
				case 16:
					goto IL_00c3;
				case 15:
					continue;
				case 10:
					_0087_0092_009A.Enabled = true;
					goto case 11;
				case 11:
					_0087_0092_0094.Enabled = true;
					_0087_0092_009B.Enabled = true;
					num = 1;
					goto case 1;
				case 1:
					_0087_0096_008A.Visible = false;
					goto end_IL_00ed;
				default:
					goto IL_016f;
				case 13:
					goto IL_0184;
				case 9:
					goto IL_01b1;
				case 5:
					goto IL_01c6;
				case 12:
					goto IL_01d2;
				case 0:
					goto IL_01e7;
				case 2:
				case 4:
				case 7:
					goto end_IL_00ed;
				case 14:
				case 17:
					return;
				}
				goto IL_003a;
				IL_003a:
				_0087_0094_0087.Visible = false;
				_0087_0094_008C.Visible = false;
				_0087_009F();
				if (!_00870())
				{
					num = 16;
					goto IL_00c3;
				}
				num = 2;
				break;
				IL_01d2:
				_0087_0092_0095.Checked = true;
				num = 0;
				goto IL_01e7;
				IL_00c3:
				do
				{
					_0087_0092_0097.Enabled = true;
					_0087_0092_0096.Enabled = true;
					num = 10;
				}
				while (_00870());
				goto IL_006d;
				IL_01e7:
				_0087_0096_008A.Visible = true;
				num = 4;
				break;
				IL_01c6:
				_0087_0092_009B.Enabled = false;
				goto IL_01d2;
				continue;
				end_IL_00ed:
				break;
			}
			_0087_0091_0092(null, null);
		}
		// R8 MethodDef: original 0x0600030B RVA 0x40B18; processed 0x0600030A RVA 0x35A60; source 03_recovered-src\annotated-strings\--\--.cs:24361; processed IL recovery, not original runtime.
public void _0087_0091_0092(object P_0, EventArgs P_1)
		{
			double value = default(double); // IL InitLocals
			OasModel obj2 = default(OasModel); // IL InitLocals
			OasMode selectedIndex = default(OasMode); // IL InitLocals
			string obj = default(string); // IL InitLocals
			string text = default(string); // IL InitLocals
			string text2 = default(string); // IL InitLocals

			if (!false /* original-file-bool-offset:476 */)
			{
				value = RecoveryParse.Text(_0087_0093_008C.Text, "输入数据有误，请检查。" );
				if (Convert.ToDouble(value) < 2000.0)
				{
					RecoveryMessages.Show("航向台至跑道入口的距离不得小于2000米。" );
					_0087_0093_008C.Text = "2000" ;
				}
				if (Convert.ToDouble(value) > 4500.0)
				{
					goto IL_00aa;
				}
				goto IL_00cf;
			}
			return;
			IL_00aa:
			RecoveryMessages.Show("航向台至跑道入口的距离不得大于4500米。" );
			_0087_0093_008C.Text = "4500" ;
			goto IL_00cf;
			IL_00cf:
			if (_0087_0093_0091.SelectedIndex == -1)
			{
				return;
			}
			// IL local hoisted
			if (_0087_0093_0089.SelectedIndex != -1)
			{
				if (_0087_0093_0090.SelectedIndex == -1)
				{
					return;
				}
				if (_0087_0092_009D.SelectedIndex == -1)
				{
					if (!_00870())
					{
						return;
					}
					goto IL_00aa;
				}
				selectedIndex = (OasMode)_0087_0093_0091.SelectedIndex;
				obj = _0087_0093_0090.Text;
				text = _0087_0092_009D.Text;
				text2 = _0087_0093_008C.Text;
				obj2 = OasParameters._0088_0090_0094(obj, selectedIndex, text, text2);
			}
			else
			{
				/* opaque discard 1 */
				if (!_00870())
				{
					return;
				}
			}
			if (obj2 != null)
			{
				OasParameters._0088_0090_0096(ref obj2, RecoveryParse.Cell(_0087_0093_0087, "输入数据有误，请检查。" ), RecoveryParse.Cell(_0087_0093_008B, "输入数据有误，请检查。" ));
				OasParameters._0088_0090_0097(ref obj2, RecoveryParse.Cell(_0087_0093_0088, "输入数据有误，请检查。" ));
				obj2._0088_0090_0098();
				_0087_0091_0093(obj2);
			}
		}
		// R8 MethodDef: original 0x0600030C RVA 0x40DA4; processed 0x0600030B RVA 0x35C04; source 03_recovered-src\annotated-strings\--\--.cs:24425; processed IL recovery, not original runtime.
public void _0087_0091_0093(OasModel P_0)
		{
			int num = default(int); // IL InitLocals

			num = 12;
			while (true /* original-file-bool-offset:480 */)
			{
				num = 1;
				while (true)
				{
					_0087_0093_0098.Text = P_0._0088_0091_0096._008B_008B_0092.ToString("F6" );
					_0087_009F();
					if (_00870())
					{
						num = 10;
						goto IL_0254;
					}
					num = 4;
					if (_0087_009F())
					{
						goto IL_00a0;
					}
					goto IL_0171;
					IL_02b1:
					_0087_0093_0095.Text = P_0._0088_0091_009A._008B_008B_0092.ToString("F6" );
					goto IL_02d6;
					IL_02d6:
					_0087_0093_0094.Text = P_0._0088_0091_009A._008B_008B_0093.ToString("F6" );
					_0087_0093_0093.Text = P_0._0088_0091_009A._008B_008B_0094.ToString("F2" );
					return;
					IL_00a0:
					_0087_0093_009E.Text = P_0._0088_0091_0096._008B_008B_0093.ToString("F6" );
					goto IL_00c5;
					IL_00c5:
					_0087_0094_008A.Text = P_0._0088_0091_0096._008B_008B_0094.ToString("F2" );
					goto IL_00ea;
					IL_00ea:
					_0087_0093_009C.Text = P_0._0088_0091_0097._008B_008B_0092.ToString("F6" );
					_0087_0094_0087.Text = P_0._0088_0091_0097._008B_008B_0093.ToString("F6" );
					_0087_0094_008C.Text = P_0._0088_0091_0097._008B_008B_0094.ToString("F2" );
					num = 11;
					if (_0087_009F())
					{
						goto IL_005a;
					}
					goto IL_02b1;
					IL_005a:
					switch (num)
					{
					case 1:
						break;
					case 2:
					case 4:
						goto IL_00a0;
					case 8:
						goto IL_00c5;
					case 6:
						goto IL_00ea;
					case 9:
						goto IL_0171;
					default:
						num = 3;
						if (_0087_009F())
						{
						}
						goto case 3;
					case 11:
						_0087_0094_008B.Text = P_0._0088_0091_0098._008B_008B_0092.ToString("F6" );
						goto case 3;
					case 3:
						_0087_0094_0089.Text = P_0._0088_0091_0098._008B_008B_0093.ToString("F6" );
						goto IL_0254;
					case 7:
					case 10:
						goto IL_0254;
					case 12:
						goto end_IL_0017;
					case 0:
						goto IL_02b1;
					case 5:
						goto IL_02d6;
					case 13:
						return;
					}
					continue;
					IL_0254:
					_0087_0094_0088.Text = P_0._0088_0091_0098._008B_008B_0094.ToString("F2" );
					num = 9;
					goto IL_0171;
					IL_0171:
					_0087_0093_009D.Text = P_0._0088_0091_0099._008B_008B_0092.ToString("F6" );
					_0087_0093_009B.Text = P_0._0088_0091_0099._008B_008B_0093.ToString("F6" );
					_0087_0093_0099.Text = P_0._0088_0091_0099._008B_008B_0094.ToString("F2" );
					num = 0;
					if (!_00870())
					{
						goto IL_005a;
					}
					goto IL_00ea;
					continue;
					end_IL_0017:
					break;
				}
			}
		}
		// R8 MethodDef: original 0x0600030D RVA 0x41110; processed 0x0600030C RVA 0x35F34; source 03_recovered-src\annotated-strings\--\--.cs:24529; processed IL recovery, not original runtime.
public void _0087_0091_0094(object P_0, EventArgs P_1)
		{
			string text = default(string); // IL InitLocals
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			if (false /* original-file-bool-offset:484 */)
			{
				return;
			}
			text = _0087_0093_0089.Text;
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				num = 0.0;
				num2 = 0.0;
				if (!(text == "A" ) && !(text == "B" ))
				{
					if (!(text == "C" ))
					{
						/* opaque discard 1 */
						if (_00870())
						{
							if (!_00870())
							{
								break;
							}
							continue;
						}
						if (_00870())
						{
							goto IL_00e1;
						}
						if (!(text == "D" ))
						{
							if (text == "DL" )
							{
								num = 40.0;
								num2 = 8.0;
							}
							break;
						}
					}
					num = 32.5;
					num2 = 7.0;
					break;
				}
				num = 30.0;
				goto IL_00e1;
				IL_00e1:
				num2 = 6.0;
				break;
			}
			_0087_0093_0087.Text = num.ToString();
			_0087_0093_008B.Text = num2.ToString();
			_0087_0091_0092(null, null);
		}
		// R8 MethodDef: original 0x0600030E RVA 0x4134C; processed 0x0600030D RVA 0x36058; source 03_recovered-src\annotated-strings\--\--.cs:24584; processed IL recovery, not original runtime.
public void _0087_0091_0095(object P_0, EventArgs P_1)
		{
			double num = default(double); // IL InitLocals

			/* opaque discard 0 */
			// IL local hoisted
			if (_0087_009F())
			{
				num = Math.Round(Math.Tan(RecoveryParse.Text(_0087_0093_0090.Text, "输入数据有误，请检查。" ) * Math.PI / 180.0), 4);
			}
			_0087_0095_0091.Text = num.ToString("f4" );
			_0087_0091_0092(null, null);
		}
		// R8 MethodDef: original 0x06000314 RVA 0x41498; processed 0x06000313 RVA 0x360D0; source 03_recovered-src\annotated-strings\--\--.cs:24621; processed IL recovery, not original runtime.
public void _0087_0091_009B(object P_0, EventArgs P_1)
		{
			string text = default(string); // IL InitLocals

			// IL local hoisted
			if (!_00870())
			{
				text = _0087_0094_0099.Text;
				_0087_0094_0099.Text = _0087_0095_008B.Text;
				goto IL_0029;
			}
			goto IL_0042;
			IL_0042:
			_0087_0094_0097.Text = _0087_0095_0088.Text;
			_0087_0095_0088.Text = text;
			if (_00870())
			{
				goto IL_0029;
			}
			return;
			IL_0029:
			_0087_0095_008B.Text = text;
			_0087_009F();
			if (!_00870())
			{
				text = _0087_0094_0098.Text;
				_0087_0094_0098.Text = _0087_0095_0089.Text;
				_0087_0095_0089.Text = text;
				text = _0087_0094_0097.Text;
			}
			goto IL_0042;
		}
		// R8 MethodDef: original 0x0600031A RVA 0x41DD0; processed 0x06000319 RVA 0x36594; source 03_recovered-src\annotated-strings\--\--.cs:24808; processed IL recovery, not original runtime.
public string _0087_0092_0088()
		{
			int num = default(int); // IL InitLocals
			string text = default(string); // IL InitLocals
			string text2 = default(string); // IL InitLocals
			string text3 = default(string); // IL InitLocals
			string text4 = default(string); // IL InitLocals
			Dictionary<string, object> obj4 = default(Dictionary<string, object>); // IL InitLocals

			try
			{
				Dictionary<string, object> obj = new Dictionary<string, object>
				{
					{"THR", new Dictionary<string, double>
					{
						{"X", RecoveryParse.Cell(_0087_0094_0099, "输入数据有误，请检查。" )},
						{"Y", RecoveryParse.Cell(_0087_0094_0098, "输入数据有误，请检查。" )},
						{"Z", RecoveryParse.Cell(_0087_0094_0097, "输入数据有误，请检查。" )}}},
					{"DER", new Dictionary<string, double>
					{
						{"X", RecoveryParse.Cell(_0087_0095_008B, "输入数据有误，请检查。" )},
						{"Y", RecoveryParse.Cell(_0087_0095_0089, "输入数据有误，请检查。" )},
						{"Z", RecoveryParse.Cell(_0087_0095_0088, "输入数据有误，请检查。" )}}}};
				num = 4;
				// IL local hoisted
				// IL local hoisted
				// IL local hoisted
				// IL local hoisted
				// IL local hoisted
				while (true)
				{
					Dictionary<string, object> obj2 = new Dictionary<string, object>
					{
						{"AppType", _0087_0093_0091.Text},
						{"CAT", _0087_0093_0089.Text},
						{"GP", _0087_0093_0090.Text},
						{"MissedCG", _0087_0092_009D.Text},
						{"LocDistance", _0087_0093_008C.Text},
						{"RDH", RecoveryParse.Cell(_0087_0093_0088, "输入数据有误，请检查。" )},
						{"WingSpan", RecoveryParse.Cell(_0087_0093_0087, "输入数据有误，请检查。" )},
						{"WheelBase", RecoveryParse.Cell(_0087_0093_008B, "输入数据有误，请检查。" )},
						{"FAF_Height", RecoveryParse.Cell(_0087_0096_0087, "输入数据有误，请检查。" )},
						{"IF_Length", RecoveryParse.Cell(_0087_0095_009B, "输入数据有误，请检查。" )},
						{"FAF_Tolerance", RecoveryParse.Cell(_0087_0095_009D, "输入数据有误，请检查。" )}};
					num = 5;
					while (true)
					{
						Dictionary<string, object> obj3 = new Dictionary<string, object>
						{
							{"P1", new Dictionary<string, double>
							{
								{"a", RecoveryParse.Cell(_0087_0095_0091, "输入数据有误，请检查。" )},
								{"b", RecoveryParse.Cell(_0087_0095_0093, "输入数据有误，请检查。" )},
								{"c", RecoveryParse.Cell(_0087_0095_0094, "输入数据有误，请检查。" )}}},
							{"P2", new Dictionary<string, double>
							{
								{"a", RecoveryParse.Cell(_0087_0095_0096, "输入数据有误，请检查。" )},
								{"b", RecoveryParse.Cell(_0087_0095_0098, "输入数据有误，请检查。" )},
								{"c", RecoveryParse.Cell(_0087_0095_0097, "输入数据有误，请检查。" )}}}};
						while (true)
						{
							_00870();
							if (!_0087_009F())
							{
								num = 1;
								if (_00870())
								{
									goto IL_041f;
								}
							}
							else
							{
								num = 0;
								if (!_0087_009F())
								{
									break;
								}
							}
							switch (num)
							{
							case 5:
								goto end_IL_011d;
							case 4:
								goto end_IL_0175;
							case 0:
							case 2:
								goto IL_041f;
							case 1:
							case 3:
								goto IL_06b9;
							case 6:
								goto IL_06ea;
							}
							continue;
							IL_06b9:
							JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
							text = javaScriptSerializer.Serialize(obj);
							text2 = javaScriptSerializer.Serialize(obj2);
							text3 = javaScriptSerializer.Serialize(obj3);
							text4 = javaScriptSerializer.Serialize(obj4);
							num = 6;
							goto IL_06ea;
							IL_06ea:
							return "RUNWAY:"  + text + "|APPROACH:"  + text2 + "|PAOAS:"  + text3 + "|OAS:"  + text4;
							IL_041f:
							obj4 = new Dictionary<string, object>
							{
								{"W", new Dictionary<string, double>
								{
									{"a", RecoveryParse.Cell(_0087_0093_0098, "输入数据有误，请检查。" )},
									{"b", RecoveryParse.Cell(_0087_0093_009E, "输入数据有误，请检查。" )},
									{"c", RecoveryParse.Cell(_0087_0094_008A, "输入数据有误，请检查。" )}}},
								{"Ws", new Dictionary<string, double>
								{
									{"a", RecoveryParse.Cell(_0087_0093_009C, "输入数据有误，请检查。" )},
									{"b", RecoveryParse.Cell(_0087_0094_0087, "输入数据有误，请检查。" )},
									{"c", RecoveryParse.Cell(_0087_0094_008C, "输入数据有误，请检查。" )}}},
								{"X", new Dictionary<string, double>
								{
									{"a", RecoveryParse.Cell(_0087_0094_008B, "输入数据有误，请检查。" )},
									{"b", RecoveryParse.Cell(_0087_0094_0089, "输入数据有误，请检查。" )},
									{"c", RecoveryParse.Cell(_0087_0094_0088, "输入数据有误，请检查。" )}}},
								{"Y", new Dictionary<string, double>
								{
									{"a", RecoveryParse.Cell(_0087_0093_009D, "输入数据有误，请检查。" )},
									{"b", RecoveryParse.Cell(_0087_0093_009B, "输入数据有误，请检查。" )},
									{"c", RecoveryParse.Cell(_0087_0093_0099, "输入数据有误，请检查。" )}}},
								{"Z", new Dictionary<string, double>
								{
									{"a", RecoveryParse.Cell(_0087_0093_0095, "输入数据有误，请检查。" )},
									{"b", RecoveryParse.Cell(_0087_0093_0094, "输入数据有误，请检查。" )},
									{"c", RecoveryParse.Cell(_0087_0093_0093, "输入数据有误，请检查。" )}}}};
							goto IL_06b9;
							continue;
							end_IL_011d:
							break;
						}
						continue;
						end_IL_0175:
						break;
					}
				}
			}
			catch (Exception ex)
			{
				RecoveryMessages.Show("\nOAS参数序列化失败: "  + ex.Message);
				return "";
			}
		}
		// R8 MethodDef: original 0x0600031B RVA 0x4259C; processed 0x0600031A RVA 0x36D38; source 03_recovered-src\annotated-strings\--\--.cs:24964; processed IL recovery, not original runtime.
public void _0087_0092_0089(string P_0, bool P_1 = true)
		{
			int num = default(int); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			int num3 = default(int); // IL InitLocals
			string text = default(string); // IL InitLocals
			Dictionary<string, object> dictionary2 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary3 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary4 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary5 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary6 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary7 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary8 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary9 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary10 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary11 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary12 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary13 = default(Dictionary<string, object>); // IL InitLocals
			Dictionary<string, object> dictionary14 = default(Dictionary<string, object>); // IL InitLocals
			string[] array = default(string[]); // IL InitLocals
			Dictionary<string, string> dictionary = default(Dictionary<string, string>); // IL InitLocals
			string[] array2 = default(string[]); // IL InitLocals
			string key = default(string); // IL InitLocals
			string value = default(string); // IL InitLocals

			if (false /* original-file-bool-offset:492 */)
			{
				return;
			}
			try
			{
				// IL local hoisted
				if (string.IsNullOrEmpty(P_0))
				{
					num = 8;
				}
				else
				{
					JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
					num = 47;
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					// IL local hoisted
					while (true)
					{
						IL_09e6:
						array = P_0.Split('|');
						dictionary = new Dictionary<string, string>();
						array2 = array;
						num = 7;
						if (_00870())
						{
							goto IL_052d;
						}
						goto IL_09cf;
						IL_09cf:
						num2 = 0;
						num = 50;
						if (_0087_009F())
						{
							goto IL_0228;
						}
						goto IL_09c5;
						IL_09c5:
						if (num3 > 0)
						{
							key = text.Substring(0, num3);
							value = text.Substring(num3 + 1);
							dictionary[key] = value;
						}
						num2++;
						num = 32;
						goto IL_0970;
						IL_0c93:
						if (dictionary2.ContainsKey("Y" ))
						{
							dictionary3 = (Dictionary<string, object>)dictionary2["Y" ];
							num = 20;
							goto IL_0cca;
						}
						goto IL_0d6f;
						IL_05db:
						if (dictionary4.ContainsKey("WingSpan" ))
						{
							_0087_0093_0087.Text = Convert.ToDouble(dictionary4["WingSpan" ]).ToString("F2" );
							num = 13;
						}
						goto IL_062b;
						IL_0970:
						if (num2 >= array2.Length)
						{
							if (P_1 && dictionary.ContainsKey("RUNWAY" ))
							{
								dictionary5 = javaScriptSerializer.Deserialize<Dictionary<string, object>>(dictionary["RUNWAY" ]);
								if (dictionary5.ContainsKey("THR" ))
								{
									num = 27;
									goto IL_07ac;
								}
								goto IL_087c;
							}
							goto IL_0968;
						}
						text = array2[num2];
						num = 3;
						goto IL_0987;
						IL_062b:
						if (!dictionary4.ContainsKey("WheelBase" ))
						{
							goto IL_0685;
						}
						num = 18;
						if (_0087_009F())
						{
							goto IL_0651;
						}
						goto IL_0b24;
						IL_0dda:
						_0087_0093_0094.Text = Convert.ToDouble(dictionary6["b" ]).ToString("F6" );
						num = 54;
						goto IL_0e17;
						IL_0651:
						_0087_0093_008B.Text = Convert.ToDouble(dictionary4["WheelBase" ]).ToString("F2" );
						goto IL_0685;
						IL_0685:
						if (dictionary4.ContainsKey("FAF_Height" ))
						{
							_0087_0096_0087.Text = Convert.ToDouble(dictionary4["FAF_Height" ]).ToString("F2" );
						}
						if (dictionary4.ContainsKey("IF_Length" ))
						{
							num = 14;
							goto IL_06e8;
						}
						goto IL_0725;
						IL_0d32:
						_0087_0093_0099.Text = Convert.ToDouble(dictionary3["c" ]).ToString("F2" );
						num = 40;
						goto IL_0d6f;
						IL_0968:
						if (P_1)
						{
							num = 25;
							goto IL_01f5;
						}
						goto IL_07a4;
						IL_0cca:
						_0087_0093_009D.Text = Convert.ToDouble(dictionary3["a" ]).ToString("F6" );
						_0087_0093_009B.Text = Convert.ToDouble(dictionary3["b" ]).ToString("F6" );
						goto IL_0d32;
						IL_07a4:
						if (!P_1 || !dictionary.ContainsKey("PAOAS" ))
						{
							goto IL_0513;
						}
						num = 24;
						if (_0087_009F())
						{
							goto IL_0345;
						}
						goto IL_0aed;
						IL_0d6f:
						if (dictionary2.ContainsKey("Z" ))
						{
							num = 9;
							goto IL_0d8e;
						}
						return;
						IL_0987:
						num3 = text.IndexOf(':');
						num = 38;
						goto IL_09c5;
						IL_0513:
						if (dictionary.ContainsKey("OAS" ))
						{
							num = 22;
							goto IL_0312;
						}
						return;
						IL_06e8:
						_0087_0095_009B.Text = Convert.ToDouble(dictionary4["IF_Length" ]).ToString("F2" );
						num = 5;
						goto IL_0725;
						IL_0312:
						dictionary2 = javaScriptSerializer.Deserialize<Dictionary<string, object>>(dictionary["OAS" ]);
						if (dictionary2.ContainsKey("W" ))
						{
							dictionary7 = (Dictionary<string, object>)dictionary2["W" ];
							num = 44;
							if (!_00870())
							{
								goto IL_0228;
							}
							goto IL_06e8;
						}
						goto IL_0aed;
						IL_0725:
						if (dictionary4.ContainsKey("FAF_Tolerance" ))
						{
							num = 37;
							goto IL_0741;
						}
						goto IL_07a4;
						IL_0228:
						while (true)
						{
							switch (num)
							{
							case 53:
								break;
							case 41:
								goto IL_0114;
							case 45:
								goto IL_0127;
							case 39:
								goto IL_0151;
							case 23:
								goto IL_018e;
							case 49:
								goto IL_01b9;
							case 25:
								goto IL_01f5;
							default:
								num = 46;
								if (_0087_009F())
								{
									continue;
								}
								goto IL_0127;
							case 22:
								goto IL_0312;
							case 24:
								goto IL_0345;
							case 29:
								goto IL_037c;
							case 31:
								goto IL_03c8;
							case 43:
								goto IL_0430;
							case 48:
								goto IL_0446;
							case 15:
							case 35:
								goto IL_046e;
							case 21:
								goto IL_04a2;
							case 6:
								goto IL_04df;
							case 30:
								goto IL_052d;
							case 28:
								goto IL_0557;
							case 26:
								goto IL_058b;
							case 2:
								goto IL_05db;
							case 13:
								goto IL_062b;
							case 18:
								goto IL_0651;
							case 46:
								goto IL_0685;
							case 14:
								goto IL_06e8;
							case 5:
								goto IL_0725;
							case 37:
								goto IL_0741;
							case 27:
								goto IL_07ac;
							case 11:
								goto IL_07d7;
							case 17:
								goto IL_0814;
							case 51:
								goto IL_08b3;
							case 10:
								goto IL_0924;
							case 32:
							case 50:
								goto IL_0970;
							case 3:
								goto IL_0987;
							case 38:
								goto IL_09c5;
							case 7:
								goto IL_09cf;
							case 47:
								goto IL_09e6;
							case 8:
								goto end_IL_09e6;
							case 16:
								return;
							case 44:
								_0087_0093_0098.Text = Convert.ToDouble(dictionary7["a" ]).ToString("F6" );
								_0087_0093_009E.Text = Convert.ToDouble(dictionary7["b" ]).ToString("F6" );
								num = 52;
								goto IL_0ab0;
							case 52:
								goto IL_0ab0;
							case 34:
								goto IL_0aed;
							case 0:
							case 42:
								goto IL_0b03;
							case 33:
								goto IL_0b24;
							case 12:
								goto IL_0b61;
							case 36:
								goto IL_0bc9;
							case 1:
								goto IL_0c5f;
							case 20:
								goto IL_0cca;
							case 19:
								goto IL_0d32;
							case 40:
								goto IL_0d6f;
							case 9:
								goto IL_0d8e;
							case 4:
								goto IL_0dda;
							case 54:
								goto IL_0e17;
							}
							break;
						}
						goto IL_00e0;
						IL_07ac:
						dictionary8 = (Dictionary<string, object>)dictionary5["THR" ];
						num = 11;
						if (!_00870())
						{
							goto IL_07d7;
						}
						goto IL_0ab0;
						IL_07d7:
						_0087_0094_0099.Text = Convert.ToDouble(dictionary8["X" ]).ToString("F2" );
						num = 17;
						goto IL_0814;
						IL_0814:
						_0087_0094_0098.Text = Convert.ToDouble(dictionary8["Y" ]).ToString("F2" );
						_0087_0094_0097.Text = Convert.ToDouble(dictionary8["Z" ]).ToString("F2" );
						goto IL_087c;
						IL_087c:
						if (dictionary5.ContainsKey("DER" ))
						{
							dictionary9 = (Dictionary<string, object>)dictionary5["DER" ];
							num = 51;
							goto IL_08b3;
						}
						goto IL_0968;
						IL_0e17:
						_0087_0093_0093.Text = Convert.ToDouble(dictionary6["c" ]).ToString("F2" );
						return;
						IL_08b3:
						_0087_0095_008B.Text = Convert.ToDouble(dictionary9["X" ]).ToString("F2" );
						_0087_0095_0089.Text = Convert.ToDouble(dictionary9["Y" ]).ToString("F2" );
						num = 10;
						goto IL_0924;
						IL_0924:
						_0087_0095_0088.Text = Convert.ToDouble(dictionary9["Z" ]).ToString("F2" );
						goto IL_0968;
						IL_0ab0:
						_0087_0094_008A.Text = Convert.ToDouble(dictionary7["c" ]).ToString("F2" );
						num = 34;
						goto IL_0aed;
						IL_052d:
						_0087_0092_009D.Text = dictionary4["MissedCG" ].ToString();
						num = 28;
						goto IL_0557;
						IL_0345:
						dictionary10 = javaScriptSerializer.Deserialize<Dictionary<string, object>>(dictionary["PAOAS" ]);
						if (dictionary10.ContainsKey("P1" ))
						{
							num = 29;
							goto IL_037c;
						}
						goto IL_0430;
						IL_0741:
						_0087_0095_009D.Text = Convert.ToDouble(dictionary4["FAF_Tolerance" ]).ToString("F2" );
						goto IL_07a4;
						IL_037c:
						dictionary11 = (Dictionary<string, object>)dictionary10["P1" ];
						_0087_0095_0091.Text = Convert.ToDouble(dictionary11["a" ]).ToString("F4" );
						goto IL_03c8;
						IL_03c8:
						_0087_0095_0093.Text = Convert.ToDouble(dictionary11["b" ]).ToString("F4" );
						_0087_0095_0094.Text = Convert.ToDouble(dictionary11["c" ]).ToString("F2" );
						goto IL_0430;
						IL_0430:
						if (dictionary10.ContainsKey("P2" ))
						{
							goto IL_0446;
						}
						goto IL_0513;
						IL_0446:
						dictionary12 = (Dictionary<string, object>)dictionary10["P2" ];
						_0087_009F();
						if (!_00870())
						{
							goto IL_046e;
						}
						num = 0;
						goto IL_0b03;
						IL_046e:
						_0087_0095_0096.Text = Convert.ToDouble(dictionary12["a" ]).ToString("F4" );
						goto IL_04a2;
						IL_04a2:
						_0087_0095_0098.Text = Convert.ToDouble(dictionary12["b" ]).ToString("F4" );
						num = 6;
						goto IL_04df;
						IL_04df:
						_0087_0095_0097.Text = Convert.ToDouble(dictionary12["c" ]).ToString("F2" );
						goto IL_0513;
						IL_0aed:
						if (dictionary2.ContainsKey("Ws" ))
						{
							goto IL_0b03;
						}
						goto IL_0bc9;
						IL_01f5:
						if (dictionary.ContainsKey("APPROACH" ))
						{
							num = 49;
							goto IL_01b9;
						}
						goto IL_07a4;
						IL_0b03:
						dictionary13 = (Dictionary<string, object>)dictionary2["Ws" ];
						num = 33;
						goto IL_0b24;
						IL_01b9:
						dictionary4 = javaScriptSerializer.Deserialize<Dictionary<string, object>>(dictionary["APPROACH" ]);
						if (dictionary4.ContainsKey("AppType" ))
						{
							num = 53;
							goto IL_00e0;
						}
						goto IL_0114;
						IL_0b24:
						_0087_0093_009C.Text = Convert.ToDouble(dictionary13["a" ]).ToString("F6" );
						num = 12;
						goto IL_0b61;
						IL_00e0:
						_0087_0093_0091.Text = dictionary4["AppType" ].ToString();
						num = 41;
						if (_0087_009F())
						{
							goto IL_0114;
						}
						goto IL_0987;
						IL_0114:
						if (dictionary4.ContainsKey("CAT" ))
						{
							goto IL_0127;
						}
						goto IL_0151;
						IL_0127:
						_0087_0093_0089.Text = dictionary4["CAT" ].ToString();
						num = 39;
						goto IL_0151;
						IL_0151:
						if (dictionary4.ContainsKey("GP" ))
						{
							_0087_0093_0090.Text = dictionary4["GP" ].ToString();
							num = 23;
						}
						goto IL_018e;
						IL_0b61:
						_0087_0094_0087.Text = Convert.ToDouble(dictionary13["b" ]).ToString("F6" );
						_0087_0094_008C.Text = Convert.ToDouble(dictionary13["c" ]).ToString("F2" );
						goto IL_0bc9;
						IL_018e:
						if (!dictionary4.ContainsKey("MissedCG" ))
						{
							goto IL_0557;
						}
						num = 30;
						if (_0087_009F())
						{
							goto IL_0228;
						}
						goto IL_0970;
						IL_0bc9:
						if (dictionary2.ContainsKey("X" ))
						{
							dictionary14 = (Dictionary<string, object>)dictionary2["X" ];
							_0087_0094_008B.Text = Convert.ToDouble(dictionary14["a" ]).ToString("F6" );
							_0087_0094_0089.Text = Convert.ToDouble(dictionary14["b" ]).ToString("F6" );
							goto IL_0c5f;
						}
						goto IL_0c93;
						IL_0557:
						if (dictionary4.ContainsKey("LocDistance" ))
						{
							_0087_0093_008C.Text = dictionary4["LocDistance" ].ToString();
						}
						goto IL_058b;
						IL_0d8e:
						dictionary6 = (Dictionary<string, object>)dictionary2["Z" ];
						_0087_0093_0095.Text = Convert.ToDouble(dictionary6["a" ]).ToString("F6" );
						goto IL_0dda;
						IL_058b:
						if (dictionary4.ContainsKey("RDH" ))
						{
							_0087_0093_0088.Text = Convert.ToDouble(dictionary4["RDH" ]).ToString("F2" );
							num = 2;
						}
						goto IL_05db;
						IL_0c5f:
						_0087_0094_0088.Text = Convert.ToDouble(dictionary14["c" ]).ToString("F2" );
						goto IL_0c93;
						continue;
						end_IL_09e6:
						break;
					}
				}
				RecoveryMessages.Show("JSON数据为空。" );
				num = 16;
			}
			catch (Exception ex)
			{
				RecoveryMessages.Show("读取OAS参数失败："  + ex.Message);
			}
		}
internal static bool _0087_009F(){return true;}
internal static bool _00870(){return false;}
}

}
