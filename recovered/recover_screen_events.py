"""Transcribe repeated ScreenData/Mark slices using existing source declarations.
All inputs are static reading copies. Output is partial C#, never a running plugin.
Generation is an analysis aid, not a change to the target software architecture.
"""
from pathlib import Path
import csv,json,re
BASE=Path(__file__).resolve().parent
R=BASE.parent/'reverse-analysis'
with (R/'04_type-map/method-source-locations.csv').open(encoding='utf-8-sig',newline='') as f:locations=list(csv.DictReader(f))
source=(R/'03_recovered-src/annotated-strings/--/--.cs').read_text(encoding='utf-8').splitlines()
forms=[
    ('DepartureObstacleFormRecovered','_0089_0086','_0087_0086_009B','_0087_0086_009C','_0087_0087_009C',True,False,'obst'),
    ('DmeObstacleFormRecovered','_0089_0088','_0087_008D_009D','_0087_008D_009E','_0087_008E_0091',False,False,'Obst'),
    ('ApproachObstacleFormRecovered','_008B_008C','_0088_009A_0095','_0088_009A_0096','_0088_009B_0092',False,False,'obst'),
    ('PbnIlsObstacleFormRecovered','_008B_0096','_0089_0095_0093','_0089_0095_0094','_0089_0097_0089',True,True,'obst'),
    ('PbnDepartureObstacleFormRecovered','_008B_0094','_0089_008E_0099','_0089_008E_009A','_0089_008F_009B',True,True,'obst'),
]
def location(cls,name):return next(r for r in locations if r['class']==cls and r['method']==name and r['source'].endswith(r'--\--.cs'))
def body(loc):
    start=int(loc['line'])
    end=min([int(r['line']) for r in locations if r['source']==loc['source'] and int(r['line'])>start],default=len(source)+1)
    return '\n'.join(source[start-1:end-1])
output=['// Recovered repeated window slices. Native reference compilation/host tests pending.',
        '// Designer/config and the other evaluation methods are outside this file.',
        '#if AUTOCAD','using System;','using System.Collections.Generic;','using System.Data;','using System.Linq;',
        'using System.Windows.Forms;','using Autodesk.AutoCAD.DatabaseServices;',
        'using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;']
index=[]
for name,cls,screen,table,mark,pre,limit,block in forms:
    sl,tl,ml=[location(cls,m) for m in (screen,table,mark)]
    # Fail if evidence does not match the precise native operations ported here.
    assert '_008B_008A<DBPoint>' in body(sl),screen
    assert ('Take(5)' in body(sl))==limit,screen
    assert '"'+block+'"' in body(ml) and '"Altitude"' in body(ml),mark
    assert '"Name"' not in body(ml),mark
    columns=re.findall(r'dataTable.Columns.Add\((".*?"\s*/\*.*?\*/\s*,\s*typeof\(\w+\))\);',body(tl))
    assert len(columns)>=8,table
    columns=[re.sub(r'\s*/\*.*?\*/','',s) for s in columns]
    output += ['','public partial class '+name+':Form {',
        '    public DataGridView Grid;public Label Status;',
        '    private List<DBPoint> points;private Dictionary<string,DBPoint> originals;',
        '    // '+sl['tokens']+' '+sl['source']+':'+sl['line'],
        '    public void Screen(object sender,EventArgs args) {']
    if pre: output += ['        points=new List<DBPoint>();originals=new Dictionary<string,DBPoint>();']
    elif name=='DmeObstacleFormRecovered':output+=['        points=new List<DBPoint>();']
    output += ['        var db=AcApp.DocumentManager.MdiActiveDocument.Database;',
               '        using(var tr=db.TransactionManager.StartTransaction()) {',
               '            points=ObstacleCadRecovered.ScreenData<DBPoint>(db,OpenMode.ForRead,false);']
    if limit: output += ['            if(points.Count>5) { MessageBox.Show("基础版仅提供前5项数据评估。");points=points.Take(5).ToList(); }']
    output += ['        }','        Status.Text="已检测到 "+points.Count+" 个障碍物。";','        ShowImported();','    }',
               '    // '+tl['tokens']+' '+tl['source']+':'+tl['line'],'    private void ShowImported() {']
    if not pre:output+=['        originals=new Dictionary<string,DBPoint>();']
    output+=['        var table=new DataTable();']+['        table.Columns.Add('+c+');' for c in columns]
    output+=['        int ordinal=1;','        foreach(var point in points) {',
             '            var p=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());',
             '            table.Rows.Add(p.ID,p.Name,Math.Round(p.X,2),Math.Round(p.Y,2),Math.Round(p.Z,2));originals.Add(p.ID,point);',
             '        }','        Grid.DataSource=table;Grid.Columns[1].Frozen=true;','    }',
             '    // '+ml['tokens']+' '+ml['source']+':'+ml['line'],'    public void Mark(object sender,EventArgs args) {',
             '        foreach(DataGridViewRow row in Grid.SelectedRows) {',
             '            var point=originals[Grid.Rows[row.Index].Cells[0].Value.ToString()];',
             '            var id=ObstacleCadRecovered.Insert("'+block+'",point.Position);',
             '            ObstacleCadRecovered.SetAttribute(id,"Altitude",point.Position.Z.ToString());','        }','    }']
    if name in ('PbnIlsObstacleFormRecovered','PbnDepartureObstacleFormRecovered'):
        disabled=location(cls,'_0089_0096_008B' if name=='PbnIlsObstacleFormRecovered' else '_0089_008F_008B')
        message='基础版不支持此功能。' if name=='PbnIlsObstacleFormRecovered' else '请指定转弯点。'
        assert '"'+message+'"' in body(disabled)
        output+=['    // Actual buttonEvl body '+disabled['tokens']+'; other evaluation methods still exist.',
                 '    public void EvaluateButton(object sender,EventArgs args) { MessageBox.Show("'+message+'"); }']
        index.append(dict(port='EvaluateButton',form=name,**disabled))
    output+=['}']
    for method,loc in [('Screen',sl),('ShowImported',tl),('Mark',ml)]:index.append(dict(port=method,form=name,**loc))
output+=['#endif','']
(BASE/'ObstacleData/ScreenData.OtherForms.Recovered.cs').write_text('\n'.join(output),encoding='utf-8')
(BASE/'ObstacleData/evidence/screen-port-locations.json').write_text(json.dumps(index,ensure_ascii=False,indent=2),encoding='utf-8')
print('Recovered five ScreenData/Mark slices and two actual button messages; no CAD build/run.')
