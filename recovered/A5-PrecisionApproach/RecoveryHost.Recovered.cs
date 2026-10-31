using System;
using System.Collections.Generic;
using Recovered.B4;
namespace Recovered.A5 {
// E3 adapter: does not simulate WinForms change events, cancellation or config order.
public class PrecisionCell:RecoveryCell { public bool Visible=true,Enabled=true; }
// E3 in-memory rows supplied by read-only Python sqlite3 fixtures. This is not a
// replacement database implementation and never loads the target SQLite DLL.
public static class RecoveryDatabase {
 public static string Path="<fixture>/oas.db";
 public static bool Present=true;
 public static Dictionary<string,string> PartA=new Dictionary<string,string>(),PartB=new Dictionary<string,string>();
}
public class SQLiteParameters {
 public string Id;
 public void AddWithValue(string key,object value){if(key!="@id")throw new ArgumentException(key);Id=Convert.ToString(value);}
}
public class SQLiteConnection:IDisposable {
 public SQLiteConnection(string connection){} public void Open(){} public void Close(){} public void Dispose(){}
}
public class SQLiteCommand:IDisposable {
 string sql; public SQLiteParameters Parameters=new SQLiteParameters();
 public SQLiteCommand(string query,SQLiteConnection connection){sql=query;}
 public object ExecuteScalar(){string s;var rows=sql=="SELECT Value FROM PartA WHERE ID = @id"?RecoveryDatabase.PartA:sql=="SELECT Value FROM PartB WHERE ID = @id"?RecoveryDatabase.PartB:null;if(rows==null)throw new ArgumentException(sql);return rows.TryGetValue(Parameters.Id,out s)?s:null;}
 public void Dispose(){}
}
}
