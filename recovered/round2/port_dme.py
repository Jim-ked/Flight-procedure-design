"""Keep the full DME CAD/evaluation state machines. No target execution or DLL mutation."""
from pathlib import Path
import re,hashlib,json
ROOT=Path(__file__).resolve().parents[2];OUT=ROOT/'recovered/A10-DmeArc'
path=OUT/'evidence/_0089_0088.source.txt'
src='\n'.join(re.sub(r'^\d+: ','',l) for l in path.read_text(encoding='utf-8').splitlines() if '//IL_' not in l)
def extract(start,end):return src[src.index(start):src.index(end)]
draw=extract('\t\tprivate void _0087_008E_008A(', '\t\tprivate static double _0087_008E_008B(')
evaluate=extract('\t\tprivate void _0087_008E_008D(', '\t\tprivate double _0087_008E_008E(')
def common(s):
    s=re.sub(r'^\s*_ = [01];\s*$', '',s,flags=re.M)
    s=s.replace('_008F_008A._0090_009A','InputCheck').replace('_008F_008A._008B_0088_0086','CheckInput')
    s=s.replace('obj._008B_008F_008E','obj.Value').replace('obj._008B_008F_008F','obj.Message').replace('obj2._008B_008F_008E','obj2.Value').replace('obj2._008B_008F_008F','obj2.Message')
    s=s.replace('_0087_009B()','TrueHelper()').replace('_0087_009C()','FalseHelper()')
    for a,b in {'_0087_008E_008B':'Bulge','_0087_008E_008E':'Normalize','_0087_008E_008F':'Angles','_0087_008E_0090':'Sector','_008F_008E._008B_0088_009E':'RePoint.Distance','_008F_008E':'RePoint'}.items():s=s.replace(a,b)
    return s
native=common(draw).replace('private void _0087_008E_008A(object P_0, EventArgs P_1)','public void DrawToCad()')
native=re.sub(r'\(\(Point3d\)\(ref (\w+)\)\)',r'\1',native)
native=re.sub(r'(\w+)\._002Ector\((.*)\);',r'\1 = new Point3d(\2);',native)
native=re.sub(r'(\w+)\._008C_0089\(\)',r'AsCad(\1)',native)
native=native.replace('_008B._0088_008D','CalcuCadRecovered.AppendWithoutMetadata')
nativehead='''#if ACAD2026_TEST
using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Application=Autodesk.AutoCAD.ApplicationServices.Core.Application;
// ACAD2026 compatibility compile only. Full original Arc/Polyline construction order.
// Original MethodDef: 0x060002DC; Original RVA: 0x37D8C.
public partial class DmeArcRecovered {
 static Point3d AsCad(RePoint p){return new Point3d(p.X,p.Y,p.Z);}
'''
(OUT/'DmeArc.Native.Recovered.cs').write_text(nativehead+native+'}\n#endif\n',encoding='utf-8')
draw=common(draw).replace('private void _0087_008E_008A(object P_0, EventArgs P_1)','private void DrawCore()')
draw=re.sub(r'\(\(Point3d\)\(ref (\w+)\)\)',r'\1',draw)
draw=re.sub(r'(\w+)\._002Ector\((.*)\);',r'\1 = new RePoint(\2);',draw)
draw=re.sub(r'(\w+)\._008C_0089\(\)',r'\1',draw)
draw=re.sub(r'\(\(Curve\)(\w+)\)',r'\1',draw)
draw=draw.replace('(Entity)(object)','').replace('(Entity)','')
draw=draw.replace('Application.DocumentManager.MdiActiveDocument.Database','null').replace('Database','object')
for a,b in {'Point3d':'RePoint','Point2d':'RePoint','Polyline':'RePolyline','DBText':'ReText','Arc':'ReArc','TextHorizontalMode':'int','TextVerticalMode':'int','_008B._0088_008D':'Capture'}.items():draw=draw.replace(a,b)
draw=draw.replace('new ReArc(','Drawing.Arc(')
evaluate=common(evaluate).replace('private void _0087_008E_008D(object P_0, EventArgs P_1)','private void EvaluateCore()')
evaluate=evaluate.replace('List<DBPoint>','List<RePoint>').replace('_008A_008B','DmeEvaluation')
evaluate=re.sub(r'enumerator.Current\._008C_008D\(num2.ToString\(\)\)',r'Imported(enumerator.Current,num2.ToString())',evaluate)
for a,b in {'_0088_008F_009C':'Area','_0088_008F_009D':'MOC','_0088_008F_009E':'OCA','_0088_0090_0087':'RoundedOca'}.items():evaluate=evaluate.replace(a,b)
evaluate=evaluate.replace('_0020:','symmetric:').replace('_0087_008E_0086(list);','Results=list;')
header='using System;\nusing System.Collections.Generic;\nusing System.Linq;\n// Mechanical source/IL port; original labels and compare operators retained.\n// CAD original060002DC/RVA37D8C; evaluation original060002DF/RVA3A5DC.\n// Portable recorder preserves signed radii; not proof of Autodesk kernel behavior.\npublic partial class DmeArcRecovered {\n'
(OUT/'DmeArc.Bodies.Recovered.cs').write_text(header+draw+evaluate+'}\n',encoding='utf-8')
(OUT/'evidence/port-transform.json').write_text(json.dumps(dict(source=str(path.relative_to(ROOT)),sha256=hashlib.sha256(path.read_bytes()).hexdigest(),draw_lines=len(draw.splitlines()),evaluation_lines=len(evaluate.splitlines()),transformation='rename types/members, replace CAD sink with construction recorder; keep gotos and branch ordering'),ensure_ascii=False,indent=2),encoding='utf-8')
print('DME mechanical port lines:',len(draw.splitlines()),len(evaluate.splitlines()))
