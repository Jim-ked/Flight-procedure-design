// Result fields correspond directly to _008A_0089 getter/setter pairs.
// Original MethodDef: 0x060003E9–0x060003FA (use evidence method map for exact pair).
// Evidence: --/--.cs:41377–41560; no new common MOC formula is introduced.
public sealed class DepartureEvaluation:RePoint {
    public string Area,Category;public double D0,Dr,MOC,OCA,AllowableAltitude,RequiredGradient;
    public DepartureEvaluation(RePoint p):base(p.X,p.Y,p.Z) {ID=p.ID;Name=p.Name;}
}
