// A2 dependency: computational body and input reader only, no control designer.
#if AUTOCAD
using System;
using System.Windows.Forms;
public sealed class TurnParametersRecovered {
    public double IAS,Altitude,Bank,Wind,Temperature,TAS,K,Rate,Radius,WindRadius,Drift;
    // --/--.cs:81748, original06000794/RVAC3820 processed793.
    public TurnParametersRecovered(double ias=380,double altitude=600,double bank=25,double wind=56,double temperature=15) {
        IAS=ias;Altitude=altitude;Bank=bank;Wind=wind;Temperature=temperature;
        K=171233*Math.Sqrt(288+temperature-.006496*altitude)/Math.Pow(288-.006496*altitude,2.628);
        TAS=IAS*K;Rate=Math.Min(6355*Math.Tan(Bank*Math.PI/180)/(Math.PI*TAS),3);
        Radius=1000*TAS/(Math.PI*20*Rate);WindRadius=1000*Wind/(Math.PI*20*Rate);Drift=Math.Asin(Wind/TAS);
        Console.WriteLine(ToString());
    }
    public override string ToString() {
        return "=====Turn Parameters=====\nIAS = "+Math.Round(IAS*100)/100+" km/h\nAltitude = "+Math.Round(Altitude*100)/100+
            " m\nk = "+Math.Round(K*10000)/10000+"\nTAS = "+Math.Round(TAS*100)/100+" km/h\nWindSpeed = "+Math.Round(Wind*100)/100+
            " km/h\nBankAngle = "+Bank+"°\nDraftAngle = "+Math.Round(Drift*180/Math.PI*100)/100+"°\nR = "+Math.Round(Rate*100)/100+
            " °/s\nRadius = "+Math.Round(Radius)+" m\nEsita = "+Math.Round(10*WindRadius*Math.PI/180)/10+
            " m /°\nE45 = "+Math.Round(Math.PI/4*WindRadius)+" m \nE90 = "+Math.Round(Math.PI/2*WindRadius)+
            " m \nE135 = "+Math.Round(Math.PI*3/4*WindRadius)+" m \nE180 = "+Math.Round(Math.PI*WindRadius)+
            " m \nE235 = "+Math.Round(4.101523742186674*WindRadius)+" m \nC6 = (v+w)*6 = "+Math.Round((TAS+Wind)/.6)+" m \n";
    }
}
public partial class TurnParameterInputRecovered:UserControl {
    // Original fields: 0093 IAS,0094 altitude,0091 bank,008F temp,008E wind.
    public TextBox IAS,Altitude,Bank,Temperature,Wind;
    // These represent the two existing custom selectors' _008D_0089 properties.
    // TODO-RE: reattach selector events/designer, not a fabricated checkbox layout.
    public bool IasKnots,WindKnots;
    // --/--.cs:85141 original06000855/RVACA6B8 processed854.
    public TurnParametersRecovered Read() {
        try {
            double ias=Convert.ToDouble(IAS.Text),alt=Convert.ToDouble(Altitude.Text),bank=Convert.ToDouble(Bank.Text);
            double temperature=Convert.ToDouble(Temperature.Text),wind=Convert.ToDouble(Wind.Text);
            if(IasKnots) ias*=1.852;if(WindKnots) wind*=1.852;
            return new TurnParametersRecovered(ias,alt,bank,wind,temperature);
        } catch {
            MessageBox.Show("参数输入有误，请检查。","\n输入错误",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);return null;
        }
    }
}
#endif
