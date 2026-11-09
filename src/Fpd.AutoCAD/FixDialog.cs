using Fpd.Core;
using TextBox=System.Windows.Controls.TextBox;
using System.Windows;
namespace Fpd.AutoCAD;
internal sealed class FixDialog : ProjectWpfDialog
{
    private readonly TextBox _ident,_lat,_lon; public FixData Value { get; private set; }=new();
    public FixDialog(FixData? existing=null) : base("定位点资料",230)
    {
        _ident=Field("标识",existing?.Ident??""); _lat=Field("纬度",Format(existing?.Latitude)); _lon=Field("经度",Format(existing?.Longitude));
        Value=existing is null?new FixData():new FixData { DataId=existing.DataId,Ident=existing.Ident,Latitude=existing.Latitude,Longitude=existing.Longitude,Elevation=existing.Elevation };
    }
    private FixData Read(bool draft)=>new() { DataId=Value.DataId,Ident=_ident.Text.Trim(),Latitude=Angle(_lat,true,draft),Longitude=Angle(_lon,false,draft),Elevation=Value.Elevation };
    protected override void Accept() { var value=Read(false); ProjectValidation.Fix(value); Value=value; Accepted(); }
    protected override void Pick() { Value=Read(true); Picked(); }
}
