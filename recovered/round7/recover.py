"""Mechanical recovery only; original host integration stays in source/IL evidence."""
from pathlib import Path
import re,csv,sys
ROOT=Path(__file__).resolve().parents[2];A=ROOT/'recovered/B4-PbnIls';E=A/'evidence'
src=(ROOT/'reverse-analysis/03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
names={'_008A_0093':'OasModel','_008C_0095':'PbnIlsTurn','_008A_008D':'PbnIlsObstacle','_008F_0092':'PlaneCarrier','_008F_008E':'TemplatePoint','_008F_008C':'LineCarrier','_008F_0090':'PointLists','_008A_008F':'OasMode'}
def rename(s):
 for a,b in names.items():s=re.sub(r'\b'+a+r'\b',b,s)
 return s
def extract(c):
 a=next(i for i,l in enumerate(src) if re.match(r'\t(?:public|internal) (?:static )?class '+re.escape(c)+r'(?:\s|:|$)',l));b=next(i for i in range(a+1,len(src)) if src[i]=='\t}')
 return '\n'.join(src[a:b+1])
def hoist(m):
 s=m[0];ls={}
 def decl(d):
  indent,t,n,init=d.groups();ls[n]=t
  return indent+('// IL local hoisted' if init is None or init.startswith('default(') else n+' = '+init+';')
 s=re.sub(r'^(\t{3,})((?:double|int|bool|string|char)(?:\[\])?|(?:List<[^;=]+>|_00[0-9A-F]{2}(?:_00[0-9A-F]{2})?)) (\w+)(?: = ([^\n;]+))?;',decl,s,flags=re.M)
 at=s.index('{')+1
 return s[:at]+'\n'+''.join('\t\t\t'+t+' '+n+' = default('+t+'); // IL InitLocals\n' for n,t in ls.items())+s[at:]
def clean(s):
 s=s.replace('base._002Ector();','// implicit object constructor')
 s=re.sub(r'LicenseManager.Validate\(typeof\([^)]*\)\);','// host licensing excluded from independent recovery',s)
 s=re.sub(r'^\s*\[.*\]\s*$','',s,flags=re.M)
 s=re.sub(r'\b_ = ([01]);',r'/* opaque discard \1 */',s)
 s=re.sub(r'\b_ = ([^;\n]+);',r'RecoveryMessages.Discard(\1);',s)
 s=s.replace('MessageBox.Show(','RecoveryMessages.Show(').replace('Application.ShowAlertDialog(','RecoveryMessages.Show(')
 s=re.sub(r'^\t\t(?:public|private|internal|protected|static) [^\n]*\([^\n]*\)[^\n]*\n\t\t\{.*?^\t\t\}',hoist,s,flags=re.M|re.S)
 return rename(s)
head='using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing Recovered.A6;\nusing Recovered.B5;\n// E1/E2 recovery. No target DLL or AutoCAD runtime. Original branches retained.\nnamespace Recovered.B4 {\n'
for c in ['_008A_0093','_008C_0095','_008A_008D','_008F_0092']:(A/(names[c]+'.Recovered.cs')).write_text(head+clean(extract(c))+'\n}\n',encoding='utf-8')
form=extract('_008B_0096');parts=[]
methods=['_0089_0095_009B','_0089_0095_009C','_0089_0095_009D','_0089_0096_0086','_0089_0096_0087','_0089_0096_0088','_0089_0096_008A','_0089_0096_008C','_0089_0096_008F','_0089_0096_0097','_0089_0096_0098','_0089_0096_0099','_0089_0096_009A']
for n in methods:
 m=re.search(r'^\t\tprivate (?:static )?[^\n]* '+n+r'\([^\n]*\)\n\t\t\{.*?^\t\t\}',form,re.M|re.S)
 assert m,n
 s=m[0].replace('private ','public ',1).replace('TextBox','RecoveryCell').replace('_008F_008A._008B_0087_009D','RecoveryParse.Text').replace('_008F_008A._008B_0087_009E','RecoveryParse.Cell')
 parts.append(s)
fields=list(csv.DictReader((E/'controls.csv').open(encoding='utf-8-sig')))
decl='\n'.join('public RecoveryCell '+x['field']+' = new RecoveryCell(); // '+x['control_name'] for x in fields if x['field']!='base')
body='public class PbnIlsForm {\n'+decl+'\npublic double[,] _0089_0097_008D = new double[,]{{40,13},{43,18},{46,22},{49,26}};\n'+'\n'.join(parts)+'\ninternal static bool _0088_009D(){return true;}\ninternal static bool _0088_009E(){return false;}\n}\n'
(A/'PbnIlsForm.Recovered.cs').write_text(head+clean(body)+'\n}\n',encoding='utf-8')
print('four complete numeric classes and thirteen Form numeric/serialization methods recovered')
