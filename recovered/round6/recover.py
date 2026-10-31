"""Mechanical B3 recovery, reusing frozen primitives. No target assembly execution."""
from pathlib import Path
import re,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2]; A=ROOT/'recovered/B3-RnpApch';E=A/'evidence'
src=(ROOT/'reverse-analysis/03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
names={'_008B_009C':'RnpApchLnav','_008C_0097':'RnpApchApv','_008A_008B':'RnpApchObstacle','_008A_008D':'RnpApchApvObstacle','_008F_008E':'TemplatePoint','_008F_008C':'LineCarrier','_008F_0090':'PointLists','_008E_009B':'TurnInput','_008E_0097':'RunwayFrame'}
def rename(s):
 for old,new in names.items():s=re.sub(r'\b'+old+r'\b',new,s)
 return s
def extract(cls):
 a=next(i for i,l in enumerate(src) if re.match(r'\t(?:public|internal) (?:static )?class '+re.escape(cls)+r'(?:\s|:|$)',l));b=next(i for i in range(a+1,len(src)) if src[i]=='\t}')
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
 s=s.replace('base._002Ector();','// object constructor emitted automatically')
 s=re.sub(r'LicenseManager.Validate\(typeof\([^)]*\)\);','// Host licensing not executed.',s)
 s=re.sub(r'^\s*\[.*\]\s*$','',s,flags=re.M)
 s=re.sub(r'\b_ = ([01]);',r'/* opaque discard \1 */',s)
 s=re.sub(r'\b_ = ([^;\n]+);',r'RecoveryMessages.Discard(\1);',s)
 s=s.replace('new _008F_0092();','// P595 constructs an unused plane carrier; no methods or fields consumed.')
 s=s.replace('MessageBox.Show(', 'RecoveryMessages.Show(')
 s=re.sub(r'^\t\t(?:public|private|internal|protected|static) [^\n]*\([^\n]*\)[^\n]*\n\t\t\{.*?^\t\t\}',hoist,s,flags=re.M|re.S)
 return rename(s)
header='using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing Recovered.A6;\nusing Recovered.B5;\n// Processed source/IL recovery; identifiers and branches retained. No original DLL oracle.\nnamespace Recovered.B3 {\n'
for cls in ['_008B_009C','_008C_0097','_008A_008B','_008A_008D']:
 (A/(names[cls]+'.Recovered.cs')).write_text(header+clean(extract(cls))+'\n}\n',encoding='utf-8')
form=extract('_008B_008C')
parts=[]
for name in ['_0088_009A_0091','_0088_009D_0086']:
 m=re.search(r'^\t\tprivate void '+name+r'\([^\n]*\)\n\t\t\{.*?^\t\t\}',form,re.M|re.S)
 parts.append(m[0].replace('private void','public static void'))
body='public static class RnpApchForm {\n'+'\n'.join(parts)+'\ninternal static bool _0088_0093(){return true;}\ninternal static bool _0088_0094(){return false;}\n}'
(A/'RnpApchForm.Recovered.cs').write_text(header+clean(body)+'\n}\n',encoding='utf-8')
print('four business/carrier classes and two Form minimums/visibility postprocessors extracted')
