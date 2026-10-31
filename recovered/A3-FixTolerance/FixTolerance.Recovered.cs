using System;
// L1/L2 numerical slices of the two original CAD events; not a two-facility solver.
// Native event slices are in FixToleranceForm.Events.Recovered.cs; not host-verified.
public static class FixToleranceRecovered
{
    // Original 0x0600020D RVA 0x19AE0; processed 0x0600020C.
    // The original uses mutually exclusive RadioButtons; null means no matching assignment.
    public static double? AccuracyOrUnchanged(string facility,bool guide) {
        if (facility=="VOR") return guide?5.2:4.5;
        if (facility=="ILS") return guide?2.4:1.4;
        if (facility=="NDB") return guide?6.9:6.2;
        return null;
    }
    // Analyst convenience for valid radio selection only; not an additional original method.
    public static double Accuracy(string facility,bool guide) { return AccuracyOrUnchanged(facility,guide).Value; }
    // Original 0x0600020F RVA 0x19CD4; processed 0x0600020E.
    public static double DmeError(double distanceMetres) { return distanceMetres*0.0125+460.0; }
    // Same original event; [early axial distance, late axial distance].
    // This calculation is also executed when the DME drawing checkbox is OFF.
    public static double[] LimitDistances(double distanceMetres,double accuracyDegrees) {
        double error=distanceMetres*0.0125+460.0;
        return new double[]{(distanceMetres-error)*Math.Cos(accuracyDegrees*Math.PI/180.0),distanceMetres+error};
    }
    // Original 0x06000212 RVA 0x1A628; processed 0x06000211.
    // The handler draws nothing for height<=0; this method is the arithmetic slice only.
    public static double BlindRadius(double height,double halfAngleDegrees) { return height*Math.Tan(halfAngleDegrees*Math.PI/180.0); }
    // Same original event. Two endpoint pairs for the optional track-tolerance polylines.
    public static double[,] BlindTrackEndpoints(double x,double y,double radius,double heading,bool vor,bool ndb) {
        double small=0,large=0;
        if (vor) { small=5;large=15; }
        if (ndb) { small=15;large=25; }
        double k=Math.PI/180.0;
        double[] angles={heading+large*k+Math.PI,heading-small*k,heading-large*k+Math.PI,heading+small*k};
        double[,] result=new double[4,2];
        for (int i=0;i<4;i++) { result[i,0]=x+radius*Math.Cos(angles[i]); result[i,1]=y+radius*Math.Sin(angles[i]); }
        return result;
    }
}
