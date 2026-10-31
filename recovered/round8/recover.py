"""Round 8 only. Mechanical E1/E2 extraction; IO and UI adapters explicitly marked."""
from pathlib import Path
import csv,re,json,sys
ROOT=Path(__file__).resolve().parents[2]; A=ROOT/'recovered/A5-PrecisionApproach'; E=A/'evidence'; O=ROOT/'recovered/round8'
src=(ROOT/'reverse-analysis/03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
names={'_008A_0093':'OasModel','_008F_0092':'PlaneCarrier','_008F_008E':'TemplatePoint','_008F_008C':'LineCarrier','_008F_0090':'PointLists','_008A_008F':'OasMode','_0089_0096':'GpInopGeometry','_008A_0097':'PaOasGeometry','_008A_0099':'PaFafGeometry','_008A_009B':'PaFapGeometry','_008A_0091':'OasParameters'}
def rename(s):
 for a,b in names.items():s=re.sub(r'\b'+a+r'\b',b,s)
 return s
def extract(c):
 a=next(i for i,l in enumerate(src) if re.match(r'\t(?:public|internal) (?:static )?class '+re.escape(c)+r'(?:\s|:|$)',l));b=next(i for i in range(a+1,len(src)) if src[i]=='\t}')
 return '\n'.join(src[a:b+1])
def dictionary_initializers(s):
 # C# 6 index initializer -> equivalent C# 5 Add initializer, including nested values.
 matches=list(re.finditer(r'\[("[^"\n]*")\s*\]\s*=\s*',s))
 for m in reversed(matches):
  a=m.end();i=a;depth=0;quoted=False;escape=False
  while i<len(s):
   ch=s[i]
   if quoted:
    if escape:escape=False
    elif ch=='\\':escape=True
    elif ch=='"':quoted=False
   elif ch=='"':quoted=True
   elif ch in '([{<':depth+=1
   elif ch in ')]}>':
    if depth==0:break
    depth-=1
   elif ch==',' and depth==0:break
   i+=1
  s=s[:m.start()]+'{'+m[1]+', '+s[a:i].rstrip()+'}'+s[i:]
 return s
def hoist(m):
 s=m[0];ls={}
 def decl(d):
  indent,t,n,init=d.groups();ls[n]=t
  return indent+('// IL local hoisted' if init is None or init.startswith('default(') else n+' = '+init+';')
 s=re.sub(r'^(\t{3,})((?:double|int|bool|string|char)(?:\[\])?|(?:List<[^;=]+>|Dictionary<[^;=]+>|_00[0-9A-F]{2}(?:_00[0-9A-F]{2})?)) (\w+)(?: = ([^\n;]+))?;',decl,s,flags=re.M)
 at=s.index('{')+1
 return s[:at]+'\n'+''.join('\t\t\t'+t+' '+n+' = default('+t+'); // IL InitLocals\n' for n,t in ls.items())+s[at:]
def clean(s):
 s=s.replace('base._002Ector();','// implicit object constructor')
 s=re.sub(r'LicenseManager.Validate\(typeof\([^)]*\)\);','// original licensing excluded; independent source only',s)
 s=re.sub(r'/\* string-offset:\d+ \*/','',s)
 s=re.sub(r'^\s*\[.*\]\s*$','',s,flags=re.M)
 s=re.sub(r'\b_ = ([01]);',r'/* opaque discard \1 */',s)
 s=re.sub(r'\b_ = ([^;\n]+);',r'RecoveryMessages.Discard(\1);',s)
 s=s.replace('MessageBox.Show(','RecoveryMessages.Show(')
 s=s.replace('Application.DocumentManager.MdiActiveDocument.Editor.WriteMessage(','RecoveryMessages.Show(')
 s=re.sub(r'^\t\t(?:public|private|internal|protected|static) [^\n]*\([^\n]*\)[^\n]*\n\t\t\{.*?^\t\t\}',hoist,s,flags=re.M|re.S)
 return rename(dictionary_initializers(s))
head='using System;\nusing System.IO;\nusing System.Reflection;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Web.Script.Serialization;\nusing Recovered.A6;\nusing Recovered.B5;\nusing Recovered.B4;\n// E1/E2 extraction. Only independent source, no target DLL or CAD execution.\nnamespace Recovered.A5 {\n'
for c in ['_0089_0096','_008A_0097','_008A_0099','_008A_009B','_008A_0091']:
 s=extract(c)
 if c=='_008A_0091':
  s=re.sub(r'string text = Path.GetDirectoryName\(Assembly.GetExecutingAssembly\(\).Location\) \+ .*?;', 'string text = RecoveryDatabase.Path; // IO boundary adapter; original location recorded in evidence',s)
  s=s.replace('File.Exists(text)','RecoveryDatabase.Present')
  s=re.sub(r'\(\(Db(?:Connection|Command)\)\(object\)(\w+)\)',r'\1',s)
  s=s.replace('((IDisposable)val2)?.Dispose();','val2.Dispose();').replace('((IDisposable)val3)?.Dispose();','val3.Dispose();').replace('((IDisposable)val)?.Dispose();','val.Dispose();')
 (A/(names[c]+'.Recovered.cs')).write_text(head+clean(s)+'\n}\n',encoding='utf-8')
form=extract('_0089_008C');parts=[]
for n in ['_0087_0091_008F','_0087_0091_0090','_0087_0091_0091','_0087_0091_0092','_0087_0091_0093','_0087_0091_0094','_0087_0091_0095','_0087_0091_009B','_0087_0092_0088','_0087_0092_0089']:
 m=re.search(r'^\t\tprivate (?:static )?[^\n]* '+n+r'\([^\n]*\)\n\t\t\{.*?^\t\t\}',form,re.M|re.S);assert m,n
 s=m[0].replace('private ','public ',1).replace('_008F_008A._008B_0087_009D','RecoveryParse.Text').replace('_008F_008A._008B_0087_009E','RecoveryParse.Cell')
 parts.append(s)
controls=list(csv.DictReader((E/'controls.csv').open(encoding='utf-8-sig')))
decl='\n'.join('public PrecisionCell '+x['field']+' = new PrecisionCell(); // '+x['control_name'] for x in controls if x['field']!='base')
body='public class PrecisionApproachForm {\npublic OasModel _0087_0092_008E; public PaOasGeometry _0087_0092_008F; public TemplatePoint _0087_0092_0090,_0087_0092_0091;\n'+decl+'\n'+'\n'.join(parts)+'\ninternal static bool _0087_009F(){return true;}\ninternal static bool _00870(){return false;}\n}\n'
(A/'PrecisionApproachForm.Recovered.cs').write_text(head+clean(body)+'\n}\n',encoding='utf-8')
print('five geometry/parameter classes and ten Form methods extracted')
