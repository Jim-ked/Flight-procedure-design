using System.Windows.Forms;
using Fpd.Core;
namespace Fpd.AutoCAD;
internal sealed class FixDialog : Form
{
    public FixData Value { get; private set; }=new();
    public FixDialog(FixData? existing=null)
    {
        var ui=new DataEditor(this,"定位点资料",210);
        var ident=ui.Field("标识",existing?.Ident??"");
        var lat=ui.Field("纬度",DataEditor.Format(existing?.Latitude)); var lon=ui.Field("经度",DataEditor.Format(existing?.Longitude));
        FixData Read(bool draft)=>new() { Ident=ident.Text.Trim(),Latitude=DataEditor.Angle(lat,true,draft),Longitude=DataEditor.Angle(lon,false,draft),Elevation=existing?.Elevation };
        ui.Buttons(()=> { var value=Read(false); ProjectValidation.Fix(value); Value=value; DialogResult=DialogResult.OK; },
            ()=> { Value=Read(true); DialogResult=DialogResult.Retry; });
    }
}
