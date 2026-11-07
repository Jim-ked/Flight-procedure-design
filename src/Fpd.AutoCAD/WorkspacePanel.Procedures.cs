using System.Drawing;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly ListBox _procedures=List();
    private readonly ListBox _sequence=List();
    private readonly TextBox _procedureName=Input();
    private readonly ComboBox _runway=new() { Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDown };
    private readonly ComboBox _sections=new() { Width=135,DropDownWidth=340,DropDownStyle=ComboBoxStyle.DropDownList };
    private sealed record SectionRow(ProcedureSection Value) { public override string ToString()=>$"{Value.Name} · {Value.Stage} / {Value.Branch}"; }
    private ProcedureSection? CurrentSection=>(_sections.SelectedItem as SectionRow)?.Value;
    private List<string> CurrentSequence=>CurrentSection?.FixIdents??RequireProcedure().FixIdents;
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
        Row(stack,Bar(_sections,Button("新增段",()=>EditSection(false)),Button("修改段",()=>EditSection(true))),34);
        Row(stack,Bar(_availableFix,Button("追加 Fix",AppendFix)),34);
        Row(stack,Caption("已使用的定位点顺序（允许重复）"),23); Row(stack,_sequence,68,true);
        Row(stack,Bar(Button("删除引用",RemoveReference),Button("上移",()=>MoveReference(-1)),Button("下移",()=>MoveReference(1))),34);
        _sections.SelectedIndexChanged+=(_,_)=> { if(!_refreshing) ShowSequence(); };
        _procedures.SelectedIndexChanged+=(_,_)=> { if(!_refreshing) ShowProcedure(); };
        void SaveFields(object? sender,EventArgs e)
        {
            if(_refreshing || CurrentProcedure is not { } p) return;
            var kind=(ProcedureKind)Math.Max(0,_procedureKind.SelectedIndex);
            if(kind!=ProcedureKind.Approach && p.Sections.Any(s=>s.Stage==ProcedureStage.Missed)) { _refreshing=true; _procedureKind.SelectedIndex=(int)p.Kind; _refreshing=false; SetStatus("含Missed段，须先将该段调整为Main后再改程序类型。"); return; }
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
        _runway.Items.Clear(); _runway.Items.AddRange(_project.Runways.SelectMany(r=>new[] { r.EndA.Designator,r.EndB.Designator }).ToArray()); _runway.Text=p?.Runway??"";
        _tips.SetToolTip(_runway,string.IsNullOrWhiteSpace(p?.Runway)||_runway.Items.Contains(p.Runway)?"项目跑道端":"旧文本未关联现有跑道，内容保留");
        var selected=CurrentSection; _sections.Items.Clear(); _sections.Items.Add("主顺序");
        if(p is not null) foreach(var section in p.Sections) _sections.Items.Add(new SectionRow(section));
        _sections.SelectedIndex=0;
        for(var i=1;i<_sections.Items.Count;i++) if(((SectionRow)_sections.Items[i]!).Value==selected) _sections.SelectedIndex=i;
        ShowSequence();
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
        var sequence=CurrentSequence; sequence.Add(ident); Changed(); RefreshProcedures(p); _sequence.SelectedIndex=sequence.Count-1;
    }
    private void RemoveReference()
    {
        var p=RequireProcedure(); if(_sequence.SelectedIndex<0) throw new InvalidOperationException("请选择要移除的引用。");
        CurrentSequence.RemoveAt(_sequence.SelectedIndex); Changed(); RefreshProcedures(p);
    }
    private void MoveReference(int direction)
    {
        var p=RequireProcedure(); var sequence=CurrentSequence; var index=_sequence.SelectedIndex; var target=index+direction;
        if(index<0 || target<0 || target>=sequence.Count) return;
        (sequence[index],sequence[target])=(sequence[target],sequence[index]); Changed(); RefreshProcedures(p); _sequence.SelectedIndex=target;
    }
    private void ShowSequence()
    {
        var old=_sequence.SelectedIndex; _sequence.Items.Clear();
        if(CurrentProcedure is not null) _sequence.Items.AddRange(CurrentSequence.Select((id,i)=>$"{i+1:00}   {id}").ToArray());
        if(old>=0 && _sequence.Items.Count>0) _sequence.SelectedIndex=Math.Min(old,_sequence.Items.Count-1);
    }
    private void EditSection(bool edit)
    {
        var p=RequireProcedure(); var previous=edit?CurrentSection:null;
        if(edit && previous is null) throw new InvalidOperationException("主顺序使用程序基本信息；请先选择分段。");
        using var dialog=new ProcedureSectionDialog(p,_project.Runways,previous);
        if(dialog.ShowDialog(this)!=DialogResult.OK) return;
        if(p.Sections.Any(s=>s!=previous && s.Name.Equals(dialog.Value.Name,StringComparison.OrdinalIgnoreCase))) throw new InvalidOperationException("段名称重复。");
        if(previous is null) p.Sections.Add(dialog.Value); else p.Sections[p.Sections.IndexOf(previous)]=dialog.Value;
        Changed(); RefreshProcedures(p);
        for(var i=1;i<_sections.Items.Count;i++) if(((SectionRow)_sections.Items[i]!).Value==dialog.Value) _sections.SelectedIndex=i;
    }

}
