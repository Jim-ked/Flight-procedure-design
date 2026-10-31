// This executable loads only analysis libraries. Targets are dnlib data models,
// never System.Reflection.Assembly instances. No target methods are invoked.
using System;
using System.IO;
using System.Reflection;
using dnlib.DotNet;
using de4dot.code.deobfuscators;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet.Emit;
using de4dot.blocks;
using de4dot.blocks.cflow;

class NoTransform : ISimpleDeobfuscator {
    public void MethodModified(MethodDef m) {}
    public void Deobfuscate(MethodDef m) {
        foreach(var ins in m.Body.Instructions) {
            var callee=ins.Operand as MethodDef;
            if(ins.OpCode==OpCodes.Call && callee!=null && callee.IsStatic && callee.HasBody && callee.MethodSig.Params.Count==0) {
                var body=callee.Body.Instructions.Where(x=>x.OpCode!=OpCodes.Nop).ToList();
                if(body.Count==2 && body[0].IsLdcI4() && body[1].OpCode==OpCodes.Ret) {
                    ins.OpCode=OpCodes.Ldc_I4; ins.Operand=body[0].GetLdcI4Value();
                }
            }
        }
        var blocks=new Blocks(m); var cf=new BlocksCflowDeobfuscator(); cf.Initialize(blocks); cf.Deobfuscate();
        IList<Instruction> instructions; IList<ExceptionHandler> handlers;
        blocks.GetCode(out instructions,out handlers); DotNetUtils.RestoreBody(m,instructions,handlers);
    }
    public void Deobfuscate(MethodDef m, SimpleDeobfuscatorFlags f) {Deobfuscate(m);}
    public void DecryptStrings(MethodDef m, IDeobfuscator d) {}
}
class StaticResourceDump {
    static int Main(string[] args) {
        try {
            var module = ModuleDefMD.Load(args[0]);
            var type = typeof(ISimpleDeobfuscator).Assembly.GetType("de4dot.code.deobfuscators.dotNET_Reactor.v4.EncryptedResource", true);
            var instance = Activator.CreateInstance(type, new object[]{module});
            MethodDef method = null;
            foreach (var t in module.GetTypes()) foreach (var m in t.Methods)
                if (m.Name.String == (args.Length>2 ? "\u008b\u008f\u009a" : "\u008b\u008f\u009d")) method=m;
            if (method == null) throw new Exception("String decrypter metadata missing");
            type.GetProperty("Method").SetValue(instance, method, null);
            type.GetMethod("Initialize").Invoke(instance,new object[]{new NoTransform()});
            if(args.Length>2) {
                var boolData=(byte[])type.GetMethod("Decrypt").Invoke(instance,new object[0]);
                File.WriteAllBytes(args[1],boolData);
                Console.WriteLine("Static boolean resource bytes="+boolData.Length+" method="+method.MDToken);
                return 0;
            }
            // The observed resource is not AES block-aligned, and the target IL
            // includes the V2 uint mixer. Do not accept legacy V1 autodetection.
            var selected=type.GetField("decrypter",BindingFlags.Instance|BindingFlags.NonPublic).GetValue(instance);
            var key=(byte[])selected.GetType().GetField("key",BindingFlags.Instance|BindingFlags.NonPublic).GetValue(selected);
            var iv=(byte[])selected.GetType().GetField("iv",BindingFlags.Instance|BindingFlags.NonPublic).GetValue(selected);
            var v2=type.GetNestedType("DecrypterV2",BindingFlags.NonPublic);
            var decoder=Activator.CreateInstance(v2,BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic,null,new object[]{iv,key,method},null);
            var resource=type.GetProperty("Resource").GetValue(instance,null);
            var data=(byte[])v2.GetMethod("Decrypt").Invoke(decoder,new object[]{resource});
            File.WriteAllBytes(args[1],data);
            Console.WriteLine("Static resource bytes="+data.Length+" method="+method.MDToken);
            return 0;
        } catch (Exception e) {
            while(e.InnerException!=null) e=e.InnerException;
            Console.Error.WriteLine(e.GetType().FullName+": "+e.Message);
            return 1;
        }
    }
}
