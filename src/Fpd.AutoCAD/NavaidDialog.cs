using System.Windows.Controls;
using TextBox=System.Windows.Controls.TextBox;
using ComboBox=System.Windows.Controls.ComboBox;
using MediaColor=System.Windows.Media.Color;
using MediaBrushes=System.Windows.Media.Brushes;
using Fpd.Core;
namespace Fpd.AutoCAD;
internal sealed class NavaidDialog : ProjectWpfDialog
{
    private readonly TextBox _ident,_lat,_lon; private readonly ComboBox _kind; public NavaidData Value { get; private set; }=new();
    public NavaidDialog(NavaidData? existing=null) : base("导航台资料",265)
    {
        Value=existing is null?new NavaidData():new NavaidData { DataId=existing.DataId,Ident=existing.Ident,Kind=existing.Kind,Position=new() { Latitude=existing.Position.Latitude,Longitude=existing.Position.Longitude,Elevation=existing.Position.Elevation },Name=existing.Name,FrequencyMHz=existing.FrequencyMHz,FrequencyKHz=existing.FrequencyKHz,Channel=existing.Channel,MagneticVariation=existing.MagneticVariation,GlidePathPosition=existing.GlidePathPosition,GlidePathAngle=existing.GlidePathAngle };
        _ident=Field("标识",existing?.Ident??""); _kind=new ComboBox { ItemsSource=Enum.GetNames<NavaidKind>(),SelectedItem=(existing?.Kind??NavaidKind.VOR).ToString(),Height=28,Background=new System.Windows.Media.SolidColorBrush(MediaColor.FromRgb(55,55,55)),Foreground=MediaBrushes.White }; ControlField("类型",_kind);
        _lat=Field("纬度",Format(existing?.Position.Latitude)); _lon=Field("经度",Format(existing?.Position.Longitude));
    }
    private NavaidData Read(bool draft)=>new() { DataId=Value.DataId,Ident=_ident.Text.Trim(),Kind=Enum.Parse<NavaidKind>((string)_kind.SelectedItem!),Position=new() { Latitude=Angle(_lat,true,draft),Longitude=Angle(_lon,false,draft),Elevation=Value.Position.Elevation },Name=Value.Name,FrequencyMHz=Value.FrequencyMHz,FrequencyKHz=Value.FrequencyKHz,Channel=Value.Channel,MagneticVariation=Value.MagneticVariation,GlidePathPosition=Value.GlidePathPosition,GlidePathAngle=Value.GlidePathAngle };
    protected override void Accept() { var value=Read(false); ProjectValidation.Navaid(value); Value=value; Accepted(); }
    protected override void Pick() { Value=Read(true); Picked(); }
}
