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
        _ident=Field("标识",existing?.Ident??""); var choices=NavaidKindCatalog.Choices.Select(NavaidKindCatalog.Display).ToList(); if(existing?.Kind==NavaidKind.ILS) choices.Add(NavaidKindCatalog.Display(NavaidKind.ILS)); _kind=new ComboBox { ItemsSource=choices,SelectedItem=NavaidKindCatalog.Display(existing?.Kind??NavaidKind.VOR),Height=28,Background=System.Windows.Media.Brushes.White,Foreground=System.Windows.Media.Brushes.Black,BorderBrush=new System.Windows.Media.SolidColorBrush(MediaColor.FromRgb(140,140,140)),ItemContainerStyle=CreateComboItemStyle() }; ControlField("类型",_kind);
        _lat=Field("纬度",Format(existing?.Position.Latitude)); _lon=Field("经度",Format(existing?.Position.Longitude));
    }
    private static System.Windows.Style CreateComboItemStyle()
    {
        var style=new System.Windows.Style(typeof(ComboBoxItem)); style.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Control.ForegroundProperty,System.Windows.Media.Brushes.Black)); style.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Control.BackgroundProperty,System.Windows.Media.Brushes.White));
        var highlighted=new System.Windows.DataTrigger { Binding=new System.Windows.Data.Binding("IsHighlighted"),Value=true }; highlighted.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Control.BackgroundProperty,new System.Windows.Media.SolidColorBrush(MediaColor.FromRgb(220,235,250)))); highlighted.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Control.ForegroundProperty,System.Windows.Media.Brushes.Black)); style.Triggers.Add(highlighted);
        var hovered=new System.Windows.DataTrigger { Binding=new System.Windows.Data.Binding("IsMouseOver"),Value=true }; hovered.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Control.BackgroundProperty,new System.Windows.Media.SolidColorBrush(MediaColor.FromRgb(220,235,250)))); hovered.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Control.ForegroundProperty,System.Windows.Media.Brushes.Black)); style.Triggers.Add(hovered);
        var selected=new System.Windows.DataTrigger { Binding=new System.Windows.Data.Binding("IsSelected"),Value=true }; selected.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Control.BackgroundProperty,new System.Windows.Media.SolidColorBrush(MediaColor.FromRgb(45,95,140)))); selected.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Control.ForegroundProperty,System.Windows.Media.Brushes.White)); style.Triggers.Add(selected); return style;
    }
    private NavaidData Read(bool draft)=>new() { DataId=Value.DataId,Ident=_ident.Text.Trim(),Kind=NavaidKindCatalog.FromDisplay((string)_kind.SelectedItem!),Position=new() { Latitude=Angle(_lat,true,draft),Longitude=Angle(_lon,false,draft),Elevation=Value.Position.Elevation },Name=Value.Name,FrequencyMHz=Value.FrequencyMHz,FrequencyKHz=Value.FrequencyKHz,Channel=Value.Channel,MagneticVariation=Value.MagneticVariation,GlidePathPosition=Value.GlidePathPosition,GlidePathAngle=Value.GlidePathAngle };
    protected override void Accept() { var value=Read(false); ProjectValidation.Navaid(value); Value=value; Accepted(); }
    protected override void Pick() { Value=Read(true); Picked(); }
}
