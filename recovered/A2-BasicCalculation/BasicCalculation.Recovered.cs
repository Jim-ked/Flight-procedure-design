using System;

// Numeric portions of FormCalcu, extracted from UI handlers; NOT a replacement plugin.
// L1 Direct: processed C#; L2 IL: tokens/evidence manifest. No original runtime test.
// Input parsing and TextBox side effects are documented separately, not silently reproduced here.
public static class BasicCalculationRecovered
{
    // Arithmetic slice of original 0x06000794 RVA 0xC3820 (protected stub),
    // recovered body processed 0x06000793; --/--.cs:81771.
    // L1 processed code, not a claim that the raw stub contains this formula.
    public static double TrueAirspeed(double iasKmh,double altitudeMetres,double temperatureDeviation) {
        double k=171233.0*Math.Sqrt(288.0+temperatureDeviation-0.006496*altitudeMetres)
            /Math.Pow(288.0-0.006496*altitudeMetres,2.628);
        return iasKmh*k;
    }
    // Original 0x06000855 RVA 0xCA6B8; processed 0x06000854, --/--.cs:85141;
    // IAS and wind have independent kt selectors. See evidence.md for original mapping.
    public static double SpeedKmh(double speed,bool knots) { return knots?speed*1.852:speed; }
    // Original 0x06000230 RVA 0x1FAC0; processed 0x0600022F RVA 0x1A9D8.
    // UI displays Math.Round(result), but CAD receives the unrounded return value.
    public static double FafDistance(double fafAltitude,double thrElevation,double rdh,double gpDegrees) {
        return (fafAltitude-rdh-thrElevation)/Math.Tan(gpDegrees*Math.PI/180.0);
    }
    // Original 0x06000234 RVA 0x1FFE8; processed 0x06000233 RVA 0x1AD50.
    // seconds is textBoxNTime, NOT a hardcoded 18 or separated 3+15.
    public static double NonPrecisionSoc(double tasKmh,double windKmh,double seconds) {
        return (tasKmh+windKmh)*seconds/3.6;
    }
    // Original 0x06000238 RVA 0x2056C; processed 0x06000237 RVA 0x1B0D8.
    // Original displays an alert when HL==0; return -1 is preserved.
    // CAD uses the NEGATIVE of this rounded return distance along the picked direction.
    public static double PrecisionSoc(double dh,double correctedHl,double gpDegrees,double xz) {
        if (correctedHl==0.0) return -1.0;
        return Math.Round((dh-correctedHl)/Math.Tan(gpDegrees*Math.PI/180.0)+xz);
    }
    // Original 0x0600023A RVA 0x2084C; processed 0x06000239 RVA 0x1B2F0.
    // Output is the value written to HLcor TextBox; both rounds are intentional.
    public static double HlCorrection(double hlm,double hlr,double airportElevation) {
        if (airportElevation>900.0) {
            double value=Math.Round(hlm+hlr*0.02*airportElevation/300.0,2);
            return Math.Round(value,1);
        }
        return hlm;
    }
    // Original 0x0600023C RVA 0x20E90; processed 0x0600023B RVA 0x1B708.
    public static double MissedTp(double socAltitude,double turnAltitude,double gradientPercent) {
        return 100.0*(turnAltitude-socAltitude)/gradientPercent;
    }
    // Original 0x0600023F RVA 0x214E4; processed 0x0600023E RVA 0x1BBE8.
    public static double DepartureTp(double derElevation,double turnAltitude,double pdgPercent) {
        return 100.0*(turnAltitude-derElevation-5.0)/pdgPercent;
    }
    // Original 0x06000242 RVA 0x21A28; processed 0x06000241 RVA 0x1BF04.
    // seconds is textBoxCTime; not a hardcoded 6 or separately evaluated 3+3.
    public static double CTolerance(double tasKmh,double windKmh,double seconds) {
        return (tasKmh+windKmh)*seconds/3.6;
    }
}
