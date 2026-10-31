using System;
using System.Collections.Generic;
// Original MethodDef/RVA for each port are recorded below and in generated bodies.
public partial class DmeArcRecovered {
    public sealed class InputValue {public string Text="";public bool Checked;
#if ACAD2026_TEST
        public System.Windows.Forms.TextBox NativeControl;
#endif
        public InputValue(){}public InputValue(double n){Text=n.ToString();}}
    sealed class InputCheck {public InputValue Value;public string Message;public InputCheck(InputValue v,string m){Value=v;Message=m;}}
    InputValue _0087_008F_009A,_0087_008F_009B,_0087_008F_0093,_0087_008F_0094,_0087_008F_008D,_0087_008F_008C;
    InputValue _0087_008F_009E=new InputValue(300),_0087_0090_008A=new InputValue(),_0087_0090_0089=new InputValue();
    InputValue _0087_008F_0089=new InputValue(),_0087_008F_009D=new InputValue();
    List<RePoint> _0087_008E_009B;public List<DmeEvaluation> Results=new List<DmeEvaluation>();
    public ReCadRecords Drawing=new ReCadRecords();public List<string> Diagnostics=new List<string>();public Action<string> DiagnosticOutput;
    public DmeArcRecovered(RePoint o,RePoint ifPoint,RePoint iafDirection,string suffix="",bool label=false) {
        _0087_008F_009A=new InputValue(o.X);_0087_008F_009B=new InputValue(o.Y);
        _0087_008F_0093=new InputValue(ifPoint.X);_0087_008F_0094=new InputValue(ifPoint.Y);
        _0087_008F_008D=new InputValue(iafDirection.X);_0087_008F_008C=new InputValue(iafDirection.Y);
        _0087_0090_008A.Text=suffix;_0087_0090_0089.Checked=label;
    }
    public string MocInput {get{return _0087_008F_009E.Text;}set{_0087_008F_009E.Text=value;}}
    public string EvaluatedText {get{return _0087_008F_0089.Text;}}public string InsideText {get{return _0087_008F_009D.Text;}}
    public void Draw(){Drawing=new ReCadRecords();DrawCore();}
    public List<DmeEvaluation> Evaluate(IEnumerable<RePoint> points){Results=new List<DmeEvaluation>();_0087_008E_009B=new List<RePoint>(points);EvaluateCore();return Results;}
    static bool TrueHelper(){return true;}static bool FalseHelper(){return false;}
    // UI validation is a pure predicate here; original focus/message side effects remain in CAD adapter.
    static bool CheckInput(InputValue v,string message){
#if ACAD2026_TEST
        if(v.NativeControl!=null)return CadSelectionRecovered.CheckInput(v.NativeControl,message);
#endif
        double n;return !string.IsNullOrWhiteSpace(v.Text)&&double.TryParse(v.Text,out n);
    }
    static RePoint Imported(RePoint p,string ordinal){return new RePoint(p.X,p.Y,p.Z){ID=p.ID??ordinal,Name=p.Name};}
    void Capture(object entity,object database){Drawing.Entities.Add(entity);}
    // Original MethodDef: 0x060002DD; Original RVA: 0x3A2B0 (processed2DC).
    public static double Bulge(double a,double b){if(a<0)a+=2*Math.PI;if(b<0)b+=2*Math.PI;double d=a<b?(b-a<=Math.PI?b-a:2*Math.PI+a-b):(a-b<=Math.PI?a-b:2*Math.PI+b-a);return (1-Math.Cos(d/2))/Math.Sin(d/2);}
    // Original MethodDef: 0x060002E0; Original RVA: 0x3B294 (processed2DF).
    public static double Normalize(double a){if(a<0)a+=2*Math.PI;else if(a>2*Math.PI)a-=2*Math.PI;return a;}
    // Original MethodDef: 0x060002E2; Original RVA: 0x3B4F0 (processed2E1).
    // Evidence: source21318-21402; endpoint inclusion and asymmetric end-cap MOC retained.
    public static RePoint Sector(RePoint p,RePoint center,double r,double a,double b,double width,bool symmetric){
        double angle=Normalize(Math.Atan2(p.Y-center.Y,p.X-center.X));bool inside=a<b?(angle>=a&&angle<=b):(angle>=a||angle<=b);
        if(inside){double d=Math.Sqrt(Math.Pow(p.X-center.X,2)+Math.Pow(p.Y-center.Y,2));
            if(!(d>r+width)&&d>=r-width){
                if(!symmetric){if(d>=r+width/2){p.Name="副区";p.Z=2*(width-d+r)/width;}else{p.Name="主区";p.Z=1;}}
                else{double error=Math.Abs(d-r);if(error<=width/2){p.Name="主区";p.Z=1;}else{p.Name="副区";p.Z=2*(width-error)/width;}}
            }else p.Name="out";
        }else p.Name="out";return p;
    }
    // Original MethodDef: 0x060002E1; Original RVA: 0x3B37C (processed2E0).
    void Angles(double a,double b,double alpha,double beta){string message="angA  "+Math.Round(a*180/Math.PI)+"\n angB  "+Math.Round(b*180/Math.PI)+"\n alpha  "+Math.Round(alpha*180/Math.PI)+"\n beta  "+Math.Round(beta*180/Math.PI);Diagnostics.Add(message);if(DiagnosticOutput!=null)DiagnosticOutput(message);}
}
public sealed class DmeEvaluation:RePoint {
    public string Area;public double MOC,OCA,RoundedOca;
    public DmeEvaluation(RePoint p):base(p.X,p.Y,p.Z){ID=p.ID;Name=p.Name;}
}
