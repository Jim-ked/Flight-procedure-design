using System;
using Recovered.Geometry;
using Recovered.Round3;

public static class Round3Tests
{
    static int n;
    static void Check(string name, bool ok)
    { n++; if (!ok) throw new Exception("FAIL " + name); Console.WriteLine("PASS " + name); }
    static bool Near(double a,double b,double e=1e-6) { return Math.Abs(a-b)<=e; }
    public static void Main()
    {
        var t = new TurnParameterRecovered(300,305,15,15,60);
        Check("turn TAS fixture", Near(t.TAS,312.32,0.02));
        Check("turn E90 linear", Near(t.E(90), Math.PI/2*t.WindRadius,1e-9));
        Check("turn C6", Near(t.C6(), (t.TAS+60)/.6,1e-9));
        var noWind = new WindSpiralRecovered(new Point2(0,0),0,0,0,1000,0,true);
        for (int i=0;i<=3;i++) {
            double a=i*Math.PI/6;
            var p=noWind.Point(a); var q=noWind.BaseCirclePoint(a);
            Check("no-wind point "+i, Near(p.X,q.X,1e-8)&&Near(p.Y,q.Y,1e-8));
        }
        Check("sample includes endpoint", noWind.Sample(0,Math.PI/2,0,30).Count==4);
        var right = new WindSpiralRecovered(new Point2(0,0),0,0,0,1000,0,true);
        var left = new WindSpiralRecovered(new Point2(0,0),0,0,0,1000,0,false);
        var rp=right.Point(Math.PI/3); var lp=left.Point(Math.PI/3);
        Check("left-right mirror", Near(rp.X,lp.X,1e-8)&&Near(rp.Y,-lp.Y,1e-8));
        var cross = new WindSpiralRecovered(new Point2(10,20),.4,5,550,2864,.19,true);
        Check("cross-wind finite", !double.IsNaN(cross.Point(Math.PI/2).X));
        Check("sample split nonempty", cross.SampleSplit(0,Math.PI,0,1,5).Count>1);
        double earliest, latest;
        TurnGeometryRecovered.FlyByEarliestLatest(2864,Math.PI/3,1482,5,2,312.32,60,out earliest,out latest);
        Check("B1 earliest", Near(earliest,1482+2864*Math.Tan(Math.PI/6),1e-9));
        Check("B1 latest", Near(latest,2864*Math.Tan(Math.PI/6)-1482-7*372.32/3.6,1e-9));
        TurnGeometryRecovered.FlyOverEarliestLatest(0,5,2,312.32,60,out earliest,out latest);
        Check("B2 ATT zero", Near(earliest,0)&&Near(latest,-7*372.32/3.6));
        double dir; var angle=TurnGeometryRecovered.TurnAngle(0,Math.PI/2,out dir);
        Check("turn angle 90", Near(angle,Math.PI/2)&&dir>0);
        Console.WriteLine("PASS " + n + " Round3 assertions; recovered code only.");
    }
}
