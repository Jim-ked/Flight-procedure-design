using System;
using System.Collections.Generic;
using System.Linq;
using Recovered.A6;
using Recovered.B5;
// E1/E2 recovery. No target DLL or AutoCAD runtime. Original branches retained.
namespace Recovered.B4 {
public class PbnIlsForm {
public RecoveryCell _0089_0098_0096 = new RecoveryCell(); // label19
public RecoveryCell _0089_0098_008E = new RecoveryCell(); // tabControl1
public RecoveryCell _0089_0098_008F = new RecoveryCell(); // tabPage1
public RecoveryCell _0089_009A_0098 = new RecoveryCell(); // label24
public RecoveryCell _0089_009A_009C = new RecoveryCell(); // textBoxWing
public RecoveryCell _0089_009A_0099 = new RecoveryCell(); // textBoxRDH
public RecoveryCell _0089_009A_008F = new RecoveryCell(); // comboBoxCat
public RecoveryCell _0089_009A_0090 = new RecoveryCell(); // label11
public RecoveryCell _0089_009A_009D = new RecoveryCell(); // textBoxWheel
public RecoveryCell _0089_009A_0091 = new RecoveryCell(); // LocDistance
public RecoveryCell _0089_0097_009C = new RecoveryCell(); // button5
public RecoveryCell _0089_0099_0090 = new RecoveryCell(); // textBoxYB
public RecoveryCell _0089_0099_0091 = new RecoveryCell(); // textBoxWsA
public RecoveryCell _0089_009A_0086 = new RecoveryCell(); // checkBoxShowOas
public RecoveryCell _0089_0099_0094 = new RecoveryCell(); // label10
public RecoveryCell _0089_0099_008E = new RecoveryCell(); // textBoxYC
public RecoveryCell _0089_0099_008F = new RecoveryCell(); // label26
public RecoveryCell _0089_0099_0098 = new RecoveryCell(); // textBoxWC
public RecoveryCell _0089_0099_0099 = new RecoveryCell(); // textBoxXA
public RecoveryCell _0089_0099_008A = new RecoveryCell(); // textBoxZA
public RecoveryCell _0089_0099_008B = new RecoveryCell(); // label27
public RecoveryCell _0089_0099_0097 = new RecoveryCell(); // textBoxXB
public RecoveryCell _0089_0099_008C = new RecoveryCell(); // label8
public RecoveryCell _0089_0099_008D = new RecoveryCell(); // textBoxWA
public RecoveryCell _0089_009A_008C = new RecoveryCell(); // textBoxLGT
public RecoveryCell _0089_009B_0086 = new RecoveryCell(); // button10
public RecoveryCell _0089_0098_0087 = new RecoveryCell(); // button4
public RecoveryCell _0089_0097_0099 = new RecoveryCell(); // textBoxLat1
public RecoveryCell _0089_0097_009A = new RecoveryCell(); // textBoxLon1
public RecoveryCell _0089_0098_009C = new RecoveryCell(); // textBoxHLm
public RecoveryCell _0089_009A_008B = new RecoveryCell(); // label14
public RecoveryCell _0089_009B_0088 = new RecoveryCell(); // textBox1
public RecoveryCell _0089_009B_0089 = new RecoveryCell(); // label28
public RecoveryCell _0089_0099_0087 = new RecoveryCell(); // buttonLoad
public RecoveryCell _0089_0098_008B = new RecoveryCell(); // textBoxLon2
public RecoveryCell _0089_009A_009B = new RecoveryCell(); // label18
public RecoveryCell _0089_0098_008C = new RecoveryCell(); // label4
public RecoveryCell _0089_0098_008D = new RecoveryCell(); // label7
public RecoveryCell _0089_0099_0093 = new RecoveryCell(); // textBoxWB
public RecoveryCell _0089_0098_009B = new RecoveryCell(); // textBoxHLr
public RecoveryCell _0089_0097_0094 = new RecoveryCell(); // buttonAix
public RecoveryCell _0089_009A_009A = new RecoveryCell(); // comboBoxMissCG
public RecoveryCell _0089_0098_009A = new RecoveryCell(); // textBoxHLcor
public RecoveryCell _0089_0099_0095 = new RecoveryCell(); // textBoxWsB
public RecoveryCell _0089_0099_0096 = new RecoveryCell(); // textBoxXC
public RecoveryCell _0089_009A_008A = new RecoveryCell(); // textBoxFAF
public RecoveryCell _0089_009A_008D = new RecoveryCell(); // label13
public RecoveryCell _0089_009A_008E = new RecoveryCell(); // textBoxAdElev
public RecoveryCell _0089_0097_0092 = new RecoveryCell(); // button6
public RecoveryCell _0089_0097_009B = new RecoveryCell(); // label2
public RecoveryCell _0089_0098_008A = new RecoveryCell(); // label9
public RecoveryCell _0089_0099_0086 = new RecoveryCell(); // label6
public RecoveryCell _0089_009A_0089 = new RecoveryCell(); // label12
public RecoveryCell _0089_009A_0092 = new RecoveryCell(); // label16
public RecoveryCell _0089_0099_009A = new RecoveryCell(); // textBoxWsC
public RecoveryCell _0089_0098_0090 = new RecoveryCell(); // tabPage2
public RecoveryCell _0089_0098_0095 = new RecoveryCell(); // comboCat
public RecoveryCell _0089_0099_0092 = new RecoveryCell(); // textBoxYA
public RecoveryCell _0089_0098_0088 = new RecoveryCell(); // textBoxZ2
public RecoveryCell _0089_0097_009D = new RecoveryCell(); // Start
public RecoveryCell _0089_0097_009E = new RecoveryCell(); // label1
public RecoveryCell _0089_0099_0088 = new RecoveryCell(); // textBoxZC
public RecoveryCell _0089_0099_0089 = new RecoveryCell(); // textBoxZB
public RecoveryCell _0089_009B_0087 = new RecoveryCell(); // button18
public RecoveryCell _0089_0098_0097 = new RecoveryCell(); // label20
public RecoveryCell _0089_0098_0092 = new RecoveryCell(); // textBoxElev
public RecoveryCell _0089_0098_0098 = new RecoveryCell(); // label29
public RecoveryCell _0089_0098_0099 = new RecoveryCell(); // label30
public RecoveryCell _0089_0098_0093 = new RecoveryCell(); // label15
public RecoveryCell _0089_009A_009E = new RecoveryCell(); // label17
public RecoveryCell _0089_0098_009D = new RecoveryCell(); // label3
public RecoveryCell _0089_0098_009E = new RecoveryCell(); // label5
public RecoveryCell _0089_0099_009B = new RecoveryCell(); // label25
public RecoveryCell _0089_0097_008F = new RecoveryCell(); // statusStrip1
public RecoveryCell _0089_0097_0090 = new RecoveryCell(); // toolStripStatusLabel1
public RecoveryCell _0089_0097_0091 = new RecoveryCell(); // button8
public RecoveryCell _0089_0097_0093 = new RecoveryCell(); // dataGridView1
public RecoveryCell _0089_0097_0097 = new RecoveryCell(); // groupBox1
public RecoveryCell _0089_0097_0098 = new RecoveryCell(); // textBoxZ1
public RecoveryCell _0089_0098_0086 = new RecoveryCell(); // groupBox2
public RecoveryCell _0089_0098_0091 = new RecoveryCell(); // tabPage3
public RecoveryCell _0089_0098_0094 = new RecoveryCell(); // groupBox11
public RecoveryCell _0089_0099_009E = new RecoveryCell(); // button7
public RecoveryCell _0089_0098_0089 = new RecoveryCell(); // textBoxLat2
public RecoveryCell _0089_009A_0093 = new RecoveryCell(); // label21
public RecoveryCell _0089_009A_0094 = new RecoveryCell(); // label22
public RecoveryCell _0089_009A_0095 = new RecoveryCell(); // comboBoxGP
public RecoveryCell _0089_009A_0096 = new RecoveryCell(); // comboBoxAppType
public RecoveryCell _0089_009A_0097 = new RecoveryCell(); // label23
public RecoveryCell _0089_0099_009C = new RecoveryCell(); // button1
public RecoveryCell _0089_0099_009D = new RecoveryCell(); // button2
public RecoveryCell _0089_0097_0095 = new RecoveryCell(); // button3
public RecoveryCell _0089_0097_0096 = new RecoveryCell(); // buttonEvl
public RecoveryCell _0089_009A_0088 = new RecoveryCell(); // groupBox3
public double[,] _0089_0097_008D = new double[,]{{40,13},{43,18},{46,22},{49,26}};
// R7 MethodDef: original 0x0600055E RVA 0x8ABAC; processed 0x0600055D RVA 0x7123C; source 03_recovered-src\annotated-strings\--\--.cs:61094; processed IL recovery, not original runtime.
public void _0089_0095_009B(PbnIlsTurn P_0)
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			/* opaque discard 0 */
			if (_0088_009D())
			{
				if (!true /* original-file-bool-offset:1060 */)
				{
					return;
				}
				P_0._008A_008B_0090._008B_008B_0092 = RecoveryParse.Text(_0089_0099_008D.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
				P_0._008A_008B_0090._008B_008B_0093 = RecoveryParse.Text(_0089_0099_0093.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
				P_0._008A_008B_0090._008B_008B_0094 = RecoveryParse.Text(_0089_0099_0098.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
				P_0._008A_008B_0091._008B_008B_0092 = RecoveryParse.Text(_0089_0099_0099.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
				P_0._008A_008B_0091._008B_008B_0093 = RecoveryParse.Text(_0089_0099_0097.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			}
			P_0._008A_008B_0091._008B_008B_0094 = RecoveryParse.Text(_0089_0099_0096.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			P_0._008A_008B_0092._008B_008B_0092 = RecoveryParse.Text(_0089_0099_0092.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			P_0._008A_008B_0092._008B_008B_0093 = RecoveryParse.Text(_0089_0099_0090.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			P_0._008A_008B_0092._008B_008B_0094 = RecoveryParse.Text(_0089_0099_008E.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			P_0._008A_008B_0093._008B_008B_0092 = RecoveryParse.Text(_0089_0099_008A.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			P_0._008A_008B_0093._008B_008B_0093 = RecoveryParse.Text(_0089_0099_0089.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			P_0._008A_008B_0093._008B_008B_0094 = RecoveryParse.Text(_0089_0099_0088.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			num = RecoveryParse.Text(_0089_0097_0098.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			num2 = RecoveryParse.Text(_0089_009A_008A.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			P_0._008A_008A_0088(num2 - num - 150.0, _0089_009A_0086.Checked);
			P_0._008A_008A_0089(_0089_0095_009C());
		}
// R7 MethodDef: original 0x0600055F RVA 0x8AEF0; processed 0x0600055E RVA 0x71484; source 03_recovered-src\annotated-strings\--\--.cs:61122; processed IL recovery, not original runtime.
public double _0089_0095_009C()
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals

			num = RecoveryParse.Text(_0089_009A_0095.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
			num2 = -900.0;
			num3 = RecoveryParse.Cell(_0089_009B_0088, "输入数据有误，请检查。" /* string-offset:1984 */);
			num4 = _0089_0095_009D();
			return Math.Round((num3 - num4) / Math.Tan(num * Math.PI / 180.0) + num2);
		}
// R7 MethodDef: original 0x06000560 RVA 0x8AF6C; processed 0x0600055F RVA 0x714F8; source 03_recovered-src\annotated-strings\--\--.cs:61131; processed IL recovery, not original runtime.
public double _0089_0095_009D()
		{
			double num = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			num = _0089_0097_008D[_0089_009A_008F.SelectedIndex, 0];
			_0088_009D();
			// IL local hoisted
			if (!_0088_009E())
			{
				num2 = _0089_0097_008D[_0089_009A_008F.SelectedIndex, 1];
			}
			num3 = RecoveryParse.Cell(_0089_009A_008E, "输入数据有误，请检查。" /* string-offset:1984 */);
			if (num3 > 900.0)
			{
				num += num2 * 0.02 * num3 / 300.0;
			}
			return num;
		}
// R7 MethodDef: original 0x06000562 RVA 0x8B1B8; processed 0x06000561 RVA 0x71614; source 03_recovered-src\annotated-strings\--\--.cs:61172; processed IL recovery, not original runtime.
public void _0089_0096_0086(string P_0)
		{
			int num = default(int); // IL InitLocals
			char c = default(char); // IL InitLocals
			string text = default(string); // IL InitLocals
			string[] array = default(string[]); // IL InitLocals
			int length = default(int); // IL InitLocals
			string[] array2 = default(string[]); // IL InitLocals
			string[] array3 = default(string[]); // IL InitLocals
			int num2 = default(int); // IL InitLocals

			/* opaque discard 1 */
			// IL local hoisted
			if (!_0088_009E())
			{
				num = 10;
				goto IL_0196;
			}
			num = 24;
			goto IL_0487;
			IL_02f1:
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			if (c == 'W' && text == "WS" /* string-offset:6404 */)
			{
				_0089_0096_0087(array, _0089_0099_0091, _0089_0099_0095, _0089_0099_009A);
				num = 23;
			}
			goto IL_0460;
			IL_003e:
			// IL local hoisted
			switch (length)
			{
			case 1:
				break;
			case 3:
				goto IL_00bf;
			case 2:
				goto IL_02d8;
			case 4:
				goto IL_0367;
			case 5:
				if (text == "LIGHT" /* string-offset:6420 */)
				{
					_0089_009A_008C.Text = array[1].Trim();
				}
				goto IL_0460;
			case 7:
				goto IL_040c;
			default:
				goto IL_0460;
			}
			c = text[0];
			goto IL_0072;
			IL_0196:
			if (true /* original-file-bool-offset:1064 */)
			{
				num = 4;
				goto IL_01d6;
			}
			return;
			IL_0367:
			c = text[0];
			if (c != 'E')
			{
				num = 9;
				goto IL_0380;
			}
			if (text == "ELEV" /* string-offset:6412 */)
			{
				_0089_009A_008E.Text = array[1].Trim();
			}
			goto IL_0460;
			IL_01d6:
			P_0 = P_0.Replace('，', ',');
			num = 14;
			goto IL_01ee;
			IL_01ee:
			array2 = P_0.Split('\n');
			// IL local hoisted
			if (array2.Length >= 5)
			{
				array3 = array2;
				num = 2;
				goto IL_0214;
			}
			RecoveryMessages.Show("文件格式错误。" /* string-offset:6400 */);
			num = 13;
			return;
			IL_0460:
			num2 = num2 + 1;
			goto IL_0216;
			IL_02d8:
			c = text[0];
			if (c != 'G')
			{
				num = 20;
				goto IL_02f1;
			}
			if (text == "GP" /* string-offset:3928 */)
			{
				_0089_009A_0095.Text = array[1].Trim();
			}
			goto IL_0460;
			IL_0214:
			num2 = 0;
			goto IL_0216;
			IL_0216:
			if (num2 >= array3.Length)
			{
				num = 30;
				if (_0088_009D())
				{
					goto IL_010c;
				}
			}
			else
			{
				array = array3[num2].Split(',');
				if (array.Length < 2)
				{
					goto IL_0460;
				}
			}
			goto IL_0487;
			IL_0380:
			if (c != 'N')
			{
				num = 21;
				if (!_0088_009E())
				{
				}
			}
			else if (text == "NAME" /* string-offset:6408 */)
			{
			}
			goto IL_0460;
			IL_01b0:
			if (!(text == "FAF" /* string-offset:2000 */))
			{
				num = 16;
				if (!_0088_009D())
				{
					goto IL_01d6;
				}
			}
			else
			{
				_0089_009A_008A.Text = array[1].Trim();
			}
			goto IL_0460;
			IL_010c:
			while (true)
			{
				switch (num)
				{
				case 29:
					break;
				case 26:
					goto IL_0072;
				case 28:
					goto IL_00de;
				case 27:
					goto IL_00f0;
				case 0:
				case 10:
					goto IL_0196;
				case 4:
					goto IL_01d6;
				case 14:
					goto IL_01ee;
				case 2:
					goto IL_0214;
				case 6:
					goto IL_0216;
				case 20:
					goto IL_02f1;
				case 9:
					goto IL_0380;
				default:
					goto IL_0460;
				case 5:
				case 24:
					goto IL_0487;
				case 13:
					return;
				case 30:
					return;
				}
				break;
				IL_00de:
				if (c != 'C')
				{
					num = 27;
					goto IL_00f0;
				}
				goto IL_023c;
				IL_00f0:
				if (c == 'F')
				{
					goto IL_01b0;
				}
				num = 3;
				if (!_0088_009E())
				{
					continue;
				}
				goto IL_0216;
			}
			goto IL_003e;
			IL_0487:
			text = array[0].Trim().ToUpper();
			if (text != null)
			{
				length = text.Length;
				num = 29;
				if (_0088_009D())
				{
					goto IL_003e;
				}
			}
			goto IL_0460;
			IL_00bf:
			c = text[0];
			num = 28;
			if (_0088_009D())
			{
				goto IL_010c;
			}
			goto IL_0460;
			IL_040c:
			if (!(text == "APPTYPE" /* string-offset:6416 */))
			{
				num = 7;
				if (_0088_009D())
				{
				}
			}
			else
			{
				_0089_009A_0096.Text = array[1].Trim();
			}
			goto IL_0460;
			IL_023c:
			if (!(text == "CAT" /* string-offset:3924 */))
			{
				num = 19;
			}
			else
			{
				_0089_009A_008F.Text = array[1].Trim();
				num = 18;
			}
			goto IL_0460;
			IL_0072:
			switch (c)
			{
			case 'W':
				break;
			case 'X':
				_0089_0096_0087(array, _0089_0099_0099, _0089_0099_0097, _0089_0099_0096);
				goto IL_0460;
			case 'Y':
				_0089_0096_0087(array, _0089_0099_0092, _0089_0099_0090, _0089_0099_008E);
				goto IL_0460;
			case 'Z':
				_0089_0096_0087(array, _0089_0099_008A, _0089_0099_0089, _0089_0099_0088);
				goto IL_0460;
			default:
				goto IL_0460;
			}
			_0089_0096_0087(array, _0089_0099_008D, _0089_0099_0093, _0089_0099_0098);
			num = 12;
			if (!_0088_009E())
			{
				goto IL_010c;
			}
			goto IL_01ee;
		}
// R7 MethodDef: original 0x06000563 RVA 0x8B760; processed 0x06000562 RVA 0x4F36; source 03_recovered-src\annotated-strings\--\--.cs:61444; processed IL recovery, not original runtime.
public void _0089_0096_0087(string[] P_0, RecoveryCell P_1, RecoveryCell P_2, RecoveryCell P_3)
		{

			/* opaque discard 1 */
			if (!_0088_009E())
			{
				P_1.Text = P_0[1].Trim();
			}
			P_2.Text = P_0[2].Trim();
			P_3.Text = P_0[3].Trim();
		}
// R7 MethodDef: original 0x06000564 RVA 0x8B810; processed 0x06000563 RVA 0x71AD8; source 03_recovered-src\annotated-strings\--\--.cs:61455; processed IL recovery, not original runtime.
public string _0089_0096_0088(RecoveryCell P_0, RecoveryCell P_1, RecoveryCell P_2)
		{

			return P_0.Text + "," /* string-offset:704 */ + P_1.Text + "," /* string-offset:704 */ + P_2.Text;
		}
// R7 MethodDef: original 0x06000566 RVA 0x8B9E4; processed 0x06000565 RVA 0x71BD4; source 03_recovered-src\annotated-strings\--\--.cs:61487; processed IL recovery, not original runtime.
public string _0089_0096_008A()
		{

			return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat("AppType," /* string-offset:6432 */ + _0089_009A_0096.Text + "\n" /* string-offset:328 */, "CAT," /* string-offset:6436 */, _0089_009A_008F.Text, "\n" /* string-offset:328 */), "GP," /* string-offset:6440 */, _0089_009A_0095.Text, "\n" /* string-offset:328 */), "FAF，" /* string-offset:6444 */, _0089_009A_008A.Text, "\n" /* string-offset:328 */), "ELEV，" /* string-offset:6448 */, _0089_009A_008E.Text, "\n" /* string-offset:328 */), "LIGHT," /* string-offset:6452 */, _0089_009A_008C.Text, "\n" /* string-offset:328 */), "W," /* string-offset:6456 */, _0089_0096_0088(_0089_0099_008D, _0089_0099_0093, _0089_0099_0098), "\n" /* string-offset:328 */), "WS," /* string-offset:6460 */, _0089_0096_0088(_0089_0099_0091, _0089_0099_0095, _0089_0099_009A), "\n" /* string-offset:328 */), "X," /* string-offset:6464 */, _0089_0096_0088(_0089_0099_0099, _0089_0099_0097, _0089_0099_0096), "\n" /* string-offset:328 */), "Y," /* string-offset:6468 */, _0089_0096_0088(_0089_0099_0092, _0089_0099_0090, _0089_0099_008E), "\n" /* string-offset:328 */), "Z," /* string-offset:6472 */, _0089_0096_0088(_0089_0099_008A, _0089_0099_0089, _0089_0099_0088), "\n" /* string-offset:328 */);
		}
// R7 MethodDef: original 0x06000568 RVA 0x8BBEC; processed 0x06000567 RVA 0x71DB0; source 03_recovered-src\annotated-strings\--\--.cs:61497; processed IL recovery, not original runtime.
public void _0089_0096_008C(PbnIlsTurn P_0, ref PbnIlsObstacle P_1, double P_2)
		{
			int num = default(int); // IL InitLocals
			double num11 = default(double); // IL InitLocals
			double num12 = default(double); // IL InitLocals
			double num13 = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num7 = default(double); // IL InitLocals
			double num8 = default(double); // IL InitLocals
			double num9 = default(double); // IL InitLocals
			double num10 = default(double); // IL InitLocals

			num = 21;
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (!false /* original-file-bool-offset:1068 */ && P_1._0088_0090_008C > 0.0)
			{
				num2 = RecoveryParse.Cell(_0089_009A_008E, "输入数据有误，请检查。" /* string-offset:1984 */);
				num3 = _0089_0097_008D[_0089_009A_008F.SelectedIndex, 0];
				num4 = _0089_0097_008D[_0089_009A_008F.SelectedIndex, 1];
				num5 = num3 + ((num2 > 900.0) ? Math.Round(num4 * 0.02 * num2 / 300.0, 2) : 0.0);
				num6 = Math.Tan(RecoveryParse.Text(_0089_009A_0095.Text, "输入数据有误，请检查。" /* string-offset:1984 */) * Math.PI / 180.0);
				num7 = ((_0089_009A_008F.Text == "H" /* string-offset:2320 */) ? 700 : 900);
				num8 = P_1.Z - P_2;
				while (true)
				{
					IL_05b8:
					num9 = 1.0 / num6;
					num10 = 100.0 / RecoveryParse.Text(_0089_009A_009A.Text, "输入数据有误，请检查。" /* string-offset:1984 */);
					num = 3;
					while (true)
					{
						if (P_1.X > -900.0)
						{
							num = 23;
							goto IL_0237;
						}
						goto IL_057d;
						IL_069c:
						P_1._0088_0090_0093 = Math.Max(num11, 400.0);
						num = 33;
						return;
						IL_057d:
						if (!(P_1.X > P_0._008A_008A_0095.X))
						{
							num12 = P_1._0088_0090_008D * 30.0;
							num = 30;
							goto IL_0514;
						}
						P_1._0088_0090_008E = Math.Ceiling((num8 * num10 + P_1.X + num7) / (num9 + num10));
						goto IL_0294;
						IL_0182:
						P_1._0088_0090_008F = P_2 + P_1.Z + P_1._0088_0090_008D;
						goto IL_019a;
						IL_019a:
						P_1._0088_0090_008B += P_2;
						num = 6;
						goto IL_01b2;
						IL_0514:
						P_1._0088_0090_008E = Math.Ceiling(((num8 - num12) * num10 + P_1.X + num7) / (num9 + num10));
						P_1._0088_0090_008D = num5;
						num = 25;
						if (!_0088_009E())
						{
							goto IL_0326;
						}
						goto IL_04ec;
						IL_04ec:
						num11 = Math.Ceiling(num11 / 50.0) * 50.0;
						num = 34;
						goto IL_04db;
						IL_04db:
						if (!(P_2 < 3000.0))
						{
							num = 18;
							goto IL_03c4;
						}
						goto IL_043c;
						IL_01b2:
						P_1._0088_0090_0092 = Math.Ceiling(P_1._0088_0090_0090 / 5.0) * 5.0;
						num = 9;
						goto IL_01e2;
						IL_043c:
						num11 = Math.Min(num11, 5000.0);
						goto IL_0418;
						IL_0418:
						if (_0089_009A_0096.Text == "CAT I" /* string-offset:4236 */)
						{
							break;
						}
						if (P_1._0088_0090_0092 <= 42.0)
						{
							if (P_1._0088_0090_0092 <= 35.0)
							{
								P_1._0088_0090_0093 = Math.Max(num11, 350.0);
								num = 35;
								if (!_0088_009D())
								{
									goto IL_0182;
								}
								goto IL_0326;
							}
							goto IL_069c;
						}
						P_1._0088_0090_0093 = Math.Max(num11, 450.0);
						num = 20;
						return;
						IL_01e2:
						if (_0089_009A_0096.Text == "CAT I" /* string-offset:4236 */)
						{
							P_1._0088_0090_0092 = Math.Max(P_1._0088_0090_0092, 60.0);
							num = 0;
						}
						goto IL_01fe;
						IL_048f:
						num11 = Math.Ceiling(num11 / 100.0) * 100.0;
						goto IL_04db;
						IL_01fe:
						P_1._0088_0090_0091 = Math.Round(P_1._0088_0090_0092 + P_2);
						/* opaque discard 0 */
						if (_0088_009D())
						{
							num = 2;
							if (_0088_009D())
							{
								goto IL_0326;
							}
							goto IL_0467;
						}
						num = 31;
						return;
						IL_0326:
						switch (num)
						{
						case 11:
							break;
						case 6:
							goto IL_01b2;
						case 9:
							goto IL_01e2;
						case 0:
							goto IL_01fe;
						case 23:
							goto IL_0237;
						case 1:
							goto IL_0294;
						case 24:
							goto IL_029c;
						case 25:
							P_1._0088_0090_0090 = P_1._0088_0090_008E + P_1._0088_0090_008D;
							goto case 12;
						case 12:
							P_1._0088_0090_008F = P_2 + P_1._0088_0090_008E + P_1._0088_0090_008D;
							goto IL_019a;
						case 28:
							P_1._0088_0090_0090 = P_1.Z + P_1._0088_0090_008D;
							num = 11;
							break;
						case 18:
							goto IL_03c4;
						case 32:
							goto IL_03e2;
						case 17:
							goto IL_03fd;
						case 26:
							goto IL_0418;
						case 2:
						case 16:
							num13 = RecoveryParse.Cell(_0089_009A_008C, "输入数据有误，请检查。" /* string-offset:1984 */);
							goto IL_0467;
						default:
							goto IL_0467;
						case 15:
							goto IL_0475;
						case 4:
							goto IL_048f;
						case 34:
							goto IL_04db;
						case 13:
							goto IL_04ec;
						case 30:
							goto IL_0514;
						case 3:
							continue;
						case 19:
							goto IL_05b8;
						case 21:
							goto end_IL_05b8;
						case 8:
							goto end_IL_05a4;
						case 5:
							return;
						case 10:
							goto IL_0682;
						case 14:
							return;
						case 20:
							return;
						case 22:
							goto IL_069c;
						case 33:
							return;
						case 7:
						case 35:
							return;
						case 29:
						case 31:
							return;
						}
						goto IL_0182;
						IL_03c4:
						if (P_1._0088_0090_0092 <= 300.0)
						{
							if (!(P_2 >= 3000.0))
							{
								goto IL_03e2;
							}
							goto IL_03fd;
						}
						goto IL_043c;
						IL_0467:
						num11 = P_1._0088_0090_0092 / num6 - num13;
						goto IL_0475;
						IL_03e2:
						if (P_1._0088_0090_0092 > 450.0)
						{
							num = 17;
							goto IL_03fd;
						}
						goto IL_0418;
						IL_0475:
						if (num11 >= 800.0)
						{
							if (num11 < 5000.0)
							{
								goto IL_048f;
							}
							num11 = Math.Ceiling(num11 / 1000.0) * 1000.0;
							goto IL_04db;
						}
						goto IL_04ec;
						IL_03fd:
						num11 = Math.Min(num11, 8000.0);
						num = 26;
						goto IL_0418;
						IL_0294:
						P_1._0088_0090_008D = num5;
						goto IL_029c;
						IL_029c:
						P_1._0088_0090_0090 = P_1._0088_0090_008E + P_1._0088_0090_008D;
						P_1._0088_0090_008F = P_2 + P_1._0088_0090_008E + P_1._0088_0090_008D;
						goto IL_019a;
						IL_0237:
						if (num8 < (P_1.X + num7) * num6)
						{
							P_1._0088_0090_008D = num5;
							num = 28;
							if (!_0088_009E())
							{
								goto IL_0326;
							}
							goto IL_04db;
						}
						goto IL_057d;
						continue;
						end_IL_05a4:
						break;
					}
					if (num13 > 720.0)
					{
						P_1._0088_0090_0093 = Math.Max(num11, 550.0);
						return;
					}
					if (num13 > 420.0)
					{
						num = 10;
						goto IL_0682;
					}
					P_1._0088_0090_0093 = Math.Max(num11, 1200.0);
					return;
					IL_0682:
					P_1._0088_0090_0093 = Math.Max(num11, 800.0);
					return;
					continue;
					end_IL_05b8:
					break;
				}
			}
		}
// R7 MethodDef: original 0x0600056B RVA 0x8C474; processed 0x0600056A RVA 0x724F8; source 03_recovered-src\annotated-strings\--\--.cs:61794; processed IL recovery, not original runtime.
public void _0089_0096_008F()
		{
			double num = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals

			/* opaque discard 1 */
			// IL local hoisted
			if (!_0088_009E())
			{
				num = RecoveryParse.Cell(_0089_0098_0092, "输入数据有误，请检查。" /* string-offset:1984 */);
			}
			else if (_0088_009E())
			{
				goto IL_007f;
			}
			// IL local hoisted
			if (num > 900.0)
			{
				num2 = RecoveryParse.Cell(_0089_0098_009C, "输入数据有误，请检查。" /* string-offset:1984 */);
				num3 = RecoveryParse.Cell(_0089_0098_009B, "输入数据有误，请检查。" /* string-offset:1984 */);
				num4 = Math.Round(num2 + num3 * 0.02 * num / 300.0, 2);
				goto IL_007f;
			}
			_0089_0098_009A.Text = _0089_0098_009C.Text;
			return;
			IL_007f:
			_0089_0098_009A.Text = num4.ToString();
		}
// R7 MethodDef: original 0x06000573 RVA 0x8D2F8; processed 0x06000572 RVA 0x72DA4; source 03_recovered-src\annotated-strings\--\--.cs:62084; processed IL recovery, not original runtime.
public static string _0089_0096_0097(string P_0)
		{
			char[] array = default(char[]); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			int num3 = default(int); // IL InitLocals
			char c = default(char); // IL InitLocals
			int num4 = default(int); // IL InitLocals
			int length = default(int); // IL InitLocals
			int num = default(int); // IL InitLocals
			char c2 = default(char); // IL InitLocals

			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				IL_014a:
				// IL local hoisted
				if (!false /* original-file-bool-offset:1080 */)
				{
					array = P_0.ToCharArray();
					_0088_009D();
					if (!_0088_009E())
					{
						num = 7;
						goto IL_00a4;
					}
					goto IL_0133;
				}
				num = 3;
				goto IL_0115;
				IL_0108:
				num2++;
				num = 11;
				goto IL_0115;
				IL_00da:
				num3 = int.Parse(c.ToString());
				num = 13;
				goto IL_00f0;
				IL_00f0:
				if (num3 != 0)
				{
					goto IL_00f3;
				}
				goto IL_0108;
				IL_0133:
				while (true)
				{
					if (num4 < length / 2)
					{
						c2 = array[num4];
						array[num4] = array[length - 1 - num4];
						array[length - 1 - num4] = c2;
						num4++;
						num = 4;
						if (!_0088_009D())
						{
							goto IL_00a4;
						}
					}
					else
					{
						num = 14;
						if (_0088_009E())
						{
							break;
						}
					}
					switch (num)
					{
					case 2:
					case 7:
						break;
					case 5:
						goto IL_00b4;
					case 0:
						goto IL_00da;
					case 13:
						goto IL_00f0;
					default:
						goto IL_00f3;
					case 9:
						goto IL_0108;
					case 1:
					case 3:
					case 11:
						goto end_IL_0133;
					case 4:
					case 8:
					case 10:
						continue;
					case 12:
						goto IL_014a;
					case 14:
						return new string(array);
					}
					goto IL_00a4;
					continue;
					end_IL_0133:
					break;
				}
				goto IL_0115;
				IL_00a4:
				length = P_0.Length;
				num = 5;
				goto IL_00b4;
				IL_00b4:
				num2 = 0;
				num = 1;
				if (_0088_009E())
				{
					goto IL_00f3;
				}
				goto IL_0115;
				IL_0115:
				if (num2 < length)
				{
					c = P_0[num2];
					num = 0;
					goto IL_00da;
				}
				num4 = 0;
				goto IL_0133;
				IL_00f3:
				array[num2] = char.Parse((10 - num3).ToString());
				goto IL_0108;
			}
		}
// R7 MethodDef: original 0x06000574 RVA 0x8D4CC; processed 0x06000573 RVA 0x72F14; source 03_recovered-src\annotated-strings\--\--.cs:62207; processed IL recovery, not original runtime.
public void _0089_0096_0098(ref OasModel P_0)
		{
			int num = default(int); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals
			double num2 = default(double); // IL InitLocals

			num = 8;
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			// IL local hoisted
			while (true /* original-file-bool-offset:1084 */)
			{
				num = 3;
				while (true)
				{
					num2 = RecoveryParse.Cell(_0089_009A_009C, "输入数据有误，请检查。" /* string-offset:1984 */);
					/* opaque discard 1 */
					if (!_0088_009E())
					{
						num = 1;
						if (_0088_009D())
						{
							goto IL_004c;
						}
						goto IL_0133;
					}
					num = 4;
					goto IL_0186;
					IL_0186:
					P_0._0088_0091_0099._008B_008B_0094 -= num3 * num4;
					num = 10;
					return;
					IL_0133:
					num5 = P_0._0088_0091_0098._008B_008B_0093;
					num3 = P_0._0088_0091_0099._008B_008B_0093;
					goto IL_0081;
					IL_0081:
					num4 = Math.Max(num6 / num5, num2 + (num6 - 3.0) / num5) - Math.Max(6.0 / num5, 30.0 + 3.0 / num5);
					num = 0;
					if (!_0088_009D())
					{
						continue;
					}
					goto IL_004c;
					IL_004c:
					switch (num)
					{
					case 3:
						break;
					default:
						goto IL_0081;
					case 1:
					case 2:
						num6 = RecoveryParse.Cell(_0089_009A_009D, "输入数据有误，请检查。" /* string-offset:1984 */);
						num = 5;
						goto case 5;
					case 5:
						P_0._0088_0091_0096._008B_008B_0094 -= num6 - 6.0;
						P_0._0088_0091_0097._008B_008B_0094 -= num6 - 6.0;
						goto IL_0133;
					case 9:
						goto IL_0133;
					case 8:
						goto end_IL_0017;
					case 0:
						P_0._0088_0091_0098._008B_008B_0094 -= num5 * num4;
						goto IL_0186;
					case 4:
					case 7:
						goto IL_0186;
					case 10:
						return;
					}
					continue;
					end_IL_0017:
					break;
				}
			}
		}
// R7 MethodDef: original 0x06000575 RVA 0x8D6B8; processed 0x06000574 RVA 0x730C8; source 03_recovered-src\annotated-strings\--\--.cs:62284; processed IL recovery, not original runtime.
public void _0089_0096_0099(ref OasModel P_0)
		{
			double num = default(double); // IL InitLocals

			num = RecoveryParse.Cell(_0089_009A_0099, "输入数据有误，请检查。" /* string-offset:1984 */) - 15.0;
			_0088_009E();
			if (_0088_009D() && !_0088_009E())
			{
				goto IL_0039;
			}
			goto IL_0075;
			IL_0075:
			P_0._0088_0091_0099._008B_008B_0094 += num;
			if (!_0088_009E())
			{
				return;
			}
			goto IL_0039;
			IL_0039:
			P_0._0088_0091_0096._008B_008B_0094 += num;
			P_0._0088_0091_0097._008B_008B_0094 += num;
			P_0._0088_0091_0098._008B_008B_0094 += num;
			goto IL_0075;
		}
// R7 MethodDef: original 0x06000576 RVA 0x8D7E0; processed 0x06000575 RVA 0x73168; source 03_recovered-src\annotated-strings\--\--.cs:62307; processed IL recovery, not original runtime.
public void _0089_0096_009A(OasModel P_0)
		{

			if (_0088_009E())
			{
				goto IL_0047;
			}
			if (true /* original-file-bool-offset:1088 */)
			{
				if (_0088_009D())
				{
				}
				_0089_0099_008D.Text = P_0._0088_0091_0096._008B_008B_0092.ToString("f6" /* string-offset:6484 */);
				goto IL_01fc;
			}
			return;
			IL_0047:
			_0089_0099_0095.Text = P_0._0088_0091_0097._008B_008B_0093.ToString("f6" /* string-offset:6484 */);
			_0088_009D();
			if (!_0088_009E())
			{
				_0089_0099_009A.Text = P_0._0088_0091_0097._008B_008B_0094.ToString("f2" /* string-offset:4640 */);
			}
			_0089_0099_0099.Text = P_0._0088_0091_0098._008B_008B_0092.ToString("f6" /* string-offset:6484 */);
			_0089_0099_0097.Text = P_0._0088_0091_0098._008B_008B_0093.ToString("f6" /* string-offset:6484 */);
			_0089_0099_0096.Text = P_0._0088_0091_0098._008B_008B_0094.ToString("f2" /* string-offset:4640 */);
			_0089_0099_0092.Text = P_0._0088_0091_0099._008B_008B_0092.ToString("f6" /* string-offset:6484 */);
			_0089_0099_0090.Text = P_0._0088_0091_0099._008B_008B_0093.ToString("f6" /* string-offset:6484 */);
			if (!_0088_009E())
			{
				_0089_0099_008E.Text = P_0._0088_0091_0099._008B_008B_0094.ToString("f2" /* string-offset:4640 */);
				_0089_0099_008A.Text = P_0._0088_0091_009A._008B_008B_0092.ToString("f6" /* string-offset:6484 */);
				_0089_0099_0089.Text = P_0._0088_0091_009A._008B_008B_0093.ToString("f6" /* string-offset:6484 */);
			}
			_0089_0099_0088.Text = P_0._0088_0091_009A._008B_008B_0094.ToString("f2" /* string-offset:4640 */);
			if (!_0088_009E())
			{
				return;
			}
			goto IL_01fc;
			IL_01fc:
			_0089_0099_0093.Text = P_0._0088_0091_0096._008B_008B_0093.ToString("f6" /* string-offset:6484 */);
			_0089_0099_0098.Text = P_0._0088_0091_0096._008B_008B_0094.ToString("f2" /* string-offset:4640 */);
			_0089_0099_0091.Text = P_0._0088_0091_0097._008B_008B_0092.ToString("f6" /* string-offset:6484 */);
			goto IL_0047;
		}
internal static bool _0088_009D(){return true;}
internal static bool _0088_009E(){return false;}
}

}
