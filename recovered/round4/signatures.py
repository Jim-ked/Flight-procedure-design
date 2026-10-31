"""Read ECMA-335 method signatures as data; never execute/load the assembly."""
from pathlib import Path
import sys,csv
ROOT=Path(__file__).resolve().parents[2]
sys.path.insert(0,str(ROOT/'reverse-analysis/tools/python'))
import dnfile
E=ROOT/'recovered/A6-Template/evidence'
ms=list(csv.DictReader((E/'methods.csv').open(encoding='utf-8-sig')))
def uint(b,i):
 a=b[i]
 if a<128:return a,i+1
 if a<192:return ((a&63)<<8)|b[i+1],i+2
 return ((a&31)<<24)|(b[i+1]<<16)|(b[i+2]<<8)|b[i+3],i+4
out=[]
for tier,path,key in [('processed',ROOT/'reverse-analysis/02_deobfuscated/WindSpiralBasic.methods-only.dll','processed_token'),('raw',ROOT/'WsTools-master/WindSpiral2026/WindSpiralBasic.dll','original_token')]:
 pe=dnfile.dnPE(str(path))
 for m in ms:
  token=m[key];row=pe.net.mdtables.MethodDef.rows[int(token,16)-0x06000001]
  b=row.Signature.value;i=1
  if b[0]&16:_,i=uint(b,i)
  n,i=uint(b,i)
  out.append(dict(Tier=tier,Token=token,ParameterCount=n,SignatureHex=b.hex(),Evidence=str(path.relative_to(ROOT))+' MethodDef.Signature (static PE read)'))
 pe.close()
with (E/'signatures.csv').open('w',encoding='utf-8-sig',newline='') as f:
 w=csv.DictWriter(f,fieldnames=list(out[0]));w.writeheader();w.writerows(out)
print('signatures',len(out))
