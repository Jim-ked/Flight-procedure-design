using System;
// L1/L2 extracted computational slices, not a new obstacle domain architecture.
public static class ObstacleRecovered
{
    // Original 0x0600034A RVA 0x4EC88; processed 0x06000349 RVA 0x4175C.
    // Actual handler makes new Random() once, then draws radius/angle/Z samples in this order.
    // Taking the three samples as inputs permits deterministic tests without changing their law.
    public static double[] RandomCoordinates(double x,double y,double rangeMetres,double zMin,double zMax,
                                             double radiusSample,double angleSample,double heightSample) {
        double radius=rangeMetres*radiusSample;
        double angle=Math.PI*2.0*angleSample;
        double z=Math.Round((zMax-zMin)*heightSample+zMin,2);
        return new double[]{radius*Math.Cos(angle)+x,radius*Math.Sin(angle)+y,z};
    }
    // Same original handler: no short-string guard is added to generation.
    public static string DerivedName(string objectIdText) { return "P"+objectIdText.Substring(objectIdText.Length-5,4); }
    // Original DBPoint parser 0x06000130 RVA 0x10D00; processed 0x0600012F RVA 0x10648.
    // EntityName is read from WsEntityFrame by the native reader; exceptions are swallowed there.
    // XYZ remains DBPoint.Position, ID is caller-supplied ordinal text, not ObjectId.
    public static string ParsedName(string entityName,string objectIdText) {
        if (!string.IsNullOrWhiteSpace(entityName)) return entityName;
        if (objectIdText.Length>6) return "P"+objectIdText.Substring(objectIdText.Length-5,4);
        return "";
    }
    // Original 0x06000003 RVA 0x2164 (protected stub); processed 0x06000002 RVA 0x710C.
    // -/-.cs:95. Pure slice of KK evaluator, NOT a universal area/MOC implementation.
    // Input XY is already in KK local coordinates, Z is restored absolute obstacle altitude.
    // Return [d0, MOC, OCA, PDA, minimum gradient as fraction]. Area text is Y<0 ?
    // "KK'线外" : "KK'线内"; neither side is excluded from evaluation.
    public static double[] KkEvaluation(double x,double y,double z,double length,double baseAltitude,
                                        double dr,double gradient,double minimumMoc,bool variableMoc,bool specifiedAltitude) {
        double d0;
        if(x < -length) d0=Math.Sqrt((x+length)*(x+length)+y*y);
        else if(x < 0.0) d0=Math.Abs(y);
        else d0=Math.Sqrt(x*x+y*y);
        double moc=variableMoc?Math.Max((dr+d0)*0.008,minimumMoc):minimumMoc;
        double oca=z+moc;
        double pda,required;
        if(specifiedAltitude) {
            pda=d0*gradient+baseAltitude;
            required=(oca-baseAltitude)/d0;
        } else if(variableMoc) {
            pda=(dr+d0)*gradient+baseAltitude+5.0;
            required=(oca-baseAltitude-5.0)/(d0+dr);
        } else {
            pda=(dr+d0)*gradient+baseAltitude;
            required=(oca-baseAltitude)/(d0+dr);
        }
        return new double[]{d0,moc,oca,pda,required};
    }
    // Native bindings now live in ObstacleCad/EntityFrameCad and the partial Form
    // files (uncompiled). A9 is separate in PriSec.Recovered.cs. Other evaluators'
    // area/MOC/OCA paths are not represented by these slices; no invented common evaluator.
}
