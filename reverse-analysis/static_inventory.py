"""Independent PE/CLI and IL inspection. Never loads a target assembly."""
from pathlib import Path
import sys, json, csv, hashlib, collections, math
ROOT = Path(__file__).resolve().parent
sys.path.insert(0, str(ROOT / 'tools/python'))
import dnfile
from dncil.cil.body import CilMethodBody
from dncil.cil.body.reader import CilMethodBodyReaderBytes
from dncil.clr.token import Token, StringToken

source = ROOT / (sys.argv[1] if len(sys.argv)>1 else '01_original/WsTools-master/WindSpiral2026/WindSpiralBasic.dll')
out = ROOT / (sys.argv[2] if len(sys.argv)>2 else '04_type-map/raw')
out.mkdir(parents=True, exist_ok=True)
pe = dnfile.dnPE(str(source))
tables = pe.net.mdtables
def esc(value): return str(value).encode('unicode_escape').decode('ascii')
def csvout(name, rows):
    if not rows: return
    with (out / name).open('w', newline='', encoding='utf-8-sig') as f:
        w=csv.DictWriter(f, fieldnames=list(rows[0])); w.writeheader(); w.writerows(rows)
def jsout(name,data): (out/name).write_text(json.dumps(data,ensure_ascii=False,indent=2),encoding='utf-8')
names = {}; owners = {}; types=[]; methods=[]; fields=[]; calls=[]; failures=[]
for i,t in enumerate(tables.TypeRef,1): names[0x01000000+i]=esc(t.TypeNamespace)+'.'+esc(t.TypeName)
for i,t in enumerate(tables.TypeDef,1):
    tok=0x02000000+i; fullname=esc(t.TypeNamespace)+'.'+esc(t.TypeName); names[tok]=fullname
    for m in t.MethodList: owners[0x06000000+m.row_index]=fullname
    for f in t.FieldList: owners[0x04000000+f.row_index]=fullname
for i,t in enumerate(tables.TypeDef,1):
    ext=t.Extends
    base=names.get((ext.table.number<<24)+ext.row_index,'') if ext and ext.row_index else ''
    types.append({'token':f'0x{0x02000000+i:08X}','name':names[0x02000000+i],'base':base,'methods':len(t.MethodList),'fields':len(t.FieldList)})
for i,m in enumerate(tables.MethodDef,1): names[0x06000000+i]=owners.get(0x06000000+i,'')+'::'+esc(m.Name)
for i,f in enumerate(tables.Field,1):
    tok=0x04000000+i; names[tok]=owners.get(tok,'')+'::'+esc(f.Name)
    fields.append({'token':f'0x{tok:08X}','name':names[tok],'signature':f.Signature.value.hex()})
for i,m in enumerate(tables.MemberRef,1):
    parent=m.Class; ptok=(parent.table.number<<24)+parent.row_index
    names[0x0A000000+i]=names.get(ptok,f'0x{ptok:08X}')+'::'+esc(m.Name)
def operand(op):
    if isinstance(op,StringToken):
        value=pe.net.user_strings.get(op.rid)
        return repr(value.value) if value else str(op)
    if isinstance(op,Token): return f'0x{op.value:08X} '+names.get(op.value,'')
    return str(op) if op is not None else ''
