using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

// L1 processed --/--.cs:78403; raw fields 0x04000731/732 confirm private names.
// Serialization + notifications slice; no target DLL load, no CAD calls here.
[DataContract]
public class EntityFrameRecovered : INotifyPropertyChanged {
    [DataMember(Name="\u008a\u009a\u008e")] private string entityName="";
    [DataMember(Name="\u008a\u009a\u008f")] private int entityType=99;
    [DataMember] public Dictionary<string,object> Properties { get; set; }
    public string EntityName { get { return entityName; } set { if(entityName!=value) { entityName=value;Notify("EntityName"); } } }
    public int EntityType { get { return entityType; } set { if(entityType!=value) { entityType=value;Notify("EntityType"); } } }
    public event PropertyChangedEventHandler PropertyChanged;
    // Source79413 constructor; int carries original enum's numeric JSON value only.
    public EntityFrameRecovered() { Properties=new Dictionary<string,object>(); }
    // Source78549 _008A_0099_008C; original token/RVA in evidence.md.
    public void Notify(string name) { var handler=PropertyChanged;if(handler!=null) handler(this,new PropertyChangedEventArgs(name)); }
    // Original0x06000711 RVA0xBE158 / processed710, source78618.
    public string ToJson(Action<string> alert) {
        try {
            var serializer=new DataContractJsonSerializer(typeof(EntityFrameRecovered));
            using(var stream=new MemoryStream()) {
                serializer.WriteObject(stream,this); byte[] bytes=stream.ToArray();
                if(bytes.Length>16384) alert(string.Format("警告：XData 数据大小超过 16KB ({0} bytes)，可能导致保存失败",bytes.Length));
                return Encoding.UTF8.GetString(bytes,0,bytes.Length);
            }
        } catch(Exception ex) { alert("序列化失败: "+ex.Message);return ""; }
    }
    // Original0x06000712 RVA0xBE298 / processed711, source78647.
    public static EntityFrameRecovered FromJson(string json,Action<string> alert) {
        if(!string.IsNullOrEmpty(json)) {
            try {
                var serializer=new DataContractJsonSerializer(typeof(EntityFrameRecovered));
                using(var stream=new MemoryStream(Encoding.UTF8.GetBytes(json))) return (EntityFrameRecovered)serializer.ReadObject(stream);
            } catch(Exception ex) { alert("反序列化失败: "+ex.Message);return new EntityFrameRecovered(); }
        }
        alert("反序列化失败: JSON 字符串为空");return new EntityFrameRecovered();
    }
    // Original0x06000713 RVA0xBE3C4 / processed712, source78664 string slice.
    public List<string> JsonChunks(string json) {
        var chunks=new List<string>();
        for(int i=0;i<json.Length;i+=250) chunks.Add(json.Substring(i,Math.Min(250,json.Length-i)));
        return chunks;
    }
}
