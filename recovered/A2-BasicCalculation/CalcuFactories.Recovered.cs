using System;
// Direct recovery of six existing factories, not a new domain-model design.
// L1 processed --/--.cs:75859–75994; token/RVA below refer to original assembly.
public static class CalcuFactoryRecovered {
    // 0x0600069A / 0xB9604
    public static CalcuLineRecovered Faf(double x,double y,double angle,double intermediate,double faf,double thr,double gp,double rdh,double distance) {
        return new CalcuLineRecovered { Kind=1,CenterX=x,CenterY=y,CenterZ=0,Direction=angle,Length=20000,
            Description=string.Format("FAF-THR: {0:F1}km",distance/1000),
            Parameters=new CalcuParametersRecovered { IntermediateLength=intermediate,FafAltitude=faf,ThrElevation=thr,FafGp=gp,Rdh=rdh,FafThrDistance=distance } };
    }
    // 0x0600069B / 0xB96B8
    public static CalcuLineRecovered Npa(double x,double y,double angle,double tas,double ias,double wind,double altitude,double temperature,double time,double distance) {
        return new CalcuLineRecovered { Kind=3,CenterX=x,CenterY=y,CenterZ=0,Direction=angle,Length=12000,Description="NPA SOC",
            Parameters=new CalcuParametersRecovered { Tas=tas,IAS=ias,WindSpeed=wind,Altitude=altitude,Temperature=temperature,SecondsNpa=time,NpaDistance=distance } };
    }
    // 0x0600069C / 0xB9760
    public static CalcuLineRecovered Pa(double x,double y,double angle,string category,double gp,double xz,double dh,double elevation,double hlm,double hlr,double correction,double distance) {
        return new CalcuLineRecovered { Kind=4,CenterX=x,CenterY=y,CenterZ=0,Direction=angle,Length=12000,Description="CAT "+category+" SOC",
            Parameters=new CalcuParametersRecovered { Category=category,PaGp=gp,Xz=xz,Dh=dh,Elevation=elevation,Hlm=hlm,Hlr=hlr,HlCorrection=correction,ThrSocDistance=distance } };
    }
    // 0x0600069D / 0xB9828
    public static CalcuLineRecovered MissedTp(double x,double y,double angle,double start,double end,double gradient,double distance) {
        return new CalcuLineRecovered { Kind=5,CenterX=x,CenterY=y,CenterZ=0,Direction=angle,Length=20000,
            Description=string.Format("SOC-TP: {0:F1}km",distance/1000),
            Parameters=new CalcuParametersRecovered { StartAltitude=start,EndAltitude=end,Gradient=gradient,TpDistance=distance } };
    }
    // 0x0600069E / 0xB98CC
    public static CalcuLineRecovered DepartureTp(double x,double y,double angle,double start,double end,double gradient,double distance) {
        return new CalcuLineRecovered { Kind=6,CenterX=x,CenterY=y,CenterZ=0,Direction=angle,Length=20000,
            Description=string.Format("DER-TP: {0:F1}km",distance/1000),
            Parameters=new CalcuParametersRecovered { StartAltitude=start,EndAltitude=end,Gradient=gradient,TpDistance=distance } };
    }
    // 0x0600069F / 0xB9970. The later writer replaces 10000 with actual line length.
    public static CalcuLineRecovered C(double x,double y,double angle,double time,double distance) {
        return new CalcuLineRecovered { Kind=7,CenterX=x,CenterY=y,CenterZ=0,Direction=angle,Length=10000,
            Description=string.Format("C类计时: {0}s",time),Parameters=new CalcuParametersRecovered { SecondsC=time,CDistance=distance } };
    }
}
