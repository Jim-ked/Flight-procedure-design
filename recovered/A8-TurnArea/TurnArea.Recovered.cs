using System;
// Original MethodDef: 0x0600025F; Original RVA: 0x292F8.
// Evidence: processed25E --/--.cs:12402-12474; reuse Round1 KK and frame arithmetic.
public sealed class TurnAreaRecovered {
    public RePoint Left,Right;public double Length,Ds,Gradient,Moc;public bool Specified;
    public TurnAreaRecovered(RePoint left,RePoint right,double ds,double gradient,double moc,string mode) {
        Left=left;Right=right;Ds=ds;Gradient=gradient;Moc=moc;Specified=mode=="指定高度";Length=RePoint.Distance(left,right);
    }
    public DepartureEvaluation Evaluate(RePoint point) {
        var p=PriSecRecovered.Local(Left.X,Left.Y,Left.Z,Right.X,Right.Y,point.X,point.Y,point.Z);
        var v=ObstacleRecovered.KkEvaluation(p[0],p[1],point.Z,Length,Left.Z,Ds,Gradient,Moc,false,Specified);
        return new DepartureEvaluation(new RePoint(p[0],p[1],point.Z){ID=point.ID,Name=point.Name}) {
            Area=p[1]<0?"KK'线外":"KK'线内",Dr=Ds,D0=v[0],MOC=v[1],OCA=v[2],AllowableAltitude=v[3],RequiredGradient=v[4]
        };
    }
    // Original MethodDef: 0x06000260; Original RVA: 0x296C0.
    // Evidence: processed25F IL DistanceTo (three dimensions), UI rounds to 2 digits.
    public static double PickedDs(RePoint a,RePoint b) {return Math.Sqrt(Math.Pow(a.X-b.X,2)+Math.Pow(a.Y-b.Y,2)+Math.Pow(a.Z-b.Z,2));}
}
