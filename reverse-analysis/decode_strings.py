from pathlib import Path
import sys,struct,json,re,hashlib
ROOT=Path(__file__).resolve().parent
sys.path.insert(0,str(ROOT/'tools/python'))
import pefile
from cryptography.hazmat.primitives.ciphers import Cipher,algorithms,modes
from cryptography.hazmat.primitives.padding import PKCS7
original=ROOT/'01_original/WsTools-master/WindSpiral2026/WindSpiralBasic.dll'
pe=pefile.PE(str(original))
table=(ROOT/'02_deobfuscated/string-rva-table.bin').read_bytes()
key=bytes([28,140,35,220,242,181,128,254,224,127,127,85,26,117,99,60,219,55,207,32,16,227,240,251,98,107,210,152,125,236,124,188])
iv=bytes([23,5,86,220,164,189,42,28,127,65,63,226,210,146,81,145])
rows=[]; decoded={}; failed=[]
booltable=(ROOT/'02_deobfuscated/boolean-table.bin').read_bytes()
originalbytes=original.read_bytes()
bools={}; boolrows=[]
for offset in range(0,len(booltable),4):
    fileoffset=struct.unpack_from('<i',booltable,offset)[0]
    if not 0<=fileoffset<len(originalbytes): raise ValueError('Boolean file offset invalid')
    value=originalbytes[fileoffset]==128
    bools[offset]=value
    boolrows.append({'offset':offset,'original_file_offset':fileoffset,'original_byte':originalbytes[fileoffset],'value':value})
(ROOT/'02_deobfuscated/booleans.json').write_text(json.dumps(boolrows,indent=2),encoding='utf-8')
for offset in range(0,len(table),4):
    rva=struct.unpack_from('<I',table,offset)[0]
    try:
        length=struct.unpack('<I',pe.get_data(rva,4))[0]
        if length>1000000 or length%16: raise ValueError('invalid ciphertext length')
        encrypted=pe.get_data(rva+4,length)
        if len(encrypted)!=length: raise ValueError('short read')
        cipher=Cipher(algorithms.AES(key),modes.CBC(iv)).decryptor()
        plain=cipher.update(encrypted)+cipher.finalize()
        unpad=PKCS7(128).unpadder(); plain=unpad.update(plain)+unpad.finalize()
        value=plain.decode('utf-16le')
        decoded[offset]=value
        rows.append({'offset':offset,'rva':hex(rva),'file_offset':hex(pe.get_offset_from_rva(rva)),
                     'cipher_length':length,'value':value})
    except Exception as e: failed.append({'offset':offset,'rva':hex(rva),'error':str(e)})
(ROOT/'02_deobfuscated/strings.json').write_text(json.dumps(rows,ensure_ascii=False,indent=2),encoding='utf-8')
(ROOT/'02_deobfuscated/string-failures.json').write_text(json.dumps(failed,ensure_ascii=False,indent=2),encoding='utf-8')
# Annotated convenience view only; never claim these textual substitutions are original source.
source=ROOT/'03_recovered-src/ilspy-methods-only'
dest=ROOT/'03_recovered-src/annotated-strings'
pattern=re.compile(r'_0090_009B\._008B_008F_009D\((\d+)\)')
count=0
for path in source.rglob('*.cs'):
    text=path.read_text(encoding='utf-8-sig')
    def replace(m):
        global count
        n=int(m[1])
        if n not in decoded: return m[0]
        count+=1
        return json.dumps(decoded[n],ensure_ascii=False)+' /* string-offset:'+str(n)+' */'
    target=dest/path.relative_to(source); target.parent.mkdir(parents=True,exist_ok=True)
    text=pattern.sub(replace,text)
    text=re.sub(r'_0090_009B\._008B_008F_009A\((\d+)\)',
                lambda m: str(bools[int(m[1])]).lower()+' /* original-file-bool-offset:'+m[1]+' */' if int(m[1]) in bools else m[0], text)
    target.write_text(text,encoding='utf-8')
print(json.dumps({'decoded':len(rows),'failed':len(failed),'annotated_sites':count,'boolean_entries':len(boolrows)}))
