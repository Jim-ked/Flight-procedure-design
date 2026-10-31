using System;
using System.Collections.Generic;
using Recovered.A6;
namespace Recovered.B3 {
// Extracted arithmetic/record adapters, not a new missed approach or UI engine.
public static class RecoveryMessages {
 public static readonly List<string> Messages=new List<string>();
 public static void Show(string text){Messages.Add(text);}
 public static void Discard(double value){}
}
public static class RnpApchMissed {
 // P48A, --/--.cs:47448. P793 only supplies TAS here; bank is fixed15.
 public static double LnavSoc(double ias,double altitude,double wind,double temperature,double seconds,bool iasKnots,bool windKnots){
  if(iasKnots)ias*=1.852;if(windKnots)wind*=1.852;
  var turn=new TurnInput(ias,altitude,15.0,wind,temperature);
  return Math.Round((turn._008A_009D_009A+wind)*seconds/3.6+444.0);
 }
 // P489, --/--.cs:47434, round to displayed integer; percent input.
 public static double SocToTp(double socHeight,double turnHeight,double gradientPercent){return Math.Round(100.0*(turnHeight-socHeight)/gradientPercent);}
 // P482: uses textBoxAdElev, not separate textBoxElev; two decimals, no GP term.
 public static double HlDisplay(double hlm,double hlr,double adElevation){return adElevation>900?Math.Round(hlm+hlr*.02*adElevation/300.0,2):hlm;}
}
}