ilout=(out/'independent-il.txt').open('w',encoding='utf-8')
for i,m in enumerate(tables.MethodDef,1):
    tok=0x06000000+i
    record={'token':f'0x{tok:08X}','name':names[tok],'rva':f'0x{m.Rva:X}',
            'file_offset':'','code_size':0,'instructions':0,'exception_handlers':0,'status':'no_body','il_sha256':'','opcodes':''}
    if m.Rva:
        try:
            offset=pe.get_offset_from_rva(m.Rva)
            b=CilMethodBody(CilMethodBodyReaderBytes(pe.__data__[offset:]))
            ops=[str(x.opcode.name) for x in b.instructions]
            trivial=set(ops)<= {'nop','ret','ldnull','ldc.i4.0','ldc.i4.1','ldc.r8','conv.i','conv.u','ldc.i4.m1'} and len(ops)<10
            record.update(file_offset=hex(offset),code_size=b.code_size,instructions=len(ops),exception_handlers=len(b.exception_handlers),
                          status='stub_like' if trivial else 'decoded',il_sha256=hashlib.sha256(pe.__data__[offset+b.header_size:offset+b.header_size+b.code_size]).hexdigest(),opcodes=' '.join(ops[:20]))
            ilout.write(f'\nMETHOD {tok:08X} {names[tok]} RVA={m.Rva:X} file={offset:X}\n')
            for ins in b.instructions:
                # dncil instruction offsets include the method header: normalize to IL_0000.
                iloff=ins.offset-b.header_size
                ilout.write(f'IL_{iloff:04X}: {ins.opcode.name} {operand(ins.operand)}\n')
                if isinstance(ins.operand,Token) and not isinstance(ins.operand,StringToken):
                    calls.append({'caller':record['token'],'caller_name':names[tok], 'il_offset':f'IL_{iloff:04X}',
                                  'opcode':ins.opcode.name,'target':f'0x{ins.operand.value:08X}','target_name':names.get(ins.operand.value,'')})
        except Exception as exc:
            record['status']='decode_error'; failures.append({'token':record['token'],'error':str(exc)})
    methods.append(record)
ilout.close()
commands=[]; attrs=[]
for a in tables.CustomAttribute:
    p=a.Parent; target=(p.table.number<<24)+p.row_index
    c=a.Type; ctor=(c.table.number<<24)+c.row_index
    name=names.get(ctor,''); blob=a.Value.value
    attrs.append({'parent':f'0x{target:08X}','constructor':name,'blob':blob.hex()})
    if 'CommandMethodAttribute' in name:
        # Observed overload is .ctor(string); retain full blob for independent verification.
        n=blob[2]; text=blob[3:3+n].decode('utf-8') if n<128 else '<compressed-length>'
        commands.append({'method_token':f'0x{target:08X}','method_name':names.get(target,''),'command':text,'attribute_blob':blob.hex()})
resources=[]
rdir=out/'resources'; rdir.mkdir(exist_ok=True)
for i,r in enumerate(pe.net.resources):
    data=r.data if isinstance(r.data,bytes) else getattr(r,'data',None)
    if not isinstance(data,bytes):
        # Raw resource payload can be extracted directly from the CLI resource directory.
        mr=tables.ManifestResource.rows[i]; pos=pe.net.struct.ResourcesRva+mr.Offset
        length=int.from_bytes(pe.get_data(pos,4),'little'); data=pe.get_data(pos+4,length)
    path=rdir/f'{i:02d}.bin'; path.write_bytes(data)
    count=collections.Counter(data); entropy=-sum((n/len(data))*math.log2(n/len(data)) for n in count.values()) if data else 0
    resources.append({'name':str(r.name),'bytes':len(data),'sha256':hashlib.sha256(data).hexdigest(),'entropy':entropy,'path':str(path.relative_to(ROOT))})
csvout('types.csv',types); csvout('methods.csv',methods); csvout('fields.csv',fields); csvout('references.csv',calls); csvout('commands.csv',commands)
jsout('custom-attributes.json',attrs); jsout('resources.json',resources); jsout('failures.json',failures)
jsout('memberrefs.json',[{'token':f'0x{k:08X}','name':v} for k,v in names.items() if k>>24==10])
jsout('assemblyrefs.json',[{'name':str(r.Name),'version':f'{r.MajorVersion}.{r.MinorVersion}.{r.BuildNumber}.{r.RevisionNumber}'} for r in tables.AssemblyRef])
summary={'sha256':hashlib.sha256(source.read_bytes()).hexdigest(),'types':len(types),'methods':len(methods),'fields':len(fields),
         'status_counts':dict(collections.Counter(m['status'] for m in methods)), 'commands':len(commands),'resources':resources,
         'sections':[{'name':s.Name.decode('ascii').strip('\0'),'rva':hex(s.VirtualAddress),'bytes':s.SizeOfRawData} for s in pe.sections]}
jsout('summary.json',summary)
print(json.dumps({k:v for k,v in summary.items() if k not in ['resources','sections']}))
