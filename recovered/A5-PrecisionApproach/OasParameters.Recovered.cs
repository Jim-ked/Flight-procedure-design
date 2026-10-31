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
	public class OasParameters
	{
		// R8 MethodDef: original 0x0600040A RVA 0x63AE4; processed 0x06000409 RVA 0x51B54; source 03_recovered-src\annotated-strings\--\--.cs:41676; processed IL recovery, not original runtime.
public static OasModel _0088_0090_0094(string P_0, OasMode P_1, string P_2, string P_3)
		{
			string text = default(string); // IL InitLocals
			string text2 = default(string); // IL InitLocals
			OasModel obj = default(OasModel); // IL InitLocals
			int num = default(int); // IL InitLocals
			string text3 = default(string); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			string text4 = default(string); // IL InitLocals
			string text5 = default(string); // IL InitLocals
			int num3 = default(int); // IL InitLocals
			string text6 = default(string); // IL InitLocals
			string text7 = default(string); // IL InitLocals

			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Expected O, but got Unknown
			text = RecoveryDatabase.Path; // IO boundary adapter; original location recorded in evidence
			/* opaque discard 1 */
			if (!_0087u())
			{
				if (RecoveryDatabase.Present)
				{
					text2 = "Data Source="  + text + ";Version=3;" ;
					obj = new OasModel(P_1);
					num = (int)P_1;
					text3 = (P_0 + num + P_2).Replace("." , "");
					num2 = (int)Math.Round(Convert.ToDouble(P_3), 0);
					SQLiteConnection val = new SQLiteConnection(text2);
					try
					{
						val.Open();
						text4 = "SELECT Value FROM PartA WHERE ID = @id" ;
						text5 = "SELECT Value FROM PartB WHERE ID = @id" ;
						SQLiteCommand val2 = new SQLiteCommand(text4, val);
						try
						{
							val2.Parameters.AddWithValue("@id" , (object)text3);
							num3 = 0;
							// IL local hoisted
							while (true)
							{
								text6 = val2.ExecuteScalar().ToString();
								num3 = 8;
								if (!_0087u())
								{
									while (true)
									{
										switch (num3)
										{
										case 8:
											obj._0088_0091_009A._008B_008B_0092 = (double)Convert.ToInt32(text3.Substring(3, 2)) * -0.001;
											/* opaque discard 1 */
											if (!_0087u())
											{
												num3 = 5;
												goto case 2;
											}
											num3 = 7;
											goto default;
										case 2:
										case 5:
											obj._0088_0091_009A._008B_008B_0093 = 0.0;
											obj._0088_0091_009A._008B_008B_0094 = (double)Convert.ToInt32(_0088_0090_0095(text6.Substring(0, 4))) * -0.01;
											num3 = 6;
											goto case 6;
										case 6:
											obj._0088_0091_0096._008B_008B_0092 = (double)Convert.ToInt32(_0088_0090_0095(text6.Substring(4, 5))) * 1E-06;
											goto default;
										default:
											obj._0088_0091_0096._008B_008B_0093 = 0.0;
											num3 = 1;
											if (_0087t())
											{
												continue;
											}
											goto case 6;
										case 0:
											break;
										case 1:
											obj._0088_0091_0096._008B_008B_0094 = (double)Convert.ToInt32(_0088_0090_0095(text6.Substring(9, 3))) * -0.01;
											num3 = 3;
											goto IL_023c;
										case 3:
											goto IL_023c;
										case 9:
											goto end_IL_01ed;
										}
										break;
									}
									continue;
								}
								goto IL_023c;
								IL_023c:
								obj._0088_0091_0097._008B_008B_0092 = (double)Convert.ToInt32(_0088_0090_0095(text6.Substring(12, 5))) * 1E-06;
								obj._0088_0091_0097._008B_008B_0093 = 0.0;
								num3 = 9;
								break;
								continue;
								end_IL_01ed:
								break;
							}
							obj._0088_0091_0097._008B_008B_0094 = (double)Convert.ToInt32(_0088_0090_0095(text6.Substring(17, 4))) * -0.01;
						}
						finally
						{
							val2.Dispose();
						}
						SQLiteCommand val3 = new SQLiteCommand(text5, val);
						try
						{
							val3.Parameters.AddWithValue("@id" , (object)(text3 + num2));
							text7 = _0088_0090_0095(val3.ExecuteScalar().ToString());
							_0087t();
							if (!_0087u())
							{
								obj._0088_0091_0098._008B_008B_0092 = (double)Convert.ToInt32(text7.Substring(0, 5)) * 1E-06;
							}
							else if (!_0087t())
							{
								goto IL_035a;
							}
							obj._0088_0091_0098._008B_008B_0093 = (double)Convert.ToInt32(text7.Substring(5, 6)) * 1E-06;
							goto IL_035a;
							IL_035a:
							obj._0088_0091_0098._008B_008B_0094 = (double)Convert.ToInt32(text7.Substring(11, 4)) * -0.01;
							obj._0088_0091_0099._008B_008B_0092 = (double)Convert.ToInt32(text7.Substring(15, 5)) * 1E-06;
							obj._0088_0091_0099._008B_008B_0093 = (double)Convert.ToInt32(text7.Substring(20, 6)) * 1E-06;
							obj._0088_0091_0099._008B_008B_0094 = (double)Convert.ToInt32(text7.Substring(26, 4)) * -0.01;
						}
						finally
						{
							val3.Dispose();
						}
						val.Close();
						return obj;
					}
					finally
					{
						val.Dispose();
					}
				}
				RecoveryMessages.Show("参数文件不存在。" );
			}
			return null;
		}

		// R8 MethodDef: original 0x0600040B RVA 0x640AC; processed 0x0600040A RVA 0x51FC4; source 03_recovered-src\annotated-strings\--\--.cs:41814; processed IL recovery, not original runtime.
private static string _0088_0090_0095(string P_0)
		{
			char[] array = default(char[]); // IL InitLocals
			int length = default(int); // IL InitLocals
			int num = default(int); // IL InitLocals
			int num2 = default(int); // IL InitLocals
			char c = default(char); // IL InitLocals

			if (false /* original-file-bool-offset:772 */)
			{
				/* opaque discard 0 */
				if (_0087t())
				{
					goto IL_006c;
				}
				goto IL_0050;
			}
			array = P_0.ToCharArray();
			length = P_0.Length;
			num = 0;
			goto IL_0072;
			IL_0050:
			// IL local hoisted
			if (num2 != 5)
			{
				array[num] = char.Parse((10 - num2).ToString());
			}
			goto IL_006c;
			IL_0072:
			do
			{
				if (num < length)
				{
					num2 = int.Parse(P_0[num].ToString());
					continue;
				}
				for (int i = 0; i < length / 2; i++)
				{
					c = array[i];
					if (!_0087t())
					{
						break;
					}
					array[i] = array[length - 1 - i];
					array[length - 1 - i] = c;
				}
				return new string(array);
			}
			while (_0087u());
			if (num2 != 0)
			{
				goto IL_0050;
			}
			goto IL_006c;
			IL_006c:
			num++;
			goto IL_0072;
		}

		// R8 MethodDef: original 0x0600040C RVA 0x64280; processed 0x0600040B RVA 0x5207C; source 03_recovered-src\annotated-strings\--\--.cs:41867; processed IL recovery, not original runtime.
public static void _0088_0090_0096(ref OasModel P_0, double P_1, double P_2)
		{
			int num = default(int); // IL InitLocals
			double num2 = default(double); // IL InitLocals
			double num3 = default(double); // IL InitLocals
			double num4 = default(double); // IL InitLocals
			double num5 = default(double); // IL InitLocals
			double num6 = default(double); // IL InitLocals

			num = 4;
			if (_0087u())
			{
			}
			// IL local hoisted
			// IL local hoisted
			while (true)
			{
				IL_0174:
				if (!false /* original-file-bool-offset:776 */)
				{
					num2 = P_1;
					num = 9;
					goto IL_015c;
				}
				/* opaque discard 1 */
				if (!_0087u())
				{
					break;
				}
				num = 2;
				goto IL_0133;
				IL_015c:
				num3 = P_2;
				goto IL_0133;
				IL_0133:
				while (true)
				{
					IL_0133_2:
					P_0._0088_0091_0096._008B_008B_0094 -= num3 - 6.0;
					num = 6;
					while (true)
					{
						IL_0113:
						P_0._0088_0091_0097._008B_008B_0094 -= num3 - 6.0;
						while (true)
						{
							IL_00f4:
							num4 = P_0._0088_0091_0098._008B_008B_0093;
							num5 = P_0._0088_0091_0099._008B_008B_0093;
							while (true)
							{
								num6 = Math.Max(num3 / num4, num2 + (num3 - 3.0) / num4) - Math.Max(6.0 / num4, 30.0 + 3.0 / num4);
								P_0._0088_0091_0098._008B_008B_0094 -= num4 * num6;
								num = 0;
								if (_0087u())
								{
									break;
								}
								while (true)
								{
									switch (num)
									{
									case 0:
										P_0._0088_0091_0099._008B_008B_0094 -= num5 * num6;
										num = 10;
										if (_0087t())
										{
											continue;
										}
										goto IL_00f4;
									case 5:
										break;
									default:
										goto IL_00f4;
									case 6:
										goto IL_0113;
									case 2:
									case 3:
										goto IL_0133_2;
									case 9:
										goto end_IL_0089;
									case 4:
										goto IL_0174;
									case 1:
									case 8:
									case 10:
										return;
									}
									break;
								}
								continue;
								end_IL_0089:
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				goto IL_015c;
			}
			num = 8;
		}

		// R8 MethodDef: original 0x0600040D RVA 0x64454; processed 0x0600040C RVA 0x52218; source 03_recovered-src\annotated-strings\--\--.cs:41965; processed IL recovery, not original runtime.
public static void _0088_0090_0097(ref OasModel P_0, double P_1)
		{
			double num = default(double); // IL InitLocals

			num = P_1 - 15.0;
			if (!_0087u())
			{
				P_0._0088_0091_0096._008B_008B_0094 += num;
				P_0._0088_0091_0097._008B_008B_0094 += num;
				/* opaque discard 0 */
				if (_0087t())
				{
					P_0._0088_0091_0098._008B_008B_0094 += num;
				}
			}
			P_0._0088_0091_0099._008B_008B_0094 += num;
		}

		// R8 MethodDef: original 0x0600040F RVA 0x64570; processed 0x0600040E RVA 0x48F3; source 03_recovered-src/annotated-strings/--/--.cs:41981; processed IL recovery, not original runtime.
static OasParameters()
		{

			// original licensing excluded; independent source only
		}

		// R8 MethodDef: original 0x06000410 RVA 0x6458C; processed 0x0600040F RVA 0x22CE; source 03_recovered-src\annotated-strings\--\--.cs:41986; processed IL recovery, not original runtime.
internal static bool _0087t()
		{

			return true;
		}

		// R8 MethodDef: original 0x06000411 RVA 0x64598; processed 0x06000410 RVA 0x22D1; source 03_recovered-src\annotated-strings\--\--.cs:41991; processed IL recovery, not original runtime.
internal static bool _0087u()
		{

			return false;
		}
	}
}
