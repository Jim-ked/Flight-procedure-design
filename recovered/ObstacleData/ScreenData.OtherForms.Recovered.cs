// Recovered repeated window slices. Native reference compilation/host tests pending.
// Designer/config and the other evaluation methods are outside this file.
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

public partial class DepartureObstacleFormRecovered:Form {
    public DataGridView Grid;public Label Status;
    private List<DBPoint> points;private Dictionary<string,DBPoint> originals;
    // 0x06000279 03_recovered-src\annotated-strings\--\--.cs:14324
    public void Screen(object sender,EventArgs args) {
        points=new List<DBPoint>();originals=new Dictionary<string,DBPoint>();
        var db=AcApp.DocumentManager.MdiActiveDocument.Database;
        using(var tr=db.TransactionManager.StartTransaction()) {
            points=ObstacleCadRecovered.ScreenData<DBPoint>(db,OpenMode.ForRead,false);
        }
        Status.Text="已检测到 "+points.Count+" 个障碍物。";
        ShowImported();
    }
    // 0x0600027A 03_recovered-src\annotated-strings\--\--.cs:14346
    private void ShowImported() {
        var table=new DataTable();
        table.Columns.Add("ID", typeof(string));
        table.Columns.Add("名称", typeof(string));
        table.Columns.Add("X坐标(m)", typeof(double));
        table.Columns.Add("Y坐标(m)", typeof(double));
        table.Columns.Add("高度(m)", typeof(double));
        table.Columns.Add("所属区域", typeof(string));
        table.Columns.Add("dr(m)", typeof(string));
        table.Columns.Add("d0(m)", typeof(string));
        table.Columns.Add("MOC(m)", typeof(double));
        table.Columns.Add("OCA(m)", typeof(double));
        table.Columns.Add("程序高度(m)", typeof(double));
        table.Columns.Add("minPDG(%)", typeof(double));
        int ordinal=1;
        foreach(var point in points) {
            var p=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());
            table.Rows.Add(p.ID,p.Name,Math.Round(p.X,2),Math.Round(p.Y,2),Math.Round(p.Z,2));originals.Add(p.ID,point);
        }
        Grid.DataSource=table;Grid.Columns[1].Frozen=true;
    }
    // 0x06000293 03_recovered-src\annotated-strings\--\--.cs:15238
    public void Mark(object sender,EventArgs args) {
        foreach(DataGridViewRow row in Grid.SelectedRows) {
            var point=originals[Grid.Rows[row.Index].Cells[0].Value.ToString()];
            var id=ObstacleCadRecovered.Insert("obst",point.Position);
            ObstacleCadRecovered.SetAttribute(id,"Altitude",point.Position.Z.ToString());
        }
    }
}

public partial class DmeObstacleFormRecovered:Form {
    public DataGridView Grid;public Label Status;
    private List<DBPoint> points;private Dictionary<string,DBPoint> originals;
    // 0x060002D5 03_recovered-src\annotated-strings\--\--.cs:19095
    public void Screen(object sender,EventArgs args) {
        points=new List<DBPoint>();
        var db=AcApp.DocumentManager.MdiActiveDocument.Database;
        using(var tr=db.TransactionManager.StartTransaction()) {
            points=ObstacleCadRecovered.ScreenData<DBPoint>(db,OpenMode.ForRead,false);
        }
        Status.Text="已检测到 "+points.Count+" 个障碍物。";
        ShowImported();
    }
    // 0x060002D6 03_recovered-src\annotated-strings\--\--.cs:19121
    private void ShowImported() {
        originals=new Dictionary<string,DBPoint>();
        var table=new DataTable();
        table.Columns.Add("ID", typeof(string));
        table.Columns.Add("名称", typeof(string));
        table.Columns.Add("X坐标(m)", typeof(double));
        table.Columns.Add("Y坐标(m)", typeof(double));
        table.Columns.Add("高度(m)", typeof(double));
        table.Columns.Add("所属区域", typeof(string));
        table.Columns.Add("MOC(m)", typeof(double));
        table.Columns.Add("OCA(m)", typeof(double));
        int ordinal=1;
        foreach(var point in points) {
            var p=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());
            table.Rows.Add(p.ID,p.Name,Math.Round(p.X,2),Math.Round(p.Y,2),Math.Round(p.Z,2));originals.Add(p.ID,point);
        }
        Grid.DataSource=table;Grid.Columns[1].Frozen=true;
    }
    // 0x060002E2 03_recovered-src\annotated-strings\--\--.cs:21404
    public void Mark(object sender,EventArgs args) {
        foreach(DataGridViewRow row in Grid.SelectedRows) {
            var point=originals[Grid.Rows[row.Index].Cells[0].Value.ToString()];
            var id=ObstacleCadRecovered.Insert("Obst",point.Position);
            ObstacleCadRecovered.SetAttribute(id,"Altitude",point.Position.Z.ToString());
        }
    }
}

