using System;
using System.Text;
class XDataTests {
    static int count;
    static void Check(bool ok,string message) { if(!ok) throw new Exception(message); count++; }
    static void Main() {
        string alert="";
        var line=new CalcuLineRecovered { Kind=7, CenterX=12.5, Parameters=new CalcuParametersRecovered { SecondsC=6 } };
        string json=line.ToJson(s=>alert=s);
        Check(json.Length>0 && alert=="","line serialization");
        Check(json.Contains("\"\u008a\u0090\u0098\":7") && !json.Contains("_008A_"),"raw metadata names, not decompiler aliases");
        Check(!json.Contains("CenterX") && !json.Contains("Kind"),"friendly names must not leak into old schema");
        var read=CalcuLineRecovered.FromJson(json,s=>alert=s);
        Check(read.Kind==7 && read.CenterX==12.5 && read.Parameters.SecondsC==6,"nested parameters roundtrip");
        Check(CalcuLineRecovered.FromJson("",s=>alert=s).Kind==1,"empty line uses constructor defaults");
        var frame=new EntityFrameRecovered { EntityName="障碍物A", EntityType=3 };
        frame.Properties["Height"]=123.5;
        string fjson=frame.ToJson(s=>alert=s);
        Check(fjson.Length>0 && !fjson.Contains("EntityName"),"frame uses private wire names");
        Check(fjson.Contains("\"Properties\":[{\"Key\":\"Height\",\"Value\":123.5}]") && fjson.Contains("\"\u008a\u009a\u008f\":3"),"dictionary entry array and original frame key");
        var fr=EntityFrameRecovered.FromJson(fjson,s=>alert=s);
        Check(fr.EntityName=="障碍物A" && fr.EntityType==3 && Convert.ToDouble(fr.Properties["Height"])==123.5,"frame roundtrip");
        var chunks=frame.JsonChunks(fjson);
        Check(string.Concat(chunks.ToArray())==fjson,"chunks join exactly");
        chunks=frame.JsonChunks(new string('中',501));
        Check(chunks.Count==3 && chunks[0].Length==250 && Encoding.UTF8.GetByteCount(chunks[0])==750 && chunks[2].Length==1,"250 chars not bytes");
        frame.Properties["Long"]=new string('a',17000);
        Check(frame.ToJson(s=>alert=s).Length>17000 && alert.Contains("16KB"),"oversize warns but returns JSON");
        Check(EntityFrameRecovered.FromJson("bad",s=>alert=s).EntityType==99,"bad frame uses type99 default");
        var faf=CalcuFactoryRecovered.Faf(1,2,0.5,5000,900,100,3,15,15000);
        Check(faf.Kind==1 && faf.Length==20000 && faf.Parameters.IntermediateLength==5000 && faf.Parameters.FafThrDistance==15000,"FAF parameter factory");
        var npa=CalcuFactoryRecovered.Npa(1,2,0.5,380,345,19,600,15,18,1995);
        Check(npa.Kind==3 && npa.Parameters.IAS==345 && npa.Parameters.WindSpeed==19 && npa.Parameters.SecondsNpa==18,"NPA factory fields");
        var pa=CalcuFactoryRecovered.Pa(1,2,0.5,"D",3,-900,100,1800,49,26,52.1,14);
        Check(pa.Kind==4 && pa.Parameters.HlCorrection==52.1 && pa.Parameters.ThrSocDistance==14,"PA factory fields");
        Check(CalcuFactoryRecovered.MissedTp(1,2,0,100,300,2.5,8000).Kind==5,"missed kind");
        Check(CalcuFactoryRecovered.DepartureTp(1,2,0,100,305,2.5,8000).Kind==6,"departure kind");
        Check(CalcuFactoryRecovered.C(1,2,0,6,500).Length==10000,"C factory length before actual line overrides");
        Console.WriteLine("PASS "+count+" recovered XData checks; NOT original runtime or DWG compatibility verification.");
        Console.WriteLine("FRAME SAMPLE: "+fjson);
        Console.WriteLine("LINE SAMPLE: "+json);
    }
}
