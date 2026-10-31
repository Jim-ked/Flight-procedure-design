using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Forms;
// Mechanical recovery: original field/method identifiers retained. See evidence/methods.csv.
// IL locals hoisted to method entry; expression assignments and branch order preserved.
namespace Recovered.A6 {
	public class TurnInput
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

// Original MethodDef: 0x06000794; Original RVA: 0xC3820; Processed MethodDef: 0x06000793; Evidence: TurnInput.source.txt:81748 + independent IL (decompilation/recovery, not runtime).
		public TurnInput(double P_0 = 380.0, double P_1 = 600.0, double P_2 = 25.0, double P_3 = 56.0, double P_4 = 15.0)
		{

			if (false /* original-file-bool-offset:1352 */)
			{
				/* opaque discard 0 */
				if (_0089h())
				{
					return;
				}
				goto IL_0034;
			}
			_008A_009E_0087 = 1000.0;
			// object constructor emitted automatically by C#
			goto IL_004b;
			IL_004b:
			_008A_009D_0095 = P_0;
			_008A_009D_0096 = P_1;
			_008A_009D_0097 = P_2;
			goto IL_0034;
			IL_0034:
			_008A_009D_0098 = P_3;
			_008A_009D_0099 = P_4;
			if (_0089h())
			{
				_008A_009D_009B = 171233.0 * Math.Sqrt(288.0 + _008A_009D_0099 - 0.006496 * _008A_009D_0096) / Math.Pow(288.0 - 0.006496 * _008A_009D_0096, 2.628);
				_008A_009D_009A = _008A_009D_0095 * _008A_009D_009B;
				_008A_009D_009C = Math.Min(6355.0 * Math.Tan(_008A_009D_0097 * Math.PI / 180.0) / (Math.PI * _008A_009D_009A), 3.0);
				_008A_009D_009D = _008A_009E_0087 * _008A_009D_009A / (Math.PI * 20.0 * _008A_009D_009C);
				_008A_009D_009E = _008A_009E_0087 * _008A_009D_0098 / (Math.PI * 20.0 * _008A_009D_009C);
				_008A_009E_0086 = Math.Asin(_008A_009D_0098 / _008A_009D_009A);
				Console.WriteLine(ToString());
				return;
			}
			goto IL_004b;
		}

// Original MethodDef: 0x06000795; Original RVA: 0xC3AB0; Processed MethodDef: 0x06000794; Evidence: TurnInput.source.txt:81784 + independent IL (decompilation/recovery, not runtime).
		public override string ToString()
		{

			return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat("=====Turn Parameters=====\n" /* string-offset:7272 */ + "IAS = " /* string-offset:7276 */ + Math.Round(_008A_009D_0095 * 100.0) / 100.0 + " km/h\n" /* string-offset:7280 */, "Altitude = " /* string-offset:7284 */, (Math.Round(_008A_009D_0096 * 100.0) / 100.0).ToString(), " m\n" /* string-offset:5280 */), "k = " /* string-offset:7288 */, (Math.Round(_008A_009D_009B * 10000.0) / 10000.0).ToString(), "\n" /* string-offset:328 */), "TAS = " /* string-offset:7292 */, (Math.Round(_008A_009D_009A * 100.0) / 100.0).ToString(), " km/h\n" /* string-offset:7280 */), "WindSpeed = " /* string-offset:7296 */, (Math.Round(_008A_009D_0098 * 100.0) / 100.0).ToString(), " km/h\n" /* string-offset:7280 */), "BankAngle = " /* string-offset:7300 */, _008A_009D_0097.ToString(), "°\n" /* string-offset:7304 */), "DraftAngle = " /* string-offset:7308 */, (Math.Round(_008A_009E_0086 * 180.0 / Math.PI * 100.0) / 100.0).ToString(), "°\n" /* string-offset:7304 */), "R = " /* string-offset:7312 */, (Math.Round(_008A_009D_009C * 100.0) / 100.0).ToString(), " °/s\n" /* string-offset:7316 */), "Radius = " /* string-offset:7320 */, Math.Round(_008A_009D_009D).ToString(), " m\n" /* string-offset:5280 */), "Esita = " /* string-offset:7324 */, (Math.Round(10.0 * _008A_009D_009E * Math.PI / 180.0) / 10.0).ToString(), " m /°\n" /* string-offset:7328 */), "E45 = " /* string-offset:7332 */, Math.Round(Math.PI / 4.0 * _008A_009D_009E).ToString(), " m \n" /* string-offset:7336 */), "E90 = " /* string-offset:7340 */, Math.Round(Math.PI / 2.0 * _008A_009D_009E).ToString(), " m \n" /* string-offset:7336 */), "E135 = " /* string-offset:7344 */, Math.Round(Math.PI * 3.0 / 4.0 * _008A_009D_009E).ToString(), " m \n" /* string-offset:7336 */), "E180 = " /* string-offset:7348 */, Math.Round(Math.PI * _008A_009D_009E).ToString(), " m \n" /* string-offset:7336 */), "E235 = " /* string-offset:7352 */, Math.Round(4.101523742186674 * _008A_009D_009E).ToString(), " m \n" /* string-offset:7336 */), "C6 = (v+w)*6 = " /* string-offset:7356 */, Math.Round((_008A_009D_009A + _008A_009D_0098) / 0.6).ToString(), " m \n" /* string-offset:7336 */);
		}