public partial class ApproachObstacleFormRecovered:Form {
    public DataGridView Grid;public Label Status;
    private List<DBPoint> points;private Dictionary<string,DBPoint> originals;
    // 0x06000476 03_recovered-src\annotated-strings\--\--.cs:47083
    public void Screen(object sender,EventArgs args) {
        var db=AcApp.DocumentManager.MdiActiveDocument.Database;
        using(var tr=db.TransactionManager.StartTransaction()) {
            points=ObstacleCadRecovered.ScreenData<DBPoint>(db,OpenMode.ForRead,false);
        }
        Status.Text="已检测到 "+points.Count+" 个障碍物。";
        ShowImported();
    }
    // 0x06000477 03_recovered-src\annotated-strings\--\--.cs:47109
    private void ShowImported() {
        originals=new Dictionary<string,DBPoint>();
        var table=new DataTable();
        table.Columns.Add("ID", typeof(string));
        table.Columns.Add("名称", typeof(string));
        table.Columns.Add("X坐标(m)", typeof(double));
        table.Columns.Add("Y坐标(m)", typeof(double));
        table.Columns.Add("高度(m)", typeof(double));
        table.Columns.Add("所属区域", typeof(string));
        table.Columns.Add("MOC(m)", typeof(double));
        table.Columns.Add("OCA(m)", typeof(double));
        table.Columns.Add("OCH(m)", typeof(double));
        table.Columns.Add("MDA(m)", typeof(double));
        table.Columns.Add("MDH(m)", typeof(double));
        table.Columns.Add("VIS(m)", typeof(double));
        int ordinal=1;
        foreach(var point in points) {
            var p=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());
            table.Rows.Add(p.ID,p.Name,Math.Round(p.X,2),Math.Round(p.Y,2),Math.Round(p.Z,2));originals.Add(p.ID,point);
        }
        Grid.DataSource=table;Grid.Columns[1].Frozen=true;
    }
    // 0x0600048C 03_recovered-src\annotated-strings\--\--.cs:47512
    public void Mark(object sender,EventArgs args) {
        foreach(DataGridViewRow row in Grid.SelectedRows) {
            var point=originals[Grid.Rows[row.Index].Cells[0].Value.ToString()];
            var id=ObstacleCadRecovered.Insert("obst",point.Position);
            ObstacleCadRecovered.SetAttribute(id,"Altitude",point.Position.Z.ToString());
        }
    }
}

