using System;
using System.Text;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
#endif

// L1/L2 restored scanner, deliberately NOT replaced by a standards-compliant JSON parser.
// Action<string> substitutes only Editor.WriteMessage for testing the same text output.
public class XInfoRecovered
{
#if AUTOCAD
    // Original 0x06000075 RVA 0x470C; processed 0x06000074.
    // Native command not built/run here: AutoCAD references are unavailable.
    [CommandMethod("xInfo")]
    public void InspectEntity() {
        var document=Application.DocumentManager.MdiActiveDocument;
        Editor editor=document.Editor;
        PromptEntityResult selected=editor.GetEntity(new PromptEntityOptions("请选择实体对象"));
        if(selected.Status!=PromptStatus.OK)return;
        using(Transaction transaction=document.Database.TransactionManager.StartTransaction()) {
            ResultBuffer data=((Entity)transaction.GetObject(selected.ObjectId,OpenMode.ForRead)).XData;
            if(data==null) { editor.WriteMessage("Non-Information avaiable\n"); return; }
            string app="";
            foreach(TypedValue value in data.AsArray()) {
                if(value.TypeCode==1001) { app=value.Value.ToString();continue; }
                FormatValue(s=>editor.WriteMessage(s),app,value.Value is string?(string)value.Value:value.Value.ToString());
            }
        }
    }
#endif
    // Original 0x06000076 RVA 0x49FC; processed 0x06000075.
    public static void FormatValue(Action<string> write,string app,string value) {
        string text=value.TrimStart();
        if(!text.StartsWith("{")&&!text.StartsWith("[")) { write(app+" = "+value+"\n");return; }
        write(app+"\n"); int index=0; Print(write,text,ref index,1);
    }
    // Original 0x06000077 RVA 0x4B30; processed 0x06000076.
    static void Print(Action<string> write,string text,ref int index,int depth) {
        White(text,ref index);if(index>=text.Length)return;
        string indent=new string(' ',depth*2);char c=text[index];
        if(c=='{') {
            index++;
            while(true) {
                White(text,ref index);
                if(index<text.Length&&text[index]=='}') {index++;return;}
                string key=Quoted(text,ref index);
                White(text,ref index);index++;White(text,ref index);
                if(Scalar(text,index))write(indent+key+" = "+Raw(text,ref index)+"\n");
                else {write(indent+key+"\n");Print(write,text,ref index,depth+1);}
                White(text,ref index);if(index<text.Length&&text[index]==',')index++;
            }
        }
        if(c=='[') {
            index++;
            while(true) {
                White(text,ref index);
                if(index<text.Length&&text[index]==']') {index++;return;}
                if(Scalar(text,index))write(indent+"- "+Raw(text,ref index)+"\n");
                else {write(indent+"-\n");Print(write,text,ref index,depth+1);}
                White(text,ref index);if(index<text.Length&&text[index]==',')index++;
            }
        }
        write(indent+(c=='"'?Quoted(text,ref index):Raw(text,ref index))+"\n");
    }
    // Original 0x06000078 RVA 0x4F64; processed 0x06000077.
    static void White(string s,ref int i) {while(i<s.Length&&char.IsWhiteSpace(s[i]))i++;}
    // Original 0x06000079 RVA 0x5014; processed 0x06000078.
    static bool Scalar(string s,int i) {return i<s.Length&&s[i]!='{'&&s[i]!='[';}
    // Original 0x0600007A RVA 0x5048; processed 0x06000079.
    static string Quoted(string s,ref int i) {
        i++;var result=new StringBuilder();
        while(i<s.Length) {
            char c=s[i++];
            if(c=='\\'&&i<s.Length) {
                char e=s[i++];
                switch(e) {case 't':result.Append('\t');break;case 'r':result.Append('\r');break;case 'n':result.Append('\n');break;default:result.Append(e);break;}
            } else if(c=='"')return result.ToString();else result.Append(c);
        }
        return result.ToString();
    }
    // Original 0x0600007B RVA 0x5234; processed 0x0600007A.
    static string Raw(string s,ref int i) {int start=i;while(i<s.Length&&s[i]!=','&&s[i]!='}'&&s[i]!=']')i++;return s.Substring(start,i-start).Trim();}
}
