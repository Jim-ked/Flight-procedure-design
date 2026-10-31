using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

// L1 processed --/--.cs:74562 and 75214; raw metadata names are C1 characters,
// NOT the decompiler's printable _008A_... identifiers. Name preserves wire members.
// These are serialization slices, not the property-grid/UI or licensing implementation.
[DataContract]
public class CalcuLineRecovered {
    [DataMember(Name="\u008a\u0090\u0098")] public int Kind { get; set; }
    [DataMember(Name="\u008a\u0090\u009d")] public double CenterX { get; set; }
    [DataMember(Name="\u008a\u0091\u0087")] public double CenterY { get; set; }
    [DataMember(Name="\u008a\u0091\u008a")] public double CenterZ { get; set; }
    [DataMember(Name="\u008a\u0091\u008d")] public double Direction { get; set; }
    [DataMember(Name="\u008a\u0091\u0090")] public double Length { get; set; }
    [DataMember(Name="\u008a\u0091\u0093")] public string Description { get; set; }
    [DataMember(Name="\u008a\u0091\u0096")] public CalcuParametersRecovered Parameters { get; set; }
    [DataMember(Name="\u008a\u0091\u0099")] public DateTime Created { get; set; }
    [DataMember(Name="\u008a\u0091\u009c")] public string Creator { get; set; }
    // --/--.cs:75165 constructor. Enum wire representation is numeric; int is a
    // serialization-only carrier, not a recovered replacement for the property-grid enum.
    public CalcuLineRecovered() { Kind=1;Length=20000;Description="";Parameters=new CalcuParametersRecovered();Created=DateTime.Now;Creator=""; }
    // Original0x06000650 RVA0xB8558 / processed64F, source74863.
    // alert replaces only the host ShowAlertDialog boundary; no JSON options added.
    public string ToJson(Action<string> alert) {
        try {
            var serializer=new DataContractJsonSerializer(typeof(CalcuLineRecovered));
            using(var stream=new MemoryStream()) {
                serializer.WriteObject(stream,this); byte[] bytes=stream.ToArray();
                if(bytes.Length>16384) alert(string.Format("警告：XData 数据大小超过 16KB ({0} bytes)，可能导致保存失败",bytes.Length));
                return Encoding.UTF8.GetString(bytes,0,bytes.Length);
            }
        } catch(Exception ex) { alert("序列化失败: "+ex.Message);return ""; }
    }
    // Original0x06000651 RVA0xB8698 / processed650, source74888. Missing JSON invokes constructor, unlike
    // deserialization of '{}' which bypasses constructors under DataContract rules.
    public static CalcuLineRecovered FromJson(string json,Action<string> alert) {
        if(string.IsNullOrEmpty(json)) return new CalcuLineRecovered();
        try {
            var serializer=new DataContractJsonSerializer(typeof(CalcuLineRecovered));
            using(var stream=new MemoryStream(Encoding.UTF8.GetBytes(json))) return (CalcuLineRecovered)serializer.ReadObject(stream);
        } catch(Exception ex) { alert("反序列化失败: "+ex.Message);return new CalcuLineRecovered(); }
    }
}
[DataContract]
public class CalcuParametersRecovered {
    [DataMember(Name="\u008a\u0092\u0092")] public double IntermediateLength { get; set; }
    [DataMember(Name="\u008a\u0092\u0095")] public double FafAltitude { get; set; }
    [DataMember(Name="\u008a\u0092\u0098")] public double ThrElevation { get; set; }
    [DataMember(Name="\u008a\u0092\u009b")] public double FafGp { get; set; }
    [DataMember(Name="\u008a\u0092\u009e")] public double Rdh { get; set; }
    [DataMember(Name="\u008a\u0093\u0088")] public double FafThrDistance { get; set; }
    [DataMember(Name="\u008a\u0093\u008b")] public double Tas { get; set; }
    [DataMember] public double IAS { get; set; }
    [DataMember] public double WindSpeed { get; set; }
    [DataMember] public double Altitude { get; set; }
    [DataMember] public double Temperature { get; set; }
    [DataMember(Name="\u008a\u0093\u0096")] public double SecondsNpa { get; set; }
    [DataMember(Name="\u008a\u0093\u0099")] public double NpaDistance { get; set; }
    [DataMember(Name="\u008a\u0093\u009c")] public double PaGp { get; set; }
    [DataMember(Name="\u008a\u0094\u0086")] public double Xz { get; set; }
    [DataMember(Name="\u008a\u0094\u0089")] public double Dh { get; set; }
    [DataMember(Name="\u008a\u0094\u008c")] public double Elevation { get; set; }
    [DataMember(Name="\u008a\u0094\u008f")] public string Category { get; set; }
    [DataMember(Name="\u008a\u0094\u0092")] public double Hlm { get; set; }
    [DataMember(Name="\u008a\u0094\u0095")] public double Hlr { get; set; }
    [DataMember(Name="\u008a\u0094\u0098")] public double HlCorrection { get; set; }
    [DataMember(Name="\u008a\u0094\u009b")] public double ThrSocDistance { get; set; }
    [DataMember(Name="\u008a\u0094\u009e")] public double StartAltitude { get; set; }
    [DataMember(Name="\u008a\u0095\u0088")] public double EndAltitude { get; set; }
    [DataMember(Name="\u008a\u0095\u008b")] public double Gradient { get; set; }
    [DataMember(Name="\u008a\u0095\u008e")] public double TpDistance { get; set; }
    [DataMember(Name="\u008a\u0095\u0091")] public double SecondsC { get; set; }
    [DataMember(Name="\u008a\u0095\u0094")] public double CDistance { get; set; }
    public CalcuParametersRecovered() { Category=""; }
}
