using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using TextBox=System.Windows.Controls.TextBox;
using CheckBox=System.Windows.Controls.CheckBox;
using TabControl=System.Windows.Controls.TabControl;
using TabItem=System.Windows.Controls.TabItem;
using MediaColor=System.Windows.Media.Color;
using MediaBrushes=System.Windows.Media.Brushes;
using System.Windows.Media;
using Fpd.Core;
namespace Fpd.AutoCAD;
internal sealed class RunwayDialog : ProjectWpfDialog
{
    private readonly TextBox _ident,_width,_aDesignator,_bDesignator;
    private readonly TextBox[] _lat=new TextBox[6],_lon=new TextBox[6],_elev=new TextBox[6];
    private readonly CheckBox[] _custom=new CheckBox[6]; private int _pickIndex;
    public RunwayData Value { get; private set; }=new(); public int PickIndex=>_pickIndex;
    private static readonly string[] Names={"A 实际端","A THR入口","A DER离场端","B 实际端","B THR入口","B DER离场端"};
    public RunwayDialog(RunwayData? value=null) : base("跑道资料",560)
    {
        Value=value is null?new RunwayData():value; _ident=Field("跑道方向",value?.Ident??""); _width=Field("宽度 m",Format(value?.Width)); _aDesignator=Field("方向 A",value?.EndA.Designator??""); _bDesignator=Field("方向 B",value?.EndB.Designator??"");
        var directions=new TabControl { Margin=new Thickness(0,8,0,0),Height=225 };
        directions.Items.Add(DirectionTab(0,"方向 A",value?.EndA,value?.EndB.PhysicalEnd)); directions.Items.Add(DirectionTab(3,"方向 B",value?.EndB,value?.EndA.PhysicalEnd));
        var row=Fields.RowDefinitions.Count; Fields.RowDefinitions.Add(new RowDefinition { Height=new GridLength(238) }); Grid.SetRow(directions,row); Grid.SetColumnSpan(directions,2); Fields.Children.Add(directions);
    }
    private TabItem DirectionTab(int offset,string title,RunwayEndData? end,GeoPosition? opposite)
    {
        var panel=new StackPanel { Margin=new Thickness(0,6,0,0) };
        for(var j=0;j<3;j++)
        {
            var i=offset+j; var grid=new Grid { Margin=new Thickness(0,2,0,2) }; grid.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(105) }); grid.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(1,GridUnitType.Star) }); grid.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(1,GridUnitType.Star) }); grid.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(1,GridUnitType.Star) });
            var label=new TextBlock { Text=Names[i],VerticalAlignment=VerticalAlignment.Center }; Grid.SetColumn(label,0); grid.Children.Add(label);
            var position=j==0?end?.PhysicalEnd:j==1?end?.Threshold:end?.DepartureEnd; _lat[i]=Small(Format(position?.Latitude),i); _lon[i]=Small(Format(position?.Longitude),i); _elev[i]=Small(Format(position?.Elevation),i);
            foreach(var box in new[]{_lat[i],_lon[i],_elev[i]}) { Grid.SetColumn(box,1+Array.IndexOf(new[]{_lat[i],_lon[i],_elev[i]},box)); grid.Children.Add(box); }
            _custom[i]=new CheckBox { Content="自定义",IsChecked=j==0 || position is not null && !RunwayDefaults.Same(position,j==1?end?.PhysicalEnd:opposite),VerticalAlignment=VerticalAlignment.Center,Margin=new Thickness(5,0,0,0) }; Grid.SetColumn(_custom[i],3); grid.Children.Add(_custom[i]); panel.Children.Add(grid);
            var enabled=j==0 || _custom[i].IsChecked==true; _lat[i].IsEnabled=_lon[i].IsEnabled=_elev[i].IsEnabled=enabled; _custom[i].Checked+=(_,_)=>SetEnabled(i,true); _custom[i].Unchecked+=(_,_)=>SetEnabled(i,false);
        }
        return new TabItem { Header=title+" · THR / DER",Content=panel };
    }
    private TextBox Small(string text,int index) { var b=new TextBox { Text=text,Height=27,Margin=new Thickness(3,0,3,0),Padding=new Thickness(5,2,5,2),Background=new SolidColorBrush(MediaColor.FromRgb(55,55,55)),Foreground=MediaBrushes.White }; b.GotFocus+=(_,_)=>_pickIndex=index; return b; }
    private void SetEnabled(int i,bool enabled) { _lat[i].IsEnabled=_lon[i].IsEnabled=_elev[i].IsEnabled=enabled; }
    private GeoPosition? Position(int i,bool draft)
    {
        if(i%3!=0 && _custom[i].IsChecked!=true) return null;
        return new GeoPosition { Latitude=Angle(_lat[i],true,draft),Longitude=Angle(_lon[i],false,draft),Elevation=double.IsNaN(Number(_elev[i],draft))?null:Number(_elev[i],draft) };
    }
    private RunwayData Read(bool draft)
    {
        var value=new RunwayData { DataId=Value.DataId,Ident=_ident.Text.Trim(),Width=Number(_width,draft),EndA=new() { Designator=_aDesignator.Text.Trim(),PhysicalEnd=Position(0,draft)??new(),Threshold=Position(1,draft)!,DepartureEnd=Position(2,draft)! },EndB=new() { Designator=_bDesignator.Text.Trim(),PhysicalEnd=Position(3,draft)??new(),Threshold=Position(4,draft)!,DepartureEnd=Position(5,draft)! } };
        if(string.IsNullOrWhiteSpace(value.Ident)) value.Ident=value.EndA.Designator+"/"+value.EndB.Designator; RunwayDefaults.Resolve(value); return value;
    }
    protected override void Accept() { var value=Read(false); ProjectValidation.Runway(value); Value=value; Accepted(); }
    protected override void Pick() { Value=Read(true); Picked(); }
    public static void SetPosition(RunwayData value,int index,GeoPosition position)
    {
        var end=index<3?value.EndA:value.EndB; switch(index%3) { case 0: var other=index<3?value.EndB:value.EndA; if(RunwayDefaults.Same(end.Threshold,end.PhysicalEnd)) end.Threshold=RunwayDefaults.Copy(position); if(RunwayDefaults.Same(other.DepartureEnd,end.PhysicalEnd)) other.DepartureEnd=RunwayDefaults.Copy(position); end.PhysicalEnd=position; break; case 1:end.Threshold=position;break; case 2:end.DepartureEnd=position;break; }
    }
}
