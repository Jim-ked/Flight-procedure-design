"""A6-only evidence packet and mechanical port. Does not load target assemblies."""
from pathlib import Path
import csv,re,json,hashlib,sys
sys.stdout.reconfigure(encoding='utf-8')
ROOT=Path(__file__).resolve().parents[2]; R=ROOT/'reverse-analysis'; O=ROOT/'recovered/round4'; A=ROOT/'recovered/A6-Template'; E=A/'evidence'
def rows(p):
 with p.open(encoding='utf-8-sig',newline='') as f:return list(csv.DictReader(f))
def csvout(p,rs):
 if not rs:return
 with p.open('w',encoding='utf-8-sig',newline='') as f:
  w=csv.DictWriter(f,fieldnames=list(rs[0]));w.writeheader();w.writerows(rs)
src=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
proc=rows(R/'04_type-map/methods-only/methods.csv'); raw={x['token']:x for x in rows(R/'04_type-map/raw/methods.csv')}; mp={x['processed_token']:x['original_token'] for x in rows(R/'04_type-map/tool-token-map.csv') if x['kind']=='Method'}
loc=rows(R/'04_type-map/method-source-locations.csv'); calls=rows(R/'05_callgraph/static-sites.csv')
arity={m['Token']:int(m['ParameterCount']) for m in rows(E/'signatures.csv') if m['Tier']=='processed'}
classes={'_0089_0092':None,'_0088_0091':'BaseTurn','_0089_0098':'Holding','_0089_009A':'HoldingXE','_0089_009C':'HoldingYE','_008B_0086':'Procedure45180','_008B_0088':'Procedure80260','_008E_009B':'TurnInput','_008F_0086':'Spiral86','_008F_0088':'Spiral88','_008F_008C':'LineCarrier','_008F_008E':'TemplatePoint','_008F_0090':'PointLists','_008F_0096':'VectorCarrier','_008E_009D':'SideClassifier'}
def enc(s):return re.sub('_00([0-9A-F]{2})',lambda m:'\\x'+m[1].lower(),s)
def clsname(x):return x['name'].split('::')[0].split('.')[-1]
classes['_008F_0098']=None # shared turn control, evidence only; prior recovery frozen
tokens={x['token'] for x in proc if clsname(x) in set(map(enc,classes))}
tokens.add('0x060007D8')
csvout(E/'shared-turn-events.csv',[x for x in rows(R/'04_type-map/events.csv') if x['class']=='_008F_0098'])
csvout(E/'shared-turn-controls.csv',[x for x in rows(R/'04_type-map/controls.csv') if x['class']=='_008F_0098'])
methods=[]
for m in proc:
 t=m['token']
 if t not in tokens:continue
 old=mp[t];l=next((x for x in loc if t in x['tokens'].split(';')), {})
 methods.append(dict(processed_token=t,original_token=old,original_rva=raw[old]['rva'],processed_rva=m['rva'],name=m['name'],line=l.get('line',''),source=l.get('source',''),il_sha256=m['il_sha256']))
csvout(E/'methods.csv',methods);csvout(E/'calls.csv',[x for x in calls if x['caller'] in tokens])
il=(R/'04_type-map/methods-only/independent-il.txt').read_text(encoding='utf-8')
for m in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',il,re.M|re.S):
 if '0x'+m[1] in tokens:(E/('0x'+m[1]+'.il.txt')).write_text(m[0],encoding='utf-8')
rawil=(R/'04_type-map/raw/independent-il.txt').read_text(encoding='utf-8');(E/'raw').mkdir(exist_ok=True)
for m in re.finditer(r'^METHOD ([0-9A-F]{8}).*?(?=^METHOD |\Z)',rawil,re.M|re.S):
 if '0x'+m[1] in {mp[t] for t in tokens}:(E/'raw'/('0x'+m[1]+'.il.txt')).write_text(m[0],encoding='utf-8')
