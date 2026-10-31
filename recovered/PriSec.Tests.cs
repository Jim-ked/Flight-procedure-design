using System;
using System.Collections.Generic;
class PriSecTests {
    static int count;
    static void Check(bool ok,string label) { if(!ok) throw new Exception(label);count++; }
    static void Equal(double actual,double expected,string label) { Check(!double.IsNaN(actual) && Math.Abs(actual-expected)<1e-8,label); }
    static PriSecObstacleRecovered Point(double x,double y,double z) { return new PriSecObstacleRecovered { X=x,Y=y,Z=z,ID="1",Name="P" }; }
    static List<PriSecObstacleRecovered> Evaluate(bool intermediate,params PriSecObstacleRecovered[] points) {
        return PriSecRecovered.Evaluate(new List<PriSecObstacleRecovered>(points),1000,200,100,800,100,50,1000,intermediate);
    }
    static int Main() {
        try { Run();return 0; } catch(Exception ex) { Console.WriteLine("FAIL: "+ex.Message);return 1; }
    }
    static void Run() {
        // Non-IF: at halfway primary=75, outer=150, MOC=75.
        var primary=Evaluate(false,Point(-500,75,200));Check(primary.Count==1,"primary boundary included");Equal(primary[0].MOC,75,"linear MOC");Equal(primary[0].OCA,275,"absolute Z plus MOC");Check(primary[0].Area=="主区","primary label");
        var secondary=Evaluate(false,Point(-500,112.5,200));Equal(secondary[0].MOC,37.5,"secondary taper");Equal(secondary[0].OCA,237.5,"secondary OCA");Check(secondary[0].Area=="副区","secondary label");
        Equal(Evaluate(false,Point(-500,-112.5,200))[0].MOC,37.5,"both track sides");
        Check(Evaluate(false,Point(0,50,200),Point(-1000,25,200)).Count==0,"regular excludes both end stations");
        Check(Evaluate(true,Point(0,50,200),Point(-1000,25,200)).Count==2,"IF includes both end stations");
        // IF primary end is FULL end width (not half); halfway primary=100.
        Check(Evaluate(true,Point(-500,100,200))[0].Area=="主区","IF primary end width");
        Equal(Evaluate(true,Point(-500,125,200))[0].MOC,37.5,"IF secondary taper");
        Equal(Evaluate(false,Point(-500,150,200))[0].MOC,0,"outer line included when below coarse maximum");
        Check(Evaluate(true,Point(0,200,200)).Count==0,"coarse absY less-than max width excludes exact maximum");
        Check(Evaluate(false,Point(1,0,200),Point(-1001,0,200)).Count==0,"outside along track excluded");
        var local=PriSecRecovered.Local(10,20,100,1010,20,1010,30,150);
        Equal(local[0],-1000,"reverse axis local X");Equal(local[1],-10,"reverse axis local Y");Equal(local[2],50,"helper subtracts origin Z");
        var degenerate=PriSecRecovered.Evaluate(new List<PriSecObstacleRecovered>{Point(0,0,200)},100,200,100,100,100,50,0,true);
        Check(degenerate.Count==0,"coincident station line helper yields negative sentinel, no invented guard");
        Console.WriteLine("PASS "+count+" primary/secondary checks; recovered source only, no target DLL execution.");
    }
}
