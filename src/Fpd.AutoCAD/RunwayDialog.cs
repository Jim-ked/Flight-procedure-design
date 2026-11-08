using System.Text.RegularExpressions;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TextBox=System.Windows.Controls.TextBox;
using CheckBox=System.Windows.Controls.CheckBox;
using FrameworkElement=System.Windows.FrameworkElement;
using MediaColor=System.Windows.Media.Color;
using MediaBrushes=System.Windows.Media.Brushes;
using Fpd.Core;
namespace Fpd.AutoCAD;
internal sealed class RunwayDialog : ProjectWpfDialog
{
    private sealed class Endpoint
    {
        public readonly TextBox Latitude,Longitude,Elevation;
        public readonly CheckBox CustomThr,CustomDer;
        public readonly TextBox ThrLatitude,ThrLongitude,ThrElevation,DerLatitude,DerLongitude,DerElevation;
        public Endpoint(RunwayEndData? end,GeoPosition? opposite)
        {
            var physical=end?.PhysicalEnd; Latitude=Create(Format(physical?.Latitude)); Longitude=Create(Format(physical?.Longitude)); Elevation=Create(Format(physical?.Elevation));
            var thr=end?.Threshold; var der=end?.DepartureEnd;
            CustomThr=new CheckBox { Content="内移THR",IsChecked=thr is not null && !RunwayDefaults.Same(thr,physical) };
            CustomDer=new CheckBox { Content="特殊DER",IsChecked=der is not null && !RunwayDefaults.Same(der,opposite) };
            ThrLatitude=Create(Format(thr?.Latitude)); ThrLongitude=Create(Format(thr?.Longitude)); ThrElevation=Create(Format(thr?.Elevation)); DerLatitude=Create(Format(der?.Latitude)); DerLongitude=Create(Format(der?.Longitude)); DerElevation=Create(Format(der?.Elevation));
            SetCustomEnabled(); CustomThr.Checked+=(_,_)=>SetCustomEnabled(); CustomThr.Unchecked+=(_,_)=>SetCustomEnabled(); CustomDer.Checked+=(_,_)=>SetCustomEnabled(); CustomDer.Unchecked+=(_,_)=>SetCustomEnabled();
        }
        private static TextBox Create(string text)=>new() { Text=text,Height=27,Margin=new Thickness(3,0,3,0),Padding=new Thickness(5,2,5,2),Background=new SolidColorBrush(MediaColor.FromRgb(55,55,55)),Foreground=MediaBrushes.White };
        private void SetCustomEnabled(){ foreach(var b in new[]{ThrLatitude,ThrLongitude,ThrElevation}) b.IsEnabled=CustomThr.IsChecked==true; foreach(var b in new[]{DerLatitude,DerLongitude,DerElevation}) b.IsEnabled=CustomDer.IsChecked==true; }
        public bool HasCustom=>CustomThr.IsChecked==true||CustomDer.IsChecked==true;
    }
    private readonly TextBox _number,_width; private readonly Endpoint _a,_b; private readonly Expander _advanced; private readonly TextBlock _aLabel,_bLabel,_aAdvancedLabel,_bAdvancedLabel; private int _pickIndex;
    public RunwayData Value { get; private set; }=new(); public int PickIndex=>_pickIndex;
    public RunwayDialog(RunwayData? existing=null) : base("跑道资料",520,false)
    {
        Value=existing is null?new RunwayData():existing; var ident=existing is null?"":existing.EndA.Designator+"/"+existing.EndB.Designator;
        _number=Field("跑道编号",ident); _width=Field("跑道宽度 m",Format(existing?.Width));
        _a=new Endpoint(existing?.EndA,existing?.EndB?.PhysicalEnd); _b=new Endpoint(existing?.EndB,existing?.EndA?.PhysicalEnd);
        _aLabel=AddEndpoint("方向A物理端",_a,0); _bLabel=AddEndpoint("方向B物理端",_b,1); _number.TextChanged+=(_,_)=>UpdateDirectionLabels(); UpdateDirectionLabels();
        _advanced=new Expander { Header="附加位置（内移THR / 特殊DER）",IsExpanded=_a.HasCustom||_b.HasCustom,Margin=new Thickness(0,8,0,0),Padding=new Thickness(4) }; var advancedPanel=new StackPanel(); _aAdvancedLabel=AddCustom(advancedPanel,"方向A",_a); _bAdvancedLabel=AddCustom(advancedPanel,"方向B",_b); _advanced.Content=advancedPanel; AddFull(_advanced,0);
    }
    private TextBlock AddEndpoint(string title,Endpoint endpoint,int index)
    {
        var panel=new Grid { Margin=new Thickness(0,7,0,0) }; panel.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(126) }); panel.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(1,GridUnitType.Star) }); panel.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(78) });
        var label=new TextBlock { Text=title,VerticalAlignment=VerticalAlignment.Center }; Grid.SetColumn(label,0); panel.Children.Add(label); var values=new Grid(); for(var i=0;i<3;i++) values.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(1,GridUnitType.Star) }); Grid.SetColumn(endpoint.Latitude,0); Grid.SetColumn(endpoint.Longitude,1); Grid.SetColumn(endpoint.Elevation,2); values.Children.Add(endpoint.Latitude);values.Children.Add(endpoint.Longitude);values.Children.Add(endpoint.Elevation); Grid.SetColumn(values,1); panel.Children.Add(values);
        var pick=Button(index==0?"拾取A端":"拾取B端",()=> { Value=Read(true); _pickIndex=index; Picked(); }); Grid.SetColumn(pick,2); panel.Children.Add(pick); AddFull(panel,39); return label;
    }
    private void UpdateDirectionLabels()
    {
        var parts=Regex.Split(_number.Text.Trim(),@"\s*/\s*"); _aLabel.Text=parts.Length>0&&!string.IsNullOrWhiteSpace(parts[0])?parts[0]+" 物理端":"方向A物理端"; _bLabel.Text=parts.Length>1&&!string.IsNullOrWhiteSpace(parts[1])?parts[1]+" 物理端":"方向B物理端"; _aAdvancedLabel.Text=parts.Length>0&&!string.IsNullOrWhiteSpace(parts[0])?parts[0]+"方向":"方向A"; _bAdvancedLabel.Text=parts.Length>1&&!string.IsNullOrWhiteSpace(parts[1])?parts[1]+"方向":"方向B";
    }
    private TextBlock AddCustom(StackPanel panel,string title,Endpoint endpoint)
    {
        var heading=new TextBlock { Text=title,Margin=new Thickness(0,4,0,2),FontWeight=FontWeights.SemiBold }; panel.Children.Add(heading);
        var offset=ReferenceEquals(endpoint,_a)?0:1;
        AddOverride(panel,"使用内移入口",endpoint.CustomThr,endpoint.ThrLatitude,endpoint.ThrLongitude,endpoint.ThrElevation,2+offset);
        AddOverride(panel,"使用特殊离场端",endpoint.CustomDer,endpoint.DerLatitude,endpoint.DerLongitude,endpoint.DerElevation,4+offset);
        return heading;
    }
    private void AddOverride(StackPanel panel,string title,CheckBox toggle,TextBox lat,TextBox lon,TextBox elev,int index)
    {
        panel.Children.Add(toggle); var row=new Grid { Margin=new Thickness(0,2,0,4) }; var widths=new[]{new GridLength(45),new GridLength(1,GridUnitType.Star),new GridLength(45),new GridLength(1,GridUnitType.Star),new GridLength(45),new GridLength(1,GridUnitType.Star),new GridLength(66)}; foreach(var width in widths) row.ColumnDefinitions.Add(new ColumnDefinition{Width=width});
        void Add(string label,TextBox box,int column){var text=new TextBlock{Text=label,VerticalAlignment=VerticalAlignment.Center,Margin=new Thickness(2,0,2,0)};Grid.SetColumn(text,column);row.Children.Add(text);Grid.SetColumn(box,column+1);row.Children.Add(box);}
        Add("纬度",lat,0);Add("经度",lon,2);Add("标高 m",elev,4);var pick=Button("拾取",()=>{Value=Read(true);_pickIndex=index;Picked();});Grid.SetColumn(pick,6);row.Children.Add(pick);panel.Children.Add(row);
        void Update(){row.Visibility=toggle.IsChecked==true?Visibility.Visible:Visibility.Collapsed;} toggle.Checked+=(_,_)=>Update();toggle.Unchecked+=(_,_)=>Update();Update();
    }
    private void AddFull(FrameworkElement control,double height){var row=Fields.RowDefinitions.Count;Fields.RowDefinitions.Add(new RowDefinition{Height=height>0?new GridLength(height):GridLength.Auto});Grid.SetRow(control,row);Grid.SetColumnSpan(control,2);Fields.Children.Add(control);}
    private static GeoPosition Position(Endpoint endpoint,bool draft)=>new() { Latitude=Angle(endpoint.Latitude,true,draft),Longitude=Angle(endpoint.Longitude,false,draft),Elevation=double.IsNaN(Number(endpoint.Elevation,draft))?null:Number(endpoint.Elevation,draft) };
    private GeoPosition ReadPosition(TextBox lat,TextBox lon,TextBox elev,bool draft)=>new() { Latitude=Angle(lat,true,draft),Longitude=Angle(lon,false,draft),Elevation=double.IsNaN(Number(elev,draft))?null:Number(elev,draft) };
    private RunwayData Read(bool draft)
    {
        var parts=Regex.Split(_number.Text.Trim(),@"\s*/\s*"); if(parts.Length!=2||string.IsNullOrWhiteSpace(parts[0])||string.IsNullOrWhiteSpace(parts[1])) throw new InvalidDataException("跑道编号须填写两个相反方向，例如16R/34L。");
        var value=new RunwayData { DataId=Value.DataId,Ident=parts[0]+"/"+parts[1],Width=Number(_width,draft),EndA=new() { Designator=parts[0],PhysicalEnd=Position(_a,draft),Threshold=_a.CustomThr.IsChecked==true?ReadPosition(_a.ThrLatitude,_a.ThrLongitude,_a.ThrElevation,draft):null!,DepartureEnd=_a.CustomDer.IsChecked==true?ReadPosition(_a.DerLatitude,_a.DerLongitude,_a.DerElevation,draft):null! },EndB=new() { Designator=parts[1],PhysicalEnd=Position(_b,draft),Threshold=_b.CustomThr.IsChecked==true?ReadPosition(_b.ThrLatitude,_b.ThrLongitude,_b.ThrElevation,draft):null!,DepartureEnd=_b.CustomDer.IsChecked==true?ReadPosition(_b.DerLatitude,_b.DerLongitude,_b.DerElevation,draft):null! } };
        RunwayDefaults.Resolve(value); return value;
    }
    protected override void Accept(){var value=Read(false);ProjectValidation.Runway(value);Value=value;Accepted();}
    protected override void Pick(){Value=Read(true);Picked();}
    public static void SetPosition(RunwayData value,int index,GeoPosition position)
    {
        static bool PlanarSame(GeoPosition? a,GeoPosition? b)=>a is not null&&b is not null&&a.Latitude==b.Latitude&&a.Longitude==b.Longitude;
        switch(index)
        {
            case 0: { var end=value.EndA; var other=value.EndB; if(PlanarSame(end.Threshold,end.PhysicalEnd)) end.Threshold=RunwayDefaults.Copy(position); if(PlanarSame(other.DepartureEnd,end.PhysicalEnd)) other.DepartureEnd=RunwayDefaults.Copy(position); end.PhysicalEnd=position; break; }
            case 1: { var end=value.EndB; var other=value.EndA; if(PlanarSame(end.Threshold,end.PhysicalEnd)) end.Threshold=RunwayDefaults.Copy(position); if(PlanarSame(other.DepartureEnd,end.PhysicalEnd)) other.DepartureEnd=RunwayDefaults.Copy(position); end.PhysicalEnd=position; break; }
            case 2: value.EndA.Threshold=position; break;
            case 3: value.EndB.Threshold=position; break;
            case 4: value.EndA.DepartureEnd=position; break;
            case 5: value.EndB.DepartureEnd=position; break;
            default: throw new ArgumentOutOfRangeException(nameof(index));
        }
    }
}