for cls,new in classes.items():
 a=next(i for i,l in enumerate(src) if re.match(r'\t(?:public|internal) (?:static )?(?:class|struct) '+cls+r'(?:\s|:|$)',l)); b=next(i for i in range(a+1,len(src)) if src[i]=='\t}')
 (E/(cls+'.source.txt')).write_text('\n'.join(f'{i+1}: {src[i]}' for i in range(a,b+1)),encoding='utf-8')
 if not new:continue
 (E/(new+'.source.txt')).write_bytes((E/(cls+'.source.txt')).read_bytes())
 out=[];prop=None
 for i in range(a,b+1):
  line=src[i]
  if '//IL_' in line:continue
  pm=re.match(r'^\t\tpublic (?:double|string) (\w+)\s*$',line)
  if pm:prop=pm[1]
  if prop and re.match(r'^\t\t\t(?:get|set)$',line):
   accessor=line.strip()+'_'+prop
   for m in methods:
    if m['name'].split('::')[0].split('.')[-1]==enc(cls) and m['name'].endswith('::'+accessor):out.append('// Original MethodDef: '+m['original_token']+'; Original RVA: '+m['original_rva']+'; Processed MethodDef: '+m['processed_token']+'; Evidence: '+cls+'.source.txt:'+str(i+1)+' + IL; property accessor.')
  if re.match(r'\t\t(?:public|private|internal|protected|static).*\(',line):
   mm=re.search(r'(\w+)\(',line);name=mm[1] if mm else ''
   pn='.ctor' if name==cls else '.cctor' if name==cls else enc(name)
   if ' operator -(' in line:pn='op_Subtraction'
   if ' operator +(' in line:pn='op_Addition'
   matches=[m for m in methods if m['name'].split('::')[0].split('.')[-1]==enc(cls) and m['name'].split('::')[1]==pn]
   if line.startswith('\t\tstatic '+cls):matches=[m for m in methods if m['name'].endswith('::.cctor') and clsname(m)==enc(cls)]
   params=line.split('(',1)[1].rsplit(')',1)[0]
   argc=0 if not params.strip() else len(params.split(','))
   matches=[m for m in matches if arity[m['processed_token']]==argc]
   for m in matches:out.append('// Original MethodDef: '+m['original_token']+'; Original RVA: '+m['original_rva']+'; Processed MethodDef: '+m['processed_token']+'; Evidence: '+cls+'.source.txt:'+str(i+1)+' + independent IL (decompilation/recovery, not runtime).')
  line=line.replace('base._002Ector();','// object constructor emitted automatically by C#')
  line=re.sub(r'\b_0020:\s*','',line) # unnamed original parameters; preserve positional order
  line=re.sub(r'LicenseManager.Validate\(typeof\([^)]*\)\);','// Host licensing not executed in independent arithmetic recovery.',line)
  line=re.sub(r'^\s*\[.*\]\s*$','',line)
  # setters are rendered with decompiler's synthetic parameter names
  if re.search(r'_008B_008A_00(?:86|87) = text;',line):line=line.replace(' = text;',' = value;')
  if re.search(r'_008B_008[AC]_00\w+ = num;',line):line=line.replace(' = num;',' = value;')
  if cls=='_008F_0096' and 'public _008F_0096(double' in line:line+=' : this()'
  out.append(line)
 text='\n'.join(out)
 for old,nn in classes.items():
  if nn:text=re.sub(r'\b'+old+r'\b',nn,text)
 text=re.sub(r'\b_ = ([01]);',r'/* opaque discard \1 */',text)
 # IL locals are initialized once at method entry. Decompiler emitted declarations
 # at labels / in switch cases, which both breaks definite assignment and resets
 # persistent IL locals when a back edge reaches a declaration. Hoist declarations.
 def hoist(m):
  block=m[0]; ls={}
  def decl(d):
   indent,typ,name,init=d.groups();ls[name]=typ
   return indent+('// IL local declared at method entry' if init is None or init.startswith('default(') else name+' = '+init+';')
  block=re.sub(r'^(\t{3,})(double|int|bool|string|(?:List<[^;=]+>|TemplatePoint|LineCarrier|Spiral86|Spiral88|SideClassifier|VectorCarrier)) (\w+)(?: = ([^\n;]+))?;',decl,block,flags=re.M)
  p=block.index('{')+1
  return block[:p]+'\n'+''.join('\t\t\t'+t+' '+n+' = default('+t+'); // IL InitLocals\n' for n,t in ls.items())+block[p:]
 text=re.sub(r'^\t\t(?:public|private|internal|protected|static) [^\n]*\([^\n]*\)[^\n]*\n\t\t\{.*?^\t\t\}',hoist,text,flags=re.M|re.S)
 header='using System;\nusing System.Collections;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Runtime.CompilerServices;\nusing System.ComponentModel;\nusing System.Windows.Forms;\n// Mechanical recovery: original field/method identifiers retained. See evidence/methods.csv.\n// IL locals hoisted to method entry; expression assignments and branch order preserved.\nnamespace Recovered.A6 {\n'
 (A/(new+'.Recovered.cs')).write_text(header+text+'\n}\n',encoding='utf-8')
 print(cls,'->',new,'lines',b-a+1,'dependencies',sorted(set(re.findall(r'\b_00[0-9A-F]{2}_00[0-9A-F]{2}\b',text))))
print('methods',len(methods))
