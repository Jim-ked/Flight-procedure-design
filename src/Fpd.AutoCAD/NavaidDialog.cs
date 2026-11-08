using System.Windows.Forms;
using Fpd.Core;
namespace Fpd.AutoCAD;
internal sealed class NavaidDialog : Form
{
    public NavaidData Value { get; private set; }=new();
    public NavaidDialog(NavaidData? existing=null)
    {
        var ui=new DataEditor(this,"导航台资料",245);
        var ident=ui.Field("名称或代号",existing?.Ident??"");
        var kind=new ComboBox { DropDownStyle=ComboBoxStyle.DropDownList,Dock=DockStyle.Fill }; kind.Items.AddRange(Enum.GetNames<NavaidKind>()); kind.SelectedItem=(existing?.Kind??NavaidKind.VOR).ToString(); ui.ControlField("类型",kind);
        var lat=ui.Field("绝对纬度",DataEditor.Format(existing?.Position.Latitude)); var lon=ui.Field("绝对经度",DataEditor.Format(existing?.Position.Longitude));
        NavaidData Read(bool draft)=>new() { Ident=ident.Text.Trim(),Kind=Enum.Parse<NavaidKind>((string)kind.SelectedItem!),
            Position=new() { Latitude=DataEditor.Angle(lat,true,draft),Longitude=DataEditor.Angle(lon,false,draft),Elevation=existing?.Position.Elevation },
            Name=existing?.Name??"",FrequencyMHz=existing?.FrequencyMHz,FrequencyKHz=existing?.FrequencyKHz,Channel=existing?.Channel,
            MagneticVariation=existing?.MagneticVariation,GlidePathPosition=existing?.GlidePathPosition,GlidePathAngle=existing?.GlidePathAngle };
        ui.Buttons(()=> { var value=Read(false); ProjectValidation.Navaid(value); Value=value; DialogResult=DialogResult.OK; },
            ()=> { Value=Read(true); DialogResult=DialogResult.Retry; });
    }
}
