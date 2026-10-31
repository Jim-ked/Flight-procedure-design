using System;

namespace Recovered.Geometry
{
    // Mechanical port of original P793 / processed 0x06000793, RVA 0xC3820.
    public sealed class TurnParameterRecovered
    {
        public readonly double IAS, Altitude, Temperature, Bank, Wind;
        public readonly double K, TAS, Rate, Radius, WindRadius, Drift;
        public TurnParameterRecovered(double ias, double altitude, double temperature,
                                      double bank, double wind)
        {
            IAS = ias; Altitude = altitude; Temperature = temperature;
            Bank = bank; Wind = wind;
            K = 171233.0 * Math.Sqrt(288.0 + temperature - 0.006496 * altitude) /
                Math.Pow(288.0 - 0.006496 * altitude, 2.628);
            TAS = IAS * K;
            Rate = Math.Min(6355.0 * Math.Tan(bank * Math.PI / 180.0) /
                            (Math.PI * TAS), 3.0);
            Radius = 1000.0 * TAS / (Math.PI * 20.0 * Rate);
            WindRadius = 1000.0 * Wind / (Math.PI * 20.0 * Rate);
            Drift = Math.Asin(Wind / TAS);
        }
        public double E(double degrees) { return degrees * Math.PI / 180.0 * WindRadius; }
        public double C6() { return (TAS + Wind) / 0.6; }
    }
}
