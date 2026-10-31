"""Deterministic mechanical port of evaluator; retain original goto labels/branch order."""
from pathlib import Path
import re,hashlib
ROOT=Path(__file__).resolve().parents[2];OUT=ROOT/'recovered/A7-Departure'
src=(OUT/'evidence/_008A_0095.source.txt').read_text(encoding='utf-8')
src='\n'.join(re.sub(r'^\d+: ', '',l) for l in src.splitlines())
method=src[src.index('\t\tpublic _008A_0089 _0088_0091_009E'):src.index('\t\tpublic void _0088_0092_0086')]
method=method.replace('public _008A_0089 _0088_0091_009E(_008A_0089 P_0)','public DepartureEvaluation Evaluate(RePoint input)')
pos=method.index('{')+1;method=method[:pos]+'\n var P_0=new DepartureEvaluation(input);'+method[pos:]
getters={'_0088_008E_0095':'Area','_0088_008E_009B':'D0','_0088_008E_009E':'Dr','_0088_008F_0088':'MOC','_0088_008F_008B':'OCA'}
setters={'_0088_008E_0096':'Area','_0088_008E_009C':'D0','_0088_008F_0086':'Dr','_0088_008F_0089':'MOC','_0088_008F_008C':'OCA','_0088_008F_008F':'AllowableAltitude','_0088_008F_0092':'RequiredGradient'}
for name,prop in getters.items():method=method.replace('P_0.'+name+'()','P_0.'+prop)
for name,prop in setters.items():
    prefix='P_0.'+name+'('
    while prefix in method:
        a=method.index(prefix);start=a+len(prefix);i=start;depth=1
        while depth:
            if method[i]=='(':depth+=1
            if method[i]==')':depth-=1
            i+=1
        method=method[:a]+'P_0.'+prop+' = '+method[start:i-1]+method[i:]
method=method.replace('_008F_008E._008B_0088_009E','RePoint.Distance').replace('_008F_008E','RePoint').replace('_008F_008C','ReLine')
for a,b in {'_008B_0088_008D':'Y','_008B_0088_0092':'Distance','_008B_0088_0094':'Angle','_008B_0088_008F':'Through','_008B_0088_0093':'Intersection'}.items():method=method.replace(a,b)
method=method.replace('_0087x()','TrueHelper()').replace('_0087y()','FalseHelper()')
header='''using System;
using System.Collections.Generic;
// Constructor Original MethodDef: 0x06000421; Original RVA: 0x65960.
// Evaluator Original MethodDef: 0x06000422; Original RVA: 0x65E14.
// Evidence: _008A_0095.source.txt:42815-43535 + processed420/421/422 IL.
// Evaluator is mechanically renamed, retaining all goto labels and original predicates.
public sealed class OmniDepartureRecovered {
 double _0088_0092_0087=150,_0088_0092_008B,_0088_0092_008E,_0088_0092_0090,_0088_0092_0091;
 RePoint _0088_0092_0093,_0088_0092_0094,_0088_0092_0095,_0088_0092_0096,_0088_0092_0097;
 ReLine _0088_0092_0098,_0088_0092_0099,_0088_0092_009A,_0088_0092_009B;
 public RePoint S {get{return _0088_0092_0093;}} public RePoint K {get{return _0088_0092_0095;}} public RePoint F {get{return _0088_0092_0096;}}
 public double Radius {get{return _0088_0092_008B;}}
 public List<List<RePoint>> Boundaries=new List<List<RePoint>>();
 public OmniDepartureRecovered(DepartureRunway runway,double baseAltitude,double tna,double finalAltitude,double gradient=.033,bool early=true) {
  _0088_0092_0090=baseAltitude;_0088_0092_0091=tna;_0088_0092_008E=gradient;
  double d1=115/gradient,d2=(tna-baseAltitude-120)/gradient;
  _0088_0092_0093=new RePoint(-runway.Length+600,150,baseAltitude+5);
  _0088_0092_0094=new RePoint(0,150,baseAltitude+5);
  _0088_0092_0095=new RePoint(d1,150+d1*Math.Tan(Math.PI/12),baseAltitude+120);
  _0088_0092_0096=new RePoint(d1+d2,K.Y+d2*Math.Tan(Math.PI/6),tna);
  _0088_0092_0098=new ReLine(S,_0088_0092_0094);_0088_0092_0099=new ReLine(_0088_0092_0094,K);_0088_0092_009A=new ReLine(K,F);
  _0088_0092_009B=new ReLine();_0088_0092_009B.Through(F,_0088_0092_009A.Angle()+Math.PI/2);
  _0088_0092_0097=new RePoint(S.X,_0088_0092_009B.Y(S.X));
  _0088_0092_008B=F.X-S.X+(finalAltitude-tna)/gradient;
  Add(_0088_0092_0094,K);Add(K,F);if(early)Add(S,_0088_0092_0094);
 }
 // Boundary builder Original MethodDef: 0x06000423; Original RVA: 0x66DEC.
 void Add(RePoint a,RePoint b){var list=RePoint.Symmetric(a,b);for(int i=0;i<list.Count;i++)list[i]=RePoint.ZeroZ(list[i]);Boundaries.Add(list);}
 static bool TrueHelper(){return true;}static bool FalseHelper(){return false;}
'''
(OUT/'OmniDeparture.Recovered.cs').write_text(header+method+'}\n',encoding='utf-8')
print('Omni evaluator mechanically ported:',len(method.splitlines()),'lines; no target execution')
