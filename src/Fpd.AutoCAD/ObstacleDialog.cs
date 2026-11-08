using System.Windows.Forms;
using Fpd.Core;
namespace Fpd.AutoCAD;
internal sealed class ObstacleDialog : Form
{
    public ObstacleData Value { get; private set; }=new();
    public ObstacleDialog(ObstacleData? existing=null)
    {
        var ui=new DataEditor(this,"障碍物资料",320);
        var ident=ui.Field("编号",existing?.Ident??"");
        var lat=ui.Field("纬度",DataEditor.Format(existing?.Latitude)); var lon=ui.Field("经度",DataEditor.Format(existing?.Longitude));
        var top=ui.Field("顶标高 m",DataEditor.Format(existing?.TopElevation)); var ground=ui.Field("地面基准高程 m",DataEditor.Format(existing?.GroundElevation));
        var height=ui.Field("自身高度 m（计算）",""); height.ReadOnly=true; height.TabStop=false;
        void Height() { if(double.TryParse(top.Text,out var t) && double.TryParse(ground.Text,out var g)) height.Text=DataEditor.Format(t-g); else height.Clear(); }
        top.TextChanged+=(_,_)=>Height(); ground.TextChanged+=(_,_)=>Height(); Height();
        ObstacleData Read(bool draft)=>new() { Ident=ident.Text.Trim(),Latitude=DataEditor.Angle(lat,true,draft),Longitude=DataEditor.Angle(lon,false,draft),TopElevation=DataEditor.Number(top,draft),GroundElevation=draft && string.IsNullOrWhiteSpace(ground.Text)?null:DataEditor.Number(ground,draft) };
        ui.Buttons(()=> { var value=Read(false); ProjectValidation.Obstacle(value); Value=value; DialogResult=DialogResult.OK; },
            ()=> { Value=Read(true); DialogResult=DialogResult.Retry; });
    }
}
