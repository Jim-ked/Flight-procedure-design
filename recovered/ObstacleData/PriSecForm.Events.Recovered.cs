#if AUTOCAD
using System;
using System.Collections.Generic;
using System.Data;
#if ACAD2026_TEST
using DataTable=System.Data.DataTable;
#endif
using System.Linq;
using System.Windows.Forms;
using Autodesk.AutoCAD.DatabaseServices;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
// Original A9 obstacle import/evaluation/mark slices ONLY. No full A9 UI/plugin.
public partial class PriSecFormRecovered:Form {
    public TextBox StartX,StartY,StartHeight,StartWidth,StartMoc,EndX,EndY,EndHeight,EndWidth,EndMoc;
    public CheckBox Intermediate;
    public DataGridView Grid;
    public Label Status,InRange;
    private List<DBPoint> points;
    private Dictionary<string,DBPoint> originals;
    private static DataTable Table() {
        var table=new DataTable();
        table.Columns.Add("ID",typeof(string));table.Columns.Add("名称",typeof(string));
        table.Columns.Add("X坐标(m)",typeof(double));table.Columns.Add("Y坐标(m)",typeof(double));table.Columns.Add("高度(m)",typeof(double));
        table.Columns.Add("所属区域",typeof(string));table.Columns.Add("MOC(m)",typeof(double));table.Columns.Add("OCA(m)",typeof(double));return table;
    }
    // processed329/32A --/--.cs:28883/28907.
    public void Screen(object sender,EventArgs args) {
        var db=AcApp.DocumentManager.MdiActiveDocument.Database;
        using(var tr=db.TransactionManager.StartTransaction()) points=ObstacleCadRecovered.ScreenData<DBPoint>(db,OpenMode.ForRead,false);
        Status.Text="已检测到 "+points.Count+" 个障碍物。";
        originals=new Dictionary<string,DBPoint>();var table=Table();int ordinal=1;
        foreach(var point in points) {
            var parsed=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());
            table.Rows.Add(parsed.ID,parsed.Name,Math.Round(parsed.X,2),Math.Round(parsed.Y,2),Math.Round(parsed.Z,2));originals.Add(parsed.ID,point);
        }
        Grid.DataSource=table;Grid.Columns[1].Frozen=true;
    }
    // processed32F --/--.cs:29152. Uses original points, NOT rounded grid XYZ.
    public void Evaluate(object sender,EventArgs args) {
        if(points==null || points.Count==0) return;
        double sx=CadInteractionRecovered.Number(StartX.Text),sy=CadInteractionRecovered.Number(StartY.Text),sz=CadInteractionRecovered.Number(StartHeight.Text);
        double sw=CadInteractionRecovered.Number(StartWidth.Text),sm=CadInteractionRecovered.Number(StartMoc.Text);
        double ex=CadInteractionRecovered.Number(EndX.Text),ey=CadInteractionRecovered.Number(EndY.Text),ez=CadInteractionRecovered.Number(EndHeight.Text);
        double ew=CadInteractionRecovered.Number(EndWidth.Text),em=CadInteractionRecovered.Number(EndMoc.Text);
        double length=Math.Sqrt(Math.Pow(ey-sy,2)+Math.Pow(ex-sx,2));int ordinal=1;var input=new List<PriSecObstacleRecovered>();
        foreach(var point in points) {
            var parsed=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());
            var local=PriSecRecovered.Local(sx,sy,sz,ex,ey,parsed.X,parsed.Y,parsed.Z);
            input.Add(new PriSecObstacleRecovered { ID=parsed.ID,Name=parsed.Name,X=local[0],Y=local[1],Z=parsed.Z });
        }
        var result=PriSecRecovered.Evaluate(input,sz,sw,sm,ez,ew,em,length,Intermediate.Checked);
        Status.Text="已评估"+points.Count+"个障碍物。";InRange.Text=result.Count+"个障碍物在范围内";
        result=result.OrderByDescending(p=>p.OCA).ToList();var table=Table();
        foreach(var point in result) table.Rows.Add(point.ID,point.Name,Math.Round(-point.X,2),Math.Round(-point.Y,2),Math.Round(point.Z,2),point.Area,Math.Round(point.MOC,2),Math.Round(point.OCA,2));
        Grid.DataSource=table;Grid.Columns[1].Frozen=true;
    }
    // processed33B --/--.cs:29636. Selected rows map back to original DBPoint.
    public void Mark(object sender,EventArgs args) {
        foreach(DataGridViewRow row in Grid.SelectedRows) {
            var point=originals[Grid.Rows[row.Index].Cells[0].Value.ToString()];
            var id=ObstacleCadRecovered.Insert("obst",point.Position);
            ObstacleCadRecovered.SetAttribute(id,"Altitude",point.Position.Z.ToString());
        }
    }
}
#endif
