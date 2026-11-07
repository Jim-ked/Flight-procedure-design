using System.Drawing;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly ListBox _procedures=List();
    private readonly ListBox _sequence=List();
    private readonly TextBox _procedureName=Input(),_runway=Input();
    private readonly ComboBox _procedureKind=new() { Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList };
    private readonly ComboBox _availableFix=new() { Width=130,DropDownStyle=ComboBoxStyle.DropDownList };
    private ProcedureData? CurrentProcedure => (_procedures.SelectedItem as ProcedureRow)?.Value;
    private sealed record ProcedureRow(ProcedureData Value) { public override string ToString()=>$"{Value.Name} · {Value.Kind} · {Value.FixIdents.Count} 点"; }
    private TabPage ProcedurePage()
    {
        var page=Page("程序"); var stack=Stack();
        Row(stack,Bar(Button("新建程序",NewProcedure),Button("更新信息",UpdateProcedure)),34);
        Row(stack,_procedures,32,true);
        var fields=FormGrid(); Field(fields,"程序名称",_procedureName); _procedureKind.Items.AddRange(Enum.GetNames<ProcedureKind>()); Field(fields,"程序类型",_procedureKind); Field(fields,"关联跑道",_runway); Row(stack,fields,92);
        Row(stack,Bar(_availableFix,Button("追加 Fix",AppendFix)),34);
        Row(stack,Caption("已使用的定位点顺序（允许重复）"),23); Row(stack,_sequence,68,true);
        Row(stack,Bar(Button("删除引用",RemoveReference),Button("上移",()=>MoveReference(-1)),Button("下移",()=>MoveReference(1))),34);
        _procedures.SelectedIndexChanged+=(_,_)=> { if(!_refreshing) ShowProcedure(); };
        void SaveFields(object? sender,EventArgs e)
        {
            if(_refreshing || CurrentProcedure is not { } p) return;
            p.Name=_procedureName.Text.Trim(); p.Runway=string.IsNullOrWhiteSpace(_runway.Text)?null:_runway.Text.Trim(); p.Kind=(ProcedureKind)Math.Max(0,_procedureKind.SelectedIndex); Changed();
        }
        _procedureName.TextChanged+=SaveFields; _runway.TextChanged+=SaveFields; _procedureKind.SelectedIndexChanged+=SaveFields;
        page.Controls.Add(stack); return page;
    }
    private void RefreshProcedures(ProcedureData? select=null)
    {
        var chosen=select??CurrentProcedure; var fix=_availableFix.SelectedItem as string;
        _refreshing=true;
        try
        {
            _procedures.Items.Clear(); foreach(var p in _project.Procedures) _procedures.Items.Add(new ProcedureRow(p));
            var index=_project.Procedures.IndexOf(chosen!); _procedures.SelectedIndex=index>=0?index:(_project.Procedures.Count>0?0:-1);
            _availableFix.Items.Clear(); _availableFix.Items.AddRange(_project.Fixes.Select(f=>f.Ident).ToArray());
            if(fix is not null && _availableFix.Items.Contains(fix)) _availableFix.SelectedItem=fix; else if(_availableFix.Items.Count>0) _availableFix.SelectedIndex=0;
        }
        finally { _refreshing=false; }
        ShowProcedure();
    }
    private void ShowProcedure()
    {
        _refreshing=true;
        try
        {
        var p=CurrentProcedure; _procedureName.Text=p?.Name??""; _runway.Text=p?.Runway??""; _procedureKind.SelectedIndex=p is null?0:(int)p.Kind;
        var old=_sequence.SelectedIndex; _sequence.Items.Clear(); if(p is not null) _sequence.Items.AddRange(p.FixIdents.Select((id,i)=>$"{i+1:00}   {id}").ToArray());
        if(old>=0 && _sequence.Items.Count>0) _sequence.SelectedIndex=Math.Min(old,_sequence.Items.Count-1);
        }
        finally { _refreshing=false; }
    }
    private ProcedureData RequireProcedure()=>CurrentProcedure??throw new InvalidOperationException("请新建或选择一个程序。");
    private void NewProcedure()
    {
        var n=_project.Procedures.Count+1; var name="程序 "+n;
        while(_project.Procedures.Any(p=>p.Name==name)) name="程序 "+(++n);
        var p=new ProcedureData { Name=name }; _project.Procedures.Add(p); Changed(); RefreshProcedures(p); _procedureName.Focus(); _procedureName.SelectAll();
    }
    private void UpdateProcedure()
    {
        var p=RequireProcedure(); if(string.IsNullOrWhiteSpace(_procedureName.Text)) throw new InvalidOperationException("程序名称不能为空。");
        p.Name=_procedureName.Text.Trim(); p.Kind=(ProcedureKind)_procedureKind.SelectedIndex; p.Runway=string.IsNullOrWhiteSpace(_runway.Text)?null:_runway.Text.Trim();
        Changed(); RefreshProcedures(p); SetStatus("程序信息已更新");
    }
    private void AppendFix()
    {
        var p=RequireProcedure(); var ident=_availableFix.SelectedItem as string??throw new InvalidOperationException("请先选择已有 Fix。");
        p.FixIdents.Add(ident); Changed(); RefreshProcedures(p); _sequence.SelectedIndex=p.FixIdents.Count-1;
    }
    private void RemoveReference()
    {
        var p=RequireProcedure(); if(_sequence.SelectedIndex<0) throw new InvalidOperationException("请选择要移除的引用。");
        p.FixIdents.RemoveAt(_sequence.SelectedIndex); Changed(); RefreshProcedures(p);
    }
    private void MoveReference(int direction)
    {
        var p=RequireProcedure(); var target=ProjectEdits.MoveReference(p,_sequence.SelectedIndex,direction); Changed(); RefreshProcedures(p); if(target>=0) _sequence.SelectedIndex=target;
    }
}
