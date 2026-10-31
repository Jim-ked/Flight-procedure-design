"""B5-only mechanical arithmetic recovery. Reads frozen sources; never runs DLL."""
from pathlib import Path
import re,csv,sys,json
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2];R=ROOT/'reverse-analysis';A=ROOT/'recovered/B5-PbnDeparture';E=A/'evidence'
src=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
names={'_008C_0091':'PbnDepartureAltitudeTurn','_008C_0093':'PbnDepartureFlyOver','_008A_0089':'PbnDepartureObstacle','_008B_0098':'StartArea','_008B_009A':'FlyOverPostArea','_008E_0097':'RunwayFrame','_008F_008A':'B5Math','_008D':'FrameHelpers','_008F_008E':'TemplatePoint','_008F_008C':'LineCarrier','_008F_0086':'Spiral86','_008E_009B':'TurnInput','_008F_0090':'PointLists','_008F_0096':'VectorCarrier','_008E_009D':'SideClassifier'}
def rename(s):
 for old,new in names.items():s=re.sub(r'\b'+old+r'\b',new,s)
 return s
classes=['_008C_0091','_008C_0093','_008A_0089','_008B_0098','_008B_009A','_008E_0097']
def extract(cls):
 a=next(i for i,l in enumerate(src) if re.match(r'\t(?:public|internal) (?:static )?class '+cls+r'(?:\s|:|$)',l));b=next(i for i in range(a+1,len(src)) if src[i]=='\t}')
 (E/(cls+'.source.txt')).write_text('\n'.join(f'{i+1}: {src[i]}' for i in range(a,b+1)),encoding='utf-8')
 return '\n'.join(src[a:b+1])
def hoist(m):
 block=m[0];ls={}
 def decl(d):
  indent,typ,name,init=d.groups();ls[name]=typ
  return indent+('// IL local hoisted' if init is None or init.startswith('default(') else name+' = '+init+';')
 block=re.sub(r'^(\t{3,})(double|int|bool|string|(?:List<[^;=]+>|_00[0-9A-F]{2}(?:_00[0-9A-F]{2})?)) (\w+)(?: = ([^\n;]+))?;',decl,block,flags=re.M)
 p=block.index('{')+1
 return block[:p]+'\n'+''.join('\t\t\t'+t+' '+n+' = default('+t+'); // IL InitLocals\n' for n,t in ls.items())+block[p:]
def clean(s):
 s=re.sub(r'\bbase\._002Ector\(\);','// object constructor emitted automatically',s)
 s=re.sub(r'LicenseManager.Validate\(typeof\([^)]*\)\);','// Host licensing not executed in independent recovery.',s)
 s=re.sub(r'^\s*\[.*\]\s*$','',s,flags=re.M)
 s=re.sub(r'\b_ = ([01]);',r'/* opaque discard \1 */',s)
 s=re.sub(r'\b_0020:\s*','',s)
 s=re.sub(r'^\t\t(?:public|private|internal|protected|static) [^\n]*\([^\n]*\)[^\n]*\n\t\t\{.*?^\t\t\}',hoist,s,flags=re.M|re.S)
 return rename(s)
header='using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing Recovered.A6;\n// Mechanical recovery of processed source/IL. Original identifiers retained.\n// IL locals initialized once at entry. No target assembly or AutoCAD dependency.\nnamespace Recovered.B5 {\n'
for cls in classes:
 s=clean(extract(cls))
 if cls=='_008C_0091':
  s=s.replace('PointLists._008B_008A_0094(Math.Atan2(obj3.Y - obj.Y, obj3.X - obj.X), new StartArea(num, P_1)._0089_009B_0095, new TemplatePoint(0.0, 0.0))','PointLists._008B_008A_0094(new StartArea(num, P_1)._0089_009B_0095, new TemplatePoint(0.0, 0.0), Math.Atan2(obj3.Y - obj.Y, obj3.X - obj.X)) /* P5CB IL_01DA-022F stack order */')
 # Result carrier's original constructor invokes its point base with positional args.
 if cls=='_008A_0089':
  s=s.replace('base._002Ector(P_0.X, P_0.Y, P_0.Z);','// base point initialized below\n            X=P_0.X; Y=P_0.Y; Z=P_0.Z;')
  s=s.replace('base._002Ector(P_0, P_1, P_2);','// base point initialized below\n            X=P_0; Y=P_1; Z=P_2;')
 (A/(names[cls]+'.Recovered.cs')).write_text(header+s+'\n}\n',encoding='utf-8')
# Only B5-reachable math bodies, avoid unrelated UI conversions in same class.
s=extract('_008F_008A'); start=s.index('\t\tpublic static List<_008F_008E> _008B_0088_0089');end=s.index('\n\t\tstatic _008F_008A')
s='public static class _008F_008A {\n'+s[start:end]+'\npublic static double _008B_0087_009A(double a){return a*Math.PI/180.0;}\ninternal static bool _0089p(){return true;}\ninternal static bool _0089q(){return false;}\n}'
s=s.replace('{return a*Math.PI/180.0;}','{\n return a*Math.PI/180.0;\n}').replace('{return true;}','{\n return true;\n}').replace('{return false;}','{\n return false;\n}')
(A/'B5Math.Recovered.cs').write_text(header+clean(s)+'\n}\n',encoding='utf-8')
s2=(R/'03_recovered-src/annotated-strings/-/-.cs').read_text(encoding='utf-8').splitlines()
s='public static class _008D {\n'+'\n'.join(s2[3102:3128])+'\n}'
(E/'frame-source.txt').write_text('\n'.join(f'{i+1}: {s2[i]}' for i in range(3102,3128)),encoding='utf-8')
(A/'FrameHelpers.Recovered.cs').write_text(header+clean(s)+'\n}\n',encoding='utf-8')
print('recovered',classes)
