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
// A8 obstacle path only. Does not port wind spiral/other whole-window functions.
public partial class TurnAreaFormRecovered:Form {
    public TextBox LeftX,LeftY,LeftHeight,RightX,RightY,RightHeight,Dr,MinimumMoc;
    public ComboBox Gradient,Mode;
    public DataGridView Grid;public Label Status;
    private List<DBPoint> points;private Dictionary<string,DBPoint> originals;
    private sealed class Row {
        public ObstacleCadRecovered.ImportedPoint Point;public double X,Y;public double[] Values;
    }
    private static DataTable Table() {
        var table=new DataTable();table.Columns.Add("ID",typeof(string));table.Columns.Add("名称",typeof(string));
        table.Columns.Add("X坐标(m)",typeof(double));table.Columns.Add("Y坐标(m)",typeof(double));table.Columns.Add("高度(m)",typeof(double));
        table.Columns.Add("所属区域",typeof(string));table.Columns.Add("ds(m)",typeof(string));table.Columns.Add("d0(m)",typeof(string));
        table.Columns.Add("MOC(m)",typeof(double));table.Columns.Add("OCA(m)",typeof(double));table.Columns.Add("程序高度(m)",typeof(double));table.Columns.Add("MCG(%)",typeof(double));return table;
    }
    // processed24D/24E, --/--.cs:12100/12168.
    public void Screen(object sender,EventArgs args) {
        points=new List<DBPoint>();originals=new Dictionary<string,DBPoint>();var db=AcApp.DocumentManager.MdiActiveDocument.Database;
        using(var tr=db.TransactionManager.StartTransaction()) points=ObstacleCadRecovered.ScreenData<DBPoint>(db,OpenMode.ForRead,false);
        Status.Text="已检测到 "+points.Count+"  个障碍物。";var table=Table();int ordinal=1;
        foreach(var point in points) {
            var parsed=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());
            table.Rows.Add(parsed.ID,parsed.Name,Math.Round(parsed.X,2),Math.Round(parsed.Y,2),Math.Round(parsed.Z,2));originals.Add(parsed.ID,point);
        }
        Grid.DataSource=table;Grid.Columns[1].Frozen=true;
    }
    // processed25E, --/--.cs:12402. Original origin uses left.Z, endpoint's Z is
    // parsed but unused by the frame; evaluation explicitly RESTORES absolute Z.
    public void Evaluate(object sender,EventArgs args) {
        if(points==null || points.Count==0) return;
        double sx=CadInteractionRecovered.Number(LeftX),sy=CadInteractionRecovered.Number(LeftY),sz=CadInteractionRecovered.Number(LeftHeight);
        double ex=CadInteractionRecovered.Number(RightX),ey=CadInteractionRecovered.Number(RightY);
        CadInteractionRecovered.Number(RightHeight);
        double length=Math.Sqrt(Math.Pow(ey-sy,2)+Math.Pow(ex-sx,2));
        double dr=CadInteractionRecovered.Number(Dr),gradient=CadInteractionRecovered.Number(Gradient.Text)/100,moc=CadInteractionRecovered.Number(MinimumMoc);
        bool specified=Mode.Text=="指定高度";int ordinal=1;var rows=new List<Row>();
        foreach(var point in points) {
            var parsed=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());
            var local=PriSecRecovered.Local(sx,sy,sz,ex,ey,parsed.X,parsed.Y,parsed.Z);
            rows.Add(new Row { Point=parsed,X=local[0],Y=local[1],Values=ObstacleRecovered.KkEvaluation(local[0],local[1],parsed.Z,length,sz,dr,gradient,moc,false,specified) });
        }
        Status.Text="已评估"+rows.Count+"个障碍物。"+rows.Count+"个障碍物在范围内";
        rows=rows.OrderByDescending(row=>row.Values[4]).ToList();var table=Table();
        foreach(var row in rows) table.Rows.Add(row.Point.ID,row.Point.Name,Math.Round(row.X,2),Math.Round(row.Y,2),Math.Round(row.Point.Z,2),row.Y<0?"KK'线外":"KK'线内",Math.Round(dr,2),Math.Round(row.Values[0],2),Math.Round(row.Values[1]),Math.Round(row.Values[2]),Math.Round(row.Values[3],2),Math.Round(row.Values[4]*100,1));
        Grid.DataSource=table;Grid.Columns[1].Frozen=true;
    }
    // processed254 --/--.cs:12310, IL_00B5 dup/00D7/00FF resolves bad C# order.
    public void Mark(object sender,EventArgs args) {
        foreach(DataGridViewRow row in Grid.SelectedRows) {
            var point=originals[Grid.Rows[row.Index].Cells[0].Value.ToString()];
            var id=ObstacleCadRecovered.Insert("obst",point.Position);
            ObstacleCadRecovered.SetAttribute(id,"Altitude",point.Position.Z.ToString());
            ObstacleCadRecovered.SetAttribute(id,"Name",ObstacleCadRecovered.Parse(point,"").Name);
        }
    }
}
#endif
