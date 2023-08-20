using Microsoft.UI.Xaml.Controls;
using PowerTune.ViewModels;

namespace PowerTune.Views;
public sealed partial class TweaksPage : Page
{
    public TweaksViewModel ViewModel
    {
        get;
    }

    public TweaksPage()
    {
        ViewModel = App.GetService<TweaksViewModel>();
        InitializeComponent();
    }

    private async void Page_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        if(ViewModel.ShowErrorDialog != false)
            await ErrorDialog.ShowAsync();
    }

}