// Original MethodDef: 0x06000796; Original RVA: 0xC3E94; Processed MethodDef: 0x06000795; Evidence: TurnInput.source.txt:81789 + independent IL (decompilation/recovery, not runtime).
		public List<string> _008A_009D_0094()
		{

			return new List<string>
			{
				"转弯参数" /* string-offset:4960 */,
				" 名称,数值,单位" /* string-offset:7360 */,
				"IAS , " /* string-offset:7364 */ + Math.Round(_008A_009D_0095 * 100.0) / 100.0 + ", km/h" /* string-offset:7368 */,
				"Altitude , " /* string-offset:7372 */ + Math.Round(_008A_009D_0096 * 100.0) / 100.0 + ", m" /* string-offset:7376 */,
				"k , " /* string-offset:7380 */ + Math.Round(_008A_009D_009B * 10000.0) / 10000.0 + "," /* string-offset:704 */,
				"TAS , " /* string-offset:7384 */ + Math.Round(_008A_009D_009A * 100.0) / 100.0 + ", km/h" /* string-offset:7368 */,
				"WindSpeed , " /* string-offset:7388 */ + Math.Round(_008A_009D_0098 * 100.0) / 100.0 + ", km/h" /* string-offset:7368 */,
				"BankAngle , " /* string-offset:7392 */ + _008A_009D_0097 + ",°" /* string-offset:7396 */,
				"DraftAngle , " /* string-offset:7400 */ + Math.Round(_008A_009E_0086 * 180.0 / Math.PI * 100.0) / 100.0 + ",°" /* string-offset:7396 */,
				"R , " /* string-offset:7404 */ + Math.Round(_008A_009D_009C * 100.0) / 100.0 + ", °/s" /* string-offset:7408 */,
				"Radius , " /* string-offset:7412 */ + Math.Round(_008A_009D_009D) + ", m" /* string-offset:7376 */,
				"Esita , " /* string-offset:7416 */ + Math.Round(10.0 * _008A_009D_009E * Math.PI / 180.0) / 10.0 + ", m /°" /* string-offset:7420 */,
				"E45 , " /* string-offset:7424 */ + Math.Round(Math.PI / 4.0 * _008A_009D_009E) + ", m " /* string-offset:7428 */,
				"E90 , " /* string-offset:7432 */ + Math.Round(Math.PI / 2.0 * _008A_009D_009E) + ", m " /* string-offset:7428 */,
				"E135 , " /* string-offset:7436 */ + Math.Round(Math.PI * 3.0 / 4.0 * _008A_009D_009E) + ", m " /* string-offset:7428 */,
				"E180 , " /* string-offset:7440 */ + Math.Round(Math.PI * _008A_009D_009E) + ", m " /* string-offset:7428 */,
				"E235 , " /* string-offset:7444 */ + Math.Round(4.101523742186674 * _008A_009D_009E) + ", m " /* string-offset:7428 */,
				"C6 = (v+w)*6 , " /* string-offset:7448 */ + Math.Round((_008A_009D_009A + _008A_009D_0098) / 0.6) + ", m " /* string-offset:7428 */
			};
		}

// Original MethodDef: 0x06000797; Original RVA: 0xC42F0; Processed MethodDef: 0x06000796; Evidence: TurnInput.source.txt:81814 + independent IL (decompilation/recovery, not runtime).
		static TurnInput()
		{

			// Host licensing not executed in independent arithmetic recovery.
		}

// Original MethodDef: 0x06000798; Original RVA: 0xC430C; Processed MethodDef: 0x06000797; Evidence: TurnInput.source.txt:81819 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089h()
		{

			return true;
		}

// Original MethodDef: 0x06000799; Original RVA: 0xC4318; Processed MethodDef: 0x06000798; Evidence: TurnInput.source.txt:81824 + independent IL (decompilation/recovery, not runtime).
		internal static bool _0089i()
		{

			return false;
		}
	}
}
