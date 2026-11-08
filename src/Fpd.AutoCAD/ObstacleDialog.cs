using Fpd.Core;
using TextBox=System.Windows.Controls.TextBox;
namespace Fpd.AutoCAD;
internal sealed class ObstacleDialog : ProjectWpfDialog
{
    private readonly TextBox _ident,_lat,_lon,_top,_ground; public ObstacleData Value { get; private set; }=new();
    public ObstacleDialog(ObstacleData? existing=null) : base("障碍物资料",300)
    {
        Value=existing is null?new ObstacleData():new ObstacleData { DataId=existing.DataId,Ident=existing.Ident,Latitude=existing.Latitude,Longitude=existing.Longitude,TopElevation=existing.TopElevation,GroundElevation=existing.GroundElevation };
        _ident=Field("编号",existing?.Ident??""); _lat=Field("纬度",Format(existing?.Latitude)); _lon=Field("经度",Format(existing?.Longitude)); _top=Field("顶标高 m",Format(existing?.TopElevation)); _ground=Field("地面基准高程 m",Format(existing?.GroundElevation));
    }
    private ObstacleData Read(bool draft)=>new() { DataId=Value.DataId,Ident=_ident.Text.Trim(),Latitude=Angle(_lat,true,draft),Longitude=Angle(_lon,false,draft),TopElevation=Number(_top,draft),GroundElevation=draft&&string.IsNullOrWhiteSpace(_ground.Text)?double.NaN:Number(_ground,draft) };
    protected override void Accept() { var value=Read(false); ProjectValidation.Obstacle(value); Value=value; Accepted(); }
    protected override void Pick() { Value=Read(true); Picked(); }
}