public partial class PbnIlsObstacleFormRecovered:Form {
    public DataGridView Grid;public Label Status;
    private List<DBPoint> points;private Dictionary<string,DBPoint> originals;
    // 0x06000555 03_recovered-src\annotated-strings\--\--.cs:60800
    public void Screen(object sender,EventArgs args) {
        points=new List<DBPoint>();originals=new Dictionary<string,DBPoint>();
        var db=AcApp.DocumentManager.MdiActiveDocument.Database;
        using(var tr=db.TransactionManager.StartTransaction()) {
            points=ObstacleCadRecovered.ScreenData<DBPoint>(db,OpenMode.ForRead,false);
            if(points.Count>5) { MessageBox.Show("基础版仅提供前5项数据评估。");points=points.Take(5).ToList(); }
        }
        Status.Text="已检测到 "+points.Count+" 个障碍物。";
        ShowImported();
    }
    // 0x06000556 03_recovered-src\annotated-strings\--\--.cs:60835
    private void ShowImported() {
        var table=new DataTable();
        table.Columns.Add("ID", typeof(string));
        table.Columns.Add("名称", typeof(string));
        table.Columns.Add("X坐标(m)", typeof(double));
        table.Columns.Add("Y坐标(m)", typeof(double));
        table.Columns.Add("高度(m)", typeof(double));
        table.Columns.Add("所属区域", typeof(string));
        table.Columns.Add("面高(m)", typeof(double));
        table.Columns.Add("穿透值(m)", typeof(double));
        table.Columns.Add("HL(m)", typeof(double));
        table.Columns.Add("Ha(m)", typeof(double));
        table.Columns.Add("DA(m)", typeof(double));
        table.Columns.Add("DH(m)", typeof(double));
        table.Columns.Add("RVR(m)", typeof(double));
        int ordinal=1;
        foreach(var point in points) {
            var p=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());
            table.Rows.Add(p.ID,p.Name,Math.Round(p.X,2),Math.Round(p.Y,2),Math.Round(p.Z,2));originals.Add(p.ID,point);
        }
        Grid.DataSource=table;Grid.Columns[1].Frozen=true;
    }
    // 0x0600057D 03_recovered-src\annotated-strings\--\--.cs:62563
    public void Mark(object sender,EventArgs args) {
        foreach(DataGridViewRow row in Grid.SelectedRows) {
            var point=originals[Grid.Rows[row.Index].Cells[0].Value.ToString()];
            var id=ObstacleCadRecovered.Insert("obst",point.Position);
            ObstacleCadRecovered.SetAttribute(id,"Altitude",point.Position.Z.ToString());
        }
    }
    // Actual buttonEvl body 0x06000566; other evaluation methods still exist.
    public void EvaluateButton(object sender,EventArgs args) { MessageBox.Show("基础版不支持此功能。"); }
}

public partial class PbnDepartureObstacleFormRecovered:Form {
    public DataGridView Grid;public Label Status;
    private List<DBPoint> points;private Dictionary<string,DBPoint> originals;
    // 0x060004F6 03_recovered-src\annotated-strings\--\--.cs:56380
    public void Screen(object sender,EventArgs args) {
        points=new List<DBPoint>();originals=new Dictionary<string,DBPoint>();
        var db=AcApp.DocumentManager.MdiActiveDocument.Database;
        using(var tr=db.TransactionManager.StartTransaction()) {
            points=ObstacleCadRecovered.ScreenData<DBPoint>(db,OpenMode.ForRead,false);
            if(points.Count>5) { MessageBox.Show("基础版仅提供前5项数据评估。");points=points.Take(5).ToList(); }
        }
        Status.Text="已检测到 "+points.Count+" 个障碍物。";
        ShowImported();
    }
    // 0x060004F7 03_recovered-src\annotated-strings\--\--.cs:56430
    private void ShowImported() {
        var table=new DataTable();
        table.Columns.Add("ID", typeof(string));
        table.Columns.Add("名称", typeof(string));
        table.Columns.Add("X坐标(m)", typeof(double));
        table.Columns.Add("Y坐标(m)", typeof(double));
        table.Columns.Add("高度(m)", typeof(double));
        table.Columns.Add("dr(m)", typeof(string));
        table.Columns.Add("d0(m)", typeof(string));
        table.Columns.Add("MOC(m)", typeof(double));
        table.Columns.Add("OCA(m)", typeof(double));
        table.Columns.Add("程序高度(%)", typeof(double));
        table.Columns.Add("minPDG(%)", typeof(double));
        int ordinal=1;
        foreach(var point in points) {
            var p=ObstacleCadRecovered.Parse(point,(ordinal++).ToString());
            table.Rows.Add(p.ID,p.Name,Math.Round(p.X,2),Math.Round(p.Y,2),Math.Round(p.Z,2));originals.Add(p.ID,point);
        }
        Grid.DataSource=table;Grid.Columns[1].Frozen=true;
    }
    // 0x06000511 03_recovered-src\annotated-strings\--\--.cs:57259
    public void Mark(object sender,EventArgs args) {
        foreach(DataGridViewRow row in Grid.SelectedRows) {
            var point=originals[Grid.Rows[row.Index].Cells[0].Value.ToString()];
            var id=ObstacleCadRecovered.Insert("obst",point.Position);
            ObstacleCadRecovered.SetAttribute(id,"Altitude",point.Position.Z.ToString());
        }
    }
    // Actual buttonEvl body 0x06000501; other evaluation methods still exist.
    public void EvaluateButton(object sender,EventArgs args) { MessageBox.Show("请指定转弯点。"); }
}
#endif
