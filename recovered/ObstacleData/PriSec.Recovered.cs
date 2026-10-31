using System;
using System.Collections.Generic;
// Projection of _008A_008B fields consumed by these two methods only.
public sealed class PriSecObstacleRecovered {
    public double X,Y,Z,MOC,OCA;
    public string ID,Name,Area;
}
public static class PriSecRecovered {
    // -/-.cs:3103/3116. Preserve atan2 and distance arithmetic, including Z difference.
    public static double[] Local(double sx,double sy,double sz,double ex,double ey,double x,double y,double z) {
        double distance=Math.Sqrt(Math.Pow(y-sy,2)+Math.Pow(x-sx,2));
        double angle=Math.Atan2(y-sy,x-sx)-Math.Atan2(sy-ey,sx-ex);
        return new[]{distance*Math.Cos(angle),distance*Math.Sin(angle),z-sz};
    }
    // --/--.cs:83906/83911/83982/83991. This is the old line helper's
    // coefficient and safe-divide behavior, not a new interpolation convention.
    private static double LineY(double x0,double y0,double x1,double y1,double x) {
        double a=y1-y0,b=x0-x1,c=y0*(x1-x0)-x0*(y1-y0);
        double numerator=-c-a*x;
        return b!=0?numerator/b:(numerator>0?1000000:-1000000);
    }
    // Original tokens/RVA in evidence.md: processed330 IF and331 regular,
    // --/--.cs:29214/29257. Two original methods share arithmetic but DIFFER
    // in endpoint tests and the primary line's END width. No clamping added.
    // Heights are original P1/P4; their Z in the temporary line points is unused.
    public static List<PriSecObstacleRecovered> Evaluate(List<PriSecObstacleRecovered> points,
        double startHeight,double startWidth,double startMoc,double endHeight,double endWidth,double endMoc,double length,bool intermediate) {
        var result=new List<PriSecObstacleRecovered>();double maximum=startWidth>endWidth?startWidth:endWidth;
        foreach(var point in points) {
            double y=Math.Abs(point.Y);
            bool within=intermediate?(point.X<=0 && point.X>=-length):(point.X<0 && point.X>-length);
            if(!within || !(y<maximum)) continue;
            double moc=endMoc+(startMoc-endMoc)*(length+point.X)/length;
            double primary=LineY(0,startWidth/2,-length,intermediate?endWidth:endWidth/2,point.X);
            double outer=LineY(0,startWidth,-length,endWidth,point.X);
            if(y<=primary) {
                point.MOC=moc;point.OCA=moc+point.Z;point.Area="主区";result.Add(point);
            } else if(y<=outer) {
                point.MOC=outer-primary==0?moc:moc*(outer-y)/(outer-primary);
                point.OCA=point.MOC+point.Z;point.Area="副区";result.Add(point);
            }
        }
        return result;
    }
}
