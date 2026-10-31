#if AUTOCAD
using System;
using System.Windows.Forms;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using AcApp=Autodesk.AutoCAD.ApplicationServices.Core.Application;
// Partial event slice. Designer/config load-save remain in evidence; no replacement UI.
public partial class RandomPointFormRecovered:Form {
    public TextBox Count,MinAltitude,MaxAltitude,RangeKm,TextHeight;
    public CheckBox ShowName,ShowAltitude;
    // Original0600034A/RVA4EC88 processed349; --/--.cs:31100.
    public void Generate(object sender,EventArgs args) {
        var db=HostApplicationServices.WorkingDatabase;
        CadInteractionRecovered.SetFocus(AcApp.DocumentManager.MdiActiveDocument.Window.Handle);
        Visible=false;Point3d center=CadInteractionRecovered.Pick("请指定中心点");
        if(center==Point3d.Origin) { Visible=true;return; }
        Visible=true;
        int count=Convert.ToInt32(Count.Text);
        double min=CadInteractionRecovered.Number(MinAltitude.Text),max=CadInteractionRecovered.Number(MaxAltitude.Text);
        double range=1000*CadInteractionRecovered.Number(RangeKm.Text);int textHeight=Convert.ToInt32(TextHeight.Text);
        var random=new Random();
        for(int i=0;i<count;i++) {
            double radiusSample=random.NextDouble(),angleSample=random.NextDouble(),heightSample=random.NextDouble();
            double[] xyz=ObstacleRecovered.RandomCoordinates(center.X,center.Y,range,min,max,radiusSample,angleSample,heightSample);
            var position=new Point3d(xyz[0],xyz[1],xyz[2]);
            string id=CalcuCadRecovered.AppendWithoutMetadata(new DBPoint { Position=position },db).ToString();
            string name=ObstacleRecovered.DerivedName(id),text="";
            if(ShowName.Checked) text+=name+"\n";
            if(ShowAltitude.Checked) text+=xyz[2];
            CalcuCadRecovered.AppendWithoutMetadata(new MText { Location=position,Contents=text,TextHeight=textHeight,Attachment=(AttachmentPoint)1 },db);
        }
    }
}
#endif
