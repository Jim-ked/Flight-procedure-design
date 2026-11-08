using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Interop;
using Forms=System.Windows.Forms;
using Fpd.Core;
using WpfTextBox=System.Windows.Controls.TextBox;
using WpfControl=System.Windows.Controls.Control;
using WpfButton=System.Windows.Controls.Button;
using MediaColor=System.Windows.Media.Color;
using MediaBrushes=System.Windows.Media.Brushes;
using WpfFontFamily=System.Windows.Media.FontFamily;

namespace Fpd.AutoCAD;

internal enum ProjectDialogOutcome { Cancel, Accept, Pick }

internal abstract class ProjectWpfDialog : Window, IDisposable
{
    protected readonly Grid Fields = new();
    private ProjectDialogOutcome _outcome;
    protected ProjectWpfDialog(string title, double height, bool showPick = true)
    {
        Title=title; Width=440; Height=height; MinWidth=400; ResizeMode=ResizeMode.NoResize;
        WindowStartupLocation=WindowStartupLocation.CenterOwner; ShowInTaskbar=false;
        Background=new SolidColorBrush(MediaColor.FromRgb(37,37,37)); Foreground=MediaBrushes.Gainsboro;
        FontFamily=new WpfFontFamily("Microsoft YaHei UI"); FontSize=13;
        var root=new Grid { Margin=new Thickness(12) }; root.RowDefinitions.Add(new RowDefinition { Height=new GridLength(1,GridUnitType.Star) }); root.RowDefinitions.Add(new RowDefinition { Height=GridLength.Auto });
        Fields.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(126) }); Fields.ColumnDefinitions.Add(new ColumnDefinition { Width=new GridLength(1,GridUnitType.Star) }); root.Children.Add(Fields);
        var buttons=new StackPanel { Orientation=System.Windows.Controls.Orientation.Horizontal,HorizontalAlignment=System.Windows.HorizontalAlignment.Right,Margin=new Thickness(0,12,0,0) };
        if(showPick) buttons.Children.Add(Button("CAD拾点",()=> { try { Pick(); } catch(Exception ex) { System.Windows.MessageBox.Show(this,ex.Message,Title,MessageBoxButton.OK,MessageBoxImage.Warning); } }));
        buttons.Children.Add(Button("确定",Accept)); buttons.Children.Add(Button("取消",Cancel)); Grid.SetRow(buttons,1); root.Children.Add(buttons); Content=root;
    }
    protected abstract void Accept();
    protected virtual void Pick() { }
    protected void Accepted() { _outcome=ProjectDialogOutcome.Accept; Close(); }
    protected virtual void Cancel() { _outcome=ProjectDialogOutcome.Cancel; Close(); }
    protected void Picked() { _outcome=ProjectDialogOutcome.Pick; Close(); }
    protected WpfTextBox Field(string title,string value)
    {
        var row=Fields.RowDefinitions.Count; Fields.RowDefinitions.Add(new RowDefinition { Height=new GridLength(34) });
        var label=new TextBlock { Text=title,VerticalAlignment=VerticalAlignment.Center,Margin=new Thickness(0,0,8,0) }; var box=new WpfTextBox { Text=value,Height=28,Padding=new Thickness(6,3,6,3),Background=new SolidColorBrush(MediaColor.FromRgb(55,55,55)),Foreground=MediaBrushes.White,BorderBrush=new SolidColorBrush(MediaColor.FromRgb(90,90,90)) };
        Grid.SetRow(label,row); Grid.SetColumn(label,0); Grid.SetRow(box,row); Grid.SetColumn(box,1); Fields.Children.Add(label); Fields.Children.Add(box); return box;
    }
    protected void ControlField(string title,WpfControl control)
    {
        var row=Fields.RowDefinitions.Count; Fields.RowDefinitions.Add(new RowDefinition { Height=new GridLength(34) }); var label=new TextBlock { Text=title,VerticalAlignment=VerticalAlignment.Center,Margin=new Thickness(0,0,8,0) };
        Grid.SetRow(label,row); Grid.SetColumn(label,0); Grid.SetRow(control,row); Grid.SetColumn(control,1); Fields.Children.Add(label); Fields.Children.Add(control);
    }
    protected WpfButton Button(string title,Action action) { var b=new WpfButton { Content=title,MinWidth=74,Height=30,Margin=new Thickness(5,0,0,0),Padding=new Thickness(10,2,10,2),Background=new SolidColorBrush(MediaColor.FromRgb(57,57,57)),Foreground=MediaBrushes.White,BorderBrush=new SolidColorBrush(MediaColor.FromRgb(90,90,90)) }; b.Click+=(_,_)=>action(); return b; }
    public Forms.DialogResult ShowDialog(Forms.IWin32Window owner)
    {
        new WindowInteropHelper(this).Owner=owner.Handle; base.ShowDialog(); return _outcome switch { ProjectDialogOutcome.Accept=>Forms.DialogResult.OK,ProjectDialogOutcome.Pick=>Forms.DialogResult.Retry,_=>Forms.DialogResult.Cancel };
    }
    public void Dispose() { if(IsVisible) Close(); }
    protected static string Format(double? value)=>value.HasValue && double.IsFinite(value.Value)?value.Value.ToString("G17",CultureInfo.InvariantCulture):"";
    protected static double Angle(WpfTextBox box,bool latitude,bool draft)=>draft && string.IsNullOrWhiteSpace(box.Text)?double.NaN:CoordinateInput.Parse(box.Text,latitude);
    protected static double Number(WpfTextBox box,bool draft)=>draft && string.IsNullOrWhiteSpace(box.Text)?double.NaN:double.Parse(box.Text,NumberStyles.Float,CultureInfo.InvariantCulture);
}
