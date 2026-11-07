using System.Drawing;
using System.Windows.Forms;
using Fpd.Core;

namespace Fpd.AutoCAD;

public sealed partial class WorkspacePanel
{
    private readonly ComboBox _procedures=new() { Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList };
    private readonly ComboBox _paths=new() { Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList };
    private readonly ComboBox _procedureKind=new() { Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList };
    private readonly ListBox _sequence=List();
    private readonly ComboBox _symbol=new() { Dock=DockStyle.Fill,DropDownStyle=ComboBoxStyle.DropDownList };
    private readonly CheckBox _missed=new() { Text="复飞用途",AutoSize=true };
    private readonly TextBox _annotation=Input();
    private ProcedureData? CurrentProcedure=>(_procedures.SelectedItem as ProcedureRow)?.Value;
    private ProcedurePath? CurrentPath=>(_paths.SelectedItem as PathRow)?.Value;
    private sealed record ProcedureRow(ProcedureData Value) { public override string ToString()=>Value.Name; }
    private sealed record PathRow(ProcedurePath Value) { public override string ToString()=>Value.Name; }
    private sealed record SymbolChoice(string Key,string Label) { public override string ToString()=>Label; }
    private ProcedureData RequireProcedure()=>CurrentProcedure??throw new InvalidOperationException("请先选择具体程序。");
    private ProcedurePath RequirePath()=>CurrentPath??throw new InvalidOperationException("请新建或选择一条路径。");
    private TabPage ProcedurePage()
    {
        var page=Page("程序"); var stack=Stack(); var fields=FormGrid();
        _procedureKind.Items.AddRange(new[]{"离场","进场","进近"}); _procedureKind.SelectedIndex=0;
        Field(fields,"类别",_procedureKind); Field(fields,"具体程序",_procedures); Field(fields,"路径",_paths); Row(stack,fields,94);
        Row(stack,Bar(MenuButton("管理",("新建程序",NewProcedure),("重命名程序",RenameProcedure),("删除程序",DeleteProcedure),("新建路径",NewPath),("重命名路径",RenamePath),("删除路径",DeletePath)),_missed),32);
        Row(stack,_sequence,100,true);
        Row(stack,Bar(MenuButton("列表选点",("追加",()=>AcquireFixes(false,0)),("在所选前插入",()=>AcquireFixes(false,-1)),("在所选后插入",()=>AcquireFixes(false,1))),MenuButton("CAD逐点",("追加",()=>AcquireFixes(true,0)),("在所选前插入",()=>AcquireFixes(true,-1)),("在所选后插入",()=>AcquireFixes(true,1))),MenuButton("顺序",("上移",()=>MoveReference(-1)),("下移",()=>MoveReference(1)),("反转整条",ReversePath),("移除引用",RemoveReference))),32);
        var detail=FormGrid();
        _symbol.Items.AddRange(new object[]{new SymbolChoice("FlyBy","Fly-by"),new SymbolChoice("FlyOver","Fly-over"),new SymbolChoice("Reporting","报告点（以审计映射为准）")});
        Field(detail,"图符",_symbol); Field(detail,"注记",_annotation); Row(stack,detail,62);
        Row(stack,Bar(Button("绘制程序图符",DrawProcedureSymbols)),32);
        _procedureKind.SelectedIndexChanged+=(_,_)=> { if(!_refreshing) RefreshProcedures(); };
        _procedures.SelectedIndexChanged+=(_,_)=> { if(!_refreshing) ShowProcedure(); };
        _paths.SelectedIndexChanged+=(_,_)=> { if(!_refreshing) ShowSequence(); };
        _sequence.SelectedIndexChanged+=(_,_)=>ShowReference();
        _symbol.SelectedIndexChanged+=(_,_)=> { if(!_refreshing && SelectedUse() is { } use && _symbol.SelectedItem is SymbolChoice symbol) { use.SymbolKey=symbol.Key; Changed(); ShowSequence(); } };
        _annotation.TextChanged+=(_,_)=> { if(!_refreshing && SelectedUse() is { } use) { use.Annotation=string.IsNullOrWhiteSpace(_annotation.Text)?null:_annotation.Text.Trim(); Changed(); } };
        _missed.CheckedChanged+=(_,_)=> { if(!_refreshing && CurrentPath is { } path && CurrentProcedure is { } procedure) { if(_missed.Checked && procedure.Kind!=ProcedureKind.Approach) throw new InvalidOperationException("复飞用途只适用于进近程序。"); path.IsMissed=_missed.Checked; Changed(); } };
        _sequence.KeyDown+=(_,e)=> { if(e.Alt && e.KeyCode==Keys.Up) { Run(()=>MoveReference(-1)); e.SuppressKeyPress=true; } if(e.Alt && e.KeyCode==Keys.Down) { Run(()=>MoveReference(1)); e.SuppressKeyPress=true; } if(e.KeyCode==Keys.Delete) { Run(RemoveReference); e.SuppressKeyPress=true; } };
        page.Controls.Add(stack); return page;
    }
    private void RefreshProcedures(ProcedureData? select=null)
    {
        var selected=select??CurrentProcedure; _refreshing=true;
        try
        {
            if(select is not null) _procedureKind.SelectedIndex=(int)select.Kind;
            _procedures.Items.Clear(); foreach(var p in _project.Procedures.Where(p=>(int)p.Kind==_procedureKind.SelectedIndex)) _procedures.Items.Add(new ProcedureRow(p));
            for(var i=0;i<_procedures.Items.Count;i++) if(((ProcedureRow)_procedures.Items[i]!).Value==selected) _procedures.SelectedIndex=i;
            if(_procedures.SelectedIndex<0 && _procedures.Items.Count>0) _procedures.SelectedIndex=0;
        }
        finally { _refreshing=false; }
        ShowProcedure();
    }
    private void ShowProcedure()
    {
        var old=CurrentPath; _refreshing=true;
        try
        {
            _paths.Items.Clear(); if(CurrentProcedure is { } p) foreach(var path in p.Paths) { var i=_paths.Items.Add(new PathRow(path)); if(path==old) _paths.SelectedIndex=i; }
            if(_paths.SelectedIndex<0 && _paths.Items.Count>0) _paths.SelectedIndex=0;
        }
        finally { _refreshing=false; }
        ShowSequence();
    }
    private void ShowSequence()
    {
        var old=_sequence.SelectedIndex; _refreshing=true;
        try
        {
            _sequence.Items.Clear(); if(CurrentPath is { } path) _sequence.Items.AddRange(path.Fixes.Select((f,i)=>$"{i+1:00}   {f.FixIdent}   {f.SymbolKey}").ToArray());
            if(old>=0 && _sequence.Items.Count>0) _sequence.SelectedIndex=Math.Min(old,_sequence.Items.Count-1);
            _missed.Enabled=CurrentProcedure?.Kind==ProcedureKind.Approach && CurrentPath is not null; _missed.Checked=CurrentPath?.IsMissed==true;
            _tips.SetToolTip(_paths,CurrentPath?.MigrationNote??CurrentPath?.Name??"");
        }
        finally { _refreshing=false; }
        ShowReference();
    }
    private FixUse? SelectedUse()=>CurrentPath is { } path && _sequence.SelectedIndex>=0 && _sequence.SelectedIndex<path.Fixes.Count?path.Fixes[_sequence.SelectedIndex]:null;
    private void ShowReference()
    {
        var prior=_refreshing; _refreshing=true;
        try { var use=SelectedUse(); _annotation.Text=use?.Annotation??""; _symbol.SelectedIndex=-1; foreach(var item in _symbol.Items.Cast<SymbolChoice>()) if(item.Key==use?.SymbolKey) _symbol.SelectedItem=item; _symbol.Enabled=_annotation.Enabled=use is not null; }
        finally { _refreshing=prior; }
    }
    private void NewProcedure()
    {
        var name=PromptText("新建具体程序","程序名称"); if(name is null) return;
        if(_project.Procedures.Any(p=>p.Name.Equals(name,StringComparison.OrdinalIgnoreCase))) throw new InvalidOperationException("程序名称重复。");
        var p=new ProcedureData { Name=name,Kind=(ProcedureKind)_procedureKind.SelectedIndex,PathsMigrated=true }; _project.Procedures.Add(p); Changed(); RefreshProcedures(p);
    }
    private void RenameProcedure() { var p=RequireProcedure(); var name=PromptText("重命名程序","名称",p.Name); if(name is null) return; if(_project.Procedures.Any(x=>x!=p && x.Name.Equals(name,StringComparison.OrdinalIgnoreCase))) throw new InvalidOperationException("程序名称重复。"); p.Name=name; Changed(); RefreshProcedures(p); }
    private void DeleteProcedure() { var p=RequireProcedure(); if(MessageBox.Show(this,$"删除程序 {p.Name} 及其路径？CAD图形保留。","删除程序",MessageBoxButtons.OKCancel)!=DialogResult.OK) return; _project.Procedures.Remove(p); Changed(); RefreshProcedures(); }
    private void NewPath() { var p=RequireProcedure(); var name=PromptText("新建路径","路径名称"); if(name is null) return; var path=ProcedurePaths.Add(p,name); Changed(); ShowProcedure(); SelectPath(path); }
    private void RenamePath() { var p=RequireProcedure(); var path=RequirePath(); var name=PromptText("重命名路径","路径名称",path.Name); if(name is null) return; ProcedurePaths.Rename(p,path,name); Changed(); ShowProcedure(); SelectPath(path); }
    private void DeletePath() { var p=RequireProcedure(); var path=RequirePath(); if(MessageBox.Show(this,$"删除路径 {path.Name}？CAD图形保留。","删除路径",MessageBoxButtons.OKCancel)!=DialogResult.OK) return; p.Paths.Remove(path); Changed(); ShowProcedure(); }
    private void SelectPath(ProcedurePath path) { for(var i=0;i<_paths.Items.Count;i++) if(((PathRow)_paths.Items[i]!).Value==path) _paths.SelectedIndex=i; }
    private void RemoveReference() { var path=RequirePath(); if(_sequence.SelectedIndex<0) return; path.Fixes.RemoveAt(_sequence.SelectedIndex); Changed(); ShowSequence(); }
    private void MoveReference(int direction) { var path=RequirePath(); var target=ProcedurePaths.Move(path,_sequence.SelectedIndex,direction); Changed(); ShowSequence(); if(target>=0) _sequence.SelectedIndex=target; }
    private void ReversePath() { RequirePath().Fixes.Reverse(); Changed(); ShowSequence(); }
    private void AcquireFixes(bool cad,int mode)
    {
        var project=_project; var procedure=RequireProcedure(); var path=RequirePath(); var dwg=_drawingPath();
        var index=mode==0?path.Fixes.Count:_sequence.SelectedIndex+(mode>0?1:0);
        if(mode!=0 && _sequence.SelectedIndex<0) throw new InvalidOperationException("请选择插入位置。");
        void Apply(IReadOnlyList<string>? ids)
        {
            if(ids is null) { SetStatus("已取消本轮选点，原顺序保持"); return; }
            if(project!=_project || CurrentProcedure!=procedure || CurrentPath!=path || _drawingPath()!=dwg || !procedure.Paths.Contains(path)) throw new InvalidOperationException("设计目标已切换，本轮未写入。");
            if(ids.Any(id=>!project.Fixes.Any(f=>f.Ident==id))) throw new InvalidOperationException("项目点已变化，请重新选点。");
            ProcedurePaths.Insert(path,index,ids); Changed(); ShowSequence(); if(ids.Count>0) _sequence.SelectedIndex=index+ids.Count-1; SetStatus($"按顺序加入 {ids.Count} 个引用");
        }
        if(cad) { if(!BaseMapPolicy.CanWrite(project.DwgPath,dwg)) throw new InvalidOperationException("请先关联并打开项目DWG。"); CadOperation(()=>Apply(CadDrawing.PickFixOrder(project))); }
        else { using var dialog=new FixOrderDialog(project.Fixes); if(dialog.ShowDialog(this)==DialogResult.OK) Apply(dialog.Identifiers); }
    }
    private void DrawProcedureSymbols()
    {
        var procedure=RequireProcedure(); var path=RequirePath(); var scale=PromptText("程序图符","图符宽度(m)","100"); if(scale is null) return;
        if(!double.TryParse(scale,System.Globalization.NumberStyles.Float,System.Globalization.CultureInfo.InvariantCulture,out var value) || !double.IsFinite(value) || value<=0) throw new InvalidOperationException("图符宽度须为正数。");
        var height=TextHeight; CadOperation(()=> { CadDrawing.DrawProcedure(_project,procedure,path,value,height); SetStatus("程序图符已处理；原生U撤销"); });
    }
}
