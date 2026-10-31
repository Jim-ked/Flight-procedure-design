using System;
class RecoveryTests
{
    static int count;
    static void Equal(double actual,double expected,string name) {
        if (Math.Abs(actual-expected)>1e-8) throw new Exception(name+": "+actual+" != "+expected);
        count++;
    }
    static void Main() {
        Equal(BasicCalculationRecovered.TrueAirspeed(345,600,15),364.405116191195,"TAS source constants");
        Equal(BasicCalculationRecovered.SpeedKmh(100,true),185.2,"knots conversion");
        Equal(BasicCalculationRecovered.SpeedKmh(100,false),100,"kmh unchanged");
        Equal(BasicCalculationRecovered.FafDistance(1000,100,15,45),885,"FAF degrees and RDH");
        Equal(BasicCalculationRecovered.NonPrecisionSoc(360,19,18),1895,"SOC UI time");
        Equal(BasicCalculationRecovered.NonPrecisionSoc(360,19,20),379*20/3.6,"SOC time is not hardcoded");
        Equal(BasicCalculationRecovered.CTolerance(360,56,6),416*6/3.6,"C UI time");
        Equal(BasicCalculationRecovered.HlCorrection(49,26,1800),52.1,"HL double rounding");
        Equal(BasicCalculationRecovered.HlCorrection(49,26,900),49,"HL threshold strict greater");
        Equal(BasicCalculationRecovered.PrecisionSoc(100,0,3,-900),-1,"HL zero sentinel");
        Equal(BasicCalculationRecovered.MissedTp(100,300,2.5),8000,"Missed gradient percent");
        Equal(BasicCalculationRecovered.DepartureTp(100,305,2.5),8000,"Departure five metres");
        if (!double.IsPositiveInfinity(BasicCalculationRecovered.DepartureTp(100,305,0))) throw new Exception("Do not invent zero-gradient clamp");
        Equal(FixToleranceRecovered.Accuracy("VOR",true),5.2,"VOR guide");
        Equal(FixToleranceRecovered.Accuracy("ILS",false),1.4,"ILS nonguide");
        Equal(FixToleranceRecovered.DmeError(10000),585,"DME error");
        double[] kk=FixToleranceRecovered.LimitDistances(10000,5.2);
        Equal(kk[1],10585,"late limit");
        Equal(FixToleranceRecovered.BlindRadius(1000,45),1000,"blind cone");
        double[] p=ObstacleRecovered.RandomCoordinates(100,200,1000,50,150,0.5,0.25,0.33333);
        Equal(p[0],100,"random X"); Equal(p[1],700,"random radius not sqrt uniform area"); Equal(p[2],83.33,"random Z rounding");
        if (ObstacleRecovered.DerivedName("(12345678)")!="P5678") throw new Exception("name suffix");
        double[] ev=ObstacleRecovered.KkEvaluation(-50,40,150,100,20,1000,0.025,50,false,true);
        Equal(ev[0],40,"KK distance inside segment projection");
        Equal(ev[2],200,"OCA is Z plus MOC");
        Equal(ev[3],21,"specified altitude excludes dr from PDA");
        Equal(ev[4],4.5,"minimum gradient unclamped");
        ev=ObstacleRecovered.KkEvaluation(-130,-40,150,100,20,1000,0.025,50,false,false);
        Equal(ev[0],50,"KK endpoint distance");
        Equal(ev[3],46.25,"nonheight constant MOC has no five metre addition");
        ev=ObstacleRecovered.KkEvaluation(30,40,150,100,20,1000,0.025,50,true,false);
        Equal(ev[3],51.25,"variable MOC nonheight five metre addition");
        string output="";
        XInfoRecovered.FormatValue(s=>output+=s,"App","{\"a\":1,\"b\":[2,{\"c\":3}]}");
        if(output!="App\n  a = 1\n  b\n    - 2\n    -\n      c = 3\n") throw new Exception("recursive format: "+output);
        Console.WriteLine("PASS "+count+" numeric checks, name, recursive formatter and zero-gradient behavior; recovered code only, NOT original runtime.");
    }
}
